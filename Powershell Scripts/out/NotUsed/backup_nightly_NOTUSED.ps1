#-------------------------------------------------------------------------------
# File 'backup_nightly_NOTUSED.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_nightly_NOTUSED'
#-------------------------------------------------------------------------------

echo "BACKUP_NIGHTLY"
echo ""
#echo  'HIT   "NEWLINE"   TO COMMENCE BACKUP ...'
#read garbage

echo ""
echo "BACKUP NOW COMMENCING ..."
echo ""
echo ""
Get-Date
echo ""

Set-Location $env:application_root
# remove flag that indicates job finished successfully
Remove-Item backup_nightly.flg *> $null

Get-Location
Get-ChildItem production\moh*, production\yasemin\*, production\web\*, production\web1\*, production\web2\*, `
  production\web3\*, production\web4\*, production\web5\*, production\web6\*, production\web7\*, production\web8\*, `
  production\web9\*, production\web10\*, production\diskette\*, production\diskette1\*, production\stone\*, `
  production\kathy\*, production\mumc\*, production\*parm*, production\23\*parm*, production\31\*parm*, `
  production\32\*parm*, production\33\*parm*, production\34\*parm*, production\35\*parm*, production\36\*parm*, `
  production\37\*parm*, production\41\*parm*, production\42\*parm*, production\43\*parm*, production\44\*parm*, `
  production\45\*parm*, production\46\*parm*, production\47\*parm*, production\48\*parm*, production\60\rm*, `
  production\70\*parm*, production\70\rm*, production\80\*parm*, production\80\rm*, production\81\*parm*, `
  production\81\rm*, production\82\*parm*, production\82\rm*, production\83\*parm*, production\83\rm*, `
  production\85\*parm*, production\85\rm*, production\91\*parm*, production\91\rm*, production\92\*parm*, `
  production\92\rm*, production\93\*parm*, production\93\rm*, production\94\*parm*, production\94\rm*, `
  production\95\*parm*, production\95\rm*, production\96\*parm*, production\96\rm*, production\98\*parm*, `
  production\98\rm*, production\*parm*, production\rm*, production\aug14*, production\oct13*, production\sep16*, `
  production\f002_suspend*, production\u010*, production\*u993*, production\icuapp*, production\r010*, `
  production\f086* > data\nightly.ls
echo ""
echo ""
Get-Date


echo "Finding directories with sub directories and files..."
Set-Location $Env:root\
Get-Location
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabill101c\backups\*.ls | Select -ExpandProperty FullName `
  >> $pb_data\nightly.ls
Get-ChildItem -recurse $Env:root\alpha\home\rma* | Select -ExpandProperty FullName >> $pb_data\nightly.ls
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabill101c\data\* | Select -ExpandProperty FullName `
  >> $pb_data\nightly.ls
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabill101c\batch\* | Select -ExpandProperty FullName `
  >> $pb_data\nightly.ls
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabill101c\cmd\* | Select -ExpandProperty FullName `
  >> $pb_data\nightly.ls
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabill101c\doc\* | Select -ExpandProperty FullName `
  >> $pb_data\nightly.ls
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabill101c\use\* | Select -ExpandProperty FullName `
  >> $pb_data\nightly.ls
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabill101c\src\* | Select -ExpandProperty FullName `
  >> $pb_data\nightly.ls
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabill101c\data2\* | Select -ExpandProperty FullName `
  >> $pb_data\nightly.ls
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabill101c\dvlp\* | Select -ExpandProperty FullName `
  >> $pb_data\nightly.ls
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabill101c\obj\* | Select -ExpandProperty FullName `
  >> $pb_data\nightly.ls
Get-ChildItem -recurse $Env:root\macros\* | Select -ExpandProperty FullName >> $pb_data\nightly.ls
Get-ChildItem -recurse $Env:root\etc\* | Select -ExpandProperty FullName >> $pb_data\nightly.ls
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabill101\dvlp\* | Select -ExpandProperty FullName `
  >> $pb_data\nightly.ls
#find /alpha/rmabill/rmabill81y2k/data/*       -print >> $pb_data/nightly.ls 
#find /alpha/rmabill/rmabill81y2k/data2/*      -print >> $pb_data/nightly.ls 
#find /alpha/rmabill/rmabill81y2k/dvlp/*       -print >> $pb_data/nightly.ls  
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabillicu\data\* | Select -ExpandProperty FullName `
  >> $pb_data\nightly.ls
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabillicu\data2\* | Select -ExpandProperty FullName `
  >> $pb_data\nightly.ls
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabillicu\dvlp\* | Select -ExpandProperty FullName `
  >> $pb_data\nightly.ls
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabillmp\dvlp\* | Select -ExpandProperty FullName >> $pb_data\nightly.ls
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabillmp\data\* | Select -ExpandProperty FullName >> $pb_data\nightly.ls
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabillmp\data2\* | Select -ExpandProperty FullName `
  >> $pb_data\nightly.ls
echo ""
echo ""
Get-Date

echo "Starting copy of file to tape ..."
Set-Location $env:application_root
Get-Location
echo "before cat"
# CONVERSION ERROR (expected, #132): tape device is involved.
# cat data/nightly.ls  | cpio -ocuvB > /dev/rmt/1
echo "after cat"
# set flag that indicates job finished successfully
utouch backup_nightly.flg
echo "after touch"
echo " "
Get-Date
echo "DONE!"


#  ***** IF NEW Daily BACKUP ADDED UPDATE BACKUP_DAILY_to_disk  ALSO

echo ""
Get-Date
echo ""

# CONVERSION ERROR (expected, #148): tape device is involved.
# mt -f /dev/rmt/1 rewind
