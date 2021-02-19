# utl0201.com    

# NOTE: clinic 22 - "normal" clinic 22 payroll
#	clinic 99 - "MP" / Manual Payments payroll
#	clinic 10 - "solo/solotest" payroll
#
# 14/Nov/25 M.C. - original  
# 15/Oct/14 MC1  - delete additonal subfiles before running of programs

echo "--- executing utl0201.qtc  ---"

cd $application_root/production

rm utl0201*.ps* utl*audit*ps*  utl0f020.ps* utl0201*.txt utl0f191.ps* 1>/dev/null 2>&1

# MC1
rm utl0f*.ps* utlf*.ps*   1>/dev/null 2>&1

# If 101c, pass 101C 
if [ $clinic_nbr = "22" ]
then

qtp << QTP_EXIT1a
execute $obj/utl0201
101C
QTP_EXIT1a

else

# If MP, pass MP   
if [ $clinic_nbr = "99" ]
then 

qtp << QTP_EXIT1b
execute $obj/utl0201
MP   
QTP_EXIT1b

else

# If solo, pass SOLO 
if [ $clinic_nbr = "10" ]
then

qtp << QTP_EXIT1c
execute $obj/utl0201
SOLO
QTP_EXIT1c

fi
fi
fi

quiz auto=$obj/utl0201.qzu
