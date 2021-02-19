'===============================================================================
' Microsoft Caching Application Block for .NET
' http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnpag/html/CachingBlock.asp
'
' ExtendedFormat.vb
' This class represents a extended format for the time to be checked for expirations.
'
'===============================================================================
' Copyright (C) 2003 Microsoft Corporation
' All rights reserved.
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
' OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
' LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
' FITNESS FOR A PARTICULAR PURPOSE.
'===============================================================================
Imports System.Globalization
Imports Core.ExceptionManagement

' Used for Handling Exceptions

Namespace Expirations

#Region "Extended Format class"

    ' <summary>
    '		This class represents a extended format for the time
    '		to be checked for expirations.
    ' </summary>

    Friend Class ExtendedFormat

#Region "Private Members"

        Private Shared ARGUMENT_DELIMITER As Char = Convert.ToChar ( _
                                                                    CacheResources.ResourceManager ( _
                                                                                                    "RES_ArgumentDelimiter"), _
                                                                    CultureInfo.CurrentCulture)

        Private Shared WILDCARD_ALL As Char = Convert.ToChar ( _
                                                              CacheResources.ResourceManager ("RES_WildcardAll"), _
                                                              CultureInfo.CurrentCulture)

        Private Const REFRESH_DELIMITER As Char = " "

        ' Variables
        Private minutes() As Integer
        Private hours() As Integer
        Private days() As Integer
        Private months() As Integer
        Private daysOfWeek() As Integer
        Private isAlwaysExpired As Boolean

#End Region

#Region "Properties"

        ' <summary>
        '		This method gets the status whether metadata has to expire 
        '		every minute.
        ' </summary>

        Public ReadOnly Property ExpireEveryMinute() As Boolean

            Get
                Return Equals (minutes (0), - 1)
            End Get
        End Property

        ' <summary>
        '		Gets the status whether metadata has to expire 
        '		every day.
        ' </summary>

        Public ReadOnly Property ExpireEveryDay() As Boolean

            Get
                Return Equals (days (0), - 1)
            End Get
        End Property

        ' <summary>
        '		Gets the status whether metadata has to expire 
        '		every hour.
        ' </summary>

        Public ReadOnly Property ExpireEveryHour() As Boolean

            Get
                Return Equals (hours (0), - 1)
            End Get
        End Property

        ' <summary>
        '		Gets the status whether metadata has to expire 
        '		every month.
        ' </summary>

        Public ReadOnly Property ExpireEveryMonth() As Boolean

            Get
                Return Equals (months (0), - 1)
            End Get
        End Property

        ' <summary>
        '		Gets the status whether metadata has to expire 
        '		every week.
        ' </summary>

        Public ReadOnly Property ExpireEveryDayOfWeek() As Boolean

            Get
                Return Equals (daysOfWeek (0), - 1)
            End Get
        End Property

        ' <summary>
        '		Gets the status whether the metadata is always expire.
        ' </summary>

        Public ReadOnly Property IsAlwaysExpire() As Boolean

            Get
                Return isAlwaysExpired
            End Get
        End Property

#End Region

