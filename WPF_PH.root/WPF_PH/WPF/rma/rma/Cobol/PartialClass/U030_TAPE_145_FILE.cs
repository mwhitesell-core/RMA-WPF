using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using rma.Cobol;

namespace RmaDAL
{
    public partial class U030_TAPE_145_FILE
    {
        public void Submit_SingleConnection()
        {
            SqlParameter[] parameters;
            switch (RecordState)
            {
                case State.Adding:
                case State.Added:
                    parameters = new SqlParameter[]
                    {
                        new SqlParameter("RAT_145_GROUP_NBR", SqlNull(RAT_145_GROUP_NBR)),
                        new SqlParameter("RAT_145_MOH_OFF_CD", SqlNull(RAT_145_MOH_OFF_CD)),
                        new SqlParameter("RAT_145_DATA_SEQ_NBR", SqlNull(RAT_145_DATA_SEQ_NBR)),
                        new SqlParameter("RAT_145_PAYMENT_DATE", SqlNull(RAT_145_PAYMENT_DATE)),
                        new SqlParameter("RAT_145_PAY_LAST_NAME", SqlNull(RAT_145_PAY_LAST_NAME)),
                        new SqlParameter("RAT_145_PAY_TITLE", SqlNull(RAT_145_PAY_TITLE)),
                        new SqlParameter("RAT_145_PAY_INITIALS", SqlNull(RAT_145_PAY_INITIALS)),
                        new SqlParameter("RAT_145_TOT_AMT_PAY", SqlNull(RAT_145_TOT_AMT_PAY)),
                        new SqlParameter("RAT_145_CHEQ_NBR", SqlNull(RAT_145_CHEQ_NBR)),
                        new SqlParameter("RAT_145_CLAIM_NBR", SqlNull(RAT_145_CLAIM_NBR)),
                        new SqlParameter("RAT_145_TRANS_TYPE", SqlNull(RAT_145_TRANS_TYPE)),
                        new SqlParameter("RAT_145_DOC_NBR", SqlNull(RAT_145_DOC_NBR)),
                        new SqlParameter("RAT_145_SPECIALTY_CD", SqlNull(RAT_145_SPECIALTY_CD)),
                        new SqlParameter("RAT_145_ACCOUNT_NBR", SqlNull(RAT_145_ACCOUNT_NBR)),
                        new SqlParameter("RAT_145_LAST_NAME", SqlNull(RAT_145_LAST_NAME)),
                        new SqlParameter("RAT_145_FIRST_NAME", SqlNull(RAT_145_FIRST_NAME)),
                        new SqlParameter("RAT_145_PROV_CD", SqlNull(RAT_145_PROV_CD)),
                        new SqlParameter("RAT_145_HEALTH_OHIP_NBR", SqlNull(RAT_145_HEALTH_OHIP_NBR)),
                        new SqlParameter("RAT_145_VERSION_CD", SqlNull(RAT_145_VERSION_CD)),
                        new SqlParameter("RAT_145_PAY_PROG", SqlNull(RAT_145_PAY_PROG)),
                        new SqlParameter("RAT_145_CONV_HEALTH_NBR", SqlNull(RAT_145_CONV_HEALTH_NBR)),
                        new SqlParameter("RAT_145_SERVICE_DATE", SqlNull(RAT_145_SERVICE_DATE)),
                        new SqlParameter("RAT_145_NBR_OF_SERV", SqlNull(RAT_145_NBR_OF_SERV)),
                        new SqlParameter("RAT_145_SERVICE_CD", SqlNull(RAT_145_SERVICE_CD)),
                        new SqlParameter("RAT_145_ELIGIBILITY_IND", SqlNull(RAT_145_ELIGIBILITY_IND)),
                        new SqlParameter("RAT_145_AMOUNT_SUB", SqlNull(RAT_145_AMOUNT_SUB)),
                        new SqlParameter("RAT_145_AMT_PAID", SqlNull(RAT_145_AMT_PAID)),
                        new SqlParameter("RAT_145_EXPLAN_CD", SqlNull(RAT_145_EXPLAN_CD)),
                        new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
                    };
                    if (Reader != null) Reader.Dispose();
                    Reader = CoreReader("[SEQUENTIAL].[sp_U030_TAPE_145_FILE_Insert]", parameters);
                    break;
                case State.Modified:
                    parameters = new SqlParameter[]
                    {
                        new SqlParameter("RowCheckSum",RowCheckSum),
                        new SqlParameter("ROWID", ROWID),
                        new SqlParameter("RAT_145_GROUP_NBR", SqlNull(RAT_145_GROUP_NBR)),
                        new SqlParameter("RAT_145_MOH_OFF_CD", SqlNull(RAT_145_MOH_OFF_CD)),
                        new SqlParameter("RAT_145_DATA_SEQ_NBR", SqlNull(RAT_145_DATA_SEQ_NBR)),
                        new SqlParameter("RAT_145_PAYMENT_DATE", SqlNull(RAT_145_PAYMENT_DATE)),
                        new SqlParameter("RAT_145_PAY_LAST_NAME", SqlNull(RAT_145_PAY_LAST_NAME)),
                        new SqlParameter("RAT_145_PAY_TITLE", SqlNull(RAT_145_PAY_TITLE)),
                        new SqlParameter("RAT_145_PAY_INITIALS", SqlNull(RAT_145_PAY_INITIALS)),
                        new SqlParameter("RAT_145_TOT_AMT_PAY", SqlNull(RAT_145_TOT_AMT_PAY)),
                        new SqlParameter("RAT_145_CHEQ_NBR", SqlNull(RAT_145_CHEQ_NBR)),
                        new SqlParameter("RAT_145_CLAIM_NBR", SqlNull(RAT_145_CLAIM_NBR)),
                        new SqlParameter("RAT_145_TRANS_TYPE", SqlNull(RAT_145_TRANS_TYPE)),
                        new SqlParameter("RAT_145_DOC_NBR", SqlNull(RAT_145_DOC_NBR)),
                        new SqlParameter("RAT_145_SPECIALTY_CD", SqlNull(RAT_145_SPECIALTY_CD)),
                        new SqlParameter("RAT_145_ACCOUNT_NBR", SqlNull(RAT_145_ACCOUNT_NBR)),
                        new SqlParameter("RAT_145_LAST_NAME", SqlNull(RAT_145_LAST_NAME)),
                        new SqlParameter("RAT_145_FIRST_NAME", SqlNull(RAT_145_FIRST_NAME)),
                        new SqlParameter("RAT_145_PROV_CD", SqlNull(RAT_145_PROV_CD)),
                        new SqlParameter("RAT_145_HEALTH_OHIP_NBR", SqlNull(RAT_145_HEALTH_OHIP_NBR)),
                        new SqlParameter("RAT_145_VERSION_CD", SqlNull(RAT_145_VERSION_CD)),
                        new SqlParameter("RAT_145_PAY_PROG", SqlNull(RAT_145_PAY_PROG)),
                        new SqlParameter("RAT_145_CONV_HEALTH_NBR", SqlNull(RAT_145_CONV_HEALTH_NBR)),
                        new SqlParameter("RAT_145_SERVICE_DATE", SqlNull(RAT_145_SERVICE_DATE)),
                        new SqlParameter("RAT_145_NBR_OF_SERV", SqlNull(RAT_145_NBR_OF_SERV)),
                        new SqlParameter("RAT_145_SERVICE_CD", SqlNull(RAT_145_SERVICE_CD)),
                        new SqlParameter("RAT_145_ELIGIBILITY_IND", SqlNull(RAT_145_ELIGIBILITY_IND)),
                        new SqlParameter("RAT_145_AMOUNT_SUB", SqlNull(RAT_145_AMOUNT_SUB)),
                        new SqlParameter("RAT_145_AMT_PAID", SqlNull(RAT_145_AMT_PAID)),
                        new SqlParameter("RAT_145_EXPLAN_CD", SqlNull(RAT_145_EXPLAN_CD)),
                        new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
                    };
                    if (Reader != null) Reader.Dispose();
                    Reader = CoreReader("[SEQUENTIAL].[sp_U030_TAPE_145_FILE_Update]", parameters);
                    break;
            }
            RecordState = State.UnChanged;
        }

