Imports System.ComponentModel
Imports Core.Framework.Core.Framework
Imports Core.Framework

Namespace Core.Windows
    'Notes: About Initial Value for CoreDate
    'If Core Date "Occurs", then Default Values cannot be supplied
    'In Legacy system, When Temporary variable occurs and Initial value is specified,
    'It initializes the Temporary variable inconsistantly

    '-----------------------------------
    ' Date class used for PowerHouse.
    '-----------------------------------
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: CoreDate
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' <summary>
    ''' 	This class defines the Renaissance Architect Framework CoreDate.
    ''' </summary>
    ''' <remarks>
    '''     The Renaissance Architect implementation of CoreDecimal handles
    '''     Temporary (variable) objects of type Date.
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
    Public Class CoreDate
        Inherits CoreBaseType

#Region "Private Variables"

        ' Private variables.
        Private m_dblValue() As Decimal
        Private Const cDefaultValue As Decimal = cZeroDecimalDate
        Private Const cDefaultDateValue As Date = cZeroDate
        Private m_dblInitialValue As Decimal

#End Region

#Region " Constructors "

#Region " Constructors With Page "

#Region " Constructors with Default as Initial Date Value "

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDate.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Page As UI.Page)
            MyBase.New()
            m_dblInitialValue = cDefaultValue
            CallInitialize (Name, 0, Page, 1, ResetTypes.Reset, True)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDate.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="ResetType">A ResetType indicating when objects value should be reset.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Page As UI.Page, ByVal ResetType As ResetTypes)
            MyBase.New()
            m_dblInitialValue = cDefaultValue
            CallInitialize (Name, 0, Page, 1, ResetType, True)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDate.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="OccursTimes">An Integer representing the number of times this CoreDate occurs in Grid.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Page As UI.Page, ByVal OccursTimes As Integer)
            MyBase.New()
            m_dblInitialValue = cDefaultValue
            CallInitialize (Name, 0, Page, OccursTimes, ResetTypes.Reset, True)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDate.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="OccursTimes">An Integer representing the number of times this CoreDate occurs in Grid.</param>
        ''' <param name="ResetType">A ResetType indicating when objects value should be reset.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Page As UI.Page, ByVal OccursTimes As Integer, _
                        ByVal ResetType As ResetTypes)
            MyBase.New()
            m_dblInitialValue = cDefaultValue
            CallInitialize (Name, 0, Page, OccursTimes, ResetType, True)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDate.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="OccursWith">A FileObject which CoreDate occurs with.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Page As UI.Page, ByVal OccursWith As IFileObject)
            MyBase.New()
            m_dblInitialValue = cDefaultValue
            With OccursWith
                CallInitialize (Name, 0, Page, .Occurs, ResetTypes.NotApplicable, True, OccursWith)
                AddHandler .GoToRecordEvent, AddressOf GoToRecord
            End With
        End Sub

#End Region

