
Option Explicit On

Imports Core.Framework
Imports Core.Framework.Core.Framework
Imports Core.Framework.Core.Framework.QDesign
Imports System.Data.SqlClient
Imports Core.DataAccess.SqlServer
Imports Core.ExceptionManagement
Imports System.Exception
Imports System.Runtime.Serialization
Imports System.Text
Imports System.Web
Imports System.Xml
Imports System.IO
Imports System.Diagnostics
Imports System.ComponentModel
Imports System.Linq

Namespace Core.Windows

    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: SqlFileObject
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of SqlFileObject.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/22/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <Serializable(), ComponentModel.ToolboxItem(False), ComponentModel.DesignTimeVisible(True),
    EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Class SqlFileObject
        Inherits SqlFileObjectBase

        'TODO: Any Web Specific Methods should be moved from BaseFileObject
        Private m_Page As Core.Windows.UI.Page
        Public m_BaseClass As BaseClassControl



#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
        Private m_BaseQuiz As BaseQuiz
#End If

#Region "Constructor and Destructor"

#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
        ''' --- New ----------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of New.
        ''' </summary>
        ''' <param name="BaseClass"></param>
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
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        ''' 
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Sub New( _
            ByVal BaseClass As Core.Windows.BaseQuiz, _
            ByVal Type As FileTypes, _
            ByVal Occurs As Integer, _
            ByVal Owner As String, _
            ByVal BaseName As String, _
            ByVal AliasName As String, _
            ByVal NoItems As Boolean, _
            ByVal NoAppend As Boolean, _
            ByVal NoDelete As Boolean, _
            ByVal Need As Integer, _
            ByVal TransactionName As String, _
            ByVal FileType As FileType)

            MyBase.New(Type, Occurs, Owner, BaseName, AliasName, NoItems, NoAppend, NoDelete, Need, TransactionName, FileType)

            If FileType = FileType.TempFile Then IsTempTable = True
          If FileType = FileType.SubFile OrElse FileType = FileType.ProtableSubFile  Then IsSubFile = True
         If FileType = FileType.PortableSubFile Then IsPortableSubFile = True

            m_BaseQuiz = BaseClass
            SubscribeStateEvents()

            'Set PrimaryFile property on a page
            If Type = FileTypes.Primary Then
                With m_BaseQuiz
                    .PrimaryFile = ReturnRelation()
                    .m_bfoPrimaryFile = Me
                End With
            End If
        End Sub

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
   Public Sub New( _
       ByVal BaseClass As Core.Windows.BaseQuiz, _
       ByVal Type As FileTypes, _
       ByVal Occurs As Integer, _
       ByVal Owner As String, _
       ByVal BaseName As String, _
       ByVal AliasName As String, _
       ByVal NoItems As Boolean)

            MyBase.New(Type, Occurs, Owner, BaseName, AliasName, NoItems, False, False, 0, "", FileType.DataFile)


            m_BaseQuiz = BaseClass
            SubscribeStateEvents()

            'Set PrimaryFile property on a page
            If Type = FileTypes.Primary Then
                With m_BaseQuiz
                    .PrimaryFile = ReturnRelation()
                    .m_bfoPrimaryFile = Me
                End With
            End If
        End Sub

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
   Public Sub New( _
       ByVal BaseClass As Core.Windows.BaseQuiz, _
       ByVal Type As FileTypes, _
       ByVal Occurs As Integer, _
       ByVal Owner As String, _
       ByVal BaseName As String, _
       ByVal AliasName As String, _
       ByVal NoItems As Boolean, _
       ByVal NoAppend As Boolean)

            MyBase.New(Type, Occurs, Owner, BaseName, AliasName, NoItems, NoAppend, False, 0, "", FileType.DataFile)


            m_BaseQuiz = BaseClass
            SubscribeStateEvents()

            'Set PrimaryFile property on a page
            If Type = FileTypes.Primary Then
                With m_BaseQuiz
                    .PrimaryFile = ReturnRelation()
                    .m_bfoPrimaryFile = Me
                End With
            End If
        End Sub

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
   Public Sub New( _
       ByVal BaseClass As Core.Windows.BaseQuiz, _
       ByVal Type As FileTypes, _
       ByVal Occurs As Integer, _
       ByVal Owner As String, _
       ByVal BaseName As String, _
       ByVal AliasName As String, _
       ByVal NoItems As Boolean, _
       ByVal NoAppend As Boolean, _
       ByVal NoDelete As Boolean)

            MyBase.New(Type, Occurs, Owner, BaseName, AliasName, NoItems, NoAppend, NoDelete, 0, "", FileType.DataFile)



            m_BaseQuiz = BaseClass
            SubscribeStateEvents()

            'Set PrimaryFile property on a page
            If Type = FileTypes.Primary Then
                With m_BaseQuiz
                    .PrimaryFile = ReturnRelation()
                    .m_bfoPrimaryFile = Me
                End With
            End If
        End Sub

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
   Public Sub New( _
       ByVal BaseClass As Core.Windows.BaseQuiz, _
       ByVal Type As FileTypes, _
       ByVal Occurs As Integer, _
       ByVal Owner As String, _
       ByVal BaseName As String, _
       ByVal AliasName As String, _
       ByVal NoItems As Boolean, _
       ByVal NoAppend As Boolean, _
       ByVal NoDelete As Boolean, _
       ByVal Need As Integer)

            MyBase.New(Type, Occurs, Owner, BaseName, AliasName, NoItems, NoAppend, NoDelete, Need, "", FileType.DataFile)



            m_BaseQuiz = BaseClass
            SubscribeStateEvents()

            'Set PrimaryFile property on a page
            If Type = FileTypes.Primary Then
                With m_BaseQuiz
                    .PrimaryFile = ReturnRelation()
                    .m_bfoPrimaryFile = Me
                End With
            End If
        End Sub

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
    Public Sub New( _
       ByVal BaseClass As Core.Windows.BaseQuiz, _
       ByVal Type As FileTypes, _
       ByVal Occurs As Integer, _
       ByVal Owner As String, _
       ByVal BaseName As String, _
       ByVal AliasName As String, _
       ByVal NoItems As Boolean, _
       ByVal NoAppend As Boolean, _
       ByVal NoDelete As Boolean, _
       ByVal Need As Integer, _
       ByVal TransactionName As String)

            MyBase.New(Type, Occurs, Owner, BaseName, AliasName, NoItems, NoAppend, NoDelete, Need, TransactionName, FileType.DataFile)

            m_BaseQuiz = BaseClass
            SubscribeStateEvents()

            'Set PrimaryFile property on a page
            If Type = FileTypes.Primary Then
                With m_BaseQuiz
                    .PrimaryFile = ReturnRelation()
                    .m_bfoPrimaryFile = Me
                End With
            End If
        End Sub

#End If

        ''' --- New ----------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of New.
        ''' </summary>
        ''' <param name="BaseClass"></param>
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
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        ''' 
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Sub New(
            ByVal BaseClass As Core.Windows.BaseClassControl,
            ByVal Type As FileTypes,
            ByVal Occurs As Integer,
            ByVal Owner As String,
            ByVal BaseName As String,
            ByVal AliasName As String,
            ByVal NoItems As Boolean,
            ByVal NoAppend As Boolean,
            ByVal NoDelete As Boolean,
            ByVal Need As Integer,
            ByVal TransactionName As String,
            ByVal FileType As FileType)

            MyBase.New(Type, Occurs, Owner, BaseName, AliasName, NoItems, NoAppend, NoDelete, Need, TransactionName, FileType)

            If FileType = FileType.TempFile Then IsTempTable = True
            If FileType = FileType.SubFile OrElse FileType = FileType.PortableSubFile Then IsSubFile = True
            If FileType = FileType.PortableSubFile Then IsPortableSubFile = True

            m_BaseClass = BaseClass
            SubscribeStateEvents()

            'Set PrimaryFile property on a page
            If Type = FileTypes.Primary Then
                With m_BaseClass
                    .PrimaryFile = ReturnRelation()
                    .m_bfoPrimaryFile = Me
                End With
            End If
        End Sub

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Sub New(
       ByVal BaseClass As Core.Windows.BaseClassControl,
       ByVal Type As FileTypes,
       ByVal Occurs As Integer,
       ByVal Owner As String,
       ByVal BaseName As String,
       ByVal AliasName As String,
       ByVal NoItems As Boolean)

            MyBase.New(Type, Occurs, Owner, BaseName, AliasName, NoItems, False, False, 0, "", FileType.DataFile)


            m_BaseClass = BaseClass
            SubscribeStateEvents()

            'Set PrimaryFile property on a page
            If Type = FileTypes.Primary Then
                With m_BaseClass
                    .PrimaryFile = ReturnRelation()
                    .m_bfoPrimaryFile = Me
                End With
            End If
        End Sub

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Sub New(
       ByVal BaseClass As Core.Windows.BaseClassControl,
       ByVal Type As FileTypes,
       ByVal Occurs As Integer,
       ByVal Owner As String,
       ByVal BaseName As String,
       ByVal AliasName As String,
       ByVal NoItems As Boolean,
       ByVal NoAppend As Boolean)

            MyBase.New(Type, Occurs, Owner, BaseName, AliasName, NoItems, NoAppend, False, 0, "", FileType.DataFile)


            m_BaseClass = BaseClass
            SubscribeStateEvents()

            'Set PrimaryFile property on a page
            If Type = FileTypes.Primary Then
                With m_BaseClass
                    .PrimaryFile = ReturnRelation()
                    .m_bfoPrimaryFile = Me
                End With
            End If
        End Sub

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Sub New(
       ByVal BaseClass As Core.Windows.BaseClassControl,
       ByVal Type As FileTypes,
       ByVal Occurs As Integer,
       ByVal Owner As String,
       ByVal BaseName As String,
       ByVal AliasName As String,
       ByVal NoItems As Boolean,
       ByVal NoAppend As Boolean,
       ByVal NoDelete As Boolean)

            MyBase.New(Type, Occurs, Owner, BaseName, AliasName, NoItems, NoAppend, NoDelete, 0, "", FileType.DataFile)



            m_BaseClass = BaseClass
            SubscribeStateEvents()

            'Set PrimaryFile property on a page
            If Type = FileTypes.Primary Then
                With m_BaseClass
                    .PrimaryFile = ReturnRelation()
                    .m_bfoPrimaryFile = Me
                End With
            End If
        End Sub

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Sub New(
       ByVal BaseClass As Core.Windows.BaseClassControl,
       ByVal Type As FileTypes,
       ByVal Occurs As Integer,
       ByVal Owner As String,
       ByVal BaseName As String,
       ByVal AliasName As String,
       ByVal NoItems As Boolean,
       ByVal NoAppend As Boolean,
       ByVal NoDelete As Boolean,
       ByVal Need As Integer)

            MyBase.New(Type, Occurs, Owner, BaseName, AliasName, NoItems, NoAppend, NoDelete, Need, "", FileType.DataFile)



            m_BaseClass = BaseClass
            SubscribeStateEvents()

            'Set PrimaryFile property on a page
            If Type = FileTypes.Primary Then
                With m_BaseClass
                    .PrimaryFile = ReturnRelation()
                    .m_bfoPrimaryFile = Me
                End With
            End If
        End Sub

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Sub New(
       ByVal BaseClass As Core.Windows.BaseClassControl,
       ByVal Type As FileTypes,
       ByVal Occurs As Integer,
       ByVal Owner As String,
       ByVal BaseName As String,
       ByVal AliasName As String,
       ByVal NoItems As Boolean,
       ByVal NoAppend As Boolean,
       ByVal NoDelete As Boolean,
       ByVal Need As Integer,
       ByVal TransactionName As String)

            MyBase.New(Type, Occurs, Owner, BaseName, AliasName, NoItems, NoAppend, NoDelete, Need, TransactionName, FileType.DataFile)

            m_BaseClass = BaseClass
            SubscribeStateEvents()

            'Set PrimaryFile property on a page
            If Type = FileTypes.Primary Then
                With m_BaseClass
                    .PrimaryFile = ReturnRelation()
                    .m_bfoPrimaryFile = Me
                End With
            End If
        End Sub

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Sub New(
          ByVal Type As FileTypes,
          ByVal Occurs As Integer,
          ByVal Owner As String,
          ByVal BaseName As String,
          ByVal AliasName As String,
          ByVal NoItems As Boolean,
          ByVal NoAppend As Boolean,
          ByVal NoDelete As Boolean,
          ByVal Need As Integer,
          ByVal TransactionName As String,
          ByVal FileType As FileType)

            MyBase.New(Type, Occurs, Owner, BaseName, AliasName, NoItems, NoAppend, NoDelete, Need, TransactionName, FileType)

            If FileType = FileType.TempFile Then IsTempTable = True
            If FileType = FileType.SubFile OrElse FileType = FileType.PortableSubFile Then IsSubFile = True
            If FileType = FileType.PortableSubFile Then IsPortableSubFile = True

            SubscribeStateEvents()

            'Set PrimaryFile property on a page
            If Type = FileTypes.Primary Then
                With m_BaseClass
                    .PrimaryFile = ReturnRelation()
                    .m_bfoPrimaryFile = Me
                End With
            End If
        End Sub

        Public Sub New(
         ByVal Type As FileTypes,
         ByVal Occurs As Integer,
         ByVal Owner As String,
         ByVal BaseName As String,
         ByVal AliasName As String,
         ByVal NoItems As Boolean,
         ByVal NoAppend As Boolean,
         ByVal NoDelete As Boolean,
         ByVal Need As Integer,
         ByVal TransactionName As String)

            MyBase.New(Type, Occurs, Owner, BaseName, AliasName, NoItems, NoAppend, NoDelete, Need, TransactionName, FileType.DataFile)

            SubscribeStateEvents()

            'Set PrimaryFile property on a page
            If Type = FileTypes.Primary Then
                With m_BaseClass
                    .PrimaryFile = ReturnRelation()
                    .m_bfoPrimaryFile = Me
                End With
            End If
        End Sub

        Public Sub New(
          ByVal Type As FileTypes,
          ByVal Occurs As Integer,
          ByVal Owner As String,
          ByVal BaseName As String,
          ByVal AliasName As String,
          ByVal NoItems As Boolean,
          ByVal NoAppend As Boolean,
          ByVal NoDelete As Boolean,
          ByVal Need As Integer)

            MyBase.New(Type, Occurs, Owner, BaseName, AliasName, NoItems, NoAppend, NoDelete, Need, "", FileType.DataFile)

            SubscribeStateEvents()

            'Set PrimaryFile property on a page
            If Type = FileTypes.Primary Then
                With m_BaseClass
                    .PrimaryFile = ReturnRelation()
                    .m_bfoPrimaryFile = Me
                End With
            End If
        End Sub

        Public Sub New(
          ByVal Type As FileTypes,
          ByVal Occurs As Integer,
          ByVal Owner As String,
          ByVal BaseName As String,
          ByVal AliasName As String,
          ByVal NoItems As Boolean,
          ByVal NoAppend As Boolean,
          ByVal NoDelete As Boolean)

            MyBase.New(Type, Occurs, Owner, BaseName, AliasName, NoItems, NoAppend, NoDelete, 0, "", FileType.DataFile)

            SubscribeStateEvents()

            'Set PrimaryFile property on a page
            If Type = FileTypes.Primary Then
                With m_BaseClass
                    .PrimaryFile = ReturnRelation()
                    .m_bfoPrimaryFile = Me
                End With
            End If
        End Sub

        Public Sub New(
         ByVal Type As FileTypes,
         ByVal Occurs As Integer,
         ByVal Owner As String,
         ByVal BaseName As String,
         ByVal AliasName As String,
         ByVal NoItems As Boolean,
         ByVal NoAppend As Boolean)

            MyBase.New(Type, Occurs, Owner, BaseName, AliasName, NoItems, NoAppend, False, 0, "", FileType.DataFile)


            SubscribeStateEvents()

            'Set PrimaryFile property on a page
            If Type = FileTypes.Primary Then
                With m_BaseClass
                    .PrimaryFile = ReturnRelation()
                    .m_bfoPrimaryFile = Me
                End With
            End If
        End Sub

        Public Sub New(
          ByVal Type As FileTypes,
          ByVal Occurs As Integer,
          ByVal Owner As String,
          ByVal BaseName As String,
          ByVal AliasName As String,
          ByVal NoItems As Boolean)

            MyBase.New(Type, Occurs, Owner, BaseName, AliasName, NoItems, False, False, 0, "", FileType.DataFile)


            SubscribeStateEvents()

            'Set PrimaryFile property on a page
            If Type = FileTypes.Primary Then
                With m_BaseClass
                    .PrimaryFile = ReturnRelation()
                    .m_bfoPrimaryFile = Me
                End With
            End If
        End Sub

        Public Sub New(
        ByVal Type As FileTypes,
        ByVal Occurs As Integer,
        ByVal Owner As String,
        ByVal BaseName As String,
        ByVal AliasName As String)

            MyBase.New(Type, Occurs, Owner, BaseName, AliasName, False, False, False, 0, "", FileType.DataFile)


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
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of New.
        ''' </summary>
        ''' <param name="BaseClass"></param>
        ''' <param name="Type"></param>
        ''' <param name="OccursWith"></param>
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
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Sub New(
            ByVal BaseClass As Core.Windows.BaseClassControl,
            ByVal Type As FileTypes,
            ByVal OccursWith As SqlFileObject,
            ByVal Owner As String,
            ByVal BaseName As String,
            ByVal AliasName As String,
            ByVal NoItems As Boolean,
            ByVal NoAppend As Boolean,
            ByVal NoDelete As Boolean,
            ByVal Need As Integer,
            ByVal TransactionName As String,
            ByVal FileType As FileType)

            MyBase.New(Type, OccursWith.Occurs, Owner, BaseName, AliasName, NoItems, NoAppend, NoDelete, Need, TransactionName, FileType)
            m_blnOccursWith = True
            m_OccursWith = OccursWith

            If FileType = FileType.TempFile Then IsTempTable = True
            If FileType = FileType.SubFile OrElse FileType = FileType.PortableSubFile Then IsSubFile = True
            If FileType = FileType.PortableSubFile Then IsPortableSubFile = True

            OccursWith.WireNavigationEvents(Me)
            m_BaseClass = BaseClass
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

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Sub New(
            ByVal BaseClass As Core.Windows.BaseClassControl,
            ByVal Type As FileTypes,
            ByVal OccursWith As SqlFileObject,
            ByVal Owner As String,
            ByVal BaseName As String,
            ByVal AliasName As String,
            ByVal NoItems As Boolean,
            ByVal NoAppend As Boolean,
            ByVal NoDelete As Boolean,
            ByVal Need As Integer,
            ByVal TransactionName As String)

            MyBase.New(Type, OccursWith.Occurs, Owner, BaseName, AliasName, NoItems, NoAppend, NoDelete, Need, TransactionName, FileType.DataFile)
            m_blnOccursWith = True
            m_OccursWith = OccursWith



            OccursWith.WireNavigationEvents(Me)
            m_BaseClass = BaseClass
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

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Sub New(
            ByVal BaseClass As Core.Windows.BaseClassControl,
            ByVal Type As FileTypes,
            ByVal OccursWith As SqlFileObject,
            ByVal Owner As String,
            ByVal BaseName As String,
            ByVal AliasName As String,
            ByVal NoItems As Boolean,
            ByVal NoAppend As Boolean,
            ByVal NoDelete As Boolean,
            ByVal Need As Integer)

            MyBase.New(Type, OccursWith.Occurs, Owner, BaseName, AliasName, NoItems, NoAppend, NoDelete, Need, "", FileType.DataFile)
            m_blnOccursWith = True
            m_OccursWith = OccursWith


            OccursWith.WireNavigationEvents(Me)
            m_BaseClass = BaseClass
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

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Sub New(
            ByVal BaseClass As Core.Windows.BaseClassControl,
            ByVal Type As FileTypes,
            ByVal OccursWith As SqlFileObject,
            ByVal Owner As String,
            ByVal BaseName As String,
            ByVal AliasName As String,
            ByVal NoItems As Boolean,
            ByVal NoAppend As Boolean,
            ByVal NoDelete As Boolean)

            MyBase.New(Type, OccursWith.Occurs, Owner, BaseName, AliasName, NoItems, NoAppend, NoDelete, 0, "", FileType.DataFile)
            m_blnOccursWith = True
            m_OccursWith = OccursWith

            OccursWith.WireNavigationEvents(Me)
            m_BaseClass = BaseClass
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

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Sub New(
            ByVal BaseClass As Core.Windows.BaseClassControl,
            ByVal Type As FileTypes,
            ByVal OccursWith As SqlFileObject,
            ByVal Owner As String,
            ByVal BaseName As String,
            ByVal AliasName As String,
            ByVal NoItems As Boolean,
            ByVal NoAppend As Boolean)

            MyBase.New(Type, OccursWith.Occurs, Owner, BaseName, AliasName, NoItems, NoAppend, False, 0, "", FileType.DataFile)
            m_blnOccursWith = True
            m_OccursWith = OccursWith

            OccursWith.WireNavigationEvents(Me)
            m_BaseClass = BaseClass
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

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Sub New(
         ByVal BaseClass As Core.Windows.BaseClassControl,
         ByVal Type As FileTypes,
         ByVal OccursWith As SqlFileObject,
         ByVal Owner As String,
         ByVal BaseName As String,
         ByVal AliasName As String,
         ByVal NoItems As Boolean)

            MyBase.New(Type, OccursWith.Occurs, Owner, BaseName, AliasName, NoItems, False, False, 0, "", FileType.DataFile)
            m_blnOccursWith = True
            m_OccursWith = OccursWith

            OccursWith.WireNavigationEvents(Me)
            m_BaseClass = BaseClass
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

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Sub New(
            ByVal BaseClass As Core.Windows.BaseClassControl,
            ByVal Type As FileTypes,
            ByVal OccursWith As SqlFileObject,
            ByVal Owner As String,
            ByVal BaseName As String,
            ByVal AliasName As String)

            MyBase.New(Type, OccursWith.Occurs, Owner, BaseName, AliasName, False, False, False, 0, "", FileType.DataFile)
            m_blnOccursWith = True
            m_OccursWith = OccursWith

            OccursWith.WireNavigationEvents(Me)
            m_BaseClass = BaseClass
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
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of New.
        ''' </summary>
        ''' <param name="CorePage"></param>
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
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Sub New(
             ByVal CorePage As Core.Windows.UI.Page,
            ByVal Type As FileTypes,
            ByVal Occurs As Integer,
            ByVal Owner As String,
            ByVal BaseName As String,
            ByVal AliasName As String,
             ByVal NoItems As Boolean,
             ByVal NoAppend As Boolean,
             ByVal NoDelete As Boolean,
             ByVal Need As Integer,
             ByVal TransactionName As String,
             ByVal FileType As FileType)

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

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Sub New(
           ByVal CorePage As Core.Windows.UI.Page,
          ByVal Type As FileTypes,
          ByVal Occurs As Integer,
          ByVal Owner As String,
          ByVal BaseName As String,
          ByVal AliasName As String,
          ByVal NoItems As Boolean,
          ByVal NoAppend As Boolean,
          ByVal NoDelete As Boolean,
          ByVal Need As Integer,
          ByVal TransactionName As String)

            MyBase.New(Type, Occurs, Owner, BaseName, AliasName, NoItems, NoAppend, NoDelete, Need, TransactionName, FileType.DataFile)
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

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Sub New(
            ByVal CorePage As Core.Windows.UI.Page,
           ByVal Type As FileTypes,
           ByVal Occurs As Integer,
           ByVal Owner As String,
           ByVal BaseName As String,
           ByVal AliasName As String,
           ByVal NoItems As Boolean,
           ByVal NoAppend As Boolean,
           ByVal NoDelete As Boolean,
           ByVal Need As Integer)

            MyBase.New(Type, Occurs, Owner, BaseName, AliasName, NoItems, NoAppend, NoDelete, Need, "", FileType.DataFile)
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

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Sub New(
            ByVal CorePage As Core.Windows.UI.Page,
           ByVal Type As FileTypes,
           ByVal Occurs As Integer,
           ByVal Owner As String,
           ByVal BaseName As String,
           ByVal AliasName As String,
           ByVal NoItems As Boolean,
           ByVal NoAppend As Boolean,
           ByVal NoDelete As Boolean)

            MyBase.New(Type, Occurs, Owner, BaseName, AliasName, NoItems, NoAppend, NoDelete, 0, "", FileType.DataFile)
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

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Sub New(
           ByVal CorePage As Core.Windows.UI.Page,
          ByVal Type As FileTypes,
          ByVal Occurs As Integer,
          ByVal Owner As String,
          ByVal BaseName As String,
          ByVal AliasName As String,
          ByVal NoItems As Boolean,
          ByVal NoAppend As Boolean)

            MyBase.New(Type, Occurs, Owner, BaseName, AliasName, NoItems, NoAppend, False, 0, "", FileType.DataFile)
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

        Public Sub New(
             ByVal CorePage As Core.Windows.UI.Page,
            ByVal Type As FileTypes,
            ByVal Occurs As Integer,
            ByVal Owner As String,
            ByVal BaseName As String,
            ByVal AliasName As String,
            ByVal NoItems As Boolean)

            MyBase.New(Type, Occurs, Owner, BaseName, AliasName, NoItems, False, False, 0, "", FileType.DataFile)
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

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Sub New(
          ByVal CorePage As Core.Windows.UI.Page,
         ByVal Type As FileTypes,
         ByVal Occurs As Integer,
         ByVal Owner As String,
         ByVal BaseName As String,
         ByVal AliasName As String)

            MyBase.New(Type, Occurs, Owner, BaseName, AliasName, False, False, False, 0, "", FileType.DataFile)
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
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of New.
        ''' </summary>
        ''' <param name="CorePage"></param>
        ''' <param name="Type"></param>
        ''' <param name="OccursWith"></param>
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
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Sub New(
            ByVal CorePage As Core.Windows.UI.Page,
            ByVal Type As FileTypes,
            ByVal OccursWith As SqlFileObject,
            ByVal Owner As String,
            ByVal BaseName As String,
            ByVal AliasName As String,
            ByVal NoItems As Boolean,
            ByVal NoAppend As Boolean,
            ByVal NoDelete As Boolean,
            ByVal Need As Integer,
            ByVal TransactionName As String)

            MyBase.New(Type, OccursWith.Occurs, Owner, BaseName, AliasName, NoItems, NoAppend, NoDelete, Need, TransactionName)
            m_blnOccursWith = True
            OccursWith.WireNavigationEvents(Me)
            m_OccursWith = OccursWith
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


        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Sub New(
         ByVal CorePage As Core.Windows.UI.Page,
         ByVal Type As FileTypes,
         ByVal OccursWith As SqlFileObject,
         ByVal Owner As String,
         ByVal BaseName As String,
         ByVal AliasName As String,
         ByVal NoItems As Boolean,
         ByVal NoAppend As Boolean,
         ByVal NoDelete As Boolean,
         ByVal Need As Integer,
         ByVal TransactionName As String,
          ByVal FileType As FileType)

            MyBase.New(Type, OccursWith.Occurs, Owner, BaseName, AliasName, NoItems, NoAppend, NoDelete, Need, TransactionName, FileType)
            m_blnOccursWith = True
            OccursWith.WireNavigationEvents(Me)
            m_OccursWith = OccursWith
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

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Sub New(
            ByVal CorePage As Core.Windows.UI.Page,
            ByVal Type As FileTypes,
            ByVal OccursWith As SqlFileObject,
            ByVal Owner As String,
            ByVal BaseName As String,
            ByVal AliasName As String,
            ByVal NoItems As Boolean,
            ByVal NoAppend As Boolean,
            ByVal NoDelete As Boolean,
            ByVal Need As Integer)

            MyBase.New(Type, OccursWith.Occurs, Owner, BaseName, AliasName, NoItems, NoAppend, NoDelete, Need, "")
            m_blnOccursWith = True
            OccursWith.WireNavigationEvents(Me)
            m_OccursWith = OccursWith
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

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Sub New(
         ByVal CorePage As Core.Windows.UI.Page,
         ByVal Type As FileTypes,
         ByVal OccursWith As SqlFileObject,
         ByVal Owner As String,
         ByVal BaseName As String,
         ByVal AliasName As String,
         ByVal NoItems As Boolean,
         ByVal NoAppend As Boolean,
         ByVal NoDelete As Boolean)

            MyBase.New(Type, OccursWith.Occurs, Owner, BaseName, AliasName, NoItems, NoAppend, NoDelete, 0, "")
            m_blnOccursWith = True
            OccursWith.WireNavigationEvents(Me)
            m_OccursWith = OccursWith
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

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Sub New(
            ByVal CorePage As Core.Windows.UI.Page,
            ByVal Type As FileTypes,
            ByVal OccursWith As SqlFileObject,
            ByVal Owner As String,
            ByVal BaseName As String,
            ByVal AliasName As String,
            ByVal NoItems As Boolean,
            ByVal NoAppend As Boolean)

            MyBase.New(Type, OccursWith.Occurs, Owner, BaseName, AliasName, NoItems, NoAppend, False, 0, "")
            m_blnOccursWith = True
            OccursWith.WireNavigationEvents(Me)
            m_OccursWith = OccursWith
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

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Sub New(
            ByVal CorePage As Core.Windows.UI.Page,
            ByVal Type As FileTypes,
            ByVal OccursWith As SqlFileObject,
            ByVal Owner As String,
            ByVal BaseName As String,
            ByVal AliasName As String,
            ByVal NoItems As Boolean)

            MyBase.New(Type, OccursWith.Occurs, Owner, BaseName, AliasName, NoItems, False, False, 0, "")
            m_blnOccursWith = True
            OccursWith.WireNavigationEvents(Me)
            m_OccursWith = OccursWith
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

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Sub New(
           ByVal CorePage As Core.Windows.UI.Page,
           ByVal Type As FileTypes,
           ByVal OccursWith As SqlFileObject,
           ByVal Owner As String,
           ByVal BaseName As String,
           ByVal AliasName As String)

            MyBase.New(Type, OccursWith.Occurs, Owner, BaseName, AliasName, False, False, False, 0, "")
            m_blnOccursWith = True
            OccursWith.WireNavigationEvents(Me)
            m_OccursWith = OccursWith
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overrides Sub AddMessage(ByVal Message As String, ByVal Type As MessageTypes, ByVal ParamArray Parameters() As Object)
            If m_Page Is Nothing Then
                'For i As Integer = 0 To Parameters.Length - 1
                '    If Not Parameters(i) Is Nothing Then Message &= ":" & Parameters(i).ToString
                'Next
                If m_BaseClass Is Nothing Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                    m_BaseQuiz.AddMessage(Message, Type)
