Option Explicit On

#If TARGET_DB <> "INFORMIX" Then
Imports Core.Framework
Imports Core.DataAccess.Oracle
Imports System.Data.OracleClient
Imports Core.ExceptionManagement
Imports System.Exception
Imports System.Runtime.Serialization
Imports System.Text
Imports System.Web
Imports System.Xml
Imports System.IO
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.ComponentModel.Design.Serialization
Imports System.CodeDom
Imports Core.Framework.Core.Windows.Framework

Namespace Core.Framework

    ''' -----------------------------------------------------------------------------
    ''' Project	 : Core.Framework
    ''' Class	 : Framework.OracleFileObjectBase
    ''' 
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    '''     Base class for the OracleFileObject.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	4/13/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
    Public Class OracleFileObjectBase
        Inherits Core.Framework.BaseFileObject

#Region " Variable Declarations "
        ' Variable declarations for properties.
        'Private m_intType As FileTypes                          ' File Type - Primary, Secondary, Detail, etc.
        'Private m_intOccurs As Integer = 0                      ' Occurs value 
        'Private m_blnBoundToGrid As Boolean = False        ' Occurs value 
        'Private m_strOwner As String = ""                       ' The owner of the table.
        'Private m_strRelation As String = ""                    ' Stores the base relation name if no alias is provided, otherwise stores the alias name.
        'Private m_strOrderBy As String = ""                     ' Order By clause.
        'Private m_strCursor As String = ""                      ' SQL statement for the Cursor
        'Private m_blnNoItems As Boolean = False                 ' No Items (no default initialization occurs)
        'Private m_blnNoAppend As Boolean = False                ' No append is generated for this file (PRIMARY only)
        'Private m_blnNoDelete As Boolean = False                ' No delete or detail delete is generated for this file
        'Private m_intNeed As Integer = 0                        ' NEED n|ALL records (Put verb treats record as changed)
        'Private m_blnAlteredRecord() As Boolean                 ' Tracks PowerHouse AlteredRecord status
        'Private m_blnNewRecord() As Boolean                     ' Tracks PowerHouse NewRecord status
        'Private m_blnDeletedRecord() As Boolean                 ' Tracks PowerHouse DeletedRecord status
        'Private m_strLastSQL As String = ""                     ' Used for REFERENCE files, to determine if GET processing should be performed

        'Private m_blnEOF As Boolean = False                     ' Determine if EOF for DataReader when calling the Read method.
        'Private m_arrBalanceFields() As String                  ' List of fields for the BALANCE option on the item statement.  (PreCompiler generated)
        'Private m_arrSumIntoFields() As String                  ' List of fields for the SUM INTO option on the item statement.  (PreCompiler generated)
        'Private m_dtbMetaData As DataTable                      ' Stores the metadata (table structure) for the non-reference files.
        'Private FileDisposed As Boolean                             ' A flag to identify whether the instance is already Disposed or not

        ' Variables used to store Occurrence and Current Record position of
        ' File passed object in ForBegin, which gets reset in ForEnd 
        'Private m_intPreviousOccurrence As Integer = -1
        'Private m_intPreviousCurrentRecord As Integer = -1

        ' Used in a call to FileObject.FOR method
        'Protected Friend m_blnSaveOccurrence As Boolean = True

        ' If FileObject "Occurs", the zero based m_intOccurrence of the 
        ' Base Page/Form used as the Current Row Position,
        ' otherwise m_intCurrentRow is used as the Current Row Position
        'Public m_intCurrentRow As Integer = 0                  ' Stores the index for the current row in the DataTable.

        'Added primarily to display a blank grid if no record found in GetData
        'Public HasData As Boolean = False

        'A Flag to convey WhileRetrieving that needs to GetData
        'Note: This flag needs to be set to True before entering into the 
        'Loop, if the calling code has Break statement within the While Retrieving loop
        'Public CallGetData As Boolean = True

        Private cachedt As DataTable

        ''' --- m_cnnTransaction ---------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of m_cnnTransaction.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_cnnTransaction As OracleConnection                    ' Connection used for REFERENCE files.

        ''' --- m_cnnLockedTransaction ---------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of m_cnnLockedTransaction.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_cnnLockedTransaction As OracleConnection                    ' Connection used for Locked REFERENCE files.

        ''' --- m_trnTransaction ---------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of m_trnTransaction.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_trnTransaction As OracleTransaction           ' Transaction object to which file can be linked.

        ''' --- m_trnLockedTransaction ---------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of m_trnLockedTransaction.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_trnLockedTransaction As OracleTransaction           ' Transaction object to which a locked file can be linked.

        ''' --- m_drdDataReader ----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of m_drdDataReader.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Private m_drdDataReader As OracleDataReader             ' Read-only recordset object used for REFERENCE files.

        ''' --- m_blnOccursWith ------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnOccursWith.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_blnOccursWith As Boolean

        ''' --- m_OccursWith ------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of m_OccursWith.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_OccursWith As IFileObject = Nothing
#End Region

