#-------------------------------------------------------------------------------
# File 'cleanup_60_monthend.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'cleanup_60_monthend'
#-------------------------------------------------------------------------------

echo "*** THIS PROGRAM WILL DELETE ALL OF THE SUBFILES  HISTORY FILE "
echo ""
echo "SORT\WORK MSTRS AND ALL THE REPORTS FOR CLINICS 60 TO 65"
echo ""
echo "**** HIT NEW LINE TO CONTINUE ****"
$garbage = Read-Host

Set-Location $env:application_production\60

Remove-Item stage40tp.ls *> $null
Remove-Item divide.ls *> $null
Remove-Item r004atp.sf* *> $null
Remove-Item r004disk*.sf* *> $null
Remove-Item r007* *> $null
Remove-Item r004disk*.ps* *> $null
Remove-Item r070atp.sf* *> $null
Remove-Item r070btp.sf* *> $null
Remove-Item utl0006.txt *> $null
Remove-Item utl0006a.txt *> $null
Remove-Item utl0007.txt *> $null
Remove-Item r004*.txt *> $null
Remove-Item r005*.txt *> $null
Remove-Item r006*.txt *> $null
Remove-Item r011*.txt *> $null
Remove-Item r012*.txt *> $null
Remove-Item r013*.txt *> $null
Remove-Item r015*.txt *> $null
Remove-Item r051*.txt *> $null
Remove-Item r070*.txt *> $null
Remove-Item r004tp *> $null
Remove-Item r005tp *> $null
Remove-Item r006tp *> $null
Remove-Item r011 *> $null
Remove-Item r012tp *> $null
Remove-Item r013tp *> $null
Remove-Item r015tp *> $null
Remove-Item r051ca *> $null
Remove-Item r051cb *> $null
Remove-Item r070tp_60 *> $null
Remove-Item r070 *> $null
Remove-Item r210 *> $null
Remove-Item f002_claims_history_tape_file *> $null
Remove-Item filer001* *> $null
Remove-Item claims_subfile* *> $null

Set-Location $env:application_production\61
Remove-Item claims*sf*
Remove-Item r004*
Remove-Item r051*
Set-Location $env:application_production\62
Remove-Item claims*sf*
Remove-Item r004*
Remove-Item r051*
Set-Location $env:application_production\63
Remove-Item claims*sf*
Remove-Item r004*
Remove-Item r051*
Set-Location $env:application_production\64
Remove-Item claims*sf*
Remove-Item r004*
Remove-Item r051*
Set-Location $env:application_production\65
Remove-Item claims*sf*
Remove-Item r004*
Remove-Item r051*
Set-Location $env:application_production\66
Remove-Item claims*sf*
Remove-Item r004*
Remove-Item r051*
