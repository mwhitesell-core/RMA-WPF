## $cmd/accounts_receivable

echo " --- r070a (COBOL) --- " `date`
cobrun $obj/r070a << R070A_EXIT
$1
Y
Y
R070A_EXIT

echo " --- r070b (COBOL) --- " `date`
cobrun $obj/r070b

echo " --- r070c (COBOL) --- " `date`
cobrun $obj/r070c << R070C_EXIT
N
R070C_EXIT