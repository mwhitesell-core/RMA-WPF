# utl0119.com    

# NOTE: clinic 22 - "normal" clinic 22 payroll
#	clinic 99 - "MP" / Manual Payments payroll
#	clinic 10 - "solo/solotest" payroll
#
# 14/Nov/25 M.C. - original  

echo "--- executing utl0119.qtc  ---"

cd $application_root/production

rm utl00119.ps* 1>/dev/null 2>&1

# If 101c, pass 101C 
if [ $clinic_nbr = "22" ]
then

qtp << QTP_EXIT1a
execute $obj/utl0119
101C
QTP_EXIT1a

else

# If MP, pass MP   
if [ $clinic_nbr = "99" ]
then 

qtp << QTP_EXIT1b
execute $obj/utl0119
MP   
QTP_EXIT1b

else

# If solo, pass SOLO 
if [ $clinic_nbr = "10" ]
then

qtp << QTP_EXIT1c
execute $obj/utl0119
SOLO
QTP_EXIT1c

fi
fi
fi

