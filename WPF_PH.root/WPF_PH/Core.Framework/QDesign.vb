Imports System.ComponentModel
Imports System.Data.OracleClient
Imports System.Data.SqlClient
Imports Core.Globalization.Core.Globalization
Imports System.Runtime.Serialization
Imports System.Text
Imports System.Security.Cryptography
Imports System.IO
Imports Core.ExceptionManagement
Imports System.Text.RegularExpressions
Imports Core.Framework.Core.Security
Imports Core.DataAccess.Oracle
Imports Core.DataAccess.SqlServer
Imports System.Web
Imports System.Threading

#If TARGET_DB = "INFORMIX" Then
Imports Core.DataAccess.Informix
Imports IBM.Data.Informix
#Else
#End If

Namespace Core.Framework
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Module	: QDesign
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' <summary>
    ''' 	PowerHouse specific functions.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(EditorBrowsableState.Always)>
    Public Module QDesign
        Public Const CORE_DELIMITER As String = "|*|"

#Region "QDesign Functions"

        ''' --- AddCentury --------------------------------------------------------------
        '''
        ''' <summary>
        ''' Converts a Decimal representing a date to an 8-digit Decimal representing a date.
        ''' </summary>
        ''' <param name="dblDate">A Decimal, between 1 and 6 digits in length, representing a date.</param>
        ''' <param name="intCentury">An integer representing the century which will be appended to the passed in Date.</param>
        ''' <returns>An 8-digit Decimal, representing a date.
        ''' </returns>
        ''' <remarks>
        ''' The size of dblDate must be 8-digits. 
        ''' <para>
        ''' <note>
        '''     If optional century is not passed in or the value passed in for the century is 0
        '''     then the Default Century will be used.
        ''' </note>
        ''' </para>
        ''' </remarks>
        ''' <example> AddCentury(010704, 20) returns 20010704 <br/>
        '''           AddCentury(010704) returns 20010704 if the default century is 20</example>
        ''' <history>
        '''     [Mayur] Concatenates the passsed century.   Changed April 07, 2005
        ''' 	[Campbell]	4/4/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function AddCentury(ByVal dblDate As Decimal, Optional ByVal intCentury As Integer = 0) As Decimal

            Dim strDate As String = String.Empty
            Dim strCentury As String = String.Empty

            Select Case dblDate.ToString.Length
                Case 1 To 6
                    If intCentury = 0 Then

                        If dblDate.ToString.Length = 5 Then
                            strCentury =
                                ReturnDateAddingDefaultCentury(CInt(dblDate.ToString.Substring(0, 1))).ToString.
                                    Substring(0, 2)
                        Else
                            strCentury =
                                ReturnDateAddingDefaultCentury(CInt(dblDate.ToString.Substring(0, 2))).ToString.
                                    Substring(0, 2)
                        End If
                    Else
                        strCentury = intCentury.ToString()
                    End If

                    strDate = Replace(dblDate.ToString.PadLeft(6), " ", "0")

                Case Else
                    strDate = dblDate.ToString.PadLeft(6, "0"c)
            End Select

            Return CDbl(strCentury + strDate)

        End Function


        ''' --- RemoveCentury --------------------------------------------------------------
        '''
        ''' <summary>
        ''' Converts a Decimal representing an 8-digit date to an 6-digit Decimal representing a date.
        ''' </summary>
        ''' <param name="dblDate">An 8 digit value representing a date.</param>
        ''' <returns>An 8-digit Decimal, representing a date.
        ''' </returns>
        ''' <remarks>
        ''' The size of dblDate must be 8-digits. 
        ''' <para>
        ''' <note>
        '''     Converts a 8-digit date to a 6-digit date.
        ''' </note>
        ''' </para>
        ''' </remarks>
        ''' <example> RemoveCentury(20010704) returns 010704 <br/></example>
        ''' <history>
        ''' 	[Campbell]	4/4/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function RemoveCentury(ByVal dblDate As Decimal) As Decimal

            If dblDate.ToString.Length = 8 Then
                Return CType(dblDate.ToString.Substring(2), Decimal)
            Else
                Return dblDate
            End If

        End Function


        ''' --- Reverse --------------------------------------------------------------
        '''
        ''' <summary>
        ''' Converts a Decimal representing an 8-digit date to an 6-digit Decimal representing a date.
        ''' </summary>
        ''' <param name="Value">A string value to reverse.</param>
        ''' <returns>A string value in the reverse order.
        ''' </returns>
        ''' <remarks>
        ''' This function returns the reverse of the value passed in. 
        ''' <para>
        ''' <note>
        '''     Converts a string value by reversing the characters.
        ''' </note>
        ''' </para>
        ''' </remarks>
        ''' <example> Reverse("TESTING") returns GNITSET <br/></example>
        ''' <history>
        ''' 	[Campbell]	4/4/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function Reverse(ByVal Value As String) As String

            Dim sb As StringBuilder = New StringBuilder(String.Empty)

            For i As Integer = Value.Length - 1 To 0 Step -1
                sb.Append(Value.Substring(i, 1))
            Next

            Return sb.ToString

        End Function

        ''' --- ASCII -------------------------------------------------------------------
        '''
        ''' <summary>
        ''' Converts a number to a character string.
        ''' </summary>
        ''' <param name="Number">A integer that will be converted to a string.</param>
        ''' <param name="Size">The length of the returned string.</param>
        ''' <returns>A character string representation of the Decimal that was passed in.</returns>
        ''' <remarks>The string will be padded with 0's if the
        ''' size is greater than the number to be converted.
        ''' </remarks>
        ''' <example> ASCII(236,5) returns "00236"</example>
        ''' <history>
        ''' 	[Campbell]	4/4/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function ASCII(ByVal Number As Integer, Optional ByVal Size As Integer = 0) As String

            If Number = 1 / 0 Then Number = 0
            If Size > 0 Then

                If Number >= 0 Then
                    Return Number.ToString().PadLeft(Size, "0"c)
                Else
                    Return "-" & Number.ToString().Replace("-", "").PadLeft(Size - 1, "0"c)
                End If

                Return Number.ToString().PadLeft(Size, "0"c)
            Else
                Return Number.ToString()
            End If

        End Function

        ''' --- ASCII -------------------------------------------------------------------
        '''
        ''' <summary>
        ''' Converts a number to a character string.
        ''' </summary>
        ''' <param name="Number">A Decimal that will be converted to a string.</param>
        ''' <param name="Size">The length of the returned string.</param>
        ''' <returns>A character string representation of the Decimal that was passed in.</returns>
        ''' <remarks>The string will be padded with 0's if the
        ''' size is greater than the number to be converted.  Values to the right of the decimal 
        ''' are ignored.
        ''' </remarks>
        ''' <example> ASCII(236,5) returns "00236"</example>
        ''' <history>
        ''' 	[Campbell]	4/4/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function ASCII(ByVal Number As Decimal, Optional ByVal Size As Integer = 0) As String

            If Number = 1 / 0 Then Number = 0
            Dim strNumber As String = Number.ToString

            ' Remove values to the right of the decimal.
            If strNumber.IndexOf(".") > -1 Then
                strNumber = strNumber.Substring(0, strNumber.IndexOf("."))
            End If

            If Size > 0 Then
                If Number >= 0 Then
                    Return strNumber.PadLeft(Size, "0"c).Substring(0, Size)
                Else
                    Return "-" & strNumber.Replace("-", "").PadLeft(Size - 1, "0"c).Substring(0, Size - 1)
                End If
            Else
                Return strNumber
            End If

        End Function

        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function ASCII(ByVal strNumber As String, Optional ByVal Size As Integer = 0) As String
            Return strNumber
        End Function

        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function ASCII(ByVal strNumber As Object, Optional ByVal Size As Integer = 0) As String
            Return ASCII(CDec(strNumber), Size)
        End Function

        ''' --- Characters --------------------------------------------------------------
        '''
        ''' <summary>
        ''' Specifies an item that is addressed as a character string.
        ''' </summary>
        ''' <param name="dblNumber">A Decimal that is to be converted to a string.</param>
        ''' <returns>A string representation of a Decimal.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example> 
        ''' Characters(79) returns "79"
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/4/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function Characters(ByVal dblNumber As Decimal) As String

            Dim strReturn As String = String.Empty

            If dblNumber = 0 Then
                Return ""
            End If

            Try
                If CInt(dblNumber) = 0 Then
                    Return ""
                End If
                strReturn = CType(CLng(dblNumber), String)
            Catch ex As Exception
                strReturn = CType(Math.Abs(CLng(dblNumber)), String)
            End Try

            Return strReturn

        End Function

        ''' --- Ceiling -----------------------------------------------------------------
        '''
        ''' <summary>
        ''' Rounds a number up to the nearest integer.
        ''' </summary>
        ''' <param name="dblNumber">The number to be rounded up.</param>
        ''' <returns>An integer representing the next highest integer.</returns>
        ''' <remarks> 
        ''' </remarks>
        ''' <example>
        '''     <para>Ceiling(79.04) returns 80</para>
        '''     <para>Ceiling(79) returns 79</para>
        '''     <para>Ceiling(-79.04) returns -79</para>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/4/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function Ceiling(ByVal dblNumber As Decimal) As Decimal

            Return Math.Ceiling(dblNumber)

        End Function

        ''' --- Divide -----------------------------------------------------------------
        '''
        ''' <summary>
        ''' Divides the first parm by the second. This function is used because powerhouse can divide by 0.
        ''' </summary>
        ''' <param name="dblDivided">The number to be divided.</param>
        ''' <param name="dblDivider">The number to be divided by.</param>
        ''' <returns>A Decimal .</returns>
        ''' <remarks> 
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/4/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function Divide(ByVal dblDivided As Decimal, ByVal dblDivider As Decimal,
                                Optional ByVal NoRemainder As Boolean = False) As Decimal

            If dblDivider = 0 Then Return 0
            If NoRemainder Then
                Return dblDivided \ dblDivider
            Else
                Return dblDivided / dblDivider
            End If

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Centers characters in a string.
        ''' </summary>
        ''' <param name="strExpression">The string who's characters are to be centered.</param>
        ''' <returns>A string who's characters are centered within the passed in string.</returns>
        ''' <remarks> 
        ''' </remarks>
        ''' <example>
        '''     Center("word    ") returns "  word  "
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/4/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function Center(ByVal strExpression As String) As String

            Dim intSpaces As Integer

            intSpaces = strExpression.Length - strExpression.Trim().Length

            Dim strSpaces As New String(" "c, intSpaces \ 2)

            ' If we have an even number of spaces.
            If intSpaces Mod 2 = 0 Then
                Return strSpaces & strExpression.Trim() & strSpaces
            Else
                Return strSpaces & " " & strExpression.Trim() & strSpaces
            End If

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Centers characters in a string.
        ''' </summary>
        ''' <param name="strExpression">The string who's characters are to be centered.</param>
        ''' <returns>A string who's characters are centered within the passed in string.</returns>
        ''' <remarks> 
        ''' </remarks>
        ''' <example>
        '''     Centre("word    ") returns "  word  "
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/4/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function Centre(ByVal strExpression As String) As String
            Return Center(strExpression)
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Returns a checksum for a string.
        ''' </summary>
        ''' <param name="strExpression">A string which will be represented by a number.</param>
        ''' <returns>A number representing the sum of each character's ascii value in the passed in expression.</returns>
        ''' <remarks> 
        ''' </remarks>
        ''' <example>
        '''     CheckSum("Top Secret") returns 17913
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/4/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function CheckSum(ByVal strExpression As String) As Integer

            Dim intChar As Integer
            Dim intVal As Integer

            Do While intChar < strExpression.Length()
                intChar += 1
                intVal += Asc(strExpression.Substring(intChar, 1))
            Loop

            Return intVal

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Adds the elapsed-time to a date.
        ''' </summary>
        ''' <param name="dblElapsedTime">the amount of time in days, hours, minutes and 
        ''' seconds which is to be added to the passed in date.</param>
        ''' <param name="dteDate">The date to which the elapsed time is to be added on to.</param>
        ''' <returns>A Decimal representing the date-time value of the passed in date after the elasped time.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        '''     <para>PhDate(120)   returns 1900/04/30</para>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/4/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function PhDate(ByVal dblElapsedTime As Decimal, ByVal dteDate As Date) As Decimal

            Dim dblDays As Decimal
            Dim dblHours As Decimal
            Dim dblMinutes As Decimal
            Dim dblSeconds As Decimal
            Dim strTemp As String
            Dim dteReturnDate As New OldCoreDate(0)

            If dblElapsedTime = 1 / 0 Then dblElapsedTime = 0

            ' Get the Elapsed Time as Days, Hours, Minutes, Seconds.
            strTemp = Format(dblElapsedTime, "0.0#")
            dblDays = CDbl(Left$(strTemp, strTemp.IndexOf(".")))
            strTemp = Format(CDbl(Right(strTemp, strTemp.Length() - strTemp.IndexOf("."))) * 24, "0.0#")
            dblHours = CDbl(Left(strTemp, strTemp.IndexOf(".")))
            strTemp = Format(CDbl(Right(strTemp, strTemp.Length() - strTemp.IndexOf("."))) * 60, "0.0#")
            dblMinutes = CDbl(Left(strTemp, strTemp.IndexOf(".")))
            strTemp = Format(CDbl(Right(strTemp, strTemp.Length() - strTemp.IndexOf("."))) * 60, "0.0#")
            dblSeconds = CDbl(Left(strTemp, strTemp.IndexOf(".")))

            ' Calculate the new date.
            dteReturnDate.DateValue = DateAdd(DateInterval.Day, dblDays, dteDate)
            dteReturnDate.DateValue = DateAdd(DateInterval.Hour, dblHours, dteReturnDate.DateValue)
            dteReturnDate.DateValue = DateAdd(DateInterval.Minute, dblMinutes, dteReturnDate.DateValue)
            dteReturnDate.DateValue = DateAdd(DateInterval.Second, dblSeconds, dteReturnDate.DateValue)

            Return dteReturnDate.Value

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Adds the elapsed-time to a date.
        ''' </summary>
        ''' <param name="dblElapsedTime">The amount of time in days, hours, minutes and seconds 
        ''' which is to be added to the passed in date.</param>
        ''' <param name="dblDate">The date, represented as a Decimal, to which the elapsed time is to be added on to.</param>
        ''' <returns>A Decimal representing the date-time value of the passed in date, represented as a Decimal, after
        '''  the elasped time.</returns>
        ''' <remarks> 
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/4/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function PhDate(ByVal dblElapsedTime As Decimal, ByVal dblDate As Decimal) As Decimal

            Dim dblDays As Decimal
            Dim dblHours As Decimal
            Dim dblMinutes As Decimal
            Dim dblSeconds As Decimal
            Dim strTemp As String
            Dim dteReturnDate As New OldCoreDate(0)

            If dblElapsedTime = 1 / 0 Then dblElapsedTime = 0
            If dblDate = 1 / 0 Then dblDate = 0

            ' Get the Elapsed Time as Days, Hours, Minutes, Seconds.
            strTemp = Format(dblElapsedTime, "0.0#")
            dblDays = CDbl(Left$(strTemp, strTemp.IndexOf(".")))
            strTemp = Format(CDbl(Right(strTemp, strTemp.Length() - strTemp.IndexOf("."))) * 24, "0.0#")
            dblHours = CDbl(Left(strTemp, strTemp.IndexOf(".")))
            strTemp = Format(CDbl(Right(strTemp, strTemp.Length() - strTemp.IndexOf("."))) * 60, "0.0#")
            dblMinutes = CDbl(Left(strTemp, strTemp.IndexOf(".")))
            strTemp = Format(CDbl(Right(strTemp, strTemp.Length() - strTemp.IndexOf("."))) * 60, "0.0#")
            dblSeconds = CDbl(Left(strTemp, strTemp.IndexOf(".")))

            ' Convert the numeric value to a date value.
            Dim dteDate As OldCoreDate = Nothing

            strTemp = dblDate.ToString()
            Select Case strTemp.Length
                Case 8
                    dteDate.DateValue =
                        DateSerial(CInt(Left(strTemp, 4)), CInt(strTemp.Substring(5, 2)),
                                    CInt(strTemp.Substring(7, 2)))
                Case 6
                    dteDate.DateValue =
                        DateSerial(CInt(Left(strTemp, 2)), CInt(strTemp.Substring(5, 2)),
                                    CInt(strTemp.Substring(7, 2)))
                Case Else
                    dteDate.DateValue = DateSerial(1899, 12, 31)
            End Select

            ' Calculate the new date.
            dteReturnDate.DateValue = DateAdd(DateInterval.Day, dblDays, dteDate.DateValue)
            dteReturnDate.DateValue = DateAdd(DateInterval.Hour, dblHours, dteReturnDate.DateValue)
            dteReturnDate.DateValue = DateAdd(DateInterval.Minute, dblMinutes, dteReturnDate.DateValue)
            dteReturnDate.DateValue = DateAdd(DateInterval.Second, dblSeconds, dteReturnDate.DateValue)

            Return dteReturnDate.Value

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Adds the elapsed-time to the base date, 12/31/1899.
        ''' </summary>
        ''' <param name="dblElapsedTime">The amount of time in days, hours, minutes and seconds 
        ''' which is to be added to the base date, 12/31/1899.</param>
        ''' <returns>A Decimal representing the date-time value of the elasped time from the base date.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/4/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function PhDate(ByVal dblElapsedTime As Decimal) As Decimal

            Dim dblDays As Decimal
            Dim dblHours As Decimal
            Dim dblMinutes As Decimal
            Dim dblSeconds As Decimal
            Dim strTemp As String
            Dim dteReturnDate As New OldCoreDate(0)

            If dblElapsedTime = 1 / 0 Then dblElapsedTime = 0

            ' Get the Elapsed Time as Days, Hours, Minutes, Seconds.
            strTemp = Format(dblElapsedTime, "0.0#")

            If Thread.CurrentThread.CurrentCulture.ToString.StartsWith("fr") Then
                dblDays = CDbl(Left$(strTemp, strTemp.IndexOf(",")))
                strTemp = Format(CDbl(Right(strTemp, strTemp.Length() - strTemp.IndexOf(","))) * 24, "0.0#")
                dblHours = CDbl(Left(strTemp, strTemp.IndexOf(",")))
                strTemp = Format(CDbl(Right(strTemp, strTemp.Length() - strTemp.IndexOf(","))) * 60, "0.0#")
                dblMinutes = CDbl(Left(strTemp, strTemp.IndexOf(",")))
                strTemp = Format(CDbl(Right(strTemp, strTemp.Length() - strTemp.IndexOf(","))) * 60, "0.0#")
                dblSeconds = CDbl(Left(strTemp, strTemp.IndexOf(",")))
            Else
                dblDays = CDbl(Left$(strTemp, strTemp.IndexOf(".")))
                strTemp = Format(CDbl(Right(strTemp, strTemp.Length() - strTemp.IndexOf("."))) * 24, "0.0#")
                dblHours = CDbl(Left(strTemp, strTemp.IndexOf(".")))
                strTemp = Format(CDbl(Right(strTemp, strTemp.Length() - strTemp.IndexOf("."))) * 60, "0.0#")
                dblMinutes = CDbl(Left(strTemp, strTemp.IndexOf(".")))
                strTemp = Format(CDbl(Right(strTemp, strTemp.Length() - strTemp.IndexOf("."))) * 60, "0.0#")
                dblSeconds = CDbl(Left(strTemp, strTemp.IndexOf(".")))

            End If



            ' Calculate the new date.
            dteReturnDate.DateValue = DateAdd(DateInterval.Day, dblDays, BaseDate)
            dteReturnDate.DateValue = DateAdd(DateInterval.Hour, dblHours, dteReturnDate.DateValue)
            dteReturnDate.DateValue = DateAdd(DateInterval.Minute, dblMinutes, dteReturnDate.DateValue)
            dteReturnDate.DateValue = DateAdd(DateInterval.Second, dblSeconds, dteReturnDate.DateValue)

            Return dteReturnDate.Value

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Extracts a specific date or time portion of a date or date-time item such as month or hour.
        ''' </summary>
        ''' <param name="dblDate">A date represented as a Decimal.</param>
        ''' <param name="intOption">The specific date or time portion to be returned.</param>
        ''' <returns>A Decimal representing the value contained in the date and expressed as the supplied option.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        '''     DateExtract(19990328, ExtractOption.Year) returns 1999
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/4/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function DateExtract(ByVal dblDate As Object, ByVal intOption As ExtractOption) As Decimal
            Return DateExtract(CDec(dblDate), intOption)
        End Function

        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function DateExtract(ByVal dblDate As Object, ByVal strOption As String) As Decimal

            Select Case strOption
                Case "0005"
                    Return DateExtract(CDec(dblDate), ExtractOption.Month)
                Case "0002"
                    Return DateExtract(CDec(dblDate), ExtractOption.Year)
                Case "0008"
                    Return DateExtract(CDec(dblDate), ExtractOption.Day)

            End Select

        End Function

        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function DateExtract(ByVal dblDate As Decimal, ByVal intOption As ExtractOption) As Decimal

            Dim coreDate As New OldCoreDate(dblDate)
            Dim dtedate As Date = coreDate.DateValue
            coreDate = Nothing

            If dblDate = 1 / 0 Then dblDate = 0

            Select Case intOption
                Case ExtractOption.Year
                    Return dtedate.Year
                Case ExtractOption.Month
                    Return dtedate.Month
                Case ExtractOption.Day
                    Return dtedate.Day
                Case ExtractOption.Hour
                    Return dtedate.Hour
                Case ExtractOption.Minute
                    Return dtedate.Minute
                Case ExtractOption.Second
                    Return dtedate.Second
                Case ExtractOption.OptionDate
                    Return CDbl(Format(dtedate, "YYYYMMDD"))
                Case ExtractOption.Time
                    Return CDbl(Format(dtedate, "HHNNSS"))
            End Select

        End Function

        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function DateExtract(ByVal dblDate As Decimal, ByVal intOption As Integer) As Decimal

            Dim coreDate As New OldCoreDate(dblDate)
            Dim dtedate As Date = coreDate.DateValue
            coreDate = Nothing

            If dblDate = 1 / 0 Then dblDate = 0

            Select Case intOption
                Case ExtractOption.Year
                    Return dtedate.Year
                Case ExtractOption.Month
                    Return dtedate.Month
                Case ExtractOption.Day
                    Return dtedate.Day
                Case ExtractOption.Hour
                    Return dtedate.Hour
                Case ExtractOption.Minute
                    Return dtedate.Minute
                Case ExtractOption.Second
                    Return dtedate.Second
                Case ExtractOption.OptionDate
                    Return CDbl(Format(dtedate, "YYYYMMDD"))
                Case ExtractOption.Time
                    Return CDbl(Format(dtedate, "HHNNSS"))
            End Select

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Extracts a specific date or time portion of a date or date-time item such as month or hour.
        ''' </summary>
        ''' <param name="dteDate">A date from which the option is to be extracted from.</param>
        ''' <param name="intOption">The specific date or time portion to be returned.</param>
        ''' <returns>A Decimal representing the value contained in the date and expressed as the supplied option.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        '''     DateExtract(1999/03/28, ExtractOption.Year) returns 1999
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/4/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function DateExtract(ByVal dteDate As Date, ByVal intOption As ExtractOption) As Decimal

            Select Case intOption
                Case ExtractOption.Year
                    Return dteDate.Year
                Case ExtractOption.Month
                    Return dteDate.Month
                Case ExtractOption.Day
                    Return dteDate.Day
                Case ExtractOption.Hour
                    Return dteDate.Hour
                Case ExtractOption.Minute
                    Return dteDate.Minute
                Case ExtractOption.Second
                    Return dteDate.Second
                Case ExtractOption.OptionDate
                    Return CDbl(Format(dteDate, "YYYYMMDD"))
                Case ExtractOption.Time
                    Return CDbl(Format(dteDate, "HHNNSS"))
            End Select

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Calculates the number of days between a specified date and December 31, 1899.
        ''' </summary>
        ''' <param name="dteDate">The date to compare with the base date to find the difference 
        ''' in the number of days between each.</param>
        ''' <returns> A Decimal representing the number of days between the specified date and the
        ''' base date of 12/31/1899.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        '''     Days("1901/01/01") returns 366
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/4/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function Days(ByVal dteDate As Date) As Decimal

            Return DateDiff(DateInterval.Day, BaseDate, dteDate)

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Calculates the number of days between a specified date and December 31, 1899.
        ''' </summary>
        ''' <param name="dblDate">The date, represented as a Decimal, to compare with the base 
        ''' date in order to find the difference in the number of days between each.</param>
        ''' <returns> A Decimal representing the number of days between the specified date and the
        ''' base date of 12/31/1899.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/4/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function Days(ByVal dblDate As Decimal) As Decimal

            ' Convert the numeric value to a date value.
            Dim dteDate As Date
            Dim strTemp As String = dblDate.ToString()

            If dblDate = 1 / 0 Then dblDate = 0

            strTemp = dblDate.ToString.Replace(".00", "")
            strTemp = strTemp.Replace(".0", "")

            If strTemp.Length = 4 Then
                strTemp = "00" + strTemp
            ElseIf strTemp.Length = 5 Then
                strTemp = "0" + strTemp
            End If

            Select Case strTemp.Length
                Case 8
                    dteDate =
                        DateSerial(CInt(Left(strTemp, 4)), CInt(strTemp.Substring(4, 2)),
                                    CInt(strTemp.Substring(6, 2)))
                Case 6
                    dteDate =
                        DateSerial(CInt("19" + Left(strTemp, 2)), CInt(strTemp.Substring(2, 2)),
                                    CInt(strTemp.Substring(4, 2)))
                Case Else
                    dteDate = DateSerial(1899, 12, 31)
            End Select

            Return Days(dteDate)

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Calculates the time difference between two dates.
        ''' </summary>
        ''' <param name="dblInputDate">A date, represented as a Decimal, that when matched against 
        ''' a base date will be used to determine the time elasped between the two.</param>
        ''' <param name="dblBaseDate">A date, represented as a Decimal, that is considered to be 
        ''' the base line by which other dates are compared to.</param>
        ''' <returns>A Decimal representing the time difference between the base date and the input date.</returns>
        ''' <remarks>  
        ''' </remarks>
        ''' <example>DecimalTime(SysDate(m_cnnQuery) + 1, SysDate(m_cnnQuery)) returns 1
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/4/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function DecimalTime(ByVal dblInputDate As Decimal, ByVal dblBaseDate As Decimal) As Decimal

            If dblInputDate = 1 / 0 Then dblInputDate = 0
            If dblBaseDate = 1 / 0 Then dblBaseDate = 0

            Dim coreDate As New OldCoreDate(dblInputDate)
            Dim dteInputDate As Date = coreDate.DateValue

            coreDate.Value = dblBaseDate

            Dim dteBaseDate As Date = coreDate.DateValue

            coreDate = Nothing

            Return DecimalTime(dteInputDate, dteBaseDate)


        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Calculates the time difference between two dates.
        ''' </summary>
        ''' <param name="dteInputDate">A date that when matched against a base date will be
        '''  used to determine the time elasped between the two.</param>
        ''' <param name="dteBaseDate">A date that is considered to be the base line by which 
        ''' other dates are compared to.</param>
        ''' <returns>A Decimal representing the difference in time between two dates.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>DecimalTime(#12/01/2001#, #13/01/2001#) returns 1
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/4/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function DecimalTime(ByVal dteInputDate As Date, ByVal dteBaseDate As Date) As Decimal

            Const cHOURS As Integer = 24
            Const cMINUTES As Integer = 60
            Const cSECONDS As Integer = 60

            Return DateDiff(DateInterval.Second, dteBaseDate, dteInputDate) / cHOURS / cMINUTES / cSECONDS

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Calculates the time difference between two dates.
        ''' </summary>
        ''' <param name="dteInputDate">A date that when matched against a base date will be 
        ''' used to determine the time elasped between the two.</param>
        ''' <param name="dblBaseDate">A date, represented as a Decimal, that is considered to 
        ''' be the base line by which other dates are compared to.</param>
        ''' <returns>A Decimal representing the time difference between the base date and the input date.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>DecimalTime(Now, SysDate(m_cnnQuery) - 1) returns 1 
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/4/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function DecimalTime(ByVal dteInputDate As Date, ByVal dblBaseDate As Decimal) As Decimal

            Const cHOURS As Integer = 24
            Const cMINUTES As Integer = 60
            Const cSECONDS As Integer = 60

            If dblBaseDate = 1 / 0 Then dblBaseDate = 0

            ' Convert the numeric value to a date value.
            Dim dteDate As Date
            Dim strTemp As String = dblBaseDate.ToString()

            strTemp = dblBaseDate.ToString()
            Select Case strTemp.Length
                Case 8
                    dteDate =
                        DateSerial(CInt(Left(strTemp, 4)), CInt(strTemp.Substring(5, 2)),
                                    CInt(strTemp.Substring(7, 2)))
                Case 6
                    dteDate =
                        DateSerial(CInt(Left(strTemp, 2)), CInt(strTemp.Substring(5, 2)),
                                    CInt(strTemp.Substring(7, 2)))
                Case Else
                    dteDate = Date.MinValue
            End Select

            Return DateDiff(DateInterval.Second, dteDate, dteInputDate) / cHOURS / cMINUTES / cSECONDS

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Calculates the time difference between two dates.
        ''' </summary>
        ''' <param name="dblInputDate">A date, represented as a Decimal, that when matched against a 
        ''' base date will be used to determine the time elasped between the two.</param>
        ''' <returns>A Decimal representing the time difference between a base date of 12/31/1899 and the input date.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>TIME_DIFF.Value = DecimalTime(CURR_TIME.Value)
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/4/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function DecimalTime(ByVal dblInputDate As Decimal) As Decimal

            If dblInputDate = 1 / 0 Then dblInputDate = 0

            Dim coreDate As New OldCoreDate(dblInputDate)
            Dim dteInputDate As Date = coreDate.DateValue
            coreDate = Nothing

            Return DecimalTime(dteInputDate)

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Calculates the time difference between two dates.
        ''' </summary>
        ''' <param name="dteInputDate">A date that when matched against a base date will be 
        ''' used to determine the time elasped between the two.</param>
        ''' <returns>A Decimal representing the time difference between a base date of 12/31/1999 and the input date.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>TIME_DIFF.Value = DecimalTime(#12/01/2001#)
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/4/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function DecimalTime(ByVal dteInputDate As Date) As Decimal

            Const cHOURS As Integer = 24
            Const cMINUTES As Integer = 60
            Const cSECONDS As Integer = 60

            Return DateDiff(DateInterval.Second, BaseDate, dteInputDate) / cHOURS / cMINUTES / cSECONDS

        End Function

        ''' --- key ----------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of key.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Private _
            key() As Byte =
                {23, 22, 86, 33, 11, 3, 67, 21, 21, 53, 8, 98, 249, 43, 98, 103, 38, 104, 105, 43, 222, 34, 45, 89}

        ''' --- iv -----------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of iv.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Private iv() As Byte = {45, 11, 45, 37, 42, 68, 102, 79}

        ''' --- Decrypt ------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Decrypt.
        ''' </summary>
        ''' <param name="EncryptedString"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function CoreDecrypt(ByVal EncryptedString As String) As String

            ' UTFEncoding is used to transform the decrypted Byte Array 
            ' information back into a string. 
            Dim utf8encoder As UTF8Encoding = New UTF8Encoding
            Dim tdesProvider As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
            Dim bytInputBytes As Byte()
            ' As before we must provide the encryption/decryption key along with 
            ' the init vector. 
            Dim cryptoTransform As ICryptoTransform = tdesProvider.CreateDecryptor(key, iv)
            ' Provide a memory stream to decrypt information into 
            Dim decryptedStream As MemoryStream = New MemoryStream
            Dim _
                cryptStream As CryptoStream =
                    New CryptoStream(decryptedStream, cryptoTransform, CryptoStreamMode.Write)

            bytInputBytes = Convert.FromBase64String(EncryptedString)
            cryptStream.Write(bytInputBytes, 0, bytInputBytes.Length)
            cryptStream.FlushFinalBlock()
            decryptedStream.Position = 0

            ' Read the memory stream and convert it back into a string 
            Dim result(Convert.ToInt16(decryptedStream.Length) - 1) As Byte
            decryptedStream.Read(result, 0, Convert.ToInt16(decryptedStream.Length))
            cryptStream.Close()
            decryptedStream.Close()

            Return utf8encoder.GetString(result)

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Decodes an encrypted key.
        ''' </summary>
        ''' <param name="strSource">The encrypted string which is to be decoded.</param>
        ''' <param name="strKey">The key used to decode the encryption.</param>
        ''' <returns>The decoded value of an encrypted string using the supplied key.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>T_PSWD.Value = Decrypt(fleUSER_PSWD.GetStringValue("PASSWORD"), "TEST")
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/4/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function Decrypt(ByVal strSource As String, ByVal strKey As String) As String

            Dim intCount As Integer
            Dim dblKey As Decimal
            Dim intSource As Integer
            Dim strDecrypt As String = String.Empty

            If strKey.Length > 0 Then
                Do While intCount < strKey.Length
                    intCount += 1
                    dblKey = dblKey + CLng(Asc(UCase(strKey.Substring(intCount - 1, 1))))
                Loop
                dblKey = Floor(dblKey / Len(strKey))
            End If

            intCount = 0
            ' Remove trailing spaces.
            strSource = strSource.TrimEnd
            Do While intCount < strSource.Length
                intCount += 1
                intSource = CInt(Asc(strSource.Substring(intCount - 1, 1)) - dblKey)

                If intSource > 255 Then
                    intSource -= 255
                ElseIf intSource <= 0 Then
                    intSource += 255
                End If
                strDecrypt &= Chr(intSource)
            Loop

            Return strDecrypt

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Encrypts a value.
        ''' </summary>
        ''' <param name="strSource">The string which is to be encrypted.</param>
        ''' <param name="strKey">The key used to encrypt the value.</param>
        ''' <returns>The encrypted value of a string using the supplied key.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>fleUSER_PSWD.SetValue("PASSWORD") = Encrypt(T_PASSWORD, "TEST")
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/4/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function Encrypt(ByVal strSource As String, ByVal strKey As String) As String

            Dim intCount As Integer
            Dim dblKey As Decimal
            Dim intSource As Integer
            Dim strEncrypt As String = String.Empty

            If Len(strKey) > 0 Then
                Do While intCount < Len(strKey)
                    intCount = intCount + 1
                    dblKey = dblKey + CLng(Asc(strKey.Substring(intCount - 1, 1)))
                Loop
                dblKey = Floor(dblKey / Len(strKey))
            End If

            intCount = 0
            ' Remove trailing spaces.
            strSource = strSource.TrimEnd
            Do While intCount < Len(strSource)
                intCount = intCount + 1
                intSource = CInt(Asc(strSource.Substring(intCount - 1, 1)) + dblKey)

                If intSource > 255 Then
                    intSource -= 255
                ElseIf intSource <= 0 Then
                    intSource += 255
                End If

                strEncrypt &= Chr(intSource)
            Loop

            Return strEncrypt

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Rounds a number down to the nearest integer.
        ''' </summary>
        ''' <param name="dblNumber">A Decimal to be used in the calculation.</param>
        ''' <returns>A Decimal representing the nearest integer below the supplied number.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/4/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function Floor(ByVal dblNumber As Decimal) As Decimal

            If dblNumber = 1 / 0 Then dblNumber = 0
            If dblNumber = 0 Then Return CDbl(dblNumber)
            If dblNumber > 0 Then ' Positive Numbers
                If InStr(1, CStr(dblNumber), ".") > 0 Then
                    Return CDbl(Left$(dblNumber.ToString, dblNumber.ToString.IndexOf(".")))
                Else
                    Return CDbl(dblNumber)
                End If
            Else ' Negative Numbers
                If InStr(1, CStr(dblNumber), ".") > 0 Then
                    Return CDbl(Left$(dblNumber.ToString, dblNumber.ToString.IndexOf("."))) - 1
                Else
                    Return CDbl(dblNumber)
                End If
            End If

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Calculates the last day of the month contained in a date.
        ''' </summary>
        ''' <param name="dblInputDate">A date, represented as a Decimal, which to find the 
        ''' last day of the month in.</param>
        ''' <returns>The last day of the supplied date.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/4/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function LastDay(ByVal dblInputDate As Decimal) As Decimal

            If dblInputDate = 1 / 0 Then dblInputDate = 0

            If dblInputDate = 0 Then
                Return dblInputDate
            Else
                Dim dblReturnValue As Decimal
                Dim coreDate As New OldCoreDate(dblInputDate)
                Dim dteInputDate As Date = coreDate.DateValue

                coreDate.DateValue = LastDay(dteInputDate)
                dblReturnValue = coreDate.Value

                coreDate = Nothing

                Return dblReturnValue
            End If

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Creates a date containing the last day of the month for the date supplied.
        ''' </summary>
        ''' <param name="dteDate">A date, represented as a Decimal, which to find the last 
        ''' day of the month in.</param>
        ''' <returns>A new date containing the last day of the month using the month of the supplied date.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/4/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function LastDay(ByVal dteDate As Date) As Date

            Try

                Return New Date(dteDate.Year, dteDate.Month, Date.DaysInMonth(dteDate.Year, dteDate.Month))

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Function


        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function Length(strExpression As String) As Integer
            Return strExpression.Length
        End Function
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Left-justifies characters in a string.
        ''' </summary>
        ''' <param name="strExpression">A string expression to be left-justified.</param>
        ''' <param name="PaddingCharacter">A string containing the character used for padding.</param>
        ''' <param name="Length">An integer representing the length of the returned string.</param>
        ''' <returns>A string which is left-justified.</returns>
        ''' <remarks>
        '''     <note>
        '''         Minimum length of Passed string will be preserved, even if Optional Length is passed.
        '''     </note>
        ''' </remarks>
        ''' <example>
        '''     <para>LeftJustify("  Test") returns "Test  "</para>
        '''     <para>LeftJustify("  Test", "*") returns "Test**"</para>
        '''     <para>LeftJustify("  Test", "*", 10) returns "Test******"</para>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/4/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function LeftJustify(ByVal strExpression As String, Optional ByVal PaddingCharacter As String = " ",
                                     Optional ByVal Length As Integer = 0) As String

            Try

                If PaddingCharacter.Trim = "" Then PaddingCharacter = " "

                If Length < strExpression.Length Then Length = strExpression.Length

                Return strExpression.Trim.PadRight(Length, CChar(PaddingCharacter))

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Compares a string to a Regular Expression Pattern.
        ''' </summary>
        ''' <param name="Value">A string containing the characters to match against the Regular Expression.</param>
        ''' <param name="RegularExpressionPattern">A string representing a PH Pattern Matching
        ''' Regular Expression.</param>
        ''' <returns>A Boolean</returns>
        ''' <remarks>This function evaluates the string value passed in against the supplied
        ''' Regular Expression Pattern. Will return True, if the pattern matches the string and False, if not.
        ''' <para>
        '''     <note>
        '''         In this function the evaluation of the Regular Expression
        '''         is customised to simulate PH Pattern Matching.
        '''     </note>
        ''' </para>
        ''' </remarks> 
        ''' <example>
        '''     EvalRegularExpressionAsPowerHousePattern("K2K 4F5", "[A-Za-z]\d[A-Za-z] \d[A-Za-z]\d") returns True
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/5/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function EvalRegularExpressionAsPowerHousePattern(ByVal Value As String,
                                                                  ByVal RegularExpressionPattern As String) As Boolean

            Dim blnReturn As Boolean = False

            Try

                blnReturn =
                    EvalRegularExpression(Value, RegularExpressionPattern.Replace("[\w~\W]{0,}", "[\w|\W]{0,}"))

                If blnReturn Then
                    Return True
                Else
                    If RegularExpressionPattern.IndexOf("|") >= 0 Then
                        Dim arrExpression() As String = RegularExpressionPattern.Split("|")

                        For i As Integer = 0 To arrExpression.Length - 1
                            If EvalRegularExpression(Value, arrExpression(i).Replace("[\w~\W]{0,}", "[\w|\W]{0,}")) _
                                Then
                                Return True
                            End If
                        Next
                        Return False

                    Else
                        Return _
                            EvalRegularExpression(Value,
                                                   RegularExpressionPattern.Replace("[\w~\W]{0,}", "[\w|\W]{0,}"))
                    End If
                End If


            Catch ex As Exception

                Try
                    If RegularExpressionPattern.IndexOf("|") >= 0 Then
                        Dim arrExpression() As String = RegularExpressionPattern.Split("|")

                        For i As Integer = 0 To arrExpression.Length - 1
                            If EvalRegularExpression(Value, arrExpression(i).Replace("[\w~\W]{0,}", "[\w|\W]{0,}")) _
                                Then
                                Return True
                            End If
                        Next
                        Return False

                    Else
                        Return _
                            EvalRegularExpression(Value,
                                                   RegularExpressionPattern.Replace("[\w~\W]{0,}", "[\w|\W]{0,}"))
                    End If
                Catch x As Exception
                    ThrowCustomApplicationException("Invalid pattern!") 'IM.InvalidPattern
                End Try

            End Try

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Compares a string to a Regular Expression Pattern.
        ''' </summary>
        ''' <param name="Value">A string containing the characters to match against the Regular Expression.</param>
        ''' <param name="RegularExpressionPattern">A string representing a PH Pattern Matching
        ''' Regular Expression.</param>
        ''' <returns>A Boolean</returns>
        ''' <remarks>This function evaluates the string value passed in against the supplied
        ''' Regular Expression Pattern. Will return True, if the pattern matches the string and False, if not.
        ''' <para>
        '''     <note>
        '''         In this function the evaluation of the Regular Expression
        '''         is customised to simulate PH Pattern Matching.
        '''     </note>
        ''' </para>
        ''' </remarks> 
        ''' <example>
        '''     EvalRegularExpressionAsPowerHousePattern("K2K 4F5", "[A-Za-z]\d[A-Za-z] \d[A-Za-z]\d") returns True
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/5/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function EvalRegularExpression(ByVal Value As String, ByVal RegularExpressionPattern As String) _
            As Boolean

            Dim objRegEx As Regex
            Dim Match As Match
            Dim objMatchCollection As MatchCollection

            Try

                objRegEx = New Regex(RegularExpressionPattern)
                objMatchCollection = objRegEx.Matches(Value)
                ' Match Pattern and get maximum matches 

                If objMatchCollection.Count = 0 Then

                    EvalRegularExpression = False

                Else

                    EvalRegularExpression = False

                    For Each Match In objMatchCollection ' Iterate Matches collection.

                        If NULL(Match.Value) = NULL(Value) Then _
                            'This condition is required to mimic PH MatchPattern!!!
                            EvalRegularExpression = True
                            Exit For
                        End If

                    Next Match

                End If

                objRegEx = Nothing
                Match = Nothing
                objMatchCollection = Nothing

                Return EvalRegularExpression

            Catch ex As Exception

                ThrowCustomApplicationException("Invalid pattern!") 'IM.InvalidPattern

            End Try

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' This method converts PowerHouse (PH) Match Pattern
        ''' into the equivallent Regular Expression (RE) Match Pattern
        ''' </summary>
        ''' <param name="PowerHousePattern">A string containing the PowerHouse Pattern which is to be translated to a Regular Expression.</param>
        ''' <returns>A string containing the translated Regular Expression (RE) Match Pattern.</returns>
        ''' <remarks>There are certain characters which require special attention.
        ''' <para>
        '''     <note>
        '''         <list type="number">
        '''             <item>This function will not replace "!0" (NULL) meta character
        '''                   which is to be checked separately.</item>
        '''             <item>"ANY" Meta Character (?) of PH is translated to a "." 
        '''                   Meta Character of RE which will allow any character
        '''                   except \n (New Line).</item>
        '''             <item>This function adds some of the RE Meta Characters as
        '''                   PH Meta Characters and then process that Meta Character as
        '''                   if they were PH Meta Character. However, this method returns it
        '''                   as a RE Meta Character.
        '''                   <para>
        '''                         This has been done considering the fact that:
        '''                         <list type="bullet">
        '''                             <item>All PH Meta Characters are also a RE Meta Characters however
        '''                                   the Reverse is not true. i.e. All RE Meta Characters are not 
        '''                                   PH Meta Character.</item>
        '''                         </list>
        '''                   </para></item>
        '''         </list>
        '''     </note>
        ''' </para>
        ''' </remarks>
        ''' <example>
        '''     GetRegularExpresssionPattern(" *#&gt; *") returns " {0,}\d{1,} {0,}"
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/5/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetRegularExpresssionPattern(ByVal PowerHousePattern As String) As String

            Dim strRegularExpressionPatern As String
            Dim i As Short
            Dim intPatternStartingIndex As Integer
            'Pattern Starting Index Position in PowerHousePattern
            Dim intNextCharacterStartingIndex As Integer
            'Next Character Starting Index Position After found pattern

            Dim strFollowingChar As String

            Try

                'Validate PH pattern against the the known invalid pattern and rectify it
                ValidatePHPattern(PowerHousePattern)

                Dim astrPowerHousePatternKeywords(11) As String
                Dim astrPowerHousePatternMetaCharacter(11) As String
                Dim astrREPatternMetaCharacter(11) As String
                strRegularExpressionPatern = PowerHousePattern

                Const TOT_PATTERN_CHARS As Short = 12

                'Defined constants for PH Pattern Keywords
                Const PH_i_ESCAPE As Short = 0
                'First character should always be an Escape Character
                Const PH_i_ALPHA As Short = 1
                Const PH_i_ANY As Short = 2
                Const PH_i_DIGIT As Short = 3
                Const PH_i_LEFTP_RIGHTP As Short = 4
                Const PH_i_NOT As Short = 5
                Const PH_i_NULL As Short = 6
                Const PH_i_OPTIONAL As Short = 7
                Const PH_i_OPTREP As Short = 8
                Const PH_i_OR As Short = 9
                Const PH_i_REPEAT As Short = 10
                Const PH_i_WILD As Short = 11

                'Defined constants to rpelace the PH Meta Characters used in Pattern
                Const PH_PTRN_KW_ESCAPE As String = "`ESCAPE`"
                Const PH_PTRN_KW_ALPHA As String = "`ALPHA`"
                Const PH_PTRN_KW_ANY As String = "`ANY`"
                Const PH_PTRN_KW_DIGIT As String = "`DIGIT`"
                Const PH_PTRN_KW_LEFTP_RIGHTP As String = "`LEFTP_RIGHTP`"
                Const PH_PTRN_KW_NOT As String = "`NOT`"
                Const PH_PTRN_KW_NULL As String = "`NULL`"
                Const PH_PTRN_KW_OPTIONAL As String = "`OPTIONAL`"
                Const PH_PTRN_KW_OPTREP As String = "`OPTREP`"
                Const PH_PTRN_KW_OR As String = "`OR`"
                Const PH_PTRN_KW_REPEAT As String = "`REPEAT`"
                Const PH_PTRN_KW_WILD As String = "`WILD`"

                'Populating an Array of PH Pattern related Keywords
                'Which is used to replace Meta Characters in a passed value
                astrPowerHousePatternKeywords(PH_i_ESCAPE) = PH_PTRN_KW_ESCAPE
                astrPowerHousePatternKeywords(PH_i_ALPHA) = PH_PTRN_KW_ALPHA
                astrPowerHousePatternKeywords(PH_i_ANY) = PH_PTRN_KW_ANY
                astrPowerHousePatternKeywords(PH_i_DIGIT) = PH_PTRN_KW_DIGIT
                astrPowerHousePatternKeywords(PH_i_LEFTP_RIGHTP) = PH_PTRN_KW_LEFTP_RIGHTP
                astrPowerHousePatternKeywords(PH_i_NOT) = PH_PTRN_KW_NOT
                astrPowerHousePatternKeywords(PH_i_NULL) = PH_PTRN_KW_NULL
                astrPowerHousePatternKeywords(PH_i_OPTIONAL) = PH_PTRN_KW_OPTIONAL
                astrPowerHousePatternKeywords(PH_i_OPTREP) = PH_PTRN_KW_OPTREP
                astrPowerHousePatternKeywords(PH_i_OR) = PH_PTRN_KW_OR
                astrPowerHousePatternKeywords(PH_i_REPEAT) = PH_PTRN_KW_REPEAT
                astrPowerHousePatternKeywords(PH_i_WILD) = PH_PTRN_KW_WILD

                'Populating an Array of Meta Characters used by PH in Match Pattern
                'Temporarily this Meta Characters will be replaced with the corresponding Keyword
                astrPowerHousePatternMetaCharacter(PH_i_ESCAPE) = "!"
                astrPowerHousePatternMetaCharacter(PH_i_ALPHA) = "^"
                astrPowerHousePatternMetaCharacter(PH_i_ANY) = "?"
                astrPowerHousePatternMetaCharacter(PH_i_DIGIT) = "#"
                astrPowerHousePatternMetaCharacter(PH_i_LEFTP_RIGHTP) = "()"
                '????
                astrPowerHousePatternMetaCharacter(PH_i_NOT) = "\"
                astrPowerHousePatternMetaCharacter(PH_i_NULL) = "!0"
                '???? NULL is to be checked separately
                astrPowerHousePatternMetaCharacter(PH_i_OPTIONAL) = "<"
                astrPowerHousePatternMetaCharacter(PH_i_OPTREP) = "*"
                astrPowerHousePatternMetaCharacter(PH_i_OR) = "|"
                astrPowerHousePatternMetaCharacter(PH_i_REPEAT) = ">"
                astrPowerHousePatternMetaCharacter(PH_i_WILD) = "@"

                'Populating an Array of RE Pattern related characters
                'This will ultimately be used in RE
                astrREPatternMetaCharacter(PH_i_ESCAPE) = "\"
                astrREPatternMetaCharacter(PH_i_ALPHA) = "[A-Za-z]"
                astrREPatternMetaCharacter(PH_i_ANY) = "."
                '????'Note:  "ANY" Meta Character (?) of PH is compared with "." Meta Character of RE which will allow any character except \n (New Line)
                astrREPatternMetaCharacter(PH_i_DIGIT) = "\d"
                astrREPatternMetaCharacter(PH_i_LEFTP_RIGHTP) = "()"
                '????
                astrREPatternMetaCharacter(PH_i_NOT) = "[^]"
                '
                astrREPatternMetaCharacter(PH_i_NULL) = "????"
                '???? NULL is to be checked separately
                astrREPatternMetaCharacter(PH_i_OPTIONAL) = "{0,1}"
                astrREPatternMetaCharacter(PH_i_OPTREP) = "{0,}"
                astrREPatternMetaCharacter(PH_i_OR) = "|"
                astrREPatternMetaCharacter(PH_i_REPEAT) = "{1,}"
                astrREPatternMetaCharacter(PH_i_WILD) = "[\w~\W]{0,}"

                'Updating following Meta Characters which infact are
                'RE Meta Characters, however it will be processed as if
                'they were PH Meta Characters
                PowerHousePattern = PowerHousePattern.Replace("+", "!+")
                PowerHousePattern = PowerHousePattern.Replace("$", "!$")
                PowerHousePattern = PowerHousePattern.Replace(".", "!.")

                'First of all Handle PH Escape Characters
                intPatternStartingIndex = PowerHousePattern.IndexOf(astrPowerHousePatternMetaCharacter(PH_i_ESCAPE))

                Do While intPatternStartingIndex >= 0
                    'Replace following character after PH Escape Meta Character,
                    'with the code to avoid conflict with other PH Meta Characters
                    intNextCharacterStartingIndex = intPatternStartingIndex + 1
                    strFollowingChar =
                        GetFollowingMetaCharacter(PowerHousePattern, intNextCharacterStartingIndex, True)

                    PowerHousePattern = PowerHousePattern.Substring(0, intPatternStartingIndex) &
                                        astrPowerHousePatternKeywords(PH_i_ESCAPE) & strFollowingChar &
                                        PowerHousePattern.Substring(intNextCharacterStartingIndex)

                    'Look for the PH Escape Character again!
                    intPatternStartingIndex =
                        PowerHousePattern.IndexOf(astrPowerHousePatternMetaCharacter(PH_i_ESCAPE))
                Loop

                'Starting from 1 as we have already handled PH Escape Characters
                For i = 1 To TOT_PATTERN_CHARS - 1
                    intPatternStartingIndex = PowerHousePattern.IndexOf(astrPowerHousePatternMetaCharacter(i))

                    Do While intPatternStartingIndex >= 0

                        Select Case astrPowerHousePatternKeywords(i)
                            Case PH_PTRN_KW_NOT
                                intNextCharacterStartingIndex = intPatternStartingIndex
                                strFollowingChar =
                                    GetFollowingMetaCharacter(PowerHousePattern, intNextCharacterStartingIndex)
                                PowerHousePattern = PowerHousePattern.Substring(0, intPatternStartingIndex) & "[^" &
                                                    strFollowingChar & "]" &
                                                    PowerHousePattern.Substring(intNextCharacterStartingIndex + 1)
                            Case PH_PTRN_KW_NULL
                                'This function should not be called to Check Null
                                'Check whether it can be replaced to check an
                                'empty string or not????
                            Case Else
                                'Replace function should replace all occurance of other Meta Characters
                                PowerHousePattern =
                                    PowerHousePattern.Replace(astrPowerHousePatternMetaCharacter(i),
                                                               astrPowerHousePatternKeywords(i))
                        End Select

                        intPatternStartingIndex = PowerHousePattern.IndexOf(astrPowerHousePatternMetaCharacter(i))

                    Loop

                Next

                For i = 0 To TOT_PATTERN_CHARS - 1
                    intPatternStartingIndex = PowerHousePattern.IndexOf(astrPowerHousePatternKeywords(i))

                    Do While intPatternStartingIndex >= 0

                        Select Case astrPowerHousePatternKeywords(i)
                            Case PH_PTRN_KW_ESCAPE
                                intNextCharacterStartingIndex = intPatternStartingIndex +
                                                                astrPowerHousePatternKeywords(PH_i_ESCAPE).Length
                                strFollowingChar =
                                    GetFollowingMetaCharacter(PowerHousePattern, intNextCharacterStartingIndex)
                                'PowerHousePattern = PowerHousePattern.Substring(0, intPatternStartingIndex - 1) & "\" & strFollowingChar & PowerHousePattern.Substring(intNextCharacterStartingIndex)
                                PowerHousePattern = PowerHousePattern.Substring(0, intPatternStartingIndex) & "\" &
                                                    strFollowingChar &
                                                    PowerHousePattern.Substring(intNextCharacterStartingIndex)
                            Case PH_PTRN_KW_NOT
                                intNextCharacterStartingIndex = intPatternStartingIndex +
                                                                astrPowerHousePatternKeywords(PH_i_NOT).Length
                                strFollowingChar =
                                    GetFollowingMetaCharacter(PowerHousePattern, intNextCharacterStartingIndex)
                                PowerHousePattern = PowerHousePattern.Substring(0, intPatternStartingIndex) & "[^" &
                                                    strFollowingChar & "]" &
                                                    PowerHousePattern.Substring(intNextCharacterStartingIndex)
                            Case PH_PTRN_KW_NULL
                                'This function should not be called to Check Null
                                'Check whether it can be replaced to check an
                                'empty string or not????
                            Case Else
                                PowerHousePattern =
                                    PowerHousePattern.Replace(astrPowerHousePatternKeywords(i),
                                                               astrREPatternMetaCharacter(i))
                        End Select

                        intPatternStartingIndex = PowerHousePattern.IndexOf(astrPowerHousePatternKeywords(i))

                    Loop

                Next

                Return PowerHousePattern
            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Function

