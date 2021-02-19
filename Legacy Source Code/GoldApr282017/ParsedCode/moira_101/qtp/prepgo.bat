del prepgo.log
del *.pre

path=C:\CoreProjects\parser\bin;%path%

set $SRC=C:\Clients\RMA\GoldApr282017\ParsedCode\use
set $PB_SRC=C:\Clients\RMA\GoldApr282017\ParsedCode\use
set $USE=C:\Clients\RMA\GoldApr282017\ParsedCode\use
set $PB_USE=C:\Clients\RMA\GoldApr282017\ParsedCode\use

phprep newu706a.qts newu706a.pre  >> prepgo.log
phprep u014_u015.qts u014_u015.pre  >> prepgo.log
phprep u030b_part2.qts u030b_part2.pre  >> prepgo.log
phprep u035c.qts u035c.pre  >> prepgo.log
phprep u115a_0.qts u115a_0.pre  >> prepgo.log
phprep u115a_1.qts u115a_1.pre  >> prepgo.log
phprep u116_pop_excl_dtl.qts u116_pop_excl_dtl.pre  >> prepgo.log
phprep u210.qts u210.pre  >> prepgo.log
