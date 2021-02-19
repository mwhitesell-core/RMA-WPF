'===============================================================================
' Microsoft Caching Application Block for .NET
' http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnpag/html/CachingBlock.asp
'
' SqlServerCacheStorage.vb
' This class is used to cache data into a Sqldatabase
'
'===============================================================================
' Copyright (C) 2003 Microsoft Corporation
' All rights reserved.
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
' OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
' LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
' FITNESS FOR A PARTICULAR PURPOSE.
'===============================================================================
Imports System.Xml
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Runtime.Serialization.Formatters.Binary
Imports Core.DataAccess.SqlServer
Imports System.Globalization
Imports Core.ExceptionManagement
Imports System.IO

' Used for Data Access Management

' Used for Handling Exceptions

' Used for Data Protection of the data being cached

' Used for Caching Management

Namespace Storages
    ' <summary>
    '		Sample SqlServer storage provider used to
    '		cache data into a database.
    ' </summary>
    ' <remarks>
    '		This provider uses the following attributes on the XML file:
    ' <list type="">
    '		<item>
    '		<b>Assembly</b> 
    '		Used to specify the provider assembly (Required)
    '		</item>
    '		<item>
    '		<b>ClassName</b> 
    '		Used to specify the provider class name (Required)
    '		</item>
    '		<item>
    '		<b>ApplicationName</b> 
    '		Used to specify the application name that 
    '		will use this provider (Optional)
    '		</item>
    '		<item>
    '		<b>ConnectionString</b> 
    '		Used to specify the connection string for a
    '		SqlServer database (Required)
    '		</item>
    '		<item>
    '		<b>Encrypted</b> 
    '		Specifies if the cache item must be encrypted 
    '		before it is stored (Optional)
    '		</item>
    '		<item>
    '		<b>Validated</b> 
    '		Specifies if a cache item validation must be done 
    '		to ensure data integrity (Optional)
    '		</item>
    ' </list>
    ' </remarks>

    <Serializable()> _
    Public Class SqlServerCacheStorage
        Implements ICacheStorage, ICacheMetadata

#Region "Private constants"

        Private Shared APPLICATION_PARAMETER As String = "@piApplication"
        Private Shared KEY_PARAMETER As String = "@piKey"
        Private Shared VALUE_PARAMETER As String = "@piValue"
        Private Shared PRIORITY_PARAMETER As String = "@piPriority"
        Private Shared EXPIRY_PARAMETER As String = "@piExpiryValue"
        Private Shared VALUE_FIELD As String = "Value"

#End Region

#Region "Private members"

        Private connectionString As String
        Private applicationName As String
        Private isEncrypted As Boolean
        Private isValidated As Boolean
        Private rowCount As Integer
        Private binaryObject() As Byte
        Private Shared keySize As Integer
        Private Shared applicationSize As Integer


#End Region

#Region "Public constructor"

        ' <summary>
        '		Constructor to create an instance of this class.
        ' </summary>

        Public Sub New()
        End Sub

#End Region

#Region "Properties"

        ' <summary>
        '		Gets the number of elements actually contained
        '		in the database.
        ' </summary>

        ReadOnly Property Size() As Integer Implements ICacheStorage.Size

            Get
                Try
                    Dim itemCount As Object = SqlHelper.ExecuteScalar ( _
                                                                       connectionString, CommandType.StoredProcedure, _
                                                                       CacheResources.ResourceManager ( _
                                                                                                       "RES_StoredProcedureItemCount"), _
                                                                       New SqlParameter() _
                                                                          {New SqlParameter (APPLICATION_PARAMETER, _
                                                                                             applicationName)})

                    Return CInt (itemCount)
                Catch genException As Exception
                    Throw New Exception (String.Format (CultureInfo. _
                                                           CurrentCulture, CacheResources.ResourceManager ( _
                                                                                                           "RES_ExceptionSqlStorageErrorChechingCount")), _
                                         genException)
                End Try
            End Get
        End Property

#End Region

#Region "Implementation of ICacheStorage"

