using Core.DataAccess.SqlServer;
using Core.DataAccess.TextFile;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.ReportFramework;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
namespace RMA_DATA
{
	public class R022E1 : BaseRDLClass
	{
		#region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "
		
		protected const string REPORT_NAME = "R022E1";
		protected const bool REPORT_HAS_PARAMETERS = false;
		private Reader rdrU020A1 = new Reader();
		private Reader rdrF002_CLAIMS_MSTR = new Reader();
		private Reader rdrU022E1 = new Reader();
		
		#endregion

        #region " Renaissance Data "
		
		public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
		{
			try
			{
				//  Set Report Properties...
				ReportName = REPORT_NAME;
				ReportHasParameters = REPORT_HAS_PARAMETERS;
				ConfigFile = strReportAssembly;
				ReportFunctions.DebugReport = blnDebug;
				//  Create Subfile.
				SubFile = true;
				SubFileName = "U022E1";
				SubFileType = SubFileType.Keep;
				SubFileAT = "";
				Sort = "";
				ProcessData(strConnection, arrParameters);
			}

			catch (Exception ex)
			{
				//  Write the exception to the log file.
				ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
			}
			
			return ReportData;
		}
		
		#endregion

        #region " Renaissance Statements "

        #region " ACCESS "
		
		private void Access_U020A1()
		{
			StringBuilder strSQL = new StringBuilder(string.Empty);
			
			strSQL.Append("SELECT ");
			strSQL.Append("CLMHDR_CLAIM_ID, ");
			strSQL.Append("BATCTRL_AGENT_CD, ");
			strSQL.Append("BATCTRL_BATCH_TYPE, ");
			strSQL.Append("CLMHDR_TOT_CLAIM_AR_OHIP, ");
			strSQL.Append("ICONST_CLINIC_NBR_1_2, ");
			strSQL.Append("ICONST_CLINIC_CYCLE_NBR, ");
			strSQL.Append("ICONST_DATE_PERIOD_END ");
			strSQL.Append("FROM TEMPORARYDATA.U020A1 ");
			
			strSQL.Append(Choose());
			
			rdrU020A1.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
			strSQL = null;
		}
		private void Link_F002_CLAIMS_MSTR()
		{
			StringBuilder strSQL = new StringBuilder(string.Empty);
			
			strSQL.Append("SELECT ");
			strSQL.Append("KEY_CLM_TYPE, ");
			strSQL.Append("KEY_CLM_BATCH_NBR, ");
			strSQL.Append("KEY_CLM_CLAIM_NBR, ");
			strSQL.Append("KEY_CLM_SERV_CODE, ");
			strSQL.Append("KEY_CLM_ADJ_NBR, ");
			strSQL.Append("CLMHDR_ADJ_CD, ");
			strSQL.Append("CLMHDR_MANUAL_AND_TAPE_PAYMENTS ");
			strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR_HDR ");
			strSQL.Append("WHERE ");
			strSQL.Append("KEY_CLM_TYPE = '").Append("B'");
            strSQL.Append(" AND KEY_CLM_BATCH_NBR = '").Append(QDesign.Substring(rdrU020A1.GetString("CLMHDR_CLAIM_ID"), 1, 8)).Append("'");
			strSQL.Append(" AND KEY_CLM_CLAIM_NBR = ").Append(QDesign.NConvert(QDesign.Substring(rdrU020A1.GetString("CLMHDR_CLAIM_ID"), 9, 2)));
			strSQL.Append(" AND KEY_CLM_SERV_CODE = '").Append(QDesign.Substring(rdrU020A1.GetString("CLMHDR_CLAIM_ID"), 11, 5)).Append("'");
			strSQL.Append(" AND KEY_CLM_ADJ_NBR = '").Append(QDesign.Substring(rdrU020A1.GetString("CLMHDR_CLAIM_ID"), 16, 1)).Append("'");
			
			rdrF002_CLAIMS_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
			strSQL = null;
		}
		
		#endregion

        #region " CHOOSE "
		
		private string Choose()
		{
			StringBuilder strChoose = new StringBuilder(string.Empty);
			
			return strChoose.ToString();
		}
		
		#endregion

        #region " SELECT IF "
		
		#endregion

        #region " DEFINES "
		
