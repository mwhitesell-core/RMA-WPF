using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class DOC_TOTALS_TMP : BaseTable
    {
        #region Retrieve

        public ObservableCollection<DOC_TOTALS_TMP> Collection( Guid? rowid,
															string doc_nbr,
															double? x_count_1min,
															double? x_count_1max,
															double? x_count_2min,
															double? x_count_2max,
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
					new SqlParameter("minX_COUNT_1",x_count_1min),
					new SqlParameter("maxX_COUNT_1",x_count_1max),
					new SqlParameter("minX_COUNT_2",x_count_2min),
					new SqlParameter("maxX_COUNT_2",x_count_2max),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_DOC_TOTALS_TMP_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<DOC_TOTALS_TMP>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_DOC_TOTALS_TMP_Search]", parameters);
            var collection = new ObservableCollection<DOC_TOTALS_TMP>();

            while (Reader.Read())
            {
                collection.Add(new DOC_TOTALS_TMP
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					X_COUNT_1 = ConvertDEC(Reader["X_COUNT_1"]),
					X_COUNT_2 = ConvertDEC(Reader["X_COUNT_2"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalX_count_1 = ConvertDEC(Reader["X_COUNT_1"]),
					_originalX_count_2 = ConvertDEC(Reader["X_COUNT_2"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public DOC_TOTALS_TMP Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<DOC_TOTALS_TMP> Collection(ObservableCollection<DOC_TOTALS_TMP>
                                                               docTotalsTmp = null)
        {
            if (IsSameSearch() && docTotalsTmp != null)
            {
                return docTotalsTmp;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<DOC_TOTALS_TMP>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("DOC_NBR",WhereDoc_nbr),
					new SqlParameter("X_COUNT_1",WhereX_count_1),
					new SqlParameter("X_COUNT_2",WhereX_count_2),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_DOC_TOTALS_TMP_Match]", parameters);
            var collection = new ObservableCollection<DOC_TOTALS_TMP>();

            while (Reader.Read())
            {
                collection.Add(new DOC_TOTALS_TMP
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					X_COUNT_1 = ConvertDEC(Reader["X_COUNT_1"]),
					X_COUNT_2 = ConvertDEC(Reader["X_COUNT_2"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereDoc_nbr = WhereDoc_nbr,
					_whereX_count_1 = WhereX_count_1,
					_whereX_count_2 = WhereX_count_2,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalX_count_1 = ConvertDEC(Reader["X_COUNT_1"]),
					_originalX_count_2 = ConvertDEC(Reader["X_COUNT_2"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereDoc_nbr = WhereDoc_nbr;
					_whereX_count_1 = WhereX_count_1;
					_whereX_count_2 = WhereX_count_2;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereDoc_nbr == null 
				&& WhereX_count_1 == null 
				&& WhereX_count_2 == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereDoc_nbr ==  _whereDoc_nbr
				&& WhereX_count_1 ==  _whereX_count_1
				&& WhereX_count_2 ==  _whereX_count_2
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereDoc_nbr = null; 
			WhereX_count_1 = null; 
			WhereX_count_2 = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _DOC_NBR;
		private decimal? _X_COUNT_1;
		private decimal? _X_COUNT_2;
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
		public decimal? X_COUNT_1
		{
			get { return _X_COUNT_1; }
			set
			{
				if (_X_COUNT_1 != value)
				{
					_X_COUNT_1 = value;
					ChangeState();
				}
			}
		}
		public decimal? X_COUNT_2
		{
			get { return _X_COUNT_2; }
			set
			{
				if (_X_COUNT_2 != value)
				{
					_X_COUNT_2 = value;
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
		public double? WhereX_count_1 { get; set; }
		private double? _whereX_count_1;
		public double? WhereX_count_2 { get; set; }
		private double? _whereX_count_2;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalDoc_nbr;
		private decimal? _originalX_count_1;
		private decimal? _originalX_count_2;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			DOC_NBR = _originalDoc_nbr;
			X_COUNT_1 = _originalX_count_1;
			X_COUNT_2 = _originalX_count_2;
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
					new SqlParameter("DOC_NBR",DOC_NBR)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_DOC_TOTALS_TMP_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_DOC_TOTALS_TMP_Purge]");
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
						new SqlParameter("X_COUNT_1", SqlNull(X_COUNT_1)),
						new SqlParameter("X_COUNT_2", SqlNull(X_COUNT_2)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_DOC_TOTALS_TMP_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOC_NBR = Reader["DOC_NBR"].ToString();
						X_COUNT_1 = ConvertDEC(Reader["X_COUNT_1"]);
						X_COUNT_2 = ConvertDEC(Reader["X_COUNT_2"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalX_count_1 = ConvertDEC(Reader["X_COUNT_1"]);
						_originalX_count_2 = ConvertDEC(Reader["X_COUNT_2"]);
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("DOC_NBR", SqlNull(DOC_NBR)),
						new SqlParameter("X_COUNT_1", SqlNull(X_COUNT_1)),
						new SqlParameter("X_COUNT_2", SqlNull(X_COUNT_2)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_DOC_TOTALS_TMP_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOC_NBR = Reader["DOC_NBR"].ToString();
						X_COUNT_1 = ConvertDEC(Reader["X_COUNT_1"]);
						X_COUNT_2 = ConvertDEC(Reader["X_COUNT_2"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalX_count_1 = ConvertDEC(Reader["X_COUNT_1"]);
						_originalX_count_2 = ConvertDEC(Reader["X_COUNT_2"]);
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