#-------------------------------------------------------------------------------
# File 'backup_nightly_to_dyadORIG.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_nightly_to_dyadORIG'
#-------------------------------------------------------------------------------

echo "BACKUP_NIGHTLY_TO_DYAD"
# 2005/jul/18 b.e. added backup of obj and cmd in rmabill mp
echo ""

echo ""
echo "BACKUP NOW COMMENCING ..."
echo ""
echo ""
Get-Date
echo ""

Set-Location $env:application_root
# remove flag that indicates job finished successfully
Remove-Item backup_nightly_to_dyad.flg *> $null

Get-Location
Get-ChildItem production\moh*, production\yasemin\*, production\web\*, production\web1\*, production\web2\*, `
  production\web3\*, production\web4\*, production\web5\*, production\web6\*, production\web7\*, production\web8\*, `
  production\web9\*, production\web10\*, production\diskette\*, production\diskette1\*, production\stone\*, `
  production\kathy\*, production\mumc\*, production\60\*parm*, production\70\*parm*, production\80\*parm*, `
  production\81\*parm*, production\82\*parm*, production\83\*parm*, production\85\*parm*, production\86\*parm*, `
  production\91\*parm*, production\92\*parm*, production\93\*parm*, production\94\*parm*, production\95\*parm*, `
  production\96\*parm*, production\98\*parm*, production\*parm*, production\aug14*, production\oct13*, `
  production\sep16*, production\f002_suspend*, production\u010*, production\*u993*, production\icuapp*, `
  production\r010*, production\f086*, obj\* > data\nightly_to_dyad.ls
echo ""
echo ""
Get-Date


echo "Finding directories with sub directories and files..."
Set-Location $Env:root\
Get-Location
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabill101c\src\* | Select -ExpandProperty FullName `
  >> $pb_data\nightly_to_dyad.ls
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabill101c\obj\* | Select -ExpandProperty FullName `
  >> $pb_data\nightly_to_dyad.ls
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabill101c\use\* | Select -ExpandProperty FullName `
  >> $pb_data\nightly_to_dyad.ls
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabill101c\batch\* | Select -ExpandProperty FullName `
  >> $pb_data\nightly_to_dyad.ls
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabill101c\cmd\* | Select -ExpandProperty FullName `
  >> $pb_data\nightly_to_dyad.ls
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabill101c\doc\* | Select -ExpandProperty FullName `
  >> $pb_data\nightly_to_dyad.ls
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabill101c\dvlp\* | Select -ExpandProperty FullName `
  >> $pb_data\nightly_to_dyad.ls
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabill101c\backups\*.ls | Select -ExpandProperty FullName `
  >> $pb_data\nightly_to_dyad.ls
Get-ChildItem -recurse $Env:root\alpha\home\rma* | Select -ExpandProperty FullName >> $pb_data\nightly_to_dyad.ls
Get-ChildItem -recurse $Env:root\macros\* | Select -ExpandProperty FullName >> $pb_data\nightly_to_dyad.ls
Get-ChildItem -recurse $Env:root\etc\* | Select -ExpandProperty FullName >> $pb_data\nightly_to_dyad.ls
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabill101\dvlp\* | Select -ExpandProperty FullName `
  >> $pb_data\nightly_to_dyad.ls
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabill101\src\* | Select -ExpandProperty FullName `
  >> $pb_data\nightly_to_dyad.ls
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabillicu\dvlp\* | Select -ExpandProperty FullName `
  >> $pb_data\nightly_to_dyad.ls
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabillmp\dvlp\* | Select -ExpandProperty FullName `
  >> $pb_data\nightly_to_dyad.ls
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabillmp\src\* | Select -ExpandProperty FullName `
  >> $pb_data\nightly_to_dyad.ls
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabillmp\cmd\* | Select -ExpandProperty FullName `
  >> $pb_data\nightly_to_dyad.ls
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabillmp\obj\* | Select -ExpandProperty FullName `
  >> $pb_data\nightly_to_dyad.ls
echo ""
echo ""
Get-Date

echo "Starting copy of file to tape ..."
Set-Location $env:application_root
Get-Location
echo "before cat"
# CONVERSION ERROR (expected, #97): piping to cpio.
# cat data/nightly_to_dyad.ls  | cpio -ocuvB > /dyad/backup_transfer_area/backup_nightly.cpio
echo "after cat"
# set flag that indicates job finished successfully
utouch backup_nightly_to_dyad.flg
echo "after touch"
echo " "
Get-Date
echo "DONE!"

echo ""
Get-Date
echo ""
