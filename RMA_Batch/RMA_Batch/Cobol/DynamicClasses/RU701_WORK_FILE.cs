using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class RU701_WORK_FILE : BaseTable
    {
        #region Retrieve

        public ObservableCollection<RU701_WORK_FILE> Collection( Guid? rowid,
															string doc_nbr,
															decimal? iconst_clinic_nbr_1_2min,
															decimal? iconst_clinic_nbr_1_2max,
															decimal? doc_spec_cdmin,
															decimal? doc_spec_cdmax,
															string clmhdr_pat_acronym,
															string clmhdr_accounting_nbr,
															decimal? orig_rec_nomin,
															decimal? orig_rec_nomax,
															string acronym_flag,
															string page_area,
															string pat_acronym,
															decimal? clmdtl_line_nomin,
															decimal? clmdtl_line_nomax,
															string print_line,
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
					new SqlParameter("DOC_NBR",doc_nbr),
					new SqlParameter("minICONST_CLINIC_NBR_1_2",iconst_clinic_nbr_1_2min),
					new SqlParameter("maxICONST_CLINIC_NBR_1_2",iconst_clinic_nbr_1_2max),
					new SqlParameter("minDOC_SPEC_CD",doc_spec_cdmin),
					new SqlParameter("maxDOC_SPEC_CD",doc_spec_cdmax),
					new SqlParameter("CLMHDR_PAT_ACRONYM",clmhdr_pat_acronym),
					new SqlParameter("CLMHDR_ACCOUNTING_NBR",clmhdr_accounting_nbr),
					new SqlParameter("minORIG_REC_NO",orig_rec_nomin),
					new SqlParameter("maxORIG_REC_NO",orig_rec_nomax),
					new SqlParameter("ACRONYM_FLAG",acronym_flag),
					new SqlParameter("PAGE_AREA",page_area),
					new SqlParameter("PAT_ACRONYM",pat_acronym),
					new SqlParameter("minCLMDTL_LINE_NO",clmdtl_line_nomin),
					new SqlParameter("maxCLMDTL_LINE_NO",clmdtl_line_nomax),
					new SqlParameter("PRINT_LINE",print_line),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[SEQUENTIAL].[sp_RU701_WORK_FILE_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<RU701_WORK_FILE>();
				}

            }

            Reader = CoreReader("[SEQUENTIAL].[sp_RU701_WORK_FILE_Search]", parameters);
            var collection = new ObservableCollection<RU701_WORK_FILE>();

            while (Reader.Read())
            {
                collection.Add(new RU701_WORK_FILE
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					ICONST_CLINIC_NBR_1_2 = ConvertDEC(Reader["ICONST_CLINIC_NBR_1_2"]),
					DOC_SPEC_CD = ConvertDEC(Reader["DOC_SPEC_CD"]),
					CLMHDR_PAT_ACRONYM = Reader["CLMHDR_PAT_ACRONYM"].ToString(),
					CLMHDR_ACCOUNTING_NBR = Reader["CLMHDR_ACCOUNTING_NBR"].ToString(),
					ORIG_REC_NO = ConvertDEC(Reader["ORIG_REC_NO"]),
					ACRONYM_FLAG = Reader["ACRONYM_FLAG"].ToString(),
					PAGE_AREA = Reader["PAGE_AREA"].ToString(),
					PAT_ACRONYM = Reader["PAT_ACRONYM"].ToString(),
					CLMDTL_LINE_NO = ConvertDEC(Reader["CLMDTL_LINE_NO"]),
					PRINT_LINE = Reader["PRINT_LINE"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalIconst_clinic_nbr_1_2 = ConvertDEC(Reader["ICONST_CLINIC_NBR_1_2"]),
					_originalDoc_spec_cd = ConvertDEC(Reader["DOC_SPEC_CD"]),
					_originalClmhdr_pat_acronym = Reader["CLMHDR_PAT_ACRONYM"].ToString(),
					_originalClmhdr_accounting_nbr = Reader["CLMHDR_ACCOUNTING_NBR"].ToString(),
					_originalOrig_rec_no = ConvertDEC(Reader["ORIG_REC_NO"]),
					_originalAcronym_flag = Reader["ACRONYM_FLAG"].ToString(),
					_originalPage_area = Reader["PAGE_AREA"].ToString(),
					_originalPat_acronym = Reader["PAT_ACRONYM"].ToString(),
					_originalClmdtl_line_no = ConvertDEC(Reader["CLMDTL_LINE_NO"]),
					_originalPrint_line = Reader["PRINT_LINE"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public RU701_WORK_FILE Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<RU701_WORK_FILE> Collection(ObservableCollection<RU701_WORK_FILE>
                                                               ru701WorkFile = null)
        {
            if (IsSameSearch() && ru701WorkFile != null)
            {
                return ru701WorkFile;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<RU701_WORK_FILE>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("DOC_NBR",WhereDoc_nbr),
					new SqlParameter("ICONST_CLINIC_NBR_1_2",WhereIconst_clinic_nbr_1_2),
					new SqlParameter("DOC_SPEC_CD",WhereDoc_spec_cd),
					new SqlParameter("CLMHDR_PAT_ACRONYM",WhereClmhdr_pat_acronym),
					new SqlParameter("CLMHDR_ACCOUNTING_NBR",WhereClmhdr_accounting_nbr),
					new SqlParameter("ORIG_REC_NO",WhereOrig_rec_no),
					new SqlParameter("ACRONYM_FLAG",WhereAcronym_flag),
					new SqlParameter("PAGE_AREA",WherePage_area),
					new SqlParameter("PAT_ACRONYM",WherePat_acronym),
					new SqlParameter("CLMDTL_LINE_NO",WhereClmdtl_line_no),
					new SqlParameter("PRINT_LINE",WherePrint_line),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[SEQUENTIAL].[sp_RU701_WORK_FILE_Match]", parameters);
            var collection = new ObservableCollection<RU701_WORK_FILE>();

            while (Reader.Read())
            {
                collection.Add(new RU701_WORK_FILE
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					ICONST_CLINIC_NBR_1_2 = ConvertDEC(Reader["ICONST_CLINIC_NBR_1_2"]),
					DOC_SPEC_CD = ConvertDEC(Reader["DOC_SPEC_CD"]),
					CLMHDR_PAT_ACRONYM = Reader["CLMHDR_PAT_ACRONYM"].ToString(),
					CLMHDR_ACCOUNTING_NBR = Reader["CLMHDR_ACCOUNTING_NBR"].ToString(),
					ORIG_REC_NO = ConvertDEC(Reader["ORIG_REC_NO"]),
					ACRONYM_FLAG = Reader["ACRONYM_FLAG"].ToString(),
					PAGE_AREA = Reader["PAGE_AREA"].ToString(),
					PAT_ACRONYM = Reader["PAT_ACRONYM"].ToString(),
					CLMDTL_LINE_NO = ConvertDEC(Reader["CLMDTL_LINE_NO"]),
					PRINT_LINE = Reader["PRINT_LINE"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereDoc_nbr = WhereDoc_nbr,
					_whereIconst_clinic_nbr_1_2 = WhereIconst_clinic_nbr_1_2,
					_whereDoc_spec_cd = WhereDoc_spec_cd,
					_whereClmhdr_pat_acronym = WhereClmhdr_pat_acronym,
					_whereClmhdr_accounting_nbr = WhereClmhdr_accounting_nbr,
					_whereOrig_rec_no = WhereOrig_rec_no,
					_whereAcronym_flag = WhereAcronym_flag,
					_wherePage_area = WherePage_area,
					_wherePat_acronym = WherePat_acronym,
					_whereClmdtl_line_no = WhereClmdtl_line_no,
					_wherePrint_line = WherePrint_line,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalIconst_clinic_nbr_1_2 = ConvertDEC(Reader["ICONST_CLINIC_NBR_1_2"]),
					_originalDoc_spec_cd = ConvertDEC(Reader["DOC_SPEC_CD"]),
					_originalClmhdr_pat_acronym = Reader["CLMHDR_PAT_ACRONYM"].ToString(),
					_originalClmhdr_accounting_nbr = Reader["CLMHDR_ACCOUNTING_NBR"].ToString(),
					_originalOrig_rec_no = ConvertDEC(Reader["ORIG_REC_NO"]),
					_originalAcronym_flag = Reader["ACRONYM_FLAG"].ToString(),
					_originalPage_area = Reader["PAGE_AREA"].ToString(),
					_originalPat_acronym = Reader["PAT_ACRONYM"].ToString(),
					_originalClmdtl_line_no = ConvertDEC(Reader["CLMDTL_LINE_NO"]),
					_originalPrint_line = Reader["PRINT_LINE"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereDoc_nbr = WhereDoc_nbr;
					_whereIconst_clinic_nbr_1_2 = WhereIconst_clinic_nbr_1_2;
					_whereDoc_spec_cd = WhereDoc_spec_cd;
					_whereClmhdr_pat_acronym = WhereClmhdr_pat_acronym;
					_whereClmhdr_accounting_nbr = WhereClmhdr_accounting_nbr;
					_whereOrig_rec_no = WhereOrig_rec_no;
					_whereAcronym_flag = WhereAcronym_flag;
					_wherePage_area = WherePage_area;
					_wherePat_acronym = WherePat_acronym;
					_whereClmdtl_line_no = WhereClmdtl_line_no;
					_wherePrint_line = WherePrint_line;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereDoc_nbr == null 
				&& WhereIconst_clinic_nbr_1_2 == null 
				&& WhereDoc_spec_cd == null 
				&& WhereClmhdr_pat_acronym == null 
				&& WhereClmhdr_accounting_nbr == null 
				&& WhereOrig_rec_no == null 
				&& WhereAcronym_flag == null 
				&& WherePage_area == null 
				&& WherePat_acronym == null 
				&& WhereClmdtl_line_no == null 
				&& WherePrint_line == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereDoc_nbr ==  _whereDoc_nbr
				&& WhereIconst_clinic_nbr_1_2 ==  _whereIconst_clinic_nbr_1_2
				&& WhereDoc_spec_cd ==  _whereDoc_spec_cd
				&& WhereClmhdr_pat_acronym ==  _whereClmhdr_pat_acronym
				&& WhereClmhdr_accounting_nbr ==  _whereClmhdr_accounting_nbr
				&& WhereOrig_rec_no ==  _whereOrig_rec_no
				&& WhereAcronym_flag ==  _whereAcronym_flag
				&& WherePage_area ==  _wherePage_area
				&& WherePat_acronym ==  _wherePat_acronym
				&& WhereClmdtl_line_no ==  _whereClmdtl_line_no
				&& WherePrint_line ==  _wherePrint_line
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereDoc_nbr = null; 
			WhereIconst_clinic_nbr_1_2 = null; 
			WhereDoc_spec_cd = null; 
			WhereClmhdr_pat_acronym = null; 
			WhereClmhdr_accounting_nbr = null; 
			WhereOrig_rec_no = null; 
			WhereAcronym_flag = null; 
			WherePage_area = null; 
			WherePat_acronym = null; 
			WhereClmdtl_line_no = null; 
			WherePrint_line = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _DOC_NBR;
		private decimal? _ICONST_CLINIC_NBR_1_2;
		private decimal? _DOC_SPEC_CD;
		private string _CLMHDR_PAT_ACRONYM;
		private string _CLMHDR_ACCOUNTING_NBR;
		private decimal? _ORIG_REC_NO;
		private string _ACRONYM_FLAG;
		private string _PAGE_AREA;
		private string _PAT_ACRONYM;
		private decimal? _CLMDTL_LINE_NO;
		private string _PRINT_LINE;
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
		public decimal? ICONST_CLINIC_NBR_1_2
		{
			get { return _ICONST_CLINIC_NBR_1_2; }
			set
			{
				if (_ICONST_CLINIC_NBR_1_2 != value)
				{
					_ICONST_CLINIC_NBR_1_2 = value;
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
		public string CLMHDR_PAT_ACRONYM
		{
			get { return _CLMHDR_PAT_ACRONYM; }
			set
			{
				if (_CLMHDR_PAT_ACRONYM != value)
				{
					_CLMHDR_PAT_ACRONYM = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_ACCOUNTING_NBR
		{
			get { return _CLMHDR_ACCOUNTING_NBR; }
			set
			{
				if (_CLMHDR_ACCOUNTING_NBR != value)
				{
					_CLMHDR_ACCOUNTING_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? ORIG_REC_NO
		{
			get { return _ORIG_REC_NO; }
			set
			{
				if (_ORIG_REC_NO != value)
				{
					_ORIG_REC_NO = value;
					ChangeState();
				}
			}
		}
		public string ACRONYM_FLAG
		{
			get { return _ACRONYM_FLAG; }
			set
			{
				if (_ACRONYM_FLAG != value)
				{
					_ACRONYM_FLAG = value;
					ChangeState();
				}
			}
		}
		public string PAGE_AREA
		{
			get { return _PAGE_AREA; }
			set
			{
				if (_PAGE_AREA != value)
				{
					_PAGE_AREA = value;
					ChangeState();
				}
			}
		}
		public string PAT_ACRONYM
		{
			get { return _PAT_ACRONYM; }
			set
			{
				if (_PAT_ACRONYM != value)
				{
					_PAT_ACRONYM = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMDTL_LINE_NO
		{
			get { return _CLMDTL_LINE_NO; }
			set
			{
				if (_CLMDTL_LINE_NO != value)
				{
					_CLMDTL_LINE_NO = value;
					ChangeState();
				}
			}
		}
		public string PRINT_LINE
		{
			get { return _PRINT_LINE; }
			set
			{
				if (_PRINT_LINE != value)
				{
					_PRINT_LINE = value;
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
		public string WhereDoc_nbr { get; set; }
		private string _whereDoc_nbr;
		public decimal? WhereIconst_clinic_nbr_1_2 { get; set; }
		private decimal? _whereIconst_clinic_nbr_1_2;
		public decimal? WhereDoc_spec_cd { get; set; }
		private decimal? _whereDoc_spec_cd;
		public string WhereClmhdr_pat_acronym { get; set; }
		private string _whereClmhdr_pat_acronym;
		public string WhereClmhdr_accounting_nbr { get; set; }
		private string _whereClmhdr_accounting_nbr;
		public decimal? WhereOrig_rec_no { get; set; }
		private decimal? _whereOrig_rec_no;
		public string WhereAcronym_flag { get; set; }
		private string _whereAcronym_flag;
		public string WherePage_area { get; set; }
		private string _wherePage_area;
		public string WherePat_acronym { get; set; }
		private string _wherePat_acronym;
		public decimal? WhereClmdtl_line_no { get; set; }
		private decimal? _whereClmdtl_line_no;
		public string WherePrint_line { get; set; }
		private string _wherePrint_line;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalDoc_nbr;
		private decimal? _originalIconst_clinic_nbr_1_2;
		private decimal? _originalDoc_spec_cd;
		private string _originalClmhdr_pat_acronym;
		private string _originalClmhdr_accounting_nbr;
		private decimal? _originalOrig_rec_no;
		private string _originalAcronym_flag;
		private string _originalPage_area;
		private string _originalPat_acronym;
		private decimal? _originalClmdtl_line_no;
		private string _originalPrint_line;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			DOC_NBR = _originalDoc_nbr;
			ICONST_CLINIC_NBR_1_2 = _originalIconst_clinic_nbr_1_2;
			DOC_SPEC_CD = _originalDoc_spec_cd;
			CLMHDR_PAT_ACRONYM = _originalClmhdr_pat_acronym;
			CLMHDR_ACCOUNTING_NBR = _originalClmhdr_accounting_nbr;
			ORIG_REC_NO = _originalOrig_rec_no;
			ACRONYM_FLAG = _originalAcronym_flag;
			PAGE_AREA = _originalPage_area;
			PAT_ACRONYM = _originalPat_acronym;
			CLMDTL_LINE_NO = _originalClmdtl_line_no;
			PRINT_LINE = _originalPrint_line;
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
					new SqlParameter("ROWID",ROWID)
				};
			RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_RU701_WORK_FILE_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_RU701_WORK_FILE_Purge]");
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
						new SqlParameter("DOC_NBR", SqlNull(DOC_NBR)),
						new SqlParameter("ICONST_CLINIC_NBR_1_2", SqlNull(ICONST_CLINIC_NBR_1_2)),
						new SqlParameter("DOC_SPEC_CD", SqlNull(DOC_SPEC_CD)),
						new SqlParameter("CLMHDR_PAT_ACRONYM", SqlNull(CLMHDR_PAT_ACRONYM)),
						new SqlParameter("CLMHDR_ACCOUNTING_NBR", SqlNull(CLMHDR_ACCOUNTING_NBR)),
						new SqlParameter("ORIG_REC_NO", SqlNull(ORIG_REC_NO)),
						new SqlParameter("ACRONYM_FLAG", SqlNull(ACRONYM_FLAG)),
						new SqlParameter("PAGE_AREA", SqlNull(PAGE_AREA)),
						new SqlParameter("PAT_ACRONYM", SqlNull(PAT_ACRONYM)),
						new SqlParameter("CLMDTL_LINE_NO", SqlNull(CLMDTL_LINE_NO)),
						new SqlParameter("PRINT_LINE", SqlNull(PRINT_LINE)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_RU701_WORK_FILE_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOC_NBR = Reader["DOC_NBR"].ToString();
						ICONST_CLINIC_NBR_1_2 = ConvertDEC(Reader["ICONST_CLINIC_NBR_1_2"]);
						DOC_SPEC_CD = ConvertDEC(Reader["DOC_SPEC_CD"]);
						CLMHDR_PAT_ACRONYM = Reader["CLMHDR_PAT_ACRONYM"].ToString();
						CLMHDR_ACCOUNTING_NBR = Reader["CLMHDR_ACCOUNTING_NBR"].ToString();
						ORIG_REC_NO = ConvertDEC(Reader["ORIG_REC_NO"]);
						ACRONYM_FLAG = Reader["ACRONYM_FLAG"].ToString();
						PAGE_AREA = Reader["PAGE_AREA"].ToString();
						PAT_ACRONYM = Reader["PAT_ACRONYM"].ToString();
						CLMDTL_LINE_NO = ConvertDEC(Reader["CLMDTL_LINE_NO"]);
						PRINT_LINE = Reader["PRINT_LINE"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalIconst_clinic_nbr_1_2 = ConvertDEC(Reader["ICONST_CLINIC_NBR_1_2"]);
						_originalDoc_spec_cd = ConvertDEC(Reader["DOC_SPEC_CD"]);
						_originalClmhdr_pat_acronym = Reader["CLMHDR_PAT_ACRONYM"].ToString();
						_originalClmhdr_accounting_nbr = Reader["CLMHDR_ACCOUNTING_NBR"].ToString();
						_originalOrig_rec_no = ConvertDEC(Reader["ORIG_REC_NO"]);
						_originalAcronym_flag = Reader["ACRONYM_FLAG"].ToString();
						_originalPage_area = Reader["PAGE_AREA"].ToString();
						_originalPat_acronym = Reader["PAT_ACRONYM"].ToString();
						_originalClmdtl_line_no = ConvertDEC(Reader["CLMDTL_LINE_NO"]);
						_originalPrint_line = Reader["PRINT_LINE"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("DOC_NBR", SqlNull(DOC_NBR)),
						new SqlParameter("ICONST_CLINIC_NBR_1_2", SqlNull(ICONST_CLINIC_NBR_1_2)),
						new SqlParameter("DOC_SPEC_CD", SqlNull(DOC_SPEC_CD)),
						new SqlParameter("CLMHDR_PAT_ACRONYM", SqlNull(CLMHDR_PAT_ACRONYM)),
						new SqlParameter("CLMHDR_ACCOUNTING_NBR", SqlNull(CLMHDR_ACCOUNTING_NBR)),
						new SqlParameter("ORIG_REC_NO", SqlNull(ORIG_REC_NO)),
						new SqlParameter("ACRONYM_FLAG", SqlNull(ACRONYM_FLAG)),
						new SqlParameter("PAGE_AREA", SqlNull(PAGE_AREA)),
						new SqlParameter("PAT_ACRONYM", SqlNull(PAT_ACRONYM)),
						new SqlParameter("CLMDTL_LINE_NO", SqlNull(CLMDTL_LINE_NO)),
						new SqlParameter("PRINT_LINE", SqlNull(PRINT_LINE)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_RU701_WORK_FILE_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOC_NBR = Reader["DOC_NBR"].ToString();
						ICONST_CLINIC_NBR_1_2 = ConvertDEC(Reader["ICONST_CLINIC_NBR_1_2"]);
						DOC_SPEC_CD = ConvertDEC(Reader["DOC_SPEC_CD"]);
						CLMHDR_PAT_ACRONYM = Reader["CLMHDR_PAT_ACRONYM"].ToString();
						CLMHDR_ACCOUNTING_NBR = Reader["CLMHDR_ACCOUNTING_NBR"].ToString();
						ORIG_REC_NO = ConvertDEC(Reader["ORIG_REC_NO"]);
						ACRONYM_FLAG = Reader["ACRONYM_FLAG"].ToString();
						PAGE_AREA = Reader["PAGE_AREA"].ToString();
						PAT_ACRONYM = Reader["PAT_ACRONYM"].ToString();
						CLMDTL_LINE_NO = ConvertDEC(Reader["CLMDTL_LINE_NO"]);
						PRINT_LINE = Reader["PRINT_LINE"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalIconst_clinic_nbr_1_2 = ConvertDEC(Reader["ICONST_CLINIC_NBR_1_2"]);
						_originalDoc_spec_cd = ConvertDEC(Reader["DOC_SPEC_CD"]);
						_originalClmhdr_pat_acronym = Reader["CLMHDR_PAT_ACRONYM"].ToString();
						_originalClmhdr_accounting_nbr = Reader["CLMHDR_ACCOUNTING_NBR"].ToString();
						_originalOrig_rec_no = ConvertDEC(Reader["ORIG_REC_NO"]);
						_originalAcronym_flag = Reader["ACRONYM_FLAG"].ToString();
						_originalPage_area = Reader["PAGE_AREA"].ToString();
						_originalPat_acronym = Reader["PAT_ACRONYM"].ToString();
						_originalClmdtl_line_no = ConvertDEC(Reader["CLMDTL_LINE_NO"]);
						_originalPrint_line = Reader["PRINT_LINE"].ToString();
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