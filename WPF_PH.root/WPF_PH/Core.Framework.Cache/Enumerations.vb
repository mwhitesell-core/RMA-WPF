'===============================================================================
' Microsoft Caching Application Block for .NET
' http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnpag/html/CachingBlock.asp
'
' Enumerations.vb
' This class has all the enumeration definitions required for the caching operations.
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
'		Specifies the item priority levels.
' </summary>
Public Enum CacheItemPriority

    Low
    Normal
    High
    NotRemovable
End Enum

' <summary>
'		Specifies the causes by which an item was removed from the cache.
' </summary>
Public Enum CacheItemRemoveCause

    Expired
    Removed
    Scavenged
End Enum
