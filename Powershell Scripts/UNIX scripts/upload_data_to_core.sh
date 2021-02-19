cd $pb_data
ftp -in 130.113.61.4 << EOC
user christensenc Spring2018!
cd ProductionUpload/data
hash
verbose
binary
mput adj_claim_file.dat
mput contract_dtl.dat
mput contract_mstr.dat
mput doc_totals_tmp.dat
mput eft_constant
mput f001_batch_control_file
mput f002_claim_shadow
mput f002_claim_shadow_new
mput f002_claims_extra
mput f002_claims_mstr
mput f002_claims_mstr_new
mput f002_dtl_after.dat
mput f002_dtl_before.dat
mput f002_outstanding.dat
mput f002_suspend_address
mput f002_suspend_desc
mput f002_suspend_dtl
mput f002_suspend_hdr
mput f010_chart_keys.dat
mput f010_crm.dat
mput f010_ins.dat
mput f011_pat_mstr_elig_history
mput f020_doc_mstr_history.dat
mput f020_doctor_audit.dat
mput f020_doctor_extra.dat
mput f020_doctor_mstr
mput f020_rpt.dat
mput f020_rpt_mstr.dat
mput f021_avail_doctor_mstr.dat
mput f022_deleted_doc_audit_file.dat
mput f023_alternative_doc_nbr.dat
mput f024_referring_doctor.dat
mput f024_referring_doctor_disk.dat
mput f027_contacts_mstr
mput f028_audit_file.dat
mput f028_contacts_info_mstr
mput f030_locations_mstr
mput f040_dtl
mput f040_oma_fee_mstr
mput f050_doc_revenue_mstr
mput f050tp_doc_revenue_mstr
mput f051_doc_cash_mstr
mput f051tp_doc_cash_mstr
mput f060_cheque_reg_mstr
mput f070_dept_mstr
mput f071_client_rma_claim_nbr
mput f072_client_mstr
mput f073_client_doc_mstr
mput f074_afp_group_mstr.dat
mput f074_afp_group_sequence_mstr.dat
mput f075_afp_doc_mstr.dat
mput f080_bank_mstr
mput f083_user_mstr.dat
mput f084_claims_inventory.dat
mput f085_backup_01
mput f085_rejected_claims
mput f086_pat_id.dat
mput f087_submitted_rejected_claims_dtl.dat
mput f087_submitted_rejected_claims_hdr.dat
mput f088_rat_rejected_claims_hist_dtl.dat
mput f088_rat_rejected_claims_hist_hdr.dat
mput f090_constants_mstr
mput f091_diag_codes_mstr
mput f092_ohip_error_cat_mstr.dat
mput f093_ohip_error_msg_mstr.dat
mput f094_msg_sub_mstr
mput f095_text_lines.dat
mput f096_ohip_pay_code
mput f096_ra_reject_code.dat
mput f097_spec_cd_mstr.dat
mput f098_equiv_oma_code_mstr.dat
mput f099_group_claim_mstr.dat
mput f110_comp_history.dat
mput f110_compensation.dat
mput f110_compensation_audit.dat
mput f112_pycd_history.dat
mput f112_pycdceilings.dat
mput f112_pycdceilings_audit.dat
mput f113_def_comp_history.dat
mput f113_default_comp.dat
mput f113_default_comp_upload_driver.dat
mput f114_special_payments.dat
mput f114_special_payments.dat-yas
mput f114_special_payments_bk1.dat
mput f114_special_payments_bk2.dat
mput f114_special_payments_bk3.dat
mput f114_special_payments_bk4.dat
mput f114_special_payments_bk5.dat
mput f115_dept_expense_calc_codes.dat
mput f116_dept_expense_rules_dtl.dat
mput f116_dept_expense_rules_hdr.dat
mput f119_doc_ytd_history.dat
mput f119_doctor_ytd.dat
mput f119_doctor_ytd_audit.dat
mput f123_company_mstr
mput f141_misc_payment_audit_file.dat
mput f190_comp_codes.dat
mput f191_earnings_period.dat
mput f198_user_defined_totals.dat
mput f199_user_defined_fields.dat
mput f200_oscar_provider
mput f201_sli_oma_code_suff
mput f920_doctor_options.dat
mput f923_doc_revenue_translation.dat
mput f924_non_fee_for_service_locations.dat
mput ohip_run_dates.dat
mput pv_ohip_run_dates.dat
mput social_contract_factor.dat
mput tmp_counters.dat
mput tmp_counters_alpha.dat
mput tmp_counters_dup.dat
mput tmp_doc_revenue.dat
mput tmp_doctor_alpha.dat
mput tmp_doctor_alpha_mohd.dat
mput tmp_governance_payments_file.dat
mput tmp_pat_mstr.dat
mput tmp_pc_download_file.dat
mput tmp_serv_err_claim.dat
quit
EOC

cd /charly/rmabill/rmabill101c/data
ftp -in 130.113.61.4 << EOC
user christensenc Spring2018!
cd ProductionUpload/charly
hash
verbose
binary
mput f010_pat_mstr
mput f050_doc_revenue_mstr_history.dat
mput f050tp_doc_revenue_mstr_history.dat
quit
EOC
