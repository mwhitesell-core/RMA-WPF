#found in \macros\setup_rmabill.com

param(
  [string] $1
)

#!\bin\ksh
# modication history
# 97\jun\21 B.E.        - cloned from setup_promis.com
# 97\Dec\16 B.E.        - added data logical
# 98\Feb\09 B.E.        - added data2 logical
# 98\Apr\03 B.E.        - PHTEMP changed to \dyad\tmp\tmp
# 08\Apr\03 yas         - added new clinic 37             
# 08\jun\09 b.e.        - added solo payroll environment
# 08\sep\02 b.e.        - added solotest test environment
# 08\sep\25 b.e.        - change solo and solotest to be clinic 88 not 22
# 08\oct\17 yas.        - add new clinic 88  for HHS Emergency clinic
# 08\ocd\17 b.e.        - change solo and solotest from clinic 88 to 10
# 09\Apr\02 yas.        - add new clinic 89  Palliative Care Clinic  
# 09\Jun\02 yas.        - add new clinic 79  McMaster Adult Emergency
# 09\Jun\27 yas.        - add new clinic 78  McMaster Peds Emergency 
# 09\Aug\10 yas.        - add dir production\disk1 to production\disk10
# 09\oct\10 B.E.        - PHTEMP changed to \charly\tmp
# 10\Feb\08 yas.        - add new clinic 66                           
# 11\Jan\11 yas.        - add new clinic 23                 
# 11\Nov\10 yas.        - add new directory n85             
# 16\Jan\12 yas.        - add new directory 24              
# 06\Mar\12 yas.        - add new directory n85a            
# 07\Mar\12 yas.        - add $env:cmd\ftpcheck
# 08\Jun\12 yas.        - add new directory 25   
# 31\Jul\13 yas.        - add new directory  oscar and oscarbk
# 14\Jan\14 yas.        - add new directory  oscar1 and oscar2
# 22\Jan\14 yas.        - add new directory  oscar3
# 03\apr\14 yas.        - add new directory  69 medicine oncology
# 03\May\14 yas.        - add new directory  68 medicine oncology new recruits
# 02\Jul\14 yas.        - add new directory  oscar4
# 02\Aug\14 yas.        - add new directory  oscar5 oscar6 oscar7 oscar8 oscar9 oscar10
# 17\Oct\14 yas.        - add new directory  30                                           
# 10\Mar\15 yas.        - add new directory  26                     
# 26\Mar\16 yas.        - add new directory  oscar11                 
# 28\Jun\16 yas.        - add new directory  oscar12 to oscar15                 
# 30\Jun\16 yas.        - add new directory  oscar16 to oscar20                 


# application 2 character acronym is: pb - physician billing
# clear\echo don't work in batch\cron

####clear
#### echo "Promis - initial development is using Ph723c3"

$env:application_production = "\\$env:srvname\RMA\alpha\rmabill\" + $env:username

#If user's folder does not exist, create it.
If(!(Test-Path $env:application_production))
{
    New-Item -ItemType Directory -Force -Path $env:application_production
}

Set-Location $env:application_production


$env:RMABILL_ROOT = "\\$env:srvname\RMA\alpha\rmabill\rmabill"


#RMABILL_VERSION=`echo $env:1|cut -c3-`     # export RMABILL_VERSION
$env:RMABILL_VERSION=$1                      # export RMABILL_VERSION
$env:RMABILL_VERS="$1"                       # export RMABILL_VERS
$env:RMABILL=$env:RMABILL_ROOT + $env:RMABILL_VERS      # export RMABILL_ROOT
####echo \\n\\n setting up RMABILL Version:$env:RMABILL_VERSION ... \\n

#if [ "$env:RMABILL_VERS" = "100" ]
#then
#  . \usr\cognos\ph733d\setpow.sh
#else
# CHANGED 2007 sep . \usr\cognos\ph733d\setpow.sh
#. \alpha\cognos\ph733e\setpow.sh
#fi

if ( $env:RMABILL_VERS -eq "101c"  -or $env:RMABILL_VERS -eq "101" -or $env:RMABILL_VERS -eq "101cD3" -or $env:RMABILL_VERS -eq "101cD2" -or $env:RMABILL_VERS -eq "101cD4" -or $env:RMABILL_VERS -eq "101cD5" )
{
  $env:clinic_nbr=22   
}                              # export clinic_nbr
elseif ( $env:RMABILL_VERS -eq "mp" )
{
      $env:clinic_nbr=99  
 }                               # export clinic_nbr
