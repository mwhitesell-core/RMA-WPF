del prepgo.log
del *.pre

path=C:\CoreProjects\parser\bin;%path%

set $SRC=C:\Clients\RMA\GoldApr282017\ParsedCode\use
set $PB_SRC=C:\Clients\RMA\GoldApr282017\ParsedCode\use
set $USE=C:\Clients\RMA\GoldApr282017\ParsedCode\use
set $PB_USE=C:\Clients\RMA\GoldApr282017\ParsedCode\use

phprep earnings_revenue_mp.qts earnings_revenue_mp.pre  >> prepgo.log
phprep earnings_revenue_mp_history.qts earnings_revenue_mp_history.pre  >> prepgo.log
phprep f020_info_export.qts f020_info_export.pre  >> prepgo.log
phprep u115a.qts u115a.pre  >> prepgo.log
phprep u115b.qts u115b.pre  >> prepgo.log
phprep u115c.qts u115c.pre  >> prepgo.log
phprep u116.qts u116.pre  >> prepgo.log
phprep u122.qts u122.pre  >> prepgo.log
phprep u130.qts u130.pre  >> prepgo.log
phprep u132_sp_mp.qts u132_sp_mp.pre  >> prepgo.log
phprep yearend_1.qts yearend_1.pre  >> prepgo.log
