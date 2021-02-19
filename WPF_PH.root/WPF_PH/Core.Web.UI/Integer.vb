Imports Core.Framework.Core.Framework
Imports Core.Framework.Core.Framework.QDesign
Imports System.ComponentModel
Imports Core.Windows

Namespace Core.Windows

    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: CoreInteger
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' <summary>
    ''' 	This class defines the Renaissance Architect Framework CoreInteger.
    ''' </summary>
    ''' <remarks>
    '''     The Renaissance Architect implementation of CoreInteger handles
    '''     Temporary (variable) objects of type Integer.
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/22/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
    Public Class CoreInteger
        Inherits CoreBaseType

        ''' --- m_intValue ---------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_intValue() As Decimal

        ''' --- cDefaultValue ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Private Const cDefaultValue As Decimal = 0

        ''' --- m_dblInitialValue --------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_dblInitialValue As Decimal

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
Protected m_previous As Decimal
        ''' --- m_previous ----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of m_previous.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected m_reset As Boolean
        ''' --- m_IsSubtotal ----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of m_previous.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Protected m_IsSubtotal As Boolean = False
        Private m_first As Boolean = True
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Protected m_IsResetSubtotal As Boolean = False

#Region " Constructors "

#Region " Menu and Ghost Screens "

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreInteger.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Size">An Integer indicating the size of the integer.</param>
        ''' <param name="CoreClass">An object of type BaseClassControl.</param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        '''     <para>
        '''         <note>
        '''             This constructor can be used only in a menu or ghost screen.
        '''         </note>
        '''     </para>
        ''' </remarks>
        ''' <example>
        '''     <code>
        '''         Private EMPLOYEE_COUNT As CoreInteger = New CoreInteger("EMPLOYEE_COUNT", 8, Me)
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal Size As Integer, ByVal CoreClass As BaseClassControl, Optional ByVal InitialValue As Decimal = cDefaultValue)
            MyBase.New()
            m_dblInitialValue = InitialValue
            CallInitialize(Name, Size, CoreClass, 1, ResetTypes.Reset, True)
        End Sub
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
       Public Sub New(ByVal Name As String, ByVal Size As Integer, ByVal CoreClass As BaseClassControl, ByVal InitialValue As Object)
            MyBase.New()
            m_dblInitialValue = CDec(InitialValue)
            CallInitialize(Name, Size, CoreClass, 1, ResetTypes.Reset, True)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreInteger.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Size">An Integer indicating the size of the integer.</param>
        ''' <param name="CoreClass">An object of type BaseClassControl.</param>
        ''' <param name="ResetType">A ResetType indicating when objects value should be reset.</param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        '''     <para>
        '''         <note>
        '''             This constructor can be used only in a menu or ghost screen.
        '''         </note>
        '''     </para>
        ''' </remarks>
        ''' <example>
        '''     <code>
        '''         Private BANK_KEY As CoreInteger = New CoreInteger("BANK_KEY", 4, Me, ResetTypes.ResetAtStartup, 0D)
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal Size As Integer, ByVal CoreClass As BaseClassControl, ByVal ResetType As ResetTypes, Optional ByVal InitialValue As Decimal = cDefaultValue)
            MyBase.New()
            m_dblInitialValue = InitialValue
            CallInitialize(Name, Size, CoreClass, 1, ResetType, True)
        End Sub
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
     Public Sub New(ByVal Name As String, ByVal Size As Integer, ByVal CoreClass As BaseClassControl, ByVal ResetType As ResetTypes, ByVal InitialValue As Object)
            MyBase.New()
            m_dblInitialValue = CDec(InitialValue)
            CallInitialize(Name, Size, CoreClass, 1, ResetType, True)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreInteger.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Size">An Integer indicating the size of the integer.</param>
        ''' <param name="CoreClass">An object of type BaseClassControl.</param>
        ''' <param name="ResetType">A ResetType indicating when objects value should be reset.</param>
        ''' <param name="Signed">A Boolean indicating if the value has a sign associated with it.</param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        '''     <para>
        '''         <note>
        '''             This constructor can be used only in a menu or ghost screen.
        '''         </note>
        '''     </para>
        ''' </remarks>
        ''' <example>
        '''     <code>
        '''         Private COMPANY_COUNT As CoreInteger = New CoreInteger("COMPANY_COUNT", 8, Me, False)
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal Size As Integer, ByVal CoreClass As BaseClassControl, ByVal ResetType As ResetTypes, ByVal Signed As Boolean, Optional ByVal InitialValue As Decimal = cDefaultValue)
            MyBase.New()
            m_dblInitialValue = InitialValue
            CallInitialize(Name, Size, CoreClass, 1, ResetType, Signed)
        End Sub
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal Size As Integer, ByVal CoreClass As BaseClassControl, ByVal ResetType As ResetTypes, ByVal Signed As Boolean, ByVal InitialValue As Object)
            MyBase.New()
            m_dblInitialValue = CDec(InitialValue)
            CallInitialize(Name, Size, CoreClass, 1, ResetType, Signed)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreInteger.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Size">An Integer indicating the size of the integer.</param>
        ''' <param name="CoreClass">An object of type BaseClassControl.</param>
        ''' <param name="OccursTimes">An Integer representing the number of times this CoreInteger occurs in Grid.</param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        '''     <para>
        '''         <note>
        '''             This constructor can be used only in a menu or ghost screen.
        '''         </note>
        '''     </para>
        ''' </remarks>
        ''' <example>
        '''     <code>
        '''         Private PACKAGE_COUNT As CoreInteger = New CoreInteger("PACKAGE_COUNT", 8, Me, 4)
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal Size As Integer, ByVal CoreClass As BaseClassControl, ByVal OccursTimes As Integer, ByVal InitialValue As Decimal)
            MyBase.New()
            m_dblInitialValue = InitialValue
            CallInitialize(Name, Size, CoreClass, OccursTimes, ResetTypes.Reset, True)
        End Sub
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
       Public Sub New(ByVal Name As String, ByVal Size As Integer, ByVal CoreClass As BaseClassControl, ByVal OccursTimes As Integer, ByVal InitialValue As Object)
            MyBase.New()
            m_dblInitialValue = CDec(InitialValue)
            CallInitialize(Name, Size, CoreClass, OccursTimes, ResetTypes.Reset, True)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreInteger.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Size">An Integer indicating the size of the integer.</param>
        ''' <param name="CoreClass">An object of type BaseClassControl.</param>
        ''' <param name="OccursTimes">An Integer representing the number of times this CoreInteger occurs in Grid.</param>
        ''' <param name="ResetType">A ResetType indicating when objects value should be reset.</param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        '''     <para>
        '''         <note>
        '''             This constructor can be used only in a menu or ghost screen.
        '''         </note>
        '''     </para>
        ''' </remarks>
        ''' <example>
        '''     <code>
        '''         Private BANK_KEY As CoreInteger = New CoreInteger("BANK_KEY", 4, Me, 8, ResetTypes.ResetAtStartup, 0D)
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal Size As Integer, ByVal CoreClass As BaseClassControl, ByVal OccursTimes As Integer, ByVal ResetType As ResetTypes, Optional ByVal InitialValue As Decimal = cDefaultValue)
            MyBase.New()
            m_dblInitialValue = InitialValue
            CallInitialize(Name, Size, CoreClass, OccursTimes, ResetType, True)
        End Sub

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
       Public Sub New(ByVal Name As String, ByVal Size As Integer, ByVal CoreClass As BaseClassControl, ByVal OccursTimes As Integer, ByVal ResetType As ResetTypes, ByVal InitialValue As Object)
            MyBase.New()
            m_dblInitialValue = CDec(InitialValue)
            CallInitialize(Name, Size, CoreClass, OccursTimes, ResetType, True)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreInteger.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Size">An Integer indicating the size of the integer.</param>
        ''' <param name="CoreClass">An object of type BaseClassControl.</param>
        ''' <param name="OccursTimes">An Integer representing the number of times this CoreInteger occurs in Grid.</param>
        ''' <param name="ResetType">A ResetType indicating when objects value should be reset.</param>
        ''' <param name="Signed">A Boolean indicating if the value has a sign associated with it.</param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        '''     <para>
        '''         <note>
        '''             This constructor can be used only in a menu or ghost screen.
        '''         </note>
        '''     </para>
        ''' </remarks>
        ''' <example>
        '''     <code>
        '''         Private AUTO_KEY As CoreInteger = New CoreInteger("AUTO_KEY", 4, Me, 8, ResetTypes.ResetAtStartup, False, 0D)
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal Size As Integer, ByVal CoreClass As BaseClassControl, ByVal OccursTimes As Integer, ByVal ResetType As ResetTypes, ByVal Signed As Boolean, Optional ByVal InitialValue As Decimal = cDefaultValue)
            MyBase.New()
            m_dblInitialValue = InitialValue
            CallInitialize(Name, Size, CoreClass, OccursTimes, ResetType, Signed)
        End Sub
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal Size As Integer, ByVal CoreClass As BaseClassControl, ByVal OccursTimes As Integer, ByVal ResetType As ResetTypes, ByVal Signed As Boolean, ByVal InitialValue As Object)
            MyBase.New()
            m_dblInitialValue = CDec(InitialValue)
            CallInitialize(Name, Size, CoreClass, OccursTimes, ResetType, Signed)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreInteger.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Size">An Integer indicating the size of the integer.</param>
        ''' <param name="CoreClass">An object of type BaseClassControl.</param>
        ''' <param name="OccursWith">A FileObject which CoreInteger occurs with.</param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        '''     <para>
        '''         <note>
        '''             This constructor can be used only in a menu or ghost screen.
        '''         </note>
        '''     </para>
        ''' </remarks>
        ''' <example>
        '''     <code>
        '''         Private SALE_PRICE As CoreInteger = New CoreInteger("SALE_PRICE", 11, Me, fleORDER_FORM)
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal Size As Integer, ByVal CoreClass As BaseClassControl, ByVal OccursWith As IFileObject, Optional ByVal InitialValue As Decimal = cDefaultValue)
            MyBase.New()
            m_dblInitialValue = InitialValue
            With OccursWith
                CallInitialize(Name, Size, CoreClass, .Occurs, ResetTypes.NotApplicable, True, OccursWith)
                AddHandler .GoToRecordEvent, AddressOf GoToRecord
            End With
        End Sub
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
       Public Sub New(ByVal Name As String, ByVal Size As Integer, ByVal CoreClass As BaseClassControl, ByVal OccursWith As IFileObject, ByVal InitialValue As Object)
            MyBase.New()
            m_dblInitialValue = CDec(InitialValue)
            With OccursWith
                CallInitialize(Name, Size, CoreClass, .Occurs, ResetTypes.NotApplicable, True, OccursWith)
                AddHandler .GoToRecordEvent, AddressOf GoToRecord
            End With
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreInteger.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Size">An Integer indicating the size of the integer.</param>
        ''' <param name="CoreClass">An object of type BaseClassControl.</param>
        ''' <param name="OccursWith">A FileObject which CoreInteger occurs with.</param>
        ''' <param name="Signed">A Boolean indicating if the value has a sign associated with it.</param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        '''     <para>
        '''         <note>
        '''             This constructor can be used only in a menu or ghost screen.
        '''         </note>
        '''     </para>
        ''' </remarks>
        ''' <example>
        '''     <code>
        '''         Private SALE_PRICE As CoreInteger = New CoreInteger("SALE_PRICE", 11, Me, fleORDER_FORM, False)
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal Size As Integer, ByVal CoreClass As BaseClassControl, ByVal OccursWith As IFileObject, ByVal Signed As Boolean, Optional ByVal InitialValue As Decimal = cDefaultValue)
            MyBase.New()
            m_dblInitialValue = InitialValue
            With OccursWith
                CallInitialize(Name, Size, CoreClass, .Occurs, ResetTypes.NotApplicable, Signed, OccursWith)
                AddHandler .GoToRecordEvent, AddressOf GoToRecord
            End With
        End Sub
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
       Public Sub New(ByVal Name As String, ByVal Size As Integer, ByVal CoreClass As BaseClassControl, ByVal OccursWith As IFileObject, ByVal Signed As Boolean, ByVal InitialValue As Object)
            MyBase.New()
            m_dblInitialValue = InitialValue
            With OccursWith
                CallInitialize(Name, Size, CoreClass, .Occurs, ResetTypes.NotApplicable, Signed, OccursWith)
                AddHandler .GoToRecordEvent, AddressOf GoToRecord
            End With
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreInteger.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Size">An Integer indicating the size of the integer.</param>
        ''' <param name="CoreClass">An object of type BaseClassControl.</param>
        ''' <param name="OccursWithCoreBaseType">A CoreBaseType which CoreInteger occurs with.</param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        '''     <para>
        '''         <note>
        '''             This constructor can be used only in a menu or ghost screen.
        '''         </note>
        '''     </para>
        ''' </remarks>
        ''' <example>
        '''     <code>
        '''         Private SALE_PRICE As CoreInteger = New CoreInteger("SALE_PRICE", 11, Me, strOldInventory)
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal Size As Integer, ByVal CoreClass As BaseClassControl, ByVal OccursWithCoreBaseType As CoreBaseType, Optional ByVal InitialValue As Decimal = cDefaultValue)
            MyBase.New()
            m_dblInitialValue = InitialValue
            With OccursWithCoreBaseType
                CallInitialize(Name, Size, CoreClass, .m_intOccursTimes, ResetTypes.NotApplicable, False, OccursWithCoreBaseType)
                AddHandler .GoToRecordEvent, AddressOf GoToRecord
            End With
        End Sub
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal Size As Integer, ByVal CoreClass As BaseClassControl, ByVal OccursWithCoreBaseType As CoreBaseType, ByVal InitialValue As Object)
            MyBase.New()
            m_dblInitialValue = CDec(InitialValue)
            With OccursWithCoreBaseType
                CallInitialize(Name, Size, CoreClass, .m_intOccursTimes, ResetTypes.NotApplicable, False, OccursWithCoreBaseType)
                AddHandler .GoToRecordEvent, AddressOf GoToRecord
            End With
        End Sub

#End Region

#Region " Screens and Sub Screens "

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreInteger.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Size">An Integer indicating the size of the integer.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        '''     <para>
        '''         <note>
        '''             This constructor can be used only in a screen or sub-screen.
        '''         </note>
        '''     </para>
        ''' </remarks>
        ''' <example>
        '''     <code>
        '''         Private EMPLOYEE_COUNT As CoreInteger = New CoreInteger("EMPLOYEE_COUNT", 8, Me)
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal Size As Integer, ByVal Page As Core.Windows.UI.Page, Optional ByVal InitialValue As Decimal = cDefaultValue)
            MyBase.New()
            m_dblInitialValue = InitialValue
            CallInitialize(Name, Size, Page, 1, ResetTypes.Reset, True)
        End Sub
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal Size As Integer, ByVal Page As Core.Windows.UI.Page, ByVal InitialValue As Object)
            MyBase.New()
            m_dblInitialValue = CDec(InitialValue)
            CallInitialize(Name, Size, Page, 1, ResetTypes.Reset, True)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreInteger.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Size">An Integer indicating the size of the integer.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="ResetType">A ResetType indicating when objects value should be reset.</param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        '''     <para>
        '''         <note>
        '''             This constructor can be used only in a screen or sub-screen.
        '''         </note>
        '''     </para>
        ''' </remarks>
        ''' <example>
        '''     <code>
        '''         Private BANK_KEY As CoreInteger = New CoreInteger("BANK_KEY", 4, Me, ResetTypes.ResetAtStartup, 0D)
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal Size As Integer, ByVal Page As Core.Windows.UI.Page, ByVal ResetType As ResetTypes, Optional ByVal InitialValue As Decimal = cDefaultValue)
            MyBase.New()
            m_dblInitialValue = InitialValue
            CallInitialize(Name, Size, Page, 1, ResetType, True)
        End Sub
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
       Public Sub New(ByVal Name As String, ByVal Size As Integer, ByVal Page As Core.Windows.UI.Page, ByVal ResetType As ResetTypes, ByVal InitialValue As Object)
            MyBase.New()
            m_dblInitialValue = CDec(InitialValue)
            CallInitialize(Name, Size, Page, 1, ResetType, True)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreInteger.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Size">An Integer indicating the size of the integer.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="ResetType">A ResetType indicating when objects value should be reset.</param>
        ''' <param name="Signed">A Boolean indicating if the value has a sign associated with it.</param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        '''     <para>
        '''         <note>
        '''             This constructor can be used only in a screen or sub-screen.
        '''         </note>
        '''     </para>
        ''' </remarks>
        ''' <example>
        '''     <code>
        '''         Private COMPANY_COUNT As CoreInteger = New CoreInteger("COMPANY_COUNT", 8, Me, False)
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal Size As Integer, ByVal Page As Core.Windows.UI.Page, ByVal ResetType As ResetTypes, ByVal Signed As Boolean, Optional ByVal InitialValue As Decimal = cDefaultValue)
            MyBase.New()
            m_dblInitialValue = InitialValue
            CallInitialize(Name, Size, Page, 1, ResetType, Signed)
        End Sub
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
       Public Sub New(ByVal Name As String, ByVal Size As Integer, ByVal Page As Core.Windows.UI.Page, ByVal ResetType As ResetTypes, ByVal Signed As Boolean, ByVal InitialValue As Object)
            MyBase.New()
            m_dblInitialValue = CDec(InitialValue)
            CallInitialize(Name, Size, Page, 1, ResetType, Signed)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreInteger.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Size">An Integer indicating the size of the integer.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="OccursTimes">An Integer representing the number of times this CoreInteger occurs in Grid.</param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        '''     <para>
        '''         <note>
        '''             This constructor can be used only in a screen or sub-screen.
        '''         </note>
        '''     </para>
        ''' </remarks>
        ''' <example>
        '''     <code>
        '''         Private PACKAGE_COUNT As CoreInteger = New CoreInteger("PACKAGE_COUNT", 8, Me, 4)
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal Size As Integer, ByVal Page As Core.Windows.UI.Page, ByVal OccursTimes As Integer, ByVal InitialValue As Decimal)
            MyBase.New()
            m_dblInitialValue = InitialValue
            CallInitialize(Name, Size, Page, OccursTimes, ResetTypes.Reset, True)
        End Sub
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
       Public Sub New(ByVal Name As String, ByVal Size As Integer, ByVal Page As Core.Windows.UI.Page, ByVal OccursTimes As Integer, ByVal InitialValue As Object)
            MyBase.New()
            m_dblInitialValue = CDec(InitialValue)
            CallInitialize(Name, Size, Page, OccursTimes, ResetTypes.Reset, True)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreInteger.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Size">An Integer indicating the size of the integer.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="OccursTimes">An Integer representing the number of times this CoreInteger occurs in Grid.</param>
        ''' <param name="ResetType">A ResetType indicating when objects value should be reset.</param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        '''     <para>
        '''         <note>
        '''             This constructor can be used only in a screen or sub-screen.
        '''         </note>
        '''     </para>
        ''' </remarks>
        ''' <example>
        '''     <code>
        '''         Private BANK_KEY As CoreInteger = New CoreInteger("BANK_KEY", 4, Me, 8, ResetTypes.ResetAtStartup, 0D)
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal Size As Integer, ByVal Page As Core.Windows.UI.Page, ByVal OccursTimes As Integer, ByVal ResetType As ResetTypes, Optional ByVal InitialValue As Decimal = cDefaultValue)
            MyBase.New()
            m_dblInitialValue = InitialValue
            CallInitialize(Name, Size, Page, OccursTimes, ResetType, True)
        End Sub
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
       Public Sub New(ByVal Name As String, ByVal Size As Integer, ByVal Page As Core.Windows.UI.Page, ByVal OccursTimes As Integer, ByVal ResetType As ResetTypes, ByVal InitialValue As Object)
            MyBase.New()
            m_dblInitialValue = CDec(InitialValue)
            CallInitialize(Name, Size, Page, OccursTimes, ResetType, True)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreInteger.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Size">An Integer indicating the size of the integer.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="OccursTimes">An Integer representing the number of times this CoreInteger occurs in Grid.</param>
        ''' <param name="ResetType">A ResetType indicating when objects value should be reset.</param>
        ''' <param name="Signed">A Boolean indicating if the value has a sign associated with it.</param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        '''     <para>
        '''         <note>
        '''             This constructor can be used only in a screen or sub-screen.
        '''         </note>
        '''     </para>
        ''' </remarks>
        ''' <example>
        '''     <code>
        '''         Private AUTO_KEY As CoreInteger = New CoreInteger("AUTO_KEY", 4, Me, 8, ResetTypes.ResetAtStartup, False, 0D)
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal Size As Integer, ByVal Page As Core.Windows.UI.Page, ByVal OccursTimes As Integer, ByVal ResetType As ResetTypes, ByVal Signed As Boolean, Optional ByVal InitialValue As Decimal = cDefaultValue)
            MyBase.New()
            m_dblInitialValue = InitialValue
            CallInitialize(Name, Size, Page, OccursTimes, ResetType, Signed)
        End Sub
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
       Public Sub New(ByVal Name As String, ByVal Size As Integer, ByVal Page As Core.Windows.UI.Page, ByVal OccursTimes As Integer, ByVal ResetType As ResetTypes, ByVal Signed As Boolean, ByVal InitialValue As Object)
            MyBase.New()
            m_dblInitialValue = CDec(InitialValue)
            CallInitialize(Name, Size, Page, OccursTimes, ResetType, Signed)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreInteger.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Size">An Integer indicating the size of the integer.</param>
        ''' <param name="Page">A Page of type Core.Windows.UI.Page.</param>
        ''' <param name="OccursWith">A FileObject which CoreInteger occurs with.</param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        '''     <para>
        '''         <note>
        '''             This constructor can be used only in a screen or sub-screen.
        '''         </note>
        '''     </para>
        ''' </remarks>
        ''' <example>
        '''     <code>
        '''         Private SALE_PRICE As CoreInteger = New CoreInteger("SALE_PRICE", 11, Me, fleORDER_FORM)
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal Size As Integer, ByVal Page As Core.Windows.UI.Page, ByVal OccursWith As IFileObject, Optional ByVal InitialValue As Decimal = cDefaultValue)
            MyBase.New()
            m_dblInitialValue = InitialValue
            With OccursWith
                CallInitialize(Name, Size, Page, .Occurs, ResetTypes.NotApplicable, True, OccursWith)
                AddHandler .GoToRecordEvent, AddressOf GoToRecord
            End With
        End Sub
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
       Public Sub New(ByVal Name As String, ByVal Size As Integer, ByVal Page As Core.Windows.UI.Page, ByVal OccursWith As IFileObject, ByVal InitialValue As Object)
            MyBase.New()
            m_dblInitialValue = CDec(InitialValue)
            With OccursWith
                CallInitialize(Name, Size, Page, .Occurs, ResetTypes.NotApplicable, True, OccursWith)
                AddHandler .GoToRecordEvent, AddressOf GoToRecord
            End With
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreInteger.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Size">An Integer indicating the size of the integer.</param>
        ''' <param name="Page">A Page of type Core.Windows.UI.Page.</param>
        ''' <param name="OccursWith">A FileObject which CoreInteger occurs with.</param>
        ''' <param name="Signed">A Boolean indicating if the value has a sign associated with it.</param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        '''     <para>
        '''         <note>
        '''             This constructor can be used only in a screen or sub-screen.
        '''         </note>
        '''     </para>
        ''' </remarks>
        ''' <example>
        '''     <code>
        '''         Private SALE_PRICE As CoreInteger = New CoreInteger("SALE_PRICE", 11, Me, fleORDER_FORM, False)
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal Size As Integer, ByVal Page As Core.Windows.UI.Page, ByVal OccursWith As IFileObject, ByVal Signed As Boolean, Optional ByVal InitialValue As Decimal = cDefaultValue)
            MyBase.New()
            m_dblInitialValue = InitialValue
            With OccursWith
                CallInitialize(Name, Size, Page, .Occurs, ResetTypes.NotApplicable, Signed, OccursWith)
                AddHandler .GoToRecordEvent, AddressOf GoToRecord
            End With
        End Sub
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
       Public Sub New(ByVal Name As String, ByVal Size As Integer, ByVal Page As Core.Windows.UI.Page, ByVal OccursWith As IFileObject, ByVal Signed As Boolean, ByVal InitialValue As Object)
            MyBase.New()
            m_dblInitialValue = CDec(InitialValue)
            With OccursWith
                CallInitialize(Name, Size, Page, .Occurs, ResetTypes.NotApplicable, Signed, OccursWith)
                AddHandler .GoToRecordEvent, AddressOf GoToRecord
            End With
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreInteger.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Size">An Integer indicating the size of the integer.</param>
        ''' <param name="Page">A Page of type Core.Windows.UI.Page.</param>
        ''' <param name="OccursWithCoreBaseType">A CoreBaseType which CoreInteger occurs with.</param>
        ''' <param name="InitialValue"><i>Optional</i>A Decimal representing the initial value of object.</param>
        ''' <remarks>
        '''     <para>
        '''         <note>
        '''             This constructor can be used only in a screen or sub-screen.
        '''         </note>
        '''     </para>
        ''' </remarks>
        ''' <example>
        '''     <code>
        '''         Private SALE_PRICE As CoreInteger = New CoreInteger("SALE_PRICE", 11, Me, strOldInventory)
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal Size As Integer, ByVal Page As Core.Windows.UI.Page, ByVal OccursWithCoreBaseType As CoreBaseType, Optional ByVal InitialValue As Decimal = cDefaultValue)
            MyBase.New()
            m_dblInitialValue = InitialValue
            With OccursWithCoreBaseType
                CallInitialize(Name, Size, Page, .Occurs, ResetTypes.NotApplicable, False, OccursWithCoreBaseType)
                AddHandler .GoToRecordEvent, AddressOf GoToRecord
            End With
        End Sub
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
       Public Sub New(ByVal Name As String, ByVal Size As Integer, ByVal Page As Core.Windows.UI.Page, ByVal OccursWithCoreBaseType As CoreBaseType, ByVal InitialValue As Object)
            MyBase.New()
            m_dblInitialValue = CDec(InitialValue)
            With OccursWithCoreBaseType
                CallInitialize(Name, Size, Page, .Occurs, ResetTypes.NotApplicable, False, OccursWithCoreBaseType)
                AddHandler .GoToRecordEvent, AddressOf GoToRecord
            End With
        End Sub

#End Region

#End Region

#Region "Events"

        ''' --- SumInto ------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Adds all values entered into the item.
        ''' </summary>
        ''' <param name="Value">Value of item field.</param>
        ''' <param name="OldValue">Running Total of the value of item field.</param>
        ''' <remarks>Will maintain the total in the item. This sum is automatically
        ''' <para>
        '''     <list type="bullet">
        '''         <item>incremented when values are entered</item>
        '''         <item>reduced when a data record containing the item is deleted</item>
        '''         <item>adjusted when the value is changed</item>
        '''     </list>
        ''' </para>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Event SumInto(ByVal Value As Decimal, ByVal OldValue As Decimal)

#End Region

#Region " Public Property "

        ''' --- SubTotalValue --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Returns the SubTotalValue of the evaluated expression.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <returns>A Decimal value.
        ''' </returns>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public ReadOnly Property SubTotalValue() As Decimal
            Get
                Dim dblValue As Decimal = 0

                If Not m_IsResetSubtotal AndAlso Not m_IsSubtotal Then
                    dblValue = Value
                End If
                dblValue = m_previous + dblValue
                If m_reset Then
                    m_previous = ResetValue
                    m_reset = False
                End If
                Return dblValue
            End Get
        End Property

        ''' --- SubTotalValue --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Returns the SubTotalValue of the evaluated expression.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <returns>A Decimal value.
        ''' </returns>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public ReadOnly Property ResetSubTotal(ByVal blnAt As Boolean) As CoreInteger
            Get
                Dim dblValue As Decimal = 0

                If m_reset Then
                    m_previous = ResetValue
                    m_reset = False
                End If

                If blnAt Then
                    m_reset = True
                End If
                dblValue = Value
                m_previous = m_previous + dblValue

                m_IsResetSubtotal = True
                m_IsSubtotal = True

                Return Me
            End Get
        End Property

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
       Public ReadOnly Property ResetValue() As Decimal
            Get
                If m_reset Then
                    Return 0
                End If

                Return m_previous
            End Get
        End Property

        ''' --- SubTotalValue --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Returns the SubTotalValue of the evaluated expression.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <returns>A Decimal value.
        ''' </returns>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public ReadOnly Property SubTotal() As CoreInteger
            Get
                Dim dblValue As Decimal = 0

                If m_first Then
                    m_previous = 0
                    m_first = False
                End If


                dblValue = Value
                m_previous = m_previous + dblValue


                m_IsSubtotal = True

                Return Me
            End Get
        End Property

        ''' --- SubTotalValue --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Returns the SubTotalValue of the evaluated expression.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <returns>A Decimal value.
        ''' </returns>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public ReadOnly Property IsSubTotal() As Boolean
            Get
                Return m_IsSubtotal
            End Get
        End Property

        Public ReadOnly Property FirstValue() As Decimal
            Get
                Return m_intValue(0)
            End Get
        End Property

        Public ReadOnly Property LastValue() As Decimal
            Get
                Dim tmpOccurs As Integer = Me.Occurs - 1
                If tmpOccurs < 0 Then tmpOccurs = 0
                Return m_intValue(tmpOccurs)
            End Get
        End Property
        ''' --- Value --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	The value of the current <B>CoreInteger</B> instance.
        ''' </summary>
        ''' <value>
        '''     A Decimal representing the value of the <B>CoreInteger</B>.
        ''' </value>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        '''     <code>
        '''         Dim myCount as CoreInteger = New CoreInteger("myCount", 4, Me)
        '''
        '''         If myCount.Value = 0 Then
        '''             .
        '''             .
        '''         End if
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Property Value() As Decimal
            Get
                If m_strEditField = m_strVariableName Then
                    Return GetFieldValue()
                Else
                    Return (m_intValue(Occurrence))
                End If
            End Get
            Set(ByVal Value As Decimal)
                'Missing functionality:
                '- No Size Error
                '- Signed/Unsigned not "PRECISELY" checked, at present if it is unsigned
                '  we are just prohibiting Negative values, however
                '  ideally we should combined it with "Size" also

                'Note: At present we are not checking Size, as such we are not raising
                'any kind of Size Error

                ' Added for SumInto
                Dim dblOldValue As Decimal = CDbl(m_intValue(Occurrence))
                If Value = 1 / 0 Then Value = 0
                m_intValue(Occurrence) = GetValidatedValue(Value)

                ' Call the SUM INTO event.
                RaiseEvent SumInto(Value, dblOldValue)
            End Set
        End Property

        ''' --- InitialValue -------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Gets or sets the Initial Value of the <B>CoreInteger</B>.
        ''' </summary>
        ''' <value>
        '''     A Decimal representing the initial value of the <B>CoreInteger</B>.
        ''' </value>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        '''     <code>
        '''         Dim myCount as CoreInteger = New CoreInteger("myCount", 4, Me)
        '''
        '''         myCount.InitialValue = 10 
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Property InitialValue() As Decimal
            Get
                Return m_dblInitialValue
            End Get
            Set(ByVal Value As Decimal)
                m_dblInitialValue = Value
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
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Overrides Function ToString() As String
            Return m_intValue(Occurrence).ToString
        End Function

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
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
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
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Sub ResetInitialValues(ByVal InitialValue As String)
            m_dblInitialValue = InitialValue
            Initialize()
        End Sub

        ''' --- GetValidatedValue --------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetValidatedValue.
        ''' </summary>
        ''' <param name="Value"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Private Function GetValidatedValue(ByVal Value As Decimal) As Decimal

            If m_blnSigned Then
                'Using Round with 0 precision and by specifying Down option, we are truncating decimal portion of the passed value
                Return Round(Value, 0, RoundOptionTypes.Down)
            Else
                'If defined as unsigned integer, raising an error for negative numbers
                If Value < 0 Then Throw New ExceptionManagement.CustomApplicationException("Error")

                'Using Round with 0 precision and by specifying Down option, we are truncating decimal portion of the passed value
                Return Round(Value, 0, RoundOptionTypes.Down)
            End If
        End Function

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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Overrides Sub Initialize()
            Dim i As Integer
            If IsNothing(m_BaseClass) OrElse m_BaseClass.ScreenType <> ScreenTypes.QTP OrElse ((m_BaseClass.ScreenType = ScreenTypes.QTP OrElse m_BaseClass.ScreenType = ScreenTypes.QUIZ) AndAlso Reset <> ResetTypes.ResetAtStartup) _
             OrElse ((m_BaseClass.ScreenType = ScreenTypes.QTP OrElse m_BaseClass.ScreenType = ScreenTypes.QUIZ) AndAlso Reset = ResetTypes.ResetAtStartup AndAlso (Not m_BaseClass.QTPRequest OrElse Not m_BaseClass.IsStateAvailable)) Then
                If m_intSize = -1 Then  'Default Size
                    'TODO: We may need to change this logic to support Legacy app behaviour
                    m_intSize = Integer.MaxValue.ToString.Length
                End If

                If m_blnFromConstructor Then
                    Dim m_intTemp(m_intOccursTimes) As Decimal
                    m_intValue = m_intTemp
                Else
                    'Allow user to override Initial Value through an Event Handler.
                    RaiseGetInitialValue() 'For details, see comments on RaiseGetInitialValue method in CoreBaseType
                End If

                If Not Me.HasReceivedValue Then
                    'If m_initReset AndAlso Not m_Page.InternalPageState(m_strVariableName + "_RV") Is Nothing Then
                    '    ' We are initializing RESET variables (not reset at startup or reset at mode).
                    '    ' If we have a Request value, use this to initialize the temporary.
                    '    m_dblInitialValue = m_Page.InternalPageState(m_strVariableName + "_RV")
                    'Else
                    '    m_dblInitialValue = GetValidatedValue(m_dblInitialValue)
                    'End If

                    For i = 0 To m_intOccursTimes
                        m_intValue(i) = m_dblInitialValue  'Initializing with the default or passed value
                    Next
                End If

                'If we are in Quiz/Qtp, save the ResetAtStartup (Global) variables in state when declaring the global (uppermost)
                ' variable to ensure that if re-running the same screen, that we have any new parameters being passed in.
                If Reset = ResetTypes.ResetAtStartup AndAlso Not m_BaseClass Is Nothing AndAlso Not m_BaseClass.GlobalSession("IsQtpObj") Is Nothing AndAlso m_BaseClass.GetType.BaseType.Name = "BaseClassControl" Then
                        m_BaseClass.InternalPageState(m_strVariableName + "_") = Me.CopyArray(m_intValue)
                    End If

                ElseIf (m_BaseClass.ScreenType = ScreenTypes.QTP OrElse m_BaseClass.ScreenType = ScreenTypes.QUIZ) Then
                    m_intValue = Me.CopyArray(CType(m_BaseClass.InternalPageState(m_strVariableName + "_"), Decimal()))
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
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Overrides Function Getter(ByVal Sender As Object, ByVal GetterArgs As GetterArgs) As Boolean
            GetterArgs.FieldText = m_intValue(Occurrence).ToString
            GetterArgs.FieldValue = m_intValue(Occurrence)
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Overrides Function Setter(ByVal Sender As Object, ByVal SetterArgs As SetterArgs) As Boolean
            'Assigning the FieldValue to the Value property to observe the Size
            Me.Value = SetterArgs.FieldValue
            If SetterArgs.IsRequest Then
                'm_Page.InternalPageState(m_strVariableName + "_RV") = SetterArgs.FieldValue
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
        '''     [Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Overrides Sub LoadPageState(Sender As Object, e As PageStateEventArgs, blnFromAppend As Boolean)
            If UseInitialValue() Then
                'Calling Initialize to get and reset the current value with the Initial value
                Me.Initialize() 'For details, see comments on RaiseGetInitialValue method in CoreBaseType
            Else
                If m_Page Is Nothing Then
                    m_intValue = Me.CopyArray(CType(m_BaseClass.InternalPageState(m_strVariableName + e.InFieldId),
                                                    Decimal()))
                Else
                    'If _
                    '    Not blnFromAppend OrElse (blnFromAppend AndAlso (Me.Occurs = 0 OrElse Me.Occurs = 1)) OrElse
                    '    Me.Reset = ResetTypes.ResetAtStartup Then
                    '    m_intValue = Me.CopyArray(CType(m_Page.InternalPageState(m_strVariableName + e.InFieldId),
                    '                                    Decimal()))
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
        '''     [Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Overrides Sub SavePageState(Sender As Object, e As PageStateEventArgs)
            If _
                (e.IncludeObjectState = ObjectState.OnlyResetAtStartUp AndAlso Reset = ResetTypes.ResetAtStartup) OrElse
                e.IncludeObjectState <> ObjectState.OnlyResetAtStartUp Then
                If m_Page Is Nothing Then
                    m_BaseClass.InternalPageState(m_strVariableName + e.InFieldId) = Me.CopyArray(m_intValue)
                Else
                    'If e.IncludeObjectState = ObjectState.OnlyResetAtStartUp AndAlso Reset = ResetTypes.ResetAtStartup _
                    '    Then
                    '    m_Page.InternalPageState(m_strVariableName + "_RAS") = Me.CopyArray(m_intValue)
                    'ElseIf _
                    '    e.IncludeObjectState = ObjectState.MoveStartUpToBaseTypes AndAlso
                    '    Reset = ResetTypes.ResetAtStartup Then
                    '    m_Page.InternalPageState(m_strVariableName + e.InFieldId) =
                    '        Me.CopyArray(CType(m_Page.InternalPageState(m_strVariableName + "_RAS"), Decimal()))
                    'ElseIf Not e.IncludeObjectState = ObjectState.MoveStartUpToBaseTypes Then
                    '    m_Page.InternalPageState(m_strVariableName + e.InFieldId) = Me.CopyArray(m_intValue)
                    '    m_Page.InternalPageState(m_strVariableName + "_RAS") = Me.CopyArray(m_intValue)
                    'End If
                End If
            End If
        End Sub
      

#End Region

    End Class

End Namespace
