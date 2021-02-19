using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class U132DAT : BaseTable
    {
        #region Retrieve

        public ObservableCollection<U132DAT> Collection( Guid? rowid,
															string doc_nbr,
															string filler,
															string doc_name,
															string doc_inits,
															string doc_given_names,
															decimal? signed_amt_netmin,
															decimal? signed_amt_netmax,
															string comp_code,
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
					new SqlParameter("DOC_NBR",doc_nbr),
					new SqlParameter("FILLER",filler),
					new SqlParameter("DOC_NAME",doc_name),
					new SqlParameter("DOC_INITS",doc_inits),
					new SqlParameter("DOC_GIVEN_NAMES",doc_given_names),
					new SqlParameter("minSIGNED_AMT_NET",signed_amt_netmin),
					new SqlParameter("maxSIGNED_AMT_NET",signed_amt_netmax),
					new SqlParameter("COMP_CODE",comp_code),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[SEQUENTIAL].[sp_U132DAT_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<U132DAT>();
				}

            }

            Reader = CoreReader("[SEQUENTIAL].[sp_U132DAT_Search]", parameters);
            var collection = new ObservableCollection<U132DAT>();

            while (Reader.Read())
            {
                collection.Add(new U132DAT
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					FILLER = Reader["FILLER"].ToString(),
					DOC_NAME = Reader["DOC_NAME"].ToString(),
					DOC_INITS = Reader["DOC_INITS"].ToString(),
					DOC_GIVEN_NAMES = Reader["DOC_GIVEN_NAMES"].ToString(),
					SIGNED_AMT_NET = ConvertDEC(Reader["SIGNED_AMT_NET"]),
					COMP_CODE = Reader["COMP_CODE"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalFiller = Reader["FILLER"].ToString(),
					_originalDoc_name = Reader["DOC_NAME"].ToString(),
					_originalDoc_inits = Reader["DOC_INITS"].ToString(),
					_originalDoc_given_names = Reader["DOC_GIVEN_NAMES"].ToString(),
					_originalSigned_amt_net = ConvertDEC(Reader["SIGNED_AMT_NET"]),
					_originalComp_code = Reader["COMP_CODE"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public U132DAT Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<U132DAT> Collection(ObservableCollection<U132DAT>
                                                               u132dat = null)
        {
            if (IsSameSearch() && u132dat != null)
            {
                return u132dat;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<U132DAT>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("DOC_NBR",WhereDoc_nbr),
					new SqlParameter("FILLER",WhereFiller),
					new SqlParameter("DOC_NAME",WhereDoc_name),
					new SqlParameter("DOC_INITS",WhereDoc_inits),
					new SqlParameter("DOC_GIVEN_NAMES",WhereDoc_given_names),
					new SqlParameter("SIGNED_AMT_NET",WhereSigned_amt_net),
					new SqlParameter("COMP_CODE",WhereComp_code),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[SEQUENTIAL].[sp_U132DAT_Match]", parameters);
            var collection = new ObservableCollection<U132DAT>();

            while (Reader.Read())
            {
                collection.Add(new U132DAT
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					FILLER = Reader["FILLER"].ToString(),
					DOC_NAME = Reader["DOC_NAME"].ToString(),
					DOC_INITS = Reader["DOC_INITS"].ToString(),
					DOC_GIVEN_NAMES = Reader["DOC_GIVEN_NAMES"].ToString(),
					SIGNED_AMT_NET = ConvertDEC(Reader["SIGNED_AMT_NET"]),
					COMP_CODE = Reader["COMP_CODE"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereDoc_nbr = WhereDoc_nbr,
					_whereFiller = WhereFiller,
					_whereDoc_name = WhereDoc_name,
					_whereDoc_inits = WhereDoc_inits,
					_whereDoc_given_names = WhereDoc_given_names,
					_whereSigned_amt_net = WhereSigned_amt_net,
					_whereComp_code = WhereComp_code,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalFiller = Reader["FILLER"].ToString(),
					_originalDoc_name = Reader["DOC_NAME"].ToString(),
					_originalDoc_inits = Reader["DOC_INITS"].ToString(),
					_originalDoc_given_names = Reader["DOC_GIVEN_NAMES"].ToString(),
					_originalSigned_amt_net = ConvertDEC(Reader["SIGNED_AMT_NET"]),
					_originalComp_code = Reader["COMP_CODE"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereDoc_nbr = WhereDoc_nbr;
					_whereFiller = WhereFiller;
					_whereDoc_name = WhereDoc_name;
					_whereDoc_inits = WhereDoc_inits;
					_whereDoc_given_names = WhereDoc_given_names;
					_whereSigned_amt_net = WhereSigned_amt_net;
					_whereComp_code = WhereComp_code;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereDoc_nbr == null 
				&& WhereFiller == null 
				&& WhereDoc_name == null 
				&& WhereDoc_inits == null 
				&& WhereDoc_given_names == null 
				&& WhereSigned_amt_net == null 
				&& WhereComp_code == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereDoc_nbr ==  _whereDoc_nbr
				&& WhereFiller ==  _whereFiller
				&& WhereDoc_name ==  _whereDoc_name
				&& WhereDoc_inits ==  _whereDoc_inits
				&& WhereDoc_given_names ==  _whereDoc_given_names
				&& WhereSigned_amt_net ==  _whereSigned_amt_net
				&& WhereComp_code ==  _whereComp_code
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereDoc_nbr = null; 
			WhereFiller = null; 
			WhereDoc_name = null; 
			WhereDoc_inits = null; 
			WhereDoc_given_names = null; 
			WhereSigned_amt_net = null; 
			WhereComp_code = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _DOC_NBR;
		private string _FILLER;
		private string _DOC_NAME;
		private string _DOC_INITS;
		private string _DOC_GIVEN_NAMES;
		private decimal? _SIGNED_AMT_NET;
		private string _COMP_CODE;
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
		public string DOC_NBR
		{
			get { return _DOC_NBR; }
			set
			{
				if (_DOC_NBR != value)
				{
					_DOC_NBR = value;
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
		public string DOC_NAME
		{
			get { return _DOC_NAME; }
			set
			{
				if (_DOC_NAME != value)
				{
					_DOC_NAME = value;
					ChangeState();
				}
			}
		}
		public string DOC_INITS
		{
			get { return _DOC_INITS; }
			set
			{
				if (_DOC_INITS != value)
				{
					_DOC_INITS = value;
					ChangeState();
				}
			}
		}
		public string DOC_GIVEN_NAMES
		{
			get { return _DOC_GIVEN_NAMES; }
			set
			{
				if (_DOC_GIVEN_NAMES != value)
				{
					_DOC_GIVEN_NAMES = value;
					ChangeState();
				}
			}
		}
		public decimal? SIGNED_AMT_NET
		{
			get { return _SIGNED_AMT_NET; }
			set
			{
				if (_SIGNED_AMT_NET != value)
				{
					_SIGNED_AMT_NET = value;
					ChangeState();
				}
			}
		}
		public string COMP_CODE
		{
			get { return _COMP_CODE; }
			set
			{
				if (_COMP_CODE != value)
				{
					_COMP_CODE = value;
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
		public string WhereDoc_nbr { get; set; }
		private string _whereDoc_nbr;
		public string WhereFiller { get; set; }
		private string _whereFiller;
		public string WhereDoc_name { get; set; }
		private string _whereDoc_name;
		public string WhereDoc_inits { get; set; }
		private string _whereDoc_inits;
		public string WhereDoc_given_names { get; set; }
		private string _whereDoc_given_names;
		public decimal? WhereSigned_amt_net { get; set; }
		private decimal? _whereSigned_amt_net;
		public string WhereComp_code { get; set; }
		private string _whereComp_code;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalDoc_nbr;
		private string _originalFiller;
		private string _originalDoc_name;
		private string _originalDoc_inits;
		private string _originalDoc_given_names;
		private decimal? _originalSigned_amt_net;
		private string _originalComp_code;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			DOC_NBR = _originalDoc_nbr;
			FILLER = _originalFiller;
			DOC_NAME = _originalDoc_name;
			DOC_INITS = _originalDoc_inits;
			DOC_GIVEN_NAMES = _originalDoc_given_names;
			SIGNED_AMT_NET = _originalSigned_amt_net;
			COMP_CODE = _originalComp_code;
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
			RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_U132DAT_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_U132DAT_Purge]");
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
						new SqlParameter("DOC_NBR", SqlNull(DOC_NBR)),
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("DOC_NAME", SqlNull(DOC_NAME)),
						new SqlParameter("DOC_INITS", SqlNull(DOC_INITS)),
						new SqlParameter("DOC_GIVEN_NAMES", SqlNull(DOC_GIVEN_NAMES)),
						new SqlParameter("SIGNED_AMT_NET", SqlNull(SIGNED_AMT_NET)),
						new SqlParameter("COMP_CODE", SqlNull(COMP_CODE)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_U132DAT_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOC_NBR = Reader["DOC_NBR"].ToString();
						FILLER = Reader["FILLER"].ToString();
						DOC_NAME = Reader["DOC_NAME"].ToString();
						DOC_INITS = Reader["DOC_INITS"].ToString();
						DOC_GIVEN_NAMES = Reader["DOC_GIVEN_NAMES"].ToString();
						SIGNED_AMT_NET = ConvertDEC(Reader["SIGNED_AMT_NET"]);
						COMP_CODE = Reader["COMP_CODE"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalFiller = Reader["FILLER"].ToString();
						_originalDoc_name = Reader["DOC_NAME"].ToString();
						_originalDoc_inits = Reader["DOC_INITS"].ToString();
						_originalDoc_given_names = Reader["DOC_GIVEN_NAMES"].ToString();
						_originalSigned_amt_net = ConvertDEC(Reader["SIGNED_AMT_NET"]);
						_originalComp_code = Reader["COMP_CODE"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("DOC_NBR", SqlNull(DOC_NBR)),
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("DOC_NAME", SqlNull(DOC_NAME)),
						new SqlParameter("DOC_INITS", SqlNull(DOC_INITS)),
						new SqlParameter("DOC_GIVEN_NAMES", SqlNull(DOC_GIVEN_NAMES)),
						new SqlParameter("SIGNED_AMT_NET", SqlNull(SIGNED_AMT_NET)),
						new SqlParameter("COMP_CODE", SqlNull(COMP_CODE)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_U132DAT_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOC_NBR = Reader["DOC_NBR"].ToString();
						FILLER = Reader["FILLER"].ToString();
						DOC_NAME = Reader["DOC_NAME"].ToString();
						DOC_INITS = Reader["DOC_INITS"].ToString();
						DOC_GIVEN_NAMES = Reader["DOC_GIVEN_NAMES"].ToString();
						SIGNED_AMT_NET = ConvertDEC(Reader["SIGNED_AMT_NET"]);
						COMP_CODE = Reader["COMP_CODE"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalFiller = Reader["FILLER"].ToString();
						_originalDoc_name = Reader["DOC_NAME"].ToString();
						_originalDoc_inits = Reader["DOC_INITS"].ToString();
						_originalDoc_given_names = Reader["DOC_GIVEN_NAMES"].ToString();
						_originalSigned_amt_net = ConvertDEC(Reader["SIGNED_AMT_NET"]);
						_originalComp_code = Reader["COMP_CODE"].ToString();
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