Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.ComponentModel

Namespace Core.Windows.UI

    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: LinkButton
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of LinkButton.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/22/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <ToolboxItem(False), _
    EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
    Public Class LinkButton
        Inherits Button

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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Sub New()

            MyBase.New()
            TabIndex = 0
            Text = "[LinkButtonText]"

        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of New.
        ''' </summary>
        ''' <param name="LinkCommandName"></param>
        ''' <param name="LinkCommandArgument"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Sub New(ByVal LinkCommandName As String, ByVal LinkCommandArgument As String)

            MyBase.New()
            TabIndex = 0
            Text = "[LinkButtonText]"
            CommandName = LinkCommandName
            CommandArgument = LinkCommandArgument
        End Sub

    End Class

End Namespace