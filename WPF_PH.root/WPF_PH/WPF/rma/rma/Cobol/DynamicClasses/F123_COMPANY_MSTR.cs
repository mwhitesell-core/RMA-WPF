using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F123_COMPANY_MSTR : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F123_COMPANY_MSTR> Collection( Guid? rowid,
															decimal? company_nbrmin,
															decimal? company_nbrmax,
															string company_name,
															decimal? bank_nbrmin,
															decimal? bank_nbrmax,
															decimal? bank_branchmin,
															decimal? bank_branchmax,
															string bank_account_nbr,
															string filler_7,
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
					new SqlParameter("minCOMPANY_NBR",company_nbrmin),
					new SqlParameter("maxCOMPANY_NBR",company_nbrmax),
					new SqlParameter("COMPANY_NAME",company_name),
					new SqlParameter("minBANK_NBR",bank_nbrmin),
					new SqlParameter("maxBANK_NBR",bank_nbrmax),
					new SqlParameter("minBANK_BRANCH",bank_branchmin),
					new SqlParameter("maxBANK_BRANCH",bank_branchmax),
					new SqlParameter("BANK_ACCOUNT_NBR",bank_account_nbr),
					new SqlParameter("FILLER_7",filler_7),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F123_COMPANY_MSTR_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F123_COMPANY_MSTR>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F123_COMPANY_MSTR_Search]", parameters);
            var collection = new ObservableCollection<F123_COMPANY_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F123_COMPANY_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					COMPANY_NBR = ConvertDEC(Reader["COMPANY_NBR"]),
					COMPANY_NAME = Reader["COMPANY_NAME"].ToString(),
					BANK_NBR = ConvertDEC(Reader["BANK_NBR"]),
					BANK_BRANCH = ConvertDEC(Reader["BANK_BRANCH"]),
					BANK_ACCOUNT_NBR = Reader["BANK_ACCOUNT_NBR"].ToString(),
					FILLER_7 = Reader["FILLER_7"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalCompany_nbr = ConvertDEC(Reader["COMPANY_NBR"]),
					_originalCompany_name = Reader["COMPANY_NAME"].ToString(),
					_originalBank_nbr = ConvertDEC(Reader["BANK_NBR"]),
					_originalBank_branch = ConvertDEC(Reader["BANK_BRANCH"]),
					_originalBank_account_nbr = Reader["BANK_ACCOUNT_NBR"].ToString(),
					_originalFiller_7 = Reader["FILLER_7"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F123_COMPANY_MSTR Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F123_COMPANY_MSTR> Collection(ObservableCollection<F123_COMPANY_MSTR>
                                                               f123CompanyMstr = null)
        {
            if (IsSameSearch() && f123CompanyMstr != null)
            {
                return f123CompanyMstr;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F123_COMPANY_MSTR>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("COMPANY_NBR",WhereCompany_nbr),
					new SqlParameter("COMPANY_NAME",WhereCompany_name),
					new SqlParameter("BANK_NBR",WhereBank_nbr),
					new SqlParameter("BANK_BRANCH",WhereBank_branch),
					new SqlParameter("BANK_ACCOUNT_NBR",WhereBank_account_nbr),
					new SqlParameter("FILLER_7",WhereFiller_7),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F123_COMPANY_MSTR_Match]", parameters);
            var collection = new ObservableCollection<F123_COMPANY_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F123_COMPANY_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					COMPANY_NBR = ConvertDEC(Reader["COMPANY_NBR"]),
					COMPANY_NAME = Reader["COMPANY_NAME"].ToString(),
					BANK_NBR = ConvertDEC(Reader["BANK_NBR"]),
					BANK_BRANCH = ConvertDEC(Reader["BANK_BRANCH"]),
					BANK_ACCOUNT_NBR = Reader["BANK_ACCOUNT_NBR"].ToString(),
					FILLER_7 = Reader["FILLER_7"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereCompany_nbr = WhereCompany_nbr,
					_whereCompany_name = WhereCompany_name,
					_whereBank_nbr = WhereBank_nbr,
					_whereBank_branch = WhereBank_branch,
					_whereBank_account_nbr = WhereBank_account_nbr,
					_whereFiller_7 = WhereFiller_7,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalCompany_nbr = ConvertDEC(Reader["COMPANY_NBR"]),
					_originalCompany_name = Reader["COMPANY_NAME"].ToString(),
					_originalBank_nbr = ConvertDEC(Reader["BANK_NBR"]),
					_originalBank_branch = ConvertDEC(Reader["BANK_BRANCH"]),
					_originalBank_account_nbr = Reader["BANK_ACCOUNT_NBR"].ToString(),
					_originalFiller_7 = Reader["FILLER_7"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereCompany_nbr = WhereCompany_nbr;
					_whereCompany_name = WhereCompany_name;
					_whereBank_nbr = WhereBank_nbr;
					_whereBank_branch = WhereBank_branch;
					_whereBank_account_nbr = WhereBank_account_nbr;
					_whereFiller_7 = WhereFiller_7;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereCompany_nbr == null 
				&& WhereCompany_name == null 
				&& WhereBank_nbr == null 
				&& WhereBank_branch == null 
				&& WhereBank_account_nbr == null 
				&& WhereFiller_7 == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereCompany_nbr ==  _whereCompany_nbr
				&& WhereCompany_name ==  _whereCompany_name
				&& WhereBank_nbr ==  _whereBank_nbr
				&& WhereBank_branch ==  _whereBank_branch
				&& WhereBank_account_nbr ==  _whereBank_account_nbr
				&& WhereFiller_7 ==  _whereFiller_7
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereCompany_nbr = null; 
			WhereCompany_name = null; 
			WhereBank_nbr = null; 
			WhereBank_branch = null; 
			WhereBank_account_nbr = null; 
			WhereFiller_7 = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private decimal? _COMPANY_NBR;
		private string _COMPANY_NAME;
		private decimal? _BANK_NBR;
		private decimal? _BANK_BRANCH;
		private string _BANK_ACCOUNT_NBR;
		private string _FILLER_7;
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
		public decimal? COMPANY_NBR
		{
			get { return _COMPANY_NBR; }
			set
			{
				if (_COMPANY_NBR != value)
				{
					_COMPANY_NBR = value;
					ChangeState();
				}
			}
		}
		public string COMPANY_NAME
		{
			get { return _COMPANY_NAME; }
			set
			{
				if (_COMPANY_NAME != value)
				{
					_COMPANY_NAME = value;
					ChangeState();
				}
			}
		}
		public decimal? BANK_NBR
		{
			get { return _BANK_NBR; }
			set
			{
				if (_BANK_NBR != value)
				{
					_BANK_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? BANK_BRANCH
		{
			get { return _BANK_BRANCH; }
			set
			{
				if (_BANK_BRANCH != value)
				{
					_BANK_BRANCH = value;
					ChangeState();
				}
			}
		}
		public string BANK_ACCOUNT_NBR
		{
			get { return _BANK_ACCOUNT_NBR; }
			set
			{
				if (_BANK_ACCOUNT_NBR != value)
				{
					_BANK_ACCOUNT_NBR = value;
					ChangeState();
				}
			}
		}
		public string FILLER_7
		{
			get { return _FILLER_7; }
			set
			{
				if (_FILLER_7 != value)
				{
					_FILLER_7 = value;
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
		public decimal? WhereCompany_nbr { get; set; }
		private decimal? _whereCompany_nbr;
		public string WhereCompany_name { get; set; }
		private string _whereCompany_name;
		public decimal? WhereBank_nbr { get; set; }
		private decimal? _whereBank_nbr;
		public decimal? WhereBank_branch { get; set; }
		private decimal? _whereBank_branch;
		public string WhereBank_account_nbr { get; set; }
		private string _whereBank_account_nbr;
		public string WhereFiller_7 { get; set; }
		private string _whereFiller_7;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private decimal? _originalCompany_nbr;
		private string _originalCompany_name;
		private decimal? _originalBank_nbr;
		private decimal? _originalBank_branch;
		private string _originalBank_account_nbr;
		private string _originalFiller_7;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			COMPANY_NBR = _originalCompany_nbr;
			COMPANY_NAME = _originalCompany_name;
			BANK_NBR = _originalBank_nbr;
			BANK_BRANCH = _originalBank_branch;
			BANK_ACCOUNT_NBR = _originalBank_account_nbr;
			FILLER_7 = _originalFiller_7;
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
					new SqlParameter("COMPANY_NBR",COMPANY_NBR)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F123_COMPANY_MSTR_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F123_COMPANY_MSTR_Purge]");
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
						new SqlParameter("COMPANY_NBR", SqlNull(COMPANY_NBR)),
						new SqlParameter("COMPANY_NAME", SqlNull(COMPANY_NAME)),
						new SqlParameter("BANK_NBR", SqlNull(BANK_NBR)),
						new SqlParameter("BANK_BRANCH", SqlNull(BANK_BRANCH)),
						new SqlParameter("BANK_ACCOUNT_NBR", SqlNull(BANK_ACCOUNT_NBR)),
						new SqlParameter("FILLER_7", SqlNull(FILLER_7)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F123_COMPANY_MSTR_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						COMPANY_NBR = ConvertDEC(Reader["COMPANY_NBR"]);
						COMPANY_NAME = Reader["COMPANY_NAME"].ToString();
						BANK_NBR = ConvertDEC(Reader["BANK_NBR"]);
						BANK_BRANCH = ConvertDEC(Reader["BANK_BRANCH"]);
						BANK_ACCOUNT_NBR = Reader["BANK_ACCOUNT_NBR"].ToString();
						FILLER_7 = Reader["FILLER_7"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalCompany_nbr = ConvertDEC(Reader["COMPANY_NBR"]);
						_originalCompany_name = Reader["COMPANY_NAME"].ToString();
						_originalBank_nbr = ConvertDEC(Reader["BANK_NBR"]);
						_originalBank_branch = ConvertDEC(Reader["BANK_BRANCH"]);
						_originalBank_account_nbr = Reader["BANK_ACCOUNT_NBR"].ToString();
						_originalFiller_7 = Reader["FILLER_7"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("COMPANY_NBR", SqlNull(COMPANY_NBR)),
						new SqlParameter("COMPANY_NAME", SqlNull(COMPANY_NAME)),
						new SqlParameter("BANK_NBR", SqlNull(BANK_NBR)),
						new SqlParameter("BANK_BRANCH", SqlNull(BANK_BRANCH)),
						new SqlParameter("BANK_ACCOUNT_NBR", SqlNull(BANK_ACCOUNT_NBR)),
						new SqlParameter("FILLER_7", SqlNull(FILLER_7)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F123_COMPANY_MSTR_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						COMPANY_NBR = ConvertDEC(Reader["COMPANY_NBR"]);
						COMPANY_NAME = Reader["COMPANY_NAME"].ToString();
						BANK_NBR = ConvertDEC(Reader["BANK_NBR"]);
						BANK_BRANCH = ConvertDEC(Reader["BANK_BRANCH"]);
						BANK_ACCOUNT_NBR = Reader["BANK_ACCOUNT_NBR"].ToString();
						FILLER_7 = Reader["FILLER_7"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalCompany_nbr = ConvertDEC(Reader["COMPANY_NBR"]);
						_originalCompany_name = Reader["COMPANY_NAME"].ToString();
						_originalBank_nbr = ConvertDEC(Reader["BANK_NBR"]);
						_originalBank_branch = ConvertDEC(Reader["BANK_BRANCH"]);
						_originalBank_account_nbr = Reader["BANK_ACCOUNT_NBR"].ToString();
						_originalFiller_7 = Reader["FILLER_7"].ToString();
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