using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
using System.Text;

namespace RmaDAL
{
    public partial class F051_DOC_CASH_MSTR
    {
        public ObservableCollection<F051_DOC_CASH_MSTR> Collection_UsingStart(ref bool isRetrieveRecord, ObservableCollection<F051_DOC_CASH_MSTR> f051_doc_cash_mstr = null)
        {
            if (f051_doc_cash_mstr != null)
            {
                F051_DOC_CASH_MSTR objF051_DOC_CASH_MSTR = f051_doc_cash_mstr.FirstOrDefault();
                if (objF051_DOC_CASH_MSTR != null)
                {
                    _whereDocash_clinic_1_2 = objF051_DOC_CASH_MSTR._whereDocash_clinic_1_2; // _DOCASH_CLINIC_1_2;                 
                    _whereDocash_dept = objF051_DOC_CASH_MSTR._whereDocash_dept;  //_DOCASH_DEPT;                    
                    _whereDocash_doc_nbr = objF051_DOC_CASH_MSTR._whereDocash_doc_nbr; //_DOCASH_DOC_NBR;                    
                    _whereDocash_location = objF051_DOC_CASH_MSTR._whereDocash_location; //_DOCASH_LOCATION;                    
                    _whereDocash_agency_type = objF051_DOC_CASH_MSTR._whereDocash_agency_type; //_DOCASH_AGENCY_TYPE;

                    if (IsSameSearch())
                    {
                        isRetrieveRecord = false;
                        return f051_doc_cash_mstr;
                    }
                }
            }

            var collection = new ObservableCollection<F051_DOC_CASH_MSTR>();
            isRetrieveRecord = true;
            StringBuilder sql = null;
            sql = new StringBuilder();
            string criteria = string.Empty;

            sql.Append("SELECT")
                .Append(" BINARY_CHECKSUM(*) AS [ROWCHECKSUM]")
                .Append(" ,[DOCASH_CLINIC_1_2]")
                .Append(" ,[DOCASH_DEPT]")
                .Append(" ,[DOCASH_DOC_NBR]")
                .Append(" ,[DOCASH_LOCATION]")
                .Append(" ,[DOCASH_AGENCY_TYPE]")
                .Append(" ,[DOCASH_MTD_IN_REC]")
                .Append(" ,[DOCASH_MTD_IN_SVC]")
                .Append(" ,[DOCASH_YTD_IN_REC]")
                .Append(" ,[DOCASH_YTD_IN_SVC]")
                .Append(" ,[FILLER]")
                .Append("  FROM")
                .Append("  [INDEXED].[F051_DOC_CASH_MSTR]  WITH (NOLOCK) ")
                .Append("  WHERE")
                .Append("  DOCASH_CLINIC_1_2 >= '").Append(WhereDocash_clinic_1_2).Append("'");
            
            if (WhereDocash_dept > 0)
            {
                sql.Append("  AND");
                sql.Append("  DOCASH_DEPT >= ").Append(WhereDocash_dept);
            }

            if (!string.IsNullOrWhiteSpace(WhereDocash_doc_nbr)) {
                sql.Append("  AND");
                sql.Append("  DOCASH_DOC_NBR >=  '").Append(WhereDocash_doc_nbr).Append("'");
            }
            if (!string.IsNullOrWhiteSpace(WhereDocash_location)) {
                sql.Append("  AND");
                sql.Append("  DOCASH_LOCATION  >= '").Append(WhereDocash_location).Append("'");
            }
            if (!string.IsNullOrWhiteSpace(WhereDocash_agency_type)) {
                sql.Append("  AND");
                sql.Append("  DOCASH_AGENCY_TYPE >= '").Append(WhereDocash_agency_type).Append("'");
            }

            Reader = CoreReader(sql.ToString());
            while (Reader.Read())
            {
                collection.Add(new F051_DOC_CASH_MSTR
                {
                    RowCheckSum = Convert.ToInt32(Reader["ROWCHECKSUM"]),
                    DOCASH_CLINIC_1_2 = Reader["DOCASH_CLINIC_1_2"].ToString(),
                    DOCASH_DEPT = ConvertDEC(Reader["DOCASH_DEPT"]),
                    DOCASH_DOC_NBR = Reader["DOCASH_DOC_NBR"].ToString(),
                    DOCASH_LOCATION = Reader["DOCASH_LOCATION"].ToString(),
                    DOCASH_AGENCY_TYPE = Reader["DOCASH_AGENCY_TYPE"].ToString(),
                    DOCASH_MTD_IN_REC = ConvertDEC(Reader["DOCASH_MTD_IN_REC"]),
                    DOCASH_MTD_IN_SVC = ConvertDEC(Reader["DOCASH_MTD_IN_SVC"]),
                    DOCASH_YTD_IN_REC = ConvertDEC(Reader["DOCASH_YTD_IN_REC"]),
                    DOCASH_YTD_IN_SVC = ConvertDEC(Reader["DOCASH_YTD_IN_SVC"]),
                    FILLER = Reader["FILLER"].ToString(),

                    _whereRowid = WhereRowid,
                    _whereDocash_clinic_1_2 = WhereDocash_clinic_1_2,
                    _whereDocash_dept = WhereDocash_dept,
                    _whereDocash_doc_nbr = WhereDocash_doc_nbr,
                    _whereDocash_location = WhereDocash_location,
                    _whereDocash_agency_type = WhereDocash_agency_type,
                    _whereDocash_mtd_in_rec = WhereDocash_mtd_in_rec,
                    _whereDocash_mtd_in_svc = WhereDocash_mtd_in_svc,
                    _whereDocash_ytd_in_rec = WhereDocash_ytd_in_rec,
                    _whereDocash_ytd_in_svc = WhereDocash_ytd_in_svc,
                    _whereFiller = WhereFiller,

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            return collection;
        }


        public F051_DOC_CASH_MSTR Collection_ReadStart()
        {
            StringBuilder sql = null;
            sql = new StringBuilder();

            sql.Append("SELECT TOP 1 ")
                .Append(" BINARY_CHECKSUM(*) AS [ROWCHECKSUM]")
                .Append(" ,[DOCASH_CLINIC_1_2]")
                .Append(" ,[DOCASH_DEPT]")
                .Append(" ,[DOCASH_DOC_NBR]")
                .Append(" ,[DOCASH_LOCATION]")
                .Append(" ,[DOCASH_AGENCY_TYPE]")
                .Append(" ,[DOCASH_MTD_IN_REC]")
                .Append(" ,[DOCASH_MTD_IN_SVC]")
                .Append(" ,[DOCASH_YTD_IN_REC]")
                .Append(" ,[DOCASH_YTD_IN_SVC]")
                .Append(" ,[FILLER]")
                .Append("  FROM")
                .Append("  [INDEXED].[F051_DOC_CASH_MSTR]  WITH (NOLOCK) ")
                .Append("  WHERE")
                .Append("  DOCASH_CLINIC_1_2 >= '").Append(WhereDocash_clinic_1_2).Append("'");

            if (WhereDocash_dept > 0)
            {
                sql.Append("  AND");
                sql.Append("  DOCASH_DEPT >= ").Append(WhereDocash_dept);
            }

            if (!string.IsNullOrWhiteSpace(WhereDocash_doc_nbr))
            {
                sql.Append("  AND");
                sql.Append("  DOCASH_DOC_NBR >=  '").Append(WhereDocash_doc_nbr).Append("'");
            }
            if (!string.IsNullOrWhiteSpace(WhereDocash_location))
            {
                sql.Append("  AND");
                sql.Append("  DOCASH_LOCATION  >= '").Append(WhereDocash_location).Append("'");
            }
            if (!string.IsNullOrWhiteSpace(WhereDocash_agency_type))
            {
                sql.Append("  AND");
                sql.Append("  DOCASH_AGENCY_TYPE >= '").Append(WhereDocash_agency_type).Append("'");
            }

            sql.Append(" ORDER BY");
            sql.Append(" DOCASH_CLINIC_1_2,");
            sql.Append(" DOCASH_DEPT,");
            sql.Append(" DOCASH_DOC_NBR,");
            sql.Append(" DOCASH_LOCATION,");
            sql.Append(" DOCASH_AGENCY_TYPE");

            Reader = CoreReader(sql.ToString());

            F051_DOC_CASH_MSTR objF051_DOC_CASH_MSTR = null;

            while (Reader.Read())
            {
                objF051_DOC_CASH_MSTR = new F051_DOC_CASH_MSTR
                {
                    RowCheckSum = Convert.ToInt32(Reader["ROWCHECKSUM"]),
                    DOCASH_CLINIC_1_2 = Reader["DOCASH_CLINIC_1_2"].ToString(),
                    DOCASH_DEPT = ConvertDEC(Reader["DOCASH_DEPT"]),
                    DOCASH_DOC_NBR = Reader["DOCASH_DOC_NBR"].ToString(),
                    DOCASH_LOCATION = Reader["DOCASH_LOCATION"].ToString(),
                    DOCASH_AGENCY_TYPE = Reader["DOCASH_AGENCY_TYPE"].ToString(),
                    DOCASH_MTD_IN_REC = ConvertDEC(Reader["DOCASH_MTD_IN_REC"]),
                    DOCASH_MTD_IN_SVC = ConvertDEC(Reader["DOCASH_MTD_IN_SVC"]),
                    DOCASH_YTD_IN_REC = ConvertDEC(Reader["DOCASH_YTD_IN_REC"]),
                    DOCASH_YTD_IN_SVC = ConvertDEC(Reader["DOCASH_YTD_IN_SVC"]),
                    FILLER = Reader["FILLER"].ToString(),

                    _whereRowid = WhereRowid,
                    _whereDocash_clinic_1_2 = WhereDocash_clinic_1_2,
                    _whereDocash_dept = WhereDocash_dept,
                    _whereDocash_doc_nbr = WhereDocash_doc_nbr,
                    _whereDocash_location = WhereDocash_location,
                    _whereDocash_agency_type = WhereDocash_agency_type,
                    _whereDocash_mtd_in_rec = WhereDocash_mtd_in_rec,
                    _whereDocash_mtd_in_svc = WhereDocash_mtd_in_svc,
                    _whereDocash_ytd_in_rec = WhereDocash_ytd_in_rec,
                    _whereDocash_ytd_in_svc = WhereDocash_ytd_in_svc,
                    _whereFiller = WhereFiller,

                    RecordState = State.UnChanged
                };
            }

            CloseConnection();
            return objF051_DOC_CASH_MSTR;
        }

        public F051_DOC_CASH_MSTR Collection_ReadNext(F051_DOC_CASH_MSTR objF051_DOC_CASH_MSTR)
        {
            StringBuilder sql = null;
            sql = new StringBuilder();

            sql.Append("SELECT TOP 2 ")
              .Append("  ROW_NUMBER() OVER (ORDER BY  DOCASH_CLINIC_1_2,DOCASH_DEPT,DOCASH_DOC_NBR,DOCASH_LOCATION,DOCASH_AGENCY_TYPE) AS 'ROWNUM'")
              .Append(" ,BINARY_CHECKSUM(*) AS [ROWCHECKSUM]")
              .Append(" ,[DOCASH_CLINIC_1_2]")
              .Append(" ,[DOCASH_DEPT]")
              .Append(" ,[DOCASH_DOC_NBR]")
              .Append(" ,[DOCASH_LOCATION]")
              .Append(" ,[DOCASH_AGENCY_TYPE]")
              .Append(" ,[DOCASH_MTD_IN_REC]")
              .Append(" ,[DOCASH_MTD_IN_SVC]")
              .Append(" ,[DOCASH_YTD_IN_REC]")
              .Append(" ,[DOCASH_YTD_IN_SVC]")
              .Append(" ,[FILLER]")
              .Append("  FROM")
              .Append("  [INDEXED].[F051_DOC_CASH_MSTR]  WITH (NOLOCK) ")
              .Append("  WHERE")
              .Append("  DOCASH_CLINIC_1_2 >= '").Append(objF051_DOC_CASH_MSTR.DOCASH_CLINIC_1_2).Append("'")                      
              .Append("  AND")
              .Append("  DOCASH_DEPT >= ").Append(objF051_DOC_CASH_MSTR.DOCASH_DEPT)                        
              .Append("  AND")
              .Append("  DOCASH_DOC_NBR >=  '").Append(objF051_DOC_CASH_MSTR.DOCASH_DOC_NBR).Append("'")                        
              .Append("  AND")
              .Append("  DOCASH_LOCATION  >= '").Append(objF051_DOC_CASH_MSTR.DOCASH_LOCATION).Append("'")                        
              .Append("  AND")
              .Append("  DOCASH_AGENCY_TYPE >= '").Append(objF051_DOC_CASH_MSTR.DOCASH_AGENCY_TYPE).Append("'")
              .Append(" ORDER BY")
              .Append(" DOCASH_CLINIC_1_2,")
              .Append(" DOCASH_DEPT,")
              .Append(" DOCASH_DOC_NBR,")
              .Append(" DOCASH_LOCATION,")
              .Append(" DOCASH_AGENCY_TYPE");

               Reader = CoreReader(sql.ToString());
              objF051_DOC_CASH_MSTR = null;

            while (Reader.Read())
            {
                if (ConvertINT(Reader["ROWNUM"]) == 2)
                {
                    objF051_DOC_CASH_MSTR = new F051_DOC_CASH_MSTR
                    {
                        RowCheckSum = Convert.ToInt32(Reader["ROWCHECKSUM"]),
                        DOCASH_CLINIC_1_2 = Reader["DOCASH_CLINIC_1_2"].ToString(),
                        DOCASH_DEPT = ConvertDEC(Reader["DOCASH_DEPT"]),
                        DOCASH_DOC_NBR = Reader["DOCASH_DOC_NBR"].ToString(),
                        DOCASH_LOCATION = Reader["DOCASH_LOCATION"].ToString(),
                        DOCASH_AGENCY_TYPE = Reader["DOCASH_AGENCY_TYPE"].ToString(),
                        DOCASH_MTD_IN_REC = ConvertDEC(Reader["DOCASH_MTD_IN_REC"]),
                        DOCASH_MTD_IN_SVC = ConvertDEC(Reader["DOCASH_MTD_IN_SVC"]),
                        DOCASH_YTD_IN_REC = ConvertDEC(Reader["DOCASH_YTD_IN_REC"]),
                        DOCASH_YTD_IN_SVC = ConvertDEC(Reader["DOCASH_YTD_IN_SVC"]),
                        FILLER = Reader["FILLER"].ToString(),

                        _whereRowid = WhereRowid,
                        _whereDocash_clinic_1_2 = WhereDocash_clinic_1_2,
                        _whereDocash_dept = WhereDocash_dept,
                        _whereDocash_doc_nbr = WhereDocash_doc_nbr,
                        _whereDocash_location = WhereDocash_location,
                        _whereDocash_agency_type = WhereDocash_agency_type,
                        _whereDocash_mtd_in_rec = WhereDocash_mtd_in_rec,
                        _whereDocash_mtd_in_svc = WhereDocash_mtd_in_svc,
                        _whereDocash_ytd_in_rec = WhereDocash_ytd_in_rec,
                        _whereDocash_ytd_in_svc = WhereDocash_ytd_in_svc,
                        _whereFiller = WhereFiller,

                        RecordState = State.UnChanged
                    };
                }
            }
            CloseConnection();
            return objF051_DOC_CASH_MSTR;
        }

    }
}
