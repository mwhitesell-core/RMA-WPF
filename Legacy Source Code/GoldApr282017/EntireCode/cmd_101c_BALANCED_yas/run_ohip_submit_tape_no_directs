# run_ohip_submit_tape_no_directs

# 98/Jun/29 B.E. - added 2>/dev/null to #lp statements
# 99/feb/08 B.E. - added logic to create 2nd ohip tape file in y2k V03  format
# 99/feb/12 B.E. - change call to quiz for r085/6/7 pgms 
# 99/feb/22 B.E. - fixed problem with file naming of y2k file
# 99/may/18 B.E. - changed so that y2k version of code is 'normal' file
# 00/jun/29 B.E. - removed hard coding and called 'elig_letters_corrections_resubmits'
# 04/feb/23 M.C. - rename 'elig_letters_corrections_resubmits' to
#			  'elig_corrections_letters_resubmits'
#
# 07/apr/09 yas  - add new contract e 
# 11/jan/12 M.C. - transfer the call of $cmd/letter_eligibility_info_wrong from
#		   $cmd/elig_corrections_letters_resubmit to be run after u020
# 11/jan/26 M.C. - add the new program u020d.qtc  
# 11/May/31 MC1  - qutil tmp-counters-alpha before u022 & u020 run

echo Running "run_ohip_submit_tape_no_directs" ...
echo
date
echo

$cmd/u010_daily ${1}


# 2011/05/31  - MC1

qutil << qutil_exit
create file tmp-counters-alpha
qutil_exit

 

##$cmd/elig_letters_corrections_resubmits
$cmd/elig_corrections_letters_resubmits


rm ru020* u020_tapeout_file* u020_tp.sf* u020*sf* 2>/dev/null

echo "--- u020a (QTP RUN) ---" 
qtp auto=$obj/u020a.qtc 

echo "Processing u020a1_a ..."
if [ -s u020a1_a.sf ]
then

  mv u020a1_a.sf  u020a1.sf
  mv u020a1_a.sfd u020a1.sfd

  $cmd/u020

  mv u020_tp.sf   u020_tapeout_file_a
  rm u020_tp.sfd
  
  mv ru020a.txt	  ru020a_a
  mv ru020b_d.txt ru020b_d_a
  mv ru020b_s.txt ru020b_s_a
  mv ru020c.txt   ru020c_a
  mv ru020mr.txt  ru020mr_a
  mv u020a1.sf    u020a1_a.sf
  mv u020a1.sfd   u020a1_a.sfd
fi
 

echo "Processing u020a1_b ..."
if [ -s u020a1_b.sf ]
then

  mv u020a1_b.sf   u020a1.sf
  mv u020a1_b.sfd  u020a1.sfd

  $cmd/u020

  mv u020_tp.sf u020_tapeout_file_b
  rm u020_tp.sfd

  mv ru020a.txt	  ru020a_b
  mv ru020b_d.txt ru020b_d_b
  mv ru020b_s.txt ru020b_s_b
  mv ru020c.txt   ru020c_b
  mv ru020mr.txt  ru020mr_b
  mv u020a1.sf    u020a1_b.sf
  mv u020a1.sfd   u020a1_b.sfd
fi

echo "Processing u020a1_c ..."
if [ -s u020a1_c.sf ]
then

  mv u020a1_c.sf   u020a1.sf
  mv u020a1_c.sfd  u020a1.sfd

  $cmd/u020

  mv  u020_tp.sf u020_tapeout_file_c
  rm  u020_tp.sfd

  mv  ru020a.txt ru020a_c
  mv  ru020b_d.txt ru020b_d_c
  mv  ru020b_s.txt ru020b_s_c
  mv  ru020c.txt ru020c_c
  mv  ru020mr.txt ru020mr_c
  mv  u020a1.sf   u020a1_c.sf
  mv  u020a1.sfd  u020a1_c.sfd
fi


