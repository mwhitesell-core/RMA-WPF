#-------------------------------------------------------------------------------
# File 'doc_rev_monthly_roll_22.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
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
$rcmd = $env:QTP +"u014_f050 22"
Invoke-Expression $rcmd | Tee-Object -FilePath "u014_f050_22.log"

echo "PROGRAM `"u015`" NOW LOADING ..."
echo ""
$rcmd = $env:QTP +"u015 22 22 22 22"
Invoke-Expression $rcmd *> u015_22.log

echo ""
