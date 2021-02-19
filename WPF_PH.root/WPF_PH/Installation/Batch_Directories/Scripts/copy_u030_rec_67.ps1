#-------------------------------------------------------------------------------
# File 'copy_u030_rec_67.ps1'
# Converted to PowerShell by CORE Migration on 2017-10-01 10:16:47
# Original file name was 'copy_u030_rec_67'
#-------------------------------------------------------------------------------

# macro: copy_u030_rec_67
# 07/Feb/08 M.C. copy all u030-tape-67-file from each clinic directory into production
# 2009/Jul/09 Yas. - Added clinics 78 79 and 88
# 2013/May/16 MC1  - exec $obj/r031b_agep.qzu for 2 passes instead of $obj/r031b_agep.qzc

Set-Location $env:application_production
Remove-Item r031a_agep.sf* 2> $null
$rcmd = $env:QUIZ + "r031a_agep 22"
invoke-expression $rcmd

echo "Current Directory:"
Get-Location

echo ""
echo "append 67  file from each clinic into production r031_agep subfile"
echo ""

Set-Location $env:application_production\23
Remove-Item r031a_agep.sf* 2> $null
$rcmd = $env:QUIZ + "r031a_agep 23"
invoke-expression $rcmd


Set-Location $env:application_production\24
Remove-Item r031a_agep.sf* 2> $null
$rcmd = $env:QUIZ + "r031a_agep 24"
invoke-expression $rcmd

Set-Location $env:application_production\25
Remove-Item r031a_agep.sf* 2> $null
$rcmd = $env:QUIZ + "r031a_agep 25"
invoke-expression $rcmd

Set-Location $env:application_production\26
Remove-Item r031a_agep.sf* 2> $null
$rcmd = $env:QUIZ + "r031a_agep 26"
invoke-expression $rcmd

Set-Location $env:application_production\30
Remove-Item r031a_agep.sf* 2> $null
$rcmd = $env:QUIZ + "r031a_agep 30"
invoke-expression $rcmd

Set-Location $env:application_production\31
Remove-Item r031a_agep.sf* 2> $null
$rcmd = $env:QUIZ + "r031a_agep 31"
invoke-expression $rcmd
Set-Location $env:application_production\32
Remove-Item r031a_agep.sf* 2> $null
$rcmd = $env:QUIZ + "r031a_agep 32"
invoke-expression $rcmd

Set-Location $env:application_production\33
Remove-Item r031a_agep.sf* 2> $null
$rcmd = $env:QUIZ + "r031a_agep 33"
invoke-expression $rcmd

Set-Location $env:application_production\34
Remove-Item r031a_agep.sf* 2> $null
$rcmd = $env:QUIZ + "r031a_agep 34"
invoke-expression $rcmd

Set-Location $env:application_production\35
Remove-Item r031a_agep.sf* 2> $null
$rcmd = $env:QUIZ + "r031a_agep 35"
invoke-expression $rcmd

Set-Location $env:application_production\36
Remove-Item r031a_agep.sf* 2> $null
$rcmd = $env:QUIZ + "r031a_agep 36"
invoke-expression $rcmd

Set-Location $env:application_production\37
Remove-Item r031a_agep.sf* 2> $null
$rcmd = $env:QUIZ + "r031a_agep 37"
invoke-expression $rcmd

Set-Location $env:application_production\41
Remove-Item r031a_agep.sf* 2> $null
$rcmd = $env:QUIZ + "r031a_agep 41"
invoke-expression $rcmd

Set-Location $env:application_production\42
Remove-Item r031a_agep.sf* 2> $null
$rcmd = $env:QUIZ + "r031a_agep 42"
invoke-expression $rcmd

Set-Location $env:application_production\43
Remove-Item r031a_agep.sf* 2> $null
$rcmd = $env:QUIZ + "r031a_agep 43"
invoke-expression $rcmd

Set-Location $env:application_production\44
Remove-Item r031a_agep.sf* 2> $null
$rcmd = $env:QUIZ + "r031a_agep 44"
invoke-expression $rcmd

Set-Location $env:application_production\45
Remove-Item r031a_agep.sf* 2> $null
$rcmd = $env:QUIZ + "r031a_agep 45"
invoke-expression $rcmd

Set-Location $env:application_production\46
Remove-Item r031a_agep.sf* 2> $null
$rcmd = $env:QUIZ + "r031a_agep 46"
invoke-expression $rcmd

