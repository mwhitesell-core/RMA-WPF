using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F002_SUSPEND_ADDRESS : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F002_SUSPEND_ADDRESS> Collection( Guid? rowid,
															string add_address_line_1,
															string add_address_line_2,
															string add_address_line_3,
															string add_postal_code,
															string add_surname,
															string add_first_name,
															decimal? add_birth_datemin,
															decimal? add_birth_datemax,
															string add_sex,
															string add_phone_no,
															decimal? add_doc_ohip_nbrmin,
															decimal? add_doc_ohip_nbrmax,
															string add_accounting_nbr,
                                                            string debug_info,
                                                            decimal? error_flag,
                                                            string input_file_location,
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
					new SqlParameter("ADD_ADDRESS_LINE_1",add_address_line_1),
					new SqlParameter("ADD_ADDRESS_LINE_2",add_address_line_2),
					new SqlParameter("ADD_ADDRESS_LINE_3",add_address_line_3),
					new SqlParameter("ADD_POSTAL_CODE",add_postal_code),
					new SqlParameter("ADD_SURNAME",add_surname),
					new SqlParameter("ADD_FIRST_NAME",add_first_name),
					new SqlParameter("minADD_BIRTH_DATE",add_birth_datemin),
					new SqlParameter("maxADD_BIRTH_DATE",add_birth_datemax),
					new SqlParameter("ADD_SEX",add_sex),
					new SqlParameter("ADD_PHONE_NO",add_phone_no),
					new SqlParameter("minADD_DOC_OHIP_NBR",add_doc_ohip_nbrmin),
					new SqlParameter("maxADD_DOC_OHIP_NBR",add_doc_ohip_nbrmax),
					new SqlParameter("ADD_ACCOUNTING_NBR",add_accounting_nbr),
                    new SqlParameter("DEBUG_INFO", debug_info),
                    new SqlParameter("minERROR_FLAG", error_flag),
                    new SqlParameter("maxERROR_FLAG", error_flag),
                    new SqlParameter("INPUT_FILE_LOCATION", input_file_location),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F002_SUSPEND_ADDRESS_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F002_SUSPEND_ADDRESS>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F002_SUSPEND_ADDRESS_Search]", parameters);
            var collection = new ObservableCollection<F002_SUSPEND_ADDRESS>();

            while (Reader.Read())
            {
                collection.Add(new F002_SUSPEND_ADDRESS
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					ADD_ADDRESS_LINE_1 = Reader["ADD_ADDRESS_LINE_1"].ToString(),
					ADD_ADDRESS_LINE_2 = Reader["ADD_ADDRESS_LINE_2"].ToString(),
					ADD_ADDRESS_LINE_3 = Reader["ADD_ADDRESS_LINE_3"].ToString(),
					ADD_POSTAL_CODE = Reader["ADD_POSTAL_CODE"].ToString(),
					ADD_SURNAME = Reader["ADD_SURNAME"].ToString(),
					ADD_FIRST_NAME = Reader["ADD_FIRST_NAME"].ToString(),
					ADD_BIRTH_DATE = ConvertDEC(Reader["ADD_BIRTH_DATE"]),
					ADD_SEX = Reader["ADD_SEX"].ToString(),
					ADD_PHONE_NO = Reader["ADD_PHONE_NO"].ToString(),
					ADD_DOC_OHIP_NBR = ConvertDEC(Reader["ADD_DOC_OHIP_NBR"]),
					ADD_ACCOUNTING_NBR = Reader["ADD_ACCOUNTING_NBR"].ToString(),
                    DEBUG_INFO = Reader["DEBUG_INFO"].ToString(),
                    ERROR_FLAG = ConvertDEC(Reader["ERROR_FLAG"]),
                    INPUT_FILE_LOCATION = Reader["INPUT_FILE_LOCATION"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalAdd_address_line_1 = Reader["ADD_ADDRESS_LINE_1"].ToString(),
					_originalAdd_address_line_2 = Reader["ADD_ADDRESS_LINE_2"].ToString(),
					_originalAdd_address_line_3 = Reader["ADD_ADDRESS_LINE_3"].ToString(),
					_originalAdd_postal_code = Reader["ADD_POSTAL_CODE"].ToString(),
					_originalAdd_surname = Reader["ADD_SURNAME"].ToString(),
					_originalAdd_first_name = Reader["ADD_FIRST_NAME"].ToString(),
					_originalAdd_birth_date = ConvertDEC(Reader["ADD_BIRTH_DATE"]),
					_originalAdd_sex = Reader["ADD_SEX"].ToString(),
					_originalAdd_phone_no = Reader["ADD_PHONE_NO"].ToString(),
					_originalAdd_doc_ohip_nbr = ConvertDEC(Reader["ADD_DOC_OHIP_NBR"]),
					_originalAdd_accounting_nbr = Reader["ADD_ACCOUNTING_NBR"].ToString(),
                    _originalDebug_info = Reader["DEBUG_INFO"].ToString(),
                    _originalError_flag = ConvertDEC(Reader["ERROR_FLAG"]),
                    _originalInput_file_location = Reader["INPUT_FILE_LOCATION"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F002_SUSPEND_ADDRESS Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F002_SUSPEND_ADDRESS> Collection(ObservableCollection<F002_SUSPEND_ADDRESS>
                                                               f002SuspendAddress = null)
        {
            if (IsSameSearch() && f002SuspendAddress != null)
            {
                return f002SuspendAddress;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F002_SUSPEND_ADDRESS>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("ADD_ADDRESS_LINE_1",WhereAdd_address_line_1),
					new SqlParameter("ADD_ADDRESS_LINE_2",WhereAdd_address_line_2),
					new SqlParameter("ADD_ADDRESS_LINE_3",WhereAdd_address_line_3),
					new SqlParameter("ADD_POSTAL_CODE",WhereAdd_postal_code),
					new SqlParameter("ADD_SURNAME",WhereAdd_surname),
					new SqlParameter("ADD_FIRST_NAME",WhereAdd_first_name),
					new SqlParameter("ADD_BIRTH_DATE",WhereAdd_birth_date),
					new SqlParameter("ADD_SEX",WhereAdd_sex),
					new SqlParameter("ADD_PHONE_NO",WhereAdd_phone_no),
					new SqlParameter("ADD_DOC_OHIP_NBR",WhereAdd_doc_ohip_nbr),
					new SqlParameter("ADD_ACCOUNTING_NBR",WhereAdd_accounting_nbr),
                    new SqlParameter("DEBUG_INFO", WhereDebug_info),
                    new SqlParameter("ERROR_FLAG", WhereError_flag),
                    new SqlParameter("INPUT_FILE_LOCATION", WhereInput_file_location),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F002_SUSPEND_ADDRESS_Match]", parameters);
            var collection = new ObservableCollection<F002_SUSPEND_ADDRESS>();

            while (Reader.Read())
            {
                collection.Add(new F002_SUSPEND_ADDRESS
                {
                    RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
                    ROWID = (Guid)Reader["ROWID"],
                    ADD_ADDRESS_LINE_1 = Reader["ADD_ADDRESS_LINE_1"].ToString(),
                    ADD_ADDRESS_LINE_2 = Reader["ADD_ADDRESS_LINE_2"].ToString(),
                    ADD_ADDRESS_LINE_3 = Reader["ADD_ADDRESS_LINE_3"].ToString(),
                    ADD_POSTAL_CODE = Reader["ADD_POSTAL_CODE"].ToString(),
                    ADD_SURNAME = Reader["ADD_SURNAME"].ToString(),
                    ADD_FIRST_NAME = Reader["ADD_FIRST_NAME"].ToString(),
                    ADD_BIRTH_DATE = ConvertDEC(Reader["ADD_BIRTH_DATE"]),
                    ADD_SEX = Reader["ADD_SEX"].ToString(),
                    ADD_PHONE_NO = Reader["ADD_PHONE_NO"].ToString(),
                    ADD_DOC_OHIP_NBR = ConvertDEC(Reader["ADD_DOC_OHIP_NBR"]),
                    ADD_ACCOUNTING_NBR = Reader["ADD_ACCOUNTING_NBR"].ToString(),
                    DEBUG_INFO = Reader["DEBUG_INFO"].ToString(),
                    ERROR_FLAG = ConvertDEC(Reader["ERROR_FLAG"]),
                    INPUT_FILE_LOCATION = Reader["INPUT_FILE_LOCATION"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereAdd_address_line_1 = WhereAdd_address_line_1,
					_whereAdd_address_line_2 = WhereAdd_address_line_2,
					_whereAdd_address_line_3 = WhereAdd_address_line_3,
					_whereAdd_postal_code = WhereAdd_postal_code,
					_whereAdd_surname = WhereAdd_surname,
					_whereAdd_first_name = WhereAdd_first_name,
					_whereAdd_birth_date = WhereAdd_birth_date,
					_whereAdd_sex = WhereAdd_sex,
					_whereAdd_phone_no = WhereAdd_phone_no,
					_whereAdd_doc_ohip_nbr = WhereAdd_doc_ohip_nbr,
					_whereAdd_accounting_nbr = WhereAdd_accounting_nbr,
                    _whereDebug_info = WhereDebug_info,
                    _whereError_flag = WhereError_flag,
                    _whereInput_file_location = WhereInput_file_location,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalAdd_address_line_1 = Reader["ADD_ADDRESS_LINE_1"].ToString(),
					_originalAdd_address_line_2 = Reader["ADD_ADDRESS_LINE_2"].ToString(),
					_originalAdd_address_line_3 = Reader["ADD_ADDRESS_LINE_3"].ToString(),
					_originalAdd_postal_code = Reader["ADD_POSTAL_CODE"].ToString(),
					_originalAdd_surname = Reader["ADD_SURNAME"].ToString(),
					_originalAdd_first_name = Reader["ADD_FIRST_NAME"].ToString(),
					_originalAdd_birth_date = ConvertDEC(Reader["ADD_BIRTH_DATE"]),
					_originalAdd_sex = Reader["ADD_SEX"].ToString(),
					_originalAdd_phone_no = Reader["ADD_PHONE_NO"].ToString(),
					_originalAdd_doc_ohip_nbr = ConvertDEC(Reader["ADD_DOC_OHIP_NBR"]),
					_originalAdd_accounting_nbr = Reader["ADD_ACCOUNTING_NBR"].ToString(),
                    _originalDebug_info = Reader["DEBUG_INFO"].ToString(),
                    _originalError_flag = ConvertDEC(Reader["ERROR_FLAG"]),
                    _originalInput_file_location = Reader["INPUT_FILE_LOCATION"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereAdd_address_line_1 = WhereAdd_address_line_1;
					_whereAdd_address_line_2 = WhereAdd_address_line_2;
					_whereAdd_address_line_3 = WhereAdd_address_line_3;
					_whereAdd_postal_code = WhereAdd_postal_code;
					_whereAdd_surname = WhereAdd_surname;
					_whereAdd_first_name = WhereAdd_first_name;
					_whereAdd_birth_date = WhereAdd_birth_date;
					_whereAdd_sex = WhereAdd_sex;
					_whereAdd_phone_no = WhereAdd_phone_no;
					_whereAdd_doc_ohip_nbr = WhereAdd_doc_ohip_nbr;
                    _whereAdd_accounting_nbr = WhereAdd_accounting_nbr;
                    _whereDebug_info = WhereDebug_info;
                    _whereError_flag = WhereError_flag;
                    _whereInput_file_location = WhereInput_file_location;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereAdd_address_line_1 == null 
				&& WhereAdd_address_line_2 == null 
				&& WhereAdd_address_line_3 == null 
				&& WhereAdd_postal_code == null 
				&& WhereAdd_surname == null 
				&& WhereAdd_first_name == null 
				&& WhereAdd_birth_date == null 
				&& WhereAdd_sex == null 
				&& WhereAdd_phone_no == null 
				&& WhereAdd_doc_ohip_nbr == null 
				&& WhereAdd_accounting_nbr == null
                && WhereDebug_info == null
                && WhereError_flag == null
                && WhereInput_file_location == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereAdd_address_line_1 ==  _whereAdd_address_line_1
				&& WhereAdd_address_line_2 ==  _whereAdd_address_line_2
				&& WhereAdd_address_line_3 ==  _whereAdd_address_line_3
				&& WhereAdd_postal_code ==  _whereAdd_postal_code
				&& WhereAdd_surname ==  _whereAdd_surname
				&& WhereAdd_first_name ==  _whereAdd_first_name
				&& WhereAdd_birth_date ==  _whereAdd_birth_date
				&& WhereAdd_sex ==  _whereAdd_sex
				&& WhereAdd_phone_no ==  _whereAdd_phone_no
				&& WhereAdd_doc_ohip_nbr ==  _whereAdd_doc_ohip_nbr
				&& WhereAdd_accounting_nbr ==  _whereAdd_accounting_nbr
                && WhereDebug_info == _whereDebug_info
                && WhereError_flag == _whereError_flag
                && WhereInput_file_location == _whereInput_file_location
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereAdd_address_line_1 = null; 
			WhereAdd_address_line_2 = null; 
			WhereAdd_address_line_3 = null; 
			WhereAdd_postal_code = null; 
			WhereAdd_surname = null; 
			WhereAdd_first_name = null; 
			WhereAdd_birth_date = null; 
			WhereAdd_sex = null; 
			WhereAdd_phone_no = null; 
			WhereAdd_doc_ohip_nbr = null; 
			WhereAdd_accounting_nbr = null;
            WhereDebug_info = null;
            WhereError_flag = null;
            WhereInput_file_location = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _ADD_ADDRESS_LINE_1;
		private string _ADD_ADDRESS_LINE_2;
		private string _ADD_ADDRESS_LINE_3;
		private string _ADD_POSTAL_CODE;
		private string _ADD_SURNAME;
		private string _ADD_FIRST_NAME;
		private decimal? _ADD_BIRTH_DATE;
		private string _ADD_SEX;
		private string _ADD_PHONE_NO;
		private decimal? _ADD_DOC_OHIP_NBR;
		private string _ADD_ACCOUNTING_NBR;
        private string _DEBUG_INFO;
        private decimal? _ERROR_FLAG;
        private string _INPUT_FILE_LOCATION;
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
		public string ADD_ADDRESS_LINE_1
		{
			get { return _ADD_ADDRESS_LINE_1; }
			set
			{
				if (_ADD_ADDRESS_LINE_1 != value)
				{
					_ADD_ADDRESS_LINE_1 = value;
					ChangeState();
				}
			}
		}
		public string ADD_ADDRESS_LINE_2
		{
			get { return _ADD_ADDRESS_LINE_2; }
			set
			{
				if (_ADD_ADDRESS_LINE_2 != value)
				{
					_ADD_ADDRESS_LINE_2 = value;
					ChangeState();
				}
			}
		}
		public string ADD_ADDRESS_LINE_3
		{
			get { return _ADD_ADDRESS_LINE_3; }
			set
			{
				if (_ADD_ADDRESS_LINE_3 != value)
				{
					_ADD_ADDRESS_LINE_3 = value;
					ChangeState();
				}
			}
		}
		public string ADD_POSTAL_CODE
		{
			get { return _ADD_POSTAL_CODE; }
			set
			{
				if (_ADD_POSTAL_CODE != value)
				{
					_ADD_POSTAL_CODE = value;
					ChangeState();
				}
			}
		}
		public string ADD_SURNAME
		{
			get { return _ADD_SURNAME; }
			set
			{
				if (_ADD_SURNAME != value)
				{
					_ADD_SURNAME = value;
					ChangeState();
				}
			}
		}
		public string ADD_FIRST_NAME
		{
			get { return _ADD_FIRST_NAME; }
			set
			{
				if (_ADD_FIRST_NAME != value)
				{
					_ADD_FIRST_NAME = value;
					ChangeState();
				}
			}
		}
		public decimal? ADD_BIRTH_DATE
		{
			get { return _ADD_BIRTH_DATE; }
			set
			{
				if (_ADD_BIRTH_DATE != value)
				{
					_ADD_BIRTH_DATE = value;
					ChangeState();
				}
			}
		}
		public string ADD_SEX
		{
			get { return _ADD_SEX; }
			set
			{
				if (_ADD_SEX != value)
				{
					_ADD_SEX = value;
					ChangeState();
				}
			}
		}
		public string ADD_PHONE_NO
		{
			get { return _ADD_PHONE_NO; }
			set
			{
				if (_ADD_PHONE_NO != value)
				{
					_ADD_PHONE_NO = value;
					ChangeState();
				}
			}
		}
		public decimal? ADD_DOC_OHIP_NBR
		{
			get { return _ADD_DOC_OHIP_NBR; }
			set
			{
				if (_ADD_DOC_OHIP_NBR != value)
				{
					_ADD_DOC_OHIP_NBR = value;
					ChangeState();
				}
			}
		}
		public string ADD_ACCOUNTING_NBR
		{
			get { return _ADD_ACCOUNTING_NBR; }
			set
			{
				if (_ADD_ACCOUNTING_NBR != value)
				{
					_ADD_ACCOUNTING_NBR = value;
					ChangeState();
				}
			}
		}
        public string DEBUG_INFO
        {
            get { return _DEBUG_INFO; }
            set
            {
                if (_DEBUG_INFO != value)
                {
                    _DEBUG_INFO = value;
                    ChangeState();
                }
            }
        }
        public decimal? ERROR_FLAG
        {
            get { return _ERROR_FLAG; }
            set
            {
                if (_ERROR_FLAG != value)
                {
                    _ERROR_FLAG = value;
                    ChangeState();
                }
            }
        }
        public string INPUT_FILE_LOCATION
        {
            get { return _INPUT_FILE_LOCATION; }
            set
            {
                if (_INPUT_FILE_LOCATION != value)
                {
                    _INPUT_FILE_LOCATION = value;
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
		public string WhereAdd_address_line_1 { get; set; }
		private string _whereAdd_address_line_1;
		public string WhereAdd_address_line_2 { get; set; }
		private string _whereAdd_address_line_2;
		public string WhereAdd_address_line_3 { get; set; }
		private string _whereAdd_address_line_3;
		public string WhereAdd_postal_code { get; set; }
		private string _whereAdd_postal_code;
		public string WhereAdd_surname { get; set; }
		private string _whereAdd_surname;
		public string WhereAdd_first_name { get; set; }
		private string _whereAdd_first_name;
		public decimal? WhereAdd_birth_date { get; set; }
		private decimal? _whereAdd_birth_date;
		public string WhereAdd_sex { get; set; }
		private string _whereAdd_sex;
		public string WhereAdd_phone_no { get; set; }
		private string _whereAdd_phone_no;
		public decimal? WhereAdd_doc_ohip_nbr { get; set; }
		private decimal? _whereAdd_doc_ohip_nbr;
		public string WhereAdd_accounting_nbr { get; set; }
		private string _whereAdd_accounting_nbr;
        public string WhereDebug_info { get; set; }
        private string _whereDebug_info;
        public decimal? WhereError_flag { get; set; }
        private decimal? _whereError_flag;
        public string WhereInput_file_location { get; set; }
        private string _whereInput_file_location;
        public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalAdd_address_line_1;
		private string _originalAdd_address_line_2;
		private string _originalAdd_address_line_3;
		private string _originalAdd_postal_code;
		private string _originalAdd_surname;
		private string _originalAdd_first_name;
		private decimal? _originalAdd_birth_date;
		private string _originalAdd_sex;
		private string _originalAdd_phone_no;
		private decimal? _originalAdd_doc_ohip_nbr;
		private string _originalAdd_accounting_nbr;
        private string _originalDebug_info;
        private decimal? _originalError_flag;
        private string _originalInput_file_location;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			ADD_ADDRESS_LINE_1 = _originalAdd_address_line_1;
			ADD_ADDRESS_LINE_2 = _originalAdd_address_line_2;
			ADD_ADDRESS_LINE_3 = _originalAdd_address_line_3;
			ADD_POSTAL_CODE = _originalAdd_postal_code;
			ADD_SURNAME = _originalAdd_surname;
			ADD_FIRST_NAME = _originalAdd_first_name;
			ADD_BIRTH_DATE = _originalAdd_birth_date;
			ADD_SEX = _originalAdd_sex;
			ADD_PHONE_NO = _originalAdd_phone_no;
			ADD_DOC_OHIP_NBR = _originalAdd_doc_ohip_nbr;
			ADD_ACCOUNTING_NBR = _originalAdd_accounting_nbr;
            DEBUG_INFO = _originalDebug_info;
            ERROR_FLAG = _originalError_flag;
            INPUT_FILE_LOCATION = _originalInput_file_location;
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
					new SqlParameter("ADD_DOC_OHIP_NBR",ADD_DOC_OHIP_NBR),
					new SqlParameter("ADD_ACCOUNTING_NBR",ADD_ACCOUNTING_NBR),
                    new SqlParameter("DEBUG_INFO", DEBUG_INFO),
                    new SqlParameter("ERROR_FLAG", ERROR_FLAG),
                    new SqlParameter("INPUT_FILE_LOCATION", INPUT_FILE_LOCATION)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F002_SUSPEND_ADDRESS_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F002_SUSPEND_ADDRESS_Purge]");
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
						new SqlParameter("ADD_ADDRESS_LINE_1", SqlNull(ADD_ADDRESS_LINE_1)),
						new SqlParameter("ADD_ADDRESS_LINE_2", SqlNull(ADD_ADDRESS_LINE_2)),
						new SqlParameter("ADD_ADDRESS_LINE_3", SqlNull(ADD_ADDRESS_LINE_3)),
						new SqlParameter("ADD_POSTAL_CODE", SqlNull(ADD_POSTAL_CODE)),
						new SqlParameter("ADD_SURNAME", SqlNull(ADD_SURNAME)),
						new SqlParameter("ADD_FIRST_NAME", SqlNull(ADD_FIRST_NAME)),
						new SqlParameter("ADD_BIRTH_DATE", SqlNull(ADD_BIRTH_DATE)),
						new SqlParameter("ADD_SEX", SqlNull(ADD_SEX)),
						new SqlParameter("ADD_PHONE_NO", SqlNull(ADD_PHONE_NO)),
						new SqlParameter("ADD_DOC_OHIP_NBR", SqlNull(ADD_DOC_OHIP_NBR)),
						new SqlParameter("ADD_ACCOUNTING_NBR", SqlNull(ADD_ACCOUNTING_NBR)),
                        new SqlParameter("DEBUG_INFO", SqlNull(DEBUG_INFO)),
                        new SqlParameter("ERROR_FLAG", SqlNull(ERROR_FLAG)),
                        new SqlParameter("INPUT_FILE_LOCATION", SqlNull(INPUT_FILE_LOCATION)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F002_SUSPEND_ADDRESS_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						ADD_ADDRESS_LINE_1 = Reader["ADD_ADDRESS_LINE_1"].ToString();
						ADD_ADDRESS_LINE_2 = Reader["ADD_ADDRESS_LINE_2"].ToString();
						ADD_ADDRESS_LINE_3 = Reader["ADD_ADDRESS_LINE_3"].ToString();
						ADD_POSTAL_CODE = Reader["ADD_POSTAL_CODE"].ToString();
						ADD_SURNAME = Reader["ADD_SURNAME"].ToString();
						ADD_FIRST_NAME = Reader["ADD_FIRST_NAME"].ToString();
						ADD_BIRTH_DATE = ConvertDEC(Reader["ADD_BIRTH_DATE"]);
						ADD_SEX = Reader["ADD_SEX"].ToString();
						ADD_PHONE_NO = Reader["ADD_PHONE_NO"].ToString();
						ADD_DOC_OHIP_NBR = ConvertDEC(Reader["ADD_DOC_OHIP_NBR"]);
						ADD_ACCOUNTING_NBR = Reader["ADD_ACCOUNTING_NBR"].ToString();
                        DEBUG_INFO = Reader["DEBUG_INFO"].ToString();
                        ERROR_FLAG = ConvertDEC(Reader["ERROR_FLAG"]);
                        INPUT_FILE_LOCATION = Reader["INPUT_FILE_LOCATION"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalAdd_address_line_1 = Reader["ADD_ADDRESS_LINE_1"].ToString();
						_originalAdd_address_line_2 = Reader["ADD_ADDRESS_LINE_2"].ToString();
						_originalAdd_address_line_3 = Reader["ADD_ADDRESS_LINE_3"].ToString();
						_originalAdd_postal_code = Reader["ADD_POSTAL_CODE"].ToString();
						_originalAdd_surname = Reader["ADD_SURNAME"].ToString();
						_originalAdd_first_name = Reader["ADD_FIRST_NAME"].ToString();
						_originalAdd_birth_date = ConvertDEC(Reader["ADD_BIRTH_DATE"]);
						_originalAdd_sex = Reader["ADD_SEX"].ToString();
						_originalAdd_phone_no = Reader["ADD_PHONE_NO"].ToString();
						_originalAdd_doc_ohip_nbr = ConvertDEC(Reader["ADD_DOC_OHIP_NBR"]);
						_originalAdd_accounting_nbr = Reader["ADD_ACCOUNTING_NBR"].ToString();
                        _originalDebug_info = Reader["DEBUG_INFO"].ToString();
                        _originalError_flag = ConvertDEC(Reader["ERROR_FLAG"]);
                        _originalInput_file_location = Reader["INPUT_FILE_LOCATION"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("ADD_ADDRESS_LINE_1", SqlNull(ADD_ADDRESS_LINE_1)),
						new SqlParameter("ADD_ADDRESS_LINE_2", SqlNull(ADD_ADDRESS_LINE_2)),
						new SqlParameter("ADD_ADDRESS_LINE_3", SqlNull(ADD_ADDRESS_LINE_3)),
						new SqlParameter("ADD_POSTAL_CODE", SqlNull(ADD_POSTAL_CODE)),
						new SqlParameter("ADD_SURNAME", SqlNull(ADD_SURNAME)),
						new SqlParameter("ADD_FIRST_NAME", SqlNull(ADD_FIRST_NAME)),
						new SqlParameter("ADD_BIRTH_DATE", SqlNull(ADD_BIRTH_DATE)),
						new SqlParameter("ADD_SEX", SqlNull(ADD_SEX)),
						new SqlParameter("ADD_PHONE_NO", SqlNull(ADD_PHONE_NO)),
						new SqlParameter("ADD_DOC_OHIP_NBR", SqlNull(ADD_DOC_OHIP_NBR)),
						new SqlParameter("ADD_ACCOUNTING_NBR", SqlNull(ADD_ACCOUNTING_NBR)),
                        new SqlParameter("DEBUG_INFO", SqlNull(DEBUG_INFO)),
                        new SqlParameter("ERROR_FLAG", SqlNull(ERROR_FLAG)),
                        new SqlParameter("INPUT_FILE_LOCATION", SqlNull(INPUT_FILE_LOCATION)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F002_SUSPEND_ADDRESS_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						ADD_ADDRESS_LINE_1 = Reader["ADD_ADDRESS_LINE_1"].ToString();
						ADD_ADDRESS_LINE_2 = Reader["ADD_ADDRESS_LINE_2"].ToString();
						ADD_ADDRESS_LINE_3 = Reader["ADD_ADDRESS_LINE_3"].ToString();
						ADD_POSTAL_CODE = Reader["ADD_POSTAL_CODE"].ToString();
						ADD_SURNAME = Reader["ADD_SURNAME"].ToString();
						ADD_FIRST_NAME = Reader["ADD_FIRST_NAME"].ToString();
						ADD_BIRTH_DATE = ConvertDEC(Reader["ADD_BIRTH_DATE"]);
						ADD_SEX = Reader["ADD_SEX"].ToString();
						ADD_PHONE_NO = Reader["ADD_PHONE_NO"].ToString();
						ADD_DOC_OHIP_NBR = ConvertDEC(Reader["ADD_DOC_OHIP_NBR"]);
						ADD_ACCOUNTING_NBR = Reader["ADD_ACCOUNTING_NBR"].ToString();
                        DEBUG_INFO = Reader["DEBUG_INFO"].ToString();
                        ERROR_FLAG = ConvertDEC(Reader["ERROR_FLAG"]);
                        INPUT_FILE_LOCATION = Reader["INPUT_FILE_LOCATION"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalAdd_address_line_1 = Reader["ADD_ADDRESS_LINE_1"].ToString();
						_originalAdd_address_line_2 = Reader["ADD_ADDRESS_LINE_2"].ToString();
						_originalAdd_address_line_3 = Reader["ADD_ADDRESS_LINE_3"].ToString();
						_originalAdd_postal_code = Reader["ADD_POSTAL_CODE"].ToString();
						_originalAdd_surname = Reader["ADD_SURNAME"].ToString();
						_originalAdd_first_name = Reader["ADD_FIRST_NAME"].ToString();
						_originalAdd_birth_date = ConvertDEC(Reader["ADD_BIRTH_DATE"]);
						_originalAdd_sex = Reader["ADD_SEX"].ToString();
						_originalAdd_phone_no = Reader["ADD_PHONE_NO"].ToString();
						_originalAdd_doc_ohip_nbr = ConvertDEC(Reader["ADD_DOC_OHIP_NBR"]);
						_originalAdd_accounting_nbr = Reader["ADD_ACCOUNTING_NBR"].ToString();
                        _originalDebug_info = Reader["DEBUG_INFO"].ToString();
                        _originalError_flag = ConvertDEC(Reader["ERROR_FLAG"]);
                        _originalInput_file_location = Reader["INPUT_FILE_LOCATION"].ToString();
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