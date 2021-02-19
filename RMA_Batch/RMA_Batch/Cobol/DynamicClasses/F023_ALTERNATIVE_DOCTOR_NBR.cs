using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F023_ALTERNATIVE_DOCTOR_NBR : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F023_ALTERNATIVE_DOCTOR_NBR> Collection( Guid? rowid,
															decimal? doc_deptmin,
															decimal? doc_deptmax,
															string doc_nbr,
															decimal? alternative_doc_deptmin,
															decimal? alternative_doc_deptmax,
															string alternative_doc_nbr,
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
					new SqlParameter("minDOC_DEPT",doc_deptmin),
					new SqlParameter("maxDOC_DEPT",doc_deptmax),
					new SqlParameter("DOC_NBR",doc_nbr),
					new SqlParameter("minALTERNATIVE_DOC_DEPT",alternative_doc_deptmin),
					new SqlParameter("maxALTERNATIVE_DOC_DEPT",alternative_doc_deptmax),
					new SqlParameter("ALTERNATIVE_DOC_NBR",alternative_doc_nbr),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F023_ALTERNATIVE_DOCTOR_NBR_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F023_ALTERNATIVE_DOCTOR_NBR>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F023_ALTERNATIVE_DOCTOR_NBR_Search]", parameters);
            var collection = new ObservableCollection<F023_ALTERNATIVE_DOCTOR_NBR>();

            while (Reader.Read())
            {
                collection.Add(new F023_ALTERNATIVE_DOCTOR_NBR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOC_DEPT = ConvertDEC(Reader["DOC_DEPT"]),
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					ALTERNATIVE_DOC_DEPT = ConvertDEC(Reader["ALTERNATIVE_DOC_DEPT"]),
					ALTERNATIVE_DOC_NBR = Reader["ALTERNATIVE_DOC_NBR"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDoc_dept = ConvertDEC(Reader["DOC_DEPT"]),
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalAlternative_doc_dept = ConvertDEC(Reader["ALTERNATIVE_DOC_DEPT"]),
					_originalAlternative_doc_nbr = Reader["ALTERNATIVE_DOC_NBR"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F023_ALTERNATIVE_DOCTOR_NBR Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F023_ALTERNATIVE_DOCTOR_NBR> Collection(ObservableCollection<F023_ALTERNATIVE_DOCTOR_NBR>
                                                               f023AlternativeDoctorNbr = null)
        {
            if (IsSameSearch() && f023AlternativeDoctorNbr != null)
            {
                return f023AlternativeDoctorNbr;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F023_ALTERNATIVE_DOCTOR_NBR>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("DOC_DEPT",WhereDoc_dept),
					new SqlParameter("DOC_NBR",WhereDoc_nbr),
					new SqlParameter("ALTERNATIVE_DOC_DEPT",WhereAlternative_doc_dept),
					new SqlParameter("ALTERNATIVE_DOC_NBR",WhereAlternative_doc_nbr),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F023_ALTERNATIVE_DOCTOR_NBR_Match]", parameters);
            var collection = new ObservableCollection<F023_ALTERNATIVE_DOCTOR_NBR>();

            while (Reader.Read())
            {
                collection.Add(new F023_ALTERNATIVE_DOCTOR_NBR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOC_DEPT = ConvertDEC(Reader["DOC_DEPT"]),
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					ALTERNATIVE_DOC_DEPT = ConvertDEC(Reader["ALTERNATIVE_DOC_DEPT"]),
					ALTERNATIVE_DOC_NBR = Reader["ALTERNATIVE_DOC_NBR"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereDoc_dept = WhereDoc_dept,
					_whereDoc_nbr = WhereDoc_nbr,
					_whereAlternative_doc_dept = WhereAlternative_doc_dept,
					_whereAlternative_doc_nbr = WhereAlternative_doc_nbr,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDoc_dept = ConvertDEC(Reader["DOC_DEPT"]),
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalAlternative_doc_dept = ConvertDEC(Reader["ALTERNATIVE_DOC_DEPT"]),
					_originalAlternative_doc_nbr = Reader["ALTERNATIVE_DOC_NBR"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereDoc_dept = WhereDoc_dept;
					_whereDoc_nbr = WhereDoc_nbr;
					_whereAlternative_doc_dept = WhereAlternative_doc_dept;
					_whereAlternative_doc_nbr = WhereAlternative_doc_nbr;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereDoc_dept == null 
				&& WhereDoc_nbr == null 
				&& WhereAlternative_doc_dept == null 
				&& WhereAlternative_doc_nbr == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereDoc_dept ==  _whereDoc_dept
				&& WhereDoc_nbr ==  _whereDoc_nbr
				&& WhereAlternative_doc_dept ==  _whereAlternative_doc_dept
				&& WhereAlternative_doc_nbr ==  _whereAlternative_doc_nbr
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereDoc_dept = null; 
			WhereDoc_nbr = null; 
			WhereAlternative_doc_dept = null; 
			WhereAlternative_doc_nbr = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private decimal? _DOC_DEPT;
		private string _DOC_NBR;
		private decimal? _ALTERNATIVE_DOC_DEPT;
		private string _ALTERNATIVE_DOC_NBR;
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
		public decimal? DOC_DEPT
		{
			get { return _DOC_DEPT; }
			set
			{
				if (_DOC_DEPT != value)
				{
					_DOC_DEPT = value;
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
		public decimal? ALTERNATIVE_DOC_DEPT
		{
			get { return _ALTERNATIVE_DOC_DEPT; }
			set
			{
				if (_ALTERNATIVE_DOC_DEPT != value)
				{
					_ALTERNATIVE_DOC_DEPT = value;
					ChangeState();
				}
			}
		}
		public string ALTERNATIVE_DOC_NBR
		{
			get { return _ALTERNATIVE_DOC_NBR; }
			set
			{
				if (_ALTERNATIVE_DOC_NBR != value)
				{
					_ALTERNATIVE_DOC_NBR = value;
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
		public decimal? WhereDoc_dept { get; set; }
		private decimal? _whereDoc_dept;
		public string WhereDoc_nbr { get; set; }
		private string _whereDoc_nbr;
		public decimal? WhereAlternative_doc_dept { get; set; }
		private decimal? _whereAlternative_doc_dept;
		public string WhereAlternative_doc_nbr { get; set; }
		private string _whereAlternative_doc_nbr;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private decimal? _originalDoc_dept;
		private string _originalDoc_nbr;
		private decimal? _originalAlternative_doc_dept;
		private string _originalAlternative_doc_nbr;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			DOC_DEPT = _originalDoc_dept;
			DOC_NBR = _originalDoc_nbr;
			ALTERNATIVE_DOC_DEPT = _originalAlternative_doc_dept;
			ALTERNATIVE_DOC_NBR = _originalAlternative_doc_nbr;
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
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F023_ALTERNATIVE_DOCTOR_NBR_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F023_ALTERNATIVE_DOCTOR_NBR_Purge]");
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
						new SqlParameter("DOC_DEPT", SqlNull(DOC_DEPT)),
						new SqlParameter("DOC_NBR", SqlNull(DOC_NBR)),
						new SqlParameter("ALTERNATIVE_DOC_DEPT", SqlNull(ALTERNATIVE_DOC_DEPT)),
						new SqlParameter("ALTERNATIVE_DOC_NBR", SqlNull(ALTERNATIVE_DOC_NBR)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F023_ALTERNATIVE_DOCTOR_NBR_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOC_DEPT = ConvertDEC(Reader["DOC_DEPT"]);
						DOC_NBR = Reader["DOC_NBR"].ToString();
						ALTERNATIVE_DOC_DEPT = ConvertDEC(Reader["ALTERNATIVE_DOC_DEPT"]);
						ALTERNATIVE_DOC_NBR = Reader["ALTERNATIVE_DOC_NBR"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDoc_dept = ConvertDEC(Reader["DOC_DEPT"]);
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalAlternative_doc_dept = ConvertDEC(Reader["ALTERNATIVE_DOC_DEPT"]);
						_originalAlternative_doc_nbr = Reader["ALTERNATIVE_DOC_NBR"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("DOC_DEPT", SqlNull(DOC_DEPT)),
						new SqlParameter("DOC_NBR", SqlNull(DOC_NBR)),
						new SqlParameter("ALTERNATIVE_DOC_DEPT", SqlNull(ALTERNATIVE_DOC_DEPT)),
						new SqlParameter("ALTERNATIVE_DOC_NBR", SqlNull(ALTERNATIVE_DOC_NBR)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F023_ALTERNATIVE_DOCTOR_NBR_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOC_DEPT = ConvertDEC(Reader["DOC_DEPT"]);
						DOC_NBR = Reader["DOC_NBR"].ToString();
						ALTERNATIVE_DOC_DEPT = ConvertDEC(Reader["ALTERNATIVE_DOC_DEPT"]);
						ALTERNATIVE_DOC_NBR = Reader["ALTERNATIVE_DOC_NBR"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDoc_dept = ConvertDEC(Reader["DOC_DEPT"]);
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalAlternative_doc_dept = ConvertDEC(Reader["ALTERNATIVE_DOC_DEPT"]);
						_originalAlternative_doc_nbr = Reader["ALTERNATIVE_DOC_NBR"].ToString();
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