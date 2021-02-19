#region "Screen Comments"

// 2013/09/11 - MC2 - add new pass for undefined doctor transactions

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
    public class R031_BEFORE_UPDATE_3 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R031_BEFORE_UPDATE_3";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrR031A_OHIP_PREMIUMS = new Reader();
        private Reader rdrF020_DOCTOR_MSTR = new Reader();

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

        private void Access_R031A_OHIP_PREMIUMS()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT * ");
            strSQL.Append("FROM SEQUENTIAL.R031A ");

            strSQL.Append(Choose());

            rdrR031A_OHIP_PREMIUMS.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.m_strFlatFileDictionary, ReportFunctions.TextFiles);

            strSQL = null;
        }

        private void Link_F020_DOCTOR_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_OHIP_NBR ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_OHIP_NBR = ").Append(rdrR031A_OHIP_PREMIUMS.GetNumber("DOC_OHIP_NBR"));

            rdrF020_DOCTOR_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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

            if (!ReportDataFunctions.Exists(rdrF020_DOCTOR_MSTR))
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        #endregion

        #region " DEFINES "

        private Decimal X_PAID_AMT()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(QDesign.Substring(rdrR031A_OHIP_PREMIUMS.GetString("DOLLARS_PAID"), 1, 1)) == QDesign.NULL("-"))
                {
                    decReturnValue = QDesign.NConvert(QDesign.Substring(rdrR031A_OHIP_PREMIUMS.GetString("DOLLARS_PAID"), 2, 2) + QDesign.Substring(rdrR031A_OHIP_PREMIUMS.GetString("DOLLARS_PAID"), 5, 3) + QDesign.Substring(rdrR031A_OHIP_PREMIUMS.GetString("DOLLARS_PAID"), 9, 2)) * -1;
                }
                else
                {
                    decReturnValue = QDesign.NConvert(QDesign.Substring(rdrR031A_OHIP_PREMIUMS.GetString("DOLLARS_PAID"), 1, 3) + QDesign.Substring(rdrR031A_OHIP_PREMIUMS.GetString("DOLLARS_PAID"), 5, 3) + QDesign.Substring(rdrR031A_OHIP_PREMIUMS.GetString("DOLLARS_PAID"), 9, 2));
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
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
                AddControl(ReportSection.REPORT, "SEQUENTIAL.R031A_OHIP_PREMIUMS.ICONST_CLINIC_NBR_1_2", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "SEQUENTIAL.R031A_OHIP_PREMIUMS.CLMHDR_ADJ_CD", DataTypes.Character, 5);
                AddControl(ReportSection.REPORT, "X_PAID_AMT", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "SEQUENTIAL.R031A_OHIP_PREMIUMS.DOC_OHIP_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "SEQUENTIAL.R031A_OHIP_PREMIUMS.DOC_NAME", DataTypes.Character, 24);
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
        //# Do not delete, modify or move it.  Updated: 9/28/2017 7:51:48 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "SEQUENTIAL.R031A_OHIP_PREMIUMS.ICONST_CLINIC_NBR_1_2":
                    return rdrR031A_OHIP_PREMIUMS.GetNumber("ICONST_CLINIC_NBR_1_2").ToString().PadLeft(2, ' ');

                case "SEQUENTIAL.R031A_OHIP_PREMIUMS.CLMHDR_ADJ_CD":
                    return Common.StringToField(rdrR031A_OHIP_PREMIUMS.GetString("CLMHDR_ADJ_CD").PadRight(5, ' '));

                case "X_PAID_AMT":
                    return X_PAID_AMT().ToString().PadLeft(8, ' ');

                case "SEQUENTIAL.R031A_OHIP_PREMIUMS.DOC_OHIP_NBR":
                    return rdrR031A_OHIP_PREMIUMS.GetNumber("DOC_OHIP_NBR").ToString().PadLeft(6, ' ');

                case "SEQUENTIAL.R031A_OHIP_PREMIUMS.DOC_NAME":
                    return Common.StringToField(rdrR031A_OHIP_PREMIUMS.GetString("DOC_NAME").PadRight(24, ' '));

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_R031A_OHIP_PREMIUMS();

                while (rdrR031A_OHIP_PREMIUMS.Read())
                {
                    Link_F020_DOCTOR_MSTR();
                    while (rdrF020_DOCTOR_MSTR.Read())
                    {
                        WriteData();
                    }
                    rdrF020_DOCTOR_MSTR.Close();
                }
                rdrR031A_OHIP_PREMIUMS.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrR031A_OHIP_PREMIUMS != null))
            {
                rdrR031A_OHIP_PREMIUMS.Close();
                rdrR031A_OHIP_PREMIUMS = null;
            }
            if ((rdrF020_DOCTOR_MSTR != null))
            {
                rdrF020_DOCTOR_MSTR.Close();
                rdrF020_DOCTOR_MSTR = null;
            }
        }


        #endregion

        #endregion
    }
}