		private string BATCTRL_ADJ_CD()
		{
			string strReturnValue = string.Empty;
			try
			{
				strReturnValue = rdrF002_CLAIMS_MSTR.GetString("CLMHDR_ADJ_CD");
			}

			catch (Exception ex)
			{
				//  Write the exception to the log file.
				ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
			}
			
			return strReturnValue;
		}
		
		private string W_AGENT()
		{
			string strReturnValue = string.Empty;
			try
			{
				if ((((QDesign.NULL(rdrU020A1.GetNumber("BATCTRL_AGENT_CD")) == QDesign.NULL(0d)) 
							|| (QDesign.NULL(rdrU020A1.GetNumber("BATCTRL_AGENT_CD")) == QDesign.NULL(2D))) 
							&& (QDesign.NULL(rdrU020A1.GetString("BATCTRL_BATCH_TYPE")) == "C")))
				{
					strReturnValue = "T";
				}
				else
				{
					strReturnValue = QDesign.ASCII(rdrU020A1.GetNumber("BATCTRL_AGENT_CD"), 1);
				}
			}

			catch (Exception ex)
			{
				//  Write the exception to the log file.
				ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
			}
			
			return strReturnValue;
		}
		
		private string W_BATCH_TYPE()
		{
			string strReturnValue = string.Empty;
			try
			{
				if ((QDesign.NULL(rdrU020A1.GetString("BATCTRL_BATCH_TYPE")) == "C"))
				{
					strReturnValue = "A";
				}
				else if ((QDesign.NULL(rdrU020A1.GetString("BATCTRL_BATCH_TYPE")) == "A")) 
				{
					strReturnValue = "B";
				}
				else if ((QDesign.NULL(rdrU020A1.GetString("BATCTRL_BATCH_TYPE")) == "P")) 
				{
					strReturnValue = "P";
				}
			}

			catch (Exception ex)
			{
				//  Write the exception to the log file.
				ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
			}
			
			return strReturnValue;
		}
		
		private string W_ADJ_CODE()
		{
			string strReturnValue = string.Empty;
			try
			{
				if ((QDesign.NULL(W_BATCH_TYPE()) == "A"))
				{
					strReturnValue = " ";
				}
				else
				{
					strReturnValue = rdrF002_CLAIMS_MSTR.GetString("CLMHDR_ADJ_CD");
				}
			}

			catch (Exception ex)
			{
				//  Write the exception to the log file.
				ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
			}
			
			return strReturnValue;
		}
		
		private decimal BATCTRL_CALC_AR_DUE()
		{
			decimal decReturnValue = 0;
			try
			{
				decReturnValue = rdrU020A1.GetNumber("CLMHDR_TOT_CLAIM_AR_OHIP");
			}

			catch (Exception ex)
			{
				//  Write the exception to the log file.
				ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
			}
			
			return decReturnValue;
		}
		
		private decimal BATCTRL_CALC_TOT_REV()
		{
			decimal decReturnValue = 0;
			try
			{
				decReturnValue = rdrU020A1.GetNumber("CLMHDR_TOT_CLAIM_AR_OHIP");
			}

			catch (Exception ex)
			{
				//  Write the exception to the log file.
				ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
			}
			
			return decReturnValue;
		}
		
		private decimal BATCTRL_MANUAL_PAY_TOT()
		{
			decimal decReturnValue = 0;
			try
			{
				decReturnValue = rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_MANUAL_AND_TAPE_PAYMENTS");
			}

			catch (Exception ex)
			{
				//  Write the exception to the log file.
				ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
			}
			
			return decReturnValue;
		}
		
		private decimal BATCTRL_NBR_CLAIMS_IN_BATCH()
		{
			decimal decReturnValue = 0;
            try
            {
                decReturnValue = 1;
            }

			catch (Exception ex)
			{
				//  Write the exception to the log file.
				ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
			}
			
			return decReturnValue;
		}
		
		#endregion

        #region " CONTROLS "
		
