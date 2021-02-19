#-------------------------------------------------------------------------------
# File 'run_reload_payroll.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_reload_payroll'
#-------------------------------------------------------------------------------

# RUN_RELOAD_PAYROLL
# RMA Physician Payroll QTP $obj/greload.
# This script runs the QTP programs that $obj/greload the files 
# in test from the subfiles that were created from production.
# Created by S. Bachmann on Jan. 27, 1999
# 1999/may/03 B.E. added delete/cr-create of data files before reload

echo "Physician Payroll QTP $obj\greload."
echo "Recreating empty PH only files"
Set-Location $pb_data
Get-Location
Remove-Item f1*
$pipedInput = @"
create file f110-compensation
create file f110-compensation-history
create file f112-pycdceilings
create file f112-pycdceilings-history
create file f113-default-comp
create file f113-default-comp-history
create file f119-doctor-ytd-history
create file f190-comp-codes
create file f191-earnings-period
create file f198-user-defined-totals
create file f199-user-defined-fields
"@

$pipedInput | qutil++
echo "Recreating empty PH\cobol files"
Remove-Item f020_doctor_mstr*
Remove-Item f020_doctor_extra*
Remove-Item f050_doc_revenue_mstr*
Remove-Item f090_constants_mstr*

Copy-Item $Env:root\alpha\rmabill\rmabill102\data\f020_doctor_extra.dat f020_doctor_extra.dat
Copy-Item $Env:root\alpha\rmabill\rmabill102\data\f020_doctor_extra.idx f020_doctor_extra.idx
Copy-Item $Env:root\alpha\rmabill\rmabill102\data\f050_doc_revenue_mstr f050_doc_revenue_mstr
Copy-Item $Env:root\alpha\rmabill\rmabill102\data\f050_doc_revenue_mstr.idx f050_doc_revenue_mstr.idx
Copy-Item $Env:root\alpha\rmabill\rmabill102\data\f119_doctor_ytd.dat f119_doctor_ytd.dat
Copy-Item $Env:root\alpha\rmabill\rmabill102\data\f119_doctor_ytd.idx f119_doctor_ytd.idx

. .\createfiles.com

echo "Reloading files ..."
&$env:QTP relof020 ";execute $obj/relof020hst"
&$env:QTP relof090_1
&$env:QTP relof090_2
&$env:QTP relof090_3
&$env:QTP relof090_4
&$env:QTP relof090_5
&$env:QTP relof090_6
&$env:QTP relof090_iconst
&$env:QTP relof110
&$env:QTP relof110hst
&$env:QTP relof112
&$env:QTP relof112hst
&$env:QTP relof113
&$env:QTP relof113hst
&$env:QTP relof119hst
&$env:QTP relof190
&$env:QTP relof191
&$env:QTP relof199
