del prepgo.log
del *.pre

path=C:\CoreProjects\parser\bin;%path%

set $SRC=C:\Clients\RMA\GoldApr282017\ParsedCode\use
set $PB_SRC=C:\Clients\RMA\GoldApr282017\ParsedCode\use
set $USE=C:\Clients\RMA\GoldApr282017\ParsedCode\use
set $PB_USE=C:\Clients\RMA\GoldApr282017\ParsedCode\use

phprep auditors_payeft_ytd.qzs auditors_payeft_ytd.pre  >> prepgo.log
phprep checkf020_active_doc.qzs checkf020_active_doc.pre  >> prepgo.log
phprep costing_f119hist.qzs costing_f119hist.pre  >> prepgo.log
phprep docinfo.qzs docinfo.pre  >> prepgo.log
phprep drchaudhary_rejects.qzs drchaudhary_rejects.pre  >> prepgo.log
phprep emergency_payroll_clmhdrid.qzs emergency_payroll_clmhdrid.pre  >> prepgo.log
phprep f087_peds_rejects_by_errcode.qzs f087_peds_rejects_by_errcode.pre  >> prepgo.log
phprep f119hist_afpadj_afpcon.qzs f119hist_afpadj_afpcon.pre  >> prepgo.log
phprep f119tithe.qzs f119tithe.pre  >> prepgo.log
phprep g271_code.qzs g271_code.pre  >> prepgo.log
phprep geriatric.qzs geriatric.pre  >> prepgo.log
phprep k037_code.qzs k037_code.pre  >> prepgo.log
phprep tithe3.qzs tithe3.pre  >> prepgo.log
phprep yasclare.qzs yasclare.pre  >> prepgo.log
