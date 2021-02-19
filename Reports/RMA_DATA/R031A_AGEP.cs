#region "Screen Comments"

// #> PROGRAM-ID.     r031a_agep.qzs
// ((C)) Dyad Infosys LTD  
// Purpose: extract AGEP payments from u030-tape-67-file  from all clinics
// MODIFICATION HISTORY
// DATE   WHO         DESCRIPTION
// 07/Feb/08 M.C.        - original
// 08/Jul/17 yas         - add  ANAESTHETIC AGE PREMIUM  
// and  GP PSYCHOTHERAPY PREMIUM 
// 08/Oct/14 yas           Add  AFTER HOURS AGE PREMIUM  
// 09/Apr/01 MC  - include 3% General Fee Payment for MOHR & AGE3 
// 09/Apr/06 yas         - add new AGEP adjustment `RMB ANAESTHESIA AGE PREMIUM`
// 09/Jul/22 MC          - add new AGEP adjustment `GLOBAL FUNDING PREMIUM PAYMENT`
// 13/May/15 MC1         - add  0.5% DISCOUNT AUTOMATED PREMIUMS ,  0.5% DISCOUNT OPTED-IN 
// and  0.5% DISCOUNT PRIMARY CARE  for MOHD
// 15/Apr/07 MC2  - MOHD has changed the description as `PAYMENT REDUCTION-AUTOMATED PREMIUMS` and
// `PAYMENT REDUCTION-OPTED-IN`

#endregion

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
public class R031A_AGEP : BaseRDLClass
{
	#region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

	protected const string REPORT_NAME = "R031A_AGEP";
	protected const bool REPORT_HAS_PARAMETERS = true;

	// Data Helpers.
	private Reader rdrU030_TAPE_67_FILE = new Reader();
	private Reader rdrR031A_AGEP = new Reader();

	#endregion

	#region " Renaissance Data "

	public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
	{
		try
		{
			// Set Report Properties...
			ReportName = REPORT_NAME;
			ReportHasParameters = REPORT_HAS_PARAMETERS;
			ConfigFile = strReportAssembly;
			ReportFunctions.DebugReport = blnDebug;
			// Create Subfile.
			SubFile = true;
			SubFileName = "R031A_AGEP";
			SubFileType = SubFileType.Keep;
			SubFileAT = "TODO: Enter sortbreak name";

			Sort = "";

			// Start report data processing.
			ProcessData(strConnection, arrParameters);
		}

		catch (Exception ex)
		{
			// Write the exception to the log file.
			ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		}

		return ReportData;
	}

	#endregion

	#region " Renaissance Statements "

	#region " ACCESS "

	private void Access_U030_TAPE_67_FILE()
	{
		StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("RAT_67_TRANS_MESSAGE, ");
            strSQL.Append("RAT_67_AMT_CLAIMS_ADJ, ");
            strSQL.Append("RAT_67_AMT_ADVANCES, ");
            strSQL.Append("RAT_67_AMT_REDUCTIONS, ");
            strSQL.Append("RAT_67_AMT_DEDUCTIONS, ");
            strSQL.Append("RAT_67_TRANS_CD, ");
            strSQL.Append("RAT_67_CHEQUE_IND, ");
            strSQL.Append("RAT_67_TRANS_DATE, ");
            strSQL.Append("RAT_67_TRANS_AMT, ");
            strSQL.Append("RAT_67_TOTAL_CLINIC_AMT, ");
            strSQL.Append("RAT_67_AMT_BILL, ");
            strSQL.Append("RAT_67_AMT_PAID ");
            strSQL.Append("FROM SEQUENTIAL.U030_TAPE_67_FILE ");

		strSQL.Append(Choose());

		rdrU030_TAPE_67_FILE.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.m_strFlatFileDictionary, ReportFunctions.TextFiles);

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

