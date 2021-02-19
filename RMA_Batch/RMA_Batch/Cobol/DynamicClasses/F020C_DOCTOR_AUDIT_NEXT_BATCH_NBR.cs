using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F020C_DOCTOR_AUDIT_NEXT_BATCH_NBR : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F020C_DOCTOR_AUDIT_NEXT_BATCH_NBR> Collection( Guid? rowid,
															string doc_nbr,
															decimal? doc_clinic_nbrmin,
															decimal? doc_clinic_nbrmax,
															decimal? doc_nx_avail_batchmin,
															decimal? doc_nx_avail_batchmax,
															string doc_clinic_nbr_status,
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
					new SqlParameter("minDOC_CLINIC_NBR",doc_clinic_nbrmin),
					new SqlParameter("maxDOC_CLINIC_NBR",doc_clinic_nbrmax),
					new SqlParameter("minDOC_NX_AVAIL_BATCH",doc_nx_avail_batchmin),
					new SqlParameter("maxDOC_NX_AVAIL_BATCH",doc_nx_avail_batchmax),
					new SqlParameter("DOC_CLINIC_NBR_STATUS",doc_clinic_nbr_status),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[SEQUENTIAL].[sp_F020C_DOCTOR_AUDIT_NEXT_BATCH_NBR_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F020C_DOCTOR_AUDIT_NEXT_BATCH_NBR>();
				}

            }

            Reader = CoreReader("[SEQUENTIAL].[sp_F020C_DOCTOR_AUDIT_NEXT_BATCH_NBR_Search]", parameters);
            var collection = new ObservableCollection<F020C_DOCTOR_AUDIT_NEXT_BATCH_NBR>();

            while (Reader.Read())
            {
                collection.Add(new F020C_DOCTOR_AUDIT_NEXT_BATCH_NBR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					DOC_CLINIC_NBR = ConvertDEC(Reader["DOC_CLINIC_NBR"]),
					DOC_NX_AVAIL_BATCH = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH"]),
					DOC_CLINIC_NBR_STATUS = Reader["DOC_CLINIC_NBR_STATUS"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalDoc_clinic_nbr = ConvertDEC(Reader["DOC_CLINIC_NBR"]),
					_originalDoc_nx_avail_batch = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH"]),
					_originalDoc_clinic_nbr_status = Reader["DOC_CLINIC_NBR_STATUS"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F020C_DOCTOR_AUDIT_NEXT_BATCH_NBR Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F020C_DOCTOR_AUDIT_NEXT_BATCH_NBR> Collection(ObservableCollection<F020C_DOCTOR_AUDIT_NEXT_BATCH_NBR>
                                                               f020cDoctorAuditNextBatchNbr = null)
        {
            if (IsSameSearch() && f020cDoctorAuditNextBatchNbr != null)
            {
                return f020cDoctorAuditNextBatchNbr;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F020C_DOCTOR_AUDIT_NEXT_BATCH_NBR>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("DOC_NBR",WhereDoc_nbr),
					new SqlParameter("DOC_CLINIC_NBR",WhereDoc_clinic_nbr),
					new SqlParameter("DOC_NX_AVAIL_BATCH",WhereDoc_nx_avail_batch),
					new SqlParameter("DOC_CLINIC_NBR_STATUS",WhereDoc_clinic_nbr_status),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[SEQUENTIAL].[sp_F020C_DOCTOR_AUDIT_NEXT_BATCH_NBR_Match]", parameters);
            var collection = new ObservableCollection<F020C_DOCTOR_AUDIT_NEXT_BATCH_NBR>();

            while (Reader.Read())
            {
                collection.Add(new F020C_DOCTOR_AUDIT_NEXT_BATCH_NBR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					DOC_CLINIC_NBR = ConvertDEC(Reader["DOC_CLINIC_NBR"]),
					DOC_NX_AVAIL_BATCH = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH"]),
					DOC_CLINIC_NBR_STATUS = Reader["DOC_CLINIC_NBR_STATUS"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereDoc_nbr = WhereDoc_nbr,
					_whereDoc_clinic_nbr = WhereDoc_clinic_nbr,
					_whereDoc_nx_avail_batch = WhereDoc_nx_avail_batch,
					_whereDoc_clinic_nbr_status = WhereDoc_clinic_nbr_status,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalDoc_clinic_nbr = ConvertDEC(Reader["DOC_CLINIC_NBR"]),
					_originalDoc_nx_avail_batch = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH"]),
					_originalDoc_clinic_nbr_status = Reader["DOC_CLINIC_NBR_STATUS"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereDoc_nbr = WhereDoc_nbr;
					_whereDoc_clinic_nbr = WhereDoc_clinic_nbr;
					_whereDoc_nx_avail_batch = WhereDoc_nx_avail_batch;
					_whereDoc_clinic_nbr_status = WhereDoc_clinic_nbr_status;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereDoc_nbr == null 
				&& WhereDoc_clinic_nbr == null 
				&& WhereDoc_nx_avail_batch == null 
				&& WhereDoc_clinic_nbr_status == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereDoc_nbr ==  _whereDoc_nbr
				&& WhereDoc_clinic_nbr ==  _whereDoc_clinic_nbr
				&& WhereDoc_nx_avail_batch ==  _whereDoc_nx_avail_batch
				&& WhereDoc_clinic_nbr_status ==  _whereDoc_clinic_nbr_status
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereDoc_nbr = null; 
			WhereDoc_clinic_nbr = null; 
			WhereDoc_nx_avail_batch = null; 
			WhereDoc_clinic_nbr_status = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _DOC_NBR;
		private decimal? _DOC_CLINIC_NBR;
		private decimal? _DOC_NX_AVAIL_BATCH;
		private string _DOC_CLINIC_NBR_STATUS;
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
		public decimal? DOC_CLINIC_NBR
		{
			get { return _DOC_CLINIC_NBR; }
			set
			{
				if (_DOC_CLINIC_NBR != value)
				{
					_DOC_CLINIC_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_NX_AVAIL_BATCH
		{
			get { return _DOC_NX_AVAIL_BATCH; }
			set
			{
				if (_DOC_NX_AVAIL_BATCH != value)
				{
					_DOC_NX_AVAIL_BATCH = value;
					ChangeState();
				}
			}
		}
		public string DOC_CLINIC_NBR_STATUS
		{
			get { return _DOC_CLINIC_NBR_STATUS; }
			set
			{
				if (_DOC_CLINIC_NBR_STATUS != value)
				{
					_DOC_CLINIC_NBR_STATUS = value;
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
		public decimal? WhereDoc_clinic_nbr { get; set; }
		private decimal? _whereDoc_clinic_nbr;
		public decimal? WhereDoc_nx_avail_batch { get; set; }
		private decimal? _whereDoc_nx_avail_batch;
		public string WhereDoc_clinic_nbr_status { get; set; }
		private string _whereDoc_clinic_nbr_status;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalDoc_nbr;
		private decimal? _originalDoc_clinic_nbr;
		private decimal? _originalDoc_nx_avail_batch;
		private string _originalDoc_clinic_nbr_status;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			DOC_NBR = _originalDoc_nbr;
			DOC_CLINIC_NBR = _originalDoc_clinic_nbr;
			DOC_NX_AVAIL_BATCH = _originalDoc_nx_avail_batch;
			DOC_CLINIC_NBR_STATUS = _originalDoc_clinic_nbr_status;
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
					new SqlParameter("DOC_CLINIC_NBR",DOC_CLINIC_NBR)
				};
			RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_F020C_DOCTOR_AUDIT_NEXT_BATCH_NBR_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_F020C_DOCTOR_AUDIT_NEXT_BATCH_NBR_Purge]");
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
						new SqlParameter("DOC_CLINIC_NBR", SqlNull(DOC_CLINIC_NBR)),
						new SqlParameter("DOC_NX_AVAIL_BATCH", SqlNull(DOC_NX_AVAIL_BATCH)),
						new SqlParameter("DOC_CLINIC_NBR_STATUS", SqlNull(DOC_CLINIC_NBR_STATUS)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_F020C_DOCTOR_AUDIT_NEXT_BATCH_NBR_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOC_NBR = Reader["DOC_NBR"].ToString();
						DOC_CLINIC_NBR = ConvertDEC(Reader["DOC_CLINIC_NBR"]);
						DOC_NX_AVAIL_BATCH = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH"]);
						DOC_CLINIC_NBR_STATUS = Reader["DOC_CLINIC_NBR_STATUS"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalDoc_clinic_nbr = ConvertDEC(Reader["DOC_CLINIC_NBR"]);
						_originalDoc_nx_avail_batch = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH"]);
						_originalDoc_clinic_nbr_status = Reader["DOC_CLINIC_NBR_STATUS"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("DOC_NBR", SqlNull(DOC_NBR)),
						new SqlParameter("DOC_CLINIC_NBR", SqlNull(DOC_CLINIC_NBR)),
						new SqlParameter("DOC_NX_AVAIL_BATCH", SqlNull(DOC_NX_AVAIL_BATCH)),
						new SqlParameter("DOC_CLINIC_NBR_STATUS", SqlNull(DOC_CLINIC_NBR_STATUS)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_F020C_DOCTOR_AUDIT_NEXT_BATCH_NBR_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOC_NBR = Reader["DOC_NBR"].ToString();
						DOC_CLINIC_NBR = ConvertDEC(Reader["DOC_CLINIC_NBR"]);
						DOC_NX_AVAIL_BATCH = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH"]);
						DOC_CLINIC_NBR_STATUS = Reader["DOC_CLINIC_NBR_STATUS"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalDoc_clinic_nbr = ConvertDEC(Reader["DOC_CLINIC_NBR"]);
						_originalDoc_nx_avail_batch = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH"]);
						_originalDoc_clinic_nbr_status = Reader["DOC_CLINIC_NBR_STATUS"].ToString();
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