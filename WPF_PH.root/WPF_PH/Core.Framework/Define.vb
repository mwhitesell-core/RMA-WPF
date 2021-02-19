Imports System.ComponentModel
Imports Core.ExceptionManagement

Namespace Core.Framework
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: DCharacter
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' <summary>
    ''' 	The DCharacter class is used to handle evaluating expressions of defined
    '''     character items.  
    ''' </summary>
    ''' <remarks>
    '''     This class evaluates the expression when referenced and
    '''     returns the value with the appropariate padded spaces based on the size 
    '''     defined in the declaration.
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(EditorBrowsableState.Always)>
    Public Class DCharacter
        ''' --- m_previous ----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of m_previous.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected m_previous As String

        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected m_reset As Boolean

        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected m_IsResetMaximum As Boolean


        ''' --- m_IsMaximum ----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of m_previous.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)> Protected m_IsMaximum As Boolean = False

        ''' --- m_intSize ----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of m_intSize.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected m_intSize As Integer

        ''' --- m_strName ----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of m_strName.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected m_strName As String

        ''' --- GetValue -----------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	This event is used to return the value of the defined item when referenced.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <param name="Value">The value of the evaluated expression that is to be returned by the event.</param>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Event GetValue(ByRef Value As String)

        ''' --- GetRecordBuffer ----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetRecordBuffer.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Public GetRecordBuffer As Getter

        ''' --- New ----------------------------------------------------------------
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
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub New()
            m_intSize = 1
            'If Size is not specified, the default size is One
            GetRecordBuffer = AddressOf Getter
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Initializes a new instance of a DCharacter class.
        ''' </summary>
        ''' <param name="Size">Specifies the storage size in bytes.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub New(ByVal Size As Integer)
            m_intSize = Size
            GetRecordBuffer = AddressOf Getter
        End Sub

        ''' --- New ----------------------------------------------------------------
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
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub New(ByVal Name As String)
            m_intSize = 1
            'If Size is not specified, the default size is One
            m_strName = Name
            GetRecordBuffer = AddressOf Getter
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Initializes a new instance of a DCharacter class.
        ''' </summary>
        ''' <param name="Size">Specifies the storage size in bytes.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub New(ByVal Name As String, ByVal Size As Integer)
            m_intSize = Size
            m_strName = Name
            GetRecordBuffer = AddressOf Getter
        End Sub

        ''' --- Name --------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Returns the Name 
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public ReadOnly Property Name() As String
            Get
                Return m_strName
            End Get
        End Property

        ''' --- SubTotalValue --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Returns the MaximumValue of the evaluated expression.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <returns>A Decimal value.
        ''' </returns>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)>
        Public ReadOnly Property MaximumValue() As String

            Get
                Dim strValue As String = String.Empty

                If Not m_IsResetMaximum AndAlso Not m_IsMaximum Then

                    Try
                        RaiseEvent GetValue(strValue)
                    Catch ex As CustomApplicationException
                        Throw ex
                    Catch ex As Exception
                        ExceptionManager.Publish(ex)
                        Throw ex
                    End Try

                End If

                strValue = m_previous


                If m_reset Then
                    m_previous = Reset
                    m_reset = False
                End If
                Return strValue
            End Get
        End Property

        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public ReadOnly Property Reset() As String
            Get
                If m_reset Then
                    Return ""
                End If

                Return m_previous
            End Get
        End Property

        ''' --- MaximumValue --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Returns the MaximumValue of the evaluated expression.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <returns>A Decimal value.
        ''' </returns>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public ReadOnly Property ResetMaximum(ByVal blnAt As Boolean) As DCharacter
            Get

                Dim strValue As String = String.Empty

                If m_reset Then
                    m_previous = Reset()
                    m_reset = False
                End If

                If blnAt Then
                    m_reset = True
                End If
                Try
                    RaiseEvent GetValue(strValue)
                Catch ex As CustomApplicationException
                    Throw ex
                Catch ex As Exception
                    ExceptionManager.Publish(ex)
                    Throw ex
                End Try

                If strValue > m_previous Then
                    m_previous = strValue
                End If

                m_IsResetMaximum = True
                m_IsMaximum = True

                Return Me
            End Get
        End Property

        ''' --- MaximumValue --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Returns the MaximumValue of the evaluated expression.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <returns>A Decimal value.
        ''' </returns>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public ReadOnly Property Maximum() As DCharacter
            Get
                Dim strValue As String = String.Empty
                Try
                    RaiseEvent GetValue(strValue)
                Catch ex As CustomApplicationException
                    Throw ex
                Catch ex As Exception
                    ExceptionManager.Publish(ex)
                    Throw ex
                End Try
                If strValue > m_previous Then
                    m_previous = strValue
                End If

                m_IsMaximum = True
                Return Me
            End Get
        End Property

        ''' --- Size --------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Returns the Size 
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public ReadOnly Property Size() As String
            Get
                Return m_intSize
            End Get
        End Property

        ''' --- MaximumValue --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Returns the MaximumValue of the evaluated expression.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <returns>A Decimal value.
        ''' </returns>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public ReadOnly Property IsMaximum() As Boolean
            Get
                Return m_IsMaximum
            End Get
        End Property

        ''' --- Value --------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Returns the value of the evaluated expression.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <returns>A string value.  This value is padded with trailing spaces
        ''' if the size of the value is less than the size of the defined class.
        ''' </returns>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public ReadOnly Property Value() As String
            Get
                Dim strValue As String = String.Empty
                Try
                    RaiseEvent GetValue(strValue)
                Catch ex As CustomApplicationException
                    Throw ex
                Catch ex As Exception
                    ExceptionManager.Publish(ex)
                    Throw ex
                End Try
                Return ValidatedValue(strValue)
            End Get
        End Property


        ''' --- Value --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Returns the value of the evaluated expression.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <returns>
        ''' </returns>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public ReadOnly Property Value(ByVal Sort As SortType) As String
            Get
                Dim strValue As String = String.Empty
                Try
                    RaiseEvent GetValue(strValue)
                Catch ex As CustomApplicationException
                    Throw ex
                Catch ex As Exception
                    ExceptionManager.Publish(ex)
                    Throw ex
                End Try
                If Sort = SortType.Descending Then
                    Return strValue & "~!Descending!~"
                Else
                    Return strValue
                End If
            End Get
        End Property

        ''' --- ValidatedValue -----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of ValidatedValue.
        ''' </summary>
        ''' <param name="Value"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function ValidatedValue(ByVal Value As String) As String
            Select Case Math.Sign(Value.Length - m_intSize)
                Case 1
                    Return Value.Substring(0, m_intSize)
                Case 0
                    Return Value
                Case -1
                    Return Value.PadRight(m_intSize)
            End Select
            Return Nothing
        End Function

        ''' --- Getter -------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Getter.
        ''' </summary>
        ''' <param name="Sender"></param>
        ''' <param name="GetterArgs"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Function Getter(ByVal Sender As Object, ByVal GetterArgs As GetterArgs) As Boolean
            GetterArgs.FieldText = Value
        End Function
    End Class

    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: DVarChar
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' <summary>
    ''' 	The DCharacter class is used to handle evaluating expressions of defined
    '''     character items.  
    ''' </summary>
    ''' <remarks>
    '''     Unlike the DCharacter class, the value returned will not include the padded
    '''     spaces at the end.
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(EditorBrowsableState.Always)>
    Public Class DVarChar
        ''' --- m_intSize ----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of m_intSize.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected m_intSize As Integer

        ''' --- m_strName ----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of m_strName.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected m_strName As String


        ''' --- GetValue -----------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	This event is used to return the value of the defined item when referenced.
        ''' </summary>
        ''' <param name="Value">The value of the evaluated expression that is to be returned by the event.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Event GetValue(ByRef Value As String)

        ''' --- GetRecordBuffer ----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetRecordBuffer.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Public GetRecordBuffer As Getter

        ''' --- New ----------------------------------------------------------------
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
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub New()
            m_intSize = 1
            'If Size is not specified, the default size is One
            GetRecordBuffer = AddressOf Getter
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Initializes a new instance of a DVarChar class.
        ''' </summary>
        ''' <param name="Size">Specifies the storage size in bytes.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub New(ByVal Size As Integer)
            m_intSize = Size
            GetRecordBuffer = AddressOf Getter
        End Sub

        ''' --- New ----------------------------------------------------------------
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
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub New(ByVal Name As String)
            m_intSize = 1
            'If Size is not specified, the default size is One
            m_strName = Name
            GetRecordBuffer = AddressOf Getter
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Initializes a new instance of a DVarChar class.
        ''' </summary>
        ''' <param name="Size">Specifies the storage size in bytes.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub New(ByVal Name As String, ByVal Size As Integer)
            m_intSize = Size
            m_strName = Name
            GetRecordBuffer = AddressOf Getter
        End Sub

        ''' --- Value --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Returns the value of the evaluated expression.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <returns>A string value.
        ''' </returns>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public ReadOnly Property Value() As String
            Get
                Dim strValue As String = String.Empty
                Try
                    RaiseEvent GetValue(strValue)
                Catch ex As CustomApplicationException
                    Throw ex
                Catch ex As Exception
                    ExceptionManager.Publish(ex)
                    Throw ex
                End Try
                Return ValidatedValue(strValue)
            End Get
        End Property

        ''' --- Value --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Returns the value of the evaluated expression.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <returns>
        ''' </returns>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public ReadOnly Property Value(ByVal Sort As SortType) As String
            Get
                Dim strValue As String = String.Empty
                Try
                    RaiseEvent GetValue(strValue)
                Catch ex As CustomApplicationException
                    Throw ex
                Catch ex As Exception
                    ExceptionManager.Publish(ex)
                    Throw ex
                End Try
                If Sort = SortType.Descending Then
                    Return strValue & "~!Descending!~"
                Else
                    Return strValue
                End If
            End Get
        End Property

        ''' --- ValidatedValue -----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of ValidatedValue.
        ''' </summary>
        ''' <param name="Value"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function ValidatedValue(ByVal Value As String) As String
            Select Case Math.Sign(Value.Length - m_intSize)
                Case 1
                    Return Value.Substring(0, m_intSize)
                Case Else
                    Return Value.TrimEnd
            End Select
        End Function

        ''' --- Getter -------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Getter.
        ''' </summary>
        ''' <param name="Sender"></param>
        ''' <param name="GetterArgs"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Function Getter(ByVal Sender As Object, ByVal GetterArgs As GetterArgs) As Boolean
            GetterArgs.FieldText = Value
        End Function
    End Class

    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: DDecimal
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' <summary>
    ''' 	The DCharacter class is used to handle evaluating expressions of defined
    '''     Decimal items.  
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(EditorBrowsableState.Always)>
    Public Class DDecimal
        'Note at present in Decimal we do not observe the Size
        ''' --- m_previous ----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of m_previous.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected m_previous As Decimal

        ''' --- m_previous ----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of m_previous.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected m_IsResetMaximum As Boolean


        ''' --- m_IsMaximum ----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of m_previous.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)> Protected m_IsMaximum As Boolean = False

        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected m_reset As Boolean

        ''' --- m_IsSubtotal ----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of m_previous.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)> Protected m_IsSubtotal As Boolean = False

        <EditorBrowsable(EditorBrowsableState.Never)> Protected m_IsResetSubtotal As Boolean = False

        ''' --- m_intSize ----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of m_intSize.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected m_intSize As Integer

        ''' --- m_strName ----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of m_intName.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected m_strName As String

        ''' --- GetValue -----------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	This event is used to return the value of the defined item when referenced.
        ''' </summary>
        ''' <param name="Value">The value of the evaluated expression that is to be returned by the event.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Event GetValue(ByRef Value As Decimal)

        ''' --- GetRecordBuffer ----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetRecordBuffer.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Public GetRecordBuffer As Getter

        ''' --- New ----------------------------------------------------------------
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
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub New()
            'Note at present in Decimal we do not observe the Size
            m_intSize = 6
            'If Size is not specified, the default size is Six
            GetRecordBuffer = AddressOf Getter
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Initializes a new instance of a DDecimal class.
        ''' </summary>
        ''' <param name="Size">Specifies the storage size in bytes.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub New(ByVal Size As Integer)
            'Note at present in Decimal we do not observe the Size
            m_intSize = Size
            GetRecordBuffer = AddressOf Getter
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Initializes a new instance of a DDecimal class.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub New(ByVal Name As String)
            'Note at present in Decimal we do not observe the Size
            m_intSize = 1
            m_strName = Name
            GetRecordBuffer = AddressOf Getter
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Initializes a new instance of a DDecimal class.
        ''' </summary>
        ''' <param name="Size">Specifies the storage size in bytes.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub New(ByVal Name As String, ByVal Size As Integer)
            'Note at present in Decimal we do not observe the Size
            m_intSize = Size
            m_strName = Name
            GetRecordBuffer = AddressOf Getter
        End Sub

        ''' --- Name --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Returns the Name 
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <returns>A Decimal Name.
        ''' </returns>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public ReadOnly Property Name() As String
            Get
                Return m_strName
            End Get
        End Property

        ''' --- Value --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Returns the value of the evaluated expression.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <returns>A Decimal value.
        ''' </returns>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public ReadOnly Property Value() As Decimal
            Get
                Dim dblValue As Decimal = 0
                Try
                    RaiseEvent GetValue(dblValue)
                Catch ex As CustomApplicationException
                    Throw ex
                Catch ex As Exception
                    ExceptionManager.Publish(ex)
                    Throw ex
                End Try
                Return dblValue
            End Get
        End Property


         <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function SortValue(ByVal Sort As SortType) As String
            
                Dim dblValue As Decimal = 0
                Try
                    RaiseEvent GetValue(dblValue)
                Catch ex As CustomApplicationException
                    Throw ex
                Catch ex As Exception
                    ExceptionManager.Publish(ex)
                    Throw ex
                End Try

                If Sort = SortType.Descending Then
                    Return dblValue.ToString & "~!Descending!~"
                ElseIf Sort = SortType.Numeric Then
                    Return dblValue.ToString & "~!Numeric!~"
                ElseIf Sort = SortType.NumericDescending Then
                    Return dblValue.ToString & "~!NumericDescending!~"
                Else
                    Return dblValue.ToString
                End If

                Return dblValue
           
        End Function

        ''' --- SubTotalValue --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Returns the SubTotalValue of the evaluated expression.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <returns>A Decimal value.
        ''' </returns>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)>
        Public ReadOnly Property SubTotalValue() As Decimal
            Get
                Dim dblValue As Decimal = 0

                If Not m_IsResetSubtotal AndAlso Not m_IsSubtotal Then
                    Try
                        RaiseEvent GetValue(dblValue)
                    Catch ex As CustomApplicationException
                        Throw ex
                    Catch ex As Exception
                        ExceptionManager.Publish(ex)
                        Throw ex
                    End Try
                End If
                dblValue = m_previous + dblValue
                If m_reset Then
                    m_previous = Reset
                    m_reset = False
                End If
                Return dblValue
            End Get
        End Property

        ''' --- SubTotalValue --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Returns the SubTotalValue of the evaluated expression.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <returns>A Decimal value.
        ''' </returns>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public ReadOnly Property ResetSubTotal(ByVal blnAt As Boolean) As DDecimal
            Get
                Dim dblValue As Decimal = 0

                If m_reset Then
                    m_previous = Reset
                    m_reset = False
                End If

                If blnAt Then
                    m_reset = True
                End If
                Try
                    RaiseEvent GetValue(dblValue)
                Catch ex As CustomApplicationException
                    Throw ex
                Catch ex As Exception
                    ExceptionManager.Publish(ex)
                    Throw ex
                End Try
                m_previous = m_previous + dblValue

                m_IsResetSubtotal = True
                m_IsSubtotal = True

                Return Me
            End Get
        End Property

        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public ReadOnly Property Reset() As Decimal
            Get
                If m_reset Then
                    Return 0
                End If

                Return m_previous
            End Get
        End Property

        ''' --- SubTotalValue --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Returns the SubTotalValue of the evaluated expression.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <returns>A Decimal value.
        ''' </returns>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public ReadOnly Property SubTotal() As DDecimal
            Get
                Dim dblValue As Decimal = 0

                Try
                    RaiseEvent GetValue(dblValue)
                Catch ex As CustomApplicationException
                    Throw ex
                Catch ex As Exception
                    ExceptionManager.Publish(ex)
                    Throw ex
                End Try
                m_previous = m_previous + dblValue

                m_IsSubtotal = True
                Return Me
            End Get
        End Property

        ''' --- Size --------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Returns the Size 
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public ReadOnly Property Size() As String
            Get
                Return m_intSize
            End Get
        End Property

        ''' --- SubTotalValue --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Returns the SubTotalValue of the evaluated expression.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <returns>A Decimal value.
        ''' </returns>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public ReadOnly Property IsSubTotal() As Boolean
            Get
                Return m_IsSubtotal
            End Get
        End Property

        ''' --- MaximumValue --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Returns the MaximumValue of the evaluated expression.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <returns>A Decimal value.
        ''' </returns>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public ReadOnly Property IsMaximum() As Boolean
            Get
                Return m_IsMaximum
            End Get
        End Property

        ''' --- MaximumValue --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Returns the MaximumValue of the evaluated expression.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <returns>A Decimal value.
        ''' </returns>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public ReadOnly Property Maximum() As DDecimal
            Get
                Dim strValue As Decimal = 0
                Try
                    RaiseEvent GetValue(strValue)
                Catch ex As CustomApplicationException
                    Throw ex
                Catch ex As Exception
                    ExceptionManager.Publish(ex)
                    Throw ex
                End Try
                If strValue > m_previous Then
                    m_previous = strValue
                End If

                m_IsMaximum = True
                Return Me
            End Get
        End Property

        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public ReadOnly Property Minimum() As DDecimal
            Get
                Dim strValue As Decimal = 0
                Try
                    RaiseEvent GetValue(strValue)
                Catch ex As CustomApplicationException
                    Throw ex
                Catch ex As Exception
                    ExceptionManager.Publish(ex)
                    Throw ex
                End Try
                If strValue < m_previous Then
                    m_previous = strValue
                End If

                m_IsMaximum = True
                Return Me
            End Get
        End Property

        ''' --- MaximumValue --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Returns the MaximumValue of the evaluated expression.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <returns>A Decimal value.
        ''' </returns>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public ReadOnly Property ResetMaximum(ByVal blnAt As Boolean) As DDecimal
            Get

                Dim strValue As Decimal = 0

                If m_reset Then
                    m_previous = Reset()
                    m_reset = False
                End If

                If blnAt Then
                    m_reset = True
                End If
                Try
                    RaiseEvent GetValue(strValue)
                Catch ex As CustomApplicationException
                    Throw ex
                Catch ex As Exception
                    ExceptionManager.Publish(ex)
                    Throw ex
                End Try

                If strValue > m_previous Then
                    m_previous = strValue
                End If

                m_IsResetMaximum = True
                m_IsMaximum = True

                Return Me
            End Get
        End Property

        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public ReadOnly Property ResetMinimum(ByVal blnAt As Boolean) As DDecimal
            Get

                Dim strValue As Decimal = 0

                If m_reset Then
                    m_previous = Reset()
                    m_reset = False
                End If

                If blnAt Then
                    m_reset = True
                End If
                Try
                    RaiseEvent GetValue(strValue)
                Catch ex As CustomApplicationException
                    Throw ex
                Catch ex As Exception
                    ExceptionManager.Publish(ex)
                    Throw ex
                End Try

                If strValue < m_previous Then
                    m_previous = strValue
                End If

                m_IsResetMaximum = True
                m_IsMaximum = True

                Return Me
            End Get
        End Property

        ''' --- SubTotalValue --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Returns the MaximumValue of the evaluated expression.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <returns>A Decimal value.
        ''' </returns>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)>
        Public ReadOnly Property MaximumValue() As Decimal

            Get
                Dim dcValue As Decimal = 0

                If Not m_IsResetMaximum AndAlso Not m_IsMaximum Then

                    Try
                        RaiseEvent GetValue(dcValue)
                    Catch ex As CustomApplicationException
                        Throw ex
                    Catch ex As Exception
                        ExceptionManager.Publish(ex)
                        Throw ex
                    End Try

                End If

                dcValue = m_previous

                If m_reset Then
                    m_previous = Reset
                    m_reset = False
                End If

                Return dcValue
            End Get
        End Property


        ''' --- Value --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Returns the value of the evaluated expression.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <returns>A Decimal value.
        ''' </returns>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public ReadOnly Property Value(ByVal Sort As SortType) As String
            Get
                Dim dblValue As Decimal = 0

                Try
                    RaiseEvent GetValue(dblValue)
                Catch ex As CustomApplicationException
                    Throw ex
                Catch ex As Exception
                    ExceptionManager.Publish(ex)
                    Throw ex
                End Try
                If Sort = SortType.Descending Then
                    Return dblValue.ToString & "~!Descending!~"
                ElseIf Sort = SortType.Numeric Then
                    Return dblValue.ToString & "~!Numeric!~"
                ElseIf Sort = SortType.NumericDescending Then
                    Return dblValue.ToString & "~!NumericDescending!~"
                Else
                    Return dblValue.ToString
                End If
            End Get
        End Property

        ''' --- Getter -------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Getter.
        ''' </summary>
        ''' <param name="Sender"></param>
        ''' <param name="GetterArgs"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Function Getter(ByVal Sender As Object, ByVal GetterArgs As GetterArgs) As Boolean
            Dim dblValue As Decimal = Me.Value
            GetterArgs.FieldText = dblValue.ToString
            GetterArgs.FieldValue = dblValue
        End Function
    End Class

    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: DInteger
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' <summary>
    ''' 	The DCharacter class is used to handle evaluating expressions of defined
    '''     integer items.  
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(EditorBrowsableState.Always)>
    Public Class DInteger
        'Note at present in Decimal we do not observe the Size
        ''' --- m_previous ----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of m_previous.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected m_previous As Decimal

        ''' --- m_IsSubtotal ----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of m_previous.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)> Protected m_IsSubtotal As Boolean = False

        <EditorBrowsable(EditorBrowsableState.Never)> Protected m_IsResetSubtotal As Boolean = False
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected m_reset As Boolean
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected m_IsResetMaximum As Boolean


        ''' --- m_IsMaximum ----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of m_previous.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)> Protected m_IsMaximum As Boolean = False

        ''' --- m_intSize ----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of m_intSize.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected m_intSize As Integer

        ''' --- m_strName ----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of m_strName.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected m_strName As String

        ''' --- GetValue -----------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	This event is used to return the value of the defined item when referenced.
        ''' </summary>
        ''' <param name="Value">The value of the evaluated expression that is to be returned by the event.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Event GetValue(ByRef Value As Decimal)

        ''' --- m_blnSigned --------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnSigned.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Private m_blnSigned As Boolean = True

        ''' --- GetRecordBuffer ----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetRecordBuffer.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Public GetRecordBuffer As Getter

        ''' --- New ----------------------------------------------------------------
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
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub New()
            m_intSize = 4
            'If Size is not specified, the default size is Four
            GetRecordBuffer = AddressOf Getter
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Initializes a new instance of a DInteger class.
        ''' </summary>
        ''' <param name="Size">Specifies the storage size in bytes.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub New(ByVal Size As Integer)
            m_intSize = Size
            GetRecordBuffer = AddressOf Getter
        End Sub

        ''' --- New ----------------------------------------------------------------
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
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub New(ByVal Name As String)
            m_intSize = 4
            'If Size is not specified, the default size is Four
            m_strName = Name
            GetRecordBuffer = AddressOf Getter
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Initializes a new instance of a DInteger class.
        ''' </summary>
        ''' <param name="Size">Specifies the storage size in bytes.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub New(ByVal Name As String, ByVal Size As Integer)
            m_intSize = Size
            m_strName = Name
            GetRecordBuffer = AddressOf Getter
        End Sub

        ''' --- Name --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Returns the Name 
        ''' </summary>
        ''' <returns>
        ''' </returns>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public ReadOnly Property Name() As String
            Get
                Return m_strName
            End Get
        End Property

        ''' --- Size --------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Returns the Size 
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public ReadOnly Property Size() As String
            Get
                Return m_intSize
            End Get
        End Property

        ''' --- SubTotalValue --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Returns the SubTotalValue of the evaluated expression.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <returns>A Decimal value.
        ''' </returns>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)>
        Public ReadOnly Property SubTotalValue() As Decimal
            Get
                Dim dblValue As Decimal = 0

                If Not m_IsResetSubtotal AndAlso Not m_IsSubtotal Then
                    Try
                        RaiseEvent GetValue(dblValue)
                    Catch ex As CustomApplicationException
                        Throw ex
                    Catch ex As Exception
                        ExceptionManager.Publish(ex)
                        Throw ex
                    End Try
                End If
                dblValue = m_previous + dblValue
                If m_reset Then
                    m_previous = Reset
                    m_reset = False
                End If
                Return dblValue
            End Get
        End Property

        ''' --- SubTotalValue --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Returns the SubTotalValue of the evaluated expression.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <returns>A Decimal value.
        ''' </returns>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public ReadOnly Property SubTotal() As DInteger
            Get
                Dim dblValue As Decimal = 0

                Try
                    RaiseEvent GetValue(dblValue)
                Catch ex As CustomApplicationException
                    Throw ex
                Catch ex As Exception
                    ExceptionManager.Publish(ex)
                    Throw ex
                End Try
                m_previous = m_previous + dblValue

                m_IsSubtotal = True
                Return Me
            End Get
        End Property

        ''' --- SubTotalValue --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Returns the SubTotalValue of the evaluated expression.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <returns>A Decimal value.
        ''' </returns>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public ReadOnly Property ResetSubTotal(ByVal blnAt As Boolean) As DInteger
            Get
                Dim dblValue As Decimal = 0

                If m_reset Then
                    m_previous = Reset
                    m_reset = False
                End If

                If blnAt Then
                    m_reset = True
                End If
                Try
                    RaiseEvent GetValue(dblValue)
                Catch ex As CustomApplicationException
                    Throw ex
                Catch ex As Exception
                    ExceptionManager.Publish(ex)
                    Throw ex
                End Try
                m_previous = m_previous + dblValue

                m_IsResetSubtotal = True
                m_IsSubtotal = True

                Return Me
            End Get
        End Property

        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public ReadOnly Property Reset() As Decimal
            Get
                If m_reset Then
                    Return 0
                End If

                Return m_previous
            End Get
        End Property

        ''' --- SubTotalValue --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Returns the SubTotalValue of the evaluated expression.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <returns>A Decimal value.
        ''' </returns>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public ReadOnly Property IsSubTotal() As Boolean
            Get
                Return m_IsSubtotal
            End Get
        End Property

        ''' --- MaximumValue --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Returns the MaximumValue of the evaluated expression.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <returns>A Decimal value.
        ''' </returns>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public ReadOnly Property IsMaximum() As Boolean
            Get
                Return m_IsMaximum
            End Get
        End Property

        ''' --- MaximumValue --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Returns the MaximumValue of the evaluated expression.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <returns>A Decimal value.
        ''' </returns>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public ReadOnly Property Maximum() As DInteger
            Get
                Dim strValue As Decimal = String.Empty
                Try
                    RaiseEvent GetValue(strValue)
                Catch ex As CustomApplicationException
                    Throw ex
                Catch ex As Exception
                    ExceptionManager.Publish(ex)
                    Throw ex
                End Try
                If strValue > m_previous Then
                    m_previous = strValue
                End If

                m_IsMaximum = True
                Return Me
            End Get
        End Property

        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public ReadOnly Property Minimum() As DInteger
            Get
                Dim strValue As Decimal = String.Empty
                Try
                    RaiseEvent GetValue(strValue)
                Catch ex As CustomApplicationException
                    Throw ex
                Catch ex As Exception
                    ExceptionManager.Publish(ex)
                    Throw ex
                End Try
                If strValue < m_previous Then
                    m_previous = strValue
                End If

                m_IsMaximum = True
                Return Me
            End Get
        End Property

        ''' --- MaximumValue --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Returns the MaximumValue of the evaluated expression.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <returns>A Decimal value.
        ''' </returns>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public ReadOnly Property ResetMaximum(ByVal blnAt As Boolean) As DInteger
            Get

                Dim strValue As Decimal = 0

                If m_reset Then
                    m_previous = Reset()
                    m_reset = False
                End If

                If blnAt Then
                    m_reset = True
                End If
                Try
                    RaiseEvent GetValue(strValue)
                Catch ex As CustomApplicationException
                    Throw ex
                Catch ex As Exception
                    ExceptionManager.Publish(ex)
                    Throw ex
                End Try

                If strValue > m_previous Then
                    m_previous = strValue
                End If

                m_IsResetMaximum = True
                m_IsMaximum = True

                Return Me
            End Get
        End Property

        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public ReadOnly Property ResetMinimum(ByVal blnAt As Boolean) As DInteger
            Get

                Dim strValue As Decimal = 0

                If m_reset Then
                    m_previous = Reset()
                    m_reset = False
                End If

                If blnAt Then
                    m_reset = True
                End If
                Try
                    RaiseEvent GetValue(strValue)
                Catch ex As CustomApplicationException
                    Throw ex
                Catch ex As Exception
                    ExceptionManager.Publish(ex)
                    Throw ex
                End Try

                If strValue < m_previous Then
                    m_previous = strValue
                End If

                m_IsResetMaximum = True
                m_IsMaximum = True

                Return Me
            End Get
        End Property

        ''' --- SubTotalValue --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Returns the MaximumValue of the evaluated expression.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <returns>A Decimal value.
        ''' </returns>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)>
        Public ReadOnly Property MaximumValue() As Decimal

            Get
                Dim dcValue As Decimal = 0

                If Not m_IsResetMaximum AndAlso Not m_IsMaximum Then

                    Try
                        RaiseEvent GetValue(dcValue)
                    Catch ex As CustomApplicationException
                        Throw ex
                    Catch ex As Exception
                        ExceptionManager.Publish(ex)
                        Throw ex
                    End Try
                End If

                dcValue = m_previous

                If m_reset Then
                    m_previous = Reset
                    m_reset = False
                End If

                Return dcValue
            End Get
        End Property


        ''' --- Value --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Returns the value of the evaluated expression.
        ''' </summary>
        ''' <remarks>To avoid casting datatypes, the integer evaluated by the expression
        ''' will be returned as a Decimal.
        ''' </remarks>
        ''' <returns>A Decimal value.  
        ''' </returns>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public ReadOnly Property Value() As Decimal
            'Note: Because the way .Net rounds the integer value, we need the type as Decimal 
            Get
                Dim dblValue As Decimal = 0

                Try
                    RaiseEvent GetValue(dblValue)
                Catch ex As CustomApplicationException
                    Throw ex
                Catch ex As Exception
                    ExceptionManager.Publish(ex)
                    Throw ex
                End Try
                Return ValidatedValue(dblValue)
            End Get
        End Property

        ''' --- Value --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Returns the value of the evaluated expression.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <returns>A Decimal value.
        ''' </returns>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public ReadOnly Property Value(ByVal Sort As SortType) As String
            Get
                Dim dblValue As Decimal = 0
                Try
                    RaiseEvent GetValue(dblValue)
                Catch ex As CustomApplicationException
                    Throw ex
                Catch ex As Exception
                    ExceptionManager.Publish(ex)
                    Throw ex
                End Try
                If Sort = SortType.Descending Then
                    Return dblValue.ToString & "~!Descending!~"
                Else
                    Return dblValue.ToString
                End If
            End Get
        End Property

        ''' --- ValidatedValue -----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of ValidatedValue.
        ''' </summary>
        ''' <param name="Value"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function ValidatedValue(ByVal Value As Decimal) As Decimal

            If m_blnSigned Then
                'Using Round with 0 precision and by specifying Down option, we are truncating decimal portion of the passed value
                Return Round(Value, 0, RoundOptionTypes.Down)
            Else
                'If defined as unsigned integer, raising an error for negative numbers
                If Value < 0 Then Throw New CustomApplicationException("Error")

                'Using Round with 0 precision and by specifying Down option, we are truncating decimal portion of the passed value
                Return Round(Value, 0, RoundOptionTypes.Down)
            End If
        End Function

        ''' --- Getter -------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Getter.
        ''' </summary>
        ''' <param name="Sender"></param>
        ''' <param name="GetterArgs"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Function Getter(ByVal Sender As Object, ByVal GetterArgs As GetterArgs) As Boolean
            GetterArgs.FieldText = Me.Value.ToString
            GetterArgs.FieldValue = Me.Value
        End Function
    End Class

    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: DDate
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' <summary>
    ''' 	The DDate class is used to handle evaluating expressions of defined
    '''     date items.  
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(EditorBrowsableState.Always)>
    Public Class DDate
        ''' --- GetValue -----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	This event is used to return the value of the defined item when referenced.
        ''' </summary>
        ''' <param name="Value">The value of the evaluated expression that is to be returned by the event.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Event GetValue(ByRef Value As Decimal)

        ''' --- cDefaultValue ------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of cDefaultValue.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Private Const cDefaultValue As Decimal = cZeroDecimalDate

        ''' --- cDefaultDateValue --------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of cDefaultDateValue.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Private Const cDefaultDateValue As Date = cZeroDate

        ''' --- m_strName ----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of m_intName.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected m_strName As String

        ''' --- GetRecordBuffer ----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetRecordBuffer.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Public GetRecordBuffer As Getter

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Initializes a new instance of a DDate class.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub New()
            GetRecordBuffer = AddressOf Getter
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Initializes a new instance of a DDate class.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub New(ByVal Name As String)
            m_strName = Name
            GetRecordBuffer = AddressOf Getter
        End Sub


        ''' --- DateValue ----------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Returns the value of the evaluated expression.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public ReadOnly Property DateValue() As Date
            Get
                Dim strValue As String

                ' Store the value as a string.
                strValue = Me.Value.ToString
                Return _
                    New Date(CInt(strValue.Substring(0, 4)), CInt(strValue.Substring(4, 2)),
                              CInt(strValue.Substring(6, 2)))
            End Get
        End Property

        ''' --- Name --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Returns the Name
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <returns>
        ''' </returns>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public ReadOnly Property Name() As String
            Get
                Return m_strName
            End Get
        End Property

        ''' --- Value --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Returns the value of the evaluated expression.
        ''' </summary>
        ''' <remarks>The value returned can be a numeric value up to 16 digits (for datetime).
        ''' </remarks>
        ''' <returns>A Decimal value representing a date.
        ''' </returns>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public ReadOnly Property Value() As Decimal
            Get
                Dim dblValue As Decimal = 0
                Try
                    RaiseEvent GetValue(dblValue)
                Catch ex As CustomApplicationException
                    Throw ex
                Catch ex As Exception
                    ExceptionManager.Publish(ex)
                    Throw ex
                End Try
                If dblValue = cDefaultValue Then
                    Return 0
                Else
                    Return dblValue
                End If
            End Get
        End Property

        ''' --- Value --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Returns the value of the evaluated expression.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <returns>
        ''' </returns>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public ReadOnly Property Value(ByVal Sort As SortType) As String
            Get
                Dim dblValue As Decimal = 0
                Try
                    RaiseEvent GetValue(dblValue)
                Catch ex As CustomApplicationException
                    Throw ex
                Catch ex As Exception
                    ExceptionManager.Publish(ex)
                    Throw ex
                End Try

                If Sort = SortType.Descending Then
                    If dblValue = cDefaultValue Then
                        Return "0" & "~!Descending!~"
                    Else
                        Return dblValue.ToString & "~!Descending!~"
                    End If

                Else
                    If dblValue = cDefaultValue Then
                        Return "0"
                    Else
                        Return dblValue.ToString
                    End If
                End If

            End Get
        End Property

        ''' --- Getter -------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Getter.
        ''' </summary>
        ''' <param name="Sender"></param>
        ''' <param name="GetterArgs"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Function Getter(ByVal Sender As Object, ByVal GetterArgs As GetterArgs) As Boolean
            GetterArgs.FieldText = Me.Value.ToString
            GetterArgs.FieldValue = Me.Value
        End Function
    End Class
End Namespace
