'===============================================================================
' Microsoft Caching Application Block for .NET
' http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnpag/html/CachingBlock.asp
'
' ExtendedFormatHelper.vb
' This class tests if a item was expired using a extended format.
'
'===============================================================================
' Copyright (C) 2003 Microsoft Corporation
' All rights reserved.
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
' OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
' LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
' FITNESS FOR A PARTICULAR PURPOSE.
'===============================================================================
Imports System.Runtime.InteropServices
Imports Core.ExceptionManagement

' Used for Handling Exceptions

Namespace Expirations

#Region "Extended Format Helper class"

    ' <summary>
    '		This class tests if an item was expired using a extended format.
    ' </summary>
    ' <remarks>
    ' Extended format sintax : <br/><br/>
    ' 
    ' Minute       - 0-59 <br/>
    ' Hour         - 0-23 <br/>
    ' Day of month - 1-31 <br/>
    ' Month        - 1-12 <br/>
    ' Day of week  - 0-7 (Sunday is 0 or 7) <br/>
    ' Wildcards    - * means run every <br/>
    ' Examples: <br/>
    ' * * * * *    - expire every minute of every day <br/>
    ' 5 * * * *    - expire 5th minute of every hour <br/>
    ' * 21 * * *   - expire every minute of the 21st hour of every day <br/>
    ' 31 15 * * *  - expire 3:31 PM every day <br/>
    ' 7 4 * * 6    - expire Saturday 4:07 AM <br/>
    ' 15 21 4 7 *  - expire 9:15 PM on 4 July <br/>
    ' </remarks>
    <ComVisible (False)> _
    Friend Class ExtendedFormatHelper

#Region "Private Members"

        Private Shared parsedFormatCache As New Hashtable()

#End Region

#Region "Constructor"

        ' <summary>
        '		Default constructor.
        ' </summary>
        Private Sub New()
        End Sub

#End Region

#Region "Public Methods"

#Region "IsExtendedExpired"

        ' <summary>
        '		Test the extended format with a given date.
        ' </summary>
        ' <remarks>
        '		isExpired = IsExtendedExpired( format, getTime, nowTime )
        ' </remarks>
        ' <param name="format">
        '		The extended format arguments
        ' </param>
        ' <param name="getTime">
        '		The time when the item has been refreshed
        ' </param>
        ' <param name="nowTime">
        '		Always DateTime.Now, or the date to test with
        ' </param>
        ' <returns>
        '		True if the item was expired, otherwise false
        ' </returns>
        Public Shared Function IsExtendedExpired (ByVal format As String, _
                                                  ByVal getTime As DateTime, ByVal nowTime As DateTime) As Boolean

            Try
                If Equals (format, Nothing) Then
                    Throw New ArgumentNullException ("format", CacheResources. _
                                                        ResourceManager ("RES_ExceptionNullFormat"))
                End If

                If format.Length = 0 Then
                    Throw New ArgumentOutOfRangeException ("format", _
                                                           CacheResources.ResourceManager ( _
                                                                                           "RES_ExceptionEmptyFormat"))
                End If

                Dim parsedFormat As ExtendedFormat = CType ( _
                        parsedFormatCache (format), ExtendedFormat)
                If Equals (parsedFormat, Nothing) Then
                    parsedFormat = New ExtendedFormat (format)
                    SyncLock parsedFormatCache.SyncRoot
                        parsedFormatCache (format) = parsedFormat
                    End SyncLock
                End If

                ' Validate the format arguments
                Dim isDataExpired As Boolean = parsedFormat.IsAlwaysExpire _
                                               OrElse ((parsedFormat.ExpireEveryMinute OrElse _
                                                        ValidateMinute (parsedFormat.MinutesFormat, _
                                                                        getTime, nowTime)) _
                                                       AndAlso (parsedFormat.ExpireEveryHour OrElse _
                                                                ValidateHour (parsedFormat.HoursFormat, getTime, nowTime)) _
                                                       AndAlso (parsedFormat.ExpireEveryDay OrElse _
                                                                ValidateDayOfMonth (parsedFormat.DaysFormat, _
                                                                                    getTime, nowTime)) _
                                                       AndAlso (parsedFormat.ExpireEveryMonth OrElse _
                                                                ValidateMonth (parsedFormat.MonthsFormat, _
                                                                               getTime, nowTime)) _
                                                       AndAlso (parsedFormat.ExpireEveryDayOfWeek OrElse _
                                                                ValidateDayOfWeek (parsedFormat.DaysOfWeekFormat, _
                                                                                   getTime, nowTime)))
                Return isDataExpired

            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Function

