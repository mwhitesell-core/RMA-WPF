#Region "  Imports  "

Imports System.ComponentModel
Imports System.Windows
Imports System.Windows.Controls
Imports Core.Framework.Core.Framework
Imports System.Drawing
Imports System.Collections.Specialized
Imports System.Text
Imports System.Xml
Imports System.Reflection
Imports System.IO
Imports Core.Framework
Imports ResourceTypes = Core.Globalization.Core.Globalization.ResourceTypes
Imports System.Windows.Visibility
#End Region

Namespace Core.Windows.UI

    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: Label
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of Label.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/22/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
    Public Class TextBlock : Inherits System.Windows.Controls.TextBox

        Sub New()
            MyBase.New()
            SetResourceReference(StyleProperty, "CoreTextBlockStyle")
            IsTabStop = False
            SetValue(ToolTipService.IsEnabledProperty, False)
        End Sub

        Private _textkey As string
         Public Property TextKey() As String
            Get
                Return _textkey
            End Get
            Set(value As String)
                If _textkey <> value Then
                    _textkey = value
                End If
            End Set
        End Property

    End Class

End Namespace