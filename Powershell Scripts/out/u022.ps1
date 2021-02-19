#-------------------------------------------------------------------------------
# File 'u022.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'u022'
#-------------------------------------------------------------------------------

# U022
# 99/dev/14 B.E. - added backup of u020a1_resubmits.sf
# 02/juan/07 B.E. - removed deletion of u022a subfile
param(
    [string]$1,
    [string]$2
     )

Set-Location $env:application_production
echo "RESUBMITS IN PROGRESS $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

Remove-Item u022_tp.sf*
Remove-Item u022a?.sf*
Remove-Item u022e?.sf*
Remove-Item ru022a
Remove-Item ru022b
Remove-Item ru022
Remove-Item ru022mr

$rcmd = $env:QTP +"u022a1 ${1} ${2}"
Invoke-Expression $rcmd
#$rcmd = $env:QUIZ +"r022a1"
#Invoke-Expression $rcmd
$rcmd = $env:QUIZ +"r022a2"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ +"r022a3"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ +"r022a4"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ +"r022a5"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ +"r022a6"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r022a6.txt > ru022.txt

$rcmd = $env:QUIZ +"r022a7"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ +"r022a8"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ +"r022a9"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r022a9.txt > ru022mr.txt

$rcmd = $env:QUIZ +"r022d"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r022d.txt > ru022a.txt

$rcmd = $env:QUIZ +"r022e1"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ +"r022e2"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ +"r022e3"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ +"r022e4"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ +"r022e5"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ +"r022e6"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r022e5.txt > ru022b.txt
Get-Content r022e6.txt >> ru022b.txt

# save resubmit subfile for debugging purposes
Copy-Item u022a1.sf u022a1_resubmits.sf
Copy-Item u022a1.sfd u022a1_resubmits.sfd
Copy-Item u022a1_audit.sf u022a1_audit_resubmits.sf
Copy-Item u022a1_audit.sfd u022a1_audit_resubmits.sfd

$rcmd = $env:QTP +"u022b"
Invoke-Expression $rcmd

$rcmd = $env:QTP +"u022c"
Invoke-Expression $rcmd

Move-Item -Force ru022a.txt ru022a
Move-Item -Force ru022b.txt ru022b
Move-Item -Force ru022.txt ru022
Move-Item -Force ru022mr.txt ru022mr_before

#lp ru022
#lp ru022b
#lp ru022_sd
#lp ru022b_sd

Move-Item -Force u020_tp.sf u022_tp.sf
Move-Item -Force u020_tp.sfd u022_tp.sfd

Set-Location $env:pb_data
Remove-Item resubmit.required
Set-Location $env:application_production

##  regenerate ru022mr for correct report
$rcmd = $env:QUIZ +"r022a7"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ +"r022a8"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ +"r022a9"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r022a9.txt > ru022mr.txt

Move-Item -Force ru022mr.txt ru022mr

echo "ENDING RESUBMIT RUN $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
