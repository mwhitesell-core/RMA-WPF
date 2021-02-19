#-------------------------------------------------------------------------------
# File 'r140_reports.ps1'
# Converted to PowerShell by CORE Migration on 2017-10-01 10:16:47
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
if($env:RMABILL_VERS -eq "101cd2") {
    rmabill 101cd2
}
else {
    rmabill 101c
}

echo ""
echo "Entering `'upload`' directory"
Set-Location $env:application_upl ; Get-Location

#echo Recreate audit file that is used to confirm that all transactions have been processed
#echo and file tmp-counters file ...
#$pipedInput = @"
#;create file tmp-governance-payments-file
#create file tmp-counters
#"@



$rcmd = $env:TRUNCATE+"tmp_governance_payments_file"
Invoke-Expression $rcmd

$rcmd = $env:TRUNCATE+"tmp_counters"
Invoke-Expression $rcmd

echo "Remove audit file before starting 101c\SOLO process"
Remove-Item r140_b1.sf* *> $null

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
$rcmd = $env:QTP+"r140_a1"
Invoke-Expression $rcmd

#&$env:QUIZ ";exec $obj/r140_a1.qzc" ";exec $obj/r140_a2.qzc"
$rcmd = $env:QUIZ+"r140_a3"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r140_a3.txt > r140_a.txt

$rcmd = $env:QUIZ+"r140_a4"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r140_a4.txt > r140_a_rma.txt

$rcmd = $env:QUIZ+"r140_a5"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r140_a5.txt > r140_a_summ.txt

echo ""
echo "Setup of SOLO environment"
if($env:RMABILL_VERS -eq "101CD2") {
    rmabill solod2
}
else {
    rmabill solo
}

echo ""
echo "Entering `'upload`' directory"
Set-Location $env:application_upl ; Get-Location

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
if($env:RMABILL_VERS -eq "SOLOD2") {
    rmabill 101cd2
}
else {
    rmabill 101c
}

echo ""
echo "Entering `'upload`' directory"
Set-Location $env:application_upl ; Get-Location

$rcmd = $env:QUIZ+"r140_b2"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ+ "r140_b2 DISC_r140_b_H055"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ+ "r140_b2 DISC_r140_b_H061"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ+ "r140_b2 DISC_r140_b_H103"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ+ "r140_b2 DISC_r140_b_H104"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ+ "r140_b2 DISC_r140_b_H105"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ+ "r140_b2 DISC_r140_b_H106"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ+ "r140_b2 DISC_r140_b_H107"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ+ "r140_b2 DISC_r140_b_H108"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ+ "r140_b2 DISC_r140_b_H109"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ+ "r140_b2 DISC_r140_b_H110"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ+ "r140_b2 DISC_r140_b_H111"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ+ "r140_b2 DISC_r140_b_H112"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ+ "r140_b2 DISC_r140_b_H129"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ+ "r140_b2 DISC_r140_b_H130"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ+ "r140_b2 DISC_r140_b_H131"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ+ "r140_b2 DISC_r140_b_H132"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ+ "r140_b2 DISC_r140_b_H133"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ+ "r140_b2 DISC_r140_b_H134"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ+ "r140_b2 DISC_r140_b_H135"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ+ "r140_b2 DISC_r140_b_H147"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ+ "r140_b2 DISC_r140_b_H520"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ+ "r140_b2 DISC_r140_b_H521"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ+ "r140_b2 DISC_r140_b_H522"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ+ "r140_b2 DISC_r140_b_H523"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ+ "r140_b2 DISC_r140_b_H524"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ+ "r140_b2 DISC_r140_b_H290"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ+ "r140_b3" 
Invoke-Expression $rcmd

$rcmd = $env:QUIZ+ "r140_b3 DISC_r140_b_H262" 
Invoke-Expression $rcmd

$rcmd = $env:QUIZ+ "r140_b3 DISC_r140_b_H289" 
Invoke-Expression $rcmd

$rcmd = $env:QUIZ+ "r140_b3 DISC_r140_b_H513" 
Invoke-Expression $rcmd

$rcmd = $env:QUIZ+ "r140_b3 DISC_r140_b_H514" 
Invoke-Expression $rcmd

$rcmd = $env:QUIZ+ "r140_b3 DISC_r140_b_H515" 
Invoke-Expression $rcmd

$rcmd = $env:QUIZ+ "r140_b3 DISC_r140_b_H516 " 
Invoke-Expression $rcmd

$rcmd = $env:QUIZ+ "r140_b3 DISC_r140_b_H517" 
Invoke-Expression $rcmd

$rcmd = $env:QUIZ+ "r140_b3 DISC_r140_b_H518" 
Invoke-Expression $rcmd

$rcmd = $env:QUIZ+ "r140_b3 DISC_r140_b_H519" 
Invoke-Expression $rcmd

$rcmd = $env:QUIZ+ "r140_b3 DISC_r140_b_H526" 
Invoke-Expression $rcmd

$rcmd = $env:QUIZ+ "r140_b3 DISC_r140_b_H527" 
Invoke-Expression $rcmd

$rcmd = $env:QUIZ+ "r140_b3 DISC_r140_b_H528" 
Invoke-Expression $rcmd

$rcmd = $env:QUIZ+ "r140_b3 DISC_r140_b_H529" 
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content R140_B2.txt > r140_b.txt
echo ""
echo "Done!"
