using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class SUBMIT_DISK_DESC : BaseTable
    {
        #region Retrieve

        public ObservableCollection<SUBMIT_DISK_DESC> Collection( Guid? rowid,
															decimal? clmdtl_doc_ohip_nbrmin,
															decimal? clmdtl_doc_ohip_nbrmax,
															string clmdtl_accounting_nbr,
															string clmdtl_suspend_desc_255,
															string filler,
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
					new SqlParameter("minCLMDTL_DOC_OHIP_NBR",clmdtl_doc_ohip_nbrmin),
					new SqlParameter("maxCLMDTL_DOC_OHIP_NBR",clmdtl_doc_ohip_nbrmax),
					new SqlParameter("CLMDTL_ACCOUNTING_NBR",clmdtl_accounting_nbr),
					new SqlParameter("CLMDTL_SUSPEND_DESC_255",clmdtl_suspend_desc_255),
					new SqlParameter("FILLER",filler),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[SEQUENTIAL].[sp_SUBMIT_DISK_DESC_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<SUBMIT_DISK_DESC>();
				}

            }

            Reader = CoreReader("[SEQUENTIAL].[sp_SUBMIT_DISK_DESC_Search]", parameters);
            var collection = new ObservableCollection<SUBMIT_DISK_DESC>();

            while (Reader.Read())
            {
                collection.Add(new SUBMIT_DISK_DESC
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLMDTL_DOC_OHIP_NBR = ConvertDEC(Reader["CLMDTL_DOC_OHIP_NBR"]),
					CLMDTL_ACCOUNTING_NBR = Reader["CLMDTL_ACCOUNTING_NBR"].ToString(),
					CLMDTL_SUSPEND_DESC_255 = Reader["CLMDTL_SUSPEND_DESC_255"].ToString(),
					FILLER = Reader["FILLER"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClmdtl_doc_ohip_nbr = ConvertDEC(Reader["CLMDTL_DOC_OHIP_NBR"]),
					_originalClmdtl_accounting_nbr = Reader["CLMDTL_ACCOUNTING_NBR"].ToString(),
					_originalClmdtl_suspend_desc_255 = Reader["CLMDTL_SUSPEND_DESC_255"].ToString(),
					_originalFiller = Reader["FILLER"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public SUBMIT_DISK_DESC Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<SUBMIT_DISK_DESC> Collection(ObservableCollection<SUBMIT_DISK_DESC>
                                                               submitDiskDesc = null)
        {
            if (IsSameSearch() && submitDiskDesc != null)
            {
                return submitDiskDesc;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<SUBMIT_DISK_DESC>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("CLMDTL_DOC_OHIP_NBR",WhereClmdtl_doc_ohip_nbr),
					new SqlParameter("CLMDTL_ACCOUNTING_NBR",WhereClmdtl_accounting_nbr),
					new SqlParameter("CLMDTL_SUSPEND_DESC_255",WhereClmdtl_suspend_desc_255),
					new SqlParameter("FILLER",WhereFiller),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[SEQUENTIAL].[sp_SUBMIT_DISK_DESC_Match]", parameters);
            var collection = new ObservableCollection<SUBMIT_DISK_DESC>();

            while (Reader.Read())
            {
                collection.Add(new SUBMIT_DISK_DESC
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLMDTL_DOC_OHIP_NBR = ConvertDEC(Reader["CLMDTL_DOC_OHIP_NBR"]),
					CLMDTL_ACCOUNTING_NBR = Reader["CLMDTL_ACCOUNTING_NBR"].ToString(),
					CLMDTL_SUSPEND_DESC_255 = Reader["CLMDTL_SUSPEND_DESC_255"].ToString(),
					FILLER = Reader["FILLER"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereClmdtl_doc_ohip_nbr = WhereClmdtl_doc_ohip_nbr,
					_whereClmdtl_accounting_nbr = WhereClmdtl_accounting_nbr,
					_whereClmdtl_suspend_desc_255 = WhereClmdtl_suspend_desc_255,
					_whereFiller = WhereFiller,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClmdtl_doc_ohip_nbr = ConvertDEC(Reader["CLMDTL_DOC_OHIP_NBR"]),
					_originalClmdtl_accounting_nbr = Reader["CLMDTL_ACCOUNTING_NBR"].ToString(),
					_originalClmdtl_suspend_desc_255 = Reader["CLMDTL_SUSPEND_DESC_255"].ToString(),
					_originalFiller = Reader["FILLER"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereClmdtl_doc_ohip_nbr = WhereClmdtl_doc_ohip_nbr;
					_whereClmdtl_accounting_nbr = WhereClmdtl_accounting_nbr;
					_whereClmdtl_suspend_desc_255 = WhereClmdtl_suspend_desc_255;
					_whereFiller = WhereFiller;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereClmdtl_doc_ohip_nbr == null 
				&& WhereClmdtl_accounting_nbr == null 
				&& WhereClmdtl_suspend_desc_255 == null 
				&& WhereFiller == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereClmdtl_doc_ohip_nbr ==  _whereClmdtl_doc_ohip_nbr
				&& WhereClmdtl_accounting_nbr ==  _whereClmdtl_accounting_nbr
				&& WhereClmdtl_suspend_desc_255 ==  _whereClmdtl_suspend_desc_255
				&& WhereFiller ==  _whereFiller
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereClmdtl_doc_ohip_nbr = null; 
			WhereClmdtl_accounting_nbr = null; 
			WhereClmdtl_suspend_desc_255 = null; 
			WhereFiller = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private decimal? _CLMDTL_DOC_OHIP_NBR;
		private string _CLMDTL_ACCOUNTING_NBR;
		private string _CLMDTL_SUSPEND_DESC_255;
		private string _FILLER;
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
		public string CLMDTL_SUSPEND_DESC_255
		{
			get { return _CLMDTL_SUSPEND_DESC_255; }
			set
			{
				if (_CLMDTL_SUSPEND_DESC_255 != value)
				{
					_CLMDTL_SUSPEND_DESC_255 = value;
					ChangeState();
				}
			}
		}
		public string FILLER
		{
			get { return _FILLER; }
			set
			{
				if (_FILLER != value)
				{
					_FILLER = value;
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
		public decimal? WhereClmdtl_doc_ohip_nbr { get; set; }
		private decimal? _whereClmdtl_doc_ohip_nbr;
		public string WhereClmdtl_accounting_nbr { get; set; }
		private string _whereClmdtl_accounting_nbr;
		public string WhereClmdtl_suspend_desc_255 { get; set; }
		private string _whereClmdtl_suspend_desc_255;
		public string WhereFiller { get; set; }
		private string _whereFiller;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private decimal? _originalClmdtl_doc_ohip_nbr;
		private string _originalClmdtl_accounting_nbr;
		private string _originalClmdtl_suspend_desc_255;
		private string _originalFiller;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			CLMDTL_DOC_OHIP_NBR = _originalClmdtl_doc_ohip_nbr;
			CLMDTL_ACCOUNTING_NBR = _originalClmdtl_accounting_nbr;
			CLMDTL_SUSPEND_DESC_255 = _originalClmdtl_suspend_desc_255;
			FILLER = _originalFiller;
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
					new SqlParameter("ROWID",ROWID)
				};
			RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_SUBMIT_DISK_DESC_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_SUBMIT_DISK_DESC_Purge]");
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
						new SqlParameter("CLMDTL_DOC_OHIP_NBR", SqlNull(CLMDTL_DOC_OHIP_NBR)),
						new SqlParameter("CLMDTL_ACCOUNTING_NBR", SqlNull(CLMDTL_ACCOUNTING_NBR)),
						new SqlParameter("CLMDTL_SUSPEND_DESC_255", SqlNull(CLMDTL_SUSPEND_DESC_255)),
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_SUBMIT_DISK_DESC_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLMDTL_DOC_OHIP_NBR = ConvertDEC(Reader["CLMDTL_DOC_OHIP_NBR"]);
						CLMDTL_ACCOUNTING_NBR = Reader["CLMDTL_ACCOUNTING_NBR"].ToString();
						CLMDTL_SUSPEND_DESC_255 = Reader["CLMDTL_SUSPEND_DESC_255"].ToString();
						FILLER = Reader["FILLER"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClmdtl_doc_ohip_nbr = ConvertDEC(Reader["CLMDTL_DOC_OHIP_NBR"]);
						_originalClmdtl_accounting_nbr = Reader["CLMDTL_ACCOUNTING_NBR"].ToString();
						_originalClmdtl_suspend_desc_255 = Reader["CLMDTL_SUSPEND_DESC_255"].ToString();
						_originalFiller = Reader["FILLER"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("CLMDTL_DOC_OHIP_NBR", SqlNull(CLMDTL_DOC_OHIP_NBR)),
						new SqlParameter("CLMDTL_ACCOUNTING_NBR", SqlNull(CLMDTL_ACCOUNTING_NBR)),
						new SqlParameter("CLMDTL_SUSPEND_DESC_255", SqlNull(CLMDTL_SUSPEND_DESC_255)),
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_SUBMIT_DISK_DESC_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLMDTL_DOC_OHIP_NBR = ConvertDEC(Reader["CLMDTL_DOC_OHIP_NBR"]);
						CLMDTL_ACCOUNTING_NBR = Reader["CLMDTL_ACCOUNTING_NBR"].ToString();
						CLMDTL_SUSPEND_DESC_255 = Reader["CLMDTL_SUSPEND_DESC_255"].ToString();
						FILLER = Reader["FILLER"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClmdtl_doc_ohip_nbr = ConvertDEC(Reader["CLMDTL_DOC_OHIP_NBR"]);
						_originalClmdtl_accounting_nbr = Reader["CLMDTL_ACCOUNTING_NBR"].ToString();
						_originalClmdtl_suspend_desc_255 = Reader["CLMDTL_SUSPEND_DESC_255"].ToString();
						_originalFiller = Reader["FILLER"].ToString();
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