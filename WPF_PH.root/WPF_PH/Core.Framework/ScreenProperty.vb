Imports System.ComponentModel
Imports System.Xml
Imports System.IO

Namespace Core.Framework
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: CoreScreenProperty
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of CoreScreenProperty.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
    Public Class CoreScreenProperty
        Implements IDisposable

        ''' --- hstScreenItems -----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of hstScreenItems.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> Private hstScreenItems As Hashtable

        ''' --- Disposed -----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Disposed.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> Private Disposed As Boolean

        ''' --- New ---------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of New.
        ''' </summary>
        ''' <param name="FileName"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Sub New (ByVal FileName As String)
            hstScreenItems = New Hashtable
            LoadScreensItems (FileName)
        End Sub

        ''' --- LoadScreensItems ---------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of LoadScreensItems.
        ''' </summary>
        ''' <param name="FileName"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Private Sub LoadScreensItems (ByVal FileName As String)
            'Note: Using XmlTextReader, instead of XMLDocument to make the loading faster 
            'At present its not strictly observing the Encoding specifiec in the XML File,
            'XmlTextReader always the default Encoding which is Windows-1252
            Dim objScreenXML As XmlTextReader
            If File.Exists (FileName) Then
                objScreenXML = New XmlTextReader (FileName)
                PopulateScreenItems (objScreenXML)
                objScreenXML.Close()
            End If
            objScreenXML = Nothing
        End Sub

        ''' --- PopulateScreenItems ------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of PopulateScreenItems.
        ''' </summary>
        ''' <param name="ScreenXMLReader"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Private Sub PopulateScreenItems (ByVal ScreenXMLReader As XmlTextReader)
            With ScreenXMLReader
                Dim objScreenItemValues As Hashtable
                Dim strScreenPropertyName As String = String.Empty

                Do While .Read
                    Select Case .NodeType
                        Case XmlNodeType.Element
                            If .Name.ToUpper.Equals ("SCREEN") Then
                                objScreenItemValues = New Hashtable (4)
                                While .MoveToNextAttribute()
                                    Select Case .Name.ToUpper
                                        Case "NAME"
                                            strScreenPropertyName = .Value
                                            objScreenItemValues.Add (ScreenAttributes.Name, strScreenPropertyName)
                                        Case "TOP"
                                            objScreenItemValues.Add (ScreenAttributes.Top, .Value)
                                        Case "LEFT"
                                            objScreenItemValues.Add (ScreenAttributes.Left, .Value)
                                        Case "HEIGHT"
                                            objScreenItemValues.Add (ScreenAttributes.Height, .Value)
                                        Case "WIDTH"
                                            objScreenItemValues.Add (ScreenAttributes.Width, .Value)
                                    End Select
                                End While
                                hstScreenItems.Add (strScreenPropertyName, objScreenItemValues)
                            End If
                    End Select
                Loop
                objScreenItemValues = Nothing
            End With
        End Sub

        ''' --- GetScreenItem ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetScreenItem.
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function GetScreenItem (ByVal Name As String) As CoreScreenItem
            Dim objScreenItem As New CoreScreenItem
            With objScreenItem
                If hstScreenItems.Item (Name) Is Nothing Then
                    Return Nothing
                Else
                    .strName = CStr (CType (hstScreenItems.Item (Name), Hashtable).Item (ScreenAttributes.Name))
                    .strTop = CStr (CType (hstScreenItems.Item (Name), Hashtable).Item (ScreenAttributes.Top))
                    .strLeft = CStr (CType (hstScreenItems.Item (Name), Hashtable).Item (ScreenAttributes.Left))
                    .strHeight = CStr (CType (hstScreenItems.Item (Name), Hashtable).Item (ScreenAttributes.Height))
                    .strWidth = CStr (CType (hstScreenItems.Item (Name), Hashtable).Item (ScreenAttributes.Width))
                    Return objScreenItem
                End If
            End With
        End Function

