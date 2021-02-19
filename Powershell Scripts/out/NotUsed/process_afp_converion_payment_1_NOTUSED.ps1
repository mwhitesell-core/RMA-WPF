#-------------------------------------------------------------------------------
# File 'process_afp_converion_payment_1_NOTUSED.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'process_afp_converion_payment_1_NOTUSED'
#-------------------------------------------------------------------------------

#file:  u140_stage1
# 04/jun/01 b.e. - original

clear
echo "Running `'processing of AFP Conversion Payment file - Stage 1`'"
echo ""
echo ""
#echo  'HIT  "NEWLINE"  TO CONTINUE'
#read garbage
echo ""
echo "Process now loading ... when done the log file will be paged to your screen"

&$env:cmd\u140_stage1.com $1 > u140_stage1.log
echo ""
Get-Content u140_stage1.log
