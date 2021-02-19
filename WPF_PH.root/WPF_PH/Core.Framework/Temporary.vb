
Namespace Core.Framework
    Public Class OldTemporary

#Region "Private Variables"

        Private m_VariableName As String
        Private m_DataType As TempTypes
        Private m_ResetOption As ResetTypes = ResetTypes.Reset
        Private m_Size As Integer
        Private m_Occurs As Integer = 0
        Private m_Occurrence As Integer = 0
        Private m_strTemp() As String = {""}
        Private m_intTemp() As Integer = {0}
        Private m_lngTemp() As Long = {0}
        Private m_dblTemp() As Decimal = {0}

#End Region

#Region "Constructor and Destructor"

        Public Sub New (ByVal Name As String, ByVal DataType As TempTypes, ByVal Size As Integer)

            m_VariableName = Name
            m_DataType = DataType
            m_Size = Size

        End Sub

        Public Sub New (ByVal Name As String, ByVal DataType As TempTypes, ByVal Size As Integer, _
                        ByVal Occurs As Integer)

            m_VariableName = Name
            m_DataType = DataType
            m_Size = Size
            m_Occurs = Occurs
            InitializeOccurs()

        End Sub

        Public Sub New (ByVal Name As String, ByVal DataType As TempTypes, ByVal Size As Integer, _
                        ByVal ResetOption As ResetTypes)

            m_VariableName = Name
            m_DataType = DataType
            m_Size = Size
            m_ResetOption = ResetOption

        End Sub

        Public Sub New (ByVal Name As String, ByVal DataType As TempTypes, ByVal Size As Integer, _
                        ByVal Occurs As Integer, ByVal ResetOption As ResetTypes)

            m_VariableName = Name
            m_DataType = DataType
            m_Size = Size
            m_Occurs = Occurs
            m_ResetOption = ResetOption
            InitializeOccurs()

        End Sub

#End Region

#Region "Properties"

        Public ReadOnly Property Name() As String
            Get
                Return m_VariableName
            End Get
        End Property

        Public Property DataType() As TempTypes
            Get
                Return m_DataType
            End Get
            Set (ByVal Value As TempTypes)
                m_DataType = Value
            End Set
        End Property

        Public Property Size() As Integer
            Get
                Return m_Size
            End Get
            Set (ByVal Value As Integer)
                m_Size = Value
            End Set
        End Property

        Public ReadOnly Property Occurs() As Integer
            Get
                Return m_Occurs
            End Get
        End Property

        Public Property Occurrence() As Integer
            Get
                Return m_Occurrence
            End Get
            Set (ByVal Value As Integer)
                m_Occurrence = Value
            End Set
        End Property

        Public Property StrTemp() As String()
            Get
                Return m_strTemp
            End Get
            Set (ByVal Value As String())
                m_strTemp = Value
            End Set
        End Property

        Public Property LngTemp() As Long()
            Get
                Return m_lngTemp
            End Get
            Set (ByVal Value As Long())
                m_lngTemp = Value
            End Set
        End Property

        Public Property IntTemp() As Integer()
            Get
                Return m_intTemp
            End Get
            Set (ByVal Value As Integer())
                m_intTemp = Value
            End Set
        End Property

        Public Property DblTemp() As Decimal()
            Get
                Return m_dblTemp
            End Get
            Set (ByVal Value As Decimal())
                m_dblTemp = Value
            End Set
        End Property

#End Region

