using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F200_OSCAR_PROVIDER : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F200_OSCAR_PROVIDER> Collection( Guid? rowid,
															string oscar_provider_no,
															string doc_nbr,
															decimal? doc_spec_cdmin,
															decimal? doc_spec_cdmax,
															string process_agent_0_flag,
															string process_agent_1_flag,
															string process_agent_2_flag,
															string process_agent_3_flag,
															string process_agent_4_flag,
															string process_agent_5_flag,
															string process_agent_6_flag,
															string process_agent_7_flag,
															string process_agent_8_flag,
															string process_agent_9_flag,
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
					new SqlParameter("OSCAR_PROVIDER_NO",oscar_provider_no),
					new SqlParameter("DOC_NBR",doc_nbr),
					new SqlParameter("minDOC_SPEC_CD",doc_spec_cdmin),
					new SqlParameter("maxDOC_SPEC_CD",doc_spec_cdmax),
					new SqlParameter("PROCESS_AGENT_0_FLAG",process_agent_0_flag),
					new SqlParameter("PROCESS_AGENT_1_FLAG",process_agent_1_flag),
					new SqlParameter("PROCESS_AGENT_2_FLAG",process_agent_2_flag),
					new SqlParameter("PROCESS_AGENT_3_FLAG",process_agent_3_flag),
					new SqlParameter("PROCESS_AGENT_4_FLAG",process_agent_4_flag),
					new SqlParameter("PROCESS_AGENT_5_FLAG",process_agent_5_flag),
					new SqlParameter("PROCESS_AGENT_6_FLAG",process_agent_6_flag),
					new SqlParameter("PROCESS_AGENT_7_FLAG",process_agent_7_flag),
					new SqlParameter("PROCESS_AGENT_8_FLAG",process_agent_8_flag),
					new SqlParameter("PROCESS_AGENT_9_FLAG",process_agent_9_flag),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F200_OSCAR_PROVIDER_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F200_OSCAR_PROVIDER>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F200_OSCAR_PROVIDER_Search]", parameters);
            var collection = new ObservableCollection<F200_OSCAR_PROVIDER>();

            while (Reader.Read())
            {
                collection.Add(new F200_OSCAR_PROVIDER
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					OSCAR_PROVIDER_NO = Reader["OSCAR_PROVIDER_NO"].ToString(),
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					DOC_SPEC_CD = ConvertDEC(Reader["DOC_SPEC_CD"]),
					PROCESS_AGENT_0_FLAG = Reader["PROCESS_AGENT_0_FLAG"].ToString(),
					PROCESS_AGENT_1_FLAG = Reader["PROCESS_AGENT_1_FLAG"].ToString(),
					PROCESS_AGENT_2_FLAG = Reader["PROCESS_AGENT_2_FLAG"].ToString(),
					PROCESS_AGENT_3_FLAG = Reader["PROCESS_AGENT_3_FLAG"].ToString(),
					PROCESS_AGENT_4_FLAG = Reader["PROCESS_AGENT_4_FLAG"].ToString(),
					PROCESS_AGENT_5_FLAG = Reader["PROCESS_AGENT_5_FLAG"].ToString(),
					PROCESS_AGENT_6_FLAG = Reader["PROCESS_AGENT_6_FLAG"].ToString(),
					PROCESS_AGENT_7_FLAG = Reader["PROCESS_AGENT_7_FLAG"].ToString(),
					PROCESS_AGENT_8_FLAG = Reader["PROCESS_AGENT_8_FLAG"].ToString(),
					PROCESS_AGENT_9_FLAG = Reader["PROCESS_AGENT_9_FLAG"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalOscar_provider_no = Reader["OSCAR_PROVIDER_NO"].ToString(),
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalDoc_spec_cd = ConvertDEC(Reader["DOC_SPEC_CD"]),
					_originalProcess_agent_0_flag = Reader["PROCESS_AGENT_0_FLAG"].ToString(),
					_originalProcess_agent_1_flag = Reader["PROCESS_AGENT_1_FLAG"].ToString(),
					_originalProcess_agent_2_flag = Reader["PROCESS_AGENT_2_FLAG"].ToString(),
					_originalProcess_agent_3_flag = Reader["PROCESS_AGENT_3_FLAG"].ToString(),
					_originalProcess_agent_4_flag = Reader["PROCESS_AGENT_4_FLAG"].ToString(),
					_originalProcess_agent_5_flag = Reader["PROCESS_AGENT_5_FLAG"].ToString(),
					_originalProcess_agent_6_flag = Reader["PROCESS_AGENT_6_FLAG"].ToString(),
					_originalProcess_agent_7_flag = Reader["PROCESS_AGENT_7_FLAG"].ToString(),
					_originalProcess_agent_8_flag = Reader["PROCESS_AGENT_8_FLAG"].ToString(),
					_originalProcess_agent_9_flag = Reader["PROCESS_AGENT_9_FLAG"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F200_OSCAR_PROVIDER Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F200_OSCAR_PROVIDER> Collection(ObservableCollection<F200_OSCAR_PROVIDER>
                                                               f200OscarProvider = null)
        {
            if (IsSameSearch() && f200OscarProvider != null)
            {
                return f200OscarProvider;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F200_OSCAR_PROVIDER>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("OSCAR_PROVIDER_NO",WhereOscar_provider_no),
					new SqlParameter("DOC_NBR",WhereDoc_nbr),
					new SqlParameter("DOC_SPEC_CD",WhereDoc_spec_cd),
					new SqlParameter("PROCESS_AGENT_0_FLAG",WhereProcess_agent_0_flag),
					new SqlParameter("PROCESS_AGENT_1_FLAG",WhereProcess_agent_1_flag),
					new SqlParameter("PROCESS_AGENT_2_FLAG",WhereProcess_agent_2_flag),
					new SqlParameter("PROCESS_AGENT_3_FLAG",WhereProcess_agent_3_flag),
					new SqlParameter("PROCESS_AGENT_4_FLAG",WhereProcess_agent_4_flag),
					new SqlParameter("PROCESS_AGENT_5_FLAG",WhereProcess_agent_5_flag),
					new SqlParameter("PROCESS_AGENT_6_FLAG",WhereProcess_agent_6_flag),
					new SqlParameter("PROCESS_AGENT_7_FLAG",WhereProcess_agent_7_flag),
					new SqlParameter("PROCESS_AGENT_8_FLAG",WhereProcess_agent_8_flag),
					new SqlParameter("PROCESS_AGENT_9_FLAG",WhereProcess_agent_9_flag),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F200_OSCAR_PROVIDER_Match]", parameters);
            var collection = new ObservableCollection<F200_OSCAR_PROVIDER>();

            while (Reader.Read())
            {
                collection.Add(new F200_OSCAR_PROVIDER
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					OSCAR_PROVIDER_NO = Reader["OSCAR_PROVIDER_NO"].ToString(),
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					DOC_SPEC_CD = ConvertDEC(Reader["DOC_SPEC_CD"]),
					PROCESS_AGENT_0_FLAG = Reader["PROCESS_AGENT_0_FLAG"].ToString(),
					PROCESS_AGENT_1_FLAG = Reader["PROCESS_AGENT_1_FLAG"].ToString(),
					PROCESS_AGENT_2_FLAG = Reader["PROCESS_AGENT_2_FLAG"].ToString(),
					PROCESS_AGENT_3_FLAG = Reader["PROCESS_AGENT_3_FLAG"].ToString(),
					PROCESS_AGENT_4_FLAG = Reader["PROCESS_AGENT_4_FLAG"].ToString(),
					PROCESS_AGENT_5_FLAG = Reader["PROCESS_AGENT_5_FLAG"].ToString(),
					PROCESS_AGENT_6_FLAG = Reader["PROCESS_AGENT_6_FLAG"].ToString(),
					PROCESS_AGENT_7_FLAG = Reader["PROCESS_AGENT_7_FLAG"].ToString(),
					PROCESS_AGENT_8_FLAG = Reader["PROCESS_AGENT_8_FLAG"].ToString(),
					PROCESS_AGENT_9_FLAG = Reader["PROCESS_AGENT_9_FLAG"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereOscar_provider_no = WhereOscar_provider_no,
					_whereDoc_nbr = WhereDoc_nbr,
					_whereDoc_spec_cd = WhereDoc_spec_cd,
					_whereProcess_agent_0_flag = WhereProcess_agent_0_flag,
					_whereProcess_agent_1_flag = WhereProcess_agent_1_flag,
					_whereProcess_agent_2_flag = WhereProcess_agent_2_flag,
					_whereProcess_agent_3_flag = WhereProcess_agent_3_flag,
					_whereProcess_agent_4_flag = WhereProcess_agent_4_flag,
					_whereProcess_agent_5_flag = WhereProcess_agent_5_flag,
					_whereProcess_agent_6_flag = WhereProcess_agent_6_flag,
					_whereProcess_agent_7_flag = WhereProcess_agent_7_flag,
					_whereProcess_agent_8_flag = WhereProcess_agent_8_flag,
					_whereProcess_agent_9_flag = WhereProcess_agent_9_flag,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalOscar_provider_no = Reader["OSCAR_PROVIDER_NO"].ToString(),
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalDoc_spec_cd = ConvertDEC(Reader["DOC_SPEC_CD"]),
					_originalProcess_agent_0_flag = Reader["PROCESS_AGENT_0_FLAG"].ToString(),
					_originalProcess_agent_1_flag = Reader["PROCESS_AGENT_1_FLAG"].ToString(),
					_originalProcess_agent_2_flag = Reader["PROCESS_AGENT_2_FLAG"].ToString(),
					_originalProcess_agent_3_flag = Reader["PROCESS_AGENT_3_FLAG"].ToString(),
					_originalProcess_agent_4_flag = Reader["PROCESS_AGENT_4_FLAG"].ToString(),
					_originalProcess_agent_5_flag = Reader["PROCESS_AGENT_5_FLAG"].ToString(),
					_originalProcess_agent_6_flag = Reader["PROCESS_AGENT_6_FLAG"].ToString(),
					_originalProcess_agent_7_flag = Reader["PROCESS_AGENT_7_FLAG"].ToString(),
					_originalProcess_agent_8_flag = Reader["PROCESS_AGENT_8_FLAG"].ToString(),
					_originalProcess_agent_9_flag = Reader["PROCESS_AGENT_9_FLAG"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereOscar_provider_no = WhereOscar_provider_no;
					_whereDoc_nbr = WhereDoc_nbr;
					_whereDoc_spec_cd = WhereDoc_spec_cd;
					_whereProcess_agent_0_flag = WhereProcess_agent_0_flag;
					_whereProcess_agent_1_flag = WhereProcess_agent_1_flag;
					_whereProcess_agent_2_flag = WhereProcess_agent_2_flag;
					_whereProcess_agent_3_flag = WhereProcess_agent_3_flag;
					_whereProcess_agent_4_flag = WhereProcess_agent_4_flag;
					_whereProcess_agent_5_flag = WhereProcess_agent_5_flag;
					_whereProcess_agent_6_flag = WhereProcess_agent_6_flag;
					_whereProcess_agent_7_flag = WhereProcess_agent_7_flag;
					_whereProcess_agent_8_flag = WhereProcess_agent_8_flag;
					_whereProcess_agent_9_flag = WhereProcess_agent_9_flag;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereOscar_provider_no == null 
				&& WhereDoc_nbr == null 
				&& WhereDoc_spec_cd == null 
				&& WhereProcess_agent_0_flag == null 
				&& WhereProcess_agent_1_flag == null 
				&& WhereProcess_agent_2_flag == null 
				&& WhereProcess_agent_3_flag == null 
				&& WhereProcess_agent_4_flag == null 
				&& WhereProcess_agent_5_flag == null 
				&& WhereProcess_agent_6_flag == null 
				&& WhereProcess_agent_7_flag == null 
				&& WhereProcess_agent_8_flag == null 
				&& WhereProcess_agent_9_flag == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereOscar_provider_no ==  _whereOscar_provider_no
				&& WhereDoc_nbr ==  _whereDoc_nbr
				&& WhereDoc_spec_cd ==  _whereDoc_spec_cd
				&& WhereProcess_agent_0_flag ==  _whereProcess_agent_0_flag
				&& WhereProcess_agent_1_flag ==  _whereProcess_agent_1_flag
				&& WhereProcess_agent_2_flag ==  _whereProcess_agent_2_flag
				&& WhereProcess_agent_3_flag ==  _whereProcess_agent_3_flag
				&& WhereProcess_agent_4_flag ==  _whereProcess_agent_4_flag
				&& WhereProcess_agent_5_flag ==  _whereProcess_agent_5_flag
				&& WhereProcess_agent_6_flag ==  _whereProcess_agent_6_flag
				&& WhereProcess_agent_7_flag ==  _whereProcess_agent_7_flag
				&& WhereProcess_agent_8_flag ==  _whereProcess_agent_8_flag
				&& WhereProcess_agent_9_flag ==  _whereProcess_agent_9_flag
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereOscar_provider_no = null; 
			WhereDoc_nbr = null; 
			WhereDoc_spec_cd = null; 
			WhereProcess_agent_0_flag = null; 
			WhereProcess_agent_1_flag = null; 
			WhereProcess_agent_2_flag = null; 
			WhereProcess_agent_3_flag = null; 
			WhereProcess_agent_4_flag = null; 
			WhereProcess_agent_5_flag = null; 
			WhereProcess_agent_6_flag = null; 
			WhereProcess_agent_7_flag = null; 
			WhereProcess_agent_8_flag = null; 
			WhereProcess_agent_9_flag = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _OSCAR_PROVIDER_NO;
		private string _DOC_NBR;
		private decimal? _DOC_SPEC_CD;
		private string _PROCESS_AGENT_0_FLAG;
		private string _PROCESS_AGENT_1_FLAG;
		private string _PROCESS_AGENT_2_FLAG;
		private string _PROCESS_AGENT_3_FLAG;
		private string _PROCESS_AGENT_4_FLAG;
		private string _PROCESS_AGENT_5_FLAG;
		private string _PROCESS_AGENT_6_FLAG;
		private string _PROCESS_AGENT_7_FLAG;
		private string _PROCESS_AGENT_8_FLAG;
		private string _PROCESS_AGENT_9_FLAG;
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
		public string OSCAR_PROVIDER_NO
		{
			get { return _OSCAR_PROVIDER_NO; }
			set
			{
				if (_OSCAR_PROVIDER_NO != value)
				{
					_OSCAR_PROVIDER_NO = value;
					ChangeState();
				}
			}
		}
		public string DOC_NBR
		{
			get { return _DOC_NBR; }
			set
			{
				if (_DOC_NBR != value)
				{
					_DOC_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_SPEC_CD
		{
			get { return _DOC_SPEC_CD; }
			set
			{
				if (_DOC_SPEC_CD != value)
				{
					_DOC_SPEC_CD = value;
					ChangeState();
				}
			}
		}
		public string PROCESS_AGENT_0_FLAG
		{
			get { return _PROCESS_AGENT_0_FLAG; }
			set
			{
				if (_PROCESS_AGENT_0_FLAG != value)
				{
					_PROCESS_AGENT_0_FLAG = value;
					ChangeState();
				}
			}
		}
		public string PROCESS_AGENT_1_FLAG
		{
			get { return _PROCESS_AGENT_1_FLAG; }
			set
			{
				if (_PROCESS_AGENT_1_FLAG != value)
				{
					_PROCESS_AGENT_1_FLAG = value;
					ChangeState();
				}
			}
		}
		public string PROCESS_AGENT_2_FLAG
		{
			get { return _PROCESS_AGENT_2_FLAG; }
			set
			{
				if (_PROCESS_AGENT_2_FLAG != value)
				{
					_PROCESS_AGENT_2_FLAG = value;
					ChangeState();
				}
			}
		}
		public string PROCESS_AGENT_3_FLAG
		{
			get { return _PROCESS_AGENT_3_FLAG; }
			set
			{
				if (_PROCESS_AGENT_3_FLAG != value)
				{
					_PROCESS_AGENT_3_FLAG = value;
					ChangeState();
				}
			}
		}
		public string PROCESS_AGENT_4_FLAG
		{
			get { return _PROCESS_AGENT_4_FLAG; }
			set
			{
				if (_PROCESS_AGENT_4_FLAG != value)
				{
					_PROCESS_AGENT_4_FLAG = value;
					ChangeState();
				}
			}
		}
		public string PROCESS_AGENT_5_FLAG
		{
			get { return _PROCESS_AGENT_5_FLAG; }
			set
			{
				if (_PROCESS_AGENT_5_FLAG != value)
				{
					_PROCESS_AGENT_5_FLAG = value;
					ChangeState();
				}
			}
		}
		public string PROCESS_AGENT_6_FLAG
		{
			get { return _PROCESS_AGENT_6_FLAG; }
			set
			{
				if (_PROCESS_AGENT_6_FLAG != value)
				{
					_PROCESS_AGENT_6_FLAG = value;
					ChangeState();
				}
			}
		}
		public string PROCESS_AGENT_7_FLAG
		{
			get { return _PROCESS_AGENT_7_FLAG; }
			set
			{
				if (_PROCESS_AGENT_7_FLAG != value)
				{
					_PROCESS_AGENT_7_FLAG = value;
					ChangeState();
				}
			}
		}
		public string PROCESS_AGENT_8_FLAG
		{
			get { return _PROCESS_AGENT_8_FLAG; }
			set
			{
				if (_PROCESS_AGENT_8_FLAG != value)
				{
					_PROCESS_AGENT_8_FLAG = value;
					ChangeState();
				}
			}
		}
		public string PROCESS_AGENT_9_FLAG
		{
			get { return _PROCESS_AGENT_9_FLAG; }
			set
			{
				if (_PROCESS_AGENT_9_FLAG != value)
				{
					_PROCESS_AGENT_9_FLAG = value;
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
		public string WhereOscar_provider_no { get; set; }
		private string _whereOscar_provider_no;
		public string WhereDoc_nbr { get; set; }
		private string _whereDoc_nbr;
		public decimal? WhereDoc_spec_cd { get; set; }
		private decimal? _whereDoc_spec_cd;
		public string WhereProcess_agent_0_flag { get; set; }
		private string _whereProcess_agent_0_flag;
		public string WhereProcess_agent_1_flag { get; set; }
		private string _whereProcess_agent_1_flag;
		public string WhereProcess_agent_2_flag { get; set; }
		private string _whereProcess_agent_2_flag;
		public string WhereProcess_agent_3_flag { get; set; }
		private string _whereProcess_agent_3_flag;
		public string WhereProcess_agent_4_flag { get; set; }
		private string _whereProcess_agent_4_flag;
		public string WhereProcess_agent_5_flag { get; set; }
		private string _whereProcess_agent_5_flag;
		public string WhereProcess_agent_6_flag { get; set; }
		private string _whereProcess_agent_6_flag;
		public string WhereProcess_agent_7_flag { get; set; }
		private string _whereProcess_agent_7_flag;
		public string WhereProcess_agent_8_flag { get; set; }
		private string _whereProcess_agent_8_flag;
		public string WhereProcess_agent_9_flag { get; set; }
		private string _whereProcess_agent_9_flag;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalOscar_provider_no;
		private string _originalDoc_nbr;
		private decimal? _originalDoc_spec_cd;
		private string _originalProcess_agent_0_flag;
		private string _originalProcess_agent_1_flag;
		private string _originalProcess_agent_2_flag;
		private string _originalProcess_agent_3_flag;
		private string _originalProcess_agent_4_flag;
		private string _originalProcess_agent_5_flag;
		private string _originalProcess_agent_6_flag;
		private string _originalProcess_agent_7_flag;
		private string _originalProcess_agent_8_flag;
		private string _originalProcess_agent_9_flag;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			OSCAR_PROVIDER_NO = _originalOscar_provider_no;
			DOC_NBR = _originalDoc_nbr;
			DOC_SPEC_CD = _originalDoc_spec_cd;
			PROCESS_AGENT_0_FLAG = _originalProcess_agent_0_flag;
			PROCESS_AGENT_1_FLAG = _originalProcess_agent_1_flag;
			PROCESS_AGENT_2_FLAG = _originalProcess_agent_2_flag;
			PROCESS_AGENT_3_FLAG = _originalProcess_agent_3_flag;
			PROCESS_AGENT_4_FLAG = _originalProcess_agent_4_flag;
			PROCESS_AGENT_5_FLAG = _originalProcess_agent_5_flag;
			PROCESS_AGENT_6_FLAG = _originalProcess_agent_6_flag;
			PROCESS_AGENT_7_FLAG = _originalProcess_agent_7_flag;
			PROCESS_AGENT_8_FLAG = _originalProcess_agent_8_flag;
			PROCESS_AGENT_9_FLAG = _originalProcess_agent_9_flag;
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
					new SqlParameter("OSCAR_PROVIDER_NO",OSCAR_PROVIDER_NO)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F200_OSCAR_PROVIDER_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F200_OSCAR_PROVIDER_Purge]");
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
						new SqlParameter("OSCAR_PROVIDER_NO", SqlNull(OSCAR_PROVIDER_NO)),
						new SqlParameter("DOC_NBR", SqlNull(DOC_NBR)),
						new SqlParameter("DOC_SPEC_CD", SqlNull(DOC_SPEC_CD)),
						new SqlParameter("PROCESS_AGENT_0_FLAG", SqlNull(PROCESS_AGENT_0_FLAG)),
						new SqlParameter("PROCESS_AGENT_1_FLAG", SqlNull(PROCESS_AGENT_1_FLAG)),
						new SqlParameter("PROCESS_AGENT_2_FLAG", SqlNull(PROCESS_AGENT_2_FLAG)),
						new SqlParameter("PROCESS_AGENT_3_FLAG", SqlNull(PROCESS_AGENT_3_FLAG)),
						new SqlParameter("PROCESS_AGENT_4_FLAG", SqlNull(PROCESS_AGENT_4_FLAG)),
						new SqlParameter("PROCESS_AGENT_5_FLAG", SqlNull(PROCESS_AGENT_5_FLAG)),
						new SqlParameter("PROCESS_AGENT_6_FLAG", SqlNull(PROCESS_AGENT_6_FLAG)),
						new SqlParameter("PROCESS_AGENT_7_FLAG", SqlNull(PROCESS_AGENT_7_FLAG)),
						new SqlParameter("PROCESS_AGENT_8_FLAG", SqlNull(PROCESS_AGENT_8_FLAG)),
						new SqlParameter("PROCESS_AGENT_9_FLAG", SqlNull(PROCESS_AGENT_9_FLAG)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F200_OSCAR_PROVIDER_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						OSCAR_PROVIDER_NO = Reader["OSCAR_PROVIDER_NO"].ToString();
						DOC_NBR = Reader["DOC_NBR"].ToString();
						DOC_SPEC_CD = ConvertDEC(Reader["DOC_SPEC_CD"]);
						PROCESS_AGENT_0_FLAG = Reader["PROCESS_AGENT_0_FLAG"].ToString();
						PROCESS_AGENT_1_FLAG = Reader["PROCESS_AGENT_1_FLAG"].ToString();
						PROCESS_AGENT_2_FLAG = Reader["PROCESS_AGENT_2_FLAG"].ToString();
						PROCESS_AGENT_3_FLAG = Reader["PROCESS_AGENT_3_FLAG"].ToString();
						PROCESS_AGENT_4_FLAG = Reader["PROCESS_AGENT_4_FLAG"].ToString();
						PROCESS_AGENT_5_FLAG = Reader["PROCESS_AGENT_5_FLAG"].ToString();
						PROCESS_AGENT_6_FLAG = Reader["PROCESS_AGENT_6_FLAG"].ToString();
						PROCESS_AGENT_7_FLAG = Reader["PROCESS_AGENT_7_FLAG"].ToString();
						PROCESS_AGENT_8_FLAG = Reader["PROCESS_AGENT_8_FLAG"].ToString();
						PROCESS_AGENT_9_FLAG = Reader["PROCESS_AGENT_9_FLAG"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalOscar_provider_no = Reader["OSCAR_PROVIDER_NO"].ToString();
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalDoc_spec_cd = ConvertDEC(Reader["DOC_SPEC_CD"]);
						_originalProcess_agent_0_flag = Reader["PROCESS_AGENT_0_FLAG"].ToString();
						_originalProcess_agent_1_flag = Reader["PROCESS_AGENT_1_FLAG"].ToString();
						_originalProcess_agent_2_flag = Reader["PROCESS_AGENT_2_FLAG"].ToString();
						_originalProcess_agent_3_flag = Reader["PROCESS_AGENT_3_FLAG"].ToString();
						_originalProcess_agent_4_flag = Reader["PROCESS_AGENT_4_FLAG"].ToString();
						_originalProcess_agent_5_flag = Reader["PROCESS_AGENT_5_FLAG"].ToString();
						_originalProcess_agent_6_flag = Reader["PROCESS_AGENT_6_FLAG"].ToString();
						_originalProcess_agent_7_flag = Reader["PROCESS_AGENT_7_FLAG"].ToString();
						_originalProcess_agent_8_flag = Reader["PROCESS_AGENT_8_FLAG"].ToString();
						_originalProcess_agent_9_flag = Reader["PROCESS_AGENT_9_FLAG"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("OSCAR_PROVIDER_NO", SqlNull(OSCAR_PROVIDER_NO)),
						new SqlParameter("DOC_NBR", SqlNull(DOC_NBR)),
						new SqlParameter("DOC_SPEC_CD", SqlNull(DOC_SPEC_CD)),
						new SqlParameter("PROCESS_AGENT_0_FLAG", SqlNull(PROCESS_AGENT_0_FLAG)),
						new SqlParameter("PROCESS_AGENT_1_FLAG", SqlNull(PROCESS_AGENT_1_FLAG)),
						new SqlParameter("PROCESS_AGENT_2_FLAG", SqlNull(PROCESS_AGENT_2_FLAG)),
						new SqlParameter("PROCESS_AGENT_3_FLAG", SqlNull(PROCESS_AGENT_3_FLAG)),
						new SqlParameter("PROCESS_AGENT_4_FLAG", SqlNull(PROCESS_AGENT_4_FLAG)),
						new SqlParameter("PROCESS_AGENT_5_FLAG", SqlNull(PROCESS_AGENT_5_FLAG)),
						new SqlParameter("PROCESS_AGENT_6_FLAG", SqlNull(PROCESS_AGENT_6_FLAG)),
						new SqlParameter("PROCESS_AGENT_7_FLAG", SqlNull(PROCESS_AGENT_7_FLAG)),
						new SqlParameter("PROCESS_AGENT_8_FLAG", SqlNull(PROCESS_AGENT_8_FLAG)),
						new SqlParameter("PROCESS_AGENT_9_FLAG", SqlNull(PROCESS_AGENT_9_FLAG)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F200_OSCAR_PROVIDER_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						OSCAR_PROVIDER_NO = Reader["OSCAR_PROVIDER_NO"].ToString();
						DOC_NBR = Reader["DOC_NBR"].ToString();
						DOC_SPEC_CD = ConvertDEC(Reader["DOC_SPEC_CD"]);
						PROCESS_AGENT_0_FLAG = Reader["PROCESS_AGENT_0_FLAG"].ToString();
						PROCESS_AGENT_1_FLAG = Reader["PROCESS_AGENT_1_FLAG"].ToString();
						PROCESS_AGENT_2_FLAG = Reader["PROCESS_AGENT_2_FLAG"].ToString();
						PROCESS_AGENT_3_FLAG = Reader["PROCESS_AGENT_3_FLAG"].ToString();
						PROCESS_AGENT_4_FLAG = Reader["PROCESS_AGENT_4_FLAG"].ToString();
						PROCESS_AGENT_5_FLAG = Reader["PROCESS_AGENT_5_FLAG"].ToString();
						PROCESS_AGENT_6_FLAG = Reader["PROCESS_AGENT_6_FLAG"].ToString();
						PROCESS_AGENT_7_FLAG = Reader["PROCESS_AGENT_7_FLAG"].ToString();
						PROCESS_AGENT_8_FLAG = Reader["PROCESS_AGENT_8_FLAG"].ToString();
						PROCESS_AGENT_9_FLAG = Reader["PROCESS_AGENT_9_FLAG"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalOscar_provider_no = Reader["OSCAR_PROVIDER_NO"].ToString();
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalDoc_spec_cd = ConvertDEC(Reader["DOC_SPEC_CD"]);
						_originalProcess_agent_0_flag = Reader["PROCESS_AGENT_0_FLAG"].ToString();
						_originalProcess_agent_1_flag = Reader["PROCESS_AGENT_1_FLAG"].ToString();
						_originalProcess_agent_2_flag = Reader["PROCESS_AGENT_2_FLAG"].ToString();
						_originalProcess_agent_3_flag = Reader["PROCESS_AGENT_3_FLAG"].ToString();
						_originalProcess_agent_4_flag = Reader["PROCESS_AGENT_4_FLAG"].ToString();
						_originalProcess_agent_5_flag = Reader["PROCESS_AGENT_5_FLAG"].ToString();
						_originalProcess_agent_6_flag = Reader["PROCESS_AGENT_6_FLAG"].ToString();
						_originalProcess_agent_7_flag = Reader["PROCESS_AGENT_7_FLAG"].ToString();
						_originalProcess_agent_8_flag = Reader["PROCESS_AGENT_8_FLAG"].ToString();
						_originalProcess_agent_9_flag = Reader["PROCESS_AGENT_9_FLAG"].ToString();
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