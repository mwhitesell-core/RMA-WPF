#-------------------------------------------------------------------------------
# File 'recreate_clean_suspense.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'recreate_clean_suspense'
#-------------------------------------------------------------------------------

# recreate_clean_suspense 
# 00/sep/05 B.E. - changed rm statements from rm filename* to filename*.txt
# 00/oct/20 B.E. - changed delete of suspend files to not use * wildcard
# 12/May/01 M.C. - include delete of suspdtl_all subfile  & web_before_after.txt
#
#lp bg2215.00* 

Remove-Item f002_suspend_hdr.dat
#Remove-Item f002_suspend_hdr.idx
Remove-Item f002_suspend_dtl.dat
#Remove-Item f002_suspend_dtl.idx
Remove-Item f002_suspend_address.dat
#Remove-Item f002_suspend_address.idx
Remove-Item f002_suspend_desc.dat
#Remove-Item f002_suspend_desc.idx

#Core - create files in script rather than COBOL
#$rcmd = $env:COBOL + "createsusp"
#Invoke-Expression $rcmd
New-Item -Path . -Name "f002_suspend_address.dat" -ItemType "file"
New-Item -Path . -Name "f002_suspend_dtl.dat" -ItemType "file"
New-Item -Path . -Name "f002_suspend_hdr.dat" -ItemType "file"
New-Item -Path . -Name "f002_suspend_desc.dat" -ItemType "file"

&$env:cmd\create_susp_links.com

Remove-Item *.in
Remove-Item *.out
Remove-Item submit*
Remove-Item ru701
Remove-Item ru701_acr.*
Remove-Item ru701_cycle
Remove-Item ru703a
Remove-Item ru703b
Remove-Item ru703c
Remove-Item r715*.txt
Remove-Item r711*.txt
Remove-Item r707*.txt
Remove-Item r709*.txt
Remove-Item r712*.txt
Remove-Item *u706*.sf*
Remove-Item *u708*.sf*
Remove-Item suspdtl.txt
Remove-Item *suspdtl.sf*
Remove-Item suspdtl.sf*
Remove-Item suspend_agent*.txt
Remove-Item susp_agent_dtl.sf*
Remove-Item dump_tech.txt
Remove-Item dump_tech.sf*
Remove-Item suspend_desc.txt
Remove-Item check_susp.txt
Remove-Item r710.txt
Remove-Item submit_disk_pat_in.sf*
Remove-Item submit_disk_pat_new
Remove-Item submit_disk_pat_out
Remove-Item check_susp.txt
Remove-Item suspend_total.txt
Remove-Item suspend_suffix.txt
Remove-Item suspend_status.txt
Remove-Item suspend_fee.txt
Remove-Item savef010_mc.sf*
Remove-Item susp_agent_dtl*
Remove-Item suspdtl_all*
Remove-Item web_before_after.txt
