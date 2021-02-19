Imports System.Resources
Imports System.Globalization
Imports System.Threading


Namespace Core.Globalization
    Public Enum ResourceTypes
        Message
        Label
    End Enum


    Public Class GlobalizationManager
        Implements IDisposable

        Private m_objMessageResourceManager As ResourceManager
        Private m_objLabelResourceManager As ResourceManager
        Private m_objCultureInfo As CultureInfo
        Private Disposed As Boolean

        Public Sub New()

            Try
                m_objCultureInfo = New CultureInfo(Thread.CurrentThread.CurrentUICulture.Name)



                Thread.CurrentThread.CurrentCulture = m_objCultureInfo
                Thread.CurrentThread.CurrentUICulture = m_objCultureInfo

                Dim _assembly As Reflection.Assembly = Reflection.Assembly.GetEntryAssembly()
                Dim names As String() = _assembly.GetManifestResourceNames()

                For Each name As String In names
                    If name.IndexOf("Messages") > 0 Then
                        m_objMessageResourceManager = New ResourceManager(name.Substring(0, name.LastIndexOf(".")), _assembly)
                    End If
                    If name.IndexOf("Labels") > 0 Then
                        m_objLabelResourceManager = New ResourceManager(name.Substring(0, name.LastIndexOf(".")), _assembly)
                    End If
                Next

            Catch objException As Exception

                'ExceptionManager.Publish(objException)
                Throw objException

            End Try

        End Sub

       Public Sub New(LanguageCode As String)

            Try
                m_objCultureInfo = New CultureInfo(LanguageCode)

                Thread.CurrentThread.CurrentCulture = m_objCultureInfo
                Thread.CurrentThread.CurrentUICulture = m_objCultureInfo

                m_objMessageResourceManager = New ResourceManager("Messages", Me.GetType.Assembly)
                m_objLabelResourceManager = New ResourceManager("Labels", Me.GetType.Assembly)

            Catch objException As Exception

                'ExceptionManager.Publish(objException)
                Throw objException

            End Try
        End Sub

    

        Public Function GetString (ByVal Value As String, ByVal ResourceType As ResourceTypes) As String

            Dim strValue As String = ""

            Try
                Select Case ResourceType
                    Case ResourceTypes.Label
                        strValue = m_objLabelResourceManager.GetString (Value, m_objCultureInfo)
                    Case ResourceTypes.Message
                        strValue = m_objMessageResourceManager.GetString (Value, m_objCultureInfo)
                End Select

                Return strValue

            Catch objException As MissingManifestResourceException
                Try
                    strValue = m_objMessageResourceManager.GetString ("IM.Error", m_objCultureInfo)'IM.Error
                Catch ex As Exception
                    strValue = "????"
                End Try
                Return strValue

            Catch objException As Exception

                'ExceptionManager.Publish(objException)
                Throw objException

            End Try


        End Function


        Public ReadOnly Property SupportedLanguage() As string
            Get

                Return m_objCultureInfo.Name

            End Get
        End Property

        Public ReadOnly Property EnglishName() As String
            Get
                Return m_objCultureInfo.EnglishName
            End Get
        End Property

        Public ReadOnly Property LocalizedName() As String

            Get
                Return m_objCultureInfo.NativeName
            End Get
        End Property

        Public ReadOnly Property ShortDatePattern() As String

            Get
                Return m_objCultureInfo.DateTimeFormat.ShortDatePattern

            End Get
        End Property

        Public ReadOnly Property ShortTimePattern() As String

            Get
                Return m_objCultureInfo.DateTimeFormat.ShortTimePattern

            End Get
        End Property

        Public ReadOnly Property LongDatePattern() As String

            Get
                Return m_objCultureInfo.DateTimeFormat.LongDatePattern

            End Get
        End Property

        Public ReadOnly Property LongTimePattern() As String

            Get

                Return m_objCultureInfo.DateTimeFormat.LongTimePattern

            End Get
        End Property

        Public ReadOnly Property DateSeparator() As String

            Get

                Return m_objCultureInfo.DateTimeFormat.DateSeparator

            End Get
        End Property

        Public ReadOnly Property TimeSeparator() As String

            Get

                Return m_objCultureInfo.DateTimeFormat.TimeSeparator

            End Get
        End Property

        Public ReadOnly Property AbbreviatedMonthNames() As String()

            Get

                Return m_objCultureInfo.DateTimeFormat.AbbreviatedMonthNames

            End Get
        End Property

        Public ReadOnly Property LanguageCode() As String
            Get

                Return m_objCultureInfo.Name

            End Get
        End Property

        Public Overloads Sub Dispose() Implements IDisposable.Dispose
            Dispose (True)
            ' Take yourself off of the finalization queue
            ' to prevent finalization code for this object
            ' from executing a second time.
            GC.SuppressFinalize (Me)

        End Sub

        Protected Overridable Overloads Sub Dispose (ByVal disposing As Boolean)
            ' Check to see if Dispose has already been called.
            If Not (Me.Disposed) Then
                ' If disposing equals true, dispose all managed 
                ' and unmanaged resources.
                If (disposing) Then
                    ' Dispose managed resources.
                    m_objCultureInfo = Nothing
                    m_objMessageResourceManager.ReleaseAllResources()
                    m_objMessageResourceManager = Nothing
                    m_objLabelResourceManager.ReleaseAllResources()
                    m_objLabelResourceManager = Nothing
                End If

            End If
            Me.Disposed = True
        End Sub
    End Class
End Namespace