echo "Processing u020a1_d ..."
if [ -s u020a1_d.sf ]
then

  mv u020a1_d.sf   u020a1.sf
  mv u020a1_d.sfd  u020a1.sfd

  $cmd/u020

  mv u020_tp.sf u020_tapeout_file_d
  rm u020_tp.sfd

  mv ru020a.txt  ru020a_d
  mv ru020b_d.txt ru020b_d_d
  mv ru020b_s.txt ru020b_s_d
  mv ru020c.txt  ru020c_d
  mv ru020mr.txt ru020mr_d
  mv u020a1.sf   u020a1_d.sf
  mv u020a1.sfd  u020a1_d.sfd
fi

echo "Processing u020a1_e ..."
if [ -s u020a1_e.sf ]
then

  mv u020a1_e.sf   u020a1.sf
  mv u020a1_e.sfd  u020a1.sfd

  $cmd/u020

  mv u020_tp.sf u020_tapeout_file_e
  rm u020_tp.sfd

  mv ru020a.txt  ru020a_e
  mv ru020b_d.txt ru020b_d_e
  mv ru020b_s.txt ru020b_s_e
  mv ru020c.txt  ru020c_e
  mv ru020mr.txt ru020mr_e
  mv u020a1.sf   u020a1_e.sf
  mv u020a1.sfd  u020a1_e.sfd
fi

echo
echo
echo
cat ru020a_a  > ru020a
cat ru020a_b >> ru020a    2>/dev/null
cat ru020a_c >> ru020a    2>/dev/null
cat ru020a_d >> ru020a    2>/dev/null
cat ru020a_e >> ru020a    2>/dev/null

cat ru020b_d_a  >ru020b
cat ru020b_s_a >>ru020b    2>/dev/null
cat ru020b_d_b >>ru020b    2>/dev/null
cat ru020b_s_b >>ru020b    2>/dev/null
cat ru020b_d_c >>ru020b    2>/dev/null
cat ru020b_s_c >>ru020b    2>/dev/null
cat ru020b_d_d >>ru020b    2>/dev/null
cat ru020b_s_d >>ru020b    2>/dev/null
cat ru020b_d_e >>ru020b    2>/dev/null
cat ru020b_s_e >>ru020b    2>/dev/null

cat ru020c_a  >ru020c
cat ru020c_b >>ru020c    2>/dev/null
cat ru020c_c >>ru020c    2>/dev/null
cat ru020c_d >>ru020c    2>/dev/null
cat ru020c_e >>ru020c    2>/dev/null

cat ru020mr_a  >ru020mr
cat ru020mr_b >>ru020mr    2>/dev/null
cat ru020mr_c >>ru020mr    2>/dev/null
cat ru020mr_d >>ru020mr    2>/dev/null
cat ru020mr_e >>ru020mr    2>/dev/null

cat u020_tapeout_file_a  >u020_tapeout_file
cat u020_tapeout_file_b >>u020_tapeout_file    2>/dev/null
cat u020_tapeout_file_c >>u020_tapeout_file    2>/dev/null
cat u020_tapeout_file_d >>u020_tapeout_file    2>/dev/null
cat u020_tapeout_file_e >>u020_tapeout_file    2>/dev/null
cat u022_tp.sf          >>u020_tapeout_file    2>/dev/null
cat sd_u022.sf          >>u020_tapeout_file    2>/dev/null

#lp ru020b 2>/dev/null
#lp ru020c 2>/dev/null

# 2011/Jan/26
echo "--- u020d (QTP RUN) ---" 
qtp auto=$obj/u020d.qtc 

# 2011/01/12 - generate r086.txt & r087.txt
$cmd/letters_eligibility_info_wrong

# backup_ohip_tape

echo R010 IN PROGRESS `date` 

$cmd/r010

echo
echo
date
echo
echo

#lp ohiptape.ls

echo Done "run_ohip_submit_tape_no_directs"
