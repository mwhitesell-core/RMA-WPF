#-------------------------------------------------------------------------------
# File 'purge_claims_rpt.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'purge_claims_rpt'
#-------------------------------------------------------------------------------


echo "Starting r072 Time is$(udate)"

Copy-Item u072-retain-claim-hdr-22.sf u072-retain-claim-hdr.sf
Copy-Item u072-retain-claim-hdr-22.sfd u072-retain-claim-hdr.sfd
Copy-Item u072-delete-claim-hdr-22.sf u072-delete-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-22.sfd u072-delete-claim-hdr.sfd

$pipedInput = @"
exec $obj/r072a.qzc
22
exec $obj/r072b.qzc
22
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
"@

$pipedInput | quiz++

Get-Content r072a.txt, r072b.txt, r072c.txt  > r072_22
Remove-Item r072?.txt
#lp r072_22

Copy-Item u072-retain-claim-hdr-23.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-23.sf u072-delete-claim-hdr.sf

$pipedInput = @"
exec $obj/r072a.qzc
23
exec $obj/r072b.qzc
23
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
"@

$pipedInput | quiz++

Get-Content r072a.txt, r072b.txt, r072c.txt  > r072_23
Remove-Item r072?.txt
#lp r072_23

Copy-Item u072-retain-claim-hdr-31.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-31.sf u072-delete-claim-hdr.sf

$pipedInput = @"
exec $obj/r072a.qzc
31
exec $obj/r072b.qzc
31
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
"@

$pipedInput | quiz++

Get-Content r072a.txt, r072b.txt, r072c.txt  > r072_31
Remove-Item r072?.txt
#lp r072_31

Copy-Item u072-retain-claim-hdr-32.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-32.sf u072-delete-claim-hdr.sf

$pipedInput = @"
exec $obj/r072a.qzc
32
exec $obj/r072b.qzc
32
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
"@

$pipedInput | quiz++

Get-Content r072a.txt, r072b.txt, r072c.txt  > r072_32
Remove-Item r072?.txt
#lp r072_32

Copy-Item u072-retain-claim-hdr-33.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-33.sf u072-delete-claim-hdr.sf

$pipedInput = @"
exec $obj/r072a.qzc
33
exec $obj/r072b.qzc
33
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
"@

$pipedInput | quiz++

Get-Content r072a.txt, r072b.txt, r072c.txt  > r072_33
Remove-Item r072?.txt
#lp r072_33

Copy-Item u072-retain-claim-hdr-34.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-34.sf u072-delete-claim-hdr.sf

$pipedInput = @"
exec $obj/r072a.qzc
34
exec $obj/r072b.qzc
34
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
"@

$pipedInput | quiz++

Get-Content r072a.txt, r072b.txt, r072c.txt  > r072_34
Remove-Item r072?.txt
#lp r072_34

Copy-Item u072-retain-claim-hdr-35.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-35.sf u072-delete-claim-hdr.sf

$pipedInput = @"
exec $obj/r072a.qzc
35
exec $obj/r072b.qzc
35
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
"@

$pipedInput | quiz++

Get-Content r072a.txt, r072b.txt, r072c.txt  > r072_35
Remove-Item r072?.txt
#lp r072_35

Copy-Item u072-retain-claim-hdr-36.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-36.sf u072-delete-claim-hdr.sf

$pipedInput = @"
exec $obj/r072a.qzc
36
exec $obj/r072b.qzc
36
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
"@

$pipedInput | quiz++

Get-Content r072a.txt, r072b.txt, r072c.txt  > r072_36
Remove-Item r072?.txt
#lp r072_36

Copy-Item u072-retain-claim-hdr-37.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-37.sf u072-delete-claim-hdr.sf

$pipedInput = @"
exec $obj/r072a.qzc
37
exec $obj/r072b.qzc
37
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
"@

$pipedInput | quiz++

Get-Content r072a.txt, r072b.txt, r072c.txt  > r072_37
Remove-Item r072?.txt
#lp r072_37

Copy-Item u072-retain-claim-hdr-41.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-41.sf u072-delete-claim-hdr.sf

$pipedInput = @"
exec $obj/r072a.qzc
41
exec $obj/r072b.qzc
41
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
"@

$pipedInput | quiz++

