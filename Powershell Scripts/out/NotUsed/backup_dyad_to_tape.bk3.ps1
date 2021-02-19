#-------------------------------------------------------------------------------
# File 'backup_dyad_to_tape.bk3.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_dyad_to_tape.bk3'
#-------------------------------------------------------------------------------

echo "BACKUP_DYAD_TO_TAPE"
echo ""

echo ""
echo "BACKUP NOW COMMENCING ..."
echo ""
echo ""
Get-Date
echo ""

Set-Location $env:application_root
# remove flag that indicates job finished successfully
Remove-Item backup_dyad_to_tape.flg *> $null

# backup non data files
Get-ChildItem $Env:root\beta\backup_transfer_area\backup_nightly.cpio > data\backup_dyad_to_tape.ls

# backup data files
echo "Finding directories with sub directories and files..."
Set-Location $Env:root\
Get-Location
#find /alpha/rmabill/rmabill101c/data/*   -print >> $pb_data/backup_dyad_to_tape.ls
Get-ChildItem -Exclude "f010_pat_mstr", "f010_pat_mstr.dat", "f010_pat_mstr.idx", "f002_claims_mstr", `
  "f002_claims_mstr.dat", "f002_claims_mstr.idx", "f011_pat_mstr_elig_history", "f011_pat_mstr_elig_history.dat", `
  "f011_pat_mstr_elig_history.idx" $Env:root\alpha\rmabill\rmabill101c\data | Select -ExpandProperty FullName `
  >> $pb_data\backup_dyad_to_tape.ls
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabill101c\data2\* | Select -ExpandProperty FullName `
  >> $pb_data\backup_dyad_to_tape.ls
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabillicu\data\* | Select -ExpandProperty FullName `
  >> $pb_data\backup_dyad_to_tape.ls
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabillicu\data2\* | Select -ExpandProperty FullName `
  >> $pb_data\backup_dyad_to_tape.ls
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabillmp\data\* | Select -ExpandProperty FullName `
  >> $pb_data\backup_dyad_to_tape.ls
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabillmp\data2\* | Select -ExpandProperty FullName `
  >> $pb_data\backup_dyad_to_tape.ls
echo ""
echo ""
Get-Date

echo "Starting copy of file to tape ..."
Set-Location $env:application_root
Get-Location
echo "before cat"
#cat data/backup_dyad_to_tape.ls  | cpio -ocuvB > /dev/rmt/1  
# CONVERSION ERROR (expected, #49): tape device is involved.
# cat data/backup_dyad_to_tape.ls  | cpio -ocuvB | compress -c | dd of=/dev/rmt/1  
# set flag that indicates job finished successfully
utouch backup_dyad_to_tape.flg
echo " "
Get-Date
echo "DONE!"

echo ""
Get-Date
echo ""

# CONVERSION ERROR (expected, #60): tape device is involved.
# mt -f /dev/rmt/1 rewind
