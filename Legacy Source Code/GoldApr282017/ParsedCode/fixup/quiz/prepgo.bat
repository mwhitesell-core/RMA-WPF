del prepgo.log
del *.pre

path=C:\CoreProjects\parser\bin;%path%

set $SRC=C:\Clients\RMA\GoldApr282017\ParsedCode\use
set $PB_SRC=C:\Clients\RMA\GoldApr282017\ParsedCode\use
set $USE=C:\Clients\RMA\GoldApr282017\ParsedCode\use
set $PB_USE=C:\Clients\RMA\GoldApr282017\ParsedCode\use

phprep check_f001_f002.qzs check_f001_f002.pre  >> prepgo.log
phprep check_f001_vs_web_amount.qzs check_f001_vs_web_amount.pre  >> prepgo.log
phprep check_f002.qzs check_f002.pre  >> prepgo.log
phprep check_f002_bkey.qzs check_f002_bkey.pre  >> prepgo.log
phprep check_f071.qzs check_f071.pre  >> prepgo.log
phprep check_f071_detail.qzs check_f071_detail.pre  >> prepgo.log
phprep checkf002_adj_sub_type.qzs checkf002_adj_sub_type.pre  >> prepgo.log