	public override bool SelectIf()
	{
		bool blnSelected = false;

		if (QDesign.NULL(rdrU030_TAPE_67_FILE.GetString("RAT_67_TRANS_MESSAGE")) == QDesign.NULL("AGE PREMIUM PAYMENT") | QDesign.NULL(rdrU030_TAPE_67_FILE.GetString("RAT_67_TRANS_MESSAGE")) == QDesign.NULL("ANAESTHETIC AGE PREMIUM") | QDesign.NULL(rdrU030_TAPE_67_FILE.GetString("RAT_67_TRANS_MESSAGE")) == QDesign.NULL("GP PSYCHOTHERAPY PREMIUM") | QDesign.NULL(rdrU030_TAPE_67_FILE.GetString("RAT_67_TRANS_MESSAGE")) == QDesign.NULL("AFTER HOURS AGE PREMIUM") | QDesign.NULL(rdrU030_TAPE_67_FILE.GetString("RAT_67_TRANS_MESSAGE")) == QDesign.NULL("RMB ANAESTHESIA AGE PREMIUM") | QDesign.NULL(rdrU030_TAPE_67_FILE.GetString("RAT_67_TRANS_MESSAGE")) == QDesign.NULL("GLOBAL FUNDING PREMIUM PAYMENT") | QDesign.NULL(rdrU030_TAPE_67_FILE.GetString("RAT_67_TRANS_MESSAGE")) == QDesign.NULL("3% GENERAL FEE PAYMENT OPTED-IN") | QDesign.NULL(rdrU030_TAPE_67_FILE.GetString("RAT_67_TRANS_MESSAGE")) == QDesign.NULL("3% GENERAL FEE PAYMENT WSIB") | QDesign.NULL(rdrU030_TAPE_67_FILE.GetString("RAT_67_TRANS_MESSAGE")) == QDesign.NULL("3% GENERAL FEE PAYMENT AUTOMATED PRM") | QDesign.NULL(rdrU030_TAPE_67_FILE.GetString("RAT_67_TRANS_MESSAGE")) == QDesign.NULL("PAYMENT REDUCTION-AUTOMATED PREMIUMS") | QDesign.NULL(rdrU030_TAPE_67_FILE.GetString("RAT_67_TRANS_MESSAGE")) == QDesign.NULL("PAYMENT REDUCTION-OPTED-IN") | QDesign.NULL(rdrU030_TAPE_67_FILE.GetString("RAT_67_TRANS_MESSAGE")) == QDesign.NULL("0.5% DISCOUNT PRIMARY CARE")) {
			blnSelected = true;
		}

		return blnSelected;
	}

	#endregion

	#region " DEFINES "

	private decimal X_CLINIC()
	{
		decimal decReturnValue = 0;

		try
		{
			if (ReportFunctions.astrScreenParameters[0].ToString().Trim() != string.Empty) {
				decReturnValue = Convert.ToDecimal(ReportFunctions.astrScreenParameters[0].ToString());
			}
			else
			{
				decReturnValue = 0;
			}
		}

		catch (Exception ex)
		{
			// Write the exception to the log file.
			ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		}

		return decReturnValue;
	}

	private string PAYMENT_TYPE()
	{
		string strReturnValue = string.Empty;

		try
		{
			if (QDesign.NULL(rdrU030_TAPE_67_FILE.GetString("RAT_67_TRANS_MESSAGE")) == QDesign.NULL("PAYMENT REDUCTION-AUTOMATED PREMIUMS") | QDesign.NULL(rdrU030_TAPE_67_FILE.GetString("RAT_67_TRANS_MESSAGE")) == QDesign.NULL("PAYMENT REDUCTION-OPTED-IN") | QDesign.NULL(rdrU030_TAPE_67_FILE.GetString("RAT_67_TRANS_MESSAGE")) == QDesign.NULL("0.5% DISCOUNT PRIMARY CARE")) {
				strReturnValue = "MOHD";
			}
			else if (QDesign.NULL(rdrU030_TAPE_67_FILE.GetString("RAT_67_TRANS_MESSAGE")) == QDesign.NULL("3% GENERAL FEE PAYMENT OPTED-IN") | QDesign.NULL(rdrU030_TAPE_67_FILE.GetString("RAT_67_TRANS_MESSAGE")) == QDesign.NULL("3% GENERAL FEE PAYMENT WSIB")) 
			{
				strReturnValue = "MOHR";
			}
			else if (QDesign.NULL(rdrU030_TAPE_67_FILE.GetString("RAT_67_TRANS_MESSAGE")) == QDesign.NULL("3% GENERAL FEE PAYMENT AUTOMATED PRM")) 
			{
				strReturnValue = "AGE3";
			}
			else
			{
				strReturnValue = "AGEP";
			}
		}

		catch (Exception ex)
		{
			// Write the exception to the log file.
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
			AddControl(ReportSection.REPORT, "PAYMENT_TYPE", DataTypes.Character, 4);
			AddControl(ReportSection.REPORT, "X_CLINIC", DataTypes.Numeric, 2);
			AddControl(ReportSection.REPORT, "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_AMT_ADVANCES", DataTypes.Numeric, 9);
			AddControl(ReportSection.REPORT, "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_AMT_BILL", DataTypes.Numeric, 9);
			AddControl(ReportSection.REPORT, "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_AMT_CLAIMS_ADJ", DataTypes.Numeric, 9);
			AddControl(ReportSection.REPORT, "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_AMT_DEDUCTIONS", DataTypes.Numeric, 9);
			AddControl(ReportSection.REPORT, "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_AMT_PAID", DataTypes.Numeric, 9);
			AddControl(ReportSection.REPORT, "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_AMT_REDUCTIONS", DataTypes.Numeric, 9);
			AddControl(ReportSection.REPORT, "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_CHEQUE_IND", DataTypes.Character, 1);
			AddControl(ReportSection.REPORT, "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_TOTAL_CLINIC_AMT", DataTypes.Numeric, 9);
			AddControl(ReportSection.REPORT, "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_TRANS_AMT", DataTypes.Numeric, 8);
			AddControl(ReportSection.REPORT, "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_TRANS_CD", DataTypes.Character, 2);
			AddControl(ReportSection.REPORT, "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_TRANS_DATE", DataTypes.Numeric, 8);
			AddControl(ReportSection.REPORT, "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_TRANS_MESSAGE", DataTypes.Character, 50);
		}

		catch (Exception ex)
		{
			// Write the exception to the log file.
			ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		}
	}

