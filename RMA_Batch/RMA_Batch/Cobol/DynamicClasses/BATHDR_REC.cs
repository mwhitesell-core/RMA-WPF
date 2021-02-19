using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class BATHDR_REC : BaseTable
    {
        #region Retrieve

        public ObservableCollection<BATHDR_REC> Collection( Guid? rowid,
															string bathdr_trans_id,
															string bathdr_rec_id,
															string bathdr_release_id,
															string bathdr_moh_cd,
															decimal? bathdr_batch_idmin,
															decimal? bathdr_batch_idmax,
															decimal? bathdr_oper_nummin,
															decimal? bathdr_oper_nummax,
															string bathdr_group_num,
															decimal? bathdr_provider_nummin,
															decimal? bathdr_provider_nummax,
															decimal? bathdr_specialty_cdmin,
															decimal? bathdr_specialty_cdmax,
															string bathdr_filler,
															string bathdr_def_batch_i_o_ind,
															string bathdr_def_batch_location,
															decimal? bathdr_clinic_1_2min,
															decimal? bathdr_clinic_1_2max,
															decimal? bathdr_deptmin,
															decimal? bathdr_deptmax,
															string bathdr_doc_nbr,
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
					new SqlParameter("BATHDR_TRANS_ID",bathdr_trans_id),
					new SqlParameter("BATHDR_REC_ID",bathdr_rec_id),
					new SqlParameter("BATHDR_RELEASE_ID",bathdr_release_id),
					new SqlParameter("BATHDR_MOH_CD",bathdr_moh_cd),
					new SqlParameter("minBATHDR_BATCH_ID",bathdr_batch_idmin),
					new SqlParameter("maxBATHDR_BATCH_ID",bathdr_batch_idmax),
					new SqlParameter("minBATHDR_OPER_NUM",bathdr_oper_nummin),
					new SqlParameter("maxBATHDR_OPER_NUM",bathdr_oper_nummax),
					new SqlParameter("BATHDR_GROUP_NUM",bathdr_group_num),
					new SqlParameter("minBATHDR_PROVIDER_NUM",bathdr_provider_nummin),
					new SqlParameter("maxBATHDR_PROVIDER_NUM",bathdr_provider_nummax),
					new SqlParameter("minBATHDR_SPECIALTY_CD",bathdr_specialty_cdmin),
					new SqlParameter("maxBATHDR_SPECIALTY_CD",bathdr_specialty_cdmax),
					new SqlParameter("BATHDR_FILLER",bathdr_filler),
					new SqlParameter("BATHDR_DEF_BATCH_I_O_IND",bathdr_def_batch_i_o_ind),
					new SqlParameter("BATHDR_DEF_BATCH_LOCATION",bathdr_def_batch_location),
					new SqlParameter("minBATHDR_CLINIC_1_2",bathdr_clinic_1_2min),
					new SqlParameter("maxBATHDR_CLINIC_1_2",bathdr_clinic_1_2max),
					new SqlParameter("minBATHDR_DEPT",bathdr_deptmin),
					new SqlParameter("maxBATHDR_DEPT",bathdr_deptmax),
					new SqlParameter("BATHDR_DOC_NBR",bathdr_doc_nbr),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[SEQUENTIAL].[sp_BATHDR_REC_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<BATHDR_REC>();
				}

            }

            Reader = CoreReader("[SEQUENTIAL].[sp_BATHDR_REC_Search]", parameters);
            var collection = new ObservableCollection<BATHDR_REC>();

            while (Reader.Read())
            {
                collection.Add(new BATHDR_REC
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					BATHDR_TRANS_ID = Reader["BATHDR_TRANS_ID"].ToString(),
					BATHDR_REC_ID = Reader["BATHDR_REC_ID"].ToString(),
					BATHDR_RELEASE_ID = Reader["BATHDR_RELEASE_ID"].ToString(),
					BATHDR_MOH_CD = Reader["BATHDR_MOH_CD"].ToString(),
					BATHDR_BATCH_ID = ConvertDEC(Reader["BATHDR_BATCH_ID"]),
					BATHDR_OPER_NUM = ConvertDEC(Reader["BATHDR_OPER_NUM"]),
					BATHDR_GROUP_NUM = Reader["BATHDR_GROUP_NUM"].ToString(),
					BATHDR_PROVIDER_NUM = ConvertDEC(Reader["BATHDR_PROVIDER_NUM"]),
					BATHDR_SPECIALTY_CD = ConvertDEC(Reader["BATHDR_SPECIALTY_CD"]),
					BATHDR_FILLER = Reader["BATHDR_FILLER"].ToString(),
					BATHDR_DEF_BATCH_I_O_IND = Reader["BATHDR_DEF_BATCH_I_O_IND"].ToString(),
					BATHDR_DEF_BATCH_LOCATION = Reader["BATHDR_DEF_BATCH_LOCATION"].ToString(),
					BATHDR_CLINIC_1_2 = ConvertDEC(Reader["BATHDR_CLINIC_1_2"]),
					BATHDR_DEPT = ConvertDEC(Reader["BATHDR_DEPT"]),
					BATHDR_DOC_NBR = Reader["BATHDR_DOC_NBR"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalBathdr_trans_id = Reader["BATHDR_TRANS_ID"].ToString(),
					_originalBathdr_rec_id = Reader["BATHDR_REC_ID"].ToString(),
					_originalBathdr_release_id = Reader["BATHDR_RELEASE_ID"].ToString(),
					_originalBathdr_moh_cd = Reader["BATHDR_MOH_CD"].ToString(),
					_originalBathdr_batch_id = ConvertDEC(Reader["BATHDR_BATCH_ID"]),
					_originalBathdr_oper_num = ConvertDEC(Reader["BATHDR_OPER_NUM"]),
					_originalBathdr_group_num = Reader["BATHDR_GROUP_NUM"].ToString(),
					_originalBathdr_provider_num = ConvertDEC(Reader["BATHDR_PROVIDER_NUM"]),
					_originalBathdr_specialty_cd = ConvertDEC(Reader["BATHDR_SPECIALTY_CD"]),
					_originalBathdr_filler = Reader["BATHDR_FILLER"].ToString(),
					_originalBathdr_def_batch_i_o_ind = Reader["BATHDR_DEF_BATCH_I_O_IND"].ToString(),
					_originalBathdr_def_batch_location = Reader["BATHDR_DEF_BATCH_LOCATION"].ToString(),
					_originalBathdr_clinic_1_2 = ConvertDEC(Reader["BATHDR_CLINIC_1_2"]),
					_originalBathdr_dept = ConvertDEC(Reader["BATHDR_DEPT"]),
					_originalBathdr_doc_nbr = Reader["BATHDR_DOC_NBR"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public BATHDR_REC Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<BATHDR_REC> Collection(ObservableCollection<BATHDR_REC>
                                                               bathdrRec = null)
        {
            if (IsSameSearch() && bathdrRec != null)
            {
                return bathdrRec;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<BATHDR_REC>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("BATHDR_TRANS_ID",WhereBathdr_trans_id),
					new SqlParameter("BATHDR_REC_ID",WhereBathdr_rec_id),
					new SqlParameter("BATHDR_RELEASE_ID",WhereBathdr_release_id),
					new SqlParameter("BATHDR_MOH_CD",WhereBathdr_moh_cd),
					new SqlParameter("BATHDR_BATCH_ID",WhereBathdr_batch_id),
					new SqlParameter("BATHDR_OPER_NUM",WhereBathdr_oper_num),
					new SqlParameter("BATHDR_GROUP_NUM",WhereBathdr_group_num),
					new SqlParameter("BATHDR_PROVIDER_NUM",WhereBathdr_provider_num),
					new SqlParameter("BATHDR_SPECIALTY_CD",WhereBathdr_specialty_cd),
					new SqlParameter("BATHDR_FILLER",WhereBathdr_filler),
					new SqlParameter("BATHDR_DEF_BATCH_I_O_IND",WhereBathdr_def_batch_i_o_ind),
					new SqlParameter("BATHDR_DEF_BATCH_LOCATION",WhereBathdr_def_batch_location),
					new SqlParameter("BATHDR_CLINIC_1_2",WhereBathdr_clinic_1_2),
					new SqlParameter("BATHDR_DEPT",WhereBathdr_dept),
					new SqlParameter("BATHDR_DOC_NBR",WhereBathdr_doc_nbr),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[SEQUENTIAL].[sp_BATHDR_REC_Match]", parameters);
            var collection = new ObservableCollection<BATHDR_REC>();

            while (Reader.Read())
            {
                collection.Add(new BATHDR_REC
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					BATHDR_TRANS_ID = Reader["BATHDR_TRANS_ID"].ToString(),
					BATHDR_REC_ID = Reader["BATHDR_REC_ID"].ToString(),
					BATHDR_RELEASE_ID = Reader["BATHDR_RELEASE_ID"].ToString(),
					BATHDR_MOH_CD = Reader["BATHDR_MOH_CD"].ToString(),
					BATHDR_BATCH_ID = ConvertDEC(Reader["BATHDR_BATCH_ID"]),
					BATHDR_OPER_NUM = ConvertDEC(Reader["BATHDR_OPER_NUM"]),
					BATHDR_GROUP_NUM = Reader["BATHDR_GROUP_NUM"].ToString(),
					BATHDR_PROVIDER_NUM = ConvertDEC(Reader["BATHDR_PROVIDER_NUM"]),
					BATHDR_SPECIALTY_CD = ConvertDEC(Reader["BATHDR_SPECIALTY_CD"]),
					BATHDR_FILLER = Reader["BATHDR_FILLER"].ToString(),
					BATHDR_DEF_BATCH_I_O_IND = Reader["BATHDR_DEF_BATCH_I_O_IND"].ToString(),
					BATHDR_DEF_BATCH_LOCATION = Reader["BATHDR_DEF_BATCH_LOCATION"].ToString(),
					BATHDR_CLINIC_1_2 = ConvertDEC(Reader["BATHDR_CLINIC_1_2"]),
					BATHDR_DEPT = ConvertDEC(Reader["BATHDR_DEPT"]),
					BATHDR_DOC_NBR = Reader["BATHDR_DOC_NBR"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereBathdr_trans_id = WhereBathdr_trans_id,
					_whereBathdr_rec_id = WhereBathdr_rec_id,
					_whereBathdr_release_id = WhereBathdr_release_id,
					_whereBathdr_moh_cd = WhereBathdr_moh_cd,
					_whereBathdr_batch_id = WhereBathdr_batch_id,
					_whereBathdr_oper_num = WhereBathdr_oper_num,
					_whereBathdr_group_num = WhereBathdr_group_num,
					_whereBathdr_provider_num = WhereBathdr_provider_num,
					_whereBathdr_specialty_cd = WhereBathdr_specialty_cd,
					_whereBathdr_filler = WhereBathdr_filler,
					_whereBathdr_def_batch_i_o_ind = WhereBathdr_def_batch_i_o_ind,
					_whereBathdr_def_batch_location = WhereBathdr_def_batch_location,
					_whereBathdr_clinic_1_2 = WhereBathdr_clinic_1_2,
					_whereBathdr_dept = WhereBathdr_dept,
					_whereBathdr_doc_nbr = WhereBathdr_doc_nbr,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalBathdr_trans_id = Reader["BATHDR_TRANS_ID"].ToString(),
					_originalBathdr_rec_id = Reader["BATHDR_REC_ID"].ToString(),
					_originalBathdr_release_id = Reader["BATHDR_RELEASE_ID"].ToString(),
					_originalBathdr_moh_cd = Reader["BATHDR_MOH_CD"].ToString(),
					_originalBathdr_batch_id = ConvertDEC(Reader["BATHDR_BATCH_ID"]),
					_originalBathdr_oper_num = ConvertDEC(Reader["BATHDR_OPER_NUM"]),
					_originalBathdr_group_num = Reader["BATHDR_GROUP_NUM"].ToString(),
					_originalBathdr_provider_num = ConvertDEC(Reader["BATHDR_PROVIDER_NUM"]),
					_originalBathdr_specialty_cd = ConvertDEC(Reader["BATHDR_SPECIALTY_CD"]),
					_originalBathdr_filler = Reader["BATHDR_FILLER"].ToString(),
					_originalBathdr_def_batch_i_o_ind = Reader["BATHDR_DEF_BATCH_I_O_IND"].ToString(),
					_originalBathdr_def_batch_location = Reader["BATHDR_DEF_BATCH_LOCATION"].ToString(),
					_originalBathdr_clinic_1_2 = ConvertDEC(Reader["BATHDR_CLINIC_1_2"]),
					_originalBathdr_dept = ConvertDEC(Reader["BATHDR_DEPT"]),
					_originalBathdr_doc_nbr = Reader["BATHDR_DOC_NBR"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereBathdr_trans_id = WhereBathdr_trans_id;
					_whereBathdr_rec_id = WhereBathdr_rec_id;
					_whereBathdr_release_id = WhereBathdr_release_id;
					_whereBathdr_moh_cd = WhereBathdr_moh_cd;
					_whereBathdr_batch_id = WhereBathdr_batch_id;
					_whereBathdr_oper_num = WhereBathdr_oper_num;
					_whereBathdr_group_num = WhereBathdr_group_num;
					_whereBathdr_provider_num = WhereBathdr_provider_num;
					_whereBathdr_specialty_cd = WhereBathdr_specialty_cd;
					_whereBathdr_filler = WhereBathdr_filler;
					_whereBathdr_def_batch_i_o_ind = WhereBathdr_def_batch_i_o_ind;
					_whereBathdr_def_batch_location = WhereBathdr_def_batch_location;
					_whereBathdr_clinic_1_2 = WhereBathdr_clinic_1_2;
					_whereBathdr_dept = WhereBathdr_dept;
					_whereBathdr_doc_nbr = WhereBathdr_doc_nbr;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereBathdr_trans_id == null 
				&& WhereBathdr_rec_id == null 
				&& WhereBathdr_release_id == null 
				&& WhereBathdr_moh_cd == null 
				&& WhereBathdr_batch_id == null 
				&& WhereBathdr_oper_num == null 
				&& WhereBathdr_group_num == null 
				&& WhereBathdr_provider_num == null 
				&& WhereBathdr_specialty_cd == null 
				&& WhereBathdr_filler == null 
				&& WhereBathdr_def_batch_i_o_ind == null 
				&& WhereBathdr_def_batch_location == null 
				&& WhereBathdr_clinic_1_2 == null 
				&& WhereBathdr_dept == null 
				&& WhereBathdr_doc_nbr == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereBathdr_trans_id ==  _whereBathdr_trans_id
				&& WhereBathdr_rec_id ==  _whereBathdr_rec_id
				&& WhereBathdr_release_id ==  _whereBathdr_release_id
				&& WhereBathdr_moh_cd ==  _whereBathdr_moh_cd
				&& WhereBathdr_batch_id ==  _whereBathdr_batch_id
				&& WhereBathdr_oper_num ==  _whereBathdr_oper_num
				&& WhereBathdr_group_num ==  _whereBathdr_group_num
				&& WhereBathdr_provider_num ==  _whereBathdr_provider_num
				&& WhereBathdr_specialty_cd ==  _whereBathdr_specialty_cd
				&& WhereBathdr_filler ==  _whereBathdr_filler
				&& WhereBathdr_def_batch_i_o_ind ==  _whereBathdr_def_batch_i_o_ind
				&& WhereBathdr_def_batch_location ==  _whereBathdr_def_batch_location
				&& WhereBathdr_clinic_1_2 ==  _whereBathdr_clinic_1_2
				&& WhereBathdr_dept ==  _whereBathdr_dept
				&& WhereBathdr_doc_nbr ==  _whereBathdr_doc_nbr
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereBathdr_trans_id = null; 
			WhereBathdr_rec_id = null; 
			WhereBathdr_release_id = null; 
			WhereBathdr_moh_cd = null; 
			WhereBathdr_batch_id = null; 
			WhereBathdr_oper_num = null; 
			WhereBathdr_group_num = null; 
			WhereBathdr_provider_num = null; 
			WhereBathdr_specialty_cd = null; 
			WhereBathdr_filler = null; 
			WhereBathdr_def_batch_i_o_ind = null; 
			WhereBathdr_def_batch_location = null; 
			WhereBathdr_clinic_1_2 = null; 
			WhereBathdr_dept = null; 
			WhereBathdr_doc_nbr = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _BATHDR_TRANS_ID;
		private string _BATHDR_REC_ID;
		private string _BATHDR_RELEASE_ID;
		private string _BATHDR_MOH_CD;
		private decimal? _BATHDR_BATCH_ID;
		private decimal? _BATHDR_OPER_NUM;
		private string _BATHDR_GROUP_NUM;
		private decimal? _BATHDR_PROVIDER_NUM;
		private decimal? _BATHDR_SPECIALTY_CD;
		private string _BATHDR_FILLER;
		private string _BATHDR_DEF_BATCH_I_O_IND;
		private string _BATHDR_DEF_BATCH_LOCATION;
		private decimal? _BATHDR_CLINIC_1_2;
		private decimal? _BATHDR_DEPT;
		private string _BATHDR_DOC_NBR;
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
		public string BATHDR_TRANS_ID
		{
			get { return _BATHDR_TRANS_ID; }
			set
			{
				if (_BATHDR_TRANS_ID != value)
				{
					_BATHDR_TRANS_ID = value;
					ChangeState();
				}
			}
		}
		public string BATHDR_REC_ID
		{
			get { return _BATHDR_REC_ID; }
			set
			{
				if (_BATHDR_REC_ID != value)
				{
					_BATHDR_REC_ID = value;
					ChangeState();
				}
			}
		}
		public string BATHDR_RELEASE_ID
		{
			get { return _BATHDR_RELEASE_ID; }
			set
			{
				if (_BATHDR_RELEASE_ID != value)
				{
					_BATHDR_RELEASE_ID = value;
					ChangeState();
				}
			}
		}
		public string BATHDR_MOH_CD
		{
			get { return _BATHDR_MOH_CD; }
			set
			{
				if (_BATHDR_MOH_CD != value)
				{
					_BATHDR_MOH_CD = value;
					ChangeState();
				}
			}
		}
		public decimal? BATHDR_BATCH_ID
		{
			get { return _BATHDR_BATCH_ID; }
			set
			{
				if (_BATHDR_BATCH_ID != value)
				{
					_BATHDR_BATCH_ID = value;
					ChangeState();
				}
			}
		}
		public decimal? BATHDR_OPER_NUM
		{
			get { return _BATHDR_OPER_NUM; }
			set
			{
				if (_BATHDR_OPER_NUM != value)
				{
					_BATHDR_OPER_NUM = value;
					ChangeState();
				}
			}
		}
		public string BATHDR_GROUP_NUM
		{
			get { return _BATHDR_GROUP_NUM; }
			set
			{
				if (_BATHDR_GROUP_NUM != value)
				{
					_BATHDR_GROUP_NUM = value;
					ChangeState();
				}
			}
		}
		public decimal? BATHDR_PROVIDER_NUM
		{
			get { return _BATHDR_PROVIDER_NUM; }
			set
			{
				if (_BATHDR_PROVIDER_NUM != value)
				{
					_BATHDR_PROVIDER_NUM = value;
					ChangeState();
				}
			}
		}
		public decimal? BATHDR_SPECIALTY_CD
		{
			get { return _BATHDR_SPECIALTY_CD; }
			set
			{
				if (_BATHDR_SPECIALTY_CD != value)
				{
					_BATHDR_SPECIALTY_CD = value;
					ChangeState();
				}
			}
		}
		public string BATHDR_FILLER
		{
			get { return _BATHDR_FILLER; }
			set
			{
				if (_BATHDR_FILLER != value)
				{
					_BATHDR_FILLER = value;
					ChangeState();
				}
			}
		}
		public string BATHDR_DEF_BATCH_I_O_IND
		{
			get { return _BATHDR_DEF_BATCH_I_O_IND; }
			set
			{
				if (_BATHDR_DEF_BATCH_I_O_IND != value)
				{
					_BATHDR_DEF_BATCH_I_O_IND = value;
					ChangeState();
				}
			}
		}
		public string BATHDR_DEF_BATCH_LOCATION
		{
			get { return _BATHDR_DEF_BATCH_LOCATION; }
			set
			{
				if (_BATHDR_DEF_BATCH_LOCATION != value)
				{
					_BATHDR_DEF_BATCH_LOCATION = value;
					ChangeState();
				}
			}
		}
		public decimal? BATHDR_CLINIC_1_2
		{
			get { return _BATHDR_CLINIC_1_2; }
			set
			{
				if (_BATHDR_CLINIC_1_2 != value)
				{
					_BATHDR_CLINIC_1_2 = value;
					ChangeState();
				}
			}
		}
		public decimal? BATHDR_DEPT
		{
			get { return _BATHDR_DEPT; }
			set
			{
				if (_BATHDR_DEPT != value)
				{
					_BATHDR_DEPT = value;
					ChangeState();
				}
			}
		}
		public string BATHDR_DOC_NBR
		{
			get { return _BATHDR_DOC_NBR; }
			set
			{
				if (_BATHDR_DOC_NBR != value)
				{
					_BATHDR_DOC_NBR = value;
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
		public string WhereBathdr_trans_id { get; set; }
		private string _whereBathdr_trans_id;
		public string WhereBathdr_rec_id { get; set; }
		private string _whereBathdr_rec_id;
		public string WhereBathdr_release_id { get; set; }
		private string _whereBathdr_release_id;
		public string WhereBathdr_moh_cd { get; set; }
		private string _whereBathdr_moh_cd;
		public decimal? WhereBathdr_batch_id { get; set; }
		private decimal? _whereBathdr_batch_id;
		public decimal? WhereBathdr_oper_num { get; set; }
		private decimal? _whereBathdr_oper_num;
		public string WhereBathdr_group_num { get; set; }
		private string _whereBathdr_group_num;
		public decimal? WhereBathdr_provider_num { get; set; }
		private decimal? _whereBathdr_provider_num;
		public decimal? WhereBathdr_specialty_cd { get; set; }
		private decimal? _whereBathdr_specialty_cd;
		public string WhereBathdr_filler { get; set; }
		private string _whereBathdr_filler;
		public string WhereBathdr_def_batch_i_o_ind { get; set; }
		private string _whereBathdr_def_batch_i_o_ind;
		public string WhereBathdr_def_batch_location { get; set; }
		private string _whereBathdr_def_batch_location;
		public decimal? WhereBathdr_clinic_1_2 { get; set; }
		private decimal? _whereBathdr_clinic_1_2;
		public decimal? WhereBathdr_dept { get; set; }
		private decimal? _whereBathdr_dept;
		public string WhereBathdr_doc_nbr { get; set; }
		private string _whereBathdr_doc_nbr;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalBathdr_trans_id;
		private string _originalBathdr_rec_id;
		private string _originalBathdr_release_id;
		private string _originalBathdr_moh_cd;
		private decimal? _originalBathdr_batch_id;
		private decimal? _originalBathdr_oper_num;
		private string _originalBathdr_group_num;
		private decimal? _originalBathdr_provider_num;
		private decimal? _originalBathdr_specialty_cd;
		private string _originalBathdr_filler;
		private string _originalBathdr_def_batch_i_o_ind;
		private string _originalBathdr_def_batch_location;
		private decimal? _originalBathdr_clinic_1_2;
		private decimal? _originalBathdr_dept;
		private string _originalBathdr_doc_nbr;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			BATHDR_TRANS_ID = _originalBathdr_trans_id;
			BATHDR_REC_ID = _originalBathdr_rec_id;
			BATHDR_RELEASE_ID = _originalBathdr_release_id;
			BATHDR_MOH_CD = _originalBathdr_moh_cd;
			BATHDR_BATCH_ID = _originalBathdr_batch_id;
			BATHDR_OPER_NUM = _originalBathdr_oper_num;
			BATHDR_GROUP_NUM = _originalBathdr_group_num;
			BATHDR_PROVIDER_NUM = _originalBathdr_provider_num;
			BATHDR_SPECIALTY_CD = _originalBathdr_specialty_cd;
			BATHDR_FILLER = _originalBathdr_filler;
			BATHDR_DEF_BATCH_I_O_IND = _originalBathdr_def_batch_i_o_ind;
			BATHDR_DEF_BATCH_LOCATION = _originalBathdr_def_batch_location;
			BATHDR_CLINIC_1_2 = _originalBathdr_clinic_1_2;
			BATHDR_DEPT = _originalBathdr_dept;
			BATHDR_DOC_NBR = _originalBathdr_doc_nbr;
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
			RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_BATHDR_REC_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_BATHDR_REC_Purge]");
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
						new SqlParameter("BATHDR_TRANS_ID", SqlNull(BATHDR_TRANS_ID)),
						new SqlParameter("BATHDR_REC_ID", SqlNull(BATHDR_REC_ID)),
						new SqlParameter("BATHDR_RELEASE_ID", SqlNull(BATHDR_RELEASE_ID)),
						new SqlParameter("BATHDR_MOH_CD", SqlNull(BATHDR_MOH_CD)),
						new SqlParameter("BATHDR_BATCH_ID", SqlNull(BATHDR_BATCH_ID)),
						new SqlParameter("BATHDR_OPER_NUM", SqlNull(BATHDR_OPER_NUM)),
						new SqlParameter("BATHDR_GROUP_NUM", SqlNull(BATHDR_GROUP_NUM)),
						new SqlParameter("BATHDR_PROVIDER_NUM", SqlNull(BATHDR_PROVIDER_NUM)),
						new SqlParameter("BATHDR_SPECIALTY_CD", SqlNull(BATHDR_SPECIALTY_CD)),
						new SqlParameter("BATHDR_FILLER", SqlNull(BATHDR_FILLER)),
						new SqlParameter("BATHDR_DEF_BATCH_I_O_IND", SqlNull(BATHDR_DEF_BATCH_I_O_IND)),
						new SqlParameter("BATHDR_DEF_BATCH_LOCATION", SqlNull(BATHDR_DEF_BATCH_LOCATION)),
						new SqlParameter("BATHDR_CLINIC_1_2", SqlNull(BATHDR_CLINIC_1_2)),
						new SqlParameter("BATHDR_DEPT", SqlNull(BATHDR_DEPT)),
						new SqlParameter("BATHDR_DOC_NBR", SqlNull(BATHDR_DOC_NBR)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_BATHDR_REC_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						BATHDR_TRANS_ID = Reader["BATHDR_TRANS_ID"].ToString();
						BATHDR_REC_ID = Reader["BATHDR_REC_ID"].ToString();
						BATHDR_RELEASE_ID = Reader["BATHDR_RELEASE_ID"].ToString();
						BATHDR_MOH_CD = Reader["BATHDR_MOH_CD"].ToString();
						BATHDR_BATCH_ID = ConvertDEC(Reader["BATHDR_BATCH_ID"]);
						BATHDR_OPER_NUM = ConvertDEC(Reader["BATHDR_OPER_NUM"]);
						BATHDR_GROUP_NUM = Reader["BATHDR_GROUP_NUM"].ToString();
						BATHDR_PROVIDER_NUM = ConvertDEC(Reader["BATHDR_PROVIDER_NUM"]);
						BATHDR_SPECIALTY_CD = ConvertDEC(Reader["BATHDR_SPECIALTY_CD"]);
						BATHDR_FILLER = Reader["BATHDR_FILLER"].ToString();
						BATHDR_DEF_BATCH_I_O_IND = Reader["BATHDR_DEF_BATCH_I_O_IND"].ToString();
						BATHDR_DEF_BATCH_LOCATION = Reader["BATHDR_DEF_BATCH_LOCATION"].ToString();
						BATHDR_CLINIC_1_2 = ConvertDEC(Reader["BATHDR_CLINIC_1_2"]);
						BATHDR_DEPT = ConvertDEC(Reader["BATHDR_DEPT"]);
						BATHDR_DOC_NBR = Reader["BATHDR_DOC_NBR"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalBathdr_trans_id = Reader["BATHDR_TRANS_ID"].ToString();
						_originalBathdr_rec_id = Reader["BATHDR_REC_ID"].ToString();
						_originalBathdr_release_id = Reader["BATHDR_RELEASE_ID"].ToString();
						_originalBathdr_moh_cd = Reader["BATHDR_MOH_CD"].ToString();
						_originalBathdr_batch_id = ConvertDEC(Reader["BATHDR_BATCH_ID"]);
						_originalBathdr_oper_num = ConvertDEC(Reader["BATHDR_OPER_NUM"]);
						_originalBathdr_group_num = Reader["BATHDR_GROUP_NUM"].ToString();
						_originalBathdr_provider_num = ConvertDEC(Reader["BATHDR_PROVIDER_NUM"]);
						_originalBathdr_specialty_cd = ConvertDEC(Reader["BATHDR_SPECIALTY_CD"]);
						_originalBathdr_filler = Reader["BATHDR_FILLER"].ToString();
						_originalBathdr_def_batch_i_o_ind = Reader["BATHDR_DEF_BATCH_I_O_IND"].ToString();
						_originalBathdr_def_batch_location = Reader["BATHDR_DEF_BATCH_LOCATION"].ToString();
						_originalBathdr_clinic_1_2 = ConvertDEC(Reader["BATHDR_CLINIC_1_2"]);
						_originalBathdr_dept = ConvertDEC(Reader["BATHDR_DEPT"]);
						_originalBathdr_doc_nbr = Reader["BATHDR_DOC_NBR"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("BATHDR_TRANS_ID", SqlNull(BATHDR_TRANS_ID)),
						new SqlParameter("BATHDR_REC_ID", SqlNull(BATHDR_REC_ID)),
						new SqlParameter("BATHDR_RELEASE_ID", SqlNull(BATHDR_RELEASE_ID)),
						new SqlParameter("BATHDR_MOH_CD", SqlNull(BATHDR_MOH_CD)),
						new SqlParameter("BATHDR_BATCH_ID", SqlNull(BATHDR_BATCH_ID)),
						new SqlParameter("BATHDR_OPER_NUM", SqlNull(BATHDR_OPER_NUM)),
						new SqlParameter("BATHDR_GROUP_NUM", SqlNull(BATHDR_GROUP_NUM)),
						new SqlParameter("BATHDR_PROVIDER_NUM", SqlNull(BATHDR_PROVIDER_NUM)),
						new SqlParameter("BATHDR_SPECIALTY_CD", SqlNull(BATHDR_SPECIALTY_CD)),
						new SqlParameter("BATHDR_FILLER", SqlNull(BATHDR_FILLER)),
						new SqlParameter("BATHDR_DEF_BATCH_I_O_IND", SqlNull(BATHDR_DEF_BATCH_I_O_IND)),
						new SqlParameter("BATHDR_DEF_BATCH_LOCATION", SqlNull(BATHDR_DEF_BATCH_LOCATION)),
						new SqlParameter("BATHDR_CLINIC_1_2", SqlNull(BATHDR_CLINIC_1_2)),
						new SqlParameter("BATHDR_DEPT", SqlNull(BATHDR_DEPT)),
						new SqlParameter("BATHDR_DOC_NBR", SqlNull(BATHDR_DOC_NBR)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_BATHDR_REC_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						BATHDR_TRANS_ID = Reader["BATHDR_TRANS_ID"].ToString();
						BATHDR_REC_ID = Reader["BATHDR_REC_ID"].ToString();
						BATHDR_RELEASE_ID = Reader["BATHDR_RELEASE_ID"].ToString();
						BATHDR_MOH_CD = Reader["BATHDR_MOH_CD"].ToString();
						BATHDR_BATCH_ID = ConvertDEC(Reader["BATHDR_BATCH_ID"]);
						BATHDR_OPER_NUM = ConvertDEC(Reader["BATHDR_OPER_NUM"]);
						BATHDR_GROUP_NUM = Reader["BATHDR_GROUP_NUM"].ToString();
						BATHDR_PROVIDER_NUM = ConvertDEC(Reader["BATHDR_PROVIDER_NUM"]);
						BATHDR_SPECIALTY_CD = ConvertDEC(Reader["BATHDR_SPECIALTY_CD"]);
						BATHDR_FILLER = Reader["BATHDR_FILLER"].ToString();
						BATHDR_DEF_BATCH_I_O_IND = Reader["BATHDR_DEF_BATCH_I_O_IND"].ToString();
						BATHDR_DEF_BATCH_LOCATION = Reader["BATHDR_DEF_BATCH_LOCATION"].ToString();
						BATHDR_CLINIC_1_2 = ConvertDEC(Reader["BATHDR_CLINIC_1_2"]);
						BATHDR_DEPT = ConvertDEC(Reader["BATHDR_DEPT"]);
						BATHDR_DOC_NBR = Reader["BATHDR_DOC_NBR"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalBathdr_trans_id = Reader["BATHDR_TRANS_ID"].ToString();
						_originalBathdr_rec_id = Reader["BATHDR_REC_ID"].ToString();
						_originalBathdr_release_id = Reader["BATHDR_RELEASE_ID"].ToString();
						_originalBathdr_moh_cd = Reader["BATHDR_MOH_CD"].ToString();
						_originalBathdr_batch_id = ConvertDEC(Reader["BATHDR_BATCH_ID"]);
						_originalBathdr_oper_num = ConvertDEC(Reader["BATHDR_OPER_NUM"]);
						_originalBathdr_group_num = Reader["BATHDR_GROUP_NUM"].ToString();
						_originalBathdr_provider_num = ConvertDEC(Reader["BATHDR_PROVIDER_NUM"]);
						_originalBathdr_specialty_cd = ConvertDEC(Reader["BATHDR_SPECIALTY_CD"]);
						_originalBathdr_filler = Reader["BATHDR_FILLER"].ToString();
						_originalBathdr_def_batch_i_o_ind = Reader["BATHDR_DEF_BATCH_I_O_IND"].ToString();
						_originalBathdr_def_batch_location = Reader["BATHDR_DEF_BATCH_LOCATION"].ToString();
						_originalBathdr_clinic_1_2 = ConvertDEC(Reader["BATHDR_CLINIC_1_2"]);
						_originalBathdr_dept = ConvertDEC(Reader["BATHDR_DEPT"]);
						_originalBathdr_doc_nbr = Reader["BATHDR_DOC_NBR"].ToString();
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