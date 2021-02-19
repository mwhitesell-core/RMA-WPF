Imports System.ComponentModel
Imports Core.Framework.Core.Framework
Imports System.Windows.Controls
Imports Core.Windows.UI.Core.Windows.UI
Imports System.Windows.Media.Imaging
Imports System.Windows.Media
Imports System.Threading

Namespace Core.Windows.UI
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: RowStatus
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of RowStatus.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/22/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <ToolboxItem(False), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
    Public Class RowStatus
        Inherits System.Windows.Controls.Image

        Private mPreviousStatus As GridRowStatus
        Private mCurrentStatus As GridRowStatus
        Private mAppendStatus As AppendStatus
        Private mDesigners As String

        ''' --- PreviousStatus -----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of PreviousStatus.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public Property PreviousStatus() As GridRowStatus
            Get
                Return mPreviousStatus
            End Get
            Set(ByVal Value As GridRowStatus)
                mPreviousStatus = Value
            End Set
        End Property



        ''' --- CurrentStatus ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of CurrentStatus.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public Property CurrentStatus() As GridRowStatus
            Get
                Return mCurrentStatus
            End Get
            Set(ByVal Value As GridRowStatus)
                mCurrentStatus = Value

                If Value = GridRowStatus.UnchangedOld OrElse Value = GridRowStatus.NotSet Then
                    'If the current row status is UnchangedOld, set AppendedRowStatus to NotSet
                    AppendedRowStatus = AppendStatus.NotSet
                End If

                Source = GetRowStatusImageURL(Value)
            End Set
        End Property

        ''' --- AppendedRowStatus --------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of AppendedRowStatus.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public Property AppendedRowStatus() As AppendStatus
            'This property is used to identify whether the row is Appended or not
            'and also used to fire Designer on already "Appended" row
            Get
                Return mAppendStatus
            End Get
            Set(ByVal Value As AppendStatus)
                Select Case Value
                    Case AppendStatus.Appending
                        If _
                            mAppendStatus = AppendStatus.NotSet OrElse _
                            (Not mAppendStatus = AppendStatus.Appending AndAlso ApplicationState.Current.CorePage.IsAppend) _
                            Then
                            'Only change the status to "Appending", if the current AppendedRowStatus is "NotSet"
                            mAppendStatus = Value
                            Me.SetBothStatus(GridRowStatus.UnchangedNew)
                        End If
                    Case AppendStatus.Appended
                        If mAppendStatus = AppendStatus.Appending OrElse mAppendStatus = AppendStatus.NotSet Then
                            'Only change the status to "Appended", if the current AppendedRowStatus is "Appending"
                            mAppendStatus = Value
                        End If
                    Case AppendStatus.NotSet
                        mAppendStatus = Value
                End Select
            End Set
        End Property

        ''' --- Designers ----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Designers.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public Property Designers() As String
            Get
                Return mDesigners
            End Get
            Set(ByVal Value As String)
                mDesigners = Value
            End Set
        End Property


        ''' --- SetBothStatus ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of SetBothStatus.
        ''' </summary>
        ''' <param name="NewStatus"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public Sub SetBothStatus(ByVal NewStatus As GridRowStatus)
            CurrentStatus = NewStatus
            PreviousStatus = NewStatus
        End Sub

        ''' --- GetRowStatusImageURL -----------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetRowStatusImageURL.
        ''' </summary>
        ''' <param name="GridRowStatus"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public Function GetRowStatusImageURL(ByVal GridRowStatus As GridRowStatus) As ImageSource

            Dim im As BitmapImage = New BitmapImage
            im.BeginInit()

            If Thread.CurrentThread.CurrentCulture.ToString.StartsWith("en") Then
                Select Case GridRowStatus
                    Case GridRowStatus.NotSet
                        Me.ToolTip = Nothing

                        im.UriSource = New Uri("pack://application:,,,/;component/Images/GridStatus/Grid_Status_None.gif")
                    Case GridRowStatus.Adding, GridRowStatus.UnchangedNew
                        Me.ToolTip = "Unchanged, New Row" 'ApplicationState.Current.CorePage.GetToolTip("IM.Grid.UnchangedNewTooltip")

                        im.UriSource = New Uri("pack://application:,,,/;component/Images/GridStatus/Grid_Status_None.gif")
                    Case GridRowStatus.Editing, GridRowStatus.UnchangedOld
                        Me.ToolTip = "Unchanged, Old Row" 'ApplicationState.Current.CorePage.GetToolTip("IM.Grid.UnchangedOldTooltip")

                        im.UriSource = New Uri("pack://application:,,,/;component/Images/GridStatus/Grid_Status_Idle.gif")
                    Case GridRowStatus.Added
                        Me.ToolTip = "Changed, New Row" 'ApplicationState.Current.CorePage.GetToolTip("IM.Grid.NewChangedTooltip")

                        im.UriSource = New Uri("pack://application:,,,/;component/Images/GridStatus/Grid_Status_Changed.gif")
                    Case GridRowStatus.Edited
                        Me.ToolTip = "Changed, Old Row" 'ApplicationState.Current.CorePage.GetToolTip("IM.Grid.OldChangedTooltip")

                        im.UriSource = New Uri("pack://application:,,,/;component/Images/GridStatus/Grid_Status_Submitted.gif")
                    Case GridRowStatus.Deleted
                        Me.ToolTip = "Marked for deletion" 'ApplicationState.Current.CorePage.GetToolTip("IM.Grid.DeletedTooltip")

                        im.UriSource = New Uri("pack://application:,,,/;component/Images/GridStatus/Grid_Status_Deleted.gif")
                End Select
            Else
                Select Case GridRowStatus
                    Case GridRowStatus.NotSet
                        Me.ToolTip = Nothing

                        im.UriSource = New Uri("pack://application:,,,/;component/Images/GridStatus/Grid_Status_None.gif")
                    Case GridRowStatus.Adding, GridRowStatus.UnchangedNew
                        Me.ToolTip = "Inchangé, nouvelle rangée" 'ApplicationState.Current.CorePage.GetToolTip("IM.Grid.UnchangedNewTooltip")

                        im.UriSource = New Uri("pack://application:,,,/;component/Images/GridStatus/Grid_Status_None.gif")
                    Case GridRowStatus.Editing, GridRowStatus.UnchangedOld
                        Me.ToolTip = "Inchangé, ancienne rangée" 'ApplicationState.Current.CorePage.GetToolTip("IM.Grid.UnchangedOldTooltip")

                        im.UriSource = New Uri("pack://application:,,,/;component/Images/GridStatus/Grid_Status_Idle.gif")
                    Case GridRowStatus.Added
                        Me.ToolTip = "Changé, nouvelle rangée" 'ApplicationState.Current.CorePage.GetToolTip("IM.Grid.NewChangedTooltip")

                        im.UriSource = New Uri("pack://application:,,,/;component/Images/GridStatus/Grid_Status_Changed.gif")
                    Case GridRowStatus.Edited
                        Me.ToolTip = "Changé, ancienne rangée" 'ApplicationState.Current.CorePage.GetToolTip("IM.Grid.OldChangedTooltip")

                        im.UriSource = New Uri("pack://application:,,,/;component/Images/GridStatus/Grid_Status_Submitted.gif")
                    Case GridRowStatus.Deleted
                        Me.ToolTip = "Marqué pour suppression" 'ApplicationState.Current.CorePage.GetToolTip("IM.Grid.DeletedTooltip")

                        im.UriSource = New Uri("pack://application:,,,/;component/Images/GridStatus/Grid_Status_Deleted.gif")
                End Select
            End If

            im.EndInit()
            Return im
        End Function

        ''' --- SaveViewState ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of SaveViewState.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Protected Function SaveViewState() As Object
            Designers = mDesigners
            CurrentStatus = mCurrentStatus
            PreviousStatus = mPreviousStatus
            AppendedRowStatus = mAppendStatus
        End Function

        ''' --- LoadViewState ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of LoadViewState.
        ''' </summary>
        ''' <param name="savedState"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Protected Sub LoadViewState(ByVal savedState As Object)
            mCurrentStatus = CurrentStatus
            mPreviousStatus = PreviousStatus
            mAppendStatus = AppendedRowStatus
            mDesigners = Designers
            If mDesigners Is Nothing Then
                mDesigners = ""
            End If
        End Sub

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
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public Sub New()
            MyBase.New()
        End Sub
    End Class
End Namespace