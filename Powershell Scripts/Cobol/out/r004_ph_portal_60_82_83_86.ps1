#-------------------------------------------------------------------------------
# File 'r004_ph_portal_60_82_83_86.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'r004_ph_portal_60_82_83_86'
#-------------------------------------------------------------------------------

echo " --- r004c_portal (PH) --- "

Set-Location $application_production\61
$cmd\r004_portal 61@  61

$pipedInput = @"
exec $obj/r004atp nogo
choose batctrl-batch-nbr '61000000' to '61ZZZ999'
go
exec $obj/r004btp_portal
"@

$pipedInput | quiz++  > r004_portal.log

Move-Item r004btp_portal.txt r004c_portal_61.txt


Set-Location $application_production\62
$cmd\r004_portal 62@  62

$pipedInput = @"
exec $obj/r004atp nogo
choose batctrl-batch-nbr '62000000' to '62ZZZ999'
go
exec $obj/r004btp_portal
"@

$pipedInput | quiz++  > r004_portal.log

Move-Item r004btp_portal.txt r004c_portal_62.txt


Set-Location $application_production\63
$cmd\r004_portal 63@  63

$pipedInput = @"
exec $obj/r004atp nogo
choose batctrl-batch-nbr '63000000' to '63ZZZ999'
go
exec $obj/r004btp_portal
"@

$pipedInput | quiz++  > r004_portal.log

Move-Item r004btp_portal.txt r004c_portal_63.txt


Set-Location $application_production\64
$cmd\r004_portal 64@  64

$pipedInput = @"
exec $obj/r004atp nogo
choose batctrl-batch-nbr '64000000' to '64ZZZ999'
go
exec $obj/r004btp_portal
"@

$pipedInput | quiz++  > r004_portal.log

Move-Item r004btp_portal.txt r004c_portal_64.txt


Set-Location $application_production\65
$cmd\r004_portal 65@  65

$pipedInput = @"
exec $obj/r004atp nogo
choose batctrl-batch-nbr '65000000' to '65ZZZ999'
go
exec $obj/r004btp_portal
"@

$pipedInput | quiz++  > r004_portal.log


Move-Item r004btp_portal.txt r004c_portal_65.txt


Set-Location $application_production\66
$cmd\r004_portal 66@  66

$pipedInput = @"
exec $obj/r004atp nogo
choose batctrl-batch-nbr '66000000' to '66ZZZ999'
go
exec $obj/r004btp_portal
"@

$pipedInput | quiz++  > r004_portal.log

Move-Item r004btp_portal.txt r004c_portal_66.txt


Set-Location $application_production\71
$cmd\r004_portal 71@  71

$pipedInput = @"
exec $obj/r004atp nogo
choose batctrl-batch-nbr '71000000' to '71ZZZ999'
go
exec $obj/r004btp_portal
"@

$pipedInput | quiz++  > r004_portal.log

Move-Item r004btp_portal.txt r004c_portal_71.txt


Set-Location $application_production\72
$cmd\r004_portal 72@  72

$pipedInput = @"
exec $obj/r004atp nogo
choose batctrl-batch-nbr '72000000' to '72ZZZ999'
go
exec $obj/r004btp_portal
"@

$pipedInput | quiz++  > r004_portal.log

Move-Item r004btp_portal.txt r004c_portal_72.txt


Set-Location $application_production\73
$cmd\r004_portal 73@  73

$pipedInput = @"
exec $obj/r004atp nogo
choose batctrl-batch-nbr '73000000' to '73ZZZ999'
go
exec $obj/r004btp_portal
"@

$pipedInput | quiz++  > r004_portal.log

Move-Item r004btp_portal.txt r004c_portal_73.txt


Set-Location $application_production\74
$cmd\r004_portal 74@  74

$pipedInput = @"
exec $obj/r004atp nogo
choose batctrl-batch-nbr '74000000' to '74ZZZ999'
go
exec $obj/r004btp_portal
"@

$pipedInput | quiz++  > r004_portal.log

Move-Item r004btp_portal.txt r004c_portal_74.txt


Set-Location $application_production\75
$cmd\r004_portal 75@  75

$pipedInput = @"
exec $obj/r004atp nogo
choose batctrl-batch-nbr '75000000' to '75ZZZ999'
go
exec $obj/r004btp_portal
"@

$pipedInput | quiz++  > r004_portal.log

Move-Item r004btp_portal.txt r004c_portal_75.txt


Set-Location $application_production\82
$cmd\r004_portal 82@  82

#cd $application_production/83
#$cmd/r004_portal 83@  83

Set-Location $application_production\86
$cmd\r004_portal 86@  86

Get-Date
echo "Done!"
