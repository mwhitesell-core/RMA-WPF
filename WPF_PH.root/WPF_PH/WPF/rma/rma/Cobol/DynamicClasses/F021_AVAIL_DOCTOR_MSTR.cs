using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F021_AVAIL_DOCTOR_MSTR : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F021_AVAIL_DOCTOR_MSTR> Collection( Guid? rowid,
															decimal? date_availablemin,
															decimal? date_availablemax,
															string doc_no,
															decimal? doc_dept_nomin,
															decimal? doc_dept_nomax,
															string doc_full_name,
															decimal? date_assignedmin,
															decimal? date_assignedmax,
															string doc_status,
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
					new SqlParameter("minDATE_AVAILABLE",date_availablemin),
					new SqlParameter("maxDATE_AVAILABLE",date_availablemax),
					new SqlParameter("DOC_NO",doc_no),
					new SqlParameter("minDOC_DEPT_NO",doc_dept_nomin),
					new SqlParameter("maxDOC_DEPT_NO",doc_dept_nomax),
					new SqlParameter("DOC_FULL_NAME",doc_full_name),
					new SqlParameter("minDATE_ASSIGNED",date_assignedmin),
					new SqlParameter("maxDATE_ASSIGNED",date_assignedmax),
					new SqlParameter("DOC_STATUS",doc_status),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F021_AVAIL_DOCTOR_MSTR_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F021_AVAIL_DOCTOR_MSTR>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F021_AVAIL_DOCTOR_MSTR_Search]", parameters);
            var collection = new ObservableCollection<F021_AVAIL_DOCTOR_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F021_AVAIL_DOCTOR_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DATE_AVAILABLE = ConvertDEC(Reader["DATE_AVAILABLE"]),
					DOC_NO = Reader["DOC_NO"].ToString(),
					DOC_DEPT_NO = ConvertDEC(Reader["DOC_DEPT_NO"]),
					DOC_FULL_NAME = Reader["DOC_FULL_NAME"].ToString(),
					DATE_ASSIGNED = ConvertDEC(Reader["DATE_ASSIGNED"]),
					DOC_STATUS = Reader["DOC_STATUS"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDate_available = ConvertDEC(Reader["DATE_AVAILABLE"]),
					_originalDoc_no = Reader["DOC_NO"].ToString(),
					_originalDoc_dept_no = ConvertDEC(Reader["DOC_DEPT_NO"]),
					_originalDoc_full_name = Reader["DOC_FULL_NAME"].ToString(),
					_originalDate_assigned = ConvertDEC(Reader["DATE_ASSIGNED"]),
					_originalDoc_status = Reader["DOC_STATUS"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F021_AVAIL_DOCTOR_MSTR Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F021_AVAIL_DOCTOR_MSTR> Collection(ObservableCollection<F021_AVAIL_DOCTOR_MSTR>
                                                               f021AvailDoctorMstr = null)
        {
            if (IsSameSearch() && f021AvailDoctorMstr != null)
            {
                return f021AvailDoctorMstr;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F021_AVAIL_DOCTOR_MSTR>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("DATE_AVAILABLE",WhereDate_available),
					new SqlParameter("DOC_NO",WhereDoc_no),
					new SqlParameter("DOC_DEPT_NO",WhereDoc_dept_no),
					new SqlParameter("DOC_FULL_NAME",WhereDoc_full_name),
					new SqlParameter("DATE_ASSIGNED",WhereDate_assigned),
					new SqlParameter("DOC_STATUS",WhereDoc_status),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F021_AVAIL_DOCTOR_MSTR_Match]", parameters);
            var collection = new ObservableCollection<F021_AVAIL_DOCTOR_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F021_AVAIL_DOCTOR_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DATE_AVAILABLE = ConvertDEC(Reader["DATE_AVAILABLE"]),
					DOC_NO = Reader["DOC_NO"].ToString(),
					DOC_DEPT_NO = ConvertDEC(Reader["DOC_DEPT_NO"]),
					DOC_FULL_NAME = Reader["DOC_FULL_NAME"].ToString(),
					DATE_ASSIGNED = ConvertDEC(Reader["DATE_ASSIGNED"]),
					DOC_STATUS = Reader["DOC_STATUS"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereDate_available = WhereDate_available,
					_whereDoc_no = WhereDoc_no,
					_whereDoc_dept_no = WhereDoc_dept_no,
					_whereDoc_full_name = WhereDoc_full_name,
					_whereDate_assigned = WhereDate_assigned,
					_whereDoc_status = WhereDoc_status,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDate_available = ConvertDEC(Reader["DATE_AVAILABLE"]),
					_originalDoc_no = Reader["DOC_NO"].ToString(),
					_originalDoc_dept_no = ConvertDEC(Reader["DOC_DEPT_NO"]),
					_originalDoc_full_name = Reader["DOC_FULL_NAME"].ToString(),
					_originalDate_assigned = ConvertDEC(Reader["DATE_ASSIGNED"]),
					_originalDoc_status = Reader["DOC_STATUS"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereDate_available = WhereDate_available;
					_whereDoc_no = WhereDoc_no;
					_whereDoc_dept_no = WhereDoc_dept_no;
					_whereDoc_full_name = WhereDoc_full_name;
					_whereDate_assigned = WhereDate_assigned;
					_whereDoc_status = WhereDoc_status;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereDate_available == null 
				&& WhereDoc_no == null 
				&& WhereDoc_dept_no == null 
				&& WhereDoc_full_name == null 
				&& WhereDate_assigned == null 
				&& WhereDoc_status == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereDate_available ==  _whereDate_available
				&& WhereDoc_no ==  _whereDoc_no
				&& WhereDoc_dept_no ==  _whereDoc_dept_no
				&& WhereDoc_full_name ==  _whereDoc_full_name
				&& WhereDate_assigned ==  _whereDate_assigned
				&& WhereDoc_status ==  _whereDoc_status
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereDate_available = null; 
			WhereDoc_no = null; 
			WhereDoc_dept_no = null; 
			WhereDoc_full_name = null; 
			WhereDate_assigned = null; 
			WhereDoc_status = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private decimal? _DATE_AVAILABLE;
		private string _DOC_NO;
		private decimal? _DOC_DEPT_NO;
		private string _DOC_FULL_NAME;
		private decimal? _DATE_ASSIGNED;
		private string _DOC_STATUS;
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
		public decimal? DATE_AVAILABLE
		{
			get { return _DATE_AVAILABLE; }
			set
			{
				if (_DATE_AVAILABLE != value)
				{
					_DATE_AVAILABLE = value;
					ChangeState();
				}
			}
		}
		public string DOC_NO
		{
			get { return _DOC_NO; }
			set
			{
				if (_DOC_NO != value)
				{
					_DOC_NO = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_DEPT_NO
		{
			get { return _DOC_DEPT_NO; }
			set
			{
				if (_DOC_DEPT_NO != value)
				{
					_DOC_DEPT_NO = value;
					ChangeState();
				}
			}
		}
		public string DOC_FULL_NAME
		{
			get { return _DOC_FULL_NAME; }
			set
			{
				if (_DOC_FULL_NAME != value)
				{
					_DOC_FULL_NAME = value;
					ChangeState();
				}
			}
		}
		public decimal? DATE_ASSIGNED
		{
			get { return _DATE_ASSIGNED; }
			set
			{
				if (_DATE_ASSIGNED != value)
				{
					_DATE_ASSIGNED = value;
					ChangeState();
				}
			}
		}
		public string DOC_STATUS
		{
			get { return _DOC_STATUS; }
			set
			{
				if (_DOC_STATUS != value)
				{
					_DOC_STATUS = value;
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
		public decimal? WhereDate_available { get; set; }
		private decimal? _whereDate_available;
		public string WhereDoc_no { get; set; }
		private string _whereDoc_no;
		public decimal? WhereDoc_dept_no { get; set; }
		private decimal? _whereDoc_dept_no;
		public string WhereDoc_full_name { get; set; }
		private string _whereDoc_full_name;
		public decimal? WhereDate_assigned { get; set; }
		private decimal? _whereDate_assigned;
		public string WhereDoc_status { get; set; }
		private string _whereDoc_status;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private decimal? _originalDate_available;
		private string _originalDoc_no;
		private decimal? _originalDoc_dept_no;
		private string _originalDoc_full_name;
		private decimal? _originalDate_assigned;
		private string _originalDoc_status;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			DATE_AVAILABLE = _originalDate_available;
			DOC_NO = _originalDoc_no;
			DOC_DEPT_NO = _originalDoc_dept_no;
			DOC_FULL_NAME = _originalDoc_full_name;
			DATE_ASSIGNED = _originalDate_assigned;
			DOC_STATUS = _originalDoc_status;
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
					new SqlParameter("DATE_AVAILABLE",DATE_AVAILABLE),
					new SqlParameter("DOC_NO",DOC_NO)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F021_AVAIL_DOCTOR_MSTR_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F021_AVAIL_DOCTOR_MSTR_Purge]");
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
						new SqlParameter("DATE_AVAILABLE", SqlNull(DATE_AVAILABLE)),
						new SqlParameter("DOC_NO", SqlNull(DOC_NO)),
						new SqlParameter("DOC_DEPT_NO", SqlNull(DOC_DEPT_NO)),
						new SqlParameter("DOC_FULL_NAME", SqlNull(DOC_FULL_NAME)),
						new SqlParameter("DATE_ASSIGNED", SqlNull(DATE_ASSIGNED)),
						new SqlParameter("DOC_STATUS", SqlNull(DOC_STATUS)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F021_AVAIL_DOCTOR_MSTR_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DATE_AVAILABLE = ConvertDEC(Reader["DATE_AVAILABLE"]);
						DOC_NO = Reader["DOC_NO"].ToString();
						DOC_DEPT_NO = ConvertDEC(Reader["DOC_DEPT_NO"]);
						DOC_FULL_NAME = Reader["DOC_FULL_NAME"].ToString();
						DATE_ASSIGNED = ConvertDEC(Reader["DATE_ASSIGNED"]);
						DOC_STATUS = Reader["DOC_STATUS"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDate_available = ConvertDEC(Reader["DATE_AVAILABLE"]);
						_originalDoc_no = Reader["DOC_NO"].ToString();
						_originalDoc_dept_no = ConvertDEC(Reader["DOC_DEPT_NO"]);
						_originalDoc_full_name = Reader["DOC_FULL_NAME"].ToString();
						_originalDate_assigned = ConvertDEC(Reader["DATE_ASSIGNED"]);
						_originalDoc_status = Reader["DOC_STATUS"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("DATE_AVAILABLE", SqlNull(DATE_AVAILABLE)),
						new SqlParameter("DOC_NO", SqlNull(DOC_NO)),
						new SqlParameter("DOC_DEPT_NO", SqlNull(DOC_DEPT_NO)),
						new SqlParameter("DOC_FULL_NAME", SqlNull(DOC_FULL_NAME)),
						new SqlParameter("DATE_ASSIGNED", SqlNull(DATE_ASSIGNED)),
						new SqlParameter("DOC_STATUS", SqlNull(DOC_STATUS)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F021_AVAIL_DOCTOR_MSTR_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DATE_AVAILABLE = ConvertDEC(Reader["DATE_AVAILABLE"]);
						DOC_NO = Reader["DOC_NO"].ToString();
						DOC_DEPT_NO = ConvertDEC(Reader["DOC_DEPT_NO"]);
						DOC_FULL_NAME = Reader["DOC_FULL_NAME"].ToString();
						DATE_ASSIGNED = ConvertDEC(Reader["DATE_ASSIGNED"]);
						DOC_STATUS = Reader["DOC_STATUS"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDate_available = ConvertDEC(Reader["DATE_AVAILABLE"]);
						_originalDoc_no = Reader["DOC_NO"].ToString();
						_originalDoc_dept_no = ConvertDEC(Reader["DOC_DEPT_NO"]);
						_originalDoc_full_name = Reader["DOC_FULL_NAME"].ToString();
						_originalDate_assigned = ConvertDEC(Reader["DATE_ASSIGNED"]);
						_originalDoc_status = Reader["DOC_STATUS"].ToString();
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