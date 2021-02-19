del apigo.log
del *.api
del metric.dat
del metric.det
del auxiliary.txt

path=C:\CoreProjects\parser\bin;%path%

qtp rmaFixup createf073_costing.pre createf073_costing.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaFixup del_doctor.pre del_doctor.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaFixup purge_f071.pre purge_f071.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaFixup purge_f071_rma.pre purge_f071_rma.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaFixup update_claims.pre update_claims.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaFixup update_claims_reason.pre update_claims_reason.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaFixup update_f001_f002_sub_type.pre update_f001_f002_sub_type.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaFixup update_f087.pre update_f087.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaFixup update_f087_VH8.pre update_f087_VH8.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaFixup update_susp_hdr_dtl_add_desc.pre update_susp_hdr_dtl_add_desc.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaFixup update_suspend_all_dtl.pre update_suspend_all_dtl.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaFixup update_suspend_hdr.pre update_suspend_hdr.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaFixup update_suspend_hdr_dtl.pre update_suspend_hdr_dtl.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaFixup update_suspend_hdr_dtl_diag.pre update_suspend_hdr_dtl_diag.api /METRIC=metric.dat /LOG=apigo.log
qtp rmaFixup update_suspend_hdr_from_all_dtl.pre update_suspend_hdr_from_all_dtl.api /METRIC=metric.dat /LOG=apigo.log
