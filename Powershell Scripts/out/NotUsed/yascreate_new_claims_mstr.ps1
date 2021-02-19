#-------------------------------------------------------------------------------
# File 'yascreate_new_claims_mstr.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'yascreate_new_claims_mstr'
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
#       
echo ""
echo "A\R FILE PURGE STAGE" # 2
#echo  NOTE -- THE PREVIOUS STAGE(S) MUST HAVE BEEN RUN !!!
echo ""
echo "CREATE NEW FILE AND MOVEBALANCE-OWING CLAIMS FROM OLD TO NEW FILE"
echo ""
echo "NOTE !!"
echo "NO ONE MUST BE ACCESSING THE CLAIMS FILE !!!"
echo ""
echo "HIT  `"NEWLINE``"  TO COMMENCE PROCEDURE ..."
 $garbage = Read-Host
echo ""
echo "CREATING THE NEW CLAIMS MASTER FILE `"F002_CLAIMS_MSTR_NEW``" ..."
echo ""

#cd $pb_prod

Set-Location $Env:root\charly\purge

echo "CREATING THE NEW CLAIM SHADOW  FILE `"F002_CLAIM_SHADOW_NEW``" ..."
echo ""

echo "HIT `"NEWLINE``" TO COPY CLAIMS FROM `'OLD`' TO `'NEW`' FILE ..."
 $garbage = Read-Host
echo ""
echo "PROGRAM `"u072``" NOW LOADING ..."

#cobrun $obj/u072
&$env:QTP u072 20060101

&$env:QUIZ r072a 22
&$env:QUIZ r072b 22
&$env:QUIZ r072c
&$env:QUIZ r072d
&$env:QUIZ r072e

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_22
Remove-Item r072?.txt
Get-Content r072_22 | Out-Printer
# CONVERSION ERROR (unexpected, #59): Unknown command.
# *****************

&$env:QUIZ r072a 31
&$env:QUIZ r072b 31
&$env:QUIZ r072c
&$env:QUIZ r072d
&$env:QUIZ r072e

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_31
Remove-Item r072?.txt
Get-Content r072_31 | Out-Printer

&$env:QUIZ r072a 32
&$env:QUIZ r072b 32
&$env:QUIZ r072c
&$env:QUIZ r072d
&$env:QUIZ r072e

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_32
Remove-Item r072?.txt
Get-Content r072_32 | Out-Printer

&$env:QUIZ r072a 33
&$env:QUIZ r072b 33
&$env:QUIZ r072c
&$env:QUIZ r072d
&$env:QUIZ r072e

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_33
Remove-Item r072?.txt
Get-Content r072_33 | Out-Printer

&$env:QUIZ r072a 34
&$env:QUIZ r072b 34
&$env:QUIZ r072c
&$env:QUIZ r072d
&$env:QUIZ r072e

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_34
Remove-Item r072?.txt
Get-Content r072_34 | Out-Printer

&$env:QUIZ r072a 35
&$env:QUIZ r072b 35
&$env:QUIZ r072c
&$env:QUIZ r072d
&$env:QUIZ r072e

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_35
Remove-Item r072?.txt
Get-Content r072_35 | Out-Printer

&$env:QUIZ r072a 36
&$env:QUIZ r072b 36
&$env:QUIZ r072c
&$env:QUIZ r072d
&$env:QUIZ r072e

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_36
Remove-Item r072?.txt
Get-Content r072_36 | Out-Printer

&$env:QUIZ r072a 37
&$env:QUIZ r072b 37
&$env:QUIZ r072c
&$env:QUIZ r072d
&$env:QUIZ r072e

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_37
Remove-Item r072?.txt
Get-Content r072_37 | Out-Printer

&$env:QUIZ r072a 41
&$env:QUIZ r072b 41
&$env:QUIZ r072c
&$env:QUIZ r072d
&$env:QUIZ r072e

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_41
Remove-Item r072?.txt
Get-Content r072_41 | Out-Printer

&$env:QUIZ r072a 42
&$env:QUIZ r072b 42
&$env:QUIZ r072c
&$env:QUIZ r072d
&$env:QUIZ r072e

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_42
Remove-Item r072?.txt
Get-Content r072_42 | Out-Printer

&$env:QUIZ r072a 43
&$env:QUIZ r072b 43
&$env:QUIZ r072c
&$env:QUIZ r072d
&$env:QUIZ r072e

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_43
Remove-Item r072?.txt
Get-Content r072_43 | Out-Printer

