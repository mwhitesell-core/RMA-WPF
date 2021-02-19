echo "start time: "
date
#DISK4
cd $pb_prod
pwd
date
ftp -in 130.113.61.4 << EOC
user christensenc Spring2018!
cd RunCycleUpload/production
debug
verbose
binary
mget u020_tapeout_file
mget u020_tapeout_file_a
mget u020_tapeout_file_b
mget u020_tapeout_file_c
mget u020_tapeout_file_d
mget u020_tapeout_file_e
quit
EOC

#/alpha/rmabill/rmabill101c/data
cd /alpha/rmabill/rmabill101c/data
pwd
date
ftp -in 130.113.61.4 << EOC
user christensenc Spring2018!
cd RunCycleUpload/data
debug
verbose
binary
mget adj_claim_file.dat
mget contract_dtl.dat
mget contract_dtl.idx
mget contract_mstr.dat
mget contract_mstr.idx
mget delay_6pm_backup.flg
mget doc_totals_tmp.dat
mget doc_totals_tmp.idx
mget dummy_99_file.dat
mget dummy_99_file.idx
mget f001_batch_control_file
mget f001_batch_control_file.idx
mget f002_claims_extra
mget f002_claims_extra.idx
mget f002_claims_history.dat
mget f002_claims_history.idx
mget f002_claims_mstr
mget f002_claims_mstr.idx
mget f002_claims_mstr_before_purge
mget f002_claims_mstr_before_purge.idx
mget f002_claim_shadow
mget f002_claim_shadow.idx
mget f002_claim_shadow_new
mget f002_claim_shadow_new.idx
mget f002_dtl_after.dat
mget f002_dtl_before.dat
mget f002_outstanding.dat
mget f002_outstanding.idx
mget f002_suspend_address
mget f002_suspend_address.idx
mget f002_suspend_desc
mget f002_suspend_desc.idx
mget f002_suspend_dtl
mget f002_suspend_dtl.idx
mget f002_suspend_hdr
mget f002_suspend_hdr.idx
mget f010_chart_keys.dat
mget f010_chart_keys.idx
mget f010_crm
mget f010_crm.idx
mget f010_ins
mget f010_ins.idx
mget f011_pat_mstr_elig_history
mget f011_pat_mstr_elig_history.idx
mget f020_doctor_audit.dat
mget f020_doctor_extra.dat
mget f020_doctor_extra.idx
mget f020_doctor_mstr
mget f020_doctor_mstr.idx
mget f020_doc_mstr_history.dat
mget f020_doc_mstr_history.idx
mget f020_rpt.dat
mget f020_rpt.idx
mget f020_rpt_mstr.dat
mget f020_rpt_mstr.idx
mget f021_avail_doctor_mstr.dat
mget f021_avail_doctor_mstr.idx
mget f022_deleted_doc_audit_file.dat
mget f023_alternative_doc_nbr.dat
mget f023_alternative_doc_nbr.idx
mget f024_referring_doctor.dat
mget f024_referring_doctor.idx
mget f024_referring_doctor_disk.dat
mget f027_contacts_mstr
mget f027_contacts_mstr.idx
mget f028_audit_file.dat
mget f028_audit_file.idx
mget f028_contacts_info_mstr
mget f028_contacts_info_mstr.idx
mget f029_followup_events.idx
mget f030_locations_mstr
mget f030_locations_mstr.idx
mget f030_locations_mstr_live
mget f030_locations_mstr_live.idx
mget f040_dtl
mget f040_dtl.idx
mget f040_oma_fee_mstr
mget f040_oma_fee_mstr.idx
mget f050tp_doc_revenue_mstr
mget f050tp_doc_revenue_mstr.idx
mget f050tp_doc_revenue_mstr_BAD
mget f050_doc_revenue_mstr
mget f050_doc_revenue_mstr.idx
mget f050_doc_revenue_mstr_BAD
mget f050_doc_revenue_mstr_BAD.idx
mget f051tp_doc_cash_mstr
mget f051tp_doc_cash_mstr.idx
mget f051_doc_cash_mstr
mget f051_doc_cash_mstr.idx
mget f060_cheque_reg_mstr
mget f060_cheque_reg_mstr.idx
mget f070_dept_mstr
mget f070_dept_mstr.idx
mget f071_client_rma_claim_nbr
mget f071_client_rma_claim_nbr.idx
mget f072_client_mstr
mget f072_client_mstr.idx
mget f073_client_doc_mstr
mget f073_client_doc_mstr.idx
mget f074_afp_group_mstr.dat
mget f074_afp_group_mstr.idx
mget f074_afp_group_sequence_mstr.dat
mget f074_afp_group_sequence_mstr.idx
mget f075_afp_doc_mstr.dat
mget f075_afp_doc_mstr.idx
mget f080_bank_mstr
mget f080_bank_mstr.idx
mget f083_user_mstr.dat
mget f083_user_mstr.idx
mget f084_claims_inventory.dat
mget f084_claims_inventory.idx
mget f085_backup_01
mget f085_backup_01.idx
mget f085_backup_02
mget f085_backup_02.idx
mget f085_backup_03
mget f085_backup_03.idx
mget f085_backup_04
mget f085_backup_04.idx
mget f085_backup_05
mget f085_backup_05.idx
mget f085_backup_06
mget f085_backup_06.idx
mget f085_backup_07
mget f085_backup_07.idx
mget f085_backup_08
mget f085_backup_08.idx
mget f085_backup_09
mget f085_backup_09.idx
mget f085_backup_10
mget f085_backup_10.idx
mget f085_rejected_claims
mget f085_rejected_claims.idx
mget f086_pat_id.dat
mget f087_submitted_rejected_claims_dtl.dat
mget f087_submitted_rejected_claims_dtl.idx
mget f087_submitted_rejected_claims_hdr.dat
mget f087_submitted_rejected_claims_hdr.idx
mget f088_rat_rejected_claims_hist_dtl.dat
mget f088_rat_rejected_claims_hist_dtl.idx
mget f088_rat_rejected_claims_hist_hdr.dat
mget f088_rat_rejected_claims_hist_hdr.idx
mget f090_constants_mstr
mget f090_constants_mstr.idx
mget f091_diag_codes_mstr
mget f091_diag_codes_mstr.idx
mget f092_ohip_error_cat_mstr.dat
mget f092_ohip_error_cat_mstr.idx
mget f093_ohip_error_msg_mstr.dat
mget f093_ohip_error_msg_mstr.idx
mget f094_msg_sub_mstr
mget f094_msg_sub_mstr.idx
mget f095_text_lines.dat
mget f095_text_lines.idx
mget f096_ohip_pay_code
mget f096_ohip_pay_code.idx
mget f096_ra_reject_code.dat
mget f096_ra_reject_code.idx
mget f097_spec_cd_mstr.dat
mget f097_spec_cd_mstr.idx
mget f098_equiv_oma_code_mstr.dat
mget f098_equiv_oma_code_mstr.idx
mget f099_group_claim_mstr.dat
mget f099_group_claim_mstr.idx
mget f110_compensation.dat
mget f110_compensation.idx
mget f110_compensation_audit.dat
mget f110_comp_history.dat
mget f110_comp_history.idx
mget f112_pycdceilings.dat
mget f112_pycdceilings.idx
mget f112_pycdceilings_audit.dat
mget f112_pycd_history.dat
mget f112_pycd_history.idx
mget f113_default_comp.dat
mget f113_default_comp.idx
mget f113_default_comp_upload_driver.dat
mget f113_default_comp_upload_driver.idx
mget f113_def_comp_history.dat
mget f113_def_comp_history.idx
mget f114_special_payments.dat
mget f114_special_payments.idx
mget f114_special_payments_bk1.dat
mget f114_special_payments_bk1.idx
mget f114_special_payments_bk2.dat
mget f114_special_payments_bk2.idx
mget f114_special_payments_bk3.dat
mget f114_special_payments_bk3.idx
mget f114_special_payments_bk4.dat
mget f114_special_payments_bk4.idx
mget f114_special_payments_bk5.dat
mget f114_special_payments_bk5.idx
mget f115_dept_expense_calc_codes.dat
mget f115_dept_expense_calc_codes.idx
mget f116_dept_expense_rules_dtl.dat
mget f116_dept_expense_rules_dtl.idx
mget f116_dept_expense_rules_hdr.dat
mget f116_dept_expense_rules_hdr.idx
mget f119_doctor_ytd.dat
mget f119_doctor_ytd.idx
mget f119_doctor_ytd_audit.dat
mget f119_doc_ytd_history.dat
mget f119_doc_ytd_history.idx
mget f123_company_mstr
mget f123_company_mstr.idx
mget f190_comp_codes.dat
mget f190_comp_codes.idx
mget f191_earnings_period.dat
mget f191_earnings_period.idx
mget f198_user_defined_totals.dat
mget f198_user_defined_totals.idx
mget f199_user_defined_fields.dat
mget f199_user_defined_fields.idx
mget f200_oscar_provider
mget f200_oscar_provider.idx
mget f201_sli_oma_code_suff
mget f201_sli_oma_code_suff.idx
mget f920_doctor_options.dat
mget f920_doctor_options.idx
mget f923_doc_revenue_translation.dat
mget f923_doc_revenue_translation.idx
mget f924_non_fee_for_service_locations.dat
mget f924_non_fee_for_service_locations.idx
mget misc_payment_file.dat
mget ohip_run_dates.dat
mget ohip_run_dates.idx
mget ohip_run_dates_backup_01.dat
mget ohip_run_dates_backup_01.idx
mget ohip_run_dates_backup_02.dat
mget ohip_run_dates_backup_02.idx
mget ohip_run_dates_backup_03.dat
mget ohip_run_dates_backup_03.idx
mget ohip_run_dates_backup_04.dat
mget ohip_run_dates_backup_04.idx
mget ohip_run_dates_backup_05.dat
mget ohip_run_dates_backup_05.idx
mget ohip_run_dates_backup_06.dat
mget ohip_run_dates_backup_06.idx
mget ohip_run_dates_backup_07.dat
mget ohip_run_dates_backup_07.idx
mget ohip_run_dates_backup_08.dat
mget ohip_run_dates_backup_08.idx
mget ohip_run_dates_backup_09.dat
mget ohip_run_dates_backup_09.idx
mget ohip_run_dates_backup_10.dat
mget ohip_run_dates_backup_10.idx
mget social_contract_factor.dat
mget social_contract_factor.idx
mget tmp_counters.dat
mget tmp_counters.idx
mget tmp_counters_alpha.dat
mget tmp_counters_alpha.idx
mget tmp_counters_dup.dat
mget tmp_counters_dup.idx
mget tmp_doctor_alpha.dat
mget tmp_doctor_alpha.idx
mget tmp_doctor_alpha_mohd.dat
mget tmp_doctor_alpha_mohd.idx
mget tmp_doc_revenue.dat
mget tmp_doc_revenue.idx
mget tmp_governance_payments_file.dat
mget tmp_governance_payments_file.idx
mget tmp_pat_mstr.dat
mget tmp_pat_mstr.idx
mget tmp_pc_download_file.dat
mget tmp_pc_download_file.idx
mget tmp_serv_err_claim.dat
mget tmp_serv_err_claim.idx

quit
EOC
#/charly/rmabill/rmabill101c/data
cd /charly/rmabill/rmabill101c/data
pwd
date
ftp -in 130.113.61.4 << EOC
user christensenc Spring2018!
cd Drop3aUpload/charly/data
debug
verbose
binary
mget f010_pat_mstr
mget f010_pat_mstr.idx
mget f050tp_doc_revenue_mstr
mget f050tp_doc_revenue_mstr.idx
mget f050tp_doc_revenue_mstr_history.dat
mget f050tp_doc_revenue_mstr_history.idx
mget f050_doc_revenue_mstr_history.dat
mget f050_doc_revenue_mstr_history.idx
quit
EOC

echo "end time: "
date


