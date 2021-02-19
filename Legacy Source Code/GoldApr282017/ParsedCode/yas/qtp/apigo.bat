del apigo.log
del *.api
del metric.dat
del metric.det
del auxiliary.txt

path=C:\CoreProjects\parser\bin;%path%

rem qtp rmaYas afp_pedsurgery_JantoDec_2015.pre afp_pedsurgery_JantoDec_2015.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaYas afp_pedsurgery_Jultojun_2017.pre afp_pedsurgery_Jultojun_2017.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaYas clinic26.pre clinic26.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaYas costing_f119hist.pre costing_f119hist.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaYas dept_average_docohip.pre dept_average_docohip.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaYas dept4_average.pre dept4_average.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaYas dept4142_doc_loc_ctas.pre dept4142_doc_loc_ctas.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaYas dept54_billings.pre dept54_billings.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaYas detail_peds_billings_ped.pre detail_peds_billings_ped.api /METRIC=metric.dat /LOG=apigo.log
rem qtp rmaYas detail_peds_billings_svcdate.pre detail_peds_billings_svcdate.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaYas doc_rat_rejects.pre doc_rat_rejects.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaYas drkolesar.pre drkolesar.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaYas drkolesar_doc.pre drkolesar_doc.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaYas drkolesar_yr.pre drkolesar_yr.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaYas emerg_codes_4142.pre emerg_codes_4142.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaYas emerg_dept44.pre emerg_dept44.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaYas emergency_payroll_clmhdrid.pre emergency_payroll_clmhdrid.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaYas emergency_urgent_clmhdrid_44.pre emergency_urgent_clmhdrid_44.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaYas f050hist_location_dept4.pre f050hist_location_dept4.api /METRIC=metric.dat /LOG=apigo.log
rem qtp rmaYas f088_clinic78_rejects.pre f088_clinic78_rejects.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaYas f088_peds_rejects.pre f088_peds_rejects.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaYas f119histtithe.pre f119histtithe.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaYas f119tithe.pre f119tithe.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaYas geriatric.pre geriatric.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaYas leena_claims.pre leena_claims.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaYas leena_detail_rmb.pre leena_detail_rmb.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaYas leena_detail_rmb_lastpass.pre leena_detail_rmb_lastpass.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaYas leena_premium.pre leena_premium.api /METRIC=metric.dat /LOG=apigo.log
rem qtp rmaYas pediatric_total_billing.pre pediatric_total_billing.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaYas peds_diag_codes.pre peds_diag_codes.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaYas test44.pre test44.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaYas ucc_patient_count_dtl.pre ucc_patient_count_dtl.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaYas ucc_patient_count_hdr.pre ucc_patient_count_hdr.api /METRIC=metric.dat /LOG=apigo.log
