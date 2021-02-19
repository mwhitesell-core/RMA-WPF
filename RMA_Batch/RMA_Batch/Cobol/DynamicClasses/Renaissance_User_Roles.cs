using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class Renaissance_User_Roles : BaseTable
    {
        #region Retrieve

        public ObservableCollection<Renaissance_User_Roles> Collection( Guid? rowid,
															string user_name,
															string role_name,
															int? role_prioritymin,
															int? role_prioritymax,
															string checksum_value,
                                                            string sortcolumn,
                                                            string sortdirection,
                                                            bool replaceSearch,
                                                            int skip)
        {
            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",rowid),
					new SqlParameter("User_Name",user_name),
					new SqlParameter("Role_Name",role_name),
					new SqlParameter("minRole_Priority",role_prioritymin),
					new SqlParameter("maxRole_Priority",role_prioritymax),
					new SqlParameter("CHECKSUM_VALUE",checksum_value),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_Renaissance_User_Roles_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<Renaissance_User_Roles>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_Renaissance_User_Roles_Search]", parameters);
            var collection = new ObservableCollection<Renaissance_User_Roles>();

            while (Reader.Read())
            {
                collection.Add(new Renaissance_User_Roles
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					User_Name = Reader["User_Name"].ToString(),
					Role_Name = Reader["Role_Name"].ToString(),
					Role_Priority = ConvertINT(Reader["Role_Priority"]),
					CHECKSUM_VALUE = Reader["CHECKSUM_VALUE"].ToString(),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalUser_name = Reader["User_Name"].ToString(),
					_originalRole_name = Reader["Role_Name"].ToString(),
					_originalRole_priority = ConvertINT(Reader["Role_Priority"]),
					_originalChecksum_value = Reader["CHECKSUM_VALUE"].ToString(),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public Renaissance_User_Roles Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<Renaissance_User_Roles> Collection(ObservableCollection<Renaissance_User_Roles>
                                                               renaissanceUserRoles = null)
        {
            if (IsSameSearch() && renaissanceUserRoles != null)
            {
                return renaissanceUserRoles;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<Renaissance_User_Roles>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("User_Name",WhereUser_name),
					new SqlParameter("Role_Name",WhereRole_name),
					new SqlParameter("Role_Priority",WhereRole_priority),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_Renaissance_User_Roles_Match]", parameters);
            var collection = new ObservableCollection<Renaissance_User_Roles>();

            while (Reader.Read())
            {
                collection.Add(new Renaissance_User_Roles
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					User_Name = Reader["User_Name"].ToString(),
					Role_Name = Reader["Role_Name"].ToString(),
					Role_Priority = ConvertINT(Reader["Role_Priority"]),
					CHECKSUM_VALUE = Reader["CHECKSUM_VALUE"].ToString(),

					_whereRowid = WhereRowid,
					_whereUser_name = WhereUser_name,
					_whereRole_name = WhereRole_name,
					_whereRole_priority = WhereRole_priority,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalUser_name = Reader["User_Name"].ToString(),
					_originalRole_name = Reader["Role_Name"].ToString(),
					_originalRole_priority = ConvertINT(Reader["Role_Priority"]),
					_originalChecksum_value = Reader["CHECKSUM_VALUE"].ToString(),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereUser_name = WhereUser_name;
					_whereRole_name = WhereRole_name;
					_whereRole_priority = WhereRole_priority;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereUser_name == null 
				&& WhereRole_name == null 
				&& WhereRole_priority == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereUser_name ==  _whereUser_name
				&& WhereRole_name ==  _whereRole_name
				&& WhereRole_priority ==  _whereRole_priority
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereUser_name = null; 
			WhereRole_name = null; 
			WhereRole_priority = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _User_Name;
		private string _Role_Name;
		private int? _Role_Priority;
		private string _CHECKSUM_VALUE;

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
		public string User_Name
		{
			get { return _User_Name; }
			set
			{
				if (_User_Name != value)
				{
					_User_Name = value;
					ChangeState();
				}
			}
		}
		public string Role_Name
		{
			get { return _Role_Name; }
			set
			{
				if (_Role_Name != value)
				{
					_Role_Name = value;
					ChangeState();
				}
			}
		}
		public int? Role_Priority
		{
			get { return _Role_Priority; }
			set
			{
				if (_Role_Priority != value)
				{
					_Role_Priority = value;
					ChangeState();
				}
			}
		}
		public string CHECKSUM_VALUE
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
		public string WhereUser_name { get; set; }
		private string _whereUser_name;
		public string WhereRole_name { get; set; }
		private string _whereRole_name;
		public int? WhereRole_priority { get; set; }
		private int? _whereRole_priority;
		public string WhereChecksum_value { get; set; }
		private string _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalUser_name;
		private string _originalRole_name;
		private int? _originalRole_priority;
		private string _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			User_Name = _originalUser_name;
			Role_Name = _originalRole_name;
			Role_Priority = _originalRole_priority;
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
					new SqlParameter("User_Name",User_Name),
					new SqlParameter("Role_Name",Role_Name),
					new SqlParameter("Role_Priority",Role_Priority)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_Renaissance_User_Roles_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_Renaissance_User_Roles_Purge]");
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
						new SqlParameter("User_Name", SqlNull(User_Name)),
						new SqlParameter("Role_Name", SqlNull(Role_Name)),
						new SqlParameter("Role_Priority", SqlNull(Role_Priority))
					};
					Reader = CoreReader("[INDEXED].[sp_Renaissance_User_Roles_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						User_Name = Reader["User_Name"].ToString();
						Role_Name = Reader["Role_Name"].ToString();
						Role_Priority = ConvertINT(Reader["Role_Priority"]);
						CHECKSUM_VALUE = Reader["CHECKSUM_VALUE"].ToString();
						_originalRowid = (Guid) Reader["ROWID"];
						_originalUser_name = Reader["User_Name"].ToString();
						_originalRole_name = Reader["Role_Name"].ToString();
						_originalRole_priority = ConvertINT(Reader["Role_Priority"]);
						_originalChecksum_value = Reader["CHECKSUM_VALUE"].ToString();
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("User_Name", SqlNull(User_Name)),
						new SqlParameter("Role_Name", SqlNull(Role_Name)),
						new SqlParameter("Role_Priority", SqlNull(Role_Priority)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_Renaissance_User_Roles_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						User_Name = Reader["User_Name"].ToString();
						Role_Name = Reader["Role_Name"].ToString();
						Role_Priority = ConvertINT(Reader["Role_Priority"]);
						CHECKSUM_VALUE = Reader["CHECKSUM_VALUE"].ToString();
						_originalRowid = (Guid) Reader["ROWID"];
						_originalUser_name = Reader["User_Name"].ToString();
						_originalRole_name = Reader["Role_Name"].ToString();
						_originalRole_priority = ConvertINT(Reader["Role_Priority"]);
						_originalChecksum_value = Reader["CHECKSUM_VALUE"].ToString();
					}
                   
                    break;
            }
	    CloseConnection();
	     
            RecordState = State.UnChanged;
        }

        #endregion

      
    }
}