#Region " Constructors with Passed Decimal as Initial value "

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDate.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Page As UI.Page, ByVal InitialValue As Decimal)
            MyBase.New()
            m_dblInitialValue = InitialValue
            CallInitialize (Name, 0, Page, 1, ResetTypes.Reset, True)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDate.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="ResetType">A ResetType indicating when objects value should be reset.</param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Page As UI.Page, ByVal ResetType As ResetTypes, _
                        ByVal InitialValue As Object)
            MyBase.New()
            m_dblInitialValue = CDec (InitialValue)
            CallInitialize (Name, 0, Page, 1, ResetType, True)
        End Sub

        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Page As UI.Page, ByVal ResetType As ResetTypes, _
                        ByVal InitialValue As Decimal)
            MyBase.New()
            m_dblInitialValue = InitialValue
            CallInitialize (Name, 0, Page, 1, ResetType, True)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDate.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="OccursTimes">An Integer representing the number of times this CoreDate occurs in Grid.</param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Page As UI.Page, ByVal OccursTimes As Integer, _
                        ByVal InitialValue As Decimal)
            MyBase.New()
            m_dblInitialValue = InitialValue
            CallInitialize (Name, 0, Page, OccursTimes, ResetTypes.Reset, True)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDate.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="OccursTimes">An Integer representing the number of times this CoreDate occurs in Grid.</param>
        ''' <param name="ResetType">A ResetType indicating when objects value should be reset.</param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Page As UI.Page, ByVal OccursTimes As Integer, _
                        ByVal ResetType As ResetTypes, ByVal InitialValue As Object)
            MyBase.New()
            m_dblInitialValue = CDec (InitialValue)
            CallInitialize (Name, 0, Page, OccursTimes, ResetType, True)
        End Sub

        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Page As UI.Page, ByVal OccursTimes As Integer, _
                        ByVal ResetType As ResetTypes, ByVal InitialValue As Decimal)
            MyBase.New()
            m_dblInitialValue = InitialValue
            CallInitialize (Name, 0, Page, OccursTimes, ResetType, True)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDate.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="OccursWith">A FileObject which CoreDate occurs with.</param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Page As UI.Page, ByVal OccursWith As IFileObject, _
                        ByVal InitialValue As Object)
            MyBase.New()
            m_dblInitialValue = CDec (InitialValue)
            With OccursWith
                CallInitialize (Name, 0, Page, .Occurs, ResetTypes.NotApplicable, True, OccursWith)
                AddHandler .GoToRecordEvent, AddressOf GoToRecord
            End With
        End Sub

        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Page As UI.Page, ByVal OccursWith As IFileObject, _
                        ByVal InitialValue As Decimal)
            MyBase.New()
            m_dblInitialValue = InitialValue
            With OccursWith
                CallInitialize (Name, 0, Page, .Occurs, ResetTypes.NotApplicable, True, OccursWith)
                AddHandler .GoToRecordEvent, AddressOf GoToRecord
            End With
        End Sub

#End Region

#Region " Constructors with passed Date as Initial value "

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDate.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Page As UI.Page, ByVal InitialValue As Date)
            MyBase.New()
            m_dblInitialValue = _
                CDbl (InitialValue.Year.ToString + Format (InitialValue.Month, "00") + Format (InitialValue.Day, "00"))
            CallInitialize (Name, 0, Page, 1, ResetTypes.Reset, True)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDate.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="ResetType">A ResetType indicating when objects value should be reset.</param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Page As UI.Page, ByVal ResetType As ResetTypes, _
                        ByVal InitialValue As Date)
            MyBase.New()
            m_dblInitialValue = _
                CDbl (InitialValue.Year.ToString + Format (InitialValue.Month, "00") + Format (InitialValue.Day, "00"))
            CallInitialize (Name, 0, Page, 1, ResetType, True)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDate.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="ResetType">A ResetType indicating when objects value should be reset.</param>
        ''' <param name="Signed"></param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Page As UI.Page, ByVal ResetType As ResetTypes, _
                        ByVal Signed As Boolean, ByVal InitialValue As Date)
            MyBase.New()
            m_dblInitialValue = _
                CDbl (InitialValue.Year.ToString + Format (InitialValue.Month, "00") + Format (InitialValue.Day, "00"))
            CallInitialize (Name, 0, Page, 1, ResetType, Signed)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDate.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="OccursTimes">An Integer representing the number of times this CoreDate occurs in Grid.</param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Page As UI.Page, ByVal OccursTimes As Integer, _
                        ByVal InitialValue As Date)
            MyBase.New()
            m_dblInitialValue = _
                CDbl (InitialValue.Year.ToString + Format (InitialValue.Month, "00") + Format (InitialValue.Day, "00"))
            CallInitialize (Name, 0, Page, OccursTimes, ResetTypes.Reset, True)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDate.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="OccursTimes">An Integer representing the number of times this CoreDate occurs in Grid.</param>
        ''' <param name="ResetType">A ResetType indicating when objects value should be reset.</param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Page As UI.Page, ByVal OccursTimes As Integer, _
                        ByVal ResetType As ResetTypes, ByVal InitialValue As Date)
            MyBase.New()
            m_dblInitialValue = _
                CDbl (InitialValue.Year.ToString + Format (InitialValue.Month, "00") + Format (InitialValue.Day, "00"))
            CallInitialize (Name, 0, Page, OccursTimes, ResetType, True)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDate.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="OccursTimes">An Integer representing the number of times this CoreDate occurs in Grid.</param>
        ''' <param name="ResetType">A ResetType indicating when objects value should be reset.</param>
        ''' <param name="Signed"></param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Page As UI.Page, ByVal OccursTimes As Integer, _
                        ByVal ResetType As ResetTypes, ByVal Signed As Boolean, ByVal InitialValue As Date)
            MyBase.New()
            m_dblInitialValue = _
                CDbl (InitialValue.Year.ToString + Format (InitialValue.Month, "00") + Format (InitialValue.Day, "00"))
            CallInitialize (Name, 0, Page, OccursTimes, ResetType, Signed)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDate.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="OccursWith">A FileObject which CoreDate occurs with.</param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Page As UI.Page, ByVal OccursWith As IFileObject, _
                        ByVal InitialValue As Date)
            MyBase.New()
            m_dblInitialValue = _
                CDbl (InitialValue.Year.ToString + Format (InitialValue.Month, "00") + Format (InitialValue.Day, "00"))
            With OccursWith
                CallInitialize (Name, 0, Page, .Occurs, ResetTypes.NotApplicable, True, OccursWith)
                AddHandler .GoToRecordEvent, AddressOf GoToRecord
            End With
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDate.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="OccursWith">A FileObject which CoreDate occurs with.</param>
        ''' <param name="Signed"></param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Page As UI.Page, ByVal OccursWith As IFileObject, _
                        ByVal Signed As Boolean, ByVal InitialValue As Date)
            MyBase.New()
            m_dblInitialValue = _
                CDbl (InitialValue.Year.ToString + Format (InitialValue.Month, "00") + Format (InitialValue.Day, "00"))
            With OccursWith
                CallInitialize (Name, 0, Page, .Occurs, ResetTypes.NotApplicable, Signed, OccursWith)
                AddHandler .GoToRecordEvent, AddressOf GoToRecord
            End With
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDate.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Size">An Integer indicating the size of CoreDate.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="OccursWithCoreBaseType">A CoreBaseType which CoreDate occurs with.</param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Never)> _
        Public Sub New (ByVal Name As String, ByVal Size As Integer, ByVal Page As UI.Page, _
                        ByVal OccursWithCoreBaseType As CoreBaseType, ByVal InitialValue As Date)
            MyBase.New()
            m_dblInitialValue = _
                CDbl (InitialValue.Year.ToString + Format (InitialValue.Month, "00") + Format (InitialValue.Day, "00"))
            With OccursWithCoreBaseType
                CallInitialize (Name, Size, Page, .Occurs, ResetTypes.NotApplicable, False, OccursWithCoreBaseType)
                AddHandler .GoToRecordEvent, AddressOf GoToRecord
            End With
        End Sub

