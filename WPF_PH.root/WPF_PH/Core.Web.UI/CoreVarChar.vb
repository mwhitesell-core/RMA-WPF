Imports System.ComponentModel
Imports Core.Framework.Core.Framework
Imports Core.Framework

Namespace Core.Windows
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: CoreVarChar
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' <summary>
    ''' 	This class defines the Renaissance Architect Framework CoreVarChar.
    ''' </summary>
    ''' <remarks>
    '''     The Renaissance Architect implementation of CoreVarChar handles
    '''     Temporary (variable) objects of type VarChar.
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
    Public Class CoreVarChar
        Inherits CoreBaseType

        Private m_strValue() As String
        Private Const cOneSpace As String = " "
        Private Const cDefaultValue As String = cOneSpace
        Private m_strInitialValue As String

#Region " Constructors "

#Region " Constructors with Default Initial Value "

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreVarChar.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Size">An Integer indicating the size of CoreVarChar.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="InitialValue"><i>Optional</i>A String representing the initial value of the object.</param>
        ''' <remarks>
        '''     <para>
        '''         <note>
        '''             This constructor can be used only in a screen or sub-screen.
        '''         </note>
        '''     </para>
        ''' </remarks>
        ''' <example>
        '''     <code>
        '''         Dim EMPLOYEE_NAME As CoreVarChar = New CoreVarChar("EMPLOYEE_NAME", 20, Me)
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Size As Integer, ByVal Page As UI.Page, _
                        Optional ByVal InitialValue As String = cDefaultValue)
            MyBase.New()
            m_strInitialValue = InitialValue
            CallInitialize (Name, Size, Page, 1, ResetTypes.Reset, False)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreVarChar.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Size">An Integer indicating the size of CoreVarChar.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="ResetType">A ResetType indicating when objects value should be reset.</param>
        ''' <param name="InitialValue"><i>Optional</i>A String representing the initial value of the object.</param>
        ''' <remarks>
        '''     <para>
        '''         <note>
        '''             This constructor can be used only in a screen or sub-screen.
        '''         </note>
        '''     </para>
        ''' </remarks>
        ''' <example>
        '''     <code>
        '''         Dim EMPLOYEE_NAME As CoreVarChar = New CoreVarChar("EMPLOYEE_NAME", 20, Me, ResetTypes.ResetAtStartup)
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Size As Integer, ByVal Page As UI.Page, _
                        ByVal ResetType As ResetTypes, Optional ByVal InitialValue As String = cDefaultValue)
            MyBase.New()
            m_strInitialValue = InitialValue
            CallInitialize (Name, Size, Page, 1, ResetType, False)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreVarChar.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Size">An Integer indicating the size of CoreVarChar.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="OccursTimes">An Integer representing the number of times this CoreVarChar occurs in Grid.</param>
        ''' <param name="InitialValue"><i>Optional</i>A String representing the initial value of the object.</param>
        ''' <remarks>
        '''     <para>
        '''         <note>
        '''             This constructor can be used only in a screen or sub-screen.
        '''         </note>
        '''     </para>
        ''' </remarks>
        ''' <example>
        '''     <code>
        '''         Dim EMPLOYEE_NAME As CoreVarChar = New CoreVarChar("EMPLOYEE_NAME", 20, Me, 6)
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Size As Integer, ByVal Page As UI.Page, ByVal OccursTimes As Integer, _
                        Optional ByVal InitialValue As String = cDefaultValue)
            MyBase.New()
            m_strInitialValue = InitialValue
            CallInitialize (Name, Size, Page, OccursTimes, ResetTypes.Reset, False)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreVarChar.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Size">An Integer indicating the size of CoreVarChar.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="OccursTimes">An Integer representing the number of times this CoreVarChar occurs in Grid.</param>
        ''' <param name="ResetType">A ResetType indicating when objects value should be reset.</param>
        ''' <param name="InitialValue"><i>Optional</i>A String representing the initial value of the object.</param>
        ''' <remarks>
        '''     <para>
        '''         <note>
        '''             This constructor can be used only in a screen or sub-screen.
        '''         </note>
        '''     </para>
        ''' </remarks>
        ''' <example>
        '''     <code>
        '''         Dim EMPLOYEE_NAME As CoreVarChar = New CoreVarChar("EMPLOYEE_NAME", 20, Me, 6, ResetTypes.ResetAtStartup)
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Size As Integer, ByVal Page As UI.Page, ByVal OccursTimes As Integer, _
                        ByVal ResetType As ResetTypes, Optional ByVal InitialValue As String = cDefaultValue)
            MyBase.New()
            m_strInitialValue = InitialValue
            CallInitialize (Name, Size, Page, OccursTimes, ResetType, False)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreVarChar.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Size">An Integer indicating the size of CoreVarChar.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="OccursWithFile">A FileObject which CoreVarChar occurs with.</param>
        ''' <param name="InitialValue"><i>Optional</i>A String representing the initial value of the object.</param>
        ''' <remarks>
        '''     <para>
        '''         <note>
        '''             This constructor can be used only in a screen or sub-screen.
        '''         </note>
        '''     </para>
        ''' </remarks>
        ''' <example>
        '''     <code>
        '''         Dim EMPLOYEE_NAME As CoreVarChar = New CoreVarChar("EMPLOYEE_NAME", 20, Me, fleCOMPANY)
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Size As Integer, ByVal Page As UI.Page, _
                        ByVal OccursWithFile As IFileObject, Optional ByVal InitialValue As String = cDefaultValue)
            MyBase.New()
            m_strInitialValue = InitialValue
            With OccursWithFile
                CallInitialize (Name, Size, Page, .Occurs, ResetTypes.NotApplicable, False, OccursWithFile)
                AddHandler .GoToRecordEvent, AddressOf GoToRecord
            End With
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreVarChar.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Size">An Integer indicating the size of CoreVarChar.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="OccursWithCoreBaseType">A CoreBaseType which CoreVarChar occurs with.</param>
        ''' <param name="InitialValue"><i>Optional</i>A String representing the initial value of the object.</param>
        ''' <remarks>
        '''     <para>
        '''         <note>
        '''             This constructor can be used only in a screen or sub-screen.
        '''         </note>
        '''     </para>
        ''' </remarks>
        ''' <example>
        '''     <code>
        '''         Dim EMPLOYEE_NAME As CoreVarChar = New CoreVarChar("EMPLOYEE_NAME", 20, Me, strCOMPANY)
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Size As Integer, ByVal Page As UI.Page, _
                        ByVal OccursWithCoreBaseType As CoreBaseType, _
                        Optional ByVal InitialValue As String = cDefaultValue)
            MyBase.New()
            m_strInitialValue = InitialValue
            With OccursWithCoreBaseType
                CallInitialize (Name, Size, Page, .Occurs, ResetTypes.NotApplicable, False, OccursWithCoreBaseType)
                AddHandler .GoToRecordEvent, AddressOf GoToRecord
            End With
        End Sub

#End Region

#End Region

#Region " Public Property "

        Public ReadOnly Property FirstValue() As String
            Get
                Return m_strValue (0)
            End Get
        End Property

        Public ReadOnly Property LastValue() As String
            Get
                Dim tmpOccurs As Integer = Me.Occurs - 1
                If tmpOccurs < 0 Then tmpOccurs = 0
                Return m_strValue (tmpOccurs)
            End Get
        End Property

        ''' --- Value --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	The value of the current <B>CoreVarChar</B> instance.
        ''' </summary>
        ''' <value>
        '''     A String representing the value of the <B>CoreVarChar</B>.
        ''' </value>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        '''     <code>
        '''         Dim myVAR_CHAR as CoreVarChar = New CoreVarChar("myVAR_CHAR", 4, Me)
        '''
        '''         If myVAR_CHAR.Value = "YES" Then
        '''             .
        '''             .
        '''         End if
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Property Value() As String
            Get
                If m_strEditField = m_strVariableName Then
                    Return ValidatedValue (GetFieldText())
                Else
                    Return ValidatedValue (m_strValue (Occurrence))
                End If
            End Get
            Set (ByVal Value As String)
                m_strValue (Occurrence) = ValidatedValue (Value)
            End Set
        End Property

        ''' --- NullValue ----------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Used to see if CoreVarChar is empty.
        ''' </summary>
        ''' <returns>
        '''     One space if the trimed valued is an empty string.
        ''' </returns>
        ''' <remarks>
        '''     <note>
        '''         <B>NullValue</B> should only be used when trailing spaces are not required.
        '''     </note>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public ReadOnly Property NullValue() As String
            Get
                Dim strValue As String
                strValue = m_strValue (Occurrence)
                If strValue.Trim = String.Empty Then
                    Return cOneSpace
                    'Return One Space
                End If

                Return strValue
            End Get
        End Property

        ''' --- InitialValue -------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Gets or sets the Initial Value of the <B>CoreVarChar</B>.
        ''' </summary>
        ''' <value>
        '''     A String representing the initial value of the <B>CoreVarChar</B>.
        ''' </value>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        '''     <code>
        '''         Dim myVAR_CHAR as CoreVarChar = New CoreVarChar("myVAR_CHAR", 4, Me)
        '''
        '''         myVAR_CHAR.InitialValue = 10 
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Property InitialValue() As String
            Get
                Return m_strInitialValue
            End Get
            Set (ByVal Value As String)
                m_strInitialValue = Value
            End Set
        End Property

        ''' --- ToString -----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of ToString.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Overrides Function ToString() As String
            Return m_strValue (Occurrence).ToString
        End Function

