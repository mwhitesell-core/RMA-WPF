Option Explicit On

Imports Core.Framework.Cache
Imports Core.Framework.Core.Windows.Framework
Imports System.Threading

#If TARGET_DB <> "INFORMIX" Then
Imports Core.Framework
Imports Core.DataAccess.SqlServer
Imports System.Data.SqlClient
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

Namespace Core.Framework

    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: SqlFileObjectBase
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of SqlFileObjectBase.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Class SqlFileObjectBase
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

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_cnnTransaction As SqlConnection                    ' Connection used for REFERENCE files.

        Protected m_hsChecksum As New Hashtable
        Protected blnOnErrorReport As Boolean = False

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
        Protected m_cnnLockedTransaction As SqlConnection                    ' Connection used for Locked REFERENCE files.

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_trnTransaction As SqlTransaction           ' Transaction object to which file can be linked.

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
        Protected m_trnLockedTransaction As SqlTransaction           ' Transaction object to which a locked file can be linked.

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Private m_drdDataReader As SqlDataReader             ' Read-only recordset object used for REFERENCE files.

        '<NonSerialized()> _
        'Public GetRecordBuffer As Getter

        '<NonSerialized()> _
        'Public SetRecordBuffer As Setter

        '' Events.
        'Public Event Access(ByRef AccessClause As String)
        'Public Event SelectIf(ByRef SelectIfClause As String)
        'Public Event InitializeItems(ByVal Fixed As Boolean)
        'Public Event SetItemFinals()
        'Public Event Cursor(ByRef SQLStatement As String)
        'Public Event Balance(ByVal Field As String, ByVal Value As Decimal)
        'Public Event SumInto(ByVal Field As String, ByVal Value As Decimal, ByVal OldValue As Decimal)

        'Public Event GoToRecordEvent(ByVal Sender As Object, ByVal EventArgs As Object, ByVal NewRecordPosition As Integer)
        'Public Event AddRecordEvent(ByVal Sender As Object, ByVal EventArgs As Object, ByVal NewRecordPosition As Integer, ByVal IsGridNew As Boolean)
        'Public Event DeleteRecordEvent(ByVal Sender As Object, ByVal EventArgs As Object, ByVal NewRecordPosition As Integer)
        'Public Event EditRecordEvent(ByVal Sender As Object, ByVal EventArgs As Object, ByVal NewRecordPosition As Integer)

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

        ''' --- m_blnIsView ------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnIsView.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_blnIsView As Boolean = False

        Protected m_IsSubFileKeep As Integer = -1
        Protected m_blnDidLock As Boolean = False

#End Region

#Region "Constructor and Destructor"

        ''' --- New ----------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of New.
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
        ''' 	Summary of New.
        ''' </summary>
        ''' <param name="Type"></param>
        ''' <param name="Occurs"></param>
        ''' <param name="Owner"></param>
        ''' <param name="BaseName"></param>
        ''' <param name="AliasName"></param>
        ''' <param name="NoItems"></param>
        ''' <param name="NoAppend"></param>
        ''' <param name="NoDelete"></param>
        ''' <param name="Need"></param>
        ''' <param name="TransactionName"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
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
            'Using .dbo as the default table owner.
            MyBase.New(Type, Occurs, Owner, BaseName, AliasName, NoItems, NoAppend, NoDelete, Need, TransactionName, FileType)
            Me.Owner = GetObjectOwner(Owner)

            If FileType = FileType.TempFile Then IsTempTable = True
            If FileType = FileType.SubFile Then IsSubFile = True

            m_intProviderTypeOrdinal = 14 'Coordinal for SQL Server Provider Type is 14
            m_intClobValue = 18  ' Text (non-unicode) TODO: ntext (unicode)
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

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Property IsPortableSubFile() As Boolean
            Get
                Return m_IsPortableSubFile
            End Get
            Set(ByVal Value As Boolean)
                m_IsPortableSubFile = Value
            End Set
        End Property

        '--------------------------
        ' Connection property.
        '--------------------------
        ''' --- Connection ---------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Connection.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
        Description("sqlConnection objects to be used to perform operation with the underlying data layer"),
        Category("Core"),
        DefaultValue(""),
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overrides Property Connection() As IDbConnection
            Get
                Return CType(m_cnnTransaction, IDbConnection)
            End Get
            Set(ByVal Value As IDbConnection)
                m_cnnTransaction = CType(Value, SqlConnection)
            End Set
        End Property

        '--------------------------
        ' Transaction property.
        '--------------------------
        ''' --- Transaction --------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Transaction.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
        Description("sqlTransaction used in transactional operations with the data layer"),
        Category("Core"),
        DefaultValue(""),
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overrides Property Transaction() As IDbTransaction
            Get
                Return CType(m_trnTransaction, IDbTransaction)
            End Get
            Set(ByVal Value As IDbTransaction)
                m_trnTransaction = CType(Value, SqlTransaction)
            End Set
        End Property

#End Region

