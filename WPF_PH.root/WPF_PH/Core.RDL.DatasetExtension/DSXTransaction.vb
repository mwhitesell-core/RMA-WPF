Option Explicit On

Imports Microsoft.ReportingServices.DataProcessing

Public Class DSXTransaction
    Implements IDbTransaction 'ToDo: Add Implements Clauses for implementation methods of these interface(s)

    Public Sub New()
    End Sub

    Public Sub Commit() Implements Microsoft.ReportingServices.DataProcessing.IDbTransaction.Commit
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
    End Sub

    Public Sub Rollback() Implements Microsoft.ReportingServices.DataProcessing.IDbTransaction.Rollback
    End Sub

End Class 'DSXTransaction
