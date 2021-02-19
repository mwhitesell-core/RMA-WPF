using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class CONTRACT_DTL : BaseTable
    {
        #region Retrieve

        public ObservableCollection<CONTRACT_DTL> Collection( Guid? rowid,
															decimal? clinic_nbrmin,
															decimal? clinic_nbrmax,
															decimal? agent_cdmin,
															decimal? agent_cdmax,
															string contract_code,
															string moh_flag,
															string dollar_flag,
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
					new SqlParameter("minCLINIC_NBR",clinic_nbrmin),
					new SqlParameter("maxCLINIC_NBR",clinic_nbrmax),
					new SqlParameter("minAGENT_CD",agent_cdmin),
					new SqlParameter("maxAGENT_CD",agent_cdmax),
					new SqlParameter("CONTRACT_CODE",contract_code),
					new SqlParameter("MOH_FLAG",moh_flag),
					new SqlParameter("DOLLAR_FLAG",dollar_flag),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_CONTRACT_DTL_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<CONTRACT_DTL>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_CONTRACT_DTL_Search]", parameters);
            var collection = new ObservableCollection<CONTRACT_DTL>();

            while (Reader.Read())
            {
                collection.Add(new CONTRACT_DTL
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLINIC_NBR = ConvertDEC(Reader["CLINIC_NBR"]),
					AGENT_CD = ConvertDEC(Reader["AGENT_CD"]),
					CONTRACT_CODE = Reader["CONTRACT_CODE"].ToString(),
					MOH_FLAG = Reader["MOH_FLAG"].ToString(),
					DOLLAR_FLAG = Reader["DOLLAR_FLAG"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClinic_nbr = ConvertDEC(Reader["CLINIC_NBR"]),
					_originalAgent_cd = ConvertDEC(Reader["AGENT_CD"]),
					_originalContract_code = Reader["CONTRACT_CODE"].ToString(),
					_originalMoh_flag = Reader["MOH_FLAG"].ToString(),
					_originalDollar_flag = Reader["DOLLAR_FLAG"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public CONTRACT_DTL Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<CONTRACT_DTL> Collection(ObservableCollection<CONTRACT_DTL>
                                                               contractDtl = null)
        {
            if (IsSameSearch() && contractDtl != null)
            {
                return contractDtl;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<CONTRACT_DTL>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("CLINIC_NBR",WhereClinic_nbr),
					new SqlParameter("AGENT_CD",WhereAgent_cd),
					new SqlParameter("CONTRACT_CODE",WhereContract_code),
					new SqlParameter("MOH_FLAG",WhereMoh_flag),
					new SqlParameter("DOLLAR_FLAG",WhereDollar_flag),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_CONTRACT_DTL_Match]", parameters);
            var collection = new ObservableCollection<CONTRACT_DTL>();

            while (Reader.Read())
            {
                collection.Add(new CONTRACT_DTL
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLINIC_NBR = ConvertDEC(Reader["CLINIC_NBR"]),
					AGENT_CD = ConvertDEC(Reader["AGENT_CD"]),
					CONTRACT_CODE = Reader["CONTRACT_CODE"].ToString(),
					MOH_FLAG = Reader["MOH_FLAG"].ToString(),
					DOLLAR_FLAG = Reader["DOLLAR_FLAG"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereClinic_nbr = WhereClinic_nbr,
					_whereAgent_cd = WhereAgent_cd,
					_whereContract_code = WhereContract_code,
					_whereMoh_flag = WhereMoh_flag,
					_whereDollar_flag = WhereDollar_flag,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClinic_nbr = ConvertDEC(Reader["CLINIC_NBR"]),
					_originalAgent_cd = ConvertDEC(Reader["AGENT_CD"]),
					_originalContract_code = Reader["CONTRACT_CODE"].ToString(),
					_originalMoh_flag = Reader["MOH_FLAG"].ToString(),
					_originalDollar_flag = Reader["DOLLAR_FLAG"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereClinic_nbr = WhereClinic_nbr;
					_whereAgent_cd = WhereAgent_cd;
					_whereContract_code = WhereContract_code;
					_whereMoh_flag = WhereMoh_flag;
					_whereDollar_flag = WhereDollar_flag;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereClinic_nbr == null 
				&& WhereAgent_cd == null 
				&& WhereContract_code == null 
				&& WhereMoh_flag == null 
				&& WhereDollar_flag == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereClinic_nbr ==  _whereClinic_nbr
				&& WhereAgent_cd ==  _whereAgent_cd
				&& WhereContract_code ==  _whereContract_code
				&& WhereMoh_flag ==  _whereMoh_flag
				&& WhereDollar_flag ==  _whereDollar_flag
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereClinic_nbr = null; 
			WhereAgent_cd = null; 
			WhereContract_code = null; 
			WhereMoh_flag = null; 
			WhereDollar_flag = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private decimal? _CLINIC_NBR;
		private decimal? _AGENT_CD;
		private string _CONTRACT_CODE;
		private string _MOH_FLAG;
		private string _DOLLAR_FLAG;
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
		public decimal? CLINIC_NBR
		{
			get { return _CLINIC_NBR; }
			set
			{
				if (_CLINIC_NBR != value)
				{
					_CLINIC_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? AGENT_CD
		{
			get { return _AGENT_CD; }
			set
			{
				if (_AGENT_CD != value)
				{
					_AGENT_CD = value;
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
		public string MOH_FLAG
		{
			get { return _MOH_FLAG; }
			set
			{
				if (_MOH_FLAG != value)
				{
					_MOH_FLAG = value;
					ChangeState();
				}
			}
		}
		public string DOLLAR_FLAG
		{
			get { return _DOLLAR_FLAG; }
			set
			{
				if (_DOLLAR_FLAG != value)
				{
					_DOLLAR_FLAG = value;
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
		public decimal? WhereClinic_nbr { get; set; }
		private decimal? _whereClinic_nbr;
		public decimal? WhereAgent_cd { get; set; }
		private decimal? _whereAgent_cd;
		public string WhereContract_code { get; set; }
		private string _whereContract_code;
		public string WhereMoh_flag { get; set; }
		private string _whereMoh_flag;
		public string WhereDollar_flag { get; set; }
		private string _whereDollar_flag;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private decimal? _originalClinic_nbr;
		private decimal? _originalAgent_cd;
		private string _originalContract_code;
		private string _originalMoh_flag;
		private string _originalDollar_flag;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			CLINIC_NBR = _originalClinic_nbr;
			AGENT_CD = _originalAgent_cd;
			CONTRACT_CODE = _originalContract_code;
			MOH_FLAG = _originalMoh_flag;
			DOLLAR_FLAG = _originalDollar_flag;
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
					new SqlParameter("CLINIC_NBR",CLINIC_NBR),
					new SqlParameter("AGENT_CD",AGENT_CD)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_CONTRACT_DTL_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_CONTRACT_DTL_Purge]");
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
						new SqlParameter("CLINIC_NBR", SqlNull(CLINIC_NBR)),
						new SqlParameter("AGENT_CD", SqlNull(AGENT_CD)),
						new SqlParameter("CONTRACT_CODE", SqlNull(CONTRACT_CODE)),
						new SqlParameter("MOH_FLAG", SqlNull(MOH_FLAG)),
						new SqlParameter("DOLLAR_FLAG", SqlNull(DOLLAR_FLAG)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_CONTRACT_DTL_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLINIC_NBR = ConvertDEC(Reader["CLINIC_NBR"]);
						AGENT_CD = ConvertDEC(Reader["AGENT_CD"]);
						CONTRACT_CODE = Reader["CONTRACT_CODE"].ToString();
						MOH_FLAG = Reader["MOH_FLAG"].ToString();
						DOLLAR_FLAG = Reader["DOLLAR_FLAG"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClinic_nbr = ConvertDEC(Reader["CLINIC_NBR"]);
						_originalAgent_cd = ConvertDEC(Reader["AGENT_CD"]);
						_originalContract_code = Reader["CONTRACT_CODE"].ToString();
						_originalMoh_flag = Reader["MOH_FLAG"].ToString();
						_originalDollar_flag = Reader["DOLLAR_FLAG"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("CLINIC_NBR", SqlNull(CLINIC_NBR)),
						new SqlParameter("AGENT_CD", SqlNull(AGENT_CD)),
						new SqlParameter("CONTRACT_CODE", SqlNull(CONTRACT_CODE)),
						new SqlParameter("MOH_FLAG", SqlNull(MOH_FLAG)),
						new SqlParameter("DOLLAR_FLAG", SqlNull(DOLLAR_FLAG)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_CONTRACT_DTL_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLINIC_NBR = ConvertDEC(Reader["CLINIC_NBR"]);
						AGENT_CD = ConvertDEC(Reader["AGENT_CD"]);
						CONTRACT_CODE = Reader["CONTRACT_CODE"].ToString();
						MOH_FLAG = Reader["MOH_FLAG"].ToString();
						DOLLAR_FLAG = Reader["DOLLAR_FLAG"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClinic_nbr = ConvertDEC(Reader["CLINIC_NBR"]);
						_originalAgent_cd = ConvertDEC(Reader["AGENT_CD"]);
						_originalContract_code = Reader["CONTRACT_CODE"].ToString();
						_originalMoh_flag = Reader["MOH_FLAG"].ToString();
						_originalDollar_flag = Reader["DOLLAR_FLAG"].ToString();
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