#-------------------------------------------------------------------------------
# File 'backup_portal_reports.ps1'
# Converted to PowerShell by CORE Migration on 2017-10-01 10:16:47
# Original file name was 'backup_portal_reports'
#-------------------------------------------------------------------------------

# Save the current working directory
Push-Location -Path .

echo "backup portal monthend reports"
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
Get-ChildItem production\*portal*, production\23\*portal*, production\24\*portal*, production\25\*portal*, `
  production\26\*portal*, production\30\*portal*, production\31\*portal*, production\32\*portal*, `
  production\33\*portal*, production\34\*portal*, production\35\*portal*, production\36\*portal*, `
  production\37\*portal*, production\41\*portal*, production\42\*portal*, production\43\*portal*, `
  production\44\*portal*, production\45\*portal*, production\46\*portal*, production\47\*portal*, `
  production\48\*portal*, production\60\*portal*, production\61\*portal*, production\62\*portal*, `
  production\63\*portal*, production\64\*portal*, production\65\*portal*, production\66\*portal*, `
  production\68\*portal*, production\69\*portal*, production\70\*portal*, production\71\*portal*, `
  production\72\*portal*, production\73\*portal*, production\74\*portal*, production\75\*portal*, `
  production\78\*portal*, production\79\*portal*, production\80\*portal*, production\82\*portal*, `
  production\83\*portal*, production\84\*portal*, production\86\*portal*, production\87\*portal*, `
  production\88\*portal*, production\89\*portal*, production\91\*portal*, production\92\*portal*, `
  production\93\*portal*, production\94\*portal*, production\95\*portal*, production\96\*portal*, `
  production\98\*portal* | Select-Object -ExpandProperty FullName > production\backup_portal.ls
  (Get-Content production\backup_portal.ls | Select-Object -Skip 3) | Set-Content production\backup_portal.ls

echo ""
echo "Now begining backup to tape ..."
Get-Date
# CONVERSION ERROR (expected, #74): tape device is involved.
# cat production/backup_portal.ls  |cpio -ocuvB > /dev/rmt/0
&"C:\Program Files\7-Zip\7z.exe" a -aoa $env:pb_data/backup_portal.tar @$env:pb_prod\backup_portal.ls

echo ""
Get-Date
echo "DONE!"

# CONVERSION ERROR (expected, #79): tape device is involved.
# mt -f /dev/rmt/0 rewind

# Go back to the original directory before script was launched.
Pop-Location
