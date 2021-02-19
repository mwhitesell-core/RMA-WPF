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
    public class R021A_2 : BaseRDLClass
    {
        protected const string REPORT_NAME = "R021A_2";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrU021A_EDT_RMB_FILE = new Reader();
        private Reader rdrF093_HDR_1 = new Reader();
        private Reader rdrF093_HDR_2 = new Reader();
        private Reader rdrF093_HDR_3 = new Reader();
        private Reader rdrF093_HDR_4 = new Reader();
        private Reader rdrF093_HDR_5 = new Reader();
        private Reader rdrF093_DTL_1 = new Reader();
        private Reader rdrF093_DTL_2 = new Reader();
        private Reader rdrF093_DTL_3 = new Reader();
        private Reader rdrF093_DTL_4 = new Reader();
        private Reader rdrF093_DTL_5 = new Reader();
        private Reader rdrR021A = new Reader();
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
                SubFileName = "R021A";
                SubFileType = SubFileType.Keep;
                SubFileAT = "TODO: Enter sortbreak name";
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
        private void Access_U021A_EDT_RMB_FILE()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("RAT_RMB_ERROR_H_CD_1, ");
            strSQL.Append("RAT_RMB_ERROR_H_CD_2, ");
            strSQL.Append("RAT_RMB_ERROR_H_CD_3, ");
            strSQL.Append("RAT_RMB_ERROR_H_CD_4, ");
            strSQL.Append("RAT_RMB_ERROR_H_CD_5, ");
            strSQL.Append("RAT_RMB_ERROR_T_CD_1, ");
            strSQL.Append("RAT_RMB_ERROR_T_CD_2, ");
            strSQL.Append("RAT_RMB_ERROR_T_CD_3, ");
            strSQL.Append("RAT_RMB_ERROR_T_CD_4, ");
            strSQL.Append("RAT_RMB_ERROR_T_CD_5, ");
            strSQL.Append("RAT_RMB_GROUP_NBR, ");
            strSQL.Append("RAT_RMB_ACCOUNT_NBR, ");
            strSQL.Append("RAT_RMB_PROCESS_DATE, ");
            strSQL.Append("RAT_RMB_FILE_NAME ");
            strSQL.Append("FROM SEQUENTIAL.U021A_EDT_RMB_FILE ");
            strSQL.Append(Choose());
            rdrU021A_EDT_RMB_FILE.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.m_strFlatFileDictionary, ReportFunctions.TextFiles);
            strSQL = null;
        }
        private void Link_F093_HDR_1()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("OHIP_ERR_CODE ");
            strSQL.Append("FROM INDEXED.F093_OHIP_ERROR_MSG_MSTR F093_HDR_1 ");
            strSQL.Append("WHERE ");
            strSQL.Append("OHIP_ERR_CODE = ").Append(Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ERROR_H_CD_1")));
            rdrF093_HDR_1.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F093_HDR_2()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("OHIP_ERR_CODE ");
            strSQL.Append("FROM INDEXED.F093_OHIP_ERROR_MSG_MSTR F093_HDR_2 ");
            strSQL.Append("WHERE ");
            strSQL.Append("OHIP_ERR_CODE = ").Append(Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ERROR_H_CD_2")));
            rdrF093_HDR_2.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F093_HDR_3()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("OHIP_ERR_CODE ");
            strSQL.Append("FROM INDEXED.F093_OHIP_ERROR_MSG_MSTR F093_HDR_3 ");
            strSQL.Append("WHERE ");
            strSQL.Append("OHIP_ERR_CODE = ").Append(Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ERROR_H_CD_3")));
            rdrF093_HDR_3.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F093_HDR_4()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("OHIP_ERR_CODE ");
            strSQL.Append("FROM INDEXED.F093_OHIP_ERROR_MSG_MSTR F093_HDR_4 ");
            strSQL.Append("WHERE ");
            strSQL.Append("OHIP_ERR_CODE = ").Append(Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ERROR_H_CD_4")));
            rdrF093_HDR_4.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F093_HDR_5()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("OHIP_ERR_CODE ");
            strSQL.Append("FROM INDEXED.F093_OHIP_ERROR_MSG_MSTR F093_HDR_5 ");
            strSQL.Append("WHERE ");
            strSQL.Append("OHIP_ERR_CODE = ").Append(Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ERROR_H_CD_5")));
            rdrF093_HDR_5.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F093_DTL_1()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("OHIP_ERR_CODE ");
            strSQL.Append("FROM INDEXED.F093_OHIP_ERROR_MSG_MSTR F093_DTL_1 ");
            strSQL.Append("WHERE ");
            strSQL.Append("OHIP_ERR_CODE = ").Append(Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ERROR_T_CD_1")));
            rdrF093_DTL_1.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F093_DTL_2()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("OHIP_ERR_CODE ");
            strSQL.Append("FROM INDEXED.F093_OHIP_ERROR_MSG_MSTR F093_DTL_2 ");
            strSQL.Append("WHERE ");
            strSQL.Append("OHIP_ERR_CODE = ").Append(Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ERROR_T_CD_2")));
            rdrF093_DTL_2.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F093_DTL_3()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("OHIP_ERR_CODE ");
            strSQL.Append("FROM INDEXED.F093_OHIP_ERROR_MSG_MSTR F093_DTL_3 ");
            strSQL.Append("WHERE ");
            strSQL.Append("OHIP_ERR_CODE = ").Append(Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ERROR_T_CD_3")));
            rdrF093_DTL_3.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F093_DTL_4()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("OHIP_ERR_CODE ");
            strSQL.Append("FROM INDEXED.F093_OHIP_ERROR_MSG_MSTR F093_DTL_4 ");
            strSQL.Append("WHERE ");
            strSQL.Append("OHIP_ERR_CODE = ").Append(Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ERROR_T_CD_4")));
            rdrF093_DTL_4.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F093_DTL_5()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("OHIP_ERR_CODE ");
            strSQL.Append("FROM INDEXED.F093_OHIP_ERROR_MSG_MSTR F093_DTL_5 ");
            strSQL.Append("WHERE ");
            strSQL.Append("OHIP_ERR_CODE = ").Append(Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ERROR_T_CD_5")));
            rdrF093_DTL_5.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            // TODO: CHOOSE Statement - May require manual changes.
            return strChoose.ToString().ToString();
        }

        public override bool SelectIf()
        {
            bool blnSelected = false;
            if ((QDesign.NULL(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ERROR_H_CD_1")) != QDesign.NULL(" ") && !ReportDataFunctions.Exists(rdrF093_HDR_1)) ||
                (QDesign.NULL(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ERROR_H_CD_2")) != QDesign.NULL(" ") && !ReportDataFunctions.Exists(rdrF093_HDR_2)) ||
                (QDesign.NULL(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ERROR_H_CD_3")) != QDesign.NULL(" ") && !ReportDataFunctions.Exists(rdrF093_HDR_3)) ||
                (QDesign.NULL(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ERROR_H_CD_4")) != QDesign.NULL(" ") && !ReportDataFunctions.Exists(rdrF093_HDR_4)) ||
                (QDesign.NULL(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ERROR_H_CD_5")) != QDesign.NULL(" ") && !ReportDataFunctions.Exists(rdrF093_HDR_5)) ||
                (QDesign.NULL(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ERROR_T_CD_1")) != QDesign.NULL(" ") && !ReportDataFunctions.Exists(rdrF093_DTL_1)) ||
                (QDesign.NULL(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ERROR_T_CD_2")) != QDesign.NULL(" ") && !ReportDataFunctions.Exists(rdrF093_DTL_2)) ||
                (QDesign.NULL(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ERROR_T_CD_3")) != QDesign.NULL(" ") && !ReportDataFunctions.Exists(rdrF093_DTL_3)) ||
                (QDesign.NULL(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ERROR_T_CD_4")) != QDesign.NULL(" ") && !ReportDataFunctions.Exists(rdrF093_DTL_4)) ||
                (QDesign.NULL(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ERROR_T_CD_5")) != QDesign.NULL(" ") && !ReportDataFunctions.Exists(rdrF093_DTL_5)))
            {
                blnSelected = true;
            }

            return blnSelected;
        }
        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.SUMMARY, "SEQUENTIAL.U021A_EDT_RMB_FILE.RAT_RMB_GROUP_NBR", DataTypes.Character, 4);
                AddControl(ReportSection.SUMMARY, "SEQUENTIAL.U021A_EDT_RMB_FILE.RAT_RMB_ACCOUNT_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "SEQUENTIAL.U021A_EDT_RMB_FILE.RAT_RMB_ERROR_H_CD_1", DataTypes.Character, 3);
                AddControl(ReportSection.SUMMARY, "SEQUENTIAL.U021A_EDT_RMB_FILE.RAT_RMB_ERROR_H_CD_2", DataTypes.Character, 3);
                AddControl(ReportSection.SUMMARY, "SEQUENTIAL.U021A_EDT_RMB_FILE.RAT_RMB_ERROR_H_CD_3", DataTypes.Character, 3);
                AddControl(ReportSection.SUMMARY, "SEQUENTIAL.U021A_EDT_RMB_FILE.RAT_RMB_ERROR_H_CD_4", DataTypes.Character, 3);
                AddControl(ReportSection.SUMMARY, "SEQUENTIAL.U021A_EDT_RMB_FILE.RAT_RMB_ERROR_H_CD_5", DataTypes.Character, 3);
                AddControl(ReportSection.SUMMARY, "SEQUENTIAL.U021A_EDT_RMB_FILE.RAT_RMB_ERROR_T_CD_1", DataTypes.Character, 3);
                AddControl(ReportSection.SUMMARY, "SEQUENTIAL.U021A_EDT_RMB_FILE.RAT_RMB_ERROR_T_CD_2", DataTypes.Character, 3);
                AddControl(ReportSection.SUMMARY, "SEQUENTIAL.U021A_EDT_RMB_FILE.RAT_RMB_ERROR_T_CD_3", DataTypes.Character, 3);
                AddControl(ReportSection.SUMMARY, "SEQUENTIAL.U021A_EDT_RMB_FILE.RAT_RMB_ERROR_T_CD_4", DataTypes.Character, 3);
                AddControl(ReportSection.SUMMARY, "SEQUENTIAL.U021A_EDT_RMB_FILE.RAT_RMB_ERROR_T_CD_5", DataTypes.Character, 3);
                AddControl(ReportSection.SUMMARY, "SEQUENTIAL.U021A_EDT_RMB_FILE.RAT_RMB_PROCESS_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.SUMMARY, "SEQUENTIAL.U021A_EDT_RMB_FILE.RAT_RMB_FILE_NAME", DataTypes.Character, 12);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2019-01-29 10:23:45 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "SEQUENTIAL.U021A_EDT_RMB_FILE.RAT_RMB_GROUP_NBR":
                    return Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_GROUP_NBR"));
                case "SEQUENTIAL.U021A_EDT_RMB_FILE.RAT_RMB_ACCOUNT_NBR":
                    return Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ACCOUNT_NBR"));
                case "SEQUENTIAL.U021A_EDT_RMB_FILE.RAT_RMB_ERROR_H_CD_1":
                    return Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ERROR_H_CD_1"));
                case "SEQUENTIAL.U021A_EDT_RMB_FILE.RAT_RMB_ERROR_H_CD_2":
                    return Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ERROR_H_CD_2"));
                case "SEQUENTIAL.U021A_EDT_RMB_FILE.RAT_RMB_ERROR_H_CD_3":
                    return Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ERROR_H_CD_3"));
                case "SEQUENTIAL.U021A_EDT_RMB_FILE.RAT_RMB_ERROR_H_CD_4":
                    return Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ERROR_H_CD_4"));
                case "SEQUENTIAL.U021A_EDT_RMB_FILE.RAT_RMB_ERROR_H_CD_5":
                    return Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ERROR_H_CD_5"));
                case "SEQUENTIAL.U021A_EDT_RMB_FILE.RAT_RMB_ERROR_T_CD_1":
                    return Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ERROR_T_CD_1"));
                case "SEQUENTIAL.U021A_EDT_RMB_FILE.RAT_RMB_ERROR_T_CD_2":
                    return Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ERROR_T_CD_2"));
                case "SEQUENTIAL.U021A_EDT_RMB_FILE.RAT_RMB_ERROR_T_CD_3":
                    return Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ERROR_T_CD_3"));
                case "SEQUENTIAL.U021A_EDT_RMB_FILE.RAT_RMB_ERROR_T_CD_4":
                    return Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ERROR_T_CD_4"));
                case "SEQUENTIAL.U021A_EDT_RMB_FILE.RAT_RMB_ERROR_T_CD_5":
                    return Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ERROR_T_CD_5"));
                case "SEQUENTIAL.U021A_EDT_RMB_FILE.RAT_RMB_PROCESS_DATE":
                    return rdrU021A_EDT_RMB_FILE.GetNumber("RAT_RMB_PROCESS_DATE").ToString();
                case "SEQUENTIAL.U021A_EDT_RMB_FILE.RAT_RMB_FILE_NAME":
                    return Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_FILE_NAME"));
                default:
                    return String.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_U021A_EDT_RMB_FILE();
                while (rdrU021A_EDT_RMB_FILE.Read())
                {
                    Link_F093_HDR_1();
                    while (rdrF093_HDR_1.Read())
                    {
                        Link_F093_HDR_2();
                        while (rdrF093_HDR_2.Read())
                        {
                            Link_F093_HDR_3();
                            while (rdrF093_HDR_3.Read())
                            {
                                Link_F093_HDR_4();
                                while (rdrF093_HDR_4.Read())
                                {
                                    Link_F093_HDR_5();
                                    while (rdrF093_HDR_5.Read())
                                    {
                                        Link_F093_DTL_1();
                                        while (rdrF093_DTL_1.Read())
                                        {
                                            Link_F093_DTL_2();
                                            while (rdrF093_DTL_2.Read())
                                            {
                                                Link_F093_DTL_3();
                                                while (rdrF093_DTL_3.Read())
                                                {
                                                    Link_F093_DTL_4();
                                                    while (rdrF093_DTL_4.Read())
                                                    {
                                                        Link_F093_DTL_5();
                                                        while (rdrF093_DTL_5.Read())
                                                        {
                                                            WriteData();
                                                        }
                                                        rdrF093_DTL_5.Close();
                                                    }
                                                    rdrF093_DTL_4.Close();
                                                }
                                                rdrF093_DTL_3.Close();
                                            }
                                            rdrF093_DTL_2.Close();
                                        }
                                        rdrF093_DTL_1.Close();
                                    }
                                    rdrF093_HDR_5.Close();
                                }
                                rdrF093_HDR_4.Close();
                            }
                            rdrF093_HDR_3.Close();
                        }
                        rdrF093_HDR_2.Close();
                    }
                    rdrF093_HDR_1.Close();
                }
                rdrU021A_EDT_RMB_FILE.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrU021A_EDT_RMB_FILE == null))
            {
                rdrU021A_EDT_RMB_FILE.Close();
                rdrU021A_EDT_RMB_FILE = null;
            }

            if (!(rdrF093_HDR_1 == null))
            {
                rdrF093_HDR_1.Close();
                rdrF093_HDR_1 = null;
            }

            if (!(rdrF093_HDR_2 == null))
            {
                rdrF093_HDR_2.Close();
                rdrF093_HDR_2 = null;
            }

            if (!(rdrF093_HDR_3 == null))
            {
                rdrF093_HDR_3.Close();
                rdrF093_HDR_3 = null;
            }

            if (!(rdrF093_HDR_4 == null))
            {
                rdrF093_HDR_4.Close();
                rdrF093_HDR_4 = null;
            }

            if (!(rdrF093_HDR_5 == null))
            {
                rdrF093_HDR_5.Close();
                rdrF093_HDR_5 = null;
            }

            if (!(rdrF093_DTL_1 == null))
            {
                rdrF093_DTL_1.Close();
                rdrF093_DTL_1 = null;
            }

            if (!(rdrF093_DTL_2 == null))
            {
                rdrF093_DTL_2.Close();
                rdrF093_DTL_2 = null;
            }

            if (!(rdrF093_DTL_3 == null))
            {
                rdrF093_DTL_3.Close();
                rdrF093_DTL_3 = null;
            }

            if (!(rdrF093_DTL_4 == null))
            {
                rdrF093_DTL_4.Close();
                rdrF093_DTL_4 = null;
            }

            if (!(rdrF093_DTL_5 == null))
            {
                rdrF093_DTL_5.Close();
                rdrF093_DTL_5 = null;
            }
        }
    }
}
