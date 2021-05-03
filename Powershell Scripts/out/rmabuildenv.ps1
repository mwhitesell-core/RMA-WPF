$env:macros = "\\$env:srvname\rma\macros"
function global:CD31 {set-location $env:application_upl} 
function global:CD32 {set-location "\\$env:srvname\RMA\alpha\rmabill\$env:username"} 
Set-Alias home  cd32 -Scope Global
Set-Alias upl   cd31 -Scope Global
Set-Alias appl \\$env:srvname\rma\macros\appl -Scope Global
function global:CD33 { clear}
function global:CD34 { Get-Content -Path "\\$env:srvname\rma\macros\apps","\\$env:srvname\rma\macros\applications"}
Set-Alias apps  cd34 -Scope Global
function global:CD35 { vi $env:src/audit.dc }
Set-Alias audit cd35 -Scope Global
#Set-Alias autoload  typeset -fu
function global:CD36 { cd ..;pwd}
Set-Alias bk    cd36 -Scope Global
Set-Alias borrow $env:macros\borrow -Scope Global
Set-Alias bdpl $env:macros\bdpl -Scope Global
Set-Alias bqks $env:macros\bqks -Scope Global
Set-Alias bqts $env:macros\bqts -Scope Global
Set-Alias bqzs $env:macros\bqzs -Scope Global
Set-Alias bt $env:macros\bt -Scope Global
Set-Alias build_comp $env:macros\build_comp -Scope Global
Set-Alias build_load $env:macros\build_load -Scope Global
Set-Alias bypass_offline $env:macros\bypass_offline -Scope Global
function global:CD37 { echo "\033[?3h" }
Set-Alias c132  cd37 -Scope Global
function global:CD38 { echo "\033[?31" }
Set-Alias c80   cd38 -Scope Global
Set-Alias cards $env:macros\cards -Scope Global
function global:CD39 { cd $env:cmd;pwd }
Set-Alias rmacmd   cd39 -Scope Global
Set-Alias cobcomp $env:macros\cobcomp -Scope Global
Set-Alias commit_dlv $env:macros\commit_dlv -Scope Global
Set-Alias comp_both $env:macros\comp_tz -Scope Global
Set-Alias comp_qks $env:macros\comp_qks -Scope Global
Set-Alias comp_qts $env:macros\comp_qts -Scope Global
Set-Alias comp_qts_qzs $env:macros\comp_qts_qtz -Scope Global
Set-Alias comp_qzs $env:macros\comp_qzs -Scope Global
Set-Alias comp_tkz $env:macros\comp_tkz -Scope Global
Set-Alias comp_tzk $env:macros\comp_tzk -Scope Global
Set-Alias consolidate $env:macros\consolidate.awk -Scope Global
function global:CD40 { data2;cd costing }
Set-Alias costing cd40 -Scope Global
Set-Alias create_comp $env:macros\create_comp
function global:CD41 { nohup /macros/daily_backup }
Set-Alias daily_backup  cd41 -Scope Global
function global:CD42 {cd $env:pb_data;pwd }
Set-Alias rmadata  CD42 -Scope Global
function global:CD43 { cd $env:pb_data2;pwd }
Set-Alias rmadata2  CD43 -Scope Global
function global:CD44 { ls -alt *.log|more }
Set-Alias dirl  cd44 -Scope Global
function global:CD45 { cd $env:pb_prod/disk1;pwd }
Set-Alias disk1  cd45 -Scope Global
function global:CD46 { cd $env:pb_prod/disk10;pwd }
Set-Alias disk10  cd46 -Scope Global
function global:CD47 { cd $env:pb_prod/disk2;pwd }
Set-Alias disk2  cd47 -Scope Global
function global:CD48 { cd $env:pb_prod/disk3;pwd }
Set-Alias disk3  cd48 -Scope Global
function global:CD49 { cd $env:pb_prod/disk4;pwd }
Set-Alias disk4  cd49 -Scope Global
function global:CD50 { cd $env:pb_prod/disk5;pwd }
Set-Alias disk5  cd50 -Scope Global
function global:CD51 { cd $env:pb_prod/disk6;pwd }
Set-Alias disk6  cd51 -Scope Global
function global:CD52 { cd $env:pb_prod/disk7;pwd }
Set-Alias disk7  cd52 -Scope Global
function global:CD53 { cd $env:pb_prod/disk8;pwd }
Set-Alias disk8  cd53 -Scope Global
function global:CD54 { cd $env:pb_prod/disk9;pwd }
Set-Alias disk9  cd54 -Scope Global
function global:CD55 { cd $env:pb_prod/diskette;pwd }
Set-Alias diskette  cd55 -Scope Global
function global:CD56 { cd $env:pb_prod/diskette1;pwd }
Set-Alias diskette1  cd56 -Scope Global
function global:CD57 { cd $env:application_doc;pwd }
Set-Alias doc  cd57 -Scope Global
Set-Alias docrev  $env:cmd/docrev -Scope Global
Set-Alias dy_date  $env:macros/dy_date -Scope Global
Set-Alias dy_time  $env:macros/dy_time -Scope Global
Set-Alias e2p  $env:macros/e2p.com -Scope Global
function global:CD58 { cd $env:exe;pwd }
Set-Alias exe  cd58 -Scope Global
Set-Alias export_variables $env:macros/export_variables -Scope Global
Set-Alias fcount  $env:macros/fcount -Scope Global
Set-Alias find_all $env:macros/find_all -Scope Global
Set-Alias find_required  $env:macros/find_required.com -Scope Global
function global:CD59 { cd $env:pb_src/fixup;pwd }
Set-Alias fixup  cd59 -Scope Global
Set-Alias fornk  $env:macros/fornk.com -Scope Global
Set-Alias ftpcheck  $env:cmd/ftpcheck -Scope Global
#Set-Alias function global:s  typeset -f
Set-Alias get_ptouch_names  $env:macros/get_ptouch_process_names.com -Scope Global
Set-Alias gettree  $env:macros/gettree -Scope Global
#Set-Alias go  /macros/go
Set-Alias goop  $env:macros/goop -Scope Global
Set-Alias gvnotes  $env:macros/gvrdnotes -Scope Global
#Set-Alias hash  alias -t -
Set-Alias help  $env:macros/help -Scope Global
#function global:CD60 { Get-History }
#Set-Alias history cd60
Set-Alias hscbill  $env:macros/setup_hscbill.com -Scope Global
Set-Alias impact  $env:macros/impact -Scope Global
#Set-Alias integer  typeset -i
function global:CD61 { cd $env:pb_prod/kathy;pwd }
Set-Alias kathy  cd61 -Scope Global
#Set-Alias laser  /ps/cmd/ps_laser
Set-Alias launch_proc $env:macros/launch_proc.com -Scope Global
Set-Alias link_object $env:macros/link_obj -Scope Global
Set-Alias lpc  $env:macros/lpc -Scope Global
Set-Alias lpcs  $env:macros/lpcs -Scope Global

