echo " --- r051_portal (PH) --- "

### Clinic 37
cd $application_production/37
rm r051*portal*
quiz << R051_EXIT  > r051_portal.log
exec $obj/r051ca_portal
37@
exec $obj/r051cb_portal
37@
R051_EXIT

mv r051ca_portal.txt r051ca_portal_37.txt
mv r051cb_portal.txt r051cb_portal_37.txt

### Clinic 68
cd $application_production/68
rm r051*portal*
quiz << R051_EXIT  > r051_portal.log
exec $obj/r051ca_portal
68@
exec $obj/r051cb_portal
68@
R051_EXIT

mv r051ca_portal.txt r051ca_portal_68.txt
mv r051cb_portal.txt r051cb_portal_68.txt

### Clinic 69
cd $application_production/69
rm r051*portal*
quiz << R051_EXIT  > r051_portal.log
exec $obj/r051ca_portal
69@
exec $obj/r051cb_portal
69@
R051_EXIT

mv r051ca_portal.txt r051ca_portal_69.txt
mv r051cb_portal.txt r051cb_portal_69.txt

### Clinic 78
cd $application_production/78
rm r051*portal*
quiz << R051_EXIT  > r051_portal.log
exec $obj/r051ca_portal
78@
exec $obj/r051cb_portal
78@
R051_EXIT

mv r051ca_portal.txt r051ca_portal_78.txt
mv r051cb_portal.txt r051cb_portal_78.txt

### Clinic 79
cd $application_production/79
rm r051*portal*
quiz << R051_EXIT  > r051_portal.log
exec $obj/r051ca_portal
79@
exec $obj/r051cb_portal
79@
R051_EXIT

mv r051ca_portal.txt r051ca_portal_79.txt
mv r051cb_portal.txt r051cb_portal_79.txt

### Clinic 80
cd $application_production/80
rm r051*portal*
quiz << R051_EXIT  > r051_portal.log
exec $obj/r051ca_portal
80@         
exec $obj/r051cb_portal
80@
R051_EXIT

mv r051ca_portal.txt r051ca_portal_80.txt
mv r051cb_portal.txt r051cb_portal_80.txt

### Clinic 84
cd $application_production/84
rm r051*portal*
quiz << R051_EXIT  > r051_portal.log
exec $obj/r051ca_portal
84@
exec $obj/r051cb_portal
84@
R051_EXIT

mv r051ca_portal.txt r051ca_portal_84.txt
mv r051cb_portal.txt r051cb_portal_84.txt

### Clinic 87
cd $application_production/87
rm r051*portal*
quiz << R051_EXIT  > r051_portal.log
exec $obj/r051ca_portal
87@
exec $obj/r051cb_portal
87@
R051_EXIT

mv r051ca_portal.txt r051ca_portal_87.txt
mv r051cb_portal.txt r051cb_portal_87.txt

### Clinic 88
cd $application_production/88
rm r051*portal*
quiz << R051_EXIT  > r051_portal.log
exec $obj/r051ca_portal
88@
exec $obj/r051cb_portal
88@
R051_EXIT

mv r051ca_portal.txt r051ca_portal_88.txt
mv r051cb_portal.txt r051cb_portal_88.txt

### Clinic 89
cd $application_production/89
rm r051*portal*
quiz << R051_EXIT  > r051_portal.log
exec $obj/r051ca_portal
89@
exec $obj/r051cb_portal
89@
R051_EXIT

mv r051ca_portal.txt r051ca_portal_89.txt
mv r051cb_portal.txt r051cb_portal_89.txt

### Clinic 91
cd $application_production/91
rm r051*portal*
quiz << R051_EXIT  > r051_portal.log
exec $obj/r051ca_portal
91@
exec $obj/r051cb_portal
91@
R051_EXIT

mv r051ca_portal.txt r051ca_portal_91.txt
mv r051cb_portal.txt r051cb_portal_91.txt

### Clinic 92
cd $application_production/92
rm r051*portal*
quiz << R051_EXIT  > r051_portal.log
exec $obj/r051ca_portal
92@
exec $obj/r051cb_portal
92@
R051_EXIT

mv r051ca_portal.txt r051ca_portal_92.txt
mv r051cb_portal.txt r051cb_portal_92.txt

### Clinic 93
cd $application_production/93
rm r051*portal*
quiz << R051_EXIT  > r051_portal.log
exec $obj/r051ca_portal
93@
exec $obj/r051cb_portal
93@
R051_EXIT

mv r051ca_portal.txt r051ca_portal_93.txt
mv r051cb_portal.txt r051cb_portal_93.txt

### Clinic 94
cd $application_production/94
rm r051*portal*
quiz << R051_EXIT  > r051_portal.log
exec $obj/r051ca_portal
94@
exec $obj/r051cb_portal
94@
R051_EXIT

mv r051ca_portal.txt r051ca_portal_94.txt
mv r051cb_portal.txt r051cb_portal_94.txt

### Clinic 95
cd $application_production/95
rm r051*portal*
quiz << R051_EXIT  > r051_portal.log
exec $obj/r051ca_portal
95@
exec $obj/r051cb_portal
95@
R051_EXIT

mv r051ca_portal.txt r051ca_portal_95.txt
mv r051cb_portal.txt r051cb_portal_95.txt

### Clinic 96
cd $application_production/96
rm r051*portal*
quiz << R051_EXIT  > r051_portal.log
exec $obj/r051ca_portal
96@
exec $obj/r051cb_portal
96@
R051_EXIT

mv r051ca_portal.txt r051ca_portal_96.txt
mv r051cb_portal.txt r051cb_portal_96.txt

date
echo Done!


