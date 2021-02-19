using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F002_CLAIM_SHADOW : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F002_CLAIM_SHADOW> Collection( Guid? rowid,
															decimal? clm_shadow_clinicmin,
															decimal? clm_shadow_clinicmax,
															string clm_shadow_subdivision,
															string clm_shadow_pat_key_type,
															string clm_shadow_pat_key_ohip,
															string clm_shadow_filler5,
															string clm_shadow_batch_nbr,
															decimal? clm_shadow_claim_nbrmin,
															decimal? clm_shadow_claim_nbrmax,
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
					new SqlParameter("minCLM_SHADOW_CLINIC",clm_shadow_clinicmin),
					new SqlParameter("maxCLM_SHADOW_CLINIC",clm_shadow_clinicmax),
					new SqlParameter("CLM_SHADOW_SUBDIVISION",clm_shadow_subdivision),
					new SqlParameter("CLM_SHADOW_PAT_KEY_TYPE",clm_shadow_pat_key_type),
					new SqlParameter("CLM_SHADOW_PAT_KEY_OHIP",clm_shadow_pat_key_ohip),
					new SqlParameter("CLM_SHADOW_FILLER5",clm_shadow_filler5),
					new SqlParameter("CLM_SHADOW_BATCH_NBR",clm_shadow_batch_nbr),
					new SqlParameter("minCLM_SHADOW_CLAIM_NBR",clm_shadow_claim_nbrmin),
					new SqlParameter("maxCLM_SHADOW_CLAIM_NBR",clm_shadow_claim_nbrmax),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F002_CLAIM_SHADOW_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F002_CLAIM_SHADOW>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F002_CLAIM_SHADOW_Search]", parameters);
            var collection = new ObservableCollection<F002_CLAIM_SHADOW>();

            while (Reader.Read())
            {
                collection.Add(new F002_CLAIM_SHADOW
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLM_SHADOW_CLINIC = ConvertDEC(Reader["CLM_SHADOW_CLINIC"]),
					CLM_SHADOW_SUBDIVISION = Reader["CLM_SHADOW_SUBDIVISION"].ToString(),
					CLM_SHADOW_PAT_KEY_TYPE = Reader["CLM_SHADOW_PAT_KEY_TYPE"].ToString(),
					CLM_SHADOW_PAT_KEY_OHIP = Reader["CLM_SHADOW_PAT_KEY_OHIP"].ToString(),
					CLM_SHADOW_FILLER5 = Reader["CLM_SHADOW_FILLER5"].ToString(),
					CLM_SHADOW_BATCH_NBR = Reader["CLM_SHADOW_BATCH_NBR"].ToString(),
					CLM_SHADOW_CLAIM_NBR = ConvertDEC(Reader["CLM_SHADOW_CLAIM_NBR"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClm_shadow_clinic = ConvertDEC(Reader["CLM_SHADOW_CLINIC"]),
					_originalClm_shadow_subdivision = Reader["CLM_SHADOW_SUBDIVISION"].ToString(),
					_originalClm_shadow_pat_key_type = Reader["CLM_SHADOW_PAT_KEY_TYPE"].ToString(),
					_originalClm_shadow_pat_key_ohip = Reader["CLM_SHADOW_PAT_KEY_OHIP"].ToString(),
					_originalClm_shadow_filler5 = Reader["CLM_SHADOW_FILLER5"].ToString(),
					_originalClm_shadow_batch_nbr = Reader["CLM_SHADOW_BATCH_NBR"].ToString(),
					_originalClm_shadow_claim_nbr = ConvertDEC(Reader["CLM_SHADOW_CLAIM_NBR"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F002_CLAIM_SHADOW Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F002_CLAIM_SHADOW> Collection(ObservableCollection<F002_CLAIM_SHADOW>
                                                               f002ClaimShadow = null)
        {
            if (IsSameSearch() && f002ClaimShadow != null)
            {
                return f002ClaimShadow;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F002_CLAIM_SHADOW>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("CLM_SHADOW_CLINIC",WhereClm_shadow_clinic),
					new SqlParameter("CLM_SHADOW_SUBDIVISION",WhereClm_shadow_subdivision),
					new SqlParameter("CLM_SHADOW_PAT_KEY_TYPE",WhereClm_shadow_pat_key_type),
					new SqlParameter("CLM_SHADOW_PAT_KEY_OHIP",WhereClm_shadow_pat_key_ohip),
					new SqlParameter("CLM_SHADOW_FILLER5",WhereClm_shadow_filler5),
					new SqlParameter("CLM_SHADOW_BATCH_NBR",WhereClm_shadow_batch_nbr),
					new SqlParameter("CLM_SHADOW_CLAIM_NBR",WhereClm_shadow_claim_nbr),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F002_CLAIM_SHADOW_Match]", parameters);
            var collection = new ObservableCollection<F002_CLAIM_SHADOW>();

            while (Reader.Read())
            {
                collection.Add(new F002_CLAIM_SHADOW
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLM_SHADOW_CLINIC = ConvertDEC(Reader["CLM_SHADOW_CLINIC"]),
					CLM_SHADOW_SUBDIVISION = Reader["CLM_SHADOW_SUBDIVISION"].ToString(),
					CLM_SHADOW_PAT_KEY_TYPE = Reader["CLM_SHADOW_PAT_KEY_TYPE"].ToString(),
					CLM_SHADOW_PAT_KEY_OHIP = Reader["CLM_SHADOW_PAT_KEY_OHIP"].ToString(),
					CLM_SHADOW_FILLER5 = Reader["CLM_SHADOW_FILLER5"].ToString(),
					CLM_SHADOW_BATCH_NBR = Reader["CLM_SHADOW_BATCH_NBR"].ToString(),
					CLM_SHADOW_CLAIM_NBR = ConvertDEC(Reader["CLM_SHADOW_CLAIM_NBR"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereClm_shadow_clinic = WhereClm_shadow_clinic,
					_whereClm_shadow_subdivision = WhereClm_shadow_subdivision,
					_whereClm_shadow_pat_key_type = WhereClm_shadow_pat_key_type,
					_whereClm_shadow_pat_key_ohip = WhereClm_shadow_pat_key_ohip,
					_whereClm_shadow_filler5 = WhereClm_shadow_filler5,
					_whereClm_shadow_batch_nbr = WhereClm_shadow_batch_nbr,
					_whereClm_shadow_claim_nbr = WhereClm_shadow_claim_nbr,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClm_shadow_clinic = ConvertDEC(Reader["CLM_SHADOW_CLINIC"]),
					_originalClm_shadow_subdivision = Reader["CLM_SHADOW_SUBDIVISION"].ToString(),
					_originalClm_shadow_pat_key_type = Reader["CLM_SHADOW_PAT_KEY_TYPE"].ToString(),
					_originalClm_shadow_pat_key_ohip = Reader["CLM_SHADOW_PAT_KEY_OHIP"].ToString(),
					_originalClm_shadow_filler5 = Reader["CLM_SHADOW_FILLER5"].ToString(),
					_originalClm_shadow_batch_nbr = Reader["CLM_SHADOW_BATCH_NBR"].ToString(),
					_originalClm_shadow_claim_nbr = ConvertDEC(Reader["CLM_SHADOW_CLAIM_NBR"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereClm_shadow_clinic = WhereClm_shadow_clinic;
					_whereClm_shadow_subdivision = WhereClm_shadow_subdivision;
					_whereClm_shadow_pat_key_type = WhereClm_shadow_pat_key_type;
					_whereClm_shadow_pat_key_ohip = WhereClm_shadow_pat_key_ohip;
					_whereClm_shadow_filler5 = WhereClm_shadow_filler5;
					_whereClm_shadow_batch_nbr = WhereClm_shadow_batch_nbr;
					_whereClm_shadow_claim_nbr = WhereClm_shadow_claim_nbr;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereClm_shadow_clinic == null 
				&& WhereClm_shadow_subdivision == null 
				&& WhereClm_shadow_pat_key_type == null 
				&& WhereClm_shadow_pat_key_ohip == null 
				&& WhereClm_shadow_filler5 == null 
				&& WhereClm_shadow_batch_nbr == null 
				&& WhereClm_shadow_claim_nbr == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereClm_shadow_clinic ==  _whereClm_shadow_clinic
				&& WhereClm_shadow_subdivision ==  _whereClm_shadow_subdivision
				&& WhereClm_shadow_pat_key_type ==  _whereClm_shadow_pat_key_type
				&& WhereClm_shadow_pat_key_ohip ==  _whereClm_shadow_pat_key_ohip
				&& WhereClm_shadow_filler5 ==  _whereClm_shadow_filler5
				&& WhereClm_shadow_batch_nbr ==  _whereClm_shadow_batch_nbr
				&& WhereClm_shadow_claim_nbr ==  _whereClm_shadow_claim_nbr
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereClm_shadow_clinic = null; 
			WhereClm_shadow_subdivision = null; 
			WhereClm_shadow_pat_key_type = null; 
			WhereClm_shadow_pat_key_ohip = null; 
			WhereClm_shadow_filler5 = null; 
			WhereClm_shadow_batch_nbr = null; 
			WhereClm_shadow_claim_nbr = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private decimal? _CLM_SHADOW_CLINIC;
		private string _CLM_SHADOW_SUBDIVISION;
		private string _CLM_SHADOW_PAT_KEY_TYPE;
		private string _CLM_SHADOW_PAT_KEY_OHIP;
		private string _CLM_SHADOW_FILLER5;
		private string _CLM_SHADOW_BATCH_NBR;
		private decimal? _CLM_SHADOW_CLAIM_NBR;
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
		public decimal? CLM_SHADOW_CLINIC
		{
			get { return _CLM_SHADOW_CLINIC; }
			set
			{
				if (_CLM_SHADOW_CLINIC != value)
				{
					_CLM_SHADOW_CLINIC = value;
					ChangeState();
				}
			}
		}
		public string CLM_SHADOW_SUBDIVISION
		{
			get { return _CLM_SHADOW_SUBDIVISION; }
			set
			{
				if (_CLM_SHADOW_SUBDIVISION != value)
				{
					_CLM_SHADOW_SUBDIVISION = value;
					ChangeState();
				}
			}
		}
		public string CLM_SHADOW_PAT_KEY_TYPE
		{
			get { return _CLM_SHADOW_PAT_KEY_TYPE; }
			set
			{
				if (_CLM_SHADOW_PAT_KEY_TYPE != value)
				{
					_CLM_SHADOW_PAT_KEY_TYPE = value;
					ChangeState();
				}
			}
		}
		public string CLM_SHADOW_PAT_KEY_OHIP
		{
			get { return _CLM_SHADOW_PAT_KEY_OHIP; }
			set
			{
				if (_CLM_SHADOW_PAT_KEY_OHIP != value)
				{
					_CLM_SHADOW_PAT_KEY_OHIP = value;
					ChangeState();
				}
			}
		}
		public string CLM_SHADOW_FILLER5
		{
			get { return _CLM_SHADOW_FILLER5; }
			set
			{
				if (_CLM_SHADOW_FILLER5 != value)
				{
					_CLM_SHADOW_FILLER5 = value;
					ChangeState();
				}
			}
		}
		public string CLM_SHADOW_BATCH_NBR
		{
			get { return _CLM_SHADOW_BATCH_NBR; }
			set
			{
				if (_CLM_SHADOW_BATCH_NBR != value)
				{
					_CLM_SHADOW_BATCH_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? CLM_SHADOW_CLAIM_NBR
		{
			get { return _CLM_SHADOW_CLAIM_NBR; }
			set
			{
				if (_CLM_SHADOW_CLAIM_NBR != value)
				{
					_CLM_SHADOW_CLAIM_NBR = value;
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
		public decimal? WhereClm_shadow_clinic { get; set; }
		private decimal? _whereClm_shadow_clinic;
		public string WhereClm_shadow_subdivision { get; set; }
		private string _whereClm_shadow_subdivision;
		public string WhereClm_shadow_pat_key_type { get; set; }
		private string _whereClm_shadow_pat_key_type;
		public string WhereClm_shadow_pat_key_ohip { get; set; }
		private string _whereClm_shadow_pat_key_ohip;
		public string WhereClm_shadow_filler5 { get; set; }
		private string _whereClm_shadow_filler5;
		public string WhereClm_shadow_batch_nbr { get; set; }
		private string _whereClm_shadow_batch_nbr;
		public decimal? WhereClm_shadow_claim_nbr { get; set; }
		private decimal? _whereClm_shadow_claim_nbr;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private decimal? _originalClm_shadow_clinic;
		private string _originalClm_shadow_subdivision;
		private string _originalClm_shadow_pat_key_type;
		private string _originalClm_shadow_pat_key_ohip;
		private string _originalClm_shadow_filler5;
		private string _originalClm_shadow_batch_nbr;
		private decimal? _originalClm_shadow_claim_nbr;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			CLM_SHADOW_CLINIC = _originalClm_shadow_clinic;
			CLM_SHADOW_SUBDIVISION = _originalClm_shadow_subdivision;
			CLM_SHADOW_PAT_KEY_TYPE = _originalClm_shadow_pat_key_type;
			CLM_SHADOW_PAT_KEY_OHIP = _originalClm_shadow_pat_key_ohip;
			CLM_SHADOW_FILLER5 = _originalClm_shadow_filler5;
			CLM_SHADOW_BATCH_NBR = _originalClm_shadow_batch_nbr;
			CLM_SHADOW_CLAIM_NBR = _originalClm_shadow_claim_nbr;
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
					new SqlParameter("CLM_SHADOW_CLINIC",CLM_SHADOW_CLINIC),
					new SqlParameter("CLM_SHADOW_SUBDIVISION",CLM_SHADOW_SUBDIVISION),
					new SqlParameter("CLM_SHADOW_PAT_KEY_TYPE",CLM_SHADOW_PAT_KEY_TYPE),
					new SqlParameter("CLM_SHADOW_PAT_KEY_OHIP",CLM_SHADOW_PAT_KEY_OHIP),
					new SqlParameter("CLM_SHADOW_FILLER5",CLM_SHADOW_FILLER5),
					new SqlParameter("CLM_SHADOW_BATCH_NBR",CLM_SHADOW_BATCH_NBR),
					new SqlParameter("CLM_SHADOW_CLAIM_NBR",CLM_SHADOW_CLAIM_NBR)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F002_CLAIM_SHADOW_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F002_CLAIM_SHADOW_Purge]");
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
						new SqlParameter("CLM_SHADOW_CLINIC", SqlNull(CLM_SHADOW_CLINIC)),
						new SqlParameter("CLM_SHADOW_SUBDIVISION", SqlNull(CLM_SHADOW_SUBDIVISION)),
						new SqlParameter("CLM_SHADOW_PAT_KEY_TYPE", SqlNull(CLM_SHADOW_PAT_KEY_TYPE)),
						new SqlParameter("CLM_SHADOW_PAT_KEY_OHIP", SqlNull(CLM_SHADOW_PAT_KEY_OHIP)),
						new SqlParameter("CLM_SHADOW_FILLER5", SqlNull(CLM_SHADOW_FILLER5)),
						new SqlParameter("CLM_SHADOW_BATCH_NBR", SqlNull(CLM_SHADOW_BATCH_NBR)),
						new SqlParameter("CLM_SHADOW_CLAIM_NBR", SqlNull(CLM_SHADOW_CLAIM_NBR)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F002_CLAIM_SHADOW_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLM_SHADOW_CLINIC = ConvertDEC(Reader["CLM_SHADOW_CLINIC"]);
						CLM_SHADOW_SUBDIVISION = Reader["CLM_SHADOW_SUBDIVISION"].ToString();
						CLM_SHADOW_PAT_KEY_TYPE = Reader["CLM_SHADOW_PAT_KEY_TYPE"].ToString();
						CLM_SHADOW_PAT_KEY_OHIP = Reader["CLM_SHADOW_PAT_KEY_OHIP"].ToString();
						CLM_SHADOW_FILLER5 = Reader["CLM_SHADOW_FILLER5"].ToString();
						CLM_SHADOW_BATCH_NBR = Reader["CLM_SHADOW_BATCH_NBR"].ToString();
						CLM_SHADOW_CLAIM_NBR = ConvertDEC(Reader["CLM_SHADOW_CLAIM_NBR"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClm_shadow_clinic = ConvertDEC(Reader["CLM_SHADOW_CLINIC"]);
						_originalClm_shadow_subdivision = Reader["CLM_SHADOW_SUBDIVISION"].ToString();
						_originalClm_shadow_pat_key_type = Reader["CLM_SHADOW_PAT_KEY_TYPE"].ToString();
						_originalClm_shadow_pat_key_ohip = Reader["CLM_SHADOW_PAT_KEY_OHIP"].ToString();
						_originalClm_shadow_filler5 = Reader["CLM_SHADOW_FILLER5"].ToString();
						_originalClm_shadow_batch_nbr = Reader["CLM_SHADOW_BATCH_NBR"].ToString();
						_originalClm_shadow_claim_nbr = ConvertDEC(Reader["CLM_SHADOW_CLAIM_NBR"]);
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("CLM_SHADOW_CLINIC", SqlNull(CLM_SHADOW_CLINIC)),
						new SqlParameter("CLM_SHADOW_SUBDIVISION", SqlNull(CLM_SHADOW_SUBDIVISION)),
						new SqlParameter("CLM_SHADOW_PAT_KEY_TYPE", SqlNull(CLM_SHADOW_PAT_KEY_TYPE)),
						new SqlParameter("CLM_SHADOW_PAT_KEY_OHIP", SqlNull(CLM_SHADOW_PAT_KEY_OHIP)),
						new SqlParameter("CLM_SHADOW_FILLER5", SqlNull(CLM_SHADOW_FILLER5)),
						new SqlParameter("CLM_SHADOW_BATCH_NBR", SqlNull(CLM_SHADOW_BATCH_NBR)),
						new SqlParameter("CLM_SHADOW_CLAIM_NBR", SqlNull(CLM_SHADOW_CLAIM_NBR)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F002_CLAIM_SHADOW_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLM_SHADOW_CLINIC = ConvertDEC(Reader["CLM_SHADOW_CLINIC"]);
						CLM_SHADOW_SUBDIVISION = Reader["CLM_SHADOW_SUBDIVISION"].ToString();
						CLM_SHADOW_PAT_KEY_TYPE = Reader["CLM_SHADOW_PAT_KEY_TYPE"].ToString();
						CLM_SHADOW_PAT_KEY_OHIP = Reader["CLM_SHADOW_PAT_KEY_OHIP"].ToString();
						CLM_SHADOW_FILLER5 = Reader["CLM_SHADOW_FILLER5"].ToString();
						CLM_SHADOW_BATCH_NBR = Reader["CLM_SHADOW_BATCH_NBR"].ToString();
						CLM_SHADOW_CLAIM_NBR = ConvertDEC(Reader["CLM_SHADOW_CLAIM_NBR"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClm_shadow_clinic = ConvertDEC(Reader["CLM_SHADOW_CLINIC"]);
						_originalClm_shadow_subdivision = Reader["CLM_SHADOW_SUBDIVISION"].ToString();
						_originalClm_shadow_pat_key_type = Reader["CLM_SHADOW_PAT_KEY_TYPE"].ToString();
						_originalClm_shadow_pat_key_ohip = Reader["CLM_SHADOW_PAT_KEY_OHIP"].ToString();
						_originalClm_shadow_filler5 = Reader["CLM_SHADOW_FILLER5"].ToString();
						_originalClm_shadow_batch_nbr = Reader["CLM_SHADOW_BATCH_NBR"].ToString();
						_originalClm_shadow_claim_nbr = ConvertDEC(Reader["CLM_SHADOW_CLAIM_NBR"]);
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