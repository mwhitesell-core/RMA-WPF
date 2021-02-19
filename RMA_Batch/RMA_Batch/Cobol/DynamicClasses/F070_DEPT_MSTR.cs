using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F070_DEPT_MSTR : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F070_DEPT_MSTR> Collection( Guid? rowid,
															decimal? dept_nbrmin,
															decimal? dept_nbrmax,
															string dept_name,
															string dept_addr1,
															string dept_addr2,
															string dept_addr3,
															string dept_chairman,
															string dept_co_ordinator,
															decimal? dept_nbr_docsmin,
															decimal? dept_nbr_docsmax,
															decimal? dept_companymin,
															decimal? dept_companymax,
															string filler,
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
					new SqlParameter("minDEPT_NBR",dept_nbrmin),
					new SqlParameter("maxDEPT_NBR",dept_nbrmax),
					new SqlParameter("DEPT_NAME",dept_name),
					new SqlParameter("DEPT_ADDR1",dept_addr1),
					new SqlParameter("DEPT_ADDR2",dept_addr2),
					new SqlParameter("DEPT_ADDR3",dept_addr3),
					new SqlParameter("DEPT_CHAIRMAN",dept_chairman),
					new SqlParameter("DEPT_CO_ORDINATOR",dept_co_ordinator),
					new SqlParameter("minDEPT_NBR_DOCS",dept_nbr_docsmin),
					new SqlParameter("maxDEPT_NBR_DOCS",dept_nbr_docsmax),
					new SqlParameter("minDEPT_COMPANY",dept_companymin),
					new SqlParameter("maxDEPT_COMPANY",dept_companymax),
					new SqlParameter("FILLER",filler),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F070_DEPT_MSTR_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F070_DEPT_MSTR>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F070_DEPT_MSTR_Search]", parameters);
            var collection = new ObservableCollection<F070_DEPT_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F070_DEPT_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DEPT_NBR = ConvertDEC(Reader["DEPT_NBR"]),
					DEPT_NAME = Reader["DEPT_NAME"].ToString(),
					DEPT_ADDR1 = Reader["DEPT_ADDR1"].ToString(),
					DEPT_ADDR2 = Reader["DEPT_ADDR2"].ToString(),
					DEPT_ADDR3 = Reader["DEPT_ADDR3"].ToString(),
					DEPT_CHAIRMAN = Reader["DEPT_CHAIRMAN"].ToString(),
					DEPT_CO_ORDINATOR = Reader["DEPT_CO_ORDINATOR"].ToString(),
					DEPT_NBR_DOCS = ConvertDEC(Reader["DEPT_NBR_DOCS"]),
					DEPT_COMPANY = ConvertDEC(Reader["DEPT_COMPANY"]),
					FILLER = Reader["FILLER"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDept_nbr = ConvertDEC(Reader["DEPT_NBR"]),
					_originalDept_name = Reader["DEPT_NAME"].ToString(),
					_originalDept_addr1 = Reader["DEPT_ADDR1"].ToString(),
					_originalDept_addr2 = Reader["DEPT_ADDR2"].ToString(),
					_originalDept_addr3 = Reader["DEPT_ADDR3"].ToString(),
					_originalDept_chairman = Reader["DEPT_CHAIRMAN"].ToString(),
					_originalDept_co_ordinator = Reader["DEPT_CO_ORDINATOR"].ToString(),
					_originalDept_nbr_docs = ConvertDEC(Reader["DEPT_NBR_DOCS"]),
					_originalDept_company = ConvertDEC(Reader["DEPT_COMPANY"]),
					_originalFiller = Reader["FILLER"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F070_DEPT_MSTR Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F070_DEPT_MSTR> Collection(ObservableCollection<F070_DEPT_MSTR>
                                                               f070DeptMstr = null)
        {
            if (IsSameSearch() && f070DeptMstr != null)
            {
                return f070DeptMstr;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F070_DEPT_MSTR>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("DEPT_NBR",WhereDept_nbr),
					new SqlParameter("DEPT_NAME",WhereDept_name),
					new SqlParameter("DEPT_ADDR1",WhereDept_addr1),
					new SqlParameter("DEPT_ADDR2",WhereDept_addr2),
					new SqlParameter("DEPT_ADDR3",WhereDept_addr3),
					new SqlParameter("DEPT_CHAIRMAN",WhereDept_chairman),
					new SqlParameter("DEPT_CO_ORDINATOR",WhereDept_co_ordinator),
					new SqlParameter("DEPT_NBR_DOCS",WhereDept_nbr_docs),
					new SqlParameter("DEPT_COMPANY",WhereDept_company),
					new SqlParameter("FILLER",WhereFiller),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F070_DEPT_MSTR_Match]", parameters);
            var collection = new ObservableCollection<F070_DEPT_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F070_DEPT_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DEPT_NBR = ConvertDEC(Reader["DEPT_NBR"]),
					DEPT_NAME = Reader["DEPT_NAME"].ToString(),
					DEPT_ADDR1 = Reader["DEPT_ADDR1"].ToString(),
					DEPT_ADDR2 = Reader["DEPT_ADDR2"].ToString(),
					DEPT_ADDR3 = Reader["DEPT_ADDR3"].ToString(),
					DEPT_CHAIRMAN = Reader["DEPT_CHAIRMAN"].ToString(),
					DEPT_CO_ORDINATOR = Reader["DEPT_CO_ORDINATOR"].ToString(),
					DEPT_NBR_DOCS = ConvertDEC(Reader["DEPT_NBR_DOCS"]),
					DEPT_COMPANY = ConvertDEC(Reader["DEPT_COMPANY"]),
					FILLER = Reader["FILLER"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereDept_nbr = WhereDept_nbr,
					_whereDept_name = WhereDept_name,
					_whereDept_addr1 = WhereDept_addr1,
					_whereDept_addr2 = WhereDept_addr2,
					_whereDept_addr3 = WhereDept_addr3,
					_whereDept_chairman = WhereDept_chairman,
					_whereDept_co_ordinator = WhereDept_co_ordinator,
					_whereDept_nbr_docs = WhereDept_nbr_docs,
					_whereDept_company = WhereDept_company,
					_whereFiller = WhereFiller,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDept_nbr = ConvertDEC(Reader["DEPT_NBR"]),
					_originalDept_name = Reader["DEPT_NAME"].ToString(),
					_originalDept_addr1 = Reader["DEPT_ADDR1"].ToString(),
					_originalDept_addr2 = Reader["DEPT_ADDR2"].ToString(),
					_originalDept_addr3 = Reader["DEPT_ADDR3"].ToString(),
					_originalDept_chairman = Reader["DEPT_CHAIRMAN"].ToString(),
					_originalDept_co_ordinator = Reader["DEPT_CO_ORDINATOR"].ToString(),
					_originalDept_nbr_docs = ConvertDEC(Reader["DEPT_NBR_DOCS"]),
					_originalDept_company = ConvertDEC(Reader["DEPT_COMPANY"]),
					_originalFiller = Reader["FILLER"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereDept_nbr = WhereDept_nbr;
					_whereDept_name = WhereDept_name;
					_whereDept_addr1 = WhereDept_addr1;
					_whereDept_addr2 = WhereDept_addr2;
					_whereDept_addr3 = WhereDept_addr3;
					_whereDept_chairman = WhereDept_chairman;
					_whereDept_co_ordinator = WhereDept_co_ordinator;
					_whereDept_nbr_docs = WhereDept_nbr_docs;
					_whereDept_company = WhereDept_company;
					_whereFiller = WhereFiller;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereDept_nbr == null 
				&& WhereDept_name == null 
				&& WhereDept_addr1 == null 
				&& WhereDept_addr2 == null 
				&& WhereDept_addr3 == null 
				&& WhereDept_chairman == null 
				&& WhereDept_co_ordinator == null 
				&& WhereDept_nbr_docs == null 
				&& WhereDept_company == null 
				&& WhereFiller == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereDept_nbr ==  _whereDept_nbr
				&& WhereDept_name ==  _whereDept_name
				&& WhereDept_addr1 ==  _whereDept_addr1
				&& WhereDept_addr2 ==  _whereDept_addr2
				&& WhereDept_addr3 ==  _whereDept_addr3
				&& WhereDept_chairman ==  _whereDept_chairman
				&& WhereDept_co_ordinator ==  _whereDept_co_ordinator
				&& WhereDept_nbr_docs ==  _whereDept_nbr_docs
				&& WhereDept_company ==  _whereDept_company
				&& WhereFiller ==  _whereFiller
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereDept_nbr = null; 
			WhereDept_name = null; 
			WhereDept_addr1 = null; 
			WhereDept_addr2 = null; 
			WhereDept_addr3 = null; 
			WhereDept_chairman = null; 
			WhereDept_co_ordinator = null; 
			WhereDept_nbr_docs = null; 
			WhereDept_company = null; 
			WhereFiller = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private decimal? _DEPT_NBR;
		private string _DEPT_NAME;
		private string _DEPT_ADDR1;
		private string _DEPT_ADDR2;
		private string _DEPT_ADDR3;
		private string _DEPT_CHAIRMAN;
		private string _DEPT_CO_ORDINATOR;
		private decimal? _DEPT_NBR_DOCS;
		private decimal? _DEPT_COMPANY;
		private string _FILLER;
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
		public decimal? DEPT_NBR
		{
			get { return _DEPT_NBR; }
			set
			{
				if (_DEPT_NBR != value)
				{
					_DEPT_NBR = value;
					ChangeState();
				}
			}
		}
		public string DEPT_NAME
		{
			get { return _DEPT_NAME; }
			set
			{
				if (_DEPT_NAME != value)
				{
					_DEPT_NAME = value;
					ChangeState();
				}
			}
		}
		public string DEPT_ADDR1
		{
			get { return _DEPT_ADDR1; }
			set
			{
				if (_DEPT_ADDR1 != value)
				{
					_DEPT_ADDR1 = value;
					ChangeState();
				}
			}
		}
		public string DEPT_ADDR2
		{
			get { return _DEPT_ADDR2; }
			set
			{
				if (_DEPT_ADDR2 != value)
				{
					_DEPT_ADDR2 = value;
					ChangeState();
				}
			}
		}
		public string DEPT_ADDR3
		{
			get { return _DEPT_ADDR3; }
			set
			{
				if (_DEPT_ADDR3 != value)
				{
					_DEPT_ADDR3 = value;
					ChangeState();
				}
			}
		}
		public string DEPT_CHAIRMAN
		{
			get { return _DEPT_CHAIRMAN; }
			set
			{
				if (_DEPT_CHAIRMAN != value)
				{
					_DEPT_CHAIRMAN = value;
					ChangeState();
				}
			}
		}
		public string DEPT_CO_ORDINATOR
		{
			get { return _DEPT_CO_ORDINATOR; }
			set
			{
				if (_DEPT_CO_ORDINATOR != value)
				{
					_DEPT_CO_ORDINATOR = value;
					ChangeState();
				}
			}
		}
		public decimal? DEPT_NBR_DOCS
		{
			get { return _DEPT_NBR_DOCS; }
			set
			{
				if (_DEPT_NBR_DOCS != value)
				{
					_DEPT_NBR_DOCS = value;
					ChangeState();
				}
			}
		}
		public decimal? DEPT_COMPANY
		{
			get { return _DEPT_COMPANY; }
			set
			{
				if (_DEPT_COMPANY != value)
				{
					_DEPT_COMPANY = value;
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
		public decimal? WhereDept_nbr { get; set; }
		private decimal? _whereDept_nbr;
		public string WhereDept_name { get; set; }
		private string _whereDept_name;
		public string WhereDept_addr1 { get; set; }
		private string _whereDept_addr1;
		public string WhereDept_addr2 { get; set; }
		private string _whereDept_addr2;
		public string WhereDept_addr3 { get; set; }
		private string _whereDept_addr3;
		public string WhereDept_chairman { get; set; }
		private string _whereDept_chairman;
		public string WhereDept_co_ordinator { get; set; }
		private string _whereDept_co_ordinator;
		public decimal? WhereDept_nbr_docs { get; set; }
		private decimal? _whereDept_nbr_docs;
		public decimal? WhereDept_company { get; set; }
		private decimal? _whereDept_company;
		public string WhereFiller { get; set; }
		private string _whereFiller;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private decimal? _originalDept_nbr;
		private string _originalDept_name;
		private string _originalDept_addr1;
		private string _originalDept_addr2;
		private string _originalDept_addr3;
		private string _originalDept_chairman;
		private string _originalDept_co_ordinator;
		private decimal? _originalDept_nbr_docs;
		private decimal? _originalDept_company;
		private string _originalFiller;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			DEPT_NBR = _originalDept_nbr;
			DEPT_NAME = _originalDept_name;
			DEPT_ADDR1 = _originalDept_addr1;
			DEPT_ADDR2 = _originalDept_addr2;
			DEPT_ADDR3 = _originalDept_addr3;
			DEPT_CHAIRMAN = _originalDept_chairman;
			DEPT_CO_ORDINATOR = _originalDept_co_ordinator;
			DEPT_NBR_DOCS = _originalDept_nbr_docs;
			DEPT_COMPANY = _originalDept_company;
			FILLER = _originalFiller;
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
					new SqlParameter("DEPT_NBR",DEPT_NBR)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F070_DEPT_MSTR_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F070_DEPT_MSTR_Purge]");
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
						new SqlParameter("DEPT_NBR", SqlNull(DEPT_NBR)),
						new SqlParameter("DEPT_NAME", SqlNull(DEPT_NAME)),
						new SqlParameter("DEPT_ADDR1", SqlNull(DEPT_ADDR1)),
						new SqlParameter("DEPT_ADDR2", SqlNull(DEPT_ADDR2)),
						new SqlParameter("DEPT_ADDR3", SqlNull(DEPT_ADDR3)),
						new SqlParameter("DEPT_CHAIRMAN", SqlNull(DEPT_CHAIRMAN)),
						new SqlParameter("DEPT_CO_ORDINATOR", SqlNull(DEPT_CO_ORDINATOR)),
						new SqlParameter("DEPT_NBR_DOCS", SqlNull(DEPT_NBR_DOCS)),
						new SqlParameter("DEPT_COMPANY", SqlNull(DEPT_COMPANY)),
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F070_DEPT_MSTR_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DEPT_NBR = ConvertDEC(Reader["DEPT_NBR"]);
						DEPT_NAME = Reader["DEPT_NAME"].ToString();
						DEPT_ADDR1 = Reader["DEPT_ADDR1"].ToString();
						DEPT_ADDR2 = Reader["DEPT_ADDR2"].ToString();
						DEPT_ADDR3 = Reader["DEPT_ADDR3"].ToString();
						DEPT_CHAIRMAN = Reader["DEPT_CHAIRMAN"].ToString();
						DEPT_CO_ORDINATOR = Reader["DEPT_CO_ORDINATOR"].ToString();
						DEPT_NBR_DOCS = ConvertDEC(Reader["DEPT_NBR_DOCS"]);
						DEPT_COMPANY = ConvertDEC(Reader["DEPT_COMPANY"]);
						FILLER = Reader["FILLER"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDept_nbr = ConvertDEC(Reader["DEPT_NBR"]);
						_originalDept_name = Reader["DEPT_NAME"].ToString();
						_originalDept_addr1 = Reader["DEPT_ADDR1"].ToString();
						_originalDept_addr2 = Reader["DEPT_ADDR2"].ToString();
						_originalDept_addr3 = Reader["DEPT_ADDR3"].ToString();
						_originalDept_chairman = Reader["DEPT_CHAIRMAN"].ToString();
						_originalDept_co_ordinator = Reader["DEPT_CO_ORDINATOR"].ToString();
						_originalDept_nbr_docs = ConvertDEC(Reader["DEPT_NBR_DOCS"]);
						_originalDept_company = ConvertDEC(Reader["DEPT_COMPANY"]);
						_originalFiller = Reader["FILLER"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("DEPT_NBR", SqlNull(DEPT_NBR)),
						new SqlParameter("DEPT_NAME", SqlNull(DEPT_NAME)),
						new SqlParameter("DEPT_ADDR1", SqlNull(DEPT_ADDR1)),
						new SqlParameter("DEPT_ADDR2", SqlNull(DEPT_ADDR2)),
						new SqlParameter("DEPT_ADDR3", SqlNull(DEPT_ADDR3)),
						new SqlParameter("DEPT_CHAIRMAN", SqlNull(DEPT_CHAIRMAN)),
						new SqlParameter("DEPT_CO_ORDINATOR", SqlNull(DEPT_CO_ORDINATOR)),
						new SqlParameter("DEPT_NBR_DOCS", SqlNull(DEPT_NBR_DOCS)),
						new SqlParameter("DEPT_COMPANY", SqlNull(DEPT_COMPANY)),
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F070_DEPT_MSTR_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DEPT_NBR = ConvertDEC(Reader["DEPT_NBR"]);
						DEPT_NAME = Reader["DEPT_NAME"].ToString();
						DEPT_ADDR1 = Reader["DEPT_ADDR1"].ToString();
						DEPT_ADDR2 = Reader["DEPT_ADDR2"].ToString();
						DEPT_ADDR3 = Reader["DEPT_ADDR3"].ToString();
						DEPT_CHAIRMAN = Reader["DEPT_CHAIRMAN"].ToString();
						DEPT_CO_ORDINATOR = Reader["DEPT_CO_ORDINATOR"].ToString();
						DEPT_NBR_DOCS = ConvertDEC(Reader["DEPT_NBR_DOCS"]);
						DEPT_COMPANY = ConvertDEC(Reader["DEPT_COMPANY"]);
						FILLER = Reader["FILLER"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDept_nbr = ConvertDEC(Reader["DEPT_NBR"]);
						_originalDept_name = Reader["DEPT_NAME"].ToString();
						_originalDept_addr1 = Reader["DEPT_ADDR1"].ToString();
						_originalDept_addr2 = Reader["DEPT_ADDR2"].ToString();
						_originalDept_addr3 = Reader["DEPT_ADDR3"].ToString();
						_originalDept_chairman = Reader["DEPT_CHAIRMAN"].ToString();
						_originalDept_co_ordinator = Reader["DEPT_CO_ORDINATOR"].ToString();
						_originalDept_nbr_docs = ConvertDEC(Reader["DEPT_NBR_DOCS"]);
						_originalDept_company = ConvertDEC(Reader["DEPT_COMPANY"]);
						_originalFiller = Reader["FILLER"].ToString();
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