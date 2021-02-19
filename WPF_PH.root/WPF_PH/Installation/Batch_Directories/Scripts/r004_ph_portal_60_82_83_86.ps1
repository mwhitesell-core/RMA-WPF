#-------------------------------------------------------------------------------
# File 'r004_ph_portal_60_82_83_86.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'r004_ph_portal_60_82_83_86'
#-------------------------------------------------------------------------------

echo" --- r004c_portal (PH) ---"

Set-Location $env:application_production\61
&$env:cmd\r004_portal 61@  61

$rcmd = $env:quiz +"r004atp 61000000 61ZZZ999"
Invoke-Expression $rcmd > r004_portal.log
$rcmd = $env:quiz +"r004btp_portal"
Invoke-Expression $rcmd >> r004_portal.log

Move-Item -Force r004btp_portal.txt r004c_portal_61.txt


Set-Location $env:application_production\62
&$env:cmd\r004_portal 62@  62

$rcmd = $env:quiz +"r004atp 62000000 62ZZZ999"
Invoke-Expression $rcmd > r004_portal.log
$rcmd = $env:quiz +"r004btp_portal"
Invoke-Expression $rcmd >> r004_portal.log

Move-Item -Force r004btp_portal.txt r004c_portal_62.txt


Set-Location $env:application_production\63
&$env:cmd\r004_portal 63@  63

$rcmd = $env:quiz +"r004atp 63000000 63ZZZ999"
Invoke-Expression $rcmd > r004_portal.log
$rcmd = $env:quiz +"r004btp_portal"
Invoke-Expression $rcmd >> r004_portal.log

Move-Item -Force r004btp_portal.txt r004c_portal_63.txt


Set-Location $env:application_production\64
&$env:cmd\r004_portal 64@  64

$rcmd = $env:quiz +"r004atp 64000000 64ZZZ999"
Invoke-Expression $rcmd > r004_portal.log
$rcmd = $env:quiz +"r004btp_portal"
Invoke-Expression $rcmd >> r004_portal.log

Move-Item -Force r004btp_portal.txt r004c_portal_64.txt


Set-Location $env:application_production\65
&$env:cmd\r004_portal 65@  65

$rcmd = $env:quiz +"r004atp 65000000 65ZZZ999"
Invoke-Expression $rcmd > r004_portal.log
$rcmd = $env:quiz +"r004btp_portal"
Invoke-Expression $rcmd >> r004_portal.log


Move-Item -Force r004btp_portal.txt r004c_portal_65.txt


Set-Location $env:application_production\66
&$env:cmd\r004_portal 66@  66

$rcmd = $env:quiz +"r004atp 66000000 66ZZZ999"
Invoke-Expression $rcmd > r004_portal.log
$rcmd = $env:quiz +"r004btp_portal"
Invoke-Expression $rcmd >> r004_portal.log

Move-Item -Force r004btp_portal.txt r004c_portal_66.txt


Set-Location $env:application_production\71
&$env:cmd\r004_portal 71@  71

$rcmd = $env:quiz +"r004atp 71000000 71ZZZ999"
Invoke-Expression $rcmd > r004_portal.log
$rcmd = $env:quiz +"r004btp_portal"
Invoke-Expression $rcmd >> r004_portal.log

Move-Item -Force r004btp_portal.txt r004c_portal_71.txt


Set-Location $env:application_production\72
&$env:cmd\r004_portal 72@  72

$rcmd = $env:quiz +"r004atp 72000000 72ZZZ999"
Invoke-Expression $rcmd > r004_portal.log
$rcmd = $env:quiz +"r004btp_portal"
Invoke-Expression $rcmd >> r004_portal.log

Move-Item -Force r004btp_portal.txt r004c_portal_72.txt


Set-Location $env:application_production\73
&$env:cmd\r004_portal 73@  73

$rcmd = $env:quiz +"r004atp 73000000 73ZZZ999"
Invoke-Expression $rcmd > r004_portal.log
$rcmd = $env:quiz +"r004btp_portal"
Invoke-Expression $rcmd >> r004_portal.log

Move-Item -Force r004btp_portal.txt r004c_portal_73.txt


Set-Location $env:application_production\74
&$env:cmd\r004_portal 74@  74

$rcmd = $env:quiz +"r004atp 74000000 74ZZZ999"
Invoke-Expression $rcmd > r004_portal.log
$rcmd = $env:quiz +"r004btp_portal"
Invoke-Expression $rcmd >> r004_portal.log

Move-Item -Force r004btp_portal.txt r004c_portal_74.txt


Set-Location $env:application_production\75
&$env:cmd\r004_portal 75@  75

$rcmd = $env:quiz +"r004atp 75000000 75ZZZ999"
Invoke-Expression $rcmd > r004_portal.log
$rcmd = $env:quiz +"r004btp_portal"
Invoke-Expression $rcmd >> r004_portal.log

Move-Item -Force r004btp_portal.txt r004c_portal_75.txt


Set-Location $env:application_production\82
&$env:cmd\r004_portal 82@  82

#cd $application_production/83
#$cmd/r004_portal 83@  83

Set-Location $env:application_production\86
&$env:cmd\r004_portal 86@  86

Get-Date
echo"Done!"
