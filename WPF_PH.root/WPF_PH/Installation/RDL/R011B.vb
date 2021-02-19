#Region "Screen Comments"

' DOC: R011B.QZS
' DOC: PHYSICIAN REVENUE ANALYSIS BY DOCTOR (SUMMARY REPORT)
' DOC: SORT BY CLINIC BY CLASS
' DOC: RUN FOR: MUMC DIAGNOSTICS
' PROGRAM PURPOSE : REVENUE ANALYSIS BY DOCTOR (SUMMARY REPORT)
' R011.CB CONVERSTION TO POWERHOUSE R011B.QZS
' THIS IS THE FIRST PART OF 3 PROGRAMS APPEND
' R011B.TXT TO END OF R011A.TXT
' DATE       WHO       DESCRIPTION
' 92/05/26   YASEMIN   ORIGINAL
' 2010/02/04 yas       - add new clinic 66
' Feb/19/2001 A.A  Increased size of docrev-mtd-in-svc and
' docrev-mtd-out-svc to 4 digits
' Dec/17/2003 A.A. alpha doctor nbr

#End Region

Imports Core.DataAccess.SqlServer
Imports Core.Framework
Imports Core.Framework.Core.Framework
Imports Core.ReportFramework
Imports Core.ReportFramework.ReportFunctions
Imports Core.ReportFramework.SessionInfo
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Web.Services.Protocols

Public Class R011B
    Inherits BaseRDLClass

#Region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

	Protected Const REPORT_NAME As String = "R011B"
	Protected Const REPORT_HAS_PARAMETERS As Boolean = False

	' Data Helpers.
	Private rdrF050_DOC_REVENUE_MSTR As New Reader
	Private rdrF020_DOCTOR_MSTR As New Reader
	Private rdrICONST_MSTR_REC As New Reader
	Private rdrF070_DEPT_MSTR As New Reader
#End Region

#Region " Renaissance Data "

	Public Function GetDataSet(ByVal strConnection As String, ByVal arrParameters() As String, ByVal strReportAssembly As String, ByVal blnDebug As Boolean) As DataSet
		
		Try
			' Set Report Properties...
			ReportName = REPORT_NAME
			ReportHasParameters = REPORT_HAS_PARAMETERS
			ConfigFile = strReportAssembly
			DebugReport = blnDebug

			Sort = "DOCREV_CLINIC_1_2 ASC, DOC_FULL_PART_IND ASC"

			' Start report data processing.
			ProcessData(strConnection, arrParameters)

		Catch ex As Exception
			' Write the exception to the log file.
			RecordReportError(strReportLogPath, ex)

		End Try

		Return ReportData

	End Function

#End Region

#Region " Renaissance Statements "

