#  2011/Mar/03 M.C. - run_patient_purge requested by Yasemin to run 4 macros
#                     $cmd/patient_purge, $cmd/pat_mstr_recreate. $cmd/u920.com, $cmd/utl0012.com
#                     from /charly/purge
#  2013/Jan/07 MC1  - move original file to /foxtrot/purge to be consistent with others
#  2013/Mar/09 yas  - ******** DO NOT run $cmd/u920.com .. we only need to run it with the claims purge

echo 'PATIENT_PURGE'
echo
echo 'PATIENT FILE PURGE STAGE # 1'
echo 'NOTE -- THE Backup MUST HAVE BEEN RUN !!!'
echo

cd /charly/purge

date

bcheck -n $pb_data/f010_pat_mstr > f010_verify_before

date

echo
echo Starting Time for Patient Purge `date`
echo

echo 'PROGRAM "U099" NOW LOADING ...'

echo
date
echo
qtp << e_o_f  > u099.log
exec  $obj/u099.qtc
20160101
exit
e_o_f

quiz auto=$obj/r099a
quiz auto=$obj/r099b
quiz auto=$obj/r099c
quiz auto=$obj/r099d

ls ru099.txt

lp ru099.txt
lp u099.log

echo
echo Ending   Time for Patient Purge `date`
echo

##########################


#    "PAT_MSTR_RECREATE"
echo
echo  PATIENT FILE PURGE STAGE # 2
echo  NOTE -- THE PREVIOUS STAGE'S' MUST HAVE BEEN RUN !!!
echo
echo  SAVE THE ORIGINAL PATIENT UNDER 'ORIG' FILENAME
echo
echo

cd /charly/rmabill/rmabill101c/data

## 2013/01/07 - MC1
##mv f010_pat_mstr      f010_pat_mstr_orig
##mv f010_pat_mstr.idx  f010_pat_mstr_orig.idx

mv f010_pat_mstr        /foxtrot/purge/f010_pat_mstr_orig
mv f010_pat_mstr.idx    /foxtrot/purge/f010_pat_mstr_orig.idx

cd $pb_data

. ./createfiles.com

chmod +w f010*

mv  f010_pat_mstr       /charly/rmabill/rmabill101c/data/f010_pat_mstr
mv  f010_pat_mstr.idx   /charly/rmabill/rmabill101c/data/f010_pat_mstr.idx

ln -s /charly/rmabill/rmabill101c/data/f010_pat_mstr     f010_pat_mstr
ln -s /charly/rmabill/rmabill101c/data/f010_pat_mstr.idx f010_pat_mstr.idx

echo
echo Starting Time for Patient Recreate `date`
echo
echo
echo  PROGRAM \"u080\" LOADING ...


cd /charly/purge

rm u080.log
qtp << e_o_f  >> u080.log
exec     $obj/u080.qtc
exit
e_o_f

quiz auto=$obj/r080.qzc >> r080.log

lp u080.log

echo

date

bcheck -n $pb_data/f010_pat_mstr > f010_verify_after

date


echo
echo Ending   Time for Patient Recreate `date`
echo


####################

#    "utl0012.com"
echo
echo  PATIENT FILE PURGE STAGE # 3
echo  NOTE -- THE PREVIOUS STAGE'S' MUST HAVE BEEN RUN !!!
echo
echo  Check if any claims without patient information
echo

echo
echo Starting Time for UTL0012  `date`
echo


cd /charly/purge

rm utl0012.log

echo "utl0012.com  -  STARTING - `date`" > utl0012.log

quiz auto=$obj/utl0012.qzc  >> utl0012.log

echo "utl0012 - ENDING - `date`" >> utl0012.log

echo
echo Ending   Time for UTL0012  `date`
echo

####################
