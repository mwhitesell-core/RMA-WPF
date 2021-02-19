using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F094_SUB_MSTR : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F094_SUB_MSTR> Collection( Guid? rowid,
															string msg_sub_key_12,
															string msg_sub_key_3,
															string sub_name,
															string sub_fee_complex,
															string sub_auto_logout,
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
					new SqlParameter("MSG_SUB_KEY_12",msg_sub_key_12),
					new SqlParameter("MSG_SUB_KEY_3",msg_sub_key_3),
					new SqlParameter("SUB_NAME",sub_name),
					new SqlParameter("SUB_FEE_COMPLEX",sub_fee_complex),
					new SqlParameter("SUB_AUTO_LOGOUT",sub_auto_logout),
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
                Reader = CoreReader("[INDEXED].[sp_F094_SUB_MSTR_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F094_SUB_MSTR>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F094_SUB_MSTR_Search]", parameters);
            var collection = new ObservableCollection<F094_SUB_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F094_SUB_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					MSG_SUB_KEY_12 = Reader["MSG_SUB_KEY_12"].ToString(),
					MSG_SUB_KEY_3 = Reader["MSG_SUB_KEY_3"].ToString(),
					SUB_NAME = Reader["SUB_NAME"].ToString(),
					SUB_FEE_COMPLEX = Reader["SUB_FEE_COMPLEX"].ToString(),
					SUB_AUTO_LOGOUT = Reader["SUB_AUTO_LOGOUT"].ToString(),
					FILLER = Reader["FILLER"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalMsg_sub_key_12 = Reader["MSG_SUB_KEY_12"].ToString(),
					_originalMsg_sub_key_3 = Reader["MSG_SUB_KEY_3"].ToString(),
					_originalSub_name = Reader["SUB_NAME"].ToString(),
					_originalSub_fee_complex = Reader["SUB_FEE_COMPLEX"].ToString(),
					_originalSub_auto_logout = Reader["SUB_AUTO_LOGOUT"].ToString(),
					_originalFiller = Reader["FILLER"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F094_SUB_MSTR Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F094_SUB_MSTR> Collection(ObservableCollection<F094_SUB_MSTR>
                                                               f094SubMstr = null)
        {
            if (IsSameSearch() && f094SubMstr != null)
            {
                return f094SubMstr;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F094_SUB_MSTR>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("MSG_SUB_KEY_12",WhereMsg_sub_key_12),
					new SqlParameter("MSG_SUB_KEY_3",WhereMsg_sub_key_3),
					new SqlParameter("SUB_NAME",WhereSub_name),
					new SqlParameter("SUB_FEE_COMPLEX",WhereSub_fee_complex),
					new SqlParameter("SUB_AUTO_LOGOUT",WhereSub_auto_logout),
					new SqlParameter("FILLER",WhereFiller),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F094_SUB_MSTR_Match]", parameters);
            var collection = new ObservableCollection<F094_SUB_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F094_SUB_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					MSG_SUB_KEY_12 = Reader["MSG_SUB_KEY_12"].ToString(),
					MSG_SUB_KEY_3 = Reader["MSG_SUB_KEY_3"].ToString(),
					SUB_NAME = Reader["SUB_NAME"].ToString(),
					SUB_FEE_COMPLEX = Reader["SUB_FEE_COMPLEX"].ToString(),
					SUB_AUTO_LOGOUT = Reader["SUB_AUTO_LOGOUT"].ToString(),
					FILLER = Reader["FILLER"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereMsg_sub_key_12 = WhereMsg_sub_key_12,
					_whereMsg_sub_key_3 = WhereMsg_sub_key_3,
					_whereSub_name = WhereSub_name,
					_whereSub_fee_complex = WhereSub_fee_complex,
					_whereSub_auto_logout = WhereSub_auto_logout,
					_whereFiller = WhereFiller,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalMsg_sub_key_12 = Reader["MSG_SUB_KEY_12"].ToString(),
					_originalMsg_sub_key_3 = Reader["MSG_SUB_KEY_3"].ToString(),
					_originalSub_name = Reader["SUB_NAME"].ToString(),
					_originalSub_fee_complex = Reader["SUB_FEE_COMPLEX"].ToString(),
					_originalSub_auto_logout = Reader["SUB_AUTO_LOGOUT"].ToString(),
					_originalFiller = Reader["FILLER"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereMsg_sub_key_12 = WhereMsg_sub_key_12;
					_whereMsg_sub_key_3 = WhereMsg_sub_key_3;
					_whereSub_name = WhereSub_name;
					_whereSub_fee_complex = WhereSub_fee_complex;
					_whereSub_auto_logout = WhereSub_auto_logout;
					_whereFiller = WhereFiller;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereMsg_sub_key_12 == null 
				&& WhereMsg_sub_key_3 == null 
				&& WhereSub_name == null 
				&& WhereSub_fee_complex == null 
				&& WhereSub_auto_logout == null 
				&& WhereFiller == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereMsg_sub_key_12 ==  _whereMsg_sub_key_12
				&& WhereMsg_sub_key_3 ==  _whereMsg_sub_key_3
				&& WhereSub_name ==  _whereSub_name
				&& WhereSub_fee_complex ==  _whereSub_fee_complex
				&& WhereSub_auto_logout ==  _whereSub_auto_logout
				&& WhereFiller ==  _whereFiller
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereMsg_sub_key_12 = null; 
			WhereMsg_sub_key_3 = null; 
			WhereSub_name = null; 
			WhereSub_fee_complex = null; 
			WhereSub_auto_logout = null; 
			WhereFiller = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _MSG_SUB_KEY_12;
		private string _MSG_SUB_KEY_3;
		private string _SUB_NAME;
		private string _SUB_FEE_COMPLEX;
		private string _SUB_AUTO_LOGOUT;
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
		public string MSG_SUB_KEY_12
		{
			get { return _MSG_SUB_KEY_12; }
			set
			{
				if (_MSG_SUB_KEY_12 != value)
				{
					_MSG_SUB_KEY_12 = value;
					ChangeState();
				}
			}
		}
		public string MSG_SUB_KEY_3
		{
			get { return _MSG_SUB_KEY_3; }
			set
			{
				if (_MSG_SUB_KEY_3 != value)
				{
					_MSG_SUB_KEY_3 = value;
					ChangeState();
				}
			}
		}
		public string SUB_NAME
		{
			get { return _SUB_NAME; }
			set
			{
				if (_SUB_NAME != value)
				{
					_SUB_NAME = value;
					ChangeState();
				}
			}
		}
		public string SUB_FEE_COMPLEX
		{
			get { return _SUB_FEE_COMPLEX; }
			set
			{
				if (_SUB_FEE_COMPLEX != value)
				{
					_SUB_FEE_COMPLEX = value;
					ChangeState();
				}
			}
		}
		public string SUB_AUTO_LOGOUT
		{
			get { return _SUB_AUTO_LOGOUT; }
			set
			{
				if (_SUB_AUTO_LOGOUT != value)
				{
					_SUB_AUTO_LOGOUT = value;
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
		public string WhereMsg_sub_key_12 { get; set; }
		private string _whereMsg_sub_key_12;
		public string WhereMsg_sub_key_3 { get; set; }
		private string _whereMsg_sub_key_3;
		public string WhereSub_name { get; set; }
		private string _whereSub_name;
		public string WhereSub_fee_complex { get; set; }
		private string _whereSub_fee_complex;
		public string WhereSub_auto_logout { get; set; }
		private string _whereSub_auto_logout;
		public string WhereFiller { get; set; }
		private string _whereFiller;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalMsg_sub_key_12;
		private string _originalMsg_sub_key_3;
		private string _originalSub_name;
		private string _originalSub_fee_complex;
		private string _originalSub_auto_logout;
		private string _originalFiller;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			MSG_SUB_KEY_12 = _originalMsg_sub_key_12;
			MSG_SUB_KEY_3 = _originalMsg_sub_key_3;
			SUB_NAME = _originalSub_name;
			SUB_FEE_COMPLEX = _originalSub_fee_complex;
			SUB_AUTO_LOGOUT = _originalSub_auto_logout;
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
					new SqlParameter("ROWID",ROWID),
					new SqlParameter("MSG_SUB_KEY_12",MSG_SUB_KEY_12),
					new SqlParameter("MSG_SUB_KEY_3",MSG_SUB_KEY_3)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F094_SUB_MSTR_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F094_SUB_MSTR_Purge]");
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
						new SqlParameter("MSG_SUB_KEY_12", SqlNull(MSG_SUB_KEY_12)),
						new SqlParameter("MSG_SUB_KEY_3", SqlNull(MSG_SUB_KEY_3)),
						new SqlParameter("SUB_NAME", SqlNull(SUB_NAME)),
						new SqlParameter("SUB_FEE_COMPLEX", SqlNull(SUB_FEE_COMPLEX)),
						new SqlParameter("SUB_AUTO_LOGOUT", SqlNull(SUB_AUTO_LOGOUT)),
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F094_SUB_MSTR_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						MSG_SUB_KEY_12 = Reader["MSG_SUB_KEY_12"].ToString();
						MSG_SUB_KEY_3 = Reader["MSG_SUB_KEY_3"].ToString();
						SUB_NAME = Reader["SUB_NAME"].ToString();
						SUB_FEE_COMPLEX = Reader["SUB_FEE_COMPLEX"].ToString();
						SUB_AUTO_LOGOUT = Reader["SUB_AUTO_LOGOUT"].ToString();
						FILLER = Reader["FILLER"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalMsg_sub_key_12 = Reader["MSG_SUB_KEY_12"].ToString();
						_originalMsg_sub_key_3 = Reader["MSG_SUB_KEY_3"].ToString();
						_originalSub_name = Reader["SUB_NAME"].ToString();
						_originalSub_fee_complex = Reader["SUB_FEE_COMPLEX"].ToString();
						_originalSub_auto_logout = Reader["SUB_AUTO_LOGOUT"].ToString();
						_originalFiller = Reader["FILLER"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("MSG_SUB_KEY_12", SqlNull(MSG_SUB_KEY_12)),
						new SqlParameter("MSG_SUB_KEY_3", SqlNull(MSG_SUB_KEY_3)),
						new SqlParameter("SUB_NAME", SqlNull(SUB_NAME)),
						new SqlParameter("SUB_FEE_COMPLEX", SqlNull(SUB_FEE_COMPLEX)),
						new SqlParameter("SUB_AUTO_LOGOUT", SqlNull(SUB_AUTO_LOGOUT)),
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F094_SUB_MSTR_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						MSG_SUB_KEY_12 = Reader["MSG_SUB_KEY_12"].ToString();
						MSG_SUB_KEY_3 = Reader["MSG_SUB_KEY_3"].ToString();
						SUB_NAME = Reader["SUB_NAME"].ToString();
						SUB_FEE_COMPLEX = Reader["SUB_FEE_COMPLEX"].ToString();
						SUB_AUTO_LOGOUT = Reader["SUB_AUTO_LOGOUT"].ToString();
						FILLER = Reader["FILLER"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalMsg_sub_key_12 = Reader["MSG_SUB_KEY_12"].ToString();
						_originalMsg_sub_key_3 = Reader["MSG_SUB_KEY_3"].ToString();
						_originalSub_name = Reader["SUB_NAME"].ToString();
						_originalSub_fee_complex = Reader["SUB_FEE_COMPLEX"].ToString();
						_originalSub_auto_logout = Reader["SUB_AUTO_LOGOUT"].ToString();
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