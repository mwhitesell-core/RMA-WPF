# 2003/nov/20 b.e. 	- added u021a.cb
# 2014/may/13 MC1  	- added r153a/b.cbl
cobcomp cpirma.cbl b
read garbage
cobcomp createf020f090.cbl b
read garbage
cobcomp createf085.cbl b
read garbage
cobcomp createfiles.cbl b
read garbage
cobcomp createpatid.cbl b
read garbage
cobcomp createsusp.cbl b
read garbage
#cobcomp createsuspendfiles.cbl b - not exist 
cobcomp d001.cbl b
read garbage
cobcomp d002.cbl b
read garbage
cobcomp d003.cbl b
read garbage
cobcomp d004.cbl b
read garbage
cobcomp d050.cbl b
read garbage
cobcomp m030.cbl b
read garbage
cobcomp m040.cbl b
read garbage
cobcomp m070.cbl b
read garbage
cobcomp m080.cbl b
read garbage
cobcomp m090.cbl b
read garbage
cobcomp m094.cbl b
read garbage
cobcomp m095.cbl b
read garbage
cobcomp newu701.cbl b
read garbage
cobcomp newu703.cbl b
read garbage
cobcomp r001.cbl b
read garbage
cobcomp r001b.cbl b
read garbage
cobcomp r002a.cbl b
read garbage
cobcomp r002b.cbl b
read garbage
cobcomp r004_cycle.cbl b
read garbage
cobcomp r004a.cbl b
read garbage
cobcomp r004b.cbl b
read garbage
cobcomp r004c.cbl b
read garbage
cobcomp r005.cbl b
read garbage
cobcomp r010cycle.cbl b
read garbage
cobcomp r011.cbl b
read garbage
cobcomp r012.cbl b
read garbage
cobcomp r013.cbl b
read garbage
cobcomp r014.cbl b
read garbage
cobcomp r014sum.cbl b
read garbage
cobcomp r040.cbl b
read garbage
cobcomp r051a.cbl b
read garbage
cobcomp r051b.cbl b
read garbage
cobcomp r051c.cbl b
read garbage
cobcomp r070a.cbl b
read garbage
cobcomp r070b.cbl b
read garbage
cobcomp r070c.cbl b
read garbage
cobcomp r071.cbl b
read garbage
cobcomp r073.cbl b
read garbage
cobcomp r123a.cbl b
read garbage
cobcomp r123b.cbl b
read garbage
cobcomp r150a.cbl b
read garbage
cobcomp r150b.cbl b
read garbage
cobcomp r150c.cbl b
read garbage
cobcomp r153a.cbl b
read garbage
cobcomp r153b.cbl b
read garbage
cobcomp r992.cbl b
read garbage
##cobcomp u010daily.cbl b - replaced by u010daily.qts
cobcomp u011.cbl b
read garbage
cobcomp u015.cbl b
read garbage
cobcomp u015tp.cbl b
read garbage
cobcomp u021a.cbl b
read garbage
cobcomp u030a.cbl b
read garbage
cobcomp u030aa1.cbl b
read garbage
cobcomp u030aa2.cbl b
read garbage
cobcomp u030c.cbl b
read garbage
## 2003/04/02 - MC
##  cobcomp u031a.cbl b - has renamed to u021a.cbl
## 2003/04/02 - end
cobcomp u035a.cbl b
read garbage
cobcomp u035b.cbl b
read garbage
cobcomp u035c.cbl b
read garbage
#cobcomp u035c_y2k_layout.cbl b
read garbage
cobcomp u035cnoupd.cbl b
read garbage
cobcomp u040.cbl b
read garbage
cobcomp u041.cbl b
read garbage
##cobcomp u080.cbl b - convert to u080.qts
#cobcomp u080fixpat.cbl b
cobcomp u093.cbl b
read garbage
cobcomp u095.cbl b
read garbage
cobcomp u099.cbl b
read garbage
cobcomp u701.cbl b
read garbage
cobcomp u706b.cbl b
read garbage
cobcomp u801_9000.cbl b
read garbage
cobcomp u888.cbl b
read garbage
cobcomp u991.cbl b
read garbage
cobcomp u992.cbl b
read garbage
cobcomp u993.cbl b
read garbage
cobcomp u999.cbl b
read garbage