#Region "Init"

        ' <summary>
        '		Initializes the storage provider. 
        ' </summary>
        ' <remarks>
        '		ICacheStorage.Init( configSection )
        ' </remarks>
        ' <param name="configSection">
        '		Xml node to read the attributes from the
        '		config file
        ' </param>		

        Sub Init (ByVal configSection As XmlNode) Implements _
                                                      ICacheStorage.Init

            Try
                Dim validatedString As String
                Dim encryptedString As String
                Const CONST_TRUE As String = "true"
                Const CONST_FALSE As String = "false"

                ' Read the application name from the App.config file
                Dim applName As XmlAttribute = configSection.Attributes ( _
                                                                         CacheResources.ResourceManager ( _
                                                                                                         "RES_ApplicationName"))

                ' Read the connection string from the App.config file
                Dim conString As XmlAttribute = configSection.Attributes ( _
                                                                          CacheResources.ResourceManager ( _
                                                                                                          "RES_ConnectionString"))

                If Equals (configSection, Nothing) Then
                    Throw New ArgumentNullException ("configSection", _
                                                     CacheResources.ResourceManager ( _
                                                                                     "RES_ExceptionNullConfigSection"))
                End If

                If conString Is Nothing Then
                    Throw New ConfigurationErrorsException (CacheResources. _
                                                               ResourceManager ( _
                                                                                "RES_ExceptionInvalidConfigurationSqlStorageProviderConnectionString"))
                End If

                connectionString = conString.Value

                If connectionString.Length = 0 Then
                    Throw New ConfigurationErrorsException (CacheResources. _
                                                               ResourceManager ( _
                                                                                "RES_ExceptionInvalidConfigurationSqlStorageProviderConnectionString"))
                End If

                ' Read the Validated attribute from the App.config file
                If (Not Equals (configSection.Attributes ( _
                                                          CacheResources.ResourceManager ("RES_ConfigValidated")), _
                                Nothing)) Then
                    validatedString = configSection.Attributes ( _
                                                                CacheResources.ResourceManager ( _
                                                                                                "RES_ConfigValidated")). _
                        Value
                Else
                    Throw New ConfigurationErrorsException (CacheResources. _
                                                               ResourceManager ("RES_ExceptionEmptyNodeValidated"))
                End If

                If validatedString Is Nothing Then
                    Throw New ConfigurationErrorsException (CacheResources. _
                                                               ResourceManager ("RES_ExceptionNullValidated"))
                ElseIf validatedString.Length = 0 Then
                    Throw New ConfigurationErrorsException (CacheResources. _
                                                               ResourceManager ("RES_ExceptionEmptyValidated"))
                ElseIf Not (Equals (validatedString.ToLower, _
                                    CONST_TRUE) OrElse Equals (validatedString. _
                                                                  ToLower, CONST_FALSE)) Then
                    Throw New ConfigurationErrorsException (CacheResources. _
                                                               ResourceManager ("RES_ExceptionInvalidValidated"))
                Else
                    isValidated = Boolean.Parse (validatedString.ToLower ( _
                                                                          CultureInfo.CurrentCulture))
                End If

                ' Read the Encrypted attribute from the App.config file
                If (Not Equals (configSection.Attributes ( _
                                                          CacheResources.ResourceManager ("RES_ConfigEncrypted")), _
                                Nothing)) Then
                    encryptedString = configSection.Attributes ( _
                                                                CacheResources.ResourceManager ( _
                                                                                                "RES_ConfigEncrypted")). _
                        Value
                Else
                    Throw New ConfigurationErrorsException (CacheResources. _
                                                               ResourceManager ("RES_ExceptionEmptyNodeEncrypted"))
                End If

                If encryptedString Is Nothing Then
                    Throw New ConfigurationErrorsException (CacheResources. _
                                                               ResourceManager ("RES_ExceptionNullEncrypted"))
                ElseIf encryptedString.Length = 0 Then
                    Throw New ConfigurationErrorsException (CacheResources. _
                                                               ResourceManager ("RES_ExceptionEmptyEncrypted"))
                ElseIf Not (Equals (encryptedString.ToLower, _
                                    CONST_TRUE) OrElse Equals (encryptedString. _
                                                                  ToLower, CONST_FALSE)) Then
                    Throw New ConfigurationErrorsException (CacheResources. _
                                                               ResourceManager ("RES_ExceptionInvalidEncrypted"))
                Else
                    isEncrypted = Boolean.Parse (encryptedString.ToLower ( _
                                                                          CultureInfo.CurrentCulture))
                End If

                Try
                    Dim connection As New SqlConnection (connectionString)

                    Dim keyDbSize As Object = SqlHelper.ExecuteScalar ( _
                                                                       connection, _
                                                                       CommandType.StoredProcedure, _
                                                                       CacheResources.ResourceManager ("RES_GetKeySize"))

                    keySize = Convert.ToInt32 (keyDbSize)

                    Dim appSize As Object = SqlHelper.ExecuteScalar ( _
                                                                     connection, _
                                                                     CommandType.StoredProcedure, _
                                                                     CacheResources.ResourceManager ( _
                                                                                                     "RES_GetApplicationSize"))

                    applicationSize = Convert.ToInt32 (appSize)

                Catch genException As Exception
                    Throw New Exception (String.Format (CultureInfo.CurrentCulture, _
                                                        CacheResources.ResourceManager ( _
                                                                                        "RES_ExceptionCantOpHPBnection"), _
                                                        connectionString), _
                                         genException)
                End Try

                ' Validate application name
                If Not Equals (applName, Nothing) Then
                    If applName.Value.Length = 0 Or _
                       applName.Value.Length > applicationSize Then
                        Throw New ConfigurationErrorsException (CacheResources. _
                                                                   ResourceManager ( _
                                                                                    "RES_ExceptionRangeApplicationName"))
                    End If
                    applicationName = applName.Value
                Else
                    applicationName = CacheResources.ResourceManager ( _
                                                                      "RES_NoApplicationName")
                End If

            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Sub

