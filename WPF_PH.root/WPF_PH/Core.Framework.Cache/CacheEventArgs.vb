'===============================================================================
' Microsoft Caching Application Block for .NET
' http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnpag/html/CachingBlock.asp
'
' CacheEventArgs.vb
' This class is derived from the EventArgs class and it wraps the key of the
' cache data to pass it to events.
'
'===============================================================================
' Copyright (C) 2003 Microsoft Corporation
' All rights reserved.
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
' OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
' LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
' FITNESS FOR A PARTICULAR PURPOSE.
'===============================================================================


' <summary>
'	This class is derived from EventArgs and is used to wrap
'	the cache item key for passing it to event handler.
' </summary>
Public Class CacheEventArgs
    Inherits EventArgs
    ' Unique value to identify a cache data
    Private key As String

    ' <summary>
    '	Property to return the key value.
    ' </summary>

    Public ReadOnly Property KeyValue() As String
        Get
            Return key
        End Get
    End Property

    ' <summary>
    ' Constructor to create the CacheEventArgs object.
    ' </summary>
    ' <param name="key">
    ' Key to uniquely identify a value
    ' </param>
    Public Sub New (ByVal key As String)
        Me.key = key
    End Sub

    'New
End Class

'CacheEventArgs