#-------------------------------------------------------------------------------
# File 'u140_stage3.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'u140_stage3.com'
#-------------------------------------------------------------------------------

#file:  u140_stage3.com
# 04/jun/01 b.e. - original
# 08/aug/10 M.C. - substitute MP with Solotest
# 08/sep/08 b.e. - running of u140.cbl moved from this macro to u140_stage1.com
# 09/jun/16 M.C. - include r140_a_summ.txt

clear
echo "Running `'processing of AFP Conversion Payment file - Stage 3`'"
echo ""
echo "Entering `'upload`' directory"
Set-Location $application_upl; Get-Location

#filename=$1
#echo 
#echo renaming $filename to afp_fixed_payments.dat ... 
#mv $filename afp_fixed_payments.dat
#
#echo running u140.cbl ...
#cobrun $obj/u140

echo "recreating file tmp_alpha_doctor ..."
$pipedInput = @"
create file tmp-doctor-alpha
"@

$pipedInput | qutil++

echo "running u140_b $root\ 140_c $root\ u140_d ..."
qtp++ $obj\u140_b " determine percentage RA payments "
qtp++ $obj\u140_c " update f075 with a1f payment amt      "
#clear subfile before running so that values can accumulate between 101c and solo
#if  [ $RMABILL_VERSION = 101c ]
#then
# echo removing u140_d1 and _d1a subfiles
  Remove-Item u140_d1.sf*
#else
# echo bypassing the removal of u140_d1 subfile
#fi
qtp++ $obj\u140_d " divy up AFP payment based upon RA percentage"

echo "running r140 reports ..."
echo "Running .. report group total amount"
echo "Running .. group conversion detail report"
echo "Running .. solo conversion detail report"
echo "Running .. total Conversion payment report"
echo "Running .. governance Total payment report"
$pipedInput = @"
exec $obj/r140_a1f.qzc
exec $obj/r140_a2g.qzc
exec $obj/r140_a2s.qzc
exec $obj/r140_a3c.qzc
exec $obj/r140_a4t.qzc
"@

$pipedInput | quiz++


#echo renaming processed file as: $filename.done
#mv afp_fixed_payments.dat $filename.done

echo ""
echo "Setup of Solotest environment"
. $root\macros\setup_rmabill.com solo

echo ""
echo "Entering `'upload`' directory"
Set-Location $application_upl; Get-Location

echo "recreating file tmp_alpha_doctor ..."
$pipedInput = @"
create file tmp-doctor-alpha
"@

$pipedInput | qutil++

echo "Running stage3 in solo"
#$cmd/u140_stage3_mp.com
qtp++ $obj\u140_b " determine percentage RA payments "
qtp++ $obj\u140_c " update f075 with a1f payment amt      "
qtp++ $obj\u140_d " divy up AFP payment based upon RA percentage"


echo ""
echo ""
echo "Return to 101c environment"
. $root\macros\setup_rmabill.com 101c

echo ""
echo "Entering `'upload`' directory"
Set-Location $application_upl; Get-Location

echo "add Report only group entries to subfile"
quiz++ $obj\u140_k

echo "removing duplicates from u140_d1 subfile"
qtp++ $obj\u140_d1_remove_dups
Move-Item u140_d1.sf u140_d1_with_dups.sf
Move-Item u140_d1.sfd u140_d1_with_dups.sfd

Move-Item u140_d2.sf u140_d1.sf
Move-Item u140_d2.sfd u140_d1.sfd

echo "ensure that all docs in u140_d1 are also in f075"
echo "running u140_f.qtc"
qtp++ $obj\u140_f

echo "run reports"
# run reports
$cmd\r140_reports

echo "Entering `'upload`' directory"
Set-Location $application_upl; Get-Location

Get-ChildItem r140_a1f.txt, r140_a2g.txt, r140_a2s.txt, r140_a3c.txt, r140_a4t.txt, r140_a.txt, r140_a_summ.txt, r140_b.txt
echo ""
echo ""
echo "Confirm the above reports are correct and then complete this process"
echo "by runningu140_stage4"
echo ""
echo "Done!"
