Imports Core.ExceptionManagement
Imports System.Security.Cryptography
Imports Core.DataAccess.Oracle
Imports Core.DataAccess.SqlServer
Imports Core.Framework
Imports Core.Framework.Core.Framework
Imports Core.Globalization
Imports System.Web.HttpContext
Imports System.Text
Imports System.IO
Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports System.Configuration
Imports Core.Framework.Core.Windows.Framework

''' ----------------------------------------------------------------------------
''' 
''' Module	: Common
''' 
''' ----------------------------------------------------------------------------
''' 
''' <summary>
''' 	This module contains Public methods, constants, structures, etc...
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[Campbell]	6/16/2005	Created
''' </history>
''' --- End of Comments ----------------------------------------------------
<EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
Public Module Common

    Private strCrLf As String = String.Empty

    Public Const cReplaceChar As String = Chr(30)

    Public Function LineTerminator() As String
        ' For text files created with keep, use carriage return and linefeeds instead of just carriage returns.
        If strCrLf = String.Empty Then
            If System.Configuration.ConfigurationManager.AppSettings("UseCrLf") Is Nothing OrElse
                        System.Configuration.ConfigurationManager.AppSettings("UseCrLf").ToString.ToUpper.Equals("TRUE") Then
                strCrLf = vbNewLine
            Else
                strCrLf = Chr(10)
            End If
        End If
        Return strCrLf
    End Function

    Public Function ReplaceSqlVerb(ByVal Source As String, ByVal Verb As String, ByVal Replace As String) As String

        ' Replace any '' with "~CORE_REPLACE~"
        Const cReplace As String = "~CORE_REPLACE~"

        Source = Source.Replace("''", cReplace)

        ' Match all quotes fields.
        Dim col As MatchCollection = Regex.Matches(Source, "'(.*?)'")

        ' Copy groups to a string array.
        Dim fields(col.Count - 1) As String
        For i As Integer = 0 To fields.Length - 1
            fields(i) = "'" & col(i).Groups(1).Value & "'" ' Index 1 is the first group.
        Next

        ' Remove these from the source to ensure we don't check for the Search value within those strings.
        For i As Integer = 0 To fields.Length - 1
            Source = Source.Replace(fields(i), "{" + i.ToString + "}")
        Next

        Source = Source.Replace(Verb, Replace)

        Source = String.Format(Source, fields)

        Source = Source.Replace(cReplace, "''")

        Return Source

    End Function
    ''' --- JobConnectionString -------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of JobConnectionString.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/29/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public JobConnectionString As String = ""



    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Parms As Object

    ''' --- cEmptyString -------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of cEmptyString.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/29/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Const cEmptyString As String = " "               ' Used for PowerHouse empty string.  If null support available, set to "".

    ''' --- BaseDate -----------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of BaseDate.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/29/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public BaseDate As Date = #12/31/1899#                  ' Used by functions as the base date.

    ''' --- NumericBaseDate ----------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of NumericBaseDate.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/29/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public NumericBaseDate As Decimal = 18991231D            ' Used for the Numeric PowerHouse zero date.

    ''' --- cZeroDate ----------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of cZeroDate.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/29/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Const cZeroDate As Date = #12:00:00 AM#          ' Used for the PowerHouse zero date.

    ''' --- cZeroDecimalDate ----------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of cZeroDecimalDate.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/29/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Const cZeroDecimalDate As Decimal = 10101          ' Used for the PowerHouse zero date.

    ''' --- cNumericZeroDate ---------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of cNumericZeroDate.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/29/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Const cNumericZeroDate As Decimal = 10101D        ' Used for the Numeric PowerHouse zero date.

    ''' --- cNullDate ----------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of cNullDate.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/29/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Const cNullDate As DateTime = #12:00:00 AM#      ' Null date value and zero date ("0001/01/01")

    ''' --- cToolbarDelimiter --------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of cToolbarDelimiter.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/29/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Const cToolbarDelimiter As String = "~"          ' Used to separate toolbar icon from it's data item.

    ''' --- cAddMessageError ---------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of cAddMessageError.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/29/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Const cAddMessageError As String = "Error"       ' Error code indicating AddMessage raised error.

    ''' --- cAddMessageReturn --------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of cAddMessageReturn.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/29/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Const cAddMessageReturn As String = "Return"     ' Error code indicating to close present window and return to calling screen.

    ''' --- cRunScreenException ------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of cRunScreenException.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/29/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Const cRunScreenException As Integer = 1

    ''' --- cMenuRunScreenException ------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of cMenuRunScreenException.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/29/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Const cMenuRunScreenException As Integer = 11

    <EditorBrowsable(EditorBrowsableState.Advanced)>
    Public Const cCancelQTP As Integer = 12

    ''' --- cReturn ------------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of cReturn.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/29/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Const cReturn As Integer = 2

    ''' --- cAcceptRequestPromptException --------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of cAcceptRequestPromptException.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/29/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Const cAcceptRequestPromptException As Integer = 3

    ''' --- cRemoveFlags -------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of cRemoveFlags.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/29/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Const cRemoveFlags As String = "RemoveFlags"

    ''' --- cLookupCharacter ---------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of cLookupCharacter.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/29/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Const cLookupCharacter As String = "LookupCharacter"

    ''' --- cGenericRetrievalCharacter -----------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of cGenericRetrievalCharacter.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/29/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Const cGenericRetrievalCharacter As String = "Generic Retrieval Character"

    ''' --- cDefaultCentury ----------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of cDefaultCentury.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/29/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Const cDefaultCentury As String = "Default Century"

    ''' --- cInputCenturyFrom ----------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of cInputCenturyFrom.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/29/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Const cInputCenturyFrom As String = "Input Century From"

    ''' --- cDefaultDateFormat ----------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of cDefaultDateFormat.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/29/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Const cDefaultDateFormat As String = "Default Date Format"

    Public Const cDefaultDateSeparator As String = "Default Date Separator"

    ''' --- cProcessing --------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of cProcessing.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/29/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Const cProcessing As String = "Processing"

    ''' --- cCollapseMenu ------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of cCollapseMenu.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/29/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Const cCollapseMenu As String = "CollapseMenu"

    ''' --- cUseScaling --------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of cUseScaling.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/29/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Const cUseScaling As String = "Use Scaling"

    ''' --- cProcessLocation ---------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of cProcessLocation.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/29/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Const cProcessLocation As String = "ProcessLocation"       ' Used by ProcessLocation function.

    ''' --- cTitle -------------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of cTitle.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/29/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Const cTitle As String = "Title"                 ' Used by SysName function.

    ''' --- cORACLE ------------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of cORACLE.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/29/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Const cORACLE As String = "Oracle"

    ''' --- cSQL_SERVER --------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of cSQL_SERVER.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/29/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Const cSQL_SERVER As String = "SQL Server"

    ''' --- cINFORMIX --------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of cINFORMIX.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/29/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Const cINFORMIX As String = "Informix"

    ''' --- m_intDefaultCentury ------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of m_intDefaultCentury.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/29/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public m_intDefaultCentury As Integer = 1900

    ''' --- m_intDefaultInputCentury ------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Used when we have a Input Century From as in Input Century 19 From 50.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/29/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public m_intDefaultInputCentury As Integer = 0

    ''' --- m_intDefaultInputFromYear ------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Used when we have a Input Century From as in Input Century 19 From 50.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/29/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public m_intInputFromYear As Integer = 0

    ''' --- m_strGenericRetrievalCharacter -------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of m_strGenericRetrievalCharacter.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/29/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public m_strGenericRetrievalCharacter As String = ""        ' Generic retrieval character.  Default is "@".

    'TODO: cZeroDecimalDateTime, needs to be verified with legacy app
    ''' --- cZeroDecimalDateTime ------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of cZeroDecimalDateTime.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/29/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Const cZeroDecimalDateTime As Int64 = 1010112000000  ' First 8 digit represents Date, last 8 digits represents Time

    'Added for debugging behaviour across the post back, especially
    'can be useful in AcceptProcessiong beside InFieldValidation
    ''' --- m_fsDebugLogStream -------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of m_fsDebugLogStream.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/29/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Private m_fsDebugLogStream As System.IO.FileStream 'Added for Debugging purposes

    ''' --- m_swLogWriter ------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of m_swLogWriter.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/29/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Private m_swLogWriter As StreamWriter              'Added for Debugging purposes

    ''' --- stcMessage ---------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Structure for application messages.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <Serializable(), EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Structure stcMessage
        Dim Type As MessageTypes
        Dim Number As String
        Dim Text As String
    End Structure

    ''' --- CoreDataField ------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of CoreDataField.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Structure CoreDataField
        Public FieldName As String
        Public Value As String
        Public SubmittedValue As String
    End Structure



    ''' --- GetSqlConnectionString ---------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of GetSqlConnectionString.
    ''' </summary>
    ''' <param name="InitialCatalog"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Function GetSqlConnectionString(ByVal InitialCatalog As String) As String

        Dim strConnection As String = GetSqlConnectionString()
        Return strConnection.Replace(System.Configuration.ConfigurationManager.AppSettings("InitialCatalog"), "Initial Catalog=" + InitialCatalog + ";")

    End Function

    ''' --- GetSqlConnectionString ---------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of GetSqlConnectionString.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Function GetSqlConnectionString() As String

        If not IsNothing(ConfigurationManager.AppSettings("UseMultipleConnectStrings")) AndAlso ConfigurationManager.AppSettings("UseMultipleConnectStrings").ToUpper = "TRUE" Then
            If ApplicationState.Current.ConnectionStrings.Count = 0 Then
                For i As Integer = 1 To 10
                    If ConfigurationManager.AppSettings("ConnectionString" + i.ToString) IsNot Nothing Then
                        ApplicationState.Current.ConnectionStrings.Add("ConnectionString" + i.ToString, ConfigurationManager.AppSettings("ConnectionString" + i.ToString))
                    End If
                Next
            End If

            Return Common.ConnectionStringDecrypt(ApplicationState.Current.ConnectionStrings(ApplicationState.Current.CurrentConnectionStrings))

        Else
            Return Common.ConnectionStringDecrypt(ConfigurationManager.AppSettings("ConnectionString"))
        End If



    End Function

     <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Function GetSqlSecurityConnectionString() As String

        
            Return Common.ConnectionStringDecrypt(ConfigurationManager.AppSettings("SecurityConnectionString"))
       



    End Function

    '-------------------------------------------------------------------
    ' Name: GetConnectionString
    ' Function: Returns the connection string.
    ' Example: 
    '-------------------------------------------------------------------
    ''' --- GetConnectionString ------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of GetConnectionString.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Function GetConnectionString() As String

        If Not IsNothing(ConfigurationManager.AppSettings("UseMultipleConnectStrings")) AndAlso ConfigurationManager.AppSettings("UseMultipleConnectStrings").ToUpper = "TRUE" Then
            If ApplicationState.Current.ConnectionStrings.Count = 0 Then
                For i As Integer = 1 To 10
                    If ConfigurationManager.AppSettings("ConnectionString" + i.ToString) IsNot Nothing Then
                        ApplicationState.Current.ConnectionStrings.Add("ConnectionString" + i.ToString, ConfigurationManager.AppSettings("ConnectionString" + i.ToString))
                    End If
                Next
            End If

            Return Common.ConnectionStringDecrypt(ApplicationState.Current.ConnectionStrings(ApplicationState.Current.CurrentConnectionStrings))

        Else
            Return Common.ConnectionStringDecrypt(ConfigurationManager.AppSettings("ConnectionString"))
        End If

    End Function



    ''' --- ReturnDateAddingDefaultCentury -------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Returns the year value including century if a century from exists.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/29/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Function ReturnDateAddingDefaultCentury(ByVal Year As Integer) As Integer

        If m_intDefaultInputCentury = 0 Then
            Return m_intDefaultCentury + Year
        Else
            If Year >= m_intInputFromYear Then
                Return m_intDefaultInputCentury + Year
            Else
                Return m_intDefaultInputCentury + 100 + Year
            End If
        End If

    End Function

    ''' --- DateTimeToString --------------------------------------------------
    ''' 
    ''' <summary>
    ''' 	Returns a datetime value as a string.
    ''' </summary>
    ''' <param name="DateTime">A Decimal representing a date.</param>
    ''' <remarks>
    '''     Returns a datetime value as a string.  Since datetime values are stored 
    '''     as a Decimal datatype, depending on the value, the returned value when
    '''     assigned to a string may contain scientific notation.  The DateTimeToString
    '''     function will return this value as a number without scientific notation 
    '''     and without decimals.
    ''' </remarks>
    ''' <example>
    '''     <c>
    '''         m_strWHERE.Append(" corepackage.CORE_DATETIME_TONUM(USER_PSWD.RENEWAL_DATE) = ").Append(DateTimeToString(T_REN_DATE.Value))
    '''     </c>
    ''' </example>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    Public Function DateTimeToString(ByVal DateTime As Decimal) As String
        If DateTime = 0 Then Return DateTime.ToString
        Return DateTime.ToString("f").Substring(0, 8) + (DateTime - CDbl(DateTime.ToString("f").Substring(0, 8).PadRight(16, "0"c))).ToString.PadLeft(8, "0"c)
    End Function

    ''' --- DateToString --------------------------------------------------
    ''' 
    ''' <summary>
    ''' 	Returns a datetime value as a string.
    ''' </summary>
    ''' <param name="Value">A Decimal representing a date.</param>
    ''' <remarks>
    '''     Returns a datetime value as a string.  Since datetime values are stored 
    '''     as a Decimal datatype, depending on the value, the returned value when
    '''     assigned to a string may contain scientific notation.  The DateTimeToString
    '''     function will return this value as a number without scientific notation 
    '''     and without decimals.
    ''' </remarks>
    ''' <example>
    '''     <c>
    '''         m_strWHERE.Append(" corepackage.CORE_DATETIME_TONUM(USER_PSWD.RENEWAL_DATE) = ").Append(DateToString(T_REN_DATE.Value))
    '''     </c>
    ''' </example>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    Public Function DateToField(ByVal DateTime As Decimal) As String
        If (DateTime = 0) Then
            Return "NULL"
        Else
            Return "CONVERT(DATETIME, " + StringToField(String.Format("{0:yyyy-MM-dd HH:mm:ss}", New DateTime(DateTime.ToString.Substring(0, 4), DateTime.ToString.Substring(4, 2), DateTime.ToString.Substring(6, 2)))) + ", 120)"
        End If
    End Function

    ''' --- IsNull -------------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Determines if the value from the DataReader or DataTable is NULL.
    ''' </summary>
    ''' <param name="fldData"></param>
    ''' <remarks>
    ''' Determines if the value from the DataReader or DataTable is NULL.
    ''' </remarks>
    ''' <example>
    ''' IsNull(m_dtbDataTable.Rows(m_intCurrentRow).Item(Field))
    ''' </example>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Function IsNull(ByVal fldData As System.Object) As Boolean

        If fldData Is System.DBNull.Value Then
            Return True
        Else
            Return False
        End If

    End Function

    ''' --- StringToField ------------------------------------------------------
    ''' 
    ''' <summary>
    ''' 	Adds single quotes around a value and assumes a space if the value is and empty string.
    ''' </summary>
    ''' <param name="Value">The string value that will be wrapped in quotes.</param>
    ''' <param name="Size">Truncates the string based on the size specified.</param>
    ''' <remarks>
    ''' This function is used to ensure that single quotes are replaced with Decimal quotes when storing the value in the database.
    ''' If StoredProcedure is False, this function adds single quotes around the value passed in and is used
    ''' when creating the WHERE clause.  The value passed in will not be wrapped in single quotes if StoredProcedure is True.  
    ''' </remarks>
    ''' <example>
    ''' StringToField("John's Test",2) returns 'Jo' 
    ''' </example>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
    Public Function StringToField(ByVal Value As String, ByVal Size As Integer) As String

        ' Determine if the value 
        ' is an empty string.
        If Value.Trim = String.Empty Then
            Return "' '"
        Else

            If Value.TrimEnd.Length > Size Then
                Return "'" & Value.TrimEnd.Substring(0, Size).Replace("'", "''") & "'"
            Else
                Return "'" & Value.TrimEnd.Replace("'", "''") & "'"
            End If

        End If

    End Function

    ''' --- StringToField ------------------------------------------------------
    ''' 
    ''' <summary>
    ''' 	Adds single quotes around a value and assumes a space if the value is and empty string.
    ''' </summary>
    ''' <param name="Value">The string value that will be wrapped in quotes.</param>
    ''' <param name="StoredProcedure">Set to True if used to assign the value as a parameter to a stored procedure.</param>
    ''' <remarks>
    ''' This function is used to ensure that single quotes are replaced with Decimal quotes when storing the value in the database.
    ''' If StoredProcedure is False, this function adds single quotes around the value passed in and is used
    ''' when creating the WHERE clause.  The value passed in will not be wrapped in single quotes if StoredProcedure is True.  
    ''' </remarks>
    ''' <example>
    ''' StringToField("") returns ' ' <br/>
    ''' StringToField("Testing") returns 'Testing' <br/>
    ''' StringToField("John's Test") returns 'John''s Test' 
    ''' </example>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
    Public Function StringToField(ByVal Value As String, ByVal StoredProcedure As Boolean) As String

        ' Determine if the value 
        ' is an empty string.
        If Value.Trim = String.Empty Then

            ' For stored procedures, return a space for 
            ' empty string values, otherwise return a space
            ' in single quotes.
            If StoredProcedure Then
                Return " "
            Else
                Return "' '"
            End If

        Else

            ' Replace the single quote with two single quotes.
            ' Add the single quote at the beginning and end of 
            ' the value passed in if not called from a stored procedure.
            If StoredProcedure Then
                Return Value.TrimEnd.Replace("'", "''")
            Else
                Return "'" & Value.TrimEnd.Replace("'", "''") & "'"
            End If

        End If

    End Function

    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
    Public Function StringToField(ByVal Value As String) As String

        ' Determine if the value 
        ' is an empty string.
        If Value.Trim = String.Empty Then

            ' For stored procedures, return a space for 
            ' empty string values, otherwise return a space
            ' in single quotes.
            Return "' '"

        Else

            ' Replace the single quote with two single quotes.
            ' Add the single quote at the beginning and end of 
            ' the value passed in if not called from a stored procedure.

            Return "'" & Value.TrimEnd.Replace("'", "''") & "'"


        End If

    End Function

    ''' --- PutQuotes ------------------------------------------------------
    ''' 
    ''' <summary>
    ''' 	Adds double quotes around a value.
    ''' </summary>
    ''' <param name="Value">The string value that will be wrapped in quotes.</param>
    ''' <remarks>
    ''' This function is used to place double quotes around a string value.  
    ''' </remarks>
    ''' <example>
    ''' PutQuotes("") returns "" <br/>
    ''' PutQuotes("Testing") returns "Testing" <br/>
    ''' PutQuotes("John's Test") returns "John's Test" 
    ''' </example>
    ''' <history>
    ''' 	[Campbell]	11/16/2007	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    Public Function PutQuotes(ByVal strValue As String) As String

        Dim strString As String = String.Empty

        Try
            If strValue.Trim = String.Empty Then
                strString = Chr(34) & Chr(34)
            Else
                strString = Chr(34) & strValue & Chr(34)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

        Return strString

    End Function

    ''' --- InsertTabs ------------------------------------------------------
    ''' 
    ''' <summary>
    ''' 	Adds tab characters together in an empty string.
    ''' </summary>
    ''' <param name="intCount">The number of tab characters to insert at beginning og string value.</param>
    ''' <remarks>
    ''' This function is used to insert tab characters at the beginning of an empty string. It mimics indenting
    ''' of text with a string.
    ''' </remarks>
    ''' <example>
    ''' InsertTabs() returns "  " <br/>
    ''' InsertTabs(2) returns "     "<br/>
    ''' InsertTabs(4) returns "             " 
    ''' </example>
    ''' <history>
    ''' 	[Campbell]	11/16/2007	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    Public Function InsertTabs(Optional ByVal intCount As Integer = 1) As String

        Dim strTab As StringBuilder = New StringBuilder(String.Empty)

        For i As Integer = 1 To intCount
            strTab.Append(vbTab)
        Next

        Return strTab.ToString

    End Function

    ''' --- Dos2Unix ---------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Replaces the carriage return and linefeeds with linefeed characters.
    ''' </summary>
    ''' <param name="InputFile">A String containing the input file (including full path).</param>
    ''' <param name="OutputFile">A String containing the output file (including full path).</param>
    ''' <param name="DeleteInputFile">A boolean indicating to delete the input file after</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	7/4/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Sub Dos2Unix(ByVal InputFile As String, ByVal OutputFile As String, Optional ByVal DeleteInputFile As Boolean = False)

        Dim content As String = String.Empty
        Dim s As StreamReader = New StreamReader(InputFile, True)
        Dim currentEncoding As System.Text.Encoding = s.CurrentEncoding
        content = s.ReadToEnd()

        ' Replace linefeeds with newline character.
        content = content.Replace(vbNewLine, vbLf).TrimStart

        s.Close()
        s.Dispose()

        If DeleteInputFile Then
            File.Delete(InputFile)
        End If

        If File.Exists(OutputFile) Then File.Delete(OutputFile)
        Dim sw As StreamWriter = New StreamWriter(OutputFile, False, currentEncoding)
        sw.Write(content)
        sw.Close()
        sw.Dispose()

    End Sub

    ''' --- Unix2Dos ---------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Replaces the linefeed characters with carriage returns and linefeeds.
    ''' </summary>
    ''' <param name="InputFile">A String containing the input file (including full path).</param>
    ''' <param name="OutputFile">A String containing the output file (including full path).</param>
    ''' <param name="DeleteInputFile">A boolean indicating to delete the input file after</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	7/4/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Sub Unix2Dos(ByVal InputFile As String, ByVal OutputFile As String, Optional ByVal DeleteInputFile As Boolean = False)

        Dim content As String = String.Empty
        Dim s As StreamReader = New StreamReader(InputFile, True)
        Dim currentEncoding As System.Text.Encoding = s.CurrentEncoding
        content = s.ReadToEnd()

        ' Replace linefeeds with newline character.
        content = content.Replace(vbLf, vbNewLine).TrimStart

        s.Close()
        s.Dispose()

        If DeleteInputFile Then
            File.Delete(InputFile)
        End If

        If File.Exists(OutputFile) Then File.Delete(OutputFile)
        Dim sw As StreamWriter = New StreamWriter(OutputFile, False, currentEncoding)
        sw.Write(content)
        sw.Close()
        sw.Dispose()

    End Sub

    ''' --- ThrowCustomApplicationException ------------------------------------
    ''' 
    ''' <summary>
    ''' 	Throws an exception (used for ERROR and SEVERE) to send a message to the screen.
    ''' </summary>
    ''' <param name="ExceptionCode"></param>
    ''' <remarks>
    ''' Throws an exception (used for ERROR and SEVERE) to send a message to the screen.
    ''' </remarks>
    ''' <example>
    ''' ThrowCustomApplicationException(31004)
    ''' </example>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Sub ThrowCustomApplicationException(ByRef ExceptionCode As Integer)

        Dim ex As New CustomApplicationException(ExceptionCode)
        Throw ex

    End Sub

    ''' --- ThrowCustomApplicationException ------------------------------------
    ''' 
    ''' <summary>
    ''' 	Throws an exception (used for ERROR and SEVERE) to send a message to the screen.
    ''' </summary>
    ''' <param name="ExceptionCode"></param>
    ''' <remarks>
    ''' Throws an exception (used for ERROR and SEVERE) to send a message to the screen.
    ''' </remarks>
    ''' <example>
    ''' ThrowCustomApplicationException("MSG100")
    ''' </example>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Sub ThrowCustomApplicationException(ByRef ExceptionCode As String)

        Dim ex As New CustomApplicationException(ExceptionCode)
        Throw ex

    End Sub

    ''' --- ThrowCustomApplicationException ------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of ThrowCustomApplicationException.
    ''' </summary>
    ''' <param name="ExceptionCode"></param>
    ''' <param name="MessageType"></param>
    ''' <param name="MessageNumber"></param>
    ''' <param name="MessageText"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Sub ThrowCustomApplicationException(ByRef ExceptionCode As String, ByVal MessageType As String, ByVal MessageNumber As String, ByVal MessageText As String)

        Dim ex As New CustomApplicationException(ExceptionCode, MessageType, MessageNumber, MessageText)
        Throw ex

    End Sub