        #region bulkInsert

        public void BulkInsert(ObservableCollection<U030_TAPE_145_FILE> U030_TAPE_145_FILE_Collection)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                DataTable tblU030_TAPE_145_FILE = MakeTable();

                foreach (var obj in U030_TAPE_145_FILE_Collection)
                {
                    DataRow dr = tblU030_TAPE_145_FILE.NewRow();
                    
                    dr["RAT_145_GROUP_NBR"] = obj.RAT_145_GROUP_NBR;                    
                    dr["RAT_145_MOH_OFF_CD"] = obj.RAT_145_MOH_OFF_CD;                    
                    dr["RAT_145_DATA_SEQ_NBR"] = Util.NumInt(obj.RAT_145_DATA_SEQ_NBR);                    
                    dr["RAT_145_PAYMENT_DATE"] = obj.RAT_145_PAYMENT_DATE;                    
                    dr["RAT_145_PAY_LAST_NAME"] = obj.RAT_145_PAY_LAST_NAME;                    
                    dr["RAT_145_PAY_TITLE"] = obj.RAT_145_PAY_TITLE;                    
                    dr["RAT_145_PAY_INITIALS"] = obj.RAT_145_PAY_INITIALS;                    
                    dr["RAT_145_TOT_AMT_PAY"] = Util.NumInt(obj.RAT_145_TOT_AMT_PAY);                    
                    dr["RAT_145_CHEQ_NBR"] = obj.RAT_145_CHEQ_NBR;                    
                    dr["RAT_145_CLAIM_NBR"] = obj.RAT_145_CLAIM_NBR;                    
                    dr["RAT_145_TRANS_TYPE"] = Util.NumInt(obj.RAT_145_TRANS_TYPE);                    
                    dr["RAT_145_DOC_NBR"] = Util.NumInt(obj.RAT_145_DOC_NBR);                    
                    dr["RAT_145_SPECIALTY_CD"] = Util.NumInt(obj.RAT_145_SPECIALTY_CD);                    
                    dr["RAT_145_ACCOUNT_NBR"] = obj.RAT_145_ACCOUNT_NBR;                    
                    dr["RAT_145_LAST_NAME"] = obj.RAT_145_LAST_NAME;                    
                    dr["RAT_145_FIRST_NAME"] = obj.RAT_145_FIRST_NAME;                    
                    dr["RAT_145_PROV_CD"] = obj.RAT_145_PROV_CD;                    
                    dr["RAT_145_HEALTH_OHIP_NBR"] = obj.RAT_145_HEALTH_OHIP_NBR;                    
                    dr["RAT_145_VERSION_CD"] = obj.RAT_145_VERSION_CD;                    
                    dr["RAT_145_PAY_PROG"] = obj.RAT_145_PAY_PROG;                    
                    dr["RAT_145_CONV_HEALTH_NBR"] = obj.RAT_145_CONV_HEALTH_NBR;                    
                    dr["RAT_145_SERVICE_DATE"] = Util.NumInt(obj.RAT_145_SERVICE_DATE);                    
                    dr["RAT_145_NBR_OF_SERV"] = Util.NumInt(obj.RAT_145_NBR_OF_SERV);                    
                    dr["RAT_145_SERVICE_CD"] = obj.RAT_145_SERVICE_CD;                    
                    dr["RAT_145_ELIGIBILITY_IND"] = obj.RAT_145_ELIGIBILITY_IND;                    
                    dr["RAT_145_AMOUNT_SUB"] = Util.NumInt(obj.RAT_145_AMOUNT_SUB);                    
                    dr["RAT_145_AMT_PAID"] = Util.NumInt(obj.RAT_145_AMT_PAID);                    
                    dr["RAT_145_EXPLAN_CD"] = obj.RAT_145_EXPLAN_CD;

                    tblU030_TAPE_145_FILE.Rows.Add(dr);
                }