&$env:QUIZ r072a 44
&$env:QUIZ r072b 44
&$env:QUIZ r072c
&$env:QUIZ r072d
&$env:QUIZ r072e

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_44
Remove-Item r072?.txt
Get-Content r072_44 | Out-Printer

&$env:QUIZ r072a 45
&$env:QUIZ r072b 45
&$env:QUIZ r072c
&$env:QUIZ r072d
&$env:QUIZ r072e

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_45
Remove-Item r072?.txt
Get-Content r072_45 | Out-Printer

&$env:QUIZ r072a 46
&$env:QUIZ r072b 46
&$env:QUIZ r072c
&$env:QUIZ r072d
&$env:QUIZ r072e

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_46
Remove-Item r072?.txt
Get-Content r072_46 | Out-Printer

&$env:QUIZ r072a 48
&$env:QUIZ r072b 48
&$env:QUIZ r072c
&$env:QUIZ r072d
&$env:QUIZ r072e

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_48
Remove-Item r072?.txt
Get-Content r072_48 | Out-Printer

&$env:QUIZ r072a 61
&$env:QUIZ r072b 61
&$env:QUIZ r072c
&$env:QUIZ r072d
&$env:QUIZ r072e

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_61
Remove-Item r072?.txt
Get-Content r072_61 | Out-Printer

&$env:QUIZ r072a 62
&$env:QUIZ r072b 62
&$env:QUIZ r072c
&$env:QUIZ r072d
&$env:QUIZ r072e

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_62
Remove-Item r072?.txt
Get-Content r072_62 | Out-Printer

&$env:QUIZ r072a 63
&$env:QUIZ r072b 63
&$env:QUIZ r072c
&$env:QUIZ r072d
&$env:QUIZ r072e

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_63
Remove-Item r072?.txt
Get-Content r072_63 | Out-Printer

&$env:QUIZ r072a 64
&$env:QUIZ r072b 64
&$env:QUIZ r072c
&$env:QUIZ r072d
&$env:QUIZ r072e

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_64
Remove-Item r072?.txt
Get-Content r072_64 | Out-Printer

&$env:QUIZ r072a 65
&$env:QUIZ r072b 65
&$env:QUIZ r072c
&$env:QUIZ r072d
&$env:QUIZ r072e

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_65
Remove-Item r072?.txt
Get-Content r072_65 | Out-Printer

&$env:QUIZ r072a 71
&$env:QUIZ r072b 71
&$env:QUIZ r072c
&$env:QUIZ r072d
&$env:QUIZ r072e

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_71
Remove-Item r072?.txt
Get-Content r072_71 | Out-Printer


&$env:QUIZ r072a 72
&$env:QUIZ r072b 72
&$env:QUIZ r072c
&$env:QUIZ r072d
&$env:QUIZ r072e

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_72
Remove-Item r072?.txt
Get-Content r072_72 | Out-Printer


&$env:QUIZ r072a 73
&$env:QUIZ r072b 73
&$env:QUIZ r072c
&$env:QUIZ r072d
&$env:QUIZ r072e

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_73
Remove-Item r072?.txt
Get-Content r072_73 | Out-Printer


&$env:QUIZ r072a 74
&$env:QUIZ r072b 74
&$env:QUIZ r072c
&$env:QUIZ r072d
&$env:QUIZ r072e

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_74
Remove-Item r072?.txt
Get-Content r072_74 | Out-Printer


&$env:QUIZ r072a 75
&$env:QUIZ r072b 75
&$env:QUIZ r072c
&$env:QUIZ r072d
&$env:QUIZ r072e

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_75
Remove-Item r072?.txt
Get-Content r072_75 | Out-Printer

&$env:QUIZ r072a 80
&$env:QUIZ r072b 80
&$env:QUIZ r072c
&$env:QUIZ r072d
&$env:QUIZ r072e

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_80
Remove-Item r072?.txt
Get-Content r072_80 | Out-Printer

&$env:QUIZ r072a 82
&$env:QUIZ r072b 82
&$env:QUIZ r072c
&$env:QUIZ r072d
&$env:QUIZ r072e

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_82
Remove-Item r072?.txt
Get-Content r072_82 | Out-Printer

&$env:QUIZ r072a 83
&$env:QUIZ r072b 83
&$env:QUIZ r072c
&$env:QUIZ r072d
&$env:QUIZ r072e

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_83
Remove-Item r072?.txt
Get-Content r072_83 | Out-Printer

&$env:QUIZ r072a 84
&$env:QUIZ r072b 84
&$env:QUIZ r072c
&$env:QUIZ r072d
&$env:QUIZ r072e

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_84
Remove-Item r072?.txt
Get-Content r072_84 | Out-Printer