#End Region

#Region "Add"

        ' <summary>
        '		Adds an element with the specified key and value
        '		into the database.
        ' </summary>
        ' <remarks>
        '		ICacheStorage.Add( key, keyData )
        ' </remarks>
        ' <param name="key">
        '		The unique key to identify the value
        ' </param>
        ' <param name="keyData">
        '		The value to be stored
        ' </param>

        Sub Add (ByVal key As String, ByVal keyData As Object) Implements _
                                                                   ICacheStorage.Add

            Try
                ' Throw exception if key size is greater than the 
                ' maximum size in the database
                If (key.Length > keySize) Then
                    Throw New Exception (CacheResources.ResourceManager ( _
                                                                         "RES_ExceptionKeySize"))
                End If
                Dim valueParameter As SqlParameter = ConvertData (keyData)

                ' Database call to the stored procedure to add or
                ' update the cache item
                rowCount = SqlHelper.ExecuteNonQuery (connectionString, _
                                                      CommandType.StoredProcedure, CacheResources. _
                                                         ResourceManager ("RES_StoredProcedureSetItem"), _
                                                      New SqlParameter() {New SqlParameter ( _
                                                                                            APPLICATION_PARAMETER, _
                                                                                            applicationName), _
                                                                          New SqlParameter (KEY_PARAMETER, key), _
                                                                          valueParameter})

                If rowCount <> 1 Then
                    Throw New Exception (CacheResources.ResourceManager ( _
                                                                         "RES_ExceptionErrorUpdatingTheDatabaseStorage"))
                End If
            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Sub

#End Region

#Region "Flush"

        ' <summary>
        '		Removes all elements from the storage.
        ' </summary>
        ' <remarks>
        '		ICacheStorage.Flush ()
        ' </remarks>

        Sub Flush() Implements ICacheStorage.Flush

            Try

                ' Database call to the stored procedure 
                ' to flush the cache items
                SqlHelper.ExecuteNonQuery (connectionString, _
                                           CommandType.StoredProcedure, CacheResources. _
                                              ResourceManager ("RES_StoredProcedureFlushItem"), _
                                           New SqlParameter() {New SqlParameter ( _
                                                                                 APPLICATION_PARAMETER, applicationName)})

            Catch genException As Exception
                Throw New Exception (CacheResources.ResourceManager ( _
                                                                     "RES_ExceptionSqlStorageErrorFlushingValue"), _
                                     genException)
            End Try

        End Sub

#End Region

