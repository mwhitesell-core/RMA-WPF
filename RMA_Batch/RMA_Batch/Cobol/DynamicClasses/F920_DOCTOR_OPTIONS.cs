using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F920_DOCTOR_OPTIONS : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F920_DOCTOR_OPTIONS> Collection( Guid? rowid,
															string doc_nbr,
															string doc_option_category,
															string doc_option_subcategory,
															decimal? doc_option_date_active_frommin,
															decimal? doc_option_date_active_frommax,
															decimal? doc_option_date_active_tomin,
															decimal? doc_option_date_active_tomax,
															string doc_option_value,
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
					new SqlParameter("DOC_OPTION_CATEGORY",doc_option_category),
					new SqlParameter("DOC_OPTION_SUBCATEGORY",doc_option_subcategory),
					new SqlParameter("minDOC_OPTION_DATE_ACTIVE_FROM",doc_option_date_active_frommin),
					new SqlParameter("maxDOC_OPTION_DATE_ACTIVE_FROM",doc_option_date_active_frommax),
					new SqlParameter("minDOC_OPTION_DATE_ACTIVE_TO",doc_option_date_active_tomin),
					new SqlParameter("maxDOC_OPTION_DATE_ACTIVE_TO",doc_option_date_active_tomax),
					new SqlParameter("DOC_OPTION_VALUE",doc_option_value),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F920_DOCTOR_OPTIONS_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F920_DOCTOR_OPTIONS>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F920_DOCTOR_OPTIONS_Search]", parameters);
            var collection = new ObservableCollection<F920_DOCTOR_OPTIONS>();

            while (Reader.Read())
            {
                collection.Add(new F920_DOCTOR_OPTIONS
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					DOC_OPTION_CATEGORY = Reader["DOC_OPTION_CATEGORY"].ToString(),
					DOC_OPTION_SUBCATEGORY = Reader["DOC_OPTION_SUBCATEGORY"].ToString(),
					DOC_OPTION_DATE_ACTIVE_FROM = ConvertDEC(Reader["DOC_OPTION_DATE_ACTIVE_FROM"]),
					DOC_OPTION_DATE_ACTIVE_TO = ConvertDEC(Reader["DOC_OPTION_DATE_ACTIVE_TO"]),
					DOC_OPTION_VALUE = Reader["DOC_OPTION_VALUE"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalDoc_option_category = Reader["DOC_OPTION_CATEGORY"].ToString(),
					_originalDoc_option_subcategory = Reader["DOC_OPTION_SUBCATEGORY"].ToString(),
					_originalDoc_option_date_active_from = ConvertDEC(Reader["DOC_OPTION_DATE_ACTIVE_FROM"]),
					_originalDoc_option_date_active_to = ConvertDEC(Reader["DOC_OPTION_DATE_ACTIVE_TO"]),
					_originalDoc_option_value = Reader["DOC_OPTION_VALUE"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F920_DOCTOR_OPTIONS Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F920_DOCTOR_OPTIONS> Collection(ObservableCollection<F920_DOCTOR_OPTIONS>
                                                               f920DoctorOptions = null)
        {
            if (IsSameSearch() && f920DoctorOptions != null)
            {
                return f920DoctorOptions;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F920_DOCTOR_OPTIONS>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("DOC_NBR",WhereDoc_nbr),
					new SqlParameter("DOC_OPTION_CATEGORY",WhereDoc_option_category),
					new SqlParameter("DOC_OPTION_SUBCATEGORY",WhereDoc_option_subcategory),
					new SqlParameter("DOC_OPTION_DATE_ACTIVE_FROM",WhereDoc_option_date_active_from),
					new SqlParameter("DOC_OPTION_DATE_ACTIVE_TO",WhereDoc_option_date_active_to),
					new SqlParameter("DOC_OPTION_VALUE",WhereDoc_option_value),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F920_DOCTOR_OPTIONS_Match]", parameters);
            var collection = new ObservableCollection<F920_DOCTOR_OPTIONS>();

            while (Reader.Read())
            {
                collection.Add(new F920_DOCTOR_OPTIONS
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					DOC_OPTION_CATEGORY = Reader["DOC_OPTION_CATEGORY"].ToString(),
					DOC_OPTION_SUBCATEGORY = Reader["DOC_OPTION_SUBCATEGORY"].ToString(),
					DOC_OPTION_DATE_ACTIVE_FROM = ConvertDEC(Reader["DOC_OPTION_DATE_ACTIVE_FROM"]),
					DOC_OPTION_DATE_ACTIVE_TO = ConvertDEC(Reader["DOC_OPTION_DATE_ACTIVE_TO"]),
					DOC_OPTION_VALUE = Reader["DOC_OPTION_VALUE"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereDoc_nbr = WhereDoc_nbr,
					_whereDoc_option_category = WhereDoc_option_category,
					_whereDoc_option_subcategory = WhereDoc_option_subcategory,
					_whereDoc_option_date_active_from = WhereDoc_option_date_active_from,
					_whereDoc_option_date_active_to = WhereDoc_option_date_active_to,
					_whereDoc_option_value = WhereDoc_option_value,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalDoc_option_category = Reader["DOC_OPTION_CATEGORY"].ToString(),
					_originalDoc_option_subcategory = Reader["DOC_OPTION_SUBCATEGORY"].ToString(),
					_originalDoc_option_date_active_from = ConvertDEC(Reader["DOC_OPTION_DATE_ACTIVE_FROM"]),
					_originalDoc_option_date_active_to = ConvertDEC(Reader["DOC_OPTION_DATE_ACTIVE_TO"]),
					_originalDoc_option_value = Reader["DOC_OPTION_VALUE"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereDoc_nbr = WhereDoc_nbr;
					_whereDoc_option_category = WhereDoc_option_category;
					_whereDoc_option_subcategory = WhereDoc_option_subcategory;
					_whereDoc_option_date_active_from = WhereDoc_option_date_active_from;
					_whereDoc_option_date_active_to = WhereDoc_option_date_active_to;
					_whereDoc_option_value = WhereDoc_option_value;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereDoc_nbr == null 
				&& WhereDoc_option_category == null 
				&& WhereDoc_option_subcategory == null 
				&& WhereDoc_option_date_active_from == null 
				&& WhereDoc_option_date_active_to == null 
				&& WhereDoc_option_value == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereDoc_nbr ==  _whereDoc_nbr
				&& WhereDoc_option_category ==  _whereDoc_option_category
				&& WhereDoc_option_subcategory ==  _whereDoc_option_subcategory
				&& WhereDoc_option_date_active_from ==  _whereDoc_option_date_active_from
				&& WhereDoc_option_date_active_to ==  _whereDoc_option_date_active_to
				&& WhereDoc_option_value ==  _whereDoc_option_value
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereDoc_nbr = null; 
			WhereDoc_option_category = null; 
			WhereDoc_option_subcategory = null; 
			WhereDoc_option_date_active_from = null; 
			WhereDoc_option_date_active_to = null; 
			WhereDoc_option_value = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _DOC_NBR;
		private string _DOC_OPTION_CATEGORY;
		private string _DOC_OPTION_SUBCATEGORY;
		private decimal? _DOC_OPTION_DATE_ACTIVE_FROM;
		private decimal? _DOC_OPTION_DATE_ACTIVE_TO;
		private string _DOC_OPTION_VALUE;
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
		public string DOC_OPTION_CATEGORY
		{
			get { return _DOC_OPTION_CATEGORY; }
			set
			{
				if (_DOC_OPTION_CATEGORY != value)
				{
					_DOC_OPTION_CATEGORY = value;
					ChangeState();
				}
			}
		}
		public string DOC_OPTION_SUBCATEGORY
		{
			get { return _DOC_OPTION_SUBCATEGORY; }
			set
			{
				if (_DOC_OPTION_SUBCATEGORY != value)
				{
					_DOC_OPTION_SUBCATEGORY = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_OPTION_DATE_ACTIVE_FROM
		{
			get { return _DOC_OPTION_DATE_ACTIVE_FROM; }
			set
			{
				if (_DOC_OPTION_DATE_ACTIVE_FROM != value)
				{
					_DOC_OPTION_DATE_ACTIVE_FROM = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_OPTION_DATE_ACTIVE_TO
		{
			get { return _DOC_OPTION_DATE_ACTIVE_TO; }
			set
			{
				if (_DOC_OPTION_DATE_ACTIVE_TO != value)
				{
					_DOC_OPTION_DATE_ACTIVE_TO = value;
					ChangeState();
				}
			}
		}
		public string DOC_OPTION_VALUE
		{
			get { return _DOC_OPTION_VALUE; }
			set
			{
				if (_DOC_OPTION_VALUE != value)
				{
					_DOC_OPTION_VALUE = value;
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
		public string WhereDoc_option_category { get; set; }
		private string _whereDoc_option_category;
		public string WhereDoc_option_subcategory { get; set; }
		private string _whereDoc_option_subcategory;
		public decimal? WhereDoc_option_date_active_from { get; set; }
		private decimal? _whereDoc_option_date_active_from;
		public decimal? WhereDoc_option_date_active_to { get; set; }
		private decimal? _whereDoc_option_date_active_to;
		public string WhereDoc_option_value { get; set; }
		private string _whereDoc_option_value;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalDoc_nbr;
		private string _originalDoc_option_category;
		private string _originalDoc_option_subcategory;
		private decimal? _originalDoc_option_date_active_from;
		private decimal? _originalDoc_option_date_active_to;
		private string _originalDoc_option_value;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			DOC_NBR = _originalDoc_nbr;
			DOC_OPTION_CATEGORY = _originalDoc_option_category;
			DOC_OPTION_SUBCATEGORY = _originalDoc_option_subcategory;
			DOC_OPTION_DATE_ACTIVE_FROM = _originalDoc_option_date_active_from;
			DOC_OPTION_DATE_ACTIVE_TO = _originalDoc_option_date_active_to;
			DOC_OPTION_VALUE = _originalDoc_option_value;
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
					new SqlParameter("DOC_NBR",DOC_NBR),
					new SqlParameter("DOC_OPTION_CATEGORY",DOC_OPTION_CATEGORY),
					new SqlParameter("DOC_OPTION_SUBCATEGORY",DOC_OPTION_SUBCATEGORY),
					new SqlParameter("DOC_OPTION_DATE_ACTIVE_FROM",DOC_OPTION_DATE_ACTIVE_FROM)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F920_DOCTOR_OPTIONS_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F920_DOCTOR_OPTIONS_Purge]");
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
						new SqlParameter("DOC_OPTION_CATEGORY", SqlNull(DOC_OPTION_CATEGORY)),
						new SqlParameter("DOC_OPTION_SUBCATEGORY", SqlNull(DOC_OPTION_SUBCATEGORY)),
						new SqlParameter("DOC_OPTION_DATE_ACTIVE_FROM", SqlNull(DOC_OPTION_DATE_ACTIVE_FROM)),
						new SqlParameter("DOC_OPTION_DATE_ACTIVE_TO", SqlNull(DOC_OPTION_DATE_ACTIVE_TO)),
						new SqlParameter("DOC_OPTION_VALUE", SqlNull(DOC_OPTION_VALUE)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F920_DOCTOR_OPTIONS_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOC_NBR = Reader["DOC_NBR"].ToString();
						DOC_OPTION_CATEGORY = Reader["DOC_OPTION_CATEGORY"].ToString();
						DOC_OPTION_SUBCATEGORY = Reader["DOC_OPTION_SUBCATEGORY"].ToString();
						DOC_OPTION_DATE_ACTIVE_FROM = ConvertDEC(Reader["DOC_OPTION_DATE_ACTIVE_FROM"]);
						DOC_OPTION_DATE_ACTIVE_TO = ConvertDEC(Reader["DOC_OPTION_DATE_ACTIVE_TO"]);
						DOC_OPTION_VALUE = Reader["DOC_OPTION_VALUE"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalDoc_option_category = Reader["DOC_OPTION_CATEGORY"].ToString();
						_originalDoc_option_subcategory = Reader["DOC_OPTION_SUBCATEGORY"].ToString();
						_originalDoc_option_date_active_from = ConvertDEC(Reader["DOC_OPTION_DATE_ACTIVE_FROM"]);
						_originalDoc_option_date_active_to = ConvertDEC(Reader["DOC_OPTION_DATE_ACTIVE_TO"]);
						_originalDoc_option_value = Reader["DOC_OPTION_VALUE"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("DOC_NBR", SqlNull(DOC_NBR)),
						new SqlParameter("DOC_OPTION_CATEGORY", SqlNull(DOC_OPTION_CATEGORY)),
						new SqlParameter("DOC_OPTION_SUBCATEGORY", SqlNull(DOC_OPTION_SUBCATEGORY)),
						new SqlParameter("DOC_OPTION_DATE_ACTIVE_FROM", SqlNull(DOC_OPTION_DATE_ACTIVE_FROM)),
						new SqlParameter("DOC_OPTION_DATE_ACTIVE_TO", SqlNull(DOC_OPTION_DATE_ACTIVE_TO)),
						new SqlParameter("DOC_OPTION_VALUE", SqlNull(DOC_OPTION_VALUE)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F920_DOCTOR_OPTIONS_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOC_NBR = Reader["DOC_NBR"].ToString();
						DOC_OPTION_CATEGORY = Reader["DOC_OPTION_CATEGORY"].ToString();
						DOC_OPTION_SUBCATEGORY = Reader["DOC_OPTION_SUBCATEGORY"].ToString();
						DOC_OPTION_DATE_ACTIVE_FROM = ConvertDEC(Reader["DOC_OPTION_DATE_ACTIVE_FROM"]);
						DOC_OPTION_DATE_ACTIVE_TO = ConvertDEC(Reader["DOC_OPTION_DATE_ACTIVE_TO"]);
						DOC_OPTION_VALUE = Reader["DOC_OPTION_VALUE"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalDoc_option_category = Reader["DOC_OPTION_CATEGORY"].ToString();
						_originalDoc_option_subcategory = Reader["DOC_OPTION_SUBCATEGORY"].ToString();
						_originalDoc_option_date_active_from = ConvertDEC(Reader["DOC_OPTION_DATE_ACTIVE_FROM"]);
						_originalDoc_option_date_active_to = ConvertDEC(Reader["DOC_OPTION_DATE_ACTIVE_TO"]);
						_originalDoc_option_value = Reader["DOC_OPTION_VALUE"].ToString();
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