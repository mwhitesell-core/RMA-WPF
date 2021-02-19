batch  << eof_batch
qtp  cc=[dg,rma] auto=comp_pay_qts.qts         > compile_payroll_ph_pgms.log
eof_batch