&$env:QUIZ r072a 86
&$env:QUIZ r072b 86
&$env:QUIZ r072c
&$env:QUIZ r072d
&$env:QUIZ r072e

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_86
Remove-Item r072?.txt
Get-Content r072_86 | Out-Printer

&$env:QUIZ r072a 87
&$env:QUIZ r072b 87
&$env:QUIZ r072c
&$env:QUIZ r072d
&$env:QUIZ r072e

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_87
Remove-Item r072?.txt
Get-Content r072_87 | Out-Printer

&$env:QUIZ r072a 91
&$env:QUIZ r072b 91
&$env:QUIZ r072c
&$env:QUIZ r072d
&$env:QUIZ r072e

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_91
Remove-Item r072?.txt
Get-Content r072_91 | Out-Printer


&$env:QUIZ r072a 92
&$env:QUIZ r072b 92
&$env:QUIZ r072c
&$env:QUIZ r072d
&$env:QUIZ r072e

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_92
Remove-Item r072?.txt
Get-Content r072_92 | Out-Printer

&$env:QUIZ r072a 93
&$env:QUIZ r072b 93
&$env:QUIZ r072c
&$env:QUIZ r072d
&$env:QUIZ r072e

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_93
Remove-Item r072?.txt
Get-Content r072_93 | Out-Printer

&$env:QUIZ r072a 94
&$env:QUIZ r072b 94
&$env:QUIZ r072c
&$env:QUIZ r072d
&$env:QUIZ r072e

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_94
Remove-Item r072?.txt
Get-Content r072_94 | Out-Printer

&$env:QUIZ r072a 95
&$env:QUIZ r072b 95
&$env:QUIZ r072c
&$env:QUIZ r072d
&$env:QUIZ r072e

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_95
Remove-Item r072?.txt
Get-Content r072_95 | Out-Printer

&$env:QUIZ r072a 96
&$env:QUIZ r072b 96
&$env:QUIZ r072c
&$env:QUIZ r072d
&$env:QUIZ r072e

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_96
Remove-Item r072?.txt
Get-Content r072_96 | Out-Printer

&$env:QUIZ r072a 98
&$env:QUIZ r072b 98
&$env:QUIZ r072c
&$env:QUIZ r072d
&$env:QUIZ r072e

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_98
Remove-Item r072?.txt
Get-Content r072_98 | Out-Printer

Set-Location $pb_data

#mv f002_claims_mstr             f002_claims_mstr_orig
#mv f002_claims_mstr.idx         f002_claims_mstr_orig.idx
#mv f002_claim_shadow            f002_claim_shadow_orig
#mv f002_claim_shadow.idx        f002_claim_shadow_orig.idx
Move-Item -Force f002_claims_mstr $Env:root\charly\purge\f002_claims_mstr_orig
Move-Item -Force f002_claims_mstr.idx $Env:root\charly\purge\f002_claims_mstr_orig.idx
Move-Item -Force f002_claim_shadow $Env:root\charly\purge\f002_claim_shadow_orig
Move-Item -Force f002_claim_shadow.idx $Env:root\charly\purge\f002_claim_shadow_orig.idx

Remove-Item f002_claims_mstr.dat
Remove-Item f002_claim_shadow.dat

#ln -s f002_claims_mstr_orig     f002_claims_mstr_orig.dat
#ln -s f002_claim_shadow_orig    f002_claim_shadow_orig.dat

. .\createfiles.com

#cd $pb_prod

Set-Location $Env:root\charly\purge

&$env:QTP u072a

#ls -l  ru072

#echo  HIT [[dq]]NEWLINE[[dq]] TO QUEUE THE REPORT FOR PRINTING
# read garbage
#echo

#lp ru072

## the followings are added by MC on 2006/mar/08

#############################################################################
&$env:QTP u071

Set-Location $pb_data

Move-Item -Force f071_client_rma_claim_nbr f071_client_rma_claim_nbr_orig
Move-Item -Force f071_client_rma_claim_nbr.idx f071_client_rma_claim_nbr_orig.idx

Remove-Item f071_client_rma_claim_nbr.dat

# CONVERSION ERROR (expected, #666): Symbolic link creation.
# ln -s f071_client_rma_claim_nbr_orig   f071_client_rma_claim_nbr_orig.dat

. .\createfiles.com

##cd $pb_prod

Set-Location $Env:root\charly\purge

&$env:QTP u071a

#############################################################################
