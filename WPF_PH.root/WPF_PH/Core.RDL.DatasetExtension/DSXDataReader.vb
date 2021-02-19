Option Explicit On

Imports System.IO
Imports System.Reflection
Imports System.Security

Public Class DSXDataReader
    Implements Microsoft.ReportingServices.DataProcessing.IDataReader

    Private m_cmdText As String = String.Empty
    Private m_connection As DSXConnection
    Private m_currentRow As Integer = 0
    Private m_fieldCount As Integer = 0
    Private m_fieldName As String = String.Empty
    Private m_fieldOrdinal As Integer = 0
    Private m_fieldType As Type
    Private m_fieldValue As Object
    Private m_ds As DataSet = Nothing
    Private m_projectName As String = String.Empty
    Private m_strReportAssembly As String = String.Empty

    Private Const c_DLL As String = ".dll"

    ' Default constructor
    Friend Sub New()

    End Sub 'New

    'Command text constructor overload.
    Friend Sub New(ByVal cmdText As String)

        m_cmdText = cmdText

    End Sub 'New

    ' Implemented. Will be called
    ' by the Report Server to 
    ' return DataSet data.
    Public Function Read() As Boolean Implements Microsoft.ReportingServices.DataProcessing.IDataReader.Read

        m_currentRow += 1
        If m_currentRow >= m_ds.Tables(0).Rows.Count Then
            Return False
        Else
            Return True
        End If

    End Function

    Public ReadOnly Property FieldCount() As Integer Implements Microsoft.ReportingServices.DataProcessing.IDataReader.FieldCount
        Get
            If Not m_ds Is Nothing Then
                m_fieldCount = m_ds.Tables(0).Columns.Count
            End If

            Return m_fieldCount
        End Get
    End Property

    Public Function GetName(ByVal i As Integer) As String Implements Microsoft.ReportingServices.DataProcessing.IDataReader.GetName

        m_fieldName = m_ds.Tables(0).Columns(i).ColumnName
        Return m_fieldName

    End Function

    Public Function GetFieldType(ByVal i As Integer) As Type Implements Microsoft.ReportingServices.DataProcessing.IDataReader.GetFieldType

        m_fieldType = m_ds.Tables(0).Columns(i).DataType
        Return m_fieldType

    End Function

    Public Function GetValue(ByVal i As Integer) As [Object] Implements Microsoft.ReportingServices.DataProcessing.IDataReader.GetValue

        m_fieldValue = m_ds.Tables(0).Rows(Me.m_currentRow)(i)
        Return m_fieldValue

    End Function

    Public Function GetOrdinal(ByVal name As String) As Integer Implements Microsoft.ReportingServices.DataProcessing.IDataReader.GetOrdinal

        m_fieldOrdinal = m_ds.Tables(0).Columns(name).Ordinal
        Return m_fieldOrdinal

    End Function

    Friend Sub CreateDataSet(ByVal strConnection As DSXConnection, ByVal colParameters As DSXParameterCollection,
                             ByVal strReportAssembly As String)

        Dim currentAssembly As [Assembly] = Nothing
        Dim assemblyType As Type = Nothing
        Dim strTypes() As Type = Nothing
        Dim objReportData As Object = Nothing

        Dim intCount As Integer = 0

        Dim strReportName As String = String.Empty
        Dim strConnString As String = String.Empty

        Dim arrParameters(colParameters.ElementCount) As String

        Try
            ' We need to determine which report class to call
            ' based on the report passed in (strReportParameters).

            If blnDebug Then
                rptManager.WriteToLogFile(vbTab + "Start DataReader")
                rptManager.WriteToLogFile(vbTab + vbTab + "Create DataSet")
            End If

            strReportName = m_cmdText

            If ReportAssemblyExists(strReportAssembly, arrParameters) Then
                If blnDebug Then
                    rptManager.WriteToLogFile(vbTab + vbTab + vbTab + "ReportAssembly Exists - " + m_strReportAssembly)
                End If

                Try
                    currentAssembly = [Assembly].LoadFrom(m_strReportAssembly)
                    If blnDebug Then
                        rptManager.WriteToLogFile(vbTab + vbTab + vbTab + "ReportAssembly Loaded - " + currentAssembly.FullName)
                    End If

                    strTypes = currentAssembly.GetTypes
                    assemblyType = currentAssembly.GetType

                    For intCount = 0 To UBound(strTypes)
                        If strTypes(intCount).Name = strReportName Then
                            assemblyType = strTypes(intCount)
                            Exit For
                        End If
                    Next

                Catch fnf As FileNotFoundException
                    If blnDebug Then
                        rptManager.WriteToLogFile(vbTab + vbTab + vbTab + "ERROR: File Not Found - " + m_strReportAssembly + " --> " + fnf.Message())
                    End If
                Catch fl As FileLoadException
                    If blnDebug Then
                        rptManager.WriteToLogFile(vbTab + vbTab + vbTab + "ERROR: Could not load file - " + m_strReportAssembly + " --> " + fl.Message())
                    End If
                Catch se As SecurityException
                    If blnDebug Then
                        rptManager.WriteToLogFile(vbTab + vbTab + vbTab + "ERROR: Wrong web permission - " + m_strReportAssembly)
                    End If
                Catch ae As ArgumentException
                    If blnDebug Then
                        rptManager.WriteToLogFile(vbTab + vbTab + vbTab + "ERROR: Assembly file parameter is an empty string - " + m_strReportAssembly + " --> " + ae.Message())
                    End If
                Catch ex As Exception
                    If blnDebug Then
                        rptManager.WriteToLogFile(vbTab + vbTab + vbTab + "ERROR: General exception - " + m_strReportAssembly + " --> " + ex.Message())
                    End If
                End Try

                If Not assemblyType Is Nothing Then
                    If blnDebug Then
                        rptManager.WriteToLogFile(vbTab + vbTab + "Create Instance - " + assemblyType.FullName)
                    End If

                    objReportData = CType(Activator.CreateInstance(assemblyType), Object)

                    If blnDebug Then
                        rptManager.WriteToLogFile(vbTab + vbTab + vbTab + "Created New Instance - " + assemblyType.FullName)
                    End If

                    For intCount = 0 To (colParameters.ElementCount)
                        arrParameters(intCount) = colParameters(intCount).Value

                        If blnDebug Then
                            rptManager.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + "Parameter Value - " + arrParameters(intCount).ToString)
                        End If
                    Next

                    strConnString = strConnection.ValidateConnectString()

                    If blnDebug Then
                        rptManager.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + "Connection String - " + strConnString)
                    End If

                    Try
                        If blnDebug Then
                            rptManager.WriteToLogFile(vbTab + vbTab + vbTab + "Call GetDataSet in report")
                        End If
                        m_ds = objReportData.GetDataSet(strConnString, arrParameters, m_strReportAssembly, blnDebug)

                        If blnDebug Then
                            rptManager.WriteToLogFile(vbTab + vbTab + vbTab + "Retrieved DataSet")
                        End If

                    Catch ex As Exception
                        If blnDebug Then
                            rptManager.WriteToLogFile(vbTab + vbTab + vbTab + "Error - " + ex.Message)
                        End If
                    End Try
                End If
            Else
                If blnDebug Then
                    rptManager.WriteToLogFile(vbTab + vbTab + vbTab + "ReportAssembly Not Found - " + m_strReportAssembly)
                End If
            End If

        Catch e As Exception
            If blnDebug Then
                rptManager.WriteToLogFile(vbTab + "ERROR - DSXDataReader:CreateDataSet")
                rptManager.WriteToLogFile(vbTab + vbTab + e.Message.ToString)
            End If


            Throw New Exception(e.Message)

        Finally
            currentAssembly = Nothing

        End Try

        ' Set the current row to -1 to prepare for reading.
        m_currentRow = -1

        If blnDebug Then
            rptManager.WriteToLogFile(vbTab + "End DataReader")
        End If

    End Sub

    Private Function ParseCmdText() As String
        'Check format of command text.
        Return m_cmdText
    End Function

    Private Function ReportAssemblyExists(ByRef strReportAssembly As String, ByRef arrParameters() As String) As Boolean

        Dim blnExists As Boolean = False
        Dim strValue As String = String.Empty

        Try
            strReportAssembly = strReportAssembly.Replace("&amp;", Chr(38).ToString)

            If Not strReportAssembly.EndsWith(c_DLL) Then
                m_strReportAssembly = strReportAssembly + c_DLL
            Else
                m_strReportAssembly = strReportAssembly
            End If

            blnExists = File.Exists(m_strReportAssembly)

        Catch ex As Exception
            Throw New Exception(ex.Message)

        End Try

        Return blnExists

    End Function

    Public Sub Dispose() Implements IDisposable.Dispose
    End Sub

End Class 'DSXDataReader

