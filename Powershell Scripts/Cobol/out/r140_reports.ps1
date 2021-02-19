#-------------------------------------------------------------------------------
# File 'r140_reports.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'r140_reports'
#-------------------------------------------------------------------------------

#file:  r140_reports
# 04/jun/01 b.e. - original
# 08/oct/15 M.C. - comment out and transfer  the qutil on tmp-governance-payments-file
#                  to $cmd/r140_verify.com, comment out the execution of r140v_1.qtc & r140_b.qtc which are no longer needed
# 09/jun/16 M.C. - include the execution of new program r140_a5.qzc to generate r140_a_summ.txt
# 13/Sep/05 yas  - include the report only group H289 to generate r140_b_H289.txt  
# 14/Dec/10 yas  - include the report only group H290 to generate r140_b_H290.txt  

clear
echo "Running `'processing of AFP Conversion Payment file - Reports`'"
echo ""
echo ""

echo ""
echo "Setup of 101c"
. $root\macros\setup_rmabill.com  101c
echo ""
echo "Entering `'upload`' directory"
Set-Location $application_upl; Get-Location

#echo Recreate audit file that is used to confirm that all transactions have been processed
#echo and file tmp-counters file ...
$pipedInput = @"
;create file tmp-governance-payments-file
create file tmp-counters
"@

$pipedInput | qutil++

echo "Remove audit file before starting 101c\SOLO process"
Remove-Item r140_b1.sf*  > $null

echo "running r140 reports ..."
echo ".."
# original run after reports
##echo Update control file with ALL doctors found in incoming governance transactions file
##echo Running r140v_1  in 101c
##qtp auto=$obj/r140v_1.qtc
# original run AFTER r140_b1.qzc
##echo
##echo Running r140_b.qtc to update which docs HAVE BEEN PROCESSED in 101c
##qtp auto=$obj/r140_b.qtc

echo "Running 1st part of reports in 101c"
echo "Running r140_a1.qtc"
qtp++ $obj\r140_a1

$pipedInput = @"
;exec $obj/r140_a1.qzc
;exec $obj/r140_a2.qzc
exec $obj/r140_a3.qzc
exec $obj/r140_a4.qzc
exec $obj/r140_a5.qzc
;exec $obj/r140_b1.qzc
"@

$pipedInput | quiz++


echo ""
echo "Setup of SOLO environment"
. $root\macros\setup_rmabill.com solo

echo ""
echo "Entering `'upload`' directory"
Set-Location $application_upl; Get-Location

# originally run AFTER r140_b1.qzc
##echo Running r140_b.qtc to update which docs have BEEN PROCESSED in SOLO
##qtp auto=$obj/r140_b.qtc

#2007/mar/6 b.e. commented out.. 
# this processes only "R" group so already handled in 101c
#echo Running 2nd part of reports in SOLO
#quiz auto=$obj/r140_b1.qzc

Get-ChildItem r140_a.txt, r140_b.txt, r140_b_??.txt
echo ""

echo "Return to  of 101c"
. $root\macros\setup_rmabill.com  101c

echo ""
echo "Entering `'upload`' directory"
Set-Location $application_upl; Get-Location

$pipedInput = @"
exec $obj/r140_b2.qzc
;------------------------------
exec $obj/r140_b2.qzc nogo
set rep dev disc name        r140_b_H055
and select if doc-afp-paym-group = "H055" 
go

set rep dev disc name        r140_b_H061
and select if doc-afp-paym-group = "H061" 
go

set rep dev disc name        r140_b_H103
and select if doc-afp-paym-group = "H103" 
go

set rep dev disc name        r140_b_H104
and select if doc-afp-paym-group = "H104" 
go

set rep dev disc name        r140_b_H105
and select if doc-afp-paym-group = "H105" 
go

set rep dev disc name        r140_b_H106
and select if doc-afp-paym-group = "H106" 
go

set rep dev disc name        r140_b_H107
and select if doc-afp-paym-group = "H107" 
go

set rep dev disc name        r140_b_H108 
and select if doc-afp-paym-group = "H108"
go

set rep dev disc name        r140_b_H109
and select if doc-afp-paym-group = "H109"
go

set rep dev disc name        r140_b_H110
and select if doc-afp-paym-group = "H110"
go

set rep dev disc name        r140_b_H111
and select if doc-afp-paym-group = "H111"
go

set rep dev disc name        r140_b_H112
and select if doc-afp-paym-group = "H112"
go

set rep dev disc name        r140_b_H129
and select if doc-afp-paym-group = "H129"
go

set rep dev disc name        r140_b_H130
and select if doc-afp-paym-group = "H130"
go

set rep dev disc name        r140_b_H131
and select if doc-afp-paym-group = "H131"
go

set rep dev disc name        r140_b_H132
and select if doc-afp-paym-group = "H132"
go

set rep dev disc name        r140_b_H133
and select if doc-afp-paym-group = "H133"
go

set rep dev disc name        r140_b_H134
and select if doc-afp-paym-group = "H134"
go

set rep dev disc name        r140_b_H135
and select if doc-afp-paym-group = "H135"
go

set rep dev disc name        r140_b_H147
and select if doc-afp-paym-group = "H147"
go

set rep dev disc name        r140_b_H520
and select if doc-afp-paym-group = "H520"
go

set rep dev disc name        r140_b_H521
and select if doc-afp-paym-group = "H521"
go

set rep dev disc name        r140_b_H522
and select if doc-afp-paym-group = "H522"
go

set rep dev disc name        r140_b_H523
and select if doc-afp-paym-group = "H523"
go

set rep dev disc name        r140_b_H524
and select if doc-afp-paym-group = "H524"
go

set rep dev disc name        r140_b_H290
and select if doc-afp-paym-group = "H290"
go

;
; REPORT ONLY groups
;

exec $obj/r140_b3.qzc nogo

set rep dev disc name        r140_b_H262
and select if doc-afp-paym-group = "H262"
go

set rep dev disc name        r140_b_H289
and select if doc-afp-paym-group = "H289"
go

set rep dev disc name        r140_b_H513
and select if doc-afp-paym-group = "H513"
go

set rep dev disc name        r140_b_H514
and select if doc-afp-paym-group = "H514"
go

set rep dev disc name        r140_b_H515
and select if doc-afp-paym-group = "H515"
go

set rep dev disc name        r140_b_H516
and select if doc-afp-paym-group = "H516"
go

set rep dev disc name        r140_b_H517
and select if doc-afp-paym-group = "H517"
go

set rep dev disc name        r140_b_H518
and select if doc-afp-paym-group = "H518"
go

set rep dev disc name        r140_b_H519
and select if doc-afp-paym-group = "H519"
go

set rep dev disc name        r140_b_H526
and select if doc-afp-paym-group = "H526"
go

set rep dev disc name        r140_b_H527
and select if doc-afp-paym-group = "H527"
go

set rep dev disc name        r140_b_H528
and select if doc-afp-paym-group = "H528"
go

set rep dev disc name        r140_b_H529
and select if doc-afp-paym-group = "H529"
go

"@

$pipedInput | quiz++


echo ""
echo "Done!"