#If TARGET_DB = "INFORMIX" Then

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Determines whether the Current User can perform in the supplied role.
        ''' </summary>
        ''' <param name="cnnQUERY">An active connection to a Informix Database.</param>
        ''' <param name="strRole">A string representing a Security Class/Role as defined in a Database.</param>
        ''' <returns>A Boolean</returns>
        ''' <remarks>Determines whether the current user is a member of the passed role(True) or not(False).
        ''' </remarks>
        ''' <example>
        '''     MatchUser(cnnQUERY, "DBA")
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/5/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Function MatchUser(ByRef cnnQUERY As IfxConnection, ByVal strRole As String) As Boolean

            Dim strSQL As String
            Dim drdreader As IfxDataReader = Nothing
            Dim blnRetVal As Boolean
            Dim objSecurityManager As New Security.SecurityManager

            Try

                strSQL = "SELECT Count(*) FROM Renaissance_Security"
                strSQL &= " WHERE User_Name = " & StringToField(Security.SecurityManager.GetCurrentUser)
                strSQL &= " AND UPPER(Security_Class) = " & StringToField(strRole.ToUpper)

                drdreader = InformixHelper.ExecuteReader(cnnQUERY, CommandType.Text, strSQL)
                drdreader.Read()
                If CInt(drdreader.GetInt32(0)) > 0 Then
                    blnRetVal = True
                Else
                    blnRetVal = False
                End If

                drdreader.Close()

                Return blnRetVal

            Catch ex As Exception

                If Not drdreader Is Nothing Then
                    If Not drdreader.IsClosed Then
                        drdreader.Close()
                    End If
                End If

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try
        End Function

