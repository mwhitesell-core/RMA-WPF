#-------------------------------------------------------------------------------
# File 'run_monthend_ar_81.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'run_monthend_ar_81'
#-------------------------------------------------------------------------------

echo ""
echo ""
echo ""
echo "CONTRACT 81"
echo ""
echo "RUN MONTHEND REPORTS AND ACCOUNTS RECEIVABLE"
echo ""
echo "HIT `"NEWLINE`" TO CONTINUE ..."
$garbage = Read-Host
echo ""

Set-Location $application_production\81

$pipedInput = @"
81
Y
"@

$pipedInput | cobrun++ $obj\r004a

cobrun++ $obj\r004b

$pipedInput = @"
Y
"@

$pipedInput | cobrun++ $obj\r004c

Get-Contents r004| Out-Printer

$pipedInput = @"
81
Y
"@

$pipedInput | cobrun++ $obj\r005

#lp r005

$pipedInput = @"
81
Y
"@

$pipedInput | cobrun++ $obj\r011

#lp r011

$pipedInput = @"
81
Y
"@

$pipedInput | cobrun++ $obj\r012

#lp r012

$pipedInput = @"
81
Y
"@

$pipedInput | cobrun++ $obj\r013

#lp r013

$pipedInput = @"
81
Y
"@

$pipedInput | cobrun++ $obj\r051a

cobrun++ $obj\r051b
cobrun++ $obj\r051c

Get-Contents r051ca| Out-Printer

cobrun++ $obj\r051b
cobrun++ $obj\r051c

#lp r051cb

$pipedInput = @"
81
Y
Y
"@

$pipedInput | cobrun++ $obj\r070a

cobrun++ $obj\r070b

$pipedInput = @"
N
"@

$pipedInput | cobrun++ $obj\r070c

#lp r070_81
