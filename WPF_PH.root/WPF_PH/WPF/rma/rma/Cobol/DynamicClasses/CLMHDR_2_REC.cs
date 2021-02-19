using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class CLMHDR_2_REC : BaseTable
    {
        #region Retrieve

        public ObservableCollection<CLMHDR_2_REC> Collection( Guid? rowid,
															string clmhdr_2_trans_id,
															string clmhdr_2_rec_id,
															string clmhdr_2_ohip_num,
															string clmhdr_2_pat_surname,
															string clmhdr_2_given_name,
															decimal? clmhdr_2_pat_sexmin,
															decimal? clmhdr_2_pat_sexmax,
															string clmhdr_2_prov_cd,
															string clmhdr_2_filler,
															string clmhdr_2_confidentiality_flag,
															string clmhdr_2_loc_code,
															string clmhdr_2_agent_cd,
															string clmhdr_2_i_o_ind,
															string clmhdr_2_phone_no,
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
					new SqlParameter("CLMHDR_2_TRANS_ID",clmhdr_2_trans_id),
					new SqlParameter("CLMHDR_2_REC_ID",clmhdr_2_rec_id),
					new SqlParameter("CLMHDR_2_OHIP_NUM",clmhdr_2_ohip_num),
					new SqlParameter("CLMHDR_2_PAT_SURNAME",clmhdr_2_pat_surname),
					new SqlParameter("CLMHDR_2_GIVEN_NAME",clmhdr_2_given_name),
					new SqlParameter("minCLMHDR_2_PAT_SEX",clmhdr_2_pat_sexmin),
					new SqlParameter("maxCLMHDR_2_PAT_SEX",clmhdr_2_pat_sexmax),
					new SqlParameter("CLMHDR_2_PROV_CD",clmhdr_2_prov_cd),
					new SqlParameter("CLMHDR_2_FILLER",clmhdr_2_filler),
					new SqlParameter("CLMHDR_2_CONFIDENTIALITY_FLAG",clmhdr_2_confidentiality_flag),
					new SqlParameter("CLMHDR_2_LOC_CODE",clmhdr_2_loc_code),
					new SqlParameter("CLMHDR_2_AGENT_CD",clmhdr_2_agent_cd),
					new SqlParameter("CLMHDR_2_I_O_IND",clmhdr_2_i_o_ind),
					new SqlParameter("CLMHDR_2_PHONE_NO",clmhdr_2_phone_no),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[SEQUENTIAL].[sp_CLMHDR_2_REC_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<CLMHDR_2_REC>();
				}

            }

            Reader = CoreReader("[SEQUENTIAL].[sp_CLMHDR_2_REC_Search]", parameters);
            var collection = new ObservableCollection<CLMHDR_2_REC>();

            while (Reader.Read())
            {
                collection.Add(new CLMHDR_2_REC
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLMHDR_2_TRANS_ID = Reader["CLMHDR_2_TRANS_ID"].ToString(),
					CLMHDR_2_REC_ID = Reader["CLMHDR_2_REC_ID"].ToString(),
					CLMHDR_2_OHIP_NUM = Reader["CLMHDR_2_OHIP_NUM"].ToString(),
					CLMHDR_2_PAT_SURNAME = Reader["CLMHDR_2_PAT_SURNAME"].ToString(),
					CLMHDR_2_GIVEN_NAME = Reader["CLMHDR_2_GIVEN_NAME"].ToString(),
					CLMHDR_2_PAT_SEX = ConvertDEC(Reader["CLMHDR_2_PAT_SEX"]),
					CLMHDR_2_PROV_CD = Reader["CLMHDR_2_PROV_CD"].ToString(),
					CLMHDR_2_FILLER = Reader["CLMHDR_2_FILLER"].ToString(),
					CLMHDR_2_CONFIDENTIALITY_FLAG = Reader["CLMHDR_2_CONFIDENTIALITY_FLAG"].ToString(),
					CLMHDR_2_LOC_CODE = Reader["CLMHDR_2_LOC_CODE"].ToString(),
					CLMHDR_2_AGENT_CD = Reader["CLMHDR_2_AGENT_CD"].ToString(),
					CLMHDR_2_I_O_IND = Reader["CLMHDR_2_I_O_IND"].ToString(),
					CLMHDR_2_PHONE_NO = Reader["CLMHDR_2_PHONE_NO"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClmhdr_2_trans_id = Reader["CLMHDR_2_TRANS_ID"].ToString(),
					_originalClmhdr_2_rec_id = Reader["CLMHDR_2_REC_ID"].ToString(),
					_originalClmhdr_2_ohip_num = Reader["CLMHDR_2_OHIP_NUM"].ToString(),
					_originalClmhdr_2_pat_surname = Reader["CLMHDR_2_PAT_SURNAME"].ToString(),
					_originalClmhdr_2_given_name = Reader["CLMHDR_2_GIVEN_NAME"].ToString(),
					_originalClmhdr_2_pat_sex = ConvertDEC(Reader["CLMHDR_2_PAT_SEX"]),
					_originalClmhdr_2_prov_cd = Reader["CLMHDR_2_PROV_CD"].ToString(),
					_originalClmhdr_2_filler = Reader["CLMHDR_2_FILLER"].ToString(),
					_originalClmhdr_2_confidentiality_flag = Reader["CLMHDR_2_CONFIDENTIALITY_FLAG"].ToString(),
					_originalClmhdr_2_loc_code = Reader["CLMHDR_2_LOC_CODE"].ToString(),
					_originalClmhdr_2_agent_cd = Reader["CLMHDR_2_AGENT_CD"].ToString(),
					_originalClmhdr_2_i_o_ind = Reader["CLMHDR_2_I_O_IND"].ToString(),
					_originalClmhdr_2_phone_no = Reader["CLMHDR_2_PHONE_NO"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public CLMHDR_2_REC Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<CLMHDR_2_REC> Collection(ObservableCollection<CLMHDR_2_REC>
                                                               clmhdr2Rec = null)
        {
            if (IsSameSearch() && clmhdr2Rec != null)
            {
                return clmhdr2Rec;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<CLMHDR_2_REC>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("CLMHDR_2_TRANS_ID",WhereClmhdr_2_trans_id),
					new SqlParameter("CLMHDR_2_REC_ID",WhereClmhdr_2_rec_id),
					new SqlParameter("CLMHDR_2_OHIP_NUM",WhereClmhdr_2_ohip_num),
					new SqlParameter("CLMHDR_2_PAT_SURNAME",WhereClmhdr_2_pat_surname),
					new SqlParameter("CLMHDR_2_GIVEN_NAME",WhereClmhdr_2_given_name),
					new SqlParameter("CLMHDR_2_PAT_SEX",WhereClmhdr_2_pat_sex),
					new SqlParameter("CLMHDR_2_PROV_CD",WhereClmhdr_2_prov_cd),
					new SqlParameter("CLMHDR_2_FILLER",WhereClmhdr_2_filler),
					new SqlParameter("CLMHDR_2_CONFIDENTIALITY_FLAG",WhereClmhdr_2_confidentiality_flag),
					new SqlParameter("CLMHDR_2_LOC_CODE",WhereClmhdr_2_loc_code),
					new SqlParameter("CLMHDR_2_AGENT_CD",WhereClmhdr_2_agent_cd),
					new SqlParameter("CLMHDR_2_I_O_IND",WhereClmhdr_2_i_o_ind),
					new SqlParameter("CLMHDR_2_PHONE_NO",WhereClmhdr_2_phone_no),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[SEQUENTIAL].[sp_CLMHDR_2_REC_Match]", parameters);
            var collection = new ObservableCollection<CLMHDR_2_REC>();

            while (Reader.Read())
            {
                collection.Add(new CLMHDR_2_REC
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLMHDR_2_TRANS_ID = Reader["CLMHDR_2_TRANS_ID"].ToString(),
					CLMHDR_2_REC_ID = Reader["CLMHDR_2_REC_ID"].ToString(),
					CLMHDR_2_OHIP_NUM = Reader["CLMHDR_2_OHIP_NUM"].ToString(),
					CLMHDR_2_PAT_SURNAME = Reader["CLMHDR_2_PAT_SURNAME"].ToString(),
					CLMHDR_2_GIVEN_NAME = Reader["CLMHDR_2_GIVEN_NAME"].ToString(),
					CLMHDR_2_PAT_SEX = ConvertDEC(Reader["CLMHDR_2_PAT_SEX"]),
					CLMHDR_2_PROV_CD = Reader["CLMHDR_2_PROV_CD"].ToString(),
					CLMHDR_2_FILLER = Reader["CLMHDR_2_FILLER"].ToString(),
					CLMHDR_2_CONFIDENTIALITY_FLAG = Reader["CLMHDR_2_CONFIDENTIALITY_FLAG"].ToString(),
					CLMHDR_2_LOC_CODE = Reader["CLMHDR_2_LOC_CODE"].ToString(),
					CLMHDR_2_AGENT_CD = Reader["CLMHDR_2_AGENT_CD"].ToString(),
					CLMHDR_2_I_O_IND = Reader["CLMHDR_2_I_O_IND"].ToString(),
					CLMHDR_2_PHONE_NO = Reader["CLMHDR_2_PHONE_NO"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereClmhdr_2_trans_id = WhereClmhdr_2_trans_id,
					_whereClmhdr_2_rec_id = WhereClmhdr_2_rec_id,
					_whereClmhdr_2_ohip_num = WhereClmhdr_2_ohip_num,
					_whereClmhdr_2_pat_surname = WhereClmhdr_2_pat_surname,
					_whereClmhdr_2_given_name = WhereClmhdr_2_given_name,
					_whereClmhdr_2_pat_sex = WhereClmhdr_2_pat_sex,
					_whereClmhdr_2_prov_cd = WhereClmhdr_2_prov_cd,
					_whereClmhdr_2_filler = WhereClmhdr_2_filler,
					_whereClmhdr_2_confidentiality_flag = WhereClmhdr_2_confidentiality_flag,
					_whereClmhdr_2_loc_code = WhereClmhdr_2_loc_code,
					_whereClmhdr_2_agent_cd = WhereClmhdr_2_agent_cd,
					_whereClmhdr_2_i_o_ind = WhereClmhdr_2_i_o_ind,
					_whereClmhdr_2_phone_no = WhereClmhdr_2_phone_no,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClmhdr_2_trans_id = Reader["CLMHDR_2_TRANS_ID"].ToString(),
					_originalClmhdr_2_rec_id = Reader["CLMHDR_2_REC_ID"].ToString(),
					_originalClmhdr_2_ohip_num = Reader["CLMHDR_2_OHIP_NUM"].ToString(),
					_originalClmhdr_2_pat_surname = Reader["CLMHDR_2_PAT_SURNAME"].ToString(),
					_originalClmhdr_2_given_name = Reader["CLMHDR_2_GIVEN_NAME"].ToString(),
					_originalClmhdr_2_pat_sex = ConvertDEC(Reader["CLMHDR_2_PAT_SEX"]),
					_originalClmhdr_2_prov_cd = Reader["CLMHDR_2_PROV_CD"].ToString(),
					_originalClmhdr_2_filler = Reader["CLMHDR_2_FILLER"].ToString(),
					_originalClmhdr_2_confidentiality_flag = Reader["CLMHDR_2_CONFIDENTIALITY_FLAG"].ToString(),
					_originalClmhdr_2_loc_code = Reader["CLMHDR_2_LOC_CODE"].ToString(),
					_originalClmhdr_2_agent_cd = Reader["CLMHDR_2_AGENT_CD"].ToString(),
					_originalClmhdr_2_i_o_ind = Reader["CLMHDR_2_I_O_IND"].ToString(),
					_originalClmhdr_2_phone_no = Reader["CLMHDR_2_PHONE_NO"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereClmhdr_2_trans_id = WhereClmhdr_2_trans_id;
					_whereClmhdr_2_rec_id = WhereClmhdr_2_rec_id;
					_whereClmhdr_2_ohip_num = WhereClmhdr_2_ohip_num;
					_whereClmhdr_2_pat_surname = WhereClmhdr_2_pat_surname;
					_whereClmhdr_2_given_name = WhereClmhdr_2_given_name;
					_whereClmhdr_2_pat_sex = WhereClmhdr_2_pat_sex;
					_whereClmhdr_2_prov_cd = WhereClmhdr_2_prov_cd;
					_whereClmhdr_2_filler = WhereClmhdr_2_filler;
					_whereClmhdr_2_confidentiality_flag = WhereClmhdr_2_confidentiality_flag;
					_whereClmhdr_2_loc_code = WhereClmhdr_2_loc_code;
					_whereClmhdr_2_agent_cd = WhereClmhdr_2_agent_cd;
					_whereClmhdr_2_i_o_ind = WhereClmhdr_2_i_o_ind;
					_whereClmhdr_2_phone_no = WhereClmhdr_2_phone_no;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereClmhdr_2_trans_id == null 
				&& WhereClmhdr_2_rec_id == null 
				&& WhereClmhdr_2_ohip_num == null 
				&& WhereClmhdr_2_pat_surname == null 
				&& WhereClmhdr_2_given_name == null 
				&& WhereClmhdr_2_pat_sex == null 
				&& WhereClmhdr_2_prov_cd == null 
				&& WhereClmhdr_2_filler == null 
				&& WhereClmhdr_2_confidentiality_flag == null 
				&& WhereClmhdr_2_loc_code == null 
				&& WhereClmhdr_2_agent_cd == null 
				&& WhereClmhdr_2_i_o_ind == null 
				&& WhereClmhdr_2_phone_no == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereClmhdr_2_trans_id ==  _whereClmhdr_2_trans_id
				&& WhereClmhdr_2_rec_id ==  _whereClmhdr_2_rec_id
				&& WhereClmhdr_2_ohip_num ==  _whereClmhdr_2_ohip_num
				&& WhereClmhdr_2_pat_surname ==  _whereClmhdr_2_pat_surname
				&& WhereClmhdr_2_given_name ==  _whereClmhdr_2_given_name
				&& WhereClmhdr_2_pat_sex ==  _whereClmhdr_2_pat_sex
				&& WhereClmhdr_2_prov_cd ==  _whereClmhdr_2_prov_cd
				&& WhereClmhdr_2_filler ==  _whereClmhdr_2_filler
				&& WhereClmhdr_2_confidentiality_flag ==  _whereClmhdr_2_confidentiality_flag
				&& WhereClmhdr_2_loc_code ==  _whereClmhdr_2_loc_code
				&& WhereClmhdr_2_agent_cd ==  _whereClmhdr_2_agent_cd
				&& WhereClmhdr_2_i_o_ind ==  _whereClmhdr_2_i_o_ind
				&& WhereClmhdr_2_phone_no ==  _whereClmhdr_2_phone_no
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereClmhdr_2_trans_id = null; 
			WhereClmhdr_2_rec_id = null; 
			WhereClmhdr_2_ohip_num = null; 
			WhereClmhdr_2_pat_surname = null; 
			WhereClmhdr_2_given_name = null; 
			WhereClmhdr_2_pat_sex = null; 
			WhereClmhdr_2_prov_cd = null; 
			WhereClmhdr_2_filler = null; 
			WhereClmhdr_2_confidentiality_flag = null; 
			WhereClmhdr_2_loc_code = null; 
			WhereClmhdr_2_agent_cd = null; 
			WhereClmhdr_2_i_o_ind = null; 
			WhereClmhdr_2_phone_no = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _CLMHDR_2_TRANS_ID;
		private string _CLMHDR_2_REC_ID;
		private string _CLMHDR_2_OHIP_NUM;
		private string _CLMHDR_2_PAT_SURNAME;
		private string _CLMHDR_2_GIVEN_NAME;
		private decimal? _CLMHDR_2_PAT_SEX;
		private string _CLMHDR_2_PROV_CD;
		private string _CLMHDR_2_FILLER;
		private string _CLMHDR_2_CONFIDENTIALITY_FLAG;
		private string _CLMHDR_2_LOC_CODE;
		private string _CLMHDR_2_AGENT_CD;
		private string _CLMHDR_2_I_O_IND;
		private string _CLMHDR_2_PHONE_NO;
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
		public string CLMHDR_2_TRANS_ID
		{
			get { return _CLMHDR_2_TRANS_ID; }
			set
			{
				if (_CLMHDR_2_TRANS_ID != value)
				{
					_CLMHDR_2_TRANS_ID = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_2_REC_ID
		{
			get { return _CLMHDR_2_REC_ID; }
			set
			{
				if (_CLMHDR_2_REC_ID != value)
				{
					_CLMHDR_2_REC_ID = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_2_OHIP_NUM
		{
			get { return _CLMHDR_2_OHIP_NUM; }
			set
			{
				if (_CLMHDR_2_OHIP_NUM != value)
				{
					_CLMHDR_2_OHIP_NUM = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_2_PAT_SURNAME
		{
			get { return _CLMHDR_2_PAT_SURNAME; }
			set
			{
				if (_CLMHDR_2_PAT_SURNAME != value)
				{
					_CLMHDR_2_PAT_SURNAME = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_2_GIVEN_NAME
		{
			get { return _CLMHDR_2_GIVEN_NAME; }
			set
			{
				if (_CLMHDR_2_GIVEN_NAME != value)
				{
					_CLMHDR_2_GIVEN_NAME = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_2_PAT_SEX
		{
			get { return _CLMHDR_2_PAT_SEX; }
			set
			{
				if (_CLMHDR_2_PAT_SEX != value)
				{
					_CLMHDR_2_PAT_SEX = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_2_PROV_CD
		{
			get { return _CLMHDR_2_PROV_CD; }
			set
			{
				if (_CLMHDR_2_PROV_CD != value)
				{
					_CLMHDR_2_PROV_CD = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_2_FILLER
		{
			get { return _CLMHDR_2_FILLER; }
			set
			{
				if (_CLMHDR_2_FILLER != value)
				{
					_CLMHDR_2_FILLER = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_2_CONFIDENTIALITY_FLAG
		{
			get { return _CLMHDR_2_CONFIDENTIALITY_FLAG; }
			set
			{
				if (_CLMHDR_2_CONFIDENTIALITY_FLAG != value)
				{
					_CLMHDR_2_CONFIDENTIALITY_FLAG = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_2_LOC_CODE
		{
			get { return _CLMHDR_2_LOC_CODE; }
			set
			{
				if (_CLMHDR_2_LOC_CODE != value)
				{
					_CLMHDR_2_LOC_CODE = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_2_AGENT_CD
		{
			get { return _CLMHDR_2_AGENT_CD; }
			set
			{
				if (_CLMHDR_2_AGENT_CD != value)
				{
					_CLMHDR_2_AGENT_CD = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_2_I_O_IND
		{
			get { return _CLMHDR_2_I_O_IND; }
			set
			{
				if (_CLMHDR_2_I_O_IND != value)
				{
					_CLMHDR_2_I_O_IND = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_2_PHONE_NO
		{
			get { return _CLMHDR_2_PHONE_NO; }
			set
			{
				if (_CLMHDR_2_PHONE_NO != value)
				{
					_CLMHDR_2_PHONE_NO = value;
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
		public string WhereClmhdr_2_trans_id { get; set; }
		private string _whereClmhdr_2_trans_id;
		public string WhereClmhdr_2_rec_id { get; set; }
		private string _whereClmhdr_2_rec_id;
		public string WhereClmhdr_2_ohip_num { get; set; }
		private string _whereClmhdr_2_ohip_num;
		public string WhereClmhdr_2_pat_surname { get; set; }
		private string _whereClmhdr_2_pat_surname;
		public string WhereClmhdr_2_given_name { get; set; }
		private string _whereClmhdr_2_given_name;
		public decimal? WhereClmhdr_2_pat_sex { get; set; }
		private decimal? _whereClmhdr_2_pat_sex;
		public string WhereClmhdr_2_prov_cd { get; set; }
		private string _whereClmhdr_2_prov_cd;
		public string WhereClmhdr_2_filler { get; set; }
		private string _whereClmhdr_2_filler;
		public string WhereClmhdr_2_confidentiality_flag { get; set; }
		private string _whereClmhdr_2_confidentiality_flag;
		public string WhereClmhdr_2_loc_code { get; set; }
		private string _whereClmhdr_2_loc_code;
		public string WhereClmhdr_2_agent_cd { get; set; }
		private string _whereClmhdr_2_agent_cd;
		public string WhereClmhdr_2_i_o_ind { get; set; }
		private string _whereClmhdr_2_i_o_ind;
		public string WhereClmhdr_2_phone_no { get; set; }
		private string _whereClmhdr_2_phone_no;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalClmhdr_2_trans_id;
		private string _originalClmhdr_2_rec_id;
		private string _originalClmhdr_2_ohip_num;
		private string _originalClmhdr_2_pat_surname;
		private string _originalClmhdr_2_given_name;
		private decimal? _originalClmhdr_2_pat_sex;
		private string _originalClmhdr_2_prov_cd;
		private string _originalClmhdr_2_filler;
		private string _originalClmhdr_2_confidentiality_flag;
		private string _originalClmhdr_2_loc_code;
		private string _originalClmhdr_2_agent_cd;
		private string _originalClmhdr_2_i_o_ind;
		private string _originalClmhdr_2_phone_no;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			CLMHDR_2_TRANS_ID = _originalClmhdr_2_trans_id;
			CLMHDR_2_REC_ID = _originalClmhdr_2_rec_id;
			CLMHDR_2_OHIP_NUM = _originalClmhdr_2_ohip_num;
			CLMHDR_2_PAT_SURNAME = _originalClmhdr_2_pat_surname;
			CLMHDR_2_GIVEN_NAME = _originalClmhdr_2_given_name;
			CLMHDR_2_PAT_SEX = _originalClmhdr_2_pat_sex;
			CLMHDR_2_PROV_CD = _originalClmhdr_2_prov_cd;
			CLMHDR_2_FILLER = _originalClmhdr_2_filler;
			CLMHDR_2_CONFIDENTIALITY_FLAG = _originalClmhdr_2_confidentiality_flag;
			CLMHDR_2_LOC_CODE = _originalClmhdr_2_loc_code;
			CLMHDR_2_AGENT_CD = _originalClmhdr_2_agent_cd;
			CLMHDR_2_I_O_IND = _originalClmhdr_2_i_o_ind;
			CLMHDR_2_PHONE_NO = _originalClmhdr_2_phone_no;
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
			RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_CLMHDR_2_REC_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_CLMHDR_2_REC_Purge]");
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
						new SqlParameter("CLMHDR_2_TRANS_ID", SqlNull(CLMHDR_2_TRANS_ID)),
						new SqlParameter("CLMHDR_2_REC_ID", SqlNull(CLMHDR_2_REC_ID)),
						new SqlParameter("CLMHDR_2_OHIP_NUM", SqlNull(CLMHDR_2_OHIP_NUM)),
						new SqlParameter("CLMHDR_2_PAT_SURNAME", SqlNull(CLMHDR_2_PAT_SURNAME)),
						new SqlParameter("CLMHDR_2_GIVEN_NAME", SqlNull(CLMHDR_2_GIVEN_NAME)),
						new SqlParameter("CLMHDR_2_PAT_SEX", SqlNull(CLMHDR_2_PAT_SEX)),
						new SqlParameter("CLMHDR_2_PROV_CD", SqlNull(CLMHDR_2_PROV_CD)),
						new SqlParameter("CLMHDR_2_FILLER", SqlNull(CLMHDR_2_FILLER)),
						new SqlParameter("CLMHDR_2_CONFIDENTIALITY_FLAG", SqlNull(CLMHDR_2_CONFIDENTIALITY_FLAG)),
						new SqlParameter("CLMHDR_2_LOC_CODE", SqlNull(CLMHDR_2_LOC_CODE)),
						new SqlParameter("CLMHDR_2_AGENT_CD", SqlNull(CLMHDR_2_AGENT_CD)),
						new SqlParameter("CLMHDR_2_I_O_IND", SqlNull(CLMHDR_2_I_O_IND)),
						new SqlParameter("CLMHDR_2_PHONE_NO", SqlNull(CLMHDR_2_PHONE_NO)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_CLMHDR_2_REC_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLMHDR_2_TRANS_ID = Reader["CLMHDR_2_TRANS_ID"].ToString();
						CLMHDR_2_REC_ID = Reader["CLMHDR_2_REC_ID"].ToString();
						CLMHDR_2_OHIP_NUM = Reader["CLMHDR_2_OHIP_NUM"].ToString();
						CLMHDR_2_PAT_SURNAME = Reader["CLMHDR_2_PAT_SURNAME"].ToString();
						CLMHDR_2_GIVEN_NAME = Reader["CLMHDR_2_GIVEN_NAME"].ToString();
						CLMHDR_2_PAT_SEX = ConvertDEC(Reader["CLMHDR_2_PAT_SEX"]);
						CLMHDR_2_PROV_CD = Reader["CLMHDR_2_PROV_CD"].ToString();
						CLMHDR_2_FILLER = Reader["CLMHDR_2_FILLER"].ToString();
						CLMHDR_2_CONFIDENTIALITY_FLAG = Reader["CLMHDR_2_CONFIDENTIALITY_FLAG"].ToString();
						CLMHDR_2_LOC_CODE = Reader["CLMHDR_2_LOC_CODE"].ToString();
						CLMHDR_2_AGENT_CD = Reader["CLMHDR_2_AGENT_CD"].ToString();
						CLMHDR_2_I_O_IND = Reader["CLMHDR_2_I_O_IND"].ToString();
						CLMHDR_2_PHONE_NO = Reader["CLMHDR_2_PHONE_NO"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClmhdr_2_trans_id = Reader["CLMHDR_2_TRANS_ID"].ToString();
						_originalClmhdr_2_rec_id = Reader["CLMHDR_2_REC_ID"].ToString();
						_originalClmhdr_2_ohip_num = Reader["CLMHDR_2_OHIP_NUM"].ToString();
						_originalClmhdr_2_pat_surname = Reader["CLMHDR_2_PAT_SURNAME"].ToString();
						_originalClmhdr_2_given_name = Reader["CLMHDR_2_GIVEN_NAME"].ToString();
						_originalClmhdr_2_pat_sex = ConvertDEC(Reader["CLMHDR_2_PAT_SEX"]);
						_originalClmhdr_2_prov_cd = Reader["CLMHDR_2_PROV_CD"].ToString();
						_originalClmhdr_2_filler = Reader["CLMHDR_2_FILLER"].ToString();
						_originalClmhdr_2_confidentiality_flag = Reader["CLMHDR_2_CONFIDENTIALITY_FLAG"].ToString();
						_originalClmhdr_2_loc_code = Reader["CLMHDR_2_LOC_CODE"].ToString();
						_originalClmhdr_2_agent_cd = Reader["CLMHDR_2_AGENT_CD"].ToString();
						_originalClmhdr_2_i_o_ind = Reader["CLMHDR_2_I_O_IND"].ToString();
						_originalClmhdr_2_phone_no = Reader["CLMHDR_2_PHONE_NO"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("CLMHDR_2_TRANS_ID", SqlNull(CLMHDR_2_TRANS_ID)),
						new SqlParameter("CLMHDR_2_REC_ID", SqlNull(CLMHDR_2_REC_ID)),
						new SqlParameter("CLMHDR_2_OHIP_NUM", SqlNull(CLMHDR_2_OHIP_NUM)),
						new SqlParameter("CLMHDR_2_PAT_SURNAME", SqlNull(CLMHDR_2_PAT_SURNAME)),
						new SqlParameter("CLMHDR_2_GIVEN_NAME", SqlNull(CLMHDR_2_GIVEN_NAME)),
						new SqlParameter("CLMHDR_2_PAT_SEX", SqlNull(CLMHDR_2_PAT_SEX)),
						new SqlParameter("CLMHDR_2_PROV_CD", SqlNull(CLMHDR_2_PROV_CD)),
						new SqlParameter("CLMHDR_2_FILLER", SqlNull(CLMHDR_2_FILLER)),
						new SqlParameter("CLMHDR_2_CONFIDENTIALITY_FLAG", SqlNull(CLMHDR_2_CONFIDENTIALITY_FLAG)),
						new SqlParameter("CLMHDR_2_LOC_CODE", SqlNull(CLMHDR_2_LOC_CODE)),
						new SqlParameter("CLMHDR_2_AGENT_CD", SqlNull(CLMHDR_2_AGENT_CD)),
						new SqlParameter("CLMHDR_2_I_O_IND", SqlNull(CLMHDR_2_I_O_IND)),
						new SqlParameter("CLMHDR_2_PHONE_NO", SqlNull(CLMHDR_2_PHONE_NO)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_CLMHDR_2_REC_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLMHDR_2_TRANS_ID = Reader["CLMHDR_2_TRANS_ID"].ToString();
						CLMHDR_2_REC_ID = Reader["CLMHDR_2_REC_ID"].ToString();
						CLMHDR_2_OHIP_NUM = Reader["CLMHDR_2_OHIP_NUM"].ToString();
						CLMHDR_2_PAT_SURNAME = Reader["CLMHDR_2_PAT_SURNAME"].ToString();
						CLMHDR_2_GIVEN_NAME = Reader["CLMHDR_2_GIVEN_NAME"].ToString();
						CLMHDR_2_PAT_SEX = ConvertDEC(Reader["CLMHDR_2_PAT_SEX"]);
						CLMHDR_2_PROV_CD = Reader["CLMHDR_2_PROV_CD"].ToString();
						CLMHDR_2_FILLER = Reader["CLMHDR_2_FILLER"].ToString();
						CLMHDR_2_CONFIDENTIALITY_FLAG = Reader["CLMHDR_2_CONFIDENTIALITY_FLAG"].ToString();
						CLMHDR_2_LOC_CODE = Reader["CLMHDR_2_LOC_CODE"].ToString();
						CLMHDR_2_AGENT_CD = Reader["CLMHDR_2_AGENT_CD"].ToString();
						CLMHDR_2_I_O_IND = Reader["CLMHDR_2_I_O_IND"].ToString();
						CLMHDR_2_PHONE_NO = Reader["CLMHDR_2_PHONE_NO"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClmhdr_2_trans_id = Reader["CLMHDR_2_TRANS_ID"].ToString();
						_originalClmhdr_2_rec_id = Reader["CLMHDR_2_REC_ID"].ToString();
						_originalClmhdr_2_ohip_num = Reader["CLMHDR_2_OHIP_NUM"].ToString();
						_originalClmhdr_2_pat_surname = Reader["CLMHDR_2_PAT_SURNAME"].ToString();
						_originalClmhdr_2_given_name = Reader["CLMHDR_2_GIVEN_NAME"].ToString();
						_originalClmhdr_2_pat_sex = ConvertDEC(Reader["CLMHDR_2_PAT_SEX"]);
						_originalClmhdr_2_prov_cd = Reader["CLMHDR_2_PROV_CD"].ToString();
						_originalClmhdr_2_filler = Reader["CLMHDR_2_FILLER"].ToString();
						_originalClmhdr_2_confidentiality_flag = Reader["CLMHDR_2_CONFIDENTIALITY_FLAG"].ToString();
						_originalClmhdr_2_loc_code = Reader["CLMHDR_2_LOC_CODE"].ToString();
						_originalClmhdr_2_agent_cd = Reader["CLMHDR_2_AGENT_CD"].ToString();
						_originalClmhdr_2_i_o_ind = Reader["CLMHDR_2_I_O_IND"].ToString();
						_originalClmhdr_2_phone_no = Reader["CLMHDR_2_PHONE_NO"].ToString();
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