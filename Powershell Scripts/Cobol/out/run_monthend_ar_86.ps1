#-------------------------------------------------------------------------------
# File 'run_monthend_ar_86.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'run_monthend_ar_86'
#-------------------------------------------------------------------------------

echo ""
echo ""
echo ""
echo "CONTRACT 86"
echo ""
echo "RUN MONTHEND REPORTS AND ACCOUNTS RECEIVABLE"
echo ""
echo ""

Set-Location $application_production\86

$pipedInput = @"
86
Y
"@

$pipedInput | cobrun++ $obj\r004a

cobrun++ $obj\r004b

$pipedInput = @"
Y
"@

$pipedInput | cobrun++ $obj\r004c

#lp r004

$pipedInput = @"
86
Y
"@

$pipedInput | cobrun++ $obj\r005

#lp r005

$pipedInput = @"
86
Y
"@

$pipedInput | cobrun++ $obj\r011

Get-Contents r011| Out-Printer

$pipedInput = @"
86
Y
"@

$pipedInput | cobrun++ $obj\r012

#lp r012

$pipedInput = @"
86
Y
"@

$pipedInput | cobrun++ $obj\r013

#lp r013

$pipedInput = @"
86
Y
"@

$pipedInput | cobrun++ $obj\r051a

cobrun++ $obj\r051b

cobrun++ $obj\r051c

#lp r051ca

cobrun++ $obj\r051b

cobrun++ $obj\r051c

Get-Contents r051cb| Out-Printer

$pipedInput = @"
86
Y
Y
"@

$pipedInput | cobrun++ $obj\r070a

cobrun++ $obj\r070b

$pipedInput = @"
N
"@

$pipedInput | cobrun++ $obj\r070c

#lp r070_86
