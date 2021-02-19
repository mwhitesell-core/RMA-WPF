using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F112_PYCDCEILINGS_AUDIT : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F112_PYCDCEILINGS_AUDIT> Collection( Guid? rowid,
															string doc_nbr,
															decimal? ep_nbrmin,
															decimal? ep_nbrmax,
															decimal? factormin,
															decimal? factormax,
															string doc_pay_code,
															string doc_pay_sub_code,
															decimal? retro_to_ep_nbrmin,
															decimal? retro_to_ep_nbrmax,
															decimal? doc_yrly_ceilingmin,
															decimal? doc_yrly_ceilingmax,
															decimal? doc_yrly_ceiling_adjustedmin,
															decimal? doc_yrly_ceiling_adjustedmax,
															decimal? doc_yrly_ceiling_computedmin,
															decimal? doc_yrly_ceiling_computedmax,
															decimal? doc_yrly_expensemin,
															decimal? doc_yrly_expensemax,
															decimal? doc_yrly_expense_adjustedmin,
															decimal? doc_yrly_expense_adjustedmax,
															decimal? doc_yrly_expense_computedmin,
															decimal? doc_yrly_expense_computedmax,
															decimal? doc_yrly_expn_alloc_persmin,
															decimal? doc_yrly_expn_alloc_persmax,
															decimal? doc_yrly_ceil_guarmin,
															decimal? doc_yrly_ceil_guarmax,
															decimal? doc_yrly_ceiling_guar_percmin,
															decimal? doc_yrly_ceiling_guar_percmax,
															int? doc_rma_expense_percent_regmin,
															int? doc_rma_expense_percent_regmax,
															int? doc_rma_expense_percent_miscmin,
															int? doc_rma_expense_percent_miscmax,
															int? doc_dept_expense_percent_regmin,
															int? doc_dept_expense_percent_regmax,
															int? doc_dept_expense_percent_miscmin,
															int? doc_dept_expense_percent_miscmax,
															int? doc_yrly_reqrevmin,
															int? doc_yrly_reqrevmax,
															int? doc_yrly_reqrev_adjustedmin,
															int? doc_yrly_reqrev_adjustedmax,
															decimal? doc_yrly_reqrev_computedmin,
															decimal? doc_yrly_reqrev_computedmax,
															int? doc_yrly_tarrevmin,
															int? doc_yrly_tarrevmax,
															int? doc_yrly_tarrev_adjustedmin,
															int? doc_yrly_tarrev_adjustedmax,
															long? doc_yrly_tarrev_computedmin,
															long? doc_yrly_tarrev_computedmax,
															decimal? retro_to_ep_nbr_reqmin,
															decimal? retro_to_ep_nbr_reqmax,
															decimal? retro_to_ep_nbr_tarmin,
															decimal? retro_to_ep_nbr_tarmax,
															string last_mod_flag,
															decimal? last_mod_datemin,
															decimal? last_mod_datemax,
															decimal? last_mod_timemin,
															decimal? last_mod_timemax,
															string last_mod_user_id,
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
					new SqlParameter("minFACTOR",factormin),
					new SqlParameter("maxFACTOR",factormax),
					new SqlParameter("DOC_PAY_CODE",doc_pay_code),
					new SqlParameter("DOC_PAY_SUB_CODE",doc_pay_sub_code),
					new SqlParameter("minRETRO_TO_EP_NBR",retro_to_ep_nbrmin),
					new SqlParameter("maxRETRO_TO_EP_NBR",retro_to_ep_nbrmax),
					new SqlParameter("minDOC_YRLY_CEILING",doc_yrly_ceilingmin),
					new SqlParameter("maxDOC_YRLY_CEILING",doc_yrly_ceilingmax),
					new SqlParameter("minDOC_YRLY_CEILING_ADJUSTED",doc_yrly_ceiling_adjustedmin),
					new SqlParameter("maxDOC_YRLY_CEILING_ADJUSTED",doc_yrly_ceiling_adjustedmax),
					new SqlParameter("minDOC_YRLY_CEILING_COMPUTED",doc_yrly_ceiling_computedmin),
					new SqlParameter("maxDOC_YRLY_CEILING_COMPUTED",doc_yrly_ceiling_computedmax),
					new SqlParameter("minDOC_YRLY_EXPENSE",doc_yrly_expensemin),
					new SqlParameter("maxDOC_YRLY_EXPENSE",doc_yrly_expensemax),
					new SqlParameter("minDOC_YRLY_EXPENSE_ADJUSTED",doc_yrly_expense_adjustedmin),
					new SqlParameter("maxDOC_YRLY_EXPENSE_ADJUSTED",doc_yrly_expense_adjustedmax),
					new SqlParameter("minDOC_YRLY_EXPENSE_COMPUTED",doc_yrly_expense_computedmin),
					new SqlParameter("maxDOC_YRLY_EXPENSE_COMPUTED",doc_yrly_expense_computedmax),
					new SqlParameter("minDOC_YRLY_EXPN_ALLOC_PERS",doc_yrly_expn_alloc_persmin),
					new SqlParameter("maxDOC_YRLY_EXPN_ALLOC_PERS",doc_yrly_expn_alloc_persmax),
					new SqlParameter("minDOC_YRLY_CEIL_GUAR",doc_yrly_ceil_guarmin),
					new SqlParameter("maxDOC_YRLY_CEIL_GUAR",doc_yrly_ceil_guarmax),
					new SqlParameter("minDOC_YRLY_CEILING_GUAR_PERC",doc_yrly_ceiling_guar_percmin),
					new SqlParameter("maxDOC_YRLY_CEILING_GUAR_PERC",doc_yrly_ceiling_guar_percmax),
					new SqlParameter("minDOC_RMA_EXPENSE_PERCENT_REG",doc_rma_expense_percent_regmin),
					new SqlParameter("maxDOC_RMA_EXPENSE_PERCENT_REG",doc_rma_expense_percent_regmax),
					new SqlParameter("minDOC_RMA_EXPENSE_PERCENT_MISC",doc_rma_expense_percent_miscmin),
					new SqlParameter("maxDOC_RMA_EXPENSE_PERCENT_MISC",doc_rma_expense_percent_miscmax),
					new SqlParameter("minDOC_DEPT_EXPENSE_PERCENT_REG",doc_dept_expense_percent_regmin),
					new SqlParameter("maxDOC_DEPT_EXPENSE_PERCENT_REG",doc_dept_expense_percent_regmax),
					new SqlParameter("minDOC_DEPT_EXPENSE_PERCENT_MISC",doc_dept_expense_percent_miscmin),
					new SqlParameter("maxDOC_DEPT_EXPENSE_PERCENT_MISC",doc_dept_expense_percent_miscmax),
					new SqlParameter("minDOC_YRLY_REQREV",doc_yrly_reqrevmin),
					new SqlParameter("maxDOC_YRLY_REQREV",doc_yrly_reqrevmax),
					new SqlParameter("minDOC_YRLY_REQREV_ADJUSTED",doc_yrly_reqrev_adjustedmin),
					new SqlParameter("maxDOC_YRLY_REQREV_ADJUSTED",doc_yrly_reqrev_adjustedmax),
					new SqlParameter("minDOC_YRLY_REQREV_COMPUTED",doc_yrly_reqrev_computedmin),
					new SqlParameter("maxDOC_YRLY_REQREV_COMPUTED",doc_yrly_reqrev_computedmax),
					new SqlParameter("minDOC_YRLY_TARREV",doc_yrly_tarrevmin),
					new SqlParameter("maxDOC_YRLY_TARREV",doc_yrly_tarrevmax),
					new SqlParameter("minDOC_YRLY_TARREV_ADJUSTED",doc_yrly_tarrev_adjustedmin),
					new SqlParameter("maxDOC_YRLY_TARREV_ADJUSTED",doc_yrly_tarrev_adjustedmax),
					new SqlParameter("minDOC_YRLY_TARREV_COMPUTED",doc_yrly_tarrev_computedmin),
					new SqlParameter("maxDOC_YRLY_TARREV_COMPUTED",doc_yrly_tarrev_computedmax),
					new SqlParameter("minRETRO_TO_EP_NBR_REQ",retro_to_ep_nbr_reqmin),
					new SqlParameter("maxRETRO_TO_EP_NBR_REQ",retro_to_ep_nbr_reqmax),
					new SqlParameter("minRETRO_TO_EP_NBR_TAR",retro_to_ep_nbr_tarmin),
					new SqlParameter("maxRETRO_TO_EP_NBR_TAR",retro_to_ep_nbr_tarmax),
					new SqlParameter("LAST_MOD_FLAG",last_mod_flag),
					new SqlParameter("minLAST_MOD_DATE",last_mod_datemin),
					new SqlParameter("maxLAST_MOD_DATE",last_mod_datemax),
					new SqlParameter("minLAST_MOD_TIME",last_mod_timemin),
					new SqlParameter("maxLAST_MOD_TIME",last_mod_timemax),
					new SqlParameter("LAST_MOD_USER_ID",last_mod_user_id),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[SEQUENTIAL].[sp_F112_PYCDCEILINGS_AUDIT_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F112_PYCDCEILINGS_AUDIT>();
				}

            }

            Reader = CoreReader("[SEQUENTIAL].[sp_F112_PYCDCEILINGS_AUDIT_Search]", parameters);
            var collection = new ObservableCollection<F112_PYCDCEILINGS_AUDIT>();

            while (Reader.Read())
            {
                collection.Add(new F112_PYCDCEILINGS_AUDIT
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					EP_NBR = ConvertDEC(Reader["EP_NBR"]),
					FACTOR = ConvertDEC(Reader["FACTOR"]),
					DOC_PAY_CODE = Reader["DOC_PAY_CODE"].ToString(),
					DOC_PAY_SUB_CODE = Reader["DOC_PAY_SUB_CODE"].ToString(),
					RETRO_TO_EP_NBR = ConvertDEC(Reader["RETRO_TO_EP_NBR"]),
					DOC_YRLY_CEILING = ConvertDEC(Reader["DOC_YRLY_CEILING"]),
					DOC_YRLY_CEILING_ADJUSTED = ConvertDEC(Reader["DOC_YRLY_CEILING_ADJUSTED"]),
					DOC_YRLY_CEILING_COMPUTED = ConvertDEC(Reader["DOC_YRLY_CEILING_COMPUTED"]),
					DOC_YRLY_EXPENSE = ConvertDEC(Reader["DOC_YRLY_EXPENSE"]),
					DOC_YRLY_EXPENSE_ADJUSTED = ConvertDEC(Reader["DOC_YRLY_EXPENSE_ADJUSTED"]),
					DOC_YRLY_EXPENSE_COMPUTED = ConvertDEC(Reader["DOC_YRLY_EXPENSE_COMPUTED"]),
					DOC_YRLY_EXPN_ALLOC_PERS = ConvertDEC(Reader["DOC_YRLY_EXPN_ALLOC_PERS"]),
					DOC_YRLY_CEIL_GUAR = ConvertDEC(Reader["DOC_YRLY_CEIL_GUAR"]),
					DOC_YRLY_CEILING_GUAR_PERC = ConvertDEC(Reader["DOC_YRLY_CEILING_GUAR_PERC"]),
					DOC_RMA_EXPENSE_PERCENT_REG = ConvertINT(Reader["DOC_RMA_EXPENSE_PERCENT_REG"]),
					DOC_RMA_EXPENSE_PERCENT_MISC = ConvertINT(Reader["DOC_RMA_EXPENSE_PERCENT_MISC"]),
					DOC_DEPT_EXPENSE_PERCENT_REG = ConvertINT(Reader["DOC_DEPT_EXPENSE_PERCENT_REG"]),
					DOC_DEPT_EXPENSE_PERCENT_MISC = ConvertINT(Reader["DOC_DEPT_EXPENSE_PERCENT_MISC"]),
					DOC_YRLY_REQREV = ConvertINT(Reader["DOC_YRLY_REQREV"]),
					DOC_YRLY_REQREV_ADJUSTED = ConvertINT(Reader["DOC_YRLY_REQREV_ADJUSTED"]),
					DOC_YRLY_REQREV_COMPUTED = ConvertDEC(Reader["DOC_YRLY_REQREV_COMPUTED"]),
					DOC_YRLY_TARREV = ConvertINT(Reader["DOC_YRLY_TARREV"]),
					DOC_YRLY_TARREV_ADJUSTED = ConvertINT(Reader["DOC_YRLY_TARREV_ADJUSTED"]),
					DOC_YRLY_TARREV_COMPUTED = Reader["DOC_YRLY_TARREV_COMPUTED"].ToString(),
					RETRO_TO_EP_NBR_REQ = ConvertDEC(Reader["RETRO_TO_EP_NBR_REQ"]),
					RETRO_TO_EP_NBR_TAR = ConvertDEC(Reader["RETRO_TO_EP_NBR_TAR"]),
					LAST_MOD_FLAG = Reader["LAST_MOD_FLAG"].ToString(),
					LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]),
					LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]),
					LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalEp_nbr = ConvertDEC(Reader["EP_NBR"]),
					_originalFactor = ConvertDEC(Reader["FACTOR"]),
					_originalDoc_pay_code = Reader["DOC_PAY_CODE"].ToString(),
					_originalDoc_pay_sub_code = Reader["DOC_PAY_SUB_CODE"].ToString(),
					_originalRetro_to_ep_nbr = ConvertDEC(Reader["RETRO_TO_EP_NBR"]),
					_originalDoc_yrly_ceiling = ConvertDEC(Reader["DOC_YRLY_CEILING"]),
					_originalDoc_yrly_ceiling_adjusted = ConvertDEC(Reader["DOC_YRLY_CEILING_ADJUSTED"]),
					_originalDoc_yrly_ceiling_computed = ConvertDEC(Reader["DOC_YRLY_CEILING_COMPUTED"]),
					_originalDoc_yrly_expense = ConvertDEC(Reader["DOC_YRLY_EXPENSE"]),
					_originalDoc_yrly_expense_adjusted = ConvertDEC(Reader["DOC_YRLY_EXPENSE_ADJUSTED"]),
					_originalDoc_yrly_expense_computed = ConvertDEC(Reader["DOC_YRLY_EXPENSE_COMPUTED"]),
					_originalDoc_yrly_expn_alloc_pers = ConvertDEC(Reader["DOC_YRLY_EXPN_ALLOC_PERS"]),
					_originalDoc_yrly_ceil_guar = ConvertDEC(Reader["DOC_YRLY_CEIL_GUAR"]),
					_originalDoc_yrly_ceiling_guar_perc = ConvertDEC(Reader["DOC_YRLY_CEILING_GUAR_PERC"]),
					_originalDoc_rma_expense_percent_reg = ConvertINT(Reader["DOC_RMA_EXPENSE_PERCENT_REG"]),
					_originalDoc_rma_expense_percent_misc = ConvertINT(Reader["DOC_RMA_EXPENSE_PERCENT_MISC"]),
					_originalDoc_dept_expense_percent_reg = ConvertINT(Reader["DOC_DEPT_EXPENSE_PERCENT_REG"]),
					_originalDoc_dept_expense_percent_misc = ConvertINT(Reader["DOC_DEPT_EXPENSE_PERCENT_MISC"]),
					_originalDoc_yrly_reqrev = ConvertINT(Reader["DOC_YRLY_REQREV"]),
					_originalDoc_yrly_reqrev_adjusted = ConvertINT(Reader["DOC_YRLY_REQREV_ADJUSTED"]),
					_originalDoc_yrly_reqrev_computed = ConvertDEC(Reader["DOC_YRLY_REQREV_COMPUTED"]),
					_originalDoc_yrly_tarrev = ConvertINT(Reader["DOC_YRLY_TARREV"]),
					_originalDoc_yrly_tarrev_adjusted = ConvertINT(Reader["DOC_YRLY_TARREV_ADJUSTED"]),
					_originalDoc_yrly_tarrev_computed = Reader["DOC_YRLY_TARREV_COMPUTED"].ToString(),
					_originalRetro_to_ep_nbr_req = ConvertDEC(Reader["RETRO_TO_EP_NBR_REQ"]),
					_originalRetro_to_ep_nbr_tar = ConvertDEC(Reader["RETRO_TO_EP_NBR_TAR"]),
					_originalLast_mod_flag = Reader["LAST_MOD_FLAG"].ToString(),
					_originalLast_mod_date = ConvertDEC(Reader["LAST_MOD_DATE"]),
					_originalLast_mod_time = ConvertDEC(Reader["LAST_MOD_TIME"]),
					_originalLast_mod_user_id = Reader["LAST_MOD_USER_ID"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F112_PYCDCEILINGS_AUDIT Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F112_PYCDCEILINGS_AUDIT> Collection(ObservableCollection<F112_PYCDCEILINGS_AUDIT>
                                                               f112PycdceilingsAudit = null)
        {
            if (IsSameSearch() && f112PycdceilingsAudit != null)
            {
                return f112PycdceilingsAudit;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F112_PYCDCEILINGS_AUDIT>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("DOC_NBR",WhereDoc_nbr),
					new SqlParameter("EP_NBR",WhereEp_nbr),
					new SqlParameter("FACTOR",WhereFactor),
					new SqlParameter("DOC_PAY_CODE",WhereDoc_pay_code),
					new SqlParameter("DOC_PAY_SUB_CODE",WhereDoc_pay_sub_code),
					new SqlParameter("RETRO_TO_EP_NBR",WhereRetro_to_ep_nbr),
					new SqlParameter("DOC_YRLY_CEILING",WhereDoc_yrly_ceiling),
					new SqlParameter("DOC_YRLY_CEILING_ADJUSTED",WhereDoc_yrly_ceiling_adjusted),
					new SqlParameter("DOC_YRLY_CEILING_COMPUTED",WhereDoc_yrly_ceiling_computed),
					new SqlParameter("DOC_YRLY_EXPENSE",WhereDoc_yrly_expense),
					new SqlParameter("DOC_YRLY_EXPENSE_ADJUSTED",WhereDoc_yrly_expense_adjusted),
					new SqlParameter("DOC_YRLY_EXPENSE_COMPUTED",WhereDoc_yrly_expense_computed),
					new SqlParameter("DOC_YRLY_EXPN_ALLOC_PERS",WhereDoc_yrly_expn_alloc_pers),
					new SqlParameter("DOC_YRLY_CEIL_GUAR",WhereDoc_yrly_ceil_guar),
					new SqlParameter("DOC_YRLY_CEILING_GUAR_PERC",WhereDoc_yrly_ceiling_guar_perc),
					new SqlParameter("DOC_RMA_EXPENSE_PERCENT_REG",WhereDoc_rma_expense_percent_reg),
					new SqlParameter("DOC_RMA_EXPENSE_PERCENT_MISC",WhereDoc_rma_expense_percent_misc),
					new SqlParameter("DOC_DEPT_EXPENSE_PERCENT_REG",WhereDoc_dept_expense_percent_reg),
					new SqlParameter("DOC_DEPT_EXPENSE_PERCENT_MISC",WhereDoc_dept_expense_percent_misc),
					new SqlParameter("DOC_YRLY_REQREV",WhereDoc_yrly_reqrev),
					new SqlParameter("DOC_YRLY_REQREV_ADJUSTED",WhereDoc_yrly_reqrev_adjusted),
					new SqlParameter("DOC_YRLY_REQREV_COMPUTED",WhereDoc_yrly_reqrev_computed),
					new SqlParameter("DOC_YRLY_TARREV",WhereDoc_yrly_tarrev),
					new SqlParameter("DOC_YRLY_TARREV_ADJUSTED",WhereDoc_yrly_tarrev_adjusted),
					new SqlParameter("DOC_YRLY_TARREV_COMPUTED",WhereDoc_yrly_tarrev_computed),
					new SqlParameter("RETRO_TO_EP_NBR_REQ",WhereRetro_to_ep_nbr_req),
					new SqlParameter("RETRO_TO_EP_NBR_TAR",WhereRetro_to_ep_nbr_tar),
					new SqlParameter("LAST_MOD_FLAG",WhereLast_mod_flag),
					new SqlParameter("LAST_MOD_DATE",WhereLast_mod_date),
					new SqlParameter("LAST_MOD_TIME",WhereLast_mod_time),
					new SqlParameter("LAST_MOD_USER_ID",WhereLast_mod_user_id),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[SEQUENTIAL].[sp_F112_PYCDCEILINGS_AUDIT_Match]", parameters);
            var collection = new ObservableCollection<F112_PYCDCEILINGS_AUDIT>();

            while (Reader.Read())
            {
                collection.Add(new F112_PYCDCEILINGS_AUDIT
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					EP_NBR = ConvertDEC(Reader["EP_NBR"]),
					FACTOR = ConvertDEC(Reader["FACTOR"]),
					DOC_PAY_CODE = Reader["DOC_PAY_CODE"].ToString(),
					DOC_PAY_SUB_CODE = Reader["DOC_PAY_SUB_CODE"].ToString(),
					RETRO_TO_EP_NBR = ConvertDEC(Reader["RETRO_TO_EP_NBR"]),
					DOC_YRLY_CEILING = ConvertDEC(Reader["DOC_YRLY_CEILING"]),
					DOC_YRLY_CEILING_ADJUSTED = ConvertDEC(Reader["DOC_YRLY_CEILING_ADJUSTED"]),
					DOC_YRLY_CEILING_COMPUTED = ConvertDEC(Reader["DOC_YRLY_CEILING_COMPUTED"]),
					DOC_YRLY_EXPENSE = ConvertDEC(Reader["DOC_YRLY_EXPENSE"]),
					DOC_YRLY_EXPENSE_ADJUSTED = ConvertDEC(Reader["DOC_YRLY_EXPENSE_ADJUSTED"]),
					DOC_YRLY_EXPENSE_COMPUTED = ConvertDEC(Reader["DOC_YRLY_EXPENSE_COMPUTED"]),
					DOC_YRLY_EXPN_ALLOC_PERS = ConvertDEC(Reader["DOC_YRLY_EXPN_ALLOC_PERS"]),
					DOC_YRLY_CEIL_GUAR = ConvertDEC(Reader["DOC_YRLY_CEIL_GUAR"]),
					DOC_YRLY_CEILING_GUAR_PERC = ConvertDEC(Reader["DOC_YRLY_CEILING_GUAR_PERC"]),
					DOC_RMA_EXPENSE_PERCENT_REG = ConvertINT(Reader["DOC_RMA_EXPENSE_PERCENT_REG"]),
					DOC_RMA_EXPENSE_PERCENT_MISC = ConvertINT(Reader["DOC_RMA_EXPENSE_PERCENT_MISC"]),
					DOC_DEPT_EXPENSE_PERCENT_REG = ConvertINT(Reader["DOC_DEPT_EXPENSE_PERCENT_REG"]),
					DOC_DEPT_EXPENSE_PERCENT_MISC = ConvertINT(Reader["DOC_DEPT_EXPENSE_PERCENT_MISC"]),
					DOC_YRLY_REQREV = ConvertINT(Reader["DOC_YRLY_REQREV"]),
					DOC_YRLY_REQREV_ADJUSTED = ConvertINT(Reader["DOC_YRLY_REQREV_ADJUSTED"]),
					DOC_YRLY_REQREV_COMPUTED = ConvertDEC(Reader["DOC_YRLY_REQREV_COMPUTED"]),
					DOC_YRLY_TARREV = ConvertINT(Reader["DOC_YRLY_TARREV"]),
					DOC_YRLY_TARREV_ADJUSTED = ConvertINT(Reader["DOC_YRLY_TARREV_ADJUSTED"]),
					DOC_YRLY_TARREV_COMPUTED = Reader["DOC_YRLY_TARREV_COMPUTED"].ToString(),
					RETRO_TO_EP_NBR_REQ = ConvertDEC(Reader["RETRO_TO_EP_NBR_REQ"]),
					RETRO_TO_EP_NBR_TAR = ConvertDEC(Reader["RETRO_TO_EP_NBR_TAR"]),
					LAST_MOD_FLAG = Reader["LAST_MOD_FLAG"].ToString(),
					LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]),
					LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]),
					LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereDoc_nbr = WhereDoc_nbr,
					_whereEp_nbr = WhereEp_nbr,
					_whereFactor = WhereFactor,
					_whereDoc_pay_code = WhereDoc_pay_code,
					_whereDoc_pay_sub_code = WhereDoc_pay_sub_code,
					_whereRetro_to_ep_nbr = WhereRetro_to_ep_nbr,
					_whereDoc_yrly_ceiling = WhereDoc_yrly_ceiling,
					_whereDoc_yrly_ceiling_adjusted = WhereDoc_yrly_ceiling_adjusted,
					_whereDoc_yrly_ceiling_computed = WhereDoc_yrly_ceiling_computed,
					_whereDoc_yrly_expense = WhereDoc_yrly_expense,
					_whereDoc_yrly_expense_adjusted = WhereDoc_yrly_expense_adjusted,
					_whereDoc_yrly_expense_computed = WhereDoc_yrly_expense_computed,
					_whereDoc_yrly_expn_alloc_pers = WhereDoc_yrly_expn_alloc_pers,
					_whereDoc_yrly_ceil_guar = WhereDoc_yrly_ceil_guar,
					_whereDoc_yrly_ceiling_guar_perc = WhereDoc_yrly_ceiling_guar_perc,
					_whereDoc_rma_expense_percent_reg = WhereDoc_rma_expense_percent_reg,
					_whereDoc_rma_expense_percent_misc = WhereDoc_rma_expense_percent_misc,
					_whereDoc_dept_expense_percent_reg = WhereDoc_dept_expense_percent_reg,
					_whereDoc_dept_expense_percent_misc = WhereDoc_dept_expense_percent_misc,
					_whereDoc_yrly_reqrev = WhereDoc_yrly_reqrev,
					_whereDoc_yrly_reqrev_adjusted = WhereDoc_yrly_reqrev_adjusted,
					_whereDoc_yrly_reqrev_computed = WhereDoc_yrly_reqrev_computed,
					_whereDoc_yrly_tarrev = WhereDoc_yrly_tarrev,
					_whereDoc_yrly_tarrev_adjusted = WhereDoc_yrly_tarrev_adjusted,
					_whereDoc_yrly_tarrev_computed = WhereDoc_yrly_tarrev_computed,
					_whereRetro_to_ep_nbr_req = WhereRetro_to_ep_nbr_req,
					_whereRetro_to_ep_nbr_tar = WhereRetro_to_ep_nbr_tar,
					_whereLast_mod_flag = WhereLast_mod_flag,
					_whereLast_mod_date = WhereLast_mod_date,
					_whereLast_mod_time = WhereLast_mod_time,
					_whereLast_mod_user_id = WhereLast_mod_user_id,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalEp_nbr = ConvertDEC(Reader["EP_NBR"]),
					_originalFactor = ConvertDEC(Reader["FACTOR"]),
					_originalDoc_pay_code = Reader["DOC_PAY_CODE"].ToString(),
					_originalDoc_pay_sub_code = Reader["DOC_PAY_SUB_CODE"].ToString(),
					_originalRetro_to_ep_nbr = ConvertDEC(Reader["RETRO_TO_EP_NBR"]),
					_originalDoc_yrly_ceiling = ConvertDEC(Reader["DOC_YRLY_CEILING"]),
					_originalDoc_yrly_ceiling_adjusted = ConvertDEC(Reader["DOC_YRLY_CEILING_ADJUSTED"]),
					_originalDoc_yrly_ceiling_computed = ConvertDEC(Reader["DOC_YRLY_CEILING_COMPUTED"]),
					_originalDoc_yrly_expense = ConvertDEC(Reader["DOC_YRLY_EXPENSE"]),
					_originalDoc_yrly_expense_adjusted = ConvertDEC(Reader["DOC_YRLY_EXPENSE_ADJUSTED"]),
					_originalDoc_yrly_expense_computed = ConvertDEC(Reader["DOC_YRLY_EXPENSE_COMPUTED"]),
					_originalDoc_yrly_expn_alloc_pers = ConvertDEC(Reader["DOC_YRLY_EXPN_ALLOC_PERS"]),
					_originalDoc_yrly_ceil_guar = ConvertDEC(Reader["DOC_YRLY_CEIL_GUAR"]),
					_originalDoc_yrly_ceiling_guar_perc = ConvertDEC(Reader["DOC_YRLY_CEILING_GUAR_PERC"]),
					_originalDoc_rma_expense_percent_reg = ConvertINT(Reader["DOC_RMA_EXPENSE_PERCENT_REG"]),
					_originalDoc_rma_expense_percent_misc = ConvertINT(Reader["DOC_RMA_EXPENSE_PERCENT_MISC"]),
					_originalDoc_dept_expense_percent_reg = ConvertINT(Reader["DOC_DEPT_EXPENSE_PERCENT_REG"]),
					_originalDoc_dept_expense_percent_misc = ConvertINT(Reader["DOC_DEPT_EXPENSE_PERCENT_MISC"]),
					_originalDoc_yrly_reqrev = ConvertINT(Reader["DOC_YRLY_REQREV"]),
					_originalDoc_yrly_reqrev_adjusted = ConvertINT(Reader["DOC_YRLY_REQREV_ADJUSTED"]),
					_originalDoc_yrly_reqrev_computed = ConvertDEC(Reader["DOC_YRLY_REQREV_COMPUTED"]),
					_originalDoc_yrly_tarrev = ConvertINT(Reader["DOC_YRLY_TARREV"]),
					_originalDoc_yrly_tarrev_adjusted = ConvertINT(Reader["DOC_YRLY_TARREV_ADJUSTED"]),
					_originalDoc_yrly_tarrev_computed = Reader["DOC_YRLY_TARREV_COMPUTED"].ToString(),
					_originalRetro_to_ep_nbr_req = ConvertDEC(Reader["RETRO_TO_EP_NBR_REQ"]),
					_originalRetro_to_ep_nbr_tar = ConvertDEC(Reader["RETRO_TO_EP_NBR_TAR"]),
					_originalLast_mod_flag = Reader["LAST_MOD_FLAG"].ToString(),
					_originalLast_mod_date = ConvertDEC(Reader["LAST_MOD_DATE"]),
					_originalLast_mod_time = ConvertDEC(Reader["LAST_MOD_TIME"]),
					_originalLast_mod_user_id = Reader["LAST_MOD_USER_ID"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereDoc_nbr = WhereDoc_nbr;
					_whereEp_nbr = WhereEp_nbr;
					_whereFactor = WhereFactor;
					_whereDoc_pay_code = WhereDoc_pay_code;
					_whereDoc_pay_sub_code = WhereDoc_pay_sub_code;
					_whereRetro_to_ep_nbr = WhereRetro_to_ep_nbr;
					_whereDoc_yrly_ceiling = WhereDoc_yrly_ceiling;
					_whereDoc_yrly_ceiling_adjusted = WhereDoc_yrly_ceiling_adjusted;
					_whereDoc_yrly_ceiling_computed = WhereDoc_yrly_ceiling_computed;
					_whereDoc_yrly_expense = WhereDoc_yrly_expense;
					_whereDoc_yrly_expense_adjusted = WhereDoc_yrly_expense_adjusted;
					_whereDoc_yrly_expense_computed = WhereDoc_yrly_expense_computed;
					_whereDoc_yrly_expn_alloc_pers = WhereDoc_yrly_expn_alloc_pers;
					_whereDoc_yrly_ceil_guar = WhereDoc_yrly_ceil_guar;
					_whereDoc_yrly_ceiling_guar_perc = WhereDoc_yrly_ceiling_guar_perc;
					_whereDoc_rma_expense_percent_reg = WhereDoc_rma_expense_percent_reg;
					_whereDoc_rma_expense_percent_misc = WhereDoc_rma_expense_percent_misc;
					_whereDoc_dept_expense_percent_reg = WhereDoc_dept_expense_percent_reg;
					_whereDoc_dept_expense_percent_misc = WhereDoc_dept_expense_percent_misc;
					_whereDoc_yrly_reqrev = WhereDoc_yrly_reqrev;
					_whereDoc_yrly_reqrev_adjusted = WhereDoc_yrly_reqrev_adjusted;
					_whereDoc_yrly_reqrev_computed = WhereDoc_yrly_reqrev_computed;
					_whereDoc_yrly_tarrev = WhereDoc_yrly_tarrev;
					_whereDoc_yrly_tarrev_adjusted = WhereDoc_yrly_tarrev_adjusted;
					_whereDoc_yrly_tarrev_computed = WhereDoc_yrly_tarrev_computed;
					_whereRetro_to_ep_nbr_req = WhereRetro_to_ep_nbr_req;
					_whereRetro_to_ep_nbr_tar = WhereRetro_to_ep_nbr_tar;
					_whereLast_mod_flag = WhereLast_mod_flag;
					_whereLast_mod_date = WhereLast_mod_date;
					_whereLast_mod_time = WhereLast_mod_time;
					_whereLast_mod_user_id = WhereLast_mod_user_id;
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
				&& WhereFactor == null 
				&& WhereDoc_pay_code == null 
				&& WhereDoc_pay_sub_code == null 
				&& WhereRetro_to_ep_nbr == null 
				&& WhereDoc_yrly_ceiling == null 
				&& WhereDoc_yrly_ceiling_adjusted == null 
				&& WhereDoc_yrly_ceiling_computed == null 
				&& WhereDoc_yrly_expense == null 
				&& WhereDoc_yrly_expense_adjusted == null 
				&& WhereDoc_yrly_expense_computed == null 
				&& WhereDoc_yrly_expn_alloc_pers == null 
				&& WhereDoc_yrly_ceil_guar == null 
				&& WhereDoc_yrly_ceiling_guar_perc == null 
				&& WhereDoc_rma_expense_percent_reg == null 
				&& WhereDoc_rma_expense_percent_misc == null 
				&& WhereDoc_dept_expense_percent_reg == null 
				&& WhereDoc_dept_expense_percent_misc == null 
				&& WhereDoc_yrly_reqrev == null 
				&& WhereDoc_yrly_reqrev_adjusted == null 
				&& WhereDoc_yrly_reqrev_computed == null 
				&& WhereDoc_yrly_tarrev == null 
				&& WhereDoc_yrly_tarrev_adjusted == null 
				&& WhereDoc_yrly_tarrev_computed == null 
				&& WhereRetro_to_ep_nbr_req == null 
				&& WhereRetro_to_ep_nbr_tar == null 
				&& WhereLast_mod_flag == null 
				&& WhereLast_mod_date == null 
				&& WhereLast_mod_time == null 
				&& WhereLast_mod_user_id == null 
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
				&& WhereFactor ==  _whereFactor
				&& WhereDoc_pay_code ==  _whereDoc_pay_code
				&& WhereDoc_pay_sub_code ==  _whereDoc_pay_sub_code
				&& WhereRetro_to_ep_nbr ==  _whereRetro_to_ep_nbr
				&& WhereDoc_yrly_ceiling ==  _whereDoc_yrly_ceiling
				&& WhereDoc_yrly_ceiling_adjusted ==  _whereDoc_yrly_ceiling_adjusted
				&& WhereDoc_yrly_ceiling_computed ==  _whereDoc_yrly_ceiling_computed
				&& WhereDoc_yrly_expense ==  _whereDoc_yrly_expense
				&& WhereDoc_yrly_expense_adjusted ==  _whereDoc_yrly_expense_adjusted
				&& WhereDoc_yrly_expense_computed ==  _whereDoc_yrly_expense_computed
				&& WhereDoc_yrly_expn_alloc_pers ==  _whereDoc_yrly_expn_alloc_pers
				&& WhereDoc_yrly_ceil_guar ==  _whereDoc_yrly_ceil_guar
				&& WhereDoc_yrly_ceiling_guar_perc ==  _whereDoc_yrly_ceiling_guar_perc
				&& WhereDoc_rma_expense_percent_reg ==  _whereDoc_rma_expense_percent_reg
				&& WhereDoc_rma_expense_percent_misc ==  _whereDoc_rma_expense_percent_misc
				&& WhereDoc_dept_expense_percent_reg ==  _whereDoc_dept_expense_percent_reg
				&& WhereDoc_dept_expense_percent_misc ==  _whereDoc_dept_expense_percent_misc
				&& WhereDoc_yrly_reqrev ==  _whereDoc_yrly_reqrev
				&& WhereDoc_yrly_reqrev_adjusted ==  _whereDoc_yrly_reqrev_adjusted
				&& WhereDoc_yrly_reqrev_computed ==  _whereDoc_yrly_reqrev_computed
				&& WhereDoc_yrly_tarrev ==  _whereDoc_yrly_tarrev
				&& WhereDoc_yrly_tarrev_adjusted ==  _whereDoc_yrly_tarrev_adjusted
				&& WhereDoc_yrly_tarrev_computed ==  _whereDoc_yrly_tarrev_computed
				&& WhereRetro_to_ep_nbr_req ==  _whereRetro_to_ep_nbr_req
				&& WhereRetro_to_ep_nbr_tar ==  _whereRetro_to_ep_nbr_tar
				&& WhereLast_mod_flag ==  _whereLast_mod_flag
				&& WhereLast_mod_date ==  _whereLast_mod_date
				&& WhereLast_mod_time ==  _whereLast_mod_time
				&& WhereLast_mod_user_id ==  _whereLast_mod_user_id
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereDoc_nbr = null; 
			WhereEp_nbr = null; 
			WhereFactor = null; 
			WhereDoc_pay_code = null; 
			WhereDoc_pay_sub_code = null; 
			WhereRetro_to_ep_nbr = null; 
			WhereDoc_yrly_ceiling = null; 
			WhereDoc_yrly_ceiling_adjusted = null; 
			WhereDoc_yrly_ceiling_computed = null; 
			WhereDoc_yrly_expense = null; 
			WhereDoc_yrly_expense_adjusted = null; 
			WhereDoc_yrly_expense_computed = null; 
			WhereDoc_yrly_expn_alloc_pers = null; 
			WhereDoc_yrly_ceil_guar = null; 
			WhereDoc_yrly_ceiling_guar_perc = null; 
			WhereDoc_rma_expense_percent_reg = null; 
			WhereDoc_rma_expense_percent_misc = null; 
			WhereDoc_dept_expense_percent_reg = null; 
			WhereDoc_dept_expense_percent_misc = null; 
			WhereDoc_yrly_reqrev = null; 
			WhereDoc_yrly_reqrev_adjusted = null; 
			WhereDoc_yrly_reqrev_computed = null; 
			WhereDoc_yrly_tarrev = null; 
			WhereDoc_yrly_tarrev_adjusted = null; 
			WhereDoc_yrly_tarrev_computed = null; 
			WhereRetro_to_ep_nbr_req = null; 
			WhereRetro_to_ep_nbr_tar = null; 
			WhereLast_mod_flag = null; 
			WhereLast_mod_date = null; 
			WhereLast_mod_time = null; 
			WhereLast_mod_user_id = null; 
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
		private decimal? _FACTOR;
		private string _DOC_PAY_CODE;
		private string _DOC_PAY_SUB_CODE;
		private decimal? _RETRO_TO_EP_NBR;
		private decimal? _DOC_YRLY_CEILING;
		private decimal? _DOC_YRLY_CEILING_ADJUSTED;
		private decimal? _DOC_YRLY_CEILING_COMPUTED;
		private decimal? _DOC_YRLY_EXPENSE;
		private decimal? _DOC_YRLY_EXPENSE_ADJUSTED;
		private decimal? _DOC_YRLY_EXPENSE_COMPUTED;
		private decimal? _DOC_YRLY_EXPN_ALLOC_PERS;
		private decimal? _DOC_YRLY_CEIL_GUAR;
		private decimal? _DOC_YRLY_CEILING_GUAR_PERC;
		private int? _DOC_RMA_EXPENSE_PERCENT_REG;
		private int? _DOC_RMA_EXPENSE_PERCENT_MISC;
		private int? _DOC_DEPT_EXPENSE_PERCENT_REG;
		private int? _DOC_DEPT_EXPENSE_PERCENT_MISC;
		private int? _DOC_YRLY_REQREV;
		private int? _DOC_YRLY_REQREV_ADJUSTED;
		private decimal? _DOC_YRLY_REQREV_COMPUTED;
		private int? _DOC_YRLY_TARREV;
		private int? _DOC_YRLY_TARREV_ADJUSTED;
		private string _DOC_YRLY_TARREV_COMPUTED;
		private decimal? _RETRO_TO_EP_NBR_REQ;
		private decimal? _RETRO_TO_EP_NBR_TAR;
		private string _LAST_MOD_FLAG;
		private decimal? _LAST_MOD_DATE;
		private decimal? _LAST_MOD_TIME;
		private string _LAST_MOD_USER_ID;
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
		public decimal? FACTOR
		{
			get { return _FACTOR; }
			set
			{
				if (_FACTOR != value)
				{
					_FACTOR = value;
					ChangeState();
				}
			}
		}
		public string DOC_PAY_CODE
		{
			get { return _DOC_PAY_CODE; }
			set
			{
				if (_DOC_PAY_CODE != value)
				{
					_DOC_PAY_CODE = value;
					ChangeState();
				}
			}
		}
		public string DOC_PAY_SUB_CODE
		{
			get { return _DOC_PAY_SUB_CODE; }
			set
			{
				if (_DOC_PAY_SUB_CODE != value)
				{
					_DOC_PAY_SUB_CODE = value;
					ChangeState();
				}
			}
		}
		public decimal? RETRO_TO_EP_NBR
		{
			get { return _RETRO_TO_EP_NBR; }
			set
			{
				if (_RETRO_TO_EP_NBR != value)
				{
					_RETRO_TO_EP_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_YRLY_CEILING
		{
			get { return _DOC_YRLY_CEILING; }
			set
			{
				if (_DOC_YRLY_CEILING != value)
				{
					_DOC_YRLY_CEILING = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_YRLY_CEILING_ADJUSTED
		{
			get { return _DOC_YRLY_CEILING_ADJUSTED; }
			set
			{
				if (_DOC_YRLY_CEILING_ADJUSTED != value)
				{
					_DOC_YRLY_CEILING_ADJUSTED = value;
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
		public decimal? DOC_YRLY_EXPENSE
		{
			get { return _DOC_YRLY_EXPENSE; }
			set
			{
				if (_DOC_YRLY_EXPENSE != value)
				{
					_DOC_YRLY_EXPENSE = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_YRLY_EXPENSE_ADJUSTED
		{
			get { return _DOC_YRLY_EXPENSE_ADJUSTED; }
			set
			{
				if (_DOC_YRLY_EXPENSE_ADJUSTED != value)
				{
					_DOC_YRLY_EXPENSE_ADJUSTED = value;
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
		public decimal? DOC_YRLY_EXPN_ALLOC_PERS
		{
			get { return _DOC_YRLY_EXPN_ALLOC_PERS; }
			set
			{
				if (_DOC_YRLY_EXPN_ALLOC_PERS != value)
				{
					_DOC_YRLY_EXPN_ALLOC_PERS = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_YRLY_CEIL_GUAR
		{
			get { return _DOC_YRLY_CEIL_GUAR; }
			set
			{
				if (_DOC_YRLY_CEIL_GUAR != value)
				{
					_DOC_YRLY_CEIL_GUAR = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_YRLY_CEILING_GUAR_PERC
		{
			get { return _DOC_YRLY_CEILING_GUAR_PERC; }
			set
			{
				if (_DOC_YRLY_CEILING_GUAR_PERC != value)
				{
					_DOC_YRLY_CEILING_GUAR_PERC = value;
					ChangeState();
				}
			}
		}
		public int? DOC_RMA_EXPENSE_PERCENT_REG
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
		public int? DOC_RMA_EXPENSE_PERCENT_MISC
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
		public int? DOC_DEPT_EXPENSE_PERCENT_REG
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
		public int? DOC_DEPT_EXPENSE_PERCENT_MISC
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
		public int? DOC_YRLY_REQREV
		{
			get { return _DOC_YRLY_REQREV; }
			set
			{
				if (_DOC_YRLY_REQREV != value)
				{
					_DOC_YRLY_REQREV = value;
					ChangeState();
				}
			}
		}
		public int? DOC_YRLY_REQREV_ADJUSTED
		{
			get { return _DOC_YRLY_REQREV_ADJUSTED; }
			set
			{
				if (_DOC_YRLY_REQREV_ADJUSTED != value)
				{
					_DOC_YRLY_REQREV_ADJUSTED = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_YRLY_REQREV_COMPUTED
		{
			get { return _DOC_YRLY_REQREV_COMPUTED; }
			set
			{
				if (_DOC_YRLY_REQREV_COMPUTED != value)
				{
					_DOC_YRLY_REQREV_COMPUTED = value;
					ChangeState();
				}
			}
		}
		public int? DOC_YRLY_TARREV
		{
			get { return _DOC_YRLY_TARREV; }
			set
			{
				if (_DOC_YRLY_TARREV != value)
				{
					_DOC_YRLY_TARREV = value;
					ChangeState();
				}
			}
		}
		public int? DOC_YRLY_TARREV_ADJUSTED
		{
			get { return _DOC_YRLY_TARREV_ADJUSTED; }
			set
			{
				if (_DOC_YRLY_TARREV_ADJUSTED != value)
				{
					_DOC_YRLY_TARREV_ADJUSTED = value;
					ChangeState();
				}
			}
		}
		public string DOC_YRLY_TARREV_COMPUTED
		{
			get { return _DOC_YRLY_TARREV_COMPUTED; }
			set
			{
				if (_DOC_YRLY_TARREV_COMPUTED != value)
				{
					_DOC_YRLY_TARREV_COMPUTED = value;
					ChangeState();
				}
			}
		}
		public decimal? RETRO_TO_EP_NBR_REQ
		{
			get { return _RETRO_TO_EP_NBR_REQ; }
			set
			{
				if (_RETRO_TO_EP_NBR_REQ != value)
				{
					_RETRO_TO_EP_NBR_REQ = value;
					ChangeState();
				}
			}
		}
		public decimal? RETRO_TO_EP_NBR_TAR
		{
			get { return _RETRO_TO_EP_NBR_TAR; }
			set
			{
				if (_RETRO_TO_EP_NBR_TAR != value)
				{
					_RETRO_TO_EP_NBR_TAR = value;
					ChangeState();
				}
			}
		}
		public string LAST_MOD_FLAG
		{
			get { return _LAST_MOD_FLAG; }
			set
			{
				if (_LAST_MOD_FLAG != value)
				{
					_LAST_MOD_FLAG = value;
					ChangeState();
				}
			}
		}
		public decimal? LAST_MOD_DATE
		{
			get { return _LAST_MOD_DATE; }
			set
			{
				if (_LAST_MOD_DATE != value)
				{
					_LAST_MOD_DATE = value;
					ChangeState();
				}
			}
		}
		public decimal? LAST_MOD_TIME
		{
			get { return _LAST_MOD_TIME; }
			set
			{
				if (_LAST_MOD_TIME != value)
				{
					_LAST_MOD_TIME = value;
					ChangeState();
				}
			}
		}
		public string LAST_MOD_USER_ID
		{
			get { return _LAST_MOD_USER_ID; }
			set
			{
				if (_LAST_MOD_USER_ID != value)
				{
					_LAST_MOD_USER_ID = value;
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
		public decimal? WhereFactor { get; set; }
		private decimal? _whereFactor;
		public string WhereDoc_pay_code { get; set; }
		private string _whereDoc_pay_code;
		public string WhereDoc_pay_sub_code { get; set; }
		private string _whereDoc_pay_sub_code;
		public decimal? WhereRetro_to_ep_nbr { get; set; }
		private decimal? _whereRetro_to_ep_nbr;
		public decimal? WhereDoc_yrly_ceiling { get; set; }
		private decimal? _whereDoc_yrly_ceiling;
		public decimal? WhereDoc_yrly_ceiling_adjusted { get; set; }
		private decimal? _whereDoc_yrly_ceiling_adjusted;
		public decimal? WhereDoc_yrly_ceiling_computed { get; set; }
		private decimal? _whereDoc_yrly_ceiling_computed;
		public decimal? WhereDoc_yrly_expense { get; set; }
		private decimal? _whereDoc_yrly_expense;
		public decimal? WhereDoc_yrly_expense_adjusted { get; set; }
		private decimal? _whereDoc_yrly_expense_adjusted;
		public decimal? WhereDoc_yrly_expense_computed { get; set; }
		private decimal? _whereDoc_yrly_expense_computed;
		public decimal? WhereDoc_yrly_expn_alloc_pers { get; set; }
		private decimal? _whereDoc_yrly_expn_alloc_pers;
		public decimal? WhereDoc_yrly_ceil_guar { get; set; }
		private decimal? _whereDoc_yrly_ceil_guar;
		public decimal? WhereDoc_yrly_ceiling_guar_perc { get; set; }
		private decimal? _whereDoc_yrly_ceiling_guar_perc;
		public int? WhereDoc_rma_expense_percent_reg { get; set; }
		private int? _whereDoc_rma_expense_percent_reg;
		public int? WhereDoc_rma_expense_percent_misc { get; set; }
		private int? _whereDoc_rma_expense_percent_misc;
		public int? WhereDoc_dept_expense_percent_reg { get; set; }
		private int? _whereDoc_dept_expense_percent_reg;
		public int? WhereDoc_dept_expense_percent_misc { get; set; }
		private int? _whereDoc_dept_expense_percent_misc;
		public int? WhereDoc_yrly_reqrev { get; set; }
		private int? _whereDoc_yrly_reqrev;
		public int? WhereDoc_yrly_reqrev_adjusted { get; set; }
		private int? _whereDoc_yrly_reqrev_adjusted;
		public decimal? WhereDoc_yrly_reqrev_computed { get; set; }
		private decimal? _whereDoc_yrly_reqrev_computed;
		public int? WhereDoc_yrly_tarrev { get; set; }
		private int? _whereDoc_yrly_tarrev;
		public int? WhereDoc_yrly_tarrev_adjusted { get; set; }
		private int? _whereDoc_yrly_tarrev_adjusted;
		public string WhereDoc_yrly_tarrev_computed { get; set; }
		private string _whereDoc_yrly_tarrev_computed;
		public decimal? WhereRetro_to_ep_nbr_req { get; set; }
		private decimal? _whereRetro_to_ep_nbr_req;
		public decimal? WhereRetro_to_ep_nbr_tar { get; set; }
		private decimal? _whereRetro_to_ep_nbr_tar;
		public string WhereLast_mod_flag { get; set; }
		private string _whereLast_mod_flag;
		public decimal? WhereLast_mod_date { get; set; }
		private decimal? _whereLast_mod_date;
		public decimal? WhereLast_mod_time { get; set; }
		private decimal? _whereLast_mod_time;
		public string WhereLast_mod_user_id { get; set; }
		private string _whereLast_mod_user_id;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalDoc_nbr;
		private decimal? _originalEp_nbr;
		private decimal? _originalFactor;
		private string _originalDoc_pay_code;
		private string _originalDoc_pay_sub_code;
		private decimal? _originalRetro_to_ep_nbr;
		private decimal? _originalDoc_yrly_ceiling;
		private decimal? _originalDoc_yrly_ceiling_adjusted;
		private decimal? _originalDoc_yrly_ceiling_computed;
		private decimal? _originalDoc_yrly_expense;
		private decimal? _originalDoc_yrly_expense_adjusted;
		private decimal? _originalDoc_yrly_expense_computed;
		private decimal? _originalDoc_yrly_expn_alloc_pers;
		private decimal? _originalDoc_yrly_ceil_guar;
		private decimal? _originalDoc_yrly_ceiling_guar_perc;
		private int? _originalDoc_rma_expense_percent_reg;
		private int? _originalDoc_rma_expense_percent_misc;
		private int? _originalDoc_dept_expense_percent_reg;
		private int? _originalDoc_dept_expense_percent_misc;
		private int? _originalDoc_yrly_reqrev;
		private int? _originalDoc_yrly_reqrev_adjusted;
		private decimal? _originalDoc_yrly_reqrev_computed;
		private int? _originalDoc_yrly_tarrev;
		private int? _originalDoc_yrly_tarrev_adjusted;
		private string _originalDoc_yrly_tarrev_computed;
		private decimal? _originalRetro_to_ep_nbr_req;
		private decimal? _originalRetro_to_ep_nbr_tar;
		private string _originalLast_mod_flag;
		private decimal? _originalLast_mod_date;
		private decimal? _originalLast_mod_time;
		private string _originalLast_mod_user_id;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			DOC_NBR = _originalDoc_nbr;
			EP_NBR = _originalEp_nbr;
			FACTOR = _originalFactor;
			DOC_PAY_CODE = _originalDoc_pay_code;
			DOC_PAY_SUB_CODE = _originalDoc_pay_sub_code;
			RETRO_TO_EP_NBR = _originalRetro_to_ep_nbr;
			DOC_YRLY_CEILING = _originalDoc_yrly_ceiling;
			DOC_YRLY_CEILING_ADJUSTED = _originalDoc_yrly_ceiling_adjusted;
			DOC_YRLY_CEILING_COMPUTED = _originalDoc_yrly_ceiling_computed;
			DOC_YRLY_EXPENSE = _originalDoc_yrly_expense;
			DOC_YRLY_EXPENSE_ADJUSTED = _originalDoc_yrly_expense_adjusted;
			DOC_YRLY_EXPENSE_COMPUTED = _originalDoc_yrly_expense_computed;
			DOC_YRLY_EXPN_ALLOC_PERS = _originalDoc_yrly_expn_alloc_pers;
			DOC_YRLY_CEIL_GUAR = _originalDoc_yrly_ceil_guar;
			DOC_YRLY_CEILING_GUAR_PERC = _originalDoc_yrly_ceiling_guar_perc;
			DOC_RMA_EXPENSE_PERCENT_REG = _originalDoc_rma_expense_percent_reg;
			DOC_RMA_EXPENSE_PERCENT_MISC = _originalDoc_rma_expense_percent_misc;
			DOC_DEPT_EXPENSE_PERCENT_REG = _originalDoc_dept_expense_percent_reg;
			DOC_DEPT_EXPENSE_PERCENT_MISC = _originalDoc_dept_expense_percent_misc;
			DOC_YRLY_REQREV = _originalDoc_yrly_reqrev;
			DOC_YRLY_REQREV_ADJUSTED = _originalDoc_yrly_reqrev_adjusted;
			DOC_YRLY_REQREV_COMPUTED = _originalDoc_yrly_reqrev_computed;
			DOC_YRLY_TARREV = _originalDoc_yrly_tarrev;
			DOC_YRLY_TARREV_ADJUSTED = _originalDoc_yrly_tarrev_adjusted;
			DOC_YRLY_TARREV_COMPUTED = _originalDoc_yrly_tarrev_computed;
			RETRO_TO_EP_NBR_REQ = _originalRetro_to_ep_nbr_req;
			RETRO_TO_EP_NBR_TAR = _originalRetro_to_ep_nbr_tar;
			LAST_MOD_FLAG = _originalLast_mod_flag;
			LAST_MOD_DATE = _originalLast_mod_date;
			LAST_MOD_TIME = _originalLast_mod_time;
			LAST_MOD_USER_ID = _originalLast_mod_user_id;
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
			RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_F112_PYCDCEILINGS_AUDIT_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_F112_PYCDCEILINGS_AUDIT_Purge]");
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
						new SqlParameter("FACTOR", SqlNull(FACTOR)),
						new SqlParameter("DOC_PAY_CODE", SqlNull(DOC_PAY_CODE)),
						new SqlParameter("DOC_PAY_SUB_CODE", SqlNull(DOC_PAY_SUB_CODE)),
						new SqlParameter("RETRO_TO_EP_NBR", SqlNull(RETRO_TO_EP_NBR)),
						new SqlParameter("DOC_YRLY_CEILING", SqlNull(DOC_YRLY_CEILING)),
						new SqlParameter("DOC_YRLY_CEILING_ADJUSTED", SqlNull(DOC_YRLY_CEILING_ADJUSTED)),
						new SqlParameter("DOC_YRLY_CEILING_COMPUTED", SqlNull(DOC_YRLY_CEILING_COMPUTED)),
						new SqlParameter("DOC_YRLY_EXPENSE", SqlNull(DOC_YRLY_EXPENSE)),
						new SqlParameter("DOC_YRLY_EXPENSE_ADJUSTED", SqlNull(DOC_YRLY_EXPENSE_ADJUSTED)),
						new SqlParameter("DOC_YRLY_EXPENSE_COMPUTED", SqlNull(DOC_YRLY_EXPENSE_COMPUTED)),
						new SqlParameter("DOC_YRLY_EXPN_ALLOC_PERS", SqlNull(DOC_YRLY_EXPN_ALLOC_PERS)),
						new SqlParameter("DOC_YRLY_CEIL_GUAR", SqlNull(DOC_YRLY_CEIL_GUAR)),
						new SqlParameter("DOC_YRLY_CEILING_GUAR_PERC", SqlNull(DOC_YRLY_CEILING_GUAR_PERC)),
						new SqlParameter("DOC_RMA_EXPENSE_PERCENT_REG", SqlNull(DOC_RMA_EXPENSE_PERCENT_REG)),
						new SqlParameter("DOC_RMA_EXPENSE_PERCENT_MISC", SqlNull(DOC_RMA_EXPENSE_PERCENT_MISC)),
						new SqlParameter("DOC_DEPT_EXPENSE_PERCENT_REG", SqlNull(DOC_DEPT_EXPENSE_PERCENT_REG)),
						new SqlParameter("DOC_DEPT_EXPENSE_PERCENT_MISC", SqlNull(DOC_DEPT_EXPENSE_PERCENT_MISC)),
						new SqlParameter("DOC_YRLY_REQREV", SqlNull(DOC_YRLY_REQREV)),
						new SqlParameter("DOC_YRLY_REQREV_ADJUSTED", SqlNull(DOC_YRLY_REQREV_ADJUSTED)),
						new SqlParameter("DOC_YRLY_REQREV_COMPUTED", SqlNull(DOC_YRLY_REQREV_COMPUTED)),
						new SqlParameter("DOC_YRLY_TARREV", SqlNull(DOC_YRLY_TARREV)),
						new SqlParameter("DOC_YRLY_TARREV_ADJUSTED", SqlNull(DOC_YRLY_TARREV_ADJUSTED)),
						new SqlParameter("DOC_YRLY_TARREV_COMPUTED", SqlNull(DOC_YRLY_TARREV_COMPUTED)),
						new SqlParameter("RETRO_TO_EP_NBR_REQ", SqlNull(RETRO_TO_EP_NBR_REQ)),
						new SqlParameter("RETRO_TO_EP_NBR_TAR", SqlNull(RETRO_TO_EP_NBR_TAR)),
						new SqlParameter("LAST_MOD_FLAG", SqlNull(LAST_MOD_FLAG)),
						new SqlParameter("LAST_MOD_DATE", SqlNull(LAST_MOD_DATE)),
						new SqlParameter("LAST_MOD_TIME", SqlNull(LAST_MOD_TIME)),
						new SqlParameter("LAST_MOD_USER_ID", SqlNull(LAST_MOD_USER_ID)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_F112_PYCDCEILINGS_AUDIT_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOC_NBR = Reader["DOC_NBR"].ToString();
						EP_NBR = ConvertDEC(Reader["EP_NBR"]);
						FACTOR = ConvertDEC(Reader["FACTOR"]);
						DOC_PAY_CODE = Reader["DOC_PAY_CODE"].ToString();
						DOC_PAY_SUB_CODE = Reader["DOC_PAY_SUB_CODE"].ToString();
						RETRO_TO_EP_NBR = ConvertDEC(Reader["RETRO_TO_EP_NBR"]);
						DOC_YRLY_CEILING = ConvertDEC(Reader["DOC_YRLY_CEILING"]);
						DOC_YRLY_CEILING_ADJUSTED = ConvertDEC(Reader["DOC_YRLY_CEILING_ADJUSTED"]);
						DOC_YRLY_CEILING_COMPUTED = ConvertDEC(Reader["DOC_YRLY_CEILING_COMPUTED"]);
						DOC_YRLY_EXPENSE = ConvertDEC(Reader["DOC_YRLY_EXPENSE"]);
						DOC_YRLY_EXPENSE_ADJUSTED = ConvertDEC(Reader["DOC_YRLY_EXPENSE_ADJUSTED"]);
						DOC_YRLY_EXPENSE_COMPUTED = ConvertDEC(Reader["DOC_YRLY_EXPENSE_COMPUTED"]);
						DOC_YRLY_EXPN_ALLOC_PERS = ConvertDEC(Reader["DOC_YRLY_EXPN_ALLOC_PERS"]);
						DOC_YRLY_CEIL_GUAR = ConvertDEC(Reader["DOC_YRLY_CEIL_GUAR"]);
						DOC_YRLY_CEILING_GUAR_PERC = ConvertDEC(Reader["DOC_YRLY_CEILING_GUAR_PERC"]);
						DOC_RMA_EXPENSE_PERCENT_REG = ConvertINT(Reader["DOC_RMA_EXPENSE_PERCENT_REG"]);
						DOC_RMA_EXPENSE_PERCENT_MISC = ConvertINT(Reader["DOC_RMA_EXPENSE_PERCENT_MISC"]);
						DOC_DEPT_EXPENSE_PERCENT_REG = ConvertINT(Reader["DOC_DEPT_EXPENSE_PERCENT_REG"]);
						DOC_DEPT_EXPENSE_PERCENT_MISC = ConvertINT(Reader["DOC_DEPT_EXPENSE_PERCENT_MISC"]);
						DOC_YRLY_REQREV = ConvertINT(Reader["DOC_YRLY_REQREV"]);
						DOC_YRLY_REQREV_ADJUSTED = ConvertINT(Reader["DOC_YRLY_REQREV_ADJUSTED"]);
						DOC_YRLY_REQREV_COMPUTED = ConvertDEC(Reader["DOC_YRLY_REQREV_COMPUTED"]);
						DOC_YRLY_TARREV = ConvertINT(Reader["DOC_YRLY_TARREV"]);
						DOC_YRLY_TARREV_ADJUSTED = ConvertINT(Reader["DOC_YRLY_TARREV_ADJUSTED"]);
						DOC_YRLY_TARREV_COMPUTED = Reader["DOC_YRLY_TARREV_COMPUTED"].ToString();
						RETRO_TO_EP_NBR_REQ = ConvertDEC(Reader["RETRO_TO_EP_NBR_REQ"]);
						RETRO_TO_EP_NBR_TAR = ConvertDEC(Reader["RETRO_TO_EP_NBR_TAR"]);
						LAST_MOD_FLAG = Reader["LAST_MOD_FLAG"].ToString();
						LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]);
						LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]);
						LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalEp_nbr = ConvertDEC(Reader["EP_NBR"]);
						_originalFactor = ConvertDEC(Reader["FACTOR"]);
						_originalDoc_pay_code = Reader["DOC_PAY_CODE"].ToString();
						_originalDoc_pay_sub_code = Reader["DOC_PAY_SUB_CODE"].ToString();
						_originalRetro_to_ep_nbr = ConvertDEC(Reader["RETRO_TO_EP_NBR"]);
						_originalDoc_yrly_ceiling = ConvertDEC(Reader["DOC_YRLY_CEILING"]);
						_originalDoc_yrly_ceiling_adjusted = ConvertDEC(Reader["DOC_YRLY_CEILING_ADJUSTED"]);
						_originalDoc_yrly_ceiling_computed = ConvertDEC(Reader["DOC_YRLY_CEILING_COMPUTED"]);
						_originalDoc_yrly_expense = ConvertDEC(Reader["DOC_YRLY_EXPENSE"]);
						_originalDoc_yrly_expense_adjusted = ConvertDEC(Reader["DOC_YRLY_EXPENSE_ADJUSTED"]);
						_originalDoc_yrly_expense_computed = ConvertDEC(Reader["DOC_YRLY_EXPENSE_COMPUTED"]);
						_originalDoc_yrly_expn_alloc_pers = ConvertDEC(Reader["DOC_YRLY_EXPN_ALLOC_PERS"]);
						_originalDoc_yrly_ceil_guar = ConvertDEC(Reader["DOC_YRLY_CEIL_GUAR"]);
						_originalDoc_yrly_ceiling_guar_perc = ConvertDEC(Reader["DOC_YRLY_CEILING_GUAR_PERC"]);
						_originalDoc_rma_expense_percent_reg = ConvertINT(Reader["DOC_RMA_EXPENSE_PERCENT_REG"]);
						_originalDoc_rma_expense_percent_misc = ConvertINT(Reader["DOC_RMA_EXPENSE_PERCENT_MISC"]);
						_originalDoc_dept_expense_percent_reg = ConvertINT(Reader["DOC_DEPT_EXPENSE_PERCENT_REG"]);
						_originalDoc_dept_expense_percent_misc = ConvertINT(Reader["DOC_DEPT_EXPENSE_PERCENT_MISC"]);
						_originalDoc_yrly_reqrev = ConvertINT(Reader["DOC_YRLY_REQREV"]);
						_originalDoc_yrly_reqrev_adjusted = ConvertINT(Reader["DOC_YRLY_REQREV_ADJUSTED"]);
						_originalDoc_yrly_reqrev_computed = ConvertDEC(Reader["DOC_YRLY_REQREV_COMPUTED"]);
						_originalDoc_yrly_tarrev = ConvertINT(Reader["DOC_YRLY_TARREV"]);
						_originalDoc_yrly_tarrev_adjusted = ConvertINT(Reader["DOC_YRLY_TARREV_ADJUSTED"]);
						_originalDoc_yrly_tarrev_computed = Reader["DOC_YRLY_TARREV_COMPUTED"].ToString();
						_originalRetro_to_ep_nbr_req = ConvertDEC(Reader["RETRO_TO_EP_NBR_REQ"]);
						_originalRetro_to_ep_nbr_tar = ConvertDEC(Reader["RETRO_TO_EP_NBR_TAR"]);
						_originalLast_mod_flag = Reader["LAST_MOD_FLAG"].ToString();
						_originalLast_mod_date = ConvertDEC(Reader["LAST_MOD_DATE"]);
						_originalLast_mod_time = ConvertDEC(Reader["LAST_MOD_TIME"]);
						_originalLast_mod_user_id = Reader["LAST_MOD_USER_ID"].ToString();
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
						new SqlParameter("FACTOR", SqlNull(FACTOR)),
						new SqlParameter("DOC_PAY_CODE", SqlNull(DOC_PAY_CODE)),
						new SqlParameter("DOC_PAY_SUB_CODE", SqlNull(DOC_PAY_SUB_CODE)),
						new SqlParameter("RETRO_TO_EP_NBR", SqlNull(RETRO_TO_EP_NBR)),
						new SqlParameter("DOC_YRLY_CEILING", SqlNull(DOC_YRLY_CEILING)),
						new SqlParameter("DOC_YRLY_CEILING_ADJUSTED", SqlNull(DOC_YRLY_CEILING_ADJUSTED)),
						new SqlParameter("DOC_YRLY_CEILING_COMPUTED", SqlNull(DOC_YRLY_CEILING_COMPUTED)),
						new SqlParameter("DOC_YRLY_EXPENSE", SqlNull(DOC_YRLY_EXPENSE)),
						new SqlParameter("DOC_YRLY_EXPENSE_ADJUSTED", SqlNull(DOC_YRLY_EXPENSE_ADJUSTED)),
						new SqlParameter("DOC_YRLY_EXPENSE_COMPUTED", SqlNull(DOC_YRLY_EXPENSE_COMPUTED)),
						new SqlParameter("DOC_YRLY_EXPN_ALLOC_PERS", SqlNull(DOC_YRLY_EXPN_ALLOC_PERS)),
						new SqlParameter("DOC_YRLY_CEIL_GUAR", SqlNull(DOC_YRLY_CEIL_GUAR)),
						new SqlParameter("DOC_YRLY_CEILING_GUAR_PERC", SqlNull(DOC_YRLY_CEILING_GUAR_PERC)),
						new SqlParameter("DOC_RMA_EXPENSE_PERCENT_REG", SqlNull(DOC_RMA_EXPENSE_PERCENT_REG)),
						new SqlParameter("DOC_RMA_EXPENSE_PERCENT_MISC", SqlNull(DOC_RMA_EXPENSE_PERCENT_MISC)),
						new SqlParameter("DOC_DEPT_EXPENSE_PERCENT_REG", SqlNull(DOC_DEPT_EXPENSE_PERCENT_REG)),
						new SqlParameter("DOC_DEPT_EXPENSE_PERCENT_MISC", SqlNull(DOC_DEPT_EXPENSE_PERCENT_MISC)),
						new SqlParameter("DOC_YRLY_REQREV", SqlNull(DOC_YRLY_REQREV)),
						new SqlParameter("DOC_YRLY_REQREV_ADJUSTED", SqlNull(DOC_YRLY_REQREV_ADJUSTED)),
						new SqlParameter("DOC_YRLY_REQREV_COMPUTED", SqlNull(DOC_YRLY_REQREV_COMPUTED)),
						new SqlParameter("DOC_YRLY_TARREV", SqlNull(DOC_YRLY_TARREV)),
						new SqlParameter("DOC_YRLY_TARREV_ADJUSTED", SqlNull(DOC_YRLY_TARREV_ADJUSTED)),
						new SqlParameter("DOC_YRLY_TARREV_COMPUTED", SqlNull(DOC_YRLY_TARREV_COMPUTED)),
						new SqlParameter("RETRO_TO_EP_NBR_REQ", SqlNull(RETRO_TO_EP_NBR_REQ)),
						new SqlParameter("RETRO_TO_EP_NBR_TAR", SqlNull(RETRO_TO_EP_NBR_TAR)),
						new SqlParameter("LAST_MOD_FLAG", SqlNull(LAST_MOD_FLAG)),
						new SqlParameter("LAST_MOD_DATE", SqlNull(LAST_MOD_DATE)),
						new SqlParameter("LAST_MOD_TIME", SqlNull(LAST_MOD_TIME)),
						new SqlParameter("LAST_MOD_USER_ID", SqlNull(LAST_MOD_USER_ID)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_F112_PYCDCEILINGS_AUDIT_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOC_NBR = Reader["DOC_NBR"].ToString();
						EP_NBR = ConvertDEC(Reader["EP_NBR"]);
						FACTOR = ConvertDEC(Reader["FACTOR"]);
						DOC_PAY_CODE = Reader["DOC_PAY_CODE"].ToString();
						DOC_PAY_SUB_CODE = Reader["DOC_PAY_SUB_CODE"].ToString();
						RETRO_TO_EP_NBR = ConvertDEC(Reader["RETRO_TO_EP_NBR"]);
						DOC_YRLY_CEILING = ConvertDEC(Reader["DOC_YRLY_CEILING"]);
						DOC_YRLY_CEILING_ADJUSTED = ConvertDEC(Reader["DOC_YRLY_CEILING_ADJUSTED"]);
						DOC_YRLY_CEILING_COMPUTED = ConvertDEC(Reader["DOC_YRLY_CEILING_COMPUTED"]);
						DOC_YRLY_EXPENSE = ConvertDEC(Reader["DOC_YRLY_EXPENSE"]);
						DOC_YRLY_EXPENSE_ADJUSTED = ConvertDEC(Reader["DOC_YRLY_EXPENSE_ADJUSTED"]);
						DOC_YRLY_EXPENSE_COMPUTED = ConvertDEC(Reader["DOC_YRLY_EXPENSE_COMPUTED"]);
						DOC_YRLY_EXPN_ALLOC_PERS = ConvertDEC(Reader["DOC_YRLY_EXPN_ALLOC_PERS"]);
						DOC_YRLY_CEIL_GUAR = ConvertDEC(Reader["DOC_YRLY_CEIL_GUAR"]);
						DOC_YRLY_CEILING_GUAR_PERC = ConvertDEC(Reader["DOC_YRLY_CEILING_GUAR_PERC"]);
						DOC_RMA_EXPENSE_PERCENT_REG = ConvertINT(Reader["DOC_RMA_EXPENSE_PERCENT_REG"]);
						DOC_RMA_EXPENSE_PERCENT_MISC = ConvertINT(Reader["DOC_RMA_EXPENSE_PERCENT_MISC"]);
						DOC_DEPT_EXPENSE_PERCENT_REG = ConvertINT(Reader["DOC_DEPT_EXPENSE_PERCENT_REG"]);
						DOC_DEPT_EXPENSE_PERCENT_MISC = ConvertINT(Reader["DOC_DEPT_EXPENSE_PERCENT_MISC"]);
						DOC_YRLY_REQREV = ConvertINT(Reader["DOC_YRLY_REQREV"]);
						DOC_YRLY_REQREV_ADJUSTED = ConvertINT(Reader["DOC_YRLY_REQREV_ADJUSTED"]);
						DOC_YRLY_REQREV_COMPUTED = ConvertDEC(Reader["DOC_YRLY_REQREV_COMPUTED"]);
						DOC_YRLY_TARREV = ConvertINT(Reader["DOC_YRLY_TARREV"]);
						DOC_YRLY_TARREV_ADJUSTED = ConvertINT(Reader["DOC_YRLY_TARREV_ADJUSTED"]);
						DOC_YRLY_TARREV_COMPUTED = Reader["DOC_YRLY_TARREV_COMPUTED"].ToString();
						RETRO_TO_EP_NBR_REQ = ConvertDEC(Reader["RETRO_TO_EP_NBR_REQ"]);
						RETRO_TO_EP_NBR_TAR = ConvertDEC(Reader["RETRO_TO_EP_NBR_TAR"]);
						LAST_MOD_FLAG = Reader["LAST_MOD_FLAG"].ToString();
						LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]);
						LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]);
						LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalEp_nbr = ConvertDEC(Reader["EP_NBR"]);
						_originalFactor = ConvertDEC(Reader["FACTOR"]);
						_originalDoc_pay_code = Reader["DOC_PAY_CODE"].ToString();
						_originalDoc_pay_sub_code = Reader["DOC_PAY_SUB_CODE"].ToString();
						_originalRetro_to_ep_nbr = ConvertDEC(Reader["RETRO_TO_EP_NBR"]);
						_originalDoc_yrly_ceiling = ConvertDEC(Reader["DOC_YRLY_CEILING"]);
						_originalDoc_yrly_ceiling_adjusted = ConvertDEC(Reader["DOC_YRLY_CEILING_ADJUSTED"]);
						_originalDoc_yrly_ceiling_computed = ConvertDEC(Reader["DOC_YRLY_CEILING_COMPUTED"]);
						_originalDoc_yrly_expense = ConvertDEC(Reader["DOC_YRLY_EXPENSE"]);
						_originalDoc_yrly_expense_adjusted = ConvertDEC(Reader["DOC_YRLY_EXPENSE_ADJUSTED"]);
						_originalDoc_yrly_expense_computed = ConvertDEC(Reader["DOC_YRLY_EXPENSE_COMPUTED"]);
						_originalDoc_yrly_expn_alloc_pers = ConvertDEC(Reader["DOC_YRLY_EXPN_ALLOC_PERS"]);
						_originalDoc_yrly_ceil_guar = ConvertDEC(Reader["DOC_YRLY_CEIL_GUAR"]);
						_originalDoc_yrly_ceiling_guar_perc = ConvertDEC(Reader["DOC_YRLY_CEILING_GUAR_PERC"]);
						_originalDoc_rma_expense_percent_reg = ConvertINT(Reader["DOC_RMA_EXPENSE_PERCENT_REG"]);
						_originalDoc_rma_expense_percent_misc = ConvertINT(Reader["DOC_RMA_EXPENSE_PERCENT_MISC"]);
						_originalDoc_dept_expense_percent_reg = ConvertINT(Reader["DOC_DEPT_EXPENSE_PERCENT_REG"]);
						_originalDoc_dept_expense_percent_misc = ConvertINT(Reader["DOC_DEPT_EXPENSE_PERCENT_MISC"]);
						_originalDoc_yrly_reqrev = ConvertINT(Reader["DOC_YRLY_REQREV"]);
						_originalDoc_yrly_reqrev_adjusted = ConvertINT(Reader["DOC_YRLY_REQREV_ADJUSTED"]);
						_originalDoc_yrly_reqrev_computed = ConvertDEC(Reader["DOC_YRLY_REQREV_COMPUTED"]);
						_originalDoc_yrly_tarrev = ConvertINT(Reader["DOC_YRLY_TARREV"]);
						_originalDoc_yrly_tarrev_adjusted = ConvertINT(Reader["DOC_YRLY_TARREV_ADJUSTED"]);
						_originalDoc_yrly_tarrev_computed = Reader["DOC_YRLY_TARREV_COMPUTED"].ToString();
						_originalRetro_to_ep_nbr_req = ConvertDEC(Reader["RETRO_TO_EP_NBR_REQ"]);
						_originalRetro_to_ep_nbr_tar = ConvertDEC(Reader["RETRO_TO_EP_NBR_TAR"]);
						_originalLast_mod_flag = Reader["LAST_MOD_FLAG"].ToString();
						_originalLast_mod_date = ConvertDEC(Reader["LAST_MOD_DATE"]);
						_originalLast_mod_time = ConvertDEC(Reader["LAST_MOD_TIME"]);
						_originalLast_mod_user_id = Reader["LAST_MOD_USER_ID"].ToString();
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