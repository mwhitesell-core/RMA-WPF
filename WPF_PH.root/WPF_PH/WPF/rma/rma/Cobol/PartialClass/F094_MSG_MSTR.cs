using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
using System.Text;

namespace RmaDAL
{
    public partial class F094_MSG_MSTR
    {
        public ObservableCollection<F094_MSG_MSTR> Collection_GetMessages(int rows = 3000)
        {

            StringBuilder sql = null;
            sql = new StringBuilder();

            sql.Append("SELECT TOP ").Append(rows)
               .Append("  ROWID as 'ROWID_HDR'")
               .Append(" ,[MSG_SUB_KEY_1]")
               .Append(" ,[MSG_SUB_KEY_23]")
               .Append(" ,[MSG_REPRINT_FLAG]")
               .Append(" ,[MSG_AUTO_LOGOUT]")
               .Append(" ,[MSG_DTL1]")
               .Append(" ,[MSG_DTL2]")
               .Append(" ,[MSG_DTL3]")
               .Append(" ,[MSG_DTL4]")

               .Append(" FROM")
               .Append(" [INDEXED].F094_MSG_MSTR")
               .Append(" WHERE")
               .Append(" 1 = 1");

            sql.Append(" AND")
               .Append(" [MSG_SUB_KEY_1] = '").Append(WhereMsg_sub_key_1).Append("'");

            sql.Append(" AND")
               .Append(" [MSG_SUB_KEY_23] >= '").Append(WhereMsg_sub_key_23).Append("'");

            Reader = CoreReader(sql.ToString());

            ObservableCollection<F094_MSG_MSTR> F094_MSG_MSTR_Collection = null;
            F094_MSG_MSTR_Collection = new ObservableCollection<F094_MSG_MSTR>();

            while (Reader.Read())
            {
                F094_MSG_MSTR objF094_MSG_MSTR = null;
                objF094_MSG_MSTR = new F094_MSG_MSTR
                {
                    ROWID = (Guid)Reader["ROWID_HDR"],
                    MSG_SUB_KEY_1 = Reader["MSG_SUB_KEY_1"].ToString(),
                    MSG_SUB_KEY_23 = Reader["MSG_SUB_KEY_23"].ToString(),
                    MSG_REPRINT_FLAG = Reader["MSG_REPRINT_FLAG"].ToString(),
                    MSG_AUTO_LOGOUT = Reader["MSG_AUTO_LOGOUT"].ToString(),
                    MSG_DTL1 = Reader["MSG_DTL1"].ToString(),
                    MSG_DTL2 = Reader["MSG_DTL2"].ToString(),
                    MSG_DTL3 = Reader["MSG_DTL3"].ToString(),
                    MSG_DTL4 = Reader["MSG_DTL4"].ToString(),
                   
                    _whereMsg_sub_key_1 = WhereMsg_sub_key_1,
                    _whereMsg_sub_key_23 = WhereMsg_sub_key_23,
                    _whereMsg_reprint_flag = WhereMsg_reprint_flag,
                    _whereMsg_auto_logout = WhereMsg_auto_logout,
                    _whereMsg_dtl1 = WhereMsg_dtl1,
                    _whereMsg_dtl2 = WhereMsg_dtl2,
                    _whereMsg_dtl3 = WhereMsg_dtl3,
                    _whereMsg_dtl4 = WhereMsg_dtl4,

                    RecordState = State.UnChanged
                };
                F094_MSG_MSTR_Collection.Add(objF094_MSG_MSTR);
            }

            CloseConnection();
            return F094_MSG_MSTR_Collection;
        }

        //public ObservableCollection<F094_MSG_MSTR> Collection_GetMessage(int rows = 3000)
        //{

        //    StringBuilder sql = null;
        //    sql = new StringBuilder();

        //    sql.Append("SELECT TOP ").Append(rows)
        //       .Append("  ROWID as 'ROWID_HDR'")
        //       .Append(" ,[MSG_SUB_KEY_1]")
        //       .Append(" ,[MSG_SUB_KEY_23]")
        //       .Append(" ,[MSG_REPRINT_FLAG]")
        //       .Append(" ,[MSG_AUTO_LOGOUT]")
        //       .Append(" ,[MSG_DTL1]")
        //       .Append(" ,[MSG_DTL2]")
        //       .Append(" ,[MSG_DTL3]")
        //       .Append(" ,[MSG_DTL4]")

        //       .Append(" FROM")
        //       .Append(" [INDEXED].F094_MSG_MSTR")
        //       .Append(" WHERE")
        //       .Append(" 1 = 1");

        //    sql.Append(" AND")
        //       .Append(" [MSG_SUB_KEY_1] = '").Append(WhereMsg_sub_key_1).Append("'");

        //    sql.Append(" AND")
        //       .Append(" [MSG_SUB_KEY_23] = '").Append(WhereMsg_sub_key_23).Append("'");

        //    Reader = CoreReader(sql.ToString());

        //    ObservableCollection<F094_MSG_MSTR> F094_MSG_MSTR_Collection = null;
        //    F094_MSG_MSTR_Collection = new ObservableCollection<F094_MSG_MSTR>();

        //    while (Reader.Read())
        //    {
        //        F094_MSG_MSTR objF094_MSG_MSTR = null;
        //        objF094_MSG_MSTR = new F094_MSG_MSTR
        //        {
        //            ROWID = (Guid)Reader["ROWID_HDR"],
        //            MSG_SUB_KEY_1 = Reader["MSG_SUB_KEY_1"].ToString(),
        //            MSG_SUB_KEY_23 = Reader["MSG_SUB_KEY_23"].ToString(),
        //            MSG_REPRINT_FLAG = Reader["MSG_REPRINT_FLAG"].ToString(),
        //            MSG_AUTO_LOGOUT = Reader["MSG_AUTO_LOGOUT"].ToString(),
        //            MSG_DTL1 = Reader["MSG_DTL1"].ToString(),
        //            MSG_DTL2 = Reader["MSG_DTL2"].ToString(),
        //            MSG_DTL3 = Reader["MSG_DTL3"].ToString(),
        //            MSG_DTL4 = Reader["MSG_DTL4"].ToString(),

        //            _whereMsg_sub_key_1 = WhereMsg_sub_key_1,
        //            _whereMsg_sub_key_23 = WhereMsg_sub_key_23,
        //            _whereMsg_reprint_flag = WhereMsg_reprint_flag,
        //            _whereMsg_auto_logout = WhereMsg_auto_logout,
        //            _whereMsg_dtl1 = WhereMsg_dtl1,
        //            _whereMsg_dtl2 = WhereMsg_dtl2,
        //            _whereMsg_dtl3 = WhereMsg_dtl3,
        //            _whereMsg_dtl4 = WhereMsg_dtl4,

        //            RecordState = State.UnChanged
        //        };
        //        F094_MSG_MSTR_Collection.Add(objF094_MSG_MSTR);
        //    }

        //    CloseConnection();
        //    return F094_MSG_MSTR_Collection;
        //}
    }
}
