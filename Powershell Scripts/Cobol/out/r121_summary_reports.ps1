#-------------------------------------------------------------------------------
# File 'r121_summary_reports.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'r121_summary_reports'
#-------------------------------------------------------------------------------

# 2015/Jan/15   MC      original (this macro should be run once a year in January when t4a is needed)

echo "START  r121_summary_reports"

echo "executing r121_summ.qts"

Set-Location $application_production

Remove-Item r121*summ*sf*, r121_summ*.txt

# first  parameter below -  enter ep nbr for Previous Calendar December 
# second parameter below -  enter ep nbr for Current  Calendar June  (either 12 or 13 ep nbr) 
# third  parameter below -  enter ep nbr for Current  Calendar December 
# fourth parameter below -  enter calendar year 

$pipedInput = @"
execute $obj/r121_summ
201306
201312
201406
2014
"@

$pipedInput | qtp++

echo "executing r121a\b\c_summ.qzs"
$pipedInput = @"
execute $obj/r121a_summ
execute $obj/r121b_summ
;execute $obj/r121b_company
execute $obj/r121c_summ
exec $obj/r121c_summ nogo
set rep dev disc name r121d_summ
set formfeed
sel if dept-company = 2
go
exec $obj/r121c_summ nogo
set rep dev disc name r121e_summ
set formfeed
sel if dept-company = 3
go
exec $obj/r121c_summ nogo
set rep dev disc name r121f_summ
set formfeed
sel if dept-company = 4
go
"@

$pipedInput | quiz++

echo "building r121_summ report"
Get-Content r121a_summ.txt, r121b_summ.txt, r121c_summ.txt, r121d_summ.txt, r121e_summ.txt, r121f_summ.txt  > r121_summ_${1}.txt
Get-Content r121c_summ.txt, r121d_summ.txt, r121e_summ.txt, r121f_summ.txt  > r121m_summ.txt
#lp r121m_summ.txt

#mv r121b_company.txt  r121b_company_${1}.txt
#lp r121b_company_${1}.txt

echo "DONE  r121_summary_reports"
