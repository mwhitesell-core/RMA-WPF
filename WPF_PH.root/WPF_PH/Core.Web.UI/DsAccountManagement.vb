Imports System
Imports System.Collections
Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.Configuration
Imports System.DirectoryServices.AccountManagement
Imports System.Linq
Imports Core.Framework


Namespace Core.Windows.UI
    Public NotInheritable Class DsAccountManagement
        Private Sub New()
        End Sub
#Region "Variables"

        Private Shared ReadOnly SDomain As String = ConfigurationSettings.AppSettings("Domain").ToString()
        Private Shared ReadOnly SServiceUser As String = ConfigurationSettings.AppSettings("ServiceUser").ToString() + "@" + SDomain
        Private Shared ReadOnly SServicePassword As String = Decrypt(ConfigurationSettings.AppSettings("ServiceUserPassword").ToString())

#End Region

#Region "Validate Methods"

        Private Shared Sub AddRole(ByRef roleCollection As ObservableCollection(Of AppRole), role As String)
            If roleCollection.Where(Function(r) r.Code = role).FirstOrDefault() Is Nothing Then
                Dim appRole = New AppRole()
                appRole.Code = role
                roleCollection.Add(appRole)
            End If
        End Sub

        Public Shared Function RoleCollection(sName As String, sDomain As String) As ObservableCollection(Of AppRole)
            'if (sDomain != SDomain && sDomain + ".local" != SDomain)
            '    return null;

            Dim myRoles As ArrayList = GetUserGroups(sName)
            Dim rolesCollection = New ObservableCollection(Of AppRole)()

            For Each s As String In myRoles

                AddRole(rolesCollection, s)
            Next

           

            Return rolesCollection
        End Function

        Public Shared Function GivenName(sUserName As String) As String
            Dim oUserPrincipal As UserPrincipal = GetUser(sUserName)
            Return oUserPrincipal.GivenName

        End Function

        Public Shared Function LastName(sUserName As String) As String
            Dim oUserPrincipal As UserPrincipal = GetUser(sUserName)
            Return oUserPrincipal.Surname

        End Function

        ''' <summary>
        ''' Validates the username and password of a given user
        ''' </summary>
        ''' <param name="sUserName">The username to validate</param>
        ''' <param name="sPassword">The password of the username to validate</param>
        ''' <returns>Returns True of user is valid</returns>
        Public Shared Function ValidateCredentials(sUserName As String, sPassword As String) As Boolean
            Dim oPrincipalContext As PrincipalContext = GetPrincipalContext()
            Return oPrincipalContext.ValidateCredentials(sUserName, sPassword)
        End Function

        ''' <summary>
        ''' Checks if the User Account is Expired
        ''' </summary>
        ''' <param name="sUserName">The username to check</param>
        ''' <returns>Returns true if Expired</returns>
        Public Shared Function IsUserExpired(sUserName As String) As Boolean
            Dim oUserPrincipal As UserPrincipal = GetUser(sUserName)
            If oUserPrincipal.AccountExpirationDate IsNot Nothing Then
                Return False
            Else
                Return True
            End If
        End Function

        ''' <summary>
        ''' Checks if user exists on AD
        ''' </summary>
        ''' <param name="sUserName">The username to check</param>
        ''' <returns>Returns true if username Exists</returns>
        Public Shared Function IsUserExisiting(sUserName As String) As Boolean
            If GetUser(sUserName) Is Nothing Then
                Return False
            Else
                Return True
            End If
        End Function

        ''' <summary>
        ''' Checks if user account is locked
        ''' </summary>
        ''' <param name="sUserName">The username to check</param>
        ''' <returns>Returns true of Account is locked</returns>
        Public Shared Function IsAccountLocked(sUserName As String) As Boolean
            Dim oUserPrincipal As UserPrincipal = GetUser(sUserName)
            Return oUserPrincipal.IsAccountLockedOut()
        End Function

#End Region

#Region "Search Methods"

        ''' <summary>
        ''' Gets a certain user on Active Directory
        ''' </summary>
        ''' <param name="sUserName">The username to get</param>
        ''' <returns>Returns the UserPrincipal Object</returns>
        Public Shared Function GetUser(sUserName As String) As UserPrincipal
            Dim oPrincipalContext As PrincipalContext = GetPrincipalContext()

            Dim oUserPrincipal As UserPrincipal = UserPrincipal.FindByIdentity(oPrincipalContext, sUserName)
            Return oUserPrincipal
        End Function

        ''' <summary>
        ''' Gets a certain group on Active Directory
        ''' </summary>
        ''' <param name="sGroupName">The group to get</param>
        ''' <returns>Returns the GroupPrincipal Object</returns>
        Public Shared Function GetGroup(sGroupName As String) As GroupPrincipal
            Dim oPrincipalContext As PrincipalContext = GetPrincipalContext()

            Dim oGroupPrincipal As GroupPrincipal = GroupPrincipal.FindByIdentity(oPrincipalContext, sGroupName)
            Return oGroupPrincipal
        End Function

#End Region

#Region "User Account Methods"

        ''' <summary>
        ''' Sets the user password
        ''' </summary>
        ''' <param name="sUserName">The username to set</param>
        ''' <param name="sNewPassword">The new password to use</param>
        ''' <param name="sMessage">Any output messages</param>
        Public Shared Sub SetUserPassword(sUserName As String, sNewPassword As String, sMessage As String)
            Try
                Dim oUserPrincipal As UserPrincipal = GetUser(sUserName)
                oUserPrincipal.SetPassword(sNewPassword)
                sMessage = ""
            Catch ex As Exception
                sMessage = ex.Message
            End Try
        End Sub

        ''' <summary>
        ''' Enables a disabled user account
        ''' </summary>
        ''' <param name="sUserName">The username to enable</param>
        Public Shared Sub EnableUserAccount(sUserName As String)
            Dim oUserPrincipal As UserPrincipal = GetUser(sUserName)
            oUserPrincipal.Enabled = True
            oUserPrincipal.Save()
        End Sub

        ''' <summary>
        ''' Force disabling of a user account
        ''' </summary>
        ''' <param name="sUserName">The username to disable</param>
        Public Shared Sub DisableUserAccount(sUserName As String)
            Dim oUserPrincipal As UserPrincipal = GetUser(sUserName)
            oUserPrincipal.Enabled = False
            oUserPrincipal.Save()
        End Sub

        ''' <summary>
        ''' Force expire password of a user
        ''' </summary>
        ''' <param name="sUserName">The username to expire the password</param>
        Public Shared Sub ExpireUserPassword(sUserName As String)
            Dim oUserPrincipal As UserPrincipal = GetUser(sUserName)
            oUserPrincipal.ExpirePasswordNow()
            oUserPrincipal.Save()
        End Sub

        ''' <summary>
        ''' Unlocks a locked user account
        ''' </summary>
        ''' <param name="sUserName">The username to unlock</param>
        Public Shared Sub UnlockUserAccount(sUserName As String)
            Dim oUserPrincipal As UserPrincipal = GetUser(sUserName)
            oUserPrincipal.UnlockAccount()
            oUserPrincipal.Save()
        End Sub

        ''' <summary>
        ''' Creates a new user on Active Directory
        ''' </summary>
        ''' <param name="sOU">The OU location you want to save your user</param>
        ''' <param name="sUserName">The username of the new user</param>
        ''' <param name="sPassword">The password of the new user</param>
        ''' <param name="sGivenName">The given name of the new user</param>
        ''' <param name="sSurname">The surname of the new user</param>
        ''' <returns>returns the UserPrincipal object</returns>
        Public Shared Sub CreateNewUser(sOU As String, sUserName As String, sPassword As String, sGivenName As String, sSurname As String)
            If Not IsUserExisiting(sUserName) Then
                Dim oPrincipalContext As PrincipalContext = GetPrincipalContext(sOU)

                'Enabled or not
                Dim oUserPrincipal = New UserPrincipal(oPrincipalContext, sUserName, sPassword, True)

                'User Log on Name
                oUserPrincipal.UserPrincipalName = sUserName
                oUserPrincipal.GivenName = sGivenName
                oUserPrincipal.Surname = sSurname
                oUserPrincipal.Save()
            End If
        End Sub

        ''' <summary>
        ''' Deletes a user in Active Directory
        ''' </summary>
        ''' <param name="sUserName">The username you want to delete</param>
        ''' <returns>Returns true if successfully deleted</returns>
        Public Shared Function DeleteUser(sUserName As String) As Boolean
            Try
                Dim oUserPrincipal As UserPrincipal = GetUser(sUserName)

                oUserPrincipal.Delete()
                Return True
            Catch
                Return False
            End Try
        End Function

#End Region

#Region "Group Methods"

        ''' <summary>
        ''' Creates a new group in Active Directory
        ''' </summary>
        ''' <param name="sOU">The OU location you want to save your new Group</param>
        ''' <param name="sGroupName">The name of the new group</param>
        ''' <param name="sDescription">The description of the new group</param>
        ''' <param name="oGroupScope">The scope of the new group</param>
        ''' <param name="bSecurityGroup">True is you want this group 
        ''' to be a security group, false if you want this as a distribution group</param>
        ''' <returns>Returns the GroupPrincipal object</returns>
        Public Shared Sub CreateNewGroup(sOU As String, sGroupName As String, sDescription As String, oGroupScope As GroupScope, bSecurityGroup As Boolean)
            Dim oPrincipalContext As PrincipalContext = GetPrincipalContext(sOU)

            Dim oGroupPrincipal = New GroupPrincipal(oPrincipalContext, sGroupName)
            oGroupPrincipal.Description = sDescription
            oGroupPrincipal.GroupScope = oGroupScope
            oGroupPrincipal.IsSecurityGroup = bSecurityGroup
            oGroupPrincipal.Save()
        End Sub

        ''' <summary>
        ''' Adds the user for a given group
        ''' </summary>
        ''' <param name="sUserName">The user you want to add to a group</param>
        ''' <param name="sGroupName">The group you want the user to be added in</param>
        ''' <returns>Returns true if successful</returns>
        Public Shared Function AddUserToGroup(sUserName As String, sGroupName As String) As Boolean
            Try
                Dim oUserPrincipal As UserPrincipal = GetUser(sUserName)
                Dim oGroupPrincipal As GroupPrincipal = GetGroup(sGroupName)
                If oUserPrincipal IsNot Nothing AndAlso oGroupPrincipal IsNot Nothing Then
                    If Not IsUserGroupMember(sUserName, sGroupName) Then
                        oGroupPrincipal.Members.Add(oUserPrincipal)
                        oGroupPrincipal.Save()
                    End If
                End If
                Return True
            Catch
                Return False
            End Try
        End Function

        ''' <summary>
        ''' Removes user from a given group
        ''' </summary>
        ''' <param name="sUserName">The user you want to remove from a group</param>
        ''' <param name="sGroupName">The group you want the user to be removed from</param>
        ''' <returns>Returns true if successful</returns>
        Public Shared Function RemoveUserFromGroup(sUserName As String, sGroupName As String) As Boolean
            Try
                Dim oUserPrincipal As UserPrincipal = GetUser(sUserName)
                Dim oGroupPrincipal As GroupPrincipal = GetGroup(sGroupName)
                If oUserPrincipal IsNot Nothing AndAlso oGroupPrincipal IsNot Nothing Then
                    If IsUserGroupMember(sUserName, sGroupName) Then
                        oGroupPrincipal.Members.Remove(oUserPrincipal)
                        oGroupPrincipal.Save()
                    End If
                End If
                Return True
            Catch
                Return False
            End Try
        End Function

        ''' <summary>
        ''' Checks if user is a member of a given group
        ''' </summary>
        ''' <param name="sUserName">The user you want to validate</param>
        ''' <param name="sGroupName">The group you want to check the 
        ''' membership of the user</param>
        ''' <returns>Returns true if user is a group member</returns>
        Public Shared Function IsUserGroupMember(sUserName As String, sGroupName As String) As Boolean
            Dim oUserPrincipal As UserPrincipal = GetUser(sUserName)
            Dim oGroupPrincipal As GroupPrincipal = GetGroup(sGroupName)

            If oUserPrincipal IsNot Nothing AndAlso oGroupPrincipal IsNot Nothing Then
                Return oGroupPrincipal.Members.Contains(oUserPrincipal)
            Else
                Return False
            End If
        End Function

        ''' <summary>
        ''' Gets a list of the users group memberships
        ''' </summary>
        ''' <param name="sUserName">The user you want to get the group memberships</param>
        ''' <returns>Returns an arraylist of group memberships</returns>
        Public Shared Function GetUserGroups(sUserName As String) As ArrayList

            Dim myItems = New ArrayList()
            Dim oUserPrincipal As UserPrincipal = GetUser(sUserName)

            Dim oPrincipalSearchResult As PrincipalSearchResult(Of Principal) = oUserPrincipal.GetGroups()

            For Each oResult As Principal In oPrincipalSearchResult
                myItems.Add(oResult.Name)
            Next
            Return myItems
        End Function

        ''' <summary>
        ''' Gets a list of the users authorization groups
        ''' </summary>  
        ''' <param name="sUserName">The user you want to get authorization groups</param>
        ''' <returns>Returns an arraylist of group authorization memberships</returns>
        Public Shared Function GetUserAuthorizationGroups(sUserName As String) As ArrayList
            Dim myItems = New ArrayList()
            Dim oUserPrincipal As UserPrincipal = GetUser(sUserName)

            Dim oPrincipalSearchResult As PrincipalSearchResult(Of Principal) = oUserPrincipal.GetAuthorizationGroups()

            For Each oResult As Principal In oPrincipalSearchResult
                myItems.Add(oResult.Name)
            Next
            Return myItems
        End Function

#End Region

#Region "Helper Methods"

        ''' <summary>
        ''' Gets the base principal context
        ''' </summary>
        ''' <returns>Returns the PrincipalContext object</returns>
        Private Shared Function GetPrincipalContext() As PrincipalContext
            'new PrincipalContext
            '   (ContextType.Domain, sDomain, sDefaultOU, ContextOptions.SimpleBind,
            '   sServiceUser, sServicePassword);
            Dim oPrincipalContext = New PrincipalContext(ContextType.Domain, SDomain, SServiceUser, SServicePassword)
            Return oPrincipalContext
        End Function

        ''' <summary>
        ''' Gets the principal context on specified OU
        ''' </summary>
        ''' <param name="sOU">The OU you want your Principal Context to run on</param>
        ''' <returns>Returns the PrincipalContext object</returns>
        Private Shared Function GetPrincipalContext(sOU As String) As PrincipalContext
            'new PrincipalContext(ContextType.Domain, sDomain, sOU,
            'ContextOptions.SimpleBind, sServiceUser, sServicePassword);
            Dim oPrincipalContext = New PrincipalContext(ContextType.Domain, SDomain, SServiceUser, SServicePassword)

            Return oPrincipalContext
        End Function

#End Region
    End Class
End Namespace