#Region "GetData"

        ' <summary>
        '       Gets the GetDataTable with the specified key.
        ' </summary>
        ' <remarks>
        '	    ICacheStorage.GetDataTable(key);
        ' </remarks>
        ' <param name="key">
        '	    The unique key to identify the value
        ' </param>
        ' <returns>
        '		The cached DataTable
        ' </returns>
        Function GetDataTable (ByVal key As String) As DataTable Implements ICacheStorage.GetDataTable
            Return CType (GetData (key), DataTable)
        End Function

        ' <summary>
        '		Gets the element with the specified key.
        ' </summary>
        ' <remarks>
        '		result = ICacheStorage.GetData(string key)
        ' </remarks>
        ' <param name="key">
        '		The unique key to identify the value
        ' </param>
        ' <returns>
        '		The cache item value
        ' </returns>

        Function GetData (ByVal key As String) As Object _
            Implements ICacheStorage.GetData

            Try
                Dim result As Object

                If key Is Nothing OrElse key.Length = 0 Then
                    Throw New ArgumentNullException ("key", CacheResources. _
                                                        ResourceManager ( _
                                                                         "RES_ExceptionTheKeyCantBeNullOrEmptyString"))
                End If

                ' Database call to the stored procedure to get
                ' the cache item value
                Dim reader As Object = SqlHelper.ExecuteScalar ( _
                                                                connectionString, CommandType.StoredProcedure, _
                                                                CacheResources.ResourceManager ( _
                                                                                                "RES_StoredProcedureGetItem"), _
                                                                New SqlParameter() _
                                                                   {New SqlParameter (APPLICATION_PARAMETER, _
                                                                                      applicationName), _
                                                                    New SqlParameter (KEY_PARAMETER, key)})

                If Not Equals (reader, Nothing) Then

                    Dim base64CacheItem As String = reader.ToString()
                    Dim cacheItemBinary As Byte() = Convert.FromBase64String ( _
                                                                              base64CacheItem)

                    If isEncrypted Then
                        cacheItemBinary = DataProtectionManager.Decrypt ( _
                                                                         cacheItemBinary)
                    End If

                    If isValidated Then
                        cacheItemBinary = DataProtectionManager.RemoveMAC ( _
                                                                           cacheItemBinary)
                    End If

                    result = New BinaryFormatter().Deserialize (New _
                                                                   MemoryStream (cacheItemBinary))

                    Return result
                End If
            Catch genException As Exception
                Throw New Exception (String.Format (CultureInfo. _
                                                       CurrentCulture, CacheResources.ResourceManager ( _
                                                                                                       "RES_ExceptionSqlStorageErrorGettingValue"), _
                                                    key), _
                                     genException)
            End Try

            Return Nothing

        End Function

#End Region

#Region "Remove"

        ' <summary>
        '		Removes the element with the specified key.
        ' </summary>
        ' <remarks>
        '		ICacheStorage.Remove( key )
        ' </remarks>
        ' <param name="key">
        '		The unique key to identify the value
        ' </param>

        Sub Remove (ByVal key As String) Implements ICacheStorage.Remove

            Try
                If Equals (key, Nothing) Then
                    Throw New ArgumentNullException ("key", CacheResources. _
                                                        ResourceManager ("RES_ExceptionNullKey"))
                End If

                If key.Length = 0 Then
                    Throw New ArgumentOutOfRangeException ("key", _
                                                           CacheResources.ResourceManager ( _
                                                                                           "RES_ExceptionEmptyKey"))
                End If

                ' Database call to the stored procedure to
                ' remove a cache item from the store
                SqlHelper.ExecuteNonQuery (connectionString, _
                                           CommandType.StoredProcedure, CacheResources. _
                                              ResourceManager ("RES_StoredProcedureDeleteItem"), _
                                           New SqlParameter() {New SqlParameter ( _
                                                                                 APPLICATION_PARAMETER, applicationName), _
                                                               New SqlParameter (KEY_PARAMETER, key)})
            Catch genException As Exception
                Throw New Exception (String.Format (CultureInfo. _
                                                       CurrentCulture, CacheResources.ResourceManager ( _
                                                                                                       "RES_ExceptionSqlStorageErrorRemovingValue"), _
                                                    key), _
                                     genException)
            End Try

        End Sub

#End Region

#Region "Update"

        ' <summary>
        '		Updates the element with the specified key.
        ' </summary>
        ' <remarks>
        '		ICacheStorage.Update( key, keyData )
        ' </remarks>
        ' <param name="key">
        '		The unique to identify the value
        ' </param>
        ' <param name="keyData">
        '		The value to be updated
        ' </param>

        Sub Update (ByVal key As String, ByVal keyData As Object) _
            Implements ICacheStorage.Update

            Try
                Dim valueParameter As SqlParameter = ConvertData (keyData)

                ' Database call to stored procedure
                ' Update the data into the store
                rowCount = SqlHelper.ExecuteNonQuery (connectionString, _
                                                      CommandType.StoredProcedure, CacheResources. _
                                                         ResourceManager ("RES_StoredProcedureSetItem"), _
                                                      New SqlParameter() {New SqlParameter ( _
                                                                                            APPLICATION_PARAMETER, _
                                                                                            applicationName), _
                                                                          New SqlParameter (KEY_PARAMETER, key), _
                                                                          valueParameter})

                If rowCount <> 1 Then
                    Throw New Exception (CacheResources.ResourceManager ( _
                                                                         "RES_ExceptionErrorUpdatingTheDatabaseStorage"))
                End If

            Catch genException As Exception
                Throw New Exception (String.Format (CultureInfo. _
                                                       CurrentCulture, CacheResources.ResourceManager ( _
                                                                                                       "RES_ExceptionSqlStorageErrorUpdatingValue"), _
                                                    key), _
                                     genException)
            End Try

        End Sub

