#-------------------------------------------------------------------------------
# File 'backup_rat_files.ps1'
# Converted to PowerShell by CORE Migration on 2017-10-01 10:16:47
# Original file name was 'backup_rat_files'
#-------------------------------------------------------------------------------

echo "backup_rat_files"
echo ""
echo "Hit NEW-LINE to commence backup of RAT files ..."
$garbage = Read-Host

echo ""
echo "BACKUP NOW COMMENCING ..."

Get-Date
echo ""
# CONVERSION ERROR (expected, #11): tape device is involved.
# mt -f /dev/rmt/0 rewind

Set-Location $env:application_root
echo "Preparing list of file to be backed up ..."
Get-Location
Get-ChildItem data\ohip_rat_ascii*, upload\A*, upload\gov*, production\moh*txt, production\r997_portal_ss.csv, `
  production\part_paid_hdr*, production\part_paid_dtl*, production\part_adj_batch*, production\ru030*, `
  production\u030*, production\r997*, production\u997*, production\r031*, production\22\ru030*, production\22\r031*, `
  production\23\part_paid_hdr*, production\23\part_paid_dtl*, production\23\part_adj_batch*, production\23\ru030*, `
  production\23\u030*, production\23\r997*, production\23\u997*, production\23\r031*, production\24\part_paid_hdr*, `
  production\24\part_paid_dtl*, production\24\part_adj_batch*, production\24\ru030*, production\24\u030*, `
  production\24\r997*, production\24\u997*, production\24\r031*, production\25\part_paid_hdr*, `
  production\25\part_paid_dtl*, production\25\part_adj_batch*, production\25\ru030*, production\25\u030*, `
  production\25\r997*, production\25\u997*, production\25\r031*, production\26\part_paid_hdr*, `
  production\26\part_paid_dtl*, production\26\part_adj_batch*, production\26\ru030*, production\26\u030*, `
  production\26\r997*, production\26\u997*, production\26\r031*, production\30\part_paid_hdr*, `
  production\30\part_paid_dtl*, production\30\part_adj_batch*, production\30\ru030*, production\30\u030*, `
  production\30\r997*, production\30\u997*, production\30\r031*, production\31\part_paid_hdr*, `
  production\31\part_paid_dtl*, production\31\part_adj_batch*, production\31\ru030*, production\31\u030*, `
  production\31\r997*, production\31\u997*, production\31\r031*, production\32\part_paid_hdr*, `
  production\32\part_paid_dtl*, production\32\part_adj_batch*, production\32\ru030*, production\32\u030*, `
  production\32\r997*, production\32\u997*, production\32\r031*, production\33\part_paid_hdr*, `
  production\33\part_paid_dtl*, production\33\part_adj_batch*, production\33\ru030*, production\33\u030*, `
  production\33\r997*, production\33\u997*, production\33\r031*, production\34\part_paid_hdr*, `
  production\34\part_paid_dtl*, production\34\part_adj_batch*, production\34\ru030*, production\34\u030*, `
  production\34\r997*, production\34\u997*, production\34\r031*, production\35\part_paid_hdr*, `
  production\35\part_paid_dtl*, production\35\part_adj_batch*, production\35\ru030*, production\35\u030*, `
  production\35\r997*, production\35\u997*, production\35\r031*, production\36\part_paid_hdr*, `
  production\36\part_paid_dtl*, production\36\part_adj_batch*, production\36\ru030*, production\36\u030*, `
  production\36\r997*, production\36\u997*, production\36\r031*, production\37\part_paid_hdr*, `
  production\37\part_paid_dtl*, production\37\part_adj_batch*, production\37\ru030*, production\37\u030*, `
  production\37\r997*, production\37\u997*, production\37\r031*, production\41\part_paid_hdr*, `
  production\41\part_paid_dtl*, production\41\part_adj_batch*, production\41\ru030*, production\41\u030*, `
  production\41\r997*, production\41\u997*, production\41\r031*, production\42\part_paid_hdr*, `
  production\42\part_paid_dtl*, production\42\part_adj_batch*, production\42\ru030*, production\42\u030*, `
  production\42\r997*, production\42\u997*, production\42\r031*, production\43\part_paid_hdr*, `
  production\43\part_paid_dtl*, production\43\part_adj_batch*, production\43\ru030*, production\43\u030*, `
  production\43\r997*, production\43\u997*, production\43\r031*, production\44\part_paid_hdr*, `
  production\44\part_paid_dtl*, production\44\part_adj_batch*, production\44\ru030*, production\44\u030*, `
  production\44\r997*, production\44\u997*, production\44\r031*, production\45\part_paid_hdr*, `
  production\45\part_paid_dtl*, production\45\part_adj_batch*, production\45\ru030*, production\45\u030*, `
  production\45\r997*, production\45\u997*, production\45\r031*, production\46\part_paid_hdr*, `
  production\46\part_paid_dtl*, production\46\part_adj_batch*, production\46\ru030*, production\46\u030*, `
  production\46\r997*, production\46\u997*, production\46\r031*, production\48\part_paid_hdr*, `
  production\48\part_paid_dtl*, production\48\part_adj_batch*, production\48\ru030*, production\48\u030*, `
  production\48\r997*, production\48\u997*, production\48\r031*, production\90\part_paid_hdr*, `
  production\90\part_paid_dtl*, production\90\part_adj_batch*, production\90\ru030*, production\90\u030*, `
  production\90\r997*, production\90\u997*, production\90\r031*, production\61\part_paid_hdr*, `
  production\61\part_paid_dtl*, production\61\part_adj_batch*, production\61\ru030*, production\61\u030*, `
  production\61\r997*, production\61\u997*, production\61\r031*, production\62\part_paid_hdr*, `
  production\62\part_paid_dtl*, production\62\part_adj_batch*, production\62\ru030*, production\62\u030*, `
  production\62\r997*, production\62\u997*, production\62\r031*, production\63\part_paid_hdr*, `
  production\63\part_paid_dtl*, production\63\part_adj_batch*, production\63\ru030*, production\63\u030*, `
  production\63\r997*, production\63\u997*, production\63\r031*, production\64\part_paid_hdr*, `
  production\64\part_paid_dtl*, production\64\part_adj_batch*, production\64\ru030*, production\64\u030*, `
  production\64\r997*, production\64\u997*, production\64\r031*, production\65\part_paid_hdr*, `
  production\65\part_paid_dtl*, production\65\part_adj_batch*, production\65\ru030*, production\65\u030*, `
  production\65\r997*, production\65\u997*, production\65\r031*, production\66\part_paid_hdr*, `
  production\66\part_paid_dtl*, production\66\part_adj_batch*, production\66\ru030*, production\66\u030*, `
  production\66\r997*, production\66\u997*, production\66\r031*, production\68\part_paid_hdr*, `
  production\68\part_paid_dtl*, production\68\part_adj_batch*, production\68\ru030*, production\68\u030*, `
  production\68\r997*, production\68\u997*, production\68\r031*, production\69\part_paid_hdr*, `
  production\69\part_paid_dtl*, production\69\part_adj_batch*, production\69\ru030*, production\69\u030*, `
  production\69\r997*, production\69\u997*, production\69\r031*, production\71\part_paid_hdr*, `
  production\71\part_paid_dtl*, production\71\part_adj_batch*, production\71\ru030*, production\71\u030*, `
  production\71\r997*, production\71\u997*, production\71\r031*, production\72\part_paid_hdr*, `
  production\72\part_paid_dtl*, production\72\part_adj_batch*, production\72\ru030*, production\72\u030*, `
  production\72\r997*, production\72\u997*, production\72\r031*, production\73\part_paid_hdr*, `
  production\73\part_paid_dtl*, production\73\part_adj_batch*, production\73\ru030*, production\73\u030*, `
  production\73\r997*, production\73\u997*, production\73\r031*, production\74\part_paid_hdr*, `
  production\74\part_paid_dtl*, production\74\part_adj_batch*, production\74\ru030*, production\74\u030*, `
  production\74\r997*, production\74\u997*, production\74\r031*, production\75\part_paid_hdr*, `
  production\75\part_paid_dtl*, production\75\part_adj_batch*, production\75\ru030*, production\75\u030*, `
  production\75\r997*, production\75\u997*, production\75\r031*, production\78\part_paid_hdr*, `
  production\78\part_paid_dtl*, production\78\part_adj_batch*, production\78\ru030*, production\78\u030*, `
  production\78\r997*, production\78\u997*, production\78\r031*, production\79\part_paid_hdr*, `
  production\79\part_paid_dtl*, production\79\part_adj_batch*, production\79\ru030*, production\79\u030*, `
  production\79\r997*, production\79\u997*, production\79\r031*, production\80\part_paid_hdr*, `
  production\80\part_paid_dtl*, production\80\part_adj_batch*, production\80\ru030*, production\80\u030*, `
  production\80\r997*, production\80\u997*, production\80\r031*, production\81\part_paid_hdr*, `
  production\81\part_paid_dtl*, production\81\part_adj_batch*, production\81\ru030*, production\81\u030*, `
  production\81\r997*, production\81\u997*, production\81\r031*, production\82\part_paid_hdr*, `
  production\82\part_paid_dtl*, production\82\part_adj_batch*, production\82\ru030*, production\82\u030*, `
  production\82\r997*, production\82\u997*, production\82\r031*, production\84\part_paid_hdr*, `
  production\84\part_paid_dtl*, production\84\part_adj_batch*, production\84\ru030*, production\84\u030*, `
  production\84\r997*, production\84\u997*, production\84\r031*, production\86\part_paid_hdr*, `
  production\86\part_paid_dtl*, production\86\part_adj_batch*, production\86\ru030*, production\86\u030*, `
  production\86\r997*, production\86\u997*, production\86\r031*, production\87\part_paid_hdr*, `
  production\87\part_paid_dtl*, production\87\part_adj_batch*, production\87\ru030*, production\87\u030*, `
  production\87\r997*, production\87\u997*, production\87\r031*, production\88\part_paid_hdr*, `
  production\88\part_paid_dtl*, production\88\part_adj_batch*, production\88\ru030*, production\88\u030*, `
  production\88\r997*, production\88\u997*, production\88\r031*, production\89\part_paid_hdr*, `
  production\89\part_paid_dtl*, production\89\part_adj_batch*, production\89\ru030*, production\89\u030*, `
  production\89\r997*, production\89\u997*, production\89\r031*, production\91\part_paid_hdr*, `
  production\91\part_paid_dtl*, production\91\part_adj_batch*, production\91\ru030*, production\91\u030*, `
  production\91\r997*, production\91\u997*, production\91\r031*, production\92\part_paid_hdr*, `
  production\92\part_paid_dtl*, production\92\part_adj_batch*, production\92\ru030*, production\92\u030*, `
  production\92\r997*, production\92\u997*, production\92\r031*, production\93\part_paid_hdr*, `
  production\93\part_paid_dtl*, production\93\part_adj_batch*, production\93\ru030*, production\93\u030*, `
  production\93\r997*, production\93\u997*, production\93\r031*, production\94\part_paid_hdr*, `
  production\94\part_paid_dtl*, production\94\part_adj_batch*, production\94\ru030*, production\94\u030*, `
  production\94\r997*, production\94\u997*, production\94\r031*, production\95\part_paid_hdr*, `
  production\95\part_paid_dtl*, production\95\part_adj_batch*, production\95\ru030*, production\95\u030*, `
  production\95\r997*, production\95\u997*, production\95\r031*, production\96\part_paid_hdr*, `
  production\96\part_paid_dtl*, production\96\part_adj_batch*, production\96\ru030*, production\96\u030*, `
  production\96\r997*, production\96\r031*, production\96\u997* | Select-Object FullName > production\backup_rat_files.ls
  (Get-Content production/backup_rat_files.ls | Select-Object -Skip 3) | Set-Content production\backup_rat_files.ls

echo ""
echo "Now begining backup to tape ..."
Get-Date
# CONVERSION ERROR (expected, #428): tape device is involved.
# cat production/backup_rat_files.ls |cpio -ocuvB > /dev/rmt/0
&"C:\Program Files\7-Zip\7z.exe" a -spf data/backup_rat_files.tar @production/backup_rat_files.ls
echo ""
Get-Date
echo "DONE!"

# CONVERSION ERROR (expected, #433): tape device is involved.
# mt -f /dev/rmt/0 rewind
