Imports System.ComponentModel


Namespace Core.Windows.UI
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: DropDownItemCollection
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of DropDownItemCollection.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
    Public Class DropDownItemCollection
        Inherits ArrayList

        ''' --- New ----------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of the DropDownItemCollection class.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Sub New()
            MyBase.New (10)
        End Sub

        ''' --- Add ----------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Adds a new DropDown Item to the Collection.
        ''' </summary>
        ''' <param name="Text">A String representing the key in a key-value collection.</param>
        ''' <param name="Value">A String representing the value in a key-value collection.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Overloads Function Add (ByVal Text As String, ByVal Value As String)
            Me.Add (New DropDownItem (Text, Value))
            Return Nothing
        End Function

        ''' --- Add ----------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Adds a new DropDown Item to the Collection.
        ''' </summary>
        ''' <param name="Text">A String representing the key in a key-value collection.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Overloads Function Add (ByVal Text As String)
            Me.Add (New DropDownItem (Text))
            Return Nothing
        End Function

        ''' --- Add ----------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Adds an existing DropDown Item to the current Collection.
        ''' </summary>
        ''' <param name="DropDownItem">An existing DropDownItem.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Overloads Function Add (ByVal DropDownItem As DropDownItem)
            MyBase.Add (DropDownItem)
            Return Nothing
        End Function

        ''' --- Item ---------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Item.
        ''' </summary>
        ''' <param name="index"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Default Public Shadows Property Item (ByVal index As Integer) As DropDownItem
            Get
                Return CType (MyBase.Item (index), DropDownItem)
            End Get
            Set (ByVal Value As DropDownItem)
                MyBase.Item (index) = Value
            End Set
        End Property

        ''' --- Text ---------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	The Value associated with the Text value in the DropDownItem.
        ''' </summary>
        ''' <param name="DropDownValue">A String containing the Text to search for.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property Text (ByVal DropDownValue As String) As String
            Get
                For intItem As Integer = 0 To Me.Count - 1
                    If Item (intItem).Value.Trim.Equals (DropDownValue.Trim) Then
                        Return Item (intItem).Text
                    End If
                Next
                Return String.Empty
            End Get
        End Property
    End Class

    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: DropDownItem
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of DropDownItem.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
    Public Class DropDownItem
        Private m_strText As String
        Private m_strValue As String

        ''' --- New ----------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of New.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Sub New()
            m_strText = String.Empty
            m_strValue = String.Empty
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of New.
        ''' </summary>
        ''' <param name="Text"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Sub New (ByVal Text As String)
            m_strText = Text
            m_strValue = Text
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of New.
        ''' </summary>
        ''' <param name="Text"></param>
        ''' <param name="Value"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Sub New (ByVal Text As String, ByVal Value As String)
            m_strText = Text
            m_strValue = Value
        End Sub

        ''' --- Text ---------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Text.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Property Text() As String
            Get
                Return m_strText
            End Get
            Set (ByVal Value As String)
                m_strText = Value
            End Set
        End Property

        ''' --- Value --------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Value.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Property Value() As String
            Get
                Return m_strValue
            End Get
            Set (ByVal Value As String)
                m_strValue = Value
            End Set
        End Property
    End Class
End Namespace
