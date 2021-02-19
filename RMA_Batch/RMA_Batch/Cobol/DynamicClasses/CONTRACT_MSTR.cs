using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class CONTRACT_MSTR : BaseTable
    {
        #region Retrieve

        public ObservableCollection<CONTRACT_MSTR> Collection( Guid? rowid,
															string contract_code,
															string contract_desc,
															string address_1,
															string address_2,
															string address_3,
															string postal_code,
															string contact_admin,
															string contact_oper,
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
					new SqlParameter("CONTRACT_CODE",contract_code),
					new SqlParameter("CONTRACT_DESC",contract_desc),
					new SqlParameter("ADDRESS_1",address_1),
					new SqlParameter("ADDRESS_2",address_2),
					new SqlParameter("ADDRESS_3",address_3),
					new SqlParameter("POSTAL_CODE",postal_code),
					new SqlParameter("CONTACT_ADMIN",contact_admin),
					new SqlParameter("CONTACT_OPER",contact_oper),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_CONTRACT_MSTR_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<CONTRACT_MSTR>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_CONTRACT_MSTR_Search]", parameters);
            var collection = new ObservableCollection<CONTRACT_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new CONTRACT_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CONTRACT_CODE = Reader["CONTRACT_CODE"].ToString(),
					CONTRACT_DESC = Reader["CONTRACT_DESC"].ToString(),
					ADDRESS_1 = Reader["ADDRESS_1"].ToString(),
					ADDRESS_2 = Reader["ADDRESS_2"].ToString(),
					ADDRESS_3 = Reader["ADDRESS_3"].ToString(),
					POSTAL_CODE = Reader["POSTAL_CODE"].ToString(),
					CONTACT_ADMIN = Reader["CONTACT_ADMIN"].ToString(),
					CONTACT_OPER = Reader["CONTACT_OPER"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalContract_code = Reader["CONTRACT_CODE"].ToString(),
					_originalContract_desc = Reader["CONTRACT_DESC"].ToString(),
					_originalAddress_1 = Reader["ADDRESS_1"].ToString(),
					_originalAddress_2 = Reader["ADDRESS_2"].ToString(),
					_originalAddress_3 = Reader["ADDRESS_3"].ToString(),
					_originalPostal_code = Reader["POSTAL_CODE"].ToString(),
					_originalContact_admin = Reader["CONTACT_ADMIN"].ToString(),
					_originalContact_oper = Reader["CONTACT_OPER"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public CONTRACT_MSTR Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<CONTRACT_MSTR> Collection(ObservableCollection<CONTRACT_MSTR>
                                                               contractMstr = null)
        {
            if (IsSameSearch() && contractMstr != null)
            {
                return contractMstr;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<CONTRACT_MSTR>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("CONTRACT_CODE",WhereContract_code),
					new SqlParameter("CONTRACT_DESC",WhereContract_desc),
					new SqlParameter("ADDRESS_1",WhereAddress_1),
					new SqlParameter("ADDRESS_2",WhereAddress_2),
					new SqlParameter("ADDRESS_3",WhereAddress_3),
					new SqlParameter("POSTAL_CODE",WherePostal_code),
					new SqlParameter("CONTACT_ADMIN",WhereContact_admin),
					new SqlParameter("CONTACT_OPER",WhereContact_oper),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_CONTRACT_MSTR_Match]", parameters);
            var collection = new ObservableCollection<CONTRACT_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new CONTRACT_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CONTRACT_CODE = Reader["CONTRACT_CODE"].ToString(),
					CONTRACT_DESC = Reader["CONTRACT_DESC"].ToString(),
					ADDRESS_1 = Reader["ADDRESS_1"].ToString(),
					ADDRESS_2 = Reader["ADDRESS_2"].ToString(),
					ADDRESS_3 = Reader["ADDRESS_3"].ToString(),
					POSTAL_CODE = Reader["POSTAL_CODE"].ToString(),
					CONTACT_ADMIN = Reader["CONTACT_ADMIN"].ToString(),
					CONTACT_OPER = Reader["CONTACT_OPER"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereContract_code = WhereContract_code,
					_whereContract_desc = WhereContract_desc,
					_whereAddress_1 = WhereAddress_1,
					_whereAddress_2 = WhereAddress_2,
					_whereAddress_3 = WhereAddress_3,
					_wherePostal_code = WherePostal_code,
					_whereContact_admin = WhereContact_admin,
					_whereContact_oper = WhereContact_oper,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalContract_code = Reader["CONTRACT_CODE"].ToString(),
					_originalContract_desc = Reader["CONTRACT_DESC"].ToString(),
					_originalAddress_1 = Reader["ADDRESS_1"].ToString(),
					_originalAddress_2 = Reader["ADDRESS_2"].ToString(),
					_originalAddress_3 = Reader["ADDRESS_3"].ToString(),
					_originalPostal_code = Reader["POSTAL_CODE"].ToString(),
					_originalContact_admin = Reader["CONTACT_ADMIN"].ToString(),
					_originalContact_oper = Reader["CONTACT_OPER"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereContract_code = WhereContract_code;
					_whereContract_desc = WhereContract_desc;
					_whereAddress_1 = WhereAddress_1;
					_whereAddress_2 = WhereAddress_2;
					_whereAddress_3 = WhereAddress_3;
					_wherePostal_code = WherePostal_code;
					_whereContact_admin = WhereContact_admin;
					_whereContact_oper = WhereContact_oper;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereContract_code == null 
				&& WhereContract_desc == null 
				&& WhereAddress_1 == null 
				&& WhereAddress_2 == null 
				&& WhereAddress_3 == null 
				&& WherePostal_code == null 
				&& WhereContact_admin == null 
				&& WhereContact_oper == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereContract_code ==  _whereContract_code
				&& WhereContract_desc ==  _whereContract_desc
				&& WhereAddress_1 ==  _whereAddress_1
				&& WhereAddress_2 ==  _whereAddress_2
				&& WhereAddress_3 ==  _whereAddress_3
				&& WherePostal_code ==  _wherePostal_code
				&& WhereContact_admin ==  _whereContact_admin
				&& WhereContact_oper ==  _whereContact_oper
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereContract_code = null; 
			WhereContract_desc = null; 
			WhereAddress_1 = null; 
			WhereAddress_2 = null; 
			WhereAddress_3 = null; 
			WherePostal_code = null; 
			WhereContact_admin = null; 
			WhereContact_oper = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _CONTRACT_CODE;
		private string _CONTRACT_DESC;
		private string _ADDRESS_1;
		private string _ADDRESS_2;
		private string _ADDRESS_3;
		private string _POSTAL_CODE;
		private string _CONTACT_ADMIN;
		private string _CONTACT_OPER;
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
		public string CONTRACT_CODE
		{
			get { return _CONTRACT_CODE; }
			set
			{
				if (_CONTRACT_CODE != value)
				{
					_CONTRACT_CODE = value;
					ChangeState();
				}
			}
		}
		public string CONTRACT_DESC
		{
			get { return _CONTRACT_DESC; }
			set
			{
				if (_CONTRACT_DESC != value)
				{
					_CONTRACT_DESC = value;
					ChangeState();
				}
			}
		}
		public string ADDRESS_1
		{
			get { return _ADDRESS_1; }
			set
			{
				if (_ADDRESS_1 != value)
				{
					_ADDRESS_1 = value;
					ChangeState();
				}
			}
		}
		public string ADDRESS_2
		{
			get { return _ADDRESS_2; }
			set
			{
				if (_ADDRESS_2 != value)
				{
					_ADDRESS_2 = value;
					ChangeState();
				}
			}
		}
		public string ADDRESS_3
		{
			get { return _ADDRESS_3; }
			set
			{
				if (_ADDRESS_3 != value)
				{
					_ADDRESS_3 = value;
					ChangeState();
				}
			}
		}
		public string POSTAL_CODE
		{
			get { return _POSTAL_CODE; }
			set
			{
				if (_POSTAL_CODE != value)
				{
					_POSTAL_CODE = value;
					ChangeState();
				}
			}
		}
		public string CONTACT_ADMIN
		{
			get { return _CONTACT_ADMIN; }
			set
			{
				if (_CONTACT_ADMIN != value)
				{
					_CONTACT_ADMIN = value;
					ChangeState();
				}
			}
		}
		public string CONTACT_OPER
		{
			get { return _CONTACT_OPER; }
			set
			{
				if (_CONTACT_OPER != value)
				{
					_CONTACT_OPER = value;
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
		public string WhereContract_code { get; set; }
		private string _whereContract_code;
		public string WhereContract_desc { get; set; }
		private string _whereContract_desc;
		public string WhereAddress_1 { get; set; }
		private string _whereAddress_1;
		public string WhereAddress_2 { get; set; }
		private string _whereAddress_2;
		public string WhereAddress_3 { get; set; }
		private string _whereAddress_3;
		public string WherePostal_code { get; set; }
		private string _wherePostal_code;
		public string WhereContact_admin { get; set; }
		private string _whereContact_admin;
		public string WhereContact_oper { get; set; }
		private string _whereContact_oper;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalContract_code;
		private string _originalContract_desc;
		private string _originalAddress_1;
		private string _originalAddress_2;
		private string _originalAddress_3;
		private string _originalPostal_code;
		private string _originalContact_admin;
		private string _originalContact_oper;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			CONTRACT_CODE = _originalContract_code;
			CONTRACT_DESC = _originalContract_desc;
			ADDRESS_1 = _originalAddress_1;
			ADDRESS_2 = _originalAddress_2;
			ADDRESS_3 = _originalAddress_3;
			POSTAL_CODE = _originalPostal_code;
			CONTACT_ADMIN = _originalContact_admin;
			CONTACT_OPER = _originalContact_oper;
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
					new SqlParameter("CONTRACT_CODE",CONTRACT_CODE)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_CONTRACT_MSTR_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_CONTRACT_MSTR_Purge]");
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
						new SqlParameter("CONTRACT_CODE", SqlNull(CONTRACT_CODE)),
						new SqlParameter("CONTRACT_DESC", SqlNull(CONTRACT_DESC)),
						new SqlParameter("ADDRESS_1", SqlNull(ADDRESS_1)),
						new SqlParameter("ADDRESS_2", SqlNull(ADDRESS_2)),
						new SqlParameter("ADDRESS_3", SqlNull(ADDRESS_3)),
						new SqlParameter("POSTAL_CODE", SqlNull(POSTAL_CODE)),
						new SqlParameter("CONTACT_ADMIN", SqlNull(CONTACT_ADMIN)),
						new SqlParameter("CONTACT_OPER", SqlNull(CONTACT_OPER)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_CONTRACT_MSTR_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CONTRACT_CODE = Reader["CONTRACT_CODE"].ToString();
						CONTRACT_DESC = Reader["CONTRACT_DESC"].ToString();
						ADDRESS_1 = Reader["ADDRESS_1"].ToString();
						ADDRESS_2 = Reader["ADDRESS_2"].ToString();
						ADDRESS_3 = Reader["ADDRESS_3"].ToString();
						POSTAL_CODE = Reader["POSTAL_CODE"].ToString();
						CONTACT_ADMIN = Reader["CONTACT_ADMIN"].ToString();
						CONTACT_OPER = Reader["CONTACT_OPER"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalContract_code = Reader["CONTRACT_CODE"].ToString();
						_originalContract_desc = Reader["CONTRACT_DESC"].ToString();
						_originalAddress_1 = Reader["ADDRESS_1"].ToString();
						_originalAddress_2 = Reader["ADDRESS_2"].ToString();
						_originalAddress_3 = Reader["ADDRESS_3"].ToString();
						_originalPostal_code = Reader["POSTAL_CODE"].ToString();
						_originalContact_admin = Reader["CONTACT_ADMIN"].ToString();
						_originalContact_oper = Reader["CONTACT_OPER"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("CONTRACT_CODE", SqlNull(CONTRACT_CODE)),
						new SqlParameter("CONTRACT_DESC", SqlNull(CONTRACT_DESC)),
						new SqlParameter("ADDRESS_1", SqlNull(ADDRESS_1)),
						new SqlParameter("ADDRESS_2", SqlNull(ADDRESS_2)),
						new SqlParameter("ADDRESS_3", SqlNull(ADDRESS_3)),
						new SqlParameter("POSTAL_CODE", SqlNull(POSTAL_CODE)),
						new SqlParameter("CONTACT_ADMIN", SqlNull(CONTACT_ADMIN)),
						new SqlParameter("CONTACT_OPER", SqlNull(CONTACT_OPER)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_CONTRACT_MSTR_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CONTRACT_CODE = Reader["CONTRACT_CODE"].ToString();
						CONTRACT_DESC = Reader["CONTRACT_DESC"].ToString();
						ADDRESS_1 = Reader["ADDRESS_1"].ToString();
						ADDRESS_2 = Reader["ADDRESS_2"].ToString();
						ADDRESS_3 = Reader["ADDRESS_3"].ToString();
						POSTAL_CODE = Reader["POSTAL_CODE"].ToString();
						CONTACT_ADMIN = Reader["CONTACT_ADMIN"].ToString();
						CONTACT_OPER = Reader["CONTACT_OPER"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalContract_code = Reader["CONTRACT_CODE"].ToString();
						_originalContract_desc = Reader["CONTRACT_DESC"].ToString();
						_originalAddress_1 = Reader["ADDRESS_1"].ToString();
						_originalAddress_2 = Reader["ADDRESS_2"].ToString();
						_originalAddress_3 = Reader["ADDRESS_3"].ToString();
						_originalPostal_code = Reader["POSTAL_CODE"].ToString();
						_originalContact_admin = Reader["CONTACT_ADMIN"].ToString();
						_originalContact_oper = Reader["CONTACT_OPER"].ToString();
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