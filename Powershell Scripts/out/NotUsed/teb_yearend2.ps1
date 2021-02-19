#-------------------------------------------------------------------------------
# File 'teb_yearend2.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'teb_yearend2'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

echo "--- u115a u115b u115c u116 u117 u118 u119 u121 and u122 ---"
&$env:QTP u115a
&$env:QTP u115b
&$env:QTP u115c
&$env:QTP u116
&$env:QTP u117
&$env:QTP u118
&$env:QTP u119
&$env:QTP u121
&$env:QTP u122

# PAREN SET DEFAULT -- MOVE PAREN ABOVE DOWN 2 LINES!!
# PAREN EXE U125

echo "--- cobol program r123 ---"
&$env:cmd\r123
Remove-Item r123*_${1}.txt *> $null
Move-Item -Force r123a r123a_${1}.txt
Move-Item -Force r123b r123b_${1}.txt
Move-Item -Force r123c r123c_${1}.txt

echo "--- generate_r120 ---"
&$env:cmd\generate_r120 $1

echo "--- r124a and r124b_rma_yearend ---"
Remove-Item r124b.txt *> $null
&$env:QUIZ r124a
&$env:QUIZ r124b_rma_yearend

# KEEP BACKUP OF SUBFILE IN CASE STATEMENTS NEED TO BE RE-GENERATED
Remove-Item r124a_${1}.sf *> $null
Move-Item -Force r124a.sf r124a_${1}.sf
Remove-Item r124a_${1}.sfd *> $null
Move-Item -Force r124a.sfd r124a_${1}.sfd
Remove-Item r124b_${1}.txt *> $null
Move-Item -Force r124b.txt r124b_${1}.txt

echo "--- u126 and u127 ---"
&$env:QTP u126
&$env:QTP u127

echo "--- r125 debugu114 debugu116 dumpf119 dumpf119ytd ---"
echo "--- cfund1 cfund2 check94 holdback ---"
&$env:QUIZ r125
&$env:QUIZ debugu114
&$env:QUIZ debugu116cd1
&$env:QUIZ debugu116cd2
&$env:QUIZ debugu116cd34
&$env:QUIZ dumpf119
&$env:QUIZ dumpf119ytd
&$env:QUIZ cfund1
&$env:QUIZ cfund2 "#execute $obj/check94" "#execute $obj/holdback" #${1}

Remove-Item debugu114_${1}.txt *> $null
Move-Item -Force debugu114.txt debug114_${1}.txt
Remove-Item debugu116cd1_${1}.txt *> $null
Move-Item -Force debugu116cd1.txt debug116cd1_${1}.txt
Remove-Item debugu116cd2_${1}.txt *> $null
Move-Item -Force debugu116cd2.txt debug116cd2_${1}.txt
Remove-Item debugu116cd34_${1}.txt *> $null
Move-Item -Force debugu116cd34.txt debug116cd34_${1}.txt
Remove-Item dumpf119_${1}.txt *> $null
Move-Item -Force dumpf119.txt dumpf119_${1}.txt
Remove-Item dumpf119ytf_${1}.txt *> $null
Move-Item -Force dumpf119ytd.txt dumpf119ytd_${1}.txt
Remove-Item u110_${1}.sf* *> $null
Move-Item -Force u110.sf u110_${1}.sf
Move-Item -Force u110.sfd u110_${1}.sfd

Get-Content r125.txt | Out-Printer
#lp holdback.txt
Get-Content r111b_${1}.txt | Out-Printer
#lp cfund2.txt
#lp check94.txt
#echo
#echo "Load Tape to create tape backup ..."
#echo 
#$cmd/backup_earnings_monthend ${1} 
#echo
#echo
