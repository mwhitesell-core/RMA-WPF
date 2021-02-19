
# 15/Apr/14 MC1  - add the new program r018.qzc

#RUN_OHIP_SUBMIT_REPORTS
echo
echo
echo Run 'create adjustment claims' and 'Ohip submittal reports' ...
echo Hit "NEWLINE" to continue ...
read garbage

$cmd/create_adj_claims

echo
echo PRINT THE BALANCED BATCH DETAIL REPORT
echo
echo NOTE !! NO ONE MUST BE ACCESSING THE BATCH CONTROL AND CLAIMS MASTER
echo
echo 'HIT "NEWLINE" TO RUN "ALL BATCHES" REPORT ...'
#read garbage
echo
echo

$cmd/all_batches

echo
echo 'HIT "NEWLINE" TO RUN "BATCH SUMMARY REPORT" ...'
echo
#read garbage

echo 'PROGRAM "R001" NOW LOADING ...'

cd $application_production
cobrun $obj/r001

echo

ls -l r001

echo
echo 'HIT  "NEWLINE"  TO PRINT REPORT ...'
echo
#read garbage

#lp r001

echo
echo
echo
echo 'HIT "NEWLINE" TO CREATE "DETAIL BATCH REPORTS" ...'
#read garbage
echo
echo 'PROGRAM "R002A" NOW LOADING ...'
cobrun $obj/r002a
echo

ls -l r002a*

echo
echo 'HIT "NEWLINE" TO PRINT REPORT ...'
#read garbage
echo

#lp r002ab

echo
echo
echo
echo 'HIT "NEWLINE" TO RUN "TRANSACTION SUMMARY CYCLE REPORT" ...'
#read garbage

echo
echo 'PROGRAM "R004_CYCLE" NOW LOADING ...'
cobrun $obj/r004_cycle
echo

#ls -l r004_c

echo
echo 'HIT "NEWLINE" TO PRINT REPORT ...'
echo
#read garbage

#lp r004_c


echo
echo
echo
echo 'HIT "NEWLINE" TO RUN "AGENT SUMMARY REPORT" ...'
#read garbage

echo
echo 'PROGRAM "R014" NOW LOADING ...(CLINIC 60 TO 61)'
echo 'AND R014SUM  (CLINIC 60 TO 61 TOTALS)'
cobrun $obj/r014sum
cobrun $obj/r014

echo

ls -l r014*

echo
echo 'HIT "NEWLINE" TO PRINT REPORT ...'
echo
#read garbage

#lp r014sm
#lp r014
#lp r801a.txt
#lp r801c.txt

# MC1
rm r018.txt  2>/dev/null
quiz auto=$obj/r018.qzc
mv r018.txt r018_${1}.txt

echo
echo  " COPY r018_yyyymmdd.txt  to Helena's directory  "
echo
date
echo
echo
echo FINISHED AT `date` ....
