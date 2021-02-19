using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F028_CONTACTS_INFO_MSTR : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F028_CONTACTS_INFO_MSTR> Collection( Guid? rowid,
															string filler,
															string doc_nbr,
															string contacts_type,
															string contacts_location,
															string contacts_addr_1,
															string contacts_addr_2,
															string contacts_addr_3,
															string postal_code,
															string contacts_email_addr,
															decimal? contacts_phone_nbrmin,
															decimal? contacts_phone_nbrmax,
															decimal? contacts_phone_extmin,
															decimal? contacts_phone_extmax,
															decimal? contacts_pager_nbrmin,
															decimal? contacts_pager_nbrmax,
															decimal? contacts_cell_nbrmin,
															decimal? contacts_cell_nbrmax,
															decimal? contacts_fax_nbrmin,
															decimal? contacts_fax_nbrmax,
															string newsletter_flag,
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
					new SqlParameter("CONTACTS_LOCATION",contacts_location),
					new SqlParameter("CONTACTS_ADDR_1",contacts_addr_1),
					new SqlParameter("CONTACTS_ADDR_2",contacts_addr_2),
					new SqlParameter("CONTACTS_ADDR_3",contacts_addr_3),
					new SqlParameter("POSTAL_CODE",postal_code),
					new SqlParameter("CONTACTS_EMAIL_ADDR",contacts_email_addr),
					new SqlParameter("minCONTACTS_PHONE_NBR",contacts_phone_nbrmin),
					new SqlParameter("maxCONTACTS_PHONE_NBR",contacts_phone_nbrmax),
					new SqlParameter("minCONTACTS_PHONE_EXT",contacts_phone_extmin),
					new SqlParameter("maxCONTACTS_PHONE_EXT",contacts_phone_extmax),
					new SqlParameter("minCONTACTS_PAGER_NBR",contacts_pager_nbrmin),
					new SqlParameter("maxCONTACTS_PAGER_NBR",contacts_pager_nbrmax),
					new SqlParameter("minCONTACTS_CELL_NBR",contacts_cell_nbrmin),
					new SqlParameter("maxCONTACTS_CELL_NBR",contacts_cell_nbrmax),
					new SqlParameter("minCONTACTS_FAX_NBR",contacts_fax_nbrmin),
					new SqlParameter("maxCONTACTS_FAX_NBR",contacts_fax_nbrmax),
					new SqlParameter("NEWSLETTER_FLAG",newsletter_flag),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F028_CONTACTS_INFO_MSTR_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F028_CONTACTS_INFO_MSTR>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F028_CONTACTS_INFO_MSTR_Search]", parameters);
            var collection = new ObservableCollection<F028_CONTACTS_INFO_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F028_CONTACTS_INFO_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					FILLER = Reader["FILLER"].ToString(),
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					CONTACTS_TYPE = Reader["CONTACTS_TYPE"].ToString(),
					CONTACTS_LOCATION = Reader["CONTACTS_LOCATION"].ToString(),
					CONTACTS_ADDR_1 = Reader["CONTACTS_ADDR_1"].ToString(),
					CONTACTS_ADDR_2 = Reader["CONTACTS_ADDR_2"].ToString(),
					CONTACTS_ADDR_3 = Reader["CONTACTS_ADDR_3"].ToString(),
					POSTAL_CODE = Reader["POSTAL_CODE"].ToString(),
					CONTACTS_EMAIL_ADDR = Reader["CONTACTS_EMAIL_ADDR"].ToString(),
					CONTACTS_PHONE_NBR = ConvertDEC(Reader["CONTACTS_PHONE_NBR"]),
					CONTACTS_PHONE_EXT = ConvertDEC(Reader["CONTACTS_PHONE_EXT"]),
					CONTACTS_PAGER_NBR = ConvertDEC(Reader["CONTACTS_PAGER_NBR"]),
					CONTACTS_CELL_NBR = ConvertDEC(Reader["CONTACTS_CELL_NBR"]),
					CONTACTS_FAX_NBR = ConvertDEC(Reader["CONTACTS_FAX_NBR"]),
					NEWSLETTER_FLAG = Reader["NEWSLETTER_FLAG"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalFiller = Reader["FILLER"].ToString(),
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalContacts_type = Reader["CONTACTS_TYPE"].ToString(),
					_originalContacts_location = Reader["CONTACTS_LOCATION"].ToString(),
					_originalContacts_addr_1 = Reader["CONTACTS_ADDR_1"].ToString(),
					_originalContacts_addr_2 = Reader["CONTACTS_ADDR_2"].ToString(),
					_originalContacts_addr_3 = Reader["CONTACTS_ADDR_3"].ToString(),
					_originalPostal_code = Reader["POSTAL_CODE"].ToString(),
					_originalContacts_email_addr = Reader["CONTACTS_EMAIL_ADDR"].ToString(),
					_originalContacts_phone_nbr = ConvertDEC(Reader["CONTACTS_PHONE_NBR"]),
					_originalContacts_phone_ext = ConvertDEC(Reader["CONTACTS_PHONE_EXT"]),
					_originalContacts_pager_nbr = ConvertDEC(Reader["CONTACTS_PAGER_NBR"]),
					_originalContacts_cell_nbr = ConvertDEC(Reader["CONTACTS_CELL_NBR"]),
					_originalContacts_fax_nbr = ConvertDEC(Reader["CONTACTS_FAX_NBR"]),
					_originalNewsletter_flag = Reader["NEWSLETTER_FLAG"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F028_CONTACTS_INFO_MSTR Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F028_CONTACTS_INFO_MSTR> Collection(ObservableCollection<F028_CONTACTS_INFO_MSTR>
                                                               f028ContactsInfoMstr = null)
        {
            if (IsSameSearch() && f028ContactsInfoMstr != null)
            {
                return f028ContactsInfoMstr;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F028_CONTACTS_INFO_MSTR>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("FILLER",WhereFiller),
					new SqlParameter("DOC_NBR",WhereDoc_nbr),
					new SqlParameter("CONTACTS_TYPE",WhereContacts_type),
					new SqlParameter("CONTACTS_LOCATION",WhereContacts_location),
					new SqlParameter("CONTACTS_ADDR_1",WhereContacts_addr_1),
					new SqlParameter("CONTACTS_ADDR_2",WhereContacts_addr_2),
					new SqlParameter("CONTACTS_ADDR_3",WhereContacts_addr_3),
					new SqlParameter("POSTAL_CODE",WherePostal_code),
					new SqlParameter("CONTACTS_EMAIL_ADDR",WhereContacts_email_addr),
					new SqlParameter("CONTACTS_PHONE_NBR",WhereContacts_phone_nbr),
					new SqlParameter("CONTACTS_PHONE_EXT",WhereContacts_phone_ext),
					new SqlParameter("CONTACTS_PAGER_NBR",WhereContacts_pager_nbr),
					new SqlParameter("CONTACTS_CELL_NBR",WhereContacts_cell_nbr),
					new SqlParameter("CONTACTS_FAX_NBR",WhereContacts_fax_nbr),
					new SqlParameter("NEWSLETTER_FLAG",WhereNewsletter_flag),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F028_CONTACTS_INFO_MSTR_Match]", parameters);
            var collection = new ObservableCollection<F028_CONTACTS_INFO_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F028_CONTACTS_INFO_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					FILLER = Reader["FILLER"].ToString(),
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					CONTACTS_TYPE = Reader["CONTACTS_TYPE"].ToString(),
					CONTACTS_LOCATION = Reader["CONTACTS_LOCATION"].ToString(),
					CONTACTS_ADDR_1 = Reader["CONTACTS_ADDR_1"].ToString(),
					CONTACTS_ADDR_2 = Reader["CONTACTS_ADDR_2"].ToString(),
					CONTACTS_ADDR_3 = Reader["CONTACTS_ADDR_3"].ToString(),
					POSTAL_CODE = Reader["POSTAL_CODE"].ToString(),
					CONTACTS_EMAIL_ADDR = Reader["CONTACTS_EMAIL_ADDR"].ToString(),
					CONTACTS_PHONE_NBR = ConvertDEC(Reader["CONTACTS_PHONE_NBR"]),
					CONTACTS_PHONE_EXT = ConvertDEC(Reader["CONTACTS_PHONE_EXT"]),
					CONTACTS_PAGER_NBR = ConvertDEC(Reader["CONTACTS_PAGER_NBR"]),
					CONTACTS_CELL_NBR = ConvertDEC(Reader["CONTACTS_CELL_NBR"]),
					CONTACTS_FAX_NBR = ConvertDEC(Reader["CONTACTS_FAX_NBR"]),
					NEWSLETTER_FLAG = Reader["NEWSLETTER_FLAG"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereFiller = WhereFiller,
					_whereDoc_nbr = WhereDoc_nbr,
					_whereContacts_type = WhereContacts_type,
					_whereContacts_location = WhereContacts_location,
					_whereContacts_addr_1 = WhereContacts_addr_1,
					_whereContacts_addr_2 = WhereContacts_addr_2,
					_whereContacts_addr_3 = WhereContacts_addr_3,
					_wherePostal_code = WherePostal_code,
					_whereContacts_email_addr = WhereContacts_email_addr,
					_whereContacts_phone_nbr = WhereContacts_phone_nbr,
					_whereContacts_phone_ext = WhereContacts_phone_ext,
					_whereContacts_pager_nbr = WhereContacts_pager_nbr,
					_whereContacts_cell_nbr = WhereContacts_cell_nbr,
					_whereContacts_fax_nbr = WhereContacts_fax_nbr,
					_whereNewsletter_flag = WhereNewsletter_flag,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalFiller = Reader["FILLER"].ToString(),
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalContacts_type = Reader["CONTACTS_TYPE"].ToString(),
					_originalContacts_location = Reader["CONTACTS_LOCATION"].ToString(),
					_originalContacts_addr_1 = Reader["CONTACTS_ADDR_1"].ToString(),
					_originalContacts_addr_2 = Reader["CONTACTS_ADDR_2"].ToString(),
					_originalContacts_addr_3 = Reader["CONTACTS_ADDR_3"].ToString(),
					_originalPostal_code = Reader["POSTAL_CODE"].ToString(),
					_originalContacts_email_addr = Reader["CONTACTS_EMAIL_ADDR"].ToString(),
					_originalContacts_phone_nbr = ConvertDEC(Reader["CONTACTS_PHONE_NBR"]),
					_originalContacts_phone_ext = ConvertDEC(Reader["CONTACTS_PHONE_EXT"]),
					_originalContacts_pager_nbr = ConvertDEC(Reader["CONTACTS_PAGER_NBR"]),
					_originalContacts_cell_nbr = ConvertDEC(Reader["CONTACTS_CELL_NBR"]),
					_originalContacts_fax_nbr = ConvertDEC(Reader["CONTACTS_FAX_NBR"]),
					_originalNewsletter_flag = Reader["NEWSLETTER_FLAG"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereFiller = WhereFiller;
					_whereDoc_nbr = WhereDoc_nbr;
					_whereContacts_type = WhereContacts_type;
					_whereContacts_location = WhereContacts_location;
					_whereContacts_addr_1 = WhereContacts_addr_1;
					_whereContacts_addr_2 = WhereContacts_addr_2;
					_whereContacts_addr_3 = WhereContacts_addr_3;
					_wherePostal_code = WherePostal_code;
					_whereContacts_email_addr = WhereContacts_email_addr;
					_whereContacts_phone_nbr = WhereContacts_phone_nbr;
					_whereContacts_phone_ext = WhereContacts_phone_ext;
					_whereContacts_pager_nbr = WhereContacts_pager_nbr;
					_whereContacts_cell_nbr = WhereContacts_cell_nbr;
					_whereContacts_fax_nbr = WhereContacts_fax_nbr;
					_whereNewsletter_flag = WhereNewsletter_flag;
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
				&& WhereContacts_location == null 
				&& WhereContacts_addr_1 == null 
				&& WhereContacts_addr_2 == null 
				&& WhereContacts_addr_3 == null 
				&& WherePostal_code == null 
				&& WhereContacts_email_addr == null 
				&& WhereContacts_phone_nbr == null 
				&& WhereContacts_phone_ext == null 
				&& WhereContacts_pager_nbr == null 
				&& WhereContacts_cell_nbr == null 
				&& WhereContacts_fax_nbr == null 
				&& WhereNewsletter_flag == null 
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
				&& WhereContacts_location ==  _whereContacts_location
				&& WhereContacts_addr_1 ==  _whereContacts_addr_1
				&& WhereContacts_addr_2 ==  _whereContacts_addr_2
				&& WhereContacts_addr_3 ==  _whereContacts_addr_3
				&& WherePostal_code ==  _wherePostal_code
				&& WhereContacts_email_addr ==  _whereContacts_email_addr
				&& WhereContacts_phone_nbr ==  _whereContacts_phone_nbr
				&& WhereContacts_phone_ext ==  _whereContacts_phone_ext
				&& WhereContacts_pager_nbr ==  _whereContacts_pager_nbr
				&& WhereContacts_cell_nbr ==  _whereContacts_cell_nbr
				&& WhereContacts_fax_nbr ==  _whereContacts_fax_nbr
				&& WhereNewsletter_flag ==  _whereNewsletter_flag
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereFiller = null; 
			WhereDoc_nbr = null; 
			WhereContacts_type = null; 
			WhereContacts_location = null; 
			WhereContacts_addr_1 = null; 
			WhereContacts_addr_2 = null; 
			WhereContacts_addr_3 = null; 
			WherePostal_code = null; 
			WhereContacts_email_addr = null; 
			WhereContacts_phone_nbr = null; 
			WhereContacts_phone_ext = null; 
			WhereContacts_pager_nbr = null; 
			WhereContacts_cell_nbr = null; 
			WhereContacts_fax_nbr = null; 
			WhereNewsletter_flag = null; 
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
		private string _CONTACTS_LOCATION;
		private string _CONTACTS_ADDR_1;
		private string _CONTACTS_ADDR_2;
		private string _CONTACTS_ADDR_3;
		private string _POSTAL_CODE;
		private string _CONTACTS_EMAIL_ADDR;
		private decimal? _CONTACTS_PHONE_NBR;
		private decimal? _CONTACTS_PHONE_EXT;
		private decimal? _CONTACTS_PAGER_NBR;
		private decimal? _CONTACTS_CELL_NBR;
		private decimal? _CONTACTS_FAX_NBR;
		private string _NEWSLETTER_FLAG;
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
		public string CONTACTS_LOCATION
		{
			get { return _CONTACTS_LOCATION; }
			set
			{
				if (_CONTACTS_LOCATION != value)
				{
					_CONTACTS_LOCATION = value;
					ChangeState();
				}
			}
		}
		public string CONTACTS_ADDR_1
		{
			get { return _CONTACTS_ADDR_1; }
			set
			{
				if (_CONTACTS_ADDR_1 != value)
				{
					_CONTACTS_ADDR_1 = value;
					ChangeState();
				}
			}
		}
		public string CONTACTS_ADDR_2
		{
			get { return _CONTACTS_ADDR_2; }
			set
			{
				if (_CONTACTS_ADDR_2 != value)
				{
					_CONTACTS_ADDR_2 = value;
					ChangeState();
				}
			}
		}
		public string CONTACTS_ADDR_3
		{
			get { return _CONTACTS_ADDR_3; }
			set
			{
				if (_CONTACTS_ADDR_3 != value)
				{
					_CONTACTS_ADDR_3 = value;
					ChangeState();
				}
			}
		}
		public string POSTAL_CODE
		{
			get { return _POSTAL_CODE; }
			set
			{
				if (_POSTAL_CODE != value)
				{
					_POSTAL_CODE = value;
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
		public decimal? CONTACTS_PHONE_NBR
		{
			get { return _CONTACTS_PHONE_NBR; }
			set
			{
				if (_CONTACTS_PHONE_NBR != value)
				{
					_CONTACTS_PHONE_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? CONTACTS_PHONE_EXT
		{
			get { return _CONTACTS_PHONE_EXT; }
			set
			{
				if (_CONTACTS_PHONE_EXT != value)
				{
					_CONTACTS_PHONE_EXT = value;
					ChangeState();
				}
			}
		}
		public decimal? CONTACTS_PAGER_NBR
		{
			get { return _CONTACTS_PAGER_NBR; }
			set
			{
				if (_CONTACTS_PAGER_NBR != value)
				{
					_CONTACTS_PAGER_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? CONTACTS_CELL_NBR
		{
			get { return _CONTACTS_CELL_NBR; }
			set
			{
				if (_CONTACTS_CELL_NBR != value)
				{
					_CONTACTS_CELL_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? CONTACTS_FAX_NBR
		{
			get { return _CONTACTS_FAX_NBR; }
			set
			{
				if (_CONTACTS_FAX_NBR != value)
				{
					_CONTACTS_FAX_NBR = value;
					ChangeState();
				}
			}
		}
		public string NEWSLETTER_FLAG
		{
			get { return _NEWSLETTER_FLAG; }
			set
			{
				if (_NEWSLETTER_FLAG != value)
				{
					_NEWSLETTER_FLAG = value;
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
		public string WhereContacts_location { get; set; }
		private string _whereContacts_location;
		public string WhereContacts_addr_1 { get; set; }
		private string _whereContacts_addr_1;
		public string WhereContacts_addr_2 { get; set; }
		private string _whereContacts_addr_2;
		public string WhereContacts_addr_3 { get; set; }
		private string _whereContacts_addr_3;
		public string WherePostal_code { get; set; }
		private string _wherePostal_code;
		public string WhereContacts_email_addr { get; set; }
		private string _whereContacts_email_addr;
		public decimal? WhereContacts_phone_nbr { get; set; }
		private decimal? _whereContacts_phone_nbr;
		public decimal? WhereContacts_phone_ext { get; set; }
		private decimal? _whereContacts_phone_ext;
		public decimal? WhereContacts_pager_nbr { get; set; }
		private decimal? _whereContacts_pager_nbr;
		public decimal? WhereContacts_cell_nbr { get; set; }
		private decimal? _whereContacts_cell_nbr;
		public decimal? WhereContacts_fax_nbr { get; set; }
		private decimal? _whereContacts_fax_nbr;
		public string WhereNewsletter_flag { get; set; }
		private string _whereNewsletter_flag;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalFiller;
		private string _originalDoc_nbr;
		private string _originalContacts_type;
		private string _originalContacts_location;
		private string _originalContacts_addr_1;
		private string _originalContacts_addr_2;
		private string _originalContacts_addr_3;
		private string _originalPostal_code;
		private string _originalContacts_email_addr;
		private decimal? _originalContacts_phone_nbr;
		private decimal? _originalContacts_phone_ext;
		private decimal? _originalContacts_pager_nbr;
		private decimal? _originalContacts_cell_nbr;
		private decimal? _originalContacts_fax_nbr;
		private string _originalNewsletter_flag;
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
			CONTACTS_LOCATION = _originalContacts_location;
			CONTACTS_ADDR_1 = _originalContacts_addr_1;
			CONTACTS_ADDR_2 = _originalContacts_addr_2;
			CONTACTS_ADDR_3 = _originalContacts_addr_3;
			POSTAL_CODE = _originalPostal_code;
			CONTACTS_EMAIL_ADDR = _originalContacts_email_addr;
			CONTACTS_PHONE_NBR = _originalContacts_phone_nbr;
			CONTACTS_PHONE_EXT = _originalContacts_phone_ext;
			CONTACTS_PAGER_NBR = _originalContacts_pager_nbr;
			CONTACTS_CELL_NBR = _originalContacts_cell_nbr;
			CONTACTS_FAX_NBR = _originalContacts_fax_nbr;
			NEWSLETTER_FLAG = _originalNewsletter_flag;
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
					new SqlParameter("CONTACTS_TYPE",CONTACTS_TYPE),
					new SqlParameter("CONTACTS_LOCATION",CONTACTS_LOCATION)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F028_CONTACTS_INFO_MSTR_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F028_CONTACTS_INFO_MSTR_Purge]");
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
						new SqlParameter("CONTACTS_LOCATION", SqlNull(CONTACTS_LOCATION)),
						new SqlParameter("CONTACTS_ADDR_1", SqlNull(CONTACTS_ADDR_1)),
						new SqlParameter("CONTACTS_ADDR_2", SqlNull(CONTACTS_ADDR_2)),
						new SqlParameter("CONTACTS_ADDR_3", SqlNull(CONTACTS_ADDR_3)),
						new SqlParameter("POSTAL_CODE", SqlNull(POSTAL_CODE)),
						new SqlParameter("CONTACTS_EMAIL_ADDR", SqlNull(CONTACTS_EMAIL_ADDR)),
						new SqlParameter("CONTACTS_PHONE_NBR", SqlNull(CONTACTS_PHONE_NBR)),
						new SqlParameter("CONTACTS_PHONE_EXT", SqlNull(CONTACTS_PHONE_EXT)),
						new SqlParameter("CONTACTS_PAGER_NBR", SqlNull(CONTACTS_PAGER_NBR)),
						new SqlParameter("CONTACTS_CELL_NBR", SqlNull(CONTACTS_CELL_NBR)),
						new SqlParameter("CONTACTS_FAX_NBR", SqlNull(CONTACTS_FAX_NBR)),
						new SqlParameter("NEWSLETTER_FLAG", SqlNull(NEWSLETTER_FLAG)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F028_CONTACTS_INFO_MSTR_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						FILLER = Reader["FILLER"].ToString();
						DOC_NBR = Reader["DOC_NBR"].ToString();
						CONTACTS_TYPE = Reader["CONTACTS_TYPE"].ToString();
						CONTACTS_LOCATION = Reader["CONTACTS_LOCATION"].ToString();
						CONTACTS_ADDR_1 = Reader["CONTACTS_ADDR_1"].ToString();
						CONTACTS_ADDR_2 = Reader["CONTACTS_ADDR_2"].ToString();
						CONTACTS_ADDR_3 = Reader["CONTACTS_ADDR_3"].ToString();
						POSTAL_CODE = Reader["POSTAL_CODE"].ToString();
						CONTACTS_EMAIL_ADDR = Reader["CONTACTS_EMAIL_ADDR"].ToString();
						CONTACTS_PHONE_NBR = ConvertDEC(Reader["CONTACTS_PHONE_NBR"]);
						CONTACTS_PHONE_EXT = ConvertDEC(Reader["CONTACTS_PHONE_EXT"]);
						CONTACTS_PAGER_NBR = ConvertDEC(Reader["CONTACTS_PAGER_NBR"]);
						CONTACTS_CELL_NBR = ConvertDEC(Reader["CONTACTS_CELL_NBR"]);
						CONTACTS_FAX_NBR = ConvertDEC(Reader["CONTACTS_FAX_NBR"]);
						NEWSLETTER_FLAG = Reader["NEWSLETTER_FLAG"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalFiller = Reader["FILLER"].ToString();
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalContacts_type = Reader["CONTACTS_TYPE"].ToString();
						_originalContacts_location = Reader["CONTACTS_LOCATION"].ToString();
						_originalContacts_addr_1 = Reader["CONTACTS_ADDR_1"].ToString();
						_originalContacts_addr_2 = Reader["CONTACTS_ADDR_2"].ToString();
						_originalContacts_addr_3 = Reader["CONTACTS_ADDR_3"].ToString();
						_originalPostal_code = Reader["POSTAL_CODE"].ToString();
						_originalContacts_email_addr = Reader["CONTACTS_EMAIL_ADDR"].ToString();
						_originalContacts_phone_nbr = ConvertDEC(Reader["CONTACTS_PHONE_NBR"]);
						_originalContacts_phone_ext = ConvertDEC(Reader["CONTACTS_PHONE_EXT"]);
						_originalContacts_pager_nbr = ConvertDEC(Reader["CONTACTS_PAGER_NBR"]);
						_originalContacts_cell_nbr = ConvertDEC(Reader["CONTACTS_CELL_NBR"]);
						_originalContacts_fax_nbr = ConvertDEC(Reader["CONTACTS_FAX_NBR"]);
						_originalNewsletter_flag = Reader["NEWSLETTER_FLAG"].ToString();
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
						new SqlParameter("CONTACTS_LOCATION", SqlNull(CONTACTS_LOCATION)),
						new SqlParameter("CONTACTS_ADDR_1", SqlNull(CONTACTS_ADDR_1)),
						new SqlParameter("CONTACTS_ADDR_2", SqlNull(CONTACTS_ADDR_2)),
						new SqlParameter("CONTACTS_ADDR_3", SqlNull(CONTACTS_ADDR_3)),
						new SqlParameter("POSTAL_CODE", SqlNull(POSTAL_CODE)),
						new SqlParameter("CONTACTS_EMAIL_ADDR", SqlNull(CONTACTS_EMAIL_ADDR)),
						new SqlParameter("CONTACTS_PHONE_NBR", SqlNull(CONTACTS_PHONE_NBR)),
						new SqlParameter("CONTACTS_PHONE_EXT", SqlNull(CONTACTS_PHONE_EXT)),
						new SqlParameter("CONTACTS_PAGER_NBR", SqlNull(CONTACTS_PAGER_NBR)),
						new SqlParameter("CONTACTS_CELL_NBR", SqlNull(CONTACTS_CELL_NBR)),
						new SqlParameter("CONTACTS_FAX_NBR", SqlNull(CONTACTS_FAX_NBR)),
						new SqlParameter("NEWSLETTER_FLAG", SqlNull(NEWSLETTER_FLAG)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F028_CONTACTS_INFO_MSTR_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						FILLER = Reader["FILLER"].ToString();
						DOC_NBR = Reader["DOC_NBR"].ToString();
						CONTACTS_TYPE = Reader["CONTACTS_TYPE"].ToString();
						CONTACTS_LOCATION = Reader["CONTACTS_LOCATION"].ToString();
						CONTACTS_ADDR_1 = Reader["CONTACTS_ADDR_1"].ToString();
						CONTACTS_ADDR_2 = Reader["CONTACTS_ADDR_2"].ToString();
						CONTACTS_ADDR_3 = Reader["CONTACTS_ADDR_3"].ToString();
						POSTAL_CODE = Reader["POSTAL_CODE"].ToString();
						CONTACTS_EMAIL_ADDR = Reader["CONTACTS_EMAIL_ADDR"].ToString();
						CONTACTS_PHONE_NBR = ConvertDEC(Reader["CONTACTS_PHONE_NBR"]);
						CONTACTS_PHONE_EXT = ConvertDEC(Reader["CONTACTS_PHONE_EXT"]);
						CONTACTS_PAGER_NBR = ConvertDEC(Reader["CONTACTS_PAGER_NBR"]);
						CONTACTS_CELL_NBR = ConvertDEC(Reader["CONTACTS_CELL_NBR"]);
						CONTACTS_FAX_NBR = ConvertDEC(Reader["CONTACTS_FAX_NBR"]);
						NEWSLETTER_FLAG = Reader["NEWSLETTER_FLAG"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalFiller = Reader["FILLER"].ToString();
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalContacts_type = Reader["CONTACTS_TYPE"].ToString();
						_originalContacts_location = Reader["CONTACTS_LOCATION"].ToString();
						_originalContacts_addr_1 = Reader["CONTACTS_ADDR_1"].ToString();
						_originalContacts_addr_2 = Reader["CONTACTS_ADDR_2"].ToString();
						_originalContacts_addr_3 = Reader["CONTACTS_ADDR_3"].ToString();
						_originalPostal_code = Reader["POSTAL_CODE"].ToString();
						_originalContacts_email_addr = Reader["CONTACTS_EMAIL_ADDR"].ToString();
						_originalContacts_phone_nbr = ConvertDEC(Reader["CONTACTS_PHONE_NBR"]);
						_originalContacts_phone_ext = ConvertDEC(Reader["CONTACTS_PHONE_EXT"]);
						_originalContacts_pager_nbr = ConvertDEC(Reader["CONTACTS_PAGER_NBR"]);
						_originalContacts_cell_nbr = ConvertDEC(Reader["CONTACTS_CELL_NBR"]);
						_originalContacts_fax_nbr = ConvertDEC(Reader["CONTACTS_FAX_NBR"]);
						_originalNewsletter_flag = Reader["NEWSLETTER_FLAG"].ToString();
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