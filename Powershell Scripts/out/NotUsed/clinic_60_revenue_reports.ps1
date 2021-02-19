#-------------------------------------------------------------------------------
# File 'clinic_60_revenue_reports.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'clinic_60_revenue_reports'
#-------------------------------------------------------------------------------

Get-Date
echo ""
&$env:QUIZ stage40tprevenue
echo ""
Get-Content r011b.txt, r011c.txt | Add-Content r011a.txt
Get-Content r012btp.txt, r012ctp.txt | Add-Content r012atp.txt
Get-Content r013btp.txt, r013ctp.txt | Add-Content r013atp.txt
Get-Content r015btp.txt, r015ctp.txt | Add-Content r015atp.txt
Get-Content r051cabtp.txt, r051cactp.txt | Add-Content r051caatp.txt
Get-Content r051cbbtp.txt, r051cbctp.txt | Add-Content r051cbatp.txt
echo ""
echo ""
Move-Item -Force r011a.txt r011_60_after
Move-Item -Force r012atp.txt r012tp_60_after
Move-Item -Force r013atp.txt r013tp_60_after
Move-Item -Force r015atp.txt r015tp_60_after
Move-Item -Force r051caatp.txt r051ca_60_after
Move-Item -Force r051cbatp.txt r051cb_60_after
echo ""
Get-Date
