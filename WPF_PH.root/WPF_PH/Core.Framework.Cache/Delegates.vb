'===============================================================================
' Microsoft Caching Application Block for .NET
' http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnpag/html/CachingBlock.asp
'
' Delegates.vb
' This class has all the delegates required for the caching operations.
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
'		Represents the method that will handle the dependency change event.
' </summary>
Public Delegate Sub ItemDependencyChangeEventHandler ( _
                                                      ByVal sender As Object, _
                                                      ByVal e As CacheEventArgs)

' <summary>
'		Represents the method that will be invoked when a item is removed.
' </summary>
Public Delegate Sub CacheItemRemovedCallback (ByVal key As String, _
                                              ByVal cause As CacheItemRemoveCause)


' <summary>
'		Represents the method that will handle the addition of item metadata.
' </summary>
Delegate Sub AddDataHandler (ByVal key As String, ByVal expirations() _
                                As ICacheItemExpiration, ByVal priority As CacheItemPriority, _
                             ByVal onRemoveCallback As CacheItemRemovedCallback)

' <summary>
'		Represents the method that will handle the flushing of all the items.
' </summary>
Delegate Sub FlushHandler()


' <summary>
'		Represents the method that will handle the retrieval of the cache item. 
' </summary>
Delegate Function GetHandler (ByVal key As String) As CacheItem


' <summary>
'		Represents the method that will handle the time when the item 
'       is last used.
' </summary>
Delegate Sub NotifyHandler (ByVal key As String)


' <summary>
'		Represents the method that will handle the removal of the item 
'       metadata.
' </summary>
Delegate Sub RemoveDataHandler (ByVal key As String)


' <summary>
'		Represents the method that will handle the updation of item metadata.
' </summary>
Delegate Sub UpdateHandler (ByVal key As String, ByVal expirations() _
                               As ICacheItemExpiration, ByVal priority As CacheItemPriority)

