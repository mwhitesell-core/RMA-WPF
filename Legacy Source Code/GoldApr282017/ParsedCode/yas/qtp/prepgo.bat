del prepgo.log
del *.pre

path=C:\CoreProjects\parser\bin;%path%

set $SRC=C:\Clients\RMA\GoldApr282017\ParsedCode\use
set $PB_SRC=C:\Clients\RMA\GoldApr282017\ParsedCode\use
set $USE=C:\Clients\RMA\GoldApr282017\ParsedCode\use
set $PB_USE=C:\Clients\RMA\GoldApr282017\ParsedCode\use

rem phprep afp_pedsurgery_JantoDec_2015.qts afp_pedsurgery_JantoDec_2015.pre  >> prepgo.log
phprep afp_pedsurgery_Jultojun_2017.qts afp_pedsurgery_Jultojun_2017.pre  >> prepgo.log
phprep clinic26.qts clinic26.pre  >> prepgo.log
phprep costing_f119hist.qts costing_f119hist.pre  >> prepgo.log
phprep dept_average_docohip.qts dept_average_docohip.pre  >> prepgo.log
phprep dept4_average.qts dept4_average.pre  >> prepgo.log
phprep dept4142_doc_loc_ctas.qts dept4142_doc_loc_ctas.pre  >> prepgo.log
phprep dept54_billings.qts dept54_billings.pre  >> prepgo.log
phprep detail_peds_billings_ped.qts detail_peds_billings_ped.pre  >> prepgo.log
rem phprep detail_peds_billings_svcdate.qts detail_peds_billings_svcdate.pre  >> prepgo.log
phprep doc_rat_rejects.qts doc_rat_rejects.pre  >> prepgo.log
phprep drkolesar.qts drkolesar.pre  >> prepgo.log
phprep drkolesar_doc.qts drkolesar_doc.pre  >> prepgo.log
phprep drkolesar_yr.qts drkolesar_yr.pre  >> prepgo.log
phprep emerg_codes_4142.qts emerg_codes_4142.pre  >> prepgo.log
phprep emerg_dept44.qts emerg_dept44.pre  >> prepgo.log
phprep emergency_payroll_clmhdrid.qts emergency_payroll_clmhdrid.pre  >> prepgo.log
phprep emergency_urgent_clmhdrid_44.qts emergency_urgent_clmhdrid_44.pre  >> prepgo.log
phprep f050hist_location_dept4.qts f050hist_location_dept4.pre  >> prepgo.log
rem phprep f088_clinic78_rejects.qts f088_clinic78_rejects.pre  >> prepgo.log
phprep f088_peds_rejects.qts f088_peds_rejects.pre  >> prepgo.log
phprep f119histtithe.qts f119histtithe.pre  >> prepgo.log
phprep f119tithe.qts f119tithe.pre  >> prepgo.log
phprep geriatric.qts geriatric.pre  >> prepgo.log
phprep leena_claims.qts leena_claims.pre  >> prepgo.log
phprep leena_detail_rmb.qts leena_detail_rmb.pre  >> prepgo.log
phprep leena_detail_rmb_lastpass.qts leena_detail_rmb_lastpass.pre  >> prepgo.log
phprep leena_premium.qts leena_premium.pre  >> prepgo.log
rem phprep pediatric_total_billing.qts pediatric_total_billing.pre  >> prepgo.log
phprep peds_diag_codes.qts peds_diag_codes.pre  >> prepgo.log
phprep test44.qts test44.pre  >> prepgo.log
phprep ucc_patient_count_dtl.qts ucc_patient_count_dtl.pre  >> prepgo.log
phprep ucc_patient_count_hdr.qts ucc_patient_count_hdr.pre  >> prepgo.log
