
Imports Core.SessionManager

Imports System.ComponentModel
Imports System.Configuration
Imports System.Configuration.ConfigurationSettings
Imports System.Runtime.Remoting
Imports System.Web.HttpContext

Namespace Core.ReportFramework

    ''' -----------------------------------------------------------------------------
    ''' Project	 : Core.Web.UI
    ''' Class	 : Web.UI.SessionInformation
    ''' 
    ''' -----------------------------------------------------------------------------
    ''' <exclude/>
    '''     
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
    ''' 	[mayur]	3/29/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
    Public Class SessionInfo

        Public Shared m_triHasSessionManager As TriState = TriState.UseDefault                     ' m_blnHasSessionManager is used as flag for availability of SessionManager
        Private Shared m_smSessionManager As Global.Core.SessionManager           ' m_smSessionManager is used to access the Session Information
        Public Shared m_strReportConfigSessionManager As String = String.Empty

        Public Sub New(ByVal state As TriState, ByVal strLocation As String)

            m_triHasSessionManager = state
            m_strReportConfigSessionManager = strLocation

            m_smSessionManager = SessionManager()

        End Sub

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Shared Sub SetSession(ByVal key As String, ByVal value As Object, ByVal SessionID As String)
            Try
                If HasSessionManager Then
                    m_smSessionManager.SetSession(SessionID, key, value)
                End If
            Catch ex As Exception
            End Try

        End Sub

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Shared Sub SetSession(ByVal key As String, ByVal value As Object)
            Try
                If HasSessionManager Then
                    m_smSessionManager.SetSession(CStr(Current.Session.SessionID), key, value)
                End If
            Catch ex As Exception
            End Try

        End Sub

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Shared Function GetSession(ByVal key As String, ByVal SessionID As String) As Object
            Try
                If HasSessionManager Then
                    If DebugReport Then
                        rptLog.WriteToLogFile("GetSession: " + key)
                        rptLog.WriteToLogFile("Session ID: " + SessionID)
                    End If
                    Return m_smSessionManager.GetSession(SessionID, key)
                End If
            Catch ex As Exception
                If DebugReport Then
                    rptLog.WriteToLogFile("Error: GetSession - " + ex.Message)
                End If
            End Try

            Return Nothing
        End Function

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Shared Function GetSession(ByVal key As String) As Object
            Try
                If HasSessionManager Then
                    If DebugReport Then
                        rptLog.WriteToLogFile("GetSession: " + key)
                        rptLog.WriteToLogFile("Current SessionID: " + CStr(Current.Session.SessionID))
                    End If

                    Return m_smSessionManager.GetSession(CStr(Current.Session.SessionID), key)
                End If

            Catch ex As Exception
                If DebugReport Then
                    rptLog.WriteToLogFile("Error: GetSession - " + ex.Message)
                End If
            End Try

            Return Nothing
        End Function

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Shared Sub Remove(ByVal key As String, ByVal SessionID As String)
            Try
                If HasSessionManager Then
                    m_smSessionManager.RemoveSession(SessionID, key)
                End If
            Catch ex As Exception
            End Try

        End Sub

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Shared Sub Remove(ByVal key As String)
            Try
                If HasSessionManager Then
                    m_smSessionManager.RemoveSession(CStr(Current.Session.SessionID), key)
                End If
            Catch ex As Exception
            End Try

        End Sub

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Shared Sub SetApplicationSession(ByVal key As String, ByVal value As Object)
            Try
                If HasSessionManager Then
                    m_smSessionManager.SetApplicationSession(key, value)
                End If
            Catch ex As Exception
            End Try

        End Sub

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Shared Function GetApplicationSession(ByVal key As String) As Object
            Try
                If HasSessionManager Then
                    If DebugReport Then
                        rptLog.WriteToLogFile("GetApplicationSession: " + key)
                    End If

                    Return m_smSessionManager.GetApplicationSession(key)
                End If
            Catch ex As Exception
            End Try

            Return Nothing
        End Function

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Shared Sub RemoveApplication(ByVal key As String)
            Try
                If HasSessionManager Then
                    m_smSessionManager.RemoveApplicationSession(key)
                End If
            Catch ex As Exception
            End Try

        End Sub

        ''' --- GetSystemVal -------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Retrieves values defined at the operating system level.
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <param name="TypeCode"></param>
        ''' <remarks>
        ''' <example>GetSystemVal("PARAMS") <br/>
        ''' GetSystemVal("QUIZ_PARAMS", "0002", "LNM$JOB") Returns "ALL"</example>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Shared Function GetSystemVal(ByVal Name As String, Optional ByVal TypeCode As String = "", Optional ByVal strSessionID As String = "") As String

            Dim strValue As String = Nothing

            If TypeCode = "" Then
                strValue = GetSession(Name + "0001")
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
                            strValue = GetSession(Name + TypeCode)
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
        ''' 
        ''' <summary>
        ''' 	Assigns values at the operating system level.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the systemval.</param>
        ''' <param name="Value">A String containing the value to be assigned to the systemval.</param>
        ''' <param name="Type">A String indicating the type of systemval.</param>
        ''' <remarks>
        ''' <example>SetSystemVal("PARAMS", T_TEMP.Value) <br/>
        ''' SetSystemValue("QUIZ_PARAMS", "ALL", "0001", "LNM$JOB") returns TRUE or FALSE.</example>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Shared Function SetSystemVal(ByVal Name As String, ByVal Value As String, Optional ByVal Type As String = "0001", Optional ByVal strSessionID As String = "") As Boolean

            If Type = "0001" Then
                If strSessionID = "" Then
                    SetSession(Name + Type, Value)
                Else
                    SetSession(Name + Type, Value, strSessionID)
                End If
            Else
                SetApplicationSession(Name + Type, Value)
            End If

            Return True

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        '''     UpdateSessionAccessTime used to set the Last Access Time for the current session.
        ''' </summary>
        ''' <remarks>
        '''     At present Page's Load Event Handler in Portal.aspx in a particular Web App registers
        '''     the current Session for the first time. Later Page's Load event updates the Last Access Time.
        ''' </remarks>
        ''' <history>
        ''' 	[mayur]	3/23/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Shared Function UpdateSessionAccessTime() As Boolean
            If HasSessionManager Then
                If Not m_smSessionManager.UpdateSessionAccessTime(Current.Session.SessionID) Then
                    m_smSessionManager.Add(Current.Session.SessionID, CStr(Current.Session("UserID")))
                End If
                UpdateSessionAccessTime = True
            End If
        End Function

        ''' ------------------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Shared Function HasSession() As Boolean
            If HasSessionManager Then
                HasSession = m_smSessionManager.HasSession(Current.Session.SessionID)
            End If
        End Function

        ''' ------------------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Shared Function IsSessionActive() As Boolean
            If HasSessionManager Then
                IsSessionActive = m_smSessionManager.IsActive(Current.Session.SessionID)
            End If
        End Function

        ''' ------------------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Shared Function IsSessionActive(ByVal SessionID As String) As Boolean
            If HasSessionManager Then
                IsSessionActive = m_smSessionManager.IsActive(SessionID)
            End If
        End Function

        ''' ------------------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Shared Function RemoveSession(ByVal SessionID As String) As Boolean
            If HasSessionManager Then
                RemoveSession = m_smSessionManager.Remove(SessionID)
            End If
        End Function

        ''' ------------------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Private Shared ReadOnly Property HasSessionManager() As Boolean
            Get
                If m_triHasSessionManager = TriState.UseDefault Then
                    SessionManager()
                End If

                Return m_triHasSessionManager = TriState.True
            End Get

        End Property

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        '''     GetSessionInformation returns the Session Information for the passed NumberedSessionID.
        ''' </summary>
        ''' <param name="SessionID">SessionID is string (usually a GUID).</param>
        ''' <param name="UserID">If passed SessionID found, it returns UserID of the user.</param>
        ''' <param name="StartTime">If passed SessionID found, it returns date and time when the session is enlisted in Session Manager Service.</param>
        ''' <param name="LastAccessTime">If passed SessionID found, it returns most recent Time(rather DateTime) when the session is accessed.</param>
        ''' <param name="IsActive">If passed SessionID found, it whether a session is active or not, based on LastAccessTime and TimeOut as specified in App.config of Session Manager Service.</param>
        ''' <param name="NumberedSessionID">If passed SessionID found, return an integer representing an ID for the session.</param>
        ''' <returns>
        '''     True if session information is found (regardless whether session is still 
        '''     active or not) in Session Manager Service, otherwise returns False.
        ''' </returns>
        ''' <remarks>
        '''     To check whether Session is active or not one should check IsActive rather than Return Value. 
        ''' </remarks>
        ''' <history>
        ''' 	[mayur]	3/30/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Shared Function GetSessionInformation(ByVal SessionID As String, ByRef UserID As String, ByRef StartTime As Date, ByRef LastAccessTime As Date, ByRef IsActive As Boolean, ByRef NumberedSessionID As Int64) As Boolean
            If HasSessionManager Then
                GetSessionInformation = m_smSessionManager.GetSessionInformation(SessionID, UserID, StartTime, LastAccessTime, IsActive, NumberedSessionID)
            End If
        End Function

        ''' ------------------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Shared Function GetSessionInformation(ByVal SessionID As String, ByRef UserID As String, ByRef StartTime As Date, ByRef LastAccessTime As Date, ByRef IsActive As Boolean, ByRef NumberedSessionID As Int32) As Boolean

            Dim int64NumberedSessionID As Int64

            int64NumberedSessionID = NumberedSessionID

            GetSessionInformation = GetSessionInformation(SessionID, UserID, StartTime, LastAccessTime, IsActive, int64NumberedSessionID)

            NumberedSessionID = CInt(int64NumberedSessionID)

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        '''     GetSessionInformation returns the Session Information for the passed NumberedSessionID.
        ''' </summary>
        ''' <param name="NumberedSessionID">An integer representing an ID for the session.</param>
        ''' <param name="UserID">If passed NumberedSessionID found, it returns UserID of the user.</param>
        ''' <param name="StartTime">If passed NumberedSessionID found, it returns date and time when the session is enlisted in Session Manager Service.</param>
        ''' <param name="LastAccessTime">If passed NumberedSessionID found, it returns most recent Time(rather DateTime) when the session is accessed.</param>
        ''' <param name="IsActive">If passed NumberedSessionID found, it whether a session is active or not, based on LastAccessTime and TimeOut as specified in App.config of Session Manager Service.</param>
        ''' <param name="SessionID">If passed NumberedSessionID found, returns corresponding string of SessionID.</param>
        ''' <returns>
        '''     True if session information is found (regardless whether session is still 
        '''     active or not) in Session Manager Service, otherwise returns False.
        ''' </returns>
        ''' <remarks>
        '''     To check whether Session is active or not one should check IsActive rather than Return Value. 
        ''' </remarks>
        ''' <history>
        ''' 	[mayur]	3/30/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Shared Function GetSessionInformation(ByVal NumberedSessionID As Int64, ByRef UserID As String, ByRef StartTime As Date, ByRef LastAccessTime As Date, ByRef IsActive As Boolean, ByRef SessionID As String) As Boolean

            If HasSessionManager Then
                GetSessionInformation = m_smSessionManager.GetSessionInformation(NumberedSessionID, UserID, StartTime, LastAccessTime, IsActive, SessionID)
            End If

        End Function

        ''' ------------------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Shared Function GetSessionInformation(ByVal SessionID As String) As UserSessionInfo

            Dim strUserID As String = String.Empty
            Dim dtStartDate As Date
            Dim dtLastAccessTime As Date
            Dim intNumberedSessionID As Int64
            Dim blnIsActive As Boolean
            Dim usiUserSessionInfo As New UserSessionInfo

            GetSessionInformation(SessionID, strUserID, dtStartDate, dtLastAccessTime, blnIsActive, intNumberedSessionID)

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
        ''' <exclude/>
        ''' 
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Shared Function GetSessionInformation(ByVal NumberedSessionID As Int64) As UserSessionInfo

            Dim strUserID As String = String.Empty
            Dim dtStartDate As Date
            Dim dtLastAccessTime As Date
            Dim strSessionID As String = String.Empty
            Dim blnIsActive As Boolean
            Dim usiUserSessionInfo As New UserSessionInfo

            GetSessionInformation(NumberedSessionID, strUserID, dtStartDate, dtLastAccessTime, blnIsActive, strSessionID)

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
        ''' <exclude/>
        ''' 
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
        ''' 	[mayur]	3/24/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Private Shared Function SessionManager() As Global.Core.SessionManager

            Select Case m_triHasSessionManager
                Case TriState.True
                    Return m_smSessionManager

                Case TriState.False
                    Return Nothing

                Case TriState.UseDefault
                    Dim strSessionManagerMachine As String

                    If m_strReportConfigSessionManager <> "" Then
                        strSessionManagerMachine = m_strReportConfigSessionManager
                    Else
                        strSessionManagerMachine = System.Configuration.ConfigurationManager.AppSettings("SessionManager")
                    End If

                    If strSessionManagerMachine Is Nothing Then
                        m_triHasSessionManager = TriState.False 'No Session Manager Defined
                    Else
                        If strSessionManagerMachine.IndexOf("://") > 0 Then
                            strSessionManagerMachine += "/CoreSessionManager/CoreSessionManagerSingleton.rem"
                        Else
                            strSessionManagerMachine = "tcp://" + strSessionManagerMachine + "/CoreSessionManager/CoreSessionManagerSingleton.rem"
                        End If

                        Dim re As System.Runtime.Remoting.WellKnownClientTypeEntry

                        re = RemotingConfiguration.IsWellKnownClientType(GetType(Global.Core.SessionManager))

                        If re Is Nothing Then
                            RemotingConfiguration.RegisterWellKnownClientType(GetType(Global.Core.SessionManager), strSessionManagerMachine)
                        End If

                        re = Nothing

                        m_triHasSessionManager = TriState.True

                        Return New Global.Core.SessionManager
                    End If

            End Select

            Return Nothing

        End Function

    End Class

    ''' ------------------------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <history>
    ''' 	[Campbell]	6/22/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
    Public Structure UserSessionInfo

        ''' ------------------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public SessionID As String

        ''' ------------------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public UserID As String

        ''' ------------------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public StartTime As Date

        ''' ------------------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public LastAccessTime As Date

        ''' ------------------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public NumberedSessionID As Int32

        ''' ------------------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public IsActive As Boolean

    End Structure

End Namespace


