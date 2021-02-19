batch  << eof_batch
qdesign cc=[dg,rma] auto=compile_qks.qks       > compile_ph_pgms.log
quiz cc=[dg,rma] auto=compile_qzs_alone.qzs   >> compile_ph_pgms.log
quiz cc=[dg,rma] auto=compile_qzs_special.qzs >> compile_ph_pgms.log
eof_batch

