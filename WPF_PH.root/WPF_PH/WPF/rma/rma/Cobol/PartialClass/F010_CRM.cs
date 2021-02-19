using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
using System.Text;
using rma.Cobol;
using System.Diagnostics;

namespace RmaDAL
{
    public partial class F010_CRM:BaseTable
    {

        public ObservableCollection<F010_CRM> Collection_UsingStart(ref bool isRetreiveRecord, ObservableCollection<F010_CRM> f010_crm_Collection = null, int rows = 3000)
        {
            if (f010_crm_Collection != null)
            {
                F010_CRM objF010_CRM = f010_crm_Collection.FirstOrDefault();
                if (objF010_CRM != null)
                {
                    WhereKey_pat_mstr = objF010_CRM.KEY_PAT_MSTR;
                    WhereClmhdr_batch_nbr = objF010_CRM.CLMHDR_BATCH_NBR;
                    WhereClmhdr_claim_nbr = objF010_CRM.CLMHDR_CLAIM_NBR;
                    WhereGhost_date_descending = objF010_CRM.GHOST_DATE_DESCENDING;
                    WhereDate_assigned = objF010_CRM.DATE_ASSIGNED;
                    WhereTime_assigned = objF010_CRM.TIME_ASSIGNED;
                    WhereKey_dtl_seq_nbr = objF010_CRM.KEY_DTL_SEQ_NBR;

                    if (IsSameSearch())
                    {
                        isRetreiveRecord = false;
                        return f010_crm_Collection;
                    }
                }
            }

            var collection = new ObservableCollection<F010_CRM>();
            isRetreiveRecord = true;
            StringBuilder sql = null;
            sql = new StringBuilder();
            string criteria = string.Empty;

            sql.Append("SELECT TOP ").Append(rows)
                .Append(" BINARY_CHECKSUM(*) AS [ROWCHECKSUM]")
                .Append(" ,[ROWID]")
                .Append(" ,[KEY_PAT_MSTR]")
                .Append("  ,[CLMHDR_BATCH_NBR]")
                .Append("  ,[CLMHDR_CLAIM_NBR]")
                .Append(" ,[GHOST_DATE_DESCENDING]")
                .Append(" ,[DATE_ASSIGNED]")
                .Append(" ,[TIME_ASSIGNED]")
                .Append(" ,[KEY_DTL_SEQ_NBR]")
                .Append(" ,[ACTION_CODE]")
                .Append(" ,[FOLLOWUP_ACTION]")
                .Append(" ,[CHECKSUM_VALUE]")
               .Append(" FROM [INDEXED].[F010_CRM]")
                .Append(" WHERE ")
                .Append(" 1 = 1");

           if ( !string.IsNullOrWhiteSpace(WhereKey_pat_mstr ))
            {
                sql.Append(" AND  KEY_PAT_MSTR >= '").Append(WhereKey_pat_mstr).Append("'");
            }

           if (!string.IsNullOrWhiteSpace( WhereClmhdr_batch_nbr))
            {
                sql.Append(" AND CLMHDR_BATCH_NBR >= '").Append(WhereClmhdr_batch_nbr).Append("'");
            } 

            if (Util.NumInt(WhereClmhdr_claim_nbr) > 0 )
            {
                sql.Append(" AND CLMHDR_CLAIM_NBR >= ").Append(WhereClmhdr_claim_nbr);
            } 

           if (Util.NumInt( WhereGhost_date_descending) > 0)
            {
                sql.Append(" AND  GHOST_DATE_DESCENDING >=  ").Append(WhereGhost_date_descending);
            } 

            if (Util.NumInt(WhereDate_assigned) > 0 )
            {
                sql.Append(" AND  DATE_ASSIGNED >= ").Append(WhereDate_assigned);
            } 

            if (Util.NumInt(WhereTime_assigned) > 0 )
            {
                sql.Append(" AND TIME_ASSIGNED >=  ").Append(WhereTime_assigned);
            }

           if (Util.NumInt(WhereKey_dtl_seq_nbr) > 0 )
            {
                sql.Append(" AND KEY_DTL_SEQ_NBR >= ").Append(WhereKey_dtl_seq_nbr);
            }

            Reader = CoreReader(sql.ToString());

            while (Reader.Read())
            {
                collection.Add(new F010_CRM
                {
                    RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
                    ROWID = (Guid)Reader["ROWID"],
                    KEY_PAT_MSTR = Reader["KEY_PAT_MSTR"].ToString(),
                    CLMHDR_BATCH_NBR = Reader["CLMHDR_BATCH_NBR"].ToString(),
                    CLMHDR_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]),
                    GHOST_DATE_DESCENDING = ConvertDEC(Reader["GHOST_DATE_DESCENDING"]),
                    DATE_ASSIGNED = ConvertDEC(Reader["DATE_ASSIGNED"]),
                    TIME_ASSIGNED = ConvertDEC(Reader["TIME_ASSIGNED"]),
                    KEY_DTL_SEQ_NBR = ConvertDEC(Reader["KEY_DTL_SEQ_NBR"]),
                    ACTION_CODE = Reader["ACTION_CODE"].ToString(),
                    FOLLOWUP_ACTION = Reader["FOLLOWUP_ACTION"].ToString(),
                    CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    _whereRowid = WhereRowid,
                    _whereKey_pat_mstr = WhereKey_pat_mstr,
                    _whereClmhdr_batch_nbr = WhereClmhdr_batch_nbr,
                    _whereClmhdr_claim_nbr = WhereClmhdr_claim_nbr,
                    _whereGhost_date_descending = WhereGhost_date_descending,
                    _whereDate_assigned = WhereDate_assigned,
                    _whereTime_assigned = WhereTime_assigned,
                    _whereKey_dtl_seq_nbr = WhereKey_dtl_seq_nbr,
                    _whereAction_code = WhereAction_code,
                    _whereFollowup_action = WhereFollowup_action,
                    _whereChecksum_value = WhereChecksum_value,

                    _originalRowid = (Guid)Reader["ROWID"],
                    _originalKey_pat_mstr = Reader["KEY_PAT_MSTR"].ToString(),
                    _originalClmhdr_batch_nbr = Reader["CLMHDR_BATCH_NBR"].ToString(),
                    _originalClmhdr_claim_nbr = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]),
                    _originalGhost_date_descending = ConvertDEC(Reader["GHOST_DATE_DESCENDING"]),
                    _originalDate_assigned = ConvertDEC(Reader["DATE_ASSIGNED"]),
                    _originalTime_assigned = ConvertDEC(Reader["TIME_ASSIGNED"]),
                    _originalKey_dtl_seq_nbr = ConvertDEC(Reader["KEY_DTL_SEQ_NBR"]),
                    _originalAction_code = Reader["ACTION_CODE"].ToString(),
                    _originalFollowup_action = Reader["FOLLOWUP_ACTION"].ToString(),
                    _originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();

            return collection;

        }

    }
}
