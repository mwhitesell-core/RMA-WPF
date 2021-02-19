Option Explicit On

Imports Core.Framework
Imports Core.ExceptionManagement
Imports System.Exception
Imports System.Runtime.Serialization
Imports System.Text
Imports System.Web
Imports System.Xml
Imports System.IO
Imports System.ComponentModel
Imports Core.Framework.Core.Windows.Framework
''test
Namespace Core.Framework
    ''' -----------------------------------------------------------------------------
    ''' Project	 : Core.Framework
    ''' Class	 : Core.Framework.BaseFileObject
    ''' 
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Provides the base implementation for the IFileObject interface.  This class handles the 
    ''' record structure accessed by the screen and implements the functionality of record retrieval,
    ''' item initialization, and updating the database with the appropriate changes.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	4/11/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <Serializable(), ComponentModel.ToolboxItem(True), ComponentModel.DesignTimeVisible(True),
    EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
    Public Class BaseFileObject
        Inherits System.ComponentModel.Component
        Implements IFileObject



#Region " Variable Declarations "

        Public m_Subtoal As Hashtable
        Public m_HasAt As Boolean

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public OverRideOccurrence As Integer = -1

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public DifferenceOccurrence As Integer = -1

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected OverRideOccurrenceCount As Integer = -1

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public SortOccurrence As Integer = -1

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public blnOverRideOccurrence As Boolean = False

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected IsSortFirst As Boolean

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected intSortOrder As Integer = -1

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected intSortFileOrder As Integer = -1

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected intLastfound As Integer = -1

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected intPrevSortOrder As Integer = -1

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected blnQTPInit As Boolean = True

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected blnInInit As Boolean = False

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected blnInForLoop As Boolean = False

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public m_intSortNextOccurence As Integer = -1

        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public m_intSortPreviousOccurence As Integer = -1

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public m_blnCreateBlankRow As Boolean = False

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public m_intQTPLevel As Integer


        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_blnOutPut As Boolean = False

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public m_blnOutPutOutGet As Boolean = False

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_blnOutGet As Boolean = False

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public m_blnResetAtOutput As Boolean = False

        Protected m_blnInDefine As Boolean = False

        Public m_arrOutPutColumns As ArrayList
        Public m_arrOutPutValues As ArrayList

        Protected m_IsKeepSubFile As BooleanTypes = BooleanTypes.NotSet

        public tmpDataTable As DataTable
        Protected blnTempPutInDatabase As Boolean = False
        Protected blnExists As Boolean = False

        Protected strSQLWhere As String = String.Empty
        Protected blnUseTableSelectIf As BooleanTypes = BooleanTypes.NotSet

        Private Shared m_strDefaultDateFormat As String
        Private Shared m_strDefaultDateSeparator As String
        Private Shared m_strNullSeparator As String
        Protected SelectifSQL As String = ""
        Protected blnRunForMissing As Boolean = False
        Protected m_intQTPSkip As Integer = 0
        Protected m_intQTPFirst As Integer = 600000

        Protected m_strTableJoin As String = String.Empty
        Protected m_blnNoTempRecords As Boolean = False

        ''' --- m_IsTempTable ------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of m_IsTempTable.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_IsTempTable As Boolean

        ''' --- m_IsTextFile ------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of m_IsTextFile.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_IsTextFile As Boolean



        ''' --- m_IsSubFile ------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of m_IsTempTable.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_IsSubFile As Boolean

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_IsPortableSubFile As Boolean

        ''' --- m_IsSubFileKeepTable ------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        '''   Summary of m_IsSubFileKeepTable.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''   [Campbell]         6/29/2005          Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_IsSubFileKeepTable As Boolean


        ''' --- m_blnPutInitiatedFromOccursWithFile --------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnPutInitiatedFromOccursWithFile.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_blnPutInitiatedFromOccursWithFile As Boolean = False

        ''' --- m_intPassingSequence --------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_intPassingSequence.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_intPassingSequence As Integer = 0

        ''' --- m_blnCountIntoCalled --------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnCountIntoCalled.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_blnCountIntoCalled() As Boolean

        ''' --- m_strSQL --------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_strSQL.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_strSQL As String = String.Empty

        ' Variable declarations for properties.
        ''' --- m_blnAccessIsOptional ---------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnAccessIsOptional.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_blnAccessIsOptional As Boolean = False                 ' AccessIsOptional value 

        ''' --- m_sortOnField ---------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_sortOnField.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_sortOnField As String = ""

        ''' --- m_sorttype ---------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_sorttype.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_sorttype As SortType = SortType.Ascending

        ''' --- m_strEditField -------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_strEditField.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Private m_strEditField As String = ""                     ' The Field on which the Edit procedure is currently executing.
        ''' --- m_blnBoundToGrid ---------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnBoundToGrid.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Private m_blnBoundToGrid As Boolean = False                 ' Occurs value 
        ''' --- m_blnNoItems -------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnNoItems.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Private m_blnNoItems As Boolean = False                     ' No Items (no default initialization occurs)
        ''' --- m_blnHasLastGetData ------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnHasLastGetData.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Private m_blnHasLastGetData As Boolean = False
        ''' --- m_blnDontAlter -----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnDontAlter.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Private m_blnDontAlter As Boolean = False
        ''' --- m_blnExecutedPrimaryDetailFor --------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnExecutedPrimaryDetailFor.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Private m_blnExecutedPrimaryDetailFor As Boolean = False    ' Used for the special scenario for Primary/Detail records in Find/DetailFind.

        ''' --- m_intType ----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_intType.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_intType As FileTypes                            ' File Type - Primary, Secondary, Detail, etc.
        ''' --- m_intNeed ----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_intNeed.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_intNeed As Integer = 0                          ' NEED n|ALL records (Put verb treats record as changed)
        ''' --- m_strTransactionName ----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_intType.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_strTransactionName As String                            ' The name of the transaction.
        ''' --- m_intProviderTypeOrdinal -------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_intProviderTypeOrdinal.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_intProviderTypeOrdinal As Integer = -1          ' A Provider type for underlying data source should be set in derived class
        ''' --- m_intClobValue -----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_intClobValue.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_intClobValue As Integer = -1

        ''' --- m_strOwner ---------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_strOwner.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_strOwner As String = ""                         ' The owner of the table.
        ''' --- m_strElementOwner --------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_strElementOwner.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_strElementOwner As String = ""                  ' ElementOwner used for this File.
        ''' --- m_strBaseName ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_strBaseName.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_strBaseName As String = ""                      ' Base relation name (underlying table if aliased)
        ''' --- m_strAliasName -----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_strAliasName.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_strAliasName As String = ""                     ' Alias name
        ''' --- m_strRelation ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_strRelation.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_strRelation As String = ""                      ' Stores the base relation name if no alias is provided, otherwise stores the alias name.
        ''' --- m_strOrderBy -------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_strOrderBy.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_strOrderBy As String = ""                       ' Order By clause.
        ''' --- m_strCursor --------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_strCursor.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_strCursor As String = ""                        ' SQL statement for the Cursor
        ''' --- m_strLastSQL -------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_strLastSQL.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_strLastSQL As String = ""                       ' Used for REFERENCE files, to determine if GET processing should be performed

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_strQTPLastSQL As String = ""                       ' Used for REFERENCE files, to determine if GET processing should be performed


        ''' --- m_blnIsInitialized -------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnIsInitialized.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_blnIsInitialized() As Boolean

        ''' --- m_blnAlteredRecord -------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnAlteredRecord.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_blnAlteredRecord() As Boolean                    ' Tracks PowerHouse AlteredRecord status
        ''' --- m_blnNewRecord -----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnNewRecord.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_blnNewRecord() As Boolean                       ' Tracks PowerHouse NewRecord status
        ''' --- m_blnDeletedRecord -------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnDeletedRecord.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_blnDeletedRecord() As Boolean                  ' Tracks PowerHouse DeletedRecord status
        ''' --- m_blnGridDeletedRecord -------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnDeletedRecord.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_blnGridDeletedRecord() As Boolean
        ''' --- m_blnEOF -----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnEOF.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_blnEOF As Boolean = False                       ' Determine if EOF for DataReader when calling the Read method.
        ''' --- m_blnUsePutProcedures ----------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnUsePutProcedures.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_blnUsePutProcedures As Boolean = False
        ''' --- FileDisposed -------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of FileDisposed.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected FileDisposed As Boolean                           ' A flag to identify whether the instance is already Disposed or not

        ''' --- m_dtbDataTable -----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_dtbDataTable.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public m_dtbBaseDataTable As DataTable                       ' Updatable recordset object

        ''' --- m_dtbQTPTempDataTable -----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_dtbQTPTempDataTable.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_dtbQTPTempDataTable As DataTable                       ' Updatable Temp recordset object

        ''' --- m_dtbMetaData ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_dtbMetaData.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_dtbMetaData As DataTable                        ' Stores the metadata (table structure) for the non-reference files.

        ''' --- m_arrBalanceFields -------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_arrBalanceFields.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_arrBalanceFields() As String                    ' List of fields for the BALANCE option on the item statement.  (PreCompiler generated)
        ''' --- m_arrSumIntoFields -------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_arrSumIntoFields.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_arrSumIntoFields() As String                    ' List of fields for the SUM INTO option on the item statement.  (PreCompiler generated)

        ''' --- m_arrCountIntoFields -------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_arrCountIntoFields.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_arrCountIntoFields() As String                    ' List of fields for the COUNT INTO option on the item statement.  (PreCompiler generated)

        ''' --- m_intOccurs --------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_intOccurs.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public m_intOccurs As Integer = 0                           ' Occurs value 

        ''' --- m_blnNoAppend ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnNoAppend.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public m_blnNoAppend As Boolean = False                     ' No append is generated for this file (PRIMARY only)
        ''' --- m_blnNoDelete ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnNoDelete.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public m_blnNoDelete As Boolean = False                     ' No delete or detail delete is generated for this file

        ' Temporary datatable used 
        ''' --- dt -----------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of dt.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected dt As DataTable

        ' Variables to control GetDataIssued within, For Missing Loop
        ''' --- m_blnForMissing ----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnForMissing.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_blnForMissing As Boolean = False
        ''' --- m_blnContinue ----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnForMissing.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_blnContinue As Boolean = False


        ''' --- m_blnFirstFile ----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnFirstFile.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_blnFirstFile As Boolean = False
        ''' --- m_blnGetDataForMissing ---------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnGetDataForMissing.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_blnGetDataForMissing As Boolean = False

        ''' --- m_blnErrorInLastRecord ---------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnErrorInLastRecord.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public m_blnErrorInLastRecord As Boolean = False    ' Used to skip records with an Error during Find/DetailFind

        ' Variables to control GetDataIssued within, For Loop for Primary/Detail in Find/DetailFind.
        ''' --- m_blnFor -----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnFor.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_blnFor As Boolean = False
        ''' --- m_blnGetDataFor ----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnGetDataFor.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_blnGetDataFor As Boolean = False

        ' m_intCurrentRecordPosition, at present updated from the GetData 
        ' called with CreateSubSelect, as such may not be available from 
        ' Files uses GetData without CreateSubSelect option.
        ''' --- m_intCurrentRecordPosition -----------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_intCurrentRecordPosition.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_intCurrentRecordPosition As Long = -1

        ' Used in a call to FileObject.FOR method
        ''' --- m_hstNestedForInfo -------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_hstNestedForInfo.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Friend m_hstNestedForInfo As Hashtable        ' m_hstNestedForInfo is a list of NestedFor, for the current FileObject
        ''' --- m_strLastForID -----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_strLastForID.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Friend m_strLastForID As String               ' m_strLastForID denotes the most ID Number for inner most For
        ''' --- m_intLastForIDNumber -----------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_intLastForIDNumber.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Friend m_intLastForIDNumber As Integer = -1   ' m_intLastForIDNumber denotes the most ID Number for inner most For
        ''' --- m_sorNestedForIDs --------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_sorNestedForIDs.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Friend m_sorNestedForIDs As System.Collections.SortedList

        ''' --- m_intRecordsToFillInFindOrDetailFind -------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_intRecordsToFillInFindOrDetailFind.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public m_intRecordsToFillInFindOrDetailFind As Integer  ' Used in Formissing to handle error in Find
        ''' --- m_blnSkipError -----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnSkipError.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Private m_blnSkipError As Boolean                       ' Used to count total records processed in case of Error in find
        ''' --- m_intRecordsToRetrieve ---------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_intRecordsToRetrieve.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_intRecordsToRetrieve As Integer = -1        ' Used to retrieve no. of records, at present used in ForMissing

        'Private m_blnExecuteLastSQL As Boolean                  ' When retrieved from Session using LastSQL, indicates need to re-fetch data.

        ''' --- m_intRetrievingRow -------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_intRetrievingRow.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Private m_intRetrievingRow As Integer = 0               ' Used to store the current occurrence of a WhileRetrieving.

        'Added primarily to display a blank grid if no record found in GetData
        ''' --- m_HasData ----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_HasData.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public m_HasData As Boolean = False

        'A Flag to convey WhileRetrieving that needs to GetData
        'Note: This flag needs to be set to True before entering into the 
        'Loop, if the calling code has Break statement within the While Retrieving loop
        ''' --- m_blnCallGetDataInWhileRetrieving ----------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnCallGetDataInWhileRetrieving.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public m_blnCallGetDataInWhileRetrieving As Boolean = True

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public m_blnInWhileRetrieving As Boolean = False

        ''' --- m_blnIsWhileRetrieving ---------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnIsWhileRetrieving.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_blnIsWhileRetrieving As Boolean = False     ' Used in WhileRetrieving method. See notes for details in the WhileRetrieving Method

        ''' --- m_blnBreakWhileRetrieving ---------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnBreakWhileRetrieving.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_blnBreakWhileRetrieving As Boolean = False     ' Set to true if a whileretrieving has a break

        ''' --- m_blnFirstWhileRetrievingExecuted ----------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnFirstWhileRetrievingExecuted.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Private m_blnFirstWhileRetrievingExecuted As Boolean    ' Used in WhileRetrieving method.  Quiz.

        ''' --- GetRecordBuffer ----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetRecordBuffer.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <NonSerialized(),
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public GetRecordBuffer As Getter

        ''' --- SetRecordBuffer ----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of SetRecordBuffer.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <NonSerialized(),
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public SetRecordBuffer As Setter

        ''' --- SetEditFlagValue ----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of SetEditFlagValue.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <NonSerialized(),
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public SetEditFlagValue As SetEditFlag

        ''' --- GetNewRecordStatus ----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetNewRecordStatus.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <NonSerialized(),
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public GetNewRecordStatus As GetNewStatus
        ''' --- GetFileTypeValue ----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetFileTypeValue.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <NonSerialized(),
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public GetFileTypeValue As GetFileType
#Region " Events... "

        ''' --- Access -------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Specifies default record-structure retrieval (WHERE clause) information.
        ''' </summary>
        ''' <param name="AccessClause">A string containing the SQL condition.</param>
        ''' <remarks>Use the Access event to set the default retrieval information for a record-structure.  
        ''' Developers can code leverage the benefits of the Access event when data retrieval for a given
        ''' record structure is the same each time records are to be retrieved.  
        ''' </remarks>
        ''' <example>
        ''' The example below specifies that the default retrieval information for the EMPLOYEE record structure <br/>
        ''' uses the EMPLOYEE_ID field to determine the records to retrieve with the value supplied from the Temporary <br/>
        ''' class T_TEMP_ID.  This event is executed each time record retrieval takes place (ie. using the GetData or WhileRetrieving methods <br/>
        ''' without specifying a WHERE clause) so the value in T_TEMP_ID can change as this expression is evaluated each time. <br/> <br/>
        ''' For example, the following code will raise the Access event on EMPLOYEE (since no where clause is specified). <br/><br/>
        ''' fleEMPLOYEE.GetData() <br/> <br/>
        ''' Private Sub fleEMPLOYEE_Access(ByRef AccessClause As String) Handles fleEMPLOYEE.Access <br/>
        ''' <br/>
        '''     Try <br/>
        ''' <br/>
        '''         Dim strText As StringBuilder = New StringBuilder("") <br/>
        ''' <br/>
        '''         strText.Append(" WHERE EMPLOYEE.EMPLOYEE_ID = ").Append(StringToField(T_EMP_ID.Value)) <br/>
        ''' <br/>
        '''         AccessClause = strText.ToString() <br/>
        ''' <br/>
        '''     Catch ex As CustomApplicationException <br/>
        ''' <br/>
        '''         Throw ex <br/>
        ''' <br/>
        '''     Catch ex As Exception <br/>
        ''' <br/>
        '''         ExceptionManager.Publish(ex) <br/>
        '''         Throw ex <br/>
        ''' <br/>
        '''     End Try <br/>
        ''' <br/>
        ''' End Sub <br/>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Event Access(ByRef AccessClause As String)

        ''' --- SelectIf -----------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Specifies filter (WHERE clause) information for data retrieval.
        ''' </summary>
        ''' <param name="SelectIfClause">A string containing the SQL condition.</param>
        ''' <remarks>Use the SelectIf event to set filter (WHERE clause) information that is applied each time data retrieval occurs.  
        ''' This filter is added regardless of whether a WHERE clause was specified for the retrieval or a Access event is used.
        ''' </remarks>
        ''' <example>
        ''' The example below specifies the additional filter criteria that is used for the EMPLOYEE record structure <br/>
        ''' This filter indicates that the STATUS_CODE of the EMPLOYEE record must be 'F' (Full Time) in order to be retrieved.<br/><br/>
        ''' Private Sub fleEMPLOYEE_SelectIf(ByRef SelectIfClause As String) Handles fleEMPLOYEE.SelectIf
        ''' <br/>
        '''     Try <br/>
        ''' <br/>
        '''         Dim strSQL As StringBuilder = New StringBuilder("") <br/>
        ''' <br/>
        '''         strSQL.Append(" WHERE EMPLOYEE.STATUS_CODE = 'F'") <br/>
        ''' <br/>
        '''         SelectIfClause = strSQL.ToString() <br/>
        ''' <br/>
        '''     Catch ex As CustomApplicationException <br/>
        ''' <br/>
        '''         Throw ex <br/>
        ''' <br/>
        '''     Catch ex As Exception <br/>
        ''' <br/>
        '''         ExceptionManager.Publish(ex) <br/>
        '''         Throw ex <br/>
        ''' <br/>
        '''     End Try <br/>
        ''' <br/>
        ''' End Sub <br/>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Event SelectIf(ByRef SelectIfClause As String)

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Event Choose(ByRef ChooseClause As String)

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Event ChooseViaIndex(ByRef ChooseClause As String)

        ''' --- InitializeItems ----------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	This event assigns an initial value to the named items. 
        ''' </summary>
        ''' <param name="Fixed">A Boolean indicating that this value will be used when updating the data record to the database even if this value was 
        ''' changed by the user or through code.</param>
        ''' <remarks>The InitializeItems event is raised when a new record is added to the record buffer and each time the data records are about to be updated
        ''' in the database using the PutData method.  
        ''' </remarks>
        ''' <note>
        ''' The InitializeItems event also handles the Renaissance Architect PreCompiler generated AutomaticItemInitialize method.
        ''' </note>
        ''' <example>
        '''Private Sub fleEMPLOYEE_InitializeItems(ByVal Fixed As Boolean) Handles fleEMPLOYEE.InitializeItems <br/>
        ''' <br/>
        '''    Try <br/>
        ''' <br/>
        '''        fleEMPLOYEE.SetValue("HIRE_CODE", Not Fixed) = "A" <br/>
        ''' <br/>
        '''        If Not Fixed Then fleEMPLOYEE.SetValue("START_DATE", True) = SysDate(m_cnnQUERY) + 14 <br/>
        ''' <br/>
        '''        fleEMPLOYEE.SetValue("BENEFIT_CODE", Not Fixed) = fleBENEFITS.GetStringValue("BENEFIT_CODE") <br/>
        ''' <br/>
        '''        If Not Fixed Then <br/>
        '''            If T_MALE_FLAG.Value = "Y" Then <br/>
        '''                fleEMPLOYEE.SetValue("GENDER", True) = "0001" <br/>
        '''            Else <br/>
        '''                fleEMPLOYEE.SetValue("GENDER", True) = "0002" <br/>
        '''            End If <br/>
        '''        End If <br/>
        ''' <br/>
        '''        If T_POSITION.Value <&gt; "0001" Then <br/>
        '''            fleEMPLOYEE.SetValue("POSITION", Not Fixed) = T_POSITION.Value <br/>
        '''        Else <br/>
        '''            fleEMPLOYEE.SetValue("POSITION", Not Fixed) = flePOSITION.GetStringValue("POSITION_CODE") <br/>
        '''        End If <br/>
        '''         <br/>
        '''    Catch ex As CustomApplicationException <br/>
        ''' <br/>
        '''        Throw ex <br/>
        ''' <br/>
        '''    Catch ex As Exception <br/>
        ''' <br/>
        '''        ' Write the exception to the event log and throw an error. <br/>
        '''        ExceptionManager.Publish(ex) <br/>
        '''        Throw ex <br/>
        ''' <br/>
        '''    End Try <br/>
        ''' <br/>
        '''End Sub 
        '''</example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Event InitializeItems(ByVal Fixed As Boolean)

        ''' --- SetItemFinals ------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	This event assigns a final value to the named items. 
        ''' </summary>
        ''' <remarks>The SetItemFinals event is raised prior to updating data records in the database, and is initiated by the PutData method.  
        ''' </remarks>
        ''' <example>
        '''Private Sub fleEMPLOYEE_SetItemFinals() Handles fleEMPLOYEE.SetItemFinals <br/>
        ''' <br/>
        '''    Try <br/>
        ''' <br/>
        '''        fleEMPLOYEE.SetValue("HIRE_CODE") = "A" <br/>
        '''         <br/>
        '''    Catch ex As CustomApplicationException <br/>
        ''' <br/>
        '''        Throw ex <br/>
        ''' <br/>
        '''    Catch ex As Exception <br/>
        ''' <br/>
        '''        ' Write the exception to the event log and throw an error. <br/>
        '''        ExceptionManager.Publish(ex) <br/>
        '''        Throw ex <br/>
        ''' <br/>
        '''    End Try <br/>
        ''' <br/>
        '''End Sub
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Event SetItemFinals()

        ''' --- Cursor -------------------------------------------------------------
        ''' <exclude/>
        ''' <summary>
        ''' 	Identifies and describes how a cursor, table, or view is used by the screen.
        ''' </summary>
        '''     <param name="SQLStatement">A valid conditional SQL statement.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Event Cursor(ByRef SQLStatement As String)

        ''' --- Balance ------------------------------------------------------------
        ''' <exclude/>
        ''' <summary>
        ''' 	Determines if another item has an equal value.
        ''' </summary>
        ''' <param name="Field">Field name of item.</param>
        ''' <param name="Value">Value of item field.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''      [Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Event Balance(ByVal Field As String, ByVal Value As Decimal)

        ''' --- SumInto ------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Adds all values entered into the item specified.
        ''' </summary>
        ''' <param name="Field">Field name of the item that will be summed.</param>
        ''' <param name="Value">Current value of item field.</param>
        ''' <param name="OldValue">Old value of the item field.</param>
        ''' <remarks>The SumInto event maintain the total of the item. This sum is automatically
        ''' <para>
        '''     <list type="bullet">
        '''         <item>incremented when values are entered</item>
        '''         <item>reduced when a data record containing the item is deleted</item>
        '''         <item>adjusted when the value is changed</item>
        '''     </list>
        ''' </para>
        ''' </remarks>
        ''' <example>
        ''' In the example below, the HOURS_WORKED value is summed into the TOTAL_HOURS field of the WORK_PERIOD structure.  By adding the 
        ''' (Value - OldValue) we are adjusting this value based on changes in the current field.  (ie. If the value was 10 and the new value is 5,
        ''' then we subtract 5 from TOTAL_HOURS). <br/><br/>
        '''    Private Sub fleBILLING_SumInto(ByVal Field As String, ByVal Value As Decimal, ByVal OldValue As Decimal) Handles fleBILLING.SumInto <br/>
        ''' <br/>
        '''    Try <br/>
        ''' <br/>
        '''        Select Case Field <br/>
        '''            Case "HOURS_WORKED" <br/>
        '''                fleWORK_PERIOD.SetValue("TOTAL_HOURS") = fleWORK_PERIOD.GetDecimalValue("TOTAL_HOURS") + (Value - OldValue) <br/>
        '''                Display(fldWORK_PERIOD_TOTAL_HOURS) <br/>
        '''        End Select <br/>
        ''' <br/>
        '''    Catch ex As CustomApplicationException <br/>
        ''' <br/>
        '''        Throw ex <br/>
        ''' <br/>
        '''    Catch ex As Exception <br/>
        ''' <br/>
        '''        ExceptionManager.Publish(ex) <br/>
        '''        Throw ex <br/>
        ''' <br/>
        '''    End Try <br/>
        ''' <br/>
        '''End Sub
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Event SumInto(ByVal Field As String, ByVal Value As Decimal, ByVal OldValue As Decimal)

        ''' --- CountInto ------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Maintains a count of the records entered.
        ''' </summary>
        ''' <param name="Value">The increment value.</param>
        ''' <remarks>The CountInto event maintains a count of the records entered. This count is automatically
        ''' <para>
        '''     <list type="bullet">
        '''         <item>incremented when records entered</item>
        '''         <item>reduced when a records are deleted</item>
        '''     </list>
        ''' </para>
        ''' The records are updated for File classes of type Delete when the PutData verb is executed.
        ''' </remarks>
        ''' <example>
        ''' In the example below, the EMPLOYEE record is counted into the EMP_COUNT field of the WORK_PERIOD structure.  <br/><br/>
        '''    Private Sub fleEMPLOYEE_SumInto(ByVal Field As String, ByVal Value As Decimal) Handles fleEMPLOYEE.SumInto <br/>
        ''' <br/>
        '''    Try <br/>
        ''' <br/>
        '''        fleWORK_PERIOD.SetValue("EMP_COUNT") = fleWORK_PERIOD.GetDecimalValue("EMP_COUNT") + Value <br/>
        '''        Display(fldWORK_PERIOD_EMP_COUNT) <br/>
        ''' <br/>
        '''    Catch ex As CustomApplicationException <br/>
        ''' <br/>
        '''        Throw ex <br/>
        ''' <br/>
        '''    Catch ex As Exception <br/>
        ''' <br/>
        '''        ExceptionManager.Publish(ex) <br/>
        '''        Throw ex <br/>
        ''' <br/>
        '''    End Try <br/>
        ''' <br/>
        '''End Sub
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Event CountInto(ByVal Value As Decimal)

        ''' --- GoToRecordEvent ----------------------------------------------------
        ''' <exclude/>
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Event GoToRecordEvent(ByVal Sender As Object, ByVal EventArgs As Object, ByVal NewRecordPosition As Integer) Implements IFileObject.GoToRecordEvent

        ''' --- AddRecordEvent -----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of AddRecordEvent.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Event AddRecordEvent(ByVal Sender As Object, ByVal EventArgs As Object, ByVal NewRecordPosition As Integer, ByVal IsGridNew As Boolean)

        ''' --- DeleteRecordEvent --------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of DeleteRecordEvent.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Event DeleteRecordEvent(ByVal Sender As Object, ByVal EventArgs As Object, ByVal NewRecordPosition As Integer)

        ''' --- EditRecordEvent ----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of EditRecordEvent.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Event EditRecordEvent(ByVal Sender As Object, ByVal EventArgs As Object, ByVal NewRecordPosition As Integer)

        Public Event Audit()
#End Region

        ''' --- ObjectOwners -------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of ObjectOwners.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Shared ObjectOwners As Hashtable

        ''' --- Varchar2Fields -----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Varchar2Fields.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Shared Varchar2Fields As ArrayList

        ''' --- m_strColumnsUsed ---------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_strColumnsUsed.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Private m_strColumnsUsed As String = "*"

        'Variables used in implementation of Lock / Unlock 
        ''' --- m_blnHasLock -------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnHasLock.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_blnHasLock As Boolean

        ''' --- m_ltLockTypes ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_ltLockTypes.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected m_ltLockTypes As LockTypes = LockTypes.NotSet

#End Region

#Region "Constructor and Destructor"

        ''' --- New ----------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' Initializes a new instance of the BaseFileObject class.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Sub New()

            ' Assign the AddressOf values.
            ReDim m_blnNewRecord(0)
            ReDim m_blnAlteredRecord(0)
            ReDim m_blnDeletedRecord(0)
            ReDim m_blnIsInitialized(0)
            ReDim m_blnCountIntoCalled(0)
            ReDim m_blnGridDeletedRecord(0)


            GetRecordBuffer = AddressOf Getter
            SetRecordBuffer = AddressOf Setter
            SetEditFlagValue = AddressOf SetEditFlag
            GetNewRecordStatus = AddressOf GetNewStatus
            GetFileTypeValue = AddressOf GetFileType

        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' <exclude/>
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

            If Owner = "SEQUENTIAL" Then
                If FileType = FileType.SequentialDataBase Then
                    FileType = FileType.DataFile
                Else
                    FileType = FileType.SubFile
                End If

            End If

            If FileType = FileType.TempFile Then m_IsTempTable = True
            If FileType = FileType.SubFile Then m_IsSubFile = True
            If FileType = FileType.SubFileTable Then m_IsSubFileKeepTable = True

            ' Initialize the values.
            m_intType = Type
            m_intOccurs = Occurs

            If m_IsSubFile Then
                m_strBaseName = BaseName
                If SubFileSchema() = "" Then
                    m_strOwner = Owner
                Else
                    m_strOwner = SubFileSchema()
                End If
            Else
                m_strBaseName = BaseName
                m_strOwner = Owner
            End If

            m_strAliasName = AliasName
            m_blnNoItems = NoItems
            m_blnNoAppend = NoAppend
            m_blnNoDelete = NoDelete
            m_intNeed = Need

            If AliasName = "" Then
                m_strRelation = BaseName
            Else
                m_strRelation = AliasName
            End If
            m_strTransactionName = TransactionName

            ' Initalize the record status flags
            ' for all occurrences.
            If Occurs = 0 Then
                ReDim m_blnNewRecord(0)
                ReDim m_blnAlteredRecord(0)
                ReDim m_blnDeletedRecord(0)
                ReDim m_blnIsInitialized(0)
                ReDim m_blnCountIntoCalled(0)
                ReDim m_blnGridDeletedRecord(0)
                m_blnNewRecord(0) = True

            Else
                ReDim m_blnNewRecord(Occurs - 1)
                ReDim m_blnAlteredRecord(Occurs - 1)
                ReDim m_blnDeletedRecord(Occurs - 1)
                ReDim m_blnIsInitialized(Occurs - 1)
                ReDim m_blnCountIntoCalled(Occurs - 1)
                ReDim m_blnGridDeletedRecord(Occurs - 1)
            End If

            GetRecordBuffer = AddressOf Getter
            SetRecordBuffer = AddressOf Setter
            SetEditFlagValue = AddressOf SetEditFlag
            GetNewRecordStatus = AddressOf GetNewStatus
            GetFileTypeValue = AddressOf GetFileType
        End Sub

#End Region

#Region "Properties"
        ''' --- FirstFileCount ---------------------------------------------------------
        ''' 
        ''' <summary>
        '''       
        ''' will be Optional.
        ''' </summary>
        ''' <remarks>
        ''' 
        ''' </remarks>
        ''' <history>
        '''       [Campbell]  6/16/2005   Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overridable Property FirstFileCount() As Integer
            Get
                Return Nothing
            End Get
            Set(ByVal Value As Integer)

            End Set
        End Property

        <Browsable(False),
      EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overridable ReadOnly Property SQLServerUseSchemas() As Boolean
            Get
                Return False
            End Get
        End Property

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public ReadOnly Property RecordCount() As Integer Implements IFileObject.RecordCount
            Get
                If IsNothing(m_dtbDataTable) Then
                    Return 0
                Else
                    Return m_dtbDataTable.Rows.Count
                End If
            End Get
        End Property


        Public Overridable Property m_dtbDataTable() As DataTable
            Get
                Return m_dtbBaseDataTable
            End Get
            Set(ByVal value As DataTable)
                m_dtbBaseDataTable = value
            End Set
        End Property

        ''' --- FirstOverrideCount ---------------------------------------------------------
        ''' 
        ''' <summary>
        '''       
        ''' will be Optional.
        ''' </summary>
        ''' <remarks>
        ''' 
        ''' </remarks>
        ''' <history>
        '''       [Campbell]  6/16/2005   Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overridable Property FirstOverrideCount() As Integer
            Get
                Return Nothing
            End Get
            Set(ByVal Value As Integer)

            End Set
        End Property

        ''' --- FromTables ---------------------------------------------------------
        ''' 
        ''' <summary>
        '''       
        ''' will be Optional.
        ''' </summary>
        ''' <remarks>
        ''' 
        ''' </remarks>
        ''' <history>
        '''       [Campbell]  6/16/2005   Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overridable Property FromTables() As String
            Get
                Return Nothing
            End Get
            Set(ByVal Value As String)

            End Set
        End Property
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overridable Property blnIsInSelectIf() As Boolean
            Get
                Return Nothing
            End Get
            Set(ByVal Value As Boolean)

            End Set
        End Property
        ''' --- blnIsInSelectIf ---------------------------------------------------------
        ''' 
        ''' <summary>
        '''       
        ''' will be Optional.
        ''' </summary>
        ''' <remarks>
        ''' 
        ''' </remarks>
        ''' <history>
        '''       [Campbell]  6/16/2005   Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overridable Property blnGlobalUseTableSelectIf() As BooleanTypes
            Get
                Return Nothing
            End Get
            Set(ByVal Value As BooleanTypes)

            End Set
        End Property

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overridable ReadOnly Property GotSQL() As BooleanTypes
            Get
                Return Nothing
            End Get
        End Property
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overridable Property QTPOrderBy() As String
            Get
                Return Nothing
            End Get
            Set(ByVal value As String)

            End Set
        End Property
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overridable Property GetSQL() As Boolean
            Get
                Return Nothing
            End Get
            Set(ByVal value As Boolean)

            End Set
        End Property
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overridable Property InChoose() As Boolean
            Get
                Return Nothing
            End Get
            Set(ByVal value As Boolean)

            End Set
        End Property
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overridable Property HasSort() As Boolean
            Get
                Return Nothing
            End Get
            Set(ByVal value As Boolean)

            End Set
        End Property
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overridable Property hsSQL() As Hashtable
            Get
                Return Nothing
            End Get
            Set(ByVal Value As Hashtable)

            End Set
        End Property
        ' Since we are looking through hsSQL using an enumerator, we cannot guarantee
        ' the same order as the items went in.  Therefore keep a second hashtable with
        ' an ordinal position and the key for hsSQL.
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overridable Property hsSQLEnum() As Hashtable
            Get
                Return Nothing
            End Get
            Set(ByVal Value As Hashtable)

            End Set
        End Property
        ''' --- SelectifColumn ---------------------------------------------------------
        ''' 
        ''' <summary>
        '''       
        ''' will be Optional.
        ''' </summary>
        ''' <remarks>
        ''' 
        ''' </remarks>
        ''' <history>
        '''       [Campbell]  6/16/2005   Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overridable Property SelectifColumn() As ArrayList
            Get
                Return Nothing
            End Get
            Set(ByVal Value As ArrayList)

            End Set
        End Property
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overridable Property RemoveSelectifColumn() As String
            Get
                Return Nothing
            End Get
            Set(ByVal Value As String)

            End Set
        End Property
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overridable Property AddSelectifColumn() As String
            Get
                Return Nothing
            End Get
            Set(ByVal Value As String)

            End Set
        End Property

        ''' --- Sql -------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	This property was added for Developers to indicate the SQL that
        ''' was last executed.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Friend ReadOnly Property Sql() As String
            Get
                Return m_strSQL
            End Get
        End Property

        ''' --- AccessIsOptional ---------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Gets or sets a value indicating that data retrieval using the Access event
        ''' will be Optional.
        ''' </summary>
        ''' <remarks>
        ''' This property should be set in the Init event of the Page if you wish to set
        ''' this property to True.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overridable Property AccessIsOptional() As Boolean
            Get
                Return m_blnAccessIsOptional
            End Get
            Set(ByVal Value As Boolean)
                m_blnAccessIsOptional = Value
            End Set
        End Property

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overridable Property FileNoRecords() As String
            Get
                Return Nothing
            End Get
            Set(ByVal value As String)

            End Set
        End Property

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overridable Property FileWhere() As Hashtable
            Get
                Return Nothing
            End Get
            Set(ByVal value As Hashtable)

            End Set
        End Property

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overridable ReadOnly Property CurrentFile() As String
            Get
                Return Nothing
            End Get
        End Property

        Private _createWhere As Boolean
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overridable ReadOnly Property CreateWhere() As Boolean
            Get
                Return Nothing
            End Get
        End Property


        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overridable Property WhereColumn() As ArrayList Implements IFileObject.WhereColumn
            Get
                Return Nothing
            End Get
            Set(ByVal value As ArrayList)

            End Set
        End Property

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overridable Property UseMemory() As Boolean
            Get
                Return Nothing
            End Get
            Set(ByVal value As Boolean)

            End Set
        End Property




        ''' --- DataReader ---------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Read-only recordset object used for REFERENCE files.
        ''' </summary>
        ''' <remarks>
        ''' Should be overridden in the derived class
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overridable Property DataReader() As IDataReader
            Get
                'Should be overrided in the derived class
                Return Nothing
            End Get
            Set(ByVal Value As IDataReader)
                'Should be overrided in the derived class
            End Set
        End Property

        ''' --- UsePutProcedures ---------------------------------------------------
        ''' <exclude/>
        ''' <summary>
        ''' 	Summary of UsePutProcedures.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected WriteOnly Property UsePutProcedures() As Boolean
            Set(ByVal Value As Boolean)
                m_blnUsePutProcedures = Value
            End Set
        End Property

        ''' --- AliasName ----------------------------------------------------------
        '''
        ''' <summary>
        '''     Gets or sets an alternative name for the record structure.
        ''' </summary>
        ''' <value>A string containing the alias name.</value>
        ''' <remarks>
        '''     Assigns an alternative name to a record-structure. When a record-structure
        ''' is declared more than once in a screen design, the AliasName
        ''' property assigns a unique identifier name for each declaration. It is recommended
        ''' to set the AliasName property in the constructor.
        ''' <para>
        ''' <note>Once an AliasName is assigned, subsequent references to the record-structure
        ''' must use this name.</note>
        ''' </para>
        ''' </remarks>
        ''' <example>
        '''    Private WithEvents fleEMPLOYEE_ALIAS As New Core.Windows.OracleFileObject(Me, FileTypes.Primary, 0, "ABCD", "EMPLOYEE", <b>"EMPLOYEE_ALIAS"</b>, False, False, True, 0, "m_trnTRANS_UPDATE")
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        '''     [Mark]      21/7/2005   Added more details in remarks and added an example.
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
        Description("Assigns an alternative name for the cursor"),
        Category("Core"),
        DefaultValue(""),
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Property AliasName() As String Implements IFileObject.AliasName
            Get
                Return m_strAliasName
            End Get
            Set(ByVal Value As String)
                m_strAliasName = Value

                m_strRelation = ReturnRelation()
            End Set
        End Property

        ''' --- IsTextFile --------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of IsTextFile.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Property IsTextFile() As Boolean
            Get
                Return m_IsTextFile
            End Get
            Set(ByVal Value As Boolean)
                m_IsTextFile = Value
            End Set
        End Property

        ''' --- AlteredRecord -----------------------------------------------------
        '''
        ''' <summary>
        ''' Gets or sets a value indicating if record has been altered or not.
        ''' </summary>
        ''' <param name="RowPosition"><i>Optional</i> A zero based integer value indicating which row to get or set.  Ommitting this value returns the current row's status.</param>
        ''' <value>A boolean indicating if record has been altered.</value>
        ''' <remarks>The current status of any file object can be determined using this condition.
        ''' <para>
        ''' <note>If the record status has changed, then the property Alteredrecord should be set to true.</note>
        ''' </para>
        ''' </remarks>
        ''' <example>
        ''' If fleEMPLOYEE.AlteredRecord Then <br/>
        '''     ErrorMessage("Cannot change employee record.") <br/>
        ''' End If
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        '''     [Mark]      21/7/2005   Added an example.
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Property AlteredRecord(ByVal RowPosition As Integer) As Boolean Implements IFileObject.AlteredRecord
            Get
                If RowPosition = -1 Then
                    RowPosition = Me.CurrentRow
                End If
                If RowPosition = -1 Then
                    Return False
                End If
                Return m_blnAlteredRecord(RowPosition)
            End Get
            Set(ByVal Value As Boolean)
                If RowPosition = -1 Then
                    RowPosition = Me.CurrentRow
                End If
                m_blnAlteredRecord(RowPosition) = Value
                If Value Then
                    Me.HasData = True
                End If
            End Set
        End Property
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Property AlteredRecord() As Boolean Implements IFileObject.AlteredRecord
            Get
                Return m_blnAlteredRecord(Me.CurrentRow)
            End Get
            Set(ByVal Value As Boolean)

                m_blnAlteredRecord(Me.CurrentRow) = Value
                If Value Then
                    Me.HasData = True
                End If
            End Set
        End Property

        ''' --- BaseName -----------------------------------------------------------
        '''
        ''' <summary>
        ''' Gets or sets the physical name for the record structure.
        ''' </summary>
        ''' <value>A string containing the name of the table.</value>
        ''' <remarks>
        '''     It is recommended to set the BaseName property in the constructor.  
        ''' </remarks>
        ''' <example>
        '''    Private WithEvents fleEMPLOYEE As New Core.Windows.OracleFileObject(Me, FileTypes.Primary, 0, "ABCD", <b>"EMPLOYEE"</b>, "", False, False, True, 0, "m_trnTRANS_UPDATE")
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        '''     [Mark]      21/7/2005   Added more details in remarks and added an example.
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
        Description("Assigns the physical name for the cursor"),
        Category("Core"),
        DefaultValue(""),
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Property BaseName() As String Implements IFileObject.BaseName
            Get
                Return m_strBaseName
            End Get
            Set(ByVal Value As String)
                m_strBaseName = Value

                m_strRelation = ReturnRelation()
            End Set
        End Property


        ' Connection property.
        '--------------------------
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets the Connection objects used to perform operations on the underlying data layer.
        ''' </summary>
        ''' <value>A Database Connection object.</value>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        ''' Protected Overrides Sub InitializeFiles() <br/>
        ''' <br/>
        '''     Try <br/>
        ''' <br/>
        '''         Initialize_TRANS_UPDATE() <br/>
        '''         fleEMPLOYEE.Connection = m_cnnQUERY <br/>
        ''' <br/>
        '''     Catch ex As CustomApplicationException <br/>
        ''' <br/>
        '''         Throw ex <br/>
        ''' <br/>
        '''     Catch ex As Exception <br/>
        ''' <br/>
        '''         ExceptionManager.Publish(ex) <br/>
        '''         Throw ex <br/>
        ''' <br/>
        '''     End Try <br/>
        ''' <br/>
        ''' End Sub
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        '''     [Mark]      21/7/2005   Added an example.
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
        Description("Connection objects to be used to perform operation with the underlying data layer"),
        Category("Core"),
        DefaultValue(""),
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overridable Property Connection() As IDbConnection Implements IFileObject.Connection
            Get
                'Should be overrided in the derived class
                Return Nothing
            End Get
            Set(ByVal Value As IDbConnection)
                'Should be overrided in the derived class
            End Set
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' Returns a boolean indicating whether a record is deleted or not.
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Friend ReadOnly Property GetDeletedRecord() As Boolean() Implements IFileObject.GetDeletedRecord
            Get
                Return m_blnDeletedRecord
            End Get
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' Returns a boolean indicating if the record is altered or not.
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Friend ReadOnly Property GetAlteredRecord() As Boolean() Implements IFileObject.GetAlteredRecord
            Get
                Return m_blnAlteredRecord
            End Get
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' Returns a boolean indicating whether the record is new or not.
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Friend ReadOnly Property GetNewRecord() As Boolean() Implements IFileObject.GetNewRecord
            Get
                Return m_blnNewRecord
            End Get
        End Property

        ' DeletedRecord property.
        '--------------------------
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets a value indicating that the current record is marked for deletion.
        ''' </summary>
        ''' <param name="RowPosition"><i>Optional</i> A zero based integer value indicating which row to get or set.  Ommitting this value returns the current row's status.</param>
        ''' <value></value>
        ''' <remarks>
        ''' <example>
        ''' Protected Overrides Function Delete() As Boolean <br/>
        ''' <br/>
        '''     Try <br/>
        ''' <br/>
        '''         fleEMPLOYEE.DeletedRecord = True <br/>
        ''' <br/>
        '''         Return True <br/>
        ''' <br/>
        '''     Catch ex As CustomApplicationException <br/>
        ''' <br/>
        '''         Throw ex <br/>
        ''' <br/>
        '''     Catch ex As Exception <br/>
        ''' <br/>
        '''         ExceptionManager.Publish(ex) <br/>
        '''         Throw ex <br/>
        ''' <br/>
        '''     End Try
        ''' <br/>
        ''' End Function
        ''' </example>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        '''     [Mark]      21/7/2005   Added an example.
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
        Description("Specifies if the current record buffer is set to removed the record in the data layer"),
        Category("Core"),
        DefaultValue(""),
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Property DeletedRecord(ByVal RowPosition As Integer) As Boolean
            Get
                If RowPosition = -1 Then
                    RowPosition = Me.CurrentRow
                End If
                Return m_blnDeletedRecord(RowPosition)
            End Get
            Set(ByVal Value As Boolean)
                If RowPosition = -1 Then
                    RowPosition = Me.CurrentRow
                End If
                m_blnDeletedRecord(RowPosition) = Value

                ' Only perform the following if DeletedRecord is set to True.
                If Value = True Then
                    ' If the DeletedRecord status is set (record is
                    ' marked for deletion), the AlteredRecord status
                    ' is set to TRUE.
                    If m_blnDeletedRecord(RowPosition) Then
                        AlteredRecord(RowPosition) = True

                        ' Call the SUM INTO and COUNT INTO options for non-DELETE files.
                        If Not Type = FileTypes.Delete Then
                            Dim intCount As Integer
                            Dim strFieldName As String
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
                        End If
                    End If

                    If Me.Occurs = 0 Then
                        CallDisplayForDelete()
                    End If
                End If

            End Set
        End Property

        <Bindable(False),
       Description("Specifies if the current record buffer is set to removed the record in the data layer"),
       Category("Core"),
       DefaultValue(""),
       EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Property DeletedRecord() As Boolean
            Get
                Dim RowPosition = Me.CurrentRow
                Return m_blnDeletedRecord(RowPosition)
            End Get
            Set(ByVal Value As Boolean)
                Dim RowPosition = Me.CurrentRow
                m_blnDeletedRecord(RowPosition) = Value

                ' Only perform the following if DeletedRecord is set to True.
                If Value = True Then
                    ' If the DeletedRecord status is set (record is
                    ' marked for deletion), the AlteredRecord status
                    ' is set to TRUE.
                    If m_blnDeletedRecord(RowPosition) Then
                        AlteredRecord(RowPosition) = True

                        ' Call the SUM INTO and COUNT INTO options for non-DELETE files.
                        If Not Type = FileTypes.Delete Then
                            Dim intCount As Integer
                            Dim strFieldName As String
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
                        End If
                    End If

                    If Me.Occurs = 0 Then
                        CallDisplayForDelete()
                    End If
                End If

            End Set
        End Property
        ' EOF property.
        '--------------------------
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Gets a boolean value indicating that the current record position is after the last record in a record structure.
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
        Description("Indicates that the current record position is after the last record in a cursor"),
        Category("Core"),
        DefaultValue(""),
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public ReadOnly Property EOF() As Boolean Implements IFileObject.EOF
            Get
                If m_intType = FileTypes.Reference Then
                    Return m_blnEOF
                Else
                    If m_dtbDataTable Is Nothing Then
                        Return True
                    Else
                        'if Current Row passes beyond the Rows in m_dtbDataTable or
                        'if Current Record is unaltered-new record consider it as EOF
                        'The implementation of "For" and "ForMissing" method relies on 
                        'this behaviour
                        If (Me.CurrentRow > m_dtbDataTable.Rows.Count - 1) OrElse (m_blnNewRecord(Me.CurrentRow) AndAlso (Not m_blnAlteredRecord(Me.CurrentRow))) Then
                            Return True
                        Else
                            Return False
                        End If
                    End If
                End If
            End Get
        End Property

        '--------------------------
        ' BOF property.
        '--------------------------
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Gets a boolean value indicating that the current record position is before the first record in a record structure.
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
        Description("Indicates that the current record position is before the first record in a cursor"),
        Category("Core"),
        DefaultValue(""),
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public ReadOnly Property BOF() As Boolean
            Get
                If m_intType = FileTypes.Reference Then
                    'Not supported in Reference file
                    Return True  'Always True
                Else
                    If m_dtbDataTable Is Nothing Then
                        Return True
                    Else
                        If Me.CurrentRow < 0 Then
                            'TODO: Needs to be tested 
                            Return True
                        Else
                            Return False
                        End If
                    End If
                End If
            End Get
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' Returns True if data has been retrieved from the data layer
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <Bindable(False),
        Description("Returns True if data has been retrieved from the data layer"),
        Category("Core"),
        DefaultValue(""),
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public ReadOnly Property DataFetched() As Boolean Implements IFileObject.DataFetched
            Get
                If m_dtbDataTable Is Nothing OrElse m_dtbDataTable.Rows.Count = 0 Then
                    Return False
                Else
                    Return True
                End If
            End Get
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' Added primarily to display a blank grid if no record found in GetData
        ''' </summary>
        ''' <value>A boolean used to indicate if file has records.</value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Property HasData() As Boolean Implements IFileObject.HasData
            Get
                Return m_HasData
            End Get
            Set(ByVal Value As Boolean)
                m_HasData = Value
            End Set
        End Property

        '--------------------------
        ' SumIntoFields property.
        '--------------------------
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Sets a string values with the fields that are SUM INTO fields.
        ''' </summary>
        ''' <value>A string representing the field names for the current file that are SUM INTO fields.</value>
        ''' <remarks>
        ''' The SumIntoFields property is used for File classes of type DELETE.  This sets the list of columns that 
        ''' are summed into other items which allows the framework to update those values when the file is deleted.
        ''' </remarks>
        ''' <example>
        ''' fleEMPLOYEE.SumIntoFields = "EMPLOYEE_SALARY,BENEFIT_AMOUNT"
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public WriteOnly Property SumIntoFields() As String
            Set(ByVal Value As String)
                m_arrSumIntoFields = Split(Value, ",")
            End Set
        End Property

        '--------------------------
        ' BalanceFields property.
        '--------------------------
        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' List of fields for the BALANCE option on the item statement.
        ''' </summary>
        ''' <value>A string representing field values.</value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public WriteOnly Property BalanceFields() As String
            Set(ByVal Value As String)
                m_arrBalanceFields = Split(Value, ",")
            End Set
        End Property

        '--------------------------
        ' Need property.
        '--------------------------
        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' Specifies the minimum number of occurrences of the data record to add to the 
        ''' file. At least this many occurrences must be declared on the screen.
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
        Description("Specifies the minimum number of occurrences of the data record to add to the file. At least this many occurrences must be declared on the screen."),
        Category("Core"),
        DefaultValue(""),
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Property Need() As Integer
            Get
                Return m_intNeed
            End Get
            Set(ByVal Value As Integer)
                m_intNeed = Value
            End Set
        End Property

        '--------------------------
        ' NewRecord property.
        '--------------------------
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets a boolean value indicating that the current record is a New record that has not been added to the database.
        ''' </summary>
        ''' <param name="RowPosition"><i>Optional</i> A zero based integer value indicating which row to get or set.  Ommitting this value returns the current row's status.</param>
        ''' <value></value>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        ''' Do While fleEMPLOYEE.For() <br/>
        '''     If fleEMPLOYEE.NewRecord Then <br/>
        '''         intEmpTotal = intEmpTotal + 1 <br/>
        '''     End If <br/>
        ''' Loop <br/>
        ''' Information("There are " + CStr(intEmpTotal) + " new employees.")
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        '''     [Mark]      21/7/2005   Added and example
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
     Description("Returns true if the record buffer will be used to insert a new record"),
     Category("Core"),
     DefaultValue(""),
     EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Property NewRecord() As Boolean Implements IFileObject.NewRecord
            Get
                Return m_blnNewRecord(Me.CurrentRow)
            End Get
            Set(ByVal Value As Boolean)
                m_blnNewRecord(Me.CurrentRow) = Value
            End Set
        End Property

        <Bindable(False),
        Description("Returns true if the record buffer will be used to insert a new record"),
        Category("Core"),
        DefaultValue(""),
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Property NewRecord(ByVal RowPosition As Integer) As Boolean Implements IFileObject.NewRecord
            Get
                If RowPosition = -1 Then
                    RowPosition = Me.CurrentRow
                End If
                Return m_blnNewRecord(RowPosition)
            End Get
            Set(ByVal Value As Boolean)
                If RowPosition = -1 Then
                    RowPosition = Me.CurrentRow
                End If
                m_blnNewRecord(RowPosition) = Value
            End Set
        End Property



        '--------------------------
        ' NoAppend property.
        '--------------------------
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Specifies if this File class supports appending new records.  
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' This is valid only for File classes of type PRIMARY.  The Renaissance Architect PreCompiler 
        ''' uses this property to determine whether the Append method or a call to this method is to be generated.
        ''' It is recommended to set the NoAppend property in the constructor.
        ''' </remarks>
        ''' <example>
        '''    Private WithEvents fleEMPLOYEE As New Core.Windows.OracleFileObject(Me, FileTypes.Primary, 0, "ABCD", "EMPLOYEE", "", False, <b>True</b>, False, 0, "m_trnTRANS_UPDATE")
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        '''     [Mark]      21/7/2005   Added more to the remarks, and added an example.
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
        Description("Specifies if the cursors supports appending new records"),
        Category("Core"),
        DefaultValue(""),
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Property NoAppend() As Boolean Implements IFileObject.NoAppend
            Get
                Return m_blnNoAppend
            End Get
            Set(ByVal Value As Boolean)
                m_blnNoAppend = Value
            End Set
        End Property

        '--------------------------
        ' NoDelete property.
        '--------------------------
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets a boolean indicating that the generation of the DeleteRecord is to be
        ''' suppressed in the Delete and DetailDelete methods.
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' It is recommended to set the NoDelete property in the constructor.
        ''' </remarks>
        ''' <example>
        '''    Private WithEvents fleEMPLOYEE As New Core.Windows.OracleFileObject(Me, FileTypes.Primary, 0, "ABCD", "EMPLOYEE", "", False, True, <b>False</b>, 0, "m_trnTRANS_UPDATE")
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        '''     [Mark]      21/7/2005   Added more to the remarks, and added an example.
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
        Description("Specifies if the cursors supports deleting records"),
        Category("Core"),
        DefaultValue(""),
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Property NoDelete() As Boolean Implements IFileObject.NoDelete
            Get
                Return m_blnNoDelete
            End Get
            Set(ByVal Value As Boolean)
                m_blnNoDelete = Value
            End Set
        End Property

        '--------------------------
        ' NoItems property.
        '--------------------------
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets a boolean value indicating that automatic item initialization
        ''' is to be suppressed for this File class.
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' It is recommended to set the NoItems property in the constructor.
        ''' </remarks>
        ''' <example>
        '''    Private WithEvents fleEMPLOYEE As New Core.Windows.OracleFileObject(Me, FileTypes.Primary, 0, "ABCD", "EMPLOYEE", "", <b>False</b>, True, False, 0, "m_trnTRANS_UPDATE")
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        '''     [Mark]      21/7/2005   Added more to the remarks, and added an example.
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
        Description("Specifies if the cursors supports automatic initialization for cursor’s items"),
        Category("Core"),
        DefaultValue(""),
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Property NoItems() As Boolean
            Get
                Return m_blnNoItems
            End Get
            Set(ByVal Value As Boolean)
                m_blnNoItems = Value
            End Set
        End Property

        '--------------------------
        ' Occurs property.
        '--------------------------
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets an integer value indicating the number of times this File class occurs.
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' It is recommended to set the Occurs property in the constructor.
        ''' </remarks>
        ''' <example>
        '''    Private WithEvents fleEMPLOYEE As New Core.Windows.OracleFileObject(Me, FileTypes.Primary, 0, "ABCD", "EMPLOYEE", "", False, True, False, <b>5</b>, "m_trnTRANS_UPDATE")
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        '''     [Mark]      21/7/2005   Added remarks, and added an example.
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
        Description("Repeats the data records on the screen"),
        Category("Core"),
        DefaultValue(""),
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Property Occurs() As Integer Implements IFileObject.Occurs
            Get
                Return m_intOccurs
            End Get
            Set(ByVal Value As Integer)
                m_intOccurs = Value
            End Set
        End Property

        '--------------------------
        ' BoundToGrid property
        ' This property gets set internally by Grid Control
        '--------------------------
        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' Indicates whether FileObject is bound to a grid.
        ''' </summary>
        ''' <value>A boolean representing whether or not FileObject is bound to a grid.</value>
        ''' <remarks>This property gets set internally by Grid Control.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <Bindable(False),
        Browsable(False),
        Description(""),
        Category("Core"),
        DefaultValue(""),
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Property BoundToGrid() As Boolean Implements IFileObject.BoundToGrid
            Get
                Return m_blnBoundToGrid
            End Get
            Set(ByVal Value As Boolean)
                m_blnBoundToGrid = Value
            End Set
        End Property

        '--------------------------
        ' CurrentRow property.
        ' Note: This Property is coded for documentation purpose only
        ' if should always be overrided and implemented in derived class
        ' as if there is any change it should be made in Derived Class 
        ' specific to Web or WinForms.
        '--------------------------
        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' Returns the position of the record in the cursor
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        '''     <note>This Property is coded for documentation purpose only
        '''         if should always be overrided and implemented in derived class
        '''         as if there is any change it should be made in Derived Class 
        '''         specific to Web or WinForms.
        '''     </note>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <Bindable(False),
        Description("Returns the position of the record in the cursor"),
        Category("Core"),
        DefaultValue(""),
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overridable ReadOnly Property CurrentRow() As Integer
            Get
                'If Me.Occurs > 0 Then
                '    'Should use the overrided CurrentRow Property in derived FileObject specific to Web/Windows
                'Else
                '    Return Me.m_intCurrentRow
                'End If
            End Get
        End Property

        ''' --- NoRecords ---------------------------------------------------------
        ''' 
        ''' <summary>
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overridable Property NoRecords() As Boolean
            Get

            End Get
            Set(ByVal Value As Boolean)

            End Set
        End Property

        '--------------------------
        ' CurrentRecordPosition property.
        ' Note: CurrentRecordPosition is meant to return Position of the record in
        ' underlying data store and not to be confused with CurrentRow which is meant to
        ' return the Row Position in retrieved records
        '
        ' At present CurrentRecordPosition is being used in GetData of SQLServerFileObject
        '--------------------------
        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' Represents the position of the record in underlying data layer.
        ''' </summary>
        ''' <value></value>
        ''' <remarks>CurrentRecordPosition is meant to return position of the record in
        ''' underlying data store.
        '''     <note>
        '''         Not to be confused with CurrentRow which is meant to
        '''         return the Row Position in retrieved records.
        '''     </note>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overridable Property CurrentRecordPosition() As Long
            Get
                Return m_intCurrentRecordPosition
            End Get
            Set(ByVal Value As Long)
                m_intCurrentRecordPosition = Value
            End Set
        End Property

        '--------------------------
        ' Owner property.
        '--------------------------
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Specifies the owner used to retrieve data from the physical underlying data
        ''' </summary>
        ''' <value>The owner of the table.</value>
        ''' <remarks>
        ''' It is recommended to set the Owner property in the constructor.
        ''' </remarks>
        ''' <example>
        '''    Private WithEvents fleEMPLOYEE As New Core.Windows.OracleFileObject(Me, FileTypes.Primary, 0, <b>"ABCD"</b>, "EMPLOYEE", "", False, True, False, 0, "m_trnTRANS_UPDATE")
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        '''     [Mark]      21/7/2005   Added remarks and an example.
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
        Description("Specifies the owner used to retrieve data from the physical underlying data"),
        Category("Core"),
        DefaultValue(""),
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Property Owner() As String
            Get
                Return m_strOwner
            End Get
            Set(ByVal Value As String)
                m_strOwner = Value
            End Set
        End Property

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
        Protected Overridable Sub AddMessage(ByVal Message As String, ByVal Type As MessageTypes, ByVal ParamArray Parameters() As Object)
            ' Must be overriden in OracleFileObject.
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        ''' Gets or sets a value indicating that the current record has been initialized
        ''' with values from the dictionary and/or item initialization.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Property IsInitialized(Optional ByVal Row As Integer = -1) As Boolean
            Get
                If Row = -1 Then Row = Me.CurrentRow
                Return m_blnIsInitialized(Row)
            End Get
            Set(ByVal Value As Boolean)
                If Row = -1 Then Row = Me.CurrentRow
                m_blnIsInitialized(Row) = Value
            End Set
        End Property

        ''' --- CheckStatusAndInitializeRecord ---------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of CheckStatusAndInitializeRecord.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Sub CheckStatusAndInitializeRecord()

            If IsQuiz Then
                Exit Sub
            End If

            ' Check the status of the file object and 
            ' create a new record buffer if necessary.
            CheckFileStatus()

            ' If the record has not been initialized, initialize it from the 
            ' dictionary and/or item intial statements.
            If ((NewRecord AndAlso Not IsInitialized()) _
            OrElse ((Type = FileTypes.Designer OrElse Type = FileTypes.Secondary) AndAlso Me.CurrentRow >= m_dtbDataTable.Rows.Count)) _
            AndAlso (Not IsQTP OrElse IsQTP AndAlso SortPhaseSet) Then

                If IsQTP AndAlso m_HasAt = False Then
                    m_Subtoal = New Hashtable
                End If

                ' If there is no blank row, then create one.
                If m_dtbDataTable.Rows.Count = 0 Then
                    AddBlankRecord(0)
                ElseIf Me.CurrentRow >= m_dtbDataTable.Rows.Count Then
                    For intCount As Integer = m_dtbDataTable.Rows.Count To Me.CurrentRow
                        AddBlankRecord(intCount)
                    Next
                End If

                ' Set to True here so that RaiseInitializeItems doesn't trigger
                ' this again.
                IsInitialized = True

                ' Set INITIAL values from the dictionary.
                If IsNothing(System.Configuration.ConfigurationManager.AppSettings("NoDictionary")) Then
                    InitializeFromDictionary()
                End If

                ' Set the Item INITIAL values.
                RaiseInitializeItems(False)
            End If

        End Sub

        Public Overridable Sub CallDisplayForDelete()

        End Sub

        Protected Function SubFileSchema() As String
            Return System.Configuration.ConfigurationManager.AppSettings("SubFileSchema") & ""
        End Function


        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public ReadOnly Property Columns() As Data.DataColumnCollection
            Get
                If IsNothing(m_dtbDataTable) AndAlso Not Me.m_IsSubFile Then
                    CreateEmptyStructure(True)
                    m_dtbDataTable.Clear()
                    GetMetaData()
                End If

                Return m_dtbDataTable.Columns
            End Get
        End Property


        '--------------------------
        ' SetEditField property.
        '--------------------------
        ''' -----------------------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' Used to set the current field on which the Edit procedure is executing.
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        '''     [Mark]      21/7/2005   Added remarks and an example.
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Property SetEditField() As String
            Get
                Return m_strEditField
            End Get
            Set(ByVal Value As String)
                m_strEditField = Value
            End Set
        End Property

        '--------------------------
        ' SetValue property.
        '--------------------------
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Assigns a value to the specified field in the record structure.
        ''' </summary>
        ''' <param name="Field"><i>Required</i> A string representing the field name to reference.</param>
        ''' <param name="Initial"><i>Optional</i> A boolean indicating that an initial value is being assigned (which does not change the AlteredRecord status).</param>
        ''' <value>An object containing the value.</value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public WriteOnly Property SetValue(ByVal Field As String, ByVal Initial As Boolean) As Object
            Set(ByVal Value As Object)

                If m_intType <> FileTypes.Reference Then

                    ' Check the file status and intialize the record if necessary.
                    CheckStatusAndInitializeRecord()

                    Dim intCurrentRow As Integer
                    intCurrentRow = Me.CurrentRow

                    If m_blnDeletedRecord(intCurrentRow) AndAlso Not m_blnAlteredRecord(intCurrentRow) Then
                        If m_blnHasLock Then Me.Unlock(m_ltLockTypes)
                        AddMessage("An attempt was made to access a record that has already been deleted: ({0}).", MessageTypes.Error, ReturnRelation) 'IM.DeletedUnAlteredRecord
                    End If

                    Select Case m_dtbDataTable.Columns(Field).DataType.ToString
                        Case "System.String"
                            Dim strValue As String
                            ' Cast the value to a String type.
                            strValue = CType(Value, String)
                            ' Only assign the value if the value is different.
                            If m_dtbDataTable.Rows(intCurrentRow).Item(Field) Is System.DBNull.Value Then
                                m_dtbDataTable.Rows(intCurrentRow).Item(Field) = ReturnStringBasedOnColumnInformation(Field, strValue)
                                MarkAsAltered(Field, Initial)
                            Else
                                If NULL(CType(m_dtbDataTable.Rows(intCurrentRow).Item(Field), String)) <> NULL(strValue) Then
                                    m_dtbDataTable.Rows(intCurrentRow).Item(Field) = ReturnStringBasedOnColumnInformation(Field, strValue)
                                    MarkAsAltered(Field, Initial)
                                End If
                            End If
                        Case "System.DateTime"
                            Dim dteValue As DateTime

                            ' Determine if the date passed in
                            ' is a number or a date.
                            If IsNumeric(Value) Then
                                dteValue = GetDateFromYYYYMMDDDecimal(CType(Value, Decimal))
                            Else
                                ' Cast the value to a DateTime type.
                                dteValue = CType(Value, DateTime)
                            End If

                            ' Only assign the value if the value is different.
                            If m_dtbDataTable.Rows(intCurrentRow).Item(Field) Is System.DBNull.Value Then
                                If dteValue <> cZeroDate Then
                                    m_dtbDataTable.Rows(intCurrentRow).Item(Field) = dteValue
                                    ' If not setting an INITIAL value, set AlteredRecord to TRUE.
                                    MarkAsAltered(Field, Initial)
                                End If
                            Else
                                If CType(m_dtbDataTable.Rows(intCurrentRow).Item(Field), DateTime) <> dteValue Then
                                    m_dtbDataTable.Rows(intCurrentRow).Item(Field) = dteValue
                                    MarkAsAltered(Field, Initial)
                                End If
                            End If
                        Case "System.Decimal", "System.Double", "System.Int16", "System.Int32", "System.Int64"
                            Dim dblValue As Decimal
                            Dim dblOldValue As Decimal

                            ' Cast the value to a Decimal type.
                            dblValue = CType(Value, Decimal)
                            If dblValue = 1 / 0 Then dblValue = 0
                            ' Only assign the value if the value is different.
                            If m_dtbDataTable.Rows(intCurrentRow).Item(Field) Is System.DBNull.Value Then
                                dblOldValue = 0
                                m_dtbDataTable.Rows(intCurrentRow).Item(Field) = dblValue
                                MarkAsAltered(Field, Initial)
                            Else
                                If CType(m_dtbDataTable.Rows(intCurrentRow).Item(Field), Decimal) <> dblValue Then
                                    dblOldValue = CType(m_dtbDataTable.Rows(intCurrentRow).Item(Field), Decimal)
                                    m_dtbDataTable.Rows(intCurrentRow).Item(Field) = dblValue
                                    MarkAsAltered(Field, Initial)
                                Else
                                    dblOldValue = CType(m_dtbDataTable.Rows(intCurrentRow).Item(Field), Decimal)
                                End If
                            End If

                            If (Me.NewRecord(intCurrentRow) AndAlso Not Me.AlteredRecord(intCurrentRow)) Then
                                'Ignore "INITIAL" value, while calculating SUM INTO
                                dblOldValue = 0
                            End If

                            ' Call the Balance and SumInto options on the ITEM statement.
                            ' NOTE: We are passing in dblValue - dblOldValue in order to 
                            ' account for the user changing (adjusting) values
                            RaiseEvent SumInto(Field, dblValue, dblOldValue)
                        Case "System.Boolean"
                            Dim blnValue As Boolean

                            If Not IsNothing(Value) AndAlso (Value.ToString.ToUpper = "F" OrElse Value.ToString.ToUpper = "FALSE") Then
                                blnValue = False
                            ElseIf Not IsNothing(Value) AndAlso (Value.ToString.ToUpper = "T" OrElse Value.ToString.ToUpper = "TRUE") Then
                                blnValue = True
                            Else
                                ' Cast the value to a String type.
                                blnValue = CType(Value, Boolean)
                            End If

                            ' Only assign the value if the value is different.
                            If m_dtbDataTable.Rows(intCurrentRow).Item(Field) Is System.DBNull.Value Then
                                m_dtbDataTable.Rows(intCurrentRow).Item(Field) = blnValue
                                MarkAsAltered(Field, False)
                            Else
                                If CType(m_dtbDataTable.Rows(intCurrentRow).Item(Field), Boolean) <> blnValue Then
                                    m_dtbDataTable.Rows(intCurrentRow).Item(Field) = blnValue
                                    MarkAsAltered(Field, Initial)
                                End If
                            End If
                        Case "System.Byte[]"
                            ' Allows us to write a record.
                            MarkAsAltered(Field, Initial)


                    End Select

                End If

            End Set
        End Property

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public WriteOnly Property SetValue(ByVal Field As String) As Object
            Set(ByVal Value As Object)

                If m_intType <> FileTypes.Reference Then

                    ' Check the file status and intialize the record if necessary.
                    CheckStatusAndInitializeRecord()

                    Dim intCurrentRow As Integer
                    intCurrentRow = Me.CurrentRow

                    If m_blnDeletedRecord(intCurrentRow) AndAlso Not m_blnAlteredRecord(intCurrentRow) Then
                        If m_blnHasLock Then Me.Unlock(m_ltLockTypes)
                        AddMessage("An attempt was made to access a record that has already been deleted: ({0}).", MessageTypes.Error, ReturnRelation) 'IM.DeletedUnAlteredRecord

                    End If

                    Select Case m_dtbDataTable.Columns(Field).DataType.ToString
                        Case "System.String"
                            Dim strValue As String
                            ' Cast the value to a String type.
                            strValue = CType(Value, String)
                            ' Only assign the value if the value is different.
                            If m_dtbDataTable.Rows(intCurrentRow).Item(Field) Is System.DBNull.Value Then
                                m_dtbDataTable.Rows(intCurrentRow).Item(Field) = ReturnStringBasedOnColumnInformation(Field, strValue)
                                MarkAsAltered(Field, False)
                            Else
                                If NULL(CType(m_dtbDataTable.Rows(intCurrentRow).Item(Field), String)) <> NULL(strValue) Then
                                    m_dtbDataTable.Rows(intCurrentRow).Item(Field) = ReturnStringBasedOnColumnInformation(Field, strValue)
                                    MarkAsAltered(Field, False)
                                End If
                            End If
                        Case "System.DateTime"
                            Dim dteValue As DateTime

                            ' Determine if the date passed in
                            ' is a number or a date.
                            If IsNumeric(Value) Then
                                dteValue = GetDateFromYYYYMMDDDecimal(CType(Value, Decimal))
                            Else
                                ' Cast the value to a DateTime type.
                                dteValue = CType(Value, DateTime)
                            End If

                            ' Only assign the value if the value is different.
                            If m_dtbDataTable.Rows(intCurrentRow).Item(Field) Is System.DBNull.Value Then
                                If dteValue <> cZeroDate Then
                                    m_dtbDataTable.Rows(intCurrentRow).Item(Field) = dteValue
                                    ' If not setting an INITIAL value, set AlteredRecord to TRUE.
                                    MarkAsAltered(Field, False)
                                End If
                            Else
                                If CType(m_dtbDataTable.Rows(intCurrentRow).Item(Field), DateTime) <> dteValue Then
                                    m_dtbDataTable.Rows(intCurrentRow).Item(Field) = dteValue
                                    MarkAsAltered(Field, False)
                                End If
                            End If
                        Case "System.Decimal", "System.Double", "System.Int16", "System.Int32", "System.Int64"
                            Dim dblValue As Decimal
                            Dim dblOldValue As Decimal

                            If Value.GetType.ToString = "System.String" AndAlso Value = "" Then Value = 0
                            ' Cast the value to a Decimal type.
                            dblValue = CType(Value, Decimal)
                            If dblValue = 1 / 0 Then dblValue = 0
                            ' Only assign the value if the value is different.
                            If m_dtbDataTable.Rows(intCurrentRow).Item(Field) Is System.DBNull.Value Then
                                dblOldValue = 0
                                m_dtbDataTable.Rows(intCurrentRow).Item(Field) = dblValue
                                If dblOldValue <> dblValue Then
                                    MarkAsAltered(Field, False)
                                End If
                            Else
                                If CType(m_dtbDataTable.Rows(intCurrentRow).Item(Field), Decimal) <> dblValue Then
                                    dblOldValue = CType(m_dtbDataTable.Rows(intCurrentRow).Item(Field), Decimal)
                                    m_dtbDataTable.Rows(intCurrentRow).Item(Field) = dblValue
                                    MarkAsAltered(Field, False)
                                Else
                                    dblOldValue = CType(m_dtbDataTable.Rows(intCurrentRow).Item(Field), Decimal)
                                End If
                            End If

                            If (Me.NewRecord(intCurrentRow) AndAlso Not Me.AlteredRecord(intCurrentRow)) Then
                                'Ignore "INITIAL" value, while calculating SUM INTO
                                dblOldValue = 0
                            End If

                            ' Call the Balance and SumInto options on the ITEM statement.
                            ' NOTE: We are passing in dblValue - dblOldValue in order to 
                            ' account for the user changing (adjusting) values
                            RaiseEvent SumInto(Field, dblValue, dblOldValue)
                        Case "System.Boolean"
                            Dim blnValue As Boolean

                            If Not IsNothing(Value) AndAlso (Value.ToString.ToUpper = "F" OrElse Value.ToString.ToUpper = "FALSE") Then
                                blnValue = False
                            ElseIf Not IsNothing(Value) AndAlso (Value.ToString.ToUpper = "T" OrElse Value.ToString.ToUpper = "TRUE") Then
                                blnValue = True
                            Else
                                ' Cast the value to a String type.
                                blnValue = CType(Value, Boolean)
                            End If

                            ' Only assign the value if the value is different.
                            If m_dtbDataTable.Rows(intCurrentRow).Item(Field) Is System.DBNull.Value Then
                                m_dtbDataTable.Rows(intCurrentRow).Item(Field) = blnValue
                                MarkAsAltered(Field, False)
                            Else
                                If CType(m_dtbDataTable.Rows(intCurrentRow).Item(Field), Boolean) <> blnValue Then
                                    m_dtbDataTable.Rows(intCurrentRow).Item(Field) = blnValue
                                    MarkAsAltered(Field, False)
                                End If
                            End If
                        Case "System.Byte[]"
                            ' Allows us to write a record.
                            MarkAsAltered(Field, False)


                    End Select

                End If

            End Set
        End Property

        '--------------------------
        ' SetParent property.
        '--------------------------
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Assigns a value to the specified parent field in the record structure.
        ''' </summary>
        ''' <param name="ParentField"><i>Required</i> A string representing the parent field name (structure) to update.</param>
        ''' <param name="StructureOffset"><i>Required</i> An integer representing the starting characher position in ParentField that will be updated.</param>
        ''' <param name="FieldSize"><i>Required</i> An integer representing the length of characters in ParentField that will be updated.</param>
        ''' <param name="Initial"><i>Optional</i> A boolean indicating that an initial value is being assigned (which does not change the AlteredRecord status).</param>
        ''' <value>An object containing the new value.</value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[GlennA]	29-oct-2007	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public WriteOnly Property SetParentValue(ByVal ParentField As String, ByVal StructureOffset As Integer, ByVal FieldSize As Integer, Optional ByVal Initial As Boolean = False) As Object
            'Public WriteOnly Property SetValue(ByVal Field As String, Optional ByVal Initial As Boolean = False) As Object
            Set(ByVal Value As Object)

                If m_intType <> FileTypes.Reference Then

                    ' Check the file status and intialize the record if necessary.
                    CheckStatusAndInitializeRecord()

                    Dim intCurrentRow As Integer
                    intCurrentRow = Me.CurrentRow

                    If m_blnDeletedRecord(intCurrentRow) AndAlso Not m_blnAlteredRecord(intCurrentRow) Then
                        If m_blnHasLock Then Me.Unlock(m_ltLockTypes)
                        AddMessage("An attempt was made to access a record that has already been deleted: ({0}).", MessageTypes.Error, ReturnRelation) 'IM.DeletedUnAlteredRecord
                    End If

                    Select Case m_dtbDataTable.Columns(ParentField).DataType.ToString
                        Case "System.String"
                            Dim m_OldValue As String
                            Dim m_NewValue As String
                            m_OldValue = ReturnStringBasedOnColumnInformation(ParentField, CType(m_dtbDataTable.Rows(intCurrentRow).Item(ParentField), String))
                            m_NewValue = Left(m_OldValue, StructureOffset) + Value.ToString.PadRight(FieldSize, " ") + Right(m_OldValue, Len(m_OldValue) - StructureOffset - FieldSize)

                            Dim strValue As String
                            ' Cast the value to a String type.
                            strValue = CType(Value, String)
                            ' Only assign the value if the value is different.
                            If m_dtbDataTable.Rows(intCurrentRow).Item(ParentField) Is System.DBNull.Value Then
                                m_dtbDataTable.Rows(intCurrentRow).Item(ParentField) = ReturnStringBasedOnColumnInformation(ParentField, m_NewValue)
                                MarkAsAltered(ParentField, Initial)
                            Else
                                If NULL(CType(m_dtbDataTable.Rows(intCurrentRow).Item(ParentField), String)) <> NULL(m_NewValue) Then
                                    m_dtbDataTable.Rows(intCurrentRow).Item(ParentField) = ReturnStringBasedOnColumnInformation(ParentField, m_NewValue)
                                    MarkAsAltered(ParentField, Initial)
                                End If
                            End If
                        Case "System.DateTime"
                        Case "System.Decimal", "System.Double", "System.Int32", "System.Int64"
                    End Select

                End If

            End Set
        End Property

        'gna

        '--------------------------
        ' Transaction property.
        '--------------------------
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Transaction used in transactional operations with the data layer
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' It is recommended to set the Transaction property in the constructor.
        ''' </remarks>
        ''' <example>
        '''    Private WithEvents fleEMPLOYEE As New Core.Windows.OracleFileObject(Me, FileTypes.Primary, 0, "ABCD", "EMPLOYEE", "", False, True, False, 0, <b>"m_trnTRANS_UPDATE"</b>)
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        '''     [Mark]      21/7/2005   Added remarks and an example.
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
        Description("Transaction used in transactional operations with the data layer"),
        Category("Core"),
        DefaultValue(""),
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overridable Property Transaction() As IDbTransaction Implements IFileObject.Transaction
            Get
                'Should be overrided in the derived class
                Return Nothing
            End Get
            Set(ByVal Value As IDbTransaction)
                'Should be overrided in the derived class
            End Set
        End Property

        '--------------------------
        ' Type property.
        '--------------------------
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Specifies the relationship of the record structure to the screen and to other File classes.
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' It is recommended to set the Type property in the constructor.
        ''' </remarks>
        ''' <example>
        '''    Private WithEvents fleEMPLOYEE As New Core.Windows.OracleFileObject(Me, <b>FileTypes.Primary</b>, 0, "ABCD", "EMPLOYEE", "", False, True, False, 0, "m_trnTRANS_UPDATE")
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        '''     [Mark]      21/7/2005   Added remarks and an example.
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
        Description("Specifies the relationship of the cursor to the screen and to other files and cursors"),
        Category("Core"),
        DefaultValue(""),
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Property Type() As FileTypes Implements IFileObject.Type
            Get
                Return m_intType
            End Get
            Set(ByVal Value As FileTypes)
                m_intType = Value
            End Set
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <Bindable(False),
        Description(""),
        Category("Core"),
        DefaultValue(""),
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public ReadOnly Property GoToRecordEventHandler() As IFileObject.GoToRecordEventEventHandler
            Get
                Return GoToRecordEventEvent
            End Get
        End Property

        ' UnderlyingDataTable Property
        ' Grid relies on this property to initially bind records
        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' Retrieves the underlying DataTable object
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <Bindable(False),
        Description("Retrieves the underlying DataTable object"),
        Category("Core"),
        DefaultValue(""),
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public ReadOnly Property UnderlyingDataTable() As DataTable Implements IFileObject.UnderlyingDataTable
            Get
                Return m_dtbDataTable
            End Get
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <Browsable(False),
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overridable Property HasLastGetData() As Boolean
            'HasLastGetData gets set in GetDataInternal and gets reset in base page's FileForRecordStatus method
            Get
                Return m_blnHasLastGetData
            End Get
            Set(ByVal Value As Boolean)
                m_blnHasLastGetData = Value
            End Set
        End Property

        ''' --- ColumnsUsed --------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of ColumnsUsed.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Property ColumnsUsed() As String
            Get
                Return m_strColumnsUsed
            End Get
            Set(ByVal Value As String)
                m_strColumnsUsed = Value
            End Set
        End Property

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overridable ReadOnly Property IsQuiz() As Boolean
            Get
                Return Nothing
            End Get
        End Property


        ''' <summary>
        ''' 	Summary of IsQTP.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overridable ReadOnly Property IsParallel() As Boolean
            Get

            End Get
        End Property
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of IsQTP.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overridable ReadOnly Property IsQTP() As Boolean
            Get

            End Get
        End Property


        ''' --- AuditStatus ----------------------------------------------
        ''' <exclude/>
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public ReadOnly Property AuditStatus(Optional ByVal RowPosition As Integer = -1) As String Implements IFileObject.AuditStatus
            Get
                If RowPosition = -1 Then RowPosition = Me.CurrentRow

                If NewRecord(RowPosition) Then
                    Return "N"
                ElseIf DeletedRecord(RowPosition) Then
                    Return "D"
                Else
                    Return "C"
                End If

            End Get
        End Property

#End Region

#Region "Methods"

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overridable Function Exists() As Boolean
            Try

                Dim RowPosition As Integer = Me.CurrentRow

                If IsQTP AndAlso IsAt Then
                    RowPosition = m_intSortNextOccurence
                End If

                If IsNothing(m_dtbDataTable) Then
                    Return False
                ElseIf m_dtbDataTable.Columns.Contains("ROWID") Then
                    If m_dtbDataTable.Rows.Count - 1 < RowPosition Then
                        Return False
                    End If

                    Return m_dtbDataTable.Rows(RowPosition).Item("ROWID").ToString.TrimEnd <> "" AndAlso m_dtbDataTable.Rows(RowPosition).Item("ROWID").ToString.TrimEnd <> "0"
                ElseIf m_dtbDataTable.Columns.Contains("ROW_ID") Then
                    If m_dtbDataTable.Rows.Count - 1 < RowPosition Then
                        Return False
                    End If

                    Return m_dtbDataTable.Rows(RowPosition).Item("ROW_ID").ToString.TrimEnd <> "" AndAlso m_dtbDataTable.Rows(RowPosition).Item("ROW_ID").ToString.TrimEnd <> "0"
#If TARGET_DB = "INFORMIX" Then
                ElseIf IsQuiz AndAlso m_dtbDataTable.Columns.Contains(Me.ReturnRelation & "_" & Me.ReturnRelation & "_ID") Then
                    Return Not IsNull(m_dtbDataTable.Rows(RowPosition).Item(Me.ReturnRelation & "_" & Me.ReturnRelation & "_ID"))
#End If
                ElseIf IsQTP Then
                    Return blnExists
                End If

                Return False
            Catch ex As Exception
                Return False
            End Try
        End Function
        ''' ---GetFieldText -------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' Retrieves the value from FieldText.
        ''' </summary>
        ''' <returns>A string.</returns>
        ''' <remarks>This method is used when retrieving a value from the record buffer for a given
        ''' field that is currently being edited (having the EDIT procedure execute on it).
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/8/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overridable Function GetFieldText() As String
            ' To be overriden.
            Return ""
        End Function

        ''' ---GetFieldValue -------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' Retrieves the value from FieldValue.
        ''' </summary>
        ''' <returns>A string.</returns>
        ''' <remarks>This method is used when retrieving a value from the record buffer for a given
        ''' field that is currently being edited (having the EDIT procedure execute on it).
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/8/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overridable Function GetFieldValue() As Decimal
            ' To be overriden.
            Return 0D
        End Function

        ''' ---FileIsAltered--------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' Checks whether any record has been altered on page.
        ''' </summary>
        ''' <returns>A boolean.</returns>
        ''' <remarks>This method is called by the CheckAlteredFlag event in the Oracle/SqlServer 
        ''' FileObject. The result is used to set the page's IsDirty flag.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/8/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Function FileIsAltered() As Boolean

            Dim intOccurs As Integer = Occurs
            If intOccurs = 0 Then intOccurs = 1

            For i As Integer = 0 To intOccurs - 1
                If Not IsNothing(m_blnAlteredRecord) AndAlso m_blnAlteredRecord.Length > i AndAlso m_blnAlteredRecord(i) Then
                    Return True
                    Exit For
                End If
            Next

            Return False

        End Function

        ''' ---CallReset--------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' Clears the record buffer and adds an empty row.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/8/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Sub CallReset()

            ' Clear the rows.			
            ResetRowAt(m_dtbDataTable, Me.CurrentRow)

        End Sub

        ''' ---SortOn--------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' Sets the field to sort on.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/8/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Sub SortOn(ByVal fieldName As String, Optional ByVal sortType As SortType = SortType.Ascending)

            m_sortOnField = fieldName
            m_sorttype = sortType

        End Sub

        ''' ---ReInitialize--------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' Initializes the record buffers.
        ''' </summary>
        ''' <remarks>
        ''' NOTE: This is called only from Ghost screens for improved performance.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/8/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Sub ReInitialize()

            ' Initalize the record status flags
            ' for all occurrences.
            If Occurs = 0 Then
                ReDim m_blnNewRecord(0)
                ReDim m_blnAlteredRecord(0)
                ReDim m_blnDeletedRecord(0)
                ReDim m_blnIsInitialized(0)
                ReDim m_blnCountIntoCalled(0)
                ReDim m_blnGridDeletedRecord(0)
            Else
                ReDim m_blnNewRecord(Occurs - 1)
                ReDim m_blnAlteredRecord(Occurs - 1)
                ReDim m_blnDeletedRecord(Occurs - 1)
                ReDim m_blnIsInitialized(Occurs - 1)
                ReDim m_blnCountIntoCalled(Occurs - 1)
                ReDim m_blnGridDeletedRecord(Occurs - 1)
            End If

            m_strLastSQL = String.Empty
            m_dtbDataTable = Nothing
            m_blnEOF = False
            m_blnHasLastGetData = False
            m_blnDontAlter = False
            m_blnExecutedPrimaryDetailFor = False
            m_blnForMissing = False
            m_blnGetDataForMissing = False
            m_blnErrorInLastRecord = False
            m_blnFor = False
            m_blnGetDataFor = False
            m_intCurrentRecordPosition = -1
            If Not blnInForLoop Then
                m_hstNestedForInfo = Nothing
                m_strLastForID = String.Empty
                m_intLastForIDNumber = -1
                m_sorNestedForIDs = Nothing
            End If
            m_intRecordsToFillInFindOrDetailFind = 0
            m_blnSkipError = False
            m_HasData = False
            m_blnCallGetDataInWhileRetrieving = True
            m_blnIsWhileRetrieving = False
            m_blnFirstWhileRetrievingExecuted = False

        End Sub

        ''' --- SetAccessOkOnPage --------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of SetAccessOkOnPage.
        ''' </summary>
        ''' <param name="AccessOk"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overridable Sub SetAccessOkOnPage(ByVal AccessOk As Boolean)
            'Should be overrided in the derived FileObjects
        End Sub

        ''' ---AddRecord--------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' Adds a new record to the datatable for Primary, Secondary, or Detail files.
        ''' </summary>
        ''' <param name="RaiseEvents"><i>Optional</i> A boolean.</param>
        ''' <param name="IsGridNew"><i>Optional</i> A boolean.</param>
        ''' <returns>A boolean.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        '''     <code>
        '''         AddRecord()
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/8/2005	Created
        '''     [Mayur]     29/08/2005  Changed to insert new record in case of a "Designer" File
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overloads Function AddRecord(Optional ByVal RaiseEvents As Boolean = False, Optional ByVal IsGridNew As Boolean = False) As Boolean

            If m_intType = FileTypes.Primary OrElse m_intType = FileTypes.Detail OrElse m_intType = FileTypes.Secondary OrElse m_intType = FileTypes.Designer Then
                'Now also adding new record in case of "Designer" Files, this is specifically to handle a case
                'where "Designer" file occurs with other file (of any type), legacy adds a record, initializes and sets NewRecord Status to "True"
                'Changed for QKCD8131, Freightways on 29/08/2005

                Dim blnRecordAdded As Boolean

                ' In case of an Append which clears all Rows from the grid, should also clear
                ' all rows from the relevant FileObjects
                If IsGridNew Then
                    m_dtbDataTable.Rows.Clear()
                End If

                ' If the file has not been opened (ie. is nothing), 
                ' then open an empty record structure.
                If m_dtbDataTable Is Nothing Then
                    CreateEmptyStructure(True)
                    blnRecordAdded = True
                Else
                    If m_dtbDataTable.Rows.Count < m_blnNewRecord.Length Then
                        CreateNewRow(m_dtbDataTable)
                    End If
                    m_blnNewRecord(Me.CurrentRow) = True
                    blnRecordAdded = True
                End If

                If blnRecordAdded Then
                    RaiseEvent AddRecordEvent(Me, Nothing, Me.CurrentRow, IsGridNew)
                End If

            End If

        End Function

        ''' ---AddRecord--------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="Sender"><i>Required</i> A Sender object.</param>
        ''' <param name="EventArgs"><i>Required</i> An Event Argument object.</param>
        ''' <param name="NewRecordPosition"><i>Optional</i> An integer representing the new record position.</param>
        ''' <param name="IsGridNew"><i>Optional</i> A boolean indicating if we are adding to a new grid.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/8/2005	Created
        '''     [Mayur]     29/08/2005  Changed to insert new record in case of a "Designer" File
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overloads Sub AddRecord(ByVal Sender As Object, ByVal EventArgs As Object, Optional ByVal NewRecordPosition As Integer = -1, Optional ByVal IsGridNew As Boolean = False) Implements IFileObject.AddRecord

            If m_intType = FileTypes.Designer AndAlso NewRecordPosition > 0 Then
                EnsureRows(NewRecordPosition - 1)
            End If

            If m_intType = FileTypes.Primary OrElse m_intType = FileTypes.Detail OrElse m_intType = FileTypes.Secondary OrElse m_intType = FileTypes.Designer Then
                'Now also adding new record in case of "Designer" Files, this is specifically to handle a case
                'where "Designer" file occurs with other file (of any type), legacy adds a record, initializes and sets NewRecord Status to "True"
                'Changed for QKCD8131, Freightways on 29/08/2005

                'In case of Grid, if user has selected Newly Added (Unsaved) Record
                'simply just move to that record rather than creating new record
                'Note: NewRecordPosition is 0 based
                CheckFileStatus()
                If (Not IsGridNew) AndAlso NewRecordPosition < m_dtbDataTable.Rows.Count Then
                    GoToRecord(NewRecordPosition)

                    'If unaltered-new record already exists, raise an event to notify dependent
                    'file object in case it need to append a record
                    If (Not Me.m_blnAlteredRecord(Me.CurrentRow)) Then
                        RaiseEvent AddRecordEvent(Me, Nothing, Me.CurrentRow, IsGridNew)
                    End If

                    'Set NewRecrod to True for NewRecrodPosition
                    Me.NewRecord(NewRecordPosition) = True

                    'On Current file new record is already exists, no need to add record
                    Exit Sub
                End If
                AddRecord(True, IsGridNew)
            End If

        End Sub

        ''' ---EditRecord--------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="Sender"></param>
        ''' <param name="EventArgs"></param>
        ''' <param name="NewRecordPosition"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overloads Sub EditRecord(ByVal Sender As Object, ByVal EventArgs As Object, Optional ByVal NewRecordPosition As Integer = -1) Implements IFileObject.EditRecord
            'This method will be called in response to an event in a Page

            Dim blnReturnValue As Boolean
            If NewRecordPosition <> Me.CurrentRow Then
                'Note: Important for Grid Screen
                'Used GoToRecord to position a record in any 
                'dependant file objects
                GoToRecord(NewRecordPosition)
            End If

            If blnReturnValue Then
                RaiseEvent EditRecordEvent(Me, EventArgs, NewRecordPosition)
            End If
        End Sub

        ''' ---DeleteRecord--------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="Sender"></param>
        ''' <param name="EventArgs"></param>
        ''' <param name="NewRecordPosition"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overloads Sub DeleteRecord(ByVal Sender As Object, ByVal EventArgs As Object, Optional ByVal NewRecordPosition As Integer = -1) Implements IFileObject.DeleteRecord
            'This method will be called in response to an event in a Page
            '
            If NewRecordPosition <> Me.CurrentRow Then
                'Note: Important for Grid Screen
                'Used GoToRecord to position a record in any 
                'dependant file objects
                GoToRecord(NewRecordPosition)
            End If

            RaiseEvent DeleteRecordEvent(Me, EventArgs, NewRecordPosition)
        End Sub

        ''' ---SubfileInit--------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="Recordcount"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Sub SubfileInit(ByVal Recordcount As Integer)
            ReDim Preserve m_blnNewRecord(Recordcount)
            ReDim Preserve m_blnAlteredRecord(Recordcount)
            ReDim Preserve m_blnDeletedRecord(Recordcount)
            ReDim Preserve m_blnIsInitialized(Recordcount)
            ReDim Preserve m_blnCountIntoCalled(Recordcount)
            ReDim Preserve m_blnGridDeletedRecord(Recordcount)

            m_blnNewRecord(Recordcount) = True
        End Sub

        ''' ---GoToRecord--------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="NewRecordPosition"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Sub GoToRecord(ByVal NewRecordPosition As Integer) Implements IFileObject.GoToRecord
            'This method will ideally be called from FileObject itself

            'Notify dependent file objects to move record position
            RaiseEvent GoToRecordEvent(Me, Nothing, NewRecordPosition)
        End Sub

        ''' ---GoToRecord--------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="EventArgs"></param>
        ''' <param name="NewRecordPosition"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Sub GoToRecord(ByVal sender As Object, ByVal EventArgs As Object, ByVal NewRecordPosition As Integer) Implements IFileObject.GoToRecord
            'This method will be called in response to an event in a Page
            '"Sender" can be used to determine the source of an event
            GoToRecord(NewRecordPosition)
        End Sub

        ''' ---WireNavigationEvents--------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' Set Relations based Parent File and DependantFile Object's properties
        ''' </summary>
        ''' <param name="DependentFileObject"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Sub WireNavigationEvents(ByVal DependentFileObject As BaseFileObject)

            Select Case DependentFileObject.Type
                Case FileTypes.Secondary
                    If m_intType = FileTypes.Primary OrElse m_intType = FileTypes.Detail Then
                        'Navigation, Append, Edit and Delete 
                        WireNavigationEvents(DependentFileObject, True, (Not NoAppend), True, (Not NoDelete))
                    Else
                        'Error????
                    End If
                Case FileTypes.Detail  'Can occur with Primary and Master
                    If m_intType = FileTypes.Primary OrElse m_intType = FileTypes.Master Then
                        'Navigation, Append, Edit and Delete 
                        WireNavigationEvents(DependentFileObject, True, (Not NoAppend), True, (Not NoDelete))
                    Else
                        'Error????
                    End If
                Case FileTypes.Delete
                    'TODO:  Need to work on Delete 
                Case FileTypes.Primary 'Can occur with Master
                    'TODO:  Need to work on Delete 
                Case FileTypes.Designer
                    WireNavigationEvents(DependentFileObject, True, (Not NoAppend), True, (Not NoDelete))
            End Select

        End Sub

        ''' ---WireNavigationEvents--------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="DependentFileObject"></param>
        ''' <param name="WireNavigationEvents"></param>
        ''' <param name="WireAddEvent"></param>
        ''' <param name="WireEditEvent"></param>
        ''' <param name="WireDeleteEvent"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Sub WireNavigationEvents(ByVal DependentFileObject As BaseFileObject, ByVal WireNavigationEvents As Boolean, ByVal WireAddEvent As Boolean, ByVal WireEditEvent As Boolean, ByVal WireDeleteEvent As Boolean)
            'TODO: Now, we need to change this function to set relations
            'This method will be called from the Page Object ideally from "SetRelations"
            With DependentFileObject
                If WireNavigationEvents Then
                    AddHandler Me.GoToRecordEvent, AddressOf .GoToRecord
                End If

                If WireAddEvent Then
                    AddHandler Me.AddRecordEvent, AddressOf .AddRecord
                End If

                If WireEditEvent Then
                    AddHandler Me.EditRecordEvent, AddressOf .EditRecord
                End If

                If WireDeleteEvent Then
                    AddHandler Me.DeleteRecordEvent, AddressOf .DeleteRecord
                End If
                .Occurs = Me.Occurs
            End With

        End Sub

        ''' ---CheckFileStatus--------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' Determines the status of a resultset.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Sub CheckFileStatus()

            Try
                ' Based on FileTypes, open the resultset if not already opened.
                ' If a REFERENCE file, then call the GetData method.
                If m_intType = FileTypes.Reference Then

                    ' If the DataReader is NOTHING, then fetch the data using
                    ' the default access.
                    If m_dtbDataTable Is Nothing Then
                        GetData(GetDataOptions.IsOptional)
                    Else
                        Dim strDefaultSQL As String
                        Dim strSelectIf As String = ""

                        m_strBaseName = BaseName
                        m_strAliasName = AliasName


                        ' Retrieve the SelectIf portion.
                        strSelectIf = ""
                        RaiseEvent SelectIf(strSelectIf)

                        ' Generate the default SQL.
                        strDefaultSQL = ReturnSelectFromSQL()

                        strDefaultSQL &= " " & GetAccessClause()
                        If strSelectIf <> "" Then strDefaultSQL &= " AND " & strSelectIf

                        ' Check if the default SQL is different from the last SQL that
                        ' was executed.  If so, execute the GetData method.
                        If strDefaultSQL <> m_strLastSQL AndAlso strDefaultSQL.IndexOf(" WHERE ") > 0 Then
                            GetData(GetDataOptions.IsOptional)
                        End If
                    End If
                Else
                    ' If the file is not a REFERENCE file, then open an empty record
                    ' structure if the file has not been opened.
                    If m_dtbDataTable Is Nothing Then
                        CreateEmptyStructure(True)
                    End If
                End If

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Sub

        ''' ---GetAccessClause--------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Function GetAccessClause() As String
            Dim strAccess As String = ""
            strAccess = ""

            Try
                RaiseEvent Access(strAccess)
            Catch ex As CustomApplicationException
                Throw ex
            Catch ex As Exception
                ExceptionManager.Publish(ex)
                Throw ex
            End Try
            If strAccess.Trim = "" Then
                strAccess = strAccess.Trim
            Else
                strAccess = " " & strAccess.Trim
            End If
            Return strAccess
        End Function

        ''' ---GetSelectIfClause--------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Function GetSelectIfClause() As String
            Dim strSelectIf As String = ""
            strSelectIf = ""
            SelectifColumn = New ArrayList
            If IsQTP Then
                blnIsInSelectIf = True
                blnGlobalUseTableSelectIf = BooleanTypes.NotSet
                If Not UseMemory OrElse blnUseTableSelectIf = BooleanTypes.NotSet Or blnUseTableSelectIf = BooleanTypes.False Then
                    If blnUseTableSelectIf = BooleanTypes.NotSet Then blnUseTableSelectIf = BooleanTypes.True
                    RaiseEvent SelectIf(strSelectIf)
                    If blnGlobalUseTableSelectIf = BooleanTypes.False Then
                        blnUseTableSelectIf = blnGlobalUseTableSelectIf
                    End If
#If TARGET_DB = "INFORMIX" Then
                    If Not blnUseTableSelectIf AndAlso SelectifColumn.Count > 0 AndAlso strSelectIf.ToUpper.IndexOf(" OR ") = -1 Then
                        Dim arrtemp() = strSelectIf.Replace(")", "").Replace("(", "").Replace(" AND ", " ~ ").Split("~")
                        For i As Integer = 0 To arrtemp.Length - 1
                            For j As Integer = 0 To SelectifColumn.Count - 1
                                If arrtemp(i).ToString.IndexOf("." & SelectifColumn(j)) > 0 Then
                                    If SelectifSQL.Length > 0 Then SelectifSQL = SelectifSQL & " AND "
                                    SelectifSQL = SelectifSQL & arrtemp(i)
                                    Exit For
                                End If
                            Next
                        Next
                    End If
#End If
                End If
                blnIsInSelectIf = False
            Else

                Try
                    RaiseEvent SelectIf(strSelectIf)
                Catch ex As CustomApplicationException
                    Throw ex
                Catch ex As Exception
                    ExceptionManager.Publish(ex)
                    Throw ex
                End Try
            End If
            If strSelectIf.Trim = "" Then
                strSelectIf = strSelectIf.Trim
            Else
                strSelectIf = " " & strSelectIf.Trim
            End If
            Return strSelectIf.Replace("Temporary Data.", "")

        End Function


        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Function GetChooseClause() As String
            Dim strChoose As String = ""
            InChoose = True
            strChoose = ""
            RaiseEvent Choose(strChoose)
            If strChoose.Trim = "" Then
                strChoose = strChoose.Trim
            Else
                strChoose = " " & strChoose.Trim
            End If
            InChoose = False
            Return strChoose.Replace("Temporary Data.", "")
        End Function

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Function GetChooseViaIndexClause() As String
            Dim strChoose As String = ""
            strChoose = ""
            RaiseEvent ChooseViaIndex(strChoose)
            If strChoose.Trim = "" Then
                strChoose = strChoose.Trim
            Else
                strChoose = " " & strChoose.Trim
            End If
            Return strChoose.Replace("Temporary Data.", "")
        End Function


        ''' ---GetCursorStatement--------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Function GetCursorStatement() As String
            Dim strSQLStatement As String = ""
            strSQLStatement = ""
            RaiseEvent Cursor(strSQLStatement)
            If strSQLStatement.Trim = "" Then
                strSQLStatement = strSQLStatement.Trim
            Else
                strSQLStatement = " " & strSQLStatement.Trim
            End If
            Return strSQLStatement
        End Function

        ''' ---CreateEmptyStructure--------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' Creates the structure (columns) for the given FILE.
        ''' </summary>
        ''' <param name="GetSchema"></param>
        ''' <remarks>Initializes the values of the columns to the PowerHouse default values 
        ''' based on their data types.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Friend Overridable Sub CreateEmptyStructure(Optional ByVal GetSchema As Boolean = False)

            Try

                ' If we need to get the schema (in the case where we are just initializing
                ' the resultset and did not execute a SQL that returned 0 rows), call the 
                ' GetTableSchema method and create the ROW_ID field.

                If Not (Me.m_IsSubFile AndAlso GetSchema) Then

                    ' Clear all the rows.
                    If Not m_dtbDataTable Is Nothing Then
                        If m_dtbDataTable.Rows.Count > 0 Then
                            m_dtbDataTable.Rows.Clear()
                        End If
                    End If

                    m_dtbDataTable = GetCachedSchema(GetSchema)

                ElseIf Me.m_IsSubFile And Me.Owner = "SEQUENTIAL" Then

                    m_dtbDataTable = GetCachedSchema(GetSchema)

                End If

                NewRecord(Me.CurrentRow) = True

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Sub

        ''' --- InitializeFromDictionary -------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of InitializeFromDictionary.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Sub InitializeFromDictionary()

            Try

                Dim intCount As Integer
                Dim strValue As String
                Dim strColumnName As String
                Dim cdi As CoreDictionaryItem

                For intCount = 0 To m_dtbDataTable.Columns.Count - 1
                    strColumnName = m_dtbDataTable.Columns(intCount).ColumnName()

                    If strColumnName <> "ROW_NUM" AndAlso strColumnName <> "ROW_ID" AndAlso strColumnName <> "CHECKSUM_VALUE" Then

                        ' If we have an AutoIncrement field, make sure it's not read only when doing searches.
                        If m_dtbDataTable.Columns(intCount).AutoIncrement AndAlso m_dtbDataTable.Columns(intCount).ReadOnly Then
                            m_dtbDataTable.Columns(intCount).ReadOnly = False
                        End If


                        cdi = GetDictionary(strColumnName)
                        If Not cdi Is Nothing Then strValue = cdi.DefaultValue

                        ' If we have a decimal value, assign it to a custom property attribute.
                        Select Case m_dtbDataTable.Columns(intCount).DataType.ToString
                            Case "System.Decimal", "System.Double"
                                If Not cdi Is Nothing AndAlso cdi.DecimalPosition > 0 AndAlso Not m_dtbDataTable.Columns(intCount).ExtendedProperties.ContainsKey("D") Then
                                    m_dtbDataTable.Columns(intCount).ExtendedProperties.Add("D", cdi.DecimalPosition)
                                End If
                        End Select

                        If strValue Is Nothing Then
                            'Field is not defined in the Dictionary
                        Else
                            Try
                                'objDictionary = New Dictionary(strColumnName)
                                'strValue = objDictionary.GetValue("Default")

                                If strValue.Trim.Length <> 0 Then
                                    Select Case m_dtbDataTable.Columns(intCount).DataType.ToString
                                        Case "System.String"
                                            If strValue.Substring(0, 1) = """" And strValue.Substring(strValue.Length - 1, 1) = """" Then
                                                strValue = strValue.Substring(1, strValue.Length - 2)
                                            End If
                                            m_dtbDataTable.Rows(Me.CurrentRow).Item(intCount) = strValue
                                        Case "System.DateTime"
                                            ' See whether the default value for the date is a number or a date.
                                            If IsDate(strValue) Then
                                                m_dtbDataTable.Rows(Me.CurrentRow).Item(intCount) = CType(strValue, DateTime)
                                            Else
                                                ' If we have a number value for a date, only set the value if it is not 
                                                ' a zero date in case of NULL support.
                                                If CType(strValue, Decimal) <> 0 Then
                                                    m_dtbDataTable.Rows(Me.CurrentRow).Item(intCount) = GetDateFromYYYYMMDDDecimal(CType(strValue, Decimal))
                                                End If
                                            End If
                                        Case "System.Decimal", "System.Double"
                                            m_dtbDataTable.Rows(Me.CurrentRow).Item(intCount) = CType(strValue, Decimal)
                                    End Select
                                End If

                            Catch ex As Exception

                                ' Write the exception to the event log and throw an error.
                                ExceptionManager.Publish(ex)
                                Throw ex

                            End Try

                        End If
                        cdi = Nothing
                    End If

                Next

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Sub

        ''' ---CreateNewRowObject--------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="dt"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Function CreateNewRowObject(ByRef dt As DataTable) As DataRow

            Dim drwDataRow As DataRow
            Dim intFieldCount As Integer

            ' Create a new row object.
            drwDataRow = dt.NewRow()

            ' Initialize the fields with the appropriate PowerHouse defaults based on data type.
            For intFieldCount = 0 To dt.Columns.Count - 1
                Select Case dt.Columns(intFieldCount).DataType.ToString
                    Case "System.String"
                        If dt.Columns(intFieldCount).ColumnName <> "ROW_ID" Then
                            drwDataRow.Item(intFieldCount) = cEmptyString
                        End If
                    Case "System.DateTime"
                        drwDataRow.Item(intFieldCount) = Date.MinValue
                    Case "System.Decimal", "System.Int16", "System.Int32", "System.Int64", "System.Boolean", "System.Double"
                        drwDataRow.Item(intFieldCount) = 0
                End Select
                ' TODO: Add code to initialize fields that are not of type String, DateTime or Decimal.
            Next
            'TODO: Remove constraints while adding new record in Entry

            Return drwDataRow

        End Function
        ''' ---CreateNewRow--------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="dt"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Sub CreateNewRow(ByRef dt As DataTable)

            ' Add the row to the DataTable object.
            dt.Rows.Add(CreateNewRowObject(dt))

        End Sub

        ''' ---ResetRowAt--------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="dt"></param>
        ''' <param name="Position></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Sub ResetRowAt(ByRef dt As DataTable, ByVal Position As Integer)

            ' Add the row to the DataTable object at the specified position and 
            ' remove the previous row at that position.
            dt.Rows.InsertAt(CreateNewRowObject(dt), Position)
            dt.Rows.Remove(dt.Rows(Position + 1))

            m_blnIsInitialized(Position) = False

            ' Set the NewRecord status flag based on the RESET option.
            m_blnNewRecord(Me.CurrentRow) = True
            If Not IsQTP Then
                m_blnAlteredRecord(Me.CurrentRow) = False
            End If
            m_blnDeletedRecord(Me.CurrentRow) = False
            m_blnGridDeletedRecord(Me.CurrentRow) = False
            m_blnIsInitialized(Me.CurrentRow) = False

        End Sub

        ''' ---GetCachedSchema--------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="GetSchema"></param>
        ''' <param name="AddRow"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overridable Function GetCachedSchema(ByVal GetSchema As Boolean, Optional ByVal AddRow As Boolean = True) As DataTable Implements IFileObject.GetCachedSchema
            'Should be implemented in the derived class
            Return Nothing
        End Function


        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' To handle GetData without any parameters
        ''' </summary>
        ''' <returns>A Boolean representing whether Data has been retrieved.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>fleEMPLOYEE.GetData()</example> 
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function GetDefineData() As Boolean
            m_blnInDefine = True
            If IsNothing(m_dtbDataTable) OrElse m_dtbDataTable.Rows.Count <= 0 Then
                Return GetDataInternal(String.Empty, String.Empty, String.Empty, GetDataOptions.None, -1)
            Else
                SetAccessOkOnPage(True)
            End If
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' To handle GetData without any parameters
        ''' </summary>
        ''' <returns>A Boolean representing whether Data has been retrieved.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>fleEMPLOYEE.GetData()</example> 
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function GetData() As Boolean
            Return GetDataInternal(String.Empty, String.Empty, String.Empty, GetDataOptions.None, -1)
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' To handle GetData by passing GetData Options
        ''' </summary>
        ''' <param name="GetDataBehaviour"></param>
        ''' <returns>A Boolean representing whether Data has been retrieved.</returns>
        ''' <remarks>
        ''' <note>
        ''' <para>The options can be combined using the OR operator. </para>
        ''' <para>The option AddRecordToBuffer should only be used by the framework. </para>
        ''' <para>The CreateSubSelect option should only be used for a Detail file (in the DetailFind method)
        ''' or for a Primary file (in the Find method).  This parameter indicates that we are retrieving
        ''' a subset of the records that meet the filter (WHERE clause) criteria, based on the Occurs property
        ''' value and the current record(s) displayed.  If the Occurs is set to 5, then only five records are retrieved at one time.
        ''' </para>
        ''' </note>
        ''' </remarks>
        ''' <example>fleEMPLOYEE.GetData(GetDataOptions.Sequential Or GetDataOptions.CreateSubSelect)</example>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function GetData(ByVal GetDataBehaviour As GetDataOptions) As Boolean
            Return GetDataInternal(String.Empty, String.Empty, String.Empty, GetDataBehaviour, -1)
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' To handle GetData with only Where Clause
        ''' </summary>
        ''' <param name="WhereClause">A string representing a SQL WHERE statement.</param>
        ''' <returns>A Boolean representing whether Data has been retrieved.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        ''' m_strWHERE = New StringBuilder(“ WHERE “) <br/>
        ''' m_strWHERE.Append(“ EMPLOYEE.EMPLOYEE_ID = “).Append(T_EMP_ID.Value) <br/>
        ''' fleEMPLOYEE.GetData(m_strWHERE.ToString())
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function GetData(ByVal WhereClause As String) As Boolean
            'Get Data using passed Where Condition, without any GetDataOptions
            Return GetDataInternal(WhereClause, String.Empty, String.Empty, GetDataOptions.None, -1)
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' To handle GetData with only Where Clause and Order By Clause
        ''' </summary>
        ''' <param name="WhereClause">A string representing a SQL WHERE statement.</param>
        ''' <param name="OrderByClause">A string representing a SQL ORDER BY statement.</param>
        ''' <returns>A Boolean representing whether Data has been retrieved.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        ''' m_strWHERE = New StringBuilder(“ WHERE “) <br/>
        ''' m_strWHERE.Append(“ EMPLOYEE.EMPLOYEE_ID = “).Append(T_EMP_ID.Value) <br/>
        ''' m_strORDERBY = New StringBuilder(“ ORDER BY EMPLOYEE.STATUS_CODE”) <br/>
        ''' fleEMPLOYEE.GetData(m_strWHERE.ToString(), m_strORDERBY.ToString())
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function GetData(
            ByVal WhereClause As String,
            ByVal OrderByClause As String) As Boolean

            If IsQTP Then
                If m_blnOutPut Then
                    If m_blnOutGet Then
                        m_blnOutGet = False
                        'Get Data using passed Where Condition, and Order By Clause, without any GetDataOptions
                        Return GetDataInternal(WhereClause, OrderByClause, String.Empty, GetDataOptions.None, -1)
                    Else
                        ReDim Preserve m_blnNewRecord(OverRideOccurrence)
                        ReDim Preserve m_blnAlteredRecord(OverRideOccurrence)
                        ReDim Preserve m_blnDeletedRecord(OverRideOccurrence)
                        ReDim Preserve m_blnIsInitialized(OverRideOccurrence)
                        ReDim Preserve m_blnCountIntoCalled(OverRideOccurrence)
                        ReDim Preserve m_blnGridDeletedRecord(OverRideOccurrence)
                    End If
                Else
                    'Get Data using passed Where Condition, and Order By Clause, without any GetDataOptions
                    Return GetDataInternal(WhereClause, OrderByClause, String.Empty, GetDataOptions.None, -1)
                End If
            Else
                'Get Data using passed Where Condition, and Order By Clause, without any GetDataOptions
                Return GetDataInternal(WhereClause, OrderByClause, String.Empty, GetDataOptions.None, -1)
            End If

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' To handle GetData with Where Clause along with any Options
        ''' </summary>
        ''' <param name="WhereClause">A string representing a SQL WHERE statement.</param>
        ''' <param name="GetDataBehaviour"></param>
        ''' <returns>A Boolean representing whether Data has been retrieved.</returns>
        ''' <remarks>Please ensure you understand when to call this method.
        ''' <para>
        '''     <note>You can use this method in following cases:
        '''         <para>
        '''             <list type="number">
        '''                 <item>To pass prepared Where Clause along with internal CreateSubSelect</item>
        '''                 <item>To pass prepared Where Clause along with any other GetDataOptions</item>
        '''             </list>
        '''         </para>
        '''         <para>
        '''         You cannot use this method:
        '''             <list type="number">
        '''                 <item>To pass complete SQL statement as Overrided, for that see other overloaded method</item>
        '''             </list>
        '''         </para>
        '''     </note>
        ''' </para>
        ''' <note>
        ''' <para>The options can be combined using the OR operator. </para>
        ''' <para>The option AddRecordToBuffer should only be used by the framework. </para>
        ''' <para>The CreateSubSelect option should only be used for a Detail file (in the DetailFind method)
        ''' or for a Primary file (in the Find method).  This parameter indicates that we are retrieving
        ''' a subset of the records that meet the filter (WHERE clause) criteria, based on the Occurs property
        ''' value and the current record(s) displayed.  If the Occurs is set to 5, then only five records are retrieved at one time.
        ''' </para>
        ''' </note>
        ''' </remarks>
        ''' <example>
        ''' m_strWHERE = New StringBuilder(“ WHERE “) <br/>
        ''' m_strWHERE.Append(“ EMPLOYEE.EMPLOYEE_ID = “).Append(T_EMP_ID.Value) <br/>
        ''' fleEMPLOYEE.GetData(m_strWHERE.ToString(), GetDataOptions.IsOptional)
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function GetData(
            ByVal WhereClause As String,
            ByVal GetDataBehaviour As GetDataOptions) As Boolean

            If IsQTP Then
                If m_blnOutPut Then
                    If m_blnOutGet Then
                        m_blnOutGet = False
                        'Get Data using passed Where Condition and passed GetDataOptions
                        Return GetDataInternal(WhereClause, String.Empty, String.Empty, GetDataBehaviour, -1)
                    Else
                        ReDim Preserve m_blnNewRecord(OverRideOccurrence)
                        ReDim Preserve m_blnAlteredRecord(OverRideOccurrence)
                        ReDim Preserve m_blnDeletedRecord(OverRideOccurrence)
                        ReDim Preserve m_blnIsInitialized(OverRideOccurrence)
                        ReDim Preserve m_blnCountIntoCalled(OverRideOccurrence)
                        ReDim Preserve m_blnGridDeletedRecord(OverRideOccurrence)
                    End If
                Else
                    'Get Data using passed Where Condition and passed GetDataOptions
                    Return GetDataInternal(WhereClause, String.Empty, String.Empty, GetDataBehaviour, -1)
                End If
            Else
                'Get Data using passed Where Condition and passed GetDataOptions
                Return GetDataInternal(WhereClause, String.Empty, String.Empty, GetDataBehaviour, -1)
            End If

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' To handle GetData with only Where Clause, Order By Clause and GetData Options
        ''' </summary>
        ''' <param name="WhereClause">A string representing a SQL WHERE statement.</param>
        ''' <param name="OrderByClause">A string representing a SQL ORDER BY statement.</param>
        ''' <param name="GetDataBehaviour"></param>
        ''' <returns>A Boolean representing whether Data has been retrieved.</returns>
        ''' <remarks>
        ''' <note>
        ''' <para>The options can be combined using the OR operator. </para>
        ''' <para>The option AddRecordToBuffer should only be used by the framework. </para>
        ''' <para>The CreateSubSelect option should only be used for a Detail file (in the DetailFind method)
        ''' or for a Primary file (in the Find method).  This parameter indicates that we are retrieving a subset
        ''' of the records that meet the filter (WHERE clause) criteria, based on the Occurs property value and
        ''' the current record(s) displayed.  If the Occurs is set to 5, then only five records are retrieved at one time.
        ''' </para>
        '''</note>
        ''' </remarks>
        ''' <example>
        ''' m_strWHERE = New StringBuilder(“ WHERE “)  <br/>
        ''' m_strWHERE.Append(“ EMPLOYEE.EMPLOYEE_ID = “).Append(T_EMP_ID.Value) <br/>
        ''' m_strORDERBY = New StringBuilder(“ ORDER BY EMPLOYEE.STATUS_CODE”) <br/>
        ''' fleEMPLOYEE.GetData(m_strWHERE.ToString(), m_strORDERBY.ToString(), GetDataOptions.IsOptional)
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function GetData(
            ByVal WhereClause As String,
            ByVal OrderByClause As String,
            ByVal GetDataBehaviour As GetDataOptions) As Boolean


            'Get Data using passed Where Condition, Order By Clause, and passed GetDataOptions
            Return GetDataInternal(WhereClause, OrderByClause, String.Empty, GetDataBehaviour, -1)

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' To handle GetData by passing fully prepared SQL that can be used to Get Data (with default options)
        ''' </summary>
        ''' <param name="IsOverrided"></param>
        ''' <param name="OverrideSQL">A string representing a full SQL statement.</param>
        ''' <returns>A Boolean representing whether Data has been retrieved.</returns>
        ''' <remarks>
        ''' Use this method if you ever need to pass complete 
        ''' Overrided SQL statement which does not rely on other parameters.
        ''' <para>
        ''' <note>
        '''     <para>
        '''         The first parameter "IsOverrided" is added to add overloaded method
        '''         Passing it as False has NO impact, i.e. whether you pass True or False
        '''         this function will treat it as True.
        '''     </para>
        '''     <para>
        '''         Use another construct If you need to pass Where Clause and Order By 
        '''         clause along with Auto Overrided SQL e.g.
        '''         GetData(WhereClause, OrderByClause, GetDataBehaviour.CreateSubSelect)
        '''     </para>
        '''     <para>
        '''         This method allows the user to override the SQL using a specific SQL statement.
        '''     </para>
        ''' </note>
        ''' </para>
        ''' </remarks>
        ''' <example>
        ''' Dim strSQL As StringBuilder = New StringBuilder(“SELECT * FROM (SELECT DISTINCT EMPLOYEE_ID FROM EMPLOYEE WHERE EMPLOYEE_STATUS_CODE = ‘F’)”) <br/>
        ''' fleEMPLOYEE.GetData(True, strSQL.ToString())
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function GetData(
            ByVal IsOverrided As Boolean,
            ByVal OverrideSQL As String) As Boolean

            'GetData with passed Overrided SQL statement (without any GetDataOptions)
            Return GetDataInternal(String.Empty, String.Empty, OverrideSQL, GetDataOptions.None, -1)

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' To handle GetData by passing fully prepared SQL that can be used to Get Data (with default options)
        ''' </summary>
        ''' <param name="IsOverrided"></param>
        ''' <param name="OverrideSQL">A string representing a full SQL statement.</param>
        ''' <param name="GetDataBehaviour"></param>
        ''' <returns>A Boolean representing whether Data has been retrieved.</returns>
        ''' <remarks>Use this method if you ever need to pass complete 
        ''' Overrided SQL statement with GetDataBehaviour.
        ''' <para>
        '''     <note>
        '''         <list type="number">
        '''             <item>Don't use this construct to generate Overrided SQL Statement internally
        '''                 i.e. Use this method if you ever need to pass GetDataBehaviour
        '''                 other than GetDataBehaviour.CreateSubSelect.
        '''             </item>
        '''             <item>To pass GetDataBehaviour.CreateSubSelect use
        '''                 Use another method, if you need to pass Where Clause and Order By
        '''                 clause along with Auto Overrided SQL e.g.
        '''                 GetData(WhereClause, OrderByClause, GetDataOptions.CreateSubSelect)
        '''                 <para>
        '''                     If you pass OverrideSQL along with GetDataBehaviour = GetDataOptions.CreateSubSelect
        '''                     this method will use passed OverrideSQL, completely ignoring the GetDataOptions.CreateSubSelect
        '''                 </para>
        '''             </item>
        '''             <item>The first parameter "IsOverrided" is added to add overloaded method
        '''                 Passing it as false has NO impact, i.e. whether you pass True or False
        '''                 this function will treat it as True.
        '''             </item>
        '''         </list>
        '''     </note>
        '''</para>
        ''' <note>
        ''' <para> This method allows the user to override the SQL using a specific SQL statement. </para>
        ''' <para> The options can be combined using the OR operator. </para>
        ''' <para> The option AddRecordToBuffer should only be used by the framework. </para>
        ''' <para> The CreateSubSelect option should only be used for a Detail file (in the DetailFind method)
        ''' or for a Primary file (in the Find method).  This parameter indicates that we are retrieving a subset
        ''' of the records that meet the filter (WHERE clause) criteria, based on the Occurs property value and
        ''' the current record(s) displayed.  If the Occurs is set to 5, then only five records are retrieved at one time.
        ''' </para>
        ''' </note>
        ''' </remarks>
        ''' <example>
        ''' Dim strSQL As StringBuilder = New StringBuilder(“SELECT * FROM (SELECT DISTINCT EMPLOYEE_ID FROM EMPLOYEE WHERE EMPLOYEE_STATUS_CODE = ‘F’)”) <br/>
        ''' fleEMPLOYEE.GetData(True, strSQL.ToString(), GetDataOptions.IsOptional)
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function GetData(
            ByVal IsOverrided As Boolean,
            ByVal OverrideSQL As String,
            ByVal GetDataBehaviour As GetDataOptions) As Boolean

            Return GetDataInternal(String.Empty, String.Empty, OverrideSQL, GetDataBehaviour, -1)

        End Function

        ''' ---GetData--------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' To handle GetData by passing prepared SQL that can be used to Get Data along with data option.
        ''' </summary>
        ''' <param name="WhereClause">A string representing a SQL WHERE statement.</param>
        ''' <param name="OrderByClause">A string representing a SQL ORDER BY statement.</param>
        ''' <param name="OverrideSQL">A string representing a full SQL statement.</param>
        ''' <param name="GetDataBehaviour"></param>
        ''' <returns>A Boolean representing whether Data has been retrieved.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overridable Function GetData(
                    ByVal WhereClause As String,
                    ByVal OrderByClause As String,
                    ByVal OverrideSQL As String,
                    ByVal GetDataBehaviour As GetDataOptions) As Boolean

            Return GetDataInternal(WhereClause, OrderByClause, OverrideSQL, GetDataBehaviour, -1)

        End Function

        ''' ---GetData--------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' To handle GetData by passing prepared SQL with data option and number of records to return.
        ''' </summary>
        ''' <param name="WhereClause">A string representing a SQL WHERE statement.</param>
        ''' <param name="OrderByClause">A string representing a SQL ORDER BY statement.</param>
        ''' <param name="OverrideSQL">A string representing a full SQL statement.</param>
        ''' <param name="GetDataBehaviour"></param>
        ''' <param name="RecordsToFill">An integer representing the number of records to return to file object.</param>
        ''' <returns>A Boolean representing whether Data has been retrieved.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overridable Function GetData(
                    ByVal WhereClause As String,
                    ByVal OrderByClause As String,
                    ByVal OverrideSQL As String,
                    ByVal GetDataBehaviour As GetDataOptions,
                    ByRef RecordsToFill As Integer) As Boolean

            Return GetDataInternal(WhereClause, OrderByClause, OverrideSQL, GetDataBehaviour, RecordsToFill)

        End Function

        ''' --- GetDataInternal ----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' To handle GetData with several options
        ''' </summary>
        ''' <param name="WhereClause"></param>
        ''' <param name="OrderByClause"></param>
        ''' <param name="OverrideSQL"></param>
        ''' <param name="GetDataBehaviour"></param>
        ''' <param name="RecordsToFill"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <example>GetData(True, OverrideSQL, GetDataBehaviour)</example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overridable Function GetDataInternal(
                    ByVal WhereClause As String,
                    ByVal OrderByClause As String,
                    ByVal OverrideSQL As String,
                    ByVal GetDataBehaviour As GetDataOptions,
                    ByRef RecordsToFill As Integer) As Boolean Implements IFileObject.GetDataInternal
            'Should be implemented in the derived class
        End Function

        ''' ---RaiseInitializeItems--------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="Fixed"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Sub RaiseInitializeItems(ByVal Fixed As Boolean)
            If blnInInit Then Exit Sub

            blnInInit = True
            RaiseEvent InitializeItems(Fixed)
            blnInInit = False
            blnQTPInit = False
        End Sub

        ''' --- RaiseSetItemFinals -------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of RaiseSetItemFinals.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Sub RaiseSetItemFinals()

            If IsQTP AndAlso NewRecord AndAlso Not IsNothing(m_arrOutPutColumns) AndAlso m_arrOutPutColumns.Count > 0 Then
                For i As Integer = 0 To m_arrOutPutColumns.Count - 1
                    Me.SetValue(m_arrOutPutColumns(i)) = m_arrOutPutValues(i)
                Next
            End If

            If IsQTP AndAlso m_IsSubFile Then


                ' Set the ITEM FINAL values.

                Try
                    RaiseEvent SetItemFinals()
                Catch ex As CustomApplicationException
                    Throw ex
                Catch ex As Exception
                    ExceptionManager.Publish(ex)
                    Throw ex
                End Try

            Else
                If (Not NewRecord OrElse AlteredRecord) Then
                    ' Set the ITEM FINAL values.

                    Try
                        RaiseEvent SetItemFinals()
                    Catch ex As CustomApplicationException
                        Throw ex
                    Catch ex As Exception
                        ExceptionManager.Publish(ex)
                        Throw ex
                    End Try
                End If
            End If



        End Sub

        ''' --- RaiseBalance -------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of RaiseBalance.
        ''' </summary>
        ''' <param name="Field"></param>
        ''' <param name="Value"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Sub RaiseBalance(ByVal Field As String, ByVal Value As Decimal)
            RaiseEvent Balance(Field, Value)
        End Sub

        ''' --- RaiseCountInto -------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of RaiseCountInto.
        ''' </summary>
        ''' <param name="Value"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Sub RaiseCountInto(ByVal Value As Decimal)

            If Not CountIntoCalled Then
                RaiseEvent CountInto(Value)
                CountIntoCalled = True
            End If

        End Sub

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
        Protected Overridable Property CountIntoCalled() As Boolean
            Get
                ' Must be overriden in the Core.Windows.UI objects.
            End Get
            Set(ByVal Value As Boolean)
                ' Must be overriden in the Core.Windows.UI objects.
            End Set
        End Property

        ''' --- RaiseSumInto -------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of RaiseSumInto.
        ''' </summary>
        ''' <param name="Field"></param>
        ''' <param name="Value"></param>
        ''' <param name="OldValue"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Sub RaiseSumInto(ByVal Field As String, ByVal Value As Decimal, ByVal OldValue As Decimal)
            RaiseEvent SumInto(Field, Value, OldValue)
        End Sub

        ''' --- GetSubSelectStatement ----------------------------------------------
        ''' <exclude/>
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
        Protected Overridable Function GetSubSelectStatement(ByVal SQLStatement As StringBuilder, ByVal WhereClause As String, ByVal OrderByClause As String, ByVal CurrentRecordPosition As Long, ByRef SkippedRecords As Integer, Optional ByRef blnoverridesql As Boolean = False) As String
            Return String.Empty 'If needed should be overrided in derived class
        End Function

        ''' --- GetOverrideSQL -----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetOverrideSQL.
        ''' </summary>
        ''' <param name="OverrideSQL"></param>
        ''' <param name="WhereClause"></param>
        ''' <param name="SelectIf"></param>
        ''' <param name="DefaultAccessVia"></param>
        ''' <param name="OrderByClause"></param>
        ''' <param name="WholeWhereCondition"></param>
        ''' <param name="SkippedRecords"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overridable Sub GetOverrideSQL(ByVal OverrideSQL As System.Text.StringBuilder, ByVal WhereClause As String, ByVal SelectIf As String, ByVal DefaultAccessVia As String, ByVal OrderByClause As String, ByRef WholeWhereCondition As String, ByRef SkippedRecords As Integer, Optional ByRef blnoverridesql As Boolean = False)
            'Must be overrided in derived class
        End Sub

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
        Protected Overridable Function GetTempTableRecordCount(ByVal WhereClause As String) As Long
            'Must be overrided in derived class
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
        Protected Overridable Function GetTextTableRecordCount(ByVal WhereClause As String) As Long
            'Must be overrided in derived class
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
        ''' intRecCount = fleEMPLOYEE.GetRecordCount(strWhereClause)
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overridable Function GetRecordCount(ByVal WhereClause As String, Optional ByVal stroverridesql As String = "") As Long
            If m_IsTempTable Then
                Return GetTempTableRecordCount(WhereClause)
            ElseIf m_IsTextFile Then
                If IsQTP Then
                    Return 0
                Else                   
                    Return GetTextTableRecordCount(WhereClause)
                End If
            Else
                 If m_IsSubFile
                      return   GetTextTableRecordCount(WhereClause)
                    End If
                Dim StrSQL As New System.Text.StringBuilder

                If stroverridesql.Length = 0 Then
                    With StrSQL
                        .Append("Select Count(*) ")
                        .Append(" FROM ")
                        .Append(Me.Owner)
                        .Append(".")
                        .Append(Me.BaseName)
                        .Append("  ")
                        .Append(Me.AliasName)

                        .Append("  WITH (NOLOCK) ")

                        .Append(WhereClause)
                        Return ExecuteScalar(GetConnectionString, CommandType.Text, .ToString)
                    End With
                Else
                    With StrSQL
                        .Append("Select Count(*) ")
                        .Append(stroverridesql.Substring(stroverridesql.IndexOf(" FROM ")))
                        .Append(WhereClause)
                        Return ExecuteScalar(GetConnectionString, CommandType.Text, .ToString)
                    End With
                End If

            End If
        End Function

        ''' --- GetConnectionString ------------------------------------------------
        ''' <exclude/>
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
        Protected Overridable Function GetConnectionString() As String Implements IFileObject.GetConnectionString
            'Must be overrided in derived class
            Return Nothing
        End Function

        ''' --- ExecuteScalar ------------------------------------------------------
        ''' <exclude/>
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
        Protected Overridable Function ExecuteScalar(ByVal connectionString As String, ByVal commandType As CommandType, ByVal commandText As String) As Long
            'Must be overrided in derived class
        End Function

        ''' --- GetMetaData --------------------------------------------------------
        ''' <exclude/>
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
        Protected Overridable Sub GetMetaData()
            'Must be overrided in derived class
        End Sub

        ''' --- GetMetaData --------------------------------------------------------
        ''' <exclude/>
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
        Protected Overridable Sub GetMetaData(ByRef cnn As IDbConnection, ByRef trn As IDbTransaction) Implements IFileObject.GetMetaData
            'Must be overrided in derived class
        End Sub

        ''' --- ReturnStringBasedOnColumnInformation -------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of ReturnStringBasedOnColumnInformation.
        ''' </summary>
        ''' <param name="Field"></param>
        ''' <param name="Value"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Private Function ReturnStringBasedOnColumnInformation(ByVal Field As String, ByVal Value As String, Optional ByVal blnSort As Boolean = False) As String

            Dim intOrdinal As Integer
            Dim Field2 As String = Field

            If IsQuiz AndAlso Field.ToLower.StartsWith(Me.ReturnRelation.ToLower & "_") Then
                If Not m_dtbDataTable.Columns.Contains(Field) Then
                    Field = Field.Substring(Field.IndexOf(Me.ReturnRelation & "_") + (Me.ReturnRelation & "_").Length)
                End If
                Field2 = Field.Substring(Field.IndexOf(Me.ReturnRelation & "_") + (Me.ReturnRelation & "_").Length)

            End If

            If Me.m_IsSubFile OrElse Me.m_IsTextFile Then
                If m_dtbDataTable.Rows(Me.CurrentRow).Item(Field).GetType.ToString = "System.DateTime" Then
                    Return GetDecimalFromDate(CDate(m_dtbDataTable.Rows(Me.CurrentRow).Item(Field)))
                End If
                Return Value
            End If


            ' Check if the metadata datatable is nothing.  If not, get the column information.
            If m_dtbMetaData Is Nothing Then
                GetMetaData()
            End If

            If Field = "ROW_ID" Then Return Value
            ' Set the ordinal position of the current field.
            If IsQTP Then
                If IsQuiz Then
                    For i As Integer = 0 To m_dtbMetaData.Rows.Count - 1
                        If m_dtbMetaData.Rows(i)(0).ToString.ToUpper = Field2.ToUpper Then
                            intOrdinal = i
                            Exit For
                        End If
                    Next

                Else
                    For i As Integer = 0 To m_dtbMetaData.Rows.Count - 1
                        If m_dtbMetaData.Rows(i)(0).ToString.ToUpper = Field.ToUpper Then
                            intOrdinal = i
                            Exit For
                        End If
                    Next
                End If
            Else
                intOrdinal = m_dtbDataTable.Columns(Field).Ordinal
            End If


            ' Based on the column size and the datatype, return the proper value.
            Dim intSize As Integer = CInt(m_dtbMetaData.Rows(intOrdinal).Item(2))

            ' For columns of type Text (Text Blobs), ensure the size is not too long
            ' or we get an OutOfMemoryException.
            If intSize > 99999999 Then intSize = Value.Trim.Length

            If blnSort Then
                If m_dtbMetaData.Rows(intOrdinal).Item("DataType").ToString = "System.String" Then
                    Return Value.TrimEnd.PadRight(intSize)
                ElseIf m_dtbMetaData.Rows(intOrdinal).Item("DataType").ToString = "System.DateTime" Then
                    If IsNull(m_dtbDataTable.Rows(Me.CurrentRow).Item(Field)) Then
                        Return 0
                    Else
                        Return GetDecimalFromDate(CDate(m_dtbDataTable.Rows(Me.CurrentRow).Item(Field)))
                    End If

                Else
                    If Value.Trim.Length = 0 Then
                        Return "0"
                    Else
                        Return ASCII(CDec(Value), intSize)
                    End If

                End If
            Else
                If Value.Length > intSize Then
                    Return Value.Substring(0, intSize)
                Else
                    Return Value.TrimEnd.PadRight(intSize)
                End If
            End If

        End Function

        ''' --- ReturnColumnSize ---------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of ReturnColumnSize.
        ''' </summary>
        ''' <param name="Column"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Function ReturnColumnSize(ByVal Column As Integer) As Integer

            ' Check if the metadata datatable is nothing.  If not, get the column information.
            If m_dtbMetaData Is Nothing Then
                GetMetaData()
            End If

            Return CInt(m_dtbMetaData.Rows(Column).Item(2))

        End Function

        ''' --- ReturnIsUpdatable --------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of ReturnIsUpdatable.
        ''' </summary>
        ''' <param name="Column"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Function ReturnIsUpdatable(ByVal Column As Integer) As Boolean

            ' Check if the metadata datatable is nothing.  If not, get the column information.
            If m_dtbMetaData Is Nothing Then
                GetMetaData()
            End If

#If TARGET_DB = "INFORMIX" Then
            If Not m_dtbMetaData.Rows(Column).Item(17) Is System.DBNull.Value Then
                Return CType(m_dtbMetaData.Rows(Column).Item(17), Boolean)
            Else
                Return True
            End If
#Else
            Return CType(m_dtbMetaData.Rows(Column).Item(17), Boolean)
#End If

        End Function

        ''' --- ReturnIsReadonly ---------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of ReturnIsReadonly.
        ''' </summary>
        ''' <param name="Column"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Function ReturnIsReadonly(ByVal Column As Integer) As Boolean

            ' Check if the metadata datatable is nothing.  If not, get the column information.
            If m_dtbMetaData Is Nothing Then
                GetMetaData()
            End If

            Return CType(m_dtbMetaData.Rows(Column).Item(22), Boolean)

        End Function

        ''' --- IsClob ------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' Determine if we have a character blob.
        ''' <summary>
        ''' 	Summary of IsClob.
        ''' </summary>
        ''' <param name="Column"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Function IsClob(ByVal Column As Integer) As Boolean

            ' Check if the metadata datatable is nothing.  If not, get the column information.
            If m_dtbMetaData Is Nothing Then
                GetMetaData()
            End If

            If CInt(m_dtbMetaData.Rows(Column).Item(m_intProviderTypeOrdinal)) = m_intClobValue Then  ' CLOB
                Return True
            Else
                Return False
            End If

        End Function

        ''' --- AcceptChanges -----------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of AcceptChanges.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Sub AcceptChanges()
            m_dtbDataTable.Rows(Me.CurrentRow).AcceptChanges()
        End Sub
        ''' --- AssignRecordToBuffer -----------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of AssignRecordToBuffer.
        ''' </summary>
        ''' <param name="NewDataTable"></param>
        ''' <param name="Row"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Sub AssignRecordToBuffer(ByRef NewDataTable As DataTable, Optional ByVal Row As Integer = -1, Optional ByVal AlterNewStatusInEnsureRows As Boolean = True)
            'Notes: 
            '1. In this function it is assumed that except ROW_NUM column,
            '   all other columns are in the same order and in equal number
            '2. Also assuming that if there is ROW_NUM column, it is the first Column
            '   either in original Table or in new table, otherwise it may produce 
            '   unexpected results 
            '3. Added CheckFileStatus to ensure m_dtbDataTable, epecially added to eunsure 
            '   an empty structure, if file is Secondary to Detail and 
            '   called GetData on Secondary from the DetailFind
            '   This behaviour is changed while implementing ForMissing, and changes in Precompiler
            '   on Aug 23, 2004
            '4. For Designer files if required, records will be added to match the CurrentRecord position
            '   on Nov 05, 2004

            Dim intCurrentRow As Integer

            Dim intHasRowNum As Integer '0 = None, 1=In Original, 2=In New

            intCurrentRow = Me.CurrentRow

            If blnInForLoop AndAlso Not IsNothing(m_dtbDataTable) Then
                Row = intCurrentRow
                If Row >= NewDataTable.Rows.Count Then
                    Exit Sub
                End If
            End If

            If IsNothing(m_dtbDataTable) AndAlso Not IsQTP AndAlso m_IsSubFile Then
                m_dtbDataTable = NewDataTable.Clone()
            End If

            'Ensure m_dtbDataTable 
            'Epecially added to eunsure an empty structure, if file is Secondary to Detail and 
            'called GetData on Secondary from the DetailFind
            CheckFileStatus()

            'For Designer files if required, records will be added to match the CurrentRecord position
            If Me.Type = FileTypes.Designer Then
                ' AlterNewStatusInEnsureRows will be passed from the GetDataInternal.  This is used
                ' to indicate the AccessOK was set to false.  In this case we need to set
                ' the NewRecord status to True.
                Me.EnsureRows(intCurrentRow, AlterNewStatusInEnsureRows)
            End If


            With m_dtbDataTable.Rows

                If NewDataTable.Rows.Count > 0 Then
                    Dim intRowToCopy As Integer
                    Dim intExistingRow As Integer
                    Dim intExistingColumnsCount As Integer = m_dtbDataTable.Columns.Count
                    Dim intNewColumnsCount As Integer = NewDataTable.Columns.Count
                    Dim intColumnsToCopy As Integer

                    Dim intStartColumn As Integer

                    'By default Start Copying from (zero based) first column
                    intStartColumn = 0

                    If intExistingColumnsCount <> intNewColumnsCount Then
                        If (m_dtbDataTable.Columns.IndexOf("ROW_NUM") = intExistingColumnsCount - 1) AndAlso (intExistingColumnsCount - 1 = intNewColumnsCount) Then
                            'If original table has ROW_NUM as Last column,
                            'Start Copying from (zero based) first column
                            intStartColumn = 0
                            intHasRowNum = 1
                        ElseIf (NewDataTable.Columns.IndexOf("ROW_NUM") = intNewColumnsCount - 1) AndAlso (intExistingColumnsCount = intNewColumnsCount - 1) Then
                            intStartColumn = 0
                            intHasRowNum = 2
                        Else
                            'Error!!!! See comments.
                        End If
                    End If

                    intColumnsToCopy = Math.Min(intExistingColumnsCount, intNewColumnsCount)
                    Dim objColumnValues(intColumnsToCopy) As Object

                    If Me.DatabaseType = DatabaseTypes.SqlServer AndAlso m_dtbDataTable.Columns.Contains("CHECKSUM_VALUE") Then
                        m_dtbDataTable.Columns("CHECKSUM_VALUE").ReadOnly = False 'We need to make it writable
                    End If

                    intExistingRow = intCurrentRow

                    If Row = -1 Then
                        intRowToCopy = 0
                    Else
                        intRowToCopy = Row
                    End If

                    'Replace the row in buffer with the new row
                    Select Case intHasRowNum
                        Case 1
                            'If Row_Num column is in Original Table

                            'Copy new row into a temporary array
                            NewDataTable.Rows(intRowToCopy).ItemArray.CopyTo(objColumnValues, intStartColumn)

                            'Assign a temporary array to existing buffer
                            .Item(intExistingRow).ItemArray = objColumnValues
                        Case 2
                            'If Row_Num column is in New Table
                            'TODO: This case needs to be tested

                            'Remove "Row_Num" Column from new Table, as the existing table doesn't have "Row_Num"
                            NewDataTable.Columns.Remove("ROW_NUM")
                            objColumnValues = NewDataTable.Rows(intRowToCopy).ItemArray
                        Case Else
                            'TODO: This case needs to be tested
                            If intExistingColumnsCount = intNewColumnsCount Then
                                objColumnValues = NewDataTable.Rows(intRowToCopy).ItemArray
                            Else
                                'If this is a valid case we may need to change this code
                                'At present... might be an Error or 
                                'should not be the case, see Notes
                            End If
                    End Select

                    'Insert the blank row if it does not exist in the existing buffer
                    If .Count <= intExistingRow OrElse (blnOverRideOccurrence AndAlso NewDataTable.Rows.Count > 0 AndAlso m_dtbDataTable.Rows.Count > 0) Then
                        .Add(objColumnValues)
                    Else
                        Try
                            m_dtbDataTable.Rows.Item(intExistingRow).ItemArray = objColumnValues
                        Catch ex As ReadOnlyException
                            For Each column As DataColumn In m_dtbDataTable.Columns
                                If column.ReadOnly Then column.ReadOnly = False
                            Next
                            .Item(intExistingRow).ItemArray = objColumnValues
                        End Try
                    End If

                    If intExistingRow >= m_blnNewRecord.Length Then
                        ReDim Preserve m_blnNewRecord(Occurs - 1)
                        ReDim Preserve m_blnAlteredRecord(Occurs - 1)
                        ReDim Preserve m_blnDeletedRecord(Occurs - 1)
                        ReDim Preserve m_blnIsInitialized(Occurs - 1)
                        ReDim Preserve m_blnCountIntoCalled(Occurs - 1)
                        ReDim Preserve m_blnGridDeletedRecord(Occurs - 1)
                    End If

                    If intExistingRow < Me.Occurs Then
                        'Due to RecordsToRetrieve, intExistingRow can be higher than the Occurs

                        'Set Status Flags for the record
                        m_blnNewRecord(intExistingRow) = False
                        AlteredRecord(intExistingRow) = False
                        m_blnDeletedRecord(intExistingRow) = False
                        m_blnGridDeletedRecord(intExistingRow) = False
                        m_blnIsInitialized(intExistingRow) = False
                    End If


                    If blnOverRideOccurrence Then

                        If .Count > 1 Then
                            .RemoveAt(m_dtbDataTable.Rows.Count - 1)
                        End If
                        For i As Integer = 0 To NewDataTable.Rows.Count - 1
                            .Add(NewDataTable.Rows(i).ItemArray)
                            .Item(i).AcceptChanges()
                        Next

                    Else
                        ' Ensure that we have the OriginalValue set.
                        If m_dtbDataTable.Rows.Count >= intExistingRow AndAlso Not m_blnNewRecord(intExistingRow) AndAlso (m_dtbDataTable.Rows(intExistingRow).RowState = DataRowState.Added OrElse m_dtbDataTable.Rows(intExistingRow).RowState = DataRowState.Modified) Then
                            m_dtbDataTable.Rows(intExistingRow).AcceptChanges()
                        End If
                    End If


                    '.InsertAt(NewDataTable.Rows(intRowToCopy), r)
                    intExistingRow += 1

                    objColumnValues = Nothing

                Else

                    'Remove the existing old record at the current row position
                    If .Count > intCurrentRow Then .RemoveAt(intCurrentRow)

                    'Assign the new record to the existing record buffer
                    Me.AddBlankRecord(intCurrentRow)

                End If
            End With
        End Sub

        ''' --- EnsureRows ---------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of EnsureRows.
        ''' </summary>
        ''' <param name="RequiredRows"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Sub EnsureRows(ByVal RequiredRows As Integer, Optional ByVal AlterNewStatusInEnsureRows As Boolean = True)
            'Note: RequiredRows should be Zero based
            'This private method ensure number of rows passed as "RequiredRows"
            'Fow each missing row, it calls CreateNewRow and initializes the Record Status Flags to False

            If m_dtbDataTable Is Nothing Then
                CreateEmptyStructure(True)
            End If

            Dim intTotalExistingRows As Integer
            With Me.m_dtbDataTable.Rows
                intTotalExistingRows = .Count - 1
                If intTotalExistingRows < RequiredRows Then
                    ' Store the current occurrence so that we can update the initial values 
                    ' for the proper row and then reset the Occurrence back to this value.
                    Dim intCurrentOccurrence As Integer = Me.GetOccurrence
                    For intRowPosition As Integer = intTotalExistingRows + 1 To RequiredRows
                        CreateNewRow(m_dtbDataTable)

                        'Set Status Flags for the record
                        m_blnNewRecord(intRowPosition) = True  'In legacy Automatically added record is a NewRecord, September 8, 2005
                        AlteredRecord(intRowPosition) = False
                        m_blnDeletedRecord(intRowPosition) = False
                        m_blnGridDeletedRecord(intRowPosition) = False
                        m_blnIsInitialized(intRowPosition) = False
                    Next
                    ' Reset the Occurrence to the value prior to the loop.
                    Me.SetOccurrence(intCurrentOccurrence, True)
                ElseIf (RequiredRows = 0 AndAlso Me.Occurs = 0) Then ' CV: Removed this line.  May be required.  If so, we'll add it back in and see what specific condition is required. Me.m_blnIsWhileRetrieving AndAlso 
                    'Set Status Flags for the record
                    AlteredRecord(0) = False
                    m_blnDeletedRecord(0) = False
                    m_blnGridDeletedRecord(0) = False
                    m_blnIsInitialized(0) = False

                    ' AlterNewStatusInEnsureRows will be passed from the GetDataInternal.  This is used
                    ' to indicate the AccessOK was set to false.  In this case we don't need to change the 
                    ' NewRecord status to False.
                    If AlterNewStatusInEnsureRows Then
                        m_blnNewRecord(0) = False
                    End If

                End If
            End With
        End Sub

        ''' --- GetBriefName -------------------------------------------------------
        ''' <exclude/>
        '''
        ''' Returns the short name to meet the 31 character Oracle limit.
        ''' <summary>
        ''' 	Summary of GetBriefName.
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <param name="BriefColumnName"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <example>GetBriefName("THIS_IS_A_BRIEF_NAME_FUNCTION_TEST") returns "THISISABRIEFNAMEFUNCTION"</example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Function GetBriefName(ByVal Name As String, Optional ByVal BriefColumnName As Boolean = False) As String

            Dim strBriefName As String
            Dim intLength As Integer = 24

            Try
                If BriefColumnName Then intLength = 28

                strBriefName = Name
                If strBriefName.Length > intLength Then strBriefName = Replace(Name, "_", "")
                If strBriefName.Length > intLength Then strBriefName = strBriefName.Substring(1, intLength)

                Return strBriefName

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Function

        ''' --- SetAllRecordStatus -------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of SetAllRecordStatus.
        ''' </summary>
        ''' <param name="StatusArray"></param>
        ''' <param name="Value"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Sub SetAllRecordStatus(ByRef StatusArray() As Boolean, Optional ByVal Value As Boolean = False)
            Dim i As Integer
            For i = 0 To UBound(StatusArray)
                StatusArray(i) = Value
            Next
        End Sub

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function GetResetDateValue(ByVal Field As String, Optional ByVal Position As FilePosition = FilePosition.NotSet) As String
            Dim inttmpOverRide As Integer = Me.OverRideOccurrence
            If m_intSortNextOccurence >= 0 Then Me.OverRideOccurrence = m_intSortNextOccurence
            GetResetDateValue = GetDateValue(Field, Position)
            Me.OverRideOccurrence = inttmpOverRide
            Return GetResetDateValue
        End Function
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Retrieves the DateTime value from the given data field.
        ''' </summary>
        ''' <param name="Field">A string representing a field from a record-structure.</param>
        ''' <returns>A DateTime value from a data field.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>T_DATE = fleEMPLOYEE.GetDateValue("BIRTHDATE"))</example>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function GetDateValue(ByVal Field As String, Optional ByVal Position As FilePosition = FilePosition.NotSet) As String

            Dim RowPosition As Integer

            If IsQTP Then ClearColumnJoinInfo()

            If DeleteSubFile Then
                Return ""
            End If

            If IsQTP AndAlso Not GotSQL AndAlso blnRunForMissing Then
                HttpContext.Current.Session("QtpStr") = True
                Return Me.ElementOwner(Field)
            End If