Get-Content r072a.txt, r072b.txt, r072c.txt  > r072_41
Remove-Item r072?.txt
#lp r072_41

Copy-Item u072-retain-claim-hdr-42.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-42.sf u072-delete-claim-hdr.sf

$pipedInput = @"
exec $obj/r072a.qzc
42
exec $obj/r072b.qzc
42
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
"@

$pipedInput | quiz++

Get-Content r072a.txt, r072b.txt, r072c.txt  > r072_42
Remove-Item r072?.txt
#lp r072_42

Copy-Item u072-retain-claim-hdr-43.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-43.sf u072-delete-claim-hdr.sf

$pipedInput = @"
exec $obj/r072a.qzc
43
exec $obj/r072b.qzc
43
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
"@

$pipedInput | quiz++

Get-Content r072a.txt, r072b.txt, r072c.txt  > r072_43
Remove-Item r072?.txt
#lp r072_43

Copy-Item u072-retain-claim-hdr-44.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-44.sf u072-delete-claim-hdr.sf

$pipedInput = @"
exec $obj/r072a.qzc
44
exec $obj/r072b.qzc
44
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
"@

$pipedInput | quiz++

Get-Content r072a.txt, r072b.txt, r072c.txt  > r072_44
Remove-Item r072?.txt
#lp r072_44

Copy-Item u072-retain-claim-hdr-45.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-45.sf u072-delete-claim-hdr.sf

$pipedInput = @"
exec $obj/r072a.qzc
45
exec $obj/r072b.qzc
45
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
"@

$pipedInput | quiz++

Get-Content r072a.txt, r072b.txt, r072c.txt  > r072_45
Remove-Item r072?.txt
#lp r072_45

Copy-Item u072-retain-claim-hdr-46.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-46.sf u072-delete-claim-hdr.sf

$pipedInput = @"
exec $obj/r072a.qzc
46
exec $obj/r072b.qzc
46
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
"@

$pipedInput | quiz++

Get-Content r072a.txt, r072b.txt, r072c.txt  > r072_46
Remove-Item r072?.txt
#lp r072_46

Copy-Item u072-retain-claim-hdr-61.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-61.sf u072-delete-claim-hdr.sf

$pipedInput = @"
exec $obj/r072a.qzc
61
exec $obj/r072b.qzc
61
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
"@

$pipedInput | quiz++

Get-Content r072a.txt, r072b.txt, r072c.txt  > r072_61
Remove-Item r072?.txt
#lp r072_61

Copy-Item u072-retain-claim-hdr-62.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-62.sf u072-delete-claim-hdr.sf

$pipedInput = @"
exec $obj/r072a.qzc
62
exec $obj/r072b.qzc
62
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
"@

$pipedInput | quiz++

Get-Content r072a.txt, r072b.txt, r072c.txt  > r072_62
Remove-Item r072?.txt
#lp r072_62

Copy-Item u072-retain-claim-hdr-63.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-63.sf u072-delete-claim-hdr.sf

$pipedInput = @"
exec $obj/r072a.qzc
63
exec $obj/r072b.qzc
63
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
"@

$pipedInput | quiz++

Get-Content r072a.txt, r072b.txt, r072c.txt  > r072_63
Remove-Item r072?.txt
#lp r072_63

Copy-Item u072-retain-claim-hdr-64.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-64.sf u072-delete-claim-hdr.sf

$pipedInput = @"
exec $obj/r072a.qzc
64
exec $obj/r072b.qzc
64
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
"@

$pipedInput | quiz++

Get-Content r072a.txt, r072b.txt, r072c.txt  > r072_64
Remove-Item r072?.txt
#lp r072_64

Copy-Item u072-retain-claim-hdr-65.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-65.sf u072-delete-claim-hdr.sf

$pipedInput = @"
exec $obj/r072a.qzc
65
exec $obj/r072b.qzc
65
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
"@

$pipedInput | quiz++

Get-Content r072a.txt, r072b.txt, r072c.txt  > r072_65
Remove-Item r072?.txt
#lp r072_65

Copy-Item u072-retain-claim-hdr-66.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-66.sf u072-delete-claim-hdr.sf

$pipedInput = @"
exec $obj/r072a.qzc
66
exec $obj/r072b.qzc
66
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
"@

