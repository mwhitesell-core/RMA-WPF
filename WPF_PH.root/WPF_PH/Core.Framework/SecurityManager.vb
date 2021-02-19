Imports System.ComponentModel
Imports System.Web
Imports System.Configuration
Imports Core.Framework.Core.Framework
Imports System.Web.Security
Imports System.Xml
Imports System.Text
Imports Core.DataAccess.Oracle
Imports Core.DataAccess.SqlServer
Imports System.Security.Cryptography
Imports System.IO
Imports Core.ExceptionManagement
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Data.SqlClient
Imports System.Security
Imports System.Data.OracleClient
Imports System.DirectoryServices
Imports System.Collections.ObjectModel
Imports Core.Framework.Core.Windows.Framework
Imports System.Linq

#If TARGET_DB = "INFORMIX" Then
Imports core.DataAccess.Informix
#Else
#End If

Namespace Core.Security
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: SecurityManager
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of SecurityManager.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(EditorBrowsableState.Advanced)>
    Public NotInheritable Class SecurityManager
        Private RunDateInsert As String = String.Empty

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

        ''' --- m_blnOracle --------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnOracle.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Private m_blnOracle As Boolean = True


        ''' --- m_htProxyUsers --------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_htProxyUsers.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        Private Shared m_htProxyUsers As Hashtable

        ' Used to store the Proxy Users

        ''' --- m_htProxyMappings --------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_htProxyMappings.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        Private Shared m_htProxyMappings As Hashtable

        ' Used to store the User and mapping Proxy User

        Private m_strAuthenticationSite As String
        Private m_hcContext As HttpContext

        ''' --- New ----------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of New.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub New()
            If ConfigurationManager.AppSettings("AuthenticationDatabase") Is Nothing OrElse
               ConfigurationManager.AppSettings("AuthenticationDatabase").ToString.Equals(cORACLE) Then
                m_blnOracle = True
            Else
                m_blnOracle = False
            End If

        End Sub

        ''' --- AuthenticationDatabaseIsOracle -------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of AuthenticationDatabaseIsOracle.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public ReadOnly Property AuthenticationDatabaseIsOracle() As Boolean
            Get
                Return m_blnOracle
            End Get
        End Property

        ''' --- BypassCheck -------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of BypassCheck.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Property BypassCheck() As Boolean
            Get
                Return HttpContext.Current.Session("BypassCheck")
            End Get
            Set(ByVal value As Boolean)
                HttpContext.Current.Session("BypassCheck") = value
            End Set
        End Property


        ''' --- GetSystemConnectionString ------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetSystemConnectionString.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetSystemConnectionString() As String


            Return Common.GetConnectionString




        End Function

        ''' --- MatchPassword ------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of MatchPassword.
        ''' </summary>
        ''' <param name="PlainText"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)>
        Public Function MatchPassword(ByVal PlainText As String) As Boolean

            Return Encrypt(PlainText) = HttpContext.Current.Session("Password")

        End Function

        ''' --- GetEncryptedPassword ------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Encrypt.
        ''' </summary>
        ''' <param name="PlainText"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)>
        Public Function GetEncryptedPassword(ByVal PlainText As String) As String

            Dim objReader As IDataReader = Nothing
            Dim strSQL As New StringBuilder


#If TARGET_DB = "INFORMIX" Then


               return ""
#Else
            If AuthenticationDatabaseIsOracle Then

                strSQL.Append("SELECT renaissance_encryption.GET_ENCRYPTED_STRING('").Append(PlainText).Append(
                                                                                                                  "') Return Value")
                strSQL.Append(" FROM DUAL ")

                objReader = OracleHelper.ExecuteReader(GetSystemConnectionString, CommandType.Text, strSQL.ToString)
            Else

                strSQL.Append("DECLARE @RC int").Append(vbNewLine)
                strSQL.Append("DECLARE @ReturnValue varchar(255)").Append(vbNewLine)
                strSQL.Append("EXEC @RC = get_encrypted_string '").Append(PlainText).Append("', @ReturnValue OUT").
                    Append(vbNewLine)
                strSQL.Append("SELECT	'Return Value' = @ReturnValue")

                objReader = SqlHelper.ExecuteReader(GetSystemConnectionString, CommandType.Text, strSQL.ToString)

            End If

#End If


            If objReader.Read Then
                Return objReader(0).ToString
            Else
                Return ""
            End If

        End Function

        ''' --- Encrypt ------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Encrypt.
        ''' </summary>
        ''' <param name="PlainText"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function Encrypt(ByVal PlainText As String) As String
            ' Declare a UTF8Encoding object so we may use the GetByte 
            ' method to transform the plainText into a Byte array. 
            Dim utf8encoder As UTF8Encoding = New UTF8Encoding
            Dim inputInBytes() As Byte = utf8encoder.GetBytes(PlainText)

            ' Create a new TripleDES service provider 
            Dim tdesProvider As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider

            ' The ICryptTransform interface uses the TripleDES 
            ' crypt provider along with encryption key and init vector 
            ' information 
            Dim cryptoTransform As ICryptoTransform = tdesProvider.CreateEncryptor(Me.key, Me.iv)

            ' All cryptographic functions need a stream to output the 
            ' encrypted information. Here we declare a memory stream 
            ' for this purpose. 
            Dim encryptedStream As MemoryStream = New MemoryStream
            Dim _
                cryptStream As CryptoStream =
                    New CryptoStream(encryptedStream, cryptoTransform, CryptoStreamMode.Write)
            Dim strResult As String

            ' Write the encrypted information to the stream. Flush the information 
            ' when done to ensure everything is out of the buffer. 
            cryptStream.Write(inputInBytes, 0, inputInBytes.Length)
            cryptStream.FlushFinalBlock()
            encryptedStream.Position = 0

            ' Read the stream back into a Byte array and return it to the calling 
            ' method. 
            Dim bytResultBytes(Convert.ToInt16(encryptedStream.Length) - 1) As Byte

            encryptedStream.Read(bytResultBytes, 0, Convert.ToInt16(encryptedStream.Length))
            cryptStream.Close()
            encryptedStream.Close()
            strResult = Convert.ToBase64String(bytResultBytes)
            Return strResult

        End Function

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
        Private Function Decrypt(ByVal EncryptedString As String) As String

            ' UTFEncoding is used to transform the decrypted Byte Array 
            ' information back into a string. 
            Dim utf8encoder As UTF8Encoding = New UTF8Encoding
            Dim tdesProvider As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
            Dim bytInputBytes As Byte()
            ' As before we must provide the encryption/decryption key along with 
            ' the init vector. 
            Dim cryptoTransform As ICryptoTransform = tdesProvider.CreateDecryptor(Me.key, Me.iv)
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

        Public Function NoPermissions(ByVal ScreenName As String)
            HttpContext.Current.Response.Redirect(
                                                   HttpContext.Current.Request.ApplicationPath &
                                                   "/NoPermission.aspx?ScreenName=" & ScreenName)
        End Function



        Public Function CheckRoles(cr As ObservableCollection(Of AppRole)) As ObservableCollection(Of AppRole)

            Dim objReader As IDataReader = Nothing
            Dim strSQL As String
            Dim roles As ObservableCollection(Of AppRole)

            For Each r As AppRole In cr
                strSQL = "Select Role_Name,Role_Priority From Renaissance_Roles where Role_Name = '" + r.Code + "'"
                objReader = SqlHelper.ExecuteReader(GetSqlSecurityConnectionString(), CommandType.Text, strSQL)

                If objReader.Read Then

                    If IsNothing(roles) Then
                        roles = New ObservableCollection(Of AppRole)
                    End If
                    r.Priority = objReader("Role_Priority")
                    roles.Add(r)
                End If

            Next

            objReader.Dispose()

            For Each r As AppRole In roles.OrderByDescending(Function(s) s.Priority)
                ApplicationState.Current.CurrentRoles.Add(r)
            Next




            ApplicationState.Current.designersecurity = New Hashtable

            strSQL = "Select Screen,Desiner_Name,Enable From Renaissance_Designer_Security where Role = '" + ApplicationState.Current.CurrentRoles(0).Code + "' "
            objReader = SqlHelper.ExecuteReader(GetSqlSecurityConnectionString(), CommandType.Text, strSQL)
            Dim screen = ""
            Dim ht As Hashtable

            While objReader.Read

                If screen <> objReader("Screen").ToString.Trim Then

                    If IsNothing(ht) Then
                        ht = New Hashtable
                    Else
                        ApplicationState.Current.designersecurity.Add(screen, ht)
                        ht = New Hashtable
                    End If

                    screen = objReader("Screen").ToString.Trim

                    ht.Add(objReader("Desiner_Name").ToString.Trim, objReader("Enable").ToString.Trim)

                End If

            End While
            objReader.Dispose()

            If Not IsNothing(ht) Then
                ApplicationState.Current.designersecurity.Add(screen, ht)
            End If


            ApplicationState.Current.menusecurity = New Hashtable
            strSQL = "Select Tag, Visible From Renaissance_Menu_Security where Role = '" + ApplicationState.Current.CurrentRoles(0).Code + "' "
            objReader = SqlHelper.ExecuteReader(GetSqlSecurityConnectionString(), CommandType.Text, strSQL)

            While objReader.Read
                ApplicationState.Current.menusecurity.Add(objReader("Tag").ToString.Trim, objReader("Visible").ToString.Trim)
            End While

            objReader.Dispose()

            Return ApplicationState.Current.CurrentRoles

        End Function




        ''' --- CheckPermissions ---------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of CheckPermissions.
        ''' </summary>
        ''' <param name="ScreenName"></param>
        ''' <param name="SecurityMenu"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function CheckPermissions(ByVal ScreenName As String, ByRef SecurityMenu As Integer) As ScreenActivities
            Const cSCREEN_ENTRY As Integer = 2
            Const cSCREEN_FIND As Integer = 3
            Const cSCREEN_CHANGE As Integer = 4
            Const cSCREEN_DELETE As Integer = 5

            Dim intSecurityMenuEntry As Integer
            Dim intSecurityMenuFind As Integer
            Dim intSecurityMenuChange As Integer
            Dim intSecurityMenuDelete As Integer

            Dim objReader As IDataReader = Nothing
            Dim strSQL As String
            Dim _
                blSECURITY_ALL_ROLES As Boolean =
                    (ConfigurationManager.AppSettings("SECURITY_ALL_ROLES") + "").ToUpper = "TRUE"

            Try


                If SecurityMenu = 0 Then
                    If blSECURITY_ALL_ROLES Then
                        strSQL =
                            "Select distinct ROLE From Renaissance_Screen_Security where Role  in (SELECT ROLE_NAME from Renaissance_User_Roles where USER_NAME = '" +
                            GetCurrentUser.ToUpper + "')"
                    Else
                        strSQL = "Select  ROLE From Renaissance_Screen_Security Where ROLE = '" &
                                 GetUserSecurityClass() & "'"
                    End If

