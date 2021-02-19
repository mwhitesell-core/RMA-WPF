Imports System
Imports System.Collections.Generic
Imports System.Web.UI.WebControls
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Media

Namespace Core.Windows.UI


    Public Module VisualTreeExtensions

        Public Function GetRow(ListView1 As ListView, index As Integer) As GridViewRowPresenter

            Dim lvi As ListViewItem = TryCast(ListView1.ItemContainerGenerator.ContainerFromIndex(index), ListViewItem)
            Return FindVisualChild(Of GridViewRowPresenter)(lvi)
        End Function

        Public Function GetRowIndex(ListView1 As ListView, gvp As GridViewRowPresenter) As Integer

            For j As Integer = 0 To ListView1.Items.Count - 1
                Dim gvp1 As GridViewRowPresenter
                gvp1 = FindVisualChild(Of GridViewRowPresenter)(TryCast(ListView1.ItemContainerGenerator.ContainerFromIndex(j), ListViewItem))

                If gvp.Equals(gvp1) Then
                    Return j
                End If

            Next


        End Function



        <System.Runtime.CompilerServices.Extension>
        Public Function FindChildByType(Of T As DependencyObject)(depObj As DependencyObject) As T
            If depObj Is Nothing Then
                Return Nothing
            End If

            For i As Integer = 0 To VisualTreeHelper.GetChildrenCount(depObj) - 1
                Dim child = VisualTreeHelper.GetChild(depObj, i)

                Dim result = If(TryCast(child, T), FindChildByType(Of T)(child))
                If result IsNot Nothing Then
                    Return result
                End If
            Next
            Return Nothing
        End Function
        <System.Runtime.CompilerServices.Extension>
        Public Function ParentOfType(Of T As DependencyObject)(child As DependencyObject) As T
            'get parent item
            Dim parentObject As DependencyObject = VisualTreeHelper.GetParent(child)

            'we've reached the end of the tree
            If parentObject Is Nothing Then
                Return Nothing
            End If

            'check if the parent matches the type we're looking for
            Dim parent As T = TryCast(parentObject, T)
            If parent IsNot Nothing Then
                Return parent
            Else
                Return ParentOfType(Of T)(parentObject)
            End If
        End Function

        Public Function FindVisualChild(Of childItem As DependencyObject)(obj As DependencyObject) As childItem


            For i As Integer = 0 To VisualTreeHelper.GetChildrenCount(obj) - 1


                Dim child As DependencyObject = VisualTreeHelper.GetChild(obj, i)

                If child IsNot Nothing AndAlso TypeOf child Is childItem Then

                    Return DirectCast(child, childItem)
                Else



                    Dim childOfChild As childItem = FindVisualChild(Of childItem)(child)

                    If childOfChild IsNot Nothing Then

                        Return childOfChild

                    End If

                End If
            Next

            Return Nothing

        End Function




        Public Function GetVisualChild(Of T As Visual)(parent As Visual) As T
            Dim child As T = Nothing
            Dim numVisuals As Integer = VisualTreeHelper.GetChildrenCount(parent)
            For i As Integer = 0 To numVisuals - 1
                Dim v As Visual = DirectCast(VisualTreeHelper.GetChild(parent, i), Visual)
                child = TryCast(v, T)
                If child Is Nothing Then
                    child = GetVisualChild(Of T)(v)
                End If
                If child IsNot Nothing Then
                    Exit For
                End If
            Next
            Return child
        End Function


        <System.Runtime.CompilerServices.Extension>
        Public Sub FindChildFrameworkElementsOfType(Of T As FrameworkElement)(parent As DependencyObject, list As IList(Of T))
            Dim child As DependencyObject
            For i As Integer = 0 To VisualTreeHelper.GetChildrenCount(parent) - 1
                child = VisualTreeHelper.GetChild(parent, i)
                If TypeOf child Is T Then
                    list.Add(DirectCast(child, T))
                End If
                FindChildFrameworkElementsOfType(Of T)(child, list)
            Next
        End Sub

        <System.Runtime.CompilerServices.Extension>
        Public Function GetDescendants(Of T As UIElement)(parent As DependencyObject) As List(Of T)
            Dim children As New List(Of T)()

            Dim count As Integer = VisualTreeHelper.GetChildrenCount(parent)

            If count > 0 Then
                For i As Integer = 0 To count - 1
                    Try
                        If VisualTreeHelper.GetChild(parent, i).GetType.ToString <> "System.Windows.Controls.TextBoxLineDrawingVisual" Then
                            Dim child As UIElement = DirectCast(VisualTreeHelper.GetChild(parent, i), UIElement)

                            If TypeOf child Is T Then
                                children.Add(DirectCast(child, T))
                            End If

                            children.AddRange(child.GetDescendants(Of T)())
                        End If

                    Catch ex As Exception

                    End Try

                Next
                Return children
            Else
                Return New List(Of T)()
            End If
        End Function

        ''' <summary>
        ''' Gets children, children's children, etc. from 
        ''' the visual tree that match the specified type and elementName
        ''' </summary>
        <System.Runtime.CompilerServices.Extension>
        Public Function GetDescendants(Of T As UIElement)(parent As DependencyObject, elementName As String) As List(Of T)
            Dim children As New List(Of T)()

            Dim count As Integer = VisualTreeHelper.GetChildrenCount(parent)

            If count > 0 Then
                For i As Integer = 0 To count - 1
                    Try
                        If VisualTreeHelper.GetChild(parent, i).GetType.ToString <> "System.Windows.Controls.TextBoxLineDrawingVisual" Then
                            Dim child As UIElement = DirectCast(VisualTreeHelper.GetChild(parent, i), UIElement)

                            If TypeOf child Is T AndAlso (TypeOf child Is FrameworkElement) AndAlso TryCast(child, FrameworkElement).Name = elementName Then
                                children.Add(DirectCast(child, T))
                            End If

                            children.AddRange(child.GetDescendants(Of T)(elementName))
                        End If

                    Catch ex As Exception

                    End Try

                Next
                Return children
            Else
                Return New List(Of T)()
            End If
        End Function

        ''' <summary>
        ''' Gets the first child, child's child, etc. 
        ''' from the visual tree that matches the specified type
        ''' </summary>
        <System.Runtime.CompilerServices.Extension>
        Public Function GetDescendant(Of T As UIElement)(parent As DependencyObject) As T
            Dim descendants As List(Of T) = parent.GetDescendants(Of T)()

            If descendants.Count > 0 Then
                Return descendants(0)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the first child, child's child, etc. from 
        ''' the visual tree that matches the specified type and elementName
        ''' </summary>
        <System.Runtime.CompilerServices.Extension>
        Public Function GetDescendant(Of T As UIElement)(parent As DependencyObject, elementName As String) As T
            Dim descendants As List(Of T) = parent.GetDescendants(Of T)(elementName)

            If descendants.Count > 0 Then
                Return descendants(0)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the first parent, parent's parent, etc. from the 
        ''' visual tree that matches the specified type
        ''' </summary>
        <System.Runtime.CompilerServices.Extension>
        Public Function GetAntecedent(Of T As UIElement)(root As DependencyObject) As T
            If root Is Nothing Then
                Return Nothing
            End If
            If TypeOf root Is T Then
                Return DirectCast(root, T)
            Else
                Dim parent As DependencyObject = VisualTreeHelper.GetParent(root)
                If parent Is Nothing Then
                    Return Nothing
                Else
                    Return parent.GetAntecedent(Of T)()
                End If
            End If
        End Function

        ''' <summary>
        ''' Gets the first parent, parent's parent, etc. from the 
        ''' visual tree that matches the specified type and elementName
        ''' </summary>
        <System.Runtime.CompilerServices.Extension>
        Public Function GetAntecedent(Of T As UIElement)(root As DependencyObject, elementName As String) As T
            If root Is Nothing Then
                Return Nothing
            End If
            If TypeOf root Is T AndAlso (TypeOf root Is FrameworkElement) AndAlso TryCast(root, FrameworkElement).Name = elementName Then
                Return DirectCast(root, T)
            Else
                Dim parent As DependencyObject = VisualTreeHelper.GetParent(root)
                If parent Is Nothing Then
                    Return Nothing
                Else
                    Return parent.GetAntecedent(Of T)(elementName)
                End If
            End If
        End Function

        <System.Runtime.CompilerServices.Extension>
        Public Iterator Function FindVisualChildrens(Of T As DependencyObject)(ByVal depObj As DependencyObject) As IEnumerable(Of T)
            If depObj IsNot Nothing Then
                For i As Integer = 0 To VisualTreeHelper.GetChildrenCount(depObj) - 1
                    Dim child As DependencyObject = VisualTreeHelper.GetChild(depObj, i)
                    If child IsNot Nothing AndAlso TypeOf child Is T Then
                        Yield CType(child, T)
                    End If

                    For Each childOfChild As T In FindVisualChildrens(Of T)(child)
                        Yield childOfChild
                    Next
                Next
            End If
        End Function

        <System.Runtime.CompilerServices.Extension>
        Public Function GetChildrenByType(Of T As UIElement)(element As UIElement, condition As Func(Of T, Boolean)) As List(Of T)
            Dim results = New List(Of T)()
            GetChildrenByType1(element, condition, results)
            Return results
        End Function

        <System.Runtime.CompilerServices.Extension>
        Private Sub GetChildrenByType1(Of T As UIElement)(element As UIElement, condition As Func(Of T, Boolean), results As List(Of T))
            For i As Integer = 0 To VisualTreeHelper.GetChildrenCount(element) - 1
                Dim child = TryCast(VisualTreeHelper.GetChild(element, i), UIElement)
                If child IsNot Nothing Then
                    Dim ct = TryCast(child, T)
                    If ct IsNot Nothing Then
                        If condition Is Nothing Then
                            results.Add(ct)
                        ElseIf condition(ct) Then
                            results.Add(ct)
                        End If
                    End If
                    GetChildrenByType1(child, condition, results)
                End If
            Next
        End Sub


        <System.Runtime.CompilerServices.Extension>
        Public Function Descendents(root As DependencyObject) As IEnumerable(Of DependencyObject)
            Dim count As Integer = VisualTreeHelper.GetChildrenCount(root)
            For i As Integer = 0 To count - 1
                Dim child As DependencyObject = VisualTreeHelper.GetChild(root, i)
                If child.GetType.ToString <> "System.Windows.Controls.Grid" Then
                    Return child
                End If

                For Each descendent As DependencyObject In Descendents(child)
                    Return descendent
                Next
            Next
        End Function

        <System.Runtime.CompilerServices.Extension>
        Public Function FindVisualParent(Of T As DependencyObject)(child As DependencyObject) As T
            ' get parent item
            Dim parentObject As DependencyObject = VisualTreeHelper.GetParent(child)

            ' we’ve reached the end of the tree
            If parentObject Is Nothing Then
                Return Nothing
            End If

            ' check if the parent matches the type we’re looking for
            Dim parent As T = TryCast(parentObject, T)
            If parent IsNot Nothing Then
                Return parent
            Else
                ' use recursion to proceed with next level
                Return FindVisualParent(Of T)(parentObject)
            End If
        End Function

        <System.Runtime.CompilerServices.Extension>
        Public Function FindChild(Of T As DependencyObject)(parent As DependencyObject, childName As String) As T
            ' Confirm parent and childName are valid. 
            If parent Is Nothing Then
                Return Nothing
            End If

            Dim foundChild As T = Nothing

            Dim childrenCount As Integer = VisualTreeHelper.GetChildrenCount(parent)
            For i As Integer = 0 To childrenCount - 1
                Dim child = VisualTreeHelper.GetChild(parent, i)
                ' If the child is not of the request child type child
                Dim childType As T = TryCast(child, T)
                If childType Is Nothing Then
                    ' recursively drill down the tree
                    foundChild = FindChild(Of T)(child, childName)

                    ' If the child is found, break so we do not overwrite the found child. 
                    If foundChild IsNot Nothing Then
                        Exit For
                    End If
                ElseIf Not String.IsNullOrEmpty(childName) Then
                    Dim frameworkElement = TryCast(child, FrameworkElement)
                    ' If the child's name is set for search
                    If frameworkElement IsNot Nothing AndAlso frameworkElement.Name = childName Then
                        ' if the child's name is of the request name
                        foundChild = DirectCast(child, T)
                        Exit For
                    End If
                Else
                    ' child element found.
                    foundChild = DirectCast(child, T)
                    Exit For
                End If
            Next

            Return foundChild
        End Function
    End Module



End Namespace