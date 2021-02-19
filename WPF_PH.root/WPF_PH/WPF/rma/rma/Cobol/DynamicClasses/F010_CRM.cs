using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F010_CRM : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F010_CRM> Collection( Guid? rowid,
															string key_pat_mstr,
															string clmhdr_batch_nbr,
															decimal? clmhdr_claim_nbrmin,
															decimal? clmhdr_claim_nbrmax,
															decimal? ghost_date_descendingmin,
															decimal? ghost_date_descendingmax,
															decimal? date_assignedmin,
															decimal? date_assignedmax,
															decimal? time_assignedmin,
															decimal? time_assignedmax,
															decimal? key_dtl_seq_nbrmin,
															decimal? key_dtl_seq_nbrmax,
															string action_code,
															string followup_action,
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
					new SqlParameter("KEY_PAT_MSTR",key_pat_mstr),
					new SqlParameter("CLMHDR_BATCH_NBR",clmhdr_batch_nbr),
					new SqlParameter("minCLMHDR_CLAIM_NBR",clmhdr_claim_nbrmin),
					new SqlParameter("maxCLMHDR_CLAIM_NBR",clmhdr_claim_nbrmax),
					new SqlParameter("minGHOST_DATE_DESCENDING",ghost_date_descendingmin),
					new SqlParameter("maxGHOST_DATE_DESCENDING",ghost_date_descendingmax),
					new SqlParameter("minDATE_ASSIGNED",date_assignedmin),
					new SqlParameter("maxDATE_ASSIGNED",date_assignedmax),
					new SqlParameter("minTIME_ASSIGNED",time_assignedmin),
					new SqlParameter("maxTIME_ASSIGNED",time_assignedmax),
					new SqlParameter("minKEY_DTL_SEQ_NBR",key_dtl_seq_nbrmin),
					new SqlParameter("maxKEY_DTL_SEQ_NBR",key_dtl_seq_nbrmax),
					new SqlParameter("ACTION_CODE",action_code),
					new SqlParameter("FOLLOWUP_ACTION",followup_action),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F010_CRM_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F010_CRM>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F010_CRM_Search]", parameters);
            var collection = new ObservableCollection<F010_CRM>();

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

					_originalRowid =  (Guid)Reader["ROWID"],
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

        public F010_CRM Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F010_CRM> Collection(ObservableCollection<F010_CRM>
                                                               f010Crm = null)
        {
            if (IsSameSearch() && f010Crm != null)
            {
                return f010Crm;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F010_CRM>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("KEY_PAT_MSTR",WhereKey_pat_mstr),
					new SqlParameter("CLMHDR_BATCH_NBR",WhereClmhdr_batch_nbr),
					new SqlParameter("CLMHDR_CLAIM_NBR",WhereClmhdr_claim_nbr),
					new SqlParameter("GHOST_DATE_DESCENDING",WhereGhost_date_descending),
					new SqlParameter("DATE_ASSIGNED",WhereDate_assigned),
					new SqlParameter("TIME_ASSIGNED",WhereTime_assigned),
					new SqlParameter("KEY_DTL_SEQ_NBR",WhereKey_dtl_seq_nbr),
					new SqlParameter("ACTION_CODE",WhereAction_code),
					new SqlParameter("FOLLOWUP_ACTION",WhereFollowup_action),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F010_CRM_Match]", parameters);
            var collection = new ObservableCollection<F010_CRM>();

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

					_originalRowid =  (Guid)Reader["ROWID"],
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

					_whereRowid = WhereRowid;
					_whereKey_pat_mstr = WhereKey_pat_mstr;
					_whereClmhdr_batch_nbr = WhereClmhdr_batch_nbr;
					_whereClmhdr_claim_nbr = WhereClmhdr_claim_nbr;
					_whereGhost_date_descending = WhereGhost_date_descending;
					_whereDate_assigned = WhereDate_assigned;
					_whereTime_assigned = WhereTime_assigned;
					_whereKey_dtl_seq_nbr = WhereKey_dtl_seq_nbr;
					_whereAction_code = WhereAction_code;
					_whereFollowup_action = WhereFollowup_action;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereKey_pat_mstr == null 
				&& WhereClmhdr_batch_nbr == null 
				&& WhereClmhdr_claim_nbr == null 
				&& WhereGhost_date_descending == null 
				&& WhereDate_assigned == null 
				&& WhereTime_assigned == null 
				&& WhereKey_dtl_seq_nbr == null 
				&& WhereAction_code == null 
				&& WhereFollowup_action == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereKey_pat_mstr ==  _whereKey_pat_mstr
				&& WhereClmhdr_batch_nbr ==  _whereClmhdr_batch_nbr
				&& WhereClmhdr_claim_nbr ==  _whereClmhdr_claim_nbr
				&& WhereGhost_date_descending ==  _whereGhost_date_descending
				&& WhereDate_assigned ==  _whereDate_assigned
				&& WhereTime_assigned ==  _whereTime_assigned
				&& WhereKey_dtl_seq_nbr ==  _whereKey_dtl_seq_nbr
				&& WhereAction_code ==  _whereAction_code
				&& WhereFollowup_action ==  _whereFollowup_action
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereKey_pat_mstr = null; 
			WhereClmhdr_batch_nbr = null; 
			WhereClmhdr_claim_nbr = null; 
			WhereGhost_date_descending = null; 
			WhereDate_assigned = null; 
			WhereTime_assigned = null; 
			WhereKey_dtl_seq_nbr = null; 
			WhereAction_code = null; 
			WhereFollowup_action = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _KEY_PAT_MSTR;
		private string _CLMHDR_BATCH_NBR;
		private decimal? _CLMHDR_CLAIM_NBR;
		private decimal? _GHOST_DATE_DESCENDING;
		private decimal? _DATE_ASSIGNED;
		private decimal? _TIME_ASSIGNED;
		private decimal? _KEY_DTL_SEQ_NBR;
		private string _ACTION_CODE;
		private string _FOLLOWUP_ACTION;
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
		public string KEY_PAT_MSTR
		{
			get { return _KEY_PAT_MSTR; }
			set
			{
				if (_KEY_PAT_MSTR != value)
				{
					_KEY_PAT_MSTR = value;
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
		public decimal? CLMHDR_CLAIM_NBR
		{
			get { return _CLMHDR_CLAIM_NBR; }
			set
			{
				if (_CLMHDR_CLAIM_NBR != value)
				{
					_CLMHDR_CLAIM_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? GHOST_DATE_DESCENDING
		{
			get { return _GHOST_DATE_DESCENDING; }
			set
			{
				if (_GHOST_DATE_DESCENDING != value)
				{
					_GHOST_DATE_DESCENDING = value;
					ChangeState();
				}
			}
		}
		public decimal? DATE_ASSIGNED
		{
			get { return _DATE_ASSIGNED; }
			set
			{
				if (_DATE_ASSIGNED != value)
				{
					_DATE_ASSIGNED = value;
					ChangeState();
				}
			}
		}
		public decimal? TIME_ASSIGNED
		{
			get { return _TIME_ASSIGNED; }
			set
			{
				if (_TIME_ASSIGNED != value)
				{
					_TIME_ASSIGNED = value;
					ChangeState();
				}
			}
		}
		public decimal? KEY_DTL_SEQ_NBR
		{
			get { return _KEY_DTL_SEQ_NBR; }
			set
			{
				if (_KEY_DTL_SEQ_NBR != value)
				{
					_KEY_DTL_SEQ_NBR = value;
					ChangeState();
				}
			}
		}
		public string ACTION_CODE
		{
			get { return _ACTION_CODE; }
			set
			{
				if (_ACTION_CODE != value)
				{
					_ACTION_CODE = value;
					ChangeState();
				}
			}
		}
		public string FOLLOWUP_ACTION
		{
			get { return _FOLLOWUP_ACTION; }
			set
			{
				if (_FOLLOWUP_ACTION != value)
				{
					_FOLLOWUP_ACTION = value;
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
		public string WhereKey_pat_mstr { get; set; }
		private string _whereKey_pat_mstr;
		public string WhereClmhdr_batch_nbr { get; set; }
		private string _whereClmhdr_batch_nbr;
		public decimal? WhereClmhdr_claim_nbr { get; set; }
		private decimal? _whereClmhdr_claim_nbr;
		public decimal? WhereGhost_date_descending { get; set; }
		private decimal? _whereGhost_date_descending;
		public decimal? WhereDate_assigned { get; set; }
		private decimal? _whereDate_assigned;
		public decimal? WhereTime_assigned { get; set; }
		private decimal? _whereTime_assigned;
		public decimal? WhereKey_dtl_seq_nbr { get; set; }
		private decimal? _whereKey_dtl_seq_nbr;
		public string WhereAction_code { get; set; }
		private string _whereAction_code;
		public string WhereFollowup_action { get; set; }
		private string _whereFollowup_action;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalKey_pat_mstr;
		private string _originalClmhdr_batch_nbr;
		private decimal? _originalClmhdr_claim_nbr;
		private decimal? _originalGhost_date_descending;
		private decimal? _originalDate_assigned;
		private decimal? _originalTime_assigned;
		private decimal? _originalKey_dtl_seq_nbr;
		private string _originalAction_code;
		private string _originalFollowup_action;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			KEY_PAT_MSTR = _originalKey_pat_mstr;
			CLMHDR_BATCH_NBR = _originalClmhdr_batch_nbr;
			CLMHDR_CLAIM_NBR = _originalClmhdr_claim_nbr;
			GHOST_DATE_DESCENDING = _originalGhost_date_descending;
			DATE_ASSIGNED = _originalDate_assigned;
			TIME_ASSIGNED = _originalTime_assigned;
			KEY_DTL_SEQ_NBR = _originalKey_dtl_seq_nbr;
			ACTION_CODE = _originalAction_code;
			FOLLOWUP_ACTION = _originalFollowup_action;
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
					new SqlParameter("ROWID",ROWID),
					new SqlParameter("KEY_PAT_MSTR",KEY_PAT_MSTR),
					new SqlParameter("CLMHDR_BATCH_NBR",CLMHDR_BATCH_NBR),
					new SqlParameter("CLMHDR_CLAIM_NBR",CLMHDR_CLAIM_NBR),
					new SqlParameter("GHOST_DATE_DESCENDING",GHOST_DATE_DESCENDING),
					new SqlParameter("DATE_ASSIGNED",DATE_ASSIGNED),
					new SqlParameter("TIME_ASSIGNED",TIME_ASSIGNED),
					new SqlParameter("KEY_DTL_SEQ_NBR",KEY_DTL_SEQ_NBR)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F010_CRM_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F010_CRM_Purge]");
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
						new SqlParameter("KEY_PAT_MSTR", SqlNull(KEY_PAT_MSTR)),
						new SqlParameter("CLMHDR_BATCH_NBR", SqlNull(CLMHDR_BATCH_NBR)),
						new SqlParameter("CLMHDR_CLAIM_NBR", SqlNull(CLMHDR_CLAIM_NBR)),
						new SqlParameter("GHOST_DATE_DESCENDING", SqlNull(GHOST_DATE_DESCENDING)),
						new SqlParameter("DATE_ASSIGNED", SqlNull(DATE_ASSIGNED)),
						new SqlParameter("TIME_ASSIGNED", SqlNull(TIME_ASSIGNED)),
						new SqlParameter("KEY_DTL_SEQ_NBR", SqlNull(KEY_DTL_SEQ_NBR)),
						new SqlParameter("ACTION_CODE", SqlNull(ACTION_CODE)),
						new SqlParameter("FOLLOWUP_ACTION", SqlNull(FOLLOWUP_ACTION)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F010_CRM_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						KEY_PAT_MSTR = Reader["KEY_PAT_MSTR"].ToString();
						CLMHDR_BATCH_NBR = Reader["CLMHDR_BATCH_NBR"].ToString();
						CLMHDR_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]);
						GHOST_DATE_DESCENDING = ConvertDEC(Reader["GHOST_DATE_DESCENDING"]);
						DATE_ASSIGNED = ConvertDEC(Reader["DATE_ASSIGNED"]);
						TIME_ASSIGNED = ConvertDEC(Reader["TIME_ASSIGNED"]);
						KEY_DTL_SEQ_NBR = ConvertDEC(Reader["KEY_DTL_SEQ_NBR"]);
						ACTION_CODE = Reader["ACTION_CODE"].ToString();
						FOLLOWUP_ACTION = Reader["FOLLOWUP_ACTION"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalKey_pat_mstr = Reader["KEY_PAT_MSTR"].ToString();
						_originalClmhdr_batch_nbr = Reader["CLMHDR_BATCH_NBR"].ToString();
						_originalClmhdr_claim_nbr = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]);
						_originalGhost_date_descending = ConvertDEC(Reader["GHOST_DATE_DESCENDING"]);
						_originalDate_assigned = ConvertDEC(Reader["DATE_ASSIGNED"]);
						_originalTime_assigned = ConvertDEC(Reader["TIME_ASSIGNED"]);
						_originalKey_dtl_seq_nbr = ConvertDEC(Reader["KEY_DTL_SEQ_NBR"]);
						_originalAction_code = Reader["ACTION_CODE"].ToString();
						_originalFollowup_action = Reader["FOLLOWUP_ACTION"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("KEY_PAT_MSTR", SqlNull(KEY_PAT_MSTR)),
						new SqlParameter("CLMHDR_BATCH_NBR", SqlNull(CLMHDR_BATCH_NBR)),
						new SqlParameter("CLMHDR_CLAIM_NBR", SqlNull(CLMHDR_CLAIM_NBR)),
						new SqlParameter("GHOST_DATE_DESCENDING", SqlNull(GHOST_DATE_DESCENDING)),
						new SqlParameter("DATE_ASSIGNED", SqlNull(DATE_ASSIGNED)),
						new SqlParameter("TIME_ASSIGNED", SqlNull(TIME_ASSIGNED)),
						new SqlParameter("KEY_DTL_SEQ_NBR", SqlNull(KEY_DTL_SEQ_NBR)),
						new SqlParameter("ACTION_CODE", SqlNull(ACTION_CODE)),
						new SqlParameter("FOLLOWUP_ACTION", SqlNull(FOLLOWUP_ACTION)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F010_CRM_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						KEY_PAT_MSTR = Reader["KEY_PAT_MSTR"].ToString();
						CLMHDR_BATCH_NBR = Reader["CLMHDR_BATCH_NBR"].ToString();
						CLMHDR_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]);
						GHOST_DATE_DESCENDING = ConvertDEC(Reader["GHOST_DATE_DESCENDING"]);
						DATE_ASSIGNED = ConvertDEC(Reader["DATE_ASSIGNED"]);
						TIME_ASSIGNED = ConvertDEC(Reader["TIME_ASSIGNED"]);
						KEY_DTL_SEQ_NBR = ConvertDEC(Reader["KEY_DTL_SEQ_NBR"]);
						ACTION_CODE = Reader["ACTION_CODE"].ToString();
						FOLLOWUP_ACTION = Reader["FOLLOWUP_ACTION"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalKey_pat_mstr = Reader["KEY_PAT_MSTR"].ToString();
						_originalClmhdr_batch_nbr = Reader["CLMHDR_BATCH_NBR"].ToString();
						_originalClmhdr_claim_nbr = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]);
						_originalGhost_date_descending = ConvertDEC(Reader["GHOST_DATE_DESCENDING"]);
						_originalDate_assigned = ConvertDEC(Reader["DATE_ASSIGNED"]);
						_originalTime_assigned = ConvertDEC(Reader["TIME_ASSIGNED"]);
						_originalKey_dtl_seq_nbr = ConvertDEC(Reader["KEY_DTL_SEQ_NBR"]);
						_originalAction_code = Reader["ACTION_CODE"].ToString();
						_originalFollowup_action = Reader["FOLLOWUP_ACTION"].ToString();
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