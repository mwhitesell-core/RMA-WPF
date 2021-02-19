#-------------------------------------------------------------------------------
# File 'delete_sort_files.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'delete_sort_files'
#-------------------------------------------------------------------------------

echo "********************************************************************"
echo "THIS WILL DELETE All the sort work mstr in all the directories"
echo "********************************************************************"
echo "PRESS `"NEWLINE`"  TO DELETE OHIP REPORTS AND TAPE"
$garbage = Read-Host

Set-Location $env:application_production
Remove-Item r004*sort*
Remove-Item r051*sort*
Remove-Item r070*work*
Remove-Item r051*work*
Remove-Item r004*work*
Remove-Item r004*.sf*
Remove-Item r004wf
Remove-Item r051wf

Set-Location $env:application_production\31
Remove-Item r004*sort*
Remove-Item r051*sort*
Remove-Item r070*work*
Remove-Item r051*work*
Remove-Item r004*work*
Remove-Item r004*.sf*
Remove-Item r004wf
Remove-Item r051wf

Set-Location $env:application_production\32
Remove-Item r004*sort*
Remove-Item r051*sort*
Remove-Item r070*work*
Remove-Item r051*work*
Remove-Item r004*work*
Remove-Item r004*.sf*
Remove-Item r004wf
Remove-Item r051wf

Set-Location $env:application_production\33
Remove-Item r004*sort*
Remove-Item r051*sort*
Remove-Item r070*work*
Remove-Item r051*work*
Remove-Item r004*work*
Remove-Item r004*.sf*
Remove-Item r004wf
Remove-Item r051wf

Set-Location $env:application_production\34
Remove-Item r004*sort*
Remove-Item r051*sort*
Remove-Item r070*work*
Remove-Item r051*work*
Remove-Item r004*work*
Remove-Item r004*.sf*
Remove-Item r004wf
Remove-Item r051wf

Set-Location $env:application_production\35
Remove-Item r004*sort*
Remove-Item r051*sort*
Remove-Item r070*work*
Remove-Item r051*work*
Remove-Item r004*work*
Remove-Item r004*.sf*
Remove-Item r004wf
Remove-Item r051wf

Set-Location $env:application_production\36
Remove-Item r004*sort*
Remove-Item r051*sort*
Remove-Item r070*work*
Remove-Item r051*work*
Remove-Item r004*work*
Remove-Item r004*.sf*
Remove-Item r004wf
Remove-Item r051wf

Set-Location $env:application_production\41
Remove-Item r004*sort*
Remove-Item r051*sort*
Remove-Item r070*work*
Remove-Item r051*work*
Remove-Item r004*work*
Remove-Item r004*.sf*
Remove-Item r004wf
Remove-Item r051wf

Set-Location $env:application_production\42
Remove-Item r004*sort*
Remove-Item r051*sort*
Remove-Item r070*work*
Remove-Item r051*work*
Remove-Item r004*work*
Remove-Item r004*.sf*
Remove-Item r004wf
Remove-Item r051wf

Set-Location $env:application_production\43
Remove-Item r004*sort*
Remove-Item r051*sort*
Remove-Item r070*work*
Remove-Item r051*work*
Remove-Item r004*work*
Remove-Item r004*.sf*
Remove-Item r004wf
Remove-Item r051wf

Set-Location $env:application_production\44
Remove-Item r004*sort*
Remove-Item r051*sort*
Remove-Item r070*work*
Remove-Item r051*work*
Remove-Item r004*work*
Remove-Item r004*.sf*
Remove-Item r004wf
Remove-Item r051wf

Set-Location $env:application_production\45
Remove-Item r004*sort*
Remove-Item r051*sort*
Remove-Item r070*work*
Remove-Item r051*work*
Remove-Item r004*work*
Remove-Item r004*.sf*
Remove-Item r004wf
Remove-Item r051wf

Set-Location $env:application_production\46
Remove-Item r004*sort*
Remove-Item r051*sort*
Remove-Item r070*work*
Remove-Item r051*work*
Remove-Item r004*work*
Remove-Item r004*.sf*
Remove-Item r004wf
Remove-Item r051wf

Set-Location $env:application_production\48
Remove-Item r004*sort*
Remove-Item r051*sort*
Remove-Item r070*work*
Remove-Item r051*work*
Remove-Item r004*work*
Remove-Item r004*.sf*
Remove-Item r004wf
Remove-Item r051wf

Set-Location $env:application_production\60
Remove-Item r004*sort*
Remove-Item r051*sort*
Remove-Item r070*work*
Remove-Item r051*work*
Remove-Item r004*work*
Remove-Item r004*.sf*
Remove-Item r004wf
Remove-Item r051wf

Set-Location $env:application_production\61
Remove-Item r004*sort*
Remove-Item r051*sort*
Remove-Item r070*work*
Remove-Item r051*work*
Remove-Item r004*work*
Remove-Item r004*.sf*
Remove-Item r004wf
Remove-Item r051wf

Set-Location $env:application_production\62
Remove-Item r004*sort*
Remove-Item r051*sort*
Remove-Item r070*work*
Remove-Item r051*work*
Remove-Item r004*work*
Remove-Item r004*.sf*
Remove-Item r004wf
Remove-Item r051wf

Set-Location $env:application_production\63
Remove-Item r004*sort*
Remove-Item r051*sort*
Remove-Item r070*work*
Remove-Item r051*work*
Remove-Item r004*work*
Remove-Item r004*.sf*
Remove-Item r004wf
Remove-Item r051wf

Set-Location $env:application_production\64
Remove-Item r004*sort*
Remove-Item r051*sort*
Remove-Item r070*work*
Remove-Item r051*work*
Remove-Item r004*work*
Remove-Item r004*.sf*
Remove-Item r004wf
Remove-Item r051wf

Set-Location $env:application_production\65
Remove-Item r004*sort*
Remove-Item r051*sort*
Remove-Item r070*work*
Remove-Item r051*work*
Remove-Item r004*work*
Remove-Item r004*.sf*
Remove-Item r004wf
Remove-Item r051wf

Set-Location $env:application_production\70
Remove-Item r004*sort*
Remove-Item r051*sort*
Remove-Item r070*work*
Remove-Item r051*work*
Remove-Item r004*work*
Remove-Item r004*.sf*
Remove-Item r004wf
Remove-Item r051wf

Set-Location $env:application_production\71
Remove-Item r004*sort*
Remove-Item r051*sort*
Remove-Item r070*work*
Remove-Item r051*work*
Remove-Item r004*work*
Remove-Item r004*.sf*
Remove-Item r004wf
Remove-Item r051wf

Set-Location $env:application_production\72
Remove-Item r004*sort*
Remove-Item r051*sort*
Remove-Item r070*work*
Remove-Item r051*work*
Remove-Item r004*work*
Remove-Item r004*.sf*
Remove-Item r004wf
Remove-Item r051wf

Set-Location $env:application_production\73
Remove-Item r004*sort*
Remove-Item r051*sort*
Remove-Item r070*work*
Remove-Item r051*work*
Remove-Item r004*work*
Remove-Item r004*.sf*
Remove-Item r004wf
Remove-Item r051wf

Set-Location $env:application_production\74
Remove-Item r004*sort*
Remove-Item r051*sort*
Remove-Item r070*work*
Remove-Item r051*work*
Remove-Item r004*work*
Remove-Item r004*.sf*
Remove-Item r004wf
Remove-Item r051wf

Set-Location $env:application_production\75
Remove-Item r004*sort*
Remove-Item r051*sort*
Remove-Item r070*work*
Remove-Item r051*work*
Remove-Item r004*work*
Remove-Item r004*.sf*
Remove-Item r004wf
Remove-Item r051wf

Set-Location $env:application_production\80
Remove-Item r004*sort*
Remove-Item r051*sort*
Remove-Item r070*work*
Remove-Item r051*work*
Remove-Item r004*work*
Remove-Item r004*.sf*
Remove-Item r004wf
Remove-Item r051wf

Set-Location $env:application_production\82
Remove-Item r004*sort*
Remove-Item r051*sort*
Remove-Item r070*work*
Remove-Item r051*work*
Remove-Item r004*work*
Remove-Item r004*.sf*
Remove-Item r004wf
Remove-Item r051wf

Set-Location $env:application_production\84
Remove-Item r004*sort*
Remove-Item r051*sort*
Remove-Item r070*work*
Remove-Item r051*work*
Remove-Item r004*work*
Remove-Item r004*.sf*
Remove-Item r004wf
Remove-Item r051wf

Set-Location $env:application_production\86
Remove-Item r004*sort*
Remove-Item r051*sort*
Remove-Item r070*work*
Remove-Item r051*work*
Remove-Item r004*work*
Remove-Item r004*.sf*
Remove-Item r004wf
Remove-Item r051wf

Set-Location $env:application_production\91
Remove-Item r004*sort*
Remove-Item r051*sort*
Remove-Item r070*work*
Remove-Item r051*work*
Remove-Item r004*work*
Remove-Item r004*.sf*
Remove-Item r004wf
Remove-Item r051wf

Set-Location $env:application_production\92
Remove-Item r004*sort*
Remove-Item r051*sort*
Remove-Item r070*work*
Remove-Item r051*work*
Remove-Item r004*work*
Remove-Item r004*.sf*
Remove-Item r004wf
Remove-Item r051wf

Set-Location $env:application_production\93
Remove-Item r004*sort*
Remove-Item r051*sort*
Remove-Item r070*work*
Remove-Item r051*work*
Remove-Item r004*work*
Remove-Item r004*.sf*
Remove-Item r004wf
Remove-Item r051wf

Set-Location $env:application_production\94
Remove-Item r004*sort*
Remove-Item r051*sort*
Remove-Item r070*work*
Remove-Item r051*work*
Remove-Item r004*work*
Remove-Item r004*.sf*
Remove-Item r004wf
Remove-Item r051wf

Set-Location $env:application_production\95
Remove-Item r004*sort*
Remove-Item r051*sort*
Remove-Item r070*work*
Remove-Item r051*work*
Remove-Item r004*work*
Remove-Item r004*.sf*
Remove-Item r004wf
Remove-Item r051wf

Set-Location $env:application_production\96
Remove-Item r004*sort*
Remove-Item r051*sort*
Remove-Item r070*work*
Remove-Item r051*work*
Remove-Item r004*work*
Remove-Item r004*.sf*
Remove-Item r004wf
Remove-Item r051wf

Set-Location $env:application_production\98
Remove-Item r004*sort*
Remove-Item r051*sort*
Remove-Item r070*work*
Remove-Item r051*work*
Remove-Item r004*work*
Remove-Item r004*.sf*
Remove-Item r004wf
Remove-Item r051wf
