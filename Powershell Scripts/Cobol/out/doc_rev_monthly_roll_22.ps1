#-------------------------------------------------------------------------------
# File 'doc_rev_monthly_roll_22.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'doc_rev_monthly_roll_22'
#-------------------------------------------------------------------------------

echo "DOC_REV_MONTHLY_ROLL_22"
echo ""

echo "MONTHLY ROLLOVER OF DOCTOR REVENUE MASTER"
echo ""
echo "WARNING  DOCTOR REVENUE FILE WILL BE UPDATED BY THIS RUN --"
echo "A BACKUP OF THE FILE WILL NOW BE RUN"

echo ""
echo "HIT   `"NEWLINE`"   TO COMMENCE BACKUP ..."
$garbage = Read-Host
echo ""

echo ""
echo ""
echo "PROGRAM `"u014_f050`" NOW LOADING ..."
echo ""
$pipedInput = @"
22
"@

$pipedInput | qtp++ $obj\u014_f050

echo "PROGRAM `"u015`" NOW LOADING ..."
echo ""
$pipedInput = @"
22@
22@
22@
22@
"@

$pipedInput | qtp++ $obj\u015  > u015_22.log  2>&1

echo ""
