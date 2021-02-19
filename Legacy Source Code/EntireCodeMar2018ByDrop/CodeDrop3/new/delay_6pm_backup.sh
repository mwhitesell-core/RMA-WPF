#!/bin/ksh

cd /alpha/rmabill/rmabill101c/data
touch delay_6pm_backup.flg

echo "delaying 6pm backup -- `date` " >> delay_6pm_backup.log

echo Create flag file to delay 6pm backup ....
date

cd /alpha/rmabill/rmabill101c/production
