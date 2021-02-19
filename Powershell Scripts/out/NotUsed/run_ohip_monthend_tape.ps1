#-------------------------------------------------------------------------------
# File 'run_ohip_monthend_tape.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_ohip_monthend_tape'
#-------------------------------------------------------------------------------

# ** IF YOU CHANGE THIS MACRO MODIFY THE FOLLOWING ALSO **
#    RUN_OHIP_SUBMIT_TAPE
#    RUN_OHIP_TAPE_NO_DIRECTS
#    RUN_OHIP_MTH_TAPE_NODIRECT

&$env:cmd\u010_daily ${1}

Set-Location $env:application_production
Remove-Item ru020*, u020_tapeout_file*, u020_tp.sf*, u020*sf*

echo " --- u020a.qtc --- "
&$env:QTP u020a

if ((Test-Path u020a1_a.sf) -and ((Get-Item u020a1_a.sf ).Length -gt 0 ))
{

Move-Item -Force u020a1_a.sf u020a1.sf
Move-Item -Force u020a1_a.sfd u020a1.sfd

&$env:cmd\u020

Move-Item -Force u020_tp.sf u020_tapeout_file_a
Remove-Item u020_tp.sfd
Move-Item -Force ru020a.txt ru020a_a
Move-Item -Force ru020b.txt ru020b_a
Move-Item -Force ru020c.txt ru020c_a
Move-Item -Force ru020mr.txt ru020mr_a
Move-Item -Force u020a1.sf u020a1_a.sf
Move-Item -Force u020a1.sfd u020a1_a.sfd

}


if ((Test-Path u020a1_b.sf) -and ((Get-Item u020a1_b.sf ).Length -gt 0 ))
{

Move-Item -Force u020a1_b.sf u020a1.sf
Move-Item -Force u020a1_b.sfd u020a1.sfd

&$env:cmd\u020

Move-Item -Force u020_tp.sf u020_tapeout_file_b
Remove-Item u020_tp.sfd
Move-Item -Force ru020a.txt ru020a_b
Move-Item -Force ru020b.txt ru020b_b
Move-Item -Force ru020c.txt ru020c_b
Move-Item -Force ru020mr.txt ru020mr_b
Move-Item -Force u020a1.sf u020a1_b.sf
Move-Item -Force u020a1.sfd u020a1_b.sfd

}

if ((Test-Path u020a1_c.sf) -and ((Get-Item u020a1_c.sf ).Length -gt 0 ))
{

Move-Item -Force u020a1_c.sf u020a1.sf
Move-Item -Force u020a1_c.sfd u020a1.sfd

&$env:cmd\u020

Move-Item -Force u020_tp.sf u020_tapeout_file_c
Remove-Item u020_tp.sfd
Move-Item -Force ru020a.txt ru020a_c
Move-Item -Force ru020b.txt ru020b_c
Move-Item -Force ru020c.txt ru020c_c
Move-Item -Force ru020mr.txt ru020mr_c
Move-Item -Force u020a1.sf u020a1_c.sf
Move-Item -Force u020a1.sfd u020a1_c.sfd

}

if ((Test-Path u020a1_d.sf) -and ((Get-Item u020a1_d.sf ).Length -gt 0 ))
{

Move-Item -Force u020a1_d.sf u020a1.sf
Move-Item -Force u020a1_d.sfd u020a1.sfd

&$env:cmd\u020

Move-Item -Force u020_tp.sf u020_tapeout_file_d
Remove-Item u020_tp.sfd
Move-Item -Force ru020a.txt ru020a_d
Move-Item -Force ru020b.txt ru020b_d
Move-Item -Force ru020c.txt ru020c_d
Move-Item -Force ru020mr.txt ru020mr_d
Move-Item -Force u020a1.sf u020a1_d.sf
Move-Item -Force u020a1.sfd u020a1_d.sfd

}

Get-Content ru020a_b, ru020a_c, ru020a_d | Add-Content ru020a_a
Move-Item -Force ru020a_a ru020a

Get-Content ru020b_b, ru020b_c, ru020b_d | Add-Content ru020b_a
Move-Item -Force ru020b_a ru020b

Get-Content ru020c_b, ru020c_c, ru020c_d | Add-Content ru020c_a
Move-Item -Force ru020c_a ru020c

Get-Content ru020mr_b, ru020mr_c, ru020mr_d | Add-Content ru020mr_a
Move-Item -Force ru020mr_a ru020mr

Get-Content uo20_tapeout_file_b, u020_tapeout_file_c, u020_tapeout_file_d | Add-Content u020_tapeout_file_a
Get-Content u022_tp.sf, sd_u022.sf | Add-Content u020_tapeout_file_a
Move-Item -Force u020_tapeout_file_a u020_tapeout_file

Get-Content ru020b | Out-Printer
#lp ru020c

# $cmd/backup_ohip_tape

echo "U010 IN PROGRESS $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

&$env:cmd\r010

echo "U035 IN PROGRESS $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

echo " --- u035a --- "
&$env:COBOL u035a
echo " --- u035b --- "
&$env:COBOL u035b
echo " --- u035c --- "
&$env:COBOL u035c

echo "U035 ENDING $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

echo ""

# $cmd/backup_after_ohip_tape

Get-Content ohiptape.ls | Out-Printer
