using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class FEMPSKISOLD : BaseTable
    {
        #region Retrieve

        public ObservableCollection<FEMPSKISOLD> Collection( Guid? rowid,
															decimal? emp_nummin,
															decimal? emp_nummax,
															string skill_code,
															long? core_levelmin,
															long? core_levelmax,
															long? level_expectedmin,
															long? level_expectedmax,
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
					new SqlParameter("minEMP_NUM",emp_nummin),
					new SqlParameter("maxEMP_NUM",emp_nummax),
					new SqlParameter("SKILL_CODE",skill_code),
					new SqlParameter("minCORE_LEVEL",core_levelmin),
					new SqlParameter("maxCORE_LEVEL",core_levelmax),
					new SqlParameter("minLEVEL_EXPECTED",level_expectedmin),
					new SqlParameter("maxLEVEL_EXPECTED",level_expectedmax),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_FEMPSKISOLD_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<FEMPSKISOLD>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_FEMPSKISOLD_Search]", parameters);
            var collection = new ObservableCollection<FEMPSKISOLD>();

            while (Reader.Read())
            {
                collection.Add(new FEMPSKISOLD
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					EMP_NUM = ConvertDEC(Reader["EMP_NUM"]),
					SKILL_CODE = Reader["SKILL_CODE"].ToString(),
					CORE_LEVEL = Reader["CORE_LEVEL"].ToString(),
					LEVEL_EXPECTED = Reader["LEVEL_EXPECTED"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalEmp_num = ConvertDEC(Reader["EMP_NUM"]),
					_originalSkill_code = Reader["SKILL_CODE"].ToString(),
					_originalCore_level = Reader["CORE_LEVEL"].ToString(),
					_originalLevel_expected = Reader["LEVEL_EXPECTED"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public FEMPSKISOLD Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<FEMPSKISOLD> Collection(ObservableCollection<FEMPSKISOLD>
                                                               fempskisold = null)
        {
            if (IsSameSearch() && fempskisold != null)
            {
                return fempskisold;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<FEMPSKISOLD>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("EMP_NUM",WhereEmp_num),
					new SqlParameter("SKILL_CODE",WhereSkill_code),
					new SqlParameter("CORE_LEVEL",WhereCore_level),
					new SqlParameter("LEVEL_EXPECTED",WhereLevel_expected),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_FEMPSKISOLD_Match]", parameters);
            var collection = new ObservableCollection<FEMPSKISOLD>();

            while (Reader.Read())
            {
                collection.Add(new FEMPSKISOLD
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					EMP_NUM = ConvertDEC(Reader["EMP_NUM"]),
					SKILL_CODE = Reader["SKILL_CODE"].ToString(),
					CORE_LEVEL = Reader["CORE_LEVEL"].ToString(),
					LEVEL_EXPECTED = Reader["LEVEL_EXPECTED"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereEmp_num = WhereEmp_num,
					_whereSkill_code = WhereSkill_code,
					_whereCore_level = WhereCore_level,
					_whereLevel_expected = WhereLevel_expected,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalEmp_num = ConvertDEC(Reader["EMP_NUM"]),
					_originalSkill_code = Reader["SKILL_CODE"].ToString(),
					_originalCore_level = Reader["CORE_LEVEL"].ToString(),
					_originalLevel_expected = Reader["LEVEL_EXPECTED"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereEmp_num = WhereEmp_num;
					_whereSkill_code = WhereSkill_code;
					_whereCore_level = WhereCore_level;
					_whereLevel_expected = WhereLevel_expected;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereEmp_num == null 
				&& WhereSkill_code == null 
				&& WhereCore_level == null 
				&& WhereLevel_expected == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereEmp_num ==  _whereEmp_num
				&& WhereSkill_code ==  _whereSkill_code
				&& WhereCore_level ==  _whereCore_level
				&& WhereLevel_expected ==  _whereLevel_expected
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereEmp_num = null; 
			WhereSkill_code = null; 
			WhereCore_level = null; 
			WhereLevel_expected = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private decimal? _EMP_NUM;
		private string _SKILL_CODE;
		private string _CORE_LEVEL;
		private string _LEVEL_EXPECTED;
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
		public decimal? EMP_NUM
		{
			get { return _EMP_NUM; }
			set
			{
				if (_EMP_NUM != value)
				{
					_EMP_NUM = value;
					ChangeState();
				}
			}
		}
		public string SKILL_CODE
		{
			get { return _SKILL_CODE; }
			set
			{
				if (_SKILL_CODE != value)
				{
					_SKILL_CODE = value;
					ChangeState();
				}
			}
		}
		public string CORE_LEVEL
		{
			get { return _CORE_LEVEL; }
			set
			{
				if (_CORE_LEVEL != value)
				{
					_CORE_LEVEL = value;
					ChangeState();
				}
			}
		}
		public string LEVEL_EXPECTED
		{
			get { return _LEVEL_EXPECTED; }
			set
			{
				if (_LEVEL_EXPECTED != value)
				{
					_LEVEL_EXPECTED = value;
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
		public decimal? WhereEmp_num { get; set; }
		private decimal? _whereEmp_num;
		public string WhereSkill_code { get; set; }
		private string _whereSkill_code;
		public string WhereCore_level { get; set; }
		private string _whereCore_level;
		public string WhereLevel_expected { get; set; }
		private string _whereLevel_expected;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private decimal? _originalEmp_num;
		private string _originalSkill_code;
		private string _originalCore_level;
		private string _originalLevel_expected;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			EMP_NUM = _originalEmp_num;
			SKILL_CODE = _originalSkill_code;
			CORE_LEVEL = _originalCore_level;
			LEVEL_EXPECTED = _originalLevel_expected;
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
					new SqlParameter("EMP_NUM",EMP_NUM),
					new SqlParameter("SKILL_CODE",SKILL_CODE)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_FEMPSKISOLD_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_FEMPSKISOLD_Purge]");
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
						new SqlParameter("EMP_NUM", SqlNull(EMP_NUM)),
						new SqlParameter("SKILL_CODE", SqlNull(SKILL_CODE)),
						new SqlParameter("CORE_LEVEL", SqlNull(CORE_LEVEL)),
						new SqlParameter("LEVEL_EXPECTED", SqlNull(LEVEL_EXPECTED)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_FEMPSKISOLD_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						EMP_NUM = ConvertDEC(Reader["EMP_NUM"]);
						SKILL_CODE = Reader["SKILL_CODE"].ToString();
						CORE_LEVEL = Reader["CORE_LEVEL"].ToString();
						LEVEL_EXPECTED = Reader["LEVEL_EXPECTED"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalEmp_num = ConvertDEC(Reader["EMP_NUM"]);
						_originalSkill_code = Reader["SKILL_CODE"].ToString();
						_originalCore_level = Reader["CORE_LEVEL"].ToString();
						_originalLevel_expected = Reader["LEVEL_EXPECTED"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("EMP_NUM", SqlNull(EMP_NUM)),
						new SqlParameter("SKILL_CODE", SqlNull(SKILL_CODE)),
						new SqlParameter("CORE_LEVEL", SqlNull(CORE_LEVEL)),
						new SqlParameter("LEVEL_EXPECTED", SqlNull(LEVEL_EXPECTED)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_FEMPSKISOLD_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						EMP_NUM = ConvertDEC(Reader["EMP_NUM"]);
						SKILL_CODE = Reader["SKILL_CODE"].ToString();
						CORE_LEVEL = Reader["CORE_LEVEL"].ToString();
						LEVEL_EXPECTED = Reader["LEVEL_EXPECTED"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalEmp_num = ConvertDEC(Reader["EMP_NUM"]);
						_originalSkill_code = Reader["SKILL_CODE"].ToString();
						_originalCore_level = Reader["CORE_LEVEL"].ToString();
						_originalLevel_expected = Reader["LEVEL_EXPECTED"].ToString();
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