using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class ITEM_REC : BaseTable
    {
        #region Retrieve

        public ObservableCollection<ITEM_REC> Collection( Guid? rowid,
															string item_trans_id,
															string item_rec_id,
															string item_service_cd,
															string item_filler_1,
															decimal? item_fee_submitmin,
															decimal? item_fee_submitmax,
															decimal? item_num_of_servmin,
															decimal? item_num_of_servmax,
															decimal? item_service_datemin,
															decimal? item_service_datemax,
															string item_diag_cd,
															string item_filler_diag,
															string item_filler_2,
															string item_1_override_price,
															string item_1_bilateral,
															string item_2_reserved,
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
					new SqlParameter("ITEM_TRANS_ID",item_trans_id),
					new SqlParameter("ITEM_REC_ID",item_rec_id),
					new SqlParameter("ITEM_SERVICE_CD",item_service_cd),
					new SqlParameter("ITEM_FILLER_1",item_filler_1),
					new SqlParameter("minITEM_FEE_SUBMIT",item_fee_submitmin),
					new SqlParameter("maxITEM_FEE_SUBMIT",item_fee_submitmax),
					new SqlParameter("minITEM_NUM_OF_SERV",item_num_of_servmin),
					new SqlParameter("maxITEM_NUM_OF_SERV",item_num_of_servmax),
					new SqlParameter("minITEM_SERVICE_DATE",item_service_datemin),
					new SqlParameter("maxITEM_SERVICE_DATE",item_service_datemax),
					new SqlParameter("ITEM_DIAG_CD",item_diag_cd),
					new SqlParameter("ITEM_FILLER_DIAG",item_filler_diag),
					new SqlParameter("ITEM_FILLER_2",item_filler_2),
					new SqlParameter("ITEM_1_OVERRIDE_PRICE",item_1_override_price),
					new SqlParameter("ITEM_1_BILATERAL",item_1_bilateral),
					new SqlParameter("ITEM_2_RESERVED",item_2_reserved),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[SEQUENTIAL].[sp_ITEM_REC_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<ITEM_REC>();
				}

            }

            Reader = CoreReader("[SEQUENTIAL].[sp_ITEM_REC_Search]", parameters);
            var collection = new ObservableCollection<ITEM_REC>();

            while (Reader.Read())
            {
                collection.Add(new ITEM_REC
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					ITEM_TRANS_ID = Reader["ITEM_TRANS_ID"].ToString(),
					ITEM_REC_ID = Reader["ITEM_REC_ID"].ToString(),
					ITEM_SERVICE_CD = Reader["ITEM_SERVICE_CD"].ToString(),
					ITEM_FILLER_1 = Reader["ITEM_FILLER_1"].ToString(),
					ITEM_FEE_SUBMIT = ConvertDEC(Reader["ITEM_FEE_SUBMIT"]),
					ITEM_NUM_OF_SERV = ConvertDEC(Reader["ITEM_NUM_OF_SERV"]),
					ITEM_SERVICE_DATE = ConvertDEC(Reader["ITEM_SERVICE_DATE"]),
					ITEM_DIAG_CD = Reader["ITEM_DIAG_CD"].ToString(),
					ITEM_FILLER_DIAG = Reader["ITEM_FILLER_DIAG"].ToString(),
					ITEM_FILLER_2 = Reader["ITEM_FILLER_2"].ToString(),
					ITEM_1_OVERRIDE_PRICE = Reader["ITEM_1_OVERRIDE_PRICE"].ToString(),
					ITEM_1_BILATERAL = Reader["ITEM_1_BILATERAL"].ToString(),
					ITEM_2_RESERVED = Reader["ITEM_2_RESERVED"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalItem_trans_id = Reader["ITEM_TRANS_ID"].ToString(),
					_originalItem_rec_id = Reader["ITEM_REC_ID"].ToString(),
					_originalItem_service_cd = Reader["ITEM_SERVICE_CD"].ToString(),
					_originalItem_filler_1 = Reader["ITEM_FILLER_1"].ToString(),
					_originalItem_fee_submit = ConvertDEC(Reader["ITEM_FEE_SUBMIT"]),
					_originalItem_num_of_serv = ConvertDEC(Reader["ITEM_NUM_OF_SERV"]),
					_originalItem_service_date = ConvertDEC(Reader["ITEM_SERVICE_DATE"]),
					_originalItem_diag_cd = Reader["ITEM_DIAG_CD"].ToString(),
					_originalItem_filler_diag = Reader["ITEM_FILLER_DIAG"].ToString(),
					_originalItem_filler_2 = Reader["ITEM_FILLER_2"].ToString(),
					_originalItem_1_override_price = Reader["ITEM_1_OVERRIDE_PRICE"].ToString(),
					_originalItem_1_bilateral = Reader["ITEM_1_BILATERAL"].ToString(),
					_originalItem_2_reserved = Reader["ITEM_2_RESERVED"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public ITEM_REC Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<ITEM_REC> Collection(ObservableCollection<ITEM_REC>
                                                               itemRec = null)
        {
            if (IsSameSearch() && itemRec != null)
            {
                return itemRec;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<ITEM_REC>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("ITEM_TRANS_ID",WhereItem_trans_id),
					new SqlParameter("ITEM_REC_ID",WhereItem_rec_id),
					new SqlParameter("ITEM_SERVICE_CD",WhereItem_service_cd),
					new SqlParameter("ITEM_FILLER_1",WhereItem_filler_1),
					new SqlParameter("ITEM_FEE_SUBMIT",WhereItem_fee_submit),
					new SqlParameter("ITEM_NUM_OF_SERV",WhereItem_num_of_serv),
					new SqlParameter("ITEM_SERVICE_DATE",WhereItem_service_date),
					new SqlParameter("ITEM_DIAG_CD",WhereItem_diag_cd),
					new SqlParameter("ITEM_FILLER_DIAG",WhereItem_filler_diag),
					new SqlParameter("ITEM_FILLER_2",WhereItem_filler_2),
					new SqlParameter("ITEM_1_OVERRIDE_PRICE",WhereItem_1_override_price),
					new SqlParameter("ITEM_1_BILATERAL",WhereItem_1_bilateral),
					new SqlParameter("ITEM_2_RESERVED",WhereItem_2_reserved),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[SEQUENTIAL].[sp_ITEM_REC_Match]", parameters);
            var collection = new ObservableCollection<ITEM_REC>();

            while (Reader.Read())
            {
                collection.Add(new ITEM_REC
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					ITEM_TRANS_ID = Reader["ITEM_TRANS_ID"].ToString(),
					ITEM_REC_ID = Reader["ITEM_REC_ID"].ToString(),
					ITEM_SERVICE_CD = Reader["ITEM_SERVICE_CD"].ToString(),
					ITEM_FILLER_1 = Reader["ITEM_FILLER_1"].ToString(),
					ITEM_FEE_SUBMIT = ConvertDEC(Reader["ITEM_FEE_SUBMIT"]),
					ITEM_NUM_OF_SERV = ConvertDEC(Reader["ITEM_NUM_OF_SERV"]),
					ITEM_SERVICE_DATE = ConvertDEC(Reader["ITEM_SERVICE_DATE"]),
					ITEM_DIAG_CD = Reader["ITEM_DIAG_CD"].ToString(),
					ITEM_FILLER_DIAG = Reader["ITEM_FILLER_DIAG"].ToString(),
					ITEM_FILLER_2 = Reader["ITEM_FILLER_2"].ToString(),
					ITEM_1_OVERRIDE_PRICE = Reader["ITEM_1_OVERRIDE_PRICE"].ToString(),
					ITEM_1_BILATERAL = Reader["ITEM_1_BILATERAL"].ToString(),
					ITEM_2_RESERVED = Reader["ITEM_2_RESERVED"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereItem_trans_id = WhereItem_trans_id,
					_whereItem_rec_id = WhereItem_rec_id,
					_whereItem_service_cd = WhereItem_service_cd,
					_whereItem_filler_1 = WhereItem_filler_1,
					_whereItem_fee_submit = WhereItem_fee_submit,
					_whereItem_num_of_serv = WhereItem_num_of_serv,
					_whereItem_service_date = WhereItem_service_date,
					_whereItem_diag_cd = WhereItem_diag_cd,
					_whereItem_filler_diag = WhereItem_filler_diag,
					_whereItem_filler_2 = WhereItem_filler_2,
					_whereItem_1_override_price = WhereItem_1_override_price,
					_whereItem_1_bilateral = WhereItem_1_bilateral,
					_whereItem_2_reserved = WhereItem_2_reserved,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalItem_trans_id = Reader["ITEM_TRANS_ID"].ToString(),
					_originalItem_rec_id = Reader["ITEM_REC_ID"].ToString(),
					_originalItem_service_cd = Reader["ITEM_SERVICE_CD"].ToString(),
					_originalItem_filler_1 = Reader["ITEM_FILLER_1"].ToString(),
					_originalItem_fee_submit = ConvertDEC(Reader["ITEM_FEE_SUBMIT"]),
					_originalItem_num_of_serv = ConvertDEC(Reader["ITEM_NUM_OF_SERV"]),
					_originalItem_service_date = ConvertDEC(Reader["ITEM_SERVICE_DATE"]),
					_originalItem_diag_cd = Reader["ITEM_DIAG_CD"].ToString(),
					_originalItem_filler_diag = Reader["ITEM_FILLER_DIAG"].ToString(),
					_originalItem_filler_2 = Reader["ITEM_FILLER_2"].ToString(),
					_originalItem_1_override_price = Reader["ITEM_1_OVERRIDE_PRICE"].ToString(),
					_originalItem_1_bilateral = Reader["ITEM_1_BILATERAL"].ToString(),
					_originalItem_2_reserved = Reader["ITEM_2_RESERVED"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereItem_trans_id = WhereItem_trans_id;
					_whereItem_rec_id = WhereItem_rec_id;
					_whereItem_service_cd = WhereItem_service_cd;
					_whereItem_filler_1 = WhereItem_filler_1;
					_whereItem_fee_submit = WhereItem_fee_submit;
					_whereItem_num_of_serv = WhereItem_num_of_serv;
					_whereItem_service_date = WhereItem_service_date;
					_whereItem_diag_cd = WhereItem_diag_cd;
					_whereItem_filler_diag = WhereItem_filler_diag;
					_whereItem_filler_2 = WhereItem_filler_2;
					_whereItem_1_override_price = WhereItem_1_override_price;
					_whereItem_1_bilateral = WhereItem_1_bilateral;
					_whereItem_2_reserved = WhereItem_2_reserved;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereItem_trans_id == null 
				&& WhereItem_rec_id == null 
				&& WhereItem_service_cd == null 
				&& WhereItem_filler_1 == null 
				&& WhereItem_fee_submit == null 
				&& WhereItem_num_of_serv == null 
				&& WhereItem_service_date == null 
				&& WhereItem_diag_cd == null 
				&& WhereItem_filler_diag == null 
				&& WhereItem_filler_2 == null 
				&& WhereItem_1_override_price == null 
				&& WhereItem_1_bilateral == null 
				&& WhereItem_2_reserved == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereItem_trans_id ==  _whereItem_trans_id
				&& WhereItem_rec_id ==  _whereItem_rec_id
				&& WhereItem_service_cd ==  _whereItem_service_cd
				&& WhereItem_filler_1 ==  _whereItem_filler_1
				&& WhereItem_fee_submit ==  _whereItem_fee_submit
				&& WhereItem_num_of_serv ==  _whereItem_num_of_serv
				&& WhereItem_service_date ==  _whereItem_service_date
				&& WhereItem_diag_cd ==  _whereItem_diag_cd
				&& WhereItem_filler_diag ==  _whereItem_filler_diag
				&& WhereItem_filler_2 ==  _whereItem_filler_2
				&& WhereItem_1_override_price ==  _whereItem_1_override_price
				&& WhereItem_1_bilateral ==  _whereItem_1_bilateral
				&& WhereItem_2_reserved ==  _whereItem_2_reserved
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereItem_trans_id = null; 
			WhereItem_rec_id = null; 
			WhereItem_service_cd = null; 
			WhereItem_filler_1 = null; 
			WhereItem_fee_submit = null; 
			WhereItem_num_of_serv = null; 
			WhereItem_service_date = null; 
			WhereItem_diag_cd = null; 
			WhereItem_filler_diag = null; 
			WhereItem_filler_2 = null; 
			WhereItem_1_override_price = null; 
			WhereItem_1_bilateral = null; 
			WhereItem_2_reserved = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _ITEM_TRANS_ID;
		private string _ITEM_REC_ID;
		private string _ITEM_SERVICE_CD;
		private string _ITEM_FILLER_1;
		private decimal? _ITEM_FEE_SUBMIT;
		private decimal? _ITEM_NUM_OF_SERV;
		private decimal? _ITEM_SERVICE_DATE;
		private string _ITEM_DIAG_CD;
		private string _ITEM_FILLER_DIAG;
		private string _ITEM_FILLER_2;
		private string _ITEM_1_OVERRIDE_PRICE;
		private string _ITEM_1_BILATERAL;
		private string _ITEM_2_RESERVED;
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
		public string ITEM_TRANS_ID
		{
			get { return _ITEM_TRANS_ID; }
			set
			{
				if (_ITEM_TRANS_ID != value)
				{
					_ITEM_TRANS_ID = value;
					ChangeState();
				}
			}
		}
		public string ITEM_REC_ID
		{
			get { return _ITEM_REC_ID; }
			set
			{
				if (_ITEM_REC_ID != value)
				{
					_ITEM_REC_ID = value;
					ChangeState();
				}
			}
		}
		public string ITEM_SERVICE_CD
		{
			get { return _ITEM_SERVICE_CD; }
			set
			{
				if (_ITEM_SERVICE_CD != value)
				{
					_ITEM_SERVICE_CD = value;
					ChangeState();
				}
			}
		}
		public string ITEM_FILLER_1
		{
			get { return _ITEM_FILLER_1; }
			set
			{
				if (_ITEM_FILLER_1 != value)
				{
					_ITEM_FILLER_1 = value;
					ChangeState();
				}
			}
		}
		public decimal? ITEM_FEE_SUBMIT
		{
			get { return _ITEM_FEE_SUBMIT; }
			set
			{
				if (_ITEM_FEE_SUBMIT != value)
				{
					_ITEM_FEE_SUBMIT = value;
					ChangeState();
				}
			}
		}
		public decimal? ITEM_NUM_OF_SERV
		{
			get { return _ITEM_NUM_OF_SERV; }
			set
			{
				if (_ITEM_NUM_OF_SERV != value)
				{
					_ITEM_NUM_OF_SERV = value;
					ChangeState();
				}
			}
		}
		public decimal? ITEM_SERVICE_DATE
		{
			get { return _ITEM_SERVICE_DATE; }
			set
			{
				if (_ITEM_SERVICE_DATE != value)
				{
					_ITEM_SERVICE_DATE = value;
					ChangeState();
				}
			}
		}
		public string ITEM_DIAG_CD
		{
			get { return _ITEM_DIAG_CD; }
			set
			{
				if (_ITEM_DIAG_CD != value)
				{
					_ITEM_DIAG_CD = value;
					ChangeState();
				}
			}
		}
		public string ITEM_FILLER_DIAG
		{
			get { return _ITEM_FILLER_DIAG; }
			set
			{
				if (_ITEM_FILLER_DIAG != value)
				{
					_ITEM_FILLER_DIAG = value;
					ChangeState();
				}
			}
		}
		public string ITEM_FILLER_2
		{
			get { return _ITEM_FILLER_2; }
			set
			{
				if (_ITEM_FILLER_2 != value)
				{
					_ITEM_FILLER_2 = value;
					ChangeState();
				}
			}
		}
		public string ITEM_1_OVERRIDE_PRICE
		{
			get { return _ITEM_1_OVERRIDE_PRICE; }
			set
			{
				if (_ITEM_1_OVERRIDE_PRICE != value)
				{
					_ITEM_1_OVERRIDE_PRICE = value;
					ChangeState();
				}
			}
		}
		public string ITEM_1_BILATERAL
		{
			get { return _ITEM_1_BILATERAL; }
			set
			{
				if (_ITEM_1_BILATERAL != value)
				{
					_ITEM_1_BILATERAL = value;
					ChangeState();
				}
			}
		}
		public string ITEM_2_RESERVED
		{
			get { return _ITEM_2_RESERVED; }
			set
			{
				if (_ITEM_2_RESERVED != value)
				{
					_ITEM_2_RESERVED = value;
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
		public string WhereItem_trans_id { get; set; }
		private string _whereItem_trans_id;
		public string WhereItem_rec_id { get; set; }
		private string _whereItem_rec_id;
		public string WhereItem_service_cd { get; set; }
		private string _whereItem_service_cd;
		public string WhereItem_filler_1 { get; set; }
		private string _whereItem_filler_1;
		public decimal? WhereItem_fee_submit { get; set; }
		private decimal? _whereItem_fee_submit;
		public decimal? WhereItem_num_of_serv { get; set; }
		private decimal? _whereItem_num_of_serv;
		public decimal? WhereItem_service_date { get; set; }
		private decimal? _whereItem_service_date;
		public string WhereItem_diag_cd { get; set; }
		private string _whereItem_diag_cd;
		public string WhereItem_filler_diag { get; set; }
		private string _whereItem_filler_diag;
		public string WhereItem_filler_2 { get; set; }
		private string _whereItem_filler_2;
		public string WhereItem_1_override_price { get; set; }
		private string _whereItem_1_override_price;
		public string WhereItem_1_bilateral { get; set; }
		private string _whereItem_1_bilateral;
		public string WhereItem_2_reserved { get; set; }
		private string _whereItem_2_reserved;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalItem_trans_id;
		private string _originalItem_rec_id;
		private string _originalItem_service_cd;
		private string _originalItem_filler_1;
		private decimal? _originalItem_fee_submit;
		private decimal? _originalItem_num_of_serv;
		private decimal? _originalItem_service_date;
		private string _originalItem_diag_cd;
		private string _originalItem_filler_diag;
		private string _originalItem_filler_2;
		private string _originalItem_1_override_price;
		private string _originalItem_1_bilateral;
		private string _originalItem_2_reserved;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			ITEM_TRANS_ID = _originalItem_trans_id;
			ITEM_REC_ID = _originalItem_rec_id;
			ITEM_SERVICE_CD = _originalItem_service_cd;
			ITEM_FILLER_1 = _originalItem_filler_1;
			ITEM_FEE_SUBMIT = _originalItem_fee_submit;
			ITEM_NUM_OF_SERV = _originalItem_num_of_serv;
			ITEM_SERVICE_DATE = _originalItem_service_date;
			ITEM_DIAG_CD = _originalItem_diag_cd;
			ITEM_FILLER_DIAG = _originalItem_filler_diag;
			ITEM_FILLER_2 = _originalItem_filler_2;
			ITEM_1_OVERRIDE_PRICE = _originalItem_1_override_price;
			ITEM_1_BILATERAL = _originalItem_1_bilateral;
			ITEM_2_RESERVED = _originalItem_2_reserved;
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
			RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_ITEM_REC_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_ITEM_REC_Purge]");
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
						new SqlParameter("ITEM_TRANS_ID", SqlNull(ITEM_TRANS_ID)),
						new SqlParameter("ITEM_REC_ID", SqlNull(ITEM_REC_ID)),
						new SqlParameter("ITEM_SERVICE_CD", SqlNull(ITEM_SERVICE_CD)),
						new SqlParameter("ITEM_FILLER_1", SqlNull(ITEM_FILLER_1)),
						new SqlParameter("ITEM_FEE_SUBMIT", SqlNull(ITEM_FEE_SUBMIT)),
						new SqlParameter("ITEM_NUM_OF_SERV", SqlNull(ITEM_NUM_OF_SERV)),
						new SqlParameter("ITEM_SERVICE_DATE", SqlNull(ITEM_SERVICE_DATE)),
						new SqlParameter("ITEM_DIAG_CD", SqlNull(ITEM_DIAG_CD)),
						new SqlParameter("ITEM_FILLER_DIAG", SqlNull(ITEM_FILLER_DIAG)),
						new SqlParameter("ITEM_FILLER_2", SqlNull(ITEM_FILLER_2)),
						new SqlParameter("ITEM_1_OVERRIDE_PRICE", SqlNull(ITEM_1_OVERRIDE_PRICE)),
						new SqlParameter("ITEM_1_BILATERAL", SqlNull(ITEM_1_BILATERAL)),
						new SqlParameter("ITEM_2_RESERVED", SqlNull(ITEM_2_RESERVED)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_ITEM_REC_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						ITEM_TRANS_ID = Reader["ITEM_TRANS_ID"].ToString();
						ITEM_REC_ID = Reader["ITEM_REC_ID"].ToString();
						ITEM_SERVICE_CD = Reader["ITEM_SERVICE_CD"].ToString();
						ITEM_FILLER_1 = Reader["ITEM_FILLER_1"].ToString();
						ITEM_FEE_SUBMIT = ConvertDEC(Reader["ITEM_FEE_SUBMIT"]);
						ITEM_NUM_OF_SERV = ConvertDEC(Reader["ITEM_NUM_OF_SERV"]);
						ITEM_SERVICE_DATE = ConvertDEC(Reader["ITEM_SERVICE_DATE"]);
						ITEM_DIAG_CD = Reader["ITEM_DIAG_CD"].ToString();
						ITEM_FILLER_DIAG = Reader["ITEM_FILLER_DIAG"].ToString();
						ITEM_FILLER_2 = Reader["ITEM_FILLER_2"].ToString();
						ITEM_1_OVERRIDE_PRICE = Reader["ITEM_1_OVERRIDE_PRICE"].ToString();
						ITEM_1_BILATERAL = Reader["ITEM_1_BILATERAL"].ToString();
						ITEM_2_RESERVED = Reader["ITEM_2_RESERVED"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalItem_trans_id = Reader["ITEM_TRANS_ID"].ToString();
						_originalItem_rec_id = Reader["ITEM_REC_ID"].ToString();
						_originalItem_service_cd = Reader["ITEM_SERVICE_CD"].ToString();
						_originalItem_filler_1 = Reader["ITEM_FILLER_1"].ToString();
						_originalItem_fee_submit = ConvertDEC(Reader["ITEM_FEE_SUBMIT"]);
						_originalItem_num_of_serv = ConvertDEC(Reader["ITEM_NUM_OF_SERV"]);
						_originalItem_service_date = ConvertDEC(Reader["ITEM_SERVICE_DATE"]);
						_originalItem_diag_cd = Reader["ITEM_DIAG_CD"].ToString();
						_originalItem_filler_diag = Reader["ITEM_FILLER_DIAG"].ToString();
						_originalItem_filler_2 = Reader["ITEM_FILLER_2"].ToString();
						_originalItem_1_override_price = Reader["ITEM_1_OVERRIDE_PRICE"].ToString();
						_originalItem_1_bilateral = Reader["ITEM_1_BILATERAL"].ToString();
						_originalItem_2_reserved = Reader["ITEM_2_RESERVED"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("ITEM_TRANS_ID", SqlNull(ITEM_TRANS_ID)),
						new SqlParameter("ITEM_REC_ID", SqlNull(ITEM_REC_ID)),
						new SqlParameter("ITEM_SERVICE_CD", SqlNull(ITEM_SERVICE_CD)),
						new SqlParameter("ITEM_FILLER_1", SqlNull(ITEM_FILLER_1)),
						new SqlParameter("ITEM_FEE_SUBMIT", SqlNull(ITEM_FEE_SUBMIT)),
						new SqlParameter("ITEM_NUM_OF_SERV", SqlNull(ITEM_NUM_OF_SERV)),
						new SqlParameter("ITEM_SERVICE_DATE", SqlNull(ITEM_SERVICE_DATE)),
						new SqlParameter("ITEM_DIAG_CD", SqlNull(ITEM_DIAG_CD)),
						new SqlParameter("ITEM_FILLER_DIAG", SqlNull(ITEM_FILLER_DIAG)),
						new SqlParameter("ITEM_FILLER_2", SqlNull(ITEM_FILLER_2)),
						new SqlParameter("ITEM_1_OVERRIDE_PRICE", SqlNull(ITEM_1_OVERRIDE_PRICE)),
						new SqlParameter("ITEM_1_BILATERAL", SqlNull(ITEM_1_BILATERAL)),
						new SqlParameter("ITEM_2_RESERVED", SqlNull(ITEM_2_RESERVED)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_ITEM_REC_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						ITEM_TRANS_ID = Reader["ITEM_TRANS_ID"].ToString();
						ITEM_REC_ID = Reader["ITEM_REC_ID"].ToString();
						ITEM_SERVICE_CD = Reader["ITEM_SERVICE_CD"].ToString();
						ITEM_FILLER_1 = Reader["ITEM_FILLER_1"].ToString();
						ITEM_FEE_SUBMIT = ConvertDEC(Reader["ITEM_FEE_SUBMIT"]);
						ITEM_NUM_OF_SERV = ConvertDEC(Reader["ITEM_NUM_OF_SERV"]);
						ITEM_SERVICE_DATE = ConvertDEC(Reader["ITEM_SERVICE_DATE"]);
						ITEM_DIAG_CD = Reader["ITEM_DIAG_CD"].ToString();
						ITEM_FILLER_DIAG = Reader["ITEM_FILLER_DIAG"].ToString();
						ITEM_FILLER_2 = Reader["ITEM_FILLER_2"].ToString();
						ITEM_1_OVERRIDE_PRICE = Reader["ITEM_1_OVERRIDE_PRICE"].ToString();
						ITEM_1_BILATERAL = Reader["ITEM_1_BILATERAL"].ToString();
						ITEM_2_RESERVED = Reader["ITEM_2_RESERVED"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalItem_trans_id = Reader["ITEM_TRANS_ID"].ToString();
						_originalItem_rec_id = Reader["ITEM_REC_ID"].ToString();
						_originalItem_service_cd = Reader["ITEM_SERVICE_CD"].ToString();
						_originalItem_filler_1 = Reader["ITEM_FILLER_1"].ToString();
						_originalItem_fee_submit = ConvertDEC(Reader["ITEM_FEE_SUBMIT"]);
						_originalItem_num_of_serv = ConvertDEC(Reader["ITEM_NUM_OF_SERV"]);
						_originalItem_service_date = ConvertDEC(Reader["ITEM_SERVICE_DATE"]);
						_originalItem_diag_cd = Reader["ITEM_DIAG_CD"].ToString();
						_originalItem_filler_diag = Reader["ITEM_FILLER_DIAG"].ToString();
						_originalItem_filler_2 = Reader["ITEM_FILLER_2"].ToString();
						_originalItem_1_override_price = Reader["ITEM_1_OVERRIDE_PRICE"].ToString();
						_originalItem_1_bilateral = Reader["ITEM_1_BILATERAL"].ToString();
						_originalItem_2_reserved = Reader["ITEM_2_RESERVED"].ToString();
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