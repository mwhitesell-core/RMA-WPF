using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class Renaissance_Menu_Security : BaseTable
    {
        #region Retrieve

        public ObservableCollection<Renaissance_Menu_Security> Collection( string screen,
															string role,
															decimal? screen_entrymin,
															decimal? screen_entrymax,
															decimal? screen_findmin,
															decimal? screen_findmax,
															decimal? screen_changemin,
															decimal? screen_changemax,
															decimal? screen_deletemin,
															decimal? screen_deletemax,
															string checksum_value,
                                                            string sortcolumn,
                                                            string sortdirection,
                                                            bool replaceSearch,
                                                            int skip)
        {
            	var parameters = new SqlParameter[]
				{
					new SqlParameter("Screen",screen),
					new SqlParameter("Role",role),
					new SqlParameter("minScreen_Entry",screen_entrymin),
					new SqlParameter("maxScreen_Entry",screen_entrymax),
					new SqlParameter("minScreen_Find",screen_findmin),
					new SqlParameter("maxScreen_Find",screen_findmax),
					new SqlParameter("minScreen_Change",screen_changemin),
					new SqlParameter("maxScreen_Change",screen_changemax),
					new SqlParameter("minScreen_Delete",screen_deletemin),
					new SqlParameter("maxScreen_Delete",screen_deletemax),
					new SqlParameter("Checksum_Value",checksum_value),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_Renaissance_Menu_Security_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<Renaissance_Menu_Security>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_Renaissance_Menu_Security_Search]", parameters);
            var collection = new ObservableCollection<Renaissance_Menu_Security>();

            while (Reader.Read())
            {
                collection.Add(new Renaissance_Menu_Security
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					Screen = Convert.ToInt32(Reader["Screen"]),
					Role = Reader["Role"].ToString(),
					Screen_Entry = ConvertDEC(Reader["Screen_Entry"]),
					Screen_Find = ConvertDEC(Reader["Screen_Find"]),
					Screen_Change = ConvertDEC(Reader["Screen_Change"]),
					Screen_Delete = ConvertDEC(Reader["Screen_Delete"]),
					Checksum_Value = Reader["Checksum_Value"].ToString(),

					_originalScreen = Convert.ToInt32(Reader["Screen"]),
					_originalRole = Reader["Role"].ToString(),
					_originalScreen_entry = ConvertDEC(Reader["Screen_Entry"]),
					_originalScreen_find = ConvertDEC(Reader["Screen_Find"]),
					_originalScreen_change = ConvertDEC(Reader["Screen_Change"]),
					_originalScreen_delete = ConvertDEC(Reader["Screen_Delete"]),
					_originalChecksum_value = Reader["Checksum_Value"].ToString(),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public Renaissance_Menu_Security Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<Renaissance_Menu_Security> Collection(ObservableCollection<Renaissance_Menu_Security>
                                                               renaissanceMenuSecurity = null)
        {
            if (IsSameSearch() && renaissanceMenuSecurity != null)
            {
                return renaissanceMenuSecurity;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<Renaissance_Menu_Security>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("Screen",WhereScreen),
					new SqlParameter("Role",WhereRole),
					new SqlParameter("Screen_Entry",WhereScreen_entry),
					new SqlParameter("Screen_Find",WhereScreen_find),
					new SqlParameter("Screen_Change",WhereScreen_change),
					new SqlParameter("Screen_Delete",WhereScreen_delete),
					new SqlParameter("Checksum_Value",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_Renaissance_Menu_Security_Match]", parameters);
            var collection = new ObservableCollection<Renaissance_Menu_Security>();

            while (Reader.Read())
            {
                collection.Add(new Renaissance_Menu_Security
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					Screen = Convert.ToInt32(Reader["Screen"]),
					Role = Reader["Role"].ToString(),
					Screen_Entry = ConvertDEC(Reader["Screen_Entry"]),
					Screen_Find = ConvertDEC(Reader["Screen_Find"]),
					Screen_Change = ConvertDEC(Reader["Screen_Change"]),
					Screen_Delete = ConvertDEC(Reader["Screen_Delete"]),
					Checksum_Value = Reader["Checksum_Value"].ToString(),

					_whereScreen = WhereScreen,
					_whereRole = WhereRole,
					_whereScreen_entry = WhereScreen_entry,
					_whereScreen_find = WhereScreen_find,
					_whereScreen_change = WhereScreen_change,
					_whereScreen_delete = WhereScreen_delete,
					_whereChecksum_value = WhereChecksum_value,

					_originalScreen = Convert.ToInt32(Reader["Screen"]),
					_originalRole = Reader["Role"].ToString(),
					_originalScreen_entry = ConvertDEC(Reader["Screen_Entry"]),
					_originalScreen_find = ConvertDEC(Reader["Screen_Find"]),
					_originalScreen_change = ConvertDEC(Reader["Screen_Change"]),
					_originalScreen_delete = ConvertDEC(Reader["Screen_Delete"]),
					_originalChecksum_value = Reader["Checksum_Value"].ToString(),

                    RecordState = State.UnChanged
                });
            }

					_whereScreen = WhereScreen;
					_whereRole = WhereRole;
					_whereScreen_entry = WhereScreen_entry;
					_whereScreen_find = WhereScreen_find;
					_whereScreen_change = WhereScreen_change;
					_whereScreen_delete = WhereScreen_delete;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereScreen == null 
				&& WhereRole == null 
				&& WhereScreen_entry == null 
				&& WhereScreen_find == null 
				&& WhereScreen_change == null 
				&& WhereScreen_delete == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereScreen ==  _whereScreen
				&& WhereRole ==  _whereRole
				&& WhereScreen_entry ==  _whereScreen_entry
				&& WhereScreen_find ==  _whereScreen_find
				&& WhereScreen_change ==  _whereScreen_change
				&& WhereScreen_delete ==  _whereScreen_delete
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereScreen = null; 
			WhereRole = null; 
			WhereScreen_entry = null; 
			WhereScreen_find = null; 
			WhereScreen_change = null; 
			WhereScreen_delete = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private int _Screen;
		private string _Role;
		private decimal? _Screen_Entry;
		private decimal? _Screen_Find;
		private decimal? _Screen_Change;
		private decimal? _Screen_Delete;
		private string _Checksum_Value;

		public int Screen
		{
			get { return _Screen; }
			set
			{
				if (_Screen != value)
				{
					_Screen = value;
					ChangeState();
				}
			}
		}
		public string Role
		{
			get { return _Role; }
			set
			{
				if (_Role != value)
				{
					_Role = value;
					ChangeState();
				}
			}
		}
		public decimal? Screen_Entry
		{
			get { return _Screen_Entry; }
			set
			{
				if (_Screen_Entry != value)
				{
					_Screen_Entry = value;
					ChangeState();
				}
			}
		}
		public decimal? Screen_Find
		{
			get { return _Screen_Find; }
			set
			{
				if (_Screen_Find != value)
				{
					_Screen_Find = value;
					ChangeState();
				}
			}
		}
		public decimal? Screen_Change
		{
			get { return _Screen_Change; }
			set
			{
				if (_Screen_Change != value)
				{
					_Screen_Change = value;
					ChangeState();
				}
			}
		}
		public decimal? Screen_Delete
		{
			get { return _Screen_Delete; }
			set
			{
				if (_Screen_Delete != value)
				{
					_Screen_Delete = value;
					ChangeState();
				}
			}
		}
		public string Checksum_Value
		{
			get { return _Checksum_Value; }
			set
			{
				if (_Checksum_Value != value)
				{
					_Checksum_Value = value;
					ChangeState();
				}
			}
		}


        #endregion

        #region Where

		public string WhereScreen { get; set; }
		private string _whereScreen;
		public string WhereRole { get; set; }
		private string _whereRole;
		public decimal? WhereScreen_entry { get; set; }
		private decimal? _whereScreen_entry;
		public decimal? WhereScreen_find { get; set; }
		private decimal? _whereScreen_find;
		public decimal? WhereScreen_change { get; set; }
		private decimal? _whereScreen_change;
		public decimal? WhereScreen_delete { get; set; }
		private decimal? _whereScreen_delete;
		public string WhereChecksum_value { get; set; }
		private string _whereChecksum_value;


        #endregion

        #region Original

		private int _originalScreen;
		private string _originalRole;
		private decimal? _originalScreen_entry;
		private decimal? _originalScreen_find;
		private decimal? _originalScreen_change;
		private decimal? _originalScreen_delete;
		private string _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			Screen = _originalScreen;
			Role = _originalRole;
			Screen_Entry = _originalScreen_entry;
			Screen_Find = _originalScreen_find;
			Screen_Change = _originalScreen_change;
			Screen_Delete = _originalScreen_delete;
			Checksum_Value = _originalChecksum_value;

            RecordState = State.UnChanged;

            return true;
        }


        public bool Delete()
        {
			int RowsAffected = 0;
			var parameters = new SqlParameter[]
				{
					new SqlParameter("RowCheckSum",RowCheckSum),
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_Renaissance_Menu_Security_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_Renaissance_Menu_Security_Purge]");
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
						new SqlParameter("Screen", SqlNull(Screen)),
						new SqlParameter("Role", SqlNull(Role)),
						new SqlParameter("Screen_Entry", SqlNull(Screen_Entry)),
						new SqlParameter("Screen_Find", SqlNull(Screen_Find)),
						new SqlParameter("Screen_Change", SqlNull(Screen_Change)),
						new SqlParameter("Screen_Delete", SqlNull(Screen_Delete))
					};
					Reader = CoreReader("[INDEXED].[sp_Renaissance_Menu_Security_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						Screen = Convert.ToInt32(Reader["Screen"]);
						Role = Reader["Role"].ToString();
						Screen_Entry = ConvertDEC(Reader["Screen_Entry"]);
						Screen_Find = ConvertDEC(Reader["Screen_Find"]);
						Screen_Change = ConvertDEC(Reader["Screen_Change"]);
						Screen_Delete = ConvertDEC(Reader["Screen_Delete"]);
						Checksum_Value = Reader["Checksum_Value"].ToString();
						_originalScreen = Convert.ToInt32(Reader["Screen"]);
						_originalRole = Reader["Role"].ToString();
						_originalScreen_entry = ConvertDEC(Reader["Screen_Entry"]);
						_originalScreen_find = ConvertDEC(Reader["Screen_Find"]);
						_originalScreen_change = ConvertDEC(Reader["Screen_Change"]);
						_originalScreen_delete = ConvertDEC(Reader["Screen_Delete"]);
						_originalChecksum_value = Reader["Checksum_Value"].ToString();
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("Screen", SqlNull(Screen)),
						new SqlParameter("Role", SqlNull(Role)),
						new SqlParameter("Screen_Entry", SqlNull(Screen_Entry)),
						new SqlParameter("Screen_Find", SqlNull(Screen_Find)),
						new SqlParameter("Screen_Change", SqlNull(Screen_Change)),
						new SqlParameter("Screen_Delete", SqlNull(Screen_Delete)),
						new SqlParameter("Checksum_Value", SqlNull(Checksum_Value))
					};
					Reader = CoreReader("[INDEXED].[sp_Renaissance_Menu_Security_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						Screen = Convert.ToInt32(Reader["Screen"]);
						Role = Reader["Role"].ToString();
						Screen_Entry = ConvertDEC(Reader["Screen_Entry"]);
						Screen_Find = ConvertDEC(Reader["Screen_Find"]);
						Screen_Change = ConvertDEC(Reader["Screen_Change"]);
						Screen_Delete = ConvertDEC(Reader["Screen_Delete"]);
						Checksum_Value = Reader["Checksum_Value"].ToString();
						_originalScreen = Convert.ToInt32(Reader["Screen"]);
						_originalRole = Reader["Role"].ToString();
						_originalScreen_entry = ConvertDEC(Reader["Screen_Entry"]);
						_originalScreen_find = ConvertDEC(Reader["Screen_Find"]);
						_originalScreen_change = ConvertDEC(Reader["Screen_Change"]);
						_originalScreen_delete = ConvertDEC(Reader["Screen_Delete"]);
						_originalChecksum_value = Reader["Checksum_Value"].ToString();
					}
                   
                    break;
            }
	    CloseConnection();
	     
            RecordState = State.UnChanged;
        }

        #endregion

      
    }
}