ftp -v blue <<  FTP_EXIT
cd rma_source
put addrlabels.qzs
put audit_doc.qzs
put auditdoc.qzs
put billinglist.qzs
put d110.qks	;brad
put fix85-b.qts	;brad
put h110.qks	;brad
put m010.qks	;brad
put m020.qks	;brad
put m100.qks	;brad
put buildfiles.qus
put cfund1.qzs
put cfund2.qzs
put check91.qzs
put check92.qzs
put check9392.qzs
put check94.qzs
put check9492.qzs
put check98.qzs
put check_claims_mstr.qzs
put checkf020.qzs
put checkf020a.qzs
put checkf119.qzs
put common_diag.qzs
put common_diag_80.qzs
put common_diag_81.qzs
put common_oma.qzs
put common_ref.qzs
put compile_proyas.qts
put compile_proyas.qzs
put compile_qks.qks
put compile_qts.qts
put compile_qzs.qzs
put compile_yas.qzs
put compile_yasemin.qts
put compile_yasemin.qzs
put comptest_qts.qts
put createf085.cbl
put createsusp.cbl
put d001.cbl
put d002.cbl
put d003.cbl
put d004.cbl
put d020.qks
put d020a.qks
put d020b.qks
put d050.cbl
put d085.qks
put d112.qks
put d112a.qks
put d113.qks
put d118.qks
put d119.qks
put d199.qks
put d705.qks
put d705_6mths.qks
put d705a.qks
put d705a_bk1.qks
put d705b.qks
put d713.qks
put debugu114.qzs
put debugu116.qzs
put del_claims.qts
put dg2pc1_use_code.qts
put dg2pc1a.qts
put dg2pc1b.qts
put dg2pc1c.qts
put docohip.qzs
put docpaycode.qzs
put docrev.qzs
put doctordump.qzs
put doctorlist.qzs
put downf020full.qzs
put dump91.qzs
put dump98.qzs
put dump_f190_1.qzs
put dump_f190_2.qzs
put dump_f190_3.qzs
put dumpf002_missing_f010_2_fix_claims.qts
put dumpf002_seq.qzs
put dumpf002_via_bkey.qzs
put dumpf002_via_pkey.qzs
put dumpf002_via_pkey_range.qzs
put dumpf010_acr_parm.qzs
put dumpf010_hnbr_parm.qzs
put dumpf010_ikey_parm.qzs
put dumpf010_ikey_range.qzs
put dumpf040.qzs
put dumpf119.qzs
put dumpf119ytd.qzs
put dycomgroups.qks
put f002_dump_via_bkey.qzs
put f002_dump_via_pkey.qzs
put f020_zero.qts
put f020rec.qts
put f050ma1.qts
put f051.qzs
put f060_mth_ceil.qks
put f060_mth_exp.qks
put f119_doctor_ytd.def
put filer001a.qzs
put filer001b.qzs
put filer001c.qzs
put fix50a.qzs
put fix50b.qts
put fix50b_1st.qts
put fix50b_2nd.qts
put fix50b_3rd.qts
put fix50c.qts
put fix51b.qts
put fix51b_1st.qts
put fix51b_2nd.qts
put fix51b_3rd.qts
put fix_claims.qks
put fix_claims_via_acr.qts
put fix_ph.awk
put fix_ph.com
put fix_r010.qts
put fix_r010.qzs
put fix_seq_nbrs.qts
put fixf002_batch_clm_hdr.qts
put fixf002_clm_hdr.qts
put fixf002pkey.qts
put fixf010.qks
put fixf020.qts
put fixf024.qts
put fixf050.qks
put fixf060.qts
put fixf113.qts
put fixpkey.qts
put h020a.qks
put h112.qks
put h112a.qks
put h113.qks
put h119.qks
put holdback.qzs
put holdbk1.qzs
put holdbk2.qzs
put holdbk3.qzs
put holdbk3orig.qzs
put holdbk4.qts
put holdbk5.qzs
put holdbk5orig.qzs
put holdbk6.qts
put holdbk6.qzs
put ikeyscreen.qks
put in01.qks
put in01.use
put in01a.qks
put in01b.qks
put in01c.qks
put in01d.qks
put juneser.qzs
put juneser1.qzs
put juneser2.qzs
put kev.cbl
put locations.qzs
put m010_acr.qks
put m010_yas.qks
put m010ver.qks
put m021.qks
put m025.qks
put m030.cbl
put m040.cbl
put m070.cbl
put m080.cbl
put m090.cbl
put m090f.qks
put m091.qks
put m094.cbl
put m095.cbl
put m097.qks
put m098.qks
put m099.cbl
put m101.qks
put m102.qks
put m190.qks
put m190a.qks
put m191.qks
put m199.qks
put m902.qks
put m907.qks
put m908.qks
put m913.qks
put m916.qks
put m932.qks
put m940.qks
put mary91.qzs
put mary98.qzs
put mc.qts
put mc_f090.qts
put mce.qzs
put menu.cbl
put menu.ipf
put mohr.qzs
put u030b.qts	;moira
put newcode.qzs
put newu703_6mths.cbl
put nonblank98.qzs
put payrolllist.qzs
put pm01.qks
put pm02.qks
put pm03.qks
put pm04.qks
put pm05.qks
put pm06.qks
put pm07.qks
put pm08.qks
put pm09.qks
put pm10.qks
put pm18.qzs
put pm19.qzs
put pm20.qzs
put pm21.qzs
put pm22.qzs
put pm23.qzs
put pm24.qts
put pm25.qzs
put pm26.qzs
put pm27.qzs
put printer_codes.def
put proxy.qzs
put purge_f050_f051.qts
put purge_f050f051_83.qts
put r001.cbl
put r001b.cbl
put r002a.cbl
put r002b.cbl
put r002b.qzs
put r004_cycle.cbl
put r004a.cbl
put r004b.cbl
put r004c.cbl
put r005.cbl
put r010cycle.cbl
put r011.cbl
put r011a.qzs
put r011b.qzs
put r011c.qzs
put r011mohr.qzs
put r012.cbl
put r013.cbl
put r014.cbl
put r014sum.cbl
put r020a.qzs
put r020d.qzs
put r020d1_use.qzs
put r020d2_use.qzs
put r020e.qzs
put r020e_81_spec.qzs
put r020f.qzs
put r022a.qzs
put r022d.qzs
put r022e.qzs
put r023b.qzs
put r023c.qzs
put r023d.qzs
put r030d.qzs ;yas has borrowed
put r030e.qzs ;yas has borrowed
put r030f.qzs ;yas has borrowed
put r030g3.qzs
put r030g5.qzs
put r030h.qzs ;yas has borrowed
put r030i.qzs ;yas has borrowed
put r030j.qzs ;yas has borrowed
put r040.cbl
put r051a.cbl
put r051b.cbl
put r070b.cbl
put r070c.cbl
put r071.cbl
put r085.qzs
put r087.qzs
put r088.qzs
put r089.qzs
put r111b.qzs
put r119a.qzs
put r119b.qzs
put r119c.qzs
put r120.qts
put r120.qzs
put r121a.qzs
put r121b.qzs
put r121c.qzs
put r124a.qzs
put r125.qzs
put r129.qzs
put r150a.cbl
put r150b.cbl
put r151.qzs
put r151_yrend.qzs
put r190_yearend_verify.qzs
put r211.qzs
put r702.qzs
put r707.qzs
put r709a.qzs
put r709b.qzs
put r711.qzs
put r712.qzs
put r715.qzs
put r801a.qzs
put r801b.qzs
put r801c.qzs
put r811.cbl
put r997a.qzs
put std_hilite.qks
put sy030.qks
put sy031.qks
put sy033.qks
put u015.cbl
put u020_use.qts
put u020a.qts
put u020b.qts
put u020b_use.qts
put u020c.qts
put u020c_use.qts
put u022b.qts
put u022c.qts
put u022sd.qts
put u023a.qts
put u030a.cbl
put u030b_22.qts
put u030b_60.qts
put u030b_60_cur.qts
put u030b_cur.qts
put u030b_fixup.qts
put u030b_orig_no_80.qts
put u030b_rerun.qts
put u030c.cbl
put u085.qts
put u086.qts
put u090f.qts
put u103.qts
put u103a.qts
put u104.qts
put u104a.qts
put u105.qts
put u110.qts
put u110_hsc.use
put u110_rma.use
put u111a.qzs
put u111c.qts
put u112.qts
put u113.qts
put u114a.qts
put u114b.qts
put u115a.qts
put u115b.qts
put u115c.qts
put u116.qts
put u116_defines1.qts
put u117.qts
put u118.qts
put u119.qts
put u121.qts
put u122.qts
put u125.qts
put u126.qts
put u127.qts
put u190_fix.qts
put u190_yearend_1.qts
put u190_yearend_3.qts
put u210.qts
put u703.cbl
put u704.qts
put u705.qts
put u708.qts
put u710.qts
put u714.qts
put u802.qts
put u901.qts
put u903.qts
put u904.qts
put u910.qts
put u912.qts
put u914.qts
put u915.qts
put u917.qts
put u918.qts
put u920.qts
put u931.qts
put u931_22.qts
put u933.qts
put u933_22.qts
put u933witheld.qts
put u997.qts
put update94.qts
put update98.qts
put update_claims.qts
put update_f020_pay_sub_code.qts
put update_f060.qts
put update_f060a.qts
put update_f060b.qts
put update_f071.qts
put update_tot.qts
put updf020.qts
put updf050.qts
put upload.qts
put upload_f024.qts
put yearend_1.qts                                                      
quit
FTP_EXIT