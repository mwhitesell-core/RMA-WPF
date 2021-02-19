#-------------------------------------------------------------------------------
# File 'doc_rev_monthly_roll_81.bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'doc_rev_monthly_roll_81.bk1'
#-------------------------------------------------------------------------------

echo "DOC_REV_MONTHLY_ROLL_81"
echo ""

echo "MONTHLY ROLLOVER OF DOCTOR REVENUE MASTER"
echo ""
echo "WARNING  DOCTOR REVENUE FILE WILL BE UPDATED BY THIS RUN --"
echo "A BACKUP OF THE FILE WILL NOW BE RUN"

echo ""
echo "HIT   `"NEWLINE`"   TO COMMENCE BACKUP ..."
$garbage = Read-Host
echo ""

&$env:cmd\backup_f001_f050

echo ""
echo "MONTHLY ROLL OVER WILL NOW BE RUN --"
echo "HIT   `"NEWLINE`"   TO CONTINUE ..."
$garbage = Read-Host
echo ""
echo "PROGRAM `"U014`" NOW LOADING ..."
echo ""
&$env:QTP u014_f050 81

echo "PROGRAM `"U015`" NOW LOADING ..."
echo ""
&$env:COBOL u015 81 Y


echo ""
echo "TO FINISH THIS RUN  HIT  `"NEWLINE`" ..."
$garbage = Read-Host
