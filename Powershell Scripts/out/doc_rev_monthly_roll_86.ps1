#-------------------------------------------------------------------------------
# File 'doc_rev_monthly_roll_86.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'doc_rev_monthly_roll_86'
#-------------------------------------------------------------------------------

echo "DOC_REV_MONTHLY_ROLL_86"
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
#read garbage
echo ""
echo "PROGRAM `"U014`" NOW LOADING ..."
echo ""
$rcmd = $env:QTP +"u014_f050 86"
Invoke-Expression $rcmd *> u014_f050_86.log

echo "PROGRAM `"U015`" NOW LOADING ..."
echo ""
$rcmd = $env:QTP +"u015 86 86 86 86"
Invoke-Expression $rcmd *> u015_86.log


#echo 
#echo  'TO FINISH THIS RUN  HIT "NEWLINE"'
#read garbage