#Region "Methods"

        ''' --- GetObjectOwner -----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetObjectOwner.
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Private Function GetObjectOwner(ByVal Name As String) As String

            Dim strObjectOwner As String

            If Not ObjectOwners Is Nothing AndAlso ObjectOwners.ContainsKey(Owner) Then
                strObjectOwner = ObjectOwners.Item(Owner).ToString
            Else
                strObjectOwner = "dbo"
            End If

            If SQLServerUseSchemas Then
                Return Name
            End If
            Return Name + "." + strObjectOwner

        End Function



        Public Overridable Function GetCachedSchemaDat() As DataTable

        End Function




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

            ' Shared Schema Cache for all file objects
            Try
                'dt = CType(CacheManager.GetCacheManager.Item(strOwner + m_strBaseName + "_SqlSchema"), DataTable)
                'dt = CType(HttpContext.Current.Cache.Item(strOwner + m_strBaseName + "_SqlSchema"), DataTable)
                cachedt = CType(ApplicationState.Current.cache.Item(strOwner + m_strBaseName + "_SqlSchema"), DataTable)

                If cachedt Is Nothing Then

                    If Me.m_IsSubFile And Me.Owner = "SEQUENTIAL" Then

                        cachedt = GetCachedSchemaDat()

                    Else



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

                                cachedt = SqlHelper.GetTableSchema(strConnectionString, CommandType.Text, ReturnSelectFromSQL(True))
                            ElseIf Not m_trnTransaction Is Nothing AndAlso Not m_blnHasLock Then
                                cachedt = SqlHelper.GetTableSchema(m_trnTransaction, CommandType.Text, ReturnSelectFromSQL(True))
                            ElseIf Not m_trnLockedTransaction Is Nothing AndAlso m_blnHasLock Then
                                cachedt = SqlHelper.GetTableSchema(m_trnLockedTransaction, CommandType.Text, ReturnSelectFromSQL(True))
                            Else
                                Dim blnWasClosed As Boolean = False
                                If m_cnnTransaction.State = ConnectionState.Closed Then
                                    blnWasClosed = True
                                    Me.OpHPBnection()
                                End If
                                dt = SqlHelper.GetTableSchema(m_cnnTransaction, CommandType.Text, ReturnSelectFromSQL(True))
                                If blnWasClosed Then
                                    Me.CloseConnection()
                                End If
                            End If

                            ' Clear any constraints.
                            cachedt.Constraints.Clear()

                            'Remove the ROWID column
                            If cachedt.Columns.Contains("ROWID") Then cachedt.Columns.Remove("ROWID")

                            ' Add the ROW_ID column to the columns collection.
                            If Me.IsTempTable OrElse Me.m_blnIsView Then
                                cachedt.Columns.Add("ROW_ID", System.Type.GetType("System.String"))
                            Else
                                cachedt.Columns.Add("ROW_ID", System.Type.GetType("System.Guid"))
                            End If
                        Else
                            cachedt = m_dtbDataTable
                        End If

                    End If

                    cachedt.Rows.Clear()

                    If AddRow Then
                        CreateNewRow(cachedt)
                    End If

                    'HttpContext.Current.Cache.Add(m_strBaseName, dt, Nothing, DateTime.Now.AddDays(1), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, OnRemove)
                    'HttpContext.Current.Cache.Add(strOwner + m_strBaseName + "_SqlSchema", dt, Nothing, DateTime.Now.AddDays(1), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, OnRemove)
                    'objCacheManager.CacheStorage.Add(m_strBaseName, dt)
                    If Not (ApplicationState.Current.cache.Contains(strOwner + m_strBaseName + "_SqlSchema")) Then
                        ApplicationState.Current.cache.Add(strOwner + m_strBaseName + "_SqlSchema", cachedt)
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

        Protected Overrides Sub ClearColumnJoinInfo()
            ' Must be overriden in derived class.
        End Sub

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
            Dim blnAddRecordToBuffer As Boolean = False
            Dim blnSingleFetch As Boolean = False
            Dim blnIsSequential As Boolean = False
            Dim blnGetOverrideSQL As Boolean = False
            Dim blnHasOverrideSQL As Boolean
            Dim intTotalRecordsFound As Integer
            Dim blnSubFileKeepText As Boolean = False
            Dim blnSubFileKeepSQL As Boolean = False
            Dim strWholeWhereCondition As String
            Dim strOrderByClauseForSQL As String
            Dim objSqlParameters() As SqlParameter
            Dim blnIsInFindOrDetailFind As Boolean
            Dim blnWriteQtpRecord As Boolean = False
            Dim tmpSQL As String = String.Empty
            Dim blnElementDiff As Boolean = False

            Try

                IsSubFileKeep()
                If m_IsSubFileKeep = 1 Then
                    blnSubFileKeepText = True
                ElseIf m_IsSubFileKeep = 2 Then
                    blnSubFileKeepSQL = True
                End If


                If IsQTP Then

                    ClearColumnJoinInfo()

                    Dim strWhereTable As String
                    If Me.AliasName = "" Then
                        strWhereTable = Me.BaseName
                    Else
                        strWhereTable = Me.AliasName
                    End If

                    If UseMemory AndAlso Not m_blnFirstFile AndAlso Not SortPhase AndAlso strSQLWhere.Length = 0 Then

                        For i As Integer = 0 To WhereColumn.Count - 1

                            'Commented out line of code as it was droping columns from the Where clause if WhereColumn had
                            'more than two columns.
                            'If i = 2 Then Exit For

                            If (WhereClause.IndexOf(WhereColumn(i).ToString.Split(CType("~", Char))(1) & " =") >= 0 _
                            OrElse (WhereColumn(i).ToString.Split(CType("~", Char)).Length = 3 AndAlso WhereClause.IndexOf(WhereColumn(i).ToString.Split(CType("~", Char))(2) & " =") >= 0)) _
                            AndAlso FileWhere.ContainsKey(WhereColumn(i).ToString.Split(CType("~", Char))(0)) Then

                                If WhereColumn(i).ToString.Split(CType("~", Char)).Length = 3 Then
                                    If WhereColumn(i).ToString.Split(CType("~", Char))(1) <> WhereColumn(i).ToString.Split(CType("~", Char))(2) Then
                                        blnElementDiff = True
                                    End If

                                    If WhereColumn(i).ToString.Split(CType("~", Char))(1).IndexOf(WhereColumn(i).ToString.Split(CType("~", Char))(2)) >= 0 Then
                                        blnElementDiff = False
                                    End If

                                    If WhereColumn(i).ToString.Split(CType("~", Char))(2).IndexOf(WhereColumn(i).ToString.Split(CType("~", Char))(1)) >= 0 Then
                                        blnElementDiff = False
                                    End If

                                End If

                                If Not blnElementDiff Then

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
                            End If






                        Next


                        If strSQLWhere.Length = 0 Then
                            UseMemory = False
                        End If



                    End If


                    'If SortPhase Then
                    m_arrOutPutColumns = New ArrayList
                    m_arrOutPutValues = New ArrayList
                    Dim arrWhere() As String = ReplaceSqlVerb(WhereClause.ToUpper.Replace("WHERE ", ""), " AND ", cReplaceChar).Split(CType(cReplaceChar, String))
                    Dim strWhereColumn As String
                    Dim strWhereValue As String


                    For i As Integer = 0 To arrWhere.Length - 1

                        If arrWhere(i).IndexOf("=") >= 0 Then
                            If arrWhere(i).Split(CType("=", Char))(0).IndexOf(strWhereTable) >= 0 Then
                                strWhereColumn = arrWhere(i).Split(CType("=", Char))(0).ToString.Trim
                                If strWhereColumn.IndexOf(", " & strWhereTable & ".") >= 0 Then
                                    strWhereColumn = strWhereColumn.Substring(strWhereColumn.LastIndexOf(", " & strWhereTable & ".") + strWhereTable.Length + 3)
                                Else
                                    strWhereColumn = strWhereColumn.Substring(strWhereColumn.LastIndexOf("." & strWhereTable & ".") + strWhereTable.Length + 2)
                                End If
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
                                If strWhereColumn.IndexOf(", " & strWhereTable & ".") >= 0 Then
                                    strWhereColumn = strWhereColumn.Substring(strWhereColumn.LastIndexOf(", " & strWhereTable & ".") + strWhereTable.Length + 3)
                                Else
                                    strWhereColumn = strWhereColumn.Substring(strWhereColumn.LastIndexOf("." & strWhereTable & ".") + strWhereTable.Length + 2)
                                End If
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
                            If strWhereColumn.IndexOf(", " & strWhereTable & ".") >= 0 Then
                                strWhereColumn = strWhereColumn.Substring(strWhereColumn.LastIndexOf(", " & strWhereTable & ".") + strWhereTable.Length + 3)
                            Else
                                strWhereColumn = strWhereColumn.Substring(strWhereColumn.LastIndexOf("." & strWhereTable & ".") + strWhereTable.Length + 2)
                            End If
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

                ElseIf m_blnFor AndAlso blnIsInFindOrDetailFind Then
                    'If GetData is called from "For" Loop (Primary/Detail) and if 
                    'GetDataInternal has already been executed, then there is
                    'no need to Call GetDataInternal as the first call in 
                    'Iteration retrieve all the matching records
                    If m_blnGetDataFor Then
                        m_blnGetDataFor = False
                    Else
                        If HasRecordsToProcessFor(RecordsToFill) Then
                            Return True
                        Else
                            'Continue calling GetDataInternal
                        End If
                        'SetAccessOkOnPage(True)
                        'Return True
                    End If
                End If

                blnIsOptional = ((GetDataBehaviour And GetDataOptions.IsOptional) <> GetDataOptions.None)
                blnAddRecordToBuffer = ((GetDataBehaviour And GetDataOptions.AddRecordToBuffer) <> GetDataOptions.None)
                blnIsSequential = ((GetDataBehaviour And GetDataOptions.Sequential) <> GetDataOptions.None)
                blnGetOverrideSQL = ((GetDataBehaviour And GetDataOptions.CreateSubSelect) <> GetDataOptions.None)
                blnHasOverrideSQL = OverrideSQL.Trim <> String.Empty

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
                        If intSortOrder = 0 OrElse m_blnOutPutOutGet OrElse IsNothing(m_dtbDataTable) OrElse m_dtbDataTable.Rows.Count = 0 Then
                            blnAddRecordToBuffer = False
                            m_blnOutGet = False
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

                If intTotalRecordsFound > 0 Then
                    HasData = True
                Else
                    HasData = False
                End If

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
                    If IsQTP Then
                        If Not blnSubFileKeepText AndAlso Not IsQuiz Then
                            If IsQuiz Then
                                OverrideSQL = OverrideSQL.Replace(" FROM ", ", " & Me.RecordIdentifier & " ROW_ID FROM ")
                            Else
                                OverrideSQL = OverrideSQL.Replace(" FROM ", ", " & Me.RecordIdentifier & " ROW_ID, CHECKSUM_VALUE FROM ")
                            End If

                        End If
                        strSQL.Append(OverrideSQL)
                        ' Add the SelectIf code.  Add the WHERE or the AND
                        ' depending on the current SQL statement.


                        If WhereClause = "" And blnIsSequential = True And strSelectIf <> "" Then
                            strSQL.Append(" WHERE ")
                            strSQL.Append(strSelectIf)
                            strSQL.Append(" ").Append(OrderByClause)
                        ElseIf WhereClause <> "" And strSelectIf = "" Then
                            strSQL.Append(WhereClause)
                            strSQL.Append(" ").Append(OrderByClause)
                        ElseIf WhereClause <> "" And strSelectIf <> "" Then
                            strSQL.Append(WhereClause)
                            strSQL.Append(" AND ")
                            strSQL.Append(strSelectIf)
                            strSQL.Append(" ").Append(OrderByClause)
                        ElseIf WhereClause = "" And strSelectIf <> "" Then
                            ' If an ORDER BY clause exists, remove it and add it to the end.
                            If strSQL.ToString.IndexOf(" WHERE ") > 0 Then
                                strSQL.Append(" AND ")
                                strSQL.Append(strSelectIf)
                            Else
                                strSQL.Append(" WHERE ")
                                strSQL.Append(strSelectIf)
                            End If
                            strSQL.Append(" ").Append(OrderByClause)
                        End If

                    Else
                        If blnGetOverrideSQL Then
                            If OverrideSQL.ToUpper.IndexOf(" WHERE ") > -1 Then
                                WhereClause = OverrideSQL.Substring(OverrideSQL.ToUpper.IndexOf(" WHERE "))
                                OverrideSQL = OverrideSQL.Substring(0, OverrideSQL.ToUpper.IndexOf(" WHERE "))

                                If WhereClause.ToUpper.IndexOf(" ORDER BY ") > -1 Then
                                    OrderByClause = WhereClause.Substring(WhereClause.ToUpper.IndexOf(" ORDER BY "))
                                    WhereClause = WhereClause.Substring(0, WhereClause.ToUpper.IndexOf(" ORDER BY "))
                                End If
                            ElseIf OverrideSQL.ToUpper.IndexOf(" ORDER BY ") > -1 Then
                                OrderByClause = OverrideSQL.Substring(OverrideSQL.ToUpper.IndexOf(" ORDER BY "))
                                OverrideSQL = OverrideSQL.Substring(0, OverrideSQL.ToUpper.IndexOf(" ORDER BY "))
                            End If

                            If OrderByClause.Length > 0 Then
                                Dim strOverrideSQL As New StringBuilder(OverrideSQL)
                                Dim strAccessClause As String = String.Empty
                                Me.GetOverrideSQL(strOverrideSQL, WhereClause, strSelectIf, strAccessClause, OrderByClause, strWholeWhereCondition, RecordsToFill, True)
                                OverrideSQL = strOverrideSQL.ToString
                            End If
                        End If
                        strSQL.Append(OverrideSQL)
                    End If
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
                    WhereClause = strWholeWhereCondition
                    strOrderByClauseForSQL = OrderByClause

                    strSQL.Append(strOverrideSQL)
                    If OrderByClause.Length = 0 Then
                        objSqlParameters = Me.GetSQLParameters(blnHasOverrideSQL, WhereClause, OrderByClause, RecordsToFill)
                    End If
                Else
                    Dim w As Integer
                    Dim o As Integer
                    If m_intType = FileTypes.Cursor Then
                        strSQL.Append(GetCursorStatement())
                        blnHasOverrideSQL = True
                    Else
                        'If Type = FileTypes.Reference Then
                        ' Retrieve the SELECT ... FROM SQL.
                        strSQL.Append(ReturnSelectFromSQL())
                        'End If

                        ' If no WHERE clause is passed in, then get the 
                        ' resultset using the DEFAULT ACCESS statement,
                        ' otherwise use the WhereClause passed in.
                        If WhereClause = "" Then
                            If blnIsSequential = False AndAlso Type <> FileTypes.Primary Then
                                Dim strAccessClause As String
                                strAccessClause = GetAccessClause()
                                If Not blnIsOptional Then blnIsOptional = m_blnAccessIsOptional ' Optional specified on the Access statement.
                                w = strAccessClause.ToUpper.IndexOf(" WHERE ")
                                o = strAccessClause.ToUpper.IndexOf(" ORDER BY ")
                                If o >= 0 Then
                                    If OrderByClause.Length = 0 Then
                                        OrderByClause = strAccessClause.Substring(o)
                                    End If
                                    strAccessClause = strAccessClause.Substring(0, o)
                                End If

                                If w >= 0 Then
                                    If WhereClause.Length = 0 Then
                                        WhereClause = strAccessClause.Substring(w)
                                    End If
                                    strAccessClause = strAccessClause.Substring(0, w)
                                End If

                                If m_intType = FileTypes.Reference AndAlso WhereClause.Length = 0 Then
                                    WhereClause = " WHERE 1=0 "
                                End If

                            End If
                        End If


                        With strSQL
                            If WhereClause.Trim.Length > 0 Then
                                .Append(" ")
                                .Append(WhereClause.Replace("Temporary Data.", ""))
                            End If
                            If OrderByClause.Trim.Length > 0 AndAlso strSelectIf = "" Then
                                .Append(" ")
                                .Append(OrderByClause.Replace("Temporary Data.", ""))
                            End If
                        End With

                        ' Add the SelectIf code.  Add the WHERE or the AND
                        ' depending on the current SQL statement.
                        If WhereClause = "" And blnIsSequential = True And strSelectIf <> "" Then
                            strSQL.Append(" WHERE ")
                            strSQL.Append(strSelectIf)
                        ElseIf WhereClause <> "" And strSelectIf <> "" Then
                            strSQL.Append(" AND ")
                            strSQL.Append(strSelectIf)
                            If OrderByClause.Trim.Length > 0 Then
                                strSQL.Append(" ")
                                strSQL.Append(OrderByClause)
                            End If
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

                '' Uncomment following to Generate Parameters passed Stored Procedure
                'Dim objParam As sqlParameter
                'For Each objParam In prmFields
                '    Debug.Write(objParam.sqlType)
                '    Debug.Write(vbTab)
                '    Debug.Write(objParam.Size)
                '    Debug.Write(vbTab)
                '    Debug.Write(objParam.ParameterName)
                '    Debug.Write(vbTab)
                '    Debug.WriteLine(objParam.Value)
                'Next
                m_strSQL = strSQL.ToString

                If Not IsQTP Then
                    m_blnCountIntoCalled(Me.CurrentRow) = False
                End If

                ' Return the resultset.
                ' If REFERENCE file
                If m_intType = FileTypes.Reference Then
                    Dim blnIsConnectionClosed As Boolean = False

                    ' Open the Connection.
                    If m_cnnTransaction Is Nothing Then
                        m_dtbDataTable = SqlHelper.ExecuteDataTable(m_trnTransaction, CommandType.Text, strSQL.ToString)
                    Else
                        With m_cnnTransaction
                            If .State = ConnectionState.Closed Then
                                blnIsConnectionClosed = True
                                .Open()
                            End If
                        End With

                        m_dtbDataTable = SqlHelper.ExecuteDataTable(m_cnnTransaction, CommandType.Text, strSQL.ToString)
                    End If

                    'Remove the ROWID column
                    If m_dtbDataTable.Columns.Contains("ROWID") Then m_dtbDataTable.Columns.Remove("ROWID")

                    ' Get the column information.
                    If m_cnnTransaction Is Nothing Then
                        GetMetaData(Nothing, m_trnTransaction)
                    Else
                        GetMetaData(m_cnnTransaction, Nothing)
                    End If

                    If blnIsConnectionClosed Then
                        m_cnnTransaction.Close()
                    End If

                    m_blnEOF = (m_dtbDataTable.Rows.Count <= 0)

                    ' Set AccessOK.
                    blnAccessOK = Not m_blnEOF

                    'Added primarily for Grid
                    HasData = blnAccessOK

                    ' Save the last SQL for REFERENCE files.
                    m_strQTPLastSQL = m_strLastSQL
                    m_strLastSQL = strSQL.ToString

                    ' Set NewRecord flag depending on EOF status.
                    If Not m_blnEOF Then
                        m_blnNewRecord(Me.CurrentRow) = False
                    Else
                        If Not Me.PageMode = PageModeTypes.Find Then
                            m_blnNewRecord(Me.CurrentRow) = True
                        End If

                        ' Generate an error if not an OPTIONAL fetch.
                        If Not blnIsOptional Then
                            ' If we are getting a reference file that occurs with a file that has no
                            ' record in the current occurrence, don't throw the error.
                            If Not m_OccursWith Is Nothing AndAlso Not m_OccursWith.NewRecord AndAlso m_OccursWith.RecordLocation.Trim = String.Empty Then
                                Return False
                            Else

                                If Thread.CurrentThread.CurrentCulture.ToString.StartsWith("fr") Then
                                    AddMessage("Pas sur le fichier de recherche ({0}).", MessageTypes.Error, Me.ReturnRelation) 'IM.NoRecordsReference
                                Else
                                    AddMessage("Not on lookup file ({0}).", MessageTypes.Error, Me.ReturnRelation) 'IM.NoRecordsReference
                                End If
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

                    If Not m_IsTempTable AndAlso blnSubFileKeepText And IsKeepText Then

                        If IsNothing(tmpDataTable) Then
                            tmpDataTable = GetTextTable(strSQL.ToString)

                            If m_blnFirstFile Then
                                FirstFileCount = tmpDataTable.Rows.Count
                            End If

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

                        End If


                        If strSelectIf.Length > 0 Then
                            If WhereClause = "" And strSelectIf <> "" Then
                                WhereClause = " WHERE " & strSelectIf
                            ElseIf strSelectIf <> "" Then
                                WhereClause = WhereClause & " and " & strSelectIf
                            End If
                        End If

                        If blnAddRecordToBuffer Then
                            dt = GetDataTempTable(WhereClause, OrderByClause, , , m_trnTransaction)
                            'Remove the ROWID column
                            If dt.Columns.Contains(Me.RecordIdentifier) Then
                                dt.Columns.Remove(Me.RecordIdentifier)
                            End If
                        Else
                            If Not IsQTP AndAlso m_IsSubFile AndAlso m_intType = FileTypes.Primary Then
                                Dim reccount = Occurs
                                If reccount = 0
                                    reccount = 1
                                End If
                                m_dtbDataTable = GetDataTempTable(WhereClause, OrderByClause, CurrentRecordPosition, reccount , m_trnTransaction)                         
                 

                            Else
                                m_dtbDataTable = GetDataTempTable(WhereClause, OrderByClause, , , m_trnTransaction)
                            End If
                           
                            'Remove the ROWID column
                            If m_dtbDataTable.Columns.Contains(Me.RecordIdentifier) Then
                                m_dtbDataTable.Columns.Remove(Me.RecordIdentifier)
                            End If
                        End If


                    ElseIf m_IsTempTable OrElse (m_IsSubFile AndAlso Not blnSubFileKeepSQL) OrElse Not IsNothing(tmpDataTable) Then

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
                                dt = GetDataTempTable(WhereClause, OrderByClause, , , m_trnTransaction)
                                'Remove the ROWID column
                                If dt.Columns.Contains("ROWID") Then dt.Columns.Remove("ROWID")
                            Else
                                m_dtbDataTable = GetDataTempTable(WhereClause, OrderByClause, , , m_trnTransaction)
                                'Remove the ROWID column
                                If m_dtbDataTable.Columns.Contains("ROWID") Then m_dtbDataTable.Columns.Remove("ROWID")
                            End If
                        End If
                    Else
                        If m_cnnTransaction Is Nothing Then

                            ' Fetching this record and add it to the current recordbuffer,
                            ' otherwise do a normal GET.
                            If m_blnHasLock Then
                                If blnAddRecordToBuffer Then
                                    If blnHasOverrideSQL Then
                                        dt = SqlHelper.ExecuteDataTable(m_trnLockedTransaction, CommandType.Text, strSQL.ToString)
                                    Else
                                        If m_blnUsePutProcedures Then
                                            ' Execute the Get...Records Stored procedure.
                                            dt = SqlHelper.ExecuteDataTable(m_trnLockedTransaction, CommandType.StoredProcedure, "Get" + GetBriefName(m_strBaseName) + "Records", objSqlParameters)
                                        Else
                                            ' Execute the SQL Statement that gets the Records
                                            dt = SqlHelper.ExecuteDataTable(m_trnLockedTransaction, CommandType.Text, strSQL.ToString, objSqlParameters)
                                        End If
                                    End If

                                    'Remove the ROWID column
                                    If dt.Columns.Contains("ROWID") Then dt.Columns.Remove("ROWID")
                                Else
                                    If blnHasOverrideSQL Then
                                        m_dtbDataTable = SqlHelper.ExecuteDataTable(m_trnLockedTransaction, CommandType.Text, strSQL.ToString)
                                    Else
                                        If m_blnUsePutProcedures Then
                                            ' Execute the Get...Records Stored procedure.
                                            m_dtbDataTable = SqlHelper.ExecuteDataTable(m_trnLockedTransaction, CommandType.StoredProcedure, "Get" + GetBriefName(m_strBaseName) + "Records", objSqlParameters)
                                        Else
                                            ' Execute the SQL Statement that gets the Records
                                            m_dtbDataTable = SqlHelper.ExecuteDataTable(m_trnLockedTransaction, CommandType.Text, strSQL.ToString, objSqlParameters)
                                        End If
                                    End If

                                    'Remove the ROWID column
                                    If m_dtbDataTable.Columns.Contains("ROWID") Then m_dtbDataTable.Columns.Remove("ROWID")
                                End If
                                GetMetaData(Nothing, m_trnLockedTransaction)
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
                                        tmpDataTable = SqlHelper.ExecuteDataTable(m_trnTransaction, CommandType.Text, tmpSQL)
                                        If tmpDataTable.Rows.Count = 0 Then m_blnNoTempRecords = True

                                        If blnElementDiff AndAlso tmpDataTable.Rows.Count = 0 AndAlso tmpSQL.IndexOf(" WHERE ") > 0 Then
                                            tmpSQL = tmpSQL.Substring(0, tmpSQL.IndexOf(" WHERE "))
                                            tmpDataTable = SqlHelper.ExecuteDataTable(m_trnTransaction, CommandType.Text, tmpSQL)
                                            If tmpDataTable.Rows.Count = 0 Then m_blnNoTempRecords = True
                                        End If

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
                                        If dt.Columns.Contains("ROWID") Then dt.Columns.Remove("ROWID")
                                    Else
                                        If blnHasOverrideSQL Then
                                            dt = SqlHelper.ExecuteDataTable(m_trnTransaction, CommandType.Text, strSQL.ToString)
                                        Else
                                            If m_blnUsePutProcedures Then
                                                ' Execute the Get...Records Stored procedure.
                                                dt = SqlHelper.ExecuteDataTable(m_trnTransaction, CommandType.StoredProcedure, "Get" + GetBriefName(m_strBaseName) + "Records", objSqlParameters)
                                            Else
                                                ' Execute the SQL Statement that gets the Records
                                                dt = SqlHelper.ExecuteDataTable(m_trnTransaction, CommandType.Text, strSQL.ToString, objSqlParameters)
                                            End If
                                        End If

                                        'Remove the ROWID column
                                        If dt.Columns.Contains("ROWID") Then dt.Columns.Remove("ROWID")
                                    End If



                                Else
                                    If IsQTP AndAlso Not m_blnFirstFile AndAlso Not SortPhase AndAlso UseMemory Then
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
                                        tmpDataTable = SqlHelper.ExecuteDataTable(m_trnTransaction, CommandType.Text, tmpSQL)
                                        If tmpDataTable.Rows.Count = 0 Then m_blnNoTempRecords = True

                                        If blnElementDiff AndAlso tmpDataTable.Rows.Count = 0 AndAlso tmpSQL.IndexOf(" WHERE ") > 0 Then
                                            tmpSQL = tmpSQL.Substring(0, tmpSQL.IndexOf(" WHERE "))
                                            tmpDataTable = SqlHelper.ExecuteDataTable(m_trnTransaction, CommandType.Text, tmpSQL)
                                            If tmpDataTable.Rows.Count = 0 Then m_blnNoTempRecords = True
                                        End If

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
                                        If m_dtbDataTable.Columns.Contains("ROWID") Then m_dtbDataTable.Columns.Remove("ROWID")
                                    Else
                                        If blnHasOverrideSQL Then

                                            m_dtbDataTable = SqlHelper.ExecuteDataTable(m_trnTransaction, CommandType.Text, strSQL.ToString)
                                        Else
                                            If m_blnUsePutProcedures Then
                                                ' Execute the Get...Records Stored procedure.
                                                m_dtbDataTable = SqlHelper.ExecuteDataTable(m_trnTransaction, CommandType.StoredProcedure, "Get" + GetBriefName(m_strBaseName) + "Records", objSqlParameters)
                                            Else
                                                ' Execute the SQL Statement that gets the Records
                                                m_dtbDataTable = SqlHelper.ExecuteDataTable(m_trnTransaction, CommandType.Text, strSQL.ToString, objSqlParameters)
                                            End If
                                        End If

                                        'Remove the ROWID column
                                        If m_dtbDataTable.Columns.Contains("ROWID") Then m_dtbDataTable.Columns.Remove("ROWID")
                                    End If
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
                                    If blnHasOverrideSQL Then
                                        dt = SqlHelper.ExecuteDataTable(m_trnLockedTransaction, CommandType.Text, strSQL.ToString)
                                    Else
                                        If m_blnUsePutProcedures Then
                                            ' Execute the Get...Records Stored procedure.
                                            dt = SqlHelper.ExecuteDataTable(m_trnLockedTransaction, CommandType.StoredProcedure, "Get" + GetBriefName(m_strBaseName) + "Records", objSqlParameters)
                                        Else
                                            ' Execute the SQL Statement that gets the Records
                                            dt = SqlHelper.ExecuteDataTable(m_trnLockedTransaction, CommandType.Text, strSQL.ToString, objSqlParameters)
                                        End If
                                    End If

                                    'Remove the ROWID column
                                    If dt.Columns.Contains("ROWID") Then dt.Columns.Remove("ROWID")
                                Else
                                    If blnHasOverrideSQL Then
                                        m_dtbDataTable = SqlHelper.ExecuteDataTable(m_trnLockedTransaction, CommandType.Text, strSQL.ToString)
                                    Else
                                        If m_blnUsePutProcedures Then
                                            ' Execute the Get...Records Stored procedure.
                                            m_dtbDataTable = SqlHelper.ExecuteDataTable(m_trnLockedTransaction, CommandType.StoredProcedure, "Get" + GetBriefName(m_strBaseName) + "Records", objSqlParameters)
                                        Else
                                            ' Execute the SQL Statement that gets the Records
                                            m_dtbDataTable = SqlHelper.ExecuteDataTable(m_trnLockedTransaction, CommandType.Text, strSQL.ToString, objSqlParameters)
                                        End If
                                    End If

                                    'Remove the ROWID column
                                    If m_dtbDataTable.Columns.Contains("ROWID") Then m_dtbDataTable.Columns.Remove("ROWID")
                                End If

                                GetMetaData(Nothing, m_trnLockedTransaction)
                            Else
                                If blnAddRecordToBuffer Then
                                    If blnHasOverrideSQL Then
                                        dt = SqlHelper.ExecuteDataTable(m_cnnTransaction, CommandType.Text, strSQL.ToString)
                                    Else
                                        If m_blnUsePutProcedures Then
                                            ' Execute the Get...Records Stored procedure.
                                            dt = SqlHelper.ExecuteDataTable(m_cnnTransaction, CommandType.StoredProcedure, "Get" + GetBriefName(m_strBaseName) + "Records", objSqlParameters)
                                        Else
                                            ' Execute the SQL Statement that gets the Records
                                            dt = SqlHelper.ExecuteDataTable(m_cnnTransaction, CommandType.Text, strSQL.ToString, objSqlParameters)
                                        End If
                                    End If

                                    'Remove the ROWID column
                                    If dt.Columns.Contains("ROWID") Then dt.Columns.Remove("ROWID")
                                Else
                                    If blnHasOverrideSQL Then
                                        m_dtbDataTable = SqlHelper.ExecuteDataTable(m_cnnTransaction, CommandType.Text, strSQL.ToString)
                                    Else
                                        If m_blnUsePutProcedures Then
                                            ' Execute the Get...Records Stored procedure.
                                            m_dtbDataTable = SqlHelper.ExecuteDataTable(m_cnnTransaction, CommandType.StoredProcedure, "Get" + GetBriefName(m_strBaseName) + "Records", objSqlParameters)
                                        Else
                                            ' Execute the SQL Statement that gets the Records
                                            m_dtbDataTable = SqlHelper.ExecuteDataTable(m_cnnTransaction, CommandType.Text, strSQL.ToString, objSqlParameters)
                                        End If
                                    End If

                                    'Remove the ROWID column
                                    If m_dtbDataTable.Columns.Contains("ROWID") Then m_dtbDataTable.Columns.Remove("ROWID")
                                End If

                                GetMetaData(m_cnnTransaction, Nothing)
                            End If

                            If blnWasClosed Then
                                Me.CloseConnection()
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
                            If Me.IsTempTable OrElse (Me.IsSubFile AndAlso m_IsSubFileKeep < 2) Then
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

                    If m_strLastSQL <> strSQL.ToString AndAlso Not m_blnCreateBlankRow Then
                        blnWriteQtpRecord = True
                    End If
                    m_strQTPLastSQL = m_strLastSQL
                    m_strLastSQL = strSQL.ToString

                    ' If we are performing a normal GET, set the first
                    ' record as the current record.
                    If blnAddRecordToBuffer Then

                        'For intRow As Integer = 0 To dt.Rows.Count - 1
                        '    If m_dtbDataTable.Select("ROW_ID = '" & dt.Rows(intRow).Item("ROW_ID").ToString & "'").Length <> 0
                        '       dt.Rows.RemoveAt(intRow)
                        '       intRow = intRow -1

                        '       If intRow = -1
                        '           Exit For 
                        '       End If
                        '     End If
                        'Next

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

                        Else
                            Dim intCurrentRow As Integer

                            intCurrentRow = Me.CurrentRow

                            ' Set AccessOK.
                            blnAccessOK = False

                            'Added primarily for Grid
                            HasData = False

                            blnQTPInit = True

                            If IsQTP AndAlso intCurrentRow > m_blnNewRecord.Length - 1 Then
                                ReDim Preserve m_blnNewRecord(intCurrentRow)
                                ReDim Preserve m_blnAlteredRecord(intCurrentRow)
                                ReDim Preserve m_blnDeletedRecord(intCurrentRow)
                                ReDim Preserve m_blnGridDeletedRecord(intCurrentRow)
                                ReDim Preserve m_blnIsInitialized(intCurrentRow)
                                ReDim Preserve m_blnCountIntoCalled(intCurrentRow)
                            End If

                            ' Added condition for a secondary occurs with a file, then set the New record status.
                            If (Not Me.PageMode = PageModeTypes.Find) OrElse (Me.Type = FileTypes.Secondary AndAlso m_blnOccursWith) Then
                                m_blnNewRecord(intCurrentRow) = True
                            End If
                            AlteredRecord(intCurrentRow) = False
                            m_blnDeletedRecord(intCurrentRow) = False
                            m_blnGridDeletedRecord(intCurrentRow) = False

                            If IsQTP AndAlso dt.Rows.Count = 0 Then
                                m_blnNewRecord(intCurrentRow) = False
                            End If

                            ' Generate an error if not and OPTIONAL fetch.
                            If Not blnIsOptional Then
                                If Me.PageMode = PageModeTypes.Entry Then
                                    If Thread.CurrentThread.CurrentCulture.ToString.StartsWith("fr") Then
                                        AddMessage("Pas sur le fichier de recherche ({0}).", MessageTypes.Error, Me.ReturnRelation) 'IM.NoRecordsReference
                                    Else
                                        AddMessage("Not on lookup file ({0}).", MessageTypes.Error, Me.ReturnRelation) 'IM.NoRecordsReference
                                    End If
                                Else
                                    If IsQTP Then
                                        intLastfound = 0
                                        QTPRecordsRead(Me.BaseName, Me.AliasName, 0, LogType.Read)
                                        NoRecords = True
                                    Else
                                        If Thread.CurrentThread.CurrentCulture.ToString.StartsWith("fr") Then
                                            ThrowCustomApplicationException("Aucun enregistrement trouvé.") 'IM.NoRecords
                                        Else
                                            ThrowCustomApplicationException("No Records Found.") 'IM.NoRecords
                                        End If

                                    End If
                                End If
                            End If
                        End If

                        If IsQTP Then

                            If m_blnOutPut AndAlso HasData Then
                                If m_strQTPLastSQL <> m_strLastSQL Then
                                    m_dtbDataTable = dt
                                End If
                            ElseIf HasData Then
                                Occurs = Occurs + dt.Rows.Count
                                NoRecords = False
                                ' Assign the new record to the existing record buffer.
                                AssignRecordToBuffer(dt)

                            End If

                            'added for the QTP log
                            If blnWriteQtpRecord OrElse Not SortPhase Then
                                If HasData Then
                                    QTPRecordsRead(Me.BaseName, Me.AliasName, dt.Rows.Count, LogType.Read)
                                Else
                                    QTPRecordsRead(Me.BaseName, Me.AliasName, 0, LogType.Read)
                                End If


                            End If

                        Else
                            AssignRecordToBuffer(dt, , HasData)
                        End If


                        If Not HasData Then
                            ' Set INITIAL values from the dictionary.
                            If Not IsQTP AndAlso IsNothing(System.Configuration.ConfigurationManager.AppSettings("NoDictionary")) Then
                                InitializeFromDictionary()
                            End If


                            If m_blnOutPut AndAlso m_strLastSQL <> m_strQTPLastSQL Then
                                If IsNothing(m_dtbDataTable) OrElse m_dtbDataTable.Rows.Count = 0 Then
                                    ' Create an empty record buffer.
                                    CreateEmptyStructure()
                                End If

                            ElseIf (IsQTP AndAlso blnIsOptional) OrElse (IsQTP AndAlso intSortOrder > 0) Then
                                AssignRecordToBuffer(dt, , HasData)

                                If blnIsOptional Then
                                    NoRecords = False
                                End If
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
                            If IsQTP AndAlso Me.CurrentRow = 0 AndAlso (blnWriteQtpRecord OrElse Not SortPhase) Then

                                If HasData Then
                                    QTPRecordsRead(Me.BaseName, Me.AliasName, m_dtbDataTable.Rows.Count, LogType.Read)
                                Else
                                    QTPRecordsRead(Me.BaseName, Me.AliasName, 0, LogType.Read)
                                End If

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

                            blnQTPInit = True

                            ' Create an empty record buffer.
                            CreateEmptyStructure()

                            ' Generate an error if not and OPTIONAL fetch.
                            If Not blnIsOptional Then
                                If Me.PageMode = PageModeTypes.Entry Then

                                    If Thread.CurrentThread.CurrentCulture.ToString.StartsWith("fr") Then
                                        AddMessage("Pas sur le fichier de recherche ({0}).", MessageTypes.Error, Me.ReturnRelation) 'IM.NoRecordsReference
                                    Else
                                        AddMessage("Not on lookup file ({0}).", MessageTypes.Error, Me.ReturnRelation) 'IM.NoRecordsReference
                                    End If
                                Else
                                    If IsQTP Then
                                        intLastfound = 0
                                        QTPRecordsRead(Me.BaseName, Me.AliasName, 0, LogType.Read)
                                        NoRecords = True
                                    Else

                                        If Thread.CurrentThread.CurrentCulture.ToString.StartsWith("fr") Then
                                            ThrowCustomApplicationException("Aucun enregistrement trouvé.") 'IM.NoRecords
                                        Else
                                            ThrowCustomApplicationException("No Records Found.") 'IM.NoRecords
                                        End If
                                    End If
                                End If
                            End If

                            If IsQTP AndAlso blnIsOptional Then
                                NoRecords = False

                                QTPRecordsRead(Me.BaseName, Me.AliasName, 0, LogType.Read)

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

                If IsQTP Then
                    WhereColumn = Nothing
                    If m_blnFirstFile AndAlso m_dtbDataTable.Rows.Count > 99 AndAlso Not blnSubFileKeepText Then
                        UseMemory = True
                    End If
                    If m_dtbDataTable.Rows.Count >= m_blnNewRecord.Length - 1 Then
                        If m_blnFirstFile Then
                            FirstFileCount = m_dtbDataTable.Rows.Count
                            ReDim Preserve m_blnNewRecord(CInt(m_dtbDataTable.Rows.Count * 2))
                            ReDim Preserve m_blnAlteredRecord(CInt(m_dtbDataTable.Rows.Count * 2))
                            ReDim Preserve m_blnDeletedRecord(CInt(m_dtbDataTable.Rows.Count * 2))
                            ReDim Preserve m_blnGridDeletedRecord(CInt(m_dtbDataTable.Rows.Count * 2))
                            ReDim Preserve m_blnIsInitialized(CInt(m_dtbDataTable.Rows.Count * 2))
                            ReDim Preserve m_blnCountIntoCalled(CInt(m_dtbDataTable.Rows.Count * 2))
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

                Me.HasLastGetData = True
                'we need to set the current instance of FileObject on the base page
                'which is turn being used in AlteredRecord, DeletedRecord and NewRecord Method of
                'the Base Page
                SetLastFileObject()
                blnExists = blnAccessOK
                SetAccessOkOnPage(blnAccessOK)
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

            If Not IsSubFile AndAlso Owner <> "SEQUENTIAL" Then Return False

            If m_IsSubFileKeep = -1 Then

                If Owner <> "SEQUENTIAL" Then
                    Dim objReader As SqlDataReader
                    Dim strSQL As New System.Text.StringBuilder("")
                    Dim FileName As String

                    If Me.AliasName = "" Then
                        FileName = Me.BaseName
                    Else
                        FileName = Me.AliasName
                    End If


                    'If SubFileSchema() <> "" Then
                    '    strSQL.Append("select name From ")
                    '    strSQL.Append(SubFileSchema).Append(".dbo.")
                    '    strSQL.Append("sysobjects where xtype = 'U' and name = '")
                    '    strSQL.Append(Me.BaseName).Append("'")
                    'Else
                    strSQL.Append("select name From sysobjects where xtype = 'U' and name = '")
                    strSQL.Append(Me.BaseName).Append("'")
                    'End If

                    If IsNothing(m_trnTransaction) Then
                        objReader = SqlHelper.ExecuteReader(GetConnectionString, CommandType.Text, strSQL.ToString)
                    Else
                        objReader = SqlHelper.ExecuteReader(m_trnTransaction, CommandType.Text, strSQL.ToString)
                    End If


                    If objReader.Read Then
                        objReader.Close()
                        objReader = Nothing
                        m_IsSubFileKeep = 2
                        Return True
                    End If

                    objReader.Close()
                    objReader = Nothing
                End If



                If IsKeepText Then

                    If m_IsSubFileKeep = -1 Then

                        If IsKeepTextFile Then
                            m_IsSubFileKeep = 1
                            Return True
                        Else
                            m_IsSubFileKeep = 0
                            Return False
                        End If



                    ElseIf m_IsSubFileKeep = 0 Then
                        Return False

                    ElseIf m_IsSubFileKeep = 1 Then
                        Return True

                    End If

                Else
                    m_IsSubFileKeep = 0
                    Return False
                End If


            ElseIf m_IsSubFileKeep = 0 Then
                Return False

            ElseIf m_IsSubFileKeep = 1 Then
                Return True

            ElseIf m_IsSubFileKeep = 2 Then
                Return True

            End If





        End Function

        ''' --- SetSearchType ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of SetSearchType.
        ''' </summary>
        ''' <param name="SearchType"></param>
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
        Public Overridable Function GetDataTempTable(ByVal WhereClause As String, ByVal OrderByClause As String, Optional ByVal StartRow As Long = -1, Optional ByVal Count As Integer = -1, Optional ByVal trnTransaction As SqlTransaction = Nothing) As DataTable
            Return Nothing
        End Function

        ''' --- GetSQLParameters ---------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetSQLParameters.
        ''' </summary>
        ''' <param name="HasOverrideSQL"></param>
        ''' <param name="WhereClause"></param>
        ''' <param name="OrderByClause"></param>
        ''' <param name="RecordsToFill"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Private Function GetSQLParameters(ByVal HasOverrideSQL As Boolean, ByVal WhereClause As String, ByVal OrderByClause As String, ByRef RecordsToFill As Integer) As SqlParameter()
            Dim objSqlParameters(4) As SqlParameter

            If Not HasOverrideSQL Then
                'Dim intTotalRecordsProcessed As Integer
                Dim intStartRow As Long

                'Prepare "WhereClause" Parameter
                objSqlParameters(0) = New SqlParameter("@WhereClause", SqlDbType.VarChar, 3000)
                With objSqlParameters(0)
                    .Direction = ParameterDirection.Input
                    .Value = WhereClause
                End With

                ' Add the OrderByClause parameter.
                objSqlParameters(1) = New SqlParameter("@OrderByClause", SqlDbType.VarChar, 1000)
                With objSqlParameters(1)
                    .Direction = ParameterDirection.Input
                    .Value = OrderByClause
                End With

                ' Add the "RowCount" parameter.
                objSqlParameters(2) = New SqlParameter("@RowCount", SqlDbType.BigInt)
                With objSqlParameters(2)
                    .Direction = ParameterDirection.InputOutput
                    .Value = -1
                End With

                ' Add the "PageSize" parameter.
                objSqlParameters(3) = New SqlParameter("@PageSize", SqlDbType.Int)
                With objSqlParameters(3)
                    .Direction = ParameterDirection.Input
                    .Value = Me.TotalRecordsToRetrieve(RecordsToFill, intStartRow)
                    'Dim intRecordsToFill As Integer
                    'If RecordsToFill > 0 Then
                    '    If m_intRecordsToRetrieve > 0 Then
                    '        .Value = m_intRecordsToRetrieve
                    '    Else
                    '        intRecordsToFill = RecordsToFill
                    '        .Value = intRecordsToFill
                    '    End If
                    'Else
                    '    intRecordsToFill = Math.Max(Me.Occurs, 1)
                    '    .Value = intRecordsToFill
                    'End If

                    'If SkipRecordsWithError Then
                    '    'Only update TotalRecordsProcessed if we need to omit records with an error
                    '    intTotalRecordsProcessed = Me.TotalRecordsProcessed
                    '    intStartRow = intTotalRecordsProcessed + 1
                    '    If m_intRecordsToRetrieve <= 0 Then
                    '        intTotalRecordsProcessed += intRecordsToFill
                    '    End If
                    '    Me.TotalRecordsProcessed = intTotalRecordsProcessed
                    'End If
                End With

                ' Add the "StartRow" parameter.
                objSqlParameters(4) = New SqlParameter("@StartRow", SqlDbType.Int)
                With objSqlParameters(4)
                    .Direction = ParameterDirection.Input
                    If SkipRecordsWithError Then
                        'Only update TotalRecordsProcessed if we need to omit records with an error
                        .Value = intStartRow
                    Else
                        .Value = Math.Max(Me.m_intCurrentRecordPosition, 1)
                    End If

                    'If RecordsToFill > 0 Then
                    '    RecordsToFill = 0
                    '    m_intRecordsToFillInFindOrDetailFind = 0
                    'End If
                End With
            End If
            Return objSqlParameters
        End Function

        'Private Function GetRecordsSQL(ByVal SQLStatement As StringBuilder) As String
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
            With SQLStatement

                Dim strSQL As String = SQLStatement.ToString


                'If by chance SQL Statement contains anything remove it
                If .Length > 0 Then
                    .Remove(0, .Length)
                End If

                If OrderByClause.Length = 0 Then
                    'Start building the Procedure to get the Rows from SQL Server
                    .Append(" BEGIN")

                    If m_blnIsView Then
                        .Append("   DECLARE @RowID Varchar(500) ")
                        .Append("   DECLARE @tblTempRowID TABLE (RowID Varchar(500) NOT NULL PRIMARY KEY, Temp__ID int identity)")
                    Else
                        .Append("   DECLARE @RowID UNIQUEIDENTIFIER ")
                        .Append("   DECLARE @tblTempRowID TABLE (RowID UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, Temp__ID int identity)")
                    End If
                    '--Eliminate the sending message to the client for each statement
                    .Append("   SET NOCOUNT ON")
                    .Append("   EXECUTE('DECLARE PagingCursor CURSOR DYNAMIC READ_ONLY FOR SELECT ").Append(ElementOwner).Append("RowID FROM ").Append(Me.TableNameWithAlias).Append("  WITH (NOLOCK) ").Append("' + @WhereClause + @OrderByClause)")
                    .Append("   IF @StartRow <= 0 ")
                    .Append("   BEGIN ")
                    .Append("   SET @StartRow = 1")
                    .Append("   END")
                    .Append("   OPEN PagingCursor FETCH RELATIVE @StartRow FROM PagingCursor INTO @RowID")
                    .Append("   SET @RowCount = @@CURSOR_ROWS")
                    .Append("   WHILE @PageSize > 0 AND @@FETCH_STATUS = 0")
                    .Append("   BEGIN")
                    .Append("       INSERT @tblTempRowID(RowID) VALUES(@RowID)")
                    .Append("       FETCH NEXT FROM PagingCursor INTO @RowID")
                    .Append("       SET @PageSize = @PageSize - 1")
                    .Append("   END")
                    .Append("   CLOSE PagingCursor")
                    .Append("   DEALLOCATE PagingCursor")
                    .Append("   SELECT ").Append(Me.TableNameWithOwner).Append(".*").Append(", ").Append(Me.TableNameWithOwner).Append(".ROWID ROW_ID FROM ").Append(Me.TableNameWithOwner()).Append("  WITH (NOLOCK) ").Append(" JOIN @tblTempRowID temp ON ").Append(Me.TableNameWithOwner).Append(".ROWID = temp.RowID").Append(" ORDER BY TEMP.Temp__ID")
                    '--Reset NOCOUNT Option back to default i.e. OFF
                    .Append("   SET NOCOUNT OFF")
                    .Append(" END")

                Else

                    Dim strAlias As String = Me.AliasName
                    CurrentRecordPosition = Math.Max(Me.m_intCurrentRecordPosition, 1) - 1
                    SkippedRecords = CInt(Me.TotalRecordsToRetrieve(SkippedRecords, CurrentRecordPosition) + CurrentRecordPosition + 1)


                    If strSQL.Length > 0 Then

                        .Append("   SELECT * FROM ( ")
                        .Append("     ").Append(strSQL.Substring(0, strSQL.IndexOf(" FROM ")))

                        .Append("    ,   ROW_NUMBER()  OVER (").Append(OrderByClause).Append(", ")

                        If strAlias.Length = 0 Then
                            .Append(Me.TableNameWithOwner).Append(".ROWID) AS ROW_NUM ")
                            .Append(strSQL.Substring(strSQL.IndexOf(" FROM ")))
                        Else
                            .Append(strAlias).Append(".ROWID) AS ROW_NUM ")
                            .Append(strSQL.Substring(strSQL.IndexOf(" FROM ")))
                        End If

                        .Append("   ").Append(WhereClause)
                        .Append("   ) AS record ")
                        .Append("   WHERE ROW_NUM > ").Append(CurrentRecordPosition.ToString).Append(" and ROW_NUM < ").Append(SkippedRecords.ToString)

                    Else
                        .Append("   SELECT * FROM ( ")
                        .Append("     SELECT ")
                        .Append("       *, ROWID ROW_ID, ")
                        .Append("       ROW_NUMBER()  OVER (").Append(OrderByClause).Append(", ")
                        If strAlias.Length = 0 Then
                            .Append(Me.TableNameWithOwner).Append(".ROWID) AS ROW_NUM ")
                            .Append("     FROM ").Append(Me.TableNameWithOwner)
                        Else
                            .Append(strAlias).Append(".ROWID) AS ROW_NUM ")
                            .Append("     FROM ").Append(Me.TableNameWithOwner).Append(" ").Append(strAlias)
                        End If
                        .Append("   ").Append(WhereClause)
                        .Append("   ) AS record ")
                        .Append("   WHERE ROW_NUM > ").Append(CurrentRecordPosition.ToString).Append(" and ROW_NUM < ").Append(SkippedRecords.ToString)

                    End If



                End If

                Return .ToString
            End With
        End Function
        ''' --- GetTextTable ---------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetTextTable.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overridable Function GetTextTable(ByVal strSelect As String) As DataTable
            Return Nothing
        End Function

        ''' --- GetTextTableStructure ---------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetTextTableStructure.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overridable Function GetTextTableStructure() As DataTable
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
            GetMetaData(CType(Connection, SqlConnection), CType(Transaction, SqlTransaction))
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
        Protected Overloads Sub GetMetaData(ByRef cnn As SqlConnection, ByRef trn As SqlTransaction)
            Dim strOwner As String = m_strOwner + "_"
            If strOwner.Trim.Equals("_") Then strOwner = ""
            Dim OnRemove As System.Web.Caching.CacheItemRemovedCallback = Nothing

            If m_dtbMetaData Is Nothing Then
                ' Retrieve the metadata datatable from the CACHE.
                m_dtbMetaData = CType(ApplicationState.Current.cache(strOwner + m_strBaseName + "_SqlMetadata"), DataTable)
                'm_dtbMetaData = CType(HttpContext.Current.Cache.Item(strOwner + m_strBaseName + "_SqlMetadata"), DataTable)

                If m_dtbMetaData Is Nothing Then
                    Dim rdr As SqlDataReader
                    Dim strSQL As StringBuilder = New StringBuilder(ReturnSelectFromSQL(True))
                    strSQL.Append(" WHERE 0 = 1")

                    If cnn Is Nothing Then
                        rdr = SqlHelper.ExecuteReader(trn, CommandType.Text, strSQL.ToString, True)
                    Else
                        rdr = SqlHelper.ExecuteReader(cnn, CommandType.Text, strSQL.ToString)
                    End If
                    m_dtbMetaData = rdr.GetSchemaTable()

                    rdr.Close()

                    'Remove the "ROWID" column from the Schema Table
                    If Not m_dtbMetaData Is Nothing Then
                        With m_dtbMetaData
                            For intRow As Integer = 0 To m_dtbMetaData.Rows.Count - 1
                                If .Rows(intRow).Item(0).ToString.ToUpper.Equals("ROWID") Then
                                    .Rows(intRow).Delete()
                                    Exit For
                                End If
                            Next
                            .AcceptChanges()
                        End With
                    End If

                    ' Add the metadata datatable to the CACHE.
                    'CacheManager.CacheStorage.Add(m_strBaseName + "_SqlMetadata", m_dtbMetaData)
                    'HttpContext.Current.Cache.Add(strOwner + m_strBaseName + "_SqlMetadata", m_dtbMetaData, Nothing, DateTime.Now.AddDays(1), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, OnRemove)
                    ApplicationState.Current.cache.Add(strOwner + m_strBaseName + "_SqlMetadata", m_dtbMetaData)
                End If
            End If

        End Sub

        '-------------------------------------------------------------------
        ' Name: PutData
        ' Function: Emulates the PowerHouse PUT verb.
        ' Example: PutData(strRowId, strCheckSum)
        '-------------------------------------------------------------------
        ''' --- PutData ------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of PutData.
        ''' </summary>
        ''' <param name="Reset"></param>
        ''' <param name="PutType"></param>
        ''' <param name="At"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        ''' 
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
            PutData(Reset, PutType, -1)
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

                            strSQL.Append("DELETE ")
                            strSQL.Append(Me.TableNameWithOwner(False))
                            strSQL.Append(" FROM ")
                            strSQL.Append(Me.TableNameWithOwner(True))
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
                                    SqlHelper.ExecuteNonQuery(m_trnLockedTransaction, CommandType.Text, strSQL.ToString)
                                Else
                                    SqlHelper.ExecuteNonQuery(m_trnTransaction, CommandType.Text, strSQL.ToString)
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
                        And m_intNeed > 0 Then AlteredRecord(Me.CurrentRow) = True


                        ' Call the Initial Fixed and Final items for Old, Undeleted records or New, Altered, Undeleted records 
                        ' or for Audit files that are being Put through the PutAuditData event.
                        If (IsQTP AndAlso NewRecord) OrElse (Not DeletedRecord AndAlso ((Not NewRecord) OrElse (NewRecord AndAlso AlteredRecord))) OrElse (Me.Type = FileTypes.Audit AndAlso m_blnPutInitiatedFromOccursWithFile) Then

                            If Not IsQTP Then
                                ' Set the ITEM INITIAL values with the FIXED flag set to TRUE.
                                RaiseInitializeItems(True)
                            End If

                            If (blnQTPInit OrElse Not IsInitialized) AndAlso IsQTP AndAlso (NewRecord OrElse m_blnOutGet) Then

                                If GetStringValue("ROW_ID").Trim = "" Then
                                    m_blnNewRecord(Me.CurrentRow) = True
                                    m_blnAlteredRecord(Me.CurrentRow) = True

                                    ' Set the ITEM INITIAL values with the FIXED flag set to TRUE.
                                    RaiseInitializeItems(False)
                                End If

                            End If

                            ' Set the ITEM FINAL values.
                            RaiseSetItemFinals()
                        End If

                        ' If nothing has changed, return the ROWID and CHECKSUM values.
                        'If IsQTP Then
                        If Not m_blnAlteredRecord(Me.CurrentRow) AndAlso Not m_blnNewRecord(Me.CurrentRow) Then
                            If IsQTP Then
                                QTPRecordsRead(Me.BaseName, Me.AliasName, 1, LogType.UnChanged)
                            End If

                            Exit Sub
                        End If
                        'ElseIf Not m_blnAlteredRecord(Me.CurrentRow) Then
                        '    Exit Sub
                        'End If

                        ' Following code is to allow toggle delete in a Grid during Entry
                        If m_blnNewRecord(Me.CurrentRow) And m_blnDeletedRecord(Me.CurrentRow) Then
                            m_blnAlteredRecord(Me.CurrentRow) = False

                            If IsQTP Then
                                QTPRecordsRead(Me.BaseName, Me.AliasName, 1, LogType.UnChanged)
                            End If

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

                        If Me.IsTempTable Then
                            PutDataTempTable()
                        ElseIf (IsSubFile) Then
                            PutDataTextTable()
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
                        If Not IsNothing(m_dtbDataTable) Then m_dtbDataTable.Rows(Me.CurrentRow).AcceptChanges()

                        SaveReceivingParam()

                        ' Reset the record buffer and record status 
                        ' flags based on the RESET option.
                        If Reset Then
                            blnQTPInit = True
                            CallReset()
                        End If
                    End If
                End If

                If Not IsQTP Then
                    CountIntoCalled = False
                End If

            Catch ex As System.Data.SqlClient.SqlException

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

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

            ' To be overriden in SqlServerFileObject.

        End Sub
        ''' --- PutDataTextTable ---------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of PutDataTextTable.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overridable Function PutDataTextTable(Optional ByVal At As Integer = -1) As Boolean
            Return Nothing
        End Function

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
            ' Must be overriden in SQLServerFileObject.
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

            If IsNothing(m_dtbDataTable) Then Exit Sub

            Const intRecordsAffectedPosition As Integer = 0
            Const intCheckSumPosition As Integer = 1
            Const intRowIDPosition As Integer = 2

            Dim strRowID As String = m_dtbDataTable.Rows(Me.CurrentRow).Item("ROW_ID").ToString.TrimEnd
            Dim strSQL As StringBuilder = New StringBuilder(String.Empty)
            Dim prmFields(2) As SqlParameter
            Dim blnIsInsert As Boolean = False
            Dim strMessage As String = String.Empty
            Dim blnFirstColumn As Boolean = True
            Dim identityColumn As String = String.Empty

            ' Determine if we are deleting a record or not
            If m_blnDeletedRecord(Me.CurrentRow) Then
                ' Generate the DELETE statement.
                strSQL.Append("DELETE FROM ").Append(Me.TableNameWithOwner)
            Else
                ' We are INSERTING or UPDATING a record.
                strSQL.Append("BEGIN ")

                Dim strValues As StringBuilder = New StringBuilder(String.Empty)

                ' Determine if we have a new record or not.
                If strRowID.Equals(String.Empty) OrElse m_blnNewRecord(Me.CurrentRow) Then
                    ' Generate the INSERT statement.
                    strSQL.Append(" SET @P_ROWID = newid();")
                    strSQL.Append("INSERT INTO ").Append(Me.TableNameWithOwner).Append(" (").Append("ROWID")
                    strValues.Append("@P_ROWID")
                    blnIsInsert = True
                Else
                    ' Generate the UPDATE statement.
                    strSQL.Append("UPDATE ").Append(Me.TableNameWithOwner).Append(" SET ")
                End If

                Dim intColumn As Integer
                Dim strColumnName As String = String.Empty
                Dim strValue As String = String.Empty
                Dim IsIdentity As Boolean = False
                Dim IsReadonly As Boolean = False

                ' Create the rest of the SQL
                ' Loop through the columns and create the appropriate parameter objects.
                For intColumn = 0 To m_dtbDataTable.Columns.Count - 1

                    ' Store the column name.
                    strColumnName = m_dtbDataTable.Columns.Item(intColumn).ColumnName.ToString

                    If IsNothing(m_dtbMetaData) Then
                        GetMetaData()
                    End If

                    If Not IsNothing(m_dtbMetaData) Then
                        For i As Integer = 0 To m_dtbMetaData.Rows.Count - 1
                            If m_dtbMetaData.Rows(i)(0).ToString.Trim = strColumnName.Trim Then
                                IsReadonly = m_dtbMetaData.Rows(i)("IsReadonly")
                                IsIdentity = m_dtbMetaData.Rows(i)("IsIdentity")
                                Exit For
                            End If
                        Next
                    End If


                    If IsReadonly Then


                        ' Create parameters for columns that are not Audit fields.  
                        ' Also exclude ROW_NUM and ROW_ID columns
                    ElseIf m_dtbDataTable.Columns.Item(intColumn).AutoIncrement OrElse IsIdentity Then
                        identityColumn = m_dtbDataTable.Columns.Item(intColumn).ColumnName
                    ElseIf (IsValidColumn(strColumnName) AndAlso Not ReturnIsReadonly(intColumn)) OrElse ((blnIsInsert AndAlso Not strColumnName.Equals("ROW_ID") AndAlso Not strColumnName.Equals("ROW_NUM"))) Then
                        Select Case m_dtbDataTable.Columns.Item(intColumn).DataType.ToString
                            Case "System.String"
                                If (m_dtbDataTable.Columns.Item(intColumn).AllowDBNull _
                                AndAlso IsNull(m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn))) _
                                OrElse (CType(m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn), String).TrimEnd = "" _
                                AndAlso IsRelationalPrimaryKeyValue(Owner, intColumn)) Then
                                    strValue = "Null"
                                Else
                                    strValue = StringToField(CType(m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn), String).TrimEnd)
                                End If
                            Case "System.DateTime"
                                If m_dtbDataTable.Columns.Item(intColumn).AllowDBNull AndAlso (IsNull(m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn)) _
                                OrElse (CDate(m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn)) = cZeroDate AndAlso blnIsInsert) _
                                OrElse (CDate(m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn)) = cZeroDate AndAlso ((Not blnIsInsert) AndAlso
                                ((Not m_dtbDataTable.Rows(Me.CurrentRow).HasVersion(DataRowVersion.Original) AndAlso CDate(m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn)) = cZeroDate) OrElse
                                (m_dtbDataTable.Rows(Me.CurrentRow).HasVersion(DataRowVersion.Original) AndAlso IsNull(m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn, DataRowVersion.Original)) OrElse CDate(m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn, DataRowVersion.Original)) = cZeroDate))))) Then
                                    strValue = "Null"
                                Else
                                    If CDate(m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn)) = cZeroDate Then
                                        strValue = "Null"
                                    Else
                                        strValue = "CONVERT(DATETIME, " + StringToField(Format(CDate(m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn)), "yyyy-MM-dd HH:mm:ss")) + ", 120)"
                                    End If
                                End If
                            Case "System.Decimal", "System.Double", "System.Int16", "System.Int32", "System.Int64"
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
                                    ' If we have a size digit date in the database, then truncate the value.
                                    If Not IsNothing(GetDictionary(strColumnName)) AndAlso (GetDictionary(strColumnName).ElementTypeCode = DataTypes.Date AndAlso Not GetDictionary(strColumnName).ItemDatatypeCode = ItemDataTypes.Date) Then
                                        Dim size As Integer = GetDictionary(strColumnName).intItemSize
                                        If strValue.Length > size Then
                                            strValue = strValue.Substring(strValue.Length - size, size)
                                        End If
                                    End If
                                End If
                            Case "System.Boolean"
                                If (m_dtbDataTable.Columns.Item(intColumn).AllowDBNull _
                                AndAlso IsNull(m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn))) Then
                                    strValue = "Null"
                                Else
                                    ' Since SQL Server stores True as a 1, do an Absolute.  Treat True as 1 and False as 0.
                                    strValue = Math.Abs(CType(m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn), Integer))
                                End If
                            Case "System.Guid"
                                'Generate the new ROWID
                                strColumnName = "ROWID"  'Because underlying Column is "ROWID" and not "ROW_ID"
                                strValue = "@P_ROWID"
                            Case "System.Blob"
                                'TODO: Blob Type needs to be varified and tested
                                strValue = m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn).ToString
                            Case "System.Clob"
                                'TODO: Clob/Text Type needs to be varified and tested
                                strValue = m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn).ToString
                            Case "System.Byte[]"
                                strValue = "Null"
                        End Select

                        If blnIsInsert Then
                            ' Append all the columns.
                            strSQL.Append(",").Append(strColumnName)

                            ' Append all the values.
                            strValues.Append(",").Append(strValue)
                        Else
                            If Not strValue.Equals("Null") OrElse m_dtbDataTable.Columns.Item(intColumn).DataType.ToString = "System.DateTime" Then
                                ' Only append the fields that have changed.
                                If (Not m_dtbDataTable.Rows(Me.CurrentRow).HasVersion(DataRowVersion.Original)) OrElse (Not m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn).Equals(m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn, DataRowVersion.Original))) Then
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
                    strSQL.Append(strValues.ToString).Append(");")
                End If

                strValues = Nothing
            End If

            If Not blnIsInsert Then
                strSQL.Append(" WHERE ROWID = @P_ROWID")
                strSQL.Append(" AND CHECKSUM_VALUE = @P_CHECKSUM_VALUE;")
            End If

            strSQL.Append(" SET @P_RECORDS_AFFECTED = @@ROWCOUNT;")
            If Not m_blnDeletedRecord(Me.CurrentRow) Then
                strSQL.Append(" SELECT @P_ROWID = ROWID, @P_CHECKSUM_VALUE = CHECKSUM_VALUE")
                ' If we have an Identity column, ensure we read the value after the insert.
                If blnIsInsert AndAlso identityColumn.Length > 0 Then
                    strSQL.Append(", @P_" & identityColumn & " = " & identityColumn)
                    ReDim prmFields(3)
                End If
                strSQL.Append(" FROM ").Append(Me.TableNameWithOwner)
                strSQL.Append(" WHERE ROWID = @P_ROWID; END")
            End If

            ' Ensure we don't pass this column to CallUpdateRecord if not an Insert.
            If Not blnIsInsert AndAlso identityColumn.Length > 0 Then identityColumn = String.Empty


            ' Only send the SQL if we are doing an Insert or the Update has actual changed values.
            ' Since a value may have been changed and then set back to the original value in update, the 
            ' altered status will force the update but there will not be a SET field = value in the SQL statement.
            If blnIsInsert OrElse m_blnDeletedRecord(Me.CurrentRow) OrElse Not blnFirstColumn Then
                CallUpdateRecord(prmFields, intRowIDPosition, intCheckSumPosition, intRecordsAffectedPosition, strSQL.ToString, blnIsInsert, identityColumn)
            End If
            strSQL = Nothing

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

            Dim intUpdateTypePosition As Integer = -1
            Dim intRecordsAffectedPosition As Integer = -1
            Dim intCheckSumPosition As Integer = -1
            Dim intRowIDPosition As Integer = -1
            Dim blnIsInsert As Boolean

            Dim intParmCount As Integer = -1
            Dim intColumn As Integer
            Dim strColumnName As String
            Dim prmFields() As SqlParameter

            ' Loop through the columns and create the appropriate parameter objects.
            For intColumn = 0 To m_dtbDataTable.Columns.Count - 1

                ' Store the column name.
                strColumnName = m_dtbDataTable.Columns.Item(intColumn).ColumnName.ToString

                ' Create parameters for columns that are not Audit fields.  
                ' Also exclude ROW_NUM and ROW_ID columns
                If IsValidColumn(strColumnName) Then

                    ' Increment the parameter count.
                    intParmCount += 1

                    ReDim Preserve prmFields(intParmCount)
                    prmFields(intParmCount) = New SqlParameter

                    ' Set the parameter name.
                    prmFields(intParmCount).ParameterName = "@P_" & GetBriefName(strColumnName, True)

                    Select Case m_dtbDataTable.Columns.Item(intColumn).DataType.ToString
                        Case "System.String"
                            prmFields(intParmCount).SqlDbType = SqlDbType.VarChar
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
                        Case "System.DateTime"
                            prmFields(intParmCount).SqlDbType = SqlDbType.DateTime
                        Case "System.Decimal", "System.Double"
                            prmFields(intParmCount).SqlDbType = SqlDbType.Decimal
                        Case "System.Int32", "System.Int64"
                            prmFields(intParmCount).SqlDbType = SqlDbType.Int
                        Case "System.Blob"
                            'TODO: Blob Type needs to be varified and tested
                            prmFields(intParmCount).SqlDbType = SqlDbType.VarBinary
                        Case "System.Clob"
                            'TODO: Clob/Text Type needs to be varified and tested
                            prmFields(intParmCount).SqlDbType = SqlDbType.Text
                    End Select

                    prmFields(intParmCount).Direction = ParameterDirection.Input
                    If m_dtbDataTable.Columns.Item(intColumn).DataType.ToString = "System.String" Then
                        prmFields(intParmCount).Value = StringToField(m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn).ToString, True)
                    ElseIf m_dtbDataTable.Columns.Item(intColumn).DataType.ToString = "System.DateTime" AndAlso m_dtbDataTable.Columns.Item(intColumn).AllowDBNull _
                    AndAlso (IsNull(m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn)) OrElse
                    (CDate(m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn)) = cZeroDate AndAlso Me.NewRecord(Me.CurrentRow)) OrElse
                    (CDate(m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn)) = cZeroDate AndAlso ((Not Me.NewRecord(Me.CurrentRow)) AndAlso CDate(m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn, DataRowVersion.Original)) = cZeroDate))) Then
                        prmFields(intParmCount).Value = DBNull.Value
                    Else
                        If m_dtbDataTable.Columns.Item(intColumn).DataType.ToString = "System.DateTime" AndAlso CDate(m_dtbDataTable.Rows(Me.CurrentRow).Item(intColumn)) = cZeroDate Then
                            prmFields(intParmCount).Value = DBNull.Value
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

                End If
            Next

            ' ReDim the array to add the RecordsAffected, CHECKSUM_VALUE, ROWID and @P_UPDATE_TYPE parameters.
            ReDim Preserve prmFields(intParmCount + 4)
            '---
            intUpdateTypePosition = intParmCount + 1
            intRecordsAffectedPosition = intParmCount + 2
            intCheckSumPosition = intParmCount + 3
            intRowIDPosition = intParmCount + 4

            ' Add the UPDATETYPE parameter
            prmFields(intUpdateTypePosition) = New SqlParameter("@P_UPDATE_TYPE", SqlDbType.Char, 6)
            With prmFields(intUpdateTypePosition)
                .Direction = ParameterDirection.Input
                If m_blnDeletedRecord(Me.CurrentRow) Then
                    .Value = "DELETED"
                Else
                    If (m_dtbDataTable.Rows(Me.CurrentRow).Item("ROW_ID") Is Nothing OrElse m_dtbDataTable.Rows(Me.CurrentRow).Item("ROW_ID") Is System.DBNull.Value) OrElse m_blnNewRecord(Me.CurrentRow) Then
                        blnIsInsert = True
                        .Value = "INSERT"
                    Else
                        blnIsInsert = False
                        .Value = "UPDATE"
                    End If
                End If
            End With

            '' Uncomment following to Generate Parameters passed Stored Procedure
            'Dim objParam As sqlParameter
            'For Each objParam In prmFields
            '    Debug.Write(objParam.sqlType)
            '    Debug.Write(vbTab)
            '    Debug.Write(objParam.Size)
            '    Debug.Write(vbTab)
            '    Debug.Write(objParam.ParameterName)
            '    Debug.Write(vbTab)
            '    Debug.WriteLine(objParam.Value)
            'Next

            CallUpdateRecord(prmFields, intRowIDPosition, intCheckSumPosition, intRecordsAffectedPosition)

        End Sub

        ''' --- CallUpdateRecord ---------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of CallUpdateRecord.
        ''' </summary>
        ''' <param name="FieldsParameters"></param>
        ''' <param name="RowIdPosition"></param>
        ''' <param name="CheckSumPosition"></param>
        ''' <param name="RecordsAffectedPosition"></param>
        ''' <param name="SQL"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Private Sub CallUpdateRecord(ByRef FieldsParameters() As SqlClient.SqlParameter, ByVal RowIdPosition As Integer, ByVal CheckSumPosition As Integer, ByVal RecordsAffectedPosition As Integer, Optional ByVal SQL As String = "", Optional ByVal blnIsInsert As Boolean = False, Optional ByVal IdentityColumn As String = "")

            ' Add the @RecordsAffected parameter.
            FieldsParameters(RecordsAffectedPosition) = New SqlParameter("@P_RECORDS_AFFECTED", SqlDbType.Decimal)
            FieldsParameters(RecordsAffectedPosition).Direction = ParameterDirection.Output

            ' Add the CHECKSUM_VALUE / TIMESTAMP parameter
            FieldsParameters(CheckSumPosition) = New SqlParameter("@P_CHECKSUM_VALUE", SqlDbType.Int)
            With FieldsParameters(CheckSumPosition)
                .Direction = ParameterDirection.InputOutput
                If IsQTP AndAlso m_hsChecksum.Contains(m_dtbDataTable.Rows(Me.CurrentRow).Item("ROW_ID")) Then
                    .Value = m_hsChecksum.Item(m_dtbDataTable.Rows(Me.CurrentRow).Item("ROW_ID")).ToString
                Else
                    .Value = m_dtbDataTable.Rows(Me.CurrentRow).Item("CHECKSUM_VALUE")
                End If
            End With

            ' Add the ROWID parameter.
            FieldsParameters(RowIdPosition) = New SqlParameter("@P_ROWID", SqlDbType.UniqueIdentifier)
            With FieldsParameters(RowIdPosition)
                .Direction = ParameterDirection.InputOutput
                .Value = m_dtbDataTable.Rows(Me.CurrentRow).Item("ROW_ID")
            End With

            If IdentityColumn.Length > 0 Then
                ' Add the identity column parameter.
                FieldsParameters(RowIdPosition + 1) = New SqlParameter("@P_" & IdentityColumn, SqlDbType.Int)
                With FieldsParameters(RowIdPosition + 1)
                    .Direction = ParameterDirection.InputOutput
                    .Value = m_dtbDataTable.Rows(Me.CurrentRow).Item(IdentityColumn)
                End With
            End If


            Dim intRecordsAffected As Integer
            Dim strMessage As String = String.Empty
            Dim strParams As String = String.Empty

            Try
                If m_blnHasLock Then
                    If SQL.Length > 0 Then
                        intRecordsAffected = SqlHelper.ExecuteNonQuery(m_trnLockedTransaction, CommandType.Text, SQL, FieldsParameters)
                    Else
                        intRecordsAffected = SqlHelper.ExecuteNonQuery(m_trnLockedTransaction, CommandType.StoredProcedure, Owner + ".Put" & GetBriefName(m_strBaseName), FieldsParameters)
                    End If
                Else
                    If SQL.Length > 0 Then
                        intRecordsAffected = SqlHelper.ExecuteNonQuery(m_trnTransaction, CommandType.Text, SQL, FieldsParameters)
                    Else
                        intRecordsAffected = SqlHelper.ExecuteNonQuery(m_trnTransaction, CommandType.StoredProcedure, Owner + ".Put" & GetBriefName(m_strBaseName), FieldsParameters)
                    End If
                End If

                intRecordsAffected = CInt(FieldsParameters(RecordsAffectedPosition).Value)
            Catch ex As SqlException
                If Not blnOnErrorReport Then
                    If ex.Message.IndexOf("PRIMARY KEY") > -1 Then

                        If Thread.CurrentThread.CurrentCulture.ToString.StartsWith("fr") Then
                            strMessage = "Violation de clé primaire sur {0}." 'IM.PKViolation
                        Else
                            strMessage = "Primary key violation on {0}." 'IM.PKViolation
                        End If
                        strParams = m_strBaseName
                        intRecordsAffected = -1
                    ElseIf ex.Message.ToUpper.IndexOf("DUPLICATE KEY") > -1 Then
                        If Thread.CurrentThread.CurrentCulture.ToString.StartsWith("fr") Then
                            strMessage = "Dupliquer la violation de clé sur {0}." 'IM.DUPLICATEViolation
                        Else
                            strMessage = "Duplicate key violation on {0}." 'IM.DUPLICATEViolation
                        End If

                        strParams = m_strBaseName
                        intRecordsAffected = -1
                    Else
                        ExceptionManager.Publish(ex)
                        intRecordsAffected = -1
                    End If
                End If
            End Try

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

                If IsQTP Then
                    If m_hsChecksum.Contains(FieldsParameters(RowIdPosition).Value) Then
                        m_hsChecksum.Item(FieldsParameters(RowIdPosition).Value) = FieldsParameters(CheckSumPosition).Value
                    Else
                        m_hsChecksum.Add(FieldsParameters(RowIdPosition).Value, FieldsParameters(CheckSumPosition).Value)
                    End If
                End If

                If Not m_blnDeletedRecord(Me.CurrentRow) Then

                    ' Assign the ROWID and CHECKSUM_VALUE fields back to the datatable.
                    m_dtbDataTable.Rows(Me.CurrentRow).Item("ROW_ID") = FieldsParameters(RowIdPosition).Value
                    m_dtbDataTable.Columns("CHECKSUM_VALUE").ReadOnly = False 'We need to make it writable
                    m_dtbDataTable.Rows(Me.CurrentRow).Item("CHECKSUM_VALUE") = FieldsParameters(CheckSumPosition).Value

                    If IdentityColumn.Length > 0 Then
                        m_dtbDataTable.Columns(IdentityColumn).ReadOnly = False 'We need to make it writable
                        m_dtbDataTable.Rows(Me.CurrentRow).Item(IdentityColumn) = FieldsParameters(RowIdPosition + 1).Value
                    End If

                    ' Update Checksum Value for any other record that may have the same ROWID.
                    If IsQTP Then
                        Dim i As Integer
                        For i = (Me.CurrentRow + 1) To m_dtbDataTable.Rows.Count - 1
                            If m_dtbDataTable.Rows(i).Item("ROW_ID").ToString <> "" AndAlso m_dtbDataTable.Rows(i).Item("ROW_ID") = FieldsParameters(RowIdPosition).Value Then
                                m_dtbDataTable.Rows(i).Item("CHECKSUM_VALUE") = FieldsParameters(CheckSumPosition).Value
                            Else
                                Exit For
                            End If
                        Next
                    End If

                    If SQL.Length > 0 Then
                        ' Set the datatable row to accept the current changes which will set the RowState to Unchanged.
                        m_dtbDataTable.Rows(Me.CurrentRow).AcceptChanges()
                    End If
                End If
                FieldsParameters = Nothing

                If m_blnDeletedRecord(Me.CurrentRow) Then
                    m_blnGridDeletedRecord(Me.CurrentRow) = True
                End If
            Else
                FieldsParameters = Nothing
                If Not blnOnErrorReport Then
                    If intRecordsAffected = 0 Then
                        If Not (IsQTP AndAlso m_hsChecksum.Contains(m_dtbDataTable.Rows(Me.CurrentRow).Item("ROW_ID"))) Then
                            If Not m_blnGridDeletedRecord(Me.CurrentRow) Then
                                AddMessage("Cannot update table <{0}&gt;, data has been changed.", MessageTypes.Error, m_strBaseName) 'IM.DataChangedDB
                            Else
                                AddMessage("This record has already been deleted({0}*{1})", MessageTypes.Information, m_strBaseName, (Me.CurrentRow + 1).ToString) 'IM.DataAlreadyDeletedDB
                            End If
                        End If
                    Else
                        If strMessage.Length > 0 Then
                            AddMessage(strMessage, MessageTypes.Error, strParams)  ' Allows us to use the globalization.
                        Else
                            AddMessage("Database Error: Could not update the table <{0}>!", MessageTypes.Error, m_strBaseName) 'IM.DBError
                        End If
                    End If
                End If

            End If

        End Sub


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
                Case "ROW_NUM", "ROW_ID", "ROWID", "AUDIT_WHO", "AUDIT_WHERE",
                    "AUDIT_WHEN", "AUDIT_UPDATE_TYPE", "AUDIT_CREATION_DATE",
                    "AUDIT_NETWORK_UPDATE", "CHECKSUM_VALUE"
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

            Return CType(SqlHelper.ExecuteScalar(connectionString, commandType, commandText), Long)

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
            Return Common.GetSqlConnectionString
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

                    m_cnnLockedTransaction = New SqlClient.SqlConnection(GetConnectionString)
                    With m_cnnLockedTransaction
                        .Open()
                        Me.GetMetaData(m_cnnLockedTransaction, Nothing)
                        m_trnLockedTransaction = .BeginTransaction
                    End With

                    If LockTypes = LockTypes.File Then
                        'Lock the Table in Exclusive Mode
                        'SqlHelper.ExecuteNonQuery(m_trnLockedTransaction, CommandType.Text, "LOCK TABLE " + Me.TableNameWithOwner + " IN EXCLUSIVE MODE")
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

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overridable ReadOnly Property IsKeepText() As Boolean
            Get
                Return False
            End Get
        End Property

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overridable ReadOnly Property IsKeepTextFile() As Boolean
            Get
                Return False
            End Get
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
                m_drdDataReader = CType(Value, SqlDataReader)
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
                Return DatabaseTypes.SqlServer
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
                Return "ROWID"
            End Get
        End Property

    End Class

End Namespace
#End If
