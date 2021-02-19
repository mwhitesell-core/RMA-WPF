#-------------------------------------------------------------------------------
# File 'r134_r135_portal.bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'r134_r135_portal.bk1'
#-------------------------------------------------------------------------------

# 2015/Jan/29   MC      r134_r135_portal 

Set-Location $env:application_root\production

Remove-Item r134*, r135*

&$env:QUIZ r134 20140701 20150630 > r134_r135.log
&$env:QUIZ r135 20140701 20150630 >> r134_r135.log


echo "Rename r134 and r135 reports to portal"
Move-Item -Force r134.txt r134_portal.txt
Move-Item -Force r135.txt r135_portal.txt
