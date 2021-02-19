using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F020_RPT_MSTR : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F020_RPT_MSTR> Collection( Guid? rowid,
															decimal? report_idmin,
															decimal? report_idmax,
															string report_short_name,
															string report_long_name,
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
					new SqlParameter("minREPORT_ID",report_idmin),
					new SqlParameter("maxREPORT_ID",report_idmax),
					new SqlParameter("REPORT_SHORT_NAME",report_short_name),
					new SqlParameter("REPORT_LONG_NAME",report_long_name),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F020_RPT_MSTR_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F020_RPT_MSTR>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F020_RPT_MSTR_Search]", parameters);
            var collection = new ObservableCollection<F020_RPT_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F020_RPT_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					REPORT_ID = ConvertDEC(Reader["REPORT_ID"]),
					REPORT_SHORT_NAME = Reader["REPORT_SHORT_NAME"].ToString(),
					REPORT_LONG_NAME = Reader["REPORT_LONG_NAME"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalReport_id = ConvertDEC(Reader["REPORT_ID"]),
					_originalReport_short_name = Reader["REPORT_SHORT_NAME"].ToString(),
					_originalReport_long_name = Reader["REPORT_LONG_NAME"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F020_RPT_MSTR Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F020_RPT_MSTR> Collection(ObservableCollection<F020_RPT_MSTR>
                                                               f020RptMstr = null)
        {
            if (IsSameSearch() && f020RptMstr != null)
            {
                return f020RptMstr;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F020_RPT_MSTR>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("REPORT_ID",WhereReport_id),
					new SqlParameter("REPORT_SHORT_NAME",WhereReport_short_name),
					new SqlParameter("REPORT_LONG_NAME",WhereReport_long_name),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F020_RPT_MSTR_Match]", parameters);
            var collection = new ObservableCollection<F020_RPT_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F020_RPT_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					REPORT_ID = ConvertDEC(Reader["REPORT_ID"]),
					REPORT_SHORT_NAME = Reader["REPORT_SHORT_NAME"].ToString(),
					REPORT_LONG_NAME = Reader["REPORT_LONG_NAME"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereReport_id = WhereReport_id,
					_whereReport_short_name = WhereReport_short_name,
					_whereReport_long_name = WhereReport_long_name,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalReport_id = ConvertDEC(Reader["REPORT_ID"]),
					_originalReport_short_name = Reader["REPORT_SHORT_NAME"].ToString(),
					_originalReport_long_name = Reader["REPORT_LONG_NAME"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereReport_id = WhereReport_id;
					_whereReport_short_name = WhereReport_short_name;
					_whereReport_long_name = WhereReport_long_name;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereReport_id == null 
				&& WhereReport_short_name == null 
				&& WhereReport_long_name == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereReport_id ==  _whereReport_id
				&& WhereReport_short_name ==  _whereReport_short_name
				&& WhereReport_long_name ==  _whereReport_long_name
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereReport_id = null; 
			WhereReport_short_name = null; 
			WhereReport_long_name = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private decimal? _REPORT_ID;
		private string _REPORT_SHORT_NAME;
		private string _REPORT_LONG_NAME;
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
		public decimal? REPORT_ID
		{
			get { return _REPORT_ID; }
			set
			{
				if (_REPORT_ID != value)
				{
					_REPORT_ID = value;
					ChangeState();
				}
			}
		}
		public string REPORT_SHORT_NAME
		{
			get { return _REPORT_SHORT_NAME; }
			set
			{
				if (_REPORT_SHORT_NAME != value)
				{
					_REPORT_SHORT_NAME = value;
					ChangeState();
				}
			}
		}
		public string REPORT_LONG_NAME
		{
			get { return _REPORT_LONG_NAME; }
			set
			{
				if (_REPORT_LONG_NAME != value)
				{
					_REPORT_LONG_NAME = value;
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
		public decimal? WhereReport_id { get; set; }
		private decimal? _whereReport_id;
		public string WhereReport_short_name { get; set; }
		private string _whereReport_short_name;
		public string WhereReport_long_name { get; set; }
		private string _whereReport_long_name;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private decimal? _originalReport_id;
		private string _originalReport_short_name;
		private string _originalReport_long_name;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			REPORT_ID = _originalReport_id;
			REPORT_SHORT_NAME = _originalReport_short_name;
			REPORT_LONG_NAME = _originalReport_long_name;
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
					new SqlParameter("REPORT_ID",REPORT_ID)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F020_RPT_MSTR_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F020_RPT_MSTR_Purge]");
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
						new SqlParameter("REPORT_ID", SqlNull(REPORT_ID)),
						new SqlParameter("REPORT_SHORT_NAME", SqlNull(REPORT_SHORT_NAME)),
						new SqlParameter("REPORT_LONG_NAME", SqlNull(REPORT_LONG_NAME)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F020_RPT_MSTR_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						REPORT_ID = ConvertDEC(Reader["REPORT_ID"]);
						REPORT_SHORT_NAME = Reader["REPORT_SHORT_NAME"].ToString();
						REPORT_LONG_NAME = Reader["REPORT_LONG_NAME"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalReport_id = ConvertDEC(Reader["REPORT_ID"]);
						_originalReport_short_name = Reader["REPORT_SHORT_NAME"].ToString();
						_originalReport_long_name = Reader["REPORT_LONG_NAME"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("REPORT_ID", SqlNull(REPORT_ID)),
						new SqlParameter("REPORT_SHORT_NAME", SqlNull(REPORT_SHORT_NAME)),
						new SqlParameter("REPORT_LONG_NAME", SqlNull(REPORT_LONG_NAME)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F020_RPT_MSTR_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						REPORT_ID = ConvertDEC(Reader["REPORT_ID"]);
						REPORT_SHORT_NAME = Reader["REPORT_SHORT_NAME"].ToString();
						REPORT_LONG_NAME = Reader["REPORT_LONG_NAME"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalReport_id = ConvertDEC(Reader["REPORT_ID"]);
						_originalReport_short_name = Reader["REPORT_SHORT_NAME"].ToString();
						_originalReport_long_name = Reader["REPORT_LONG_NAME"].ToString();
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