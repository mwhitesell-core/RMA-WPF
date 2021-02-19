Imports Microsoft.Win32
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.IO
Imports System.Reflection
Imports System.Security
Imports System.Security.Permissions
Imports System.Threading
Imports System.Xml
Imports System.Xml.XmlNode

Namespace Core.ReportFramework

    Public Class Dictionary
#Region "Declarations"

#Region "Variables"

        Private Const el_ELEMENT_NAME As Integer = 0
        Private Const el_ALTERNATE_ELEMENT_NAME As Integer = 1
        Private Const el_BWZ_FLAG As Integer = 2
        Private Const el_DECIMAL_POSITION As Integer = 3
        Private Const el_ELEMENT_SIZE As Integer = 4
        Private Const el_ELEMENT_TYPE_CODE As Integer = 5
        Private Const el_HEADING As Integer = 6
        Private Const el_FILL As Integer = 7
        Private Const el_FLOAT_VALUE As Integer = 8
        Private Const el_DATE_FORMAT_CODE As Integer = 9
        Private Const el_LABEL As Integer = 10
        Private Const el_HELP As Integer = 11
        Private Const el_INITIAL_VALUE As Integer = 12
        Private Const el_INPUT_SCALE As Integer = 13
        Private Const el_OUTPUT_SCALE As Integer = 14
        Private Const el_ITEM_DATATYPE_CODE As Integer = 15
        Private Const el_ITEM_SIZE As Integer = 16
        Private Const el_LEADING_SIGN As Integer = 17
        Private Const el_PATTERN_VALUE As Integer = 18
        Private Const el_PICTURE As Integer = 19
        Private Const el_SHIFTINPUT_CODE As Integer = 20
        Private Const el_SEPARATOR As Integer = 21
        Private Const el_SIGNIFICANCE As Integer = 22
        Private Const el_TRAILING_SIGN As Integer = 23
        Private Const el_DESCRIPTION As Integer = 24
        Private Const el_VALUES As Integer = 25
        Private Const el_CONTROLTYPE As Integer = 26
        Private Const el_LABELISHYPERLINK As Integer = 27
        Private Const el_LABELURL As Integer = 28
        Private Const el_DISPLAYCLASS As Integer = 29
        Private Const el_USAGE As Integer = 30

#End Region

#End Region

#Region "Methods"

#Region "Private"

        '<FileIOPermissionAttribute(SecurityAction.Assert)> _
        <SecuritySafeCritical>
        Private Function ReadXMLFile(fileName As String) As XmlDocument

            Dim FileIOPermission As New FileIOPermission(PermissionState.Unrestricted)
            Dim xmlDocName As String = fileName

            Try
                FileIOPermission.Assert()

                Dim xmlDoc As XmlDocument = New XmlDocument()
                xmlDoc.Load(xmlDocName)

                Return xmlDoc

            Catch ex As Exception
                Return Nothing

            End Try

        End Function

#End Region

#Region "Public"

        '<FileIOPermissionAttribute(SecurityAction.Assert)> _
        <SecuritySafeCritical>
        Public Function ColumnHeader(ByVal Project As String, ByVal elementName As String, ByVal language As String) As String

            Dim FileIOPermission As New FileIOPermission(PermissionState.Unrestricted)

            Dim EnglishlanguageCulture As String = String.Empty
            Dim FrenchlanguageCulture As String = String.Empty
            Dim key As String = String.Empty
            Dim languageCulture As String = String.Empty
            Dim pathOfReportingServices As String = String.Empty
            Dim value As String = String.Empty

            Dim xmlDoc As New XmlDocument

            Try
                FileIOPermission.Assert()

                If Assembly.GetExecutingAssembly().Location.IndexOf("Reporting Services") > -1 Then
                    pathOfReportingServices = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location.Substring(0, Assembly.GetExecutingAssembly().Location.IndexOf("Reporting Services"))) & "\Reporting Services\ReportServer\bin\"
                Else
                    pathOfReportingServices = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
                End If

                If Not pathOfReportingServices.EndsWith("\") Then
                    pathOfReportingServices += "\"
                End If

                xmlDoc.Load(pathOfReportingServices & cREPORT_CONFIG)

                Dim Parent As XmlElement = xmlDoc.DocumentElement
                Dim Child As XmlElement

                For Each Child In Parent
                    key = Child.Attributes("key").Value
                    value = Child.Attributes("value").Value

                    If Parent.Name.Trim.ToUpper = "APPSETTINGS" Then
                        Select Case key
                            Case "EnglishCulture"
                                If value.Length > 0 Then
                                    EnglishlanguageCulture = value
                                End If
                            Case "FrenchCulture"
                                If value.Length > 0 Then
                                    FrenchlanguageCulture = value
                                End If
                        End Select
                    End If
                Next

                If language = "EN" Then
                    languageCulture = EnglishlanguageCulture
                ElseIf language = "FR" Then
                    languageCulture = FrenchlanguageCulture
                End If

                xmlDoc = New XmlDocument()
                xmlDoc = ReadXMLFile(pathOfReportingServices & "Dictionary\" & Project & "\" & languageCulture & "\Dictionary_" & languageCulture & ".xml")

                Dim rootNode As XmlElement = xmlDoc.DocumentElement
                Dim query As String = "Element[@ELEMENT_NAME='" & elementName & "']"
                Dim elements As XmlNodeList = rootNode.SelectNodes(query)

                'Should only be 1 element in elements. Get the column heading.
                For Each element As XmlElement In elements
                    value = element.GetAttribute("HEADING")
                Next

            Catch ex As Exception
                value = String.Empty

            End Try

            Return value.Replace("^", vbCrLf)

        End Function

#End Region

#End Region

    End Class

End Namespace
