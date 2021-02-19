using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class FSKILLSOLD : BaseTable
    {
        #region Retrieve

        public ObservableCollection<FSKILLSOLD> Collection( Guid? rowid,
															string skill_code,
															string cla_ss,
															string sk_desc,
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
					new SqlParameter("SKILL_CODE",skill_code),
					new SqlParameter("CLASS",cla_ss),
					new SqlParameter("SK_DESC",sk_desc),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_FSKILLSOLD_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<FSKILLSOLD>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_FSKILLSOLD_Search]", parameters);
            var collection = new ObservableCollection<FSKILLSOLD>();

            while (Reader.Read())
            {
                collection.Add(new FSKILLSOLD
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					SKILL_CODE = Reader["SKILL_CODE"].ToString(),
					CLASS = Reader["CLASS"].ToString(),
					SK_DESC = Reader["SK_DESC"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalSkill_code = Reader["SKILL_CODE"].ToString(),
					_originalClass = Reader["CLASS"].ToString(),
					_originalSk_desc = Reader["SK_DESC"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public FSKILLSOLD Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<FSKILLSOLD> Collection(ObservableCollection<FSKILLSOLD>
                                                               fskillsold = null)
        {
            if (IsSameSearch() && fskillsold != null)
            {
                return fskillsold;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<FSKILLSOLD>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("SKILL_CODE",WhereSkill_code),
					new SqlParameter("CLASS",WhereClass),
					new SqlParameter("SK_DESC",WhereSk_desc),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_FSKILLSOLD_Match]", parameters);
            var collection = new ObservableCollection<FSKILLSOLD>();

            while (Reader.Read())
            {
                collection.Add(new FSKILLSOLD
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					SKILL_CODE = Reader["SKILL_CODE"].ToString(),
					CLASS = Reader["CLASS"].ToString(),
					SK_DESC = Reader["SK_DESC"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereSkill_code = WhereSkill_code,
					_whereClass = WhereClass,
					_whereSk_desc = WhereSk_desc,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalSkill_code = Reader["SKILL_CODE"].ToString(),
					_originalClass = Reader["CLASS"].ToString(),
					_originalSk_desc = Reader["SK_DESC"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereSkill_code = WhereSkill_code;
					_whereClass = WhereClass;
					_whereSk_desc = WhereSk_desc;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereSkill_code == null 
				&& WhereClass == null 
				&& WhereSk_desc == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereSkill_code ==  _whereSkill_code
				&& WhereClass ==  _whereClass
				&& WhereSk_desc ==  _whereSk_desc
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereSkill_code = null; 
			WhereClass = null; 
			WhereSk_desc = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _SKILL_CODE;
		private string _CLASS;
		private string _SK_DESC;
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
		public string CLASS
		{
			get { return _CLASS; }
			set
			{
				if (_CLASS != value)
				{
					_CLASS = value;
					ChangeState();
				}
			}
		}
		public string SK_DESC
		{
			get { return _SK_DESC; }
			set
			{
				if (_SK_DESC != value)
				{
					_SK_DESC = value;
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
		public string WhereSkill_code { get; set; }
		private string _whereSkill_code;
		public string WhereClass { get; set; }
		private string _whereClass;
		public string WhereSk_desc { get; set; }
		private string _whereSk_desc;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalSkill_code;
		private string _originalClass;
		private string _originalSk_desc;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			SKILL_CODE = _originalSkill_code;
			CLASS = _originalClass;
			SK_DESC = _originalSk_desc;
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
					new SqlParameter("SKILL_CODE",SKILL_CODE)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_FSKILLSOLD_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_FSKILLSOLD_Purge]");
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
						new SqlParameter("SKILL_CODE", SqlNull(SKILL_CODE)),
						new SqlParameter("CLASS", SqlNull(CLASS)),
						new SqlParameter("SK_DESC", SqlNull(SK_DESC)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_FSKILLSOLD_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						SKILL_CODE = Reader["SKILL_CODE"].ToString();
						CLASS = Reader["CLASS"].ToString();
						SK_DESC = Reader["SK_DESC"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalSkill_code = Reader["SKILL_CODE"].ToString();
						_originalClass = Reader["CLASS"].ToString();
						_originalSk_desc = Reader["SK_DESC"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("SKILL_CODE", SqlNull(SKILL_CODE)),
						new SqlParameter("CLASS", SqlNull(CLASS)),
						new SqlParameter("SK_DESC", SqlNull(SK_DESC)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_FSKILLSOLD_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						SKILL_CODE = Reader["SKILL_CODE"].ToString();
						CLASS = Reader["CLASS"].ToString();
						SK_DESC = Reader["SK_DESC"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalSkill_code = Reader["SKILL_CODE"].ToString();
						_originalClass = Reader["CLASS"].ToString();
						_originalSk_desc = Reader["SK_DESC"].ToString();
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