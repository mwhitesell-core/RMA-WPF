using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class SUBMIT_DISK_PAT_OUT : BaseTable
    {
        #region Retrieve

        public ObservableCollection<SUBMIT_DISK_PAT_OUT> Collection( Guid? rowid,
															decimal? seq_pat_doctor_nbrmin,
															decimal? seq_pat_doctor_nbrmax,
															string seq_pat_account_nbr,
															string seq_pat_i_key,
															string seq_pat_acronym,
															string seq_pat_province,
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
					new SqlParameter("minSEQ_PAT_DOCTOR_NBR",seq_pat_doctor_nbrmin),
					new SqlParameter("maxSEQ_PAT_DOCTOR_NBR",seq_pat_doctor_nbrmax),
					new SqlParameter("SEQ_PAT_ACCOUNT_NBR",seq_pat_account_nbr),
					new SqlParameter("SEQ_PAT_I_KEY",seq_pat_i_key),
					new SqlParameter("SEQ_PAT_ACRONYM",seq_pat_acronym),
					new SqlParameter("SEQ_PAT_PROVINCE",seq_pat_province),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[SEQUENTIAL].[sp_SUBMIT_DISK_PAT_OUT_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<SUBMIT_DISK_PAT_OUT>();
				}

            }

            Reader = CoreReader("[SEQUENTIAL].[sp_SUBMIT_DISK_PAT_OUT_Search]", parameters);
            var collection = new ObservableCollection<SUBMIT_DISK_PAT_OUT>();

            while (Reader.Read())
            {
                collection.Add(new SUBMIT_DISK_PAT_OUT
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					SEQ_PAT_DOCTOR_NBR = ConvertDEC(Reader["SEQ_PAT_DOCTOR_NBR"]),
					SEQ_PAT_ACCOUNT_NBR = Reader["SEQ_PAT_ACCOUNT_NBR"].ToString(),
					SEQ_PAT_I_KEY = Reader["SEQ_PAT_I_KEY"].ToString(),
					SEQ_PAT_ACRONYM = Reader["SEQ_PAT_ACRONYM"].ToString(),
					SEQ_PAT_PROVINCE = Reader["SEQ_PAT_PROVINCE"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalSeq_pat_doctor_nbr = ConvertDEC(Reader["SEQ_PAT_DOCTOR_NBR"]),
					_originalSeq_pat_account_nbr = Reader["SEQ_PAT_ACCOUNT_NBR"].ToString(),
					_originalSeq_pat_i_key = Reader["SEQ_PAT_I_KEY"].ToString(),
					_originalSeq_pat_acronym = Reader["SEQ_PAT_ACRONYM"].ToString(),
					_originalSeq_pat_province = Reader["SEQ_PAT_PROVINCE"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public SUBMIT_DISK_PAT_OUT Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<SUBMIT_DISK_PAT_OUT> Collection(ObservableCollection<SUBMIT_DISK_PAT_OUT>
                                                               submitDiskPatOut = null)
        {
            if (IsSameSearch() && submitDiskPatOut != null)
            {
                return submitDiskPatOut;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<SUBMIT_DISK_PAT_OUT>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("SEQ_PAT_DOCTOR_NBR",WhereSeq_pat_doctor_nbr),
					new SqlParameter("SEQ_PAT_ACCOUNT_NBR",WhereSeq_pat_account_nbr),
					new SqlParameter("SEQ_PAT_I_KEY",WhereSeq_pat_i_key),
					new SqlParameter("SEQ_PAT_ACRONYM",WhereSeq_pat_acronym),
					new SqlParameter("SEQ_PAT_PROVINCE",WhereSeq_pat_province),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[SEQUENTIAL].[sp_SUBMIT_DISK_PAT_OUT_Match]", parameters);
            var collection = new ObservableCollection<SUBMIT_DISK_PAT_OUT>();

            while (Reader.Read())
            {
                collection.Add(new SUBMIT_DISK_PAT_OUT
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					SEQ_PAT_DOCTOR_NBR = ConvertDEC(Reader["SEQ_PAT_DOCTOR_NBR"]),
					SEQ_PAT_ACCOUNT_NBR = Reader["SEQ_PAT_ACCOUNT_NBR"].ToString(),
					SEQ_PAT_I_KEY = Reader["SEQ_PAT_I_KEY"].ToString(),
					SEQ_PAT_ACRONYM = Reader["SEQ_PAT_ACRONYM"].ToString(),
					SEQ_PAT_PROVINCE = Reader["SEQ_PAT_PROVINCE"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereSeq_pat_doctor_nbr = WhereSeq_pat_doctor_nbr,
					_whereSeq_pat_account_nbr = WhereSeq_pat_account_nbr,
					_whereSeq_pat_i_key = WhereSeq_pat_i_key,
					_whereSeq_pat_acronym = WhereSeq_pat_acronym,
					_whereSeq_pat_province = WhereSeq_pat_province,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalSeq_pat_doctor_nbr = ConvertDEC(Reader["SEQ_PAT_DOCTOR_NBR"]),
					_originalSeq_pat_account_nbr = Reader["SEQ_PAT_ACCOUNT_NBR"].ToString(),
					_originalSeq_pat_i_key = Reader["SEQ_PAT_I_KEY"].ToString(),
					_originalSeq_pat_acronym = Reader["SEQ_PAT_ACRONYM"].ToString(),
					_originalSeq_pat_province = Reader["SEQ_PAT_PROVINCE"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereSeq_pat_doctor_nbr = WhereSeq_pat_doctor_nbr;
					_whereSeq_pat_account_nbr = WhereSeq_pat_account_nbr;
					_whereSeq_pat_i_key = WhereSeq_pat_i_key;
					_whereSeq_pat_acronym = WhereSeq_pat_acronym;
					_whereSeq_pat_province = WhereSeq_pat_province;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereSeq_pat_doctor_nbr == null 
				&& WhereSeq_pat_account_nbr == null 
				&& WhereSeq_pat_i_key == null 
				&& WhereSeq_pat_acronym == null 
				&& WhereSeq_pat_province == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereSeq_pat_doctor_nbr ==  _whereSeq_pat_doctor_nbr
				&& WhereSeq_pat_account_nbr ==  _whereSeq_pat_account_nbr
				&& WhereSeq_pat_i_key ==  _whereSeq_pat_i_key
				&& WhereSeq_pat_acronym ==  _whereSeq_pat_acronym
				&& WhereSeq_pat_province ==  _whereSeq_pat_province
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereSeq_pat_doctor_nbr = null; 
			WhereSeq_pat_account_nbr = null; 
			WhereSeq_pat_i_key = null; 
			WhereSeq_pat_acronym = null; 
			WhereSeq_pat_province = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private decimal? _SEQ_PAT_DOCTOR_NBR;
		private string _SEQ_PAT_ACCOUNT_NBR;
		private string _SEQ_PAT_I_KEY;
		private string _SEQ_PAT_ACRONYM;
		private string _SEQ_PAT_PROVINCE;
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
		public decimal? SEQ_PAT_DOCTOR_NBR
		{
			get { return _SEQ_PAT_DOCTOR_NBR; }
			set
			{
				if (_SEQ_PAT_DOCTOR_NBR != value)
				{
					_SEQ_PAT_DOCTOR_NBR = value;
					ChangeState();
				}
			}
		}
		public string SEQ_PAT_ACCOUNT_NBR
		{
			get { return _SEQ_PAT_ACCOUNT_NBR; }
			set
			{
				if (_SEQ_PAT_ACCOUNT_NBR != value)
				{
					_SEQ_PAT_ACCOUNT_NBR = value;
					ChangeState();
				}
			}
		}
		public string SEQ_PAT_I_KEY
		{
			get { return _SEQ_PAT_I_KEY; }
			set
			{
				if (_SEQ_PAT_I_KEY != value)
				{
					_SEQ_PAT_I_KEY = value;
					ChangeState();
				}
			}
		}
		public string SEQ_PAT_ACRONYM
		{
			get { return _SEQ_PAT_ACRONYM; }
			set
			{
				if (_SEQ_PAT_ACRONYM != value)
				{
					_SEQ_PAT_ACRONYM = value;
					ChangeState();
				}
			}
		}
		public string SEQ_PAT_PROVINCE
		{
			get { return _SEQ_PAT_PROVINCE; }
			set
			{
				if (_SEQ_PAT_PROVINCE != value)
				{
					_SEQ_PAT_PROVINCE = value;
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
		public decimal? WhereSeq_pat_doctor_nbr { get; set; }
		private decimal? _whereSeq_pat_doctor_nbr;
		public string WhereSeq_pat_account_nbr { get; set; }
		private string _whereSeq_pat_account_nbr;
		public string WhereSeq_pat_i_key { get; set; }
		private string _whereSeq_pat_i_key;
		public string WhereSeq_pat_acronym { get; set; }
		private string _whereSeq_pat_acronym;
		public string WhereSeq_pat_province { get; set; }
		private string _whereSeq_pat_province;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private decimal? _originalSeq_pat_doctor_nbr;
		private string _originalSeq_pat_account_nbr;
		private string _originalSeq_pat_i_key;
		private string _originalSeq_pat_acronym;
		private string _originalSeq_pat_province;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			SEQ_PAT_DOCTOR_NBR = _originalSeq_pat_doctor_nbr;
			SEQ_PAT_ACCOUNT_NBR = _originalSeq_pat_account_nbr;
			SEQ_PAT_I_KEY = _originalSeq_pat_i_key;
			SEQ_PAT_ACRONYM = _originalSeq_pat_acronym;
			SEQ_PAT_PROVINCE = _originalSeq_pat_province;
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
			RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_SUBMIT_DISK_PAT_OUT_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_SUBMIT_DISK_PAT_OUT_Purge]");
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
						new SqlParameter("SEQ_PAT_DOCTOR_NBR", SqlNull(SEQ_PAT_DOCTOR_NBR)),
						new SqlParameter("SEQ_PAT_ACCOUNT_NBR", SqlNull(SEQ_PAT_ACCOUNT_NBR)),
						new SqlParameter("SEQ_PAT_I_KEY", SqlNull(SEQ_PAT_I_KEY)),
						new SqlParameter("SEQ_PAT_ACRONYM", SqlNull(SEQ_PAT_ACRONYM)),
						new SqlParameter("SEQ_PAT_PROVINCE", SqlNull(SEQ_PAT_PROVINCE)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_SUBMIT_DISK_PAT_OUT_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						SEQ_PAT_DOCTOR_NBR = ConvertDEC(Reader["SEQ_PAT_DOCTOR_NBR"]);
						SEQ_PAT_ACCOUNT_NBR = Reader["SEQ_PAT_ACCOUNT_NBR"].ToString();
						SEQ_PAT_I_KEY = Reader["SEQ_PAT_I_KEY"].ToString();
						SEQ_PAT_ACRONYM = Reader["SEQ_PAT_ACRONYM"].ToString();
						SEQ_PAT_PROVINCE = Reader["SEQ_PAT_PROVINCE"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalSeq_pat_doctor_nbr = ConvertDEC(Reader["SEQ_PAT_DOCTOR_NBR"]);
						_originalSeq_pat_account_nbr = Reader["SEQ_PAT_ACCOUNT_NBR"].ToString();
						_originalSeq_pat_i_key = Reader["SEQ_PAT_I_KEY"].ToString();
						_originalSeq_pat_acronym = Reader["SEQ_PAT_ACRONYM"].ToString();
						_originalSeq_pat_province = Reader["SEQ_PAT_PROVINCE"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("SEQ_PAT_DOCTOR_NBR", SqlNull(SEQ_PAT_DOCTOR_NBR)),
						new SqlParameter("SEQ_PAT_ACCOUNT_NBR", SqlNull(SEQ_PAT_ACCOUNT_NBR)),
						new SqlParameter("SEQ_PAT_I_KEY", SqlNull(SEQ_PAT_I_KEY)),
						new SqlParameter("SEQ_PAT_ACRONYM", SqlNull(SEQ_PAT_ACRONYM)),
						new SqlParameter("SEQ_PAT_PROVINCE", SqlNull(SEQ_PAT_PROVINCE)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_SUBMIT_DISK_PAT_OUT_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						SEQ_PAT_DOCTOR_NBR = ConvertDEC(Reader["SEQ_PAT_DOCTOR_NBR"]);
						SEQ_PAT_ACCOUNT_NBR = Reader["SEQ_PAT_ACCOUNT_NBR"].ToString();
						SEQ_PAT_I_KEY = Reader["SEQ_PAT_I_KEY"].ToString();
						SEQ_PAT_ACRONYM = Reader["SEQ_PAT_ACRONYM"].ToString();
						SEQ_PAT_PROVINCE = Reader["SEQ_PAT_PROVINCE"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalSeq_pat_doctor_nbr = ConvertDEC(Reader["SEQ_PAT_DOCTOR_NBR"]);
						_originalSeq_pat_account_nbr = Reader["SEQ_PAT_ACCOUNT_NBR"].ToString();
						_originalSeq_pat_i_key = Reader["SEQ_PAT_I_KEY"].ToString();
						_originalSeq_pat_acronym = Reader["SEQ_PAT_ACRONYM"].ToString();
						_originalSeq_pat_province = Reader["SEQ_PAT_PROVINCE"].ToString();
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