#If TARGET_DB = "INFORMIX" Then
            If IsQuiz AndAlso Not IsParallel AndAlso (Not Field.ToLower.StartsWith(Me.ReturnRelation.ToLower & "_") OrElse Field.ToLower = Me.RecordIdentifier.ToLower) Then
                Field = Me.ReturnRelation & "_" & Field
            End If
#End If

            If IsQTP AndAlso IsAt Then
                RowPosition = m_intSortNextOccurence
            ElseIf Position = FilePosition.First Then
                RowPosition = 0
            ElseIf Position = FilePosition.Last Then
                If Me.Occurs = 0 Then
                    RowPosition = Me.Occurs
                Else
                    RowPosition = Me.Occurs - 1
                End If
            Else
                RowPosition = Me.CurrentRow
            End If

            If CreateWhere Then
                Dim arrWhereColumn As ArrayList = WhereColumn
                If blnIsInSelectIf AndAlso Not m_blnInDefine Then
                    blnGlobalUseTableSelectIf = BooleanTypes.False
                    RemoveSelectifColumn = WhereElementColumn
                End If
                Dim strTable As String = Me.AliasName
                If strTable.Trim.Length = 0 Then strTable = Me.BaseName
                strTable = strTable & "~" & Field
                If WhereElementColumn.Length > 0 Then
                    strTable = strTable & "~" & WhereElementColumn
                    WhereElementColumn = ""
                End If
                If Not arrWhereColumn.Contains(strTable) Then
                    arrWhereColumn.Add(strTable)
                    WhereColumn = arrWhereColumn
                End If
            End If

            Try
                If IsQTP AndAlso (IsNothing(m_dtbDataTable) OrElse m_dtbDataTable.Columns.Count = 0) Then
                    Return CDate("")
                End If

                ' Check the file status and intialize the record if necessary.
                CheckStatusAndInitializeRecord()

                If (m_intType = FileTypes.Reference AndAlso m_blnEOF) OrElse (IsNull(m_dtbDataTable.Rows(RowPosition).Item(Field))) Then
                    Return cZeroDate
                Else
                    If m_dtbDataTable.Rows(Me.CurrentRow).Item(Field).GetType.ToString = "System.Decimal" Then
                        Return ConvertNumberToScreenDate(GetDecimalFromDate((m_dtbDataTable.Rows(Me.CurrentRow).Item(Field))), Nothing, GetDefaultDateFormat, GetDefaultDateSeparator)
                    Else
                        Return ConvertNumberToScreenDate(GetDecimalFromDate(CDate(m_dtbDataTable.Rows(Me.CurrentRow).Item(Field))), Nothing, GetDefaultDateFormat, GetDefaultDateSeparator)
                    End If

                End If

                CheckLookupOnSameFile()

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Function

        ''' ---RecordBuffer--------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="FieldName"></param>
        ''' <param name="RecordBufferType"></param>
        ''' <param name="ReturnFieldType"></param>
        ''' <param name="FieldText"></param>
        ''' <param name="FieldValue"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Sub RecordBuffer(ByVal FieldName As String, ByVal RecordBufferType As RecordBufferType, ByVal ReturnFieldType As ReturnFieldType, ByRef FieldText As String, ByRef FieldValue As Decimal)
            If RecordBufferType = RecordBufferType.Get Then
                Select Case ReturnFieldType
                    Case ReturnFieldType.String
                        FieldText = GetStringValue(FieldName)
                    Case ReturnFieldType.Decimal
                        FieldValue = GetDecimalValue(FieldName)
                        FieldText = FieldValue.ToString
                    Case ReturnFieldType.Date
                        FieldText = GetDateValue(FieldName).ToString
                    Case ReturnFieldType.NumericDate
                        FieldValue = GetNumericDateValue(FieldName)
                        FieldText = FieldValue.ToString
                End Select
            Else
                Select Case ReturnFieldType
                    Case ReturnFieldType.String
                        SetValue(FieldName) = FieldText
                    Case ReturnFieldType.Decimal, ReturnFieldType.Date, ReturnFieldType.NumericDate
                        SetValue(FieldName) = FieldValue
                End Select
            End If
        End Sub
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function GetResetNumericDateValue(ByVal Field As String, Optional ByVal Position As FilePosition = FilePosition.NotSet) As Decimal
            Dim inttmpOverRide As Integer = Me.OverRideOccurrence
            If m_intSortNextOccurence >= 0 Then Me.OverRideOccurrence = m_intSortNextOccurence
            GetResetNumericDateValue = GetNumericDateTimeValue(Field, Position)
            Me.OverRideOccurrence = inttmpOverRide
            Return GetResetNumericDateValue
        End Function
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Retrieves the Decimal value from the given data field.
        ''' </summary>
        ''' <param name="Field">A string representing a field from a record-structure.</param>
        ''' <returns>A Decimal value from a data field.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        ''' If fleEMPLOYEE.GetNumericDateValue("BIRTHDATE") = 0 Then <br/>
        '''     ErrorMessage("Invalid birth date.") <br/>
        ''' End If
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function GetNumericDateValue(ByVal Field As String, ByVal Position As FilePosition) As Decimal

            Try

                Dim RowPosition As Integer

                If IsQTP Then ClearColumnJoinInfo()

                If DeleteSubFile Then
                    Return 0
                End If

                If IsQTP AndAlso Not GotSQL AndAlso blnRunForMissing Then
                    HttpContext.Current.Session("QtpStr") = True
                    Return Me.ElementOwner(Field)
                End If

#If TARGET_DB = "INFORMIX" Then
                If IsQuiz AndAlso Not IsParallel AndAlso (Not Field.ToLower.StartsWith(Me.ReturnRelation.ToLower & "_") OrElse Field.ToLower = Me.RecordIdentifier.ToLower) Then
                    Field = Me.ReturnRelation & "_" & Field
                End If
#End If

                If IsQTP AndAlso IsAt Then
                    RowPosition = m_intSortNextOccurence
                ElseIf Position = FilePosition.First Then
                    RowPosition = 0
                ElseIf Position = FilePosition.Last Then
                    If Me.Occurs = 0 Then
                        RowPosition = Me.Occurs
                    Else
                        RowPosition = Me.Occurs - 1
                    End If
                Else
                    RowPosition = Me.CurrentRow
                End If

                If CreateWhere Then
                    Dim arrWhereColumn As ArrayList = WhereColumn
                    If blnIsInSelectIf AndAlso Not m_blnInDefine Then
                        blnGlobalUseTableSelectIf = BooleanTypes.False
                        RemoveSelectifColumn = WhereElementColumn
                    End If
                    Dim strTable As String = Me.AliasName
                    If strTable.Trim.Length = 0 Then strTable = Me.BaseName
                    strTable = strTable & "~" & Field
                    If WhereElementColumn.Length > 0 Then
                        strTable = strTable & "~" & WhereElementColumn
                        WhereElementColumn = ""
                    End If
                    If Not arrWhereColumn.Contains(strTable) Then
                        arrWhereColumn.Add(strTable)
                        WhereColumn = arrWhereColumn
                    End If
                End If

                If IsQTP AndAlso (IsNothing(m_dtbDataTable) OrElse m_dtbDataTable.Columns.Count = 0) Then
                    Return 0
                End If

                Dim dblReturnValue As Decimal

                ' Check the file status and intialize the record if necessary.
                CheckStatusAndInitializeRecord()

                If m_strEditField = Field Then
                    ' If we are executing the EDIT procedure on the current field, then return the value of
                    ' FieldValue when the code prompts for the RecordBuffer value.
                    Return GetFieldValue()
                Else
                    If (m_intType = FileTypes.Reference AndAlso m_blnEOF) OrElse (IsNull(m_dtbDataTable.Rows(RowPosition).Item(Field))) Then
                        'In derived page 0 is compared against the return value of GetNumericDateValue
                        'as such this function Returns 0 instead of 18991231 
                        dblReturnValue = 0
                    Else
                        dblReturnValue = GetDecimalFromDate(CDate(m_dtbDataTable.Rows(RowPosition).Item(Field)))
                    End If
                    CheckLookupOnSameFile()

                    Return dblReturnValue
                End If

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Function

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function GetNumericDateValue(ByVal Field As String) As Decimal

            Try

                Dim RowPosition As Integer

                If DeleteSubFile Then
                    Return 0
                End If

                If IsQTP AndAlso Not GotSQL AndAlso blnRunForMissing Then
                    Return Me.ElementOwner(Field)
                End If

#If TARGET_DB = "INFORMIX" Then
                If IsQuiz AndAlso Not IsParallel AndAlso (Not Field.ToLower.StartsWith(Me.ReturnRelation.ToLower & "_") OrElse Field.ToLower = Me.RecordIdentifier.ToLower) Then
                    Field = Me.ReturnRelation & "_" & Field
                End If
#End If

                If IsQTP AndAlso IsAt Then
                    RowPosition = m_intSortNextOccurence
                Else
                    RowPosition = Me.CurrentRow
                End If

                If CreateWhere Then
                    Dim arrWhereColumn As ArrayList = WhereColumn
                    If blnIsInSelectIf AndAlso Not m_blnInDefine Then
                        blnGlobalUseTableSelectIf = BooleanTypes.False
                        RemoveSelectifColumn = WhereElementColumn
                    End If
                    Dim strTable As String = Me.AliasName
                    If strTable.Trim.Length = 0 Then strTable = Me.BaseName
                    strTable = strTable & "~" & Field
                    If WhereElementColumn.Length > 0 Then
                        strTable = strTable & "~" & WhereElementColumn
                        WhereElementColumn = ""
                    End If
                    If Not arrWhereColumn.Contains(strTable) Then
                        arrWhereColumn.Add(strTable)
                        WhereColumn = arrWhereColumn
                    End If
                End If

                If IsQTP AndAlso (IsNothing(m_dtbDataTable) OrElse m_dtbDataTable.Columns.Count = 0) Then
                    Return 0
                End If

                Dim dblReturnValue As Decimal

                ' Check the file status and intialize the record if necessary.
                CheckStatusAndInitializeRecord()

                If m_strEditField = Field Then
                    ' If we are executing the EDIT procedure on the current field, then return the value of
                    ' FieldValue when the code prompts for the RecordBuffer value.
                    Return GetFieldValue()
                Else
                    If (m_intType = FileTypes.Reference AndAlso m_blnEOF) OrElse (IsNull(m_dtbDataTable.Rows(RowPosition).Item(Field))) Then
                        'In derived page 0 is compared against the return value of GetNumericDateValue
                        'as such this function Returns 0 instead of 18991231 
                        dblReturnValue = 0
                    ElseIf (m_dtbDataTable.Columns(Field)).DataType.ToString() = "System.Decimal" Then
                        dblReturnValue = m_dtbDataTable.Rows(RowPosition).Item(Field)
                    Else
                        dblReturnValue = GetDecimalFromDate(CDate(m_dtbDataTable.Rows(RowPosition).Item(Field)))
                    End If
                    CheckLookupOnSameFile()

                    Return dblReturnValue
                End If

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Function
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function GetResetNumericDateTimeValue(ByVal Field As String, Optional ByVal Position As FilePosition = FilePosition.NotSet) As Decimal
            Dim inttmpOverRide As Integer = Me.OverRideOccurrence
            If m_intSortNextOccurence >= 0 Then Me.OverRideOccurrence = m_intSortNextOccurence
            GetResetNumericDateTimeValue = GetNumericDateTimeValue(Field, Position)
            Me.OverRideOccurrence = inttmpOverRide
            Return GetResetNumericDateTimeValue
        End Function
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Retrieves a datetime value as a number for the given field.
        ''' </summary>
        ''' <param name="Field">A string representing a field from a record-structure.</param>
        ''' <returns>A Decimal representing a DateTime value from a data field.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>T_NUMBER = fleEMPLOYEE.GetNumericDateTimeValue("AUDITDATETIME")</example>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        '''     [Mark]      21/7/2005   Modified the example.
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function GetNumericDateTimeValue(ByVal Field As String, Optional ByVal Position As FilePosition = FilePosition.NotSet) As Decimal

            Dim RowPosition As Integer

            If IsQTP Then ClearColumnJoinInfo()

            If DeleteSubFile Then
                Return 0
            End If

            If IsQTP AndAlso Not GotSQL AndAlso blnRunForMissing Then
                HttpContext.Current.Session("QtpStr") = True
                Return Me.ElementOwner(Field)
            End If

#If TARGET_DB = "INFORMIX" Then
            If IsQuiz AndAlso Not IsParallel AndAlso (Not Field.ToLower.StartsWith(Me.ReturnRelation.ToLower & "_") OrElse Field.ToLower = Me.RecordIdentifier.ToLower) Then
                Field = Me.ReturnRelation & "_" & Field
            End If
#End If

            If IsQTP AndAlso IsAt Then
                RowPosition = m_intSortNextOccurence
            ElseIf Position = FilePosition.First Then
                RowPosition = 0
            ElseIf Position = FilePosition.Last Then
                If Me.Occurs = 0 Then
                    RowPosition = Me.Occurs
                Else
                    RowPosition = Me.Occurs - 1
                End If
            Else
                RowPosition = Me.CurrentRow
            End If

            If CreateWhere Then
                Dim arrWhereColumn As ArrayList = WhereColumn
                If blnIsInSelectIf AndAlso Not m_blnInDefine Then
                    blnGlobalUseTableSelectIf = BooleanTypes.False
                    RemoveSelectifColumn = WhereElementColumn
                End If
                Dim strTable As String = Me.AliasName
                If strTable.Trim.Length = 0 Then strTable = Me.BaseName
                strTable = strTable & "~" & Field
                If WhereElementColumn.Length > 0 Then
                    strTable = strTable & "~" & WhereElementColumn
                    WhereElementColumn = ""
                End If
                If Not arrWhereColumn.Contains(strTable) Then
                    arrWhereColumn.Add(strTable)
                    WhereColumn = arrWhereColumn
                End If
            End If

            Try

                If IsQTP AndAlso (IsNothing(m_dtbDataTable) OrElse m_dtbDataTable.Columns.Count = 0) Then
                    Return 0
                End If

                Dim dblReturnValue As Decimal

                ' Check the file status and intialize the record if necessary.
                CheckStatusAndInitializeRecord()

                If m_strEditField = Field Then
                    ' If we are executing the EDIT procedure on the current field, then return the value of
                    ' FieldValue when the code prompts for the RecordBuffer value.
                    Return GetFieldValue()
                Else
                    If (m_intType = FileTypes.Reference AndAlso m_blnEOF) OrElse (IsNull(m_dtbDataTable.Rows(RowPosition).Item(Field))) Then
                        'In derived page 0 is compared against the return value of GetNumericDateValue
                        'as such this function Returns 0 instead of 18991231 
                        dblReturnValue = 0
                    Else
                        dblReturnValue = GetDecimalFromDateTime(CDate(m_dtbDataTable.Rows(RowPosition).Item(Field)))
                    End If
                    CheckLookupOnSameFile()

                    Return dblReturnValue
                End If

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Function
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function GetResetNumericTimeValue(ByVal Field As String, Optional ByVal Length As Integer = 8, Optional ByVal Position As FilePosition = FilePosition.NotSet) As Decimal
            Dim inttmpOverRide As Integer = Me.OverRideOccurrence
            If m_intSortNextOccurence >= 0 Then Me.OverRideOccurrence = m_intSortNextOccurence
            GetResetNumericTimeValue = GetNumericTimeValue(Field, Length, Position)
            Me.OverRideOccurrence = inttmpOverRide
            Return GetResetNumericTimeValue
        End Function
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Retrieves a time value as a number for the given field.
        ''' </summary>
        ''' <param name="Field">A string representing a field from a record-structure.</param>
        ''' <returns>A Decimal representing a Time value from a data field.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>T_NUMBER = fleEMPLOYEE.GetNumericTimeValue("AUDITDATETIME")</example>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        '''     [Mark]      21/7/2005   Modified the example.
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function GetNumericTimeValue(ByVal Field As String, Optional ByVal Length As Integer = 8, Optional ByVal Position As FilePosition = FilePosition.NotSet) As Decimal

            Dim RowPosition As Integer

            If IsQTP Then ClearColumnJoinInfo()

            If DeleteSubFile Then
                Return 0
            End If

            If IsQTP AndAlso Not GotSQL AndAlso blnRunForMissing Then
                HttpContext.Current.Session("QtpStr") = True
                Return Me.ElementOwner(Field)
            End If

#If TARGET_DB = "INFORMIX" Then
            If IsQuiz AndAlso Not IsParallel AndAlso (Not Field.ToLower.StartsWith(Me.ReturnRelation.ToLower & "_") OrElse Field.ToLower = Me.RecordIdentifier.ToLower) Then
                Field = Me.ReturnRelation & "_" & Field
            End If
#End If

            If IsQTP AndAlso IsAt Then
                RowPosition = m_intSortNextOccurence
            ElseIf Position = FilePosition.First Then
                RowPosition = 0
            ElseIf Position = FilePosition.Last Then
                If Me.Occurs = 0 Then
                    RowPosition = Me.Occurs
                Else
                    RowPosition = Me.Occurs - 1
                End If
            Else
                RowPosition = Me.CurrentRow
            End If

            If CreateWhere Then
                Dim arrWhereColumn As ArrayList = WhereColumn
                If blnIsInSelectIf AndAlso Not m_blnInDefine Then
                    blnGlobalUseTableSelectIf = BooleanTypes.False
                    RemoveSelectifColumn = WhereElementColumn
                End If
                Dim strTable As String = Me.AliasName
                If strTable.Trim.Length = 0 Then strTable = Me.BaseName
                strTable = strTable & "~" & Field
                If WhereElementColumn.Length > 0 Then
                    strTable = strTable & "~" & WhereElementColumn
                    WhereElementColumn = ""
                End If
                If Not arrWhereColumn.Contains(strTable) Then
                    arrWhereColumn.Add(strTable)
                    WhereColumn = arrWhereColumn
                End If
            End If

            Try

                If IsQTP AndAlso (IsNothing(m_dtbDataTable) OrElse m_dtbDataTable.Columns.Count = 0) Then
                    Return 0
                End If

                Dim dblReturnValue As Decimal

                ' Check the file status and intialize the record if necessary.
                CheckStatusAndInitializeRecord()

                If m_strEditField = Field Then
                    ' If we are executing the EDIT procedure on the current field, then return the value of
                    ' FieldValue when the code prompts for the RecordBuffer value.
                    Return GetFieldValue()
                Else
                    If (m_intType = FileTypes.Reference AndAlso m_blnEOF) OrElse (IsNull(m_dtbDataTable.Rows(RowPosition).Item(Field))) Then
                        'In derived page 0 is compared against the return value of GetNumericDateValue
                        'as such this function Returns 0 instead of 18991231 
                        dblReturnValue = 0
                    Else
                        dblReturnValue = CType(ASCII(GetDecimalFromTime(CDate(m_dtbDataTable.Rows(RowPosition).Item(Field))), 8).ToString.Substring(0, Length), Decimal)
                    End If
                    CheckLookupOnSameFile()

                    Return dblReturnValue
                End If

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Function
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function GetResetTimeValue(ByVal Field As String, Optional ByVal Length As Integer = 8, Optional ByVal Position As FilePosition = FilePosition.NotSet) As Decimal
            Dim inttmpOverRide As Integer = Me.OverRideOccurrence
            If m_intSortNextOccurence >= 0 Then Me.OverRideOccurrence = m_intSortNextOccurence
            GetResetTimeValue = GetTimeValue(Field, Position)
            Me.OverRideOccurrence = inttmpOverRide
            Return GetResetTimeValue
        End Function
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Retrieves a time value as a number for the given field.
        ''' </summary>
        ''' <param name="Field">A string representing a field from a record-structure.</param>
        ''' <returns>A String representing a Time value from a data field.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>T_NUMBER = fleEMPLOYEE.GetTimeValue("AUDITDATETIME")</example>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        '''     [Mark]      21/7/2005   Modified the example.
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function GetTimeValue(ByVal Field As String, Optional ByVal Position As FilePosition = FilePosition.NotSet) As String

            Dim RowPosition As Integer

            If IsQTP Then ClearColumnJoinInfo()

            If DeleteSubFile Then
                Return 0
            End If

            If IsQTP AndAlso Not GotSQL AndAlso blnRunForMissing Then
                HttpContext.Current.Session("QtpStr") = True
                Return Me.ElementOwner(Field)
            End If

#If TARGET_DB = "INFORMIX" Then
            If IsQuiz AndAlso Not IsParallel AndAlso (Not Field.ToLower.StartsWith(Me.ReturnRelation.ToLower & "_") OrElse Field.ToLower = Me.RecordIdentifier.ToLower) Then
                Field = Me.ReturnRelation & "_" & Field
            End If
#End If

            If IsQTP AndAlso IsAt Then
                RowPosition = m_intSortNextOccurence
            ElseIf Position = FilePosition.First Then
                RowPosition = 0
            ElseIf Position = FilePosition.Last Then
                If Me.Occurs = 0 Then
                    RowPosition = Me.Occurs
                Else
                    RowPosition = Me.Occurs - 1
                End If
            Else
                RowPosition = Me.CurrentRow
            End If

            If CreateWhere Then
                Dim arrWhereColumn As ArrayList = WhereColumn
                If blnIsInSelectIf AndAlso Not m_blnInDefine Then
                    blnGlobalUseTableSelectIf = BooleanTypes.False
                    RemoveSelectifColumn = WhereElementColumn
                End If
                Dim strTable As String = Me.AliasName
                If strTable.Trim.Length = 0 Then strTable = Me.BaseName
                strTable = strTable & "~" & Field
                If WhereElementColumn.Length > 0 Then
                    strTable = strTable & "~" & WhereElementColumn
                    WhereElementColumn = ""
                End If
                If Not arrWhereColumn.Contains(strTable) Then
                    arrWhereColumn.Add(strTable)
                    WhereColumn = arrWhereColumn
                End If
            End If


            Try
                Dim strReturnValue As String

                ' Check the file status and intialize the record if necessary.
                CheckStatusAndInitializeRecord()

                If m_strEditField = Field Then
                    ' If we are executing the EDIT procedure on the current field, then return the value of
                    ' FieldValue when the code prompts for the RecordBuffer value.
                    Return GetFieldText()
                Else
                    If (m_intType = FileTypes.Reference AndAlso m_blnEOF) OrElse (IsNull(m_dtbDataTable.Rows(RowPosition).Item(Field))) Then
                        'In derived page 0 is compared against the return value of GetNumericDateValue
                        'as such this function Returns 0 instead of 18991231 
                        strReturnValue = ASCII(0, 8)
                    Else
                        strReturnValue = ASCII(GetDecimalFromTime(CDate(m_dtbDataTable.Rows(RowPosition).Item(Field))), 8)
                    End If
                    CheckLookupOnSameFile()

                    Return strReturnValue
                End If

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Function
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function GetResetDecimalValue(ByVal Field As String, Optional ByVal Position As FilePosition = FilePosition.NotSet) As Decimal
            Dim inttmpOverRide As Integer = Me.OverRideOccurrence
            If m_intSortNextOccurence >= 0 Then Me.OverRideOccurrence = m_intSortNextOccurence
            GetResetDecimalValue = GetDecimalValue(Field, Position)
            Me.OverRideOccurrence = inttmpOverRide
            Return GetResetDecimalValue
        End Function
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Retrieves the value from a numeric field as a Decimal.
        ''' </summary>
        ''' <param name="Field">A string representing a field from a record-structure.</param>
        ''' <returns>A Decimal representing a Numeric value from a data field.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>T_NUMBER = fleEMPLOYEE.GetDecimalValue("ID_NUMBER")</example>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        '''     [Mark]      21/7/2005   Modified the example
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function GetDecimalValue(ByVal Field As String, ByVal Position As FilePosition) As Decimal

            Dim RowPosition As Integer

            If IsQTP Then ClearColumnJoinInfo()

            If DeleteSubFile Then
                Return 0
            End If

            If IsQTP AndAlso Not GotSQL AndAlso blnRunForMissing Then
                HttpContext.Current.Session("QtpStr") = True
                Return Me.ElementOwner(Field)
            End If

#If TARGET_DB = "INFORMIX" Then
            If IsQuiz AndAlso Not IsParallel AndAlso (Not Field.ToLower.StartsWith(Me.ReturnRelation.ToLower & "_") OrElse Field.ToLower = Me.RecordIdentifier.ToLower) Then
                Field = Me.ReturnRelation & "_" & Field
            End If
#End If

            If IsQTP AndAlso IsAt Then
                RowPosition = m_intSortNextOccurence
            ElseIf Position = FilePosition.First Then
                RowPosition = 0
            ElseIf Position = FilePosition.Last Then
                If Me.Occurs = 0 Then
                    RowPosition = Me.Occurs
                Else
                    RowPosition = Me.Occurs - 1
                End If
            Else
                RowPosition = Me.CurrentRow
            End If

            If CreateWhere Then
                Dim arrWhereColumn As ArrayList = WhereColumn
                If blnIsInSelectIf AndAlso Not m_blnInDefine Then
                    blnGlobalUseTableSelectIf = BooleanTypes.False
                    RemoveSelectifColumn = WhereElementColumn
                End If
                Dim strTable As String = Me.AliasName
                If strTable.Trim.Length = 0 Then strTable = Me.BaseName
                strTable = strTable & "~" & Field
                If WhereElementColumn.Length > 0 Then
                    strTable = strTable & "~" & WhereElementColumn
                    WhereElementColumn = ""
                End If
                If Not arrWhereColumn.Contains(strTable) Then
                    arrWhereColumn.Add(strTable)
                    WhereColumn = arrWhereColumn
                End If
            End If

            Try
                If IsQTP AndAlso (IsNothing(m_dtbDataTable) OrElse m_dtbDataTable.Columns.Count = 0) Then
                    Return 0
                End If

                ' Check the file status and intialize the record if necessary.
                CheckStatusAndInitializeRecord()

                If m_strEditField = Field Then
                    ' If we are executing the EDIT procedure on the current field, then return the value of
                    ' FieldValue when the code prompts for the RecordBuffer value.
                    Return GetFieldValue()
                Else
                    If (m_intType = FileTypes.Reference AndAlso m_blnEOF) OrElse (IsNull(m_dtbDataTable.Rows(RowPosition).Item(Field))) _
                    OrElse (IsTextFile AndAlso (m_dtbDataTable.Rows.Count = 0 OrElse IsNull(m_dtbDataTable.Rows(RowPosition).Item(Field)))) Then
                        Return 0
                    Else
                        ' If the field is a date, then convert it to a Decimal.  
                        If m_dtbDataTable.Rows(Me.CurrentRow).Item(Field).GetType.ToString = "System.DateTime" Then
                            Return GetDecimalFromDate(CType(m_dtbDataTable.Rows(RowPosition).Item(Field), Date))
                        ElseIf m_dtbDataTable.Rows(Me.CurrentRow).Item(Field).GetType.ToString = "System.Boolean" Then
                            ' Since SQL Server stores True as a 1, do an Absolute.  Treat True as 1 and False as 0.
                            Return Math.Abs(CType(m_dtbDataTable.Rows(RowPosition).Item(Field), Decimal))
                        Else
                            Return CType(m_dtbDataTable.Rows(RowPosition).Item(Field), Decimal)
                        End If
                    End If
                    CheckLookupOnSameFile()
                End If

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Function

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function GetDecimalValue(ByVal Field As String) As Decimal

            Dim RowPosition As Integer

            If IsQTP Then ClearColumnJoinInfo()

            If DeleteSubFile Then
                Return 0
            End If

            If IsQTP AndAlso Not GotSQL AndAlso blnRunForMissing Then
                HttpContext.Current.Session("QtpStr") = True
                Return Me.ElementOwner(Field)
            End If

#If TARGET_DB = "INFORMIX" Then
            If IsQuiz AndAlso Not IsParallel AndAlso (Not Field.ToLower.StartsWith(Me.ReturnRelation.ToLower & "_") OrElse Field.ToLower = Me.RecordIdentifier.ToLower) Then
                Field = Me.ReturnRelation & "_" & Field
            End If
#End If

            If IsQTP AndAlso IsAt Then
                RowPosition = m_intSortNextOccurence
            Else
                RowPosition = Me.CurrentRow
            End If

            If CreateWhere Then
                Dim arrWhereColumn As ArrayList = WhereColumn
                If blnIsInSelectIf AndAlso Not m_blnInDefine Then
                    blnGlobalUseTableSelectIf = BooleanTypes.False
                    RemoveSelectifColumn = WhereElementColumn
                End If
                Dim strTable As String = Me.AliasName
                If strTable.Trim.Length = 0 Then strTable = Me.BaseName
                strTable = strTable & "~" & Field
                If WhereElementColumn.Length > 0 Then
                    strTable = strTable & "~" & WhereElementColumn
                    WhereElementColumn = ""
                End If
                If Not arrWhereColumn.Contains(strTable) Then
                    arrWhereColumn.Add(strTable)
                    WhereColumn = arrWhereColumn
                End If
            End If

            Try


                If IsQTP AndAlso (IsNothing(m_dtbDataTable) OrElse m_dtbDataTable.Columns.Count = 0) Then
                    If m_HasAt = False Then
                        m_Subtoal = New Hashtable
                    End If
                    Return 0
                End If

                ' Check the file status and intialize the record if necessary.
                CheckStatusAndInitializeRecord()

                If m_strEditField = Field Then
                    ' If we are executing the EDIT procedure on the current field, then return the value of
                    ' FieldValue when the code prompts for the RecordBuffer value.
                    Return GetFieldValue()
                Else
                    If m_dtbDataTable.Rows.Count - 1 < RowPosition Then
                        Return 0
                    ElseIf (m_intType = FileTypes.Reference AndAlso m_blnEOF) OrElse (IsNull(m_dtbDataTable.Rows(RowPosition).Item(Field))) _
                    OrElse (IsTextFile AndAlso (m_dtbDataTable.Rows.Count = 0 OrElse IsNull(m_dtbDataTable.Rows(RowPosition).Item(Field)))) Then
                        Return 0
                    Else
                        ' If the field is a date, then convert it to a Decimal.  
                        If m_dtbDataTable.Rows(Me.CurrentRow).Item(Field).GetType.ToString = "System.DateTime" Then
                            Return GetDecimalFromDate(CType(m_dtbDataTable.Rows(RowPosition).Item(Field), Date))
                        ElseIf m_dtbDataTable.Rows(Me.CurrentRow).Item(Field).GetType.ToString = "System.Boolean" Then
                            ' Since SQL Server stores True as a 1, do an Absolute.  Treat True as 1 and False as 0.
                            Return Math.Abs(CType(m_dtbDataTable.Rows(RowPosition).Item(Field), Decimal))
                        Else
                            If m_dtbDataTable.Rows(RowPosition).Item(Field).ToString = "????????" Then
                                Return 0
                            End If
                            Return CType(m_dtbDataTable.Rows(RowPosition).Item(Field), Decimal)
                        End If
                    End If
                    CheckLookupOnSameFile()
                End If

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Retrieves the value from a numeric field as a Decimal.
        ''' </summary>
        ''' <param name="Field">A string representing a field from a record-structure.</param>
        ''' <param name="StartPosition">An integer indicating the start position (0-based)</param>
        ''' <param name="Length">An integer indicating the length to retrieve.</param>
        ''' <returns>A Decimal representing a Numeric value from a data field.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>T_NUMBER = fleEMPLOYEE.GetDecimalValue("ID_NUMBER")</example>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        '''     [Mark]      21/7/2005   Modified the example
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function GetDecimalValue(ByVal Field As String, ByVal StartPosition As Integer, ByVal Length As Integer) As Decimal

            Try

                If DeleteSubFile Then
                    Return 0
                End If

                If IsQTP AndAlso Not GotSQL AndAlso blnRunForMissing Then
                    Return Me.ElementOwner(Field)
                End If



                Dim value As String = GetStringValue(Field)
                Dim intOrdinal As Integer = -1
                ' Set the ordinal position of the current field.
                If IsQTP Then

                    For i As Integer = 0 To m_dtbMetaData.Rows.Count
                        If m_dtbMetaData.Rows(i)(0).ToString.ToUpper = Field.ToUpper Then
                            intOrdinal = i
                            Exit For
                        End If
                    Next

                Else
                    intOrdinal = m_dtbDataTable.Columns(Field).Ordinal
                End If

#If TARGET_DB = "INFORMIX" Then
                If IsQuiz AndAlso Not IsParallel AndAlso (Not Field.ToLower.StartsWith(Me.ReturnRelation.ToLower & "_") OrElse Field.ToLower = Me.RecordIdentifier.ToLower) Then
                    Field = Me.ReturnRelation & "_" & Field
                End If
#End If


                ' Based on the column size and the datatype, return the proper value.
                Dim intSize As Integer = CInt(m_dtbMetaData.Rows(intOrdinal).Item(2))
                Dim intDec As Integer = 0
                If value.IndexOf(".") >= 0 Then
                    intDec = VAL(value.Substring(value.IndexOf(".") + 1))
                    If intDec = 0 Then
                        value = value.Substring(0, value.IndexOf("."))
                    End If
                End If
                value = value.PadLeft(intSize, "0")

                If value.Substring(StartPosition, Length).Trim = "" Then
                    Return 0
                End If

                Return CType(value.Substring(StartPosition, Length), Decimal)


            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Function
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Deletes the temp file from the session
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <example>fleEMPLOYEE.DeleteTempFile</example>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        '''     [Mark]      21/7/2005   Modified the example
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overridable Function DeleteTempFile() As Boolean

            Try

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Function

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Function GetObjectType(ByVal Field As String) As String

            Try
                If IsQuiz AndAlso Not m_dtbDataTable.Columns.Contains(Field) Then
                    Field = Me.ReturnRelation & "_" & Field
                End If

                If m_dtbDataTable.Columns.Contains(Field) Then
                    Return m_dtbDataTable.Columns.Item(Field).DataType.ToString()
                Else
                    Return ""
                End If

            Catch ex As Exception

                Return ""

            End Try

        End Function


        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Function GetDecimalSize(ByVal Field As String) As String

            Try

                Dim Field2 As String = Field

                If IsQuiz AndAlso Field.IndexOf(Me.ReturnRelation & "_") >= 0 Then
                    Field2 = Field.Substring(Field.IndexOf(Me.ReturnRelation & "_") + (Me.ReturnRelation & "_").Length)
                End If

                If Not IsNothing(m_dtbMetaData) Then
                    If IsQTP Then
                        Dim blnFindOrdinal As Boolean = False
                        Dim intOrdinal As Integer = 0
                        For i As Integer = 0 To m_dtbMetaData.Rows.Count - 1
                            If IsQuiz Then
                                If m_dtbMetaData.Rows(i)(0).ToString.ToUpper = Field2.ToUpper Then
                                    intOrdinal = i
                                    blnFindOrdinal = True
                                    Exit For
                                End If
                            Else
                                If m_dtbMetaData.Rows(i)(0).ToString.ToUpper = Field.ToUpper Then
                                    intOrdinal = i
                                    blnFindOrdinal = True
                                    Exit For
                                End If
                            End If

                        Next

                        If blnFindOrdinal Then
                            ' In SQL Server for a Decimal, the precision can't be larger than 38 and the scale larger than 19
                            If CInt(m_dtbMetaData.Rows(intOrdinal).Item(3)) = 15 AndAlso CInt(m_dtbMetaData.Rows(intOrdinal).Item(4)) = 255 Then
                                Return "18, 0"
                            Else
                                Return CInt(m_dtbMetaData.Rows(intOrdinal).Item(3)).ToString & ", " & CInt(m_dtbMetaData.Rows(intOrdinal).Item(4)).ToString
                            End If
                        Else
                            If HttpContext.Current.Cache.Item(BaseName + "_DataTypes") Is Nothing Then
                                Return "18, 2"
                            Else
                                Dim ht As Hashtable = CType(HttpContext.Current.Cache.Item(BaseName + "_DataTypes"), Hashtable)
                                If ht.Contains(Field.ToUpper) Then
                                    Return ht.Item(Field.ToUpper)
                                Else
                                    Return "18, 2"
                                End If
                            End If
                        End If
                    Else
                        Return CInt(m_dtbMetaData.Rows(m_dtbDataTable.Columns(Field).Ordinal).Item(3)).ToString & ", " & CInt(m_dtbMetaData.Rows(m_dtbDataTable.Columns(Field).Ordinal).Item(4)).ToString
                    End If
                Else

                    If HttpContext.Current.Cache.Item(BaseName + "_DataTypes") Is Nothing Then
                        Return "18, 2"
                    Else
                        Dim ht As Hashtable = CType(HttpContext.Current.Cache.Item(BaseName + "_DataTypes"), Hashtable)
                        If ht.Contains(Field.ToUpper) Then
                            Return ht.Item(Field.ToUpper)
                        Else
                            Return "18, 2"
                        End If
                    End If

                End If

            Catch ex As Exception

                Return ""

            End Try

        End Function

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Function GetObjectSize(ByVal Field As String) As String

            Try

                Dim Field2 As String = Field

                If IsQuiz AndAlso Field.IndexOf(Me.ReturnRelation & "_") >= 0 Then
                    Field2 = Field.Substring(Field.IndexOf(Me.ReturnRelation & "_") + (Me.ReturnRelation & "_").Length)
                End If

                If IsNothing(m_dtbMetaData) AndAlso Not m_IsSubFile Then
                    GetMetaData()
                End If

                If Not IsNothing(m_dtbMetaData) Then
                    If IsQTP Then
                        Dim blnFindOrdinal As Boolean = False
                        Dim intOrdinal As Integer = 0
                        For i As Integer = 0 To m_dtbMetaData.Rows.Count - 1
                            If IsQuiz Then
                                If m_dtbMetaData.Rows(i)(0).ToString.ToUpper = Field2.ToUpper Then
                                    intOrdinal = i
                                    blnFindOrdinal = True
                                    Exit For
                                End If
                            Else
                                If m_dtbMetaData.Rows(i)(0).ToString.ToUpper = Field.ToUpper Then
                                    intOrdinal = i
                                    blnFindOrdinal = True
                                    Exit For
                                End If
                            End If

                        Next
                        If blnFindOrdinal Then
                            If m_dtbMetaData.Rows(intOrdinal).Item("DataTypeName") = "decimal" Then
                                Return CInt(m_dtbMetaData.Rows(intOrdinal).Item(3)).ToString
                            Else
                                Return CInt(m_dtbMetaData.Rows(intOrdinal).Item(2)).ToString
                            End If

                        Else
                            Return -1
                        End If
                    Else
                        Return CInt(m_dtbMetaData.Rows(m_dtbDataTable.Columns(Field).Ordinal).Item(2)).ToString
                    End If

                Else
                    If IsQuiz AndAlso Not m_dtbDataTable.Columns.Contains(Field) Then
                        Field = Me.ReturnRelation & "_" & Field
                    End If
                    Return CInt(m_dtbDataTable.Columns(Field).MaxLength)
                End If

            Catch ex As Exception

                Return ""

            End Try

        End Function


        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function GetResetStringValue(ByVal Field As String, ByVal Position As FilePosition) As String
            Dim inttmpOverRide As Integer = Me.OverRideOccurrence
            If m_intSortNextOccurence >= 0 Then Me.OverRideOccurrence = m_intSortNextOccurence
            GetResetStringValue = GetStringValue(Field, Position)
            Me.OverRideOccurrence = inttmpOverRide
            Return GetResetStringValue
        End Function

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function GetResetStringValue(ByVal Field As String) As String
            Dim inttmpOverRide As Integer = Me.OverRideOccurrence
            Dim Position As FilePosition = FilePosition.NotSet
            If m_intSortNextOccurence >= 0 Then Me.OverRideOccurrence = m_intSortNextOccurence
            GetResetStringValue = GetStringValue(Field, Position)
            Me.OverRideOccurrence = inttmpOverRide
            Return GetResetStringValue
        End Function
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Returns the value from a character field.
        ''' </summary>
        ''' <param name="Field">A string representing a field from a record-structure.</param>
        ''' <returns>A String representing a character value from a data field.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>T_STRING = fleEMPLOYEE.GetStringValue("FULLNAME")</example>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        '''     [Mark]      21/7/2005   Modified the example
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function GetStringValue(ByVal Field As String, ByVal Position As FilePosition) As String

            Dim strValue As String
            Dim RowPosition As Integer

            If DeleteSubFile Then
                Return ""
            End If

            If IsQTP AndAlso Not GotSQL AndAlso blnRunForMissing Then
                HttpContext.Current.Session("QtpStr") = True
                Return Me.ElementOwner(Field)
            End If

