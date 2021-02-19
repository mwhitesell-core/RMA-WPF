using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F199_USER_DEFINED_FIELDS : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F199_USER_DEFINED_FIELDS> Collection( Guid? rowid,
															string record_id,
															string interpretation_desc,
															string field_desc1,
															string field_desc2,
															string field_desc3,
															string field_desc4,
															string field_desc5,
															string field_desc6,
															string field_desc7,
															string field_desc8,
															string field_desc9,
															string field_desc10,
															decimal? last_mod_datemin,
															decimal? last_mod_datemax,
															decimal? last_mod_timemin,
															decimal? last_mod_timemax,
															string last_mod_user_id,
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
					new SqlParameter("RECORD_ID",record_id),
					new SqlParameter("INTERPRETATION_DESC",interpretation_desc),
					new SqlParameter("FIELD_DESC1",field_desc1),
					new SqlParameter("FIELD_DESC2",field_desc2),
					new SqlParameter("FIELD_DESC3",field_desc3),
					new SqlParameter("FIELD_DESC4",field_desc4),
					new SqlParameter("FIELD_DESC5",field_desc5),
					new SqlParameter("FIELD_DESC6",field_desc6),
					new SqlParameter("FIELD_DESC7",field_desc7),
					new SqlParameter("FIELD_DESC8",field_desc8),
					new SqlParameter("FIELD_DESC9",field_desc9),
					new SqlParameter("FIELD_DESC10",field_desc10),
					new SqlParameter("minLAST_MOD_DATE",last_mod_datemin),
					new SqlParameter("maxLAST_MOD_DATE",last_mod_datemax),
					new SqlParameter("minLAST_MOD_TIME",last_mod_timemin),
					new SqlParameter("maxLAST_MOD_TIME",last_mod_timemax),
					new SqlParameter("LAST_MOD_USER_ID",last_mod_user_id),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F199_USER_DEFINED_FIELDS_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F199_USER_DEFINED_FIELDS>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F199_USER_DEFINED_FIELDS_Search]", parameters);
            var collection = new ObservableCollection<F199_USER_DEFINED_FIELDS>();

            while (Reader.Read())
            {
                collection.Add(new F199_USER_DEFINED_FIELDS
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					RECORD_ID = Reader["RECORD_ID"].ToString(),
					INTERPRETATION_DESC = Reader["INTERPRETATION_DESC"].ToString(),
					FIELD_DESC1 = Reader["FIELD_DESC1"].ToString(),
					FIELD_DESC2 = Reader["FIELD_DESC2"].ToString(),
					FIELD_DESC3 = Reader["FIELD_DESC3"].ToString(),
					FIELD_DESC4 = Reader["FIELD_DESC4"].ToString(),
					FIELD_DESC5 = Reader["FIELD_DESC5"].ToString(),
					FIELD_DESC6 = Reader["FIELD_DESC6"].ToString(),
					FIELD_DESC7 = Reader["FIELD_DESC7"].ToString(),
					FIELD_DESC8 = Reader["FIELD_DESC8"].ToString(),
					FIELD_DESC9 = Reader["FIELD_DESC9"].ToString(),
					FIELD_DESC10 = Reader["FIELD_DESC10"].ToString(),
					LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]),
					LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]),
					LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalRecord_id = Reader["RECORD_ID"].ToString(),
					_originalInterpretation_desc = Reader["INTERPRETATION_DESC"].ToString(),
					_originalField_desc1 = Reader["FIELD_DESC1"].ToString(),
					_originalField_desc2 = Reader["FIELD_DESC2"].ToString(),
					_originalField_desc3 = Reader["FIELD_DESC3"].ToString(),
					_originalField_desc4 = Reader["FIELD_DESC4"].ToString(),
					_originalField_desc5 = Reader["FIELD_DESC5"].ToString(),
					_originalField_desc6 = Reader["FIELD_DESC6"].ToString(),
					_originalField_desc7 = Reader["FIELD_DESC7"].ToString(),
					_originalField_desc8 = Reader["FIELD_DESC8"].ToString(),
					_originalField_desc9 = Reader["FIELD_DESC9"].ToString(),
					_originalField_desc10 = Reader["FIELD_DESC10"].ToString(),
					_originalLast_mod_date = ConvertDEC(Reader["LAST_MOD_DATE"]),
					_originalLast_mod_time = ConvertDEC(Reader["LAST_MOD_TIME"]),
					_originalLast_mod_user_id = Reader["LAST_MOD_USER_ID"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F199_USER_DEFINED_FIELDS Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F199_USER_DEFINED_FIELDS> Collection(ObservableCollection<F199_USER_DEFINED_FIELDS>
                                                               f199UserDefinedFields = null)
        {
            if (IsSameSearch() && f199UserDefinedFields != null)
            {
                return f199UserDefinedFields;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F199_USER_DEFINED_FIELDS>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("RECORD_ID",WhereRecord_id),
					new SqlParameter("INTERPRETATION_DESC",WhereInterpretation_desc),
					new SqlParameter("FIELD_DESC1",WhereField_desc1),
					new SqlParameter("FIELD_DESC2",WhereField_desc2),
					new SqlParameter("FIELD_DESC3",WhereField_desc3),
					new SqlParameter("FIELD_DESC4",WhereField_desc4),
					new SqlParameter("FIELD_DESC5",WhereField_desc5),
					new SqlParameter("FIELD_DESC6",WhereField_desc6),
					new SqlParameter("FIELD_DESC7",WhereField_desc7),
					new SqlParameter("FIELD_DESC8",WhereField_desc8),
					new SqlParameter("FIELD_DESC9",WhereField_desc9),
					new SqlParameter("FIELD_DESC10",WhereField_desc10),
					new SqlParameter("LAST_MOD_DATE",WhereLast_mod_date),
					new SqlParameter("LAST_MOD_TIME",WhereLast_mod_time),
					new SqlParameter("LAST_MOD_USER_ID",WhereLast_mod_user_id),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F199_USER_DEFINED_FIELDS_Match]", parameters);
            var collection = new ObservableCollection<F199_USER_DEFINED_FIELDS>();

            while (Reader.Read())
            {
                collection.Add(new F199_USER_DEFINED_FIELDS
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					RECORD_ID = Reader["RECORD_ID"].ToString(),
					INTERPRETATION_DESC = Reader["INTERPRETATION_DESC"].ToString(),
					FIELD_DESC1 = Reader["FIELD_DESC1"].ToString(),
					FIELD_DESC2 = Reader["FIELD_DESC2"].ToString(),
					FIELD_DESC3 = Reader["FIELD_DESC3"].ToString(),
					FIELD_DESC4 = Reader["FIELD_DESC4"].ToString(),
					FIELD_DESC5 = Reader["FIELD_DESC5"].ToString(),
					FIELD_DESC6 = Reader["FIELD_DESC6"].ToString(),
					FIELD_DESC7 = Reader["FIELD_DESC7"].ToString(),
					FIELD_DESC8 = Reader["FIELD_DESC8"].ToString(),
					FIELD_DESC9 = Reader["FIELD_DESC9"].ToString(),
					FIELD_DESC10 = Reader["FIELD_DESC10"].ToString(),
					LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]),
					LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]),
					LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereRecord_id = WhereRecord_id,
					_whereInterpretation_desc = WhereInterpretation_desc,
					_whereField_desc1 = WhereField_desc1,
					_whereField_desc2 = WhereField_desc2,
					_whereField_desc3 = WhereField_desc3,
					_whereField_desc4 = WhereField_desc4,
					_whereField_desc5 = WhereField_desc5,
					_whereField_desc6 = WhereField_desc6,
					_whereField_desc7 = WhereField_desc7,
					_whereField_desc8 = WhereField_desc8,
					_whereField_desc9 = WhereField_desc9,
					_whereField_desc10 = WhereField_desc10,
					_whereLast_mod_date = WhereLast_mod_date,
					_whereLast_mod_time = WhereLast_mod_time,
					_whereLast_mod_user_id = WhereLast_mod_user_id,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalRecord_id = Reader["RECORD_ID"].ToString(),
					_originalInterpretation_desc = Reader["INTERPRETATION_DESC"].ToString(),
					_originalField_desc1 = Reader["FIELD_DESC1"].ToString(),
					_originalField_desc2 = Reader["FIELD_DESC2"].ToString(),
					_originalField_desc3 = Reader["FIELD_DESC3"].ToString(),
					_originalField_desc4 = Reader["FIELD_DESC4"].ToString(),
					_originalField_desc5 = Reader["FIELD_DESC5"].ToString(),
					_originalField_desc6 = Reader["FIELD_DESC6"].ToString(),
					_originalField_desc7 = Reader["FIELD_DESC7"].ToString(),
					_originalField_desc8 = Reader["FIELD_DESC8"].ToString(),
					_originalField_desc9 = Reader["FIELD_DESC9"].ToString(),
					_originalField_desc10 = Reader["FIELD_DESC10"].ToString(),
					_originalLast_mod_date = ConvertDEC(Reader["LAST_MOD_DATE"]),
					_originalLast_mod_time = ConvertDEC(Reader["LAST_MOD_TIME"]),
					_originalLast_mod_user_id = Reader["LAST_MOD_USER_ID"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereRecord_id = WhereRecord_id;
					_whereInterpretation_desc = WhereInterpretation_desc;
					_whereField_desc1 = WhereField_desc1;
					_whereField_desc2 = WhereField_desc2;
					_whereField_desc3 = WhereField_desc3;
					_whereField_desc4 = WhereField_desc4;
					_whereField_desc5 = WhereField_desc5;
					_whereField_desc6 = WhereField_desc6;
					_whereField_desc7 = WhereField_desc7;
					_whereField_desc8 = WhereField_desc8;
					_whereField_desc9 = WhereField_desc9;
					_whereField_desc10 = WhereField_desc10;
					_whereLast_mod_date = WhereLast_mod_date;
					_whereLast_mod_time = WhereLast_mod_time;
					_whereLast_mod_user_id = WhereLast_mod_user_id;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereRecord_id == null 
				&& WhereInterpretation_desc == null 
				&& WhereField_desc1 == null 
				&& WhereField_desc2 == null 
				&& WhereField_desc3 == null 
				&& WhereField_desc4 == null 
				&& WhereField_desc5 == null 
				&& WhereField_desc6 == null 
				&& WhereField_desc7 == null 
				&& WhereField_desc8 == null 
				&& WhereField_desc9 == null 
				&& WhereField_desc10 == null 
				&& WhereLast_mod_date == null 
				&& WhereLast_mod_time == null 
				&& WhereLast_mod_user_id == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereRecord_id ==  _whereRecord_id
				&& WhereInterpretation_desc ==  _whereInterpretation_desc
				&& WhereField_desc1 ==  _whereField_desc1
				&& WhereField_desc2 ==  _whereField_desc2
				&& WhereField_desc3 ==  _whereField_desc3
				&& WhereField_desc4 ==  _whereField_desc4
				&& WhereField_desc5 ==  _whereField_desc5
				&& WhereField_desc6 ==  _whereField_desc6
				&& WhereField_desc7 ==  _whereField_desc7
				&& WhereField_desc8 ==  _whereField_desc8
				&& WhereField_desc9 ==  _whereField_desc9
				&& WhereField_desc10 ==  _whereField_desc10
				&& WhereLast_mod_date ==  _whereLast_mod_date
				&& WhereLast_mod_time ==  _whereLast_mod_time
				&& WhereLast_mod_user_id ==  _whereLast_mod_user_id
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereRecord_id = null; 
			WhereInterpretation_desc = null; 
			WhereField_desc1 = null; 
			WhereField_desc2 = null; 
			WhereField_desc3 = null; 
			WhereField_desc4 = null; 
			WhereField_desc5 = null; 
			WhereField_desc6 = null; 
			WhereField_desc7 = null; 
			WhereField_desc8 = null; 
			WhereField_desc9 = null; 
			WhereField_desc10 = null; 
			WhereLast_mod_date = null; 
			WhereLast_mod_time = null; 
			WhereLast_mod_user_id = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _RECORD_ID;
		private string _INTERPRETATION_DESC;
		private string _FIELD_DESC1;
		private string _FIELD_DESC2;
		private string _FIELD_DESC3;
		private string _FIELD_DESC4;
		private string _FIELD_DESC5;
		private string _FIELD_DESC6;
		private string _FIELD_DESC7;
		private string _FIELD_DESC8;
		private string _FIELD_DESC9;
		private string _FIELD_DESC10;
		private decimal? _LAST_MOD_DATE;
		private decimal? _LAST_MOD_TIME;
		private string _LAST_MOD_USER_ID;
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
		public string RECORD_ID
		{
			get { return _RECORD_ID; }
			set
			{
				if (_RECORD_ID != value)
				{
					_RECORD_ID = value;
					ChangeState();
				}
			}
		}
		public string INTERPRETATION_DESC
		{
			get { return _INTERPRETATION_DESC; }
			set
			{
				if (_INTERPRETATION_DESC != value)
				{
					_INTERPRETATION_DESC = value;
					ChangeState();
				}
			}
		}
		public string FIELD_DESC1
		{
			get { return _FIELD_DESC1; }
			set
			{
				if (_FIELD_DESC1 != value)
				{
					_FIELD_DESC1 = value;
					ChangeState();
				}
			}
		}
		public string FIELD_DESC2
		{
			get { return _FIELD_DESC2; }
			set
			{
				if (_FIELD_DESC2 != value)
				{
					_FIELD_DESC2 = value;
					ChangeState();
				}
			}
		}
		public string FIELD_DESC3
		{
			get { return _FIELD_DESC3; }
			set
			{
				if (_FIELD_DESC3 != value)
				{
					_FIELD_DESC3 = value;
					ChangeState();
				}
			}
		}
		public string FIELD_DESC4
		{
			get { return _FIELD_DESC4; }
			set
			{
				if (_FIELD_DESC4 != value)
				{
					_FIELD_DESC4 = value;
					ChangeState();
				}
			}
		}
		public string FIELD_DESC5
		{
			get { return _FIELD_DESC5; }
			set
			{
				if (_FIELD_DESC5 != value)
				{
					_FIELD_DESC5 = value;
					ChangeState();
				}
			}
		}
		public string FIELD_DESC6
		{
			get { return _FIELD_DESC6; }
			set
			{
				if (_FIELD_DESC6 != value)
				{
					_FIELD_DESC6 = value;
					ChangeState();
				}
			}
		}
		public string FIELD_DESC7
		{
			get { return _FIELD_DESC7; }
			set
			{
				if (_FIELD_DESC7 != value)
				{
					_FIELD_DESC7 = value;
					ChangeState();
				}
			}
		}
		public string FIELD_DESC8
		{
			get { return _FIELD_DESC8; }
			set
			{
				if (_FIELD_DESC8 != value)
				{
					_FIELD_DESC8 = value;
					ChangeState();
				}
			}
		}
		public string FIELD_DESC9
		{
			get { return _FIELD_DESC9; }
			set
			{
				if (_FIELD_DESC9 != value)
				{
					_FIELD_DESC9 = value;
					ChangeState();
				}
			}
		}
		public string FIELD_DESC10
		{
			get { return _FIELD_DESC10; }
			set
			{
				if (_FIELD_DESC10 != value)
				{
					_FIELD_DESC10 = value;
					ChangeState();
				}
			}
		}
		public decimal? LAST_MOD_DATE
		{
			get { return _LAST_MOD_DATE; }
			set
			{
				if (_LAST_MOD_DATE != value)
				{
					_LAST_MOD_DATE = value;
					ChangeState();
				}
			}
		}
		public decimal? LAST_MOD_TIME
		{
			get { return _LAST_MOD_TIME; }
			set
			{
				if (_LAST_MOD_TIME != value)
				{
					_LAST_MOD_TIME = value;
					ChangeState();
				}
			}
		}
		public string LAST_MOD_USER_ID
		{
			get { return _LAST_MOD_USER_ID; }
			set
			{
				if (_LAST_MOD_USER_ID != value)
				{
					_LAST_MOD_USER_ID = value;
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
		public string WhereRecord_id { get; set; }
		private string _whereRecord_id;
		public string WhereInterpretation_desc { get; set; }
		private string _whereInterpretation_desc;
		public string WhereField_desc1 { get; set; }
		private string _whereField_desc1;
		public string WhereField_desc2 { get; set; }
		private string _whereField_desc2;
		public string WhereField_desc3 { get; set; }
		private string _whereField_desc3;
		public string WhereField_desc4 { get; set; }
		private string _whereField_desc4;
		public string WhereField_desc5 { get; set; }
		private string _whereField_desc5;
		public string WhereField_desc6 { get; set; }
		private string _whereField_desc6;
		public string WhereField_desc7 { get; set; }
		private string _whereField_desc7;
		public string WhereField_desc8 { get; set; }
		private string _whereField_desc8;
		public string WhereField_desc9 { get; set; }
		private string _whereField_desc9;
		public string WhereField_desc10 { get; set; }
		private string _whereField_desc10;
		public decimal? WhereLast_mod_date { get; set; }
		private decimal? _whereLast_mod_date;
		public decimal? WhereLast_mod_time { get; set; }
		private decimal? _whereLast_mod_time;
		public string WhereLast_mod_user_id { get; set; }
		private string _whereLast_mod_user_id;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalRecord_id;
		private string _originalInterpretation_desc;
		private string _originalField_desc1;
		private string _originalField_desc2;
		private string _originalField_desc3;
		private string _originalField_desc4;
		private string _originalField_desc5;
		private string _originalField_desc6;
		private string _originalField_desc7;
		private string _originalField_desc8;
		private string _originalField_desc9;
		private string _originalField_desc10;
		private decimal? _originalLast_mod_date;
		private decimal? _originalLast_mod_time;
		private string _originalLast_mod_user_id;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			RECORD_ID = _originalRecord_id;
			INTERPRETATION_DESC = _originalInterpretation_desc;
			FIELD_DESC1 = _originalField_desc1;
			FIELD_DESC2 = _originalField_desc2;
			FIELD_DESC3 = _originalField_desc3;
			FIELD_DESC4 = _originalField_desc4;
			FIELD_DESC5 = _originalField_desc5;
			FIELD_DESC6 = _originalField_desc6;
			FIELD_DESC7 = _originalField_desc7;
			FIELD_DESC8 = _originalField_desc8;
			FIELD_DESC9 = _originalField_desc9;
			FIELD_DESC10 = _originalField_desc10;
			LAST_MOD_DATE = _originalLast_mod_date;
			LAST_MOD_TIME = _originalLast_mod_time;
			LAST_MOD_USER_ID = _originalLast_mod_user_id;
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
					new SqlParameter("RECORD_ID",RECORD_ID)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F199_USER_DEFINED_FIELDS_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F199_USER_DEFINED_FIELDS_Purge]");
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
						new SqlParameter("RECORD_ID", SqlNull(RECORD_ID)),
						new SqlParameter("INTERPRETATION_DESC", SqlNull(INTERPRETATION_DESC)),
						new SqlParameter("FIELD_DESC1", SqlNull(FIELD_DESC1)),
						new SqlParameter("FIELD_DESC2", SqlNull(FIELD_DESC2)),
						new SqlParameter("FIELD_DESC3", SqlNull(FIELD_DESC3)),
						new SqlParameter("FIELD_DESC4", SqlNull(FIELD_DESC4)),
						new SqlParameter("FIELD_DESC5", SqlNull(FIELD_DESC5)),
						new SqlParameter("FIELD_DESC6", SqlNull(FIELD_DESC6)),
						new SqlParameter("FIELD_DESC7", SqlNull(FIELD_DESC7)),
						new SqlParameter("FIELD_DESC8", SqlNull(FIELD_DESC8)),
						new SqlParameter("FIELD_DESC9", SqlNull(FIELD_DESC9)),
						new SqlParameter("FIELD_DESC10", SqlNull(FIELD_DESC10)),
						new SqlParameter("LAST_MOD_DATE", SqlNull(LAST_MOD_DATE)),
						new SqlParameter("LAST_MOD_TIME", SqlNull(LAST_MOD_TIME)),
						new SqlParameter("LAST_MOD_USER_ID", SqlNull(LAST_MOD_USER_ID)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F199_USER_DEFINED_FIELDS_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						RECORD_ID = Reader["RECORD_ID"].ToString();
						INTERPRETATION_DESC = Reader["INTERPRETATION_DESC"].ToString();
						FIELD_DESC1 = Reader["FIELD_DESC1"].ToString();
						FIELD_DESC2 = Reader["FIELD_DESC2"].ToString();
						FIELD_DESC3 = Reader["FIELD_DESC3"].ToString();
						FIELD_DESC4 = Reader["FIELD_DESC4"].ToString();
						FIELD_DESC5 = Reader["FIELD_DESC5"].ToString();
						FIELD_DESC6 = Reader["FIELD_DESC6"].ToString();
						FIELD_DESC7 = Reader["FIELD_DESC7"].ToString();
						FIELD_DESC8 = Reader["FIELD_DESC8"].ToString();
						FIELD_DESC9 = Reader["FIELD_DESC9"].ToString();
						FIELD_DESC10 = Reader["FIELD_DESC10"].ToString();
						LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]);
						LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]);
						LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalRecord_id = Reader["RECORD_ID"].ToString();
						_originalInterpretation_desc = Reader["INTERPRETATION_DESC"].ToString();
						_originalField_desc1 = Reader["FIELD_DESC1"].ToString();
						_originalField_desc2 = Reader["FIELD_DESC2"].ToString();
						_originalField_desc3 = Reader["FIELD_DESC3"].ToString();
						_originalField_desc4 = Reader["FIELD_DESC4"].ToString();
						_originalField_desc5 = Reader["FIELD_DESC5"].ToString();
						_originalField_desc6 = Reader["FIELD_DESC6"].ToString();
						_originalField_desc7 = Reader["FIELD_DESC7"].ToString();
						_originalField_desc8 = Reader["FIELD_DESC8"].ToString();
						_originalField_desc9 = Reader["FIELD_DESC9"].ToString();
						_originalField_desc10 = Reader["FIELD_DESC10"].ToString();
						_originalLast_mod_date = ConvertDEC(Reader["LAST_MOD_DATE"]);
						_originalLast_mod_time = ConvertDEC(Reader["LAST_MOD_TIME"]);
						_originalLast_mod_user_id = Reader["LAST_MOD_USER_ID"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("RECORD_ID", SqlNull(RECORD_ID)),
						new SqlParameter("INTERPRETATION_DESC", SqlNull(INTERPRETATION_DESC)),
						new SqlParameter("FIELD_DESC1", SqlNull(FIELD_DESC1)),
						new SqlParameter("FIELD_DESC2", SqlNull(FIELD_DESC2)),
						new SqlParameter("FIELD_DESC3", SqlNull(FIELD_DESC3)),
						new SqlParameter("FIELD_DESC4", SqlNull(FIELD_DESC4)),
						new SqlParameter("FIELD_DESC5", SqlNull(FIELD_DESC5)),
						new SqlParameter("FIELD_DESC6", SqlNull(FIELD_DESC6)),
						new SqlParameter("FIELD_DESC7", SqlNull(FIELD_DESC7)),
						new SqlParameter("FIELD_DESC8", SqlNull(FIELD_DESC8)),
						new SqlParameter("FIELD_DESC9", SqlNull(FIELD_DESC9)),
						new SqlParameter("FIELD_DESC10", SqlNull(FIELD_DESC10)),
						new SqlParameter("LAST_MOD_DATE", SqlNull(LAST_MOD_DATE)),
						new SqlParameter("LAST_MOD_TIME", SqlNull(LAST_MOD_TIME)),
						new SqlParameter("LAST_MOD_USER_ID", SqlNull(LAST_MOD_USER_ID)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F199_USER_DEFINED_FIELDS_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						RECORD_ID = Reader["RECORD_ID"].ToString();
						INTERPRETATION_DESC = Reader["INTERPRETATION_DESC"].ToString();
						FIELD_DESC1 = Reader["FIELD_DESC1"].ToString();
						FIELD_DESC2 = Reader["FIELD_DESC2"].ToString();
						FIELD_DESC3 = Reader["FIELD_DESC3"].ToString();
						FIELD_DESC4 = Reader["FIELD_DESC4"].ToString();
						FIELD_DESC5 = Reader["FIELD_DESC5"].ToString();
						FIELD_DESC6 = Reader["FIELD_DESC6"].ToString();
						FIELD_DESC7 = Reader["FIELD_DESC7"].ToString();
						FIELD_DESC8 = Reader["FIELD_DESC8"].ToString();
						FIELD_DESC9 = Reader["FIELD_DESC9"].ToString();
						FIELD_DESC10 = Reader["FIELD_DESC10"].ToString();
						LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]);
						LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]);
						LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalRecord_id = Reader["RECORD_ID"].ToString();
						_originalInterpretation_desc = Reader["INTERPRETATION_DESC"].ToString();
						_originalField_desc1 = Reader["FIELD_DESC1"].ToString();
						_originalField_desc2 = Reader["FIELD_DESC2"].ToString();
						_originalField_desc3 = Reader["FIELD_DESC3"].ToString();
						_originalField_desc4 = Reader["FIELD_DESC4"].ToString();
						_originalField_desc5 = Reader["FIELD_DESC5"].ToString();
						_originalField_desc6 = Reader["FIELD_DESC6"].ToString();
						_originalField_desc7 = Reader["FIELD_DESC7"].ToString();
						_originalField_desc8 = Reader["FIELD_DESC8"].ToString();
						_originalField_desc9 = Reader["FIELD_DESC9"].ToString();
						_originalField_desc10 = Reader["FIELD_DESC10"].ToString();
						_originalLast_mod_date = ConvertDEC(Reader["LAST_MOD_DATE"]);
						_originalLast_mod_time = ConvertDEC(Reader["LAST_MOD_TIME"]);
						_originalLast_mod_user_id = Reader["LAST_MOD_USER_ID"].ToString();
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