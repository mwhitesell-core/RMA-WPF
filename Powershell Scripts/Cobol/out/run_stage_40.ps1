#-------------------------------------------------------------------------------
# File 'run_stage_40.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'run_stage_40'
#-------------------------------------------------------------------------------

echo " --- r004a (COBOL) --- "
$pipedInput = @"
22
Y
"@

$pipedInput | cobrun++ $obj\r004a

echo " --- r004b (COBOL) --- "
cobrun++ $obj\r004b

echo " --- r004c (COBOL) --- "
$pipedInput = @"
Y
"@

$pipedInput | cobrun++ $obj\r004c

#lp r004

echo " --- r005 (COBOL) --- "
$pipedInput = @"
22
Y
"@

$pipedInput | cobrun++ $obj\r005

#lp r005

echo " --- r011 (COBOL) --- "
$pipedInput = @"
22
Y
"@

$pipedInput | cobrun++ $obj\r011

#lp r011

echo " --- r011mohr (QUIZ) --- "
$pipedInput = @"
22@
"@

$pipedInput | quiz++ $obj\r011mohr

#lp r011mohr.txt

echo " --- r012 (COBOL) --- "
$pipedInput = @"
22
Y
"@

$pipedInput | cobrun++ $obj\r012

#lp r012

echo " --- r013 (COBOL) --- "
$pipedInput = @"
22
Y
"@

$pipedInput | cobrun++ $obj\r013

#lp r013

echo " --- r051a (COBOL) --- "
$pipedInput = @"
22
Y
"@

$pipedInput | cobrun++ $obj\r051a

echo " --- r051b (COBOL) --- "
cobrun++ $obj\r051b
echo " --- r051c (COBOL) --- "
cobrun++ $obj\r051c

#lp r051ca

echo " --- r051b (COBOL) --- "
cobrun++ $obj\r051b
echo " --- r051c (COBOL) --- "
cobrun++ $obj\r051c

#lp r051cb

#echo NOW RUNNING $cmd/r004_ph_portal_22to48
#$cmd/r004_ph_portal_22to48