#Region " Get ScreenProperty Item's Attribute functions "

        ''' --- GetName ------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetName.
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function GetName (ByVal Name As String) As String
            Return CStr (CType (hstScreenItems.Item (Name), Hashtable).Item (ScreenAttributes.Name))
        End Function

        ''' --- GetTop -------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetTop.
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function GetTop (ByVal Name As String) As String
            Return CStr (CType (hstScreenItems.Item (Name), Hashtable).Item (ScreenAttributes.Top))
        End Function

        ''' --- GetLeft ------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetLeft.
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function GetLeft (ByVal Name As String) As String
            Return CStr (CType (hstScreenItems.Item (Name), Hashtable).Item (ScreenAttributes.Left))
        End Function

        ''' --- GetHeight ----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetHeight.
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function GetHeight (ByVal Name As String) As String
            Return CStr (CType (hstScreenItems.Item (Name), Hashtable).Item (ScreenAttributes.Height))
        End Function

        ''' --- GetWidth -----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetWidth.
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function GetWidth (ByVal Name As String) As String
            Return CStr (CType (hstScreenItems.Item (Name), Hashtable).Item (ScreenAttributes.Width))
        End Function

#End Region

#Region " Dispose and Finalize DictionaryItem "

        ' Dispose(Disposing As Boolean) executes in two distinct scenarios.
        ' If Disposing is true, the method has been called directly 
        ' or indirectly by a user's code. Managed and unmanaged resources 
        ' can be Disposed.
        ' If Disposing equals false, the method has been called by the runtime
        ' from inside the finalizer and you should not reference other    
        ' objects. Only unmanaged resources can be Disposed.
        ''' --- Dispose ------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Dispose.
        ''' </summary>
        ''' <param name="Disposing"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected Overridable Overloads Sub Dispose (ByVal Disposing As Boolean)
            ' Check to see if Dispose has already been called.
            If Not (Me.Disposed) Then
                ' If Disposing equals true, dispose all managed 
                ' and unmanaged resources.
                If (Disposing) Then
                    ' Dispose managed resources.
                    hstScreenItems.Clear()
                    hstScreenItems = Nothing
                End If
            End If
            Me.Disposed = True
        End Sub

        ' Implement IDisposable.
        ' Do not make this method Overridable.
        ' A derived class should not be able to override this method.
        ''' --- Dispose ------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Dispose.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Overloads Sub Dispose() Implements IDisposable.Dispose
            Dispose (True)
            ' Take CoreDictionary off of the finalization queue
            ' to prevent finalization code for CoreDictionary
            ' from executing a second time.
            GC.SuppressFinalize (Me)
        End Sub

        ' This Finalize method will run only if the 
        ' Dispose method does not get called.
        ''' --- Finalize -----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Finalize.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected Overrides Sub Finalize()
            ' Do not re-create Dispose clean-up code here.
            ' Calling Dispose(false) is optimal in terms of
            ' readability and maintainability.
            Dispose (False)
        End Sub

#End Region
    End Class

    ''' --- ScreenAttributes ---------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of ScreenAttributes.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
    Public Enum ScreenAttributes As Integer
        ''' --- Name ---------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Name.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
            <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Name = 0
        ''' --- Top ----------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Top.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
            <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Top = 1
        ''' --- Left ---------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Left.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
            <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Left = 2
        ''' --- Height -------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Height.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
            <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Height = 3
        ''' --- Width --------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Width.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
            <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Width = 4
    End Enum

#Region " Screen Item Class "

    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: CoreScreenItem
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' <exclude/>
    ''' <summary>
    ''' 	Summary of CoreScreenItem.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
    Public Class CoreScreenItem
        Implements IDisposable

        ''' --- strName ------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of strName.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> Friend strName As String

        ''' --- strTop -------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of strTop.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> Friend strTop As String

        ''' --- strLeft ------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of strLeft.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> Friend strLeft As String

        ''' --- strHeight ----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of strHeight.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> Friend strHeight As String

        ''' --- strWidth -----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of strWidth.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> Friend strWidth As String

        ' Track whether Dispose has been called.
        ''' --- Disposed -----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Disposed.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> Private Disposed As Boolean = False

        ''' --- Name ---------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Name.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property Name() As String
            Get
                Return strName
            End Get
        End Property

        ''' --- Top ----------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Top.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property Top() As String
            Get
                Return strTop
            End Get
        End Property

        ''' --- Left ---------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Left.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property Left() As String
            Get
                Return strLeft
            End Get
        End Property

        ''' --- Height -------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Height.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property Height() As String
            Get
                Return strHeight
            End Get
        End Property

        ''' --- Width --------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Width.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property Width() As String
            Get
                Return strWidth
            End Get
        End Property

#Region " Dispose and Finalize ScreenItem "

        ' Dispose(Disposing As Boolean) executes in two distinct scenarios.
        ' If Disposing is true, the method has been called directly 
        ' or indirectly by a user's code. Managed and unmanaged resources 
        ' can be Disposed.
        ' If Disposing equals false, the method has been called by the runtime
        ' from inside the finalizer and you should not reference other    
        ' objects. Only unmanaged resources can be Disposed.
        ''' --- Dispose ------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Dispose.
        ''' </summary>
        ''' <param name="Disposing"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected Overridable Overloads Sub Dispose (ByVal Disposing As Boolean)
            ' Check to see if Dispose has already been called.
            If Not (Me.Disposed) Then
                ' If Disposing equals true, dispose all managed 
                ' and unmanaged resources.
                If (Disposing) Then
                    ' Dispose managed resources.
                    strName = Nothing
                    strTop = Nothing
                    strLeft = Nothing
                    strHeight = Nothing
                    strWidth = Nothing
                End If
            End If
            Me.Disposed = True
        End Sub

        ' Implement IDisposable.
        ' Do not make this method Overridable.
        ' A derived class should not be able to override this method.
        ''' --- Dispose ------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Dispose.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Overloads Sub Dispose() Implements IDisposable.Dispose
            Dispose (True)
            ' Take CoreScreenItem off of the finalization queue
            ' to prevent finalization code for CoreScreenItem
            ' from executing a second time.
            GC.SuppressFinalize (Me)
        End Sub

        ' This Finalize method will run only if the 
        ' Dispose method does not get called.
        ''' --- Finalize -----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Finalize.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected Overrides Sub Finalize()
            ' Do not re-create Dispose clean-up code here.
            ' Calling Dispose(false) is optimal in terms of
            ' readability and maintainability.
            Dispose (False)
        End Sub

#End Region
    End Class

#End Region
End Namespace