#Else

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Determines whether the Current User can perform in the supplied role.
        ''' </summary>
        ''' <param name="cnnQUERY">An active connection to an Oracle Database.</param>
        ''' <param name="strRole">A string representing a Security Class/Role as defined in a Database.</param>
        ''' <returns>A Boolean</returns>
        ''' <remarks>Determines whether the current user is a member of the passed role(True) or not(False).
        ''' </remarks>
        ''' <example>
        '''     MatchUser(cnnQUERY, "DBA")
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/5/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function MatchUser(ByRef cnnQUERY As OracleConnection, ByVal strRole As String) As Boolean

            Dim strSQL As String
            Dim drdreader As OracleDataReader = Nothing
            Dim blnRetVal As Boolean
            Dim objSecurityManager As New SecurityManager

            Try
                strSQL = "SELECT Count(*) FROM Renaissance_Security"
                strSQL &= " WHERE User_Name = " & StringToField(SecurityManager.GetCurrentUser)
                strSQL &= " AND UPPER(Security_Class) = " & StringToField(strRole.ToUpper)

                drdreader = OracleHelper.ExecuteReader(cnnQUERY, CommandType.Text, strSQL)
                drdreader.Read()

                If CInt(drdreader.GetInt32(0)) > 0 Then
                    blnRetVal = True
                Else
                    blnRetVal = False
                End If

                drdreader.Close()
                drdreader.Dispose()

                Return blnRetVal

            Catch ex As Exception

                If Not drdreader Is Nothing Then
                    If Not drdreader.IsClosed Then
                        drdreader.Close()
                    End If
                    drdreader.Dispose()
                End If

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Determines whether the Current User can perform in the supplied role.
        ''' </summary>
        ''' <param name="cnnQUERY">An active connection to a SQLServer Database.</param>
        ''' <param name="strRole">A string representing a Security Class/Role as defined in a Database.</param>
        ''' <returns>A Boolean</returns>
        ''' <remarks>Determines whether the current user is a member of the passed role(True) or not(False).
        ''' </remarks>
        ''' <example>
        '''     MatchUser(cnnQUERY, "DBA")
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/5/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function MatchUser(ByRef cnnQUERY As SqlConnection, ByVal strRole As String) As Boolean

            Dim strSQL As String
            Dim drdreader As SqlDataReader = Nothing
            Dim blnRetVal As Boolean
            Dim objSecurityManager As New SecurityManager

            Try

                strSQL = "SELECT Count(*) FROM Renaissance_Security"
                strSQL &= " WHERE User_Name = " & StringToField(SecurityManager.GetCurrentUser)
                strSQL &= " AND UPPER(Security_Class) = " & StringToField(strRole.ToUpper)

                drdreader = SqlHelper.ExecuteReader(cnnQUERY, CommandType.Text, strSQL)
                drdreader.Read()
                If CInt(drdreader.GetInt32(0)) > 0 Then
                    blnRetVal = True
                Else
                    blnRetVal = False
                End If

                drdreader.Close()

                Return blnRetVal

            Catch ex As Exception

                If Not drdreader Is Nothing Then
                    If Not drdreader.IsClosed Then
                        drdreader.Close()
                    End If
                End If

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Function

