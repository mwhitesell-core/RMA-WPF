using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class Renaissance_Security : BaseTable
    {
        #region Retrieve

        public ObservableCollection<Renaissance_Security> Collection( string user_name,
															string pswd,
															string security_class,
															DateTime? pswd_expiry_datemin,
															DateTime? pswd_expiry_datemax,
															int? pswd_durationmin,
															int? pswd_durationmax,
															string email_address,
															DateTime? not_chg_beforemin,
															DateTime? not_chg_beforemax,
															int? acc_attemptsmin,
															int? acc_attemptsmax,
															DateTime? acc_lck_outmin,
															DateTime? acc_lck_outmax,
															string checksum_value,
                                                            string sortcolumn,
                                                            string sortdirection,
                                                            bool replaceSearch,
                                                            int skip)
        {
            	var parameters = new SqlParameter[]
				{
					new SqlParameter("User_Name",user_name),
					new SqlParameter("Pswd",pswd),
					new SqlParameter("Security_Class",security_class),
					new SqlParameter("fromPswd_Expiry_Date", ConvertDATE(pswd_expiry_datemin, true)),
					new SqlParameter("toPswd_Expiry_Date", ConvertDATE(pswd_expiry_datemax,false)),
					new SqlParameter("minPswd_Duration",pswd_durationmin),
					new SqlParameter("maxPswd_Duration",pswd_durationmax),
					new SqlParameter("Email_Address",email_address),
					new SqlParameter("fromNot_Chg_Before", ConvertDATE(not_chg_beforemin, true)),
					new SqlParameter("toNot_Chg_Before", ConvertDATE(not_chg_beforemax,false)),
					new SqlParameter("minAcc_Attempts",acc_attemptsmin),
					new SqlParameter("maxAcc_Attempts",acc_attemptsmax),
					new SqlParameter("fromAcc_Lck_Out", ConvertDATE(acc_lck_outmin, true)),
					new SqlParameter("toAcc_Lck_Out", ConvertDATE(acc_lck_outmax,false)),
					new SqlParameter("Checksum_Value",checksum_value),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_Renaissance_Security_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<Renaissance_Security>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_Renaissance_Security_Search]", parameters);
            var collection = new ObservableCollection<Renaissance_Security>();

            while (Reader.Read())
            {
                collection.Add(new Renaissance_Security
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					User_Name = Convert.ToInt32(Reader["User_Name"]),
					Pswd = Reader["Pswd"].ToString(),
					Security_Class = Reader["Security_Class"].ToString(),
					Pswd_Expiry_Date = ConvertDATETIME(Reader["Pswd_Expiry_Date"]),
					Pswd_Duration = ConvertINT(Reader["Pswd_Duration"]),
					Email_Address = Reader["Email_Address"].ToString(),
					Not_Chg_Before = ConvertDATETIME(Reader["Not_Chg_Before"]),
					Acc_Attempts = ConvertINT(Reader["Acc_Attempts"]),
					Acc_Lck_Out = ConvertDATETIME(Reader["Acc_Lck_Out"]),
					Checksum_Value = Reader["Checksum_Value"].ToString(),

					_originalUser_name = Convert.ToInt32(Reader["User_Name"]),
					_originalPswd = Reader["Pswd"].ToString(),
					_originalSecurity_class = Reader["Security_Class"].ToString(),
					_originalPswd_expiry_date = ConvertDATETIME(Reader["Pswd_Expiry_Date"]),
					_originalPswd_duration = ConvertINT(Reader["Pswd_Duration"]),
					_originalEmail_address = Reader["Email_Address"].ToString(),
					_originalNot_chg_before = ConvertDATETIME(Reader["Not_Chg_Before"]),
					_originalAcc_attempts = ConvertINT(Reader["Acc_Attempts"]),
					_originalAcc_lck_out = ConvertDATETIME(Reader["Acc_Lck_Out"]),
					_originalChecksum_value = Reader["Checksum_Value"].ToString(),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public Renaissance_Security Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<Renaissance_Security> Collection(ObservableCollection<Renaissance_Security>
                                                               renaissanceSecurity = null)
        {
            if (IsSameSearch() && renaissanceSecurity != null)
            {
                return renaissanceSecurity;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<Renaissance_Security>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("User_Name",WhereUser_name),
					new SqlParameter("Pswd",WherePswd),
					new SqlParameter("Security_Class",WhereSecurity_class),
					new SqlParameter("Pswd_Expiry_Date",WherePswd_expiry_date),
					new SqlParameter("Pswd_Duration",WherePswd_duration),
					new SqlParameter("Email_Address",WhereEmail_address),
					new SqlParameter("Not_Chg_Before",WhereNot_chg_before),
					new SqlParameter("Acc_Attempts",WhereAcc_attempts),
					new SqlParameter("Acc_Lck_Out",WhereAcc_lck_out),
					new SqlParameter("Checksum_Value",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_Renaissance_Security_Match]", parameters);
            var collection = new ObservableCollection<Renaissance_Security>();

            while (Reader.Read())
            {
                collection.Add(new Renaissance_Security
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					User_Name = Convert.ToInt32(Reader["User_Name"]),
					Pswd = Reader["Pswd"].ToString(),
					Security_Class = Reader["Security_Class"].ToString(),
					Pswd_Expiry_Date = ConvertDATETIME(Reader["Pswd_Expiry_Date"]),
					Pswd_Duration = ConvertINT(Reader["Pswd_Duration"]),
					Email_Address = Reader["Email_Address"].ToString(),
					Not_Chg_Before = ConvertDATETIME(Reader["Not_Chg_Before"]),
					Acc_Attempts = ConvertINT(Reader["Acc_Attempts"]),
					Acc_Lck_Out = ConvertDATETIME(Reader["Acc_Lck_Out"]),
					Checksum_Value = Reader["Checksum_Value"].ToString(),

					_whereUser_name = WhereUser_name,
					_wherePswd = WherePswd,
					_whereSecurity_class = WhereSecurity_class,
					_wherePswd_expiry_date = WherePswd_expiry_date,
					_wherePswd_duration = WherePswd_duration,
					_whereEmail_address = WhereEmail_address,
					_whereNot_chg_before = WhereNot_chg_before,
					_whereAcc_attempts = WhereAcc_attempts,
					_whereAcc_lck_out = WhereAcc_lck_out,
					_whereChecksum_value = WhereChecksum_value,

					_originalUser_name = Convert.ToInt32(Reader["User_Name"]),
					_originalPswd = Reader["Pswd"].ToString(),
					_originalSecurity_class = Reader["Security_Class"].ToString(),
					_originalPswd_expiry_date = ConvertDATETIME(Reader["Pswd_Expiry_Date"]),
					_originalPswd_duration = ConvertINT(Reader["Pswd_Duration"]),
					_originalEmail_address = Reader["Email_Address"].ToString(),
					_originalNot_chg_before = ConvertDATETIME(Reader["Not_Chg_Before"]),
					_originalAcc_attempts = ConvertINT(Reader["Acc_Attempts"]),
					_originalAcc_lck_out = ConvertDATETIME(Reader["Acc_Lck_Out"]),
					_originalChecksum_value = Reader["Checksum_Value"].ToString(),

                    RecordState = State.UnChanged
                });
            }

					_whereUser_name = WhereUser_name;
					_wherePswd = WherePswd;
					_whereSecurity_class = WhereSecurity_class;
					_wherePswd_expiry_date = WherePswd_expiry_date;
					_wherePswd_duration = WherePswd_duration;
					_whereEmail_address = WhereEmail_address;
					_whereNot_chg_before = WhereNot_chg_before;
					_whereAcc_attempts = WhereAcc_attempts;
					_whereAcc_lck_out = WhereAcc_lck_out;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereUser_name == null 
				&& WherePswd == null 
				&& WhereSecurity_class == null 
				&& WherePswd_expiry_date == null 
				&& WherePswd_duration == null 
				&& WhereEmail_address == null 
				&& WhereNot_chg_before == null 
				&& WhereAcc_attempts == null 
				&& WhereAcc_lck_out == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereUser_name ==  _whereUser_name
				&& WherePswd ==  _wherePswd
				&& WhereSecurity_class ==  _whereSecurity_class
				&& WherePswd_expiry_date ==  _wherePswd_expiry_date
				&& WherePswd_duration ==  _wherePswd_duration
				&& WhereEmail_address ==  _whereEmail_address
				&& WhereNot_chg_before ==  _whereNot_chg_before
				&& WhereAcc_attempts ==  _whereAcc_attempts
				&& WhereAcc_lck_out ==  _whereAcc_lck_out
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereUser_name = null; 
			WherePswd = null; 
			WhereSecurity_class = null; 
			WherePswd_expiry_date = null; 
			WherePswd_duration = null; 
			WhereEmail_address = null; 
			WhereNot_chg_before = null; 
			WhereAcc_attempts = null; 
			WhereAcc_lck_out = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private int _User_Name;
		private string _Pswd;
		private string _Security_Class;
		private DateTime? _Pswd_Expiry_Date;
		private int? _Pswd_Duration;
		private string _Email_Address;
		private DateTime? _Not_Chg_Before;
		private int? _Acc_Attempts;
		private DateTime? _Acc_Lck_Out;
		private string _Checksum_Value;

		public int User_Name
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
		public string Pswd
		{
			get { return _Pswd; }
			set
			{
				if (_Pswd != value)
				{
					_Pswd = value;
					ChangeState();
				}
			}
		}
		public string Security_Class
		{
			get { return _Security_Class; }
			set
			{
				if (_Security_Class != value)
				{
					_Security_Class = value;
					ChangeState();
				}
			}
		}
		public DateTime? Pswd_Expiry_Date
		{
			get { return _Pswd_Expiry_Date; }
			set
			{
				if (_Pswd_Expiry_Date != value)
				{
					_Pswd_Expiry_Date = value;
					ChangeState();
				}
			}
		}
		public int? Pswd_Duration
		{
			get { return _Pswd_Duration; }
			set
			{
				if (_Pswd_Duration != value)
				{
					_Pswd_Duration = value;
					ChangeState();
				}
			}
		}
		public string Email_Address
		{
			get { return _Email_Address; }
			set
			{
				if (_Email_Address != value)
				{
					_Email_Address = value;
					ChangeState();
				}
			}
		}
		public DateTime? Not_Chg_Before
		{
			get { return _Not_Chg_Before; }
			set
			{
				if (_Not_Chg_Before != value)
				{
					_Not_Chg_Before = value;
					ChangeState();
				}
			}
		}
		public int? Acc_Attempts
		{
			get { return _Acc_Attempts; }
			set
			{
				if (_Acc_Attempts != value)
				{
					_Acc_Attempts = value;
					ChangeState();
				}
			}
		}
		public DateTime? Acc_Lck_Out
		{
			get { return _Acc_Lck_Out; }
			set
			{
				if (_Acc_Lck_Out != value)
				{
					_Acc_Lck_Out = value;
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

		public string WhereUser_name { get; set; }
		private string _whereUser_name;
		public string WherePswd { get; set; }
		private string _wherePswd;
		public string WhereSecurity_class { get; set; }
		private string _whereSecurity_class;
		public DateTime? WherePswd_expiry_date { get; set; }
		private DateTime? _wherePswd_expiry_date;
		public int? WherePswd_duration { get; set; }
		private int? _wherePswd_duration;
		public string WhereEmail_address { get; set; }
		private string _whereEmail_address;
		public DateTime? WhereNot_chg_before { get; set; }
		private DateTime? _whereNot_chg_before;
		public int? WhereAcc_attempts { get; set; }
		private int? _whereAcc_attempts;
		public DateTime? WhereAcc_lck_out { get; set; }
		private DateTime? _whereAcc_lck_out;
		public string WhereChecksum_value { get; set; }
		private string _whereChecksum_value;


        #endregion

        #region Original

		private int _originalUser_name;
		private string _originalPswd;
		private string _originalSecurity_class;
		private DateTime? _originalPswd_expiry_date;
		private int? _originalPswd_duration;
		private string _originalEmail_address;
		private DateTime? _originalNot_chg_before;
		private int? _originalAcc_attempts;
		private DateTime? _originalAcc_lck_out;
		private string _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			User_Name = _originalUser_name;
			Pswd = _originalPswd;
			Security_Class = _originalSecurity_class;
			Pswd_Expiry_Date = _originalPswd_expiry_date;
			Pswd_Duration = _originalPswd_duration;
			Email_Address = _originalEmail_address;
			Not_Chg_Before = _originalNot_chg_before;
			Acc_Attempts = _originalAcc_attempts;
			Acc_Lck_Out = _originalAcc_lck_out;
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
					new SqlParameter("User_Name",User_Name)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_Renaissance_Security_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_Renaissance_Security_Purge]");
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
						new SqlParameter("Pswd", SqlNull(Pswd)),
						new SqlParameter("Security_Class", SqlNull(Security_Class)),
						new SqlParameter("Pswd_Expiry_Date", SqlNull(Pswd_Expiry_Date)),
						new SqlParameter("Pswd_Duration", SqlNull(Pswd_Duration)),
						new SqlParameter("Email_Address", SqlNull(Email_Address)),
						new SqlParameter("Not_Chg_Before", SqlNull(Not_Chg_Before)),
						new SqlParameter("Acc_Attempts", SqlNull(Acc_Attempts)),
						new SqlParameter("Acc_Lck_Out", SqlNull(Acc_Lck_Out))
					};
					Reader = CoreReader("[INDEXED].[sp_Renaissance_Security_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						User_Name = Convert.ToInt32(Reader["User_Name"]);
						Pswd = Reader["Pswd"].ToString();
						Security_Class = Reader["Security_Class"].ToString();
						Pswd_Expiry_Date = ConvertDATETIME(Reader["Pswd_Expiry_Date"]);
						Pswd_Duration = ConvertINT(Reader["Pswd_Duration"]);
						Email_Address = Reader["Email_Address"].ToString();
						Not_Chg_Before = ConvertDATETIME(Reader["Not_Chg_Before"]);
						Acc_Attempts = ConvertINT(Reader["Acc_Attempts"]);
						Acc_Lck_Out = ConvertDATETIME(Reader["Acc_Lck_Out"]);
						Checksum_Value = Reader["Checksum_Value"].ToString();
						_originalUser_name = Convert.ToInt32(Reader["User_Name"]);
						_originalPswd = Reader["Pswd"].ToString();
						_originalSecurity_class = Reader["Security_Class"].ToString();
						_originalPswd_expiry_date = ConvertDATETIME(Reader["Pswd_Expiry_Date"]);
						_originalPswd_duration = ConvertINT(Reader["Pswd_Duration"]);
						_originalEmail_address = Reader["Email_Address"].ToString();
						_originalNot_chg_before = ConvertDATETIME(Reader["Not_Chg_Before"]);
						_originalAcc_attempts = ConvertINT(Reader["Acc_Attempts"]);
						_originalAcc_lck_out = ConvertDATETIME(Reader["Acc_Lck_Out"]);
						_originalChecksum_value = Reader["Checksum_Value"].ToString();
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("User_Name", SqlNull(User_Name)),
						new SqlParameter("Pswd", SqlNull(Pswd)),
						new SqlParameter("Security_Class", SqlNull(Security_Class)),
						new SqlParameter("Pswd_Expiry_Date", SqlNull(Pswd_Expiry_Date)),
						new SqlParameter("Pswd_Duration", SqlNull(Pswd_Duration)),
						new SqlParameter("Email_Address", SqlNull(Email_Address)),
						new SqlParameter("Not_Chg_Before", SqlNull(Not_Chg_Before)),
						new SqlParameter("Acc_Attempts", SqlNull(Acc_Attempts)),
						new SqlParameter("Acc_Lck_Out", SqlNull(Acc_Lck_Out)),
						new SqlParameter("Checksum_Value", SqlNull(Checksum_Value))
					};
					Reader = CoreReader("[INDEXED].[sp_Renaissance_Security_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						User_Name = Convert.ToInt32(Reader["User_Name"]);
						Pswd = Reader["Pswd"].ToString();
						Security_Class = Reader["Security_Class"].ToString();
						Pswd_Expiry_Date = ConvertDATETIME(Reader["Pswd_Expiry_Date"]);
						Pswd_Duration = ConvertINT(Reader["Pswd_Duration"]);
						Email_Address = Reader["Email_Address"].ToString();
						Not_Chg_Before = ConvertDATETIME(Reader["Not_Chg_Before"]);
						Acc_Attempts = ConvertINT(Reader["Acc_Attempts"]);
						Acc_Lck_Out = ConvertDATETIME(Reader["Acc_Lck_Out"]);
						Checksum_Value = Reader["Checksum_Value"].ToString();
						_originalUser_name = Convert.ToInt32(Reader["User_Name"]);
						_originalPswd = Reader["Pswd"].ToString();
						_originalSecurity_class = Reader["Security_Class"].ToString();
						_originalPswd_expiry_date = ConvertDATETIME(Reader["Pswd_Expiry_Date"]);
						_originalPswd_duration = ConvertINT(Reader["Pswd_Duration"]);
						_originalEmail_address = Reader["Email_Address"].ToString();
						_originalNot_chg_before = ConvertDATETIME(Reader["Not_Chg_Before"]);
						_originalAcc_attempts = ConvertINT(Reader["Acc_Attempts"]);
						_originalAcc_lck_out = ConvertDATETIME(Reader["Acc_Lck_Out"]);
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