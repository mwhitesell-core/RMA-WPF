﻿New-PSSession -ComputerName rmascripts.coremig.local
cd \\rmascripts.coremig.local\rma
mkdir alpha
cd alpha
mkdir backups,cognos,dgux_kernel,home_RMA,pop3,pop3_dg,recover_info,rmabill,tmp
cd cognos
mkdir licensebkp,pg205,ph733e,ph813d1
cd pg205
mkdir doc,install,tcpip
cd tcpip
mkdir netbin,network
cd ../..
cd ph733e
mkdir bin,doc,doextdemo,lib,link,man,migrate,msg,qkgo,sflib,stdpdl
cd man
mkdir deutsch,english,francais
cd ../migrate
mkdir aosvs,mpexl,vms
cd ../msg
mkdir deutsch,english,francais,japanese
cd ../qkgo
mkdir resource
cd ../..
cd ph813d1
mkdir bin,doc,lib,msg,qkgo,sflib,stdpdl
cd msg
mkdir deutsch,english,francais
cd ../qkgo
mkdir resource
cd ../../..
cd home_RMA
mkdir brad,moira,root
cd ../..
mkdir macros
cd macros
mkdir anzio,ivaco_scripts_awk,rma
cd ..
mkdir macros_rma
cd macros_rma
mkdir anzio,ivaco_scripts_awk, rma
cd ..
mkdir beta
cd beta
mkdir hscbill,ma_101c,phtmp,rmabill,tmp
cd hscbill
mkdir backup_transfer_area,hscbill101
cd hscbill101
mkdir backups,batch,cmd,data,data_orig,doc,dvlp,dvlp_bk_2005_05_06,history,obj,production,purge_2010,src,src_fixup,use
cd cmd
mkdir oldcmd
cd ../dvlp
mkdir abol,brad,dave,moira
cd ../dvlp_bk_2005_05_06
mkdir brucea
cd ../obj
mkdir oldobj
cd ../production
mkdir clinic_2265,clinic_3333,clinic_9999,diag_file_1,diag_file_2,diag_set1,diag_set2,diag_set3,fixup,logs,ma0001,moira,u021_logs
cd moira
mkdir rerun
cd ../u021_logs
mkdir 2011_01_05.13:34,2011_01_25.11:22,2011_02_22.15:36,2011_03_29.13:29,2011_04_28.13:19,2011_05_26.16:28,2011_06_23.15:19,2011_07_21.15:26,2011_08_23.11:08
cd ../../src
mkdir backup, fixup, oldsrc
cd ../use
mkdir olduse
cd ../../../rmabill
mkdir rmabill101, rmabill101c, rmabillsolotest
cd rmabill101
mkdir backups, cmd, data, dvlp, obj, obj_20160705,obj_before_f001,obj_compile,production,production_201413,src,src_missing_files_moira,use
cd cmd
mkdir backup_macros,moira,oldcmd,u123_backup
cd ..
cd dvlp
mkdir abol,brad,dave,moira,moira_old,moira_works_but_using_ytdear_not_ytdinc,yas
cd brad
mkdir a0002q,paySum
cd a0002q
mkdir d1,d2,d3
cd ../../moira
mkdir claims_purge,disk,moira
cd ../moira_works_but_using_ytdear_not_ytdinc
mkdir agep,backup_oct28_2_30,ph_src
cd ../../obj
mkdir a002ka,backup_r123_nodelete
cd ../obj_20160705
mkdir backup_r123_nodelete,oldobj
cd ../obj_before_f001
mkdir backup_r123_nodelete,oldobj
cd ../production
mkdir moira
cd ../src
mkdir canbedel,fixup,oldsrc
cd ../use
mkdir olduse
cd ../../rmabillsolotest
mkdir batch,data,data2,production
cd \\rmascripts\rma
mkdir charly
cd charly
mkdir alpha,backup_transfer_area,rmabill,purge,tmp
cd alpha
mkdir home
cd home
mkdir rma/app-defaults,rma01,rma02,rma03,rma04,rma05,rma06,rma07,rma08,rma09,rma10,rma11/app-defaults,rma12/app-defaults,rma13/app-defaults
mkdir rma14/app-defaults,rma15/app-defaults,rma16/app-defaults,rma17/app-defaults,rma18/app-defaults,rma19/app-defaults,rma20/app-defaults,rma21/app-defaults,rma22/app-defaults,rma23/app-defaults,rma24/app-defaults,rma25/app-defaults
mkdir rma26/app-defaults,rma27/app-defaults,rma28/app-defaults,hsc/app-defaults,rma29/app-defaults,rma30/app-defaults,rma31,rma32,rma33,rma34
mkdir rma35,rma1/app-defaults,rma2,rma3/app-defaults,rma4/app-defaults,rma5/app-defaults,rma6/app-defaults,rma7/app-defaults,rma8/app-defaults,rma9/app-defaults,rma81/app-defaults,rmaHam2,rma_mp/app-defaults,rma_orig_dir_canbdel/app-defaults,rma_orig_dir_canbdel/edt_rat
mkdir rma_solo,rma_icu/app-defaults,brad,moira/app-defaults,abol,dave/app-defaults,hsc01/app-defaults,hsc01/backup,hsc02/app-defaults,hsc03/app-defaults,hsc04/app-defaults,hsc04/backup
mkdir hsc05/app-defaults,hsc05/backup,hsc06/app-defaults,hsc07/app-defaults,hsc09/app-defaults,hsc10/app-defaults,hsc_dyad,outside,root,samb/app-defaults,stu/app-defaults
mkdir test1/app-defaults,test_101/app-defaults,yas
cd brad
mkdir app-defaults,pplay,myDir,FPP/p,FPP/p/cmp_details,FPP/p/cmp_summary, FPP/p/cmp_p,FPP/r,rmahma3_ubuntu,backup_rmaham4,remotepc,Brad_backups,tccac,vpn,backups/rmaham4
mkdir xx,pc_backups,oscar_scripts/local
cd ../abol
mkdir app-defaults,cota/cdbl,cdbl,NY/oldpplay,NY/data_powerplay,intercon,client9x
cd ..\..\..\rmabill
mkdir rmabill101,rmabillsolo,rmabillmp,rmabill101c
mkdir rmabillsolo/data,rmabillsolo/production,rmabillsolo/production/canbedel,rmabillsolo/data2,rmabillsolo/data2/ma/backup
mkdir rmabillmp/data,rmabillmp/dvlp/brad,rmabillmp/dvlp/moira/Jan2013_payroll_problems,rmabillmp/dvlp/moira/Jun2013_payroll_problems,rmabillmp/dvlp/rma,rmabillmp/dvlp/yas
mkdir rmabillmp/src/backup_r123,rmabillmp/src/fixup,rmabillmp/src/oldsrc,rmabillmp/src/prodsrc,rmabillmp/obj/backup_r123_pgms,rmabillmp/obj/oldobj,rmabillmp/obj/oldobj_bkp
mkdir rmabillmp/production/moira,rmabillmp/production/backup,rmabillmp/production/brad_eft,rmabillmp/production/canbedel,rmabillmp/production/rerun_r150
mkdir rmabillmp/data2/ma/backup,rmabill101c/data,rmabill101c/olddata
cd ..\purge
mkdir costing/noweb
cd ../../
mkdir dyad
cd dyad
mkdir backup_transfer_area,rmabill/rmabill101c,foxtrot
cd rmabill/rmabill101c
mkdir use/olduse,upload/xxx,upload/backup,upload/moira,upload/test,src/fixup/backup,src/fixup/101c,src/fixup/solo,src/oldsrc,src/yas/backup,src/yas/yas_bk1,src/yas/moira
mkdir src/prodsrc,src/yas_bk1,production,obj/backups_r123_pgms,obj/oldobj,backups,batch,cmd/backup,cmd/canbedel,cmd/oldcmd,cmd/prodcmd,data,doc/backup,dvlp,data2,olddata/backup,+w
cd production
mkdir 22,23,24,25,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,60,61,62,63,64,65,66,68,69,70,71,72,73,74,75,78,79,80,81,82,83,84,85,86,87,88,89,91,92,93/backup
mkdir 94,95,96,98,moira,web/canbedel,30,26,oscar12,oscar5,oscar6,yasemin/noweb,yasemin/yearend2004,yasemin/yearend2005,yasemin/yearend2006,yasemin/yearend2007,yasemin/yearend2008
mkdir yasemin/yearend2009,yasemin/yearend2010,yasemin/yearend2011,yasemin/yearend2012,yasemin/yearend2013,yasemin/yearend2014,yasemin/yearend2015,yasemin/yearend2016
mkdir disk1,disk2,disk3,disk4,disk5,disk6,disk7,disk8,disk9,disk10,kathy,web1/moira,web1/canbedel,web2/canbedel,web3/backup,web3/canbedel,web4/canbedel,web5/canbedel
mkdir web5/backup,web6/canbedel,web7/canbedel,web8/canbedel,web9/canbedel,web10/canbedel,web10/backup,web10/production/web10,oscar/yas,oscar/test/test,oscar/test1
mkdir oscar/test2,oscar/test3,oscar/test4_va,oscar/test4_ja,oscar/testgi,oscar/bradsFiles,oscar1,oscar2,oscar3,oscarbk,oscar4,oscar7,oscar8,oscar9,oscar11,oscar13,oscar10
mkdir oscar14,oscar15,oscar16,oscar17,r134_r135_r136,oscar18,oscar19,oscar20,oscar21
cd ../dvlp
mkdir abol/reload,brad/myDir,dave,moira,rma,yas/src/yasemin
cd moira
mkdir temp2,ph_src,Jan2010_problems,Nov2009_ME_clinic78_79_problems,Aug2010_payroll_problems,temp3,Jan2012_claims_purge,Feb2012_ME_60_70_problems,2013_11_payroll_problems,Sep2009_payroll_problems
mkdir May2011_ME_problems,Oct2012_ME_problems,Jul2009_ME_problems,Dec2009_ME_problems,Mar2012_ME_60_70_problems,Mar2012_RAT_problems,Oct2012_payroll_problems,Jul2012_yearend_payroll_problems
mkdir Jul2011_yearend_payroll_problems,Dec2009_ME_clinic_78_79_problems,Apr2009_ME_clinic70_problems,Dec2009_payroll_problems,Feb2009_payroll_problems,Jan2010_payroll_problems,Mar2009_payroll_problems
mkdir Oct2009_payroll_problems,Apr2012_RAT_problems,May2012_ME_problems,delete_doctors,Dec2012_cycle_problems,drkolesar,2013_12_AGEP_problems,Jul2013_reverse_B_adjustment_done_on_Jul17,Mar2013_check_problems
mkdir Mar2013_payroll_problems,Aug2013_ME_problems,temp1,Aug2013_payroll_problems,Feb2010_payroll_problems,Jun2010_payroll_problems,2013_12_18_misc_pay_agent,paycode7,Oct2011_payroll_problems
mkdir Sep2011_payroll_problems,Apr2011_payroll_problems,Feb2015_cycle_problems,Mar022015_web_create_problems,Mar2015_cycle_problems,Mar2015_ME_42_problems,Mar2015_payroll_problems,Mar2015_ME_clinic22_problems
mkdir costing,Apr2015_ME_22_problems,Mar2015_ME_22_problems,moira,Jun2015_web4_problems,costing_run2,Aug2015_ME_33_problems,Aug2015_payroll_problems,moira2,Nov302015_web2_problems,Jun2016_ME_33_problems
mkdir Dec2015_payroll_problems,Nov2013_payroll_problems,Jan2016_RAT_problems,Jan2016_payroll_problems,Mar2016_ME_88_problems,Apr2016_web10_duplicate_claims,Sep2016_payroll_problems,Nov2016_ME_23_problems
mkdir Dec2016_ME_98_problems,Apr2017_ME_98_problems
cd ../../../../foxtrot
mkdir purge,bi
Invoke-Command -ComputerName rmascripts.coremig.local -FilePath \\rmascripts\RMA\Scripts\junctions.ps1