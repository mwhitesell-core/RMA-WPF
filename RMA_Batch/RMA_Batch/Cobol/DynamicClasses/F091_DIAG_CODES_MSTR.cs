using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F091_DIAG_CODES_MSTR : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F091_DIAG_CODES_MSTR> Collection( Guid? rowid,
															string diag_cd,
															string diag_cd_desc,
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
					new SqlParameter("DIAG_CD",diag_cd),
					new SqlParameter("DIAG_CD_DESC",diag_cd_desc),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F091_DIAG_CODES_MSTR_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F091_DIAG_CODES_MSTR>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F091_DIAG_CODES_MSTR_Search]", parameters);
            var collection = new ObservableCollection<F091_DIAG_CODES_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F091_DIAG_CODES_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DIAG_CD = Reader["DIAG_CD"].ToString(),
					DIAG_CD_DESC = Reader["DIAG_CD_DESC"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDiag_cd = Reader["DIAG_CD"].ToString(),
					_originalDiag_cd_desc = Reader["DIAG_CD_DESC"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F091_DIAG_CODES_MSTR Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F091_DIAG_CODES_MSTR> Collection(ObservableCollection<F091_DIAG_CODES_MSTR>
                                                               f091DiagCodesMstr = null)
        {
            if (IsSameSearch() && f091DiagCodesMstr != null)
            {
                return f091DiagCodesMstr;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F091_DIAG_CODES_MSTR>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("DIAG_CD",WhereDiag_cd),
					new SqlParameter("DIAG_CD_DESC",WhereDiag_cd_desc),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F091_DIAG_CODES_MSTR_Match]", parameters);
            var collection = new ObservableCollection<F091_DIAG_CODES_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F091_DIAG_CODES_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DIAG_CD = Reader["DIAG_CD"].ToString(),
					DIAG_CD_DESC = Reader["DIAG_CD_DESC"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereDiag_cd = WhereDiag_cd,
					_whereDiag_cd_desc = WhereDiag_cd_desc,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDiag_cd = Reader["DIAG_CD"].ToString(),
					_originalDiag_cd_desc = Reader["DIAG_CD_DESC"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereDiag_cd = WhereDiag_cd;
					_whereDiag_cd_desc = WhereDiag_cd_desc;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereDiag_cd == null 
				&& WhereDiag_cd_desc == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereDiag_cd ==  _whereDiag_cd
				&& WhereDiag_cd_desc ==  _whereDiag_cd_desc
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereDiag_cd = null; 
			WhereDiag_cd_desc = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _DIAG_CD;
		private string _DIAG_CD_DESC;
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
		public string DIAG_CD
		{
			get { return _DIAG_CD; }
			set
			{
				if (_DIAG_CD != value)
				{
					_DIAG_CD = value;
					ChangeState();
				}
			}
		}
		public string DIAG_CD_DESC
		{
			get { return _DIAG_CD_DESC; }
			set
			{
				if (_DIAG_CD_DESC != value)
				{
					_DIAG_CD_DESC = value;
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
		public string WhereDiag_cd { get; set; }
		private string _whereDiag_cd;
		public string WhereDiag_cd_desc { get; set; }
		private string _whereDiag_cd_desc;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalDiag_cd;
		private string _originalDiag_cd_desc;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			DIAG_CD = _originalDiag_cd;
			DIAG_CD_DESC = _originalDiag_cd_desc;
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
					new SqlParameter("DIAG_CD",DIAG_CD)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F091_DIAG_CODES_MSTR_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F091_DIAG_CODES_MSTR_Purge]");
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
						new SqlParameter("DIAG_CD", SqlNull(DIAG_CD)),
						new SqlParameter("DIAG_CD_DESC", SqlNull(DIAG_CD_DESC)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F091_DIAG_CODES_MSTR_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DIAG_CD = Reader["DIAG_CD"].ToString();
						DIAG_CD_DESC = Reader["DIAG_CD_DESC"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDiag_cd = Reader["DIAG_CD"].ToString();
						_originalDiag_cd_desc = Reader["DIAG_CD_DESC"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("DIAG_CD", SqlNull(DIAG_CD)),
						new SqlParameter("DIAG_CD_DESC", SqlNull(DIAG_CD_DESC)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F091_DIAG_CODES_MSTR_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DIAG_CD = Reader["DIAG_CD"].ToString();
						DIAG_CD_DESC = Reader["DIAG_CD_DESC"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDiag_cd = Reader["DIAG_CD"].ToString();
						_originalDiag_cd_desc = Reader["DIAG_CD_DESC"].ToString();
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