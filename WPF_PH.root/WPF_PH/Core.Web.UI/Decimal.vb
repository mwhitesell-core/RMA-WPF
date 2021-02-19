Imports System.ComponentModel
Imports Core.Framework.Core.Framework

Namespace Core.Windows
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: CoreDecimal
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' <summary>
    ''' 	This class defines the Renaissance Architect Framework CoreDecimal.
    ''' </summary>
    ''' <remarks>
    '''     The Renaissance Architect implementation of CoreDecimal handles
    '''     Temporary (variable) objects of type Numeric.
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
    Public Class CoreDecimal
        Inherits CoreBaseType

        Private m_dblValue() As Decimal
        Private Const cDefaultValue As Decimal = 0
        Private m_dblInitialValue As Decimal

        <EditorBrowsable (EditorBrowsableState.Advanced)> Protected m_previous As Decimal

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
        <EditorBrowsable (EditorBrowsableState.Advanced)> Protected m_reset As Boolean

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
        <EditorBrowsable (EditorBrowsableState.Never)> Protected m_IsSubtotal As Boolean = False

        Private m_first As Boolean = False
        <EditorBrowsable (EditorBrowsableState.Never)> Protected m_IsResetSubtotal As Boolean = False

#Region " Constructors "

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDecimal.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Size">An Integer indicating the size of CoreDecimal.</param>
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
        '''         Private EMPLOYEE_COUNT As CoreDecimal = New CoreDecimal("EMPLOYEE_COUNT", 8, Me)
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Size As Integer, ByVal CoreClass As BaseClassControl, _
                        ByVal InitialValue As Object)
            MyBase.New()
            m_dblInitialValue = CDec (InitialValue)
            CallInitialize (Name, Size, CoreClass, 1, ResetTypes.Reset, True)
        End Sub

        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Size As Integer, ByVal CoreClass As BaseClassControl, _
                        Optional ByVal InitialValue As Decimal = cDefaultValue)
            MyBase.New()
            m_dblInitialValue = InitialValue
            CallInitialize (Name, Size, CoreClass, 1, ResetTypes.Reset, True)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDecimal.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Size">An Integer indicating the size of CoreDecimal.</param>
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
        '''         Private BANK_KEY As CoreDecimal = New CoreDecimal("BANK_KEY", 4, Me, ResetTypes.ResetAtStartup, 0D)
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Size As Integer, ByVal CoreClass As BaseClassControl, _
                        ByVal ResetType As ResetTypes, Optional ByVal InitialValue As Decimal = cDefaultValue)
            MyBase.New()
            m_dblInitialValue = InitialValue
            CallInitialize (Name, Size, CoreClass, 1, ResetType, True)
        End Sub

        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Size As Integer, ByVal CoreClass As BaseClassControl, _
                        ByVal ResetType As ResetTypes, ByVal InitialValue As Object)
            MyBase.New()
            m_dblInitialValue = CDec (InitialValue)
            CallInitialize (Name, Size, CoreClass, 1, ResetType, True)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDecimal.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Size">An Integer indicating the size of CoreDecimal.</param>
        ''' <param name="CoreClass">An object of type BaseClassControl.</param>
        ''' <param name="OccursTimes">An Integer representing the number of times this CoreDecimal occurs in Grid.</param>
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
        '''         Private BANK_KEY As CoreDecimal = New CoreDecimal("BANK_KEY", 4, Me, 6)
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Size As Integer, ByVal CoreClass As BaseClassControl, _
                        ByVal OccursTimes As Integer, ByVal InitialValue As Decimal)
            MyBase.New()
            m_dblInitialValue = InitialValue
            CallInitialize (Name, Size, CoreClass, OccursTimes, ResetTypes.Reset, True)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDecimal.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Size">An Integer indicating the size of CoreDecimal.</param>
        ''' <param name="CoreClass">An object of type BaseClassControl.</param>
        ''' <param name="OccursTimes">An Integer representing the number of times this CoreDecimal occurs in Grid.</param>
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
        '''         Private BANK_KEY As CoreDecimal = New CoreDecimal("BANK_KEY", 4, Me, 8, ResetTypes.ResetAtStartup, 0D)
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Size As Integer, ByVal CoreClass As BaseClassControl, _
                        ByVal OccursTimes As Integer, ByVal ResetType As ResetTypes, _
                        Optional ByVal InitialValue As Decimal = cDefaultValue)
            MyBase.New()
            m_dblInitialValue = InitialValue
            CallInitialize (Name, Size, CoreClass, OccursTimes, ResetType, True)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDecimal.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Size">An Integer indicating the size of CoreDecimal.</param>
        ''' <param name="CoreClass">An object of type BaseClassControl.</param>
        ''' <param name="OccursWith">A FileObject which CoreDecimal occurs with.</param>
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
        '''         Private SALE_PRICE As CoreDecimal = New CoreDecimal("SALE_PRICE", 11, Me, fleORDER_FORM)
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Size As Integer, ByVal CoreClass As BaseClassControl, _
                        ByVal OccursWith As IFileObject, Optional ByVal InitialValue As Decimal = cDefaultValue)
            MyBase.New()
            m_dblInitialValue = InitialValue
            With OccursWith
                CallInitialize (Name, Size, CoreClass, .Occurs, ResetTypes.NotApplicable, True, OccursWith)
                AddHandler .GoToRecordEvent, AddressOf GoToRecord
            End With
        End Sub

        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Size As Integer, ByVal CoreClass As BaseClassControl, _
                        ByVal OccursWith As IFileObject, ByVal InitialValue As Object)
            MyBase.New()
            m_dblInitialValue = CDec (InitialValue)
            With OccursWith
                CallInitialize (Name, Size, CoreClass, .Occurs, ResetTypes.NotApplicable, True, OccursWith)
                AddHandler .GoToRecordEvent, AddressOf GoToRecord
            End With
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDecimal.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Size">An Integer indicating the size of CoreDecimal.</param>
        ''' <param name="CoreClass">An object of type BaseClassControl.</param>
        ''' <param name="OccursWithCoreBaseType">A CoreBaseType which CoreDecimal occurs with.</param>
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
        '''         Private SALE_PRICE As CoreDecimal = New CoreDecimal("SALE_PRICE", 11, Me, strOldInventory)
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Size As Integer, ByVal CoreClass As BaseClassControl, _
                        ByVal OccursWithCoreBaseType As CoreBaseType, _
                        Optional ByVal InitialValue As Decimal = cDefaultValue)
            MyBase.New()
            m_dblInitialValue = InitialValue
            With OccursWithCoreBaseType
                CallInitialize (Name, Size, CoreClass, .m_intOccursTimes, ResetTypes.NotApplicable, False, _
                                OccursWithCoreBaseType)
                AddHandler .GoToRecordEvent, AddressOf GoToRecord
            End With
        End Sub

        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Size As Integer, ByVal CoreClass As BaseClassControl, _
                        ByVal OccursWithCoreBaseType As CoreBaseType, ByVal InitialValue As Object)
            MyBase.New()
            m_dblInitialValue = CDec (InitialValue)
            With OccursWithCoreBaseType
                CallInitialize (Name, Size, CoreClass, .m_intOccursTimes, ResetTypes.NotApplicable, False, _
                                OccursWithCoreBaseType)
                AddHandler .GoToRecordEvent, AddressOf GoToRecord
            End With
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDecimal.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Size">An Integer indicating the size of CoreDecimal.</param>
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
        '''         Private EMPLOYEE_COUNT As CoreDecimal = New CoreDecimal("EMPLOYEE_COUNT", 8, Me)
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Size As Integer, ByVal Page As UI.Page, _
                        Optional ByVal InitialValue As Decimal = cDefaultValue)
            MyBase.New()
            m_dblInitialValue = InitialValue
            CallInitialize (Name, Size, Page, 1, ResetTypes.Reset, True)
        End Sub

        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Size As Integer, ByVal Page As UI.Page, ByVal InitialValue As Object)
            MyBase.New()
            m_dblInitialValue = CDec (InitialValue)
            CallInitialize (Name, Size, Page, 1, ResetTypes.Reset, True)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDecimal.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Size">An Integer indicating the size of CoreDecimal.</param>
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
        '''         Private BANK_KEY As CoreDecimal = New CoreDecimal("BANK_KEY", 4, Me, ResetTypes.ResetAtStartup, 0D)
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Size As Integer, ByVal Page As UI.Page, _
                        ByVal ResetType As ResetTypes, Optional ByVal InitialValue As Decimal = cDefaultValue)
            MyBase.New()
            m_dblInitialValue = InitialValue
            CallInitialize (Name, Size, Page, 1, ResetType, True)
        End Sub

        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Size As Integer, ByVal Page As UI.Page, _
                        ByVal ResetType As ResetTypes, ByVal InitialValue As Object)
            MyBase.New()
            m_dblInitialValue = CDec (InitialValue)
            CallInitialize (Name, Size, Page, 1, ResetType, True)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDecimal.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Size">An Integer indicating the size of CoreDecimal.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="OccursTimes">An Integer representing the number of times this CoreDecimal occurs in Grid.</param>
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
        '''         Private PACKAGE_COUNT As CoreDecimal = New CoreDecimal("PACKAGE_COUNT", 8, Me, 4)
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Size As Integer, ByVal Page As UI.Page, ByVal OccursTimes As Integer, _
                        ByVal InitialValue As Decimal)
            MyBase.New()
            m_dblInitialValue = InitialValue
            CallInitialize (Name, Size, Page, OccursTimes, ResetTypes.Reset, True)
        End Sub

        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Size As Integer, ByVal Page As UI.Page, ByVal OccursTimes As Integer, _
                        ByVal InitialValue As Object)
            MyBase.New()
            m_dblInitialValue = CDec (InitialValue)
            CallInitialize (Name, Size, Page, OccursTimes, ResetTypes.Reset, True)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDecimal.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Size">An Integer indicating the size of CoreDecimal.</param>
        ''' <param name="Page">The current page of type Core.Windows.UI.Page.  Use the keyword "Me" to set this value.</param>
        ''' <param name="OccursTimes">An Integer representing the number of times this CoreDecimal occurs in Grid.</param>
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
        '''         Private BANK_KEY As CoreDecimal = New CoreDecimal("BANK_KEY", 4, Me, 8, ResetTypes.ResetAtStartup, 0D)
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Size As Integer, ByVal Page As UI.Page, ByVal OccursTimes As Integer, _
                        ByVal ResetType As ResetTypes, Optional ByVal InitialValue As Decimal = cDefaultValue)
            MyBase.New()
            m_dblInitialValue = InitialValue
            CallInitialize (Name, Size, Page, OccursTimes, ResetType, True)
        End Sub

        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Size As Integer, ByVal Page As UI.Page, ByVal OccursTimes As Integer, _
                        ByVal ResetType As ResetTypes, ByVal InitialValue As Object)
            MyBase.New()
            m_dblInitialValue = CDec (InitialValue)
            CallInitialize (Name, Size, Page, OccursTimes, ResetType, True)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDecimal.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Size">An Integer indicating the size of CoreDecimal.</param>
        ''' <param name="Page">A Page of type Core.Windows.UI.Page.</param>
        ''' <param name="OccursWith">A FileObject which CoreDecimal occurs with.</param>
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
        '''         Private SALE_PRICE As CoreDecimal = New CoreDecimal("SALE_PRICE", 11, Me, fleORDER_FORM)
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Size As Integer, ByVal Page As UI.Page, _
                        ByVal OccursWith As IFileObject, Optional ByVal InitialValue As Decimal = cDefaultValue)
            MyBase.New()
            m_dblInitialValue = InitialValue
            With OccursWith
                CallInitialize (Name, Size, Page, .Occurs, ResetTypes.NotApplicable, True, OccursWith)
                AddHandler .GoToRecordEvent, AddressOf GoToRecord
            End With
        End Sub

        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Size As Integer, ByVal Page As UI.Page, _
                        ByVal OccursWith As IFileObject, ByVal InitialValue As Object)
            MyBase.New()
            m_dblInitialValue = CDec (InitialValue)
            With OccursWith
                CallInitialize (Name, Size, Page, .Occurs, ResetTypes.NotApplicable, True, OccursWith)
                AddHandler .GoToRecordEvent, AddressOf GoToRecord
            End With
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of CoreDecimal.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the object.</param>
        ''' <param name="Size">An Integer indicating the size of CoreDecimal.</param>
        ''' <param name="Page">A Page of type Core.Windows.UI.Page.</param>
        ''' <param name="OccursWithCoreBaseType">A CoreBaseType which CoreDecimal occurs with.</param>
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
        '''         Private SALE_PRICE As CoreDecimal = New CoreDecimal("SALE_PRICE", 11, Me, strOldInventory)
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Size As Integer, ByVal Page As UI.Page, _
                        ByVal OccursWithCoreBaseType As CoreBaseType, _
                        Optional ByVal InitialValue As Decimal = cDefaultValue)
            MyBase.New()
            m_dblInitialValue = InitialValue
            With OccursWithCoreBaseType
                CallInitialize (Name, Size, Page, .Occurs, ResetTypes.NotApplicable, False, OccursWithCoreBaseType)
                AddHandler .GoToRecordEvent, AddressOf GoToRecord
            End With
        End Sub

        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub New (ByVal Name As String, ByVal Size As Integer, ByVal Page As UI.Page, _
                        ByVal OccursWithCoreBaseType As CoreBaseType, ByVal InitialValue As Object)
            MyBase.New()
            m_dblInitialValue = CDec (InitialValue)
            With OccursWithCoreBaseType
                CallInitialize (Name, Size, Page, .Occurs, ResetTypes.NotApplicable, False, OccursWithCoreBaseType)
                AddHandler .GoToRecordEvent, AddressOf GoToRecord
            End With
        End Sub

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
            <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Event SumInto (ByVal Value As Decimal, ByVal OldValue As Decimal)

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
        <EditorBrowsable (EditorBrowsableState.Never)> _
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
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property ResetSubTotal (ByVal blnAt As Boolean) As CoreDecimal
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

        <EditorBrowsable (EditorBrowsableState.Advanced)> _
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
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property SubTotal() As CoreDecimal
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
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property IsSubTotal() As Boolean
            Get
                Return m_IsSubtotal
            End Get
        End Property

        Public ReadOnly Property FirstValue() As Decimal
            Get
                Return m_dblValue (0)
            End Get
        End Property

        Public ReadOnly Property LastValue() As Decimal
            Get
                Dim tmpOccurs As Integer = Me.Occurs - 1
                If tmpOccurs < 0 Then tmpOccurs = 0
                Return m_dblValue (tmpOccurs)
            End Get
        End Property

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
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Property Value() As Decimal
            Get
                If m_strEditField = m_strVariableName Then
                    Return GetFieldValue()
                Else
                    Return m_dblValue (Occurrence)
                End If
            End Get
            Set (ByVal Value As Decimal)
                'Missing functionality:
                '- No Size Error
                '- Signed/Unsigned not checked

                'Note: At present we are treating all numeric types as 
                'Decimal so we are not checking Size, as such we are not raising
                'any kind of Size Error

                'Sooner or later, we may need to check the size to match the legacy behaviour
                'in that case it is recommended to use different Core Types for different numeric types
                'e.g. for Integer use CoreInteger instead of CoreDecimal

                'If m_intSize < Value.ToString.Length Then
                '    'TODO: Replace with proper Error Code
                '    Throw New CustomApplicationException("Size Error")
                'End If

                ' Added for SumInto
                Dim dblOldValue As Decimal = m_dblValue (Occurrence)
                If Value = 1/0 Then Value = 0
                m_dblValue (Occurrence) = Value

                ' Call the SUM INTO event.
                RaiseEvent SumInto (Value, dblOldValue)
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
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Property InitialValue() As Decimal
            Get
                Return m_dblInitialValue
            End Get
            Set (ByVal Value As Decimal)
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
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Overrides Function ToString() As String
            Return m_dblValue (Occurrence).ToString
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
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Sub ResetInitialValues()
            ResetInitialValues (0)
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
        Public Sub ResetInitialValues (ByVal InitialValue As Decimal)
            m_dblInitialValue = InitialValue
            Initialize()
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
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected Overrides Sub Initialize()
            Dim i As Integer
            If _
                IsNothing (m_BaseClass) OrElse m_BaseClass.ScreenType <> ScreenTypes.QTP OrElse _
                ((m_BaseClass.ScreenType = ScreenTypes.QTP OrElse m_BaseClass.ScreenType = ScreenTypes.QUIZ) AndAlso _
                 Reset <> ResetTypes.ResetAtStartup) _
                OrElse _
                ((m_BaseClass.ScreenType = ScreenTypes.QTP OrElse m_BaseClass.ScreenType = ScreenTypes.QUIZ) AndAlso _
                 Reset = ResetTypes.ResetAtStartup AndAlso _
                 (Not m_BaseClass.QTPRequest OrElse Not m_BaseClass.IsStateAvailable)) Then
                If m_intSize = - 1 Then 'Default Size
                    'TODO: We may need to change this logic to support Legacy app behaviour
                    m_intSize = Decimal.MaxValue.ToString.Length
                End If

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
                        m_dblValue (i) = m_dblInitialValue
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

            ElseIf m_BaseClass.ScreenType = ScreenTypes.QTP OrElse m_BaseClass.ScreenType = ScreenTypes.QUIZ Then
                m_dblValue = Me.CopyArray(CType(m_BaseClass.InternalPageState(m_strVariableName + "_"), Decimal()))
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
            GetterArgs.FieldText = VAL (m_dblValue (Occurrence).ToString).ToString
            GetterArgs.FieldValue = m_dblValue (Occurrence)
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Overrides Function Setter(Sender As Object, SetterArgs As SetterArgs) As Boolean
            Value = SetterArgs.FieldValue
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
                    If _
                        Not blnFromAppend OrElse (blnFromAppend AndAlso (Me.Occurs = 0 OrElse Me.Occurs = 1)) OrElse
                        Me.Reset = ResetTypes.ResetAtStartup Then
                        'm_dblValue =
                        '    Me.CopyArray(CType(m_Page.InternalPageState(m_strVariableName + e.InFieldId), Decimal()))
                    Else
                        Me.Initialize()
                    End If
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