#End Region

#Region " Public Methods "

        ''' --- ResetInitialValues -------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Resets the initial value based on the datatype.  
        ''' </summary>
        ''' <remarks>
        ''' Note: Called only from ghost screens for improved performance.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub ResetInitialValues()
            ResetInitialValues (cEmptyString)
        End Sub

        ''' --- ResetInitialValues -------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Resets the initial value. 
        ''' </summary>
        ''' <param name="InitialValue">The value to assign as the initial value</param>
        ''' <remarks>
        ''' Note: Called only from ghost screens for improved performance.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub ResetInitialValues (ByVal InitialValue As String)
            m_strInitialValue = ValidatedValue (InitialValue)
            Initialize()
        End Sub

        ''' --- Equals -------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Equals.
        ''' </summary>
        ''' <param name="Value"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Overloads Function Equals (ByVal Value As String) As Boolean
            Return (m_strValue (Occurrence).TrimEnd = Value.TrimEnd)
        End Function

#End Region

#Region " Protected/Private Methods "

        ''' --- Initialize ---------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Initialize.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected Overrides Sub Initialize()
            Dim i As Integer

            With m_page
                Dim strInitialValue As String
                strInitialValue = m_strInitialValue.TrimEnd

                If m_blnFromConstructor Then
                    Dim m_intTemp(m_intOccursTimes) As String
                    m_strValue = m_intTemp
                Else
                    'Allow user to override Initial Value through an Event Handler.
                    RaiseGetInitialValue()
                    'For details, see comments on RaiseGetInitialValue method in CoreBaseType
                End If

                If Not Me.HasReceivedValue Then
                    'If m_initReset AndAlso Not m_Page.InternalPageState (m_strVariableName + "_RV") Is Nothing Then
                    '    ' We are initializing RESET variables (not reset at startup or reset at mode).
                    '    ' If we have a Request value, use this to initialize the temporary.
                    '    strInitialValue = m_Page.InternalPageState (m_strVariableName + "_RV")
                    'End If

                    For i = 0 To m_intOccursTimes
                        If _
                            (m_strValue (i) Is Nothing) OrElse m_strValue (i) = cDefaultValue OrElse _
                            m_strValue (i) = strInitialValue Then
                            m_strValue (i) = strInitialValue
                            'Initializing with One Space or passed value
                        Else
                            'We assume that this is a Receiving Variable and Value is set 
                            'somewhere in RetrieveParamsReceived method
                        End If
                    Next
                End If

            End With
        End Sub

                ''' --- LoadPageState ------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of LoadPageState.
        ''' </summary>
        ''' <param name="Sender"></param>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Overrides Sub LoadPageState(Sender As Object, e As PageStateEventArgs,
                                              blnFromAppend As Boolean)
            If UseInitialValue() Then
                'Calling Initialize to get and reset the current value with the Initial value
                Me.Initialize()
                'For details, see comments on RaiseGetInitialValue method in CoreBaseType
            Else
                If m_Page Is Nothing Then
                    m_strValue =
                        Me.CopyArray(CType(m_BaseClass.InternalPageState(m_strVariableName + e.InFieldId), String()))
                Else
                    'If _
                    '    Not blnFromAppend OrElse (blnFromAppend AndAlso (Me.Occurs = 0 OrElse Me.Occurs = 1)) OrElse
                    '    Me.Reset = ResetTypes.ResetAtStartup Then
                    '    m_strValue =
                    '        Me.CopyArray(CType(m_Page.InternalPageState(m_strVariableName + e.InFieldId), String()))
                    'Else
                    '    Me.Initialize()
                    'End If
                End If
            End If
        End Sub

        ''' --- SavePageState ------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of SavePageState.
        ''' </summary>
        ''' <param name="Sender"></param>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Overrides Sub SavePageState(Sender As Object, e As PageStateEventArgs)
            If _
                (e.IncludeObjectState = ObjectState.OnlyResetAtStartUp AndAlso Reset = ResetTypes.ResetAtStartup) OrElse
                e.IncludeObjectState <> ObjectState.OnlyResetAtStartUp Then
                If m_Page Is Nothing Then
                    m_BaseClass.InternalPageState(m_strVariableName + e.InFieldId) = Me.CopyArray(m_strValue)
                Else
                    'If e.IncludeObjectState = ObjectState.OnlyResetAtStartUp AndAlso Reset = ResetTypes.ResetAtStartup _
                    '    Then
                    '    m_Page.InternalPageState(m_strVariableName + "_RAS") = Me.CopyArray(m_strValue)
                    'ElseIf _
                    '    e.IncludeObjectState = ObjectState.MoveStartUpToBaseTypes AndAlso
                    '    Reset = ResetTypes.ResetAtStartup Then
                    '    m_Page.InternalPageState(m_strVariableName + e.InFieldId) =
                    '        Me.CopyArray(CType(m_Page.InternalPageState(m_strVariableName + "_RAS"), String()))
                    'ElseIf Not e.IncludeObjectState = ObjectState.MoveStartUpToBaseTypes Then
                    '    m_Page.InternalPageState(m_strVariableName + e.InFieldId) = Me.CopyArray(m_strValue)
                    '    m_Page.InternalPageState(m_strVariableName + "_RAS") = Me.CopyArray(m_strValue)
                    'End If
                End If
            End If
        End Sub

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
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected Overrides Function Getter (ByVal Sender As Object, ByVal GetterArgs As GetterArgs) As Boolean
            GetterArgs.FieldText = m_strValue (Occurrence)
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
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected Overrides Function Setter (ByVal Sender As Object, ByVal SetterArgs As SetterArgs) As Boolean
            'Assigning the FieldValue to the Value property to observe the Size
            Me.Value = SetterArgs.FieldText
            If SetterArgs.IsRequest Then
                'm_Page.InternalPageState (m_strVariableName + "_RV") = SetterArgs.FieldText
            End If
        End Function

        ''' --- ValidatedValue -----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of ValidatedValue.
        ''' </summary>
        ''' <param name="Value"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Private Function ValidatedValue (ByVal Value As String) As String
            Select Case Math.Sign (Value.Length - m_intsize)
                Case 1
                    Return Value.Substring (0, m_intSize)
                Case Else
                    Return Value.TrimEnd
            End Select
        End Function

#End Region
    End Class
End Namespace