#End If
                Else
                    m_BaseClass.AddMessage(Message, Type, Parameters)
                End If
            Else
                m_Page.AddMessage(Message, Type, Parameters)
            End If
        End Sub

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overridable Sub SetOverRideOccurrence(ByVal value As Integer, ByVal FileName As String)
            Dim strRelation As String = Me.BaseName
            If Me.AliasName.Trim.Length > 0 Then strRelation = Me.AliasName
            If FileName = strRelation Then
                OverRideOccurrence = value
            End If
        End Sub

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Friend Sub CreateDataStructure()
            ' In some cases where Subfile's are being created based on a FileObject, there is no column information
            ' to create an empty structure. This new Sub will allow the column information to be 
            CreateEmptyStructure(True)
        End Sub

        ''' --- ResetFile ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of ResetFile.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overridable Sub ResetFile(ByVal Sender As Object)

            If m_blnResetAtOutput Then
                blnQTPInit = True
                CallReset()
                m_blnResetAtOutput = False
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overridable Sub SaveTempFile(ByVal Sender As Object, ByVal e As PageStateEventArgs)
            If Not Me.IsSubFile AndAlso Not IsNothing(m_dtbQTPTempDataTable) Then
                'Core.Windows.UI.SessionInformation.SetSession(Me.BaseName, m_dtbQTPTempDataTable, m_BaseClass.QTPSessionID)
            End If
            If Not IsNothing(m_BaseClass) Then
                'm_BaseClass.Session,Hashtable("WhereColumn" & Me.BaseName) = Nothing
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
            ElseIf Not IsNothing(m_BaseQuiz) Then
                m_BaseQuiz.Session("WhereColumn" & Me.BaseName) = Nothing
#End If
            End If

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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Private Sub CheckAlteredFlag(ByRef Altered As Boolean)

            ' If the Page's IsDirty is not set to true (based on previous file's
            ' CheckAlteredFlag event, then check the status of the current file.
            If Not Altered AndAlso Not Me.Type = FileTypes.Master Then
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Private Sub SubscribeStateEvents()
            If Not IsNothing(m_Page) Then

                AddHandler m_Page.CheckFileStatuses, AddressOf CheckAlteredFlag
            ElseIf Not IsNothing(m_BaseClass) Then

                AddHandler m_BaseClass.SetOverRideOccurrence, AddressOf SetOverRideOccurrence
                AddHandler m_BaseClass.ResetFile, AddressOf ResetFile
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
            ElseIf Not IsNothing(m_BaseQuiz) Then
                AddHandler m_BaseQuiz.LoadPageState, AddressOf LoadPageState
                AddHandler m_BaseQuiz.SavePageState, AddressOf SavePageState
                AddHandler m_BaseQuiz.SetOverRideOccurrence, AddressOf SetOverRideOccurrence
#End If
            End If
            If IsQTP Then
                If Not IsNothing(m_BaseClass) Then
                    AddHandler m_BaseClass.SaveTempFile, AddressOf SaveTempFile
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                ElseIf Not IsNothing(m_BaseQuiz) Then
                    AddHandler m_BaseQuiz.SaveTempFile, AddressOf SaveTempFile
#End If
                End If
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overrides Sub SetOccurrence(ByVal NewValue As Integer, Optional ByVal Reset As Boolean = False)
            'Note: This is internal method and should ONLY be
            'called from Break method of BaseFileObject
            If m_Page Is Nothing Then
                If m_BaseClass Is Nothing Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                    m_BaseQuiz.SetOccurrence(NewValue, Reset)
#End If
                Else
                    m_BaseClass.SetOccurrence(NewValue, Reset)
                End If
            Else
                m_Page.SetOccurrence(NewValue, Reset)
            End If
        End Sub

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overrides Function QTPLoop() As Boolean

            Dim m_Class As Object = Nothing

            Try

                If m_BaseClass Is Nothing Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                    m_Class = m_BaseQuiz
#End If
                Else
                    m_Class = m_BaseClass
                End If
                If m_blnInDefine Then Return True

                intSortOrder = intSortOrder + 1

                If intSortFileOrder = -1 Then
                    intSortFileOrder = m_Class.m_SortFileOrder + 1
                    m_Class.m_SortFileOrder = m_Class.m_SortFileOrder + 1
                End If

                If m_Class.m_SortOrder = "" Then
                    m_Class.m_SortOrder = intSortOrder.ToString.PadLeft(10, " ")
                Else
                    Dim tmpSortOrder As String = m_Class.m_SortOrder
                    m_Class.m_SortOrder = ""

                    For i As Integer = 0 To intSortFileOrder - 2
                        m_Class.m_SortOrder = m_Class.m_SortOrder & "," & tmpSortOrder.Split(",")(i)
                    Next

                    m_Class.m_SortOrder = m_Class.m_SortOrder & "," & intSortOrder.ToString.PadLeft(10, " ")
                    m_Class.m_SortOrder = m_Class.m_SortOrder.Substring(1)

                End If

                m_Class = Nothing

            Catch ex As Exception
                m_Class = Nothing
            End Try

        End Function

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overrides Function QTPForMissing() As Boolean
            Return QTPForMissing("")
        End Function


        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overrides Function QTPForMissing(ByVal strForId As String) As Boolean

            Dim m_Class As Object = Nothing

            Try

                m_blnResetAtOutput = False


                If IsNothing(m_BaseClass) Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                    m_Class = m_BaseQuiz
#End If
                Else
                    m_Class = m_BaseClass
                End If


                m_blnCreateBlankRow = False

                m_intQTPLevel = VAL(strForId)

                If Me.AliasName = "" Then
                    m_Class.Session("CurrentFile") = Me.BaseName
                Else
                    m_Class.Session("CurrentFile") = Me.AliasName
                End If

                If m_Class.blnDeleteSubFile = True Then
                    If Not m_Class.blnHasSort AndAlso Not m_Class.blnDeletedSubFile AndAlso m_Class.blnHasRunSubfile = False Then
                        Return True
                    Else
                        Return False
                    End If
                End If

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
                Else
                    m_blnOutPut = False
                End If

                If strForId.Length > 0 Then
                    m_blnFirstFile = False
                    m_BaseClass.Session("CreateWhere") = True
                Else
                    NoRecords = False
                    m_blnFirstFile = True
                    m_Class.m_SortOrder = ""
                End If

                If NoRecords Then
                    If IsNothing(m_dtbDataTable) Then
                        Return False
                    Else
                        If m_dtbDataTable.Rows.Count - 1 > OverRideOccurrence AndAlso m_intQTPLevel < VAL(m_Class.m_strNoRecordsLevel) Then
                            m_dtbDataTable.Rows.RemoveAt(OverRideOccurrence)
                            m_blnContinue = True
                            NoRecords = False
                            SortOccurrence = OverRideOccurrence - 1
                            intSortOrder = OverRideOccurrence - 1
                        Else
                            If Not IsNothing(m_dtbDataTable) AndAlso m_intQTPLevel <= VAL(m_Class.m_strNoRecordsLevel) Then
                                Rowcount = m_dtbDataTable.Rows.Count
                                If OverRideOccurrence < m_dtbDataTable.Rows.Count AndAlso Rowcount > 0 Then
                                    Do While intLastfound > -1 AndAlso Rowcount > 0

                                        If Not IsNothing(m_Class.dtSortOrder) AndAlso m_Class.dtSortOrder.Rows.Count > 0 Then

                                            If m_Class.arrSortOrder.Contains(intSortFileOrder.ToString & "_" & (Rowcount - 1).ToString) Then
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
                        'ElseIf m_blnOutPut Then
                        '    OverRideOccurrence = OverRideOccurrence - 1
                    End If

                    If m_blnFirstFile AndAlso Not m_BaseClass.blnDeleteSubFile AndAlso Not m_BaseClass.blnHasSort AndAlso Not m_BaseClass.blnHasRunSubfile AndAlso Not m_BaseClass.blnDeletedSubFile Then
                        m_Class.blnDeleteSubFile = True
                        blnReturn = True
                    End If

                End If

                If strForId.Length = 0 Then
                    FirstOverrideCount = OverRideOccurrence
                End If




                Return blnReturn

            Catch ex As Exception
                m_Class = Nothing
            Finally
                m_Class = Nothing
            End Try

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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overrides Function GetOccurrence() As Integer
            'Note: This is internal method and should ONLY be
            'called from Break method of BaseFileObject
            If m_Page Is Nothing Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                If m_BaseQuiz Is Nothing Then
#End If
                Return m_BaseClass.Occurrence - 1
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                Else
                    Return m_BaseQuiz.Occurrence - 1
                End If
#End If
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
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overrides Function IsInAppendOrEntry() As Boolean
            If m_Page Is Nothing Then
                If m_BaseClass Is Nothing Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                    Return m_BaseQuiz.IsInAppendOrEntry
#End If
                Else
                    Return m_BaseClass.IsInAppendOrEntry
                End If
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overrides Function IsInFindOrDetailFind() As Boolean
            If m_Page Is Nothing Then
                If m_BaseClass Is Nothing Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                    Return m_BaseQuiz.InFindOrDetailFind
#End If
                Else
                    Return m_BaseClass.InFindOrDetailFind
                End If
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overrides Function IsInFind() As Boolean
            If m_Page Is Nothing Then
                If m_BaseClass Is Nothing Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                    Return m_BaseQuiz.InFind
#End If
                Else
                    Return m_BaseClass.InFind
                End If
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overrides Function PageMode() As PageModeTypes
            If m_Page Is Nothing Then
                If m_BaseClass Is Nothing Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                    Return m_BaseQuiz.Mode
#End If
                Else
                    Return m_BaseClass.Mode
                End If
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overrides Function SetAlteredFlag() As Boolean
            ' The AlteredRecord flag is not set to True if the value was changed when 
            ' FindMode is true except when in the PostFind or DetailPostFind.  If in 
            ' NoMode (in our case we are in NoMode when searching for a record using FIND 
            ' and no records are found, or by pressing the cancel button), the AlteredRecord flag
            ' should not be set to True, unless we are running the INITIALIZE procedure.  In
            ' all other modes, the AlteredRecord status should change to True when the value changes.

            If m_Page Is Nothing Then
                If m_BaseClass Is Nothing Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                    Return m_BaseQuiz.SetAlteredFlag
#End If
                Else
                    Return m_BaseClass.SetAlteredFlag
                End If
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overrides Sub GetOverrideSQL(ByVal OverrideSQL As System.Text.StringBuilder, ByVal WhereClause As String, ByVal SelectIf As String, ByVal AccessClause As String, ByVal OrderByClause As String, ByRef WholeWhereCondition As String, ByRef SkippedRecords As Integer, Optional ByRef blnoverridesql As Boolean = False)
            'Called from the GetData metod of the BaseFileObject

            'If OverridSQL already contains SQL Statement, return the same statement
            If blnoverridesql Then
                If m_Page Is Nothing Then
                    If m_BaseClass Is Nothing Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                        m_BaseQuiz.SetCurrentRecordPosition(Me, WhereClause, SelectIf, AccessClause, OrderByClause, WholeWhereCondition, SkippedRecords)
#End If
                    Else
                        m_BaseClass.SetCurrentRecordPosition(Me, WhereClause, SelectIf, AccessClause, OrderByClause, WholeWhereCondition, SkippedRecords)
                    End If
                Else
                    m_Page.SetCurrentRecordPosition(Me, WhereClause, SelectIf, AccessClause, OrderByClause, WholeWhereCondition, SkippedRecords, OverrideSQL.ToString)
                End If
            Else
                If OverrideSQL.Length > 0 Then Return

                If m_Page Is Nothing Then
                    If m_BaseClass Is Nothing Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                        m_BaseQuiz.SetCurrentRecordPosition(Me, WhereClause, SelectIf, AccessClause, OrderByClause, WholeWhereCondition, SkippedRecords)
#End If
                    Else
                        m_BaseClass.SetCurrentRecordPosition(Me, WhereClause, SelectIf, AccessClause, OrderByClause, WholeWhereCondition, SkippedRecords)
                    End If
                Else
                    m_Page.SetCurrentRecordPosition(Me, WhereClause, SelectIf, AccessClause, OrderByClause, WholeWhereCondition, SkippedRecords)
                End If
            End If



            If Not (Me.IsTempTable OrElse (Me.IsSubFile AndAlso Not Me.IsSubFileKeep)) Then
                Me.GetSubSelectStatement(OverrideSQL, WholeWhereCondition, OrderByClause, Me.m_intCurrentRecordPosition, SkippedRecords)
            End If
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overrides Function GetDictionary(ByVal FieldID As String) As CoreDictionaryItem

            If m_Page Is Nothing Then
                If m_BaseClass Is Nothing Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                    Return m_BaseQuiz.GetDictionaryItem(FieldID)
#End If
                Else
                    Return m_BaseClass.GetDictionaryItem(FieldID)
                End If
            Else
                Return m_Page.GetDictionaryItem(FieldID)
            End If

        End Function

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Sub OutPut(ByVal OutPutType As OutPutType, ByVal blnAT As Object, ByVal blnContinue As Object)

            Try
                m_HasAt = False
                m_blnOutPut = True
                m_BaseClass.blnHasRunSubfile = True
                If m_BaseClass.blnDeleteSubFile Then
                    m_BaseClass.blnDeletedSubFile = True
                    QTPRecordsRead(Me.BaseName, Me.AliasName, 0, LogType.Added)

                    If IsNothing(Me.m_dtbDataTable) Then
                        CheckStatusAndInitializeRecord()
                    End If

                    Exit Sub
                End If
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

                If (IsNothing(blnContinue) OrElse blnContinue) AndAlso (IsNothing(blnAT) OrElse blnAT) Then
                    m_blnOutGet = True
                    PutData()
                Else
                    QTPRecordsRead(Me.BaseName, Me.AliasName, 0, LogType.OutPut)
                    If OutPutType = OutPutType.Update Then
                        QTPRecordsRead(Me.BaseName, Me.AliasName, 1, LogType.UnChanged)
                    ElseIf OutPutType = OutPutType.Add Then

                        QTPRecordsRead(Me.BaseName, Me.AliasName, 0, LogType.Added)
                    End If



                End If


                If Not m_BaseClass.Subtotal_Files.Contains(Me) Then
                    m_BaseClass.Subtotal_Files.Add(Me)
                End If
                If Not IsNothing(blnAT) AndAlso Not blnAT Then
                    m_HasAt = True
                End If




            Catch ex As Exception
                m_BaseClass.WriteError(ex)


            End Try


            If m_BaseClass.blnHasSort Then
                If (Not m_BaseClass.InializesFile.Contains(Me)) Then
                    m_BaseClass.InializesFile.Add(Me)
                End If
            Else
                IsInitialized = False
            End If




        End Sub
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Sub OutPut(ByVal OutPutType As OutPutType, ByVal blnAT As Object, ByVal blnContinue As Object, ByVal OnError As OnError)
            Try
                If OnError = OnError.Report Then blnOnErrorReport = True
                OutPut(OutPutType, blnAT, blnContinue)
                blnOnErrorReport = False
            Catch ex As Exception
                m_BaseClass.WriteError(ex)
            End Try
        End Sub


        '   <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        'Public Sub OutPut(ByVal OutPutType As OutPutType, ByVal blnAT As Boolean)
        '    Try
        '        m_blnOutPut = True
        '        m_BaseClass.blnHasRunSubfile = True
        '        If m_BaseClass.blnDeleteSubFile Then
        '            m_BaseClass.blnDeletedSubFile = True
        '            QTPRecordsRead(Me.BaseName, Me.AliasName, 0, LogType.Added)
        '            Exit Sub
        '        End If
        '        Select Case OutPutType
        '            Case OutPutType.Update
        '                If Not Me.Exists Then
        '                    Exit Sub
        '                End If
        '            Case OutPutType.Add
        '                NewRecord = True
        '                m_blnAlteredRecord(Me.CurrentRow) = True
        '            Case OutPutType.Delete
        '                DeletedRecord = True
        '            Case OutPutType.Add_Update
        '        End Select

        '        If blnAT Then
        '            m_blnOutGet = True
        '            PutData()
        '        Else
        '            QTPRecordsRead(Me.BaseName, Me.AliasName, 0, LogType.OutPut)
        '            If OutPutType = OutPutType.Update Then
        '                QTPRecordsRead(Me.BaseName, Me.AliasName, 1, LogType.UnChanged)
        '            ElseIf OutPutType = OutPutType.Add Then

        '                QTPRecordsRead(Me.BaseName, Me.AliasName, 0, LogType.Added)
        '            End If
        '        End If

        '        m_HasAt = Not blnAT

        '    Catch ex As Exception
        '        m_BaseClass.WriteError(ex)
        '    End Try

        '    IsInitialized = False
        'End Sub

        '<EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        'Public Sub OutPut(ByVal OutPutType As OutPutType, ByVal blnAT As Boolean, ByVal OnError As OnError)
        '    Try
        '        If OnError = OnError.Report Then blnOnErrorReport = True
        '        OutPut(OutPutType, blnAT)
        '        blnOnErrorReport = False
        '    Catch ex As Exception
        '        m_BaseClass.WriteError(ex)
        '    End Try
        'End Sub

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Sub OutPut(ByVal objFile As SqlFileObject, ByVal OutPutType As OutPutType, ByVal blnAT As Object, ByVal blnContinue As Object)
            Try
                m_blnOutPut = True
                m_BaseClass.blnHasRunSubfile = True
                If m_BaseClass.blnDeleteSubFile Then
                    m_BaseClass.blnDeletedSubFile = True
                    QTPRecordsRead(Me.BaseName, Me.AliasName, 0, LogType.Added)
                    Exit Sub
                End If

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

                If blnContinue AndAlso blnAT Then
                    m_blnOutGet = True

                    PutData()
                Else
                    QTPRecordsRead(Me.BaseName, Me.AliasName, 0, LogType.OutPut)
                    If OutPutType = OutPutType.Update Then
                        QTPRecordsRead(Me.BaseName, Me.AliasName, 1, LogType.UnChanged)
                    ElseIf OutPutType = OutPutType.Add Then

                        QTPRecordsRead(Me.BaseName, Me.AliasName, 0, LogType.Added)
                    End If



                End If

            Catch ex As Exception
                m_BaseClass.WriteError(ex)
            End Try

            If m_BaseClass.blnHasSort Then
                If (Not m_BaseClass.InializesFile.Contains(Me)) Then
                    m_BaseClass.InializesFile.Add(Me)
                End If
            Else
                IsInitialized = False
            End If

            m_HasAt = Not blnAT

        End Sub

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Sub OutPut(ByVal objFile As SqlFileObject, ByVal OutPutType As OutPutType, ByVal blnAT As Object, ByVal blnContinue As Object, ByVal OnError As OnError)

            Try
                If OnError = OnError.Report Then blnOnErrorReport = True
                OutPut(objFile, OutPutType, blnAT, blnContinue)
                blnOnErrorReport = False
            Catch ex As Exception
                m_BaseClass.WriteError(ex)
            End Try
        End Sub

        '<EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        'Public Sub OutPut(ByVal objFile As SqlFileObject, ByVal OutPutType As OutPutType, ByVal blnAT As Boolean)
        '    Try
        '        m_blnOutPut = True
        '        m_BaseClass.blnHasRunSubfile = True
        '        If m_BaseClass.blnDeleteSubFile Then
        '            m_BaseClass.blnDeletedSubFile = True
        '            QTPRecordsRead(Me.BaseName, Me.AliasName, 0, LogType.Added)
        '            Exit Sub
        '        End If

        '        If IsNothing(Me.m_dtbDataTable) Then
        '            CheckStatusAndInitializeRecord()
        '        End If

        '        For i As Integer = 0 To objFile.m_dtbDataTable.Columns.Count - 1
        '            If Not IsNothing(Me.m_dtbDataTable.Columns(objFile.m_dtbDataTable.Columns(i).ColumnName)) AndAlso objFile.m_dtbDataTable.Columns(i).ColumnName <> "ROW_ID" AndAlso objFile.m_dtbDataTable.Columns(i).ColumnName <> "CHECKSUM_VALUE" Then
        '                Me.m_dtbDataTable.Rows(Me.CurrentRow)(objFile.m_dtbDataTable.Columns(i).ColumnName) = objFile.m_dtbDataTable.Rows(objFile.CurrentRow)(i)
        '            End If
        '        Next

        '        Select Case OutPutType
        '            Case OutPutType.Update
        '                If Not Me.Exists Then
        '                    Exit Sub
        '                End If
        '            Case OutPutType.Add
        '                NewRecord = True
        '                m_blnAlteredRecord(Me.CurrentRow) = True
        '            Case OutPutType.Delete
        '                DeletedRecord = True
        '            Case OutPutType.Add_Update
        '        End Select


        '        If blnAT Then
        '            m_blnOutGet = True

        '            PutData()
        '        Else
        '            QTPRecordsRead(Me.BaseName, Me.AliasName, 0, LogType.OutPut)
        '            If OutPutType = OutPutType.Update Then
        '                QTPRecordsRead(Me.BaseName, Me.AliasName, 1, LogType.UnChanged)
        '            ElseIf OutPutType = OutPutType.Add Then

        '                QTPRecordsRead(Me.BaseName, Me.AliasName, 0, LogType.Added)
        '            End If
        '        End If

        '    Catch ex As Exception
        '        m_BaseClass.WriteError(ex)
        '    End Try

        '    IsInitialized = False
        '    m_HasAt = Not blnAT


        'End Sub

        '<EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        'Public Sub OutPut(ByVal objFile As SqlFileObject, ByVal OutPutType As OutPutType, ByVal blnAT As Boolean, ByVal OnError As OnError)
        '    Try
        '        If OnError = OnError.Report Then blnOnErrorReport = True
        '        OutPut(objFile, OutPutType, blnAT)
        '        blnOnErrorReport = False
        '    Catch ex As Exception
        '        m_BaseClass.WriteError(ex)
        '    End Try
        'End Sub


        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Sub OutPut(ByVal objFile As SqlFileObject, ByVal OutPutType As OutPutType)
            Try
                m_blnOutPut = True
                m_BaseClass.blnHasRunSubfile = True
                If m_BaseClass.blnDeleteSubFile Then
                    m_BaseClass.blnDeletedSubFile = True
                    QTPRecordsRead(Me.BaseName, Me.AliasName, 0, LogType.Added)
                    Exit Sub
                End If

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
                        ReDim m_blnDeletedRecord(OverRideOccurrence)

                        DeletedRecord = True
                    Case OutPutType.Add_Update
                End Select
                m_blnOutGet = True

                PutData()


                If m_BaseClass.blnHasSort Then
                    If (Not m_BaseClass.InializesFile.Contains(Me)) Then
                        m_BaseClass.InializesFile.Add(Me)
                    End If
                Else
                    IsInitialized = False
                End If

            Catch ex As Exception
                m_BaseClass.WriteError(ex)
            End Try
        End Sub

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Sub OutPut(ByVal objFile As SqlFileObject, ByVal OutPutType As OutPutType, ByVal OnError As OnError)
            Try
                If OnError = OnError.Report Then blnOnErrorReport = True
                OutPut(objFile, OutPutType)
                blnOnErrorReport = False

            Catch ex As Exception
                m_BaseClass.WriteError(ex)
            End Try
        End Sub

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Sub OutPut(ByVal OutPutType As OutPutType)
            Try
                m_blnOutPut = True
                m_BaseClass.blnHasRunSubfile = True
                If m_BaseClass.blnDeleteSubFile Then
                    m_BaseClass.blnDeletedSubFile = True
                    QTPRecordsRead(Me.BaseName, Me.AliasName, 0, LogType.Added)
                    Exit Sub
                End If
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


                If m_BaseClass.blnHasSort Then
                    If (Not m_BaseClass.InializesFile.Contains(Me)) Then
                        m_BaseClass.InializesFile.Add(Me)
                    End If
                Else
                    IsInitialized = False
                End If

            Catch ex As Exception
                m_BaseClass.WriteError(ex)
            End Try
        End Sub

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Sub OutPut(ByVal OutPutType As OutPutType, ByVal OnError As OnError)
            Try
                If OnError = OnError.Report Then blnOnErrorReport = True
                OutPut(OutPutType)
                blnOnErrorReport = False
            Catch ex As Exception
                m_BaseClass.WriteError(ex)
            End Try
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

            'Save Audit record
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
                ' SessionTable = Core.Windows.UI.SessionInformation.GetSession(Me.BaseName, m_BaseClass.QTPSessionID)
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

        ''' --- PutData ------------------------------------------------------------
        ''' <exclude/>
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
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
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

                If (m_blnInWhileRetrieving AndAlso DeletedRecord) Then
                    Reset = True
                ElseIf (NewRecord AndAlso IsQTP) Then
                    ' Does the Reset at the next Output for an Output(Add) so that
                    ' if this record is being used in a Subfile, that we can retrieve 
                    ' the data.
                    m_blnResetAtOutput = True
                End If

                If m_Page Is Nothing Then
                    If m_BaseClass Is Nothing Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                        If Not IsNothing(m_BaseQuiz.Application) Then
                            If Not m_BaseQuiz.Application("PutProcedures") Is Nothing AndAlso m_BaseQuiz.Application("PutProcedures").ToString.Equals("True") Then
                                MyBase.UsePutProcedures = True
                            End If
                        End If
#End If
                    Else
                        'If Not IsNothing(m_BaseClass.Application) Then
                        '    If Not m_BaseClass.Application("PutProcedures") Is Nothing AndAlso m_BaseClass.Application("PutProcedures").ToString.Equals("True") Then
                        '        MyBase.UsePutProcedures = True
                        '    End If
                        'End If
                    End If
                Else
                    'If Not IsNothing(m_Page.Application) Then
                    '    If Not m_Page.Application("PutProcedures") Is Nothing AndAlso m_Page.Application("PutProcedures").ToString.Equals("True") Then
                    '        MyBase.UsePutProcedures = True
                    '    End If
                    'End If
                End If

                If Me.IsTempTable OrElse (IsSubFile AndAlso (m_IsSubFileKeep = 1 OrElse m_IsSubFileKeep = 0)) Then

                    Dim blnContinuePut As Boolean = ContinuePut(PutType)
                    'To trap and convey error to user, we have overrided the PutData
                    'In this case we are using AddMessage to display CheckSum error.
                    MyBase.PutData(Reset, PutType, At)

                Else

                    Dim blnContinuePut As Boolean = ContinuePut(PutType)
                    'To trap and convey error to user, we have overrided the PutData
                    'In this case we are using AddMessage to display CheckSum error.
                    MyBase.PutData(Reset, PutType, -1)

                    If m_Page Is Nothing Then
                        If Not m_trnTransaction Is Nothing AndAlso blnContinuePut Then
                            If m_BaseClass Is Nothing Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                                If m_BaseQuiz.ScreenType <> ScreenTypes.QTP Then
                                    If m_blnHasLock Then
                                        Unlock(LockTypes.File)
                                        m_BaseQuiz.TRANS_UPDATE(TransactionMethods.Commit)
                                        Lock(LockTypes.File)
                                    Else
                                        m_BaseQuiz.TRANS_UPDATE(TransactionMethods.Commit)
                                    End If
                                End If
#End If
                            Else
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

                If m_blnResetAtOutput Then
                    blnQTPInit = True
                    CallReset()
                    m_blnResetAtOutput = False
                End If

            Catch ex As System.Data.SqlClient.SqlException

                If m_Page Is Nothing Then
                    If m_BaseClass Is Nothing Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                        m_BaseQuiz.AddMessage("Database Error: Could not update the table <{0}>!", MessageTypes.Error)'IM.DBError
#End If
                    Else
                        m_BaseClass.AddMessage("Database Error: Could not update the table <{0}>!", MessageTypes.Error) 'IM.DBError
                    End If
                Else
                    m_Page.AddMessage("Database Error: Could not update the table <{0}>!", MessageTypes.Error)
                End If
                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            Catch ex As CustomApplicationException



                If ex.Message = "Database Error: Could not update the table <{0}>!" Then 'IM.DBError
                    If m_Page Is Nothing Then
                        If m_BaseClass Is Nothing Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                            m_BaseQuiz.AddMessage("Database Error: Could not update the table <{0}>!", MessageTypes.Error)'IM.DBError
#End If
                        Else
                            m_BaseClass.AddMessage("Database Error: Could not update the table <{0}>!", MessageTypes.Error) 'IM.DBError
                        End If

                    Else

                        m_Page.AddMessage("Database Error: Could not update the table <{0}>!", MessageTypes.Error) 'IM.DBError
                    End If


                Else

                    If m_Page Is Nothing Then
                        'm_BaseClass.TRANS_UPDATE(TransactionMethods.Rollback)
                    Else
                        m_Page.TRANS_UPDATE(TransactionMethods.Rollback)
                    End If

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

                If m_Page Is Nothing Then
                    If m_BaseClass Is Nothing Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                        UI.SessionInformation.Remove(FileName, m_BaseQuiz.Session.SessionID)
#End If
                    Else
                        'UI.SessionInformation.Remove(FileName, m_BaseClass.Session,Hashtable.SessionID)
                    End If
                Else
                    'UI.SessionInformation.Remove(FileName, m_Page.Session.SessionID)
                End If


            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overrides Function Build() As Boolean

        End Function
        ''' --- GetTextTableStructure ---------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetTextTableStructure.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overrides Function GetTextTableStructure() As DataTable

            Dim strFilePath As String = ""
            Dim strFileColumn As String = strFilePath

            If IsQTP Then
                strFilePath = Directory.GetCurrentDirectory()
            Else
                strFilePath = Environment.GetEnvironmentVariable("CurrentDirectory", EnvironmentVariableTarget.Process)
                strFilePath = strFilePath.Replace(vbCr, "\r")
            End If

            If IsPortableSubFile Then
                If strFileColumn.EndsWith("\") Then
                    strFileColumn = strFilePath & Me.BaseName & ".psd"
                Else
                    strFileColumn = strFilePath & "\" & Me.BaseName & ".psd"
                End If
            Else
                If strFileColumn.EndsWith("\") Then
                    strFileColumn = strFilePath & Me.BaseName & ".sfd"
                Else
                    strFileColumn = strFilePath & "\" & Me.BaseName & ".sfd"
                End If
            End If




            If Not File.Exists(strFileColumn) Then
                If IsNothing(m_BaseClass) Then
                    'strFilePath = System.Configuration.ConfigurationManager.AppSettings("FlatFilePath") & "\" & m_Page.Session("m_strUser") & "_" & m_Page.Session("m_strSessionID")
                Else
                    'strFilePath = System.Configuration.ConfigurationManager.AppSettings("FlatFilePath") & "\" & m_BaseClass.Session("m_strUser") & "_" & m_BaseClass.Session("m_strSessionID")
                End If
                If IsPortableSubFile Then
                    If strFileColumn.EndsWith("\") Then
                        strFileColumn = strFilePath & Me.BaseName & ".psd"
                    Else
                        strFileColumn = strFilePath & "\" & Me.BaseName & ".psd"
                    End If
                Else
                    If strFileColumn.EndsWith("\") Then
                        strFileColumn = strFilePath & Me.BaseName & ".sfd"
                    Else
                        strFileColumn = strFilePath & "\" & Me.BaseName & ".sfd"
                    End If
                End If


            End If


            Dim strFile As String = String.Empty
            Dim sr As New StreamReader(strFileColumn)
            Dim dt As New DataTable
            Dim strText As String = String.Empty
            Dim arrStructure() As String
            Dim intPlaceholder As Integer = 0
            Dim intLinelength As Integer = 0
            Dim hsLength As New Hashtable
            Dim strTextName As String = String.Empty

            Dim dc As DataColumn

            Try


                strText = sr.ReadLine

                Do While Not IsNothing(strText)
                    arrStructure = strText.Split(",")

                    dc = New DataColumn()
                    dc.ColumnName = arrStructure(0)

                    dc.DataType = System.Type.GetType(arrStructure(1))
                    hsLength.Add(arrStructure(0).ToLower, arrStructure(2))

                    dt.Columns.Add(dc)

                    intLinelength = intLinelength + VAL(arrStructure(2))

                    strText = sr.ReadLine
                Loop

                sr.Close()


                Return dt

            Catch ex As Exception
                Return dt
            End Try

        End Function



        Public Overrides Function GetCachedSchemaDat() As DataTable

            Dim cachedt As DataTable = New DataTable
            Dim hsLength As New Hashtable
            Dim strFilePath As String = Directory.GetCurrentDirectory()
            Dim strFileColumn As String = strFilePath

            If strFileColumn.EndsWith("\") Then
                strFileColumn = System.Configuration.ConfigurationManager.AppSettings("FlatFileDictionary") & Me.BaseName & ".dfd"
            Else
                strFileColumn = System.Configuration.ConfigurationManager.AppSettings("FlatFileDictionary") & "\" & Me.BaseName & ".dfd"
            End If

            Dim sr As StreamReader = New StreamReader(strFileColumn)
            Dim strtmp As String = sr.ReadLine()

            cachedt = New DataTable

            Dim arrStructure() As String
            Dim dc As DataColumn

            Do While Not IsNothing(strtmp)
                If strtmp.Trim.Length > 0 Then
                    arrStructure = strtmp.Split(",")

                    dc = New DataColumn()
                    dc.ColumnName = arrStructure(0)

                    If arrStructure(1).LastIndexOf("System.Zoned") >= 0 Then
                        dc.DataType = System.Type.GetType("System.Decimal")
                    Else
                        dc.DataType = System.Type.GetType(arrStructure(1))
                    End If

                    hsLength.Add(arrStructure(0).ToLower, arrStructure(2))

                    cachedt.Columns.Add(dc)
                End If
                strtmp = sr.ReadLine
            Loop

            If hsLength.Count Then
                If Not IsNothing(m_BaseClass) Then
                    If m_BaseClass.Session("hsSubfileKeepText").Contains(Me.BaseName) Then
                        m_BaseClass.Session("hsSubfileKeepText").Item(Me.BaseName) = hsLength
                    Else
                        m_BaseClass.Session("hsSubfileKeepText").Add(Me.BaseName, hsLength)
                    End If
                End If
            End If

            cachedt.Columns.Add("ROW_ID", System.Type.GetType("System.Decimal"))

            Return cachedt

        End Function

        ''' --- GetTextTableRecordCount ---------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' 	Summary of GetTextTableRecordCount.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overrides Function GetTextTableRecordCount(ByVal WhereClause As String) As Long
            Dim strFilePath As String = ""
            Dim strFileColumn As String = ""

            Dim strFile As String = String.Empty
            Dim sr As StreamReader
            Dim dt As New DataTable
            Dim dtTemp As New DataTable
            Dim strText As StringBuilder = New StringBuilder("")
            Dim arrStructure() As String
            Dim intPlaceholder As Integer = 0
            Dim intLinelength As Integer = 0
            Dim hsLength As New Hashtable
            Dim hsColumns As New Hashtable
            Dim strTextName As String = String.Empty
            Dim strName As String = String.Empty
            Dim dc As DataColumn
            Dim rw As DataRow
            Dim blnAllColumns As Boolean = True
            Dim arrColumns As New ArrayList

            Try



                If IsQTP Then
                    If IsNothing(Me.m_BaseClass.Session("strSubFileName")) Then
                        strTextName = Me.BaseName
                    Else
                        strTextName = Me.m_BaseClass.Session("strSubFileName").ToString
                        If strTextName.IndexOf(".") >= 0 Then
                            strName = strTextName.Substring(0, strTextName.IndexOf("."))
                            strTextName = strTextName.Substring(strTextName.IndexOf(".") + 1)
                            strTextName = strTextName.Replace(".", "\") & "\" & strName
                        End If
                    End If

                    If Owner = "SEQUENTIAL" Then
                        strTextName = strTextName + ".dat"
                    Else
                        If IsPortableSubFile Then
                            strTextName = strTextName + ".ps"
                        Else
                            strTextName = strTextName + ".sf"
                        End If
                    End If


                Else
                    Try
                        strTextName = Me.BaseName

                        If strTextName.IndexOf(".") >= 0 Then
                            strName = strTextName.Substring(0, strTextName.IndexOf("."))
                            strTextName = strTextName.Substring(strTextName.IndexOf(".") + 1)
                            strTextName = strTextName.Replace(".", "\") & "\" & strName
                        End If
                    Catch ex As Exception
                        strTextName = Me.BaseName
                    End Try

                End If



                If Not IsNothing(m_Page) Then
                    If Not IsNothing(m_Page.Session("hsSubfile")) Then
                        If m_Page.Session("hsSubfile").Contains(Me.BaseName) Then
                            dt = m_Page.Session("hsSubfile").Item(Me.BaseName)
                        End If
                    End If
                End If


                If dt.Rows.Count = 0 Then

                    If IsQTP Then
                        strFilePath = Directory.GetCurrentDirectory()
                    Else
                        strFilePath = Environment.GetEnvironmentVariable("CurrentDirectory", EnvironmentVariableTarget.Process)
                        strFilePath = strFilePath.Replace(vbCr, "\r")
                    End If


                    If strFilePath.EndsWith("\") Then
                        strFile = strFilePath & strTextName
                    Else
                        strFile = strFilePath & "\" & strTextName
                    End If

                    If Not File.Exists(strFile) Then
                        If IsNothing(m_BaseClass) Then
                            'strFilePath = System.Configuration.ConfigurationManager.AppSettings("FlatFilePath") & "\" & m_Page.Session("m_strUser") & "_" & m_Page.Session("m_strSessionID")
                        Else
                            'strFilePath = System.Configuration.ConfigurationManager.AppSettings("FlatFilePath") & "\" & m_BaseClass.Session("m_strUser") & "_" & m_BaseClass.Session("m_strSessionID")
                        End If
                        If strFile.EndsWith("\") Then
                            strFile = strFilePath & strTextName
                        Else
                            strFile = strFilePath & "\" & strTextName
                        End If
                    End If

                    If Not File.Exists(strFile) Then
                        strFile = strFile.Replace(".sf", ".ps")
                    End If

                    strFileColumn = strFilePath

                    If Owner = "SEQUENTIAL" Then
                        If strFileColumn.EndsWith("\") Then
                            strFileColumn = System.Configuration.ConfigurationManager.AppSettings("FlatFileDictionary") & Me.BaseName & ".dfd"
                        Else
                            strFileColumn = System.Configuration.ConfigurationManager.AppSettings("FlatFileDictionary") & "\" & Me.BaseName & ".dfd"
                        End If

                        If Not File.Exists(strFile) Then
                            strFile = strFile + ".dat"
                        End If

                    Else
                        If IsPortableSubFile Then

                            If strFileColumn.EndsWith("\") Then
                                strFileColumn = strFilePath & Me.BaseName & ".psd"
                            Else
                                strFileColumn = strFilePath & "\" & Me.BaseName & ".psd"
                            End If
                        Else
                            If strFileColumn.EndsWith("\") Then
                                strFileColumn = strFilePath & Me.BaseName & ".sfd"
                            Else
                                strFileColumn = strFilePath & "\" & Me.BaseName & ".sfd"
                            End If
                        End If
                    End If


                    If Not File.Exists(strFileColumn) Then
                        strFileColumn = strFileColumn.Replace(".sfd", ".psd")
                    End If

                    sr = New StreamReader(strFileColumn)

                    If IsNothing(m_BaseClass) Then
                        If Not m_Page.hsSubConverted.Contains(Me.BaseName) Then
                            m_Page.hsSubConverted.Add(Me.BaseName, Me.BaseName)
                        End If
                    Else
                        If Not m_BaseClass.hsSubConverted.Contains(Me.BaseName) Then
                            m_BaseClass.hsSubConverted.Add(Me.BaseName, Me.BaseName)
                        End If
                    End If


                    Dim strtmp As String
                    strtmp = sr.ReadLine

                    Do While Not IsNothing(strtmp)
                        If (strtmp.Trim.Length > 0) Then

                            arrStructure = strtmp.Split(",")

                            If blnAllColumns OrElse arrColumns.Contains(arrStructure(0).ToUpper) Then
                                dc = New DataColumn()
                                dc.ColumnName = arrStructure(0)

                                hsColumns.Add(arrStructure(0), arrStructure(1))

                                If arrStructure(1).LastIndexOf("System.Zoned") >= 0 Then
                                    dc.DataType = System.Type.GetType("System.Decimal")
                                Else
                                    dc.DataType = System.Type.GetType(arrStructure(1))
                                End If


                                hsLength.Add(arrStructure(0).ToString.ToLower, arrStructure(2))

                                If Not dt.Columns.Contains(arrStructure(0)) Then
                                    dt.Columns.Add(dc)
                                End If


                                intLinelength = intLinelength + VAL(arrStructure(2))
                            End If
                        End If
                        strtmp = sr.ReadLine
                    Loop



                    If Not dt.Columns.Contains("ROW_ID") Then
                        dc = New DataColumn()
                        dc.ColumnName = "ROW_ID"
                        dc.DataType = System.Type.GetType("System.Decimal")
                        dt.Columns.Add(dc)
                    End If

                    If IsQTP Then
                        If hsLength.Count Then
                            If m_BaseClass.Session("hsSubfileKeepText").Contains(Me.BaseName) Then
                                m_BaseClass.Session("hsSubfileKeepText").Item(Me.BaseName) = hsLength
                            Else
                                m_BaseClass.Session("hsSubfileKeepText").Add(Me.BaseName, hsLength)
                            End If
                        End If
                    End If

                    sr.Close()

                    If File.Exists(strFile) Then
                        Dim intRowid As Integer = 1
                        Dim arrlines As New List(Of String)
                        'strText = New StringBuilder("")
                        sr = New StreamReader(strFile)


                        Dim strtemp = sr.ReadLine()






                        Do While Not IsNothing(strtemp)

                            If strtemp.ToString.Replace(vbNullChar, "").Trim = "" Then
                                Exit Do
                            End If

                            strtemp = strtemp.PadRight(intLinelength)

                            If strtemp.Length = intLinelength Then

                                rw = dt.NewRow
                                intPlaceholder = 0

                                For i As Integer = 0 To dt.Columns.Count - 1

                                    If blnAllColumns OrElse arrColumns.Contains(dt.Columns(i).ColumnName.ToUpper) Then
                                        If dt.Columns(i).DataType.ToString = "System.Decimal" Then

                                            If hsColumns.Contains(dt.Columns(i).ColumnName.ToUpper) AndAlso hsColumns(dt.Columns(i).ColumnName.ToUpper).ToString.IndexOf("System.Zoned.Signed") >= 0 Then
                                                rw.Item(dt.Columns(i).ColumnName) = VAL(ConvertZoned(strtemp.Substring(intPlaceholder, hsLength(dt.Columns(i).ColumnName.ToLower)), True))
                                            ElseIf hsColumns.Contains(dt.Columns(i).ColumnName.ToUpper) AndAlso hsColumns(dt.Columns(i).ColumnName.ToUpper).ToString.IndexOf("System.Zoned.Unsigned") >= 0 Then
                                                rw.Item(dt.Columns(i).ColumnName) = VAL(ConvertZoned(strtemp.Substring(intPlaceholder, hsLength(dt.Columns(i).ColumnName.ToLower)), False))
                                            Else
                                                Try
                                                    rw.Item(dt.Columns(i).ColumnName) = VAL(strtemp.Substring(intPlaceholder, hsLength(dt.Columns(i).ColumnName.ToLower)))
                                                Catch ex As Exception
                                                    rw.Item(dt.Columns(i).ColumnName) = 0
                                                End Try
                                            End If


                                        ElseIf dt.Columns(i).DataType.ToString = "System.DateTime" Then

                                            Dim strDate As String = strtemp.Substring(intPlaceholder, hsLength(dt.Columns(i).ColumnName.ToLower))
                                            Dim dateTimeInfo As New DateTime
                                            If strDate.Trim.Length > 0 Then
                                                dateTimeInfo = New DateTime(VAL(strDate.Substring(0, 4)), VAL(strDate.Substring(4, 2)), VAL(strDate.Substring(6, 2)))
                                            End If

                                            rw.Item(dt.Columns(i).ColumnName.ToUpper) = dateTimeInfo

                                        Else
                                            rw.Item(dt.Columns(i).ColumnName.ToUpper) = strtemp.Substring(intPlaceholder, hsLength(dt.Columns(i).ColumnName.ToLower))
                                        End If
                                        Dim place As Int32 = hsLength(dt.Columns(i).ColumnName.ToLower)
                                        intPlaceholder = intPlaceholder + place
                                    End If
                                Next

                                rw.Item("ROW_ID") = intRowid
                                intRowid = intRowid + 1

                                dt.Rows.Add(rw)

                                strtemp = sr.ReadLine

                            Else
                                For i As Integer = 0 To strtemp.Length - 1 Step intLinelength
                                    arrlines.Add(strtemp.Substring(i, intLinelength))
                                Next


                                For Each strtmp In arrlines
                                    rw = dt.NewRow
                                    intPlaceholder = 0

                                    For i As Integer = 0 To dt.Columns.Count - 1

                                        If blnAllColumns OrElse arrColumns.Contains(dt.Columns(i).ColumnName.ToUpper) Then
                                            If dt.Columns(i).DataType.ToString = "System.Decimal" Then

                                                If hsColumns.Contains(dt.Columns(i).ColumnName.ToUpper) AndAlso hsColumns(dt.Columns(i).ColumnName.ToUpper).ToString.IndexOf("System.Zoned.Signed") >= 0 Then
                                                    rw.Item(dt.Columns(i).ColumnName) = VAL(ConvertZoned(strtmp.Substring(intPlaceholder, hsLength(dt.Columns(i).ColumnName.ToLower)), True))
                                                ElseIf hsColumns.Contains(dt.Columns(i).ColumnName.ToUpper) AndAlso hsColumns(dt.Columns(i).ColumnName.ToUpper).ToString.IndexOf("System.Zoned.Unsigned") >= 0 Then
                                                    rw.Item(dt.Columns(i).ColumnName) = VAL(ConvertZoned(strtmp.Substring(intPlaceholder, hsLength(dt.Columns(i).ColumnName.ToLower)), False))
                                                Else
                                                    rw.Item(dt.Columns(i).ColumnName) = VAL(strtmp.Substring(intPlaceholder, hsLength(dt.Columns(i).ColumnName.ToLower)))
                                                End If


                                            ElseIf dt.Columns(i).DataType.ToString = "System.DateTime" Then

                                                Dim strDate As String = strtmp.Substring(intPlaceholder, hsLength(dt.Columns(i).ColumnName.ToLower))
                                                Dim dateTimeInfo As New DateTime
                                                If strDate.Trim.Length > 0 Then
                                                    dateTimeInfo = New DateTime(VAL(strDate.Substring(0, 4)), VAL(strDate.Substring(4, 2)), VAL(strDate.Substring(6, 2)))
                                                End If

                                                rw.Item(dt.Columns(i).ColumnName.ToUpper) = dateTimeInfo

                                            Else
                                                rw.Item(dt.Columns(i).ColumnName.ToUpper) = strtmp.Substring(intPlaceholder, hsLength(dt.Columns(i).ColumnName.ToLower))
                                            End If
                                            intPlaceholder = intPlaceholder + hsLength(dt.Columns(i).ColumnName.ToLower)
                                        End If
                                    Next

                                    rw.Item("ROW_ID") = intRowid
                                    intRowid = intRowid + 1

                                    dt.Rows.Add(rw)
                                Next

                                Exit Do

                            End If




                        Loop

                        sr.Dispose()
                        sr = Nothing

                    End If
                End If

                Dim NewDataTable As DataTable = New DataTable(Me.BaseName)
                Dim PreDataTable As DataTable
                Dim OrderByClause As String = ""




                If Not IsNothing(m_Page) Then
                    If IsNothing(m_Page.Session("hsSubfile")) Then
                        m_Page.Session("hsSubfile") = New Hashtable
                    End If
                    m_Page.Session("hsSubfile").Item(Me.BaseName) = dt
                End If


                If WhereClause = "" Then
                    Return dt.Rows.Count
                Else

                    NewDataTable = dt.Clone
                    PreDataTable = dt.Copy


                    WhereClause = (WhereClause).ToUpper.Replace("WHERE ", "").Replace(Me.ElementOwner.ToUpper, "").Replace(
                  Me.BaseName & ".", "").Replace(" DBO.", " ").Replace("(DBO.", "(")
                    OrderByClause =
                        OrderByClause.ToUpper.Replace("ORDER BY ", "").Replace(Me.ElementOwner.ToUpper, "").Replace(
                            Me.BaseName & ".", "")

                    If OrderByClause.Length = 0 AndAlso m_IsSubFileKeep = 1 Then
                        OrderByClause = " ROW_ID "
                    End If

                    WhereClause = WhereClause.Replace("(CONVERT(INTEGER, CONVERT(CHAR(8),",
                                                      "( CONVERT(INTEGER, CONVERT(CHAR(8),")

                    Do While (WhereClause.IndexOf("CONVERT(INTEGER, CONVERT(CHAR(8),") >= 0)
                        Dim strColumn As String = String.Empty
                        Dim strReplace As String = String.Empty
                        Dim strOper As String = String.Empty
                        Dim strDate As String = String.Empty
                        Dim arrWhere() As String = WhereClause.Split(" ")

                        For i As Integer = 0 To arrWhere.Length - 1
                            If arrWhere(i) = "CONVERT(INTEGER," Then

                                strColumn = arrWhere(i + 2).Replace(",", "")
                                'Added IF Condition due to the Date value being before the CONVERT function.
                                If arrWhere.Length >= (i + 5) Then
                                    strOper = arrWhere(i + 4)
                                    strDate = arrWhere(i + 5)
                                    If strDate.Trim = "0" OrElse strDate.Trim = "0)" Then
                                        strDate = "'0001/01/01'"
                                        strReplace = arrWhere(i) & " " & arrWhere(i + 1) & " " & arrWhere(i + 2) & " " &
                                                     arrWhere(i + 3) & " " & arrWhere(i + 4) & " " &
                                                     arrWhere(i + 5).Substring(0, 1)
                                    Else
                                        strDate = "'" & strDate.Substring(0, 4) + "/" & strDate.Substring(4, 2) + "/" &
                                                  strDate.Substring(6, 2) & "'"
                                        strReplace = arrWhere(i) & " " & arrWhere(i + 1) & " " & arrWhere(i + 2) & " " &
                                                     arrWhere(i + 3) & " " & arrWhere(i + 4) & " " &
                                                     arrWhere(i + 5).Substring(0, 8)
                                    End If
                                    Exit For
                                Else
                                    'Added due to the Date value being before the CONVERT function.
                                    strOper = arrWhere(i - 1)
                                    strDate = arrWhere(i - 2)
                                    If strDate.Trim = "0" OrElse strDate.Trim = "(0" Then
                                        strDate = "'0001/01/01'"
                                        strReplace = arrWhere(i - 2) & " " & arrWhere(i - 1).Substring(0, 1) & " " &
                                                     arrWhere(i) & " " & arrWhere(i + 1) & " " & arrWhere(i + 2) & " " &
                                                     arrWhere(i + 3)
                                    Else
                                        strDate = "'" & strDate.Substring(0, 4) + "/" & strDate.Substring(4, 2) + "/" &
                                                  strDate.Substring(6, 2) & "'"
                                        strReplace = arrWhere(i - 2) & " " & arrWhere(i - 1).Substring(0, 8) & " " &
                                                     arrWhere(i) & " " & arrWhere(i + 1) & " " & arrWhere(i + 2) & " " &
                                                     arrWhere(i + 3)
                                    End If
                                    Exit For
                                End If
                            End If
                        Next

                        WhereClause = WhereClause.Replace(strReplace, strColumn & " " & strOper & " " & strDate)

                    Loop

                    Const cReplaceChar As String = Chr(30)
                    Do While (ReplaceSqlVerb(WhereClause, " BETWEEN ", "~CORE_BETWEEN~").IndexOf("~CORE_BETWEEN~") >= 0)

                        Dim strTable As String = ""
                        Dim strValue As String = ""
                        Dim strReplace As String = ""
                        Dim strReplaceWith As String = ""
                        Dim arrWhere() As String =
                                ReplaceSqlVerb(WhereClause, " AND ", cReplaceChar).Split(CType(cReplaceChar, String))

                        For i As Integer = 0 To arrWhere.Length - 1
                            If ReplaceSqlVerb(arrWhere(i), " BETWEEN ", "~CORE_BETWEEN~").IndexOf("~CORE_BETWEEN~") >= 0 _
                                Then
                                strReplace = arrWhere(i) & " AND " & arrWhere(i + 1)
                                strTable = arrWhere(i).Substring(0, arrWhere(i).IndexOf(" BETWEEN ")).Trim
                                strValue = arrWhere(i).Substring(arrWhere(i).IndexOf(" BETWEEN ") + 9).Trim
                                strReplaceWith = strTable & " >= " & strValue & " AND " & strTable & " <= " &
                                                 arrWhere(i + 1).Trim
                                WhereClause = WhereClause.Replace(strReplace, strReplaceWith)
                            End If

                        Next

                    Loop

                    WhereClause = WhereClause.Replace("SEQUENTIAL.", "")

                    Dim tmpDataRow As DataRow() = PreDataTable.Select(WhereClause, OrderByClause)



                    For i As Integer = 0 To tmpDataRow.Length - 1
                        NewDataTable.Rows.Add(tmpDataRow(i).ItemArray)
                    Next



                    Return NewDataTable.Rows.Count

                End If



            Catch ex As Exception
                Dim e As New Exception("The subfile " + Me.BaseName + " does not exist!")
                Throw e
            End Try

        End Function

        ''' --- GetTextTable ---------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetTextTable.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overrides Function GetTextTable(ByVal strSelect As String) As DataTable

            Dim strFilePath As String = ""
            Dim strFileColumn As String = ""

            Dim strFile As String = String.Empty
            Dim sr As StreamReader
            Dim dt As New DataTable
            Dim dtTemp As New DataTable
            Dim strText As StringBuilder = New StringBuilder("")
            Dim arrStructure() As String
            Dim intPlaceholder As Integer = 0
            Dim intLinelength As Integer = 0
            Dim hsLength As New Hashtable
            Dim hsColumns As New Hashtable
            Dim strTextName As String = String.Empty
            Dim strName As String = String.Empty
            Dim dc As DataColumn
            Dim rw As DataRow
            Dim blnAllColumns As Boolean = True
            Dim arrColumns As New ArrayList

            Try

               

                If Not blnAllColumns Then
                    strSelect = strSelect.ToUpper
                    strSelect = strSelect.Substring(0, strSelect.IndexOf("FROM"))
                    strSelect = strSelect.Replace("SELECT", "").Trim

                    For i As Integer = 0 To strSelect.Split(",").Length - 1
                        arrColumns.Add(strSelect.Split(",")(i).ToUpper.Trim)
                    Next
                End If

                If IsQTP Then
                    If IsNothing(Me.m_BaseClass.Session("strSubFileName")) Then
                        strTextName = Me.BaseName
                    Else
                        strTextName = Me.m_BaseClass.Session("strSubFileName").ToString
                        If strTextName.IndexOf(".") >= 0 Then
                            strName = strTextName.Substring(0, strTextName.IndexOf("."))
                            strTextName = strTextName.Substring(strTextName.IndexOf(".") + 1)
                            strTextName = strTextName.Replace(".", "\") & "\" & strName
                        End If
                    End If

                    If Owner = "SEQUENTIAL" Then
                        strTextName = strTextName + ".dat"
                    Else
                        If IsPortableSubFile Then
                            strTextName = strTextName + ".ps"
                        Else
                            strTextName = strTextName + ".sf"
                        End If
                    End If


                Else
                    Try
                        strTextName = Me.BaseName

                        If strTextName.IndexOf(".") >= 0 Then
                            strName = strTextName.Substring(0, strTextName.IndexOf("."))
                            strTextName = strTextName.Substring(strTextName.IndexOf(".") + 1)
                            strTextName = strTextName.Replace(".", "\") & "\" & strName
                        End If
                    Catch ex As Exception
                        strTextName = Me.BaseName
                    End Try

                End If

                If IsQTP Then
                    strFilePath = Directory.GetCurrentDirectory()
                Else
                    strFilePath = Environment.GetEnvironmentVariable("CurrentDirectory", EnvironmentVariableTarget.Process)
                    strFilePath = strFilePath.Replace(vbCr, "\r")
                End If

                If strFilePath.EndsWith("\") Then
                    strFile = strFilePath & strTextName
                Else
                    strFile = strFilePath & "\" & strTextName
                End If

                If Not File.Exists(strFile) Then
                    If IsNothing(m_BaseClass) Then
                        'strFilePath = System.Configuration.ConfigurationManager.AppSettings("FlatFilePath") & "\" & m_Page.Session("m_strUser") & "_" & m_Page.Session("m_strSessionID")
                    Else
                        'strFilePath = System.Configuration.ConfigurationManager.AppSettings("FlatFilePath") & "\" & m_BaseClass.Session("m_strUser") & "_" & m_BaseClass.Session("m_strSessionID")
                    End If
                    If strFile.EndsWith("\") Then
                        strFile = strFilePath & strTextName
                    Else
                        strFile = strFilePath & "\" & strTextName
                    End If
                End If

                If Not File.Exists(strFile) Then
                    strFile = strFile.Replace(".sf", ".ps")
                End If

                strFileColumn = strFilePath

                If Owner = "SEQUENTIAL" Then
                    If strFileColumn.EndsWith("\") Then
                        strFileColumn = System.Configuration.ConfigurationManager.AppSettings("FlatFileDictionary") & Me.BaseName & ".dfd"
                    Else
                        strFileColumn = System.Configuration.ConfigurationManager.AppSettings("FlatFileDictionary") & "\" & Me.BaseName & ".dfd"
                    End If

                    If Not strFile.EndsWith(".dat") Then
                        strFile = strFile + ".dat"
                    End If
                Else
                    If IsPortableSubFile Then

                        If strFileColumn.EndsWith("\") Then
                            strFileColumn = strFilePath & Me.BaseName & ".psd"
                        Else
                            strFileColumn = strFilePath & "\" & Me.BaseName & ".psd"
                        End If
                    Else
                        If strFileColumn.EndsWith("\") Then
                            strFileColumn = strFilePath & Me.BaseName & ".sfd"
                        Else
                            strFileColumn = strFilePath & "\" & Me.BaseName & ".sfd"
                        End If
                    End If
                End If


                If Not File.Exists(strFileColumn) Then
                    strFileColumn = strFileColumn.Replace(".sfd", ".psd")
                End If

                sr = New StreamReader(strFileColumn)

                If IsNothing(m_BaseClass) Then
                    If Not m_Page.hsSubConverted.Contains(Me.BaseName) Then
                        m_Page.hsSubConverted.Add(Me.BaseName, Me.BaseName)
                    End If
                Else
                    If Not m_BaseClass.hsSubConverted.Contains(Me.BaseName) Then
                        m_BaseClass.hsSubConverted.Add(Me.BaseName, Me.BaseName)
                    End If
                End If


                Dim strtmp As String
                strtmp = sr.ReadLine

                Do While Not IsNothing(strtmp)
                    If (strtmp.Trim.Length > 0) Then

                        arrStructure = strtmp.Split(",")

                        If blnAllColumns OrElse arrColumns.Contains(arrStructure(0).ToUpper) Then
                            dc = New DataColumn()
                            dc.ColumnName = arrStructure(0)

                            hsColumns.Add(arrStructure(0), arrStructure(1))

                            If arrStructure(1).LastIndexOf("System.Zoned") >= 0 Then
                                dc.DataType = System.Type.GetType("System.Decimal")
                            Else
                                dc.DataType = System.Type.GetType(arrStructure(1))
                            End If


                            hsLength.Add(arrStructure(0).ToString.ToLower, arrStructure(2))

                            dt.Columns.Add(dc)

                            intLinelength = intLinelength + VAL(arrStructure(2))
                        End If
                    End If
                    strtmp = sr.ReadLine
                Loop



                If Not dt.Columns.Contains("ROW_ID") Then
                    dc = New DataColumn()
                    dc.ColumnName = "ROW_ID"
                    dc.DataType = System.Type.GetType("System.Decimal")
                    dt.Columns.Add(dc)
                End If

                If IsQTP Then
                    If hsLength.Count Then
                        If m_BaseClass.Session("hsSubfileKeepText").Contains(Me.BaseName) Then
                            m_BaseClass.Session("hsSubfileKeepText").Item(Me.BaseName) = hsLength
                        Else
                            m_BaseClass.Session("hsSubfileKeepText").Add(Me.BaseName, hsLength)
                        End If
                    End If
                End If

                sr.Close()

                If File.Exists(strFile) Then
                    Dim intRowid As Integer = 1
                    Dim arrlines As New List(Of String)
                    'strText = New StringBuilder("")
                    sr = New StreamReader(strFile)

                    'If strFileColumn.EndsWith(".psd") Then
                    '    arrlines = sr.ReadToEnd.Split(vbNewLine).ToList

                    '    sr.Close()
                    '    sr.Dispose()
                    '    sr = Nothing
                    '    GC.Collect()

                    'Else

                    '    strText.Append(sr.ReadLine)

                    '    sr.Close()
                    '    sr.Dispose()
                    '    sr = Nothing
                    '    GC.Collect()

                    '    For i As Integer = 0 To strText.Length - 1 Step intLinelength
                    '        arrlines.Add(strText.ToString().Substring(i, intLinelength))
                    '    Next

                    'End If

                    Dim strtemp = sr.ReadLine()


                    'For Each strtmp In arrlines
                    '    rw = dt.NewRow
                    '    intPlaceholder = 0

                    '    For i As Integer = 0 To dt.Columns.Count - 1

                    '        If blnAllColumns OrElse arrColumns.Contains(dt.Columns(i).ColumnName.ToUpper) Then
                    '            If dt.Columns(i).DataType.ToString = "System.Decimal" Then

                    '                If hsColumns.Contains(dt.Columns(i).ColumnName.ToUpper) AndAlso hsColumns(dt.Columns(i).ColumnName.ToUpper).ToString.IndexOf("System.Zoned.Signed") >= 0 Then
                    '                    rw.Item(dt.Columns(i).ColumnName) = VAL(ConvertZoned(strtmp.Substring(intPlaceholder, hsLength(dt.Columns(i).ColumnName.ToLower)), True))
                    '                ElseIf hsColumns.Contains(dt.Columns(i).ColumnName.ToUpper) AndAlso hsColumns(dt.Columns(i).ColumnName.ToUpper).ToString.IndexOf("System.Zoned.Unsigned") >= 0 Then
                    '                    rw.Item(dt.Columns(i).ColumnName) = VAL(ConvertZoned(strtmp.Substring(intPlaceholder, hsLength(dt.Columns(i).ColumnName.ToLower)), False))
                    '                Else
                    '                    rw.Item(dt.Columns(i).ColumnName) = VAL(strtmp.Substring(intPlaceholder, hsLength(dt.Columns(i).ColumnName.ToLower)))
                    '                End If


                    '            ElseIf dt.Columns(i).DataType.ToString = "System.DateTime" Then

                    '                Dim strDate As String = strtmp.Substring(intPlaceholder, hsLength(dt.Columns(i).ColumnName.ToLower))
                    '                Dim dateTimeInfo As New DateTime
                    '                If strDate.Trim.Length > 0 Then
                    '                    dateTimeInfo = New DateTime(VAL(strDate.Substring(0, 4)), VAL(strDate.Substring(4, 2)), VAL(strDate.Substring(6, 2)))
                    '                End If

                    '                rw.Item(dt.Columns(i).ColumnName.ToUpper) = dateTimeInfo

                    '            Else
                    '                rw.Item(dt.Columns(i).ColumnName.ToUpper) = strtmp.Substring(intPlaceholder, hsLength(dt.Columns(i).ColumnName.ToLower))
                    '            End If
                    '            intPlaceholder = intPlaceholder + hsLength(dt.Columns(i).ColumnName.ToLower)
                    '        End If
                    '    Next

                    '    rw.Item("ROW_ID") = intRowid
                    '    intRowid = intRowid + 1

                    '    dt.Rows.Add(rw)
                    'Next



                    Do While Not IsNothing(strtemp)

                        strtemp = strtemp.PadRight(intLinelength)

                        If strtemp.Length = intLinelength Then

                            rw = dt.NewRow
                            intPlaceholder = 0

                            For i As Integer = 0 To dt.Columns.Count - 1

                                If blnAllColumns OrElse arrColumns.Contains(dt.Columns(i).ColumnName.ToUpper) Then
                                    If dt.Columns(i).DataType.ToString = "System.Decimal" Then

                                        If hsColumns.Contains(dt.Columns(i).ColumnName.ToUpper) AndAlso hsColumns(dt.Columns(i).ColumnName.ToUpper).ToString.IndexOf("System.Zoned.Signed") >= 0 Then
                                            rw.Item(dt.Columns(i).ColumnName) = VAL(ConvertZoned(strtemp.Substring(intPlaceholder, hsLength(dt.Columns(i).ColumnName.ToLower)), True))
                                        ElseIf hsColumns.Contains(dt.Columns(i).ColumnName.ToUpper) AndAlso hsColumns(dt.Columns(i).ColumnName.ToUpper).ToString.IndexOf("System.Zoned.Unsigned") >= 0 Then
                                            rw.Item(dt.Columns(i).ColumnName) = VAL(ConvertZoned(strtemp.Substring(intPlaceholder, hsLength(dt.Columns(i).ColumnName.ToLower)), False))
                                        Else
                                            Try
                                                rw.Item(dt.Columns(i).ColumnName) = VAL(strtemp.Substring(intPlaceholder, hsLength(dt.Columns(i).ColumnName.ToLower)))
                                            Catch ex As Exception
                                                rw.Item(dt.Columns(i).ColumnName) = 0
                                            End Try

                                        End If


                                    ElseIf dt.Columns(i).DataType.ToString = "System.DateTime" Then

                                        Dim strDate As String = strtemp.Substring(intPlaceholder, hsLength(dt.Columns(i).ColumnName.ToLower))
                                        Dim dateTimeInfo As New DateTime
                                        If strDate.Trim.Length > 0 Then
                                            dateTimeInfo = New DateTime(VAL(strDate.Substring(0, 4)), VAL(strDate.Substring(4, 2)), VAL(strDate.Substring(6, 2)))
                                        End If

                                        rw.Item(dt.Columns(i).ColumnName.ToUpper) = dateTimeInfo

                                    Else
                                        rw.Item(dt.Columns(i).ColumnName.ToUpper) = strtemp.Substring(intPlaceholder, hsLength(dt.Columns(i).ColumnName.ToLower))
                                    End If
                                    intPlaceholder = intPlaceholder + hsLength(dt.Columns(i).ColumnName.ToLower)
                                End If
                            Next

                            rw.Item("ROW_ID") = intRowid
                            intRowid = intRowid + 1

                            dt.Rows.Add(rw)

                            strtemp = sr.ReadLine

                        Else
                            For i As Integer = 0 To strtemp.Length - 1 Step intLinelength
                                If strtemp.ToString.Replace(vbNullChar, " ").Trim = "" Then
                                    Exit For
                                End If
                                arrlines.Add(strtemp.ToString.Replace(vbNullChar, " ").Substring(i, intLinelength))
                            Next


                            For Each strtmp In arrlines
                                rw = dt.NewRow
                                intPlaceholder = 0

                                For i As Integer = 0 To dt.Columns.Count - 1

                                    If blnAllColumns OrElse arrColumns.Contains(dt.Columns(i).ColumnName.ToUpper) Then
                                        If dt.Columns(i).DataType.ToString = "System.Decimal" Then

                                            If hsColumns.Contains(dt.Columns(i).ColumnName.ToUpper) AndAlso hsColumns(dt.Columns(i).ColumnName.ToUpper).ToString.IndexOf("System.Zoned.Signed") >= 0 Then
                                                rw.Item(dt.Columns(i).ColumnName) = VAL(ConvertZoned(strtmp.Substring(intPlaceholder, hsLength(dt.Columns(i).ColumnName.ToLower)), True))
                                            ElseIf hsColumns.Contains(dt.Columns(i).ColumnName.ToUpper) AndAlso hsColumns(dt.Columns(i).ColumnName.ToUpper).ToString.IndexOf("System.Zoned.Unsigned") >= 0 Then
                                                rw.Item(dt.Columns(i).ColumnName) = VAL(ConvertZoned(strtmp.Substring(intPlaceholder, hsLength(dt.Columns(i).ColumnName.ToLower)), False))
                                            Else
                                                rw.Item(dt.Columns(i).ColumnName) = VAL(strtmp.Substring(intPlaceholder, hsLength(dt.Columns(i).ColumnName.ToLower)))
                                            End If


                                        ElseIf dt.Columns(i).DataType.ToString = "System.DateTime" Then

                                            Dim strDate As String = strtmp.Substring(intPlaceholder, hsLength(dt.Columns(i).ColumnName.ToLower))
                                            Dim dateTimeInfo As New DateTime
                                            If strDate.Trim.Length > 0 Then
                                                dateTimeInfo = New DateTime(VAL(strDate.Substring(0, 4)), VAL(strDate.Substring(4, 2)), VAL(strDate.Substring(6, 2)))
                                            End If

                                            rw.Item(dt.Columns(i).ColumnName.ToUpper) = dateTimeInfo

                                        Else
                                            rw.Item(dt.Columns(i).ColumnName.ToUpper) = strtmp.Substring(intPlaceholder, hsLength(dt.Columns(i).ColumnName.ToLower))
                                        End If
                                        intPlaceholder = intPlaceholder + hsLength(dt.Columns(i).ColumnName.ToLower)
                                    End If
                                Next

                                rw.Item("ROW_ID") = intRowid
                                intRowid = intRowid + 1

                                dt.Rows.Add(rw)
                            Next

                            Exit Do

                        End If




                    Loop

                    sr.Dispose()
                    sr = Nothing

                End If

                Return dt

            Catch ex As Exception
                Dim e As New Exception("The subfile " + Me.BaseName + " does not exist!")
                Throw e
            End Try

        End Function


        Private Function ConvertZoned(value As String, Optional signed As Boolean = False) As Decimal
            Try
                Dim result As Integer
                If value.Trim() <> "" Then
                    result = Integer.Parse(value.Substring(value.Length - 1, 1))
                End If
                signed = False
            Catch
                signed = True
            End Try

            If signed Then
                If value.Trim() = "" Then
                    value = "0"
                End If
                Dim overpunchDigit As Integer = GetOverpunchDigit(value.Substring(value.Length - 1, 1))
                Dim isPositive As Boolean = GetOverpunchSign(value.Substring(value.Length - 1, 1))

                If value = "0" Then
                    Return 0
                End If


                If isPositive Then
                    Return Convert.ToDecimal(value.Substring(0, value.Length - 1).ToString() + overpunchDigit.ToString())
                Else
                    Return Convert.ToDecimal(value.Substring(0, value.Length - 1).ToString() + overpunchDigit.ToString()) * -1
                End If
            Else
                If Not IsNumeric(value) Then
                    If value.Trim = "" Then
                        Return Convert.ToDecimal(0)
                    End If
                    Dim decimalValue As Decimal = 0
                    For i As Integer = 0 To value.Length - 1
                        If Convert.ToInt32(value.Substring(i, 1)) <> 0 AndAlso Convert.ToInt32(value.Substring(i, 1)) <> 32 Then
                            decimalValue = Convert.ToDecimal(value)
                        End If
                    Next

                    Return decimalValue
                Else
                    Return Convert.ToDecimal(value)
                End If
            End If
        End Function


        Private Function GetOverpunchDigit(value As String) As Integer

            Select Case value
                Case "{", "p"
                    Return 0
                Case "A", "q"
                    Return 1
                Case "B", "r"
                    Return 2
                Case "C", "s"
                    Return 3
                Case "D", "t"
                    Return 4
                Case "E", "u"
                    Return 5
                Case "F", "v"
                    Return 6
                Case "G", "w"
                    Return 7
                Case "H", "x"
                    Return 8
                Case "I", "y"
                    Return 9
                Case "}"
                    Return 0
                Case "J"
                    Return 1
                Case "K"
                    Return 2
                Case "L"
                    Return 3
                Case "M"
                    Return 4
                Case "N"
                    Return 5
                Case "O"
                    Return 6
                Case "P"
                    Return 7
                Case "Q"
                    Return 8
                Case "R"
                    Return 9
                Case Else
                    Return 0
            End Select
        End Function

        Private Function GetOverpunchSign(value As String) As Boolean
            Select Case value
                Case "{"
                    Return True
                Case "A"
                    Return True
                Case "B"
                    Return True
                Case "C"
                    Return True
                Case "D"
                    Return True
                Case "E"
                    Return True
                Case "F"
                    Return True
                Case "G"
                    Return True
                Case "H"
                    Return True
                Case "I"
                    Return True
                Case "}"
                    Return False
                Case "J"
                    Return False
                Case "K"
                    Return False
                Case "L"
                    Return False
                Case "M"
                    Return False
                Case "N"
                    Return False
                Case "O"
                    Return False
                Case "P"
                    Return False
                Case "Q"
                    Return False
                Case "R"
                    Return False
                Case Else
                    Return False
            End Select
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
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
                'Core.Windows.UI.SessionInformation.Remove(FileName)
            End If

            If Not IsNothing(m_dtbDataTable) Then
                For i As Integer = 0 To m_dtbDataTable.Rows.Count - 1
                    m_dtbDataTable.Rows.Remove(m_dtbDataTable.Rows.Item(i))
                Next
            End If

        End Function

        ''' --- PutDataTextTable ---------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of PutDataTextTable.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overrides Function PutDataTextTable(Optional ByVal At As Integer = -1) As Boolean

            Dim strFilePath As String

            If Not IsQTP Then
                strFilePath = Environment.GetEnvironmentVariable("CurrentDirectory", EnvironmentVariableTarget.Process)
                strFilePath = strFilePath.Replace(vbCr, "\r")
            Else
                strFilePath = Directory.GetCurrentDirectory()
            End If

            Dim strFileColumn As String = strFilePath
            If Owner = "SEQUENTIAL" Then
                If strFileColumn.EndsWith("\") Then
                    strFileColumn = System.Configuration.ConfigurationManager.AppSettings("FlatFileDictionary") & Me.BaseName & ".dfd"
                Else
                    strFileColumn = System.Configuration.ConfigurationManager.AppSettings("FlatFileDictionary") & "\" & Me.BaseName & ".dfd"
                End If
            ElseIf IsPortableSubFile Then
                If strFileColumn.EndsWith("\") Then
                    strFileColumn = strFilePath & Me.BaseName & ".psd"
                Else
                    strFileColumn = strFilePath & "\" & Me.BaseName & ".psd"
                End If
            Else
                If strFileColumn.EndsWith("\") Then
                    strFileColumn = strFilePath & Me.BaseName & ".sfd"
                Else
                    strFileColumn = strFilePath & "\" & Me.BaseName & ".sfd"
                End If
            End If



            Dim strFile As String = String.Empty
            Dim sr As New StreamReader(strFileColumn)
            Dim strText As String = String.Empty
            Dim strTextName As String = String.Empty
            Dim strFileText As New StringBuilder("")
            Dim arrLength As New ArrayList
            Dim intRowcount As Integer = 0
            Dim sw As StreamWriter
            Dim strName As String = String.Empty

            Try


                If IsQTP Then

                    Dim arrdatfiles As ArrayList

                    arrdatfiles = m_BaseClass.Session("DatFiles")
                    If IsNothing(arrdatfiles) Then
                        arrdatfiles = New ArrayList
                        arrdatfiles.Add(Me.BaseName)
                        m_BaseClass.Session("DatFiles") = arrdatfiles
                    ElseIf Not arrdatfiles.Contains(Me.BaseName) Then
                        arrdatfiles.Add(Me.BaseName)
                        m_BaseClass.Session("DatFiles") = arrdatfiles
                    End If

                    Dim PassLog As LogType = LogType.Updated
                    strName = Me.BaseName

                    If m_blnDeletedRecord(Me.CurrentRow) Then
                        PassLog = LogType.Deleted
                    Else
                        If m_blnNewRecord(Me.CurrentRow) Then
                            PassLog = LogType.Added
                        End If
                    End If
                    QTPRecordsRead(Me.BaseName, Me.AliasName, 1, PassLog)

                    If IsNothing(Me.m_BaseClass.Session("strSubFileName")) Then
                        strTextName = Me.BaseName
                    Else
                        strTextName = Me.m_BaseClass.Session("strSubFileName").ToString
                        If strTextName.IndexOf(".") >= 0 Then
                            strName = strTextName.Substring(0, strTextName.IndexOf("."))
                            strTextName = strTextName.Substring(strTextName.IndexOf(".") + 1)
                            strTextName = strTextName.Replace(".", "\") & "\" & strName
                        End If
                    End If

                    If Owner = "SEQUENTIAL" Then
                        strTextName = strTextName + ".dat"
                    ElseIf IsPortableSubFile Then
                        strTextName = strTextName + ".ps"
                    Else
                        strTextName = strTextName + ".sf"
                    End If


                    If Not m_BaseClass.alSubTempText.Contains(strTextName) Then
                        m_BaseClass.alSubTempText.Add(strTextName)
                    End If
                Else
                    Try

                        strTextName = Me.BaseName

                        If strTextName.IndexOf(".") >= 0 Then
                            strName = strTextName.Substring(0, strTextName.IndexOf("."))
                            strTextName = strTextName.Substring(strTextName.IndexOf(".") + 1)
                        End If

                        If Owner = "SEQUENTIAL" Then
                            strTextName = strTextName + ".dat"
                        ElseIf IsPortableSubFile Then
                            strTextName = strTextName + ".ps"
                        Else
                            strTextName = strTextName + ".sf"
                        End If


                    Catch ex As Exception
                        If Owner = "SEQUENTIAL" Then
                            strTextName = strTextName + ".dat"
                        ElseIf IsPortableSubFile Then
                            strTextName = strTextName + ".ps"
                        Else
                            strTextName = strTextName + ".sf"
                        End If

                    End Try

                End If

                If strFile.EndsWith("\") Then
                    strFile = strFilePath & strTextName
                Else
                    strFile = strFilePath & "\" & strTextName
                End If




                If (IsNothing(tmpDataTable) AndAlso Not m_blnDeletedRecord(Me.CurrentRow)) Then

                    Dim dt As DataTable = New DataTable

                    If Not IsNothing(m_BaseClass) Then

                        If m_BaseClass.Session("hsSubfile").Contains(Me.BaseName) Then
                            dt = m_BaseClass.Session("hsSubfile").Item(Me.BaseName)
                            dt.Rows.Add(m_dtbDataTable.Rows(0).ItemArray)
                            m_BaseClass.Session("hsSubfile").Item(Me.BaseName) = dt
                        Else
                            dt = m_dtbDataTable.Clone()
                            dt.Rows.Add(m_dtbDataTable.Rows(0).ItemArray)
                            m_BaseClass.Session("hsSubfile").Add(Me.BaseName, dt)
                        End If

                        If File.Exists(strFile) Then
                            File.Delete(strFile)
                        End If

                        sr.Close()
                        sr.Dispose()

                        Exit Function
                    Else
                        If m_Page.Session("hsSubfile").Contains(Me.BaseName) Then
                            dt = m_Page.Session("hsSubfile").Item(Me.BaseName)
                            dt.Rows.Add(m_dtbDataTable.Rows(0).ItemArray)
                            m_Page.Session("hsSubfile").Item(Me.BaseName) = dt
                        Else
                            dt = m_dtbDataTable.Clone()
                            dt.Rows.Add(m_dtbDataTable.Rows(0).ItemArray)
                            m_Page.Session("hsSubfile").Add(Me.BaseName, dt)
                        End If

                        If File.Exists(strFile) Then
                            File.Delete(strFile)
                        End If
                        tmpDataTable = dt

                    End If




                ElseIf (Not IsNothing(tmpDataTable) AndAlso tmpDataTable.Rows.Count >= m_dtbDataTable.Rows.Count) Then

                    If m_blnNewRecord(Me.CurrentRow) Then
                        tmpDataTable.Rows.Add(m_dtbDataTable.Rows(Me.CurrentRow).ItemArray)
                    ElseIf m_blnDeletedRecord(Me.CurrentRow) Then
                        Dim dr As DataRow = (tmpDataTable.Select("ROW_ID = " + m_dtbDataTable.Rows(Me.CurrentRow)("ROW_ID").ToString))(0)
                        dr.Delete()
                        tmpDataTable.AcceptChanges()
                    ElseIf AlteredRecord(Me.CurrentRow) Then

                        Dim dr As DataRow = (tmpDataTable.Select("ROW_ID = " + m_dtbDataTable.Rows(Me.CurrentRow)("ROW_ID").ToString))(0)

                            For i As Integer = 0 To m_dtbDataTable.Columns.Count - 1
                                dr(i) = m_dtbDataTable.Rows(Me.CurrentRow)(i)
                            Next

                            dr.AcceptChanges()
                        End If

                        If IsNothing(m_BaseClass) Then
                            If m_Page.Session("hsSubfile").Contains(Me.BaseName) Then
                                m_Page.Session("hsSubfile")(Me.BaseName) = tmpDataTable
                            Else
                                m_Page.Session("hsSubfile").Add(Me.BaseName, tmpDataTable)
                            End If
                        Else
                            If m_BaseClass.Session("hsSubfile").Contains(Me.BaseName) Then
                                m_BaseClass.Session("hsSubfile")(Me.BaseName) = tmpDataTable
                            Else
                                m_BaseClass.Session("hsSubfile").Add(Me.BaseName, tmpDataTable)
                            End If
                        End If


                    If File.Exists(strFile) Then
                        File.Delete(strFile)
                    End If

                    'Exit Function
                End If

                strText = sr.ReadLine

                Do While Not IsNothing(strText)
                    arrLength.Add(strText.Split(",")(2))

                    strText = sr.ReadLine
                Loop

                sr.Close()


                Dim aFileInfo As New System.IO.FileInfo(strFile)
                If File.Exists(strFile) Then


                    If aFileInfo.Attributes And FileAttributes.ReadOnly Then

                        If m_blnDidLock = True Then
                            aFileInfo.Attributes -= FileAttributes.ReadOnly
                        Else
                            Err.Raise("This File is Locked!")
                            Return False
                        End If

                    End If

                    aFileInfo = Nothing
                End If


                If IsQTP Then
                    'If Not m_BaseClass.Session(m_BaseClass.UniqueSessionID + "hsSubfile").Contains(strName) Then
                    '    m_BaseClass.Session(m_BaseClass.UniqueSessionID + "hsSubfile").Add(strName, m_dtbDataTable)
                    'Else
                    '    m_BaseClass.Session(m_BaseClass.UniqueSessionID + "hsSubfile").Item(strName) = m_dtbDataTable
                    'End If




                    'For i As Integer = 0 To m_dtbDataTable.Rows.Count - 1

                    '    If strFileText.ToString.Length > 0 Then strFileText.Append(LineTerminator)

                    '    For j As Integer = 0 To m_dtbDataTable.Columns.Count - 1

                    '        If m_dtbDataTable.Columns(j).ColumnName.ToUpper <> "ROW_ID" AndAlso m_dtbDataTable.Columns(j).ColumnName.ToUpper <> "CHECKSUM_VALUE" AndAlso m_dtbDataTable.Columns(j).ColumnName.ToUpper <> Me.RecordIdentifier Then

                    '            If m_dtbDataTable.Columns(j).DataType.ToString = "System.Decimal" Then
                    '                strFileText.Append(m_dtbDataTable.Rows(i)(j).ToString.PadLeft(arrLength(j)))
                    '            Else
                    '                strFileText.Append(m_dtbDataTable.Rows(i)(j).ToString.PadRight(arrLength(j)))
                    '            End If
                    '        End If
                    '    Next

                    '    intRowcount = intRowcount + 1

                    '    If intRowcount = 200 Then
                    '        intRowcount = 0

                    '        If strFileText.ToString.Length > 0 Then
                    '            sw = New StreamWriter(strFile)
                    '            sw.Write(strFileText.ToString)
                    '            sw.Close()
                    '            sw.Dispose()
                    '            strFileText.Remove(0, strFileText.Length)
                    '        End If
                    '    End If
                    'Next
                Else
                    sw = New StreamWriter(strFile, True)

                    For i As Integer = 0 To tmpDataTable.Rows.Count - 1

                        If strFileText.ToString.Length > 0 Then strFileText.Append(LineTerminator)

                        For j As Integer = 0 To tmpDataTable.Columns.Count - 1

                            If tmpDataTable.Columns(j).ColumnName.ToUpper <> "ROW_ID" AndAlso tmpDataTable.Columns(j).ColumnName.ToUpper <> "CHECKSUM_VALUE" AndAlso tmpDataTable.Columns(j).ColumnName.ToUpper <> Me.RecordIdentifier Then

                                If tmpDataTable.Columns(j).DataType.ToString = "System.Decimal" Then
                                    strFileText.Append(tmpDataTable.Rows(i)(j).ToString.PadLeft(arrLength(j)))
                                Else
                                    strFileText.Append(tmpDataTable.Rows(i)(j).ToString.PadRight(arrLength(j)))
                                End If
                            End If
                        Next

                        sw.WriteLine(strFileText.ToString)
                        strFileText.Remove(0, strFileText.Length)

                    Next
                    sw.Close()
                    sw.Dispose()
                End If





                aFileInfo = New System.IO.FileInfo(strFile)


                If m_blnDidLock AndAlso aFileInfo.Attributes Then

                    aFileInfo.Attributes = aFileInfo.Attributes Or FileAttributes.ReadOnly

                End If

                aFileInfo = Nothing

            Catch ex As Exception

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
            Dim blnUsem_dtbQTPTempDataTable As Boolean = False


            If IsQTP Then

                Dim arrdatfiles As ArrayList

                arrdatfiles = m_BaseClass.Session("TempFiles")
                If IsNothing(arrdatfiles) Then
                    arrdatfiles = New ArrayList
                    arrdatfiles.Add(Me.BaseName)
                    m_BaseClass.Session("TempFiles") = arrdatfiles
                ElseIf Not arrdatfiles.Contains(Me.BaseName) Then
                    arrdatfiles.Add(Me.BaseName)
                    m_BaseClass.Session("TempFiles") = arrdatfiles
                End If

                If IsNothing(m_dtbQTPTempDataTable) Then
                    If m_BaseClass.Session("hsSubfile").Contains(Me.BaseName) Then
                        SessionTable = m_BaseClass.Session("hsSubfile").Item(Me.BaseName)

                        If IsNothing(SessionTable) Then
                            SessionTable = GetTextTable("")
                        End If

                    End If

                ElseIf m_BaseClass.blnHasRunSubfile AndAlso m_BaseClass.Session("hsSubfile").Contains(Me.BaseName) Then
                    SessionTable = m_BaseClass.Session("hsSubfile").Item(Me.BaseName)
                Else
                    blnUsem_dtbQTPTempDataTable = True
                End If
            Else
                If (Core.Windows.UI.ApplicationState.Current.TempTable.ContainsKey(BaseName)) Then
                    SessionTable = Core.Windows.UI.ApplicationState.Current.TempTable.Item(BaseName)
                End If
            End If


            If blnUsem_dtbQTPTempDataTable Then

                ' Perform the appropriate action based on the status flags.
                If m_blnDeletedRecord(Me.CurrentRow) Then

                    ' Only delete if the session table exists.
                    If Not m_dtbQTPTempDataTable Is Nothing Then
                        If m_dtbQTPTempDataTable.Select("ROW_ID = '" & m_dtbDataTable.Rows(Me.CurrentRow).Item("ROW_ID") & "' AND CHECKSUM_VALUE = " & m_dtbDataTable.Rows(Me.CurrentRow).Item("CHECKSUM_VALUE")).Length = 1 Then
                            m_dtbQTPTempDataTable.Select("ROW_ID = '" & m_dtbDataTable.Rows(Me.CurrentRow).Item("ROW_ID") & "' AND CHECKSUM_VALUE = " & m_dtbDataTable.Rows(Me.CurrentRow).Item("CHECKSUM_VALUE"))(0).Delete()
                        Else
                            AddMessage("Cannot update table <{0}>, data has been changed.", MessageTypes.Error, m_strBaseName) 'IM.DataChangedDB
                        End If
                    End If

                Else


                    ' Check if a new record or a record being updated.
                    If m_dtbDataTable.Rows(Me.CurrentRow).Item("ROW_ID").ToString.TrimEnd.Equals(String.Empty) OrElse NewRecord Then
                        PassLog = LogType.Added
                        If m_dtbQTPTempDataTable Is Nothing Then
                            m_dtbQTPTempDataTable = New DataTable

                            ' Add the columns to match the current file.
                            m_dtbQTPTempDataTable = m_dtbDataTable.Clone
                        End If

                        ' Add the new record.
                        Try
                            m_dtbDataTable.Rows(Me.CurrentRow).Item("ROW_ID") = Now.TimeOfDay.TotalMilliseconds.ToString & (m_dtbQTPTempDataTable.Rows.Count + 1).ToString
                            m_dtbDataTable.Rows(Me.CurrentRow).Item("CHECKSUM_VALUE") = 0
                            m_dtbQTPTempDataTable.Rows.Add(m_dtbDataTable.Rows(Me.CurrentRow).ItemArray)
                        Catch ex As Exception
                            ' If an error occurred, reset the rowid.
                            m_dtbDataTable.Rows(Me.CurrentRow).Item("ROW_ID") = System.DBNull.Value
                            m_dtbDataTable.Rows(Me.CurrentRow).Item("CHECKSUM_VALUE") = System.DBNull.Value
                            AddMessage("Database Error: Could not update the table <{0}>!", MessageTypes.Error, m_strBaseName) 'IM.DBError
                        End Try

                    Else

                        ' Update the record.
                        Dim strRow As String = "ROW_ID = '" & m_dtbDataTable.Rows(Me.CurrentRow).Item("ROW_ID") & "'"

                        Try
                            'Dim dc(0) As DataColumn
                            'dc(0) = m_dtbQTPTempDataTable.Columns("ROW_ID")
                            'm_dtbQTPTempDataTable.PrimaryKey = dc
                            m_dtbDataTable.Rows(Me.CurrentRow).Item("CHECKSUM_VALUE") += 1
                            m_dtbQTPTempDataTable.Select(strRow)(0).ItemArray = m_dtbDataTable.Rows(Me.CurrentRow).ItemArray

                        Catch ex As Exception
                            AddMessage("Database Error: Could not update the table <{0}>!", MessageTypes.Error, m_strBaseName) 'IM.DBError
                        End Try


                    End If

                End If

                If Not m_dtbQTPTempDataTable Is Nothing Then
                    ' Commit the changes to the temporary file.
                    m_dtbQTPTempDataTable.AcceptChanges()

                    If m_blnDeletedRecord(Me.CurrentRow) Then
                        PassLog = LogType.Deleted
                    End If

                    QTPRecordsRead(Me.BaseName, Me.AliasName, 1, PassLog)


                    'If IsQTP Then
                    '    If m_BaseClass.Session("hsSubfile").Contains(Me.BaseName) Then
                    '        m_BaseClass.Session("hsSubfile").Item(Me.BaseName) = m_dtbQTPTempDataTable
                    '    Else
                    '        m_BaseClass.Session("hsSubfile").Add(Me.BaseName, m_dtbQTPTempDataTable)
                    '    End If
                    'Else
                    '    Core.Windows.UI.SessionInformation.SetSession(Me.BaseName, m_dtbQTPTempDataTable)
                    'End If

                End If


            Else

                ' Perform the appropriate action based on the status flags.
                If m_blnDeletedRecord(Me.CurrentRow) Then

                    ' Only delete if the session table exists.
                    If Not SessionTable Is Nothing Then
                        If SessionTable.Select("ROW_ID = '" & m_dtbDataTable.Rows(Me.CurrentRow).Item("ROW_ID") & "' AND CHECKSUM_VALUE = " & m_dtbDataTable.Rows(Me.CurrentRow).Item("CHECKSUM_VALUE")).Length = 1 Then
                            SessionTable.Select("ROW_ID = '" & m_dtbDataTable.Rows(Me.CurrentRow).Item("ROW_ID") & "' AND CHECKSUM_VALUE = " & m_dtbDataTable.Rows(Me.CurrentRow).Item("CHECKSUM_VALUE"))(0).Delete()
                        Else
                            AddMessage("Cannot update table <{0}>, data has been changed.", MessageTypes.Error, m_strBaseName) 'IM.DataChangedDB
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
                            'm_dtbDataTable.Rows(Me.CurrentRow).Item("CHECKSUM_VALUE") = 0
                            SessionTable.Rows.Add(m_dtbDataTable.Rows(Me.CurrentRow).ItemArray)
                        Catch ex As Exception
                            ' If an error occurred, reset the rowid.
                            m_dtbDataTable.Rows(Me.CurrentRow).Item("ROW_ID") = System.DBNull.Value
                            'm_dtbDataTable.Rows(Me.CurrentRow).Item("CHECKSUM_VALUE") = System.DBNull.Value
                            AddMessage("Database Error: Could not update the table <{0}>!", MessageTypes.Error, m_strBaseName) 'IM.DBError
                        End Try

                    Else

                        ' Update the record.
                        Dim strRow As String = "ROW_ID = '" & m_dtbDataTable.Rows(Me.CurrentRow).Item("ROW_ID") & "'"

                        Try
                            'Dim dc(0) As DataColumn
                            'dc(0) = SessionTable.Columns("ROW_ID")
                            'SessionTable.PrimaryKey = dc
                            'm_dtbDataTable.Rows(Me.CurrentRow).Item("CHECKSUM_VALUE") += 1
                            SessionTable.Select(strRow)(0).ItemArray = m_dtbDataTable.Rows(Me.CurrentRow).ItemArray

                        Catch ex As Exception
                            AddMessage("Database Error: Could not update the table <{0}>!", MessageTypes.Error, m_strBaseName) 'IM.DBError
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
                        If m_BaseClass.Session("hsSubfile").Contains(Me.BaseName) Then
                            m_BaseClass.Session("hsSubfile").Item(Me.BaseName) = SessionTable
                        Else
                            m_BaseClass.Session("hsSubfile").Add(Me.BaseName, SessionTable)
                        End If
                    Else
                        'Core.Windows.UI.SessionInformation.SetSession(Me.BaseName, SessionTable)
                    End If

                End If

            End If

        End Sub

        <Browsable(False),
      EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overrides ReadOnly Property SQLServerUseSchemas() As Boolean
            Get
                Return (System.Configuration.ConfigurationManager.AppSettings("SQLServerUseSchemas") + "").ToUpper = "TRUE"
            End Get
        End Property

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overrides ReadOnly Property DeleteSubFile() As Boolean
            Get
                If IsQTP Then
                    If m_BaseClass Is Nothing Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                        Return m_BaseQuiz.blnDeleteSubFile
#End If
                    Else
                        Return m_BaseClass.blnDeleteSubFile
                    End If
                Else
                    Return False
                End If
            End Get
        End Property

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overrides ReadOnly Property IsKeepText() As Boolean
            Get
                Return (System.Configuration.ConfigurationManager.AppSettings("SubfileKEEPtoTEXT") & "").ToUpper = "TRUE" OrElse (Owner = "SEQUENTIAL" AndAlso Not IsQTP)

            End Get
        End Property

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overrides ReadOnly Property IsKeepTextFile() As Boolean
            Get
                Dim strFilePath As String
                Dim strFilePath2 As String = ""

                If Not IsQTP Then
                    strFilePath = Environment.GetEnvironmentVariable("CurrentDirectory", EnvironmentVariableTarget.Process)
                    strFilePath = strFilePath.Replace(vbCr, "\r")
                Else
                    strFilePath = Directory.GetCurrentDirectory()
                End If

                'If IsNothing(m_Page) Then
                '    strFilePath2 = System.Configuration.ConfigurationManager.AppSettings("FlatFilePath") & "\" & m_BaseClass.Session("m_strUser") & "_" & m_BaseClass.Session("m_strSessionID")
                'Else
                '    strFilePath2 = System.Configuration.ConfigurationManager.AppSettings("FlatFilePath") & "\" & m_Page.Session("m_strUser") & "_" & m_Page.Session("m_strSessionID")
                'End If
                Dim strFile As String = String.Empty
                Dim strTextName As String = String.Empty
                Dim strName As String = String.Empty
                Dim blnreturn As Boolean = False

                If IsQTP Then
                    If IsNothing(Me.m_BaseClass.Session("strSubFileName")) Then
                        strTextName = Me.BaseName
                    Else
                        strTextName = Me.m_BaseClass.Session("strSubFileName").ToString
                        If strTextName.IndexOf(".") >= 0 Then
                            strName = strTextName.Substring(0, strTextName.IndexOf("."))
                            strTextName = strTextName.Substring(strTextName.IndexOf(".") + 1)
                            strTextName = strTextName.Replace(".", "\") & "\" & strName
                        End If
                    End If
                    If Owner = "SEQUENTIAL" Then
                        strTextName = strTextName + ".dat"
                    Else
                        If IsPortableSubFile Then
                            strTextName = strTextName + ".ps"
                        Else
                            strTextName = strTextName + ".sf"
                        End If
                    End If


                Else
                    If IsNothing(Me.m_Page.Session("strSubFileName")) Then
                        strTextName = Me.BaseName
                    Else
                        strTextName = Me.m_Page.Session("strSubFileName").ToString
                        If strTextName.IndexOf(".") >= 0 Then
                            strName = strTextName.Substring(0, strTextName.IndexOf("."))
                            strTextName = strTextName.Substring(strTextName.IndexOf(".") + 1)
                            strTextName = strTextName.Replace(".", "\") & "\" & strName
                        End If
                    End If
                    If Owner = "SEQUENTIAL" Then
                        strTextName = strTextName + ".dat"
                    Else
                        If IsPortableSubFile Then
                            strTextName = strTextName + ".ps"
                        Else
                            strTextName = strTextName + ".sf"
                        End If
                    End If

                End If

                If strFile.EndsWith("\") Then
                    strFile = strFilePath & strTextName
                Else
                    strFile = strFilePath & "\" & strTextName
                End If

                blnreturn = File.Exists(strFile)
                If Not blnreturn Then
                    blnreturn = File.Exists(strFile.Replace(strFilePath, strFilePath2))
                End If
                If Not blnreturn Then
                    blnreturn = File.Exists(strFile.Replace(".sf", ".ps"))
                End If

                Return blnreturn

            End Get
        End Property

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
        Public Overrides Property FirstFileCount() As Integer
            Get
                If IsNothing(m_BaseClass) Then
                    Return Nothing
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                ElseIf IsNothing(m_BaseQuiz) Then
                    Return Nothing
#End If
                End If
                If IsNothing(m_BaseClass) Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                    Return m_BaseQuiz.intFirstRecordCount
#End If
                Else
                    Return m_BaseClass.intFirstRecordCount
                End If

            End Get
            Set(ByVal Value As Integer)
                If Not IsNothing(m_BaseClass) Then
                    m_BaseClass.intFirstRecordCount = Value
                End If
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                If Not IsNothing(m_BaseQuiz) Then
                    m_BaseQuiz.intFirstRecordCount = Value
                End If
#End If
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
        Public Overrides Property FirstOverrideCount() As Integer
            Get
                If IsNothing(m_BaseClass) Then
                    Return Nothing
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                ElseIf IsNothing(m_BaseQuiz) Then
                    Return Nothing
#End If
                End If
                If m_BaseClass Is Nothing Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                    Return m_BaseQuiz.intFirstOverrideOccurs
#End If
                Else
                    Return m_BaseClass.intFirstOverrideOccurs
                End If
            End Get
            Set(ByVal Value As Integer)
                If Not IsNothing(m_BaseClass) Then
                    m_BaseClass.intFirstOverrideOccurs = Value
                End If
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                If Not IsNothing(m_BaseQuiz) Then
                    m_BaseQuiz.intFirstOverrideOccurs = Value
                End If
#End If
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
        Public Overrides Property blnIsInSelectIf() As Boolean
            Get
                If IsNothing(m_BaseClass) Then
                    Return Nothing
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                ElseIf IsNothing(m_BaseQuiz) Then
                    Return Nothing
#End If
                End If
                If m_BaseClass Is Nothing Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                    Return m_BaseQuiz.blnIsInSelectIf
#End If
                Else
                    Return m_BaseClass.blnIsInSelectIf
                End If

            End Get
            Set(ByVal Value As Boolean)
                If Not IsNothing(m_BaseClass) Then
                    m_BaseClass.blnIsInSelectIf = Value
                End If
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                If Not IsNothing(m_BaseQuiz) Then
                    m_BaseQuiz.blnIsInSelectIf = Value
                End If
#End If
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
        Public Overrides Property blnGlobalUseTableSelectIf() As BooleanTypes
            Get
                If IsNothing(m_BaseClass) Then
                    Return Nothing
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                ElseIf IsNothing(m_BaseQuiz) Then
                    Return Nothing
#End If
                End If
                If m_BaseClass Is Nothing Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                    Return m_BaseQuiz.blnGlobalUseTableSelectIf
#End If
                Else
                    Return m_BaseClass.blnGlobalUseTableSelectIf
                End If

            End Get
            Set(ByVal Value As BooleanTypes)
                If Not IsNothing(m_BaseClass) Then
                    m_BaseClass.blnGlobalUseTableSelectIf = Value
                End If
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                If Not IsNothing(m_BaseQuiz) Then
                    m_BaseQuiz.blnGlobalUseTableSelectIf = Value
                End If
#End If
            End Set
        End Property

        ''' --- IsView ---------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Gets or sets a boolean value indicating that the current file is
        '''     based on a View.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Property IsView() As Boolean
            Get
                Return m_blnIsView
            End Get
            Set(ByVal Value As Boolean)
                m_blnIsView = Value
            End Set
        End Property



        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overrides Property FileNoRecords() As String
            Get
                If IsNothing(m_BaseClass) Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                    Return m_BaseQuiz.strFileNoRecords
#End If
                Else
                    Return m_BaseClass.strFileNoRecords
                End If

            End Get
            Set(ByVal value As String)
                If IsNothing(m_BaseClass) Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                    m_BaseQuiz.strFileNoRecords = value
#End If
                Else
                    m_BaseClass.strFileNoRecords = value
                End If

            End Set
        End Property

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overrides Property FileWhere() As Hashtable
            Get
                If IsNothing(m_BaseClass) Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                    Return m_BaseQuiz.m_hsFileWhere
#End If
                Else
                    Return m_BaseClass.m_hsFileWhere
                End If

            End Get
            Set(ByVal value As Hashtable)
                If IsNothing(m_BaseClass) Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                    m_BaseQuiz.m_hsFileWhere = value
#End If
                Else
                    m_BaseClass.m_hsFileWhere = value
                End If

            End Set
        End Property

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overrides ReadOnly Property CurrentFile() As String
            Get
                If IsNothing(m_BaseClass) Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                    Return m_BaseQuiz.Session("CurrentFile") & ""
#End If
                Else
                    Return m_BaseClass.Session("CurrentFile") & ""
                End If

            End Get
        End Property

        Private _createWhere As Boolean
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Protected Overrides ReadOnly Property IsAt() As Boolean
            Get
                If IsNothing(m_BaseClass) Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                    Return m_BaseQuiz.m_blnIsAt
#Else
                    Return False
#End If
                Else
                    Return m_BaseClass.m_blnIsAt
                End If

            End Get
        End Property

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overrides Property WhereColumn() As ArrayList
            Get
                If IsNothing(m_BaseClass) Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                    If Not IsNothing(m_BaseQuiz.Session("WhereColumn" & m_BaseQuiz.Session("CurrentFile"))) Then
                        Return m_BaseQuiz.Session("WhereColumn" & m_BaseQuiz.Session("CurrentFile"))
                    Else
                        Return New ArrayList
                    End If
#Else
                    Return New ArrayList
#End If
                Else
                    If m_BaseClass.Session("WhereColumn" &
                        m_BaseClass.Session("CurrentFile")) Is Nothing Then
                        Return New ArrayList
                    Else
                        Return m_BaseClass.Session("WhereColumn" &
                        m_BaseClass.Session("CurrentFile"))
                    End If
                End If
            End Get
            Set(ByVal value As ArrayList)
                If IsNothing(m_BaseClass) Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                    m_BaseQuiz.Session("WhereColumn" & m_BaseQuiz.Session("CurrentFile")) = value
#End If
                Else
                    m_BaseClass.Session("WhereColumn" & m_BaseClass.Session("CurrentFile")) = value
                End If
            End Set
        End Property

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overrides Property UseMemory() As Boolean
            Get
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                If IsNothing(m_BaseClass) AndAlso IsNothing(m_BaseQuiz) Then
                    Return False
#Else
                If IsNothing(m_BaseClass) Then
                    Return False
#End If

                Else
                    If IsNothing(m_BaseClass) Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                        Return m_BaseQuiz.m_blnUseMemory
#Else
                        Return False
#End If
                    Else
                        Return m_BaseClass.m_blnUseMemory
                    End If

                End If
            End Get
            Set(ByVal value As Boolean)
                If Not IsNothing(m_BaseClass) Then
                    m_BaseClass.m_blnUseMemory = value
                End If
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                If Not IsNothing(m_BaseQuiz) Then
                    m_BaseQuiz.m_blnUseMemory = value
                End If
#End If
            End Set
        End Property

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overrides Property WhereElementColumn() As String
            Get
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                If IsNothing(m_BaseClass) AndAlso IsNothing(m_BaseQuiz) Then
                    Return False
#Else
                If IsNothing(m_BaseClass) Then
                    Return False
#End If
                Else
                    If m_BaseClass Is Nothing Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                        Return m_BaseQuiz.WhereElementColumn
#End If
                    Else
                        Return m_BaseClass.WhereElementColumn
                    End If
                End If
            End Get
            Set(ByVal Value As String)
                If Not IsNothing(m_BaseClass) Then
                    m_BaseClass.WhereElementColumn = Value
                End If
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                If Not IsNothing(m_BaseQuiz) Then
                    m_BaseQuiz.WhereElementColumn = Value
                End If
#End If
            End Set
        End Property

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overrides ReadOnly Property SortPhase() As Boolean
            Get
                If m_BaseClass Is Nothing Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                    Return m_BaseQuiz.intSorted > 0
#Else
                    Return False
#End If
                Else
                    Return m_BaseClass.intSorted > 0
                End If

            End Get
        End Property

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overrides ReadOnly Property SortPhaseSet() As Boolean
            Get
                If m_BaseClass Is Nothing Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                    Return m_BaseQuiz.intSorted > 0
#Else
                    Return False
#End If
                Else
                    Return m_BaseClass.intSorted > 0 OrElse m_BaseClass.blnTrans
                End If

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
        Public Overrides Property NoRecords() As Boolean
            Get
                If m_BaseClass Is Nothing Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                    Return m_BaseQuiz.m_blnNoRecords
#Else
                    Return False
#End If
                Else
                    Return m_BaseClass.m_blnNoRecords
                End If
            End Get
            Set(ByVal Value As Boolean)
                If m_BaseClass Is Nothing Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                    m_BaseQuiz.m_strNoRecordsLevel = m_intQTPLevel
                    m_BaseQuiz.m_blnNoRecords = Value
#End If
                Else
                    m_BaseClass.m_strNoRecordsLevel = m_intQTPLevel
                    m_BaseClass.m_blnNoRecords = Value
                End If
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overrides ReadOnly Property CurrentRow() As Integer
            Get
                If Me.Type = FileTypes.Reference Then
                    Return 0
                ElseIf Me.Occurs > 0 Then
                    If m_Page Is Nothing Then
                        If blnOverRideOccurrence Then
                            Return OverRideOccurrence
                        Else
                            If m_BaseClass Is Nothing Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                                Return m_BaseQuiz.Occurrence - 1
#End If
                            Else
                                Return m_BaseClass.Occurrence - 1
                            End If
                        End If
                    Else
                        Return m_Page.m_intOccurrence
                    End If
                Else
                    Return 0 '--- Me.m_intCurrentRow
                End If
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
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overrides Property TotalRecordsFound() As Integer
            'Note: Only to be used in While skipping records with an error in Find/DetailFind

            'TotalRecordsFound, TotalSkippedRecords and TotalRecordsProcessed
            'are at screen level. i.e. per screen only one file should use these properties
            Get
                Dim objTotalRecordsFound As Object
                If m_Page Is Nothing Then
                    If m_BaseClass Is Nothing Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                        objTotalRecordsFound = Me.m_BaseQuiz.TotalRecordsFound
#End If
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
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                        Me.m_BaseQuiz.TotalRecordsFound = Value
#End If
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overrides Property TotalSkippedRecords() As Integer
            'Note: Only to be used in While skipping records with an error in Find/DetailFind
            'That too only to be used from a file that is occuring and in which "records-with-an-error" to be bypassed 

            'TotalRecordsFound, TotalSkippedRecords and TotalRecordsProcessed
            'are at screen level. i.e. per screen only one file should use these properties
            Get
                Dim objTotalRecordsFound As Object
                If m_Page Is Nothing Then
                    If m_BaseClass Is Nothing Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                        objTotalRecordsFound = Me.m_BaseQuiz.TotalSkippedRecords
#End If
                    Else
                        objTotalRecordsFound = Me.m_BaseClass.TotalSkippedRecords
                    End If
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
                    If m_BaseClass Is Nothing Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                        Me.m_BaseQuiz.TotalSkippedRecords = Value
#End If
                    Else
                        Me.m_BaseClass.TotalSkippedRecords = Value
                    End If
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overrides Property TotalRecordsProcessed() As Integer
            'Note: Only to be used in While skipping records with an error in Find/DetailFind

            'TotalRecordsFound, TotalSkippedRecords and TotalRecordsProcessed
            'are at screen level. i.e. per screen only one file should use these properties
            Get
                If m_Page Is Nothing Then
                    Dim objTotalRecordsFound As Object
                    If m_BaseClass Is Nothing Then

                    Else
                        objTotalRecordsFound = Me.m_BaseClass.RecordsProcessed
                    End If
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
                    If m_BaseClass Is Nothing Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                        Me.m_BaseQuiz.RecordsProcessed = Value
#End If
                    Else
                        Me.m_BaseClass.RecordsProcessed = Value
                    End If
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overrides ReadOnly Property IsQTP() As Boolean
            Get
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                If Not IsNothing(m_BaseQuiz) Then
                    Return True
                ElseIf Not IsNothing(m_BaseClass) AndAlso (m_BaseClass.ScreenType = ScreenTypes.QTP OrElse m_BaseClass.ScreenType = ScreenTypes.QUIZ) Then
#Else
                If Not IsNothing(m_BaseClass) AndAlso (m_BaseClass.ScreenType = ScreenTypes.QTP OrElse m_BaseClass.ScreenType = ScreenTypes.QUIZ) Then
#End If
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overrides ReadOnly Property IsQuiz() As Boolean
            Get
                If IsQTP Then
                    If m_BaseClass Is Nothing Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                        Return m_BaseQuiz.ScreenType = ScreenTypes.QUIZ
#Else
                        Return False
#End If
                    Else
                        Return m_BaseClass.ScreenType = ScreenTypes.QUIZ
                    End If

                Else
                    Return False
                End If
            End Get
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
        Public Overrides Property SelectifColumn() As ArrayList
            Get
                If IsNothing(m_BaseClass) Then
                    Return Nothing
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                ElseIf IsNothing(m_BaseQuiz) Then
                    Return Nothing
#End If
                End If
                If IsNothing(m_BaseClass) Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                    Return m_BaseQuiz.m_arrSelectifColumn
#Else
                    Return Nothing
#End If
                Else
                    Return m_BaseClass.m_arrSelectifColumn
                End If

            End Get
            Set(ByVal Value As ArrayList)
                If Not IsNothing(m_BaseClass) Then
                    m_BaseClass.m_arrSelectifColumn = Value
                End If
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                If Not IsNothing(m_BaseQuiz) Then
                    m_BaseQuiz.m_arrSelectifColumn = Value
                End If
#End If
            End Set
        End Property

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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overrides Sub SaveReceivingParam()
            If m_Page Is Nothing Then
                '
            Else
                If m_intPassingSequence > 0 Then
                    Me.m_Page.SaveReceivingParam(Me, m_intPassingSequence)
                End If
            End If
        End Sub

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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overrides Function IsExecutingPostPath() As Boolean
            If m_Page Is Nothing Then
                'TODO: To add m_blnExecutingPath in BaseClassControl
                'Return Me.m_BaseClass.m_blnExecutingPath
            Else
                Return Me.m_Page.m_blnExecutingPostPath
            End If
        End Function

        ''' --- ClearColumnJoinInfo --------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' Clears the join column information used by the VAL function that is located
        ''' in MenuOptionWeb (to handle when joining multiple sql's into one).
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        Protected Overrides Sub ClearColumnJoinInfo()
            If Not m_BaseClass Is Nothing Then
                m_BaseClass.SetJoinColumnInfo(Nothing, "")
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overrides Sub SetLastFileObject()
            'Should only be called from GetInternalData.
            'AlteredRecord, DeletedRecord and NewRecord uses 
            'm_bfoFileForRecordStatus to return the primary file unless it is changed with the 
            'SET ASSUMED (Which we don't support at present) statement. If there is no assumed 
            'record-structure, the status is the same as that of the current record-structure,
            'that gets set in GetData
            If m_Page Is Nothing Then
                If m_BaseClass Is Nothing Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                    Me.m_BaseQuiz.FileForRecordStatus = CType(Me, BaseFileObject)
#End If
                Else
                    Me.m_BaseClass.FileForRecordStatus = CType(Me, BaseFileObject)
                End If
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Protected Overrides Sub SetAccessOkOnPage(ByVal AccessOk As Boolean)
            If m_Page Is Nothing Then
                If m_BaseClass Is Nothing Then
#If INCLUDE_ACTIVE_REPORTS = "TRUE" Then
                    Me.m_BaseQuiz.SetAccessOk(AccessOk)
#End If
                Else
                    Me.m_BaseClass.SetAccessOk(AccessOk)
                End If
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Overrides Function GetDataTempTable(ByVal WhereClause As String, ByVal OrderByClause As String, Optional ByVal StartRow As Long = -1, Optional ByVal Count As Integer = -1, Optional ByVal trnTransaction As SqlTransaction = Nothing) As DataTable

            Dim NewDataTable As DataTable = New DataTable(Me.BaseName)
            Dim PreDataTable As DataTable
            Dim SessionTable As DataTable



            If IsQTP OrElse IsSubFile Then
                If IsTempTable OrElse (IsSubFile AndAlso m_IsSubFileKeep <> 2) Then
                    If m_IsSubFileKeep = 1 And Not IsTempTable Then
                        SessionTable = tmpDataTable
                    Else
                        If IsNothing(m_dtbQTPTempDataTable) Then
                            If IsNothing(m_BaseClass) Then
                                If m_Page.Session("hsSubfile").Contains(Me.BaseName) Then
                                    m_dtbQTPTempDataTable = m_Page.Session("hsSubfile").Item(Me.BaseName)
                                End If
                            Else
                                If m_BaseClass.Session("hsSubfile").Contains(Me.BaseName) Then
                                    m_dtbQTPTempDataTable = m_BaseClass.Session("hsSubfile").Item(Me.BaseName)
                                End If
                            End If

                            If IsNothing(m_dtbQTPTempDataTable) Then
                                m_dtbQTPTempDataTable = GetTextTable("")
                            End If
                        ElseIf Not IsNothing(m_BaseClass) AndAlso m_BaseClass.Session("hsSubfile").Contains(Me.BaseName) Then
                            If IsNothing(m_BaseClass) Then
                                m_dtbQTPTempDataTable = m_Page.Session("hsSubfile").Item(Me.BaseName)
                            Else
                                m_dtbQTPTempDataTable = m_BaseClass.Session("hsSubfile").Item(Me.BaseName)
                            End If

                        ElseIf Not IsNothing(m_Page) AndAlso m_Page.Session("hsSubfile").Contains(Me.BaseName) Then
                            If IsNothing(m_BaseClass) Then
                                m_dtbQTPTempDataTable = m_Page.Session("hsSubfile").Item(Me.BaseName)
                            Else
                                m_dtbQTPTempDataTable = m_BaseClass.Session("hsSubfile").Item(Me.BaseName)
                            End If

                        End If
                        SessionTable = m_dtbQTPTempDataTable
                    End If



                    If Not m_blnFirstFile AndAlso Not IsNothing(SessionTable) AndAlso (IsNothing(m_dtbDataTable) OrElse m_dtbDataTable.Rows.Count = 0) Then
                        ReDim m_blnNewRecord(CInt(SessionTable.Rows.Count * 2))
                        ReDim m_blnAlteredRecord(CInt(SessionTable.Rows.Count * 2))
                        ReDim m_blnDeletedRecord(CInt(SessionTable.Rows.Count * 2))
                        ReDim m_blnGridDeletedRecord(CInt(SessionTable.Rows.Count * 2))
                        ReDim m_blnIsInitialized(CInt(SessionTable.Rows.Count * 2))
                        ReDim m_blnCountIntoCalled(CInt(SessionTable.Rows.Count * 2))
                    End If


                    If Not blnTempPutInDatabase AndAlso Not SortPhase Then


                        Dim strCreateTable As New StringBuilder("")


                        Try
                            If Not IsNothing(m_BaseClass) Then
                                If IsNothing(SessionTable) Then
                                    If Me.Owner <> "Temporary Data.dbo" AndAlso Me.Owner <> "Temporary Data" AndAlso Me.Owner <> "TEMPORARYDATA" Then
                                        SessionTable = GetCachedSchema(True, False)
                                    End If
                                End If

                                If Not IsNothing(SessionTable) Then

                                    If IsNothing(m_BaseClass.arrTempTables) Then m_BaseClass.arrTempTables = New ArrayList
                                    If Not m_BaseClass.arrTempTables.Contains("#" & Me.BaseName) Then

                                        m_BaseClass.arrTempTables.Add("#" & Me.BaseName)


                                        With strCreateTable
                                            Dim arrDate As New ArrayList
                                            .Append("CREATE TABLE #").Append(Me.BaseName)
                                            .Append("(")

                                            For i As Integer = 0 To SessionTable.Columns.Count - 1
                                                .Append(SessionTable.Columns(i).ColumnName)

                                                Select Case SessionTable.Columns(i).DataType.ToString
                                                    Case "System.String"
                                                        Dim strCulture As String = System.Configuration.ConfigurationManager.AppSettings("Culture") & ""
                                                        If strCulture.Length = 0 Then
                                                            .Append(" ").Append("varchar(max)  NULL ")
                                                        Else
                                                            .Append(" ").Append("varchar(max) COLLATE ").Append(strCulture).Append(" NULL ")
                                                        End If
                                                    Case "System.Int32", "System.Int64"
                                                        .Append(" ").Append("int NULL ")
                                                    Case "System.Decimal", "System.Double"
                                                        .Append(" ").Append("float NULL ")
                                                    Case "System.DateTime"
                                                        .Append(" ").Append("datetime NULL ")
                                                        arrDate.Add(i)
                                                End Select


                                                If i < SessionTable.Columns.Count - 1 Then
                                                    .Append(", ")
                                                Else
                                                    .Append(")")
                                                End If

                                            Next

                                            SqlHelper.ExecuteNonQuery(trnTransaction, CommandType.Text, strCreateTable.ToString)



                                            If SessionTable.Rows.Count > 0 Then


                                                Dim SqlBC As New SqlBulkCopy(trnTransaction.Connection, SqlBulkCopyOptions.Default, trnTransaction)
                                                SqlBC.DestinationTableName = "#" & Me.BaseName

                                                For i As Integer = 0 To SessionTable.Columns.Count - 1
                                                    SqlBC.ColumnMappings.Add(SessionTable.Columns(i).ColumnName, SessionTable.Columns(i).ColumnName)
                                                Next

                                                Try
                                                    SqlBC.WriteToServer(SessionTable)
                                                Catch ex As Exception

                                                    If arrDate.Count > 0 Then
                                                        For i As Integer = 0 To SessionTable.Rows.Count - 1
                                                            For j As Integer = 0 To arrDate.Count - 1
                                                                If Not IsNull(SessionTable.Rows(i)(arrDate(j))) AndAlso SessionTable.Rows(i)(arrDate(j)) = #12:00:00 AM# Then
                                                                    SessionTable.Rows(i)(arrDate(j)) = DBNull.Value
                                                                End If
                                                            Next
                                                        Next

                                                    Else
                                                        Throw (ex)

                                                    End If

                                                    SqlBC.WriteToServer(SessionTable)

                                                End Try


                                                SqlBC.Close()

                                            End If

                                        End With


                                    End If
                                End If
                            End If
                        Catch ex As Exception
                            'The table is already in the Database
                            'This should never happen and is only a precaution
                        End Try

                        blnTempPutInDatabase = True

                    End If

                Else
                    SessionTable = tmpDataTable
                End If


            ElseIf (Core.Windows.UI.ApplicationState.Current.TempTable.ContainsKey(BaseName)) Then
                SessionTable = Core.Windows.UI.ApplicationState.Current.TempTable.Item(BaseName)

            End If


            If Not IsNothing(SessionTable) Then
                PreDataTable = SessionTable
            End If

            Dim strRelation As String = Me.BaseName
            If Me.AliasName.Trim.Length > 0 Then strRelation = Me.AliasName

            WhereClause = (WhereClause).ToUpper.Replace("WHERE ", "").Replace(Me.ElementOwner.ToUpper, "").Replace(strRelation & ".", "").Replace(" DBO.", " ").Replace("(DBO.", "(")
            OrderByClause = OrderByClause.ToUpper.Replace("ORDER BY ", "").Replace(Me.ElementOwner.ToUpper, "").Replace(strRelation & ".", "")

            If OrderByClause.Length = 0 AndAlso m_IsSubFileKeep = 1 Then
                OrderByClause = " ROW_ID "
            End If

            If IsNothing(SessionTable) AndAlso Not m_IsSubFile Then
                Dim tmpDataTable As DataTable = GetCachedSchema(True)
                tmpDataTable.Rows.RemoveAt(0)
                Return tmpDataTable
            Else

                If IsNothing(SessionTable) Then
                    Return NewDataTable
                Else


                    NewDataTable = PreDataTable.Clone

                    WhereClause = WhereClause.Replace("(CONVERT(INTEGER, CONVERT(CHAR(8),", "( CONVERT(INTEGER, CONVERT(CHAR(8),")

                    Do While (WhereClause.IndexOf("CONVERT(INTEGER, CONVERT(CHAR(8),") >= 0)
                        Dim strColumn As String = String.Empty
                        Dim strReplace As String = String.Empty
                        Dim strOper As String = String.Empty
                        Dim strDate As String = String.Empty
                        Dim arrWhere() As String = WhereClause.Split(" ")


                        For i As Integer = 0 To arrWhere.Length - 1
                            If arrWhere(i) = "CONVERT(INTEGER," Then

                                strColumn = arrWhere(i + 2).Replace(",", "")
                                'Added IF Condition due to the Date value being before the CONVERT function.
                                If arrWhere.Length >= (i + 5) Then
                                    strOper = arrWhere(i + 4)
                                    strDate = arrWhere(i + 5)
                                    If strDate.Trim = "0" OrElse strDate.Trim = "0)" Then
                                        strDate = "'0001/01/01'"
                                        strReplace = arrWhere(i) & " " & arrWhere(i + 1) & " " & arrWhere(i + 2) & " " & arrWhere(i + 3) & " " & arrWhere(i + 4) & " " & arrWhere(i + 5).Substring(0, 1)
                                    Else
                                        strDate = "'" & strDate.Substring(0, 4) + "/" & strDate.Substring(4, 2) + "/" & strDate.Substring(6, 2) & "'"
                                        strReplace = arrWhere(i) & " " & arrWhere(i + 1) & " " & arrWhere(i + 2) & " " & arrWhere(i + 3) & " " & arrWhere(i + 4) & " " & arrWhere(i + 5).Substring(0, 8)
                                    End If
                                    Exit For
                                Else
                                    'Added due to the Date value being before the CONVERT function.
                                    strOper = arrWhere(i - 1)
                                    strDate = arrWhere(i - 2)
                                    If strDate.Trim = "0" OrElse strDate.Trim = "(0" Then
                                        strDate = "'0001/01/01'"
                                        strReplace = arrWhere(i - 2) & " " & arrWhere(i - 1).Substring(0, 1) & " " & arrWhere(i) & " " & arrWhere(i + 1) & " " & arrWhere(i + 2) & " " & arrWhere(i + 3)
                                    Else
                                        strDate = "'" & strDate.Substring(0, 4) + "/" & strDate.Substring(4, 2) + "/" & strDate.Substring(6, 2) & "'"
                                        strReplace = arrWhere(i - 2) & " " & arrWhere(i - 1).Substring(0, 8) & " " & arrWhere(i) & " " & arrWhere(i + 1) & " " & arrWhere(i + 2) & " " & arrWhere(i + 3)
                                    End If
                                    Exit For
                                End If
                            End If
                        Next

                        WhereClause = WhereClause.Replace(strReplace, strColumn & " " & strOper & " " & strDate)


                    Loop


                    Const cReplaceChar As String = Chr(30)
                    Do While (ReplaceSqlVerb(WhereClause, " BETWEEN ", "~CORE_BETWEEN~").IndexOf("~CORE_BETWEEN~") >= 0)

                        Dim strTable As String = ""
                        Dim strValue As String = ""
                        Dim strReplace As String = ""
                        Dim strReplaceWith As String = ""
                        Dim arrWhere() As String = ReplaceSqlVerb(WhereClause, " AND ", cReplaceChar).Split(CType(cReplaceChar, String))

                        For i As Integer = 0 To arrWhere.Length - 1
                            If ReplaceSqlVerb(arrWhere(i), " BETWEEN ", "~CORE_BETWEEN~").IndexOf("~CORE_BETWEEN~") >= 0 Then
                                strReplace = arrWhere(i) & " AND " & arrWhere(i + 1)
                                strTable = arrWhere(i).Substring(0, arrWhere(i).IndexOf(" BETWEEN ")).Trim
                                strValue = arrWhere(i).Substring(arrWhere(i).IndexOf(" BETWEEN ") + 9).Trim
                                strReplaceWith = strTable & " >= " & strValue & " AND " & strTable & " <= " & arrWhere(i + 1).Trim
                                WhereClause = WhereClause.Replace(strReplace, strReplaceWith)
                            End If

                        Next

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

    End Class

End Namespace

