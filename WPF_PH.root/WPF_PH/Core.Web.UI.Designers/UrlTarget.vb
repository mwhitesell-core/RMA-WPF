#Region "  Imports  "

Imports System.Drawing.Design
Imports System.Windows.Forms.Design
Imports System.ComponentModel
Imports System.Windows.Forms

#End Region


#Region " Core.Windows.UI.Designers  "

Namespace Core.Windows.UI.Designers
    Public NotInheritable Class UrlTarget
        Inherits UITypeEditor
        Private fEdSvc As IWindowsFormsEditorService = Nothing

        Public Overloads Overrides Function GetEditStyle (ByVal context As ITypeDescriptorContext) _
            As UITypeEditorEditStyle
            If Not context Is Nothing And Not context.Instance Is Nothing Then
                Return UITypeEditorEditStyle.DropDown
            End If
            Return MyBase.GetEditStyle (context)
        End Function

        Public Overloads Overrides Function EditValue (ByVal context As ITypeDescriptorContext, _
                                                       ByVal provider As IServiceProvider, ByVal value As Object) _
            As Object
            If Not context Is Nothing And Not context.Instance Is Nothing And Not provider Is Nothing Then
                Try
                    fEdSvc = _
                        CType (provider.GetService (GetType (IWindowsFormsEditorService)), IWindowsFormsEditorService)
                    Dim vListBox As New ListBox
                    ' ListBox
                    AddHandler vListBox.SelectedValueChanged, AddressOf Me.List_Click

                    'Dim objControl As Object
                    'For Each objControl In context.Instance.parent.controls
                    '    Try
                    '        If objControl.ID <> context.Instance.ID Then
                    '            vListBox.Items.Add(objControl.ID)
                    '        End If
                    '    Catch
                    '    End Try
                    'Next
                    'Dim item As String
                    'Dim myArray() As String
                    'myArray = Split(value, ";")
                    'For Each item In myArray

                    '    vListBox.SelectedItem = CType(item, String)
                    'Next
                    'fEdSvc.DropDownControl(vListBox)
                    'Dim strTemp As String
                    'For Each item In vListBox.SelectedItems
                    '    strTemp += item & ";"
                    'Next
                    'Return strTemp

                    vListBox.Items.Add ("_blank")
                    vListBox.Items.Add ("_parent")
                    vListBox.Items.Add ("_search")
                    vListBox.Items.Add ("_self")
                    vListBox.Items.Add ("_top")
                    vListBox.SelectedItem = CType (value, String)
                    fEdSvc.DropDownControl (vListBox)
                    Return vListBox.SelectedItem
                Finally
                    fEdSvc = Nothing
                End Try
            Else
                Return value
            End If
        End Function

        Protected Sub List_Click (ByVal Sender As Object, ByVal Args As EventArgs)
            fEdSvc.CloseDropDown()
        End Sub
    End Class
End Namespace

#End Region
