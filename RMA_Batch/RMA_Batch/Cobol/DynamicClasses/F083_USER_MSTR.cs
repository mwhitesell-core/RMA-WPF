using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F083_USER_MSTR : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F083_USER_MSTR> Collection( Guid? rowid,
															decimal? logon_idmin,
															decimal? logon_idmax,
															string logon_username,
															string billing_clerk_initials,
															string full_name,
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
					new SqlParameter("minLOGON_ID",logon_idmin),
					new SqlParameter("maxLOGON_ID",logon_idmax),
					new SqlParameter("LOGON_USERNAME",logon_username),
					new SqlParameter("BILLING_CLERK_INITIALS",billing_clerk_initials),
					new SqlParameter("FULL_NAME",full_name),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F083_USER_MSTR_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F083_USER_MSTR>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F083_USER_MSTR_Search]", parameters);
            var collection = new ObservableCollection<F083_USER_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F083_USER_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					LOGON_ID = ConvertDEC(Reader["LOGON_ID"]),
					LOGON_USERNAME = Reader["LOGON_USERNAME"].ToString(),
					BILLING_CLERK_INITIALS = Reader["BILLING_CLERK_INITIALS"].ToString(),
					FULL_NAME = Reader["FULL_NAME"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalLogon_id = ConvertDEC(Reader["LOGON_ID"]),
					_originalLogon_username = Reader["LOGON_USERNAME"].ToString(),
					_originalclerk_initials = Reader["BILLING_CLERK_INITIALS"].ToString(),
					_originalFull_name = Reader["FULL_NAME"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F083_USER_MSTR Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F083_USER_MSTR> Collection(ObservableCollection<F083_USER_MSTR>
                                                               f083UserMstr = null)
        {
            if (IsSameSearch() && f083UserMstr != null)
            {
                return f083UserMstr;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F083_USER_MSTR>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("LOGON_ID",WhereLogon_id),
					new SqlParameter("LOGON_USERNAME",WhereLogon_username),
					new SqlParameter("BILLING_CLERK_INITIALS",Whereclerk_initials),
					new SqlParameter("FULL_NAME",WhereFull_name),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F083_USER_MSTR_Match]", parameters);
            var collection = new ObservableCollection<F083_USER_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F083_USER_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					LOGON_ID = ConvertDEC(Reader["LOGON_ID"]),
					LOGON_USERNAME = Reader["LOGON_USERNAME"].ToString(),
					BILLING_CLERK_INITIALS = Reader["BILLING_CLERK_INITIALS"].ToString(),
					FULL_NAME = Reader["FULL_NAME"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereLogon_id = WhereLogon_id,
					_whereLogon_username = WhereLogon_username,
					_whereclerk_initials = Whereclerk_initials,
					_whereFull_name = WhereFull_name,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalLogon_id = ConvertDEC(Reader["LOGON_ID"]),
					_originalLogon_username = Reader["LOGON_USERNAME"].ToString(),
					_originalclerk_initials = Reader["BILLING_CLERK_INITIALS"].ToString(),
					_originalFull_name = Reader["FULL_NAME"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereLogon_id = WhereLogon_id;
					_whereLogon_username = WhereLogon_username;
					_whereclerk_initials = Whereclerk_initials;
					_whereFull_name = WhereFull_name;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereLogon_id == null 
				&& WhereLogon_username == null 
				&& Whereclerk_initials == null 
				&& WhereFull_name == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereLogon_id ==  _whereLogon_id
				&& WhereLogon_username ==  _whereLogon_username
				&& Whereclerk_initials ==  _whereclerk_initials
				&& WhereFull_name ==  _whereFull_name
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereLogon_id = null; 
			WhereLogon_username = null; 
			Whereclerk_initials = null; 
			WhereFull_name = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private decimal? _LOGON_ID;
		private string _LOGON_USERNAME;
		private string _BILLING_CLERK_INITIALS;
		private string _FULL_NAME;
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
		public decimal? LOGON_ID
		{
			get { return _LOGON_ID; }
			set
			{
				if (_LOGON_ID != value)
				{
					_LOGON_ID = value;
					ChangeState();
				}
			}
		}
		public string LOGON_USERNAME
		{
			get { return _LOGON_USERNAME; }
			set
			{
				if (_LOGON_USERNAME != value)
				{
					_LOGON_USERNAME = value;
					ChangeState();
				}
			}
		}
		public string BILLING_CLERK_INITIALS
		{
			get { return _BILLING_CLERK_INITIALS; }
			set
			{
				if (_BILLING_CLERK_INITIALS != value)
				{
					_BILLING_CLERK_INITIALS = value;
					ChangeState();
				}
			}
		}
		public string FULL_NAME
		{
			get { return _FULL_NAME; }
			set
			{
				if (_FULL_NAME != value)
				{
					_FULL_NAME = value;
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
		public decimal? WhereLogon_id { get; set; }
		private decimal? _whereLogon_id;
		public string WhereLogon_username { get; set; }
		private string _whereLogon_username;
		public string Whereclerk_initials { get; set; }
		private string _whereclerk_initials;
		public string WhereFull_name { get; set; }
		private string _whereFull_name;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private decimal? _originalLogon_id;
		private string _originalLogon_username;
		private string _originalclerk_initials;
		private string _originalFull_name;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			LOGON_ID = _originalLogon_id;
			LOGON_USERNAME = _originalLogon_username;
			BILLING_CLERK_INITIALS = _originalclerk_initials;
			FULL_NAME = _originalFull_name;
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
					new SqlParameter("LOGON_ID",LOGON_ID)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F083_USER_MSTR_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F083_USER_MSTR_Purge]");
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
						new SqlParameter("LOGON_ID", SqlNull(LOGON_ID)),
						new SqlParameter("LOGON_USERNAME", SqlNull(LOGON_USERNAME)),
						new SqlParameter("BILLING_CLERK_INITIALS", SqlNull(BILLING_CLERK_INITIALS)),
						new SqlParameter("FULL_NAME", SqlNull(FULL_NAME)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F083_USER_MSTR_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						LOGON_ID = ConvertDEC(Reader["LOGON_ID"]);
						LOGON_USERNAME = Reader["LOGON_USERNAME"].ToString();
						BILLING_CLERK_INITIALS = Reader["BILLING_CLERK_INITIALS"].ToString();
						FULL_NAME = Reader["FULL_NAME"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalLogon_id = ConvertDEC(Reader["LOGON_ID"]);
						_originalLogon_username = Reader["LOGON_USERNAME"].ToString();
						_originalclerk_initials = Reader["BILLING_CLERK_INITIALS"].ToString();
						_originalFull_name = Reader["FULL_NAME"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("LOGON_ID", SqlNull(LOGON_ID)),
						new SqlParameter("LOGON_USERNAME", SqlNull(LOGON_USERNAME)),
						new SqlParameter("BILLING_CLERK_INITIALS", SqlNull(BILLING_CLERK_INITIALS)),
						new SqlParameter("FULL_NAME", SqlNull(FULL_NAME)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F083_USER_MSTR_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						LOGON_ID = ConvertDEC(Reader["LOGON_ID"]);
						LOGON_USERNAME = Reader["LOGON_USERNAME"].ToString();
						BILLING_CLERK_INITIALS = Reader["BILLING_CLERK_INITIALS"].ToString();
						FULL_NAME = Reader["FULL_NAME"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalLogon_id = ConvertDEC(Reader["LOGON_ID"]);
						_originalLogon_username = Reader["LOGON_USERNAME"].ToString();
						_originalclerk_initials = Reader["BILLING_CLERK_INITIALS"].ToString();
						_originalFull_name = Reader["FULL_NAME"].ToString();
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