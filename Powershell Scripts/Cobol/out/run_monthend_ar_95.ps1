#-------------------------------------------------------------------------------
# File 'run_monthend_ar_95.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'run_monthend_ar_95'
#-------------------------------------------------------------------------------

echo ""
echo "CONTRACT 95"
echo ""
echo "RUN MONTHEND REPORTS AND ACCOUNTS RECEIVABLE"
echo ""
echo ""

Set-Location $application_production\95

$pipedInput = @"
95
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
95
Y
"@

$pipedInput | cobrun++ $obj\r005

#lp r005

$pipedInput = @"
95
Y
"@

$pipedInput | cobrun++ $obj\r011

#lp r011

$pipedInput = @"
95
Y
"@

$pipedInput | cobrun++ $obj\r012

#lp r012

$pipedInput = @"
95
Y
"@

$pipedInput | cobrun++ $obj\r013

#lp r013

$pipedInput = @"
95
Y
"@

$pipedInput | cobrun++ $obj\r051a

cobrun++ $obj\r051b

cobrun++ $obj\r051c

#lp r051ca

cobrun++ $obj\r051b

cobrun++ $obj\r051c

#lp r051cb

$pipedInput = @"
95
Y
Y
"@

$pipedInput | cobrun++ $obj\r070a

cobrun++ $obj\r070b

$pipedInput = @"
N
"@

$pipedInput | cobrun++ $obj\r070c

#lp r070_95