#End Region

#End Region

#Region " Constructors With BaseClass "

#Region " Constructors with Default as Initial Date Value "

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDate.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal CoreClass As BaseClassControl)
            MyBase.New()
            m_dblInitialValue = cDefaultValue
            CallInitialize(Name, 0, CoreClass, 1, ResetTypes.Reset, True)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDate.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="ResetType">A ResetType indicating when objects value should be reset.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal CoreClass As BaseClassControl, ByVal ResetType As ResetTypes)
            MyBase.New()
            m_dblInitialValue = cDefaultValue
            CallInitialize(Name, 0, CoreClass, 1, ResetType, True)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDate.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="OccursTimes">An Integer representing the number of times this CoreDate occurs in Grid.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal CoreClass As BaseClassControl, ByVal OccursTimes As Integer)
            MyBase.New()
            m_dblInitialValue = cDefaultValue
            CallInitialize(Name, 0, CoreClass, OccursTimes, ResetTypes.Reset, True)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDate.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="OccursTimes">An Integer representing the number of times this CoreDate occurs in Grid.</param>
        ''' <param name="ResetType">A ResetType indicating when objects value should be reset.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal CoreClass As BaseClassControl, ByVal OccursTimes As Integer, _
                        ByVal ResetType As ResetTypes)
            MyBase.New()
            m_dblInitialValue = cDefaultValue
            CallInitialize(Name, 0, CoreClass, OccursTimes, ResetType, True)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDate.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="OccursWith">A FileObject which CoreDate occurs with.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal CoreClass As BaseClassControl, ByVal OccursWith As IFileObject)
            MyBase.New()
            m_dblInitialValue = cDefaultValue
            With OccursWith
                CallInitialize(Name, 0, CoreClass, .Occurs, ResetTypes.NotApplicable, True, OccursWith)
                AddHandler .GoToRecordEvent, AddressOf GoToRecord
            End With
        End Sub

#End Region

#Region " Constructors with Passed Decimal as Initial value "

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDate.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal CoreClass As BaseClassControl, ByVal InitialValue As Decimal)
            MyBase.New()
            m_dblInitialValue = InitialValue
            CallInitialize(Name, 0, CoreClass, 1, ResetTypes.Reset, True)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDate.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="ResetType">A ResetType indicating when objects value should be reset.</param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal CoreClass As BaseClassControl, ByVal ResetType As ResetTypes, _
                        ByVal InitialValue As Object)
            MyBase.New()
            m_dblInitialValue = CDec(InitialValue)
            CallInitialize(Name, 0, CoreClass, 1, ResetType, True)
        End Sub

        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal CoreClass As BaseClassControl, ByVal ResetType As ResetTypes, _
                        ByVal InitialValue As Decimal)
            MyBase.New()
            m_dblInitialValue = InitialValue
            CallInitialize(Name, 0, CoreClass, 1, ResetType, True)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDate.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="OccursTimes">An Integer representing the number of times this CoreDate occurs in Grid.</param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal CoreClass As BaseClassControl, ByVal OccursTimes As Integer, _
                        ByVal InitialValue As Decimal)
            MyBase.New()
            m_dblInitialValue = InitialValue
            CallInitialize(Name, 0, CoreClass, OccursTimes, ResetTypes.Reset, True)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDate.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="OccursTimes">An Integer representing the number of times this CoreDate occurs in Grid.</param>
        ''' <param name="ResetType">A ResetType indicating when objects value should be reset.</param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal CoreClass As BaseClassControl, ByVal OccursTimes As Integer, _
                        ByVal ResetType As ResetTypes, ByVal InitialValue As Object)
            MyBase.New()
            m_dblInitialValue = CDec(InitialValue)
            CallInitialize(Name, 0, CoreClass, OccursTimes, ResetType, True)
        End Sub

        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal CoreClass As BaseClassControl, ByVal OccursTimes As Integer, _
                        ByVal ResetType As ResetTypes, ByVal InitialValue As Decimal)
            MyBase.New()
            m_dblInitialValue = InitialValue
            CallInitialize(Name, 0, CoreClass, OccursTimes, ResetType, True)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDate.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="OccursWith">A FileObject which CoreDate occurs with.</param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal CoreClass As BaseClassControl, ByVal OccursWith As IFileObject, _
                        ByVal InitialValue As Object)
            MyBase.New()
            m_dblInitialValue = CDec(InitialValue)
            With OccursWith
                CallInitialize(Name, 0, CoreClass, .Occurs, ResetTypes.NotApplicable, True, OccursWith)
                AddHandler .GoToRecordEvent, AddressOf GoToRecord
            End With
        End Sub

        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal CoreClass As BaseClassControl, ByVal OccursWith As IFileObject, _
                        ByVal InitialValue As Decimal)
            MyBase.New()
            m_dblInitialValue = InitialValue
            With OccursWith
                CallInitialize(Name, 0, CoreClass, .Occurs, ResetTypes.NotApplicable, True, OccursWith)
                AddHandler .GoToRecordEvent, AddressOf GoToRecord
            End With
        End Sub