Set-Location $env:application_production\61
Remove-Item r031a_agep.sf* 2> $null
$rcmd = $env:QUIZ + "r031a_agep 61"
invoke-expression $rcmd

Set-Location $env:application_production\62
Remove-Item r031a_agep.sf* 2> $null
$rcmd = $env:QUIZ + "r031a_agep 62"
invoke-expression $rcmd

Set-Location $env:application_production\63
Remove-Item r031a_agep.sf* 2> $null
$rcmd = $env:QUIZ + "r031a_agep 63"
invoke-expression $rcmd

Set-Location $env:application_production\64
Remove-Item r031a_agep.sf* 2> $null
$rcmd = $env:QUIZ + "r031a_agep 64"
invoke-expression $rcmd

Set-Location $env:application_production\65
Remove-Item r031a_agep.sf* 2> $null
$rcmd = $env:QUIZ + "r031a_agep 65"
invoke-expression $rcmd

Set-Location $env:application_production\66
Remove-Item r031a_agep.sf* 2> $null
$rcmd = $env:QUIZ + "r031a_agep 66"
invoke-expression $rcmd

Set-Location $env:application_production\71
Remove-Item r031a_agep.sf* 2> $null
$rcmd = $env:QUIZ + "r031a_agep 71"
invoke-expression $rcmd

Set-Location $env:application_production\72
Remove-Item r031a_agep.sf* 2> $null
$rcmd = $env:QUIZ + "r031a_agep 72"
invoke-expression $rcmd

Set-Location $env:application_production\73
Remove-Item r031a_agep.sf* 2> $null
$rcmd = $env:QUIZ + "r031a_agep 73"
invoke-expression $rcmd

Set-Location $env:application_production\74
Remove-Item r031a_agep.sf* 2> $null
$rcmd = $env:QUIZ + "r031a_agep 74"
invoke-expression $rcmd

Set-Location $env:application_production\75
Remove-Item r031a_agep.sf* 2> $null
$rcmd = $env:QUIZ + "r031a_agep 75"
invoke-expression $rcmd

Set-Location $env:application_production\78
Remove-Item r031a_agep.sf* 2> $null
$rcmd = $env:QUIZ + "r031a_agep 78"
invoke-expression $rcmd

Set-Location $env:application_production\79
Remove-Item r031a_agep.sf* 2> $null
$rcmd = $env:QUIZ + "r031a_agep 79"
invoke-expression $rcmd

Set-Location $env:application_production\84
Remove-Item r031a_agep.sf* 2> $null
$rcmd = $env:QUIZ + "r031a_agep 84"
invoke-expression $rcmd

Set-Location $env:application_production\88
Remove-Item r031a_agep.sf* 2> $null
$rcmd = $env:QUIZ + "r031a_agep 88"
invoke-expression $rcmd

Set-Location $env:application_production\96
Remove-Item r031a_agep.sf* 2> $null
$rcmd = $env:QUIZ + "r031a_agep 96"
invoke-expression $rcmd


Set-Location $env:application_production

"" | Add-Content r031a_agep.sf

Get-Content 23\r031a_agep.sf, 24\r031a_agep.sf, 25\r031a_agep.sf, 26\r031a_agep.sf, 30\r031a_agep.sf, 31\r031a_agep.sf, 32\r031a_agep.sf, 33\r031a_agep.sf,`
34\r031a_agep.sf, 35\r031a_agep.sf, 36\r031a_agep.sf, 37\r031a_agep.sf, 41\r031a_agep.sf, 42\r031a_agep.sf, 43\r031a_agep.sf, 44\r031a_agep.sf,45\r031a_agep.sf,`
46\r031a_agep.sf, 61\r031a_agep.sf, 62\r031a_agep.sf, 63\r031a_agep.sf, 64\r031a_agep.sf, 65\r031a_agep.sf, 66\r031a_agep.sf, 71\r031a_agep.sf, 72\r031a_agep.sf,73\r031a_agep.sf,`
74\r031a_agep.sf, 75\r031a_agep.sf, 78\r031a_agep.sf, 79\r031a_agep.sf, 84\r031a_agep.sf, 88\r031a_agep.sf, 96\r031a_agep.sf | Add-Content r031a_agep.sf

$rcmd = $env:QUIZ + "r031b_agep_1"
invoke-expression $rcmd

$rcmd = $env:QUIZ + "r031b_agep_2"
invoke-expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r031b_agep_1.txt > r031b_agep.txt
Get-Content r031b_agep_2.txt >> r031b_agep.txt

echo ""
echo "end of the run"
echo ""
Get-Date