function global:CD129 { Get-ChildItem |Sort LastWriteTime }
Set-Alias lst cd129 -Scope Global
function global:CD62 { data2;cd ma }
Set-Alias ma  cd62 -Scope Global
function global:CD63 { cd $env:macros;pwd }
Set-Alias macros  cd63 -Scope Global
Set-Alias make_dlv  $env:macros/make_dlv -Scope Global
Set-Alias mandatory  $env:macros/mandatory.com -Scope Global
Set-Alias mpop  $env:macros/setup_mpop.com -Scope Global
function global:CD64 { cd $env:pb_prod/mumc;pwd }
Set-Alias mumc  cd64 -Scope Global
function global:CD65 { cd $env:pb_prod/n85;pwd }
Set-Alias n85  cd65 -Scope Global
function global:CD66 { cd $env:pb_prod/n85a;pwd }
Set-Alias n85a  cd66 -Scope Global
Set-Alias name $env:macros/name -Scope Global
Set-Alias names  $env:macros/names -Scope Global
Set-Alias newport  $env:macros/newport -Scope Global
function global:CD121 { \\$env:srvname\rma\scripts\newu701 bg2215 }
Set-Alias newu701  cd121 -Scope Global
#Set-Alias nohup  nohup 
Set-Alias number_requests  $env:macros/number_requests -Scope Global
function global:CD67 { cd $env:obj;pwd }
Set-Alias obj  cd67 -Scope Global
Set-Alias obs  $env:macros/obsolete -Scope Global
Set-Alias offline  $env:macros/offline -Scope Global
Set-Alias online  $env:macros/online -Scope Global
function global:CD68 { cd $env:pb_prod/oscar;pwd }
Set-Alias oscar    cd68 -Scope Global
function global:CD69 { cd $env:pb_prod/oscar1;pwd }
Set-Alias oscar1   cd69 -Scope Global
function global:CD70 { cd $env:pb_prod/oscar10;pwd }
Set-Alias oscar10  cd70 -Scope Global
function global:CD71 { cd $env:pb_prod/oscar11;pwd }
Set-Alias oscar11  cd71 -Scope Global
function global:CD72 { cd $env:pb_prod/oscar12;pwd }
Set-Alias oscar12  cd72 -Scope Global
function global:CD73 { cd $env:pb_prod/oscar13;pwd }
Set-Alias oscar13  cd73 -Scope Global
function global:CD74 { cd $env:pb_prod/oscar14;pwd }
Set-Alias oscar14  cd74 -Scope Global
function global:CD75 { cd $env:pb_prod/oscar15;pwd }
Set-Alias oscar15  cd75 -Scope Global
function global:CD76 { cd $env:pb_prod/oscar16;pwd }
Set-Alias oscar16  cd76 -Scope Global
function global:CD77 { cd $env:pb_prod/oscar17;pwd }
Set-Alias oscar17  cd77 -Scope Global
function global:CD78 { cd $env:pb_prod/oscar18;pwd }
Set-Alias oscar18  cd78 -Scope Global
function global:CD79 { cd $env:pb_prod/oscar19;pwd }
Set-Alias oscar19  cd79 -Scope Global
function global:CD80 { cd $env:pb_prod/oscar2;pwd }
Set-Alias oscar2  cd80 -Scope Global
function global:CD81 { cd $env:pb_prod/oscar20;pwd }
Set-Alias oscar20  cd81 -Scope Global
function global:CD82 { cd $env:pb_prod/oscar21;pwd }
Set-Alias oscar21  cd82 -Scope Global
function global:CD83 { cd $env:pb_prod/oscar3;pwd }
Set-Alias oscar3  cd83 -Scope Global
function global:CD84 { cd $env:pb_prod/oscar4;pwd }
Set-Alias oscar4  cd84 -Scope Global
function global:CD85 { cd $env:pb_prod/oscar5;pwd }
Set-Alias oscar5  cd85 -Scope Global
function global:CD86 { cd $env:pb_prod/oscar6;pwd }
Set-Alias oscar6  cd86 -Scope Global
function global:CD87 { cd $env:pb_prod/oscar7;pwd }
Set-Alias oscar7  cd87 -Scope Global
function global:CD88 { cd $env:pb_prod/oscar8;pwd }
Set-Alias oscar8  cd88 -Scope Global
function global:CD89 { cd $env:pb_prod/oscar9;pwd }
Set-Alias oscar9  cd89 -Scope Global
function global:CD90 { cd $env:pb_prod/oscarbk;pwd }
Set-Alias oscarbk cd90 -Scope Global
function global:CD91 {Get-Content -Path "\\$env:srvname\rma\macros\phdfm_create"}
Set-Alias phdfm_create  cd91 -Scope Global
Set-Alias pherr  $env:macros/pherr -Scope Global
Set-Alias pl  $env:macros/problem_log -Scope Global
Set-Alias plog  $env:macros/plog -Scope Global
function global:CD92 {Get-Content -Path "\\$env:srvname\rma\macros\portable_make.awk"}
Set-Alias portable_make  cd92 -Scope Global
function global:CD93 { cd ; pwd }
Set-Alias portcom  cd93 -Scope Global
Set-Alias pplay  $env:macros/setup_pplay.com -Scope Global
Set-Alias prep  $env:macros/prep -Scope Global
Set-Alias prepare_transfer  $env:macros/prepare_transfer -Scope Global
#Set-Alias print  /ps/cmd/ps_print
#Set-Alias print2  /ps/cmd/ps_print2
Set-Alias print_diskettes  $env:cmd/print_diskettes -Scope Global
Set-Alias proc_names  $env:macros/proc_names.com -Scope Global
Set-Alias process_tbl  $env:macros/process_tbl.com -Scope Global
function global:CD94 { cd $env:pb_prod;pwd }
Set-Alias prod  cd94 -Scope Global
Set-Alias promis  $env:macros/setup_promis.com -Scope Global
#Set-Alias ps_print  /ps/cmd/ps_print
#Set-Alias ps_print132  /ps/cmd/ps_print132
#Set-Alias ps_print2  /ps/cmd/ps_print2
#Set-Alias ps_print2132  /ps/cmd/ps_print2132
#Set-Alias ps_shutdown  /ps/cmd/ps_shutdown
#Set-Alias ps_stat  tail /ps/log/ps.log
Set-Alias putback  $env:macros/putback -Scope Global
Set-Alias qdformat  $env:macros/qdformat -Scope Global
Set-Alias qkstree  $env:macros/qks_tree.com -Scope Global
Set-Alias qzformat  $env:macros/qzformat -Scope Global
#Set-Alias r  fc -e -
function global:CD95 { Get-Content -Path "\\$env:srvname\rma\macros\read_pdl_files.awk" }
Set-Alias read_pdl_files  cd95 -Scope Global
Set-Alias recreate_clean_suspense  $env:cmd/recreate_clean_suspense -Scope Global
Set-Alias reduce_std  $env:macros/reduce_std -Scope Global
Set-Alias relnotes  $env:macros/relnotes -Scope Global
Set-Alias reload_dict  $env:macros/reload_dict -Scope Global
Set-Alias reload_table $env:macros/reload_table -Scope Global
function global:CD96 { cd $env:application_root;pwd }
Set-Alias root  cd96 -Scope Global
Set-Alias screen_shots  $env:macros/screen_shots.awk -Scope Global
Set-Alias screen_tree  $env:macros/screen_tree.com -Scope Global
Set-Alias separate_doc  $env:macros/separate_doc -Scope Global
Set-Alias set_var  $env:macros/set_var -Scope Global
Set-Alias skip_at_c1  $env:macros/skip_at_c1.awk -Scope Global
Set-Alias skip_at_p1  $env:macros/skip_at_p1.awk -Scope Global
function global:CD97 { cd $env:src;pwd }
Set-Alias src  cd97 -Scope Global
function global:CD98 { cd $env:pb_prod/stone;pwd }
Set-Alias stone  cd98 -Scope Global
#Set-Alias stop  kill -STOP
function global:CD99 { Get-Content -Path "\\$env:srvname\rma\macros\subfile_make.awk" }
Set-Alias subfile_make  cd99 -Scope Global
function global:CD100 { Get-Content -Path "\\$env:srvname\rma\macros\subfile_read.awk" }
Set-Alias subfile_read  cd100 -Scope Global
function global:CD101 { Get-Content -Path "\\$env:srvname\rma\macros\sum_bkup.awk" }
Set-Alias sum_bkup  cd101 -Scope Global
#Set-Alias suspend  kill -STOP $env:$env:
Set-Alias suspend_dtl  $env:cmd/suspend_dtl -Scope Global
Set-Alias suspend_total  $env:cmd/suspend_total -Scope Global
Set-Alias timesheet  $env:macros/setup_timesheet.com -Scope Global
Set-Alias tk $env:macros/toolkit -Scope Global
Set-Alias treesize  $env:macros/treesize -Scope Global
Set-Alias ts $env:macros/timesheet -Scope Global
function global:CD120 { Get-Command }
Set-Alias rmatype cd120 -Scope Global
function global:CD122 { \\$env:srvname\rma\scripts\u700 bg2215 }
Set-Alias u700  cd122 -Scope Global
Set-Alias unborrow  $env:macros/unborrow -Scope Global
Set-Alias unload_dict  $env:macros/unload_dict -Scope Global
Set-Alias unload_table $env:macros/unload_table -Scope Global
Set-Alias unnumber_requests  $env:macros/unnumber_requests -Scope Global
Set-Alias unpfs $env:macros/un_pfs.awk -Scope Global
#function global:CD102 { cd $env:application_upl;pwd }
#Set-Alias upl  cd102 -Scope Global
function global:CD103 { Invoke-Command $env:cmd/recreate_clean_suspense ; u700 ; newu701 }
Set-Alias upload_susp  cd103 -Scope Global
function global:CD104 { cd $env:pb_use;pwd }
Set-Alias use  cd104 -Scope Global
function global:CD105 { cd $env:application_root/vax; pwd }
Set-Alias vax  cd105 -Scope Global
Set-Alias vaxcards  $env:macros/vaxcards.com -Scope Global
#Set-Alias view_suspense  quick auto  $env:obj/d705.qkc
#Set-Alias vs  view_suspense
function global:CD106 { cd $env:pb_prod/web;pwd }
Set-Alias web  cd106 -Scope Global
function global:CD107 { cd $env:pb_prod/web1;pwd }
Set-Alias web1  cd107 -Scope Global
function global:CD108 { cd $env:pb_prod/web10;pwd }
Set-Alias web10  cd108 -Scope Global
function global:CD109 { cd $env:pb_prod/web2;pwd }
Set-Alias web2  cd109 -Scope Global
function global:CD110 { cd $env:pb_prod/web3;pwd }
Set-Alias web3  cd110 -Scope Global
function global:CD111 { cd $env:pb_prod/web4;pwd }
Set-Alias web4  cd111 -Scope Global
function global:CD112 { cd $env:pb_prod/web5;pwd }
Set-Alias web5  cd112 -Scope Global
function global:CD113 { cd $env:pb_prod/web6;pwd }
Set-Alias web6  cd113 -Scope Global
function global:CD114 { cd $env:pb_prod/web7;pwd }
Set-Alias web7  cd114 -Scope Global
function global:CD115 { cd $env:pb_prod/web8;pwd }
Set-Alias web8  cd115 -Scope Global
function global:CD116 { cd $env:pb_prod/web9;pwd }
Set-Alias web9  cd116 -Scope Global
function global:CD117 { pwd }
Set-Alias rmawhere cd117 -Scope Global
Set-Alias work  $env:macros/work -Scope Global
function global:CD118 { cd $env:pb_src/yas;pwd }
Set-Alias yas  cd118 -Scope Global
function global:CD119 { cd $env:pb_prod/yasemin;pwd }
Set-Alias yasemin  cd119 -Scope Global
Set-Alias pg more -Scope Global
function global:CD123 ([string]$path) { Get-Content -Path $path | Out-Printer -Name $env:networkprinter }
Set-Alias rmalp cd123 -Scope Global
function global:CD124 { Get-ChildItem Env: }
Set-Alias printenv cd124 -Scope Global
function global:CD125 ([string]$name) { $rcmd = $env:QTP + $name; Invoke-Expression $rcmd }
Set-Alias qtp cd125 -Scope Global
function global:CD126 ([string]$name) { $rcmd = $env:QUIZ + $name; Invoke-Expression $rcmd }
Set-Alias quiz cd126 -Scope Global
function global:CD127 ([string]$path) { Get-Content -Path $path -Tail 1 }
Set-Alias tail cd127 -Scope Global
function global:CD128 ([string]$name) { $rcmd = $env:COBOL + $name; Invoke-Expression $rcmd }
Set-Alias cobrun cd128 -Scope Global
function global:CD130 { &$env:cmd/view_suspense }
Set-Alias vs CD130 -Scope Global
function global:CD131 { cd $env:pb_prod/web11;pwd }
Set-Alias web11 CD131 -Scope Global
function global:CD132 { &$env:cmd/u700 bg2215 }
Set-Alias u700 CD132 -Scope Global
function global:CD133 { &$env:cmd/newu701 bg2215 }
Set-Alias newu701 CD133 -Scope Global
home