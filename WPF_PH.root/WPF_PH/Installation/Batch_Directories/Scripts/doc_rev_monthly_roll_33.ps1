#-------------------------------------------------------------------------------
# File 'doc_rev_monthly_roll_33.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'doc_rev_monthly_roll_33'
#-------------------------------------------------------------------------------

echo "DOC_REV_MONTHLY_ROLL_33"
echo ""

echo "MONTHLY ROLLOVER OF DOCTOR REVENUE MASTER"
echo ""
echo "WARNING  DOCTOR REVENUE FILE WILL BE UPDATED BY THIS RUN --"
echo "A BACKUP OF THE FILE WILL NOW BE RUN"

echo ""
echo ""

echo ""
echo "MONTHLY ROLL OVER WILL NOW BE RUN --"
echo ""
echo "PROGRAM `"U014`" NOW LOADING ..."
echo ""
$rcmd = $env:QTP +"u014_f050 33"
Invoke-Expression $rcmd | Tee-Object -FilePath "u014_f050_33.log"

echo "PROGRAM `"U015`" NOW LOADING ..."
echo ""
$rcmd = $env:QTP +"u015 33 33 33 33"
Invoke-Expression $rcmd *> u015_33.log

echo ""