		public override void DeclareReportControls()
		{
			try
			{
				 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020A1.CLMHDR_CLAIM_ID", DataTypes.Character, 16);
				 AddControl(ReportSection.SUMMARY, "W_ADJ_CODE", DataTypes.Character, 1);
				 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020A1.ICONST_CLINIC_NBR_1_2", DataTypes.Numeric, 2);
				 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020A1.ICONST_CLINIC_CYCLE_NBR", DataTypes.Numeric, 2);
				 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020A1.ICONST_DATE_PERIOD_END", DataTypes.Numeric, 8);
				 AddControl(ReportSection.SUMMARY, "W_BATCH_TYPE", DataTypes.Character, 1);
				 AddControl(ReportSection.SUMMARY, "BATCTRL_ADJ_CD", DataTypes.Character, 1);
				 AddControl(ReportSection.SUMMARY, "W_AGENT", DataTypes.Character, 1);
				 AddControl(ReportSection.SUMMARY, "BATCTRL_CALC_AR_DUE", DataTypes.Numeric, 9);
				 AddControl(ReportSection.SUMMARY, "BATCTRL_CALC_TOT_REV", DataTypes.Numeric, 9);
				 AddControl(ReportSection.SUMMARY, "BATCTRL_MANUAL_PAY_TOT", DataTypes.Numeric, 9);
				 AddControl(ReportSection.SUMMARY, "BATCTRL_NBR_CLAIMS_IN_BATCH", DataTypes.Numeric, 2);
			}

			catch (Exception ex)
			{
				//  Write the exception to the log file.
				ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
			}
		}
		
		#endregion

        #region " Renaissance Precompiler Generated Code "
		
		// # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
		// # Do not delete, modify or move it.  Updated: 2018-05-11 7:47:46 AM
		public override string ReturnControlValue(string strControl, int intSize)
		{
			switch (strControl)
			{
				case "TEMPORARYDATA.U020A1.CLMHDR_CLAIM_ID":
					return Common.StringToField(rdrU020A1.GetString("CLMHDR_CLAIM_ID"));
					
				case "W_ADJ_CODE":
					return Common.StringToField(W_ADJ_CODE(), intSize);
					
				case "TEMPORARYDATA.U020A1.ICONST_CLINIC_NBR_1_2":
					return rdrU020A1.GetNumber("ICONST_CLINIC_NBR_1_2").ToString();
					
				case "TEMPORARYDATA.U020A1.ICONST_CLINIC_CYCLE_NBR":
					return rdrU020A1.GetNumber("ICONST_CLINIC_CYCLE_NBR").ToString();
					
				case "TEMPORARYDATA.U020A1.ICONST_DATE_PERIOD_END":
					return rdrU020A1.GetNumber("ICONST_DATE_PERIOD_END").ToString();
					
				case "W_BATCH_TYPE":
					return Common.StringToField(W_BATCH_TYPE(), intSize);
					
				case "BATCTRL_ADJ_CD":
					return Common.StringToField(BATCTRL_ADJ_CD(), intSize);
					
				case "W_AGENT":
					return Common.StringToField(W_AGENT(), intSize);
					
				case "BATCTRL_CALC_AR_DUE":
					return BATCTRL_CALC_AR_DUE().ToString();
					
				case "BATCTRL_CALC_TOT_REV":
					return BATCTRL_CALC_TOT_REV().ToString();
					
				case "BATCTRL_MANUAL_PAY_TOT":
					return BATCTRL_MANUAL_PAY_TOT().ToString();
					
				case "BATCTRL_NBR_CLAIMS_IN_BATCH":
					return BATCTRL_NBR_CLAIMS_IN_BATCH().ToString();
					
				default:
					return string.Empty;
			}
		}
		public override void AccessData()
		{
			try
			{
				Access_U020A1();
				while (rdrU020A1.Read())
				{
					Link_F002_CLAIMS_MSTR();
					while (rdrF002_CLAIMS_MSTR.Read())
					{
						WriteData();
					}
					
					rdrF002_CLAIMS_MSTR.Close();
				}
				
				rdrU020A1.Close();
			}

			catch (Exception ex)
			{
				ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
			}
		}
		public override void CloseReaders()
		{
			if (!(rdrU020A1 == null))
			{
				rdrU020A1.Close();
				rdrU020A1 = null;
			}
			
			if (!(rdrF002_CLAIMS_MSTR == null))
			{
				rdrF002_CLAIMS_MSTR.Close();
				rdrF002_CLAIMS_MSTR = null;
			}
		}
		
		#endregion

        #endregion
	}
}
