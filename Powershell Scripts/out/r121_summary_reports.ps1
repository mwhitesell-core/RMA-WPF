#-------------------------------------------------------------------------------
# File 'r121_summary_reports.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'r121_summary_reports'
#-------------------------------------------------------------------------------

# 2015/Jan/15   MC      original (this macro should be run once a year in January when t4a is needed)

param(
  [string] $1,
  [string] $2,
  [string] $3,
  [string] $4
)

echo "START  r121_summary_reports"

echo "executing r121_summ.qts"

Set-Location $env:application_production

Remove-Item r121*summ*sf*, r121_summ*.txt

# first parameter below -  enter ep nbr for Current  Calendar June  (either 12 or 13 ep nbr) 
# second  parameter below -  enter ep nbr for Current  Calendar December 
# third parameter below -  enter calendar year 

$rcmd = $env:QTP + "r121_summ $1 $2 $3 $4"
Invoke-Expression $rcmd

echo "executing r121a\b\c_summ.qzs"
$rcmd = $env:QUIZ + "r121a_summ"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r121b_summ" #execute $obj/r121b_company
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r121c_summ"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r121c_summ DISC_r121d_summ 2" #sel if dept-company = 2""
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r121c_summ DISC_r121e_summ 3" #sel if dept-company = 3""
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r121c_summ DISC_r121f_summ 4" #sel if dept-company = 4""
Invoke-Expression $rcmd

echo "building r121_summ report"
#CORE - RDL fix
if (Test-Path r121a_summ.txt -PathType leaf)
{
   cat r121a_summ.txt -raw | %{$_.replace("<FORMFEED>", "`f")} > r121a_summ2.txt
   copy-item r121a_summ2.txt r121a_summ.txt
   remove-item r121a_summ2.txt
}

if (Test-Path r121b_summ.txt -PathType leaf)
{
   cat r121b_summ.txt -raw | %{$_.replace("<FORMFEED>", "`f")} > r121b_summ2.txt
   copy-item r121b_summ2.txt r121b_summ.txt
   remove-item r121b_summ2.txt
}

if (Test-Path r121c_summ.txt -PathType leaf)
{
   cat r121c_summ.txt -raw | %{$_.replace("<FORMFEED>", "`f")} > r121c_summ2.txt
   copy-item r121c_summ2.txt r121c_summ.txt
   remove-item r121c_summ2.txt
}

if (Test-Path r121d_summ.txt -PathType leaf)
{
   cat r121d_summ.txt -raw | %{$_.replace("<FORMFEED>", "`f")} > r121d_summ2.txt
   copy-item r121d_summ2.txt r121d_summ.txt
   remove-item r121d_summ2.txt
}

if (Test-Path r121e_summ.txt -PathType leaf)
{
   cat r121e_summ.txt -raw | %{$_.replace("<FORMFEED>", "`f")} > r121e_summ2.txt
   copy-item r121e_summ2.txt r121e_summ.txt
   remove-item r121e_summ2.txt
}

if (Test-Path r121f_summ.txt -PathType leaf)
{
   cat r121f_summ.txt -raw | %{$_.replace("<FORMFEED>", "")} > r121f_summ2.txt
   copy-item r121f_summ2.txt r121f_summ.txt
   remove-item r121f_summ2.txt
}

Get-Content r121a_summ.txt, r121b_summ.txt, r121c_summ.txt, r121d_summ.txt, r121e_summ.txt, r121f_summ.txt `
  | Set-Content r121_summ_${4}.txt
Get-Content r121c_summ.txt, r121d_summ.txt, r121e_summ.txt, r121f_summ.txt | Set-Content r121m_summ.txt
#lp r121m_summ.txt

#mv r121b_company.txt  r121b_company_${1}.txt
#lp r121b_company_${1}.txt

echo "DONE  r121_summary_reports"
