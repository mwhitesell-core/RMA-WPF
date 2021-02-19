# reload_suspend_hdr.com
# This script is used to reload suspend hdr in selected web directories   


cd $application_root/production/web2
qtp auto=$obj/relof002_susp_hdr.qtc > relof002susphdr.log
cd $application_root/production/web3
qtp auto=$obj/relof002_susp_hdr.qtc > relof002susphdr.log
cd $application_root/production/web5
qtp auto=$obj/relof002_susp_hdr.qtc > relof002susphdr.log
cd $application_root/production/web7
qtp auto=$obj/relof002_susp_hdr.qtc > relof002susphdr.log
cd $application_root/production/web8
qtp auto=$obj/relof002_susp_hdr.qtc > relof002susphdr.log


cd $application_root/production