#End If

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Returns a remainder after division.
        ''' </summary>
        ''' <param name="Number">A Decimal representing the dividend.</param>
        ''' <param name="NumberToDivide">A Decimal representing the divisor.</param>
        ''' <returns>A Decimal representing the remainder.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        '''     PHMOD(126,10) returns 6
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/5/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function PHMod(ByVal Number As Decimal, ByVal NumberToDivide As Decimal) As Decimal

            Try

                If Number = 1 / 0 Then Number = 0
                If NumberToDivide = 1 / 0 Then NumberToDivide = 0
                Return Number Mod NumberToDivide

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Returns a remainder after division.
        ''' </summary>
        ''' <param name="Number">An integer representing the dividend.</param>
        ''' <param name="NumberToDivide">An integer representing the divisor.</param>
        ''' <returns>An Integer representing the remainder.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        '''     PHMOD(126,10) returns 6
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/5/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function PHMod(ByVal Number As Integer, ByVal NumberToDivide As Integer) As Integer

            Try

                Return Number Mod NumberToDivide

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Creates a phonetic code from a string.
        ''' </summary>
        ''' <param name="strExpression">A string expression to be translated.</param>
        ''' <param name="intNumber">An integer representing the length of returned value.</param>
        ''' <returns>A string containing the transformed phonetic values.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        '''     Soundex("Stewart") returns "S363"
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/5/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function Soundex(ByVal strExpression As String, Optional ByVal intNumber As Integer = 4) As String

            Dim strReturnValue As String
            Dim strTemp As String
            Dim strPrevChar As String
            Dim strCurChar As String
            Dim intCount As Integer

            Try

                strReturnValue = Left$(strExpression, 1).ToUpper
                strTemp = strExpression.ToUpper
                strPrevChar = ""

                For intCount = 2 To strTemp.Length

                    If strReturnValue.Length = intNumber Then Exit For

                    strCurChar = strTemp.Substring(intCount - 1, 1)

                    If strCurChar <> strPrevChar Then

                        Select Case strCurChar

                            Case "A", "E", "I", "O", "U", "Y", "W", "H"

                            Case "B", "F", "P", "V"

                                If Not strReturnValue.EndsWith("1") Then
                                    strReturnValue &= "1"
                                End If

                            Case "C", "G", "J", "K", "Q", "X", "S", "Z"

                                If Not strReturnValue.EndsWith("2") Then
                                    strReturnValue &= "2"
                                End If

                            Case "D", "T"

                                If Not strReturnValue.EndsWith("3") Then
                                    strReturnValue &= "3"
                                End If

                            Case "L"

                                If Not strReturnValue.EndsWith("4") Then
                                    strReturnValue &= "4"
                                End If

                            Case "M", "N"

                                If Not strReturnValue.EndsWith("5") Then
                                    strReturnValue &= "5"
                                End If

                            Case "R"

                                If Not strReturnValue.EndsWith("6") Then
                                    strReturnValue &= "6"
                                End If

                        End Select

                    End If

                    strPrevChar = strCurChar

                Next

                'strReturnValue &= New String(CChar("0"), (intNumber - strReturnValue.Length))
                strReturnValue = strReturnValue.PadRight(intNumber, CChar("0"))

                Soundex = strReturnValue

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Determines the specified portion of a string.
        ''' </summary>
        ''' <param name="Value">A string which to search through and determine the returned characters.</param>
        ''' <param name="StartPosition">An integer representing the character position within the string value to start retrieving.</param>
        ''' <param name="Length">The number of characters to return, beginning from the start position.</param>
        ''' <returns>A string contained within the passed in value. </returns>
        ''' <remarks>The returned string begins at the start position within the passed in value and ends when the 
        ''' string contains the number of characters expressed in the length.
        ''' <para>
        '''     <note>
        '''         -   If the value is an empty string, then a string containing a space will be returned.<br/>
        '''         -   If the StartPosition is greater than the length of the string, then a string containing spaces
        '''             will be returned.<br/>
        '''         -   If the Length is greater than the length of the value passed in, then the value will be padded with spaces.<br/>
        '''         -   If a Length value was passed in, return the Substring using the length value, otherwise return the 
        '''             value from the start position.
        '''     </note>
        ''' </para>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/5/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function Substring(ByVal Value As String, ByVal StartPosition As Integer,
                                   Optional ByVal Length As Integer = 0) As String

            ' If Value is an empty string, 
            ' create a space.
            If Value.Length = 0 Then
                Value = " "
            End If

            ' If the StartPosition is greater than the length of the 
            ' string, then return spaces.
            If StartPosition > Value.Length Then
                If Length = 0 Then Length = 1
                Return " ".PadRight(Length)
            End If

            ' If the Length is greater than the length of the
            ' value passed in, pad the value with spaces.
            If Length > Value.Length Then
                Return Value.Substring(StartPosition - 1).PadRight(Length)
            Else
                ' If a length value was passed in, return the Substring using the
                ' length value, otherwise return the value from the start position.
                If Length > 0 Then
                    If Value.Length < (StartPosition + Length) Then
                        'Pad spaces if passed Value does not contain enough characters
                        Return Value.PadRight(StartPosition + Length - 1).Substring(StartPosition - 1, Length)
                    Else
                        Return Value.Substring(StartPosition - 1, Length)
                    End If
                Else
                    Return Value.Substring(StartPosition - 1)
                End If
            End If

        End Function


        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Determines the system date from the database.
        ''' </summary>
        ''' <param name="cnnQUERY">An active connection to an Oracle Database.</param>
        ''' <returns>The system date (in the format YYYYMMDD) from the database.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        '''     SysDate(cnnQUERY) returns "20050104"
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/5/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function SysDate(ByRef cnnQUERY As OracleConnection) As Decimal

            Dim drdReader As OracleDataReader = Nothing
            Dim strSQL As String
            Dim dblDate As Decimal

            Try
                strSQL = "SELECT TO_CHAR(SysDate,'YYYYMMDD') FROM Dual"

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
                    End If
                    drdReader.Dispose()
                End If

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Determines the system date from the database.
        ''' </summary>
        ''' <param name="cnnQUERY">An active connection to a SQLServer Database.</param>
        ''' <returns>The system date (in the format YYYYMMDD) from the database.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        '''     SysDate(cnnQUERY) returns "20050104"
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/5/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function SysDate(ByRef cnnQUERY As SqlConnection) As Decimal

            Dim drdReader As SqlDataReader = Nothing
            Dim strSQL As String
            Dim dblDate As Decimal

            Try

                Try
                    strSQL = "SELECT DATE FROM [INDEXED].[CORE_DEBUG_SYSDATE]"
                    drdReader = SqlHelper.ExecuteReader(cnnQUERY, CommandType.Text, strSQL)

                    If drdReader.Read() Then
                        dblDate = CType(drdReader(0), Decimal)
                        drdReader.Close()
                        Return dblDate
                    End If
                    drdReader.Close()
                Catch ex As Exception
                    If Not drdReader Is Nothing Then
                        If Not drdReader.IsClosed Then drdReader.Close()
                    End If
                End Try


                strSQL = "SELECT CONVERT(varchar,GETDATE(),112)"

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

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Determines the system time from the database.
        ''' </summary>
        ''' <param name="cnnQUERY">An active connection to an Oracle Database.</param>
        ''' <returns>The system time (in the format HHMMSSMS) from the database.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        '''     SysTime(cnnQUERY) returns "13212200"
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/5/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function SysTime(ByRef cnnQUERY As OracleConnection) As Decimal

            Dim drdReader As OracleDataReader = Nothing
            Dim strSQL As String
            Dim tdDateTime As DateTime

            Try
                strSQL = "SELECT SysDate FROM Dual"

                ' Fetch the result.
                drdReader = OracleHelper.ExecuteReader(cnnQUERY, CommandType.Text, strSQL)
                drdReader.Read()
                tdDateTime = drdReader.GetDateTime(0)
                drdReader.Close()
                drdReader.Dispose()
                Return GetTimeValue(tdDateTime)

            Catch ex As Exception

                If Not drdReader Is Nothing Then
                    If Not drdReader.IsClosed Then drdReader.Close()
                End If

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Determines the system time from the database.
        ''' </summary>
        ''' <param name="cnnQUERY">An active connection to a SQLServer Database.</param>
        ''' <returns>The system time (in the format HHMMSSMS) from the database.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        '''     SysTime(cnnQUERY) returns "13212200"
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/5/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function SysTime(ByRef cnnQUERY As SqlConnection) As Decimal

            Dim drdReader As SqlDataReader = Nothing
            Dim strSQL As String
            Dim dblTime As Decimal

            Try
                strSQL = "SELECT SUBSTRING(REPLACE(CONVERT(varchar,GETDATE(), 114),':',''),1,8)"

                ' Fetch the result.
                drdReader = SqlHelper.ExecuteReader(cnnQUERY, CommandType.Text, strSQL)
                drdReader.Read()
                dblTime = CType(drdReader(0), Decimal)
                drdReader.Close()
                Return dblTime

            Catch ex As Exception


                If Not drdReader Is Nothing Then
                    If Not drdReader.IsClosed Then drdReader.Close()
                End If

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Function


        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Determines the system Date Time from a database.
        ''' </summary>
        ''' <param name="cnnQUERY">An active connection to an Oracle Database.</param>
        ''' <returns>The system DateTime from the Database.</returns>
        ''' <remarks>The returned value's type is that of a Decimal. It represents an 
        ''' instant in time, typically expressed as a date and time of day.
        ''' </remarks>
        ''' <example>
        '''     SysDateTimeAsDecimal(cnnQUERY) returns 20050115202449
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/5/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function SysDateTime(ByRef cnnQUERY As OracleConnection) As Decimal

            Dim drdReader As OracleDataReader = Nothing
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
                    If Not drdReader.IsClosed Then drdReader.Close()
                End If

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Determines the system Date Time from a database.
        ''' </summary>
        ''' <param name="cnnQUERY">An active connection to an Oracle Database.</param>
        ''' <returns>The system DateTime from the Database.</returns>
        ''' <remarks>The returned value's type is that of a Decimal. It represents an 
        ''' instant in time, typically expressed as a date and time of day.
        ''' </remarks>
        ''' <example>
        '''     SysDateTimeAsDecimal(cnnQUERY) returns 20050115202449
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/5/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function SysDateTime(ByRef cnnQUERY As SqlConnection) As Decimal

            Dim drdReader As SqlDataReader = Nothing
            Dim strSQL As String
            Dim dblDate As Decimal

            Try
                strSQL =
                    "SELECT CONVERT(varchar,GETDATE(),112) + SUBSTRING(REPLACE(CONVERT(varchar,GETDATE(), 114),':',''),1,8)"

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



        ''' --- ValidatePHPattern --------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of ValidatePHPattern.
        ''' </summary>
        ''' <param name="PowerHousePattern"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub ValidatePHPattern(ByRef PowerHousePattern As String)

            ' This function checks for common mistakes found in PH Pattern strings
            ' and replaces it with rectified PH Pattern

            '1. Replace @* where * is not required as @ does include the behaviour of *
            Dim i As Integer = PowerHousePattern.IndexOf("@*")

            If i > 0 Then
                'The only place where it can be valid is !@* where @ is treated as literal character
                'well, there is also possibility of !!@* however list will grow
                'with each fix at present here we are assuming that
                '  - there will not be any pattern including !!@*
                '  - there will not be any pattern including ``*
                'in case any PH pattern includes above mentioned patterns,
                'we need to change a pattern or this code
                PowerHousePattern = PowerHousePattern.Replace("!@*", "``*")
                PowerHousePattern = PowerHousePattern.Replace("@*", "@")
                PowerHousePattern = PowerHousePattern.Replace("``*", "!@*")
            End If

        End Sub

        ''' --- GetFollowingMetaCharacter ------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	This is a support function called from GetRegularExpresssionPattern and not meant for general use
        ''' </summary>
        ''' <param name="Pattern">Pattern from which next character will be returned</param>
        ''' <param name="NextCharacterStartingIndex">Next Character Starting Index position in a passed Pattern</param>
        ''' <param name="IsAsciiCode">Optional Parameter, Defaults to False</param>
        ''' <remarks>This function will return following Meta Character either:
        '''       <para>- Literal Meta Character or</para>
        '''       <para>- Coded Meta Character</para>
        ''' <para>This function if called, should be called twice once to Code RE Meta Characters</para>
        ''' <para>IsAsciiCode - When passed as True funtion will Return Coded ASCII Value surrounded by "~"
        ''' (Tilled) character. Which in turn will be decoded while forming RE Pattern.</para>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function GetFollowingMetaCharacter(ByVal Pattern As String, ByRef NextCharacterStartingIndex As Integer,
                                                    Optional ByRef IsAsciiCode As Boolean = False) As String
            Dim i As Integer
            Dim ei As Integer
            Try
                i = NextCharacterStartingIndex
                ei = NextCharacterStartingIndex

                If IsAsciiCode Then

                    'Return Character's ASCII Code
                    If Pattern.Substring(i, 1) = "`" Then 'i.e. Already coded PH Meta Character
                        ei = Pattern.IndexOf("~", i + 1)
                        'Starting of ASCII Code
                        ei = Pattern.IndexOf("~", ei + 1)
                        'Ending of ASCII Code
                        GetFollowingMetaCharacter = Pattern.Substring(i, ei)
                        NextCharacterStartingIndex = ei
                    Else
                        GetFollowingMetaCharacter = "~" & Asc(Pattern.Substring(i, 1)) & "~"
                    End If

                Else

                    'Return Character itself
                    If Pattern.Substring(i, 1) = "~" Then 'i.e. ASCII Code
                        ei = Pattern.IndexOf("~", i + 1)
                        'Starting of ASCII Code
                        'ei = InStr(ei + 1, Pattern, "~") 'Ending of ASCII Code
                        GetFollowingMetaCharacter = Pattern.Substring(i + 1, ei - i - 1)
                        GetFollowingMetaCharacter = Chr(CInt(GetFollowingMetaCharacter))
                        NextCharacterStartingIndex = ei
                    Else
                        GetFollowingMetaCharacter = Pattern.Substring(i + 1, 1)
                    End If

                End If

                NextCharacterStartingIndex = NextCharacterStartingIndex + 1
                'Next Starting Character

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Function

#End Region

