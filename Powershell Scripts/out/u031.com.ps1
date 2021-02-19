#-------------------------------------------------------------------------------
# File 'u031.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-10-01 10:16:47
# Original file name was 'u031.com'
#-------------------------------------------------------------------------------

# process AGEP payments from u030-tape-8-file RA file
# 2006/nov/06 b.e. - added multi-clinic processing
# 2009/Mar/05 yas  - added clinics 37 and 84      
# 2009/Mar/26 yas  - added clinics 61-65 and 71-75
# 2009/Apr/09 M.C. - change to 'rm r031a.txt' instead of 'rm r031*'
# 2009/Jul/09 Yas. - Added clinics 78 79 and 88
# 2010/Feb/10 Yas. - Add clinc 66 same as 61-65 
# 2011/Jan/11 Yas. - Add clinc 23 same as 22    
# 2012/Jan/23 Yas. - Add clinc 24 same as 22    
# 2012/Jun/08 Yas. - Add clinc 25 same as 22    
# 2014/Oct/17 Yas. - Add clinc 30 same as 31               
# 2015/Mar/10 Yas. - Add clinc 26 same as 23

Push-Location
echo ""
echo "Processing clinic 22 ..."
Set-Location $env:pb_prod
Remove-Item r031a.txt
$rcmd = $env:QUIZ+"r031a"
Invoke-Expression $rcmd
echo ""
echo ""

echo "Processing clinic 23 ..."
Set-Location $env:pb_prod\23
Remove-Item r031a.txt
$rcmd = $env:QUIZ+"r031a"
Invoke-Expression $rcmd
echo ""
echo ""

echo "Processing clinic 24 ..."
Set-Location $env:pb_prod\24
Remove-Item r031a.txt
$rcmd = $env:QUIZ+"r031a"
Invoke-Expression $rcmd
echo ""
echo ""

echo "Processing clinic 25 ..."
Set-Location $env:pb_prod\25
Remove-Item r031a.txt
$rcmd = $env:QUIZ+"r031a"
Invoke-Expression $rcmd
echo ""
echo ""

echo "Processing clinic 26 ..."
Set-Location $env:pb_prod\26
Remove-Item r031a.txt
$rcmd = $env:QUIZ+"r031a"
Invoke-Expression $rcmd
echo ""
echo ""

echo "Processing clinic 30 ..."
Set-Location $env:pb_prod\30
Remove-Item r031a.txt
$rcmd = $env:QUIZ+"r031a"
Invoke-Expression $rcmd
echo ""
echo ""

echo "Processing clinic 31 ..."
Set-Location $env:pb_prod\31
Remove-Item r031a.txt
$rcmd = $env:QUIZ+"r031a"
Invoke-Expression $rcmd
echo ""
echo ""

echo "Processing clinic 32 ..."
Set-Location $env:pb_prod\32
Remove-Item r031a.txt
$rcmd = $env:QUIZ+"r031a"
Invoke-Expression $rcmd
echo ""
echo ""

echo "Processing clinic 33 ..."
Set-Location $env:pb_prod\33
Remove-Item r031a.txt
$rcmd = $env:QUIZ+"r031a"
Invoke-Expression $rcmd
echo ""
echo ""

echo "Processing clinic 34 ..."
Set-Location $env:pb_prod\34
Remove-Item r031a.txt
$rcmd = $env:QUIZ+"r031a"
Invoke-Expression $rcmd
echo ""
echo ""

echo "Processing clinic 35 ..."
Set-Location $env:pb_prod\35
Remove-Item r031a.txt
$rcmd = $env:QUIZ+"r031a"
Invoke-Expression $rcmd
echo ""
echo ""

echo "Processing clinic 36 ..."
Set-Location $env:pb_prod\36
Remove-Item r031a.txt
$rcmd = $env:QUIZ+"r031a"
Invoke-Expression $rcmd
echo ""
echo ""

echo "Processing clinic 37 ..."
Set-Location $env:pb_prod\37
Remove-Item r031a.txt
$rcmd = $env:QUIZ+"r031a"
Invoke-Expression $rcmd
echo ""
echo ""

echo "Processing clinic 41 ..."
Set-Location $env:pb_prod\41
Remove-Item r031a.txt
$rcmd = $env:QUIZ+"r031a"
Invoke-Expression $rcmd
echo ""
echo ""

echo "Processing clinic 42 ..."
Set-Location $env:pb_prod\42
Remove-Item r031a.txt
$rcmd = $env:QUIZ+"r031a"
Invoke-Expression $rcmd
echo ""
echo ""