elseif ( $env:RMABILL_VERS -eq "solo" -or $env:RMABILL_VERS -eq "solotest" -or $env:RMABILL_VERS -eq "soloD2" )
{
         $env:clinic_nbr=10 
}                                # export clinic_nbr
else
{
          echo WARNING - CLINIC NOT SETUP FOR THIS ENVIRONMENT
          echo Hit enter to contine
          #read garbage
          $env:clinic_nbr=22  
}                               # export clinic_nbr


#PHTEMP=\charly\phtmp           # export PHTEMP
#PHTEMP=\dyad\tmp\tmp           # export PHTEMP
#PHTEMP=\charly\tmp              # export PHTEMP

#. $env:macros\toolkit
#. $env:macros\clear_application


$env:exe=$env:RMABILL + "\obj"                  # export exe
$env:pb_exe=$env:exe                       # export pb_exe
$env:obj=$env:exe                          # export obj
$env:pb_obj=$env:exe                       # export pb_obj
$env:src=$env:RMABILL +"\src"                  # export src
$env:pb_src=$env:src                       # export pb_src
$env:use=$env:RMABILL + "\use"                  # export use
$env:pb_use=$env:use                       # export pb_use
$env:pb_prod=$env:prod                     # export prod
$env:prod=$env:prod                        # export pb_prod
# include link to powertouch objects for compatiblity with PT source
$env:pt_obj=$env:pr_obj                    # export pt_obj

$env:DICT=$env:pb_obj                      # export DICT
$env:QKGO=$env:obj + "\mcqkgo.qkg"              # export QKGO
$env:obj_var="pb_obj"                  # export obj_var
#setdict $env:DICT + "\dict"

#*****************************************************************************

$env:application_comp1="cc=[dg,rma,ohip,unix,nosecurity,ibase,NotClientServer]"
                                          #export application_comp1
$env:application_comp2=""                    # export application_comp2
$env:application_comp3=""                    # export application_comp3
$env:application_data=""                     # export application_data
$env:application_dvlp=$env:RMABILL + "\dvlp"          # export application_dvlp
$env:application_doc=$env:RMABILL + "\doc"            # export application_doc
$env:application_upl=$env:RMABILL + "\upload"         # export application_upl
$env:pplication_delivery=$env:RMABILL + "\dlv"       # export application_delivery
$env:application_switches="$env:application_comp1 $env:application_comp2 $env:application_comp3"
                                          #export application_switches
$env:application_root=$env:RMABILL               # export application_root
$env:application_macro="$env:macros\setup_promis.com"
                                          #export application_macro
$env:application_name="RMABILL"              # export application_name
$env:application_origin="RMABILL Version 1.0"# export application_origin
$env:application_port="UNIX"                 # export application_port
$env:ar=$env:application_root                    # export ar 
$env:application_quick="osaccess"            # export application_quick
$env:application_batch=$env:RMABILL + "\batch"        # export application_batch
$env:cmd=$env:application_root + "\cmd"               # export cmd
$env:pb_data=""                              # export pb_data
$env:pb_data2=""                             # export pb_data2
#**************************************************************
# $env:macros\set_dvlp

# The following is database\version specific and is normally in a separate
# macro which would typically invoke this macro and then set the database.
$env:pb_data="$env:RMABILL\data"                 # export pb_data

#$env:pb_data="d:\alpha\rmabill\rmabill101c\data"

$env:pb_data2="$env:RMABILL\data2"               # export pb_data
$env:application_data=$env:pr_data               # export application_data 
$env:pb_prod="$env:RMABILL\production"           # export pb_prod
$env:application_production="$env:RMABILL\production"    # export application_production

$env:data_symbol="pb_data"                   # export data_symbol

