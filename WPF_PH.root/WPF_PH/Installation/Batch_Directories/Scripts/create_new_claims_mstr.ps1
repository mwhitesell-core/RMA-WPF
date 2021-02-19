#-------------------------------------------------------------------------------
# File 'create_new_claims_mstr.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'create_new_claims_mstr'
#-------------------------------------------------------------------------------

echo "CREATE_NEW_CLAIMS_MSTR"
#  modification history
#  2002/jul/06 B.E. - changed to put orig claim and processing of subifle
#                    on /dyad/purge disk
#  2002/nov/14 M.C. - include clinic 95 as well  
#  2003/Jun/16 yas  - include clinics 91,92,93,94 and 96
#  2005/jul/06 M.C. - changed to put orig claim and processing of subfile
#                     on /charly/purge disk
#  2006/Jun/29 yas  - include clinic 98                     
#  2011/Feb/16 yas  - comment out the printing of the reports
#  2011/Feb/17 MC1  - move the 3 files from /charly to /foxtrot instead as suggested by Brad
#  2011/Feb/22 MC2  - save f002_claims_extra & f085_rejected_claims as well in /foxtrot       
#  2011/Feb/22 yas  - include "claims_mstr_verify_new" in this macro  
#  2011/May/10 MC3  - copy f002_claims_extra & f085_rejected_claims instead of move
#                     unload & reload f002_claims_extra & f085_rejected_claims  
#  2011/Jun/06 MC4  - save f071 & f099 files as well in /foxtrot and  unload & reload f071 & f099 files  
#  2014/Oct/02 MC5  - generate r072_all.txt  for all clinics - run before each individual clinic  
#  2015/Jan/21 yas  - add new group H290 - clinic 30                                                                  
#  2015/Feb/11 MC6  - add f002-outstanding in /foxtrot/purge
#  2015/Jun/25 yas  - add clinic 26  
#  2015/Jun/29 MC7  - move f002-outstanding in  /foxtrot/purge with orig like other files, make correction
#                     on printing r072_all.txt, comment out 'rm *.dat' because create_links.com will 'rm *.dat'

echo ""
echo "A\R FILE PURGE STAGE" # 1

Set-Location $Env:root\charly\purge

&$env:cmd\claims_mstr_verify_old


echo ""
echo "A\R FILE PURGE STAGE" # 2
#echo  NOTE -- THE PREVIOUS STAGE(S) MUST HAVE BEEN RUN !!!
echo ""
echo "CREATE NEW FILE AND MOVEBALANCE-OWING CLAIMS FROM OLD TO NEW FILE"
echo ""
echo "NOTE !!"
echo "NO ONE MUST BE ACCESSING THE CLAIMS FILE !!!"
echo ""
echo ""
echo "CREATING THE NEW CLAIMS MASTER FILE `"F002_CLAIMS_MSTR_NEW`" ..."
echo ""

Set-Location \\$Env:root\charly\purge

echo "CREATING THE NEW CLAIM SHADOW  FILE `"F002_CLAIM_SHADOW_NEW`" ..."
echo ""