#End Region

#End Region

#Region "Private Methods"

#Region "ValidateMinute"

        ' <summary>
        '		Validates the extended format minute argument. 
        ' </summary>
        ' <remarks>
        '		isValid = ValidateMinute( minutes, getTime, nowTime )
        ' </remarks>
        ' <param name="minutes">
        '		The extended format minute argument
        ' </param>
        ' <param name="getTime">
        '		The time when the item has been refreshed
        ' </param>
        ' <param name="nowTime">
        '		Always DateTime.Now, or the date to test with
        ' </param>
        ' <returns>
        '		True if the item was expired, otherwise false
        ' </returns>
        Private Shared Function ValidateMinute (ByVal minutes() As Integer, _
                                                ByVal getTime As DateTime, ByVal nowTime As DateTime) As Boolean

            Try
                If Equals (minutes, Nothing) Then
                    Throw New ArgumentNullException ("minutes", _
                                                     CacheResources.ResourceManager ( _
                                                                                     "RES_ExceptionNullMinutes"))
                End If

                ' Validates the minute argument
                Dim span As TimeSpan = nowTime.Subtract (getTime)
                Dim minute As Integer
                For Each minute In minutes
                    If span.TotalMinutes >= 60 Then
                        Return True
                    Else
                        If Not Equals (getTime.Hour, nowTime.Hour) _
                           AndAlso nowTime.Minute >= minute OrElse _
                           (getTime.Minute < minute AndAlso _
                            nowTime.Minute >= minute) Then
                            Return True
                        End If
                    End If
                Next minute
                Return False
            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Function

#End Region

#Region "ValidateHour"

        ' <summary>
        '		Validates the extended format hour argument.  
        ' </summary>
        ' <remarks>
        '		isValid = ValidateHour( hours, getTime, nowTime )
        ' </remarks>
        ' <param name="hours">
        '		The extended format hour argument
        ' </param>
        ' <param name="getTime">
        '		The time when the item has been refreshed
        ' </param>
        ' <param name="nowTime">
        '		Always DateTime.Now, or the date to test with
        ' </param>
        ' <returns>
        '		true if the item was expired, otherwise false
        ' </returns>
        Private Shared Function ValidateHour (ByVal hours() As Integer, _
                                              ByVal getTime As DateTime, ByVal nowTime As DateTime) As Boolean

            Try
                Dim span As TimeSpan
                If Equals (hours, Nothing) Then
                    Throw New ArgumentNullException ("hours", CacheResources. _
                                                        ResourceManager ("RES_ExceptionNullHours"))
                End If

                ' Validates the hour argument			
                Dim hour As Integer
                For Each hour In hours
                    span = nowTime.Subtract (getTime)
                    If span.TotalHours >= 24 Then
                        Return True
                    ElseIf Not Equals (nowTime.Day, getTime.Day) _
                           AndAlso nowTime.Hour >= hour OrElse ( _
                               getTime.Hour <= hour AndAlso nowTime.Hour >= hour) Then
                        Return True
                    End If
                Next hour
                Return False
            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Function

#End Region

