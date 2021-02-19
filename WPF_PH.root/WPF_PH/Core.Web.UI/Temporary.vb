Imports System.ComponentModel
Imports Core.Framework.Core.Framework

Namespace Core.Windows
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: CoreBaseType
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of CoreBaseType.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/22/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
        <Serializable(), _
            EditorBrowsable (EditorBrowsableState.Advanced)> _
    Public Class CoreBaseType
        Implements IDisposable

        Public Reset As ResetTypes = ResetTypes.Reset

        'm_intOccurrence is now constant with value 0, if instance "Occurs", 
        '0 based m_intOccurrence Property of the "Base Page" will be used
        ''' --- m_intOccurrence ----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> Protected Const m_intOccurrence As Integer = 0

        Private m_blnHasReceivedValue As Boolean

        Public m_strVariableName As String
        Protected m_strEditField As String = ""
        Public m_intSize As Integer
        Protected m_blnSigned As Boolean
        Protected Friend m_intOccursTimes As Integer = 0
        Private m_OccursWithFile As IFileObject
        Private m_OccursWithCoreBaseType As CoreBaseType
        Protected m_Page As UI.Page
        Protected m_BaseClass As BaseClassControl
        Protected m_initReset As Boolean = False

        ' Used in a call to FileObject.FOR method
        Protected Friend m_hstNestedForInfo As Hashtable
        ' m_hstNestedForInfo is a list of NestedFor, for the current FileObject
        Private m_strLastForID As String
        ' m_strLastForID denotes the most ID Number for inner most For
        Protected Friend m_intLastForIDNumber As Integer = - 1
        ' m_intLastForIDNumber denotes the most ID Number for inner most For
        Protected Friend m_sorNestedForIDs As SortedList

        'm_blnFromConstructor Flag is used to determine whether initialize is called from constructor
        Protected m_blnFromConstructor As Boolean

        Public GetRecordBuffer As Getter
        Public SetRecordBuffer As Setter
        Public SetEditFlagValue As SetEditFlag

        Private Disposed As Boolean

#Region " Events "

        ''' --- GoToRecordEvent ----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GoToRecordEvent.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
            <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Event GoToRecordEvent (ByVal Sender As Object, ByVal EventArgs As Object, _
                                      ByVal NewRecordPosition As Integer)

        ''' --- GetInitialValue ----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetInitialValue.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
            <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Event GetInitialValue()

#End Region

#Region " Constructor and Destructor "

        ''' --- New ----------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of New.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected Sub New()
            MyBase.New()
        End Sub

#End Region

