using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class OHIP_RUN_DATES : BaseTable
    {
        #region Retrieve

        public ObservableCollection<OHIP_RUN_DATES> Collection( Guid? rowid,
															decimal? seq_nbrmin,
															decimal? seq_nbrmax,
															decimal? ohip_run_datemin,
															decimal? ohip_run_datemax,
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
					new SqlParameter("minOHIP_RUN_DATE",ohip_run_datemin),
					new SqlParameter("maxOHIP_RUN_DATE",ohip_run_datemax),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_OHIP_RUN_DATES_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<OHIP_RUN_DATES>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_OHIP_RUN_DATES_Search]", parameters);
            var collection = new ObservableCollection<OHIP_RUN_DATES>();

            while (Reader.Read())
            {
                collection.Add(new OHIP_RUN_DATES
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					SEQ_NBR = ConvertDEC(Reader["SEQ_NBR"]),
					OHIP_RUN_DATE = ConvertDEC(Reader["OHIP_RUN_DATE"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalSeq_nbr = ConvertDEC(Reader["SEQ_NBR"]),
					_originalOhip_run_date = ConvertDEC(Reader["OHIP_RUN_DATE"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public OHIP_RUN_DATES Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<OHIP_RUN_DATES> Collection(ObservableCollection<OHIP_RUN_DATES>
                                                               ohipRunDates = null)
        {
            if (IsSameSearch() && ohipRunDates != null)
            {
                return ohipRunDates;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<OHIP_RUN_DATES>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("SEQ_NBR",WhereSeq_nbr),
					new SqlParameter("OHIP_RUN_DATE",WhereOhip_run_date),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_OHIP_RUN_DATES_Match]", parameters);
            var collection = new ObservableCollection<OHIP_RUN_DATES>();

            while (Reader.Read())
            {
                collection.Add(new OHIP_RUN_DATES
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					SEQ_NBR = ConvertDEC(Reader["SEQ_NBR"]),
					OHIP_RUN_DATE = ConvertDEC(Reader["OHIP_RUN_DATE"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereSeq_nbr = WhereSeq_nbr,
					_whereOhip_run_date = WhereOhip_run_date,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalSeq_nbr = ConvertDEC(Reader["SEQ_NBR"]),
					_originalOhip_run_date = ConvertDEC(Reader["OHIP_RUN_DATE"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereSeq_nbr = WhereSeq_nbr;
					_whereOhip_run_date = WhereOhip_run_date;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereSeq_nbr == null 
				&& WhereOhip_run_date == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereSeq_nbr ==  _whereSeq_nbr
				&& WhereOhip_run_date ==  _whereOhip_run_date
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereSeq_nbr = null; 
			WhereOhip_run_date = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private decimal? _SEQ_NBR;
		private decimal? _OHIP_RUN_DATE;
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
		public decimal? OHIP_RUN_DATE
		{
			get { return _OHIP_RUN_DATE; }
			set
			{
				if (_OHIP_RUN_DATE != value)
				{
					_OHIP_RUN_DATE = value;
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
		public decimal? WhereOhip_run_date { get; set; }
		private decimal? _whereOhip_run_date;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private decimal? _originalSeq_nbr;
		private decimal? _originalOhip_run_date;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			SEQ_NBR = _originalSeq_nbr;
			OHIP_RUN_DATE = _originalOhip_run_date;
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
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_OHIP_RUN_DATES_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_OHIP_RUN_DATES_Purge]");
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
						new SqlParameter("OHIP_RUN_DATE", SqlNull(OHIP_RUN_DATE)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_OHIP_RUN_DATES_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						SEQ_NBR = ConvertDEC(Reader["SEQ_NBR"]);
						OHIP_RUN_DATE = ConvertDEC(Reader["OHIP_RUN_DATE"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalSeq_nbr = ConvertDEC(Reader["SEQ_NBR"]);
						_originalOhip_run_date = ConvertDEC(Reader["OHIP_RUN_DATE"]);
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("SEQ_NBR", SqlNull(SEQ_NBR)),
						new SqlParameter("OHIP_RUN_DATE", SqlNull(OHIP_RUN_DATE)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_OHIP_RUN_DATES_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						SEQ_NBR = ConvertDEC(Reader["SEQ_NBR"]);
						OHIP_RUN_DATE = ConvertDEC(Reader["OHIP_RUN_DATE"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalSeq_nbr = ConvertDEC(Reader["SEQ_NBR"]);
						_originalOhip_run_date = ConvertDEC(Reader["OHIP_RUN_DATE"]);
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