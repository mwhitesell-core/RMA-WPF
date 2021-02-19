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
	public class R022E2 : BaseRDLClass
	{
		#region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "
		
		protected const string REPORT_NAME = "R022E2";
		protected const bool REPORT_HAS_PARAMETERS = false;
		private Reader rdrU022E1 = new Reader();
		private Reader rdrU022E2 = new Reader();
		
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
				SubFileName = "U022E2";
				SubFileType = SubFileType.Keep;
				SubFileAT = "W_AGENT";
				Sort = "FIRST_KEY ASC, W_AGENT ASC, CLMHDR_CLAIM_ID ASC";
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
		
		private void Access_U022E1()
		{
			StringBuilder strSQL = new StringBuilder(string.Empty);
			
			strSQL.Append("SELECT ");
			strSQL.Append("ICONST_CLINIC_NBR_1_2, ");
			strSQL.Append("W_BATCH_TYPE, ");
			strSQL.Append("W_ADJ_CODE, ");
			strSQL.Append("W_AGENT, ");
			strSQL.Append("CLMHDR_CLAIM_ID, ");
			strSQL.Append("ICONST_CLINIC_CYCLE_NBR, ");
			strSQL.Append("ICONST_DATE_PERIOD_END, ");
			strSQL.Append("BATCTRL_ADJ_CD, ");
			strSQL.Append("BATCTRL_CALC_AR_DUE, ");
			strSQL.Append("BATCTRL_CALC_TOT_REV, ");
			strSQL.Append("BATCTRL_MANUAL_PAY_TOT, ");
			strSQL.Append("BATCTRL_NBR_CLAIMS_IN_BATCH ");
			strSQL.Append("FROM TEMPORARYDATA.U022E1 ");
			
			strSQL.Append(Choose());
			
			rdrU022E1.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
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
		
		private string FIRST_KEY()
		{
			string strReturnValue = string.Empty;
			try
			{
				strReturnValue = (QDesign.ASCII(rdrU022E1.GetNumber("ICONST_CLINIC_NBR_1_2"), 2) 
							+ (rdrU022E1.GetString("W_BATCH_TYPE") + rdrU022E1.GetString("W_ADJ_CODE")));
			}

			catch (Exception ex)
			{
				//  Write the exception to the log file.
				ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
			}
			
			return strReturnValue;
		}
		
		#endregion

        #region " CONTROLS "
		
		public override void DeclareReportControls()
		{
			try
			{
				 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022E1.ICONST_CLINIC_NBR_1_2", DataTypes.Numeric, 2);
				 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022E1.ICONST_CLINIC_CYCLE_NBR", DataTypes.Numeric, 2);
				 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022E1.ICONST_DATE_PERIOD_END", DataTypes.Numeric, 8);
				 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022E1.W_BATCH_TYPE", DataTypes.Character, 1);
				 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022E1.BATCTRL_ADJ_CD", DataTypes.Character, 1);
				 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022E1.W_AGENT", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022E1.BATCTRL_CALC_AR_DUE", DataTypes.Numeric, 9, SummaryType.SUBTOTAL, "W_AGENT");
				 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022E1.BATCTRL_CALC_TOT_REV", DataTypes.Numeric, 9, SummaryType.SUBTOTAL, "W_AGENT");
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022E1.BATCTRL_MANUAL_PAY_TOT", DataTypes.Numeric, 9, SummaryType.SUBTOTAL, "W_AGENT");
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022E1.BATCTRL_NBR_CLAIMS_IN_BATCH", DataTypes.Numeric, 5, SummaryType.SUBTOTAL, "W_AGENT");
				 AddControl(ReportSection.REPORT, "FIRST_KEY", DataTypes.Character, 4);
				 AddControl(ReportSection.REPORT, "TEMPORARYDATA.U022E1.CLMHDR_CLAIM_ID", DataTypes.Character, 16);
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
				case "TEMPORARYDATA.U022E1.ICONST_CLINIC_NBR_1_2":
					return rdrU022E1.GetNumber("ICONST_CLINIC_NBR_1_2").ToString();
					
				case "TEMPORARYDATA.U022E1.ICONST_CLINIC_CYCLE_NBR":
					return rdrU022E1.GetNumber("ICONST_CLINIC_CYCLE_NBR").ToString();
					
				case "TEMPORARYDATA.U022E1.ICONST_DATE_PERIOD_END":
					return rdrU022E1.GetNumber("ICONST_DATE_PERIOD_END").ToString();
					
				case "TEMPORARYDATA.U022E1.W_BATCH_TYPE":
					return Common.StringToField(rdrU022E1.GetString("W_BATCH_TYPE"));
					
				case "TEMPORARYDATA.U022E1.BATCTRL_ADJ_CD":
					return Common.StringToField(rdrU022E1.GetString("BATCTRL_ADJ_CD"));
					
				case "TEMPORARYDATA.U022E1.W_AGENT":
					return Common.StringToField(rdrU022E1.GetString("W_AGENT"));
					
				case "TEMPORARYDATA.U022E1.BATCTRL_CALC_AR_DUE":
					return rdrU022E1.GetNumber("BATCTRL_CALC_AR_DUE").ToString();
					
				case "TEMPORARYDATA.U022E1.BATCTRL_CALC_TOT_REV":
					return rdrU022E1.GetNumber("BATCTRL_CALC_TOT_REV").ToString();
					
				case "TEMPORARYDATA.U022E1.BATCTRL_MANUAL_PAY_TOT":
					return rdrU022E1.GetNumber("BATCTRL_MANUAL_PAY_TOT").ToString();
					
				case "TEMPORARYDATA.U022E1.BATCTRL_NBR_CLAIMS_IN_BATCH":
					return rdrU022E1.GetNumber("BATCTRL_NBR_CLAIMS_IN_BATCH").ToString();
					
				case "FIRST_KEY":
					return Common.StringToField(FIRST_KEY(), intSize);
					
				case "TEMPORARYDATA.U022E1.CLMHDR_CLAIM_ID":
					return Common.StringToField(rdrU022E1.GetString("CLMHDR_CLAIM_ID"));
					
				default:
					return string.Empty;
			}
		}
		public override void AccessData()
		{
			try
			{
				Access_U022E1();
				while (rdrU022E1.Read())
				{
					WriteData();
				}
				
				rdrU022E1.Close();
			}

			catch (Exception ex)
			{
				ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
			}
		}
		public override void CloseReaders()
		{
			if (!(rdrU022E1 == null))
			{
				rdrU022E1.Close();
				rdrU022E1 = null;
			}
		}
		
		#endregion

        #endregion
	}
}
