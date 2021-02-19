Option Strict Off

Imports System.ComponentModel
Imports Core.ExceptionManagement
Imports System.Text

'for StringBuilder

Namespace Core.Framework
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: RangeList
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of RangeList.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
        <Serializable(), _
            EditorBrowsable (EditorBrowsableState.Advanced)> _
    Public Class RangeList
        Inherits ArrayList

#Region "AddRange Overloaded Method Implementations"

        'Function is used to add a range of Character Values to the values for a field.
        ''' --- AddRange -----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of AddRange.
        ''' </summary>
        ''' <param name="StartofStringRange"></param>
        ''' <param name="EndofStringRange"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [mayur] 9/12/2005 Changed to consider "-" as part of the valid value by replacing "~!" with "-"
        '''     [mayur] 8/22/2005 Changed to Strip Quotes from passed Value
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Overloads Sub AddRange (ByVal StartofStringRange As String, ByVal EndofStringRange As String)
            Dim arrNewStringValues(2) As String

            Try
                If StartofStringRange = "" Then

                    Dim _
                        ex As _
                            New ArgumentException ( _
                                                   "Start of String Range cannot be <blank>. This must be a valid alphanumeric string.", _
                                                   "AddRange::StartofStringRange")
                    Throw ex

                End If

                If EndofStringRange = "" Or StartofStringRange = EndofStringRange Then
                    AddRange (CleanUpValue (StartofStringRange))
                Else
                    If StartofStringRange > EndofStringRange Then
                        Dim _
                            ex As _
                                New ArgumentException ("Start of String Range must be less than End of String Range", _
                                                       "AddRange::StartofStringRange")
                        Throw ex
                    Else
                        arrNewStringValues (0) = CleanUpValue (StartofStringRange)
                        arrNewStringValues (1) = CleanUpValue (EndofStringRange)

                        Me.Add (arrNewStringValues)
                    End If
                End If

            Catch ex As Exception

                ExceptionManager.Publish (ex)
                Throw (ex)

            End Try

        End Sub

        'Function is used to add a single Character value to the range of values for a field.
        ''' --- AddRange -----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of AddRange.
        ''' </summary>
        ''' <param name="StringValue"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        '''     [mayur] 8/22/2005 Changed to Stip Quotes from passed Value
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Overloads Sub AddRange (ByVal StringValue As String)

            Try
                If StringValue = "" Then
                    Dim _
                        ex As _
                            New ArgumentException ( _
                                                   "String Value cannot be <blank>. This must be a valid alphanumeric string.", _
                                                   "AddRange::StringValue")
                    Throw ex
                Else
                    Me.Add (CleanUpValue (StringValue))
                End If

            Catch ex As Exception

                ExceptionManager.Publish (ex)
                Throw (ex)

            End Try

        End Sub

        ''' --- CleanUpValue -----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Removes leading and trailing Single Quote from the passed Value. Also replaces ~! with -.
        ''' </summary>
        ''' <param name="Value"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[mayur]	8/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        Private Function CleanUpValue (ByVal Value As String) As String
            'Strip Leading and Trailing "Single Quote"
            If Value.StartsWith ("'") AndAlso Value.EndsWith ("'") AndAlso Value.Length > 1 Then
                Value = Value.Substring (1, Value.Length - 2)
            End If

            'Return Value after replacing Hyphen character
            Return Value.Replace ("~!", "-")
        End Function

        'Function is used to add a range of Decimal Values to the values for a field.
        ''' --- AddRange -----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of AddRange.
        ''' </summary>
        ''' <param name="StartofNumericRange"></param>
        ''' <param name="EndofNumericRange"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Overloads Sub AddRange (ByVal StartofNumericRange As Decimal, ByVal EndofNumericRange As Decimal)
            Dim newArray(1) As Decimal

            Try
                If EndofNumericRange.Equals (Nothing) Or StartofNumericRange = EndofNumericRange Then

                    AddRange (StartofNumericRange)
                Else
                    If StartofNumericRange > EndofNumericRange Then
                        Dim _
                            ex As _
                                New ArgumentException ("Start of Numeric Range must be less than End of Numeric Range", _
                                                       "AddRange::StartofNumericRange")
                        Throw ex
                    Else
                        newArray (0) = StartofNumericRange
                        newArray (1) = EndofNumericRange

                        Me.Add (newArray)
                    End If
                End If

            Catch ex As Exception

                ExceptionManager.Publish (ex)
                Throw (ex)

            End Try

        End Sub

        'Function is used to add a single Decimal value to the range of values for a field.
        ''' --- AddRange -----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of AddRange.
        ''' </summary>
        ''' <param name="NumericValue"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Overloads Sub AddRange (ByVal NumericValue As Decimal)

            Try
                Me.Add (NumericValue)

            Catch ex As Exception

                ExceptionManager.Publish (ex)
                Throw (ex)

            End Try

        End Sub

#End Region

#Region "IsValueInRange Overloaded Method Implementations"

        'Checks to see if the Character Value is in the range of acceptable values for the Range List
        ''' --- IsValueInRange -----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of IsValueInRange.
        ''' </summary>
        ''' <param name="StringValue"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Overloads Function IsValueInRange (ByVal StringValue As String) As Boolean
            Dim i As Integer

            Try
                If StringValue = "" Then
                    Dim _
                        ex As _
                            New ArgumentException ( _
                                                   "String Value cannot be <blank>. This must be a valid alphanumeric string.", _
                                                   "IsValueInRange::StringValue")
                    Throw ex
                End If

                If Me.Count = 0 Then Return True

                For i = 0 To Me.Count - 1
                    If IsArray (Me (i)) Then
                        If Me (i) (0).GetType.Equals (GetType (String)) Then
                            If (Me (i) (0) <= StringValue) And (StringValue <= Me (i) (1)) Then Return True
                        End If
                    Else
                        'Temporarily trimmed to compare the string values
                        'TODO: This behaviour needs to be confirmed with legacy
                        If Me (i).GetType.Equals (GetType (String)) Then _
                            If CStr (Me (i)).Replace ("!~", "-").Trim = StringValue.Trim Then Return True
                    End If
                Next

                Return False

            Catch ex As Exception

                ExceptionManager.Publish (ex)
                Throw (ex)

            End Try

        End Function

        'Checks to see if the Numeric Value is in the range of acceptable values for the Range List
        ''' --- IsValueInRange -----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of IsValueInRange.
        ''' </summary>
        ''' <param name="NumericValue"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Overloads Function IsValueInRange (ByVal NumericValue As Decimal, _
                                                  Optional ByVal InputScale As Integer = 0) As Boolean
            Dim i As Integer

            Try

                If Me.Count = 0 Then Return True

                For i = 0 To Me.Count - 1
                    If IsArray (Me (i)) Then

                        If IsNumeric (Me (i) (0)) Then
                            If _
                                ((Me (i) (0)*10^InputScale) <= NumericValue) And _
                                (NumericValue <= (Me (i) (1)*10^InputScale)) Then Return True

                        End If

                    Else
                        If IsNumeric (Me (i)) Then If (Me (i)*10^InputScale) = NumericValue Then Return True

                    End If

                Next

                Return False

            Catch ex As Exception

                ExceptionManager.Publish (ex)
                Throw (ex)

            End Try

        End Function

#End Region

#Region "ToString (Required by Core DevStudio for DLL Viewer)"

        'overrides the ToString function to display something more useful than "Core.Framework.RangeList"
        ''' --- ToString -----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of ToString.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Overrides Function ToString() As String
            Dim i As Integer
            Dim sb As New StringBuilder

            Try
                If Me.Count = 0 Then
                    Return ""
                End If

                For i = 0 To Me.Count - 1
                    If IsArray (Me (i)) Then
                        If Me (i) (0).GetType.Equals (GetType (String)) Then
                            sb.Append ("'" + Me (i) (0) + "'-'" + Me (i) (1) + "'")
                            '  'str1'-'str2'
                        Else
                            sb.Append ("(" + CDbl (Me (i) (0)).ToString + ")-(" + CDbl (Me (i) (1)).ToString + ")")
                            ' (n1)-(n2)
                        End If
                    Else
                        If Me (i).GetType.Equals (GetType (String)) Then
                            sb.Append ("'" + Me (i) + "'")
                            '  'str1'
                        Else
                            sb.Append ("(" + CDbl (Me (i)).ToString + ")")
                            '  (n1)
                        End If
                    End If

                    If (i < Me.Count - 1) Then
                        sb.Append (",")
                    End If
                Next

                Return sb.ToString

            Catch ex As Exception

                ExceptionManager.Publish (ex)
                Throw (ex)

            End Try

        End Function

        'NOTE: we could also use a FromString function, or even better a constructor that takes a string. It's quite trivial to add them now, since the code is written and tested
        'already. See Core.Tools.XMLTools.vb, the function StringToRangeList; also see Core.Tools.Mdi.vb, the function test_RangeList.
        'I'm not adding them yet because I'm not sure the syntax I picked is perfect. If the strings in a range list need to include single quotes, then that function will require
        'improvement to accept two single quotes in the middle of a string and think of them as just another character.

#End Region
    End Class
End Namespace

