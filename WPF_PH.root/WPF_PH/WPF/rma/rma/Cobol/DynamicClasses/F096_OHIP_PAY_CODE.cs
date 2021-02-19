using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F096_OHIP_PAY_CODE : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F096_OHIP_PAY_CODE> Collection( Guid? rowid,
															string rat_code,
															string rat_explanation,
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
					new SqlParameter("RAT_CODE",rat_code),
					new SqlParameter("RAT_EXPLANATION",rat_explanation),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F096_OHIP_PAY_CODE_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F096_OHIP_PAY_CODE>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F096_OHIP_PAY_CODE_Search]", parameters);
            var collection = new ObservableCollection<F096_OHIP_PAY_CODE>();

            while (Reader.Read())
            {
                collection.Add(new F096_OHIP_PAY_CODE
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					RAT_CODE = Reader["RAT_CODE"].ToString(),
					RAT_EXPLANATION = Reader["RAT_EXPLANATION"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalRat_code = Reader["RAT_CODE"].ToString(),
					_originalRat_explanation = Reader["RAT_EXPLANATION"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F096_OHIP_PAY_CODE Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F096_OHIP_PAY_CODE> Collection(ObservableCollection<F096_OHIP_PAY_CODE>
                                                               f096OhipPayCode = null)
        {
            if (IsSameSearch() && f096OhipPayCode != null)
            {
                return f096OhipPayCode;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F096_OHIP_PAY_CODE>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("RAT_CODE",WhereRat_code),
					new SqlParameter("RAT_EXPLANATION",WhereRat_explanation),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F096_OHIP_PAY_CODE_Match]", parameters);
            var collection = new ObservableCollection<F096_OHIP_PAY_CODE>();

            while (Reader.Read())
            {
                collection.Add(new F096_OHIP_PAY_CODE
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					RAT_CODE = Reader["RAT_CODE"].ToString(),
					RAT_EXPLANATION = Reader["RAT_EXPLANATION"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereRat_code = WhereRat_code,
					_whereRat_explanation = WhereRat_explanation,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalRat_code = Reader["RAT_CODE"].ToString(),
					_originalRat_explanation = Reader["RAT_EXPLANATION"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereRat_code = WhereRat_code;
					_whereRat_explanation = WhereRat_explanation;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereRat_code == null 
				&& WhereRat_explanation == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereRat_code ==  _whereRat_code
				&& WhereRat_explanation ==  _whereRat_explanation
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereRat_code = null; 
			WhereRat_explanation = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _RAT_CODE;
		private string _RAT_EXPLANATION;
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
		public string RAT_CODE
		{
			get { return _RAT_CODE; }
			set
			{
				if (_RAT_CODE != value)
				{
					_RAT_CODE = value;
					ChangeState();
				}
			}
		}
		public string RAT_EXPLANATION
		{
			get { return _RAT_EXPLANATION; }
			set
			{
				if (_RAT_EXPLANATION != value)
				{
					_RAT_EXPLANATION = value;
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
		public string WhereRat_code { get; set; }
		private string _whereRat_code;
		public string WhereRat_explanation { get; set; }
		private string _whereRat_explanation;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalRat_code;
		private string _originalRat_explanation;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			RAT_CODE = _originalRat_code;
			RAT_EXPLANATION = _originalRat_explanation;
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
					new SqlParameter("RAT_CODE",RAT_CODE)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F096_OHIP_PAY_CODE_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F096_OHIP_PAY_CODE_Purge]");
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
						new SqlParameter("RAT_CODE", SqlNull(RAT_CODE)),
						new SqlParameter("RAT_EXPLANATION", SqlNull(RAT_EXPLANATION)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F096_OHIP_PAY_CODE_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						RAT_CODE = Reader["RAT_CODE"].ToString();
						RAT_EXPLANATION = Reader["RAT_EXPLANATION"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalRat_code = Reader["RAT_CODE"].ToString();
						_originalRat_explanation = Reader["RAT_EXPLANATION"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("RAT_CODE", SqlNull(RAT_CODE)),
						new SqlParameter("RAT_EXPLANATION", SqlNull(RAT_EXPLANATION)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F096_OHIP_PAY_CODE_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						RAT_CODE = Reader["RAT_CODE"].ToString();
						RAT_EXPLANATION = Reader["RAT_EXPLANATION"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalRat_code = Reader["RAT_CODE"].ToString();
						_originalRat_explanation = Reader["RAT_EXPLANATION"].ToString();
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