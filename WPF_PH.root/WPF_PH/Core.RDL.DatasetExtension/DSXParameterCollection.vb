Option Explicit On

Imports Microsoft.ReportingServices.DataProcessing

'DSXParameterCollection inherits from ArrayList - 
'Microsoft.ReportingServices.DataProcessing.IDataParameterCollection 
'is like System.Data.IDataParameterCollection in that it is 
'essentially an IList. It makes sense to use an existing class 
'to provide the majority of the implementation.

Public Class DSXParameterCollection
    Inherits ArrayList
    Implements IDataParameterCollection

    ' Default constructor
    Public Sub New()
    End Sub 'New

    ' ArrayList Item property.
    Default Public Overloads Property Item(ByVal index As String) As Object
        Get
            Return Me(IndexOf(index))
        End Get
        Set(ByVal Value As Object)
            Me(IndexOf(index)) = Value
        End Set
    End Property

    ' ArrayList Count property.
    Public Overloads ReadOnly Property ElementCount() As Integer
        Get
            Return (MyBase.Count() - 1)
        End Get
    End Property

    ' ArrayList Add method - implemented.
    Public Overloads Function Add(ByVal value As IDataParameter) As Integer Implements Microsoft.ReportingServices.DataProcessing.IDataParameterCollection.Add
        If Not (CType(value, DSXParameter).ParameterName Is Nothing) Then
            Return MyBase.Add(value)
        Else
            Throw New ArgumentException("Your parameter must be named.")
        End If
    End Function

    Public Overloads Function Add(ByVal parameterName As String, ByVal value As Object) As Integer

        Return MyBase.Add(New DSXParameter(parameterName, value))

    End Function

End Class 'DSXParameterCollection
