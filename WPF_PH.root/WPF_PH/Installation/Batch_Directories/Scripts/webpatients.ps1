#-------------------------------------------------------------------------------
# File 'webpatients.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'webpatients'
#-------------------------------------------------------------------------------

&$env:QUIZ webpatients_doc

#Core - Added to rename report according to quiz file
Get-Content webpatients_doc.txt > patients.txt

