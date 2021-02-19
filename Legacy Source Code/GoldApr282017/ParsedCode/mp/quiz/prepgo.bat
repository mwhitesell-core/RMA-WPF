del prepgo.log
del *.pre

path=C:\CoreProjects\parser\bin;%path%

set $SRC=C:\Clients\RMA\GoldApr282017\ParsedCode\use
set $PB_SRC=C:\Clients\RMA\GoldApr282017\ParsedCode\use
set $USE=C:\Clients\RMA\GoldApr282017\ParsedCode\use
set $PB_USE=C:\Clients\RMA\GoldApr282017\ParsedCode\use

phprep abe.qzs abe.pre  >> prepgo.log
phprep mp_payments.qzs mp_payments.pre  >> prepgo.log
phprep r119a.qzs r119a.pre  >> prepgo.log
phprep r119b.qzs r119b.pre  >> prepgo.log
phprep r119c.qzs r119c.pre  >> prepgo.log
phprep r121a.qzs r121a.pre  >> prepgo.log
phprep r121b.qzs r121b.pre  >> prepgo.log
phprep r121c.qzs r121c.pre  >> prepgo.log
phprep r123d1a.qzs r123d1a.pre  >> prepgo.log
phprep r124a_mp.qzs r124a_mp.pre  >> prepgo.log
phprep r124a_paycode7.qzs r124a_paycode7.pre  >> prepgo.log
phprep r124b_mp.qzs r124b_mp.pre  >> prepgo.log
phprep r124b_paycode7.qzs r124b_paycode7.pre  >> prepgo.log
phprep r124c.qzs r124c.pre  >> prepgo.log
phprep r126.qzs r126.pre  >> prepgo.log
phprep r127.qzs r127.pre  >> prepgo.log
phprep r137.qzs r137.pre  >> prepgo.log
phprep utl0101.qzs utl0101.pre  >> prepgo.log
phprep utl0201.qzs utl0201.pre  >> prepgo.log