#If TARGET_DB = "INFORMIX" Then
                        objReader = InformixHelper.ExecuteReader(GetInformixConnectionString(), CommandType.Text, strSQL _
)
#Else
                    If AuthenticationDatabaseIsOracle Then
                        objReader = OracleHelper.ExecuteReader(GetConnectionString(), CommandType.Text, strSQL)
                    Else
                        objReader = SqlHelper.ExecuteReader(GetSqlSecurityConnectionString(), CommandType.Text, strSQL)
                    End If
#End If
                    If objReader.Read() Then
                        objReader.Close()
                        SecurityMenu = 2
                    Else
                        SecurityMenu = 1
                        objReader.Close()
                        objReader.Dispose()
                        Exit Function
                    End If
                ElseIf SecurityMenu = 1 Then
                    Exit Function
                End If

                If blSECURITY_ALL_ROLES Then

                    strSQL =
                        "  Select a.SCREEN, a.ROLE, a.SCREEN_ENTRY, a.SCREEN_FIND, a.SCREEN_CHANGE, a.SCREEN_DELETE "
                    strSQL = strSQL + " From Renaissance_Screen_Security a, Renaissance_User_Roles b "
                    strSQL = strSQL + " where b.USER_NAME = '" + GetCurrentUser.ToUpper + "'"
                    strSQL = strSQL + " AND a.Role = b.Role_Name"
                    strSQL = strSQL + " And (a.SCREEN = 'ALLOW_ACCESS_ALL_SCREENS' Or a.SCREEN = '" & ScreenName &
                             "')"
                    strSQL = strSQL + " ORDER BY b.Role_Priority"
                Else
                    strSQL =
                        "Select SCREEN, ROLE, SCREEN_ENTRY, SCREEN_FIND, SCREEN_CHANGE, SCREEN_DELETE From Renaissance_Screen_Security Where ROLE = '" &
                        GetUserSecurityClass() & "' And (SCREEN = 'ALLOW_ACCESS_ALL_SCREENS' Or SCREEN = '" &
                        ScreenName & "')"
                End If



                If AuthenticationDatabaseIsOracle Then
                    objReader = OracleHelper.ExecuteReader(GetConnectionString(), CommandType.Text, strSQL)
                Else
                    objReader = SqlHelper.ExecuteReader(GetSqlSecurityConnectionString(), CommandType.Text, strSQL)
                End If


                If blSECURITY_ALL_ROLES Then

                    Dim intSCREEN_ENTRY As Integer = 0
                    Dim intSCREEN_FIND As Integer = 0
                    Dim intSCREEN_CHANGE As Integer = 0
                    Dim intSCREEN_DELETE As Integer = 0
                    Dim blRead = False

                    Do While objReader.Read()
                        blRead = True
                        If CInt(objReader(cSCREEN_ENTRY)) = 1 Then
                            intSCREEN_ENTRY = 1
                        End If
                        If CInt(objReader(cSCREEN_FIND)) = 1 Then
                            intSCREEN_FIND = 1
                        End If
                        If CInt(objReader(cSCREEN_CHANGE)) = 1 Then
                            intSCREEN_CHANGE = 1
                        End If
                        If CInt(objReader(cSCREEN_DELETE)) = 1 Then
                            intSCREEN_DELETE = 1
                        End If

                    Loop

                    objReader.Close()
                    objReader.Dispose()

                    If blRead = False Then
                        intSecurityMenuEntry = 1
                        intSecurityMenuFind = 1
                        intSecurityMenuChange = 1
                        intSecurityMenuDelete = 1
                    Else
                        If _
                            intSCREEN_ENTRY = 0 AndAlso intSCREEN_FIND = 0 AndAlso intSCREEN_CHANGE = 0 AndAlso
                            intSCREEN_DELETE = 0 Then
                            HttpContext.Current.Response.Redirect(
                                                                   HttpContext.Current.Request.ApplicationPath &
                                                                   "/NoPermission.aspx?ScreenName=" & ScreenName)
                        End If

                        intSecurityMenuEntry = intSCREEN_ENTRY
                        intSecurityMenuFind = intSCREEN_FIND
                        intSecurityMenuChange = intSCREEN_CHANGE
                        intSecurityMenuDelete = intSCREEN_DELETE
                    End If
                Else
                    If objReader.Read() Then
                        If CInt(objReader(cSCREEN_ENTRY)) = 1 OrElse
                           CInt(objReader(cSCREEN_FIND)) = 1 OrElse
                           CInt(objReader(cSCREEN_CHANGE)) = 1 OrElse
                           CInt(objReader(cSCREEN_DELETE)) = 1 Then
                            'Allow access, if user has at least 
                            'one permission from Entry, Find, Change, and Delete

                            intSecurityMenuEntry = CInt(objReader(cSCREEN_ENTRY))
                            intSecurityMenuFind = CInt(objReader(cSCREEN_FIND))
                            intSecurityMenuChange = CInt(objReader(cSCREEN_CHANGE))
                            intSecurityMenuDelete = CInt(objReader(cSCREEN_DELETE))

                            objReader.Close()
                            objReader.Dispose()
                        Else
                            objReader.Close()
                            objReader.Dispose()
                            HttpContext.Current.Response.Redirect(
                                                                   HttpContext.Current.Request.ApplicationPath &
                                                                   "/NoPermission.aspx?ScreenName=" & ScreenName)
                        End If
                    Else
                        intSecurityMenuEntry = 1
                        intSecurityMenuFind = 1
                        intSecurityMenuChange = 1
                        intSecurityMenuDelete = 1
                        objReader.Close()
                        objReader.Dispose()
                    End If
                End If



                If intSecurityMenuFind = 1 Then
                    CheckPermissions = CheckPermissions Or ScreenActivities.Find
                End If

                If intSecurityMenuEntry = 1 Then
                    CheckPermissions = CheckPermissions Or ScreenActivities.Entry
                End If

                If intSecurityMenuChange = 1 Then
                    CheckPermissions = CheckPermissions Or ScreenActivities.Change
                End If

                If intSecurityMenuDelete = 1 Then
                    CheckPermissions = CheckPermissions Or ScreenActivities.Delete
                End If

            Catch ex As Exception

                If Not IsNothing(objReader) AndAlso Not objReader.IsClosed Then
                    objReader.Close()
                    objReader.Dispose()

                End If

                ExceptionManager.Publish(ex)
                Throw ex

            End Try

        End Function

        ''' --- Login --------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Login.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Overloads Function Login() As Boolean
            'This function is used to redirect user to login page if
            'session has Time-Out ("Deployment" in web.confg should be other than "Development")
            '
            'If you make any change to the Time-Out behaviour, you also need to make the similar 
            'change in HandleRunScreenException

            Dim currentSessionId As String = HttpContext.Current.Session.SessionID

            ' This abandons the current session and clears the session id cookie.  This ensures that
            ' the SessionManager components expires the old session (for table locking).
            HttpContext.Current.Session.Abandon()
            HttpContext.Current.Response.Cookies.Add(New HttpCookie("ASP.NET_SessionId", ""))

            With HttpContext.Current.Response
                If UsesActiveDirectory() Then
                    .Clear()
                    'TODO: To be redirected to Time-Out Page
                    .Write("<H1>Your session has ended</H1>")
                    .End()
                    Return False
                End If
                .Clear()
                .Expires = 0
                .ContentType = "text/HTML"

                Dim strIsFlickerFree As String
                strIsFlickerFree = ConfigurationManager.AppSettings("FlickerFree")
                If strIsFlickerFree Is Nothing OrElse Not strIsFlickerFree.ToString.Equals("True") Then
                    .Write("<script language='javascript'>")

                    .Write("  try { ")
                    .Write("if (window.top.frames[1].document.all.hidIsDirty){")
                    .Write("window.top.frames[1].document.all.hidIsDirty.value = ""Time-Out"";}")
                    .Write(" }catch (e) {}")

                    .Write("if (window.dialogTop==null){")
                    .Write("window.top.open('")
                    .Write(HttpContext.Current.Request.ApplicationPath & "/default.aspx?Redirected=Yes")
                    If Not ConfigurationManager.AppSettings("SshHost") Is Nothing Then
                        .Write("&SID=" & currentSessionId)
                        HttpContext.Current.Session("SID") = currentSessionId
                    End If
                    .Write("','_top',null,true);")
                    .Write("}else{")
                    .Write("window.returnValue='Time-Out';")
                    .Write("window.close();")
                    .Write("}")
                    .Write("</script>")
                Else
                    .Write("Redirect=")
                    .Write(HttpContext.Current.Request.ApplicationPath)
                    .Write("/default.aspx?Redirected=Yes")
                    If Not ConfigurationManager.AppSettings("SshHost") Is Nothing Then
                        .Write("&SID=" & currentSessionId)
                    End If
                End If
                .End()
            End With
        End Function

        ''' --- Login --------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Login.
        ''' </summary>
        ''' <param name="UserName"></param>
        ''' <param name="Password"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Overloads Function SetNewPassword(ByVal UserName As String, ByRef Password As String,
                                                  ByVal NewPassword As String) As String

            Dim strSQL As New StringBuilder
            Dim intReturnValue As Integer
            Dim strEncryptedPswd As String = String.Empty
            Dim intPasswordCount As Integer = 0

            Try
#If TARGET_DB = "INFORMIX" Then

                strSQL.Append(" UPDATE Renaissance_Security SET Pswd = GET_ENCRYPTED_STRING('").Append(NewPassword. _
PadRight(32)).Append("')")
                strSQL.Append( _
", pswd_expiry_date = DECODE(pswd_duration, 0, MDY(1,1,1900), DATE(TODAY + PSWD_DURATION))")
                strSQL.Append(" WHERE UPPER(User_Name) = '").Append(UserName.ToUpper).Append("'")
                intReturnValue = InformixHelper.ExecuteNonQuery(GetSystemConnectionString, CommandType.Text, strSQL. _
ToString)
#Else
                If AuthenticationDatabaseIsOracle Then

                    strSQL.Append(
                                   " UPDATE Renaissance_Security SET Pswd = renaissance_encryption.get_encrypted_string('") _
                        .Append(NewPassword.PadRight(32).ToUpper).Append("')")
                    strSQL.Append(" WHERE UPPER(User_Name) = '").Append(UserName.ToUpper).Append("'")
                    intReturnValue =
                        OracleHelper.ExecuteNonQuery(GetSystemConnectionString, CommandType.Text, strSQL.ToString)
                Else
                    If _
                        Not IsNothing(ConfigurationManager.AppSettings("Min_Password_Length")) AndAlso
                        CInt(ConfigurationManager.AppSettings("Min_Password_Length")) > 0 Then
                        If CInt(ConfigurationManager.AppSettings("Min_Password_Length")) > NewPassword.Length Then
                            Return "6," & ConfigurationManager.AppSettings("Min_Password_Length")
                        End If
                    End If

                    If _
                        Not IsNothing(ConfigurationManager.AppSettings("Special_Characters")) AndAlso
                        CBool(ConfigurationManager.AppSettings("Special_Characters")) = True Then
                        Dim intcount As Integer = 0
                        Dim arpattern As New ArrayList
                        arpattern.Add(".")
                        arpattern.Add("`")
                        arpattern.Add("~")
                        arpattern.Add("!")
                        arpattern.Add("@")
                        arpattern.Add("#")
                        arpattern.Add("$")
                        arpattern.Add("%")
                        arpattern.Add("^")
                        arpattern.Add("&")
                        arpattern.Add("*")
                        arpattern.Add("_")
                        arpattern.Add("-")
                        arpattern.Add("+")
                        arpattern.Add("=")
                        arpattern.Add("[")
                        arpattern.Add("{")
                        arpattern.Add("]")
                        arpattern.Add("}")
                        arpattern.Add("|")
                        arpattern.Add("\")
                        arpattern.Add("<")
                        arpattern.Add(">")
                        arpattern.Add("?")
                        arpattern.Add("/")


                        Dim blnSpecial As Boolean = False

                        Do While intcount < NewPassword.Length
                            If arpattern.Contains(NewPassword.Substring(intcount, 1)) Then
                                blnSpecial = True
                                Exit Do
                            End If
                            intcount = intcount + 1
                        Loop

                        If Not blnSpecial Then
                            arpattern = Nothing
                            Return "7"
                        End If
                        arpattern = Nothing
                    End If


                    If _
                        Not IsNothing(ConfigurationManager.AppSettings("Upper_Lower_Case")) AndAlso
                        CBool(ConfigurationManager.AppSettings("Upper_Lower_Case")) = True Then
                        Dim intcount As Integer = 0
                        Dim pattern As String = "[a-z]"
                        Dim cappattern As String = "[A-Z]"
                        Dim AllCaps As Regex = New Regex(pattern)
                        Dim blnlower As Boolean = False
                        Dim blnUpper As Boolean = False

                        Do While intcount < NewPassword.Length
                            If AllCaps.IsMatch(NewPassword.Substring(intcount, 1)) Then
                                blnlower = True
                                Exit Do
                            End If
                            intcount = intcount + 1
                        Loop
                        intcount = 0
                        AllCaps = New Regex(cappattern)
                        Do While intcount < NewPassword.Length
                            If AllCaps.IsMatch(NewPassword.Substring(intcount, 1)) Then
                                blnUpper = True
                                Exit Do
                            End If
                            intcount = intcount + 1
                        Loop

                        If Not (blnlower AndAlso blnUpper) Then
                            Return "4"
                        End If

                    End If

                    If _
                        Not IsNothing(ConfigurationManager.AppSettings("Character_Numeric")) AndAlso
                        CBool(ConfigurationManager.AppSettings("Character_Numeric")) = True Then
                        Dim intcount As Integer = 0
                        Dim pattern As String = "[a-z]|[A-Z]"
                        Dim AllCaps As Regex = New Regex(pattern)
                        Dim blnNumeric As Boolean = False
                        Dim blnChar As Boolean = False

                        Do While intcount < NewPassword.Length
                            If AllCaps.IsMatch(NewPassword.Substring(intcount, 1)) Then
                                blnChar = True
                            ElseIf IsNumeric(NewPassword.Substring(intcount, 1)) Then
                                blnNumeric = True
                            End If
                            intcount = intcount + 1
                        Loop

                        If Not (blnChar AndAlso blnNumeric) Then
                            Return "5"
                        End If

                    End If


                    Dim objReader As IDataReader = Nothing

                    If Not IsNothing(ConfigurationManager.AppSettings("Account_Lockout_Threshold")) Then

                        strSQL.Append(" SELECT * FROM Renaissance_Security")
                        strSQL.Append(" WHERE USER_NAME = '").Append(UserName.ToUpper).Append("'")
                        objReader =
                            SqlHelper.ExecuteReader(GetSystemConnectionString, CommandType.Text, strSQL.ToString)

                        If objReader.Read Then
                            Dim dteNewDate As Date = CDate(Now())
                            If Not IsNull(objReader("Acc_Lck_Out")) AndAlso objReader("Acc_Lck_Out") > dteNewDate _
                                Then
                                Return "1"
                            ElseIf _
                                Not IsNull(objReader("Not_Chg_Before")) AndAlso
                                objReader("Not_Chg_Before") > dteNewDate Then
                                Return "2," + objReader("Not_Chg_Before")
                            End If
                        End If

                    End If


                    strSQL.Remove(0, strSQL.Length)

                    strEncryptedPswd = GetEncryptedPassword(NewPassword.PadRight(32))
                    strEncryptedPswd = strEncryptedPswd.Replace("'", "''")

                    If Not IsNothing(ConfigurationManager.AppSettings("Password_History")) Then
                        strSQL.Append(" SELECT * FROM Renaissance_Pswd_History")
                        strSQL.Append(" WHERE USER_NAME = '").Append(UserName.ToUpper).Append("'")
                        strSQL.Append(" ORDER BY DATE ")
                        objReader =
                            SqlHelper.ExecuteReader(GetSystemConnectionString, CommandType.Text, strSQL.ToString)

                        Do While objReader.Read
                            If objReader("PSWD").ToString.Trim = strEncryptedPswd.Trim Then
                                Return "3"
                            End If

                            intPasswordCount = intPasswordCount + 1

                            If Not IsNothing(ConfigurationManager.AppSettings("Password_History")) Then
                                If intPasswordCount >= CInt(ConfigurationManager.AppSettings("Password_History")) Then

                                    strSQL.Remove(0, strSQL.Length)
                                    strSQL.Append(" delete Renaissance_Pswd_History ")
                                    strSQL.Append(" where DATE IN (SELECT top 1 DATE FROM Renaissance_Pswd_History ")
                                    strSQL.Append(" where user_name = '").Append(UserName.ToUpper).Append(
                                                                                                             " ' order by DATE) ")

                                    SqlHelper.ExecuteNonQuery(GetSystemConnectionString, CommandType.Text,
                                                               strSQL.ToString)

                                End If
                            End If


                        Loop


                        RunDateInsert = Now.Month.ToString.PadLeft(2, "0") + "/" + Now.Day.ToString.PadLeft(2, "0") +
                                        "/" + Now.Year.ToString.Substring(2) + " " +
                                        Now.ToLongTimeString.PadLeft(11, " ")

                        strSQL.Remove(0, strSQL.Length)
                        strSQL.Append(" INSERT INTO Renaissance_Pswd_History")
                        strSQL.Append(" (USER_NAME, PSWD, DATE) ")
                        strSQL.Append("VALUES ('").Append(UserName.ToUpper).Append("', '").Append(strEncryptedPswd).
                            Append("', '").Append(RunDateInsert).Append("')")

                        SqlHelper.ExecuteNonQuery(GetSystemConnectionString, CommandType.Text, strSQL.ToString)

                    End If


                    strSQL.Remove(0, strSQL.Length)
                    strSQL.Append("DECLARE @RC int").Append(vbNewLine)
                    strSQL.Append("DECLARE @ReturnValue varchar(255)").Append(vbNewLine)
                    strSQL.Append("EXEC @RC = get_encrypted_string '").Append(NewPassword.PadRight(32)).Append(
                                                                                                                   "', @ReturnValue OUT") _
                        .Append(vbNewLine)
                    strSQL.Append(" UPDATE Renaissance_Security SET Pswd = @ReturnValue")
                    If Not IsNothing(ConfigurationManager.AppSettings("Max_Password_Age")) Then
                        Dim _
                            dteNewDate As Date =
                                CDate(Now.AddDays(CInt(ConfigurationManager.AppSettings("Max_Password_Age"))))
                        RunDateInsert = dteNewDate.Month.ToString.PadLeft(2, "0") + "/" +
                                        dteNewDate.Day.ToString.PadLeft(2, "0") + "/" +
                                        dteNewDate.Year.ToString.Substring(2) + " " +
                                        dteNewDate.ToLongTimeString.PadLeft(11, " ")
                        strSQL.Append(", Pswd_Expiry_Date = '").Append(RunDateInsert).Append("'")
                    Else
                        strSQL.Append(", Pswd_Expiry_Date = '1/1/1900 12:00:00 AM'")
                    End If
                    If _
                        Not IsNothing(ConfigurationManager.AppSettings("Min_Password_Age")) AndAlso
                        CInt(ConfigurationManager.AppSettings("Min_Password_Age")) > 0 Then
                        Dim _
                            dteNewDate As Date =
                                CDate(Now.AddDays(CInt(ConfigurationManager.AppSettings("Min_Password_Age"))))
                        RunDateInsert = dteNewDate.Month.ToString.PadLeft(2, "0") + "/" +
                                        dteNewDate.Day.ToString.PadLeft(2, "0") + "/" +
                                        dteNewDate.Year.ToString.Substring(2) + " " +
                                        dteNewDate.ToLongTimeString.PadLeft(11, " ")
                        strSQL.Append(", Not_Chg_Before = '").Append(RunDateInsert).Append("'")
                    End If
                    strSQL.Append(" WHERE UPPER(User_Name) = '").Append(UserName.ToUpper).Append("'")
                    intReturnValue =
                        SqlHelper.ExecuteNonQuery(GetSystemConnectionString, CommandType.Text, strSQL.ToString)


                End If
#End If
                Password = NewPassword
                HttpContext.Current.Session.Remove("PasswordExpiry")

                Return 0

            Catch ex As Exception

                ExceptionManager.Publish(ex)

                Throw ex

            End Try

        End Function

        ''' --- CorrectIPAddress --------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of CorrectIPAddress.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Overloads Function CorrectIPAddress() As Boolean

            Return _
                HttpContext.Current.Session(Encrypt("IpAddress")) =
                Encrypt(HttpContext.Current.Request.ServerVariables("REMOTE_ADDR").ToString())

        End Function

        ''' --- Login --------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Login.
        ''' </summary>
        ''' <param name="UserName"></param>
        ''' <param name="Password"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------

        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Overloads Function Login(ByVal UserName As String, ByVal Password As String) As Integer

            Dim objReader As IDataReader = Nothing
            Dim strSQL As New StringBuilder
            Dim blnLogin As Boolean
            Dim userAccount As String = String.Empty
            Dim position As Integer = -1

            Try
                position = UserName.IndexOf(".")
                If position > -1 Then
                    userAccount = UserName.Substring(position + 1)
                    UserName = UserName.Substring(0, position)
                End If

