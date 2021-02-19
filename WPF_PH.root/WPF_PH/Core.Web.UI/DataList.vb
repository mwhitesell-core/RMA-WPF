Imports System.ComponentModel
Imports Core.Framework.Core.Framework
Imports System.Windows.Controls
Imports System.Drawing
Imports System.Text
Imports System.Web.UI.HtmlControls
Imports Core.ExceptionManagement

Imports Core.Windows.UI.Core.Windows.UI
Imports Core.Windows.UI.Core.Windows
'Imports Telerik.Windows.Controls.GridView
Imports System.Linq
Imports System.Windows.Media.Imaging
Imports System.Windows
Imports System.Windows.Media
Imports System.Reflection
Imports System.Threading
Imports System.Configuration

Namespace Core.Windows.UI
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: DataList
    '''
    ''' Note    : At present "Datalist" is not available from Toolbox,
    '''           the Grid Page should be created using one of the Core Templates.
    '''
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' <summary>
    ''' 	This class defines the Renaissance Architect DataList.
    ''' </summary>
    ''' <remarks>
    '''     The Renaissance Architect DataList control allows for the grouping of 
    '''     desired records or objects into one displayed structure.
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <ToolboxItem(False),
        EditorBrowsable(EditorBrowsableState.Always)>
    Public Class DataList
        Inherits ListView


#Region " Private, Protected and Public Variables used in class "

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        '''     This member supports the Renaissance Architect Framework infrastructure and 
        '''     is not intended to be used directly from your code.
        ''' </summary>
        ''' 
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Public GridDataTable As DataTable

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        '''     Used to disable the DetailDelete buttons during Correct mode.
        ''' </summary>
        ''' 
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)> Private m_blnDisableDetailDelete As Boolean = False

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        '''     This member supports the Renaissance Architect Framework infrastructure and 
        '''     is not intended to be used directly from your code.
        ''' </summary>
        ''' 
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public blnGenerateTable As Boolean = False


        ''' --- GetGridFieldObjectDelegate -----------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetGridFieldObjectDelegate.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Delegate Sub GetGridFieldObjectDelegate _
        (ByVal DataListField As Object, ByRef CoreField As Object, ByVal Name As String)

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        '''     This member supports the Renaissance Architect Framework infrastructure and 
        '''     is not intended to be used directly from your code.
        ''' </summary>
        ''' 
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Public GetGridFieldObject As GetGridFieldObjectDelegate

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        '''     This member supports the Renaissance Architect Framework infrastructure and 
        '''     is not intended to be used directly from your code.
        ''' </summary>
        ''' 
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Public FileObject As IFileObject

        'Contains the FileObject if this instance of Grid Occurs with a File Object

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        '''     This member supports the Renaissance Architect Framework infrastructure and 
        '''     is not intended to be used directly from your code.
        ''' </summary>
        ''' 
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Public NoRecordsFound As Boolean = False

        Private m_strOccursWith As String
        'Contains the "Name" of FileObject or Temporary Object with which this instance of Grid Occurs
        Private m_objOccursWithCoreBaseType As CoreBaseType
        'Contains the one of the CoreBaseType, if this instance of Grid Occurs with one of the derived object of CoreBaseType

        Private m_blnAlteredRecord() As Boolean
        Private m_blnNewRecord() As Boolean
        Private m_blnDeletedRecord() As Boolean
        Private m_intRowCount As Integer

        Private m_intGridAction As DataListActionTypes = DataListActionTypes.NotSet
        Private m_intToolbarAction As ToolbarIcons
        Private m_strPadSpaces As String = ""
        Private m_intCurrentPageNumber As Integer
        Private m_blnBlankControlsInUndefinedRows As Boolean = False
        Private m_blnEnableFirstNewButton As Boolean = False
        Private m_intGridButton As DataListButtons
        Private m_strEventTarget As String = ""
        Private m_strEventArgument As String = ""
        Private m_strEventCommandName As String = ""
        Private m_blnClearFields As Boolean = False
        Private m_blnEnableFirstRow As Boolean = False
        Private m_blnBindGridEvents As Boolean = False
        Private m_intSelectedRecord As Integer = -1
        Private m_blnAllowSelectRowButton As Boolean = False
        Private m_intNewRowIndex As Integer = -1
        'Should only be used in Click and BeforeClick event handlers
        Private m_blnSuppressAdditionalEdits As Boolean = False

        Private m_objDesigner As Designer
        Private m_blnDesignerMode As Boolean
        Private m_triKeepEditButtonEnabledAfterDesigner As TriState = TriState.UseDefault
        Private m_blnKeepEditButtonEnabled As Boolean = True
        Private m_triKeepDeleteButtonEnabledAfterDesigner As TriState = TriState.UseDefault
        Private m_blnKeepDeleteButtonEnabled As Boolean = False
        Private m_blnEnableAllEditButtons As Boolean = False
        Private m_blnNoAppend As Boolean = False
        Private m_blnNoChange As Boolean = False
        Private m_blnNoDelete As Boolean = False
        Private m_blnHasError As Boolean = False
        Private m_intPageMode As PageModeTypes = PageModeTypes.NoMode
        'At present used in Prepare For Display

        Private m_blnRequireSelectProcessing As Boolean = True
        Private m_blnOverrideSelectProcessing As TriState = TriState.UseDefault

        ''' --- GridUpdateValidation -----------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GridUpdateValidation.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Event GridUpdateValidation(ByVal Sender As DataList, ByVal EventArgs As Object,
                                       ByVal NewRecordPosition As Integer)

        'These are three Core Solution specific events which 
        'developer can use to prohibit end user from selecting a particular row
        'by setting corresponding Cancel Variable to True in Event Handler code


        ''' --- BeforeAdd ----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of BeforeAdd.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Event BeforeAdd(ByVal source As DataList, ByVal GridButtonEventArgs As GridButtonEventArgs,
                            ByRef CancelAdd As Boolean)

        ''' --- BeforeEdit ---------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of BeforeEdit.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Event BeforeEdit(ByVal source As DataList, ByVal GridButtonEventArgs As GridButtonEventArgs,
                             ByRef CancelEdit As Boolean)

        ''' --- BeforeDelete -------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of BeforeDelete.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Event BeforeDelete(ByVal source As DataList, ByVal GridButtonEventArgs As GridButtonEventArgs,
                               ByRef CancelDelete As Boolean)

        ''' --- AddClick -----------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Event to allow user to Add a record to the Grid.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Event AddClick(ByVal source As DataList, ByVal GridButtonEventArgs As GridButtonEventArgs)

        ''' --- EditClick ----------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Event to allow user to Edit a record in the Grid.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Event EditClick(ByVal source As DataList, ByVal GridButtonEventArgs As GridButtonEventArgs)

        ''' --- DeleteClick --------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Event to allow user to Delete a record in the Grid.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Event DeleteClick(ByVal source As DataList, ByVal GridButtonEventArgs As GridButtonEventArgs)

        'Following events to be used to notify FileObject/CoreBaseType associated with Grid
        'and should be used internally within the Core Framework
        'Protected Friend Event MoveRecordEvent(ByVal Sender As Object, ByVal EventArgs As Object, ByVal NewRecordPosition As Integer)

        ''' --- AppendRecordEvent --------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of AppendRecordEvent.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Friend Event AppendRecordEvent(ByVal Sender As Object, ByVal EventArgs As Object,
                                              ByVal NewRecordPosition As Integer, ByVal IsGridNew As Boolean)

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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Friend Event GoToRecordEvent(ByVal Sender As Object, ByVal EventArgs As Object,
                                            ByVal NewRecordPosition As Integer)

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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Friend Event DeleteRecordEvent(ByVal Sender As Object, ByVal EventArgs As Object,
                                              ByVal NewRecordPosition As Integer)

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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Friend Event EditRecordEvent(ByVal Sender As Object, ByVal EventArgs As Object,
                                            ByVal NewRecordPosition As Integer)

        Private m_intNextRecord As Integer = -1
        Private m_blnAllowEditButton As Boolean = True
        Private m_blnHasPaginate As Boolean = False
        Private m_bytPaginationTypes As PaginationTypes = PaginationTypes.Default
        ' Used in Formissing to display "Next" only in Paginate; Mainly introduced in Formissing to handle error in Find

        ' Used to indicate that we moved using pagination.  This ensures that we set the 
        ' CurrentPageNumber and CurrentSetNumber back to 1.
        Private m_blnKeepPaginationPage As Boolean
        Private m_strAppendButton As String = String.Empty
        Private m_strNextPage As String = String.Empty
        Private m_strPreviousPage As String = String.Empty

        Private m_blnDictionaryLoaded As Boolean = False
        ' Determine if the dictionary values are loaded.
        Private m_blnGridDesignerCompleted As Boolean = False
        Private m_blnMaxAppend As Boolean = False
        Private m_blnNoNewAppend As Boolean = False

        Private m_intNextAppendInRow As Integer = -1
        'Leave the initial value to -1
        Private m_blnImmediateTerminateFromFirstNew As Boolean = False
        'Used to determine whether the Append is terminated from GridNew/Entry (from First Field of the First record) or not
        Private m_blnUsingAcceptProcessing As Boolean = False
        'Used to determine whether the screen using AcceptProcessing or not
        Private m_blnEnableFirstEmptyNewButton As Boolean = False
        'Enable New Record button for First empty row

#End Region

#Region " Public Properties "

        ''' --- GridDesignerCompleted ----------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GridDesignerCompleted.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Browsable(False),
            EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Property GridDesignerCompleted() As Boolean
            Get
                Return m_blnGridDesignerCompleted
            End Get
            Set(ByVal Value As Boolean)
                m_blnGridDesignerCompleted = Value
            End Set
        End Property

        ''' --- MaxAppend -----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of MaxAppend.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Browsable(False),
            EditorBrowsable(EditorBrowsableState.Always)>
        Public Property MaxAppend() As Boolean
            ' This property is used to set a limit on the number of appends.
            Get
                Return m_blnMaxAppend
            End Get
            Set(ByVal Value As Boolean)
                m_blnMaxAppend = Value
            End Set
        End Property

        ''' --- PreviousDataID -----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of PreviousDataID.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Browsable(False),
            EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Property PreviousDataID() As String
            ' This property is used for the PUSH (NextData) verb.
            Get
                Return m_strPreviousPage
            End Get
            Set(ByVal Value As String)
                m_strPreviousPage = Value
            End Set
        End Property

        ''' --- NextDataID ---------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of NextDataID.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Browsable(False),
            EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Property NextDataID() As String
            ' This property is used for the PUSH (NextData) verb.
            Get
                Return m_strNextPage
            End Get
            Set(ByVal Value As String)
                m_strNextPage = Value
            End Set
        End Property

        ''' --- AppendID -----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of AppendID.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Browsable(False),
            EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Property AppendID() As String
            ' This property is used for the PUSH (Append) verb.
            Get
                Return m_strAppendButton
            End Get
            Set(ByVal Value As String)
                m_strAppendButton = Value
            End Set
        End Property

        ''' --- AddRowIndex --------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of AddRowIndex.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Browsable(False),
            EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Property AddRowIndex() As Integer
            Get
                Return _AddRowIndex
            End Get
            Set(ByVal Value As Integer)
                _AddRowIndex = Value
            End Set
        End Property
        Private _AddRowIndex As Integer = -1


        ''' --- PreviousRowIndex ---------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of PreviousRowIndex.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Browsable(False),
            EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Property PreviousRowIndex() As Integer
            Get
                Return _PreviousRowIndex
            End Get
            Set(ByVal Value As Integer)
                _PreviousRowIndex = Value
            End Set
        End Property
        Private _PreviousRowIndex As Integer = -1


        ''' --- ReadOnly -----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of ReadOnly.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub [ReadOnly]()
            Me.ReadOnly(TriState.UseDefault)
        End Sub

        ''' --- ReadOnly -----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of ReadOnly.
        ''' </summary>
        ''' <param name="DesignerMode"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub [ReadOnly](ByVal DesignerMode As TriState)

            'Disable all rows in grid
            CurrentRowIndex = -1

            ''Reset Designer Mode on Base Page
            With ApplicationState.Current.CorePage
                Select Case TriState.UseDefault
                    'Case TriState.True
                    '    .DesignerMode = True
                    'Case TriState.False
                    '    .DesignerMode = False
                    Case TriState.UseDefault
                        'Use the existing value
                End Select

                'Reset Append Mode on Base Page
                .AppendMode = False
            End With
        End Sub

        ''' --- Occurs -------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Occurs.
        ''' </summary>
        ''' <remarks>
        '''     Occurs Property only needs to be set once during DataBind and will be 
        '''     referred in all subsequent postbacks.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Property Occurs() As Integer
            Get
                Return _Occurs
            End Get
            Set(ByVal Value As Integer)
                _Occurs = Value
            End Set
        End Property
        Dim _Occurs As Integer

        ''' --- OccursWith ---------------------------------------------------------
        ''' 
        ''' <summary>
        '''     Repeats the record structure of object associated with.
        ''' </summary>
        ''' <value>
        ''' 	Contains the "Name" of the FileObject or Temporary Object with which 
        '''     this instance of the Grid OccursWith.
        ''' </value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Property OccursWith() As String
            Get
                Return m_strOccursWith
                'Return ViewState("OccursWith")
            End Get
            Set(ByVal Value As String)
                m_strOccursWith = Value
                'ViewState("OccursWith") = Value
            End Set
        End Property

        ''' --- OccursWithFile -----------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Contains a reference to a FileObject.
        ''' </summary>
        ''' <value>
        '''     A defined FileObject.
        ''' </value>
        ''' <remarks>
        '''     Will contain the reference to a FileObject only if this 
        '''     instance of the Grid Occurs with a defined File Object.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Browsable(False),
            EditorBrowsable(EditorBrowsableState.Always)>
        Public Property OccursWithFile() As IFileObject
            Get
                Return FileObject
                'Return ViewState("OccursWith")
            End Get
            Set(ByVal Value As IFileObject)
                Value.BoundToGrid = True
                FileObject = Value
                ApplicationState.Current.CorePage.m_ClusterFile = Value
                Select Case Value.Type
                    Case FileTypes.Primary, FileTypes.Secondary
                        ApplicationState.Current.CorePage.ScreenType = ScreenTypes.Grid
                    Case FileTypes.Detail
                        ApplicationState.Current.CorePage.OccursWithDetail = True
                    Case Else
                        'If we ever need other ScreenTypes we need 
                        'to write necessary code over here
                End Select
            End Set
        End Property

        ''' --- OccursWithCoreBaseType ---------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Contains a reference to a temporary object.
        ''' </summary>
        ''' <value>
        '''     A defined CoreBaseType Object.
        ''' </value>
        ''' <remarks>
        '''     Will contain a reference to a CoreBaseType only if this instance of the Grid 
        '''     Occurs with one of the derived types of the CoreBaseType Object.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Browsable(False),
            EditorBrowsable(EditorBrowsableState.Always)>
        Public Property OccursWithCoreBaseType() As CoreBaseType
            Get
                Return m_objOccursWithCoreBaseType
            End Get
            Set(ByVal Value As CoreBaseType)
                m_objOccursWithCoreBaseType = Value
            End Set
        End Property

        ''' --- SuppressAdditionalEdits --------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of SuppressAdditionalEdits.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Description("Display the Edit button only for the first grid record and suppress it on all other records."),
            Category("Core"),
            DefaultValue("False"),
            EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Property SuppressAdditionalEdits() As Boolean
            Get
                Return m_blnSuppressAdditionalEdits
            End Get
            Set(ByVal Value As Boolean)
                m_blnSuppressAdditionalEdits = Value
            End Set
        End Property

        'This property needs to be enabled in order to 
        'allow user to select a record and call Designer
        'e.g. in View Screens, there can be NoAppend set to true and
        'no ChangeActivity still user needs to be allowed to selected a record
        'Setting this property will enable the Edit Button even if append or 
        'change is not allowed.
        'Contradictory, setting it to False has NO effect i.e. system will use
        'the default logic to enable or disable the Edit Button
        'Setting this property will enable those Edit Button against which 
        'it has data. To enable all Edit Buttons regardless it has data or not
        'use EnableAllEditButtons property
        ''' --- KeepEditButtonEnabled ----------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of KeepEditButtonEnabled.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <
            Description _
                (
                 "True enables the Edit/Designer button even if Append or Change is not allowed. Setting to False has no effect (i.e. system will use the default logic to enable or disable this Button)."),
            Category("Core"),
            DefaultValue("True"),
            EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Property KeepEditButtonEnabled() As Boolean
            Get
                Return m_blnKeepEditButtonEnabled
            End Get
            Set(ByVal Value As Boolean)
                m_blnKeepEditButtonEnabled = Value
            End Set
        End Property

        ' Disables the DetailDelete buttons regardless of being in Correct mode.
        ''' --- DisableDetailDelete -----------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of DisableDetailDelete.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Description("True disabled all Detail Delete buttons"),
            Category("Core"),
            DefaultValue("False"),
            EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Property DisableDetailDelete() As Boolean
            Get
                Return m_blnDisableDetailDelete
            End Get
            Set(ByVal Value As Boolean)
                m_blnDisableDetailDelete = Value
            End Set
        End Property

        'EnableAllEditButtons enables all Edit Buttons regardless it has data or not
        'To enable EditButtons having data use KeepEditButtonEnabled property
        'Generally if Grid contains a Field bound to one of the derived
        'Base Type Variable, then precomiler should set EnableAllEditButtons property to True
        ''' --- EnableAllEditButtons -----------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of EnableAllEditButtons.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Description("True enables all Edit Buttons regardless it has data or not."),
            Category("Core"),
            DefaultValue("False"),
            EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Property EnableAllEditButtons() As Boolean
            Get
                Return m_blnEnableAllEditButtons
            End Get
            Set(ByVal Value As Boolean)
                m_blnEnableAllEditButtons = Value
            End Set
        End Property

        'Setting this property will enable the Delete Button even if 
        'there is NoDelete on Associated File or NoDeleteActivity on 
        'a screen Contradictory, setting it to False has NO effect 
        'i.e. system will use the default logic to enable or disable the Delete Button
        ''' --- KeepDeleteButtonEnabled --------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of KeepDeleteButtonEnabled.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <
            Description _
                (
                 "Setting this property will enable the Delete Button regardless of whether the NoDelete is set on the associated file or the Delete activity on the screen is False. Setting it to False has no effect (i.e. system will use the default logic to enable or disable this button)."),
            Category("Core"),
            DefaultValue("False"),
            EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Property KeepDeleteButtonEnabled() As Boolean
            Get
                Return m_blnKeepDeleteButtonEnabled
            End Get
            Set(ByVal Value As Boolean)
                m_blnKeepDeleteButtonEnabled = Value
            End Set
        End Property

        ''' --- RowsInitiallyDisplayedInGrid ---------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of RowsInitiallyDisplayedInGrid.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Browsable(False),
            EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Property RowsInitiallyDisplayedInGrid() As Integer
            Get
                Return _RowsInitiallyDisplayedInGrid
            End Get
            Set(ByVal Value As Integer)
                _RowsInitiallyDisplayedInGrid = Value
            End Set
        End Property
        Dim _RowsInitiallyDisplayedInGrid As Integer

        '----------------------------------------
        ' GridNew property
        ' IsGridNew is used while saving a record, to
        ' pass this property as a parameter to clear rows 
        ' from respective FileObject and start with the first new Row
        '----------------------------------------
        ''' --- IsGridNew ----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of IsGridNew.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Friend Property IsGridNew() As Boolean
            Get
                Return _IsGridNew
            End Get
            Set(ByVal Value As Boolean)
                _IsGridNew = Value
            End Set
        End Property
        Dim _IsGridNew As Boolean


        ''' --- CurrentRowIndex ----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of CurrentRowIndex.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Browsable(False),
            EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Property CurrentRowIndex() As Integer
            Get
                Return _CurrentRowIndex
            End Get
            Set(ByVal Value As Integer)
                _CurrentRowIndex = Value
            End Set
        End Property
        Dim _CurrentRowIndex As Integer = -1

        ''' --- NewRowIndex --------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of NewRowIndex.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Browsable(False),
            EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Property NewRowIndex() As Integer
            Get
                Return m_intNewRowIndex
            End Get
            Set(ByVal Value As Integer)
                m_intNewRowIndex = Value
            End Set
        End Property

        'We are not using this standard property rather we are using CurrentRowIndex
        ''' --- EditItemIndex ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of EditItemIndex.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Browsable(False),
            EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Property EditItemIndex() As Integer
            Get
                Return -1
            End Get
            Set(ByVal Value As Integer)
                'Ignore as we are not using this property
            End Set
        End Property

        '----------------------
        ' NoAppend property
        ' Setting NoAppend to True will disable Append on a Grid
        '----------------------
        ''' --- NoAppend -----------------------------------------------------------
        ''' <exclude/>
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
        <Description("Setting NoAppend to True will disable Append on a Grid."),
            Category("Core"),
            DefaultValue(GetType(Boolean), "False"),
            EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Property NoAppend() As Boolean
            Get
                Return m_blnNoAppend
            End Get
            Set(ByVal Value As Boolean)
                m_blnNoAppend = Value
            End Set
        End Property

        '----------------------
        ' NoChange property
        ' Setting NoChange to True will disable Edit Button on a Grid
        '----------------------
        ''' --- NoChange -----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of NoChange.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Description("Setting NoChange to True will disable Edit Button on a Grid."),
            Category("Core"),
            DefaultValue(GetType(Boolean), "False"),
            EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Property NoChange() As Boolean
            Get
                Return m_blnNoChange
            End Get
            Set(ByVal Value As Boolean)
                m_blnNoChange = Value
            End Set
        End Property

        '----------------------
        ' NoDelete property
        ' Setting NoDelete to True will disable Delete on a Grid
        '----------------------
        ''' --- NoDelete -----------------------------------------------------------
        ''' <exclude/>
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
        <Description("Setting NoDelete to True will disable Delete on a Grid."),
            Category("Core"),
            DefaultValue(GetType(Boolean), "False"),
            EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Property NoDelete() As Boolean
            Get
                Return m_blnNoDelete
            End Get
            Set(ByVal Value As Boolean)
                m_blnNoDelete = Value
            End Set
        End Property

        ''' --- AllowGridNew -------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of AllowGridNew.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Property AllowGridNew() As Boolean
            Get
                Dim blnAllowGridNew As Boolean

                'Disable Grid New button if:
                '- this property is not in ViewState
                '- user click on Find/Add/Cancel
                With ApplicationState.Current.CorePage
                    If _
                        (Not Me.m_blnUsingAcceptProcessing AndAlso Me.m_intToolbarAction = ToolbarIcons.Find AndAlso
                         (.HasPathRequestFields)) _
                        OrElse
                        (Me.m_blnUsingAcceptProcessing AndAlso Me.m_intToolbarAction = ToolbarIcons.Find AndAlso
                         ApplicationState.Current.CorePage.EnableNumberedDesigners AndAlso (.HasPathRequestFields)) _
                        Then
                        blnAllowGridNew = False
                        Return False
                    End If
                End With
                If _
                   Me.m_intToolbarAction = ToolbarIcons.Add OrElse
                   Me.m_intToolbarAction = ToolbarIcons.Cancel Then
                    AllowGridNew = False
                    blnAllowGridNew = False
                Else
                    blnAllowGridNew = blnOverRideAllowGridNew
                End If

                'If submit and last row of the grid has record then enable Append button on top of grid
                If (Not m_blnHasError) AndAlso Me.m_intToolbarAction = ToolbarIcons.Submit AndAlso (m_intPageMode = PageModeTypes.Entry OrElse m_intPageMode = PageModeTypes.Correct OrElse m_intPageMode = PageModeTypes.Change) Then
                    Select Case Me.GetStatus(Me.Items.Count - 1).CurrentStatus
                        Case GridRowStatus.UnchangedOld, GridRowStatus.Edited, GridRowStatus.Added, GridRowStatus.Deleted
                            'If last record in grid is successfully added, changed or deleted then
                            'allow Grid New
                            blnAllowGridNew = True
                    End Select
                End If

                Return blnAllowGridNew
            End Get
            Set(ByVal Value As Boolean)
                If Value AndAlso Me.m_intGridAction = DataListActionTypes.GridNew Then
                    'Whether to allow Append through "GridNew" or not!
                    'If there is no records and NoAppend Property on Grid Control is not set to false
                    'Enable the "GridNew" button which is equallent to "Append", however "GridNew" button
                    'Gets enabled only if there is all the rows in Grid has Data displayed or 
                    'there is none on a grid
                    '
                    'However, If selects a GridNew (Append) in that case, all though there is no
                    'record in grid we will no enable the "GridNew" button
                    Value = False
                End If
                blnOverRideAllowGridNew = Value
            End Set
        End Property

        Dim blnOverRideAllowGridNew As Boolean
        '----------------------
        ' AllowSelectRowButton property
        ' Set this property to "True" to display a Radio/Checkbox button. 
        ' AllowSelectRowButton property is used with Designer Links that 
        ' act on rows in a grid.
        '----------------------
        ''' --- AllowSelectRowButton -----------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Sets or gets a boolean value indicating that the rows within the grid
        '''     can be selected using a radio button/checkbox to execute
        '''     a designer procedure against the select row(s).
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <
            Description _
                (
                 "Set this property to ""True"" to display a Radio/Checkbox Button.  This enables a Designer function to operate on rows in the grid."),
            Category("Core"),
            DefaultValue(GetType(Boolean), "True"),
            EditorBrowsable(EditorBrowsableState.Always)>
        Public Property AllowSelectRowButton() As Boolean
            Get
                Return m_blnAllowSelectRowButton
            End Get

            Set(ByVal Value As Boolean)
                m_blnAllowSelectRowButton = Value
            End Set
        End Property

#End Region

#Region " Public Methods "



        ''' --- PrepareGridToProcess -----------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of PrepareGridToProcess.
        ''' </summary>
        ''' <param name="CallMainSaveState"></param>
        ''' <param name="CallInFieldSaveState"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub PrepareGridToProcess(ByRef CallMainSaveState As Boolean, ByRef CallInFieldSaveState As Boolean)

            GridDesignerCompleted = False

            'Used a local variable to determine whether the screen using AcceptProcessing or not
            Me.m_blnUsingAcceptProcessing = ApplicationState.Current.CorePage.UseAcceptProcessing

            'Ideally SetRelations should only set
            '- OccursWithFile if grid occurs with the File Object
            '- OccursWithCoreBaseType, if grid occurs with one of the derived Type from CoreBaseType
            WireNavigationEvents()

            If ApplicationState.Current.CorePage.PageClick <> PaginationClick.NotSet Then

                ChangeGridPage()

                'At the time when responding to Base Page's we ONLY have to SaveState in InField variables
                CallMainSaveState = True
                'We need to update the main state, which is used to update the record
                CallInFieldSaveState = True

                'Added to handle any reference to Field from Path or Find
                BindGridFieldsEvents(0, False)
            Else

                If Me.m_blnUsingAcceptProcessing Then
                    PositionRowFireEventsForAcceptProcessing(CallMainSaveState, CallInFieldSaveState)
                Else
                    PositionRowFireEvents(CallMainSaveState, CallInFieldSaveState)
                End If

                'We don't have to bind fields if user click on GridNew or events are already bound
                If m_blnBindGridEvents Then BindGridFieldsEvents(CurrentRowIndex, False)
            End If
        End Sub

        ''' --- GetGridAction ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetGridAction.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetGridAction() As DataListActionTypes
            m_intGridButton = GetGridButton()
            'Dim strEventTarget As String = Me.Page.Request("__EventTarget") & ""
            'Dim strEventArgument As String = Me.Page.Request("__EventArgument") & ""

            Select Case m_intGridButton
                Case DataListButtons.EditRecordButton
                    If _
                        m_strEventArgument.ToUpper = "ADD" OrElse m_strEventArgument.ToUpper = "ADDING" OrElse
                        m_strEventArgument.ToUpper = "ADDED" OrElse m_strEventArgument.ToUpper = "UNCHANGEDNEW" Then
                        ' Although used to append a record in a grid Add is used to Append a record in a grid if grid has space to Add a record i.e. records displayed in a Grid is less then the Occurs.
                        Return DataListActionTypes.Add
                    Else
                        Return DataListActionTypes.Update
                    End If
                Case DataListButtons.DeleteRecordButton
                    Return DataListActionTypes.Delete
                Case DataListButtons.NewRecordButton
                    ' GridNew is similar to Add and it differs in the way that GridNew is used to Append a Record in a Grid if Grid-Full records are displayed on a Grid
                    Return DataListActionTypes.GridNew
                Case DataListButtons.SelectRecordButton
                    ' Unless otherwise changed, We don't have Select Record Button
                Case DataListButtons.NotSet
                    If m_strEventArgument.IndexOf("Pagination") = 0 Then
                        m_strEventCommandName = m_strEventArgument.Substring(m_strEventArgument.IndexOf("~") + 1)
                        m_strEventArgument = m_strEventArgument.Substring(0, m_strEventArgument.IndexOf("~"))
                        With ApplicationState.Current.CorePage
                            .PageActionType = PageActionType.PaginationClick
                            .PageActionObject = m_strEventArgument
                            '.Substring(0, m_strEventArgument.IndexOf("~"))
                        End With
                        Me.AllowGridNew = False
                        Return DataListActionTypes.Pagination
                    Else
                        Return DataListActionTypes.NotSet
                    End If
                Case Else
            End Select
        End Function

        'Gets the RowStatus object based on CurrentRowIndex property
        ''' --- GetStatus ----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetStatus.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetStatus() As RowStatus
            Return GetStatus(CurrentRowIndex)
        End Function

        'Gets the RowStatus object for the row denoted by RowIndex parameter
        ''' --- GetStatus ----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetStatus.
        ''' </summary>
        ''' <param name="RowIndex"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetStatus(ByVal RowIndex As Integer) As RowStatus
            Dim intOccurs = Occurs
            If intOccurs > 0 AndAlso RowIndex < intOccurs Then
                Return GetStatus(GetDataListItem(RowIndex))
            Else
                'Should not be the case
                Return Nothing
            End If
        End Function

        ''' --- GetDataListItem ----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetDataListItem.
        ''' </summary>
        ''' <param name="ItemIndex"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public ReadOnly Property GetDataListItem(ByVal ItemIndex As Integer) As GridViewRowPresenter
            Get
                If (Items.Count > 0) Then
                    If ItemIndex >= 0 AndAlso ItemIndex < Occurs Then
                        SelectedItem = Items(ItemIndex)
                        Return GetRow(Me, ItemIndex)
                    Else
                        Throw New Exception("Invalid ItemIndex")
                    End If
                End If

                Exit Property

            End Get
        End Property

        'Gets the RowStatus object for the passed DataListItem
        ''' --- GetStatus ----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetStatus.
        ''' </summary>
        ''' <param name="DataListItem"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetStatus(ByVal DataListItem As GridViewRowPresenter) As RowStatus
            If DataListItem Is Nothing Then
                'Should not be the case
                Return Nothing
            Else
                Dim objGridRowStatusButton As RowStatus

                objGridRowStatusButton = CType(DataListItem.GetDescendants(Of RowStatus)("btnGridRowStatus").FirstOrDefault(), RowStatus)




                Return objGridRowStatusButton
            End If
        End Function

        ''' --- GetNewRowIndex -----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetNewRowIndex.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetNewRowIndex() As Integer

            Dim intIndexOfButtonName As Integer = -1
            Dim intGridRow As Integer = -1
            Dim intCtlStart As Integer = -1

            If m_intGridButton = DataListButtons.NotSet Then
                Return CurrentRowIndex
            End If

            If IsNothing(ApplicationState.Current.CorePage.PageActionObject) Then
                Return 0
            End If
            If ApplicationState.Current.CorePage.PageActionObject.GetType.ToString = "Core.Windows.UI.Core.Windows.UI.InGridButton" Then

                If m_intGridAction = DataListActionTypes.GridNew Then
                    intGridRow = -1
                Else
                    'intGridRow = ItemContainerGenerator.IndexFromContainer(DirectCast(ApplicationState.Current.CorePage.PageActionObject, GridButton).ParentOfType(Of DataGridRow)())

                    Dim lvi As ListViewItem

                    Dim gvp As GridViewRowPresenter

                    Dim column1 As DependencyObject

                    Dim cellTemplate1 As DataTemplate

                    Dim index As Integer = -1



                    For j As Integer = 0 To Items.Count - 1
                        lvi = TryCast(ItemContainerGenerator.ContainerFromIndex(j), ListViewItem)

                        gvp = FindVisualChild(Of GridViewRowPresenter)(lvi)



                        Dim ctl As InGridButton
                        For Each ctl In gvp.GetDescendants(Of InGridButton)()
                            If ctl.Equals(DirectCast(ApplicationState.Current.CorePage.PageActionObject, InGridButton)) Then
                                Return j

                            End If


                        Next



                    Next

                End If


                ' Row Index (Position) should always be Zero based


            ElseIf ApplicationState.Current.CorePage.PageActionObject.GetType.ToString = "Core.Windows.UI.Core.Windows.UI.GridButton" Then

                If m_intGridAction = DataListActionTypes.GridNew Then
                    intGridRow = -1
                Else
                    'intGridRow = ItemContainerGenerator.IndexFromContainer(DirectCast(ApplicationState.Current.CorePage.PageActionObject, GridButton).ParentOfType(Of DataGridRow)())

                    Dim lvi As ListViewItem

                    Dim gvp As GridViewRowPresenter

                    Dim column1 As DependencyObject

                    Dim cellTemplate1 As DataTemplate

                    Dim index As Integer = -1


                    For j As Integer = 0 To Items.Count - 1
                        lvi = TryCast(ItemContainerGenerator.ContainerFromIndex(j), ListViewItem)

                        gvp = FindVisualChild(Of GridViewRowPresenter)(lvi)
                        column1 = VisualTreeHelper.GetChild(gvp, 0)
                        cellTemplate1 = TryCast(column1, ContentPresenter).ContentTemplate

                        Dim cb As GridButton = TryCast(cellTemplate1.FindName("btnGridRowEdit", DirectCast(column1, FrameworkElement)), GridButton)

                        If cb.Equals(DirectCast(ApplicationState.Current.CorePage.PageActionObject, GridButton)) Then
                            intGridRow = j
                            Exit For

                        End If
                    Next

                End If


                ' Row Index (Position) should always be Zero based
                Return intGridRow
            Else
                Return -1
            End If
        End Function

        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetDeleteRowIndex() As Integer

            Dim intIndexOfButtonName As Integer = -1
            Dim intGridRow As Integer = -1
            Dim intCtlStart As Integer = -1

            If m_intGridButton = DataListButtons.NotSet Then
                Return CurrentRowIndex
            End If



            If ApplicationState.Current.CorePage.PageActionObject.GetType.ToString = "Core.Windows.UI.Core.Windows.UI.GridButton" Then

                If m_intGridAction = DataListActionTypes.GridNew Then
                    intGridRow = -1
                Else
                    'intGridRow = ItemContainerGenerator.IndexFromContainer(DirectCast(ApplicationState.Current.CorePage.PageActionObject, GridButton).ParentOfType(Of DataGridRow)())

                    Dim lvi As ListViewItem

                    Dim gvp As GridViewRowPresenter

                    Dim column1 As DependencyObject

                    Dim cellTemplate1 As DataTemplate

                    Dim index As Integer = -1


                    For j As Integer = 0 To Items.Count - 1
                        lvi = TryCast(ItemContainerGenerator.ContainerFromIndex(j), ListViewItem)

                        gvp = FindVisualChild(Of GridViewRowPresenter)(lvi)
                        column1 = VisualTreeHelper.GetChild(gvp, gvp.Columns.Count - 1)
                        cellTemplate1 = TryCast(column1, ContentPresenter).ContentTemplate

                        Dim cb As GridButton = TryCast(cellTemplate1.FindName("btnGridRowDelete", DirectCast(column1, FrameworkElement)), GridButton)

                        If cb.Equals(DirectCast(ApplicationState.Current.CorePage.PageActionObject, GridButton)) Then
                            intGridRow = j
                            Exit For

                        End If
                    Next

                End If


                ' Row Index (Position) should always be Zero based
                Return intGridRow
            Else
                Return -1
            End If
        End Function

        ''' --- RaiseGridUpdateValidation ------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of RaiseGridUpdateValidation.
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub RaiseGridUpdateValidation(ByVal Sender As DataList, ByVal EventArgs As Object,
                                              Optional ByVal NewRecordPosition As Integer = -1)
            'Sender and EventArgs are passed as By Reference

            RaiseEvent GridUpdateValidation(Sender, EventArgs, NewRecordPosition)

        End Sub

        ''' --- ShowBlankRows ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of ShowBlankRows.
        ''' </summary>
        ''' <param name="NoOfBlankRowsToDisplay"></param>
        ''' <param name="EnableFirstRowForEdit"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub ShowBlankRows(ByVal NoOfBlankRowsToDisplay As Integer, ByVal EnableFirstRowForEdit As Boolean)
            GridDataTable = New DataTable
            With GridDataTable
                .Columns.Add("InternalRowStatus", GetType(Short))
                Dim objDataRow As DataRow
                For i As Integer = 1 To NoOfBlankRowsToDisplay
                    objDataRow = .NewRow
                    objDataRow("InternalRowStatus") = GridRowStatus.NotSet
                    .Rows.Add(objDataRow)
                Next
                objDataRow = Nothing
            End With
            IsGridNew = False

            'If (ApplicationState.Current.CorePage.Mode = PageModeTypes.NoMode) Then
            '    ItemsSource = Nothing
            'Else
            ItemsSource = New DataView(GridDataTable)
            'End If

            DataList1_ItemDataBound()
            m_blnDictionaryLoaded = True
        End Sub

        ''' --- ShowGrid -----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of ShowGrid.
        ''' </summary>
        ''' <param name="NoRecords"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub ShowGrid(ByVal NoRecords As Boolean, ByVal IsLoaded As Boolean)
            Try

                If (IsLoaded) Then
                    If FileObject.RecordCount > 0 Then
                        Exit Sub
                    End If
                End If

                If Not FileObject Is Nothing Then
                    Bind(FileObject, NoRecords)
                ElseIf Not m_objOccursWithCoreBaseType Is Nothing Then
                    'TODO: Yet to be tested
                    Bind(m_objOccursWithCoreBaseType.m_intOccursTimes + 1)
                ElseIf Occurs > 0 Then
                    'TODO: Yet to be tested
                    Bind(Occurs)
                End If
            Catch ex As CustomApplicationException

                Throw ex

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try
        End Sub

        ''' --- Bind ---------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Bind.
        ''' </summary>
        ''' <param name="PassedFileObject"></param>
        ''' <param name="NoRecords"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function Bind(ByVal PassedFileObject As IFileObject, ByVal NoRecords As Boolean)
            Dim objDataRow As DataRow
            Dim intNoOfRowsInGrid As Integer
            Dim intNoOfRowsInitiallyDisplayedInGrid As Integer
            Dim blnHasRecords As Boolean = True
            NoRecordsFound = NoRecords

            If NoRecords OrElse (Not PassedFileObject.HasData) Then
                blnHasRecords = False
                NoRecordsFound = True
            End If

            intNoOfRowsInGrid = PassedFileObject.Occurs

            intNoOfRowsInitiallyDisplayedInGrid = -1
            blnGenerateTable = True
            GridDataTable = New DataTable
            Occurs = intNoOfRowsInGrid

            With GridDataTable
                ApplicationState.Current.CorePage.m_intOccurrence = 0
                .Columns.Add("InternalRowStatus", GetType(Short))

                'Create Empty Rows with Row Status "UnchangedOld"
                If blnHasRecords Then
                    Dim intFileRowCount As Integer = PassedFileObject.UnderlyingDataTable.Rows.Count
                    For intRowNo As Integer = 0 To intFileRowCount - 1
                        If .Rows.Count <= intRowNo AndAlso PassedFileObject.IsOldRecord(intRowNo) Then
                            'Create Empty Row with Row Status "UnchangedOld"
                            objDataRow = .NewRow
                            objDataRow("InternalRowStatus") = GridRowStatus.UnchangedOld
                            .Rows.Add(objDataRow)
                        End If
                    Next
                End If

                intNoOfRowsInitiallyDisplayedInGrid = .Rows.Count
                'Create Empty Rows with Row Status "UnchangedNew"
                If .Rows.Count < intNoOfRowsInGrid Then
                    Dim blnFirstRowEnabledForEdit As Boolean = (intNoOfRowsInitiallyDisplayedInGrid = 0)
                    For i As Integer = (.Rows.Count + 1) To intNoOfRowsInGrid
                        objDataRow = .NewRow
                        'Create Empty Rows with Row Status "UnchangedNew" or "NotSet"
                        If blnFirstRowEnabledForEdit Then
                            objDataRow("InternalRowStatus") = GridRowStatus.NotSet
                        Else
                            objDataRow("InternalRowStatus") = GridRowStatus.UnchangedNew
                            blnFirstRowEnabledForEdit = True
                        End If
                        .Rows.Add(objDataRow)
                    Next
                End If
            End With
            RowsInitiallyDisplayedInGrid = intNoOfRowsInitiallyDisplayedInGrid

            If NoRecords Then
                Me.AllowGridNew = False
            Else
                Me.AllowGridNew =
                    (intNoOfRowsInitiallyDisplayedInGrid = 0 OrElse
                     intNoOfRowsInitiallyDisplayedInGrid = intNoOfRowsInGrid) AndAlso (Not NoAppend) AndAlso
                    Not ApplicationState.Current.CorePage.DisableAppend
            End If

            IsGridNew = False

            'If (ApplicationState.Current.CorePage.Mode = PageModeTypes.NoMode) Then
            '    ItemsSource = Nothing
            'Else
            'ItemsSource = New DataView(GridDataTable)
            'End If
            ItemsSource = GridDataTable.DefaultView

            DataList1_ItemDataBound()

            'Preserve Search Criterian, Bind and Restore Search Criterian
            'PreserveRequestValueAndBind()

            'Move to the first record in file object
            If intNoOfRowsInitiallyDisplayedInGrid Then PassedFileObject.MoveFirst()
            Return Nothing
        End Function

        'PreserveRequestValueAndBind preserves search criterian, Binds grid and restores search criterian
        ''' --- PreserveRequestValueAndBind ----------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of PreserveRequestValueAndBind.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function PreserveRequestValueAndBind()

            'If Grid is being bound for First Time, we
            'don't need to Preserve Request Values, however
            'we still need to Bind Grid
            If Me.Items.Count <= 0 Then
                'Me.DataBind()
                Return Nothing
            End If

            Dim hstRequestValues As Hashtable
            Dim objCtl As Control

            hstRequestValues = New Hashtable
            Dim intTotalControls As Integer
            With Me.Items(0).Controls
                intTotalControls = (.Count - 1)
                For intControlIndex As Integer = 0 To intTotalControls
                    objCtl = .Item(intControlIndex)
                    Select Case objCtl.ToString
                        Case "Core.Windows.UI.Core.Windows.UI.TextBox", "Core.Windows.UI.Core.Windows.UI.DateControl",
                            "Core.Windows.UI.Core.Windows.UI.CheckBox", "Core.Windows.UI.Core.Windows.UI.ComboBox"
                            hstRequestValues(intControlIndex) = CType(objCtl, FieldObjectBase).RequestValue
                    End Select
                Next
            End With

            'Call DataBind of Datalist
            'Note: Calling DataBind should exactly recreate same number of 
            'Field Controls as it was there before calling DataBind and stored in "hstRequestValues"
            'Me.DataBind()
            With Me.Items(0).Controls
                intTotalControls = (.Count - 1)
                For intControlIndex As Integer = 0 To intTotalControls
                    objCtl = .Item(intControlIndex)
                    Select Case objCtl.ToString
                        Case "Core.Windows.UI.Core.Windows.UI.TextBox", "Core.Windows.UI.Core.Windows.UI.DateControl",
                            "Core.Windows.UI.Core.Windows.UI.CheckBox", "Core.Windows.UI.Core.Windows.UI.ComboBox"
                            CType(objCtl, FieldObjectBase).RequestValue = hstRequestValues(intControlIndex)
                    End Select
                Next
            End With

            objCtl = Nothing
            hstRequestValues = Nothing
            Return Nothing
        End Function

        ''' --- Bind ---------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Bind.
        ''' </summary>
        ''' <param name="NoOfRowsToDisplay"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function Bind(ByVal NoOfRowsToDisplay As Integer)
            'TODO: Yet to be tested
            Dim objDataRow As DataRow
            blnGenerateTable = True
            GridDataTable = New DataTable
            Occurs = NoOfRowsToDisplay

            With GridDataTable
                ApplicationState.Current.CorePage.m_intOccurrence = 0
                .Columns.Add("InternalRowStatus", GetType(Short))
                If .Rows.Count < NoOfRowsToDisplay Then
                    For i As Integer = (.Rows.Count + 1) To NoOfRowsToDisplay
                        objDataRow = .NewRow

                        'If grid is bound to one of derived type from CoreBaseType, we are setting UnchangedOld
                        objDataRow("InternalRowStatus") = GridRowStatus.UnchangedOld
                        .Rows.Add(objDataRow)
                    Next
                End If
            End With
            RowsInitiallyDisplayedInGrid = NoOfRowsToDisplay
            'If grid is bound to one of derived type from CoreBaseType, Always disable GridNewButton
            Me.AllowGridNew = False
            IsGridNew = False
            'If (ApplicationState.Current.CorePage.Mode = PageModeTypes.NoMode) Then
            '    ItemsSource = Nothing
            'Else
            ItemsSource = New DataView(GridDataTable)
            'End If
            'DataBind()
            Return Nothing
        End Function

#Region " WireNavigation Events "

        ''' --- WireNavigationEvents -----------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of WireNavigationEvents.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub WireNavigationEvents()
            If Not FileObject Is Nothing Then
                WireNavigationEvents(FileObject)
                Occurs = FileObject.Occurs
            ElseIf Not m_objOccursWithCoreBaseType Is Nothing Then
                WireNavigationEvents(m_objOccursWithCoreBaseType)
                Occurs = m_objOccursWithCoreBaseType.Occurs
            Else
                'TODO: if bound to a Fixed Number
                Dim blnCanAppend As Boolean = False
                Dim blnCanEdit As Boolean = False
                Dim blnCanDelete As Boolean = False
                GetAllowedOperationsInGrid(blnCanAppend, blnCanEdit, blnCanDelete)

                NoAppend = Not blnCanAppend
                NoDelete = Not blnCanDelete
            End If
        End Sub

