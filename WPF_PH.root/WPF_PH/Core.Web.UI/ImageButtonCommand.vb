Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.ComponentModel
Imports System.Drawing.Design

<Assembly: TagPrefix("Core.UI.Web", "Core")> 
Namespace Core.UI.Web
    <ToolboxItem(False), _
       EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
       Public Class ImageButtonCommand
        Inherits System.Web.UI.WebControls.ImageButton

        Sub New()
            MyBase.New()
            
            Me.TabIndex = 0
            Me.EnableViewState = True

            MyBase.EnableViewState = True

        End Sub
        Sub New(ByVal ID As String, ByVal ImageURL As String, Optional ByVal CommandName As String = "", Optional ByVal CommandArgument As String = "")
            MyBase.New()
            
            Me.TabIndex = 0
            MyBase.EnableViewState = True
            Me.EnableViewState = True
            Me.ID = ID
            Me.ImageUrl = ImageURL
            Me.CommandName = CommandName
            Me.CommandArgument = CommandArgument

            Me.Attributes.Add("onmousedown", "javascript:document.all('RequestedTarget').value=this.name;document.all('RequestedArgument').value='" + CommandArgument.ToString + "';")
            Me.Attributes.Add("onclick", "javascript:if(document.forms(0).hidPutSecondPostbackOnHold.value != 'True'){document.all('__EventTarget').value=this.name;document.all('__EventArgument').value='" + CommandArgument.ToString + "';}else{document.all('RequestedTarget').value=this.name;document.all('RequestedArgument').value='" + CommandArgument.ToString + "';};")
        End Sub

    End Class

End Namespace