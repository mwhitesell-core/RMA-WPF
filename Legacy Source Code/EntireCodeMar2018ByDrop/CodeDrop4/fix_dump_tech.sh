# 2010/02/23  yas    - This program will zero out the tech amount in f002-hdr and f002-dtl
#                    - dump_tech.qzs will create dump_tech.sf and dump_tech.txt and 
#                    - $obj/fix_dump_tech.qtc will use the subfile to zero tech amounts 


qtp << qtp_EXIT
exe $obj/fix_dump_tech.qtc
qtp_EXIT
