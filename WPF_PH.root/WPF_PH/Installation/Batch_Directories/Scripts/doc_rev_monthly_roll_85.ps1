#-------------------------------------------------------------------------------
# File 'doc_rev_monthly_roll_85.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'doc_rev_monthly_roll_85'
#-------------------------------------------------------------------------------

echo "DOC_REV_MONTHLY_ROLL_85"
echo ""

echo "MONTHLY ROLLOVER OF DOCTOR REVENUE MASTER"
echo ""
echo "WARNING  DOCTOR REVENUE FILE WILL BE UPDATED BY THIS RUN --"
echo "A BACKUP OF THE FILE WILL NOW BE RUN"

#echo 
#echo  'HIT  "NEWLINE" TO COMMENCE BACKUP ...'
#read garbage
#echo 

#$cmd/backup_f001_f050

echo ""
#echo  MONTHLY ROLL OVER WILL NOW BE RUN --
#echo  'HIT  "NEWLINE" TO CONTINUE ...'
$garbage = Read-Host
echo ""
echo "PROGRAM `"U014`" NOW LOADING ..."
echo ""
$rcmd = $env:QTP +"u014_f050 85"
Invoke-Expression $rcmd *> u014_f050_85.log

echo "PROGRAM `"U015`" NOW LOADING ..."
echo ""
$rcmd = $env:QTP +"u015 85 85 85 85"
Invoke-Expression $rcmd *> u015_85.log


echo ""
echo "TO FINISH THIS RUN  HIT  `"NEWLINE`""
$garbage = Read-Host
