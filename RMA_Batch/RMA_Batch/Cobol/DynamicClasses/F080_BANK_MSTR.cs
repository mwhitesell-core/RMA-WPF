using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F080_BANK_MSTR : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F080_BANK_MSTR> Collection( Guid? rowid,
															string bank_cd,
															string bank_name,
															string bank_address1,
															string bank_address2,
															string bank_city,
															string bank_prov,
															string bank_pc1,
															decimal? bank_pc2min,
															decimal? bank_pc2max,
															string bank_pc3,
															decimal? bank_pc4min,
															decimal? bank_pc4max,
															string bank_pc5,
															decimal? bank_pc6min,
															decimal? bank_pc6max,
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
					new SqlParameter("BANK_CD",bank_cd),
					new SqlParameter("BANK_NAME",bank_name),
					new SqlParameter("BANK_ADDRESS1",bank_address1),
					new SqlParameter("BANK_ADDRESS2",bank_address2),
					new SqlParameter("BANK_CITY",bank_city),
					new SqlParameter("BANK_PROV",bank_prov),
					new SqlParameter("BANK_PC1",bank_pc1),
					new SqlParameter("minBANK_PC2",bank_pc2min),
					new SqlParameter("maxBANK_PC2",bank_pc2max),
					new SqlParameter("BANK_PC3",bank_pc3),
					new SqlParameter("minBANK_PC4",bank_pc4min),
					new SqlParameter("maxBANK_PC4",bank_pc4max),
					new SqlParameter("BANK_PC5",bank_pc5),
					new SqlParameter("minBANK_PC6",bank_pc6min),
					new SqlParameter("maxBANK_PC6",bank_pc6max),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F080_BANK_MSTR_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F080_BANK_MSTR>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F080_BANK_MSTR_Search]", parameters);
            var collection = new ObservableCollection<F080_BANK_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F080_BANK_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					BANK_CD = Reader["BANK_CD"].ToString(),
					BANK_NAME = Reader["BANK_NAME"].ToString(),
					BANK_ADDRESS1 = Reader["BANK_ADDRESS1"].ToString(),
					BANK_ADDRESS2 = Reader["BANK_ADDRESS2"].ToString(),
					BANK_CITY = Reader["BANK_CITY"].ToString(),
					BANK_PROV = Reader["BANK_PROV"].ToString(),
					BANK_PC1 = Reader["BANK_PC1"].ToString(),
					BANK_PC2 = ConvertDEC(Reader["BANK_PC2"]),
					BANK_PC3 = Reader["BANK_PC3"].ToString(),
					BANK_PC4 = ConvertDEC(Reader["BANK_PC4"]),
					BANK_PC5 = Reader["BANK_PC5"].ToString(),
					BANK_PC6 = ConvertDEC(Reader["BANK_PC6"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalBank_cd = Reader["BANK_CD"].ToString(),
					_originalBank_name = Reader["BANK_NAME"].ToString(),
					_originalBank_address1 = Reader["BANK_ADDRESS1"].ToString(),
					_originalBank_address2 = Reader["BANK_ADDRESS2"].ToString(),
					_originalBank_city = Reader["BANK_CITY"].ToString(),
					_originalBank_prov = Reader["BANK_PROV"].ToString(),
					_originalBank_pc1 = Reader["BANK_PC1"].ToString(),
					_originalBank_pc2 = ConvertDEC(Reader["BANK_PC2"]),
					_originalBank_pc3 = Reader["BANK_PC3"].ToString(),
					_originalBank_pc4 = ConvertDEC(Reader["BANK_PC4"]),
					_originalBank_pc5 = Reader["BANK_PC5"].ToString(),
					_originalBank_pc6 = ConvertDEC(Reader["BANK_PC6"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F080_BANK_MSTR Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F080_BANK_MSTR> Collection(ObservableCollection<F080_BANK_MSTR>
                                                               f080BankMstr = null)
        {
            if (IsSameSearch() && f080BankMstr != null)
            {
                return f080BankMstr;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F080_BANK_MSTR>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("BANK_CD",WhereBank_cd),
					new SqlParameter("BANK_NAME",WhereBank_name),
					new SqlParameter("BANK_ADDRESS1",WhereBank_address1),
					new SqlParameter("BANK_ADDRESS2",WhereBank_address2),
					new SqlParameter("BANK_CITY",WhereBank_city),
					new SqlParameter("BANK_PROV",WhereBank_prov),
					new SqlParameter("BANK_PC1",WhereBank_pc1),
					new SqlParameter("BANK_PC2",WhereBank_pc2),
					new SqlParameter("BANK_PC3",WhereBank_pc3),
					new SqlParameter("BANK_PC4",WhereBank_pc4),
					new SqlParameter("BANK_PC5",WhereBank_pc5),
					new SqlParameter("BANK_PC6",WhereBank_pc6),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F080_BANK_MSTR_Match]", parameters);
            var collection = new ObservableCollection<F080_BANK_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F080_BANK_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					BANK_CD = Reader["BANK_CD"].ToString(),
					BANK_NAME = Reader["BANK_NAME"].ToString(),
					BANK_ADDRESS1 = Reader["BANK_ADDRESS1"].ToString(),
					BANK_ADDRESS2 = Reader["BANK_ADDRESS2"].ToString(),
					BANK_CITY = Reader["BANK_CITY"].ToString(),
					BANK_PROV = Reader["BANK_PROV"].ToString(),
					BANK_PC1 = Reader["BANK_PC1"].ToString(),
					BANK_PC2 = ConvertDEC(Reader["BANK_PC2"]),
					BANK_PC3 = Reader["BANK_PC3"].ToString(),
					BANK_PC4 = ConvertDEC(Reader["BANK_PC4"]),
					BANK_PC5 = Reader["BANK_PC5"].ToString(),
					BANK_PC6 = ConvertDEC(Reader["BANK_PC6"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereBank_cd = WhereBank_cd,
					_whereBank_name = WhereBank_name,
					_whereBank_address1 = WhereBank_address1,
					_whereBank_address2 = WhereBank_address2,
					_whereBank_city = WhereBank_city,
					_whereBank_prov = WhereBank_prov,
					_whereBank_pc1 = WhereBank_pc1,
					_whereBank_pc2 = WhereBank_pc2,
					_whereBank_pc3 = WhereBank_pc3,
					_whereBank_pc4 = WhereBank_pc4,
					_whereBank_pc5 = WhereBank_pc5,
					_whereBank_pc6 = WhereBank_pc6,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalBank_cd = Reader["BANK_CD"].ToString(),
					_originalBank_name = Reader["BANK_NAME"].ToString(),
					_originalBank_address1 = Reader["BANK_ADDRESS1"].ToString(),
					_originalBank_address2 = Reader["BANK_ADDRESS2"].ToString(),
					_originalBank_city = Reader["BANK_CITY"].ToString(),
					_originalBank_prov = Reader["BANK_PROV"].ToString(),
					_originalBank_pc1 = Reader["BANK_PC1"].ToString(),
					_originalBank_pc2 = ConvertDEC(Reader["BANK_PC2"]),
					_originalBank_pc3 = Reader["BANK_PC3"].ToString(),
					_originalBank_pc4 = ConvertDEC(Reader["BANK_PC4"]),
					_originalBank_pc5 = Reader["BANK_PC5"].ToString(),
					_originalBank_pc6 = ConvertDEC(Reader["BANK_PC6"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereBank_cd = WhereBank_cd;
					_whereBank_name = WhereBank_name;
					_whereBank_address1 = WhereBank_address1;
					_whereBank_address2 = WhereBank_address2;
					_whereBank_city = WhereBank_city;
					_whereBank_prov = WhereBank_prov;
					_whereBank_pc1 = WhereBank_pc1;
					_whereBank_pc2 = WhereBank_pc2;
					_whereBank_pc3 = WhereBank_pc3;
					_whereBank_pc4 = WhereBank_pc4;
					_whereBank_pc5 = WhereBank_pc5;
					_whereBank_pc6 = WhereBank_pc6;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereBank_cd == null 
				&& WhereBank_name == null 
				&& WhereBank_address1 == null 
				&& WhereBank_address2 == null 
				&& WhereBank_city == null 
				&& WhereBank_prov == null 
				&& WhereBank_pc1 == null 
				&& WhereBank_pc2 == null 
				&& WhereBank_pc3 == null 
				&& WhereBank_pc4 == null 
				&& WhereBank_pc5 == null 
				&& WhereBank_pc6 == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereBank_cd ==  _whereBank_cd
				&& WhereBank_name ==  _whereBank_name
				&& WhereBank_address1 ==  _whereBank_address1
				&& WhereBank_address2 ==  _whereBank_address2
				&& WhereBank_city ==  _whereBank_city
				&& WhereBank_prov ==  _whereBank_prov
				&& WhereBank_pc1 ==  _whereBank_pc1
				&& WhereBank_pc2 ==  _whereBank_pc2
				&& WhereBank_pc3 ==  _whereBank_pc3
				&& WhereBank_pc4 ==  _whereBank_pc4
				&& WhereBank_pc5 ==  _whereBank_pc5
				&& WhereBank_pc6 ==  _whereBank_pc6
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereBank_cd = null; 
			WhereBank_name = null; 
			WhereBank_address1 = null; 
			WhereBank_address2 = null; 
			WhereBank_city = null; 
			WhereBank_prov = null; 
			WhereBank_pc1 = null; 
			WhereBank_pc2 = null; 
			WhereBank_pc3 = null; 
			WhereBank_pc4 = null; 
			WhereBank_pc5 = null; 
			WhereBank_pc6 = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _BANK_CD;
		private string _BANK_NAME;
		private string _BANK_ADDRESS1;
		private string _BANK_ADDRESS2;
		private string _BANK_CITY;
		private string _BANK_PROV;
		private string _BANK_PC1;
		private decimal? _BANK_PC2;
		private string _BANK_PC3;
		private decimal? _BANK_PC4;
		private string _BANK_PC5;
		private decimal? _BANK_PC6;
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
		public string BANK_CD
		{
			get { return _BANK_CD; }
			set
			{
				if (_BANK_CD != value)
				{
					_BANK_CD = value;
					ChangeState();
				}
			}
		}
		public string BANK_NAME
		{
			get { return _BANK_NAME; }
			set
			{
				if (_BANK_NAME != value)
				{
					_BANK_NAME = value;
					ChangeState();
				}
			}
		}
		public string BANK_ADDRESS1
		{
			get { return _BANK_ADDRESS1; }
			set
			{
				if (_BANK_ADDRESS1 != value)
				{
					_BANK_ADDRESS1 = value;
					ChangeState();
				}
			}
		}
		public string BANK_ADDRESS2
		{
			get { return _BANK_ADDRESS2; }
			set
			{
				if (_BANK_ADDRESS2 != value)
				{
					_BANK_ADDRESS2 = value;
					ChangeState();
				}
			}
		}
		public string BANK_CITY
		{
			get { return _BANK_CITY; }
			set
			{
				if (_BANK_CITY != value)
				{
					_BANK_CITY = value;
					ChangeState();
				}
			}
		}
		public string BANK_PROV
		{
			get { return _BANK_PROV; }
			set
			{
				if (_BANK_PROV != value)
				{
					_BANK_PROV = value;
					ChangeState();
				}
			}
		}
		public string BANK_PC1
		{
			get { return _BANK_PC1; }
			set
			{
				if (_BANK_PC1 != value)
				{
					_BANK_PC1 = value;
					ChangeState();
				}
			}
		}
		public decimal? BANK_PC2
		{
			get { return _BANK_PC2; }
			set
			{
				if (_BANK_PC2 != value)
				{
					_BANK_PC2 = value;
					ChangeState();
				}
			}
		}
		public string BANK_PC3
		{
			get { return _BANK_PC3; }
			set
			{
				if (_BANK_PC3 != value)
				{
					_BANK_PC3 = value;
					ChangeState();
				}
			}
		}
		public decimal? BANK_PC4
		{
			get { return _BANK_PC4; }
			set
			{
				if (_BANK_PC4 != value)
				{
					_BANK_PC4 = value;
					ChangeState();
				}
			}
		}
		public string BANK_PC5
		{
			get { return _BANK_PC5; }
			set
			{
				if (_BANK_PC5 != value)
				{
					_BANK_PC5 = value;
					ChangeState();
				}
			}
		}
		public decimal? BANK_PC6
		{
			get { return _BANK_PC6; }
			set
			{
				if (_BANK_PC6 != value)
				{
					_BANK_PC6 = value;
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
		public string WhereBank_cd { get; set; }
		private string _whereBank_cd;
		public string WhereBank_name { get; set; }
		private string _whereBank_name;
		public string WhereBank_address1 { get; set; }
		private string _whereBank_address1;
		public string WhereBank_address2 { get; set; }
		private string _whereBank_address2;
		public string WhereBank_city { get; set; }
		private string _whereBank_city;
		public string WhereBank_prov { get; set; }
		private string _whereBank_prov;
		public string WhereBank_pc1 { get; set; }
		private string _whereBank_pc1;
		public decimal? WhereBank_pc2 { get; set; }
		private decimal? _whereBank_pc2;
		public string WhereBank_pc3 { get; set; }
		private string _whereBank_pc3;
		public decimal? WhereBank_pc4 { get; set; }
		private decimal? _whereBank_pc4;
		public string WhereBank_pc5 { get; set; }
		private string _whereBank_pc5;
		public decimal? WhereBank_pc6 { get; set; }
		private decimal? _whereBank_pc6;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalBank_cd;
		private string _originalBank_name;
		private string _originalBank_address1;
		private string _originalBank_address2;
		private string _originalBank_city;
		private string _originalBank_prov;
		private string _originalBank_pc1;
		private decimal? _originalBank_pc2;
		private string _originalBank_pc3;
		private decimal? _originalBank_pc4;
		private string _originalBank_pc5;
		private decimal? _originalBank_pc6;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			BANK_CD = _originalBank_cd;
			BANK_NAME = _originalBank_name;
			BANK_ADDRESS1 = _originalBank_address1;
			BANK_ADDRESS2 = _originalBank_address2;
			BANK_CITY = _originalBank_city;
			BANK_PROV = _originalBank_prov;
			BANK_PC1 = _originalBank_pc1;
			BANK_PC2 = _originalBank_pc2;
			BANK_PC3 = _originalBank_pc3;
			BANK_PC4 = _originalBank_pc4;
			BANK_PC5 = _originalBank_pc5;
			BANK_PC6 = _originalBank_pc6;
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
					new SqlParameter("BANK_CD",BANK_CD)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F080_BANK_MSTR_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F080_BANK_MSTR_Purge]");
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
						new SqlParameter("BANK_CD", SqlNull(BANK_CD)),
						new SqlParameter("BANK_NAME", SqlNull(BANK_NAME)),
						new SqlParameter("BANK_ADDRESS1", SqlNull(BANK_ADDRESS1)),
						new SqlParameter("BANK_ADDRESS2", SqlNull(BANK_ADDRESS2)),
						new SqlParameter("BANK_CITY", SqlNull(BANK_CITY)),
						new SqlParameter("BANK_PROV", SqlNull(BANK_PROV)),
						new SqlParameter("BANK_PC1", SqlNull(BANK_PC1)),
						new SqlParameter("BANK_PC2", SqlNull(BANK_PC2)),
						new SqlParameter("BANK_PC3", SqlNull(BANK_PC3)),
						new SqlParameter("BANK_PC4", SqlNull(BANK_PC4)),
						new SqlParameter("BANK_PC5", SqlNull(BANK_PC5)),
						new SqlParameter("BANK_PC6", SqlNull(BANK_PC6)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F080_BANK_MSTR_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						BANK_CD = Reader["BANK_CD"].ToString();
						BANK_NAME = Reader["BANK_NAME"].ToString();
						BANK_ADDRESS1 = Reader["BANK_ADDRESS1"].ToString();
						BANK_ADDRESS2 = Reader["BANK_ADDRESS2"].ToString();
						BANK_CITY = Reader["BANK_CITY"].ToString();
						BANK_PROV = Reader["BANK_PROV"].ToString();
						BANK_PC1 = Reader["BANK_PC1"].ToString();
						BANK_PC2 = ConvertDEC(Reader["BANK_PC2"]);
						BANK_PC3 = Reader["BANK_PC3"].ToString();
						BANK_PC4 = ConvertDEC(Reader["BANK_PC4"]);
						BANK_PC5 = Reader["BANK_PC5"].ToString();
						BANK_PC6 = ConvertDEC(Reader["BANK_PC6"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalBank_cd = Reader["BANK_CD"].ToString();
						_originalBank_name = Reader["BANK_NAME"].ToString();
						_originalBank_address1 = Reader["BANK_ADDRESS1"].ToString();
						_originalBank_address2 = Reader["BANK_ADDRESS2"].ToString();
						_originalBank_city = Reader["BANK_CITY"].ToString();
						_originalBank_prov = Reader["BANK_PROV"].ToString();
						_originalBank_pc1 = Reader["BANK_PC1"].ToString();
						_originalBank_pc2 = ConvertDEC(Reader["BANK_PC2"]);
						_originalBank_pc3 = Reader["BANK_PC3"].ToString();
						_originalBank_pc4 = ConvertDEC(Reader["BANK_PC4"]);
						_originalBank_pc5 = Reader["BANK_PC5"].ToString();
						_originalBank_pc6 = ConvertDEC(Reader["BANK_PC6"]);
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("BANK_CD", SqlNull(BANK_CD)),
						new SqlParameter("BANK_NAME", SqlNull(BANK_NAME)),
						new SqlParameter("BANK_ADDRESS1", SqlNull(BANK_ADDRESS1)),
						new SqlParameter("BANK_ADDRESS2", SqlNull(BANK_ADDRESS2)),
						new SqlParameter("BANK_CITY", SqlNull(BANK_CITY)),
						new SqlParameter("BANK_PROV", SqlNull(BANK_PROV)),
						new SqlParameter("BANK_PC1", SqlNull(BANK_PC1)),
						new SqlParameter("BANK_PC2", SqlNull(BANK_PC2)),
						new SqlParameter("BANK_PC3", SqlNull(BANK_PC3)),
						new SqlParameter("BANK_PC4", SqlNull(BANK_PC4)),
						new SqlParameter("BANK_PC5", SqlNull(BANK_PC5)),
						new SqlParameter("BANK_PC6", SqlNull(BANK_PC6)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F080_BANK_MSTR_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						BANK_CD = Reader["BANK_CD"].ToString();
						BANK_NAME = Reader["BANK_NAME"].ToString();
						BANK_ADDRESS1 = Reader["BANK_ADDRESS1"].ToString();
						BANK_ADDRESS2 = Reader["BANK_ADDRESS2"].ToString();
						BANK_CITY = Reader["BANK_CITY"].ToString();
						BANK_PROV = Reader["BANK_PROV"].ToString();
						BANK_PC1 = Reader["BANK_PC1"].ToString();
						BANK_PC2 = ConvertDEC(Reader["BANK_PC2"]);
						BANK_PC3 = Reader["BANK_PC3"].ToString();
						BANK_PC4 = ConvertDEC(Reader["BANK_PC4"]);
						BANK_PC5 = Reader["BANK_PC5"].ToString();
						BANK_PC6 = ConvertDEC(Reader["BANK_PC6"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalBank_cd = Reader["BANK_CD"].ToString();
						_originalBank_name = Reader["BANK_NAME"].ToString();
						_originalBank_address1 = Reader["BANK_ADDRESS1"].ToString();
						_originalBank_address2 = Reader["BANK_ADDRESS2"].ToString();
						_originalBank_city = Reader["BANK_CITY"].ToString();
						_originalBank_prov = Reader["BANK_PROV"].ToString();
						_originalBank_pc1 = Reader["BANK_PC1"].ToString();
						_originalBank_pc2 = ConvertDEC(Reader["BANK_PC2"]);
						_originalBank_pc3 = Reader["BANK_PC3"].ToString();
						_originalBank_pc4 = ConvertDEC(Reader["BANK_PC4"]);
						_originalBank_pc5 = Reader["BANK_PC5"].ToString();
						_originalBank_pc6 = ConvertDEC(Reader["BANK_PC6"]);
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