#-------------------------------------------------------------------------------
# File 'reload_daily_bk2.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'reload_daily_bk2'
#-------------------------------------------------------------------------------

echo "RELOAD_F001_F020_F050_SHDW"

echo "Reload from tape created bybackup_f001_f020_f050_shdw"
echo "oribackup_f001_f020_f050_shdw"
echo ""
echo "----------!  f002   - claims mstr"
echo "----------!  f010   - patient mstr"
echo "----------!  f001   - batch control file"
echo "----------!  f020   - doctor mstr"
echo "----------!  f050   - doc revenue mstr"
echo "----------!  f051   - doc cash    mstr"
echo "----------!  f050tp - doc revenue mstr"
echo "----------!  f051tp - doc cash    mstr"
echo "----------!  f002   - claim shadow"
echo "----------!  f090   - constants master"
echo "----------!  f021   - available doctor mstr"
echo "----------!  f096   - ohip pay code mstr"
echo "----------!  f023   - alternative doc nbr"
echo "----------!  f002   - suspend hdr"
echo "----------!  f002   - suspend dtl"
echo "----------!  f002   - suspend address"
echo "----------!  f085   - rejected claims"
echo "----------!  f086   - patient-id.dat"
echo "----------!  f086   - rma`'s patient-id.dat 95$Env:root\02\02"
echo "----------!  f071   - clinet rma claims nbr"
echo "----------!  f072   - client mstr"
echo "----------!  f073   - client doc mstr"
echo "----------!  f098   - equiv oma code mstr"
echo "----------!  f022   - deleted doc"
echo "----------!  u010   - u010-out-file"
echo "----------!  adj    - adj-claim-file"
echo "----------!  f002   - f002 extra"
echo "----------!  f020   - f020 extra"
echo ""
echo ""

echo "RELOAD BACKUP_DAILY ? (y\n)"
&$string = Read-Host

if ("$string" -eq "Y" -or "$string" -eq "y")
{
        Set-Location $pb_data
        Get-Location
        echo ""
        Get-Date
        echo "Build a consolidated list of files to be restored ..."
        Set-Location $pb_data
        Copy-Item $null reload_daily.ls
        Get-Content backup_daily.ls, rmadir.ls, webdir.ls, web1dir.ls, diskettedir.ls, diskette1dir.ls, stonedir.ls `
          | Set-Content reload_daily.ls
        echo ""
        Get-Date

        echo "RELOAD BACKUP_DAILY ? (y\n)"
        &$string = Read-Host

if ("$ string" -eq "Y" -or "$string" -eq "y")
        {
        echo "restoring files"

        Set-Location $Env:root\

        Get-Location
# CONVERSION ERROR (expected, #69): tape device is involved.
#         cpio -icuvB "`cat reload_daily.ls`" < /dev/rmt/1
        echo ""
        echo "restore DONE!"

#       cpio -icuvB -I $pb_data/backup_data.cpio
        echo ""
        Get-Date
        echo ""
}
echo ""
# CONVERSION ERROR (expected, #79): tape device is involved.
# mt -f /dev/rmt/1 rewind
echo ""
echo "FINISHED ..."
echo ""
# CONVERSION ERROR (unexpected, #83): Unknown command.
# time
echo ""