#Region "Constructor and Destructor"

        ''' --- New ----------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Constructor of OracleFileObjectBase.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Sub New()
            MyBase.New()
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' <exclude />
        '''
        ''' <summary>
        ''' Initializes a new instance of the BaseFileObject class.
        ''' </summary>
        ''' <param name="Type"><i>Required</i> A type of file as defined in FileTypes Enumeration.</param>
        ''' <param name="Occurs"><i>Required</i> An integer representing the number of occurrences of a 
        ''' record-structure to display.</param>
        ''' <param name="Owner"><i>Required</i> A string specifying the owner of the table.</param>
        ''' <param name="BaseName"><i>Required</i> Base relation name (underlying table if aliased)</param>
        ''' <param name="AliasName"><i>Required</i> Alias name of table.</param>
        ''' <param name="NoItems"><i>Optional</i> No Items (no default initialization occurs)</param>
        ''' <param name="NoAppend"><i>Optional</i> No append is generated for this file (PRIMARY only)</param>
        ''' <param name="NoDelete"><i>Optional</i> No delete or detail delete is generated for this file</param>
        ''' <param name="Need"><i>Optional</i> This option can be used to add blank data records or data records 
        ''' with initial and final values only. (Put verb treats record as changed)</param>
        ''' <param name="TransactionName"><i>Optional</i> A string representing a Transaction Name.</param>
        ''' <remarks>Members contained in FileTypes:<br/>
        '''     <list type="number">
        '''         <item>Primary</item>
        '''         <item>Secondary</item>
        '''         <item>Detail</item>
        '''         <item>Reference</item>
        '''         <item>Master</item>
        '''         <item>Designer</item>
        '''         <item>Delete</item>
        '''         <item>Audit</item>  
        '''         <item>Cursor</item>
        '''     </list>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Sub New(
            ByVal Type As FileTypes,
            ByVal Occurs As Integer,
            ByVal Owner As String,
            ByVal BaseName As String,
            ByVal AliasName As String,
            Optional ByVal NoItems As Boolean = False,
            Optional ByVal NoAppend As Boolean = False,
            Optional ByVal NoDelete As Boolean = False,
            Optional ByVal Need As Integer = 0,
            Optional ByVal TransactionName As String = "",
             Optional ByVal FileType As FileType = FileType.DataFile)
            MyBase.New(Type, Occurs, Owner, BaseName, AliasName, NoItems, NoAppend, NoDelete, Need, TransactionName, FileType)

            m_intProviderTypeOrdinal = 6 'Coordinal for Oracle Provider Type is 6
            m_intClobValue = 4

            If FileType = FileType.TempFile Then IsTempTable = True
            If FileType = FileType.SubFile Then IsSubFile = True
        End Sub
#End Region

#Region "Properties"
        ''' --- CountIntoCalled -------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of CountIntoCalled.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overrides Property CountIntoCalled() As Boolean
            Get
                Return m_blnCountIntoCalled(Me.CurrentRow)
            End Get
            Set(ByVal Value As Boolean)
                m_blnCountIntoCalled(Me.CurrentRow) = Value
            End Set
        End Property

        ''' --- IsTempTable --------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of IsTempTable.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Property IsTempTable() As Boolean
            Get
                Return m_IsTempTable
            End Get
            Set(ByVal Value As Boolean)
                m_IsTempTable = Value
            End Set
        End Property


        ''' --- IsSubFile --------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of IsSubFile.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Property IsSubFile() As Boolean
            Get
                Return m_IsSubFile
            End Get
            Set(ByVal Value As Boolean)
                m_IsSubFile = Value
            End Set
        End Property


        ''' --- Connection ---------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	OracleConnection objects to be used to perform operation with the underlying data layer.
        ''' </summary>
        ''' <remarks>
        ''' OracleConnection objects to be used to perform operation with the underlying data layer
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
        Description("OracleConnection objects to be used to perform operation with the underlying data layer"),
        Category("Core"),
        DefaultValue(""),
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overrides Property Connection() As IDbConnection
            Get
                Return CType(m_cnnTransaction, IDbConnection)
            End Get
            Set(ByVal Value As IDbConnection)
                m_cnnTransaction = CType(Value, OracleConnection)
            End Set
        End Property

        ''' --- Transaction --------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	OracleTransaction used in transactional operations with the data layer.
        ''' </summary>
        ''' <remarks>
        ''' OracleTransaction used in transactional operations with the data layer.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
        Description("OracleTransaction used in transactional operations with the data layer"),
        Category("Core"),
        DefaultValue(""),
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overrides Property Transaction() As IDbTransaction
            Get
                Return CType(m_trnTransaction, IDbTransaction)
            End Get
            Set(ByVal Value As IDbTransaction)
                m_trnTransaction = CType(Value, OracleTransaction)
            End Set
        End Property

        ''' --- DataReader ---------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of DataReader.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overrides Property DataReader() As System.Data.IDataReader
            Get
                Return m_drdDataReader
            End Get
            Set(ByVal Value As System.Data.IDataReader)
                m_drdDataReader = CType(Value, OracleDataReader)
            End Set
        End Property

        ''' --- DatabaseType -------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of DatabaseType.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overrides ReadOnly Property DatabaseType() As DatabaseTypes
            Get
                Return DatabaseTypes.Oracle
            End Get
        End Property

        ''' --- RowIDName ----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of RowIDName.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overrides ReadOnly Property RowIDName() As String
            Get
                Return "ROW_ID"
            End Get
        End Property
#End Region

#Region "Methods"

        ''' --- GetCachedSchema ----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetCachedSchema.
        ''' </summary>
        ''' <param name="GetSchema"></param>
        ''' <param name="AddRow"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overrides Function GetCachedSchema(ByVal GetSchema As Boolean, Optional ByVal AddRow As Boolean = True) As DataTable
            Dim strOwner As String = m_strOwner + "_"
            'Dim objCacheManager As CacheManager

            Dim dt2 As DataTable
            Dim OnRemove As System.Web.Caching.CacheItemRemovedCallback = Nothing
            If strOwner.Trim.Equals("_") Then strOwner = ""

            ' Shared Schema Cache for all file objects
            Try
                'dt = CType(objCacheManager.GetCacheManager.Item(strOwner + m_strBaseName), DataTable)
                'dt = CType(HttpContext.Current.Cache.Item(strOwner + m_strBaseName + "_OraSchema"), DataTable)
                cachedt = CType(ApplicationState.Current.cache.Item(strOwner + m_strBaseName + "_OraSchema"), DataTable)


                If cachedt Is Nothing Then
                    If GetSchema Then
                        ' Get the structure for the FILE object.  Pass in the 
                        ' Transaction or Connection object depending on the 
                        ' transaction type (QUERY, UPDATE or specified transaction).
                        If m_cnnTransaction Is Nothing AndAlso m_trnTransaction Is Nothing AndAlso m_cnnLockedTransaction Is Nothing AndAlso m_trnLockedTransaction Is Nothing Then

                            ' In case of INITIAL values on variables, we need to get the structure
                            ' for the current table using the SystemConnectionString.
                            Dim objSecurityManager As Security.SecurityManager = New Security.SecurityManager
                            Dim strConnectionString As String = objSecurityManager.GetSystemConnectionString
                            objSecurityManager = Nothing

                            cachedt = OracleHelper.GetTableSchema(strConnectionString, CommandType.Text, ReturnSelectFromSQL(True))
                        ElseIf Not m_trnTransaction Is Nothing AndAlso Not m_blnHasLock Then
                            cachedt = OracleHelper.GetTableSchema(m_trnTransaction, CommandType.Text, ReturnSelectFromSQL(True))
                        ElseIf Not m_trnLockedTransaction Is Nothing AndAlso m_blnHasLock Then
                            cachedt = OracleHelper.GetTableSchema(m_trnLockedTransaction, CommandType.Text, ReturnSelectFromSQL(True))
                        Else
                            Dim blnWasClosed As Boolean = False
                            If m_cnnTransaction.State = ConnectionState.Closed Then
                                blnWasClosed = True
                                Me.OpHPBnection()
                            End If
                            cachedt = OracleHelper.GetTableSchema(m_cnnTransaction, CommandType.Text, ReturnSelectFromSQL(True))
                            If blnWasClosed Then
                                Me.CloseConnection()
                            End If
                        End If

                        ' Clear any constraints.
                        cachedt.Constraints.Clear()

                        ' Add the ROW_ID column to the columns collection.
                        With cachedt.Columns
                            'In case there is "ROWID" column remove it, and add it at the end
                            If Not .Contains("ROW_ID") Then
                                .Add("ROW_ID", System.Type.GetType("System.String"))
                                .Item("ROW_ID").MaxLength = 18
                            End If
                        End With
                    Else
                        cachedt = m_dtbDataTable
                    End If

                    cachedt.Rows.Clear()

                    If AddRow Then
                        CreateNewRow(cachedt)
                    End If

                    'HttpContext.Current.Cache.Add(strOwner + m_strBaseName + "_OraSchema", cachedt, Nothing, DateTime.Now.AddQDesign.Days(1), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, OnRemove)
                    'objCacheManager.CacheStorage.Add(strOwner + m_strBaseName, cachedt)
                    If Not (ApplicationState.Current.cache.Contains(strOwner + m_strBaseName + "_OraSchema")) Then
                        ApplicationState.Current.cache.Add(strOwner + m_strBaseName + "_OraSchema", cachedt)
                    End If

                    Return cachedt

                Else
                    dt2 = cachedt.Clone
                    dt2.Rows.Clear()

                    If AddRow Then
                        CreateNewRow(dt2)
                    End If

                    Return dt2
                End If

            Catch e As Exception

                Throw e

            End Try

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Retrieves the number of records returned.
        ''' </summary>
        ''' <param name="WhereClause">A string representing a SQL WHERE statement.</param>
        ''' <returns>A Long representing the record count.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overrides Function GetTempTableRecordCount(ByVal WhereClause As String) As Long
            'Must be overrided in derived class
        End Function

        ''' --- GetDataInternal ----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetDataInternal.
        ''' </summary>
        ''' <param name="WhereClause"></param>
        ''' <param name="OrderByClause"></param>
        ''' <param name="OverrideSQL"></param>
        ''' <param name="GetDataBehaviour"></param>
        ''' <param name="RecordsToFill"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overrides Function GetDataInternal(
            ByVal WhereClause As String,
            ByVal OrderByClause As String,
            ByVal OverrideSQL As String,
            ByVal GetDataBehaviour As GetDataOptions,
            ByRef RecordsToFill As Integer) As Boolean

            Dim strSQL As StringBuilder = New StringBuilder("")
            Dim blnAccessOK As Boolean
            Dim strSelectIf As String
            Dim strChoose As String
            Dim strChooseViaIndex As String

            Dim blnIsOptional As Boolean = False
            Dim blnCreateRecordsForOccurs As Boolean = False
            Dim blnAddRecordToBuffer As Boolean = False
            Dim blnSingleFetch As Boolean = False
            Dim blnIsSequential As Boolean = False
            Dim blnGetOverrideSQL As Boolean = False
            Dim intTotalRecordsFound As Integer

            Dim strWholeWhereCondition As String
            Dim blnHasOverrideSQL As Boolean
            Dim blnIsInFindOrDetailFind As Boolean
            Dim blnIsSubFileKeep As Boolean = IsSubFileKeep()
            Dim blnWriteQtpRecord As Boolean = False
            Dim tmpSQL As String = String.Empty

            Try

                If IsQTP Then

                    Dim strWhereTable As String
                    If Me.AliasName = "" Then
                        strWhereTable = Me.BaseName
                    Else
                        strWhereTable = Me.AliasName
                    End If

                    If UseMemory AndAlso Not m_blnFirstFile AndAlso Not SortPhase AndAlso strSQLWhere.Length = 0 Then

                        For i As Integer = 0 To WhereColumn.Count - 1


                            If (WhereClause.IndexOf(WhereColumn(i).ToString.Split(CType("~", Char))(1) & " =") >= 0 _
                             OrElse (WhereColumn(i).ToString.Split(CType("~", Char)).Length = 3 AndAlso WhereClause.IndexOf(WhereColumn(i).ToString.Split(CType("~", Char))(2) & " =") >= 0)) _
                             AndAlso FileWhere.ContainsKey(WhereColumn(i).ToString.Split(CType("~", Char))(0)) Then

                                If strSQLWhere.Length = 0 Then
                                    strSQLWhere = " WHERE "
                                Else
                                    strSQLWhere = strSQLWhere & " AND "
                                End If


                                'strSQLWhere = strSQLWhere & Me.Owner & "."
                                strSQLWhere = strSQLWhere & strWhereTable & "."
                                If WhereColumn(i).ToString.Split(CType("~", Char)).Length = 3 Then
                                    strSQLWhere = strSQLWhere & WhereColumn(i).ToString.Split(CType("~", Char))(2)
                                Else
                                    strSQLWhere = strSQLWhere & WhereColumn(i).ToString.Split(CType("~", Char))(1)
                                End If
                                strSQLWhere = strSQLWhere & " IN("

                                Dim strUseWhere As String = FileWhere.Item(WhereColumn(i).ToString.Split(CType("~", Char))(0)).ToString

                                strUseWhere = strUseWhere.Substring(strUseWhere.ToUpper.IndexOf("FROM"))
                                If strUseWhere.IndexOf(" ORDER BY ") >= 0 Then
                                    strUseWhere = strUseWhere.Substring(0, strUseWhere.IndexOf(" ORDER BY "))
                                End If
                                strUseWhere = " SELECT " & WhereColumn(i).ToString.Split(CType("~", Char))(1) & " " & strUseWhere

                                strSQLWhere = strSQLWhere & strUseWhere & " )"


                            End If

                        Next


                    End If



                    m_arrOutPutColumns = New ArrayList
                    m_arrOutPutValues = New ArrayList
                    Dim arrWhere() As String = ReplaceSqlVerb(WhereClause.ToUpper.Replace("WHERE ", ""), " AND ", cReplaceChar).Split(CType(cReplaceChar, String))

                    Dim strWhereColumn As String
                    Dim strWhereValue As String

                    For i As Integer = 0 To arrWhere.Length - 1

                        If arrWhere(i).IndexOf("=") >= 0 Then
                            If arrWhere(i).Split(CType("=", Char))(0).IndexOf(strWhereTable) >= 0 Then
                                strWhereColumn = arrWhere(i).Split(CType("=", Char))(0).ToString.Trim
                                strWhereColumn = strWhereColumn.Substring(strWhereColumn.LastIndexOf("." & strWhereTable & ".") + strWhereTable.Length + 2)
                                If strWhereColumn.EndsWith(", 112))") Then
                                    strWhereColumn = strWhereColumn.Substring(0, strWhereColumn.IndexOf(", 112))"))
                                End If
                                m_arrOutPutColumns.Add(strWhereColumn)
                                strWhereValue = arrWhere(i).Split(CType("=", Char))(1).ToString.Trim
                                If strWhereValue.StartsWith("'") AndAlso strWhereValue.EndsWith("'") Then
                                    strWhereValue = strWhereValue.Substring(1, strWhereValue.Length - 2)
                                    m_arrOutPutValues.Add(strWhereValue)
                                Else
                                    m_arrOutPutValues.Add(CDec(strWhereValue))
                                End If
                            Else
                                strWhereColumn = arrWhere(i).Split(CType("=", Char))(1).ToString.Trim
                                strWhereColumn = strWhereColumn.Substring(strWhereColumn.LastIndexOf("." & strWhereTable & ".") + strWhereTable.Length + 2)
                                If strWhereColumn.EndsWith(", 112))") Then
                                    strWhereColumn = strWhereColumn.Substring(0, strWhereColumn.IndexOf(", 112))"))
                                End If
                                m_arrOutPutColumns.Add(strWhereColumn)
                                strWhereValue = arrWhere(i).Split(CType("=", Char))(0).ToString.Trim
                                If strWhereValue.StartsWith("'") AndAlso strWhereValue.EndsWith("'") Then
                                    strWhereValue = strWhereValue.Substring(1, strWhereValue.Length - 2)
                                    m_arrOutPutValues.Add(strWhereValue)
                                Else
                                    m_arrOutPutValues.Add(CDec(strWhereValue))
                                End If
                            End If

                        ElseIf arrWhere(i).IndexOf("IS NULL") >= 0 Then
                            strWhereColumn = arrWhere(i).Replace("IS NULL", "").ToString.Trim
                            strWhereColumn = strWhereColumn.Substring(strWhereColumn.LastIndexOf("." & strWhereTable & ".") + strWhereTable.Length + 2)
                            If strWhereColumn.EndsWith(", 112))") Then
                                strWhereColumn = strWhereColumn.Substring(0, strWhereColumn.IndexOf(", 112))"))
                            End If
                            m_arrOutPutColumns.Add(strWhereColumn)
                            m_arrOutPutValues.Add(0)
                        End If
                    Next

                    If Not SortPhase Then
                        If m_blnCreateBlankRow Then
                            intSortOrder = intSortOrder - 1
                        End If
                        If OverRideOccurrence < 0 Then OverRideOccurrence = 0

                        QTPLoop()
                    End If


                    If m_blnCreateBlankRow Then
                        SortOccurrence = m_dtbDataTable.Rows.Count
                        Exit Function
                    End If

                    If Not m_blnCreateBlankRow AndAlso (blnOverRideOccurrence AndAlso m_blnForMissing AndAlso (OverRideOccurrence > 0 OrElse m_blnContinue) AndAlso OverRideOccurrence < m_dtbDataTable.Rows.Count) Then
                        m_blnContinue = False
                        If IsQTP AndAlso m_dtbDataTable.Rows.Count >= m_blnNewRecord.Length - 1 Then
                            ReDim Preserve m_blnNewRecord(m_dtbDataTable.Rows.Count + 200)
                            ReDim Preserve m_blnAlteredRecord(m_dtbDataTable.Rows.Count + 200)
                            ReDim Preserve m_blnDeletedRecord(m_dtbDataTable.Rows.Count + 200)
                            ReDim Preserve m_blnGridDeletedRecord(m_dtbDataTable.Rows.Count + 200)
                            ReDim Preserve m_blnIsInitialized(m_dtbDataTable.Rows.Count + 200)
                            ReDim Preserve m_blnCountIntoCalled(m_dtbDataTable.Rows.Count + 200)
                        End If
                        Return True
                    End If

                    If m_blnCreateBlankRow Then
                        intSortOrder = intSortOrder - 1
                    End If
                    If OverRideOccurrence < 0 Then OverRideOccurrence = 0

                    For i As Integer = 0 To OverRideOccurrence
                        ReDim Preserve m_blnNewRecord(OverRideOccurrence)
                        ReDim Preserve m_blnAlteredRecord(OverRideOccurrence)
                        ReDim Preserve m_blnDeletedRecord(OverRideOccurrence)
                        ReDim Preserve m_blnGridDeletedRecord(OverRideOccurrence)
                        ReDim Preserve m_blnIsInitialized(OverRideOccurrence)
                        ReDim Preserve m_blnCountIntoCalled(OverRideOccurrence)
                    Next


                    If m_blnCreateBlankRow Then
                        SortOccurrence = m_dtbDataTable.Rows.Count
                        Exit Function
                    End If


                End If



                blnSingleFetch = ((GetDataBehaviour And GetDataOptions.SingleFetch) <> GetDataOptions.None)
                blnIsInFindOrDetailFind = Me.IsInFindOrDetailFind

                'If GetData is called from "ForMissing" Loop and if 
                'GetDataInternal has already been executed, then there is
                'no need to Call GetDataInternal as the first call in 
                'Iteration retrieve all the matching records
                If (m_blnForMissing AndAlso blnIsInFindOrDetailFind) OrElse (blnSingleFetch AndAlso GetOccurrence() >= 1) Then
                    intTotalRecordsFound = Me.TotalRecordsFound
                    If m_blnGetDataForMissing Then
                        m_blnGetDataForMissing = False
                    Else
                        If HasRecordsToProcessForMissing(RecordsToFill, intTotalRecordsFound) Then
                            Return True
                        Else
                            'Continue calling GetDataInternal
                        End If
                    End If
                End If


                'If GetData is called from "For" Loop (Primary/Detail) and if 
                'GetDataInternal has already been executed, then there is
                'no need to Call GetDataInternal as the first call in 
                'Iteration retrieve all the matching records
                If m_blnFor Then
                    If m_blnGetDataFor Then
                        m_blnGetDataFor = False
                    Else
                        If HasRecordsToProcessFor(RecordsToFill) Then
                            Return True
                        Else
                            'Continue calling GetDataInternal
                        End If
                    End If
                End If

                blnIsOptional = ((GetDataBehaviour And GetDataOptions.IsOptional) <> GetDataOptions.None)
                blnCreateRecordsForOccurs = ((GetDataBehaviour And GetDataOptions.CreateRecordsForOccurs) <> GetDataOptions.None)
                blnAddRecordToBuffer = ((GetDataBehaviour And GetDataOptions.AddRecordToBuffer) <> GetDataOptions.None)
                blnIsSequential = ((GetDataBehaviour And GetDataOptions.Sequential) <> GetDataOptions.None)
                blnGetOverrideSQL = ((GetDataBehaviour And GetDataOptions.CreateSubSelect) <> GetDataOptions.None)
                blnHasOverrideSQL = OverrideSQL.Trim <> String.Empty

                If ((GetDataBehaviour And GetDataOptions.ForOccurence) <> GetDataOptions.None) Then
                    m_dtbDataTable = Nothing
                End If

                ' Retrieval from DELETE files is always OPTIONAL.
                If m_intType = FileTypes.Delete Then
                    blnIsOptional = True
                End If

                ' Secondary file retrieval is optional in the FIND procedure.
                If m_intType = FileTypes.Secondary AndAlso IsInFind() Then
                    blnIsOptional = True
                End If

                ' If FileObject "Occurs", GetData into to existing DataTable
                If (m_intType = FileTypes.Primary OrElse m_intType = FileTypes.Detail) Then
                    If IsQTP Then
                        If intSortOrder = 0 OrElse m_blnOutPut Then
                            blnAddRecordToBuffer = False
                        Else
                            blnAddRecordToBuffer = True
                        End If
                    End If

                    Dim blnIsInFind As Boolean = IsInFind()
                    If blnIsInFind AndAlso RecordsToFill > 0 Then
                        blnAddRecordToBuffer = True
                    ElseIf Not blnIsInFind AndAlso Not IsQTP Then
                        'Set Get Data to Optional if File's Type is Primary or Detail
                        'and it is not called from Find
                        blnIsOptional = True

                        'Add record to buffer if File that Occurs and having Type of Primary or Detail
                        'and GetData is not issued from Find
                        If (Not m_dtbDataTable Is Nothing) AndAlso Me.Occurs > 0 Then

                            blnAddRecordToBuffer = True
                        End If
                    End If
                Else
                    'Add record to buffer if File (other than Primary/Detail) that Occurs or of type Designer (excluding Temp tables).
                    If (((Not m_dtbDataTable Is Nothing) AndAlso Me.Occurs > 0) OrElse Me.Type = FileTypes.Designer) Then
                        blnAddRecordToBuffer = True
                    End If
                End If

                If m_blnIsWhileRetrieving AndAlso m_intType = FileTypes.Designer Then
                    blnAddRecordToBuffer = True
                End If

                HasData = False
                If Not blnAddRecordToBuffer Then
                    ' Initialize the record status flags.
                    SetAllRecordStatus(m_blnAlteredRecord, False)
                    SetAllRecordStatus(m_blnDeletedRecord, False)
                End If

                'Dim strSelectIfClause As String
                strSelectIf = GetSelectIfClause()
                strChoose = GetChooseClause()
                strChooseViaIndex = GetChooseViaIndexClause()

                If strChoose <> "" Then
                    If strSelectIf <> "" Then
                        strSelectIf = strSelectIf & " AND " & strChoose
                    Else
                        strSelectIf = strChoose
                    End If
                End If
                If strChooseViaIndex <> "" Then
                    If strChooseViaIndex.ToUpper.Trim.StartsWith("ORDER BY") Then
                        If OrderByClause <> "" Then
                            OrderByClause = OrderByClause & strChooseViaIndex.ToUpper.Replace("ORDER BY", ", ")
                        Else
                            OrderByClause = strChooseViaIndex
                        End If
                    End If
                End If



                ' If an overriding SQL was passed in, then use
                ' it to retrieve the resultset.
                If blnHasOverrideSQL Then
                    strSQL.Append(OverrideSQL)
                ElseIf blnGetOverrideSQL Then
                    Dim strOverrideSQL As New StringBuilder(String.Empty)
                    Dim strAccessClause As String

                    strAccessClause = String.Empty
                    'Get Access Clause if "Where" clause is not provided
                    'and GetData is Not Sequential or FileObject is of Type "Detail"
                    If WhereClause.Trim = String.Empty AndAlso (Not blnIsSequential OrElse Me.Type = FileTypes.Detail) Then
                        strAccessClause = Me.GetAccessClause()
                        If Not blnIsOptional Then blnIsOptional = m_blnAccessIsOptional ' Optional specified on the Access statement.
                    End If
                    ' If there is an ORDER BY in the ACCESS, then remove it and assign it to OrderByClause.
                    Dim intOrderByIndex As Integer = strAccessClause.IndexOf("ORDER BY")
                    If intOrderByIndex > 0 Then
                        OrderByClause = strAccessClause.Substring(intOrderByIndex - 1)
                        strAccessClause = strAccessClause.Substring(0, intOrderByIndex)
                    End If
                    Me.GetOverrideSQL(strOverrideSQL, WhereClause, strSelectIf, strAccessClause, OrderByClause, strWholeWhereCondition, RecordsToFill)

                    strSQL.Append(strOverrideSQL)
                Else
                    If m_intType = FileTypes.Cursor Then
                        strSQL.Append(GetCursorStatement())
                        blnHasOverrideSQL = True
                    Else
                        ' Retrieve the SELECT ... FROM SQL.
                        strSQL.Append(ReturnSelectFromSQL())

                        ' If no WHERE clause is passed in, then get the 
                        ' resultset using the DEFAULT ACCESS statement,
                        ' otherwise use the WhereClause passed in.
                        If WhereClause = "" Then
                            If blnIsSequential = False AndAlso Type <> FileTypes.Primary Then

                                strSQL.Append(" ")
                                WhereClause = GetAccessClause()
                                If Not blnIsOptional Then blnIsOptional = m_blnAccessIsOptional ' Optional specified on the Access statement.

                                If m_intType = FileTypes.Reference AndAlso WhereClause.Length = 0 Then
                                    WhereClause = " WHERE 1=0 "
                                End If

                                strSQL.Append(WhereClause)

                            End If
                        Else
                            strSQL.Append(" ")
                            strSQL.Append(WhereClause)
                        End If

                        ' Add the SelectIf code.  Add the WHERE or the AND
                        ' depending on the current SQL statement.
                        If WhereClause = "" And blnIsSequential = True And strSelectIf <> "" Then
                            strSQL.Append(" WHERE ")
                            strSQL.Append(strSelectIf)
                        ElseIf WhereClause <> "" And strSelectIf <> "" Then
                            strSQL.Append(" AND ")
                            strSQL.Append(strSelectIf)
                        ElseIf WhereClause = "" And strSelectIf <> "" Then
                            ' If an ORDER BY clause exists, remove it and add it to the end.
                            If strSQL.ToString.IndexOf("ORDER BY") > 0 Then
                                Dim strSelectIfCode As StringBuilder = New StringBuilder("")
                                If strSQL.ToString.IndexOf(" WHERE ") > 0 Then
                                    strSelectIfCode.Append(" AND ")
                                    strSelectIfCode.Append(strSelectIf)
                                Else
                                    strSelectIfCode.Append(" WHERE ")
                                    strSelectIfCode.Append(strSelectIf)
                                End If
                                strSelectIfCode.Append(" ORDER BY")
                                strSQL.Replace(" ORDER BY", strSelectIfCode.ToString)
                            Else
                                If strSQL.ToString.IndexOf(" WHERE ") > 0 Then
                                    strSQL.Append(" AND ")
                                    strSQL.Append(strSelectIf)
                                Else
                                    strSQL.Append(" WHERE ")
                                    strSQL.Append(strSelectIf)
                                End If
                            End If
                        End If

                        If strSQL.ToString.IndexOf(" ORDER BY ") = -1 Then
                            ' If an ORDER BY statement was passed in, sort the
                            ' result using this ORDER BY.
                            If OrderByClause <> "" Then
                                strSQL.Append(" ")
                                strSQL.Append(OrderByClause)
                            End If
                        End If
                    End If
                End If

                ' Used for LookupNotOn.  See more info in Validate procedure in the Page.aspx.vb file.
                If IsInFindOrDetailFind() Then
                    Select Case Type
                        Case FileTypes.Primary, FileTypes.Secondary, FileTypes.Detail
                            If strSQL.ToString.Replace(" WHERE ROW_NUM ", "").IndexOf(" WHERE ") > -1 Then
                                SetSearchType(SearchTypes.Filtered)
                            Else
                                SetSearchType(SearchTypes.Sequential)
                            End If
                    End Select
                End If

                'System.Web.HttpContext.Current.Trace.Write("SQL Statement", strSQL.ToString)
                m_strSQL = strSQL.ToString

                If Not IsQTP Then
                    m_blnCountIntoCalled(Me.CurrentRow) = False
                End If

                ' Return the resultset.
                ' If REFERENCE file, then create a DataReader (not updatable).
                If m_intType = FileTypes.Reference Then
                    Dim blnIsConnectionClosed As Boolean = False

                    ' Open the Connection.
                    Dim blnWasClosed As Boolean = False
                    If m_cnnTransaction Is Nothing Then
                        m_dtbDataTable = OracleHelper.ExecuteDataTable(m_trnTransaction, CommandType.Text, strSQL.ToString)
                    Else
                        If m_cnnTransaction.State = ConnectionState.Closed Then
                            blnWasClosed = True
                            Me.OpHPBnection()
                        End If
                        m_dtbDataTable = OracleHelper.ExecuteDataTable(m_cnnTransaction, CommandType.Text, strSQL.ToString)
                    End If

                    'Remove the ROWID column
                    If m_dtbDataTable.Columns.Contains("ROWID") Then
                        m_dtbDataTable.Columns.Remove("ROWID")
                    End If

                    ' Get the column information.
                    If m_cnnTransaction Is Nothing Then
                        GetMetaData(Nothing, m_trnTransaction)
                    Else
                        GetMetaData(m_cnnTransaction, Nothing)
                    End If
                    If blnWasClosed Then
                        Me.CloseConnection()
                    End If

                    m_blnEOF = (m_dtbDataTable.Rows.Count <= 0)

                    ' Set AccessOK.
                    blnAccessOK = Not m_blnEOF

                    'Added primarily for Grid
                    HasData = blnAccessOK

                    ' Save the last SQL for REFERENCE files.
                    m_strLastSQL = strSQL.ToString

                    ' Set NewRecord flag depending on EOF status.
                    If Not m_blnEOF Then
                        m_blnNewRecord(Me.CurrentRow) = False
                    Else
                        If Not Me.PageMode = PageModeTypes.Find Then
                            m_blnNewRecord(Me.CurrentRow) = True
                        End If

                        ' Create an empty record buffer.
                        CreateEmptyStructure()

                        ' Generate an error if not an OPTIONAL fetch.
                        If Not blnIsOptional Then
                            ' If we are getting a reference file that occurs with a file that has no
                            ' record in the current occurrence, don't throw the error.
                            If Not m_OccursWith Is Nothing AndAlso Not m_OccursWith.NewRecord AndAlso m_OccursWith.RecordLocation.Trim = String.Empty Then
                                Return False
                            Else
                                AddMessage("Not on lookup file ({0}).", MessageTypes.Error, Me.ReturnRelation) 'IM.NoRecordsReference
                            End If
                        End If
                    End If
                Else
                    ' Get the DataTable by passing in the 
                    ' Transaction or Connection object depending on the 
                    ' transaction type (QUERY, UPDATE or specified transaction).

                    If Not m_blnCreateBlankRow AndAlso (blnOverRideOccurrence AndAlso m_blnForMissing AndAlso (OverRideOccurrence > 0 OrElse m_blnContinue) AndAlso OverRideOccurrence < m_dtbDataTable.Rows.Count) Then
                        m_blnContinue = False
                        Return True
                    End If

                    If m_IsTempTable OrElse (m_IsSubFile AndAlso Not blnIsSubFileKeep) OrElse Not IsNothing(tmpDataTable) Then

                        If WhereClause = "" And strSelectIf <> "" Then
                            WhereClause = " WHERE " & strSelectIf
                        ElseIf strSelectIf <> "" Then
                            WhereClause = WhereClause & " and " & strSelectIf
                        End If

                        If IsQTP Then
                            If strSQL.ToString.ToUpper.IndexOf("WHERE") >= 0 Then
                                tmpSQL = strSQL.ToString.Substring(0, strSQL.ToString.ToUpper.IndexOf("WHERE")) & " " & strSQLWhere
                            ElseIf strSQLWhere.Length > 0 Then
                                tmpSQL = strSQL.ToString & " WHERE " & strSQLWhere
                            Else
                                tmpSQL = strSQL.ToString
                            End If
                            If strSelectIf.Length > 0 Then
                                If tmpSQL.ToUpper.IndexOf("WHERE") >= 0 Then
                                    tmpSQL = tmpSQL & " AND " & strSelectIf
                                Else
                                    tmpSQL = tmpSQL & " WHERE " & strSelectIf
                                End If
                            End If
                        End If

                        If blnGetOverrideSQL Then
                            Dim intStartRow As Long = 0
                            Dim intTotalRecords As Integer = Me.TotalRecordsToRetrieve(RecordsToFill, intStartRow)
                            If Not SkipRecordsWithError Then
                                intStartRow = Math.Max(Me.m_intCurrentRecordPosition, 1)
                            End If
                            If blnAddRecordToBuffer Then
                                dt = GetDataTempTable(WhereClause, OrderByClause, intStartRow, intTotalRecords, m_trnTransaction)
                                'Remove the ROWID column
                                If dt.Columns.Contains("ROWID") Then dt.Columns.Remove("ROWID")
                            Else
                                m_dtbDataTable = GetDataTempTable(WhereClause, OrderByClause, intStartRow, intTotalRecords, m_trnTransaction)
                                'Remove the ROWID column
                                If m_dtbDataTable.Columns.Contains("ROWID") Then m_dtbDataTable.Columns.Remove("ROWID")
                            End If
                        Else
                            If blnAddRecordToBuffer Then
                                If IsQTP AndAlso Not SortPhase AndAlso UseMemory Then
                                    If strSQL.ToString.ToUpper.IndexOf("WHERE") >= 0 Then
                                        tmpSQL = strSQL.ToString.Substring(0, strSQL.ToString.ToUpper.IndexOf("WHERE")) & " " & strSQLWhere
                                    ElseIf strSQLWhere.Length > 0 Then
                                        tmpSQL = strSQL.ToString & " WHERE " & strSQLWhere
                                    Else
                                        tmpSQL = strSQL.ToString
                                    End If
                                    If blnUseTableSelectIf = BooleanTypes.True AndAlso strSelectIf.Length > 0 Then
                                        If tmpSQL.ToUpper.IndexOf("WHERE") >= 0 Then
                                            tmpSQL = tmpSQL & " AND " & strSelectIf
                                        Else
                                            tmpSQL = tmpSQL & " WHERE " & strSelectIf
                                        End If
                                    End If

                                    ' Execute the SQL Statement that gets the Records
                                    tmpDataTable = OracleHelper.ExecuteDataTable(m_trnTransaction, CommandType.Text, tmpSQL)

                                    If CInt(tmpDataTable.Rows.Count * 2) > FirstFileCount Then
                                        ReDim m_blnNewRecord(CInt(tmpDataTable.Rows.Count * 2))
                                        ReDim m_blnAlteredRecord(CInt(tmpDataTable.Rows.Count * 2))
                                        ReDim m_blnDeletedRecord(CInt(tmpDataTable.Rows.Count * 2))
                                        ReDim m_blnGridDeletedRecord(CInt(tmpDataTable.Rows.Count * 2))
                                        ReDim m_blnIsInitialized(CInt(tmpDataTable.Rows.Count * 2))
                                        ReDim m_blnCountIntoCalled(CInt(tmpDataTable.Rows.Count * 2))
                                    Else
                                        ReDim m_blnNewRecord(FirstFileCount)
                                        ReDim m_blnAlteredRecord(FirstFileCount)
                                        ReDim m_blnDeletedRecord(FirstFileCount)
                                        ReDim m_blnGridDeletedRecord(FirstFileCount)
                                        ReDim m_blnIsInitialized(FirstFileCount)
                                        ReDim m_blnCountIntoCalled(FirstFileCount)
                                    End If

                                    If strSelectIf.Length > 0 AndAlso blnUseTableSelectIf = BooleanTypes.False Then
                                        If WhereClause = "" And strSelectIf <> "" Then
                                            WhereClause = " WHERE " & strSelectIf
                                        ElseIf strSelectIf <> "" Then
                                            WhereClause = WhereClause & " and " & strSelectIf
                                        End If
                                    End If

                                    dt = GetDataTempTable(WhereClause, OrderByClause)

                                    'Remove the ROWID column
                                    dt.Columns.Remove("ROWID")
                                Else
                                    dt = GetDataTempTable(WhereClause, OrderByClause, , , m_trnTransaction)
                                    'Remove the ROWID column
                                    If dt.Columns.Contains("ROWID") Then dt.Columns.Remove("ROWID")
                                End If
                            Else
                                m_dtbDataTable = GetDataTempTable(WhereClause, OrderByClause, , , m_trnTransaction)
                                'Remove the ROWID column
                                If m_dtbDataTable.Columns.Contains("ROWID") Then m_dtbDataTable.Columns.Remove("ROWID")
                            End If
                        End If
                    Else
                        If IsQTP AndAlso Not m_blnFirstFile AndAlso Not SortPhase Then
                            If strSQL.ToString.ToUpper.IndexOf("WHERE") >= 0 Then
                                tmpSQL = strSQL.ToString.Substring(0, strSQL.ToString.ToUpper.IndexOf("WHERE")) & " " & strSQLWhere
                            ElseIf strSQLWhere.Length > 0 Then
                                tmpSQL = strSQL.ToString & " WHERE " & strSQLWhere
                            Else
                                tmpSQL = strSQL.ToString
                            End If
                            If blnUseTableSelectIf = BooleanTypes.True AndAlso strSelectIf.Length > 0 Then
                                If tmpSQL.ToUpper.IndexOf("WHERE") >= 0 Then
                                    tmpSQL = tmpSQL & " AND " & strSelectIf
                                Else
                                    tmpSQL = tmpSQL & " WHERE " & strSelectIf
                                End If
                            End If


                            ' Execute the SQL Statement that gets the Records
                            tmpDataTable = OracleHelper.ExecuteDataTable(m_trnTransaction, CommandType.Text, tmpSQL)

                            If CInt(tmpDataTable.Rows.Count * 2) > FirstFileCount Then
                                ReDim m_blnNewRecord(CInt(tmpDataTable.Rows.Count * 2))
                                ReDim m_blnAlteredRecord(CInt(tmpDataTable.Rows.Count * 2))
                                ReDim m_blnDeletedRecord(CInt(tmpDataTable.Rows.Count * 2))
                                ReDim m_blnGridDeletedRecord(CInt(tmpDataTable.Rows.Count * 2))
                                ReDim m_blnIsInitialized(CInt(tmpDataTable.Rows.Count * 2))
                                ReDim m_blnCountIntoCalled(CInt(tmpDataTable.Rows.Count * 2))
                            Else
                                ReDim m_blnNewRecord(FirstFileCount)
                                ReDim m_blnAlteredRecord(FirstFileCount)
                                ReDim m_blnDeletedRecord(FirstFileCount)
                                ReDim m_blnGridDeletedRecord(FirstFileCount)
                                ReDim m_blnIsInitialized(FirstFileCount)
                                ReDim m_blnCountIntoCalled(FirstFileCount)
                            End If

                            If strSelectIf.Length > 0 AndAlso blnUseTableSelectIf = BooleanTypes.False Then
                                If WhereClause = "" And strSelectIf <> "" Then
                                    WhereClause = " WHERE " & strSelectIf
                                ElseIf strSelectIf <> "" Then
                                    WhereClause = WhereClause & " and " & strSelectIf
                                End If
                            End If

                            m_dtbDataTable = GetDataTempTable(WhereClause, OrderByClause)

                            'Remove the ROWID column
                            m_dtbDataTable.Columns.Remove("ROWID")
                        Else
                            If m_cnnTransaction Is Nothing Then

                                ' Fetching this record and add it to the current recordbuffer,
                                ' otherwise do a normal GET.
                                If m_blnHasLock Then
                                    If blnAddRecordToBuffer Then
                                        dt = OracleHelper.ExecuteDataTable(m_trnLockedTransaction, CommandType.Text, strSQL.ToString)
                                    Else
                                        m_dtbDataTable = OracleHelper.ExecuteDataTable(m_trnLockedTransaction, CommandType.Text, strSQL.ToString)
                                    End If
                                    GetMetaData(Nothing, m_trnLockedTransaction)
                                Else
                                    If blnAddRecordToBuffer Then
                                        dt = OracleHelper.ExecuteDataTable(m_trnTransaction, CommandType.Text, strSQL.ToString)
                                    Else
                                        m_dtbDataTable = OracleHelper.ExecuteDataTable(m_trnTransaction, CommandType.Text, strSQL.ToString)
                                    End If
                                    GetMetaData(Nothing, m_trnTransaction)
                                End If
                            Else
                                ' Open the Connection.
                                Dim blnWasClosed As Boolean = False
                                If m_cnnTransaction.State = ConnectionState.Closed Then
                                    blnWasClosed = True
                                    Me.OpHPBnection()
                                End If

                                If m_blnHasLock Then
                                    strSQL.Append(" FOR UPDATE")
                                End If

                                ' Fetching this record and add it to the current recordbuffer,
                                ' otherwise do a normal GET.

                                If m_blnHasLock Then
                                    If blnAddRecordToBuffer Then
                                        dt = OracleHelper.ExecuteDataTable(m_trnLockedTransaction, CommandType.Text, strSQL.ToString)
                                    Else
                                        m_dtbDataTable = OracleHelper.ExecuteDataTable(m_trnLockedTransaction, CommandType.Text, strSQL.ToString)
                                    End If
                                    GetMetaData(Nothing, m_trnLockedTransaction)
                                Else
                                    If blnAddRecordToBuffer Then
                                        dt = OracleHelper.ExecuteDataTable(m_cnnTransaction, CommandType.Text, strSQL.ToString)
                                    Else
                                        m_dtbDataTable = OracleHelper.ExecuteDataTable(m_cnnTransaction, CommandType.Text, strSQL.ToString)
                                    End If
                                    GetMetaData(m_cnnTransaction, Nothing)
                                End If

                                If blnWasClosed Then
                                    Me.CloseConnection()
                                End If
                            End If
                        End If
                    End If

                    If IsQTP AndAlso Not SortPhase Then

                        Dim strWhereTable As String = String.Empty


                        If Me.AliasName = "" Then
                            strWhereTable = Me.BaseName
                        Else
                            strWhereTable = Me.AliasName
                        End If

                        If (m_blnFirstFile OrElse UseMemory) AndAlso Not FileWhere.Contains(strWhereTable) Then
                            If Me.IsTempTable OrElse (Me.IsSubFile AndAlso Not Me.IsSubFileKeep) Then
                                If m_blnFirstFile Then
                                    FileWhere.Add(strWhereTable, strSQL.ToString.Replace(Me.TableNameWithAlias.Trim, "#" & strWhereTable))
                                Else
                                    FileWhere.Add(strWhereTable, tmpSQL.Replace(Me.TableNameWithAlias.Trim, "#" & strWhereTable))
                                End If
                            Else
                                If m_blnFirstFile Then
                                    FileWhere.Add(strWhereTable, strSQL.ToString)
                                Else
                                    FileWhere.Add(strWhereTable, tmpSQL)
                                End If
                            End If
                        End If

                    End If

                    If blnSingleFetch Then
                        Me.TotalRecordsFound = m_dtbDataTable.Rows.Count
                    End If

                    m_strLastSQL = strSQL.ToString

                    ' If we are performing a normal GET, set the first
                    ' record as the current record.
                    If blnAddRecordToBuffer Then
                        If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then

                            ' Set AccessOK.
                            blnAccessOK = True
                            blnQTPInit = False
                            If IsQTP Then
                                NoRecords = False
                            End If
                            'Added primarily for Grid
                            HasData = True

                            intLastfound = dt.Rows.Count

                            'added for the QTP log

                            QTPRecordsRead(Me.BaseName, Me.AliasName, dt.Rows.Count, LogType.Read)



                        Else
                            Dim intCurrentRow As Integer

                            intCurrentRow = Me.CurrentRow

                            ' Set AccessOK.
                            blnAccessOK = False

                            'Added primarily for Grid
                            HasData = False

                            If IsQTP Then
                                If m_blnFirstFile AndAlso m_dtbDataTable.Rows.Count > 49 Then
                                    UseMemory = True
                                End If
                                If m_dtbDataTable.Rows.Count >= m_blnNewRecord.Length - 1 Then
                                    If m_blnFirstFile Then
                                        FirstFileCount = m_dtbDataTable.Rows.Count
                                        ReDim m_blnNewRecord(CInt(m_dtbDataTable.Rows.Count * 2))
                                        ReDim m_blnAlteredRecord(CInt(m_dtbDataTable.Rows.Count * 2))
                                        ReDim m_blnDeletedRecord(CInt(m_dtbDataTable.Rows.Count * 2))
                                        ReDim m_blnGridDeletedRecord(CInt(m_dtbDataTable.Rows.Count * 2))
                                        ReDim m_blnIsInitialized(CInt(m_dtbDataTable.Rows.Count * 2))
                                        ReDim m_blnCountIntoCalled(CInt(m_dtbDataTable.Rows.Count * 2))
                                    Else
                                        ReDim Preserve m_blnNewRecord(m_dtbDataTable.Rows.Count + 200)
                                        ReDim Preserve m_blnAlteredRecord(m_dtbDataTable.Rows.Count + 200)
                                        ReDim Preserve m_blnDeletedRecord(m_dtbDataTable.Rows.Count + 200)
                                        ReDim Preserve m_blnGridDeletedRecord(m_dtbDataTable.Rows.Count + 200)
                                        ReDim Preserve m_blnIsInitialized(m_dtbDataTable.Rows.Count + 200)
                                        ReDim Preserve m_blnCountIntoCalled(m_dtbDataTable.Rows.Count + 200)
                                    End If
                                End If
                            End If

                            ' Added condition for a secondary occurs with a file, then set the New record status.
                            If (Not Me.PageMode = PageModeTypes.Find) OrElse (Me.Type = FileTypes.Secondary AndAlso m_blnOccursWith) Then
                                m_blnNewRecord(intCurrentRow) = True
                            End If
                            AlteredRecord(intCurrentRow) = False
                            m_blnDeletedRecord(intCurrentRow) = False

                            ' Generate an error if not and OPTIONAL fetch.
                            If Not blnIsOptional Then
                                If Me.PageMode = PageModeTypes.Entry Then
                                    AddMessage("Not on lookup file ({0}).", MessageTypes.Error, Me.ReturnRelation) 'IM.NoRecordsReference
                                Else
                                    If IsQTP Then
                                        intLastfound = 0
                                        QTPRecordsRead(Me.BaseName, Me.AliasName, 0, LogType.Read)
                                        If m_blnFirstFile Then
                                            ThrowCustomApplicationException("No Records Found.") 'IM.NoRecords
                                        Else
                                            NoRecords = True
                                        End If
                                    Else
                                        ThrowCustomApplicationException("No Records Found.") 'IM.NoRecords
                                    End If
                                End If
                            End If
                        End If

                        If IsQTP AndAlso blnIsOptional Then
                            NoRecords = False
                        End If

                        If IsQTP Then

                            If HasData Then
                                Occurs = Occurs + dt.Rows.Count
                                ' Assign the new record to the existing record buffer.
                                AssignRecordToBuffer(dt)
                            End If

                        Else
                            ' Assign the new record to the existing record buffer.
                            ' Pass the HasData value indicating that no records were found
                            ' so that EnsureRows doesn't change the NewRecordStatus to False.
                            AssignRecordToBuffer(dt, , HasData)
                        End If

                        If Not HasData Then
                            ' Set INITIAL values from the dictionary.
                            If Not IsQTP AndAlso IsNothing(System.Configuration.ConfigurationManager.AppSettings("NoDictionary")) Then
                                InitializeFromDictionary()
                            End If

                            If (IsQTP AndAlso blnIsOptional) OrElse (IsQTP AndAlso intSortOrder > 0) Then
                                AssignRecordToBuffer(dt)

                                If FileNoRecords.Length = 0 Then
                                    If Me.AliasName = "" Then
                                        FileNoRecords = Me.BaseName
                                    Else
                                        FileNoRecords = Me.AliasName
                                    End If
                                End If
                            Else
                                ' Set the Item INITIAL values.
                                RaiseInitializeItems(False)
                            End If
                        End If

                        ' Only dispose of the temporary datatable (used for adding records to current datatable buffer)
                        ' if not in a WhileRetrieving.  In a WhileRetrieving, we will dispose of this table when we
                        ' break out of the loop.
                        If Not m_blnCallGetDataInWhileRetrieving Then
                            dt.Dispose()
                        End If
                    Else
                        ' Set the AccessOK and New flags.
                        If Not IsNothing(m_dtbDataTable) AndAlso m_dtbDataTable.Rows.Count > 0 Then
                            m_blnNewRecord(0) = False

                            ' Set AccessOK.
                            blnAccessOK = True
                            blnQTPInit = False
                            If IsQTP Then
                                NoRecords = False
                            End If
                            'Added primarily for Grid
                            HasData = True

                            intLastfound = m_dtbDataTable.Rows.Count

                            'added for the QTP log
                            If Me.CurrentRow = 0 Then

                                QTPRecordsRead(Me.BaseName, Me.AliasName, m_dtbDataTable.Rows.Count, LogType.Read)

                            End If

                        Else
                            ' Added condition for a secondary occurs with a file, then set the New record status.
                            If (Not Me.PageMode = PageModeTypes.Find) OrElse (Me.Type = FileTypes.Secondary AndAlso m_blnOccursWith) Then
                                m_blnNewRecord(0) = True
                            End If

                            ' Set AccessOK.
                            blnAccessOK = False

                            'Added primarily for Grid
                            HasData = False

                            ' Create an empty record buffer.
                            CreateEmptyStructure()

                            ' Generate an error if not and OPTIONAL fetch.
                            If Not blnIsOptional Then
                                If Me.PageMode = PageModeTypes.Entry Then
                                    AddMessage("IM.NoRecordsReference", MessageTypes.Error, Me.ReturnRelation)
                                Else
                                    If IsQTP Then
                                        intLastfound = 0
                                        QTPRecordsRead(Me.BaseName, Me.AliasName, 0, LogType.Read)
                                        If m_blnFirstFile Then
                                            ThrowCustomApplicationException("No Records Found.") 'IM.NoRecords
                                        Else
                                            NoRecords = True
                                        End If
                                    Else
                                        ThrowCustomApplicationException("No Records Found.") 'IM.NoRecords
                                    End If
                                End If
                            End If



                            If IsQTP AndAlso blnIsOptional Then
                                NoRecords = False
                            End If


                            ' Set INITIAL values from the dictionary.
                            If Not IsQTP AndAlso IsNothing(System.Configuration.ConfigurationManager.AppSettings("NoDictionary")) Then
                                InitializeFromDictionary()
                            End If

                            ' Set the Item INITIAL values.
                            If Not IsQTP Then RaiseInitializeItems(False)

                        End If
                    End If

                End If

                If IsQTP AndAlso m_blnFirstFile Then

                    If m_dtbDataTable.Rows.Count > 99 Then
                        UseMemory = True
                    End If

                    ReDim Preserve m_blnNewRecord(CInt(m_dtbDataTable.Rows.Count * 2))
                    ReDim Preserve m_blnAlteredRecord(CInt(m_dtbDataTable.Rows.Count * 2))
                    ReDim Preserve m_blnDeletedRecord(CInt(m_dtbDataTable.Rows.Count * 2))
                    ReDim Preserve m_blnGridDeletedRecord(CInt(m_dtbDataTable.Rows.Count * 2))
                    ReDim Preserve m_blnIsInitialized(CInt(m_dtbDataTable.Rows.Count * 2))
                    ReDim Preserve m_blnCountIntoCalled(CInt(m_dtbDataTable.Rows.Count * 2))
                ElseIf IsQTP AndAlso m_dtbDataTable.Rows.Count >= m_blnNewRecord.Length - 1 Then
                    ReDim Preserve m_blnNewRecord(m_dtbDataTable.Rows.Count + 200)
                    ReDim Preserve m_blnAlteredRecord(m_dtbDataTable.Rows.Count + 200)
                    ReDim Preserve m_blnDeletedRecord(m_dtbDataTable.Rows.Count + 200)
                    ReDim Preserve m_blnGridDeletedRecord(m_dtbDataTable.Rows.Count + 200)
                    ReDim Preserve m_blnIsInitialized(m_dtbDataTable.Rows.Count + 200)
                    ReDim Preserve m_blnCountIntoCalled(m_dtbDataTable.Rows.Count + 200)


                End If

                Me.HasLastGetData = True
                'we need to set the current instance of FileObject on the base page
                'which is turn being used in AlteredRecord, DeletedRecord and NewRecord Method of
                'the Base Page
                SetLastFileObject()
                blnExists = blnAccessOK
                SetAccessOkOnPage(blnAccessOK)

                If blnCreateRecordsForOccurs Then
                    For i As Integer = m_dtbDataTable.Rows.Count To Occurs - 1
                        AddBlankRecord(i)
                        m_blnNewRecord(i) = True
                    Next

                End If


                Return blnAccessOK

            Catch ex As CustomApplicationException

                Throw ex

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex
            End Try

        End Function

        Protected Function IsSubFileKeep() As Boolean

            If Not IsSubFile Then Return False

            If m_IsKeepSubFile = BooleanTypes.NotSet Then

                Dim objReader As OracleDataReader
                Dim strSQL As New System.Text.StringBuilder("")


                strSQL.Append("SELECT * from ALL_TABLES WHERE TABLE_NAME = ").Append(StringToField(Me.BaseName))
                If SubFileSchema() = "" Then
                    strSQL.Append(" AND OWNER = USER")
                Else
                    strSQL.Append(" AND OWNER = ").Append(StringToField(SubFileSchema))
                End If

                If IsNothing(m_trnTransaction) Then
                    objReader = OracleHelper.ExecuteReader(GetConnectionString, CommandType.Text, strSQL.ToString)
                Else
                    objReader = OracleHelper.ExecuteReader(m_trnTransaction, CommandType.Text, strSQL.ToString)
                End If

                If objReader.Read Then
                    objReader.Close()
                    objReader.Dispose()
                    m_IsKeepSubFile = BooleanTypes.True
                    Return True
                End If

                objReader.Close()
                objReader.Dispose()
                m_IsKeepSubFile = BooleanTypes.False
                Return False
            Else
                If m_IsKeepSubFile = BooleanTypes.True Then
                    Return True
                Else
                    Return False
                End If
            End If

        End Function

        ''' --- SetSearchType ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of SetSearchType.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overridable Sub SetSearchType(ByVal SearchType As SearchTypes)
            ' To be overriden in the OracleFileObject.
        End Sub

        ''' --- GetDataTempTable ---------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetDataTempTable.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overridable Function GetDataTempTable(ByVal WhereClause As String, ByVal OrderByClause As String, Optional ByVal StartRow As Long = -1, Optional ByVal Count As Integer = -1, Optional ByVal trnTransaction As OracleTransaction = Nothing) As DataTable
            Return Nothing
        End Function

        ''' --- GetMetaData --------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetMetaData.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overloads Overrides Sub GetMetaData()
            GetMetaData(CType(Connection, OracleConnection), CType(Transaction, OracleTransaction))
        End Sub

        ''' --- GetMetaData --------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetMetaData.
        ''' </summary>
        ''' <param name="cnn"></param>
        ''' <param name="trn"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overloads Sub GetMetaData(ByRef cnn As OracleConnection, ByRef trn As OracleTransaction)

            Dim strOwner As String = m_strOwner + "_"
            If strOwner.Trim.Equals("_") Then strOwner = ""
            Dim OnRemove As System.Web.Caching.CacheItemRemovedCallback = Nothing
            Dim hshUpdatable As Hashtable = New Hashtable

            If m_dtbMetaData Is Nothing Then
                ' Retrieve the metadata datatable from the CACHE.
                'm_dtbMetaData = CType(CacheManager.GetCacheManager.Item(strOwner + m_strBaseName + "_OraMetadata"), DataTable)
                'm_dtbMetaData = CType(HttpContext.Current.Cache.Item(strOwner + m_strBaseName + "_OraMetadata"), DataTable)

                If m_dtbMetaData Is Nothing Then
                    Dim rdr As OracleDataReader
                    Dim strSQL As StringBuilder = New StringBuilder(ReturnSelectFromSQL(True))
                    strSQL.Append(" WHERE 0 = 1")

                    If cnn Is Nothing Then
                        rdr = OracleHelper.ExecuteReader(trn, CommandType.Text, strSQL.ToString)
                    Else
                        rdr = OracleHelper.ExecuteReader(cnn, CommandType.Text, strSQL.ToString)
                    End If

                    m_dtbMetaData = rdr.GetSchemaTable()
                    rdr.Close()

                    Dim Updatable As New System.Data.DataColumn("Updatable")

                    m_dtbMetaData.Columns.Add(Updatable)

                    strSQL = New StringBuilder("")
                    strSQL.Append("SELECT * FROM all_updatable_columns where table_name = '").Append(m_strBaseName).Append("'")

                    If cnn Is Nothing Then
                        rdr = OracleHelper.ExecuteReader(trn, CommandType.Text, strSQL.ToString)
                    Else
                        rdr = OracleHelper.ExecuteReader(cnn, CommandType.Text, strSQL.ToString)
                    End If

                    ' Set the datatypes to CHAR (since we changed them to VARCHAR.
                    m_dtbMetaData.Columns(m_intProviderTypeOrdinal).ReadOnly = False
                    If Not BaseFileObject.Varchar2Fields Is Nothing Then
                        For i As Integer = 0 To m_dtbMetaData.Rows.Count - 1
                            If Not BaseFileObject.Varchar2Fields.Contains(m_dtbMetaData.Rows(i).Item(0).ToString) _
                            AndAlso m_dtbMetaData.Rows(i).Item(m_intProviderTypeOrdinal).ToString.Equals("22") Then
                                m_dtbMetaData.Rows(i).Item(m_intProviderTypeOrdinal) = 3
                            End If
                        Next
                    End If

                    Do While rdr.Read
                        If Not hshUpdatable.ContainsKey(rdr.Item(2)) Then
                            hshUpdatable.Add(rdr.Item(2), rdr.Item(3))
                        End If
                    Loop

                    For i As Integer = 0 To m_dtbMetaData.Rows.Count - 1
                        If hshUpdatable.Contains(CStr(m_dtbMetaData.Rows(i).Item(0))) Then
                            If CStr(hshUpdatable.Item(CStr(m_dtbMetaData.Rows(i).Item(0)))) = "YES" Then
                                m_dtbMetaData.Rows(i).Item("Updatable") = True
                            Else
                                m_dtbMetaData.Rows(i).Item("Updatable") = False
                            End If
                        End If

                    Next

                    rdr.Close()

                    ' Add the metadata datatable to the CACHE.
                    'CacheManager.CacheStorage.Add(strOwner + m_strBaseName + "_OraMetadata", m_dtbMetaData)
                    'HttpContext.Current.Cache.Add(strOwner + m_strBaseName + "_OraMetadata", m_dtbMetaData, Nothing, DateTime.Now.AddQDesign.Days(1), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, OnRemove)
                End If
            End If

        End Sub

        ''' --- PutData ------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Emulates the PowerHouse PUT verb.
        ''' </summary>
        ''' <param name="Reset"></param>
        ''' <param name="PutType"></param>
        ''' <param name="At"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        ''' PutData(strRowId, strCheckSum)
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overrides Sub PutData()
            PutData(False, PutTypes.None, -1)
        End Sub
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overrides Sub PutData(ByVal Reset As Boolean)
            PutData(Reset, PutTypes.None, -1)
        End Sub
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overrides Sub PutData(ByVal Reset As Boolean, ByVal PutType As PutTypes)
            MyClass.PutData(Reset, PutType, -1)
        End Sub
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overrides Sub PutData(ByVal Reset As Boolean, ByVal PutType As PutTypes, ByVal At As Integer)


            Try

                'For QTP log file

                QTPRecordsRead(Me.BaseName, Me.AliasName, 0, LogType.OutPut)


                ' Execute the code depending on PutType (handled by ContinuePut).  
                ' TYPES: None [Default]
                '        New - Only update records with NewRecord flag set to true.
                '        Deleted - Only update records with DeletedRecord flag set to true.
                '        NotDeleted - Only update records that are not marked for deletion.
                If ContinuePut(PutType) Then

                    ' If we have a file of type DELETE, delete all records 
                    ' that match the ACCESS statement.  For other file types,
                    ' cal the Package that matches the base relation name.
                    If m_intType = FileTypes.Delete Then
                        If m_blnDeletedRecord(Me.CurrentRow) Then
                            If m_intType <> FileTypes.Audit Then
                                'Raise an event to allow Audit Files to write data
                                RaiseAudit()
                            End If

                            Dim strSQL As StringBuilder = New StringBuilder("")
                            Dim strWhereClause As String = GetAccessClause()
                            Dim strSelectIf As String = GetSelectIfClause()
                            Dim strChoose As String = GetChooseClause()

                            If strChoose <> "" Then
                                If strSelectIf <> "" Then
                                    strSelectIf = strSelectIf & " AND " & strChoose
                                Else
                                    strSelectIf = strChoose
                                End If
                            End If

                            strSQL.Append("DELETE FROM ")
                            If m_strOwner.Length > 0 Then
                                strSQL.Append(m_strOwner).Append(".")
                            End If
                            strSQL.Append(m_strBaseName)
                            strSQL.Append(" ")
                            strSQL.Append(m_strAliasName)
                            strSQL.Append(" ")
                            strSQL.Append(strWhereClause)

                            ' Append the SELECT IF.
                            If strSelectIf.TrimEnd.Length > 0 Then
                                If strWhereClause.TrimEnd.Length > 0 Then
                                    strSQL.Append(" AND ")
                                Else
                                    strSQL.Append(" WHERE ")
                                End If
                                strSQL.Append(strSelectIf)
                            End If

                            If IsTempTable Then
                                ' TODO: Add code for delete files.
                            Else
                                If m_blnHasLock Then
                                    OracleHelper.ExecuteNonQuery(m_trnLockedTransaction, CommandType.Text, strSQL.ToString)
                                Else
                                    OracleHelper.ExecuteNonQuery(m_trnTransaction, CommandType.Text, strSQL.ToString)
                                End If
                            End If

                            Dim intCount As Integer
                            Dim strFieldName As String

                            ' Call the SUM INTO and COUNT INTO options.
                            If Not (m_arrSumIntoFields Is Nothing) Then
                                For intCount = 0 To UBound(m_arrSumIntoFields)
                                    strFieldName = m_arrSumIntoFields(intCount)
                                    Select Case m_dtbDataTable.Columns.Item(strFieldName).DataType.ToString
                                        Case "System.Decimal", "System.Double"
                                            RaiseSumInto(strFieldName, 0, CType(m_dtbDataTable.Rows(Me.CurrentRow).Item(strFieldName), Decimal))
                                    End Select
                                Next
                            End If
                            RaiseCountInto(-1)
                            SaveReceivingParam()
                        End If
                    Else
                        ' If NEED is specified, the PUT verb treats data record as changed.
                        If m_blnNewRecord(Me.CurrentRow) AndAlso (m_intType = FileTypes.Primary Or m_intType = FileTypes.Secondary Or m_intType = FileTypes.Detail Or m_intType = FileTypes.Designer) _
                        AndAlso m_intNeed > 0 Then AlteredRecord(Me.CurrentRow) = True


                        ' Call the Initial Fixed and Final items for Old, Undeleted records or New, Altered, Undeleted records 
                        ' or for Audit files that are being Put through the PutAuditData event.
                        If (IsQTP AndAlso NewRecord) OrElse (Not DeletedRecord AndAlso ((Not NewRecord) OrElse (NewRecord AndAlso AlteredRecord))) OrElse (Me.Type = FileTypes.Audit AndAlso m_blnPutInitiatedFromOccursWithFile) Then
                            If Not IsQTP Then
                                ' Set the ITEM INITIAL values with the FIXED flag set to TRUE.
                                RaiseInitializeItems(True)
                            End If

                            If blnQTPInit AndAlso IsQTP AndAlso NewRecord Then
                                ' Set the ITEM INITIAL values with the FIXED flag set to TRUE.
                                RaiseInitializeItems(False)
                            End If

                            ' Set the ITEM FINAL values.
                            RaiseSetItemFinals()
                        End If

                        ' If nothing has changed, return the ROWID and CHECKSUM values.
                        If IsQTP Then
                            If Not m_blnAlteredRecord(Me.CurrentRow) AndAlso Not m_blnNewRecord(Me.CurrentRow) Then
                                Exit Sub
                            End If
                        ElseIf Not m_blnAlteredRecord(Me.CurrentRow) Then
                            Exit Sub
                        End If

                        ' Following code is to allow toggle delete in a Grid during Entry
                        If m_blnNewRecord(Me.CurrentRow) And m_blnDeletedRecord(Me.CurrentRow) Then
                            m_blnAlteredRecord(Me.CurrentRow) = False
                            Exit Sub
                        End If

                        Dim intCount As Integer
                        Dim strFieldName As String

                        ' Execute the BALANCE option for records not marked for DELETION.
                        If Not m_blnDeletedRecord(Me.CurrentRow) Then
                            ' Call the BALANCE option.
                            If Not (m_arrBalanceFields Is Nothing) Then
                                For intCount = 0 To UBound(m_arrBalanceFields)
                                    strFieldName = m_arrBalanceFields(intCount)
                                    Select Case m_dtbDataTable.Columns.Item(strFieldName).DataType.ToString
                                        Case "System.Decimal", "System.Double"
                                            RaiseBalance(strFieldName, CType(m_dtbDataTable.Rows(Me.CurrentRow).Item(strFieldName), Decimal))
                                    End Select
                                Next
                            End If
                        End If

                        If m_intType <> FileTypes.Audit Then
                            'Raise an event to allow Audit Files to write data
                            RaiseAudit()
                        End If

                        If Me.IsTempTable OrElse (IsSubFile AndAlso Not IsSubFileKeep()) Then
                            PutDataTempTable()
                        Else
                            If m_blnUsePutProcedures Then
                                CallPutProcedure()
                            Else
                                CallPutSQL()
                            End If
                        End If

                        ' Reset the record status flags.
                        m_blnNewRecord(Me.CurrentRow) = False
                        If Not IsQTP Then
                            AlteredRecord(Me.CurrentRow) = False
                        End If
                        'Reset the original values
                        m_dtbDataTable.Rows(Me.CurrentRow).AcceptChanges()

                        ' Reset the record buffer and record status 
                        ' flags based on the RESET option.
                        If Reset Then
                            blnQTPInit = True
                            CallReset()
                        End If
                        SaveReceivingParam()

                    End If
                End If

                If Not IsQTP Then
                    CountIntoCalled = False
                End If

            Catch ex As System.Data.OracleClient.OracleException

                If ex.Message.StartsWith("ORA-02292:") Then
                    AddMessage(ex.Message, MessageTypes.Error)
                Else
                    ' Write the exception to the event log and throw an error.
                    ExceptionManager.Publish(ex)
                    Throw ex
                End If

            Catch ex As CustomApplicationException

                Throw ex

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Sub

        ''' --- PutDataTempTable ---------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of PutDataTempTable.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overridable Sub PutDataTempTable()

            ' To be overriden in OracleFileObject.

        End Sub

        ''' --- CallPutProcedure ---------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of CallPutProcedure.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Private Sub CallPutProcedure()

            Dim intParmCount As Integer
            Dim intColumn As Integer
            Dim intCheckSumPosition As Integer
            Dim strColumnName As String
            Dim alCLobs As ArrayList = Nothing
            Dim prmFields() As OracleParameter = Nothing
            Dim objOracleException As OracleException
            Dim strMessage As String = String.Empty
            Dim strParams As String = String.Empty

            ' Loop through the columns and create the appropriate parameter objects.
            For intColumn = 0 To m_dtbDataTable.Columns.Count - 1

                ' Store the column name.
                strColumnName = m_dtbDataTable.Columns.Item(intColumn).ColumnName.ToString

                ' Create parameters for columns that are not Audit fields.  
                ' Also exclude ROW_NUM and ROW_ID columns
                If IsValidColumn(strColumnName) Then

                    Dim blnIsClob As Boolean = IsClob(intColumn)

                    If Not blnIsClob Then

                        ReDim Preserve prmFields(intParmCount)
                        prmFields(intParmCount) = New OracleParameter

                        ' Set the parameter name.
                        prmFields(intParmCount).ParameterName = "P_" & GetBriefName(strColumnName, True)
                    End If


                    Select Case m_dtbDataTable.Columns.Item(intColumn).DataType.ToString
                        Case "System.String"
                            ' Check if we have a CLOB.
                            If blnIsClob Then

                                ' Check if the contents of the CLOB were modified.  If so,
                                ' add this column id to the arraylist.
                                If (m_dtbDataTable.Rows(Me.CurrentRow).Item("ROW_ID").ToString.TrimEnd.Equals(String.Empty) AndAlso Not m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn).ToString.Trim.Equals(String.Empty)) _
                                OrElse Not m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn, DataRowVersion.Current).Equals(m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn, DataRowVersion.Original)) Then
                                    If alCLobs Is Nothing Then alCLobs = New ArrayList
                                    alCLobs.Add(intColumn)
                                End If
                            Else
                                prmFields(intParmCount).OracleType = OracleType.VarChar
                                ' Set the size of the field for character fields.
                                If m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn) Is Nothing Or m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn).GetType.ToString = "System.DBNull" Then
                                    prmFields(intParmCount).Size = 1
                                Else
                                    Dim strValue As String = CType(m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn), String)
                                    Dim intSize As Integer = ReturnColumnSize(intColumn)
                                    prmFields(intParmCount).Size = intSize 'strValue.Length

                                    ' In case the value is greater in length.
                                    If strValue.Length > intSize Then strValue = strValue.Substring(0, intSize)
                                End If
                            End If
                        Case "System.DateTime"
                            prmFields(intParmCount).OracleType = OracleType.DateTime
                        Case "System.Decimal", "System.Double"
                            prmFields(intParmCount).OracleType = OracleType.Number
                        Case "System.Blob"
                            prmFields(intParmCount).OracleType = OracleType.Blob
                        Case "System.Clob"
                            prmFields(intParmCount).OracleType = OracleType.Clob
                    End Select

                    If Not blnIsClob Then
                        prmFields(intParmCount).Direction = ParameterDirection.Input
                        If m_dtbDataTable.Columns.Item(intColumn).DataType.ToString = "System.String" Then
                            prmFields(intParmCount).Value = StringToField(m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn).ToString, True)
                        ElseIf m_dtbDataTable.Columns.Item(intColumn).DataType.ToString = "System.DateTime" _
                        AndAlso (m_dtbDataTable.Columns.Item(intColumn).AllowDBNull AndAlso (IsNull(m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn)) _
                        OrElse (CDate(m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn)) = cZeroDate AndAlso Me.NewRecord(Me.CurrentRow)) _
                        OrElse (CDate(m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn)) = cZeroDate AndAlso ((Not Me.NewRecord(Me.CurrentRow)) _
                        AndAlso ((Not m_dtbDataTable.Rows(Me.CurrentRow).HasVersion(DataRowVersion.Original) AndAlso CDate(m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn)) = cZeroDate) _
                        OrElse (m_dtbDataTable.Rows(Me.CurrentRow).HasVersion(DataRowVersion.Original) AndAlso CDate(m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn, DataRowVersion.Original)) = cZeroDate)))))) Then
                            prmFields(intParmCount).Value = DBNull.Value
                        Else
                            ' Handle 0 date.
                            If m_dtbDataTable.Columns.Item(intColumn).DataType.ToString = "System.DateTime" AndAlso CDate(m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn)) = cZeroDate Then
                                prmFields(intParmCount).Value = DBNull.Value  ' Set 0 date to Null
                            Else
                                prmFields(intParmCount).Value = m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn)
                                ' Trim any number values based on the Decimal position in the Dictionary.
                                Select Case m_dtbDataTable.Columns.Item(intColumn).DataType.ToString
                                    Case "System.Decimal", "System.Double"
                                        If Not m_dtbDataTable.Columns(intColumn).ExtendedProperties.Item("D") Is Nothing Then
                                            Dim strValue As String = prmFields(intParmCount).Value.ToString
                                            Dim index As Integer = strValue.IndexOf(".")
                                            Dim decimalValue As Integer = CInt(m_dtbDataTable.Columns(intColumn).ExtendedProperties.Item("D"))
                                            If index > -1 AndAlso strValue.Length - index > decimalValue + 1 Then
                                                prmFields(intParmCount).Value = strValue.Substring(0, index + decimalValue + 1)
                                            End If
                                        End If
                                End Select
                            End If
                        End If

                        ' Determine the position of the CheckSum_Value field.
                        If strColumnName.ToUpper = "CHECKSUM_VALUE" Then
                            prmFields(intParmCount).Direction = ParameterDirection.InputOutput
                            intCheckSumPosition = intParmCount
                        End If

                        ' Increment the parameter count.
                        intParmCount += 1
                    End If
                End If
            Next

            ' ReDim the array to add the ROWID and DELETE_FLAG parameters.
            ReDim Preserve prmFields(intParmCount + 1)

            ' Add the ROWID parameter.
            prmFields(intParmCount) = New OracleParameter
            prmFields(intParmCount).ParameterName = "P_ROWID"
            prmFields(intParmCount).OracleType = OracleType.RowId
            prmFields(intParmCount).Direction = ParameterDirection.InputOutput
            If m_blnNewRecord(Me.CurrentRow) Then
                prmFields(intParmCount).Value = String.Empty
            Else
                prmFields(intParmCount).Value = m_dtbDataTable.Rows(Me.CurrentRow).Item("ROW_ID").ToString.TrimEnd
            End If

            ' Add the DELETE_FLAG parameter.
            prmFields(intParmCount + 1) = New OracleParameter
            prmFields(intParmCount + 1).ParameterName = "P_DELETE_FLAG"
            prmFields(intParmCount + 1).OracleType = OracleType.VarChar
            prmFields(intParmCount + 1).Size = 1
            prmFields(intParmCount + 1).Direction = ParameterDirection.Input
            prmFields(intParmCount + 1).Value = IIf(m_blnDeletedRecord(Me.CurrentRow), "T", "")

            '' Uncomment following to Generate Parameters passed Stored Procedure
            'Dim objParam As OracleParameter
            'For Each objParam In prmFields
            '    Debug.Write(objParam.OracleType)
            '    Debug.Write(vbTab)
            '    Debug.Write(objParam.Size)
            '    Debug.Write(vbTab)
            '    Debug.Write(objParam.ParameterName)
            '    Debug.Write(vbTab)
            '    Debug.WriteLine(objParam.Value)
            'Next

            'Set Audit Info for the subsequent update
            SetAuditInfo()

            ' Execute the PUT procedure.
            Dim intRecordsAffected As Integer
            Dim strOwner As String = m_strOwner + "."
            If strOwner.Trim.Equals(".") Then strOwner = ""
            Try
                If m_blnHasLock Then
                    intRecordsAffected = OracleHelper.ExecuteNonQuery(m_trnLockedTransaction, CommandType.StoredProcedure, strOwner + "PKG_" & GetBriefName(m_strBaseName) & ".PUT_VB", prmFields)
                Else
                    intRecordsAffected = OracleHelper.ExecuteNonQuery(m_trnTransaction, CommandType.StoredProcedure, strOwner + "PKG_" & GetBriefName(m_strBaseName) & ".PUT_VB", prmFields)
                End If
            Catch ex As OracleException
                If ex.Message.IndexOf("unique constraint") > -1 Then
                    strMessage = "Unique constraint violated on {0}." 'IM.UniqueConstraint
                    strParams = m_strBaseName
                Else
                    objOracleException = ex
                    ExceptionManager.Publish(ex)
                End If
                intRecordsAffected = -1
            End Try

            If intRecordsAffected > 0 Then

                If Not m_blnDeletedRecord(Me.CurrentRow) Then
                    ' Assign the ROWID and CHECKSUM_VALUE fields back to the datatable.
                    m_dtbDataTable.Rows(Me.CurrentRow).Item("ROW_ID") = prmFields(intParmCount).Value
                    m_dtbDataTable.Rows(Me.CurrentRow).Item("CHECKSUM_VALUE") = prmFields(intCheckSumPosition).Value
                End If
                prmFields = Nothing

                ' Update the CLOBS.
                UpdateCLobs(alCLobs)
                alCLobs = Nothing

                'Delete Audit info set by SetAuditInfo
                DeleteAuditInfo()

                If m_blnDeletedRecord(Me.CurrentRow) Then
                    m_blnGridDeletedRecord(Me.CurrentRow) = True
                End If
            Else
                prmFields = Nothing

                'Delete Audit info set by SetAuditInfo
                DeleteAuditInfo()
                If intRecordsAffected = 0 Then
                    If Not m_blnGridDeletedRecord(Me.CurrentRow) Then
                        AddMessage("IM.DataChangedDB", MessageTypes.Error, m_strBaseName) 'IM.DataChangedDB
                    Else
                        AddMessage("IM.DataAlreadyDeletedDB", MessageTypes.Information, m_strBaseName, (Me.CurrentRow + 1).ToString)
                    End If
                Else
                    If strMessage.Length > 0 Then
                        If strParams.Length = 0 Then
                            AddMessage(strMessage, MessageTypes.Error)
                        Else
                            AddMessage(strMessage, MessageTypes.Error, strParams)
                        End If
                    Else
                        AddMessage("IM.DBError", MessageTypes.Error, m_strBaseName)
                    End If
                End If
            End If

        End Sub

        ''' --- CallPutSQL ---------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of CallPutSQL.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Private Sub CallPutSQL()

            Dim strRowID As String = m_dtbDataTable.Rows(Me.CurrentRow).Item("ROW_ID").ToString.TrimEnd
            Dim strSQL As StringBuilder = New StringBuilder(String.Empty)
            Dim prmFields(1) As OracleParameter
            Dim intRecordsAffected As Integer
            Dim blnIsInsert As Boolean = False
            Dim objOracleException As OracleException
            Dim alCLobs As ArrayList = Nothing
            Dim intColumn As Integer
            Dim strMessage As String = String.Empty
            Dim strParams As String = String.Empty

            ' Determine if we are deleting a record or not
            If m_blnDeletedRecord(Me.CurrentRow) Then
                ' Generate the DELETE statement.
                strSQL.Append("DELETE FROM ")
                If m_strOwner.Length > 0 Then
                    strSQL.Append(m_strOwner).Append(".")
                End If
                strSQL.Append(m_strBaseName)
                strSQL.Append(" WHERE ROWID = '").Append(strRowID).Append("'")
                If IsNull(m_dtbDataTable.Rows(Me.CurrentRow).Item("CHECKSUM_VALUE")) Then
                    strSQL.Append(" AND CheckSum_Value IS NULL")
                Else
                    strSQL.Append(" AND CheckSum_Value = ").Append(m_dtbDataTable.Rows(Me.CurrentRow).Item("CHECKSUM_VALUE").ToString)
                End If

                If m_blnHasLock Then
                    intRecordsAffected = OracleHelper.ExecuteNonQuery(m_trnLockedTransaction, CommandType.Text, strSQL.ToString)
                Else
                    intRecordsAffected = OracleHelper.ExecuteNonQuery(m_trnTransaction, CommandType.Text, strSQL.ToString)
                End If
            Else
                ' We are INSERTING or UPDATING a record.
                strSQL.Append("DECLARE P_ROWID VARCHAR2(18); P_CHECKSUM_VALUE NUMBER; BEGIN ")
                'strSQL.Append("SESSION_INFO.SET_LOGGEDON_USER_ID('" + GetCurrentUserID + "');")

                ' Determine if we have a new record or not.
                If strRowID.Equals(String.Empty) OrElse m_blnNewRecord(Me.CurrentRow) Then
                    ' Generate the INSERT statement.
                    strSQL.Append("INSERT INTO ")
                    If m_strOwner.Length > 0 Then
                        strSQL.Append(m_strOwner).Append(".")
                    End If
                    strSQL.Append(m_strBaseName).Append(" (")
                    blnIsInsert = True
                Else
                    ' Generate the UPDATE statement.
                    strSQL.Append("UPDATE ")
                    If m_strOwner.Length > 0 Then
                        strSQL.Append(m_strOwner).Append(".")
                    End If
                    strSQL.Append(m_strBaseName).Append(" SET ")
                End If

                Dim strColumnName As String = ""
                Dim strValue As String = ""
                Dim blnZeroDate As Boolean = False
                Dim blnFirstColumn As Boolean = True
                Dim strColumns As StringBuilder = New StringBuilder(String.Empty)
                Dim strValues As StringBuilder = New StringBuilder(String.Empty)

                ' Create the rest of the SQL
                ' Loop through the columns and create the appropriate parameter objects.
                For intColumn = 0 To m_dtbDataTable.Columns.Count - 1

                    Dim blnIsClob As Boolean = False
                    blnZeroDate = False

                    ' Store the column name.
                    strColumnName = m_dtbDataTable.Columns.Item(intColumn).ColumnName.ToString

                    ' Create parameters for columns that are not Audit fields.  
                    ' Also exclude ROW_NUM and ROW_ID columns
                    If IsValidColumn(strColumnName) AndAlso ReturnIsUpdatable(intColumn) Then
                        Select Case m_dtbDataTable.Columns.Item(intColumn).DataType.ToString
                            Case "System.String"
                                ' Check if we have a CLOB.
                                If IsClob(intColumn) Then
                                    blnIsClob = True

                                    ' Check if the contents of the CLOB were modified.  If so,
                                    ' add this column id to the arraylist.
                                    If (blnIsInsert AndAlso Not m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn).ToString.Trim.Equals(String.Empty)) _
                                    OrElse ((m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn).ToString.Trim.Equals(String.Empty) AndAlso Not m_dtbDataTable.Rows(Me.CurrentRow).HasVersion(DataRowVersion.Original)) OrElse Not m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn, DataRowVersion.Current).Equals(m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn, DataRowVersion.Original))) Then
                                        If alCLobs Is Nothing Then alCLobs = New ArrayList
                                        alCLobs.Add(intColumn)
                                    End If

                                    ' Insert a null value for new records.
                                    If blnIsInsert Then
                                        strValue = "' '"
                                    End If
                                Else
                                    If m_dtbDataTable.Columns.Item(intColumn).AllowDBNull _
                                    AndAlso IsNull(m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn)) Then
                                        strValue = "Null"
                                    Else
                                        strValue = StringToField(CType(m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn), String).TrimEnd)
                                    End If
                                End If
                            Case "System.DateTime"
                                If m_dtbDataTable.Columns.Item(intColumn).AllowDBNull AndAlso (IsNull(m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn)) _
                                OrElse (CDate(m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn)) = cZeroDate AndAlso blnIsInsert) _
                                OrElse (CDate(m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn)) = cZeroDate AndAlso ((Not blnIsInsert) AndAlso
                                ((Not m_dtbDataTable.Rows(Me.CurrentRow).HasVersion(DataRowVersion.Original) AndAlso CDate(m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn)) = cZeroDate) OrElse
                                (m_dtbDataTable.Rows(Me.CurrentRow).HasVersion(DataRowVersion.Original) AndAlso CDate(m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn, DataRowVersion.Original)) = cZeroDate))))) Then
                                    strValue = "Null"
                                Else
                                    If CDate(m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn)) = cZeroDate Then
                                        strValue = "Null" ' Set 0 date to Null
                                        blnZeroDate = True
                                    Else
                                        strValue = "TO_TIMESTAMP(" + StringToField(Format(CDate(m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn)), "yyyy/MM/dd HH:mm:ss.ffff")) + ", 'YYYY/MM/DD HH24:MI:SS.FF4')"
                                    End If
                                End If
                            Case "System.Decimal", "System.Double"
                                If m_dtbDataTable.Columns.Item(intColumn).AllowDBNull _
                                AndAlso IsNull(m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn)) Then
                                    strValue = "Null"
                                Else
                                    strValue = m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn).ToString
                                    ' Trim any number values based on the Decimal position in the Dictionary.
                                    If Not m_dtbDataTable.Columns(intColumn).ExtendedProperties.Item("D") Is Nothing Then
                                        Dim index As Integer = strValue.IndexOf(".")
                                        Dim decimalValue As Integer = CInt(m_dtbDataTable.Columns(intColumn).ExtendedProperties.Item("D"))
                                        If index > -1 AndAlso strValue.Length - index > decimalValue + 1 Then
                                            strValue = strValue.Substring(0, index + decimalValue + 1)
                                        End If
                                    End If
                                End If
                            Case "System.Blob"
                                strValue = m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn).ToString
                        End Select

                        If blnIsInsert Then
                            ' Determine if we need to add a comma.
                            If Not blnFirstColumn Then strSQL.Append(",")
                            If Not blnFirstColumn Then strValues.Append(",")
                            blnFirstColumn = False

                            ' Append all the columns.
                            strSQL.Append(strColumnName)

                            ' Append all the values.
                            strValues.Append(strValue)
                        Else
                            If Not blnIsClob AndAlso (Not strValue.Equals("Null") OrElse blnZeroDate) Then
                                ' Only append the fields that have changed.
                                If Not m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn).Equals(m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn, DataRowVersion.Original)) Then
                                    If Not blnFirstColumn Then strSQL.Append(",")
                                    blnFirstColumn = False

                                    ' We are creating the update SQL.
                                    strSQL.Append(strColumnName).Append("=").Append(strValue)
                                End If
                            End If
                        End If
                    End If
                Next

                If blnIsInsert Then
                    strSQL.Append(") VALUES (")
                    strSQL.Append(strValues.ToString).Append(")")
                    strSQL.Append(" RETURNING ROWIDTOCHAR(ROWID), CHECKSUM_VALUE INTO :P_ROWID, :P_CHECKSUM_VALUE;")
                Else
                    ' If we have an Update with no columns that were changed but altered record is true (due to the fact
                    ' that a field was changed and then reset to the original value), then exit this procedure.  We should not update anything.
                    If Not m_blnDeletedRecord(Me.CurrentRow) AndAlso blnFirstColumn Then
                        Exit Sub
                    End If
                    If strSQL.ToString.IndexOf("CHECKSUM_VALUE=") = -1 AndAlso strSQL.ToString.IndexOf("CHECKSUM_VALUE =") = -1 _
                   AndAlso Not IsNull(m_dtbDataTable.Rows(Me.CurrentRow).Item("CHECKSUM_VALUE")) _
                   AndAlso m_dtbDataTable.Rows(Me.CurrentRow).Item("CHECKSUM_VALUE").ToString.Length > 0 Then
                        strSQL.Append(", CHECKSUM_VALUE = ").Append(m_dtbDataTable.Rows(Me.CurrentRow).Item("CHECKSUM_VALUE").ToString)
                    End If
                    strSQL.Append(" WHERE ROWID = ").Append("'").Append(m_dtbDataTable.Rows(Me.CurrentRow).Item("ROW_ID").ToString).Append("'")
                    strSQL.Append(" RETURNING ROWIDTOCHAR(ROWID), CHECKSUM_VALUE INTO :P_ROWID, :P_CHECKSUM_VALUE;")
                End If
                'strSQL.Append("SESSION_INFO.DELETE_LOGGEDON_USER_ID;")
                strSQL.Append(" END;")

                ' Add the ROWID parameter.
                prmFields(0) = New OracleParameter
                With prmFields(0)
                    .ParameterName = ":P_ROWID"
                    .OracleType = OracleType.RowId
                    .Direction = ParameterDirection.Output
                End With

                ' Add the DELETE_FLAG parameter.
                prmFields(1) = New OracleParameter
                With prmFields(1)
                    .ParameterName = ":P_CHECKSUM_VALUE"
                    .OracleType = OracleType.Number
                    .Size = 1
                    .Direction = ParameterDirection.Output
                End With
                Try
                    If m_blnHasLock Then
                        intRecordsAffected = OracleHelper.ExecuteNonQuery(m_trnLockedTransaction, CommandType.Text, strSQL.ToString, prmFields)
                    Else
                        intRecordsAffected = OracleHelper.ExecuteNonQuery(m_trnTransaction, CommandType.Text, strSQL.ToString, prmFields)
                    End If
                Catch ex As OracleException
                    If ex.Message.IndexOf("unique constraint") > -1 Then
                        strMessage = "IM.UniqueConstraint"
                        strParams = m_strBaseName
                        intRecordsAffected = -1
                    ElseIf Not ex.Message.StartsWith("ORA-20501:") Then
                        objOracleException = ex
                        ExceptionManager.Publish(ex)
                        intRecordsAffected = -1
                    End If
                End Try

                strSQL = Nothing
                strColumns = Nothing
                strValues = Nothing

            End If

            If intRecordsAffected > 0 Then
                'added for the QTP log
                Dim PassLog As LogType = LogType.Updated
                Dim strName As String = Me.BaseName

                If m_blnDeletedRecord(Me.CurrentRow) Then
                    PassLog = LogType.Deleted
                Else
                    If blnIsInsert Then
                        PassLog = LogType.Added
                    End If
                End If
                QTPRecordsRead(Me.BaseName, Me.AliasName, intRecordsAffected, PassLog)
                If Not m_blnDeletedRecord(Me.CurrentRow) Then
                    ' Assign the ROWID and CHECKSUM_VALUE fields back to the datatable.
                    m_dtbDataTable.Rows(Me.CurrentRow).Item("ROW_ID") = prmFields(0).Value
                    m_dtbDataTable.Rows(Me.CurrentRow).Item("CHECKSUM_VALUE") = prmFields(1).Value

                    ' Set the datatable row to accept the current changes which will set the RowState to Unchanged.
                    m_dtbDataTable.Rows(Me.CurrentRow).AcceptChanges()
                End If
                prmFields = Nothing

                ' Update the CLOBS.
                UpdateCLobs(alCLobs)

                If m_blnDeletedRecord(Me.CurrentRow) Then
                    m_blnGridDeletedRecord(Me.CurrentRow) = True
                End If

            Else
                prmFields = Nothing
                If intRecordsAffected = 0 Then
                    If Not m_blnGridDeletedRecord(Me.CurrentRow) Then
                        AddMessage("IM.DataChangedDB", MessageTypes.Error, m_strBaseName)
                    Else
                        AddMessage("IM.DataAlreadyDeletedDB", MessageTypes.Information, m_strBaseName, (Me.CurrentRow + 1).ToString)
                    End If
                Else
                    If strMessage.Length > 0 Then
                        AddMessage(strMessage, MessageTypes.Error, strParams)  ' Allows us to use the globalization.
                    Else
                        AddMessage("IM.DBError", MessageTypes.Error, m_strBaseName)
                    End If
                End If
            End If

        End Sub

        ''' --- AddMessage ---------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of AddMessage.
        ''' </summary>
        ''' <param name="Message"></param>
        ''' <param name="Type"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overrides Sub AddMessage(ByVal Message As String, ByVal Type As MessageTypes, ByVal ParamArray Parameters() As Object)
            ' Must be overriden in OracleFileObject.
        End Sub

        ''' --- UpdateCLobs --------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of UpdateCLobs.
        ''' </summary>
        ''' <param name="alCLobs"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Private Sub UpdateCLobs(ByVal alCLobs As ArrayList)

            ' Update any CLOB fields.
            If Not alCLobs Is Nothing Then
                Dim clob As OracleLob
                Dim rdr As OracleDataReader
                Dim intColumn As Integer
                Dim strOwner As String = m_strOwner + "."
                If strOwner.Trim.Equals(".") Then strOwner = ""

                Dim sbSQL As StringBuilder = New StringBuilder("SELECT * FROM ")
                sbSQL.Append(strOwner).Append(m_strBaseName)
                sbSQL.Append(" WHERE ROWID = '").Append(m_dtbDataTable.Rows(Me.CurrentRow).Item("ROW_ID").ToString)
                sbSQL.Append("' FOR UPDATE")

                If m_blnHasLock Then
                    rdr = OracleHelper.ExecuteReader(m_trnLockedTransaction, CommandType.Text, sbSQL.ToString)
                Else
                    rdr = OracleHelper.ExecuteReader(m_trnTransaction, CommandType.Text, sbSQL.ToString)
                End If
                sbSQL = Nothing

                If rdr.Read Then
                    Dim clobEnumerator As System.Collections.IEnumerator = alCLobs.GetEnumerator()
                    Dim strValue As String
                    While clobEnumerator.MoveNext()
                        intColumn = CInt(clobEnumerator.Current)
                        strValue = CType(m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn), String)
                        If strValue.Equals(String.Empty) Then strValue = " "
                        clob = rdr.GetOracleLob(intColumn)
                        Dim bytes As Byte() = System.Text.Encoding.Unicode.GetBytes(strValue)
                        ' Ensure that we remove the previous contents.  This is 
                        ' important when writing shorter values then the previous value.
                        clob.Erase()

                        ' Write the new value.
                        clob.Write(bytes, 0, bytes.Length)
                        clob.Flush()
                    End While
                End If
                rdr.Close()
                rdr.Dispose()
            End If

        End Sub

        ''' --- SetAuditInfo -------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of SetAuditInfo.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Private Sub SetAuditInfo()
            'Set Audit Info for the subsequent update
            'OracleHelper.ExecuteNonQuery(m_trnTransaction, CommandType.StoredProcedure, "SESSION_INFO.SET_LOGGEDON_USER_ID", GetAuditParameters)
        End Sub

        ''' --- DeleteAuditInfo ----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of DeleteAuditInfo.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Private Sub DeleteAuditInfo()
            'Delete Audit info set by SetAuditInfo
            'OracleHelper.ExecuteNonQuery(m_trnTransaction, CommandType.StoredProcedure, "SESSION_INFO.DELETE_LOGGEDON_USER_ID")
        End Sub

        ''' --- GetAuditParameters -------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetAuditParameters.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Private Function GetAuditParameters() As OracleParameter()
            Dim prmFields(0) As OracleParameter
            prmFields(0) = New OracleParameter
            With prmFields(0)
                .ParameterName = "P_USER_ID"
                .OracleType = OracleType.Char
                .Direction = ParameterDirection.Input
                .Value = GetCurrentUserID()
            End With
            Return prmFields
        End Function

        ''' --- IsValidColumn ------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of IsValidColumn.
        ''' </summary>
        ''' <param name="ColumnName"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Private Function IsValidColumn(ByVal ColumnName As String) As Boolean
            Select Case ColumnName
                Case "ROW_NUM", "ROWID", "ROW_ID", "AUDIT_WHO", "AUDIT_WHERE",
                    "AUDIT_WHEN", "AUDIT_UPDATE_TYPE", "AUDIT_CREATION_DATE",
                    "AUDIT_NETWORK_UPDATE"
                    Return False
                Case Else
                    Return True
            End Select
        End Function

        ''' --- ExecuteScalar ------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of ExecuteScalar.
        ''' </summary>
        ''' <param name="connectionString"></param>
        ''' <param name="commandType"></param>
        ''' <param name="commandText"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overrides Function ExecuteScalar(ByVal connectionString As String, ByVal commandType As CommandType, ByVal commandText As String) As Long

            Return CType(OracleHelper.ExecuteScalar(connectionString, commandType, commandText), Long)

        End Function

        ''' --- GetSubSelectStatement ----------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetSubSelectStatement.
        ''' </summary>
        ''' <param name="SQLStatement"></param>
        ''' <param name="WhereClause"></param>
        ''' <param name="OrderByClause"></param>
        ''' <param name="CurrentRecordPosition"></param>
        ''' <param name="SkippedRecords"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overrides Function GetSubSelectStatement(ByVal SQLStatement As StringBuilder, ByVal WhereClause As String, ByVal OrderByClause As String, ByVal CurrentRecordPosition As Long, ByRef SkippedRecords As Integer, Optional ByRef blnoverridesql As Boolean = False) As String
            Dim intRecordsToFill As Integer
            Dim intStartRow As Long

            If (CurrentRecordPosition < 0) Then
                CurrentRecordPosition = 1
            End If

            m_intCurrentRecordPosition = CurrentRecordPosition
            intStartRow = CurrentRecordPosition
            intRecordsToFill = Me.TotalRecordsToRetrieve(SkippedRecords, intStartRow)

            ' Add the Sub-Select code.
            With SQLStatement
                'If by chance SQL Statement contains anything remove it
                If .Length > 0 Then
                    .Remove(0, .Length)
                End If

                .Append("Select * ")
                .Append(" FROM (SELECT TEMP.*, ROWNUM ROW_NUM")
                .Append(" FROM (SELECT ")
                If Me.ColumnsUsed.Equals("*") Then
                    .Append(m_strRelation)
                    .Append(".*, ")
                    .Append(m_strRelation)
                    .Append(".ROWID ROW_ID")
                Else
                    .Append(Me.ColumnsUsed)
                End If
                .Append(" FROM ")
                If m_strOwner.Length > 0 Then
                    .Append(m_strOwner).Append(".")
                End If
                .Append(m_strBaseName)
                .Append("  ")
                .Append(m_strAliasName)
                .Append(WhereClause)
                .Append(OrderByClause)
                .Append(" ) TEMP)")
                .Append(" WHERE ROW_NUM BETWEEN ")
                '.Append((CurrentRecordPosition).ToString)
                .Append((intStartRow).ToString)
                .Append(" AND ")
                '.Append((CurrentRecordPosition + Math.Max(Me.Occurs, 1) - 1).ToString)
                .Append((intStartRow + intRecordsToFill - 1).ToString)
                Return .ToString
            End With

        End Function

        ''' --- GetConnectionString ------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetConnectionString.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overrides Function GetConnectionString() As String
            'Must be overrided in derived class
            Return Common.GetConnectionString
        End Function

        ''' --- Lock ---------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Lock.
        ''' </summary>
        ''' <param name="LockTypes"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overrides Function Lock(ByVal LockTypes As LockTypes) As Boolean
            m_ltLockTypes = LockTypes
            Select Case LockTypes
                Case LockTypes.Record, LockTypes.File
                    m_blnHasLock = True

                    m_cnnLockedTransaction = New OracleClient.OracleConnection(GetConnectionString)
                    With m_cnnLockedTransaction
                        .Open()
                        Me.GetMetaData(m_cnnLockedTransaction, Nothing)
                        m_trnLockedTransaction = .BeginTransaction
                    End With

                    If LockTypes = LockTypes.File Then
                        'Lock the Table in Exclusive Mode
                        OracleHelper.ExecuteNonQuery(m_trnLockedTransaction, CommandType.Text, "LOCK TABLE " + Me.TableNameWithOwner + " IN EXCLUSIVE MODE")
                    End If
                Case LockTypes.Base
                    'TODO: To be implemented
            End Select
        End Function

        ''' --- OpHPBnection -----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of OpHPBnection.
        ''' </summary>
        ''' <param name="RequireNewTrnsaction"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overloads Overrides Function OpHPBnection(ByVal RequireNewTrnsaction As Boolean) As Boolean
            If Not m_cnnTransaction Is Nothing AndAlso m_cnnTransaction.State = ConnectionState.Closed Then
                m_cnnTransaction.Open()
                If RequireNewTrnsaction Or m_blnHasLock Then
                    m_trnTransaction = m_cnnTransaction.BeginTransaction
                End If
            Else
                'We may need to extend this behaviour
            End If
        End Function

        ''' --- CloseConnection ----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of CloseConnection.
        ''' </summary>
        ''' <param name="Commit"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overloads Overrides Function CloseConnection(ByVal Commit As Boolean) As Boolean
            If Not m_cnnTransaction Is Nothing AndAlso m_cnnTransaction.State = ConnectionState.Open Then
                If m_cnnTransaction.State <> ConnectionState.Open Then
                    'Not opened? at present do nothing.
                    'This might be a logical error, or may need to address this issue in Framework
                Else
                    If Commit Or m_blnHasLock Then
                        m_trnTransaction.Commit()
                        m_blnHasLock = False
                        m_ltLockTypes = LockTypes.NotSet
                    Else
                        'Rollback????
                    End If
                    m_cnnTransaction.Close()
                End If
            End If
        End Function

        ''' --- CloseLockedConnection ----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of CloseLockedConnection.
        ''' </summary>
        ''' <param name="Commit"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overloads Overrides Function CloseLockedConnection(ByVal Commit As Boolean) As Boolean
            If Not m_cnnLockedTransaction Is Nothing AndAlso m_cnnLockedTransaction.State = ConnectionState.Open Then
                If m_cnnLockedTransaction.State <> ConnectionState.Open Then
                    'Not opened? at present do nothing.
                    'This might be a logical error, or may need to address this issue in Framework
                Else
                    If Commit Or m_blnHasLock Then
                        m_trnLockedTransaction.Commit()
                        m_blnHasLock = False
                        m_ltLockTypes = LockTypes.NotSet
                    Else
                        'Rollback????
                    End If
                    m_cnnLockedTransaction.Close()
                End If
            End If
        End Function

        ''' --- Unlock -------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Unlock.
        ''' </summary>
        ''' <param name="LockTypes"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overrides Function Unlock(ByVal LockTypes As LockTypes) As Boolean
            CloseLockedConnection(True)
        End Function

