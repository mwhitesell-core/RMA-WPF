#-------------------------------------------------------------------------------
# File 'backup_22to48_reports.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_22to48_reports'
#-------------------------------------------------------------------------------

echo "backup 80, 84 and 91 to 96 reports"
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
Get-ChildItem production\r004*, production\r005*, production\r011*, production\r012*, production\r013*, `
  production\r051*, production\r123*, production\r111b*, production\r120*, production\r119*, production\r121*, `
  production\r124*, production\r070*, production\23\r004*, production\23\r005*, production\23\r011*, `
  production\23\r012*, production\23\r013*, production\23\r051*, production\23\r070*, production\24\r004*, `
  production\24\r005*, production\24\r011*, production\24\r012*, production\24\r013*, production\24\r051*, `
  production\24\r070*, production\25\r004*, production\25\r005*, production\25\r011*, production\25\r012*, `
  production\25\r013*, production\25\r051*, production\25\r070*, production\26\r004*, production\26\r005*, `
  production\26\r011*, production\26\r012*, production\26\r013*, production\26\r051*, production\26\r070*, `
  production\30\r004*, production\30\r005*, production\30\r011*, production\30\r012*, production\30\r013*, `
  production\30\r051*, production\30\r070*, production\31\r004*, production\31\r005*, production\31\r011*, `
  production\31\r012*, production\31\r013*, production\31\r051*, production\31\r070*, production\32\r004*, `
  production\32\r005*, production\32\r011*, production\32\r012*, production\32\r013*, production\32\r051*, `
  production\32\r070*, production\33\r004*, production\33\r005*, production\33\r011*, production\33\r012*, `
  production\33\r013*, production\33\r051*, production\33\r070*, production\34\r004*, production\34\r005*, `
  production\34\r011*, production\34\r012*, production\34\r013*, production\34\r051*, production\34\r070*, `
  production\35\r004*, production\35\r005*, production\35\r011*, production\35\r012*, production\35\r013*, `
  production\35\r051*, production\35\r070*, production\36\r004*, production\36\r005*, production\36\r011*, `
  production\36\r012*, production\36\r013*, production\36\r051*, production\36\r070*, production\41\r004*, `
  production\41\r005*, production\41\r011*, production\41\r012*, production\41\r013*, production\41\r051*, `
  production\41\r070*, production\42\r004*, production\42\r005*, production\42\r011*, production\42\r012*, `
  production\42\r013*, production\42\r051*, production\42\r070*, production\43\r004*, production\43\r005*, `
  production\43\r011*, production\43\r012*, production\43\r013*, production\43\r051*, production\43\r070*, `
  production\44\r004*, production\44\r005*, production\44\r011*, production\44\r012*, production\44\r013*, `
  production\44\r051*, production\44\r070*, production\45\r004*, production\45\r005*, production\45\r011*, `
  production\45\r012*, production\45\r013*, production\45\r051*, production\45\r070*, production\46\r004*, `
  production\46\r005*, production\46\r011*, production\46\r012*, production\46\r013*, production\46\r051*, `
  production\46\r070*, production\48\r004*, production\48\r005*, production\48\r011*, production\48\r012*, `
  production\48\r013*, production\48\r051*, production\48\r070*, production\98\r004*, production\98\r005*, `
  production\98\r011*, production\98\r012*, production\98\r013*, production\98\r051*, production\98\r070* `
  | Select-Object -ExpandProperty FullName > production\backup_22to48.ls
  (Get-Content production\backup_22to48.ls |Select-Object -Skip 3) | Set-Content production\backup_22to48.ls

echo ""
echo "Now begining backup to tape ..."
Get-Date
# CONVERSION ERROR (expected, #168): tape device is involved.
# cat production/backup_22to48.ls  |cpio -ocuvB > /dev/rmt/0
&"C:\Program Files\7-Zip\7z.exe" a -aoa -spf2 production\backup_22to48.tar @production\backup_22to48.ls
&"C:\Program Files\7-Zip\7z.exe" rn production\backup_22to48.tar -r RMA/alpha alpha
echo ""
Get-Date
echo "DONE!"

# CONVERSION ERROR (expected, #173): tape device is involved.
# mt -f /dev/rmt/0 rewind
