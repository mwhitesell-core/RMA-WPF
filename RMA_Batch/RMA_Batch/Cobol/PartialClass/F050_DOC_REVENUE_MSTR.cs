using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;

namespace RmaDAL
{
    public partial class F050_DOC_REVENUE_MSTR
    {
        public ObservableCollection<F050_DOC_REVENUE_MSTR> Collection_UsingStart(ref bool isRetrieveRecord, ObservableCollection<F050_DOC_REVENUE_MSTR> f050DocRevenueMstr = null)
        {
            if (f050DocRevenueMstr != null)
            {
                F050_DOC_REVENUE_MSTR objf050DocRevenueMstr = f050DocRevenueMstr.FirstOrDefault();
                if (objf050DocRevenueMstr != null)
                {
                    _whereDocrev_clinic_1_2 = objf050DocRevenueMstr._whereDocrev_clinic_1_2;
                    _whereDocrev_dept = objf050DocRevenueMstr._whereDocrev_dept;
                    _whereDocrev_doc_nbr = objf050DocRevenueMstr._whereDocrev_doc_nbr;
                    _whereDocrev_location = objf050DocRevenueMstr._whereDocrev_location;
                    _whereDocrev_oma_code = objf050DocRevenueMstr._whereDocrev_oma_code;
                    _whereDocrev_oma_suff = objf050DocRevenueMstr._whereDocrev_oma_suff;

                    if (IsSameSearch())
                    {
                        isRetrieveRecord = false;
                        return f050DocRevenueMstr;
                    }
                }
            }

            var collection = new ObservableCollection<F050_DOC_REVENUE_MSTR>();
            isRetrieveRecord = true;
            StringBuilder sql = null;
            sql = new StringBuilder();
            string criteria = string.Empty;

            sql.Append("SELECT")
                .Append(" BINARY_CHECKSUM(*) AS [ROWCHECKSUM],")
                .Append(" ROWID,")
                .Append(" [DOCREV_CLINIC_1_2],")
                .Append(" [DOCREV_DEPT],")
                .Append(" [DOCREV_DOC_NBR],")
                .Append(" [DOCREV_LOCATION],")
                .Append(" [DOCREV_OMA_CODE],")
                .Append(" [DOCREV_OMA_SUFF],")
                .Append(" [DOCREV_MTD_IN_REC],")
                .Append(" [DOCREV_MTD_IN_SVC],")
                .Append(" [DOCREV_MTD_OUT_REC],")
                .Append(" [DOCREV_MTD_OUT_SVC],")
                .Append(" [DOCREV_YTD_IN_REC],")
                .Append(" [DOCREV_YTD_IN_SVC],")
                .Append(" [DOCREV_YTD_OUT_REC],")
                .Append(" [DOCREV_YTD_OUT_SVC]")
                .Append(" FROM")
                .Append(" [INDEXED].[F050_DOC_REVENUE_MSTR]  WITH (NOLOCK) ")
                .Append(" WHERE")
                .Append(" [DOCREV_CLINIC_1_2] >= ").Append(WhereDocrev_clinic_1_2);
            criteria = sql.ToString();

            if (!string.IsNullOrWhiteSpace(WhereDocrev_dept.ToString()) || WhereDocrev_dept > 0)
            {
                criteria += " AND";
                criteria += " [DOCREV_DEPT] >= " + WhereDocrev_dept;
            }
            if (!string.IsNullOrWhiteSpace(WhereDocrev_doc_nbr))
            {
                criteria += " AND";
                criteria += " [DOCREV_DOC_NBR] >= " + "'" + WhereDocrev_doc_nbr + "'";
            }
            if (!string.IsNullOrWhiteSpace(WhereDocrev_location))
            {
                criteria += " AND";
                criteria += " [DOCREV_LOCATION] >=" + "'" + WhereDocrev_location + "'";
            }
            if (!string.IsNullOrWhiteSpace(WhereDocrev_oma_code))
            {
                criteria += " AND";
                criteria += " [DOCREV_OMA_CODE] >= " + "'" + WhereDocrev_oma_code + "'";
            }

            if (!string.IsNullOrWhiteSpace(WhereDocrev_oma_suff))
            {
                criteria += " AND";
                criteria += " [DOCREV_OMA_SUFF] >= " + "'" + WhereDocrev_oma_suff + "'";
            }

            criteria += " ORDER BY [DOCREV_CLINIC_1_2],[DOCREV_DEPT],[DOCREV_DOC_NBR],[DOCREV_LOCATION],[DOCREV_OMA_CODE],[DOCREV_OMA_SUFF] ";

            Reader = CoreReader(criteria);

            while (Reader.Read())
            {
                collection.Add(new F050_DOC_REVENUE_MSTR
                {
                    RowCheckSum = Convert.ToInt32(Reader["ROWCHECKSUM"]),
                    ROWID = (Guid)Reader["ROWID"],
                    DOCREV_CLINIC_1_2 = Reader["DOCREV_CLINIC_1_2"].ToString(),
                    DOCREV_DEPT = ConvertDEC(Reader["DOCREV_DEPT"]),
                    DOCREV_DOC_NBR = Reader["DOCREV_DOC_NBR"].ToString(),
                    DOCREV_LOCATION = Reader["DOCREV_LOCATION"].ToString(),
                    DOCREV_OMA_CODE = Reader["DOCREV_OMA_CODE"].ToString(),
                    DOCREV_OMA_SUFF = Reader["DOCREV_OMA_SUFF"].ToString(),
                    DOCREV_MTD_IN_REC = ConvertDEC(Reader["DOCREV_MTD_IN_REC"]),
                    DOCREV_MTD_IN_SVC = ConvertDEC(Reader["DOCREV_MTD_IN_SVC"]),
                    DOCREV_MTD_OUT_REC = ConvertDEC(Reader["DOCREV_MTD_OUT_REC"]),
                    DOCREV_MTD_OUT_SVC = ConvertDEC(Reader["DOCREV_MTD_OUT_SVC"]),
                    DOCREV_YTD_IN_REC = ConvertDEC(Reader["DOCREV_YTD_IN_REC"]),
                    DOCREV_YTD_IN_SVC = ConvertDEC(Reader["DOCREV_YTD_IN_SVC"]),
                    DOCREV_YTD_OUT_REC = ConvertDEC(Reader["DOCREV_YTD_OUT_REC"]),
                    DOCREV_YTD_OUT_SVC = ConvertDEC(Reader["DOCREV_YTD_OUT_SVC"]),

                    _whereRowid = WhereRowid,
                    _whereDocrev_clinic_1_2 = WhereDocrev_clinic_1_2,
                    _whereDocrev_dept = WhereDocrev_dept,
                    _whereDocrev_doc_nbr = WhereDocrev_doc_nbr,
                    _whereDocrev_location = WhereDocrev_location,
                    _whereDocrev_oma_code = WhereDocrev_oma_code,
                    _whereDocrev_oma_suff = WhereDocrev_oma_suff,
                    _whereDocrev_mtd_in_rec = WhereDocrev_mtd_in_rec,
                    _whereDocrev_mtd_in_svc = WhereDocrev_mtd_in_svc,
                    _whereDocrev_mtd_out_rec = WhereDocrev_mtd_out_rec,
                    _whereDocrev_mtd_out_svc = WhereDocrev_mtd_out_svc,
                    _whereDocrev_ytd_in_rec = WhereDocrev_ytd_in_rec,
                    _whereDocrev_ytd_in_svc = WhereDocrev_ytd_in_svc,
                    _whereDocrev_ytd_out_rec = WhereDocrev_ytd_out_rec,
                    _whereDocrev_ytd_out_svc = WhereDocrev_ytd_out_svc,

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();

            return collection;
        }

        public ObservableCollection<F050_DOC_REVENUE_MSTR> Collection_UsingTop(int rows = 3000, bool isClosedConnection = true, SqlConnection objConn = null)
        {
            

            var collection = new ObservableCollection<F050_DOC_REVENUE_MSTR>();            
            StringBuilder sql = null;
            sql = new StringBuilder();
            string criteria = string.Empty;

            sql.Append("SELECT TOP ").Append(rows)
                .Append(" BINARY_CHECKSUM(*) AS [ROWCHECKSUM],")
                .Append(" ROWID,")
                .Append(" [DOCREV_CLINIC_1_2],")
                .Append(" [DOCREV_DEPT],")
                .Append(" [DOCREV_DOC_NBR],")
                .Append(" [DOCREV_LOCATION],")
                .Append(" [DOCREV_OMA_CODE],")
                .Append(" [DOCREV_OMA_SUFF],")
                .Append(" [DOCREV_MTD_IN_REC],")
                .Append(" [DOCREV_MTD_IN_SVC],")
                .Append(" [DOCREV_MTD_OUT_REC],")
                .Append(" [DOCREV_MTD_OUT_SVC],")
                .Append(" [DOCREV_YTD_IN_REC],")
                .Append(" [DOCREV_YTD_IN_SVC],")
                .Append(" [DOCREV_YTD_OUT_REC],")
                .Append(" [DOCREV_YTD_OUT_SVC]")
                .Append(" FROM")
                .Append(" [INDEXED].[F050_DOC_REVENUE_MSTR]  WITH (NOLOCK) ")
                .Append(" WHERE")
                .Append(" 1 = 1");                
            criteria = sql.ToString();

            if (!string.IsNullOrWhiteSpace(WhereDocrev_clinic_1_2)) {
                criteria += " AND";
                criteria += " [DOCREV_CLINIC_1_2] >= " + "'" + WhereDocrev_clinic_1_2 + "'";
            }

            if (!string.IsNullOrWhiteSpace(WhereDocrev_dept.ToString()) || WhereDocrev_dept > 0)
            {
                criteria += " AND";
                criteria += " [DOCREV_DEPT] >= " + WhereDocrev_dept;
            }
            if (!string.IsNullOrWhiteSpace(WhereDocrev_doc_nbr))
            {
                criteria += " AND";
                criteria += " [DOCREV_DOC_NBR] >= " + "'" + WhereDocrev_doc_nbr + "'";
            }
            if (!string.IsNullOrWhiteSpace(WhereDocrev_location))
            {
                criteria += " AND";
                criteria += " [DOCREV_LOCATION] >=" + "'" + WhereDocrev_location + "'";
            }
            if (!string.IsNullOrWhiteSpace(WhereDocrev_oma_code))
            {
                criteria += " AND";
                criteria += " [DOCREV_OMA_CODE] >= " + "'" + WhereDocrev_oma_code + "'";
            }

            if (!string.IsNullOrWhiteSpace(WhereDocrev_oma_suff))
            {
                criteria += " AND";
                criteria += " [DOCREV_OMA_SUFF] >= " + "'" + WhereDocrev_oma_suff + "'";
            }

            criteria += " ORDER BY [DOCREV_CLINIC_1_2],[DOCREV_DEPT],[DOCREV_DOC_NBR],[DOCREV_LOCATION],[DOCREV_OMA_CODE],[DOCREV_OMA_SUFF] ";


           // Debug.WriteLine(criteria);

            if (!isClosedConnection)
            {
                Reader = CoreReader(criteria,objConn);
            }
            else
            {
                Reader = CoreReader(criteria);
            }

            while (Reader.Read())
            {
                collection.Add(new F050_DOC_REVENUE_MSTR
                {
                    RowCheckSum = Convert.ToInt32(Reader["ROWCHECKSUM"]),
                    ROWID = (Guid)Reader["ROWID"],
                    DOCREV_CLINIC_1_2 = Reader["DOCREV_CLINIC_1_2"].ToString(),
                    DOCREV_DEPT = ConvertDEC(Reader["DOCREV_DEPT"]),
                    DOCREV_DOC_NBR = Reader["DOCREV_DOC_NBR"].ToString(),
                    DOCREV_LOCATION = Reader["DOCREV_LOCATION"].ToString(),
                    DOCREV_OMA_CODE = Reader["DOCREV_OMA_CODE"].ToString(),
                    DOCREV_OMA_SUFF = Reader["DOCREV_OMA_SUFF"].ToString(),
                    DOCREV_MTD_IN_REC = ConvertDEC(Reader["DOCREV_MTD_IN_REC"]),
                    DOCREV_MTD_IN_SVC = ConvertDEC(Reader["DOCREV_MTD_IN_SVC"]),
                    DOCREV_MTD_OUT_REC = ConvertDEC(Reader["DOCREV_MTD_OUT_REC"]),
                    DOCREV_MTD_OUT_SVC = ConvertDEC(Reader["DOCREV_MTD_OUT_SVC"]),
                    DOCREV_YTD_IN_REC = ConvertDEC(Reader["DOCREV_YTD_IN_REC"]),
                    DOCREV_YTD_IN_SVC = ConvertDEC(Reader["DOCREV_YTD_IN_SVC"]),
                    DOCREV_YTD_OUT_REC = ConvertDEC(Reader["DOCREV_YTD_OUT_REC"]),
                    DOCREV_YTD_OUT_SVC = ConvertDEC(Reader["DOCREV_YTD_OUT_SVC"]),

                    _whereRowid = WhereRowid,
                    _whereDocrev_clinic_1_2 = WhereDocrev_clinic_1_2,
                    _whereDocrev_dept = WhereDocrev_dept,
                    _whereDocrev_doc_nbr = WhereDocrev_doc_nbr,
                    _whereDocrev_location = WhereDocrev_location,
                    _whereDocrev_oma_code = WhereDocrev_oma_code,
                    _whereDocrev_oma_suff = WhereDocrev_oma_suff,
                    _whereDocrev_mtd_in_rec = WhereDocrev_mtd_in_rec,
                    _whereDocrev_mtd_in_svc = WhereDocrev_mtd_in_svc,
                    _whereDocrev_mtd_out_rec = WhereDocrev_mtd_out_rec,
                    _whereDocrev_mtd_out_svc = WhereDocrev_mtd_out_svc,
                    _whereDocrev_ytd_in_rec = WhereDocrev_ytd_in_rec,
                    _whereDocrev_ytd_in_svc = WhereDocrev_ytd_in_svc,
                    _whereDocrev_ytd_out_rec = WhereDocrev_ytd_out_rec,
                    _whereDocrev_ytd_out_svc = WhereDocrev_ytd_out_svc,

                    RecordState = State.UnChanged
                });
            }

            CloseConnection(isClosedConnection);
            return collection;
        }
    }
}
