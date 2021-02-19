#-------------------------------------------------------------------------------
# File 'pat_mstr_recreate.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'pat_mstr_recreate'
#-------------------------------------------------------------------------------

#  2005/jul/06 M.C. - changed to the processing of subfile
#                     on /charly/purge disk
#  2008/jan/22 M.C. - since physical file f010 in located in /charly/rmabill/rmabill10c/data,
#                     change the remove and create link statements accordingly 

#    "PAT_MSTR_RECREATE"
echo ""
echo "PATIENT FILE PURGE STAGE" # 2
echo "NOTE -- THE PREVIOUS STAGES MUST HAVE BEEN RUN !!!"
echo ""
echo "SAVE THE ORIGINAL PATIENT UNDERORIG FILENAME"
echo ""
Get-Date
echo ""

Set-Location $Env:root\charly\rmabill\rmabill101c\data

Move-Item -Force f010_pat_mstr f010_pat_mstr_orig
Move-Item -Force f010_pat_mstr.idx f010_pat_mstr_orig.idx

Set-Location $pb_data

. .\createfiles.com

Get-Item f010* | % {$_.isreadonly = $false}

Move-Item -Force f010_pat_mstr $Env:root\charly\rmabill\rmabill101c\data\f010_pat_mstr
Move-Item -Force f010_pat_mstr.idx $Env:root\charly\rmabill\rmabill101c\data\f010_pat_mstr.idx

# CONVERSION ERROR (expected, #30): Symbolic link creation.
# ln -s /charly/rmabill/rmabill101c/data/f010_pat_mstr     f010_pat_mstr
# CONVERSION ERROR (expected, #31): Symbolic link creation.
# ln -s /charly/rmabill/rmabill101c/data/f010_pat_mstr.idx f010_pat_mstr.idx

echo "HIT `"NEWLINE``" TO RE-CREATE PATIENT MSTR"
echo "BY COPYING RECORDS FROM `'OLD`' MASTER FILES TO `'NEW`' MASTER FILES ..."
echo ""
echo "PROGRAM `"u080``" LOADING ..."


##cd $pb_prod
Set-Location $Env:root\charly\purge

Remove-Item u080.log
#cobrun $obj/u080
&$env:QTP u080 >> u080.log

&$env:QUIZ r080 >> r080.log

#lp ru080.txt
Get-Content u080.log | Out-Printer

echo ""

Get-Date
# CONVERSION ERROR (expected, #57): bcheck.
# bcheck -n $pb_data/f010_pat_mstr > f010_verify_after

echo ""

Get-Date
