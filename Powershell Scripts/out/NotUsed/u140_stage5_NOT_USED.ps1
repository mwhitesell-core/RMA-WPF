#-------------------------------------------------------------------------------
# File 'u140_stage5_NOT_USED.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'u140_stage5_NOT_USED'
#-------------------------------------------------------------------------------

#file:  u140_stage5
# 08/jun/23 b.e. - original

clear
echo "Running `'processing of AFP Conversion Payment file - Stage 5`'"
echo ""

echo ""
#echo  'HIT  "NEWLINE"  TO CONTINUE'
#read garbage
echo ""
echo "Process now loading ... when done the log file will be paged to your screen"

&$env:cmd\u140_stage5.com $1 > u140_stage5.log
Get-Content u140_stage5.log
