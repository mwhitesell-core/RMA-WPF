#-------------------------------------------------------------------------------
# File 'r010.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'r010'
#-------------------------------------------------------------------------------

# 
# 98/jun/29 B.E.        added delete of u010_out_file after processing
# 2001/oct/17 M.C.      convert r010 from cobol to powerhouse  
#

echo "R010 BEGINNING $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

echo "Running r010cycle ..."
Set-Location $env:application_production

Move-Item -Force r010daily_cycle.sf r010cycle.sf
Copy-Item r010daily.sfd r010cycle.sfd
Move-Item -Force extf001aa_cycle.sf extf001aacycle.sf
Copy-Item extf001aa.sfd extf001aacycle.sfd
Move-Item -Force extf001_cycle.sf extf001cycle.sf
Copy-Item extf001.sfd extf001cycle.sfd

$rcmd = $env:QUIZ + "r010cycle_1" 
Invoke-Expression $rcmd >> r010cycle.log
$rcmd = $env:QUIZ + "r010cycle_2" 
Invoke-Expression $rcmd >> r010cycle.log
$rcmd = $env:QUIZ + "r010cycle_3" 
Invoke-Expression $rcmd >> r010cycle.log
$rcmd = $env:QUIZ + "r010cycle_4" 
Invoke-Expression $rcmd >> r010cycle.log

#Core - Added to rename report according to quiz file
Get-Content r010cycle_1.txt | Set-Content r010cycle.txt
Get-Content r010cycle_2.txt | Add-Content r010cycle.txt
Get-Content r010cycle_3.txt | Add-Content r010cycle.txt
Get-Content r010cycle_4.txt | Add-Content r010cycle.txt

#lp r010cycle.txt

echo "R010 ENDING $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
