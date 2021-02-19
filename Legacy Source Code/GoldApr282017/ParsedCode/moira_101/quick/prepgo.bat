del prepgo.log
del *.pre

path=C:\CoreProjects\parser\bin;%path%

set $SRC=C:\Clients\RMA\GoldApr282017\ParsedCode\use
set $PB_SRC=C:\Clients\RMA\GoldApr282017\ParsedCode\use
set $USE=C:\Clients\RMA\GoldApr282017\ParsedCode\use
set $PB_USE=C:\Clients\RMA\GoldApr282017\ParsedCode\use

phprep d113.qks d113.pre  >> prepgo.log
phprep d705.qks d705.pre  >> prepgo.log
phprep m010_crm.qks m010_crm.pre  >> prepgo.log
phprep m010_crm_d003.qks m010_crm_d003.pre  >> prepgo.log
phprep m010_ins.qks m010_ins.pre  >> prepgo.log
phprep m010_ins_d003.qks m010_ins_d003.pre  >> prepgo.log
phprep m010_ins_f.qks m010_ins_f.pre  >> prepgo.log
phprep m076.qks m076.pre  >> prepgo.log
phprep m116.qks m116.pre  >> prepgo.log
phprep m116b.qks m116b.pre  >> prepgo.log
