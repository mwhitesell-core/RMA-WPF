using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F116_DEPT_EXPENSE_RULES_DTL : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F116_DEPT_EXPENSE_RULES_DTL> Collection( Guid? rowid,
															string dept_expense_calc_code,
															decimal? dept_nbrmin,
															decimal? dept_nbrmax,
															string doc_afp_paym_group,
															string doc_nbr,
															string comp_code,
															string desc_long,
															string desc_short,
															string tithe_in_ex_clude_flag,
															string flag_display_hide,
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
					new SqlParameter("minDEPT_NBR",dept_nbrmin),
					new SqlParameter("maxDEPT_NBR",dept_nbrmax),
					new SqlParameter("DOC_AFP_PAYM_GROUP",doc_afp_paym_group),
					new SqlParameter("DOC_NBR",doc_nbr),
					new SqlParameter("COMP_CODE",comp_code),
					new SqlParameter("DESC_LONG",desc_long),
					new SqlParameter("DESC_SHORT",desc_short),
					new SqlParameter("TITHE_IN_EX_CLUDE_FLAG",tithe_in_ex_clude_flag),
					new SqlParameter("FLAG_DISPLAY_HIDE",flag_display_hide),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F116_DEPT_EXPENSE_RULES_DTL_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F116_DEPT_EXPENSE_RULES_DTL>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F116_DEPT_EXPENSE_RULES_DTL_Search]", parameters);
            var collection = new ObservableCollection<F116_DEPT_EXPENSE_RULES_DTL>();

            while (Reader.Read())
            {
                collection.Add(new F116_DEPT_EXPENSE_RULES_DTL
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DEPT_EXPENSE_CALC_CODE = Reader["DEPT_EXPENSE_CALC_CODE"].ToString(),
					DEPT_NBR = ConvertDEC(Reader["DEPT_NBR"]),
					DOC_AFP_PAYM_GROUP = Reader["DOC_AFP_PAYM_GROUP"].ToString(),
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					COMP_CODE = Reader["COMP_CODE"].ToString(),
					DESC_LONG = Reader["DESC_LONG"].ToString(),
					DESC_SHORT = Reader["DESC_SHORT"].ToString(),
					TITHE_IN_EX_CLUDE_FLAG = Reader["TITHE_IN_EX_CLUDE_FLAG"].ToString(),
					FLAG_DISPLAY_HIDE = Reader["FLAG_DISPLAY_HIDE"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDept_expense_calc_code = Reader["DEPT_EXPENSE_CALC_CODE"].ToString(),
					_originalDept_nbr = ConvertDEC(Reader["DEPT_NBR"]),
					_originalDoc_afp_paym_group = Reader["DOC_AFP_PAYM_GROUP"].ToString(),
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalComp_code = Reader["COMP_CODE"].ToString(),
					_originalDesc_long = Reader["DESC_LONG"].ToString(),
					_originalDesc_short = Reader["DESC_SHORT"].ToString(),
					_originalTithe_in_ex_clude_flag = Reader["TITHE_IN_EX_CLUDE_FLAG"].ToString(),
					_originalFlag_display_hide = Reader["FLAG_DISPLAY_HIDE"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F116_DEPT_EXPENSE_RULES_DTL Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F116_DEPT_EXPENSE_RULES_DTL> Collection(ObservableCollection<F116_DEPT_EXPENSE_RULES_DTL>
                                                               f116DeptExpenseRulesDtl = null)
        {
            if (IsSameSearch() && f116DeptExpenseRulesDtl != null)
            {
                return f116DeptExpenseRulesDtl;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F116_DEPT_EXPENSE_RULES_DTL>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("DEPT_EXPENSE_CALC_CODE",WhereDept_expense_calc_code),
					new SqlParameter("DEPT_NBR",WhereDept_nbr),
					new SqlParameter("DOC_AFP_PAYM_GROUP",WhereDoc_afp_paym_group),
					new SqlParameter("DOC_NBR",WhereDoc_nbr),
					new SqlParameter("COMP_CODE",WhereComp_code),
					new SqlParameter("DESC_LONG",WhereDesc_long),
					new SqlParameter("DESC_SHORT",WhereDesc_short),
					new SqlParameter("TITHE_IN_EX_CLUDE_FLAG",WhereTithe_in_ex_clude_flag),
					new SqlParameter("FLAG_DISPLAY_HIDE",WhereFlag_display_hide),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F116_DEPT_EXPENSE_RULES_DTL_Match]", parameters);
            var collection = new ObservableCollection<F116_DEPT_EXPENSE_RULES_DTL>();

            while (Reader.Read())
            {
                collection.Add(new F116_DEPT_EXPENSE_RULES_DTL
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DEPT_EXPENSE_CALC_CODE = Reader["DEPT_EXPENSE_CALC_CODE"].ToString(),
					DEPT_NBR = ConvertDEC(Reader["DEPT_NBR"]),
					DOC_AFP_PAYM_GROUP = Reader["DOC_AFP_PAYM_GROUP"].ToString(),
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					COMP_CODE = Reader["COMP_CODE"].ToString(),
					DESC_LONG = Reader["DESC_LONG"].ToString(),
					DESC_SHORT = Reader["DESC_SHORT"].ToString(),
					TITHE_IN_EX_CLUDE_FLAG = Reader["TITHE_IN_EX_CLUDE_FLAG"].ToString(),
					FLAG_DISPLAY_HIDE = Reader["FLAG_DISPLAY_HIDE"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereDept_expense_calc_code = WhereDept_expense_calc_code,
					_whereDept_nbr = WhereDept_nbr,
					_whereDoc_afp_paym_group = WhereDoc_afp_paym_group,
					_whereDoc_nbr = WhereDoc_nbr,
					_whereComp_code = WhereComp_code,
					_whereDesc_long = WhereDesc_long,
					_whereDesc_short = WhereDesc_short,
					_whereTithe_in_ex_clude_flag = WhereTithe_in_ex_clude_flag,
					_whereFlag_display_hide = WhereFlag_display_hide,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDept_expense_calc_code = Reader["DEPT_EXPENSE_CALC_CODE"].ToString(),
					_originalDept_nbr = ConvertDEC(Reader["DEPT_NBR"]),
					_originalDoc_afp_paym_group = Reader["DOC_AFP_PAYM_GROUP"].ToString(),
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalComp_code = Reader["COMP_CODE"].ToString(),
					_originalDesc_long = Reader["DESC_LONG"].ToString(),
					_originalDesc_short = Reader["DESC_SHORT"].ToString(),
					_originalTithe_in_ex_clude_flag = Reader["TITHE_IN_EX_CLUDE_FLAG"].ToString(),
					_originalFlag_display_hide = Reader["FLAG_DISPLAY_HIDE"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereDept_expense_calc_code = WhereDept_expense_calc_code;
					_whereDept_nbr = WhereDept_nbr;
					_whereDoc_afp_paym_group = WhereDoc_afp_paym_group;
					_whereDoc_nbr = WhereDoc_nbr;
					_whereComp_code = WhereComp_code;
					_whereDesc_long = WhereDesc_long;
					_whereDesc_short = WhereDesc_short;
					_whereTithe_in_ex_clude_flag = WhereTithe_in_ex_clude_flag;
					_whereFlag_display_hide = WhereFlag_display_hide;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereDept_expense_calc_code == null 
				&& WhereDept_nbr == null 
				&& WhereDoc_afp_paym_group == null 
				&& WhereDoc_nbr == null 
				&& WhereComp_code == null 
				&& WhereDesc_long == null 
				&& WhereDesc_short == null 
				&& WhereTithe_in_ex_clude_flag == null 
				&& WhereFlag_display_hide == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereDept_expense_calc_code ==  _whereDept_expense_calc_code
				&& WhereDept_nbr ==  _whereDept_nbr
				&& WhereDoc_afp_paym_group ==  _whereDoc_afp_paym_group
				&& WhereDoc_nbr ==  _whereDoc_nbr
				&& WhereComp_code ==  _whereComp_code
				&& WhereDesc_long ==  _whereDesc_long
				&& WhereDesc_short ==  _whereDesc_short
				&& WhereTithe_in_ex_clude_flag ==  _whereTithe_in_ex_clude_flag
				&& WhereFlag_display_hide ==  _whereFlag_display_hide
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereDept_expense_calc_code = null; 
			WhereDept_nbr = null; 
			WhereDoc_afp_paym_group = null; 
			WhereDoc_nbr = null; 
			WhereComp_code = null; 
			WhereDesc_long = null; 
			WhereDesc_short = null; 
			WhereTithe_in_ex_clude_flag = null; 
			WhereFlag_display_hide = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _DEPT_EXPENSE_CALC_CODE;
		private decimal? _DEPT_NBR;
		private string _DOC_AFP_PAYM_GROUP;
		private string _DOC_NBR;
		private string _COMP_CODE;
		private string _DESC_LONG;
		private string _DESC_SHORT;
		private string _TITHE_IN_EX_CLUDE_FLAG;
		private string _FLAG_DISPLAY_HIDE;
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
		public string DOC_AFP_PAYM_GROUP
		{
			get { return _DOC_AFP_PAYM_GROUP; }
			set
			{
				if (_DOC_AFP_PAYM_GROUP != value)
				{
					_DOC_AFP_PAYM_GROUP = value;
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
		public string COMP_CODE
		{
			get { return _COMP_CODE; }
			set
			{
				if (_COMP_CODE != value)
				{
					_COMP_CODE = value;
					ChangeState();
				}
			}
		}
		public string DESC_LONG
		{
			get { return _DESC_LONG; }
			set
			{
				if (_DESC_LONG != value)
				{
					_DESC_LONG = value;
					ChangeState();
				}
			}
		}
		public string DESC_SHORT
		{
			get { return _DESC_SHORT; }
			set
			{
				if (_DESC_SHORT != value)
				{
					_DESC_SHORT = value;
					ChangeState();
				}
			}
		}
		public string TITHE_IN_EX_CLUDE_FLAG
		{
			get { return _TITHE_IN_EX_CLUDE_FLAG; }
			set
			{
				if (_TITHE_IN_EX_CLUDE_FLAG != value)
				{
					_TITHE_IN_EX_CLUDE_FLAG = value;
					ChangeState();
				}
			}
		}
		public string FLAG_DISPLAY_HIDE
		{
			get { return _FLAG_DISPLAY_HIDE; }
			set
			{
				if (_FLAG_DISPLAY_HIDE != value)
				{
					_FLAG_DISPLAY_HIDE = value;
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
		public decimal? WhereDept_nbr { get; set; }
		private decimal? _whereDept_nbr;
		public string WhereDoc_afp_paym_group { get; set; }
		private string _whereDoc_afp_paym_group;
		public string WhereDoc_nbr { get; set; }
		private string _whereDoc_nbr;
		public string WhereComp_code { get; set; }
		private string _whereComp_code;
		public string WhereDesc_long { get; set; }
		private string _whereDesc_long;
		public string WhereDesc_short { get; set; }
		private string _whereDesc_short;
		public string WhereTithe_in_ex_clude_flag { get; set; }
		private string _whereTithe_in_ex_clude_flag;
		public string WhereFlag_display_hide { get; set; }
		private string _whereFlag_display_hide;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalDept_expense_calc_code;
		private decimal? _originalDept_nbr;
		private string _originalDoc_afp_paym_group;
		private string _originalDoc_nbr;
		private string _originalComp_code;
		private string _originalDesc_long;
		private string _originalDesc_short;
		private string _originalTithe_in_ex_clude_flag;
		private string _originalFlag_display_hide;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			DEPT_EXPENSE_CALC_CODE = _originalDept_expense_calc_code;
			DEPT_NBR = _originalDept_nbr;
			DOC_AFP_PAYM_GROUP = _originalDoc_afp_paym_group;
			DOC_NBR = _originalDoc_nbr;
			COMP_CODE = _originalComp_code;
			DESC_LONG = _originalDesc_long;
			DESC_SHORT = _originalDesc_short;
			TITHE_IN_EX_CLUDE_FLAG = _originalTithe_in_ex_clude_flag;
			FLAG_DISPLAY_HIDE = _originalFlag_display_hide;
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
					new SqlParameter("DEPT_EXPENSE_CALC_CODE",DEPT_EXPENSE_CALC_CODE),
					new SqlParameter("DEPT_NBR",DEPT_NBR),
					new SqlParameter("DOC_AFP_PAYM_GROUP",DOC_AFP_PAYM_GROUP),
					new SqlParameter("DOC_NBR",DOC_NBR),
					new SqlParameter("COMP_CODE",COMP_CODE)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F116_DEPT_EXPENSE_RULES_DTL_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F116_DEPT_EXPENSE_RULES_DTL_Purge]");
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
						new SqlParameter("DEPT_NBR", SqlNull(DEPT_NBR)),
						new SqlParameter("DOC_AFP_PAYM_GROUP", SqlNull(DOC_AFP_PAYM_GROUP)),
						new SqlParameter("DOC_NBR", SqlNull(DOC_NBR)),
						new SqlParameter("COMP_CODE", SqlNull(COMP_CODE)),
						new SqlParameter("DESC_LONG", SqlNull(DESC_LONG)),
						new SqlParameter("DESC_SHORT", SqlNull(DESC_SHORT)),
						new SqlParameter("TITHE_IN_EX_CLUDE_FLAG", SqlNull(TITHE_IN_EX_CLUDE_FLAG)),
						new SqlParameter("FLAG_DISPLAY_HIDE", SqlNull(FLAG_DISPLAY_HIDE)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F116_DEPT_EXPENSE_RULES_DTL_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DEPT_EXPENSE_CALC_CODE = Reader["DEPT_EXPENSE_CALC_CODE"].ToString();
						DEPT_NBR = ConvertDEC(Reader["DEPT_NBR"]);
						DOC_AFP_PAYM_GROUP = Reader["DOC_AFP_PAYM_GROUP"].ToString();
						DOC_NBR = Reader["DOC_NBR"].ToString();
						COMP_CODE = Reader["COMP_CODE"].ToString();
						DESC_LONG = Reader["DESC_LONG"].ToString();
						DESC_SHORT = Reader["DESC_SHORT"].ToString();
						TITHE_IN_EX_CLUDE_FLAG = Reader["TITHE_IN_EX_CLUDE_FLAG"].ToString();
						FLAG_DISPLAY_HIDE = Reader["FLAG_DISPLAY_HIDE"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDept_expense_calc_code = Reader["DEPT_EXPENSE_CALC_CODE"].ToString();
						_originalDept_nbr = ConvertDEC(Reader["DEPT_NBR"]);
						_originalDoc_afp_paym_group = Reader["DOC_AFP_PAYM_GROUP"].ToString();
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalComp_code = Reader["COMP_CODE"].ToString();
						_originalDesc_long = Reader["DESC_LONG"].ToString();
						_originalDesc_short = Reader["DESC_SHORT"].ToString();
						_originalTithe_in_ex_clude_flag = Reader["TITHE_IN_EX_CLUDE_FLAG"].ToString();
						_originalFlag_display_hide = Reader["FLAG_DISPLAY_HIDE"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("DEPT_EXPENSE_CALC_CODE", SqlNull(DEPT_EXPENSE_CALC_CODE)),
						new SqlParameter("DEPT_NBR", SqlNull(DEPT_NBR)),
						new SqlParameter("DOC_AFP_PAYM_GROUP", SqlNull(DOC_AFP_PAYM_GROUP)),
						new SqlParameter("DOC_NBR", SqlNull(DOC_NBR)),
						new SqlParameter("COMP_CODE", SqlNull(COMP_CODE)),
						new SqlParameter("DESC_LONG", SqlNull(DESC_LONG)),
						new SqlParameter("DESC_SHORT", SqlNull(DESC_SHORT)),
						new SqlParameter("TITHE_IN_EX_CLUDE_FLAG", SqlNull(TITHE_IN_EX_CLUDE_FLAG)),
						new SqlParameter("FLAG_DISPLAY_HIDE", SqlNull(FLAG_DISPLAY_HIDE)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F116_DEPT_EXPENSE_RULES_DTL_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DEPT_EXPENSE_CALC_CODE = Reader["DEPT_EXPENSE_CALC_CODE"].ToString();
						DEPT_NBR = ConvertDEC(Reader["DEPT_NBR"]);
						DOC_AFP_PAYM_GROUP = Reader["DOC_AFP_PAYM_GROUP"].ToString();
						DOC_NBR = Reader["DOC_NBR"].ToString();
						COMP_CODE = Reader["COMP_CODE"].ToString();
						DESC_LONG = Reader["DESC_LONG"].ToString();
						DESC_SHORT = Reader["DESC_SHORT"].ToString();
						TITHE_IN_EX_CLUDE_FLAG = Reader["TITHE_IN_EX_CLUDE_FLAG"].ToString();
						FLAG_DISPLAY_HIDE = Reader["FLAG_DISPLAY_HIDE"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDept_expense_calc_code = Reader["DEPT_EXPENSE_CALC_CODE"].ToString();
						_originalDept_nbr = ConvertDEC(Reader["DEPT_NBR"]);
						_originalDoc_afp_paym_group = Reader["DOC_AFP_PAYM_GROUP"].ToString();
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalComp_code = Reader["COMP_CODE"].ToString();
						_originalDesc_long = Reader["DESC_LONG"].ToString();
						_originalDesc_short = Reader["DESC_SHORT"].ToString();
						_originalTithe_in_ex_clude_flag = Reader["TITHE_IN_EX_CLUDE_FLAG"].ToString();
						_originalFlag_display_hide = Reader["FLAG_DISPLAY_HIDE"].ToString();
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