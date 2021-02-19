echo 'Comparing source in [Current Directory] vs [/alpha/rmabill/rmabill101c/src/]' >> compare_source.log
echo 'Code prefaced with < is in [Current Directory] ] ' >> compare_source.log
echo 'Code prefaced with > is in [/alpha/rmabill/rmabill101c/src/] ] ' >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: addrlabels.qzs >> compare_source.log
diff addrlabels.qzs /alpha/rmabill/rmabill101c/src/addrlabels.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: addrlabels_termdocs.qzs >> compare_source.log
diff addrlabels_termdocs.qzs /alpha/rmabill/rmabill101c/src/addrlabels_termdocs.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: afpfix.qts >> compare_source.log
diff afpfix.qts /alpha/rmabill/rmabill101c/src/afpfix.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: append_claims_subfile.qts >> compare_source.log
diff append_claims_subfile.qts /alpha/rmabill/rmabill101c/src/append_claims_subfile.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: append_claims_subfile_22_60.qts >> compare_source.log
diff append_claims_subfile_22_60.qts /alpha/rmabill/rmabill101c/src/append_claims_subfile_22_60.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: append_claims_subfile_80_81.qts >> compare_source.log
diff append_claims_subfile_80_81.qts /alpha/rmabill/rmabill101c/src/append_claims_subfile_80_81.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: append_claims_subfile_82.qts >> compare_source.log
diff append_claims_subfile_82.qts /alpha/rmabill/rmabill101c/src/append_claims_subfile_82.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: audit_doc.qzs >> compare_source.log
diff audit_doc.qzs /alpha/rmabill/rmabill101c/src/audit_doc.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: audit_f050.qzs >> compare_source.log
diff audit_f050.qzs /alpha/rmabill/rmabill101c/src/audit_f050.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: audit_f050hist.qzs >> compare_source.log
diff audit_f050hist.qzs /alpha/rmabill/rmabill101c/src/audit_f050hist.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: audit_f050tp.qzs >> compare_source.log
diff audit_f050tp.qzs /alpha/rmabill/rmabill101c/src/audit_f050tp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: audit_f050tphist.qzs >> compare_source.log
diff audit_f050tphist.qzs /alpha/rmabill/rmabill101c/src/audit_f050tphist.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: auditdoc.qzs >> compare_source.log
diff auditdoc.qzs /alpha/rmabill/rmabill101c/src/auditdoc.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: auditdoc_9798.qzs >> compare_source.log
diff auditdoc_9798.qzs /alpha/rmabill/rmabill101c/src/auditdoc_9798.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: auditdoc_bkp.qzs >> compare_source.log
diff auditdoc_bkp.qzs /alpha/rmabill/rmabill101c/src/auditdoc_bkp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: auditdoc_old.qzs >> compare_source.log
diff auditdoc_old.qzs /alpha/rmabill/rmabill101c/src/auditdoc_old.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: audityas.qzs >> compare_source.log
diff audityas.qzs /alpha/rmabill/rmabill101c/src/audityas.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: ballot.qzs >> compare_source.log
diff ballot.qzs /alpha/rmabill/rmabill101c/src/ballot.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: banks.qzs >> compare_source.log
diff banks.qzs /alpha/rmabill/rmabill101c/src/banks.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: billdirects.qzs >> compare_source.log
diff billdirects.qzs /alpha/rmabill/rmabill101c/src/billdirects.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: billinglist.qzs >> compare_source.log
diff billinglist.qzs /alpha/rmabill/rmabill101c/src/billinglist.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: brad+u933a_part1.qts >> compare_source.log
diff brad+u933a_part1.qts /alpha/rmabill/rmabill101c/src/brad+u933a_part1.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: brad2_use.qzs >> compare_source.log
diff brad2_use.qzs /alpha/rmabill/rmabill101c/src/brad2_use.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: brad_maria_rejects.qzs >> compare_source.log
diff brad_maria_rejects.qzs /alpha/rmabill/rmabill101c/src/brad_maria_rejects.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: bsuffix.qzs >> compare_source.log
diff bsuffix.qzs /alpha/rmabill/rmabill101c/src/bsuffix.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: buildfiles.qus >> compare_source.log
diff buildfiles.qus /alpha/rmabill/rmabill101c/src/buildfiles.qus >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: c.qzs >> compare_source.log
diff c.qzs /alpha/rmabill/rmabill101c/src/c.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: cfund1.qzs >> compare_source.log
diff cfund1.qzs /alpha/rmabill/rmabill101c/src/cfund1.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: cfund2.qzs >> compare_source.log
diff cfund2.qzs /alpha/rmabill/rmabill101c/src/cfund2.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: check_claims_mstr.qzs >> compare_source.log
diff check_claims_mstr.qzs /alpha/rmabill/rmabill101c/src/check_claims_mstr.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: check_susp_dtl.qzs >> compare_source.log
diff check_susp_dtl.qzs /alpha/rmabill/rmabill101c/src/check_susp_dtl.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: claims85_a.qts >> compare_source.log
diff claims85_a.qts /alpha/rmabill/rmabill101c/src/claims85_a.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: claims85_b.qzs >> compare_source.log
diff claims85_b.qzs /alpha/rmabill/rmabill101c/src/claims85_b.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: claims_hdr_dtl.qts >> compare_source.log
diff claims_hdr_dtl.qts /alpha/rmabill/rmabill101c/src/claims_hdr_dtl.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: claims_updt.qts >> compare_source.log
diff claims_updt.qts /alpha/rmabill/rmabill101c/src/claims_updt.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: claims_updt2.qts >> compare_source.log
diff claims_updt2.qts /alpha/rmabill/rmabill101c/src/claims_updt2.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: clinic_81_august_claims.qzs >> compare_source.log
diff clinic_81_august_claims.qzs /alpha/rmabill/rmabill101c/src/clinic_81_august_claims.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: common_diag.qzs >> compare_source.log
diff common_diag.qzs /alpha/rmabill/rmabill101c/src/common_diag.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: common_diag_80.qzs >> compare_source.log
diff common_diag_80.qzs /alpha/rmabill/rmabill101c/src/common_diag_80.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: common_diag_81.qzs >> compare_source.log
diff common_diag_81.qzs /alpha/rmabill/rmabill101c/src/common_diag_81.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: common_diag_noweb.qzs >> compare_source.log
diff common_diag_noweb.qzs /alpha/rmabill/rmabill101c/src/common_diag_noweb.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: common_oma.qzs >> compare_source.log
diff common_oma.qzs /alpha/rmabill/rmabill101c/src/common_oma.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: common_ref.qzs >> compare_source.log
diff common_ref.qzs /alpha/rmabill/rmabill101c/src/common_ref.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: comp_pay_qts.qts >> compare_source.log
diff comp_pay_qts.qts /alpha/rmabill/rmabill101c/src/comp_pay_qts.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: comp_pay_qts_special.qts >> compare_source.log
diff comp_pay_qts_special.qts /alpha/rmabill/rmabill101c/src/comp_pay_qts_special.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: comp_pay_qzs.qzs >> compare_source.log
diff comp_pay_qzs.qzs /alpha/rmabill/rmabill101c/src/comp_pay_qzs.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: compile_proyas.qts >> compare_source.log
diff compile_proyas.qts /alpha/rmabill/rmabill101c/src/compile_proyas.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: compile_proyas.qzs >> compare_source.log
diff compile_proyas.qzs /alpha/rmabill/rmabill101c/src/compile_proyas.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: compile_qks.qks >> compare_source.log
diff compile_qks.qks /alpha/rmabill/rmabill101c/src/compile_qks.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: compile_qts.qts >> compare_source.log
diff compile_qts.qts /alpha/rmabill/rmabill101c/src/compile_qts.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: compile_qts_alone.qts >> compare_source.log
diff compile_qts_alone.qts /alpha/rmabill/rmabill101c/src/compile_qts_alone.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: compile_qts_special.qts >> compare_source.log
diff compile_qts_special.qts /alpha/rmabill/rmabill101c/src/compile_qts_special.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: compile_qzs.qzs >> compare_source.log
diff compile_qzs.qzs /alpha/rmabill/rmabill101c/src/compile_qzs.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: compile_qzs_alone.qzs >> compare_source.log
diff compile_qzs_alone.qzs /alpha/rmabill/rmabill101c/src/compile_qzs_alone.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: compile_qzs_special.qzs >> compare_source.log
diff compile_qzs_special.qzs /alpha/rmabill/rmabill101c/src/compile_qzs_special.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: compile_qzs_special2.qzs >> compare_source.log
diff compile_qzs_special2.qzs /alpha/rmabill/rmabill101c/src/compile_qzs_special2.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: compile_time_qks.qks >> compare_source.log
diff compile_time_qks.qks /alpha/rmabill/rmabill101c/src/compile_time_qks.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: compile_time_qts.qts >> compare_source.log
diff compile_time_qts.qts /alpha/rmabill/rmabill101c/src/compile_time_qts.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: compile_time_qzs.qzs >> compare_source.log
diff compile_time_qzs.qzs /alpha/rmabill/rmabill101c/src/compile_time_qzs.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: compile_yas.qzs >> compare_source.log
diff compile_yas.qzs /alpha/rmabill/rmabill101c/src/compile_yas.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: compile_yasemin.qts >> compare_source.log
diff compile_yasemin.qts /alpha/rmabill/rmabill101c/src/compile_yasemin.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: compile_yasemin.qzs >> compare_source.log
diff compile_yasemin.qzs /alpha/rmabill/rmabill101c/src/compile_yasemin.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: comptest_qts.qts >> compare_source.log
diff comptest_qts.qts /alpha/rmabill/rmabill101c/src/comptest_qts.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: convert_date1.qzs >> compare_source.log
diff convert_date1.qzs /alpha/rmabill/rmabill101c/src/convert_date1.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: convert_date2.qzs >> compare_source.log
diff convert_date2.qzs /alpha/rmabill/rmabill101c/src/convert_date2.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: costing.qzs >> compare_source.log
diff costing.qzs /alpha/rmabill/rmabill101c/src/costing.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: costing1.qts >> compare_source.log
diff costing1.qts /alpha/rmabill/rmabill101c/src/costing1.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: costing1.qzs >> compare_source.log
diff costing1.qzs /alpha/rmabill/rmabill101c/src/costing1.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: costing10.qzs >> compare_source.log
diff costing10.qzs /alpha/rmabill/rmabill101c/src/costing10.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: costing11.qts >> compare_source.log
diff costing11.qts /alpha/rmabill/rmabill101c/src/costing11.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: costing11.qzs >> compare_source.log
diff costing11.qzs /alpha/rmabill/rmabill101c/src/costing11.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: costing11_dtl.qts >> compare_source.log
diff costing11_dtl.qts /alpha/rmabill/rmabill101c/src/costing11_dtl.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: costing1_bkp.qts >> compare_source.log
diff costing1_bkp.qts /alpha/rmabill/rmabill101c/src/costing1_bkp.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: costing1_noweb.qts >> compare_source.log
diff costing1_noweb.qts /alpha/rmabill/rmabill101c/src/costing1_noweb.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: costing1_old.qts >> compare_source.log
diff costing1_old.qts /alpha/rmabill/rmabill101c/src/costing1_old.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: costing1b_yas_orig.qts >> compare_source.log
diff costing1b_yas_orig.qts /alpha/rmabill/rmabill101c/src/costing1b_yas_orig.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: costing2.qts >> compare_source.log
diff costing2.qts /alpha/rmabill/rmabill101c/src/costing2.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: costing2_before_debug_subfile.qts >> compare_source.log
diff costing2_before_debug_subfile.qts /alpha/rmabill/rmabill101c/src/costing2_before_debug_subfile.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: costing2_noweb.qts >> compare_source.log
diff costing2_noweb.qts /alpha/rmabill/rmabill101c/src/costing2_noweb.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: costing2_noweb_part2.qts >> compare_source.log
diff costing2_noweb_part2.qts /alpha/rmabill/rmabill101c/src/costing2_noweb_part2.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: costing2_uses_f002_before_f088.qts >> compare_source.log
diff costing2_uses_f002_before_f088.qts /alpha/rmabill/rmabill101c/src/costing2_uses_f002_before_f088.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: costing3.qts >> compare_source.log
diff costing3.qts /alpha/rmabill/rmabill101c/src/costing3.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: costing3_long_version.qts >> compare_source.log
diff costing3_long_version.qts /alpha/rmabill/rmabill101c/src/costing3_long_version.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: costing4.qts >> compare_source.log
diff costing4.qts /alpha/rmabill/rmabill101c/src/costing4.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: costing5.qts >> compare_source.log
diff costing5.qts /alpha/rmabill/rmabill101c/src/costing5.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: costing5_noweb.qts >> compare_source.log
diff costing5_noweb.qts /alpha/rmabill/rmabill101c/src/costing5_noweb.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: costing6_man_rej_dtl.qts >> compare_source.log
diff costing6_man_rej_dtl.qts /alpha/rmabill/rmabill101c/src/costing6_man_rej_dtl.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: costing6_noweb.qts >> compare_source.log
diff costing6_noweb.qts /alpha/rmabill/rmabill101c/src/costing6_noweb.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: costing6a_man_rej_dtl.qzs >> compare_source.log
diff costing6a_man_rej_dtl.qzs /alpha/rmabill/rmabill101c/src/costing6a_man_rej_dtl.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: costing7.qts >> compare_source.log
diff costing7.qts /alpha/rmabill/rmabill101c/src/costing7.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: costing8_moved_to_src.qzs >> compare_source.log
diff costing8_moved_to_src.qzs /alpha/rmabill/rmabill101c/src/costing8_moved_to_src.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: costing8_yas_orig.qzs >> compare_source.log
diff costing8_yas_orig.qzs /alpha/rmabill/rmabill101c/src/costing8_yas_orig.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: costing_claims.qzs >> compare_source.log
diff costing_claims.qzs /alpha/rmabill/rmabill101c/src/costing_claims.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: costing_claims1.qzs >> compare_source.log
diff costing_claims1.qzs /alpha/rmabill/rmabill101c/src/costing_claims1.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: costing_doctors.qzs >> compare_source.log
diff costing_doctors.qzs /alpha/rmabill/rmabill101c/src/costing_doctors.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: costreject.qzs >> compare_source.log
diff costreject.qzs /alpha/rmabill/rmabill101c/src/costreject.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: costrev.qzs >> compare_source.log
diff costrev.qzs /alpha/rmabill/rmabill101c/src/costrev.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: costrev22.qzs >> compare_source.log
diff costrev22.qzs /alpha/rmabill/rmabill101c/src/costrev22.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: costrev60.qzs >> compare_source.log
diff costrev60.qzs /alpha/rmabill/rmabill101c/src/costrev60.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: costrev80to96.qzs >> compare_source.log
diff costrev80to96.qzs /alpha/rmabill/rmabill101c/src/costrev80to96.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: costrev81.qzs >> compare_source.log
diff costrev81.qzs /alpha/rmabill/rmabill101c/src/costrev81.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: costrevhis.qzs >> compare_source.log
diff costrevhis.qzs /alpha/rmabill/rmabill101c/src/costrevhis.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: create_claims_sub.qzs >> compare_source.log
diff create_claims_sub.qzs /alpha/rmabill/rmabill101c/src/create_claims_sub.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: create_claims_sub_60.qzs >> compare_source.log
diff create_claims_sub_60.qzs /alpha/rmabill/rmabill101c/src/create_claims_sub_60.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: create_claims_sub_80.qzs >> compare_source.log
diff create_claims_sub_80.qzs /alpha/rmabill/rmabill101c/src/create_claims_sub_80.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: create_claims_sub_81.qzs >> compare_source.log
diff create_claims_sub_81.qzs /alpha/rmabill/rmabill101c/src/create_claims_sub_81.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: create_claims_sub_82.qzs >> compare_source.log
diff create_claims_sub_82.qzs /alpha/rmabill/rmabill101c/src/create_claims_sub_82.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: create_claims_sub_83.qzs >> compare_source.log
diff create_claims_sub_83.qzs /alpha/rmabill/rmabill101c/src/create_claims_sub_83.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: create_claims_sub_91.qzs >> compare_source.log
diff create_claims_sub_91.qzs /alpha/rmabill/rmabill101c/src/create_claims_sub_91.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: create_claims_sub_92.qzs >> compare_source.log
diff create_claims_sub_92.qzs /alpha/rmabill/rmabill101c/src/create_claims_sub_92.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: create_claims_sub_93.qzs >> compare_source.log
diff create_claims_sub_93.qzs /alpha/rmabill/rmabill101c/src/create_claims_sub_93.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: create_claims_sub_94.qzs >> compare_source.log
diff create_claims_sub_94.qzs /alpha/rmabill/rmabill101c/src/create_claims_sub_94.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: create_claims_sub_95.qzs >> compare_source.log
diff create_claims_sub_95.qzs /alpha/rmabill/rmabill101c/src/create_claims_sub_95.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: create_claims_sub_96.qzs >> compare_source.log
diff create_claims_sub_96.qzs /alpha/rmabill/rmabill101c/src/create_claims_sub_96.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: create_claims_suba.qzs >> compare_source.log
diff create_claims_suba.qzs /alpha/rmabill/rmabill101c/src/create_claims_suba.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: createf086.qts >> compare_source.log
diff createf086.qts /alpha/rmabill/rmabill101c/src/createf086.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: d003_1.qks >> compare_source.log
diff d003_1.qks /alpha/rmabill/rmabill101c/src/d003_1.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: d003_1a.qks >> compare_source.log
diff d003_1a.qks /alpha/rmabill/rmabill101c/src/d003_1a.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: d020.qks >> compare_source.log
diff d020.qks /alpha/rmabill/rmabill101c/src/d020.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: d020a.qks >> compare_source.log
diff d020a.qks /alpha/rmabill/rmabill101c/src/d020a.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: d020b.qks >> compare_source.log
diff d020b.qks /alpha/rmabill/rmabill101c/src/d020b.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: d084.qks >> compare_source.log
diff d084.qks /alpha/rmabill/rmabill101c/src/d084.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: d085.qks >> compare_source.log
diff d085.qks /alpha/rmabill/rmabill101c/src/d085.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: d087.qks >> compare_source.log
diff d087.qks /alpha/rmabill/rmabill101c/src/d087.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: d087_dtl.qks >> compare_source.log
diff d087_dtl.qks /alpha/rmabill/rmabill101c/src/d087_dtl.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: d087_hdr.qks >> compare_source.log
diff d087_hdr.qks /alpha/rmabill/rmabill101c/src/d087_hdr.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: d110.qks >> compare_source.log
diff d110.qks /alpha/rmabill/rmabill101c/src/d110.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: d112.qks >> compare_source.log
diff d112.qks /alpha/rmabill/rmabill101c/src/d112.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: d112a.qks >> compare_source.log
diff d112a.qks /alpha/rmabill/rmabill101c/src/d112a.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: d113.qks >> compare_source.log
diff d113.qks /alpha/rmabill/rmabill101c/src/d113.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: d114.qks >> compare_source.log
diff d114.qks /alpha/rmabill/rmabill101c/src/d114.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: d118.qks >> compare_source.log
diff d118.qks /alpha/rmabill/rmabill101c/src/d118.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: d119.qks >> compare_source.log
diff d119.qks /alpha/rmabill/rmabill101c/src/d119.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: d199.qks >> compare_source.log
diff d199.qks /alpha/rmabill/rmabill101c/src/d199.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: d705.qks >> compare_source.log
diff d705.qks /alpha/rmabill/rmabill101c/src/d705.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: d705_20000215.qks >> compare_source.log
diff d705_20000215.qks /alpha/rmabill/rmabill101c/src/d705_20000215.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: d705_6mths.qks >> compare_source.log
diff d705_6mths.qks /alpha/rmabill/rmabill101c/src/d705_6mths.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: d705a.qks >> compare_source.log
diff d705a.qks /alpha/rmabill/rmabill101c/src/d705a.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: d705a_20000215.qks >> compare_source.log
diff d705a_20000215.qks /alpha/rmabill/rmabill101c/src/d705a_20000215.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: d705a_bk1.qks >> compare_source.log
diff d705a_bk1.qks /alpha/rmabill/rmabill101c/src/d705a_bk1.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: d705b.qks >> compare_source.log
diff d705b.qks /alpha/rmabill/rmabill101c/src/d705b.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: d705c.qks >> compare_source.log
diff d705c.qks /alpha/rmabill/rmabill101c/src/d705c.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: d713.qks >> compare_source.log
diff d713.qks /alpha/rmabill/rmabill101c/src/d713.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: debug_u933a.qzs >> compare_source.log
diff debug_u933a.qzs /alpha/rmabill/rmabill101c/src/debug_u933a.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: debugu114.qzs >> compare_source.log
diff debugu114.qzs /alpha/rmabill/rmabill101c/src/debugu114.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: debugu115a_comp_code.qzs >> compare_source.log
diff debugu115a_comp_code.qzs /alpha/rmabill/rmabill101c/src/debugu115a_comp_code.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: debugu115a_doc_nbr.qzs >> compare_source.log
diff debugu115a_doc_nbr.qzs /alpha/rmabill/rmabill101c/src/debugu115a_doc_nbr.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: debugu116.qzs >> compare_source.log
diff debugu116.qzs /alpha/rmabill/rmabill101c/src/debugu116.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dg2pc1_use_code.qts >> compare_source.log
diff dg2pc1_use_code.qts /alpha/rmabill/rmabill101c/src/dg2pc1_use_code.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dg2pc1a.qts >> compare_source.log
diff dg2pc1a.qts /alpha/rmabill/rmabill101c/src/dg2pc1a.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dg2pc1b.qts >> compare_source.log
diff dg2pc1b.qts /alpha/rmabill/rmabill101c/src/dg2pc1b.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dg2pc1c.qts >> compare_source.log
diff dg2pc1c.qts /alpha/rmabill/rmabill101c/src/dg2pc1c.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: doc_term0.qzs >> compare_source.log
diff doc_term0.qzs /alpha/rmabill/rmabill101c/src/doc_term0.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: docj.qzs >> compare_source.log
diff docj.qzs /alpha/rmabill/rmabill101c/src/docj.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: docohip.qzs >> compare_source.log
diff docohip.qzs /alpha/rmabill/rmabill101c/src/docohip.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: docpart.qzs >> compare_source.log
diff docpart.qzs /alpha/rmabill/rmabill101c/src/docpart.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: docpaycode4.qzs >> compare_source.log
diff docpaycode4.qzs /alpha/rmabill/rmabill101c/src/docpaycode4.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: docrev-tphistory-bkp.qzs >> compare_source.log
diff docrev-tphistory-bkp.qzs /alpha/rmabill/rmabill101c/src/docrev-tphistory-bkp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: docrev-tphistory.qts >> compare_source.log
diff docrev-tphistory.qts /alpha/rmabill/rmabill101c/src/docrev-tphistory.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: docrev-tphistory.qzs >> compare_source.log
diff docrev-tphistory.qzs /alpha/rmabill/rmabill101c/src/docrev-tphistory.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: docrev.qzs >> compare_source.log
diff docrev.qzs /alpha/rmabill/rmabill101c/src/docrev.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: docrev_history.qzs >> compare_source.log
diff docrev_history.qzs /alpha/rmabill/rmabill101c/src/docrev_history.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: docrevhistory.qts >> compare_source.log
diff docrevhistory.qts /alpha/rmabill/rmabill101c/src/docrevhistory.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: docrevhistory.qzs >> compare_source.log
diff docrevhistory.qzs /alpha/rmabill/rmabill101c/src/docrevhistory.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: docrevhistory_bkp.qzs >> compare_source.log
diff docrevhistory_bkp.qzs /alpha/rmabill/rmabill101c/src/docrevhistory_bkp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: docrevhistory_final.qzs >> compare_source.log
diff docrevhistory_final.qzs /alpha/rmabill/rmabill101c/src/docrevhistory_final.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: docthisyear.qzs >> compare_source.log
diff docthisyear.qzs /alpha/rmabill/rmabill101c/src/docthisyear.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: doctor_dept9.qzs >> compare_source.log
diff doctor_dept9.qzs /alpha/rmabill/rmabill101c/src/doctor_dept9.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: doctordump.qzs >> compare_source.log
diff doctordump.qzs /alpha/rmabill/rmabill101c/src/doctordump.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: doctorlist.qzs >> compare_source.log
diff doctorlist.qzs /alpha/rmabill/rmabill101c/src/doctorlist.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: doctorpart.qzs >> compare_source.log
diff doctorpart.qzs /alpha/rmabill/rmabill101c/src/doctorpart.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: doctors.qzs >> compare_source.log
diff doctors.qzs /alpha/rmabill/rmabill101c/src/doctors.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: doctors60.qzs >> compare_source.log
diff doctors60.qzs /alpha/rmabill/rmabill101c/src/doctors60.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: doctors_cs.qzs >> compare_source.log
diff doctors_cs.qzs /alpha/rmabill/rmabill101c/src/doctors_cs.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: down_f084.qts >> compare_source.log
diff down_f084.qts /alpha/rmabill/rmabill101c/src/down_f084.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: down_f087.qts >> compare_source.log
diff down_f087.qts /alpha/rmabill/rmabill101c/src/down_f087.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: down_f088.qts >> compare_source.log
diff down_f088.qts /alpha/rmabill/rmabill101c/src/down_f088.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: down_f987.qts >> compare_source.log
diff down_f987.qts /alpha/rmabill/rmabill101c/src/down_f987.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: downf020full.qzs >> compare_source.log
diff downf020full.qzs /alpha/rmabill/rmabill101c/src/downf020full.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dump.qzs >> compare_source.log
diff dump.qzs /alpha/rmabill/rmabill101c/src/dump.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dump91.qzs >> compare_source.log
diff dump91.qzs /alpha/rmabill/rmabill101c/src/dump91.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dump98.qzs >> compare_source.log
diff dump98.qzs /alpha/rmabill/rmabill101c/src/dump98.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dump_confidential_claims.qzs >> compare_source.log
diff dump_confidential_claims.qzs /alpha/rmabill/rmabill101c/src/dump_confidential_claims.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dump_costing2.qzs >> compare_source.log
diff dump_costing2.qzs /alpha/rmabill/rmabill101c/src/dump_costing2.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dump_f001_by_clinic_ped.qzs >> compare_source.log
diff dump_f001_by_clinic_ped.qzs /alpha/rmabill/rmabill101c/src/dump_f001_by_clinic_ped.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dump_f001_by_doctor.qzs >> compare_source.log
diff dump_f001_by_doctor.qzs /alpha/rmabill/rmabill101c/src/dump_f001_by_doctor.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dump_f050.qzs >> compare_source.log
diff dump_f050.qzs /alpha/rmabill/rmabill101c/src/dump_f050.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dump_f050hist.qzs >> compare_source.log
diff dump_f050hist.qzs /alpha/rmabill/rmabill101c/src/dump_f050hist.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dump_f050tp.qzs >> compare_source.log
diff dump_f050tp.qzs /alpha/rmabill/rmabill101c/src/dump_f050tp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dump_f050tphist.qzs >> compare_source.log
diff dump_f050tphist.qzs /alpha/rmabill/rmabill101c/src/dump_f050tphist.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dump_f083.qzs >> compare_source.log
diff dump_f083.qzs /alpha/rmabill/rmabill101c/src/dump_f083.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dump_f084.qzs >> compare_source.log
diff dump_f084.qzs /alpha/rmabill/rmabill101c/src/dump_f084.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dump_f086_f002_f010.qzs >> compare_source.log
diff dump_f086_f002_f010.qzs /alpha/rmabill/rmabill101c/src/dump_f086_f002_f010.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dump_f087.qzs >> compare_source.log
diff dump_f087.qzs /alpha/rmabill/rmabill101c/src/dump_f087.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dump_f088_hdr.qzs >> compare_source.log
diff dump_f088_hdr.qzs /alpha/rmabill/rmabill101c/src/dump_f088_hdr.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dump_f190_1.qzs >> compare_source.log
diff dump_f190_1.qzs /alpha/rmabill/rmabill101c/src/dump_f190_1.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dump_f190_2.qzs >> compare_source.log
diff dump_f190_2.qzs /alpha/rmabill/rmabill101c/src/dump_f190_2.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dump_f190_3.qzs >> compare_source.log
diff dump_f190_3.qzs /alpha/rmabill/rmabill101c/src/dump_f190_3.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dump_fix_claims.qzs >> compare_source.log
diff dump_fix_claims.qzs /alpha/rmabill/rmabill101c/src/dump_fix_claims.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dump_r085_link_pat.qzs >> compare_source.log
diff dump_r085_link_pat.qzs /alpha/rmabill/rmabill101c/src/dump_r085_link_pat.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dump_r120aa.qzs >> compare_source.log
diff dump_r120aa.qzs /alpha/rmabill/rmabill101c/src/dump_r120aa.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dump_select_t4.qzs >> compare_source.log
diff dump_select_t4.qzs /alpha/rmabill/rmabill101c/src/dump_select_t4.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dump_susp_prices.qzs >> compare_source.log
diff dump_susp_prices.qzs /alpha/rmabill/rmabill101c/src/dump_susp_prices.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dump_tech.qzs >> compare_source.log
diff dump_tech.qzs /alpha/rmabill/rmabill101c/src/dump_tech.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dump_tmp_counters_alpha.qzs >> compare_source.log
diff dump_tmp_counters_alpha.qzs /alpha/rmabill/rmabill101c/src/dump_tmp_counters_alpha.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dump_u020a.qzs >> compare_source.log
diff dump_u020a.qzs /alpha/rmabill/rmabill101c/src/dump_u020a.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dump_u119_f110.qzs >> compare_source.log
diff dump_u119_f110.qzs /alpha/rmabill/rmabill101c/src/dump_u119_f110.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dump_u119_f110_transferred.qzs >> compare_source.log
diff dump_u119_f110_transferred.qzs /alpha/rmabill/rmabill101c/src/dump_u119_f110_transferred.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dump_u933_debug.qzs >> compare_source.log
diff dump_u933_debug.qzs /alpha/rmabill/rmabill101c/src/dump_u933_debug.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dump_u933_totals.qzs >> compare_source.log
diff dump_u933_totals.qzs /alpha/rmabill/rmabill101c/src/dump_u933_totals.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dump_u933a1.qzs >> compare_source.log
diff dump_u933a1.qzs /alpha/rmabill/rmabill101c/src/dump_u933a1.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dump_u933a2.qzs >> compare_source.log
diff dump_u933a2.qzs /alpha/rmabill/rmabill101c/src/dump_u933a2.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dump_u933a_doc.qzs >> compare_source.log
diff dump_u933a_doc.qzs /alpha/rmabill/rmabill101c/src/dump_u933a_doc.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dump_u933a_doc_summarized.qzs >> compare_source.log
diff dump_u933a_doc_summarized.qzs /alpha/rmabill/rmabill101c/src/dump_u933a_doc_summarized.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dumpf002_claim_range.qzs >> compare_source.log
diff dumpf002_claim_range.qzs /alpha/rmabill/rmabill101c/src/dumpf002_claim_range.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dumpf002_f010_via_acr.qts >> compare_source.log
diff dumpf002_f010_via_acr.qts /alpha/rmabill/rmabill101c/src/dumpf002_f010_via_acr.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dumpf002_f010_via_ikey.qts >> compare_source.log
diff dumpf002_f010_via_ikey.qts /alpha/rmabill/rmabill101c/src/dumpf002_f010_via_ikey.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dumpf002_missing_f010_2_fix_claims.qts >> compare_source.log
diff dumpf002_missing_f010_2_fix_claims.qts /alpha/rmabill/rmabill101c/src/dumpf002_missing_f010_2_fix_claims.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dumpf002_missing_f010_ikey.qts >> compare_source.log
diff dumpf002_missing_f010_ikey.qts /alpha/rmabill/rmabill101c/src/dumpf002_missing_f010_ikey.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dumpf002_seq.qzs >> compare_source.log
diff dumpf002_seq.qzs /alpha/rmabill/rmabill101c/src/dumpf002_seq.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dumpf002_seq_f050tpProb.qzs >> compare_source.log
diff dumpf002_seq_f050tpProb.qzs /alpha/rmabill/rmabill101c/src/dumpf002_seq_f050tpProb.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dumpf002_single_claim.qzs >> compare_source.log
diff dumpf002_single_claim.qzs /alpha/rmabill/rmabill101c/src/dumpf002_single_claim.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dumpf002_via_bkey.qzs >> compare_source.log
diff dumpf002_via_bkey.qzs /alpha/rmabill/rmabill101c/src/dumpf002_via_bkey.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dumpf002_via_claim_nbr.qzs >> compare_source.log
diff dumpf002_via_claim_nbr.qzs /alpha/rmabill/rmabill101c/src/dumpf002_via_claim_nbr.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dumpf002_via_pkey.qzs >> compare_source.log
diff dumpf002_via_pkey.qzs /alpha/rmabill/rmabill101c/src/dumpf002_via_pkey.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dumpf002_via_pkey_range.qzs >> compare_source.log
diff dumpf002_via_pkey_range.qzs /alpha/rmabill/rmabill101c/src/dumpf002_via_pkey_range.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dumpf010_acr_parm.qzs >> compare_source.log
diff dumpf010_acr_parm.qzs /alpha/rmabill/rmabill101c/src/dumpf010_acr_parm.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dumpf010_hnbr_parm.qzs >> compare_source.log
diff dumpf010_hnbr_parm.qzs /alpha/rmabill/rmabill101c/src/dumpf010_hnbr_parm.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dumpf010_ikey_parm.qzs >> compare_source.log
diff dumpf010_ikey_parm.qzs /alpha/rmabill/rmabill101c/src/dumpf010_ikey_parm.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dumpf010_ikey_range.qzs >> compare_source.log
diff dumpf010_ikey_range.qzs /alpha/rmabill/rmabill101c/src/dumpf010_ikey_range.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dumpf040.qzs >> compare_source.log
diff dumpf040.qzs /alpha/rmabill/rmabill101c/src/dumpf040.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dumpf119.qzs >> compare_source.log
diff dumpf119.qzs /alpha/rmabill/rmabill101c/src/dumpf119.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dumpf119ytd.qzs >> compare_source.log
diff dumpf119ytd.qzs /alpha/rmabill/rmabill101c/src/dumpf119ytd.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dycomgroups.qks >> compare_source.log
diff dycomgroups.qks /alpha/rmabill/rmabill101c/src/dycomgroups.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: dymenu.qks >> compare_source.log
diff dymenu.qks /alpha/rmabill/rmabill101c/src/dymenu.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: effective.qzs >> compare_source.log
diff effective.qzs /alpha/rmabill/rmabill101c/src/effective.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: extra.qzs >> compare_source.log
diff extra.qzs /alpha/rmabill/rmabill101c/src/extra.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: f001.qks >> compare_source.log
diff f001.qks /alpha/rmabill/rmabill101c/src/f001.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: f001status.qzs >> compare_source.log
diff f001status.qzs /alpha/rmabill/rmabill101c/src/f001status.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: f020_active.qzs >> compare_source.log
diff f020_active.qzs /alpha/rmabill/rmabill101c/src/f020_active.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: f020_down.qts >> compare_source.log
diff f020_down.qts /alpha/rmabill/rmabill101c/src/f020_down.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: f020_next_batch_save.qts >> compare_source.log
diff f020_next_batch_save.qts /alpha/rmabill/rmabill101c/src/f020_next_batch_save.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: f020_next_batch_update.qts >> compare_source.log
diff f020_next_batch_update.qts /alpha/rmabill/rmabill101c/src/f020_next_batch_update.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: f020_select_active.qzs >> compare_source.log
diff f020_select_active.qzs /alpha/rmabill/rmabill101c/src/f020_select_active.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: f020_up.qts >> compare_source.log
diff f020_up.qts /alpha/rmabill/rmabill101c/src/f020_up.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: f020_zero.qts >> compare_source.log
diff f020_zero.qts /alpha/rmabill/rmabill101c/src/f020_zero.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: f020rec.qts >> compare_source.log
diff f020rec.qts /alpha/rmabill/rmabill101c/src/f020rec.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: f050hist.qzs >> compare_source.log
diff f050hist.qzs /alpha/rmabill/rmabill101c/src/f050hist.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: f050ma1.qts >> compare_source.log
diff f050ma1.qts /alpha/rmabill/rmabill101c/src/f050ma1.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: f050ma1_excel.qts >> compare_source.log
diff f050ma1_excel.qts /alpha/rmabill/rmabill101c/src/f050ma1_excel.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: f050ma1_fake_doc.qts >> compare_source.log
diff f050ma1_fake_doc.qts /alpha/rmabill/rmabill101c/src/f050ma1_fake_doc.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: f050ma1_lastyear.qts >> compare_source.log
diff f050ma1_lastyear.qts /alpha/rmabill/rmabill101c/src/f050ma1_lastyear.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: f050tpyas.qzs >> compare_source.log
diff f050tpyas.qzs /alpha/rmabill/rmabill101c/src/f050tpyas.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: f050tpyashist.qzs >> compare_source.log
diff f050tpyashist.qzs /alpha/rmabill/rmabill101c/src/f050tpyashist.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: f050yas.qzs >> compare_source.log
diff f050yas.qzs /alpha/rmabill/rmabill101c/src/f050yas.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: f050yashist.qzs >> compare_source.log
diff f050yashist.qzs /alpha/rmabill/rmabill101c/src/f050yashist.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: f051.qzs >> compare_source.log
diff f051.qzs /alpha/rmabill/rmabill101c/src/f051.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: f051_dailyreverse.qts >> compare_source.log
diff f051_dailyreverse.qts /alpha/rmabill/rmabill101c/src/f051_dailyreverse.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: f060_mth_ceil.qks >> compare_source.log
diff f060_mth_ceil.qks /alpha/rmabill/rmabill101c/src/f060_mth_ceil.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: f060_mth_exp.qks >> compare_source.log
diff f060_mth_exp.qks /alpha/rmabill/rmabill101c/src/f060_mth_exp.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: f071-drgoodacre.qzs >> compare_source.log
diff f071-drgoodacre.qzs /alpha/rmabill/rmabill101c/src/f071-drgoodacre.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: f087-stjoes.qzs >> compare_source.log
diff f087-stjoes.qzs /alpha/rmabill/rmabill101c/src/f087-stjoes.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: f090_add_rec.qts >> compare_source.log
diff f090_add_rec.qts /alpha/rmabill/rmabill101c/src/f090_add_rec.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: f094messages.qzs >> compare_source.log
diff f094messages.qzs /alpha/rmabill/rmabill101c/src/f094messages.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: f923_down.qts >> compare_source.log
diff f923_down.qts /alpha/rmabill/rmabill101c/src/f923_down.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: f923_up.qts >> compare_source.log
diff f923_up.qts /alpha/rmabill/rmabill101c/src/f923_up.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: f932_up.qts >> compare_source.log
diff f932_up.qts /alpha/rmabill/rmabill101c/src/f932_up.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: filer001a.qzs >> compare_source.log
diff filer001a.qzs /alpha/rmabill/rmabill101c/src/filer001a.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: filer001b.qzs >> compare_source.log
diff filer001b.qzs /alpha/rmabill/rmabill101c/src/filer001b.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: filer001c.qzs >> compare_source.log
diff filer001c.qzs /alpha/rmabill/rmabill101c/src/filer001c.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: fix_adj_claim_file_1.qts >> compare_source.log
diff fix_adj_claim_file_1.qts /alpha/rmabill/rmabill101c/src/fix_adj_claim_file_1.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: fix_adj_claim_file_2.qts >> compare_source.log
diff fix_adj_claim_file_2.qts /alpha/rmabill/rmabill101c/src/fix_adj_claim_file_2.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: fix_seq_nbrs.qts >> compare_source.log
diff fix_seq_nbrs.qts /alpha/rmabill/rmabill101c/src/fix_seq_nbrs.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: h020a.qks >> compare_source.log
diff h020a.qks /alpha/rmabill/rmabill101c/src/h020a.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: h110.qks >> compare_source.log
diff h110.qks /alpha/rmabill/rmabill101c/src/h110.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: h112.qks >> compare_source.log
diff h112.qks /alpha/rmabill/rmabill101c/src/h112.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: h112a.qks >> compare_source.log
diff h112a.qks /alpha/rmabill/rmabill101c/src/h112a.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: h113.qks >> compare_source.log
diff h113.qks /alpha/rmabill/rmabill101c/src/h113.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: h119.qks >> compare_source.log
diff h119.qks /alpha/rmabill/rmabill101c/src/h119.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: holdback.qzs >> compare_source.log
diff holdback.qzs /alpha/rmabill/rmabill101c/src/holdback.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: holdbk1.qzs >> compare_source.log
diff holdbk1.qzs /alpha/rmabill/rmabill101c/src/holdbk1.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: holdbk2.qzs >> compare_source.log
diff holdbk2.qzs /alpha/rmabill/rmabill101c/src/holdbk2.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: holdbk3.qzs >> compare_source.log
diff holdbk3.qzs /alpha/rmabill/rmabill101c/src/holdbk3.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: holdbk3orig.qzs >> compare_source.log
diff holdbk3orig.qzs /alpha/rmabill/rmabill101c/src/holdbk3orig.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: holdbk4.qts >> compare_source.log
diff holdbk4.qts /alpha/rmabill/rmabill101c/src/holdbk4.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: holdbk5.qzs >> compare_source.log
diff holdbk5.qzs /alpha/rmabill/rmabill101c/src/holdbk5.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: holdbk5orig.qzs >> compare_source.log
diff holdbk5orig.qzs /alpha/rmabill/rmabill101c/src/holdbk5orig.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: holdbk6.qts >> compare_source.log
diff holdbk6.qts /alpha/rmabill/rmabill101c/src/holdbk6.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: holdbk6.qzs >> compare_source.log
diff holdbk6.qzs /alpha/rmabill/rmabill101c/src/holdbk6.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: icu_gather_data.qts >> compare_source.log
diff icu_gather_data.qts /alpha/rmabill/rmabill101c/src/icu_gather_data.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: in01.qks >> compare_source.log
diff in01.qks /alpha/rmabill/rmabill101c/src/in01.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: in01a.qks >> compare_source.log
diff in01a.qks /alpha/rmabill/rmabill101c/src/in01a.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: in01b.qks >> compare_source.log
diff in01b.qks /alpha/rmabill/rmabill101c/src/in01b.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: in01c.qks >> compare_source.log
diff in01c.qks /alpha/rmabill/rmabill101c/src/in01c.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: in01d.qks >> compare_source.log
diff in01d.qks /alpha/rmabill/rmabill101c/src/in01d.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: k.qzs >> compare_source.log
diff k.qzs /alpha/rmabill/rmabill101c/src/k.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: k_day.qzs >> compare_source.log
diff k_day.qzs /alpha/rmabill/rmabill101c/src/k_day.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: kathyf001status.qzs >> compare_source.log
diff kathyf001status.qzs /alpha/rmabill/rmabill101c/src/kathyf001status.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: locations.qzs >> compare_source.log
diff locations.qzs /alpha/rmabill/rmabill101c/src/locations.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m010.qks >> compare_source.log
diff m010.qks /alpha/rmabill/rmabill101c/src/m010.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m010_acr.qks >> compare_source.log
diff m010_acr.qks /alpha/rmabill/rmabill101c/src/m010_acr.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m010_yas.qks >> compare_source.log
diff m010_yas.qks /alpha/rmabill/rmabill101c/src/m010_yas.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m010ver.qks >> compare_source.log
diff m010ver.qks /alpha/rmabill/rmabill101c/src/m010ver.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m020.qks >> compare_source.log
diff m020.qks /alpha/rmabill/rmabill101c/src/m020.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m021.qks >> compare_source.log
diff m021.qks /alpha/rmabill/rmabill101c/src/m021.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m025.qks >> compare_source.log
diff m025.qks /alpha/rmabill/rmabill101c/src/m025.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m074.qks >> compare_source.log
diff m074.qks /alpha/rmabill/rmabill101c/src/m074.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m075.qks >> compare_source.log
diff m075.qks /alpha/rmabill/rmabill101c/src/m075.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m083.qks >> compare_source.log
diff m083.qks /alpha/rmabill/rmabill101c/src/m083.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m084a.qks >> compare_source.log
diff m084a.qks /alpha/rmabill/rmabill101c/src/m084a.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m084b.qks >> compare_source.log
diff m084b.qks /alpha/rmabill/rmabill101c/src/m084b.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m088.qks >> compare_source.log
diff m088.qks /alpha/rmabill/rmabill101c/src/m088.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m088_1.qks >> compare_source.log
diff m088_1.qks /alpha/rmabill/rmabill101c/src/m088_1.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m088_1a.qks >> compare_source.log
diff m088_1a.qks /alpha/rmabill/rmabill101c/src/m088_1a.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m089.qks >> compare_source.log
diff m089.qks /alpha/rmabill/rmabill101c/src/m089.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m090.qks >> compare_source.log
diff m090.qks /alpha/rmabill/rmabill101c/src/m090.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m090a.qks >> compare_source.log
diff m090a.qks /alpha/rmabill/rmabill101c/src/m090a.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m090f.qks >> compare_source.log
diff m090f.qks /alpha/rmabill/rmabill101c/src/m090f.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m090g.qks >> compare_source.log
diff m090g.qks /alpha/rmabill/rmabill101c/src/m090g.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m091.qks >> compare_source.log
diff m091.qks /alpha/rmabill/rmabill101c/src/m091.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m092.qks >> compare_source.log
diff m092.qks /alpha/rmabill/rmabill101c/src/m092.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m093.qks >> compare_source.log
diff m093.qks /alpha/rmabill/rmabill101c/src/m093.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m097.qks >> compare_source.log
diff m097.qks /alpha/rmabill/rmabill101c/src/m097.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m098.qks >> compare_source.log
diff m098.qks /alpha/rmabill/rmabill101c/src/m098.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m100.qks >> compare_source.log
diff m100.qks /alpha/rmabill/rmabill101c/src/m100.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m101.qks >> compare_source.log
diff m101.qks /alpha/rmabill/rmabill101c/src/m101.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m102.qks >> compare_source.log
diff m102.qks /alpha/rmabill/rmabill101c/src/m102.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m113.qks >> compare_source.log
diff m113.qks /alpha/rmabill/rmabill101c/src/m113.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m123.qks >> compare_source.log
diff m123.qks /alpha/rmabill/rmabill101c/src/m123.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m190.qks >> compare_source.log
diff m190.qks /alpha/rmabill/rmabill101c/src/m190.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m190a.qks >> compare_source.log
diff m190a.qks /alpha/rmabill/rmabill101c/src/m190a.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m191.qks >> compare_source.log
diff m191.qks /alpha/rmabill/rmabill101c/src/m191.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m199.qks >> compare_source.log
diff m199.qks /alpha/rmabill/rmabill101c/src/m199.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m902.qks >> compare_source.log
diff m902.qks /alpha/rmabill/rmabill101c/src/m902.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m907.qks >> compare_source.log
diff m907.qks /alpha/rmabill/rmabill101c/src/m907.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m908.qks >> compare_source.log
diff m908.qks /alpha/rmabill/rmabill101c/src/m908.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m913.qks >> compare_source.log
diff m913.qks /alpha/rmabill/rmabill101c/src/m913.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m916.qks >> compare_source.log
diff m916.qks /alpha/rmabill/rmabill101c/src/m916.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m920.qks >> compare_source.log
diff m920.qks /alpha/rmabill/rmabill101c/src/m920.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m923.qks >> compare_source.log
diff m923.qks /alpha/rmabill/rmabill101c/src/m923.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m924.qks >> compare_source.log
diff m924.qks /alpha/rmabill/rmabill101c/src/m924.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m932.qks >> compare_source.log
diff m932.qks /alpha/rmabill/rmabill101c/src/m932.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m940.qks >> compare_source.log
diff m940.qks /alpha/rmabill/rmabill101c/src/m940.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: m941.qks >> compare_source.log
diff m941.qks /alpha/rmabill/rmabill101c/src/m941.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: maria_rejects.qzs >> compare_source.log
diff maria_rejects.qzs /alpha/rmabill/rmabill101c/src/maria_rejects.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: maria_rejects1.qts >> compare_source.log
diff maria_rejects1.qts /alpha/rmabill/rmabill101c/src/maria_rejects1.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: maria_rejects2.qts >> compare_source.log
diff maria_rejects2.qts /alpha/rmabill/rmabill101c/src/maria_rejects2.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: maria_rejects3.qzs >> compare_source.log
diff maria_rejects3.qzs /alpha/rmabill/rmabill101c/src/maria_rejects3.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: maria_rejects_withdtl.qzs >> compare_source.log
diff maria_rejects_withdtl.qzs /alpha/rmabill/rmabill101c/src/maria_rejects_withdtl.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: maria_rejects_yas.qzs >> compare_source.log
diff maria_rejects_yas.qzs /alpha/rmabill/rmabill101c/src/maria_rejects_yas.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: mm_f020.qzs >> compare_source.log
diff mm_f020.qzs /alpha/rmabill/rmabill101c/src/mm_f020.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: moh1a.qts >> compare_source.log
diff moh1a.qts /alpha/rmabill/rmabill101c/src/moh1a.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: moh1a.qzs >> compare_source.log
diff moh1a.qzs /alpha/rmabill/rmabill101c/src/moh1a.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: moh1a_icu.qzs >> compare_source.log
diff moh1a_icu.qzs /alpha/rmabill/rmabill101c/src/moh1a_icu.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: moh1b.qzs >> compare_source.log
diff moh1b.qzs /alpha/rmabill/rmabill101c/src/moh1b.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: moh1b_icu.qzs >> compare_source.log
diff moh1b_icu.qzs /alpha/rmabill/rmabill101c/src/moh1b_icu.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: moh1c.qzs >> compare_source.log
diff moh1c.qzs /alpha/rmabill/rmabill101c/src/moh1c.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: moh1c_icu.qzs >> compare_source.log
diff moh1c_icu.qzs /alpha/rmabill/rmabill101c/src/moh1c_icu.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: moh1d.qzs >> compare_source.log
diff moh1d.qzs /alpha/rmabill/rmabill101c/src/moh1d.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: moh1d_icu.qzs >> compare_source.log
diff moh1d_icu.qzs /alpha/rmabill/rmabill101c/src/moh1d_icu.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: moh1e_icu.qzs >> compare_source.log
diff moh1e_icu.qzs /alpha/rmabill/rmabill101c/src/moh1e_icu.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: moh1f_icu.qzs >> compare_source.log
diff moh1f_icu.qzs /alpha/rmabill/rmabill101c/src/moh1f_icu.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: mohr.qzs >> compare_source.log
diff mohr.qzs /alpha/rmabill/rmabill101c/src/mohr.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: moira+r140_e.qzs >> compare_source.log
diff moira+r140_e.qzs /alpha/rmabill/rmabill101c/src/moira+r140_e.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: moira+r997.qzs >> compare_source.log
diff moira+r997.qzs /alpha/rmabill/rmabill101c/src/moira+r997.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: moira+u030b_part1.qts >> compare_source.log
diff moira+u030b_part1.qts /alpha/rmabill/rmabill101c/src/moira+u030b_part1.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: moira+u997.qts >> compare_source.log
diff moira+u997.qts /alpha/rmabill/rmabill101c/src/moira+u997.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: newcode.qzs >> compare_source.log
diff newcode.qzs /alpha/rmabill/rmabill101c/src/newcode.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: newu701.qts >> compare_source.log
diff newu701.qts /alpha/rmabill/rmabill101c/src/newu701.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: newu706a.qts >> compare_source.log
diff newu706a.qts /alpha/rmabill/rmabill101c/src/newu706a.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: nonblank98.qzs >> compare_source.log
diff nonblank98.qzs /alpha/rmabill/rmabill101c/src/nonblank98.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: norecord98.qzs >> compare_source.log
diff norecord98.qzs /alpha/rmabill/rmabill101c/src/norecord98.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: overagef119.qzs >> compare_source.log
diff overagef119.qzs /alpha/rmabill/rmabill101c/src/overagef119.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: patients.qzs >> compare_source.log
diff patients.qzs /alpha/rmabill/rmabill101c/src/patients.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: paycode4list.qzs >> compare_source.log
diff paycode4list.qzs /alpha/rmabill/rmabill101c/src/paycode4list.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: payrolllist.qzs >> compare_source.log
diff payrolllist.qzs /alpha/rmabill/rmabill101c/src/payrolllist.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm01.qks >> compare_source.log
diff pm01.qks /alpha/rmabill/rmabill101c/src/pm01.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm02.qks >> compare_source.log
diff pm02.qks /alpha/rmabill/rmabill101c/src/pm02.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm03.qks >> compare_source.log
diff pm03.qks /alpha/rmabill/rmabill101c/src/pm03.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm04.qks >> compare_source.log
diff pm04.qks /alpha/rmabill/rmabill101c/src/pm04.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm05.qks >> compare_source.log
diff pm05.qks /alpha/rmabill/rmabill101c/src/pm05.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm06.qks >> compare_source.log
diff pm06.qks /alpha/rmabill/rmabill101c/src/pm06.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm07.qks >> compare_source.log
diff pm07.qks /alpha/rmabill/rmabill101c/src/pm07.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm08.qks >> compare_source.log
diff pm08.qks /alpha/rmabill/rmabill101c/src/pm08.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm09.qks >> compare_source.log
diff pm09.qks /alpha/rmabill/rmabill101c/src/pm09.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm10.qks >> compare_source.log
diff pm10.qks /alpha/rmabill/rmabill101c/src/pm10.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm11.qks >> compare_source.log
diff pm11.qks /alpha/rmabill/rmabill101c/src/pm11.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm12.qks >> compare_source.log
diff pm12.qks /alpha/rmabill/rmabill101c/src/pm12.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm13.qzs >> compare_source.log
diff pm13.qzs /alpha/rmabill/rmabill101c/src/pm13.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm14.qzs >> compare_source.log
diff pm14.qzs /alpha/rmabill/rmabill101c/src/pm14.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm14a.qzs >> compare_source.log
diff pm14a.qzs /alpha/rmabill/rmabill101c/src/pm14a.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm14b.qzs >> compare_source.log
diff pm14b.qzs /alpha/rmabill/rmabill101c/src/pm14b.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm15.qzs >> compare_source.log
diff pm15.qzs /alpha/rmabill/rmabill101c/src/pm15.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm16.qzs >> compare_source.log
diff pm16.qzs /alpha/rmabill/rmabill101c/src/pm16.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm17.qzs >> compare_source.log
diff pm17.qzs /alpha/rmabill/rmabill101c/src/pm17.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm17_agfix.qzs >> compare_source.log
diff pm17_agfix.qzs /alpha/rmabill/rmabill101c/src/pm17_agfix.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm18.qzs >> compare_source.log
diff pm18.qzs /alpha/rmabill/rmabill101c/src/pm18.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm19.qzs >> compare_source.log
diff pm19.qzs /alpha/rmabill/rmabill101c/src/pm19.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm20.qzs >> compare_source.log
diff pm20.qzs /alpha/rmabill/rmabill101c/src/pm20.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm21.qzs >> compare_source.log
diff pm21.qzs /alpha/rmabill/rmabill101c/src/pm21.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm22.qzs >> compare_source.log
diff pm22.qzs /alpha/rmabill/rmabill101c/src/pm22.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm23.qzs >> compare_source.log
diff pm23.qzs /alpha/rmabill/rmabill101c/src/pm23.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm24.qts >> compare_source.log
diff pm24.qts /alpha/rmabill/rmabill101c/src/pm24.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm25.qzs >> compare_source.log
diff pm25.qzs /alpha/rmabill/rmabill101c/src/pm25.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm26.qzs >> compare_source.log
diff pm26.qzs /alpha/rmabill/rmabill101c/src/pm26.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm27.qzs >> compare_source.log
diff pm27.qzs /alpha/rmabill/rmabill101c/src/pm27.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm28.qzs >> compare_source.log
diff pm28.qzs /alpha/rmabill/rmabill101c/src/pm28.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm29.qzs >> compare_source.log
diff pm29.qzs /alpha/rmabill/rmabill101c/src/pm29.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm30.qks >> compare_source.log
diff pm30.qks /alpha/rmabill/rmabill101c/src/pm30.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm30.qzs >> compare_source.log
diff pm30.qzs /alpha/rmabill/rmabill101c/src/pm30.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm31.qks >> compare_source.log
diff pm31.qks /alpha/rmabill/rmabill101c/src/pm31.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm31_update.qks >> compare_source.log
diff pm31_update.qks /alpha/rmabill/rmabill101c/src/pm31_update.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm32.qks >> compare_source.log
diff pm32.qks /alpha/rmabill/rmabill101c/src/pm32.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm32.qzs >> compare_source.log
diff pm32.qzs /alpha/rmabill/rmabill101c/src/pm32.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm33.qks >> compare_source.log
diff pm33.qks /alpha/rmabill/rmabill101c/src/pm33.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm33.qts >> compare_source.log
diff pm33.qts /alpha/rmabill/rmabill101c/src/pm33.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm34.qts >> compare_source.log
diff pm34.qts /alpha/rmabill/rmabill101c/src/pm34.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm35.qts >> compare_source.log
diff pm35.qts /alpha/rmabill/rmabill101c/src/pm35.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm36.qts >> compare_source.log
diff pm36.qts /alpha/rmabill/rmabill101c/src/pm36.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm37.qts >> compare_source.log
diff pm37.qts /alpha/rmabill/rmabill101c/src/pm37.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm38.qks >> compare_source.log
diff pm38.qks /alpha/rmabill/rmabill101c/src/pm38.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm39.qks >> compare_source.log
diff pm39.qks /alpha/rmabill/rmabill101c/src/pm39.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm40.qks >> compare_source.log
diff pm40.qks /alpha/rmabill/rmabill101c/src/pm40.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm41.qks >> compare_source.log
diff pm41.qks /alpha/rmabill/rmabill101c/src/pm41.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm42.qts >> compare_source.log
diff pm42.qts /alpha/rmabill/rmabill101c/src/pm42.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pm43.qzs >> compare_source.log
diff pm43.qzs /alpha/rmabill/rmabill101c/src/pm43.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: pps001.qts >> compare_source.log
diff pps001.qts /alpha/rmabill/rmabill101c/src/pps001.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: price_comparison.qts >> compare_source.log
diff price_comparison.qts /alpha/rmabill/rmabill101c/src/price_comparison.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: price_comparison.qzs >> compare_source.log
diff price_comparison.qzs /alpha/rmabill/rmabill101c/src/price_comparison.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: printer_codes_scanning.qzs >> compare_source.log
diff printer_codes_scanning.qzs /alpha/rmabill/rmabill101c/src/printer_codes_scanning.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: proxy.qzs >> compare_source.log
diff proxy.qzs /alpha/rmabill/rmabill101c/src/proxy.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: purge_f050_f051.qts >> compare_source.log
diff purge_f050_f051.qts /alpha/rmabill/rmabill101c/src/purge_f050_f051.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: purge_f050f051_83.qts >> compare_source.log
diff purge_f050f051_83.qts /alpha/rmabill/rmabill101c/src/purge_f050f051_83.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r002b.qzs >> compare_source.log
diff r002b.qzs /alpha/rmabill/rmabill101c/src/r002b.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r004atp.qzs >> compare_source.log
diff r004atp.qzs /alpha/rmabill/rmabill101c/src/r004atp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r004btp.qzs >> compare_source.log
diff r004btp.qzs /alpha/rmabill/rmabill101c/src/r004btp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r004ctp.qzs >> compare_source.log
diff r004ctp.qzs /alpha/rmabill/rmabill101c/src/r004ctp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r004dtp.qzs >> compare_source.log
diff r004dtp.qzs /alpha/rmabill/rmabill101c/src/r004dtp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r005atp.qzs >> compare_source.log
diff r005atp.qzs /alpha/rmabill/rmabill101c/src/r005atp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r005btp.qzs >> compare_source.log
diff r005btp.qzs /alpha/rmabill/rmabill101c/src/r005btp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r005ctp.qzs >> compare_source.log
diff r005ctp.qzs /alpha/rmabill/rmabill101c/src/r005ctp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r005dtp.qzs >> compare_source.log
diff r005dtp.qzs /alpha/rmabill/rmabill101c/src/r005dtp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r006atp.qzs >> compare_source.log
diff r006atp.qzs /alpha/rmabill/rmabill101c/src/r006atp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r006btp.qzs >> compare_source.log
diff r006btp.qzs /alpha/rmabill/rmabill101c/src/r006btp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r006ctp.qzs >> compare_source.log
diff r006ctp.qzs /alpha/rmabill/rmabill101c/src/r006ctp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r006dtp.qzs >> compare_source.log
diff r006dtp.qzs /alpha/rmabill/rmabill101c/src/r006dtp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r007tp.qzs >> compare_source.log
diff r007tp.qzs /alpha/rmabill/rmabill101c/src/r007tp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r010cycle.qzs >> compare_source.log
diff r010cycle.qzs /alpha/rmabill/rmabill101c/src/r010cycle.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r010daily.qzs >> compare_source.log
diff r010daily.qzs /alpha/rmabill/rmabill101c/src/r010daily.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r011a.qzs >> compare_source.log
diff r011a.qzs /alpha/rmabill/rmabill101c/src/r011a.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r011b.qzs >> compare_source.log
diff r011b.qzs /alpha/rmabill/rmabill101c/src/r011b.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r011c.qzs >> compare_source.log
diff r011c.qzs /alpha/rmabill/rmabill101c/src/r011c.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r011mohr.qzs >> compare_source.log
diff r011mohr.qzs /alpha/rmabill/rmabill101c/src/r011mohr.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r011tpc.qzs >> compare_source.log
diff r011tpc.qzs /alpha/rmabill/rmabill101c/src/r011tpc.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r012atp.qzs >> compare_source.log
diff r012atp.qzs /alpha/rmabill/rmabill101c/src/r012atp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r012btp.qzs >> compare_source.log
diff r012btp.qzs /alpha/rmabill/rmabill101c/src/r012btp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r012ctp.qzs >> compare_source.log
diff r012ctp.qzs /alpha/rmabill/rmabill101c/src/r012ctp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r013atp.qzs >> compare_source.log
diff r013atp.qzs /alpha/rmabill/rmabill101c/src/r013atp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r013btp.qzs >> compare_source.log
diff r013btp.qzs /alpha/rmabill/rmabill101c/src/r013btp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r013ctp.qzs >> compare_source.log
diff r013ctp.qzs /alpha/rmabill/rmabill101c/src/r013ctp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r015atp.qzs >> compare_source.log
diff r015atp.qzs /alpha/rmabill/rmabill101c/src/r015atp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r015btp.qzs >> compare_source.log
diff r015btp.qzs /alpha/rmabill/rmabill101c/src/r015btp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r015ctp.qzs >> compare_source.log
diff r015ctp.qzs /alpha/rmabill/rmabill101c/src/r015ctp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r020a.qzs >> compare_source.log
diff r020a.qzs /alpha/rmabill/rmabill101c/src/r020a.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r020a_temp.qzs >> compare_source.log
diff r020a_temp.qzs /alpha/rmabill/rmabill101c/src/r020a_temp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r020d.qzs >> compare_source.log
diff r020d.qzs /alpha/rmabill/rmabill101c/src/r020d.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r020d1_use.qzs >> compare_source.log
diff r020d1_use.qzs /alpha/rmabill/rmabill101c/src/r020d1_use.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r020d2_use.qzs >> compare_source.log
diff r020d2_use.qzs /alpha/rmabill/rmabill101c/src/r020d2_use.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r020e.qzs >> compare_source.log
diff r020e.qzs /alpha/rmabill/rmabill101c/src/r020e.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r020e_81_spec.qzs >> compare_source.log
diff r020e_81_spec.qzs /alpha/rmabill/rmabill101c/src/r020e_81_spec.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r020f.qzs >> compare_source.log
diff r020f.qzs /alpha/rmabill/rmabill101c/src/r020f.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r021b.qzs >> compare_source.log
diff r021b.qzs /alpha/rmabill/rmabill101c/src/r021b.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r021c.qzs >> compare_source.log
diff r021c.qzs /alpha/rmabill/rmabill101c/src/r021c.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r022a2.qzs >> compare_source.log
diff r022a2.qzs /alpha/rmabill/rmabill101c/src/r022a2.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r022a3.qzs >> compare_source.log
diff r022a3.qzs /alpha/rmabill/rmabill101c/src/r022a3.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r022a4.qzs >> compare_source.log
diff r022a4.qzs /alpha/rmabill/rmabill101c/src/r022a4.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r022a5.qzs >> compare_source.log
diff r022a5.qzs /alpha/rmabill/rmabill101c/src/r022a5.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r022a6.qzs >> compare_source.log
diff r022a6.qzs /alpha/rmabill/rmabill101c/src/r022a6.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r022a7.qzs >> compare_source.log
diff r022a7.qzs /alpha/rmabill/rmabill101c/src/r022a7.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r022a8.qzs >> compare_source.log
diff r022a8.qzs /alpha/rmabill/rmabill101c/src/r022a8.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r022a9.qzs >> compare_source.log
diff r022a9.qzs /alpha/rmabill/rmabill101c/src/r022a9.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r022d.qzs >> compare_source.log
diff r022d.qzs /alpha/rmabill/rmabill101c/src/r022d.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r022e.qzs >> compare_source.log
diff r022e.qzs /alpha/rmabill/rmabill101c/src/r022e.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r023b.qzs >> compare_source.log
diff r023b.qzs /alpha/rmabill/rmabill101c/src/r023b.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r023c.qzs >> compare_source.log
diff r023c.qzs /alpha/rmabill/rmabill101c/src/r023c.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r023d.qzs >> compare_source.log
diff r023d.qzs /alpha/rmabill/rmabill101c/src/r023d.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r030d.qzs >> compare_source.log
diff r030d.qzs /alpha/rmabill/rmabill101c/src/r030d.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r030e.qzs >> compare_source.log
diff r030e.qzs /alpha/rmabill/rmabill101c/src/r030e.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r030f.qzs >> compare_source.log
diff r030f.qzs /alpha/rmabill/rmabill101c/src/r030f.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r030g.qzs >> compare_source.log
diff r030g.qzs /alpha/rmabill/rmabill101c/src/r030g.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r030g3.qzs >> compare_source.log
diff r030g3.qzs /alpha/rmabill/rmabill101c/src/r030g3.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r030g5.qzs >> compare_source.log
diff r030g5.qzs /alpha/rmabill/rmabill101c/src/r030g5.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r030h.qzs >> compare_source.log
diff r030h.qzs /alpha/rmabill/rmabill101c/src/r030h.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r030i.qzs >> compare_source.log
diff r030i.qzs /alpha/rmabill/rmabill101c/src/r030i.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r030j.qzs >> compare_source.log
diff r030j.qzs /alpha/rmabill/rmabill101c/src/r030j.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r035b.qzs >> compare_source.log
diff r035b.qzs /alpha/rmabill/rmabill101c/src/r035b.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r043.qzs >> compare_source.log
diff r043.qzs /alpha/rmabill/rmabill101c/src/r043.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r051a_tp_per.qzs >> compare_source.log
diff r051a_tp_per.qzs /alpha/rmabill/rmabill101c/src/r051a_tp_per.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r051b_tp_per.qzs >> compare_source.log
diff r051b_tp_per.qzs /alpha/rmabill/rmabill101c/src/r051b_tp_per.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r051caatp.qzs >> compare_source.log
diff r051caatp.qzs /alpha/rmabill/rmabill101c/src/r051caatp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r051cabtp.qzs >> compare_source.log
diff r051cabtp.qzs /alpha/rmabill/rmabill101c/src/r051cabtp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r051cactp.qzs >> compare_source.log
diff r051cactp.qzs /alpha/rmabill/rmabill101c/src/r051cactp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r051cbatp.qzs >> compare_source.log
diff r051cbatp.qzs /alpha/rmabill/rmabill101c/src/r051cbatp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r051cbbtp.qzs >> compare_source.log
diff r051cbbtp.qzs /alpha/rmabill/rmabill101c/src/r051cbbtp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r051cbctp.qzs >> compare_source.log
diff r051cbctp.qzs /alpha/rmabill/rmabill101c/src/r051cbctp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r070atp.qzs >> compare_source.log
diff r070atp.qzs /alpha/rmabill/rmabill101c/src/r070atp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r070btp.qzs >> compare_source.log
diff r070btp.qzs /alpha/rmabill/rmabill101c/src/r070btp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r070ctp.qzs >> compare_source.log
diff r070ctp.qzs /alpha/rmabill/rmabill101c/src/r070ctp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r070ctp_agent.qzs >> compare_source.log
diff r070ctp_agent.qzs /alpha/rmabill/rmabill101c/src/r070ctp_agent.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r070ctp_old.qzs >> compare_source.log
diff r070ctp_old.qzs /alpha/rmabill/rmabill101c/src/r070ctp_old.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r070dtp.qzs >> compare_source.log
diff r070dtp.qzs /alpha/rmabill/rmabill101c/src/r070dtp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r072.qzs >> compare_source.log
diff r072.qzs /alpha/rmabill/rmabill101c/src/r072.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r080.qzs >> compare_source.log
diff r080.qzs /alpha/rmabill/rmabill101c/src/r080.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r084.qzs >> compare_source.log
diff r084.qzs /alpha/rmabill/rmabill101c/src/r084.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r084b.qzs >> compare_source.log
diff r084b.qzs /alpha/rmabill/rmabill101c/src/r084b.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r084docbillings.qzs >> compare_source.log
diff r084docbillings.qzs /alpha/rmabill/rmabill101c/src/r084docbillings.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r085_replaced_by_r085abc.qzs >> compare_source.log
diff r085_replaced_by_r085abc.qzs /alpha/rmabill/rmabill101c/src/r085_replaced_by_r085abc.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r085a.qzs >> compare_source.log
diff r085a.qzs /alpha/rmabill/rmabill101c/src/r085a.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r085e.qzs >> compare_source.log
diff r085e.qzs /alpha/rmabill/rmabill101c/src/r085e.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r086.qzs >> compare_source.log
diff r086.qzs /alpha/rmabill/rmabill101c/src/r086.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r087.qzs >> compare_source.log
diff r087.qzs /alpha/rmabill/rmabill101c/src/r087.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r088.qzs >> compare_source.log
diff r088.qzs /alpha/rmabill/rmabill101c/src/r088.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r089.qzs >> compare_source.log
diff r089.qzs /alpha/rmabill/rmabill101c/src/r089.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r093.qzs >> compare_source.log
diff r093.qzs /alpha/rmabill/rmabill101c/src/r093.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r093a.qzs >> compare_source.log
diff r093a.qzs /alpha/rmabill/rmabill101c/src/r093a.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r093d.qzs >> compare_source.log
diff r093d.qzs /alpha/rmabill/rmabill101c/src/r093d.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r095.qzs >> compare_source.log
diff r095.qzs /alpha/rmabill/rmabill101c/src/r095.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r099.qzs >> compare_source.log
diff r099.qzs /alpha/rmabill/rmabill101c/src/r099.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r102.qzs >> compare_source.log
diff r102.qzs /alpha/rmabill/rmabill101c/src/r102.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r111b.qzs >> compare_source.log
diff r111b.qzs /alpha/rmabill/rmabill101c/src/r111b.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r119a.qzs >> compare_source.log
diff r119a.qzs /alpha/rmabill/rmabill101c/src/r119a.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r119b.qzs >> compare_source.log
diff r119b.qzs /alpha/rmabill/rmabill101c/src/r119b.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r119c.qzs >> compare_source.log
diff r119c.qzs /alpha/rmabill/rmabill101c/src/r119c.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r120.qts >> compare_source.log
diff r120.qts /alpha/rmabill/rmabill101c/src/r120.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r120.qzs >> compare_source.log
diff r120.qzs /alpha/rmabill/rmabill101c/src/r120.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r120b.qzs >> compare_source.log
diff r120b.qzs /alpha/rmabill/rmabill101c/src/r120b.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r121a.qzs >> compare_source.log
diff r121a.qzs /alpha/rmabill/rmabill101c/src/r121a.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r121b.qzs >> compare_source.log
diff r121b.qzs /alpha/rmabill/rmabill101c/src/r121b.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r121c.qzs >> compare_source.log
diff r121c.qzs /alpha/rmabill/rmabill101c/src/r121c.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r121d.qzs >> compare_source.log
diff r121d.qzs /alpha/rmabill/rmabill101c/src/r121d.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r121dx.qzs >> compare_source.log
diff r121dx.qzs /alpha/rmabill/rmabill101c/src/r121dx.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r123d.qzs >> compare_source.log
diff r123d.qzs /alpha/rmabill/rmabill101c/src/r123d.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r123d1a.qzs >> compare_source.log
diff r123d1a.qzs /alpha/rmabill/rmabill101c/src/r123d1a.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r123e.qzs >> compare_source.log
diff r123e.qzs /alpha/rmabill/rmabill101c/src/r123e.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r124a.qzs >> compare_source.log
diff r124a.qzs /alpha/rmabill/rmabill101c/src/r124a.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r124a_icu.qzs >> compare_source.log
diff r124a_icu.qzs /alpha/rmabill/rmabill101c/src/r124a_icu.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r124a_mp.qzs >> compare_source.log
diff r124a_mp.qzs /alpha/rmabill/rmabill101c/src/r124a_mp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r124b_81y2k.qzs >> compare_source.log
diff r124b_81y2k.qzs /alpha/rmabill/rmabill101c/src/r124b_81y2k.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r124b_icu.qzs >> compare_source.log
diff r124b_icu.qzs /alpha/rmabill/rmabill101c/src/r124b_icu.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r124b_mp.qzs >> compare_source.log
diff r124b_mp.qzs /alpha/rmabill/rmabill101c/src/r124b_mp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r124b_rma.qzs >> compare_source.log
diff r124b_rma.qzs /alpha/rmabill/rmabill101c/src/r124b_rma.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r124b_rma_yearend.qzs >> compare_source.log
diff r124b_rma_yearend.qzs /alpha/rmabill/rmabill101c/src/r124b_rma_yearend.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r124b_rma_yearend_OLD.qzs >> compare_source.log
diff r124b_rma_yearend_OLD.qzs /alpha/rmabill/rmabill101c/src/r124b_rma_yearend_OLD.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r125.qzs >> compare_source.log
diff r125.qzs /alpha/rmabill/rmabill101c/src/r125.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r129.qzs >> compare_source.log
diff r129.qzs /alpha/rmabill/rmabill101c/src/r129.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r132.qzs >> compare_source.log
diff r132.qzs /alpha/rmabill/rmabill101c/src/r132.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r140_a.qzs >> compare_source.log
diff r140_a.qzs /alpha/rmabill/rmabill101c/src/r140_a.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r140_a1.qts >> compare_source.log
diff r140_a1.qts /alpha/rmabill/rmabill101c/src/r140_a1.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r140_a1f.qzs >> compare_source.log
diff r140_a1f.qzs /alpha/rmabill/rmabill101c/src/r140_a1f.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r140_a2.qts >> compare_source.log
diff r140_a2.qts /alpha/rmabill/rmabill101c/src/r140_a2.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r140_a2.qzs >> compare_source.log
diff r140_a2.qzs /alpha/rmabill/rmabill101c/src/r140_a2.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r140_a2g.qzs >> compare_source.log
diff r140_a2g.qzs /alpha/rmabill/rmabill101c/src/r140_a2g.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r140_a2s.qzs >> compare_source.log
diff r140_a2s.qzs /alpha/rmabill/rmabill101c/src/r140_a2s.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r140_a3.qzs >> compare_source.log
diff r140_a3.qzs /alpha/rmabill/rmabill101c/src/r140_a3.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r140_a3c.qzs >> compare_source.log
diff r140_a3c.qzs /alpha/rmabill/rmabill101c/src/r140_a3c.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r140_a4t.qzs >> compare_source.log
diff r140_a4t.qzs /alpha/rmabill/rmabill101c/src/r140_a4t.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r140_b1.qzs >> compare_source.log
diff r140_b1.qzs /alpha/rmabill/rmabill101c/src/r140_b1.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r140_b2.qzs >> compare_source.log
diff r140_b2.qzs /alpha/rmabill/rmabill101c/src/r140_b2.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r140_b_yas.qzs >> compare_source.log
diff r140_b_yas.qzs /alpha/rmabill/rmabill101c/src/r140_b_yas.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r150a.qts >> compare_source.log
diff r150a.qts /alpha/rmabill/rmabill101c/src/r150a.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r150a_detail.qts >> compare_source.log
diff r150a_detail.qts /alpha/rmabill/rmabill101c/src/r150a_detail.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r150a_new.qts >> compare_source.log
diff r150a_new.qts /alpha/rmabill/rmabill101c/src/r150a_new.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r150b.qzs >> compare_source.log
diff r150b.qzs /alpha/rmabill/rmabill101c/src/r150b.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r150b_part2.qzs >> compare_source.log
diff r150b_part2.qzs /alpha/rmabill/rmabill101c/src/r150b_part2.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r150c.qzs >> compare_source.log
diff r150c.qzs /alpha/rmabill/rmabill101c/src/r150c.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r150d.qzs >> compare_source.log
diff r150d.qzs /alpha/rmabill/rmabill101c/src/r150d.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r150d_detail.qts >> compare_source.log
diff r150d_detail.qts /alpha/rmabill/rmabill101c/src/r150d_detail.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r150d_detail.qzs >> compare_source.log
diff r150d_detail.qzs /alpha/rmabill/rmabill101c/src/r150d_detail.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r151.qzs >> compare_source.log
diff r151.qzs /alpha/rmabill/rmabill101c/src/r151.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r151_hist.qzs >> compare_source.log
diff r151_hist.qzs /alpha/rmabill/rmabill101c/src/r151_hist.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r151_yrend.qzs >> compare_source.log
diff r151_yrend.qzs /alpha/rmabill/rmabill101c/src/r151_yrend.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r151d.qzs >> compare_source.log
diff r151d.qzs /alpha/rmabill/rmabill101c/src/r151d.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r190_yearend_verify.qzs >> compare_source.log
diff r190_yearend_verify.qzs /alpha/rmabill/rmabill101c/src/r190_yearend_verify.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r211.qzs >> compare_source.log
diff r211.qzs /alpha/rmabill/rmabill101c/src/r211.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r699.qzs >> compare_source.log
diff r699.qzs /alpha/rmabill/rmabill101c/src/r699.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r702.qzs >> compare_source.log
diff r702.qzs /alpha/rmabill/rmabill101c/src/r702.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r707.qzs >> compare_source.log
diff r707.qzs /alpha/rmabill/rmabill101c/src/r707.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r709a.qzs >> compare_source.log
diff r709a.qzs /alpha/rmabill/rmabill101c/src/r709a.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r709b.qzs >> compare_source.log
diff r709b.qzs /alpha/rmabill/rmabill101c/src/r709b.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r710.qzs >> compare_source.log
diff r710.qzs /alpha/rmabill/rmabill101c/src/r710.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r711.qzs >> compare_source.log
diff r711.qzs /alpha/rmabill/rmabill101c/src/r711.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r712.qzs >> compare_source.log
diff r712.qzs /alpha/rmabill/rmabill101c/src/r712.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r715.qzs >> compare_source.log
diff r715.qzs /alpha/rmabill/rmabill101c/src/r715.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r716a.qzs >> compare_source.log
diff r716a.qzs /alpha/rmabill/rmabill101c/src/r716a.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r716b.qzs >> compare_source.log
diff r716b.qzs /alpha/rmabill/rmabill101c/src/r716b.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r716c.qzs >> compare_source.log
diff r716c.qzs /alpha/rmabill/rmabill101c/src/r716c.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r801a.qzs >> compare_source.log
diff r801a.qzs /alpha/rmabill/rmabill101c/src/r801a.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r801b.qzs >> compare_source.log
diff r801b.qzs /alpha/rmabill/rmabill101c/src/r801b.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r801c.qzs >> compare_source.log
diff r801c.qzs /alpha/rmabill/rmabill101c/src/r801c.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r902.qzs >> compare_source.log
diff r902.qzs /alpha/rmabill/rmabill101c/src/r902.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r905.qzs >> compare_source.log
diff r905.qzs /alpha/rmabill/rmabill101c/src/r905.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r906.qzs >> compare_source.log
diff r906.qzs /alpha/rmabill/rmabill101c/src/r906.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r907.qzs >> compare_source.log
diff r907.qzs /alpha/rmabill/rmabill101c/src/r907.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r909.qzs >> compare_source.log
diff r909.qzs /alpha/rmabill/rmabill101c/src/r909.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r911.qzs >> compare_source.log
diff r911.qzs /alpha/rmabill/rmabill101c/src/r911.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r911a.qzs >> compare_source.log
diff r911a.qzs /alpha/rmabill/rmabill101c/src/r911a.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r919.qzs >> compare_source.log
diff r919.qzs /alpha/rmabill/rmabill101c/src/r919.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r933b.qzs >> compare_source.log
diff r933b.qzs /alpha/rmabill/rmabill101c/src/r933b.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r934_22.qzs >> compare_source.log
diff r934_22.qzs /alpha/rmabill/rmabill101c/src/r934_22.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r934_replaced_by_r934abcd.qzs >> compare_source.log
diff r934_replaced_by_r934abcd.qzs /alpha/rmabill/rmabill101c/src/r934_replaced_by_r934abcd.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r934a_no_longer_run.qzs >> compare_source.log
diff r934a_no_longer_run.qzs /alpha/rmabill/rmabill101c/src/r934a_no_longer_run.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r934addwitheld.qzs >> compare_source.log
diff r934addwitheld.qzs /alpha/rmabill/rmabill101c/src/r934addwitheld.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r934b_no_longer_run.qzs >> compare_source.log
diff r934b_no_longer_run.qzs /alpha/rmabill/rmabill101c/src/r934b_no_longer_run.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r940.qzs >> compare_source.log
diff r940.qzs /alpha/rmabill/rmabill101c/src/r940.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r941.qzs >> compare_source.log
diff r941.qzs /alpha/rmabill/rmabill101c/src/r941.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r990.qzs >> compare_source.log
diff r990.qzs /alpha/rmabill/rmabill101c/src/r990.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r991a.qts >> compare_source.log
diff r991a.qts /alpha/rmabill/rmabill101c/src/r991a.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r991b.qzs >> compare_source.log
diff r991b.qzs /alpha/rmabill/rmabill101c/src/r991b.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r992.qzs >> compare_source.log
diff r992.qzs /alpha/rmabill/rmabill101c/src/r992.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r992a.qts >> compare_source.log
diff r992a.qts /alpha/rmabill/rmabill101c/src/r992a.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r992b.qzs >> compare_source.log
diff r992b.qzs /alpha/rmabill/rmabill101c/src/r992b.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r995.qzs >> compare_source.log
diff r995.qzs /alpha/rmabill/rmabill101c/src/r995.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r996.qzs >> compare_source.log
diff r996.qzs /alpha/rmabill/rmabill101c/src/r996.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r997_paid.qzs >> compare_source.log
diff r997_paid.qzs /alpha/rmabill/rmabill101c/src/r997_paid.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r997_total.qzs >> compare_source.log
diff r997_total.qzs /alpha/rmabill/rmabill101c/src/r997_total.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r997_total_bkp.qzs >> compare_source.log
diff r997_total_bkp.qzs /alpha/rmabill/rmabill101c/src/r997_total_bkp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: r997a.qzs >> compare_source.log
diff r997a.qzs /alpha/rmabill/rmabill101c/src/r997a.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: rat_all_claims.qzs >> compare_source.log
diff rat_all_claims.qzs /alpha/rmabill/rmabill101c/src/rat_all_claims.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: rat_audit_1.qzs >> compare_source.log
diff rat_audit_1.qzs /alpha/rmabill/rmabill101c/src/rat_audit_1.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: rat_audit_10.qzs >> compare_source.log
diff rat_audit_10.qzs /alpha/rmabill/rmabill101c/src/rat_audit_10.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: rat_audit_2.qzs >> compare_source.log
diff rat_audit_2.qzs /alpha/rmabill/rmabill101c/src/rat_audit_2.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: rat_audit_3.qzs >> compare_source.log
diff rat_audit_3.qzs /alpha/rmabill/rmabill101c/src/rat_audit_3.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: rat_audit_30.qzs >> compare_source.log
diff rat_audit_30.qzs /alpha/rmabill/rmabill101c/src/rat_audit_30.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: rat_audit_4.qzs >> compare_source.log
diff rat_audit_4.qzs /alpha/rmabill/rmabill101c/src/rat_audit_4.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: rat_audit_5.qzs >> compare_source.log
diff rat_audit_5.qzs /alpha/rmabill/rmabill101c/src/rat_audit_5.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: rat_audit_6a.qzs >> compare_source.log
diff rat_audit_6a.qzs /alpha/rmabill/rmabill101c/src/rat_audit_6a.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: rat_audit_6b.qzs >> compare_source.log
diff rat_audit_6b.qzs /alpha/rmabill/rmabill101c/src/rat_audit_6b.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: rat_audit_6c.qzs >> compare_source.log
diff rat_audit_6c.qzs /alpha/rmabill/rmabill101c/src/rat_audit_6c.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: rat_audit_8.qzs >> compare_source.log
diff rat_audit_8.qzs /alpha/rmabill/rmabill101c/src/rat_audit_8.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: reason80.qzs >> compare_source.log
diff reason80.qzs /alpha/rmabill/rmabill101c/src/reason80.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: rebuild_f002shdw.qts >> compare_source.log
diff rebuild_f002shdw.qts /alpha/rmabill/rmabill101c/src/rebuild_f002shdw.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: reject_dtl.qzs >> compare_source.log
diff reject_dtl.qzs /alpha/rmabill/rmabill101c/src/reject_dtl.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: rejectdtl.qzs >> compare_source.log
diff rejectdtl.qzs /alpha/rmabill/rmabill101c/src/rejectdtl.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: rejects_dept6.qzs >> compare_source.log
diff rejects_dept6.qzs /alpha/rmabill/rmabill101c/src/rejects_dept6.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: rejecttest.qzs >> compare_source.log
diff rejecttest.qzs /alpha/rmabill/rmabill101c/src/rejecttest.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relo_adj_claim_file.qts >> compare_source.log
diff relo_adj_claim_file.qts /alpha/rmabill/rmabill101c/src/relo_adj_claim_file.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: reload_f010_f020.qts >> compare_source.log
diff reload_f010_f020.qts /alpha/rmabill/rmabill101c/src/reload_f010_f020.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relocontractdtl.qts >> compare_source.log
diff relocontractdtl.qts /alpha/rmabill/rmabill101c/src/relocontractdtl.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relocontractmstr.qts >> compare_source.log
diff relocontractmstr.qts /alpha/rmabill/rmabill101c/src/relocontractmstr.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof001-old.qts >> compare_source.log
diff relof001-old.qts /alpha/rmabill/rmabill101c/src/relof001-old.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof001.qts >> compare_source.log
diff relof001.qts /alpha/rmabill/rmabill101c/src/relof001.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof002.qts >> compare_source.log
diff relof002.qts /alpha/rmabill/rmabill101c/src/relof002.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof002_hdr_fields.qts >> compare_source.log
diff relof002_hdr_fields.qts /alpha/rmabill/rmabill101c/src/relof002_hdr_fields.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof002_susp_addr.qts >> compare_source.log
diff relof002_susp_addr.qts /alpha/rmabill/rmabill101c/src/relof002_susp_addr.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof002_susp_dtl.qts >> compare_source.log
diff relof002_susp_dtl.qts /alpha/rmabill/rmabill101c/src/relof002_susp_dtl.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof002_susp_hdr.qts >> compare_source.log
diff relof002_susp_hdr.qts /alpha/rmabill/rmabill101c/src/relof002_susp_hdr.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof002extra.qts >> compare_source.log
diff relof002extra.qts /alpha/rmabill/rmabill101c/src/relof002extra.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof002hst.qts >> compare_source.log
diff relof002hst.qts /alpha/rmabill/rmabill101c/src/relof002hst.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof002shadow.qts >> compare_source.log
diff relof002shadow.qts /alpha/rmabill/rmabill101c/src/relof002shadow.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof010-old.qts >> compare_source.log
diff relof010-old.qts /alpha/rmabill/rmabill101c/src/relof010-old.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof010.qts >> compare_source.log
diff relof010.qts /alpha/rmabill/rmabill101c/src/relof010.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof020.qts >> compare_source.log
diff relof020.qts /alpha/rmabill/rmabill101c/src/relof020.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof020extra.qts >> compare_source.log
diff relof020extra.qts /alpha/rmabill/rmabill101c/src/relof020extra.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof020hist.qts >> compare_source.log
diff relof020hist.qts /alpha/rmabill/rmabill101c/src/relof020hist.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof020hst.qts >> compare_source.log
diff relof020hst.qts /alpha/rmabill/rmabill101c/src/relof020hst.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof021-old.qts >> compare_source.log
diff relof021-old.qts /alpha/rmabill/rmabill101c/src/relof021-old.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof021.qts >> compare_source.log
diff relof021.qts /alpha/rmabill/rmabill101c/src/relof021.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof021_fix.qts >> compare_source.log
diff relof021_fix.qts /alpha/rmabill/rmabill101c/src/relof021_fix.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof022.qts >> compare_source.log
diff relof022.qts /alpha/rmabill/rmabill101c/src/relof022.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof023.qts >> compare_source.log
diff relof023.qts /alpha/rmabill/rmabill101c/src/relof023.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof025.qts >> compare_source.log
diff relof025.qts /alpha/rmabill/rmabill101c/src/relof025.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof040.qts >> compare_source.log
diff relof040.qts /alpha/rmabill/rmabill101c/src/relof040.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof040_fix.qts >> compare_source.log
diff relof040_fix.qts /alpha/rmabill/rmabill101c/src/relof040_fix.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof040_y2k.qts >> compare_source.log
diff relof040_y2k.qts /alpha/rmabill/rmabill101c/src/relof040_y2k.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof050.qts >> compare_source.log
diff relof050.qts /alpha/rmabill/rmabill101c/src/relof050.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof050hist-old.qts >> compare_source.log
diff relof050hist-old.qts /alpha/rmabill/rmabill101c/src/relof050hist-old.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof050hist.qts >> compare_source.log
diff relof050hist.qts /alpha/rmabill/rmabill101c/src/relof050hist.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof050tp.qts >> compare_source.log
diff relof050tp.qts /alpha/rmabill/rmabill101c/src/relof050tp.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof050tp_2.qts >> compare_source.log
diff relof050tp_2.qts /alpha/rmabill/rmabill101c/src/relof050tp_2.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof050tphist-old.qts >> compare_source.log
diff relof050tphist-old.qts /alpha/rmabill/rmabill101c/src/relof050tphist-old.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof050tphist.qts >> compare_source.log
diff relof050tphist.qts /alpha/rmabill/rmabill101c/src/relof050tphist.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof051.qts >> compare_source.log
diff relof051.qts /alpha/rmabill/rmabill101c/src/relof051.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof051tp.qts >> compare_source.log
diff relof051tp.qts /alpha/rmabill/rmabill101c/src/relof051tp.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof060.qts >> compare_source.log
diff relof060.qts /alpha/rmabill/rmabill101c/src/relof060.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof071-old.qts >> compare_source.log
diff relof071-old.qts /alpha/rmabill/rmabill101c/src/relof071-old.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof071.qts >> compare_source.log
diff relof071.qts /alpha/rmabill/rmabill101c/src/relof071.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof073-old.qts >> compare_source.log
diff relof073-old.qts /alpha/rmabill/rmabill101c/src/relof073-old.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof073.qts >> compare_source.log
diff relof073.qts /alpha/rmabill/rmabill101c/src/relof073.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof084.qts >> compare_source.log
diff relof084.qts /alpha/rmabill/rmabill101c/src/relof084.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof085.qts >> compare_source.log
diff relof085.qts /alpha/rmabill/rmabill101c/src/relof085.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof086.qts >> compare_source.log
diff relof086.qts /alpha/rmabill/rmabill101c/src/relof086.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof087-old.qts >> compare_source.log
diff relof087-old.qts /alpha/rmabill/rmabill101c/src/relof087-old.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof087-sub-dtl.qts >> compare_source.log
diff relof087-sub-dtl.qts /alpha/rmabill/rmabill101c/src/relof087-sub-dtl.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof087-sub-hdr.qts >> compare_source.log
diff relof087-sub-hdr.qts /alpha/rmabill/rmabill101c/src/relof087-sub-hdr.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof087.qts >> compare_source.log
diff relof087.qts /alpha/rmabill/rmabill101c/src/relof087.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof088-dtl.qts >> compare_source.log
diff relof088-dtl.qts /alpha/rmabill/rmabill101c/src/relof088-dtl.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof088-hdr.qts >> compare_source.log
diff relof088-hdr.qts /alpha/rmabill/rmabill101c/src/relof088-hdr.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof090_1.qts >> compare_source.log
diff relof090_1.qts /alpha/rmabill/rmabill101c/src/relof090_1.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof090_2.qts >> compare_source.log
diff relof090_2.qts /alpha/rmabill/rmabill101c/src/relof090_2.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof090_3.qts >> compare_source.log
diff relof090_3.qts /alpha/rmabill/rmabill101c/src/relof090_3.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof090_4.qts >> compare_source.log
diff relof090_4.qts /alpha/rmabill/rmabill101c/src/relof090_4.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof090_5.qts >> compare_source.log
diff relof090_5.qts /alpha/rmabill/rmabill101c/src/relof090_5.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof090_6.qts >> compare_source.log
diff relof090_6.qts /alpha/rmabill/rmabill101c/src/relof090_6.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof090_iconst.qts >> compare_source.log
diff relof090_iconst.qts /alpha/rmabill/rmabill101c/src/relof090_iconst.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof095.qts >> compare_source.log
diff relof095.qts /alpha/rmabill/rmabill101c/src/relof095.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof099.qts >> compare_source.log
diff relof099.qts /alpha/rmabill/rmabill101c/src/relof099.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof110.qts >> compare_source.log
diff relof110.qts /alpha/rmabill/rmabill101c/src/relof110.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof110hst.qts >> compare_source.log
diff relof110hst.qts /alpha/rmabill/rmabill101c/src/relof110hst.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof112.qts >> compare_source.log
diff relof112.qts /alpha/rmabill/rmabill101c/src/relof112.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof112hst.qts >> compare_source.log
diff relof112hst.qts /alpha/rmabill/rmabill101c/src/relof112hst.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof113.qts >> compare_source.log
diff relof113.qts /alpha/rmabill/rmabill101c/src/relof113.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof113hst.qts >> compare_source.log
diff relof113hst.qts /alpha/rmabill/rmabill101c/src/relof113hst.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof119.qts >> compare_source.log
diff relof119.qts /alpha/rmabill/rmabill101c/src/relof119.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof119hst.qts >> compare_source.log
diff relof119hst.qts /alpha/rmabill/rmabill101c/src/relof119hst.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof123.qts >> compare_source.log
diff relof123.qts /alpha/rmabill/rmabill101c/src/relof123.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof190.qts >> compare_source.log
diff relof190.qts /alpha/rmabill/rmabill101c/src/relof190.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof191.qts >> compare_source.log
diff relof191.qts /alpha/rmabill/rmabill101c/src/relof191.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof198.qts >> compare_source.log
diff relof198.qts /alpha/rmabill/rmabill101c/src/relof198.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof199-old.qts >> compare_source.log
diff relof199-old.qts /alpha/rmabill/rmabill101c/src/relof199-old.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof199.qts >> compare_source.log
diff relof199.qts /alpha/rmabill/rmabill101c/src/relof199.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof920.qts >> compare_source.log
diff relof920.qts /alpha/rmabill/rmabill101c/src/relof920.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof923.qts >> compare_source.log
diff relof923.qts /alpha/rmabill/rmabill101c/src/relof923.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relof924.qts >> compare_source.log
diff relof924.qts /alpha/rmabill/rmabill101c/src/relof924.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relosoc.qts >> compare_source.log
diff relosoc.qts /alpha/rmabill/rmabill101c/src/relosoc.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relosubfile.qts >> compare_source.log
diff relosubfile.qts /alpha/rmabill/rmabill101c/src/relosubfile.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: relotime.qts >> compare_source.log
diff relotime.qts /alpha/rmabill/rmabill101c/src/relotime.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: rev85.qzs >> compare_source.log
diff rev85.qzs /alpha/rmabill/rmabill101c/src/rev85.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: revhbk1.qts >> compare_source.log
diff revhbk1.qts /alpha/rmabill/rmabill101c/src/revhbk1.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: rmaprice.qzs >> compare_source.log
diff rmaprice.qzs /alpha/rmabill/rmabill101c/src/rmaprice.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: rtimesht2.qzs >> compare_source.log
diff rtimesht2.qzs /alpha/rmabill/rmabill101c/src/rtimesht2.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: screen_tot.qzs >> compare_source.log
diff screen_tot.qzs /alpha/rmabill/rmabill101c/src/screen_tot.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: screen_tot_lotus.qzs >> compare_source.log
diff screen_tot_lotus.qzs /alpha/rmabill/rmabill101c/src/screen_tot_lotus.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: selclmdtl.qzs >> compare_source.log
diff selclmdtl.qzs /alpha/rmabill/rmabill101c/src/selclmdtl.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: selclmhdr.qzs >> compare_source.log
diff selclmhdr.qzs /alpha/rmabill/rmabill101c/src/selclmhdr.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: select60.qzs >> compare_source.log
diff select60.qzs /alpha/rmabill/rmabill101c/src/select60.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: select_t4.qts >> compare_source.log
diff select_t4.qts /alpha/rmabill/rmabill101c/src/select_t4.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: selsum.qzs >> compare_source.log
diff selsum.qzs /alpha/rmabill/rmabill101c/src/selsum.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: signaturelabels.qzs >> compare_source.log
diff signaturelabels.qzs /alpha/rmabill/rmabill101c/src/signaturelabels.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: skip.qzs >> compare_source.log
diff skip.qzs /alpha/rmabill/rmabill101c/src/skip.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: split_file.qts >> compare_source.log
diff split_file.qts /alpha/rmabill/rmabill101c/src/split_file.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: std_hilite.qks >> compare_source.log
diff std_hilite.qks /alpha/rmabill/rmabill101c/src/std_hilite.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: suspend_agent.qzs >> compare_source.log
diff suspend_agent.qzs /alpha/rmabill/rmabill101c/src/suspend_agent.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: suspend_desc.qzs >> compare_source.log
diff suspend_desc.qzs /alpha/rmabill/rmabill101c/src/suspend_desc.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: suspend_dtl.qts >> compare_source.log
diff suspend_dtl.qts /alpha/rmabill/rmabill101c/src/suspend_dtl.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: suspend_dtl.qzs >> compare_source.log
diff suspend_dtl.qzs /alpha/rmabill/rmabill101c/src/suspend_dtl.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: suspend_dtl_bkp.qts >> compare_source.log
diff suspend_dtl_bkp.qts /alpha/rmabill/rmabill101c/src/suspend_dtl_bkp.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: suspend_dtl_bkp.qzs >> compare_source.log
diff suspend_dtl_bkp.qzs /alpha/rmabill/rmabill101c/src/suspend_dtl_bkp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: suspend_dtl_old.qzs >> compare_source.log
diff suspend_dtl_old.qzs /alpha/rmabill/rmabill101c/src/suspend_dtl_old.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: suspend_status.qzs >> compare_source.log
diff suspend_status.qzs /alpha/rmabill/rmabill101c/src/suspend_status.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: suspend_total.qzs >> compare_source.log
diff suspend_total.qzs /alpha/rmabill/rmabill101c/src/suspend_total.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: suspend_total_bkp.qzs >> compare_source.log
diff suspend_total_bkp.qzs /alpha/rmabill/rmabill101c/src/suspend_total_bkp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: sy030.qks >> compare_source.log
diff sy030.qks /alpha/rmabill/rmabill101c/src/sy030.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: sy031.qks >> compare_source.log
diff sy031.qks /alpha/rmabill/rmabill101c/src/sy031.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: sy033.qks >> compare_source.log
diff sy033.qks /alpha/rmabill/rmabill101c/src/sy033.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: tax98.qzs >> compare_source.log
diff tax98.qzs /alpha/rmabill/rmabill101c/src/tax98.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: taxlabels.qzs >> compare_source.log
diff taxlabels.qzs /alpha/rmabill/rmabill101c/src/taxlabels.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: taxmp.qzs >> compare_source.log
diff taxmp.qzs /alpha/rmabill/rmabill101c/src/taxmp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u010daily.qts >> compare_source.log
diff u010daily.qts /alpha/rmabill/rmabill101c/src/u010daily.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u010dailyapply.qts >> compare_source.log
diff u010dailyapply.qts /alpha/rmabill/rmabill101c/src/u010dailyapply.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u010dailyreverse.qts >> compare_source.log
diff u010dailyreverse.qts /alpha/rmabill/rmabill101c/src/u010dailyreverse.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u010dailyreverse_from_subfile.qts >> compare_source.log
diff u010dailyreverse_from_subfile.qts /alpha/rmabill/rmabill101c/src/u010dailyreverse_from_subfile.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u014.qts >> compare_source.log
diff u014.qts /alpha/rmabill/rmabill101c/src/u014.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u014_f050.qts >> compare_source.log
diff u014_f050.qts /alpha/rmabill/rmabill101c/src/u014_f050.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u014_f050tp.qts >> compare_source.log
diff u014_f050tp.qts /alpha/rmabill/rmabill101c/src/u014_f050tp.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u014_f050tp_before_split_add_udpate.qts >> compare_source.log
diff u014_f050tp_before_split_add_udpate.qts /alpha/rmabill/rmabill101c/src/u014_f050tp_before_split_add_udpate.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u020_use.qts >> compare_source.log
diff u020_use.qts /alpha/rmabill/rmabill101c/src/u020_use.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u020a.qts >> compare_source.log
diff u020a.qts /alpha/rmabill/rmabill101c/src/u020a.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u020a_81_spec.qts >> compare_source.log
diff u020a_81_spec.qts /alpha/rmabill/rmabill101c/src/u020a_81_spec.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u020a_resubmit.qts >> compare_source.log
diff u020a_resubmit.qts /alpha/rmabill/rmabill101c/src/u020a_resubmit.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u020b.qts >> compare_source.log
diff u020b.qts /alpha/rmabill/rmabill101c/src/u020b.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u020b_81_spec.qts >> compare_source.log
diff u020b_81_spec.qts /alpha/rmabill/rmabill101c/src/u020b_81_spec.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u020b_resubmit.qts >> compare_source.log
diff u020b_resubmit.qts /alpha/rmabill/rmabill101c/src/u020b_resubmit.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u020b_resubmit_SPLIT.qts >> compare_source.log
diff u020b_resubmit_SPLIT.qts /alpha/rmabill/rmabill101c/src/u020b_resubmit_SPLIT.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u020b_use.qts >> compare_source.log
diff u020b_use.qts /alpha/rmabill/rmabill101c/src/u020b_use.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u020c.qts >> compare_source.log
diff u020c.qts /alpha/rmabill/rmabill101c/src/u020c.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u020c_81_spec.qts >> compare_source.log
diff u020c_81_spec.qts /alpha/rmabill/rmabill101c/src/u020c_81_spec.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u020c_use.qts >> compare_source.log
diff u020c_use.qts /alpha/rmabill/rmabill101c/src/u020c_use.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u020c_use_before_review_fix.qts >> compare_source.log
diff u020c_use_before_review_fix.qts /alpha/rmabill/rmabill101c/src/u020c_use_before_review_fix.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u020c_use_before_y2k.qts >> compare_source.log
diff u020c_use_before_y2k.qts /alpha/rmabill/rmabill101c/src/u020c_use_before_y2k.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u021a.qts >> compare_source.log
diff u021a.qts /alpha/rmabill/rmabill101c/src/u021a.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u021f.qts >> compare_source.log
diff u021f.qts /alpha/rmabill/rmabill101c/src/u021f.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u021f_use.qts >> compare_source.log
diff u021f_use.qts /alpha/rmabill/rmabill101c/src/u021f_use.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u022a1.qts >> compare_source.log
diff u022a1.qts /alpha/rmabill/rmabill101c/src/u022a1.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u022a1_81.qts >> compare_source.log
diff u022a1_81.qts /alpha/rmabill/rmabill101c/src/u022a1_81.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u022a1_brad.qts >> compare_source.log
diff u022a1_brad.qts /alpha/rmabill/rmabill101c/src/u022a1_brad.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u022a1_clinic_81.qts >> compare_source.log
diff u022a1_clinic_81.qts /alpha/rmabill/rmabill101c/src/u022a1_clinic_81.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u022a1_clinic_81_b.qts >> compare_source.log
diff u022a1_clinic_81_b.qts /alpha/rmabill/rmabill101c/src/u022a1_clinic_81_b.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u022b.qts >> compare_source.log
diff u022b.qts /alpha/rmabill/rmabill101c/src/u022b.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u022c.qts >> compare_source.log
diff u022c.qts /alpha/rmabill/rmabill101c/src/u022c.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u022sd.qts >> compare_source.log
diff u022sd.qts /alpha/rmabill/rmabill101c/src/u022sd.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u023a.qts >> compare_source.log
diff u023a.qts /alpha/rmabill/rmabill101c/src/u023a.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u030aa3.qzs >> compare_source.log
diff u030aa3.qzs /alpha/rmabill/rmabill101c/src/u030aa3.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u030b.qts >> compare_source.log
diff u030b.qts /alpha/rmabill/rmabill101c/src/u030b.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u030b_1.qts >> compare_source.log
diff u030b_1.qts /alpha/rmabill/rmabill101c/src/u030b_1.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u030b_22.qts >> compare_source.log
diff u030b_22.qts /alpha/rmabill/rmabill101c/src/u030b_22.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u030b_60.qts >> compare_source.log
diff u030b_60.qts /alpha/rmabill/rmabill101c/src/u030b_60.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u030b_orig_no_80.qts >> compare_source.log
diff u030b_orig_no_80.qts /alpha/rmabill/rmabill101c/src/u030b_orig_no_80.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u030b_part2.qts >> compare_source.log
diff u030b_part2.qts /alpha/rmabill/rmabill101c/src/u030b_part2.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u030b_part2_rerun.qts >> compare_source.log
diff u030b_part2_rerun.qts /alpha/rmabill/rmabill101c/src/u030b_part2_rerun.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u030b_reapply.qts >> compare_source.log
diff u030b_reapply.qts /alpha/rmabill/rmabill101c/src/u030b_reapply.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u030b_rerun.qts >> compare_source.log
diff u030b_rerun.qts /alpha/rmabill/rmabill101c/src/u030b_rerun.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u030b_reverse.qts >> compare_source.log
diff u030b_reverse.qts /alpha/rmabill/rmabill101c/src/u030b_reverse.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u030b_special.qts >> compare_source.log
diff u030b_special.qts /alpha/rmabill/rmabill101c/src/u030b_special.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u030b_special1.qts >> compare_source.log
diff u030b_special1.qts /alpha/rmabill/rmabill101c/src/u030b_special1.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u030b_special2.qts >> compare_source.log
diff u030b_special2.qts /alpha/rmabill/rmabill101c/src/u030b_special2.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u030bb.qts >> compare_source.log
diff u030bb.qts /alpha/rmabill/rmabill101c/src/u030bb.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u030bb_1.qts >> compare_source.log
diff u030bb_1.qts /alpha/rmabill/rmabill101c/src/u030bb_1.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u030bb_1_process_jul_jan_claims.qts >> compare_source.log
diff u030bb_1_process_jul_jan_claims.qts /alpha/rmabill/rmabill101c/src/u030bb_1_process_jul_jan_claims.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u035a.qts >> compare_source.log
diff u035a.qts /alpha/rmabill/rmabill101c/src/u035a.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u035c.qts >> compare_source.log
diff u035c.qts /alpha/rmabill/rmabill101c/src/u035c.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u042.qts >> compare_source.log
diff u042.qts /alpha/rmabill/rmabill101c/src/u042.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u043.qts >> compare_source.log
diff u043.qts /alpha/rmabill/rmabill101c/src/u043.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u050.qts >> compare_source.log
diff u050.qts /alpha/rmabill/rmabill101c/src/u050.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u050_hist.qts >> compare_source.log
diff u050_hist.qts /alpha/rmabill/rmabill101c/src/u050_hist.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u071.qts >> compare_source.log
diff u071.qts /alpha/rmabill/rmabill101c/src/u071.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u071a.qts >> compare_source.log
diff u071a.qts /alpha/rmabill/rmabill101c/src/u071a.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u072.qts >> compare_source.log
diff u072.qts /alpha/rmabill/rmabill101c/src/u072.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u072a.qts >> compare_source.log
diff u072a.qts /alpha/rmabill/rmabill101c/src/u072a.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u080.qts >> compare_source.log
diff u080.qts /alpha/rmabill/rmabill101c/src/u080.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u084a.qts >> compare_source.log
diff u084a.qts /alpha/rmabill/rmabill101c/src/u084a.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u085.qts >> compare_source.log
diff u085.qts /alpha/rmabill/rmabill101c/src/u085.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u085b.qts >> compare_source.log
diff u085b.qts /alpha/rmabill/rmabill101c/src/u085b.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u085c.qts >> compare_source.log
diff u085c.qts /alpha/rmabill/rmabill101c/src/u085c.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u085d.qts >> compare_source.log
diff u085d.qts /alpha/rmabill/rmabill101c/src/u085d.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u086.qts >> compare_source.log
diff u086.qts /alpha/rmabill/rmabill101c/src/u086.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u086a.qts >> compare_source.log
diff u086a.qts /alpha/rmabill/rmabill101c/src/u086a.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u090f.qts >> compare_source.log
diff u090f.qts /alpha/rmabill/rmabill101c/src/u090f.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u093.qts >> compare_source.log
diff u093.qts /alpha/rmabill/rmabill101c/src/u093.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u095.qts >> compare_source.log
diff u095.qts /alpha/rmabill/rmabill101c/src/u095.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u095a.qts >> compare_source.log
diff u095a.qts /alpha/rmabill/rmabill101c/src/u095a.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u099.qts >> compare_source.log
diff u099.qts /alpha/rmabill/rmabill101c/src/u099.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u103.qts >> compare_source.log
diff u103.qts /alpha/rmabill/rmabill101c/src/u103.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u103a.qts >> compare_source.log
diff u103a.qts /alpha/rmabill/rmabill101c/src/u103a.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u104.qts >> compare_source.log
diff u104.qts /alpha/rmabill/rmabill101c/src/u104.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u104a.qts >> compare_source.log
diff u104a.qts /alpha/rmabill/rmabill101c/src/u104a.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u105.qts >> compare_source.log
diff u105.qts /alpha/rmabill/rmabill101c/src/u105.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u105a.qts >> compare_source.log
diff u105a.qts /alpha/rmabill/rmabill101c/src/u105a.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u106.qts >> compare_source.log
diff u106.qts /alpha/rmabill/rmabill101c/src/u106.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u110.qts >> compare_source.log
diff u110.qts /alpha/rmabill/rmabill101c/src/u110.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u110_hsc.qts >> compare_source.log
diff u110_hsc.qts /alpha/rmabill/rmabill101c/src/u110_hsc.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u110_rma.qts >> compare_source.log
diff u110_rma.qts /alpha/rmabill/rmabill101c/src/u110_rma.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u111a.qzs >> compare_source.log
diff u111a.qzs /alpha/rmabill/rmabill101c/src/u111a.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u111c.qts >> compare_source.log
diff u111c.qts /alpha/rmabill/rmabill101c/src/u111c.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u112.qts >> compare_source.log
diff u112.qts /alpha/rmabill/rmabill101c/src/u112.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u113.qts >> compare_source.log
diff u113.qts /alpha/rmabill/rmabill101c/src/u113.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u114_94nov_calcd_ytdceil.qts >> compare_source.log
diff u114_94nov_calcd_ytdceil.qts /alpha/rmabill/rmabill101c/src/u114_94nov_calcd_ytdceil.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u114_replaced_by_u114ab.qts >> compare_source.log
diff u114_replaced_by_u114ab.qts /alpha/rmabill/rmabill101c/src/u114_replaced_by_u114ab.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u114a.qts >> compare_source.log
diff u114a.qts /alpha/rmabill/rmabill101c/src/u114a.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u114b.qts >> compare_source.log
diff u114b.qts /alpha/rmabill/rmabill101c/src/u114b.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u115_common.qts >> compare_source.log
diff u115_common.qts /alpha/rmabill/rmabill101c/src/u115_common.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u115_debug.qts >> compare_source.log
diff u115_debug.qts /alpha/rmabill/rmabill101c/src/u115_debug.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u115a.qts >> compare_source.log
diff u115a.qts /alpha/rmabill/rmabill101c/src/u115a.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u115a_out_of_date.qts >> compare_source.log
diff u115a_out_of_date.qts /alpha/rmabill/rmabill101c/src/u115a_out_of_date.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u115b.qts >> compare_source.log
diff u115b.qts /alpha/rmabill/rmabill101c/src/u115b.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u115c.qts >> compare_source.log
diff u115c.qts /alpha/rmabill/rmabill101c/src/u115c.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u116.qts >> compare_source.log
diff u116.qts /alpha/rmabill/rmabill101c/src/u116.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u116_defines1.qts >> compare_source.log
diff u116_defines1.qts /alpha/rmabill/rmabill101c/src/u116_defines1.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u117.qts >> compare_source.log
diff u117.qts /alpha/rmabill/rmabill101c/src/u117.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u118.qts >> compare_source.log
diff u118.qts /alpha/rmabill/rmabill101c/src/u118.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u118_icu.qts >> compare_source.log
diff u118_icu.qts /alpha/rmabill/rmabill101c/src/u118_icu.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u119.qts >> compare_source.log
diff u119.qts /alpha/rmabill/rmabill101c/src/u119.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u119_before_split_u119b.qts >> compare_source.log
diff u119_before_split_u119b.qts /alpha/rmabill/rmabill101c/src/u119_before_split_u119b.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u119b.qts >> compare_source.log
diff u119b.qts /alpha/rmabill/rmabill101c/src/u119b.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u121.qts >> compare_source.log
diff u121.qts /alpha/rmabill/rmabill101c/src/u121.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u122.qts >> compare_source.log
diff u122.qts /alpha/rmabill/rmabill101c/src/u122.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u125.qts >> compare_source.log
diff u125.qts /alpha/rmabill/rmabill101c/src/u125.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u126.qts >> compare_source.log
diff u126.qts /alpha/rmabill/rmabill101c/src/u126.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u127.qts >> compare_source.log
diff u127.qts /alpha/rmabill/rmabill101c/src/u127.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u130.qts >> compare_source.log
diff u130.qts /alpha/rmabill/rmabill101c/src/u130.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u131a.qts >> compare_source.log
diff u131a.qts /alpha/rmabill/rmabill101c/src/u131a.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u131b.qts >> compare_source.log
diff u131b.qts /alpha/rmabill/rmabill101c/src/u131b.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u132.qts >> compare_source.log
diff u132.qts /alpha/rmabill/rmabill101c/src/u132.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u140_a.qts >> compare_source.log
diff u140_a.qts /alpha/rmabill/rmabill101c/src/u140_a.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u140_a2s.qts >> compare_source.log
diff u140_a2s.qts /alpha/rmabill/rmabill101c/src/u140_a2s.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u140_b.qts >> compare_source.log
diff u140_b.qts /alpha/rmabill/rmabill101c/src/u140_b.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u140_c.qts >> compare_source.log
diff u140_c.qts /alpha/rmabill/rmabill101c/src/u140_c.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u140_d.qts >> compare_source.log
diff u140_d.qts /alpha/rmabill/rmabill101c/src/u140_d.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u140_e.qts >> compare_source.log
diff u140_e.qts /alpha/rmabill/rmabill101c/src/u140_e.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u190_fix.qts >> compare_source.log
diff u190_fix.qts /alpha/rmabill/rmabill101c/src/u190_fix.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u190_yearend_1_appears_renamed_to_yearend_1.qts >> compare_source.log
diff u190_yearend_1_appears_renamed_to_yearend_1.qts /alpha/rmabill/rmabill101c/src/u190_yearend_1_appears_renamed_to_yearend_1.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u190_yearend_3_appears_renamed_to_yearend_2.qts >> compare_source.log
diff u190_yearend_3_appears_renamed_to_yearend_2.qts /alpha/rmabill/rmabill101c/src/u190_yearend_3_appears_renamed_to_yearend_2.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u210.qts >> compare_source.log
diff u210.qts /alpha/rmabill/rmabill101c/src/u210.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u699.qts >> compare_source.log
diff u699.qts /alpha/rmabill/rmabill101c/src/u699.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u704.qts >> compare_source.log
diff u704.qts /alpha/rmabill/rmabill101c/src/u704.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u704_6mths.qts >> compare_source.log
diff u704_6mths.qts /alpha/rmabill/rmabill101c/src/u704_6mths.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u705.qts >> compare_source.log
diff u705.qts /alpha/rmabill/rmabill101c/src/u705.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u706a_replaced_by_newu706a.qts >> compare_source.log
diff u706a_replaced_by_newu706a.qts /alpha/rmabill/rmabill101c/src/u706a_replaced_by_newu706a.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u708.qts >> compare_source.log
diff u708.qts /alpha/rmabill/rmabill101c/src/u708.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u710.qts >> compare_source.log
diff u710.qts /alpha/rmabill/rmabill101c/src/u710.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u714.qts >> compare_source.log
diff u714.qts /alpha/rmabill/rmabill101c/src/u714.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u716a.qts >> compare_source.log
diff u716a.qts /alpha/rmabill/rmabill101c/src/u716a.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u716c.qts >> compare_source.log
diff u716c.qts /alpha/rmabill/rmabill101c/src/u716c.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u802.qts >> compare_source.log
diff u802.qts /alpha/rmabill/rmabill101c/src/u802.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u901.qts >> compare_source.log
diff u901.qts /alpha/rmabill/rmabill101c/src/u901.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u901_special.qts >> compare_source.log
diff u901_special.qts /alpha/rmabill/rmabill101c/src/u901_special.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u902.qts >> compare_source.log
diff u902.qts /alpha/rmabill/rmabill101c/src/u902.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u903.qts >> compare_source.log
diff u903.qts /alpha/rmabill/rmabill101c/src/u903.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u904.qts >> compare_source.log
diff u904.qts /alpha/rmabill/rmabill101c/src/u904.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u910.qts >> compare_source.log
diff u910.qts /alpha/rmabill/rmabill101c/src/u910.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u912.qts >> compare_source.log
diff u912.qts /alpha/rmabill/rmabill101c/src/u912.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u914.qts >> compare_source.log
diff u914.qts /alpha/rmabill/rmabill101c/src/u914.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u915.qts >> compare_source.log
diff u915.qts /alpha/rmabill/rmabill101c/src/u915.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u918.qts >> compare_source.log
diff u918.qts /alpha/rmabill/rmabill101c/src/u918.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u920.qts >> compare_source.log
diff u920.qts /alpha/rmabill/rmabill101c/src/u920.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u931.qts >> compare_source.log
diff u931.qts /alpha/rmabill/rmabill101c/src/u931.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u931_22.qts >> compare_source.log
diff u931_22.qts /alpha/rmabill/rmabill101c/src/u931_22.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u931_22_non_y2k.qts >> compare_source.log
diff u931_22_non_y2k.qts /alpha/rmabill/rmabill101c/src/u931_22_non_y2k.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u931_non_y2k.qts >> compare_source.log
diff u931_non_y2k.qts /alpha/rmabill/rmabill101c/src/u931_non_y2k.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u931_temp.qts >> compare_source.log
diff u931_temp.qts /alpha/rmabill/rmabill101c/src/u931_temp.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u933_22.qts >> compare_source.log
diff u933_22.qts /alpha/rmabill/rmabill101c/src/u933_22.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u933_OLD.qts >> compare_source.log
diff u933_OLD.qts /alpha/rmabill/rmabill101c/src/u933_OLD.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u933_before_split.qts >> compare_source.log
diff u933_before_split.qts /alpha/rmabill/rmabill101c/src/u933_before_split.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u933_before_split_into_2part_a.qts >> compare_source.log
diff u933_before_split_into_2part_a.qts /alpha/rmabill/rmabill101c/src/u933_before_split_into_2part_a.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u933a_part2.qts >> compare_source.log
diff u933a_part2.qts /alpha/rmabill/rmabill101c/src/u933a_part2.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u933a_part2_PER_DEIM_LOGIC.qts >> compare_source.log
diff u933a_part2_PER_DEIM_LOGIC.qts /alpha/rmabill/rmabill101c/src/u933a_part2_PER_DEIM_LOGIC.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u933b.qts >> compare_source.log
diff u933b.qts /alpha/rmabill/rmabill101c/src/u933b.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u933c.qts >> compare_source.log
diff u933c.qts /alpha/rmabill/rmabill101c/src/u933c.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u933witheld.qts >> compare_source.log
diff u933witheld.qts /alpha/rmabill/rmabill101c/src/u933witheld.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u934.qts >> compare_source.log
diff u934.qts /alpha/rmabill/rmabill101c/src/u934.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u941.qts >> compare_source.log
diff u941.qts /alpha/rmabill/rmabill101c/src/u941.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: u993a_DONT_NEED.qts >> compare_source.log
diff u993a_DONT_NEED.qts /alpha/rmabill/rmabill101c/src/u993a_DONT_NEED.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unixnames.qzs >> compare_source.log
diff unixnames.qzs /alpha/rmabill/rmabill101c/src/unixnames.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlof001.qzs >> compare_source.log
diff unlof001.qzs /alpha/rmabill/rmabill101c/src/unlof001.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlof002.qts >> compare_source.log
diff unlof002.qts /alpha/rmabill/rmabill101c/src/unlof002.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlof002_susp_addr.qts >> compare_source.log
diff unlof002_susp_addr.qts /alpha/rmabill/rmabill101c/src/unlof002_susp_addr.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlof002_susp_dtl.qts >> compare_source.log
diff unlof002_susp_dtl.qts /alpha/rmabill/rmabill101c/src/unlof002_susp_dtl.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlof002_susp_hdr.qts >> compare_source.log
diff unlof002_susp_hdr.qts /alpha/rmabill/rmabill101c/src/unlof002_susp_hdr.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlof010.qzs >> compare_source.log
diff unlof010.qzs /alpha/rmabill/rmabill101c/src/unlof010.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlof020.qzs >> compare_source.log
diff unlof020.qzs /alpha/rmabill/rmabill101c/src/unlof020.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlof020extra.qzs >> compare_source.log
diff unlof020extra.qzs /alpha/rmabill/rmabill101c/src/unlof020extra.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlof020hst.qzs >> compare_source.log
diff unlof020hst.qzs /alpha/rmabill/rmabill101c/src/unlof020hst.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlof021.qzs >> compare_source.log
diff unlof021.qzs /alpha/rmabill/rmabill101c/src/unlof021.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlof022.qzs >> compare_source.log
diff unlof022.qzs /alpha/rmabill/rmabill101c/src/unlof022.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlof040.qzs >> compare_source.log
diff unlof040.qzs /alpha/rmabill/rmabill101c/src/unlof040.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlof050.qts >> compare_source.log
diff unlof050.qts /alpha/rmabill/rmabill101c/src/unlof050.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlof050.qzs >> compare_source.log
diff unlof050.qzs /alpha/rmabill/rmabill101c/src/unlof050.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlof050hist.qzs >> compare_source.log
diff unlof050hist.qzs /alpha/rmabill/rmabill101c/src/unlof050hist.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlof050tphist.qzs >> compare_source.log
diff unlof050tphist.qzs /alpha/rmabill/rmabill101c/src/unlof050tphist.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlof060.qzs >> compare_source.log
diff unlof060.qzs /alpha/rmabill/rmabill101c/src/unlof060.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlof071.qzs >> compare_source.log
diff unlof071.qzs /alpha/rmabill/rmabill101c/src/unlof071.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlof073.qzs >> compare_source.log
diff unlof073.qzs /alpha/rmabill/rmabill101c/src/unlof073.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlof087.qts >> compare_source.log
diff unlof087.qts /alpha/rmabill/rmabill101c/src/unlof087.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlof088.qzs >> compare_source.log
diff unlof088.qzs /alpha/rmabill/rmabill101c/src/unlof088.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlof090_1.qzs >> compare_source.log
diff unlof090_1.qzs /alpha/rmabill/rmabill101c/src/unlof090_1.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlof090_2.qzs >> compare_source.log
diff unlof090_2.qzs /alpha/rmabill/rmabill101c/src/unlof090_2.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlof090_3.qzs >> compare_source.log
diff unlof090_3.qzs /alpha/rmabill/rmabill101c/src/unlof090_3.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlof090_4.qzs >> compare_source.log
diff unlof090_4.qzs /alpha/rmabill/rmabill101c/src/unlof090_4.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlof090_5.qzs >> compare_source.log
diff unlof090_5.qzs /alpha/rmabill/rmabill101c/src/unlof090_5.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlof090_6.qzs >> compare_source.log
diff unlof090_6.qzs /alpha/rmabill/rmabill101c/src/unlof090_6.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlof090_iconst.qzs >> compare_source.log
diff unlof090_iconst.qzs /alpha/rmabill/rmabill101c/src/unlof090_iconst.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlof095.qzs >> compare_source.log
diff unlof095.qzs /alpha/rmabill/rmabill101c/src/unlof095.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlof110.qzs >> compare_source.log
diff unlof110.qzs /alpha/rmabill/rmabill101c/src/unlof110.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlof110hst.qzs >> compare_source.log
diff unlof110hst.qzs /alpha/rmabill/rmabill101c/src/unlof110hst.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlof112.qzs >> compare_source.log
diff unlof112.qzs /alpha/rmabill/rmabill101c/src/unlof112.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlof112hst.qzs >> compare_source.log
diff unlof112hst.qzs /alpha/rmabill/rmabill101c/src/unlof112hst.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlof113.qzs >> compare_source.log
diff unlof113.qzs /alpha/rmabill/rmabill101c/src/unlof113.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlof113hst.qzs >> compare_source.log
diff unlof113hst.qzs /alpha/rmabill/rmabill101c/src/unlof113hst.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlof119.qzs >> compare_source.log
diff unlof119.qzs /alpha/rmabill/rmabill101c/src/unlof119.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlof119hst.qzs >> compare_source.log
diff unlof119hst.qzs /alpha/rmabill/rmabill101c/src/unlof119hst.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlof123.qzs >> compare_source.log
diff unlof123.qzs /alpha/rmabill/rmabill101c/src/unlof123.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlof190.qzs >> compare_source.log
diff unlof190.qzs /alpha/rmabill/rmabill101c/src/unlof190.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlof191.qzs >> compare_source.log
diff unlof191.qzs /alpha/rmabill/rmabill101c/src/unlof191.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlof198.qzs >> compare_source.log
diff unlof198.qzs /alpha/rmabill/rmabill101c/src/unlof198.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlof199.qzs >> compare_source.log
diff unlof199.qzs /alpha/rmabill/rmabill101c/src/unlof199.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlof924.qzs >> compare_source.log
diff unlof924.qzs /alpha/rmabill/rmabill101c/src/unlof924.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: unlosoc.qzs >> compare_source.log
diff unlosoc.qzs /alpha/rmabill/rmabill101c/src/unlosoc.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: up_f084.qts >> compare_source.log
diff up_f084.qts /alpha/rmabill/rmabill101c/src/up_f084.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: up_f087.qts >> compare_source.log
diff up_f087.qts /alpha/rmabill/rmabill101c/src/up_f087.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: up_f088.qts >> compare_source.log
diff up_f088.qts /alpha/rmabill/rmabill101c/src/up_f088.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: update_f001.qts >> compare_source.log
diff update_f001.qts /alpha/rmabill/rmabill101c/src/update_f001.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: updf020.qts >> compare_source.log
diff updf020.qts /alpha/rmabill/rmabill101c/src/updf020.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: updf050.qts >> compare_source.log
diff updf050.qts /alpha/rmabill/rmabill101c/src/updf050.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: upload.qts >> compare_source.log
diff upload.qts /alpha/rmabill/rmabill101c/src/upload.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: upload_f024.qts >> compare_source.log
diff upload_f024.qts /alpha/rmabill/rmabill101c/src/upload_f024.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: utl0001.qts >> compare_source.log
diff utl0001.qts /alpha/rmabill/rmabill101c/src/utl0001.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: utl00013.qzs >> compare_source.log
diff utl00013.qzs /alpha/rmabill/rmabill101c/src/utl00013.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: utl0002.qzs >> compare_source.log
diff utl0002.qzs /alpha/rmabill/rmabill101c/src/utl0002.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: utl0003.qzs >> compare_source.log
diff utl0003.qzs /alpha/rmabill/rmabill101c/src/utl0003.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: utl0006.qzs >> compare_source.log
diff utl0006.qzs /alpha/rmabill/rmabill101c/src/utl0006.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: utl0006a.qzs >> compare_source.log
diff utl0006a.qzs /alpha/rmabill/rmabill101c/src/utl0006a.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: utl0007.qzs >> compare_source.log
diff utl0007.qzs /alpha/rmabill/rmabill101c/src/utl0007.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: utl0010.qts >> compare_source.log
diff utl0010.qts /alpha/rmabill/rmabill101c/src/utl0010.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: utl0010_a.qts >> compare_source.log
diff utl0010_a.qts /alpha/rmabill/rmabill101c/src/utl0010_a.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: utl0010_b.qts >> compare_source.log
diff utl0010_b.qts /alpha/rmabill/rmabill101c/src/utl0010_b.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: utl0010_c.qts >> compare_source.log
diff utl0010_c.qts /alpha/rmabill/rmabill101c/src/utl0010_c.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: utl0010_d1.qts >> compare_source.log
diff utl0010_d1.qts /alpha/rmabill/rmabill101c/src/utl0010_d1.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: utl0010_d10.qts >> compare_source.log
diff utl0010_d10.qts /alpha/rmabill/rmabill101c/src/utl0010_d10.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: utl0010_d2.qts >> compare_source.log
diff utl0010_d2.qts /alpha/rmabill/rmabill101c/src/utl0010_d2.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: utl0010_d3.qts >> compare_source.log
diff utl0010_d3.qts /alpha/rmabill/rmabill101c/src/utl0010_d3.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: utl0010_d4.qts >> compare_source.log
diff utl0010_d4.qts /alpha/rmabill/rmabill101c/src/utl0010_d4.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: utl0010_d5.qts >> compare_source.log
diff utl0010_d5.qts /alpha/rmabill/rmabill101c/src/utl0010_d5.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: utl0010_d6.qts >> compare_source.log
diff utl0010_d6.qts /alpha/rmabill/rmabill101c/src/utl0010_d6.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: utl0010_d7.qts >> compare_source.log
diff utl0010_d7.qts /alpha/rmabill/rmabill101c/src/utl0010_d7.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: utl0010_d8.qts >> compare_source.log
diff utl0010_d8.qts /alpha/rmabill/rmabill101c/src/utl0010_d8.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: utl0010_d9.qts >> compare_source.log
diff utl0010_d9.qts /alpha/rmabill/rmabill101c/src/utl0010_d9.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: utl0010_e.qts >> compare_source.log
diff utl0010_e.qts /alpha/rmabill/rmabill101c/src/utl0010_e.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: utl0010_f.qzs >> compare_source.log
diff utl0010_f.qzs /alpha/rmabill/rmabill101c/src/utl0010_f.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: utl0011.qzs >> compare_source.log
diff utl0011.qzs /alpha/rmabill/rmabill101c/src/utl0011.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: utl0012.qzs >> compare_source.log
diff utl0012.qzs /alpha/rmabill/rmabill101c/src/utl0012.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: utl0014.qzs >> compare_source.log
diff utl0014.qzs /alpha/rmabill/rmabill101c/src/utl0014.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: utl0015.qts >> compare_source.log
diff utl0015.qts /alpha/rmabill/rmabill101c/src/utl0015.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: utl0015.qzs >> compare_source.log
diff utl0015.qzs /alpha/rmabill/rmabill101c/src/utl0015.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: utl0020a.qts >> compare_source.log
diff utl0020a.qts /alpha/rmabill/rmabill101c/src/utl0020a.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: utl0020b.qts >> compare_source.log
diff utl0020b.qts /alpha/rmabill/rmabill101c/src/utl0020b.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: utl0020c.qzs >> compare_source.log
diff utl0020c.qzs /alpha/rmabill/rmabill101c/src/utl0020c.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: utl0020c_use.qzs >> compare_source.log
diff utl0020c_use.qzs /alpha/rmabill/rmabill101c/src/utl0020c_use.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: utl0020d.qzs >> compare_source.log
diff utl0020d.qzs /alpha/rmabill/rmabill101c/src/utl0020d.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: utl0100.qts >> compare_source.log
diff utl0100.qts /alpha/rmabill/rmabill101c/src/utl0100.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: utl0101.qzs >> compare_source.log
diff utl0101.qzs /alpha/rmabill/rmabill101c/src/utl0101.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: utl1000.qks >> compare_source.log
diff utl1000.qks /alpha/rmabill/rmabill101c/src/utl1000.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: utl1001.qks >> compare_source.log
diff utl1001.qks /alpha/rmabill/rmabill101c/src/utl1001.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: utl1002.qks >> compare_source.log
diff utl1002.qks /alpha/rmabill/rmabill101c/src/utl1002.qks >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: webomafee.qzs >> compare_source.log
diff webomafee.qzs /alpha/rmabill/rmabill101c/src/webomafee.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: webomafee_bkp.qzs >> compare_source.log
diff webomafee_bkp.qzs /alpha/rmabill/rmabill101c/src/webomafee_bkp.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: webomafee_bkp1.qzs >> compare_source.log
diff webomafee_bkp1.qzs /alpha/rmabill/rmabill101c/src/webomafee_bkp1.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: webomafee_dtl.qzs >> compare_source.log
diff webomafee_dtl.qzs /alpha/rmabill/rmabill101c/src/webomafee_dtl.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: webpatients.qzs >> compare_source.log
diff webpatients.qzs /alpha/rmabill/rmabill101c/src/webpatients.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: x.qts >> compare_source.log
diff x.qts /alpha/rmabill/rmabill101c/src/x.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: x.qzs >> compare_source.log
diff x.qzs /alpha/rmabill/rmabill101c/src/x.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: xx.qzs >> compare_source.log
diff xx.qzs /alpha/rmabill/rmabill101c/src/xx.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: xxxx.qts >> compare_source.log
diff xxxx.qts /alpha/rmabill/rmabill101c/src/xxxx.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: ytyas.qzs >> compare_source.log
diff ytyas.qzs /alpha/rmabill/rmabill101c/src/ytyas.qzs >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: yearend_1.qts >> compare_source.log
diff yearend_1.qts /alpha/rmabill/rmabill101c/src/yearend_1.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: yearend_2.qts >> compare_source.log
diff yearend_2.qts /alpha/rmabill/rmabill101c/src/yearend_2.qts >> compare_source.log
echo ' ' >> compare_source.log

echo PROCESSING: yearend_earnings_f112.qzs >> compare_source.log
diff yearend_earnings_f112.qzs /alpha/rmabill/rmabill101c/src/yearend_earnings_f112.qzs >> compare_source.log
echo ' ' >> compare_source.log