#If TARGET_DB = "INFORMIX" Then


    '-------------------------------------------------------------------
    ' Name: VMSTimeStamp
    ' Function: Returns the system date and time from the database.
    ' Example: VMSTimeStamp returns the date and time.
    '-------------------------------------------------------------------
    ''' --- VMSTimeStamp -------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Returns the system datetime from the database.
    ''' </summary>
    ''' <param name="cnnQUERY">The current Query transaction to connect to the database.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
    Public Function VMSTimeStamp(ByRef cnnQUERY As IfxConnection) As Decimal

        Dim drdReader As IfxDataReader = Nothing
        Dim strSQL As String
        Dim dblDate As Decimal

        Try
            strSQL = "select REPLACE(REPLACE(REPLACE(TO_CHAR(current),'-',''),':',''),' ','') || '00' from sysmaster:systables where tabid = 1"

            ' Fetch the result.
            drdReader = InformixHelper.ExecuteReader(cnnQUERY, CommandType.Text, strSQL)
            drdReader.Read()
            dblDate = CType(drdReader(0), Decimal)
            drdReader.Close()
            drdReader = Nothing
            Return dblDate

        Catch ex As Exception

            If Not drdReader Is Nothing Then
                If Not drdReader.IsClosed Then
                    drdReader.Close()
                    drdReader = Nothing
                End If
            End If

            ' Write the exception to the event log and throw an error.
            ExceptionManager.Publish(ex)
            Throw ex

        End Try

    End Function

    '-------------------------------------------------------------------
    ' Name: GetRecordCount
    ' Function: Returns the record count for a specific SQL.
    ' Example: GetRecordCount(m_cnnQuery, strSQL.ToString)
    '-------------------------------------------------------------------
    ''' --- GetRecordCount -----------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of GetRecordCount.
    ''' </summary>
    ''' <param name="SQL"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
    Public Function GetRecordCount(ByVal SQL As String) As Long

        Return CType(InformixHelper.ExecuteScalar(GetInformixConnectionString, CommandType.Text, SQL), Long)

    End Function

