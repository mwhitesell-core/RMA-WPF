del apigo.log
del *.api
del metric.dat
del metric.det
del auxiliary.txt

path=C:\CoreProjects\parser\bin;%path%

quiz rmaYas auditors_payeft_ytd.pre auditors_payeft_ytd.api /METRIC=metric.dat /LOG=apigo.log
quiz rmaYas checkf020_active_doc.pre checkf020_active_doc.api /METRIC=metric.dat /LOG=apigo.log
quiz rmaYas costing_f119hist.pre costing_f119hist.api /METRIC=metric.dat /LOG=apigo.log
quiz rmaYas docinfo.pre docinfo.api /METRIC=metric.dat /LOG=apigo.log
quiz rmaYas drchaudhary_rejects.pre drchaudhary_rejects.api /METRIC=metric.dat /LOG=apigo.log
quiz rmaYas emergency_payroll_clmhdrid.pre emergency_payroll_clmhdrid.api /METRIC=metric.dat /LOG=apigo.log
quiz rmaYas f087_peds_rejects_by_errcode.pre f087_peds_rejects_by_errcode.api /METRIC=metric.dat /LOG=apigo.log
quiz rmaYas f119hist_afpadj_afpcon.pre f119hist_afpadj_afpcon.api /METRIC=metric.dat /LOG=apigo.log
quiz rmaYas f119tithe.pre f119tithe.api /METRIC=metric.dat /LOG=apigo.log
quiz rmaYas g271_code.pre g271_code.api /METRIC=metric.dat /LOG=apigo.log
quiz rmaYas geriatric.pre geriatric.api /METRIC=metric.dat /LOG=apigo.log
quiz rmaYas k037_code.pre k037_code.api /METRIC=metric.dat /LOG=apigo.log
quiz rmaYas tithe3.pre tithe3.api /METRIC=metric.dat /LOG=apigo.log
quiz rmaYas yasclare.pre yasclare.api /METRIC=metric.dat /LOG=apigo.log
