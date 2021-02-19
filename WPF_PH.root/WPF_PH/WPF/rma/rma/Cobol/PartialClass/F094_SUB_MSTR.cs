using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
using System.Text;

namespace RmaDAL
{
    public partial class F094_SUB_MSTR
    {
        public ObservableCollection<F094_SUB_MSTR> Collection_GetSubMessage(int rows = 3000)
        {

            StringBuilder sql = null;
            sql = new StringBuilder();

            sql.Append("SELECT TOP ").Append(rows)
               .Append("  ROWID as 'ROWID_HDR'")
               .Append(" ,[MSG_SUB_KEY_12]")
               .Append(" ,[MSG_SUB_KEY_3]")
               .Append(" ,[SUB_NAME]")
               .Append(" ,[SUB_FEE_COMPLEX]")
               .Append(" ,[SUB_AUTO_LOGOUT]")
               .Append(" ,[FILLER]")

               .Append(" FROM")
               .Append(" [INDEXED].F094_SUB_MSTR")
               .Append(" WHERE")
               .Append(" 1 = 1");

            sql.Append(" AND")
               .Append(" [MSG_SUB_KEY_12] + [MSG_SUB_KEY_3] = '").Append(WhereMsg_sub_key_12 + WhereMsg_sub_key_3).Append("'");

            Reader = CoreReader(sql.ToString());

            ObservableCollection<F094_SUB_MSTR> F094_SUB_MSTR_Collection = null;
            F094_SUB_MSTR_Collection = new ObservableCollection<F094_SUB_MSTR>();

            while (Reader.Read())
            {
                F094_SUB_MSTR objF094_SUB_MSTR = null;
                objF094_SUB_MSTR = new F094_SUB_MSTR
                {
                    ROWID = (Guid)Reader["ROWID_HDR"],
                    MSG_SUB_KEY_12 = Reader["MSG_SUB_KEY_12"].ToString(),
                    MSG_SUB_KEY_3 = Reader["MSG_SUB_KEY_3"].ToString(),
                    SUB_NAME = Reader["SUB_NAME"].ToString(),
                    SUB_FEE_COMPLEX = Reader["SUB_FEE_COMPLEX"].ToString(),
                    SUB_AUTO_LOGOUT = Reader["SUB_AUTO_LOGOUT"].ToString(),
                    FILLER = Reader["FILLER"].ToString(),
                   
                    _whereMsg_sub_key_12 = WhereMsg_sub_key_12,
                    _whereMsg_sub_key_3 = WhereMsg_sub_key_3,
                    _whereSub_name = WhereSub_name,
                    _whereSub_fee_complex = WhereSub_fee_complex,
                    _whereSub_auto_logout = WhereSub_auto_logout,
                    _whereFiller = WhereFiller,

                    RecordState = State.UnChanged
                };
                F094_SUB_MSTR_Collection.Add(objF094_SUB_MSTR);
            }

            CloseConnection();
            return F094_SUB_MSTR_Collection;
        }

        public ObservableCollection<F094_SUB_MSTR> Collection_GetSubMessages(int rows = 3000)
        {

            StringBuilder sql = null;
            sql = new StringBuilder();

            sql.Append("SELECT TOP ").Append(rows)
               .Append("  ROWID as 'ROWID_HDR'")
               .Append(" ,[MSG_SUB_KEY_12]")
               .Append(" ,[MSG_SUB_KEY_3]")
               .Append(" ,[SUB_NAME]")
               .Append(" ,[SUB_FEE_COMPLEX]")
               .Append(" ,[SUB_AUTO_LOGOUT]")
               .Append(" ,[FILLER]")

               .Append(" FROM")
               .Append(" [INDEXED].F094_SUB_MSTR")
               .Append(" WHERE")
               .Append(" 1 = 1");

            sql.Append(" AND")
               .Append(" [MSG_SUB_KEY_12] + [MSG_SUB_KEY_3] >= '").Append(WhereMsg_sub_key_12 + WhereMsg_sub_key_3).Append("'");

            Reader = CoreReader(sql.ToString());

            ObservableCollection<F094_SUB_MSTR> F094_SUB_MSTR_Collection = null;
            F094_SUB_MSTR_Collection = new ObservableCollection<F094_SUB_MSTR>();

            while (Reader.Read())
            {
                F094_SUB_MSTR objF094_SUB_MSTR = null;
                objF094_SUB_MSTR = new F094_SUB_MSTR
                {
                    ROWID = (Guid)Reader["ROWID_HDR"],
                    MSG_SUB_KEY_12 = Reader["MSG_SUB_KEY_12"].ToString(),
                    MSG_SUB_KEY_3 = Reader["MSG_SUB_KEY_3"].ToString(),
                    SUB_NAME = Reader["SUB_NAME"].ToString(),
                    SUB_FEE_COMPLEX = Reader["SUB_FEE_COMPLEX"].ToString(),
                    SUB_AUTO_LOGOUT = Reader["SUB_AUTO_LOGOUT"].ToString(),
                    FILLER = Reader["FILLER"].ToString(),

                    _whereMsg_sub_key_12 = WhereMsg_sub_key_12,
                    _whereMsg_sub_key_3 = WhereMsg_sub_key_3,
                    _whereSub_name = WhereSub_name,
                    _whereSub_fee_complex = WhereSub_fee_complex,
                    _whereSub_auto_logout = WhereSub_auto_logout,
                    _whereFiller = WhereFiller,

                    RecordState = State.UnChanged
                };
                F094_SUB_MSTR_Collection.Add(objF094_SUB_MSTR);
            }

            CloseConnection();
            return F094_SUB_MSTR_Collection;
        }
    }
}
