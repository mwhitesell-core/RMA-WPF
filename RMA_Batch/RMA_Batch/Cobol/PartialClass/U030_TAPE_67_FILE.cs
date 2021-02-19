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
    public partial class U030_TAPE_67_FILE
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
                        new SqlParameter("RAT_67_AMT_CLAIMS_ADJ", SqlNull(RAT_67_AMT_CLAIMS_ADJ)),
                        new SqlParameter("RAT_67_AMT_ADVANCES", SqlNull(RAT_67_AMT_ADVANCES)),
                        new SqlParameter("RAT_67_AMT_REDUCTIONS", SqlNull(RAT_67_AMT_REDUCTIONS)),
                        new SqlParameter("RAT_67_AMT_DEDUCTIONS", SqlNull(RAT_67_AMT_DEDUCTIONS)),
                        new SqlParameter("RAT_67_TRANS_CD", SqlNull(RAT_67_TRANS_CD)),
                        new SqlParameter("RAT_67_CHEQUE_IND", SqlNull(RAT_67_CHEQUE_IND)),
                        new SqlParameter("RAT_67_TRANS_DATE", SqlNull(RAT_67_TRANS_DATE)),
                        new SqlParameter("RAT_67_TRANS_AMT", SqlNull(RAT_67_TRANS_AMT)),
                        new SqlParameter("RAT_67_TRANS_MESSAGE", SqlNull(RAT_67_TRANS_MESSAGE)),
                        new SqlParameter("RAT_67_TOTAL_CLINIC_AMT", SqlNull(RAT_67_TOTAL_CLINIC_AMT)),
                        new SqlParameter("RAT_67_AMT_BILL", SqlNull(RAT_67_AMT_BILL)),
                        new SqlParameter("RAT_67_AMT_PAID", SqlNull(RAT_67_AMT_PAID)),
                        new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
                    };
                    if (Reader != null) Reader.Dispose();                    
                    Reader = CoreReader("[SEQUENTIAL].[sp_U030_TAPE_67_FILE_Insert]", parameters);                   
                    break;
                case State.Modified:
                    parameters = new SqlParameter[]
                    {
                        new SqlParameter("RowCheckSum",RowCheckSum),
                        new SqlParameter("ROWID", ROWID),
                        new SqlParameter("RAT_67_AMT_CLAIMS_ADJ", SqlNull(RAT_67_AMT_CLAIMS_ADJ)),
                        new SqlParameter("RAT_67_AMT_ADVANCES", SqlNull(RAT_67_AMT_ADVANCES)),
                        new SqlParameter("RAT_67_AMT_REDUCTIONS", SqlNull(RAT_67_AMT_REDUCTIONS)),
                        new SqlParameter("RAT_67_AMT_DEDUCTIONS", SqlNull(RAT_67_AMT_DEDUCTIONS)),
                        new SqlParameter("RAT_67_TRANS_CD", SqlNull(RAT_67_TRANS_CD)),
                        new SqlParameter("RAT_67_CHEQUE_IND", SqlNull(RAT_67_CHEQUE_IND)),
                        new SqlParameter("RAT_67_TRANS_DATE", SqlNull(RAT_67_TRANS_DATE)),
                        new SqlParameter("RAT_67_TRANS_AMT", SqlNull(RAT_67_TRANS_AMT)),
                        new SqlParameter("RAT_67_TRANS_MESSAGE", SqlNull(RAT_67_TRANS_MESSAGE)),
                        new SqlParameter("RAT_67_TOTAL_CLINIC_AMT", SqlNull(RAT_67_TOTAL_CLINIC_AMT)),
                        new SqlParameter("RAT_67_AMT_BILL", SqlNull(RAT_67_AMT_BILL)),
                        new SqlParameter("RAT_67_AMT_PAID", SqlNull(RAT_67_AMT_PAID)),
                        new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
                    };
                    if (Reader != null) Reader.Dispose();                    
                    Reader = CoreReader("[SEQUENTIAL].[sp_U030_TAPE_67_FILE_Update]", parameters);                   
                    break;
            }            

            RecordState = State.UnChanged;
        }

        #region bulkInsert
        public void BulkInset(ObservableCollection<U030_TAPE_67_FILE> U030_TAPE_67_FILE_Collection)
        {

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                DataTable tblU030_TAPE_67_FILE = MakeTable();

                foreach (var obj in U030_TAPE_67_FILE_Collection)
                {
                    DataRow dr = tblU030_TAPE_67_FILE.NewRow();
                    
                    dr["RAT_67_AMT_CLAIMS_ADJ"] = Util.NumInt(obj.RAT_67_AMT_CLAIMS_ADJ);
                    dr["RAT_67_AMT_ADVANCES"] = Util.NumInt(obj.RAT_67_AMT_ADVANCES);                    
                    dr["RAT_67_AMT_REDUCTIONS"] = Util.NumInt(obj.RAT_67_AMT_REDUCTIONS);                    
                    dr["RAT_67_AMT_DEDUCTIONS"] = Util.NumInt(obj.RAT_67_AMT_DEDUCTIONS);                    
                    dr["RAT_67_TRANS_CD"] = obj.RAT_67_TRANS_CD;                    
                    dr["RAT_67_CHEQUE_IND"] = obj.RAT_67_CHEQUE_IND;                    
                    dr["RAT_67_TRANS_DATE"] = Util.NumInt(obj.RAT_67_TRANS_DATE);                    
                    dr["RAT_67_TRANS_AMT"] = Util.NumInt(obj.RAT_67_TRANS_AMT);                    
                    dr["RAT_67_TRANS_MESSAGE"] = obj.RAT_67_TRANS_MESSAGE;                    
                    dr["RAT_67_TOTAL_CLINIC_AMT"] = Util.NumInt(obj.RAT_67_TOTAL_CLINIC_AMT);                    
                    dr["RAT_67_AMT_BILL"] = Util.NumInt(obj.RAT_67_AMT_BILL);                    
                    dr["RAT_67_AMT_PAID"] = Util.NumInt(obj.RAT_67_AMT_PAID);

                    tblU030_TAPE_67_FILE.Rows.Add(dr);
                }

                using (SqlBulkCopy blk = new SqlBulkCopy(con) )
                {
                    blk.DestinationTableName = "SEQUENTIAL.U030_TAPE_67_FILE";
                    blk.ColumnMappings.Add("RAT_67_AMT_CLAIMS_ADJ", "RAT_67_AMT_CLAIMS_ADJ");
                    blk.ColumnMappings.Add("RAT_67_AMT_ADVANCES", "RAT_67_AMT_ADVANCES");
                    blk.ColumnMappings.Add("RAT_67_AMT_REDUCTIONS", "RAT_67_AMT_REDUCTIONS");
                    blk.ColumnMappings.Add("RAT_67_AMT_DEDUCTIONS", "RAT_67_AMT_DEDUCTIONS");
                    blk.ColumnMappings.Add("RAT_67_TRANS_CD", "RAT_67_TRANS_CD");
                    blk.ColumnMappings.Add("RAT_67_CHEQUE_IND", "RAT_67_CHEQUE_IND");
                    blk.ColumnMappings.Add("RAT_67_TRANS_DATE", "RAT_67_TRANS_DATE");
                    blk.ColumnMappings.Add("RAT_67_TRANS_AMT", "RAT_67_TRANS_AMT");
                    blk.ColumnMappings.Add("RAT_67_TRANS_MESSAGE", "RAT_67_TRANS_MESSAGE");
                    blk.ColumnMappings.Add("RAT_67_TOTAL_CLINIC_AMT", "RAT_67_TOTAL_CLINIC_AMT");
                    blk.ColumnMappings.Add("RAT_67_AMT_BILL", "RAT_67_AMT_BILL");
                    blk.ColumnMappings.Add("RAT_67_AMT_PAID", "RAT_67_AMT_PAID");                    
                    blk.WriteToServer(tblU030_TAPE_67_FILE);
                }
            }
        }
        private DataTable MakeTable()
        {
            DataTable tblU030_TAPE_67_FILE = new DataTable("U030_TAPE_67_FILE");
            
            DataColumn RAT_67_AMT_CLAIMS_ADJ = new DataColumn();
            RAT_67_AMT_CLAIMS_ADJ.DataType = System.Type.GetType("System.Int32");
            RAT_67_AMT_CLAIMS_ADJ.ColumnName = "RAT_67_AMT_CLAIMS_ADJ";
            tblU030_TAPE_67_FILE.Columns.Add(RAT_67_AMT_CLAIMS_ADJ);

            DataColumn RAT_67_AMT_ADVANCES = new DataColumn();
            RAT_67_AMT_ADVANCES.DataType = System.Type.GetType("System.Int32");
            RAT_67_AMT_ADVANCES.ColumnName = "RAT_67_AMT_ADVANCES";
            tblU030_TAPE_67_FILE.Columns.Add(RAT_67_AMT_ADVANCES);

            DataColumn RAT_67_AMT_REDUCTIONS = new DataColumn();
            RAT_67_AMT_REDUCTIONS.DataType = System.Type.GetType("System.Int32");
            RAT_67_AMT_REDUCTIONS.ColumnName = "RAT_67_AMT_REDUCTIONS";
            tblU030_TAPE_67_FILE.Columns.Add(RAT_67_AMT_REDUCTIONS);

            DataColumn RAT_67_AMT_DEDUCTIONS = new DataColumn();
            RAT_67_AMT_DEDUCTIONS.DataType = System.Type.GetType("System.Int32");
            RAT_67_AMT_DEDUCTIONS.ColumnName = "RAT_67_AMT_DEDUCTIONS";
            tblU030_TAPE_67_FILE.Columns.Add(RAT_67_AMT_DEDUCTIONS);

            DataColumn RAT_67_TRANS_CD = new DataColumn();
            RAT_67_TRANS_CD.DataType = System.Type.GetType("System.String");
            RAT_67_TRANS_CD.ColumnName = "RAT_67_TRANS_CD";
            tblU030_TAPE_67_FILE.Columns.Add(RAT_67_TRANS_CD);

            DataColumn RAT_67_CHEQUE_IND = new DataColumn();
            RAT_67_CHEQUE_IND.DataType = System.Type.GetType("System.String");
            RAT_67_CHEQUE_IND.ColumnName = "RAT_67_CHEQUE_IND";
            tblU030_TAPE_67_FILE.Columns.Add(RAT_67_CHEQUE_IND);

            DataColumn RAT_67_TRANS_DATE = new DataColumn();
            RAT_67_TRANS_DATE.DataType = System.Type.GetType("System.Int32");
            RAT_67_TRANS_DATE.ColumnName = "RAT_67_TRANS_DATE";
            tblU030_TAPE_67_FILE.Columns.Add(RAT_67_TRANS_DATE);

            DataColumn RAT_67_TRANS_AMT = new DataColumn();
            RAT_67_TRANS_AMT.DataType = System.Type.GetType("System.Int32");
            RAT_67_TRANS_AMT.ColumnName = "RAT_67_TRANS_AMT";
            tblU030_TAPE_67_FILE.Columns.Add(RAT_67_TRANS_AMT);

            DataColumn RAT_67_TRANS_MESSAGE = new DataColumn();
            RAT_67_TRANS_MESSAGE.DataType = System.Type.GetType("System.String");
            RAT_67_TRANS_MESSAGE.ColumnName = "RAT_67_TRANS_MESSAGE";
            tblU030_TAPE_67_FILE.Columns.Add(RAT_67_TRANS_MESSAGE);

            DataColumn RAT_67_TOTAL_CLINIC_AMT = new DataColumn();
            RAT_67_TOTAL_CLINIC_AMT.DataType = System.Type.GetType("System.Int32");
            RAT_67_TOTAL_CLINIC_AMT.ColumnName = "RAT_67_TOTAL_CLINIC_AMT";
            tblU030_TAPE_67_FILE.Columns.Add(RAT_67_TOTAL_CLINIC_AMT);

            DataColumn RAT_67_AMT_BILL = new DataColumn();
            RAT_67_AMT_BILL.DataType = System.Type.GetType("System.Int32");
            RAT_67_AMT_BILL.ColumnName = "RAT_67_AMT_BILL";
            tblU030_TAPE_67_FILE.Columns.Add(RAT_67_AMT_BILL);

            DataColumn RAT_67_AMT_PAID = new DataColumn();
            RAT_67_AMT_PAID.DataType = System.Type.GetType("System.Int32");
            RAT_67_AMT_PAID.ColumnName = "RAT_67_AMT_PAID";
            tblU030_TAPE_67_FILE.Columns.Add(RAT_67_AMT_PAID);

            return tblU030_TAPE_67_FILE;
        }
        #endregion
    }
}