echo ""
echo "PROGRAM `"u072`" NOW LOADING ..."

echo "Starting u072 Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

$rcmd = $env:QTP + "u072 20150630"
Invoke-Expression $rcmd

echo "Ending u072 Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

#############################################################################

# MC5

echo "Starting r072a\b\c_all    Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
$rcmd = $env:QUIZ + "r072a_all"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b_all"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c_all"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r072c_all.txt > r072_all.txt

# MC7
##lp r072_all
#lp r072_all.txt

echo "Ending r072a\b\c_all      Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

#############################################################################



echo "Starting u072 split Files Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

$rcmd = $env:QTP + "u072_retain_1"
Invoke-Expression $rcmd
$rcmd = $env:QTP + "u072_retain_2"
Invoke-Expression $rcmd
$rcmd = $env:QTP + "u072_delete_1"
Invoke-Expression $rcmd
$rcmd = $env:QTP + "u072_delete_2"
Invoke-Expression $rcmd

echo "Ending u072 split Files Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"


#############################################################################

# save the original subfiles
Move-Item -Force u072-retain-claim-hdr.sf u072-retain-claim-hdr-orig.sf
Move-Item -Force u072-retain-claim-hdr.sfd u072-retain-claim-hdr-orig.sfd
Move-Item -Force u072-delete-claim-hdr.sf u072-delete-claim-hdr-orig.sf
Move-Item -Force u072-delete-claim-hdr.sfd u072-delete-claim-hdr-orig.sfd

echo "Starting r072_22 to r072_98 reports Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

Copy-Item u072-retain-claim-hdr-22.sf u072-retain-claim-hdr.sf
Copy-Item u072-retain-claim-hdr-22.sfd u072-retain-claim-hdr.sfd
Copy-Item u072-delete-claim-hdr-22.sf u072-delete-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-22.sfd u072-delete-claim-hdr.sfd

$rcmd = $env:QUIZ + "r072a 22"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 22"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ  + "r072d"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ  + "r072e"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_22
Remove-Item r072?.txt
#lp r072_22

Copy-Item u072-retain-claim-hdr-23.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-23.sf u072-delete-claim-hdr.sf

$rcmd = $env:QUIZ + "r072a 23"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 23"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_23
Remove-Item r072?.txt
#lp r072_23

Copy-Item u072-retain-claim-hdr-24.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-24.sf u072-delete-claim-hdr.sf

$rcmd = $env:QUIZ + "r072a 24"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 24"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_24
Remove-Item r072?.txt
#lp r072_24

Copy-Item u072-retain-claim-hdr-25.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-25.sf u072-delete-claim-hdr.sf

$rcmd = $env:QUIZ + "r072a 25"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 25"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_25
Remove-Item r072?.txt
#lp r072_25

Copy-Item u072-retain-claim-hdr-26.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-26.sf u072-delete-claim-hdr.sf

$rcmd = $env:QUIZ + "r072a 26"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 26"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_26
Remove-Item r072?.txt
#lp r072_26


Copy-Item u072-retain-claim-hdr-30.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-30.sf u072-delete-claim-hdr.sf

$rcmd = $env:QUIZ + "r072a 30"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 30"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_30
Remove-Item r072?.txt
#lp r072_30

Copy-Item u072-retain-claim-hdr-31.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-31.sf u072-delete-claim-hdr.sf

$rcmd = $env:QUIZ + "r072a 31"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 31"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_31
Remove-Item r072?.txt
#lp r072_31

Copy-Item u072-retain-claim-hdr-32.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-32.sf u072-delete-claim-hdr.sf

$rcmd = $env:QUIZ + "r072a 32"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 32"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_32
Remove-Item r072?.txt
#lp r072_32

Copy-Item u072-retain-claim-hdr-33.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-33.sf u072-delete-claim-hdr.sf

$rcmd = $env:QUIZ + "r072a 33"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 33"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_33
Remove-Item r072?.txt
#lp r072_33

Copy-Item u072-retain-claim-hdr-34.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-34.sf u072-delete-claim-hdr.sf

$rcmd = $env:QUIZ + "r072a 34"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 34"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd


#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_34
Remove-Item r072?.txt
#lp r072_34

Copy-Item u072-retain-claim-hdr-35.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-35.sf u072-delete-claim-hdr.sf

$rcmd = $env:QUIZ + "r072a 35"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 35"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_35
Remove-Item r072?.txt
#lp r072_35

Copy-Item u072-retain-claim-hdr-36.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-36.sf u072-delete-claim-hdr.sf

$rcmd = $env:QUIZ + "r072a 36"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 36"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_36
Remove-Item r072?.txt
#lp r072_36

Copy-Item u072-retain-claim-hdr-37.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-37.sf u072-delete-claim-hdr.sf

$rcmd = $env:QUIZ + "r072a 37"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 37"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_37
Remove-Item r072?.txt
#lp r072_37

Copy-Item u072-retain-claim-hdr-41.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-41.sf u072-delete-claim-hdr.sf

$rcmd = $env:QUIZ + "r072a 41"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 41"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_41
Remove-Item r072?.txt
#lp r072_41

Copy-Item u072-retain-claim-hdr-42.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-42.sf u072-delete-claim-hdr.sf

$rcmd = $env:QUIZ + "r072a 42"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 42"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_42
Remove-Item r072?.txt
#lp r072_42

Copy-Item u072-retain-claim-hdr-43.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-43.sf u072-delete-claim-hdr.sf

$rcmd = $env:QUIZ + "r072a 43"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 43"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_43
Remove-Item r072?.txt
#lp r072_43

Copy-Item u072-retain-claim-hdr-44.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-44.sf u072-delete-claim-hdr.sf

$rcmd = $env:QUIZ + "r072a 44"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 44"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_44
Remove-Item r072?.txt
#lp r072_44

Copy-Item u072-retain-claim-hdr-45.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-45.sf u072-delete-claim-hdr.sf

$rcmd = $env:QUIZ + "r072a 45"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 45"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_45
Remove-Item r072?.txt
#lp r072_45

Copy-Item u072-retain-claim-hdr-46.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-46.sf u072-delete-claim-hdr.sf

$rcmd = $env:QUIZ + "r072a 46"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 46"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_46
Remove-Item r072?.txt
#lp r072_46

Copy-Item u072-retain-claim-hdr-61.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-61.sf u072-delete-claim-hdr.sf

$rcmd = $env:QUIZ + "r072a 61"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 61"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_61
Remove-Item r072?.txt
#lp r072_61

Copy-Item u072-retain-claim-hdr-62.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-62.sf u072-delete-claim-hdr.sf

$rcmd = $env:QUIZ + "r072a 62"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 62"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_62
Remove-Item r072?.txt
#lp r072_62

Copy-Item u072-retain-claim-hdr-63.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-63.sf u072-delete-claim-hdr.sf

$rcmd = $env:QUIZ + "r072a 63"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 63"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_63
Remove-Item r072?.txt
#lp r072_63

Copy-Item u072-retain-claim-hdr-64.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-64.sf u072-delete-claim-hdr.sf

$rcmd = $env:QUIZ + "r072a 64"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 64"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_64
Remove-Item r072?.txt
#lp r072_64

Copy-Item u072-retain-claim-hdr-65.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-65.sf u072-delete-claim-hdr.sf

$rcmd = $env:QUIZ + "r072a 65"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 65"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_65
Remove-Item r072?.txt
#lp r072_65

Copy-Item u072-retain-claim-hdr-66.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-66.sf u072-delete-claim-hdr.sf

$rcmd = $env:QUIZ + "r072a 66"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 66"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_66
Remove-Item r072?.txt
#lp r072_66

Copy-Item u072-retain-claim-hdr-68.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-68.sf u072-delete-claim-hdr.sf

$rcmd = $env:QUIZ + "r072a 68"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 68"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_68
Remove-Item r072?.txt
#lp r072_68


Copy-Item u072-retain-claim-hdr-69.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-69.sf u072-delete-claim-hdr.sf

$rcmd = $env:QUIZ + "r072a 69"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 69"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_69
Remove-Item r072?.txt
#lp r072_69

Copy-Item u072-retain-claim-hdr-71.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-71.sf u072-delete-claim-hdr.sf

$rcmd = $env:QUIZ + "r072a 71"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 71"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_71
Remove-Item r072?.txt
#lp r072_71

Copy-Item u072-retain-claim-hdr-72.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-72.sf u072-delete-claim-hdr.sf


$rcmd = $env:QUIZ + "r072a 72"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 72"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_72
Remove-Item r072?.txt
#lp r072_72

Copy-Item u072-retain-claim-hdr-73.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-73.sf u072-delete-claim-hdr.sf


$rcmd = $env:QUIZ + "r072a 73"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 73"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_73
Remove-Item r072?.txt
#lp r072_73

Copy-Item u072-retain-claim-hdr-74.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-74.sf u072-delete-claim-hdr.sf


$rcmd = $env:QUIZ + "r072a 74"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 74"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_74
Remove-Item r072?.txt
#lp r072_74

Copy-Item u072-retain-claim-hdr-75.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-75.sf u072-delete-claim-hdr.sf


$rcmd = $env:QUIZ + "r072a 75"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 75"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_75
Remove-Item r072?.txt
#lp r072_75

Copy-Item u072-retain-claim-hdr-78.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-78.sf u072-delete-claim-hdr.sf

$rcmd = $env:QUIZ + "r072a 78"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 78"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_78
Remove-Item r072?.txt
#lp r072_78

Copy-Item u072-retain-claim-hdr-79.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-79.sf u072-delete-claim-hdr.sf

$rcmd = $env:QUIZ + "r072a 79"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 79"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_79
Remove-Item r072?.txt
#lp r072_79

Copy-Item u072-retain-claim-hdr-80.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-80.sf u072-delete-claim-hdr.sf

$rcmd = $env:QUIZ + "r072a 80"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 80"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_80
Remove-Item r072?.txt
#lp r072_80

Copy-Item u072-retain-claim-hdr-82.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-82.sf u072-delete-claim-hdr.sf

$rcmd = $env:QUIZ + "r072a 82"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 82"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_82
Remove-Item r072?.txt
#lp r072_82

Copy-Item u072-retain-claim-hdr-84.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-84.sf u072-delete-claim-hdr.sf

$rcmd = $env:QUIZ + "r072a 84"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 84"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_84
Remove-Item r072?.txt
#lp r072_84

Copy-Item u072-retain-claim-hdr-86.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-86.sf u072-delete-claim-hdr.sf

$rcmd = $env:QUIZ + "r072a 86"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 86"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_86
Remove-Item r072?.txt
#lp r072_86

Copy-Item u072-retain-claim-hdr-87.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-87.sf u072-delete-claim-hdr.sf

$rcmd = $env:QUIZ + "r072a 87"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 87"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_87
Remove-Item r072?.txt
#lp r072_87

Copy-Item u072-retain-claim-hdr-88.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-88.sf u072-delete-claim-hdr.sf

$rcmd = $env:QUIZ + "r072a 88"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 88"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_88
Remove-Item r072?.txt
#lp r072_88

Copy-Item u072-retain-claim-hdr-89.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-89.sf u072-delete-claim-hdr.sf

$rcmd = $env:QUIZ + "r072a 89"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 89"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_89
Remove-Item r072?.txt
#lp r072_89

Copy-Item u072-retain-claim-hdr-91.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-91.sf u072-delete-claim-hdr.sf

$rcmd = $env:QUIZ + "r072a 91"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 91"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_91
Remove-Item r072?.txt
#lp r072_91

Copy-Item u072-retain-claim-hdr-92.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-92.sf u072-delete-claim-hdr.sf


$rcmd = $env:QUIZ + "r072a 92"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 92"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_92
Remove-Item r072?.txt
#lp r072_92

Copy-Item u072-retain-claim-hdr-93.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-93.sf u072-delete-claim-hdr.sf

$rcmd = $env:QUIZ + "r072a 93"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 93"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_93
Remove-Item r072?.txt
#lp r072_93

Copy-Item u072-retain-claim-hdr-94.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-94.sf u072-delete-claim-hdr.sf

$rcmd = $env:QUIZ + "r072a 94"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 94"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_94
Remove-Item r072?.txt
#lp r072_94

Copy-Item u072-retain-claim-hdr-95.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-95.sf u072-delete-claim-hdr.sf

$rcmd = $env:QUIZ + "r072a 95"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 95"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_95
Remove-Item r072?.txt
#lp r072_95

Copy-Item u072-retain-claim-hdr-96.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-96.sf u072-delete-claim-hdr.sf

$rcmd = $env:QUIZ + "r072a 96"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 96"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_96
Remove-Item r072?.txt
#lp r072_96

Copy-Item u072-retain-claim-hdr-98.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-98.sf u072-delete-claim-hdr.sf

$rcmd = $env:QUIZ + "r072a 98"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072b 98"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r072c"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

$rcmd = $env:QUIZ + "r072d"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

$rcmd = $env:QUIZ + "r072e"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_98
Remove-Item r072?.txt
#lp r072_98

echo "Ending r072_22 to r072_98 reports Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

#############################################################################

#  rename the original subfiles before recreating the new claims mstr  

Move-Item -Force u072-retain-claim-hdr-orig.sf u072-retain-claim-hdr.sf
Move-Item -Force u072-retain-claim-hdr-orig.sfd u072-retain-claim-hdr.sfd
Move-Item -Force u072-delete-claim-hdr-orig.sf u072-delete-claim-hdr.sf
Move-Item -Force u072-delete-claim-hdr-orig.sfd u072-delete-claim-hdr.sfd


Set-Location $env:pb_data

Move-Item -Force f002_claims_mstr \\$Env:root\foxtrot\purge\f002_claims_mstr_orig
Move-Item -Force f002_claims_mstr.idx \\$Env:root\foxtrot\purge\f002_claims_mstr_orig.idx
Move-Item -Force f002_claim_shadow \\$Env:root\foxtrot\purge\f002_claim_shadow_orig
Move-Item -Force f002_claim_shadow.idx \\$Env:root\foxtrot\purge\f002_claim_shadow_orig.idx

# MC7
##rm f002_claims_mstr.dat
##rm f002_claim_shadow.dat


. .\createfiles.com

# MC6

#############################################################################

# MC7
##mv f002_outstanding.dat        /foxtrot/purge/f002_outstanding.dat
##mv f002_outstanding.idx        /foxtrot/purge/f002_outstanding.idx
Move-Item -Force f002_outstanding.dat \\$Env:root\foxtrot\purge\f002_outstanding_orig.dat
Move-Item -Force f002_outstanding.idx \\$Env:root\foxtrot\purge\f002_outstanding_orig.idx

<#$pipedInput = @"
create file f002-outstanding
"@

$pipedInput | qutil++#>
$rcmd = $env:TRUNCATE+ "f002_outstanding"
Invoke-Expression $rcmd

#############################################################################

# 2011/feb/22  - save the following two files as well

Copy-Item f002_claims_extra \\$Env:root\foxtrot\purge\f002_claims_extra_orig
Copy-Item f002_claims_extra.idx \\$Env:root\foxtrot\purge\f002_claims_extra_orig.idx
Copy-Item f085_rejected_claims \\$Env:root\foxtrot\purge\f085_rejected_claims_orig
Copy-Item f085_rejected_claims.idx \\$Env:root\foxtrot\purge\f085_rejected_claims_orig.idx

# 2011/Jun/06  - save the following two files as well

Copy-Item f071_client_rma_claim_nbr \\$Env:root\foxtrot\purge\f071_client_rma_claim_nbr_orig
Copy-Item f071_client_rma_claim_nbr.idx \\$Env:root\foxtrot\purge\f071_client_rma_claim_nbr_orig.idx
Copy-Item f099_group_claim_mstr.dat \\$Env:root\foxtrot\purge\f099_group_claim_mstr_orig.dat
Copy-Item f099_group_claim_mstr.idx \\$Env:root\foxtrot\purge\f099_group_claim_mstr_orig.idx

#############################################################################

echo "Starting u072a Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

Set-Location \\$Env:root\charly\purge

$rcmd = $env:QTP + "u072a"
Invoke-Expression $rcmd

echo "Ending u072a Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

#ls -l  ru072
#lp ru072

#############################################################################
#following "claims_mstr_verify_new" is add Feb 22, 2011

echo "Starting r073 Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

echo "CLAIMS_MSTR_VERIFY_NEW"

Set-Location \\$Env:root\charly\purge

$rcmd = $env:COBOL + "r073 20150630 Y"
Invoke-Expression $rcmd

# CONVERSION ERROR (expected, #1064): bcheck.
# bcheck -n $pb_data/f002_claim_shadow > rv073_after

echo ""
Get-ChildItem -Force r073
echo ""
Get-Date

Move-Item -Force r073 r073_after_claims_purge
Get-Content r073 | Out-Printer
Get-Content r073_after_claims_purge | Out-Printer
Get-Content rv073_after | Out-Printer

echo "Ending r073 Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

## the followings are added by MC on 2011/May/10
#############################################################################
echo "Starting time to unload f002extra and f085 files $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

$rcmd = $env:QUIZ + "unlof002extra"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "unlof085"
Invoke-Expression $rcmd

Set-Location $pb_data

Remove-Item f002_claims_extra.idx
Remove-Item f002_claims_extra

# MC7
##rm f002_claims_extra.dat

Remove-Item f085_rejected_claims.idx
Remove-Item f085_rejected_claims
# MC7
##rm f085_rejected_claims.dat

. .\createfiles.com

Set-Location \\$Env:root\charly\purge

$rcmd = $env:QTP + "relof002extra"
Invoke-Expression $rcmd
$rcmd = $env:QTP + "relof085"
Invoke-Expression $rcmd

echo "Ending time to reload f002extra and f085 files $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

## the followings are added by MC on 2011/Jun/06
#############################################################################
echo "Starting time to unload f071 and f099 files $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

$rcmd = $env:QUIZ + "unlof071"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "unlof099"
Invoke-Expression $rcmd

Set-Location $env:pb_data

Remove-Item f071_client_rma_claim_nbr.idx
Remove-Item f071_client_rma_claim_nbr
# MC7 
##rm f071_client_rma_claim_nbr.dat

Remove-Item f099_group_claim_mstr.dat
Remove-Item f099_group_claim_mstr.idx

. .\createfiles.com

<#$pipedInput = @"
create file f099-group-claim-mstr
"@

$pipedInput | qutil++
#>
$rcmd = $env:TRUNCATE+ "f099_group_claim_mstr"
Invoke-Expression $rcmd

Set-Location $Env:root\charly\purge

$rcmd = $env:QTP + "relof071"
Invoke-Expression $rcmd
$rcmd = $env:QTP + "relof099"
Invoke-Expression $rcmd

echo "Ending time to reload f071 and  f099 files  $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
