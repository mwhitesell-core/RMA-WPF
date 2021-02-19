ln -s f001_batch_control_file f001_batch_control_file.dat
ln -s f002_claims_mstr        f002_claims_mstr.dat
ln -s f002_claims_extra       f002_claims_extra.dat
ln -s f002_claim_shadow       f002_claim_shadow.dat

#ln -s f002_suspend_hdr        f002_suspend_hdr.dat
#ln -s f002_suspend_dtl        f002_suspend_dtl.dat
#ln -s f002_suspend_addr       f002_suspend_addr.dat
#ln -s f002_suspend_desc       f002_suspend_desc.dat

ln -s f010_pat_mstr           f010_pat_mstr.dat
ln -s f020_doctor_mstr        f020_doctor_mstr.dat
ln -s f030_locations_mstr     f030_locations_mstr.dat
ln -s f040_oma_fee_mstr       f040_oma_fee_mstr.dat
ln -s f050_doc_revenue_mstr   f050_doc_revenue_mstr.dat
ln -s f050tp_doc_revenue_mstr f050tp_doc_revenue_mstr.dat
ln -s f051_doc_cash_mstr      f051_doc_cash_mstr.dat
ln -s f051tp_doc_cash_mstr    f051tp_doc_cash_mstr.dat
ln -s f060_cheque_reg_mstr    f060_cheque_reg_mstr.dat
ln -s f070_dept_mstr          f070_dept_mstr.dat
ln -s f080_bank_mstr          f080_bank_mstr.dat
ln -s f085_rejected_claims    f085_rejected_claims.dat
ln -s f090_constants_mstr     f090_constants_mstr.dat
ln -s f091_diag_codes_mstr    f091_diag_codes_mstr.dat
ln -s f094_msg_sub_mstr       f094_msg_sub_mstr.dat
ln -s f096_ohip_pay_code      f096_ohip_pay_code.dat
