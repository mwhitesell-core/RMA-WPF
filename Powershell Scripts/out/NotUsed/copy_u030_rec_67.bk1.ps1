#-------------------------------------------------------------------------------
# File 'copy_u030_rec_67.bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'copy_u030_rec_67.bk1'
#-------------------------------------------------------------------------------

# macro: copy_u030_rec_67
# 07/Feb/08 M.C. copy all u030-tape-67-file from each clinic directory into production
# 2009/Jul/09 Yas. - Added clinics 78 79 and 88

Set-Location $env:application_production
Remove-Item r031a_agep.sf* 2> $null
&$env:QUIZ r031a_agep 22

echo "Current Directory:"
Get-Location

echo ""
echo "append 67  file from each clinic into production r031_agep subfile"
echo ""

Set-Location $env:application_production\23
Remove-Item r031a_agep.sf* 2> $null
&$env:QUIZ r031a_agep 23

Set-Location $env:application_production\24
Remove-Item r031a_agep.sf* 2> $null
&$env:QUIZ r031a_agep 24

Set-Location $env:application_production\25
Remove-Item r031a_agep.sf* 2> $null
&$env:QUIZ r031a_agep 25

Set-Location $env:application_production\31
Remove-Item r031a_agep.sf* 2> $null
&$env:QUIZ r031a_agep 31

Set-Location $env:application_production\32
Remove-Item r031a_agep.sf* 2> $null
&$env:QUIZ r031a_agep 32

Set-Location $env:application_production\33
Remove-Item r031a_agep.sf* 2> $null
&$env:QUIZ r031a_agep 33

Set-Location $env:application_production\34
Remove-Item r031a_agep.sf* 2> $null
&$env:QUIZ r031a_agep 34

Set-Location $env:application_production\35
Remove-Item r031a_agep.sf* 2> $null
&$env:QUIZ r031a_agep 35

Set-Location $env:application_production\36
Remove-Item r031a_agep.sf* 2> $null
&$env:QUIZ r031a_agep 36

Set-Location $env:application_production\37
Remove-Item r031a_agep.sf* 2> $null
&$env:QUIZ r031a_agep 37

Set-Location $env:application_production\41
Remove-Item r031a_agep.sf* 2> $null
&$env:QUIZ r031a_agep 41

Set-Location $env:application_production\42
Remove-Item r031a_agep.sf* 2> $null
&$env:QUIZ r031a_agep 42

Set-Location $env:application_production\43
Remove-Item r031a_agep.sf* 2> $null
&$env:QUIZ r031a_agep 43

Set-Location $env:application_production\44
Remove-Item r031a_agep.sf* 2> $null
&$env:QUIZ r031a_agep 44

Set-Location $env:application_production\45
Remove-Item r031a_agep.sf* 2> $null
&$env:QUIZ r031a_agep 45

Set-Location $env:application_production\46
Remove-Item r031a_agep.sf* 2> $null
&$env:QUIZ r031a_agep 46

Set-Location $env:application_production\61
Remove-Item r031a_agep.sf* 2> $null
&$env:QUIZ r031a_agep 61

Set-Location $env:application_production\62
Remove-Item r031a_agep.sf* 2> $null
&$env:QUIZ r031a_agep 62

Set-Location $env:application_production\63
Remove-Item r031a_agep.sf* 2> $null
&$env:QUIZ r031a_agep 63

Set-Location $env:application_production\64
Remove-Item r031a_agep.sf* 2> $null
&$env:QUIZ r031a_agep 64

Set-Location $env:application_production\65
Remove-Item r031a_agep.sf* 2> $null
&$env:QUIZ r031a_agep 65

Set-Location $env:application_production\66
Remove-Item r031a_agep.sf* 2> $null
&$env:QUIZ r031a_agep 66

Set-Location $env:application_production\71
Remove-Item r031a_agep.sf* 2> $null
&$env:QUIZ r031a_agep 71

Set-Location $env:application_production\72
Remove-Item r031a_agep.sf* 2> $null
&$env:QUIZ r031a_agep 72

Set-Location $env:application_production\73
Remove-Item r031a_agep.sf* 2> $null
&$env:QUIZ r031a_agep 73

Set-Location $env:application_production\74
Remove-Item r031a_agep.sf* 2> $null
&$env:QUIZ r031a_agep 74

Set-Location $env:application_production\75
Remove-Item r031a_agep.sf* 2> $null
&$env:QUIZ r031a_agep 75

Set-Location $env:application_production\78
Remove-Item r031a_agep.sf* 2> $null
&$env:QUIZ r031a_agep 78

Set-Location $env:application_production\79
Remove-Item r031a_agep.sf* 2> $null
&$env:QUIZ r031a_agep 79

Set-Location $env:application_production\84
Remove-Item r031a_agep.sf* 2> $null
&$env:QUIZ r031a_agep 84

Set-Location $env:application_production\88
Remove-Item r031a_agep.sf* 2> $null
&$env:QUIZ r031a_agep 88

Set-Location $env:application_production\96
Remove-Item r031a_agep.sf* 2> $null
&$env:QUIZ r031a_agep 96


Set-Location $env:application_production
&$env:QUIZ r031b_agep

echo ""
echo "end of the run"
echo ""
Get-Date
