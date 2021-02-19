Imports System.ComponentModel
Imports Core.Framework.Core.Framework

Namespace Core.Windows
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: PageStateEventArgs
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of PageStateEventArgs.
    ''' </summary>
    ''' <remarks>Inherited from EventArgs however no members at present
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/22/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
    Public Class PageStateEventArgs
        Inherits EventArgs

        Public InFieldId As String
        Public IncludeObjectState As ObjectState

        ''' --- New ----------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        '''     Initializes a new instance of an PageStateEventArgs class.
        ''' </summary>
        ''' <param name="InField"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/12/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Sub New (ByVal InField As String)
            MyBase.New()
            InFieldId = InField
            IncludeObjectState = ObjectState.FileObjectsAndCoreBaseTypes
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        '''     Initializes a new instance of an PageStateEventArgs class.
        ''' </summary>
        ''' <param name="InField"></param>
        ''' <param name="ObjectsToSaveRetrieve"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/12/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Sub New (ByVal InField As String, ByVal ObjectsToSaveRetrieve As ObjectState)
            MyBase.New()
            InFieldId = InField
            IncludeObjectState = ObjectsToSaveRetrieve
        End Sub
    End Class
End Namespace