#Region " ACCESS "

	Private Sub Access_F050_DOC_REVENUE_MSTR() 
		
		Dim strSQL As StringBuilder = New StringBuilder(String.Empty)

		strSQL.Append("SELECT ")
		strSQL.Append("DOCREV_DOC_NBR, ")
		strSQL.Append("DOCREV_CLINIC_1_2, ")
		strSQL.Append("DOCREV_DEPT, ")
		strSQL.Append("DOCREV_CLINIC_1_2, ")
	strSQL.Append(" DOCREV_DEPT, ")
	strSQL.Append(" DOCREV_DOC_NBR, ")
	strSQL.Append(" DOCREV_LOCATION, ")
	strSQL.Append(" DOCREV_OMA_CODE, ")
	strSQL.Append(" DOCREV_OMA_SUFF, ")
	strSQL.Append(" DOCREV_ADJ_CD_SUB_TYPE, ")
		strSQL.Append("DOCREV_LOCATION, ")
		strSQL.Append("DOCREV_MTD_IN_SVC, ")
		strSQL.Append("DOCREV_MTD_OUT_SVC, ")
		strSQL.Append("DOCREV_MTD_IN_REC, ")
		strSQL.Append("DOCREV_MTD_OUT_REC, ")
		strSQL.Append("DOCREV_YTD_IN_SVC, ")
		strSQL.Append("DOCREV_YTD_OUT_SVC, ")
		strSQL.Append("DOCREV_YTD_IN_REC, ")
		strSQL.Append("DOCREV_YTD_OUT_REC ")
		strSQL.Append("FROM INDEXED.dbo.F050_DOC_REVENUE_MSTR ")

		strSQL.Append(Choose())

		rdrF050_DOC_REVENUE_MSTR.GetDataTable = SQLHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString)

		strSQL = Nothing

	End Sub

	Private Sub Link_F020_DOCTOR_MSTR() 
		
		Dim strSQL As StringBuilder = New StringBuilder(String.Empty)

		'TODO: Check the 'WHERE' and 'AND' clauses are correct.
		strSQL.Append("SELECT ")
		strSQL.Append("DOC_NBR, ")
		strSQL.Append("DOC_FULL_PART_IND, ")
		strSQL.Append("DOC_NAME, ")
		strSQL.Append("DOC_INIT1, ")
	strSQL.Append(" DOC_INIT2, ")
	strSQL.Append(" DOC_INIT3 ")
		strSQL.Append("FROM INDEXED.dbo.F020_DOCTOR_MSTR ")
		strSQL.Append("WHERE ")
		strSQL.Append("DOC_NBR = ").Append(StringToField(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_DOC_NBR")))

		rdrF020_DOCTOR_MSTR.GetOptionalTable = SQLHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString)

		strSQL = Nothing

	End Sub

	Private Sub Link_ICONST_MSTR_REC() 
		
		Dim strSQL As StringBuilder = New StringBuilder(String.Empty)

		'TODO: Check the 'WHERE' and 'AND' clauses are correct.
		strSQL.Append("SELECT ")
		strSQL.Append("ICONST_CLINIC_NBR_1_2, ")
		strSQL.Append("ICONST_DATE_PERIOD_END_YY, ")
	strSQL.Append(" ICONST_DATE_PERIOD_END_MM, ")
	strSQL.Append(" ICONST_DATE_PERIOD_END_DD, ")
		strSQL.Append("ICONST_CLINIC_NBR, ")
		strSQL.Append("ICONST_CLINIC_NAME ")
		strSQL.Append("FROM INDEXED.dbo.ICONST_MSTR_REC ")
		strSQL.Append("WHERE ")
		strSQL.Append("ICONST_CLINIC_NBR_1_2 = ( NConvert ( rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_CLINIC_1_2")  ) )))

		rdrICONST_MSTR_REC.GetOptionalTable = SQLHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString)

		strSQL = Nothing

	End Sub

	Private Sub Link_F070_DEPT_MSTR() 
		
		Dim strSQL As StringBuilder = New StringBuilder(String.Empty)

		'TODO: Check the 'WHERE' and 'AND' clauses are correct.
		strSQL.Append("SELECT ")
		strSQL.Append("DEPT_NBR ")
		strSQL.Append("FROM INDEXED.dbo.F070_DEPT_MSTR ")
		strSQL.Append("WHERE ")
		strSQL.Append("DEPT_NBR = ").Append(StringToField(rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_DEPT")))

		rdrF070_DEPT_MSTR.GetOptionalTable = SQLHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString)

		strSQL = Nothing

	End Sub

#End Region

#Region " CHOOSE "

	Private Function Choose() As String
		
		Dim strChoose As New StringBuilder(String.Empty)

		'TODO: CHOOSE Statement - May require manual changes.
		strChoose.Append(GetWhereCondition("DOCREV_KEY", "60@", True))


		Return strChoose.ToString

	End Function

#End Region

#Region " SELECT IF "

#End Region

#Region " DEFINES "
	Private Function X_CLASS() As String

		Dim strReturnValue As String = String.Empty

		Try
			If Null( rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND") ) = Null( "F") Then
	 strReturnValue =   "FULL TIME"
	  elseif Null( rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND") ) = Null( "P") Then
	  strReturnValue =   "PART TIME"
	  elseif Null( rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND") ) = Null( "C") Then
	  strReturnValue =   "CLINICAL SCHOLARS"
	  elseif Null( rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND") ) = Null( "S") Then
	  strReturnValue =   "OTHER"
	              End If

		Catch ex As Exception
			' Write the exception to the log file.
			RecordReportError(strReportLogPath, ex)

		End Try
		
		Return strReturnValue

	End Function
	Private Function X_SVC_MTD_IN() As Decimal

		Dim decReturnValue As Decimal = 0D

		Try
			If Null( rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")  ) <> Null( "MISC") Then
	 decReturnValue =   rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_IN_SVC") 
	              End If

		Catch ex As Exception
			' Write the exception to the log file.
			RecordReportError(strReportLogPath, ex)

		End Try
		
		Return decReturnValue

	End Function
	Private Function X_SVC_MTD_OUT() As Decimal

		Dim decReturnValue As Decimal = 0D

		Try
			If Null( rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")  ) <> Null( "MISC") Then
	 decReturnValue =   rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_OUT_SVC") 
	              End If

		Catch ex As Exception
			' Write the exception to the log file.
			RecordReportError(strReportLogPath, ex)

		End Try
		
		Return decReturnValue

	End Function
	Private Function X_AMT_MTD_IN() As Decimal

		Dim decReturnValue As Decimal = 0D

		Try
			If Null( rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")  ) <> Null( "MISC") Then
	 decReturnValue =   rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_IN_REC") 
	              End If

		Catch ex As Exception
			' Write the exception to the log file.
			RecordReportError(strReportLogPath, ex)

		End Try
		
		Return decReturnValue

	End Function
	Private Function X_AMT_MTD_OUT() As Decimal

		Dim decReturnValue As Decimal = 0D

		Try
			If Null( rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")  ) <> Null( "MISC") Then
	 decReturnValue =   rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_OUT_REC") 
	              End If

		Catch ex As Exception
			' Write the exception to the log file.
			RecordReportError(strReportLogPath, ex)

		End Try
		
		Return decReturnValue

	End Function
	Private Function X_MISC_SVC_MTD() As Decimal

		Dim decReturnValue As Decimal = 0D

		Try
			If Null( rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")  ) = Null( "MISC") Then
	 decReturnValue =   ( rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_IN_SVC")  + rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_OUT_SVC")  )
	              End If

		Catch ex As Exception
			' Write the exception to the log file.
			RecordReportError(strReportLogPath, ex)

		End Try
		
		Return decReturnValue

	End Function
	Private Function X_MISC_AMT_MTD() As Decimal

		Dim decReturnValue As Decimal = 0D

		Try
			If Null( rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")  ) = Null( "MISC") Then
	 decReturnValue =   ( rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_IN_REC")  + rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_OUT_REC")  )
	              End If

		Catch ex As Exception
			' Write the exception to the log file.
			RecordReportError(strReportLogPath, ex)

		End Try
		
		Return decReturnValue

	End Function
	Private Function X_SVC_YTD_IN() As Decimal

		Dim decReturnValue As Decimal = 0D

		Try
			If Null( rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")  ) <> Null( "MISC") Then
	 decReturnValue =   rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_IN_SVC") 
	              End If

		Catch ex As Exception
			' Write the exception to the log file.
			RecordReportError(strReportLogPath, ex)

		End Try
		
		Return decReturnValue

	End Function
	Private Function X_SVC_YTD_OUT() As Decimal

		Dim decReturnValue As Decimal = 0D

		Try
			If Null( rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")  ) <> Null( "MISC") Then
	 decReturnValue =   rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_OUT_SVC") 
	              End If

		Catch ex As Exception
			' Write the exception to the log file.
			RecordReportError(strReportLogPath, ex)

		End Try
		
		Return decReturnValue

	End Function
	Private Function X_AMT_YTD_IN() As Decimal

		Dim decReturnValue As Decimal = 0D

		Try
			If Null( rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")  ) <> Null( "MISC") Then
	 decReturnValue =   rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_IN_REC") 
	              End If

		Catch ex As Exception
			' Write the exception to the log file.
			RecordReportError(strReportLogPath, ex)

		End Try
		
		Return decReturnValue

	End Function
	Private Function X_AMT_YTD_OUT() As Decimal

		Dim decReturnValue As Decimal = 0D

		Try
			If Null( rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")  ) <> Null( "MISC") Then
	 decReturnValue =   rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_OUT_REC") 
	              End If

		Catch ex As Exception
			' Write the exception to the log file.
			RecordReportError(strReportLogPath, ex)

		End Try
		
		Return decReturnValue

	End Function
	Private Function X_MISC_SVC_YTD() As Decimal

		Dim decReturnValue As Decimal = 0D

		Try
			If Null( rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")  ) = Null( "MISC") Then
	 decReturnValue =   ( rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_IN_SVC")  + rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_OUT_SVC")  )
	              End If

		Catch ex As Exception
			' Write the exception to the log file.
			RecordReportError(strReportLogPath, ex)

		End Try
		
		Return decReturnValue

	End Function
	Private Function X_MISC_AMT_YTD() As Decimal

		Dim decReturnValue As Decimal = 0D

		Try
			If Null( rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")  ) = Null( "MISC") Then
	 decReturnValue =   ( rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_IN_REC")  + rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_OUT_REC")  )
	              End If

		Catch ex As Exception
			' Write the exception to the log file.
			RecordReportError(strReportLogPath, ex)

		End Try
		
		Return decReturnValue

	End Function
	Private Function X_SVC_TOTAL_MTD() As Decimal

		Dim decReturnValue As Decimal = 0D

		Try
			decReturnValue = (  X_SVC_MTD_IN +  X_SVC_MTD_OUT +  X_MISC_SVC_MTD )

		Catch ex As Exception
			' Write the exception to the log file.
			RecordReportError(strReportLogPath, ex)

		End Try
		
		Return decReturnValue

	End Function
	Private Function X_SVC_TOTAL_YTD() As Decimal

		Dim decReturnValue As Decimal = 0D

		Try
			decReturnValue = (  X_SVC_YTD_IN +  X_SVC_YTD_OUT +  X_MISC_SVC_YTD )

		Catch ex As Exception
			' Write the exception to the log file.
			RecordReportError(strReportLogPath, ex)

		End Try
		
		Return decReturnValue

	End Function
	Private Function X_AMT_TOTAL_MTD() As Decimal

		Dim decReturnValue As Decimal = 0D

		Try
			decReturnValue = (  X_AMT_MTD_IN +  X_AMT_MTD_OUT +  X_MISC_AMT_MTD )

		Catch ex As Exception
			' Write the exception to the log file.
			RecordReportError(strReportLogPath, ex)

		End Try
		
		Return decReturnValue

	End Function
	Private Function X_AMT_TOTAL_YTD() As Decimal

		Dim decReturnValue As Decimal = 0D

		Try
			decReturnValue = (  X_AMT_YTD_IN +  X_AMT_YTD_OUT +  X_MISC_AMT_YTD )

		Catch ex As Exception
			' Write the exception to the log file.
			RecordReportError(strReportLogPath, ex)

		End Try
		
		Return decReturnValue

	End Function
	Private Function X_PERIOD() As String

		Dim strReturnValue As String = String.Empty

		Try
			strReturnValue = "."

		Catch ex As Exception
			' Write the exception to the log file.
			RecordReportError(strReportLogPath, ex)

		End Try
		
		Return strReturnValue

	End Function
	Private Function X_NAME() As String

		Dim strReturnValue As String = String.Empty

		Try
			strReturnValue = PACK ( rdrF020_DOCTOR_MSTR.GetString("DOC_NAME") & " " & rdrF020_DOCTOR_MSTR.GetString("DOC_INITS") )

		Catch ex As Exception
			' Write the exception to the log file.
			RecordReportError(strReportLogPath, ex)

		End Try
		
		Return strReturnValue

	End Function

	Private Function ICONST_MSTR_REC_ICONST_DATE_PERIOD_END() As Date

		Dim dteReturnValue As Date = cZeroDate

		Try
			dteReturnValue == (rdrICONST_MSTR_REC.GetString("ICONST_DATE_PERIOD_END_YY") & rdrICONST_MSTR_REC.GetString("ICONST_DATE_PERIOD_END_MM") & rdrICONST_MSTR_REC.GetString("ICONST_DATE_PERIOD_END_DD"))

		Catch ex As Exception
			' Write the exception to the log file.
			RecordReportError(strReportLogPath, ex)

		End Try
		Return dteReturnValue

	End Function

#End Region

#Region " CONTROLS "

	Public Overrides Sub DeclareReportControls() 
		
		Try
			AddControl(ReportSection.PAGE_HEADING, "INDEXED.dbo.F050_DOC_REVENUE_MSTR.DOCREV_CLINIC_1_2" , DataTypes.Character, 2)
			AddControl(ReportSection.PAGE_HEADING, "ICONST_MSTR_REC_ICONST_DATE_PERIOD_END" , DataTypes.Date)
			AddControl(ReportSection.PAGE_HEADING, "INDEXED.dbo.F050_DOC_REVENUE_MSTR.DOCREV_CLINIC_1_2" , DataTypes.Character, 2)
			AddControl(ReportSection.PAGE_HEADING, "INDEXED.dbo.ICONST_MSTR_REC.ICONST_CLINIC_NBR" , DataTypes.Character, 4)
			AddControl(ReportSection.PAGE_HEADING, "INDEXED.dbo.ICONST_MSTR_REC.ICONST_CLINIC_NAME" , DataTypes.Character, 20)
			AddControl(ReportSection.FOOTING_AT, "INDEXED.dbo.F020_DOCTOR_MSTR.DOC_FULL_PART_IND" , DataTypes.Character, 1)
			AddControl(ReportSection.FOOTING_AT, "X_CLASS", DataTypes.Character, 18)
			AddControl(ReportSection.FOOTING_AT, "X_SVC_MTD_IN", DataTypes.Numeric, 4)
			AddControl(ReportSection.FOOTING_AT, "X_AMT_MTD_IN", DataTypes.Numeric, 8)
			AddControl(ReportSection.FOOTING_AT, "X_SVC_MTD_OUT", DataTypes.Numeric, 4)
			AddControl(ReportSection.FOOTING_AT, "X_AMT_MTD_OUT", DataTypes.Numeric, 8)
			AddControl(ReportSection.FOOTING_AT, "X_MISC_SVC_MTD", DataTypes.Numeric, 4)
			AddControl(ReportSection.FOOTING_AT, "X_MISC_AMT_MTD", DataTypes.Numeric, 8)
			AddControl(ReportSection.FOOTING_AT, "X_SVC_TOTAL_MTD", DataTypes.Numeric, 4)
			AddControl(ReportSection.FOOTING_AT, "X_AMT_TOTAL_MTD", DataTypes.Numeric, 8)
			AddControl(ReportSection.FOOTING_AT, "X_SVC_YTD_IN", DataTypes.Numeric, 5)
			AddControl(ReportSection.FOOTING_AT, "X_AMT_YTD_IN", DataTypes.Numeric, 8)
			AddControl(ReportSection.FOOTING_AT, "X_SVC_YTD_OUT", DataTypes.Numeric, 5)
			AddControl(ReportSection.FOOTING_AT, "X_AMT_YTD_OUT", DataTypes.Numeric, 8)
			AddControl(ReportSection.FOOTING_AT, "X_MISC_SVC_YTD", DataTypes.Numeric, 5)
			AddControl(ReportSection.FOOTING_AT, "X_MISC_AMT_YTD", DataTypes.Numeric, 8)
			AddControl(ReportSection.FOOTING_AT, "X_SVC_TOTAL_YTD", DataTypes.Numeric, 5)
			AddControl(ReportSection.FOOTING_AT, "X_AMT_TOTAL_YTD", DataTypes.Numeric, 8)
			AddControl(ReportSection.FOOTING_AT, "X_SVC_MTD_IN", DataTypes.Numeric, 4)
			AddControl(ReportSection.FOOTING_AT, "X_AMT_MTD_IN", DataTypes.Numeric, 8)
			AddControl(ReportSection.FOOTING_AT, "X_SVC_MTD_OUT", DataTypes.Numeric, 4)
			AddControl(ReportSection.FOOTING_AT, "X_AMT_MTD_OUT", DataTypes.Numeric, 8)
			AddControl(ReportSection.FOOTING_AT, "X_MISC_SVC_MTD", DataTypes.Numeric, 4)
			AddControl(ReportSection.FOOTING_AT, "X_MISC_AMT_MTD", DataTypes.Numeric, 8)
			AddControl(ReportSection.FOOTING_AT, "X_SVC_TOTAL_MTD", DataTypes.Numeric, 4)
			AddControl(ReportSection.FOOTING_AT, "X_AMT_TOTAL_MTD", DataTypes.Numeric, 8)
			AddControl(ReportSection.FOOTING_AT, "X_SVC_YTD_IN", DataTypes.Numeric, 5)
			AddControl(ReportSection.FOOTING_AT, "X_AMT_YTD_IN", DataTypes.Numeric, 8)
			AddControl(ReportSection.FOOTING_AT, "X_SVC_YTD_OUT", DataTypes.Numeric, 5)
			AddControl(ReportSection.FOOTING_AT, "X_AMT_YTD_OUT", DataTypes.Numeric, 8)
			AddControl(ReportSection.FOOTING_AT, "X_MISC_SVC_YTD", DataTypes.Numeric, 5)
			AddControl(ReportSection.FOOTING_AT, "X_MISC_AMT_YTD", DataTypes.Numeric, 8)
			AddControl(ReportSection.FOOTING_AT, "X_SVC_TOTAL_YTD", DataTypes.Numeric, 5)
			AddControl(ReportSection.FOOTING_AT, "X_AMT_TOTAL_YTD", DataTypes.Numeric, 8)

		Catch ex As Exception
			' Write the exception to the log file.
			RecordReportError(strReportLogPath, ex)

		End Try

	End Sub

#End Region

#Region " Renaissance Precompiler Generated Code "

#End Region

#End Region

End Class


