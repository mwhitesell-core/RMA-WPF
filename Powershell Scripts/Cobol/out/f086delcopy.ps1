#-------------------------------------------------------------------------------
# File 'f086delcopy.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'f086delcopy'
#-------------------------------------------------------------------------------

# f086delcopy
# 00/oct/16 B.E. - added code to keep 5 backups of files
# 04/jan/05 b.e. - perform only if in 'live' application

# NOTE: LIVE version is   '101c'


if ("$RMABILL_VERSION" -eq "101c")
{

Remove-Item f086_pat_id_bkp_5.dat  > $null
Move-Item f086_pat_id_bkp_4.dat f086_pat_id_bkp_5.dat
Move-Item f086_pat_id_bkp_3.dat f086_pat_id_bkp_4.dat
Move-Item f086_pat_id_bkp_2.dat f086_pat_id_bkp_3.dat
Move-Item f086_pat_id_bkp.dat f086_pat_id_bkp_2.dat
Copy-Item f086_pat_id.dat f086_pat_id_bkp.dat

Remove-Item f086_pat_id_bkp_5.d001  > $null
Move-Item f086_pat_id_bkp_4.d001 f086_pat_id_bkp_5.d001
Move-Item f086_pat_id_bkp_3.d001 f086_pat_id_bkp_4.d001
Move-Item f086_pat_id_bkp_2.d001 f086_pat_id_bkp_3.d001
Move-Item f086_pat_id_bkp.d001 f086_pat_id_bkp_2.d001
Copy-Item f086_pat_id.d001 f086_pat_id_bkp.d001

Remove-Item f086_pat_id_bkp_5.d003  > $null
Move-Item f086_pat_id_bkp_4.d003 f086_pat_id_bkp_5.d003
Move-Item f086_pat_id_bkp_3.d003 f086_pat_id_bkp_4.d003
Move-Item f086_pat_id_bkp_2.d003 f086_pat_id_bkp_3.d003
Move-Item f086_pat_id_bkp.d003 f086_pat_id_bkp_2.d003
Copy-Item f086_pat_id.d003 f086_pat_id_bkp.d003

Remove-Item f086_pat_id.dat
Remove-Item f086_pat_id.d001
Remove-Item f086_pat_id.d003

cobrun++ $obj\createpatid
Copy-Item f086_pat_id.dat f086_pat_id.d003
Copy-Item f086_pat_id.dat f086_pat_id.d001

Get-Item f086_pat_id.dat | % {$_.isreadonly = $false}
Get-Item f086_pat_id.d001 | % {$_.isreadonly = $false}
Get-Item f086_pat_id.d003 | % {$_.isreadonly = $false}
} else {
  echo "NOT running in Live - f086_delcopy bypassed ..."

}