$env:prod="cd \$env:pb_prod#pwd"
$env:audit='vi $env:src\audit.dc'
$env:exe='cd $env:exe#pwd'
$env:data='cd $env:pb_data#pwd'
$env:data2='cd $env:pb_data2#pwd'
$env:ma='data2#cd ma'
$env:costing='data2#cd costing'
$env:use='cd $env:pb_use#pwd'
$env:prod='cd $env:pb_prod#pwd'
$env:web='cd $env:pb_prod\web#pwd'
$env:web1='cd $env:pb_prod\web1#pwd'
$env:web2='cd $env:pb_prod\web2#pwd'
$env:web3='cd $env:pb_prod\web3#pwd'
$env:web4='cd $env:pb_prod\web4#pwd'
$env:web5='cd $env:pb_prod\web5#pwd'
$env:web6='cd $env:pb_prod\web6#pwd'
$env:web7='cd $env:pb_prod\web7#pwd'
$env:web8='cd $env:pb_prod\web8#pwd'
$env:web9='cd $env:pb_prod\web9#pwd'
$env:web10='cd $env:pb_prod\web10#pwd'
$env:disk1='cd $env:pb_prod\disk1#pwd'
$env:disk2='cd $env:pb_prod\disk2#pwd'
$env:disk3='cd $env:pb_prod\disk3#pwd'
$env:disk4='cd $env:pb_prod\disk4#pwd'
$env:disk5='cd $env:pb_prod\disk5#pwd'
$env:disk6='cd $env:pb_prod\disk6#pwd'
$env:disk7='cd $env:pb_prod\disk7#pwd'
$env:disk8='cd $env:pb_prod\disk8#pwd'
$env:disk9='cd $env:pb_prod\disk9#pwd'
$env:disk10='cd $env:pb_prod\disk10#pwd'
$env:diskette='cd $env:pb_prod\diskette#pwd'
$env:diskette1='cd $env:pb_prod\diskette1#pwd'
$env:n85='cd $env:pb_prod\n85#pwd'
$env:n85a='cd $env:pb_prod\n85a#pwd'
$env:oscar='cd $env:pb_prod\oscar#pwd'
$env:oscar1='cd $env:pb_prod\oscar1#pwd'
$env:oscar2='cd $env:pb_prod\oscar2#pwd'
$env:oscar3='cd $env:pb_prod\oscar3#pwd'
$env:oscar4='cd $env:pb_prod\oscar4#pwd'
$env:oscar5='cd $env:pb_prod\oscar5#pwd'
$env:oscar6='cd $env:pb_prod\oscar6#pwd'
$env:oscar7='cd $env:pb_prod\oscar7#pwd'
$env:oscar8='cd $env:pb_prod\oscar8#pwd'
$env:oscar9='cd $env:pb_prod\oscar9#pwd'
$env:oscar10='cd $env:pb_prod\oscar10#pwd'
$env:oscar11='cd $env:pb_prod\oscar11#pwd'
$env:oscar12='cd $env:pb_prod\oscar12#pwd'
$env:oscar13='cd $env:pb_prod\oscar13#pwd'
$env:oscar14='cd $env:pb_prod\oscar14#pwd'
$env:oscar15='cd $env:pb_prod\oscar15#pwd'
$env:oscar16='cd $env:pb_prod\oscar16#pwd'
$env:oscar17='cd $env:pb_prod\oscar17#pwd'
$env:oscar18='cd $env:pb_prod\oscar18#pwd'
$env:oscar19='cd $env:pb_prod\oscar19#pwd'
$env:oscar20='cd $env:pb_prod\oscar20#pwd'
$env:oscar21='cd $env:pb_prod\oscar21#pwd'
$env:oscarbk='cd $env:pb_prod\oscarbk#pwd'
$env:stone='cd $env:pb_prod\stone#pwd'
$env:mumc='cd $env:pb_prod\mumc#pwd'
$env:yasemin='cd $env:pb_prod\yasemin#pwd'
$env:yas='cd $env:pb_src\yas#pwd'
$env:kathy='cd $env:pb_prod\kathy#pwd'
$env:90='cd $env:pb_prod\90#pwd'
$env:78='cd $env:pb_prod\78#pwd'
$env:79='cd $env:pb_prod\79#pwd'
$env:80='cd $env:pb_prod\80#pwd'
$env:81='cd $env:pb_prod\81#pwd'
$env:82='cd $env:pb_prod\82#pwd'
$env:83='cd $env:pb_prod\83#pwd'
$env:84='cd $env:pb_prod\84#pwd'
$env:85='cd $env:pb_prod\85#pwd'
$env:91='cd $env:pb_prod\91#pwd'
$env:92='cd $env:pb_prod\92#pwd'
$env:93='cd $env:pb_prod\93#pwd'
$env:94='cd $env:pb_prod\94#pwd'
$env:95='cd $env:pb_prod\95#pwd'
$env:96='cd $env:pb_prod\96#pwd'
$env:60='cd $env:pb_prod\60#pwd'
$env:61='cd $env:pb_prod\61#pwd'
$env:62='cd $env:pb_prod\62#pwd'
$env:63='cd $env:pb_prod\63#pwd'
$env:64='cd $env:pb_prod\64#pwd'
$env:65='cd $env:pb_prod\65#pwd'
$env:66='cd $env:pb_prod\66#pwd'
$env:68='cd $env:pb_prod\68#pwd'
$env:69='cd $env:pb_prod\69#pwd'
$env:70='cd $env:pb_prod\70#pwd'
$env:71='cd $env:pb_prod\71#pwd'
$env:72='cd $env:pb_prod\72#pwd'
$env:73='cd $env:pb_prod\73#pwd'
$env:74='cd $env:pb_prod\74#pwd'
$env:75='cd $env:pb_prod\75#pwd'
$env:30='cd $env:pb_prod\30#pwd'
$env:31='cd $env:pb_prod\31#pwd'
$env:32='cd $env:pb_prod\32#pwd'
$env:33='cd $env:pb_prod\33#pwd'
$env:34='cd $env:pb_prod\34#pwd'
$env:35='cd $env:pb_prod\35#pwd'
$env:36='cd $env:pb_prod\36#pwd'
$env:37='cd $env:pb_prod\37#pwd'
$env:41='cd $env:pb_prod\41#pwd'
$env:42='cd $env:pb_prod\42#pwd'
$env:43='cd $env:pb_prod\43#pwd'
$env:86='cd $env:pb_prod\86#pwd'
$env:87='cd $env:pb_prod\87#pwd'
$env:88='cd $env:pb_prod\88#pwd'
$env:89='cd $env:pb_prod\89#pwd'
$env:44='cd $env:pb_prod\44#pwd'
$env:45='cd $env:pb_prod\45#pwd'
$env:46='cd $env:pb_prod\46#pwd'
$env:48='cd $env:pb_prod\48#pwd'
$env:98='cd $env:pb_prod\98#pwd'
$env:23='cd $env:pb_prod\23#pwd'
$env:24='cd $env:pb_prod\24#pwd'
$env:25='cd $env:pb_prod\25#pwd'
$env:26='cd $env:pb_prod\26#pwd'
$env:22='cd $env:pb_prod\22#pwd'
$env:fixup='cd $env:pb_src\fixup#pwd'
$env:view_suspense='quick auto=$env:obj\d705.qkc'
$env:vs='view_suspense'
$env:u700='$env:cmd\u700 bg2215'
$env:newu701='$env:cmd\newu701 bg2215'
$env:recreate_clean_suspense='$env:cmd\recreate_clean_suspense'
$env:print_diskettes='$env:cmd\print_diskettes'
$env:suspend_dtl='$env:cmd\suspend_dtl'
$env:suspend_total='$env:cmd\suspend_total'
$env:docrev='$env:cmd\docrev'
$env:upload_susp='$env:cmd\recreate_clean_suspense # u700 # newu701'
$env:ftpcheck='$env:cmd\ftpcheck'
$env:lpc='\macros\lpc'
$env:lpcs='\macros\lpcs'
# COBOL Copy file location Environment variable
#COBCPY=".:\alpha\rmabill\rmabill"$env:RMABILL_VERS"\use"
#COBCPY="\alpha\rmabill\rmabill"$env:RMABILL_VERS"\use"
                                         # export COBCPY
# ADDED below line 2007 sept
#. $env:macros\setup_cobol.com

#changed to environment variable
$env:cmd = "\\$env:srvname\RMA\Scripts"
$env:transfer_area = "\\$env:srvname\RMA\alpha\temp\transfer_area\rmabill"


$env:QTP = "\\$env:srvname\RMA\RMA_Batch\RMA_Batch.exe " + $1 + " " + "QTP" + " " 
$env:QUIZ = "\\$env:srvname\RMA\RMA_Batch\RMA_Batch.exe " + $1 + " " + "QUIZ" + " " 
$env:COBOL = "\\$env:srvname\RMA\RMA_Batch\RMA_Batch.exe " + $1 + " " + "COBOL" + " "
$env:TRUNCATE = "\\$env:srvname\RMA\RMA_Batch\RMA_Batch.exe " + $1 + " " + "TRUNCATE" + " "

$env:root = "$env:srvname\rma"
$env:sqlinstance = "$env:srvname"

$env:1 = $1

$rcmd = $env:cmd + "\rmabuildenv"
Invoke-Expression $rcmd


### echo "Setup Complete."