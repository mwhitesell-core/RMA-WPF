using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F094_MSG_MSTR : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F094_MSG_MSTR> Collection( Guid? rowid,
															string msg_sub_key_1,
															string msg_sub_key_23,
															string msg_reprint_flag,
															string msg_auto_logout,
															string msg_dtl1,
															string msg_dtl2,
															string msg_dtl3,
															string msg_dtl4,
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
					new SqlParameter("MSG_SUB_KEY_1",msg_sub_key_1),
					new SqlParameter("MSG_SUB_KEY_23",msg_sub_key_23),
					new SqlParameter("MSG_REPRINT_FLAG",msg_reprint_flag),
					new SqlParameter("MSG_AUTO_LOGOUT",msg_auto_logout),
					new SqlParameter("MSG_DTL1",msg_dtl1),
					new SqlParameter("MSG_DTL2",msg_dtl2),
					new SqlParameter("MSG_DTL3",msg_dtl3),
					new SqlParameter("MSG_DTL4",msg_dtl4),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F094_MSG_MSTR_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F094_MSG_MSTR>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F094_MSG_MSTR_Search]", parameters);
            var collection = new ObservableCollection<F094_MSG_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F094_MSG_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					MSG_SUB_KEY_1 = Reader["MSG_SUB_KEY_1"].ToString(),
					MSG_SUB_KEY_23 = Reader["MSG_SUB_KEY_23"].ToString(),
					MSG_REPRINT_FLAG = Reader["MSG_REPRINT_FLAG"].ToString(),
					MSG_AUTO_LOGOUT = Reader["MSG_AUTO_LOGOUT"].ToString(),
					MSG_DTL1 = Reader["MSG_DTL1"].ToString(),
					MSG_DTL2 = Reader["MSG_DTL2"].ToString(),
					MSG_DTL3 = Reader["MSG_DTL3"].ToString(),
					MSG_DTL4 = Reader["MSG_DTL4"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalMsg_sub_key_1 = Reader["MSG_SUB_KEY_1"].ToString(),
					_originalMsg_sub_key_23 = Reader["MSG_SUB_KEY_23"].ToString(),
					_originalMsg_reprint_flag = Reader["MSG_REPRINT_FLAG"].ToString(),
					_originalMsg_auto_logout = Reader["MSG_AUTO_LOGOUT"].ToString(),
					_originalMsg_dtl1 = Reader["MSG_DTL1"].ToString(),
					_originalMsg_dtl2 = Reader["MSG_DTL2"].ToString(),
					_originalMsg_dtl3 = Reader["MSG_DTL3"].ToString(),
					_originalMsg_dtl4 = Reader["MSG_DTL4"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F094_MSG_MSTR Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F094_MSG_MSTR> Collection(ObservableCollection<F094_MSG_MSTR>
                                                               f094MsgMstr = null)
        {
            if (IsSameSearch() && f094MsgMstr != null)
            {
                return f094MsgMstr;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F094_MSG_MSTR>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("MSG_SUB_KEY_1",WhereMsg_sub_key_1),
					new SqlParameter("MSG_SUB_KEY_23",WhereMsg_sub_key_23),
					new SqlParameter("MSG_REPRINT_FLAG",WhereMsg_reprint_flag),
					new SqlParameter("MSG_AUTO_LOGOUT",WhereMsg_auto_logout),
					new SqlParameter("MSG_DTL1",WhereMsg_dtl1),
					new SqlParameter("MSG_DTL2",WhereMsg_dtl2),
					new SqlParameter("MSG_DTL3",WhereMsg_dtl3),
					new SqlParameter("MSG_DTL4",WhereMsg_dtl4),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F094_MSG_MSTR_Match]", parameters);
            var collection = new ObservableCollection<F094_MSG_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F094_MSG_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					MSG_SUB_KEY_1 = Reader["MSG_SUB_KEY_1"].ToString(),
					MSG_SUB_KEY_23 = Reader["MSG_SUB_KEY_23"].ToString(),
					MSG_REPRINT_FLAG = Reader["MSG_REPRINT_FLAG"].ToString(),
					MSG_AUTO_LOGOUT = Reader["MSG_AUTO_LOGOUT"].ToString(),
					MSG_DTL1 = Reader["MSG_DTL1"].ToString(),
					MSG_DTL2 = Reader["MSG_DTL2"].ToString(),
					MSG_DTL3 = Reader["MSG_DTL3"].ToString(),
					MSG_DTL4 = Reader["MSG_DTL4"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereMsg_sub_key_1 = WhereMsg_sub_key_1,
					_whereMsg_sub_key_23 = WhereMsg_sub_key_23,
					_whereMsg_reprint_flag = WhereMsg_reprint_flag,
					_whereMsg_auto_logout = WhereMsg_auto_logout,
					_whereMsg_dtl1 = WhereMsg_dtl1,
					_whereMsg_dtl2 = WhereMsg_dtl2,
					_whereMsg_dtl3 = WhereMsg_dtl3,
					_whereMsg_dtl4 = WhereMsg_dtl4,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalMsg_sub_key_1 = Reader["MSG_SUB_KEY_1"].ToString(),
					_originalMsg_sub_key_23 = Reader["MSG_SUB_KEY_23"].ToString(),
					_originalMsg_reprint_flag = Reader["MSG_REPRINT_FLAG"].ToString(),
					_originalMsg_auto_logout = Reader["MSG_AUTO_LOGOUT"].ToString(),
					_originalMsg_dtl1 = Reader["MSG_DTL1"].ToString(),
					_originalMsg_dtl2 = Reader["MSG_DTL2"].ToString(),
					_originalMsg_dtl3 = Reader["MSG_DTL3"].ToString(),
					_originalMsg_dtl4 = Reader["MSG_DTL4"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereMsg_sub_key_1 = WhereMsg_sub_key_1;
					_whereMsg_sub_key_23 = WhereMsg_sub_key_23;
					_whereMsg_reprint_flag = WhereMsg_reprint_flag;
					_whereMsg_auto_logout = WhereMsg_auto_logout;
					_whereMsg_dtl1 = WhereMsg_dtl1;
					_whereMsg_dtl2 = WhereMsg_dtl2;
					_whereMsg_dtl3 = WhereMsg_dtl3;
					_whereMsg_dtl4 = WhereMsg_dtl4;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereMsg_sub_key_1 == null 
				&& WhereMsg_sub_key_23 == null 
				&& WhereMsg_reprint_flag == null 
				&& WhereMsg_auto_logout == null 
				&& WhereMsg_dtl1 == null 
				&& WhereMsg_dtl2 == null 
				&& WhereMsg_dtl3 == null 
				&& WhereMsg_dtl4 == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereMsg_sub_key_1 ==  _whereMsg_sub_key_1
				&& WhereMsg_sub_key_23 ==  _whereMsg_sub_key_23
				&& WhereMsg_reprint_flag ==  _whereMsg_reprint_flag
				&& WhereMsg_auto_logout ==  _whereMsg_auto_logout
				&& WhereMsg_dtl1 ==  _whereMsg_dtl1
				&& WhereMsg_dtl2 ==  _whereMsg_dtl2
				&& WhereMsg_dtl3 ==  _whereMsg_dtl3
				&& WhereMsg_dtl4 ==  _whereMsg_dtl4
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereMsg_sub_key_1 = null; 
			WhereMsg_sub_key_23 = null; 
			WhereMsg_reprint_flag = null; 
			WhereMsg_auto_logout = null; 
			WhereMsg_dtl1 = null; 
			WhereMsg_dtl2 = null; 
			WhereMsg_dtl3 = null; 
			WhereMsg_dtl4 = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _MSG_SUB_KEY_1;
		private string _MSG_SUB_KEY_23;
		private string _MSG_REPRINT_FLAG;
		private string _MSG_AUTO_LOGOUT;
		private string _MSG_DTL1;
		private string _MSG_DTL2;
		private string _MSG_DTL3;
		private string _MSG_DTL4;
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
		public string MSG_SUB_KEY_1
		{
			get { return _MSG_SUB_KEY_1; }
			set
			{
				if (_MSG_SUB_KEY_1 != value)
				{
					_MSG_SUB_KEY_1 = value;
					ChangeState();
				}
			}
		}
		public string MSG_SUB_KEY_23
		{
			get { return _MSG_SUB_KEY_23; }
			set
			{
				if (_MSG_SUB_KEY_23 != value)
				{
					_MSG_SUB_KEY_23 = value;
					ChangeState();
				}
			}
		}
		public string MSG_REPRINT_FLAG
		{
			get { return _MSG_REPRINT_FLAG; }
			set
			{
				if (_MSG_REPRINT_FLAG != value)
				{
					_MSG_REPRINT_FLAG = value;
					ChangeState();
				}
			}
		}
		public string MSG_AUTO_LOGOUT
		{
			get { return _MSG_AUTO_LOGOUT; }
			set
			{
				if (_MSG_AUTO_LOGOUT != value)
				{
					_MSG_AUTO_LOGOUT = value;
					ChangeState();
				}
			}
		}
		public string MSG_DTL1
		{
			get { return _MSG_DTL1; }
			set
			{
				if (_MSG_DTL1 != value)
				{
					_MSG_DTL1 = value;
					ChangeState();
				}
			}
		}
		public string MSG_DTL2
		{
			get { return _MSG_DTL2; }
			set
			{
				if (_MSG_DTL2 != value)
				{
					_MSG_DTL2 = value;
					ChangeState();
				}
			}
		}
		public string MSG_DTL3
		{
			get { return _MSG_DTL3; }
			set
			{
				if (_MSG_DTL3 != value)
				{
					_MSG_DTL3 = value;
					ChangeState();
				}
			}
		}
		public string MSG_DTL4
		{
			get { return _MSG_DTL4; }
			set
			{
				if (_MSG_DTL4 != value)
				{
					_MSG_DTL4 = value;
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
		public string WhereMsg_sub_key_1 { get; set; }
		private string _whereMsg_sub_key_1;
		public string WhereMsg_sub_key_23 { get; set; }
		private string _whereMsg_sub_key_23;
		public string WhereMsg_reprint_flag { get; set; }
		private string _whereMsg_reprint_flag;
		public string WhereMsg_auto_logout { get; set; }
		private string _whereMsg_auto_logout;
		public string WhereMsg_dtl1 { get; set; }
		private string _whereMsg_dtl1;
		public string WhereMsg_dtl2 { get; set; }
		private string _whereMsg_dtl2;
		public string WhereMsg_dtl3 { get; set; }
		private string _whereMsg_dtl3;
		public string WhereMsg_dtl4 { get; set; }
		private string _whereMsg_dtl4;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalMsg_sub_key_1;
		private string _originalMsg_sub_key_23;
		private string _originalMsg_reprint_flag;
		private string _originalMsg_auto_logout;
		private string _originalMsg_dtl1;
		private string _originalMsg_dtl2;
		private string _originalMsg_dtl3;
		private string _originalMsg_dtl4;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			MSG_SUB_KEY_1 = _originalMsg_sub_key_1;
			MSG_SUB_KEY_23 = _originalMsg_sub_key_23;
			MSG_REPRINT_FLAG = _originalMsg_reprint_flag;
			MSG_AUTO_LOGOUT = _originalMsg_auto_logout;
			MSG_DTL1 = _originalMsg_dtl1;
			MSG_DTL2 = _originalMsg_dtl2;
			MSG_DTL3 = _originalMsg_dtl3;
			MSG_DTL4 = _originalMsg_dtl4;
			CHECKSUM_VALUE = _originalChecksum_value;

            RecordState = State.UnChanged;

            return true;
        }


        public bool Delete()
        {
            bool retvalue = true;

            try
            {
                int RowsAffected = 0;
                var parameters = new SqlParameter[]
                    {
                    new SqlParameter("RowCheckSum",RowCheckSum),
                    new SqlParameter("ROWID",ROWID),
                    new SqlParameter("MSG_SUB_KEY_1",MSG_SUB_KEY_1),
                    new SqlParameter("MSG_SUB_KEY_23",MSG_SUB_KEY_23)
                    };
                RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F094_MSG_MSTR_DeleteRow]", parameters);
            }

            catch (Exception e)
            {
                retvalue = false;
            }

            finally
            {
                CloseConnection();
            }

            return retvalue;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F094_MSG_MSTR_Purge]");
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
						new SqlParameter("MSG_SUB_KEY_1", SqlNull(MSG_SUB_KEY_1)),
						new SqlParameter("MSG_SUB_KEY_23", SqlNull(MSG_SUB_KEY_23)),
						new SqlParameter("MSG_REPRINT_FLAG", SqlNull(MSG_REPRINT_FLAG)),
						new SqlParameter("MSG_AUTO_LOGOUT", SqlNull(MSG_AUTO_LOGOUT)),
						new SqlParameter("MSG_DTL1", SqlNull(MSG_DTL1)),
						new SqlParameter("MSG_DTL2", SqlNull(MSG_DTL2)),
						new SqlParameter("MSG_DTL3", SqlNull(MSG_DTL3)),
						new SqlParameter("MSG_DTL4", SqlNull(MSG_DTL4)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F094_MSG_MSTR_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						MSG_SUB_KEY_1 = Reader["MSG_SUB_KEY_1"].ToString();
						MSG_SUB_KEY_23 = Reader["MSG_SUB_KEY_23"].ToString();
						MSG_REPRINT_FLAG = Reader["MSG_REPRINT_FLAG"].ToString();
						MSG_AUTO_LOGOUT = Reader["MSG_AUTO_LOGOUT"].ToString();
						MSG_DTL1 = Reader["MSG_DTL1"].ToString();
						MSG_DTL2 = Reader["MSG_DTL2"].ToString();
						MSG_DTL3 = Reader["MSG_DTL3"].ToString();
						MSG_DTL4 = Reader["MSG_DTL4"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalMsg_sub_key_1 = Reader["MSG_SUB_KEY_1"].ToString();
						_originalMsg_sub_key_23 = Reader["MSG_SUB_KEY_23"].ToString();
						_originalMsg_reprint_flag = Reader["MSG_REPRINT_FLAG"].ToString();
						_originalMsg_auto_logout = Reader["MSG_AUTO_LOGOUT"].ToString();
						_originalMsg_dtl1 = Reader["MSG_DTL1"].ToString();
						_originalMsg_dtl2 = Reader["MSG_DTL2"].ToString();
						_originalMsg_dtl3 = Reader["MSG_DTL3"].ToString();
						_originalMsg_dtl4 = Reader["MSG_DTL4"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("MSG_SUB_KEY_1", SqlNull(MSG_SUB_KEY_1)),
						new SqlParameter("MSG_SUB_KEY_23", SqlNull(MSG_SUB_KEY_23)),
						new SqlParameter("MSG_REPRINT_FLAG", SqlNull(MSG_REPRINT_FLAG)),
						new SqlParameter("MSG_AUTO_LOGOUT", SqlNull(MSG_AUTO_LOGOUT)),
						new SqlParameter("MSG_DTL1", SqlNull(MSG_DTL1)),
						new SqlParameter("MSG_DTL2", SqlNull(MSG_DTL2)),
						new SqlParameter("MSG_DTL3", SqlNull(MSG_DTL3)),
						new SqlParameter("MSG_DTL4", SqlNull(MSG_DTL4)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F094_MSG_MSTR_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						MSG_SUB_KEY_1 = Reader["MSG_SUB_KEY_1"].ToString();
						MSG_SUB_KEY_23 = Reader["MSG_SUB_KEY_23"].ToString();
						MSG_REPRINT_FLAG = Reader["MSG_REPRINT_FLAG"].ToString();
						MSG_AUTO_LOGOUT = Reader["MSG_AUTO_LOGOUT"].ToString();
						MSG_DTL1 = Reader["MSG_DTL1"].ToString();
						MSG_DTL2 = Reader["MSG_DTL2"].ToString();
						MSG_DTL3 = Reader["MSG_DTL3"].ToString();
						MSG_DTL4 = Reader["MSG_DTL4"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalMsg_sub_key_1 = Reader["MSG_SUB_KEY_1"].ToString();
						_originalMsg_sub_key_23 = Reader["MSG_SUB_KEY_23"].ToString();
						_originalMsg_reprint_flag = Reader["MSG_REPRINT_FLAG"].ToString();
						_originalMsg_auto_logout = Reader["MSG_AUTO_LOGOUT"].ToString();
						_originalMsg_dtl1 = Reader["MSG_DTL1"].ToString();
						_originalMsg_dtl2 = Reader["MSG_DTL2"].ToString();
						_originalMsg_dtl3 = Reader["MSG_DTL3"].ToString();
						_originalMsg_dtl4 = Reader["MSG_DTL4"].ToString();
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