#If TARGET_DB = "INFORMIX" Then

                strSQL.Append( _
"SELECT a.User_Name, Get_User_Password(a.User_Name) PSWD, a.Security_Class, a.Pswd_Expiry_Date, a.Pswd_Duration")
                strSQL.Append(" FROM RENAISSANCE_SECURITY a, RENAISSANCE_SECURITY b")
                strSQL.Append(" WHERE UPPER(a.User_Name) = '" & UserName.ToUpper & "'")
                strSQL.Append(" AND a.Security_Class = b.User_Name")

                objReader = InformixHelper.ExecuteReader(GetSystemConnectionString, CommandType.Text, strSQL.ToString)
#Else


                If _
                    Not IsNothing(ConfigurationManager.AppSettings("LoginFrom")) AndAlso
                    Not IsNothing(ConfigurationManager.AppSettings("LoginTo")) Then


                    Dim _
                        fromdate As Date = CDate(Now).ToString.Split(" ")(0) & " " &
                                           ConfigurationManager.AppSettings("LoginFrom")
                    Dim _
                        fromto As Date = CDate(Now).ToString.Split(" ")(0) & " " &
                                         ConfigurationManager.AppSettings("LoginTo")


                    If CDate(Now) < fromdate Or
                       CDate(Now) > fromto Then
                        Return 4
                    End If
                End If

                If AuthenticationDatabaseIsOracle Then

                    strSQL.Append(
                                   "SELECT a.User_Name, renaissance_encryption.Get_User_Password(a.User_Name) PSWD, a.Security_Class, a.Pswd_Expiry_Date, a.Pswd_Duration")
                    strSQL.Append(" FROM RENAISSANCE_SECURITY a, RENAISSANCE_SECURITY b")
                    strSQL.Append(" WHERE UPPER(a.User_Name) = '" & UserName.ToUpper & "'")
                    strSQL.Append(" AND a.Security_Class = b.User_Name")

                    objReader =
                        OracleHelper.ExecuteReader(GetSystemConnectionString, CommandType.Text, strSQL.ToString)
                Else

                    If _
                        Not IsNothing(ConfigurationManager.AppSettings("Account_Lockout_Duration")) AndAlso
                        Not IsNothing(ConfigurationManager.AppSettings("Account_Lockout_Threshold")) Then
                        strSQL.Append("DECLARE @RC int").Append(vbNewLine)
                        strSQL.Append("DECLARE @UserName varchar(255)").Append(vbNewLine)
                        strSQL.Append("DECLARE @ReturnValue varchar(255)").Append(vbNewLine)
                        strSQL.Append("SET @UserName = '").Append(UserName.ToUpper).Append("'").Append(vbNewLine)
                        strSQL.Append("EXEC @RC = Get_User_Password @UserName, @ReturnValue OUT").Append(vbNewLine)
                        strSQL.Append(
                                       "SELECT a.User_Name, @ReturnValue PSWD, a.Security_Class, a.Pswd_Expiry_Date, a.Pswd_Duration")
                        strSQL.Append(",a.Acc_Attempts, a.Acc_Lck_Out")
                        strSQL.Append(" FROM RENAISSANCE_SECURITY a, RENAISSANCE_SECURITY b")
                        strSQL.Append(" WHERE UPPER(a.User_Name) = '").Append(UserName.ToUpper).Append("'")
                        strSQL.Append(" AND a.Security_Class = b.User_Name")
                    Else
                        strSQL.Append("DECLARE @RC int").Append(vbNewLine)
                        strSQL.Append("DECLARE @UserName varchar(255)").Append(vbNewLine)
                        strSQL.Append("DECLARE @ReturnValue varchar(255)").Append(vbNewLine)
                        strSQL.Append("SET @UserName = '").Append(UserName.ToUpper).Append("'").Append(vbNewLine)
                        strSQL.Append("EXEC @RC = Get_User_Password @UserName, @ReturnValue OUT").Append(vbNewLine)
                        strSQL.Append(
                                       "SELECT a.User_Name, @ReturnValue PSWD, a.Security_Class, a.Pswd_Expiry_Date, a.Pswd_Duration")
                        strSQL.Append(" FROM RENAISSANCE_SECURITY a, RENAISSANCE_SECURITY b")
                        strSQL.Append(" WHERE UPPER(a.User_Name) = '").Append(UserName.ToUpper).Append("'")
                        strSQL.Append(" AND a.Security_Class = b.User_Name")

                    End If


                    objReader = SqlHelper.ExecuteReader(GetSystemConnectionString, CommandType.Text, strSQL.ToString)
                End If
