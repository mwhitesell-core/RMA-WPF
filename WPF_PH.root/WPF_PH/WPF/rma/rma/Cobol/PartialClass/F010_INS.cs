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
    public partial class F010_INS
    {

        public ObservableCollection<F010_INS> Collection_UsingStart(ref bool isRetreiveRecord, ObservableCollection<F010_INS> f010_ins_Collection = null, int rows = 3000)
        {

            if (f010_ins_Collection != null)
            {
                F010_INS objF010_INS = f010_ins_Collection.FirstOrDefault();
                if (objF010_INS != null)
                {
                    WhereKey_pat_mstr = objF010_INS.KEY_PAT_MSTR;
                    WhereClmhdr_batch_nbr = objF010_INS.CLMHDR_BATCH_NBR;
                    WhereClmhdr_claim_nbr = objF010_INS.CLMHDR_CLAIM_NBR;
                    WhereIns_acronym = objF010_INS.INS_ACRONYM;

                    if (IsSameSearch())
                    {
                        isRetreiveRecord = false;
                        return f010_ins_Collection;
                    }
                }
            }

            var collection = new ObservableCollection<F010_INS>();
            isRetreiveRecord = true;
            StringBuilder sql = null;
            sql = new StringBuilder();
            string criteria = string.Empty;

            sql.Append("SELECT TOP ").Append(rows)
                .Append(" BINARY_CHECKSUM(*) AS [ROWCHECKSUM]")
                .Append(" ,[ROWID]")
                .Append(" ,[KEY_PAT_MSTR]")
                .Append(" ,[CLMHDR_BATCH_NBR]")
                .Append(" ,[CLMHDR_CLAIM_NBR]")
                .Append(" ,[INS_ACRONYM]")
                .Append(" ,[PRIORITY_SEQ]")
                .Append(" ,[PERCENTAGE_TO_PAY]")
                .Append(" ,[POLICY_NBR]")
                .Append(" ,[CHECKSUM_VALUE]")
                .Append(" FROM [INDEXED].[F010_INS]")
                .Append(" WHERE ")
                .Append(" 1= 1");

            if (!string.IsNullOrWhiteSpace(WhereKey_pat_mstr))
            {
                sql.Append(" AND  KEY_PAT_MSTR >= '").Append(WhereKey_pat_mstr).Append("'");
            }
                  
            if (!string.IsNullOrWhiteSpace(WhereClmhdr_batch_nbr))
            {
                sql.Append(" AND CLMHDR_BATCH_NBR >= '").Append(WhereClmhdr_batch_nbr).Append("'");
            }

            if (Util.NumInt(WhereClmhdr_claim_nbr) > 0 )
            {
                sql.Append(" AND CLMHDR_CLAIM_NBR >= ").Append(WhereClmhdr_claim_nbr);
            }

            if (!string.IsNullOrWhiteSpace(WhereIns_acronym ))
            {
                sql.Append(" AND  INS_ACRONYM >= '").Append(WhereIns_acronym).Append("'");
            }

            Reader = CoreReader(sql.ToString());

            while (Reader.Read())
            {
                collection.Add(new F010_INS
                {
                    RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
                    ROWID = (Guid)Reader["ROWID"],
                    KEY_PAT_MSTR = Reader["KEY_PAT_MSTR"].ToString(),
                    CLMHDR_BATCH_NBR = Reader["CLMHDR_BATCH_NBR"].ToString(),
                    CLMHDR_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]),
                    INS_ACRONYM = Reader["INS_ACRONYM"].ToString(),
                    PRIORITY_SEQ = ConvertDEC(Reader["PRIORITY_SEQ"]),
                    PERCENTAGE_TO_PAY = ConvertDEC(Reader["PERCENTAGE_TO_PAY"]),
                    POLICY_NBR = Reader["POLICY_NBR"].ToString(),
                    CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    _whereRowid = WhereRowid,
                    _whereKey_pat_mstr = WhereKey_pat_mstr,
                    _whereClmhdr_batch_nbr = WhereClmhdr_batch_nbr,
                    _whereClmhdr_claim_nbr = WhereClmhdr_claim_nbr,
                    _whereIns_acronym = WhereIns_acronym,
                    _wherePriority_seq = WherePriority_seq,
                    _wherePercentage_to_pay = WherePercentage_to_pay,
                    _wherePolicy_nbr = WherePolicy_nbr,
                    _whereChecksum_value = WhereChecksum_value,

                    _originalRowid = (Guid)Reader["ROWID"],
                    _originalKey_pat_mstr = Reader["KEY_PAT_MSTR"].ToString(),
                    _originalClmhdr_batch_nbr = Reader["CLMHDR_BATCH_NBR"].ToString(),
                    _originalClmhdr_claim_nbr = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]),
                    _originalIns_acronym = Reader["INS_ACRONYM"].ToString(),
                    _originalPriority_seq = ConvertDEC(Reader["PRIORITY_SEQ"]),
                    _originalPercentage_to_pay = ConvertDEC(Reader["PERCENTAGE_TO_PAY"]),
                    _originalPolicy_nbr = Reader["POLICY_NBR"].ToString(),
                    _originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            _whereRowid = WhereRowid;
            _whereKey_pat_mstr = WhereKey_pat_mstr;
            _whereClmhdr_batch_nbr = WhereClmhdr_batch_nbr;
            _whereClmhdr_claim_nbr = WhereClmhdr_claim_nbr;
            _whereIns_acronym = WhereIns_acronym;
            _wherePriority_seq = WherePriority_seq;
            _wherePercentage_to_pay = WherePercentage_to_pay;
            _wherePolicy_nbr = WherePolicy_nbr;
            _whereChecksum_value = WhereChecksum_value;
            
            CloseConnection();
            return collection;
        }
    }
}
