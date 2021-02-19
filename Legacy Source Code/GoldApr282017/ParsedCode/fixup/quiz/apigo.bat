del apigo.log
del *.api
del metric.dat
del metric.det
del auxiliary.txt

path=C:\CoreProjects\parser\bin;%path%

quiz rmaFixup check_f001_f002.pre check_f001_f002.api /METRIC=metric.dat /LOG=apigo.log
quiz rmaFixup check_f001_vs_web_amount.pre check_f001_vs_web_amount.api /METRIC=metric.dat /LOG=apigo.log
quiz rmaFixup check_f002.pre check_f002.api /METRIC=metric.dat /LOG=apigo.log
quiz rmaFixup check_f002_bkey.pre check_f002_bkey.api /METRIC=metric.dat /LOG=apigo.log
quiz rmaFixup check_f071.pre check_f071.api /METRIC=metric.dat /LOG=apigo.log
quiz rmaFixup check_f071_detail.pre check_f071_detail.api /METRIC=metric.dat /LOG=apigo.log
quiz rmaFixup checkf002_adj_sub_type.pre checkf002_adj_sub_type.api /METRIC=metric.dat /LOG=apigo.log
