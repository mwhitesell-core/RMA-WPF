using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F040_DTL : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F040_DTL> Collection( Guid? rowid,
															string fee_oma_cd,
															decimal? dept_nbrmin,
															decimal? dept_nbrmax,
															string doc_nbr,
															string data_entry_flag,
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
					new SqlParameter("FEE_OMA_CD",fee_oma_cd),
					new SqlParameter("minDEPT_NBR",dept_nbrmin),
					new SqlParameter("maxDEPT_NBR",dept_nbrmax),
					new SqlParameter("DOC_NBR",doc_nbr),
					new SqlParameter("DATA_ENTRY_FLAG",data_entry_flag),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F040_DTL_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F040_DTL>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F040_DTL_Search]", parameters);
            var collection = new ObservableCollection<F040_DTL>();

            while (Reader.Read())
            {
                collection.Add(new F040_DTL
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					FEE_OMA_CD = Reader["FEE_OMA_CD"].ToString(),
					DEPT_NBR = ConvertDEC(Reader["DEPT_NBR"]),
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					DATA_ENTRY_FLAG = Reader["DATA_ENTRY_FLAG"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalFee_oma_cd = Reader["FEE_OMA_CD"].ToString(),
					_originalDept_nbr = ConvertDEC(Reader["DEPT_NBR"]),
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalData_entry_flag = Reader["DATA_ENTRY_FLAG"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F040_DTL Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F040_DTL> Collection(ObservableCollection<F040_DTL>
                                                               f040Dtl = null)
        {
            if (IsSameSearch() && f040Dtl != null)
            {
                return f040Dtl;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F040_DTL>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("FEE_OMA_CD",WhereFee_oma_cd),
					new SqlParameter("DEPT_NBR",WhereDept_nbr),
					new SqlParameter("DOC_NBR",WhereDoc_nbr),
					new SqlParameter("DATA_ENTRY_FLAG",WhereData_entry_flag),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F040_DTL_Match]", parameters);
            var collection = new ObservableCollection<F040_DTL>();

            while (Reader.Read())
            {
                collection.Add(new F040_DTL
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					FEE_OMA_CD = Reader["FEE_OMA_CD"].ToString(),
					DEPT_NBR = ConvertDEC(Reader["DEPT_NBR"]),
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					DATA_ENTRY_FLAG = Reader["DATA_ENTRY_FLAG"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereFee_oma_cd = WhereFee_oma_cd,
					_whereDept_nbr = WhereDept_nbr,
					_whereDoc_nbr = WhereDoc_nbr,
					_whereData_entry_flag = WhereData_entry_flag,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalFee_oma_cd = Reader["FEE_OMA_CD"].ToString(),
					_originalDept_nbr = ConvertDEC(Reader["DEPT_NBR"]),
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalData_entry_flag = Reader["DATA_ENTRY_FLAG"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereFee_oma_cd = WhereFee_oma_cd;
					_whereDept_nbr = WhereDept_nbr;
					_whereDoc_nbr = WhereDoc_nbr;
					_whereData_entry_flag = WhereData_entry_flag;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereFee_oma_cd == null 
				&& WhereDept_nbr == null 
				&& WhereDoc_nbr == null 
				&& WhereData_entry_flag == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereFee_oma_cd ==  _whereFee_oma_cd
				&& WhereDept_nbr ==  _whereDept_nbr
				&& WhereDoc_nbr ==  _whereDoc_nbr
				&& WhereData_entry_flag ==  _whereData_entry_flag
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereFee_oma_cd = null; 
			WhereDept_nbr = null; 
			WhereDoc_nbr = null; 
			WhereData_entry_flag = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _FEE_OMA_CD;
		private decimal? _DEPT_NBR;
		private string _DOC_NBR;
		private string _DATA_ENTRY_FLAG;
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
		public string FEE_OMA_CD
		{
			get { return _FEE_OMA_CD; }
			set
			{
				if (_FEE_OMA_CD != value)
				{
					_FEE_OMA_CD = value;
					ChangeState();
				}
			}
		}
		public decimal? DEPT_NBR
		{
			get { return _DEPT_NBR; }
			set
			{
				if (_DEPT_NBR != value)
				{
					_DEPT_NBR = value;
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
		public string DATA_ENTRY_FLAG
		{
			get { return _DATA_ENTRY_FLAG; }
			set
			{
				if (_DATA_ENTRY_FLAG != value)
				{
					_DATA_ENTRY_FLAG = value;
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
		public string WhereFee_oma_cd { get; set; }
		private string _whereFee_oma_cd;
		public decimal? WhereDept_nbr { get; set; }
		private decimal? _whereDept_nbr;
		public string WhereDoc_nbr { get; set; }
		private string _whereDoc_nbr;
		public string WhereData_entry_flag { get; set; }
		private string _whereData_entry_flag;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalFee_oma_cd;
		private decimal? _originalDept_nbr;
		private string _originalDoc_nbr;
		private string _originalData_entry_flag;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			FEE_OMA_CD = _originalFee_oma_cd;
			DEPT_NBR = _originalDept_nbr;
			DOC_NBR = _originalDoc_nbr;
			DATA_ENTRY_FLAG = _originalData_entry_flag;
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
					new SqlParameter("FEE_OMA_CD",FEE_OMA_CD),
					new SqlParameter("DEPT_NBR",DEPT_NBR),
					new SqlParameter("DOC_NBR",DOC_NBR)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F040_DTL_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F040_DTL_Purge]");
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
						new SqlParameter("FEE_OMA_CD", SqlNull(FEE_OMA_CD)),
						new SqlParameter("DEPT_NBR", SqlNull(DEPT_NBR)),
						new SqlParameter("DOC_NBR", SqlNull(DOC_NBR)),
						new SqlParameter("DATA_ENTRY_FLAG", SqlNull(DATA_ENTRY_FLAG)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F040_DTL_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						FEE_OMA_CD = Reader["FEE_OMA_CD"].ToString();
						DEPT_NBR = ConvertDEC(Reader["DEPT_NBR"]);
						DOC_NBR = Reader["DOC_NBR"].ToString();
						DATA_ENTRY_FLAG = Reader["DATA_ENTRY_FLAG"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalFee_oma_cd = Reader["FEE_OMA_CD"].ToString();
						_originalDept_nbr = ConvertDEC(Reader["DEPT_NBR"]);
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalData_entry_flag = Reader["DATA_ENTRY_FLAG"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("FEE_OMA_CD", SqlNull(FEE_OMA_CD)),
						new SqlParameter("DEPT_NBR", SqlNull(DEPT_NBR)),
						new SqlParameter("DOC_NBR", SqlNull(DOC_NBR)),
						new SqlParameter("DATA_ENTRY_FLAG", SqlNull(DATA_ENTRY_FLAG)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F040_DTL_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						FEE_OMA_CD = Reader["FEE_OMA_CD"].ToString();
						DEPT_NBR = ConvertDEC(Reader["DEPT_NBR"]);
						DOC_NBR = Reader["DOC_NBR"].ToString();
						DATA_ENTRY_FLAG = Reader["DATA_ENTRY_FLAG"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalFee_oma_cd = Reader["FEE_OMA_CD"].ToString();
						_originalDept_nbr = ConvertDEC(Reader["DEPT_NBR"]);
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalData_entry_flag = Reader["DATA_ENTRY_FLAG"].ToString();
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