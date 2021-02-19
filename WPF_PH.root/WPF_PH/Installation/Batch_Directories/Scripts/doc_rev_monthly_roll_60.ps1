#-------------------------------------------------------------------------------
# File 'doc_rev_monthly_roll_60.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'doc_rev_monthly_roll_60'
#-------------------------------------------------------------------------------

echo "DOC_REV_MONTHLY_ROLL_60"
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
$rcmd = $env:QTP +"u014_f050 60"
Invoke-Expression $rcmd *> u014_f050_60.log

echo ""
echo "PROGRAM `"u014_f050tp`" NOW LOADING ..."
echo ""
$rcmd = $env:QTP +"u014_f050tp 60"
Invoke-Expression $rcmd *> u014_f050tp_60.log

echo "PROGRAM `"u015`" NOW LOADING ..."
echo ""
$rcmd = $env:QTP +"u015 61 66 61 66"
Invoke-Expression $rcmd *> u015_60.log

echo ""
echo "PROGRAM `"u015tp`" NOW LOADING ..."
echo ""
$rcmd = $env:QTP +"u015tp 61 66 61 66"
Invoke-Expression $rcmd *> u015tp_60.log

echo ""
