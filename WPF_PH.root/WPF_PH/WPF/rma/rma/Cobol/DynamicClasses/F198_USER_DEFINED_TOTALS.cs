using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F198_USER_DEFINED_TOTALS : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F198_USER_DEFINED_TOTALS> Collection( Guid? rowid,
															string record_id,
															string udt_key,
															decimal? user_total1min,
															decimal? user_total1max,
															decimal? user_total2min,
															decimal? user_total2max,
															decimal? user_total3min,
															decimal? user_total3max,
															decimal? user_total4min,
															decimal? user_total4max,
															decimal? user_total5min,
															decimal? user_total5max,
															decimal? user_total6min,
															decimal? user_total6max,
															decimal? user_total7min,
															decimal? user_total7max,
															decimal? user_total8min,
															decimal? user_total8max,
															decimal? user_total9min,
															decimal? user_total9max,
															decimal? user_total10min,
															decimal? user_total10max,
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
					new SqlParameter("UDT_KEY",udt_key),
					new SqlParameter("minUSER_TOTAL1",user_total1min),
					new SqlParameter("maxUSER_TOTAL1",user_total1max),
					new SqlParameter("minUSER_TOTAL2",user_total2min),
					new SqlParameter("maxUSER_TOTAL2",user_total2max),
					new SqlParameter("minUSER_TOTAL3",user_total3min),
					new SqlParameter("maxUSER_TOTAL3",user_total3max),
					new SqlParameter("minUSER_TOTAL4",user_total4min),
					new SqlParameter("maxUSER_TOTAL4",user_total4max),
					new SqlParameter("minUSER_TOTAL5",user_total5min),
					new SqlParameter("maxUSER_TOTAL5",user_total5max),
					new SqlParameter("minUSER_TOTAL6",user_total6min),
					new SqlParameter("maxUSER_TOTAL6",user_total6max),
					new SqlParameter("minUSER_TOTAL7",user_total7min),
					new SqlParameter("maxUSER_TOTAL7",user_total7max),
					new SqlParameter("minUSER_TOTAL8",user_total8min),
					new SqlParameter("maxUSER_TOTAL8",user_total8max),
					new SqlParameter("minUSER_TOTAL9",user_total9min),
					new SqlParameter("maxUSER_TOTAL9",user_total9max),
					new SqlParameter("minUSER_TOTAL10",user_total10min),
					new SqlParameter("maxUSER_TOTAL10",user_total10max),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F198_USER_DEFINED_TOTALS_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F198_USER_DEFINED_TOTALS>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F198_USER_DEFINED_TOTALS_Search]", parameters);
            var collection = new ObservableCollection<F198_USER_DEFINED_TOTALS>();

            while (Reader.Read())
            {
                collection.Add(new F198_USER_DEFINED_TOTALS
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					RECORD_ID = Reader["RECORD_ID"].ToString(),
					UDT_KEY = Reader["UDT_KEY"].ToString(),
					USER_TOTAL1 = ConvertDEC(Reader["USER_TOTAL1"]),
					USER_TOTAL2 = ConvertDEC(Reader["USER_TOTAL2"]),
					USER_TOTAL3 = ConvertDEC(Reader["USER_TOTAL3"]),
					USER_TOTAL4 = ConvertDEC(Reader["USER_TOTAL4"]),
					USER_TOTAL5 = ConvertDEC(Reader["USER_TOTAL5"]),
					USER_TOTAL6 = ConvertDEC(Reader["USER_TOTAL6"]),
					USER_TOTAL7 = ConvertDEC(Reader["USER_TOTAL7"]),
					USER_TOTAL8 = ConvertDEC(Reader["USER_TOTAL8"]),
					USER_TOTAL9 = ConvertDEC(Reader["USER_TOTAL9"]),
					USER_TOTAL10 = ConvertDEC(Reader["USER_TOTAL10"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalRecord_id = Reader["RECORD_ID"].ToString(),
					_originalUdt_key = Reader["UDT_KEY"].ToString(),
					_originalUser_total1 = ConvertDEC(Reader["USER_TOTAL1"]),
					_originalUser_total2 = ConvertDEC(Reader["USER_TOTAL2"]),
					_originalUser_total3 = ConvertDEC(Reader["USER_TOTAL3"]),
					_originalUser_total4 = ConvertDEC(Reader["USER_TOTAL4"]),
					_originalUser_total5 = ConvertDEC(Reader["USER_TOTAL5"]),
					_originalUser_total6 = ConvertDEC(Reader["USER_TOTAL6"]),
					_originalUser_total7 = ConvertDEC(Reader["USER_TOTAL7"]),
					_originalUser_total8 = ConvertDEC(Reader["USER_TOTAL8"]),
					_originalUser_total9 = ConvertDEC(Reader["USER_TOTAL9"]),
					_originalUser_total10 = ConvertDEC(Reader["USER_TOTAL10"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F198_USER_DEFINED_TOTALS Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F198_USER_DEFINED_TOTALS> Collection(ObservableCollection<F198_USER_DEFINED_TOTALS>
                                                               f198UserDefinedTotals = null)
        {
            if (IsSameSearch() && f198UserDefinedTotals != null)
            {
                return f198UserDefinedTotals;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F198_USER_DEFINED_TOTALS>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("RECORD_ID",WhereRecord_id),
					new SqlParameter("UDT_KEY",WhereUdt_key),
					new SqlParameter("USER_TOTAL1",WhereUser_total1),
					new SqlParameter("USER_TOTAL2",WhereUser_total2),
					new SqlParameter("USER_TOTAL3",WhereUser_total3),
					new SqlParameter("USER_TOTAL4",WhereUser_total4),
					new SqlParameter("USER_TOTAL5",WhereUser_total5),
					new SqlParameter("USER_TOTAL6",WhereUser_total6),
					new SqlParameter("USER_TOTAL7",WhereUser_total7),
					new SqlParameter("USER_TOTAL8",WhereUser_total8),
					new SqlParameter("USER_TOTAL9",WhereUser_total9),
					new SqlParameter("USER_TOTAL10",WhereUser_total10),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F198_USER_DEFINED_TOTALS_Match]", parameters);
            var collection = new ObservableCollection<F198_USER_DEFINED_TOTALS>();

            while (Reader.Read())
            {
                collection.Add(new F198_USER_DEFINED_TOTALS
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					RECORD_ID = Reader["RECORD_ID"].ToString(),
					UDT_KEY = Reader["UDT_KEY"].ToString(),
					USER_TOTAL1 = ConvertDEC(Reader["USER_TOTAL1"]),
					USER_TOTAL2 = ConvertDEC(Reader["USER_TOTAL2"]),
					USER_TOTAL3 = ConvertDEC(Reader["USER_TOTAL3"]),
					USER_TOTAL4 = ConvertDEC(Reader["USER_TOTAL4"]),
					USER_TOTAL5 = ConvertDEC(Reader["USER_TOTAL5"]),
					USER_TOTAL6 = ConvertDEC(Reader["USER_TOTAL6"]),
					USER_TOTAL7 = ConvertDEC(Reader["USER_TOTAL7"]),
					USER_TOTAL8 = ConvertDEC(Reader["USER_TOTAL8"]),
					USER_TOTAL9 = ConvertDEC(Reader["USER_TOTAL9"]),
					USER_TOTAL10 = ConvertDEC(Reader["USER_TOTAL10"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereRecord_id = WhereRecord_id,
					_whereUdt_key = WhereUdt_key,
					_whereUser_total1 = WhereUser_total1,
					_whereUser_total2 = WhereUser_total2,
					_whereUser_total3 = WhereUser_total3,
					_whereUser_total4 = WhereUser_total4,
					_whereUser_total5 = WhereUser_total5,
					_whereUser_total6 = WhereUser_total6,
					_whereUser_total7 = WhereUser_total7,
					_whereUser_total8 = WhereUser_total8,
					_whereUser_total9 = WhereUser_total9,
					_whereUser_total10 = WhereUser_total10,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalRecord_id = Reader["RECORD_ID"].ToString(),
					_originalUdt_key = Reader["UDT_KEY"].ToString(),
					_originalUser_total1 = ConvertDEC(Reader["USER_TOTAL1"]),
					_originalUser_total2 = ConvertDEC(Reader["USER_TOTAL2"]),
					_originalUser_total3 = ConvertDEC(Reader["USER_TOTAL3"]),
					_originalUser_total4 = ConvertDEC(Reader["USER_TOTAL4"]),
					_originalUser_total5 = ConvertDEC(Reader["USER_TOTAL5"]),
					_originalUser_total6 = ConvertDEC(Reader["USER_TOTAL6"]),
					_originalUser_total7 = ConvertDEC(Reader["USER_TOTAL7"]),
					_originalUser_total8 = ConvertDEC(Reader["USER_TOTAL8"]),
					_originalUser_total9 = ConvertDEC(Reader["USER_TOTAL9"]),
					_originalUser_total10 = ConvertDEC(Reader["USER_TOTAL10"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereRecord_id = WhereRecord_id;
					_whereUdt_key = WhereUdt_key;
					_whereUser_total1 = WhereUser_total1;
					_whereUser_total2 = WhereUser_total2;
					_whereUser_total3 = WhereUser_total3;
					_whereUser_total4 = WhereUser_total4;
					_whereUser_total5 = WhereUser_total5;
					_whereUser_total6 = WhereUser_total6;
					_whereUser_total7 = WhereUser_total7;
					_whereUser_total8 = WhereUser_total8;
					_whereUser_total9 = WhereUser_total9;
					_whereUser_total10 = WhereUser_total10;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereRecord_id == null 
				&& WhereUdt_key == null 
				&& WhereUser_total1 == null 
				&& WhereUser_total2 == null 
				&& WhereUser_total3 == null 
				&& WhereUser_total4 == null 
				&& WhereUser_total5 == null 
				&& WhereUser_total6 == null 
				&& WhereUser_total7 == null 
				&& WhereUser_total8 == null 
				&& WhereUser_total9 == null 
				&& WhereUser_total10 == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereRecord_id ==  _whereRecord_id
				&& WhereUdt_key ==  _whereUdt_key
				&& WhereUser_total1 ==  _whereUser_total1
				&& WhereUser_total2 ==  _whereUser_total2
				&& WhereUser_total3 ==  _whereUser_total3
				&& WhereUser_total4 ==  _whereUser_total4
				&& WhereUser_total5 ==  _whereUser_total5
				&& WhereUser_total6 ==  _whereUser_total6
				&& WhereUser_total7 ==  _whereUser_total7
				&& WhereUser_total8 ==  _whereUser_total8
				&& WhereUser_total9 ==  _whereUser_total9
				&& WhereUser_total10 ==  _whereUser_total10
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereRecord_id = null; 
			WhereUdt_key = null; 
			WhereUser_total1 = null; 
			WhereUser_total2 = null; 
			WhereUser_total3 = null; 
			WhereUser_total4 = null; 
			WhereUser_total5 = null; 
			WhereUser_total6 = null; 
			WhereUser_total7 = null; 
			WhereUser_total8 = null; 
			WhereUser_total9 = null; 
			WhereUser_total10 = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _RECORD_ID;
		private string _UDT_KEY;
		private decimal? _USER_TOTAL1;
		private decimal? _USER_TOTAL2;
		private decimal? _USER_TOTAL3;
		private decimal? _USER_TOTAL4;
		private decimal? _USER_TOTAL5;
		private decimal? _USER_TOTAL6;
		private decimal? _USER_TOTAL7;
		private decimal? _USER_TOTAL8;
		private decimal? _USER_TOTAL9;
		private decimal? _USER_TOTAL10;
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
		public string UDT_KEY
		{
			get { return _UDT_KEY; }
			set
			{
				if (_UDT_KEY != value)
				{
					_UDT_KEY = value;
					ChangeState();
				}
			}
		}
		public decimal? USER_TOTAL1
		{
			get { return _USER_TOTAL1; }
			set
			{
				if (_USER_TOTAL1 != value)
				{
					_USER_TOTAL1 = value;
					ChangeState();
				}
			}
		}
		public decimal? USER_TOTAL2
		{
			get { return _USER_TOTAL2; }
			set
			{
				if (_USER_TOTAL2 != value)
				{
					_USER_TOTAL2 = value;
					ChangeState();
				}
			}
		}
		public decimal? USER_TOTAL3
		{
			get { return _USER_TOTAL3; }
			set
			{
				if (_USER_TOTAL3 != value)
				{
					_USER_TOTAL3 = value;
					ChangeState();
				}
			}
		}
		public decimal? USER_TOTAL4
		{
			get { return _USER_TOTAL4; }
			set
			{
				if (_USER_TOTAL4 != value)
				{
					_USER_TOTAL4 = value;
					ChangeState();
				}
			}
		}
		public decimal? USER_TOTAL5
		{
			get { return _USER_TOTAL5; }
			set
			{
				if (_USER_TOTAL5 != value)
				{
					_USER_TOTAL5 = value;
					ChangeState();
				}
			}
		}
		public decimal? USER_TOTAL6
		{
			get { return _USER_TOTAL6; }
			set
			{
				if (_USER_TOTAL6 != value)
				{
					_USER_TOTAL6 = value;
					ChangeState();
				}
			}
		}
		public decimal? USER_TOTAL7
		{
			get { return _USER_TOTAL7; }
			set
			{
				if (_USER_TOTAL7 != value)
				{
					_USER_TOTAL7 = value;
					ChangeState();
				}
			}
		}
		public decimal? USER_TOTAL8
		{
			get { return _USER_TOTAL8; }
			set
			{
				if (_USER_TOTAL8 != value)
				{
					_USER_TOTAL8 = value;
					ChangeState();
				}
			}
		}
		public decimal? USER_TOTAL9
		{
			get { return _USER_TOTAL9; }
			set
			{
				if (_USER_TOTAL9 != value)
				{
					_USER_TOTAL9 = value;
					ChangeState();
				}
			}
		}
		public decimal? USER_TOTAL10
		{
			get { return _USER_TOTAL10; }
			set
			{
				if (_USER_TOTAL10 != value)
				{
					_USER_TOTAL10 = value;
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
		public string WhereUdt_key { get; set; }
		private string _whereUdt_key;
		public decimal? WhereUser_total1 { get; set; }
		private decimal? _whereUser_total1;
		public decimal? WhereUser_total2 { get; set; }
		private decimal? _whereUser_total2;
		public decimal? WhereUser_total3 { get; set; }
		private decimal? _whereUser_total3;
		public decimal? WhereUser_total4 { get; set; }
		private decimal? _whereUser_total4;
		public decimal? WhereUser_total5 { get; set; }
		private decimal? _whereUser_total5;
		public decimal? WhereUser_total6 { get; set; }
		private decimal? _whereUser_total6;
		public decimal? WhereUser_total7 { get; set; }
		private decimal? _whereUser_total7;
		public decimal? WhereUser_total8 { get; set; }
		private decimal? _whereUser_total8;
		public decimal? WhereUser_total9 { get; set; }
		private decimal? _whereUser_total9;
		public decimal? WhereUser_total10 { get; set; }
		private decimal? _whereUser_total10;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalRecord_id;
		private string _originalUdt_key;
		private decimal? _originalUser_total1;
		private decimal? _originalUser_total2;
		private decimal? _originalUser_total3;
		private decimal? _originalUser_total4;
		private decimal? _originalUser_total5;
		private decimal? _originalUser_total6;
		private decimal? _originalUser_total7;
		private decimal? _originalUser_total8;
		private decimal? _originalUser_total9;
		private decimal? _originalUser_total10;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			RECORD_ID = _originalRecord_id;
			UDT_KEY = _originalUdt_key;
			USER_TOTAL1 = _originalUser_total1;
			USER_TOTAL2 = _originalUser_total2;
			USER_TOTAL3 = _originalUser_total3;
			USER_TOTAL4 = _originalUser_total4;
			USER_TOTAL5 = _originalUser_total5;
			USER_TOTAL6 = _originalUser_total6;
			USER_TOTAL7 = _originalUser_total7;
			USER_TOTAL8 = _originalUser_total8;
			USER_TOTAL9 = _originalUser_total9;
			USER_TOTAL10 = _originalUser_total10;
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
					new SqlParameter("RECORD_ID",RECORD_ID),
					new SqlParameter("UDT_KEY",UDT_KEY)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F198_USER_DEFINED_TOTALS_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F198_USER_DEFINED_TOTALS_Purge]");
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
						new SqlParameter("UDT_KEY", SqlNull(UDT_KEY)),
						new SqlParameter("USER_TOTAL1", SqlNull(USER_TOTAL1)),
						new SqlParameter("USER_TOTAL2", SqlNull(USER_TOTAL2)),
						new SqlParameter("USER_TOTAL3", SqlNull(USER_TOTAL3)),
						new SqlParameter("USER_TOTAL4", SqlNull(USER_TOTAL4)),
						new SqlParameter("USER_TOTAL5", SqlNull(USER_TOTAL5)),
						new SqlParameter("USER_TOTAL6", SqlNull(USER_TOTAL6)),
						new SqlParameter("USER_TOTAL7", SqlNull(USER_TOTAL7)),
						new SqlParameter("USER_TOTAL8", SqlNull(USER_TOTAL8)),
						new SqlParameter("USER_TOTAL9", SqlNull(USER_TOTAL9)),
						new SqlParameter("USER_TOTAL10", SqlNull(USER_TOTAL10)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F198_USER_DEFINED_TOTALS_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						RECORD_ID = Reader["RECORD_ID"].ToString();
						UDT_KEY = Reader["UDT_KEY"].ToString();
						USER_TOTAL1 = ConvertDEC(Reader["USER_TOTAL1"]);
						USER_TOTAL2 = ConvertDEC(Reader["USER_TOTAL2"]);
						USER_TOTAL3 = ConvertDEC(Reader["USER_TOTAL3"]);
						USER_TOTAL4 = ConvertDEC(Reader["USER_TOTAL4"]);
						USER_TOTAL5 = ConvertDEC(Reader["USER_TOTAL5"]);
						USER_TOTAL6 = ConvertDEC(Reader["USER_TOTAL6"]);
						USER_TOTAL7 = ConvertDEC(Reader["USER_TOTAL7"]);
						USER_TOTAL8 = ConvertDEC(Reader["USER_TOTAL8"]);
						USER_TOTAL9 = ConvertDEC(Reader["USER_TOTAL9"]);
						USER_TOTAL10 = ConvertDEC(Reader["USER_TOTAL10"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalRecord_id = Reader["RECORD_ID"].ToString();
						_originalUdt_key = Reader["UDT_KEY"].ToString();
						_originalUser_total1 = ConvertDEC(Reader["USER_TOTAL1"]);
						_originalUser_total2 = ConvertDEC(Reader["USER_TOTAL2"]);
						_originalUser_total3 = ConvertDEC(Reader["USER_TOTAL3"]);
						_originalUser_total4 = ConvertDEC(Reader["USER_TOTAL4"]);
						_originalUser_total5 = ConvertDEC(Reader["USER_TOTAL5"]);
						_originalUser_total6 = ConvertDEC(Reader["USER_TOTAL6"]);
						_originalUser_total7 = ConvertDEC(Reader["USER_TOTAL7"]);
						_originalUser_total8 = ConvertDEC(Reader["USER_TOTAL8"]);
						_originalUser_total9 = ConvertDEC(Reader["USER_TOTAL9"]);
						_originalUser_total10 = ConvertDEC(Reader["USER_TOTAL10"]);
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("RECORD_ID", SqlNull(RECORD_ID)),
						new SqlParameter("UDT_KEY", SqlNull(UDT_KEY)),
						new SqlParameter("USER_TOTAL1", SqlNull(USER_TOTAL1)),
						new SqlParameter("USER_TOTAL2", SqlNull(USER_TOTAL2)),
						new SqlParameter("USER_TOTAL3", SqlNull(USER_TOTAL3)),
						new SqlParameter("USER_TOTAL4", SqlNull(USER_TOTAL4)),
						new SqlParameter("USER_TOTAL5", SqlNull(USER_TOTAL5)),
						new SqlParameter("USER_TOTAL6", SqlNull(USER_TOTAL6)),
						new SqlParameter("USER_TOTAL7", SqlNull(USER_TOTAL7)),
						new SqlParameter("USER_TOTAL8", SqlNull(USER_TOTAL8)),
						new SqlParameter("USER_TOTAL9", SqlNull(USER_TOTAL9)),
						new SqlParameter("USER_TOTAL10", SqlNull(USER_TOTAL10)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F198_USER_DEFINED_TOTALS_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						RECORD_ID = Reader["RECORD_ID"].ToString();
						UDT_KEY = Reader["UDT_KEY"].ToString();
						USER_TOTAL1 = ConvertDEC(Reader["USER_TOTAL1"]);
						USER_TOTAL2 = ConvertDEC(Reader["USER_TOTAL2"]);
						USER_TOTAL3 = ConvertDEC(Reader["USER_TOTAL3"]);
						USER_TOTAL4 = ConvertDEC(Reader["USER_TOTAL4"]);
						USER_TOTAL5 = ConvertDEC(Reader["USER_TOTAL5"]);
						USER_TOTAL6 = ConvertDEC(Reader["USER_TOTAL6"]);
						USER_TOTAL7 = ConvertDEC(Reader["USER_TOTAL7"]);
						USER_TOTAL8 = ConvertDEC(Reader["USER_TOTAL8"]);
						USER_TOTAL9 = ConvertDEC(Reader["USER_TOTAL9"]);
						USER_TOTAL10 = ConvertDEC(Reader["USER_TOTAL10"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalRecord_id = Reader["RECORD_ID"].ToString();
						_originalUdt_key = Reader["UDT_KEY"].ToString();
						_originalUser_total1 = ConvertDEC(Reader["USER_TOTAL1"]);
						_originalUser_total2 = ConvertDEC(Reader["USER_TOTAL2"]);
						_originalUser_total3 = ConvertDEC(Reader["USER_TOTAL3"]);
						_originalUser_total4 = ConvertDEC(Reader["USER_TOTAL4"]);
						_originalUser_total5 = ConvertDEC(Reader["USER_TOTAL5"]);
						_originalUser_total6 = ConvertDEC(Reader["USER_TOTAL6"]);
						_originalUser_total7 = ConvertDEC(Reader["USER_TOTAL7"]);
						_originalUser_total8 = ConvertDEC(Reader["USER_TOTAL8"]);
						_originalUser_total9 = ConvertDEC(Reader["USER_TOTAL9"]);
						_originalUser_total10 = ConvertDEC(Reader["USER_TOTAL10"]);
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