#Region "Miscellaneous Functions"

        Public Function Numeric(ByVal strText As String) As Boolean
            Return IsNumeric(strText)
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' Replaces the vbCr + vbLf with a vbCr.
        ''' </summary>
        ''' <param name="InputFile">A string representing the file to read.</param>
        ''' <param name="OutputFile">A string representing the file to create.</param>
        ''' <param name="DeleteInputFile">A boolean indicating to delete the input file.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        '''     ApplyCharacterFormatting(FieldText, sender.Picture)
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/5/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub Dos2Unix(ByVal InputFile As String, ByVal OutputFile As String,
                             Optional ByVal DeleteInputFile As Boolean = False)

            Dim content As String = String.Empty
            Dim s As StreamReader = New StreamReader(InputFile, True)
            Dim currentEncoding As Encoding = Encoding.Default
            ' s.CurrentEncoding  ' This added strange characters at the beginning of the file
            content = s.ReadToEnd()

            ' Replace linefeeds with newline character.
            content = content.Replace(vbNewLine, vbLf)

            s.Close()
            s.Dispose()

            If DeleteInputFile Then
                File.Delete(InputFile)
            End If

            Dim sw As StreamWriter = New StreamWriter(OutputFile, False, currentEncoding)
            sw.Write(content)
            sw.Close()
            sw.Dispose()

        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' Replaces the vbCr with a vbCr + vbLf.
        ''' </summary>
        ''' <param name="InputFile">A string representing the file to read.</param>
        ''' <param name="OutputFile">A string representing the file to create.</param>
        ''' <param name="DeleteInputFile">A boolean indicating to delete the input file.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        '''     ApplyCharacterFormatting(FieldText, sender.Picture)
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/5/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub Unix2Dos(ByVal InputFile As String, ByVal OutputFile As String,
                             Optional ByVal DeleteInputFile As Boolean = False)

            Dim content As String = String.Empty
            Dim s As StreamReader = New StreamReader(InputFile, True)
            Dim currentEncoding As Encoding = Encoding.Default
            ' s.CurrentEncoding ' This added strange characters at the beginning of the file
            content = s.ReadToEnd()

            ' Replace linefeeds with newline character.
            content = content.Replace(vbLf, vbNewLine)

            s.Close()
            s.Dispose()

            If DeleteInputFile Then
                File.Delete(InputFile)
            End If

            Dim sw As StreamWriter = New StreamWriter(OutputFile, False, currentEncoding)
            sw.Write(content)
            sw.Close()
            sw.Dispose()

        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' Applies character formatting prior to displaying value.
        ''' </summary>
        ''' <param name="Value">A string representing the characters to be formatted.</param>
        ''' <param name="Picture">A string representing the format to apply to the value.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        '''     ApplyCharacterFormatting(FieldText, sender.Picture)
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/5/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub ApplyCharacterFormatting(ByRef Value As String, ByVal Picture As String)
            Try
                Dim strTemp As New StringBuilder
                Dim intPicturePosition As Integer = 0
                Dim intValuePosition As Integer = 0

                If Picture.Length = 0 Then
                    Exit Sub
                End If

                For intPicturePosition = 0 To Picture.Length - 1

                    Select Case Picture.Substring(intPicturePosition, 1)
                        Case "^" 'Substitute Character

                            If Value.Length - 1 < intValuePosition Then _
                                'If Length of Picture is higher then the passed String Value
                                strTemp.Append(" ")
                                'Pad spaces
                            Else
                                strTemp.Append(Value.Substring(intValuePosition, 1))
                                'Concate the a character from the passed String Value
                            End If

                            intValuePosition += 1

                        Case "" 'Length of Picture is less than Value

                            Exit For
                            'Return Truncated String

                        Case Else 'Non-substitute Character

                            strTemp.Append(Picture.Substring(intPicturePosition, 1))
                            'Concate the a non-substitute character from the passed Picture

                    End Select

                Next

                Value = strTemp.ToString
                strTemp = Nothing

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Sub

        '-------------------------------------------------------------------
        ' Name: ApplyDateFormatting
        ' Function: Applies date formatting prior to displaying value.
        ' Example: ApplyDateFormatting(FieldText, sender.Picture, 
        '                       sender.Significance)
        '-------------------------------------------------------------------
        ''' --- ApplyDateFormatting ------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of ApplyDateFormatting.
        ''' </summary>
        ''' <param name="Value"></param>
        ''' <param name="Format"></param>
        ''' <param name="Separator"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub ApplyDateFormatting(ByRef Value As String, ByVal [Format] As String, ByVal Separator As String)

            ' TODO: Add code for ApplyDateFormatting.

        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' Applies numeric formatting prior to displaying the fieldtext value.
        ''' </summary>
        ''' <param name="ElementName">The name of the element being formatted.  Blank for a Temporary or Define.</param>
        ''' <param name="FieldText">The string which is to be formatted.</param>
        ''' <param name="BWZFlag">A boolean indicating if FieldText should be blank when it's value is zero.</param>
        ''' <param name="TrailingSign">A string used to indicate a negative number. Usually 'CR' or ')'.</param>
        ''' <param name="LeadingSign">A string used to indicate a negative number. Usually ' ' or '('.</param>
        ''' <param name="Picture">A string of characters and metacharacters that provides a general description of values.</param>
        ''' <param name="Significance">An integer specifying the minimum number of characters displayed.</param>
        ''' <param name="FillCharacter">A string containing the character used to "fill" unused space to the left in the picture.</param>
        ''' <param name="FloatCharacter">A string character which is inserted immediately to the left of the most significant digit.</param>
        ''' <param name="FieldSize">An integer specifying the number of characters in the FieldText.</param>
        ''' <param name="Decimal">An integer indicating the number of places to display after the point.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        '''     ApplyNumericFormatting(strText, "0001", "(", ")", " ^^^^^^.^^ ", 5, "*", "$", 8, 4, ItemDataTypes.SignedInteger, 2)
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/5/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function ApplyNumericFormatting(ByVal ElementName As String, ByRef FieldText As String,
                                                ByVal BWZFlag As BooleanTypes,
                                                ByVal TrailingSign As String,
                                                ByVal LeadingSign As String,
                                                ByRef Picture As String,
                                                ByVal Significance As Integer,
                                                ByVal FillCharacter As String,
                                                ByVal FloatCharacter As String,
                                                ByVal FieldSize As Integer, ByVal ItemSize As Integer,
                                                ByVal ItemDataType As ItemDataTypes,
                                                Optional ByVal DataType As DataTypes = DataTypes.NotSet,
                                                Optional ByVal [Decimal] As Integer = 0,
                                                Optional ByVal InputScale As Integer = 0,
                                                Optional ByVal ThousandSeperator As String = ",") As String

            Dim strTempText As String
            Dim strPicture As String
            Dim dblTempValue As Decimal
            Dim intPictureLength As Integer
            Dim isOverflowed As Boolean
            Const PAD_CHARACTER As String = " "
            'In case there is need to pad Space, uncomment all statement which uses PAD_CHARACTER

            ' If we have a Temporary/Define, no thousand seperator is added to the generated picture. 
            If ElementName.Length = 0 Then ThousandSeperator = String.Empty

            Try
                Dim i As Integer
                Dim strTempStringBuilder As StringBuilder
                Dim intSignOfValue As Integer
                Dim IsPictureCalculated As Boolean = False

                ' Remove leading spaces.
                FieldText = FieldText.TrimStart

                ' Remove Leading Zero's if underlying datatype is Character.
                If ItemDataType = ItemDataTypes.Character And DataType = DataTypes.Numeric Then
                    FieldText = VAL(FieldText)
                End If

                ' For reports, set the datatype to the item datatype.
                If DataType = DataTypes.NotSet Then
                    Select Case ItemDataType
                        Case ItemDataTypes.Character
                            DataType = DataTypes.Character
                        Case ItemDataTypes.Date
                            DataType = DataTypes.Date
                        Case Else
                            DataType = DataTypes.Numeric
                    End Select
                End If

                If _
                    ItemDataType = ItemDataTypes.Character AndAlso FieldText = "0" AndAlso
                    Not DataType = DataTypes.Numeric AndAlso Not BWZFlag = BooleanTypes.True Then
                    BWZFlag = BooleanTypes.True
                End If

                strTempText = FieldText
                isOverflowed = False
                strPicture = Picture

                '-------------------
                'Apply BWZ
                '-------------------
                If BWZFlag = BooleanTypes.True AndAlso (strTempText.Trim = "" OrElse CDbl(strTempText) = 0) Then
                    strTempText = cEmptyString
                    Exit Try
                End If

                '-------------------
                'Apply Decimal
                '-------------------
                If [Decimal] >= 0 Then

                    If strTempText.LastIndexOf(".") >= 0 Then

                        ' TODO: Following "If" condition and commented code
                        ' can be removed once we find a solution for 
                        ' the below mentioned case
                        If strTempText.Substring(strTempText.LastIndexOf(".") + 1).Length > [Decimal] Then
                            ' Although, legacy displays an error "Too many decimal..." 
                            ' when user enters Value with decimal in a field which is 
                            ' not expecting Decimal i.e. for Integer
                            ' or Numeric with Decimal set to 0 in dictionary, 
                            ' however,here we have assumed that "Too many Decimal" 
                            ' error is handled in Validate Function
                            ' 
                            ' Following code simply "Truncates" the Decimal Value assuming that
                            ' the value is assigned interenally by code and not entered by user 
                            ' on a Screen.
                            ' 
                            ' We may have to remove this code when a FileObject 
                            ' becomes aware of Dictionary Values and when it can 
                            ' read whether Field allows Decimals or not.

                            ' We tested following code which did truncates the decimal
                            ' However during test (6ft 7in)in OFF003, Height which is a singed integer
                            ' field and being assigned in calculation (not user input), which rounds 
                            ' the value to 201 although following code returns as 200 i.e. after
                            ' truncating decimals from 200.66.
                            strTempText = Round(strTempText, [Decimal])
                        End If

                        If strTempText.IndexOf(".") > -1 Then
                            strTempText = strTempText.Substring(0, strTempText.LastIndexOf(".") + 1) &
                                          strTempText.Substring(strTempText.LastIndexOf(".") + 1).PadRight([Decimal],
                                                                                                              CChar("0")) _
                                              .Substring(0, [Decimal])
                        Else
                            strTempText = strTempText & "." & "".PadRight([Decimal], "0")
                        End If

                    Else 'If no Decimals in Value entered by user 
                        If InputScale <= 0 AndAlso [Decimal] > 0 Then
                            'Treat entered value as Integer Value for that we need to Pad necessary Zeros as decimal
                            If _
                                strPicture.Length > 0 AndAlso
                                [Decimal] <= Occurs(strPicture.Substring(strPicture.IndexOf(".") + 1), "^") Then
                                [Decimal] = Occurs(strPicture.Substring(strPicture.IndexOf(".") + 1), "^")
                            End If
                            If strTempText = "0" Then
                                strTempText &= New String(CChar("0"), [Decimal])
                            Else
                                strTempText = strTempText.PadRight([Decimal] + 1, "0")
                            End If


                        End If
                    End If

                End If

                '-------------------
                'Populate variables required to apply Numeric formatting
                '-------------------

                'Pass Scaled Integer Value for Formatting
                strTempText = strTempText.Replace(".", "")

                If strTempText = "" Then
                    dblTempValue = CDbl(0)
                Else
                    dblTempValue = CDbl(strTempText)
                End If

                'Check and store the sign of the value 
                intSignOfValue = Math.Sign(dblTempValue)

                If intSignOfValue < 0 Then
                    'Store positive value in as Text that will be used to apply strPicture
                    strTempText = Math.Abs(dblTempValue).ToString
                End If

                Dim intSignLength As Integer = 0
                If LeadingSign.Length > 0 OrElse TrailingSign.Length > 0 Then intSignLength = 1

                '-------------------
                'Added following code to generate default strPicture and 
                'display formatted number in case if
                'strPicture is not defined in QKS/Dictionary. 
                'In this PH displays formatted numbers e.g. 1234 with Size 4
                'Gets displayed as 1,234 and -123 as -123
                '-------------------
                If strPicture.Trim.Length = 0 Then
                    Dim intIntegerResult As Integer
                    Dim intRemainder As Integer

                    intIntegerResult = ((FieldSize - intSignLength) - [Decimal]) \ 3
                    intRemainder = ((FieldSize - intSignLength) - [Decimal]) Mod 3

                    strTempStringBuilder = New StringBuilder
                    If [Decimal] > 0 Then
                        strTempStringBuilder.Insert(0, "^", [Decimal])
                        strTempStringBuilder.Insert(0, ".")
                    End If

                    If Significance = 0 Then
                        For i = 1 To intIntegerResult
                            strTempStringBuilder.Insert(0, ThousandSeperator + "^^^", 1)
                        Next

                        If intRemainder = 0 Then
                            If Not ThousandSeperator.Length = 0 Then
                                If strTempStringBuilder.Length > 0 Then strTempStringBuilder.Remove(0, 1)
                            End If
                        Else
                            strTempStringBuilder.Insert(0, "^", intRemainder)
                        End If

                    ElseIf Significance > (FieldSize - intSignLength) Then
                        strTempStringBuilder.Insert(0, "^", Significance)
                    Else
                        strTempStringBuilder.Insert(0, "^", (FieldSize - intSignLength))

                    End If

                    If LeadingSign.Length > 0 Then strTempStringBuilder.Insert(0, " ", LeadingSign.Length)
                    If TrailingSign.Length > 0 Then strTempStringBuilder.Append(" "c, TrailingSign.Length)

                    strPicture = strTempStringBuilder.ToString
                    Picture = strPicture
                    'Pass back the calculated Picture
                    IsPictureCalculated = True

                End If

                If FillCharacter.Length > 0 AndAlso ThousandSeperator <> "" Then
                    'If Fill Character is specified, remove the Comma and Leading Spaces
                    strPicture = strPicture.Replace(ThousandSeperator, String.Empty).TrimStart
                End If

                intPictureLength = strPicture.Length

                '-------------------
                'Apply strPicture
                '-------------------
                If ItemDataType = ItemDataTypes.Integer OrElse ItemDataType = ItemDataTypes.SignedInteger Then
                    Dim decValue As Decimal = CDec(FieldText.Trim)
                    If ItemSize = 0 Then ItemSize = 2
                    If ItemDataType = ItemDataTypes.Integer Then
                        ' Check if value is within range of Integer (unsigned) based on Item size.
                        If decValue < 0 Then
                            ' This entry must not be negative.
                            Return "This entry must not be negative." 'IM.Negative
                        ElseIf decValue > CDec((2 ^ (8 * ItemSize)) - 1) Then
                            Return "This entry isn't within the acceptable range of values" 'IM.Range
                        End If
                    ElseIf ItemDataType = ItemDataTypes.SignedInteger Then
                        ' Check if value is within range of SignedInteger based on Item size.
                        If decValue < -2 ^ ((8 * ItemSize) - 1) OrElse decValue > (2 ^ ((8 * ItemSize) - 1) - 1) Then
                            Return "This entry isn't within the acceptable range of values" 'IM.Range
                        End If
                        ' Perform additional checks to SignedInteger (as with Numeric)
                        ' If deciamal point is to be applied then if entered value size plus decimal > fieldsize then error
                        Dim decimalCount As Integer = 0
                        If [Decimal] > 0 Then decimalCount = 1
                        If strTempText.Length + decimalCount > FieldSize Then
                            Return "This entry isn't within the acceptable range of values" 'IM.Range
                        End If
                        ' Check if too many chars were entered based on field length
                        Dim OriginalMaxLength As Integer = FieldSize
                        If _
                            (TrailingSign.Length > 0 OrElse LeadingSign.Length > 0) AndAlso
                            Picture.Trim.Length < Picture.Length Then
                            OriginalMaxLength -= 1
                        End If
                        If Picture.IndexOf(".") > 0 Then
                            OriginalMaxLength -= 1
                        End If
                        If strTempText.Length > OriginalMaxLength Then
                            Return "This entry isn't within the acceptable range of values" 'IM.Range
                        End If

                    End If
                ElseIf ItemDataType = ItemDataTypes.Numeric Then
                    Dim decimalCount As Integer = 0
                    If [Decimal] > 0 Then decimalCount = 1
                    If strTempText.Length + decimalCount > FieldSize Then
                        'Return "This entry isn't within the acceptable range of values"'IM.Range
                    End If
                    Dim OriginalMaxLength As Integer = FieldSize
                    If _
                        (TrailingSign.Length > 0 OrElse LeadingSign.Length > 0) AndAlso
                        Picture.Trim.Length < Picture.Length Then
                        OriginalMaxLength -= 1
                    End If
                    If Picture.IndexOf(".") > 0 Then
                        OriginalMaxLength -= 1
                    End If
                    If strTempText.Length > OriginalMaxLength Then
                        'Return "This entry isn't within the acceptable range of values"'IM.Range
                    End If
                ElseIf ItemDataType = ItemDataTypes.UnsignedNumeric Then
                    If CType(strTempText, Decimal) <> 0 Then
                        Dim decimalCount As Integer = 0
                        If [Decimal] > 0 Then decimalCount = 1
                        If strTempText.Length + decimalCount > FieldSize Then
                            'Return "This entry isn't within the acceptable range of values"'IM.Range
                        End If
                        Dim OriginalMaxLength As Integer = FieldSize
                        If Picture.IndexOf(".") > 0 Then
                            OriginalMaxLength -= 1
                        End If
                        If strTempText.Length > OriginalMaxLength Then
                            'Return "This entry isn't within the acceptable range of values"'IM.Range
                        End If
                    End If

                End If

                Dim intPicturePosition As Integer = 0
                Dim intValuePosition As Integer = 0

                Dim intUpHatCount As Integer = Occurs(strPicture, "^")
                If intUpHatCount < strTempText.Length Then

                    'If the length of the strPicture is less then the Length of the value
                    'Pass #...
                    strTempText = New String(CChar("#"), intPictureLength)
                    isOverflowed = True
                    Exit Try
                End If

                'Note: If strPicture is not defined in QKS/Dictionary 
                'for a "Field" with "Size" of 4, 
                'Although PH displays six # signs for 12345, 
                'this function will return as #### (4 # signs)
                'This is done to avoid Size Error

                ' TODO: to be tested in .Net Version of Buffer (rsMain etc in previous version)
                If IsPictureCalculated And strTempText.Length > FieldSize Then
                    strTempText = New String(CChar("#"), FieldSize)
                    isOverflowed = True
                    Exit Try
                End If

                strTempStringBuilder = New StringBuilder
                intValuePosition = strTempText.Length - 1
                Dim strPictureCharacter As String

                For intPicturePosition = intPictureLength - 1 To 0 Step -1

                    strPictureCharacter = strPicture.Substring(intPicturePosition, 1)

                    Select Case strPictureCharacter
                        Case "^" 'Substitute Character

                            If intValuePosition < 0 Then 'If Length of strPicture is higher then the passed String Value

                                If Significance > 0 Then
                                    strTempStringBuilder.Insert(0, "0")
                                    'Pad Zeros
                                Else
                                    strTempStringBuilder.Insert(0, PAD_CHARACTER)
                                    'Pad Character
                                End If

                            Else

                                strTempStringBuilder.Insert(0, strTempText.Substring(intValuePosition, 1))
                                'Concate the a character from the passed String Value

                            End If

                            intValuePosition -= 1
                            'To be incremented only in case of Substitute character

                        Case ""

                            'If Length of strPicture is less than Value
                            'Note: Unless it is changed, this should not be 
                            'the case, at least in this "For" loop, as this
                            'case is already handled above this "For" loop

                        Case Else 'Non-substitute Character

                            If intValuePosition >= 0 Then '

                                If strTempText.Substring(intValuePosition, 1) = " " Then
                                    strTempStringBuilder.Insert(0, " ")
                                    'Insert a space instead of non-substitute character
                                Else
                                    'Concate the a non-substitute character from the passed strPicture
                                    strTempStringBuilder.Insert(0, strPicture.Substring(intPicturePosition, 1))
                                End If
                            ElseIf intValuePosition < 0 And Significance <= 0 Then
                                strTempStringBuilder.Insert(0, " ")
                                'Insert a space instead of non-substitute character
                            ElseIf Significance > 0 Then 'Don't display leading non-substitute character 
                                'Concate the a non-substitute character from the passed strPicture
                                strTempStringBuilder.Insert(0, strPicture.Substring(intPicturePosition, 1))
                            End If

                    End Select

                    Significance -= 1

                Next

                strTempText = strTempStringBuilder.ToString
                strTempStringBuilder = Nothing

                '-------------------
                'Apply Float Character
                '-------------------
                If FloatCharacter <> "" Then

                    If intPictureLength >= strTempText.TrimStart.Length + FloatCharacter.Length Then
                        'If there is enough Substitution/Non-Substitution characters for Float Character in strPicture 
                        strTempText = FloatCharacter & strTempText.TrimStart
                        strTempText = strTempText.PadLeft(intPictureLength, CChar(PAD_CHARACTER))
                    Else
                        'Error in Legacy/During Migration
                    End If

                End If

                '-------------------
                'Apply Leading and/or Trailing Sign
                '-------------------
                If intSignOfValue < 0 Then

                    If intSignOfValue < 0 And LeadingSign.Trim = "" And TrailingSign.Trim = "" Then
                        ' Note: Legacy application does not accept negative numbers if leading sing is blank for Signed Integer
                        ' TODO: For Signed Integer when Negative values with Empty ("") LeadingSign are entered in legacy it results an error.
                        ' TODO: To generate above mentioned error we need a way to differentiate between Blank Parameter and Empty Value.
                        ' TODO: During FE, In DICTIONARY, we need to generate "-" Leading Sign for Signed/Numeric fields without Leading Sign in Dictionary OR we need to make provision in this function to determine whether the field is a Signed Integer/Numeric or not.

                        If _
                            ItemDataType = ItemDataTypes.Integer OrElse ItemDataType = ItemDataTypes.SignedInteger OrElse
                            ItemDataType = ItemDataTypes.UnsignedNumeric OrElse ItemDataType = ItemDataTypes.Character _
                            Then
                            ' This entry must not be negative.
                            Return "This entry must not be negative." 'IM.Negative
                        Else
                            ' We have a value that doesn't have a Leading/Trailing sign.  Ensure that there are enough
                            ' substitution characters in the picture to allow for the negative sign.
                            Dim intDecimalCount As Integer = 0
                            If strPicture.IndexOf(".") > -1 Then intDecimalCount = 1
                            If strTempText.Replace(",", "").Trim.Length + 1 <= intUpHatCount + intDecimalCount Then
                                strTempText = ("-" & strTempText.Trim).PadLeft(strTempText.Length, " ")
                            Else
                                strTempText = New String(CChar("#"), intPictureLength)
                                isOverflowed = True
                                Exit Try
                            End If
                        End If

                    End If


                    'Apply Leading Sign
                    If LeadingSign.Trim <> "" Then

                        If intPictureLength >= strTempText.TrimStart.Length + LeadingSign.Length Then

                            'If there is enough Substitution/Non-Substitution characters for Leading Sign in strPicture 
                            strTempText = LeadingSign & strTempText.TrimStart
                            strTempText = strTempText.PadLeft(intPictureLength, CChar(PAD_CHARACTER))

                        Else

                            'strPicture must have sufficient space to display Leading Sign
                            '
                            'Check following possibilities
                            '   1. strPicture Generated by FE is changed by developer
                            '   2. FE does not generated strPicture properly
                            '   3. Legacy Code might have wrong strPicture

                            strTempText = New String(CChar("#"), intPictureLength)
                            isOverflowed = True
                            Exit Try

                        End If

                    End If

                    'Apply Trailing Sign
                    If TrailingSign.Trim <> "" Then

                        If strPicture.EndsWith("^") Then

                            'strPicture must have sufficient space to display Trailing sign
                            '
                            'Check following possibilities
                            '   1. strPicture Generated by FE is changed by developer
                            '   2. FE does not generated strPicture properly
                            '   3. Legacy Code might have wrong strPicture
                            strTempText = New String(CChar("#"), intPictureLength)
                            isOverflowed = True
                            Exit Try


                        Else

                            'In following code it is assumed that there is enough 
                            'Non-substitution characters in strPicture for Trailing Sign,
                            'even with Trailing Sign with more than one character
                            strTempText = strTempText.Substring(0, strTempText.Length - TrailingSign.Length) &
                                          TrailingSign

                        End If

                    End If

                End If

                '-------------------
                'Apply Fill Character
                '-------------------
                If FillCharacter.Trim <> "" Then
                    strTempText = strTempText.Trim()
                    strTempText = strTempText.PadLeft(intPictureLength, CChar(FillCharacter))
                End If

            Catch ex As Exception
                'MsgBox("Error: " & ex.Message & vbCrLf & ex.StackTrace)

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

            '-------------------
            'Prepare Return Value
            '-------------------
            FieldText = strTempText

            Return String.Empty
        End Function


        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' Converts the screen date to a PowerHouse date.
        ''' </summary>
        ''' <param name="Value">A string containing the screen date.</param>
        ''' <param name="DateAsNumber">A Decimal used as an output parameter containing the PowerHouse Date.</param>
        ''' <param name="GlobalizationManager">The GlobalizationManager object.</param>
        ''' <param name="DateFormat">A string representing an optional date format.</param>
        ''' <param name="DateSeparator">A string representing an optional date separator.</param>
        ''' <returns>A boolean indicating the screen date is valid and has been converted.</returns>
        ''' <remarks>If the screen date is determinedd to be a valid date, it will under go a convertion to a 
        ''' PowerHouse date, in the format YYYYMMDD. The result will be stored in the output parameter DateAsNumber.
        ''' <para>
        '''     This function only supports the combination of the following formats:
        '''         <list type="bullet">
        '''             <item>  Month: M, MM and MMM</item>
        '''             <item>  Day: D and DD</item>
        '''             <item>  Year: YYYY</item>
        '''         </list>
        ''' </para>
        ''' <para>
        '''     <note>
        '''         <list type="number">
        '''             <item>  Comparable number of digits are not matched with the passed format
        '''                     as such Parameters like "12/2/2002" with format "MM/DD/YYYY" will
        '''                     return "20021202" and will not cause an error.</item>
        '''             <item>  Unlike standard .Net Format functions above Format is case insensitive.</item>
        '''             <item>  GlobalizationManager should ideally be passed from a shared field of Page object 
        '''                     e.g. Page.GlobalizationManager.</item>
        '''             <item>  Although GlobalizationManager parameter is passed as ByRef it is not being updated 
        '''                     and should not be updated in the future.</item>
        '''         </list>
        '''     </note>
        ''' </para>
        ''' </remarks>
        ''' <example>
        '''     <para>ConvertScreenDateToNumber("12/22/2002", FieldValue, Page.GlobalizationManager) returns True and sets FieldValue to 20021222.0</para>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/5/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function ConvertScreenDateToNumber(ByVal Value As String, ByRef DateAsNumber As Decimal,
                                                   ByRef GlobalizationManager As GlobalizationManager,
                                                   Optional ByVal DateFormat As String = Nothing
                                                   ) As Boolean

            If Value = "" Then
                DateAsNumber = 0
                Return True
            End If

            If DateFormat = "dd/MM/yyyy" AndAlso Value.IndexOf("/") = -1 Then
                DateAsNumber = Convert.ToInt32(Value.Substring(4, 4) + Value.Substring(2, 2) + Value.Substring(0, 2))
                Return True
            End If

            Dim dValue As New Date?(Value)

            DateAsNumber = Convert.ToInt32(dValue.Value.Year.ToString + dValue.Value.Month.ToString.PadLeft(2, "0") + dValue.Value.Day.ToString.PadLeft(2, "0"))

            Return True

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Determines if a valid date is found.
        ''' </summary>
        ''' <param name="Year">An integer representing the year.</param>
        ''' <param name="Month">An integer representing the month.</param>
        ''' <param name="Day">An integer representing the day.</param>
        ''' <param name="DateAsNumber">A Decimal containing the processed date.</param>
        ''' <returns>A boolean indicating if there is a valid date.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        '''     IsValidDate(2005, 11, 12) returns true.
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/5/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function IsValidDate(ByVal Year As Integer, ByVal Month As Integer, ByVal Day As Integer,
                                     Optional ByRef DateAsNumber As Decimal = 0) As Boolean

            ' Return false if this is not a valid date.
            Try
                Dim dteDate As Date
                'By assigning a new date to "dteDate" we are just
                'checking whether this is a valid date or not.
                'This is done to avoid any formatting issue 
                'while converting string to date.
                dteDate = New DateTime(Year, Month, Day)

                DateAsNumber =
                    CDbl(
                        Year.ToString.PadLeft(4, CChar("0")) & Month.ToString.PadLeft(2, CChar("0")) &
                        Day.ToString.PadLeft(2, CChar("0")))

                Return True

            Catch ex As Exception
                Return False

            End Try

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Determines the number corresponding to the abbreviated month name.
        ''' </summary>
        ''' <param name="AbbreviatedMonthName">A string containing the name of a month in abbreviated form.</param>
        ''' <param name="GlobalizationManager">The GlobalizationManager objec.</param>
        ''' <returns>A number representing the chosen month.</returns>
        ''' <remarks>
        '''     <note>
        '''         1. This function relies on GlobalizationManager for Abbreviated Month Names.
        '''         <br/><br/>
        '''         2. By default GlobalizationManager and inturn DateTimeFormat 
        '''         object returns Months Array with 13 elements and so does this function.
        '''         <br/><br/>
        '''         3. GlobalizationManager should ideally be passed from a shared field of Page object
        '''         e.g. Page.GlobalizationManager. Although GlobalizationManager parameter is passed
        '''         ByRef, it is not being updated and should not be updated in future.
        '''     </note>
        ''' </remarks>
        ''' <example>
        '''     ConvertScreenDateToNumber("Jun", Page.GlobalizationManager) returns 6
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/5/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function GetMonthNumberForAbbreviatedMonth(ByVal AbbreviatedMonthName As String,
                                                           ByRef GlobalizationManager As GlobalizationManager) As Short

            Dim astrAbbreviatedMonthNames As String()
            Dim i As Integer

            astrAbbreviatedMonthNames = GlobalizationManager.AbbreviatedMonthNames
            For i = 0 To astrAbbreviatedMonthNames.GetUpperBound(0)
                If astrAbbreviatedMonthNames(i).ToUpper = AbbreviatedMonthName.ToUpper Then
                    Exit For
                End If
            Next

            Return CShort(i + 1)

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' Formats a value, representing a date, to an optional date format or to the defaulted date format of the current culture.
        ''' </summary>
        ''' <param name="Value">A Decimal representing a valid date.</param>
        ''' <param name="GlobalizationManager">The GlobalizationManager object.</param>
        ''' <param name="DateFormat">A string representing an optional date format.</param>
        ''' <param name="DateSeparator">A string representing an optional date separator.</param>
        ''' <returns>A string containing a date.</returns>
        ''' <remarks>DateFormat is Optional and Case Sensitive.
        ''' <para>
        '''     <note>
        '''         <list type="number">
        '''             <item>  If the DateFormat is passed in, it should take the format as supported by
        '''                     "Format" function defined in Microsoft.VisualBasic Namespace</item>
        '''             <item>  GlobalizationManager should ideally be passed from a shared field of Page object
        '''                     e.g. Page.GlobalizationManager.Although GlobalizationManager parameter is passed ByRef,
        '''                     it is not being updated and should not be updated in future.</item>
        '''         </list>
        '''     </note>
        ''' </para>
        ''' </remarks>
        ''' <example>
        '''     ConvertNumberToScreenDate(20021222, Page.GlobalizationManager, "m/d/YYYY") returns "12/22/2002"
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/5/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function ConvertNumberToScreenDate(ByVal Value As Decimal,
                                                   ByRef GlobalizationManager As GlobalizationManager,
                                                   Optional ByVal DateFormat As String = "",
                                                   Optional ByVal DateSeparator As String = Nothing,
                                                   Optional ByVal NoSeparator As Boolean = False) As String
            Dim strValue As String
            Dim srtDay As Short
            Dim srtMonth As Short
            Dim srtYear As Short
            Dim dteDate As Date
            Dim strDateFormatWithSeparator As String = String.Empty

            Try

                If DateFormat.Trim.Length = 0 Then DateFormat = GlobalizationManager.ShortDatePattern

                'Now DefaultDateSeparator needs to be passed from calling function, and if we want to
                'use DateSeparator from GlobalizationManager, we need to change code to pass Nothing,
                'at present calling function will always pass Separator, if non specified it will pass "/"
                '...Changed while working on GlassMan Prototype where Dates were being displayed without 
                'separator, in which we introduced NullSeparator, when set to True passes an empty string
                'as a separator. August 16, 2005
                If DateSeparator.Trim.Length = 0 AndAlso Not NoSeparator Then _
                    DateSeparator = GlobalizationManager.DateSeparator

                Dim chrPreviousChar As Char
                Dim chrCurrentChar As Char

                For i As Integer = 0 To DateFormat.Length - 1
                    chrCurrentChar = DateFormat.ToUpper.Chars(i)
                    Select Case chrCurrentChar
                        Case "D"c, "M"c, "Y"c
                            If i > 0 AndAlso chrPreviousChar <> chrCurrentChar Then
                                strDateFormatWithSeparator += DateSeparator
                            End If
                            If chrCurrentChar = "D"c OrElse chrCurrentChar = "Y"c Then
                                strDateFormatWithSeparator += DateFormat.Substring(i, 1).ToLower
                            Else
                                strDateFormatWithSeparator += DateFormat.Substring(i, 1)
                            End If
                            chrPreviousChar = chrCurrentChar
                        Case Else
                            strDateFormatWithSeparator = DateFormat
                            Exit For
                    End Select
                Next

                ' If the value is not a zero date value, convert the date.
                If Value <> 0 And Value <> cNumericZeroDate Then
                    strValue = Value.ToString.PadLeft(8, "0"c)
                    srtYear = CShort(strValue.Substring(0, 4))
                    srtMonth = CShort(strValue.Substring(4, 2))
                    srtDay = CShort(strValue.Substring(6, 2))

                    ' Throw an error if this is not a valid date
                    Try
                        ' By assigning a new date to "dteDate" we are just checking 
                        ' whether this is a valid date or not.
                        ' This is done to avoid any formatting issue 
                        ' while converting string to date.
                        dteDate = New DateTime(srtYear, srtMonth, srtDay)
                        Return Format(dteDate, strDateFormatWithSeparator)
                    Catch ex As Exception
                        ' TODO: Error Code for Invalid Date or DateFormat
                        'ThrowCustomApplicationException("MSG????")
                        strDateFormatWithSeparator = Replace(strDateFormatWithSeparator.ToUpper, "YYYY", srtYear)
                        strDateFormatWithSeparator =
                            Replace(strDateFormatWithSeparator.ToUpper, "MM", srtMonth.ToString.PadLeft(2, "0"))
                        strDateFormatWithSeparator =
                            Replace(strDateFormatWithSeparator.ToUpper, "DD", srtDay.ToString.PadLeft(2, "0"))
                        Return strDateFormatWithSeparator
                    End Try
                Else
                    ' Format the 0 date.
                    strValue = ""

                    Return strValue
                End If

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try
            ' TODO: Add date checking code.
            ' TODO: Add code to convert date to a number.

            Return Nothing

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Translates a value representing a datetime into a Decimal.
        ''' </summary>
        ''' <param name="Value">A valid date.</param>
        ''' <param name="ReturnDefaultDate">A boolean indicating whether to return a defaulted 0 date.</param>
        ''' <returns>A Decimal representing the value of the passed in datetime.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/5/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function GetDecimalFromDateTime(ByVal Value As Date, Optional ByVal ReturnDefaultDate As Boolean = True) _
            As Decimal

            If (Not Value.Equals(Date.MinValue)) AndAlso IsDate(Value) Then
                Dim _
                    dblReturnValue As Decimal =
                        CDbl(
                        Value.Year.ToString + Format(Value.Month, "00") + Format(Value.Day, "00") +
                        Format(Value.Hour, "00") + Format(Value.Minute, "00") + Format(Value.Second, "00") +
                        Format(Value.Millisecond, "000").ToString.Substring(0, 2))

                If dblReturnValue = cZeroDecimalDate Then dblReturnValue = 0

                Return dblReturnValue
            Else
                If ReturnDefaultDate Then
                    'In derived page 0 is compared against the return value of GetNumericDateValue function
                    'and as GetDecimalFromDate is also being called from GetDecimalFromDate, this function Returns 0 instead of 18991231 
                    Return 0
                Else
                    Return -1
                End If
            End If

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Translates a value representing a time into a Decimal.
        ''' </summary>
        ''' <param name="Value">A valid TIME.</param>
        ''' <param name="ReturnDefaultDate">A boolean indicating whether to return a defaulted 0 date.</param>
        ''' <returns>A Decimal representing the value of the passed in time.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/5/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function GetDecimalFromTime(ByVal Value As Date, Optional ByVal ReturnDefaultDate As Boolean = True) _
            As Decimal

            If (Not Value.Equals(Date.MinValue)) AndAlso IsDate(Value) Then
                Dim _
                    dblReturnValue As Decimal =
                        CDbl(
                        Format(Value.Hour, "00") + Format(Value.Minute, "00") + Format(Value.Second, "00") +
                        Format(Value.Millisecond, "000").ToString.Substring(0, 2))

                If dblReturnValue = cZeroDecimalDate Then dblReturnValue = 0

                Return dblReturnValue
            Else
                If ReturnDefaultDate Then
                    'In derived page 0 is compared against the return value of GetNumericDateValue function
                    'and as GetDecimalFromDate is also being called from GetDecimalFromDate, this function Returns 0 instead of 18991231 
                    Return 0
                Else
                    Return -1
                End If
            End If

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Validates a datetime represented as a Decimal.
        ''' </summary>
        ''' <param name="Value">A valid date.</param>
        ''' <param name="ReturnDefaultDate">A boolean indicating whether to return a defaulted 0 date.</param>
        ''' <returns>A Decimal representing a date.</returns>
        ''' <remarks>If the passed in value is valid then the value is simply returned as is. However, if the value is
        ''' invalid then if requested, the default zero date is returned. If the value is invalid and no default date is 
        ''' requested then a value of -1 is returned.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/5/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function GetDecimalFromDateTime(ByVal Value As Decimal,
                                                Optional ByVal ReturnDefaultDate As Boolean = True) As Decimal

            If Value <= 0 Then
                If ReturnDefaultDate Then
                    Return cZeroDecimalDate
                Else
                    Return -1
                End If
            Else
                Return Value
            End If

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Translates a value representing a date into a Decimal.
        ''' </summary>
        ''' <param name="Value">A valid date.</param>
        ''' <param name="ReturnDefaultDate">A boolean indicating whether to return a defaulted 0 date.</param>
        ''' <returns>A Decimal representing the value of the passed in date.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/5/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function GetDecimalFromDate(ByVal Value As Date, Optional ByVal ReturnDefaultDate As Boolean = True) _
            As Decimal

            If (Not Value.Equals(Date.MinValue)) AndAlso IsDate(Value) Then
                Dim _
                    dblReturnValue As Decimal =
                        CDbl(Value.Year.ToString + Format(Value.Month, "00") + Format(Value.Day, "00"))

                If dblReturnValue = cZeroDecimalDate Then dblReturnValue = 0

                Return dblReturnValue
            Else
                If ReturnDefaultDate Then
                    'In derived page 0 is compared against the return value of GetNumericDateValue function
                    'and as GetDecimalFromDate is also being called from GetDecimalFromDate, this function Returns 0 instead of 18991231 
                    Return 0
                Else
                    Return -1
                End If
            End If

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Validates a date represented as a Decimal.
        ''' </summary>
        ''' <param name="Value">A valid date.</param>
        ''' <param name="ReturnDefaultDate">A boolean indicating whether to return a defaulted 0 date.</param>
        ''' <returns>A Decimal representing a date.</returns>
        ''' <remarks>If the passed in value is valid then the value is simply returned as is. However, if the value is
        ''' invalid then if requested, the default zero date is returned. If the value is invalid and no default date is 
        ''' requested then a value of -1 is returned.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/5/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function GetDecimalFromDate(ByVal Value As Decimal, Optional ByVal ReturnDefaultDate As Boolean = True) _
            As Decimal

            If Value <= 0 Then
                If ReturnDefaultDate Then
                    Return cZeroDecimalDate
                Else
                    Return -1
                End If
            Else
                Return Value
            End If

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' Converts a date to a Decimal.
        ''' </summary>
        ''' <param name="Value">A string containing a date value.</param>
        ''' <param name="ReturnDefaultDate">A boolean indicating whether a default date is required if passed in value is invalid.</param>
        ''' <param name="DateSeparator">A string containing the character used to separate the different parts of the date.</param>
        ''' <returns>A Decimal representing a date passed in as a string.</returns>
        ''' <remarks>If the passed in value is valid then the value is translated into a Decimal value. However, if the value is
        ''' invalid then if requested, the default zero date is returned. If the value is invalid and no default date is 
        ''' requested then a value of -1 is returned.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/5/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetDecimalFromYYYYMMDDDate(ByVal Value As String,
                                                    Optional ByVal ReturnDefaultDate As Boolean = True,
                                                    Optional ByVal DateSeparator As String = "/") As Decimal
            Value = Value.Replace(DateSeparator, String.Empty)
            Value = Value.Trim

            If IsNumeric(Value) AndAlso CInt(Value) > 0 Then
                'We always expect passed Date Value to be of 8 characters, and in order of YYYYMMDD, for missing digits we are adding leading zeros to make passed date value to be of 8 characters
                'Wednesday, April 06, 2005 7:42:25 PM
                Value = Value.PadLeft(8, "0"c)
                Return _
                    CDbl(
                        Format(Value.Substring(0, 4), "0000") + Format(Value.Substring(4, 2), "00") +
                        Format(Value.Substring(6, 2), "00"))
            Else
                If ReturnDefaultDate Then
                    Return cZeroDecimalDate
                Else
                    Return -1
                End If
            End If
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' Converts a value, passed in as a string, to a date.
        ''' </summary>
        ''' <param name="Value">A string representing a date, without a separator.</param>
        ''' <returns>A date.</returns>
        ''' <remarks>If the string value can be expressed as a numerical expression and can be formatted
        ''' in the YYYYMMDD style then a new date object is created and returned. If one or both of these
        ''' conditions fail, then the default zero date is returned.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/5/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetDateFromYYYYMMDDDecimal(ByVal Value As String) As Date
            Value = Value.Trim
            If IsNumeric(Value) AndAlso CInt(Value) > 0 Then

                If Value.Length < 8 AndAlso m_intDefaultInputCentury > 0 Then
                    Value = CInt(Value).ToString.PadLeft(8, "0"c)

                    Return _
                        New Date(ReturnDateAddingDefaultCentury(CInt(Value.Substring(0, 4))),
                                  CInt(Value.Substring(4, 2)), CInt(Value.Substring(6, 2)))
                Else
                    'We always expect passed Date Value to be of 8 characters, and in order of YYYYMMDD, for missing digits we are adding leading zeros to make passed date value to be of 8 characters
                    'Wednesday, April 06, 2005 7:42:25 PM
                    Value = Value.PadLeft(8, "0"c)

                    Return _
                        New Date(CInt(Value.Substring(0, 4)), CInt(Value.Substring(4, 2)),
                                  CInt(Value.Substring(6, 2)))
                End If
            Else
                Return cZeroDate
            End If
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' Converts a value, passed in as a Decimal, to a date.
        ''' </summary>
        ''' <param name="Value">A Decimal representing a date.</param>
        ''' <returns>A date.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/5/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetDateFromYYYYMMDDDecimal(ByVal Value As Decimal) As Date

            Try
                If Value = 1 / 0 Then Value = 0
                If CLng(Value).ToString.Length > 8 Then
                    Return GetDateFromDateTimeDecimal(CLng(Value))
                Else
                    Return GetDateFromYYYYMMDDDecimal(CStr(Value))
                End If

            Catch ex As Exception
                Return GetDateFromYYYYMMDDDecimal(CStr(Value))

            End Try

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Converts a value, passed in as a long, to a date.
        ''' </summary>
        ''' <param name="Value">A long representing a date.</param>
        ''' <returns>A date.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/5/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function GetDateFromDateTimeDecimal(ByVal Value As Long) As Date

            Return GetDateFromDateTimeDecimal(CStr(Value))

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Converts a string, representing a date expressed as a Decimal, to a date.
        ''' </summary>
        ''' <param name="Value">A string representing a datetime value, without a separator.</param>
        ''' <returns>A date.</returns>
        ''' <remarks>If the string value can be expressed as a numerical expression and has a length
        ''' of 16, then a new date object is created and returned. If one or both of these
        ''' conditions fail, then the default zero date is returned.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/5/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function GetDateFromDateTimeDecimal(ByVal Value As String) As Date
            Value = Value.Trim

            If IsNumeric(Value) Then
                Select Case Value.Length
                    Case 16
                        Dim intHour As Integer = CInt(Value.Substring(8, 2))
                        If intHour = 24 Then intHour = 0
                        Return _
                            New DateTime(CInt(Value.Substring(0, 4)), CInt(Value.Substring(4, 2)),
                                          CInt(Value.Substring(6, 2)), intHour, CInt(Value.Substring(10, 2)),
                                          CInt(Value.Substring(12, 2)), CInt(Value.Substring(14, 2)) * 10)
                    Case Else
                        'We may need to change this to raise error if it is invalid date
                        Return cZeroDate
                End Select
            Else
                Return cZeroDate
            End If

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Will substitute a string containing a space for an empty string.
        ''' </summary>
        ''' <param name="Value">A character string.</param>
        ''' <returns>A space for empty strings, otherwise the value passed in.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        '''     NULL("This is a test") returns "This is a test"<br/>
        '''     NULL("") returns " "
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/5/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function NULL(ByVal Value As String) As String

            If (Value Is Nothing) OrElse (Value.TrimEnd.Length = 0) Then
                Return " "
            Else
                Return Value.TrimEnd
            End If

        End Function


        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function NULL(ByVal Value As Decimal) As Decimal

            If (IsNothing(Value)) Then
                Return 0
            Else
                Return Value
            End If

        End Function

        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function NULL(ByVal Value As Double) As Decimal

            If (IsNothing(Value)) Then
                Return 0
            Else
                Return Value
            End If

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Converts a string into a Decimal.
        ''' </summary>
        ''' <param name="Value">A string.</param>
        ''' <returns>A Decimal.</returns>
        ''' <remarks>Will only convert numeric values and remove character values.
        ''' </remarks>
        ''' <example>
        '''     VAL("123") returns 123<br/>
        '''     VAL("$12") returns 12
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/6/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function VAL(ByVal Value As String) As Object

            ' Remove any trailing spaces.
            Value = Value.TrimEnd

            Try

                ' 
                If IsNumeric(Value) Then
                    Return CDec(Value)

                    ' TODO: Revisit DECIMAL code.
                    'If InStr(1, strNumber, ".") > 0 And blnDecimal Then
                    '    VAL = VAL * (10 ^ (Len(Trim(strNumber)) - InStr(1, strNumber, ".")))
                    'End If
                Else
                    Dim intPosition As Integer
                    Dim strNewNumber As String = String.Empty

                    If Value.StartsWith("0") Then
                        strNewNumber = Value
                        Do While strNewNumber.StartsWith("0")
                            strNewNumber = strNewNumber.Substring(1)
                        Loop

                        If strNewNumber.Length = 0 Then strNewNumber = "0"

                        If IsNumeric(strNewNumber) Then
                            Return CDec(strNewNumber)
                        End If

                        strNewNumber = ""
                    End If

                    ' Loop through the string and remove any non-numeric characters.
                    For intPosition = 1 To Value.Length
                        ' Remove non-numeric characters.
                        If Asc(Value.Substring(intPosition, 1)) > 47 And Asc(Value.Substring(intPosition, 1)) < 58 _
                            Then
                            strNewNumber &= Value.Substring(intPosition, 1)
                        End If
                    Next


                    ' Return the new number.
                    If IsNumeric(strNewNumber) Then
                        Return CDec(strNewNumber)
                    Else
                        Return 0
                    End If
                End If

            Catch ex As Exception
                If Not IsNumeric(Value) Then
                    Return Value
                Else
                    Return 0
                End If
            End Try


        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Converts a string into a Decimal.
        ''' </summary>
        ''' <param name="Value">A string.</param>
        ''' <returns>A Decimal.</returns>
        ''' <remarks>Will only convert numeric values and remove character values.
        ''' </remarks>
        ''' <example>
        '''     VAL("123") returns 123<br/>
        '''     VAL("$12") returns 12
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/6/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function VAL2(ByVal Value As String) As Object

            ' Remove any trailing spaces.
            Value = Value.TrimEnd

            Try

                ' 
                If IsNumeric(Value) Then
                    Return CDec(Value)

                    ' TODO: Revisit DECIMAL code.
                    'If InStr(1, strNumber, ".") > 0 And blnDecimal Then
                    '    VAL = VAL * (10 ^ (Len(Trim(strNumber)) - InStr(1, strNumber, ".")))
                    'End If
                Else
                    Dim intPosition As Integer
                    Dim strNewNumber As String = String.Empty

                    If Value.StartsWith("0") Then
                        strNewNumber = Value
                        Do While strNewNumber.StartsWith("0")
                            strNewNumber = strNewNumber.Substring(1)
                        Loop

                        If strNewNumber.Length = 0 Then strNewNumber = "0"

                        If IsNumeric(strNewNumber) Then
                            Return CDec(strNewNumber)
                        End If

                        strNewNumber = ""
                    End If

                    ' Loop through the string and remove any non-numeric characters.
                    For intPosition = 0 To Value.Length - 1
                        ' Remove non-numeric characters.
                        If Asc(Value.Substring(intPosition, 1)) > 47 And Asc(Value.Substring(intPosition, 1)) < 58 _
                            Then
                            strNewNumber &= Value.Substring(intPosition, 1)
                        End If
                    Next


                    ' Return the new number.
                    If IsNumeric(strNewNumber) Then
                        Return CDec(strNewNumber)
                    Else
                        Return 0
                    End If
                End If

            Catch ex As Exception
                If Not IsNumeric(Value) Then
                    Return Value
                Else
                    Return 0
                End If
            End Try


        End Function

        Public Function PortID() As String

            Return "            "

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Compacts a string containing excess space characters.
        ''' </summary>
        ''' <param name="Expression">A string.</param>
        ''' <returns>A string.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        '''     Pack("  J Smith") returns "J Smith"
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/6/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function Pack(ByVal Expression As String) As String

            Dim strTemp As String

            Try
                strTemp = Expression.Trim
                ' Remove all leading and trailing Semi-Colons, Commas and Spaces.
                strTemp = strTemp.TrimStart(CChar(";"), CChar(","), CChar(" "))
                strTemp = strTemp.TrimEnd(CChar(";"), CChar(","), CChar(" "))

                'Remove all but one intervening space between words
                strTemp = Regex.Replace(strTemp, " {2,}", " ")

                'Remove the leading spaces before a comma, period, colon or semi-colon.
                strTemp = Regex.Replace(strTemp, " +(?<CommaSemicolonDot>[,\.:;])", "${CommaSemicolonDot}")

                Return strTemp.Trim

            Catch ex As Exception
                'MsgBox("Error: " & ex.Message & vbCrLf & ex.StackTrace)

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex
            End Try

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Converts a Decimal-precision floating-point number to a rounded number using the desired option. 
        ''' </summary>
        ''' <param name="Number">A Decimal representing the number to round.</param>
        ''' <param name="Precision">The number of significant digits (precision) in the return value.</param>
        ''' <param name="RoundOption">A RoundOptionTypes.</param>
        ''' <returns>A Decimal.</returns>
        ''' <remarks>The following options are available:<br/>
        '''     <OL>
        '''         <li>Near (default if none passed in)</li>
        '''         <li>Up</li>
        '''         <li>Down</li>
        '''         <li>Zero</li>
        '''     </OL>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/6/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function Round(ByVal Number As Decimal, Optional ByVal Precision As Integer = 0,
                               Optional ByVal RoundOption As RoundOptionTypes = RoundOptionTypes.Near) As Decimal
            Dim dblReturnValue As Decimal = 0

            If Number = 0 Then Return dblReturnValue

            'TODO: we may need to change Decimal Character according to Globalization Info????
            Dim intPrecisionSign As Integer = Math.Sign(Precision)

            ' For Negative Precision
            If intPrecisionSign = -1 Then
                Number = Number * (Math.Pow(10, Precision))
            End If

            Select Case RoundOption
                Case RoundOptionTypes.Near 'Default Round Option
                    Select Case intPrecisionSign
                        Case -1
                            Number = RoundFixForPH(Number, 0)
                            dblReturnValue = Number * Math.Pow(10, Math.Abs(Precision))

                        Case 0 'Default Precision
                            dblReturnValue = RoundFixForPH(Number, Precision)

                        Case 1
                            dblReturnValue = RoundFixForPH(Number, Precision)
                    End Select

                Case RoundOptionTypes.Up
                    Select Case intPrecisionSign
                        Case -1
                            dblReturnValue = (Int(Number) + CInt(IIf(Number > Int(Number), 1, 0))) *
                                             Math.Pow(10, Math.Abs(Precision))

                        Case 0
                            dblReturnValue = (Int(Number) + CInt(IIf(Number > Int(Number), 1, 0)))

                        Case 1
                            Dim intRelation As Integer

                            dblReturnValue = Math.Round(Number, Precision)
                            intRelation = Math.Sign(dblReturnValue - Number)

                            Select Case intRelation
                                Case -1 'If Rounded Number is lower then the passed Number (Rounded downward)
                                    dblReturnValue += Math.Pow(10, -Precision)

                                Case 0 'If Rounded Number is equal to the passed Number (not Rounded)
                                    ' Do nothing as,
                                    ' dblReturnValue calculated above is our return value

                                Case 1 'If Rounded Number is higher then the passed Number (Rounded upward)
                                    ' Do nothing as,
                                    ' dblReturnValue calculated above is our return value
                            End Select
                    End Select

                Case RoundOptionTypes.Down
                    Select Case intPrecisionSign
                        Case -1
                            dblReturnValue = Int(Number) * Math.Pow(10, Math.Abs(Precision))

                        Case 0
                            dblReturnValue = Int(Number)

                        Case 1
                            Dim intRelation As Integer

                            dblReturnValue = Math.Round(Number, Precision)
                            intRelation = Math.Sign(dblReturnValue - Number)

                            Select Case intRelation
                                Case -1 'If Rounded Number is lower then the passed Number (Rounded downward)
                                    ' Do nothing as,
                                    ' dblReturnValue calculated above is our return value

                                Case 0 'If Rounded Number is equal to the passed Number (not Rounded)
                                    ' Do nothing as,
                                    ' dblReturnValue calculated above is our return value

                                Case 1 'If Rounded Number is higher then the passed Number (Rounded upward)
                                    dblReturnValue -= Math.Pow(10, -Precision)
                            End Select
                    End Select

                Case RoundOptionTypes.Zero
                    Select Case intPrecisionSign
                        Case -1
                            If Number >= 0 Then
                                dblReturnValue = Int(Number) * Math.Pow(10, Math.Abs(Precision))
                            Else
                                dblReturnValue = (Int(Number) + 1) * Math.Pow(10, Math.Abs(Precision))
                            End If

                        Case 0
                            'If Number >= 0 Then
                            dblReturnValue = Int(Number)
                            'Else
                            'dblReturnValue = (Int(Number) + 1)
                            'End If

                        Case 1
                            Dim intRelation As Integer

                            dblReturnValue = Math.Round(Number, Precision)
                            intRelation = Math.Sign(dblReturnValue - Number)

                            Select Case intRelation
                                Case -1 'If Rounded Number is lower then the passed Number (Rounded downward)
                                    ' Do nothing as,
                                    ' dblReturnValue calculated above is our return value

                                Case 0 'If Rounded Number is equal to the passed Number (not Rounded)
                                    ' Do nothing as,
                                    ' dblReturnValue calculated above is our return value

                                Case 1 'If Rounded Number is higher then the passed Number (Rounded upward)
                                    If dblReturnValue > 0 Then
                                        dblReturnValue -= Math.Pow(10, -Precision)
                                    End If
                            End Select
                    End Select
            End Select

            Return dblReturnValue

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Converts a character string to a number.
        ''' </summary>
        ''' <param name="StringExpression">A string.</param>
        ''' <param name="IsInteger">A boolean indicating if target variable is an Integer.</param>
        ''' <returns>A Decimal.</returns>
        ''' <remarks>
        '''     <note>
        '''         1.  NConvert Function in PH return different results depending on Target 
        '''             Variable's DataType.
        '''         <br/><br/>
        '''         2.  By default this function is changed to round to nearest Integer Value<br/>
        '''             i.e. it will work well with a Variables expecting NUMERIC Data Type.
        '''         <br/><br/>
        '''         3.  Pass IsInteger to deal with INTEGER Variables or an Expression expecting 
        '''             an Integer Value.
        '''     </note>
        ''' </remarks>
        ''' <example>
        '''     If in PH if Value is declared as an Integer then
        '''         Value = NConvert("-12236")  ;returns -12236<br/>
        '''         Value = NConvert("12.5")    ;returns 12<br/>
        '''         Value = NConvert("-12.5")   ;returns -12<br/>
        '''     <br/><br/>
        '''     However, if in PH if Value is declared as an Numeric then<br/>
        '''         Value = NConvert("-12236")  ;returns -12236<br/>
        '''         Value = NConvert("12.5")    ;returns 13<br/>
        '''         Value = NConvert("-12.5")   ;returns -13
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/6/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function NConvert(ByVal StringExpression As String, Optional ByVal IsInteger As Boolean = False) _
            As Decimal
            'TODO : During FE, Pass "IsInteger" in a call to NConvert if Target variable is INTEGER Variable

            Dim dblDecimal As Decimal

            Try
                ' PH returns 0 if empty string is passed
                If StringExpression.Trim = "" Then Return 0
                If StringExpression.Trim = "." Then Return 0


                If StringExpression.Trim.IndexOf("-") > 0 Then

                    If VAL(StringExpression.Trim.Split("-")(0)) = 0 Then
                        StringExpression = "-" & StringExpression.Trim.Split("-")(1)
                    End If

                End If

                If IsNumeric(StringExpression) Then
                    dblDecimal = CDbl(StringExpression)

                    If IsInteger = False Then _
                        'If Targeted Variable/Expression is or expects Numeric (Not an Integer) Value
                        'Add .01 to Round .5 to 1 as PH App rounds .5 to 1
                        Select Case (dblDecimal - Fix(dblDecimal))
                            Case 0.5
                                dblDecimal = dblDecimal + 0.01

                            Case -0.5
                                dblDecimal = dblDecimal - 0.01
                        End Select

                    Else 'If Targeted Variable/Expression is or expects an Integer Value
                        'To round downward used Fix which always returns downward Rounded Integer even with 12.5
                        dblDecimal = Fix(dblDecimal)
                    End If

                    Return Math.Round(dblDecimal, 0)
#If TARGET_DB = "INFORMIX" Then
                ElseIf StringExpression.ToUpper.IndexOf(".DBO.") = -1 Then
                    ThrowCustomApplicationException("Data expression error.")
#Else
                    Return 0
#End If
                End If

            Catch ex As CustomApplicationException

                Throw ex

            Catch ex As Exception
                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Function


        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Converts a character string to a number.
        ''' </summary>
        ''' <param name="StringExpression">A string.</param>
        ''' <param name="IsInteger">A boolean indicating if target variable is an Integer.</param>
        ''' <returns>A Decimal.</returns>
        ''' <remarks>
        '''     <note>
        '''         1.  NConvert Function in PH return different results depending on Target 
        '''             Variable's DataType.
        '''         <br/><br/>
        '''         2.  By default this function is changed to round to nearest Integer Value<br/>
        '''             i.e. it will work well with a Variables expecting NUMERIC Data Type.
        '''         <br/><br/>
        '''         3.  Pass IsInteger to deal with INTEGER Variables or an Expression expecting 
        '''             an Integer Value.
        '''     </note>
        ''' </remarks>
        ''' <example>
        '''     If in PH if Value is declared as an Integer then
        '''         Value = NConvert("-12236")  ;returns -12236<br/>
        '''         Value = NConvert("12.5")    ;returns 12<br/>
        '''         Value = NConvert("-12.5")   ;returns -12<br/>
        '''     <br/><br/>
        '''     However, if in PH if Value is declared as an Numeric then<br/>
        '''         Value = NConvert("-12236")  ;returns -12236<br/>
        '''         Value = NConvert("12.5")    ;returns 13<br/>
        '''         Value = NConvert("-12.5")   ;returns -13
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/6/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function NConvert(ByVal StringExpression As String, ByVal MultipleBy As Decimal,
                                  Optional ByVal IsInteger As Boolean = False) As Decimal
            'TODO : During FE, Pass "IsInteger" in a call to NConvert if Target variable is INTEGER Variable

            Dim dblDecimal As Decimal

            Try
                ' PH returns 0 if empty string is passed
                If StringExpression.Trim = "" Then Return 0
                If StringExpression.Trim = "." Then Return 0


                If StringExpression.Trim.IndexOf("-") > 0 Then

                    If VAL(StringExpression.Trim.Split("-")(0)) = 0 Then
                        StringExpression = "-" & StringExpression.Trim.Split("-")(1)
                    End If

                End If

                If IsNumeric(StringExpression) Then
                    dblDecimal = CDbl(StringExpression)

                    dblDecimal = dblDecimal * MultipleBy

                    If IsInteger = False Then _
                        'If Targeted Variable/Expression is or expects Numeric (Not an Integer) Value
                        'Add .01 to Round .5 to 1 as PH App rounds .5 to 1
                        Select Case (dblDecimal - Fix(dblDecimal))
                            Case 0.5
                                dblDecimal = dblDecimal + 0.01

                            Case -0.5
                                dblDecimal = dblDecimal - 0.01
                        End Select

                    Else 'If Targeted Variable/Expression is or expects an Integer Value
                        'To round downward used Fix which always returns downward Rounded Integer even with 12.5
                        dblDecimal = Fix(dblDecimal)
                    End If

                    Return Math.Round(dblDecimal, 0)
#If TARGET_DB = "INFORMIX" Then
                ElseIf StringExpression.ToUpper.IndexOf(".DBO.") = -1 Then
                    ThrowCustomApplicationException("Data expression error.")
#Else
                    Return 0
#End If
                End If

            Catch ex As CustomApplicationException

                Throw ex

            Catch ex As Exception
                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Finds the starting position of one substring within another.
        ''' </summary>
        ''' <param name="Source">A string from which to search in.</param>
        ''' <param name="SearchString">A string to search with.</param>
        ''' <returns>A Decimal representing the position within the Source string of </returns>
        ''' <remarks>The returned value is the starting position of the SearchString within 
        ''' the Source string, if that string is found. If the SearchString is longer than the 
        ''' Source or is not found in the Source, then the return value is 0.
        ''' </remarks>
        ''' <example> 
        '''     Index("Test", "s") returns 3
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/6/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function Index(ByVal Source As String, ByVal SearchString As String) As Decimal

            If SearchString.Length > Source.Length Then
                Return CDbl(0)
            Else
                ' Increment the IndexOf value by 1 since IndexOf is 0-based.
                Return CDbl(Source.IndexOf(SearchString) + 1)
            End If

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Adds an additional space between each character of a string expression.
        ''' </summary>
        ''' <param name="Expression">A string expression.</param>
        ''' <returns>A string.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        '''     Spread("TEST") returns "T E S T"<br/>
        '''     Spread("FUTURE'S INVENTORY") returns "F U T U R E ' S   I N V E N T O R Y"
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/6/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function Spread(ByVal Expression As String) As String

            Try

                Return Regex.Replace(Expression, "(.)", " $1").Trim

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Replaces substitution characters in a string.
        ''' </summary>
        ''' <param name="Expression">A string expression containing substitution characters (default substitution character: caret ^).</param>
        ''' <param name="OtherExpressions">An array of string expressions to replace a substitution character in Expression.</param>
        ''' <returns>A string.</returns>
        ''' <remarks>The first substitution character in Expression is replaced by the first value in array.
        ''' Similarly, the second substitution character in Expression is replaced by the second value in the array 
        ''' and so on. A substitution character is not replaced if there is no corresponding string expression.
        ''' </remarks>
        ''' <example>
        '''     Substitute("Here is a name: ^ ^.", "STEWART", "MELVIN")<br/>
        '''     returns "Here is a name: STEWART MELVIN"
        ''' </example> 
        ''' <history>
        ''' 	[Campbell]	4/6/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function Substitute(ByVal Expression As String, ByVal ParamArray OtherExpressions() As String) As String

            Dim intCount As Integer
            Dim strReturnValue As String

            Try
                strReturnValue = Expression
                If Expression.IndexOf("^") > -1 Then
                    For intCount = 0 To OtherExpressions.GetUpperBound(0)
                        ' Replace one instance of the ^ with the replacement value.
                        strReturnValue = Replace(strReturnValue, "^", OtherExpressions(intCount), 1, 1)
                    Next
                Else
                    For intCount = 0 To OtherExpressions.GetUpperBound(0)
                        ' Replace one instance of the ^ with the replacement value.
                        strReturnValue += ":" + OtherExpressions(intCount)
                    Next
                End If

                Return strReturnValue

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Replaces leading spaces with zeros.
        ''' </summary>
        ''' <param name="strExpression">A string to be filled with zeros.</param>
        ''' <returns>A string.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        '''     ZeroFill("  562") returns "00562"
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/6/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function ZeroFill(ByVal strExpression As String) As String

            Dim intlength As Integer = 0

            Try

                intlength = strExpression.Length

                Return strExpression.TrimStart.PadLeft(intlength, CChar("0"))

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try
        End Function

        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function UCase(strExpression As String) As String
            Return strExpression.ToUpper
        End Function

        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function LCase(strExpression As String) As String
            Return strExpression.ToLower
        End Function

        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function RTrim(strExpression As String) As String
            Return strExpression.TrimEnd
        End Function
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Right-justifies characters in a string, optionally Pad Character and Length can be passed in.
        ''' </summary>
        ''' <param name="strExpression">A string to be right-justified.</param>
        ''' <param name="PaddingCharacter">A string containing the character to pad the expression with.</param>
        ''' <param name="Length">An integer indicating the length of the expression, including the padding characters.</param>
        ''' <returns>A string that is right-justified.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        '''     <list type="number">
        '''         <item>RightJustify("Test  ") returns "  Test"</item>
        '''         <item>RightJustify("Test  ", "*") returns "**Test"</item>
        '''         <item>RightJustify("Test  ", "*", 10) returns "******Test"</item>
        '''     </list>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/6/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function RightJustify(ByVal strExpression As String, Optional ByVal PaddingCharacter As String = " ",
                                      Optional ByVal Length As Integer = 0) As String

            Try

                If PaddingCharacter.Trim = "" Then PaddingCharacter = " "

                If Length < strExpression.Length Then Length = strExpression.Length

                Return strExpression.Trim.PadLeft(Length, CChar(PaddingCharacter))

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Upshifts, downshifts the current value if required based on the FIELD property and dictionary settings.
        ''' </summary>
        ''' <param name="Value">A string value to be downshifted or upshifted.</param>
        ''' <param name="ShiftType">A ShiftTypes, either UpShift or DownShift.</param>
        ''' <returns>A string.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        '''     SetShiftUpDown("TEXT", ShiftTypes.DownShift) returns "text"<br/>
        '''     SetShiftUpDown("text", ShiftTypes.UpShift) returns "TEXT"
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/6/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function SetShiftUpDown(ByRef Value As String, ByVal ShiftType As ShiftTypes) As String

            ' Depending on the ShiftType, upshift or
            ' downshift the value.  Since the NotSet
            ' and NoShift options do nothing, don't 
            ' add code to the Select Case statement.
            Select Case ShiftType
                Case ShiftTypes.UpShift
                    Value = Value.ToUpper

                Case ShiftTypes.DownShift
                    Value = Value.ToLower
            End Select

            Return Value

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Throws an exception (used for ERROR and SEVERE) to send a message to the screen.
        ''' </summary>
        ''' <param name="ExceptionCode">An integer corresponding to the Exception to be thrown.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        '''     ThrowCustomApplicationException(31004)
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/6/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub ThrowCustomApplicationException(ByRef ExceptionCode As Integer)

            Dim ex As New CustomApplicationException(ExceptionCode)
            Throw ex

        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Throws an exception (used for ERROR and SEVERE) to send a message to the screen.
        ''' </summary>
        ''' <param name="ExceptionCode">An string indicating the Exception to be thrown.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/6/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub ThrowCustomApplicationException(ByRef ExceptionCode As String)

            Dim ex As New CustomApplicationException(ExceptionCode)
            Throw ex

        End Sub

        ''' --- RoundFixForPH ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of RoundFixForPH.
        ''' </summary>
        ''' <param name="Number"></param>
        ''' <param name="Precision"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function RoundFixForPH(ByVal Number As Decimal, ByVal Precision As Integer) As Decimal
            ' This function is a fix to VB's Round behaviour as
            ' it is different in the way as PowerHouse rounds unward 
            ' from the value from 0.5 where as .Net's Math.Round 
            ' funcion rounds upward from 0.5+
            Number = CType(Number * Math.Pow(10, Precision), Decimal)
            If Number - Int(Number) = 0.5 Then
                ' As PowerHouse rounds unward from the value from 0.5 
                ' where as .Net's Math.Round funcion rounds upward from 0.5+
                If Number >= 0 Then
                    Number = Int(Number) + 1
                    ' .Net returns int(-0.5) as -1
                Else
                    Number = Int(Number)
                    ' .Net returns int(0.5) as 0
                End If
            Else
                Number = Math.Round(Number)
            End If
            Number = Math.Round(Number * Math.Pow(10, -Precision), Precision)
            ' Added Math.Round since "113.0 * (10^-2)" returned "1.1300000000000001"
            Return Number
        End Function

        ''' --- GetTimeValue -------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetTimeValue.
        ''' </summary>
        ''' <param name="Value"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function GetTimeValue(ByVal Value As DateTime) As Decimal
            ' Return the time as a number.
            Dim x As Decimal = Value.Millisecond()

            ' If the Millisecond value is 0, add 00.
            If Value.Millisecond = 0 Then
                Return _
                    CDbl(Format(Value.Hour, "00") & Format(Value.Minute, "00") & Format(Value.Second, "00") & "00")
            Else
                Return _
                    CDbl(
                        Format(Value.Hour, "00") & Format(Value.Minute, "00") & Format(Value.Second, "00") &
                        Value.Millisecond.ToString.Substring(0, 2))
            End If

        End Function

        ''' --- HTMLSpace -------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetTimeValue.
        ''' </summary>
        ''' <param name="Value"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function HTMLSpace(ByVal Value As Integer) As String

            Dim sbHTMLSpace As New StringBuilder("")
            For i As Integer = 0 To Value
                sbHTMLSpace.Append("")
            Next

            Return Nothing

        End Function

        ''' --- Occurs -------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Occurs.
        ''' </summary>
        ''' <param name="Value"></param>
        ''' <param name="FindString"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function Occurs(ByVal Value As String, ByVal FindString As String) As Integer

            Dim intOccurs As Integer = 0

            intOccurs = CInt(Value.Length - Value.Replace(FindString, "").Length() / Len(FindString))

            Return intOccurs

        End Function

#End Region
    End Module

    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: OldCoreDate
    ''' Note    : Now we should use OldCoreDate defined in Core.Windows namespace
    '''
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' <summary>
    ''' 	Summary of OldCoreDate.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(EditorBrowsableState.Always)>
    Public Class OldCoreDate
        Implements ISerializable

