del apigo.log
del *.api
del metric.dat
del metric.det
del auxiliary.txt

path=C:\CoreProjects\parser\bin;%path%

qdesign rmaFixup create_f001.pre create_f001.api /METRIC=metric.dat /LOG=apigo.log
