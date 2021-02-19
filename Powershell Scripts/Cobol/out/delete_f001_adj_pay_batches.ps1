#-------------------------------------------------------------------------------
# File 'delete_f001_adj_pay_batches.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'delete_f001_adj_pay_batches'
#-------------------------------------------------------------------------------

#  2001/jul/09 B.E. added renames to backup subfiles for each clinic
#  2003/Jul/16 yas. added clinics 91,92,93,94 and 96
#  2012/Jul/05 MC   copy f002-claims-mstr   to /foxtrot/purge
#  2015/Feb/17 Yas  add new group H290 clinic 30             
#  2015/Jun/10 Yas  add new clinic 26                        

echo "DELETE_F001_ADJ_PAY_BATCHES"
echo ""

echo "DELETE THE ADJUSTMENT AND PAYMENT BATCHES FOR THE CLINIC"
echo ""
echo "N O T E : ! ! !  F001 AND F002 MUST HAVE BE BACKED UP before THIS RUN ..."
echo ""
echo ""
echo "STAGE 1A - RUN VERIFY OF CLAIMS  FOR A REPORT OF FILE BEFORE DELETION .."

Set-Location $pb_data

Copy-Item f002_claims_mstr $root\foxtrot\purge\f002_claims_mstr_orig
Copy-Item f002_claims_mstr.idx $root\foxtrot\purge\f002_claims_mstr_orig.idx

Set-Location $root\charly\purge

$pipedInput = @"
20160630
Y
"@

$pipedInput | cobrun++ $obj\r071  2>&1

Remove-Item r071_before  > $null
Move-Item r071 r071_before

echo ""
Get-ChildItem -Force r071_before
echo ""

Get-Date

#lp r071_before

