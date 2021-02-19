using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class R031A_OHIP_PREMIUMS : BaseTable
    {
        #region Retrieve

        public ObservableCollection<R031A_OHIP_PREMIUMS> Collection( Guid? rowid,
															decimal? iconst_clinic_nbr_1_2min,
															decimal? iconst_clinic_nbr_1_2max,
															string afp_group_name,
															string group_nbr,
															string premium_payment_date,
															decimal? doc_ohip_nbrmin,
															decimal? doc_ohip_nbrmax,
															string doc_name,
															string clmhdr_adj_cd,
															string payment_type,
															string payment_percentage,
															string nbr_of_claims,
															string dollars_approved,
															string dollars_paid,
															string lf,
															string cr,
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
					new SqlParameter("minICONST_CLINIC_NBR_1_2",iconst_clinic_nbr_1_2min),
					new SqlParameter("maxICONST_CLINIC_NBR_1_2",iconst_clinic_nbr_1_2max),
					new SqlParameter("AFP_GROUP_NAME",afp_group_name),
					new SqlParameter("GROUP_NBR",group_nbr),
					new SqlParameter("PREMIUM_PAYMENT_DATE",premium_payment_date),
					new SqlParameter("minDOC_OHIP_NBR",doc_ohip_nbrmin),
					new SqlParameter("maxDOC_OHIP_NBR",doc_ohip_nbrmax),
					new SqlParameter("DOC_NAME",doc_name),
					new SqlParameter("CLMHDR_ADJ_CD",clmhdr_adj_cd),
					new SqlParameter("PAYMENT_TYPE",payment_type),
					new SqlParameter("PAYMENT_PERCENTAGE",payment_percentage),
					new SqlParameter("NBR_OF_CLAIMS",nbr_of_claims),
					new SqlParameter("DOLLARS_APPROVED",dollars_approved),
					new SqlParameter("DOLLARS_PAID",dollars_paid),
					new SqlParameter("LF",lf),
					new SqlParameter("CR",cr),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[SEQUENTIAL].[sp_R031A_OHIP_PREMIUMS_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<R031A_OHIP_PREMIUMS>();
				}

            }

            Reader = CoreReader("[SEQUENTIAL].[sp_R031A_OHIP_PREMIUMS_Search]", parameters);
            var collection = new ObservableCollection<R031A_OHIP_PREMIUMS>();

            while (Reader.Read())
            {
                collection.Add(new R031A_OHIP_PREMIUMS
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					ICONST_CLINIC_NBR_1_2 = ConvertDEC(Reader["ICONST_CLINIC_NBR_1_2"]),
					AFP_GROUP_NAME = Reader["AFP_GROUP_NAME"].ToString(),
					GROUP_NBR = Reader["GROUP_NBR"].ToString(),
					PREMIUM_PAYMENT_DATE = Reader["PREMIUM_PAYMENT_DATE"].ToString(),
					DOC_OHIP_NBR = ConvertDEC(Reader["DOC_OHIP_NBR"]),
					DOC_NAME = Reader["DOC_NAME"].ToString(),
					CLMHDR_ADJ_CD = Reader["CLMHDR_ADJ_CD"].ToString(),
					PAYMENT_TYPE = Reader["PAYMENT_TYPE"].ToString(),
					PAYMENT_PERCENTAGE = Reader["PAYMENT_PERCENTAGE"].ToString(),
					NBR_OF_CLAIMS = Reader["NBR_OF_CLAIMS"].ToString(),
					DOLLARS_APPROVED = Reader["DOLLARS_APPROVED"].ToString(),
					DOLLARS_PAID = Reader["DOLLARS_PAID"].ToString(),
					LF = Reader["LF"].ToString(),
					CR = Reader["CR"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalIconst_clinic_nbr_1_2 = ConvertDEC(Reader["ICONST_CLINIC_NBR_1_2"]),
					_originalAfp_group_name = Reader["AFP_GROUP_NAME"].ToString(),
					_originalGroup_nbr = Reader["GROUP_NBR"].ToString(),
					_originalPremium_payment_date = Reader["PREMIUM_PAYMENT_DATE"].ToString(),
					_originalDoc_ohip_nbr = ConvertDEC(Reader["DOC_OHIP_NBR"]),
					_originalDoc_name = Reader["DOC_NAME"].ToString(),
					_originalClmhdr_adj_cd = Reader["CLMHDR_ADJ_CD"].ToString(),
					_originalPayment_type = Reader["PAYMENT_TYPE"].ToString(),
					_originalPayment_percentage = Reader["PAYMENT_PERCENTAGE"].ToString(),
					_originalNbr_of_claims = Reader["NBR_OF_CLAIMS"].ToString(),
					_originalDollars_approved = Reader["DOLLARS_APPROVED"].ToString(),
					_originalDollars_paid = Reader["DOLLARS_PAID"].ToString(),
					_originalLf = Reader["LF"].ToString(),
					_originalCr = Reader["CR"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public R031A_OHIP_PREMIUMS Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<R031A_OHIP_PREMIUMS> Collection(ObservableCollection<R031A_OHIP_PREMIUMS>
                                                               r031aOhipPremiums = null)
        {
            if (IsSameSearch() && r031aOhipPremiums != null)
            {
                return r031aOhipPremiums;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<R031A_OHIP_PREMIUMS>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("ICONST_CLINIC_NBR_1_2",WhereIconst_clinic_nbr_1_2),
					new SqlParameter("AFP_GROUP_NAME",WhereAfp_group_name),
					new SqlParameter("GROUP_NBR",WhereGroup_nbr),
					new SqlParameter("PREMIUM_PAYMENT_DATE",WherePremium_payment_date),
					new SqlParameter("DOC_OHIP_NBR",WhereDoc_ohip_nbr),
					new SqlParameter("DOC_NAME",WhereDoc_name),
					new SqlParameter("CLMHDR_ADJ_CD",WhereClmhdr_adj_cd),
					new SqlParameter("PAYMENT_TYPE",WherePayment_type),
					new SqlParameter("PAYMENT_PERCENTAGE",WherePayment_percentage),
					new SqlParameter("NBR_OF_CLAIMS",WhereNbr_of_claims),
					new SqlParameter("DOLLARS_APPROVED",WhereDollars_approved),
					new SqlParameter("DOLLARS_PAID",WhereDollars_paid),
					new SqlParameter("LF",WhereLf),
					new SqlParameter("CR",WhereCr),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[SEQUENTIAL].[sp_R031A_OHIP_PREMIUMS_Match]", parameters);
            var collection = new ObservableCollection<R031A_OHIP_PREMIUMS>();

            while (Reader.Read())
            {
                collection.Add(new R031A_OHIP_PREMIUMS
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					ICONST_CLINIC_NBR_1_2 = ConvertDEC(Reader["ICONST_CLINIC_NBR_1_2"]),
					AFP_GROUP_NAME = Reader["AFP_GROUP_NAME"].ToString(),
					GROUP_NBR = Reader["GROUP_NBR"].ToString(),
					PREMIUM_PAYMENT_DATE = Reader["PREMIUM_PAYMENT_DATE"].ToString(),
					DOC_OHIP_NBR = ConvertDEC(Reader["DOC_OHIP_NBR"]),
					DOC_NAME = Reader["DOC_NAME"].ToString(),
					CLMHDR_ADJ_CD = Reader["CLMHDR_ADJ_CD"].ToString(),
					PAYMENT_TYPE = Reader["PAYMENT_TYPE"].ToString(),
					PAYMENT_PERCENTAGE = Reader["PAYMENT_PERCENTAGE"].ToString(),
					NBR_OF_CLAIMS = Reader["NBR_OF_CLAIMS"].ToString(),
					DOLLARS_APPROVED = Reader["DOLLARS_APPROVED"].ToString(),
					DOLLARS_PAID = Reader["DOLLARS_PAID"].ToString(),
					LF = Reader["LF"].ToString(),
					CR = Reader["CR"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereIconst_clinic_nbr_1_2 = WhereIconst_clinic_nbr_1_2,
					_whereAfp_group_name = WhereAfp_group_name,
					_whereGroup_nbr = WhereGroup_nbr,
					_wherePremium_payment_date = WherePremium_payment_date,
					_whereDoc_ohip_nbr = WhereDoc_ohip_nbr,
					_whereDoc_name = WhereDoc_name,
					_whereClmhdr_adj_cd = WhereClmhdr_adj_cd,
					_wherePayment_type = WherePayment_type,
					_wherePayment_percentage = WherePayment_percentage,
					_whereNbr_of_claims = WhereNbr_of_claims,
					_whereDollars_approved = WhereDollars_approved,
					_whereDollars_paid = WhereDollars_paid,
					_whereLf = WhereLf,
					_whereCr = WhereCr,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalIconst_clinic_nbr_1_2 = ConvertDEC(Reader["ICONST_CLINIC_NBR_1_2"]),
					_originalAfp_group_name = Reader["AFP_GROUP_NAME"].ToString(),
					_originalGroup_nbr = Reader["GROUP_NBR"].ToString(),
					_originalPremium_payment_date = Reader["PREMIUM_PAYMENT_DATE"].ToString(),
					_originalDoc_ohip_nbr = ConvertDEC(Reader["DOC_OHIP_NBR"]),
					_originalDoc_name = Reader["DOC_NAME"].ToString(),
					_originalClmhdr_adj_cd = Reader["CLMHDR_ADJ_CD"].ToString(),
					_originalPayment_type = Reader["PAYMENT_TYPE"].ToString(),
					_originalPayment_percentage = Reader["PAYMENT_PERCENTAGE"].ToString(),
					_originalNbr_of_claims = Reader["NBR_OF_CLAIMS"].ToString(),
					_originalDollars_approved = Reader["DOLLARS_APPROVED"].ToString(),
					_originalDollars_paid = Reader["DOLLARS_PAID"].ToString(),
					_originalLf = Reader["LF"].ToString(),
					_originalCr = Reader["CR"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereIconst_clinic_nbr_1_2 = WhereIconst_clinic_nbr_1_2;
					_whereAfp_group_name = WhereAfp_group_name;
					_whereGroup_nbr = WhereGroup_nbr;
					_wherePremium_payment_date = WherePremium_payment_date;
					_whereDoc_ohip_nbr = WhereDoc_ohip_nbr;
					_whereDoc_name = WhereDoc_name;
					_whereClmhdr_adj_cd = WhereClmhdr_adj_cd;
					_wherePayment_type = WherePayment_type;
					_wherePayment_percentage = WherePayment_percentage;
					_whereNbr_of_claims = WhereNbr_of_claims;
					_whereDollars_approved = WhereDollars_approved;
					_whereDollars_paid = WhereDollars_paid;
					_whereLf = WhereLf;
					_whereCr = WhereCr;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereIconst_clinic_nbr_1_2 == null 
				&& WhereAfp_group_name == null 
				&& WhereGroup_nbr == null 
				&& WherePremium_payment_date == null 
				&& WhereDoc_ohip_nbr == null 
				&& WhereDoc_name == null 
				&& WhereClmhdr_adj_cd == null 
				&& WherePayment_type == null 
				&& WherePayment_percentage == null 
				&& WhereNbr_of_claims == null 
				&& WhereDollars_approved == null 
				&& WhereDollars_paid == null 
				&& WhereLf == null 
				&& WhereCr == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereIconst_clinic_nbr_1_2 ==  _whereIconst_clinic_nbr_1_2
				&& WhereAfp_group_name ==  _whereAfp_group_name
				&& WhereGroup_nbr ==  _whereGroup_nbr
				&& WherePremium_payment_date ==  _wherePremium_payment_date
				&& WhereDoc_ohip_nbr ==  _whereDoc_ohip_nbr
				&& WhereDoc_name ==  _whereDoc_name
				&& WhereClmhdr_adj_cd ==  _whereClmhdr_adj_cd
				&& WherePayment_type ==  _wherePayment_type
				&& WherePayment_percentage ==  _wherePayment_percentage
				&& WhereNbr_of_claims ==  _whereNbr_of_claims
				&& WhereDollars_approved ==  _whereDollars_approved
				&& WhereDollars_paid ==  _whereDollars_paid
				&& WhereLf ==  _whereLf
				&& WhereCr ==  _whereCr
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereIconst_clinic_nbr_1_2 = null; 
			WhereAfp_group_name = null; 
			WhereGroup_nbr = null; 
			WherePremium_payment_date = null; 
			WhereDoc_ohip_nbr = null; 
			WhereDoc_name = null; 
			WhereClmhdr_adj_cd = null; 
			WherePayment_type = null; 
			WherePayment_percentage = null; 
			WhereNbr_of_claims = null; 
			WhereDollars_approved = null; 
			WhereDollars_paid = null; 
			WhereLf = null; 
			WhereCr = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private decimal? _ICONST_CLINIC_NBR_1_2;
		private string _AFP_GROUP_NAME;
		private string _GROUP_NBR;
		private string _PREMIUM_PAYMENT_DATE;
		private decimal? _DOC_OHIP_NBR;
		private string _DOC_NAME;
		private string _CLMHDR_ADJ_CD;
		private string _PAYMENT_TYPE;
		private string _PAYMENT_PERCENTAGE;
		private string _NBR_OF_CLAIMS;
		private string _DOLLARS_APPROVED;
		private string _DOLLARS_PAID;
		private string _LF;
		private string _CR;
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
		public string AFP_GROUP_NAME
		{
			get { return _AFP_GROUP_NAME; }
			set
			{
				if (_AFP_GROUP_NAME != value)
				{
					_AFP_GROUP_NAME = value;
					ChangeState();
				}
			}
		}
		public string GROUP_NBR
		{
			get { return _GROUP_NBR; }
			set
			{
				if (_GROUP_NBR != value)
				{
					_GROUP_NBR = value;
					ChangeState();
				}
			}
		}
		public string PREMIUM_PAYMENT_DATE
		{
			get { return _PREMIUM_PAYMENT_DATE; }
			set
			{
				if (_PREMIUM_PAYMENT_DATE != value)
				{
					_PREMIUM_PAYMENT_DATE = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_OHIP_NBR
		{
			get { return _DOC_OHIP_NBR; }
			set
			{
				if (_DOC_OHIP_NBR != value)
				{
					_DOC_OHIP_NBR = value;
					ChangeState();
				}
			}
		}
		public string DOC_NAME
		{
			get { return _DOC_NAME; }
			set
			{
				if (_DOC_NAME != value)
				{
					_DOC_NAME = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_ADJ_CD
		{
			get { return _CLMHDR_ADJ_CD; }
			set
			{
				if (_CLMHDR_ADJ_CD != value)
				{
					_CLMHDR_ADJ_CD = value;
					ChangeState();
				}
			}
		}
		public string PAYMENT_TYPE
		{
			get { return _PAYMENT_TYPE; }
			set
			{
				if (_PAYMENT_TYPE != value)
				{
					_PAYMENT_TYPE = value;
					ChangeState();
				}
			}
		}
		public string PAYMENT_PERCENTAGE
		{
			get { return _PAYMENT_PERCENTAGE; }
			set
			{
				if (_PAYMENT_PERCENTAGE != value)
				{
					_PAYMENT_PERCENTAGE = value;
					ChangeState();
				}
			}
		}
		public string NBR_OF_CLAIMS
		{
			get { return _NBR_OF_CLAIMS; }
			set
			{
				if (_NBR_OF_CLAIMS != value)
				{
					_NBR_OF_CLAIMS = value;
					ChangeState();
				}
			}
		}
		public string DOLLARS_APPROVED
		{
			get { return _DOLLARS_APPROVED; }
			set
			{
				if (_DOLLARS_APPROVED != value)
				{
					_DOLLARS_APPROVED = value;
					ChangeState();
				}
			}
		}
		public string DOLLARS_PAID
		{
			get { return _DOLLARS_PAID; }
			set
			{
				if (_DOLLARS_PAID != value)
				{
					_DOLLARS_PAID = value;
					ChangeState();
				}
			}
		}
		public string LF
		{
			get { return _LF; }
			set
			{
				if (_LF != value)
				{
					_LF = value;
					ChangeState();
				}
			}
		}
		public string CR
		{
			get { return _CR; }
			set
			{
				if (_CR != value)
				{
					_CR = value;
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
		public decimal? WhereIconst_clinic_nbr_1_2 { get; set; }
		private decimal? _whereIconst_clinic_nbr_1_2;
		public string WhereAfp_group_name { get; set; }
		private string _whereAfp_group_name;
		public string WhereGroup_nbr { get; set; }
		private string _whereGroup_nbr;
		public string WherePremium_payment_date { get; set; }
		private string _wherePremium_payment_date;
		public decimal? WhereDoc_ohip_nbr { get; set; }
		private decimal? _whereDoc_ohip_nbr;
		public string WhereDoc_name { get; set; }
		private string _whereDoc_name;
		public string WhereClmhdr_adj_cd { get; set; }
		private string _whereClmhdr_adj_cd;
		public string WherePayment_type { get; set; }
		private string _wherePayment_type;
		public string WherePayment_percentage { get; set; }
		private string _wherePayment_percentage;
		public string WhereNbr_of_claims { get; set; }
		private string _whereNbr_of_claims;
		public string WhereDollars_approved { get; set; }
		private string _whereDollars_approved;
		public string WhereDollars_paid { get; set; }
		private string _whereDollars_paid;
		public string WhereLf { get; set; }
		private string _whereLf;
		public string WhereCr { get; set; }
		private string _whereCr;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private decimal? _originalIconst_clinic_nbr_1_2;
		private string _originalAfp_group_name;
		private string _originalGroup_nbr;
		private string _originalPremium_payment_date;
		private decimal? _originalDoc_ohip_nbr;
		private string _originalDoc_name;
		private string _originalClmhdr_adj_cd;
		private string _originalPayment_type;
		private string _originalPayment_percentage;
		private string _originalNbr_of_claims;
		private string _originalDollars_approved;
		private string _originalDollars_paid;
		private string _originalLf;
		private string _originalCr;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			ICONST_CLINIC_NBR_1_2 = _originalIconst_clinic_nbr_1_2;
			AFP_GROUP_NAME = _originalAfp_group_name;
			GROUP_NBR = _originalGroup_nbr;
			PREMIUM_PAYMENT_DATE = _originalPremium_payment_date;
			DOC_OHIP_NBR = _originalDoc_ohip_nbr;
			DOC_NAME = _originalDoc_name;
			CLMHDR_ADJ_CD = _originalClmhdr_adj_cd;
			PAYMENT_TYPE = _originalPayment_type;
			PAYMENT_PERCENTAGE = _originalPayment_percentage;
			NBR_OF_CLAIMS = _originalNbr_of_claims;
			DOLLARS_APPROVED = _originalDollars_approved;
			DOLLARS_PAID = _originalDollars_paid;
			LF = _originalLf;
			CR = _originalCr;
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
			RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_R031A_OHIP_PREMIUMS_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_R031A_OHIP_PREMIUMS_Purge]");
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
						new SqlParameter("ICONST_CLINIC_NBR_1_2", SqlNull(ICONST_CLINIC_NBR_1_2)),
						new SqlParameter("AFP_GROUP_NAME", SqlNull(AFP_GROUP_NAME)),
						new SqlParameter("GROUP_NBR", SqlNull(GROUP_NBR)),
						new SqlParameter("PREMIUM_PAYMENT_DATE", SqlNull(PREMIUM_PAYMENT_DATE)),
						new SqlParameter("DOC_OHIP_NBR", SqlNull(DOC_OHIP_NBR)),
						new SqlParameter("DOC_NAME", SqlNull(DOC_NAME)),
						new SqlParameter("CLMHDR_ADJ_CD", SqlNull(CLMHDR_ADJ_CD)),
						new SqlParameter("PAYMENT_TYPE", SqlNull(PAYMENT_TYPE)),
						new SqlParameter("PAYMENT_PERCENTAGE", SqlNull(PAYMENT_PERCENTAGE)),
						new SqlParameter("NBR_OF_CLAIMS", SqlNull(NBR_OF_CLAIMS)),
						new SqlParameter("DOLLARS_APPROVED", SqlNull(DOLLARS_APPROVED)),
						new SqlParameter("DOLLARS_PAID", SqlNull(DOLLARS_PAID)),
						new SqlParameter("LF", SqlNull(LF)),
						new SqlParameter("CR", SqlNull(CR)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_R031A_OHIP_PREMIUMS_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						ICONST_CLINIC_NBR_1_2 = ConvertDEC(Reader["ICONST_CLINIC_NBR_1_2"]);
						AFP_GROUP_NAME = Reader["AFP_GROUP_NAME"].ToString();
						GROUP_NBR = Reader["GROUP_NBR"].ToString();
						PREMIUM_PAYMENT_DATE = Reader["PREMIUM_PAYMENT_DATE"].ToString();
						DOC_OHIP_NBR = ConvertDEC(Reader["DOC_OHIP_NBR"]);
						DOC_NAME = Reader["DOC_NAME"].ToString();
						CLMHDR_ADJ_CD = Reader["CLMHDR_ADJ_CD"].ToString();
						PAYMENT_TYPE = Reader["PAYMENT_TYPE"].ToString();
						PAYMENT_PERCENTAGE = Reader["PAYMENT_PERCENTAGE"].ToString();
						NBR_OF_CLAIMS = Reader["NBR_OF_CLAIMS"].ToString();
						DOLLARS_APPROVED = Reader["DOLLARS_APPROVED"].ToString();
						DOLLARS_PAID = Reader["DOLLARS_PAID"].ToString();
						LF = Reader["LF"].ToString();
						CR = Reader["CR"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalIconst_clinic_nbr_1_2 = ConvertDEC(Reader["ICONST_CLINIC_NBR_1_2"]);
						_originalAfp_group_name = Reader["AFP_GROUP_NAME"].ToString();
						_originalGroup_nbr = Reader["GROUP_NBR"].ToString();
						_originalPremium_payment_date = Reader["PREMIUM_PAYMENT_DATE"].ToString();
						_originalDoc_ohip_nbr = ConvertDEC(Reader["DOC_OHIP_NBR"]);
						_originalDoc_name = Reader["DOC_NAME"].ToString();
						_originalClmhdr_adj_cd = Reader["CLMHDR_ADJ_CD"].ToString();
						_originalPayment_type = Reader["PAYMENT_TYPE"].ToString();
						_originalPayment_percentage = Reader["PAYMENT_PERCENTAGE"].ToString();
						_originalNbr_of_claims = Reader["NBR_OF_CLAIMS"].ToString();
						_originalDollars_approved = Reader["DOLLARS_APPROVED"].ToString();
						_originalDollars_paid = Reader["DOLLARS_PAID"].ToString();
						_originalLf = Reader["LF"].ToString();
						_originalCr = Reader["CR"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("ICONST_CLINIC_NBR_1_2", SqlNull(ICONST_CLINIC_NBR_1_2)),
						new SqlParameter("AFP_GROUP_NAME", SqlNull(AFP_GROUP_NAME)),
						new SqlParameter("GROUP_NBR", SqlNull(GROUP_NBR)),
						new SqlParameter("PREMIUM_PAYMENT_DATE", SqlNull(PREMIUM_PAYMENT_DATE)),
						new SqlParameter("DOC_OHIP_NBR", SqlNull(DOC_OHIP_NBR)),
						new SqlParameter("DOC_NAME", SqlNull(DOC_NAME)),
						new SqlParameter("CLMHDR_ADJ_CD", SqlNull(CLMHDR_ADJ_CD)),
						new SqlParameter("PAYMENT_TYPE", SqlNull(PAYMENT_TYPE)),
						new SqlParameter("PAYMENT_PERCENTAGE", SqlNull(PAYMENT_PERCENTAGE)),
						new SqlParameter("NBR_OF_CLAIMS", SqlNull(NBR_OF_CLAIMS)),
						new SqlParameter("DOLLARS_APPROVED", SqlNull(DOLLARS_APPROVED)),
						new SqlParameter("DOLLARS_PAID", SqlNull(DOLLARS_PAID)),
						new SqlParameter("LF", SqlNull(LF)),
						new SqlParameter("CR", SqlNull(CR)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_R031A_OHIP_PREMIUMS_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						ICONST_CLINIC_NBR_1_2 = ConvertDEC(Reader["ICONST_CLINIC_NBR_1_2"]);
						AFP_GROUP_NAME = Reader["AFP_GROUP_NAME"].ToString();
						GROUP_NBR = Reader["GROUP_NBR"].ToString();
						PREMIUM_PAYMENT_DATE = Reader["PREMIUM_PAYMENT_DATE"].ToString();
						DOC_OHIP_NBR = ConvertDEC(Reader["DOC_OHIP_NBR"]);
						DOC_NAME = Reader["DOC_NAME"].ToString();
						CLMHDR_ADJ_CD = Reader["CLMHDR_ADJ_CD"].ToString();
						PAYMENT_TYPE = Reader["PAYMENT_TYPE"].ToString();
						PAYMENT_PERCENTAGE = Reader["PAYMENT_PERCENTAGE"].ToString();
						NBR_OF_CLAIMS = Reader["NBR_OF_CLAIMS"].ToString();
						DOLLARS_APPROVED = Reader["DOLLARS_APPROVED"].ToString();
						DOLLARS_PAID = Reader["DOLLARS_PAID"].ToString();
						LF = Reader["LF"].ToString();
						CR = Reader["CR"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalIconst_clinic_nbr_1_2 = ConvertDEC(Reader["ICONST_CLINIC_NBR_1_2"]);
						_originalAfp_group_name = Reader["AFP_GROUP_NAME"].ToString();
						_originalGroup_nbr = Reader["GROUP_NBR"].ToString();
						_originalPremium_payment_date = Reader["PREMIUM_PAYMENT_DATE"].ToString();
						_originalDoc_ohip_nbr = ConvertDEC(Reader["DOC_OHIP_NBR"]);
						_originalDoc_name = Reader["DOC_NAME"].ToString();
						_originalClmhdr_adj_cd = Reader["CLMHDR_ADJ_CD"].ToString();
						_originalPayment_type = Reader["PAYMENT_TYPE"].ToString();
						_originalPayment_percentage = Reader["PAYMENT_PERCENTAGE"].ToString();
						_originalNbr_of_claims = Reader["NBR_OF_CLAIMS"].ToString();
						_originalDollars_approved = Reader["DOLLARS_APPROVED"].ToString();
						_originalDollars_paid = Reader["DOLLARS_PAID"].ToString();
						_originalLf = Reader["LF"].ToString();
						_originalCr = Reader["CR"].ToString();
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