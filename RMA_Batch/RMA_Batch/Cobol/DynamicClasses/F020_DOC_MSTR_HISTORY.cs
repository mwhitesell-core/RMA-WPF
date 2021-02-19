using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F020_DOC_MSTR_HISTORY : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F020_DOC_MSTR_HISTORY> Collection( Guid? rowid,
															string doc_nbr,
															decimal? ep_nbrmin,
															decimal? ep_nbrmax,
															decimal? doc_bank_nbrmin,
															decimal? doc_bank_nbrmax,
															decimal? doc_bank_branchmin,
															decimal? doc_bank_branchmax,
															string doc_bank_acct,
															decimal? doc_ytdguamin,
															decimal? doc_ytdguamax,
															decimal? doc_ytdgubmin,
															decimal? doc_ytdgubmax,
															decimal? doc_ytdgucmin,
															decimal? doc_ytdgucmax,
															decimal? doc_ytdgudmin,
															decimal? doc_ytdgudmax,
															decimal? doc_ytdceamin,
															decimal? doc_ytdceamax,
															decimal? doc_ytdcexmin,
															decimal? doc_ytdcexmax,
															decimal? doc_ytdearmin,
															decimal? doc_ytdearmax,
															decimal? doc_ytdincmin,
															decimal? doc_ytdincmax,
															decimal? doc_ytdeftmin,
															decimal? doc_ytdeftmax,
															decimal? doc_totinc_gmin,
															decimal? doc_totinc_gmax,
															decimal? doc_ep_date_depositmin,
															decimal? doc_ep_date_depositmax,
															decimal? doc_totincmin,
															decimal? doc_totincmax,
															decimal? doc_ep_ceiexpmin,
															decimal? doc_ep_ceiexpmax,
															decimal? doc_adjceamin,
															decimal? doc_adjceamax,
															decimal? doc_adjcexmin,
															decimal? doc_adjcexmax,
															decimal? doc_ceiceamin,
															decimal? doc_ceiceamax,
															decimal? doc_ceicexmin,
															decimal? doc_ceicexmax,
															string ceicea_prt_format,
															string ceicex_prt_format,
															string ytdcea_prt_format,
															string ytdcex_prt_format,
															decimal? doc_ytdinc_gmin,
															decimal? doc_ytdinc_gmax,
															long? doc_rma_expense_percent_miscmin,
															long? doc_rma_expense_percent_miscmax,
															long? doc_rma_expense_percent_regmin,
															long? doc_rma_expense_percent_regmax,
															decimal? doc_yrly_ceiling_computedmin,
															decimal? doc_yrly_ceiling_computedmax,
															decimal? doc_yrly_expense_computedmin,
															decimal? doc_yrly_expense_computedmax,
															decimal? doc_payeftmin,
															decimal? doc_payeftmax,
															decimal? doc_ytddedmin,
															decimal? doc_ytddedmax,
															long? doc_dept_expense_percent_miscmin,
															long? doc_dept_expense_percent_miscmax,
															long? doc_dept_expense_percent_regmin,
															long? doc_dept_expense_percent_regmax,
															long? doc_ep_pedmin,
															long? doc_ep_pedmax,
															string doc_ep_pay_code,
															string doc_ep_pay_sub_code,
															decimal? doc_yrly_require_revenuemin,
															decimal? doc_yrly_require_revenuemax,
															decimal? doc_yrly_target_revenuemin,
															decimal? doc_yrly_target_revenuemax,
															decimal? doc_ceireqmin,
															decimal? doc_ceireqmax,
															decimal? doc_ytdreqmin,
															decimal? doc_ytdreqmax,
															decimal? doc_ceitarmin,
															decimal? doc_ceitarmax,
															decimal? doc_ytdtarmin,
															decimal? doc_ytdtarmax,
															string ceireq_prt_format,
															string ytdreq_prt_format,
															string ceitar_prt_format,
															string ytdtar_prt_format,
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
					new SqlParameter("minEP_NBR",ep_nbrmin),
					new SqlParameter("maxEP_NBR",ep_nbrmax),
					new SqlParameter("minDOC_BANK_NBR",doc_bank_nbrmin),
					new SqlParameter("maxDOC_BANK_NBR",doc_bank_nbrmax),
					new SqlParameter("minDOC_BANK_BRANCH",doc_bank_branchmin),
					new SqlParameter("maxDOC_BANK_BRANCH",doc_bank_branchmax),
					new SqlParameter("DOC_BANK_ACCT",doc_bank_acct),
					new SqlParameter("minDOC_YTDGUA",doc_ytdguamin),
					new SqlParameter("maxDOC_YTDGUA",doc_ytdguamax),
					new SqlParameter("minDOC_YTDGUB",doc_ytdgubmin),
					new SqlParameter("maxDOC_YTDGUB",doc_ytdgubmax),
					new SqlParameter("minDOC_YTDGUC",doc_ytdgucmin),
					new SqlParameter("maxDOC_YTDGUC",doc_ytdgucmax),
					new SqlParameter("minDOC_YTDGUD",doc_ytdgudmin),
					new SqlParameter("maxDOC_YTDGUD",doc_ytdgudmax),
					new SqlParameter("minDOC_YTDCEA",doc_ytdceamin),
					new SqlParameter("maxDOC_YTDCEA",doc_ytdceamax),
					new SqlParameter("minDOC_YTDCEX",doc_ytdcexmin),
					new SqlParameter("maxDOC_YTDCEX",doc_ytdcexmax),
					new SqlParameter("minDOC_YTDEAR",doc_ytdearmin),
					new SqlParameter("maxDOC_YTDEAR",doc_ytdearmax),
					new SqlParameter("minDOC_YTDINC",doc_ytdincmin),
					new SqlParameter("maxDOC_YTDINC",doc_ytdincmax),
					new SqlParameter("minDOC_YTDEFT",doc_ytdeftmin),
					new SqlParameter("maxDOC_YTDEFT",doc_ytdeftmax),
					new SqlParameter("minDOC_TOTINC_G",doc_totinc_gmin),
					new SqlParameter("maxDOC_TOTINC_G",doc_totinc_gmax),
					new SqlParameter("minDOC_EP_DATE_DEPOSIT",doc_ep_date_depositmin),
					new SqlParameter("maxDOC_EP_DATE_DEPOSIT",doc_ep_date_depositmax),
					new SqlParameter("minDOC_TOTINC",doc_totincmin),
					new SqlParameter("maxDOC_TOTINC",doc_totincmax),
					new SqlParameter("minDOC_EP_CEIEXP",doc_ep_ceiexpmin),
					new SqlParameter("maxDOC_EP_CEIEXP",doc_ep_ceiexpmax),
					new SqlParameter("minDOC_ADJCEA",doc_adjceamin),
					new SqlParameter("maxDOC_ADJCEA",doc_adjceamax),
					new SqlParameter("minDOC_ADJCEX",doc_adjcexmin),
					new SqlParameter("maxDOC_ADJCEX",doc_adjcexmax),
					new SqlParameter("minDOC_CEICEA",doc_ceiceamin),
					new SqlParameter("maxDOC_CEICEA",doc_ceiceamax),
					new SqlParameter("minDOC_CEICEX",doc_ceicexmin),
					new SqlParameter("maxDOC_CEICEX",doc_ceicexmax),
					new SqlParameter("CEICEA_PRT_FORMAT",ceicea_prt_format),
					new SqlParameter("CEICEX_PRT_FORMAT",ceicex_prt_format),
					new SqlParameter("YTDCEA_PRT_FORMAT",ytdcea_prt_format),
					new SqlParameter("YTDCEX_PRT_FORMAT",ytdcex_prt_format),
					new SqlParameter("minDOC_YTDINC_G",doc_ytdinc_gmin),
					new SqlParameter("maxDOC_YTDINC_G",doc_ytdinc_gmax),
					new SqlParameter("minDOC_RMA_EXPENSE_PERCENT_MISC",doc_rma_expense_percent_miscmin),
					new SqlParameter("maxDOC_RMA_EXPENSE_PERCENT_MISC",doc_rma_expense_percent_miscmax),
					new SqlParameter("minDOC_RMA_EXPENSE_PERCENT_REG",doc_rma_expense_percent_regmin),
					new SqlParameter("maxDOC_RMA_EXPENSE_PERCENT_REG",doc_rma_expense_percent_regmax),
					new SqlParameter("minDOC_YRLY_CEILING_COMPUTED",doc_yrly_ceiling_computedmin),
					new SqlParameter("maxDOC_YRLY_CEILING_COMPUTED",doc_yrly_ceiling_computedmax),
					new SqlParameter("minDOC_YRLY_EXPENSE_COMPUTED",doc_yrly_expense_computedmin),
					new SqlParameter("maxDOC_YRLY_EXPENSE_COMPUTED",doc_yrly_expense_computedmax),
					new SqlParameter("minDOC_PAYEFT",doc_payeftmin),
					new SqlParameter("maxDOC_PAYEFT",doc_payeftmax),
					new SqlParameter("minDOC_YTDDED",doc_ytddedmin),
					new SqlParameter("maxDOC_YTDDED",doc_ytddedmax),
					new SqlParameter("minDOC_DEPT_EXPENSE_PERCENT_MISC",doc_dept_expense_percent_miscmin),
					new SqlParameter("maxDOC_DEPT_EXPENSE_PERCENT_MISC",doc_dept_expense_percent_miscmax),
					new SqlParameter("minDOC_DEPT_EXPENSE_PERCENT_REG",doc_dept_expense_percent_regmin),
					new SqlParameter("maxDOC_DEPT_EXPENSE_PERCENT_REG",doc_dept_expense_percent_regmax),
					new SqlParameter("minDOC_EP_PED",doc_ep_pedmin),
					new SqlParameter("maxDOC_EP_PED",doc_ep_pedmax),
					new SqlParameter("DOC_EP_PAY_CODE",doc_ep_pay_code),
					new SqlParameter("DOC_EP_PAY_SUB_CODE",doc_ep_pay_sub_code),
					new SqlParameter("minDOC_YRLY_REQUIRE_REVENUE",doc_yrly_require_revenuemin),
					new SqlParameter("maxDOC_YRLY_REQUIRE_REVENUE",doc_yrly_require_revenuemax),
					new SqlParameter("minDOC_YRLY_TARGET_REVENUE",doc_yrly_target_revenuemin),
					new SqlParameter("maxDOC_YRLY_TARGET_REVENUE",doc_yrly_target_revenuemax),
					new SqlParameter("minDOC_CEIREQ",doc_ceireqmin),
					new SqlParameter("maxDOC_CEIREQ",doc_ceireqmax),
					new SqlParameter("minDOC_YTDREQ",doc_ytdreqmin),
					new SqlParameter("maxDOC_YTDREQ",doc_ytdreqmax),
					new SqlParameter("minDOC_CEITAR",doc_ceitarmin),
					new SqlParameter("maxDOC_CEITAR",doc_ceitarmax),
					new SqlParameter("minDOC_YTDTAR",doc_ytdtarmin),
					new SqlParameter("maxDOC_YTDTAR",doc_ytdtarmax),
					new SqlParameter("CEIREQ_PRT_FORMAT",ceireq_prt_format),
					new SqlParameter("YTDREQ_PRT_FORMAT",ytdreq_prt_format),
					new SqlParameter("CEITAR_PRT_FORMAT",ceitar_prt_format),
					new SqlParameter("YTDTAR_PRT_FORMAT",ytdtar_prt_format),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F020_DOC_MSTR_HISTORY_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F020_DOC_MSTR_HISTORY>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F020_DOC_MSTR_HISTORY_Search]", parameters);
            var collection = new ObservableCollection<F020_DOC_MSTR_HISTORY>();

            while (Reader.Read())
            {
                collection.Add(new F020_DOC_MSTR_HISTORY
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					EP_NBR = ConvertDEC(Reader["EP_NBR"]),
					DOC_BANK_NBR = ConvertDEC(Reader["DOC_BANK_NBR"]),
					DOC_BANK_BRANCH = ConvertDEC(Reader["DOC_BANK_BRANCH"]),
					DOC_BANK_ACCT = Reader["DOC_BANK_ACCT"].ToString(),
					DOC_YTDGUA = ConvertDEC(Reader["DOC_YTDGUA"]),
					DOC_YTDGUB = ConvertDEC(Reader["DOC_YTDGUB"]),
					DOC_YTDGUC = ConvertDEC(Reader["DOC_YTDGUC"]),
					DOC_YTDGUD = ConvertDEC(Reader["DOC_YTDGUD"]),
					DOC_YTDCEA = ConvertDEC(Reader["DOC_YTDCEA"]),
					DOC_YTDCEX = ConvertDEC(Reader["DOC_YTDCEX"]),
					DOC_YTDEAR = ConvertDEC(Reader["DOC_YTDEAR"]),
					DOC_YTDINC = ConvertDEC(Reader["DOC_YTDINC"]),
					DOC_YTDEFT = ConvertDEC(Reader["DOC_YTDEFT"]),
					DOC_TOTINC_G = ConvertDEC(Reader["DOC_TOTINC_G"]),
					DOC_EP_DATE_DEPOSIT = ConvertDEC(Reader["DOC_EP_DATE_DEPOSIT"]),
					DOC_TOTINC = ConvertDEC(Reader["DOC_TOTINC"]),
					DOC_EP_CEIEXP = ConvertDEC(Reader["DOC_EP_CEIEXP"]),
					DOC_ADJCEA = ConvertDEC(Reader["DOC_ADJCEA"]),
					DOC_ADJCEX = ConvertDEC(Reader["DOC_ADJCEX"]),
					DOC_CEICEA = ConvertDEC(Reader["DOC_CEICEA"]),
					DOC_CEICEX = ConvertDEC(Reader["DOC_CEICEX"]),
					CEICEA_PRT_FORMAT = Reader["CEICEA_PRT_FORMAT"].ToString(),
					CEICEX_PRT_FORMAT = Reader["CEICEX_PRT_FORMAT"].ToString(),
					YTDCEA_PRT_FORMAT = Reader["YTDCEA_PRT_FORMAT"].ToString(),
					YTDCEX_PRT_FORMAT = Reader["YTDCEX_PRT_FORMAT"].ToString(),
					DOC_YTDINC_G = ConvertDEC(Reader["DOC_YTDINC_G"]),
					DOC_RMA_EXPENSE_PERCENT_MISC = Reader["DOC_RMA_EXPENSE_PERCENT_MISC"].ToString(),
					DOC_RMA_EXPENSE_PERCENT_REG = Reader["DOC_RMA_EXPENSE_PERCENT_REG"].ToString(),
					DOC_YRLY_CEILING_COMPUTED = ConvertDEC(Reader["DOC_YRLY_CEILING_COMPUTED"]),
					DOC_YRLY_EXPENSE_COMPUTED = ConvertDEC(Reader["DOC_YRLY_EXPENSE_COMPUTED"]),
					DOC_PAYEFT = ConvertDEC(Reader["DOC_PAYEFT"]),
					DOC_YTDDED = ConvertDEC(Reader["DOC_YTDDED"]),
					DOC_DEPT_EXPENSE_PERCENT_MISC = Reader["DOC_DEPT_EXPENSE_PERCENT_MISC"].ToString(),
					DOC_DEPT_EXPENSE_PERCENT_REG = Reader["DOC_DEPT_EXPENSE_PERCENT_REG"].ToString(),
					DOC_EP_PED = Reader["DOC_EP_PED"].ToString(),
					DOC_EP_PAY_CODE = Reader["DOC_EP_PAY_CODE"].ToString(),
					DOC_EP_PAY_SUB_CODE = Reader["DOC_EP_PAY_SUB_CODE"].ToString(),
					DOC_YRLY_REQUIRE_REVENUE = ConvertDEC(Reader["DOC_YRLY_REQUIRE_REVENUE"]),
					DOC_YRLY_TARGET_REVENUE = ConvertDEC(Reader["DOC_YRLY_TARGET_REVENUE"]),
					DOC_CEIREQ = ConvertDEC(Reader["DOC_CEIREQ"]),
					DOC_YTDREQ = ConvertDEC(Reader["DOC_YTDREQ"]),
					DOC_CEITAR = ConvertDEC(Reader["DOC_CEITAR"]),
					DOC_YTDTAR = ConvertDEC(Reader["DOC_YTDTAR"]),
					CEIREQ_PRT_FORMAT = Reader["CEIREQ_PRT_FORMAT"].ToString(),
					YTDREQ_PRT_FORMAT = Reader["YTDREQ_PRT_FORMAT"].ToString(),
					CEITAR_PRT_FORMAT = Reader["CEITAR_PRT_FORMAT"].ToString(),
					YTDTAR_PRT_FORMAT = Reader["YTDTAR_PRT_FORMAT"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalEp_nbr = ConvertDEC(Reader["EP_NBR"]),
					_originalDoc_bank_nbr = ConvertDEC(Reader["DOC_BANK_NBR"]),
					_originalDoc_bank_branch = ConvertDEC(Reader["DOC_BANK_BRANCH"]),
					_originalDoc_bank_acct = Reader["DOC_BANK_ACCT"].ToString(),
					_originalDoc_ytdgua = ConvertDEC(Reader["DOC_YTDGUA"]),
					_originalDoc_ytdgub = ConvertDEC(Reader["DOC_YTDGUB"]),
					_originalDoc_ytdguc = ConvertDEC(Reader["DOC_YTDGUC"]),
					_originalDoc_ytdgud = ConvertDEC(Reader["DOC_YTDGUD"]),
					_originalDoc_ytdcea = ConvertDEC(Reader["DOC_YTDCEA"]),
					_originalDoc_ytdcex = ConvertDEC(Reader["DOC_YTDCEX"]),
					_originalDoc_ytdear = ConvertDEC(Reader["DOC_YTDEAR"]),
					_originalDoc_ytdinc = ConvertDEC(Reader["DOC_YTDINC"]),
					_originalDoc_ytdeft = ConvertDEC(Reader["DOC_YTDEFT"]),
					_originalDoc_totinc_g = ConvertDEC(Reader["DOC_TOTINC_G"]),
					_originalDoc_ep_date_deposit = ConvertDEC(Reader["DOC_EP_DATE_DEPOSIT"]),
					_originalDoc_totinc = ConvertDEC(Reader["DOC_TOTINC"]),
					_originalDoc_ep_ceiexp = ConvertDEC(Reader["DOC_EP_CEIEXP"]),
					_originalDoc_adjcea = ConvertDEC(Reader["DOC_ADJCEA"]),
					_originalDoc_adjcex = ConvertDEC(Reader["DOC_ADJCEX"]),
					_originalDoc_ceicea = ConvertDEC(Reader["DOC_CEICEA"]),
					_originalDoc_ceicex = ConvertDEC(Reader["DOC_CEICEX"]),
					_originalCeicea_prt_format = Reader["CEICEA_PRT_FORMAT"].ToString(),
					_originalCeicex_prt_format = Reader["CEICEX_PRT_FORMAT"].ToString(),
					_originalYtdcea_prt_format = Reader["YTDCEA_PRT_FORMAT"].ToString(),
					_originalYtdcex_prt_format = Reader["YTDCEX_PRT_FORMAT"].ToString(),
					_originalDoc_ytdinc_g = ConvertDEC(Reader["DOC_YTDINC_G"]),
					_originalDoc_rma_expense_percent_misc = Reader["DOC_RMA_EXPENSE_PERCENT_MISC"].ToString(),
					_originalDoc_rma_expense_percent_reg = Reader["DOC_RMA_EXPENSE_PERCENT_REG"].ToString(),
					_originalDoc_yrly_ceiling_computed = ConvertDEC(Reader["DOC_YRLY_CEILING_COMPUTED"]),
					_originalDoc_yrly_expense_computed = ConvertDEC(Reader["DOC_YRLY_EXPENSE_COMPUTED"]),
					_originalDoc_payeft = ConvertDEC(Reader["DOC_PAYEFT"]),
					_originalDoc_ytdded = ConvertDEC(Reader["DOC_YTDDED"]),
					_originalDoc_dept_expense_percent_misc = Reader["DOC_DEPT_EXPENSE_PERCENT_MISC"].ToString(),
					_originalDoc_dept_expense_percent_reg = Reader["DOC_DEPT_EXPENSE_PERCENT_REG"].ToString(),
					_originalDoc_ep_ped = Reader["DOC_EP_PED"].ToString(),
					_originalDoc_ep_pay_code = Reader["DOC_EP_PAY_CODE"].ToString(),
					_originalDoc_ep_pay_sub_code = Reader["DOC_EP_PAY_SUB_CODE"].ToString(),
					_originalDoc_yrly_require_revenue = ConvertDEC(Reader["DOC_YRLY_REQUIRE_REVENUE"]),
					_originalDoc_yrly_target_revenue = ConvertDEC(Reader["DOC_YRLY_TARGET_REVENUE"]),
					_originalDoc_ceireq = ConvertDEC(Reader["DOC_CEIREQ"]),
					_originalDoc_ytdreq = ConvertDEC(Reader["DOC_YTDREQ"]),
					_originalDoc_ceitar = ConvertDEC(Reader["DOC_CEITAR"]),
					_originalDoc_ytdtar = ConvertDEC(Reader["DOC_YTDTAR"]),
					_originalCeireq_prt_format = Reader["CEIREQ_PRT_FORMAT"].ToString(),
					_originalYtdreq_prt_format = Reader["YTDREQ_PRT_FORMAT"].ToString(),
					_originalCeitar_prt_format = Reader["CEITAR_PRT_FORMAT"].ToString(),
					_originalYtdtar_prt_format = Reader["YTDTAR_PRT_FORMAT"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F020_DOC_MSTR_HISTORY Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F020_DOC_MSTR_HISTORY> Collection(ObservableCollection<F020_DOC_MSTR_HISTORY>
                                                               f020DocMstrHistory = null)
        {
            if (IsSameSearch() && f020DocMstrHistory != null)
            {
                return f020DocMstrHistory;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F020_DOC_MSTR_HISTORY>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("DOC_NBR",WhereDoc_nbr),
					new SqlParameter("EP_NBR",WhereEp_nbr),
					new SqlParameter("DOC_BANK_NBR",WhereDoc_bank_nbr),
					new SqlParameter("DOC_BANK_BRANCH",WhereDoc_bank_branch),
					new SqlParameter("DOC_BANK_ACCT",WhereDoc_bank_acct),
					new SqlParameter("DOC_YTDGUA",WhereDoc_ytdgua),
					new SqlParameter("DOC_YTDGUB",WhereDoc_ytdgub),
					new SqlParameter("DOC_YTDGUC",WhereDoc_ytdguc),
					new SqlParameter("DOC_YTDGUD",WhereDoc_ytdgud),
					new SqlParameter("DOC_YTDCEA",WhereDoc_ytdcea),
					new SqlParameter("DOC_YTDCEX",WhereDoc_ytdcex),
					new SqlParameter("DOC_YTDEAR",WhereDoc_ytdear),
					new SqlParameter("DOC_YTDINC",WhereDoc_ytdinc),
					new SqlParameter("DOC_YTDEFT",WhereDoc_ytdeft),
					new SqlParameter("DOC_TOTINC_G",WhereDoc_totinc_g),
					new SqlParameter("DOC_EP_DATE_DEPOSIT",WhereDoc_ep_date_deposit),
					new SqlParameter("DOC_TOTINC",WhereDoc_totinc),
					new SqlParameter("DOC_EP_CEIEXP",WhereDoc_ep_ceiexp),
					new SqlParameter("DOC_ADJCEA",WhereDoc_adjcea),
					new SqlParameter("DOC_ADJCEX",WhereDoc_adjcex),
					new SqlParameter("DOC_CEICEA",WhereDoc_ceicea),
					new SqlParameter("DOC_CEICEX",WhereDoc_ceicex),
					new SqlParameter("CEICEA_PRT_FORMAT",WhereCeicea_prt_format),
					new SqlParameter("CEICEX_PRT_FORMAT",WhereCeicex_prt_format),
					new SqlParameter("YTDCEA_PRT_FORMAT",WhereYtdcea_prt_format),
					new SqlParameter("YTDCEX_PRT_FORMAT",WhereYtdcex_prt_format),
					new SqlParameter("DOC_YTDINC_G",WhereDoc_ytdinc_g),
					new SqlParameter("DOC_RMA_EXPENSE_PERCENT_MISC",WhereDoc_rma_expense_percent_misc),
					new SqlParameter("DOC_RMA_EXPENSE_PERCENT_REG",WhereDoc_rma_expense_percent_reg),
					new SqlParameter("DOC_YRLY_CEILING_COMPUTED",WhereDoc_yrly_ceiling_computed),
					new SqlParameter("DOC_YRLY_EXPENSE_COMPUTED",WhereDoc_yrly_expense_computed),
					new SqlParameter("DOC_PAYEFT",WhereDoc_payeft),
					new SqlParameter("DOC_YTDDED",WhereDoc_ytdded),
					new SqlParameter("DOC_DEPT_EXPENSE_PERCENT_MISC",WhereDoc_dept_expense_percent_misc),
					new SqlParameter("DOC_DEPT_EXPENSE_PERCENT_REG",WhereDoc_dept_expense_percent_reg),
					new SqlParameter("DOC_EP_PED",WhereDoc_ep_ped),
					new SqlParameter("DOC_EP_PAY_CODE",WhereDoc_ep_pay_code),
					new SqlParameter("DOC_EP_PAY_SUB_CODE",WhereDoc_ep_pay_sub_code),
					new SqlParameter("DOC_YRLY_REQUIRE_REVENUE",WhereDoc_yrly_require_revenue),
					new SqlParameter("DOC_YRLY_TARGET_REVENUE",WhereDoc_yrly_target_revenue),
					new SqlParameter("DOC_CEIREQ",WhereDoc_ceireq),
					new SqlParameter("DOC_YTDREQ",WhereDoc_ytdreq),
					new SqlParameter("DOC_CEITAR",WhereDoc_ceitar),
					new SqlParameter("DOC_YTDTAR",WhereDoc_ytdtar),
					new SqlParameter("CEIREQ_PRT_FORMAT",WhereCeireq_prt_format),
					new SqlParameter("YTDREQ_PRT_FORMAT",WhereYtdreq_prt_format),
					new SqlParameter("CEITAR_PRT_FORMAT",WhereCeitar_prt_format),
					new SqlParameter("YTDTAR_PRT_FORMAT",WhereYtdtar_prt_format),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F020_DOC_MSTR_HISTORY_Match]", parameters);
            var collection = new ObservableCollection<F020_DOC_MSTR_HISTORY>();

            while (Reader.Read())
            {
                collection.Add(new F020_DOC_MSTR_HISTORY
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					EP_NBR = ConvertDEC(Reader["EP_NBR"]),
					DOC_BANK_NBR = ConvertDEC(Reader["DOC_BANK_NBR"]),
					DOC_BANK_BRANCH = ConvertDEC(Reader["DOC_BANK_BRANCH"]),
					DOC_BANK_ACCT = Reader["DOC_BANK_ACCT"].ToString(),
					DOC_YTDGUA = ConvertDEC(Reader["DOC_YTDGUA"]),
					DOC_YTDGUB = ConvertDEC(Reader["DOC_YTDGUB"]),
					DOC_YTDGUC = ConvertDEC(Reader["DOC_YTDGUC"]),
					DOC_YTDGUD = ConvertDEC(Reader["DOC_YTDGUD"]),
					DOC_YTDCEA = ConvertDEC(Reader["DOC_YTDCEA"]),
					DOC_YTDCEX = ConvertDEC(Reader["DOC_YTDCEX"]),
					DOC_YTDEAR = ConvertDEC(Reader["DOC_YTDEAR"]),
					DOC_YTDINC = ConvertDEC(Reader["DOC_YTDINC"]),
					DOC_YTDEFT = ConvertDEC(Reader["DOC_YTDEFT"]),
					DOC_TOTINC_G = ConvertDEC(Reader["DOC_TOTINC_G"]),
					DOC_EP_DATE_DEPOSIT = ConvertDEC(Reader["DOC_EP_DATE_DEPOSIT"]),
					DOC_TOTINC = ConvertDEC(Reader["DOC_TOTINC"]),
					DOC_EP_CEIEXP = ConvertDEC(Reader["DOC_EP_CEIEXP"]),
					DOC_ADJCEA = ConvertDEC(Reader["DOC_ADJCEA"]),
					DOC_ADJCEX = ConvertDEC(Reader["DOC_ADJCEX"]),
					DOC_CEICEA = ConvertDEC(Reader["DOC_CEICEA"]),
					DOC_CEICEX = ConvertDEC(Reader["DOC_CEICEX"]),
					CEICEA_PRT_FORMAT = Reader["CEICEA_PRT_FORMAT"].ToString(),
					CEICEX_PRT_FORMAT = Reader["CEICEX_PRT_FORMAT"].ToString(),
					YTDCEA_PRT_FORMAT = Reader["YTDCEA_PRT_FORMAT"].ToString(),
					YTDCEX_PRT_FORMAT = Reader["YTDCEX_PRT_FORMAT"].ToString(),
					DOC_YTDINC_G = ConvertDEC(Reader["DOC_YTDINC_G"]),
					DOC_RMA_EXPENSE_PERCENT_MISC = Reader["DOC_RMA_EXPENSE_PERCENT_MISC"].ToString(),
					DOC_RMA_EXPENSE_PERCENT_REG = Reader["DOC_RMA_EXPENSE_PERCENT_REG"].ToString(),
					DOC_YRLY_CEILING_COMPUTED = ConvertDEC(Reader["DOC_YRLY_CEILING_COMPUTED"]),
					DOC_YRLY_EXPENSE_COMPUTED = ConvertDEC(Reader["DOC_YRLY_EXPENSE_COMPUTED"]),
					DOC_PAYEFT = ConvertDEC(Reader["DOC_PAYEFT"]),
					DOC_YTDDED = ConvertDEC(Reader["DOC_YTDDED"]),
					DOC_DEPT_EXPENSE_PERCENT_MISC = Reader["DOC_DEPT_EXPENSE_PERCENT_MISC"].ToString(),
					DOC_DEPT_EXPENSE_PERCENT_REG = Reader["DOC_DEPT_EXPENSE_PERCENT_REG"].ToString(),
					DOC_EP_PED = Reader["DOC_EP_PED"].ToString(),
					DOC_EP_PAY_CODE = Reader["DOC_EP_PAY_CODE"].ToString(),
					DOC_EP_PAY_SUB_CODE = Reader["DOC_EP_PAY_SUB_CODE"].ToString(),
					DOC_YRLY_REQUIRE_REVENUE = ConvertDEC(Reader["DOC_YRLY_REQUIRE_REVENUE"]),
					DOC_YRLY_TARGET_REVENUE = ConvertDEC(Reader["DOC_YRLY_TARGET_REVENUE"]),
					DOC_CEIREQ = ConvertDEC(Reader["DOC_CEIREQ"]),
					DOC_YTDREQ = ConvertDEC(Reader["DOC_YTDREQ"]),
					DOC_CEITAR = ConvertDEC(Reader["DOC_CEITAR"]),
					DOC_YTDTAR = ConvertDEC(Reader["DOC_YTDTAR"]),
					CEIREQ_PRT_FORMAT = Reader["CEIREQ_PRT_FORMAT"].ToString(),
					YTDREQ_PRT_FORMAT = Reader["YTDREQ_PRT_FORMAT"].ToString(),
					CEITAR_PRT_FORMAT = Reader["CEITAR_PRT_FORMAT"].ToString(),
					YTDTAR_PRT_FORMAT = Reader["YTDTAR_PRT_FORMAT"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereDoc_nbr = WhereDoc_nbr,
					_whereEp_nbr = WhereEp_nbr,
					_whereDoc_bank_nbr = WhereDoc_bank_nbr,
					_whereDoc_bank_branch = WhereDoc_bank_branch,
					_whereDoc_bank_acct = WhereDoc_bank_acct,
					_whereDoc_ytdgua = WhereDoc_ytdgua,
					_whereDoc_ytdgub = WhereDoc_ytdgub,
					_whereDoc_ytdguc = WhereDoc_ytdguc,
					_whereDoc_ytdgud = WhereDoc_ytdgud,
					_whereDoc_ytdcea = WhereDoc_ytdcea,
					_whereDoc_ytdcex = WhereDoc_ytdcex,
					_whereDoc_ytdear = WhereDoc_ytdear,
					_whereDoc_ytdinc = WhereDoc_ytdinc,
					_whereDoc_ytdeft = WhereDoc_ytdeft,
					_whereDoc_totinc_g = WhereDoc_totinc_g,
					_whereDoc_ep_date_deposit = WhereDoc_ep_date_deposit,
					_whereDoc_totinc = WhereDoc_totinc,
					_whereDoc_ep_ceiexp = WhereDoc_ep_ceiexp,
					_whereDoc_adjcea = WhereDoc_adjcea,
					_whereDoc_adjcex = WhereDoc_adjcex,
					_whereDoc_ceicea = WhereDoc_ceicea,
					_whereDoc_ceicex = WhereDoc_ceicex,
					_whereCeicea_prt_format = WhereCeicea_prt_format,
					_whereCeicex_prt_format = WhereCeicex_prt_format,
					_whereYtdcea_prt_format = WhereYtdcea_prt_format,
					_whereYtdcex_prt_format = WhereYtdcex_prt_format,
					_whereDoc_ytdinc_g = WhereDoc_ytdinc_g,
					_whereDoc_rma_expense_percent_misc = WhereDoc_rma_expense_percent_misc,
					_whereDoc_rma_expense_percent_reg = WhereDoc_rma_expense_percent_reg,
					_whereDoc_yrly_ceiling_computed = WhereDoc_yrly_ceiling_computed,
					_whereDoc_yrly_expense_computed = WhereDoc_yrly_expense_computed,
					_whereDoc_payeft = WhereDoc_payeft,
					_whereDoc_ytdded = WhereDoc_ytdded,
					_whereDoc_dept_expense_percent_misc = WhereDoc_dept_expense_percent_misc,
					_whereDoc_dept_expense_percent_reg = WhereDoc_dept_expense_percent_reg,
					_whereDoc_ep_ped = WhereDoc_ep_ped,
					_whereDoc_ep_pay_code = WhereDoc_ep_pay_code,
					_whereDoc_ep_pay_sub_code = WhereDoc_ep_pay_sub_code,
					_whereDoc_yrly_require_revenue = WhereDoc_yrly_require_revenue,
					_whereDoc_yrly_target_revenue = WhereDoc_yrly_target_revenue,
					_whereDoc_ceireq = WhereDoc_ceireq,
					_whereDoc_ytdreq = WhereDoc_ytdreq,
					_whereDoc_ceitar = WhereDoc_ceitar,
					_whereDoc_ytdtar = WhereDoc_ytdtar,
					_whereCeireq_prt_format = WhereCeireq_prt_format,
					_whereYtdreq_prt_format = WhereYtdreq_prt_format,
					_whereCeitar_prt_format = WhereCeitar_prt_format,
					_whereYtdtar_prt_format = WhereYtdtar_prt_format,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalEp_nbr = ConvertDEC(Reader["EP_NBR"]),
					_originalDoc_bank_nbr = ConvertDEC(Reader["DOC_BANK_NBR"]),
					_originalDoc_bank_branch = ConvertDEC(Reader["DOC_BANK_BRANCH"]),
					_originalDoc_bank_acct = Reader["DOC_BANK_ACCT"].ToString(),
					_originalDoc_ytdgua = ConvertDEC(Reader["DOC_YTDGUA"]),
					_originalDoc_ytdgub = ConvertDEC(Reader["DOC_YTDGUB"]),
					_originalDoc_ytdguc = ConvertDEC(Reader["DOC_YTDGUC"]),
					_originalDoc_ytdgud = ConvertDEC(Reader["DOC_YTDGUD"]),
					_originalDoc_ytdcea = ConvertDEC(Reader["DOC_YTDCEA"]),
					_originalDoc_ytdcex = ConvertDEC(Reader["DOC_YTDCEX"]),
					_originalDoc_ytdear = ConvertDEC(Reader["DOC_YTDEAR"]),
					_originalDoc_ytdinc = ConvertDEC(Reader["DOC_YTDINC"]),
					_originalDoc_ytdeft = ConvertDEC(Reader["DOC_YTDEFT"]),
					_originalDoc_totinc_g = ConvertDEC(Reader["DOC_TOTINC_G"]),
					_originalDoc_ep_date_deposit = ConvertDEC(Reader["DOC_EP_DATE_DEPOSIT"]),
					_originalDoc_totinc = ConvertDEC(Reader["DOC_TOTINC"]),
					_originalDoc_ep_ceiexp = ConvertDEC(Reader["DOC_EP_CEIEXP"]),
					_originalDoc_adjcea = ConvertDEC(Reader["DOC_ADJCEA"]),
					_originalDoc_adjcex = ConvertDEC(Reader["DOC_ADJCEX"]),
					_originalDoc_ceicea = ConvertDEC(Reader["DOC_CEICEA"]),
					_originalDoc_ceicex = ConvertDEC(Reader["DOC_CEICEX"]),
					_originalCeicea_prt_format = Reader["CEICEA_PRT_FORMAT"].ToString(),
					_originalCeicex_prt_format = Reader["CEICEX_PRT_FORMAT"].ToString(),
					_originalYtdcea_prt_format = Reader["YTDCEA_PRT_FORMAT"].ToString(),
					_originalYtdcex_prt_format = Reader["YTDCEX_PRT_FORMAT"].ToString(),
					_originalDoc_ytdinc_g = ConvertDEC(Reader["DOC_YTDINC_G"]),
					_originalDoc_rma_expense_percent_misc = Reader["DOC_RMA_EXPENSE_PERCENT_MISC"].ToString(),
					_originalDoc_rma_expense_percent_reg = Reader["DOC_RMA_EXPENSE_PERCENT_REG"].ToString(),
					_originalDoc_yrly_ceiling_computed = ConvertDEC(Reader["DOC_YRLY_CEILING_COMPUTED"]),
					_originalDoc_yrly_expense_computed = ConvertDEC(Reader["DOC_YRLY_EXPENSE_COMPUTED"]),
					_originalDoc_payeft = ConvertDEC(Reader["DOC_PAYEFT"]),
					_originalDoc_ytdded = ConvertDEC(Reader["DOC_YTDDED"]),
					_originalDoc_dept_expense_percent_misc = Reader["DOC_DEPT_EXPENSE_PERCENT_MISC"].ToString(),
					_originalDoc_dept_expense_percent_reg = Reader["DOC_DEPT_EXPENSE_PERCENT_REG"].ToString(),
					_originalDoc_ep_ped = Reader["DOC_EP_PED"].ToString(),
					_originalDoc_ep_pay_code = Reader["DOC_EP_PAY_CODE"].ToString(),
					_originalDoc_ep_pay_sub_code = Reader["DOC_EP_PAY_SUB_CODE"].ToString(),
					_originalDoc_yrly_require_revenue = ConvertDEC(Reader["DOC_YRLY_REQUIRE_REVENUE"]),
					_originalDoc_yrly_target_revenue = ConvertDEC(Reader["DOC_YRLY_TARGET_REVENUE"]),
					_originalDoc_ceireq = ConvertDEC(Reader["DOC_CEIREQ"]),
					_originalDoc_ytdreq = ConvertDEC(Reader["DOC_YTDREQ"]),
					_originalDoc_ceitar = ConvertDEC(Reader["DOC_CEITAR"]),
					_originalDoc_ytdtar = ConvertDEC(Reader["DOC_YTDTAR"]),
					_originalCeireq_prt_format = Reader["CEIREQ_PRT_FORMAT"].ToString(),
					_originalYtdreq_prt_format = Reader["YTDREQ_PRT_FORMAT"].ToString(),
					_originalCeitar_prt_format = Reader["CEITAR_PRT_FORMAT"].ToString(),
					_originalYtdtar_prt_format = Reader["YTDTAR_PRT_FORMAT"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereDoc_nbr = WhereDoc_nbr;
					_whereEp_nbr = WhereEp_nbr;
					_whereDoc_bank_nbr = WhereDoc_bank_nbr;
					_whereDoc_bank_branch = WhereDoc_bank_branch;
					_whereDoc_bank_acct = WhereDoc_bank_acct;
					_whereDoc_ytdgua = WhereDoc_ytdgua;
					_whereDoc_ytdgub = WhereDoc_ytdgub;
					_whereDoc_ytdguc = WhereDoc_ytdguc;
					_whereDoc_ytdgud = WhereDoc_ytdgud;
					_whereDoc_ytdcea = WhereDoc_ytdcea;
					_whereDoc_ytdcex = WhereDoc_ytdcex;
					_whereDoc_ytdear = WhereDoc_ytdear;
					_whereDoc_ytdinc = WhereDoc_ytdinc;
					_whereDoc_ytdeft = WhereDoc_ytdeft;
					_whereDoc_totinc_g = WhereDoc_totinc_g;
					_whereDoc_ep_date_deposit = WhereDoc_ep_date_deposit;
					_whereDoc_totinc = WhereDoc_totinc;
					_whereDoc_ep_ceiexp = WhereDoc_ep_ceiexp;
					_whereDoc_adjcea = WhereDoc_adjcea;
					_whereDoc_adjcex = WhereDoc_adjcex;
					_whereDoc_ceicea = WhereDoc_ceicea;
					_whereDoc_ceicex = WhereDoc_ceicex;
					_whereCeicea_prt_format = WhereCeicea_prt_format;
					_whereCeicex_prt_format = WhereCeicex_prt_format;
					_whereYtdcea_prt_format = WhereYtdcea_prt_format;
					_whereYtdcex_prt_format = WhereYtdcex_prt_format;
					_whereDoc_ytdinc_g = WhereDoc_ytdinc_g;
					_whereDoc_rma_expense_percent_misc = WhereDoc_rma_expense_percent_misc;
					_whereDoc_rma_expense_percent_reg = WhereDoc_rma_expense_percent_reg;
					_whereDoc_yrly_ceiling_computed = WhereDoc_yrly_ceiling_computed;
					_whereDoc_yrly_expense_computed = WhereDoc_yrly_expense_computed;
					_whereDoc_payeft = WhereDoc_payeft;
					_whereDoc_ytdded = WhereDoc_ytdded;
					_whereDoc_dept_expense_percent_misc = WhereDoc_dept_expense_percent_misc;
					_whereDoc_dept_expense_percent_reg = WhereDoc_dept_expense_percent_reg;
					_whereDoc_ep_ped = WhereDoc_ep_ped;
					_whereDoc_ep_pay_code = WhereDoc_ep_pay_code;
					_whereDoc_ep_pay_sub_code = WhereDoc_ep_pay_sub_code;
					_whereDoc_yrly_require_revenue = WhereDoc_yrly_require_revenue;
					_whereDoc_yrly_target_revenue = WhereDoc_yrly_target_revenue;
					_whereDoc_ceireq = WhereDoc_ceireq;
					_whereDoc_ytdreq = WhereDoc_ytdreq;
					_whereDoc_ceitar = WhereDoc_ceitar;
					_whereDoc_ytdtar = WhereDoc_ytdtar;
					_whereCeireq_prt_format = WhereCeireq_prt_format;
					_whereYtdreq_prt_format = WhereYtdreq_prt_format;
					_whereCeitar_prt_format = WhereCeitar_prt_format;
					_whereYtdtar_prt_format = WhereYtdtar_prt_format;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereDoc_nbr == null 
				&& WhereEp_nbr == null 
				&& WhereDoc_bank_nbr == null 
				&& WhereDoc_bank_branch == null 
				&& WhereDoc_bank_acct == null 
				&& WhereDoc_ytdgua == null 
				&& WhereDoc_ytdgub == null 
				&& WhereDoc_ytdguc == null 
				&& WhereDoc_ytdgud == null 
				&& WhereDoc_ytdcea == null 
				&& WhereDoc_ytdcex == null 
				&& WhereDoc_ytdear == null 
				&& WhereDoc_ytdinc == null 
				&& WhereDoc_ytdeft == null 
				&& WhereDoc_totinc_g == null 
				&& WhereDoc_ep_date_deposit == null 
				&& WhereDoc_totinc == null 
				&& WhereDoc_ep_ceiexp == null 
				&& WhereDoc_adjcea == null 
				&& WhereDoc_adjcex == null 
				&& WhereDoc_ceicea == null 
				&& WhereDoc_ceicex == null 
				&& WhereCeicea_prt_format == null 
				&& WhereCeicex_prt_format == null 
				&& WhereYtdcea_prt_format == null 
				&& WhereYtdcex_prt_format == null 
				&& WhereDoc_ytdinc_g == null 
				&& WhereDoc_rma_expense_percent_misc == null 
				&& WhereDoc_rma_expense_percent_reg == null 
				&& WhereDoc_yrly_ceiling_computed == null 
				&& WhereDoc_yrly_expense_computed == null 
				&& WhereDoc_payeft == null 
				&& WhereDoc_ytdded == null 
				&& WhereDoc_dept_expense_percent_misc == null 
				&& WhereDoc_dept_expense_percent_reg == null 
				&& WhereDoc_ep_ped == null 
				&& WhereDoc_ep_pay_code == null 
				&& WhereDoc_ep_pay_sub_code == null 
				&& WhereDoc_yrly_require_revenue == null 
				&& WhereDoc_yrly_target_revenue == null 
				&& WhereDoc_ceireq == null 
				&& WhereDoc_ytdreq == null 
				&& WhereDoc_ceitar == null 
				&& WhereDoc_ytdtar == null 
				&& WhereCeireq_prt_format == null 
				&& WhereYtdreq_prt_format == null 
				&& WhereCeitar_prt_format == null 
				&& WhereYtdtar_prt_format == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereDoc_nbr ==  _whereDoc_nbr
				&& WhereEp_nbr ==  _whereEp_nbr
				&& WhereDoc_bank_nbr ==  _whereDoc_bank_nbr
				&& WhereDoc_bank_branch ==  _whereDoc_bank_branch
				&& WhereDoc_bank_acct ==  _whereDoc_bank_acct
				&& WhereDoc_ytdgua ==  _whereDoc_ytdgua
				&& WhereDoc_ytdgub ==  _whereDoc_ytdgub
				&& WhereDoc_ytdguc ==  _whereDoc_ytdguc
				&& WhereDoc_ytdgud ==  _whereDoc_ytdgud
				&& WhereDoc_ytdcea ==  _whereDoc_ytdcea
				&& WhereDoc_ytdcex ==  _whereDoc_ytdcex
				&& WhereDoc_ytdear ==  _whereDoc_ytdear
				&& WhereDoc_ytdinc ==  _whereDoc_ytdinc
				&& WhereDoc_ytdeft ==  _whereDoc_ytdeft
				&& WhereDoc_totinc_g ==  _whereDoc_totinc_g
				&& WhereDoc_ep_date_deposit ==  _whereDoc_ep_date_deposit
				&& WhereDoc_totinc ==  _whereDoc_totinc
				&& WhereDoc_ep_ceiexp ==  _whereDoc_ep_ceiexp
				&& WhereDoc_adjcea ==  _whereDoc_adjcea
				&& WhereDoc_adjcex ==  _whereDoc_adjcex
				&& WhereDoc_ceicea ==  _whereDoc_ceicea
				&& WhereDoc_ceicex ==  _whereDoc_ceicex
				&& WhereCeicea_prt_format ==  _whereCeicea_prt_format
				&& WhereCeicex_prt_format ==  _whereCeicex_prt_format
				&& WhereYtdcea_prt_format ==  _whereYtdcea_prt_format
				&& WhereYtdcex_prt_format ==  _whereYtdcex_prt_format
				&& WhereDoc_ytdinc_g ==  _whereDoc_ytdinc_g
				&& WhereDoc_rma_expense_percent_misc ==  _whereDoc_rma_expense_percent_misc
				&& WhereDoc_rma_expense_percent_reg ==  _whereDoc_rma_expense_percent_reg
				&& WhereDoc_yrly_ceiling_computed ==  _whereDoc_yrly_ceiling_computed
				&& WhereDoc_yrly_expense_computed ==  _whereDoc_yrly_expense_computed
				&& WhereDoc_payeft ==  _whereDoc_payeft
				&& WhereDoc_ytdded ==  _whereDoc_ytdded
				&& WhereDoc_dept_expense_percent_misc ==  _whereDoc_dept_expense_percent_misc
				&& WhereDoc_dept_expense_percent_reg ==  _whereDoc_dept_expense_percent_reg
				&& WhereDoc_ep_ped ==  _whereDoc_ep_ped
				&& WhereDoc_ep_pay_code ==  _whereDoc_ep_pay_code
				&& WhereDoc_ep_pay_sub_code ==  _whereDoc_ep_pay_sub_code
				&& WhereDoc_yrly_require_revenue ==  _whereDoc_yrly_require_revenue
				&& WhereDoc_yrly_target_revenue ==  _whereDoc_yrly_target_revenue
				&& WhereDoc_ceireq ==  _whereDoc_ceireq
				&& WhereDoc_ytdreq ==  _whereDoc_ytdreq
				&& WhereDoc_ceitar ==  _whereDoc_ceitar
				&& WhereDoc_ytdtar ==  _whereDoc_ytdtar
				&& WhereCeireq_prt_format ==  _whereCeireq_prt_format
				&& WhereYtdreq_prt_format ==  _whereYtdreq_prt_format
				&& WhereCeitar_prt_format ==  _whereCeitar_prt_format
				&& WhereYtdtar_prt_format ==  _whereYtdtar_prt_format
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereDoc_nbr = null; 
			WhereEp_nbr = null; 
			WhereDoc_bank_nbr = null; 
			WhereDoc_bank_branch = null; 
			WhereDoc_bank_acct = null; 
			WhereDoc_ytdgua = null; 
			WhereDoc_ytdgub = null; 
			WhereDoc_ytdguc = null; 
			WhereDoc_ytdgud = null; 
			WhereDoc_ytdcea = null; 
			WhereDoc_ytdcex = null; 
			WhereDoc_ytdear = null; 
			WhereDoc_ytdinc = null; 
			WhereDoc_ytdeft = null; 
			WhereDoc_totinc_g = null; 
			WhereDoc_ep_date_deposit = null; 
			WhereDoc_totinc = null; 
			WhereDoc_ep_ceiexp = null; 
			WhereDoc_adjcea = null; 
			WhereDoc_adjcex = null; 
			WhereDoc_ceicea = null; 
			WhereDoc_ceicex = null; 
			WhereCeicea_prt_format = null; 
			WhereCeicex_prt_format = null; 
			WhereYtdcea_prt_format = null; 
			WhereYtdcex_prt_format = null; 
			WhereDoc_ytdinc_g = null; 
			WhereDoc_rma_expense_percent_misc = null; 
			WhereDoc_rma_expense_percent_reg = null; 
			WhereDoc_yrly_ceiling_computed = null; 
			WhereDoc_yrly_expense_computed = null; 
			WhereDoc_payeft = null; 
			WhereDoc_ytdded = null; 
			WhereDoc_dept_expense_percent_misc = null; 
			WhereDoc_dept_expense_percent_reg = null; 
			WhereDoc_ep_ped = null; 
			WhereDoc_ep_pay_code = null; 
			WhereDoc_ep_pay_sub_code = null; 
			WhereDoc_yrly_require_revenue = null; 
			WhereDoc_yrly_target_revenue = null; 
			WhereDoc_ceireq = null; 
			WhereDoc_ytdreq = null; 
			WhereDoc_ceitar = null; 
			WhereDoc_ytdtar = null; 
			WhereCeireq_prt_format = null; 
			WhereYtdreq_prt_format = null; 
			WhereCeitar_prt_format = null; 
			WhereYtdtar_prt_format = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _DOC_NBR;
		private decimal? _EP_NBR;
		private decimal? _DOC_BANK_NBR;
		private decimal? _DOC_BANK_BRANCH;
		private string _DOC_BANK_ACCT;
		private decimal? _DOC_YTDGUA;
		private decimal? _DOC_YTDGUB;
		private decimal? _DOC_YTDGUC;
		private decimal? _DOC_YTDGUD;
		private decimal? _DOC_YTDCEA;
		private decimal? _DOC_YTDCEX;
		private decimal? _DOC_YTDEAR;
		private decimal? _DOC_YTDINC;
		private decimal? _DOC_YTDEFT;
		private decimal? _DOC_TOTINC_G;
		private decimal? _DOC_EP_DATE_DEPOSIT;
		private decimal? _DOC_TOTINC;
		private decimal? _DOC_EP_CEIEXP;
		private decimal? _DOC_ADJCEA;
		private decimal? _DOC_ADJCEX;
		private decimal? _DOC_CEICEA;
		private decimal? _DOC_CEICEX;
		private string _CEICEA_PRT_FORMAT;
		private string _CEICEX_PRT_FORMAT;
		private string _YTDCEA_PRT_FORMAT;
		private string _YTDCEX_PRT_FORMAT;
		private decimal? _DOC_YTDINC_G;
		private string _DOC_RMA_EXPENSE_PERCENT_MISC;
		private string _DOC_RMA_EXPENSE_PERCENT_REG;
		private decimal? _DOC_YRLY_CEILING_COMPUTED;
		private decimal? _DOC_YRLY_EXPENSE_COMPUTED;
		private decimal? _DOC_PAYEFT;
		private decimal? _DOC_YTDDED;
		private string _DOC_DEPT_EXPENSE_PERCENT_MISC;
		private string _DOC_DEPT_EXPENSE_PERCENT_REG;
		private string _DOC_EP_PED;
		private string _DOC_EP_PAY_CODE;
		private string _DOC_EP_PAY_SUB_CODE;
		private decimal? _DOC_YRLY_REQUIRE_REVENUE;
		private decimal? _DOC_YRLY_TARGET_REVENUE;
		private decimal? _DOC_CEIREQ;
		private decimal? _DOC_YTDREQ;
		private decimal? _DOC_CEITAR;
		private decimal? _DOC_YTDTAR;
		private string _CEIREQ_PRT_FORMAT;
		private string _YTDREQ_PRT_FORMAT;
		private string _CEITAR_PRT_FORMAT;
		private string _YTDTAR_PRT_FORMAT;
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
		public decimal? EP_NBR
		{
			get { return _EP_NBR; }
			set
			{
				if (_EP_NBR != value)
				{
					_EP_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_BANK_NBR
		{
			get { return _DOC_BANK_NBR; }
			set
			{
				if (_DOC_BANK_NBR != value)
				{
					_DOC_BANK_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_BANK_BRANCH
		{
			get { return _DOC_BANK_BRANCH; }
			set
			{
				if (_DOC_BANK_BRANCH != value)
				{
					_DOC_BANK_BRANCH = value;
					ChangeState();
				}
			}
		}
		public string DOC_BANK_ACCT
		{
			get { return _DOC_BANK_ACCT; }
			set
			{
				if (_DOC_BANK_ACCT != value)
				{
					_DOC_BANK_ACCT = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_YTDGUA
		{
			get { return _DOC_YTDGUA; }
			set
			{
				if (_DOC_YTDGUA != value)
				{
					_DOC_YTDGUA = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_YTDGUB
		{
			get { return _DOC_YTDGUB; }
			set
			{
				if (_DOC_YTDGUB != value)
				{
					_DOC_YTDGUB = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_YTDGUC
		{
			get { return _DOC_YTDGUC; }
			set
			{
				if (_DOC_YTDGUC != value)
				{
					_DOC_YTDGUC = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_YTDGUD
		{
			get { return _DOC_YTDGUD; }
			set
			{
				if (_DOC_YTDGUD != value)
				{
					_DOC_YTDGUD = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_YTDCEA
		{
			get { return _DOC_YTDCEA; }
			set
			{
				if (_DOC_YTDCEA != value)
				{
					_DOC_YTDCEA = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_YTDCEX
		{
			get { return _DOC_YTDCEX; }
			set
			{
				if (_DOC_YTDCEX != value)
				{
					_DOC_YTDCEX = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_YTDEAR
		{
			get { return _DOC_YTDEAR; }
			set
			{
				if (_DOC_YTDEAR != value)
				{
					_DOC_YTDEAR = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_YTDINC
		{
			get { return _DOC_YTDINC; }
			set
			{
				if (_DOC_YTDINC != value)
				{
					_DOC_YTDINC = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_YTDEFT
		{
			get { return _DOC_YTDEFT; }
			set
			{
				if (_DOC_YTDEFT != value)
				{
					_DOC_YTDEFT = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_TOTINC_G
		{
			get { return _DOC_TOTINC_G; }
			set
			{
				if (_DOC_TOTINC_G != value)
				{
					_DOC_TOTINC_G = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_EP_DATE_DEPOSIT
		{
			get { return _DOC_EP_DATE_DEPOSIT; }
			set
			{
				if (_DOC_EP_DATE_DEPOSIT != value)
				{
					_DOC_EP_DATE_DEPOSIT = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_TOTINC
		{
			get { return _DOC_TOTINC; }
			set
			{
				if (_DOC_TOTINC != value)
				{
					_DOC_TOTINC = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_EP_CEIEXP
		{
			get { return _DOC_EP_CEIEXP; }
			set
			{
				if (_DOC_EP_CEIEXP != value)
				{
					_DOC_EP_CEIEXP = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_ADJCEA
		{
			get { return _DOC_ADJCEA; }
			set
			{
				if (_DOC_ADJCEA != value)
				{
					_DOC_ADJCEA = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_ADJCEX
		{
			get { return _DOC_ADJCEX; }
			set
			{
				if (_DOC_ADJCEX != value)
				{
					_DOC_ADJCEX = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_CEICEA
		{
			get { return _DOC_CEICEA; }
			set
			{
				if (_DOC_CEICEA != value)
				{
					_DOC_CEICEA = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_CEICEX
		{
			get { return _DOC_CEICEX; }
			set
			{
				if (_DOC_CEICEX != value)
				{
					_DOC_CEICEX = value;
					ChangeState();
				}
			}
		}
		public string CEICEA_PRT_FORMAT
		{
			get { return _CEICEA_PRT_FORMAT; }
			set
			{
				if (_CEICEA_PRT_FORMAT != value)
				{
					_CEICEA_PRT_FORMAT = value;
					ChangeState();
				}
			}
		}
		public string CEICEX_PRT_FORMAT
		{
			get { return _CEICEX_PRT_FORMAT; }
			set
			{
				if (_CEICEX_PRT_FORMAT != value)
				{
					_CEICEX_PRT_FORMAT = value;
					ChangeState();
				}
			}
		}
		public string YTDCEA_PRT_FORMAT
		{
			get { return _YTDCEA_PRT_FORMAT; }
			set
			{
				if (_YTDCEA_PRT_FORMAT != value)
				{
					_YTDCEA_PRT_FORMAT = value;
					ChangeState();
				}
			}
		}
		public string YTDCEX_PRT_FORMAT
		{
			get { return _YTDCEX_PRT_FORMAT; }
			set
			{
				if (_YTDCEX_PRT_FORMAT != value)
				{
					_YTDCEX_PRT_FORMAT = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_YTDINC_G
		{
			get { return _DOC_YTDINC_G; }
			set
			{
				if (_DOC_YTDINC_G != value)
				{
					_DOC_YTDINC_G = value;
					ChangeState();
				}
			}
		}
		public string DOC_RMA_EXPENSE_PERCENT_MISC
		{
			get { return _DOC_RMA_EXPENSE_PERCENT_MISC; }
			set
			{
				if (_DOC_RMA_EXPENSE_PERCENT_MISC != value)
				{
					_DOC_RMA_EXPENSE_PERCENT_MISC = value;
					ChangeState();
				}
			}
		}
		public string DOC_RMA_EXPENSE_PERCENT_REG
		{
			get { return _DOC_RMA_EXPENSE_PERCENT_REG; }
			set
			{
				if (_DOC_RMA_EXPENSE_PERCENT_REG != value)
				{
					_DOC_RMA_EXPENSE_PERCENT_REG = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_YRLY_CEILING_COMPUTED
		{
			get { return _DOC_YRLY_CEILING_COMPUTED; }
			set
			{
				if (_DOC_YRLY_CEILING_COMPUTED != value)
				{
					_DOC_YRLY_CEILING_COMPUTED = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_YRLY_EXPENSE_COMPUTED
		{
			get { return _DOC_YRLY_EXPENSE_COMPUTED; }
			set
			{
				if (_DOC_YRLY_EXPENSE_COMPUTED != value)
				{
					_DOC_YRLY_EXPENSE_COMPUTED = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_PAYEFT
		{
			get { return _DOC_PAYEFT; }
			set
			{
				if (_DOC_PAYEFT != value)
				{
					_DOC_PAYEFT = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_YTDDED
		{
			get { return _DOC_YTDDED; }
			set
			{
				if (_DOC_YTDDED != value)
				{
					_DOC_YTDDED = value;
					ChangeState();
				}
			}
		}
		public string DOC_DEPT_EXPENSE_PERCENT_MISC
		{
			get { return _DOC_DEPT_EXPENSE_PERCENT_MISC; }
			set
			{
				if (_DOC_DEPT_EXPENSE_PERCENT_MISC != value)
				{
					_DOC_DEPT_EXPENSE_PERCENT_MISC = value;
					ChangeState();
				}
			}
		}
		public string DOC_DEPT_EXPENSE_PERCENT_REG
		{
			get { return _DOC_DEPT_EXPENSE_PERCENT_REG; }
			set
			{
				if (_DOC_DEPT_EXPENSE_PERCENT_REG != value)
				{
					_DOC_DEPT_EXPENSE_PERCENT_REG = value;
					ChangeState();
				}
			}
		}
		public string DOC_EP_PED
		{
			get { return _DOC_EP_PED; }
			set
			{
				if (_DOC_EP_PED != value)
				{
					_DOC_EP_PED = value;
					ChangeState();
				}
			}
		}
		public string DOC_EP_PAY_CODE
		{
			get { return _DOC_EP_PAY_CODE; }
			set
			{
				if (_DOC_EP_PAY_CODE != value)
				{
					_DOC_EP_PAY_CODE = value;
					ChangeState();
				}
			}
		}
		public string DOC_EP_PAY_SUB_CODE
		{
			get { return _DOC_EP_PAY_SUB_CODE; }
			set
			{
				if (_DOC_EP_PAY_SUB_CODE != value)
				{
					_DOC_EP_PAY_SUB_CODE = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_YRLY_REQUIRE_REVENUE
		{
			get { return _DOC_YRLY_REQUIRE_REVENUE; }
			set
			{
				if (_DOC_YRLY_REQUIRE_REVENUE != value)
				{
					_DOC_YRLY_REQUIRE_REVENUE = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_YRLY_TARGET_REVENUE
		{
			get { return _DOC_YRLY_TARGET_REVENUE; }
			set
			{
				if (_DOC_YRLY_TARGET_REVENUE != value)
				{
					_DOC_YRLY_TARGET_REVENUE = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_CEIREQ
		{
			get { return _DOC_CEIREQ; }
			set
			{
				if (_DOC_CEIREQ != value)
				{
					_DOC_CEIREQ = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_YTDREQ
		{
			get { return _DOC_YTDREQ; }
			set
			{
				if (_DOC_YTDREQ != value)
				{
					_DOC_YTDREQ = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_CEITAR
		{
			get { return _DOC_CEITAR; }
			set
			{
				if (_DOC_CEITAR != value)
				{
					_DOC_CEITAR = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_YTDTAR
		{
			get { return _DOC_YTDTAR; }
			set
			{
				if (_DOC_YTDTAR != value)
				{
					_DOC_YTDTAR = value;
					ChangeState();
				}
			}
		}
		public string CEIREQ_PRT_FORMAT
		{
			get { return _CEIREQ_PRT_FORMAT; }
			set
			{
				if (_CEIREQ_PRT_FORMAT != value)
				{
					_CEIREQ_PRT_FORMAT = value;
					ChangeState();
				}
			}
		}
		public string YTDREQ_PRT_FORMAT
		{
			get { return _YTDREQ_PRT_FORMAT; }
			set
			{
				if (_YTDREQ_PRT_FORMAT != value)
				{
					_YTDREQ_PRT_FORMAT = value;
					ChangeState();
				}
			}
		}
		public string CEITAR_PRT_FORMAT
		{
			get { return _CEITAR_PRT_FORMAT; }
			set
			{
				if (_CEITAR_PRT_FORMAT != value)
				{
					_CEITAR_PRT_FORMAT = value;
					ChangeState();
				}
			}
		}
		public string YTDTAR_PRT_FORMAT
		{
			get { return _YTDTAR_PRT_FORMAT; }
			set
			{
				if (_YTDTAR_PRT_FORMAT != value)
				{
					_YTDTAR_PRT_FORMAT = value;
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
		public decimal? WhereEp_nbr { get; set; }
		private decimal? _whereEp_nbr;
		public decimal? WhereDoc_bank_nbr { get; set; }
		private decimal? _whereDoc_bank_nbr;
		public decimal? WhereDoc_bank_branch { get; set; }
		private decimal? _whereDoc_bank_branch;
		public string WhereDoc_bank_acct { get; set; }
		private string _whereDoc_bank_acct;
		public decimal? WhereDoc_ytdgua { get; set; }
		private decimal? _whereDoc_ytdgua;
		public decimal? WhereDoc_ytdgub { get; set; }
		private decimal? _whereDoc_ytdgub;
		public decimal? WhereDoc_ytdguc { get; set; }
		private decimal? _whereDoc_ytdguc;
		public decimal? WhereDoc_ytdgud { get; set; }
		private decimal? _whereDoc_ytdgud;
		public decimal? WhereDoc_ytdcea { get; set; }
		private decimal? _whereDoc_ytdcea;
		public decimal? WhereDoc_ytdcex { get; set; }
		private decimal? _whereDoc_ytdcex;
		public decimal? WhereDoc_ytdear { get; set; }
		private decimal? _whereDoc_ytdear;
		public decimal? WhereDoc_ytdinc { get; set; }
		private decimal? _whereDoc_ytdinc;
		public decimal? WhereDoc_ytdeft { get; set; }
		private decimal? _whereDoc_ytdeft;
		public decimal? WhereDoc_totinc_g { get; set; }
		private decimal? _whereDoc_totinc_g;
		public decimal? WhereDoc_ep_date_deposit { get; set; }
		private decimal? _whereDoc_ep_date_deposit;
		public decimal? WhereDoc_totinc { get; set; }
		private decimal? _whereDoc_totinc;
		public decimal? WhereDoc_ep_ceiexp { get; set; }
		private decimal? _whereDoc_ep_ceiexp;
		public decimal? WhereDoc_adjcea { get; set; }
		private decimal? _whereDoc_adjcea;
		public decimal? WhereDoc_adjcex { get; set; }
		private decimal? _whereDoc_adjcex;
		public decimal? WhereDoc_ceicea { get; set; }
		private decimal? _whereDoc_ceicea;
		public decimal? WhereDoc_ceicex { get; set; }
		private decimal? _whereDoc_ceicex;
		public string WhereCeicea_prt_format { get; set; }
		private string _whereCeicea_prt_format;
		public string WhereCeicex_prt_format { get; set; }
		private string _whereCeicex_prt_format;
		public string WhereYtdcea_prt_format { get; set; }
		private string _whereYtdcea_prt_format;
		public string WhereYtdcex_prt_format { get; set; }
		private string _whereYtdcex_prt_format;
		public decimal? WhereDoc_ytdinc_g { get; set; }
		private decimal? _whereDoc_ytdinc_g;
		public string WhereDoc_rma_expense_percent_misc { get; set; }
		private string _whereDoc_rma_expense_percent_misc;
		public string WhereDoc_rma_expense_percent_reg { get; set; }
		private string _whereDoc_rma_expense_percent_reg;
		public decimal? WhereDoc_yrly_ceiling_computed { get; set; }
		private decimal? _whereDoc_yrly_ceiling_computed;
		public decimal? WhereDoc_yrly_expense_computed { get; set; }
		private decimal? _whereDoc_yrly_expense_computed;
		public decimal? WhereDoc_payeft { get; set; }
		private decimal? _whereDoc_payeft;
		public decimal? WhereDoc_ytdded { get; set; }
		private decimal? _whereDoc_ytdded;
		public string WhereDoc_dept_expense_percent_misc { get; set; }
		private string _whereDoc_dept_expense_percent_misc;
		public string WhereDoc_dept_expense_percent_reg { get; set; }
		private string _whereDoc_dept_expense_percent_reg;
		public string WhereDoc_ep_ped { get; set; }
		private string _whereDoc_ep_ped;
		public string WhereDoc_ep_pay_code { get; set; }
		private string _whereDoc_ep_pay_code;
		public string WhereDoc_ep_pay_sub_code { get; set; }
		private string _whereDoc_ep_pay_sub_code;
		public decimal? WhereDoc_yrly_require_revenue { get; set; }
		private decimal? _whereDoc_yrly_require_revenue;
		public decimal? WhereDoc_yrly_target_revenue { get; set; }
		private decimal? _whereDoc_yrly_target_revenue;
		public decimal? WhereDoc_ceireq { get; set; }
		private decimal? _whereDoc_ceireq;
		public decimal? WhereDoc_ytdreq { get; set; }
		private decimal? _whereDoc_ytdreq;
		public decimal? WhereDoc_ceitar { get; set; }
		private decimal? _whereDoc_ceitar;
		public decimal? WhereDoc_ytdtar { get; set; }
		private decimal? _whereDoc_ytdtar;
		public string WhereCeireq_prt_format { get; set; }
		private string _whereCeireq_prt_format;
		public string WhereYtdreq_prt_format { get; set; }
		private string _whereYtdreq_prt_format;
		public string WhereCeitar_prt_format { get; set; }
		private string _whereCeitar_prt_format;
		public string WhereYtdtar_prt_format { get; set; }
		private string _whereYtdtar_prt_format;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalDoc_nbr;
		private decimal? _originalEp_nbr;
		private decimal? _originalDoc_bank_nbr;
		private decimal? _originalDoc_bank_branch;
		private string _originalDoc_bank_acct;
		private decimal? _originalDoc_ytdgua;
		private decimal? _originalDoc_ytdgub;
		private decimal? _originalDoc_ytdguc;
		private decimal? _originalDoc_ytdgud;
		private decimal? _originalDoc_ytdcea;
		private decimal? _originalDoc_ytdcex;
		private decimal? _originalDoc_ytdear;
		private decimal? _originalDoc_ytdinc;
		private decimal? _originalDoc_ytdeft;
		private decimal? _originalDoc_totinc_g;
		private decimal? _originalDoc_ep_date_deposit;
		private decimal? _originalDoc_totinc;
		private decimal? _originalDoc_ep_ceiexp;
		private decimal? _originalDoc_adjcea;
		private decimal? _originalDoc_adjcex;
		private decimal? _originalDoc_ceicea;
		private decimal? _originalDoc_ceicex;
		private string _originalCeicea_prt_format;
		private string _originalCeicex_prt_format;
		private string _originalYtdcea_prt_format;
		private string _originalYtdcex_prt_format;
		private decimal? _originalDoc_ytdinc_g;
		private string _originalDoc_rma_expense_percent_misc;
		private string _originalDoc_rma_expense_percent_reg;
		private decimal? _originalDoc_yrly_ceiling_computed;
		private decimal? _originalDoc_yrly_expense_computed;
		private decimal? _originalDoc_payeft;
		private decimal? _originalDoc_ytdded;
		private string _originalDoc_dept_expense_percent_misc;
		private string _originalDoc_dept_expense_percent_reg;
		private string _originalDoc_ep_ped;
		private string _originalDoc_ep_pay_code;
		private string _originalDoc_ep_pay_sub_code;
		private decimal? _originalDoc_yrly_require_revenue;
		private decimal? _originalDoc_yrly_target_revenue;
		private decimal? _originalDoc_ceireq;
		private decimal? _originalDoc_ytdreq;
		private decimal? _originalDoc_ceitar;
		private decimal? _originalDoc_ytdtar;
		private string _originalCeireq_prt_format;
		private string _originalYtdreq_prt_format;
		private string _originalCeitar_prt_format;
		private string _originalYtdtar_prt_format;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			DOC_NBR = _originalDoc_nbr;
			EP_NBR = _originalEp_nbr;
			DOC_BANK_NBR = _originalDoc_bank_nbr;
			DOC_BANK_BRANCH = _originalDoc_bank_branch;
			DOC_BANK_ACCT = _originalDoc_bank_acct;
			DOC_YTDGUA = _originalDoc_ytdgua;
			DOC_YTDGUB = _originalDoc_ytdgub;
			DOC_YTDGUC = _originalDoc_ytdguc;
			DOC_YTDGUD = _originalDoc_ytdgud;
			DOC_YTDCEA = _originalDoc_ytdcea;
			DOC_YTDCEX = _originalDoc_ytdcex;
			DOC_YTDEAR = _originalDoc_ytdear;
			DOC_YTDINC = _originalDoc_ytdinc;
			DOC_YTDEFT = _originalDoc_ytdeft;
			DOC_TOTINC_G = _originalDoc_totinc_g;
			DOC_EP_DATE_DEPOSIT = _originalDoc_ep_date_deposit;
			DOC_TOTINC = _originalDoc_totinc;
			DOC_EP_CEIEXP = _originalDoc_ep_ceiexp;
			DOC_ADJCEA = _originalDoc_adjcea;
			DOC_ADJCEX = _originalDoc_adjcex;
			DOC_CEICEA = _originalDoc_ceicea;
			DOC_CEICEX = _originalDoc_ceicex;
			CEICEA_PRT_FORMAT = _originalCeicea_prt_format;
			CEICEX_PRT_FORMAT = _originalCeicex_prt_format;
			YTDCEA_PRT_FORMAT = _originalYtdcea_prt_format;
			YTDCEX_PRT_FORMAT = _originalYtdcex_prt_format;
			DOC_YTDINC_G = _originalDoc_ytdinc_g;
			DOC_RMA_EXPENSE_PERCENT_MISC = _originalDoc_rma_expense_percent_misc;
			DOC_RMA_EXPENSE_PERCENT_REG = _originalDoc_rma_expense_percent_reg;
			DOC_YRLY_CEILING_COMPUTED = _originalDoc_yrly_ceiling_computed;
			DOC_YRLY_EXPENSE_COMPUTED = _originalDoc_yrly_expense_computed;
			DOC_PAYEFT = _originalDoc_payeft;
			DOC_YTDDED = _originalDoc_ytdded;
			DOC_DEPT_EXPENSE_PERCENT_MISC = _originalDoc_dept_expense_percent_misc;
			DOC_DEPT_EXPENSE_PERCENT_REG = _originalDoc_dept_expense_percent_reg;
			DOC_EP_PED = _originalDoc_ep_ped;
			DOC_EP_PAY_CODE = _originalDoc_ep_pay_code;
			DOC_EP_PAY_SUB_CODE = _originalDoc_ep_pay_sub_code;
			DOC_YRLY_REQUIRE_REVENUE = _originalDoc_yrly_require_revenue;
			DOC_YRLY_TARGET_REVENUE = _originalDoc_yrly_target_revenue;
			DOC_CEIREQ = _originalDoc_ceireq;
			DOC_YTDREQ = _originalDoc_ytdreq;
			DOC_CEITAR = _originalDoc_ceitar;
			DOC_YTDTAR = _originalDoc_ytdtar;
			CEIREQ_PRT_FORMAT = _originalCeireq_prt_format;
			YTDREQ_PRT_FORMAT = _originalYtdreq_prt_format;
			CEITAR_PRT_FORMAT = _originalCeitar_prt_format;
			YTDTAR_PRT_FORMAT = _originalYtdtar_prt_format;
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
					new SqlParameter("DOC_NBR",DOC_NBR),
					new SqlParameter("EP_NBR",EP_NBR)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F020_DOC_MSTR_HISTORY_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F020_DOC_MSTR_HISTORY_Purge]");
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
						new SqlParameter("EP_NBR", SqlNull(EP_NBR)),
						new SqlParameter("DOC_BANK_NBR", SqlNull(DOC_BANK_NBR)),
						new SqlParameter("DOC_BANK_BRANCH", SqlNull(DOC_BANK_BRANCH)),
						new SqlParameter("DOC_BANK_ACCT", SqlNull(DOC_BANK_ACCT)),
						new SqlParameter("DOC_YTDGUA", SqlNull(DOC_YTDGUA)),
						new SqlParameter("DOC_YTDGUB", SqlNull(DOC_YTDGUB)),
						new SqlParameter("DOC_YTDGUC", SqlNull(DOC_YTDGUC)),
						new SqlParameter("DOC_YTDGUD", SqlNull(DOC_YTDGUD)),
						new SqlParameter("DOC_YTDCEA", SqlNull(DOC_YTDCEA)),
						new SqlParameter("DOC_YTDCEX", SqlNull(DOC_YTDCEX)),
						new SqlParameter("DOC_YTDEAR", SqlNull(DOC_YTDEAR)),
						new SqlParameter("DOC_YTDINC", SqlNull(DOC_YTDINC)),
						new SqlParameter("DOC_YTDEFT", SqlNull(DOC_YTDEFT)),
						new SqlParameter("DOC_TOTINC_G", SqlNull(DOC_TOTINC_G)),
						new SqlParameter("DOC_EP_DATE_DEPOSIT", SqlNull(DOC_EP_DATE_DEPOSIT)),
						new SqlParameter("DOC_TOTINC", SqlNull(DOC_TOTINC)),
						new SqlParameter("DOC_EP_CEIEXP", SqlNull(DOC_EP_CEIEXP)),
						new SqlParameter("DOC_ADJCEA", SqlNull(DOC_ADJCEA)),
						new SqlParameter("DOC_ADJCEX", SqlNull(DOC_ADJCEX)),
						new SqlParameter("DOC_CEICEA", SqlNull(DOC_CEICEA)),
						new SqlParameter("DOC_CEICEX", SqlNull(DOC_CEICEX)),
						new SqlParameter("CEICEA_PRT_FORMAT", SqlNull(CEICEA_PRT_FORMAT)),
						new SqlParameter("CEICEX_PRT_FORMAT", SqlNull(CEICEX_PRT_FORMAT)),
						new SqlParameter("YTDCEA_PRT_FORMAT", SqlNull(YTDCEA_PRT_FORMAT)),
						new SqlParameter("YTDCEX_PRT_FORMAT", SqlNull(YTDCEX_PRT_FORMAT)),
						new SqlParameter("DOC_YTDINC_G", SqlNull(DOC_YTDINC_G)),
						new SqlParameter("DOC_RMA_EXPENSE_PERCENT_MISC", SqlNull(DOC_RMA_EXPENSE_PERCENT_MISC)),
						new SqlParameter("DOC_RMA_EXPENSE_PERCENT_REG", SqlNull(DOC_RMA_EXPENSE_PERCENT_REG)),
						new SqlParameter("DOC_YRLY_CEILING_COMPUTED", SqlNull(DOC_YRLY_CEILING_COMPUTED)),
						new SqlParameter("DOC_YRLY_EXPENSE_COMPUTED", SqlNull(DOC_YRLY_EXPENSE_COMPUTED)),
						new SqlParameter("DOC_PAYEFT", SqlNull(DOC_PAYEFT)),
						new SqlParameter("DOC_YTDDED", SqlNull(DOC_YTDDED)),
						new SqlParameter("DOC_DEPT_EXPENSE_PERCENT_MISC", SqlNull(DOC_DEPT_EXPENSE_PERCENT_MISC)),
						new SqlParameter("DOC_DEPT_EXPENSE_PERCENT_REG", SqlNull(DOC_DEPT_EXPENSE_PERCENT_REG)),
						new SqlParameter("DOC_EP_PED", SqlNull(DOC_EP_PED)),
						new SqlParameter("DOC_EP_PAY_CODE", SqlNull(DOC_EP_PAY_CODE)),
						new SqlParameter("DOC_EP_PAY_SUB_CODE", SqlNull(DOC_EP_PAY_SUB_CODE)),
						new SqlParameter("DOC_YRLY_REQUIRE_REVENUE", SqlNull(DOC_YRLY_REQUIRE_REVENUE)),
						new SqlParameter("DOC_YRLY_TARGET_REVENUE", SqlNull(DOC_YRLY_TARGET_REVENUE)),
						new SqlParameter("DOC_CEIREQ", SqlNull(DOC_CEIREQ)),
						new SqlParameter("DOC_YTDREQ", SqlNull(DOC_YTDREQ)),
						new SqlParameter("DOC_CEITAR", SqlNull(DOC_CEITAR)),
						new SqlParameter("DOC_YTDTAR", SqlNull(DOC_YTDTAR)),
						new SqlParameter("CEIREQ_PRT_FORMAT", SqlNull(CEIREQ_PRT_FORMAT)),
						new SqlParameter("YTDREQ_PRT_FORMAT", SqlNull(YTDREQ_PRT_FORMAT)),
						new SqlParameter("CEITAR_PRT_FORMAT", SqlNull(CEITAR_PRT_FORMAT)),
						new SqlParameter("YTDTAR_PRT_FORMAT", SqlNull(YTDTAR_PRT_FORMAT)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F020_DOC_MSTR_HISTORY_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOC_NBR = Reader["DOC_NBR"].ToString();
						EP_NBR = ConvertDEC(Reader["EP_NBR"]);
						DOC_BANK_NBR = ConvertDEC(Reader["DOC_BANK_NBR"]);
						DOC_BANK_BRANCH = ConvertDEC(Reader["DOC_BANK_BRANCH"]);
						DOC_BANK_ACCT = Reader["DOC_BANK_ACCT"].ToString();
						DOC_YTDGUA = ConvertDEC(Reader["DOC_YTDGUA"]);
						DOC_YTDGUB = ConvertDEC(Reader["DOC_YTDGUB"]);
						DOC_YTDGUC = ConvertDEC(Reader["DOC_YTDGUC"]);
						DOC_YTDGUD = ConvertDEC(Reader["DOC_YTDGUD"]);
						DOC_YTDCEA = ConvertDEC(Reader["DOC_YTDCEA"]);
						DOC_YTDCEX = ConvertDEC(Reader["DOC_YTDCEX"]);
						DOC_YTDEAR = ConvertDEC(Reader["DOC_YTDEAR"]);
						DOC_YTDINC = ConvertDEC(Reader["DOC_YTDINC"]);
						DOC_YTDEFT = ConvertDEC(Reader["DOC_YTDEFT"]);
						DOC_TOTINC_G = ConvertDEC(Reader["DOC_TOTINC_G"]);
						DOC_EP_DATE_DEPOSIT = ConvertDEC(Reader["DOC_EP_DATE_DEPOSIT"]);
						DOC_TOTINC = ConvertDEC(Reader["DOC_TOTINC"]);
						DOC_EP_CEIEXP = ConvertDEC(Reader["DOC_EP_CEIEXP"]);
						DOC_ADJCEA = ConvertDEC(Reader["DOC_ADJCEA"]);
						DOC_ADJCEX = ConvertDEC(Reader["DOC_ADJCEX"]);
						DOC_CEICEA = ConvertDEC(Reader["DOC_CEICEA"]);
						DOC_CEICEX = ConvertDEC(Reader["DOC_CEICEX"]);
						CEICEA_PRT_FORMAT = Reader["CEICEA_PRT_FORMAT"].ToString();
						CEICEX_PRT_FORMAT = Reader["CEICEX_PRT_FORMAT"].ToString();
						YTDCEA_PRT_FORMAT = Reader["YTDCEA_PRT_FORMAT"].ToString();
						YTDCEX_PRT_FORMAT = Reader["YTDCEX_PRT_FORMAT"].ToString();
						DOC_YTDINC_G = ConvertDEC(Reader["DOC_YTDINC_G"]);
						DOC_RMA_EXPENSE_PERCENT_MISC = Reader["DOC_RMA_EXPENSE_PERCENT_MISC"].ToString();
						DOC_RMA_EXPENSE_PERCENT_REG = Reader["DOC_RMA_EXPENSE_PERCENT_REG"].ToString();
						DOC_YRLY_CEILING_COMPUTED = ConvertDEC(Reader["DOC_YRLY_CEILING_COMPUTED"]);
						DOC_YRLY_EXPENSE_COMPUTED = ConvertDEC(Reader["DOC_YRLY_EXPENSE_COMPUTED"]);
						DOC_PAYEFT = ConvertDEC(Reader["DOC_PAYEFT"]);
						DOC_YTDDED = ConvertDEC(Reader["DOC_YTDDED"]);
						DOC_DEPT_EXPENSE_PERCENT_MISC = Reader["DOC_DEPT_EXPENSE_PERCENT_MISC"].ToString();
						DOC_DEPT_EXPENSE_PERCENT_REG = Reader["DOC_DEPT_EXPENSE_PERCENT_REG"].ToString();
						DOC_EP_PED = Reader["DOC_EP_PED"].ToString();
						DOC_EP_PAY_CODE = Reader["DOC_EP_PAY_CODE"].ToString();
						DOC_EP_PAY_SUB_CODE = Reader["DOC_EP_PAY_SUB_CODE"].ToString();
						DOC_YRLY_REQUIRE_REVENUE = ConvertDEC(Reader["DOC_YRLY_REQUIRE_REVENUE"]);
						DOC_YRLY_TARGET_REVENUE = ConvertDEC(Reader["DOC_YRLY_TARGET_REVENUE"]);
						DOC_CEIREQ = ConvertDEC(Reader["DOC_CEIREQ"]);
						DOC_YTDREQ = ConvertDEC(Reader["DOC_YTDREQ"]);
						DOC_CEITAR = ConvertDEC(Reader["DOC_CEITAR"]);
						DOC_YTDTAR = ConvertDEC(Reader["DOC_YTDTAR"]);
						CEIREQ_PRT_FORMAT = Reader["CEIREQ_PRT_FORMAT"].ToString();
						YTDREQ_PRT_FORMAT = Reader["YTDREQ_PRT_FORMAT"].ToString();
						CEITAR_PRT_FORMAT = Reader["CEITAR_PRT_FORMAT"].ToString();
						YTDTAR_PRT_FORMAT = Reader["YTDTAR_PRT_FORMAT"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalEp_nbr = ConvertDEC(Reader["EP_NBR"]);
						_originalDoc_bank_nbr = ConvertDEC(Reader["DOC_BANK_NBR"]);
						_originalDoc_bank_branch = ConvertDEC(Reader["DOC_BANK_BRANCH"]);
						_originalDoc_bank_acct = Reader["DOC_BANK_ACCT"].ToString();
						_originalDoc_ytdgua = ConvertDEC(Reader["DOC_YTDGUA"]);
						_originalDoc_ytdgub = ConvertDEC(Reader["DOC_YTDGUB"]);
						_originalDoc_ytdguc = ConvertDEC(Reader["DOC_YTDGUC"]);
						_originalDoc_ytdgud = ConvertDEC(Reader["DOC_YTDGUD"]);
						_originalDoc_ytdcea = ConvertDEC(Reader["DOC_YTDCEA"]);
						_originalDoc_ytdcex = ConvertDEC(Reader["DOC_YTDCEX"]);
						_originalDoc_ytdear = ConvertDEC(Reader["DOC_YTDEAR"]);
						_originalDoc_ytdinc = ConvertDEC(Reader["DOC_YTDINC"]);
						_originalDoc_ytdeft = ConvertDEC(Reader["DOC_YTDEFT"]);
						_originalDoc_totinc_g = ConvertDEC(Reader["DOC_TOTINC_G"]);
						_originalDoc_ep_date_deposit = ConvertDEC(Reader["DOC_EP_DATE_DEPOSIT"]);
						_originalDoc_totinc = ConvertDEC(Reader["DOC_TOTINC"]);
						_originalDoc_ep_ceiexp = ConvertDEC(Reader["DOC_EP_CEIEXP"]);
						_originalDoc_adjcea = ConvertDEC(Reader["DOC_ADJCEA"]);
						_originalDoc_adjcex = ConvertDEC(Reader["DOC_ADJCEX"]);
						_originalDoc_ceicea = ConvertDEC(Reader["DOC_CEICEA"]);
						_originalDoc_ceicex = ConvertDEC(Reader["DOC_CEICEX"]);
						_originalCeicea_prt_format = Reader["CEICEA_PRT_FORMAT"].ToString();
						_originalCeicex_prt_format = Reader["CEICEX_PRT_FORMAT"].ToString();
						_originalYtdcea_prt_format = Reader["YTDCEA_PRT_FORMAT"].ToString();
						_originalYtdcex_prt_format = Reader["YTDCEX_PRT_FORMAT"].ToString();
						_originalDoc_ytdinc_g = ConvertDEC(Reader["DOC_YTDINC_G"]);
						_originalDoc_rma_expense_percent_misc = Reader["DOC_RMA_EXPENSE_PERCENT_MISC"].ToString();
						_originalDoc_rma_expense_percent_reg = Reader["DOC_RMA_EXPENSE_PERCENT_REG"].ToString();
						_originalDoc_yrly_ceiling_computed = ConvertDEC(Reader["DOC_YRLY_CEILING_COMPUTED"]);
						_originalDoc_yrly_expense_computed = ConvertDEC(Reader["DOC_YRLY_EXPENSE_COMPUTED"]);
						_originalDoc_payeft = ConvertDEC(Reader["DOC_PAYEFT"]);
						_originalDoc_ytdded = ConvertDEC(Reader["DOC_YTDDED"]);
						_originalDoc_dept_expense_percent_misc = Reader["DOC_DEPT_EXPENSE_PERCENT_MISC"].ToString();
						_originalDoc_dept_expense_percent_reg = Reader["DOC_DEPT_EXPENSE_PERCENT_REG"].ToString();
						_originalDoc_ep_ped = Reader["DOC_EP_PED"].ToString();
						_originalDoc_ep_pay_code = Reader["DOC_EP_PAY_CODE"].ToString();
						_originalDoc_ep_pay_sub_code = Reader["DOC_EP_PAY_SUB_CODE"].ToString();
						_originalDoc_yrly_require_revenue = ConvertDEC(Reader["DOC_YRLY_REQUIRE_REVENUE"]);
						_originalDoc_yrly_target_revenue = ConvertDEC(Reader["DOC_YRLY_TARGET_REVENUE"]);
						_originalDoc_ceireq = ConvertDEC(Reader["DOC_CEIREQ"]);
						_originalDoc_ytdreq = ConvertDEC(Reader["DOC_YTDREQ"]);
						_originalDoc_ceitar = ConvertDEC(Reader["DOC_CEITAR"]);
						_originalDoc_ytdtar = ConvertDEC(Reader["DOC_YTDTAR"]);
						_originalCeireq_prt_format = Reader["CEIREQ_PRT_FORMAT"].ToString();
						_originalYtdreq_prt_format = Reader["YTDREQ_PRT_FORMAT"].ToString();
						_originalCeitar_prt_format = Reader["CEITAR_PRT_FORMAT"].ToString();
						_originalYtdtar_prt_format = Reader["YTDTAR_PRT_FORMAT"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("DOC_NBR", SqlNull(DOC_NBR)),
						new SqlParameter("EP_NBR", SqlNull(EP_NBR)),
						new SqlParameter("DOC_BANK_NBR", SqlNull(DOC_BANK_NBR)),
						new SqlParameter("DOC_BANK_BRANCH", SqlNull(DOC_BANK_BRANCH)),
						new SqlParameter("DOC_BANK_ACCT", SqlNull(DOC_BANK_ACCT)),
						new SqlParameter("DOC_YTDGUA", SqlNull(DOC_YTDGUA)),
						new SqlParameter("DOC_YTDGUB", SqlNull(DOC_YTDGUB)),
						new SqlParameter("DOC_YTDGUC", SqlNull(DOC_YTDGUC)),
						new SqlParameter("DOC_YTDGUD", SqlNull(DOC_YTDGUD)),
						new SqlParameter("DOC_YTDCEA", SqlNull(DOC_YTDCEA)),
						new SqlParameter("DOC_YTDCEX", SqlNull(DOC_YTDCEX)),
						new SqlParameter("DOC_YTDEAR", SqlNull(DOC_YTDEAR)),
						new SqlParameter("DOC_YTDINC", SqlNull(DOC_YTDINC)),
						new SqlParameter("DOC_YTDEFT", SqlNull(DOC_YTDEFT)),
						new SqlParameter("DOC_TOTINC_G", SqlNull(DOC_TOTINC_G)),
						new SqlParameter("DOC_EP_DATE_DEPOSIT", SqlNull(DOC_EP_DATE_DEPOSIT)),
						new SqlParameter("DOC_TOTINC", SqlNull(DOC_TOTINC)),
						new SqlParameter("DOC_EP_CEIEXP", SqlNull(DOC_EP_CEIEXP)),
						new SqlParameter("DOC_ADJCEA", SqlNull(DOC_ADJCEA)),
						new SqlParameter("DOC_ADJCEX", SqlNull(DOC_ADJCEX)),
						new SqlParameter("DOC_CEICEA", SqlNull(DOC_CEICEA)),
						new SqlParameter("DOC_CEICEX", SqlNull(DOC_CEICEX)),
						new SqlParameter("CEICEA_PRT_FORMAT", SqlNull(CEICEA_PRT_FORMAT)),
						new SqlParameter("CEICEX_PRT_FORMAT", SqlNull(CEICEX_PRT_FORMAT)),
						new SqlParameter("YTDCEA_PRT_FORMAT", SqlNull(YTDCEA_PRT_FORMAT)),
						new SqlParameter("YTDCEX_PRT_FORMAT", SqlNull(YTDCEX_PRT_FORMAT)),
						new SqlParameter("DOC_YTDINC_G", SqlNull(DOC_YTDINC_G)),
						new SqlParameter("DOC_RMA_EXPENSE_PERCENT_MISC", SqlNull(DOC_RMA_EXPENSE_PERCENT_MISC)),
						new SqlParameter("DOC_RMA_EXPENSE_PERCENT_REG", SqlNull(DOC_RMA_EXPENSE_PERCENT_REG)),
						new SqlParameter("DOC_YRLY_CEILING_COMPUTED", SqlNull(DOC_YRLY_CEILING_COMPUTED)),
						new SqlParameter("DOC_YRLY_EXPENSE_COMPUTED", SqlNull(DOC_YRLY_EXPENSE_COMPUTED)),
						new SqlParameter("DOC_PAYEFT", SqlNull(DOC_PAYEFT)),
						new SqlParameter("DOC_YTDDED", SqlNull(DOC_YTDDED)),
						new SqlParameter("DOC_DEPT_EXPENSE_PERCENT_MISC", SqlNull(DOC_DEPT_EXPENSE_PERCENT_MISC)),
						new SqlParameter("DOC_DEPT_EXPENSE_PERCENT_REG", SqlNull(DOC_DEPT_EXPENSE_PERCENT_REG)),
						new SqlParameter("DOC_EP_PED", SqlNull(DOC_EP_PED)),
						new SqlParameter("DOC_EP_PAY_CODE", SqlNull(DOC_EP_PAY_CODE)),
						new SqlParameter("DOC_EP_PAY_SUB_CODE", SqlNull(DOC_EP_PAY_SUB_CODE)),
						new SqlParameter("DOC_YRLY_REQUIRE_REVENUE", SqlNull(DOC_YRLY_REQUIRE_REVENUE)),
						new SqlParameter("DOC_YRLY_TARGET_REVENUE", SqlNull(DOC_YRLY_TARGET_REVENUE)),
						new SqlParameter("DOC_CEIREQ", SqlNull(DOC_CEIREQ)),
						new SqlParameter("DOC_YTDREQ", SqlNull(DOC_YTDREQ)),
						new SqlParameter("DOC_CEITAR", SqlNull(DOC_CEITAR)),
						new SqlParameter("DOC_YTDTAR", SqlNull(DOC_YTDTAR)),
						new SqlParameter("CEIREQ_PRT_FORMAT", SqlNull(CEIREQ_PRT_FORMAT)),
						new SqlParameter("YTDREQ_PRT_FORMAT", SqlNull(YTDREQ_PRT_FORMAT)),
						new SqlParameter("CEITAR_PRT_FORMAT", SqlNull(CEITAR_PRT_FORMAT)),
						new SqlParameter("YTDTAR_PRT_FORMAT", SqlNull(YTDTAR_PRT_FORMAT)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F020_DOC_MSTR_HISTORY_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOC_NBR = Reader["DOC_NBR"].ToString();
						EP_NBR = ConvertDEC(Reader["EP_NBR"]);
						DOC_BANK_NBR = ConvertDEC(Reader["DOC_BANK_NBR"]);
						DOC_BANK_BRANCH = ConvertDEC(Reader["DOC_BANK_BRANCH"]);
						DOC_BANK_ACCT = Reader["DOC_BANK_ACCT"].ToString();
						DOC_YTDGUA = ConvertDEC(Reader["DOC_YTDGUA"]);
						DOC_YTDGUB = ConvertDEC(Reader["DOC_YTDGUB"]);
						DOC_YTDGUC = ConvertDEC(Reader["DOC_YTDGUC"]);
						DOC_YTDGUD = ConvertDEC(Reader["DOC_YTDGUD"]);
						DOC_YTDCEA = ConvertDEC(Reader["DOC_YTDCEA"]);
						DOC_YTDCEX = ConvertDEC(Reader["DOC_YTDCEX"]);
						DOC_YTDEAR = ConvertDEC(Reader["DOC_YTDEAR"]);
						DOC_YTDINC = ConvertDEC(Reader["DOC_YTDINC"]);
						DOC_YTDEFT = ConvertDEC(Reader["DOC_YTDEFT"]);
						DOC_TOTINC_G = ConvertDEC(Reader["DOC_TOTINC_G"]);
						DOC_EP_DATE_DEPOSIT = ConvertDEC(Reader["DOC_EP_DATE_DEPOSIT"]);
						DOC_TOTINC = ConvertDEC(Reader["DOC_TOTINC"]);
						DOC_EP_CEIEXP = ConvertDEC(Reader["DOC_EP_CEIEXP"]);
						DOC_ADJCEA = ConvertDEC(Reader["DOC_ADJCEA"]);
						DOC_ADJCEX = ConvertDEC(Reader["DOC_ADJCEX"]);
						DOC_CEICEA = ConvertDEC(Reader["DOC_CEICEA"]);
						DOC_CEICEX = ConvertDEC(Reader["DOC_CEICEX"]);
						CEICEA_PRT_FORMAT = Reader["CEICEA_PRT_FORMAT"].ToString();
						CEICEX_PRT_FORMAT = Reader["CEICEX_PRT_FORMAT"].ToString();
						YTDCEA_PRT_FORMAT = Reader["YTDCEA_PRT_FORMAT"].ToString();
						YTDCEX_PRT_FORMAT = Reader["YTDCEX_PRT_FORMAT"].ToString();
						DOC_YTDINC_G = ConvertDEC(Reader["DOC_YTDINC_G"]);
						DOC_RMA_EXPENSE_PERCENT_MISC = Reader["DOC_RMA_EXPENSE_PERCENT_MISC"].ToString();
						DOC_RMA_EXPENSE_PERCENT_REG = Reader["DOC_RMA_EXPENSE_PERCENT_REG"].ToString();
						DOC_YRLY_CEILING_COMPUTED = ConvertDEC(Reader["DOC_YRLY_CEILING_COMPUTED"]);
						DOC_YRLY_EXPENSE_COMPUTED = ConvertDEC(Reader["DOC_YRLY_EXPENSE_COMPUTED"]);
						DOC_PAYEFT = ConvertDEC(Reader["DOC_PAYEFT"]);
						DOC_YTDDED = ConvertDEC(Reader["DOC_YTDDED"]);
						DOC_DEPT_EXPENSE_PERCENT_MISC = Reader["DOC_DEPT_EXPENSE_PERCENT_MISC"].ToString();
						DOC_DEPT_EXPENSE_PERCENT_REG = Reader["DOC_DEPT_EXPENSE_PERCENT_REG"].ToString();
						DOC_EP_PED = Reader["DOC_EP_PED"].ToString();
						DOC_EP_PAY_CODE = Reader["DOC_EP_PAY_CODE"].ToString();
						DOC_EP_PAY_SUB_CODE = Reader["DOC_EP_PAY_SUB_CODE"].ToString();
						DOC_YRLY_REQUIRE_REVENUE = ConvertDEC(Reader["DOC_YRLY_REQUIRE_REVENUE"]);
						DOC_YRLY_TARGET_REVENUE = ConvertDEC(Reader["DOC_YRLY_TARGET_REVENUE"]);
						DOC_CEIREQ = ConvertDEC(Reader["DOC_CEIREQ"]);
						DOC_YTDREQ = ConvertDEC(Reader["DOC_YTDREQ"]);
						DOC_CEITAR = ConvertDEC(Reader["DOC_CEITAR"]);
						DOC_YTDTAR = ConvertDEC(Reader["DOC_YTDTAR"]);
						CEIREQ_PRT_FORMAT = Reader["CEIREQ_PRT_FORMAT"].ToString();
						YTDREQ_PRT_FORMAT = Reader["YTDREQ_PRT_FORMAT"].ToString();
						CEITAR_PRT_FORMAT = Reader["CEITAR_PRT_FORMAT"].ToString();
						YTDTAR_PRT_FORMAT = Reader["YTDTAR_PRT_FORMAT"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalEp_nbr = ConvertDEC(Reader["EP_NBR"]);
						_originalDoc_bank_nbr = ConvertDEC(Reader["DOC_BANK_NBR"]);
						_originalDoc_bank_branch = ConvertDEC(Reader["DOC_BANK_BRANCH"]);
						_originalDoc_bank_acct = Reader["DOC_BANK_ACCT"].ToString();
						_originalDoc_ytdgua = ConvertDEC(Reader["DOC_YTDGUA"]);
						_originalDoc_ytdgub = ConvertDEC(Reader["DOC_YTDGUB"]);
						_originalDoc_ytdguc = ConvertDEC(Reader["DOC_YTDGUC"]);
						_originalDoc_ytdgud = ConvertDEC(Reader["DOC_YTDGUD"]);
						_originalDoc_ytdcea = ConvertDEC(Reader["DOC_YTDCEA"]);
						_originalDoc_ytdcex = ConvertDEC(Reader["DOC_YTDCEX"]);
						_originalDoc_ytdear = ConvertDEC(Reader["DOC_YTDEAR"]);
						_originalDoc_ytdinc = ConvertDEC(Reader["DOC_YTDINC"]);
						_originalDoc_ytdeft = ConvertDEC(Reader["DOC_YTDEFT"]);
						_originalDoc_totinc_g = ConvertDEC(Reader["DOC_TOTINC_G"]);
						_originalDoc_ep_date_deposit = ConvertDEC(Reader["DOC_EP_DATE_DEPOSIT"]);
						_originalDoc_totinc = ConvertDEC(Reader["DOC_TOTINC"]);
						_originalDoc_ep_ceiexp = ConvertDEC(Reader["DOC_EP_CEIEXP"]);
						_originalDoc_adjcea = ConvertDEC(Reader["DOC_ADJCEA"]);
						_originalDoc_adjcex = ConvertDEC(Reader["DOC_ADJCEX"]);
						_originalDoc_ceicea = ConvertDEC(Reader["DOC_CEICEA"]);
						_originalDoc_ceicex = ConvertDEC(Reader["DOC_CEICEX"]);
						_originalCeicea_prt_format = Reader["CEICEA_PRT_FORMAT"].ToString();
						_originalCeicex_prt_format = Reader["CEICEX_PRT_FORMAT"].ToString();
						_originalYtdcea_prt_format = Reader["YTDCEA_PRT_FORMAT"].ToString();
						_originalYtdcex_prt_format = Reader["YTDCEX_PRT_FORMAT"].ToString();
						_originalDoc_ytdinc_g = ConvertDEC(Reader["DOC_YTDINC_G"]);
						_originalDoc_rma_expense_percent_misc = Reader["DOC_RMA_EXPENSE_PERCENT_MISC"].ToString();
						_originalDoc_rma_expense_percent_reg = Reader["DOC_RMA_EXPENSE_PERCENT_REG"].ToString();
						_originalDoc_yrly_ceiling_computed = ConvertDEC(Reader["DOC_YRLY_CEILING_COMPUTED"]);
						_originalDoc_yrly_expense_computed = ConvertDEC(Reader["DOC_YRLY_EXPENSE_COMPUTED"]);
						_originalDoc_payeft = ConvertDEC(Reader["DOC_PAYEFT"]);
						_originalDoc_ytdded = ConvertDEC(Reader["DOC_YTDDED"]);
						_originalDoc_dept_expense_percent_misc = Reader["DOC_DEPT_EXPENSE_PERCENT_MISC"].ToString();
						_originalDoc_dept_expense_percent_reg = Reader["DOC_DEPT_EXPENSE_PERCENT_REG"].ToString();
						_originalDoc_ep_ped = Reader["DOC_EP_PED"].ToString();
						_originalDoc_ep_pay_code = Reader["DOC_EP_PAY_CODE"].ToString();
						_originalDoc_ep_pay_sub_code = Reader["DOC_EP_PAY_SUB_CODE"].ToString();
						_originalDoc_yrly_require_revenue = ConvertDEC(Reader["DOC_YRLY_REQUIRE_REVENUE"]);
						_originalDoc_yrly_target_revenue = ConvertDEC(Reader["DOC_YRLY_TARGET_REVENUE"]);
						_originalDoc_ceireq = ConvertDEC(Reader["DOC_CEIREQ"]);
						_originalDoc_ytdreq = ConvertDEC(Reader["DOC_YTDREQ"]);
						_originalDoc_ceitar = ConvertDEC(Reader["DOC_CEITAR"]);
						_originalDoc_ytdtar = ConvertDEC(Reader["DOC_YTDTAR"]);
						_originalCeireq_prt_format = Reader["CEIREQ_PRT_FORMAT"].ToString();
						_originalYtdreq_prt_format = Reader["YTDREQ_PRT_FORMAT"].ToString();
						_originalCeitar_prt_format = Reader["CEITAR_PRT_FORMAT"].ToString();
						_originalYtdtar_prt_format = Reader["YTDTAR_PRT_FORMAT"].ToString();
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