#Else

    '-------------------------------------------------------------------
    ' Name: VMSTimeStamp
    ' Function: Returns the system date and time from the database.
    ' Example: VMSTimeStamp returns the date and time.
    '-------------------------------------------------------------------
    ''' --- VMSTimeStamp -------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Returns the system datetime from the database.
    ''' </summary>
    ''' <param name="cnnQUERY">The current Query transaction to connect to the database.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Function VMSTimeStamp(ByRef cnnQUERY As OracleClient.OracleConnection) As Decimal

        Dim drdReader As OracleClient.OracleDataReader = Nothing
        Dim strSQL As String
        Dim dblDate As Decimal

        Try
            strSQL = "SELECT TO_CHAR(SysTimeStamp,'YYYYMMDDHH24MISSFF2') FROM Dual"

            ' Fetch the result.
            drdReader = OracleHelper.ExecuteReader(cnnQUERY, CommandType.Text, strSQL)
            drdReader.Read()
            dblDate = CType(drdReader(0), Decimal)
            drdReader.Close()
            drdReader.Dispose()
            Return dblDate

        Catch ex As Exception

            If Not drdReader Is Nothing Then
                If Not drdReader.IsClosed Then
                    drdReader.Close()
                    drdReader.Dispose()
                End If
            End If

            ' Write the exception to the event log and throw an error.
            ExceptionManager.Publish(ex)
            Throw ex

        End Try

    End Function

    ''' --- VMSTimeStamp -------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Returns the system datetime from the database.
    ''' </summary>
    ''' <param name="cnnQUERY">The current Query transaction to connect to the database.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Function VMSTimeStamp(ByRef cnnQUERY As SqlClient.SqlConnection) As Decimal

        Dim drdReader As SqlClient.SqlDataReader = Nothing
        Dim strSQL As String
        Dim dblDate As Decimal

        Try
            strSQL = "SELECT CONVERT(varchar,GETDATE(),112) + SUBSTRING(REPLACE(CONVERT(varchar,GETDATE(), 114),':',''),1,8)"

            ' Fetch the result.
            drdReader = SqlHelper.ExecuteReader(cnnQUERY, CommandType.Text, strSQL)
            drdReader.Read()
            dblDate = CType(drdReader(0), Decimal)
            drdReader.Close()

            Return dblDate

        Catch ex As Exception

            If Not drdReader Is Nothing Then
                If Not drdReader.IsClosed Then drdReader.Close()
            End If

            ' Write the exception to the event log and throw an error.
            ExceptionManager.Publish(ex)
            Throw ex

        End Try

    End Function

    '-------------------------------------------------------------------
    ' Name: GetRecordCount
    ' Function: Returns the record count for a specific SQL.
    ' Example: GetRecordCount(m_cnnQuery, strSQL.ToString)
    '-------------------------------------------------------------------
    ''' --- GetRecordCount -----------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of GetRecordCount.
    ''' </summary>
    ''' <param name="SQL"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Function GetRecordCount(ByVal SQL As String) As Long

        Return CType(OracleHelper.ExecuteScalar(GetConnectionString, CommandType.Text, SQL), Long)

    End Function

#End If

    ''' --- CoreWebTrace -------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of CoreWebTrace.
    ''' </summary>
    ''' <param name="strCategory"></param>
    ''' <param name="strDescription"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Sub CoreWebTrace(ByVal strCategory As String, ByVal strDescription As String)

        ' Commented out because this does not work in WinForms!
        'If Current.Trace.IsEnabled Then
        '    Current.Trace.Write(strCategory, strDescription)
        'End If

    End Sub

    ''' --- CoreDebugLog -------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of CoreDebugLog.
    ''' </summary>
    ''' <param name="Category"></param>
    ''' <param name="Description"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Sub CoreDebugLog(ByVal Category As String, ByVal Description As String)
        'Use this method "only to debug" an application
        'for Tracing use CoreWebTrace
        '
        'TODO: We always NEED to Comment-Out either a call to CoreDebugLog or this logic
        If m_fsDebugLogStream Is Nothing OrElse m_swLogWriter Is Nothing Then
            OpenDebugLog()
        End If
        If Description Is Nothing Then Description = " Nothing "
        If Description = String.Empty Then Description = " Empty "
        m_swLogWriter.WriteLine(Category + vbTab + Description)
    End Sub

    ''' --- CoreDebugLogSection ------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of CoreDebugLogSection.
    ''' </summary>
    ''' <param name="SectionDescription"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Sub CoreDebugLogSection(ByVal SectionDescription As String)
        'Creates a different section in the log file to improve readability of the log file
        CoreDebugLog(SectionDescription, Now.ToLongDateString + " " + Now.ToLongTimeString)
    End Sub

    ''' --- CoreDebugLogSection ------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of CoreDebugLogSection.
    ''' </summary>
    ''' <param name="SectionDescription"></param>
    ''' <param name="Begin"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Sub CoreDebugLogSection(ByVal SectionDescription As String, ByVal Begin As Boolean)
        'Creates a different section in the log file to improve readability of the log file
        If Begin Then
            CoreDebugLog("*", "*")
            CoreDebugLog(SectionDescription, "Start: " + Now.ToLongDateString + " " + Now.ToLongTimeString)
            CoreDebugLog("----------------------------", "----------------------------")
        Else
            CoreDebugLog("----------------------------", "----------------------------")
            CoreDebugLog(SectionDescription, "End: " + Now.ToLongDateString + " " + Now.ToLongTimeString)
        End If
    End Sub

    ''' --- OpenDebugLog -------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of OpenDebugLog.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Sub OpenDebugLog()
        ' Opens a log file
        'Ideally this method should be called from the Init event handler of the page you want to debug
        'To close log file, See CloseDebugLog
        If m_fsDebugLogStream Is Nothing OrElse m_swLogWriter Is Nothing Then
            m_fsDebugLogStream = New System.IO.FileStream("C:\DebugLog.txt", IO.FileMode.Append, FileAccess.Write)
            m_swLogWriter = New StreamWriter(m_fsDebugLogStream)
        End If
    End Sub

    ''' --- CloseDebugLog ------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of CloseDebugLog.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Sub CloseDebugLog()
        'Closes a log file
        'Ideally this method should be called from the UnLoad event handler of the page you want to debug
        'To open log file, See OpenDebugLog
        Try
            If Not m_swLogWriter Is Nothing Then
                With m_swLogWriter

                    .Flush()
                    .Close()
                End With
                m_swLogWriter = Nothing
                m_fsDebugLogStream.Close()
                m_fsDebugLogStream = Nothing
            End If
        Catch ex As Exception
            '????Closed or error
        End Try
    End Sub

    ''' --- LogPostbackInfo ----------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of LogPostbackInfo.
    ''' </summary>
    ''' <param name="ProcName"></param>
    ''' <param name="EventTarget"></param>
    ''' <param name="EventArgument"></param>
    ''' <param name="m_strRequestedTarget"></param>
    ''' <param name="m_strRequestedArgument"></param>
    ''' <param name="m_strPendingBuffer"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Sub LogPostbackInfo(ByVal ProcName As String, ByVal EventTarget As String, ByVal EventArgument As String, ByVal m_strRequestedTarget As String, ByVal m_strRequestedArgument As String, ByVal m_strPendingBuffer As String)
        If ProcName Is Nothing Then
            ProcName = String.Empty
        Else
            ProcName += ": "
        End If
        CoreDebugLog(ProcName + "EventTarget", EventTarget)
        CoreDebugLog(ProcName + "EventArgument", EventArgument)
        CoreDebugLog(ProcName + "m_strRequestedTarget", m_strRequestedTarget)
        CoreDebugLog(ProcName + "m_strRequestedArgument", m_strRequestedArgument)
        CoreDebugLog(ProcName + "m_strPendingBuffer", m_strPendingBuffer)
    End Sub

    ''' --- LogPostbackInfo ----------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of LogPostbackInfo.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Sub LogPostbackInfo()
        CoreDebugLog("Request(__EventTarget)", Current.Request("__EventTarget"))
        CoreDebugLog("Request(__EventArgument)", Current.Request("__EventArgument"))
        CoreDebugLog("Request(RequestedTarget)", Current.Request("RequestedTarget"))
        CoreDebugLog("Request(RequestedArgument)", Current.Request("RequestedArgument"))
        CoreDebugLog("Request(hidPendingBuffer)", Current.Request("hidPendingBuffer"))
    End Sub

    '-------------------------------------------------------------------
    ' Name: NumberOfCharacters
    ' Function: Returns the number of specified characters contained in a string.
    ' Example: NumberOfCharacters(m_string, "."c)
    '-------------------------------------------------------------------
    ''' --- NumberOfCharacters -------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of NumberOfCharacters.
    ''' </summary>
    ''' <param name="TheString"></param>
    ''' <param name="Character"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Function NumberOfCharacters(ByVal TheString As String, ByVal Character As Char) As Integer
        Dim intCounter As Integer
        Dim i As Integer

        For i = 0 To TheString.Length - 1
            If TheString.Chars(i) = Character Then
                intCounter += 1
            End If
        Next
        Return intCounter

    End Function

    '-------------------------------------------------------------------
    ' Name: GetNewStringArray
    ' Function: Returns a new one dimentional array of specified ArraySize initialized with an 
    '           empty string or with a passed Value.
    ' Example: GetNewStringArray(4, " ") ' will return a new one dimentional array with 4 elements initialized with one space
    '-------------------------------------------------------------------
    ''' --- GetNewStringArray --------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of GetNewStringArray.
    ''' </summary>
    ''' <param name="ArraySize"></param>
    ''' <param name="Value"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Function GetNewStringArray(ByVal ArraySize As Integer, Optional ByVal Value As String = "") As String()
        Dim i As Integer
        Dim StringArray(ArraySize - 1) As String
        For i = 0 To StringArray.GetUpperBound(0)
            StringArray.SetValue(Value, i)
        Next
        Return StringArray
    End Function

    '-------------------------------------------------------------------
    ' Name: GetNewDateArray
    ' Function: Returns a new one dimentional array of specified ArraySize initialized with an 
    '           cZeroDate (Constant value #12/31/1899#) or with a passed Value.
    ' Example: GetNewDateArray(4) ' will return a new one dimentional array of 4 elements with  default value of #12/31/1899#
    '-------------------------------------------------------------------
    ''' --- GetNewDateArray ----------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of GetNewDateArray.
    ''' </summary>
    ''' <param name="ArraySize"></param>
    ''' <param name="Value"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Function GetNewDateArray(ByRef ArraySize As Integer, Optional ByVal Value As Date = cZeroDate) As Core.Framework.OldCoreDate()
        Dim i As Integer
        Dim DateArray(ArraySize - 1) As Core.Framework.OldCoreDate
        For i = 0 To DateArray.GetUpperBound(0)
            DateArray.SetValue(New Core.Framework.OldCoreDate(Value), i)
        Next
        Return DateArray
    End Function

    '-------------------------------------------------------------------
    ' Name: GetNewDateArray
    ' Function: Returns a new one dimentional array of specified ArraySize initialized
    '           with a passed Value.
    ' Example: GetNewDateArray(4, 0) ' will return a new one dimentional array of 4 elements with  default value of #12/31/1899#
    '-------------------------------------------------------------------
    ''' --- GetNewDateArray ----------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of GetNewDateArray.
    ''' </summary>
    ''' <param name="ArraySize"></param>
    ''' <param name="Value"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Function GetNewDateArray(ByRef ArraySize As Integer, ByVal Value As Decimal) As Core.Framework.OldCoreDate()
        Dim i As Integer
        Dim DateArray(ArraySize - 1) As Core.Framework.OldCoreDate
        For i = 0 To DateArray.GetUpperBound(0)
            DateArray.SetValue(New Core.Framework.OldCoreDate(Value), i)
        Next
        Return DateArray
    End Function

    '-------------------------------------------------------------------
    ' Name: GetNewIntegerArray
    ' Function: Returns a new one dimentional array of specified ArraySize initialized with an 
    '           0 or with a passed Value.
    ' Example: GetNewIntegerArray(4, -1) ' will return a new one dimentional array of 4 elements with  default value of -1
    '-------------------------------------------------------------------
    ''' --- GetNewIntegerArray -------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of GetNewIntegerArray.
    ''' </summary>
    ''' <param name="ArraySize"></param>
    ''' <param name="Value"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Function GetNewIntegerArray(ByRef ArraySize As Integer, Optional ByVal Value As Integer = 0) As Integer()
        Dim i As Integer
        Dim intArray(ArraySize - 1) As Integer
        If Value <> 0 Then ' Number Arrarys are already initialized with zeros
            For i = 0 To intArray.GetUpperBound(0)
                intArray.SetValue(Value, i)
            Next
        End If
        Return intArray
    End Function

    '-------------------------------------------------------------------
    ' Name: GetNewLongArray
    ' Function: Returns a new one dimentional array of specified ArraySize initialized with an 
    '           0 or with a passed Value.
    ' Example: GetNewLongArray(4, -1) ' will return a new one dimentional array of 4 elements with  default value of -1
    '-------------------------------------------------------------------
    ''' --- GetNewLongArray ----------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of GetNewLongArray.
    ''' </summary>
    ''' <param name="ArraySize"></param>
    ''' <param name="Value"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Function GetNewLongArray(ByRef ArraySize As Integer, Optional ByVal Value As Long = 0) As Long()
        Dim i As Integer
        Dim lngArray(ArraySize - 1) As Long
        If Value <> 0 Then ' Number Arrarys are already initialized with zeros
            For i = 0 To lngArray.GetUpperBound(0)
                lngArray.SetValue(Value, i)
            Next
        End If
        Return lngArray
    End Function

    '-------------------------------------------------------------------
    ' Name: GetNewDecimalArray
    ' Function: Returns a new one dimentional array of specified ArraySize initialized with an 
    '           0 or with a passed Value.
    ' Example: GetNewDecimalArray(4, -1) ' will return a new one dimentional array of 4 elements with  default value of -1
    '-------------------------------------------------------------------
    ''' --- GetNewDecimalArray --------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of GetNewDecimalArray.
    ''' </summary>
    ''' <param name="ArraySize"></param>
    ''' <param name="Value"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Function GetNewDecimalArray(ByRef ArraySize As Integer, Optional ByVal Value As Decimal = 0) As Decimal()
        Dim i As Integer
        Dim dblArray(ArraySize - 1) As Decimal
        If Value <> 0 Then ' Number Arrarys are already initialized with zeros
            For i = 0 To dblArray.GetUpperBound(0)
                dblArray.SetValue(Value, i)
            Next
        End If
        Return dblArray
    End Function

    ''' --- BuildWhereCondition ------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of BuildWhereCondition.
    ''' </summary>
    ''' <param name="WhereCondition"></param>
    ''' <param name="AppendWhereCondition"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Sub BuildWhereCondition(ByRef WhereCondition As String, ByVal AppendWhereCondition As String)
        'If there is nothing to append, exit 
        If AppendWhereCondition.Trim = String.Empty Then Exit Sub

        'Concatenate the passed condition to the Where Condition
        If WhereCondition.Trim = String.Empty AndAlso AppendWhereCondition.Trim <> String.Empty Then
            If AppendWhereCondition.Trim.Substring(0, 6) = "WHERE " OrElse AppendWhereCondition.Trim.Substring(0, 5) = "JOIN " Then
                WhereCondition = " "
            Else
                If AppendWhereCondition.Trim.Substring(0, 4).ToUpper = "AND " Then
                    AppendWhereCondition = AppendWhereCondition.Trim.Substring(3)
                End If
                WhereCondition = " WHERE "
            End If
        Else
            If AppendWhereCondition.Trim.Substring(0, 4).ToUpper = "AND " Then
                WhereCondition = WhereCondition + " "
            Else
                WhereCondition = WhereCondition + " AND "
            End If
        End If
        WhereCondition = WhereCondition + AppendWhereCondition.Trim
    End Sub

    Public Function BooleanArray(ByVal ParamArray BooleanValues() As Boolean) As Boolean()
        Return BooleanValues
    End Function

    Public Function StringArray(ByVal ParamArray StringValues() As String) As String()
        Return StringValues
    End Function

    Public Function ObjectArray(ByVal ParamArray Objects() As Object) As Object()
        Return Objects
    End Function

    Private Key As Byte() = {23, 22, 86, 33, 11, 3,
    67, 21, 21, 53, 8, 98,
    249, 43, 98, 103, 38, 104,
    105, 43, 222, 34, 45, 89}

    Private Iv As Byte() = {45, 11, 45, 37, 42, 68,
        102, 79}

    Public Function ConnectionStringDecrypt(ConnectionString As String) As String

        Dim password As String = ConnectionString.Substring(ConnectionString.ToUpper().IndexOf("PASSWORD") + 8)
        password = password.Substring(password.IndexOf("=") + 1)
        password = password.Substring(0, password.IndexOf(";"))

        Return ConnectionString.Replace(password, Decrypt(password))
    End Function

    Public Function Decrypt(EncryptedString As String) As String
        ' UTFEncoding is used to transform the decrypted Byte Array 
        ' information back into a string. 
        Dim utf8encoder = New UTF8Encoding()
        Dim tdesProvider = New TripleDESCryptoServiceProvider()
        Dim bytInputBytes As Byte() = Nothing
        ' As before we must provide the encryption/decryption key along with 
        ' the init vector. 
        Dim cryptoTransform As ICryptoTransform = Nothing
        cryptoTransform = tdesProvider.CreateDecryptor(Key, Iv)


        ' Provide a memory stream to decrypt information into 
        Dim decryptedStream = New MemoryStream()
        Dim cryptStream = New CryptoStream(decryptedStream, cryptoTransform, CryptoStreamMode.Write)

        bytInputBytes = Convert.FromBase64String(EncryptedString)
        cryptStream.Write(bytInputBytes, 0, bytInputBytes.Length)
        cryptStream.FlushFinalBlock()
        decryptedStream.Position = 0

        ' Read the memory stream and convert it back into a string 
        Dim result = New Byte(Convert.ToInt16(decryptedStream.Length) - 1) {}
        decryptedStream.Read(result, 0, Convert.ToInt16(decryptedStream.Length))
        cryptStream.Close()
        decryptedStream.Close()

        Return utf8encoder.GetString(result)
    End Function



End Module