#Region "Public methods"

        Public Function IsEqual (ByVal Value As String) As Boolean
            If m_strTemp (m_Occurrence).StartsWith (" ") Or Value.StartsWith (" ") Then
                ' Remove the trailing spaces but keep any leading spaces.
                Dim temp As String = m_strTemp (m_Occurrence).TrimEnd (" "c)
                Dim val As String = Value.TrimEnd (" "c)
                If temp.Equals (val) Then
                    Return True
                Else
                    Return False
                End If
            Else
                If m_strTemp (m_Occurrence).Trim.Equals (Value.Trim) Then
                    Return True
                Else
                    Return False
                End If
            End If
        End Function

        Public Sub Value (ByVal Value As String)
            If Value.Length >= m_Size Then
                m_strTemp (m_Occurrence) = Value.Substring (0, Size)
            Else
                m_strTemp (m_Occurrence) = Value
            End If
        End Sub

        Public Sub Value (ByVal Value As Integer)
            Select Case m_DataType
                Case TempTypes.Character, TempTypes.VarChar
                    m_strTemp (m_Occurrence) = Value.ToString
                Case TempTypes.Integer
                    m_intTemp (m_Occurrence) = Value
                Case TempTypes.Long, TempTypes.Date
                    m_lngTemp (m_Occurrence) = Value
                Case TempTypes.Decimal, TempTypes.Float
                    m_dblTemp (m_Occurrence) = Value
            End Select
        End Sub

        Public Sub Value (ByVal Value As Long)
            Select Case m_DataType
                Case TempTypes.Character, TempTypes.VarChar
                    m_strTemp (m_Occurrence) = Value.ToString
                Case TempTypes.Integer
                    m_intTemp (m_Occurrence) = CType (Value, Integer)
                Case TempTypes.Long, TempTypes.Date
                    m_lngTemp (m_Occurrence) = Value
                Case TempTypes.Decimal, TempTypes.Float
                    m_dblTemp (m_Occurrence) = Value
            End Select
        End Sub

        Public Sub Value (ByVal Value As Decimal)
            Select Case m_DataType
                Case TempTypes.Character, TempTypes.VarChar
                    m_strTemp (m_Occurrence) = Value.ToString
                Case TempTypes.Integer
                    m_intTemp (m_Occurrence) = CType (Value, Integer)
                Case TempTypes.Long, TempTypes.Date
                    m_lngTemp (m_Occurrence) = CType (Value, Long)
                Case TempTypes.Decimal, TempTypes.Float
                    m_dblTemp (m_Occurrence) = Value
            End Select
        End Sub

        Public Function GetString() As String
            If m_DataType = TempTypes.Character Then
                If m_strTemp (m_Occurrence).Length < m_Size Then
                    Return m_strTemp (m_Occurrence).PadRight (m_Size)
                Else
                    Return m_strTemp (m_Occurrence)
                End If
            Else
                If m_strTemp (m_Occurrence).Trim.Length = 0 Then
                    Return " "
                Else
                    m_strTemp (m_Occurrence).TrimEnd()
                End If
            End If
            Return Nothing
        End Function

        Public Function GetInt() As Integer
            Return m_intTemp (m_Occurrence)
        End Function

        Public Function GetLong() As Long
            Return m_lngTemp (m_Occurrence)
        End Function

        Public Function GetDecimal() As Decimal
            Return m_dblTemp (m_Occurrence)
        End Function

        Public Overrides Function ToString() As String
            Select Case m_DataType
                Case TempTypes.Integer
                    Return m_intTemp (m_Occurrence).ToString
                Case TempTypes.Long, TempTypes.Date
                    Return m_lngTemp (m_Occurrence).ToString
                Case TempTypes.Decimal, TempTypes.Float
                    Return m_dblTemp (m_Occurrence).ToString
                Case Else
                    Return GetString()
            End Select
        End Function

#End Region

#Region "Private methods"

        Private Sub InitializeOccurs()
            Dim i As Integer

            Select Case m_DataType
                Case TempTypes.Long, TempTypes.Date
                    ReDim m_lngTemp(m_Occurs)
                    For i = 0 To m_Occurs
                        m_lngTemp (i) = 0
                    Next
                Case TempTypes.Integer
                    ReDim m_intTemp(m_Occurs)
                    For i = 0 To m_Occurs
                        m_intTemp (i) = 0
                    Next
                Case TempTypes.Decimal, TempTypes.Float
                    ReDim m_dblTemp(m_Occurs)
                    For i = 0 To m_Occurs
                        m_dblTemp (i) = 0
                    Next
                Case Else
                    ' TempTypes.Character, TempTypes.VarChar
                    ReDim m_strTemp(m_Occurs)
                    For i = 0 To m_Occurs
                        m_strTemp (i) = String.Empty
                    Next
            End Select

        End Sub

#End Region
    End Class
End Namespace
