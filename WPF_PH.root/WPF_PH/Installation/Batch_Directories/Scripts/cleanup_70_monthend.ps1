#-------------------------------------------------------------------------------
# File 'cleanup_70_monthend.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'cleanup_70_monthend'
#-------------------------------------------------------------------------------

echo "*** THIS PROGRAM WILL DELETE ALL OF THE SUBFILES  HISTORY FILE "
echo ""
echo "SORT\WORK MSTRS AND ALL THE REPORTS FOR CLINICS 60 TO 65"
echo ""
echo "**** HIT NEW LINE TO CONTINUE ****"
$garbage = Read-Host

Set-Location $env:application_production\70

Remove-Item r004atp*.sf* *> $null
Remove-Item r007* *> $null
Remove-Item r070atp*.sf* *> $null
Remove-Item r070btp*.sf* *> $null
Remove-Item utl0006*.txt *> $null
Remove-Item utl0006a*.txt *> $null
Remove-Item utl0007*.txt *> $null
Remove-Item r004*.txt *> $null
Remove-Item r005*.txt *> $null
Remove-Item r006*.txt *> $null
Remove-Item r011*.txt *> $null
Remove-Item r012*.txt *> $null
Remove-Item r013*.txt *> $null
Remove-Item r015*.txt *> $null
Remove-Item r051*.txt *> $null
Remove-Item r070*.txt *> $null
Remove-Item r004tp_70 *> $null
Remove-Item r005tp_70 *> $null
Remove-Item r006tp_70 *> $null
Remove-Item r011_70 *> $null
Remove-Item r012tp_70 *> $null
Remove-Item r013tp_70 *> $null
Remove-Item r015tp_70 *> $null
Remove-Item r051ca_70 *> $null
Remove-Item r051cb_70 *> $null
Remove-Item r070tp_70 *> $null
Remove-Item r070_70 *> $null
Remove-Item r210_70 *> $null
Remove-Item f002_claims_history_tape_file *> $null
Remove-Item filer001* *> $null
Remove-Item claims_subfile* *> $null

Set-Location $env:application_production\71
Remove-Item claims*sf*
Set-Location $env:application_production\72
Remove-Item claims*sf*
Set-Location $env:application_production\73
Remove-Item claims*sf*
Set-Location $env:application_production\74
Remove-Item claims*sf*
Set-Location $env:application_production\75
Remove-Item claims*sf*