#Region " Properties "

        'Note: Derived class should have Value property with specific type

        '--------------------------------
        'Occurs Property
        'Returns Integer Number of times this specific type occurs
        '--------------------------------
        ''' --- Occurs -------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Occurs.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property Occurs() As Integer
            Get
                ' m_intOccursTimes is 0 based, so must increment by 1 when returning occurs.
                Return m_intOccursTimes + 1
            End Get
        End Property


        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property Name() As String
            Get
                Return m_strVariableName
            End Get
        End Property

        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property Size() As Integer
            Get
                Return m_intSize
            End Get
        End Property

        '--------------------------------
        'OccursWithFile Property
        'Returns a reference to a FileObject, incase it occurs with a FileObject
        '--------------------------------
        ''' --- OccursWithFile -----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of OccursWithFile.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property OccursWithFile() As IFileObject
            Get
                Return m_OccursWithFile
            End Get
        End Property

        '--------------------------------
        'OccursWithBaseType Property
        'Returns a reference to a CoreBaseType, incase it occurs with a CoreBaseType
        'Note: This property returns CoreBaseType to get a specific type, one needs to typecast
        '--------------------------------
        ''' --- OccursWithBaseType -------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of OccursWithBaseType.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property OccursWithBaseType() As CoreBaseType
            Get
                Return m_OccursWithCoreBaseType
            End Get
        End Property

        ''' --- Occurrence ---------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Occurrence.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected ReadOnly Property Occurrence() As Integer
            Get
                If Not m_Page Is Nothing Then
                    If Me.m_intOccursTimes > 0 Then
                        Return m_Page.m_intOccurrence
                    Else
                        Return m_intOccurrence
                    End If
                Else
                    If Me.m_intOccursTimes > 0 Then
                        Return m_BaseClass.m_intOccurrence
                    Else
                        Return m_intOccurrence
                    End If
                End If
            End Get
        End Property

        ''' --- HasReceivedValue ---------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of HasReceivedValue.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Property HasReceivedValue() As Boolean
            Get
                Return m_blnHasReceivedValue
            End Get
            Set (ByVal Value As Boolean)
                m_blnHasReceivedValue = Value
            End Set
        End Property

#End Region

#Region " Methods "

#Region " Protected/Private Methods "

        ''' --- GetFieldText -------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetFieldText.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected Function GetFieldText() As String
            If Not m_Page Is Nothing Then
                Return m_Page.FieldText
            Else
                Return m_BaseClass.GetFieldText
            End If
        End Function

        ''' --- GetFieldValue -------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetFieldValue.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected Function GetFieldValue() As String
            If Not m_Page Is Nothing Then
                Return m_Page.FieldValue
            Else
                Return m_BaseClass.GetFieldValue
            End If
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
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected Overridable Function Getter (ByVal Sender As Object, ByVal GetterArgs As GetterArgs) As Boolean
            'Should be overrided in derived class
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
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected Overridable Function Setter (ByVal Sender As Object, ByVal SetterArgs As SetterArgs) As Boolean
            'Should be overrided in derived class
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
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected Function SetEditFlag (ByVal Field As String) As Boolean
            m_strEditField = Field
        End Function

        ''' --- CallInitialize -----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of CallInitialize.
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <param name="Size"></param>
        ''' <param name="CoreClass"></param>
        ''' <param name="OccursTimes"></param>
        ''' <param name="ResetType"></param>
        ''' <param name="Signed"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected Overridable Sub CallInitialize (ByVal Name As String, ByVal Size As Integer, _
                                                  ByVal CoreClass As BaseClassControl, ByVal OccursTimes As Integer, _
                                                  ByVal ResetType As ResetTypes, ByVal Signed As Boolean)
            'Initializing variable which is common to each derived type
            m_strVariableName = Name
            m_intSize = Size
            m_BaseClass = CoreClass
            m_intOccursTimes = OccursTimes - 1
            'As Arrays are 0 based and OccursTimes is 1 based
            Reset = ResetType
            m_blnSigned = Signed

            If Not m_BaseClass Is Nothing Then
                With m_BaseClass
                    AddHandler .InitializeInternalValues, AddressOf Initialize
                    AddHandler .LoadPageState, AddressOf LoadPageState
                    AddHandler .SavePageState, AddressOf SavePageState
                End With
                GetRecordBuffer = AddressOf Getter
                SetRecordBuffer = AddressOf Setter
                SetEditFlagValue = AddressOf SetEditFlag
            End If

            m_blnFromConstructor = True

            'Note: We know that at present Initialize is being called two times;
            'from the constructor and from the ResetVariable
            'To Initialize variables specific to a derived class we are calling Initialize Method
            Initialize()
            m_blnFromConstructor = False
        End Sub

        ''' --- CallInitialize -----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of CallInitialize.
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <param name="Size"></param>
        ''' <param name="Page"></param>
        ''' <param name="OccursTimes"></param>
        ''' <param name="ResetType"></param>
        ''' <param name="Signed"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected Overridable Sub CallInitialize (ByVal Name As String, ByVal Size As Integer, ByVal Page As UI.Page, _
                                                  ByVal OccursTimes As Integer, ByVal ResetType As ResetTypes, _
                                                  ByVal Signed As Boolean)
            'Initializing variable which is common to each derived type
            m_strVariableName = Name
            m_intSize = Size
            m_Page = Page
            m_intOccursTimes = OccursTimes - 1
            'As Arrays are 0 based and OccursTimes is 1 based
            Reset = ResetType
            m_blnSigned = Signed

            If Not m_Page Is Nothing Then
                With m_Page
                    AddHandler .InitializeInternalValues, AddressOf Initialize
                    AddHandler .ResetInitialValues, AddressOf ResetInitialValues
                    AddHandler .LoadPageState, AddressOf LoadPageState
                    AddHandler .SavePageState, AddressOf SavePageState
                End With
                GetRecordBuffer = AddressOf Getter
                SetRecordBuffer = AddressOf Setter
                SetEditFlagValue = AddressOf SetEditFlag
            End If

            m_blnFromConstructor = True

            'Note: We know that at present Initialize is being called two times;
            'from the constructor and from the ResetVariable
            'To Initialize variables specific to a derived class we are calling Initialize Method
            Initialize()
            m_blnFromConstructor = False
        End Sub

        ''' --- CallInitialize -----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of CallInitialize.
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <param name="Size"></param>
        ''' <param name="Page"></param>
        ''' <param name="OccursTimes"></param>
        ''' <param name="ResetType"></param>
        ''' <param name="Signed"></param>
        ''' <param name="OccursWith"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected Overridable Sub CallInitialize (ByVal Name As String, ByVal Size As Integer, ByVal Page As UI.Page, _
                                                  ByVal OccursTimes As Integer, ByVal ResetType As ResetTypes, _
                                                  ByVal Signed As Boolean, ByVal OccursWith As IFileObject)
            m_OccursWithFile = OccursWith
            If OccursTimes = 0 Then
                OccursTimes = 1
            End If
            CallInitialize (Name, Size, Page, OccursTimes, ResetType, Signed)
        End Sub

        ''' --- CallInitialize -----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of CallInitialize.
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <param name="Size"></param>
        ''' <param name="Page"></param>
        ''' <param name="OccursTimes"></param>
        ''' <param name="ResetType"></param>
        ''' <param name="Signed"></param>
        ''' <param name="OccursWith"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected Overridable Sub CallInitialize (ByVal Name As String, ByVal Size As Integer, ByVal Page As UI.Page, _
                                                  ByVal OccursTimes As Integer, ByVal ResetType As ResetTypes, _
                                                  ByVal Signed As Boolean, ByVal OccursWith As CoreBaseType)
            m_OccursWithCoreBaseType = OccursWith
            CallInitialize (Name, Size, Page, OccursTimes, ResetType, Signed)
        End Sub

        ''' --- CallInitialize -----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of CallInitialize.
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <param name="Size"></param>
        ''' <param name="CoreClass"></param>
        ''' <param name="OccursTimes"></param>
        ''' <param name="ResetType"></param>
        ''' <param name="Signed"></param>
        ''' <param name="OccursWith"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected Overridable Sub CallInitialize (ByVal Name As String, ByVal Size As Integer, _
                                                  ByVal CoreClass As BaseClassControl, ByVal OccursTimes As Integer, _
                                                  ByVal ResetType As ResetTypes, ByVal Signed As Boolean, _
                                                  ByVal OccursWith As IFileObject)
            m_OccursWithFile = OccursWith
            If OccursTimes = 0 Then
                OccursTimes = 1
            End If
            CallInitialize (Name, Size, CoreClass, OccursTimes, ResetType, Signed)
        End Sub

        ''' --- CallInitialize -----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of CallInitialize.
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <param name="Size"></param>
        ''' <param name="CoreClass"></param>
        ''' <param name="OccursTimes"></param>
        ''' <param name="ResetType"></param>
        ''' <param name="Signed"></param>
        ''' <param name="OccursWith"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected Overridable Sub CallInitialize (ByVal Name As String, ByVal Size As Integer, _
                                                  ByVal CoreClass As BaseClassControl, ByVal OccursTimes As Integer, _
                                                  ByVal ResetType As ResetTypes, ByVal Signed As Boolean, _
                                                  ByVal OccursWith As CoreBaseType)
            m_OccursWithCoreBaseType = OccursWith
            CallInitialize (Name, Size, CoreClass, OccursTimes, ResetType, Signed)
        End Sub

        ''' --- Initialize ---------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Initialize.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected Overridable Sub Initialize()
            'Should be implemented in derived class
        End Sub

        ''' --- ResetInitialValue ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of ResetInitialValue.
        ''' </summary>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected Overridable Sub ResetInitialValues()
            If Me.Reset = ResetTypes.Reset Then
                m_initReset = True
                Me.Initialize()
                m_initReset = False
            End If
        End Sub

        ''' --- LoadPageState ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of LoadPageState.
        ''' </summary>
        ''' <param name="Sender"></param>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected Overridable Sub LoadPageState (ByVal Sender As Object, ByVal e As PageStateEventArgs, _
                                                 ByVal blnFromAppend As Boolean)
            'Should be implemented in derived class
        End Sub

        ''' --- SavePageState ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of SavePageState.
        ''' </summary>
        ''' <param name="Sender"></param>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected Overridable Sub SavePageState (ByVal Sender As Object, ByVal e As PageStateEventArgs)
            'Should be implemented in derived class
        End Sub

        ''' --- UseInitialValue ----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of UseInitialValue.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected Function UseInitialValue() As Boolean
            Dim blnUseInitialValue As Boolean

            If Me.HasReceivedValue Then
                'If parameter is Received from calling screen, use value from the State
                Return False
            End If

            'By default, use the value retrieved from "State"
            blnUseInitialValue = False

            If m_Page Is Nothing Then
                ' Is we are using the BaseClassControl, then we need to always
                ' retrieve the value from state since the mode won't change.
                blnUseInitialValue = False
            Else
                With m_Page
                    Select Case .PageActionType
                        Case PageActionType.InFieldValidation, PageActionType.DataListButtonClick, _
                            PageActionType.DesignerClick
                            'In case of InFieldValidation, we will use the value retrieved from State
                            blnUseInitialValue = False
                            'instead, use the value retrieved from "State"
                        Case PageActionType.PaginationClick
                            If Reset = ResetTypes.Reset OrElse Reset = ResetTypes.NotApplicable Then
                                'Use the value Initial Value
                                blnUseInitialValue = True
                            Else
                                'instead, use the value retrieved from the "State"
                                blnUseInitialValue = False
                            End If
                        Case Else
                            'Ideally only new request and Toolbar click should be 
                            'evaluated over here
                            Dim intPageModeType As PageModeTypes
                            Dim intToolbarAction As ToolbarIcons
                            Dim blnIsPostback As Boolean
                            'blnIsPostback = (Not .IsNewRequest)
                            intPageModeType = .Mode
                            intToolbarAction = .ToolbarAction
                            Select Case Reset
                                Case ResetTypes.Reset
                                    If _
                                        intToolbarAction = ToolbarIcons.Add OrElse _
                                        (Not blnIsPostback AndAlso intPageModeType = PageModeTypes.Entry) Then
                                        'Reset the value, if user Selected "Add" toolbar button or
                                        'screen is opened in "Entry" Mode 

                                        'Do not reset the state if it is append from entry
                                        If Not .IsAppendFromEntry Then
                                            blnUseInitialValue = True
                                            'Initializing with the default or passed value
                                            If m_Page.m_clearRequestInitValues Then
                                                'm_Page.InternalPageState (m_strVariableName + "_RV") = Nothing
                                            End If
                                        End If

                                    ElseIf _
                                        IsFindOrNavigation (intToolbarAction) OrElse _
                                        (Not blnIsPostback AndAlso intPageModeType = PageModeTypes.Find) Then _
                                        ' or Select ????
                                        'Reset the value, if user Selected "Find" toolbar button or
                                        'screen is opened in "Find" Mode 
                                        blnUseInitialValue = True
                                        'Initializing with the default or passed value
                                        If m_Page.m_clearRequestInitValues Then
                                            'm_Page.InternalPageState (m_strVariableName + "_RV") = Nothing
                                        End If
                                    End If
                                Case ResetTypes.NotApplicable
                                    If _
                                        (intToolbarAction = ToolbarIcons.Add OrElse _
                                         (Not blnIsPostback AndAlso intPageModeType = PageModeTypes.Entry)) Then
                                        'Reset the value, if user Selected "Add" toolbar button or screen is opened in "Entry" Mode 

                                        'Do not reset the state if it is append from entry
                                        If Not .IsAppendFromEntry Then
                                            blnUseInitialValue = True
                                            'Initializing with the default or passed value
                                        End If
                                    ElseIf _
                                        (intToolbarAction = ToolbarIcons.Find OrElse _
                                         (Not blnIsPostback AndAlso intPageModeType = PageModeTypes.Find)) Then
                                        'Reset the value, if user Selected "Find" toolbar button or screen is opened in "Find" Mode 

                                        blnUseInitialValue = True
                                        'Initializing with the default or passed value
                                    ElseIf _
                                        IsFindOrNavigation (intToolbarAction) OrElse _
                                        (Not blnIsPostback AndAlso intPageModeType = PageModeTypes.Find) Then _
                                        ' or Select ????
                                        'Reset the value, if user Selected "Find" toolbar button (or navigation buttons) or
                                        'screen is opened in "Find" Mode 
                                        blnUseInitialValue = True
                                        'Initializing with the default or passed value
                                    End If
                                Case ResetTypes.ResetAtMode
                                    'Note: Unlike legacy during the retrieval initialization phase, 
                                    'if the data record retrieval fails, the temporary item is WILL BE reset, to the Initial Value.
                                    Select Case intToolbarAction
                                        Case ToolbarIcons.Add
                                            'Do not reset the state if it is append from entry
                                            If Not .IsAppendFromEntry Then
                                                blnUseInitialValue = True
                                                'Initializing with the default or passed value
                                            End If
                                        Case ToolbarIcons.Find
                                            If Not m_Page.InPostFind Then
                                                blnUseInitialValue = True
                                                'Initializing with the default or passed value
                                            End If
                                        Case ToolbarIcons.First, ToolbarIcons.Last, ToolbarIcons.Previous, _
                                            ToolbarIcons.Next ' or Select ????
                                            blnUseInitialValue = False
                                            ' Use the value retrieved from "State".
                                    End Select
                                Case ResetTypes.ResetAtStartup
                                    If (Not blnIsPostback) Then
                                        blnUseInitialValue = True
                                        'Initializing with the default or passed value
                                    End If
                            End Select
                    End Select
                End With
            End If
            Return blnUseInitialValue
        End Function

        Private Function IsFindOrNavigation (ByVal Action As ToolbarIcons) As Boolean

            Select Case Action
                Case ToolbarIcons.Find, ToolbarIcons.First, ToolbarIcons.Last, ToolbarIcons.Previous, ToolbarIcons.Next
                    Return True
                Case Else
                    Return False
            End Select

        End Function

        ''' --- CopyArray ----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of CopyArray.
        ''' </summary>
        ''' <param name="Source"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected Function CopyArray (ByVal Source() As Boolean) As Boolean()
            If Source Is Nothing Then
                Return Nothing
            Else
                'This method is used to return a NEW copy of an "Source" in "Destination"
                Dim blnTemp(Source.Length - 1) As Boolean
                Array.Copy (Source, blnTemp, Source.Length)
                Return blnTemp
            End If
        End Function

        ''' --- CopyArray ----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of CopyArray.
        ''' </summary>
        ''' <param name="Source"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected Function CopyArray (ByVal Source() As String) As String()
            If Source Is Nothing Then
                Return Nothing
            Else
                'This method is used to return a NEW copy of an "Source" in "Destination"
                Dim strTemp(Source.Length - 1) As String
                Array.Copy (Source, strTemp, Source.Length)
                Return strTemp
            End If
        End Function

        ''' --- CopyArray ----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of CopyArray.
        ''' </summary>
        ''' <param name="Source"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected Function CopyArray (ByVal Source() As Date) As Date()
            If Source Is Nothing Then
                Return Nothing
            Else
                'This method is used to return a NEW copy of an "Source" in "Destination"
                Dim dteTemp(Source.Length - 1) As Date
                Array.Copy (Source, dteTemp, Source.Length)
                Return dteTemp
            End If
        End Function

        ''' --- CopyArray ----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of CopyArray.
        ''' </summary>
        ''' <param name="Source"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected Function CopyArray (ByVal Source() As Decimal) As Decimal()
            If Source Is Nothing Then
                Return Nothing
            Else
                'This method is used to return a NEW copy of an "Source" in "Destination"
                Dim dblTemp(Source.Length - 1) As Decimal
                Array.Copy (Source, dblTemp, Source.Length)
                Return dblTemp
            End If
        End Function

        ''' --- CopyArray ----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of CopyArray.
        ''' </summary>
        ''' <param name="Source"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected Function CopyArray (ByVal Source() As Integer) As Integer()
            If Source Is Nothing Then
                Return Nothing
            Else
                'This method is used to return a NEW copy of an "Source" in "Destination"
                Dim intTemp(Source.Length - 1) As Integer
                Array.Copy (Source, intTemp, Source.Length)
                Return intTemp
            End If
        End Function

        ''' --- RaiseGetInitialValue -----------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of RaiseGetInitialValue.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected Sub RaiseGetInitialValue()
            '-----------December 6, 2004
            'Get the overrided initial value through an Event Handler
            'In the handler of InitialValue developer should set the "InitialValue" property and NOT
            'the "Value" property. "InitialValue" is later used to assign it to the "Value" property

            'In Accept Processing, following is the behaviour of Setting InitialValue
            ' 1. During the New Request (IsNewRequest property is True), Initial Value will be set through 
            '    the BasePage's InitializeScreen Procedure, which in turn gets called from 
            '    PerformOperationInitializationForAcceptProcessing
            ' 2. During the subsequent requests, Raising Load Page State Event (RaiseLoadPageState)
            '    calls LoadPageState in each Temporary variable which in turn determines whether to use
            '    the "InitialValue" or the value from the State
            '-----------December 6, 2004
            '-----------December 13, 2004
            ' 3. Will not call InitialValue, if value is initially received from the calling screen
            '-----------December 13, 2004
            If Not Me.HasReceivedValue Then
                RaiseEvent GetInitialValue()
            End If
        End Sub

#End Region

        ''' --- GoToRecord ---------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GoToRecord.
        ''' </summary>
        ''' <param name="Sender"></param>
        ''' <param name="EventArgs"></param>
        ''' <param name="NewRecordPosition"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Overridable Sub GoToRecord (ByVal Sender As Object, ByVal EventArgs As Object, _
                                           ByVal NewRecordPosition As Integer)
            If NewRecordPosition <> Occurrence Then
                RaiseEvent GoToRecordEvent (Me, Nothing, NewRecordPosition)
            End If
        End Sub

        ''' --- WireNavigationEvents -----------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of WireNavigationEvents.
        ''' </summary>
        ''' <param name="DependentFileObject"></param>
        ''' <param name="WireNavigationEvents"></param>
        ''' <param name="WireAddEvent"></param>
        ''' <param name="WireEditEvent"></param>
        ''' <param name="WireDeleteEvent"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Sub WireNavigationEvents (ByVal DependentFileObject As BaseFileObject, _
                                         ByVal WireNavigationEvents As Boolean, ByVal WireAddEvent As Boolean, _
                                         ByVal WireEditEvent As Boolean, ByVal WireDeleteEvent As Boolean)
            If WireNavigationEvents Then
                AddHandler Me.GoToRecordEvent, AddressOf DependentFileObject.GoToRecord
            End If
        End Sub

        ''' --- WireNavigationEvents -----------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of WireNavigationEvents.
        ''' </summary>
        ''' <param name="DependentCoreBaseType"></param>
        ''' <param name="WireNavigationEvents"></param>
        ''' <param name="WireAddEvent"></param>
        ''' <param name="WireEditEvent"></param>
        ''' <param name="WireDeleteEvent"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Sub WireNavigationEvents (ByVal DependentCoreBaseType As CoreBaseType, _
                                         ByVal WireNavigationEvents As Boolean, ByVal WireAddEvent As Boolean, _
                                         ByVal WireEditEvent As Boolean, ByVal WireDeleteEvent As Boolean)
            If WireNavigationEvents Then
                AddHandler Me.GoToRecordEvent, AddressOf DependentCoreBaseType.GoToRecord
            End If
        End Sub

        ''' --- For ----------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of For.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function [For]() As Boolean
            'Note: in case of calls to nested For call NestedFor with ID starting with "For"
            Return NestedFor ("InterFor1")
        End Function

        ''' --- NestedFor ----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of NestedFor.
        ''' </summary>
        ''' <param name="ForID"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function NestedFor (ByVal ForID As String) As Boolean
            'Note: in case of calls to nested For call NestedFor with ID starting with "For"

            'TODO: Needs to be tested
            'Notes:
            'The behaviour of For function has following differences from the Legacy App:
            '1.	It will produce unexpected results if it has direct or indirect nested For/WhileRetrieve (discussed in WhileRetrieve of BaseFileObject).
            '2. OccursTimes is assumed to be One based, however m_intOccurrence
            '   which is used to loop through all occurrence is zero based
            '3. To access the global Occurrence use Occurrence Property which is one based

            If m_hstNestedForInfo Is Nothing Then m_hstNestedForInfo = New Hashtable

            'If m_hstNestedForInfo contains the passed ForID,
            'Move to the next Record using the Occurrence
            'Otherwise see Else part for comments
            If m_hstNestedForInfo.Contains (ForID) Then
                ' Temp fix.  Only go through number of occurrence of records found.
                ' Changed to check the number of records in UnderlyingDatatable.  This should have the number
                ' of occurrences available.
                If _
                    Not Me.OccursWithFile Is Nothing AndAlso _
                    (m_Page.m_intOccurrence + 1) >= Me.OccursWithFile.UnderlyingDataTable.Rows.Count Then
                    Break (ForID)
                    Return False
                End If

                ' Reached at either Last Value in FileObject i.e. EOF or 
                ' upto Occurs then Reset OccursTimes and Position in an Array
                If (m_Page.m_intOccurrence + 1) >= Me.Occurs Then _
                    'm_intOccurrence is zero based and OccursTimes is one based
                    'we need to reset some variables inside the Break method
                    'so that subsequent FOR Statements (if any) can start 
                    'from First Value
                    Break (ForID)
                    'We are using Break to reset these variables

                    'Return False so that we can exit from the Do While Loop in derived Page
                    Return False
                Else
                    'Move to next Occurrence and bind Grid Fields if screen has grid
                    m_Page.SetOccurrence (m_Page.m_intOccurrence + 1)
                End If
            Else
                'If m_hstNestedForInfo doesn't contain the passed ForID
                'Create a new instance of ForInfo using the current occurrence and CurrentRow
                'and add it to the m_hstNestedForInfo
                m_hstNestedForInfo.Add (ForID, New ForInfo (m_Page.m_intOccurrence, m_Page.m_intOccurrence))

                'Increment the m_intLastForIDNumber which denotes the ID number for inner most For
                m_intLastForIDNumber += 1
                If m_intLastForIDNumber = 0 Then
                    'If this is the first (outer most) For
                    'Create the m_sorNestedForIDs
                    m_sorNestedForIDs = New SortedList

                    'Update m_sorNestedForIDs with the ForID, which is used 
                    'to determine For in Break (w/o parameters) method
                    m_sorNestedForIDs.Add (m_intLastForIDNumber, ForID)
                End If

                'Start from the first Value i.e. 0
                m_Page.SetOccurrence (0)
            End If

            'Return True to continue looping through all records in a file in derived Page
            Return True

        End Function

        ''' --- Break --------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Break.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Sub Break()
            'This function can be called from the derived page whenever there is a Break inside the For loop

            'If "For" and "Break" method is used properly, m_strLastForID should always have
            'the value set during a Call to "For" or "ForMissing"
            Me.Break (Me.m_strLastForID)
        End Sub

        ''' --- Break --------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Break.
        ''' </summary>
        ''' <param name="ForID"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Private Sub Break (ByVal ForID As String)
            'This function should not be called from outside the Base Page

            If Not m_hstNestedForInfo.Contains (ForID) Then
                'To avoid Error exit
                Exit Sub
            End If

            Dim objForInfo As ForInfo

            'Get the ForInfo for the passed "ForID"
            objForInfo = CType (m_hstNestedForInfo (ForID), ForInfo)

            'Reset Main Occurrence on the Page to Previous Value and if applicable, bind Grid Fields
            m_Page.SetOccurrence (objForInfo.PreviousOccurrence)

            'Release the reference to ForInfo
            objForInfo = Nothing

            'Remove the ForInfo object from NestedForInfo hash table
            m_hstNestedForInfo.Remove (ForID)

            'Reduce the LastForIDNumber by one
            m_intLastForIDNumber -= 1

            'If there is no nested For left, 
            'remove the reference to m_sorNestedForIDs and m_strLastForID 
            'otherwise get the m_strLastForID from the m_sorNestedForIDs
            If m_intLastForIDNumber = - 1 Then
                m_sorNestedForIDs = Nothing
                m_strLastForID = Nothing

                'Note: m_intLastForIDNumber and m_hstNestedForInfo should work hand-in-hand,
                'if m_intLastForIDNumber becomes negative, ideally m_hstNestedForInfo should not contain any item
                'however to release the reference we are clearing and than releasing the m_hstNestedForInfo
                m_hstNestedForInfo.Clear()
                m_hstNestedForInfo = Nothing
            Else
                m_strLastForID = CStr (m_sorNestedForIDs.Item (m_intLastForIDNumber))
            End If
        End Sub

