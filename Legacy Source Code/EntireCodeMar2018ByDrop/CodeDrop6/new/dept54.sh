cd /alpha/rmabill/rmabill101c/src/yas

echo Start Time of $cmd/dept54 is `date`

qtp << E_O_F
Exec $obj/dept54_billings.qtc
201704
exit
E_O_F

echo End Time of $cmd/dept54 is `date`

