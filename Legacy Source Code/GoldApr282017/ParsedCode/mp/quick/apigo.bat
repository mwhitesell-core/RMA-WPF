del apigo.log
del *.api
del metric.dat
del metric.det
del auxiliary.txt

path=C:\CoreProjects\parser\bin;%path%

qdesign rmaMp d020.pre d020.api /METRIC=metric.dat /LOG=apigo.log
qdesign rmaMp d020a.pre d020a.api /METRIC=metric.dat /LOG=apigo.log
qdesign rmaMp d112a.pre d112a.api /METRIC=metric.dat /LOG=apigo.log
qdesign rmaMp d113.pre d113.api /METRIC=metric.dat /LOG=apigo.log
qdesign rmaMp d114.pre d114.api /METRIC=metric.dat /LOG=apigo.log
qdesign rmaMp d119.pre d119.api /METRIC=metric.dat /LOG=apigo.log
qdesign rmaMp h119.pre h119.api /METRIC=metric.dat /LOG=apigo.log
qdesign rmaMp m020.pre m020.api /METRIC=metric.dat /LOG=apigo.log
qdesign rmaMp m074.pre m074.api /METRIC=metric.dat /LOG=apigo.log
qdesign rmaMp m075.pre m075.api /METRIC=metric.dat /LOG=apigo.log
qdesign rmaMp m100.pre m100.api /METRIC=metric.dat /LOG=apigo.log
