Imports System.ComponentModel
Imports System.Configuration
Imports System.Runtime.Remoting
Imports System.Web

Namespace Core.Windows.UI
    ''' -----------------------------------------------------------------------------
    ''' Project	 : Core.Web.UI
    ''' Class	 : Web.UI.SessionInformation
    ''' 
    ''' -----------------------------------------------------------------------------
    ''' <exclude />
    ''' <summary>
    '''     SessionInformation is a wrapper function to communicate with the SessionManager
    '''     Service.
    ''' </summary>
    ''' <remarks>
    '''     Typically used in Web Farm to track the Session Information.At present web
    '''     form that inherits from Core.Web.UI.Page can access the session information
    '''     from Session Manager Service.
    ''' </remarks>
    ''' <history>
    '''     [mayur]	3/29/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <EditorBrowsable(EditorBrowsableState.Advanced)>
    Public Class SessionInformation
        Private Shared m_triHasSessionManager As TriState = TriState.UseDefault
        ' m_blnHasSessionManager is used as flag for availability of SessionManager
        Private Shared ReadOnly m_smSessionManager As SessionManager = SessionManager()
        ' m_smSessionManager is used to access the Session Information

        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Shared Function ListSessionvariabls(SessionID As String, UniqueSessionID As String) As String
            Try
                If HasSessionManager Then
                    Return m_smSessionManager.ListSessionVariables(UniqueSessionID + SessionID) & ""
                End If
                Return ""
            Catch ex As Exception
            End Try
            Return ""
        End Function

        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Shared Function ListSessionvariabls() As String
            Try
                If HasSessionManager Then
                    Return m_smSessionManager.ListSessionVariables() & ""
                End If
                Return ""
            Catch ex As Exception
            End Try
            Return ""
        End Function

        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Shared Sub SetSession(key As String, value As Object, SessionID As String)
            Try
                If HasSessionManager Then
                    m_smSessionManager.SetSession(SessionID, key, value)
                End If
            Catch ex As Exception
            End Try
        End Sub

        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Shared Function GetSession(key As String, SessionID As String) As Object
            Try
                If HasSessionManager Then
                    Return m_smSessionManager.GetSession(SessionID, key)
                End If
            Catch ex As Exception
                Return Nothing
            End Try

            Return Nothing
        End Function

        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Shared Sub Remove(key As String, SessionID As String)
            Try
                If HasSessionManager Then
                    m_smSessionManager.RemoveSession(SessionID, key)
                End If
            Catch ex As Exception
            End Try
        End Sub

       

        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Shared Sub SetApplicationSession(key As String, value As Object)
            Try
                If HasSessionManager Then
                    m_smSessionManager.SetApplicationSession(key, value)
                End If
            Catch ex As Exception
            End Try
        End Sub

       

        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Shared Function GetApplicationSession(key As String) As Object
            Try
                If HasSessionManager Then
                    Return m_smSessionManager.GetApplicationSession(key)
                End If
            Catch ex As Exception
            End Try

            Return Nothing
        End Function

      

        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Shared Sub RemoveApplication(key As String )
            Try
                If HasSessionManager Then
                    m_smSessionManager.RemoveApplicationSession(key)
                End If
            Catch ex As Exception
            End Try
        End Sub

        ''' --- GetSystemVal -------------------------------------------------------
        ''' <summary>
        '''     Retrieves values defined at the operating system level.
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <param name="TypeCode"></param>
        ''' <remarks>
        '''     <example>
        '''         GetSystemVal("PARAMS") <br />
        '''         GetSystemVal("QUIZ_PARAMS", "0002", "LNM$JOB") Returns "ALL"
        '''     </example>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Shared Function GetSystemVal(Name As String, TypeCode As String,
                                            strSessionID As String) As String

            Dim strValue As String = Nothing

            If TypeCode = "" Then
                strValue = GetSession(Name + "0001", strSessionID)
                If IsNothing(strValue) Then
                    strValue = GetApplicationSession(Name + "0002")
                End If
                If IsNothing(strValue) Then
                    strValue = GetApplicationSession(Name + "0003")
                End If
            Else
                Select Case TypeCode
                    Case "0001"
                        If strSessionID = "" Then
                            strValue = GetSession(Name + TypeCode, strSessionID)
                        Else
                            strValue = GetSession(Name + TypeCode, strSessionID)
                        End If
                    Case "0002", "0003"
                        strValue = GetApplicationSession(Name + TypeCode)
                End Select

            End If

            If IsNothing(strValue) Then strValue = String.Empty
            Return strValue
        End Function

        ''' --- SetSystemVal -------------------------------------------------------
        ''' <summary>
        '''     Assigns values at the operating system level.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the systemval.</param>
        ''' <param name="Value">A String containing the value to be assigned to the systemval.</param>
        ''' <param name="Type">A String indicating the type of systemval.</param>
        ''' <remarks>
        '''     <example>
        '''         SetSystemVal("PARAMS", T_TEMP.Value) <br />
        '''         SetSystemValue("QUIZ_PARAMS", "ALL", "0001", "LNM$JOB") returns TRUE or FALSE.
        '''     </example>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Shared Function SetSystemVal(Name As String,
                                            Value As String,
                                            Type As String,
                                            strSessionID As String) As Boolean

            If Type = "0001" Then
                If strSessionID = "" Then
                    SetSession(Name + Type, Value, strSessionID)
                Else
                    SetSession(Name + Type, Value, strSessionID)
                End If
            Else
                SetApplicationSession(Name + Type, Value)
            End If

            Return True
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     OpenSshShellConnection used to set the Last Access Time for the current session.
        ''' </summary>
        ''' <remarks>
        '''     Opens a connection to the SSH component.
        ''' </remarks>
        ''' <history>
        '''     [mayur]	3/23/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Shared Function OpenSshConnection(HostName As String, UserName As String,
                                                 Password As String) As Boolean
            If HasSessionManager Then
#If SSH Then
               Return m_smSessionManager.OpenSshShellConnection(HttpContext.Current.Session.SessionID, HostName,
UserName, _
                                                           Password)
#End If

            End If
            Return False
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     OpenSshShellConnection used to set the Last Access Time for the current session.
        ''' </summary>
        ''' <remarks>
        '''     Opens a connection to the SSH component.
        ''' </remarks>
        ''' <history>
        '''     [mayur]	3/23/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Shared Function OpenSshConnection(HostName As String, UserName As String,
                                                 Password As String, Command As String) As Boolean
            If HasSessionManager Then
#If SSH Then
                Return _
                    m_smSessionManager.OpenSshShellConnection(HttpContext.Current.Session.SessionID, HostName, UserName, _
                                                               Password, Command)
#End If
            End If
            Return False
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     CloseSshShellConnection used to set the Last Access Time for the current session.
        ''' </summary>
        ''' <remarks>
        '''     Close a connection to the SSH component.
        ''' </remarks>
        ''' <history>
        '''     [mayur]	3/23/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Shared Function CloseSshConnection() As Boolean
            If Not ConfigurationManager.AppSettings("SshUseLoggedOnUser") Is Nothing Then
                If HasSessionManager Then
#If SSH Then
                    Return m_smSessionManager.CloseSshShellConnection(HttpContext.Current.Session.SessionID)
#End If
                End If
                Return False
            Else
                Return True
            End If
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     CloseSshShellConnection used to set the Last Access Time for the current session.
        ''' </summary>
        ''' <remarks>
        '''     Close a connection to the SSH component.
        ''' </remarks>
        ''' <history>
        '''     [mayur]	3/23/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Shared Function CloseSshConnection(SessionID As String) As Boolean
            If Not ConfigurationManager.AppSettings("SshUseLoggedOnUser") Is Nothing Then
                If HasSessionManager Then
#If SSH Then
                    Return m_smSessionManager.CloseSshShellConnection(SessionID)
#End If
                End If
                Return False
            Else
                Return True
            End If
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Runs a command using the SSH Shell object.
        ''' </summary>
        ''' <remarks>
        '''     Opens a connection to the SSH component.
        ''' </remarks>
        ''' <history>
        '''     [mayur]	3/23/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Shared Function RunSshCommand(Command As String) As String
            If HasSessionManager Then
#If SSH Then
                Return m_smSessionManager.RunSshShellCommand(HttpContext.Current.Session.SessionID, Command)
#End If
            End If
            Return ""
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Runs a command using the SSH Shell object.
        ''' </summary>
        ''' <remarks>
        '''     Opens a connection to the SSH component.
        ''' </remarks>
        ''' <history>
        '''     [mayur]	3/23/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Shared Function RunCommandAmxw(Command As String) As String
            If HasSessionManager Then
#If SSH Then
                Return _
                    m_smSessionManager.RunCommandAmxw(HttpContext.Current.Session.SessionID, Command, _
                                                       ConfigurationManager.AppSettings("SharedDrive"))
#End If
            End If
            Return ""
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Builds a temporary file on SSH server.
        ''' </summary>
        ''' <remarks>
        '''     Opens a connection to the SSH component.
        ''' </remarks>
        ''' <history>
        '''     [mayur]	3/23/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Shared Function BuildTemporaryFile(Command As String) As Boolean
            If HasSessionManager Then
#If SSH Then
                Return m_smSessionManager.BuildTemporaryFile(HttpContext.Current.Session.SessionID, Command)
#End If
            End If
            Return False
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Gets a systemval value from the SSH server.
        ''' </summary>
        ''' <remarks>
        '''     Opens a connection to the SSH component.
        ''' </remarks>
        ''' <history>
        '''     [mayur]	3/23/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Shared Function GetSystemValAmxw(Command As String) As String
            If HasSessionManager Then
                Dim returnValue As String
#If SSH Then
                returnValue = m_smSessionManager.GetSystemValAmxw(HttpContext.Current.Session.SessionID, Command, _
                                                             ConfigurationManager.AppSettings("SharedDrive"))
#End If

                returnValue = returnValue.Trim
                Dim variable As String = Command.Substring(8)
                If Command.ToUpper.StartsWith("SHOWVAR ") AndAlso returnValue.TrimStart.StartsWith(variable & " = ") _
                    Then
                    returnValue = returnValue.Substring(variable.Length).Trim
                    If returnValue.StartsWith("=") Then
                        returnValue = returnValue.Substring(1).Trim
                    End If
                End If
                Return returnValue
            End If
            Return ""
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Sets a systemval value from the SSH server.
        ''' </summary>
        ''' <remarks>
        '''     Opens a connection to the SSH component.
        ''' </remarks>
        ''' <history>
        '''     [mayur]	3/23/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Shared Function SetSystemValAmxw(Command As String) As Boolean
            If HasSessionManager Then
#If SSH Then
                Return m_smSessionManager.SetSystemValAmxw(HttpContext.Current.Session.SessionID, Command)
#End If
            End If
            Return False
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Puts a file on the SSH server.
        ''' </summary>
        ''' <remarks>
        '''     Opens a connection to the SSH component.
        ''' </remarks>
        ''' <history>
        '''     [mayur]	3/23/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Shared Function PutFileOnAmxw(Command As String, RecordLength As Integer) As Boolean
            If HasSessionManager Then
#If SSH Then
                Return m_smSessionManager.PutFileOnAmxw(HttpContext.Current.Session.SessionID, Command, RecordLength)
#End If
            End If
            Return False
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Creates a file on the SSH server.
        ''' </summary>
        ''' <remarks>
        '''     Opens a connection to the SSH component.
        ''' </remarks>
        ''' <history>
        '''     [mayur]	3/23/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Shared Function CreateFileOnAmxw(Command As String) As Boolean
            If HasSessionManager Then
#If SSH Then
                Return m_smSessionManager.CreateFileOnAmxw(HttpContext.Current.Session.SessionID, Command)
#End If
            End If
            Return False
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     UpdateSessionAccessTime used to set the Last Access Time for the current session.
        ''' </summary>
        ''' <remarks>
        '''     At present Page's Load Event Handler in Portal.aspx in a particular Web App registers
        '''     the current Session for the first time. Later Page's Load event updates the Last Access Time.
        ''' </remarks>
        ''' <history>
        '''     [mayur]	3/23/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Shared Function UpdateSessionAccessTime(UniqueSessionID As String) As Boolean
            If HasSessionManager Then
                If Not m_smSessionManager.UpdateSessionAccessTime(HttpContext.Current.Session.SessionID) Then
                    m_smSessionManager.Add(UniqueSessionID + HttpContext.Current.Session.SessionID,
                                           CStr(HttpContext.Current.Session("UserID")))
                End If
                UpdateSessionAccessTime = True
            End If
        End Function

        ''' ------------------------------------------------------------------------
        ''' <exclude />
        ''' <history>
        '''     [Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Shared Function HasSession(UniqueSessionID As String) As Boolean
            If HasSessionManager Then
                HasSession = m_smSessionManager.HasSession(UniqueSessionID + HttpContext.Current.Session.SessionID)
            End If
        End Function

        ''' ------------------------------------------------------------------------
        ''' <exclude />
        ''' <history>
        '''     [Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        ''' ------------------------------------------------------------------------
        ''' <exclude />
        ''' <history>
        '''     [Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        '<EditorBrowsable(EditorBrowsableState.Advanced)> _
        'Public Shared Function IsSessionActive(ByVal UniqueSessionID As String) As Boolean
        '    If HasSessionManager Then
        '        IsSessionActive = m_smSessionManager.IsActive(UniqueSessionID + HttpContext.Current.Session.SessionID)
        '    End If
        'End Function


        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Shared Function IsSessionActive(SessionID As String, UniqueSessionID As String) As Boolean
            If HasSessionManager Then
                IsSessionActive = m_smSessionManager.IsActive(UniqueSessionID + SessionID)
            End If
        End Function

        ''' ------------------------------------------------------------------------
        ''' <exclude />
        ''' <history>
        '''     [Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Shared Function RemoveSession(SessionID As String, UniqueSessionID As String) As Boolean
            If HasSessionManager Then
                CloseSshConnection(SessionID)
                RemoveSession = m_smSessionManager.Remove(UniqueSessionID + SessionID)
            End If
        End Function

        ''' ------------------------------------------------------------------------
        ''' <exclude />
        ''' <history>
        '''     [Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Shared ReadOnly Property HasSessionManager As Boolean
            Get
                If m_triHasSessionManager = TriState.UseDefault Then
                    SessionManager()
                End If
                Return m_triHasSessionManager = TriState.True
            End Get
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     GetSessionInformation returns the Session Information for the passed NumberedSessionID.
        ''' </summary>
        ''' <param name="SessionID">SessionID is string (usually a GUID).</param>
        ''' <param name="UserID">If passed SessionID found, it returns UserID of the user.</param>
        ''' <param name="StartTime">
        '''     If passed SessionID found, it returns date and time when the session is enlisted in Session
        '''     Manager Service.
        ''' </param>
        ''' <param name="LastAccessTime">
        '''     If passed SessionID found, it returns most recent Time(rather DateTime) when the session
        '''     is accessed.
        ''' </param>
        ''' <param name="IsActive">
        '''     If passed SessionID found, it whether a session is active or not, based on LastAccessTime and
        '''     TimeOut as specified in App.config of Session Manager Service.
        ''' </param>
        ''' <param name="NumberedSessionID">If passed SessionID found, return an integer representing an ID for the session.</param>
        ''' <returns>
        '''     True if session information is found (regardless whether session is still
        '''     active or not) in Session Manager Service, otherwise returns False.
        ''' </returns>
        ''' <remarks>
        '''     To check whether Session is active or not one should check IsActive rather than Return Value.
        ''' </remarks>
        ''' <history>
        '''     [mayur]	3/30/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Shared Function GetSessionInformation(SessionID As String, ByRef UserID As String,
                                                     ByRef StartTime As Date, ByRef LastAccessTime As Date,
                                                     ByRef IsActive As Boolean, ByRef NumberedSessionID As Int64,
                                                     UniqueSessionID As String) _
            As Boolean
            If HasSessionManager Then
                GetSessionInformation =
                    m_smSessionManager.GetSessionInformation(UniqueSessionID + SessionID, UserID, StartTime,
                                                             LastAccessTime, IsActive,
                                                             NumberedSessionID)
            End If
        End Function

        ''' ------------------------------------------------------------------------
        ''' <exclude />
        ''' <history>
        '''     [Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Shared Function GetSessionInformation(SessionID As String, ByRef UserID As String,
                                                     ByRef StartTime As Date, ByRef LastAccessTime As Date,
                                                     ByRef IsActive As Boolean, ByRef NumberedSessionID As Int32,
                                                     UniqueSessionID As String) _
            As Boolean
            Dim int64NumberedSessionID As Int64
            int64NumberedSessionID = NumberedSessionID
            GetSessionInformation =
                GetSessionInformation(SessionID, UserID, StartTime, LastAccessTime, IsActive, int64NumberedSessionID,
                                      UniqueSessionID)
            NumberedSessionID = CInt(int64NumberedSessionID)
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     GetSessionInformation returns the Session Information for the passed NumberedSessionID.
        ''' </summary>
        ''' <param name="NumberedSessionID">An integer representing an ID for the session.</param>
        ''' <param name="UserID">If passed NumberedSessionID found, it returns UserID of the user.</param>
        ''' <param name="StartTime">
        '''     If passed NumberedSessionID found, it returns date and time when the session is enlisted in
        '''     Session Manager Service.
        ''' </param>
        ''' <param name="LastAccessTime">
        '''     If passed NumberedSessionID found, it returns most recent Time(rather DateTime) when the
        '''     session is accessed.
        ''' </param>
        ''' <param name="IsActive">
        '''     If passed NumberedSessionID found, it whether a session is active or not, based on
        '''     LastAccessTime and TimeOut as specified in App.config of Session Manager Service.
        ''' </param>
        ''' <param name="SessionID">If passed NumberedSessionID found, returns corresponding string of SessionID.</param>
        ''' <returns>
        '''     True if session information is found (regardless whether session is still
        '''     active or not) in Session Manager Service, otherwise returns False.
        ''' </returns>
        ''' <remarks>
        '''     To check whether Session is active or not one should check IsActive rather than Return Value.
        ''' </remarks>
        ''' <history>
        '''     [mayur]	3/30/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Shared Function GetSessionInformation(NumberedSessionID As Int64, ByRef UserID As String,
                                                     ByRef StartTime As Date, ByRef LastAccessTime As Date,
                                                     ByRef IsActive As Boolean, ByRef SessionID As String,
                                                     UniqueSessionID As String) As Boolean
            If HasSessionManager Then
                GetSessionInformation =
                    m_smSessionManager.GetSessionInformation(NumberedSessionID, UserID, StartTime, LastAccessTime,
                                                             IsActive, SessionID + UniqueSessionID)
            End If
        End Function

        ''' ------------------------------------------------------------------------
        ''' <exclude />
        ''' <history>
        '''     [Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Shared Function GetSessionInformation(SessionID As String, UniqueSessionID As String) As UserSessionInfo
            Dim strUserID As String = String.Empty
            Dim dtStartDate As Date
            Dim dtLastAccessTime As Date
            Dim intNumberedSessionID As Int64
            Dim blnIsActive As Boolean
            Dim usiUserSessionInfo As New UserSessionInfo

            GetSessionInformation(SessionID, strUserID, dtStartDate, dtLastAccessTime, blnIsActive,
                                  intNumberedSessionID, UniqueSessionID)
            With usiUserSessionInfo
                .SessionID = SessionID
                .UserID = strUserID
                .StartTime = dtStartDate
                .LastAccessTime = dtLastAccessTime
                .IsActive = blnIsActive
                .NumberedSessionID = intNumberedSessionID
            End With
            Return Nothing
        End Function

        ''' ------------------------------------------------------------------------
        ''' <exclude />
        ''' <history>
        '''     [Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Shared Function GetSessionInformation(NumberedSessionID As Int64, UniqueSessionID As String) _
            As UserSessionInfo
            Dim strUserID As String = String.Empty
            Dim dtStartDate As Date
            Dim dtLastAccessTime As Date
            Dim strSessionID As String = String.Empty
            Dim blnIsActive As Boolean
            Dim usiUserSessionInfo As New UserSessionInfo

            GetSessionInformation(NumberedSessionID, strUserID, dtStartDate, dtLastAccessTime, blnIsActive,
                                  strSessionID, UniqueSessionID)
            With usiUserSessionInfo
                .SessionID = strSessionID
                .UserID = strUserID
                .StartTime = dtStartDate
                .LastAccessTime = dtLastAccessTime
                .IsActive = blnIsActive
                .NumberedSessionID = NumberedSessionID
            End With
            Return Nothing
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     SessionManager is an internal function and should not be exposed outside
        '''     this page Computer running "SessionManager" can be defined in Web.Config
        '''     (e.g. <add key="SessionManager" value="CORE-W-107:15124" />)
        '''     Typically can be used in Web Farm scenerio to track the active Sessions.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [mayur]	3/24/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Shared Function SessionManager() As SessionManager
            Select Case m_triHasSessionManager
                Case TriState.True
                    Return m_smSessionManager
                Case TriState.False
                    Return Nothing
                Case TriState.UseDefault
                    Dim strSessionManagerMachine As String
                    strSessionManagerMachine = ConfigurationManager.AppSettings("SessionManager")
                    If strSessionManagerMachine Is Nothing Then
                        m_triHasSessionManager = TriState.False
                        'No Session Manager Defined
                    Else
                        If strSessionManagerMachine.IndexOf("://") > 0 Then
                            strSessionManagerMachine += "/CoreSessionManager/CoreSessionManagerSingleton.rem"
                        Else
                            strSessionManagerMachine = "tcp://" + strSessionManagerMachine +
                                                       "/CoreSessionManager/CoreSessionManagerSingleton.rem"
                        End If
                        Dim re As WellKnownClientTypeEntry
                        re = RemotingConfiguration.IsWellKnownClientType(GetType(SessionManager))
                        If re Is Nothing Then
                            RemotingConfiguration.RegisterWellKnownClientType(GetType(SessionManager),
                                                                              strSessionManagerMachine)
                        End If
                        re = Nothing

                        m_triHasSessionManager = TriState.True
                        Return New SessionManager
                    End If
            End Select
            Return Nothing
        End Function
    End Class

    ''' ------------------------------------------------------------------------
    ''' <exclude />
    ''' <history>
    '''     [Campbell]	6/22/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(EditorBrowsableState.Advanced)>
    Public Structure UserSessionInfo
        ''' ------------------------------------------------------------------------
        ''' <exclude />
        ''' <history>
        '''     [Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Public SessionID As String

        ''' ------------------------------------------------------------------------
        ''' <exclude />
        ''' <history>
        '''     [Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Public UserID As String

        ''' ------------------------------------------------------------------------
        ''' <exclude />
        ''' <history>
        '''     [Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Public StartTime As Date

        ''' ------------------------------------------------------------------------
        ''' <exclude />
        ''' <history>
        '''     [Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Public LastAccessTime As Date

        ''' ------------------------------------------------------------------------
        ''' <exclude />
        ''' <history>
        '''     [Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Public NumberedSessionID As Int32

        ''' ------------------------------------------------------------------------
        ''' <exclude />
        ''' <history>
        '''     [Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Public IsActive As Boolean
    End Structure
End Namespace