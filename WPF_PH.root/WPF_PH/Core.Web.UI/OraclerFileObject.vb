
Option Explicit On

Imports Core.Framework
Imports Core.Framework.Core.Framework
Imports Core.Framework.Core.Framework.QDesign
Imports Core.ExceptionManagement
Imports System.Exception
Imports System.Runtime.Serialization
Imports System.Text
Imports System.Web
Imports System.Xml
Imports System.IO
Imports System.Diagnostics
Imports System.ComponentModel
Imports Core.Windows.UI

Namespace Core.Windows

    ''' -----------------------------------------------------------------------
    ''' Project	 : Core.Windows.UI
    ''' Class	 : Core.Windows.OracleFileObject
    ''' 
    ''' -----------------------------------------------------------------------
    '''
    ''' <summary>
    '''     Identifies and describes an Oracle record-structure accessed by the screen.
    ''' </summary>
    ''' <remarks>
    '''     This class contains the properties, methods, events and members
    '''     that provide the functionality to identify and describe an Oracle record-structure 
    '''     (FileObject) accessed by the screen.
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	4/12/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <Serializable(), ComponentModel.ToolboxItem(False), ComponentModel.DesignTimeVisible(True), _
    EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
    Public Class OracleFileObject
        Inherits OracleFileObjectBase

        'TODO: Any Web Specific Methods should be moved from BaseFileObject
        Private m_Page As Core.Windows.UI.Page
        Private m_BaseClass As Core.Windows.BaseClassControl

#Region "Constructor and Destructor"

        ''' --- New ----------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Initializes a new instance of an OracleFileObject class.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/12/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Private Sub New()
            MyBase.New()
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' <summary>
        '''     Initializes a new instance of an OracleFileObject class.
        ''' </summary>
        ''' <param name="CoreClass"><i>Required</i> A reference to the current menu/ghost screen class set using the keyword 'Me'.</param>
        ''' <param name="Type"><i>Required</i> A type of file as defined in FileTypes.</param>
        ''' <param name="Occurs"><i>Required</i> An integer representing the number of occurrences of a 
        '''     record-structure to display.</param>
        ''' <param name="Owner"><i>Required</i> A string specifying the owner of the table.</param>
        ''' <param name="BaseName"><i>Required</i> Base relation name (underlying table if aliased)</param>
        ''' <param name="AliasName"><i>Required</i> Alias name of table.</param>
        ''' <param name="NoItems"><i>Optional</i> No Items (no default initialization occurs)</param>
        ''' <param name="NoAppend"><i>Optional</i> No Append method is generated for this file (PRIMARY only)</param>
        ''' <param name="NoDelete"><i>Optional</i> No DeletedRecord is generated in the Delete or DetailDelete methods for this file</param>
        ''' <param name="Need"><i>Optional</i> This option can be used to add blank data records or data records 
        '''     with initial and final values only. (PutData method treats record as changed)</param>
        ''' <param name="TransactionName"><i>Optional</i> A string representing a Transaction Name.  This is used by the
        ''' Renaissance Architect PreCompiler to generate the necessary transaction code for this File class.
        ''' </param>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        ''' Private WithEvents fleEMP_LKP As New OracleFileObject(Me, FileTypes.Reference, 0, "HRMAIN", "EMPLOYEE", "EMP_LKP", False, False, False, 0, "m_trnTRANS_UPDATE")
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/12/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Sub New( _
            ByVal CoreClass As Core.Windows.BaseClassControl, _
            ByVal Type As FileTypes, _
            ByVal Occurs As Integer, _
            ByVal Owner As String, _
            ByVal BaseName As String, _
            ByVal AliasName As String, _
            Optional ByVal NoItems As Boolean = False, _
            Optional ByVal NoAppend As Boolean = False, _
            Optional ByVal NoDelete As Boolean = False, _
            Optional ByVal Need As Integer = 0, _
            Optional ByVal TransactionName As String = "", _
            Optional ByVal FileType As FileType = FileType.DataFile)

            MyBase.New(Type, Occurs, Owner, BaseName, AliasName, NoItems, NoAppend, NoDelete, Need, TransactionName, FileType)

            If FileType = FileType.TempFile Then IsTempTable = True
           If FileType = FileType.SubFile OrElse FileType = FileType.PortableSubFile  Then IsSubFile = True

            m_BaseClass = CoreClass
            SubscribeStateEvents()

            'Set PrimaryFile property on a page
            If Type = FileTypes.Primary Then
                With m_BaseClass
                    .PrimaryFile = ReturnRelation()
                    .m_bfoPrimaryFile = Me
                End With
            End If
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' <summary>
        '''     Initializes a new instance of an OracleFileObject class.
        ''' </summary>
        ''' <param name="CoreClass"><i>Required</i> A reference to the current menu/ghost screen class set using the keyword 'Me'.</param>
        ''' <param name="Type"><i>Required</i> A type of file as defined in FileTypes.</param>
        ''' <param name="OccursWith"><i>Required</i> An reference to an OracleFileObject class with which this File class occurs.</param>
        ''' <param name="Owner"><i>Required</i> A string specifying the owner of the table.</param>
        ''' <param name="BaseName"><i>Required</i> Base relation name (underlying table if aliased)</param>
        ''' <param name="AliasName"><i>Required</i> Alias name of table.</param>
        ''' <param name="NoItems"><i>Optional</i> No Items (no default initialization occurs)</param>
        ''' <param name="NoAppend"><i>Optional</i> No Append method is generated for this file (PRIMARY only)</param>
        ''' <param name="NoDelete"><i>Optional</i> No DeletedRecord is generated in the Delete or DetailDelete methods for this file</param>
        ''' <param name="Need"><i>Optional</i> This option can be used to add blank data records or data records 
        '''     with initial and final values only. (PutData method treats record as changed)</param>
        ''' <param name="TransactionName"><i>Optional</i> A string representing a Transaction Name.  This is used by the
        ''' Renaissance Architect PreCompiler to generate the necessary transaction code for this File class.
        ''' </param>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        ''' Private WithEvents fleEMP_LKP As New OracleFileObject(Me, FileTypes.Reference, fleEMPLOYEE, "HRMAIN", "EMPLOYEE", "EMP_LKP", False, False, False, 0, "m_trnTRANS_UPDATE")
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/12/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Sub New( _
            ByVal CoreClass As Core.Windows.BaseClassControl, _
            ByVal Type As FileTypes, _
            ByVal OccursWith As OracleFileObject, _
            ByVal Owner As String, _
            ByVal BaseName As String, _
            ByVal AliasName As String, _
            Optional ByVal NoItems As Boolean = False, _
            Optional ByVal NoAppend As Boolean = False, _
            Optional ByVal NoDelete As Boolean = False, _
            Optional ByVal Need As Integer = 0, _
            Optional ByVal TransactionName As String = "", _
            Optional ByVal FileType As FileType = FileType.DataFile)

            MyBase.New(Type, OccursWith.Occurs, Owner, BaseName, AliasName, NoItems, NoAppend, NoDelete, Need, TransactionName, FileType)
            m_blnOccursWith = True
            m_OccursWith = OccursWith
            m_intProviderTypeOrdinal = 6 'Coordinal for Oracle Provider Type is 6
            m_intClobValue = 4

            If FileType = FileType.TempFile Then IsTempTable = True
          If FileType = FileType.SubFile OrElse FileType = FileType.PortableSubFile  Then IsSubFile = True

            OccursWith.WireNavigationEvents(Me)
            m_BaseClass = CoreClass
            SubscribeStateEvents()

            'Set PrimaryFile property on a page
            If Type = FileTypes.Primary Then
                With m_BaseClass
                    .PrimaryFile = ReturnRelation()
                    .m_bfoPrimaryFile = Me
                End With
            End If

            Select Case Type
                Case FileTypes.Secondary
                    If OccursWith.Type = FileTypes.Primary Then
                        'Navigation, Append, Edit and Delete 
                        OccursWith.WireNavigationEvents(Me, True, (Not NoAppend), True, (Not NoDelete))
                    Else
                        'Error????
                    End If
                Case FileTypes.Detail  'Can occur with Primary and Master
                    With OccursWith
                        If .Type = FileTypes.Primary OrElse .Type = FileTypes.Master Then
                            'Navigation, Append, Edit and Delete 
                            .WireNavigationEvents(Me, True, (Not NoAppend), True, (Not NoDelete))
                        Else
                            'Error????
                        End If
                    End With
                Case FileTypes.Delete
                    'TODO:  Need to work on Delete 
                Case FileTypes.Primary 'Can occur with Master
                    'TODO:  Need to work on Delete 
            End Select
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' <summary>
        '''     Initializes a new instance of an OracleFileObject class.
        ''' </summary>
        ''' <param name="CorePage"><i>Required</i> A reference to the current screen class set using the keyword 'Me'.</param>
        ''' <param name="Type"><i>Required</i> A type of file as defined in FileTypes.</param>
        ''' <param name="Occurs"><i>Required</i> An integer representing the number of occurrences of a 
        '''     record-structure to display.</param>
        ''' <param name="Owner"><i>Required</i> A string specifying the owner of the table.</param>
        ''' <param name="BaseName"><i>Required</i> Base relation name (underlying table if aliased)</param>
        ''' <param name="AliasName"><i>Required</i> Alias name of table.</param>
        ''' <param name="NoItems"><i>Optional</i> No Items (no default initialization occurs)</param>
        ''' <param name="NoAppend"><i>Optional</i> No Append method is generated for this file (PRIMARY only)</param>
        ''' <param name="NoDelete"><i>Optional</i> No DeletedRecord is generated in the Delete or DetailDelete methods for this file</param>
        ''' <param name="Need"><i>Optional</i> This option can be used to add blank data records or data records 
        '''     with initial and final values only. (PutData method treats record as changed)</param>
        ''' <param name="TransactionName"><i>Optional</i> A string representing a Transaction Name.  This is used by the
        ''' Renaissance Architect PreCompiler to generate the necessary transaction code for this File class.
        ''' </param>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        ''' Private WithEvents fleEMP_LKP As New OracleFileObject(Me, FileTypes.Reference, 5, "HRMAIN", "EMPLOYEE", "EMP_LKP", False, False, False, 0, "m_trnTRANS_UPDATE")
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/12/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Sub New( _
            ByVal CorePage As Core.Windows.UI.Page, _
            ByVal Type As FileTypes, _
            ByVal Occurs As Integer, _
            ByVal Owner As String, _
            ByVal BaseName As String, _
            ByVal AliasName As String, _
            Optional ByVal NoItems As Boolean = False, _
            Optional ByVal NoAppend As Boolean = False, _
            Optional ByVal NoDelete As Boolean = False, _
            Optional ByVal Need As Integer = 0, _
            Optional ByVal TransactionName As String = "", _
            Optional ByVal FileType As FileType = FileType.DataFile)

            MyBase.New(Type, Occurs, Owner, BaseName, AliasName, NoItems, NoAppend, NoDelete, Need, TransactionName, FileType)
            m_Page = CorePage
            SubscribeStateEvents()

            'Set PrimaryFile property on a page
            If Type = FileTypes.Primary Then
                With m_Page
                    .PrimaryFile = ReturnRelation()
                    .m_bfoPrimaryFile = Me
                End With
            End If

        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' <summary>
        '''     Initializes a new instance of an OracleFileObject class.
        ''' </summary>
        ''' <param name="CorePage"><i>Required</i> A reference to the current screen class set using the keyword 'Me'.</param>
        ''' <param name="Type"><i>Required</i> A type of file as defined in FileTypes.</param>
        ''' <param name="OccursWith"><i>Required</i> An reference to an OracleFileObject class with which this File class occurs.</param>
        ''' <param name="Owner"><i>Required</i> A string specifying the owner of the table.</param>
        ''' <param name="BaseName"><i>Required</i> Base relation name (underlying table if aliased)</param>
        ''' <param name="AliasName"><i>Required</i> Alias name of table.</param>
        ''' <param name="NoItems"><i>Optional</i> No Items (no default initialization occurs)</param>
        ''' <param name="NoAppend"><i>Optional</i> No Append method is generated for this file (PRIMARY only)</param>
        ''' <param name="NoDelete"><i>Optional</i> No DeletedRecord is generated in the Delete or DetailDelete methods for this file</param>
        ''' <param name="Need"><i>Optional</i> This option can be used to add blank data records or data records 
        '''     with initial and final values only. (PutData method treats record as changed)</param>
        ''' <param name="TransactionName"><i>Optional</i> A string representing a Transaction Name.  This is used by the
        ''' Renaissance Architect PreCompiler to generate the necessary transaction code for this File class.
        ''' </param>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        ''' Private WithEvents fleEMP_LKP As New OracleFileObject(Me, FileTypes.Reference, fleEMPLOYEE, "HRMAIN", "EMPLOYEE", "EMP_LKP", False, False, False, 0, "m_trnTRANS_UPDATE")
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/12/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Sub New( _
            ByVal CorePage As Core.Windows.UI.Page, _
            ByVal Type As FileTypes, _
            ByVal OccursWith As OracleFileObject, _
            ByVal Owner As String, _
            ByVal BaseName As String, _
            ByVal AliasName As String, _
            Optional ByVal NoItems As Boolean = False, _
            Optional ByVal NoAppend As Boolean = False, _
            Optional ByVal NoDelete As Boolean = False, _
            Optional ByVal Need As Integer = 0, _
            Optional ByVal TransactionName As String = "")

            MyBase.New(Type, OccursWith.Occurs, Owner, BaseName, AliasName, NoItems, NoAppend, NoDelete, Need, TransactionName)
            m_blnOccursWith = True
            m_OccursWith = OccursWith

            OccursWith.WireNavigationEvents(Me)
            m_Page = CorePage
            SubscribeStateEvents()

            'Set PrimaryFile property on a page
            If Type = FileTypes.Primary Then
                With m_Page
                    .PrimaryFile = ReturnRelation()
                    .m_bfoPrimaryFile = Me
                End With
            End If

            Select Case Type
                Case FileTypes.Secondary
                    If OccursWith.Type = FileTypes.Primary Then
                        'Navigation, Append, Edit and Delete 
                        OccursWith.WireNavigationEvents(Me, True, (Not NoAppend), True, (Not NoDelete))
                    Else
                        'Error????
                    End If
                Case FileTypes.Detail  'Can occur with Primary and Master
                    With OccursWith
                        If .Type = FileTypes.Primary OrElse .Type = FileTypes.Master Then
                            'Navigation, Append, Edit and Delete 
                            .WireNavigationEvents(Me, True, (Not NoAppend), True, (Not NoDelete))
                        Else
                            'Error????
                        End If
                    End With
                Case FileTypes.Delete
                    'TODO:  Need to work on Delete 
                Case FileTypes.Primary 'Can occur with Master
                    'TODO:  Need to work on Delete 
            End Select
        End Sub