#End Region

#Region " Constructors with passed Date as Initial value "

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDate.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal CoreClass As BaseClassControl, ByVal InitialValue As Date)
            MyBase.New()
            m_dblInitialValue = _
                CDbl(InitialValue.Year.ToString + Format(InitialValue.Month, "00") + Format(InitialValue.Day, "00"))
            CallInitialize(Name, 0, CoreClass, 1, ResetTypes.Reset, True)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDate.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="ResetType">A ResetType indicating when objects value should be reset.</param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal CoreClass As BaseClassControl, ByVal ResetType As ResetTypes, _
                        ByVal InitialValue As Date)
            MyBase.New()
            m_dblInitialValue = _
                CDbl(InitialValue.Year.ToString + Format(InitialValue.Month, "00") + Format(InitialValue.Day, "00"))
            CallInitialize(Name, 0, CoreClass, 1, ResetType, True)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDate.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="ResetType">A ResetType indicating when objects value should be reset.</param>
        ''' <param name="Signed"></param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal CoreClass As BaseClassControl, ByVal ResetType As ResetTypes, _
                        ByVal Signed As Boolean, ByVal InitialValue As Date)
            MyBase.New()
            m_dblInitialValue = _
                CDbl(InitialValue.Year.ToString + Format(InitialValue.Month, "00") + Format(InitialValue.Day, "00"))
            CallInitialize(Name, 0, CoreClass, 1, ResetType, Signed)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDate.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="OccursTimes">An Integer representing the number of times this CoreDate occurs in Grid.</param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal CoreClass As BaseClassControl, ByVal OccursTimes As Integer, _
                        ByVal InitialValue As Date)
            MyBase.New()
            m_dblInitialValue = _
                CDbl(InitialValue.Year.ToString + Format(InitialValue.Month, "00") + Format(InitialValue.Day, "00"))
            CallInitialize(Name, 0, CoreClass, OccursTimes, ResetTypes.Reset, True)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDate.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="OccursTimes">An Integer representing the number of times this CoreDate occurs in Grid.</param>
        ''' <param name="ResetType">A ResetType indicating when objects value should be reset.</param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal CoreClass As BaseClassControl, ByVal OccursTimes As Integer, _
                        ByVal ResetType As ResetTypes, ByVal InitialValue As Date)
            MyBase.New()
            m_dblInitialValue = _
                CDbl(InitialValue.Year.ToString + Format(InitialValue.Month, "00") + Format(InitialValue.Day, "00"))
            CallInitialize(Name, 0, CoreClass, OccursTimes, ResetType, True)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDate.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="OccursTimes">An Integer representing the number of times this CoreDate occurs in Grid.</param>
        ''' <param name="ResetType">A ResetType indicating when objects value should be reset.</param>
        ''' <param name="Signed"></param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal CoreClass As BaseClassControl, ByVal OccursTimes As Integer, _
                        ByVal ResetType As ResetTypes, ByVal Signed As Boolean, ByVal InitialValue As Date)
            MyBase.New()
            m_dblInitialValue = _
                CDbl(InitialValue.Year.ToString + Format(InitialValue.Month, "00") + Format(InitialValue.Day, "00"))
            CallInitialize(Name, 0, CoreClass, OccursTimes, ResetType, Signed)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDate.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="OccursWith">A FileObject which CoreDate occurs with.</param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal CoreClass As BaseClassControl, ByVal OccursWith As IFileObject, _
                        ByVal InitialValue As Date)
            MyBase.New()
            m_dblInitialValue = _
                CDbl(InitialValue.Year.ToString + Format(InitialValue.Month, "00") + Format(InitialValue.Day, "00"))
            With OccursWith
                CallInitialize(Name, 0, CoreClass, .Occurs, ResetTypes.NotApplicable, True, OccursWith)
                AddHandler .GoToRecordEvent, AddressOf GoToRecord
            End With
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDate.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="OccursWith">A FileObject which CoreDate occurs with.</param>
        ''' <param name="Signed"></param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal CoreClass As BaseClassControl, ByVal OccursWith As IFileObject, _
                        ByVal Signed As Boolean, ByVal InitialValue As Date)
            MyBase.New()
            m_dblInitialValue = _
                CDbl(InitialValue.Year.ToString + Format(InitialValue.Month, "00") + Format(InitialValue.Day, "00"))
            With OccursWith
                CallInitialize(Name, 0, CoreClass, .Occurs, ResetTypes.NotApplicable, Signed, OccursWith)
                AddHandler .GoToRecordEvent, AddressOf GoToRecord
            End With
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDate.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Size">An Integer indicating the size of CoreDate.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="OccursWithCoreBaseType">A CoreBaseType which CoreDate occurs with.</param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)> _
        Public Sub New(ByVal Name As String, ByVal Size As Integer, ByVal CoreClass As BaseClassControl, _
                        ByVal OccursWithCoreBaseType As CoreBaseType, ByVal InitialValue As Date)
            MyBase.New()
            m_dblInitialValue = _
                CDbl(InitialValue.Year.ToString + Format(InitialValue.Month, "00") + Format(InitialValue.Day, "00"))
            With OccursWithCoreBaseType
                CallInitialize(Name, Size, CoreClass, .m_intOccursTimes, ResetTypes.NotApplicable, False, _
                                OccursWithCoreBaseType)
                AddHandler .GoToRecordEvent, AddressOf GoToRecord
            End With
        End Sub

#End Region

#End Region

#End Region

#Region "Properties"

        '--------------------------
        ' DateValue property.
        '--------------------------
        ''' --- DateValue ----------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Returns the value as a date.
        ''' </summary>
        ''' <remarks>
        ''' Dates are treated as numbers using the Renaissance Architect Framework, therefore it is recommended that you use the Value property.  
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Property DateValue() As Date
            Get
                Dim strValue As String

                ' Store the value as a string.
                strValue = m_dblValue(Occurrence).ToString
                Return _
                    New Date(CInt(strValue.Substring(0, 4)), CInt(strValue.Substring(4, 2)), _
                              CInt(strValue.Substring(6, 2)))
            End Get
            Set(ByVal Value As Date)

                ' If the date value is the Min date value ("0001/01/01"), 
                ' then change it to "1899/12/31".
                If Value = Date.MinValue Then
                    m_dblValue(Occurrence) = cDefaultValue
                Else
                    m_dblValue(Occurrence) = _
                        CDbl(Value.Year.ToString + Format(Value.Month, "00") + Format(Value.Day, "00"))
                End If

            End Set
        End Property

        ''' --- InitialValue -------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Gets or sets the Initial Value of the <B>CoreDecimal</B>.
        ''' </summary>
        ''' <value>
        '''     A Decimal representing the initial value of the <B>CoreDecimal</B>.
        ''' </value>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        '''     <code>
        '''         Dim myCount as CoreDecimal = New CoreDecimal("myCount", 4, Me)
        '''
        '''         myCount.InitialValue = 10 
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public Property InitialValue() As Decimal
            Get
                Return m_dblInitialValue
            End Get
            Set(ByVal Value As Decimal)
                m_dblInitialValue = Value
            End Set
        End Property

        '--------------------------
        ' TimeValue property.
        '--------------------------
        'Public ReadOnly Property TimeValue() As Decimal
        '    Get
        '        ' Return the date as a number.
        '        Dim x As Decimal = m_dteDate(m_intOccurrence).Millisecond()

        '        ' If the Millisecond value is 0, add 00.
        '        If m_dteDate.Millisecond = 0 Then
        '            Return CDbl(Format(m_dteDate.Hour, "00") & Format(m_dteDate.Minute, "00") & Format(m_dteDate.Second, "00") & "00")
        '        Else
        '            Return CDbl(Format(m_dteDate.Hour, "00") & Format(m_dteDate.Minute, "00") & Format(m_dteDate.Second, "00") & m_dteDate.Millisecond.ToString.Substring(0, 2))
        '        End If
        '    End Get
        'End Property

        ''' --- Value --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	The value of the current <B>CoreDecimal</B> instance.
        ''' </summary>
        ''' <value>
        '''     A Decimal representing the value of the <B>CoreDecimal</B>.
        ''' </value>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        '''     <code>
        '''         Dim myCount as CoreDecimal = New CoreDecimal("myCount", 4, Me)
        '''
        '''         If myCount.Value = 0 Then
        '''             .
        '''             .
        '''         End if
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Property Value() As Decimal
            Get
                If m_strEditField = m_strVariableName Then
                    Return GetFieldValue()
                Else
                    If m_dblValue(Occurrence) = cDefaultValue Then
                        Return 0
                    Else
                        Return m_dblValue(Occurrence)
                    End If
                End If
            End Get
            Set(ByVal Value As Decimal)
                ' If the value is 0, set the date to 1899/12/31.
                If Value = 1 / 0 Then Value = 0
                If Value = 0 Then
                    m_dblValue(Occurrence) = cDefaultValue
                Else
                    ' Use the 0-based Substring function to create the date using the DateSerial function.
                    m_dblValue(Occurrence) = Value
                End If
            End Set
        End Property

