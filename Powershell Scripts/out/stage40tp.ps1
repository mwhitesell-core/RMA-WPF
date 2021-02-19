#-------------------------------------------------------------------------------
# File 'stage40tp.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'stage40tp'
#-------------------------------------------------------------------------------

# 99/dec/15 B.E. changed deleted to ignore errors, alignment changes
# 05/jul/07 M.C. include r004btp_portal.txt in the run                    
# 05/aug/10 M.C. undo    r004btp_portal.txt in the run                    


Set-Location $env:application_production\60
echo ""
Get-Date
echo ""

Remove-Item utl0006.txt, utl0006a.txt, utl0007.txt *> $null
Remove-Item r004atp.sf*, r004btp.txt, r004ctp.txt, r004dtp.txt *> $null
Remove-Item r004tp *> $null
Remove-Item r004diska.ps*, r004diskb.ps*, r004diska.sf*, r004diskb.sf* *> $null
Remove-Item r005atp.txt, r005btp.txt, r005ctp.txt, r005dtp.txt *> $null
Remove-Item r005tp *> $null
Remove-Item r006atp.txt, r006btp.txt, r006ctp.txt, r006dtp.txt *> $null
Remove-Item r006tp *> $null
Remove-Item r007tp.ps*, r007tp.sf* *> $null
Remove-Item r011a.txt, r011b.txt, r011c.txt *> $null
Remove-Item r011 *> $null
Remove-Item r012atp.txt, r012btp.txt, r012ctp.txt *> $null
Remove-Item r012tp *> $null
Remove-Item r013atp.txt, r013btp.txt, r013ctp.txt *> $null
Remove-Item r013tp *> $null
Remove-Item r015atp.txt, r015btp.txt, r015ctp.txt *> $null
Remove-Item r015tp *> $null
Remove-Item r051caatp.txt, r051cabtp.txt, r051cactp.txt, r051cbatp.txt, r051cbbtp.txt, r051cbctp.txt *> $null
Remove-Item r051ca, r051cb *> $null
Remove-Item r051*tp* *> $null
Remove-Item r070atp.sf*, r070btp.sf*, r070ctp.txt, r070dtp.txt *> $null
Remove-Item r070tp_60 *> $null
Remove-Item divide.ls

Get-Date
echo ""
#$rcmd = $env:QUIZ + "stage40tp
$rcmd = $env:QUIZ + "utl0006"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "utl0006a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "utl0007"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r004atp"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r004btp"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r004ctp"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r004dtp"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r005atp"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r005btp"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r005ctp"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r005dtp"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r006atp"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r006btp"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r006ctp"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r006dtp"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r011a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r011b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r011c"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r012atp"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r012btp"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r012ctp"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r013atp"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r013btp"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r013ctp"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r015atp"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r015btp"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r015ctp"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r051caatp"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r051cabtp"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r051cactp"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r051cbatp"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r051cbbtp"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r051cbctp"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r070atp"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r070btp"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r070ctp"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r070dtp"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r051a_tp_per"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r051b_tp_per"
Invoke-Expression $rcmd

echo ""
Get-Content r004ctp.txt, r004dtp.txt | Add-Content r004btp.txt
Get-Content r005btp.txt, r005ctp.txt, r005dtp.txt | Add-Content r005atp.txt
Get-Content r006btp.txt, r006ctp.txt, r006dtp.txt | Add-Content r006atp.txt
Get-Content r011b.txt, r011c.txt | Add-Content r011a.txt
Get-Content r012btp.txt, r012ctp.txt | Add-Content r012atp.txt
Get-Content r013btp.txt, r013ctp.txt | Add-Content r013atp.txt
Get-Content r015btp.txt, r015ctp.txt | Add-Content r015atp.txt
Get-Content r051cabtp.txt, r051cactp.txt | Add-Content r051caatp.txt
Get-Content r051cbbtp.txt, r051cbctp.txt | Add-Content r051cbatp.txt
Get-Content r070dtp.txt | Add-Content r070ctp.txt
echo ""
echo ""
Move-Item -Force r004btp.txt r004tp
Move-Item -Force r005atp.txt r005tp
Move-Item -Force r006atp.txt r006tp
Move-Item -Force r011a.txt r011
Move-Item -Force r012atp.txt r012tp
Move-Item -Force r013atp.txt r013tp
Move-Item -Force r015atp.txt r015tp
Move-Item -Force r051caatp.txt r051ca
Move-Item -Force r051cbatp.txt r051cb
Move-Item -Force r070ctp.txt r070tp_60
echo ""
#lp r051b_tp_per.txt
Get-Content utl0006.txt | Out-Printer
Get-Content utl0006a.txt | Out-Printer
Get-Content utl0007.txt | Out-Printer
Get-Content r006tp | Out-Printer
Get-Content r012tp | Out-Printer
#lp r004tp
Get-Content r005tp | Out-Printer
Get-Content r006tp | Out-Printer
#lp r011
#lp r012tp
#lp r013tp
#lp r015tp
#lp r051ca
#lp r051cb
Get-Content r070tp_60 | Out-Printer
echo ""
Get-Date
