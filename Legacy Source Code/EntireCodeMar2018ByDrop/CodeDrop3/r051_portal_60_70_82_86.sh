echo " --- r051c_portal (PH) --- "

### Clinic 82
cd $application_production/82
rm r051*portal*
quiz << R051_EXIT  > r051_portal.log
exec $obj/r051ca_portal
82@
exec $obj/r051cb_portal
82@
R051_EXIT

mv r051ca_portal.txt r051ca_portal_82.txt
mv r051cb_portal.txt r051cb_portal_82.txt

### Clinic 86
cd $application_production/86
rm r051*portal*
quiz << R051_EXIT  > r051_portal.log
exec $obj/r051ca_portal
86@
exec $obj/r051cb_portal
86@
R051_EXIT

mv r051ca_portal.txt r051ca_portal_86.txt
mv r051cb_portal.txt r051cb_portal_86.txt

### Clinic 61
cd $application_production/61
rm r051*portal*
quiz << R051_EXIT  > r051_portal.log
exec $obj/r051catp_portal     
61@
exec $obj/r051cbtp_portal     
61@
R051_EXIT

mv r051catp_portal.txt r051ca_portal_61.txt
mv r051cbtp_portal.txt r051cb_portal_61.txt

### Clinic 62
cd $application_production/62
rm r051*portal*
quiz << R051_EXIT  > r051_portal.log
exec $obj/r051catp_portal     
62@
exec $obj/r051cbtp_portal     
62@
R051_EXIT

mv r051catp_portal.txt r051ca_portal_62.txt
mv r051cbtp_portal.txt r051cb_portal_62.txt

### Clinic 63
cd $application_production/63
rm r051*portal*
quiz << R051_EXIT  > r051_portal.log
exec $obj/r051catp_portal
63@
exec $obj/r051cbtp_portal
63@
R051_EXIT

mv r051catp_portal.txt r051ca_portal_63.txt
mv r051cbtp_portal.txt r051cb_portal_63.txt

### Clinic 64
cd $application_production/64
rm r051*portal*
quiz << R051_EXIT  > r051_portal.log
exec $obj/r051catp_portal
64@
exec $obj/r051cbtp_portal
64@
R051_EXIT

mv r051catp_portal.txt r051ca_portal_64.txt
mv r051cbtp_portal.txt r051cb_portal_64.txt

### Clinic 65
cd $application_production/65
rm r051*portal*
quiz << R051_EXIT  > r051_portal.log
exec $obj/r051catp_portal
65@
exec $obj/r051cbtp_portal
65@
R051_EXIT

mv r051catp_portal.txt r051ca_portal_65.txt
mv r051cbtp_portal.txt r051cb_portal_65.txt

### Clinic 66
cd $application_production/66
rm r051*portal*
quiz << R051_EXIT  > r051_portal.log
exec $obj/r051catp_portal
66@
exec $obj/r051cbtp_portal
66@
R051_EXIT

mv r051catp_portal.txt r051ca_portal_66.txt
mv r051cbtp_portal.txt r051cb_portal_66.txt

### Clinic 71
cd $application_production/71
rm r051*portal*
quiz << R051_EXIT  > r051_portal.log
exec $obj/r051catp_portal
71@
exec $obj/r051cbtp_portal
71@
R051_EXIT

mv r051catp_portal.txt r051ca_portal_71.txt
mv r051cbtp_portal.txt r051cb_portal_71.txt

### Clinic 72
cd $application_production/72
rm r051*portal*
quiz << R051_EXIT  > r051_portal.log
exec $obj/r051catp_portal
72@
exec $obj/r051cbtp_portal
72@
R051_EXIT

mv r051catp_portal.txt r051ca_portal_72.txt
mv r051cbtp_portal.txt r051cb_portal_72.txt

### Clinic 73
cd $application_production/73
rm r051*portal*
quiz << R051_EXIT  > r051_portal.log
exec $obj/r051catp_portal
73@
exec $obj/r051cbtp_portal
73@
R051_EXIT

mv r051catp_portal.txt r051ca_portal_73.txt
mv r051cbtp_portal.txt r051cb_portal_73.txt

### Clinic 74
cd $application_production/74
rm r051*portal*
quiz << R051_EXIT  > r051_portal.log
exec $obj/r051catp_portal
74@
exec $obj/r051cbtp_portal
74@
R051_EXIT

mv r051catp_portal.txt r051ca_portal_74.txt
mv r051cbtp_portal.txt r051cb_portal_74.txt

### Clinic 75
cd $application_production/75
rm r051*portal*
quiz << R051_EXIT  > r051_portal.log
exec $obj/r051catp_portal
75@
exec $obj/r051cbtp_portal
75@
R051_EXIT

mv r051catp_portal.txt r051ca_portal_75.txt
mv r051cbtp_portal.txt r051cb_portal_75.txt

date
echo Done!
