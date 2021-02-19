
#-------------------------------------------------------------------------------
# File 'backup_earnings_mp.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'backup_earnings_mp'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

# Save the current working directory
Push-Location -Path .

# EARNINGS_BACKUP.CLI
# parameters: $1 contains 'nv' if no verify is to be performed

# 2000/11/13  yas backup disk files *Z daily and monthend onto tape 
# 2008/06/18  brad 'nv' option

echo "backup_earnings_MP"
echo ""
echo ""

if (("$1" -ne "") -and ("$1" -ne "nv"))
{
        echo ""
        echo "**ERROR**"
        echo "You must run the backup with either no parameter or theNo Verify  parameter"
        echo ""
        echo ""
        echo "Valid format:   backup_earning_mp [nv]"
        exit
}

Set-Location $env:pb_data
#Added to account for cpio overwrite
Remove-Item backup_earnings_mp.tar
Get-Date
echo ""
echo "This macro will perform a TAPE backup ..."
echo ""
Get-Location
echo "Press Enter to begin backup:"
$garbage = Read-Host

echo "Backup started ..."
Get-ChildItem *.tar | Select-Object Name  > backup_earnings_mp.ls
(Get-Content backup_earnings_mp.ls | Select-Object -Skip 3) | Set-Content backup_earnings_mp.ls
echo ""
Get-Date
echo ""
echo "Performing TAPE backup ..."
echo "doing cpio ....................."
# CONVERSION WARNING; tape is involved.
# cat backup_earnings_mp.ls  |cpio -ocuvB > /dev/rmt/0
&"C:\Program Files\7-Zip\7z.exe" a -aoa backup_earnings_mp.tar @$env:pb_data/backup_earnings_mp.ls
echo ""
Get-Date

echo ""
# CONVERSION WARNING; tape is involved.
# echo mt -f /dev/rmt/0 rewind
echo ""
Get-Date

if ("$1" -ne "nv")
{
echo ""
echo "VERIFICATION NOW COMMENCING ... Be patient - this may take some time!"
echo ""
echo "Output is being sent to a file that will be paged out at end of verify ..."
echo ""
# CONVERSION WARNING; tape is involved.
# cpio -itcvB < /dev/rmt/0 >   backup_earnings_mp.log
&"C:\Program Files\7-Zip\7z.exe" l backup_earnings_mp.tar > backup_earnings_mp.log
(Get-Content backup_earnings_mp.log | Select-Object -Skip 17) | Set-Content backup_earnings_mp.log
$test = Get-Content backup_earnings_mp.log
$test = $test[0..($test.count-3)]
$test | ForEach { $_.Remove(0,53) } | Set-Content backup_earnings_mp.log
echo ""

Get-ChildItem backup_earnings_mp.ls, backup_earnings_mp.log
echo ""
echo "Comparing lines in .ls vs .log"
Get-Content backup_earnings_mp.log | Measure-Object -Line | Select -ExpandProperty Lines
Get-Content backup_earnings_mp.ls | Measure-Object -Line | Select -ExpandProperty Lines

echo ""
# CONVERSION WARNING; tape is involved.
# mt -f /dev/rmt/0 rewind
echo ""

echo "Press Enter to page out verification log"
$garbage = Read-Host

Get-Content backup_earnings_mp.log | Out-Host -paging

echo ""
Get-Date

} else {
        echo "NO VERIFICATION of tape was performed!"
}
echo ""
echo "DONE!"

# Go back to the original directory before script was launched.
Pop-Location



