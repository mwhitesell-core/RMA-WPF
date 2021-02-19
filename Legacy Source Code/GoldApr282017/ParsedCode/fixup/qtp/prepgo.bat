del prepgo.log
del *.pre

path=C:\CoreProjects\parser\bin;%path%

set $SRC=C:\Clients\RMA\GoldApr282017\ParsedCode\use
set $PB_SRC=C:\Clients\RMA\GoldApr282017\ParsedCode\use
set $USE=C:\Clients\RMA\GoldApr282017\ParsedCode\use
set $PB_USE=C:\Clients\RMA\GoldApr282017\ParsedCode\use

phprep createf073_costing.qts createf073_costing.pre  >> prepgo.log
phprep del_doctor.qts del_doctor.pre  >> prepgo.log
phprep purge_f071.qts purge_f071.pre  >> prepgo.log
phprep purge_f071_rma.qts purge_f071_rma.pre  >> prepgo.log
phprep update_claims.qts update_claims.pre  >> prepgo.log
phprep update_claims_reason.qts update_claims_reason.pre  >> prepgo.log
phprep update_f001_f002_sub_type.qts update_f001_f002_sub_type.pre  >> prepgo.log
phprep update_f087.qts update_f087.pre  >> prepgo.log
phprep update_f087_VH8.qts update_f087_VH8.pre  >> prepgo.log
phprep update_susp_hdr_dtl_add_desc.qts update_susp_hdr_dtl_add_desc.pre  >> prepgo.log
phprep update_suspend_all_dtl.qts update_suspend_all_dtl.pre  >> prepgo.log
phprep update_suspend_hdr.qts update_suspend_hdr.pre  >> prepgo.log
phprep update_suspend_hdr_dtl.qts update_suspend_hdr_dtl.pre  >> prepgo.log
phprep update_suspend_hdr_dtl_diag.qts update_suspend_hdr_dtl_diag.pre  >> prepgo.log
phprep update_suspend_hdr_from_all_dtl.qts update_suspend_hdr_from_all_dtl.pre  >> prepgo.log
