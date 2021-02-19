# 2009/jan/21 	MC	r121d/e.qzc are no longer needed, instead execute r121c.qzc with nogo
#			and modify the selection criteria for company
#			include the new report to r121_$1.txt and r121m.txt
# 2011/Jan/19   MC      include the new program r121b_company.qzs

echo "starting r120.QTS"
rm r120*
rm r119*
rm r121*

qtp << QTP_EXIT
execute $obj/r120
$1
$1
QTP_EXIT

echo "starting r120.qzs, r119 & r121"
quiz << QUIZ_EXIT
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
QUIZ_EXIT
echo "finished r121c"

echo "building r120"
mv r120.txt r120_${1}.txt
#lp r120_${1}.txt

echo "building r119"
cat r119a.txt r119b.txt r119c.txt >r119_${1}.txt
#lp r119_${1}.txt

echo "building r121"
#cat r121a.txt r121b.txt r121c.txt r121d.txt >r121_${1}.txt
cat r121a.txt r121b.txt r121c.txt r121d.txt r121e.txt r121f.txt  > r121_${1}.txt
#cat r121c.txt r121d.txt r121e.txt > r121m.txt
cat r121c.txt r121d.txt r121e.txt r121f.txt  > r121m.txt
lp r121m.txt

mv r121b_company.txt  r121b_company_${1}.txt
lp r121b_company_${1}.txt

echo "DONE  generate_r120"
