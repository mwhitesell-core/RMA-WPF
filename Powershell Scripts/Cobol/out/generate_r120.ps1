#-------------------------------------------------------------------------------
# File 'generate_r120.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'generate_r120'
#-------------------------------------------------------------------------------

# 2009/jan/21   MC      r121d/e.qzc are no longer needed, instead execute r121c.qzc with nogo
#                       and modify the selection criteria for company
#                       include the new report to r121_$1.txt and r121m.txt
# 2011/Jan/19   MC      include the new program r121b_company.qzs

echo "starting r120.QTS"
Remove-Item r120*
Remove-Item r119*
Remove-Item r121*

$pipedInput = @"
execute $obj/r120
$1
$1
"@

$pipedInput | qtp++

echo "starting r120.qzs, r119 & r121"
$pipedInput = @"
execute $obj/r120
$1
$1
execute $obj/r119a
execute $obj/r119b
execute $obj/r119c
execute $obj/r121a
execute $obj/r121b
execute $obj/r121b_company
execute $obj/r121c
;execute $obj/r121d
;execute $obj/r121e
exec $obj/r121c nogo
set rep dev disc name r121d
set formfeed
sel if dept-company = 2
go
exec $obj/r121c nogo
set rep dev disc name r121e
set formfeed
sel if dept-company = 3
go
exec $obj/r121c nogo
set rep dev disc name r121f
set formfeed
sel if dept-company = 4
go
"@

$pipedInput | quiz++
echo "finished r121c"

echo "building r120"
Move-Item r120.txt r120_${1}.txt
#lp r120_${1}.txt

echo "building r119"
Get-Content r119a.txt, r119b.txt, r119c.txt  > r119_${1}.txt
#lp r119_${1}.txt

echo "building r121"
#cat r121a.txt r121b.txt r121c.txt r121d.txt >r121_${1}.txt
Get-Content r121a.txt, r121b.txt, r121c.txt, r121d.txt, r121e.txt, r121f.txt  > r121_${1}.txt
#cat r121c.txt r121d.txt r121e.txt > r121m.txt
Get-Content r121c.txt, r121d.txt, r121e.txt, r121f.txt  > r121m.txt
Get-Contents r121m.txt| Out-Printer

Move-Item r121b_company.txt r121b_company_${1}.txt
Get-Contents r121b_company_${1}.txt| Out-Printer

echo "DONE  generate_r120"