$pipedInput | quiz++

Get-Content r072a.txt, r072b.txt, r072c.txt  > r072_66
Remove-Item r072?.txt
#lp r072_66

Copy-Item u072-retain-claim-hdr-71.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-71.sf u072-delete-claim-hdr.sf

$pipedInput = @"
exec $obj/r072a.qzc
71
exec $obj/r072b.qzc
71
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
"@

$pipedInput | quiz++

Get-Content r072a.txt, r072b.txt, r072c.txt  > r072_71
Remove-Item r072?.txt
#lp r072_71

Copy-Item u072-retain-claim-hdr-72.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-72.sf u072-delete-claim-hdr.sf


$pipedInput = @"
exec $obj/r072a.qzc
72
exec $obj/r072b.qzc
72
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
"@

$pipedInput | quiz++

Get-Content r072a.txt, r072b.txt, r072c.txt  > r072_72
Remove-Item r072?.txt
#lp r072_72

Copy-Item u072-retain-claim-hdr-73.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-73.sf u072-delete-claim-hdr.sf


$pipedInput = @"
exec $obj/r072a.qzc
73
exec $obj/r072b.qzc
73
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
"@

$pipedInput | quiz++

Get-Content r072a.txt, r072b.txt, r072c.txt  > r072_73
Remove-Item r072?.txt
#lp r072_73

Copy-Item u072-retain-claim-hdr-74.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-74.sf u072-delete-claim-hdr.sf


$pipedInput = @"
exec $obj/r072a.qzc
74
exec $obj/r072b.qzc
74
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
"@

$pipedInput | quiz++

Get-Content r072a.txt, r072b.txt, r072c.txt  > r072_74
Remove-Item r072?.txt
#lp r072_74

Copy-Item u072-retain-claim-hdr-75.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-75.sf u072-delete-claim-hdr.sf


$pipedInput = @"
exec $obj/r072a.qzc
75
exec $obj/r072b.qzc
75
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
"@

$pipedInput | quiz++

Get-Content r072a.txt, r072b.txt, r072c.txt  > r072_75
Remove-Item r072?.txt
#lp r072_75

Copy-Item u072-retain-claim-hdr-78.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-78.sf u072-delete-claim-hdr.sf

$pipedInput = @"
exec $obj/r072a.qzc
78
exec $obj/r072b.qzc
78
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
"@

$pipedInput | quiz++

Get-Content r072a.txt, r072b.txt, r072c.txt  > r072_78
Remove-Item r072?.txt
#lp r072_78

Copy-Item u072-retain-claim-hdr-79.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-79.sf u072-delete-claim-hdr.sf

$pipedInput = @"
exec $obj/r072a.qzc
79
exec $obj/r072b.qzc
79
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
"@

$pipedInput | quiz++

Get-Content r072a.txt, r072b.txt, r072c.txt  > r072_79
Remove-Item r072?.txt
#lp r072_79

Copy-Item u072-retain-claim-hdr-80.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-80.sf u072-delete-claim-hdr.sf

$pipedInput = @"
exec $obj/r072a.qzc
80
exec $obj/r072b.qzc
80
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
"@

$pipedInput | quiz++

Get-Content r072a.txt, r072b.txt, r072c.txt  > r072_80
Remove-Item r072?.txt
#lp r072_80

Copy-Item u072-retain-claim-hdr-82.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-82.sf u072-delete-claim-hdr.sf

$pipedInput = @"
exec $obj/r072a.qzc
82
exec $obj/r072b.qzc
82
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
"@

$pipedInput | quiz++

Get-Content r072a.txt, r072b.txt, r072c.txt  > r072_82
Remove-Item r072?.txt
#lp r072_82

Copy-Item u072-retain-claim-hdr-84.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-84.sf u072-delete-claim-hdr.sf

$pipedInput = @"
exec $obj/r072a.qzc
84
exec $obj/r072b.qzc
84
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
"@

$pipedInput | quiz++

Get-Content r072a.txt, r072b.txt, r072c.txt  > r072_84
Remove-Item r072?.txt
#lp r072_84

Copy-Item u072-retain-claim-hdr-86.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-86.sf u072-delete-claim-hdr.sf

$pipedInput = @"
exec $obj/r072a.qzc
86
exec $obj/r072b.qzc
86
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
"@

