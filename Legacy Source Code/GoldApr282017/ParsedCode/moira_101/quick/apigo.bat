del apigo.log
del *.api
del metric.dat
del metric.det
del auxiliary.txt

path=C:\CoreProjects\parser\bin;%path%

qdesign rmaMoira d113.pre d113.api /METRIC=metric.dat /LOG=apigo.log
qdesign rmaMoira d705.pre d705.api /METRIC=metric.dat /LOG=apigo.log
qdesign rmaMoira m010_crm.pre m010_crm.api /METRIC=metric.dat /LOG=apigo.log
qdesign rmaMoira m010_crm_d003.pre m010_crm_d003.api /METRIC=metric.dat /LOG=apigo.log
qdesign rmaMoira m010_ins.pre m010_ins.api /METRIC=metric.dat /LOG=apigo.log
qdesign rmaMoira m010_ins_d003.pre m010_ins_d003.api /METRIC=metric.dat /LOG=apigo.log
qdesign rmaMoira m010_ins_f.pre m010_ins_f.api /METRIC=metric.dat /LOG=apigo.log
qdesign rmaMoira m076.pre m076.api /METRIC=metric.dat /LOG=apigo.log
qdesign rmaMoira m116.pre m116.api /METRIC=metric.dat /LOG=apigo.log
qdesign rmaMoira m116b.pre m116b.api /METRIC=metric.dat /LOG=apigo.log
