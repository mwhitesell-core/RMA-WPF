#-------------------------------------------------------------------------------
# File 'run_ohip_submit_tape_no_directs.bkp.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_ohip_submit_tape_no_directs.bkp'
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
echo "Runningrun_ohip_submit_tape_no_directs ..."
echo ""
Get-Date
echo ""

&$env:cmd\u010_daily ${1}


##$cmd/elig_letters_corrections_resubmits
&$env:cmd\elig_corrections_letters_resubmits


Remove-Item ru020*, u020_tapeout_file*, u020_tp.sf*, u020*sf* 2> $null

echo "--- u020a (QTP RUN) ---"
&$env:QTP u020a

echo "Processing u020a1_a ..."
if ((Test-Path u020a1_a.sf) -and ((Get-Item u020a1_a.sf ).Length -gt 0 ))
{

  Move-Item -Force u020a1_a.sf u020a1.sf
  Move-Item -Force u020a1_a.sfd u020a1.sfd

    &$env:cmd\u020

  Move-Item -Force u020_tp.sf u020_tapeout_file_a
  Remove-Item u020_tp.sfd

  Move-Item -Force ru020a.txt ru020a_a
  Move-Item -Force ru020b_d.txt ru020b_d_a
  Move-Item -Force ru020b_s.txt ru020b_s_a
  Move-Item -Force ru020c.txt ru020c_a
  Move-Item -Force ru020mr.txt ru020mr_a
  Move-Item -Force u020a1.sf u020a1_a.sf
  Move-Item -Force u020a1.sfd u020a1_a.sfd
}


echo "Processing u020a1_b ..."
if ((Test-Path u020a1_b.sf) -and ((Get-Item u020a1_b.sf ).Length -gt 0 ))
{

  Move-Item -Force u020a1_b.sf u020a1.sf
  Move-Item -Force u020a1_b.sfd u020a1.sfd

    &$env:cmd\u020

  Move-Item -Force u020_tp.sf u020_tapeout_file_b
  Remove-Item u020_tp.sfd

  Move-Item -Force ru020a.txt ru020a_b
  Move-Item -Force ru020b_d.txt ru020b_d_b
  Move-Item -Force ru020b_s.txt ru020b_s_b
  Move-Item -Force ru020c.txt ru020c_b
  Move-Item -Force ru020mr.txt ru020mr_b
  Move-Item -Force u020a1.sf u020a1_b.sf
  Move-Item -Force u020a1.sfd u020a1_b.sfd
}

echo "Processing u020a1_c ..."
if ((Test-Path u020a1_c.sf) -and ((Get-Item u020a1_c.sf ).Length -gt 0 ))
{

  Move-Item -Force u020a1_c.sf u020a1.sf
  Move-Item -Force u020a1_c.sfd u020a1.sfd

    &$env:cmd\u020

  Move-Item -Force u020_tp.sf u020_tapeout_file_c
  Remove-Item u020_tp.sfd

  Move-Item -Force ru020a.txt ru020a_c
  Move-Item -Force ru020b_d.txt ru020b_d_c
  Move-Item -Force ru020b_s.txt ru020b_s_c
  Move-Item -Force ru020c.txt ru020c_c
  Move-Item -Force ru020mr.txt ru020mr_c
  Move-Item -Force u020a1.sf u020a1_c.sf
  Move-Item -Force u020a1.sfd u020a1_c.sfd
}


echo "Processing u020a1_d ..."
if ((Test-Path u020a1_d.sf) -and ((Get-Item u020a1_d.sf ).Length -gt 0 ))
{

  Move-Item -Force u020a1_d.sf u020a1.sf
  Move-Item -Force u020a1_d.sfd u020a1.sfd

    &$env:cmd\u020

  Move-Item -Force u020_tp.sf u020_tapeout_file_d
  Remove-Item u020_tp.sfd

  Move-Item -Force ru020a.txt ru020a_d
  Move-Item -Force ru020b_d.txt ru020b_d_d
  Move-Item -Force ru020b_s.txt ru020b_s_d
  Move-Item -Force ru020c.txt ru020c_d
  Move-Item -Force ru020mr.txt ru020mr_d
  Move-Item -Force u020a1.sf u020a1_d.sf
  Move-Item -Force u020a1.sfd u020a1_d.sfd
}


echo ""
echo ""
echo ""
Get-Content ru020a_a | Set-Content ru020a
Get-Content ru020a_b | Add-Content ru020a | Set-Content $null
Get-Content ru020a_c | Add-Content ru020a | Set-Content $null
Get-Content ru020a_d | Add-Content ru020a | Set-Content $null

Get-Content ru020b_d_a | Set-Content ru020b
Get-Content ru020b_s_a | Add-Content ru020b | Set-Content $null
Get-Content ru020b_d_b | Add-Content ru020b | Set-Content $null
Get-Content ru020b_s_b | Add-Content ru020b | Set-Content $null
Get-Content ru020b_d_c | Add-Content ru020b | Set-Content $null
Get-Content ru020b_s_c | Add-Content ru020b | Set-Content $null
Get-Content ru020b_d_d | Add-Content ru020b | Set-Content $null
Get-Content ru020b_s_d | Add-Content ru020b | Set-Content $null

Get-Content ru020c_a | Set-Content ru020c
Get-Content ru020c_b | Add-Content ru020c | Set-Content $null
Get-Content ru020c_c | Add-Content ru020c | Set-Content $null
Get-Content ru020c_d | Add-Content ru020c | Set-Content $null

Get-Content ru020mr_a | Set-Content ru020mr
Get-Content ru020mr_b | Add-Content ru020mr | Set-Content $null
Get-Content ru020mr_c | Add-Content ru020mr | Set-Content $null
Get-Content ru020mr_d | Add-Content ru020mr | Set-Content $null

Get-Content u020_tapeout_file_a | Set-Content u020_tapeout_file
Get-Content u020_tapeout_file_b | Add-Content u020_tapeout_file | Set-Content $null
Get-Content u020_tapeout_file_c | Add-Content u020_tapeout_file | Set-Content $null
Get-Content u020_tapeout_file_d | Add-Content u020_tapeout_file | Set-Content $null
Get-Content u022_tp.sf | Add-Content u020_tapeout_file | Set-Content $null
Get-Content sd_u022.sf | Add-Content u020_tapeout_file | Set-Content $null

Get-Content ru020b | Out-Printer 2> $null
#lp ru020c 2>/dev/null

# backup_ohip_tape

echo "R010 IN PROGRESS $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

&$env:cmd\r010


echo ""
echo "R U N    ** PRINT_LETTERS.CLI **   TO CREATE  PATIENT LETTERS"
echo ""
echo ""
Get-Date
echo ""


#lp ohiptape.ls

echo "Donerun_ohip_submit_tape_no_directs"
