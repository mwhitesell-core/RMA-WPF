#-------------------------------------------------------------------------------
# File 'fileroom.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'fileroom'
#-------------------------------------------------------------------------------

Remove-Item filer001a.ps*
Remove-Item filer001b.txt
Remove-Item filer001c.txt

&$env:QUIZ filer001a
&$env:QUIZ filer001b 60
&$env:QUIZ filer001c 60

#cat filer001b.txt >>filer001c.txt
Get-Content filer001c.txt | Out-Printer
