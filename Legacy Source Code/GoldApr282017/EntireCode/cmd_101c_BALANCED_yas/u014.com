#!/bin/ksh
qtp auto=$obj/u014.qtc << E_O_F
83
E_O_F
