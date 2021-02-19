cd /alpha/rmabill/rmabill101c/data
pwd
date
ftp -in 130.113.61.4 << EOC
user christensenc Spring2018!
cd ProductionUpload/data
hash
verbose
binary
mget adj_claim_file.dat
mget contract_dtl.dat
mget contract_mstr.dat
mget doc_totals_tmp.dat
mget eft_constant
mget f001_batch_control_file
mget f002_claims_extra
mget f002_claims_mstr
mget f002_claims_mstr_new
mget f002_claim_shadow
mget f002_claim_shadow_new
mget f002_dtl_after.dat
mget f002_dtl_before.dat
mget f002_outstanding.dat
mget f002_suspend_address
mget f002_suspend_desc
mget f002_suspend_dtl
mget f002_suspend_hdr
mget f010_chart_keys.dat
mget f011_pat_mstr_elig_history
mget f020_doctor_audit.dat
mget f020_doctor_extra.dat
mget f020_doctor_mstr
mget f020_doc_mstr_history.dat
mget f020_rpt.dat
mget f020_rpt_mstr.dat
mget f021_avail_doctor_mstr.dat
mget f022_deleted_doc_audit_file.dat
mget f023_alternative_doc_nbr.dat
mget f024_referring_doctor.dat
mget f024_referring_doctor_disk.dat
mget f027_contacts_mstr
mget f028_audit_file.dat
mget f028_contacts_info_mstr
mget f030_locations_mstr
mget f040_dtl
mget f040_oma_fee_mstr
mget f050tp_doc_revenue_mstr
mget f050_doc_revenue_mstr
mget f051tp_doc_cash_mstr
mget f051_doc_cash_mstr
mget f060_cheque_reg_mstr
mget f070_dept_mstr
mget f071_client_rma_claim_nbr
mget f072_client_mstr
mget f073_client_doc_mstr
mget f074_afp_group_mstr.dat
mget f074_afp_group_sequence_mstr.dat
mget f075_afp_doc_mstr.dat
mget f080_bank_mstr
mget f083_user_mstr.dat
mget f084_claims_inventory.dat
mget f085_backup_01
mget f085_rejected_claims
mget f086_pat_id.dat
mget f087_submitted_rejected_claims_dtl.dat
mget f087_submitted_rejected_claims_hdr.dat
mget f088_rat_rejected_claims_hist_dtl.dat
mget f088_rat_rejected_claims_hist_hdr.dat
mget f090_constants_mstr
mget f091_diag_codes_mstr
mget f092_ohip_error_cat_mstr.dat
mget f093_ohip_error_msg_mstr.dat
mget f094_msg_sub_mstr
mget f095_text_lines.dat
mget f096_ohip_pay_code
mget f096_ra_reject_code.dat
mget f097_spec_cd_mstr.dat
mget f098_equiv_oma_code_mstr.dat
mget f099_group_claim_mstr.dat
mget f110_compensation.dat
mget f110_compensation_audit.dat
mget f110_comp_history.dat
mget f112_pycdceilings.dat
mget f112_pycdceilings_audit.dat
mget f112_pycd_history.dat
mget f113_default_comp.dat
mget f113_default_comp_upload_driver.dat
mget f113_def_comp_history.dat
mget f114_special_payments.dat
mget f114_special_payments.dat-yas
mget f114_special_payments_bk1.dat
mget f114_special_payments_bk2.dat
mget f114_special_payments_bk3.dat
mget f114_special_payments_bk4.dat
mget f114_special_payments_bk5.dat
mget f115_dept_expense_calc_codes.dat
mget f116_dept_expense_rules_dtl.dat
mget f116_dept_expense_rules_hdr.dat
mget f119_doctor_ytd.dat
mget f119_doctor_ytd_audit.dat
mget f119_doc_ytd_history.dat
mget f123_company_mstr
mget f141_misc_payment_audit_file.dat
mget f190_comp_codes.dat
mget f191_earnings_period.dat
mget f198_user_defined_totals.dat
mget f199_user_defined_fields.dat
mget f200_oscar_provider
mget f201_sli_oma_code_suff
mget f920_doctor_options.dat
mget f923_doc_revenue_translation.dat
mget f924_non_fee_for_service_locations.dat
mget ohip_run_dates.dat
mget pv_ohip_run_dates.dat
mget social_contract_factor.dat
mget tmp_counters.dat
mget tmp_counters_alpha.dat
mget tmp_counters_dup.dat
mget tmp_doctor_alpha.dat
mget tmp_doctor_alpha_mohd.dat
mget tmp_doc_revenue.dat
mget tmp_governance_payments_file.dat
mget tmp_pat_mstr.dat
mget tmp_pc_download_file.dat
mget tmp_serv_err_claim.dat

quit
EOC
cd /charly/rmabill/rmabill101c/data
pwd
date
ftp -in 130.113.61.4 << EOC
user christensenc Spring2018!
cd ProductionUpload/charly
hash
verbose
binary
mget f010_pat_mstr
mget f050tp_doc_revenue_mstr_history.dat
mget f050_doc_revenue_mstr_history.dat
quit
EOC
cd /alpha/rmabill/rmabill101c/production
pwd
date
ftp -in 130.113.61.4 << EOC
user christensenc Spring2018!
cd ProductionUpload/production/bin
hash
verbose
binary
mget EB0706.234
mget EB0706.284
mget EB0706.314
mget EB0706.339
mget EB0930.234
mget EB0930.339
mget EB1837.234
mget EB1837.339
mget EB2215.234
mget EB2215.339
mget EB2215.378
mget EB6317.234
mget EB6317.339
mget EB6411.234
mget EB6411.284
mget EB6411.339
mget EB9595.234
mget EB9595.378
mget EBAA21.234
mget EBAA21.339
mget EBAA21.378
mget EBAA2K.339
mget EBAA2K.378
mget EBAA32.339
mget EBAA3F.234
mget EBAA3F.263
mget EBAA3F.339
mget EBAA5B.234
mget EBAA5B.263
mget EBAA5B.284
mget EBAA5B.314
mget EBAA5B.339
mget EBAA5B.359
mget EBAA5B.378
mget EBAA5V.339
mget EBAA5W.234
mget EBAA5W.339
mget EBAA5W.359
mget EBAA5X.234
mget EBAA5X.339
mget EBAA5X.378
mget EBAA5Y.339
mget EBAA8U.234
mget EBAA8U.263
mget EBAA8U.339
mget EBC022.339
mget EBH055.234
mget EBH055.339
mget EBH061.234
mget EBH061.314
mget EBH061.339
mget EBH103.234
mget EBH103.263
mget EBH103.339
mget EBH103.378
mget EBH105.234
mget EBH105.284
mget EBH105.339
mget EBH105.378
mget EBH106.234
mget EBH106.314
mget EBH106.339
mget EBH107.234
mget EBH107.314
mget EBH107.339
mget EBH107.378
mget EBH108.234
mget EBH108.339
mget EBH110.234
mget EBH110.263
mget EBH110.284
mget EBH110.314
mget EBH110.339
mget EBH111.339
quit
EOC