#End Region

#Region " Protected/Private Methods "

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
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Sub ResetInitialValues()
            ResetInitialValues(0)
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
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Sub ResetInitialValues(ByVal InitialValue As Decimal)
            m_dblInitialValue = InitialValue
            Initialize()
        End Sub

        ''' --- Initialize ---------------------------------------------------------
        ''' <exclude />
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
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Protected Overrides Sub Initialize()

            Dim i As Integer

            If _
                IsNothing(m_BaseClass) OrElse m_BaseClass.ScreenType <> ScreenTypes.QTP OrElse _
                ((m_BaseClass.ScreenType = ScreenTypes.QTP OrElse m_BaseClass.ScreenType = ScreenTypes.QUIZ) AndAlso _
                 Reset <> ResetTypes.ResetAtStartup) _
                OrElse _
                ((m_BaseClass.ScreenType = ScreenTypes.QTP OrElse m_BaseClass.ScreenType = ScreenTypes.QUIZ) AndAlso _
                 Reset = ResetTypes.ResetAtStartup AndAlso _
                 (Not m_BaseClass.QTPRequest OrElse Not m_BaseClass.IsStateAvailable)) Then

                If m_blnFromConstructor Then
                    Dim m_intTemp(m_intOccursTimes) As Decimal
                    m_dblValue = m_intTemp
                Else
                    'Allow user to override Initial Value through an Event Handler.
                    RaiseGetInitialValue()
                    'For details, see comments on RaiseGetInitialValue method in CoreBaseType
                End If

                If Not Me.HasReceivedValue Then
                    'If m_initReset AndAlso Not m_Page.InternalPageState (m_strVariableName + "_RV") Is Nothing Then
                    '    ' We are initializing RESET variables (not reset at startup or reset at mode).
                    '    ' If we have a Request value, use this to initialize the temporary.
                    '    m_dblInitialValue = m_Page.InternalPageState (m_strVariableName + "_RV")
                    'End If
                    For i = 0 To m_intOccursTimes
                        m_dblValue(i) = m_dblInitialValue
                        'Initializing with default or passed value
                    Next
                End If

                ' If we are in Quiz/Qtp, save the ResetAtStartup (Global) variables in state when declaring the global (uppermost)
                ' variable to ensure that if re-running the same screen, that we have any new parameters being passed in.
                If _
                    Reset = ResetTypes.ResetAtStartup AndAlso Not m_BaseClass Is Nothing AndAlso _
                    Not m_BaseClass.GlobalSession("IsQtpObj") Is Nothing AndAlso _
                    m_BaseClass.GetType.BaseType.Name = "BaseClassControl" Then
                    m_BaseClass.InternalPageState(m_strVariableName + "_") = Me.CopyArray(m_dblValue)
                End If

            ElseIf (m_BaseClass.ScreenType = ScreenTypes.QTP OrElse m_BaseClass.ScreenType = ScreenTypes.QUIZ) Then
                m_dblValue = Me.CopyArray(CType(m_BaseClass.InternalPageState(m_strVariableName + "_"), Decimal()))
            End If

        End Sub

        ''' --- ToString -----------------------------------------------------------
        ''' <exclude />
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
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public Overrides Function ToString() As String
            Return Value.ToString
        End Function

        ''' --- ToDefaultDateString ------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of ToDefaultDateString.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)> _
        Public Overridable Function ToDefaultDateString() As String
            Return DateValue.ToString
        End Function

        ''' --- Getter -------------------------------------------------------------
        ''' <exclude />
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
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Protected Overrides Function Getter(ByVal Sender As Object, ByVal GetterArgs As GetterArgs) As Boolean
            GetterArgs.FieldText = Value.ToString
            GetterArgs.FieldValue = Value
        End Function

        ''' --- Setter -------------------------------------------------------------
        ''' <exclude />
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
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Protected Overrides Function Setter(ByVal Sender As Object, ByVal SetterArgs As SetterArgs) As Boolean
            m_dblValue(Occurrence) = SetterArgs.FieldValue
            If SetterArgs.IsRequest Then
                'm_Page.InternalPageState (m_strVariableName + "_RV") = SetterArgs.FieldValue
            End If
        End Function

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
                    m_dblValue =
                        Me.CopyArray(CType(m_BaseClass.InternalPageState(m_strVariableName + e.InFieldId), Decimal()))
                Else
                    'If _
                    '    Not blnFromAppend OrElse (blnFromAppend AndAlso (Me.Occurs = 0 OrElse Me.Occurs = 1)) OrElse
                    '    Me.Reset = ResetTypes.ResetAtStartup Then
                    '    m_dblValue =
                    '        Me.CopyArray(CType(m_Page.InternalPageState(m_strVariableName + e.InFieldId), Decimal()))
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
                    m_BaseClass.InternalPageState(m_strVariableName + e.InFieldId) = Me.CopyArray(m_dblValue)
                Else
                    'If e.IncludeObjectState = ObjectState.OnlyResetAtStartUp AndAlso Reset = ResetTypes.ResetAtStartup _
                    '    Then
                    '    m_Page.InternalPageState(m_strVariableName + "_RAS") = Me.CopyArray(m_dblValue)
                    'ElseIf _
                    '    e.IncludeObjectState = ObjectState.MoveStartUpToBaseTypes AndAlso
                    '    Reset = ResetTypes.ResetAtStartup Then
                    '    m_Page.InternalPageState(m_strVariableName + e.InFieldId) =
                    '        Me.CopyArray(CType(m_Page.InternalPageState(m_strVariableName + "_RAS"), Decimal()))
                    'ElseIf Not e.IncludeObjectState = ObjectState.MoveStartUpToBaseTypes Then
                    '    m_Page.InternalPageState(m_strVariableName + e.InFieldId) = Me.CopyArray(m_dblValue)
                    '    m_Page.InternalPageState(m_strVariableName + "_RAS") = Me.CopyArray(m_dblValue)
                    'End If
                End If
            End If
        End Sub

#End Region
    End Class
End Namespace
