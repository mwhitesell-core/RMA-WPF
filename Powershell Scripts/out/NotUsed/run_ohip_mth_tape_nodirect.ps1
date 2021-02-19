#-------------------------------------------------------------------------------
# File 'run_ohip_mth_tape_nodirect.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_ohip_mth_tape_nodirect'
#-------------------------------------------------------------------------------

#  ** IF YOU CHANGE THIS MACRO MODIFY FOLLOWING ALSO **
#     run_ohip_submit_tape
#     run_ohip_tape_no_directs
#     run_ohip_monthend_tape


&$env:cmd\u010_daily  ${1}

Remove-Item ru020*, u020_tapeout_file*, u020_tp.sf*, u020*sf* *> $null

echo " --- u020a.qtc --- "
&$env:QTP u020a

if ((Test-Path u020a1_a.sf) -and ((Get-Item u020a1_a.sf ).Length -gt 0 ))
{
Move-Item -Force u020a1_a.sf u020a1.sf
Move-Item -Force u020a1_a.sfd u020a1.sfd

&$env:cmd\u020

Move-Item -Force u020_tp.sf u020_tapeout_file_a *> $null
Remove-Item u020_tp.sfd *> $null
Move-Item -Force ru020a.txt ru020a_a *> $null
Move-Item -Force ru020b.txt ru020b_a *> $null
Move-Item -Force ru020c.txt ru020c_a *> $null
Move-Item -Force ru020mr.txt ru020mr_a *> $null
Move-Item -Force u020a1.sf u020a1_a.sf *> $null
Move-Item -Force u020a1.sfd u020a1_a.sfd *> $null

}

if ((Test-Path u020a1_b.sf) -and ((Get-Item u020a1_b.sf ).Length -gt 0 ))
 {

Move-Item -Force u020a1_b.sf u020a1.sf
Move-Item -Force u020a1_b.sfd u020a1.sfd

&$env:cmd\u020

Move-Item -Force u020_tp.sf u020_tapeout_file_b *> $null
Remove-Item u020_tp.sfd *> $null
Move-Item -Force ru020a.txt ru020a_b *> $null
Move-Item -Force ru020b.txt ru020b_b *> $null
Move-Item -Force ru020c.txt ru020c_b *> $null
Move-Item -Force ru020mr.txt ru020mr_b *> $null
Move-Item -Force u020a1.sf u020a1_b.sf *> $null
Move-Item -Force u020a1.sfd u020a1_b.sfd *> $null

}

if ((Test-Path u020a1_c.sf) -and ((Get-Item u020a1_c.sf ).Length -gt 0 ))
 {

Move-Item -Force u020a1_c.sf u020a1.sf
Move-Item -Force u020a1_c.sfd u020a1.sfd

&$env:cmd\u020

Move-Item -Force u020_tp.sf u020_tapeout_file_c *> $null
Remove-Item u020_tp.sfd *> $null
Move-Item -Force ru020a.txt ru020a_c *> $null
Move-Item -Force ru020b.txt ru020b_c *> $null
Move-Item -Force ru020c.txt ru020c_c *> $null
Move-Item -Force ru020mr.txt ru020mr_c *> $null
Move-Item -Force u020a1.sf u020a1_c.sf *> $null
Move-Item -Force u020a1.sfd u020a1_c.sfd *> $null

}

if ((Test-Path u020a1_d.sf) -and ((Get-Item u020a1_d.sf ).Length -gt 0 ))
 {

Move-Item -Force u020a1_d.sf u020a1.sf
Move-Item -Force u020a1_d.sfd u020a1.sfd

&$env:cmd\u020

Move-Item -Force u020_tp.sf u020_tapeout_file_d *> $null
Remove-Item u020_tp.sfd *> $null
Move-Item -Force ru020a.txt ru020a_d *> $null
Move-Item -Force ru020b.txt ru020b_d *> $null
Move-Item -Force ru020c.txt ru020c_d *> $null
Move-Item -Force ru020mr.txt ru020mr_d *> $null
Move-Item -Force u020a1.sf u020a1_d.sf *> $null
Move-Item -Force u020a1.sfd u020a1_d.sfd *> $null

}

Get-Content run020a_b, run020a_c, run020a_d | Add-Content run020a_a
Move-Item -Force ru020a_a ru020a *> $null

Get-Content run020b_b, run020b_c, run020b_d | Add-Content run020b_a
Move-Item -Force ru020b_a ru020b *> $null

Get-Content run020c_b, run020c_c, run020c_d | Add-Content run020c_a
Move-Item -Force ru020c_a ru020c *> $null

Get-Content run020mr_b, run020mr_c, run020mr_d | Add-Content run020mr_a
Move-Item -Force ru020mr_a ru020mr *> $null

Get-Content u020_tapeout_file_b, u020_tapeout_file_c, u020_tapeout_file_d | Add-Content u020_tapeout_file_a
Get-Content u020_tapeout_tp.sf, sd_u022.sf | Add-Content u020_tapeout_file_a
Copy-Item u020_tapeout_file_a u022_tp.sf
Copy-Item u020_tapeout_file_a sd_u022.sf
Move-Item -Force u020_tapeout_file_a u020_tapeout_file *> $null

Get-Content ru020b | Out-Printer
#lp ru020c

#  $cmd/backup_ohip_tape

echo "U010 IN PROGRESS $(Get-Date -uformat `"%T`")"

&$env:cmd\r010

# $cmd/backup_after_ohiptape

Get-Content ohiptape.ls | Out-Printer