#End If

                If Not objReader.Read Then
                    'UserName is invalid
                    blnLogin = False
                Else


#If TARGET_DB = "INFORMIX" Then
                    If objReader.GetString(1).Trim.ToUpper = Password.ToUpper Then

                        HttpContext.Current.Session.Add("Password", Encrypt(objReader.GetString(1).Trim))
#Else
                    If _
                        Not IsNothing(ConfigurationManager.AppSettings("Account_Lockout_Duration")) AndAlso
                        Not IsNothing(ConfigurationManager.AppSettings("Account_Lockout_Threshold")) AndAlso
                        Not AuthenticationDatabaseIsOracle AndAlso Not IsNull(objReader("Acc_Lck_Out")) AndAlso
                        objReader("Acc_Lck_Out") > CDate(Now) Then
                        HttpContext.Current.Session.Add("AccountLocked", "Locked")
                        Return 3

                    ElseIf objReader.GetString(1).Trim = Password Then
                        HttpContext.Current.Session.Add("Password", Encrypt(Password))
#End If
                        HttpContext.Current.Session.Add(Encrypt("IpAddress"),
                                                         Encrypt(
                                                                  HttpContext.Current.Request.ServerVariables(
                                                                                                               "REMOTE_ADDR") _
                                                                     .ToString()))

                        ' Check if the password has expired.
                        Dim dteExpiry As Date
                        If Not objReader.GetValue(3) Is DBNull.Value Then
                            dteExpiry = objReader.GetDateTime(3)
                        End If
                        Dim intDuration As Integer
                        If Not objReader.GetValue(4) Is DBNull.Value Then
                            intDuration = objReader.GetValue(4)
                        End If

                        If dteExpiry > Now OrElse (dteExpiry = New Date(1900, 1, 1) AndAlso intDuration = 0) Then

                            Dim strRole As String = objReader.GetString(2)
                            SetCurrentUser(UserName)
                            If userAccount.Length > 0 Then SetCurrentAccount(userAccount)
                            objReader.Close()
                            objReader.Dispose()

                            ' Determine the user's roles.
                            If Not Me.UsesActiveDirectory Then
                                Dim strRoles As String = RetrieveUserRoles(UserName)
                                If strRoles.Length = 0 Then strRoles = strRole
                                HttpContext.Current.Session.Add("UserRoles", strRole)
                            End If


#If TARGET_DB = "INFORMIX" Then
#Else

                            If _
                                Not AuthenticationDatabaseIsOracle AndAlso
                                Not IsNothing(ConfigurationManager.AppSettings("Account_Lockout_Duration")) AndAlso
                                Not IsNothing(ConfigurationManager.AppSettings("Account_Lockout_Threshold")) Then

                                strSQL.Remove(0, strSQL.Length)
                                strSQL.Append(" UPDATE Renaissance_Security SET Acc_Attempts = 0, Acc_Lck_Out = null")
                                strSQL.Append(" WHERE UPPER(User_Name) = '").Append(UserName.ToUpper).Append("'")
                                SqlHelper.ExecuteNonQuery(GetSystemConnectionString, CommandType.Text, strSQL.ToString)
                                HttpContext.Current.Session.Remove("AccountLocked")

                            End If

#End If

                            If ConfigurationManager.AppSettings("Redirect") = "On" Then
                                HttpContext.Current.Response.Redirect(
                                                                       HttpContext.Current.Request.Url.ToString.Substring(0, HttpContext.Current.Request.Url.ToString.LastIndexOf("/")) & "/" &
                                                                       ConfigurationManager.AppSettings("Screen"))
                            End If

                        Else ' If dteExpiry > Now Then
                            HttpContext.Current.Session.Add("PasswordExpiry", "Expired")
                        End If
                        ' If dteExpiry > Now Then

                    Else
                        'Password is Invalid
                        blnLogin = False