echo "Processing clinic 43 ..."
Set-Location $env:pb_prod\43
Remove-Item r031a.txt
$rcmd = $env:QUIZ+"r031a"
Invoke-Expression $rcmd
echo ""
echo ""

echo "Processing clinic 44 ..."
Set-Location $env:pb_prod\44
Remove-Item r031a.txt
$rcmd = $env:QUIZ+"r031a"
Invoke-Expression $rcmd
echo ""
echo ""

echo "Processing clinic 45 ..."
Set-Location $env:pb_prod\45
Remove-Item r031a.txt
$rcmd = $env:QUIZ+"r031a"
Invoke-Expression $rcmd
echo ""
echo ""

echo "Processing clinic 46 ..."
Set-Location $env:pb_prod\46
Remove-Item r031a.txt
$rcmd = $env:QUIZ+"r031a"
Invoke-Expression $rcmd
echo ""
echo ""

echo "Processing clinic 61 ..."
Set-Location $env:pb_prod\61
Remove-Item r031a.txt
$rcmd = $env:QUIZ+"r031a"
Invoke-Expression $rcmd
echo ""
echo ""

echo "Processing clinic 62 ..."
Set-Location $env:pb_prod\62
Remove-Item r031a.txt
$rcmd = $env:QUIZ+"r031a"
Invoke-Expression $rcmd
echo ""
echo ""

echo "Processing clinic 63 ..."
Set-Location $env:pb_prod\63
Remove-Item r031a.txt
$rcmd = $env:QUIZ+"r031a"
Invoke-Expression $rcmd
echo ""
echo ""

echo "Processing clinic 64 ..."
Set-Location $env:pb_prod\64
Remove-Item r031a.txt
$rcmd = $env:QUIZ+"r031a"
Invoke-Expression $rcmd
echo ""
echo ""

#echo Processing clinic 65 ...
#cd $env:pb_prod/65
#rm r031a.txt
#quiz auto=$obj/r031a.qzc
#echo
#echo

echo "Processing clinic 66 ..."
Set-Location $env:pb_prod\66
Remove-Item r031a.txt
$rcmd = $env:QUIZ+"r031a"
Invoke-Expression $rcmd
echo ""
echo ""

echo "Processing clinic 71 ..."
Set-Location $env:pb_prod\71
Remove-Item r031a.txt
$rcmd = $env:QUIZ+"r031a"
Invoke-Expression $rcmd
echo ""
echo ""

echo "Processing clinic 72 ..."
Set-Location $env:pb_prod\72
Remove-Item r031a.txt
$rcmd = $env:QUIZ+"r031a"
Invoke-Expression $rcmd
echo ""
echo ""

echo "Processing clinic 73 ..."
Set-Location $env:pb_prod\73
Remove-Item r031a.txt
$rcmd = $env:QUIZ+"r031a"
Invoke-Expression $rcmd
echo ""
echo ""

echo "Processing clinic 74 ..."
Set-Location $env:pb_prod\74
Remove-Item r031a.txt
$rcmd = $env:QUIZ+"r031a"
Invoke-Expression $rcmd
echo ""
echo ""

echo "Processing clinic 75 ..."
Set-Location $env:pb_prod\75
Remove-Item r031a.txt
$rcmd = $env:QUIZ+"r031a"
Invoke-Expression $rcmd
echo ""
echo ""

echo "Processing clinic 78 ..."
Set-Location $env:pb_prod\78
Remove-Item r031a.txt
$rcmd = $env:QUIZ+"r031a"
Invoke-Expression $rcmd
echo ""
echo ""

#echo Processing clinic 79 ...
#cd $env:pb_prod/79
#rm r031a.txt
#quiz auto=$obj/r031a.qzc
#echo
#echo

echo "Processing clinic 84 ..."
Set-Location $env:pb_prod\84
Remove-Item r031a.txt
$rcmd = $env:QUIZ+"r031a"
Invoke-Expression $rcmd
echo ""
echo ""

echo "Processing clinic 88 ..."
Set-Location $env:pb_prod\88
Remove-Item r031a.txt
$rcmd = $env:QUIZ+"r031a"
Invoke-Expression $rcmd
echo ""
echo ""

echo "Processing clinic 96 ..."
Set-Location $env:pb_prod\96
Remove-Item r031a.txt
$rcmd = $env:QUIZ+"r031a"
Invoke-Expression $rcmd
echo ""
echo ""

echo "Done!"

Pop-Location