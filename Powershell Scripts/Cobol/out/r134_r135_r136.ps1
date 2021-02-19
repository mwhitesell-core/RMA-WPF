#-------------------------------------------------------------------------------
# File 'r134_r135_r136.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'r134_r135_r136'
#-------------------------------------------------------------------------------

# 2015/Apr/15   MC      r134_r135_r136   
#                       include the parameter 'REGULAR' and 'PORTAL' to run r134 & r135 twice
#                       include the run of r136.qtc/qzc at then end

Set-Location $application_root\production

echo "Start  -$(udate)"

Remove-Item r134*txt, r135*txt, r136*txt, r134.sf*, r135.sf*  > $null

echo "Running r134_r135_portal -$(udate)"
echo ""

$cmd\r134_r135_portal  > r134_r135_portal.log

echo "Rename  r134_r135_portal -$(udate)"
echo ""

echo "Rename r134 and r135 reports to portal"  >> r134_r135_portal.log
Move-Item r134.txt r134_portal.txt
Move-Item r135.txt r135_portal.txt

echo "Running r134_r135_regular -$(udate)"
echo ""

$cmd\r134_r135_regular  > r134_r135_regular.log

echo "Running r136   -$(udate)"
echo ""

$cmd\r136  > r136.log

echo "Finish -$(udate)"