#End Region

        ''' --- AddMessage ---------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of AddMessage.
        ''' </summary>
        ''' <param name="Message"></param>
        ''' <param name="Type"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Overrides Sub AddMessage(ByVal Message As String, ByVal Type As MessageTypes, ByVal ParamArray Parameters() As Object)
            If m_Page Is Nothing Then
                For i As Integer = 0 To Parameters.Length - 1
                    If Not Parameters(i) Is Nothing Then Message &= ":" & Parameters(i).ToString
                Next
                m_BaseClass.AddMessage(Message, Type)
            Else
                m_Page.AddMessage(Message, Type, Parameters)
            End If
        End Sub

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Overridable Sub SetOverRideOccurrence(ByVal value As Integer, ByVal FileName As String)
            Dim strRelation As String = Me.BaseName
            If Me.AliasName.Trim.Length > 0 Then strRelation = Me.AliasName
            If FileName = strRelation Then
                OverRideOccurrence = value
            End If
        End Sub


        ''' --- SaveTempFile ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of SaveTempFile.
        ''' </summary>
        ''' <param name="Sender"></param>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Overridable Sub SaveTempFile(ByVal Sender As Object, ByVal e As PageStateEventArgs)
            If Not Me.IsSubFile AndAlso Not IsNothing(m_dtbQTPTempDataTable) Then
                'Core.Windows.UI.SessionInformation.SetSession(Me.BaseName, m_dtbQTPTempDataTable, m_BaseClass.QTPSessionID)
            End If

            'm_BaseClass.Session("WhereColumn" & Me.BaseName) = Nothing
        End Sub

        ''' --- CheckAlteredFlag ---------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of CheckAlteredFlag.
        ''' </summary>
        ''' <param name="Altered"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Private Sub CheckAlteredFlag(ByRef Altered As Boolean)
            ' If the Page's IsDirty is not set to true (based on previous file's
            ' CheckAlteredFlag event, then check the status of the current file.
            If Not Me.Type = FileTypes.Master Then
                Altered = FileIsAltered()
            End If

        End Sub

        ''' --- SubscribeStateEvents -----------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of SubscribeStateEvents.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Private Sub SubscribeStateEvents()
            If m_Page Is Nothing Then
                
            Else
               
                AddHandler m_Page.CheckFileStatuses, AddressOf CheckAlteredFlag
            End If
            If IsQTP Then
                AddHandler m_BaseClass.SaveTempFile, AddressOf SaveTempFile
            End If
        End Sub

        ''' --- UnsubscribeEvents --------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of UnsubscribeEvents.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Overrides Sub UnsubscribeEvents()
            If m_Page Is Nothing Then
                
            Else
                
                RemoveHandler m_Page.CheckFileStatuses, AddressOf CheckAlteredFlag
            End If
        End Sub

        ''' --- CheckLookupOnSameFile ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of CheckLookupOnSameFile.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Overrides Sub CheckLookupOnSameFile()
            'Note: This is internal method and should ONLY be
            'called from Break method of BaseFileObject
            If Not m_Page Is Nothing Then
                m_Page.CheckLookupOnSameFile(Me.TableNameWithOwner(True))
            End If
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
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Overrides Sub SetLookupNotOnFileName(ByVal Name As String)
            'Note: This is internal method and should ONLY be
            'called from Break method of BaseFileObject
            If Not m_Page Is Nothing Then
                m_Page.SetLookupNotOnFileName(Name)
            End If
        End Sub

        ''' --- SetOccurrence ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of SetOccurrence.
        ''' </summary>
        ''' <param name="NewValue"></param>
        ''' <param name="Reset"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Overrides Sub SetOccurrence(ByVal NewValue As Integer, Optional ByVal Reset As Boolean = False)
            'Note: This is internal method and should ONLY be
            'called from Break method of BaseFileObject
            If m_Page Is Nothing Then
                m_BaseClass.SetOccurrence(NewValue, Reset)
            Else
                m_Page.SetOccurrence(NewValue, Reset)
            End If
        End Sub

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Overrides Function QTPLoop() As Boolean

            Try

                If m_blnInDefine Then Return True

                intSortOrder = intSortOrder + 1

                If intSortFileOrder = -1 Then
                    intSortFileOrder = m_BaseClass.m_SortFileOrder + 1
                    m_BaseClass.m_SortFileOrder = m_BaseClass.m_SortFileOrder + 1
                End If

                If m_BaseClass.m_SortOrder = "" Then
                    m_BaseClass.m_SortOrder = intSortOrder.ToString.PadLeft(10, " ")
                Else
                    Dim tmpSortOrder As String = m_BaseClass.m_SortOrder
                    m_BaseClass.m_SortOrder = ""

                    For i As Integer = 0 To intSortFileOrder - 2
                        m_BaseClass.m_SortOrder = m_BaseClass.m_SortOrder & "," & tmpSortOrder.Split(",")(i)
                    Next

                    m_BaseClass.m_SortOrder = m_BaseClass.m_SortOrder & "," & intSortOrder.ToString.PadLeft(10, " ")
                    m_BaseClass.m_SortOrder = m_BaseClass.m_SortOrder.Substring(1)

                End If

            Catch ex As Exception

            End Try

        End Function


        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Overrides Function QTPForMissing() As Boolean
            Return QTPForMissing("")
        End Function


        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Overrides Function QTPForMissing(ByVal strForId As String) As Boolean

            m_blnCreateBlankRow = False

            m_intQTPLevel = VAL(strForId)

            'If Me.AliasName = "" Then
            '    m_BaseClass.Session("CurrentFile") = Me.BaseName
            'Else
            '    m_BaseClass.Session("CurrentFile") = Me.AliasName
            'End If


            blnOverRideOccurrence = True
            m_blnForMissing = True
            Dim blnReturn As Boolean = False
            Dim blnRemove As Boolean = True
            Dim Rowcount As Integer = 0

            If m_blnOutPutOutGet Then
                m_blnOutPutOutGet = False
                Do While m_dtbDataTable.Rows.Count > 0
                    m_dtbDataTable.Rows.RemoveAt(m_dtbDataTable.Rows.Count - 1)
                Loop
                OverRideOccurrence = -1
            End If

            If strForId.Length > 0 Then
                m_blnFirstFile = False
               m_BaseClass.Session("CreateWhere") = True
            Else
                NoRecords = False
                m_blnFirstFile = True
                m_BaseClass.m_SortOrder = ""
            End If

            If NoRecords Then
                If IsNothing(m_dtbDataTable) Then
                    Return False
                Else
                    If m_dtbDataTable.Rows.Count - 1 > OverRideOccurrence AndAlso m_intQTPLevel < VAL(m_BaseClass.m_strNoRecordsLevel) Then
                        m_dtbDataTable.Rows.RemoveAt(OverRideOccurrence)
                        m_blnContinue = True
                        NoRecords = False
                        SortOccurrence = OverRideOccurrence - 1
                        intSortOrder = OverRideOccurrence - 1
                    Else
                        If Not IsNothing(m_dtbDataTable) AndAlso m_intQTPLevel <= VAL(m_BaseClass.m_strNoRecordsLevel) Then
                            Rowcount = m_dtbDataTable.Rows.Count
                            If OverRideOccurrence < m_dtbDataTable.Rows.Count AndAlso Rowcount > 0 Then
                                Do While intLastfound > -1 AndAlso Rowcount > 0

                                    If Not IsNothing(m_BaseClass.dtSortOrder) AndAlso m_BaseClass.dtSortOrder.Rows.Count > 0 Then

                                        If m_BaseClass.arrSortOrder.Contains(intSortFileOrder.ToString & "_" & (Rowcount - 1).ToString) Then
                                            blnRemove = False
                                        End If

                                    End If

                                    If blnRemove Then
                                        m_dtbDataTable.Rows.RemoveAt(Rowcount - 1)
                                        If OverRideOccurrence > -1 Then OverRideOccurrence = OverRideOccurrence - 1
                                        SortOccurrence = -1
                                        intSortOrder = intSortOrder - 1
                                    Else
                                        NoRecords = False
                                    End If
                                    Rowcount = Rowcount - 1
                                    intLastfound = intLastfound - 1
                                Loop
                            Else
                                If OverRideOccurrence > -1 Then OverRideOccurrence = OverRideOccurrence - 1
                                SortOccurrence = OverRideOccurrence - DifferenceOccurrence
                            End If

                        End If

                        OverRideOccurrenceCount = -1
                        SortOccurrence = -1

                        Return False
                    End If
                End If


            End If

            If IsNothing(m_dtbDataTable) OrElse m_dtbDataTable.Rows.Count = 0 Then
                Me.Occurs = 1
            Else
                Me.Occurs = m_dtbDataTable.Rows.Count
                OverRideOccurrenceCount = m_dtbDataTable.Rows.Count
            End If

            If IsNothing(m_dtbDataTable) OrElse m_dtbDataTable.Rows.Count = 0 Then
                If OverRideOccurrence >= 0 Then
                    OverRideOccurrenceCount = -1
                    OverRideOccurrence = -1
                    SortOccurrence = -1
                    blnReturn = False
                Else
                    OverRideOccurrence = OverRideOccurrence + 1
                    SortOccurrence = SortOccurrence + 1
                    blnReturn = True
                End If

            Else
                If SortOccurrence < OverRideOccurrenceCount - 1 Then
                    If Not m_blnContinue Then
                        OverRideOccurrence = OverRideOccurrence + 1
                    End If
                    SortOccurrence = SortOccurrence + 1
                    blnReturn = True
                Else
                    OverRideOccurrenceCount = -1
                    SortOccurrence = -1

                    blnReturn = False
                End If

            End If


            If blnReturn Then
                If OverRideOccurrence < OverRideOccurrenceCount Then
                    m_blnCreateBlankRow = False
                End If

                DifferenceOccurrence = OverRideOccurrence - SortOccurrence
                SortOccurrence = OverRideOccurrence
            Else
                m_blnCreateBlankRow = True
                If m_blnOutPut And m_blnOutGet Then
                    OverRideOccurrence = m_dtbDataTable.Rows.Count - 1
                    m_blnOutPutOutGet = True
                ElseIf m_blnOutPut Then
                    OverRideOccurrence = OverRideOccurrence - 1
                End If
            End If

            If strForId.Length = 0 Then
                FirstOverrideCount = OverRideOccurrence
            End If


            Return blnReturn

        End Function

        ''' --- GetOccurrence ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetOccurrence.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Overrides Function GetOccurrence() As Integer
            'Note: This is internal method and should ONLY be
            'called from Break method of BaseFileObject
            If m_Page Is Nothing Then
                Return m_BaseClass.Occurrence - 1
            Else
                Return m_Page.m_intOccurrence
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Overrides Sub SetSearchType(ByVal SearchType As SearchTypes)
            If Not m_Page Is Nothing Then
                m_Page.SetSearchType(Me.ReturnRelation, Me.Type, Me.Occurs, SearchType)
            End If
        End Sub

        ''' --- IsInAppendOrEntry --------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of IsInAppendOrEntry.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Overrides Function IsInAppendOrEntry() As Boolean
            If m_Page Is Nothing Then
                Return m_BaseClass.IsInAppendOrEntry
            Else
                Return m_Page.IsInAppendOrEntry
            End If
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
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Overrides Function IsInFindOrDetailFind() As Boolean
            If m_Page Is Nothing Then
                Return m_BaseClass.InFindOrDetailFind
            Else
                Return m_Page.m_blnInFindOrDetailFind
            End If
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
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Overrides Function IsInFind() As Boolean
            If m_Page Is Nothing Then
                Return m_BaseClass.InFind
            Else
                Return m_Page.m_blnInFind
            End If
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
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Overrides Function PageMode() As PageModeTypes
            If m_Page Is Nothing Then
                Return m_BaseClass.Mode
            Else
                Return m_Page.Mode
            End If
        End Function

        ''' --- SetAlteredFlag -----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of SetAlteredFlag.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Overrides Function SetAlteredFlag() As Boolean
            ' The AlteredRecord flag is not set to True if the value was changed when 
            ' FindMode is true except when in the PostFind or DetailPostFind.  If in 
            ' NoMode (in our case we are in NoMode when searching for a record using FIND 
            ' and no records are found, or by pressing the cancel button), the AlteredRecord flag
            ' should not be set to True, unless we are running the INITIALIZE procedure.  In
            ' all other modes, the AlteredRecord status should change to True when the value changes.

            If m_Page Is Nothing Then
                Return m_BaseClass.SetAlteredFlag
            Else
                Return m_Page.SetAlteredFlag
            End If
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
        ''' <param name="AccessClause"></param>
        ''' <param name="OrderByClause"></param>
        ''' <param name="WholeWhereCondition"></param>
        ''' <param name="SkippedRecords"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Overrides Sub GetOverrideSQL(ByVal OverrideSQL As System.Text.StringBuilder, ByVal WhereClause As String, ByVal SelectIf As String, ByVal AccessClause As String, ByVal OrderByClause As String, ByRef WholeWhereCondition As String, ByRef SkippedRecords As Integer, Optional ByRef blnoverridesql As Boolean = False)
            'Called from the GetData metod of the BaseFileObject

            'If OverridSQL already contains SQL Statement, return the same statement
            If OverrideSQL.Length > 0 Then Return

            If m_Page Is Nothing Then
                m_BaseClass.SetCurrentRecordPosition(Me, WhereClause, SelectIf, AccessClause, OrderByClause, WholeWhereCondition, SkippedRecords)
            Else
                m_Page.SetCurrentRecordPosition(Me, WhereClause, SelectIf, AccessClause, OrderByClause, WholeWhereCondition, SkippedRecords)
            End If

            Me.GetSubSelectStatement(OverrideSQL, WholeWhereCondition, OrderByClause, Me.m_intCurrentRecordPosition, SkippedRecords)
        End Sub

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
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Overrides Function GetDictionary(ByVal FieldID As String) As CoreDictionaryItem

            If m_Page Is Nothing Then
                Return m_BaseClass.GetDictionaryItem(FieldID)
            Else
                Return m_Page.GetDictionaryItem(FieldID)
            End If

        End Function



        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Sub OutPut(ByVal OutPutType As OutPutType, ByVal blnAT As Boolean, ByVal blnContinue As Boolean)
            m_blnOutPut = True
            Select Case OutPutType
                Case OutPutType.Update
                    If Not Me.Exists Then
                        Exit Sub
                    End If
                Case OutPutType.Add
                    NewRecord = True
                    m_blnAlteredRecord(Me.CurrentRow) = True
                Case OutPutType.Delete
                    DeletedRecord = True
                Case OutPutType.Add_Update
            End Select

            m_blnOutGet = True

            If blnContinue AndAlso blnAT Then
                PutData()
            End If



        End Sub


        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Sub OutPut(ByVal OutPutType As OutPutType, ByVal blnAT As Boolean)
            m_blnOutPut = True
            Select Case OutPutType
                Case OutPutType.Update
                    If Not Me.Exists Then
                        Exit Sub
                    End If
                Case OutPutType.Add
                    NewRecord = True
                    m_blnAlteredRecord(Me.CurrentRow) = True
                Case OutPutType.Delete
                    DeletedRecord = True
                Case OutPutType.Add_Update
            End Select

            m_blnOutGet = True

            If blnAT Then
                PutData()
            End If

        End Sub

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Sub OutPut(ByVal objFile As OracleFileObject, ByVal OutPutType As OutPutType, ByVal blnAT As Boolean, ByVal blnContinue As Boolean)
            m_blnOutPut = True

            If IsNothing(Me.m_dtbDataTable) Then
                CheckStatusAndInitializeRecord()
            End If

            For i As Integer = 0 To objFile.m_dtbDataTable.Columns.Count - 1
                If Not IsNothing(Me.m_dtbDataTable.Columns(objFile.m_dtbDataTable.Columns(i).ColumnName)) AndAlso objFile.m_dtbDataTable.Columns(i).ColumnName <> "ROW_ID" AndAlso objFile.m_dtbDataTable.Columns(i).ColumnName <> "CHECKSUM_VALUE" Then
                    Me.m_dtbDataTable.Rows(Me.CurrentRow)(objFile.m_dtbDataTable.Columns(i).ColumnName) = objFile.m_dtbDataTable.Rows(objFile.CurrentRow)(i)
                End If
            Next

            Select Case OutPutType
                Case OutPutType.Update
                    If Not Me.Exists Then
                        Exit Sub
                    End If
                Case OutPutType.Add
                    NewRecord = True
                    m_blnAlteredRecord(Me.CurrentRow) = True
                Case OutPutType.Delete
                    DeletedRecord = True
                Case OutPutType.Add_Update
            End Select

            m_blnOutGet = True

            If blnContinue AndAlso blnAT Then
                PutData()
            End If


        End Sub

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Sub OutPut(ByVal objFile As OracleFileObject, ByVal OutPutType As OutPutType, ByVal blnAT As Boolean)
            m_blnOutPut = True

            If IsNothing(Me.m_dtbDataTable) Then
                CheckStatusAndInitializeRecord()
            End If

            For i As Integer = 0 To objFile.m_dtbDataTable.Columns.Count - 1
                If Not IsNothing(Me.m_dtbDataTable.Columns(objFile.m_dtbDataTable.Columns(i).ColumnName)) AndAlso objFile.m_dtbDataTable.Columns(i).ColumnName <> "ROW_ID" AndAlso objFile.m_dtbDataTable.Columns(i).ColumnName <> "CHECKSUM_VALUE" Then
                    Me.m_dtbDataTable.Rows(Me.CurrentRow)(objFile.m_dtbDataTable.Columns(i).ColumnName) = objFile.m_dtbDataTable.Rows(objFile.CurrentRow)(i)
                End If
            Next

            Select Case OutPutType
                Case OutPutType.Update
                    If Not Me.Exists Then
                        Exit Sub
                    End If
                Case OutPutType.Add
                    NewRecord = True
                    m_blnAlteredRecord(Me.CurrentRow) = True
                Case OutPutType.Delete
                    DeletedRecord = True
                Case OutPutType.Add_Update
            End Select

            m_blnOutGet = True

            If blnAT Then
                PutData()
            End If

        End Sub


        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Sub OutPut(ByVal objFile As OracleFileObject, ByVal OutPutType As OutPutType)
            m_blnOutPut = True

            If IsNothing(Me.m_dtbDataTable) Then
                CheckStatusAndInitializeRecord()
            End If

            For i As Integer = 0 To objFile.m_dtbDataTable.Columns.Count - 1
                If Not IsNothing(Me.m_dtbDataTable.Columns(objFile.m_dtbDataTable.Columns(i).ColumnName)) AndAlso objFile.m_dtbDataTable.Columns(i).ColumnName <> "ROW_ID" AndAlso objFile.m_dtbDataTable.Columns(i).ColumnName <> "CHECKSUM_VALUE" Then
                    Me.m_dtbDataTable.Rows(Me.CurrentRow)(objFile.m_dtbDataTable.Columns(i).ColumnName) = objFile.m_dtbDataTable.Rows(objFile.CurrentRow)(i)
                End If
            Next

            Select Case OutPutType
                Case OutPutType.Update
                    If Not Me.Exists Then
                        Exit Sub
                    End If
                Case OutPutType.Add
                    NewRecord = True
                    m_blnAlteredRecord(Me.CurrentRow) = True
                Case OutPutType.Delete
                    DeletedRecord = True
                Case OutPutType.Add_Update
            End Select
            m_blnOutGet = True
            PutData()
        End Sub

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Sub OutPut(ByVal OutPutType As OutPutType)
            m_blnOutPut = True
            Select Case OutPutType
                Case OutPutType.Update
                    If Not Me.Exists Then
                        Exit Sub
                    End If
                Case OutPutType.Add
                    NewRecord = True
                    m_blnAlteredRecord(Me.CurrentRow) = True
                Case OutPutType.Delete
                    DeletedRecord = True
                Case OutPutType.Add_Update
            End Select
            m_blnOutGet = True
            PutData()
        End Sub


        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overrides Sub QTPRecordsRead(ByVal strFile As String, ByVal strFileAlias As String, ByVal intRecords As Integer, ByVal LogType As LogType)
            If Not IsNothing(m_BaseClass) Then

                If strFileAlias.Length > 0 Then
                    strFile = strFileAlias
                End If

                If (m_BaseClass.ScreenType = ScreenTypes.QTP OrElse m_BaseClass.ScreenType = ScreenTypes.QUIZ) Then
                    m_BaseClass.AddRecordsRead(strFile, intRecords, LogType)
                End If
            End If
        End Sub


        ''' -----------------------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Updates an Audit Record based on an associated file.
        ''' </summary>
        ''' <param name="AssociatedFileObject">An OracleFileObject with which an Audit File is associated with</param>
        ''' <remarks>
        ''' </remarks>
        ''' <example>PutData(FleAssociatedFile)</example>
        ''' <history>
        ''' 	[Mayur]	8/29/2005	Created
        ''' </history>
        ''' <exclude/>
        ''' -----------------------------------------------------------------------------
        Public Sub PutAuditData(ByVal AssociatedFileObject As BaseFileObject)

            'Ensure we have record at the current occurrence
            Me.EnsureRows(CurrentRow, False)

            ' Save the Audit record.
            m_blnPutInitiatedFromOccursWithFile = True
            Me.PutData()
            m_blnPutInitiatedFromOccursWithFile = False
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Resets the Audit file.
        ''' </summary>
        ''' <remarks>
        ''' This should only be called by the generated PreCompiler code in association with 
        ''' the PutAuditData method.
        ''' </remarks>
        ''' <example>ResetAudit()</example>
        ''' <history>
        ''' 	[Mayur]	8/29/2005	Created
        ''' </history>
        ''' <exclude/>
        ''' -----------------------------------------------------------------------------
        Public Sub ResetAudit()
            CallReset()
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
        Protected Overrides Function GetTempTableRecordCount(ByVal WhereClause As String) As Long

            Dim SessionTable As DataTable
            If Not IsNothing(m_BaseClass) AndAlso (m_BaseClass.ScreenType = ScreenTypes.QTP OrElse m_BaseClass.ScreenType = ScreenTypes.QUIZ) Then
                'SessionTable = Core.Windows.UI.SessionInformation.GetSession(Me.BaseName, m_BaseClass.QTPSessionID)
            Else
                If (Core.Windows.UI.ApplicationState.Current.TempTable.ContainsKey(BaseName)) Then
                    SessionTable = Core.Windows.UI.ApplicationState.Current.TempTable.Item(BaseName)
                End If
            End If

            If SessionTable Is Nothing Then
                Return 0
            Else
                Dim strRelation As String = Me.BaseName
                If Me.AliasName.Trim.Length > 0 Then strRelation = Me.AliasName

                WhereClause = (WhereClause).ToUpper.Replace("WHERE ", "").Replace(Me.ElementOwner.ToUpper, "").Replace(strRelation & ".", "")

                Return SessionTable.Select(WhereClause).Length
            End If

        End Function

        ''' -----------------------------------------------------------------------------
        ''' 
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
        ''' <exclude/>
        ''' -----------------------------------------------------------------------------
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

                If (m_blnInWhileRetrieving AndAlso DeletedRecord) OrElse (NewRecord AndAlso IsQTP) Then
                    Reset = True
                End If

                If m_Page Is Nothing Then
                    'If Not IsNothing(m_BaseClass.Application) Then
                    '    If Not m_BaseClass.Application("PutProcedures") Is Nothing AndAlso m_BaseClass.Application("PutProcedures").ToString.Equals("True") Then
                    '        MyBase.UsePutProcedures = True
                    '    End If
                    'End If
                Else
                    'If Not IsNothing(m_Page.Application) Then
                    '    If Not m_Page.Application("PutProcedures") Is Nothing AndAlso m_Page.Application("PutProcedures").ToString.Equals("True") Then
                    '        MyBase.UsePutProcedures = True
                    '    End If
                    'End If
                End If


                If Me.IsTempTable OrElse (IsSubFile AndAlso Not IsSubFileKeep()) Then

                    Dim blnContinuePut As Boolean = ContinuePut(PutType)
                    'To trap and convey error to user, we have overrided the PutData
                    'In this case we are using AddMessage to display CheckSum error.
                    MyBase.PutData(Reset, PutType)

                Else

                    Dim blnContinuePut As Boolean = ContinuePut(PutType)
                    'To trap and convey error to user, we have overrided the PutData
                    'In this case we are using AddMessage to display CheckSum error.
                    MyBase.PutData(Reset, PutType)
                    If m_Page Is Nothing Then
                        If Not m_trnTransaction Is Nothing AndAlso blnContinuePut Then
                            If m_BaseClass.ScreenType <> ScreenTypes.QTP Then
                                If m_blnHasLock Then
                                    Unlock(LockTypes.File)
                                    m_BaseClass.TRANS_UPDATE(TransactionMethods.Commit)
                                    Lock(LockTypes.File)
                                Else
                                    m_BaseClass.TRANS_UPDATE(TransactionMethods.Commit)
                                End If
                            End If
                        End If
                    Else
                        If Not m_trnTransaction Is Nothing AndAlso blnContinuePut AndAlso Not m_Page.m_blnExecutingUpdate Then
                            If m_blnHasLock Then
                                Unlock(LockTypes.File)
                                m_Page.TRANS_UPDATE(TransactionMethods.Commit)
                                Lock(LockTypes.File)
                            Else
                                m_Page.TRANS_UPDATE(TransactionMethods.Commit)
                            End If
                        End If
                    End If
                End If

            Catch ex As System.Data.OracleClient.OracleException

                If ex.Message.IndexOf("ORA-20501") = 0 Then
                    ' Checksum error 
                    If m_Page Is Nothing Then
                        m_BaseClass.AddMessage("IM.DataChanged", MessageTypes.Error)
                    Else
                        m_Page.AddMessage("IM.DataChanged", MessageTypes.Error)
                    End If
                Else
                    'TODO: New Internal Message Code should be created
                    If m_Page Is Nothing Then
                        m_BaseClass.AddMessage("IM.DBError", MessageTypes.Error)
                    Else
                        m_Page.AddMessage("IM.DBError", MessageTypes.Error)
                    End If
                End If
                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            Catch ex As CustomApplicationException

                If ex.Message = "IM.DBError" Then
                    If m_Page Is Nothing Then
                        m_BaseClass.AddMessage("IM.DBError", MessageTypes.Error)
                    Else
                        m_Page.AddMessage("IM.DBError", MessageTypes.Error)
                    End If
                Else
                    Throw ex
                End If

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try
        End Sub


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
        Public Overrides Function DeleteTempFile() As Boolean

            Try

                Dim FileName As String

                If Me.AliasName = "" Then
                    FileName = Me.BaseName
                Else
                    FileName = Me.AliasName
                End If




            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Function


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
        Protected Overrides Sub PutDataTempTable()

            Dim SessionTable As DataTable
            Dim PassLog As LogType = LogType.Updated


            If IsQTP Then
                '    If IsNothing(m_dtbQTPTempDataTable) Then
                '        If m_BaseClass.Session("hsSubfile").Contains(Me.BaseName) Then
                '            SessionTable = m_BaseClass.Session("hsSubfile").Item(Me.BaseName)
                '        End If
                '        If IsNothing(SessionTable) Then
                '            SessionTable = Core.Windows.UI.SessionInformation.GetSession(Me.BaseName, m_BaseClass.QTPSessionID)
                '        End If
                '    ElseIf m_BaseClass.Session("hsSubfile").Contains(Me.BaseName) Then
                '        SessionTable = m_BaseClass.Session("hsSubfile").Item(Me.BaseName).Copy
                '    Else
                '        SessionTable = m_dtbQTPTempDataTable.Copy
                '    End If
            Else

                If (Core.Windows.UI.ApplicationState.Current.TempTable.ContainsKey(BaseName)) Then
                    SessionTable = Core.Windows.UI.ApplicationState.Current.TempTable.Item(BaseName)
                End If
            End If


            ' Perform the appropriate action based on the status flags.
            If m_blnDeletedRecord(Me.CurrentRow) Then

                ' Only delete if the session table exists.
                If Not SessionTable Is Nothing Then
                    If SessionTable.Select("ROW_ID = '" & m_dtbDataTable.Rows(Me.CurrentRow).Item("ROW_ID") & "' AND CHECKSUM_VALUE = " & m_dtbDataTable.Rows(Me.CurrentRow).Item("CHECKSUM_VALUE")).Length = 1 Then
                        SessionTable.Select("ROW_ID = '" & m_dtbDataTable.Rows(Me.CurrentRow).Item("ROW_ID") & "' AND CHECKSUM_VALUE = " & m_dtbDataTable.Rows(Me.CurrentRow).Item("CHECKSUM_VALUE"))(0).Delete()
                    Else
                        AddMessage("IM.DataChangedDB", MessageTypes.Error, m_strBaseName)
                    End If
                End If

            Else


                ' Check if a new record or a record being updated.
                If m_dtbDataTable.Rows(Me.CurrentRow).Item("ROW_ID").ToString.TrimEnd.Equals(String.Empty) OrElse NewRecord Then
                    PassLog = LogType.Added
                    If SessionTable Is Nothing Then
                        SessionTable = New DataTable

                        ' Add the columns to match the current file.
                        SessionTable = m_dtbDataTable.Clone
                    End If

                    ' Add the new record.
                    Try
                        m_dtbDataTable.Rows(Me.CurrentRow).Item("ROW_ID") = Now.TimeOfDay.TotalMilliseconds.ToString & (SessionTable.Rows.Count + 1).ToString
                        m_dtbDataTable.Rows(Me.CurrentRow).Item("CHECKSUM_VALUE") = 0
                        SessionTable.Rows.Add(m_dtbDataTable.Rows(Me.CurrentRow).ItemArray)
                    Catch ex As Exception
                        ' If an error occurred, reset the rowid.
                        m_dtbDataTable.Rows(Me.CurrentRow).Item("ROW_ID") = System.DBNull.Value
                        m_dtbDataTable.Rows(Me.CurrentRow).Item("CHECKSUM_VALUE") = System.DBNull.Value
                        AddMessage("IM.DBError", MessageTypes.Error, m_strBaseName)
                    End Try

                Else

                    ' Update the record.
                    Dim strRow As String = "ROW_ID = '" & m_dtbDataTable.Rows(Me.CurrentRow).Item("ROW_ID") & "'"

                    Try
                        m_dtbDataTable.Rows(Me.CurrentRow).Item("CHECKSUM_VALUE") += 1
                        SessionTable.Select(strRow)(0).ItemArray = m_dtbDataTable.Rows(Me.CurrentRow).ItemArray

                    Catch ex As Exception
                        AddMessage("IM.DBError", MessageTypes.Error, m_strBaseName)
                    End Try


                End If

            End If

            If Not SessionTable Is Nothing Then
                ' Commit the changes to the temporary file.
                SessionTable.AcceptChanges()

                If m_blnDeletedRecord(Me.CurrentRow) Then
                    PassLog = LogType.Deleted
                End If

                QTPRecordsRead(Me.BaseName, Me.AliasName, 1, PassLog)


                If IsQTP Then
                    '    If m_BaseClass.Session("hsSubfile").Contains(Me.BaseName) Then
                    '        m_BaseClass.Session("hsSubfile").Item(Me.BaseName) = SessionTable
                    '    Else
                    '        m_BaseClass.Session("hsSubfile").Add(Me.BaseName, SessionTable)
                    '    End If
                Else

                    If (Core.Windows.UI.ApplicationState.Current.TempTable.ContainsKey(BaseName)) Then
                        Core.Windows.UI.ApplicationState.Current.TempTable.Item(BaseName) = SessionTable
                    Else
                        Core.Windows.UI.ApplicationState.Current.TempTable.Add(BaseName, SessionTable)
                    End If
                End If

            End If

        End Sub
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Overrides Property FirstFileCount() As Integer
            Get
                If IsNothing(m_BaseClass) Then
                    Return Nothing
                End If
                Return m_BaseClass.intFirstRecordCount
            End Get
            Set(ByVal Value As Integer)
                If Not IsNothing(m_BaseClass) Then
                    m_BaseClass.intFirstRecordCount = Value
                End If
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Overrides Property FirstOverrideCount() As Integer
            Get
                If IsNothing(m_BaseClass) Then
                    Return Nothing
                End If
                Return m_BaseClass.intFirstOverrideOccurs
            End Get
            Set(ByVal Value As Integer)
                If Not IsNothing(m_BaseClass) Then
                    m_BaseClass.intFirstOverrideOccurs = Value
                End If
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Overrides Property blnIsInSelectIf() As Boolean
            Get
                If IsNothing(m_BaseClass) Then
                    Return Nothing
                End If
                Return m_BaseClass.blnIsInSelectIf
            End Get
            Set(ByVal Value As Boolean)
                If Not IsNothing(m_BaseClass) Then
                    m_BaseClass.blnIsInSelectIf = Value
                End If
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Overrides Property blnGlobalUseTableSelectIf() As BooleanTypes
            Get
                If IsNothing(m_BaseClass) Then
                    Return Nothing
                End If
                Return m_BaseClass.blnGlobalUseTableSelectIf
            End Get
            Set(ByVal Value As BooleanTypes)
                If Not IsNothing(m_BaseClass) Then
                    m_BaseClass.blnGlobalUseTableSelectIf = Value
                End If
            End Set
        End Property



        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Overrides Property FileNoRecords() As String
            Get
                Return m_BaseClass.strFileNoRecords
            End Get
            Set(ByVal value As String)
                m_BaseClass.strFileNoRecords = value
            End Set
        End Property
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Overrides Property FileWhere() As Hashtable
            Get
                Return m_BaseClass.m_hsFileWhere
            End Get
            Set(ByVal value As Hashtable)
                m_BaseClass.m_hsFileWhere = value
            End Set
        End Property

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Overrides ReadOnly Property CurrentFile() As String
            Get
                Return "" 'm_BaseClass.Session("CurrentFile") & ""
            End Get
        End Property

        Private _createWhere As Boolean
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Overrides ReadOnly Property CreateWhere() As Boolean
            Get
                If Not UseMemory OrElse Not IsQTP OrElse SortPhase OrElse IsNothing(m_BaseClass.Session("CreateWhere")) Then
                    Return False
                Else
                    Return m_BaseClass.Session("CreateWhere")
                End If
            End Get
           
        End Property

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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Protected Overrides ReadOnly Property IsAt() As Boolean
            Get
                Return m_BaseClass.m_blnIsAt
            End Get
        End Property

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Overrides Property WhereColumn() As ArrayList
            Get
                'If Not IsNothing(m_BaseClass.Session("WhereColumn" & m_BaseClass.Session("CurrentFile"))) Then
                '    Return m_BaseClass.Session("WhereColumn" & m_BaseClass.Session("CurrentFile"))
                'Else
                '    Return New ArrayList
                'End If
                Return New ArrayList
            End Get
            Set(ByVal value As ArrayList)
                'm_BaseClass.Session("WhereColumn" & m_BaseClass.Session("CurrentFile")) = value
            End Set
        End Property


        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Overrides Property UseMemory() As Boolean
            Get
                If IsNothing(m_BaseClass) Then
                    Return False
                Else
                    Return m_BaseClass.m_blnUseMemory
                End If
            End Get
            Set(ByVal value As Boolean)
                If Not IsNothing(m_BaseClass) Then
                    m_BaseClass.m_blnUseMemory = value
                End If
            End Set
        End Property

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Overrides ReadOnly Property SortPhase() As Boolean
            Get
                Return m_BaseClass.intSorted > 0
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Overrides Property NoRecords() As Boolean
            Get
                Return m_BaseClass.m_blnNoRecords
            End Get
            Set(ByVal Value As Boolean)
                m_BaseClass.m_strNoRecordsLevel = m_intQTPLevel
                m_BaseClass.m_blnNoRecords = Value
            End Set
        End Property

        ''' --- CurrentRow ---------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of CurrentRow.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Overrides ReadOnly Property CurrentRow() As Integer
            Get
                If Me.Type = FileTypes.Reference Then
                    Return 0
                ElseIf Me.Occurs > 0 Then
                    If m_Page Is Nothing Then
                        If blnOverRideOccurrence Then
                            Return OverRideOccurrence
                        Else
                            Return m_BaseClass.Occurrence - 1
                        End If
                    Else
                        Return m_Page.m_intOccurrence
                    End If
                Else
                    Return 0 '--- Me.m_intCurrentRow
                End If
            End Get
        End Property

        ''' --- GetFieldText ----------------------------------------------------
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Overrides Function GetFieldText() As String
            If m_Page Is Nothing Then
                Return m_BaseClass.GetFieldText
            Else
                Return m_Page.FieldText
            End If
        End Function

        ''' --- GetFieldValue ----------------------------------------------------
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Overrides Function GetFieldValue() As Decimal
            If m_Page Is Nothing Then
                Return m_BaseClass.GetFieldValue
            Else
                Return m_Page.FieldValue
            End If
        End Function

        ''' --- IsExecutingPath ----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of IsExecutingPath.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Overrides Function IsExecutingPath() As Boolean
            If m_Page Is Nothing Then
                'TODO: To add m_blnExecutingPath in BaseClassControl
                'Return Me.m_BaseClass.m_blnExecutingPath
            Else
                Return Me.m_Page.m_blnExecutingPath
            End If
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
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Overrides Function IsExecutingPostPath() As Boolean
            If m_Page Is Nothing Then
                'TODO: To add m_blnExecutingPath in BaseClassControl
                'Return Me.m_BaseClass.m_blnExecutingPath
            Else
                Return Me.m_Page.m_blnExecutingPostPath
            End If
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
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Overrides Sub SaveReceivingParam()
            If m_Page Is Nothing Then
                '
            Else
                If m_intPassingSequence > 0 Then
                    Me.m_Page.SaveReceivingParam(Me, m_intPassingSequence)
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
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Overrides Sub SetLastFileObject()
            'Should only be called from GetInternalData.

            'Set the current instance of FileObject that 
            'issued last GetData which is turn being used in AlteredRecord, DeletedRecord 
            'and NewRecord Method of the Base Page
            If m_Page Is Nothing Then
                Me.m_BaseClass.FileForRecordStatus = CType(Me, BaseFileObject)
            Else
                Me.m_Page.FileForRecordStatus = CType(Me, BaseFileObject)
            End If
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
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Overrides Sub SetAccessOkOnPage(ByVal AccessOk As Boolean)
            'The ACCESSOK condition relates to a session and not to a specific screen.
            If m_Page Is Nothing Then
                Me.m_BaseClass.SetAccessOk(AccessOk)
            Else
                Me.m_Page.SetAccessOk(AccessOk)
            End If
        End Sub

        ''' --- GetDataTempTable ---------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetDataTempTable.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Overrides Function GetDataTempTable(ByVal WhereClause As String, ByVal OrderByClause As String, Optional ByVal StartRow As Long = -1, Optional ByVal Count As Integer = -1, Optional ByVal trnTransaction As OracleClient.OracleTransaction = Nothing) As DataTable

            Dim NewDataTable As DataTable = New DataTable(Me.BaseName)
            Dim PreDataTable As DataTable
            Dim SessionTable As DataTable

            If IsQTP Then
                If IsTempTable OrElse (IsSubFile AndAlso Not IsSubFileKeep()) Then
                    'If IsNothing(m_dtbQTPTempDataTable) Then
                    '    If m_BaseClass.Session("hsSubfile").Contains(Me.BaseName) Then
                    '        m_dtbQTPTempDataTable = m_BaseClass.Session("hsSubfile").Item(Me.BaseName)
                    '    End If
                    '    If IsNothing(m_dtbQTPTempDataTable) Then
                    '        m_dtbQTPTempDataTable = Core.Windows.UI.SessionInformation.GetSession(Me.BaseName, m_BaseClass.QTPSessionID)
                    '    End If
                    'ElseIf m_BaseClass.Session("hsSubfile").Contains(Me.BaseName) Then
                    '    m_dtbQTPTempDataTable = m_BaseClass.Session("hsSubfile").Item(Me.BaseName)
                    'End If
                    SessionTable = m_dtbQTPTempDataTable

                    If Not m_blnFirstFile AndAlso Not IsNothing(SessionTable) AndAlso (IsNothing(m_dtbDataTable) OrElse m_dtbDataTable.Rows.Count = 0) Then
                        ReDim m_blnNewRecord(CInt(SessionTable.Rows.Count * 2))
                        ReDim m_blnAlteredRecord(CInt(SessionTable.Rows.Count * 2))
                        ReDim m_blnDeletedRecord(CInt(SessionTable.Rows.Count * 2))
                        ReDim m_blnGridDeletedRecord(CInt(SessionTable.Rows.Count * 2))
                        ReDim m_blnIsInitialized(CInt(SessionTable.Rows.Count * 2))
                        ReDim m_blnCountIntoCalled(CInt(SessionTable.Rows.Count * 2))
                    End If

                Else
                    SessionTable = tmpDataTable
                End If
            Else
                If (Core.Windows.UI.ApplicationState.Current.TempTable.ContainsKey(BaseName)) Then
                    SessionTable = Core.Windows.UI.ApplicationState.Current.TempTable.Item(BaseName)
                End If


                'Core.Windows.UI.SessionInformation.GetSession(Me.BaseName)
            End If

            If Not IsNothing(SessionTable) Then
                PreDataTable = SessionTable
            End If
            Dim NewDataRow As DataRow
            Dim strRelation As String = Me.BaseName
            If Me.AliasName.Trim.Length > 0 Then strRelation = Me.AliasName

            WhereClause = (WhereClause).ToUpper.Replace("WHERE ", "").Replace(Me.ElementOwner.ToUpper, "").Replace(strRelation & ".", "")
            OrderByClause = OrderByClause.ToUpper.Replace("ORDER BY ", "").Replace(Me.ElementOwner.ToUpper, "").Replace(strRelation & ".", "")

            If IsNothing(SessionTable) AndAlso Not m_IsSubFile Then
                Dim tmpDataTable As DataTable = GetCachedSchema(True)
                tmpDataTable.Rows.RemoveAt(0)
                Return tmpDataTable
            Else
                If IsNothing(SessionTable) Then
                    Return NewDataTable
                Else

                    NewDataTable = PreDataTable.Clone

                    Do While (WhereClause.IndexOf("CONVERT(INTEGER, CONVERT(CHAR(8),") >= 0)
                        Dim strColumn As String = String.Empty
                        Dim strReplace As String = String.Empty
                        Dim strOper As String = String.Empty
                        Dim strDate As String = String.Empty
                        Dim arrWhere() As String = WhereClause.Split(" ")


                        For i As Integer = 0 To arrWhere.Length - 1
                            If arrWhere(i) = "CONVERT(INTEGER," Then
                                strColumn = arrWhere(i + 2).Replace(",", "")
                                strOper = arrWhere(i + 4)
                                strDate = arrWhere(i + 5)
                                strDate = "'" & strDate.Substring(0, 4) + "/" & strDate.Substring(4, 2) + "/" & strDate.Substring(6, 2) & "'"
                                strReplace = arrWhere(i) & " " & arrWhere(i + 1) & " " & arrWhere(i + 2) & " " & arrWhere(i + 3) & " " & arrWhere(i + 4) & " " & arrWhere(i + 5).Substring(0, 8)
                                Exit For
                            End If
                        Next

                        WhereClause = WhereClause.Replace(strReplace, strColumn & " " & strOper & " " & strDate)


                    Loop


                    Dim tmpDataRow As DataRow() = PreDataTable.Select(WhereClause, OrderByClause)


                    If OrderByClause.Length = 0 AndAlso WhereClause.Length = 0 AndAlso StartRow = -1 Then
                        Return PreDataTable
                    End If


                    For i As Integer = 0 To tmpDataRow.Length - 1
                        If StartRow = -1 OrElse (StartRow > 0 AndAlso i + 1 >= StartRow AndAlso i + 1 <= (StartRow + Count - 1)) Then
                            NewDataTable.Rows.Add(tmpDataRow(i).ItemArray)
                            If i + 1 = (StartRow + Count - 1) Then Exit For
                        End If
                    Next


                    Return NewDataTable

                End If
            End If


        End Function

        ''' --- Purge --------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Purge.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Overrides Function Purge() As Boolean
            Dim FileName As String

            If Me.AliasName = "" Then
                FileName = Me.BaseName
            Else
                FileName = Me.AliasName
            End If

            If Not IsNothing(m_BaseClass) AndAlso (m_BaseClass.ScreenType = ScreenTypes.QTP OrElse m_BaseClass.ScreenType = ScreenTypes.QUIZ) Then
                'Core.Windows.UI.SessionInformation.Remove(FileName, m_BaseClass.QTPSessionID)
            Else
                If (Core.Windows.UI.ApplicationState.Current.TempTable.ContainsKey(BaseName)) Then
                    Core.Windows.UI.ApplicationState.Current.TempTable.Remove(BaseName)
                End If
            End If

            If Not IsNothing(m_dtbDataTable) Then
                For i As Integer = 0 To m_dtbDataTable.Rows.Count - 1
                    m_dtbDataTable.Rows.Remove(m_dtbDataTable.Rows.Item(i))
                Next
            End If


        End Function

        Public Overrides Sub CallDisplayForDelete()

            Dim FileName As String

            If Me.AliasName = "" Then
                FileName = Me.BaseName
            Else
                FileName = Me.AliasName
            End If

            If Not IsNothing(m_Page) Then
                m_Page.DisplayFileForDelete = FileName
                m_Page.CallDisplayForDelete()
                m_Page.DisplayFileForDelete = ""
            End If

        End Sub

        ''' --- Build --------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Build.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Overrides Function Build() As Boolean

        End Function

        ''' --- TotalRecordsFound --------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of TotalRecordsFound.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Overrides Property TotalRecordsFound() As Integer
            'Note: Only to be used in While skipping records with an error in Find/DetailFind

            'TotalRecordsFound, TotalSkippedRecords and TotalRecordsProcessed
            'are at screen level. i.e. per screen only one file should use these properties
            Get
                Dim objTotalRecordsFound As Object
                If m_Page Is Nothing Then
                    If m_BaseClass Is Nothing Then

                    Else
                        objTotalRecordsFound = Me.m_BaseClass.TotalRecordsFound
                    End If
                Else
                    objTotalRecordsFound = Me.m_Page.TotalRecordsFound
                End If
                If objTotalRecordsFound Is Nothing Then
                    Return -1
                Else
                    Return CInt(objTotalRecordsFound)
                End If
            End Get
            Set(ByVal Value As Integer)
                If m_Page Is Nothing Then
                    If m_BaseClass Is Nothing Then

                    Else
                        Me.m_BaseClass.TotalRecordsFound = Value
                    End If
                Else
                    Me.m_Page.TotalRecordsFound = Value
                End If
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
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Overrides Property TotalSkippedRecords() As Integer
            'Note: TotalRecordsFound, TotalSkippedRecords and TotalRecordsProcessed
            'are at screen level. i.e. per screen only one file should use these properties
            Get
                Dim objTotalRecordsFound As Object
                If m_Page Is Nothing Then
                    objTotalRecordsFound = Me.m_BaseClass.TotalSkippedRecords
                Else
                    objTotalRecordsFound = Me.m_Page.TotalSkippedRecords
                End If
                If objTotalRecordsFound Is Nothing Then
                    Return -1
                Else
                    Return CInt(objTotalRecordsFound)
                End If
            End Get
            Set(ByVal Value As Integer)
                If m_Page Is Nothing Then
                    Me.m_BaseClass.TotalSkippedRecords = Value
                Else
                    Me.m_Page.TotalSkippedRecords = Value
                End If
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
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Overrides Property TotalRecordsProcessed() As Integer
            'Note: TotalRecordsFound, TotalSkippedRecords and TotalRecordsProcessed
            'are at screen level. i.e. per screen only one file should use these properties
            Get
                If m_Page Is Nothing Then
                    Dim objTotalRecordsFound As Object
                    objTotalRecordsFound = Me.m_BaseClass.RecordsProcessed
                    If objTotalRecordsFound Is Nothing Then
                        Return 0
                    Else
                        Return CInt(objTotalRecordsFound)
                    End If
                Else
                    Return Me.m_Page.TotalRecordsProcessed
                End If
            End Get
            Set(ByVal Value As Integer)
                If m_Page Is Nothing Then
                    Me.m_BaseClass.RecordsProcessed = Value
                Else
                    Me.m_Page.TotalRecordsProcessed = Value
                End If
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Overrides ReadOnly Property RecordsForLoop() As Integer
            Get
                If m_Page Is Nothing Then
                    'If required, we need to implement RecordsForLoop property on m_BaseClass
                    'For Now returning 0
                    Return 0
                    'Return Me.m_BaseClass.RecordsForLoop
                Else
                    Return Me.m_Page.RecordsForLoop
                End If

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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Overrides ReadOnly Property IsQTP() As Boolean
            Get
                If Not IsNothing(m_BaseClass) AndAlso (m_BaseClass.ScreenType = ScreenTypes.QTP OrElse m_BaseClass.ScreenType = ScreenTypes.QUIZ) Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property

    End Class

End Namespace