#If TARGET_DB = "INFORMIX" Then
#Else
                        If _
                            Not AuthenticationDatabaseIsOracle AndAlso
                            Not IsNothing(ConfigurationManager.AppSettings("Account_Lockout_Duration")) AndAlso
                            CInt(ConfigurationManager.AppSettings("Account_Lockout_Duration")) > 0 Then


                            strSQL.Remove(0, strSQL.Length)

                            strSQL.Append("SELECT Acc_Attempts from RENAISSANCE_SECURITY")
                            strSQL.Append(" WHERE UPPER(User_Name) = '").Append(UserName.ToUpper).Append("'")
                            objReader =
                                SqlHelper.ExecuteReader(GetSystemConnectionString, CommandType.Text, strSQL.ToString)


                            If objReader.Read Then

                                If Not IsNothing(ConfigurationManager.AppSettings("Account_Lockout_Threshold")) Then

                                    If _
                                        objReader("Acc_Attempts") >=
                                        (CInt(ConfigurationManager.AppSettings("Account_Lockout_Threshold")) - 1) Then
                                        strSQL.Remove(0, strSQL.Length)
                                        strSQL.Append(" UPDATE Renaissance_Security SET Acc_Attempts = 0")
                                        If _
                                            Not _
                                            IsNothing(ConfigurationManager.AppSettings("Account_Lockout_Duration")) AndAlso
                                            CInt(ConfigurationManager.AppSettings("Account_Lockout_Duration")) > 0 _
                                            Then
                                            Dim _
                                                dteNewDate As Date =
                                                    CDate(
                                                    Now.AddMinutes(
                                                                    CInt(
                                                                       ConfigurationManager.AppSettings(
                                                                                                         "Account_Lockout_Duration"))))
                                            strSQL.Append(" , Acc_Lck_Out = '").Append(dteNewDate).Append("'")
                                            HttpContext.Current.Session.Add("AccountLocked", "Locked")
                                        End If
                                        strSQL.Append(" WHERE UPPER(User_Name) = '").Append(UserName.ToUpper).Append(
                                                                                                                        "'")
                                        SqlHelper.ExecuteNonQuery(GetSystemConnectionString, CommandType.Text,
                                                                   strSQL.ToString)
                                    Else
                                        strSQL.Remove(0, strSQL.Length)
                                        strSQL.Append(" UPDATE Renaissance_Security SET Acc_Attempts = ").Append(
                                                                                                                   objReader(
                                                                                                                              "Acc_Attempts") +
                                                                                                                   1)
                                        strSQL.Append(" WHERE UPPER(User_Name) = '").Append(UserName.ToUpper).Append(
                                                                                                                        "'")
                                        SqlHelper.ExecuteNonQuery(GetSystemConnectionString, CommandType.Text,
                                                                   strSQL.ToString)

                                    End If
                                End If


                            End If


                        End If
#End If

                    End If

                End If

                objReader.Close()
                objReader.Dispose()


                Return blnLogin

            Catch ex As ThreadAbortException

            Catch ex As Exception

                If Not IsNothing(objReader) AndAlso Not objReader.IsClosed Then
                    objReader.Close()
                    objReader.Dispose()

                End If

                ExceptionManager.Publish(ex)

                Throw ex

            End Try

        End Function

#If TARGET_DB <> "INFORMIX" Then

        ''' --- StartBatch --------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of StartBatch.
        ''' </summary>
        ''' <param name="strFile"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Overloads Function StartBatch(ByVal strFile As String) As Boolean


            Dim objReader As IDataReader = Nothing
            Dim strSQL As New StringBuilder
            Dim intJobFence As Integer = 1
            Dim _
                blnJobQueByFile As Boolean =
                    (Not IsNothing(ConfigurationManager.AppSettings("JobQueByFile")) AndAlso
                     ConfigurationManager.AppSettings("JobQueByFile").ToUpper = "TRUE")

            If Not IsNothing(ConfigurationManager.AppSettings("JobFence")) Then
                intJobFence = CInt(ConfigurationManager.AppSettings("JobFence"))
            End If

            Try
                If Not BypassCheck Then


                    strSQL.Append(" SELECT COUNT(*) FROM Renaissance_Batch_Job ")
                    If blnJobQueByFile Then
                        strSQL.Append(" WHERE JOBSCRIPT_FILE = '***RUNNING***").Append(
                                                                                         strFile.Split("_")(0).
                                                                                            ToString).Append("'")
                    Else
                        strSQL.Append(" WHERE JOBSCRIPT_FILE = '***RUNNING***'")
                    End If

                    objReader =
                        SqlHelper.ExecuteReader(Decrypt(ConfigurationManager.AppSettings("SQLConnectionString")),
                                                 CommandType.Text, strSQL.ToString)


                    If objReader.Read Then

                        If objReader(0) < intJobFence Then
                            RunDateInsert = Now.Month.ToString.PadLeft(2, "0") + "/" +
                                            Now.Day.ToString.PadLeft(2, "0") + "/" + Now.Year.ToString.Substring(2) +
                                            " " + Now.ToLongTimeString.PadLeft(11, " ")
                            strSQL.Append(" Insert into Renaissance_Batch_Job (JOBSCRIPT_FILE,DATE_INSERTED) Values(")

                            If blnJobQueByFile Then
                                strSQL.Append("'").Append("***RUNNING***").Append(strFile.Split("_")(0).ToString).
                                    Append("','").Append(RunDateInsert).Append("')")
                            Else
                                strSQL.Append("'").Append("***RUNNING***").Append("','").Append(RunDateInsert).
                                    Append("')")
                            End If
                            SqlHelper.ExecuteNonQuery(
                                                       Decrypt(ConfigurationManager.AppSettings("SQLConnectionString")),
                                                       CommandType.Text, strSQL.ToString)

                            Return True
                        Else
                            strSQL.Remove(0, strSQL.Length)

                            strSQL.Append(" Insert into Renaissance_Batch_Job (JOBSCRIPT_FILE,DATE_INSERTED) Values(")
                            strSQL.Append("'").Append(strFile).Append("','").Append(Now).Append("')")

                            SqlHelper.ExecuteNonQuery(
                                                       Decrypt(ConfigurationManager.AppSettings("SQLConnectionString")),
                                                       CommandType.Text, strSQL.ToString)

                            Return False
                        End If
                    Else
                        strSQL.Remove(0, strSQL.Length)
                        RunDateInsert = Now.Month.ToString.PadLeft(2, "0") + "/" + Now.Day.ToString.PadLeft(2, "0") +
                                        "/" + Now.Year.ToString.Substring(2) + " " +
                                        Now.ToLongTimeString.PadLeft(11, " ")

                        strSQL.Append(" Insert into Renaissance_Batch_Job (JOBSCRIPT_FILE,DATE_INSERTED) Values(")

                        If blnJobQueByFile Then
                            strSQL.Append("'").Append("***RUNNING***").Append(strFile.Split("_")(0).ToString).
                                Append("','").Append(RunDateInsert).Append("')")
                        Else
                            strSQL.Append("'").Append("***RUNNING***").Append("','").Append(RunDateInsert).Append(
                                                                                                                       "')")
                        End If
                        SqlHelper.ExecuteNonQuery(Decrypt(ConfigurationManager.AppSettings("SQLConnectionString")),
                                                   CommandType.Text, strSQL.ToString)

                        Return True
                    End If
                End If


                BypassCheck = False

                Return True

            Catch ex As Exception

                ExceptionManager.Publish(ex)

                Throw ex

            End Try

        End Function


        ''' --- EndBatch --------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of StartBatch.
        ''' </summary>
        ''' <param name="strFile"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Overloads Function EndBatch(ByRef strFile As String) As Boolean
            Dim objReader As IDataReader = Nothing
            Dim strSQL As New StringBuilder
            Dim _
                blnJobQueByFile As Boolean =
                    (Not IsNothing(ConfigurationManager.AppSettings("JobQueByFile")) AndAlso
                     ConfigurationManager.AppSettings("JobQueByFile").ToUpper = "TRUE")


            strSQL.Remove(0, strSQL.Length)
            If blnJobQueByFile Then
                strSQL.Append(
                               " SELECT JOBSCRIPT_FILE, convert(varchar, DATE_INSERTED, 22) FROM Renaissance_Batch_Job WHERE Substring (JOBSCRIPT_FILE, 1, ") _
                    .Append(strFile.IndexOf("_"))
                strSQL.Append(") = '").Append(strFile.Substring(0, strFile.IndexOf("_"))).Append(
                                                                                                      "' ORDER BY DATE_INSERTED")
            Else
                strSQL.Append(
                               " SELECT JOBSCRIPT_FILE, convert(varchar, DATE_INSERTED, 22) FROM Renaissance_Batch_Job WHERE JOBSCRIPT_FILE <> '***RUNNING***' ORDER BY DATE_INSERTED")
            End If
            objReader =
                SqlHelper.ExecuteReader(Decrypt(ConfigurationManager.AppSettings("SQLConnectionString")),
                                         CommandType.Text, strSQL.ToString)


            strSQL.Remove(0, strSQL.Length)
            If blnJobQueByFile Then
                strSQL.Append(" DELETE Renaissance_Batch_Job WHERE JOBSCRIPT_FILE = '***RUNNING***").Append(
                                                                                                              strFile.
                                                                                                                 Split(
                                                                                                                        "_")(
                                                                                                                              0) _
                                                                                                                 .
                                                                                                                 ToString) _
                    .Append("' ")
            Else
                strSQL.Append(" DELETE Renaissance_Batch_Job WHERE JOBSCRIPT_FILE = '***RUNNING***' ")
            End If

            strSQL.Append(" AND convert(varchar, DATE_INSERTED, 22) = '").Append(RunDateInsert).Append("'")

            SqlHelper.ExecuteNonQuery(Decrypt(ConfigurationManager.AppSettings("SQLConnectionString")),
                                       CommandType.Text, strSQL.ToString)


            If objReader.Read Then

                strSQL.Remove(0, strSQL.Length)
                strSQL.Append(" DELETE Renaissance_Batch_Job WHERE JOBSCRIPT_FILE = '").Append(objReader(0)).Append(
                                                                                                                        "' AND convert(varchar, DATE_INSERTED, 22) = '") _
                    .Append(objReader(1)).Append("'")

                SqlHelper.ExecuteNonQuery(Decrypt(ConfigurationManager.AppSettings("SQLConnectionString")),
                                           CommandType.Text, strSQL.ToString)

                strFile = objReader(0)
                Return True

            Else

                Return False
            End If
        End Function