#Region "ValidateDayOfMonth"

        ' <summary>
        '		Validates the extended format day of month argument.
        ' </summary>
        ' <remarks>
        '		isValid = ValidateDayOfMonth( days, getTime, nowTime )
        ' </remarks>
        ' <param name="days">
        '		The extended format day of month argument
        ' </param>
        ' <param name="getTime">
        '		The time when the item has been refreshed
        ' </param>
        ' <param name="nowTime">
        '		Always DateTime.Now, or the date to test with
        ' </param>
        ' <returns>
        '		True if the item was expired, otherwise false
        ' </returns>
        Private Shared Function ValidateDayOfMonth (ByVal days() As Integer, _
                                                    ByVal getTime As DateTime, ByVal nowTime As DateTime) As Boolean

            Try
                Dim span As TimeSpan
                If Equals (days, Nothing) Then
                    Throw New ArgumentNullException ("days", CacheResources. _
                                                        ResourceManager ("RES_ExceptionNullDays"))
                End If

                ' Validates the day of month argument			
                Dim day As Integer
                For Each day In days
                    span = nowTime.Subtract (getTime)
                    If span.TotalDays >= 30 Then
                        Return True
                    Else
                        If Not Equals (getTime.Month, nowTime.Month) _
                           AndAlso nowTime.Day >= day OrElse _
                           (getTime.Day <= day AndAlso nowTime.Day >= day) Then
                            Return True
                        End If
                    End If
                    Return False
                Next day
            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Function

#End Region

#Region "ValidateMonth"

        ' <summary>
        '		Validates the extended format month argument. 
        ' </summary>
        ' <remarks>
        '		isValid = ValidateMonth( months, getTime, nowTime )
        ' </remarks>
        ' <param name="months">
        '		The extended format month argument
        ' </param>
        ' <param name="getTime">
        '		The time when the item has been refreshed
        ' </param>
        ' <param name="nowTime">
        '		Always DateTime.Now, or the date to test with
        ' </param>
        ' <returns>
        '		True if the item was expired, otherwise false
        ' </returns>
        Private Shared Function ValidateMonth (ByVal months() As Integer, _
                                               ByVal getTime As DateTime, ByVal nowTime As DateTime) As Boolean

            Try
                Dim span As TimeSpan

                If Equals (months, Nothing) Then
                    Throw New ArgumentNullException ("months", CacheResources. _
                                                        ResourceManager ("RES_ExceptionNullMonths"))
                End If

                ' Validates the month argument			
                Dim month As Integer
                For Each month In months
                    span = nowTime.Subtract (getTime)
                    If span.TotalDays >= 364 Then
                        Return True
                    Else
                        If Not Equals (nowTime.Year, getTime.Year) _
                           AndAlso nowTime.Month >= month OrElse _
                           (getTime.Month <= month AndAlso _
                            nowTime.Month >= month) Then
                            Return True
                        End If
                    End If
                Next month
                Return False
            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Function

#End Region

#Region "ValidateDayOfWeek"

        ' <summary>
        '		Validates the extended format day of week argument.  
        ' </summary>
        ' <remarks>
        '		isValid = ValidateDayOfWeek(daysOfWeek, getTime, nowTime)
        ' </remarks>
        ' <param name="daysOfWeek">
        '		The extended format day of week argument
        ' </param>
        ' <param name="getTime">
        '		The time when the item has been refreshed
        ' </param>
        ' <param name="nowTime">
        '		Always DateTime.Now, or the date to test with
        ' </param>
        ' <returns>
        '		True if the item was expired, otherwise false
        ' </returns>
        Private Shared Function ValidateDayOfWeek ( _
                                                   ByVal daysOfWeek() As Integer, _
                                                   ByVal getTime As DateTime, ByVal nowTime As DateTime) _
            As Boolean

            Try
                Dim dateValue As DateTime
                Dim span As TimeSpan

                If Equals (daysOfWeek, Nothing) Then
                    Throw New ArgumentNullException ("daysOfWeek", _
                                                     CacheResources.ResourceManager ( _
                                                                                     "RES_ExceptionNullDaysOfWeek"))
                End If

                ' Validates the day of week argument
                Dim day As Integer
                For Each day In daysOfWeek
                    span = nowTime.Subtract (getTime)
                    If span.TotalDays >= 7 Then
                        Return True
                    Else
                        dateValue = nowTime
                        Dim counter As Integer
                        For counter = 0 To dateValue = _
                                           dateValue.AddDays (- 1)
                            If Equals (CInt (dateValue.DayOfWeek), _
                                       day) Then
                                Return True
                            End If
                        Next counter
                        Return False
                    End If
                Next day
                Return False
            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Function

#End Region

#End Region
    End Class

#End Region
End Namespace

