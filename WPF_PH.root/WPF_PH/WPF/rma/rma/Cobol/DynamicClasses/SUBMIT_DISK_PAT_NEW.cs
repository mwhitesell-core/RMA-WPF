using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class SUBMIT_DISK_PAT_NEW : BaseTable
    {
        #region Retrieve

        public ObservableCollection<SUBMIT_DISK_PAT_NEW> Collection( Guid? rowid,
															string new_pat_ohip,
															string new_pat_surname,
															string new_pat_first_name,
															string new_pat_subscr_surname,
															string new_pat_address_line_1,
															string new_pat_address_line_2,
															string new_pat_address_line_3,
															string new_pat_address_prov_cd,
															string new_pat_postal_code,
															string new_pat_birth_date,
															string new_pat_sex,
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
					new SqlParameter("NEW_PAT_OHIP",new_pat_ohip),
					new SqlParameter("NEW_PAT_SURNAME",new_pat_surname),
					new SqlParameter("NEW_PAT_FIRST_NAME",new_pat_first_name),
					new SqlParameter("NEW_PAT_SUBSCR_SURNAME",new_pat_subscr_surname),
					new SqlParameter("NEW_PAT_ADDRESS_LINE_1",new_pat_address_line_1),
					new SqlParameter("NEW_PAT_ADDRESS_LINE_2",new_pat_address_line_2),
					new SqlParameter("NEW_PAT_ADDRESS_LINE_3",new_pat_address_line_3),
					new SqlParameter("NEW_PAT_ADDRESS_PROV_CD",new_pat_address_prov_cd),
					new SqlParameter("NEW_PAT_POSTAL_CODE",new_pat_postal_code),
					new SqlParameter("NEW_PAT_BIRTH_DATE",new_pat_birth_date),
					new SqlParameter("NEW_PAT_SEX",new_pat_sex),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[SEQUENTIAL].[sp_SUBMIT_DISK_PAT_NEW_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<SUBMIT_DISK_PAT_NEW>();
				}

            }

            Reader = CoreReader("[SEQUENTIAL].[sp_SUBMIT_DISK_PAT_NEW_Search]", parameters);
            var collection = new ObservableCollection<SUBMIT_DISK_PAT_NEW>();

            while (Reader.Read())
            {
                collection.Add(new SUBMIT_DISK_PAT_NEW
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					NEW_PAT_OHIP = Reader["NEW_PAT_OHIP"].ToString(),
					NEW_PAT_SURNAME = Reader["NEW_PAT_SURNAME"].ToString(),
					NEW_PAT_FIRST_NAME = Reader["NEW_PAT_FIRST_NAME"].ToString(),
					NEW_PAT_SUBSCR_SURNAME = Reader["NEW_PAT_SUBSCR_SURNAME"].ToString(),
					NEW_PAT_ADDRESS_LINE_1 = Reader["NEW_PAT_ADDRESS_LINE_1"].ToString(),
					NEW_PAT_ADDRESS_LINE_2 = Reader["NEW_PAT_ADDRESS_LINE_2"].ToString(),
					NEW_PAT_ADDRESS_LINE_3 = Reader["NEW_PAT_ADDRESS_LINE_3"].ToString(),
					NEW_PAT_ADDRESS_PROV_CD = Reader["NEW_PAT_ADDRESS_PROV_CD"].ToString(),
					NEW_PAT_POSTAL_CODE = Reader["NEW_PAT_POSTAL_CODE"].ToString(),
					NEW_PAT_BIRTH_DATE = Reader["NEW_PAT_BIRTH_DATE"].ToString(),
					NEW_PAT_SEX = Reader["NEW_PAT_SEX"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalNew_pat_ohip = Reader["NEW_PAT_OHIP"].ToString(),
					_originalNew_pat_surname = Reader["NEW_PAT_SURNAME"].ToString(),
					_originalNew_pat_first_name = Reader["NEW_PAT_FIRST_NAME"].ToString(),
					_originalNew_pat_subscr_surname = Reader["NEW_PAT_SUBSCR_SURNAME"].ToString(),
					_originalNew_pat_address_line_1 = Reader["NEW_PAT_ADDRESS_LINE_1"].ToString(),
					_originalNew_pat_address_line_2 = Reader["NEW_PAT_ADDRESS_LINE_2"].ToString(),
					_originalNew_pat_address_line_3 = Reader["NEW_PAT_ADDRESS_LINE_3"].ToString(),
					_originalNew_pat_address_prov_cd = Reader["NEW_PAT_ADDRESS_PROV_CD"].ToString(),
					_originalNew_pat_postal_code = Reader["NEW_PAT_POSTAL_CODE"].ToString(),
					_originalNew_pat_birth_date = Reader["NEW_PAT_BIRTH_DATE"].ToString(),
					_originalNew_pat_sex = Reader["NEW_PAT_SEX"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public SUBMIT_DISK_PAT_NEW Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<SUBMIT_DISK_PAT_NEW> Collection(ObservableCollection<SUBMIT_DISK_PAT_NEW>
                                                               submitDiskPatNew = null)
        {
            if (IsSameSearch() && submitDiskPatNew != null)
            {
                return submitDiskPatNew;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<SUBMIT_DISK_PAT_NEW>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("NEW_PAT_OHIP",WhereNew_pat_ohip),
					new SqlParameter("NEW_PAT_SURNAME",WhereNew_pat_surname),
					new SqlParameter("NEW_PAT_FIRST_NAME",WhereNew_pat_first_name),
					new SqlParameter("NEW_PAT_SUBSCR_SURNAME",WhereNew_pat_subscr_surname),
					new SqlParameter("NEW_PAT_ADDRESS_LINE_1",WhereNew_pat_address_line_1),
					new SqlParameter("NEW_PAT_ADDRESS_LINE_2",WhereNew_pat_address_line_2),
					new SqlParameter("NEW_PAT_ADDRESS_LINE_3",WhereNew_pat_address_line_3),
					new SqlParameter("NEW_PAT_ADDRESS_PROV_CD",WhereNew_pat_address_prov_cd),
					new SqlParameter("NEW_PAT_POSTAL_CODE",WhereNew_pat_postal_code),
					new SqlParameter("NEW_PAT_BIRTH_DATE",WhereNew_pat_birth_date),
					new SqlParameter("NEW_PAT_SEX",WhereNew_pat_sex),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[SEQUENTIAL].[sp_SUBMIT_DISK_PAT_NEW_Match]", parameters);
            var collection = new ObservableCollection<SUBMIT_DISK_PAT_NEW>();

            while (Reader.Read())
            {
                collection.Add(new SUBMIT_DISK_PAT_NEW
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					NEW_PAT_OHIP = Reader["NEW_PAT_OHIP"].ToString(),
					NEW_PAT_SURNAME = Reader["NEW_PAT_SURNAME"].ToString(),
					NEW_PAT_FIRST_NAME = Reader["NEW_PAT_FIRST_NAME"].ToString(),
					NEW_PAT_SUBSCR_SURNAME = Reader["NEW_PAT_SUBSCR_SURNAME"].ToString(),
					NEW_PAT_ADDRESS_LINE_1 = Reader["NEW_PAT_ADDRESS_LINE_1"].ToString(),
					NEW_PAT_ADDRESS_LINE_2 = Reader["NEW_PAT_ADDRESS_LINE_2"].ToString(),
					NEW_PAT_ADDRESS_LINE_3 = Reader["NEW_PAT_ADDRESS_LINE_3"].ToString(),
					NEW_PAT_ADDRESS_PROV_CD = Reader["NEW_PAT_ADDRESS_PROV_CD"].ToString(),
					NEW_PAT_POSTAL_CODE = Reader["NEW_PAT_POSTAL_CODE"].ToString(),
					NEW_PAT_BIRTH_DATE = Reader["NEW_PAT_BIRTH_DATE"].ToString(),
					NEW_PAT_SEX = Reader["NEW_PAT_SEX"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereNew_pat_ohip = WhereNew_pat_ohip,
					_whereNew_pat_surname = WhereNew_pat_surname,
					_whereNew_pat_first_name = WhereNew_pat_first_name,
					_whereNew_pat_subscr_surname = WhereNew_pat_subscr_surname,
					_whereNew_pat_address_line_1 = WhereNew_pat_address_line_1,
					_whereNew_pat_address_line_2 = WhereNew_pat_address_line_2,
					_whereNew_pat_address_line_3 = WhereNew_pat_address_line_3,
					_whereNew_pat_address_prov_cd = WhereNew_pat_address_prov_cd,
					_whereNew_pat_postal_code = WhereNew_pat_postal_code,
					_whereNew_pat_birth_date = WhereNew_pat_birth_date,
					_whereNew_pat_sex = WhereNew_pat_sex,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalNew_pat_ohip = Reader["NEW_PAT_OHIP"].ToString(),
					_originalNew_pat_surname = Reader["NEW_PAT_SURNAME"].ToString(),
					_originalNew_pat_first_name = Reader["NEW_PAT_FIRST_NAME"].ToString(),
					_originalNew_pat_subscr_surname = Reader["NEW_PAT_SUBSCR_SURNAME"].ToString(),
					_originalNew_pat_address_line_1 = Reader["NEW_PAT_ADDRESS_LINE_1"].ToString(),
					_originalNew_pat_address_line_2 = Reader["NEW_PAT_ADDRESS_LINE_2"].ToString(),
					_originalNew_pat_address_line_3 = Reader["NEW_PAT_ADDRESS_LINE_3"].ToString(),
					_originalNew_pat_address_prov_cd = Reader["NEW_PAT_ADDRESS_PROV_CD"].ToString(),
					_originalNew_pat_postal_code = Reader["NEW_PAT_POSTAL_CODE"].ToString(),
					_originalNew_pat_birth_date = Reader["NEW_PAT_BIRTH_DATE"].ToString(),
					_originalNew_pat_sex = Reader["NEW_PAT_SEX"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereNew_pat_ohip = WhereNew_pat_ohip;
					_whereNew_pat_surname = WhereNew_pat_surname;
					_whereNew_pat_first_name = WhereNew_pat_first_name;
					_whereNew_pat_subscr_surname = WhereNew_pat_subscr_surname;
					_whereNew_pat_address_line_1 = WhereNew_pat_address_line_1;
					_whereNew_pat_address_line_2 = WhereNew_pat_address_line_2;
					_whereNew_pat_address_line_3 = WhereNew_pat_address_line_3;
					_whereNew_pat_address_prov_cd = WhereNew_pat_address_prov_cd;
					_whereNew_pat_postal_code = WhereNew_pat_postal_code;
					_whereNew_pat_birth_date = WhereNew_pat_birth_date;
					_whereNew_pat_sex = WhereNew_pat_sex;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereNew_pat_ohip == null 
				&& WhereNew_pat_surname == null 
				&& WhereNew_pat_first_name == null 
				&& WhereNew_pat_subscr_surname == null 
				&& WhereNew_pat_address_line_1 == null 
				&& WhereNew_pat_address_line_2 == null 
				&& WhereNew_pat_address_line_3 == null 
				&& WhereNew_pat_address_prov_cd == null 
				&& WhereNew_pat_postal_code == null 
				&& WhereNew_pat_birth_date == null 
				&& WhereNew_pat_sex == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereNew_pat_ohip ==  _whereNew_pat_ohip
				&& WhereNew_pat_surname ==  _whereNew_pat_surname
				&& WhereNew_pat_first_name ==  _whereNew_pat_first_name
				&& WhereNew_pat_subscr_surname ==  _whereNew_pat_subscr_surname
				&& WhereNew_pat_address_line_1 ==  _whereNew_pat_address_line_1
				&& WhereNew_pat_address_line_2 ==  _whereNew_pat_address_line_2
				&& WhereNew_pat_address_line_3 ==  _whereNew_pat_address_line_3
				&& WhereNew_pat_address_prov_cd ==  _whereNew_pat_address_prov_cd
				&& WhereNew_pat_postal_code ==  _whereNew_pat_postal_code
				&& WhereNew_pat_birth_date ==  _whereNew_pat_birth_date
				&& WhereNew_pat_sex ==  _whereNew_pat_sex
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereNew_pat_ohip = null; 
			WhereNew_pat_surname = null; 
			WhereNew_pat_first_name = null; 
			WhereNew_pat_subscr_surname = null; 
			WhereNew_pat_address_line_1 = null; 
			WhereNew_pat_address_line_2 = null; 
			WhereNew_pat_address_line_3 = null; 
			WhereNew_pat_address_prov_cd = null; 
			WhereNew_pat_postal_code = null; 
			WhereNew_pat_birth_date = null; 
			WhereNew_pat_sex = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _NEW_PAT_OHIP;
		private string _NEW_PAT_SURNAME;
		private string _NEW_PAT_FIRST_NAME;
		private string _NEW_PAT_SUBSCR_SURNAME;
		private string _NEW_PAT_ADDRESS_LINE_1;
		private string _NEW_PAT_ADDRESS_LINE_2;
		private string _NEW_PAT_ADDRESS_LINE_3;
		private string _NEW_PAT_ADDRESS_PROV_CD;
		private string _NEW_PAT_POSTAL_CODE;
		private string _NEW_PAT_BIRTH_DATE;
		private string _NEW_PAT_SEX;
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
		public string NEW_PAT_OHIP
		{
			get { return _NEW_PAT_OHIP; }
			set
			{
				if (_NEW_PAT_OHIP != value)
				{
					_NEW_PAT_OHIP = value;
					ChangeState();
				}
			}
		}
		public string NEW_PAT_SURNAME
		{
			get { return _NEW_PAT_SURNAME; }
			set
			{
				if (_NEW_PAT_SURNAME != value)
				{
					_NEW_PAT_SURNAME = value;
					ChangeState();
				}
			}
		}
		public string NEW_PAT_FIRST_NAME
		{
			get { return _NEW_PAT_FIRST_NAME; }
			set
			{
				if (_NEW_PAT_FIRST_NAME != value)
				{
					_NEW_PAT_FIRST_NAME = value;
					ChangeState();
				}
			}
		}
		public string NEW_PAT_SUBSCR_SURNAME
		{
			get { return _NEW_PAT_SUBSCR_SURNAME; }
			set
			{
				if (_NEW_PAT_SUBSCR_SURNAME != value)
				{
					_NEW_PAT_SUBSCR_SURNAME = value;
					ChangeState();
				}
			}
		}
		public string NEW_PAT_ADDRESS_LINE_1
		{
			get { return _NEW_PAT_ADDRESS_LINE_1; }
			set
			{
				if (_NEW_PAT_ADDRESS_LINE_1 != value)
				{
					_NEW_PAT_ADDRESS_LINE_1 = value;
					ChangeState();
				}
			}
		}
		public string NEW_PAT_ADDRESS_LINE_2
		{
			get { return _NEW_PAT_ADDRESS_LINE_2; }
			set
			{
				if (_NEW_PAT_ADDRESS_LINE_2 != value)
				{
					_NEW_PAT_ADDRESS_LINE_2 = value;
					ChangeState();
				}
			}
		}
		public string NEW_PAT_ADDRESS_LINE_3
		{
			get { return _NEW_PAT_ADDRESS_LINE_3; }
			set
			{
				if (_NEW_PAT_ADDRESS_LINE_3 != value)
				{
					_NEW_PAT_ADDRESS_LINE_3 = value;
					ChangeState();
				}
			}
		}
		public string NEW_PAT_ADDRESS_PROV_CD
		{
			get { return _NEW_PAT_ADDRESS_PROV_CD; }
			set
			{
				if (_NEW_PAT_ADDRESS_PROV_CD != value)
				{
					_NEW_PAT_ADDRESS_PROV_CD = value;
					ChangeState();
				}
			}
		}
		public string NEW_PAT_POSTAL_CODE
		{
			get { return _NEW_PAT_POSTAL_CODE; }
			set
			{
				if (_NEW_PAT_POSTAL_CODE != value)
				{
					_NEW_PAT_POSTAL_CODE = value;
					ChangeState();
				}
			}
		}
		public string NEW_PAT_BIRTH_DATE
		{
			get { return _NEW_PAT_BIRTH_DATE; }
			set
			{
				if (_NEW_PAT_BIRTH_DATE != value)
				{
					_NEW_PAT_BIRTH_DATE = value;
					ChangeState();
				}
			}
		}
		public string NEW_PAT_SEX
		{
			get { return _NEW_PAT_SEX; }
			set
			{
				if (_NEW_PAT_SEX != value)
				{
					_NEW_PAT_SEX = value;
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
		public string WhereNew_pat_ohip { get; set; }
		private string _whereNew_pat_ohip;
		public string WhereNew_pat_surname { get; set; }
		private string _whereNew_pat_surname;
		public string WhereNew_pat_first_name { get; set; }
		private string _whereNew_pat_first_name;
		public string WhereNew_pat_subscr_surname { get; set; }
		private string _whereNew_pat_subscr_surname;
		public string WhereNew_pat_address_line_1 { get; set; }
		private string _whereNew_pat_address_line_1;
		public string WhereNew_pat_address_line_2 { get; set; }
		private string _whereNew_pat_address_line_2;
		public string WhereNew_pat_address_line_3 { get; set; }
		private string _whereNew_pat_address_line_3;
		public string WhereNew_pat_address_prov_cd { get; set; }
		private string _whereNew_pat_address_prov_cd;
		public string WhereNew_pat_postal_code { get; set; }
		private string _whereNew_pat_postal_code;
		public string WhereNew_pat_birth_date { get; set; }
		private string _whereNew_pat_birth_date;
		public string WhereNew_pat_sex { get; set; }
		private string _whereNew_pat_sex;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalNew_pat_ohip;
		private string _originalNew_pat_surname;
		private string _originalNew_pat_first_name;
		private string _originalNew_pat_subscr_surname;
		private string _originalNew_pat_address_line_1;
		private string _originalNew_pat_address_line_2;
		private string _originalNew_pat_address_line_3;
		private string _originalNew_pat_address_prov_cd;
		private string _originalNew_pat_postal_code;
		private string _originalNew_pat_birth_date;
		private string _originalNew_pat_sex;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			NEW_PAT_OHIP = _originalNew_pat_ohip;
			NEW_PAT_SURNAME = _originalNew_pat_surname;
			NEW_PAT_FIRST_NAME = _originalNew_pat_first_name;
			NEW_PAT_SUBSCR_SURNAME = _originalNew_pat_subscr_surname;
			NEW_PAT_ADDRESS_LINE_1 = _originalNew_pat_address_line_1;
			NEW_PAT_ADDRESS_LINE_2 = _originalNew_pat_address_line_2;
			NEW_PAT_ADDRESS_LINE_3 = _originalNew_pat_address_line_3;
			NEW_PAT_ADDRESS_PROV_CD = _originalNew_pat_address_prov_cd;
			NEW_PAT_POSTAL_CODE = _originalNew_pat_postal_code;
			NEW_PAT_BIRTH_DATE = _originalNew_pat_birth_date;
			NEW_PAT_SEX = _originalNew_pat_sex;
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
			RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_SUBMIT_DISK_PAT_NEW_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_SUBMIT_DISK_PAT_NEW_Purge]");
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
						new SqlParameter("NEW_PAT_OHIP", SqlNull(NEW_PAT_OHIP)),
						new SqlParameter("NEW_PAT_SURNAME", SqlNull(NEW_PAT_SURNAME)),
						new SqlParameter("NEW_PAT_FIRST_NAME", SqlNull(NEW_PAT_FIRST_NAME)),
						new SqlParameter("NEW_PAT_SUBSCR_SURNAME", SqlNull(NEW_PAT_SUBSCR_SURNAME)),
						new SqlParameter("NEW_PAT_ADDRESS_LINE_1", SqlNull(NEW_PAT_ADDRESS_LINE_1)),
						new SqlParameter("NEW_PAT_ADDRESS_LINE_2", SqlNull(NEW_PAT_ADDRESS_LINE_2)),
						new SqlParameter("NEW_PAT_ADDRESS_LINE_3", SqlNull(NEW_PAT_ADDRESS_LINE_3)),
						new SqlParameter("NEW_PAT_ADDRESS_PROV_CD", SqlNull(NEW_PAT_ADDRESS_PROV_CD)),
						new SqlParameter("NEW_PAT_POSTAL_CODE", SqlNull(NEW_PAT_POSTAL_CODE)),
						new SqlParameter("NEW_PAT_BIRTH_DATE", SqlNull(NEW_PAT_BIRTH_DATE)),
						new SqlParameter("NEW_PAT_SEX", SqlNull(NEW_PAT_SEX)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_SUBMIT_DISK_PAT_NEW_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						NEW_PAT_OHIP = Reader["NEW_PAT_OHIP"].ToString();
						NEW_PAT_SURNAME = Reader["NEW_PAT_SURNAME"].ToString();
						NEW_PAT_FIRST_NAME = Reader["NEW_PAT_FIRST_NAME"].ToString();
						NEW_PAT_SUBSCR_SURNAME = Reader["NEW_PAT_SUBSCR_SURNAME"].ToString();
						NEW_PAT_ADDRESS_LINE_1 = Reader["NEW_PAT_ADDRESS_LINE_1"].ToString();
						NEW_PAT_ADDRESS_LINE_2 = Reader["NEW_PAT_ADDRESS_LINE_2"].ToString();
						NEW_PAT_ADDRESS_LINE_3 = Reader["NEW_PAT_ADDRESS_LINE_3"].ToString();
						NEW_PAT_ADDRESS_PROV_CD = Reader["NEW_PAT_ADDRESS_PROV_CD"].ToString();
						NEW_PAT_POSTAL_CODE = Reader["NEW_PAT_POSTAL_CODE"].ToString();
						NEW_PAT_BIRTH_DATE = Reader["NEW_PAT_BIRTH_DATE"].ToString();
						NEW_PAT_SEX = Reader["NEW_PAT_SEX"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalNew_pat_ohip = Reader["NEW_PAT_OHIP"].ToString();
						_originalNew_pat_surname = Reader["NEW_PAT_SURNAME"].ToString();
						_originalNew_pat_first_name = Reader["NEW_PAT_FIRST_NAME"].ToString();
						_originalNew_pat_subscr_surname = Reader["NEW_PAT_SUBSCR_SURNAME"].ToString();
						_originalNew_pat_address_line_1 = Reader["NEW_PAT_ADDRESS_LINE_1"].ToString();
						_originalNew_pat_address_line_2 = Reader["NEW_PAT_ADDRESS_LINE_2"].ToString();
						_originalNew_pat_address_line_3 = Reader["NEW_PAT_ADDRESS_LINE_3"].ToString();
						_originalNew_pat_address_prov_cd = Reader["NEW_PAT_ADDRESS_PROV_CD"].ToString();
						_originalNew_pat_postal_code = Reader["NEW_PAT_POSTAL_CODE"].ToString();
						_originalNew_pat_birth_date = Reader["NEW_PAT_BIRTH_DATE"].ToString();
						_originalNew_pat_sex = Reader["NEW_PAT_SEX"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("NEW_PAT_OHIP", SqlNull(NEW_PAT_OHIP)),
						new SqlParameter("NEW_PAT_SURNAME", SqlNull(NEW_PAT_SURNAME)),
						new SqlParameter("NEW_PAT_FIRST_NAME", SqlNull(NEW_PAT_FIRST_NAME)),
						new SqlParameter("NEW_PAT_SUBSCR_SURNAME", SqlNull(NEW_PAT_SUBSCR_SURNAME)),
						new SqlParameter("NEW_PAT_ADDRESS_LINE_1", SqlNull(NEW_PAT_ADDRESS_LINE_1)),
						new SqlParameter("NEW_PAT_ADDRESS_LINE_2", SqlNull(NEW_PAT_ADDRESS_LINE_2)),
						new SqlParameter("NEW_PAT_ADDRESS_LINE_3", SqlNull(NEW_PAT_ADDRESS_LINE_3)),
						new SqlParameter("NEW_PAT_ADDRESS_PROV_CD", SqlNull(NEW_PAT_ADDRESS_PROV_CD)),
						new SqlParameter("NEW_PAT_POSTAL_CODE", SqlNull(NEW_PAT_POSTAL_CODE)),
						new SqlParameter("NEW_PAT_BIRTH_DATE", SqlNull(NEW_PAT_BIRTH_DATE)),
						new SqlParameter("NEW_PAT_SEX", SqlNull(NEW_PAT_SEX)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_SUBMIT_DISK_PAT_NEW_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						NEW_PAT_OHIP = Reader["NEW_PAT_OHIP"].ToString();
						NEW_PAT_SURNAME = Reader["NEW_PAT_SURNAME"].ToString();
						NEW_PAT_FIRST_NAME = Reader["NEW_PAT_FIRST_NAME"].ToString();
						NEW_PAT_SUBSCR_SURNAME = Reader["NEW_PAT_SUBSCR_SURNAME"].ToString();
						NEW_PAT_ADDRESS_LINE_1 = Reader["NEW_PAT_ADDRESS_LINE_1"].ToString();
						NEW_PAT_ADDRESS_LINE_2 = Reader["NEW_PAT_ADDRESS_LINE_2"].ToString();
						NEW_PAT_ADDRESS_LINE_3 = Reader["NEW_PAT_ADDRESS_LINE_3"].ToString();
						NEW_PAT_ADDRESS_PROV_CD = Reader["NEW_PAT_ADDRESS_PROV_CD"].ToString();
						NEW_PAT_POSTAL_CODE = Reader["NEW_PAT_POSTAL_CODE"].ToString();
						NEW_PAT_BIRTH_DATE = Reader["NEW_PAT_BIRTH_DATE"].ToString();
						NEW_PAT_SEX = Reader["NEW_PAT_SEX"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalNew_pat_ohip = Reader["NEW_PAT_OHIP"].ToString();
						_originalNew_pat_surname = Reader["NEW_PAT_SURNAME"].ToString();
						_originalNew_pat_first_name = Reader["NEW_PAT_FIRST_NAME"].ToString();
						_originalNew_pat_subscr_surname = Reader["NEW_PAT_SUBSCR_SURNAME"].ToString();
						_originalNew_pat_address_line_1 = Reader["NEW_PAT_ADDRESS_LINE_1"].ToString();
						_originalNew_pat_address_line_2 = Reader["NEW_PAT_ADDRESS_LINE_2"].ToString();
						_originalNew_pat_address_line_3 = Reader["NEW_PAT_ADDRESS_LINE_3"].ToString();
						_originalNew_pat_address_prov_cd = Reader["NEW_PAT_ADDRESS_PROV_CD"].ToString();
						_originalNew_pat_postal_code = Reader["NEW_PAT_POSTAL_CODE"].ToString();
						_originalNew_pat_birth_date = Reader["NEW_PAT_BIRTH_DATE"].ToString();
						_originalNew_pat_sex = Reader["NEW_PAT_SEX"].ToString();
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