#Region "Private Variables"

        ' Private variables.
        <EditorBrowsable(EditorBrowsableState.Advanced)> Private m_dteDate As Date

#End Region

#Region "Constructor and Destructor"

        ''' --- New ------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Summary of New.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/17/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub New()

        End Sub

        ''' --- New ------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Summary of New.
        ''' </summary>
        ''' <param name="info"></param>
        ''' <param name="context"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/17/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Private Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            m_dteDate = info.GetDateTime("m_dteDate")
        End Sub

        ''' --- New ------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Summary of New.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/17/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub New(ByVal [Date] As Date)

            m_dteDate = [Date]

        End Sub

        ''' --- New ------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Summary of New.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/17/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub New(ByVal [Date] As Decimal)

            Me.Value = [Date]

        End Sub

#End Region

#Region "Properties"

        ''' --- DateValue ----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of DateValue.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Property DateValue() As Date
            Get
                Return (m_dteDate)
            End Get
            Set(ByVal Value As Date)

                If Value = Date.MinValue Then
                    m_dteDate = cZeroDate
                Else
                    m_dteDate = Value
                End If

            End Set
        End Property

        ''' --- TimeValue ----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of TimeValue.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public ReadOnly Property TimeValue() As Decimal
            Get
                ' Return the date as a number.
                Dim x As Decimal = m_dteDate.Millisecond()

                ' If the Millisecond value is 0, add 00.
                If m_dteDate.Millisecond = 0 Then
                    Return _
                        CDbl(
                            Format(m_dteDate.Hour, "00") & Format(m_dteDate.Minute, "00") &
                            Format(m_dteDate.Second, "00") & "00")
                Else
                    Return _
                        CDbl(
                            Format(m_dteDate.Hour, "00") & Format(m_dteDate.Minute, "00") &
                            Format(m_dteDate.Second, "00") & m_dteDate.Millisecond.ToString.Substring(0, 2))
                End If
            End Get
        End Property

        ''' --- Value --------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Value.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Property Value() As Decimal
            Get
                Dim dblDate As Decimal

                ' Return the date as a number.
                dblDate = CDbl(m_dteDate.Year.ToString & Format(m_dteDate.Month, "00") & Format(m_dteDate.Day, "00"))

                ' If the date is a zero date, return 0.
                If dblDate = cNumericZeroDate Then dblDate = 0D

                Return dblDate

            End Get
            Set(ByVal Value As Decimal)

                ' If the value is 0, set the date to 0001/01/01.
                If Value = 0 Then
                    m_dteDate = cZeroDate
                Else
                    Dim strValue As String

                    ' Store the value as a string.
                    strValue = Value.ToString.PadLeft(8).Replace(" ", "0")

                    ' If the century is 00 then add the proper century.
                    If strValue.Substring(0, 2) = "00" Then
                        strValue = m_intDefaultCentury.ToString.Substring(0, 2) + strValue.Substring(2)
                    End If

                    ' Use the 0-based Substring function to create the date using the DateSerial function.
                    m_dteDate =
                        DateSerial(CInt(strValue.Substring(0, 4)), CInt(strValue.Substring(4, 2)),
                                    CInt(strValue.Substring(6, 2)))
                End If

            End Set
        End Property

#End Region

        ''' --- GetObjectData ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetObjectData.
        ''' </summary>
        ''' <param name="info"></param>
        ''' <param name="context"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub GetObjectData(ByVal info As SerializationInfo, ByVal context As StreamingContext) _
            Implements ISerializable.GetObjectData
            HttpContext.Current.Trace.Write("FileObject:Serialization", "Initial Call")
            info.AddValue("m_dteDate", Me.m_dteDate)
            HttpContext.Current.Trace.Write("OldCoreDate:Serialization", "End")
        End Sub
    End Class
End Namespace
