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
    public partial class U030_TAPE_8_FILE
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
                        new SqlParameter("RAT_8_MESSAGE_TEXT", SqlNull(RAT_8_MESSAGE_TEXT)),
                        new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
                    };
                    if (Reader != null) Reader.Dispose();                    
                    Reader = CoreReader("[SEQUENTIAL].[sp_U030_TAPE_8_FILE_Insert]", parameters);                   
                    break;
                case State.Modified:
                    parameters = new SqlParameter[]
                    {
                        new SqlParameter("RowCheckSum",RowCheckSum),
                        new SqlParameter("ROWID", ROWID),
                        new SqlParameter("RAT_8_MESSAGE_TEXT", SqlNull(RAT_8_MESSAGE_TEXT)),
                        new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
                    };
                    if (Reader != null) Reader.Dispose();                    
                    Reader = CoreReader("[SEQUENTIAL].[sp_U030_TAPE_8_FILE_Update]", parameters);                   
                    break;
            }           

            RecordState = State.UnChanged;
        }

        #region bulkInsert
        public void BulkInsert(ObservableCollection<U030_TAPE_8_FILE> U030_TAPE_8_FILE_Collection)
        {
            using  (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                DataTable tblU030_TAPE_8_FILE = MakeTable();

                foreach(var obj in U030_TAPE_8_FILE_Collection)
                {
                    DataRow dr = tblU030_TAPE_8_FILE.NewRow();

                    dr["RAT_8_MESSAGE_TEXT"] = obj.RAT_8_MESSAGE_TEXT;
                    tblU030_TAPE_8_FILE.Rows.Add(dr);
                }

                using(SqlBulkCopy blk = new SqlBulkCopy(con))
                {
                    blk.DestinationTableName = "[SEQUENTIAL].[U030_TAPE_8_FILE]";
                    blk.ColumnMappings.Add("RAT_8_MESSAGE_TEXT", "RAT_8_MESSAGE_TEXT");
                    blk.WriteToServer(tblU030_TAPE_8_FILE);
                }
            }
        }
        private DataTable MakeTable()
        {
            DataTable tblU030_TAPE_8_FILE = new DataTable("U030_TAPE_8_FILE");

            DataColumn RAT_8_MESSAGE_TEXT = new DataColumn();
            RAT_8_MESSAGE_TEXT.DataType = System.Type.GetType("System.String");
            RAT_8_MESSAGE_TEXT.ColumnName = "RAT_8_MESSAGE_TEXT";
            tblU030_TAPE_8_FILE.Columns.Add(RAT_8_MESSAGE_TEXT);

            return tblU030_TAPE_8_FILE;
        }
        #endregion
    }
}
