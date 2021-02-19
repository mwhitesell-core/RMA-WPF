using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F027_CONTACTS_MSTR : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F027_CONTACTS_MSTR> Collection( Guid? rowid,
															string filler,
															string doc_nbr,
															string contacts_type,
															string contacts_given_names,
															string contacts_surname,
															string contacts_init_s1,
															string contacts_init_s2,
															string contacts_init_s3,
															string contacts_title,
															string contacts_sex,
															string billing_entry_flag,
															string logon_username,
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
					new SqlParameter("CONTACTS_TYPE",contacts_type),
					new SqlParameter("CONTACTS_GIVEN_NAMES",contacts_given_names),
					new SqlParameter("CONTACTS_SURNAME",contacts_surname),
					new SqlParameter("CONTACTS_INIT_S1",contacts_init_s1),
					new SqlParameter("CONTACTS_INIT_S2",contacts_init_s2),
					new SqlParameter("CONTACTS_INIT_S3",contacts_init_s3),
					new SqlParameter("CONTACTS_TITLE",contacts_title),
					new SqlParameter("CONTACTS_SEX",contacts_sex),
					new SqlParameter("BILLING_ENTRY_FLAG",billing_entry_flag),
					new SqlParameter("LOGON_USERNAME",logon_username),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F027_CONTACTS_MSTR_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F027_CONTACTS_MSTR>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F027_CONTACTS_MSTR_Search]", parameters);
            var collection = new ObservableCollection<F027_CONTACTS_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F027_CONTACTS_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					FILLER = Reader["FILLER"].ToString(),
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					CONTACTS_TYPE = Reader["CONTACTS_TYPE"].ToString(),
					CONTACTS_GIVEN_NAMES = Reader["CONTACTS_GIVEN_NAMES"].ToString(),
					CONTACTS_SURNAME = Reader["CONTACTS_SURNAME"].ToString(),
					CONTACTS_INIT_S1 = Reader["CONTACTS_INIT_S1"].ToString(),
					CONTACTS_INIT_S2 = Reader["CONTACTS_INIT_S2"].ToString(),
					CONTACTS_INIT_S3 = Reader["CONTACTS_INIT_S3"].ToString(),
					CONTACTS_TITLE = Reader["CONTACTS_TITLE"].ToString(),
					CONTACTS_SEX = Reader["CONTACTS_SEX"].ToString(),
					BILLING_ENTRY_FLAG = Reader["BILLING_ENTRY_FLAG"].ToString(),
					LOGON_USERNAME = Reader["LOGON_USERNAME"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalFiller = Reader["FILLER"].ToString(),
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalContacts_type = Reader["CONTACTS_TYPE"].ToString(),
					_originalContacts_given_names = Reader["CONTACTS_GIVEN_NAMES"].ToString(),
					_originalContacts_surname = Reader["CONTACTS_SURNAME"].ToString(),
					_originalContacts_init_s1 = Reader["CONTACTS_INIT_S1"].ToString(),
					_originalContacts_init_s2 = Reader["CONTACTS_INIT_S2"].ToString(),
					_originalContacts_init_s3 = Reader["CONTACTS_INIT_S3"].ToString(),
					_originalContacts_title = Reader["CONTACTS_TITLE"].ToString(),
					_originalContacts_sex = Reader["CONTACTS_SEX"].ToString(),
					_originalentry_flag = Reader["BILLING_ENTRY_FLAG"].ToString(),
					_originalLogon_username = Reader["LOGON_USERNAME"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F027_CONTACTS_MSTR Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F027_CONTACTS_MSTR> Collection(ObservableCollection<F027_CONTACTS_MSTR>
                                                               f027ContactsMstr = null)
        {
            if (IsSameSearch() && f027ContactsMstr != null)
            {
                return f027ContactsMstr;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F027_CONTACTS_MSTR>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("FILLER",WhereFiller),
					new SqlParameter("DOC_NBR",WhereDoc_nbr),
					new SqlParameter("CONTACTS_TYPE",WhereContacts_type),
					new SqlParameter("CONTACTS_GIVEN_NAMES",WhereContacts_given_names),
					new SqlParameter("CONTACTS_SURNAME",WhereContacts_surname),
					new SqlParameter("CONTACTS_INIT_S1",WhereContacts_init_s1),
					new SqlParameter("CONTACTS_INIT_S2",WhereContacts_init_s2),
					new SqlParameter("CONTACTS_INIT_S3",WhereContacts_init_s3),
					new SqlParameter("CONTACTS_TITLE",WhereContacts_title),
					new SqlParameter("CONTACTS_SEX",WhereContacts_sex),
					new SqlParameter("BILLING_ENTRY_FLAG",Whereentry_flag),
					new SqlParameter("LOGON_USERNAME",WhereLogon_username),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F027_CONTACTS_MSTR_Match]", parameters);
            var collection = new ObservableCollection<F027_CONTACTS_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F027_CONTACTS_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					FILLER = Reader["FILLER"].ToString(),
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					CONTACTS_TYPE = Reader["CONTACTS_TYPE"].ToString(),
					CONTACTS_GIVEN_NAMES = Reader["CONTACTS_GIVEN_NAMES"].ToString(),
					CONTACTS_SURNAME = Reader["CONTACTS_SURNAME"].ToString(),
					CONTACTS_INIT_S1 = Reader["CONTACTS_INIT_S1"].ToString(),
					CONTACTS_INIT_S2 = Reader["CONTACTS_INIT_S2"].ToString(),
					CONTACTS_INIT_S3 = Reader["CONTACTS_INIT_S3"].ToString(),
					CONTACTS_TITLE = Reader["CONTACTS_TITLE"].ToString(),
					CONTACTS_SEX = Reader["CONTACTS_SEX"].ToString(),
					BILLING_ENTRY_FLAG = Reader["BILLING_ENTRY_FLAG"].ToString(),
					LOGON_USERNAME = Reader["LOGON_USERNAME"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereFiller = WhereFiller,
					_whereDoc_nbr = WhereDoc_nbr,
					_whereContacts_type = WhereContacts_type,
					_whereContacts_given_names = WhereContacts_given_names,
					_whereContacts_surname = WhereContacts_surname,
					_whereContacts_init_s1 = WhereContacts_init_s1,
					_whereContacts_init_s2 = WhereContacts_init_s2,
					_whereContacts_init_s3 = WhereContacts_init_s3,
					_whereContacts_title = WhereContacts_title,
					_whereContacts_sex = WhereContacts_sex,
					_whereentry_flag = Whereentry_flag,
					_whereLogon_username = WhereLogon_username,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalFiller = Reader["FILLER"].ToString(),
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalContacts_type = Reader["CONTACTS_TYPE"].ToString(),
					_originalContacts_given_names = Reader["CONTACTS_GIVEN_NAMES"].ToString(),
					_originalContacts_surname = Reader["CONTACTS_SURNAME"].ToString(),
					_originalContacts_init_s1 = Reader["CONTACTS_INIT_S1"].ToString(),
					_originalContacts_init_s2 = Reader["CONTACTS_INIT_S2"].ToString(),
					_originalContacts_init_s3 = Reader["CONTACTS_INIT_S3"].ToString(),
					_originalContacts_title = Reader["CONTACTS_TITLE"].ToString(),
					_originalContacts_sex = Reader["CONTACTS_SEX"].ToString(),
					_originalentry_flag = Reader["BILLING_ENTRY_FLAG"].ToString(),
					_originalLogon_username = Reader["LOGON_USERNAME"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereFiller = WhereFiller;
					_whereDoc_nbr = WhereDoc_nbr;
					_whereContacts_type = WhereContacts_type;
					_whereContacts_given_names = WhereContacts_given_names;
					_whereContacts_surname = WhereContacts_surname;
					_whereContacts_init_s1 = WhereContacts_init_s1;
					_whereContacts_init_s2 = WhereContacts_init_s2;
					_whereContacts_init_s3 = WhereContacts_init_s3;
					_whereContacts_title = WhereContacts_title;
					_whereContacts_sex = WhereContacts_sex;
					_whereentry_flag = Whereentry_flag;
					_whereLogon_username = WhereLogon_username;
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
				&& WhereContacts_type == null 
				&& WhereContacts_given_names == null 
				&& WhereContacts_surname == null 
				&& WhereContacts_init_s1 == null 
				&& WhereContacts_init_s2 == null 
				&& WhereContacts_init_s3 == null 
				&& WhereContacts_title == null 
				&& WhereContacts_sex == null 
				&& Whereentry_flag == null 
				&& WhereLogon_username == null 
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
				&& WhereContacts_type ==  _whereContacts_type
				&& WhereContacts_given_names ==  _whereContacts_given_names
				&& WhereContacts_surname ==  _whereContacts_surname
				&& WhereContacts_init_s1 ==  _whereContacts_init_s1
				&& WhereContacts_init_s2 ==  _whereContacts_init_s2
				&& WhereContacts_init_s3 ==  _whereContacts_init_s3
				&& WhereContacts_title ==  _whereContacts_title
				&& WhereContacts_sex ==  _whereContacts_sex
				&& Whereentry_flag ==  _whereentry_flag
				&& WhereLogon_username ==  _whereLogon_username
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereFiller = null; 
			WhereDoc_nbr = null; 
			WhereContacts_type = null; 
			WhereContacts_given_names = null; 
			WhereContacts_surname = null; 
			WhereContacts_init_s1 = null; 
			WhereContacts_init_s2 = null; 
			WhereContacts_init_s3 = null; 
			WhereContacts_title = null; 
			WhereContacts_sex = null; 
			Whereentry_flag = null; 
			WhereLogon_username = null; 
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
		private string _CONTACTS_TYPE;
		private string _CONTACTS_GIVEN_NAMES;
		private string _CONTACTS_SURNAME;
		private string _CONTACTS_INIT_S1;
		private string _CONTACTS_INIT_S2;
		private string _CONTACTS_INIT_S3;
		private string _CONTACTS_TITLE;
		private string _CONTACTS_SEX;
		private string _BILLING_ENTRY_FLAG;
		private string _LOGON_USERNAME;
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
		public string CONTACTS_TYPE
		{
			get { return _CONTACTS_TYPE; }
			set
			{
				if (_CONTACTS_TYPE != value)
				{
					_CONTACTS_TYPE = value;
					ChangeState();
				}
			}
		}
		public string CONTACTS_GIVEN_NAMES
		{
			get { return _CONTACTS_GIVEN_NAMES; }
			set
			{
				if (_CONTACTS_GIVEN_NAMES != value)
				{
					_CONTACTS_GIVEN_NAMES = value;
					ChangeState();
				}
			}
		}
		public string CONTACTS_SURNAME
		{
			get { return _CONTACTS_SURNAME; }
			set
			{
				if (_CONTACTS_SURNAME != value)
				{
					_CONTACTS_SURNAME = value;
					ChangeState();
				}
			}
		}
		public string CONTACTS_INIT_S1
		{
			get { return _CONTACTS_INIT_S1; }
			set
			{
				if (_CONTACTS_INIT_S1 != value)
				{
					_CONTACTS_INIT_S1 = value;
					ChangeState();
				}
			}
		}
		public string CONTACTS_INIT_S2
		{
			get { return _CONTACTS_INIT_S2; }
			set
			{
				if (_CONTACTS_INIT_S2 != value)
				{
					_CONTACTS_INIT_S2 = value;
					ChangeState();
				}
			}
		}
		public string CONTACTS_INIT_S3
		{
			get { return _CONTACTS_INIT_S3; }
			set
			{
				if (_CONTACTS_INIT_S3 != value)
				{
					_CONTACTS_INIT_S3 = value;
					ChangeState();
				}
			}
		}
		public string CONTACTS_TITLE
		{
			get { return _CONTACTS_TITLE; }
			set
			{
				if (_CONTACTS_TITLE != value)
				{
					_CONTACTS_TITLE = value;
					ChangeState();
				}
			}
		}
		public string CONTACTS_SEX
		{
			get { return _CONTACTS_SEX; }
			set
			{
				if (_CONTACTS_SEX != value)
				{
					_CONTACTS_SEX = value;
					ChangeState();
				}
			}
		}
		public string BILLING_ENTRY_FLAG
		{
			get { return _BILLING_ENTRY_FLAG; }
			set
			{
				if (_BILLING_ENTRY_FLAG != value)
				{
					_BILLING_ENTRY_FLAG = value;
					ChangeState();
				}
			}
		}
		public string LOGON_USERNAME
		{
			get { return _LOGON_USERNAME; }
			set
			{
				if (_LOGON_USERNAME != value)
				{
					_LOGON_USERNAME = value;
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
		public string WhereContacts_type { get; set; }
		private string _whereContacts_type;
		public string WhereContacts_given_names { get; set; }
		private string _whereContacts_given_names;
		public string WhereContacts_surname { get; set; }
		private string _whereContacts_surname;
		public string WhereContacts_init_s1 { get; set; }
		private string _whereContacts_init_s1;
		public string WhereContacts_init_s2 { get; set; }
		private string _whereContacts_init_s2;
		public string WhereContacts_init_s3 { get; set; }
		private string _whereContacts_init_s3;
		public string WhereContacts_title { get; set; }
		private string _whereContacts_title;
		public string WhereContacts_sex { get; set; }
		private string _whereContacts_sex;
		public string Whereentry_flag { get; set; }
		private string _whereentry_flag;
		public string WhereLogon_username { get; set; }
		private string _whereLogon_username;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalFiller;
		private string _originalDoc_nbr;
		private string _originalContacts_type;
		private string _originalContacts_given_names;
		private string _originalContacts_surname;
		private string _originalContacts_init_s1;
		private string _originalContacts_init_s2;
		private string _originalContacts_init_s3;
		private string _originalContacts_title;
		private string _originalContacts_sex;
		private string _originalentry_flag;
		private string _originalLogon_username;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			FILLER = _originalFiller;
			DOC_NBR = _originalDoc_nbr;
			CONTACTS_TYPE = _originalContacts_type;
			CONTACTS_GIVEN_NAMES = _originalContacts_given_names;
			CONTACTS_SURNAME = _originalContacts_surname;
			CONTACTS_INIT_S1 = _originalContacts_init_s1;
			CONTACTS_INIT_S2 = _originalContacts_init_s2;
			CONTACTS_INIT_S3 = _originalContacts_init_s3;
			CONTACTS_TITLE = _originalContacts_title;
			CONTACTS_SEX = _originalContacts_sex;
			BILLING_ENTRY_FLAG = _originalentry_flag;
			LOGON_USERNAME = _originalLogon_username;
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
					new SqlParameter("FILLER",FILLER),
					new SqlParameter("DOC_NBR",DOC_NBR),
					new SqlParameter("CONTACTS_TYPE",CONTACTS_TYPE)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F027_CONTACTS_MSTR_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F027_CONTACTS_MSTR_Purge]");
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
						new SqlParameter("CONTACTS_TYPE", SqlNull(CONTACTS_TYPE)),
						new SqlParameter("CONTACTS_GIVEN_NAMES", SqlNull(CONTACTS_GIVEN_NAMES)),
						new SqlParameter("CONTACTS_SURNAME", SqlNull(CONTACTS_SURNAME)),
						new SqlParameter("CONTACTS_INIT_S1", SqlNull(CONTACTS_INIT_S1)),
						new SqlParameter("CONTACTS_INIT_S2", SqlNull(CONTACTS_INIT_S2)),
						new SqlParameter("CONTACTS_INIT_S3", SqlNull(CONTACTS_INIT_S3)),
						new SqlParameter("CONTACTS_TITLE", SqlNull(CONTACTS_TITLE)),
						new SqlParameter("CONTACTS_SEX", SqlNull(CONTACTS_SEX)),
						new SqlParameter("BILLING_ENTRY_FLAG", SqlNull(BILLING_ENTRY_FLAG)),
						new SqlParameter("LOGON_USERNAME", SqlNull(LOGON_USERNAME)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F027_CONTACTS_MSTR_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						FILLER = Reader["FILLER"].ToString();
						DOC_NBR = Reader["DOC_NBR"].ToString();
						CONTACTS_TYPE = Reader["CONTACTS_TYPE"].ToString();
						CONTACTS_GIVEN_NAMES = Reader["CONTACTS_GIVEN_NAMES"].ToString();
						CONTACTS_SURNAME = Reader["CONTACTS_SURNAME"].ToString();
						CONTACTS_INIT_S1 = Reader["CONTACTS_INIT_S1"].ToString();
						CONTACTS_INIT_S2 = Reader["CONTACTS_INIT_S2"].ToString();
						CONTACTS_INIT_S3 = Reader["CONTACTS_INIT_S3"].ToString();
						CONTACTS_TITLE = Reader["CONTACTS_TITLE"].ToString();
						CONTACTS_SEX = Reader["CONTACTS_SEX"].ToString();
						BILLING_ENTRY_FLAG = Reader["BILLING_ENTRY_FLAG"].ToString();
						LOGON_USERNAME = Reader["LOGON_USERNAME"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalFiller = Reader["FILLER"].ToString();
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalContacts_type = Reader["CONTACTS_TYPE"].ToString();
						_originalContacts_given_names = Reader["CONTACTS_GIVEN_NAMES"].ToString();
						_originalContacts_surname = Reader["CONTACTS_SURNAME"].ToString();
						_originalContacts_init_s1 = Reader["CONTACTS_INIT_S1"].ToString();
						_originalContacts_init_s2 = Reader["CONTACTS_INIT_S2"].ToString();
						_originalContacts_init_s3 = Reader["CONTACTS_INIT_S3"].ToString();
						_originalContacts_title = Reader["CONTACTS_TITLE"].ToString();
						_originalContacts_sex = Reader["CONTACTS_SEX"].ToString();
						_originalentry_flag = Reader["BILLING_ENTRY_FLAG"].ToString();
						_originalLogon_username = Reader["LOGON_USERNAME"].ToString();
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
						new SqlParameter("CONTACTS_TYPE", SqlNull(CONTACTS_TYPE)),
						new SqlParameter("CONTACTS_GIVEN_NAMES", SqlNull(CONTACTS_GIVEN_NAMES)),
						new SqlParameter("CONTACTS_SURNAME", SqlNull(CONTACTS_SURNAME)),
						new SqlParameter("CONTACTS_INIT_S1", SqlNull(CONTACTS_INIT_S1)),
						new SqlParameter("CONTACTS_INIT_S2", SqlNull(CONTACTS_INIT_S2)),
						new SqlParameter("CONTACTS_INIT_S3", SqlNull(CONTACTS_INIT_S3)),
						new SqlParameter("CONTACTS_TITLE", SqlNull(CONTACTS_TITLE)),
						new SqlParameter("CONTACTS_SEX", SqlNull(CONTACTS_SEX)),
						new SqlParameter("BILLING_ENTRY_FLAG", SqlNull(BILLING_ENTRY_FLAG)),
						new SqlParameter("LOGON_USERNAME", SqlNull(LOGON_USERNAME)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F027_CONTACTS_MSTR_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						FILLER = Reader["FILLER"].ToString();
						DOC_NBR = Reader["DOC_NBR"].ToString();
						CONTACTS_TYPE = Reader["CONTACTS_TYPE"].ToString();
						CONTACTS_GIVEN_NAMES = Reader["CONTACTS_GIVEN_NAMES"].ToString();
						CONTACTS_SURNAME = Reader["CONTACTS_SURNAME"].ToString();
						CONTACTS_INIT_S1 = Reader["CONTACTS_INIT_S1"].ToString();
						CONTACTS_INIT_S2 = Reader["CONTACTS_INIT_S2"].ToString();
						CONTACTS_INIT_S3 = Reader["CONTACTS_INIT_S3"].ToString();
						CONTACTS_TITLE = Reader["CONTACTS_TITLE"].ToString();
						CONTACTS_SEX = Reader["CONTACTS_SEX"].ToString();
						BILLING_ENTRY_FLAG = Reader["BILLING_ENTRY_FLAG"].ToString();
						LOGON_USERNAME = Reader["LOGON_USERNAME"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalFiller = Reader["FILLER"].ToString();
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalContacts_type = Reader["CONTACTS_TYPE"].ToString();
						_originalContacts_given_names = Reader["CONTACTS_GIVEN_NAMES"].ToString();
						_originalContacts_surname = Reader["CONTACTS_SURNAME"].ToString();
						_originalContacts_init_s1 = Reader["CONTACTS_INIT_S1"].ToString();
						_originalContacts_init_s2 = Reader["CONTACTS_INIT_S2"].ToString();
						_originalContacts_init_s3 = Reader["CONTACTS_INIT_S3"].ToString();
						_originalContacts_title = Reader["CONTACTS_TITLE"].ToString();
						_originalContacts_sex = Reader["CONTACTS_SEX"].ToString();
						_originalentry_flag = Reader["BILLING_ENTRY_FLAG"].ToString();
						_originalLogon_username = Reader["LOGON_USERNAME"].ToString();
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