#Region "  Imports  "

Imports System.Drawing.Design
Imports System.Windows.Forms.Design
Imports System.ComponentModel
Imports System.Windows.Forms

#End Region


#Region " Core.Windows.UI.Designers  "

Namespace Core.Windows.UI.Designers
    Public NotInheritable Class FieldSelector
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
                    vListBox.SelectionMode = SelectionMode.MultiSimple
                    'Cycle through page and list the panels
                    Dim objControl As Object
                    For Each objControl In context.Instance.parent.controls
                        Try
                            If objControl.GetType.ToString = "Core.Windows.UI.DataList" Then
                                For Each objCtl As Object In objControl.items (0).controls
                                    If _
                                        objCtl.ID <> context.Instance.ID And _
                                        Not (objCtl.GetType.GetInterface ("IFieldObject", True) Is Nothing) Then
                                        vListBox.Items.Add (objCtl.ID)
                                    End If
                                Next
                            Else
                                If _
                                    objControl.ID <> context.Instance.ID And _
                                    Not (objControl.GetType.GetInterface ("IFieldObject", True) Is Nothing) Then
                                    vListBox.Items.Add (objControl.ID)
                                End If
                            End If
                        Catch
                        End Try
                    Next
                    Dim item As String
                    Dim myArray() As String
                    myArray = Split (value, ";")
                    For Each item In myArray

                        vListBox.SelectedItem = CType (item, String)
                    Next
                    vListBox.Sorted = True
                    fEdSvc.DropDownControl (vListBox)
                    Dim strTemp As String = ""
                    For Each item In vListBox.SelectedItems
                        strTemp += item & ";"
                    Next
                    Return strTemp
                Finally
                    fEdSvc = Nothing
                End Try
            Else
                Return value
            End If
        End Function
    End Class
End Namespace

#End Region
