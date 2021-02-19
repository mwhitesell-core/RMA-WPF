using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F076_INSURANCE_MSTR : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F076_INSURANCE_MSTR> Collection( Guid? rowid,
															string ins_acronym,
															string ins_full_name,
															string addr_line_1,
															string addr_line_2,
															string addr_line_3,
															string addr_postal_cd,
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
					new SqlParameter("INS_ACRONYM",ins_acronym),
					new SqlParameter("INS_FULL_NAME",ins_full_name),
					new SqlParameter("ADDR_LINE_1",addr_line_1),
					new SqlParameter("ADDR_LINE_2",addr_line_2),
					new SqlParameter("ADDR_LINE_3",addr_line_3),
					new SqlParameter("ADDR_POSTAL_CD",addr_postal_cd),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F076_INSURANCE_MSTR_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F076_INSURANCE_MSTR>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F076_INSURANCE_MSTR_Search]", parameters);
            var collection = new ObservableCollection<F076_INSURANCE_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F076_INSURANCE_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					INS_ACRONYM = Reader["INS_ACRONYM"].ToString(),
					INS_FULL_NAME = Reader["INS_FULL_NAME"].ToString(),
					ADDR_LINE_1 = Reader["ADDR_LINE_1"].ToString(),
					ADDR_LINE_2 = Reader["ADDR_LINE_2"].ToString(),
					ADDR_LINE_3 = Reader["ADDR_LINE_3"].ToString(),
					ADDR_POSTAL_CD = Reader["ADDR_POSTAL_CD"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalIns_acronym = Reader["INS_ACRONYM"].ToString(),
					_originalIns_full_name = Reader["INS_FULL_NAME"].ToString(),
					_originalAddr_line_1 = Reader["ADDR_LINE_1"].ToString(),
					_originalAddr_line_2 = Reader["ADDR_LINE_2"].ToString(),
					_originalAddr_line_3 = Reader["ADDR_LINE_3"].ToString(),
					_originalAddr_postal_cd = Reader["ADDR_POSTAL_CD"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F076_INSURANCE_MSTR Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F076_INSURANCE_MSTR> Collection(ObservableCollection<F076_INSURANCE_MSTR>
                                                               f076InsuranceMstr = null)
        {
            if (IsSameSearch() && f076InsuranceMstr != null)
            {
                return f076InsuranceMstr;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F076_INSURANCE_MSTR>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("INS_ACRONYM",WhereIns_acronym),
					new SqlParameter("INS_FULL_NAME",WhereIns_full_name),
					new SqlParameter("ADDR_LINE_1",WhereAddr_line_1),
					new SqlParameter("ADDR_LINE_2",WhereAddr_line_2),
					new SqlParameter("ADDR_LINE_3",WhereAddr_line_3),
					new SqlParameter("ADDR_POSTAL_CD",WhereAddr_postal_cd),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F076_INSURANCE_MSTR_Match]", parameters);
            var collection = new ObservableCollection<F076_INSURANCE_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F076_INSURANCE_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					INS_ACRONYM = Reader["INS_ACRONYM"].ToString(),
					INS_FULL_NAME = Reader["INS_FULL_NAME"].ToString(),
					ADDR_LINE_1 = Reader["ADDR_LINE_1"].ToString(),
					ADDR_LINE_2 = Reader["ADDR_LINE_2"].ToString(),
					ADDR_LINE_3 = Reader["ADDR_LINE_3"].ToString(),
					ADDR_POSTAL_CD = Reader["ADDR_POSTAL_CD"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereIns_acronym = WhereIns_acronym,
					_whereIns_full_name = WhereIns_full_name,
					_whereAddr_line_1 = WhereAddr_line_1,
					_whereAddr_line_2 = WhereAddr_line_2,
					_whereAddr_line_3 = WhereAddr_line_3,
					_whereAddr_postal_cd = WhereAddr_postal_cd,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalIns_acronym = Reader["INS_ACRONYM"].ToString(),
					_originalIns_full_name = Reader["INS_FULL_NAME"].ToString(),
					_originalAddr_line_1 = Reader["ADDR_LINE_1"].ToString(),
					_originalAddr_line_2 = Reader["ADDR_LINE_2"].ToString(),
					_originalAddr_line_3 = Reader["ADDR_LINE_3"].ToString(),
					_originalAddr_postal_cd = Reader["ADDR_POSTAL_CD"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereIns_acronym = WhereIns_acronym;
					_whereIns_full_name = WhereIns_full_name;
					_whereAddr_line_1 = WhereAddr_line_1;
					_whereAddr_line_2 = WhereAddr_line_2;
					_whereAddr_line_3 = WhereAddr_line_3;
					_whereAddr_postal_cd = WhereAddr_postal_cd;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereIns_acronym == null 
				&& WhereIns_full_name == null 
				&& WhereAddr_line_1 == null 
				&& WhereAddr_line_2 == null 
				&& WhereAddr_line_3 == null 
				&& WhereAddr_postal_cd == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereIns_acronym ==  _whereIns_acronym
				&& WhereIns_full_name ==  _whereIns_full_name
				&& WhereAddr_line_1 ==  _whereAddr_line_1
				&& WhereAddr_line_2 ==  _whereAddr_line_2
				&& WhereAddr_line_3 ==  _whereAddr_line_3
				&& WhereAddr_postal_cd ==  _whereAddr_postal_cd
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereIns_acronym = null; 
			WhereIns_full_name = null; 
			WhereAddr_line_1 = null; 
			WhereAddr_line_2 = null; 
			WhereAddr_line_3 = null; 
			WhereAddr_postal_cd = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _INS_ACRONYM;
		private string _INS_FULL_NAME;
		private string _ADDR_LINE_1;
		private string _ADDR_LINE_2;
		private string _ADDR_LINE_3;
		private string _ADDR_POSTAL_CD;
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
		public string INS_ACRONYM
		{
			get { return _INS_ACRONYM; }
			set
			{
				if (_INS_ACRONYM != value)
				{
					_INS_ACRONYM = value;
					ChangeState();
				}
			}
		}
		public string INS_FULL_NAME
		{
			get { return _INS_FULL_NAME; }
			set
			{
				if (_INS_FULL_NAME != value)
				{
					_INS_FULL_NAME = value;
					ChangeState();
				}
			}
		}
		public string ADDR_LINE_1
		{
			get { return _ADDR_LINE_1; }
			set
			{
				if (_ADDR_LINE_1 != value)
				{
					_ADDR_LINE_1 = value;
					ChangeState();
				}
			}
		}
		public string ADDR_LINE_2
		{
			get { return _ADDR_LINE_2; }
			set
			{
				if (_ADDR_LINE_2 != value)
				{
					_ADDR_LINE_2 = value;
					ChangeState();
				}
			}
		}
		public string ADDR_LINE_3
		{
			get { return _ADDR_LINE_3; }
			set
			{
				if (_ADDR_LINE_3 != value)
				{
					_ADDR_LINE_3 = value;
					ChangeState();
				}
			}
		}
		public string ADDR_POSTAL_CD
		{
			get { return _ADDR_POSTAL_CD; }
			set
			{
				if (_ADDR_POSTAL_CD != value)
				{
					_ADDR_POSTAL_CD = value;
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
		public string WhereIns_acronym { get; set; }
		private string _whereIns_acronym;
		public string WhereIns_full_name { get; set; }
		private string _whereIns_full_name;
		public string WhereAddr_line_1 { get; set; }
		private string _whereAddr_line_1;
		public string WhereAddr_line_2 { get; set; }
		private string _whereAddr_line_2;
		public string WhereAddr_line_3 { get; set; }
		private string _whereAddr_line_3;
		public string WhereAddr_postal_cd { get; set; }
		private string _whereAddr_postal_cd;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalIns_acronym;
		private string _originalIns_full_name;
		private string _originalAddr_line_1;
		private string _originalAddr_line_2;
		private string _originalAddr_line_3;
		private string _originalAddr_postal_cd;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			INS_ACRONYM = _originalIns_acronym;
			INS_FULL_NAME = _originalIns_full_name;
			ADDR_LINE_1 = _originalAddr_line_1;
			ADDR_LINE_2 = _originalAddr_line_2;
			ADDR_LINE_3 = _originalAddr_line_3;
			ADDR_POSTAL_CD = _originalAddr_postal_cd;
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
					new SqlParameter("INS_ACRONYM",INS_ACRONYM)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F076_INSURANCE_MSTR_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F076_INSURANCE_MSTR_Purge]");
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
						new SqlParameter("INS_ACRONYM", SqlNull(INS_ACRONYM)),
						new SqlParameter("INS_FULL_NAME", SqlNull(INS_FULL_NAME)),
						new SqlParameter("ADDR_LINE_1", SqlNull(ADDR_LINE_1)),
						new SqlParameter("ADDR_LINE_2", SqlNull(ADDR_LINE_2)),
						new SqlParameter("ADDR_LINE_3", SqlNull(ADDR_LINE_3)),
						new SqlParameter("ADDR_POSTAL_CD", SqlNull(ADDR_POSTAL_CD)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F076_INSURANCE_MSTR_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						INS_ACRONYM = Reader["INS_ACRONYM"].ToString();
						INS_FULL_NAME = Reader["INS_FULL_NAME"].ToString();
						ADDR_LINE_1 = Reader["ADDR_LINE_1"].ToString();
						ADDR_LINE_2 = Reader["ADDR_LINE_2"].ToString();
						ADDR_LINE_3 = Reader["ADDR_LINE_3"].ToString();
						ADDR_POSTAL_CD = Reader["ADDR_POSTAL_CD"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalIns_acronym = Reader["INS_ACRONYM"].ToString();
						_originalIns_full_name = Reader["INS_FULL_NAME"].ToString();
						_originalAddr_line_1 = Reader["ADDR_LINE_1"].ToString();
						_originalAddr_line_2 = Reader["ADDR_LINE_2"].ToString();
						_originalAddr_line_3 = Reader["ADDR_LINE_3"].ToString();
						_originalAddr_postal_cd = Reader["ADDR_POSTAL_CD"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("INS_ACRONYM", SqlNull(INS_ACRONYM)),
						new SqlParameter("INS_FULL_NAME", SqlNull(INS_FULL_NAME)),
						new SqlParameter("ADDR_LINE_1", SqlNull(ADDR_LINE_1)),
						new SqlParameter("ADDR_LINE_2", SqlNull(ADDR_LINE_2)),
						new SqlParameter("ADDR_LINE_3", SqlNull(ADDR_LINE_3)),
						new SqlParameter("ADDR_POSTAL_CD", SqlNull(ADDR_POSTAL_CD)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F076_INSURANCE_MSTR_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						INS_ACRONYM = Reader["INS_ACRONYM"].ToString();
						INS_FULL_NAME = Reader["INS_FULL_NAME"].ToString();
						ADDR_LINE_1 = Reader["ADDR_LINE_1"].ToString();
						ADDR_LINE_2 = Reader["ADDR_LINE_2"].ToString();
						ADDR_LINE_3 = Reader["ADDR_LINE_3"].ToString();
						ADDR_POSTAL_CD = Reader["ADDR_POSTAL_CD"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalIns_acronym = Reader["INS_ACRONYM"].ToString();
						_originalIns_full_name = Reader["INS_FULL_NAME"].ToString();
						_originalAddr_line_1 = Reader["ADDR_LINE_1"].ToString();
						_originalAddr_line_2 = Reader["ADDR_LINE_2"].ToString();
						_originalAddr_line_3 = Reader["ADDR_LINE_3"].ToString();
						_originalAddr_postal_cd = Reader["ADDR_POSTAL_CD"].ToString();
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