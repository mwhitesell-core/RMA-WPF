#-------------------------------------------------------------------------------
# File 'run_ohip_submit_tape_no_directs.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'run_ohip_submit_tape_no_directs'
#-------------------------------------------------------------------------------

# run_ohip_submit_tape_no_directs

# 98/Jun/29 B.E. - added 2>/dev/null to #lp statements
# 99/feb/08 B.E. - added logic to create 2nd ohip tape file in y2k V03  format
# 99/feb/12 B.E. - change call to quiz for r085/6/7 pgms 
# 99/feb/22 B.E. - fixed problem with file naming of y2k file
# 99/may/18 B.E. - changed so that y2k version of code is 'normal' file
# 00/jun/29 B.E. - removed hard coding and called 'elig_letters_corrections_resubmits'
# 04/feb/23 M.C. - rename 'elig_letters_corrections_resubmits' to
#                         'elig_corrections_letters_resubmits'
#
# 07/apr/09 yas  - add new contract e 
# 11/jan/12 M.C. - transfer the call of $cmd/letter_eligibility_info_wrong from
#                  $cmd/elig_corrections_letters_resubmit to be run after u020
# 11/jan/26 M.C. - add the new program u020d.qtc  
# 11/May/31 MC1  - qutil tmp-counters-alpha before u022 & u020 run

echo "Runningrun_ohip_submit_tape_no_directs ..."
echo ""
Get-Date
echo ""

$cmd\u010_daily ${1}


# 2011/05/31  - MC1

$pipedInput = @"
create file tmp-counters-alpha
"@

$pipedInput | qutil++



##$cmd/elig_letters_corrections_resubmits
$cmd\elig_corrections_letters_resubmits


Remove-Item ru020*, u020_tapeout_file*, u020_tp.sf*, u020*sf*

echo "--- u020a (QTP RUN) ---"
qtp++ $obj\u020a

echo "Processing u020a1_a ..."
if ((Test-Path u020a1_a.sf) -and ((Get-Item u020a1_a.sf).Length -gt 0))
{

  Move-Item u020a1_a.sf u020a1.sf
  Move-Item u020a1_a.sfd u020a1.sfd

    $cmd\u020

  Move-Item u020_tp.sf u020_tapeout_file_a
  Remove-Item u020_tp.sfd

  Move-Item ru020a.txt ru020a_a
  Move-Item ru020b_d.txt ru020b_d_a
  Move-Item ru020b_s.txt ru020b_s_a
  Move-Item ru020c.txt ru020c_a
  Move-Item ru020mr.txt ru020mr_a
  Move-Item u020a1.sf u020a1_a.sf
  Move-Item u020a1.sfd u020a1_a.sfd
}


echo "Processing u020a1_b ..."
if ((Test-Path u020a1_b.sf) -and ((Get-Item u020a1_b.sf).Length -gt 0))
{

  Move-Item u020a1_b.sf u020a1.sf
  Move-Item u020a1_b.sfd u020a1.sfd

    $cmd\u020

  Move-Item u020_tp.sf u020_tapeout_file_b
  Remove-Item u020_tp.sfd

  Move-Item ru020a.txt ru020a_b
  Move-Item ru020b_d.txt ru020b_d_b
  Move-Item ru020b_s.txt ru020b_s_b
  Move-Item ru020c.txt ru020c_b
  Move-Item ru020mr.txt ru020mr_b
  Move-Item u020a1.sf u020a1_b.sf
  Move-Item u020a1.sfd u020a1_b.sfd
}

echo "Processing u020a1_c ..."
if ((Test-Path u020a1_c.sf) -and ((Get-Item u020a1_c.sf).Length -gt 0))
{

  Move-Item u020a1_c.sf u020a1.sf
  Move-Item u020a1_c.sfd u020a1.sfd

    $cmd\u020

  Move-Item u020_tp.sf u020_tapeout_file_c
  Remove-Item u020_tp.sfd

  Move-Item ru020a.txt ru020a_c
  Move-Item ru020b_d.txt ru020b_d_c
  Move-Item ru020b_s.txt ru020b_s_c
  Move-Item ru020c.txt ru020c_c
  Move-Item ru020mr.txt ru020mr_c
  Move-Item u020a1.sf u020a1_c.sf
  Move-Item u020a1.sfd u020a1_c.sfd
}


