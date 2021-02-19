echo
echo  'Hit new line to run clinic 22 group 2215  ...'
read garbage
echo
cd $pb_data
mv P*2215* ohip_rat_ascii
cd $application_production
#cobrun $obj/u030a 1>u030a.log 2>&1 << RAT_EXIT
# use above line if you don't want the amount displayed but put on log file
#log file does not keep the screen values
cobrun $obj/u030a  << RAT_EXIT
2215
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_22
echo 
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage 

#################
echo
echo  'Hit new line to run clinic 23 group 0706  ...'
read garbage
echo
cd $pb_data
mv P*0706* ohip_rat_ascii
cd $application_production/23
cobrun $obj/u030a  << RAT_EXIT
0706
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_23
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage

#################
echo
echo  'Hit new line to run clinic 24 group AB99  ...'
read garbage
echo
cd $pb_data
mv P*AB99* ohip_rat_ascii
cd $application_production/24
cobrun $obj/u030a  << RAT_EXIT
AB99
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_24
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage

#################
echo
echo  'Hit new line to run clinic 25 group 0930  ...'
read garbage
echo
cd $pb_data
mv P*0930* ohip_rat_ascii
cd $application_production/25
cobrun $obj/u030a  << RAT_EXIT
0930
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_25
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage

#################
echo
echo  'Hit new line to run clinic 26 group 1837 ...'
read garbage
echo
cd $pb_data
mv P*1837* ohip_rat_ascii
cd $application_production/26
cobrun $obj/u030a  << RAT_EXIT
1837
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_26
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage

#################
echo
echo  'Hit new line to run clinic 30 group H290  ...'
read garbage
echo
cd $pb_data
mv P*H290* ohip_rat_ascii
cd $application_production/30
cobrun $obj/u030a  << RAT_EXIT
H290
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_30
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage

#################
echo
echo  'Hit new line to run clinic 31 group H104  ...'
read garbage
echo
cd $pb_data
mv P*H104* ohip_rat_ascii
cd $application_production/31
cobrun $obj/u030a  << RAT_EXIT
H104
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_31
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage

#################
echo
echo  'Hit new line to run clinic 32 group H061  ...'
read garbage
echo
cd $pb_data
mv P*H061* ohip_rat_ascii
cd $application_production/32
cobrun $obj/u030a  << RAT_EXIT
H061
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_32
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage

#################
echo
echo  'Hit new line to run clinic 33 group H107  ...'
read garbage
echo
cd $pb_data
mv P*H107* ohip_rat_ascii
cd $application_production/33
cobrun $obj/u030a  << RAT_EXIT
H107
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_33
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage

#################
echo
echo  'Hit new line to run clinic 34 group H105    ...'
read garbage
echo
cd $pb_data
mv P*H105* ohip_rat_ascii
cd $application_production/34
cobrun $obj/u030a  << RAT_EXIT
H105
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_34
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage

#################
echo
echo  'Hit new line to run clinic 35 group H106  ...'
read garbage
echo
cd $pb_data
mv P*H106* ohip_rat_ascii
cd $application_production/35
cobrun $obj/u030a  << RAT_EXIT
H106
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_35
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage

#################
echo
echo  'Hit new line to run clinic 36 group H103  ...'
read garbage
echo
cd $pb_data
mv P*H103* ohip_rat_ascii
cd $application_production/36
cobrun $obj/u030a  << RAT_EXIT
H103
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_36
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage

#################
echo
echo  'Hit new line to run clinic 37 group 6411  ...'
read garbage
echo
cd $pb_data
mv P*6411* ohip_rat_ascii
cd $application_production/37
cobrun $obj/u030a  << RAT_EXIT
6411
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_37
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage

#################

echo
echo  'Hit new line to run clinic 41 group H108  ...'
read garbage
echo
cd $pb_data
mv P*H108* ohip_rat_ascii
cd $application_production/41
cobrun $obj/u030a  << RAT_EXIT
H108
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_41
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage

#################
echo
echo  'Hit new line to run clinic 42 group H110  ...'
read garbage
echo
cd $pb_data
mv P*H110* ohip_rat_ascii
cd $application_production/42
cobrun $obj/u030a  << RAT_EXIT
H110
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_42
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage

