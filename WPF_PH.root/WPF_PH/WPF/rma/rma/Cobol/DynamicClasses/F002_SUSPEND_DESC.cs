using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F002_SUSPEND_DESC : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F002_SUSPEND_DESC> Collection( Guid? rowid,
															string clmdtl_suspend_desc,
															string clmdtl_status,
															decimal? clmdtl_doc_ohip_nbrmin,
															decimal? clmdtl_doc_ohip_nbrmax,
															string clmdtl_accounting_nbr,
															decimal? clmdtl_line_nomin,
															decimal? clmdtl_line_nomax,
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
					new SqlParameter("CLMDTL_SUSPEND_DESC",clmdtl_suspend_desc),
					new SqlParameter("CLMDTL_STATUS",clmdtl_status),
					new SqlParameter("minCLMDTL_DOC_OHIP_NBR",clmdtl_doc_ohip_nbrmin),
					new SqlParameter("maxCLMDTL_DOC_OHIP_NBR",clmdtl_doc_ohip_nbrmax),
					new SqlParameter("CLMDTL_ACCOUNTING_NBR",clmdtl_accounting_nbr),
					new SqlParameter("minCLMDTL_LINE_NO",clmdtl_line_nomin),
					new SqlParameter("maxCLMDTL_LINE_NO",clmdtl_line_nomax),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F002_SUSPEND_DESC_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F002_SUSPEND_DESC>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F002_SUSPEND_DESC_Search]", parameters);
            var collection = new ObservableCollection<F002_SUSPEND_DESC>();

            while (Reader.Read())
            {
                collection.Add(new F002_SUSPEND_DESC
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLMDTL_SUSPEND_DESC = Reader["CLMDTL_SUSPEND_DESC"].ToString(),
					CLMDTL_STATUS = Reader["CLMDTL_STATUS"].ToString(),
					CLMDTL_DOC_OHIP_NBR = ConvertDEC(Reader["CLMDTL_DOC_OHIP_NBR"]),
					CLMDTL_ACCOUNTING_NBR = Reader["CLMDTL_ACCOUNTING_NBR"].ToString(),
					CLMDTL_LINE_NO = ConvertDEC(Reader["CLMDTL_LINE_NO"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClmdtl_suspend_desc = Reader["CLMDTL_SUSPEND_DESC"].ToString(),
					_originalClmdtl_status = Reader["CLMDTL_STATUS"].ToString(),
					_originalClmdtl_doc_ohip_nbr = ConvertDEC(Reader["CLMDTL_DOC_OHIP_NBR"]),
					_originalClmdtl_accounting_nbr = Reader["CLMDTL_ACCOUNTING_NBR"].ToString(),
					_originalClmdtl_line_no = ConvertDEC(Reader["CLMDTL_LINE_NO"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F002_SUSPEND_DESC Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F002_SUSPEND_DESC> Collection(ObservableCollection<F002_SUSPEND_DESC>
                                                               f002SuspendDesc = null)
        {
            if (IsSameSearch() && f002SuspendDesc != null)
            {
                return f002SuspendDesc;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F002_SUSPEND_DESC>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("CLMDTL_SUSPEND_DESC",WhereClmdtl_suspend_desc),
					new SqlParameter("CLMDTL_STATUS",WhereClmdtl_status),
					new SqlParameter("CLMDTL_DOC_OHIP_NBR",WhereClmdtl_doc_ohip_nbr),
					new SqlParameter("CLMDTL_ACCOUNTING_NBR",WhereClmdtl_accounting_nbr),
					new SqlParameter("CLMDTL_LINE_NO",WhereClmdtl_line_no),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F002_SUSPEND_DESC_Match]", parameters);
            var collection = new ObservableCollection<F002_SUSPEND_DESC>();

            while (Reader.Read())
            {
                collection.Add(new F002_SUSPEND_DESC
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLMDTL_SUSPEND_DESC = Reader["CLMDTL_SUSPEND_DESC"].ToString(),
					CLMDTL_STATUS = Reader["CLMDTL_STATUS"].ToString(),
					CLMDTL_DOC_OHIP_NBR = ConvertDEC(Reader["CLMDTL_DOC_OHIP_NBR"]),
					CLMDTL_ACCOUNTING_NBR = Reader["CLMDTL_ACCOUNTING_NBR"].ToString(),
					CLMDTL_LINE_NO = ConvertDEC(Reader["CLMDTL_LINE_NO"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereClmdtl_suspend_desc = WhereClmdtl_suspend_desc,
					_whereClmdtl_status = WhereClmdtl_status,
					_whereClmdtl_doc_ohip_nbr = WhereClmdtl_doc_ohip_nbr,
					_whereClmdtl_accounting_nbr = WhereClmdtl_accounting_nbr,
					_whereClmdtl_line_no = WhereClmdtl_line_no,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClmdtl_suspend_desc = Reader["CLMDTL_SUSPEND_DESC"].ToString(),
					_originalClmdtl_status = Reader["CLMDTL_STATUS"].ToString(),
					_originalClmdtl_doc_ohip_nbr = ConvertDEC(Reader["CLMDTL_DOC_OHIP_NBR"]),
					_originalClmdtl_accounting_nbr = Reader["CLMDTL_ACCOUNTING_NBR"].ToString(),
					_originalClmdtl_line_no = ConvertDEC(Reader["CLMDTL_LINE_NO"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereClmdtl_suspend_desc = WhereClmdtl_suspend_desc;
					_whereClmdtl_status = WhereClmdtl_status;
					_whereClmdtl_doc_ohip_nbr = WhereClmdtl_doc_ohip_nbr;
					_whereClmdtl_accounting_nbr = WhereClmdtl_accounting_nbr;
					_whereClmdtl_line_no = WhereClmdtl_line_no;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereClmdtl_suspend_desc == null 
				&& WhereClmdtl_status == null 
				&& WhereClmdtl_doc_ohip_nbr == null 
				&& WhereClmdtl_accounting_nbr == null 
				&& WhereClmdtl_line_no == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereClmdtl_suspend_desc ==  _whereClmdtl_suspend_desc
				&& WhereClmdtl_status ==  _whereClmdtl_status
				&& WhereClmdtl_doc_ohip_nbr ==  _whereClmdtl_doc_ohip_nbr
				&& WhereClmdtl_accounting_nbr ==  _whereClmdtl_accounting_nbr
				&& WhereClmdtl_line_no ==  _whereClmdtl_line_no
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereClmdtl_suspend_desc = null; 
			WhereClmdtl_status = null; 
			WhereClmdtl_doc_ohip_nbr = null; 
			WhereClmdtl_accounting_nbr = null; 
			WhereClmdtl_line_no = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _CLMDTL_SUSPEND_DESC;
		private string _CLMDTL_STATUS;
		private decimal? _CLMDTL_DOC_OHIP_NBR;
		private string _CLMDTL_ACCOUNTING_NBR;
		private decimal? _CLMDTL_LINE_NO;
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
		public string CLMDTL_SUSPEND_DESC
		{
			get { return _CLMDTL_SUSPEND_DESC; }
			set
			{
				if (_CLMDTL_SUSPEND_DESC != value)
				{
					_CLMDTL_SUSPEND_DESC = value;
					ChangeState();
				}
			}
		}
		public string CLMDTL_STATUS
		{
			get { return _CLMDTL_STATUS; }
			set
			{
				if (_CLMDTL_STATUS != value)
				{
					_CLMDTL_STATUS = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMDTL_DOC_OHIP_NBR
		{
			get { return _CLMDTL_DOC_OHIP_NBR; }
			set
			{
				if (_CLMDTL_DOC_OHIP_NBR != value)
				{
					_CLMDTL_DOC_OHIP_NBR = value;
					ChangeState();
				}
			}
		}
		public string CLMDTL_ACCOUNTING_NBR
		{
			get { return _CLMDTL_ACCOUNTING_NBR; }
			set
			{
				if (_CLMDTL_ACCOUNTING_NBR != value)
				{
					_CLMDTL_ACCOUNTING_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMDTL_LINE_NO
		{
			get { return _CLMDTL_LINE_NO; }
			set
			{
				if (_CLMDTL_LINE_NO != value)
				{
					_CLMDTL_LINE_NO = value;
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
		public string WhereClmdtl_suspend_desc { get; set; }
		private string _whereClmdtl_suspend_desc;
		public string WhereClmdtl_status { get; set; }
		private string _whereClmdtl_status;
		public decimal? WhereClmdtl_doc_ohip_nbr { get; set; }
		private decimal? _whereClmdtl_doc_ohip_nbr;
		public string WhereClmdtl_accounting_nbr { get; set; }
		private string _whereClmdtl_accounting_nbr;
		public decimal? WhereClmdtl_line_no { get; set; }
		private decimal? _whereClmdtl_line_no;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalClmdtl_suspend_desc;
		private string _originalClmdtl_status;
		private decimal? _originalClmdtl_doc_ohip_nbr;
		private string _originalClmdtl_accounting_nbr;
		private decimal? _originalClmdtl_line_no;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			CLMDTL_SUSPEND_DESC = _originalClmdtl_suspend_desc;
			CLMDTL_STATUS = _originalClmdtl_status;
			CLMDTL_DOC_OHIP_NBR = _originalClmdtl_doc_ohip_nbr;
			CLMDTL_ACCOUNTING_NBR = _originalClmdtl_accounting_nbr;
			CLMDTL_LINE_NO = _originalClmdtl_line_no;
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
					new SqlParameter("CLMDTL_DOC_OHIP_NBR",CLMDTL_DOC_OHIP_NBR),
					new SqlParameter("CLMDTL_ACCOUNTING_NBR",CLMDTL_ACCOUNTING_NBR),
					new SqlParameter("CLMDTL_LINE_NO",CLMDTL_LINE_NO)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F002_SUSPEND_DESC_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F002_SUSPEND_DESC_Purge]");
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
						new SqlParameter("CLMDTL_SUSPEND_DESC", SqlNull(CLMDTL_SUSPEND_DESC)),
						new SqlParameter("CLMDTL_STATUS", SqlNull(CLMDTL_STATUS)),
						new SqlParameter("CLMDTL_DOC_OHIP_NBR", SqlNull(CLMDTL_DOC_OHIP_NBR)),
						new SqlParameter("CLMDTL_ACCOUNTING_NBR", SqlNull(CLMDTL_ACCOUNTING_NBR)),
						new SqlParameter("CLMDTL_LINE_NO", SqlNull(CLMDTL_LINE_NO)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F002_SUSPEND_DESC_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLMDTL_SUSPEND_DESC = Reader["CLMDTL_SUSPEND_DESC"].ToString();
						CLMDTL_STATUS = Reader["CLMDTL_STATUS"].ToString();
						CLMDTL_DOC_OHIP_NBR = ConvertDEC(Reader["CLMDTL_DOC_OHIP_NBR"]);
						CLMDTL_ACCOUNTING_NBR = Reader["CLMDTL_ACCOUNTING_NBR"].ToString();
						CLMDTL_LINE_NO = ConvertDEC(Reader["CLMDTL_LINE_NO"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClmdtl_suspend_desc = Reader["CLMDTL_SUSPEND_DESC"].ToString();
						_originalClmdtl_status = Reader["CLMDTL_STATUS"].ToString();
						_originalClmdtl_doc_ohip_nbr = ConvertDEC(Reader["CLMDTL_DOC_OHIP_NBR"]);
						_originalClmdtl_accounting_nbr = Reader["CLMDTL_ACCOUNTING_NBR"].ToString();
						_originalClmdtl_line_no = ConvertDEC(Reader["CLMDTL_LINE_NO"]);
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("CLMDTL_SUSPEND_DESC", SqlNull(CLMDTL_SUSPEND_DESC)),
						new SqlParameter("CLMDTL_STATUS", SqlNull(CLMDTL_STATUS)),
						new SqlParameter("CLMDTL_DOC_OHIP_NBR", SqlNull(CLMDTL_DOC_OHIP_NBR)),
						new SqlParameter("CLMDTL_ACCOUNTING_NBR", SqlNull(CLMDTL_ACCOUNTING_NBR)),
						new SqlParameter("CLMDTL_LINE_NO", SqlNull(CLMDTL_LINE_NO)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F002_SUSPEND_DESC_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLMDTL_SUSPEND_DESC = Reader["CLMDTL_SUSPEND_DESC"].ToString();
						CLMDTL_STATUS = Reader["CLMDTL_STATUS"].ToString();
						CLMDTL_DOC_OHIP_NBR = ConvertDEC(Reader["CLMDTL_DOC_OHIP_NBR"]);
						CLMDTL_ACCOUNTING_NBR = Reader["CLMDTL_ACCOUNTING_NBR"].ToString();
						CLMDTL_LINE_NO = ConvertDEC(Reader["CLMDTL_LINE_NO"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClmdtl_suspend_desc = Reader["CLMDTL_SUSPEND_DESC"].ToString();
						_originalClmdtl_status = Reader["CLMDTL_STATUS"].ToString();
						_originalClmdtl_doc_ohip_nbr = ConvertDEC(Reader["CLMDTL_DOC_OHIP_NBR"]);
						_originalClmdtl_accounting_nbr = Reader["CLMDTL_ACCOUNTING_NBR"].ToString();
						_originalClmdtl_line_no = ConvertDEC(Reader["CLMDTL_LINE_NO"]);
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