#-------------------------------------------------------------------------------
# File 'r997_ph_portal_all_clinics.ps1'
# Converted to PowerShell by CORE Migration on 2017-10-01 10:16:47
# Original file name was 'r997_ph_portal_all_clinics'
#-------------------------------------------------------------------------------

echo " --- r997_portal (PH) --- "

Set-Location $env:application_production
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_22.txt

Set-Location $env:application_production\23
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_23.txt

Set-Location $env:application_production\24
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_24.txt

Set-Location $env:application_production\25
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_25.txt

Set-Location $env:application_production\26
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_26.txt

Set-Location $env:application_production\30
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_30.txt

Set-Location $env:application_production\31
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_31.txt

Set-Location $env:application_production\32
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_32.txt

Set-Location $env:application_production\33
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_33.txt

Set-Location $env:application_production\34
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_34.txt

Set-Location $env:application_production\35
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_35.txt

Set-Location $env:application_production\36
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_36.txt

Set-Location $env:application_production\37
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_37.txt

Set-Location $env:application_production\41
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_41.txt

Set-Location $env:application_production\42
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_42.txt

Set-Location $env:application_production\43
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_43.txt

Set-Location $env:application_production\44
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_44.txt

Set-Location $env:application_production\45
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_45.txt

Set-Location $env:application_production\46
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_46.txt

#cd $application_production/48
#cp u997_good_srt.sf u997_good_srt_bkp.sf
#cat u997_rmb_srt.sf >> u997_good_srt.sf

#quiz << R997_EXIT  > r997_portal.log
#exec $obj/r997_portal_a
#exec $obj/r997_portal_b
#R997_EXIT
#mv r997_portal.txt r997_portal_48.txt


Set-Location $env:application_production\61
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_61.txt

Set-Location $env:application_production\62
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf


$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_62.txt


Set-Location $env:application_production\63
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_63.txt


Set-Location $env:application_production\64
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_64.txt


Set-Location $env:application_production\65
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_65.txt

Set-Location $env:application_production\66
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_66.txt

Set-Location $env:application_production\68
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_68.txt

Set-Location $env:application_production\69
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_69.txt

Set-Location $env:application_production\71
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_71.txt

Set-Location $env:application_production\72
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_72.txt

Set-Location $env:application_production\73
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_73.txt

Set-Location $env:application_production\74
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_74.txt

Set-Location $env:application_production\75
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_75.txt

Set-Location $env:application_production\78
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_78.txt

Set-Location $env:application_production\79
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_79.txt

Set-Location $env:application_production\80
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_80.txt


Set-Location $env:application_production\82
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_82.txt


#cd $application_production/83
#cp u997_good_srt.sf u997_good_srt_bkp.sf
#cat u997_rmb_srt.sf >> u997_good_srt.sf

#quiz << R997_EXIT  > r997_portal.log
#exec $obj/r997_portal_a
#exec $obj/r997_portal_b
#R997_EXIT
#mv r997_portal.txt r997_portal_83.txt


Set-Location $env:application_production\84
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_84.txt


Set-Location $env:application_production\86
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt
Move-Item -Force r997_portal.txt r997_portal_86.txt

Set-Location $env:application_production\87
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_87.txt

Set-Location $env:application_production\88
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_88.txt

Set-Location $env:application_production\89
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_89.txt

Set-Location $env:application_production\91
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_91.txt


Set-Location $env:application_production\92
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_92.txt


Set-Location $env:application_production\93
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_93.txt


Set-Location $env:application_production\94
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_94.txt


Set-Location $env:application_production\95
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_95.txt


Set-Location $env:application_production\96
Copy-Item u997_good_srt.sf u997_good_srt_bkp.sf
Add-Content -path u997_good_srt.sf -value ""
Get-Content u997_rmb_srt.sf | Add-Content u997_good_srt.sf

$rcmd = $env:QUIZ + "r997_portal_a"
invoke-expression $rcmd > r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_a.txt > r997_portal.txt

$rcmd = $env:QUIZ + "r997_portal_b"
invoke-expression $rcmd >> r997_portal.log

#Core - Added to rename report according to quiz file
Get-Content r997_portal_b.txt > r997_portal_total.txt

Move-Item -Force r997_portal.txt r997_portal_96.txt

echo "Done!"
