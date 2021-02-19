#-------------------------------------------------------------------------------
# File 'stage40tp.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'stage40tp'
#-------------------------------------------------------------------------------

# 99/dec/15 B.E. changed deleted to ignore errors, alignment changes
# 05/jul/07 M.C. include r004btp_portal.txt in the run                    
# 05/aug/10 M.C. undo    r004btp_portal.txt in the run                    


Set-Location $application_production\60
echo ""
Get-Date
echo ""

Remove-Item utl0006.txt, utl0006a.txt, utl0007.txt  > $null
Remove-Item r004atp.sf*, r004btp.txt, r004ctp.txt, r004dtp.txt  > $null
Remove-Item r004tp  > $null
Remove-Item r004diska.ps*, r004diskb.ps*, r004diska.sf*, r004diskb.sf*  > $null
Remove-Item r005atp.txt, r005btp.txt, r005ctp.txt, r005dtp.txt  > $null
Remove-Item r005tp  > $null
Remove-Item r006atp.txt, r006btp.txt, r006ctp.txt, r006dtp.txt  > $null
Remove-Item r006tp  > $null
Remove-Item r007tp.ps*, r007tp.sf*  > $null
Remove-Item r011a.txt, r011b.txt, r011c.txt  > $null
Remove-Item r011  > $null
Remove-Item r012atp.txt, r012btp.txt, r012ctp.txt  > $null
Remove-Item r012tp  > $null
Remove-Item r013atp.txt, r013btp.txt, r013ctp.txt  > $null
Remove-Item r013tp  > $null
Remove-Item r015atp.txt, r015btp.txt, r015ctp.txt  > $null
Remove-Item r015tp  > $null
Remove-Item r051caatp.txt, r051cabtp.txt, r051cactp.txt, r051cbatp.txt, r051cbbtp.txt, r051cbctp.txt  > $null
Remove-Item r051ca, r051cb  > $null
Remove-Item r051*tp*  > $null
Remove-Item r070atp.sf*, r070btp.sf*, r070ctp.txt, r070dtp.txt  > $null
Remove-Item r070tp_60  > $null
Remove-Item divide.ls

Get-Date
echo ""
quiz++ $obj\stage40tp
echo ""
Get-Content r004ctp.txt, r004dtp.txt  >> r004btp.txt
Get-Content r005btp.txt, r005ctp.txt, r005dtp.txt  >> r005atp.txt
Get-Content r006btp.txt, r006ctp.txt, r006dtp.txt  >> r006atp.txt
Get-Content r011b.txt, r011c.txt  >> r011a.txt
Get-Content r012btp.txt, r012ctp.txt  >> r012atp.txt
Get-Content r013btp.txt, r013ctp.txt  >> r013atp.txt
Get-Content r015btp.txt, r015ctp.txt  >> r015atp.txt
Get-Content r051cabtp.txt, r051cactp.txt  >> r051caatp.txt
Get-Content r051cbbtp.txt, r051cbctp.txt  >> r051cbatp.txt
Get-Content r070dtp.txt  >> r070ctp.txt
echo ""
echo ""
Move-Item r004btp.txt r004tp
Move-Item r005atp.txt r005tp
Move-Item r006atp.txt r006tp
Move-Item r011a.txt r011
Move-Item r012atp.txt r012tp
Move-Item r013atp.txt r013tp
Move-Item r015atp.txt r015tp
Move-Item r051caatp.txt r051ca
Move-Item r051cbatp.txt r051cb
Move-Item r070ctp.txt r070tp_60
echo ""
#lp r051b_tp_per.txt
Get-Contents utl0006.txt| Out-Printer
Get-Contents utl0006a.txt| Out-Printer
Get-Contents utl0007.txt| Out-Printer
Get-Contents r006tp| Out-Printer
Get-Contents r012tp| Out-Printer
#lp r004tp
Get-Contents r005tp| Out-Printer
Get-Contents r006tp| Out-Printer
#lp r011
#lp r012tp
#lp r013tp
#lp r015tp
#lp r051ca
#lp r051cb
Get-Contents r070tp_60| Out-Printer
echo ""
Get-Date
