#-------------------------------------------------------------------------------
# File 'u140_stage3_mp.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'u140_stage3_mp.com'
#-------------------------------------------------------------------------------

#file:  u140_stage3_mp.com
# 04/oct/16 b.e. - original

clear
echo "Running `'processing of AFP Conversion Payment file - Stage 3 - MANUAL PAY Payroll`'"
echo ""
echo "Entering `'upload`' directory"
Set-Location $application_upl ; Get-Location

echo "recreating file tmp_alpha_doctor ..."
$pipedInput = @"
create file tmp-doctor-alpha
"@

$pipedInput | qutil++

#echo running u140_b / u140_c / u140_d ...
echo "running special version of u140_d for mp only u140_d_mp"
#qtp  auto=$obj/u140_b.qtc
#qtp  auto=$obj/u140_c.qtc

&$env:QTP u140_d_mp

#echo running r140 reports ...
#quiz << QUIZ_EXIT
#exec $obj/r140_a1f.qzc
#exec $obj/r140_a2g.qzc
#exec $obj/r140_a2s.qzc
#exec $obj/r140_a3c.qzc
#exec $obj/r140_a4t.qzc
#
#QUIZ_EXIT

#ls -l r140_a1f.txt r140_a2g.txt r140_a2s.txt r140_a3c.txt r140_a4t.txt r140_a.txt
# these reports now run after MP payroll so that all transaction can be included
#echo running r140_reports
#$cmd/r140_reports

#echo
#echo
#echo Confirm the above reports are correct and then complete this process
#echo by running "u140_stage4"
#echo

echo "Done!"