#################
echo
echo  'Hit new line to run clinic 43 group H055  ...'
read garbage
echo
cd $pb_data
mv P*H055* ohip_rat_ascii
cd $application_production/43
cobrun $obj/u030a  << RAT_EXIT
H055
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_43
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage

#################
echo
echo  'Hit new line to run clinic 44 group H111  ...'
read garbage
echo
cd $pb_data
mv P*H111* ohip_rat_ascii
cd $application_production/44
cobrun $obj/u030a  << RAT_EXIT
H111
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_44
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage

#################
echo
echo  'Hit new line to run clinic 45 group H112...'
read garbage
echo
cd $pb_data
mv P*H112* ohip_rat_ascii
cd $application_production/45
cobrun $obj/u030a  << RAT_EXIT
H112
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_45
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage

#################
echo
echo  'Hit new line to run clinic 46 group H147  ...'
read garbage
echo
cd $pb_data
mv P*H147* ohip_rat_ascii
cd $application_production/46
cobrun $obj/u030a  << RAT_EXIT
H147
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_46
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage

#################
echo
echo  'Hit new line to run clinic 61 group 9595  ...'
read garbage
echo
cd $pb_data
mv P*9595* ohip_rat_ascii
cd $application_production/61
cobrun $obj/u030a  << RAT_EXIT
9595
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_61
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage

#################
echo
echo  'Hit new line to run clinic 62 group 9598  ...'
read garbage
echo
cd $pb_data
mv P*9598* ohip_rat_ascii
cd $application_production/62
cobrun $obj/u030a  << RAT_EXIT
9598
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_62
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage

#################
echo
echo  'Hit new line to run clinic 63 group 9607  ...'
read garbage
echo
cd $pb_data
mv P*9607* ohip_rat_ascii
cd $application_production/63
cobrun $obj/u030a  << RAT_EXIT
9607
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_63
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage

#################
echo
echo  'Hit new line to run clinic 64 group 9619  ...'
read garbage
echo
cd $pb_data
mv P*9619* ohip_rat_ascii
cd $application_production/64
cobrun $obj/u030a  << RAT_EXIT
9619
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_64
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage

#################
echo
echo  'Hit new line to run clinic 65 group 9632  ...'
read garbage
echo
cd $pb_data
mv P*9632* ohip_rat_ascii
cd $application_production/65
cobrun $obj/u030a  << RAT_EXIT
9632
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_65
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage
#################
echo
echo  'Hit new line to run clinic 66 group 9098  ...'
read garbage
echo
cd $pb_data
mv P*9098* ohip_rat_ascii
cd $application_production/66
cobrun $obj/u030a  << RAT_EXIT
9098
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_66
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage
#################
echo
echo  'Hit new line to run clinic 68 group 6064  ...'
read garbage
echo
cd $pb_data
mv P*6064* ohip_rat_ascii
cd $application_production/68
cobrun $obj/u030a  << RAT_EXIT
6064
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_68
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage
#################

echo
echo  'Hit new line to run clinic 69 group AA5B  ...'
read garbage
echo
cd $pb_data
mv P*AA5B* ohip_rat_ascii
cd $application_production/69
cobrun $obj/u030a  << RAT_EXIT
AA5B
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_69
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage
#################
echo
echo
echo  'Hit new line to run clinic 71 group H520  ...'
read garbage
echo
cd $pb_data
mv P*H520* ohip_rat_ascii
cd $application_production/71
cobrun $obj/u030a  << RAT_EXIT
H520 
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_71
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage
#################
echo
echo  'Hit new line to run clinic 72 group H521  ...'
read garbage
echo
cd $pb_data
mv P*H521* ohip_rat_ascii
cd $application_production/72
cobrun $obj/u030a  << RAT_EXIT
H521
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_72
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage
#################
echo
echo  'Hit new line to run clinic 73 group H522  ...'
read garbage
echo
cd $pb_data
mv P*H522* ohip_rat_ascii
cd $application_production/73
cobrun $obj/u030a  << RAT_EXIT
H522
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_73
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage
#################
echo
echo  'Hit new line to run clinic 74 group H523  ...'
read garbage
echo
cd $pb_data
mv P*H523* ohip_rat_ascii
cd $application_production/74
cobrun $obj/u030a  << RAT_EXIT
H523
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_74
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage
#################
echo
echo  'Hit new line to run clinic 75 group H524  ...'
read garbage
echo
cd $pb_data
mv P*H524* ohip_rat_ascii
cd $application_production/75
cobrun $obj/u030a  << RAT_EXIT
H524
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_75
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage
#################
echo
echo  'Hit new line to run clinic 78 group AA8U  ...'
read garbage
echo
cd $pb_data
mv P*AA8U* ohip_rat_ascii
cd $application_production/78
cobrun $obj/u030a  << RAT_EXIT
AA8U
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_78
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage
#################
echo
echo  'Hit new line to run clinic 80 group AA32  ...'
read garbage
echo
cd $pb_data
mv P*AA32* ohip_rat_ascii
cd $application_production/80
cobrun $obj/u030a  << RAT_EXIT
AA32
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_80
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage

#################
echo
echo  'Hit new line to run clinic 82 group AA21  ...'
read garbage
echo
cd $pb_data
mv P*AA21* ohip_rat_ascii
cd $application_production/82
cobrun $obj/u030a  << RAT_EXIT
AA21
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_82
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage

#################
echo
echo  'Hit new line to run clinic 84 group 6072  ...'
read garbage
echo
cd $pb_data
mv P*6072* ohip_rat_ascii
cd $application_production/84
cobrun $obj/u030a  << RAT_EXIT
6072
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_84
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage

#################
echo
echo  'Hit new line to run clinic 86 group AA18  ...'
read garbage
echo
cd $pb_data
mv P*AA18* ohip_rat_ascii
cd $application_production/86
cobrun $obj/u030a  << RAT_EXIT
AA18
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_86
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage

#################
echo
echo  'Hit new line to run clinic 87 group C001  ...'
read garbage
echo
cd $pb_data
mv P*C001* ohip_rat_ascii
cd $application_production/87
cobrun $obj/u030a  << RAT_EXIT
C001
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_87
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage

#################
echo
echo  'Hit new line to run clinic 88 group AA3F  ...'
read garbage
echo
cd $pb_data
mv P*AA3F* ohip_rat_ascii
cd $application_production/88
cobrun $obj/u030a  << RAT_EXIT
AA3F
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_88
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage

#################
echo
echo  'Hit new line to run clinic 89 group C022  ...'
read garbage
echo
cd $pb_data
mv P*C022* ohip_rat_ascii
cd $application_production/89
cobrun $obj/u030a  << RAT_EXIT
C022
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_89
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage

#################
echo
echo  'Hit new line to run clinic 91 group AA5V  ...'
read garbage
echo
cd $pb_data
mv P*AA5V* ohip_rat_ascii
cd $application_production/91
cobrun $obj/u030a  << RAT_EXIT
AA5V
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_91
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage

#################
echo
echo  'Hit new line to run clinic 92 group AA5W  ...'
read garbage
echo
cd $pb_data
mv P*AA5W* ohip_rat_ascii
cd $application_production/92
cobrun $obj/u030a  << RAT_EXIT
AA5W
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_92
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage

#################
echo
echo  'Hit new line to run clinic 93 group AA5X  ...'
read garbage
echo
cd $pb_data
mv P*AA5X* ohip_rat_ascii
cd $application_production/93
cobrun $obj/u030a  << RAT_EXIT
AA5X
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_93
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage

#################
echo
echo  'Hit new line to run clinic 94 group AA5Y  ...'
read garbage
echo
cd $pb_data
mv P*AA5Y* ohip_rat_ascii
cd $application_production/94
cobrun $obj/u030a  << RAT_EXIT
AA5Y
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_94
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage

#################
echo
echo  'Hit new line to run clinic 95 group AA2K  ...'
read garbage
echo
cd $pb_data
mv P*AA2K* ohip_rat_ascii
cd $application_production/95
cobrun $obj/u030a  << RAT_EXIT
AA2K
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_95
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage

#################
echo
echo  'Hit new line to run clinic 96 group 6317  ...'
read garbage
echo
cd $pb_data
mv P*6317* ohip_rat_ascii
cd $application_production/96
cobrun $obj/u030a  << RAT_EXIT
6317
${1}
Y
RAT_EXIT
cd $pb_data
mv ohip_rat_ascii ohip_rat_ascii_96
echo
echo  'To finish this run  hit   "NEWLINE"  ...'
read garbage

