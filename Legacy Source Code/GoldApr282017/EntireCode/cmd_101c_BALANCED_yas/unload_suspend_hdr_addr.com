# unload_suspend_hdr_addr.com
# This script is used to unload suspend hdr  & addr in selected web directories   


cd $application_root/production/web2
cp f002_suspend_hdr      f002_suspend_hdr.idx      backup
cp f002_suspend_address  f002_suspend_address.idx  backup
qtp auto=$obj/unlof002_susp_hdr.qtc > unlof002susphdr.log
qtp auto=$obj/unlof002_susp_addr.qtc > unlof002suspaddr.log
cd $application_root/production/web4
cp f002_suspend_hdr      f002_suspend_hdr.idx      backup
cp f002_suspend_address  f002_suspend_address.idx  backup
qtp auto=$obj/unlof002_susp_hdr.qtc > unlof002susphdr.log
qtp auto=$obj/unlof002_susp_addr.qtc > unlof002suspaddr.log
cd $application_root/production/web8
cp f002_suspend_hdr      f002_suspend_hdr.idx      backup
cp f002_suspend_address  f002_suspend_address.idx  backup
qtp auto=$obj/unlof002_susp_hdr.qtc > unlof002susphdr.log
qtp auto=$obj/unlof002_susp_addr.qtc > unlof002suspaddr.log
cd $application_root/production/web10
cp f002_suspend_hdr      f002_suspend_hdr.idx      backup
cp f002_suspend_address  f002_suspend_address.idx  backup
qtp auto=$obj/unlof002_susp_hdr.qtc > unlof002susphdr.log
qtp auto=$obj/unlof002_susp_addr.qtc > unlof002suspaddr.log

cd $application_root/production

