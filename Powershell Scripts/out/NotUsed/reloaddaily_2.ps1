#-------------------------------------------------------------------------------
# File 'reloaddaily_2.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'reloaddaily_2'
#-------------------------------------------------------------------------------

echo "reloaddaily_2.cli"
echo ""
# CONVERSION ERROR (unexpected, #3): Unknown command.
# [ $# -eq 0 ] && echo "usage: reload_daily {filename}" && exit

echo "reload from tape created bybackup_f001_f020_f050_shdw"
echo "oribackup_f001_f020_f050_shdw"
echo ""
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
echo "----------!  f086   - pat-id.dat"
echo "----------!  f086   - rma#'s pat-id.dat  add 95$Env:root\02\02"
echo "----------!  f071   - client rma claim nbr"
echo "----------!  f072   - client mstr"
echo "----------!  f073   - client doc mstr"
echo "----------!  f098   - equiv oma code mstr"
echo "----------!  f022   - deleted doc"
echo "----------!  u010   - u010-out-file"
echo "----------!  ajd    - adj-claim-file"
echo "----------!  f020   - doctor-extra"
echo ""
echo ""
# CONVERSION ERROR (unexpected, #36): Unknown command.
# mt rewind
echo "Reload $1 ? (y\n)"
&$string = Read-Host

if ("$string" -eq "y" -or "$string" -eq "Y")
{
        Set-Location $pb_data
        Get-Location
        echo ""
        Get-Date
        echo ""
# CONVERSION ERROR (expected, #47): tape device is involved.
#         cpio -icvb -I/dev/rmt/1 "$1"
        echo ""
        Get-Date
}

echo ""
echo ""
Set-Location $application
# CONVERSION ERROR (unexpected, #55): Unknown command.
# mt rewind
echo ""
echo "Finished ..."
echo ""