#Region "Constructor"

        ' <summary>
        '		Constructor to convert the string format and spilt 
        '       using delimiters to retrieve the time format.
        ' </summary>
        ' <param name="timeFormat">
        '       The time format for the item to get expired
        ' </param>
        Public Sub New (ByVal timeFormat As String)

            Try
                If Equals (timeFormat, Nothing) Then
                    Throw New ArgumentNullException ("timeFormat", _
                                                     CacheResources.ResourceManager ( _
                                                                                     "RES_ExceptionNullTimeFormat"))
                End If

                If timeFormat.Length = 0 Then
                    Throw New ArgumentOutOfRangeException ("timeFormat", _
                                                           CacheResources.ResourceManager ( _
                                                                                           "RES_ExceptionRangeTimeFormat"))
                End If

                Dim parsedFormat As String() = timeFormat.Split ( _
                                                                 REFRESH_DELIMITER)

                If Not Equals (parsedFormat.Length, Convert.ToInt32 ( _
                                                                     CacheResources.ResourceManager ( _
                                                                                                     "RES_ParsedFormatLength"))) _
                    Then
                    Throw New Exception (CacheResources.ResourceManager ( _
                                                                         "RES_ExceptionInvalidExtendedFormatArguments"))
                End If

                minutes = ParseValueToInt (parsedFormat (Convert.ToInt32 ( _
                                                                          CacheResources.ResourceManager ( _
                                                                                                          "RES_MinutesIndex"))))
                Dim minute As Integer
                For Each minute In minutes
                    If minute > 59 Then
                        Throw New ArgumentOutOfRangeException ("minute", _
                                                               CacheResources.ResourceManager ( _
                                                                                               "RES_ExceptionRangeMinute"))
                    End If
                Next minute

                hours = ParseValueToInt (parsedFormat (Convert.ToInt32 ( _
                                                                        CacheResources.ResourceManager ("RES_HoursIndex"))))
                Dim hour As Integer
                For Each hour In hours
                    If hour > 23 Then
                        Throw New ArgumentOutOfRangeException ("hour", _
                                                               CacheResources.ResourceManager ( _
                                                                                               "RES_ExceptionRangeHour"))
                    End If
                Next hour

                days = ParseValueToInt (parsedFormat (Convert.ToInt32 ( _
                                                                       CacheResources.ResourceManager ("RES_DaysIndex"))))
                Dim day As Integer
                For Each day In days
                    If (day < 1 OrElse day > 31) AndAlso day <> - 1 Then
                        Throw New ArgumentOutOfRangeException ("day", _
                                                               CacheResources.ResourceManager ( _
                                                                                               "RES_ExceptionRangeDayOfMonth"))
                    End If
                Next day

                months = ParseValueToInt (parsedFormat (Convert.ToInt32 ( _
                                                                         CacheResources.ResourceManager ( _
                                                                                                         "RES_MonthsIndex"))))
                Dim month As Integer
                For Each month In months
                    If (month < 1 OrElse month > 12) AndAlso month <> - 1 Then
                        Throw New ArgumentOutOfRangeException ("month", _
                                                               CacheResources.ResourceManager ( _
                                                                                               "RES_ExceptionRangeMonth"))
                    End If
                Next month

                daysOfWeek = ParseValueToInt (parsedFormat (Convert.ToInt32 ( _
                                                                             CacheResources.ResourceManager ( _
                                                                                                             "RES_DaysOfWeekIndex"))))
                For Each day In daysOfWeek
                    If day > 6 Then
                        Throw New ArgumentOutOfRangeException ("day", _
                                                               CacheResources.ResourceManager ( _
                                                                                               "RES_ExceptionRangeDay"))
                    End If
                Next day
                Dim dayLength As Integer
                For dayLength = 0 To days.Length - 1
                    If Not (days (dayLength) = - 1 OrElse _
                            months (dayLength) = - 1) Then
                        If days (dayLength) > DateTime.DaysInMonth ( _
                                                                    DateTime.Now.Year, months (dayLength)) Then
                            Throw New Exception (CacheResources. _
                                                    ResourceManager ("RES_ExcetionInvalidDay"))
                        End If
                    End If
                Next dayLength

                If ExpireEveryMinute AndAlso ExpireEveryHour AndAlso _
                   ExpireEveryDay AndAlso ExpireEveryMonth AndAlso _
                   ExpireEveryDayOfWeek Then
                    isAlwaysExpired = True
                End If

            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Sub

#End Region

#Region "Public Method"

        ' <summary>
        '		This method gets the extended format minute argument.
        ' </summary>

        Public Function MinutesFormat() As Integer()

            Return minutes

        End Function

        ' <summary>
        '		This method gets the extended format hour argument.
        ' </summary>

        Public Function HoursFormat() As Integer()

            Return hours

        End Function

        ' <summary>
        '		This method gets the extended format day of month argument.
        ' </summary>

        Public Function DaysFormat() As Integer()

            Return days

        End Function

        ' <summary>
        '		This method gets the extended format month argument.
        ' </summary>

        Public Function MonthsFormat() As Integer()

            Return months

        End Function

        ' <summary>
        '		This method gets the extended format day of week argument.
        ' </summary>

        Public Function DaysOfWeekFormat() As Integer()

            Return daysOfWeek

        End Function

#End Region

#Region "Private Methods"

        ' <summary>
        '		Parse a string value to int.
        ' </summary>
        ' <remarks>
        '		result = ParseValueToInt( timeFormat )
        ' </remarks>
        ' <param name="timeFormat">
        '		The string value
        ' </param>
        ' <returns>
        '		Int array
        ' </returns>

        Private Function ParseValueToInt (ByVal timeFormat As String) _
            As Integer()

            Try
                If Equals (timeFormat, Nothing) Then
                    Throw New ArgumentNullException ("timeFormat", _
                                                     CacheResources.ResourceManager ( _
                                                                                     "RES_ExceptionNullTimeFormat"))
                End If

                If timeFormat.Length = 0 Then
                    Throw New ArgumentOutOfRangeException ("timeFormat", _
                                                           CacheResources.ResourceManager ( _
                                                                                           "RES_ExceptionRangeTimeFormat"))
                End If

                Dim result As Integer()
                If timeFormat.IndexOf (WILDCARD_ALL) <> - 1 Then
                    result = New Integer(0) {}
                    result (0) = - 1
                Else
                    Dim values As String() = timeFormat.Split ( _
                                                               ARGUMENT_DELIMITER)
                    result = New Integer(values.Length - 1) {}
                    Dim counter As Integer
                    For counter = 0 To values.Length - 1
                        result (counter) = Integer.Parse (values (counter), _
                                                          CultureInfo.CurrentCulture)
                        If result (counter) < 0 Then
                            Throw New ArgumentException (CacheResources. _
                                                            ResourceManager ( _
                                                                             "RES_ExceptionInvalidExtendedFormatTime"))
                        End If
                    Next counter
                End If
                Return result

            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Function

#End Region
    End Class

#End Region
End Namespace
