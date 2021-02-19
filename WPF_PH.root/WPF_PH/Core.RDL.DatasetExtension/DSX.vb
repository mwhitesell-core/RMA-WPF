
Imports System.IO
Imports System.Xml

Public Module DSX

    Public strProject As String = String.Empty
    Public strCmdText As String = String.Empty
    Public strConfiguration As String = String.Empty
    Public strReportAssembly As String = String.Empty
    Public strLogFile As String = String.Empty
    Public strStatistics As String = String.Empty

    Public blnDebug As Boolean = False

    Public rptManager As LogManager = Nothing

    Public Sub InitializeExtension(ByVal strText As String)

        Dim arrText() As String
        Dim strName As String = String.Empty
        Dim strValue As String = String.Empty

        Dim intCount As Integer = 0

        Dim xmlDoc As New XmlDocument
        Dim xmlReader As TextReader

        arrText = strText.Split("~")

        If arrText.GetUpperBound(0) = 1 Then
            strProject = arrText(0).ToString
            strCmdText = arrText(1).ToString
        Else
            strCmdText = arrText(0).ToString
        End If

        Try
            xmlReader = New StringReader(strConfiguration)
            xmlDoc.Load(xmlReader)

            Dim Parent As XmlElement = xmlDoc.DocumentElement
            Dim eleDataChild As XmlElement = xmlDoc.DocumentElement
            Dim eleProjectChild As XmlElement = xmlDoc.DocumentElement
            Dim eleChild As XmlElement = xmlDoc.DocumentElement

            For Each eleDataChild In Parent
                If Parent.Name.Trim.ToUpper = "EXTENSIONDATA" Then
                    For Each eleProjectChild In eleDataChild
                        If eleDataChild.Name.Trim.ToUpper = "PROJECTS" Then
                            For Each eleChild In eleProjectChild
                                If eleProjectChild.Name.Trim.ToUpper = strProject.ToUpper Then
                                    strName = eleChild.Name
                                    strValue = eleChild.InnerXml

                                    Select Case strName
                                        Case "ReportAssemblyPath"
                                            strReportAssembly = strValue

                                        Case "LogFile"
                                            strLogFile = strValue

                                        Case "Debug"
                                            blnDebug = CType(strValue, Boolean)

                                        Case "Statistics"
                                            strStatistics = strValue

                                    End Select
                                End If
                            Next
                        End If
                    Next
                End If
            Next

        Catch ex As Exception

        End Try

    End Sub

End Module
