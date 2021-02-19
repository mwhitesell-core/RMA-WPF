#-------------------------------------------------------------------------------
# File 'cleanup_22_monthend.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'cleanup_22_monthend'
#-------------------------------------------------------------------------------

echo "********************************************************************"

echo "THIS PROGRAM WILL DELETE THE CLINIC 22 MONTHEND REPORTS"
echo "MAKE SURE ALL THE REPORTS ARE PRINTED AND COPY MAG TAPE IS RUN"
echo "IT ALSO DELETES +.PS FILES FOR SHARI MAKE SURE THEY ARE ON DISKETTE"
echo ""
echo "********************************************************************"
echo ""
echo "**** HIT NEW LINE TO CONTINUE ****"
$garbage = Read-Host

Set-Location $application_production

Remove-Item r004  > $null
Remove-Item r005  > $null
Remove-Item r011  > $null
Remove-Item r011mohr*  > $null
Remove-Item r012  > $null
Remove-Item r013  > $null
Remove-Item r051ca  > $null
Remove-Item r051cb  > $null
Remove-Item r070  > $null
Remove-Item r070_22  > $null
Remove-Item r120*  > $null
Remove-Item r123*  > $null
Remove-Item r123a*  > $null
Remove-Item r123b*  > $null
Remove-Item r123c*  > $null
Remove-Item r123ef  > $null
Remove-Item r124b*  > $null
Remove-Item r111b*  > $null
Remove-Item r119*  > $null
Remove-Item r119a*  > $null
Remove-Item r119b*  > $null
Remove-Item r119c*  > $null
Remove-Item r121*  > $null
Remove-Item r121a*  > $null
Remove-Item r121b*  > $null
Remove-Item r121c*  > $null
Remove-Item r121d*  > $null
Remove-Item r210  > $null
Remove-Item r211  > $null
Remove-Item f002_claims_history_tape_file  > $null
Remove-Item filer001*  > $null
Remove-Item *sort*.tmp  > $null
Remove-Item *debug*  > $null
Remove-Item sub905*  > $null
Remove-Item work_file_a  > $null
Remove-Item subfile.ls  > $null
Remove-Item hold.ls  > $null
Remove-Item utl00013*.txt  > $null
Remove-Item utl00013*.sf*  > $null
Remove-Item r030g*.sf*  > $null
Remove-Item r030g*.txt*  > $null
