using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F053_PAYROLL_UPLOAD : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F053_PAYROLL_UPLOAD> Collection( Guid? rowid,
															string claim_nbr,
															string clmhdr_batch_type,
															string processing_program,
															decimal? clmhdr_curr_paymentmin,
															decimal? clmhdr_curr_paymentmax,
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
					new SqlParameter("CLAIM_NBR",claim_nbr),
					new SqlParameter("CLMHDR_BATCH_TYPE",clmhdr_batch_type),
					new SqlParameter("PROCESSING_PROGRAM",processing_program),
					new SqlParameter("minCLMHDR_CURR_PAYMENT",clmhdr_curr_paymentmin),
					new SqlParameter("maxCLMHDR_CURR_PAYMENT",clmhdr_curr_paymentmax),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[SEQUENTIAL].[sp_F053_PAYROLL_UPLOAD_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F053_PAYROLL_UPLOAD>();
				}

            }

            Reader = CoreReader("[SEQUENTIAL].[sp_F053_PAYROLL_UPLOAD_Search]", parameters);
            var collection = new ObservableCollection<F053_PAYROLL_UPLOAD>();

            while (Reader.Read())
            {
                collection.Add(new F053_PAYROLL_UPLOAD
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLAIM_NBR = Reader["CLAIM_NBR"].ToString(),
					CLMHDR_BATCH_TYPE = Reader["CLMHDR_BATCH_TYPE"].ToString(),
					PROCESSING_PROGRAM = Reader["PROCESSING_PROGRAM"].ToString(),
					CLMHDR_CURR_PAYMENT = ConvertDEC(Reader["CLMHDR_CURR_PAYMENT"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClaim_nbr = Reader["CLAIM_NBR"].ToString(),
					_originalClmhdr_batch_type = Reader["CLMHDR_BATCH_TYPE"].ToString(),
					_originalProcessing_program = Reader["PROCESSING_PROGRAM"].ToString(),
					_originalClmhdr_curr_payment = ConvertDEC(Reader["CLMHDR_CURR_PAYMENT"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F053_PAYROLL_UPLOAD Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F053_PAYROLL_UPLOAD> Collection(ObservableCollection<F053_PAYROLL_UPLOAD>
                                                               f053PayrollUpload = null)
        {
            if (IsSameSearch() && f053PayrollUpload != null)
            {
                return f053PayrollUpload;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F053_PAYROLL_UPLOAD>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("CLAIM_NBR",WhereClaim_nbr),
					new SqlParameter("CLMHDR_BATCH_TYPE",WhereClmhdr_batch_type),
					new SqlParameter("PROCESSING_PROGRAM",WhereProcessing_program),
					new SqlParameter("CLMHDR_CURR_PAYMENT",WhereClmhdr_curr_payment),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[SEQUENTIAL].[sp_F053_PAYROLL_UPLOAD_Match]", parameters);
            var collection = new ObservableCollection<F053_PAYROLL_UPLOAD>();

            while (Reader.Read())
            {
                collection.Add(new F053_PAYROLL_UPLOAD
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLAIM_NBR = Reader["CLAIM_NBR"].ToString(),
					CLMHDR_BATCH_TYPE = Reader["CLMHDR_BATCH_TYPE"].ToString(),
					PROCESSING_PROGRAM = Reader["PROCESSING_PROGRAM"].ToString(),
					CLMHDR_CURR_PAYMENT = ConvertDEC(Reader["CLMHDR_CURR_PAYMENT"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereClaim_nbr = WhereClaim_nbr,
					_whereClmhdr_batch_type = WhereClmhdr_batch_type,
					_whereProcessing_program = WhereProcessing_program,
					_whereClmhdr_curr_payment = WhereClmhdr_curr_payment,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClaim_nbr = Reader["CLAIM_NBR"].ToString(),
					_originalClmhdr_batch_type = Reader["CLMHDR_BATCH_TYPE"].ToString(),
					_originalProcessing_program = Reader["PROCESSING_PROGRAM"].ToString(),
					_originalClmhdr_curr_payment = ConvertDEC(Reader["CLMHDR_CURR_PAYMENT"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereClaim_nbr = WhereClaim_nbr;
					_whereClmhdr_batch_type = WhereClmhdr_batch_type;
					_whereProcessing_program = WhereProcessing_program;
					_whereClmhdr_curr_payment = WhereClmhdr_curr_payment;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereClaim_nbr == null 
				&& WhereClmhdr_batch_type == null 
				&& WhereProcessing_program == null 
				&& WhereClmhdr_curr_payment == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereClaim_nbr ==  _whereClaim_nbr
				&& WhereClmhdr_batch_type ==  _whereClmhdr_batch_type
				&& WhereProcessing_program ==  _whereProcessing_program
				&& WhereClmhdr_curr_payment ==  _whereClmhdr_curr_payment
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereClaim_nbr = null; 
			WhereClmhdr_batch_type = null; 
			WhereProcessing_program = null; 
			WhereClmhdr_curr_payment = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _CLAIM_NBR;
		private string _CLMHDR_BATCH_TYPE;
		private string _PROCESSING_PROGRAM;
		private decimal? _CLMHDR_CURR_PAYMENT;
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
		public string CLAIM_NBR
		{
			get { return _CLAIM_NBR; }
			set
			{
				if (_CLAIM_NBR != value)
				{
					_CLAIM_NBR = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_BATCH_TYPE
		{
			get { return _CLMHDR_BATCH_TYPE; }
			set
			{
				if (_CLMHDR_BATCH_TYPE != value)
				{
					_CLMHDR_BATCH_TYPE = value;
					ChangeState();
				}
			}
		}
		public string PROCESSING_PROGRAM
		{
			get { return _PROCESSING_PROGRAM; }
			set
			{
				if (_PROCESSING_PROGRAM != value)
				{
					_PROCESSING_PROGRAM = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_CURR_PAYMENT
		{
			get { return _CLMHDR_CURR_PAYMENT; }
			set
			{
				if (_CLMHDR_CURR_PAYMENT != value)
				{
					_CLMHDR_CURR_PAYMENT = value;
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
		public string WhereClaim_nbr { get; set; }
		private string _whereClaim_nbr;
		public string WhereClmhdr_batch_type { get; set; }
		private string _whereClmhdr_batch_type;
		public string WhereProcessing_program { get; set; }
		private string _whereProcessing_program;
		public decimal? WhereClmhdr_curr_payment { get; set; }
		private decimal? _whereClmhdr_curr_payment;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalClaim_nbr;
		private string _originalClmhdr_batch_type;
		private string _originalProcessing_program;
		private decimal? _originalClmhdr_curr_payment;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			CLAIM_NBR = _originalClaim_nbr;
			CLMHDR_BATCH_TYPE = _originalClmhdr_batch_type;
			PROCESSING_PROGRAM = _originalProcessing_program;
			CLMHDR_CURR_PAYMENT = _originalClmhdr_curr_payment;
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
			RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_F053_PAYROLL_UPLOAD_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_F053_PAYROLL_UPLOAD_Purge]");
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
						new SqlParameter("CLAIM_NBR", SqlNull(CLAIM_NBR)),
						new SqlParameter("CLMHDR_BATCH_TYPE", SqlNull(CLMHDR_BATCH_TYPE)),
						new SqlParameter("PROCESSING_PROGRAM", SqlNull(PROCESSING_PROGRAM)),
						new SqlParameter("CLMHDR_CURR_PAYMENT", SqlNull(CLMHDR_CURR_PAYMENT)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_F053_PAYROLL_UPLOAD_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLAIM_NBR = Reader["CLAIM_NBR"].ToString();
						CLMHDR_BATCH_TYPE = Reader["CLMHDR_BATCH_TYPE"].ToString();
						PROCESSING_PROGRAM = Reader["PROCESSING_PROGRAM"].ToString();
						CLMHDR_CURR_PAYMENT = ConvertDEC(Reader["CLMHDR_CURR_PAYMENT"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClaim_nbr = Reader["CLAIM_NBR"].ToString();
						_originalClmhdr_batch_type = Reader["CLMHDR_BATCH_TYPE"].ToString();
						_originalProcessing_program = Reader["PROCESSING_PROGRAM"].ToString();
						_originalClmhdr_curr_payment = ConvertDEC(Reader["CLMHDR_CURR_PAYMENT"]);
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("CLAIM_NBR", SqlNull(CLAIM_NBR)),
						new SqlParameter("CLMHDR_BATCH_TYPE", SqlNull(CLMHDR_BATCH_TYPE)),
						new SqlParameter("PROCESSING_PROGRAM", SqlNull(PROCESSING_PROGRAM)),
						new SqlParameter("CLMHDR_CURR_PAYMENT", SqlNull(CLMHDR_CURR_PAYMENT)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_F053_PAYROLL_UPLOAD_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLAIM_NBR = Reader["CLAIM_NBR"].ToString();
						CLMHDR_BATCH_TYPE = Reader["CLMHDR_BATCH_TYPE"].ToString();
						PROCESSING_PROGRAM = Reader["PROCESSING_PROGRAM"].ToString();
						CLMHDR_CURR_PAYMENT = ConvertDEC(Reader["CLMHDR_CURR_PAYMENT"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClaim_nbr = Reader["CLAIM_NBR"].ToString();
						_originalClmhdr_batch_type = Reader["CLMHDR_BATCH_TYPE"].ToString();
						_originalProcessing_program = Reader["PROCESSING_PROGRAM"].ToString();
						_originalClmhdr_curr_payment = ConvertDEC(Reader["CLMHDR_CURR_PAYMENT"]);
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