#End If

        ''' --- RetrieveUserRoles --------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of RetrieveUserRoles.
        ''' </summary>
        ''' <param name="UserName"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function RetrieveUserRoles(ByVal UserName As String) As String

            Dim objReader As IDataReader = Nothing
            Dim strSQL As New StringBuilder
            Dim sb As StringBuilder = New StringBuilder(String.Empty)

            Try
                strSQL.Append("SELECT ROLE_NAME")
                strSQL.Append(" FROM RENAISSANCE_USER_ROLES")
                strSQL.Append(" WHERE UPPER(User_Name) = '" & UserName.ToUpper & "'")
                strSQL.Append(" ORDER BY ROLE_PRIORITY")

#If TARGET_DB = "INFORMIX" Then
                objReader = InformixHelper.ExecuteReader(GetSystemConnectionString, CommandType.Text, strSQL.ToString)
#Else
                If AuthenticationDatabaseIsOracle Then
                    objReader =
                        OracleHelper.ExecuteReader(GetSystemConnectionString, CommandType.Text, strSQL.ToString)
                Else
                    objReader = SqlHelper.ExecuteReader(GetSystemConnectionString, CommandType.Text, strSQL.ToString)
                End If
#End If

                Do While objReader.Read
                    If sb.Length > 0 Then sb.Append("|")
                    sb.Append(objReader(0).ToString)
                Loop
                objReader.Close()
                objReader.Dispose()

            Catch ex As Exception

                If Not IsNothing(objReader) AndAlso Not objReader.IsClosed Then
                    objReader.Close()
                    objReader.Dispose()

                End If

                ExceptionManager.Publish(ex)

                Throw ex

            End Try
            Return sb.ToString

        End Function

        ''' --- MenuSecurity -------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of MenuSecurity.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function MenuSecurity() As Hashtable

            Dim objReader As IDataReader = Nothing
            Dim strSQL As StringBuilder = New StringBuilder("")
            Dim tmpHash As Hashtable = New Hashtable

            Try

                strSQL.Append("SELECT SECURITY_CLASS FROM RENAISSANCE_SECURITY WHERE USER_NAME = '").Append(
                                                                                                              HttpContext _
                                                                                                                 .
                                                                                                                 Current _
                                                                                                                 .
                                                                                                                 Session(
                                                                                                                          "UserID") _
                                                                                                                 .
                                                                                                                 ToString _
                                                                                                                 .
                                                                                                                 ToUpper) _
                    .Append("'")
#If TARGET_DB = "INFORMIX" Then
                objReader = InformixHelper.ExecuteReader(GetSystemConnectionString, CommandType.Text, strSQL.ToString)
#Else
                If AuthenticationDatabaseIsOracle Then
                    objReader =
                        OracleHelper.ExecuteReader(GetSystemConnectionString, CommandType.Text, strSQL.ToString)
                Else
                    objReader = SqlHelper.ExecuteReader(GetSqlConnectionString, CommandType.Text, strSQL.ToString)
                End If
#End If

                If objReader.Read() Then
                    strSQL = New StringBuilder("")
                    strSQL.Append("SELECT * FROM Renaissance_Screen_Security WHERE ROLE = '").Append(
                                                                                                     objReader.GetString(
                                                                                                                          0)) _
                        .Append("' ")
                    strSQL.Append(" ORDER BY SCREEN")

#If TARGET_DB = "INFORMIX" Then
                    objReader = InformixHelper.ExecuteReader(GetSystemConnectionString, CommandType.Text, strSQL. _
ToString)
#Else
                    If AuthenticationDatabaseIsOracle Then
                        objReader =
                            OracleHelper.ExecuteReader(GetSystemConnectionString, CommandType.Text, strSQL.ToString)
                    Else
                        objReader = SqlHelper.ExecuteReader(GetSqlConnectionString, CommandType.Text, strSQL.ToString)
                    End If
#End If

                    Do While objReader.Read()
                        tmpHash.Add(objReader.GetString(0).Trim,
                                     (objReader.GetValue(2).ToString & objReader.GetValue(3).ToString &
                                      objReader.GetValue(4).ToString & objReader.GetValue(5).ToString))
                        objReader.Read()
                    Loop

                    MenuSecurity = tmpHash
                    objReader.Close()
                    objReader.Dispose()
                End If

            Catch
                MenuSecurity = tmpHash
                objReader.Close()
                objReader.Dispose()
                Exit Function

            End Try

            Return Nothing

        End Function

#If TARGET_DB = "INFORMIX" Then
        ''' --- GetInformixUserPassword -------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetInformixUserPassword.
        ''' </summary>
        ''' <param name="UserName"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Friend Function GetInformixUserPassword(ByVal UserName As String) As String
            If Me.UsesActiveDirectory Then
                Return GetADUserPassword(UserName)
            End If
            Dim objReader As IBM.Data.Informix.IfxDataReader = Nothing
            Dim strPassword As String
            Dim sbSQL As StringBuilder = New StringBuilder(String.Empty)

            Try
                With sbSQL
                    '.Append("Select Get_User_Password('").Append(UserName.ToUpper).Append("') from systables where tabid = 1")
                    .Append("Select Get_User_Password('").Append(UserName).Append("') from systables where tabid = 1")
                    objReader = InformixHelper.ExecuteReader(GetSystemConnectionString, CommandType.Text, .ToString)
                End With
                Dim hasRows As Boolean = objReader.Read()

                If Not hasRows Then
                    Dim ex As New SecurityException("Security Manager Exception. User: " & UserName & _
" does not have access to the database")
                End If
                strPassword = objReader.Item(0).ToString
                objReader.Close()
                Return strPassword.Trim

            Catch ex As Exception

                If Not IsNothing(objReader) AndAlso Not objReader.IsClosed Then
                    objReader.Close()
                End If
                ExceptionManager.Publish(ex)
                Throw ex
            End Try
        End Function
#Else

        ''' --- GetSqlServerUserPassword -------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetSqlServerUserPassword.
        ''' </summary>
        ''' <param name="UserName"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Friend Function GetSqlServerUserPassword(ByVal UserName As String) As String
            If Me.UsesActiveDirectory Then
                Return GetADUserPassword(UserName)
            End If
            Dim objReader As SqlDataReader = Nothing
            Dim strPassword As String
            Dim sbSQL As StringBuilder = New StringBuilder(String.Empty)

            Try
                With sbSQL
                    .Append("DECLARE @RC int").Append(vbNewLine)
                    .Append("DECLARE @UserName varchar(255)").Append(vbNewLine)
                    .Append("DECLARE @ReturnValue varchar(255)").Append(vbNewLine)
                    .Append("SET @UserName = '").Append(UserName.ToUpper).Append("'").Append(vbNewLine)
                    .Append("EXEC @RC = Get_User_Password @UserName, @ReturnValue OUT").Append(vbNewLine)
                    .Append("SELECT @ReturnValue")
                    objReader = SqlHelper.ExecuteReader(GetSystemConnectionString, CommandType.Text, .ToString)
                End With
                objReader.Read()

                If Not objReader.HasRows Then
                    Dim _
                        ex As _
                            New SecurityException(
                                                   "Security Manager Exception. User: " & UserName &
                                                   " does not have access to the database")
                End If
                strPassword = objReader.Item(0).ToString
                objReader.Close()
                Return strPassword.Trim

            Catch ex As Exception

                If Not IsNothing(objReader) AndAlso Not objReader.IsClosed Then
                    objReader.Close()
                End If
                ExceptionManager.Publish(ex)
                Throw ex
            End Try

        End Function

        ''' --- GetUserPassword ----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetUserPassword.
        ''' </summary>
        ''' <param name="UserName"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetUserPassword(ByVal UserName As String) As String
            If Me.UsesActiveDirectory Then
                Return GetADUserPassword(UserName)
            End If
            Dim objReader As OracleDataReader = Nothing
            Dim strPassword As String
            Try
                objReader =
                    OracleHelper.ExecuteReader(GetSystemConnectionString, CommandType.Text,
                                                "select RENAISSANCE_ENCRYPTION.Get_User_Password('" &
                                                UserName.PadRight(8, Convert.ToChar(" ")).ToUpper & "') from dual")
                objReader.Read()

                If Not objReader.HasRows Then
                    Dim _
                        ex As _
                            New SecurityException(
                                                   "Security Manager Exception. User: " & UserName &
                                                   " does not have access to the database")
                End If
                strPassword = objReader.Item(0).ToString
                objReader.Close()
                objReader.Dispose()
                Return strPassword.Trim

            Catch ex As Exception

                If Not IsNothing(objReader) AndAlso Not objReader.IsClosed Then
                    objReader.Close()
                    objReader.Dispose()
                End If
                ExceptionManager.Publish(ex)
                Throw ex
            End Try

        End Function

#End If

        ''' --- GetCurrentUser -----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetCurrentUser.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Shared Function GetCurrentUser() As String

            Try
                Return ApplicationState.Current.CurrentRoles(0).Code
            Catch ex As Exception
                ExceptionManager.Publish(ex)
                Throw ex
            End Try

        End Function

        ''' --- GetCurrentAccount -----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetCurrentAccount.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Shared Function GetCurrentAccount() As String

            Try
                Dim strUserAccount As String
                If HttpContext.Current.Session Is Nothing Then
                    Return String.Empty
                Else
                    strUserAccount = CStr(HttpContext.Current.Session("ProxyUser")) & ""
                End If

                'Checks the Session Variable "UserID" and returns it, or throws a security exception if the user is not present
                If Not ConfigurationManager.AppSettings("UseSignOnAccount") Is Nothing _
                   AndAlso ConfigurationManager.AppSettings("UseSignOnAccount").ToUpper = "TRUE" Then
                    Return strUserAccount
                Else
                    If strUserAccount.Length = 0 Then
                        Return GetCurrentUser()
                    Else
                        Return strUserAccount
                    End If
                End If

            Catch ex As Exception
                ExceptionManager.Publish(ex)
                Throw ex
            End Try

        End Function

        ''' --- GetUserSecurityClass -----------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetUserSecurityClass.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetUserSecurityClass() As String
            Return GetCurrentUser.ToUpper
        End Function

        ''' --- GetUserSecurityClass -----------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetUserSecurityClass.
        ''' </summary>
        ''' <param name="UserName"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetUserSecurityClass(ByVal UserName As String) As String

            Dim objReader As IDataReader = Nothing
            Dim strSQL As String
            Dim strSecurityClass As String = String.Empty
            Dim _
                blSECURITY_ALL_ROLES As Boolean =
                    (ConfigurationManager.AppSettings("SECURITY_ALL_ROLES") + "").ToUpper = "TRUE"

            strSQL = "SELECT SECURITY_CLASS FROM RENAISSANCE_SECURITY WHERE USER_NAME = '" & UserName.ToUpper & "'"
            Try
                If Me.UsesActiveDirectory Then
                    Return GetADUserProxy()
                Else
#If TARGET_DB = "INFORMIX" Then
                    objReader = CType(InformixHelper.ExecuteReader(GetInformixConnectionString(), CommandType.Text, _
strSQL), IDataReader)
#Else
                    If AuthenticationDatabaseIsOracle Then
                        objReader =
                            CType(OracleHelper.ExecuteReader(GetConnectionString(), CommandType.Text, strSQL),
                                IDataReader)
                    Else
                        objReader =
                            CType(SqlHelper.ExecuteReader(GetSqlSecurityConnectionString(), CommandType.Text, strSQL),
                                IDataReader)
                    End If
#End If
                End If

                If Not objReader.Read() Then
                    Dim _
                        ex As _
                            New SecurityException(
                                                   "SecurityManager::GetUserSecurityClass. User: " & UserName &
                                                   " was not found")
                Else
                    strSecurityClass = objReader.Item(0).ToString.Trim
                    If strSecurityClass.ToUpper = "PROXY" Then
                        Dim _
                            ex As _
                                New SecurityException(
                                                       "SecurityManager::GetUserSecurityClass. User: " & UserName &
                                                       " is a Proxy User Account")
                    End If
                End If

                objReader.Close()
                objReader.Dispose()

                Return strSecurityClass

            Catch ex As Exception

                If Not IsNothing(objReader) AndAlso Not objReader.IsClosed Then
                    objReader.Close()
                    objReader.Dispose()
                End If
                ExceptionManager.Publish(ex)
                Throw ex
            End Try

        End Function

#If TARGET_DB = "INFORMIX" Then
        ''' --- GetInformixUserProxy ----------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetInformixUserProxy.
        ''' </summary>
        ''' <param name="UserName"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Friend Function GetInformixUserProxy(ByVal UserName As String) As String
            If Me.UsesActiveDirectory Then
                Return GetADUserProxy()
            End If
            Dim objReader As IBM.Data.Informix.IfxDataReader  = Nothing
            Dim strSQL As String
            Dim strUserName As String = String.Empty

            strSQL = "SELECT SECURITY_CLASS FROM RENAISSANCE_SECURITY WHERE USER_NAME = '" & UserName.ToUpper & "'"
            Try
                objReader = InformixHelper.ExecuteReader(GetSystemConnectionString, CommandType.Text, strSQL)
                dim hasRows as Boolean = objReader.Read()

                If Not hasRows Then
                    Dim ex As New SecurityException("SecurityManager::GetUserProxy. User: " & UserName & _
" was not found")
                Else
                    strUserName = objReader.Item(0).ToString.Trim
                    If strUserName.ToUpper = "PROXY" Then
                        Dim ex As New SecurityException("SecurityManager::GetUserProxy. User: " & UserName & _
" is a Proxy User Account")
                    End If
                End If

                objReader.Close()

                Return strUserName

            Catch ex As Exception

                If Not IsNothing(objReader) AndAlso Not objReader.IsClosed Then
                    objReader.Close()
                End If
                ExceptionManager.Publish(ex)
                Throw ex
            End Try
        End Function