#If TARGET_DB = "INFORMIX" Then
            If IsQuiz AndAlso Not IsParallel AndAlso (Not Field.ToLower.StartsWith(Me.ReturnRelation.ToLower & "_") OrElse Field.ToLower = Me.RecordIdentifier.ToLower) Then
                Field = Me.ReturnRelation & "_" & Field
            End If
#End If

            If IsQTP AndAlso IsAt Then
                RowPosition = m_intSortNextOccurence
            ElseIf Position = FilePosition.First Then
                RowPosition = 0
            ElseIf Position = FilePosition.Last Then
                If Me.Occurs = 0 Then
                    RowPosition = Me.Occurs
                Else
                    RowPosition = Me.Occurs - 1
                End If
            Else
                RowPosition = Me.CurrentRow
            End If

            If CreateWhere Then
                Dim arrWhereColumn As ArrayList = WhereColumn
                If blnIsInSelectIf AndAlso Not m_blnInDefine Then
                    blnGlobalUseTableSelectIf = BooleanTypes.False
                    RemoveSelectifColumn = WhereElementColumn
                End If
                Dim strTable As String = Me.AliasName
                If strTable.Trim.Length = 0 Then strTable = Me.BaseName
                strTable = strTable & "~" & Field
                If WhereElementColumn.Length > 0 Then
                    strTable = strTable & "~" & WhereElementColumn
                    WhereElementColumn = ""
                End If
                If Not arrWhereColumn.Contains(strTable) Then
                    arrWhereColumn.Add(strTable)
                    m_strTableJoin = strTable ' This will be used by WhereColumn to call SetJoinColumnInfo. 
                    WhereColumn = arrWhereColumn
                    m_strTableJoin = String.Empty
                End If
            End If

            Try

                If IsQTP AndAlso (IsNothing(m_dtbDataTable) OrElse m_dtbDataTable.Columns.Count = 0) Then
                    Return ""
                End If

                ' Check the file status and intialize the record if necessary.
                CheckStatusAndInitializeRecord()

                If m_strEditField = Field Then
                    ' If we are executing the EDIT procedure on the current field, then return the value of
                    ' FieldValue when the code prompts for the RecordBuffer value.
                    Return GetFieldText()
                Else
                    If Type = FileTypes.Reference AndAlso m_blnEOF Then
                        strValue = cEmptyString
                    Else
                        If IsNull(m_dtbDataTable.Rows(RowPosition).Item(Field)) Then
                            strValue = cEmptyString
                        Else
                            strValue = m_dtbDataTable.Rows(RowPosition).Item(Field).ToString()
                        End If
                    End If
                    strValue = strValue.Replace(Chr(0), "") ' Ensure we have no NULL characters.
                    strValue = ReturnStringBasedOnColumnInformation(Field, strValue)
                    CheckLookupOnSameFile()

                    Return strValue
                End If

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Function

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function GetStringValue(ByVal Field As String) As String

            Dim strValue As String
            Dim RowPosition As Integer

            If DeleteSubFile Then
                Return ""
            End If

            If IsQTP AndAlso Not GotSQL AndAlso blnRunForMissing Then
                HttpContext.Current.Session("QtpStr") = True
                Return Me.ElementOwner(Field)
            End If

