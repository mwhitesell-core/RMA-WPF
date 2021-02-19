#-------------------------------------------------------------------------------
# File 'payroll_file_create.qus.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'payroll_file_create.qus'
#-------------------------------------------------------------------------------

# PAYROLL_FILE_CREATE.QUS
# This program is used to create the files that get unloaded from
# production and reloaded into test. (Physician Payroll)
# Created by S. Bachmann on Jan. 27, 1999

$pipedInput = @"
create file f020-doc-mstr-history
create file f110-compensation
create file f110-compensation-history
create file f112-pycdceilings
create file f112-pycdceilings-history
create file f113-default-comp
create file f113-default-comp-history
create file f190-comp-codes
create file f191-earnings-period
create file f199-user-defined-fields
"@

$pipedInput | qutil++
