using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F002_DTL_BEFORE : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F002_DTL_BEFORE> Collection( Guid? rowid,
															string batctrl_batch_status,
															string batctrl_batch_type,
															string batctrl_adj_cd,
															decimal? clmhdr_clinic_nbr_1_2min,
															decimal? clmhdr_clinic_nbr_1_2max,
															string clmhdr_batch_nbr,
															decimal? clmhdr_claim_nbrmin,
															decimal? clmhdr_claim_nbrmax,
															string clmhdr_doc_nbr,
															int? clmhdr_doc_deptmin,
															int? clmhdr_doc_deptmax,
															string clmhdr_loc,
															int? clmhdr_agent_cdmin,
															int? clmhdr_agent_cdmax,
															int? clmhdr_manual_and_tape_paymentsmin,
															int? clmhdr_manual_and_tape_paymentsmax,
															int? clmhdr_amt_tech_paidmin,
															int? clmhdr_amt_tech_paidmax,
															string clmhdr_i_o_pat_ind,
															string clmhdr_adj_cd_sub_type,
															string clmhdr_adj_cd,
															string clmhdr_payroll,
															string clmdtl_oma_cd,
															string clmdtl_oma_suff,
															int? clmdtl_fee_ohipmin,
															int? clmdtl_fee_ohipmax,
															decimal? clmdtl_nbr_servmin,
															decimal? clmdtl_nbr_servmax,
															int? clmdtl_amt_tech_billedmin,
															int? clmdtl_amt_tech_billedmax,
															string clmdtl_date_period_end,
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
					new SqlParameter("BATCTRL_BATCH_STATUS",batctrl_batch_status),
					new SqlParameter("BATCTRL_BATCH_TYPE",batctrl_batch_type),
					new SqlParameter("BATCTRL_ADJ_CD",batctrl_adj_cd),
					new SqlParameter("minCLMHDR_CLINIC_NBR_1_2",clmhdr_clinic_nbr_1_2min),
					new SqlParameter("maxCLMHDR_CLINIC_NBR_1_2",clmhdr_clinic_nbr_1_2max),
					new SqlParameter("CLMHDR_BATCH_NBR",clmhdr_batch_nbr),
					new SqlParameter("minCLMHDR_CLAIM_NBR",clmhdr_claim_nbrmin),
					new SqlParameter("maxCLMHDR_CLAIM_NBR",clmhdr_claim_nbrmax),
					new SqlParameter("CLMHDR_DOC_NBR",clmhdr_doc_nbr),
					new SqlParameter("minCLMHDR_DOC_DEPT",clmhdr_doc_deptmin),
					new SqlParameter("maxCLMHDR_DOC_DEPT",clmhdr_doc_deptmax),
					new SqlParameter("CLMHDR_LOC",clmhdr_loc),
					new SqlParameter("minCLMHDR_AGENT_CD",clmhdr_agent_cdmin),
					new SqlParameter("maxCLMHDR_AGENT_CD",clmhdr_agent_cdmax),
					new SqlParameter("minCLMHDR_MANUAL_AND_TAPE_PAYMENTS",clmhdr_manual_and_tape_paymentsmin),
					new SqlParameter("maxCLMHDR_MANUAL_AND_TAPE_PAYMENTS",clmhdr_manual_and_tape_paymentsmax),
					new SqlParameter("minCLMHDR_AMT_TECH_PAID",clmhdr_amt_tech_paidmin),
					new SqlParameter("maxCLMHDR_AMT_TECH_PAID",clmhdr_amt_tech_paidmax),
					new SqlParameter("CLMHDR_I_O_PAT_IND",clmhdr_i_o_pat_ind),
					new SqlParameter("CLMHDR_ADJ_CD_SUB_TYPE",clmhdr_adj_cd_sub_type),
					new SqlParameter("CLMHDR_ADJ_CD",clmhdr_adj_cd),
					new SqlParameter("CLMHDR_PAYROLL",clmhdr_payroll),
					new SqlParameter("CLMDTL_OMA_CD",clmdtl_oma_cd),
					new SqlParameter("CLMDTL_OMA_SUFF",clmdtl_oma_suff),
					new SqlParameter("minCLMDTL_FEE_OHIP",clmdtl_fee_ohipmin),
					new SqlParameter("maxCLMDTL_FEE_OHIP",clmdtl_fee_ohipmax),
					new SqlParameter("minCLMDTL_NBR_SERV",clmdtl_nbr_servmin),
					new SqlParameter("maxCLMDTL_NBR_SERV",clmdtl_nbr_servmax),
					new SqlParameter("minCLMDTL_AMT_TECH_BILLED",clmdtl_amt_tech_billedmin),
					new SqlParameter("maxCLMDTL_AMT_TECH_BILLED",clmdtl_amt_tech_billedmax),
					new SqlParameter("CLMDTL_DATE_PERIOD_END",clmdtl_date_period_end),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[SEQUENTIAL].[sp_F002_DTL_BEFORE_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F002_DTL_BEFORE>();
				}

            }

            Reader = CoreReader("[SEQUENTIAL].[sp_F002_DTL_BEFORE_Search]", parameters);
            var collection = new ObservableCollection<F002_DTL_BEFORE>();

            while (Reader.Read())
            {
                collection.Add(new F002_DTL_BEFORE
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					BATCTRL_BATCH_STATUS = Reader["BATCTRL_BATCH_STATUS"].ToString(),
					BATCTRL_BATCH_TYPE = Reader["BATCTRL_BATCH_TYPE"].ToString(),
					BATCTRL_ADJ_CD = Reader["BATCTRL_ADJ_CD"].ToString(),
					CLMHDR_CLINIC_NBR_1_2 = ConvertDEC(Reader["CLMHDR_CLINIC_NBR_1_2"]),
					CLMHDR_BATCH_NBR = Reader["CLMHDR_BATCH_NBR"].ToString(),
					CLMHDR_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]),
					CLMHDR_DOC_NBR = Reader["CLMHDR_DOC_NBR"].ToString(),
					CLMHDR_DOC_DEPT = ConvertINT(Reader["CLMHDR_DOC_DEPT"]),
					CLMHDR_LOC = Reader["CLMHDR_LOC"].ToString(),
					CLMHDR_AGENT_CD = ConvertINT(Reader["CLMHDR_AGENT_CD"]),
					CLMHDR_MANUAL_AND_TAPE_PAYMENTS = ConvertINT(Reader["CLMHDR_MANUAL_AND_TAPE_PAYMENTS"]),
					CLMHDR_AMT_TECH_PAID = ConvertINT(Reader["CLMHDR_AMT_TECH_PAID"]),
					CLMHDR_I_O_PAT_IND = Reader["CLMHDR_I_O_PAT_IND"].ToString(),
					CLMHDR_ADJ_CD_SUB_TYPE = Reader["CLMHDR_ADJ_CD_SUB_TYPE"].ToString(),
					CLMHDR_ADJ_CD = Reader["CLMHDR_ADJ_CD"].ToString(),
					CLMHDR_PAYROLL = Reader["CLMHDR_PAYROLL"].ToString(),
					CLMDTL_OMA_CD = Reader["CLMDTL_OMA_CD"].ToString(),
					CLMDTL_OMA_SUFF = Reader["CLMDTL_OMA_SUFF"].ToString(),
					CLMDTL_FEE_OHIP = ConvertINT(Reader["CLMDTL_FEE_OHIP"]),
					CLMDTL_NBR_SERV = ConvertDEC(Reader["CLMDTL_NBR_SERV"]),
					CLMDTL_AMT_TECH_BILLED = ConvertINT(Reader["CLMDTL_AMT_TECH_BILLED"]),
					CLMDTL_DATE_PERIOD_END = Reader["CLMDTL_DATE_PERIOD_END"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalBatctrl_batch_status = Reader["BATCTRL_BATCH_STATUS"].ToString(),
					_originalBatctrl_batch_type = Reader["BATCTRL_BATCH_TYPE"].ToString(),
					_originalBatctrl_adj_cd = Reader["BATCTRL_ADJ_CD"].ToString(),
					_originalClmhdr_clinic_nbr_1_2 = ConvertDEC(Reader["CLMHDR_CLINIC_NBR_1_2"]),
					_originalClmhdr_batch_nbr = Reader["CLMHDR_BATCH_NBR"].ToString(),
					_originalClmhdr_claim_nbr = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]),
					_originalClmhdr_doc_nbr = Reader["CLMHDR_DOC_NBR"].ToString(),
					_originalClmhdr_doc_dept = ConvertINT(Reader["CLMHDR_DOC_DEPT"]),
					_originalClmhdr_loc = Reader["CLMHDR_LOC"].ToString(),
					_originalClmhdr_agent_cd = ConvertINT(Reader["CLMHDR_AGENT_CD"]),
					_originalClmhdr_manual_and_tape_payments = ConvertINT(Reader["CLMHDR_MANUAL_AND_TAPE_PAYMENTS"]),
					_originalClmhdr_amt_tech_paid = ConvertINT(Reader["CLMHDR_AMT_TECH_PAID"]),
					_originalClmhdr_i_o_pat_ind = Reader["CLMHDR_I_O_PAT_IND"].ToString(),
					_originalClmhdr_adj_cd_sub_type = Reader["CLMHDR_ADJ_CD_SUB_TYPE"].ToString(),
					_originalClmhdr_adj_cd = Reader["CLMHDR_ADJ_CD"].ToString(),
					_originalClmhdr_payroll = Reader["CLMHDR_PAYROLL"].ToString(),
					_originalClmdtl_oma_cd = Reader["CLMDTL_OMA_CD"].ToString(),
					_originalClmdtl_oma_suff = Reader["CLMDTL_OMA_SUFF"].ToString(),
					_originalClmdtl_fee_ohip = ConvertINT(Reader["CLMDTL_FEE_OHIP"]),
					_originalClmdtl_nbr_serv = ConvertDEC(Reader["CLMDTL_NBR_SERV"]),
					_originalClmdtl_amt_tech_billed = ConvertINT(Reader["CLMDTL_AMT_TECH_BILLED"]),
					_originalClmdtl_date_period_end = Reader["CLMDTL_DATE_PERIOD_END"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F002_DTL_BEFORE Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F002_DTL_BEFORE> Collection(ObservableCollection<F002_DTL_BEFORE>
                                                               f002DtlBefore = null)
        {
            if (IsSameSearch() && f002DtlBefore != null)
            {
                return f002DtlBefore;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F002_DTL_BEFORE>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("BATCTRL_BATCH_STATUS",WhereBatctrl_batch_status),
					new SqlParameter("BATCTRL_BATCH_TYPE",WhereBatctrl_batch_type),
					new SqlParameter("BATCTRL_ADJ_CD",WhereBatctrl_adj_cd),
					new SqlParameter("CLMHDR_CLINIC_NBR_1_2",WhereClmhdr_clinic_nbr_1_2),
					new SqlParameter("CLMHDR_BATCH_NBR",WhereClmhdr_batch_nbr),
					new SqlParameter("CLMHDR_CLAIM_NBR",WhereClmhdr_claim_nbr),
					new SqlParameter("CLMHDR_DOC_NBR",WhereClmhdr_doc_nbr),
					new SqlParameter("CLMHDR_DOC_DEPT",WhereClmhdr_doc_dept),
					new SqlParameter("CLMHDR_LOC",WhereClmhdr_loc),
					new SqlParameter("CLMHDR_AGENT_CD",WhereClmhdr_agent_cd),
					new SqlParameter("CLMHDR_MANUAL_AND_TAPE_PAYMENTS",WhereClmhdr_manual_and_tape_payments),
					new SqlParameter("CLMHDR_AMT_TECH_PAID",WhereClmhdr_amt_tech_paid),
					new SqlParameter("CLMHDR_I_O_PAT_IND",WhereClmhdr_i_o_pat_ind),
					new SqlParameter("CLMHDR_ADJ_CD_SUB_TYPE",WhereClmhdr_adj_cd_sub_type),
					new SqlParameter("CLMHDR_ADJ_CD",WhereClmhdr_adj_cd),
					new SqlParameter("CLMHDR_PAYROLL",WhereClmhdr_payroll),
					new SqlParameter("CLMDTL_OMA_CD",WhereClmdtl_oma_cd),
					new SqlParameter("CLMDTL_OMA_SUFF",WhereClmdtl_oma_suff),
					new SqlParameter("CLMDTL_FEE_OHIP",WhereClmdtl_fee_ohip),
					new SqlParameter("CLMDTL_NBR_SERV",WhereClmdtl_nbr_serv),
					new SqlParameter("CLMDTL_AMT_TECH_BILLED",WhereClmdtl_amt_tech_billed),
					new SqlParameter("CLMDTL_DATE_PERIOD_END",WhereClmdtl_date_period_end),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[SEQUENTIAL].[sp_F002_DTL_BEFORE_Match]", parameters);
            var collection = new ObservableCollection<F002_DTL_BEFORE>();

            while (Reader.Read())
            {
                collection.Add(new F002_DTL_BEFORE
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					BATCTRL_BATCH_STATUS = Reader["BATCTRL_BATCH_STATUS"].ToString(),
					BATCTRL_BATCH_TYPE = Reader["BATCTRL_BATCH_TYPE"].ToString(),
					BATCTRL_ADJ_CD = Reader["BATCTRL_ADJ_CD"].ToString(),
					CLMHDR_CLINIC_NBR_1_2 = ConvertDEC(Reader["CLMHDR_CLINIC_NBR_1_2"]),
					CLMHDR_BATCH_NBR = Reader["CLMHDR_BATCH_NBR"].ToString(),
					CLMHDR_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]),
					CLMHDR_DOC_NBR = Reader["CLMHDR_DOC_NBR"].ToString(),
					CLMHDR_DOC_DEPT = ConvertINT(Reader["CLMHDR_DOC_DEPT"]),
					CLMHDR_LOC = Reader["CLMHDR_LOC"].ToString(),
					CLMHDR_AGENT_CD = ConvertINT(Reader["CLMHDR_AGENT_CD"]),
					CLMHDR_MANUAL_AND_TAPE_PAYMENTS = ConvertINT(Reader["CLMHDR_MANUAL_AND_TAPE_PAYMENTS"]),
					CLMHDR_AMT_TECH_PAID = ConvertINT(Reader["CLMHDR_AMT_TECH_PAID"]),
					CLMHDR_I_O_PAT_IND = Reader["CLMHDR_I_O_PAT_IND"].ToString(),
					CLMHDR_ADJ_CD_SUB_TYPE = Reader["CLMHDR_ADJ_CD_SUB_TYPE"].ToString(),
					CLMHDR_ADJ_CD = Reader["CLMHDR_ADJ_CD"].ToString(),
					CLMHDR_PAYROLL = Reader["CLMHDR_PAYROLL"].ToString(),
					CLMDTL_OMA_CD = Reader["CLMDTL_OMA_CD"].ToString(),
					CLMDTL_OMA_SUFF = Reader["CLMDTL_OMA_SUFF"].ToString(),
					CLMDTL_FEE_OHIP = ConvertINT(Reader["CLMDTL_FEE_OHIP"]),
					CLMDTL_NBR_SERV = ConvertDEC(Reader["CLMDTL_NBR_SERV"]),
					CLMDTL_AMT_TECH_BILLED = ConvertINT(Reader["CLMDTL_AMT_TECH_BILLED"]),
					CLMDTL_DATE_PERIOD_END = Reader["CLMDTL_DATE_PERIOD_END"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereBatctrl_batch_status = WhereBatctrl_batch_status,
					_whereBatctrl_batch_type = WhereBatctrl_batch_type,
					_whereBatctrl_adj_cd = WhereBatctrl_adj_cd,
					_whereClmhdr_clinic_nbr_1_2 = WhereClmhdr_clinic_nbr_1_2,
					_whereClmhdr_batch_nbr = WhereClmhdr_batch_nbr,
					_whereClmhdr_claim_nbr = WhereClmhdr_claim_nbr,
					_whereClmhdr_doc_nbr = WhereClmhdr_doc_nbr,
					_whereClmhdr_doc_dept = WhereClmhdr_doc_dept,
					_whereClmhdr_loc = WhereClmhdr_loc,
					_whereClmhdr_agent_cd = WhereClmhdr_agent_cd,
					_whereClmhdr_manual_and_tape_payments = WhereClmhdr_manual_and_tape_payments,
					_whereClmhdr_amt_tech_paid = WhereClmhdr_amt_tech_paid,
					_whereClmhdr_i_o_pat_ind = WhereClmhdr_i_o_pat_ind,
					_whereClmhdr_adj_cd_sub_type = WhereClmhdr_adj_cd_sub_type,
					_whereClmhdr_adj_cd = WhereClmhdr_adj_cd,
					_whereClmhdr_payroll = WhereClmhdr_payroll,
					_whereClmdtl_oma_cd = WhereClmdtl_oma_cd,
					_whereClmdtl_oma_suff = WhereClmdtl_oma_suff,
					_whereClmdtl_fee_ohip = WhereClmdtl_fee_ohip,
					_whereClmdtl_nbr_serv = WhereClmdtl_nbr_serv,
					_whereClmdtl_amt_tech_billed = WhereClmdtl_amt_tech_billed,
					_whereClmdtl_date_period_end = WhereClmdtl_date_period_end,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalBatctrl_batch_status = Reader["BATCTRL_BATCH_STATUS"].ToString(),
					_originalBatctrl_batch_type = Reader["BATCTRL_BATCH_TYPE"].ToString(),
					_originalBatctrl_adj_cd = Reader["BATCTRL_ADJ_CD"].ToString(),
					_originalClmhdr_clinic_nbr_1_2 = ConvertDEC(Reader["CLMHDR_CLINIC_NBR_1_2"]),
					_originalClmhdr_batch_nbr = Reader["CLMHDR_BATCH_NBR"].ToString(),
					_originalClmhdr_claim_nbr = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]),
					_originalClmhdr_doc_nbr = Reader["CLMHDR_DOC_NBR"].ToString(),
					_originalClmhdr_doc_dept = ConvertINT(Reader["CLMHDR_DOC_DEPT"]),
					_originalClmhdr_loc = Reader["CLMHDR_LOC"].ToString(),
					_originalClmhdr_agent_cd = ConvertINT(Reader["CLMHDR_AGENT_CD"]),
					_originalClmhdr_manual_and_tape_payments = ConvertINT(Reader["CLMHDR_MANUAL_AND_TAPE_PAYMENTS"]),
					_originalClmhdr_amt_tech_paid = ConvertINT(Reader["CLMHDR_AMT_TECH_PAID"]),
					_originalClmhdr_i_o_pat_ind = Reader["CLMHDR_I_O_PAT_IND"].ToString(),
					_originalClmhdr_adj_cd_sub_type = Reader["CLMHDR_ADJ_CD_SUB_TYPE"].ToString(),
					_originalClmhdr_adj_cd = Reader["CLMHDR_ADJ_CD"].ToString(),
					_originalClmhdr_payroll = Reader["CLMHDR_PAYROLL"].ToString(),
					_originalClmdtl_oma_cd = Reader["CLMDTL_OMA_CD"].ToString(),
					_originalClmdtl_oma_suff = Reader["CLMDTL_OMA_SUFF"].ToString(),
					_originalClmdtl_fee_ohip = ConvertINT(Reader["CLMDTL_FEE_OHIP"]),
					_originalClmdtl_nbr_serv = ConvertDEC(Reader["CLMDTL_NBR_SERV"]),
					_originalClmdtl_amt_tech_billed = ConvertINT(Reader["CLMDTL_AMT_TECH_BILLED"]),
					_originalClmdtl_date_period_end = Reader["CLMDTL_DATE_PERIOD_END"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereBatctrl_batch_status = WhereBatctrl_batch_status;
					_whereBatctrl_batch_type = WhereBatctrl_batch_type;
					_whereBatctrl_adj_cd = WhereBatctrl_adj_cd;
					_whereClmhdr_clinic_nbr_1_2 = WhereClmhdr_clinic_nbr_1_2;
					_whereClmhdr_batch_nbr = WhereClmhdr_batch_nbr;
					_whereClmhdr_claim_nbr = WhereClmhdr_claim_nbr;
					_whereClmhdr_doc_nbr = WhereClmhdr_doc_nbr;
					_whereClmhdr_doc_dept = WhereClmhdr_doc_dept;
					_whereClmhdr_loc = WhereClmhdr_loc;
					_whereClmhdr_agent_cd = WhereClmhdr_agent_cd;
					_whereClmhdr_manual_and_tape_payments = WhereClmhdr_manual_and_tape_payments;
					_whereClmhdr_amt_tech_paid = WhereClmhdr_amt_tech_paid;
					_whereClmhdr_i_o_pat_ind = WhereClmhdr_i_o_pat_ind;
					_whereClmhdr_adj_cd_sub_type = WhereClmhdr_adj_cd_sub_type;
					_whereClmhdr_adj_cd = WhereClmhdr_adj_cd;
					_whereClmhdr_payroll = WhereClmhdr_payroll;
					_whereClmdtl_oma_cd = WhereClmdtl_oma_cd;
					_whereClmdtl_oma_suff = WhereClmdtl_oma_suff;
					_whereClmdtl_fee_ohip = WhereClmdtl_fee_ohip;
					_whereClmdtl_nbr_serv = WhereClmdtl_nbr_serv;
					_whereClmdtl_amt_tech_billed = WhereClmdtl_amt_tech_billed;
					_whereClmdtl_date_period_end = WhereClmdtl_date_period_end;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereBatctrl_batch_status == null 
				&& WhereBatctrl_batch_type == null 
				&& WhereBatctrl_adj_cd == null 
				&& WhereClmhdr_clinic_nbr_1_2 == null 
				&& WhereClmhdr_batch_nbr == null 
				&& WhereClmhdr_claim_nbr == null 
				&& WhereClmhdr_doc_nbr == null 
				&& WhereClmhdr_doc_dept == null 
				&& WhereClmhdr_loc == null 
				&& WhereClmhdr_agent_cd == null 
				&& WhereClmhdr_manual_and_tape_payments == null 
				&& WhereClmhdr_amt_tech_paid == null 
				&& WhereClmhdr_i_o_pat_ind == null 
				&& WhereClmhdr_adj_cd_sub_type == null 
				&& WhereClmhdr_adj_cd == null 
				&& WhereClmhdr_payroll == null 
				&& WhereClmdtl_oma_cd == null 
				&& WhereClmdtl_oma_suff == null 
				&& WhereClmdtl_fee_ohip == null 
				&& WhereClmdtl_nbr_serv == null 
				&& WhereClmdtl_amt_tech_billed == null 
				&& WhereClmdtl_date_period_end == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereBatctrl_batch_status ==  _whereBatctrl_batch_status
				&& WhereBatctrl_batch_type ==  _whereBatctrl_batch_type
				&& WhereBatctrl_adj_cd ==  _whereBatctrl_adj_cd
				&& WhereClmhdr_clinic_nbr_1_2 ==  _whereClmhdr_clinic_nbr_1_2
				&& WhereClmhdr_batch_nbr ==  _whereClmhdr_batch_nbr
				&& WhereClmhdr_claim_nbr ==  _whereClmhdr_claim_nbr
				&& WhereClmhdr_doc_nbr ==  _whereClmhdr_doc_nbr
				&& WhereClmhdr_doc_dept ==  _whereClmhdr_doc_dept
				&& WhereClmhdr_loc ==  _whereClmhdr_loc
				&& WhereClmhdr_agent_cd ==  _whereClmhdr_agent_cd
				&& WhereClmhdr_manual_and_tape_payments ==  _whereClmhdr_manual_and_tape_payments
				&& WhereClmhdr_amt_tech_paid ==  _whereClmhdr_amt_tech_paid
				&& WhereClmhdr_i_o_pat_ind ==  _whereClmhdr_i_o_pat_ind
				&& WhereClmhdr_adj_cd_sub_type ==  _whereClmhdr_adj_cd_sub_type
				&& WhereClmhdr_adj_cd ==  _whereClmhdr_adj_cd
				&& WhereClmhdr_payroll ==  _whereClmhdr_payroll
				&& WhereClmdtl_oma_cd ==  _whereClmdtl_oma_cd
				&& WhereClmdtl_oma_suff ==  _whereClmdtl_oma_suff
				&& WhereClmdtl_fee_ohip ==  _whereClmdtl_fee_ohip
				&& WhereClmdtl_nbr_serv ==  _whereClmdtl_nbr_serv
				&& WhereClmdtl_amt_tech_billed ==  _whereClmdtl_amt_tech_billed
				&& WhereClmdtl_date_period_end ==  _whereClmdtl_date_period_end
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereBatctrl_batch_status = null; 
			WhereBatctrl_batch_type = null; 
			WhereBatctrl_adj_cd = null; 
			WhereClmhdr_clinic_nbr_1_2 = null; 
			WhereClmhdr_batch_nbr = null; 
			WhereClmhdr_claim_nbr = null; 
			WhereClmhdr_doc_nbr = null; 
			WhereClmhdr_doc_dept = null; 
			WhereClmhdr_loc = null; 
			WhereClmhdr_agent_cd = null; 
			WhereClmhdr_manual_and_tape_payments = null; 
			WhereClmhdr_amt_tech_paid = null; 
			WhereClmhdr_i_o_pat_ind = null; 
			WhereClmhdr_adj_cd_sub_type = null; 
			WhereClmhdr_adj_cd = null; 
			WhereClmhdr_payroll = null; 
			WhereClmdtl_oma_cd = null; 
			WhereClmdtl_oma_suff = null; 
			WhereClmdtl_fee_ohip = null; 
			WhereClmdtl_nbr_serv = null; 
			WhereClmdtl_amt_tech_billed = null; 
			WhereClmdtl_date_period_end = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _BATCTRL_BATCH_STATUS;
		private string _BATCTRL_BATCH_TYPE;
		private string _BATCTRL_ADJ_CD;
		private decimal? _CLMHDR_CLINIC_NBR_1_2;
		private string _CLMHDR_BATCH_NBR;
		private decimal? _CLMHDR_CLAIM_NBR;
		private string _CLMHDR_DOC_NBR;
		private int? _CLMHDR_DOC_DEPT;
		private string _CLMHDR_LOC;
		private int? _CLMHDR_AGENT_CD;
		private int? _CLMHDR_MANUAL_AND_TAPE_PAYMENTS;
		private int? _CLMHDR_AMT_TECH_PAID;
		private string _CLMHDR_I_O_PAT_IND;
		private string _CLMHDR_ADJ_CD_SUB_TYPE;
		private string _CLMHDR_ADJ_CD;
		private string _CLMHDR_PAYROLL;
		private string _CLMDTL_OMA_CD;
		private string _CLMDTL_OMA_SUFF;
		private int? _CLMDTL_FEE_OHIP;
		private decimal? _CLMDTL_NBR_SERV;
		private int? _CLMDTL_AMT_TECH_BILLED;
		private string _CLMDTL_DATE_PERIOD_END;
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
		public string BATCTRL_BATCH_STATUS
		{
			get { return _BATCTRL_BATCH_STATUS; }
			set
			{
				if (_BATCTRL_BATCH_STATUS != value)
				{
					_BATCTRL_BATCH_STATUS = value;
					ChangeState();
				}
			}
		}
		public string BATCTRL_BATCH_TYPE
		{
			get { return _BATCTRL_BATCH_TYPE; }
			set
			{
				if (_BATCTRL_BATCH_TYPE != value)
				{
					_BATCTRL_BATCH_TYPE = value;
					ChangeState();
				}
			}
		}
		public string BATCTRL_ADJ_CD
		{
			get { return _BATCTRL_ADJ_CD; }
			set
			{
				if (_BATCTRL_ADJ_CD != value)
				{
					_BATCTRL_ADJ_CD = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_CLINIC_NBR_1_2
		{
			get { return _CLMHDR_CLINIC_NBR_1_2; }
			set
			{
				if (_CLMHDR_CLINIC_NBR_1_2 != value)
				{
					_CLMHDR_CLINIC_NBR_1_2 = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_BATCH_NBR
		{
			get { return _CLMHDR_BATCH_NBR; }
			set
			{
				if (_CLMHDR_BATCH_NBR != value)
				{
					_CLMHDR_BATCH_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_CLAIM_NBR
		{
			get { return _CLMHDR_CLAIM_NBR; }
			set
			{
				if (_CLMHDR_CLAIM_NBR != value)
				{
					_CLMHDR_CLAIM_NBR = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_DOC_NBR
		{
			get { return _CLMHDR_DOC_NBR; }
			set
			{
				if (_CLMHDR_DOC_NBR != value)
				{
					_CLMHDR_DOC_NBR = value;
					ChangeState();
				}
			}
		}
		public int? CLMHDR_DOC_DEPT
		{
			get { return _CLMHDR_DOC_DEPT; }
			set
			{
				if (_CLMHDR_DOC_DEPT != value)
				{
					_CLMHDR_DOC_DEPT = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_LOC
		{
			get { return _CLMHDR_LOC; }
			set
			{
				if (_CLMHDR_LOC != value)
				{
					_CLMHDR_LOC = value;
					ChangeState();
				}
			}
		}
		public int? CLMHDR_AGENT_CD
		{
			get { return _CLMHDR_AGENT_CD; }
			set
			{
				if (_CLMHDR_AGENT_CD != value)
				{
					_CLMHDR_AGENT_CD = value;
					ChangeState();
				}
			}
		}
		public int? CLMHDR_MANUAL_AND_TAPE_PAYMENTS
		{
			get { return _CLMHDR_MANUAL_AND_TAPE_PAYMENTS; }
			set
			{
				if (_CLMHDR_MANUAL_AND_TAPE_PAYMENTS != value)
				{
					_CLMHDR_MANUAL_AND_TAPE_PAYMENTS = value;
					ChangeState();
				}
			}
		}
		public int? CLMHDR_AMT_TECH_PAID
		{
			get { return _CLMHDR_AMT_TECH_PAID; }
			set
			{
				if (_CLMHDR_AMT_TECH_PAID != value)
				{
					_CLMHDR_AMT_TECH_PAID = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_I_O_PAT_IND
		{
			get { return _CLMHDR_I_O_PAT_IND; }
			set
			{
				if (_CLMHDR_I_O_PAT_IND != value)
				{
					_CLMHDR_I_O_PAT_IND = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_ADJ_CD_SUB_TYPE
		{
			get { return _CLMHDR_ADJ_CD_SUB_TYPE; }
			set
			{
				if (_CLMHDR_ADJ_CD_SUB_TYPE != value)
				{
					_CLMHDR_ADJ_CD_SUB_TYPE = value;
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
		public string CLMHDR_PAYROLL
		{
			get { return _CLMHDR_PAYROLL; }
			set
			{
				if (_CLMHDR_PAYROLL != value)
				{
					_CLMHDR_PAYROLL = value;
					ChangeState();
				}
			}
		}
		public string CLMDTL_OMA_CD
		{
			get { return _CLMDTL_OMA_CD; }
			set
			{
				if (_CLMDTL_OMA_CD != value)
				{
					_CLMDTL_OMA_CD = value;
					ChangeState();
				}
			}
		}
		public string CLMDTL_OMA_SUFF
		{
			get { return _CLMDTL_OMA_SUFF; }
			set
			{
				if (_CLMDTL_OMA_SUFF != value)
				{
					_CLMDTL_OMA_SUFF = value;
					ChangeState();
				}
			}
		}
		public int? CLMDTL_FEE_OHIP
		{
			get { return _CLMDTL_FEE_OHIP; }
			set
			{
				if (_CLMDTL_FEE_OHIP != value)
				{
					_CLMDTL_FEE_OHIP = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMDTL_NBR_SERV
		{
			get { return _CLMDTL_NBR_SERV; }
			set
			{
				if (_CLMDTL_NBR_SERV != value)
				{
					_CLMDTL_NBR_SERV = value;
					ChangeState();
				}
			}
		}
		public int? CLMDTL_AMT_TECH_BILLED
		{
			get { return _CLMDTL_AMT_TECH_BILLED; }
			set
			{
				if (_CLMDTL_AMT_TECH_BILLED != value)
				{
					_CLMDTL_AMT_TECH_BILLED = value;
					ChangeState();
				}
			}
		}
		public string CLMDTL_DATE_PERIOD_END
		{
			get { return _CLMDTL_DATE_PERIOD_END; }
			set
			{
				if (_CLMDTL_DATE_PERIOD_END != value)
				{
					_CLMDTL_DATE_PERIOD_END = value;
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
		public string WhereBatctrl_batch_status { get; set; }
		private string _whereBatctrl_batch_status;
		public string WhereBatctrl_batch_type { get; set; }
		private string _whereBatctrl_batch_type;
		public string WhereBatctrl_adj_cd { get; set; }
		private string _whereBatctrl_adj_cd;
		public decimal? WhereClmhdr_clinic_nbr_1_2 { get; set; }
		private decimal? _whereClmhdr_clinic_nbr_1_2;
		public string WhereClmhdr_batch_nbr { get; set; }
		private string _whereClmhdr_batch_nbr;
		public decimal? WhereClmhdr_claim_nbr { get; set; }
		private decimal? _whereClmhdr_claim_nbr;
		public string WhereClmhdr_doc_nbr { get; set; }
		private string _whereClmhdr_doc_nbr;
		public int? WhereClmhdr_doc_dept { get; set; }
		private int? _whereClmhdr_doc_dept;
		public string WhereClmhdr_loc { get; set; }
		private string _whereClmhdr_loc;
		public int? WhereClmhdr_agent_cd { get; set; }
		private int? _whereClmhdr_agent_cd;
		public int? WhereClmhdr_manual_and_tape_payments { get; set; }
		private int? _whereClmhdr_manual_and_tape_payments;
		public int? WhereClmhdr_amt_tech_paid { get; set; }
		private int? _whereClmhdr_amt_tech_paid;
		public string WhereClmhdr_i_o_pat_ind { get; set; }
		private string _whereClmhdr_i_o_pat_ind;
		public string WhereClmhdr_adj_cd_sub_type { get; set; }
		private string _whereClmhdr_adj_cd_sub_type;
		public string WhereClmhdr_adj_cd { get; set; }
		private string _whereClmhdr_adj_cd;
		public string WhereClmhdr_payroll { get; set; }
		private string _whereClmhdr_payroll;
		public string WhereClmdtl_oma_cd { get; set; }
		private string _whereClmdtl_oma_cd;
		public string WhereClmdtl_oma_suff { get; set; }
		private string _whereClmdtl_oma_suff;
		public int? WhereClmdtl_fee_ohip { get; set; }
		private int? _whereClmdtl_fee_ohip;
		public decimal? WhereClmdtl_nbr_serv { get; set; }
		private decimal? _whereClmdtl_nbr_serv;
		public int? WhereClmdtl_amt_tech_billed { get; set; }
		private int? _whereClmdtl_amt_tech_billed;
		public string WhereClmdtl_date_period_end { get; set; }
		private string _whereClmdtl_date_period_end;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalBatctrl_batch_status;
		private string _originalBatctrl_batch_type;
		private string _originalBatctrl_adj_cd;
		private decimal? _originalClmhdr_clinic_nbr_1_2;
		private string _originalClmhdr_batch_nbr;
		private decimal? _originalClmhdr_claim_nbr;
		private string _originalClmhdr_doc_nbr;
		private int? _originalClmhdr_doc_dept;
		private string _originalClmhdr_loc;
		private int? _originalClmhdr_agent_cd;
		private int? _originalClmhdr_manual_and_tape_payments;
		private int? _originalClmhdr_amt_tech_paid;
		private string _originalClmhdr_i_o_pat_ind;
		private string _originalClmhdr_adj_cd_sub_type;
		private string _originalClmhdr_adj_cd;
		private string _originalClmhdr_payroll;
		private string _originalClmdtl_oma_cd;
		private string _originalClmdtl_oma_suff;
		private int? _originalClmdtl_fee_ohip;
		private decimal? _originalClmdtl_nbr_serv;
		private int? _originalClmdtl_amt_tech_billed;
		private string _originalClmdtl_date_period_end;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			BATCTRL_BATCH_STATUS = _originalBatctrl_batch_status;
			BATCTRL_BATCH_TYPE = _originalBatctrl_batch_type;
			BATCTRL_ADJ_CD = _originalBatctrl_adj_cd;
			CLMHDR_CLINIC_NBR_1_2 = _originalClmhdr_clinic_nbr_1_2;
			CLMHDR_BATCH_NBR = _originalClmhdr_batch_nbr;
			CLMHDR_CLAIM_NBR = _originalClmhdr_claim_nbr;
			CLMHDR_DOC_NBR = _originalClmhdr_doc_nbr;
			CLMHDR_DOC_DEPT = _originalClmhdr_doc_dept;
			CLMHDR_LOC = _originalClmhdr_loc;
			CLMHDR_AGENT_CD = _originalClmhdr_agent_cd;
			CLMHDR_MANUAL_AND_TAPE_PAYMENTS = _originalClmhdr_manual_and_tape_payments;
			CLMHDR_AMT_TECH_PAID = _originalClmhdr_amt_tech_paid;
			CLMHDR_I_O_PAT_IND = _originalClmhdr_i_o_pat_ind;
			CLMHDR_ADJ_CD_SUB_TYPE = _originalClmhdr_adj_cd_sub_type;
			CLMHDR_ADJ_CD = _originalClmhdr_adj_cd;
			CLMHDR_PAYROLL = _originalClmhdr_payroll;
			CLMDTL_OMA_CD = _originalClmdtl_oma_cd;
			CLMDTL_OMA_SUFF = _originalClmdtl_oma_suff;
			CLMDTL_FEE_OHIP = _originalClmdtl_fee_ohip;
			CLMDTL_NBR_SERV = _originalClmdtl_nbr_serv;
			CLMDTL_AMT_TECH_BILLED = _originalClmdtl_amt_tech_billed;
			CLMDTL_DATE_PERIOD_END = _originalClmdtl_date_period_end;
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
			RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_F002_DTL_BEFORE_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_F002_DTL_BEFORE_Purge]");
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
						new SqlParameter("BATCTRL_BATCH_STATUS", SqlNull(BATCTRL_BATCH_STATUS)),
						new SqlParameter("BATCTRL_BATCH_TYPE", SqlNull(BATCTRL_BATCH_TYPE)),
						new SqlParameter("BATCTRL_ADJ_CD", SqlNull(BATCTRL_ADJ_CD)),
						new SqlParameter("CLMHDR_CLINIC_NBR_1_2", SqlNull(CLMHDR_CLINIC_NBR_1_2)),
						new SqlParameter("CLMHDR_BATCH_NBR", SqlNull(CLMHDR_BATCH_NBR)),
						new SqlParameter("CLMHDR_CLAIM_NBR", SqlNull(CLMHDR_CLAIM_NBR)),
						new SqlParameter("CLMHDR_DOC_NBR", SqlNull(CLMHDR_DOC_NBR)),
						new SqlParameter("CLMHDR_DOC_DEPT", SqlNull(CLMHDR_DOC_DEPT)),
						new SqlParameter("CLMHDR_LOC", SqlNull(CLMHDR_LOC)),
						new SqlParameter("CLMHDR_AGENT_CD", SqlNull(CLMHDR_AGENT_CD)),
						new SqlParameter("CLMHDR_MANUAL_AND_TAPE_PAYMENTS", SqlNull(CLMHDR_MANUAL_AND_TAPE_PAYMENTS)),
						new SqlParameter("CLMHDR_AMT_TECH_PAID", SqlNull(CLMHDR_AMT_TECH_PAID)),
						new SqlParameter("CLMHDR_I_O_PAT_IND", SqlNull(CLMHDR_I_O_PAT_IND)),
						new SqlParameter("CLMHDR_ADJ_CD_SUB_TYPE", SqlNull(CLMHDR_ADJ_CD_SUB_TYPE)),
						new SqlParameter("CLMHDR_ADJ_CD", SqlNull(CLMHDR_ADJ_CD)),
						new SqlParameter("CLMHDR_PAYROLL", SqlNull(CLMHDR_PAYROLL)),
						new SqlParameter("CLMDTL_OMA_CD", SqlNull(CLMDTL_OMA_CD)),
						new SqlParameter("CLMDTL_OMA_SUFF", SqlNull(CLMDTL_OMA_SUFF)),
						new SqlParameter("CLMDTL_FEE_OHIP", SqlNull(CLMDTL_FEE_OHIP)),
						new SqlParameter("CLMDTL_NBR_SERV", SqlNull(CLMDTL_NBR_SERV)),
						new SqlParameter("CLMDTL_AMT_TECH_BILLED", SqlNull(CLMDTL_AMT_TECH_BILLED)),
						new SqlParameter("CLMDTL_DATE_PERIOD_END", SqlNull(CLMDTL_DATE_PERIOD_END)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_F002_DTL_BEFORE_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						BATCTRL_BATCH_STATUS = Reader["BATCTRL_BATCH_STATUS"].ToString();
						BATCTRL_BATCH_TYPE = Reader["BATCTRL_BATCH_TYPE"].ToString();
						BATCTRL_ADJ_CD = Reader["BATCTRL_ADJ_CD"].ToString();
						CLMHDR_CLINIC_NBR_1_2 = ConvertDEC(Reader["CLMHDR_CLINIC_NBR_1_2"]);
						CLMHDR_BATCH_NBR = Reader["CLMHDR_BATCH_NBR"].ToString();
						CLMHDR_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]);
						CLMHDR_DOC_NBR = Reader["CLMHDR_DOC_NBR"].ToString();
						CLMHDR_DOC_DEPT = ConvertINT(Reader["CLMHDR_DOC_DEPT"]);
						CLMHDR_LOC = Reader["CLMHDR_LOC"].ToString();
						CLMHDR_AGENT_CD = ConvertINT(Reader["CLMHDR_AGENT_CD"]);
						CLMHDR_MANUAL_AND_TAPE_PAYMENTS = ConvertINT(Reader["CLMHDR_MANUAL_AND_TAPE_PAYMENTS"]);
						CLMHDR_AMT_TECH_PAID = ConvertINT(Reader["CLMHDR_AMT_TECH_PAID"]);
						CLMHDR_I_O_PAT_IND = Reader["CLMHDR_I_O_PAT_IND"].ToString();
						CLMHDR_ADJ_CD_SUB_TYPE = Reader["CLMHDR_ADJ_CD_SUB_TYPE"].ToString();
						CLMHDR_ADJ_CD = Reader["CLMHDR_ADJ_CD"].ToString();
						CLMHDR_PAYROLL = Reader["CLMHDR_PAYROLL"].ToString();
						CLMDTL_OMA_CD = Reader["CLMDTL_OMA_CD"].ToString();
						CLMDTL_OMA_SUFF = Reader["CLMDTL_OMA_SUFF"].ToString();
						CLMDTL_FEE_OHIP = ConvertINT(Reader["CLMDTL_FEE_OHIP"]);
						CLMDTL_NBR_SERV = ConvertDEC(Reader["CLMDTL_NBR_SERV"]);
						CLMDTL_AMT_TECH_BILLED = ConvertINT(Reader["CLMDTL_AMT_TECH_BILLED"]);
						CLMDTL_DATE_PERIOD_END = Reader["CLMDTL_DATE_PERIOD_END"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalBatctrl_batch_status = Reader["BATCTRL_BATCH_STATUS"].ToString();
						_originalBatctrl_batch_type = Reader["BATCTRL_BATCH_TYPE"].ToString();
						_originalBatctrl_adj_cd = Reader["BATCTRL_ADJ_CD"].ToString();
						_originalClmhdr_clinic_nbr_1_2 = ConvertDEC(Reader["CLMHDR_CLINIC_NBR_1_2"]);
						_originalClmhdr_batch_nbr = Reader["CLMHDR_BATCH_NBR"].ToString();
						_originalClmhdr_claim_nbr = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]);
						_originalClmhdr_doc_nbr = Reader["CLMHDR_DOC_NBR"].ToString();
						_originalClmhdr_doc_dept = ConvertINT(Reader["CLMHDR_DOC_DEPT"]);
						_originalClmhdr_loc = Reader["CLMHDR_LOC"].ToString();
						_originalClmhdr_agent_cd = ConvertINT(Reader["CLMHDR_AGENT_CD"]);
						_originalClmhdr_manual_and_tape_payments = ConvertINT(Reader["CLMHDR_MANUAL_AND_TAPE_PAYMENTS"]);
						_originalClmhdr_amt_tech_paid = ConvertINT(Reader["CLMHDR_AMT_TECH_PAID"]);
						_originalClmhdr_i_o_pat_ind = Reader["CLMHDR_I_O_PAT_IND"].ToString();
						_originalClmhdr_adj_cd_sub_type = Reader["CLMHDR_ADJ_CD_SUB_TYPE"].ToString();
						_originalClmhdr_adj_cd = Reader["CLMHDR_ADJ_CD"].ToString();
						_originalClmhdr_payroll = Reader["CLMHDR_PAYROLL"].ToString();
						_originalClmdtl_oma_cd = Reader["CLMDTL_OMA_CD"].ToString();
						_originalClmdtl_oma_suff = Reader["CLMDTL_OMA_SUFF"].ToString();
						_originalClmdtl_fee_ohip = ConvertINT(Reader["CLMDTL_FEE_OHIP"]);
						_originalClmdtl_nbr_serv = ConvertDEC(Reader["CLMDTL_NBR_SERV"]);
						_originalClmdtl_amt_tech_billed = ConvertINT(Reader["CLMDTL_AMT_TECH_BILLED"]);
						_originalClmdtl_date_period_end = Reader["CLMDTL_DATE_PERIOD_END"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("BATCTRL_BATCH_STATUS", SqlNull(BATCTRL_BATCH_STATUS)),
						new SqlParameter("BATCTRL_BATCH_TYPE", SqlNull(BATCTRL_BATCH_TYPE)),
						new SqlParameter("BATCTRL_ADJ_CD", SqlNull(BATCTRL_ADJ_CD)),
						new SqlParameter("CLMHDR_CLINIC_NBR_1_2", SqlNull(CLMHDR_CLINIC_NBR_1_2)),
						new SqlParameter("CLMHDR_BATCH_NBR", SqlNull(CLMHDR_BATCH_NBR)),
						new SqlParameter("CLMHDR_CLAIM_NBR", SqlNull(CLMHDR_CLAIM_NBR)),
						new SqlParameter("CLMHDR_DOC_NBR", SqlNull(CLMHDR_DOC_NBR)),
						new SqlParameter("CLMHDR_DOC_DEPT", SqlNull(CLMHDR_DOC_DEPT)),
						new SqlParameter("CLMHDR_LOC", SqlNull(CLMHDR_LOC)),
						new SqlParameter("CLMHDR_AGENT_CD", SqlNull(CLMHDR_AGENT_CD)),
						new SqlParameter("CLMHDR_MANUAL_AND_TAPE_PAYMENTS", SqlNull(CLMHDR_MANUAL_AND_TAPE_PAYMENTS)),
						new SqlParameter("CLMHDR_AMT_TECH_PAID", SqlNull(CLMHDR_AMT_TECH_PAID)),
						new SqlParameter("CLMHDR_I_O_PAT_IND", SqlNull(CLMHDR_I_O_PAT_IND)),
						new SqlParameter("CLMHDR_ADJ_CD_SUB_TYPE", SqlNull(CLMHDR_ADJ_CD_SUB_TYPE)),
						new SqlParameter("CLMHDR_ADJ_CD", SqlNull(CLMHDR_ADJ_CD)),
						new SqlParameter("CLMHDR_PAYROLL", SqlNull(CLMHDR_PAYROLL)),
						new SqlParameter("CLMDTL_OMA_CD", SqlNull(CLMDTL_OMA_CD)),
						new SqlParameter("CLMDTL_OMA_SUFF", SqlNull(CLMDTL_OMA_SUFF)),
						new SqlParameter("CLMDTL_FEE_OHIP", SqlNull(CLMDTL_FEE_OHIP)),
						new SqlParameter("CLMDTL_NBR_SERV", SqlNull(CLMDTL_NBR_SERV)),
						new SqlParameter("CLMDTL_AMT_TECH_BILLED", SqlNull(CLMDTL_AMT_TECH_BILLED)),
						new SqlParameter("CLMDTL_DATE_PERIOD_END", SqlNull(CLMDTL_DATE_PERIOD_END)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_F002_DTL_BEFORE_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						BATCTRL_BATCH_STATUS = Reader["BATCTRL_BATCH_STATUS"].ToString();
						BATCTRL_BATCH_TYPE = Reader["BATCTRL_BATCH_TYPE"].ToString();
						BATCTRL_ADJ_CD = Reader["BATCTRL_ADJ_CD"].ToString();
						CLMHDR_CLINIC_NBR_1_2 = ConvertDEC(Reader["CLMHDR_CLINIC_NBR_1_2"]);
						CLMHDR_BATCH_NBR = Reader["CLMHDR_BATCH_NBR"].ToString();
						CLMHDR_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]);
						CLMHDR_DOC_NBR = Reader["CLMHDR_DOC_NBR"].ToString();
						CLMHDR_DOC_DEPT = ConvertINT(Reader["CLMHDR_DOC_DEPT"]);
						CLMHDR_LOC = Reader["CLMHDR_LOC"].ToString();
						CLMHDR_AGENT_CD = ConvertINT(Reader["CLMHDR_AGENT_CD"]);
						CLMHDR_MANUAL_AND_TAPE_PAYMENTS = ConvertINT(Reader["CLMHDR_MANUAL_AND_TAPE_PAYMENTS"]);
						CLMHDR_AMT_TECH_PAID = ConvertINT(Reader["CLMHDR_AMT_TECH_PAID"]);
						CLMHDR_I_O_PAT_IND = Reader["CLMHDR_I_O_PAT_IND"].ToString();
						CLMHDR_ADJ_CD_SUB_TYPE = Reader["CLMHDR_ADJ_CD_SUB_TYPE"].ToString();
						CLMHDR_ADJ_CD = Reader["CLMHDR_ADJ_CD"].ToString();
						CLMHDR_PAYROLL = Reader["CLMHDR_PAYROLL"].ToString();
						CLMDTL_OMA_CD = Reader["CLMDTL_OMA_CD"].ToString();
						CLMDTL_OMA_SUFF = Reader["CLMDTL_OMA_SUFF"].ToString();
						CLMDTL_FEE_OHIP = ConvertINT(Reader["CLMDTL_FEE_OHIP"]);
						CLMDTL_NBR_SERV = ConvertDEC(Reader["CLMDTL_NBR_SERV"]);
						CLMDTL_AMT_TECH_BILLED = ConvertINT(Reader["CLMDTL_AMT_TECH_BILLED"]);
						CLMDTL_DATE_PERIOD_END = Reader["CLMDTL_DATE_PERIOD_END"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalBatctrl_batch_status = Reader["BATCTRL_BATCH_STATUS"].ToString();
						_originalBatctrl_batch_type = Reader["BATCTRL_BATCH_TYPE"].ToString();
						_originalBatctrl_adj_cd = Reader["BATCTRL_ADJ_CD"].ToString();
						_originalClmhdr_clinic_nbr_1_2 = ConvertDEC(Reader["CLMHDR_CLINIC_NBR_1_2"]);
						_originalClmhdr_batch_nbr = Reader["CLMHDR_BATCH_NBR"].ToString();
						_originalClmhdr_claim_nbr = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]);
						_originalClmhdr_doc_nbr = Reader["CLMHDR_DOC_NBR"].ToString();
						_originalClmhdr_doc_dept = ConvertINT(Reader["CLMHDR_DOC_DEPT"]);
						_originalClmhdr_loc = Reader["CLMHDR_LOC"].ToString();
						_originalClmhdr_agent_cd = ConvertINT(Reader["CLMHDR_AGENT_CD"]);
						_originalClmhdr_manual_and_tape_payments = ConvertINT(Reader["CLMHDR_MANUAL_AND_TAPE_PAYMENTS"]);
						_originalClmhdr_amt_tech_paid = ConvertINT(Reader["CLMHDR_AMT_TECH_PAID"]);
						_originalClmhdr_i_o_pat_ind = Reader["CLMHDR_I_O_PAT_IND"].ToString();
						_originalClmhdr_adj_cd_sub_type = Reader["CLMHDR_ADJ_CD_SUB_TYPE"].ToString();
						_originalClmhdr_adj_cd = Reader["CLMHDR_ADJ_CD"].ToString();
						_originalClmhdr_payroll = Reader["CLMHDR_PAYROLL"].ToString();
						_originalClmdtl_oma_cd = Reader["CLMDTL_OMA_CD"].ToString();
						_originalClmdtl_oma_suff = Reader["CLMDTL_OMA_SUFF"].ToString();
						_originalClmdtl_fee_ohip = ConvertINT(Reader["CLMDTL_FEE_OHIP"]);
						_originalClmdtl_nbr_serv = ConvertDEC(Reader["CLMDTL_NBR_SERV"]);
						_originalClmdtl_amt_tech_billed = ConvertINT(Reader["CLMDTL_AMT_TECH_BILLED"]);
						_originalClmdtl_date_period_end = Reader["CLMDTL_DATE_PERIOD_END"].ToString();
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