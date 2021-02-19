using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F923_DOC_REVENUE_TRANSLATION : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F923_DOC_REVENUE_TRANSLATION> Collection( Guid? rowid,
															string doc_nbr,
															decimal? clinic_nbrmin,
															decimal? clinic_nbrmax,
															string clmhdr_payroll,
															decimal? clinic_nbr_translatedmin,
															decimal? clinic_nbr_translatedmax,
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
					new SqlParameter("minCLINIC_NBR",clinic_nbrmin),
					new SqlParameter("maxCLINIC_NBR",clinic_nbrmax),
					new SqlParameter("CLMHDR_PAYROLL",clmhdr_payroll),
					new SqlParameter("minCLINIC_NBR_TRANSLATED",clinic_nbr_translatedmin),
					new SqlParameter("maxCLINIC_NBR_TRANSLATED",clinic_nbr_translatedmax),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F923_DOC_REVENUE_TRANSLATION_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F923_DOC_REVENUE_TRANSLATION>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F923_DOC_REVENUE_TRANSLATION_Search]", parameters);
            var collection = new ObservableCollection<F923_DOC_REVENUE_TRANSLATION>();

            while (Reader.Read())
            {
                collection.Add(new F923_DOC_REVENUE_TRANSLATION
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					CLINIC_NBR = ConvertDEC(Reader["CLINIC_NBR"]),
					CLMHDR_PAYROLL = Reader["CLMHDR_PAYROLL"].ToString(),
					CLINIC_NBR_TRANSLATED = ConvertDEC(Reader["CLINIC_NBR_TRANSLATED"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalClinic_nbr = ConvertDEC(Reader["CLINIC_NBR"]),
					_originalClmhdr_payroll = Reader["CLMHDR_PAYROLL"].ToString(),
					_originalClinic_nbr_translated = ConvertDEC(Reader["CLINIC_NBR_TRANSLATED"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F923_DOC_REVENUE_TRANSLATION Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F923_DOC_REVENUE_TRANSLATION> Collection(ObservableCollection<F923_DOC_REVENUE_TRANSLATION>
                                                               f923DocRevenueTranslation = null)
        {
            if (IsSameSearch() && f923DocRevenueTranslation != null)
            {
                return f923DocRevenueTranslation;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F923_DOC_REVENUE_TRANSLATION>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("DOC_NBR",WhereDoc_nbr),
					new SqlParameter("CLINIC_NBR",WhereClinic_nbr),
					new SqlParameter("CLMHDR_PAYROLL",WhereClmhdr_payroll),
					new SqlParameter("CLINIC_NBR_TRANSLATED",WhereClinic_nbr_translated),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F923_DOC_REVENUE_TRANSLATION_Match]", parameters);
            var collection = new ObservableCollection<F923_DOC_REVENUE_TRANSLATION>();

            while (Reader.Read())
            {
                collection.Add(new F923_DOC_REVENUE_TRANSLATION
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					CLINIC_NBR = ConvertDEC(Reader["CLINIC_NBR"]),
					CLMHDR_PAYROLL = Reader["CLMHDR_PAYROLL"].ToString(),
					CLINIC_NBR_TRANSLATED = ConvertDEC(Reader["CLINIC_NBR_TRANSLATED"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereDoc_nbr = WhereDoc_nbr,
					_whereClinic_nbr = WhereClinic_nbr,
					_whereClmhdr_payroll = WhereClmhdr_payroll,
					_whereClinic_nbr_translated = WhereClinic_nbr_translated,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalClinic_nbr = ConvertDEC(Reader["CLINIC_NBR"]),
					_originalClmhdr_payroll = Reader["CLMHDR_PAYROLL"].ToString(),
					_originalClinic_nbr_translated = ConvertDEC(Reader["CLINIC_NBR_TRANSLATED"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereDoc_nbr = WhereDoc_nbr;
					_whereClinic_nbr = WhereClinic_nbr;
					_whereClmhdr_payroll = WhereClmhdr_payroll;
					_whereClinic_nbr_translated = WhereClinic_nbr_translated;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereDoc_nbr == null 
				&& WhereClinic_nbr == null 
				&& WhereClmhdr_payroll == null 
				&& WhereClinic_nbr_translated == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereDoc_nbr ==  _whereDoc_nbr
				&& WhereClinic_nbr ==  _whereClinic_nbr
				&& WhereClmhdr_payroll ==  _whereClmhdr_payroll
				&& WhereClinic_nbr_translated ==  _whereClinic_nbr_translated
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereDoc_nbr = null; 
			WhereClinic_nbr = null; 
			WhereClmhdr_payroll = null; 
			WhereClinic_nbr_translated = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _DOC_NBR;
		private decimal? _CLINIC_NBR;
		private string _CLMHDR_PAYROLL;
		private decimal? _CLINIC_NBR_TRANSLATED;
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
		public decimal? CLINIC_NBR
		{
			get { return _CLINIC_NBR; }
			set
			{
				if (_CLINIC_NBR != value)
				{
					_CLINIC_NBR = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_PAYROLL
		{
			get { return _CLMHDR_PAYROLL; }
			set
			{
				if (_CLMHDR_PAYROLL != value)
				{
					_CLMHDR_PAYROLL = value;
					ChangeState();
				}
			}
		}
		public decimal? CLINIC_NBR_TRANSLATED
		{
			get { return _CLINIC_NBR_TRANSLATED; }
			set
			{
				if (_CLINIC_NBR_TRANSLATED != value)
				{
					_CLINIC_NBR_TRANSLATED = value;
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
		public decimal? WhereClinic_nbr { get; set; }
		private decimal? _whereClinic_nbr;
		public string WhereClmhdr_payroll { get; set; }
		private string _whereClmhdr_payroll;
		public decimal? WhereClinic_nbr_translated { get; set; }
		private decimal? _whereClinic_nbr_translated;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalDoc_nbr;
		private decimal? _originalClinic_nbr;
		private string _originalClmhdr_payroll;
		private decimal? _originalClinic_nbr_translated;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			DOC_NBR = _originalDoc_nbr;
			CLINIC_NBR = _originalClinic_nbr;
			CLMHDR_PAYROLL = _originalClmhdr_payroll;
			CLINIC_NBR_TRANSLATED = _originalClinic_nbr_translated;
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
					new SqlParameter("CLINIC_NBR",CLINIC_NBR),
					new SqlParameter("CLMHDR_PAYROLL",CLMHDR_PAYROLL)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F923_DOC_REVENUE_TRANSLATION_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F923_DOC_REVENUE_TRANSLATION_Purge]");
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
						new SqlParameter("CLINIC_NBR", SqlNull(CLINIC_NBR)),
						new SqlParameter("CLMHDR_PAYROLL", SqlNull(CLMHDR_PAYROLL)),
						new SqlParameter("CLINIC_NBR_TRANSLATED", SqlNull(CLINIC_NBR_TRANSLATED)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F923_DOC_REVENUE_TRANSLATION_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOC_NBR = Reader["DOC_NBR"].ToString();
						CLINIC_NBR = ConvertDEC(Reader["CLINIC_NBR"]);
						CLMHDR_PAYROLL = Reader["CLMHDR_PAYROLL"].ToString();
						CLINIC_NBR_TRANSLATED = ConvertDEC(Reader["CLINIC_NBR_TRANSLATED"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalClinic_nbr = ConvertDEC(Reader["CLINIC_NBR"]);
						_originalClmhdr_payroll = Reader["CLMHDR_PAYROLL"].ToString();
						_originalClinic_nbr_translated = ConvertDEC(Reader["CLINIC_NBR_TRANSLATED"]);
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("DOC_NBR", SqlNull(DOC_NBR)),
						new SqlParameter("CLINIC_NBR", SqlNull(CLINIC_NBR)),
						new SqlParameter("CLMHDR_PAYROLL", SqlNull(CLMHDR_PAYROLL)),
						new SqlParameter("CLINIC_NBR_TRANSLATED", SqlNull(CLINIC_NBR_TRANSLATED)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F923_DOC_REVENUE_TRANSLATION_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOC_NBR = Reader["DOC_NBR"].ToString();
						CLINIC_NBR = ConvertDEC(Reader["CLINIC_NBR"]);
						CLMHDR_PAYROLL = Reader["CLMHDR_PAYROLL"].ToString();
						CLINIC_NBR_TRANSLATED = ConvertDEC(Reader["CLINIC_NBR_TRANSLATED"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalClinic_nbr = ConvertDEC(Reader["CLINIC_NBR"]);
						_originalClmhdr_payroll = Reader["CLMHDR_PAYROLL"].ToString();
						_originalClinic_nbr_translated = ConvertDEC(Reader["CLINIC_NBR_TRANSLATED"]);
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