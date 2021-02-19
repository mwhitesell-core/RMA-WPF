Option Explicit On
Option Strict On

Imports Core.Framework
#If TARGET_DB = "INFORMIX" Then
Imports ibm.Data.Informix
Imports Core.DataAccess.Informix
#Else
Imports System.Data.OracleClient
Imports Core.DataAccess.Oracle
#End If
Imports Core.ExceptionManagement
Imports System.Exception
Imports System.Runtime.Serialization
Imports System.Text
Imports System.Web
Imports System.Xml
Imports System.IO
Imports System.Diagnostics
Imports System.ComponentModel

Namespace Core.Framework

    ''' --- IFileObject --------------------------------------------------------
    ''' 
    ''' <summary>
    ''' The IFileObject interface supports the Renaissance Architect Framework infrastructure and 
    ''' is not intended to be used directly from your code.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
    Public Interface IFileObject

        ''' --- GoToRecordEvent ----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GoToRecordEvent.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Event GoToRecordEvent(ByVal Sender As Object, ByVal EventArgs As Object, ByVal NewRecordPosition As Integer)

        ''' --- UnderlyingDataTable ------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of UnderlyingDataTable.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        ReadOnly Property UnderlyingDataTable() As DataTable

        ''' --- EOF ----------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of EOF.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        ReadOnly Property EOF() As Boolean

        ''' --- DataFetched --------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of DataFetched.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        ReadOnly Property DataFetched() As Boolean

        ''' --- HasData ------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of HasData.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Property HasData() As Boolean

        ''' --- AliasName ----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of AliasName.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Property AliasName() As String

        ''' --- BaseName -----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of BaseName.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Property BaseName() As String

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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Property Connection() As IDbConnection

        ''' --- NewRecord ----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of NewRecord.
        ''' </summary>
        ''' <param name="RowPosition"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Property NewRecord(ByVal RowPosition As Integer) As Boolean

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Property NewRecord() As Boolean

        ''' --- IsOldRecord --------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of IsOldRecord.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        ReadOnly Property IsOldRecord() As Boolean

        ''' --- IsOldRecord --------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of IsOldRecord.
        ''' </summary>
        ''' <param name="RowPosition"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        ReadOnly Property IsOldRecord(ByVal RowPosition As Integer) As Boolean

        ''' --- AlteredRecord ------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of AlteredRecord.
        ''' </summary>
        ''' <param name="RowPosition"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Property AlteredRecord(ByVal RowPosition As Integer) As Boolean

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Property AlteredRecord() As Boolean

        ''' --- GetAlteredRecord ---------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetAlteredRecord.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        ReadOnly Property GetAlteredRecord() As Boolean()

        ''' --- GetDeletedRecord ---------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetDeletedRecord.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        ReadOnly Property GetDeletedRecord() As Boolean()

        ''' --- GetNewRecord -------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetNewRecord.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        ReadOnly Property GetNewRecord() As Boolean()

        ''' --- Occurs -------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Occurs.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Property Occurs() As Integer

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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Property Transaction() As IDbTransaction

        ''' --- NoAppend -----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of NoAppend.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Property NoAppend() As Boolean

        ''' --- NoDelete -----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of NoDelete.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Property NoDelete() As Boolean

        ''' --- BoundToGrid --------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of BoundToGrid.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Property BoundToGrid() As Boolean

        ''' --- Type ---------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Type.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Property Type() As FileTypes

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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        ReadOnly Property DatabaseType() As DatabaseTypes

        ''' --- SkipRecordsWithError -----------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of SkipRecordsWithError.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Property SkipRecordsWithError() As Boolean

        ''' --- TotalRecordsFound --------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of TotalRecordsFound.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Property TotalRecordsFound() As Integer

        ''' --- TotalSkippedRecords ------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of TotalSkippedRecords.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Property TotalSkippedRecords() As Integer

        ''' --- TotalRecordsProcessed ----------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of TotalRecordsProcessed.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Property TotalRecordsProcessed() As Integer

        ''' --- GetInternalValues --------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetInternalValues.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Function GetInternalValues(Optional ByVal PassingFile As Boolean = False) As System.Collections.Hashtable

        ''' --- RecordLocation --------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of RecordLocation.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Function RecordLocation() As String

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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Function GetCachedSchema(ByVal GetSchema As Boolean, Optional ByVal AddRow As Boolean = True) As DataTable

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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Function GetDataInternal( _
            ByVal WhereClause As String, _
            ByVal OrderByClause As String, _
            ByVal OverrideSQL As String, _
            ByVal GetDataBehaviour As GetDataOptions, _
            ByRef RecordsToFill As Integer) As Boolean

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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Function GetConnectionString() As String

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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Sub GetMetaData(ByRef cnn As IDbConnection, ByRef trn As IDbTransaction)

        ''' --- MoveFirst ----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of MoveFirst.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Sub MoveFirst()

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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Sub PutData()

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Sub PutData(ByVal Reset As Boolean)

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Sub PutData(ByVal Reset As Boolean, ByVal PutType As PutTypes)

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Sub PutData(ByVal Reset As Boolean, ByVal PutType As PutTypes, ByVal At As Integer)

        'Sub CallPutSQL()
        ''' --- GoToRecord ---------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GoToRecord.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="EventArgs"></param>
        ''' <param name="NewRecordPosition"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Sub GoToRecord(ByVal sender As Object, ByVal EventArgs As Object, ByVal NewRecordPosition As Integer)

        ''' --- GoToRecord ---------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GoToRecord.
        ''' </summary>
        ''' <param name="NewRecordPosition"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Sub GoToRecord(ByVal NewRecordPosition As Integer)

        ''' --- SetInternalValues --------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of SetInternalValues.
        ''' </summary>
        ''' <param name="InternalData"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Sub SetInternalValues(ByVal InternalData As Hashtable, Optional ByVal PassingFile As Boolean = False, Optional ByVal PassingSequence As Integer = 0)

        ''' --- DeleteRecord -------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of DeleteRecord.
        ''' </summary>
        ''' <param name="Sender"></param>
        ''' <param name="EventArgs"></param>
        ''' <param name="NewRecordPosition"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Overloads Sub DeleteRecord(ByVal Sender As Object, ByVal EventArgs As Object, Optional ByVal NewRecordPosition As Integer = -1)

        ''' --- EditRecord ---------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of EditRecord.
        ''' </summary>
        ''' <param name="Sender"></param>
        ''' <param name="EventArgs"></param>
        ''' <param name="NewRecordPosition"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Overloads Sub EditRecord(ByVal Sender As Object, ByVal EventArgs As Object, Optional ByVal NewRecordPosition As Integer = -1)

        ''' --- AddRecord ----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of AddRecord.
        ''' </summary>
        ''' <param name="Sender"></param>
        ''' <param name="EventArgs"></param>
        ''' <param name="NewRecordPosition"></param>
        ''' <param name="IsGridNew"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Overloads Sub AddRecord(ByVal Sender As Object, ByVal EventArgs As Object, Optional ByVal NewRecordPosition As Integer = -1, Optional ByVal IsGridNew As Boolean = False)

        ''' --- AuditStatus ---------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of AuditStatus.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        ReadOnly Property AuditStatus(Optional ByVal RowPosition As Integer = -1) As String
        ''' --- WhereColumn ---------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of WhereColumn.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	03/23/2009	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Property WhereColumn() As ArrayList

        ''' --- RecordCount ---------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of RecordCount.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	03/23/2009	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        ReadOnly Property RecordCount() As Integer
    End Interface

End Namespace