                using (SqlBulkCopy blk = new SqlBulkCopy(con))
                {
                    blk.DestinationTableName = "SEQUENTIAL.U030_TAPE_145_FILE";
                    blk.ColumnMappings.Add("RAT_145_GROUP_NBR", "RAT_145_GROUP_NBR");
                    blk.ColumnMappings.Add("RAT_145_MOH_OFF_CD", "RAT_145_MOH_OFF_CD");
                    blk.ColumnMappings.Add("RAT_145_DATA_SEQ_NBR", "RAT_145_DATA_SEQ_NBR");
                    blk.ColumnMappings.Add("RAT_145_PAYMENT_DATE", "RAT_145_PAYMENT_DATE");
                    blk.ColumnMappings.Add("RAT_145_PAY_LAST_NAME", "RAT_145_PAY_LAST_NAME");
                    blk.ColumnMappings.Add("RAT_145_PAY_TITLE", "RAT_145_PAY_TITLE");
                    blk.ColumnMappings.Add("RAT_145_PAY_INITIALS", "RAT_145_PAY_INITIALS");
                    blk.ColumnMappings.Add("RAT_145_TOT_AMT_PAY", "RAT_145_TOT_AMT_PAY");
                    blk.ColumnMappings.Add("RAT_145_CHEQ_NBR", "RAT_145_CHEQ_NBR");
                    blk.ColumnMappings.Add("RAT_145_CLAIM_NBR", "RAT_145_CLAIM_NBR");
                    blk.ColumnMappings.Add("RAT_145_TRANS_TYPE", "RAT_145_TRANS_TYPE");
                    blk.ColumnMappings.Add("RAT_145_DOC_NBR", "RAT_145_DOC_NBR");
                    blk.ColumnMappings.Add("RAT_145_SPECIALTY_CD", "RAT_145_SPECIALTY_CD");
                    blk.ColumnMappings.Add("RAT_145_ACCOUNT_NBR", "RAT_145_ACCOUNT_NBR");
                    blk.ColumnMappings.Add("RAT_145_LAST_NAME", "RAT_145_LAST_NAME");
                    blk.ColumnMappings.Add("RAT_145_FIRST_NAME", "RAT_145_FIRST_NAME");
                    blk.ColumnMappings.Add("RAT_145_PROV_CD", "RAT_145_PROV_CD");
                    blk.ColumnMappings.Add("RAT_145_HEALTH_OHIP_NBR", "RAT_145_HEALTH_OHIP_NBR");
                    blk.ColumnMappings.Add("RAT_145_VERSION_CD", "RAT_145_VERSION_CD");
                    blk.ColumnMappings.Add("RAT_145_PAY_PROG", "RAT_145_PAY_PROG");
                    blk.ColumnMappings.Add("RAT_145_CONV_HEALTH_NBR", "RAT_145_CONV_HEALTH_NBR");
                    blk.ColumnMappings.Add("RAT_145_SERVICE_DATE", "RAT_145_SERVICE_DATE");
                    blk.ColumnMappings.Add("RAT_145_NBR_OF_SERV", "RAT_145_NBR_OF_SERV");
                    blk.ColumnMappings.Add("RAT_145_SERVICE_CD", "RAT_145_SERVICE_CD");
                    blk.ColumnMappings.Add("RAT_145_ELIGIBILITY_IND", "RAT_145_ELIGIBILITY_IND");
                    blk.ColumnMappings.Add("RAT_145_AMOUNT_SUB", "RAT_145_AMOUNT_SUB");
                    blk.ColumnMappings.Add("RAT_145_AMT_PAID", "RAT_145_AMT_PAID");
                    blk.ColumnMappings.Add("RAT_145_EXPLAN_CD", "RAT_145_EXPLAN_CD");
                    blk.WriteToServer(tblU030_TAPE_145_FILE);
                }

            }
        }

        private DataTable MakeTable()
        {
            DataTable tblU030_TAPE_145_FILE = new DataTable("U030_TAPE_145_FILE");
                        
            DataColumn RAT_145_GROUP_NBR = new DataColumn();
            RAT_145_GROUP_NBR.DataType = System.Type.GetType("System.String");
            RAT_145_GROUP_NBR.ColumnName = "RAT_145_GROUP_NBR";
            tblU030_TAPE_145_FILE.Columns.Add(RAT_145_GROUP_NBR);
            
            DataColumn RAT_145_MOH_OFF_CD = new DataColumn();
            RAT_145_MOH_OFF_CD.DataType = System.Type.GetType("System.String");
            RAT_145_MOH_OFF_CD.ColumnName = "RAT_145_MOH_OFF_CD";
            tblU030_TAPE_145_FILE.Columns.Add(RAT_145_MOH_OFF_CD);

            DataColumn RAT_145_DATA_SEQ_NBR = new DataColumn();
            RAT_145_DATA_SEQ_NBR.DataType = System.Type.GetType("System.Int32");
            RAT_145_DATA_SEQ_NBR.ColumnName = "RAT_145_DATA_SEQ_NBR";
            tblU030_TAPE_145_FILE.Columns.Add(RAT_145_DATA_SEQ_NBR);

            DataColumn RAT_145_PAYMENT_DATE = new DataColumn();
            RAT_145_PAYMENT_DATE.DataType = System.Type.GetType("System.Int32");
            RAT_145_PAYMENT_DATE.ColumnName = "RAT_145_PAYMENT_DATE";
            tblU030_TAPE_145_FILE.Columns.Add(RAT_145_PAYMENT_DATE);

            DataColumn RAT_145_PAY_LAST_NAME = new DataColumn();
            RAT_145_PAY_LAST_NAME.DataType = System.Type.GetType("System.String");
            RAT_145_PAY_LAST_NAME.ColumnName = "RAT_145_PAY_LAST_NAME";
            tblU030_TAPE_145_FILE.Columns.Add(RAT_145_PAY_LAST_NAME);

            DataColumn RAT_145_PAY_TITLE = new DataColumn();
            RAT_145_PAY_TITLE.DataType = System.Type.GetType("System.String");
            RAT_145_PAY_TITLE.ColumnName = "RAT_145_PAY_TITLE";
            tblU030_TAPE_145_FILE.Columns.Add(RAT_145_PAY_TITLE);

            DataColumn RAT_145_PAY_INITIALS = new DataColumn();
            RAT_145_PAY_INITIALS.DataType = System.Type.GetType("System.String");
            RAT_145_PAY_INITIALS.ColumnName = "RAT_145_PAY_INITIALS";
            tblU030_TAPE_145_FILE.Columns.Add(RAT_145_PAY_INITIALS);

            DataColumn RAT_145_TOT_AMT_PAY = new DataColumn();
            RAT_145_TOT_AMT_PAY.DataType = System.Type.GetType("System.Int32");
            RAT_145_TOT_AMT_PAY.ColumnName = "RAT_145_TOT_AMT_PAY";
            tblU030_TAPE_145_FILE.Columns.Add(RAT_145_TOT_AMT_PAY);

            DataColumn RAT_145_CHEQ_NBR = new DataColumn();
            RAT_145_CHEQ_NBR.DataType = System.Type.GetType("System.String");
            RAT_145_CHEQ_NBR.ColumnName = "RAT_145_CHEQ_NBR";
            tblU030_TAPE_145_FILE.Columns.Add(RAT_145_CHEQ_NBR);

            DataColumn RAT_145_CLAIM_NBR = new DataColumn();
            RAT_145_CLAIM_NBR.DataType = System.Type.GetType("System.String");
            RAT_145_CLAIM_NBR.ColumnName = "RAT_145_CLAIM_NBR";
            tblU030_TAPE_145_FILE.Columns.Add(RAT_145_CLAIM_NBR);

            DataColumn RAT_145_TRANS_TYPE = new DataColumn();
            RAT_145_TRANS_TYPE.DataType = System.Type.GetType("System.Int32");
            RAT_145_TRANS_TYPE.ColumnName = "RAT_145_TRANS_TYPE";
            tblU030_TAPE_145_FILE.Columns.Add(RAT_145_TRANS_TYPE);

            DataColumn RAT_145_DOC_NBR = new DataColumn();
            RAT_145_DOC_NBR.DataType = System.Type.GetType("System.Int32");
            RAT_145_DOC_NBR.ColumnName = "RAT_145_DOC_NBR";
            tblU030_TAPE_145_FILE.Columns.Add(RAT_145_DOC_NBR);

            DataColumn RAT_145_SPECIALTY_CD = new DataColumn();
            RAT_145_SPECIALTY_CD.DataType = System.Type.GetType("System.Int32");
            RAT_145_SPECIALTY_CD.ColumnName = "RAT_145_SPECIALTY_CD";
            tblU030_TAPE_145_FILE.Columns.Add(RAT_145_SPECIALTY_CD);

            DataColumn RAT_145_ACCOUNT_NBR = new DataColumn();
            RAT_145_ACCOUNT_NBR.DataType = System.Type.GetType("System.String");
            RAT_145_ACCOUNT_NBR.ColumnName = "RAT_145_ACCOUNT_NBR";
            tblU030_TAPE_145_FILE.Columns.Add(RAT_145_ACCOUNT_NBR);

            DataColumn RAT_145_LAST_NAME = new DataColumn();
            RAT_145_LAST_NAME.DataType = System.Type.GetType("System.String");
            RAT_145_LAST_NAME.ColumnName = "RAT_145_LAST_NAME";
            tblU030_TAPE_145_FILE.Columns.Add(RAT_145_LAST_NAME);

            DataColumn RAT_145_FIRST_NAME = new DataColumn();
            RAT_145_FIRST_NAME.DataType = System.Type.GetType("System.String");
            RAT_145_FIRST_NAME.ColumnName = "RAT_145_FIRST_NAME";
            tblU030_TAPE_145_FILE.Columns.Add(RAT_145_FIRST_NAME);

            DataColumn RAT_145_PROV_CD = new DataColumn();
            RAT_145_PROV_CD.DataType = System.Type.GetType("System.String");
            RAT_145_PROV_CD.ColumnName = "RAT_145_PROV_CD";
            tblU030_TAPE_145_FILE.Columns.Add(RAT_145_PROV_CD);

            DataColumn RAT_145_HEALTH_OHIP_NBR = new DataColumn();
            RAT_145_HEALTH_OHIP_NBR.DataType = System.Type.GetType("System.String");
            RAT_145_HEALTH_OHIP_NBR.ColumnName = "RAT_145_HEALTH_OHIP_NBR";
            tblU030_TAPE_145_FILE.Columns.Add(RAT_145_HEALTH_OHIP_NBR);

            DataColumn RAT_145_VERSION_CD = new DataColumn();
            RAT_145_VERSION_CD.DataType = System.Type.GetType("System.String");
            RAT_145_VERSION_CD.ColumnName = "RAT_145_VERSION_CD";
            tblU030_TAPE_145_FILE.Columns.Add(RAT_145_VERSION_CD);

            DataColumn RAT_145_PAY_PROG = new DataColumn();
            RAT_145_PAY_PROG.DataType = System.Type.GetType("System.String");
            RAT_145_PAY_PROG.ColumnName = "RAT_145_PAY_PROG";
            tblU030_TAPE_145_FILE.Columns.Add(RAT_145_PAY_PROG);

            DataColumn RAT_145_CONV_HEALTH_NBR = new DataColumn();
            RAT_145_CONV_HEALTH_NBR.DataType = System.Type.GetType("System.String");
            RAT_145_CONV_HEALTH_NBR.ColumnName = "RAT_145_CONV_HEALTH_NBR";
            tblU030_TAPE_145_FILE.Columns.Add(RAT_145_CONV_HEALTH_NBR);

            DataColumn RAT_145_SERVICE_DATE = new DataColumn();
            RAT_145_SERVICE_DATE.DataType = System.Type.GetType("System.Int32");
            RAT_145_SERVICE_DATE.ColumnName = "RAT_145_SERVICE_DATE";
            tblU030_TAPE_145_FILE.Columns.Add(RAT_145_SERVICE_DATE);

            DataColumn RAT_145_NBR_OF_SERV = new DataColumn();
            RAT_145_NBR_OF_SERV.DataType = System.Type.GetType("System.Int32");
            RAT_145_NBR_OF_SERV.ColumnName = "RAT_145_NBR_OF_SERV";
            tblU030_TAPE_145_FILE.Columns.Add(RAT_145_NBR_OF_SERV);

            DataColumn RAT_145_SERVICE_CD = new DataColumn();
            RAT_145_SERVICE_CD.DataType = System.Type.GetType("System.String");
            RAT_145_SERVICE_CD.ColumnName = "RAT_145_SERVICE_CD";
            tblU030_TAPE_145_FILE.Columns.Add(RAT_145_SERVICE_CD);

            DataColumn RAT_145_ELIGIBILITY_IND = new DataColumn();
            RAT_145_ELIGIBILITY_IND.DataType = System.Type.GetType("System.String");
            RAT_145_ELIGIBILITY_IND.ColumnName = "RAT_145_ELIGIBILITY_IND";
            tblU030_TAPE_145_FILE.Columns.Add(RAT_145_ELIGIBILITY_IND);

            DataColumn RAT_145_AMOUNT_SUB = new DataColumn();
            RAT_145_AMOUNT_SUB.DataType = System.Type.GetType("System.Int32");
            RAT_145_AMOUNT_SUB.ColumnName = "RAT_145_AMOUNT_SUB";
            tblU030_TAPE_145_FILE.Columns.Add(RAT_145_AMOUNT_SUB);

            DataColumn RAT_145_AMT_PAID = new DataColumn();
            RAT_145_AMT_PAID.DataType = System.Type.GetType("System.Int32");
            RAT_145_AMT_PAID.ColumnName = "RAT_145_AMT_PAID";
            tblU030_TAPE_145_FILE.Columns.Add(RAT_145_AMT_PAID);

            DataColumn RAT_145_EXPLAN_CD = new DataColumn();
            RAT_145_EXPLAN_CD.DataType = System.Type.GetType("System.String");
            RAT_145_EXPLAN_CD.ColumnName = "RAT_145_EXPLAN_CD";
            tblU030_TAPE_145_FILE.Columns.Add(RAT_145_EXPLAN_CD);

            return tblU030_TAPE_145_FILE;
        }

        #endregion
    }
}
