using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class TRAILER_REC : BaseTable
    {
        #region Retrieve

        public ObservableCollection<TRAILER_REC> Collection( Guid? rowid,
															string trailer_trans_id,
															string trailer_rec_id,
															decimal? trailer_h_countmin,
															decimal? trailer_h_countmax,
															decimal? trailer_r_countmin,
															decimal? trailer_r_countmax,
															decimal? trailer_t_countmin,
															decimal? trailer_t_countmax,
															string trailer_filler,
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
					new SqlParameter("TRAILER_TRANS_ID",trailer_trans_id),
					new SqlParameter("TRAILER_REC_ID",trailer_rec_id),
					new SqlParameter("minTRAILER_H_COUNT",trailer_h_countmin),
					new SqlParameter("maxTRAILER_H_COUNT",trailer_h_countmax),
					new SqlParameter("minTRAILER_R_COUNT",trailer_r_countmin),
					new SqlParameter("maxTRAILER_R_COUNT",trailer_r_countmax),
					new SqlParameter("minTRAILER_T_COUNT",trailer_t_countmin),
					new SqlParameter("maxTRAILER_T_COUNT",trailer_t_countmax),
					new SqlParameter("TRAILER_FILLER",trailer_filler),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[SEQUENTIAL].[sp_TRAILER_REC_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<TRAILER_REC>();
				}

            }

            Reader = CoreReader("[SEQUENTIAL].[sp_TRAILER_REC_Search]", parameters);
            var collection = new ObservableCollection<TRAILER_REC>();

            while (Reader.Read())
            {
                collection.Add(new TRAILER_REC
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					TRAILER_TRANS_ID = Reader["TRAILER_TRANS_ID"].ToString(),
					TRAILER_REC_ID = Reader["TRAILER_REC_ID"].ToString(),
					TRAILER_H_COUNT = ConvertDEC(Reader["TRAILER_H_COUNT"]),
					TRAILER_R_COUNT = ConvertDEC(Reader["TRAILER_R_COUNT"]),
					TRAILER_T_COUNT = ConvertDEC(Reader["TRAILER_T_COUNT"]),
					TRAILER_FILLER = Reader["TRAILER_FILLER"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalTrailer_trans_id = Reader["TRAILER_TRANS_ID"].ToString(),
					_originalTrailer_rec_id = Reader["TRAILER_REC_ID"].ToString(),
					_originalTrailer_h_count = ConvertDEC(Reader["TRAILER_H_COUNT"]),
					_originalTrailer_r_count = ConvertDEC(Reader["TRAILER_R_COUNT"]),
					_originalTrailer_t_count = ConvertDEC(Reader["TRAILER_T_COUNT"]),
					_originalTrailer_filler = Reader["TRAILER_FILLER"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public TRAILER_REC Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<TRAILER_REC> Collection(ObservableCollection<TRAILER_REC>
                                                               trailerRec = null)
        {
            if (IsSameSearch() && trailerRec != null)
            {
                return trailerRec;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<TRAILER_REC>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("TRAILER_TRANS_ID",WhereTrailer_trans_id),
					new SqlParameter("TRAILER_REC_ID",WhereTrailer_rec_id),
					new SqlParameter("TRAILER_H_COUNT",WhereTrailer_h_count),
					new SqlParameter("TRAILER_R_COUNT",WhereTrailer_r_count),
					new SqlParameter("TRAILER_T_COUNT",WhereTrailer_t_count),
					new SqlParameter("TRAILER_FILLER",WhereTrailer_filler),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[SEQUENTIAL].[sp_TRAILER_REC_Match]", parameters);
            var collection = new ObservableCollection<TRAILER_REC>();

            while (Reader.Read())
            {
                collection.Add(new TRAILER_REC
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					TRAILER_TRANS_ID = Reader["TRAILER_TRANS_ID"].ToString(),
					TRAILER_REC_ID = Reader["TRAILER_REC_ID"].ToString(),
					TRAILER_H_COUNT = ConvertDEC(Reader["TRAILER_H_COUNT"]),
					TRAILER_R_COUNT = ConvertDEC(Reader["TRAILER_R_COUNT"]),
					TRAILER_T_COUNT = ConvertDEC(Reader["TRAILER_T_COUNT"]),
					TRAILER_FILLER = Reader["TRAILER_FILLER"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereTrailer_trans_id = WhereTrailer_trans_id,
					_whereTrailer_rec_id = WhereTrailer_rec_id,
					_whereTrailer_h_count = WhereTrailer_h_count,
					_whereTrailer_r_count = WhereTrailer_r_count,
					_whereTrailer_t_count = WhereTrailer_t_count,
					_whereTrailer_filler = WhereTrailer_filler,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalTrailer_trans_id = Reader["TRAILER_TRANS_ID"].ToString(),
					_originalTrailer_rec_id = Reader["TRAILER_REC_ID"].ToString(),
					_originalTrailer_h_count = ConvertDEC(Reader["TRAILER_H_COUNT"]),
					_originalTrailer_r_count = ConvertDEC(Reader["TRAILER_R_COUNT"]),
					_originalTrailer_t_count = ConvertDEC(Reader["TRAILER_T_COUNT"]),
					_originalTrailer_filler = Reader["TRAILER_FILLER"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereTrailer_trans_id = WhereTrailer_trans_id;
					_whereTrailer_rec_id = WhereTrailer_rec_id;
					_whereTrailer_h_count = WhereTrailer_h_count;
					_whereTrailer_r_count = WhereTrailer_r_count;
					_whereTrailer_t_count = WhereTrailer_t_count;
					_whereTrailer_filler = WhereTrailer_filler;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereTrailer_trans_id == null 
				&& WhereTrailer_rec_id == null 
				&& WhereTrailer_h_count == null 
				&& WhereTrailer_r_count == null 
				&& WhereTrailer_t_count == null 
				&& WhereTrailer_filler == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereTrailer_trans_id ==  _whereTrailer_trans_id
				&& WhereTrailer_rec_id ==  _whereTrailer_rec_id
				&& WhereTrailer_h_count ==  _whereTrailer_h_count
				&& WhereTrailer_r_count ==  _whereTrailer_r_count
				&& WhereTrailer_t_count ==  _whereTrailer_t_count
				&& WhereTrailer_filler ==  _whereTrailer_filler
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereTrailer_trans_id = null; 
			WhereTrailer_rec_id = null; 
			WhereTrailer_h_count = null; 
			WhereTrailer_r_count = null; 
			WhereTrailer_t_count = null; 
			WhereTrailer_filler = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _TRAILER_TRANS_ID;
		private string _TRAILER_REC_ID;
		private decimal? _TRAILER_H_COUNT;
		private decimal? _TRAILER_R_COUNT;
		private decimal? _TRAILER_T_COUNT;
		private string _TRAILER_FILLER;
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
		public string TRAILER_TRANS_ID
		{
			get { return _TRAILER_TRANS_ID; }
			set
			{
				if (_TRAILER_TRANS_ID != value)
				{
					_TRAILER_TRANS_ID = value;
					ChangeState();
				}
			}
		}
		public string TRAILER_REC_ID
		{
			get { return _TRAILER_REC_ID; }
			set
			{
				if (_TRAILER_REC_ID != value)
				{
					_TRAILER_REC_ID = value;
					ChangeState();
				}
			}
		}
		public decimal? TRAILER_H_COUNT
		{
			get { return _TRAILER_H_COUNT; }
			set
			{
				if (_TRAILER_H_COUNT != value)
				{
					_TRAILER_H_COUNT = value;
					ChangeState();
				}
			}
		}
		public decimal? TRAILER_R_COUNT
		{
			get { return _TRAILER_R_COUNT; }
			set
			{
				if (_TRAILER_R_COUNT != value)
				{
					_TRAILER_R_COUNT = value;
					ChangeState();
				}
			}
		}
		public decimal? TRAILER_T_COUNT
		{
			get { return _TRAILER_T_COUNT; }
			set
			{
				if (_TRAILER_T_COUNT != value)
				{
					_TRAILER_T_COUNT = value;
					ChangeState();
				}
			}
		}
		public string TRAILER_FILLER
		{
			get { return _TRAILER_FILLER; }
			set
			{
				if (_TRAILER_FILLER != value)
				{
					_TRAILER_FILLER = value;
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
		public string WhereTrailer_trans_id { get; set; }
		private string _whereTrailer_trans_id;
		public string WhereTrailer_rec_id { get; set; }
		private string _whereTrailer_rec_id;
		public decimal? WhereTrailer_h_count { get; set; }
		private decimal? _whereTrailer_h_count;
		public decimal? WhereTrailer_r_count { get; set; }
		private decimal? _whereTrailer_r_count;
		public decimal? WhereTrailer_t_count { get; set; }
		private decimal? _whereTrailer_t_count;
		public string WhereTrailer_filler { get; set; }
		private string _whereTrailer_filler;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalTrailer_trans_id;
		private string _originalTrailer_rec_id;
		private decimal? _originalTrailer_h_count;
		private decimal? _originalTrailer_r_count;
		private decimal? _originalTrailer_t_count;
		private string _originalTrailer_filler;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			TRAILER_TRANS_ID = _originalTrailer_trans_id;
			TRAILER_REC_ID = _originalTrailer_rec_id;
			TRAILER_H_COUNT = _originalTrailer_h_count;
			TRAILER_R_COUNT = _originalTrailer_r_count;
			TRAILER_T_COUNT = _originalTrailer_t_count;
			TRAILER_FILLER = _originalTrailer_filler;
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
			RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_TRAILER_REC_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_TRAILER_REC_Purge]");
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
						new SqlParameter("TRAILER_TRANS_ID", SqlNull(TRAILER_TRANS_ID)),
						new SqlParameter("TRAILER_REC_ID", SqlNull(TRAILER_REC_ID)),
						new SqlParameter("TRAILER_H_COUNT", SqlNull(TRAILER_H_COUNT)),
						new SqlParameter("TRAILER_R_COUNT", SqlNull(TRAILER_R_COUNT)),
						new SqlParameter("TRAILER_T_COUNT", SqlNull(TRAILER_T_COUNT)),
						new SqlParameter("TRAILER_FILLER", SqlNull(TRAILER_FILLER)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_TRAILER_REC_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						TRAILER_TRANS_ID = Reader["TRAILER_TRANS_ID"].ToString();
						TRAILER_REC_ID = Reader["TRAILER_REC_ID"].ToString();
						TRAILER_H_COUNT = ConvertDEC(Reader["TRAILER_H_COUNT"]);
						TRAILER_R_COUNT = ConvertDEC(Reader["TRAILER_R_COUNT"]);
						TRAILER_T_COUNT = ConvertDEC(Reader["TRAILER_T_COUNT"]);
						TRAILER_FILLER = Reader["TRAILER_FILLER"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalTrailer_trans_id = Reader["TRAILER_TRANS_ID"].ToString();
						_originalTrailer_rec_id = Reader["TRAILER_REC_ID"].ToString();
						_originalTrailer_h_count = ConvertDEC(Reader["TRAILER_H_COUNT"]);
						_originalTrailer_r_count = ConvertDEC(Reader["TRAILER_R_COUNT"]);
						_originalTrailer_t_count = ConvertDEC(Reader["TRAILER_T_COUNT"]);
						_originalTrailer_filler = Reader["TRAILER_FILLER"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("TRAILER_TRANS_ID", SqlNull(TRAILER_TRANS_ID)),
						new SqlParameter("TRAILER_REC_ID", SqlNull(TRAILER_REC_ID)),
						new SqlParameter("TRAILER_H_COUNT", SqlNull(TRAILER_H_COUNT)),
						new SqlParameter("TRAILER_R_COUNT", SqlNull(TRAILER_R_COUNT)),
						new SqlParameter("TRAILER_T_COUNT", SqlNull(TRAILER_T_COUNT)),
						new SqlParameter("TRAILER_FILLER", SqlNull(TRAILER_FILLER)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_TRAILER_REC_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						TRAILER_TRANS_ID = Reader["TRAILER_TRANS_ID"].ToString();
						TRAILER_REC_ID = Reader["TRAILER_REC_ID"].ToString();
						TRAILER_H_COUNT = ConvertDEC(Reader["TRAILER_H_COUNT"]);
						TRAILER_R_COUNT = ConvertDEC(Reader["TRAILER_R_COUNT"]);
						TRAILER_T_COUNT = ConvertDEC(Reader["TRAILER_T_COUNT"]);
						TRAILER_FILLER = Reader["TRAILER_FILLER"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalTrailer_trans_id = Reader["TRAILER_TRANS_ID"].ToString();
						_originalTrailer_rec_id = Reader["TRAILER_REC_ID"].ToString();
						_originalTrailer_h_count = ConvertDEC(Reader["TRAILER_H_COUNT"]);
						_originalTrailer_r_count = ConvertDEC(Reader["TRAILER_R_COUNT"]);
						_originalTrailer_t_count = ConvertDEC(Reader["TRAILER_T_COUNT"]);
						_originalTrailer_filler = Reader["TRAILER_FILLER"].ToString();
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