#If TARGET_DB = "INFORMIX" Then
            If IsQuiz AndAlso Not IsParallel AndAlso (Not Field.ToLower.StartsWith(Me.ReturnRelation.ToLower & "_") OrElse Field.ToLower = Me.RecordIdentifier.ToLower) Then
                Field = Me.ReturnRelation & "_" & Field
            End If
#End If

            If IsQTP AndAlso IsAt Then
                RowPosition = m_intSortNextOccurence
            Else
                RowPosition = Me.CurrentRow
            End If

            If CreateWhere Then
                Dim arrWhereColumn As ArrayList = WhereColumn
                If blnIsInSelectIf AndAlso Not m_blnInDefine Then
                    blnGlobalUseTableSelectIf = BooleanTypes.False
                    RemoveSelectifColumn = WhereElementColumn
                End If
                Dim strTable As String = Me.AliasName
                If strTable.Trim.Length = 0 Then strTable = Me.BaseName
                strTable = strTable & "~" & Field
                If WhereElementColumn.Length > 0 Then
                    strTable = strTable & "~" & WhereElementColumn
                    WhereElementColumn = ""
                End If
                If Not arrWhereColumn.Contains(strTable) Then
                    arrWhereColumn.Add(strTable)
                    m_strTableJoin = strTable ' This will be used by WhereColumn to call SetJoinColumnInfo. 
                    WhereColumn = arrWhereColumn
                    m_strTableJoin = String.Empty
                End If
            End If

            Try

                If IsQTP AndAlso (IsNothing(m_dtbDataTable) OrElse m_dtbDataTable.Columns.Count = 0) Then
                    Return ""
                End If

                ' Check the file status and intialize the record if necessary.
                CheckStatusAndInitializeRecord()

                If m_strEditField = Field Then
                    ' If we are executing the EDIT procedure on the current field, then return the value of
                    ' FieldValue when the code prompts for the RecordBuffer value.
                    Return GetFieldText()
                Else
                    If Type = FileTypes.Reference AndAlso m_blnEOF Then
                        strValue = cEmptyString
                    Else
                        If m_dtbDataTable.Rows.Count - 1 < RowPosition Then
                            strValue = cEmptyString
                        ElseIf Not m_dtbDataTable.Columns.Contains(Field) OrElse IsNull(m_dtbDataTable.Rows(RowPosition).Item(Field)) Then
                            strValue = cEmptyString
                        Else
                            strValue = m_dtbDataTable.Rows(RowPosition).Item(Field).ToString()
                        End If
                    End If
                    strValue = strValue.Replace(Chr(0), "") ' Ensure we have no NULL characters.
                    strValue = ReturnStringBasedOnColumnInformation(Field, strValue)
                    CheckLookupOnSameFile()

                    Return strValue
                End If

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Function


        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function GetStringValue(ByVal Field As String, ByVal intStart As Integer, ByVal intLength As Integer, Optional ByVal Position As FilePosition = FilePosition.NotSet) As String

            Dim strValue As String
            Dim RowPosition As Integer

            If DeleteSubFile Then
                Return ""
            End If

            If IsQTP AndAlso Not GotSQL AndAlso blnRunForMissing Then
                Return Me.ElementOwner(Field, intStart, intLength)
            End If

