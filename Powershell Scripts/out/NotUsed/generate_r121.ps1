#-------------------------------------------------------------------------------
# File 'generate_r121.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'generate_r121'
#-------------------------------------------------------------------------------

# 2009/jan/21   MC      r121d/e.qzc are no longer needed, instead execute r121c.qzc with nogo
#                       and modify the selection criteria for company
#                       include the new report to r121_$1.txt and r121m.txt

Remove-Item r120*
Remove-Item r119*
Remove-Item r121*

echo "starting r120.qzs, r119 & r121"
&$env:QUIZ r119a
&$env:QUIZ r119b
&$env:QUIZ r119c
&$env:QUIZ r121a
&$env:QUIZ r121b
&$env:QUIZ r121c
&$env:QUIZ r121c "sel if dept-company = 2"
&$env:QUIZ r121c "sel if dept-company = 3"
&$env:QUIZ r121c "sel if dept-company = 4"
echo "finished r121c"

echo "building r119"
Get-Content r119a.txt, r119b.txt, r119c.txt | Set-Content r119_${1}.txt

echo "building r121"
#cat r121a.txt r121b.txt r121c.txt r121d.txt >r121_${1}.txt
Get-Content r121a.txt, r121b.txt, r121c.txt, r121d.txt, r121e.txt, r121f.txt | Set-Content r121_${1}.txt
#cat r121c.txt r121d.txt r121e.txt > r121m.txt
Get-Content r121c.txt, r121d.txt, r121e.txt, r121f.txt | Set-Content r121m.txt
Get-Content r121m.txt | Out-Printer
