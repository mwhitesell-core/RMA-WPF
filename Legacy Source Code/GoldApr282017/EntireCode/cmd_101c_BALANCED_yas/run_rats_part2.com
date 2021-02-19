#
# $cmd/runs_rats_part2.com  (rerun of the missing clinics)

date


#-------------------

cd $application_production/23
$cmd/u030_clinic_dtl_part2  > u030_dtl_part2.log

cd $application_production/24
$cmd/u030_clinic_dtl_part2  > u030_dtl_part2.log

cd $application_production/25
$cmd/u030_clinic_dtl_part2  > u030_dtl_part2.log

#-------------------

cd $application_production/31
$cmd/u030_clinic_dtl_part2  > u030_dtl_part2.log

cd $application_production/32
$cmd/u030_clinic_dtl_part2  > u030_dtl_part2.log

cd $application_production/33
$cmd/u030_clinic_dtl_part2  > u030_dtl_part2.log

cd $application_production/34
$cmd/u030_clinic_dtl_part2  > u030_dtl_part2.log

cd $application_production/35
$cmd/u030_clinic_dtl_part2  > u030_dtl_part2.log

cd $application_production/37
$cmd/u030_clinic_dtl_part2  > u030_dtl_part2.log

#-------------------

cd $application_production/41
$cmd/u030_clinic_dtl_part2  > u030_dtl_part2.log

cd $application_production/42
$cmd/u030_clinic_dtl_part2  > u030_dtl_part2.log

cd $application_production/43
$cmd/u030_clinic_dtl_part2  > u030_dtl_part2.log

cd $application_production/44
$cmd/u030_clinic_dtl_part2  > u030_dtl_part2.log

cd $application_production/45
$cmd/u030_clinic_dtl_part2  > u030_dtl_part2.log

#-------------------

cd $application_production/80
$cmd/u030_clinic_dtl_part2  > u030_dtl_part2.log

cd $application_production/82
$cmd/u030_clinic_dtl_part2  > u030_dtl_part2.log

cd $application_production/84
$cmd/u030_clinic_dtl_part2  > u030_dtl_part2.log

cd $application_production/87
$cmd/u030_clinic_dtl_part2  > u030_dtl_part2.log

cd $application_production/89
$cmd/u030_clinic_dtl_part2  > u030_dtl_part2.log

#####################

cd $application_production/91
$cmd/u030_clinic_dtl_part2  > u030_dtl_part2.log

cd $application_production/92
$cmd/u030_clinic_dtl_part2  > u030_dtl_part2.log

cd $application_production/93
$cmd/u030_clinic_dtl_part2  > u030_dtl_part2.log

cd $application_production/94
$cmd/u030_clinic_dtl_part2  > u030_dtl_part2.log

cd $application_production/95
$cmd/u030_clinic_dtl_part2  > u030_dtl_part2.log

cd $application_production/96
$cmd/u030_clinic_dtl_part2  > u030_dtl_part2.log

#-------------------

date

