# recreate_clean_suspense 
# 00/sep/05 B.E. - changed rm statements from rm filename* to filename*.txt
# 00/oct/20 B.E. - changed delete of suspend files to not use * wildcard
# 12/May/01 M.C. - include delete of suspdtl_all subfile  & web_before_after.txt
#
#lp bg2215.00* 

rm f002_suspend_hdr
rm f002_suspend_hdr.idx
rm f002_suspend_dtl
rm f002_suspend_dtl.idx
rm f002_suspend_address
rm f002_suspend_address.idx
rm f002_suspend_desc
rm f002_suspend_desc.idx

cobrun $obj/createsusp
. $cmd/create_susp_links.com

rm *.in
rm *.out
rm submit*  
rm ru701
rm ru701_acr.txt
rm ru701_cycle
rm ru703a
rm ru703b
rm ru703c
rm r715*.txt
rm r711*.txt
rm r707*.txt
rm r709*.txt
rm r712*.txt
rm *u706*.sf*
rm *u708*.sf*
rm suspdtl.txt
rm *suspdtl.sf*
rm suspdtl.sf*
rm suspend_agent*.txt
rm susp_agent_dtl.sf* 
rm dump_tech.txt
rm dump_tech.sf*
rm suspend_desc.txt
rm check_susp.txt
rm r710.txt
rm submit_disk_pat_in.sf*
rm submit_disk_pat_new
rm submit_disk_pat_out
rm check_susp.txt
rm suspend_total.txt
rm suspend_suffix.txt 
rm suspend_status.txt 
rm suspend_fee.txt
rm savef010_mc.sf*
rm susp_agent_dtl*
rm suspdtl_all*    
rm web_before_after.txt
