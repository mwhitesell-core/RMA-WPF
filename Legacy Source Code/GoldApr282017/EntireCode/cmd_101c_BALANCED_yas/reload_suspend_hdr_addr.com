# reload_suspend_hdr_addr.com
# This script is used to reload suspend hdr & addr in selected web directories   


cd $application_root/production/web2
qtp auto=$obj/relof002_susp_hdr.qtc > relof002susphdr.log
qtp auto=$obj/relof002_susp_addr.qtc > relof002suspaddr.log
cd $application_root/production/web4
qtp auto=$obj/relof002_susp_hdr.qtc > relof002susphdr.log
qtp auto=$obj/relof002_susp_addr.qtc > relof002suspaddr.log
cd $application_root/production/web8
qtp auto=$obj/relof002_susp_hdr.qtc > relof002susphdr.log
qtp auto=$obj/relof002_susp_addr.qtc > relof002suspaddr.log
cd $application_root/production/web10
qtp auto=$obj/relof002_susp_hdr.qtc > relof002susphdr.log
qtp auto=$obj/relof002_susp_addr.qtc > relof002suspaddr.log

cd $application_root/production

