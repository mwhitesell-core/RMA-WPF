using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class R070_WORK_MSTR : BaseTable
    {
        #region Retrieve

        public ObservableCollection<R070_WORK_MSTR> Collection( Guid? rowid,
															decimal? clmhdr_doc_deptmin,
															decimal? clmhdr_doc_deptmax,
															string filler,
															decimal? clmhdr_agent_cdmin,
															decimal? clmhdr_agent_cdmax,
															string clmhdr_pat_acronym,
															string pat_ohip_mmyy,
															string claim_nbr,
															string clmhdr_status_ohip,
															string clmhdr_sub_nbr,
															decimal? docrev_mtd_in_recmin,
															decimal? docrev_mtd_in_recmax,
															decimal? docrev_mtd_out_recmin,
															decimal? docrev_mtd_out_recmax,
															string item_filler_2,
															string item_2_reserved,
															decimal? clmhdr_date_period_endmin,
															decimal? clmhdr_date_period_endmax,
															decimal? clmhdr_serv_datemin,
															decimal? clmhdr_serv_datemax,
															string clmhdr_batch_nbr,
															string clmhdr_tape_submit_ind,
															string clmhdr_reference,
															int? checksum_valuemin,
															int? checksum_valuemax,
                                                            string sortcolumn,
                                                            string sortdirection,
                                                            bool replaceSearch,
                                                            int skip)
        {
            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",rowid),
					new SqlParameter("minCLMHDR_DOC_DEPT",clmhdr_doc_deptmin),
					new SqlParameter("maxCLMHDR_DOC_DEPT",clmhdr_doc_deptmax),
					new SqlParameter("FILLER",filler),
					new SqlParameter("minCLMHDR_AGENT_CD",clmhdr_agent_cdmin),
					new SqlParameter("maxCLMHDR_AGENT_CD",clmhdr_agent_cdmax),
					new SqlParameter("CLMHDR_PAT_ACRONYM",clmhdr_pat_acronym),
					new SqlParameter("PAT_OHIP_MMYY",pat_ohip_mmyy),
					new SqlParameter("CLAIM_NBR",claim_nbr),
					new SqlParameter("CLMHDR_STATUS_OHIP",clmhdr_status_ohip),
					new SqlParameter("CLMHDR_SUB_NBR",clmhdr_sub_nbr),
					new SqlParameter("minDOCREV_MTD_IN_REC",docrev_mtd_in_recmin),
					new SqlParameter("maxDOCREV_MTD_IN_REC",docrev_mtd_in_recmax),
					new SqlParameter("minDOCREV_MTD_OUT_REC",docrev_mtd_out_recmin),
					new SqlParameter("maxDOCREV_MTD_OUT_REC",docrev_mtd_out_recmax),
					new SqlParameter("ITEM_FILLER_2",item_filler_2),
					new SqlParameter("ITEM_2_RESERVED",item_2_reserved),
					new SqlParameter("minCLMHDR_DATE_PERIOD_END",clmhdr_date_period_endmin),
					new SqlParameter("maxCLMHDR_DATE_PERIOD_END",clmhdr_date_period_endmax),
					new SqlParameter("minCLMHDR_SERV_DATE",clmhdr_serv_datemin),
					new SqlParameter("maxCLMHDR_SERV_DATE",clmhdr_serv_datemax),
					new SqlParameter("CLMHDR_BATCH_NBR",clmhdr_batch_nbr),
					new SqlParameter("CLMHDR_TAPE_SUBMIT_IND",clmhdr_tape_submit_ind),
					new SqlParameter("CLMHDR_REFERENCE",clmhdr_reference),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[SEQUENTIAL].[sp_R070_WORK_MSTR_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<R070_WORK_MSTR>();
				}

            }

            Reader = CoreReader("[SEQUENTIAL].[sp_R070_WORK_MSTR_Search]", parameters);
            var collection = new ObservableCollection<R070_WORK_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new R070_WORK_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLMHDR_DOC_DEPT = ConvertDEC(Reader["CLMHDR_DOC_DEPT"]),
					FILLER = Reader["FILLER"].ToString(),
					CLMHDR_AGENT_CD = ConvertDEC(Reader["CLMHDR_AGENT_CD"]),
					CLMHDR_PAT_ACRONYM = Reader["CLMHDR_PAT_ACRONYM"].ToString(),
					PAT_OHIP_MMYY = Reader["PAT_OHIP_MMYY"].ToString(),
					CLAIM_NBR = Reader["CLAIM_NBR"].ToString(),
					CLMHDR_STATUS_OHIP = Reader["CLMHDR_STATUS_OHIP"].ToString(),
					CLMHDR_SUB_NBR = Reader["CLMHDR_SUB_NBR"].ToString(),
					DOCREV_MTD_IN_REC = ConvertDEC(Reader["DOCREV_MTD_IN_REC"]),
					DOCREV_MTD_OUT_REC = ConvertDEC(Reader["DOCREV_MTD_OUT_REC"]),
					ITEM_FILLER_2 = Reader["ITEM_FILLER_2"].ToString(),
					ITEM_2_RESERVED = Reader["ITEM_2_RESERVED"].ToString(),
					CLMHDR_DATE_PERIOD_END = ConvertDEC(Reader["CLMHDR_DATE_PERIOD_END"]),
					CLMHDR_SERV_DATE = ConvertDEC(Reader["CLMHDR_SERV_DATE"]),
					CLMHDR_BATCH_NBR = Reader["CLMHDR_BATCH_NBR"].ToString(),
					CLMHDR_TAPE_SUBMIT_IND = Reader["CLMHDR_TAPE_SUBMIT_IND"].ToString(),
					CLMHDR_REFERENCE = Reader["CLMHDR_REFERENCE"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClmhdr_doc_dept = ConvertDEC(Reader["CLMHDR_DOC_DEPT"]),
					_originalFiller = Reader["FILLER"].ToString(),
					_originalClmhdr_agent_cd = ConvertDEC(Reader["CLMHDR_AGENT_CD"]),
					_originalClmhdr_pat_acronym = Reader["CLMHDR_PAT_ACRONYM"].ToString(),
					_originalPat_ohip_mmyy = Reader["PAT_OHIP_MMYY"].ToString(),
					_originalClaim_nbr = Reader["CLAIM_NBR"].ToString(),
					_originalClmhdr_status_ohip = Reader["CLMHDR_STATUS_OHIP"].ToString(),
					_originalClmhdr_sub_nbr = Reader["CLMHDR_SUB_NBR"].ToString(),
					_originalDocrev_mtd_in_rec = ConvertDEC(Reader["DOCREV_MTD_IN_REC"]),
					_originalDocrev_mtd_out_rec = ConvertDEC(Reader["DOCREV_MTD_OUT_REC"]),
					_originalItem_filler_2 = Reader["ITEM_FILLER_2"].ToString(),
					_originalItem_2_reserved = Reader["ITEM_2_RESERVED"].ToString(),
					_originalClmhdr_date_period_end = ConvertDEC(Reader["CLMHDR_DATE_PERIOD_END"]),
					_originalClmhdr_serv_date = ConvertDEC(Reader["CLMHDR_SERV_DATE"]),
					_originalClmhdr_batch_nbr = Reader["CLMHDR_BATCH_NBR"].ToString(),
					_originalClmhdr_tape_submit_ind = Reader["CLMHDR_TAPE_SUBMIT_IND"].ToString(),
					_originalClmhdr_reference = Reader["CLMHDR_REFERENCE"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public R070_WORK_MSTR Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<R070_WORK_MSTR> Collection(ObservableCollection<R070_WORK_MSTR>
                                                               r070WorkMstr = null)
        {
            if (IsSameSearch() && r070WorkMstr != null)
            {
                return r070WorkMstr;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<R070_WORK_MSTR>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("CLMHDR_DOC_DEPT",WhereClmhdr_doc_dept),
					new SqlParameter("FILLER",WhereFiller),
					new SqlParameter("CLMHDR_AGENT_CD",WhereClmhdr_agent_cd),
					new SqlParameter("CLMHDR_PAT_ACRONYM",WhereClmhdr_pat_acronym),
					new SqlParameter("PAT_OHIP_MMYY",WherePat_ohip_mmyy),
					new SqlParameter("CLAIM_NBR",WhereClaim_nbr),
					new SqlParameter("CLMHDR_STATUS_OHIP",WhereClmhdr_status_ohip),
					new SqlParameter("CLMHDR_SUB_NBR",WhereClmhdr_sub_nbr),
					new SqlParameter("DOCREV_MTD_IN_REC",WhereDocrev_mtd_in_rec),
					new SqlParameter("DOCREV_MTD_OUT_REC",WhereDocrev_mtd_out_rec),
					new SqlParameter("ITEM_FILLER_2",WhereItem_filler_2),
					new SqlParameter("ITEM_2_RESERVED",WhereItem_2_reserved),
					new SqlParameter("CLMHDR_DATE_PERIOD_END",WhereClmhdr_date_period_end),
					new SqlParameter("CLMHDR_SERV_DATE",WhereClmhdr_serv_date),
					new SqlParameter("CLMHDR_BATCH_NBR",WhereClmhdr_batch_nbr),
					new SqlParameter("CLMHDR_TAPE_SUBMIT_IND",WhereClmhdr_tape_submit_ind),
					new SqlParameter("CLMHDR_REFERENCE",WhereClmhdr_reference),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[SEQUENTIAL].[sp_R070_WORK_MSTR_Match]", parameters);
            var collection = new ObservableCollection<R070_WORK_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new R070_WORK_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLMHDR_DOC_DEPT = ConvertDEC(Reader["CLMHDR_DOC_DEPT"]),
					FILLER = Reader["FILLER"].ToString(),
					CLMHDR_AGENT_CD = ConvertDEC(Reader["CLMHDR_AGENT_CD"]),
					CLMHDR_PAT_ACRONYM = Reader["CLMHDR_PAT_ACRONYM"].ToString(),
					PAT_OHIP_MMYY = Reader["PAT_OHIP_MMYY"].ToString(),
					CLAIM_NBR = Reader["CLAIM_NBR"].ToString(),
					CLMHDR_STATUS_OHIP = Reader["CLMHDR_STATUS_OHIP"].ToString(),
					CLMHDR_SUB_NBR = Reader["CLMHDR_SUB_NBR"].ToString(),
					DOCREV_MTD_IN_REC = ConvertDEC(Reader["DOCREV_MTD_IN_REC"]),
					DOCREV_MTD_OUT_REC = ConvertDEC(Reader["DOCREV_MTD_OUT_REC"]),
					ITEM_FILLER_2 = Reader["ITEM_FILLER_2"].ToString(),
					ITEM_2_RESERVED = Reader["ITEM_2_RESERVED"].ToString(),
					CLMHDR_DATE_PERIOD_END = ConvertDEC(Reader["CLMHDR_DATE_PERIOD_END"]),
					CLMHDR_SERV_DATE = ConvertDEC(Reader["CLMHDR_SERV_DATE"]),
					CLMHDR_BATCH_NBR = Reader["CLMHDR_BATCH_NBR"].ToString(),
					CLMHDR_TAPE_SUBMIT_IND = Reader["CLMHDR_TAPE_SUBMIT_IND"].ToString(),
					CLMHDR_REFERENCE = Reader["CLMHDR_REFERENCE"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereClmhdr_doc_dept = WhereClmhdr_doc_dept,
					_whereFiller = WhereFiller,
					_whereClmhdr_agent_cd = WhereClmhdr_agent_cd,
					_whereClmhdr_pat_acronym = WhereClmhdr_pat_acronym,
					_wherePat_ohip_mmyy = WherePat_ohip_mmyy,
					_whereClaim_nbr = WhereClaim_nbr,
					_whereClmhdr_status_ohip = WhereClmhdr_status_ohip,
					_whereClmhdr_sub_nbr = WhereClmhdr_sub_nbr,
					_whereDocrev_mtd_in_rec = WhereDocrev_mtd_in_rec,
					_whereDocrev_mtd_out_rec = WhereDocrev_mtd_out_rec,
					_whereItem_filler_2 = WhereItem_filler_2,
					_whereItem_2_reserved = WhereItem_2_reserved,
					_whereClmhdr_date_period_end = WhereClmhdr_date_period_end,
					_whereClmhdr_serv_date = WhereClmhdr_serv_date,
					_whereClmhdr_batch_nbr = WhereClmhdr_batch_nbr,
					_whereClmhdr_tape_submit_ind = WhereClmhdr_tape_submit_ind,
					_whereClmhdr_reference = WhereClmhdr_reference,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClmhdr_doc_dept = ConvertDEC(Reader["CLMHDR_DOC_DEPT"]),
					_originalFiller = Reader["FILLER"].ToString(),
					_originalClmhdr_agent_cd = ConvertDEC(Reader["CLMHDR_AGENT_CD"]),
					_originalClmhdr_pat_acronym = Reader["CLMHDR_PAT_ACRONYM"].ToString(),
					_originalPat_ohip_mmyy = Reader["PAT_OHIP_MMYY"].ToString(),
					_originalClaim_nbr = Reader["CLAIM_NBR"].ToString(),
					_originalClmhdr_status_ohip = Reader["CLMHDR_STATUS_OHIP"].ToString(),
					_originalClmhdr_sub_nbr = Reader["CLMHDR_SUB_NBR"].ToString(),
					_originalDocrev_mtd_in_rec = ConvertDEC(Reader["DOCREV_MTD_IN_REC"]),
					_originalDocrev_mtd_out_rec = ConvertDEC(Reader["DOCREV_MTD_OUT_REC"]),
					_originalItem_filler_2 = Reader["ITEM_FILLER_2"].ToString(),
					_originalItem_2_reserved = Reader["ITEM_2_RESERVED"].ToString(),
					_originalClmhdr_date_period_end = ConvertDEC(Reader["CLMHDR_DATE_PERIOD_END"]),
					_originalClmhdr_serv_date = ConvertDEC(Reader["CLMHDR_SERV_DATE"]),
					_originalClmhdr_batch_nbr = Reader["CLMHDR_BATCH_NBR"].ToString(),
					_originalClmhdr_tape_submit_ind = Reader["CLMHDR_TAPE_SUBMIT_IND"].ToString(),
					_originalClmhdr_reference = Reader["CLMHDR_REFERENCE"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereClmhdr_doc_dept = WhereClmhdr_doc_dept;
					_whereFiller = WhereFiller;
					_whereClmhdr_agent_cd = WhereClmhdr_agent_cd;
					_whereClmhdr_pat_acronym = WhereClmhdr_pat_acronym;
					_wherePat_ohip_mmyy = WherePat_ohip_mmyy;
					_whereClaim_nbr = WhereClaim_nbr;
					_whereClmhdr_status_ohip = WhereClmhdr_status_ohip;
					_whereClmhdr_sub_nbr = WhereClmhdr_sub_nbr;
					_whereDocrev_mtd_in_rec = WhereDocrev_mtd_in_rec;
					_whereDocrev_mtd_out_rec = WhereDocrev_mtd_out_rec;
					_whereItem_filler_2 = WhereItem_filler_2;
					_whereItem_2_reserved = WhereItem_2_reserved;
					_whereClmhdr_date_period_end = WhereClmhdr_date_period_end;
					_whereClmhdr_serv_date = WhereClmhdr_serv_date;
					_whereClmhdr_batch_nbr = WhereClmhdr_batch_nbr;
					_whereClmhdr_tape_submit_ind = WhereClmhdr_tape_submit_ind;
					_whereClmhdr_reference = WhereClmhdr_reference;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereClmhdr_doc_dept == null 
				&& WhereFiller == null 
				&& WhereClmhdr_agent_cd == null 
				&& WhereClmhdr_pat_acronym == null 
				&& WherePat_ohip_mmyy == null 
				&& WhereClaim_nbr == null 
				&& WhereClmhdr_status_ohip == null 
				&& WhereClmhdr_sub_nbr == null 
				&& WhereDocrev_mtd_in_rec == null 
				&& WhereDocrev_mtd_out_rec == null 
				&& WhereItem_filler_2 == null 
				&& WhereItem_2_reserved == null 
				&& WhereClmhdr_date_period_end == null 
				&& WhereClmhdr_serv_date == null 
				&& WhereClmhdr_batch_nbr == null 
				&& WhereClmhdr_tape_submit_ind == null 
				&& WhereClmhdr_reference == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereClmhdr_doc_dept ==  _whereClmhdr_doc_dept
				&& WhereFiller ==  _whereFiller
				&& WhereClmhdr_agent_cd ==  _whereClmhdr_agent_cd
				&& WhereClmhdr_pat_acronym ==  _whereClmhdr_pat_acronym
				&& WherePat_ohip_mmyy ==  _wherePat_ohip_mmyy
				&& WhereClaim_nbr ==  _whereClaim_nbr
				&& WhereClmhdr_status_ohip ==  _whereClmhdr_status_ohip
				&& WhereClmhdr_sub_nbr ==  _whereClmhdr_sub_nbr
				&& WhereDocrev_mtd_in_rec ==  _whereDocrev_mtd_in_rec
				&& WhereDocrev_mtd_out_rec ==  _whereDocrev_mtd_out_rec
				&& WhereItem_filler_2 ==  _whereItem_filler_2
				&& WhereItem_2_reserved ==  _whereItem_2_reserved
				&& WhereClmhdr_date_period_end ==  _whereClmhdr_date_period_end
				&& WhereClmhdr_serv_date ==  _whereClmhdr_serv_date
				&& WhereClmhdr_batch_nbr ==  _whereClmhdr_batch_nbr
				&& WhereClmhdr_tape_submit_ind ==  _whereClmhdr_tape_submit_ind
				&& WhereClmhdr_reference ==  _whereClmhdr_reference
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereClmhdr_doc_dept = null; 
			WhereFiller = null; 
			WhereClmhdr_agent_cd = null; 
			WhereClmhdr_pat_acronym = null; 
			WherePat_ohip_mmyy = null; 
			WhereClaim_nbr = null; 
			WhereClmhdr_status_ohip = null; 
			WhereClmhdr_sub_nbr = null; 
			WhereDocrev_mtd_in_rec = null; 
			WhereDocrev_mtd_out_rec = null; 
			WhereItem_filler_2 = null; 
			WhereItem_2_reserved = null; 
			WhereClmhdr_date_period_end = null; 
			WhereClmhdr_serv_date = null; 
			WhereClmhdr_batch_nbr = null; 
			WhereClmhdr_tape_submit_ind = null; 
			WhereClmhdr_reference = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private decimal? _CLMHDR_DOC_DEPT;
		private string _FILLER;
		private decimal? _CLMHDR_AGENT_CD;
		private string _CLMHDR_PAT_ACRONYM;
		private string _PAT_OHIP_MMYY;
		private string _CLAIM_NBR;
		private string _CLMHDR_STATUS_OHIP;
		private string _CLMHDR_SUB_NBR;
		private decimal? _DOCREV_MTD_IN_REC;
		private decimal? _DOCREV_MTD_OUT_REC;
		private string _ITEM_FILLER_2;
		private string _ITEM_2_RESERVED;
		private decimal? _CLMHDR_DATE_PERIOD_END;
		private decimal? _CLMHDR_SERV_DATE;
		private string _CLMHDR_BATCH_NBR;
		private string _CLMHDR_TAPE_SUBMIT_IND;
		private string _CLMHDR_REFERENCE;
		private int? _CHECKSUM_VALUE;

		public Guid ROWID
		{
			get { return _ROWID; }
			set
			{
				if (_ROWID != value)
				{
					_ROWID = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_DOC_DEPT
		{
			get { return _CLMHDR_DOC_DEPT; }
			set
			{
				if (_CLMHDR_DOC_DEPT != value)
				{
					_CLMHDR_DOC_DEPT = value;
					ChangeState();
				}
			}
		}
		public string FILLER
		{
			get { return _FILLER; }
			set
			{
				if (_FILLER != value)
				{
					_FILLER = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_AGENT_CD
		{
			get { return _CLMHDR_AGENT_CD; }
			set
			{
				if (_CLMHDR_AGENT_CD != value)
				{
					_CLMHDR_AGENT_CD = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_PAT_ACRONYM
		{
			get { return _CLMHDR_PAT_ACRONYM; }
			set
			{
				if (_CLMHDR_PAT_ACRONYM != value)
				{
					_CLMHDR_PAT_ACRONYM = value;
					ChangeState();
				}
			}
		}
		public string PAT_OHIP_MMYY
		{
			get { return _PAT_OHIP_MMYY; }
			set
			{
				if (_PAT_OHIP_MMYY != value)
				{
					_PAT_OHIP_MMYY = value;
					ChangeState();
				}
			}
		}
		public string CLAIM_NBR
		{
			get { return _CLAIM_NBR; }
			set
			{
				if (_CLAIM_NBR != value)
				{
					_CLAIM_NBR = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_STATUS_OHIP
		{
			get { return _CLMHDR_STATUS_OHIP; }
			set
			{
				if (_CLMHDR_STATUS_OHIP != value)
				{
					_CLMHDR_STATUS_OHIP = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_SUB_NBR
		{
			get { return _CLMHDR_SUB_NBR; }
			set
			{
				if (_CLMHDR_SUB_NBR != value)
				{
					_CLMHDR_SUB_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCREV_MTD_IN_REC
		{
			get { return _DOCREV_MTD_IN_REC; }
			set
			{
				if (_DOCREV_MTD_IN_REC != value)
				{
					_DOCREV_MTD_IN_REC = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCREV_MTD_OUT_REC
		{
			get { return _DOCREV_MTD_OUT_REC; }
			set
			{
				if (_DOCREV_MTD_OUT_REC != value)
				{
					_DOCREV_MTD_OUT_REC = value;
					ChangeState();
				}
			}
		}
		public string ITEM_FILLER_2
		{
			get { return _ITEM_FILLER_2; }
			set
			{
				if (_ITEM_FILLER_2 != value)
				{
					_ITEM_FILLER_2 = value;
					ChangeState();
				}
			}
		}
		public string ITEM_2_RESERVED
		{
			get { return _ITEM_2_RESERVED; }
			set
			{
				if (_ITEM_2_RESERVED != value)
				{
					_ITEM_2_RESERVED = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_DATE_PERIOD_END
		{
			get { return _CLMHDR_DATE_PERIOD_END; }
			set
			{
				if (_CLMHDR_DATE_PERIOD_END != value)
				{
					_CLMHDR_DATE_PERIOD_END = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_SERV_DATE
		{
			get { return _CLMHDR_SERV_DATE; }
			set
			{
				if (_CLMHDR_SERV_DATE != value)
				{
					_CLMHDR_SERV_DATE = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_BATCH_NBR
		{
			get { return _CLMHDR_BATCH_NBR; }
			set
			{
				if (_CLMHDR_BATCH_NBR != value)
				{
					_CLMHDR_BATCH_NBR = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_TAPE_SUBMIT_IND
		{
			get { return _CLMHDR_TAPE_SUBMIT_IND; }
			set
			{
				if (_CLMHDR_TAPE_SUBMIT_IND != value)
				{
					_CLMHDR_TAPE_SUBMIT_IND = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_REFERENCE
		{
			get { return _CLMHDR_REFERENCE; }
			set
			{
				if (_CLMHDR_REFERENCE != value)
				{
					_CLMHDR_REFERENCE = value;
					ChangeState();
				}
			}
		}
		public int? CHECKSUM_VALUE
		{
			get { return _CHECKSUM_VALUE; }
			set
			{
				if (_CHECKSUM_VALUE != value)
				{
					_CHECKSUM_VALUE = value;
					ChangeState();
				}
			}
		}


        #endregion

        #region Where

		public Guid? WhereRowid { get; set; }
		private Guid? _whereRowid;
		public decimal? WhereClmhdr_doc_dept { get; set; }
		private decimal? _whereClmhdr_doc_dept;
		public string WhereFiller { get; set; }
		private string _whereFiller;
		public decimal? WhereClmhdr_agent_cd { get; set; }
		private decimal? _whereClmhdr_agent_cd;
		public string WhereClmhdr_pat_acronym { get; set; }
		private string _whereClmhdr_pat_acronym;
		public string WherePat_ohip_mmyy { get; set; }
		private string _wherePat_ohip_mmyy;
		public string WhereClaim_nbr { get; set; }
		private string _whereClaim_nbr;
		public string WhereClmhdr_status_ohip { get; set; }
		private string _whereClmhdr_status_ohip;
		public string WhereClmhdr_sub_nbr { get; set; }
		private string _whereClmhdr_sub_nbr;
		public decimal? WhereDocrev_mtd_in_rec { get; set; }
		private decimal? _whereDocrev_mtd_in_rec;
		public decimal? WhereDocrev_mtd_out_rec { get; set; }
		private decimal? _whereDocrev_mtd_out_rec;
		public string WhereItem_filler_2 { get; set; }
		private string _whereItem_filler_2;
		public string WhereItem_2_reserved { get; set; }
		private string _whereItem_2_reserved;
		public decimal? WhereClmhdr_date_period_end { get; set; }
		private decimal? _whereClmhdr_date_period_end;
		public decimal? WhereClmhdr_serv_date { get; set; }
		private decimal? _whereClmhdr_serv_date;
		public string WhereClmhdr_batch_nbr { get; set; }
		private string _whereClmhdr_batch_nbr;
		public string WhereClmhdr_tape_submit_ind { get; set; }
		private string _whereClmhdr_tape_submit_ind;
		public string WhereClmhdr_reference { get; set; }
		private string _whereClmhdr_reference;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private decimal? _originalClmhdr_doc_dept;
		private string _originalFiller;
		private decimal? _originalClmhdr_agent_cd;
		private string _originalClmhdr_pat_acronym;
		private string _originalPat_ohip_mmyy;
		private string _originalClaim_nbr;
		private string _originalClmhdr_status_ohip;
		private string _originalClmhdr_sub_nbr;
		private decimal? _originalDocrev_mtd_in_rec;
		private decimal? _originalDocrev_mtd_out_rec;
		private string _originalItem_filler_2;
		private string _originalItem_2_reserved;
		private decimal? _originalClmhdr_date_period_end;
		private decimal? _originalClmhdr_serv_date;
		private string _originalClmhdr_batch_nbr;
		private string _originalClmhdr_tape_submit_ind;
		private string _originalClmhdr_reference;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			CLMHDR_DOC_DEPT = _originalClmhdr_doc_dept;
			FILLER = _originalFiller;
			CLMHDR_AGENT_CD = _originalClmhdr_agent_cd;
			CLMHDR_PAT_ACRONYM = _originalClmhdr_pat_acronym;
			PAT_OHIP_MMYY = _originalPat_ohip_mmyy;
			CLAIM_NBR = _originalClaim_nbr;
			CLMHDR_STATUS_OHIP = _originalClmhdr_status_ohip;
			CLMHDR_SUB_NBR = _originalClmhdr_sub_nbr;
			DOCREV_MTD_IN_REC = _originalDocrev_mtd_in_rec;
			DOCREV_MTD_OUT_REC = _originalDocrev_mtd_out_rec;
			ITEM_FILLER_2 = _originalItem_filler_2;
			ITEM_2_RESERVED = _originalItem_2_reserved;
			CLMHDR_DATE_PERIOD_END = _originalClmhdr_date_period_end;
			CLMHDR_SERV_DATE = _originalClmhdr_serv_date;
			CLMHDR_BATCH_NBR = _originalClmhdr_batch_nbr;
			CLMHDR_TAPE_SUBMIT_IND = _originalClmhdr_tape_submit_ind;
			CLMHDR_REFERENCE = _originalClmhdr_reference;
			CHECKSUM_VALUE = _originalChecksum_value;

            RecordState = State.UnChanged;

            return true;
        }


        public bool Delete()
        {
			int RowsAffected = 0;
			var parameters = new SqlParameter[]
				{
					new SqlParameter("RowCheckSum",RowCheckSum),
					new SqlParameter("ROWID",ROWID)
				};
			RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_R070_WORK_MSTR_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_R070_WORK_MSTR_Purge]");
		    CloseConnection();
		    return true;
		}


        #endregion

        #region Submit

        public void Submit()
        {
            int RowsAffected = 0;
            SqlParameter[] parameters; 
            switch (RecordState)
            {
                case State.Adding:
                case State.Added:
					parameters = new SqlParameter[]
					{
						new SqlParameter("CLMHDR_DOC_DEPT", SqlNull(CLMHDR_DOC_DEPT)),
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("CLMHDR_AGENT_CD", SqlNull(CLMHDR_AGENT_CD)),
						new SqlParameter("CLMHDR_PAT_ACRONYM", SqlNull(CLMHDR_PAT_ACRONYM)),
						new SqlParameter("PAT_OHIP_MMYY", SqlNull(PAT_OHIP_MMYY)),
						new SqlParameter("CLAIM_NBR", SqlNull(CLAIM_NBR)),
						new SqlParameter("CLMHDR_STATUS_OHIP", SqlNull(CLMHDR_STATUS_OHIP)),
						new SqlParameter("CLMHDR_SUB_NBR", SqlNull(CLMHDR_SUB_NBR)),
						new SqlParameter("DOCREV_MTD_IN_REC", SqlNull(DOCREV_MTD_IN_REC)),
						new SqlParameter("DOCREV_MTD_OUT_REC", SqlNull(DOCREV_MTD_OUT_REC)),
						new SqlParameter("ITEM_FILLER_2", SqlNull(ITEM_FILLER_2)),
						new SqlParameter("ITEM_2_RESERVED", SqlNull(ITEM_2_RESERVED)),
						new SqlParameter("CLMHDR_DATE_PERIOD_END", SqlNull(CLMHDR_DATE_PERIOD_END)),
						new SqlParameter("CLMHDR_SERV_DATE", SqlNull(CLMHDR_SERV_DATE)),
						new SqlParameter("CLMHDR_BATCH_NBR", SqlNull(CLMHDR_BATCH_NBR)),
						new SqlParameter("CLMHDR_TAPE_SUBMIT_IND", SqlNull(CLMHDR_TAPE_SUBMIT_IND)),
						new SqlParameter("CLMHDR_REFERENCE", SqlNull(CLMHDR_REFERENCE)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_R070_WORK_MSTR_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLMHDR_DOC_DEPT = ConvertDEC(Reader["CLMHDR_DOC_DEPT"]);
						FILLER = Reader["FILLER"].ToString();
						CLMHDR_AGENT_CD = ConvertDEC(Reader["CLMHDR_AGENT_CD"]);
						CLMHDR_PAT_ACRONYM = Reader["CLMHDR_PAT_ACRONYM"].ToString();
						PAT_OHIP_MMYY = Reader["PAT_OHIP_MMYY"].ToString();
						CLAIM_NBR = Reader["CLAIM_NBR"].ToString();
						CLMHDR_STATUS_OHIP = Reader["CLMHDR_STATUS_OHIP"].ToString();
						CLMHDR_SUB_NBR = Reader["CLMHDR_SUB_NBR"].ToString();
						DOCREV_MTD_IN_REC = ConvertDEC(Reader["DOCREV_MTD_IN_REC"]);
						DOCREV_MTD_OUT_REC = ConvertDEC(Reader["DOCREV_MTD_OUT_REC"]);
						ITEM_FILLER_2 = Reader["ITEM_FILLER_2"].ToString();
						ITEM_2_RESERVED = Reader["ITEM_2_RESERVED"].ToString();
						CLMHDR_DATE_PERIOD_END = ConvertDEC(Reader["CLMHDR_DATE_PERIOD_END"]);
						CLMHDR_SERV_DATE = ConvertDEC(Reader["CLMHDR_SERV_DATE"]);
						CLMHDR_BATCH_NBR = Reader["CLMHDR_BATCH_NBR"].ToString();
						CLMHDR_TAPE_SUBMIT_IND = Reader["CLMHDR_TAPE_SUBMIT_IND"].ToString();
						CLMHDR_REFERENCE = Reader["CLMHDR_REFERENCE"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClmhdr_doc_dept = ConvertDEC(Reader["CLMHDR_DOC_DEPT"]);
						_originalFiller = Reader["FILLER"].ToString();
						_originalClmhdr_agent_cd = ConvertDEC(Reader["CLMHDR_AGENT_CD"]);
						_originalClmhdr_pat_acronym = Reader["CLMHDR_PAT_ACRONYM"].ToString();
						_originalPat_ohip_mmyy = Reader["PAT_OHIP_MMYY"].ToString();
						_originalClaim_nbr = Reader["CLAIM_NBR"].ToString();
						_originalClmhdr_status_ohip = Reader["CLMHDR_STATUS_OHIP"].ToString();
						_originalClmhdr_sub_nbr = Reader["CLMHDR_SUB_NBR"].ToString();
						_originalDocrev_mtd_in_rec = ConvertDEC(Reader["DOCREV_MTD_IN_REC"]);
						_originalDocrev_mtd_out_rec = ConvertDEC(Reader["DOCREV_MTD_OUT_REC"]);
						_originalItem_filler_2 = Reader["ITEM_FILLER_2"].ToString();
						_originalItem_2_reserved = Reader["ITEM_2_RESERVED"].ToString();
						_originalClmhdr_date_period_end = ConvertDEC(Reader["CLMHDR_DATE_PERIOD_END"]);
						_originalClmhdr_serv_date = ConvertDEC(Reader["CLMHDR_SERV_DATE"]);
						_originalClmhdr_batch_nbr = Reader["CLMHDR_BATCH_NBR"].ToString();
						_originalClmhdr_tape_submit_ind = Reader["CLMHDR_TAPE_SUBMIT_IND"].ToString();
						_originalClmhdr_reference = Reader["CLMHDR_REFERENCE"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("CLMHDR_DOC_DEPT", SqlNull(CLMHDR_DOC_DEPT)),
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("CLMHDR_AGENT_CD", SqlNull(CLMHDR_AGENT_CD)),
						new SqlParameter("CLMHDR_PAT_ACRONYM", SqlNull(CLMHDR_PAT_ACRONYM)),
						new SqlParameter("PAT_OHIP_MMYY", SqlNull(PAT_OHIP_MMYY)),
						new SqlParameter("CLAIM_NBR", SqlNull(CLAIM_NBR)),
						new SqlParameter("CLMHDR_STATUS_OHIP", SqlNull(CLMHDR_STATUS_OHIP)),
						new SqlParameter("CLMHDR_SUB_NBR", SqlNull(CLMHDR_SUB_NBR)),
						new SqlParameter("DOCREV_MTD_IN_REC", SqlNull(DOCREV_MTD_IN_REC)),
						new SqlParameter("DOCREV_MTD_OUT_REC", SqlNull(DOCREV_MTD_OUT_REC)),
						new SqlParameter("ITEM_FILLER_2", SqlNull(ITEM_FILLER_2)),
						new SqlParameter("ITEM_2_RESERVED", SqlNull(ITEM_2_RESERVED)),
						new SqlParameter("CLMHDR_DATE_PERIOD_END", SqlNull(CLMHDR_DATE_PERIOD_END)),
						new SqlParameter("CLMHDR_SERV_DATE", SqlNull(CLMHDR_SERV_DATE)),
						new SqlParameter("CLMHDR_BATCH_NBR", SqlNull(CLMHDR_BATCH_NBR)),
						new SqlParameter("CLMHDR_TAPE_SUBMIT_IND", SqlNull(CLMHDR_TAPE_SUBMIT_IND)),
						new SqlParameter("CLMHDR_REFERENCE", SqlNull(CLMHDR_REFERENCE)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_R070_WORK_MSTR_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLMHDR_DOC_DEPT = ConvertDEC(Reader["CLMHDR_DOC_DEPT"]);
						FILLER = Reader["FILLER"].ToString();
						CLMHDR_AGENT_CD = ConvertDEC(Reader["CLMHDR_AGENT_CD"]);
						CLMHDR_PAT_ACRONYM = Reader["CLMHDR_PAT_ACRONYM"].ToString();
						PAT_OHIP_MMYY = Reader["PAT_OHIP_MMYY"].ToString();
						CLAIM_NBR = Reader["CLAIM_NBR"].ToString();
						CLMHDR_STATUS_OHIP = Reader["CLMHDR_STATUS_OHIP"].ToString();
						CLMHDR_SUB_NBR = Reader["CLMHDR_SUB_NBR"].ToString();
						DOCREV_MTD_IN_REC = ConvertDEC(Reader["DOCREV_MTD_IN_REC"]);
						DOCREV_MTD_OUT_REC = ConvertDEC(Reader["DOCREV_MTD_OUT_REC"]);
						ITEM_FILLER_2 = Reader["ITEM_FILLER_2"].ToString();
						ITEM_2_RESERVED = Reader["ITEM_2_RESERVED"].ToString();
						CLMHDR_DATE_PERIOD_END = ConvertDEC(Reader["CLMHDR_DATE_PERIOD_END"]);
						CLMHDR_SERV_DATE = ConvertDEC(Reader["CLMHDR_SERV_DATE"]);
						CLMHDR_BATCH_NBR = Reader["CLMHDR_BATCH_NBR"].ToString();
						CLMHDR_TAPE_SUBMIT_IND = Reader["CLMHDR_TAPE_SUBMIT_IND"].ToString();
						CLMHDR_REFERENCE = Reader["CLMHDR_REFERENCE"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClmhdr_doc_dept = ConvertDEC(Reader["CLMHDR_DOC_DEPT"]);
						_originalFiller = Reader["FILLER"].ToString();
						_originalClmhdr_agent_cd = ConvertDEC(Reader["CLMHDR_AGENT_CD"]);
						_originalClmhdr_pat_acronym = Reader["CLMHDR_PAT_ACRONYM"].ToString();
						_originalPat_ohip_mmyy = Reader["PAT_OHIP_MMYY"].ToString();
						_originalClaim_nbr = Reader["CLAIM_NBR"].ToString();
						_originalClmhdr_status_ohip = Reader["CLMHDR_STATUS_OHIP"].ToString();
						_originalClmhdr_sub_nbr = Reader["CLMHDR_SUB_NBR"].ToString();
						_originalDocrev_mtd_in_rec = ConvertDEC(Reader["DOCREV_MTD_IN_REC"]);
						_originalDocrev_mtd_out_rec = ConvertDEC(Reader["DOCREV_MTD_OUT_REC"]);
						_originalItem_filler_2 = Reader["ITEM_FILLER_2"].ToString();
						_originalItem_2_reserved = Reader["ITEM_2_RESERVED"].ToString();
						_originalClmhdr_date_period_end = ConvertDEC(Reader["CLMHDR_DATE_PERIOD_END"]);
						_originalClmhdr_serv_date = ConvertDEC(Reader["CLMHDR_SERV_DATE"]);
						_originalClmhdr_batch_nbr = Reader["CLMHDR_BATCH_NBR"].ToString();
						_originalClmhdr_tape_submit_ind = Reader["CLMHDR_TAPE_SUBMIT_IND"].ToString();
						_originalClmhdr_reference = Reader["CLMHDR_REFERENCE"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                   
                    break;
            }
	    CloseConnection();
	     
            RecordState = State.UnChanged;
        }

        #endregion

      
    }
}