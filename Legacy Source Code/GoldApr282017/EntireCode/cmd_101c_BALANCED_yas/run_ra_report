rm   1>/dev/null  2>/dev/null  r997* r997*.sf* u997*.sf*
echo "Running RA reports"
qtp auto=$obj/u997.qtc

# r997 exculudes 35's
#quiz auto=$obj/r997.qzu

# r997 includes 35's
quiz auto=$obj/r997_35.qzu

cat r997f.txt >> r997.txt
cat r997g.txt >> r997.txt
cat r997h.txt >> r997.txt
cat r997i.txt >> r997.txt
cat r997j.txt >> r997.txt
cat r997k.txt >> r997.txt

cat u030_tape_rmb_file.dat >> u030_tape_145_file.dat

quiz auto=$obj/r997_total.qzc
cat r997_total.txt  >> r997.txt

quiz auto=$obj/r997_paid.qzc      
          
rm                            u030_tape_145_file.dat 1>/dev/null 2>&1
cp u030_tape_145_file_bkp.dat u030_tape_145_file.dat 




