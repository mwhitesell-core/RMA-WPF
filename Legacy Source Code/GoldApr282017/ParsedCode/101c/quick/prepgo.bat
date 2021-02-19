del prepgo.log
del *.pre

path=C:\CoreProjects\parser\bin;%path%

set $SRC=T:\CLIENTS\RMA\GoldApr282017\ParsedCode\use
set $PB_SRC=T:\CLIENTS\RMA\GoldApr282017\ParsedCode\use
set $USE=T:\CLIENTS\RMA\GoldApr282017\ParsedCode\use
set $PB_USE=T:\CLIENTS\RMA\GoldApr282017\ParsedCode\use

phprep d003_1.qks d003_1.pre  >> prepgo.log
phprep d003_1a.qks d003_1a.pre  >> prepgo.log

Rem Conditional Compile
phprep d020.qks d020.pre  /CC=rma >> prepgo.log

phprep d020a.qks d020a.pre  >> prepgo.log
phprep d020b.qks d020b.pre  >> prepgo.log
phprep d085.qks d085.pre  >> prepgo.log
phprep d087.qks d087.pre  >> prepgo.log
phprep d087_dtl.qks d087_dtl.pre  >> prepgo.log
phprep d087_hdr.qks d087_hdr.pre  >> prepgo.log
phprep d110.qks d110.pre  >> prepgo.log
phprep d112.qks d112.pre  >> prepgo.log
phprep d112a.qks d112a.pre  >> prepgo.log
phprep d114.qks d114.pre  >> prepgo.log
phprep d118.qks d118.pre  >> prepgo.log
phprep d119.qks d119.pre  >> prepgo.log
phprep d119gov.qks d119gov.pre  >> prepgo.log
phprep d119tithe.qks d119tithe.pre  >> prepgo.log
phprep d199.qks d199.pre  >> prepgo.log
phprep d705a.qks d705a.pre  >> prepgo.log
phprep d705b.qks d705b.pre  >> prepgo.log
phprep d705c.qks d705c.pre  >> prepgo.log
phprep d713.qks d713.pre  >> prepgo.log
phprep h020a.qks h020a.pre  >> prepgo.log
phprep h110.qks h110.pre  >> prepgo.log
phprep h112.qks h112.pre  >> prepgo.log
phprep h112a.qks h112a.pre  >> prepgo.log
phprep h113.qks h113.pre  >> prepgo.log
phprep h119.qks h119.pre  >> prepgo.log
phprep h119gov.qks h119gov.pre  >> prepgo.log
phprep h119tithe.qks h119tithe.pre  >> prepgo.log
phprep m010.qks m010.pre  >> prepgo.log
phprep m010_acr.qks m010_acr.pre  >> prepgo.log

Rem Conditional Compile
phprep m020.qks m020.pre /CC=rma >> prepgo.log

phprep m020a.qks m020a.pre  >> prepgo.log
phprep m020b.qks m020b.pre  >> prepgo.log
phprep m020c.qks m020c.pre  >> prepgo.log
phprep m021.qks m021.pre  >> prepgo.log
phprep m027.qks m027.pre  >> prepgo.log
phprep m028.qks m028.pre  >> prepgo.log
phprep m029.qks m029.pre  >> prepgo.log
phprep m040_dtl.qks m040_dtl.pre  >> prepgo.log
phprep m074.qks m074.pre  >> prepgo.log
phprep m074a.qks m074a.pre  >> prepgo.log
phprep m075.qks m075.pre  >> prepgo.log
phprep m083.qks m083.pre  >> prepgo.log
phprep m088.qks m088.pre  >> prepgo.log
phprep m088_1.qks m088_1.pre  >> prepgo.log
phprep m088_1a.qks m088_1a.pre  >> prepgo.log
phprep m090.qks m090.pre  >> prepgo.log
phprep m090a.qks m090a.pre  >> prepgo.log
phprep m090f.qks m090f.pre  >> prepgo.log
phprep m090g.qks m090g.pre  >> prepgo.log
phprep m091.qks m091.pre  >> prepgo.log
phprep m092.qks m092.pre  >> prepgo.log
phprep m093.qks m093.pre  >> prepgo.log
phprep m096.qks m096.pre  >> prepgo.log
phprep m098.qks m098.pre  >> prepgo.log
phprep m101.qks m101.pre  >> prepgo.log
phprep m102.qks m102.pre  >> prepgo.log
phprep m113.qks m113.pre  >> prepgo.log
phprep m115.qks m115.pre  >> prepgo.log
phprep m123.qks m123.pre  >> prepgo.log
phprep m190a.qks m190a.pre  >> prepgo.log
phprep m190b.qks m190b.pre  >> prepgo.log
phprep m191.qks m191.pre  >> prepgo.log
phprep m199.qks m199.pre  >> prepgo.log
phprep m200.qks m200.pre  >> prepgo.log
phprep m201.qks m201.pre  >> prepgo.log
phprep m902.qks m902.pre  >> prepgo.log
phprep m920.qks m920.pre  >> prepgo.log
phprep m923.qks m923.pre  >> prepgo.log
phprep m940.qks m940.pre  >> prepgo.log
phprep ohip_run_dates.qks ohip_run_dates.pre  >> prepgo.log
phprep sy030.qks sy030.pre  >> prepgo.log
phprep sy033.qks sy033.pre  >> prepgo.log
phprep utl1000.qks utl1000.pre  >> prepgo.log
phprep utl1001.qks utl1001.pre  >> prepgo.log
phprep utl1002.qks utl1002.pre  >> prepgo.log
