using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F097_SPEC_CD_MSTR : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F097_SPEC_CD_MSTR> Collection( Guid? rowid,
															decimal? spec_cdmin,
															decimal? spec_cdmax,
															string spec_name,
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
					new SqlParameter("minSPEC_CD",spec_cdmin),
					new SqlParameter("maxSPEC_CD",spec_cdmax),
					new SqlParameter("SPEC_NAME",spec_name),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F097_SPEC_CD_MSTR_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F097_SPEC_CD_MSTR>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F097_SPEC_CD_MSTR_Search]", parameters);
            var collection = new ObservableCollection<F097_SPEC_CD_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F097_SPEC_CD_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					SPEC_CD = ConvertDEC(Reader["SPEC_CD"]),
					SPEC_NAME = Reader["SPEC_NAME"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalSpec_cd = ConvertDEC(Reader["SPEC_CD"]),
					_originalSpec_name = Reader["SPEC_NAME"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F097_SPEC_CD_MSTR Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F097_SPEC_CD_MSTR> Collection(ObservableCollection<F097_SPEC_CD_MSTR>
                                                               f097SpecCdMstr = null)
        {
            if (IsSameSearch() && f097SpecCdMstr != null)
            {
                return f097SpecCdMstr;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F097_SPEC_CD_MSTR>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("SPEC_CD",WhereSpec_cd),
					new SqlParameter("SPEC_NAME",WhereSpec_name),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F097_SPEC_CD_MSTR_Match]", parameters);
            var collection = new ObservableCollection<F097_SPEC_CD_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F097_SPEC_CD_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					SPEC_CD = ConvertDEC(Reader["SPEC_CD"]),
					SPEC_NAME = Reader["SPEC_NAME"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereSpec_cd = WhereSpec_cd,
					_whereSpec_name = WhereSpec_name,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalSpec_cd = ConvertDEC(Reader["SPEC_CD"]),
					_originalSpec_name = Reader["SPEC_NAME"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereSpec_cd = WhereSpec_cd;
					_whereSpec_name = WhereSpec_name;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereSpec_cd == null 
				&& WhereSpec_name == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereSpec_cd ==  _whereSpec_cd
				&& WhereSpec_name ==  _whereSpec_name
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereSpec_cd = null; 
			WhereSpec_name = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private decimal? _SPEC_CD;
		private string _SPEC_NAME;
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
		public decimal? SPEC_CD
		{
			get { return _SPEC_CD; }
			set
			{
				if (_SPEC_CD != value)
				{
					_SPEC_CD = value;
					ChangeState();
				}
			}
		}
		public string SPEC_NAME
		{
			get { return _SPEC_NAME; }
			set
			{
				if (_SPEC_NAME != value)
				{
					_SPEC_NAME = value;
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
		public decimal? WhereSpec_cd { get; set; }
		private decimal? _whereSpec_cd;
		public string WhereSpec_name { get; set; }
		private string _whereSpec_name;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private decimal? _originalSpec_cd;
		private string _originalSpec_name;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			SPEC_CD = _originalSpec_cd;
			SPEC_NAME = _originalSpec_name;
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
					new SqlParameter("SPEC_CD",SPEC_CD)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F097_SPEC_CD_MSTR_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F097_SPEC_CD_MSTR_Purge]");
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
						new SqlParameter("SPEC_CD", SqlNull(SPEC_CD)),
						new SqlParameter("SPEC_NAME", SqlNull(SPEC_NAME)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F097_SPEC_CD_MSTR_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						SPEC_CD = ConvertDEC(Reader["SPEC_CD"]);
						SPEC_NAME = Reader["SPEC_NAME"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalSpec_cd = ConvertDEC(Reader["SPEC_CD"]);
						_originalSpec_name = Reader["SPEC_NAME"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("SPEC_CD", SqlNull(SPEC_CD)),
						new SqlParameter("SPEC_NAME", SqlNull(SPEC_NAME)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F097_SPEC_CD_MSTR_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						SPEC_CD = ConvertDEC(Reader["SPEC_CD"]);
						SPEC_NAME = Reader["SPEC_NAME"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalSpec_cd = ConvertDEC(Reader["SPEC_CD"]);
						_originalSpec_name = Reader["SPEC_NAME"].ToString();
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