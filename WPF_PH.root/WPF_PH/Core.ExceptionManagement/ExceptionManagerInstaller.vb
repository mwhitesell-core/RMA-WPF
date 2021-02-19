Imports System.ComponentModel
Imports System.Configuration.Install
Imports System.Resources
Imports System.Reflection


''' -----------------------------------------------------------------------------
''' Project	 : Core.ExceptionManagement
''' Class	 : ExceptionManagement.ExceptionManagerInstaller
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Installer class used to create two event sources for the Exception Management Application Block to function correctly.
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[patrick]	2005/01/04	Created
''' </history>
''' -----------------------------------------------------------------------------
    <RunInstaller (True)> _
Public Class ExceptionManagerInstaller
    Inherits Installer

    Private exceptionManagerEventLogInstaller As EventLogInstaller
    Private exceptionManagementEventLogInstaller As EventLogInstaller

    Private Shared _
        m_resourceManager As ResourceManager = _
            New ResourceManager (GetType (ExceptionManager).Namespace + ".ExceptionManagerText", _
                                 Assembly.GetAssembly (GetType (ExceptionManager)))


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Constructor with no params.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[patrick]	2005/01/04	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub New()
        MyBase.New()

        'Initialize variables.
        InitializeComponent()

    End Sub


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Installer overrides dispose to clean up the component list.
    ''' </summary>
    ''' <param name="disposing"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[patrick]	2005/01/04	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Protected Overloads Overrides Sub Dispose (ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose (disposing)
    End Sub

    'Required by the Component Designer
    Private components As IContainer


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Initialization function to set internal variables.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[patrick]	2005/01/04	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub InitializeComponent()

        Me.exceptionManagerEventLogInstaller = New EventLogInstaller
        Me.exceptionManagementEventLogInstaller = New EventLogInstaller

        ' exceptionManagerEventLogInstaller

        Me.exceptionManagerEventLogInstaller.Log = "Application"
        Me.exceptionManagerEventLogInstaller.Source = _
            m_resourceManager.GetString ("RES_EXCEPTIONMANAGER_INTERNAL_EXCEPTIONS")

        ' exceptionManagementEventLogInstaller

        Me.exceptionManagementEventLogInstaller.Log = "Application"
        Me.exceptionManagementEventLogInstaller.Source = _
            m_resourceManager.GetString ("RES_EXCEPTIONMANAGER_PUBLISHED_EXCEPTIONS")

        Me.Installers.AddRange ( _
                                New Installer() _
                                   {Me.exceptionManagerEventLogInstaller, Me.exceptionManagementEventLogInstaller})

    End Sub
End Class