#End Region

#End Region

#Region "Implementation of ICacheMetaData"

        ' <summary>
        '	    Adds new data to the cache metadata storage.
        ' </summary>
        ' <remarks>
        '	    ICacheStorage.Add(key, exp, priority);
        ' </remarks>
        ' <param name="key">
        '	    The unique key to identify the value
        ' </param>
        ' <param name="expirations">
        '	    An array of expirations for the cache data
        ' </param>
        ' <param name="priority">
        '	    Priority of the data in cache
        ' </param>
        Sub AddMetaData (ByVal key As String, ByVal expirations() As _
                            ICacheItemExpiration, ByVal priority As CacheItemPriority) _
            Implements ICacheMetadata.Add
            Try

                ' Add the priority in the database
                rowCount = SqlHelper.ExecuteNonQuery ( _
                                                      connectionString, CommandType.StoredProcedure, _
                                                      CacheResources.ResourceManager ("RES_SetPriority"), _
                                                      New SqlParameter() { _
                                                                             New SqlParameter (APPLICATION_PARAMETER, _
                                                                                               applicationName), _
                                                                             New SqlParameter (KEY_PARAMETER, key), _
                                                                             New SqlParameter (PRIORITY_PARAMETER, _
                                                                                               CInt (priority))})

                If rowCount <> 1 Then
                    Throw New Exception ( _
                                         CacheResources.ResourceManager ( _
                                                                         "RES_ExceptionErrorUpdatingTheDatabaseStorage"))
                End If

                ' Add the expirations array in the database
                If Not Equals (expirations, Nothing) Then
                    Dim byteStream As Byte() = Nothing
                    ' Serialize the expirations array
                    byteStream = SerializeData (expirations)

                    rowCount = SqlHelper.ExecuteNonQuery ( _
                                                          connectionString, CommandType.StoredProcedure, _
                                                          CacheResources.ResourceManager ("RES_SetExpiration"), _
                                                          New SqlParameter() { _
                                                                                 New SqlParameter (APPLICATION_PARAMETER, _
                                                                                                   applicationName), _
                                                                                 New SqlParameter (KEY_PARAMETER, key), _
                                                                                 New SqlParameter (EXPIRY_PARAMETER, _
                                                                                                   byteStream)})
                    If rowCount <> 1 Then
                        Throw New Exception ( _
                                             CacheResources.ResourceManager ( _
                                                                             "RES_ExceptionErrorUpdatingTheDatabaseStorage"))
                    End If

                End If
            Catch genException As Exception
                Throw New Exception (String.Format (CultureInfo.CurrentCulture, _
                                                    CacheResources.ResourceManager ( _
                                                                                    "RES_ExceptionSqlStorageErrorUpdatingValue"), _
                                                    key), genException)
            End Try

        End Sub

        ' <summary>
        '		Removes the element with the specified key from 
        '		the metadata storage.
        ' </summary>
        Sub RemoveMetatData (ByVal key As String) Implements ICacheMetadata.Remove
            ' No implementation is required because
            ' when the cache data is deleted, the metadata
            ' are also deleted with it
        End Sub

        ' <summary>
        '	    Gets all metadata from the metadata storage.
        ' </summary>
        ' <remarks>
        '	    Hashtable table = ICacheMetadata.GetMetadata();
        ' </remarks>
        ' <returns>
        '       The Hashtable containing all the meta data
        ' </returns>
        Function GetMetadata() As Hashtable _
            Implements ICacheMetadata.GetMetadata
            Try
                Dim metadataSet As DataSet = Nothing
                Dim parseTable As DataTable = Nothing
                Dim dataEntry As DictionaryEntry
                Dim metadataTable As New Hashtable()

                metadataSet = SqlHelper.ExecuteDataset (connectionString, _
                                                        CommandType.StoredProcedure, _
                                                        CacheResources.ResourceManager ("RES_GetMetadata"), _
                                                        New SqlParameter() { _
                                                                               New SqlParameter (APPLICATION_PARAMETER, _
                                                                                                 applicationName)})

                ' Parse through the dataset 
                parseTable = metadataSet.Tables (0)
                Dim row As DataRow
                For Each row In parseTable.Rows
                    ' Add the cache item priority
                    If Not Equals (row (1), DBNull.Value) Then
                        dataEntry = New DictionaryEntry (row (0), _
                                                         CType (row (1), CacheItemPriority))
                        metadataTable.Add (metadataTable.Count.ToString(), _
                                           dataEntry)
                    End If

                    ' Add the expiration data
                    If Not Equals (row (2), DBNull.Value) Then
                        dataEntry = New DictionaryEntry (row (0), _
                                                         CType (DeSerializeData (CType (row (2), Byte())), _
                                                            ICacheItemExpiration()))
                        metadataTable.Add (metadataTable.Count.ToString(), _
                                           dataEntry)
                    End If
                Next row

                Return metadataTable
            Catch genException As Exception
                ExceptionManager.Publish (genException)
            End Try
            Return Nothing
        End Function

        ' <summary>
        '		Removes all metadata from the metadata storage.
        ' </summary>
        Sub FlushMetadata() Implements ICacheMetadata.Flush
            ' No implementation is required because
            ' when the cache data is deleted, the metadata
            ' are also deleted with it
        End Sub

