#region "Screen Comments"

// 2016/Dec/01 MC utl0013.qzs
// Helena made the below rule:
// If the doctor has a Dept 13 and Dept 14 RMA #, Dept 14 should be credited with the OHIP discounts (MOHD) 
// and the OHIP premiums (AGEP).
// This program should be run before running for MOHD and/or AGEP macros
// This program will set `Y` to pay-this-doctor-ohip-premium for dept 14 if doctor has both dept 13 and 14
// This is the second pass of utl0013

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
    public class UTL0013 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "UTL0013";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrUTL0013_B = new Reader();

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

                Sort = "DOC_OHIP_NBR ASC";

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

        private void Access_UTL0013_B()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_OHIP_NBR ");
            strSQL.Append("FROM TEMPORARYDATA.UTL0013_B ");

            strSQL.Append(Choose());

            rdrUTL0013_B.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

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

        #endregion

        #region " CONTROLS "

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.UTL0013_B.REC_IND", DataTypes.Character, 6);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.UTL0013_B.DOC_OHIP_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.UTL0013_B.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.UTL0013_B.DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "DOC_DATE_FAC_TERM", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.UTL0013_B.PAY_THIS_DOCTOR_OHIP_PREMIUM", DataTypes.Character, 1);
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
        //# Do not delete, modify or move it.  Updated: 10/10/2017 11:40:03 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.UTL0013_B.REC_IND":
                    return Common.StringToField(rdrUTL0013_B.GetString("REC_IND").PadRight(6, ' '));

                case "TEMPORARYDATA.UTL0013_B.DOC_OHIP_NBR":
                    return rdrUTL0013_B.GetNumber("DOC_OHIP_NBR").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.UTL0013_B.DOC_NBR":
                    return Common.StringToField(rdrUTL0013_B.GetString("DOC_NBR").PadRight(3, ' '));

                case "TEMPORARYDATA.UTL0013_B.DOC_DEPT":
                    return rdrUTL0013_B.GetNumber("DOC_DEPT").ToString().PadLeft(2, ' ');

                case "DOC_DATE_FAC_TERM":
                    return QDesign.NConvert(rdrUTL0013_B.GetNumber("DOC_DATE_FAC_TERM_YY").ToString() + rdrUTL0013_B.GetNumber("DOC_DATE_FAC_TERM_MM").ToString() + rdrUTL0013_B.GetNumber("DOC_DATE_FAC_TERM_DD").ToString()).ToString().PadLeft(8, ' ');

                case "TEMPORARYDATA.UTL0013_B.PAY_THIS_DOCTOR_OHIP_PREMIUM":
                    return Common.StringToField(rdrUTL0013_B.GetString("PAY_THIS_DOCTOR_OHIP_PREMIUM").PadRight(1, ' '));

                default:

                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_UTL0013_B();

                while (rdrUTL0013_B.Read())
                {
                    WriteData();
                }
                rdrUTL0013_B.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrUTL0013_B != null))
            {
                rdrUTL0013_B.Close();
                rdrUTL0013_B = null;
            }
        }


        #endregion

        #endregion
    }
}
