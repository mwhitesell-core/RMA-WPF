Option Explicit On

Imports Microsoft.ReportingServices.DataProcessing

Public Class DSXParameter
    Implements IDataParameter

    Private m_parameterName As String
    Private m_parameterValue As Object

    ' Default constructor
    Public Sub New()
    End Sub 'New

    ' Constructor to accept parameter name & value.
    Public Sub New(ByVal parameterName As String, ByVal value As Object)
        m_parameterName = parameterName
        m_parameterValue = value
    End Sub 'New

    Public Property ParameterName() As [String] Implements Microsoft.ReportingServices.DataProcessing.IDataParameter.ParameterName
        Get
            Return m_parameterName
        End Get
        Set(ByVal Value As [String])
            m_parameterName = Value
        End Set
    End Property

    Public Property Value() As Object Implements Microsoft.ReportingServices.DataProcessing.IDataParameter.Value
        Get
            Return m_parameterValue
        End Get
        Set(ByVal Value As Object)
            m_parameterValue = Value
        End Set
    End Property

End Class 'DSXParameter

