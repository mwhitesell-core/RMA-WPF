Imports System.ComponentModel

Namespace Core.Windows.UI

    'Custom Attribute to determine if a property is loaded from the dictionary
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: LoadDictionary
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of LoadDictionary.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/22/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <AttributeUsage(AttributeTargets.Property), _
    EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
    Friend Class LoadDictionary
        Inherits System.Attribute

        'Private fields.
        Private m_blnLoadDictionary As Boolean = False

        ''' --- New ----------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of New.
        ''' </summary>
        ''' <param name="value"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Sub New(ByVal value As Boolean)
            m_blnLoadDictionary = value
        End Sub

        ''' --- Load ---------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Load.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public ReadOnly Property Load() As Boolean
            Get
                Return m_blnLoadDictionary
            End Get
            'Set(ByVal Value As Boolean)
            '    Me.m_blnLoadDictionary = Value
            'End Set
        End Property

    End Class

    ''Custom Attribute to determine if a property is has been loaded from the dictionary
    '<AttributeUsage(AttributeTargets.Property)> Friend Class DictionaryOverRidden
    '    Inherits System.Attribute

    '    'Private fields.
    '    Private m_blnOverridden As Boolean = False

    '    Public Sub New(ByVal value As Boolean)
    '        m_blnOverridden = value
    '    End Sub

    '    Public Property Overridden() As Boolean
    '        Get
    '            Return m_blnOverridden
    '        End Get
    '        Set(ByVal Value As Boolean)
    '            Me.m_blnOverridden = Value
    '        End Set
    '    End Property
    'End Class

End Namespace