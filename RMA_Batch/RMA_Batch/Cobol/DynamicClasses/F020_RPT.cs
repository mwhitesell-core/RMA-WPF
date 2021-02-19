using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F020_RPT : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F020_RPT> Collection( Guid? rowid,
															string doc_nbr,
															decimal? report_idmin,
															decimal? report_idmax,
															string report_flag,
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
					new SqlParameter("DOC_NBR",doc_nbr),
					new SqlParameter("minREPORT_ID",report_idmin),
					new SqlParameter("maxREPORT_ID",report_idmax),
					new SqlParameter("REPORT_FLAG",report_flag),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F020_RPT_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F020_RPT>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F020_RPT_Search]", parameters);
            var collection = new ObservableCollection<F020_RPT>();

            while (Reader.Read())
            {
                collection.Add(new F020_RPT
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					REPORT_ID = ConvertDEC(Reader["REPORT_ID"]),
					REPORT_FLAG = Reader["REPORT_FLAG"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalReport_id = ConvertDEC(Reader["REPORT_ID"]),
					_originalReport_flag = Reader["REPORT_FLAG"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F020_RPT Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F020_RPT> Collection(ObservableCollection<F020_RPT>
                                                               f020Rpt = null)
        {
            if (IsSameSearch() && f020Rpt != null)
            {
                return f020Rpt;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F020_RPT>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("DOC_NBR",WhereDoc_nbr),
					new SqlParameter("REPORT_ID",WhereReport_id),
					new SqlParameter("REPORT_FLAG",WhereReport_flag),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F020_RPT_Match]", parameters);
            var collection = new ObservableCollection<F020_RPT>();

            while (Reader.Read())
            {
                collection.Add(new F020_RPT
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					REPORT_ID = ConvertDEC(Reader["REPORT_ID"]),
					REPORT_FLAG = Reader["REPORT_FLAG"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereDoc_nbr = WhereDoc_nbr,
					_whereReport_id = WhereReport_id,
					_whereReport_flag = WhereReport_flag,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalReport_id = ConvertDEC(Reader["REPORT_ID"]),
					_originalReport_flag = Reader["REPORT_FLAG"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereDoc_nbr = WhereDoc_nbr;
					_whereReport_id = WhereReport_id;
					_whereReport_flag = WhereReport_flag;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereDoc_nbr == null 
				&& WhereReport_id == null 
				&& WhereReport_flag == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereDoc_nbr ==  _whereDoc_nbr
				&& WhereReport_id ==  _whereReport_id
				&& WhereReport_flag ==  _whereReport_flag
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereDoc_nbr = null; 
			WhereReport_id = null; 
			WhereReport_flag = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _DOC_NBR;
		private decimal? _REPORT_ID;
		private string _REPORT_FLAG;
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
		public string REPORT_FLAG
		{
			get { return _REPORT_FLAG; }
			set
			{
				if (_REPORT_FLAG != value)
				{
					_REPORT_FLAG = value;
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
		public string WhereDoc_nbr { get; set; }
		private string _whereDoc_nbr;
		public decimal? WhereReport_id { get; set; }
		private decimal? _whereReport_id;
		public string WhereReport_flag { get; set; }
		private string _whereReport_flag;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalDoc_nbr;
		private decimal? _originalReport_id;
		private string _originalReport_flag;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			DOC_NBR = _originalDoc_nbr;
			REPORT_ID = _originalReport_id;
			REPORT_FLAG = _originalReport_flag;
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
					new SqlParameter("DOC_NBR",DOC_NBR),
					new SqlParameter("REPORT_ID",REPORT_ID)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F020_RPT_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F020_RPT_Purge]");
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
						new SqlParameter("DOC_NBR", SqlNull(DOC_NBR)),
						new SqlParameter("REPORT_ID", SqlNull(REPORT_ID)),
						new SqlParameter("REPORT_FLAG", SqlNull(REPORT_FLAG)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F020_RPT_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOC_NBR = Reader["DOC_NBR"].ToString();
						REPORT_ID = ConvertDEC(Reader["REPORT_ID"]);
						REPORT_FLAG = Reader["REPORT_FLAG"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalReport_id = ConvertDEC(Reader["REPORT_ID"]);
						_originalReport_flag = Reader["REPORT_FLAG"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("DOC_NBR", SqlNull(DOC_NBR)),
						new SqlParameter("REPORT_ID", SqlNull(REPORT_ID)),
						new SqlParameter("REPORT_FLAG", SqlNull(REPORT_FLAG)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F020_RPT_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOC_NBR = Reader["DOC_NBR"].ToString();
						REPORT_ID = ConvertDEC(Reader["REPORT_ID"]);
						REPORT_FLAG = Reader["REPORT_FLAG"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalReport_id = ConvertDEC(Reader["REPORT_ID"]);
						_originalReport_flag = Reader["REPORT_FLAG"].ToString();
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