#Else

        ''' --- GetSqlServerUserProxy ----------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetSqlServerUserProxy.
        ''' </summary>
        ''' <param name="UserName"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Friend Function GetSqlServerUserProxy(ByVal UserName As String) As String
            If Me.UsesActiveDirectory Then
                Return GetADUserProxy()
            End If
            Dim objReader As SqlDataReader = Nothing
            Dim strSQL As String
            Dim strUserName As String = String.Empty

            strSQL = "SELECT SECURITY_CLASS FROM RENAISSANCE_SECURITY WHERE USER_NAME = '" & UserName.ToUpper & "'"
            Try
                objReader = SqlHelper.ExecuteReader(GetSystemConnectionString, CommandType.Text, strSQL)
                objReader.Read()

                If Not objReader.HasRows Then
                    Dim _
                        ex As _
                            New SecurityException("SecurityManager::GetUserProxy. User: " & UserName & " was not found")
                Else
                    strUserName = objReader.Item(0).ToString.Trim
                    If strUserName.ToUpper = "PROXY" Then
                        Dim _
                            ex As _
                                New SecurityException(
                                                       "SecurityManager::GetUserProxy. User: " & UserName &
                                                       " is a Proxy User Account")
                    End If
                End If

                objReader.Close()

                Return strUserName

            Catch ex As Exception

                If Not IsNothing(objReader) AndAlso Not objReader.IsClosed Then
                    objReader.Close()
                End If
                ExceptionManager.Publish(ex)
                Throw ex
            End Try

        End Function

        ''' --- GetUserProxy -------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetUserProxy.
        ''' </summary>
        ''' <param name="UserName"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetUserProxy(ByVal UserName As String) As String
            If Me.UsesActiveDirectory Then
                UserName = GetADUserProxy()
            End If

            Dim objReader As OracleDataReader = Nothing
            Dim strSQL As String
            Dim strUserName As String = String.Empty

            strSQL = "SELECT SECURITY_CLASS FROM RENAISSANCE_SECURITY WHERE USER_NAME = '" & UserName.ToUpper & "'"
            Try
                objReader = OracleHelper.ExecuteReader(GetSystemConnectionString, CommandType.Text, strSQL)
                objReader.Read()

                If Not objReader.HasRows Then
                    Dim _
                        ex As _
                            New SecurityException("SecurityManager::GetUserProxy. User: " & UserName & " was not found")
                Else
                    strUserName = objReader.Item(0).ToString.Trim
                    If strUserName.ToUpper = "PROXY" Then
                        Dim _
                            ex As _
                                New SecurityException(
                                                       "SecurityManager::GetUserProxy. User: " & UserName &
                                                       " is a Proxy User Account")
                    End If
                End If

                objReader.Close()
                objReader.Dispose()

                Return strUserName

            Catch ex As Exception

                If Not IsNothing(objReader) AndAlso Not objReader.IsClosed Then
                    objReader.Close()
                    objReader.Dispose()
                End If
                ExceptionManager.Publish(ex)
                Throw ex
            End Try

        End Function

