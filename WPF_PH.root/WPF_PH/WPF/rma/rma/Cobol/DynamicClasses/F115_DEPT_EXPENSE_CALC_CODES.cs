using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F115_DEPT_EXPENSE_CALC_CODES : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F115_DEPT_EXPENSE_CALC_CODES> Collection( Guid? rowid,
															string dept_expense_calc_code,
															string dept_expense_calc_code_desc,
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
					new SqlParameter("DEPT_EXPENSE_CALC_CODE",dept_expense_calc_code),
					new SqlParameter("DEPT_EXPENSE_CALC_CODE_DESC",dept_expense_calc_code_desc),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F115_DEPT_EXPENSE_CALC_CODES_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F115_DEPT_EXPENSE_CALC_CODES>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F115_DEPT_EXPENSE_CALC_CODES_Search]", parameters);
            var collection = new ObservableCollection<F115_DEPT_EXPENSE_CALC_CODES>();

            while (Reader.Read())
            {
                collection.Add(new F115_DEPT_EXPENSE_CALC_CODES
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DEPT_EXPENSE_CALC_CODE = Reader["DEPT_EXPENSE_CALC_CODE"].ToString(),
					DEPT_EXPENSE_CALC_CODE_DESC = Reader["DEPT_EXPENSE_CALC_CODE_DESC"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDept_expense_calc_code = Reader["DEPT_EXPENSE_CALC_CODE"].ToString(),
					_originalDept_expense_calc_code_desc = Reader["DEPT_EXPENSE_CALC_CODE_DESC"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F115_DEPT_EXPENSE_CALC_CODES Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F115_DEPT_EXPENSE_CALC_CODES> Collection(ObservableCollection<F115_DEPT_EXPENSE_CALC_CODES>
                                                               f115DeptExpenseCalcCodes = null)
        {
            if (IsSameSearch() && f115DeptExpenseCalcCodes != null)
            {
                return f115DeptExpenseCalcCodes;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F115_DEPT_EXPENSE_CALC_CODES>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("DEPT_EXPENSE_CALC_CODE",WhereDept_expense_calc_code),
					new SqlParameter("DEPT_EXPENSE_CALC_CODE_DESC",WhereDept_expense_calc_code_desc),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F115_DEPT_EXPENSE_CALC_CODES_Match]", parameters);
            var collection = new ObservableCollection<F115_DEPT_EXPENSE_CALC_CODES>();

            while (Reader.Read())
            {
                collection.Add(new F115_DEPT_EXPENSE_CALC_CODES
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DEPT_EXPENSE_CALC_CODE = Reader["DEPT_EXPENSE_CALC_CODE"].ToString(),
					DEPT_EXPENSE_CALC_CODE_DESC = Reader["DEPT_EXPENSE_CALC_CODE_DESC"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereDept_expense_calc_code = WhereDept_expense_calc_code,
					_whereDept_expense_calc_code_desc = WhereDept_expense_calc_code_desc,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDept_expense_calc_code = Reader["DEPT_EXPENSE_CALC_CODE"].ToString(),
					_originalDept_expense_calc_code_desc = Reader["DEPT_EXPENSE_CALC_CODE_DESC"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereDept_expense_calc_code = WhereDept_expense_calc_code;
					_whereDept_expense_calc_code_desc = WhereDept_expense_calc_code_desc;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereDept_expense_calc_code == null 
				&& WhereDept_expense_calc_code_desc == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereDept_expense_calc_code ==  _whereDept_expense_calc_code
				&& WhereDept_expense_calc_code_desc ==  _whereDept_expense_calc_code_desc
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereDept_expense_calc_code = null; 
			WhereDept_expense_calc_code_desc = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _DEPT_EXPENSE_CALC_CODE;
		private string _DEPT_EXPENSE_CALC_CODE_DESC;
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
		public string DEPT_EXPENSE_CALC_CODE
		{
			get { return _DEPT_EXPENSE_CALC_CODE; }
			set
			{
				if (_DEPT_EXPENSE_CALC_CODE != value)
				{
					_DEPT_EXPENSE_CALC_CODE = value;
					ChangeState();
				}
			}
		}
		public string DEPT_EXPENSE_CALC_CODE_DESC
		{
			get { return _DEPT_EXPENSE_CALC_CODE_DESC; }
			set
			{
				if (_DEPT_EXPENSE_CALC_CODE_DESC != value)
				{
					_DEPT_EXPENSE_CALC_CODE_DESC = value;
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
		public string WhereDept_expense_calc_code { get; set; }
		private string _whereDept_expense_calc_code;
		public string WhereDept_expense_calc_code_desc { get; set; }
		private string _whereDept_expense_calc_code_desc;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalDept_expense_calc_code;
		private string _originalDept_expense_calc_code_desc;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			DEPT_EXPENSE_CALC_CODE = _originalDept_expense_calc_code;
			DEPT_EXPENSE_CALC_CODE_DESC = _originalDept_expense_calc_code_desc;
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
					new SqlParameter("DEPT_EXPENSE_CALC_CODE",DEPT_EXPENSE_CALC_CODE)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F115_DEPT_EXPENSE_CALC_CODES_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F115_DEPT_EXPENSE_CALC_CODES_Purge]");
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
						new SqlParameter("DEPT_EXPENSE_CALC_CODE", SqlNull(DEPT_EXPENSE_CALC_CODE)),
						new SqlParameter("DEPT_EXPENSE_CALC_CODE_DESC", SqlNull(DEPT_EXPENSE_CALC_CODE_DESC)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F115_DEPT_EXPENSE_CALC_CODES_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DEPT_EXPENSE_CALC_CODE = Reader["DEPT_EXPENSE_CALC_CODE"].ToString();
						DEPT_EXPENSE_CALC_CODE_DESC = Reader["DEPT_EXPENSE_CALC_CODE_DESC"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDept_expense_calc_code = Reader["DEPT_EXPENSE_CALC_CODE"].ToString();
						_originalDept_expense_calc_code_desc = Reader["DEPT_EXPENSE_CALC_CODE_DESC"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("DEPT_EXPENSE_CALC_CODE", SqlNull(DEPT_EXPENSE_CALC_CODE)),
						new SqlParameter("DEPT_EXPENSE_CALC_CODE_DESC", SqlNull(DEPT_EXPENSE_CALC_CODE_DESC)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F115_DEPT_EXPENSE_CALC_CODES_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DEPT_EXPENSE_CALC_CODE = Reader["DEPT_EXPENSE_CALC_CODE"].ToString();
						DEPT_EXPENSE_CALC_CODE_DESC = Reader["DEPT_EXPENSE_CALC_CODE_DESC"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDept_expense_calc_code = Reader["DEPT_EXPENSE_CALC_CODE"].ToString();
						_originalDept_expense_calc_code_desc = Reader["DEPT_EXPENSE_CALC_CODE_DESC"].ToString();
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