#-------------------------------------------------------------------------------
# File 'doc_rev_monthly_roll_70.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'doc_rev_monthly_roll_70'
#-------------------------------------------------------------------------------

echo "DOC_REV_MONTHLY_ROLL_70"
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
echo "PROGRAM `"u014_f050`" NOW LOADING ..."
echo ""
$rcmd = $env:QTP +"u014_f050 70"
Invoke-Expression $rcmd *> u014_f050_70.log

echo ""
echo "PROGRAM `"u014_f050tp`" NOW LOADING ..."
echo ""
$rcmd = $env:QTP +"u014_f050tp 70"
Invoke-Expression $rcmd *> u014_f050tp_70.log

echo "PROGRAM `"u015`" NOW LOADING ..."
echo ""
$rcmd = $env:QTP +"u015 71 75 71 75"
Invoke-Expression $rcmd *> u015_70.log

echo ""
echo "PROGRAM `"u015tp`" NOW LOADING ..."
echo ""
$rcmd = $env:QTP +"u015tp 71 75 71 75"
Invoke-Expression $rcmd *> u015tp_70.log



echo ""