echo "Processing u020a1_d ..."
if ((Test-Path u020a1_d.sf) -and ((Get-Item u020a1_d.sf).Length -gt 0))
{

  Move-Item u020a1_d.sf u020a1.sf
  Move-Item u020a1_d.sfd u020a1.sfd

    $cmd\u020

  Move-Item u020_tp.sf u020_tapeout_file_d
  Remove-Item u020_tp.sfd

  Move-Item ru020a.txt ru020a_d
  Move-Item ru020b_d.txt ru020b_d_d
  Move-Item ru020b_s.txt ru020b_s_d
  Move-Item ru020c.txt ru020c_d
  Move-Item ru020mr.txt ru020mr_d
  Move-Item u020a1.sf u020a1_d.sf
  Move-Item u020a1.sfd u020a1_d.sfd
}

echo "Processing u020a1_e ..."
if ((Test-Path u020a1_e.sf) -and ((Get-Item u020a1_e.sf).Length -gt 0))
{

  Move-Item u020a1_e.sf u020a1.sf
  Move-Item u020a1_e.sfd u020a1.sfd

    $cmd\u020

  Move-Item u020_tp.sf u020_tapeout_file_e
  Remove-Item u020_tp.sfd

  Move-Item ru020a.txt ru020a_e
  Move-Item ru020b_d.txt ru020b_d_e
  Move-Item ru020b_s.txt ru020b_s_e
  Move-Item ru020c.txt ru020c_e
  Move-Item ru020mr.txt ru020mr_e
  Move-Item u020a1.sf u020a1_e.sf
  Move-Item u020a1.sfd u020a1_e.sfd
}

echo ""
echo ""
echo ""
Get-Content ru020a_a  > ru020a
Get-Content ru020a_b  >> ru020a
Get-Content ru020a_c  >> ru020a
Get-Content ru020a_d  >> ru020a
Get-Content ru020a_e  >> ru020a

Get-Content ru020b_d_a  > ru020b
Get-Content ru020b_s_a  >> ru020b
Get-Content ru020b_d_b  >> ru020b
Get-Content ru020b_s_b  >> ru020b
Get-Content ru020b_d_c  >> ru020b
Get-Content ru020b_s_c  >> ru020b
Get-Content ru020b_d_d  >> ru020b
Get-Content ru020b_s_d  >> ru020b
Get-Content ru020b_d_e  >> ru020b
Get-Content ru020b_s_e  >> ru020b

Get-Content ru020c_a  > ru020c
Get-Content ru020c_b  >> ru020c
Get-Content ru020c_c  >> ru020c
Get-Content ru020c_d  >> ru020c
Get-Content ru020c_e  >> ru020c

Get-Content ru020mr_a  > ru020mr
Get-Content ru020mr_b  >> ru020mr
Get-Content ru020mr_c  >> ru020mr
Get-Content ru020mr_d  >> ru020mr
Get-Content ru020mr_e  >> ru020mr

Get-Content u020_tapeout_file_a  > u020_tapeout_file
Get-Content u020_tapeout_file_b  >> u020_tapeout_file
Get-Content u020_tapeout_file_c  >> u020_tapeout_file
Get-Content u020_tapeout_file_d  >> u020_tapeout_file
Get-Content u020_tapeout_file_e  >> u020_tapeout_file
Get-Content u022_tp.sf  >> u020_tapeout_file
Get-Content sd_u022.sf  >> u020_tapeout_file

#lp ru020b 2>/dev/null
#lp ru020c 2>/dev/null

# 2011/Jan/26
echo "--- u020d (QTP RUN) ---"
qtp++ $obj\u020d

# 2011/01/12 - generate r086.txt & r087.txt
$cmd\letters_eligibility_info_wrong

# backup_ohip_tape

echo "R010 IN PROGRESS$(udate)"

$cmd\r010

echo ""
echo ""
Get-Date
echo ""
echo ""

#lp ohiptape.ls

echo "Donerun_ohip_submit_tape_no_directs"
