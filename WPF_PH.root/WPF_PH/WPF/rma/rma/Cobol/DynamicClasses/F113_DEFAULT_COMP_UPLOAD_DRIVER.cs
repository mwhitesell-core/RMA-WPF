using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F113_DEFAULT_COMP_UPLOAD_DRIVER : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F113_DEFAULT_COMP_UPLOAD_DRIVER> Collection( Guid? rowid,
															decimal? seq_nbrmin,
															decimal? seq_nbrmax,
															decimal? column_nbr_doc_nbrmin,
															decimal? column_nbr_doc_nbrmax,
															decimal? column_nbr_doc_surnamemin,
															decimal? column_nbr_doc_surnamemax,
															decimal? column_nbr_doc_initsmin,
															decimal? column_nbr_doc_initsmax,
															decimal? column_nbr_doc_given_namesmin,
															decimal? column_nbr_doc_given_namesmax,
															decimal? column_nbr_amtmin,
															decimal? column_nbr_amtmax,
															decimal? column_nbr_comp_codemin,
															decimal? column_nbr_comp_codemax,
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
					new SqlParameter("minSEQ_NBR",seq_nbrmin),
					new SqlParameter("maxSEQ_NBR",seq_nbrmax),
					new SqlParameter("minCOLUMN_NBR_DOC_NBR",column_nbr_doc_nbrmin),
					new SqlParameter("maxCOLUMN_NBR_DOC_NBR",column_nbr_doc_nbrmax),
					new SqlParameter("minCOLUMN_NBR_DOC_SURNAME",column_nbr_doc_surnamemin),
					new SqlParameter("maxCOLUMN_NBR_DOC_SURNAME",column_nbr_doc_surnamemax),
					new SqlParameter("minCOLUMN_NBR_DOC_INITS",column_nbr_doc_initsmin),
					new SqlParameter("maxCOLUMN_NBR_DOC_INITS",column_nbr_doc_initsmax),
					new SqlParameter("minCOLUMN_NBR_DOC_GIVEN_NAMES",column_nbr_doc_given_namesmin),
					new SqlParameter("maxCOLUMN_NBR_DOC_GIVEN_NAMES",column_nbr_doc_given_namesmax),
					new SqlParameter("minCOLUMN_NBR_AMT",column_nbr_amtmin),
					new SqlParameter("maxCOLUMN_NBR_AMT",column_nbr_amtmax),
					new SqlParameter("minCOLUMN_NBR_COMP_CODE",column_nbr_comp_codemin),
					new SqlParameter("maxCOLUMN_NBR_COMP_CODE",column_nbr_comp_codemax),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F113_DEFAULT_COMP_UPLOAD_DRIVER_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F113_DEFAULT_COMP_UPLOAD_DRIVER>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F113_DEFAULT_COMP_UPLOAD_DRIVER_Search]", parameters);
            var collection = new ObservableCollection<F113_DEFAULT_COMP_UPLOAD_DRIVER>();

            while (Reader.Read())
            {
                collection.Add(new F113_DEFAULT_COMP_UPLOAD_DRIVER
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					SEQ_NBR = ConvertDEC(Reader["SEQ_NBR"]),
					COLUMN_NBR_DOC_NBR = ConvertDEC(Reader["COLUMN_NBR_DOC_NBR"]),
					COLUMN_NBR_DOC_SURNAME = ConvertDEC(Reader["COLUMN_NBR_DOC_SURNAME"]),
					COLUMN_NBR_DOC_INITS = ConvertDEC(Reader["COLUMN_NBR_DOC_INITS"]),
					COLUMN_NBR_DOC_GIVEN_NAMES = ConvertDEC(Reader["COLUMN_NBR_DOC_GIVEN_NAMES"]),
					COLUMN_NBR_AMT = ConvertDEC(Reader["COLUMN_NBR_AMT"]),
					COLUMN_NBR_COMP_CODE = ConvertDEC(Reader["COLUMN_NBR_COMP_CODE"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalSeq_nbr = ConvertDEC(Reader["SEQ_NBR"]),
					_originalColumn_nbr_doc_nbr = ConvertDEC(Reader["COLUMN_NBR_DOC_NBR"]),
					_originalColumn_nbr_doc_surname = ConvertDEC(Reader["COLUMN_NBR_DOC_SURNAME"]),
					_originalColumn_nbr_doc_inits = ConvertDEC(Reader["COLUMN_NBR_DOC_INITS"]),
					_originalColumn_nbr_doc_given_names = ConvertDEC(Reader["COLUMN_NBR_DOC_GIVEN_NAMES"]),
					_originalColumn_nbr_amt = ConvertDEC(Reader["COLUMN_NBR_AMT"]),
					_originalColumn_nbr_comp_code = ConvertDEC(Reader["COLUMN_NBR_COMP_CODE"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F113_DEFAULT_COMP_UPLOAD_DRIVER Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F113_DEFAULT_COMP_UPLOAD_DRIVER> Collection(ObservableCollection<F113_DEFAULT_COMP_UPLOAD_DRIVER>
                                                               f113DefaultCompUploadDriver = null)
        {
            if (IsSameSearch() && f113DefaultCompUploadDriver != null)
            {
                return f113DefaultCompUploadDriver;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F113_DEFAULT_COMP_UPLOAD_DRIVER>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("SEQ_NBR",WhereSeq_nbr),
					new SqlParameter("COLUMN_NBR_DOC_NBR",WhereColumn_nbr_doc_nbr),
					new SqlParameter("COLUMN_NBR_DOC_SURNAME",WhereColumn_nbr_doc_surname),
					new SqlParameter("COLUMN_NBR_DOC_INITS",WhereColumn_nbr_doc_inits),
					new SqlParameter("COLUMN_NBR_DOC_GIVEN_NAMES",WhereColumn_nbr_doc_given_names),
					new SqlParameter("COLUMN_NBR_AMT",WhereColumn_nbr_amt),
					new SqlParameter("COLUMN_NBR_COMP_CODE",WhereColumn_nbr_comp_code),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F113_DEFAULT_COMP_UPLOAD_DRIVER_Match]", parameters);
            var collection = new ObservableCollection<F113_DEFAULT_COMP_UPLOAD_DRIVER>();

            while (Reader.Read())
            {
                collection.Add(new F113_DEFAULT_COMP_UPLOAD_DRIVER
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					SEQ_NBR = ConvertDEC(Reader["SEQ_NBR"]),
					COLUMN_NBR_DOC_NBR = ConvertDEC(Reader["COLUMN_NBR_DOC_NBR"]),
					COLUMN_NBR_DOC_SURNAME = ConvertDEC(Reader["COLUMN_NBR_DOC_SURNAME"]),
					COLUMN_NBR_DOC_INITS = ConvertDEC(Reader["COLUMN_NBR_DOC_INITS"]),
					COLUMN_NBR_DOC_GIVEN_NAMES = ConvertDEC(Reader["COLUMN_NBR_DOC_GIVEN_NAMES"]),
					COLUMN_NBR_AMT = ConvertDEC(Reader["COLUMN_NBR_AMT"]),
					COLUMN_NBR_COMP_CODE = ConvertDEC(Reader["COLUMN_NBR_COMP_CODE"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereSeq_nbr = WhereSeq_nbr,
					_whereColumn_nbr_doc_nbr = WhereColumn_nbr_doc_nbr,
					_whereColumn_nbr_doc_surname = WhereColumn_nbr_doc_surname,
					_whereColumn_nbr_doc_inits = WhereColumn_nbr_doc_inits,
					_whereColumn_nbr_doc_given_names = WhereColumn_nbr_doc_given_names,
					_whereColumn_nbr_amt = WhereColumn_nbr_amt,
					_whereColumn_nbr_comp_code = WhereColumn_nbr_comp_code,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalSeq_nbr = ConvertDEC(Reader["SEQ_NBR"]),
					_originalColumn_nbr_doc_nbr = ConvertDEC(Reader["COLUMN_NBR_DOC_NBR"]),
					_originalColumn_nbr_doc_surname = ConvertDEC(Reader["COLUMN_NBR_DOC_SURNAME"]),
					_originalColumn_nbr_doc_inits = ConvertDEC(Reader["COLUMN_NBR_DOC_INITS"]),
					_originalColumn_nbr_doc_given_names = ConvertDEC(Reader["COLUMN_NBR_DOC_GIVEN_NAMES"]),
					_originalColumn_nbr_amt = ConvertDEC(Reader["COLUMN_NBR_AMT"]),
					_originalColumn_nbr_comp_code = ConvertDEC(Reader["COLUMN_NBR_COMP_CODE"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereSeq_nbr = WhereSeq_nbr;
					_whereColumn_nbr_doc_nbr = WhereColumn_nbr_doc_nbr;
					_whereColumn_nbr_doc_surname = WhereColumn_nbr_doc_surname;
					_whereColumn_nbr_doc_inits = WhereColumn_nbr_doc_inits;
					_whereColumn_nbr_doc_given_names = WhereColumn_nbr_doc_given_names;
					_whereColumn_nbr_amt = WhereColumn_nbr_amt;
					_whereColumn_nbr_comp_code = WhereColumn_nbr_comp_code;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereSeq_nbr == null 
				&& WhereColumn_nbr_doc_nbr == null 
				&& WhereColumn_nbr_doc_surname == null 
				&& WhereColumn_nbr_doc_inits == null 
				&& WhereColumn_nbr_doc_given_names == null 
				&& WhereColumn_nbr_amt == null 
				&& WhereColumn_nbr_comp_code == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereSeq_nbr ==  _whereSeq_nbr
				&& WhereColumn_nbr_doc_nbr ==  _whereColumn_nbr_doc_nbr
				&& WhereColumn_nbr_doc_surname ==  _whereColumn_nbr_doc_surname
				&& WhereColumn_nbr_doc_inits ==  _whereColumn_nbr_doc_inits
				&& WhereColumn_nbr_doc_given_names ==  _whereColumn_nbr_doc_given_names
				&& WhereColumn_nbr_amt ==  _whereColumn_nbr_amt
				&& WhereColumn_nbr_comp_code ==  _whereColumn_nbr_comp_code
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereSeq_nbr = null; 
			WhereColumn_nbr_doc_nbr = null; 
			WhereColumn_nbr_doc_surname = null; 
			WhereColumn_nbr_doc_inits = null; 
			WhereColumn_nbr_doc_given_names = null; 
			WhereColumn_nbr_amt = null; 
			WhereColumn_nbr_comp_code = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private decimal? _SEQ_NBR;
		private decimal? _COLUMN_NBR_DOC_NBR;
		private decimal? _COLUMN_NBR_DOC_SURNAME;
		private decimal? _COLUMN_NBR_DOC_INITS;
		private decimal? _COLUMN_NBR_DOC_GIVEN_NAMES;
		private decimal? _COLUMN_NBR_AMT;
		private decimal? _COLUMN_NBR_COMP_CODE;
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
		public decimal? SEQ_NBR
		{
			get { return _SEQ_NBR; }
			set
			{
				if (_SEQ_NBR != value)
				{
					_SEQ_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? COLUMN_NBR_DOC_NBR
		{
			get { return _COLUMN_NBR_DOC_NBR; }
			set
			{
				if (_COLUMN_NBR_DOC_NBR != value)
				{
					_COLUMN_NBR_DOC_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? COLUMN_NBR_DOC_SURNAME
		{
			get { return _COLUMN_NBR_DOC_SURNAME; }
			set
			{
				if (_COLUMN_NBR_DOC_SURNAME != value)
				{
					_COLUMN_NBR_DOC_SURNAME = value;
					ChangeState();
				}
			}
		}
		public decimal? COLUMN_NBR_DOC_INITS
		{
			get { return _COLUMN_NBR_DOC_INITS; }
			set
			{
				if (_COLUMN_NBR_DOC_INITS != value)
				{
					_COLUMN_NBR_DOC_INITS = value;
					ChangeState();
				}
			}
		}
		public decimal? COLUMN_NBR_DOC_GIVEN_NAMES
		{
			get { return _COLUMN_NBR_DOC_GIVEN_NAMES; }
			set
			{
				if (_COLUMN_NBR_DOC_GIVEN_NAMES != value)
				{
					_COLUMN_NBR_DOC_GIVEN_NAMES = value;
					ChangeState();
				}
			}
		}
		public decimal? COLUMN_NBR_AMT
		{
			get { return _COLUMN_NBR_AMT; }
			set
			{
				if (_COLUMN_NBR_AMT != value)
				{
					_COLUMN_NBR_AMT = value;
					ChangeState();
				}
			}
		}
		public decimal? COLUMN_NBR_COMP_CODE
		{
			get { return _COLUMN_NBR_COMP_CODE; }
			set
			{
				if (_COLUMN_NBR_COMP_CODE != value)
				{
					_COLUMN_NBR_COMP_CODE = value;
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
		public decimal? WhereSeq_nbr { get; set; }
		private decimal? _whereSeq_nbr;
		public decimal? WhereColumn_nbr_doc_nbr { get; set; }
		private decimal? _whereColumn_nbr_doc_nbr;
		public decimal? WhereColumn_nbr_doc_surname { get; set; }
		private decimal? _whereColumn_nbr_doc_surname;
		public decimal? WhereColumn_nbr_doc_inits { get; set; }
		private decimal? _whereColumn_nbr_doc_inits;
		public decimal? WhereColumn_nbr_doc_given_names { get; set; }
		private decimal? _whereColumn_nbr_doc_given_names;
		public decimal? WhereColumn_nbr_amt { get; set; }
		private decimal? _whereColumn_nbr_amt;
		public decimal? WhereColumn_nbr_comp_code { get; set; }
		private decimal? _whereColumn_nbr_comp_code;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private decimal? _originalSeq_nbr;
		private decimal? _originalColumn_nbr_doc_nbr;
		private decimal? _originalColumn_nbr_doc_surname;
		private decimal? _originalColumn_nbr_doc_inits;
		private decimal? _originalColumn_nbr_doc_given_names;
		private decimal? _originalColumn_nbr_amt;
		private decimal? _originalColumn_nbr_comp_code;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			SEQ_NBR = _originalSeq_nbr;
			COLUMN_NBR_DOC_NBR = _originalColumn_nbr_doc_nbr;
			COLUMN_NBR_DOC_SURNAME = _originalColumn_nbr_doc_surname;
			COLUMN_NBR_DOC_INITS = _originalColumn_nbr_doc_inits;
			COLUMN_NBR_DOC_GIVEN_NAMES = _originalColumn_nbr_doc_given_names;
			COLUMN_NBR_AMT = _originalColumn_nbr_amt;
			COLUMN_NBR_COMP_CODE = _originalColumn_nbr_comp_code;
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
					new SqlParameter("SEQ_NBR",SEQ_NBR)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F113_DEFAULT_COMP_UPLOAD_DRIVER_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F113_DEFAULT_COMP_UPLOAD_DRIVER_Purge]");
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
						new SqlParameter("SEQ_NBR", SqlNull(SEQ_NBR)),
						new SqlParameter("COLUMN_NBR_DOC_NBR", SqlNull(COLUMN_NBR_DOC_NBR)),
						new SqlParameter("COLUMN_NBR_DOC_SURNAME", SqlNull(COLUMN_NBR_DOC_SURNAME)),
						new SqlParameter("COLUMN_NBR_DOC_INITS", SqlNull(COLUMN_NBR_DOC_INITS)),
						new SqlParameter("COLUMN_NBR_DOC_GIVEN_NAMES", SqlNull(COLUMN_NBR_DOC_GIVEN_NAMES)),
						new SqlParameter("COLUMN_NBR_AMT", SqlNull(COLUMN_NBR_AMT)),
						new SqlParameter("COLUMN_NBR_COMP_CODE", SqlNull(COLUMN_NBR_COMP_CODE)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F113_DEFAULT_COMP_UPLOAD_DRIVER_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						SEQ_NBR = ConvertDEC(Reader["SEQ_NBR"]);
						COLUMN_NBR_DOC_NBR = ConvertDEC(Reader["COLUMN_NBR_DOC_NBR"]);
						COLUMN_NBR_DOC_SURNAME = ConvertDEC(Reader["COLUMN_NBR_DOC_SURNAME"]);
						COLUMN_NBR_DOC_INITS = ConvertDEC(Reader["COLUMN_NBR_DOC_INITS"]);
						COLUMN_NBR_DOC_GIVEN_NAMES = ConvertDEC(Reader["COLUMN_NBR_DOC_GIVEN_NAMES"]);
						COLUMN_NBR_AMT = ConvertDEC(Reader["COLUMN_NBR_AMT"]);
						COLUMN_NBR_COMP_CODE = ConvertDEC(Reader["COLUMN_NBR_COMP_CODE"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalSeq_nbr = ConvertDEC(Reader["SEQ_NBR"]);
						_originalColumn_nbr_doc_nbr = ConvertDEC(Reader["COLUMN_NBR_DOC_NBR"]);
						_originalColumn_nbr_doc_surname = ConvertDEC(Reader["COLUMN_NBR_DOC_SURNAME"]);
						_originalColumn_nbr_doc_inits = ConvertDEC(Reader["COLUMN_NBR_DOC_INITS"]);
						_originalColumn_nbr_doc_given_names = ConvertDEC(Reader["COLUMN_NBR_DOC_GIVEN_NAMES"]);
						_originalColumn_nbr_amt = ConvertDEC(Reader["COLUMN_NBR_AMT"]);
						_originalColumn_nbr_comp_code = ConvertDEC(Reader["COLUMN_NBR_COMP_CODE"]);
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("SEQ_NBR", SqlNull(SEQ_NBR)),
						new SqlParameter("COLUMN_NBR_DOC_NBR", SqlNull(COLUMN_NBR_DOC_NBR)),
						new SqlParameter("COLUMN_NBR_DOC_SURNAME", SqlNull(COLUMN_NBR_DOC_SURNAME)),
						new SqlParameter("COLUMN_NBR_DOC_INITS", SqlNull(COLUMN_NBR_DOC_INITS)),
						new SqlParameter("COLUMN_NBR_DOC_GIVEN_NAMES", SqlNull(COLUMN_NBR_DOC_GIVEN_NAMES)),
						new SqlParameter("COLUMN_NBR_AMT", SqlNull(COLUMN_NBR_AMT)),
						new SqlParameter("COLUMN_NBR_COMP_CODE", SqlNull(COLUMN_NBR_COMP_CODE)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F113_DEFAULT_COMP_UPLOAD_DRIVER_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						SEQ_NBR = ConvertDEC(Reader["SEQ_NBR"]);
						COLUMN_NBR_DOC_NBR = ConvertDEC(Reader["COLUMN_NBR_DOC_NBR"]);
						COLUMN_NBR_DOC_SURNAME = ConvertDEC(Reader["COLUMN_NBR_DOC_SURNAME"]);
						COLUMN_NBR_DOC_INITS = ConvertDEC(Reader["COLUMN_NBR_DOC_INITS"]);
						COLUMN_NBR_DOC_GIVEN_NAMES = ConvertDEC(Reader["COLUMN_NBR_DOC_GIVEN_NAMES"]);
						COLUMN_NBR_AMT = ConvertDEC(Reader["COLUMN_NBR_AMT"]);
						COLUMN_NBR_COMP_CODE = ConvertDEC(Reader["COLUMN_NBR_COMP_CODE"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalSeq_nbr = ConvertDEC(Reader["SEQ_NBR"]);
						_originalColumn_nbr_doc_nbr = ConvertDEC(Reader["COLUMN_NBR_DOC_NBR"]);
						_originalColumn_nbr_doc_surname = ConvertDEC(Reader["COLUMN_NBR_DOC_SURNAME"]);
						_originalColumn_nbr_doc_inits = ConvertDEC(Reader["COLUMN_NBR_DOC_INITS"]);
						_originalColumn_nbr_doc_given_names = ConvertDEC(Reader["COLUMN_NBR_DOC_GIVEN_NAMES"]);
						_originalColumn_nbr_amt = ConvertDEC(Reader["COLUMN_NBR_AMT"]);
						_originalColumn_nbr_comp_code = ConvertDEC(Reader["COLUMN_NBR_COMP_CODE"]);
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