#If TARGET_DB = "INFORMIX" Then
            If IsQuiz AndAlso Not IsParallel AndAlso (Not Field.ToLower.StartsWith(Me.ReturnRelation.ToLower & "_") OrElse Field.ToLower = Me.RecordIdentifier.ToLower) Then
                Field = Me.ReturnRelation & "_" & Field
            End If
#End If

            If IsQTP AndAlso IsAt Then
                RowPosition = m_intSortNextOccurence
            ElseIf Position = FilePosition.First Then
                RowPosition = 0
            ElseIf Position = FilePosition.Last Then
                If Me.Occurs = 0 Then
                    RowPosition = Me.Occurs
                Else
                    RowPosition = Me.Occurs - 1
                End If
            Else
                RowPosition = Me.CurrentRow
            End If

            If CreateWhere Then
                Dim arrWhereColumn As ArrayList = WhereColumn
                If blnIsInSelectIf AndAlso Not m_blnInDefine Then
                    blnGlobalUseTableSelectIf = BooleanTypes.False
                    RemoveSelectifColumn = WhereElementColumn
                End If
                Dim strTable As String = Me.AliasName
                If strTable.Trim.Length = 0 Then strTable = Me.BaseName

                Select Case Me.GetType.ToString

                    Case "Core.Windows.UI.Core.Windows.OracleFileObject"
                        strTable = strTable & "~" & "Substr( " & Field & "," & intStart + 1 & "," & intLength & ")"
                    Case "Core.Windows.UI.Core.Windows.SqlFileObject"
                        strTable = strTable & "~" & "Substring( " & Field & "," & intStart + 1 & "," & intLength & ")"
                    Case "Core.Windows.UI.Core.Windows.IfxFileObject"
                        strTable = strTable & "~" & "Substr( " & Field & "," & intStart + 1 & "," & intLength & ")"

                End Select


                If WhereElementColumn.Length > 0 Then
                    strTable = strTable & "~" & WhereElementColumn
                    WhereElementColumn = ""
                End If
                If Not arrWhereColumn.Contains(strTable) Then
                    arrWhereColumn.Add(strTable)
                    WhereColumn = arrWhereColumn
                End If
            End If

            Try

                If IsQTP AndAlso (IsNothing(m_dtbDataTable) OrElse m_dtbDataTable.Columns.Count = 0) Then
                    Return ""
                End If

                ' Check the file status and intialize the record if necessary.
                CheckStatusAndInitializeRecord()

                If m_strEditField = Field Then
                    ' If we are executing the EDIT procedure on the current field, then return the value of
                    ' FieldValue when the code prompts for the RecordBuffer value.
                    Return GetFieldText()
                Else
                    If Type = FileTypes.Reference AndAlso m_blnEOF Then
                        strValue = cEmptyString
                    Else
                        If IsNull(m_dtbDataTable.Rows(RowPosition).Item(Field)) Then
                            strValue = cEmptyString
                        Else
                            strValue = m_dtbDataTable.Rows(RowPosition).Item(Field).ToString()
                        End If
                    End If
                    strValue = strValue.Replace(Chr(0), "") ' Ensure we have no NULL characters.
                    strValue = ReturnStringBasedOnColumnInformation(Field, strValue)
                    CheckLookupOnSameFile()

                    Return strValue.Substring(intStart, intLength)
                End If

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Function


        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' GetDefaultDateFormat returns "DateFormat" set in "AppSettings" section of web.config.
        ''' If not set in web.config, the default is "YYYYMMDD"
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[mayur]	8/19/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Shared Function GetDefaultDateFormat() As String
            If m_strDefaultDateFormat Is Nothing Then
                m_strDefaultDateFormat = System.Web.HttpContext.Current.Application(cDefaultDateFormat)
                'if not defined in Application collection, looking into AppSettings
                If m_strDefaultDateFormat Is Nothing Then m_strDefaultDateFormat = System.Configuration.ConfigurationManager.AppSettings("DateFormat")
                ' NOTE: This is for the purposes of the user entering a date using this format.  We will always
                '       internally (FIELDVALUE, etc.) treat this date in the format YYYYMMDD when manipulating it.
                ' Set the default date format based on the dictionary.  If not set, we will use YYYYMMDD.
                If m_strDefaultDateFormat Is Nothing Then m_strDefaultDateFormat = ""
            End If
            Return m_strDefaultDateFormat
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' GetDefaultDateSeparator returns "DateSeparator" set in "AppSettings" section of web.config.
        ''' If not set in web.config, it uses "/" as the default separator.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[mayur]	8/19/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Function GetDefaultDateSeparator() As String
            If m_strDefaultDateSeparator Is Nothing Then
                m_strDefaultDateSeparator = System.Web.HttpContext.Current.Application(cDefaultDateSeparator) & ""
                'if not defined in Application collection, looking into AppSettings
                If m_strDefaultDateSeparator Is Nothing Then m_strDefaultDateSeparator = System.Configuration.ConfigurationManager.AppSettings("DateSeparator")
                ' Set the default date Separator based on the dictionary.  If not set, the default is "/".
                If m_strDefaultDateSeparator Is Nothing OrElse m_strDefaultDateSeparator.Length = 0 Then
                    If IsNullSeparator() Then
                        m_strDefaultDateSeparator = String.Empty
                    Else
                        m_strDefaultDateSeparator = ""
                    End If
                End If
            End If
            Return m_strDefaultDateSeparator
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' IsNullSeparator returns "NullSeparator" set in "AppSettings" section of web.config.
        ''' If not set in web.config, it returns False.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[mayur]	8/19/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Private Shared Function IsNullSeparator() As Boolean
            If m_strNullSeparator Is Nothing Then
                m_strNullSeparator = System.Configuration.ConfigurationManager.AppSettings("Default Null Separator")

                'if not defined in Application collection, looking into AppSettings
                If m_strNullSeparator Is Nothing Then m_strNullSeparator = System.Configuration.ConfigurationManager.AppSettings("NullSeparator")
                ' Set the default date Separator based on the dictionary.  If not set, the default is "/".
                If m_strNullSeparator Is Nothing OrElse m_strNullSeparator.Length = 0 Then m_strNullSeparator = "False"
            End If
            Return (m_strNullSeparator = "True")
        End Function

        ''' --- IsValidColumn ------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of IsValidColumn.
        ''' </summary>
        ''' <param name="Owner">The schema/database owner.</param>
        ''' <param name="ColumnPosition">The column ordinal position</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        Protected Function IsRelationalPrimaryKeyValue(ByVal Owner As String, ByVal ColumnPosition As Integer) As Boolean

            Dim blnRetVal As Boolean = False
            Dim strRelationalFiles As String = System.Configuration.ConfigurationManager.AppSettings("RelationalSchemas")
            If Not strRelationalFiles Is Nothing Then
                If m_dtbMetaData.Rows(ColumnPosition).Item(5).ToString = "False" AndAlso m_dtbMetaData.Rows(ColumnPosition).Item(6).ToString = "True" Then
                    Dim ar() As String = strRelationalFiles.Split(","c)
                    For intCount As Integer = 0 To UBound(ar)
                        If ar(intCount).Trim = Owner.Replace(".dbo", "") Then
                            blnRetVal = True
                        End If
                    Next
                End If
            End If

            Return blnRetVal

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Returns the value from a character field.
        ''' </summary>
        ''' <param name="Field">A string representing a field from a record-structure.</param>
        ''' <returns>A String representing a character value from a data field.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>T_STRING = fleEMPLOYEE.GetStringValue("FULLNAME")</example>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        '''     [Mark]      21/7/2005   Modified the example
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function GetSortValue(ByVal Field As String, ByVal Sort As SortType) As String

            Dim strValue As String

            Try

                If IsQTP AndAlso GetSQL Then
                    If (Not QTPOrderBy.Replace(" DESC ", "").EndsWith(ElementOwner(Field))) AndAlso QTPOrderBy.Replace(" DESC ", "").IndexOf(ElementOwner(Field) & ", ") = -1 Then
                        If QTPOrderBy.Length > 0 Then QTPOrderBy = QTPOrderBy & ", "
                        QTPOrderBy = QTPOrderBy & ElementOwner(Field)
                        If Sort = SortType.Descending Then
                            QTPOrderBy = QTPOrderBy & " DESC "
                        End If
                        Return ""
                    End If
                End If

                If (m_IsSubFile AndAlso (IsNothing(m_dtbDataTable) OrElse m_dtbDataTable.Columns.Count = 0)) OrElse DeleteSubFile Then
                    Return ""
                End If

#If TARGET_DB = "INFORMIX" Then
                If IsQuiz AndAlso Not IsParallel AndAlso (Not Field.ToLower.StartsWith(Me.ReturnRelation.ToLower & "_") OrElse Field.ToLower = Me.RecordIdentifier.ToLower) Then
                    Field = Me.ReturnRelation & "_" & Field
                End If
#End If

                ' Check the file status and intialize the record if necessary.
                CheckStatusAndInitializeRecord()

                If m_strEditField = Field Then
                    ' If we are executing the EDIT procedure on the current field, then return the value of
                    ' FieldValue when the code prompts for the RecordBuffer value.
                    Return GetFieldText()
                Else
                    If Type = FileTypes.Reference AndAlso m_blnEOF Then
                        strValue = cEmptyString
                    Else
                        If IsNull(m_dtbDataTable.Rows(Me.CurrentRow).Item(Field)) Then
                            strValue = cEmptyString
                        Else
                            If m_dtbDataTable.Rows(Me.CurrentRow).Item(Field).GetType.ToString = "System.Decimal" Then
                                strValue = m_dtbDataTable.Rows(Me.CurrentRow).Item(Field).ToString().Split(".")(0).PadLeft(12, "0") & "." & m_dtbDataTable.Rows(Me.CurrentRow).Item(Field).ToString().Split(".")(0).PadRight(6, "0")
                            Else
                                strValue = m_dtbDataTable.Rows(Me.CurrentRow).Item(Field).ToString()
                            End If

                        End If
                    End If
                    strValue = ReturnStringBasedOnColumnInformation(Field, strValue, True)

                    If Sort = Framework.SortType.Descending Then
                        strValue = strValue & "~!Descending!~"
                    End If
                    Return strValue
                End If

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Function


        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function GetSortValue(ByVal Field As String, ByVal intStart As Integer, ByVal intLength As Integer, ByVal Sort As SortType) As String

            Dim strValue As String

            Try

                If IsQTP And GetSQL Then

                    If (Not QTPOrderBy.Replace(" DESC ", "").EndsWith(ElementOwner(Field, intStart, intLength))) AndAlso QTPOrderBy.Replace(" DESC ", "").IndexOf(ElementOwner(Field, intStart, intLength) & ", ") = -1 Then
                        If QTPOrderBy.Length > 0 Then QTPOrderBy = QTPOrderBy & ", "
                        QTPOrderBy = QTPOrderBy & ElementOwner(Field, intStart, intLength)
                        If Sort = SortType.Descending Then
                            QTPOrderBy = QTPOrderBy & " DESC "
                        End If
                        Return ""
                    End If
                End If

                If (m_IsSubFile AndAlso (IsNothing(m_dtbDataTable) OrElse m_dtbDataTable.Columns.Count = 0)) OrElse DeleteSubFile Then
                    Return ""
                End If

#If TARGET_DB = "INFORMIX" Then
                If IsQuiz AndAlso Not IsParallel AndAlso (Not Field.ToLower.StartsWith(Me.ReturnRelation.ToLower & "_") OrElse Field.ToLower = Me.RecordIdentifier.ToLower) Then
                    Field = Me.ReturnRelation & "_" & Field
                End If
#End If

                ' Check the file status and intialize the record if necessary.
                CheckStatusAndInitializeRecord()

                If m_strEditField = Field Then
                    ' If we are executing the EDIT procedure on the current field, then return the value of
                    ' FieldValue when the code prompts for the RecordBuffer value.
                    Return GetFieldText()
                Else
                    If Type = FileTypes.Reference AndAlso m_blnEOF Then
                        strValue = cEmptyString
                    Else
                        If IsNull(m_dtbDataTable.Rows(Me.CurrentRow).Item(Field)) Then
                            strValue = cEmptyString
                        Else
                            strValue = m_dtbDataTable.Rows(Me.CurrentRow).Item(Field).ToString()
                        End If
                    End If
                    strValue = ReturnStringBasedOnColumnInformation(Field, strValue, True)

                    strValue = strValue.Substring(intStart, intLength)
                    If Sort = Framework.SortType.Descending Then
                        strValue = strValue & "~!Descending!~"
                    End If
                    Return strValue
                End If

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Function

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function GetSortValue(ByVal Field As String) As String

            Dim strValue As String

            Try

                If IsQTP AndAlso GetSQL Then
                    If (Not QTPOrderBy.Replace(" DESC ", "").EndsWith(ElementOwner(Field))) AndAlso QTPOrderBy.Replace(" DESC ", "").IndexOf(ElementOwner(Field) & ", ") = -1 Then
                        If QTPOrderBy.Length > 0 Then QTPOrderBy = QTPOrderBy & ", "
                        QTPOrderBy = QTPOrderBy & ElementOwner(Field)

                        Return ""
                    End If
                End If

                If (m_IsSubFile AndAlso (IsNothing(m_dtbDataTable) OrElse m_dtbDataTable.Columns.Count = 0)) OrElse DeleteSubFile Then
                    Return ""
                End If

#If TARGET_DB = "INFORMIX" Then
                If IsQuiz AndAlso Not IsParallel AndAlso (Not Field.ToLower.StartsWith(Me.ReturnRelation.ToLower & "_") OrElse Field.ToLower = Me.RecordIdentifier.ToLower) Then
                    Field = Me.ReturnRelation & "_" & Field
                End If
#End If

                ' Check the file status and intialize the record if necessary.
                CheckStatusAndInitializeRecord()

                If m_strEditField = Field Then
                    ' If we are executing the EDIT procedure on the current field, then return the value of
                    ' FieldValue when the code prompts for the RecordBuffer value.
                    Return GetFieldText()
                Else
                    If Type = FileTypes.Reference AndAlso m_blnEOF Then
                        strValue = cEmptyString
                    Else
                        If IsNull(m_dtbDataTable.Rows(Me.CurrentRow).Item(Field)) Then
                            strValue = cEmptyString
                        Else
                            If m_dtbDataTable.Rows(Me.CurrentRow).Item(Field).GetType.ToString = "System.Decimal" Then
                                strValue = m_dtbDataTable.Rows(Me.CurrentRow).Item(Field).ToString().Split(".")(0).PadLeft(12, "0") & "." & m_dtbDataTable.Rows(Me.CurrentRow).Item(Field).ToString().Split(".")(0).PadRight(6, "0")
                            Else
                                strValue = m_dtbDataTable.Rows(Me.CurrentRow).Item(Field).ToString()
                            End If

                        End If
                    End If
                    strValue = ReturnStringBasedOnColumnInformation(Field, strValue, True)


                    Return strValue
                End If

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Function


        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function GetSortValue(ByVal Field As String, ByVal intStart As Integer, ByVal intLength As Integer) As String

            Dim strValue As String

            Try

                If IsQTP And GetSQL Then

                    If (Not QTPOrderBy.Replace(" DESC ", "").EndsWith(ElementOwner(Field, intStart, intLength))) AndAlso QTPOrderBy.Replace(" DESC ", "").IndexOf(ElementOwner(Field, intStart, intLength) & ", ") = -1 Then
                        If QTPOrderBy.Length > 0 Then QTPOrderBy = QTPOrderBy & ", "
                        QTPOrderBy = QTPOrderBy & ElementOwner(Field, intStart, intLength)

                        Return ""
                    End If
                End If

                If (m_IsSubFile AndAlso (IsNothing(m_dtbDataTable) OrElse m_dtbDataTable.Columns.Count = 0)) OrElse DeleteSubFile Then
                    Return ""
                End If

#If TARGET_DB = "INFORMIX" Then
                If IsQuiz AndAlso Not IsParallel AndAlso (Not Field.ToLower.StartsWith(Me.ReturnRelation.ToLower & "_") OrElse Field.ToLower = Me.RecordIdentifier.ToLower) Then
                    Field = Me.ReturnRelation & "_" & Field
                End If
#End If

                ' Check the file status and intialize the record if necessary.
                CheckStatusAndInitializeRecord()

                If m_strEditField = Field Then
                    ' If we are executing the EDIT procedure on the current field, then return the value of
                    ' FieldValue when the code prompts for the RecordBuffer value.
                    Return GetFieldText()
                Else
                    If Type = FileTypes.Reference AndAlso m_blnEOF Then
                        strValue = cEmptyString
                    Else
                        If IsNull(m_dtbDataTable.Rows(Me.CurrentRow).Item(Field)) Then
                            strValue = cEmptyString
                        Else
                            strValue = m_dtbDataTable.Rows(Me.CurrentRow).Item(Field).ToString()
                        End If
                    End If
                    strValue = ReturnStringBasedOnColumnInformation(Field, strValue, True)

                    strValue = strValue.Substring(intStart, intLength)

                    Return strValue
                End If

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Function



        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Retrieves the ROWID for the current record.
        ''' </summary>
        ''' <returns>A String representing the current records ROWID.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        ''' Private Sub fleEMPLOYEE_SelectIf(ByRef SelectIfClause As String) Handles fleEMPLOYEE.SelectIf <br/>
        ''' <br/>
        '''     Try <br/>
        ''' <br/>
        '''         Dim strSQL As StringBuilder = New StringBuilder("") <br/>
        ''' <br/>
        '''         strSQL.Append(" (EMPLOYEE.ROWID  = ").Append(StringToField(fleEMPLOYEE.RecordLocation())).Append(")") <br/>
        ''' <br/>
        '''         SelectIfClause = strSQL.ToString() <br/>
        ''' <br/>
        '''     Catch ex As CustomApplicationException <br/>
        ''' <br/>
        '''         Throw ex <br/>
        ''' <br/>
        '''     Catch ex As Exception <br/>
        ''' <br/>
        '''         ExceptionManager.Publish(ex) <br/>
        ''' <br/>   Throw ex <br/>
        ''' <br/>
        '''     End Try <br/>
        ''' <br/>
        ''' End Sub
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        '''     [Mark]      21/7/2005   Modified the example
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function RecordLocation() As String Implements IFileObject.RecordLocation

            Dim strValue As String

            Try
                ' Determine the file status.
                CheckFileStatus()

                If Type = FileTypes.Reference AndAlso m_blnEOF Then
                    strValue = cEmptyString
                Else
                    If IsNull(m_dtbDataTable.Rows(Me.CurrentRow).Item("ROW_ID")) Then
                        strValue = cEmptyString
                    Else
                        strValue = m_dtbDataTable.Rows(Me.CurrentRow).Item("ROW_ID").ToString()
                    End If
                End If

                Return strValue

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Function

        ''' ---NullValue--------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="Field"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Function NullValue(ByVal Field As String) As String
            Dim strReturnValue As String
            strReturnValue = GetStringValue(Field)
            If strReturnValue.Trim = String.Empty Then
                Return cEmptyString
            Else
                Return strReturnValue.TrimEnd
            End If
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Moves the position to the first record in the DataReader or DataTable.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <example>fleEMPLOYEE.MoveFirst</example>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        '''     [Mark]      21/7/2005   Modified the example
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overridable Sub MoveFirst() Implements IFileObject.MoveFirst

            Try
                If m_intType <> FileTypes.Reference Then
                    GoToRecord(0)
                End If
            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Moves the position to the next record in the DataReader or DataTable.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <example>fleEMPLOYEE.MoveNext</example>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        '''     [Mark]      21/7/2005   Modified the example
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overridable Sub MoveNext()

            Try
                If Not Me.EOF Then
                    If m_intType <> FileTypes.Reference Then
                        GoToRecord(Me.CurrentRow + 1)
                    End If
                End If

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Moves the position to the previous record in the DataTable
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <example>fleEMPLOYEE.MovePrevious</example>
        ''' <history>
        ''' 	[Campbell]	4/11/2005	Created
        '''     [Mark]      21/7/2005   Modified the example
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overridable Sub MovePrevious()

            Try
                If Not Me.BOF Then
                    If m_intType <> FileTypes.Reference Then
                        GoToRecord(Me.CurrentRow - 1)
                    End If
                End If

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Sub

