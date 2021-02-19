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

Set-Location $env:application_production

Remove-Item r004  -EA SilentlyContinue
Remove-Item r005  -EA SilentlyContinue
Remove-Item r011  -EA SilentlyContinue
Remove-Item r011mohr*  -EA SilentlyContinue
Remove-Item r012  -EA SilentlyContinue
Remove-Item r013  -EA SilentlyContinue
Remove-Item r051ca  -EA SilentlyContinue
Remove-Item r051cb  -EA SilentlyContinue
Remove-Item r070  -EA SilentlyContinue
Remove-Item r070_22  -EA SilentlyContinue
Remove-Item r120*  -EA SilentlyContinue
Remove-Item r123*  -EA SilentlyContinue
Remove-Item r123a*  -EA SilentlyContinue
Remove-Item r123b*  -EA SilentlyContinue
Remove-Item r123c*  -EA SilentlyContinue
Remove-Item r123ef  -EA SilentlyContinue
Remove-Item r124b*  -EA SilentlyContinue
Remove-Item r111b*  -EA SilentlyContinue
Remove-Item r119*  -EA SilentlyContinue
Remove-Item r119a*  -EA SilentlyContinue
Remove-Item r119b*  -EA SilentlyContinue
Remove-Item r119c*  -EA SilentlyContinue
Remove-Item r121*  -EA SilentlyContinue
Remove-Item r121a*  -EA SilentlyContinue
Remove-Item r121b*  -EA SilentlyContinue
Remove-Item r121c*  -EA SilentlyContinue
Remove-Item r121d*  -EA SilentlyContinue
Remove-Item r210  -EA SilentlyContinue
Remove-Item r211  -EA SilentlyContinue
Remove-Item f002_claims_history_tape_file  -EA SilentlyContinue
Remove-Item filer001*  -EA SilentlyContinue
Remove-Item *sort*.tmp  -EA SilentlyContinue
Remove-Item *debug*  -EA SilentlyContinue
Remove-Item sub905*  -EA SilentlyContinue
Remove-Item work_file_a  -EA SilentlyContinue
Remove-Item subfile.ls  -EA SilentlyContinue
Remove-Item hold.ls  -EA SilentlyContinue
Remove-Item utl00013*.txt  -EA SilentlyContinue
Remove-Item utl00013*.sf*  -EA SilentlyContinue
Remove-Item r030g*.sf*  -EA SilentlyContinue
Remove-Item r030g*.txt*  -EA SilentlyContinue