$pipedInput | quiz++

Get-Content r072a.txt, r072b.txt, r072c.txt  > r072_86
Remove-Item r072?.txt
#lp r072_86

Copy-Item u072-retain-claim-hdr-87.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-87.sf u072-delete-claim-hdr.sf

$pipedInput = @"
exec $obj/r072a.qzc
87
exec $obj/r072b.qzc
87
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
"@

$pipedInput | quiz++

Get-Content r072a.txt, r072b.txt, r072c.txt  > r072_87
Remove-Item r072?.txt
#lp r072_87

Copy-Item u072-retain-claim-hdr-88.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-88.sf u072-delete-claim-hdr.sf

$pipedInput = @"
exec $obj/r072a.qzc
88
exec $obj/r072b.qzc
88
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
"@

$pipedInput | quiz++

Get-Content r072a.txt, r072b.txt, r072c.txt  > r072_88
Remove-Item r072?.txt
#lp r072_88

Copy-Item u072-retain-claim-hdr-89.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-89.sf u072-delete-claim-hdr.sf

$pipedInput = @"
exec $obj/r072a.qzc
89
exec $obj/r072b.qzc
89
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
"@

$pipedInput | quiz++

Get-Content r072a.txt, r072b.txt, r072c.txt  > r072_89
Remove-Item r072?.txt
#lp r072_89

Copy-Item u072-retain-claim-hdr-91.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-91.sf u072-delete-claim-hdr.sf

$pipedInput = @"
exec $obj/r072a.qzc
91
exec $obj/r072b.qzc
91
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
"@

$pipedInput | quiz++

Get-Content r072a.txt, r072b.txt, r072c.txt  > r072_91
Remove-Item r072?.txt
#lp r072_91

Copy-Item u072-retain-claim-hdr-92.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-92.sf u072-delete-claim-hdr.sf


$pipedInput = @"
exec $obj/r072a.qzc
92
exec $obj/r072b.qzc
92
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
"@

$pipedInput | quiz++

Get-Content r072a.txt, r072b.txt, r072c.txt  > r072_92
Remove-Item r072?.txt
#lp r072_92

Copy-Item u072-retain-claim-hdr-93.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-93.sf u072-delete-claim-hdr.sf

$pipedInput = @"
exec $obj/r072a.qzc
93
exec $obj/r072b.qzc
93
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
"@

$pipedInput | quiz++

Get-Content r072a.txt, r072b.txt, r072c.txt  > r072_93
Remove-Item r072?.txt
#lp r072_93

Copy-Item u072-retain-claim-hdr-94.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-94.sf u072-delete-claim-hdr.sf

$pipedInput = @"
exec $obj/r072a.qzc
94
exec $obj/r072b.qzc
94
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
"@

$pipedInput | quiz++

Get-Content r072a.txt, r072b.txt, r072c.txt  > r072_94
Remove-Item r072?.txt
#lp r072_94

Copy-Item u072-retain-claim-hdr-95.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-95.sf u072-delete-claim-hdr.sf

$pipedInput = @"
exec $obj/r072a.qzc
95
exec $obj/r072b.qzc
95
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
"@

$pipedInput | quiz++

Get-Content r072a.txt, r072b.txt, r072c.txt  > r072_95
Remove-Item r072?.txt
#lp r072_95

Copy-Item u072-retain-claim-hdr-96.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-96.sf u072-delete-claim-hdr.sf

$pipedInput = @"
exec $obj/r072a.qzc
96
exec $obj/r072b.qzc
96
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
"@

$pipedInput | quiz++

Get-Content r072a.txt, r072b.txt, r072c.txt  > r072_96
Remove-Item r072?.txt
#lp r072_96

Copy-Item u072-retain-claim-hdr-98.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-98.sf u072-delete-claim-hdr.sf

$pipedInput = @"
exec $obj/r072a.qzc
98
exec $obj/r072b.qzc
98
exec $obj/r072c.qzc
exec $obj/r072d.qzc
exec $obj/r072e.qzc
exit
"@

$pipedInput | quiz++

Get-Content r072a.txt, r072b.txt, r072c.txt  > r072_98
Remove-Item r072?.txt
#lp r072_98

echo "Ending R072 Time is$(udate)"

#----------------