#Region " Methods to implement 'ForMissing' method "

        'Notes:
        '1. ForMissing should not be called on File which doesn't Occur
        '2. File should be of type Primary, Detail or Secondary
        ''' --- MoveFirstMissing ---------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of MoveFirstMissing.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Private Function MoveFirstMissing() As Integer

            Dim intCurrentRow As Integer
            Dim intRowCount As Integer
            Dim intOccurs As Integer
            If m_intOccurs > 0 Then
                intOccurs = m_intOccurs - 1
            Else
                intOccurs = 0
            End If

            intRowCount = (m_dtbDataTable.Rows.Count - 1)
            For intCurrentRow = 0 To (intRowCount)
                If m_blnNewRecord(intCurrentRow) AndAlso (Not m_blnAlteredRecord(intCurrentRow)) Then
                    Exit For
                End If
            Next

            Return MoveToMissing(intCurrentRow)
        End Function

        ''' --- MoveToMissing ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of MoveToMissing.
        ''' </summary>
        ''' <param name="RowPosition"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Private Function MoveToMissing(ByVal RowPosition As Integer) As Integer

            Dim intOccurs As Integer
            If m_intOccurs > 0 Then
                intOccurs = m_intOccurs - 1
            Else
                intOccurs = 0
            End If
            'If new RowPosition for "MissingRow" is outside the "Occurs", return -1
            Select Case RowPosition
                Case Is > intOccurs
                    If Me.m_intRecordsToRetrieve > 0 Then
                        With m_dtbDataTable.Rows
                            Dim intTotalRowsInTable As Integer
                            intTotalRowsInTable = .Count
                            If intTotalRowsInTable > Me.m_intOccurs Then
                                For i As Integer = m_intOccurs To intTotalRowsInTable - 1
                                    .RemoveAt(Me.m_intOccurs)
                                Next
                            End If
                        End With
                    End If
                    Return -1
                Case Is < 0
                    Return -1
                Case Else
                    AddBlankRecord(RowPosition, True)

                    Return RowPosition
            End Select
        End Function

        ''' --- MoveNextMissing ----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of MoveNextMissing.
        ''' </summary>
        ''' <param name="ErrorInLastRecord"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Private Function MoveNextMissing(ByRef ErrorInLastRecord As Boolean) As Integer
            Dim intCurrentOccurrence As Integer
            Dim intTotalRecordsFound As Integer
            Dim intTotalRecordsProcessed As Integer

            intTotalRecordsProcessed = Me.TotalRecordsProcessed
            If intTotalRecordsProcessed < 0 Then
                intTotalRecordsProcessed = 0
            End If

            intTotalRecordsFound = Me.TotalRecordsFound
            If intTotalRecordsFound < 0 Then
                intTotalRecordsFound = 0
            End If

            If ErrorInLastRecord Then
                Dim blnExit As Boolean = False

                'ErrorInLastRecord has specifically been added to handle Errors in Find/DetailFind
                intCurrentOccurrence = Me.CurrentRow
                'Remove the current record on which an error has occurred
                With m_dtbDataTable
                    .Rows.RemoveAt(intCurrentOccurrence)
                    .AcceptChanges()
                    If (.Rows.Count = intCurrentOccurrence) Then
                        If intTotalRecordsProcessed < intTotalRecordsFound Then
                            'Add New blank record
                            AddBlankRecord(intCurrentOccurrence)
                        Else
                            blnExit = True
                        End If
                    End If
                End With

                'Reset ErrorInLastRecord to False, so that we can track new errors
                ErrorInLastRecord = False
                If blnExit Then
                    intCurrentOccurrence = -1
                End If
            Else
                intCurrentOccurrence = Me.CurrentRow + 1
                If (Me.m_dtbDataTable.Rows.Count = intCurrentOccurrence) AndAlso intTotalRecordsProcessed = intTotalRecordsFound Then
                    intCurrentOccurrence = -1
                Else
                    intCurrentOccurrence = MoveToMissing(intCurrentOccurrence)
                End If

            End If
            Return intCurrentOccurrence
        End Function

        ''' --- AddBlankRecord -----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of AddBlankRecord.
        ''' </summary>
        ''' <param name="RowPosition"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Function AddBlankRecord(ByVal RowPosition As Integer, Optional ByVal blnSetOccurrence As Boolean = False) As Boolean
            'During "ForMissing" if the targetted RowPosition is not there in
            'm_dtbDataTable, and if its within the range of OCCURS, insert
            'a new record and initialize the columns
            If RowPosition > (m_dtbDataTable.Rows.Count - 1) Then
                CreateNewRow(m_dtbDataTable)

                If blnSetOccurrence Then
                    'Set Main Occurrence on the Page to next occurrence and if applicable, bind Grid Fields
                    SetOccurrence(RowPosition)
                End If

                If Me.Type = FileTypes.Detail Then
                    ' Set NewRecord Status to True
                    m_blnNewRecord(RowPosition) = True
                End If

                Return True
            Else
                If blnSetOccurrence Then
                    'Set Main Occurrence on the Page to next occurrence and if applicable, bind Grid Fields
                    SetOccurrence(RowPosition)
                End If
                Return False
            End If

        End Function
