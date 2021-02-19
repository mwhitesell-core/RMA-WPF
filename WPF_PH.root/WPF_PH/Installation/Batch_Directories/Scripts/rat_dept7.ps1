#-------------------------------------------------------------------------------
# File 'rat_dept7.ps1'
# Converted to PowerShell by CORE Migration on 2017-10-01 10:16:47
# Original file name was 'rat_dept7'
#-------------------------------------------------------------------------------

Set-Location $env:application_production

# save the original subfile for clinic 22 in production
Copy-Item u997_good_srt.sf u997_good_srt.sf.bkp

# append all Pediatric subfiles to 22 subfile in the production
Get-Content $pb_prod\23\u997_good_srt.sf >> u997_good_srt.sf
Get-Content $pb_prod\24\u997_good_srt.sf >> u997_good_srt.sf
Get-Content $pb_prod\25\u997_good_srt.sf >> u997_good_srt.sf
Get-Content $pb_prod\31\u997_good_srt.sf >> u997_good_srt.sf
Get-Content $pb_prod\32\u997_good_srt.sf >> u997_good_srt.sf
Get-Content $pb_prod\33\u997_good_srt.sf >> u997_good_srt.sf
Get-Content $pb_prod\34\u997_good_srt.sf >> u997_good_srt.sf
Get-Content $pb_prod\35\u997_good_srt.sf >> u997_good_srt.sf
Get-Content $pb_prod\36\u997_good_srt.sf >> u997_good_srt.sf
Get-Content $pb_prod\37\u997_good_srt.sf >> u997_good_srt.sf
Get-Content $pb_prod\41\u997_good_srt.sf >> u997_good_srt.sf
Get-Content $pb_prod\42\u997_good_srt.sf >> u997_good_srt.sf
Get-Content $pb_prod\43\u997_good_srt.sf >> u997_good_srt.sf
Get-Content $pb_prod\44\u997_good_srt.sf >> u997_good_srt.sf
Get-Content $pb_prod\45\u997_good_srt.sf >> u997_good_srt.sf
Get-Content $pb_prod\46\u997_good_srt.sf >> u997_good_srt.sf
Get-Content $pb_prod\61\u997_good_srt.sf >> u997_good_srt.sf
Get-Content $pb_prod\62\u997_good_srt.sf >> u997_good_srt.sf
Get-Content $pb_prod\63\u997_good_srt.sf >> u997_good_srt.sf
Get-Content $pb_prod\64\u997_good_srt.sf >> u997_good_srt.sf
Get-Content $pb_prod\66\u997_good_srt.sf >> u997_good_srt.sf
Get-Content $pb_prod\68\u997_good_srt.sf >> u997_good_srt.sf
Get-Content $pb_prod\69\u997_good_srt.sf >> u997_good_srt.sf
Get-Content $pb_prod\71\u997_good_srt.sf >> u997_good_srt.sf
Get-Content $pb_prod\72\u997_good_srt.sf >> u997_good_srt.sf
Get-Content $pb_prod\73\u997_good_srt.sf >> u997_good_srt.sf
Get-Content $pb_prod\74\u997_good_srt.sf >> u997_good_srt.sf
Get-Content $pb_prod\75\u997_good_srt.sf >> u997_good_srt.sf
Get-Content $pb_prod\78\u997_good_srt.sf >> u997_good_srt.sf
Get-Content $pb_prod\79\u997_good_srt.sf >> u997_good_srt.sf
Get-Content $pb_prod\80\u997_good_srt.sf >> u997_good_srt.sf
Get-Content $pb_prod\82\u997_good_srt.sf >> u997_good_srt.sf
Get-Content $pb_prod\84\u997_good_srt.sf >> u997_good_srt.sf
Get-Content $pb_prod\86\u997_good_srt.sf >> u997_good_srt.sf
Get-Content $pb_prod\87\u997_good_srt.sf >> u997_good_srt.sf
Get-Content $pb_prod\88\u997_good_srt.sf >> u997_good_srt.sf
Get-Content $pb_prod\89\u997_good_srt.sf >> u997_good_srt.sf
Get-Content $pb_prod\91\u997_good_srt.sf >> u997_good_srt.sf
Get-Content $pb_prod\92\u997_good_srt.sf >> u997_good_srt.sf
Get-Content $pb_prod\93\u997_good_srt.sf >> u997_good_srt.sf
Get-Content $pb_prod\94\u997_good_srt.sf >> u997_good_srt.sf
Get-Content $pb_prod\95\u997_good_srt.sf >> u997_good_srt.sf
Get-Content $pb_prod\96\u997_good_srt.sf >> u997_good_srt.sf


$rcmd = $env:QUIZ + "r997_portal_ss" > r997_portal_ss.log
invoke-expression $rcmd

Move-Item -Force r997_portal_ss.txt r997_portal_ss.csv

# rename all clinic subfiles (all consolidate files) to all
Move-Item -Force u997_good_srt.sf u997_good_srt.sf_all

# rename original 22 clinic subfile back
Move-Item -Force u997_good_srt.sf.bkp u997_good_srt.sf