#End If

        ''' --- SetCurrentUser -----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of SetCurrentUser.
        ''' </summary>
        ''' <param name="UserName"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub SetCurrentUser(ByVal UserName As String)
            HttpContext.Current.Session.Add("UserID", UserName.ToUpper)
        End Sub

        ''' --- SetCurrentAccount -----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of SetCurrentUser.
        ''' </summary>
        ''' <param name="Account"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub SetCurrentAccount(ByVal Account As String)
            HttpContext.Current.Session.Add("ProxyUser", Account.ToUpper)
        End Sub


        ''' --- GetSessionID -------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetSessionID.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetSessionID() As String
            'Calls GetSessionID(GetCurrentUser())

            Return HttpContext.Current.Session.SessionID

        End Function

        Friend Function GetADUserProxy() As String
            Return CStr(m_hcContext.Session("ProxyUser"))
        End Function

        Friend Function GetADUserPassword() As String
            Return GetADUserPassword(GetCurrentUser)
        End Function

        Friend Function GetADUserPassword(ByVal UserID As String) As String
            UserID = UserID.ToUpper
            If Me.ProxyUsers.Contains(UserID) Then
                Return (CStr(ProxyUsers.Item(UserID)))
            End If
            Return Nothing
        End Function

        ''' --- ADLogin --------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Login using Active Directory.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Overloads Function ADLogin(ByVal e As WindowsAuthenticationEventArgs) As Boolean
            Try
                Dim strUserName As String
                Dim strGroups As String = String.Empty
                Dim Response As HttpResponse = HttpContext.Current.Response

                strUserName = e.Identity.Name

                'For the specified user, get the roles from Active Directory to create an authentication ticket. 
                If Not IsUserDefinedInAD(strUserName, strGroups) Then
                    Response.Write("Access Denied! Contact your supervisor to access this application.")
                    Response.End()
                End If

                'Attach a new application-defined class that implements IPrincipal to the request.
                'Note that since IIS has already performed authentication, the provided identity is used.
                Dim formsAuthTicket As FormsAuthenticationTicket
                Dim httpcook As HttpCookie
                Dim encryptedTicket As String

                'Check for the existence of the cookie. If it exists then Authentication Ticket has already been created.
                If HttpContext.Current.Request.Cookies("authcookie") Is Nothing Then
                    Response.Write("Logged in User Name:" & strUserName)

                    formsAuthTicket =
                        New FormsAuthenticationTicket(1, strUserName, DateTime.Now, DateTime.Now.AddMinutes(30), False,
                                                       strGroups, "/")

                    'Encrpt the ticket before setting the cookie value
                    encryptedTicket = FormsAuthentication.Encrypt(formsAuthTicket)

                    httpcook = New HttpCookie("authcookie", encryptedTicket)
                    Response.Cookies.Add(httpcook)
                End If
                Response.Redirect(CStr(m_hcContext.Request("SecuredSite")))

            Catch ex As ThreadAbortException

            Catch ex As Exception

                ExceptionManager.Publish(ex)

                Throw ex

            End Try

        End Function

        Private Function IsValidADUser(ByVal UserID As String, ByVal Roles() As String) As Boolean
            If ProxyMappings Is Nothing AndAlso ProxyUsers Is Nothing Then
                Return False
            Else
                Select Case Roles.Length
                    Case 0
                        Return False
                    Case Else
                        'The present implementation allows only one role to be mapped to a specific user
                        '
                        'If there are multiple roles defined in Windows, and more than one role has corresponding Proxy User defined in Proxy Settings,
                        'one of those roles should be mapped in ProxyMappings in ProxyUsers' Settings
                        Dim strProxyUser As String = String.Empty
                        If Me.ProxyMappings.Contains(UserID) Then
                            strProxyUser = CStr(Me.ProxyMappings.Item(UserID))
                        End If
                        If strProxyUser <> "" Then
                            For i As Integer = 1 To ProxyUsers.Count
                                If CStr(ProxyUsers.Item(i)) = strProxyUser Then
                                    For j As Integer = 0 To Roles.Length - 1
                                        If Roles(j) = strProxyUser Then
                                            'Read the preferred Role for a specific user incase User belongs to more than one Role with more than one corresponding Proxy Account.
                                            m_hcContext.Session("UserID") = UserID
                                            m_hcContext.Session("ProxyUser") = strProxyUser
                                            Return True
                                        End If
                                    Next
                                End If
                            Next
                            Return False
                        Else
                            'If MAP element has "User" specified, ProxyUser must be defined in ProxyUser element.
                            'Return False
                            For i As Integer = 1 To ProxyUsers.Count
                                For j As Integer = 0 To Roles.Length - 1
                                    If CStr(ProxyUsers.Item(i)) = Roles(j) Then
                                        m_hcContext.Session("UserID") = UserID
                                        m_hcContext.Session("ProxyUser") = Roles(j)
                                        Return True
                                    End If
                                Next
                            Next
                            Return False
                        End If


                        'Deny access as there is no Proxy User defined for the user
                        Return False
                End Select
            End If
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Preferred Role for a specific user incase a User belongs to more than one Operating System Role with more than one corresponding Database Proxy Account.
        ''' ProxyMappings.config contains a list of Users and Roles that is to be used to map to a Proxy Accounts.
        ''' In ProxySettings.config, a User and its roles can be mapped to a Proxy Account using <MAP&gt; element.
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[mayur]	8/2/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private ReadOnly Property ProxyMappings() As Hashtable
            Get
                If m_htProxyMappings Is Nothing Then
                    LoadProxySettings()
                End If
                Return m_htProxyMappings
            End Get
        End Property

        Private ReadOnly Property ProxyUsers() As Hashtable
            Get
                If m_htProxyUsers Is Nothing Then
                    LoadProxySettings()
                End If
                Return m_htProxyUsers
            End Get
        End Property

        ''' --- LoadProxySettings -----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of LoadProxySettings.
        ''' </summary>
        ''' <param name="ProxySettingsFileName"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub LoadProxySettings(ByVal ProxySettingsFileName As String)
            'Note: Using XmlTextReader, instead of XMLDocument to make the loading faster 
            'At present its not strictly observing the Encoding specifiec in the XML File,
            'XmlTextReader always the default Encoding which is Windows-1252
            If File.Exists(ProxySettingsFileName) Then
                Dim objProxySettingsXML As XmlTextReader
                objProxySettingsXML = New XmlTextReader(ProxySettingsFileName)
                ReadProxySettings(objProxySettingsXML)
                objProxySettingsXML.Close()
                objProxySettingsXML = Nothing
            Else
                'TODO: to be replaced with Exception Code that can display localized error message
                Throw New CustomApplicationException("ProxySettings File Not found!")
            End If
        End Sub

        Private Sub LoadProxySettings()
            'RA Studio is case sensitive while reading "proxyUserSettingsFile"
            LoadProxySettings(ConfigurationManager.AppSettings("proxyUserSettingsFile"))
        End Sub

        ''' --- ReadProxySettings -----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of ReadProxySettings.
        ''' </summary>
        ''' <param name="ProxySettingsXMLReader"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub ReadProxySettings(ByVal ProxySettingsXMLReader As XmlTextReader)
            With ProxySettingsXMLReader
                Dim strID As String
                Dim strPassword As String

                Dim strUser As String = String.Empty
                Dim strProxy As String = String.Empty
                Dim count As Integer = 1

                m_htProxyUsers = New Hashtable
                m_htProxyMappings = New Hashtable

                Do While .Read
                    Select Case .NodeType
                        Case XmlNodeType.Element
                            Select Case .Name.ToUpper
                                Case "PROXYUSER"
                                    strID = String.Empty
                                    strPassword = String.Empty
                                    While .MoveToNextAttribute()
                                        Select Case .Name.ToUpper
                                            Case "ID"
                                                strID = .Value
                                        End Select
                                    End While
                                    m_htProxyUsers.Add(count, strID.ToUpper)
                                    count = count + 1
                                Case "MAP"
                                    strID = String.Empty
                                    strPassword = String.Empty
                                    While .MoveToNextAttribute()
                                        Select Case .Name.ToUpper
                                            Case "USER"
                                                strUser = .Value
                                            Case "PROXY"
                                                strProxy = .Value
                                        End Select
                                    End While
                                    m_htProxyMappings.Add(strUser.ToUpper, strProxy.ToUpper)
                            End Select
                    End Select
                Loop
            End With
        End Sub

        Private Function IsUserDefinedInAD(ByVal UserName As String, ByRef Roles As String) As Boolean
            Dim deRoot As New DirectoryEntry("LDAP://Core2.local")
            Roles = String.Empty

            Dim dsValidator As New DirectorySearcher(deRoot)
            Dim srUserInfo As SearchResult
            Try
                Dim intUserStart As Integer
                intUserStart = UserName.IndexOf("\")
                If intUserStart > 0 Then
                    UserName = UserName.Substring(intUserStart + 1)
                End If
                dsValidator.Filter = "(SAMAccountName=" + UserName + ")"

                srUserInfo = dsValidator.FindOne
                If srUserInfo Is Nothing Then
                    Return False
                End If

                With srUserInfo.GetDirectoryEntry
                    If .Path = "LDAP://Core2.local/CN=mayur patel,CN=Users,DC=Core2,DC=local" Then
                        Debug.WriteLine(.Name)
                        'Update the new path to the user in the directory.
                        Roles = GetGroupsFromAD(.Path, CStr(srUserInfo.Properties("cn").Item(0)))
                    End If
                End With
            Finally
                deRoot.Dispose()
                dsValidator.Dispose()
                srUserInfo = Nothing
            End Try
            Return True
        End Function

        Private Function GetGroupsFromAD(ByVal Path As String, ByVal FilterAttribute As String) As String
            Dim dsFindUser As New DirectorySearcher(Path)
            dsFindUser.Filter = "(cn=" + FilterAttribute + ")"
            dsFindUser.PropertiesToLoad.Add("memberOf")
            Dim groupNames As StringBuilder = New StringBuilder
            Dim srUserInfo As SearchResult

            Try

                srUserInfo = dsFindUser.FindOne()

                Dim propertyCount As Integer = srUserInfo.Properties("memberOf").Count

                Dim dn As String
                Dim equalsIndex, commaIndex As Integer

                For propertyCounter As Integer = 0 To propertyCount - 1

                    dn = CStr(srUserInfo.Properties("memberOf")(propertyCounter))

                    equalsIndex = dn.IndexOf("=", 1)
                    commaIndex = dn.IndexOf(",", 1)
                    If (-1 = equalsIndex) Then
                        Return Nothing
                    End If
                    If propertyCounter > 0 Then
                        groupNames.Append("|")
                    End If
                    groupNames.Append(dn.Substring((equalsIndex + 1), (commaIndex - equalsIndex) - 1))
                Next

            Catch ex As Exception

                Throw New Exception("Error obtaining group names. " + ex.Message)
            Finally
                dsFindUser.Dispose()
                srUserInfo = Nothing
            End Try
            Return groupNames.ToString()
        End Function

        Private Function GetAuthenticationSite() As String
            If m_strAuthenticationSite Is Nothing Then
                m_strAuthenticationSite = CStr(ConfigurationManager.AppSettings("AuthenticationSite"))
                If m_strAuthenticationSite Is Nothing Then
                    m_strAuthenticationSite = String.Empty
                End If
            End If
            Return m_strAuthenticationSite
        End Function

        Public Function UsesActiveDirectory() As Boolean
            Return GetAuthenticationSite.Trim.Length > 0
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' If AuthenticationSite is present in Web.Config's AppSettings, it redirects to that page for user information,
        ''' In absence of AuthenticationSite, it will continue processing Default.aspx and prompt for the User Name and Password
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[mayur]	7/29/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function EnsureLogin() As Boolean
            With m_hcContext
                Dim hcAuthCookie As HttpCookie
                Dim fatAuthTicket As FormsAuthenticationTicket
                Dim blnAuthenticationRequired As Boolean
                Dim strUserInfo As String = String.Empty
                Dim strUserName As String
                Dim strUserRoles() As String
                Dim strStartPage As String

                If GetCurrentUser().Equals(String.Empty) Then
                    hcAuthCookie = .Request.Cookies("authcookie")
                    If hcAuthCookie Is Nothing Then
                        If .Request.Path.ToLower.EndsWith("default.aspx") Then
                            If UsesActiveDirectory() Then
                                blnAuthenticationRequired = True
                            Else
                                'Prompt for User Name and Password
                            End If
                        Else
                            'Either Redirect to the Default.aspx or Logged-off page
                            Login()
                        End If
                    Else
                        'Get the user information
                        .Request.Cookies.Remove("authcookie")
                        strUserInfo = hcAuthCookie.Value
                        .Session("UserInfo") = strUserInfo
                    End If
                Else
                    strUserInfo = CStr(.Session("UserInfo"))
                End If

                If blnAuthenticationRequired Then
                    m_hcContext.Response.Redirect(GetAuthenticationSite() + "?SecuredSite=" + .Request.Path)
                Else
                    If (Not strUserInfo Is Nothing) AndAlso strUserInfo.Length > 0 Then
                        strStartPage = ConfigurationManager.AppSettings("Screen")
                        If strStartPage Is Nothing OrElse strStartPage.Trim.Length = 0 Then
                            'Error???? or strStartPage = "Default.aspx"
                        End If

                        fatAuthTicket = FormsAuthentication.Decrypt(strUserInfo)
                        strUserName = fatAuthTicket.Name.ToUpper
                        strUserRoles = fatAuthTicket.UserData.ToUpper.Split("|"c)

                        If Not IsValidADUser(strUserName, strUserRoles) Then
                            .Session("") = Nothing
                            .Response.Clear()
                            .Response.Write("<H1>To access this application, please contact your supervisor.</H1>")
                            .Response.End()
                        End If

                        If Not strStartPage Is Nothing AndAlso strStartPage.Length > 0 Then
                            .Response.Redirect(strStartPage)
                        End If
                    End If
                End If
            End With

        End Function
    End Class
End Namespace