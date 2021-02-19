#-------------------------------------------------------------------------------
# File 'u140_stage3.com_bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'u140_stage3.com_bk1'
#-------------------------------------------------------------------------------

#file:  u140_stage3.com
# 04/jun/01 b.e. - original

clear
echo "Running `'processing of AFP Conversion Payment file - Stage 3`'"
echo ""
echo "Entering `'upload`' directory"
Set-Location $application_upl ; Get-Location

$filename = "$1"
echo ""
echo "renaming $filename to afp_fixed_payments.dat ..."
Move-Item -Force $filename afp_fixed_payments.dat

echo "running u140.cbl ..."
&$env:COBOL u140

echo "recreating file tmp_alpha_doctor ..."
$pipedInput = @"
create file tmp-doctor-alpha
"@

$pipedInput | qutil++

echo "running u140_b $Env:root\ 140_c $Env:root\ u140_d ..."
&$env:QTP u140_b
&$env:QTP u140_c
&$env:QTP u140_d

echo "running r140 reports ..."
&$env:QUIZ r140_a1f
&$env:QUIZ r140_a2g
&$env:QUIZ r140_a2s
&$env:QUIZ r140_a3c
&$env:QUIZ r140_a4t

Get-ChildItem r140_a1f.txt, r140_a2g.txt, r140_a2s.txt, r140_a3c.txt, r140_a4t.txt, r140_a.txt
# these reports run after MP payroll so that all transaction can be included
#echo running r140_reports
#$cmd/r140_reports

echo ""
echo ""
echo "Confirm the above reports are correct and then complete this process"
echo "by runningu140_stage4"
echo ""

echo "renaming processed file as: $filename.done"
Move-Item -Force afp_fixed_payments.dat $filename.done

echo ""
echo "Setup of MP environment"
. $Env:root\macros\setup_rmabill.com  mp

echo ""
echo "Entering `'upload`' directory"
Set-Location $application_upl ; Get-Location

echo "Running MP stage3.com"
&$env:cmd\u140_stage3_mp.com

echo ""
echo ""
echo "Return to 101c environment"
. $Env:root\macros\setup_rmabill.com  101c

echo ""
echo "Entering `'upload`' directory"
Set-Location $application_upl ; Get-Location

#run reports
&$env:cmd\r140_reports

echo "Entering `'upload`' directory"
Set-Location $application_upl ; Get-Location

echo "Done!"
