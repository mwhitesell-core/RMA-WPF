#-------------------------------------------------------------------------------
# File 'run_y2k.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_y2k'
#-------------------------------------------------------------------------------

# run_y2k
#

echo "Processing u020a1_a ..."
if ((Test-Path u020a1_a.sf) -and ((Get-Item u020a1_a.sf ).Length -gt 0 ))
{

  Move-Item -Force u020a1_a.sf u020a1.sf
  Move-Item -Force u020a1_a.sfd u020a1.sfd
&$env:QTP u020b
  Move-Item -Force u020a1.sf u020a1_a.sf
  Move-Item -Force u020a1.sfd u020a1_a.sfd
  Move-Item -Force u020_tp_y2k.sf u020_tapeout_file_a_y2k
  Remove-Item u020_tp_y2k.sfd

}


echo "Processing u020a1_b ..."
if ((Test-Path u020a1_b.sf) -and ((Get-Item u020a1_b.sf ).Length -gt 0 ))
{

  Move-Item -Force u020a1_b.sf u020a1.sf
  Move-Item -Force u020a1_b.sfd u020a1.sfd
&$env:QTP u020b
  Move-Item -Force u020a1.sf u020a1_b.sf
  Move-Item -Force u020a1.sfd u020a1_b.sfd
  Move-Item -Force u020_tp_y2k.sf u020_tapeout_file_b_y2k
  Remove-Item u020_tp_y2k.sfd

}

echo "Processing u020a1_c ..."
if ((Test-Path u020a1_c.sf) -and ((Get-Item u020a1_c.sf ).Length -gt 0 ))
{

  Move-Item -Force u020a1_c.sf u020a1.sf
  Move-Item -Force u020a1_c.sfd u020a1.sfd
&$env:QTP u020b
  Move-Item -Force u020a1.sf u020a1_c.sf
  Move-Item -Force u020a1.sfd u020a1_c.sfd
  Move-Item -Force u020_tp_y2k.sf u020_tapeout_file_c_y2k
  Remove-Item u020_tp_y2k.sfd

}


echo "Processing u020a1_d ..."
if ((Test-Path u020a1_d.sf) -and ((Get-Item u020a1_d.sf ).Length -gt 0 ))
{

  Move-Item -Force u020a1_d.sf u020a1.sf
  Move-Item -Force u020a1_d.sfd u020a1.sfd
&$env:QTP u020b
  Move-Item -Force u020a1.sf u020a1_d.sf
  Move-Item -Force u020a1.sfd u020a1_d.sfd
  Move-Item -Force u020_tp_y2k.sf u020_tapeout_file_d_y2k
  Remove-Item u020_tp_y2k.sfd

}

Copy-Item u020_tapeout_file_a_y2k u020_tapeout_file_y2k
Get-Content u020_tapeout_file_b_y2k | Add-Content u020_tapeout_file_y2k
Get-Content u020_tapeout_file_c_y2k | Add-Content u020_tapeout_file_y2k
Get-Content u020_tapeout_file_d_y2k | Add-Content u020_tapeout_file_y2k

Move-Item -Force u020_tapeout_file_y2k u020_tapeout_file
&$env:cmd\dump_ohip_submit_tape
Move-Item -Force u020_tapeout_file u020_tapeout_file_y2k