echo ""
echo "STAGE 1B - RUN `"ALL_BATCHES`" ON ALL CLINICS BEFORE DELETION ..."

cobrun++ $obj\r001b

Remove-Item r001b_before_r093  > $null
Move-Item r001b r001b_before_r093

echo ""
Get-ChildItem -Force r001b_before_r093
echo ""



##lp     r001b_before_r093

Remove-Item u093-retain-batch.sf*  > $null
Remove-Item u093-delete-batch.sf*  > $null
Remove-Item u093-purge-validate.sf*  > $null
Remove-Item u093*.txt  > $null

echo ""
echo "STAGE 2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 22 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."


echo " --- u093   (QTP) --- "
$pipedInput = @"
exec $obj/u093.qtc
22000000
22ZZZ999
20160630
exit
"@

$pipedInput | qtp++

$pipedInput = @"
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
22
exec $obj/r093d.qzc
22
exit
"@

$pipedInput | quiz++
Move-Item u093-delete-batch.sf u093-delete-batch-22.sf
Move-Item u093-delete-batch.sfd u093-delete-batch-22.sfd
Move-Item u093-retain-batch.sf u093-retain-batch-22.sf
Move-Item u093-retain-batch.sfd u093-retain-batch-22.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_22  > $null
Get-Content r093a.txt, r093b.txt  > r093_22
#lp                           r093_22

echo ""
echo "STAGE 2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 23 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$pipedInput = @"
exec $obj/u093.qtc
23000000
23ZZZ999
20160630
exit
"@

$pipedInput | qtp++

$pipedInput = @"
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
23
exec $obj/r093d.qzc
23
exit
"@

$pipedInput | quiz++
Move-Item u093-delete-batch.sf u093-delete-batch-23.sf
Move-Item u093-delete-batch.sfd u093-delete-batch-23.sfd
Move-Item u093-retain-batch.sf u093-retain-batch-23.sf
Move-Item u093-retain-batch.sfd u093-retain-batch-23.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

Remove-Item r093_23  > $null
Get-Content r093a.txt, r093b.txt  > r093_23
#lp                           r093_23

echo ""
echo "STAGE 2   - RUN BATCH DELETION PROGRAM FOR CLINIC -- 24 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$pipedInput = @"
exec $obj/u093.qtc
24000000
24ZZZ999
20160630
exit
"@

$pipedInput | qtp++

$pipedInput = @"
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
24
exec $obj/r093d.qzc
24
exit
"@

$pipedInput | quiz++
Move-Item u093-delete-batch.sf u093-delete-batch-24.sf
Move-Item u093-delete-batch.sfd u093-delete-batch-24.sfd
Move-Item u093-retain-batch.sf u093-retain-batch-24.sf
Move-Item u093-retain-batch.sfd u093-retain-batch-24.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

Remove-Item r093_24  > $null
Get-Content r093a.txt, r093b.txt  > r093_24
#lp                           r093_24


echo ""
echo "STAGE 2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 25 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$pipedInput = @"
exec $obj/u093.qtc
25000000
25ZZZ999
20160630
exit
"@

$pipedInput | qtp++

$pipedInput = @"
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
25
exec $obj/r093d.qzc
25
exit
"@

$pipedInput | quiz++
Move-Item u093-delete-batch.sf u093-delete-batch-25.sf
Move-Item u093-delete-batch.sfd u093-delete-batch-25.sfd
Move-Item u093-retain-batch.sf u093-retain-batch-25.sf
Move-Item u093-retain-batch.sfd u093-retain-batch-25.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

Remove-Item r093_25  > $null
Get-Content r093a.txt, r093b.txt  > r093_25
#lp                           r093_25


echo ""
echo "STAGE 2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 26 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$pipedInput = @"
exec $obj/u093.qtc
26000000
26ZZZ999
20160630
exit
"@

$pipedInput | qtp++

$pipedInput = @"
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
26
exec $obj/r093d.qzc
26
exit
"@

$pipedInput | quiz++
Move-Item u093-delete-batch.sf u093-delete-batch-26.sf
Move-Item u093-delete-batch.sfd u093-delete-batch-26.sfd
Move-Item u093-retain-batch.sf u093-retain-batch-26.sf
Move-Item u093-retain-batch.sfd u093-retain-batch-26.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

Remove-Item r093_26  > $null
Get-Content r093a.txt, r093b.txt  > r093_26
#lp                           r093_26


echo ""
echo "STAGE  2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 30 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$pipedInput = @"
exec $obj/u093.qtc
30000000
30ZZZ999
20160630
exit
"@

$pipedInput | qtp++

$pipedInput = @"
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
30
exec $obj/r093d.qzc
30
exit
"@

$pipedInput | quiz++
Move-Item u093-delete-batch.sf u093-delete-batch-30.sf
Move-Item u093-delete-batch.sfd u093-delete-batch-30.sfd
Move-Item u093-retain-batch.sf u093-retain-batch-30.sf
Move-Item u093-retain-batch.sfd u093-retain-batch-30.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

Remove-Item r093_30  > $null
Get-Content r093a.txt, r093b.txt  > r093_30
#lp                           r093_30

echo ""
echo "STAGE 2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 31 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$pipedInput = @"
exec $obj/u093.qtc
31000000
31ZZZ999
20160630
exit
"@

$pipedInput | qtp++

$pipedInput = @"
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
31
exec $obj/r093d.qzc
31
exit
"@

$pipedInput | quiz++
Move-Item u093-delete-batch.sf u093-delete-batch-31.sf
Move-Item u093-delete-batch.sfd u093-delete-batch-31.sfd
Move-Item u093-retain-batch.sf u093-retain-batch-31.sf
Move-Item u093-retain-batch.sfd u093-retain-batch-31.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_31  > $null
Get-Content r093a.txt, r093b.txt  > r093_31
#lp                           r093_31

echo ""
echo "STAGE 2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 32 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$pipedInput = @"
exec $obj/u093.qtc
32000000
32ZZZ999
20160630
exit
"@

$pipedInput | qtp++

$pipedInput = @"
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
32
exec $obj/r093d.qzc
32
exit
"@

$pipedInput | quiz++
Move-Item u093-delete-batch.sf u093-delete-batch-32.sf
Move-Item u093-delete-batch.sfd u093-delete-batch-32.sfd
Move-Item u093-retain-batch.sf u093-retain-batch-32.sf
Move-Item u093-retain-batch.sfd u093-retain-batch-32.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_32  > $null
Get-Content r093a.txt, r093b.txt  > r093_32
#lp                           r093_32

echo ""
echo "STAGE 2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 33 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$pipedInput = @"
exec $obj/u093.qtc
33000000
33ZZZ999
20160630
exit
"@

$pipedInput | qtp++

$pipedInput = @"
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
33
exec $obj/r093d.qzc
33
exit
"@

$pipedInput | quiz++
Move-Item u093-delete-batch.sf u093-delete-batch-33.sf
Move-Item u093-delete-batch.sfd u093-delete-batch-33.sfd
Move-Item u093-retain-batch.sf u093-retain-batch-33.sf
Move-Item u093-retain-batch.sfd u093-retain-batch-33.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_33  > $null
Get-Content r093a.txt, r093b.txt  > r093_33
#lp                           r093_33

echo ""
echo "STAGE 2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 34 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$pipedInput = @"
exec $obj/u093.qtc
34000000
34ZZZ999
20160630
exit
"@

$pipedInput | qtp++

$pipedInput = @"
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
34
exec $obj/r093d.qzc
34
exit
"@

$pipedInput | quiz++
Move-Item u093-delete-batch.sf u093-delete-batch-34.sf
Move-Item u093-delete-batch.sfd u093-delete-batch-34.sfd
Move-Item u093-retain-batch.sf u093-retain-batch-34.sf
Move-Item u093-retain-batch.sfd u093-retain-batch-34.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_34  > $null
Get-Content r093a.txt, r093b.txt  > r093_34
#lp                           r093_34

echo ""
echo "STAGE 2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 35 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$pipedInput = @"
exec $obj/u093.qtc
35000000
35ZZZ999
20160630
exit
"@

$pipedInput | qtp++

$pipedInput = @"
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
35
exec $obj/r093d.qzc
35
exit
"@

$pipedInput | quiz++
Move-Item u093-delete-batch.sf u093-delete-batch-35.sf
Move-Item u093-delete-batch.sfd u093-delete-batch-35.sfd
Move-Item u093-retain-batch.sf u093-retain-batch-35.sf
Move-Item u093-retain-batch.sfd u093-retain-batch-35.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_35  > $null
Get-Content r093a.txt, r093b.txt  > r093_35
#lp                           r093_35


echo ""
echo "STAGE 2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 36 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$pipedInput = @"
exec $obj/u093.qtc
36000000
36ZZZ999
20160630
exit
"@

$pipedInput | qtp++

$pipedInput = @"
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
36
exec $obj/r093d.qzc
36
exit
"@

$pipedInput | quiz++
Move-Item u093-delete-batch.sf u093-delete-batch-36.sf
Move-Item u093-delete-batch.sfd u093-delete-batch-36.sfd
Move-Item u093-retain-batch.sf u093-retain-batch-36.sf
Move-Item u093-retain-batch.sfd u093-retain-batch-36.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_36  > $null
Get-Content r093a.txt, r093b.txt  > r093_36
#lp                           r093_36


echo ""
echo "STAGE  2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 37 --"
echo ""

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

$pipedInput = @"
exec $obj/u093.qtc
37000000
37ZZZ999
20160630
exit
"@

$pipedInput | qtp++

$pipedInput = @"
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
37
exec $obj/r093d.qzc
37
exit
"@

$pipedInput | quiz++
Move-Item u093-delete-batch.sf u093-delete-batch-37.sf
Move-Item u093-delete-batch.sfd u093-delete-batch-37.sfd
Move-Item u093-retain-batch.sf u093-retain-batch-37.sf
Move-Item u093-retain-batch.sfd u093-retain-batch-37.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_37  > $null
Get-Content r093a.txt, r093b.txt  > r093_37
#lp                           r093_37

echo ""
echo "STAGE 2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 41 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$pipedInput = @"
exec $obj/u093.qtc
41000000
41ZZZ999
20160630
exit
"@

$pipedInput | qtp++

$pipedInput = @"
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
41
exec $obj/r093d.qzc
41
exit
"@

$pipedInput | quiz++
Move-Item u093-delete-batch.sf u093-delete-batch-41.sf
Move-Item u093-delete-batch.sfd u093-delete-batch-41.sfd
Move-Item u093-retain-batch.sf u093-retain-batch-41.sf
Move-Item u093-retain-batch.sfd u093-retain-batch-41.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_41  > $null
Get-Content r093a.txt, r093b.txt  > r093_41
#lp                           r093_41


echo ""
echo "STAGE 2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 42 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$pipedInput = @"
exec $obj/u093.qtc
42000000
42ZZZ999
20160630
exit
"@

$pipedInput | qtp++

$pipedInput = @"
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
42
exec $obj/r093d.qzc
42
exit
"@

$pipedInput | quiz++
Move-Item u093-delete-batch.sf u093-delete-batch-42.sf
Move-Item u093-delete-batch.sfd u093-delete-batch-42.sfd
Move-Item u093-retain-batch.sf u093-retain-batch-42.sf
Move-Item u093-retain-batch.sfd u093-retain-batch-42.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_42  > $null
Get-Content r093a.txt, r093b.txt  > r093_42
#lp                           r093_42

echo ""
echo "STAGE 2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 43 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$pipedInput = @"
exec $obj/u093.qtc
43000000
43ZZZ999
20160630
exit
"@

$pipedInput | qtp++

$pipedInput = @"
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
43
exec $obj/r093d.qzc
43
exit
"@

$pipedInput | quiz++
Move-Item u093-delete-batch.sf u093-delete-batch-43.sf
Move-Item u093-delete-batch.sfd u093-delete-batch-43.sfd
Move-Item u093-retain-batch.sf u093-retain-batch-43.sf
Move-Item u093-retain-batch.sfd u093-retain-batch-43.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_43  > $null
Get-Content r093a.txt, r093b.txt  > r093_43
#lp                           r093_43


echo ""
echo "STAGE 2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 44 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$pipedInput = @"
exec $obj/u093.qtc
44000000
44ZZZ999
20160630
exit
"@

$pipedInput | qtp++

$pipedInput = @"
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
44
exec $obj/r093d.qzc
44
exit
"@

$pipedInput | quiz++
Move-Item u093-delete-batch.sf u093-delete-batch-44.sf
Move-Item u093-delete-batch.sfd u093-delete-batch-44.sfd
Move-Item u093-retain-batch.sf u093-retain-batch-44.sf
Move-Item u093-retain-batch.sfd u093-retain-batch-44.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_44  > $null
Get-Content r093a.txt, r093b.txt  > r093_44
#lp                           r093_44


echo ""
echo "STAGE 2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 45 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$pipedInput = @"
exec $obj/u093.qtc
45000000
45ZZZ999
20160630
exit
"@

$pipedInput | qtp++

$pipedInput = @"
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
45
exec $obj/r093d.qzc
45
exit
"@

$pipedInput | quiz++
Move-Item u093-delete-batch.sf u093-delete-batch-45.sf
Move-Item u093-delete-batch.sfd u093-delete-batch-45.sfd
Move-Item u093-retain-batch.sf u093-retain-batch-45.sf
Move-Item u093-retain-batch.sfd u093-retain-batch-45.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_45  > $null
Get-Content r093a.txt, r093b.txt  > r093_45
#lp                           r093_45


echo ""
echo "STAGE 2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 46 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$pipedInput = @"
exec $obj/u093.qtc
46000000
46ZZZ999
20160630
exit
"@

$pipedInput | qtp++

$pipedInput = @"
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
46
exec $obj/r093d.qzc
46
exit
"@

$pipedInput | quiz++
Move-Item u093-delete-batch.sf u093-delete-batch-46.sf
Move-Item u093-delete-batch.sfd u093-delete-batch-46.sfd
Move-Item u093-retain-batch.sf u093-retain-batch-46.sf
Move-Item u093-retain-batch.sfd u093-retain-batch-46.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_46  > $null
Get-Content r093a.txt, r093b.txt  > r093_46
#lp                           r093_46


echo ""
echo ""
echo "STAGE  2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 60 --"
echo ""

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

$pipedInput = @"
exec $obj/u093.qtc
60000000
66ZZZ999
20160630
exit
"@

$pipedInput | qtp++

$pipedInput = @"
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
60
exec $obj/r093d.qzc
60
exit
"@

$pipedInput | quiz++
Move-Item u093-delete-batch.sf u093-delete-batch-60.sf
Move-Item u093-delete-batch.sfd u093-delete-batch-60.sfd
Move-Item u093-retain-batch.sf u093-retain-batch-60.sf
Move-Item u093-retain-batch.sfd u093-retain-batch-60.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""
Get-Date
echo ""


Remove-Item r093_60  > $null
Get-Content r093a.txt, r093b.txt  > r093_60
#lp                           r093_60

echo ""
echo ""
echo "STAGE 2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 68 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$pipedInput = @"
exec $obj/u093.qtc
68000000
68ZZZ999
20160630
exit
"@

$pipedInput | qtp++

$pipedInput = @"
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
68
exec $obj/r093d.qzc
68
exit
"@

$pipedInput | quiz++
Move-Item u093-delete-batch.sf u093-delete-batch-68.sf
Move-Item u093-delete-batch.sfd u093-delete-batch-68.sfd
Move-Item u093-retain-batch.sf u093-retain-batch-68.sf
Move-Item u093-retain-batch.sfd u093-retain-batch-68.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_68  > $null
Get-Content r093a.txt, r093b.txt  > r093_68
#lp                           r093_68

echo ""
echo ""


echo "STAGE 2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 69 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$pipedInput = @"
exec $obj/u093.qtc
69000000
69ZZZ999
20160630
exit
"@

$pipedInput | qtp++

$pipedInput = @"
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
69
exec $obj/r093d.qzc
69
exit
"@

$pipedInput | quiz++
Move-Item u093-delete-batch.sf u093-delete-batch-69.sf
Move-Item u093-delete-batch.sfd u093-delete-batch-69.sfd
Move-Item u093-retain-batch.sf u093-retain-batch-69.sf
Move-Item u093-retain-batch.sfd u093-retain-batch-69.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_69  > $null
Get-Content r093a.txt, r093b.txt  > r093_69
#lp                           r093_69

echo ""
echo ""
echo "STAGE   2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 70 --"
echo ""

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

$pipedInput = @"
exec $obj/u093.qtc
70000000
75ZZZ999
20160630
exit
"@

$pipedInput | qtp++

$pipedInput = @"
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
70
exec $obj/r093d.qzc
70
exit
"@

$pipedInput | quiz++
Move-Item u093-delete-batch.sf u093-delete-batch-70.sf
Move-Item u093-delete-batch.sfd u093-delete-batch-70.sfd
Move-Item u093-retain-batch.sf u093-retain-batch-70.sf
Move-Item u093-retain-batch.sfd u093-retain-batch-70.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""
Get-Date
echo ""


Remove-Item r093_70  > $null
Get-Content r093a.txt, r093b.txt  > r093_70
#lp                           r093_70


echo ""
echo "STAGE  2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 78 --"
echo ""

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

$pipedInput = @"
exec $obj/u093.qtc
78000000
78ZZZ999
20160630
exit
"@

$pipedInput | qtp++

$pipedInput = @"
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
78
exec $obj/r093d.qzc
78
exit
"@

$pipedInput | quiz++
Move-Item u093-delete-batch.sf u093-delete-batch-78.sf
Move-Item u093-delete-batch.sfd u093-delete-batch-78.sfd
Move-Item u093-retain-batch.sf u093-retain-batch-78.sf
Move-Item u093-retain-batch.sfd u093-retain-batch-78.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_78  > $null
Get-Content r093a.txt, r093b.txt  > r093_78
#lp                           r093_78




echo ""
echo "STAGE 2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 79 --"
echo ""

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

$pipedInput = @"
exec $obj/u093.qtc
79000000
79ZZZ999
20160630
exit
"@

$pipedInput | qtp++

$pipedInput = @"
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
79
exec $obj/r093d.qzc
79
exit
"@

$pipedInput | quiz++
Move-Item u093-delete-batch.sf u093-delete-batch-79.sf
Move-Item u093-delete-batch.sfd u093-delete-batch-79.sfd
Move-Item u093-retain-batch.sf u093-retain-batch-79.sf
Move-Item u093-retain-batch.sfd u093-retain-batch-79.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_79  > $null
Get-Content r093a.txt, r093b.txt  > r093_79
#lp                           r093_79

echo ""
echo "STAGE  2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 80 --"
echo ""

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

$pipedInput = @"
exec $obj/u093.qtc
80000000
80ZZZ999
20160630
exit
"@

$pipedInput | qtp++

$pipedInput = @"
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
80
exec $obj/r093d.qzc
80
exit
"@

$pipedInput | quiz++
Move-Item u093-delete-batch.sf u093-delete-batch-80.sf
Move-Item u093-delete-batch.sfd u093-delete-batch-80.sfd
Move-Item u093-retain-batch.sf u093-retain-batch-80.sf
Move-Item u093-retain-batch.sfd u093-retain-batch-80.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_80  > $null
Get-Content r093a.txt, r093b.txt  > r093_80
#lp                           r093_80


echo ""
echo ""
echo "STAGE  2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 82 --"
echo ""

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

$pipedInput = @"
exec $obj/u093.qtc
82000000
82ZZZ999
20160630
exit
"@

$pipedInput | qtp++

$pipedInput = @"
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
82
exec $obj/r093d.qzc
82
exit
"@

$pipedInput | quiz++
Move-Item u093-delete-batch.sf u093-delete-batch-82.sf
Move-Item u093-delete-batch.sfd u093-delete-batch-82.sfd
Move-Item u093-retain-batch.sf u093-retain-batch-82.sf
Move-Item u093-retain-batch.sfd u093-retain-batch-82.sfd


echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_82  > $null
Get-Content r093a.txt, r093b.txt  > r093_82
#lp                           r093_82

echo ""

echo ""
echo ""
echo "STAGE   2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 84 --"
echo ""

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

$pipedInput = @"
exec $obj/u093.qtc
84000000
84ZZZ999
20160630
exit
"@

$pipedInput | qtp++

$pipedInput = @"
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
84
exec $obj/r093d.qzc
84
exit
"@

$pipedInput | quiz++
Move-Item u093-delete-batch.sf u093-delete-batch-84.sf
Move-Item u093-delete-batch.sfd u093-delete-batch-84.sfd
Move-Item u093-retain-batch.sf u093-retain-batch-84.sf
Move-Item u093-retain-batch.sfd u093-retain-batch-84.sfd


echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_84  > $null
Get-Content r093a.txt, r093b.txt  > r093_84
#lp                           r093_84


echo ""
echo "STAGE 2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 86 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$pipedInput = @"
exec $obj/u093.qtc
86000000
86ZZZ999
20160630
exit
"@

$pipedInput | qtp++

$pipedInput = @"
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
86
exec $obj/r093d.qzc
86
exit
"@

$pipedInput | quiz++
Move-Item u093-delete-batch.sf u093-delete-batch-86.sf
Move-Item u093-delete-batch.sfd u093-delete-batch-86.sfd
Move-Item u093-retain-batch.sf u093-retain-batch-86.sf
Move-Item u093-retain-batch.sfd u093-retain-batch-86.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_86  > $null
Get-Content r093a.txt, r093b.txt  > r093_86
#lp                           r093_86

echo ""
echo "STAGE 2  - RUN BATCH DELETION PROGRAM FOR CLINIC --87 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$pipedInput = @"
exec $obj/u093.qtc
87000000
87ZZZ999
20160630
exit
"@

$pipedInput | qtp++

$pipedInput = @"
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
87
exec $obj/r093d.qzc
87
exit
"@

$pipedInput | quiz++
Move-Item u093-delete-batch.sf u093-delete-batch-87.sf
Move-Item u093-delete-batch.sfd u093-delete-batch-87.sfd
Move-Item u093-retain-batch.sf u093-retain-batch-87.sf
Move-Item u093-retain-batch.sfd u093-retain-batch-87.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_87  > $null

Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_87  > $null
Get-Content r093a.txt, r093b.txt  > r093_87
#lp                           r093_87

echo ""
echo "STAGE 2  - RUN BATCH DELETION PROGRAM FOR CLINIC --88 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$pipedInput = @"
exec $obj/u093.qtc
88000000
88ZZZ999
20160630
exit
"@

$pipedInput | qtp++

$pipedInput = @"
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
88
exec $obj/r093d.qzc
88
exit
"@

$pipedInput | quiz++
Move-Item u093-delete-batch.sf u093-delete-batch-88.sf
Move-Item u093-delete-batch.sfd u093-delete-batch-88.sfd
Move-Item u093-retain-batch.sf u093-retain-batch-88.sf
Move-Item u093-retain-batch.sfd u093-retain-batch-88.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_88  > $null

Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_88  > $null
Get-Content r093a.txt, r093b.txt  > r093_88
#lp                           r093_88

echo ""
echo "STAGE 2 - RUN BATCH DELETION PROGRAM FOR CLINIC --89 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$pipedInput = @"
exec $obj/u093.qtc
89000000
89ZZZ999
20160630
exit
"@

$pipedInput | qtp++

$pipedInput = @"
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
89
exec $obj/r093d.qzc
89
exit
"@

$pipedInput | quiz++
Move-Item u093-delete-batch.sf u093-delete-batch-89.sf
Move-Item u093-delete-batch.sfd u093-delete-batch-89.sfd
Move-Item u093-retain-batch.sf u093-retain-batch-89.sf
Move-Item u093-retain-batch.sfd u093-retain-batch-89.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_89  > $null

Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_89  > $null
Get-Content r093a.txt, r093b.txt  > r093_89
#lp                           r093_89

echo ""
echo "STAGE 2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 91 --"
echo ""

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

$pipedInput = @"
exec $obj/u093.qtc
91000000
91ZZZ999
20160630
exit
"@

$pipedInput | qtp++

$pipedInput = @"
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
91
exec $obj/r093d.qzc
91
exit
"@

$pipedInput | quiz++
Move-Item u093-delete-batch.sf u093-delete-batch-91.sf
Move-Item u093-delete-batch.sfd u093-delete-batch-91.sfd
Move-Item u093-retain-batch.sf u093-retain-batch-91.sf
Move-Item u093-retain-batch.sfd u093-retain-batch-91.sfd


echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_91  > $null
Get-Content r093a.txt, r093b.txt  > r093_91
#lp                           r093_91



echo ""
echo "STAGE  2   - RUN BATCH DELETION PROGRAM FOR CLINIC -- 92 --"
echo ""

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

$pipedInput = @"
exec $obj/u093.qtc
92000000
92ZZZ999
20160630
exit
"@

$pipedInput | qtp++

$pipedInput = @"
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
92
exec $obj/r093d.qzc
92
exit
"@

$pipedInput | quiz++
Move-Item u093-delete-batch.sf u093-delete-batch-92.sf
Move-Item u093-delete-batch.sfd u093-delete-batch-92.sfd
Move-Item u093-retain-batch.sf u093-retain-batch-92.sf
Move-Item u093-retain-batch.sfd u093-retain-batch-92.sfd


echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_92  > $null
Get-Content r093a.txt, r093b.txt  > r093_92
#lp                           r093_92



echo ""
echo "STAGE  2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 93 --"
echo ""

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

$pipedInput = @"
exec $obj/u093.qtc
93000000
93ZZZ999
20160630
exit
"@

$pipedInput | qtp++

$pipedInput = @"
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
93
exec $obj/r093d.qzc
93
exit
"@

$pipedInput | quiz++
Move-Item u093-delete-batch.sf u093-delete-batch-93.sf
Move-Item u093-delete-batch.sfd u093-delete-batch-93.sfd
Move-Item u093-retain-batch.sf u093-retain-batch-93.sf
Move-Item u093-retain-batch.sfd u093-retain-batch-93.sfd


echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_93  > $null
Get-Content r093a.txt, r093b.txt  > r093_93
#lp                           r093_93


echo ""
echo "STAGE  2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 94 --"
echo ""

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

$pipedInput = @"
exec $obj/u093.qtc
94000000
94ZZZ999
20160630
exit
"@

$pipedInput | qtp++

$pipedInput = @"
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
94
exec $obj/r093d.qzc
94
exit
"@

$pipedInput | quiz++
Move-Item u093-delete-batch.sf u093-delete-batch-94.sf
Move-Item u093-delete-batch.sfd u093-delete-batch-94.sfd
Move-Item u093-retain-batch.sf u093-retain-batch-94.sf
Move-Item u093-retain-batch.sfd u093-retain-batch-94.sfd


echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_94  > $null
Get-Content r093a.txt, r093b.txt  > r093_94
#lp                           r093_94


echo ""
echo "STAGE   2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 95 --"
echo ""

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

$pipedInput = @"
exec $obj/u093.qtc
95000000
95ZZZ999
20160630
exit
"@

$pipedInput | qtp++

$pipedInput = @"
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
95
exec $obj/r093d.qzc
95
exit
"@

$pipedInput | quiz++
Move-Item u093-delete-batch.sf u093-delete-batch-95.sf
Move-Item u093-delete-batch.sfd u093-delete-batch-95.sfd
Move-Item u093-retain-batch.sf u093-retain-batch-95.sf
Move-Item u093-retain-batch.sfd u093-retain-batch-95.sfd


echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_95  > $null
Get-Content r093a.txt, r093b.txt  > r093_95
#lp                           r093_95


echo ""
echo "STAGE  2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 96 --"
echo ""

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

$pipedInput = @"
exec $obj/u093.qtc
96000000
96ZZZ999
20160630
exit
"@

$pipedInput | qtp++

$pipedInput = @"
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
96
exec $obj/r093d.qzc
96
exit
"@

$pipedInput | quiz++
Move-Item u093-delete-batch.sf u093-delete-batch-96.sf
Move-Item u093-delete-batch.sfd u093-delete-batch-96.sfd
Move-Item u093-retain-batch.sf u093-retain-batch-96.sf
Move-Item u093-retain-batch.sfd u093-retain-batch-96.sfd


echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_96  > $null
Get-Content r093a.txt, r093b.txt  > r093_96
#lp                           r093_96


echo ""
echo "STAGE   2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 98 --"
echo ""

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

$pipedInput = @"
exec $obj/u093.qtc
98000000
98ZZZ999
20160630
exit
"@

$pipedInput | qtp++

$pipedInput = @"
exec $obj/r093a.qzc
exec $obj/r093b.qzc
exec $obj/r093c.qzc
98
exec $obj/r093d.qzc
98
exit
"@

$pipedInput | quiz++
Move-Item u093-delete-batch.sf u093-delete-batch-98.sf
Move-Item u093-delete-batch.sfd u093-delete-batch-98.sfd
Move-Item u093-retain-batch.sf u093-retain-batch-98.sf
Move-Item u093-retain-batch.sfd u093-retain-batch-98.sfd


echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_98  > $null
Get-Content r093a.txt, r093b.txt  > r093_98
#lp                           r093_98



echo ""
echo "STAGE  3A - RUN VERIFY OF CLAIMS FOR A REPORT OF FILE AFTER DELETION ."

$pipedInput = @"
20160630
Y
"@

$pipedInput | cobrun++ $obj\r071  2>&1

Remove-Item r071_after  > $null
Move-Item r071 r071_after

echo ""
Get-ChildItem -Force r071_after
echo ""
#lp      r071_after

echo ""
Get-Date
echo ""
echo "STAGE   3B    - RUN `"ALL_BATCHES`" FOR REPORT OF FILE AFTER REPORT ..."

cobrun++ $obj\r001b

Remove-Item r001b_after_r093  > $null
Move-Item r001b r001b_after_r093

echo ""
Get-ChildItem -Force r001b_after_r093
echo ""
##lp      r001b_after_r093


echo ""
echo "FINISHED ..."
