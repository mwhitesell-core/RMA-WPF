using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F029_FOLLOWUP_EVENTS : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F029_FOLLOWUP_EVENTS> Collection( Guid? rowid,
															string filler,
															string doc_nbr,
															decimal? followup_datemin,
															decimal? followup_datemax,
															string contacts_email_addr,
															string followup_action,
															string followup_status,
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
					new SqlParameter("FILLER",filler),
					new SqlParameter("DOC_NBR",doc_nbr),
					new SqlParameter("minFOLLOWUP_DATE",followup_datemin),
					new SqlParameter("maxFOLLOWUP_DATE",followup_datemax),
					new SqlParameter("CONTACTS_EMAIL_ADDR",contacts_email_addr),
					new SqlParameter("FOLLOWUP_ACTION",followup_action),
					new SqlParameter("FOLLOWUP_STATUS",followup_status),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F029_FOLLOWUP_EVENTS_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F029_FOLLOWUP_EVENTS>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F029_FOLLOWUP_EVENTS_Search]", parameters);
            var collection = new ObservableCollection<F029_FOLLOWUP_EVENTS>();

            while (Reader.Read())
            {
                collection.Add(new F029_FOLLOWUP_EVENTS
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					FILLER = Reader["FILLER"].ToString(),
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					FOLLOWUP_DATE = ConvertDEC(Reader["FOLLOWUP_DATE"]),
					CONTACTS_EMAIL_ADDR = Reader["CONTACTS_EMAIL_ADDR"].ToString(),
					FOLLOWUP_ACTION = Reader["FOLLOWUP_ACTION"].ToString(),
					FOLLOWUP_STATUS = Reader["FOLLOWUP_STATUS"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalFiller = Reader["FILLER"].ToString(),
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalFollowup_date = ConvertDEC(Reader["FOLLOWUP_DATE"]),
					_originalContacts_email_addr = Reader["CONTACTS_EMAIL_ADDR"].ToString(),
					_originalFollowup_action = Reader["FOLLOWUP_ACTION"].ToString(),
					_originalFollowup_status = Reader["FOLLOWUP_STATUS"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F029_FOLLOWUP_EVENTS Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F029_FOLLOWUP_EVENTS> Collection(ObservableCollection<F029_FOLLOWUP_EVENTS>
                                                               f029FollowupEvents = null)
        {
            if (IsSameSearch() && f029FollowupEvents != null)
            {
                return f029FollowupEvents;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F029_FOLLOWUP_EVENTS>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("FILLER",WhereFiller),
					new SqlParameter("DOC_NBR",WhereDoc_nbr),
					new SqlParameter("FOLLOWUP_DATE",WhereFollowup_date),
					new SqlParameter("CONTACTS_EMAIL_ADDR",WhereContacts_email_addr),
					new SqlParameter("FOLLOWUP_ACTION",WhereFollowup_action),
					new SqlParameter("FOLLOWUP_STATUS",WhereFollowup_status),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F029_FOLLOWUP_EVENTS_Match]", parameters);
            var collection = new ObservableCollection<F029_FOLLOWUP_EVENTS>();

            while (Reader.Read())
            {
                collection.Add(new F029_FOLLOWUP_EVENTS
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					FILLER = Reader["FILLER"].ToString(),
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					FOLLOWUP_DATE = ConvertDEC(Reader["FOLLOWUP_DATE"]),
					CONTACTS_EMAIL_ADDR = Reader["CONTACTS_EMAIL_ADDR"].ToString(),
					FOLLOWUP_ACTION = Reader["FOLLOWUP_ACTION"].ToString(),
					FOLLOWUP_STATUS = Reader["FOLLOWUP_STATUS"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereFiller = WhereFiller,
					_whereDoc_nbr = WhereDoc_nbr,
					_whereFollowup_date = WhereFollowup_date,
					_whereContacts_email_addr = WhereContacts_email_addr,
					_whereFollowup_action = WhereFollowup_action,
					_whereFollowup_status = WhereFollowup_status,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalFiller = Reader["FILLER"].ToString(),
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalFollowup_date = ConvertDEC(Reader["FOLLOWUP_DATE"]),
					_originalContacts_email_addr = Reader["CONTACTS_EMAIL_ADDR"].ToString(),
					_originalFollowup_action = Reader["FOLLOWUP_ACTION"].ToString(),
					_originalFollowup_status = Reader["FOLLOWUP_STATUS"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereFiller = WhereFiller;
					_whereDoc_nbr = WhereDoc_nbr;
					_whereFollowup_date = WhereFollowup_date;
					_whereContacts_email_addr = WhereContacts_email_addr;
					_whereFollowup_action = WhereFollowup_action;
					_whereFollowup_status = WhereFollowup_status;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereFiller == null 
				&& WhereDoc_nbr == null 
				&& WhereFollowup_date == null 
				&& WhereContacts_email_addr == null 
				&& WhereFollowup_action == null 
				&& WhereFollowup_status == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereFiller ==  _whereFiller
				&& WhereDoc_nbr ==  _whereDoc_nbr
				&& WhereFollowup_date ==  _whereFollowup_date
				&& WhereContacts_email_addr ==  _whereContacts_email_addr
				&& WhereFollowup_action ==  _whereFollowup_action
				&& WhereFollowup_status ==  _whereFollowup_status
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereFiller = null; 
			WhereDoc_nbr = null; 
			WhereFollowup_date = null; 
			WhereContacts_email_addr = null; 
			WhereFollowup_action = null; 
			WhereFollowup_status = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _FILLER;
		private string _DOC_NBR;
		private decimal? _FOLLOWUP_DATE;
		private string _CONTACTS_EMAIL_ADDR;
		private string _FOLLOWUP_ACTION;
		private string _FOLLOWUP_STATUS;
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
		public decimal? FOLLOWUP_DATE
		{
			get { return _FOLLOWUP_DATE; }
			set
			{
				if (_FOLLOWUP_DATE != value)
				{
					_FOLLOWUP_DATE = value;
					ChangeState();
				}
			}
		}
		public string CONTACTS_EMAIL_ADDR
		{
			get { return _CONTACTS_EMAIL_ADDR; }
			set
			{
				if (_CONTACTS_EMAIL_ADDR != value)
				{
					_CONTACTS_EMAIL_ADDR = value;
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
		public string FOLLOWUP_STATUS
		{
			get { return _FOLLOWUP_STATUS; }
			set
			{
				if (_FOLLOWUP_STATUS != value)
				{
					_FOLLOWUP_STATUS = value;
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
		public string WhereFiller { get; set; }
		private string _whereFiller;
		public string WhereDoc_nbr { get; set; }
		private string _whereDoc_nbr;
		public decimal? WhereFollowup_date { get; set; }
		private decimal? _whereFollowup_date;
		public string WhereContacts_email_addr { get; set; }
		private string _whereContacts_email_addr;
		public string WhereFollowup_action { get; set; }
		private string _whereFollowup_action;
		public string WhereFollowup_status { get; set; }
		private string _whereFollowup_status;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalFiller;
		private string _originalDoc_nbr;
		private decimal? _originalFollowup_date;
		private string _originalContacts_email_addr;
		private string _originalFollowup_action;
		private string _originalFollowup_status;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			FILLER = _originalFiller;
			DOC_NBR = _originalDoc_nbr;
			FOLLOWUP_DATE = _originalFollowup_date;
			CONTACTS_EMAIL_ADDR = _originalContacts_email_addr;
			FOLLOWUP_ACTION = _originalFollowup_action;
			FOLLOWUP_STATUS = _originalFollowup_status;
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
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F029_FOLLOWUP_EVENTS_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F029_FOLLOWUP_EVENTS_Purge]");
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
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("DOC_NBR", SqlNull(DOC_NBR)),
						new SqlParameter("FOLLOWUP_DATE", SqlNull(FOLLOWUP_DATE)),
						new SqlParameter("CONTACTS_EMAIL_ADDR", SqlNull(CONTACTS_EMAIL_ADDR)),
						new SqlParameter("FOLLOWUP_ACTION", SqlNull(FOLLOWUP_ACTION)),
						new SqlParameter("FOLLOWUP_STATUS", SqlNull(FOLLOWUP_STATUS)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F029_FOLLOWUP_EVENTS_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						FILLER = Reader["FILLER"].ToString();
						DOC_NBR = Reader["DOC_NBR"].ToString();
						FOLLOWUP_DATE = ConvertDEC(Reader["FOLLOWUP_DATE"]);
						CONTACTS_EMAIL_ADDR = Reader["CONTACTS_EMAIL_ADDR"].ToString();
						FOLLOWUP_ACTION = Reader["FOLLOWUP_ACTION"].ToString();
						FOLLOWUP_STATUS = Reader["FOLLOWUP_STATUS"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalFiller = Reader["FILLER"].ToString();
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalFollowup_date = ConvertDEC(Reader["FOLLOWUP_DATE"]);
						_originalContacts_email_addr = Reader["CONTACTS_EMAIL_ADDR"].ToString();
						_originalFollowup_action = Reader["FOLLOWUP_ACTION"].ToString();
						_originalFollowup_status = Reader["FOLLOWUP_STATUS"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("DOC_NBR", SqlNull(DOC_NBR)),
						new SqlParameter("FOLLOWUP_DATE", SqlNull(FOLLOWUP_DATE)),
						new SqlParameter("CONTACTS_EMAIL_ADDR", SqlNull(CONTACTS_EMAIL_ADDR)),
						new SqlParameter("FOLLOWUP_ACTION", SqlNull(FOLLOWUP_ACTION)),
						new SqlParameter("FOLLOWUP_STATUS", SqlNull(FOLLOWUP_STATUS)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F029_FOLLOWUP_EVENTS_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						FILLER = Reader["FILLER"].ToString();
						DOC_NBR = Reader["DOC_NBR"].ToString();
						FOLLOWUP_DATE = ConvertDEC(Reader["FOLLOWUP_DATE"]);
						CONTACTS_EMAIL_ADDR = Reader["CONTACTS_EMAIL_ADDR"].ToString();
						FOLLOWUP_ACTION = Reader["FOLLOWUP_ACTION"].ToString();
						FOLLOWUP_STATUS = Reader["FOLLOWUP_STATUS"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalFiller = Reader["FILLER"].ToString();
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalFollowup_date = ConvertDEC(Reader["FOLLOWUP_DATE"]);
						_originalContacts_email_addr = Reader["CONTACTS_EMAIL_ADDR"].ToString();
						_originalFollowup_action = Reader["FOLLOWUP_ACTION"].ToString();
						_originalFollowup_status = Reader["FOLLOWUP_STATUS"].ToString();
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