#End Region

        ''' --- HasRecordsToProcessForMissing --------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of HasRecordsToProcessForMissing.
        ''' </summary>
        ''' <param name="RecordsToFill"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        '''     [Mayur] August 30, 2005 Changed to reset AccessOK based on records found, changed to address "AcessOK" in MBS03 (Glassman) in Find Procedure
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Function HasRecordsToProcessForMissing(ByVal RecordsToFill As Integer, ByVal TotalRecordsFound As Integer) As Boolean
            'This function is an internal function used to check whether there is data
            'to process or not. If there is no data, it will continue to process GetDataInternal
            'otherwise return True and AccessOk will be set to True
            'This method is designed to be called from GetDataInternal 
            Dim intCurrentRow As Integer = Me.CurrentRow
            If RecordsToFill > 0 Then
                Dim intConsiderCurrentRowAsMissingRow As Integer
                If m_blnErrorInLastRecord Then
                    intConsiderCurrentRowAsMissingRow = 0
                Else
                    intConsiderCurrentRowAsMissingRow = 1
                End If

                If (Me.m_dtbDataTable.Rows.Count = intCurrentRow + intConsiderCurrentRowAsMissingRow) AndAlso ((Me.CurrentRow + RecordsToFill) = Me.Occurs) Then
                    'We need to retrieve data to fill records with an error
                    RecordsToFill = RecordsToFill  'TODO: to be removed; added to set break point
                Else
                    'We still have records to process
                    SetAccessOkOnPage(intCurrentRow < TotalRecordsFound)
                    Return True
                End If
            Else
                'We still have records to process
                SetAccessOkOnPage(intCurrentRow < TotalRecordsFound)
                Return True
            End If
            Return False
        End Function

        ''' --- HasRecordsToProcessFor ---------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of HasRecordsToProcessFor.
        ''' </summary>
        ''' <param name="RecordsToFill"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Function HasRecordsToProcessFor(ByVal RecordsToFill As Integer) As Boolean
            'This function is an internal function used to check whether there is data
            'to process or not. If there is no data, it will continue to process GetDataInternal
            'otherwise return True and AccessOk will be set to True
            'This method is designed to be called from GetDataInternal 
            If RecordsToFill > 0 Then
                Dim intCurrentRow As Integer = Me.CurrentRow
                Dim intConsiderCurrentRowAsMissingRow As Integer
                If m_blnErrorInLastRecord Then
                    intConsiderCurrentRowAsMissingRow = 0
                Else
                    intConsiderCurrentRowAsMissingRow = 1
                End If

                If (Me.m_dtbDataTable.Rows.Count = intCurrentRow + intConsiderCurrentRowAsMissingRow) AndAlso ((Me.CurrentRow + RecordsToFill) = Me.Occurs) Then
                    'We need to retrieve data to fill records with an error
                    RecordsToFill = RecordsToFill  'TODO: to be removed; added to set break point
                Else
                    'We still have records to process
                    SetAccessOkOnPage(True)
                    Return True
                End If
            Else
                'We still have records to process
                SetAccessOkOnPage(True)
                Return True
            End If
            Return False
        End Function

        ''' --- WhileRetrieving ----------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Retrieves and processes a set of records in a loop.
        ''' </summary>
        ''' <param name="WhereClause"></param>
        ''' <param name="OrderByClause"></param>
        ''' <param name="Sequential"></param>
        ''' <param name="Backward"></param>
        ''' <param name="IsOptional"></param>
        ''' <remarks>
        '''     The WhileRetrieving method is used for specialized processing of a set of data records.
        ''' It will loop through the records retrieved by the File class and execute the code within the loop
        ''' for each record. Looping through the records will end when the last record retrieved in processed, 
        ''' or if the Break method is encountered.
        ''' <note>The WhileRetrieving method can only be used on Designer Files. Using WhileRetrieving on other
        ''' file types may produce unexpected results
        ''' </note>
        ''' </remarks>
        ''' <example>
        ''' Do While fleEMPLOYEE.WhileRetrieving() <br/>
        '''     Select Case fleMPLOYEE.GetStringValue("GROUPSTATUS") <br/>
        '''         Case "BRO" <br/>
        '''             intGROUP_COUNT = intGROUP_COUNT + 1 <br/>
        '''         Case "CAD" <br/>
        '''             fleEMPLOYEE.Break() <br/>
        '''     End Select <br/>
        ''' Loop
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        '''     [Mark]      21/7/2005   Modified remarks and added example
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        ''' 
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function WhileRetrieving() As Boolean
            Return WhileRetrieving("", "", False, False, False)
        End Function
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function WhileRetrieving(ByVal WhereClause As String) As Boolean
            Return WhileRetrieving(WhereClause, "", False, False, False)
        End Function
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function WhileRetrieving(ByVal WhereClause As String, ByVal OrderByClause As String) As Boolean
            Return WhileRetrieving(WhereClause, OrderByClause, False, False, False)
        End Function
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function WhileRetrieving(ByVal WhereClause As String, ByVal OrderByClause As String, ByVal Sequential As Boolean) As Boolean
            Return WhileRetrieving(WhereClause, OrderByClause, Sequential, False, False)
        End Function
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function WhileRetrieving(ByVal WhereClause As String, ByVal OrderByClause As String, ByVal Sequential As Boolean, ByVal Backward As Boolean) As Boolean
            Return WhileRetrieving(WhereClause, OrderByClause, Sequential, Backward, False)
        End Function

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function WhileRetrieving(ByVal WhereClause As String, ByVal OrderByClause As String, ByVal Sequential As Boolean, ByVal Backward As Boolean, ByVal IsOptional As Boolean) As Boolean

            Dim blnReturnValue As Boolean
            Dim intRecordCount As Integer

            If m_blnBreakWhileRetrieving Then
                m_blnBreakWhileRetrieving = False
                Return False
            End If

            m_blnInWhileRetrieving = True

            If Backward AndAlso OrderByClause.Length > 0 AndAlso OrderByClause.ToUpper.IndexOf(" DESC") > 0 Then
                Backward = False
            End If

            If m_blnCallGetDataInWhileRetrieving Then
                'blnReturnValue = Me.GetData(WhereClause, OrderByClause, String.Empty, True, Sequential)
                Dim intIsSequential As GetDataOptions = GetDataOptions.None
                If Sequential Then
                    intIsSequential = GetDataOptions.Sequential
                End If
                m_blnIsWhileRetrieving = True
                blnReturnValue = Me.GetData(WhereClause, OrderByClause, GetDataOptions.IsOptional Or intIsSequential)
                If Not blnReturnValue AndAlso IsOptional AndAlso Not m_blnFirstWhileRetrievingExecuted Then
                    m_blnFirstWhileRetrievingExecuted = True
                    blnReturnValue = True
                End If
                If blnReturnValue Then

                    intRecordCount = dt.Rows.Count

                    'm_blnCallGetDataInWhileRetrieving is a Flag to convey WhileRetrieving that needs to GetData
                    'Note: This flag needs to be set to True before entering into the 
                    'Loop, if the calling code has Break statement within the While Retrieving loop
                    'It is a best practice to always set m_blnCallGetDataInWhileRetrieving to True before calling WhileRetrieving
                    m_blnCallGetDataInWhileRetrieving = False
                End If
            Else
                intRecordCount = dt.Rows.Count

                ' Set this back to false, so that next time we retrieve data, we have the correct value.
                m_blnFirstWhileRetrievingExecuted = False

                If Backward Then
                    'In case of WhileRetrieving with Backward Option, move to the previour row
                    m_intRetrievingRow -= 1

                    If m_intRetrievingRow < 0 Then
                        'If we already processed the first record then exit the WhileRetrieving
                        blnReturnValue = False
                    Else
                        ' Move the record into the current Occurrence position from the 
                        ' temporary datatable.
                        AssignRecordToBuffer(dt, m_intRetrievingRow)
                        blnReturnValue = True
                    End If
                Else
                    m_intRetrievingRow += 1
                    If m_intRetrievingRow < intRecordCount Then
                        ' Move the record into the current Occurrence position from the 
                        ' temporary datatable.
                        AssignRecordToBuffer(dt, m_intRetrievingRow)
                        blnReturnValue = True
                    Else
                        blnReturnValue = False
                    End If
                End If
                m_blnCallGetDataInWhileRetrieving = Not blnReturnValue
            End If
            Me.SetAccessOkOnPage(blnReturnValue)
            If Not blnReturnValue Then
                Break()
            End If
            m_blnInWhileRetrieving = blnReturnValue

            If Not blnReturnValue Then
                ' if the while reaches the end of the record buffer reset it
                IsInitialized = True

                ' Set INITIAL values from the dictionary.
                If IsNothing(System.Configuration.ConfigurationManager.AppSettings("NoDictionary")) Then
                    InitializeFromDictionary()
                End If

                ' Set the Item INITIAL values.
                RaiseInitializeItems(False)

                ReInitialize()
            End If
            Return blnReturnValue
        End Function

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function WhileRetrieving(ByVal blnHasExecuted As Boolean) As Boolean
            Return WhileRetrieving(blnHasExecuted, "", "", False, False, False)
        End Function
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function WhileRetrieving(ByVal blnHasExecuted As Boolean, ByVal WhereClause As String) As Boolean
            Return WhileRetrieving(blnHasExecuted, WhereClause, "", False, False, False)
        End Function
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function WhileRetrieving(ByVal blnHasExecuted As Boolean, ByVal WhereClause As String, ByVal OrderByClause As String) As Boolean
            Return WhileRetrieving(blnHasExecuted, WhereClause, OrderByClause, False, False, False)
        End Function
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function WhileRetrieving(ByVal blnHasExecuted As Boolean, ByVal WhereClause As String, ByVal OrderByClause As String, ByVal Sequential As Boolean) As Boolean
            Return WhileRetrieving(blnHasExecuted, WhereClause, OrderByClause, Sequential, False, False)
        End Function
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function WhileRetrieving(ByVal blnHasExecuted As Boolean, ByVal WhereClause As String, ByVal OrderByClause As String, ByVal Sequential As Boolean, ByVal Backward As Boolean) As Boolean
            Return WhileRetrieving(blnHasExecuted, WhereClause, OrderByClause, Sequential, Backward, False)
        End Function
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function WhileRetrieving(ByVal blnHasExecuted As Boolean, ByVal WhereClause As String, ByVal OrderByClause As String, ByVal Sequential As Boolean, ByVal Backward As Boolean, ByVal IsOptional As Boolean) As Boolean

            Dim blnReturnValue As Boolean
            Dim intRecordCount As Integer

            m_blnInWhileRetrieving = True

            If Backward AndAlso OrderByClause.Length > 0 AndAlso OrderByClause.ToUpper.IndexOf(" DESC") > 0 Then
                Backward = False
            End If

            If m_blnCallGetDataInWhileRetrieving Then
                'blnReturnValue = Me.GetData(WhereClause, OrderByClause, String.Empty, True, Sequential)
                Dim intIsSequential As GetDataOptions = GetDataOptions.None
                If Sequential Then
                    intIsSequential = GetDataOptions.Sequential
                End If
                m_blnIsWhileRetrieving = True
                blnReturnValue = True
                If Not blnReturnValue AndAlso IsOptional AndAlso Not m_blnFirstWhileRetrievingExecuted Then
                    m_blnFirstWhileRetrievingExecuted = True
                    blnReturnValue = True
                End If
                If blnReturnValue Then

                    intRecordCount = dt.Rows.Count

                    'm_blnCallGetDataInWhileRetrieving is a Flag to convey WhileRetrieving that needs to GetData
                    'Note: This flag needs to be set to True before entering into the 
                    'Loop, if the calling code has Break statement within the While Retrieving loop
                    'It is a best practice to always set m_blnCallGetDataInWhileRetrieving to True before calling WhileRetrieving
                    m_blnCallGetDataInWhileRetrieving = False
                End If
            Else
                intRecordCount = dt.Rows.Count

                ' Set this back to false, so that next time we retrieve data, we have the correct value.
                m_blnFirstWhileRetrievingExecuted = False

                If Backward Then
                    'In case of WhileRetrieving with Backward Option, move to the previour row
                    m_intRetrievingRow -= 1

                    If m_intRetrievingRow < 0 Then
                        'If we already processed the first record then exit the WhileRetrieving
                        blnReturnValue = False
                    Else
                        ' Move the record into the current Occurrence position from the 
                        ' temporary datatable.
                        AssignRecordToBuffer(dt, m_intRetrievingRow)
                        blnReturnValue = True
                    End If
                Else
                    m_intRetrievingRow += 1
                    If m_intRetrievingRow < intRecordCount Then
                        ' Move the record into the current Occurrence position from the 
                        ' temporary datatable.
                        AssignRecordToBuffer(dt, m_intRetrievingRow)
                        blnReturnValue = True
                    Else
                        blnReturnValue = False
                    End If
                End If
                m_blnCallGetDataInWhileRetrieving = Not blnReturnValue
            End If
            Me.SetAccessOkOnPage(blnReturnValue)
            If Not blnReturnValue Then
                Break()
            End If
            m_blnInWhileRetrieving = blnReturnValue

            If Not blnReturnValue Then
                ' if the while reaches the end of the record buffer reset it
                IsInitialized = True

                ' Set INITIAL values from the dictionary.
                If IsNothing(System.Configuration.ConfigurationManager.AppSettings("NoDictionary")) Then
                    InitializeFromDictionary()
                End If

                ' Set the Item INITIAL values.
                RaiseInitializeItems(False)

                ReInitialize()
            End If
            Return blnReturnValue
        End Function

        ''' --- Break --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Stops data record retrieval.
        ''' </summary>
        ''' <remarks>Used within a FOR loop to exit on a predetermined condition.
        ''' </remarks>
        ''' <example>
        ''' Do While fleEMPLOYEE.WhileRetrieving() <br/>
        '''     Select Case fleMPLOYEE.GetStringValue("GROUPSTATUS") <br/>
        '''         Case "BRO" <br/>
        '''             intGROUP_COUNT = intGROUP_COUNT + 1 <br/>
        '''         Case "CAD" <br/>
        '''             fleEMPLOYEE.Break() <br/>
        '''     End Select <br/>
        ''' Loop
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        '''     [Mark]      21/7/2005   Added an example
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Sub Break()
            'This function can be called whenever there is a Break inside the For loop

            'Note that WHILE RETRIEVING control structures can’t be explicitly
            'nested. In addition, a WHILE RETRIEVING control structure can’t be
            'nested within a FOR control structure. Similarly, a FOR control
            'structure can’t be nested within a WHILE RETRIEVING control
            'structure.
            'If Break encountered inside the WhileRetrieving loop, Exit without doing anything
            If m_blnIsWhileRetrieving Then
                m_blnIsWhileRetrieving = False
                m_blnBreakWhileRetrieving = True
                m_blnCallGetDataInWhileRetrieving = True
                m_intRetrievingRow = 0
                If Not dt Is Nothing Then
                    dt.Dispose()
                End If
                dt = Nothing
                Exit Sub
            End If

            'If "For" and "Break" method is used properly, m_strLastForID should always have
            'the value set during a Call to "For" or "ForMissing"
            Me.Break(Me.m_strLastForID)
        End Sub

        ''' --- Break --------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Stops data record retrieval.
        ''' </summary>
        ''' <param name="ForID"></param>
        ''' <remarks>Used within a FOR loop to exit on a predetermined condition. This function 
        ''' should not be called from outside the BaseFileObject.
        ''' <para>
        '''     <note>Break with ForID should not be called inside the WhileRetrieving.</note>
        ''' </para>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Private Sub Break(ByVal ForID As String)
            'This function should not be called from outside the BaseFileObject
            'Note: Break with ForID should not be called inside the WhileRetrieving
            If IsNothing(m_hstNestedForInfo) OrElse Not m_hstNestedForInfo.Contains(ForID) Then
                'To avoid Error exit
                Exit Sub
            End If

            Dim objForInfo As ForInfo

            'Get the ForInfo for the passed "ForID"
            objForInfo = CType(m_hstNestedForInfo(ForID), ForInfo)

            'Reset Main Occurrence on the Page to Previous Value and if applicable, bind Grid Fields
            With objForInfo
                'Reset the occurrence to the previous occurrence and call BindGridFields for that row
                Me.SetOccurrence(.PreviousOccurrence)
                Me.GoToRecord(.PreviousCurrentRecord)
            End With

            'Release the reference to ForInfo
            objForInfo = Nothing

            'Remove the ForInfo object from NestedForInfo hash table
            m_hstNestedForInfo.Remove(ForID)

            'Reduce the LastForIDNumber by one
            m_intLastForIDNumber -= 1
            m_blnSkipError = False

            'If there is no nested For left, 
            'remove the reference to m_sorNestedForIDs and m_strLastForID 
            'otherwise get the m_strLastForID from the m_sorNestedForIDs
            If m_intLastForIDNumber = -1 Then
                m_sorNestedForIDs = Nothing
                m_strLastForID = Nothing

                'Note: m_intLastForIDNumber and m_hstNestedForInfo should work hand-in-hand,
                'if m_intLastForIDNumber becomes negative, ideally m_hstNestedForInfo should not contain any item
                'however to release the reference we are clearing and than releasing the m_hstNestedForInfo
                m_hstNestedForInfo.Clear()
                m_hstNestedForInfo = Nothing
            Else
                m_strLastForID = CStr(m_sorNestedForIDs.Item(m_intLastForIDNumber))
            End If

            m_blnForMissing = False
            m_blnFor = False
        End Sub

        ''' --- For ----------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Will iterate through the records in a file object's data set.
        ''' </summary>
        ''' <param name="IsInFindOrDetailFind">A Boolean representing if control structure is in the Find or DetailFind procedure.</param>
        ''' <param name="ErrorInLastRecord">A Boolean indicating if an error was encountered while processing last record.</param>
        ''' <remarks>
        ''' <para>
        '''     <note>In the case of calls to nested ForMissing, call NestedForMissing with ID starting with "For".</note>
        ''' </para>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Function [For](ByVal IsInFindOrDetailFind As Boolean, ByRef ErrorInLastRecord As Boolean) As Boolean

            'Note: in case of calls to nested ForMissing, call NestedForMissing with ID starting with "For"

            'If ForMissing is not nested there is no need of an ID from the derived page
            'we are using an internal ID which will always be "InternalFor1"
            Return NestedFor("InternalFor1", IsInFindOrDetailFind, ErrorInLastRecord)
        End Function

        ''' --- For ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Will iterate through the records in a file object's data set.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        ''' Do While fleEMPLOYEE.For() <br/>
        '''     fleEMPLOYEEE.PutData() <br/>
        ''' Loop
        '''</example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function [For]() As Boolean
            'Note: in case of calls to nested For call NestedFor with ID starting with "For"
            Return NestedFor("InternalFor1", False, False)
        End Function

        ''' --- NestedFor ----------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Repeats a group of statements within another repeating control structure.
        ''' </summary>
        ''' <param name="ForID">A string value generated by the Renaissance Architect PreCompiler to uniquely identify this control structure.</param>
        ''' <remarks>
        ''' The NestedFor method is used to handle For controls structures being called within For control structures.  The RenaissanceArchitect PreCompiler 
        ''' will generate a unique ForID parameter.  This function ensures that the Occurrence is reset properly upon completion or breaking out of this control structure.
        ''' </remarks>
        ''' <example>
        ''' Do While fleEMPLOYEE.NestedFor("File2") <br/>
        '''     If Null(fleEMPLOYEE.GetDecimalValue("VACATION")) &gt; 25 Then <br/>
        '''         Internal_CHECK_EMPLOYEEVACATION() <br/>
        '''     End If <br/>
        ''' Loop <br/>
        ''' <br/>
        ''' <br/>
        ''' Private Function Internale_CHECK_EMPLOYEEVACATION() As Boolean
        '''
        '''     Try <br/>
        ''' <br/>
        '''         Dim intVacation as Integer
        '''         Do While fleEMPLOYEEVACATION.NestedFor("File1") <br/>
        '''             If fleEMPLOYEEVACATION.GetDateValue("ENDDATE") <= CurrDate Then <br/>
        '''                intVacation = intVacation + Internal Calc_Vacation() <br/>
        '''             End If <br/>
        '''         Loop <br/>
        ''' <br/>
        '''         Return True <br/>
        ''' <br/>
        '''     Catch ex As Exception <br/>
        ''' <br/>
        '''        ExceptionManager.Publish(ex) <br/>
        '''        Throw ex <br/>
        ''' <br/>
        '''     End Try <br/>
        ''' <br/>
        ''' End Function
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function NestedFor(ByVal ForID As String) As Boolean
            ' This function assumes that we have not implemented "Cache" option 
            ' of "File" Statement of PH.

            'Note: This overload of NestedFor should ONLY be used outside the Find and DetailFind procedures
            Return NestedFor(ForID, False, False)
        End Function

        ''' --- NestedFor ----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	A Helper function which helps an executing Do While Statement in a derived 
        ''' page to mimic the PowerHouse For [RecordStructure] functionality.
        ''' </summary>
        ''' <param name="ForID"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Function NestedFor(ByVal ForID As String, ByVal blnIsInFindOrDetailFind As Boolean, ByRef ErrorInLastRecord As Boolean) As Boolean
            'Note: in case of calls to nested For call NestedFor with ID starting with "For"

            'Notes:
            'The behaviour of For function has following differences from the Legacy App:
            '1.	It does not support any functionality related to Cache, as File object at present doesn’t support Cache
            '2.	In this implemetation For function does not support "Missing" and "Missing Displayed"
            '3.	In this implemetation "For Each" and "For Each Displayed" is same
            '4.	It will produce unexpected results if it has direct or indirect nested For/WhileRetrieve (discussed in WhileRetrieve).
            '5. Whenever there is "Break" inside the For loop it is necessary to 
            '   Reset m_blnSaveOccurence through ResetOccurrence
            '6. While entering into the loop for the first time, 
            '   Passed Referenced Occurrence (generally m_intOccurrence) should always be 0, 
            '   otherwise it will produce unexpected results

            Dim intCurrentOccurrence As Integer

            If m_hstNestedForInfo Is Nothing Then m_hstNestedForInfo = New Hashtable

            If Not m_blnExecutedPrimaryDetailFor AndAlso IsInFindOrDetailFind() AndAlso (Me.Type = FileTypes.Primary OrElse Me.Type = FileTypes.Detail) Then
                ' For Primary or Detail files, when in Find or DetailFind procedure,
                ' run through the loop at least once.  The number of records returned will determine
                ' the end of the loop.  The next time through, we should execute the ELSE portion of this
                ' condition.
                m_blnExecutedPrimaryDetailFor = True

                'Increment the m_intLastForIDNumber which denotes the ID number for inner most For
                m_intLastForIDNumber += 1

                'If m_hstNestedForInfo doesn't contain the passed ForID
                'Create a new instance of ForInfo using the current occurrence and CurrentRow
                'and add it to the m_hstNestedForInfo
                m_hstNestedForInfo.Add(ForID, New ForInfo(GetOccurrence, Me.CurrentRow))

                ' Let the GetData determine when to end the loop.
                m_blnFor = True
                m_blnGetDataFor = True

            Else

                'If m_hstNestedForInfo contains the passed ForID,
                'Move to the next Record using the Occurrence
                'Otherwise see Else part for comments
                If m_hstNestedForInfo.Contains(ForID) Then
                    ' Reached at either Last record in FileObject i.e. EOF or 
                    ' upto Occurs then Reset Occurrence and Record Position
                    ' Note: Occurs is one based and Me.CurrentRow is Zero based
                    intCurrentOccurrence = Me.MoveNextFor(ErrorInLastRecord, Me.GetOccurrence + 1)

                    If intCurrentOccurrence < 0 Then
                        'IsEmptyRecord(intCurrentOccurrence) Then

                        'we need to reset some variables inside the Break method
                        'so that subsequent FOR Statements (if any) can start 
                        'from First Value
                        Break(ForID) 'We are using Break to reset these variables

                        ' Set this back to false so that the next FOR is handled.
                        m_blnExecutedPrimaryDetailFor = False

                        blnInForLoop = False
                        'Return False so that we can exit from the Do While Loop in derived Page
                        Return False
                    Else
                        If Me.m_intRecordsToRetrieve > 0 Then
                            Me.TotalRecordsProcessed = Me.TotalRecordsProcessed + 1
                        End If
                        'Set Main Occurrence on the Page to next occurrence and if applicable, bind Grid Fields
                        SetOccurrence(intCurrentOccurrence)
                    End If
                Else
                    ' For a Designer or Secondary file, the number of processing repetitions
                    ' performed is equal to the number of occurrences declared on the FILE or CURSOR
                    ' statement, regardless of the number of data records retrieved or entered.
                    If Not (Me.Type = FileTypes.Secondary OrElse Me.Type = FileTypes.Designer OrElse Me.Type = FileTypes.Master) Then
                        'If there is no first record then exit the For loop
                        'Note: New and Unaltered record is considered as "Missing" however not a first record
                        If Not m_dtbDataTable Is Nothing AndAlso (intCurrentOccurrence <= Me.Occurs) AndAlso Me.RecordsForLoop > intCurrentOccurrence Then
                            'Process this record
                        ElseIf (m_dtbDataTable Is Nothing AndAlso Not Me.Type = FileTypes.Delete) OrElse
                            ((intCurrentOccurrence >= Me.Occurs AndAlso Not ((Me.Type = FileTypes.Primary OrElse Me.Type = FileTypes.Delete) AndAlso Me.Occurs = 0))) OrElse
                            (Not m_dtbDataTable Is Nothing AndAlso 0 > m_dtbDataTable.Rows.Count - 1) OrElse
                            IsEmptyRecord(0) Then

                            'Clear and Release a reference to m_hstNestedForInfo
                            m_hstNestedForInfo.Clear()
                            m_hstNestedForInfo = Nothing
                            blnInForLoop = False
                            Return False
                        End If
                    End If

                    'If m_hstNestedForInfo doesn't contain the passed ForID
                    'Create a new instance of ForInfo using the current occurrence and CurrentRow
                    'and add it to the m_hstNestedForInfo
                    m_hstNestedForInfo.Add(ForID, New ForInfo(GetOccurrence, Me.CurrentRow))

                    'Increment the m_intLastForIDNumber which denotes the ID number for inner most For
                    m_intLastForIDNumber += 1
                    If m_intLastForIDNumber = 0 Then
                        'If this is the first (outer most) For
                        'Create the m_sorNestedForIDs
                        m_sorNestedForIDs = New SortedList

                        'Update m_sorNestedForIDs with the ForID, which is used 
                        'to determine For in Break (w/o parameters) method
                        m_sorNestedForIDs.Add(m_intLastForIDNumber, ForID)
                    End If

                    'Start from the first record
                    Me.MoveFirst()

                    'Reset Main Occurrence on the Page to 0 and if applicable, bind Grid Fields
                    SetOccurrence(0)
                End If

            End If

            m_strLastForID = ForID

            blnInForLoop = True
            'Return True to continue looping through all records in a file in derived Page
            Return True

        End Function

        ''' --- MoveNextFor --------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of MoveNextFor.
        ''' </summary>
        ''' <param name="ErrorInLastRecord"></param>
        ''' <param name="NextPosition"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Private Function MoveNextFor(ByRef ErrorInLastRecord As Boolean, ByVal NextPosition As Integer) As Integer
            'Note: This internal method expects "NextPosition" to be Zero based

            If Not Me.SkipRecordsWithError Then
                'If there is no need to skip records with an error
                If Not m_dtbDataTable Is Nothing AndAlso (NextPosition <= Me.Occurs) AndAlso Me.RecordsForLoop > NextPosition AndAlso (NextPosition > m_dtbDataTable.Rows.Count) Then
                    'Process this record
                    Return NextPosition
                ElseIf m_dtbDataTable Is Nothing OrElse
                    (NextPosition) >= Me.Occurs OrElse
                    (NextPosition >= m_dtbDataTable.Rows.Count) OrElse
                    IsEmptyRecord(NextPosition) Then
                    If Not IsNothing(m_dtbDataTable) AndAlso
                    (NextPosition) < Me.Occurs AndAlso
                    (NextPosition < m_dtbDataTable.Rows.Count) AndAlso
                    IsEmptyRecord(NextPosition) Then
                        NextPosition += 1
                        Return MoveNextFor(ErrorInLastRecord, NextPosition)
                    End If
                    Return -1
                Else
                    Return NextPosition
                End If
            Else
                If m_dtbDataTable Is Nothing OrElse
                (NextPosition) >= Me.Occurs Then
                    Return -1
                Else
                    'If records with an error needs to be skipped
                    'also check following conditions
                End If
            End If

            Dim intCurrentOccurrence As Integer
            Dim intTotalRecordsFound As Integer
            Dim intTotalRecordsProcessed As Integer

            intTotalRecordsProcessed = Me.TotalRecordsProcessed
            If intTotalRecordsProcessed < 0 Then
                intTotalRecordsProcessed = 0
            End If

            intTotalRecordsFound = Me.TotalRecordsFound
            If intTotalRecordsFound < 0 Then
                intTotalRecordsFound = 0
            End If

            If ErrorInLastRecord Then
                Dim blnExit As Boolean = False

                'ErrorInLastRecord has specifically been added to handle Errors in Find/DetailFind
                intCurrentOccurrence = Me.CurrentRow
                'Remove the current record on which an error has occurred
                With m_dtbDataTable
                    .Rows.RemoveAt(intCurrentOccurrence)
                    .AcceptChanges()
                    If (.Rows.Count = intCurrentOccurrence) Then
                        If intTotalRecordsProcessed < intTotalRecordsFound Then
                            'Add New blank record
                            AddBlankRecord(intCurrentOccurrence)
                        Else
                            blnExit = True
                        End If
                    End If
                End With

                'Reset ErrorInLastRecord to False, so that we can track new errors
                ErrorInLastRecord = False
                If blnExit Then '(intCurrentOccurrence = m_dtbDataTable.Rows.Count - 1) AndAlso (blnCanExit AndAlso intTotalRecordsFound = (m_dtbDataTable.Rows.Count - 1 + intTotalSkippedRecords + m_intRecordsToFillInFindOrDetailFind)) Then
                    NextPosition = -1
                Else
                    NextPosition = intCurrentOccurrence
                End If
            Else
                With m_dtbDataTable
                    If (.Rows.Count = NextPosition) Then
                        If intTotalRecordsProcessed < intTotalRecordsFound Then
                            'Add New blank record
                            AddBlankRecord(NextPosition)
                        Else
                            NextPosition = -1
                        End If
                    End If
                End With
            End If

            Return NextPosition
        End Function

        ''' --- IsEmptyRecord ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of IsEmptyRecord.
        ''' </summary>
        ''' <param name="RecordPosition"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Private Function IsEmptyRecord(ByVal RecordPosition As Integer) As Boolean
            'EmptyRecord function is used to exit the FOR loop

            'Record is considered as an Empty in following cases:
            '1. If File is of Detail Type and the record is NewRecord and Un-altered
            '2. If File is other than of Detail Type, and the record is "Un-altered" and Column Row_ID is Empty
            Return (Me.Type = FileTypes.Detail AndAlso m_blnNewRecord(RecordPosition) AndAlso (Not m_blnAlteredRecord(RecordPosition))) OrElse
                (Me.Type <> FileTypes.Detail AndAlso (Not m_blnAlteredRecord(RecordPosition)) AndAlso (Not Me.IsOldRecord(RecordPosition)))
        End Function

        ''' --- ForMissing ---------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Allows users to perform Append processing when changing data records.
        ''' </summary>
        ''' <remarks>ForMissing repeats as many times as there are empty record 
        ''' occurrences on the screen.
        ''' </remarks>
        ''' <example>
        ''' Do While fleEMPLOYEE.ForMissing() <br/>
        '''     fleEMPLOYEE.GetData(GetDataOptions.CreateSubSelect Or GetDataOptions.IsOptional) <br/>
        ''' Loop <br/>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function ForMissing() As Boolean
            Return ForMissing(False, False)
        End Function

        Public Overridable Function QTPForMissing() As Boolean
            Return ForMissing(False, False)
        End Function

        Public Overridable Function QTPForMissing(ByVal strForId As String) As Boolean
            Return ForMissing(False, False)
        End Function

        Public Overridable Function QTPLoop() As Boolean

        End Function

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overridable Sub QTPRecordsRead(ByVal strFile As String, ByVal strFileAlias As String, ByVal intRecords As Integer, ByVal LogType As LogType)

        End Sub
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Function At(ByVal strColumn As String) As Boolean
            Dim arrColumn() As String

            If IsQuiz AndAlso Not strColumn.ToLower.StartsWith(Me.ReturnRelation.ToLower & "_") Then
                strColumn = Me.ReturnRelation & "_" & strColumn
            End If



            If Not IsNothing(m_dtbDataTable) AndAlso Me.m_dtbDataTable.Rows.Count > 0 Then

                If strColumn.IndexOf(",") >= 0 Then
                    arrColumn = strColumn.Split(",")
                    For i As Integer = 0 To arrColumn.Length - 1

                        If m_intSortNextOccurence = -1 Then

                            Return True
                        Else
                            If Me.m_dtbDataTable.Rows(Me.CurrentRow).Item(arrColumn(i).Trim) <> Me.m_dtbDataTable.Rows(m_intSortNextOccurence).Item(arrColumn(i).Trim) Then
                                Return True
                            End If
                        End If
                    Next

                Else
                    If m_intSortNextOccurence = -1 Then
                        Return True
                    ElseIf Not IsNull(Me.m_dtbDataTable.Rows(Me.CurrentRow).Item(strColumn)) OrElse Not IsNull(Me.m_dtbDataTable.Rows(m_intSortNextOccurence).Item(strColumn)) Then
                        If IsNull(Me.m_dtbDataTable.Rows(Me.CurrentRow).Item(strColumn)) AndAlso Not IsNull(Me.m_dtbDataTable.Rows(m_intSortNextOccurence).Item(strColumn)) Then
                            Return True
                        ElseIf Not IsNull(Me.m_dtbDataTable.Rows(Me.CurrentRow).Item(strColumn)) AndAlso IsNull(Me.m_dtbDataTable.Rows(m_intSortNextOccurence).Item(strColumn)) Then
                            Return True
                        ElseIf Me.m_dtbDataTable.Columns(strColumn).DataType.ToString = "System.String" Then
                            If Me.m_dtbDataTable.Rows(Me.CurrentRow).Item(strColumn).ToString.Trim <> Me.m_dtbDataTable.Rows(m_intSortNextOccurence).Item(strColumn).ToString.Trim Then
                                Return True
                            End If
                        ElseIf Me.m_dtbDataTable.Rows(Me.CurrentRow).Item(strColumn) <> Me.m_dtbDataTable.Rows(m_intSortNextOccurence).Item(strColumn) Then
                            Return True
                        End If
                    End If


                End If

            End If


            Return False
        End Function

        ''' --- ForMissing ---------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Allows users to perform Append processing when changing data records.
        ''' </summary>
        ''' <param name="IsInFindOrDetailFind">A Boolean representing if control structure is in the Find or DetailFind procedure.</param>
        ''' <remarks>ForMissing repeats as many times as there are empty record 
        ''' occurrences on the screen.
        ''' </remarks>
        ''' <example>
        ''' Do While fleEMPLOYEE.ForMissing(True) <br/>
        '''     fleEMPLOYEE.GetData(GetDataOptions.CreateSubSelect) <br/>
        ''' Loop <br/>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function ForMissing(ByVal IsInFindOrDetailFind As Boolean) As Boolean
            Return ForMissing(IsInFindOrDetailFind, False)
        End Function

        ''' --- ForMissing ---------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Allows users to perform Append processing when changing data records.
        ''' </summary>
        ''' <param name="IsInFindOrDetailFind">A Boolean representing if control structure is in the Find or DetailFind procedure.</param>
        ''' <param name="ErrorInLastRecord">A Boolean indicating if an error was encountered while processing last record.</param>
        ''' <remarks>ForMissing repeats as many times as there are empty record 
        ''' occurrences on the screen. 
        ''' <para>
        '''     <note>If ForMissing is not nested there is no need of an ID from the derived page.</note>
        ''' </para>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Function ForMissing(ByVal IsInFindOrDetailFind As Boolean, ByRef ErrorInLastRecord As Boolean) As Boolean

            'Note: in case of calls to nested ForMissing, call NestedForMissing with ID starting with "For"

            'If ForMissing is not nested there is no need of an ID from the derived page
            'we are using an internal ID which will always be "InternalFor1"
            Return NestedForMissing("InternalFor1", IsInFindOrDetailFind, ErrorInLastRecord)
        End Function

        ''' --- NestedForMissing ---------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Allows users to perform Append processing when changing data records.
        ''' </summary>
        ''' <param name="ForID"></param>
        ''' <param name="IsInFindOrDetailFind">A Boolean representing if control structure is in the Find or DetailFind procedure.</param>
        ''' <param name="ErrorInLastRecord">A Boolean indicating if an error was encountered while processing last record.</param>
        ''' <remarks>NestedForMissing should not be called on File which doesn't Occur.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Function NestedForMissing(ByVal ForID As String, ByVal IsInFindOrDetailFind As Boolean, ByRef ErrorInLastRecord As Boolean) As Boolean
            'Note: in case of calls to nested ForMissing, call NestedForMissing with ID starting with "For"

            If m_intOccurs < 1 Then
                'ForMissing should not be called on File which doesn't Occur
                Return False
            End If

            ' Open an empty record structure if the file has not been opened
            If m_dtbDataTable Is Nothing OrElse ((IsNothing(m_hstNestedForInfo) OrElse Not m_hstNestedForInfo.Contains(ForID)) AndAlso ApplicationState.Current.Createempty) Then
                CreateEmptyStructure(True)
            End If

            Dim intCurrentOccurrence As Integer

            If m_hstNestedForInfo Is Nothing Then m_hstNestedForInfo = New Hashtable

            'If m_hstNestedForInfo contains the passed ForID,
            'Move to the next Record using the Occurrence
            'Otherwise see Else part for comments
            If m_hstNestedForInfo.Contains(ForID) Then

                'For "Detail" file exit the ForMissing if the current record is new and unaltered
                If Me.Type = FileTypes.Detail AndAlso Me.NewRecord AndAlso Not Me.AlteredRecord Then
                    'we need to reset some variables inside the Break method
                    'so that subsequent FOR Statements (if any) can start 
                    'from First Value
                    Break(ForID) 'We are using Break to reset these variables

                    'Return False so that we can exit from the Do While Loop in derived Page
                    Return False
                End If

                intCurrentOccurrence = Me.MoveNextMissing(ErrorInLastRecord)

                ' Reached at either Last record in FileObject i.e. EOF or 
                ' upto Occurs then Reset Occurrence and Record Position
                ' Note: Occurs is one based and Me.CurrentRow is Zero based
                If m_dtbDataTable Is Nothing OrElse (intCurrentOccurrence < 0) OrElse (intCurrentOccurrence >= Me.Occurs) OrElse (intCurrentOccurrence >= m_dtbDataTable.Rows.Count) Then
                    'we need to reset some variables inside the Break method
                    'so that subsequent FOR Statements (if any) can start 
                    'from First Value
                    Break(ForID) 'We are using Break to reset these variables

                    'Return False so that we can exit from the Do While Loop in derived Page
                    Return False
                Else
                    If Me.m_intRecordsToRetrieve > 0 Then
                        Me.TotalRecordsProcessed = Me.TotalRecordsProcessed + 1
                    End If
                End If
            Else
                m_blnForMissing = True
                m_blnGetDataForMissing = True

                intCurrentOccurrence = 0
                'If m_hstNestedForInfo doesn't contain the passed ForID
                'Create a new instance of ForInfo using the current occurrence and CurrentRow
                'and add it to the m_hstNestedForInfo
                m_hstNestedForInfo.Add(ForID, New ForInfo(GetOccurrence, Me.CurrentRow))

                'Increment the m_intLastForIDNumber which denotes the ID number for inner most For
                m_intLastForIDNumber += 1
                If m_intLastForIDNumber = 0 Then
                    'If this is the first (outer most) For
                    'Create the m_sorNestedForIDs
                    m_sorNestedForIDs = New SortedList

                    'Update m_sorNestedForIDs with the ForID, which is used 
                    'to determine For in Break (w/o parameters) method
                    m_sorNestedForIDs.Add(m_intLastForIDNumber, ForID)
                End If

                'Start from the first "Missing" record
                intCurrentOccurrence = Me.MoveFirstMissing()
                If intCurrentOccurrence < 0 Then
                    Break(ForID)
                    Return False
                Else
                    If Me.m_intRecordsToRetrieve > 0 Then
                        Me.TotalRecordsProcessed = Me.TotalRecordsProcessed + 1
                    End If
                End If
            End If
            m_strLastForID = ForID

            'Return True to continue looping through all records in a file in derived Page
            Return True
        End Function

        ''' --- CheckLookupOnSameFile ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of CheckLookupOnSameFile.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overridable Sub CheckLookupOnSameFile()
            ' To be overridden.
        End Sub

        ''' --- SetLookupNotOnFileName ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of SetLookupNotOnFileName.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overridable Sub SetLookupNotOnFileName(ByVal Name As String)
            ' To be overridden.
        End Sub

        ''' --- SetOccurrence ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of SetOccurrence.
        ''' </summary>
        ''' <param name="NewValue"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overridable Sub SetOccurrence(ByVal NewValue As Integer, Optional ByVal ByPassBinding As Boolean = False)
            'Must be implemented to reset m_intOccurrence in Derived Class that can
            'access the zero based m_intOccurrence property on a base page/form
        End Sub

        ''' --- GetOccurrence ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetOccurrence.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overridable Function GetOccurrence() As Integer
            'Must be implemented to Get m_intOccurrence in Derived Class that can
            'access the zero based m_intOccurrence property on a base page/form
        End Function
        ''' --- IsAt ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of IsAt.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Protected Overridable ReadOnly Property IsAt() As Boolean
            Get
                Return False
            End Get
        End Property

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overridable ReadOnly Property DeleteSubFile() As Boolean
            Get
                Return False
            End Get
        End Property
        ''' --- TotalRecordsFound --------------------------------------------------
        ''' <exclude/>
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overridable Property TotalRecordsFound() As Integer Implements IFileObject.TotalRecordsFound
            'Note: Only to be used in While skipping records with an error in Find/DetailFind

            'TotalRecordsFound, TotalSkippedRecords and TotalRecordsProcessed
            'are at screen level. i.e. per screen only one file should use these properties
            Get
                'Must be implemented to Get TotalRecordsFound in Derived Class
            End Get
            Set(ByVal Value As Integer)
                'Must be implemented to Get TotalRecordsFound in Derived Class
            End Set
        End Property

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overridable ReadOnly Property SortPhase() As Boolean
            Get
                Return Nothing
            End Get
        End Property

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overridable ReadOnly Property SortPhaseSet() As Boolean
            Get
                Return Nothing
            End Get
        End Property

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overridable Property WhereElementColumn() As String
            Get
                Return ""
            End Get
            Set(ByVal Value As String)

            End Set
        End Property



        ''' --- TotalSkippedRecords ------------------------------------------------
        ''' <exclude/>
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overridable Property TotalSkippedRecords() As Integer Implements IFileObject.TotalSkippedRecords

            Get
                'Must be implemented to Get TotalRecordsFound in Derived Class
            End Get
            Set(ByVal Value As Integer)
                'Must be implemented to Get TotalRecordsFound in Derived Class
            End Set
        End Property

        ''' --- TotalRecordsProcessed ----------------------------------------------
        ''' <exclude/>
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overridable Property TotalRecordsProcessed() As Integer Implements IFileObject.TotalRecordsProcessed
            'Note: Only to be used in While skipping records with an error in Find/DetailFind

            'TotalRecordsFound, TotalSkippedRecords and TotalRecordsProcessed
            'are at screen level. i.e. per screen only one file should use these properties
            Get
                'Must be implemented to Get TotalRecordsFound in Derived Class
            End Get
            Set(ByVal Value As Integer)
                'Must be implemented to Get TotalRecordsFound in Derived Class
            End Set
        End Property

        ''' ---PutData--------------------------------------------------------------------------
        ''' <exclude/>
        ''' <summary>
        ''' 	Updates the data record.
        ''' </summary>
        ''' <param name="Reset"></param>
        ''' <param name="PutType"></param>
        ''' <param name="At"></param>
        ''' <remarks>
        ''' <para>This function is overridable so that the developer has the option
        ''' of coding their own procedure to suite the needs of the specific screen
        ''' they are working on. By doing so, the screens functionality is tied to the 
        ''' Renaissance Architect Framework.</para>
        ''' </remarks>
        ''' <example>PutData(True, PutTypes.None)</example>
        ''' <history>
        ''' 	[Campbell]	4/14/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overridable Sub PutData() Implements IFileObject.PutData
            'Should be overridden in the derived class
        End Sub

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overridable Sub PutData(ByVal Reset As Boolean) Implements IFileObject.PutData
            'Should be overridden in the derived class
        End Sub

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overridable Sub PutData(ByVal Reset As Boolean, ByVal PutType As PutTypes) Implements IFileObject.PutData
            'Should be overridden in the derived class
        End Sub

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overridable Sub PutData(ByVal Reset As Boolean, ByVal PutType As PutTypes, ByVal At As Integer) Implements IFileObject.PutData
            'Should be overridden in the derived class
        End Sub

        ''' --- IsValidColumn ------------------------------------------------------
        ''' <exclude/>
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
            If ColumnName <> "ROW_NUM" AndAlso ColumnName <> "ROW_ID" AndAlso ColumnName <> "AUDIT_WHO" AndAlso ColumnName <> "AUDIT_WHERE" _
            AndAlso ColumnName <> "AUDIT_WHEN" AndAlso ColumnName <> "AUDIT_UPDATE_TYPE" AndAlso ColumnName <> "AUDIT_CREATION_DATE" _
            AndAlso ColumnName <> "AUDIT_NETWORK_UPDATE" Then
                Return True
            Else
                Return False
            End If
        End Function

        ''' --- ContinuePut --------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of ContinuePut.
        ''' </summary>
        ''' <param name="PutType"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Function ContinuePut(ByVal PutType As PutTypes) As Boolean

            ' Execute the code depending on PutType.  
            ' TYPES: None [Default]
            '        New - Only update records with NewRecord flag set to true.
            '        Deleted - Only update records with DeletedRecord flag set to true.
            '        NotDeleted - Only update records that are not marked for deletion.
            If (PutType = PutTypes.None) Or (PutType = PutTypes.Deleted And m_blnDeletedRecord(Me.CurrentRow)) _
                    Or (PutType = PutTypes.[New] And m_blnNewRecord(Me.CurrentRow) Or (PutType = PutTypes.NotDeleted And (IsNothing(m_blnDeletedRecord) OrElse Not m_blnDeletedRecord(Me.CurrentRow)))) Then
                Return True
            Else
                Return False
            End If

        End Function

        ''' --- ReturnRelation -----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Returns the base relation name or alias name depending on whether the 
        ''' file is aliased or not.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <example>strRelation = ReturnRelation()</example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Function ReturnRelation() As String

            Dim strRelation As String

            Try
                ' Set the name to use when accessing this file.
                If m_strAliasName <> "" Then
                    strRelation = m_strAliasName
                Else
                    strRelation = m_strBaseName
                End If

                Return strRelation

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Function

        ''' --- TableNameWithOwner -------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Retrieves the full database table name of the File Object.
        ''' </summary>
        ''' <returns>A String containing the owner and name of the current File Object.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        ''' strTable = fleEMPLOYEE.TableNameWithOwner()
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Protected Overridable Overloads Function TableNameWithOwner() As String
            Return TableNameWithOwner(False)
        End Function

        ''' --- TableNameWithOwner -------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Retrieves the full database table name of the File Object.
        ''' </summary>
        ''' <param name="ReturnAlias">A Boolean indicating whether to retrieve the Alias name of table.</param>
        ''' <returns>A String containing the concactenation of Database Table Owner, Table Name and, if 
        ''' <i>ReturnAlias</i> equals True, Table Alias Name.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        ''' strTable = fleEMPLOYEE.TableNameWithOwner(True)
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Protected Overridable Overloads Function TableNameWithOwner(ByVal ReturnAlias As Boolean) As String
            Dim strReturnValue As String = String.Empty
            Dim strSeparator As String = "."

            If IsQTP AndAlso (m_IsTextFile OrElse m_IsSubFile) Then
                If SubFileSchema.Length > 0 Then
                    strReturnValue = SubFileSchema() + "." + Me.BaseName
                Else
                    strReturnValue = Me.BaseName
                End If

                If ReturnAlias Then
                    strReturnValue += " " + Me.AliasName
                End If
            Else
                If Not IsNothing(Owner) AndAlso Me.Owner.Trim.Length > 0 Then
                    strReturnValue = Me.Owner + "." + Me.BaseName
                Else
                    strReturnValue = Me.BaseName
                End If

                If ReturnAlias Then
                    strReturnValue += " " + Me.AliasName
                End If
            End If

            Return strReturnValue
        End Function

        ''' --- TableNameWithAlias -------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Retrieves the full database table name of the File Object along with the Alias Name.
        ''' </summary>
        ''' <returns>A String containing the concactenation of Database Table Owner, Table Name and Table Alias Name.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        ''' strTable = fleEMPLOYEE.TableNameWithAlias()
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overridable Function TableNameWithAlias() As String
            SetLookupNotOnFileName(Me.TableNameWithOwner(True))
            Return Me.TableNameWithOwner(True)
        End Function

        Protected Overridable Sub ClearColumnJoinInfo()
            ' Must be overriden in derived class.
        End Sub

        ''' --- ElementOwner -------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Determines the name of the Database Element's owner.
        ''' </summary>
        ''' <returns>A String containing the either of the Database Table Owner and Table Name or the Table Alias Name.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        ''' strElement = fleEMPLOYEE.ElementOwner()
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overridable Function ElementOwner() As String
            If m_strElementOwner Is Nothing OrElse m_strElementOwner.Trim.Length = 0 Then
                If IsQTP AndAlso m_IsKeepSubFile = BooleanTypes.True Then
                    If SubFileSchema.Length > 0 Then
                        m_strElementOwner = SubFileSchema() + "." + Me.BaseName + "."
                    Else
                        m_strElementOwner = Me.BaseName + "."
                    End If
                Else

                    If m_strAliasName <> "" Then
                        m_strElementOwner = Me.m_strAliasName + "."
                    Else
                        m_strElementOwner = m_strOwner + "." + Me.BaseName + "."
                    End If
                End If
            End If
            If IsQTP Then
                ClearColumnJoinInfo()
            End If
            Return m_strElementOwner
        End Function

        ''' --- ElementOwner -------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Determines the name of the Database Element's owner.
        ''' </summary>
        ''' <param name="Field">A string value indicating the field name.</param>
        ''' <returns>A String containing the either of the Database Table Owner and Table Name or the Table Alias Name.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        ''' strElement = fleEMPLOYEE.ElementOwner("EMPLOYEE_ID")
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overridable Function ElementOwner(ByVal Field As String) As String
            If m_strElementOwner Is Nothing OrElse m_strElementOwner.Trim.Length = 0 Then
                If IsQTP AndAlso m_IsKeepSubFile = BooleanTypes.True Then
                    If SubFileSchema.Length > 0 Then
                        m_strElementOwner = SubFileSchema() + "." + Me.BaseName + "."
                    Else
                        m_strElementOwner = Me.BaseName + "."
                    End If
                Else

                    If m_strAliasName <> "" Then
                        m_strElementOwner = Me.m_strAliasName + "."
                    Else
                        m_strElementOwner = m_strOwner + "." + Me.BaseName + "."
                    End If
                End If
            End If
            If IsQTP AndAlso Not IsNothing(SelectifColumn) Then
                WhereElementColumn = Field
                If Not SelectifColumn.Contains(Field) Then AddSelectifColumn = Field
            End If
            If IsQTP Then
                ClearColumnJoinInfo()
            End If
            Return m_strElementOwner + Field
        End Function

        ''' --- ElementOwner -------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Determines the name of the Database Element's owner.
        ''' </summary>
        ''' <param name="Field">A string value indicating the field name.</param>
        ''' <param name="StartPosition">Start position for a substring</param>
        ''' <param name="Length">Length of a substringed value</param>
        ''' <returns>A String containing the either of the Database Table Owner and Table Name or the Table Alias Name.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        ''' strElement = fleEMPLOYEE.ElementOwner("EMPLOYEE_ID")
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overridable Function ElementOwner(ByVal Field As String, ByVal StartPosition As Integer, ByVal Length As Integer) As String
            Select Case Me.GetType.ToString
                Case "Core.Windows.UI.Core.Windows.OracleFileObject"
                    Return "Substr(" & ElementOwner(Field) & ", " & (StartPosition + 1).ToString & ", " & Length.ToString & ")"
                Case "Core.Windows.UI.Core.Windows.SqlFileObject"
                    Return "Substring(" & ElementOwner(Field) & ", " & (StartPosition + 1).ToString & ", " & Length.ToString & ")"
                Case "Core.Windows.UI.Core.Windows.IfxFileObject"
                    Return "Substr(" & ElementOwner(Field) & ", " & (StartPosition + 1).ToString & ", " & Length.ToString & ")"
            End Select
            Return "" ' Should not get here...
        End Function

        ''' --- ReturnSelectFromSQL ------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Returns the SELECT ... FROM portion of the SQL select statement.
        ''' </summary>
        ''' <param name="RemoveRowId">A Boolean indicating whether or not to include the ROWID in Select statement.</param>
        ''' <returns>A String representing the SQL SELECT ... FROM of the an SQL Statement.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>strSQL = ReturnSelectFromSQL</example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Function ReturnSelectFromSQL(Optional ByVal RemoveRowId As Boolean = False) As String

            Dim strSQL As StringBuilder = New StringBuilder("")

            Try
                ' Create the Select ... FROM SQL statement.
                With strSQL
                    .Append("SELECT ")
                    If RemoveRowId Then
                        .Append(ColumnsUsed).Append(" ")
                    Else
                        If Me.ColumnsUsed.Equals("*") Then
                            .Append(Me.ElementOwner).Append("*, ").Append(Me.ElementOwner)
                            .Append(RecordIdentifier).Append(" ROW_ID ")
                        Else
                            .Append(Me.ColumnsUsed)
                        End If
                    End If
                    strSQL.Append(" FROM ")
                    strSQL.Append(Me.TableNameWithAlias)

                    strSQL.Append("  WITH (NOLOCK) ")
                End With

                Return strSQL.ToString.Replace("Temporary Data.", "")

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Function

        ''' --- RecordIdentifier ------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Returns the value ROWID or the value for RecordIdentifier from the
        '''     Web.config file.
        ''' </summary>
        ''' <returns>A String representing the record identifier of the an SQL Statement.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>strSQL = "Update EMPLOYEE Set EMPLOYEE_ID = 10 WHERE " + RecordIdentifier + " = 10"</example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Function RecordIdentifier() As String

            If System.Configuration.ConfigurationManager.AppSettings("RecordIdentifier") Is Nothing Then
                Return "ROWID"
            Else
                If System.Configuration.ConfigurationManager.AppSettings("RecordIdentifier").ToString.IndexOf("%") > -1 Then
                    Return System.Configuration.ConfigurationManager.AppSettings("RecordIdentifier").ToString.Replace("%", Me.BaseName).ToUpper
                Else
                    Return System.Configuration.ConfigurationManager.AppSettings("RecordIdentifier").ToUpper
                End If
            End If

        End Function

        ''' --- GetNewRecordStatus -------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetNewRecordStatus.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overridable Function GetNewStatus() As Boolean
            Return Me.NewRecord
        End Function

        ''' --- GetFileType -------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetFileType.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overridable Function GetFileType() As FileTypes
            Return Me.Type
        End Function

        ''' --- Getter -------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Getter.
        ''' </summary>
        ''' <param name="Sender"></param>
        ''' <param name="GetterArgs"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overridable Function Getter(ByVal Sender As Object, ByVal GetterArgs As GetterArgs) As Boolean
            'If required, can be overrided in derived class
            With GetterArgs

                If Not IsNothing(m_blnDeletedRecord) AndAlso Me.DeletedRecord AndAlso Me.Occurs = 0 Then
                    Select Case .UnderlyingDataType
                        Case DataTypes.Character
                            .FieldText = " "
                        Case DataTypes.Date
                            .FieldText = " "
                            .FieldValue = CType(0, Decimal)
                        Case DataTypes.Numeric
                            .FieldText = " "
                            .FieldValue = CType(0, Decimal)
                    End Select
                Else
                    Select Case .UnderlyingDataType
                        Case DataTypes.Character
                            .FieldText = GetStringValue(.ColumnName)
                        Case DataTypes.Date
                            .FieldText = GetNumericDateValue(.ColumnName).ToString
                            .FieldValue = CType(.FieldText, Decimal)
                        Case DataTypes.Numeric
                            .FieldText = GetDecimalValue(.ColumnName).ToString
                            .FieldValue = CType(.FieldText, Decimal)
                    End Select
                End If
            End With
        End Function

        ''' --- Setter -------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Setter.
        ''' </summary>
        ''' <param name="Sender"></param>
        ''' <param name="SetterArgs"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overridable Function Setter(ByVal Sender As Object, ByVal SetterArgs As SetterArgs) As Boolean
            'If required, can be overrided in derived class
            With SetterArgs
                'If Field value is being changed during "Select" processing, don't alter the record's status
                m_blnDontAlter = (.PageMode = PageModeTypes.Select)
                Select Case .UnderlyingDataType
                    Case DataTypes.Character
                        SetValue(.ColumnName) = .FieldText
                    Case DataTypes.Date, DataTypes.Numeric
                        SetValue(.ColumnName) = .FieldValue
                End Select
            End With
        End Function

        ''' --- SetEditFlag -------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of SetEditFlag.
        ''' </summary>
        ''' <param name="Field"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overridable Function SetEditFlag(ByVal Field As String) As Boolean
            'If required, can be overrided in derived class
            SetEditField = Field
        End Function

        ''' --- GetInternalValues --------------------------------------------------
        ''' <exclude/>
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overridable Function GetInternalValues(Optional ByVal PassingFile As Boolean = False) As Hashtable Implements IFileObject.GetInternalValues
            Dim hstInternalValues As Hashtable

            ' If we are passing the file to the next screen, ensure that if we have a new,
            ' un-initialized record that the record is initialized.  
            If PassingFile Then
                CheckStatusAndInitializeRecord()
            End If

            hstInternalValues = New Hashtable
            With hstInternalValues

                If PassingFile Then
                    Dim intCurrentRow As Integer
                    intCurrentRow = Me.CurrentRow

                    If m_dtbDataTable Is Nothing Then
                        .Add("m_dtbDataTable", Nothing)
                    Else
                        .Add("m_dtbDataTable", Me.m_dtbDataTable.Copy)
                        With CType(.Item("m_dtbDataTable"), DataTable)
                            For r As Integer = (Math.Min(m_intOccurs, m_dtbDataTable.Rows.Count) - 1) To 0 Step -1
                                Select Case r
                                    Case Is > intCurrentRow
                                        .Rows.RemoveAt(r)
                                    Case Is = intCurrentRow
                                        'Leave this row
                                    Case Else
                                        .Rows.RemoveAt(r)
                                End Select
                            Next
                        End With
                    End If

                    ' Pass the record status flags.
                    .Item("m_blnAlteredRecord") = BooleanArray(m_blnAlteredRecord(intCurrentRow))
                    .Item("m_blnNewRecord") = BooleanArray(m_blnNewRecord(intCurrentRow))
                    .Item("m_blnDeletedRecord") = BooleanArray(m_blnDeletedRecord(intCurrentRow))
                    .Item("m_blnGridDeletedRecord") = BooleanArray(m_blnGridDeletedRecord(intCurrentRow))
                    .Item("m_blnIsInitialized") = BooleanArray(m_blnIsInitialized(intCurrentRow))
                    .Item("m_blnCountIntoCalled") = BooleanArray(m_blnCountIntoCalled(intCurrentRow))
                    .Item("m_HasData") = Me.m_HasData
                Else
                    .Add("m_HasData", Me.m_HasData)
                    .Add("m_strOrderBy", Me.m_strOrderBy)
                    .Add("m_strCursor", Me.m_strCursor)
                    .Add("m_blnAlteredRecord", GetArrayCopy(Me.m_blnAlteredRecord))
                    .Add("m_blnNewRecord", GetArrayCopy(Me.m_blnNewRecord))
                    .Add("m_blnDeletedRecord", GetArrayCopy(Me.m_blnDeletedRecord))
                    .Add("m_blnGridDeletedRecord", GetArrayCopy(Me.m_blnGridDeletedRecord))
                    .Add("m_blnIsInitialized", GetArrayCopy(Me.m_blnIsInitialized))
                    .Add("m_strLastSQL", Me.m_strLastSQL)
                    .Add("m_blnCountIntoCalled", GetArrayCopy(Me.m_blnCountIntoCalled))


                    'Removed code from FileObject’s constructor and GetObjectData, which was used 
                    'to Serialize and Deserialize the file object with schema. Instead of that I added code 
                    'serialize and deserialize only a table (without shema).
                    '
                    'I added the removed code when "Cached Schema" was not working while 
                    'saving objects in ViewState, however yesterday, during George’s visit 
                    'I could not reproduce the error. So I am rolling back code I added. 
                    'In case in future if we ever get similar error, we may need to 
                    'reintrodue the code I am removing now.
                    If m_dtbDataTable Is Nothing Then
                        .Add("m_dtbDataTable", Nothing)
                    Else
                        .Add("m_dtbDataTable", Me.m_dtbDataTable.Copy)
                    End If

                    .Add("m_blnEOF", Me.m_blnEOF)
                    .Add("m_blnHasLastGetData", m_blnHasLastGetData)
                End If
            End With
            Return hstInternalValues
        End Function

        ''' --- SetInternalValues --------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of SetInternalValues.
        ''' </summary>
        ''' <param name="InternalValues"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Sub SetInternalValues(ByVal InternalValues As Hashtable, Optional ByVal PassingFile As Boolean = False, Optional ByVal PassingSequence As Integer = 0) Implements IFileObject.SetInternalValues
            Try

                If PassingFile Then
                    Dim intCurrentRow As Integer
                    intCurrentRow = Me.CurrentRow

                    Dim dtbFromState As DataTable
                    dtbFromState = CType(InternalValues("m_dtbDataTable"), DataTable)
                    If Not dtbFromState Is Nothing Then
                        If m_dtbDataTable Is Nothing Then
                            m_dtbDataTable = dtbFromState.Copy
                        Else
                            If Not Me.Type = FileTypes.Reference Then 'm_dtbDataTable.Rows(intCurrentRow).ItemArray = dtbFromState.Rows(0).ItemArray
                                If dtbFromState.Rows(0).HasVersion(DataRowVersion.Original) Then
                                    For i As Integer = 0 To m_dtbDataTable.Columns.Count - 1
                                        m_dtbDataTable.Rows(intCurrentRow).Item(i) = dtbFromState.Rows(0).Item(i, DataRowVersion.Original)
                                    Next
                                    m_dtbDataTable.Rows(intCurrentRow).AcceptChanges()
                                End If

                                For i As Integer = 0 To m_dtbDataTable.Columns.Count - 1
                                    m_dtbDataTable.Rows(intCurrentRow).Item(i) = dtbFromState.Rows(0).Item(i)
                                Next
                            End If

                        End If
                        If dtbFromState.Rows.Count > 0 AndAlso dtbFromState.Rows(0).HasVersion(DataRowVersion.Original) AndAlso Not m_dtbDataTable.Rows(intCurrentRow).HasVersion(DataRowVersion.Original) Then
                            m_dtbDataTable.Rows(intCurrentRow).AcceptChanges()
                        End If
                    Else
                        m_dtbDataTable = Nothing
                    End If
                    AlteredRecord(intCurrentRow) = CType(InternalValues("m_blnAlteredRecord"), Boolean())(0)
                    m_blnNewRecord(intCurrentRow) = CType(InternalValues("m_blnNewRecord"), Boolean())(0)
                    m_blnDeletedRecord(intCurrentRow) = CType(InternalValues("m_blnDeletedRecord"), Boolean())(0)
                    m_blnGridDeletedRecord(intCurrentRow) = CType(InternalValues("m_blnGridDeletedRecord"), Boolean())(0)
                    m_blnIsInitialized(intCurrentRow) = CType(InternalValues("m_blnIsInitialized"), Boolean())(0)
                    m_blnCountIntoCalled(intCurrentRow) = CType(InternalValues("m_blnCountIntoCalled"), Boolean())(0)
                    m_intPassingSequence = PassingSequence
                Else
                    m_strOrderBy = CStr(InternalValues("m_strOrderBy"))
                    m_strCursor = CStr(InternalValues("m_strCursor"))
                    m_strLastSQL = CStr(InternalValues("m_strLastSQL"))

                    'Removed code from FileObject’s constructor and GetObjectData, which was used 
                    'to Serialize and Deserialize the file object with schema. Instead of that I added code 
                    'serialize and deserialize only a table (without shema).
                    '
                    'I added the removed code when "Cached Schema" was not working while 
                    'saving objects in ViewState, however yesterday, during George’s visit 
                    'I could not reproduce the error. So I am rolling back code I added. 
                    'In case in future if we ever get similar error, we may need to 
                    'reintrodue the code I am removing now.
                    If Not CType(InternalValues("m_dtbDataTable"), DataTable) Is Nothing Then
                        m_dtbDataTable = CType(InternalValues("m_dtbDataTable"), DataTable).Copy
                    Else
                        m_dtbDataTable = Nothing
                    End If
                    CopyArray(CType(InternalValues("m_blnAlteredRecord"), Boolean()), m_blnAlteredRecord)
                    CopyArray(CType(InternalValues("m_blnNewRecord"), Boolean()), m_blnNewRecord)
                    CopyArray(CType(InternalValues("m_blnDeletedRecord"), Boolean()), m_blnDeletedRecord)
                    CopyArray(CType(InternalValues("m_blnGridDeletedRecord"), Boolean()), m_blnGridDeletedRecord)
                    CopyArray(CType(InternalValues("m_blnIsInitialized"), Boolean()), m_blnIsInitialized)
                    CopyArray(CType(InternalValues("m_blnCountIntoCalled"), Boolean()), m_blnCountIntoCalled)
                End If

                m_blnEOF = CBool(InternalValues("m_blnEOF"))
                m_blnHasLastGetData = CBool(InternalValues("m_blnHasLastGetData"))
                m_HasData = CType(InternalValues("m_HasData"), Boolean)


                'Set Last File Object in the base page
                If Me.HasLastGetData Then
                    Me.SetLastFileObject()
                End If

                GetRecordBuffer = AddressOf Getter
                SetRecordBuffer = AddressOf Setter
                SetEditFlagValue = AddressOf SetEditFlag
                GetNewRecordStatus = AddressOf GetNewStatus
                GetFileTypeValue = AddressOf GetFileType
            Catch ex As Exception

            End Try

        End Sub

        ''' --- CopyArray ----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of CopyArray.
        ''' </summary>
        ''' <param name="Source"></param>
        ''' <param name="Destination"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Private Sub CopyArray(ByVal Source As Boolean(), ByRef Destination As Boolean())
            'This method is used to return a NEW copy of an "Source" in "Destination"
            If Source Is Nothing Then
                Destination = Nothing
            Else
                Dim blnTemp(Source.Length - 1) As Boolean
                Array.Copy(Source, blnTemp, Source.Length)
                Destination = blnTemp
            End If
        End Sub

        ''' --- GetArrayCopy -------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetArrayCopy.
        ''' </summary>
        ''' <param name="Source"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Private Function GetArrayCopy(ByVal Source As Boolean()) As Boolean()
            'This method is used to return a NEW copy of an "Source"
            If Source Is Nothing Then
                Return Nothing
            Else
                Dim blnTemp(Source.Length - 1) As Boolean
                Array.Copy(Source, blnTemp, Source.Length)
                Return blnTemp
            End If
        End Function


        ''' --- IsInAppendOrEntry --------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of IsInAppendOrEntry.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overridable Function IsInAppendOrEntry() As Boolean
            ' Should be overridden in the Derived class.
        End Function

        ''' --- IsInFindOrDetailFind -----------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of IsInFindOrDetailFind.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overridable Function IsInFindOrDetailFind() As Boolean
            ' Should be overridden in the Derived class.
        End Function

        ''' --- IsInFind -----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of IsInFind.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overridable Function IsInFind() As Boolean
            'Should be overrided in Derived Class
        End Function

        ''' --- PageMode -----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of PageMode.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overridable Function PageMode() As PageModeTypes
            'Should be overrided in Derived Class
        End Function

        ''' --- PageMode -----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of PageMode.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overridable Function SetAlteredFlag() As Boolean
            'Should be overrided in Derived Class

            ' The AlteredRecord flag is not set to True if the value was changed when 
            ' FindMode is true except when in the PostFind or DetailPostFind.  If in 
            ' NoMode (in our case we are in NoMode when searching for a record using FIND 
            ' and no records are found, or by pressing the cancel button), the AlteredRecord flag
            ' should not be set to True, unless we are running the INITIALIZE procedure.  In
            ' all other modes, the AlteredRecord status should change to True when the value changes.

        End Function

        ''' --- UnsubscribeEvents --------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of UnsubscribeEvents.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overridable Sub UnsubscribeEvents()
            'Should be overrided in Derived Class
        End Sub

        ''' --- Lock ---------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Locks a Record, File or Database.
        ''' </summary>
        ''' <param name="LockTypes">One of the defined LockTypes indicating the scope of the Lock.</param>
        ''' <remarks>This function needs to be overridden in Database Specific File Object.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overridable Function Lock(ByVal LockTypes As LockTypes) As Boolean

            'Need to override in Database Specific File Object

            'Note: At present Lock and Unlock doesn't implement all the functionality

        End Function

        ''' --- Purge --------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Purge ???
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overridable Function Purge() As Boolean

        End Function

        ''' --- Build --------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Build ???
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overridable Function Build() As Boolean

        End Function

        ''' --- OpHPBnection -----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of OpHPBnection.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overridable Overloads Function OpHPBnection() As Boolean
            OpHPBnection(False)
        End Function

        ''' --- OpHPBnection -----------------------------------------------------
        ''' <exclude/>
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
        Protected Overridable Overloads Function OpHPBnection(ByVal RequireNewTrnsaction As Boolean) As Boolean

            'Need to override in Database Specific File Object

        End Function

        ''' --- CloseConnection ----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of CloseConnection.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overridable Overloads Function CloseConnection() As Boolean
            If Me.m_blnHasLock Then
                'Don't close connection, only Unlock can close the connection
                CloseConnection(False)
            End If
        End Function

        ''' --- CloseConnection ----------------------------------------------------
        ''' <exclude/>
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
        Protected Overridable Overloads Function CloseConnection(ByVal Commit As Boolean) As Boolean
            'Need to override in Database Specific File Object

            'Note: At present Lock and Unlock doesn't implement all the functionality
        End Function

        ''' --- CloseLockedConnection ----------------------------------------------------
        ''' <exclude/>
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
        Protected Overridable Overloads Function CloseLockedConnection(ByVal Commit As Boolean) As Boolean
            'Need to override in Database Specific File Object

            'Note: At present Lock and Unlock doesn't implement all the functionality
        End Function

        ''' --- Unlock -------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Used to unlock a File Object.
        ''' </summary>
        ''' <param name="LockTypes">One of the defined LockTypes indicating the scope of the Lock.</param>
        ''' <remarks>This function needs to overridden in Database Specific File Object.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overridable Function Unlock(ByVal LockTypes As LockTypes) As Boolean

            'Need to override in Database Specific File Object

            'Note: At present Lock and Unlock doesn't implement all the functionality

        End Function

        ''' --- LookupNotOn --------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Specifies that the field value must not exist in the named record structure.
        ''' </summary>
        ''' <param name="FieldName">A string representing the Field name of the File Object.</param>
        ''' <param name="FieldText">A string containing the current value of the named Field.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Function LookupNotOn(ByVal FieldName As String, ByVal FieldText As String, Optional ByRef Occurrence As Integer = 0) As Boolean
            If Me.Occurs > 0 Then
                'If file "OCCURS", check whether the value exists in existing records or not
                Dim currentRow As Integer = Me.CurrentRow
                With m_dtbDataTable
                    Dim intTotalRows As Integer
                    Dim objDatabaseValue As Object
                    intTotalRows = .Rows.Count
                    For r As Integer = 0 To intTotalRows - 1
                        objDatabaseValue = .Rows(r).Item(FieldName)
                        'TODO: Need to test Convert.IsDBNull
                        If (Not objDatabaseValue Is Nothing) AndAlso (Not Convert.IsDBNull(objDatabaseValue)) Then
                            ' Added TrimEnd to ensure that string values don't have spaces.  Other datatypes
                            ' should be fine as they are compared as strings.
                            If r <> currentRow AndAlso FieldText.TrimEnd.Equals(objDatabaseValue.ToString.TrimEnd) Then
                                Occurrence = r
                                Return False 'Value already exists
                            End If
                        End If
                    Next
                End With
            End If
            Return True  'Value doesn't exist
        End Function

        ''' --- LookupNotOn --------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Specifies that the field value must not exist in the named record structure.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Function LookupNotOn(ByVal FieldNames As String(), ByVal Values As Object(), Optional ByRef Occurrence As Integer = 0) As Boolean
            If Me.Occurs > 0 Then
                'If file "OCCURS", check whether the value exists in existing records or not
                With m_dtbDataTable
                    Dim intTotalRows As Integer
                    Dim objDatabaseValue As Object
                    intTotalRows = .Rows.Count
                    Dim blnValueExists As Boolean
                    For r As Integer = 0 To intTotalRows - 1
                        blnValueExists = False
                        If r <> CurrentRow Then
                            For i As Integer = 0 To FieldNames.Length - 1
                                objDatabaseValue = .Rows(r).Item(FieldNames(i))
                                'TODO: Need to test Convert.IsDBNull
                                If (i = 0 OrElse blnValueExists) AndAlso (Not objDatabaseValue Is Nothing) AndAlso (Not Convert.IsDBNull(objDatabaseValue)) Then
                                    'While checking subsequent fields, value should already exist for previous fields
                                    blnValueExists = Values(i).ToString.TrimEnd.Equals(objDatabaseValue.ToString.TrimEnd)
                                End If
                            Next
                        End If

                        If blnValueExists Then
                            Occurrence = r
                            Return False
                        End If
                    Next
                End With
            End If
            Return True  'Value doesn't exist
        End Function

        ''' --- GetDictionary ----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetDictionary.
        ''' </summary>
        ''' <param name="FieldID"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overridable Function GetDictionary(ByVal FieldID As String) As CoreDictionaryItem
            'Should be implemented in derived FileObject
        End Function

        ''' --- GetCurrentUserID ---------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetCurrentUserID.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overridable Function GetCurrentUserID() As String
            Dim objSecurityManager As New Core.Security.SecurityManager

            Return Security.SecurityManager.GetCurrentUser
        End Function

        ''' --- GetCurrentSessionID ------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetCurrentSessionID.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overridable Function GetCurrentSessionID() As String
            Dim objSecurityManager As New Core.Security.SecurityManager

            Return objSecurityManager.GetSessionID
        End Function

        ''' --- SaveReceivingParam ----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of SaveReceivingParam.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overridable Sub SaveReceivingParam()
            'Should be overrided in the derived FileObject
        End Sub

        ''' --- IsExecutingPath ----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of IsExecutingPath.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overridable Function IsExecutingPath() As Boolean
            'Should be overrided in the derived FileObject
        End Function

        ''' --- IsExecutingPostPath ----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of IsExecutingPostPath.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overridable Function IsExecutingPostPath() As Boolean
            'Should be overrided in the derived FileObject
        End Function

        ''' --- MarkAsAltered ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of MarkAsAltered.
        ''' </summary>
        ''' <param name="Field"></param>
        ''' <param name="Initial"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Private Sub MarkAsAltered(ByVal Field As String, ByVal Initial As Boolean)
            ' Mark record as AlteredRecord to True only if:
            ' - it's not setting a INITIAL value
            ' - "Field" is other than "CHECKSUM_VALUE" or "ROW_ID"
            ' - and value is not being altered during execution of Path or PostPath
            If Initial = False AndAlso Field.ToUpper <> "CHECKSUM_VALUE" AndAlso Field.ToUpper <> "ROW_ID" AndAlso (Not m_blnDontAlter) AndAlso (Not IsExecutingPath() OrElse IsExecutingPostPath()) AndAlso SetAlteredFlag() Then
                Dim intRow As Integer = Me.CurrentRow
                Dim blnAltered As Boolean = m_blnAlteredRecord(intRow)

                AlteredRecord(intRow) = True

                ' Call the CountInto event if a new record is added.
                If Not blnAltered AndAlso m_blnNewRecord(intRow) Then
                    RaiseCountInto(1)
                End If
            End If
        End Sub

        ''' --- SetLastFileObject --------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of SetLastFileObject.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overridable Sub SetLastFileObject()
            'This method is overrided in the System.Web.UI's SqlServerFileObject and OracleFileObject

            'In the overrided method we need to set the current instance of FileObject that 
            'issued last GetData which is turn being used in AlteredRecord, DeletedRecord 
            'and NewRecord Method of the Base Page
        End Sub

        Protected Sub RaiseAudit()
            RaiseEvent Audit()
        End Sub
