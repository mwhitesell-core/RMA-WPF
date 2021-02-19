
Imports Core.DataAccess.SqlServer
Imports Core.DataAccess.Oracle
Imports Core.Framework
Imports Core.Framework.Core.Framework
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OracleClient
Imports System.IO
Imports System.Security
Imports System.Security.Permissions
Imports System.Text
Imports System.Xml

Namespace Core.ReportFramework

    Public Module ReportDataFunctions

#Region "Methods"

#Region "Public"

        '' --- AddDateFunction --------------------------------------------------
        '' <exclude/>
        '' 
        '' <summary>
        '' 	Wraps the date field within the appropriate date function code.
        '' </summary>
        '' <param name="Field">The field to add the function around.</param>
        '' <remarks>
        '' Returns a string with the date function
        '' </remarks>
        '' <example>
        '' 1. AddDateFunction("EMPLOYEE.START_DATE") will return 
        ''         " TO_NUMBER(TO_CHAR(EMPLOYEE.START_DATE, 'YYYYMMDD'))" <br/>
        '' </example>
        '' <history>
        '' 	[Campbell]	6/16/2005	Created
        '' </history>
        '' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Public Function AddDateFunction(ByVal Field As String) As String

            Dim sb As StringBuilder = New StringBuilder(255)

            If strDatabaseType Is Nothing OrElse strDatabaseType = cORACLE Then
                Return sb.Append("TO_NUMBER(TO_CHAR(").Append(Field).Append(", 'YYYYMMDD'))").ToString
            Else
                Return sb.Append("CONVERT(INTEGER, CONVERT(CHAR(8), ").Append(Field).Append(", 112))").ToString
            End If

        End Function

        Public Function Exists(ByVal rdr As Reader) As Boolean

            Return rdr.RecordExists

        End Function

        <SqlClientPermissionAttribute(SecurityAction.Assert)>
        Public Function GetDataSQL(ByVal ReportName As String, ByVal strSort As String, ByVal blnTempTable As Boolean) As String

            Dim sbSQL As New StringBuilder(String.Empty)
            Dim sbSort As New StringBuilder(String.Empty)

            Dim arrOrder As String()
            Dim strTempSort As String = String.Empty

            Dim intCount As Integer = 0

            Try
                If blnTempTable Then

                    If AddToDatabase Then
                        sbSQL.Append("SELECT * FROM ").Append(ReportName).Append("_TEMP")
                    Else
                        sbSQL.Append("SELECT * FROM #").Append(ReportName).Append("_TEMP")
                    End If


                Else
                    sbSQL.Append("SELECT * FROM ").Append(ReportName)
                End If

                If strSort.Trim.Length > 0 Then
                    strTempSort = strSort

                    If strTempSort.IndexOf("ORDER BY") > -1 Then
                        ' Remove the Order By clause if included.
                        strTempSort = Mid$(strTempSort, strTempSort.IndexOf("ORDER BY") + 2)
                    End If

                    ' Split up the order by fields.
                    arrOrder = strTempSort.Split(","c)

                    'For intCount = 0 To arrOrder.GetUpperBound(0)
                    '    If arrOrder(intCount).EndsWith(" ASC") Then
                    '        arrOrder(intCount) = arrOrder(intCount).Replace(" ASC", " collate Latin1_General_BIN ASC")
                    '    ElseIf arrOrder(intCount).EndsWith(" DESC") Then
                    '        arrOrder(intCount) = arrOrder(intCount).Replace(" DESC", " collate Latin1_General_BIN DESC")
                    '    Else
                    '         arrOrder(intCount) = arrOrder(intCount) + " collate Latin1_General_BIN"
                    '    End If
                    'Next

                    ' Remove the relation name from the field.
                    For intCount = 0 To arrOrder.GetUpperBound(0)
                        sbSort.Append(Mid$(arrOrder(intCount).ToString, arrOrder(intCount).ToString.IndexOf("."c) + 2) + ", ")
                    Next

                    ' Remove the last comma add to string.
                    strTempSort = Mid$(sbSort.ToString, 1, (sbSort.ToString).LastIndexOf(", "))

                    sbSQL.Append(" ORDER BY ").Append(strTempSort)
                End If

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogPath, ex)

            End Try

            Return sbSQL.ToString

        End Function

        <SqlClientPermissionAttribute(SecurityAction.Assert)>
        Public Function GetRangeSQL(ByVal strRange As String, ByVal Name As String, ByVal intDataType As BaseRDLClass.DataTypes, ByVal blnWhere As Boolean) As String

            Dim sbSQL As New StringBuilder(String.Empty)

            If blnWhere Then
                sbSQL.Append(" WHERE ")
            Else
                sbSQL.Append(" AND ")
            End If

            SetRange(strRange)

            If RangeStart.Trim <> String.Empty And RangeEnd.Trim <> String.Empty Then
                Select Case intDataType
                    Case BaseRDLClass.DataTypes.Character, BaseRDLClass.DataTypes.VarChar
                        sbSQL.Append("(").Append(Name).Append(" >= ").Append(StringToField(RangeStart)).Append(" AND ")
                        sbSQL.Append(Name).Append(" <= ").Append(StringToField(RangeEnd)).Append(")")

                    Case BaseRDLClass.DataTypes.Date, BaseRDLClass.DataTypes.DateTime
                        sbSQL.Append("(").Append(AddDateFunction(Name)).Append(" >= ").Append(AddDateFunction(RangeStart)).Append(" AND ")
                        sbSQL.Append(AddDateFunction(Name)).Append(" <= ").Append(AddDateFunction(RangeEnd)).Append(")")

                    Case BaseRDLClass.DataTypes.Float, BaseRDLClass.DataTypes.Integer, BaseRDLClass.DataTypes.Numeric, BaseRDLClass.DataTypes.SignedInteger
                        sbSQL.Append("(").Append(Name).Append(" >= ").Append(RangeStart).Append(" AND ")
                        sbSQL.Append(Name).Append(" <= ").Append(RangeEnd).Append(")")

                End Select
            ElseIf RangeStart.Trim <> String.Empty Then
                Select Case intDataType
                    Case BaseRDLClass.DataTypes.Character, BaseRDLClass.DataTypes.VarChar
                        sbSQL.Append(Name).Append(" = ").Append(StringToField(RangeStart))

                    Case BaseRDLClass.DataTypes.Date, BaseRDLClass.DataTypes.DateTime
                        sbSQL.Append(AddDateFunction(Name)).Append(" = ").Append(AddDateFunction(RangeStart))

                    Case BaseRDLClass.DataTypes.Float, BaseRDLClass.DataTypes.Integer, BaseRDLClass.DataTypes.Numeric, BaseRDLClass.DataTypes.SignedInteger
                        sbSQL.Append(Name).Append(" = ").Append(RangeStart)

                End Select
            Else
                sbSQL.Remove(0, sbSQL.Length)
            End If

            Return sbSQL.ToString

        End Function

        <SqlClientPermissionAttribute(SecurityAction.Assert)>
        Public Function GetTableOwner(ByVal strTableName As String, ByVal strConnectString As String) As String

            Dim strTableOwner As String
            Dim strSQLTable As StringBuilder

            Dim rdr As IDataReader = Nothing
            Dim SqlPermission As New SqlClientPermission(PermissionState.Unrestricted)

            SqlPermission.Assert()

            Try
                strTableOwner = New String(String.Empty)
                strSQLTable = New StringBuilder(String.Empty)

                If strDatabaseType = cORACLE Or strDatabaseType = String.Empty Then
                    strSQLTable.Append("SELECT * FROM user_tables ")
                    strSQLTable.Append(GetWhereCondition("table_name", strTableName, True))

                    rdr = OracleHelper.ExecuteReader(strConnectString, CommandType.Text, strSQLTable.ToString)
                ElseIf strDatabaseType = cSQLSERVER Then
                    strSQLTable.Append("Exec sp_MSforeachdb 'select ''?'' as DBName, name, xtype From ?..sysobjects where xtype = ''U'' and name like ''%")
                    strSQLTable.Append(strTableName).Append("%'' '")

                    rdr = SqlHelper.ExecuteReader(strConnectString, CommandType.Text, strSQLTable.ToString)
                End If

                Do While rdr.Read()
                    If rdr.Item("DBName").ToString.Trim <> String.Empty Then
                        strTableOwner = rdr.Item("DBName").ToString.Trim
                        Exit Do
                    End If
                Loop

                If strTableOwner.Trim = String.Empty Then
                    strTableOwner = cTEMP_SCHEMA
                End If

            Catch
                strTableOwner = cTEMP_SCHEMA

            Finally
                rdr.Close()
                rdr = Nothing

            End Try

            Return strTableOwner

        End Function

        Public Function GetTempTableWhereClauseString(ByVal Field1 As String, ByVal [Operator] As String, ByVal Field2 As Decimal) As String

            Dim sb As StringBuilder = New StringBuilder(String.Empty)
            Dim strWhere As String = String.Empty

            If Field2 = 0 Then
                If [Operator].Trim.Equals("=") Then
                    sb.Append(Field1).Append(" IS NULL ")
                ElseIf [Operator].Trim.Equals("<>") OrElse [Operator].Trim.Equals("!=") Then
                    sb.Append(Field1).Append(" IS NOT NULL ")
                Else
                    If [Operator].Trim.IndexOf("=") > -1 Then
                        sb.Append("(").Append(Field1).Append(" IS NULL OR ").Append(AddDateFunction(Field1)).Append(" ").Append([Operator]).Append(" 0)")
                    Else
                        sb.Append(AddDateFunction(Field1)).Append(" ").Append([Operator]).Append(" 0")
                    End If
                End If
            Else
                If [Operator].IndexOf("<") > -1 Then
                    sb.Append("(").Append(Field1).Append(" IS NULL OR ").Append(AddDateFunction(Field1)).Append(" ").Append([Operator]).Append(" ").Append(Field2).Append(")")
                Else
                    sb.Append(AddDateFunction(Field1)).Append(" ").Append([Operator]).Append(" ").Append(Field2)
                End If
            End If

            strWhere = sb.ToString

            Do While (strWhere.IndexOf("CONVERT(INTEGER, CONVERT(CHAR(8),") >= 0)
                Dim strColumn As String = String.Empty
                Dim strReplace As String = String.Empty
                Dim strOper As String = String.Empty
                Dim strDate As String = String.Empty
                Dim arrWhere() As String = strWhere.Split(" ")

                For i As Integer = 0 To arrWhere.Length - 1
                    If arrWhere(i) = "CONVERT(INTEGER," Then
                        strColumn = arrWhere(i + 2).Replace(",", "")
                        strOper = arrWhere(i + 4)
                        strDate = arrWhere(i + 5)
                        strDate = "'" & strDate.Substring(0, 4) + "/" & strDate.Substring(4, 2) + "/" & strDate.Substring(6, 2) & "'"
                        strReplace = arrWhere(i) & " " & arrWhere(i + 1) & " " & arrWhere(i + 2) & " " & arrWhere(i + 3) & " " & arrWhere(i + 4) & " " & arrWhere(i + 5).Substring(0, 8)
                        Exit For
                    End If
                Next

                strWhere = strWhere.Replace(strReplace, strColumn & " " & strOper & " " & strDate)
            Loop

            Return strWhere

        End Function

        ''' --- GetWhereClauseString --------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Generates a string value containing a SQL WHERE clause.
        ''' </summary>
        ''' <param name="Field1">The first field in the SQL statement.</param>
        ''' <param name="Operator">The Operator value.</param>
        ''' <param name="Field2">The second field in the SQL statement</param>
        ''' <param name="AddWhere">Indicates that this is the first field in the WHERE clause and the keyword WHERE is to be appended.  This is passed in using a variable.</param>
        ''' <remarks>
        ''' Returns a formatted SQL WHERE CLAUSE by concatenating the parameters Field1, Operator and Field2 for date fields to ensure that 
        ''' fields with a NULL are also returned if necessary.
        ''' </remarks>
        ''' <example>
        ''' 1. GetWhereClauseString("EMPLOYEE.START_DATE", "=", 0, True) will return 
        '''         " WHERE EMPLOYEE.START_DATE IS NULL" <br/>
        ''' 2. GetWhereClauseString("EMPLOYEE.START_DATE", "&lt;", 19991231, True) will return 
        '''         " WHERE (EMPLOYEE.START_DATE IS NULL OR TO_NUMBER(TO_CHAR(EMPLOYEE.START_DATE,'YYYYMMDD')) &lt; 19991231)" <br/>
        ''' 3. GetWhereClauseString(19991231, "&gt;", "EMPLOYEE.START_DATE", True) will return 
        '''         " WHERE (19991231 &gt; (TO_NUMBER(TO_CHAR(EMPLOYEE.START_DATE,'YYYYMMDD')) OR EMPLOYEE.START_DATE IS NULL)" <br/>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function GetWhereClauseString(ByVal Field1 As String, ByVal [Operator] As String, ByVal Field2 As String, ByRef AddWhere As Boolean) As String

            Dim sb As StringBuilder = New StringBuilder(String.Empty)

            If AddWhere Then
                sb.Append(" WHERE ")
            Else
                sb.Append(" AND ")
            End If

            sb.Append(GetWhereClauseString(Field1, [Operator], Field2))

            Return sb.ToString

        End Function

        ''' --- GetWhereClauseString --------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Generates a string value containing a SQL WHERE clause.
        ''' </summary>
        ''' <param name="Field1">The first field in the SQL statement.</param>
        ''' <param name="Operator">The Operator value.</param>
        ''' <param name="Field2">The second field in the SQL statement</param>
        ''' <remarks>
        ''' Returns a formatted SQL WHERE CLAUSE by concatenating the parameters Field1, Operator and Field2 for date fields to ensure that 
        ''' fields with a NULL are also returned if necessary.
        ''' </remarks>
        ''' <example>
        ''' 1. GetWhereClauseString("EMPLOYEE.START_DATE", "=", 0, True) will return 
        '''         " WHERE EMPLOYEE.START_DATE IS NULL" <br/>
        ''' 2. GetWhereClauseString("EMPLOYEE.START_DATE", "&lt;", 19991231, True) will return 
        '''         " WHERE (EMPLOYEE.START_DATE IS NULL OR TO_NUMBER(TO_CHAR(EMPLOYEE.START_DATE,'YYYYMMDD')) &lt; 19991231)" <br/>
        ''' 3. GetWhereClauseString(19991231, "&gt;", "EMPLOYEE.START_DATE", True) will return 
        '''         " WHERE (19991231 &gt; (TO_NUMBER(TO_CHAR(EMPLOYEE.START_DATE,'YYYYMMDD')) OR EMPLOYEE.START_DATE IS NULL)" <br/>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function GetWhereClauseString(ByVal Field1 As String, ByVal [Operator] As String, ByVal Field2 As String) As String

            Dim sb As StringBuilder = New StringBuilder(String.Empty)

            sb.Append(Field1).Append(" ").Append([Operator]).Append(" ").Append(Field2)

            Return sb.ToString

        End Function

        ''' --- GetWhereClauseString --------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Generates a string value containing a SQL WHERE clause.
        ''' </summary>
        ''' <param name="Field1">The first field in the SQL statement.</param>
        ''' <param name="Operator">The Operator value.</param>
        ''' <param name="Field2">The second field in the SQL statement</param>
        ''' <param name="AddWhere">Indicates that this is the first field in the WHERE clause and the keyword WHERE is to be appended.  This is passed in using a variable.</param>
        ''' <remarks>
        ''' Returns a formatted SQL WHERE CLAUSE by concatenating the parameters Field1, Operator and Field2 for date fields to ensure that 
        ''' fields with a NULL are also returned if necessary.
        ''' </remarks>
        ''' <example>
        ''' 1. GetWhereClauseString("EMPLOYEE.START_DATE", "=", 0, True) will return 
        '''         " WHERE EMPLOYEE.START_DATE IS NULL" <br/>
        ''' 2. GetWhereClauseString("EMPLOYEE.START_DATE", "&lt;", 19991231, True) will return 
        '''         " WHERE (EMPLOYEE.START_DATE IS NULL OR TO_NUMBER(TO_CHAR(EMPLOYEE.START_DATE,'YYYYMMDD')) &lt; 19991231)" <br/>
        ''' 3. GetWhereClauseString(19991231, "&gt;", "EMPLOYEE.START_DATE", True) will return 
        '''         " WHERE (19991231 &gt; (TO_NUMBER(TO_CHAR(EMPLOYEE.START_DATE,'YYYYMMDD')) OR EMPLOYEE.START_DATE IS NULL)" <br/>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function GetWhereClauseString(ByVal Field1 As String, ByVal [Operator] As String, ByVal Field2 As Decimal, ByRef AddWhere As Boolean) As String

            Dim sb As StringBuilder = New StringBuilder(String.Empty)

            If AddWhere Then
                sb.Append(" WHERE ")
            Else
                sb.Append(" AND ")
            End If

            sb.Append(GetWhereClauseString(Field1, [Operator], Field2))

            Return sb.ToString

        End Function

        ''' --- GetWhereClauseString --------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Generates a string value containing a SQL WHERE clause.
        ''' </summary>
        ''' <param name="Field1">The first field in the SQL statement.</param>
        ''' <param name="Operator">The Operator value.</param>
        ''' <param name="Field2">The second field in the SQL statement</param>
        ''' <remarks>
        ''' Returns a formatted SQL WHERE CLAUSE by concatenating the parameters Field1, Operator and Field2 for date fields to ensure that 
        ''' fields with a NULL are also returned if necessary.
        ''' </remarks>
        ''' <example>
        ''' 1. GetWhereClauseString("EMPLOYEE.START_DATE", "=", 0, True) will return 
        '''         " WHERE EMPLOYEE.START_DATE IS NULL" <br/>
        ''' 2. GetWhereClauseString("EMPLOYEE.START_DATE", "&lt;", 19991231, True) will return 
        '''         " WHERE (EMPLOYEE.START_DATE IS NULL OR TO_NUMBER(TO_CHAR(EMPLOYEE.START_DATE,'YYYYMMDD')) &lt; 19991231)" <br/>
        ''' 3. GetWhereClauseString(19991231, "&gt;", "EMPLOYEE.START_DATE", True) will return 
        '''         " WHERE (19991231 &gt; (TO_NUMBER(TO_CHAR(EMPLOYEE.START_DATE,'YYYYMMDD')) OR EMPLOYEE.START_DATE IS NULL)" <br/>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function GetWhereClauseString(ByVal Field1 As String, ByVal [Operator] As String, ByVal Field2 As Decimal) As String

            Dim sb As StringBuilder = New StringBuilder(String.Empty)

            If Field2 = 0 Then
                If [Operator].Trim.Equals("=") Then
                    sb.Append(Field1).Append(" IS NULL ")
                ElseIf [Operator].Trim.Equals("<>") OrElse [Operator].Trim.Equals("!=") Then
                    sb.Append(Field1).Append(" IS NOT NULL ")
                Else
                    If [Operator].Trim.IndexOf("=") > -1 Then
                        sb.Append("(").Append(Field1).Append(" IS NULL OR ").Append(AddDateFunction(Field1)).Append(" ").Append([Operator]).Append(" 0)")
                    Else
                        sb.Append(AddDateFunction(Field1)).Append(" ").Append([Operator]).Append(" 0")
                    End If
                End If
            Else
                If [Operator].IndexOf("<") > -1 Then
                    sb.Append("(").Append(Field1).Append(" IS NULL OR ").Append(AddDateFunction(Field1)).Append(" ").Append([Operator]).Append(" ").Append(Field2).Append(")")
                Else
                    sb.Append(AddDateFunction(Field1)).Append(" ").Append([Operator]).Append(" ").Append(Field2)
                End If
            End If

            Return sb.ToString

        End Function

        ''' --- GetWhereClauseString --------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Generates a string value containing a SQL WHERE clause.
        ''' </summary>
        ''' <param name="Field1">The first field in the SQL statement.</param>
        ''' <param name="Operator">The Operator value.</param>
        ''' <param name="Field2">The second field in the SQL statement</param>
        ''' <param name="AddWhere">Indicates that this is the first field in the WHERE clause and the keyword WHERE is to be appended.  This is passed in using a variable.</param>
        ''' <remarks>
        ''' Returns a formatted SQL WHERE CLAUSE by concatenating the parameters Field1, Operator and Field2 for date fields to ensure that 
        ''' fields with a NULL are also returned if necessary.
        ''' </remarks>
        ''' <example>
        ''' 1. GetWhereClauseString("EMPLOYEE.START_DATE", "=", 0, True) will return 
        '''         " WHERE EMPLOYEE.START_DATE IS NULL" <br/>
        ''' 2. GetWhereClauseString("EMPLOYEE.START_DATE", "&lt;", 19991231, True) will return 
        '''         " WHERE (EMPLOYEE.START_DATE IS NULL OR TO_NUMBER(TO_CHAR(EMPLOYEE.START_DATE,'YYYYMMDD')) &lt; 19991231)" <br/>
        ''' 3. GetWhereClauseString(19991231, "&gt;", "EMPLOYEE.START_DATE", True) will return 
        '''         " WHERE (19991231 &gt; (TO_NUMBER(TO_CHAR(EMPLOYEE.START_DATE,'YYYYMMDD')) OR EMPLOYEE.START_DATE IS NULL)" <br/>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function GetWhereClauseString(ByVal Field1 As Decimal, ByVal [Operator] As String, ByVal Field2 As String, ByRef AddWhere As Boolean) As String

            Dim sb As StringBuilder = New StringBuilder(String.Empty)

            If AddWhere Then
                sb.Append(" WHERE ")
            Else
                sb.Append(" AND ")
            End If

            sb.Append(GetWhereClauseString(Field1, [Operator], Field2))

            Return sb.ToString

        End Function

        ''' --- GetWhereClauseString --------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Generates a string value containing a SQL WHERE clause.
        ''' </summary>
        ''' <param name="Field1">The first field in the SQL statement.</param>
        ''' <param name="Operator">The Operator value.</param>
        ''' <param name="Field2">The second field in the SQL statement</param>
        ''' <remarks>
        ''' Returns a formatted SQL WHERE CLAUSE by concatenating the parameters Field1, Operator and Field2 for date fields to ensure that 
        ''' fields with a NULL are also returned if necessary.
        ''' </remarks>
        ''' <example>
        ''' 1. GetWhereClauseString("EMPLOYEE.START_DATE", "=", 0, True) will return 
        '''         " WHERE EMPLOYEE.START_DATE IS NULL" <br/>
        ''' 2. GetWhereClauseString("EMPLOYEE.START_DATE", "&lt;", 19991231, True) will return 
        '''         " WHERE (EMPLOYEE.START_DATE IS NULL OR TO_NUMBER(TO_CHAR(EMPLOYEE.START_DATE,'YYYYMMDD')) &lt; 19991231)" <br/>
        ''' 3. GetWhereClauseString(19991231, "&gt;", "EMPLOYEE.START_DATE", True) will return 
        '''         " WHERE (19991231 &gt; (TO_NUMBER(TO_CHAR(EMPLOYEE.START_DATE,'YYYYMMDD')) OR EMPLOYEE.START_DATE IS NULL)" <br/>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Function GetWhereClauseString(ByVal Field1 As Decimal, ByVal [Operator] As String, ByVal Field2 As String) As String

            Dim sb As StringBuilder = New StringBuilder(String.Empty)

            If Field1 = 0 Then
                If [Operator].Trim.Equals("=") Then
                    sb.Append(Field2).Append(" IS NULL ")
                Else
                    If [Operator].Trim.IndexOf("=") > -1 Then
                        sb.Append("(").Append(Field2).Append(" IS NULL OR 0 ").Append([Operator]).Append(" ").Append(AddDateFunction(Field2)).Append(")")
                    Else
                        sb.Append("0 ").Append([Operator]).Append(" ").Append(AddDateFunction(Field2))
                    End If
                End If
            Else
                If [Operator].IndexOf(">") > -1 Then
                    sb.Append("(").Append(Field2).Append(" IS NULL OR ").Append(Field1).Append(" ").Append([Operator]).Append(" ").Append(AddDateFunction(Field2)).Append(")")
                Else
                    sb.Append(Field1).Append(" ").Append([Operator]).Append(" ").Append(AddDateFunction(Field2))
                End If
            End If

            Return sb.ToString

        End Function

        <SqlClientPermissionAttribute(SecurityAction.Assert)>
        Public Function GetWhereCondition(ByVal FieldName As String, ByVal Value As String, Optional ByVal blnAddWhere As Boolean = False,
                          Optional ByVal IsBlankLiteral As Boolean = False, Optional ByVal IsGeneric As Boolean = False) As String

            Dim strReturnValue As StringBuilder = New StringBuilder("")

            Try

                If Value.Trim.Length > 0 Then
                    If blnAddWhere = True Then
                        strReturnValue.Append(" WHERE ")
                        blnAddWhere = False
                    Else
                        strReturnValue.Append(" AND ")
                    End If

                    strReturnValue.Append(FieldName)

                    If m_strGenericRetrievalCharacter.Length = 0 Then m_strGenericRetrievalCharacter = "@"

                    If IsGeneric AndAlso Value.EndsWith(m_strGenericRetrievalCharacter + m_strGenericRetrievalCharacter) Then
                        'e.g. If the user enters M@@, all data records will be retrieved where the index begins with letter M to the highest value (that is the last segment value).
                        Value = Value.Replace(m_strGenericRetrievalCharacter, String.Empty)
                        If Value.Equals(String.Empty) Then
                            'In case user type one or more "@" (or character set as GenericRetrievalCharacter)
                            strReturnValue.Append(" LIKE '%'")
                        Else
                            strReturnValue.Append(" >= ")
                            strReturnValue.Append(StringToField(Value.Trim))
                        End If
                    ElseIf Value.IndexOf(m_strGenericRetrievalCharacter) >= 0 Then
                        Value = Replace(Value, m_strGenericRetrievalCharacter, "%")
                        strReturnValue.Append(" Like ")
                        strReturnValue.Append(StringToField(Value.Trim))
                    Else
                        strReturnValue.Append(" = ")
                        strReturnValue.Append(StringToField(Value))
                    End If
                End If

            Catch ex As Exception

            End Try

            Return strReturnValue.ToString

        End Function

        <SqlClientPermissionAttribute(SecurityAction.Assert)>
        Public Sub SetReportParameters(ByVal stcParameters As Object)

            Dim intCount As Integer = 1

            Try
                With stcParameters
                    astrScreenParameters = .astrScreenParameters
                    strDatabaseType = .strDatabaseType.ToString
                    strConnString = .strConnString.ToString
                    strUserID = .strReportRunBy.ToString
                    strReportFormat = .strReportFormat.ToString
                    strReportFileName = .strReportFileName.ToString
                    strLanguage = IIf(.strReportLanguage.ToString = "Eng", "0001", "0002")
                End With

            Catch ex As Exception
                RecordReportError(GetLogFilePath(""), ex)

            End Try

        End Sub

        <SqlClientPermissionAttribute(SecurityAction.Assert)>
        Public Function TableSetup(ByVal strTableName As String, ByVal strConnectionString As String) As Boolean

            Dim strSQL As New StringBuilder(String.Empty)

            Dim rdr As IDataReader = Nothing

            Dim strUser As String = String.Empty
            Dim strSearch As String = String.Empty

            Dim intStart As Integer = 0
            Dim intEnd As Integer = 0

            Dim blnFound As Boolean = False

            Dim SqlPermission As New SqlClientPermission(PermissionState.Unrestricted)

            Try
                SqlPermission.Assert()

                If strDatabaseType = cORACLE Then
                    strSearch = RemoveSpaces(strConnectionString)
                    intStart = InStr(strSearch, "UserID=") + 7
                    intEnd = InStr(intStart, strSearch, ";")
                    strUser = Mid(strSearch, intStart, intEnd - intStart)

                    strSQL.Append("DECLARE")
                    strSQL.Append("    V_COUNT NUMBER(38);")
                    strSQL.Append("BEGIN")

                    strSQL.Append("    SELECT COUNT(*) INTO V_COUNT FROM ALL_TABLES ")
                    strSQL.Append("        WHERE OWNER = ").Append(StringToField(UCase(strUser)))
                    strSQL.Append("          AND TABLE_NAME = ").Append(StringToField(strTableName)).Append(" ;")

                    strSQL.Append("    IF V_COUNT <> 0 THEN")
                    strSQL.Append("        EXECUTE IMMEDIATE 'DROP TABLE ").Append(UCase(strUser)).Append(".").Append(strTableName).Append("';")
                    strSQL.Append("    END IF;")
                    strSQL.Append("END;")

                    OracleHelper.ExecuteNonQuery(strConnectionString, CommandType.Text, strSQL.ToString)

                    blnFound = True
                ElseIf strDatabaseType = cSQLSERVER Then
                    strSQL.Append("SELECT * FROM sysobjects WHERE xtype = 'u' and name = ")
                    If strTableName.IndexOf(".") > -1 Then
                        strSQL.Append(StringToField(strTableName.Substring(strTableName.LastIndexOf(".") + 1)))
                    Else
                        strSQL.Append(StringToField(strTableName))
                    End If

                    rdr = SqlHelper.ExecuteReader(strConnectionString, CommandType.Text, strSQL.ToString)

                    If rdr.Read() Then
                        blnFound = True
                    Else
                        blnFound = False
                    End If
                End If

            Catch ex As Exception
                blnFound = False

            Finally
                rdr.Close()
                rdr.Dispose()

            End Try

            Return blnFound

        End Function

#End Region

#End Region

    End Module

    Public Class Reader

#Region "Declarations"

#Region "Variables"

        Private m_rdr As IDataReader
        Private m_dst As DataSet
        Private m_dtb As DataTable

        Private m_intCurrentRow As Integer = 0

        Public m_blnAccessOK As Boolean = False
        Private m_blnIsOptional As Boolean = False
        Private m_blnOptionalRead As Boolean = False
        Private m_blnIsParallel As Boolean = False

#End Region

#End Region

#Region " Properties..."

        Public WriteOnly Property GetData() As IDataReader
            Set(ByVal Value As IDataReader)
                m_rdr = Value
            End Set
        End Property

        Public WriteOnly Property GetOptional() As IDataReader
            Set(ByVal Value As IDataReader)
                m_blnIsOptional = True
                m_blnOptionalRead = False
                m_rdr = Value
            End Set
        End Property

        'Private WriteOnly Property GetParallel() As IDataReader
        '    Set(ByVal Value As IDataReader)
        '        m_blnIsParallel = True
        '        m_rdr = Value
        '    End Set
        'End Property

        'Private WriteOnly Property GetOptionalParallel() As IDataReader
        '    Set(ByVal Value As IDataReader)
        '        m_blnIsOptional = True
        '        m_blnOptionalRead = False
        '        m_blnIsParallel = True
        '        m_rdr = Value
        '    End Set
        'End Property

        Public WriteOnly Property GetDataSet() As DataSet
            Set(ByVal Value As DataSet)
                m_dst = Value
            End Set
        End Property

        Public WriteOnly Property GetDataTable() As DataTable
            Set(ByVal Value As DataTable)
                m_dtb = Value
                m_intCurrentRow = 0
            End Set
        End Property

        Public WriteOnly Property GetOptionalTable() As DataTable
            Set(ByVal Value As DataTable)
                m_blnIsOptional = True
                m_blnOptionalRead = False
                m_dtb = Value
                m_intCurrentRow = 0
            End Set
        End Property

#End Region

#Region "Methods"

#Region "Private"

        Private Function CurrentRow() As Integer

            Return m_intCurrentRow - 1

        End Function

        Private Function HasRows() As Boolean

            If UseReader() Then
                Return CType(m_rdr, System.Data.SqlClient.SqlDataReader).HasRows
            Else
                Return False
            End If

        End Function

        Private Function UseReader() As Boolean

            Return (m_dtb Is Nothing)

        End Function

#End Region

#Region "Public"

        Public Sub Close()

            If UseReader() Then
                If Not m_rdr Is Nothing AndAlso Not m_rdr.IsClosed Then
                    m_rdr.Close()
                End If
                m_rdr = Nothing
            Else
                m_dtb.Dispose()
            End If

        End Sub

        Public Function Exists(ByVal rdr As Reader) As Boolean

            Return rdr.RecordExists

        End Function

        Public Function GetDate(ByVal Name As String) As Date

            Dim returnValue As Date

            Try
                If UseReader() Then
                    If Not m_blnAccessOK OrElse m_rdr.Item(Name) Is System.DBNull.Value Then
                        returnValue = New Date(0)
                    Else
                        returnValue = CType(m_rdr.Item(Name), Date)
                    End If
                Else
                    If CurrentRow() >= 0 Then
                        If m_dtb.Rows(CurrentRow).Item(Name) Is System.DBNull.Value Then
                            returnValue = New Date(0)
                        Else
                            Try
                                returnValue = CType(m_dtb.Rows(CurrentRow).Item(Name), Date)
                            Catch ex As Exception
                                returnValue = New DateTime(m_dtb.Rows(CurrentRow).Item(Name).ToString.Substring(0, 4), m_dtb.Rows(CurrentRow).Item(Name).ToString.Substring(4, 2), m_dtb.Rows(CurrentRow).Item(Name).ToString.Substring(6, 2))
                            End Try

                        End If
                    Else
                        returnValue = New Date(0)
                    End If
                End If

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogPath, ex)

            End Try

            Return returnValue
        End Function

        Public Function GetNumber(ByVal Name As String) As Decimal

            Dim returnValue As Decimal

            Try
                If UseReader() Then
                    If Not m_blnAccessOK OrElse m_rdr.Item(Name) Is System.DBNull.Value Then
                        returnValue = 0D
                    Else
                        returnValue = CType(m_rdr.Item(Name), Decimal)
                    End If
                Else
                    If CurrentRow() >= 0 Then
                        'If Not m_blnAccessOK OrElse m_dtb.Rows(CurrentRow).Item(Name) Is System.DBNull.Value Then
                        If m_dtb.Rows(CurrentRow).Item(Name) Is System.DBNull.Value Then
                            returnValue = 0D
                        Else
                            returnValue = CType(m_dtb.Rows(CurrentRow).Item(Name), Decimal)
                        End If
                    Else
                        returnValue = 0D
                    End If
                End If

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogPath, ex)

            End Try

            Return returnValue

        End Function

        Public Function GetString(ByVal Name As String) As String

            Dim strValue As String = String.Empty

            Try
                If UseReader() Then
                    If Not m_blnAccessOK OrElse m_rdr.Item(Name) Is System.DBNull.Value Then
                        strValue = String.Empty
                    Else
                        strValue = m_rdr.Item(Name).ToString.TrimEnd
                    End If
                Else
                    If m_dtb.Rows.Count > 0 Then
                        If m_dtb.Columns(Name).DataType.ToString = "System.String" Then
                            If CurrentRow() >= 0 Then
                                'If Not m_blnAccessOK OrElse m_dtb.Rows(CurrentRow).Item(Name) Is System.DBNull.Value Then
                                If m_dtb.Rows(CurrentRow).Item(Name) Is System.DBNull.Value Then
                                    strValue = String.Empty
                                Else
                                    strValue = m_dtb.Rows(CurrentRow).Item(Name).ToString.TrimEnd
                                End If
                            Else
                                strValue = String.Empty
                            End If
                        Else
#If TARGET_DB = "INFORMIX" Then

                Dim itemSize As Integer = 0

                GetDictionaryInfo(Name, itemSize)
                strValue = ASCII(GetNumber(Name), itemSize)
#End If
                        End If
                    Else
                        strValue = String.Empty
                    End If
                End If

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogPath, ex)

            End Try

            Return strValue

        End Function

        Public Function Read() As Boolean

            Try
                If Not m_blnOptionalRead Then
                    If UseReader() Then
                        If Not m_rdr Is Nothing Then
                            m_blnAccessOK = m_rdr.Read
                        Else
                            Return False
                        End If
                    Else
                        m_intCurrentRow += 1

                        If m_dtb.Rows.Count >= m_intCurrentRow Then
                            m_blnAccessOK = True
                        Else
                            m_intCurrentRow = m_dtb.Rows.Count
                            m_blnAccessOK = False
                        End If
                    End If
                Else
                    ' Should only enter this code on last read
                    ' for Optional reader.
                    Return False
                End If

                If m_blnIsOptional Then
                    If Not m_dtb Is Nothing Then
                        If (m_dtb.Rows.Count = 0 OrElse m_dtb.Rows.Count = m_intCurrentRow) Then
                            m_blnOptionalRead = True
                        End If
                    Else
                        m_blnOptionalRead = True
                    End If

                    Return True
                Else
                    Return m_blnAccessOK
                End If

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogPath, ex)
                Return False

            End Try

        End Function

        Public Function RecordExists() As Boolean

            Return m_blnAccessOK

        End Function

#End Region

#End Region

    End Class

End Namespace