#End Region

#Region "ConvertData"

        ' <summary>
        '       This method is a helper function for adding and updating the 
        '       element with specified key.
        ' </summary>
        ' <remarks>
        '       SqlParameter value = ConvertData(keyData);
        ' </remarks>
        ' <param name="keyData">
        '       The value to be updated
        ' </param>
        Private Function ConvertData (ByVal keyData As Object) As SqlParameter

            Dim memStream As MemoryStream = New MemoryStream
            Try

                Dim binFormatter As New BinaryFormatter()
                Dim valueParameter As SqlParameter

                ' Serializes the value in order to store it in the database
                memStream = New MemoryStream()
                binFormatter.Serialize (memStream, keyData)
                binaryObject = memStream.ToArray()

                ' Appends a mac value for data validation
                If isValidated Then
                    binaryObject = DataProtectionManager.AppendMAC ( _
                                                                    binaryObject)
                End If

                ' Encrypts the value
                If isEncrypted Then
                    binaryObject = DataProtectionManager.Encrypt (binaryObject)
                End If

                ' Stores the value in the database
                valueParameter = New SqlParameter (VALUE_PARAMETER, _
                                                   SqlDbType.Text)
                valueParameter.Value = Convert.ToBase64String (binaryObject)
                Return valueParameter

            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            Finally
                memStream.Close()
            End Try

        End Function

        ' <summary>
        '   	This method is used to serialize the object.
        ' </summary>
        ' <remarks>
        '	    byte[] byteStream = SerializeData(data);
        ' </remarks>
        ' <param name="dataValue">
        '       The object to be serialized
        ' </param>
        ' <returns>
        '       A byte array of the serialized object
        ' </returns>
        Private Function SerializeData (ByVal dataValue As Object) As Byte()
            Dim memStream As MemoryStream = Nothing
            Try
                memStream = New MemoryStream()
                Dim formatter As New BinaryFormatter()

                formatter.Serialize (memStream, dataValue)

                Return memStream.ToArray()
            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            Finally
                memStream.Close()
            End Try
        End Function

        'SerializeData


        ' <summary>
        '	    This method is used to deserialize the byte array
        ' </summary>
        ' <remarks>
        '	    object data = DeSerializeData(binaryData);
        ' </remarks>
        ' <param name="binaryData">
        '       The byte array to be deserialized
        ' </param>
        ' <returns>
        '       The deserialized object
        ' </returns>
        Private Function DeSerializeData (ByVal binaryData() As Byte) As Object
            Dim memStream As MemoryStream = Nothing
            Try
                memStream = New MemoryStream (binaryData)
                Return New BinaryFormatter().Deserialize (memStream)
            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            Finally
                memStream.Close()
            End Try
        End Function

        'DeSerializeData


#End Region
    End Class
End Namespace
