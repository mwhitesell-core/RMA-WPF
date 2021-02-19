del prepgo.log
del *.pre

path=C:\CoreProjects\parser\bin;%path%

set $SRC=C:\Clients\RMA\GoldApr282017\ParsedCode\use
set $PB_SRC=C:\Clients\RMA\GoldApr282017\ParsedCode\use
set $USE=C:\Clients\RMA\GoldApr282017\ParsedCode\use
set $PB_USE=C:\Clients\RMA\GoldApr282017\ParsedCode\use

phprep d020.qks d020.pre  >> prepgo.log
phprep d020a.qks d020a.pre  >> prepgo.log
phprep d112a.qks d112a.pre  >> prepgo.log
phprep d113.qks d113.pre  >> prepgo.log
phprep d114.qks d114.pre  >> prepgo.log
phprep d119.qks d119.pre  >> prepgo.log
phprep h119.qks h119.pre  >> prepgo.log
phprep m020.qks m020.pre /CC=rma >> prepgo.log
phprep m074.qks m074.pre  >> prepgo.log
phprep m075.qks m075.pre  >> prepgo.log
phprep m100.qks m100.pre  >> prepgo.log