#Region " Wire Navigation Events to a File Objects "

        ''' --- WireNavigationEvents -----------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of WireNavigationEvents.
        ''' </summary>
        ''' <param name="FileObject"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub WireNavigationEvents(ByVal FileObject As IFileObject)
            Dim blnCanAppend As Boolean = False
            Dim blnCanEdit As Boolean = False
            Dim blnCanDelete As Boolean = False
            GetAllowedOperationsInGrid(FileObject, blnCanAppend, blnCanEdit, blnCanDelete)

            ' Ensure that the Append icon (top of grid) does not
            ' appear when 
            ' - the user presses the DELETE button.
            ' - there is NoMode
            ' - Mode = Find but Navagiation is not Submit (or any of First, Previous, Next, Last buttons)
            ' - Mode = Select but Navagiation is not Submit
            With ApplicationState.Current.CorePage
                If _
                    m_intToolbarAction = ToolbarIcons.Delete OrElse .Mode = PageModeTypes.NoMode OrElse
                    (.Mode = PageModeTypes.Select AndAlso m_intToolbarAction <> ToolbarIcons.Submit) Then
                    blnCanAppend = False
                Else
                    blnCanAppend = True
                End If
            End With

            NoAppend = Not blnCanAppend
            NoDelete = Not blnCanDelete
            WireNavigationEvents(FileObject, True, blnCanAppend, blnCanEdit, blnCanDelete)
        End Sub

        ' This function is used in conjunction with the WireNavigationEvents method.  It is used to 
        ' determine that a record was found and displayed in order to ensure that the Append buttons is 
        ' displayed in the grid.
        ''' --- IsSubmitOrRecordNavigation -----------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of IsSubmitOrRecordNavigation.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function IsSubmitOrRecordNavigation() As Boolean

            Select Case ApplicationState.Current.CorePage.NavigationType
                Case NavigationTypes.Submit, NavigationTypes.First, NavigationTypes.Next, NavigationTypes.Last,
                    NavigationTypes.Previous
                    Return True
                Case Else
                    Return False
            End Select

        End Function

        ''' --- WireNavigationEvents -----------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of WireNavigationEvents.
        ''' </summary>
        ''' <param name="FileObject"></param>
        ''' <param name="WireNavigationEvents"></param>
        ''' <param name="WireAddEvent"></param>
        ''' <param name="WireEditEvent"></param>
        ''' <param name="WireDeleteEvent"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub WireNavigationEvents(ByVal FileObject As IFileObject, ByVal WireNavigationEvents As Boolean,
                                         ByVal WireAddEvent As Boolean, ByVal WireEditEvent As Boolean,
                                         ByVal WireDeleteEvent As Boolean)
            If WireAddEvent Then
                AddHandler Me.AppendRecordEvent, AddressOf FileObject.AddRecord
            End If

            If WireNavigationEvents Then
                AddHandler Me.GoToRecordEvent, AddressOf FileObject.GoToRecord
            End If

            If WireEditEvent Then
                AddHandler Me.EditRecordEvent, AddressOf FileObject.EditRecord
            End If

            If WireDeleteEvent Then
                AddHandler Me.DeleteRecordEvent, AddressOf FileObject.DeleteRecord
            End If
        End Sub

        ''' --- GetAllowedOperationsInGrid -----------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetAllowedOperationsInGrid.
        ''' </summary>
        ''' <param name="FileObject"></param>
        ''' <param name="CanAppend"></param>
        ''' <param name="CanEdit"></param>
        ''' <param name="CanDelete"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub GetAllowedOperationsInGrid(ByVal FileObject As IFileObject, ByRef CanAppend As Boolean,
                                                ByRef CanEdit As Boolean, ByRef CanDelete As Boolean)

            With ApplicationState.Current.CorePage
                ' CanAppend will be true unless DisableAppendFromEntry is false.  If DisableAppend is true, then this only disables the Append during Change/Correct mode.
                CanAppend =
                    (.ChangeActivity OrElse
                     (.EntryActivity AndAlso
                      (Me.m_intToolbarAction = ToolbarIcons.Add OrElse .Mode = PageModeTypes.Entry OrElse
                       .Mode = PageModeTypes.Correct))) AndAlso Not FileObject.NoAppend AndAlso
                    Not .DisableAppendFromEntry

                CanEdit = .ChangeActivity

                CanDelete = .DeleteActivity AndAlso Not FileObject.NoDelete AndAlso Not DisableDetailDelete

                If _
                    Not DisableDetailDelete AndAlso Not CanDelete AndAlso
                    (ApplicationState.Current.CorePage.Mode = PageModeTypes.Entry OrElse ApplicationState.Current.CorePage.Mode = PageModeTypes.Correct) Then
                    CanDelete = True
                End If
            End With
        End Sub

        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub GetAllowedOperationsInGrid(ByRef CanAppend As Boolean, ByRef CanEdit As Boolean,
                                                ByRef CanDelete As Boolean)

            With ApplicationState.Current.CorePage
                ' CanAppend will be true unless DisableAppendFromEntry is false.  If DisableAppend is true, then this only disables the Append during Change/Correct mode.
                CanAppend =
                    (.ChangeActivity OrElse
                     (.EntryActivity AndAlso
                      (Me.m_intToolbarAction = ToolbarIcons.Add OrElse .Mode = PageModeTypes.Entry OrElse
                       .Mode = PageModeTypes.Correct))) AndAlso Not .DisableAppendFromEntry

                CanEdit = .ChangeActivity

                CanDelete = .DeleteActivity AndAlso Not DisableDetailDelete

            End With
        End Sub

        ''' --- GetControlId -------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetControlId.
        ''' </summary>
        ''' <param name="Push"></param>
        ''' <param name="ControlId"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub GetControlId(ByVal Push As String, ByRef ControlId As String)

            Select Case Push
                Case PushTypes.Append.ToString
                    ControlId = AppendID
                Case PushTypes.NextData.ToString
                    If GetTotalPages(ApplicationState.Current.CorePage.TotalGridRecords) > ApplicationState.Current.CorePage.CurrentPageNumber Then
                        ControlId = Me.Name + "$ctl0:lnk" + (ApplicationState.Current.CorePage.CurrentPageNumber + 1).ToString
                    End If
                Case PushTypes.PreviousData.ToString
                    If ApplicationState.Current.CorePage.CurrentPageNumber > 1 Then
                        ControlId = Me.Name + "$ctl0:lnk" + (ApplicationState.Current.CorePage.CurrentPageNumber - 1).ToString
                    End If
            End Select

        End Sub

#End Region

#Region " Wire Navigation Events to one of derived type of CoreBaseType "

        ''' --- WireNavigationEvents -----------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of WireNavigationEvents.
        ''' </summary>
        ''' <param name="CoreBaseType"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub WireNavigationEvents(ByVal CoreBaseType As CoreBaseType)
            Dim blnCanAppend As Boolean = False
            Dim blnCanEdit As Boolean = False
            Dim blnCanDelete As Boolean = False
            GetAllowedOperationsInGrid(CoreBaseType, blnCanAppend, blnCanEdit, blnCanDelete)

            NoAppend = Not blnCanAppend
            NoDelete = Not blnCanDelete
            WireNavigationEvents(CoreBaseType, True, blnCanAppend, blnCanEdit, blnCanDelete)
        End Sub


        ''' --- WireNavigationEvents -----------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of WireNavigationEvents.
        ''' </summary>
        ''' <param name="CoreBaseType"></param>
        ''' <param name="WireNavigationEvents"></param>
        ''' <param name="WireAddEvent"></param>
        ''' <param name="WireEditEvent"></param>
        ''' <param name="WireDeleteEvent"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub WireNavigationEvents(ByVal CoreBaseType As CoreBaseType, ByVal WireNavigationEvents As Boolean,
                                         ByVal WireAddEvent As Boolean, ByVal WireEditEvent As Boolean,
                                         ByVal WireDeleteEvent As Boolean)
            If WireNavigationEvents Then
                AddHandler Me.GoToRecordEvent, AddressOf CoreBaseType.GoToRecord
            End If
        End Sub

        ''' --- GetAllowedOperationsInGrid -----------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetAllowedOperationsInGrid.
        ''' </summary>
        ''' <param name="CoreBaseType"></param>
        ''' <param name="CanAppend"></param>
        ''' <param name="CanEdit"></param>
        ''' <param name="CanDelete"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub GetAllowedOperationsInGrid(ByVal CoreBaseType As CoreBaseType, ByRef CanAppend As Boolean,
                                                ByRef CanEdit As Boolean, ByRef CanDelete As Boolean)
            'TODO: We need to develop precise logic
            With ApplicationState.Current.CorePage
                CanAppend = False
                'Append is not allowed, if Grid is bound to a temporary Variable

                CanEdit = .ChangeActivity

                'By default legacy app removes all records, however at present
                'Delete is disabled in .Net App, if grid is bound to one of the type derived
                'from CoreBaseType
                CanDelete = False
                'Delete is not allowed
            End With
        End Sub

#End Region

#End Region

        ''' --- RaiseGotoRecord ----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of RaiseGotoRecord.
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub RaiseGotoRecord(ByVal Sender As Object, ByVal EventArgs As Object,
                                    Optional ByVal NewRecordPosition As Integer = -1)

            RaiseEvent GoToRecordEvent(Sender, EventArgs, NewRecordPosition)

        End Sub

        ''' --- RaiseAppendRecord --------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of RaiseAppendRecord.
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub RaiseAppendRecord(ByVal Sender As Object, ByVal EventArgs As Object,
                                      Optional ByVal NewRecordPosition As Integer = -1,
                                      Optional ByVal IsGridNew As Boolean = False)

            RaiseEvent AppendRecordEvent(Sender, EventArgs, NewRecordPosition, IsGridNew)

        End Sub

        ''' --- RaiseEditRecord ----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of RaiseEditRecord.
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub RaiseEditRecord(ByVal Sender As Object, ByVal EventArgs As Object,
                                    Optional ByVal NewRecordPosition As Integer = -1)

            RaiseEvent EditRecordEvent(Sender, EventArgs, NewRecordPosition)

        End Sub

        ''' --- RaiseDeleteRecord --------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of RaiseDeleteRecord.
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub RaiseDeleteRecord(ByVal Sender As Object, ByVal EventArgs As Object,
                                      Optional ByVal NewRecordPosition As Integer = -1)

            RaiseEvent DeleteRecordEvent(Sender, EventArgs, NewRecordPosition)

        End Sub

        ''' --- SetRowStatus -------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of SetRowStatus.
        ''' </summary>
        ''' <param name="NewRowStatus"></param>
        ''' <param name="PreviousStatus"></param>
        ''' <param name="RowIndex"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub SetRowStatus(ByVal NewRowStatus As GridRowStatus,
                                 Optional ByVal PreviousStatus As GridRowStatus = GridRowStatus.AsItIs,
                                 Optional ByVal RowIndex As Integer = -1)
            ' Unless RowIndex is specified, this function uses 
            ' m_intNewRowIndex instead of CurrentRowIndex 
            ' This function can be used to manually update the Row Status in Grid from
            ' designer procedures or from BeforeClick or Click event handlers
            '
            ' This function should ONLY be called from Click or BeforeClick 
            ' events of GridButton or Designer controls
            '
            If RowIndex = -1 Then RowIndex = m_intNewRowIndex
            If RowIndex >= 0 Then
                Dim objDataListItem As GridViewRowPresenter
                Dim objGridRowStatus As RowStatus
                objDataListItem = GetDataListItem(RowIndex)
                objGridRowStatus = GetStatus(objDataListItem)
                With objGridRowStatus
                    ' If we are editing a row which was already edited, don't set the new row status.  This 
                    ' ensures that if an error occurs during processing, that we don't have the status return
                    ' to the unchanged icon.
                    If NewRowStatus = GridRowStatus.Editing AndAlso .CurrentStatus = GridRowStatus.Edited Then
                        ' Do nothing.
                    Else
                        .CurrentStatus = NewRowStatus
                        If PreviousStatus <> GridRowStatus.AsItIs Then .PreviousStatus = PreviousStatus
                    End If
                End With
                objDataListItem = Nothing
                objGridRowStatus = Nothing
            End If
        End Sub

        ' **** Sub AddDesigner
        ' Adds DesignerName into for a Row specified by RowPosition
        ' Which will be executed in ProcessGrid
        ''' --- AddDesigner --------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of AddDesigner.
        ''' </summary>
        ''' <param name="DesignerName"></param>
        ''' <param name="DataListItem"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub AddDesigner(ByVal DesignerName As String, ByVal DataListItem As GridViewRowPresenter)
            Dim strDesignerNames As String
            Dim astrFieldName As String()
            Dim objAnyCase As New CaseInsensitiveComparer
            Dim objGridRowStatus As RowStatus
            Dim intItemIndex As Integer

            objGridRowStatus = GetStatus(DataListItem)
            'intItemIndex = ItemContainerGenerator.IndexFromContainer(DataListItem)
            intItemIndex = GetRowIndex(Me, DataListItem)
            strDesignerNames = objGridRowStatus.Designers
            astrFieldName = strDesignerNames.Split(";")
            ' If not already added... 
            If Array.BinarySearch(astrFieldName, DesignerName, objAnyCase) < 0 Then
                Dim strSeparator As String
                If strDesignerNames.Trim = String.Empty Then
                    strSeparator = String.Empty
                Else
                    strSeparator = ";"
                End If
                ' Add DesignerName for the row
                objGridRowStatus.Designers = strDesignerNames + strSeparator + DesignerName
            End If
            objAnyCase = Nothing
            objGridRowStatus = Nothing
        End Sub

