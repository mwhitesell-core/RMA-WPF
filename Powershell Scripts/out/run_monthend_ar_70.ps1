#-------------------------------------------------------------------------------
# File 'run_monthend_ar_70.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_monthend_ar_70'
#-------------------------------------------------------------------------------

Set-Location $env:application_production\70
echo ""
Get-Date
echo ""

Remove-Item utl0006_70.txt, utl0006a_70.txt, utl0007_70.txt, utl0007a_70.txt *> $null
Remove-Item r004atp_70.sf*, r004btp_70.txt, r004ctp_70.txt, r004dtp_70.txt *> $null
Remove-Item r004tp_70 *> $null
Remove-Item r005atp_70.txt, r005btp_70.txt, r005ctp_70.txt, r005dtp_70.txt *> $null
Remove-Item r005tp_70 *> $null
Remove-Item r006atp_70.txt, r006btp_70.txt, r006ctp_70.txt, r006dtp_70.txt *> $null
Remove-Item r006tp_70 *> $null
Remove-Item r007tp_70.ps*, r007tp_70.sf* *> $null
Remove-Item r011a_70.txt, r011b_70.txt, r011c_70.txt *> $null
Remove-Item r011_70 *> $null
Remove-Item r012atp_70.txt, r012btp_70.txt, r012ctp_70.txt *> $null
Remove-Item r012tp_70 *> $null
Remove-Item r013atp_70.txt, r013btp_70.txt, r013ctp_70.txt *> $null
Remove-Item r013tp_70 *> $null
Remove-Item r015atp_70.txt, r015btp_70.txt, r015ctp_70.txt *> $null
Remove-Item r015tp_70 *> $null
Remove-Item r051caatp_70.txt, r051cabtp_70.txt, r051cactp_70.txt, r051cbatp_70.txt, r051cbbtp_70.txt, r051cbctp_70.txt `
  *> $null
Remove-Item r051ca_70, r051cb_70 *> $null
Remove-Item r051*tp*70* *> $null
Remove-Item r070atp_70.sf*, r070btp_70.sf*, r070ctp_70.txt, r070dtp_70.txt *> $null
Remove-Item r070tp_70 *> $null
Remove-Item divide.ls

Get-Date
echo ""
#$rcmd = $env:QUIZ + "stage40tp_70
$rcmd = $env:QUIZ + "utl0006_70"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "utl0006a_70"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "utl0007_70"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "utl0007a_70"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r004atp_70"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r004btp_70"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r004ctp_70"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r004dtp_70"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r005atp_70"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r005btp_70"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r005ctp_70"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r005dtp_70"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r006atp_70"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r006btp_70"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r006ctp_70"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r006dtp_70"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r011a_70"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r011b_70"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r011c_70"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r012atp_70"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r012btp_70"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r012ctp_70"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r013atp_70"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r013btp_70"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r013ctp_70"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r015atp_70"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r015btp_70"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r015ctp_70"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r051caatp_70"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r051cabtp_70"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r051cactp_70"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r051cbatp_70"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r051cbbtp_70"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r051cbctp_70"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r070atp_70"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r070btp_70"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r070ctp_70"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r070dtp_70"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r051a_tp_per_70"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r051b_tp_per_70"
Invoke-Expression $rcmd
echo ""
Get-Content r004ctp_70.txt, r004dtp_70.txt | Add-Content r004btp_70.txt
Get-Content r005btp_70.txt, r005ctp_70.txt, r005dtp_70.txt | Add-Content r005atp_70.txt
Get-Content r006btp_70.txt, r006ctp_70.txt, r006dtp_70.txt | Add-Content r006atp_70.txt
Get-Content r011b_70.txt, r011c_70.txt | Add-Content r011a_70.txt
Get-Content r012btp_70.txt, r012ctp_70.txt | Add-Content r012atp_70.txt
Get-Content r013btp_70.txt, r013ctp_70.txt | Add-Content r013atp_70.txt
Get-Content r015btp_70.txt, r015ctp_70.txt | Add-Content r015atp_70.txt
Get-Content r051cabtp_70.txt, r051cactp_70.txt | Add-Content r051caatp_70.txt
Get-Content r051cbbtp_70.txt, r051cbctp_70.txt | Add-Content r051cbatp_70.txt
Get-Content r070dtp_70.txt | Add-Content r070ctp_70.txt
echo ""
echo ""
Move-Item -Force r004btp_70.txt r004tp_70
Move-Item -Force r005atp_70.txt r005tp_70
Move-Item -Force r006atp_70.txt r006tp_70
Move-Item -Force r011a_70.txt r011_70
Move-Item -Force r012atp_70.txt r012tp_70
Move-Item -Force r013atp_70.txt r013tp_70
Move-Item -Force r015atp_70.txt r015tp_70
Move-Item -Force r051caatp_70.txt r051ca_70
Move-Item -Force r051cbatp_70.txt r051cb_70
Move-Item -Force r070ctp_70.txt r070tp_70
echo ""
Get-Content utl0006_70.txt | Out-Printer
Get-Content utl0006a_70.txt | Out-Printer
Get-Content utl0007_70.txt | Out-Printer
Get-Content utl0007a_70.txt | Out-Printer
Get-Content r006tp_70 | Out-Printer
Get-Content r012tp_70 | Out-Printer
#lp r004tp_70
Get-Content r005tp_70 | Out-Printer
Get-Content r006tp_70 | Out-Printer
#lp r011_70
#lp r012tp_70
#lp r013tp_70
#lp r015tp_70
#lp r051ca_70
#lp r051cb_70
Get-Content r070tp_70 | Out-Printer
echo ""
Get-Date
