Option Explicit On
Option Strict On

Imports System.ComponentModel

Namespace Core.Framework
    ''' --- GetNewRecordStatus -------------------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of GetNewRecordStatus.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
    Public Delegate Function GetNewStatus() As Boolean

    ''' --- GetFileType -------------------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of GetFileType.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
    Public Delegate Function GetFileType() As FileTypes

    ''' --- Getter -------------------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of Getter.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
    Public Delegate Function Getter (ByVal Sender As Object, ByVal GetterArgs As GetterArgs) As Boolean

    ''' --- Setter -------------------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of Setter.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
    Public Delegate Function Setter (ByVal Sender As Object, ByVal SetterArgs As SetterArgs) As Boolean

    ''' --- SetEditFlag -------------------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of SetEditFlag.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
    Public Delegate Function SetEditFlag (ByVal Field As String) As Boolean

    'BaseGetterSeterArgs is the base class for GetterArgs and SetterArgs, and should not be used directly
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: BaseGetterSetterArgs
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of BaseGetterSetterArgs.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
    Public Class BaseGetterSetterArgs
        Inherits EventArgs
        Implements IDisposable

        ''' --- DatabaseName -------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of DatabaseName.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> Public DatabaseName As String

        ''' --- TableName ----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of TableName.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> Public TableName As String

        ''' --- ColumnName ---------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of ColumnName.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> Public ColumnName As String

        ''' --- FieldText ----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of FieldText.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Public FieldText As String

        <EditorBrowsable(EditorBrowsableState.Advanced)> Public FieldDate As String

        ''' --- FieldValue ---------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of FieldValue.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> Public FieldValue As Decimal

        ''' --- PageMode -----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of PageMode.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> Public PageMode As PageModeTypes

        ''' --- IsRequest -----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of IsRequest.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> Public IsRequest As Boolean = False

        ''' --- DataType -----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of DataType.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> Public DataType As DataTypes

        ''' --- DataType -----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of DataType.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> Public UnderlyingDataType As DataTypes

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
            If (Not Me.Disposed) AndAlso Disposing Then
                DatabaseName = Nothing
                TableName = Nothing
                ColumnName = Nothing
                FieldText = Nothing
                PageMode = Nothing
                DataType = Nothing
            End If
            Disposed = True
        End Sub

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
        End Sub
    End Class

    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: GetterArgs
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of GetterArgs.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
    Public Class GetterArgs
        Inherits BaseGetterSetterArgs
        'If we ever need to extend Getter Specific argument, implement it in GetterArgs
    End Class

    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: SetterArgs
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of SetterArgs.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
    Public Class SetterArgs
        Inherits BaseGetterSetterArgs
        'If we ever need to extend Getter Specific argument, implement it in GetterArgs
    End Class
End Namespace