#End Region

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
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected Overridable Overloads Sub Dispose (ByVal Disposing As Boolean)
            If (Not Me.Disposed) AndAlso Disposing Then
                m_Page = Nothing
                m_BaseClass = Nothing
                GetRecordBuffer = Nothing
                SetRecordBuffer = Nothing
                If Not m_hstNestedForInfo Is Nothing Then
                    m_hstNestedForInfo.Clear()
                    m_hstNestedForInfo = Nothing
                End If

                If Not m_OccursWithCoreBaseType Is Nothing Then
                    m_OccursWithCoreBaseType = Nothing
                End If

                If Not m_OccursWithFile Is Nothing Then
                    m_OccursWithFile = Nothing
                End If
                Reset = Nothing

                If Not Me.GetInitialValueEvent Is Nothing Then
                    RemoveHandler Me.GetInitialValue, _
                        CType (Me.GetInitialValueEvent.GetInvocationList.Clone, GetInitialValueEventHandler)
                End If
            End If
            Disposed = True
        End Sub

        ''' --- Dispose ------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Dispose.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Overloads Sub Dispose() Implements IDisposable.Dispose
            Dispose (True)
        End Sub
    End Class

    'Inherited from EventArgs however no members at present
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: TemporaryEventArgs
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of TemporaryEventArgs.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/22/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
    Public Class TemporaryEventArgs
        Inherits EventArgs
        'No members at present however can be added as and when required
    End Class
End Namespace