	#endregion

	#region " Renaissance Precompiler Generated Code "

	//# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
	//# Do not delete, modify or move it.  Updated: 10/10/2017 12:10:57 PM

	public override string ReturnControlValue(string strControl, int intSize)
	{
		switch (strControl) {
			case "PAYMENT_TYPE":
				return Common.StringToField(PAYMENT_TYPE().PadRight( 4, ' '));

			case "X_CLINIC":
				return X_CLINIC().ToString().ToString().PadLeft( 2, ' ');

			case "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_AMT_ADVANCES":
				return rdrU030_TAPE_67_FILE.GetNumber("RAT_67_AMT_ADVANCES").ToString().PadLeft( 9, ' ');

			case "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_AMT_BILL":
				return rdrU030_TAPE_67_FILE.GetNumber("RAT_67_AMT_BILL").ToString().PadLeft( 9, ' ');

			case "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_AMT_CLAIMS_ADJ":
				return rdrU030_TAPE_67_FILE.GetNumber("RAT_67_AMT_CLAIMS_ADJ").ToString().PadLeft( 9, ' ');

			case "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_AMT_DEDUCTIONS":
				return rdrU030_TAPE_67_FILE.GetNumber("RAT_67_AMT_DEDUCTIONS").ToString().PadLeft( 9, ' ');

			case "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_AMT_PAID":
				return rdrU030_TAPE_67_FILE.GetNumber("RAT_67_AMT_PAID").ToString().PadLeft( 9, ' ');

			case "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_AMT_REDUCTIONS":
				return rdrU030_TAPE_67_FILE.GetNumber("RAT_67_AMT_REDUCTIONS").ToString().PadLeft( 9, ' ');

			case "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_CHEQUE_IND":
				return Common.StringToField(rdrU030_TAPE_67_FILE.GetString("RAT_67_CHEQUE_IND").PadRight( 1, ' '));

			case "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_TOTAL_CLINIC_AMT":
				return rdrU030_TAPE_67_FILE.GetNumber("RAT_67_TOTAL_CLINIC_AMT").ToString().PadLeft( 9, ' ');

			case "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_TRANS_AMT":
				return rdrU030_TAPE_67_FILE.GetNumber("RAT_67_TRANS_AMT").ToString().PadLeft( 8, ' ');

			case "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_TRANS_CD":
				return Common.StringToField(rdrU030_TAPE_67_FILE.GetString("RAT_67_TRANS_CD").PadRight( 2, ' '));

			case "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_TRANS_DATE":
                    return rdrU030_TAPE_67_FILE.GetNumber("RAT_67_TRANS_DATE").ToString().PadLeft(8, ' ');

                case "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_TRANS_MESSAGE":
				return Common.StringToField(rdrU030_TAPE_67_FILE.GetString("RAT_67_TRANS_MESSAGE").PadRight( 50, ' '));

			default:
				return string.Empty;
		}
	}

	public override void AccessData()
	{
		try
		{
			Access_U030_TAPE_67_FILE();

			while (rdrU030_TAPE_67_FILE.Read()) {
				WriteData();
			}
			rdrU030_TAPE_67_FILE.Close();

		}

		catch (Exception ex)
		{
			ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		}
	}

	public override void CloseReaders()
	{
		if ((rdrU030_TAPE_67_FILE != null)) {
			rdrU030_TAPE_67_FILE.Close();
			rdrU030_TAPE_67_FILE = null;
		}
	}


	#endregion

	#endregion
}
}