#End Region

#Region " Private Helper Methods "



        ' PositionRowFireEventsForAcceptProcessing method positions the Current Row Position 
        ' of the DataList control and if required fire event corresponding to user's action
        ''' --- PositionRowFireEventsForAcceptProcessing ---------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of PositionRowFireEventsForAcceptProcessing.
        ''' </summary>
        ''' <param name="CallMainSaveState"></param>
        ''' <param name="CallInFieldSaveState"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub PositionRowFireEventsForAcceptProcessing(ByRef CallMainSaveState As Boolean,
                                                              ByRef CallInFieldSaveState As Boolean)
            Dim intMode As PageModeTypes
            Dim objDataListItem As GridViewRowPresenter
            Dim i As Integer = 0
            Dim objDesigner As Designer = Nothing
            Dim objPageActionObject As Object
            Dim blnButtonchecked As Boolean = False
            Dim objRowStatus As RowStatus

            ' Determine which Grid Control caused the post back
            m_intGridAction = GetGridAction()
            ApplicationState.Current.CorePage.GridActionType = m_intGridAction
            m_intToolbarAction = ApplicationState.Current.CorePage.ToolbarAction()

            With ApplicationState.Current.CorePage
                intMode = .Mode

                m_blnBindGridEvents = True
                'By default bind grid events
                m_blnImmediateTerminateFromFirstNew = .m_blnImmediateTerminateAppend AndAlso .IsAppend
                ' ((m_intGridAction = DataListActionTypes.GridNew OrElse Me.m_intToolbarAction = ToolbarIcons.Add) AndAlso .m_blnImmediateTerminateAppend)


                If ApplicationState.Current.CorePage.Mode = PageModeTypes.Entry AndAlso ApplicationState.Current.CorePage.IsFunctionKey AndAlso .IsAppend Then
                    If CurrentRowIndex < 1 Then
                        m_intToolbarAction = ToolbarIcons.Add
                    Else
                        m_intGridAction = DataListActionTypes.Update
                        CallInFieldSaveState = True
                    End If
                End If

                Select Case m_intToolbarAction
                    Case ToolbarIcons.Add
                        CurrentRowIndex = 0
                        PreviousRowIndex = 0

                    Case ToolbarIcons.Delete
                        'DeleteAll should be called from Derived Page's Delete procedure

                        Me.ReadOnly()

                        m_blnBindGridEvents = False

                    Case ToolbarIcons.Find
                        If (.HasPathRequestFields) Then
                            If ApplicationState.Current.CorePage.ScreenType = ScreenTypes.Grid Then
                                CurrentRowIndex = 0
                            End If

                            If ApplicationState.Current.CorePage.IsRequest = False Then
                                ShowBlankRows(Occurs, False)
                            End If
                            BindGridFieldsEvents(0, False)
                            m_blnBindGridEvents = False
                            'Use Default m_blnBindGridEvents which is set to True
                        Else
                            CurrentRowIndex = -1
                            m_blnBindGridEvents = False
                        End If
                    Case ToolbarIcons.Submit
                        If ApplicationState.Current.CorePage.FindMode Then
                            BindGridFieldsEvents(0, False)
                        End If
                        CurrentRowIndex = -1
                        m_blnBindGridEvents = False

                    Case ToolbarIcons.Cancel
                        CurrentRowIndex = -1
                        m_blnBindGridEvents = False

                    Case ToolbarIcons.First, ToolbarIcons.Previous, ToolbarIcons.Next, ToolbarIcons.Last
                        BindGridFieldsEvents(0, False)
                        m_blnBindGridEvents = False
                        CurrentRowIndex = -1

                    Case Else 'Required for InFieldValidation 
                        If ApplicationState.Current.CorePage.AllowAcceptInDetailPostFind = True AndAlso ApplicationState.Current.CorePage.IsFunctionKey _
                            Then
                            If (.HasPathRequestFields) Then
                                If ApplicationState.Current.CorePage.ScreenType = ScreenTypes.Grid Then
                                    CurrentRowIndex = 0
                                End If

                                If ApplicationState.Current.CorePage.IsRequest = False Then
                                    ShowBlankRows(Occurs, False)
                                End If
                                BindGridFieldsEvents(0, False)
                                m_blnBindGridEvents = False
                                'Use Default m_blnBindGridEvents which is set to True
                            Else
                                CurrentRowIndex = -1
                                m_blnBindGridEvents = False
                            End If
                        Else
                            Select Case .PageActionType
                                Case PageActionType.NotSet
                                    'Assuming InFieldValidation
                                    If _
                                        .Mode = PageModeTypes.NoMode OrElse
                                        ((.Mode = PageModeTypes.Entry) OrElse
                                         (.Mode = PageModeTypes.Find OrElse .ToolbarAction = ToolbarIcons.Find) AndAlso
                                         (.HasPathRequestFields)) Then
                                        If _
                                            (.Mode = PageModeTypes.Entry) OrElse
                                            ((.Mode = PageModeTypes.Find OrElse .ToolbarAction = ToolbarIcons.Find) AndAlso
                                             .HasPathRequestFields) Then
                                            'If we open screen in Find mode and if screen has PathRequestFields
                                            'Enable First Row to enter Search Criteria
                                            CurrentRowIndex = 0
                                        End If
                                        m_intNewRowIndex = 0

                                        If ApplicationState.Current.CorePage.IsRequest = False Then
                                            ShowBlankRows(Occurs, False)
                                        End If
                                        If (Not ItemsSource Is Nothing) Then
                                            BindGridFieldsEvents(m_intNewRowIndex, False)
                                        End If

                                        m_blnBindGridEvents = False
                                    End If

                                    If .Mode = PageModeTypes.Entry AndAlso m_intToolbarAction = ToolbarIcons.NotSet Then
                                        'Incase Page is opened in Entry Mode, set ToolbarAction to Add
                                        m_intToolbarAction = ToolbarIcons.Add
                                    End If
                                Case PageActionType.InFieldValidation
                                    CallMainSaveState = False
                                Case PageActionType.DataListButtonClick
                                    m_intNewRowIndex = GetNewRowIndex()

                                    'At the time when responding to Base Page's event we DON'T have to Call SaveState or SaveState with InField = True
                                    CallMainSaveState = False
                                    CallInFieldSaveState = False
                                    'EditCommand should call SaveState with Infield = True

                                    If Not ApplicationState.Current.CorePage.EnableNumberedDesigners AndAlso PreviousRowIndex <> m_intNewRowIndex _
                                        Then
                                        If PreviousRowIndex = -1 Then PreviousRowIndex = 0
                                        ApplicationState.Current.CorePage.EventArgument = "SKIPALL"
                                        BindGridFieldsEvents(PreviousRowIndex, False)
                                        ProcessEditClickForAcceptProcessing(PreviousRowIndex)
                                        objDataListItem = GetDataListItem(PreviousRowIndex)
                                        objRowStatus =
                                            CType(objDataListItem.GetDescendants(Of RowStatus)("btnGridRowStatus").FirstOrDefault(), RowStatus)
                                        Select Case objRowStatus.CurrentStatus()
                                            Case GridRowStatus.Adding
                                                SetRowStatus(GridRowStatus.Added, GridRowStatus.Added, PreviousRowIndex)
                                                SetRowStatus(GridRowStatus.Adding, GridRowStatus.Adding,
                                                              m_intNewRowIndex)
                                            Case GridRowStatus.Editing
                                                SetRowStatus(GridRowStatus.Edited, GridRowStatus.Edited,
                                                              PreviousRowIndex)
                                        End Select
                                        If _
                                            objRowStatus.CurrentStatus = GridRowStatus.Edited OrElse
                                            objRowStatus.CurrentStatus = GridRowStatus.Added Then
                                            ' Ensure state is saved if the user modified/added a row and then clicked the edit/add 
                                            ' button for another row without finishing the Edit/Append.
                                            ApplicationState.Current.CorePage.RemoveFlags(True)
                                        Else
                                            ApplicationState.Current.CorePage.RemoveFlags()
                                        End If
                                        ApplicationState.Current.CorePage.EventArgument = ""
                                    End If

                                    PreviousRowIndex = m_intNewRowIndex

                                    If m_intNewRowIndex >= 0 Then
                                        BindGridFieldsEvents(m_intNewRowIndex, False)
                                        m_blnBindGridEvents = False
                                    End If

                                    ApplicationState.Current.CorePage.EnableNumberedDesigners = False

                                    Select Case m_intGridAction
                                        Case DataListActionTypes.Delete
                                            m_intNewRowIndex = GetDeleteRowIndex()
                                            ApplicationState.Current.CorePage.SetOccurrence(m_intNewRowIndex)
                                            CurrentRowIndex = -1
                                            ProcessDeleteClick(m_intNewRowIndex)
                                        Case DataListActionTypes.Add, DataListActionTypes.Update
                                            Dim _
                                                strStatus As String =
                                                    GetStatus(GetDataListItem(m_intNewRowIndex)).CurrentStatus.
                                                    ToString
                                            ' Only set the IsAppendFromGrid when adding new records.
                                            If strStatus.IndexOf("Add") > -1 OrElse strStatus.IndexOf("New") > -1 _
                                                Then
                                                ApplicationState.Current.CorePage.IsAppendFromGrid = True
                                            End If
                                            'Use the CurrentRowIndex set by CheckForNewIndex function
                                            ProcessEditClickForAcceptProcessing(m_intNewRowIndex)
                                        Case DataListActionTypes.GridNew
                                            'Set position to First Row
                                            m_intNewRowIndex = 0

                                            m_blnBindGridEvents = True
                                            ApplicationState.Current.CorePage.IsAppendFromGrid = True
                                            ProcessEditClickForAcceptProcessing(m_intNewRowIndex)

                                            Me.AllowGridNew = False

                                            'To store any changes made in event handlers for the events raised from Edit_Command calling SaveState 
                                            CallInFieldSaveState = True
                                        Case Else
                                            ' Unless otherwise changed later, Should not be the case 
                                            If ApplicationState.Current.CorePage.IsFunctionKey Then
                                                Dim _
                                                    strStatus As String =
                                                        GetStatus(GetDataListItem(m_intNewRowIndex)).CurrentStatus.
                                                        ToString
                                                ' Only set the IsAppendFromGrid when adding new records.
                                                If _
                                                    strStatus.IndexOf("Add") > -1 OrElse
                                                    strStatus.IndexOf("New") > -1 Then
                                                    ApplicationState.Current.CorePage.IsAppendFromGrid = True
                                                End If
                                                'Use the CurrentRowIndex set by CheckForNewIndex function
                                                ProcessEditClickForAcceptProcessing(m_intNewRowIndex)
                                            End If
                                    End Select

                                Case PageActionType.DesignerClick
                                    ApplicationState.Current.CorePage.EnableNumberedDesigners = False

                                    objPageActionObject = ApplicationState.Current.CorePage.PageActionObject
                                    If objPageActionObject Is Nothing Then
                                        objDesigner = ApplicationState.Current.CorePage.CurrentDesigner
                                    ElseIf TypeOf objPageActionObject Is Designer Then
                                        objDesigner = CType(objPageActionObject, Designer)
                                    End If

                                    'If ApplicationState.Current.CorePage.Request("__EventTarget") = "btnGridRowEdit" Then

                                    '    m_intNewRowIndex = GetNewRowIndex()

                                    '    'At the time when responding to Base Page's event we DON'T have to Call SaveState or SaveState with InField = True
                                    '    CallMainSaveState = False
                                    '    CallInFieldSaveState = False
                                    '    'EditCommand should call SaveState with Infield = True

                                    '    If m_intNewRowIndex >= 0 Then
                                    '        BindGridFieldsEvents(m_intNewRowIndex, False)
                                    '        m_blnBindGridEvents = False
                                    '    End If

                                    '    Select Case m_intGridAction
                                    '        Case DataListActionTypes.Delete
                                    '            CurrentRowIndex = -1
                                    '            ProcessDeleteClick(m_intNewRowIndex)
                                    '        Case DataListActionTypes.Add, DataListActionTypes.Update
                                    '            'Use the CurrentRowIndex set by CheckForNewIndex function
                                    '            ProcessEditClickForAcceptProcessing(m_intNewRowIndex)
                                    '        Case DataListActionTypes.GridNew
                                    '            'Set position to First Row
                                    '            m_intNewRowIndex = 0
                                    '            m_blnBindGridEvents = False
                                    '            ProcessEditClickForAcceptProcessing(m_intNewRowIndex)

                                    '            Me.AllowGridNew = False

                                    '            'To store any changes made in event handlers for the events raised from Edit_Command calling SaveState 
                                    '            CallInFieldSaveState = True
                                    '        Case Else
                                    '            ' Unless otherwise changed later, Should not be the case 
                                    '    End Select

                                    'ElseIf _
                                    If _
                                        Not AllowSelectRowButton AndAlso
                                        Not _
                                        (objDesigner.HasAcceptInGrid OrElse
                                         (Me.m_blnUsingAcceptProcessing AndAlso objDesigner.DefaultFirstRowInGrid)) Then
                                        'Disable the grid
                                        Me.ReadOnly()
                                    Else

                                        ApplicationState.Current.CorePage.EnableNumberedDesigners = False
                                        If Not IsNothing(objDesigner) AndAlso objDesigner.AcceptVerbList = "" Then

                                            For intItemRowIndex As Integer = 0 To (Items.Count - 1) _
                                                'Loop through each row in a grid
                                                objDataListItem = GetDataListItem(intItemRowIndex)

                                                Dim objRadioButton As RadioButton = objDataListItem.GetDescendants(Of Control)("btnGridRowSelect").FirstOrDefault

                                                If Not IsNothing(objRadioButton) AndAlso objRadioButton.IsEnabled = True AndAlso objRadioButton.IsChecked = True Then


                                                    blnButtonchecked = True
                                                    m_objDesigner = .CurrentDesigner

                                                    'm_blnDesignerMode = .DesignerMode
                                                    m_intNewRowIndex = i
                                                    m_intSelectedRecord = i
                                                    objDataListItem = GetDataListItem(i)
                                                    BindGridFieldsEvents(i, False)
                                                    m_blnBindGridEvents = False
                                                    RaiseDesignerEvents(objDataListItem, False)
                                                    'GetCheckBox(Me.Items(i)).Checked = False
                                                    'If ApplicationState.Current.CorePage.IsFlickerFree Then
                                                    '    ApplicationState.Current.CorePage.ReplaceContent( _
                                                    '                             GetCheckBox(Me.Items(i)).Name _
                                                    '                                .Replace("$", "_"))
                                                    'End If
                                                    ApplicationState.Current.CorePage.PageActionType = PageActionType.NotSet
                                                    ApplicationState.Current.CorePage.RemoveFlags(True)
                                                    ' Save state for the row we completed.

                                                    objRadioButton.IsChecked = False

                                                End If
                                                i = i + 1
                                                'If IsItem(objDataListItem.ItemType) Then
                                                '    i = objDataListItem.ItemIndex
                                                '    'EditItemIndex should always be zero based
                                                '    Dim blnGridRowCheckValue As Boolean
                                                '    'blnGridRowCheckValue = GetCheckBox(Me.Items(i)).Checked AndAlso _
                                                '    '                       GetCheckBox(Me.Items(i)).Enabled
                                                '    If blnGridRowCheckValue = True Then
                                                '        blnButtonchecked = True
                                                '        m_objDesigner = .CurrentDesigner
                                                '        m_triKeepEditButtonEnabledAfterDesigner = _
                                                '            m_objDesigner.KeepEditButtonEnabledInGrid
                                                '        m_triKeepDeleteButtonEnabledAfterDesigner = _
                                                '            m_objDesigner.KeepDeleteButtonEnabledInGrid
                                                '        'm_blnDesignerMode = .DesignerMode
                                                '        m_intNewRowIndex = i
                                                '        m_intSelectedRecord = i
                                                '        objDataListItem = GetDataListItem(i)
                                                '        BindGridFieldsEvents(i, False)
                                                '        m_blnBindGridEvents = False
                                                '        RaiseDesignerEvents(objDataListItem, False)
                                                '        'GetCheckBox(Me.Items(i)).Checked = False
                                                '        'If ApplicationState.Current.CorePage.IsFlickerFree Then
                                                '        '    ApplicationState.Current.CorePage.ReplaceContent( _
                                                '        '                             GetCheckBox(Me.Items(i)).Name _
                                                '        '                                .Replace("$", "_"))
                                                '        'End If
                                                '        ApplicationState.Current.CorePage.PageActionType = PageActionType.NotSet
                                                '        ApplicationState.Current.CorePage.RemoveFlags(True)
                                                '        ' Save state for the row we completed.
                                                '    End If
                                                'End If
                                            Next

                                            If blnButtonchecked Then
                                                .SetOccurrence(0)
                                            Else
                                                i = 0
                                                m_objDesigner = .CurrentDesigner
                                                If m_objDesigner Is Nothing Then
                                                    m_objDesigner = objDesigner
                                                End If
                                                m_triKeepEditButtonEnabledAfterDesigner =
                                                    m_objDesigner.KeepEditButtonEnabledInGrid
                                                m_triKeepDeleteButtonEnabledAfterDesigner =
                                                    m_objDesigner.KeepDeleteButtonEnabledInGrid
                                                'm_blnDesignerMode = .DesignerMode
                                                m_intNewRowIndex = i
                                                objDataListItem = GetDataListItem(i)
                                                BindGridFieldsEvents(i, False)
                                                m_blnBindGridEvents = False
                                                RaiseDesignerEvents(objDataListItem, False)
                                                ApplicationState.Current.CorePage.PageActionType = PageActionType.NotSet
                                            End If
                                        Else
                                            For intItemRowIndex As Integer = 0 To (Me.Items.Count - 1) _
                                                'Loop through each row in a grid
                                                objDataListItem = Me.Items(intItemRowIndex)
                                                'If IsItem(objDataListItem.ItemType) Then
                                                '    i = intItemRowIndex
                                                '    'EditItemIndex should always be zero based
                                                '    Dim blnGridRowCheckValue As Boolean
                                                '    'blnGridRowCheckValue = _
                                                '    '    GetCheckBox(Me.Items(intItemRowIndex)).Checked

                                                '    If blnGridRowCheckValue = True Then
                                                '        m_blnAllowEditButton = False
                                                '        'change to the record when looping
                                                '        If m_intSelectedRecord = -1 Then
                                                '            m_intSelectedRecord = i
                                                '        ElseIf m_intNextRecord = -1 Then
                                                '            m_intNextRecord = i
                                                '        End If
                                                '    End If

                                                'End If
                                            Next

                                            If m_intSelectedRecord = -1 Then m_intSelectedRecord = 0

                                            'We created a copy of CurrentDesigner Object and its one of property so 
                                            'that later, in loop we don't have to refer ApplicationState.Current.CorePage and CurrentDesigner 
                                            'while processing each row in a grid
                                            m_objDesigner = .CurrentDesigner
                                            m_triKeepEditButtonEnabledAfterDesigner =
                                                m_objDesigner.KeepEditButtonEnabledInGrid
                                            m_triKeepDeleteButtonEnabledAfterDesigner =
                                                m_objDesigner.KeepDeleteButtonEnabledInGrid
                                            'm_blnDesignerMode = .DesignerMode

                                            If m_intSelectedRecord >= 0 Then
                                                m_intNewRowIndex = m_intSelectedRecord
                                                objDataListItem = GetDataListItem(m_intSelectedRecord)
                                                BindGridFieldsEvents(m_intSelectedRecord, False)
                                                m_blnBindGridEvents = False
                                                RaiseDesignerEvents(objDataListItem, False)
                                                SetRowStatus(GridRowStatus.Edited, GridRowStatus.Edited,
                                                              m_intSelectedRecord)
                                                ApplicationState.Current.CorePage.PageActionType = PageActionType.NotSet
                                            Else
                                                'Although row is not selected bind grid fields to the first row,
                                                'however here we are not enabling the first row in Grid
                                                'This will ensure that derived page, Grid Fields can work
                                                'with the first row/occurrence
                                                BindGridFieldsEvents(0, False)
                                                m_blnBindGridEvents = False
                                            End If

                                            'At the time when responding to Base Page's event we DON'T have to Call SaveState however, we have to call SaveState with InField = True
                                            CallMainSaveState = False
                                            'To store any changes made in event handlers for for events raised in RaiseDesignerEvents
                                            CallInFieldSaveState = True

                                        End If
                                    End If
                            End Select
                        End If

                End Select
                'ApplicationState.Current.CorePage.RegisterHiddenFields("AppendNewRow", m_intNewRowIndex + 1)
                If m_intNextRecord < 0 Then
                    m_blnAllowEditButton = True
                    ApplicationState.Current.CorePage.EnableNumberedDesigners = True
                End If
                objDataListItem = Nothing
            End With
        End Sub

        'PositionRowFireEvents method positions the Current Row Position of the DataList control and
        'if required fire event corresponding to user's action
        ''' --- PositionRowFireEvents ----------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of PositionRowFireEvents.
        ''' </summary>
        ''' <param name="CallMainSaveState"></param>
        ''' <param name="CallInFieldSaveState"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub PositionRowFireEvents(ByRef CallMainSaveState As Boolean, ByRef CallInFieldSaveState As Boolean)
            Dim intMode As PageModeTypes
            Dim objDataListItem As GridViewRowPresenter

            ' Determine which Grid Control caused the post back
            m_intGridAction = GetGridAction()
            ApplicationState.Current.CorePage.GridActionType = m_intGridAction
            m_intToolbarAction = ApplicationState.Current.CorePage.ToolbarAction()

            With ApplicationState.Current.CorePage
                intMode = .Mode
                'm_blnDesignerMode = .DesignerMode

                m_blnBindGridEvents = True
                'By default bind grid events

                Select Case m_intToolbarAction
                    Case ToolbarIcons.Add
                        CurrentRowIndex = 0

                    Case ToolbarIcons.Delete
                        'DeleteAll should be called from Derived Page's Delete procedure

                        Me.ReadOnly()
                        m_blnBindGridEvents = False

                    Case ToolbarIcons.Find
                        If .HasPathRequestFields Then
                            CurrentRowIndex = 0
                            ShowBlankRows(Occurs, False)
                            If m_intNewRowIndex >= 0 Then
                                BindGridFieldsEvents(0, False)
                                m_blnBindGridEvents = False
                            End If
                            'Use Default m_blnBindGridEvents which is set to True
                        Else
                            CurrentRowIndex = -1
                            m_blnBindGridEvents = False
                        End If
                    Case ToolbarIcons.Submit
                        If ApplicationState.Current.CorePage.FindMode Then
                            BindGridFieldsEvents(0, False)
                        End If
                        CurrentRowIndex = -1
                        m_blnBindGridEvents = False

                    Case ToolbarIcons.Cancel
                        CurrentRowIndex = -1
                        m_blnBindGridEvents = False

                    Case ToolbarIcons.First, ToolbarIcons.Previous, ToolbarIcons.Next, ToolbarIcons.Last
                        BindGridFieldsEvents(0, False)
                        CurrentRowIndex = -1

                    Case Else 'Required for InFieldValidation 
                        Select Case .PageActionType
                            Case PageActionType.NotSet
                                'Assuming InFieldValidation
                                'CurrentRowIndex = CurrentRowIndex
                                If _
                                    .Mode = PageModeTypes.NoMode OrElse
                                    (.Mode = PageModeTypes.Find OrElse .ToolbarAction = ToolbarIcons.Find) AndAlso
                                    (.HasPathRequestFields) _
                                    Then
                                    If _
                                        (.Mode = PageModeTypes.Find OrElse .ToolbarAction = ToolbarIcons.Find) AndAlso
                                        .HasPathRequestFields Then
                                        'If we open screen in Find mode and if screen has PathRequestFields
                                        'Enable First Row to enter Search Criteria
                                        CurrentRowIndex = 0
                                    End If
                                    m_intNewRowIndex = 0

                                    ShowBlankRows(Occurs, False)
                                    BindGridFieldsEvents(m_intNewRowIndex, False)
                                    m_blnBindGridEvents = False
                                End If
                            Case PageActionType.InFieldValidation
                                CallMainSaveState = False
                            Case PageActionType.DataListButtonClick
                                m_intNewRowIndex = GetNewRowIndex()

                                'At the time when responding to Base Page's event we DON'T have to Call SaveState or SaveState with InField = True
                                CallMainSaveState = False
                                CallInFieldSaveState = False
                                'EditCommand should call SaveState with Infield = True

                                If m_intNewRowIndex >= 0 Then
                                    BindGridFieldsEvents(m_intNewRowIndex, False)
                                    m_blnBindGridEvents = False
                                    CallMainSaveState = True
                                    CallInFieldSaveState = True
                                End If

                                Select Case m_intGridAction
                                    Case DataListActionTypes.Delete
                                        CurrentRowIndex = -1
                                        ProcessDeleteClick(m_intNewRowIndex)
                                    Case DataListActionTypes.Add, DataListActionTypes.Update
                                        'Use the CurrentRowIndex set by CheckForNewIndex function
                                        ProcessEditClick(m_intNewRowIndex)
                                    Case DataListActionTypes.GridNew
                                        'Set position to First Row
                                        m_intNewRowIndex = 0
                                        m_blnBindGridEvents = False
                                        ProcessEditClick(m_intNewRowIndex)

                                        Me.AllowGridNew = False

                                        'To store any changes made in event handlers for the events raised from Edit_Command calling SaveState 
                                        CallInFieldSaveState = True
                                    Case Else
                                        ' Unless otherwise changed later, Should not be the case 
                                End Select

                            Case PageActionType.DesignerClick
                                'EditItemIndex should always be zero based
                                Dim strGridRowSelectValue As String
                                'strGridRowSelectValue = Me.Page.Request("btnGridRowSelect") & ""

                                'We created a copy of CurrentDesigner Object and its one of property so 
                                'that later, in loop we don't have to refer ApplicationState.Current.CorePage and CurrentDesigner 
                                'while processing each row in a grid
                                m_objDesigner = .CurrentDesigner
                                m_triKeepEditButtonEnabledAfterDesigner = m_objDesigner.KeepEditButtonEnabledInGrid
                                m_triKeepDeleteButtonEnabledAfterDesigner = m_objDesigner.KeepDeleteButtonEnabledInGrid
                                'm_blnDesignerMode = .DesignerMode

                                If strGridRowSelectValue = "" Then
                                    'If DefaultFirstRowInGrid of the Designer control is set to True
                                    'The First Row in a Grid will be enabled, if no record is selected at
                                    'the time of selecting the Designer, otherwise no record will be selected
                                    If .m_blnDefaultFirstRowInGrid Then
                                        m_intSelectedRecord = 0
                                        CurrentRowIndex = 0
                                    Else
                                        m_intSelectedRecord = -1
                                        CurrentRowIndex = -1

                                        'Note: Prepare grid controls to display as labels
                                        'We need to make sure that PerformOperation calls
                                        'PrepareGridControlsForDisplay(False, Nothing)
                                    End If
                                Else
                                    m_intSelectedRecord = CInt(strGridRowSelectValue)
                                End If

                                If m_intSelectedRecord >= 0 Then
                                    m_intNewRowIndex = m_intSelectedRecord
                                    BindGridFieldsEvents(m_intSelectedRecord, False)
                                    m_blnBindGridEvents = False
                                    objDataListItem = GetDataListItem(m_intSelectedRecord)
                                    RaiseDesignerEvents(objDataListItem, False)
                                Else
                                    'Although row is not selected bind grid fields to the first row,
                                    'however here we are not enabling the first row in Grid
                                    'This will ensure that derived page, Grid Fields can work
                                    'with the first row/occurrence
                                    BindGridFieldsEvents(0, False)
                                    m_blnBindGridEvents = False
                                End If

                                'At the time when responding to Base Page's event we DON'T have to Call SaveState however, we have to call SaveState with InField = True
                                CallMainSaveState = False
                                'To store any changes made in event handlers for for events raised in RaiseDesignerEvents
                                CallInFieldSaveState = True
                        End Select
                End Select
                objDataListItem = Nothing
            End With
        End Sub

        ''' --- RaiseDesignerEvents ------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of RaiseDesignerEvents.
        ''' </summary>
        ''' <param name="DataListItem"></param>
        ''' <param name="blnCancel"></param>
        ''' <param name="CommandName"></param>
        ''' <param name="CommandArgument"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function RaiseDesignerEvents(ByVal DataListItem As GridViewRowPresenter, ByRef blnCancel As Boolean,
                                              Optional ByVal CommandName As String = "",
                                              Optional ByVal CommandArgument As String = "")
            Dim objDesigner As Designer
            Dim objDesignerEventArgs As DesignerEventArgs
            Dim objPageActionObject As Object

            objPageActionObject = ApplicationState.Current.CorePage.PageActionObject
            If objPageActionObject Is Nothing Then
                objDesigner = ApplicationState.Current.CorePage.CurrentDesigner
            Else
                objDesigner = CType(objPageActionObject, Designer)
            End If

            If Not objDesigner Is Nothing Then
                objDesignerEventArgs = New DesignerEventArgs(DataListItem, CommandName, CommandArgument)
                RaiseEditRecord(Me, objDesignerEventArgs, m_intSelectedRecord)

                With objDesigner
                    .m_intCurrentItemIndex = m_intSelectedRecord
                    .RaiseBeforeClick(blnCancel, objDesignerEventArgs)
                    If blnCancel Then
                        CurrentRowIndex = -1
                        m_intSelectedRecord = -1
                    Else
                        CurrentRowIndex = m_intSelectedRecord
                        SetRowStatus(GridRowStatusCommand.Designer, DataListItem)
                        'Me.AddDesigner(ApplicationState.Current.CorePage.DesignerName, DataListItem)
                        .RaiseClick()

                        ' Don't enable row if there is no Accept Verb List
                        If Not objDesigner.HasAccept Then CurrentRowIndex = -1
                    End If
                End With
            End If
            'If m_intToolbarAction <> ToolbarIcons.Delete AndAlso m_intToolbarAction <> ToolbarIcons.Submit Then PrepareGridControlsForDisplay(False, objDesigner)
            objDesigner = Nothing
            objDesignerEventArgs = Nothing
            objPageActionObject = Nothing
            Return Nothing
        End Function

        ''' --- RaiseAddEvents -----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of RaiseAddEvents.
        ''' </summary>
        ''' <param name="ItemIndex"></param>
        ''' <param name="IsGridNew"></param>
        ''' <param name="GridButtonEventArgs"></param>
        ''' <param name="Cancel"></param>
        ''' <param name="SetCurrentRowIndex"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function RaiseAddEvents(ByVal ItemIndex As Integer, ByVal IsGridNew As Boolean,
                                         ByVal GridButtonEventArgs As GridButtonEventArgs, ByRef Cancel As Boolean,
                                         ByVal SetCurrentRowIndex As Boolean) As Boolean
            With ApplicationState.Current.CorePage
                .AppendMode = True
                RaiseAppendRecord(Me, EventArgs.Empty, ItemIndex, IsGridNew)
            End With

            'BeforeAdd is Core Solution specific event which 
            'developer can use to prohibit end user from selecting a particular row
            'by setting corresponding Cancel Variable to True in Event Handler code
            RaiseEvent BeforeAdd(Me, GridButtonEventArgs, Cancel)
            If Not Cancel Then
                If SetCurrentRowIndex Then CurrentRowIndex = ItemIndex
                RaiseEvent AddClick(Me, GridButtonEventArgs)
            End If
        End Function

        ''' --- RaiseEditEvents ----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of RaiseEditEvents.
        ''' </summary>
        ''' <param name="ItemIndex"></param>
        ''' <param name="GridButtonEventArgs"></param>
        ''' <param name="Cancel"></param>
        ''' <param name="SetCurrentRowIndex"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function RaiseEditEvents(ByVal ItemIndex As Integer, ByVal GridButtonEventArgs As GridButtonEventArgs,
                                          ByRef Cancel As Boolean, ByVal SetCurrentRowIndex As Boolean) As Boolean
            With ApplicationState.Current.CorePage
                .AppendMode = False
                'Dim objCheckBox As WebControls.CheckBox
                ' Ensure that if the user checked the checkbox and then
                ' edits a row in the grid, that we remove the checkbox values.
                ' Otherwise what happens is only 1 fields is enabled (current ACCEPT field)
                ' for first postback.
                'For i As Integer = 0 To Me.Occurs - 1
                '    objCheckBox = GetCheckBox(Me.Items(i))
                '    If Not (objCheckBox Is Nothing) Then
                '        objCheckBox.Checked = False
                '    Else
                '        Exit For
                '    End If
                'Next

                'Unlike RaiseDeleteRecord, RaiseAppendRecord and RaiseEditRecord gets called before BeforeAdd and BeforeEdit events
                'This may lead to a bug when user cancel Click event in BeforeAdd / BeforeEdit event,
                'as raising RaiseAppendRecord and RaiseEditRecord on base page may
                'change record position in corresponding FileObjects

                'We need to move the record position in FileObject, so that Designers or
                'screen like lookup screen can select value and return to the calling screen
                RaiseGotoRecord(Me, GridButtonEventArgs, ItemIndex)
            End With
            'BeforeEdit is Core Solution specific event which 
            'developer can use to prohibit end user from selecting a particular row
            'by setting corresponding Cancel Variable to True in Event Handler code
            RaiseEvent BeforeEdit(Me, GridButtonEventArgs, Cancel)
            If Not Cancel Then
                CurrentRowIndex = ItemIndex
                RaiseEvent EditClick(Me, GridButtonEventArgs)
                If Me.m_blnUsingAcceptProcessing Then
                    If GetStatus().CurrentStatus = GridRowStatus.Editing Then
                        GetStatus().CurrentStatus = GridRowStatus.UnchangedOld
                    End If
                    GridDesignerCompleted = True
                End If

                ApplicationState.Current.CorePage.InGridFieldID = ""

            End If



        End Function

        ' GetGridButton function
        ' returns the button pressed by user, based on __EventTarget
        ''' --- GetGridButton ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetGridButton.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function GetGridButton() As DataListButtons
            Dim intGridRow As Integer = -1
            Dim intIndexOfButtonName As Integer = -1
            Dim strButtonName As String = ""
            Dim strKey As String

            If ApplicationState.Current.CorePage.PageActionType = PageActionType.DataListButtonClick Then

                If Not IsNothing(ApplicationState.Current.CorePage.PageActionObject) AndAlso ApplicationState.Current.CorePage.PageActionObject.GetType.ToString = "Core.Windows.UI.Core.Windows.UI.InGridButton" Then

                    Return DataListButtons.EditRecordButton

                Else
                    If IsNothing(DirectCast(ApplicationState.Current.CorePage.PageActionObject, GridButton)) Then
                        Return DataListButtons.EditRecordButton
                    End If
                End If


                Select Case DirectCast(ApplicationState.Current.CorePage.PageActionObject, GridButton).Name.ToUpper
                    Case "BTNGRIDROWNEW" 'Clears Grid and enable first row as new Row
                        Return DataListButtons.NewRecordButton
                    Case "BTNGRIDROWEDIT" 'Includes Add and Edit both 
                        Return DataListButtons.EditRecordButton
                    Case "BTNGRIDROWDELETE"
                        Return DataListButtons.DeleteRecordButton
                    Case Else
                        Return DataListButtons.NotSet
                End Select
            Else
                Return DataListButtons.NotSet
            End If




        End Function

        ''' --- SetRowStatus -------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of SetRowStatus.
        ''' </summary>
        ''' <param name="StatusCommand"></param>
        ''' <param name="DataListItem"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub SetRowStatus(ByVal StatusCommand As GridRowStatusCommand, ByRef DataListItem As GridViewRowPresenter)
            Dim intCurrentStatus As GridRowStatus
            Dim intPreviousStatus As GridRowStatus
            Dim intNewStatus As GridRowStatus
            Dim objGridRowStatus As RowStatus

            'Dim intIndex As Integer = ItemContainerGenerator.IndexFromContainer(DataListItem)
            Dim intIndex = GetRowIndex(Me, DataListItem)

            objGridRowStatus = GetStatus(DataListItem)

            With objGridRowStatus
                intPreviousStatus = .PreviousStatus
                intCurrentStatus = .CurrentStatus
            End With
            intNewStatus = intCurrentStatus
            Select Case StatusCommand
                Case GridRowStatusCommand.Idle, GridRowStatusCommand.None
                    intNewStatus = GridRowStatus.NotSet
                Case GridRowStatusCommand.Delete
                    'Check if already marked for deletion?
                    If intCurrentStatus = GridRowStatus.Deleted Then 'Deleted
                        'At present we disable the Delete Button as soon as user
                        'clicks on "Delete" button, as user might have logic on 
                        'Delete Click that cannot be reverted.
                        '
                        'In case if we ever need to allow revert Delete uncomment
                        'following code.

                        'If Me.m_intToolbarAction <> ToolbarIcons.Submit Then
                        '    'Revert it to previous status
                        '    intNewStatus = intPreviousStatus
                        'End If
                    Else
                        If Not m_blnUsingAcceptProcessing Then
                            'Mark for deletion
                            RaiseDeleteRecord(Me, EventArgs.Empty, intIndex)
                        End If
                        intNewStatus = GridRowStatus.Deleted
                    End If
                Case GridRowStatusCommand.DeleteAll
                    'If not already Deleted and a Record is an existing record
                    If intCurrentStatus <> GridRowStatus.Deleted And
                       (intCurrentStatus = GridRowStatus.Edited OrElse
                        intCurrentStatus = GridRowStatus.Editing OrElse
                        intCurrentStatus = GridRowStatus.UnchangedOld OrElse
                        intCurrentStatus = GridRowStatus.Adding OrElse
                        intCurrentStatus = GridRowStatus.Added) Then
                        'Mark for deletion
                        intNewStatus = GridRowStatus.Deleted
                    End If
                Case GridRowStatusCommand.Edit 'Selected a record for Editing through Edit Button
                    Select Case intCurrentStatus
                        Case GridRowStatus.UnchangedOld, GridRowStatus.Editing
                            If intCurrentStatus = GridRowStatus.UnchangedOld AndAlso GridDesignerCompleted Then
                                ' Do nothing.
                            Else
                                intNewStatus = GridRowStatus.Editing
                            End If
                            RaiseEditRecord(Me, EventArgs.Empty, intIndex)

                            'Image unchanged at this stage, Let user change a field 
                        Case GridRowStatus.Edited
                            RaiseEditRecord(Me, EventArgs.Empty, intIndex)
                            'No change to status i.e. still be in Edited mode
                        Case GridRowStatus.UnchangedNew, GridRowStatus.Adding
                            intNewStatus = GridRowStatus.Adding
                            RaiseAppendRecord(Me, EventArgs.Empty, intIndex,
                            m_intGridAction = DataListActionTypes.GridNew)
                            'Image unchanged at this stage, Let user change the content of a field 
                        Case GridRowStatus.Added
                            RaiseAppendRecord(Me, EventArgs.Empty, intIndex,
                            (m_intGridAction = DataListActionTypes.GridNew))
                            'No change to status i.e. still be in Added mode
                        Case GridRowStatus.NotSet
                            'Should not be the case
                    End Select
                Case GridRowStatusCommand.Designer
                    Select Case intCurrentStatus
                        Case GridRowStatus.UnchangedOld
                            intNewStatus = GridRowStatus.Editing
                            RaiseEditRecord(Me, EventArgs.Empty, intIndex)
                            'Image unchanged at this stage, Let user change a field 
                        Case GridRowStatus.UnchangedNew
                            intNewStatus = GridRowStatus.Adding
                            RaiseAppendRecord(Me, EventArgs.Empty, intIndex,
                            (m_intGridAction = DataListActionTypes.GridNew))
                            'Image unchanged at this stage, Let user change a field 
                            'Set Previous Status as Edited so that if user deletes an edited record,
                            'Later can revert it by again clicking on Delete Icon
                            objGridRowStatus.PreviousStatus = intNewStatus
                    End Select
                Case GridRowStatusCommand.Add
                    Select Case intCurrentStatus
                        Case GridRowStatus.NotSet, GridRowStatus.UnchangedNew
                            intNewStatus = GridRowStatus.Adding
                            'Image unchanged at this stage, Let user change the content of a field 
                        Case GridRowStatus.Added
                            'TODO: Check whether to revert Adding or not, especially fields already changed????
                    End Select
                Case GridRowStatusCommand.Change
                    Select Case intCurrentStatus
                        Case GridRowStatus.Adding, GridRowStatus.Added
                            intNewStatus = GridRowStatus.Added

                            'Set Previous Status as Added so that if user deletes an added record,
                            'Later can revert it by again clicking on Delete Icon
                            objGridRowStatus.PreviousStatus = intNewStatus
                        Case GridRowStatus.Editing, GridRowStatus.Edited
                            intNewStatus = GridRowStatus.Edited

                            'Set Previous Status as Edited so that if user deletes an edited record,
                            'Later can revert it by again clicking on Delete Icon
                            objGridRowStatus.PreviousStatus = intNewStatus
                    End Select
            End Select

            If _
                intNewStatus = GridRowStatus.Added OrElse intNewStatus = GridRowStatus.Deleted OrElse
                intNewStatus = GridRowStatus.Edited Then
                Me.AllowGridNew = False
            End If

            If intNewStatus <> intCurrentStatus Then
                objGridRowStatus.CurrentStatus = intNewStatus
            End If
        End Sub

        ''' --- ProcessDesigners ---------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of ProcessDesigners.
        ''' </summary>
        ''' <param name="DataListItem"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub ProcessDesigners(ByVal DataListItem As GridViewRowPresenter)
            Dim strDesignerNames As String
            Dim strDesignerName As String
            Dim astrFieldName As String()
            Dim objGridRowStatus As RowStatus
            Dim intItemIndex As Integer
            Dim blnCancel As Boolean

            blnCancel = False
            objGridRowStatus = GetStatus(DataListItem)
            'intItemIndex = ItemContainerGenerator.IndexFromContainer(DataListItem)
            intItemIndex = GetRowIndex(Me, DataListItem)
            strDesignerNames = objGridRowStatus.Designers & ""
            m_intNewRowIndex = intItemIndex
            CurrentRowIndex = intItemIndex
            astrFieldName = strDesignerNames.Split(";")
            For Each strDesignerName In astrFieldName
                If strDesignerName.Trim <> "" Then
                    Dim objDesigner As Designer
                    With ApplicationState.Current.CorePage
                        objDesigner = .FindControl(strDesignerName)
                        If objDesigner Is Nothing Then
                            'should not be the case
                        Else
                            .PageActionObject = Nothing
                            .DesignerName = strDesignerName
                            .CurrentDesigner = objDesigner
                            RaiseDesignerEvents(DataListItem, blnCancel)
                            .RunDesigner(strDesignerName, intItemIndex)
                        End If
                    End With
                End If
            Next
            objGridRowStatus = Nothing
        End Sub

        ''' --- DeleteGridRecords --------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of DeleteGridRecords.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub DeleteGridRecords()
            'Notes: 
            '1. Should only be called from the Base Page through RaiseDeleteGridRecords
            '2. At present only used in AcceptProcessing
            Dim objDataListItem As GridViewRowPresenter

            'Mark each record as Deleted through either Delete or DetailDelete
            For intItemRowIndex As Integer = 0 To (Me.Items.Count - 1) 'Loop through each row in a grid
                objDataListItem = GetDataListItem(intItemRowIndex)

                'Make available all those fields to the Delete/Detail Delete procedure
                BindGridFieldsEvents(objDataListItem, False)

                SetRowStatus(GridRowStatusCommand.DeleteAll, objDataListItem)

                Select Case GetStatus(objDataListItem).PreviousStatus
                    Case GridRowStatus.Edited, GridRowStatus.Editing, GridRowStatus.UnchangedOld
                        '.AppendMode = False
                        ProcessDeleteClick(objDataListItem)
                End Select
            Next
            ApplicationState.Current.CorePage.SetOccurrence(0)

        End Sub

        ''' --- ProcessGridRecords -------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of ProcessGridRecords.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub ProcessGridRecords()
            Dim i As Integer = 0
            Dim objDataListItem As DataGridRow
            Dim intCurrentStatus As GridRowStatus
            Dim intPreviousStatus As GridRowStatus
            Dim intNewStatus As GridRowStatus
            Dim objGridRowStatus As RowStatus
            Dim intPreviousOccurrence As Integer

            intPreviousOccurrence = ApplicationState.Current.CorePage.m_intOccurrence

            With ApplicationState.Current.CorePage
                Dim blnIsGridNew As Boolean = IsGridNew
                If .Mode = PageModeTypes.Entry Then
                    'For Each objDataListItem In Items 'Loop through each row in a grid
                    For intItemRowIndex As Integer = 0 To (Me.Items.Count - 1) 'Loop through each row in a grid
                        objDataListItem = Me.Items(intItemRowIndex)
                        'If IsItem(objDataListItem.ItemType) Then
                        '    'Get the Previous and Current status for the row
                        '    objGridRowStatus = GetStatus(objDataListItem)
                        '    With objGridRowStatus
                        '        intPreviousStatus = .PreviousStatus
                        '        intCurrentStatus = .CurrentStatus
                        '    End With

                        '    'We need to set Occurrence, so that derived page can use it, especially Temporary Array Variables which are bound to Grid.
                        '    i = intItemRowIndex
                        '    m_intNewRowIndex = intItemRowIndex
                        '    m_intSelectedRecord = intItemRowIndex
                        '    CurrentRowIndex = intItemRowIndex

                        '    'Read Record from Grid and puts it into Field Objects
                        '    BindGridFieldsEvents(objDataListItem, False)
                        '    Select Case intCurrentStatus 'Rows and Fields in a GridDataSource are Zero Based
                        '        Case GridRowStatus.Added, GridRowStatus.Adding
                        '            RaiseAddEvents(intItemRowIndex, blnIsGridNew, _
                        '                            New GridButtonEventArgs(objDataListItem), False, False)
                        '            '.RaiseAppendRecord(Me, Nothing, i, blnIsGridNew)
                        '            blnIsGridNew = False
                        '            .AppendFromEntry()

                        '            ProcessDesigners(objDataListItem)
                        '        Case GridRowStatus.Deleted
                        '            'Note: ' This code is specifically added to toggle delete on
                        '            ' New Record in a grid.
                        '            '
                        '            ' Following two events are raised to mimic Append and Delete on a Grid
                        '            '
                        '            ' We have did this because, during displaying 
                        '            ' First empty record, FileObject is not 
                        '            ' retrieved from InField Session.
                        '            '
                        '            ' In case if we ever write a code to retrieve FileObject From 
                        '            ' InField Session variables, we can omit this code
                        '            '  Don't remove this code
                        '            RaiseAppendRecord(Me, Nothing, intItemRowIndex)
                        '            RaiseDeleteRecord(Me, Nothing, intItemRowIndex)
                        '    End Select
                        'End If
                    Next
                    .SetOccurrence(0)

                    'To display all Grid controls as label 
                    Me.CurrentRowIndex = -1
                    m_intNewRowIndex = -1
                ElseIf .Mode = PageModeTypes.Change Then

                    'For Each objDataListItem In Items 'Loop through each row in a grid
                    For intItemRowIndex As Integer = 0 To (Me.Items.Count - 1) 'Loop through each row in a grid
                        objDataListItem = Me.Items(intItemRowIndex)
                        'If IsItem(objDataListItem.ItemType) Then

                        '    ' If user clicked the DELETE button on the toolbar, mark all 
                        '    ' rows for deletion and call the Delete procedure (n) times.
                        '    If m_intToolbarAction = ToolbarIcons.Delete AndAlso .ScreenType = ScreenTypes.Grid Then
                        '        'Mark current record as Deleted
                        '        SetRowStatus(GridRowStatusCommand.DeleteAll, objDataListItem)
                        '    End If
                        '    'Get the Previous and Current status for the row
                        '    objGridRowStatus = GetStatus(objDataListItem)
                        '    With objGridRowStatus
                        '        intPreviousStatus = .PreviousStatus
                        '        intCurrentStatus = .CurrentStatus
                        '    End With

                        '    'We need to set Occurrence, so that derived page can use it, especially Temporary Array Variables which are bound to Grid.
                        '    i = intItemRowIndex
                        '    m_intNewRowIndex = i
                        '    CurrentRowIndex = i
                        '    m_intSelectedRecord = i

                        '    'Read Records from Grid and puts it into Field Objects
                        '    BindGridFieldsEvents(objDataListItem, False)

                        '    Select Case intCurrentStatus 'Rows and Fields in a GridDataSource are Zero Based
                        '        Case GridRowStatus.Added, GridRowStatus.Adding
                        '            '.RaiseAppendRecord(Me, Nothing, i, blnIsGridNew)
                        '            .AppendMode = True
                        '            RaiseAddEvents(i, blnIsGridNew, New GridButtonEventArgs(objDataListItem), False, _
                        '                            False)
                        '            blnIsGridNew = False
                        '            .Append()

                        '            ProcessDesigners(objDataListItem)
                        '        Case GridRowStatus.Deleted
                        '            'Ensure, not to run "Delete" on New Rows, Delete will be called only for existing rows
                        '            Select Case intPreviousStatus
                        '                Case GridRowStatus.Edited, GridRowStatus.Editing, GridRowStatus.UnchangedOld

                        '                    .AppendMode = False
                        '                    ProcessDeleteClick(i)
                        '                    '.RaiseDeleteRecord(Me, Nothing, i)
                        '                    If .ScreenType = ScreenTypes.Grid Then
                        '                        .Delete()
                        '                    Else
                        '                        .DetailDelete()
                        '                    End If
                        '                Case GridRowStatus.Adding, GridRowStatus.Added
                        '                    'Although newly added record is deleted we are adding it to record buffer
                        '                    'to maintain record position which is zero based Occurrence in a base page
                        '                    'However, in this case we are not calling RaiseAddEvents (which in turn 
                        '                    'calls "Append") for the record as it is already deleted
                        '                    .AppendMode = True
                        '                    'RaiseAppendRecord to add new record in FileObject's record buffer
                        '                    RaiseAppendRecord(Me, EventArgs.Empty, i, blnIsGridNew)
                        '                    blnIsGridNew = False

                        '                    'Mark record buffer to deleted
                        '                    RaiseDeleteRecord(Me, EventArgs.Empty, i)
                        '            End Select
                        '        Case GridRowStatus.Edited
                        '            .AppendMode = False
                        '            RaiseEditEvents(i, New GridButtonEventArgs(objDataListItem), False, False)
                        '            '.RaiseEditRecord(Me, Nothing, i)
                        '            RaiseGridUpdateValidation(Me, Nothing, i)
                        '            'GridUpdateValidation Event is specific to the current instance of DataList

                        '            ProcessDesigners(objDataListItem)
                        '    End Select
                        'End If
                    Next
                    .SetOccurrence(0)

                    IsGridNew = blnIsGridNew

                    'To display all Grid controls as label 
                    CurrentRowIndex = -1
                    m_intNewRowIndex = -1
                    m_intSelectedRecord = -1
                    'To deselect the last Radio Button
                End If
            End With

            'Reset Occurrence to the previous occurrence 
            ApplicationState.Current.CorePage.m_intOccurrence = intPreviousOccurrence

            objDataListItem = Nothing
            intCurrentStatus = Nothing
            intPreviousStatus = Nothing
            intNewStatus = Nothing
            objGridRowStatus = Nothing
        End Sub

        Public Sub AddRecordDynamically()

            Dim row As Integer = ApplicationState.Current.CorePage.Occurrence
            If GetStatus(Me.Items(row - 1)).CurrentStatus = GridRowStatus.NotSet Then
                Dim objDataListItem As DataGridRow
                objDataListItem = Me.Items(row - 1)
                'RaiseAddEvents(row - 1, False, New GridButtonEventArgs(objDataListItem), False, False)
                SetRowStatus(GridRowStatus.Added, , row - 1)
                DynamicallyAddedRows = True
            End If

        End Sub

        ''' --- IsItem -------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of IsItem.
        ''' </summary>
        ''' <param name="ItemType"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function IsItem(ByVal ItemType As Object) As Boolean
            'Select Case ItemType
            '    Case ListItemType.AlternatingItem, ListItemType.EditItem, ListItemType.Item, ListItemType.SelectedItem
            '        Return True
            '    Case Else
            '        Return False
            'End Select

            Return True
        End Function

        ''' --- PrepareDataTableFromGridRowsToProcess ------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of PrepareDataTableFromGridRowsToProcess.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub PrepareDataTableFromGridRowsToProcess()
            Dim intOccurs As Integer = Occurs
            If intOccurs > 0 Then
                GridDataTable = New DataTable
                PrepareGridDataTableFromDataListItem(GridDataTable, GetDataListItem(0))
                Dim objDataListItem As DataGridRow
                For Each objDataListItem In Items
                    'If IsItem(objDataListItem.ItemType) Then
                    '    GridDataTable.Rows.Add(GridDataTable.NewRow)
                    'End If
                Next
            End If
        End Sub

        ''' --- PrepareGridDataTableFromDataListItem -------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of PrepareGridDataTableFromDataListItem.
        ''' </summary>
        ''' <param name="DataTable"></param>
        ''' <param name="DataListItem"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub PrepareGridDataTableFromDataListItem(ByVal DataTable As DataTable,
                                                          ByVal DataListItem As GridViewRowPresenter)


            Dim objTextBox As TextBox
            'System.Web.UI.WebControls.TextBox
            Dim objDateControl As DateControl
            Dim objCheckBoxControl As CheckBox
            Dim objComboBoxControl As ComboBox

            Dim ctl As Control
            For Each ctl In DataListItem.GetDescendants(Of Control)()

                Select Case ctl.GetType.ToString
                    Case "Core.Windows.UI.Core.Windows.UI.TextBox"
                        objTextBox = CType(ctl, TextBox)
                        DataTable.Columns.Add(objTextBox.FieldName.Replace(".", "_"), GetType(String))
                    Case "Core.Windows.UI.Core.Windows.UI.DateControl"
                        objDateControl = CType(ctl, DateControl)
                        DataTable.Columns.Add(objDateControl.FieldName.Replace(".", "_"), GetType(String))
                        'Case "Core.Web.UI.Core.Web.UI.CheckBox"
                        '    objCheckBoxControl = CType(objCtl, CheckBox)
                        '    DataTable.Columns.Add(objCheckBoxControl.FieldName.Replace(".", "_"), GetType(String))
                    Case "Core.Windows.UI.Core.Web.UI.ComboBox"
                        objComboBoxControl = CType(ctl, ComboBox)
                        DataTable.Columns.Add(objComboBoxControl.FieldName.Replace(".", "_"), GetType(String))
                End Select
            Next
            ctl = Nothing
            objTextBox = Nothing
            objDateControl = Nothing
            objCheckBoxControl = Nothing
            objComboBoxControl = Nothing

        End Sub

        ''' --- MoveFileObjectRecordPosition ---------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of MoveFileObjectRecordPosition.
        ''' </summary>
        ''' <param name="RecordPosition"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub MoveFileObjectRecordPosition(ByVal RecordPosition As Integer)
            If Not FileObject Is Nothing Then
                With FileObject
                    .GoToRecord(RecordPosition)
                    If .EOF Then .MoveFirst()
                End With
            End If
        End Sub

        ''' --- SetOccursWithFileFlags ---------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of SetOccursWithFileFlags.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub SetOccursWithFileFlags()

            If Not FileObject Is Nothing Then
                With FileObject
                    m_blnAlteredRecord = .GetAlteredRecord
                    m_blnDeletedRecord = .GetDeletedRecord
                    m_blnNewRecord = .GetNewRecord()
                    If Not .UnderlyingDataTable Is Nothing Then
                        m_intRowCount = .UnderlyingDataTable.Rows.Count
                    End If
                End With
            End If

        End Sub

        ''' --- PrepareGridControlsForDisplay --------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of PrepareGridControlsForDisplay.
        ''' </summary>
        ''' <param name="KeepCurrentPage"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub PrepareGridControlsForDisplay()
            Dim objDesigner As Designer

            With ApplicationState.Current.CorePage
                objDesigner = .CurrentDesigner
                m_blnHasError = .HasError
                m_intPageMode = .Mode
                If _
                    m_blnHasError AndAlso (Not objDesigner Is Nothing) AndAlso
                    objDesigner.ResetDesignerMode = ResetDesigner.InSamePostBack Then
                    objDesigner = Nothing
                End If

                ' Check here as well to see if we can append.  This is due to the fact that we first check prior to calling the procedure
                ' that is executing.  If this procedure was the entry procedure, and we finish the Entry sequence, we are now in correct mode. 
                ' Since the mode changed, we need to re-check if we can append to ensure that the Append icon is enabled if need be.
                NoAppend =
                    Not _
                    (.ChangeActivity OrElse
                     (.EntryActivity AndAlso
                      (Me.m_intToolbarAction = ToolbarIcons.Add OrElse .Mode = PageModeTypes.Entry OrElse
                       .Mode = PageModeTypes.Correct))) AndAlso
                    (Not FileObject Is Nothing AndAlso Not FileObject.NoAppend) AndAlso Not .DisableAppend
            End With




            'Prepare grid controls to display as labels
            'If Me.m_blnUsingAcceptProcessing Then
            PrepareGridControlsForDisplayForAcceptProcessing(objDesigner)
            'Else
            'PrepareGridControlsForDisplay(objDesigner)
            'End If

            'If CurrentRowIndex <= 0 Then
            '    ApplicationState.Current.CorePage.RegisterHiddenFields("GridRow", "")
            'Else
            '    ApplicationState.Current.CorePage.RegisterHiddenFields("GridRow", CurrentRowIndex + 1)
            'End If

            'ApplicationState.Current.CorePage.RegisterHiddenFields("GridShort", "")
            'ApplicationState.Current.CorePage.RegisterHiddenFields("GridId", Me.ID)
            'ApplicationState.Current.CorePage.RegisterHiddenFields("GridOccurs", Me.Occurs)
        End Sub

        ''' --- GridRowHasData -----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GridRowHasData.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function GridRowHasData() As Boolean

            Dim intOccurrence As Integer = ApplicationState.Current.CorePage.Occurrence
            ' PH Occurrence.
            Dim intRow As Integer = intOccurrence - 1
            ' 0-based row value.
            Dim blnReturnValue As Boolean = False

            ' If in the Entry procedure we have a FOR that fetches DETAIL records.
            If _
                (ApplicationState.Current.CorePage.DisableAppend OrElse Me.NoAppend) AndAlso m_intToolbarAction = ToolbarIcons.Add AndAlso
                Not FileObject Is Nothing Then
                If Not m_blnNewRecord Is Nothing And m_intRowCount > 0 Then _
                    ' Check that we have an OccursWith file object.
                    If _
                        (intOccurrence <= m_intRowCount AndAlso Not m_blnNewRecord(intRow) AndAlso
                         Not m_blnAlteredRecord(intRow)) Then
                        blnReturnValue = True
                    End If
                End If
            End If
            Return blnReturnValue

        End Function

        Private Function DynamicallyAddedRow(ByVal Row As Integer) As Boolean

            Return DynamicallyAddedRows AndAlso m_blnNewRecord(Row) AndAlso m_blnAlteredRecord(Row)

        End Function

        Private Property DynamicallyAddedRows() As Boolean
            Get
                Return _DynamicallyAddedRows
            End Get
            Set(ByVal Value As Boolean)
                _DynamicallyAddedRows = Value
            End Set
        End Property
        Private _DynamicallyAddedRows As Boolean



        'PrepareGridControlsForDisplayForAcceptProcessing enables or disables the controls depending on 
        'this procedure is being called from different methods
        ''' --- PrepareGridControlsForDisplayForAcceptProcessing -------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of PrepareGridControlsForDisplayForAcceptProcessing.
        ''' </summary>
        ''' <param name="Designer"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub PrepareGridControlsForDisplayForAcceptProcessing(ByVal Designer As Designer)

            Dim objCtl As Control
            Dim objTextBox As TextBox
            Dim objComboBox As ComboBox
            'System.Web.UI.WebControls.TextBox
            Dim objValidateTextBox As TextBox
            'System.Web.UI.WebControls.TextBox
            Dim objDateControl As DateControl
            'Dim objGridButtonCheck As WebControls.CheckBox
            'Dim objGridRadioButton As GridRadioButton
            Dim objValidateDateControl As DateControl
            Dim objRowStatus As RowStatus
            Dim intItemIndex As Integer = -1
            Dim intCurrentRowIndex As Integer
            Dim intCurrentStatus As GridRowStatus
            Dim blnClearCurrentRecordFields As Boolean
            Dim blnEditedDesigner As Boolean = False
            Dim m_triEnableGrid As TriState = TriState.UseDefault
            Dim blnSetNextRow As Boolean = False
            Dim blnFirstEmptyRow As Boolean = True
            Dim intLastAppendedRow As Integer = -1
            'By default there is no appended row


            With ApplicationState.Current.CorePage

                If .m_blnShowGridFromUpdate Then
                    m_intToolbarAction = ToolbarIcons.Submit
                End If
                If .m_blnImmediateTerminateAppend Then
                    'If Append is terminated from the first field, Appended row is the CurrentRow - 1
                    intLastAppendedRow = Me.CurrentRowIndex - 1
                End If

                If .m_blnSkipAllAndTerminateAppend Then
                    'If Append is terminated from after the first field, CurrentRow is the last appended row
                    intLastAppendedRow = Me.CurrentRowIndex
                End If


                ' Disabling all the rows on grid if EnableNumberedDesigners is True
                ' This is specifically added to disable the row when we tab out the
                ' last field during Append, however, it may affect other scenerios
                ' Disable grid after named designers or if error occurs (and no Accept was executed).
                ' Disable grid at the end of any "Designer" procedure, beside Entry and Append, Find.
                ' m_blnDisableGridRows is also used 
                ' m_triEnableGrid: If there is an Error and  no more Accept disable ALL grid rows
                If _
                    .m_blnDisableGridRows AndAlso
                    (Me.m_intGridAction <> DataListActionTypes.NotSet OrElse Me.m_intToolbarAction = ToolbarIcons.Add) _
                    Then
                    'If .m_blnDisableGridRows Then
                    Me.ReadOnly(TriState.False)
                End If

                If _
                    ((.IsPathComplete AndAlso Not .IsAppend) OrElse
                     (Me.m_blnUsingAcceptProcessing AndAlso Not .ExecutingDesigner AndAlso
                      ApplicationState.Current.CorePage.EnableNumberedDesigners)) AndAlso (ApplicationState.Current.CorePage.Mode <> PageModeTypes.Select) Then
                    CurrentRowIndex = -1
                End If

                'Check whether to display Blank Grid or not
                'If Me.Controls.Count = 0 Then
                '    'TODO: To identify all cases in which we need to display blank grid
                '    ' Ideally we need to handle such cases individually
                '    ' Until we figure out all cases, we are displaying blank grid from here
                '    ShowGrid(True)
                '    'Display grid without any records
                'End If

                intItemIndex = -1
                intCurrentRowIndex = CurrentRowIndex
                If m_intToolbarAction = ToolbarIcons.Cancel Then
                    m_blnClearFields = True
                ElseIf _
                    m_intToolbarAction <> ToolbarIcons.Submit AndAlso
                    ((ApplicationState.Current.CorePage.FindMode AndAlso ApplicationState.Current.CorePage.PageActionType = PageActionType.NotSet) OrElse
                     m_intToolbarAction = ToolbarIcons.Find) AndAlso
                    (ApplicationState.Current.CorePage.HasPathRequestFields) AndAlso
                    (.EnableNumberedDesigners = True) Then
                    'If called from Menu/other screen with Find Mode or if Click on Find on screen which HasPathRequestFields
                    If Designer Is Nothing AndAlso (IsNothing(ApplicationState.Current.CorePage.DesignerName) OrElse ApplicationState.Current.CorePage.DesignerName.Length = 0) Then m_blnClearFields = True
                ElseIf _
                    m_intToolbarAction = ToolbarIcons.Add OrElse
                    m_intGridAction = DataListActionTypes.GridNew AndAlso (.EnableNumberedDesigners) Then
                    m_intNextAppendInRow = .NextAppendInRow

                    'Make sure error has not occured while calling Append/Entry
                    'If m_triContinueAppend other than "False", there is no error, during a call to Entry/Append
                    If .m_triContinueAppend = TriState.False Then
                        m_blnClearFields = False
                        m_blnEnableFirstRow = False
                    Else
                        If .EnableNumberedDesigners OrElse .ControlsCleared Then
                            m_blnEnableFirstRow = True
                            m_blnClearFields = True
                        Else
                            m_blnEnableFirstRow = True
                            m_blnClearFields = False
                        End If

                        ' If in the Entry procedure we have a FOR that fetches DETAIL records when APPEND is disabled.
                        If GridRowHasData() Then
                            m_blnEnableFirstRow = False
                            m_blnClearFields = False
                        End If
                    End If
                ElseIf _
                    (Me.m_intGridButton = DataListButtons.EditRecordButton OrElse
                     Me.m_intGridButton = DataListButtons.NewRecordButton) AndAlso (.IsExecutingAppend) Then
                    m_intNextAppendInRow = .NextAppendInRow
                End If

                ' Since all edits are disabled except for the first, row,
                ' we need to set all rows to inactive (since the ACCEPT verb
                ' will handle setting focus and enabling the field).
                If m_blnSuppressAdditionalEdits Then
                    If ApplicationState.Current.CorePage.Occurrence > 1 Then
                        CurrentRowIndex = -1
                        intCurrentRowIndex = CurrentRowIndex
                    End If
                End If

                'If there is need to call next Append, write client-side code to call Append
                If m_intNextAppendInRow >= 0 Then
                    'Disable Current Row
                    CurrentRowIndex = -1
                    intCurrentRowIndex = -1

                    If m_intNextAppendInRow < Me.Occurs Then
                        'Leave the value of .NextAppendInRow as it is as it is used in Page's
                        'PreRender event to write client-side script to call Append on that row
                    Else
                        'Reached at the limit of Occurs, and there is no more rows to append, so set it to -1
                        .FinishAppend()

                        CType(GetDataListItem(m_intNextAppendInRow - 1).GetDescendants(Of RowStatus)("btnGridRowStatus").FirstOrDefault(), RowStatus).AppendedRowStatus = AppendStatus.Appended

                        'CType(Me.Items(m_intNextAppendInRow - 1).FindControl("btnGridRowStatus"), RowStatus).
                        '    AppendedRowStatus = AppendStatus.Appended
                        m_intNextAppendInRow = -1
                    End If
                End If

                If Not NoAppend AndAlso (Not .m_blnExecutingPath AndAlso Not .m_blnInFind) AndAlso Not NoRecordsFound _
                    Then
                    m_blnEnableFirstEmptyNewButton = True
                End If
            End With

            'Dim rows = Me.ChildrenOfType(Of GridViewRowPresenter)()
            Dim row As GridViewRowPresenter

            For j As Integer = 0 To Items.Count - 1



                row = FindVisualChild(Of GridViewRowPresenter)(TryCast(ItemContainerGenerator.ContainerFromIndex(j), ListViewItem))

                'If row.GetType.ToString = "Telerik.Windows.Controls.GridView.GridViewRow" Then
                intItemIndex += 1
                objRowStatus = row.GetDescendants(Of RowStatus)("btnGridRowStatus").FirstOrDefault()

                blnClearCurrentRecordFields = m_blnClearFields

                If Not Me.FileObject Is Nothing Then
                    With FileObject
                        If .HasData AndAlso .AlteredRecord(intItemIndex) Then
                            SetRowStatus(GridRowStatusCommand.Change, row)
                            If Not NoAppend Then
                                m_blnEnableFirstEmptyNewButton = True
                            End If
                        End If
                    End With
                End If

                'Get the Grid Record Status
                intCurrentStatus = objRowStatus.CurrentStatus

                'Select Case intCurrentStatus
                '    Case GridRowStatus.UnchangedNew, GridRowStatus.NotSet
                '        row.Visibility = System.Windows.Visibility.Collapsed
                '    Case Else
                '        row.Visibility = System.Windows.Visibility.Visible

                'End Select

                ' Since the record is being saved, reset the 
                ' status to UnchangedOld or NotSet if record is Deleted
                If _
                    Me.m_intToolbarAction = ToolbarIcons.Submit AndAlso (Not m_blnHasError) AndAlso
                    (m_intPageMode = PageModeTypes.Entry OrElse m_intPageMode = PageModeTypes.Change OrElse
                     m_intPageMode = PageModeTypes.Correct) Then
                    Select Case intCurrentStatus
                        Case GridRowStatus.Added, GridRowStatus.Edited
                            SetRowStatus(GridRowStatus.UnchangedOld, GridRowStatus.UnchangedOld, intItemIndex)
                        Case GridRowStatus.Adding
                                'Leave the status as it is
                        Case GridRowStatus.Editing
                            SetRowStatus(GridRowStatus.UnchangedOld, GridRowStatus.UnchangedOld, intItemIndex)
                            intCurrentStatus = objRowStatus.CurrentStatus
                        Case GridRowStatus.Deleted
                            ' Record was deleted from grid, so ensure that we clear controls for the current row.
                            blnClearCurrentRecordFields = True
                    End Select

                End If

                With objRowStatus

                    If _
                        (intItemIndex = m_intNextAppendInRow - 1) AndAlso m_intNextAppendInRow > 0 AndAlso
                        m_intNextAppendInRow < Me.Occurs Then
                        'm_intNextAppendInRow variable only contains the non-negative value if Row is changing
                        'As such whenever row is changing, we can safely assume that 
                        'Set the AppendedRowStatus to Appended
                        .AppendedRowStatus = AppendStatus.Appended
                    End If

                    If DynamicallyAddedRow(intItemIndex) Then
                        AddRowIndex = intItemIndex
                    ElseIf _
                        m_blnClearFields OrElse
                        (intCurrentStatus = GridRowStatus.NotSet AndAlso m_blnEnableFirstRow AndAlso (Not m_blnHasError) AndAlso
                         (intItemIndex = 0 AndAlso (m_intPageMode = PageModeTypes.Entry OrElse ApplicationState.Current.CorePage.IsAppend))) Then
                        If m_blnEnableFirstRow AndAlso intItemIndex = 0 Then
                            If intCurrentStatus <> GridRowStatus.Added Then
                                .SetBothStatus(GridRowStatus.Adding)
                            End If
                            AddRowIndex = intItemIndex
                        Else
                            .SetBothStatus(GridRowStatus.NotSet)
                            intCurrentStatus = .CurrentStatus
                        End If
                    End If

                    If _
                        (AddRowIndex = 0 AndAlso
                         (intCurrentStatus = GridRowStatus.Adding OrElse intCurrentStatus = GridRowStatus.Added)) OrElse
                        DynamicallyAddedRow(intItemIndex) Then
                        blnClearCurrentRecordFields = False
                    End If

                    If intCurrentStatus = GridRowStatus.Adding Then
                        If ApplicationState.Current.CorePage.IsAppend Then AddRowIndex = intItemIndex
                        'If intItemIndex <> intCurrentRowIndex Then .SetBothStatus(GridRowStatus.Added)
                    End If

                    If _
                        (AddRowIndex + 1) = intItemIndex AndAlso intCurrentStatus = GridRowStatus.NotSet AndAlso
                        (ApplicationState.Current.CorePage.IsAppend OrElse ApplicationState.Current.CorePage.IsAppendFromEntry _
                         OrElse (Not DynamicallyAddedRow(intItemIndex) AndAlso DynamicallyAddedRow(intItemIndex - 1))) _
                        Then
                        .SetBothStatus(GridRowStatus.UnchangedNew)
                    End If

                    ' Remove the checks from the DESIGNER checkboxes if the grid is being disabled.
                    'Dim chkDesignerCheckBox As WebControls.CheckBox = Nothing
                    'If AllowSelectRowButton AndAlso Me.m_blnUsingAcceptProcessing Then
                    '    chkDesignerCheckBox = GetCheckBox(Me.Items(intItemIndex))
                    '    If ApplicationState.Current.CorePage.m_blnDisableGridRows Then
                    '        chkDesignerCheckBox.Checked = False
                    '    End If
                    'End If

                    If AllowSelectRowButton AndAlso Me.m_blnUsingAcceptProcessing Then
                        '    If _
                        '        intItemIndex = intCurrentRowIndex AndAlso chkDesignerCheckBox.Checked AndAlso _
                        '        Not ApplicationState.Current.CorePage.ExecutingDesigner AndAlso Not blnSetNextRow Then
                        '        chkDesignerCheckBox.Checked = False
                        '        If m_intNextRecord = -1 Then
                        '            intCurrentRowIndex = 0
                        '            m_blnAllowEditButton = True
                        '        Else
                        '            intCurrentRowIndex = m_intNextRecord
                        '            SetRowStatus(GridRowStatus.Editing, GridRowStatus.Editing, intCurrentRowIndex)
                        '            blnSetNextRow = True
                        '        End If
                        '        m_intSelectedRecord = m_intNextRecord
                        '        blnEditedDesigner = True
                        '    End If
                    End If

                    If intLastAppendedRow >= 0 AndAlso intItemIndex > intLastAppendedRow Then
                        'In case when append is terminated, reset the row status to the NotSet on all subsequent
                        'rows to the last appended row, except the very first subsequent row, for which set the
                        'status to UnChangeNew
                        If _
                            Not Me.NoAppend AndAlso
                            (.CurrentStatus = GridRowStatus.Adding OrElse .CurrentStatus = GridRowStatus.UnchangedNew OrElse
                             .CurrentStatus = GridRowStatus.NotSet) Then
                            If blnFirstEmptyRow Then
                                'This is first empty row to the recently appended Row
                                .SetBothStatus(GridRowStatus.UnchangedNew)
                                blnFirstEmptyRow = False
                            Else
                                .SetBothStatus(GridRowStatus.NotSet)
                            End If
                        End If
                    End If

                    'Get the Grid Record Status again after SetBothStatus
                    intCurrentStatus = .CurrentStatus


                End With


                Dim ctl As Control
                For Each ctl In row.GetDescendants(Of Control)()

                    Select Case ctl.GetType.ToString
                        Case "Core.Windows.UI.Core.Windows.UI.TextBox"
                            objTextBox = ctl
                            objTextBox.PrepareForDisplayInGrid((intCurrentRowIndex = intItemIndex),
                                                                blnClearCurrentRecordFields, Designer)
                        Case "Core.Windows.UI.Core.Windows.UI.DateControl"
                            objDateControl = ctl
                            objDateControl.PrepareForDisplayInGrid((intCurrentRowIndex = intItemIndex),
                                                                    blnClearCurrentRecordFields, Designer)

                        Case "Core.Windows.UI.Core.Windows.UI.ComboBox"
                            objComboBox = ctl
                            objComboBox.PrepareForDisplayInGrid((intCurrentRowIndex = intItemIndex),
                                                                blnClearCurrentRecordFields, Designer)
                    End Select
                Next

                If intCurrentStatus = GridRowStatus.Edited OrElse intCurrentStatus = GridRowStatus.Editing Then _
                blnOverRideAllowGridNew = False
                Dim objGridRowEditButton As GridButton
                Dim blnForEdit As Boolean
                objGridRowEditButton = row.GetDescendants(Of Control)("btnGridRowEdit").FirstOrDefault
                If m_intNextAppendInRow = intItemIndex Then
                    'With ApplicationState.Current.CorePage
                    '    If .m_strRequestedTarget.Trim.Length = 0 Then
                    '        'If there is no requested Target, Set requested target to the Append Button Click
                    '        .m_strRequestedTarget = objGridRowEditButton.Name()

                    '        ' Since we are setting the target for the next postback to be the append of the 
                    '        ' next row, check if we have Info or Warning messages that need to be displayed.
                    '        ' If so, store them in Session temporarily so that they can be displayed after
                    '        ' the Append() postback.
                    '        'If Not .HasError AndAlso .m_colMessages.Count > 0 Then
                    '        '    .GlobalSession("Messages") = .m_colMessages
                    '        'End If
                    '    End If
                    'End With

                    ApplicationState.Current.CorePage.NextControl = objGridRowEditButton

                    blnForEdit = True
                Else
                    blnForEdit = intCurrentRowIndex = intItemIndex
                End If

                Dim objRadioButton As RadioButton = row.GetDescendants(Of Control)("btnGridRowSelect").FirstOrDefault

                If Not IsNothing(objRadioButton) Then

                    If objGridRowEditButton.IsEnabled Then
                        objRadioButton.IsEnabled = True
                    Else
                        objRadioButton.IsEnabled = False
                    End If
                End If

                SetEditButtonImage(objGridRowEditButton, objRowStatus, blnForEdit, intItemIndex, m_intNextAppendInRow, row)
                SetDeleteButtonImage(row.GetDescendants(Of Control)("btnGridRowDelete").FirstOrDefault, objRowStatus)
                'End If
            Next

            'If m_blnDesignerMode And m_intNextRecord > 0 And blnEditedDesigner Then
            '    BindGridFieldsEvents(m_intNextRecord, False)
            '    m_blnBindGridEvents = False
            '    objDataListItem = GetDataListItem(m_intNextRecord)
            '    ApplicationState.Current.CorePage.RemoveFlags()
            '    RaiseDesignerEvents(objDataListItem, False)
            '    ApplicationState.Current.CorePage.PageActionType = PageActionType.NotSet
            '    blnEditedDesigner = False
            'End If


            AddPagination()

            DynamicallyAddedRows = False

            objCtl = Nothing
            objTextBox = Nothing
            objValidateTextBox = Nothing
            objDateControl = Nothing
            objValidateDateControl = Nothing
            objRowStatus = Nothing


            m_blnClearFields = False

        End Sub

        'PrepareGridControlsForDisplay enables or disables the controls depending on 
        'this procedure is being called from different methods
        ''' --- PrepareGridControlsForDisplay --------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of PrepareGridControlsForDisplay.
        ''' </summary>
        ''' <param name="Designer"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub PrepareGridControlsForDisplay(ByVal Designer As Designer)

            Dim objCtl As Control
            Dim objTextBox As System.Windows.Forms.TextBox
            'System.Web.UI.WebControls.TextBox
            Dim objValidateTextBox As System.Windows.Forms.TextBox
            'System.Web.UI.WebControls.TextBox
            Dim objDateControl As DateControl
            Dim objCheckBox As CheckBox
            Dim objComboBox As System.Windows.Forms.ComboBox
            'Dim objGridRadioButton As GridRadioButton
            Dim objValidateDateControl As DateControl
            Dim objRowStatus As RowStatus
            Dim intItemIndex As Integer = -1
            Dim intCurrentRowIndex As Integer
            Dim intCurrentStatus As GridRowStatus
            Dim blnClearCurrentRecordFields As Boolean
            'Dim objGridButtonCheck As WebControls.CheckBox

            'Check whether to display Blank Grid or not
            'If Me.Controls.Count = 0 Then
            '    'TODO: To identify all cases in which we need to display blank grid
            '    ' Ideally we need to handle such cases individually
            '    ' Untill we figure out all cases, we are displaying blank grid from here
            '    ShowGrid(True)
            '    'Display grid without any records
            'End If

            intItemIndex = -1
            intCurrentRowIndex = CurrentRowIndex
            If m_intToolbarAction = ToolbarIcons.Cancel Then
                m_blnClearFields = True
            ElseIf _
                m_intToolbarAction <> ToolbarIcons.Submit AndAlso
                ((ApplicationState.Current.CorePage.FindMode AndAlso ApplicationState.Current.CorePage.PageActionType = PageActionType.NotSet) OrElse
                 m_intToolbarAction = ToolbarIcons.Find) AndAlso
                (ApplicationState.Current.CorePage.HasPathRequestFields) Then
                'If called from Menu/other screen with Find Mode or if Click on Find on screen which HasPathRequestFields
                m_blnClearFields = True
            ElseIf m_intToolbarAction = ToolbarIcons.Add OrElse m_intGridAction = DataListActionTypes.GridNew Then
                m_blnEnableFirstRow = True
                m_blnClearFields = True
            End If
            AddPagination()

            Dim rows = GetDescendants(Of GridViewRowPresenter)()
            For Each objDataListItem As GridViewRowPresenter In rows

                If objDataListItem.GetType.ToString <> "Telerik.Windows.Controls.GridView.GridViewNewRow" Then

                    'intItemIndex = ItemContainerGenerator.IndexFromContainer(objDataListItem)
                    intItemIndex = GetRowIndex(Me, objDataListItem)
                    objRowStatus = CType(objDataListItem.GetDescendants(Of RowStatus)("btnGridRowStatus").FirstOrDefault(), RowStatus)

                    blnClearCurrentRecordFields = m_blnClearFields

                    'Get the Grid Record Status
                    intCurrentStatus = objRowStatus.CurrentStatus

                    ' Since the record is being saved, reset the 
                    ' status to UnchangedOld or NotSet if record is Deleted
                    If _
                        Me.m_intToolbarAction = ToolbarIcons.Submit AndAlso (Not m_blnHasError) AndAlso
                        (m_intPageMode = PageModeTypes.Entry OrElse m_intPageMode = PageModeTypes.Change) Then
                        Select Case intCurrentStatus
                            Case GridRowStatus.Added, GridRowStatus.Edited
                                SetRowStatus(GridRowStatus.UnchangedOld, GridRowStatus.UnchangedOld, intItemIndex)
                            Case GridRowStatus.Deleted
                                ' Record was deleted from grid, so ensure that we clear controls for the current row.
                                SetRowStatus(GridRowStatus.NotSet, GridRowStatus.NotSet, intItemIndex)
                                blnClearCurrentRecordFields = True
                        End Select
                    End If

                    With objRowStatus
                        If m_blnClearFields Then
                            If m_blnEnableFirstRow AndAlso intItemIndex = 0 Then
                                .SetBothStatus(GridRowStatus.Adding)
                            Else
                                .SetBothStatus(GridRowStatus.NotSet)
                            End If
                        End If
                        'Get the Grid Record Status again after SetBothStatus
                        intCurrentStatus = .CurrentStatus

                    End With

                    If intCurrentStatus = GridRowStatus.Adding Then ApplicationState.Current.CorePage.IsAppend = True

                    'For Each objCtl In objDataListItem.Controls
                    '    Select Case objCtl.GetType.ToString
                    '        Case "Core.Web.UI.Core.Web.UI.TextBox"
                    '            objTextBox = CType(objCtl, TextBox)
                    '            objTextBox.PrepareForDisplayInGrid((intCurrentRowIndex = intItemIndex), _
                    '                                                blnClearCurrentRecordFields, Designer)
                    '        Case "Core.Web.UI.Core.Web.UI.DateControl"
                    '            objDateControl = CType(objCtl, DateControl)
                    '            objDateControl.PrepareForDisplayInGrid((intCurrentRowIndex = intItemIndex), _
                    '                                                    blnClearCurrentRecordFields, Designer)
                    '        Case "Core.Web.UI.Core.Web.UI.CheckBox"
                    '            objCheckBox = CType(objCtl, CheckBox)
                    '            objCheckBox.PrepareForDisplayInGrid((intCurrentRowIndex = intItemIndex), _
                    '                                                 blnClearCurrentRecordFields, Designer)
                    '        Case "Core.Web.UI.Core.Web.UI.ComboBox"
                    '            objComboBox = CType(objCtl, ComboBox)
                    '            objComboBox.PrepareForDisplayInGrid((intCurrentRowIndex = intItemIndex), _
                    '                                                 blnClearCurrentRecordFields, Designer)
                    '        Case "Core.Web.UI.GridRadioButton"
                    '            objGridRadioButton = CType(objCtl, GridRadioButton)
                    '            With objGridRadioButton
                    '                If Not m_blnAllowSelectRowButton Then
                    '                    .Visible = False
                    '                Else
                    '                    .Enabled = _
                    '                        (intCurrentStatus = GridRowStatus.UnchangedOld OrElse _
                    '                         intCurrentStatus = GridRowStatus.Editing OrElse _
                    '                         intCurrentStatus = GridRowStatus.Edited OrElse _
                    '                         intCurrentStatus = GridRowStatus.Added)
                    '                    .Value = intItemIndex
                    '                    .Checked = (m_intSelectedRecord = intItemIndex)
                    '                End If
                    '            End With

                    '        Case "System.Web.UI.WebControls.CheckBox"
                    '            objGridButtonCheck = CType(objCtl, WebControls.CheckBox)
                    '            With objGridButtonCheck
                    '                If Not AllowSelectRowButton OrElse Not Me.m_blnUsingAcceptProcessing Then
                    '                    .Visible = False
                    '                    .Checked = False
                    '                Else
                    '                    .Enabled = _
                    '                        (intCurrentStatus = GridRowStatus.UnchangedOld OrElse _
                    '                         intCurrentStatus = GridRowStatus.Editing OrElse _
                    '                         intCurrentStatus = GridRowStatus.Edited OrElse _
                    '                         intCurrentStatus = GridRowStatus.Added)
                    '                    If Not .Enabled Then .Checked = False
                    '                End If
                    '            End With
                    '    End Select
                    'Next

                    'SetEditButtonImage(CType(objDataListItem.FindControl("btnGridRowEdit"), GridButton), objRowStatus, _
                    '                    intCurrentRowIndex = intItemIndex)
                    'SetDeleteButtonImage(CType(objDataListItem.FindControl("btnGridRowDelete"), GridButton), objRowStatus)
                End If
            Next
            'If intCurrentStatus = GridRowStatus.UnchangedOld Then

            'End If
            objCtl = Nothing
            objTextBox = Nothing
            objValidateTextBox = Nothing
            objDateControl = Nothing
            objValidateDateControl = Nothing
            objRowStatus = Nothing
            ApplicationState.Current.CorePage.IsAppend = False
        End Sub

        ''' --- BindGridFields -----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of BindGridFields.
        ''' </summary>
        ''' <param name="RowPosition"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub BindGridFields(ByVal RowPosition As Integer)
            'Note: Should not be called from out side the framework
            'At present gets called in response to BindGridFields event on the page,
            'which in turn gets fired from the FOR loop on Page, File or Temporary

            ' Changed Display parameter to False since the SetOccurrence (which is called 
            ' from the BREAK verb as well as other places) should not force the row to have
            ' the DISPLAY verb called.  The user must explicitly code a display. 
            ' Changed on 2005/10/31
            BindGridFieldsEvents(RowPosition, False)

        End Sub

        ''' --- BindGridFieldsEvents -----------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of BindGridFieldsEvents.
        ''' </summary>
        ''' <param name="DataListItemIndex"></param>
        ''' <param name="Display"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub BindGridFieldsEvents(ByVal DataListItemIndex As Integer, ByVal Display As Boolean)
            'Set occurrance for the Arrays which occurs with the cluster
            If DataListItemIndex >= 0 AndAlso DataListItemIndex < Occurs AndAlso Not GetDataListItem(DataListItemIndex) Is Nothing Then
                ApplicationState.Current.CorePage.m_intOccurrence = DataListItemIndex
                BindGridFieldsEvents(GetDataListItem(DataListItemIndex), Display)
            Else
                'We may need to add/remove code to handle this case
                'Throw New Exception("Invalid ItemIndex")
            End If
        End Sub

        ''' --- BindGridFieldsEvents -----------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of BindGridFieldsEvents.
        ''' </summary>
        ''' <param name="DataListItem"></param>
        ''' <param name="Display"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub BindGridFieldsEvents(ByVal DataListItem As GridViewRowPresenter, ByVal Display As Boolean)
            Dim objCtl As Control
            Dim objLabel As TextBlock
            Dim objTextBox As TextBox
            Dim objDateControl As DateControl
            Dim objCheckBox As CheckBox
            Dim objComboBox As ComboBox
            Dim objValidateDateControl As DateControl
            Dim objValidateTextBox As TextBox
            Dim objValidateCheckBox As CheckBox
            Dim objValidateComboBox As ComboBox
            Dim blnCalledFind As Boolean
            Dim intItemIndex As Integer
            Dim colControls As Collection = New Collection
            ' Store a reference to the controls that need DISPLAY validation.

            blnCalledFind = ApplicationState.Current.CorePage.m_blnCallFind


            'Set occurrance for the Arrays which occurs with the cluster
            'intItemIndex = ItemContainerGenerator.IndexFromContainer(DataListItem)
            intItemIndex = GetRowIndex(Me, DataListItem)

            If _
                intItemIndex > 0 AndAlso
                ((Not blnCalledFind) AndAlso Me.IsSelectProcessing AndAlso Me.m_intToolbarAction <> ToolbarIcons.Submit) AndAlso
                Not ApplicationState.Current.CorePage.IsFunctionKey Then
                m_blnBlankControlsInUndefinedRows = True
            Else
                m_blnBlankControlsInUndefinedRows = False
            End If

            ApplicationState.Current.CorePage.m_intOccurrence = intItemIndex

            For Each objCtl In DataListItem.GetDescendants(Of TextBox)()
                objTextBox = CType(objCtl, TextBox)
                objValidateTextBox = Nothing
                'objValidateTextBox = objTextBox
                If m_blnBlankControlsInUndefinedRows Then
                    With objTextBox
                        .ClearValues()

                        'For performance reasons we don't load dictionary values on undefined rows
                        'if we ever decide to populate dictionary values for undefined rows uncomment following line
                        'May 19, 2005
                        'June 6, 2005 We need to roll back this as it is required in Find with Path that has request on Grid Field
                        If Not m_blnDictionaryLoaded Then .LoadValues()
                    End With

                    'For performance reasons we don't call GetGridFieldObject on undefined rows
                    'if we ever decide to call it uncomment following line block of code
                    'May 19, 2005
                    'June 6, 2005 We need to roll back this as it is required in Find with Path that has request on Grid Field
                    'Oct 6, 2005  Added code to bind the row if the screen is called in Entry mode.
                    If _
                        intItemIndex = 0 AndAlso
                        (IsSelectProcessing() OrElse
                         (ApplicationState.Current.CorePage.Mode = PageModeTypes.Entry AndAlso
                          ApplicationState.Current.CorePage.NavigationType = NavigationTypes.None)) Then

                        Try
                            GetGridFieldObject(objTextBox, objValidateTextBox, objTextBox.Name)
                        Catch ex As CustomApplicationException
                            Throw ex
                        Catch ex As Exception
                            ExceptionManager.Publish(ex)
                            Throw ex
                        End Try
                        AddHandler objValidateTextBox.DataChanged, AddressOf Control_Changed
                    End If
                Else

                    Try
                        GetGridFieldObject(objTextBox, objValidateTextBox, objTextBox.Name)
                    Catch ex As CustomApplicationException
                        Throw ex
                    Catch ex As Exception
                        ExceptionManager.Publish(ex)
                        Throw ex
                    End Try
                    AddHandler objValidateTextBox.DataChanged, AddressOf Control_Changed

                    If Display Then
                        'We need to load default values from dictionary 
                        'e.g. During First Request, Pagination, Find etc.
                        objValidateTextBox.LoadValues()

                        ' Add the control to the collection.  This is done in 
                        ' case we have a DISPLAY verb inside an OUTPUT procedure of the 
                        ' current control which sets a value in the next control.  The 
                        ' next control has not been fetched, so it will point to the 
                        ' previous record in the grid.  Add the ID as part of the key to 
                        ' keep the key unique.
                        colControls.Add(objValidateTextBox, "T:" + objValidateTextBox.Name)
                    End If
                End If
            Next

            For Each objCtl In DataListItem.GetDescendants(Of TextBlock)()
                objLabel = CType(objCtl, TextBlock)
                If objLabel.Name = "RecordNo" Then
                    If (ApplicationState.Current.CorePage.CurrentPageNumber > 0) Then
                        objLabel.Text = intItemIndex + 1 + ((ApplicationState.Current.CorePage.CurrentPageNumber - 1) * Occurs)
                    Else
                        objLabel.Text = intItemIndex + 1
                    End If
                End If

            Next

            For Each objCtl In DataListItem.GetDescendants(Of DatePicker)()
                objDateControl = CType(objCtl, DateControl)
                objValidateDateControl = Nothing
                If m_blnBlankControlsInUndefinedRows Then
                    With objDateControl
                        .ClearValues()

                        'For performance reasons we don't load dictionary values on undefined rows
                        'if we ever decide to populate dictionary values for undefined rows uncomment following line
                        'May 19, 2005
                        'June 6, 2005 We need to roll back this as it is required in Find with Path that has request on Grid Field
                        If Not m_blnDictionaryLoaded Then .LoadValues()
                    End With

                    'For performance reasons we don't call GetGridFieldObject on undefined rows
                    'if we ever decide to call it uncomment following line block of code
                    'May 19, 2005
                    'June 6, 2005 We need to roll back this as it is required in Find with Path that has request on Grid Field
                    'Oct 6, 2005  Added code to bind the row if the screen is called in Entry mode.
                    If _
                        intItemIndex = 0 AndAlso
                        (IsSelectProcessing() OrElse
                         (ApplicationState.Current.CorePage.Mode = PageModeTypes.Entry AndAlso
                          ApplicationState.Current.CorePage.NavigationType = NavigationTypes.None)) Then

                        Try
                            GetGridFieldObject(objDateControl, objValidateDateControl, objDateControl.Name)
                        Catch ex As CustomApplicationException
                            Throw ex
                        Catch ex As Exception
                            ExceptionManager.Publish(ex)
                            Throw ex
                        End Try
                        AddHandler objValidateDateControl.DataChanged, AddressOf Control_Changed
                    End If
                Else

                    Try
                        GetGridFieldObject(objDateControl, objValidateDateControl, objDateControl.Name)
                    Catch ex As CustomApplicationException
                        Throw ex
                    Catch ex As Exception
                        ExceptionManager.Publish(ex)
                        Throw ex
                    End Try
                    AddHandler objValidateDateControl.DataChanged, AddressOf Control_Changed
                    If Display Then
                        'We need to load default values from dictionary 
                        'e.g. During First Request, Pagination, Find etc.
                        objValidateDateControl.LoadValues()

                        ' Add the control to the collection.  This is done in 
                        ' case we have a DISPLAY verb inside an OUTPUT procedure of the 
                        ' current control which sets a value in the next control.  The 
                        ' next control has not been fetched, so it will point to the 
                        ' previous record in the grid.  Add the ID as part of the key to 
                        ' keep the key unique.
                        colControls.Add(objValidateDateControl, "T:" + objValidateDateControl.Name)
                    End If
                End If
            Next

            For Each objCtl In DataListItem.GetDescendants(Of ComboBox)()
                objComboBox = CType(objCtl, ComboBox)
                objValidateComboBox = Nothing
                If m_blnBlankControlsInUndefinedRows Then
                    With objComboBox
                        .ClearValues()

                        'For performance reasons we don't load dictionary values on undefined rows
                        'if we ever decide to populate dictionary values for undefined rows uncomment following line
                        'May 19, 2005
                        'June 6, 2005 We need to roll back this as it is required in Find with Path that has request on Grid Field
                        If Not m_blnDictionaryLoaded Then .LoadValues()
                    End With

                    'For performance reasons we don't call GetGridFieldObject on undefined rows
                    'if we ever decide to call it uncomment following line block of code
                    'May 19, 2005
                    'June 6, 2005 We need to roll back this as it is required in Find with Path that has request on Grid Field
                    'Oct 6, 2005  Added code to bind the row if the screen is called in Entry mode.
                    If _
                        intItemIndex = 0 AndAlso
                        (IsSelectProcessing() OrElse
                         (ApplicationState.Current.CorePage.Mode = PageModeTypes.Entry AndAlso
                          ApplicationState.Current.CorePage.NavigationType = NavigationTypes.None)) Then

                        Try
                            GetGridFieldObject(objComboBox, objValidateDateControl, objComboBox.Name)
                        Catch ex As CustomApplicationException
                            Throw ex
                        Catch ex As Exception
                            ExceptionManager.Publish(ex)
                            Throw ex
                        End Try
                        AddHandler objValidateDateControl.DataChanged, AddressOf Control_Changed
                    End If
                Else

                    Try
                        GetGridFieldObject(objComboBox, objValidateComboBox, objComboBox.Name)
                    Catch ex As CustomApplicationException
                        Throw ex
                    Catch ex As Exception
                        ExceptionManager.Publish(ex)
                        Throw ex
                    End Try
                    AddHandler objValidateComboBox.DataChanged, AddressOf Control_Changed
                    If Display Then
                        'We need to load default values from dictionary 
                        'e.g. During First Request, Pagination, Find etc.
                        objValidateComboBox.LoadValues()

                        ' Add the control to the collection.  This is done in 
                        ' case we have a DISPLAY verb inside an OUTPUT procedure of the 
                        ' current control which sets a value in the next control.  The 
                        ' next control has not been fetched, so it will point to the 
                        ' previous record in the grid.  Add the ID as part of the key to 
                        ' keep the key unique.
                        colControls.Add(objValidateComboBox, "T:" + objValidateComboBox.Name)
                    End If
                End If
            Next





            If Display Then
                Dim objGridRowStatus As RowStatus = GetStatus(DataListItem)
                ' Loop through the controls collection and call the DISPLAY validation now.

                If objGridRowStatus.CurrentStatus <> GridRowStatus.NotSet AndAlso objGridRowStatus.CurrentStatus <> GridRowStatus.UnchangedNew Then
                    For intcount As Integer = 1 To colControls.Count
                        Try
                            ApplicationState.Current.CorePage.Validate(colControls(intcount), ValidateTypes.Display)
                        Catch ex As Exception

                        End Try

                    Next
                End If


            End If

            objCtl = Nothing
            objTextBox = Nothing
            objCheckBox = Nothing
            objComboBox = Nothing
            objValidateTextBox = Nothing
            objValidateDateControl = Nothing
            objValidateCheckBox = Nothing
            objValidateComboBox = Nothing

            If intItemIndex + 1 = Occurs Then
                PrepareGridControlsForDisplay()
            End If
        End Sub

        ''' --- IsSelectProcessing -------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of IsSelectProcessing.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function IsSelectProcessing() As Boolean
            'This method is used to enable first row for user input depending on whether:
            '- Page is in Find Mode (either opened first time from calling screen with "Find" mode or Clicked on "Find" in the toolbar)
            '- and whether this is an AcceptProcessing or not
            '- and HasPathRequestFields or HasSelectProcessing propeties on page is set to True or not
            With ApplicationState.Current.CorePage
                Return _
                    (.Mode = PageModeTypes.Find OrElse .ToolbarAction = ToolbarIcons.Find) AndAlso
                    Me.m_blnUsingAcceptProcessing AndAlso (.HasPathRequestFields)
            End With
        End Function

        ''' --- Control_Changed ----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Control_Changed.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub Control_Changed(ByVal sender As Object, ByVal e As EventArgs)
            Dim objDataListItem As GridViewRowPresenter
            Dim objNextDataListItem As GridViewRowPresenter
            Dim objGridRowStatus As RowStatus
            Dim objGridRowEdit As GridButton
            Dim intCurrentStatus As GridRowStatus
            Dim intPreviousStatus As GridRowStatus
            Dim intItemIndex As Integer
            ' I need to reach into the DataListItem, which is usually the container
            ' (parent) of sender, the control that initiates the Edit event. 
            ' When sender is a Calendar, I need to go one step further
            ' (parent.parent).
            'If TypeOf sender Is WebControls.Calendar Then
            '    objDataListItem = sender.parent.parent
            'Else
            'objDataListItem = DirectCast(sender, Control).ParentOfType(Of GridViewRowPresenter)()

            objDataListItem = DirectCast(sender, Control).ParentOfType(Of GridViewRowPresenter)()

            'objDataListItem = sender.parent

            'End If
            'Get the Previous and Current status for the row
            objGridRowStatus = GetStatus(objDataListItem)
            With objGridRowStatus
                intCurrentStatus = .CurrentStatus
                intPreviousStatus = .PreviousStatus
            End With

            If intCurrentStatus = GridRowStatus.Adding OrElse intCurrentStatus = GridRowStatus.Editing Then
                SetRowStatus(GridRowStatusCommand.Change, objDataListItem)
                If intCurrentStatus = GridRowStatus.Adding Then
                    'TODO: Enable next record for add
                    'intItemIndex = ItemContainerGenerator.IndexFromContainer(objDataListItem)
                    intItemIndex = GetRowIndex(Me, objDataListItem)
                    If (Not NoAppend) AndAlso Occurs > (intItemIndex + 1) Then
                        objNextDataListItem = GetDataListItem(intItemIndex + 1)
                        objGridRowEdit = objNextDataListItem.GetDescendants(Of Control)("btnGridRowEdit").FirstOrDefault
                        objGridRowStatus = GetStatus(objNextDataListItem)
                        ' Set Next Row's Status as "UnchangedNew" so that user can a add new record
                        objGridRowStatus.CurrentStatus = GridRowStatus.UnchangedNew
                        objGridRowStatus.PreviousStatus = GridRowStatus.UnchangedNew
                        'Set next row's edit button image to Add New and enable it depending on NoAppend property
                        SetEditButtonImage(objGridRowEdit, objGridRowStatus, False, objDataListItem)
                    End If
                End If
            End If
            objDataListItem = Nothing
            objNextDataListItem = Nothing
            objGridRowStatus = Nothing
            objGridRowEdit = Nothing
            intCurrentStatus = Nothing
            intPreviousStatus = Nothing
        End Sub

        ' Used for Accept Processing.
        ''' --- Control_Changed ----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Control_Changed.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub Control_Changed(ByVal sender As Object)
            Dim objDataListItem As GridViewRowPresenter
            Dim objNextDataListItem As GridViewRowPresenter
            Dim objGridRowStatus As RowStatus
            Dim objGridRowEdit As GridButton
            Dim intCurrentStatus As GridRowStatus
            Dim intPreviousStatus As GridRowStatus
            Dim intItemIndex As Integer


            ' I need to reach into the DataListItem, which is usually the container
            ' (parent) of sender, the control that initiates the Edit event. 
            ' When sender is a Calendar, I need to go one step further
            ' (parent.parent).
            'If TypeOf sender Is WebControls.Calendar Then
            '    objDataListItem = sender.parent.parent
            'Else
            objDataListItem = sender.parent
            'End If
            'Get the Previous and Current status for the row
            objGridRowStatus = GetStatus(objDataListItem)
            With objGridRowStatus
                intCurrentStatus = .CurrentStatus
                intPreviousStatus = .PreviousStatus
            End With

            If intCurrentStatus = GridRowStatus.Adding OrElse intCurrentStatus = GridRowStatus.Editing Then
                SetRowStatus(GridRowStatusCommand.Change, objDataListItem)
                If intCurrentStatus = GridRowStatus.Adding Then
                    'TODO: Enable next record for add
                    'intItemIndex = ItemContainerGenerator.IndexFromContainer(objDataListItem)
                    intItemIndex = GetRowIndex(Me, objDataListItem)

                    If (Not NoAppend) AndAlso Occurs > (intItemIndex + 1) Then
                        objNextDataListItem = Items.Item(intItemIndex + 1)
                        objGridRowEdit = objNextDataListItem.GetDescendants(Of Control)("btnGridRowEdit").FirstOrDefault
                        objGridRowStatus = GetStatus(objNextDataListItem)
                        ' Set Next Row's Status as "UnchangedNew" so that user can a add new record
                        objGridRowStatus.CurrentStatus = GridRowStatus.UnchangedNew
                        objGridRowStatus.PreviousStatus = GridRowStatus.UnchangedNew
                        'Set next row's edit button image to Add New and enable it depending on NoAppend property
                        SetEditButtonImage(objGridRowEdit, objGridRowStatus, False, objDataListItem)
                    End If
                End If
            End If
            objDataListItem = Nothing
            objNextDataListItem = Nothing
            objGridRowStatus = Nothing
            objGridRowEdit = Nothing
            intCurrentStatus = Nothing
            intPreviousStatus = Nothing
        End Sub

        ''' --- AddPagination ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of AddPagination.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub AddPagination()
            Try




                Dim intTotalRecords As Integer
                Dim intTotalRecordsProcessed As Integer
                Dim intOccurs As Integer
                Dim intTotalPages As Integer
                Dim intTotalPageSets As Integer
                Dim intCurrentPageSetNumber As Integer
                Dim blnAddPageSetLink As Boolean
                Dim blnShowPaginate As Boolean
                Dim objDataListItem As DataGridRow
                Dim ptPaginationType As PaginationTypes

                Dim objPaginationControl As Control
                Dim objPageButtonDefaultBorder As System.Drawing.Color
                'objPageButtonDefaultBorder = Me.HeaderStyle.BackColor
                If objPageButtonDefaultBorder.Name = "0" Then
                    objPageButtonDefaultBorder = System.Drawing.Color.White
                End If

                objPaginationControl = New Control

                'There should always be a Header as the first item in Controls collection
                'objDataListItem = CType(Me.Controls(0), DataListItem)
                intTotalRecords = ApplicationState.Current.CorePage.TotalGridRecords
                intOccurs = Occurs

                With ApplicationState.Current.CorePage
                    intTotalRecordsProcessed = .TotalRecordsProcessed
                    ptPaginationType = .PaginationType

                    If intTotalRecords > 0 AndAlso intOccurs > 0 Then
                        intTotalPages = (intTotalRecords / intOccurs)
                        If intTotalRecords > (intTotalPages * intOccurs) Then
                            intTotalPages += 1
                        End If
                        intTotalPageSets = Me.GetTotalPageSets(intTotalPages)
                    Else
                        intTotalPages = 0
                        intTotalPageSets = 0
                    End If

                    If ptPaginationType <> PaginationTypes.FirstNextOnly Then
                        If Not m_blnKeepPaginationPage Then
                            .CurrentPageNumber = 1
                            .CurrentPageSetNumber = 1
                        End If
                        m_intCurrentPageNumber = .CurrentPageNumber
                        If m_intCurrentPageNumber <= 0 Then m_intCurrentPageNumber = 1
                        If m_intCurrentPageNumber > intTotalPages Then m_intCurrentPageNumber = 1

                        intCurrentPageSetNumber = .CurrentPageSetNumber
                        If intCurrentPageSetNumber <= 0 Then intCurrentPageSetNumber = 1

                        If intTotalPages > 10 Then
                            blnAddPageSetLink = True
                        End If

                        .TotalPageSets = intTotalPageSets
                    End If

                    If (.Mode = PageModeTypes.Change OrElse .m_blnCallFind) AndAlso
                       (.ToolbarAction <> ToolbarIcons.Cancel AndAlso .ToolbarAction <> ToolbarIcons.Add _
                        AndAlso .ToolbarAction <> ToolbarIcons.Delete) AndAlso
                       (Not m_blnClearFields) OrElse (Me.m_blnUsingAcceptProcessing AndAlso ApplicationState.Current.CorePage.IsPathComplete) _
                        Then
                        blnShowPaginate = True
                    Else
                        blnShowPaginate = False
                    End If
                End With

                EnableGridNew(objDataListItem)

                Dim i As Integer
                Dim intNoOfPages As String
                If blnShowPaginate Then
                    Dim intStartPageNo As Integer
                    Dim intEndPageNo As Integer

                    If ptPaginationType <> PaginationTypes.FirstNextOnly Then
                        intStartPageNo = ((intCurrentPageSetNumber - 1) * 10) + 1
                        intEndPageNo = intStartPageNo + 9

                        If intEndPageNo > intTotalPages Then intEndPageNo = intTotalPages

                        If intTotalPages < 10 Then
                            intNoOfPages = intTotalPages
                        Else
                            intNoOfPages = 10
                        End If
                    End If

                    'objPaginationControl.Controls.Add( _
                    '                                   New LiteralControl( _
                    '                                                       "<TABLE vAlign ='middle' width='100%'><TR><TD>"))
                    'objPaginationControl.Controls.Add( _
                    '                                   New LiteralControl( _
                    '                                                       "   Pages: " + m_strPadSpaces + _
                    '                                                       m_strPadSpaces + m_strPadSpaces))

                    Select Case ptPaginationType
                        Case PaginationTypes.FirstNextOnly
                            'Enable links to First and Next page only in case the form needs to bypass
                            'records with an error in Find/DetailFind
                            'AddPageLink(objPaginationControl, "First", "FirstNextOnly", objPageButtonDefaultBorder, _
                            '             (intTotalRecordsProcessed > 0), objShortCutKeyPaginate)
                            ''Link to First Page in a Grid
                            'AddPageLink(objPaginationControl, "Next", "FirstNextOnly", objPageButtonDefaultBorder, _
                            '             (intTotalRecordsProcessed > 0 AndAlso _
                            '              intTotalRecordsProcessed < intTotalRecords), objShortCutKeyPaginate)
                            'Link to Next Page in a Grid
                        Case PaginationTypes.Default
                            For i = intStartPageNo To intEndPageNo
                                'AddPageLink(objPaginationControl, i.ToString, "Page", objPageButtonDefaultBorder, True, _
                                '             objShortCutKeyPaginate)
                                'Individual Page Link
                            Next

                            'If blnAddPageSetLink Then
                            '    objPaginationControl.Controls.Add( _
                            '                                       New LiteralControl( _
                            '                                                           m_strPadSpaces + m_strPadSpaces + _
                            '                                                           m_strPadSpaces + "Sets:"))
                            '    AddPageLink(objPaginationControl, "First", "PageSet", objPageButtonDefaultBorder, _
                            '                 (intCurrentPageSetNumber <> 1), objShortCutKeyPaginate)
                            '    'First Page Set
                            '    AddPageLink(objPaginationControl, "Last", "PageSet", objPageButtonDefaultBorder, _
                            '                 (intCurrentPageSetNumber <> intTotalPageSets), objShortCutKeyPaginate)
                            '    'Last Page Set
                            '    AddPageLink(objPaginationControl, "Previous", "PageSet", objPageButtonDefaultBorder, _
                            '                 (intCurrentPageSetNumber <> 1), objShortCutKeyPaginate)
                            '    'Previous Page Set
                            '    AddPageLink(objPaginationControl, "Next", "PageSet", objPageButtonDefaultBorder, _
                            '                 (intCurrentPageSetNumber <> intTotalPageSets), objShortCutKeyPaginate)
                            '    'Next Page SetEnd If
                            'End If
                    End Select

                    'Dim txtTotalGridPages As New WebControls.Label
                    'Dim txtCurrentGridPage As New WebControls.TextBox

                    'With objPaginationControl
                    '    If blnShowPaginate And Not ptPaginationType = PaginationTypes.FirstNextOnly Then
                    '        Dim strPages As String
                    '        If intTotalPages = 1 Then
                    '            strPages = " Page"
                    '        Else
                    '            strPages = " Pages"
                    '        End If
                    '        .Controls.Add(New LiteralControl("</TD><TD align='right'>"))
                    '        .Controls.Add( _
                    '                       New LiteralControl( _
                    '                                           m_strPadSpaces + m_strPadSpaces + m_strPadSpaces + _
                    '                                           "Total " + intTotalPages.ToString + strPages))
                    '    End If
                    '    .Controls.Add(New LiteralControl("</TD></TR></TABLE>"))
                    '    '</TD></TR><TR><TD>"))
                    'End With
                Else
                    'objPaginationControl.Controls.Add( _
                    '                                   New LiteralControl( _
                    '                                                       "<TABLE vAlign ='middle' width='100%'><TR><TD><BR></TD></TR></TABLE>"))
                End If

                'objDataListItem.Controls.AddAt(0, objPaginationControl)
                objDataListItem = Nothing



                'If (intTotalPages > 0) Then
                '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "PaginateKey", _
                '                                                 objShortCutKeyPaginate.ToString)
                'End If


            Catch ex As CustomApplicationException

                Throw ex

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Sub

        ''' --- AddPageLink --------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of AddPageLink.
        ''' </summary>
        ''' <param name="container"></param>
        ''' <param name="Label"></param>
        ''' <param name="CommandName"></param>
        ''' <param name="BorderColor"></param>
        ''' <param name="EnableLink"></param>
        ''' <param name="objShortCutKeyPaginate"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        '<EditorBrowsable(EditorBrowsableState.Advanced)> _
        'Private Sub AddPageLink(ByVal container As Control, ByVal Label As String, ByVal CommandName As String, _
        '                         ByVal BorderColor As Color, ByVal EnableLink As Boolean, _
        '                         ByVal objShortCutKeyPaginate As StringBuilder)

        '    Dim lnkPage As New PaginationLink(Label, CommandName, "Pagination" + Label, BorderColor)

        '    If m_strPadSpaces = "" Then
        '        m_strPadSpaces = "&nbsp;&nbsp;&nbsp;"
        '    Else
        '        container.Controls.Add(New LiteralControl(m_strPadSpaces))
        '    End If
        '    Select Case CommandName
        '        Case "FirstNextOnly"
        '            If Not EnableLink Then
        '                lnkPage.Enabled = False
        '            Else
        '                With objShortCutKeyPaginate
        '                    .Append("if ((event.ctrlLeft || event.ctrlKey) && event.keyCode == cGrid").Append( _
        '                                                                                                        Label. _
        '                                                                                                           ToString) _
        '                        .Append("){").Append(vbNewLine)
        '                    .Append(" document.all.").Append(Me.Name.Replace("$"c, "$"c)).Append("_ctl00_lnk"). _
        '                        Append(Label.ToString).Append(".focus();").Append(vbNewLine)
        '                    .Append("            blnExecutingProcedure=true;").Append(vbNewLine)
        '                    .Append("            javascript:Pageunload();").Append(vbNewLine)
        '                    .Append("            ContinuePostback('").Append(Me.Name.Replace("$"c, "$"c)).Append( _
        '                                                                                                                 "$ctl00$lnk") _
        '                        .Append(Label.ToString).Append("', '").Append(lnkPage.CommandArgument).Append("~"). _
        '                        Append(lnkPage.CommandName).Append("')").Append(vbNewLine)
        '                    .Append("            event.keyCode = 0;").Append(vbNewLine)
        '                    .Append("            event.returnValue = false;}").Append(vbNewLine)
        '                End With
        '            End If
        '            container.Controls.Add(lnkPage)
        '        Case "Page"
        '            If CInt(Label) = m_intCurrentPageNumber Then
        '                container.Controls.Add( _
        '                                        New LiteralControl( _
        '                                                            "<span class='ActivePage'>&nbsp;" + Label.ToString + _
        '                                                            "&nbsp;</span>"))
        '            Else
        '                container.Controls.Add(lnkPage)

        '                With objShortCutKeyPaginate
        '                    .Append("if ((event.ctrlLeft || event.ctrlKey) && event.keyCode == cGrid").Append( _
        '                                                                                                        Right( _
        '                                                                                                               Label _
        '                                                                                                                  . _
        '                                                                                                                  ToString, _
        '                                                                                                               1)) _
        '                        .Append("){").Append(vbNewLine)
        '                    .Append(" document.all.").Append(Me.Name.Replace("$"c, "$"c)).Append("_ctl00_lnk"). _
        '                        Append(Label.ToString).Append(".focus();").Append(vbNewLine)
        '                    .Append("            blnExecutingProcedure=true;").Append(vbNewLine)
        '                    .Append("            javascript:Pageunload();").Append(vbNewLine)
        '                    .Append("            ContinuePostback('").Append(Me.Name.Replace("$"c, "$"c)).Append( _
        '                                                                                                                 "$ctl00$lnk") _
        '                        .Append(Label.ToString).Append("', '").Append(lnkPage.CommandArgument).Append("~"). _
        '                        Append(lnkPage.CommandName).Append("')").Append(vbNewLine)
        '                    .Append("            event.keyCode = 0;").Append(vbNewLine)
        '                    .Append("            event.returnValue = false;}").Append(vbNewLine)
        '                End With
        '            End If
        '        Case Else
        '            '"Page Set" Link
        '            If Not EnableLink Then
        '                lnkPage.Enabled = False
        '            Else
        '                With objShortCutKeyPaginate
        '                    If IsNumeric(Label.ToString) Then
        '                        .Append("if ((event.ctrlLeft || event.ctrlKey) && event.keyCode == cGrid").Append( _
        '                                                                                                            Right( _
        '                                                                                                                   Label _
        '                                                                                                                      . _
        '                                                                                                                      ToString, _
        '                                                                                                                   1)) _
        '                            .Append("){").Append(vbNewLine)
        '                    Else
        '                        .Append("if ((event.ctrlLeft || event.ctrlKey) && event.keyCode == cGrid").Append( _
        '                                                                                                            Label _
        '                                                                                                               . _
        '                                                                                                               ToString) _
        '                            .Append("){").Append(vbNewLine)
        '                    End If
        '                    .Append(" document.all.").Append(Me.Name.Replace("$"c, "$"c)).Append("_ctl00_lnk"). _
        '                        Append(Label.ToString).Append(".focus();").Append(vbNewLine)
        '                    .Append("            blnExecutingProcedure=true;").Append(vbNewLine)
        '                    .Append("            javascript:Pageunload();").Append(vbNewLine)
        '                    .Append("            ContinuePostback('").Append(Me.Name.Replace("$"c, "$"c)).Append( _
        '                                                                                                                 "$ctl00$lnk") _
        '                        .Append(Label.ToString).Append("', '").Append(lnkPage.CommandArgument).Append("~"). _
        '                        Append(lnkPage.CommandName).Append("')").Append(vbNewLine)
        '                    .Append("            event.keyCode = 0;").Append(vbNewLine)
        '                    .Append("            event.returnValue = false;}").Append(vbNewLine)
        '                End With
        '            End If
        '            container.Controls.Add(lnkPage)
        '    End Select
        'End Sub

        ''' --- GoToGridPage -------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GoToGridPage.
        ''' </summary>
        ''' <param name="NewPageNumber"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function GoToGridPage(ByRef NewPageNumber As Integer)
            Dim intNewRecordNumber As Integer
            Dim intTotalPages As Integer

            'TODO: Before Paginating, a client script should prompt user, when changes made in a screen

            intTotalPages = GetTotalPages()

            If NewPageNumber <= 0 Then NewPageNumber = 1

            If NewPageNumber > intTotalPages Then NewPageNumber = intTotalPages

            With ApplicationState.Current.CorePage
                intNewRecordNumber = ((NewPageNumber - 1) * Me.Occurs)
                If intNewRecordNumber = 0 Then intNewRecordNumber = -1
                If .ScreenType = ScreenTypes.Grid Then ' Grid Only
                    .GridRecordNumber = intNewRecordNumber
                    m_blnKeepPaginationPage = True
                Else ' ScreenTypes.Composite;  A Primary Detail Screen 
                    .GridRecordNumber = intNewRecordNumber + 1
                    ' Following we are issuing NavigationType.Next, 
                    ' and calling Perform Operation to call Find 
                    .CurrentRecordNumber -= 1
                    m_blnKeepPaginationPage = True
                End If
                .CurrentPageNumber = NewPageNumber
                .NavigationType = NavigationTypes.Next
                .Mode = PageModeTypes.Find
                .ResetAppendVariables()
                .RecordsForLoop = 0
                ' Reset the records in the loop.
            End With
            Return Nothing
        End Function

        ''' --- GoToGridPageSet ----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GoToGridPageSet.
        ''' </summary>
        ''' <param name="NewPageSetNumber"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function GoToGridPageSet(ByVal NewPageSetNumber As Integer)
            Dim intNewPageNumber As Integer

            Dim intTotalPages As Integer
            Dim intTotalPageSets As Integer

            intTotalPages = GetTotalPages()
            intTotalPageSets = GetTotalPageSets()

            If NewPageSetNumber <= 0 Then NewPageSetNumber = 1
            If NewPageSetNumber > intTotalPageSets Then NewPageSetNumber = intTotalPageSets

            intNewPageNumber = ((NewPageSetNumber - 1) * 10) + 1
            ApplicationState.Current.CorePage.CurrentPageSetNumber = NewPageSetNumber
            ApplicationState.Current.CorePage.TotalPageSets = intTotalPageSets

            GoToGridPage(intNewPageNumber)
            Return Nothing
        End Function

        ''' --- GoToNextGridPage ---------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GoToNextGridPage.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function GoToNextGridPage()
            With ApplicationState.Current.CorePage
                If .ScreenType = ScreenTypes.Grid Then ' Grid Only
                    '.GridRecordNumber = intNewRecordNumber
                    m_blnKeepPaginationPage = True
                Else ' ScreenTypes.Composite;  A Primary Detail Screen 
                    '.GridRecordNumber = intNewRecordNumber + 1
                    ' Following we are issuing NavigationType.Next, 
                    ' and calling Perform Operation to call Find 
                    .CurrentRecordNumber -= 1
                    m_blnKeepPaginationPage = True
                End If
                '.CurrentPageNumber = NewPageNumber
                .NavigationType = NavigationTypes.Next
                .Mode = PageModeTypes.Find
                .ResetAppendVariables()
            End With
            Return Nothing
        End Function

        ''' --- GetTotalPages ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetTotalPages.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function GetTotalPages() As Integer
            Return GetTotalPages(ApplicationState.Current.CorePage.TotalGridRecords)
        End Function

        ''' --- GetTotalPages ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetTotalPages.
        ''' </summary>
        ''' <param name="TotalGridRecords"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function GetTotalPages(ByVal TotalGridRecords As Integer) As Integer
            Dim intOccurs As Integer

            Dim intTotalPages As Decimal

            intOccurs = Me.Occurs
            intTotalPages = Fix(TotalGridRecords / intOccurs)
            If TotalGridRecords Mod intOccurs > 0 Then
                intTotalPages += 1
            End If
            Return CInt(intTotalPages)
        End Function

        ''' --- GetTotalPageSets ---------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetTotalPageSets.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function GetTotalPageSets() As Integer
            Return GetTotalPageSets(GetTotalPages())
        End Function

        ''' --- GetTotalPageSets ---------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetTotalPageSets.
        ''' </summary>
        ''' <param name="TotalPages"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function GetTotalPageSets(ByVal TotalPages As Integer) As Integer
            Dim intTotalPageSets As Integer = 0
            If TotalPages > 0 Then
                intTotalPageSets = TotalPages \ 10
                'Get the integer part
                If TotalPages Mod 10 > 0 Then
                    intTotalPageSets += 1
                End If
            End If
            Return intTotalPageSets
        End Function

#End Region

#Region " Private Event Handlers "

        ''' --- DataList1_ItemDataBound --------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of DataList1_ItemDataBound.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub DataList1_ItemDataBound()

            UpdateLayout()

            For i As Integer = 0 To Occurs - 1

                Dim objCtl As Control
                Dim objLabel As System.Windows.Forms.Label
                Dim objDataListItem As GridViewRowPresenter
                Dim intRowsInitiallyDisplayedInGrid As Integer

                'If DirectCast(e, Telerik.Windows.Controls.GridView.RowLoadedEventArgs).Row.GetType.ToString = "Telerik.Windows.Controls.GridView.GridViewHeaderRow" _
                '    OrElse DirectCast(e, Telerik.Windows.Controls.GridView.RowLoadedEventArgs).Row.GetType.ToString = "Telerik.Windows.Controls.GridView.GridViewFooterRow" Then
                '    Exit Sub
                'End If

                'objDataListItem = e.Row



                objDataListItem = GetRow(Me, i)




                'objDataListItem = DirectCast(e, Telerik.Windows.Controls.GridView.RowLoadedEventArgs).Row
                intRowsInitiallyDisplayedInGrid = RowsInitiallyDisplayedInGrid

                'Select Case objDataListItem.ItemType
                '    Case ListItemType.Header, ListItemType.Footer
                '        If objDataListItem.ItemType = ListItemType.Header Then
                '            With ApplicationState.Current.CorePage
                '                If _
                '                    ((intRowsInitiallyDisplayedInGrid = 0 AndAlso .ScreenType = ScreenTypes.Grid) OrElse _
                '                     intRowsInitiallyDisplayedInGrid = Occurs) AndAlso (Not NoAppend) Then
                '                    Select Case .Mode
                '                        Case PageModeTypes.Entry, PageModeTypes.Change
                '                            If Not Me.AllowGridNew Then Me.AllowGridNew = True
                '                        Case PageModeTypes.Find
                '                            If ApplicationState.Current.CorePage.m_blnCallFind Then
                '                                'If Not Me.AllowGridNew Then Me.AllowGridNew = True
                '                            End If
                '                    End Select
                '                Else
                '                    'If Me.AllowGridNew Then Me.AllowGridNew = False
                '                End If
                '            End With
                '            EnableGridNew(objDataListItem)
                '        End If

                '        'Initially we need to display labels' text rather than the Resource String
                '        'For Each objCtl In objDataListItem.Controls
                '        '    Select Case objCtl.ToString
                '        '        Case "Core.Web.UI.Label"
                '        '            objLabel = CType(objCtl, Label)
                '        '            LoadOverrides(objLabel)
                '        '        Case "System.Web.UI.HtmlControls.HtmlGenericControl"
                '        '            DisplayLabelText(objCtl)
                '        '    End Select
                '        'NextPrepareGridDataTableFromDataListItem
                '        'For now we are expecting Core.Web.UI.Label controls only
                '        Exit Sub
                '        'Case ListItemType.AlternatingItem, ListItemType.EditItem, ListItemType.Item, ListItemType.SelectedItem
                '        'if one of the Grid Row having Core controls
                '    Case Else
                '        'Do not process
                '        Exit Sub
                'End Select
                'objLabel = Nothing
                'objCtl = Nothing

                'Private variables used to refresh Grid, display values, call Validate 
                Dim objDataRowView As System.Data.DataRowView
                Dim objDataRow As System.Data.DataRow
                Dim objGridRowStatus As Core.Windows.UI.RowStatus
                Dim objGridRowEditButton As Core.Windows.UI.GridButton
                Dim objDataTable As DataTable
                Dim intTotalGridRecords As Integer
                Dim intTotalRecordsFound As Integer

                objDataRowView = CType(objDataListItem.DataContext, System.Data.DataRowView)
                objDataRow = objDataRowView.Row

                intTotalGridRecords = ApplicationState.Current.CorePage.TotalGridRecords
                If Me.FileObject Is Nothing Then
                    intTotalRecordsFound = Me.Occurs
                End If

                objDataTable = objDataRow.Table

                'Dim intItemIndex As Integer = ItemContainerGenerator.IndexFromContainer(objDataListItem)
                Dim intItemIndex As Integer = GetRowIndex(Me, objDataListItem)

                'If blnGenerateTable Then
                '    PrepareGridDataTableFromDataListItem(objDataTable, objDataListItem)
                '    blnGenerateTable = False
                '    GetGridFieldObject = AddressOf ApplicationState.Current.CorePage.GetGridFieldObject
                'End If

                'Move record position in FileObject if there is corresponding row in FileObject as to Data List Item being processed
                If intRowsInitiallyDisplayedInGrid > intItemIndex Then
                    MoveFileObjectRecordPosition(intItemIndex)
                End If

                'Set the initial row status from the corresponding DataTable
                objGridRowStatus = GetStatus(objDataListItem)
                objGridRowEditButton = objDataListItem.GetDescendants(Of Control)("btnGridRowEdit").FirstOrDefault
                objGridRowStatus.CurrentStatus = CType(objDataRow("InternalRowStatus"), GridRowStatus)
                objGridRowStatus.PreviousStatus = CType(objDataRow("InternalRowStatus"), GridRowStatus)
                SetEditButtonImage(objGridRowEditButton, objGridRowStatus, False, objDataListItem)
                m_blnBlankControlsInUndefinedRows = False
                'Select Case objGridRowStatus.CurrentStatus
                '    Case GridRowStatus.UnchangedNew, GridRowStatus.NotSet
                '        m_blnBlankControlsInUndefinedRows = True
                '        objDataListItem.Visibility = System.Windows.Visibility.Collapsed
                '    Case Else
                '        objDataListItem.Visibility = System.Windows.Visibility.Visible
                'End Select
                'If Not NoRecordsFound Then
                BindGridFieldsEvents(objDataListItem, True)
                'End If

                objCtl = Nothing
                objDataTable = Nothing
                objDataListItem = Nothing
                objGridRowStatus = Nothing
                objDataRowView = Nothing
                objGridRowStatus = Nothing

            Next
        End Sub

        ''' --- DisplayLabelText ---------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of DisplayLabelText.
        ''' </summary>
        ''' <param name="ParentControl"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub DisplayLabelText(ByVal ParentControl As HtmlGenericControl)
            Dim objCtl As Control
            Dim objLabel As System.Windows.Forms.Label
            For Each objCtl In ParentControl.Controls
                Select Case objCtl.ToString
                    Case "Core.Web.UI.Label"
                        'objLabel = CType(objCtl, System.Windows.Controls.Label)
                        'LoadOverrides(objLabel)
                    Case "System.Web.UI.HtmlControls.HtmlGenericControl"
                        'If objCtl.HasControls Then
                        '    DisplayLabelText(objCtl)
                        'End If
                End Select
            Next
            objCtl = Nothing
        End Sub

        ''' --- SetEditButtonImage -------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of SetEditButtonImage.
        ''' </summary>
        ''' <param name="EditButton"></param>
        ''' <param name="RowStatus"></param>
        ''' <param name="ForEdit"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function SetEditButtonImage(ByVal EditButton As GridButton, ByVal RowStatus As RowStatus,
                                             ByVal ForEdit As Boolean, ByVal objDataListItem As GridViewRowPresenter) As String
            Return SetEditButtonImage(EditButton, RowStatus, ForEdit, -1, -1, objDataListItem)
        End Function

        ''' --- SetEditButtonImage -------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of SetEditButtonImage.
        ''' </summary>
        ''' <param name="EditButton"></param>
        ''' <param name="RowStatus"></param>
        ''' <param name="ForEdit"></param>
        ''' <param name="CurrentRowBeingProcessed"></param>
        ''' <param name="NextAppendRowTobeEnabled"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function SetEditButtonImage(ByVal EditButton As GridButton, ByVal RowStatus As RowStatus,
                                             ByVal ForEdit As Boolean, ByVal CurrentRowBeingProcessed As Integer,
                                             ByVal NextAppendRowTobeEnabled As Integer, ByVal objDataListItem As GridViewRowPresenter) As String
            Dim CurrentRowStatus As GridRowStatus
            Dim PreviousRowStatus As GridRowStatus
            Dim triEnableEditButton As TriState
            Const DisplayEditButtonAsOffIfDeleted As Boolean = True




            triEnableEditButton = TriState.UseDefault
            'Don't Change this or move it, following logic depends on this value

            With RowStatus
                CurrentRowStatus = .CurrentStatus
                PreviousRowStatus = .PreviousStatus
            End With

            If _
                MaxAppend AndAlso CurrentRowBeingProcessed >= (FileObject.Occurs - 1) AndAlso
                CurrentRowStatus = GridRowStatus.UnchangedOld Then
                m_blnNoNewAppend = True
            End If

            If _
                Not Me.m_blnUsingAcceptProcessing AndAlso CurrentRowStatus <> GridRowStatus.UnchangedNew AndAlso
                CurrentRowStatus <> GridRowStatus.NotSet AndAlso m_blnDesignerMode Then
                ' If user clicked on one of the desinger, we need to 
                ' disable all Grid Button Controls
                ' If CurrentRowStatus id NotSet then Disable the Edit Button
                triEnableEditButton = m_triKeepEditButtonEnabledAfterDesigner
            Else
                With EditButton
                    If m_blnEnableAllEditButtons Then
                        triEnableEditButton = TriState.True
                    Else
                        .IsEnabled = True
                        .Background = New SolidColorBrush(Colors.White)
                        .Opacity = 1
                        Select Case CurrentRowStatus
                            Case GridRowStatus.Deleted
                                If DisplayEditButtonAsOffIfDeleted Then
                                    ' Once Record is Marked for Deleted EditButton is Disabled and Editted button displayed as Off
                                    ' It can be enabled by again clicking on DeleteButton
                                    triEnableEditButton = TriState.False
                                End If
                            Case GridRowStatus.UnchangedOld, GridRowStatus.Editing, GridRowStatus.Edited
                                If m_blnNoChange Then
                                    triEnableEditButton = TriState.False
                                Else
                                    If ApplicationState.Current.CorePage.ChangeActivity Then
                                        If ForEdit Then
                                            'If _
                                            '    ApplicationState.Current.CorePage.DesignerMode AndAlso Me.m_blnUsingAcceptProcessing AndAlso _
                                            '    m_intNextRecord > 0 Then
                                            '    triEnableEditButton = TriState.False
                                            'Else
                                            '    .IsEnabled = True
                                            '    '.ImageUrl = "~/Images/Controls/Grid_Edit_Active.gif"
                                            '    '.Attributes.Add("onclick", " javascript:Pageunload();")
                                            '    '.Attributes.Add("onMouseOver", "this.style.cursor = 'pointer';")
                                            'End If
                                            'triEnableEditButton is UseDefault

                                            If Thread.CurrentThread.CurrentCulture.ToString.StartsWith("en") Then
                                                .ToolTip = "Change this Row" 'ApplicationState.Current.CorePage.GetToolTip("IM.Grid.AddingNewRecordToolTip")
                                            Else
                                                .ToolTip = "Changer cette ligne" 'ApplicationState.Current.CorePage.GetToolTip("ChangeRecordToolTip")
                                            End If

                                            Dim im As BitmapImage = New BitmapImage
                                            im.BeginInit()
                                            im.UriSource = New Uri("pack://application:,,,/;component/Images/Toolbar/Edit.png")
                                            im.EndInit()

                                            Dim ima As System.Windows.Controls.Image = EditButton.FindChildByType(Of System.Windows.Controls.Image)()
                                            ima.Source = im

                                        ElseIf Not Me.m_blnUsingAcceptProcessing AndAlso Not m_blnAllowEditButton Then
                                            triEnableEditButton = TriState.False
                                        Else
                                            'If _
                                            '    ApplicationState.Current.CorePage.DesignerMode AndAlso Me.m_blnUsingAcceptProcessing AndAlso _
                                            '    m_intNextRecord > 0 Then
                                            '    triEnableEditButton = TriState.False
                                            'Else
                                            '    If _
                                            '        (m_blnSuppressAdditionalEdits AndAlso CurrentRowBeingProcessed > 0) OrElse _
                                            '        (ApplicationState.Current.CorePage.IsInAppendOrEntry AndAlso ApplicationState.Current.CorePage.IsFlickerFree) Then
                                            '        triEnableEditButton = TriState.False
                                            '    Else
                                            '        triEnableEditButton = TriState.True
                                            '    End If
                                            'End If
                                            If Thread.CurrentThread.CurrentCulture.ToString.StartsWith("en") Then
                                                .ToolTip = "Change this Row" 'ApplicationState.Current.CorePage.GetToolTip("IM.Grid.AddingNewRecordToolTip")
                                            Else
                                                .ToolTip = "Changer cette ligne" 'ApplicationState.Current.CorePage.GetToolTip("IM.Grid.AddingNewRecordToolTip")
                                            End If
                                        End If
                                    Else
                                        'We need to allow user to select a record if there is designer
                                        'eventhough append or change is not allowed.
                                        'e.g. in a lookup screens use should be allowed to 
                                        'select a record.
                                        '
                                        'This should at least fire a BeforeEdit Event
                                        'so that developer can write code to select a value
                                        'and return to the calling screen or it can be used to 
                                        'call a desinger procedure.
                                        If m_blnKeepEditButtonEnabled Then
                                            triEnableEditButton = TriState.True
                                        Else
                                            triEnableEditButton = TriState.False
                                        End If
                                    End If
                                End If
                            Case GridRowStatus.UnchangedNew, GridRowStatus.Adding, GridRowStatus.Added
                                If NoAppend Then
                                    triEnableEditButton = TriState.False
                                Else
                                    If ForEdit Then
                                        .IsEnabled = True
                                        .Opacity = 1
                                        .Background = New SolidColorBrush(Colors.White)
                                        '.ImageUrl = "~/Images/Controls/Grid_Edit_Active.gif"
                                        '.Attributes.Add("onclick", " javascript:Pageunload();")
                                        '.Attributes.Add("onMouseOver", "this.style.cursor = 'pointer';")
                                        Dim im As BitmapImage = New BitmapImage
                                        im.BeginInit()
                                        im.UriSource = New Uri("pack://application:,,,/;component/Images/Toolbar/Edit.png")
                                        im.EndInit()

                                        Dim ima As System.Windows.Controls.Image = EditButton.FindChildByType(Of System.Windows.Controls.Image)()
                                        ima.Source = im
                                        If Thread.CurrentThread.CurrentCulture.ToString.StartsWith("en") Then
                                            .ToolTip = "Adding new Row" 'ApplicationState.Current.CorePage.GetToolTip("IM.Grid.AddingNewRecordToolTip")
                                        Else
                                            .ToolTip = "Ajouter une nouvelle ligne" 'ApplicationState.Current.CorePage.GetToolTip("IM.Grid.AddingNewRecordToolTip")
                                        End If

                                        If _
                                            m_blnEnableFirstEmptyNewButton AndAlso
                                            CurrentRowStatus = GridRowStatus.Adding Then
                                            m_blnEnableFirstEmptyNewButton = False
                                        End If
                                        'triEnableEditButton is UseDefault
                                    Else
                                        Dim blnEnableFirstEmptyButton As Boolean
                                        If Me.m_intToolbarAction = ToolbarIcons.Add Then
                                            'In case record is added and altered through the code, we want to enable an
                                            'Edit Button on unchanged row which is "CurrentRowStatus = GridRowStatus.UnchangedNew"
                                            If _
                                                Me.m_intToolbarAction = ToolbarIcons.Add AndAlso
                                                (CurrentRowStatus = GridRowStatus.UnchangedNew OrElse
                                                 CurrentRowStatus = GridRowStatus.Adding) Then
                                                blnEnableFirstEmptyButton = True
                                            Else
                                                blnEnableFirstEmptyButton = False
                                            End If
                                        Else
                                            blnEnableFirstEmptyButton = m_blnEnableFirstEmptyNewButton
                                        End If

                                        If Me.m_blnUsingAcceptProcessing AndAlso blnEnableFirstEmptyButton Then
                                            ' Added condition to ensure that if DisableAppend is True on the page, and DisableAppendFromEntry is not,
                                            ' to disable the append button for the next row but allow for Append to be called from the Entry procedure.
                                            If _
                                                Not _
                                                DisableAppendIcon(NextAppendRowTobeEnabled, CurrentRowBeingProcessed) _
                                                AndAlso m_blnEnableFirstEmptyNewButton AndAlso
                                                Not (Not ApplicationState.Current.CorePage.EntryMode AndAlso ApplicationState.Current.CorePage.DisableAppend) AndAlso
                                                ((ApplicationState.Current.CorePage.EntryMode AndAlso Not ApplicationState.Current.CorePage.DisableAppendFromEntry) OrElse
                                                 Not _
                                                 (CurrentRowStatus = GridRowStatus.Adding AndAlso ApplicationState.Current.CorePage.DisableAppend AndAlso
                                                  (ApplicationState.Current.CorePage.CorrectMode OrElse ApplicationState.Current.CorePage.ChangeMode))) Then
                                                ' Disable the Append icon in the last row (new row) in order to ensure
                                                ' that the user doesn't click that while appending the current row.  
                                                If _
                                                    ApplicationState.Current.CorePage.IsInAppendOrEntry AndAlso
                                                    CurrentRowStatus = GridRowStatus.UnchangedNew Then
                                                    triEnableEditButton = TriState.False
                                                    .ToolTip = Nothing
                                                Else
                                                    'Display Add Button
                                                    .IsEnabled = True
                                                    .Opacity = 1
                                                    .Background = New SolidColorBrush(Colors.White)
                                                    If CurrentRowStatus = GridRowStatus.Added Then
                                                        triEnableEditButton = TriState.True
                                                    Else
                                                        triEnableEditButton = TriState.UseDefault
                                                        If Thread.CurrentThread.CurrentCulture.ToString.StartsWith("en") Then
                                                            .ToolTip = "Adding new Row" 'ApplicationState.Current.CorePage.GetToolTip("IM.Grid.AddingNewRecordToolTip")
                                                        Else
                                                            .ToolTip = "Ajouter une nouvelle ligne" 'ApplicationState.Current.CorePage.GetToolTip("IM.Grid.AddingNewRecordToolTip")
                                                        End If
                                                        '.ImageUrl = "~/Images/Controls/Grid_Add_On.gif"

                                                        Dim im As BitmapImage = New BitmapImage
                                                        im.BeginInit()
                                                        im.UriSource = New Uri("pack://application:,,,/;component/Images/Toolbar/Add.png")
                                                        im.EndInit()

                                                        Dim ima As System.Windows.Controls.Image = EditButton.FindChildByType(Of System.Windows.Controls.Image)()
                                                        ima.Source = im


                                                        '.Attributes.Add("onclick", " javascript:Pageunload();")
                                                        '.Attributes.Add("onMouseOver", "this.style.cursor = 'pointer';")
                                                        AppendID = .Name
                                                    End If

                                                    If CurrentRowStatus <> GridRowStatus.Added Then
                                                        'If new record is altered, enable the next empty button
                                                        m_blnEnableFirstEmptyNewButton = False
                                                    End If
                                                End If

                                            Else
                                                If _
                                                    CurrentRowStatus = GridRowStatus.Added AndAlso
                                                    Not _
                                                    DisableAppendIcon(NextAppendRowTobeEnabled,
                                                                       CurrentRowBeingProcessed) Then
                                                    triEnableEditButton = TriState.True
                                                Else
                                                    triEnableEditButton = TriState.False
                                                    .ToolTip = Nothing
                                                End If
                                            End If
                                        Else
                                            If _
                                                Not _
                                                DisableAppendIcon(NextAppendRowTobeEnabled, CurrentRowBeingProcessed) AndAlso
                                                m_blnEnableFirstEmptyNewButton Then
                                                'Display Add Button
                                                triEnableEditButton = TriState.UseDefault
                                                .IsEnabled = True
                                                .Opacity = 1
                                                .Background = New SolidColorBrush(Colors.White)
                                                If Thread.CurrentThread.CurrentCulture.ToString.StartsWith("en") Then
                                                    .ToolTip = "Adding new Row" 'ApplicationState.Current.CorePage.GetToolTip("IM.Grid.AddingNewRecordToolTip")
                                                Else
                                                    .ToolTip = "Ajouter une nouvelle ligne" 'ApplicationState.Current.CorePage.GetToolTip("IM.Grid.AddingNewRecordToolTip")
                                                End If
                                                '.ImageUrl = "~/Images/Controls/Grid_Add_On.gif"
                                                '.Attributes.Add("onclick", " javascript:Pageunload();")
                                                '.Attributes.Add("onMouseOver", "this.style.cursor = 'pointer';")

                                                Dim im As BitmapImage = New BitmapImage
                                                im.BeginInit()
                                                im.UriSource = New Uri("pack://application:,,,/;component/Images/Toolbar/Add.png")
                                                im.EndInit()

                                                Dim ima As System.Windows.Controls.Image = EditButton.FindChildByType(Of System.Windows.Controls.Image)()
                                                ima.Source = im

                                                AppendID = .Name
                                            Else
                                                'Display Add Button
                                                If ApplicationState.Current.CorePage.IsInAppendOrEntry Then
                                                    triEnableEditButton = TriState.UseDefault
                                                Else
                                                    triEnableEditButton = TriState.False
                                                End If
                                                .IsEnabled = False
                                                .Opacity = 0.55
                                                '.ImageUrl = "~/Images/Controls/Grid_Add_On.gif"
                                                '.Attributes.Add("onclick", " javascript:Pageunload();")
                                                'AppendID = .Name
                                            End If
                                        End If
                                    End If
                                End If
                            Case GridRowStatus.NotSet
                                triEnableEditButton = TriState.False
                        End Select
                    End If
                End With
            End If

            With EditButton
                Select Case triEnableEditButton
                    Case TriState.True
                        .IsEnabled = True
                        .Opacity = 1
                        .Background = New SolidColorBrush(Colors.White)
                        '.ImageUrl = "~/Images/Controls/Grid_Edit_On.gif"
                        '.Attributes.Add("onclick", " javascript:Pageunload();")
                        '.Attributes.Add("onMouseOver", "this.style.cursor = 'pointer';")
                        If Thread.CurrentThread.CurrentCulture.ToString.StartsWith("en") Then
                            .ToolTip = "Change this Row" 'ApplicationState.Current.CorePage.GetToolTip("IM.Grid.AddingNewRecordToolTip")
                        Else
                            .ToolTip = "Changer cette ligne" 'ApplicationState.Current.CorePage.GetToolTip("IM.Grid.AddingNewRecordToolTip")
                        End If

                    Case TriState.False
                        .IsEnabled = False
                        .Opacity = 0.55
                        '.ImageUrl = "~/Images/Controls/Grid_Edit_Off.gif"
                        .ToolTip = Nothing

                    Case TriState.UseDefault

                        'Use the current settings
                End Select


                If Not IsNothing(ConfigurationManager.AppSettings("HideGridButtons")) AndAlso ConfigurationManager.AppSettings("HideGridButtons").ToString().ToUpper = "TRUE" Then
                    If Not .IsEnabled Then
                        .Visibility = Visibility.Hidden
                    End If
                End If


                EnableDisableInGridButton(EditButton.IsEnabled, objDataListItem)

            End With



            CurrentRowStatus = Nothing
            PreviousRowStatus = Nothing
            Return Nothing
        End Function

        Private Sub EnableDisableInGridButton(enabled As Boolean, ByVal objDataListItem As GridViewRowPresenter)


            Dim ctl As Control
            For Each ctl In objDataListItem.GetDescendants(Of Control)()

                Select Case ctl.GetType.ToString
                    Case "Core.Windows.UI.Core.Windows.UI.InGridButton"

                        If enabled Then
                            ctl.Opacity = 1
                            ctl.IsEnabled = True
                            ctl.Background = New SolidColorBrush(Colors.White)
                        Else
                            ctl.Opacity = 0.55
                            ctl.IsEnabled = False
                            ctl.Background = New SolidColorBrush(Colors.White)
                        End If

                End Select


            Next



        End Sub


        ''' --- DisableAppendIcon -----------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of DisableAppendIcon.
        ''' </summary>
        ''' <param name="NextAppendRowTobeEnabled"></param>
        ''' <param name="CurrentRowBeingProcessed"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function DisableAppendIcon(ByVal NextAppendRowTobeEnabled As Integer,
                                            ByVal CurrentRowBeingProcessed As Integer) As Boolean

            Return (NextAppendRowTobeEnabled >= 0 AndAlso CurrentRowBeingProcessed < NextAppendRowTobeEnabled) _
                   OrElse
                   (NextAppendRowTobeEnabled = -1 AndAlso CurrentRowBeingProcessed < NewRowIndex) AndAlso
                   ApplicationState.Current.CorePage.IsAppend

        End Function

        ''' --- SetDeleteButtonImage -----------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of SetDeleteButtonImage.
        ''' </summary>
        ''' <param name="DeleteButton"></param>
        ''' <param name="RowStatus"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function SetDeleteButtonImage(ByVal DeleteButton As GridButton, ByVal RowStatus As RowStatus) As String
            Dim CurrentRowStatus As GridRowStatus
            Dim PreviousRowStatus As GridRowStatus
            Dim triEnableDeleteButton As TriState = TriState.False

            With RowStatus
                CurrentRowStatus = .CurrentStatus
                PreviousRowStatus = .PreviousStatus
            End With

            If m_blnDesignerMode AndAlso Not Me.m_blnUsingAcceptProcessing Then
                If _
                    CurrentRowStatus <> GridRowStatus.UnchangedNew AndAlso CurrentRowStatus <> GridRowStatus.NotSet AndAlso
                    m_blnDesignerMode Then
                    ' If user clicked on one of the designer, we need to 
                    ' enable/disable Delete Button
                    triEnableDeleteButton = m_triKeepDeleteButtonEnabledAfterDesigner
                End If
            Else
                Select Case CurrentRowStatus
                    Case GridRowStatus.NotSet, GridRowStatus.UnchangedNew
                        triEnableDeleteButton = False
                    Case GridRowStatus.UnchangedOld, GridRowStatus.Edited, GridRowStatus.Editing,
                        GridRowStatus.UnchangedNew, GridRowStatus.Adding, GridRowStatus.Added

                        If NoDelete Then
                            triEnableDeleteButton = TriState.False
                        Else
                            If Me.m_blnUsingAcceptProcessing Then
                                Select Case CurrentRowStatus
                                    Case GridRowStatus.Editing, GridRowStatus.Adding, GridRowStatus.UnchangedNew
                                        If _
                                            CurrentRowStatus = GridRowStatus.Editing AndAlso
                                            (ApplicationState.Current.CorePage.EnableNumberedDesigners AndAlso
                                             (m_blnKeepDeleteButtonEnabled OrElse (Not NoDelete)) AndAlso
                                             m_blnAllowEditButton) Then
                                            triEnableDeleteButton = TriState.True
                                        Else
                                            triEnableDeleteButton = TriState.False
                                        End If
                                    Case GridRowStatus.Added, GridRowStatus.Edited, GridRowStatus.UnchangedOld
                                        If _
                                            m_blnKeepDeleteButtonEnabled OrElse
                                            (Not NoDelete) AndAlso m_blnAllowEditButton AndAlso
                                            Not ApplicationState.Current.CorePage.ExecutingDesigner Then
                                            triEnableDeleteButton = TriState.True
                                        Else
                                            triEnableDeleteButton = TriState.False
                                        End If
                                    Case Else
                                        If _
                                            m_blnKeepDeleteButtonEnabled OrElse
                                            (Not NoDelete) AndAlso m_blnAllowEditButton AndAlso
                                            Not ApplicationState.Current.CorePage.ExecutingDesigner Then
                                            triEnableDeleteButton = TriState.True
                                        Else
                                            triEnableDeleteButton = TriState.False
                                        End If
                                End Select
                            Else
                                If m_blnKeepDeleteButtonEnabled OrElse (Not NoDelete) Then
                                    triEnableDeleteButton = TriState.True
                                Else
                                    triEnableDeleteButton = TriState.False
                                End If
                            End If
                        End If
                End Select
            End If

            With ApplicationState.Current.CorePage
                'In case of AcceptProcessing and if Append is being executed,
                'override the current settings of Delete button
                If _
                    Me.m_blnUsingAcceptProcessing AndAlso
                    (m_intToolbarAction <> ToolbarIcons.Submit AndAlso .IsExecutingAppend AndAlso
                     (Not .HasError OrElse
                      .HasError AndAlso .m_strRequestedControlFocusOverRide.ToUpper.StartsWith("DTL"))) Then
                    'In Accept Processing, disable delete button during execution of an Append
                    triEnableDeleteButton = TriState.False
                End If
            End With
            With DeleteButton
                Select Case triEnableDeleteButton
                    Case TriState.True
                        .IsEnabled = True
                        .Opacity = 1
                        .Background = New SolidColorBrush(Colors.White)
                        '.ImageUrl = "~/Images/Controls/Grid_Delete_On.gif"
                        '.Attributes.Add("onclick", " javascript:Pageunload();")
                        '.Attributes.Add("onMouseOver", "this.style.cursor = 'pointer';")
                        .ToolTip = "Mark this Row for deletion" 'ApplicationState.Current.CorePage.GetToolTip("IM.Grid.MarkForDeletionToolTip")
                    Case TriState.False
                        .IsEnabled = False
                        .Opacity = 0.55
                        '.ImageUrl = "~/Images/Controls/Grid_Delete_Off.gif"
                        .ToolTip = Nothing
                    Case Else
                        'Use the current settings
                End Select

                   If Not IsNothing(ConfigurationManager.AppSettings("HideGridButtons")) AndAlso ConfigurationManager.AppSettings("HideGridButtons").ToString().ToUpper = "TRUE" Then
                    If Not .IsEnabled Then
                        .Visibility = Visibility.Hidden
                    End If
                End If

            End With


            Return Nothing
        End Function



        ''' --- DataList1_Init -----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of DataList1_Init.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub DataList1_Init(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Loaded
            If Not IsNothing(ApplicationState.Current.CorePage) Then
                With ApplicationState.Current.CorePage
                    ' To initialize Grid on each postback
                    AddHandler .PrepareGridToProcess, AddressOf PrepareGridToProcess

                    ' To Display Grid Items on end of request
                    AddHandler .PrepareGridControlsForDisplay, AddressOf PrepareGridControlsForDisplay

                    'To apply changes made in a Grid when user submits page
                    AddHandler .ProcessGridRecords, AddressOf ProcessGridRecords

                    'To apply changes made in a Grid when user submits page
                    AddHandler .DeleteGridRecords, AddressOf DeleteGridRecords

                    'To Display Grid
                    AddHandler .ShowGridEvent, AddressOf ShowGrid

                    'To Display Grid
                    AddHandler .BindGridFields, AddressOf BindGridFields

                    'Get the Address of procedure to bind Grid Fields' Events
                    GetGridFieldObject = AddressOf .GetGridFieldObject

                    'To return control information for PUSH verb
                    AddHandler .GetControlId, AddressOf GetControlId

                    ' To get the occurs with file flags.
                    AddHandler .SetOccursWithFileFlags, AddressOf SetOccursWithFileFlags

                    .HasGrid = True

                    ' Determine which Grid Control caused the post back
                    m_intGridAction = GetGridAction()
                    .GridActionType = m_intGridAction
                    m_intToolbarAction = .ToolbarAction()

                End With
            End If
        End Sub



        ' Accept Processing.
        ''' --- ProcessEditClickForAcceptProcessing --------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of ProcessEditClickForAcceptProcessing.
        ''' </summary>
        ''' <param name="ItemIndex"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub ProcessEditClickForAcceptProcessing(ByVal ItemIndex As Integer)
            Dim blnCancel As Boolean = False
            Dim objGridRowStatus As RowStatus
            Dim objGridButton As GridButton
            Dim objDataListItem As GridViewRowPresenter
            Dim objCurrentStatus As GridRowStatus
            Dim strCommandName As String = String.Empty
            Dim strCommandArgument As String = String.Empty
            Dim strFireEvent As String = String.Empty

            ' Set to true so the pagination doesn't change.
            m_blnKeepPaginationPage = True

            If Not IsNothing(ApplicationState.Current.CorePage.PageActionObject) AndAlso ApplicationState.Current.CorePage.PageActionObject.GetType.ToString <> "Core.Windows.UI.Core.Windows.UI.InGridButton" Then

                objGridButton = CType(ApplicationState.Current.CorePage.PageActionObject, GridButton)
                If Not objGridButton Is Nothing Then
                    With objGridButton
                        strCommandName = .CommandName
                        strCommandArgument = .CommandArgument
                    End With
                End If
            End If


            objDataListItem = GetDataListItem(ItemIndex)

            With ApplicationState.Current.CorePage
                'If .DesignerMode Then
                '    'because of named designers
                '    If ApplicationState.Current.CorePage.Request("__EventTarget") = "" OrElse ApplicationState.Current.CorePage.IsFunctionKey Then
                '        Dim objGridButtonEventArgs As GridButtonEventArgs
                '        If strCommandArgument = "GridNew" Then
                '            objGridRowStatus = Nothing
                '            IsGridNew = True
                '            m_blnClearFields = True
                '            m_blnEnableFirstRow = True
                '            objCurrentStatus = GridRowStatus.NotSet
                '            'Unknown
                '            ItemIndex = 0
                '            'First Record
                '            With ApplicationState.Current.CorePage
                '                .GridRecordNumber = 0
                '                .CurrentPageNumber = 0
                '                .CurrentPageSetNumber = 0
                '                .TotalGridRecords = 0

                '                ' TODO: Check what PH does, while APPENDing new record in Primary-Grid Screen with no records on a screen
                '                ' At present we are setting Change mode 
                '                .Mode = PageModeTypes.Change
                '            End With
                '        Else
                '            objGridRowStatus = GetStatus(objDataListItem)
                '            objCurrentStatus = objGridRowStatus.CurrentStatus
                '        End If

                '        'objGridButtonEventArgs = _
                '        '    New GridButtonEventArgs(objDataListItem, objGridButton, objGridRowStatus, strCommandName, _
                '        '                             strCommandArgument)

                '        If _
                '            objCurrentStatus = GridRowStatus.Added OrElse objCurrentStatus = GridRowStatus.Adding OrElse _
                '            objCurrentStatus = GridRowStatus.UnchangedNew OrElse _
                '            (m_intGridAction = DataListActionTypes.GridNew) Then
                '            RaiseAddEvents(ItemIndex, (m_intGridAction = DataListActionTypes.GridNew), _
                '                            objGridButtonEventArgs, blnCancel, True)
                '            strFireEvent = "Append"
                '            ApplicationState.Current.CorePage.IsAppend = True
                '        ElseIf _
                '            objCurrentStatus = GridRowStatus.Edited OrElse GridRowStatus.Editing OrElse _
                '            objCurrentStatus = GridRowStatus.UnchangedOld Then
                '            'pat 
                '            SetRowStatus(GridRowStatusCommand.Edit, objDataListItem)
                '            RaiseEditEvents(ItemIndex, objGridButtonEventArgs, blnCancel, True)
                '            strFireEvent = "Edit"
                '            ApplicationState.Current.CorePage.IsAppend = False
                '        End If
                '        objGridButtonEventArgs = Nothing
                '    Else
                '        'Instead of raising Add Click or Edit Click raise designer events
                '        m_intSelectedRecord = ItemIndex

                '        .PageActionObject = Nothing
                '        'RaiseDesignerEvents will use the Designer Object, if this property is set to Nothing
                '        RaiseDesignerEvents(objDataListItem, blnCancel, strCommandName, strCommandArgument)
                '        strFireEvent = "Designer"
                '    End If
                'Else
                Dim objGridButtonEventArgs As GridButtonEventArgs
                If m_intGridAction = DataListActionTypes.GridNew Then
                    objGridRowStatus = GetStatus(objDataListItem)
                    objGridRowStatus.AppendedRowStatus = AppendStatus.Appending

                    IsGridNew = True
                    m_blnClearFields = True
                    m_blnEnableFirstRow = True
                    objCurrentStatus = GridRowStatus.NotSet
                    'Unknown
                    ItemIndex = 0
                    'First Record
                    With ApplicationState.Current.CorePage
                        .GridRecordNumber = 0
                        .CurrentPageNumber = 0
                        .CurrentPageSetNumber = 0
                        .TotalPageSets = 0
                        .TotalGridRecords = 0

                        ' TODO: Check what PH does, while APPENDing new record in Primary-Grid Screen with no records on a screen
                        ' At present we are setting Change mode 

                        ApplicationState.Current.CorePage.IsAppend = True
                        .Mode = PageModeTypes.Change

                    End With
                Else
                    objGridRowStatus = GetStatus(objDataListItem)
                    objCurrentStatus = objGridRowStatus.CurrentStatus
                End If


                objGridButtonEventArgs =
                    New GridButtonEventArgs(objDataListItem, objGridButton, objGridRowStatus, strCommandName,
                                             strCommandArgument)

                If _
                    (objGridRowStatus.AppendedRowStatus <> AppendStatus.Appended) AndAlso
                    (objCurrentStatus = GridRowStatus.UnchangedNew OrElse objCurrentStatus = GridRowStatus.Added OrElse
                     objCurrentStatus = GridRowStatus.Adding OrElse objCurrentStatus = GridRowStatus.UnchangedNew OrElse
                     (m_intGridAction = DataListActionTypes.GridNew)) Then
                    objGridRowStatus.AppendedRowStatus = AppendStatus.Appending
                    RaiseAddEvents(ItemIndex, (m_intGridAction = DataListActionTypes.GridNew),
                                    objGridButtonEventArgs, blnCancel, True)
                    strFireEvent = "Append"
                    ApplicationState.Current.CorePage.IsAppend = True
                    ApplicationState.Current.CorePage.m_blnCorrectMode = False
                    ApplicationState.Current.CorePage.m_blnEntryMode = True
                ElseIf _
                    (objGridRowStatus.AppendedRowStatus = AppendStatus.Appended) OrElse
                    objCurrentStatus = GridRowStatus.Edited OrElse GridRowStatus.Editing OrElse
                    objCurrentStatus = GridRowStatus.UnchangedOld Then
                    'pat 
                    SetRowStatus(GridRowStatusCommand.Edit, objDataListItem)
                    RaiseEditEvents(ItemIndex, objGridButtonEventArgs, blnCancel, True)
                    strFireEvent = "Edit"
                    ApplicationState.Current.CorePage.IsAppend = False
                End If
                objGridButtonEventArgs = Nothing
                ' End If

                If blnCancel Then
                    'if user cancels the Edit or Append event set Current Row Index to -1
                    CurrentRowIndex = -1
                ElseIf Not blnCancel AndAlso strFireEvent <> "" Then
                    CurrentRowIndex = m_intNewRowIndex
                    If strFireEvent <> "Designer" AndAlso m_intGridAction <> DataListActionTypes.GridNew Then _
                        SetRowStatus(GridRowStatusCommand.Edit, objDataListItem)
                End If

            End With
        End Sub


        ''' --- ProcessEditClick ---------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of ProcessEditClick.
        ''' </summary>
        ''' <param name="ItemIndex"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub ProcessEditClick(ByVal ItemIndex As Integer)
            Dim blnCancel As Boolean = False
            Dim objGridRowStatus As RowStatus
            Dim objGridButton As GridButton
            Dim objDataListItem As GridViewRowPresenter
            Dim objCurrentStatus As GridRowStatus
            Dim strCommandName As String
            Dim strCommandArgument As String
            Dim strFireEvent As String = ""

            ' Set to true so the pagination doesn't change.
            m_blnKeepPaginationPage = True

            objGridButton = CType(ApplicationState.Current.CorePage.PageActionObject, GridButton)
            With objGridButton
                strCommandName = .CommandName
                strCommandArgument = .CommandArgument
            End With
            objDataListItem = GetDataListItem(ItemIndex)

            With ApplicationState.Current.CorePage
                'If .DesignerMode Then
                '    'Instead of raising Add Click or Edit Click raise designer events
                '    'objDesigner.CurrentDesigner = ApplicationState.Current.CorePage.FindControl(ApplicationState.Current.CorePage.DesignerName)
                '    m_intSelectedRecord = ItemIndex

                '    .PageActionObject = Nothing
                '    'RaiseDesignerEvents will use the Designer Object, if this property is set to Nothing
                '    RaiseDesignerEvents(objDataListItem, blnCancel, strCommandName, strCommandArgument)
                '    strFireEvent = "Designer"
                'Else
                Dim objGridButtonEventArgs As GridButtonEventArgs
                If strCommandArgument = "GridNew" Then
                    objGridRowStatus = Nothing
                    IsGridNew = True
                    m_blnClearFields = True
                    m_blnEnableFirstRow = True
                    objCurrentStatus = GridRowStatus.NotSet
                    'Unknown
                    ItemIndex = 0
                    'First Record
                    With ApplicationState.Current.CorePage
                        .GridRecordNumber = 0
                        .CurrentPageNumber = 0
                        .CurrentPageSetNumber = 0
                        .TotalPageSets = 0
                        .TotalGridRecords = 0

                        ' TODO: Check what PH does, while APPENDing new record in Primary-Grid Screen with no records on a screen
                        ' At present we are setting Change mode 
                        .Mode = PageModeTypes.Change
                    End With
                Else
                    objGridRowStatus = GetStatus(objDataListItem)
                    objCurrentStatus = objGridRowStatus.CurrentStatus
                End If

                'objGridButtonEventArgs = _
                '    New GridButtonEventArgs(objDataListItem, objGridButton, objGridRowStatus, strCommandName, _
                '                             strCommandArgument)

                If _
                    objCurrentStatus = GridRowStatus.Added OrElse objCurrentStatus = GridRowStatus.Adding OrElse
                    objCurrentStatus = GridRowStatus.UnchangedNew OrElse
                    (m_intGridAction = DataListActionTypes.GridNew) Then
                    RaiseAddEvents(ItemIndex, (m_intGridAction = DataListActionTypes.GridNew),
                                    objGridButtonEventArgs, blnCancel, True)
                    strFireEvent = "Append"
                ElseIf _
                    objCurrentStatus = GridRowStatus.Edited OrElse GridRowStatus.Editing OrElse
                    objCurrentStatus = GridRowStatus.UnchangedOld Then
                    RaiseEditEvents(ItemIndex, objGridButtonEventArgs, blnCancel, True)
                    strFireEvent = "Edit"
                End If
                objGridButtonEventArgs = Nothing
                'End If

                If blnCancel Then
                    'if user cancels the Edit or Append event set Current Row Index to -1
                    CurrentRowIndex = -1
                ElseIf Not blnCancel AndAlso strFireEvent <> "" Then
                    CurrentRowIndex = m_intNewRowIndex
                    If strFireEvent <> "Designer" AndAlso strCommandArgument <> "GridNew" Then _
                        SetRowStatus(GridRowStatusCommand.Edit, objDataListItem)
                    'If strFireEvent <> "Designer" Then PrepareGridControlsForDisplay(False, Nothing)
                End If

            End With
        End Sub

        ''' --- ProcessDeleteClick -------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of ProcessDeleteClick.
        ''' </summary>
        ''' <param name="ItemIndex"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub ProcessDeleteClick(ByVal ItemIndex As Integer)
            ProcessDeleteClick(GetDataListItem(ItemIndex))
        End Sub

        ''' --- ProcessDeleteClick -------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of ProcessDeleteClick.
        ''' </summary>
        ''' <param name="objDataListItem"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub ProcessDeleteClick(ByVal objDataListItem As GridViewRowPresenter)
            Dim blnCancelDelete As Boolean = False
            Dim intItemIndex As Integer
            intItemIndex = ItemContainerGenerator.IndexFromContainer(objDataListItem)
            intItemIndex = GetRowIndex(Me, objDataListItem)
            Dim objGridRowStatus As RowStatus = Nothing
            Dim objGridButton As GridButton
            Dim objGridButtonEventArgs

            If m_intToolbarAction <> ToolbarIcons.Submit AndAlso m_intToolbarAction <> ToolbarIcons.Delete Then
                objGridButton = CType(ApplicationState.Current.CorePage.PageActionObject, GridButton)
            Else
                'objGridButton = CType(objDataListItem.FindControl("btnGridRowDelete"), GridButton)
            End If

            'objGridButtonEventArgs = _
            '    New GridButtonEventArgs(objDataListItem, objGridButton, objGridRowStatus, objGridButton.CommandName, _
            '                             objGridButton.CommandArgument)

            'BeforeDelete is Core Solution specific event which 
            'developer can use to prohibit end user from selecting a particular row
            'by setting corresponding Cancel Variable to True in Event Handler code
            RaiseEvent BeforeDelete(Me, objGridButtonEventArgs, blnCancelDelete)
            If Not blnCancelDelete Then
                RaiseEvent DeleteClick(Me, objGridButtonEventArgs)
                With ApplicationState.Current.CorePage
                    .AppendMode = False

                    If .ScreenType = ScreenTypes.Grid Then
                        .Delete()
                    Else
                        .DetailDelete()
                    End If

                    If .m_IsDefaultDelete Then
                        Me.OccursWithFile.GetDeletedRecord(intItemIndex) = True
                        .m_IsDefaultDelete = False
                    End If

                End With

                'Mark the record deleted only if Delete / DetailDelete has set the record as Deleted
                If Not Me.FileObject Is Nothing AndAlso CType(Me.FileObject, BaseFileObject).DeletedRecord Then
                    SetRowStatus(GridRowStatusCommand.Delete, objDataListItem)
                End If
            End If
            'If m_intToolbarAction <> ToolbarIcons.Delete AndAlso m_intToolbarAction <> ToolbarIcons.Submit Then PrepareGridControlsForDisplay(False)
        End Sub

        ''' --- ChangeGridPage -----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of ChangeGridPage.
        ''' </summary>
        ''' <param name="CommandName"></param>
        ''' <param name="CommandArgument"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub ChangeGridPage()
            Dim intCurrentPageSetNumber As Integer

            Select Case ApplicationState.Current.CorePage.PageClick
                Case PaginationClick.First
                    GoToGridPageSet(0)
                Case PaginationClick.Next
                    intCurrentPageSetNumber = ApplicationState.Current.CorePage.CurrentPageSetNumber
                    If intCurrentPageSetNumber <= 0 Then intCurrentPageSetNumber = 1
                    intCurrentPageSetNumber += 1
                    GoToGridPageSet(intCurrentPageSetNumber)

                Case PaginationClick.Previous
                    intCurrentPageSetNumber = ApplicationState.Current.CorePage.CurrentPageSetNumber
                    intCurrentPageSetNumber -= 1
                    GoToGridPageSet(intCurrentPageSetNumber)

                Case PaginationClick.Last
                    Dim intTotalPageSets As Integer
                    intTotalPageSets = GetTotalPageSets()
                    GoToGridPageSet(intTotalPageSets)

                Case PaginationClick.GoTo
                    GoToGridPage(ApplicationState.Current.CorePage.CurrentPageNumber)

            End Select


        End Sub

        ''' --- EnableGridNew ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of EnableGridNew.
        ''' </summary>
        ''' <param name="DataListItem"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub EnableGridNew(ByVal DataListItem As DataGridRow)
            Dim objGridRowNew As GridButton

            objGridRowNew = ApplicationState.Current.CorePage.FindChildByType(Of GridButton)()


            With objGridRowNew
                If _
                    (Not m_blnNoNewAppend) AndAlso (Not Me.NoAppend) AndAlso Me.AllowGridNew AndAlso
                    ((Me.m_blnUsingAcceptProcessing AndAlso m_blnAllowEditButton) OrElse
                     Not Me.m_blnUsingAcceptProcessing) Then
                    '.ImageUrl = "~/Images/Controls/Grid_Add_On.gif"
                    '.Attributes.Add("onMouseOver", "this.style.cursor = 'pointer';")
                    .ToolTip = "Add new Row" 'ApplicationState.Current.CorePage.GetToolTip("IM.Grid.AddNewRecordToolTip")
                    .IsEnabled = True
                    .Opacity = 1
                    .Background = New SolidColorBrush(Colors.White)
                    AppendID = .Name
                Else
                    '.ImageUrl = "~/Images/Controls/Grid_Status_None.gif"
                    .IsEnabled = False
                    .Opacity = 0.55

                End If


            End With
            objGridRowNew = Nothing

        End Sub

#End Region
    End Class
End Namespace
