#-------------------------------------------------------------------------------
# File 'reloaddaily_1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'reloaddaily_1'
#-------------------------------------------------------------------------------

echo "reloaddaily_1"
echo ""
# CONVERSION ERROR (unexpected, #3): Unknown command.
# [ $# -eq 0 ] && echo "usage: reloaddaily_1 {filename}" && exit

echo "Reload from tape created bybackupdaily_1.cli"
echo ""
echo "----------!  f002   - claims mstr"
echo "----------!  f002   - claims extra"
echo ""
echo ""
# CONVERSION ERROR (unexpected, #11): Unknown command.
# mt rewind
echo ""

Set-Location $pb_data

echo "Reload $1 ? (y\n)"
&$string = Read-Host

if ("$string" -eq "y" -or "$string" -eq "Y")
{
        Set-Location $pb_data
        Get-Location
        echo ""
        Get-Date
        echo ""
# CONVERSION ERROR (expected, #26): tape device is involved.
#         cpio -icvb -I/dev/rmt/1 "$1"
        echo ""
        Get-Date
}

echo ""
echo ""
echo ""
Set-Location $application_upl
# CONVERSION ERROR (unexpected, #35): Unknown command.
# mt rewind
echo ""
echo "Finished ..."
echo ""
