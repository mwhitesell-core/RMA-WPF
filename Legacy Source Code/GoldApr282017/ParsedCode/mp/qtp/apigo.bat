del apigo.log
del *.api
del metric.dat
del metric.det
del auxiliary.txt

path=C:\CoreProjects\parser\bin;%path%

qtp rmaMp earnings_revenue_mp.pre earnings_revenue_mp.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaMp earnings_revenue_mp_history.pre earnings_revenue_mp_history.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaMp f020_info_export.pre f020_info_export.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaMp u115a.pre u115a.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaMp u115b.pre u115b.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaMp u115c.pre u115c.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaMp u116.pre u116.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaMp u122.pre u122.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaMp u130.pre u130.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaMp u132_sp_mp.pre u132_sp_mp.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaMp yearend_1.pre yearend_1.api /METRIC=metric.dat /LOG=apigo.log
