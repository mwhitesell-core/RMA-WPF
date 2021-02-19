#-------------------------------------------------------------------------------
# File 'r140_reports.bk2.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'r140_reports.bk2'
#-------------------------------------------------------------------------------

#file:  r140_reports
# 04/jun/01 b.e. - original

clear
echo "Running `'processing of AFP Conversion Payment file - Reports`'"
echo ""
echo ""

echo ""
echo "Setup of 101c environment"
. $Env:root\macros\setup_rmabill.com   101c
echo ""
echo "Entering `'upload`' directory"
Set-Location $application_upl ; Get-Location

echo "Recreate audit file that is used to confirm that all transactions have been processed"
$pipedInput = @"
create file tmp-governance-payments-file
"@

$pipedInput | qutil++

echo "Remove audit file before starting 101c\MP process"
Remove-Item r140_b1.sf* *> $null

echo "recreating file tmp-counters file ..."
$pipedInput = @"
create file tmp-counters
"@

$pipedInput | qutil++

echo "running r140 reports ..."

&$env:QTP r140_a1

echo "Running 1st part of reports in 101c"

&$env:QUIZ r140_a2
&$env:QUIZ r140_a3
&$env:QUIZ r140_b1

echo "Update file with ALL doctors in governance transaction file"
echo "Runnin g r140v_1  in 101c"
&$env:QTP r140v_1

echo ""
echo "Setup of MP environment"
. $Env:root\macros\setup_rmabill.com  mp

echo ""
echo "Entering `'upload`' directory"
Set-Location $application_upl ; Get-Location

echo "Running 2nd part of reports in MP"

&$env:QUIZ r140_b1

echo "Running r140_b.qtc to update which docs have BEEN PROCESSED in MP"
&$env:QTP r140_b

Get-ChildItem r140_a.txt, r140_b.txt, r140_b_??.txt
echo ""

echo "Return to  of 101c"
. $Env:root\macros\setup_rmabill.com   101c

echo ""
echo "Entering `'upload`' directory"
Set-Location $application_upl ; Get-Location

&$env:QUIZ r140_b2 ;------------------------------
&$env:QUIZ r140_b2 "and select if doc-afp-paym-group = `"H055`" "  "set rep dev disc name        r140_b_H061" `
  "and select if doc-afp-paym-group = `"H061`"" go  "set rep dev disc name        r140_b_H103" `
  "and select if doc-afp-paym-group = `"H103`"" go  "set rep dev disc name        r140_b_H104" `
  "and select if doc-afp-paym-group = `"H104`"" go  "set rep dev disc name        r140_b_H105" `
  "and select if doc-afp-paym-group = `"H105`"" go  "set rep dev disc name        r140_b_H106" `
  "and select if doc-afp-paym-group = `"H106`"" go  "set rep dev disc name        r140_b_H107" `
  "and select if doc-afp-paym-group = `"H107`"" go  "set rep dev disc name        r140_b_H108" `
  "and select if doc-afp-paym-group = `"H108`"" go  "set rep dev disc name        r140_b_H109" `
  "and select if doc-afp-paym-group = `"H109`"" go  "set rep dev disc name        r140_b_H110" `
  "and select if doc-afp-paym-group = `"H110`"" go  "set rep dev disc name        r140_b_H111" `
  "and select if doc-afp-paym-group = `"H111`"" go  "set rep dev disc name        r140_b_H112" `
  "and select if doc-afp-paym-group = `"H112`"" go  "set rep dev disc name        r140_b_H129" `
  "and select if doc-afp-paym-group = `"H129`"" go  "set rep dev disc name        r140_b_H130" `
  "and select if doc-afp-paym-group = `"H130`"" go  "set rep dev disc name        r140_b_H131" `
  "and select if doc-afp-paym-group = `"H131`"" go  "set rep dev disc name        r140_b_H132" `
  "and select if doc-afp-paym-group = `"H132`"" go  "set rep dev disc name        r140_b_H133" `
  "and select if doc-afp-paym-group = `"H133`"" go  "set rep dev disc name        r140_b_H134" `
  "and select if doc-afp-paym-group = `"H134`"" go  "set rep dev disc name        r140_b_H135" `
  "and select if doc-afp-paym-group = `"H135`"" go  "set rep dev disc name        r140_b_H147" `
  "and select if doc-afp-paym-group = `"H147`"" go "; REPORT ONLY groups"
&$env:QUIZ r140_b3 " and select if doc-afp-paym-group = `"H513`""  "set rep dev disc name        r140_b_H514" `
  "and select if doc-afp-paym-group = `"H514`"" go  "set rep dev disc name        r140_b_H515" `
  "and select if doc-afp-paym-group = `"H515`"" go  "set rep dev disc name        r140_b_H516" `
  "and select if doc-afp-paym-group = `"H516`"" go  "set rep dev disc name        r140_b_H517" `
  "and select if doc-afp-paym-group = `"H517`"" go  "set rep dev disc name        r140_b_H518" `
  "and select if doc-afp-paym-group = `"H518`"" go  "set rep dev disc name        r140_b_H519" `
  "and select if doc-afp-paym-group = `"H519`"" go

Move-Item -Force r140_b.txt r140_b_.txt
Get-Content r140_b_.txt, r140_b_H513.txt, r140_b_H514.txt, r140_b_H515.txt, r140_b_H516.txt, r140_b_H517.txt, `
  r140_b_H518.txt, r140_b_H519.txt | Set-Content r140_b.txt

echo "Running r140_b.qtc to update which docs HAVE BEEN PROCESSED in 101c"
&$env:QTP r140_b

echo ""
echo "Done!"