#End Region

#Region "Dispose Methods"
        ''' --- Dispose ------------------------------------------------------------
        ''' <exclude/>
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

                    If Not m_dtbDataTable Is Nothing Then
                        m_dtbDataTable.Dispose()
                        m_dtbDataTable = Nothing
                    End If

                    If Not m_dtbMetaData Is Nothing Then
                        m_dtbMetaData.Dispose()
                        m_dtbMetaData = Nothing
                    End If

                    If Not dt Is Nothing Then
                        dt.Dispose()
                        dt = Nothing
                    End If

                    Me.m_arrBalanceFields = Nothing
                    Me.m_arrSumIntoFields = Nothing
                    Me.m_blnAlteredRecord = Nothing
                    Me.m_blnBoundToGrid = Nothing
                    Me.m_blnDeletedRecord = Nothing
                    Me.m_blnGridDeletedRecord = Nothing
                    Me.m_blnIsInitialized = Nothing
                    Me.m_blnEOF = Nothing
                    Me.m_strAliasName = Nothing
                    Me.m_strBaseName = Nothing
                    Me.m_strCursor = Nothing
                    Me.m_strLastSQL = Nothing
                    Me.m_strOrderBy = Nothing
                    Me.m_strOwner = Nothing
                    Me.m_strRelation = Nothing
                    Me.GetRecordBuffer = Nothing
                    Me.SetRecordBuffer = Nothing
                    Me.SetEditFlagValue = Nothing
                    Me.GetNewRecordStatus = Nothing
                    Me.GetFileTypeValue = Nothing
                    UnsubscribeEvents()
                    'If Not Me.AccessEvent Is Nothing Then
                    '    RemoveHandler Me.Access, CType(Me.AccessEvent.GetInvocationList.Clone, AccessEventHandler)
                    'End If
                    'If Not Me.SelectIfEvent Is Nothing Then
                    '    RemoveHandler Me.SelectIf, CType(Me.SelectIfEvent.GetInvocationList.Clone, SelectIfEventHandler)
                    'End If
                    'If Not Me.InitializeItemsEvent Is Nothing Then
                    '    RemoveHandler Me.InitializeItems, CType(Me.InitializeItemsEvent.GetInvocationList.Clone, InitializeItemsEventHandler)
                    'End If
                    'If Not Me.SetItemFinalsEvent Is Nothing Then
                    '    RemoveHandler Me.SetItemFinals, CType(Me.SetItemFinalsEvent.GetInvocationList.Clone, SetItemFinalsEventHandler)
                    'End If
                    'If Not Me.CursorEvent Is Nothing Then
                    '    RemoveHandler Me.Cursor, CType(Me.CursorEvent.GetInvocationList.Clone, CursorEventHandler)
                    'End If
                    'If Not Me.BalanceEvent Is Nothing Then
                    '    RemoveHandler Me.Balance, CType(Me.BalanceEvent.GetInvocationList.Clone, BalanceEventHandler)
                    'End If
                    'If Not Me.SumIntoEvent Is Nothing Then
                    '    RemoveHandler Me.SumInto, CType(Me.SumIntoEvent.GetInvocationList.Clone, SumIntoEventHandler)
                    'End If
                    'If Not Me.GoToRecordEventEvent Is Nothing Then
                    '    RemoveHandler Me.GoToRecordEvent, CType(Me.GoToRecordEventEvent.GetInvocationList.Clone, IFileObject.GoToRecordEventEventHandler)
                    'End If
                    'If Not Me.AddRecordEventEvent Is Nothing Then
                    '    RemoveHandler Me.AddRecordEvent, CType(Me.AddRecordEventEvent.GetInvocationList.Clone, AddRecordEventEventHandler)
                    'End If
                    'If Not Me.DeleteRecordEventEvent Is Nothing Then
                    '    RemoveHandler Me.DeleteRecordEvent, CType(Me.DeleteRecordEventEvent.GetInvocationList.Clone, DeleteRecordEventEventHandler)
                    'End If
                    'If Not Me.EditRecordEventEvent Is Nothing Then
                    '    RemoveHandler Me.EditRecordEvent, CType(Me.EditRecordEventEvent.GetInvocationList.Clone, EditRecordEventEventHandler)
                    'End If
                End If
                MyBase.Dispose(True)
            End If
            Me.FileDisposed = True
        End Sub
#End Region

        ''' --- IsOldRecord --------------------------------------------------------
        ''' <exclude/>
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public ReadOnly Property IsOldRecord() As Boolean Implements IFileObject.IsOldRecord
            Get
                Return IsOldRecord(Me.CurrentRow)
            End Get
        End Property

        ''' --- IsOldRecord --------------------------------------------------------
        ''' <exclude/>
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public ReadOnly Property IsOldRecord(ByVal RowPosition As Integer) As Boolean Implements IFileObject.IsOldRecord
            Get
                'This function returns True or False based on the value in Row_ID column 
                '
                'Note: A valid RowPosition should be passed
                'For invalid RowPosition, this function will raise an exception
                If RowPosition = -1 Then
                    Return False
                Else
                    Return ((Not Me.m_dtbDataTable Is Nothing) AndAlso Me.m_dtbDataTable.Rows(RowPosition).Item("Row_ID").ToString.Trim.Length > 0 AndAlso Me.m_dtbDataTable.Rows(RowPosition).Item("Row_ID").ToString.Trim <> "0")
                End If
            End Get
        End Property

        ''' --- RowIDName ----------------------------------------------------------
        ''' <exclude/>
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
        Protected Overridable ReadOnly Property RowIDName() As String
            Get
                'If required should be implemented in Derived FileObject
                Return Nothing
            End Get
        End Property

        ''' --- DatabaseType -------------------------------------------------------
        ''' <exclude/>
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
        Public Overridable ReadOnly Property DatabaseType() As DatabaseTypes Implements IFileObject.DatabaseType
            Get
                'Should be implemented in Derived FileObject
            End Get
        End Property

        ''' --- SkipRecordsWithError -----------------------------------------------
        ''' <exclude/>
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Property SkipRecordsWithError() As Boolean Implements IFileObject.SkipRecordsWithError
            Get
                Return m_blnSkipError
            End Get
            Set(ByVal Value As Boolean)
                m_blnSkipError = Value
            End Set
        End Property

        ''' --- RecordsToRetrieve --------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of RecordsToRetrieve.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Property RecordsToRetrieve() As Integer
            'RecordsToRetrieve is added to forcefully retrieve more records than Occurs
            'espcially, in Find/DetailFind having "Error"
            'This property needs to be set manually depending on the requirement
            '
            'e.g. Occurs is 15, however to fill these 15 rows, if more than 200 records needs to
            'be processed (rest of the records are filtered out by an Error in Find/DetailFind),
            'then setting this property to 200, will get 200 records at a time when
            'we issue GetData(<FileObject>, cSkipError) from the derived page.
            'Note: In the cases like this, Getting too many or too less records can result 
            'result into performance degradation, as such its upto the developer to identify
            'best suitable number for this property, by default GetData will retrieve
            'either records mentioned in Occurs or RecordsToFill (which is a number of records
            'still needs to be filled due to an "Error")
            Get
                If m_intRecordsToRetrieve < Me.Occurs Then
                    Return Me.Occurs
                End If
                Return m_intRecordsToRetrieve
            End Get
            Set(ByVal Value As Integer)
                m_intRecordsToRetrieve = Value
            End Set
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        '''     This member supports the Renaissance Architect Framework infrastructure and is 
        '''     not intended to be used directly from your code.
        ''' </summary>
        ''' 
        ''' <history>
        ''' 	[Mayur]	25/08/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overridable ReadOnly Property RecordsForLoop() As Integer
            Get
                'Should be overridable in the derived class
            End Get
        End Property

        ''' --- TotalRecordsToRetrieve ---------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of TotalRecordsToRetrieve.
        ''' </summary>
        ''' <param name="RecordsToFill"></param>
        ''' <param name="StartRow"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Function TotalRecordsToRetrieve(ByRef RecordsToFill As Integer, ByRef StartRow As Long) As Integer
            Dim intTotalRecordsToRetrieve As Integer
            Dim intRecordsToFill As Integer
            Dim intTotalRecordsProcessed As Integer

            If RecordsToFill > 0 Then
                If m_intRecordsToRetrieve > 0 Then
                    intTotalRecordsToRetrieve = m_intRecordsToRetrieve
                Else
                    intRecordsToFill = RecordsToFill
                    intTotalRecordsToRetrieve = intRecordsToFill
                End If
            Else
                intRecordsToFill = Math.Max(Me.Occurs, 1)
                intTotalRecordsToRetrieve = intRecordsToFill
            End If

            If SkipRecordsWithError Then
                'Only update TotalRecordsProcessed if we need to omit records with an error
                intTotalRecordsProcessed = Me.TotalRecordsProcessed
                StartRow = intTotalRecordsProcessed + 1
                If m_intRecordsToRetrieve <= 0 Then
                    intTotalRecordsProcessed += intRecordsToFill
                End If
                Me.TotalRecordsProcessed = intTotalRecordsProcessed
            End If

            If RecordsToFill > 0 Then
                RecordsToFill = 0
                m_intRecordsToFillInFindOrDetailFind = 0
            End If

            Return intTotalRecordsToRetrieve
        End Function

    End Class

    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: ForInfo
    ''' 
    ''' ---ForInfo-------------------------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of ForInfo.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Class ForInfo
        'Private m_intCurrentOccurrence As Integer

        ''' --- m_intPreviousOccurrence --------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_intPreviousOccurrence.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Private m_intPreviousOccurrence As Integer = -1

        ''' --- m_intPreviousCurrentRecord -----------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_intPreviousCurrentRecord.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Private m_intPreviousCurrentRecord As Integer = -1

        ''' --- New ----------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of New.
        ''' </summary>
        ''' <param name="Occurrence"></param>
        ''' <param name="PreviousCurrentRecord"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Sub New(ByVal Occurrence As Integer, ByVal PreviousCurrentRecord As Integer)
            'Me.m_intCurrentOccurrence = 0
            Me.m_intPreviousOccurrence = Occurrence
            Me.m_intPreviousCurrentRecord = PreviousCurrentRecord
        End Sub

        ''' --- PreviousOccurrence -------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of PreviousOccurrence.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public ReadOnly Property PreviousOccurrence() As Integer
            Get
                Return m_intPreviousOccurrence
            End Get
        End Property

        ''' --- PreviousCurrentRecord ----------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of PreviousCurrentRecord.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public ReadOnly Property PreviousCurrentRecord() As Integer
            Get
                Return m_intPreviousCurrentRecord
            End Get
        End Property


    End Class

End Namespace

