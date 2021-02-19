#-------------------------------------------------------------------------------
# File 'old_web_create_claims_new_susp.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'old_web_create_claims_new_susp'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

&$env:QUIZ rmaprice
&$env:QTP u708
&$env:QTP newu706a
#cobrun $obj/u706b
&$env:QUIZ r709a
&$env:QUIZ r709b
Get-Content r709b.txt | Out-Printer
Get-Content r709a.txt | Out-Printer
Move-Item -Force rmaprice.txt pr${1}.txt
