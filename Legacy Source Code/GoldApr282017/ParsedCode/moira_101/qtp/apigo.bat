del apigo.log
del *.api
del metric.dat
del metric.det
del auxiliary.txt

path=C:\CoreProjects\parser\bin;%path%

qtp rmaMoira newu706a.pre newu706a.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaMoira u014_u015.pre u014_u015.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaMoira u030b_part2.pre u030b_part2.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaMoira u035c.pre u035c.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaMoira u115a_0.pre u115a_0.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaMoira u115a_1.pre u115a_1.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaMoira u116_pop_excl_dtl.pre u116_pop_excl_dtl.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaMoira u210.pre u210.api /METRIC=metric.dat /LOG=apigo.log
