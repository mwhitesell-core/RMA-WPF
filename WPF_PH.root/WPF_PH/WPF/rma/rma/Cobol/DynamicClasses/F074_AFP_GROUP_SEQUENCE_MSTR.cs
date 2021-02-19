using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F074_AFP_GROUP_SEQUENCE_MSTR : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F074_AFP_GROUP_SEQUENCE_MSTR> Collection( Guid? rowid,
															string doc_afp_paym_group,
															string const_section,
															decimal? reporting_seqmin,
															decimal? reporting_seqmax,
															string total_flag,
															string nonrbp_flag,
															string solo_flag,
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
					new SqlParameter("DOC_AFP_PAYM_GROUP",doc_afp_paym_group),
					new SqlParameter("CONST_SECTION",const_section),
					new SqlParameter("minREPORTING_SEQ",reporting_seqmin),
					new SqlParameter("maxREPORTING_SEQ",reporting_seqmax),
					new SqlParameter("TOTAL_FLAG",total_flag),
					new SqlParameter("NONRBP_FLAG",nonrbp_flag),
					new SqlParameter("SOLO_FLAG",solo_flag),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F074_AFP_GROUP_SEQUENCE_MSTR_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F074_AFP_GROUP_SEQUENCE_MSTR>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F074_AFP_GROUP_SEQUENCE_MSTR_Search]", parameters);
            var collection = new ObservableCollection<F074_AFP_GROUP_SEQUENCE_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F074_AFP_GROUP_SEQUENCE_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOC_AFP_PAYM_GROUP = Reader["DOC_AFP_PAYM_GROUP"].ToString(),
					CONST_SECTION = Reader["CONST_SECTION"].ToString(),
					REPORTING_SEQ = ConvertDEC(Reader["REPORTING_SEQ"]),
					TOTAL_FLAG = Reader["TOTAL_FLAG"].ToString(),
					NONRBP_FLAG = Reader["NONRBP_FLAG"].ToString(),
					SOLO_FLAG = Reader["SOLO_FLAG"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDoc_afp_paym_group = Reader["DOC_AFP_PAYM_GROUP"].ToString(),
					_originalConst_section = Reader["CONST_SECTION"].ToString(),
					_originalReporting_seq = ConvertDEC(Reader["REPORTING_SEQ"]),
					_originalTotal_flag = Reader["TOTAL_FLAG"].ToString(),
					_originalNonrbp_flag = Reader["NONRBP_FLAG"].ToString(),
					_originalSolo_flag = Reader["SOLO_FLAG"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F074_AFP_GROUP_SEQUENCE_MSTR Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F074_AFP_GROUP_SEQUENCE_MSTR> Collection(ObservableCollection<F074_AFP_GROUP_SEQUENCE_MSTR>
                                                               f074AfpGroupSequenceMstr = null)
        {
            if (IsSameSearch() && f074AfpGroupSequenceMstr != null)
            {
                return f074AfpGroupSequenceMstr;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F074_AFP_GROUP_SEQUENCE_MSTR>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("DOC_AFP_PAYM_GROUP",WhereDoc_afp_paym_group),
					new SqlParameter("CONST_SECTION",WhereConst_section),
					new SqlParameter("REPORTING_SEQ",WhereReporting_seq),
					new SqlParameter("TOTAL_FLAG",WhereTotal_flag),
					new SqlParameter("NONRBP_FLAG",WhereNonrbp_flag),
					new SqlParameter("SOLO_FLAG",WhereSolo_flag),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F074_AFP_GROUP_SEQUENCE_MSTR_Match]", parameters);
            var collection = new ObservableCollection<F074_AFP_GROUP_SEQUENCE_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F074_AFP_GROUP_SEQUENCE_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOC_AFP_PAYM_GROUP = Reader["DOC_AFP_PAYM_GROUP"].ToString(),
					CONST_SECTION = Reader["CONST_SECTION"].ToString(),
					REPORTING_SEQ = ConvertDEC(Reader["REPORTING_SEQ"]),
					TOTAL_FLAG = Reader["TOTAL_FLAG"].ToString(),
					NONRBP_FLAG = Reader["NONRBP_FLAG"].ToString(),
					SOLO_FLAG = Reader["SOLO_FLAG"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereDoc_afp_paym_group = WhereDoc_afp_paym_group,
					_whereConst_section = WhereConst_section,
					_whereReporting_seq = WhereReporting_seq,
					_whereTotal_flag = WhereTotal_flag,
					_whereNonrbp_flag = WhereNonrbp_flag,
					_whereSolo_flag = WhereSolo_flag,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDoc_afp_paym_group = Reader["DOC_AFP_PAYM_GROUP"].ToString(),
					_originalConst_section = Reader["CONST_SECTION"].ToString(),
					_originalReporting_seq = ConvertDEC(Reader["REPORTING_SEQ"]),
					_originalTotal_flag = Reader["TOTAL_FLAG"].ToString(),
					_originalNonrbp_flag = Reader["NONRBP_FLAG"].ToString(),
					_originalSolo_flag = Reader["SOLO_FLAG"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereDoc_afp_paym_group = WhereDoc_afp_paym_group;
					_whereConst_section = WhereConst_section;
					_whereReporting_seq = WhereReporting_seq;
					_whereTotal_flag = WhereTotal_flag;
					_whereNonrbp_flag = WhereNonrbp_flag;
					_whereSolo_flag = WhereSolo_flag;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereDoc_afp_paym_group == null 
				&& WhereConst_section == null 
				&& WhereReporting_seq == null 
				&& WhereTotal_flag == null 
				&& WhereNonrbp_flag == null 
				&& WhereSolo_flag == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereDoc_afp_paym_group ==  _whereDoc_afp_paym_group
				&& WhereConst_section ==  _whereConst_section
				&& WhereReporting_seq ==  _whereReporting_seq
				&& WhereTotal_flag ==  _whereTotal_flag
				&& WhereNonrbp_flag ==  _whereNonrbp_flag
				&& WhereSolo_flag ==  _whereSolo_flag
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereDoc_afp_paym_group = null; 
			WhereConst_section = null; 
			WhereReporting_seq = null; 
			WhereTotal_flag = null; 
			WhereNonrbp_flag = null; 
			WhereSolo_flag = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _DOC_AFP_PAYM_GROUP;
		private string _CONST_SECTION;
		private decimal? _REPORTING_SEQ;
		private string _TOTAL_FLAG;
		private string _NONRBP_FLAG;
		private string _SOLO_FLAG;
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
		public string DOC_AFP_PAYM_GROUP
		{
			get { return _DOC_AFP_PAYM_GROUP; }
			set
			{
				if (_DOC_AFP_PAYM_GROUP != value)
				{
					_DOC_AFP_PAYM_GROUP = value;
					ChangeState();
				}
			}
		}
		public string CONST_SECTION
		{
			get { return _CONST_SECTION; }
			set
			{
				if (_CONST_SECTION != value)
				{
					_CONST_SECTION = value;
					ChangeState();
				}
			}
		}
		public decimal? REPORTING_SEQ
		{
			get { return _REPORTING_SEQ; }
			set
			{
				if (_REPORTING_SEQ != value)
				{
					_REPORTING_SEQ = value;
					ChangeState();
				}
			}
		}
		public string TOTAL_FLAG
		{
			get { return _TOTAL_FLAG; }
			set
			{
				if (_TOTAL_FLAG != value)
				{
					_TOTAL_FLAG = value;
					ChangeState();
				}
			}
		}
		public string NONRBP_FLAG
		{
			get { return _NONRBP_FLAG; }
			set
			{
				if (_NONRBP_FLAG != value)
				{
					_NONRBP_FLAG = value;
					ChangeState();
				}
			}
		}
		public string SOLO_FLAG
		{
			get { return _SOLO_FLAG; }
			set
			{
				if (_SOLO_FLAG != value)
				{
					_SOLO_FLAG = value;
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
		public string WhereDoc_afp_paym_group { get; set; }
		private string _whereDoc_afp_paym_group;
		public string WhereConst_section { get; set; }
		private string _whereConst_section;
		public decimal? WhereReporting_seq { get; set; }
		private decimal? _whereReporting_seq;
		public string WhereTotal_flag { get; set; }
		private string _whereTotal_flag;
		public string WhereNonrbp_flag { get; set; }
		private string _whereNonrbp_flag;
		public string WhereSolo_flag { get; set; }
		private string _whereSolo_flag;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalDoc_afp_paym_group;
		private string _originalConst_section;
		private decimal? _originalReporting_seq;
		private string _originalTotal_flag;
		private string _originalNonrbp_flag;
		private string _originalSolo_flag;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			DOC_AFP_PAYM_GROUP = _originalDoc_afp_paym_group;
			CONST_SECTION = _originalConst_section;
			REPORTING_SEQ = _originalReporting_seq;
			TOTAL_FLAG = _originalTotal_flag;
			NONRBP_FLAG = _originalNonrbp_flag;
			SOLO_FLAG = _originalSolo_flag;
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
					new SqlParameter("DOC_AFP_PAYM_GROUP",DOC_AFP_PAYM_GROUP)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F074_AFP_GROUP_SEQUENCE_MSTR_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F074_AFP_GROUP_SEQUENCE_MSTR_Purge]");
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
						new SqlParameter("DOC_AFP_PAYM_GROUP", SqlNull(DOC_AFP_PAYM_GROUP)),
						new SqlParameter("CONST_SECTION", SqlNull(CONST_SECTION)),
						new SqlParameter("REPORTING_SEQ", SqlNull(REPORTING_SEQ)),
						new SqlParameter("TOTAL_FLAG", SqlNull(TOTAL_FLAG)),
						new SqlParameter("NONRBP_FLAG", SqlNull(NONRBP_FLAG)),
						new SqlParameter("SOLO_FLAG", SqlNull(SOLO_FLAG)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F074_AFP_GROUP_SEQUENCE_MSTR_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOC_AFP_PAYM_GROUP = Reader["DOC_AFP_PAYM_GROUP"].ToString();
						CONST_SECTION = Reader["CONST_SECTION"].ToString();
						REPORTING_SEQ = ConvertDEC(Reader["REPORTING_SEQ"]);
						TOTAL_FLAG = Reader["TOTAL_FLAG"].ToString();
						NONRBP_FLAG = Reader["NONRBP_FLAG"].ToString();
						SOLO_FLAG = Reader["SOLO_FLAG"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDoc_afp_paym_group = Reader["DOC_AFP_PAYM_GROUP"].ToString();
						_originalConst_section = Reader["CONST_SECTION"].ToString();
						_originalReporting_seq = ConvertDEC(Reader["REPORTING_SEQ"]);
						_originalTotal_flag = Reader["TOTAL_FLAG"].ToString();
						_originalNonrbp_flag = Reader["NONRBP_FLAG"].ToString();
						_originalSolo_flag = Reader["SOLO_FLAG"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("DOC_AFP_PAYM_GROUP", SqlNull(DOC_AFP_PAYM_GROUP)),
						new SqlParameter("CONST_SECTION", SqlNull(CONST_SECTION)),
						new SqlParameter("REPORTING_SEQ", SqlNull(REPORTING_SEQ)),
						new SqlParameter("TOTAL_FLAG", SqlNull(TOTAL_FLAG)),
						new SqlParameter("NONRBP_FLAG", SqlNull(NONRBP_FLAG)),
						new SqlParameter("SOLO_FLAG", SqlNull(SOLO_FLAG)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F074_AFP_GROUP_SEQUENCE_MSTR_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOC_AFP_PAYM_GROUP = Reader["DOC_AFP_PAYM_GROUP"].ToString();
						CONST_SECTION = Reader["CONST_SECTION"].ToString();
						REPORTING_SEQ = ConvertDEC(Reader["REPORTING_SEQ"]);
						TOTAL_FLAG = Reader["TOTAL_FLAG"].ToString();
						NONRBP_FLAG = Reader["NONRBP_FLAG"].ToString();
						SOLO_FLAG = Reader["SOLO_FLAG"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDoc_afp_paym_group = Reader["DOC_AFP_PAYM_GROUP"].ToString();
						_originalConst_section = Reader["CONST_SECTION"].ToString();
						_originalReporting_seq = ConvertDEC(Reader["REPORTING_SEQ"]);
						_originalTotal_flag = Reader["TOTAL_FLAG"].ToString();
						_originalNonrbp_flag = Reader["NONRBP_FLAG"].ToString();
						_originalSolo_flag = Reader["SOLO_FLAG"].ToString();
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