#-------------------------------------------------------------------------------
# File 'all_files_create.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'all_files_create.com'
#-------------------------------------------------------------------------------

# all_files_create.com
# This program is used to create the files that get unloaded from
# production and reloaded into test. 

Set-Location $pb_data
. .\createfiles.com

Set-Location $env:application_production
$pipedInput = @"
create file contract-dtl
create file contract-mstr
create file doc-totals-tmp

create file f020-doc-mstr-history
create file f020-doctor-extra
create file f021-avail-doctor-mstr
create file f022-deleted-doc-mstr
create file f023-alternative-doctor-nbr  
create file f024-referring-doctor 
create file f026-doctor-options

create file f050-doc-revenue-mstr-history
create file f050tp-doc-revenue-mstr-history

create file f087-man-rejected-claims-hist

create file f097-spec-cd-mstr
create file f098-equiv-oma-code-mstr
create file f099-group-claim-mstr

create file f110-compensation
create file f110-compensation-history
create file f112-pycdceilings
create file f112-pycdceilings-history
create file f113-default-comp
create file f113-default-comp-history
create file f119-doctor-ytd
create file f119-doctor-ytd-history  

create file f190-comp-codes
create file f191-earnings-period
create file f198-user-defined-totals
create file f199-user-defined-fields

;           f085_rejected_claims
create file rejected-claims

create file social-contract-factor

;           f095_text_lines
create file text-lines

"@

$pipedInput | qutil++