#End Region

#Region "Dispose Methods"

        ''' --- Dispose ------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Dispose.
        ''' </summary>
        ''' <param name="Disposing"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
            ' Check to see if Dispose has already been called. 
            If Not (Me.FileDisposed) Then
                ' If Disposing equals true, dispose all managed 
                ' and unmanaged resources.
                If (Disposing) Then
                    ' Check to see if Dispose has already been called.
                    ' Dispose managed resources.
                    If Not m_drdDataReader Is Nothing Then
                        If Not m_drdDataReader.IsClosed Then m_drdDataReader.Close()
                        m_drdDataReader.Dispose()
                        m_drdDataReader = Nothing
                    End If

                    If Not m_cnnTransaction Is Nothing Then
                        m_cnnTransaction.Dispose()
                        m_cnnTransaction = Nothing
                    End If

                    If Not m_cnnLockedTransaction Is Nothing Then
                        m_cnnLockedTransaction.Dispose()
                        m_cnnLockedTransaction = Nothing
                    End If

                    If Not m_dtbDataTable Is Nothing Then
                        m_dtbDataTable.Dispose()
                        m_dtbDataTable = Nothing
                    End If

                    If Not IsNothing(m_dtbQTPTempDataTable) Then
                        m_dtbQTPTempDataTable.Dispose()
                        m_dtbQTPTempDataTable = Nothing
                    End If

                    If Not IsNothing(tmpDataTable) Then
                        tmpDataTable.Dispose()
                        tmpDataTable = Nothing
                    End If

                    If Not m_trnTransaction Is Nothing Then
                        m_trnTransaction.Dispose()
                        m_trnTransaction = Nothing
                    End If

                    If Not m_trnLockedTransaction Is Nothing Then
                        m_trnLockedTransaction.Dispose()
                        m_trnLockedTransaction = Nothing
                    End If

                    If Not m_dtbMetaData Is Nothing Then
                        m_dtbMetaData.Dispose()
                        m_dtbMetaData = Nothing
                    End If

                    Me.m_arrBalanceFields = Nothing
                    Me.m_arrSumIntoFields = Nothing
                    Me.m_blnAlteredRecord = Nothing
                    Me.m_blnDeletedRecord = Nothing
                    Me.m_blnGridDeletedRecord = Nothing
                    Me.m_blnEOF = Nothing
                    Me.m_strAliasName = Nothing
                    Me.m_strBaseName = Nothing
                    Me.m_strCursor = Nothing
                    Me.m_strLastSQL = Nothing
                    Me.m_strOrderBy = Nothing
                    Me.m_strOwner = Nothing
                    Me.m_strRelation = Nothing
                End If
                MyBase.Dispose(True)
            End If
        End Sub

#End Region

    End Class

End Namespace
#End If

