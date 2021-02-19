#-------------------------------------------------------------------------------
# File 'backup_60_82_83_86_reports.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_60_82_83_86_reports'
#-------------------------------------------------------------------------------
Push-Location
echo "backup 61 - 66 and 82 and 83 reports"

echo ""
echo "Hit NEW-LINE to commence backup of monthend reports."
$garbage = Read-Host

echo ""
echo "BACKUP NOW COMMENCING ..."

Get-Date
echo ""

Set-Location $env:application_root
echo "Preparing list of file to be backed up ..."
Get-Location
Get-ChildItem production\60\r004*, production\60\r005*, production\60\r011*, production\60\r012*, production\60\r013*, `
  production\60\r051*, production\60\r070*, production\60\r210*, production\60\r211*, production\61\r004*, `
  production\61\r051*, production\62\r004*, production\62\r051*, production\63\r004*, production\63\r051*, `
  production\64\r004*, production\64\r051*, production\65\r004*, production\65\r051*, production\66\r004*, `
  production\66\r051*, production\70\r004*, production\70\r005*, production\70\r011*, production\70\r012*, `
  production\70\r013*, production\70\r051*, production\70\r070*, production\70\r210*, production\70\r211*, `
  production\71\r004*, production\71\r051*, production\72\r004*, production\72\r051*, production\73\r004*, `
  production\73\r051*, production\74\r004*, production\74\r051*, production\75\r004*, production\75\r051*, `
  production\82\r004*, production\82\r005*, production\82\r011*, production\82\r012*, production\82\r013*, `
  production\82\r051*, production\82\r070*, production\82\r210*, production\82\r211*, production\83\r004*, `
  production\83\r005*, production\83\r011*, production\83\r012*, production\83\r013*, production\83\r051*, `
  production\83\r070*, production\83\r210*, production\83\r211*, production\86\r* | Select-Object -ExpandProperty FullName > production\backup_82_83_60.ls
  (Get-Content production\backup_82_83_60.ls ) | Set-Content production\backup_82_83_60.ls
  
  
  

echo ""
echo "Now begining backup to tape ..."
Get-Date
# CONVERSION ERROR (expected, #81): tape device is involved.
# cat production/backup_82_83_60.ls |cpio -ocuvB > /dev/rmt/0
&"C:\Program Files\7-Zip\7z.exe" a -aoa -spf2 production\backup_82_83_60.tar @production\backup_82_83_60.ls
echo ""
Get-Date
echo "Rewinding tape ..."
# CONVERSION ERROR (expected, #85): tape device is involved.
# mt -f /dev/rmt/0 rewind

echo ""
echo "VERIFICATION NOW COMMENCING ... Be patient - this may take some time!"
echo ""
echo "Output is being sent to a file that will be paged out at end of verify ..."
echo ""
echo ""
# CONVERSION ERROR (expected, #93): tape device is involved.
# cpio -itcvB < /dev/rmt/0 > production/backup_82_83_60.log
&"C:\Program Files\7-Zip\7z.exe" l production/backup_82_83_60.tar > production/backup_82_83_60.log
(Get-Content production/backup_82_83_60.log | Select-Object -Skip 17) | Set-Content production/backup_82_83_60.log
$test = Get-Content production/backup_82_83_60.log
$test = $test[0..($test.count-3)]
$test | ForEach { $_.Remove(0,53) } | Set-Content production/backup_82_83_60.log
echo ""
echo ""
echo "Comparing lines in .ls vs .log"
Get-ChildItem production\backup_82_83_60.ls, production\backup_82_83_60.log
echo ""
Get-Content production\backup_82_83_60.ls | Measure-Object -Line | Select -ExpandProperty Lines
Get-Content production\backup_82_83_60.log | Measure-Object -Line | Select -ExpandProperty Lines

echo ""
#echo Press Enter to page out verification log
#read garbage
#pg production/backup_82_83_60.log

echo ""
Get-Date
echo "DONE!"
Pop-Location
# CONVERSION ERROR (expected, #111): tape device is involved.
# mt -f /dev/rmt/0 rewind
