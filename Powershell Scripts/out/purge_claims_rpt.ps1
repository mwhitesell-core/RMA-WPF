#-------------------------------------------------------------------------------
# File 'purge_claims_rpt.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'purge_claims_rpt'
#-------------------------------------------------------------------------------


echo "Starting r072 Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

Copy-Item u072-retain-claim-hdr-22.sf u072-retain-claim-hdr.sf
Copy-Item u072-retain-claim-hdr-22.sfd u072-retain-claim-hdr.sfd
Copy-Item u072-delete-claim-hdr-22.sf u072-delete-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-22.sfd u072-delete-claim-hdr.sfd

&$env:QUIZ r072a 22
&$env:QUIZ r072b 22
&$env:QUIZ r072c

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

&$env:QUIZ r072d

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

&$env:QUIZ r072e

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_22
Remove-Item r072?.txt
#lp r072_22

Copy-Item u072-retain-claim-hdr-23.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-23.sf u072-delete-claim-hdr.sf

&$env:QUIZ r072a 23
&$env:QUIZ r072b 23
&$env:QUIZ r072c

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

&$env:QUIZ r072d

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

&$env:QUIZ r072e

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_23
Remove-Item r072?.txt
#lp r072_23

Copy-Item u072-retain-claim-hdr-31.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-31.sf u072-delete-claim-hdr.sf

&$env:QUIZ r072a 31
&$env:QUIZ r072b 31
&$env:QUIZ r072c

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

&$env:QUIZ r072d

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

&$env:QUIZ r072e

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_31
Remove-Item r072?.txt
#lp r072_31

Copy-Item u072-retain-claim-hdr-32.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-32.sf u072-delete-claim-hdr.sf

&$env:QUIZ r072a 32
&$env:QUIZ r072b 32
&$env:QUIZ r072c

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

&$env:QUIZ r072d

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

&$env:QUIZ r072e

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_32
Remove-Item r072?.txt
#lp r072_32

Copy-Item u072-retain-claim-hdr-33.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-33.sf u072-delete-claim-hdr.sf

&$env:QUIZ r072a 33
&$env:QUIZ r072b 33
&$env:QUIZ r072c

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

&$env:QUIZ r072d

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

&$env:QUIZ r072e

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_33
Remove-Item r072?.txt
#lp r072_33

Copy-Item u072-retain-claim-hdr-34.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-34.sf u072-delete-claim-hdr.sf

&$env:QUIZ r072a 34
&$env:QUIZ r072b 34
&$env:QUIZ r072c

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

&$env:QUIZ r072d

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

&$env:QUIZ r072e

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_34
Remove-Item r072?.txt
#lp r072_34

Copy-Item u072-retain-claim-hdr-35.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-35.sf u072-delete-claim-hdr.sf

&$env:QUIZ r072a 35
&$env:QUIZ r072b 35
&$env:QUIZ r072c

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

&$env:QUIZ r072d

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

&$env:QUIZ r072e

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_35
Remove-Item r072?.txt
#lp r072_35

Copy-Item u072-retain-claim-hdr-36.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-36.sf u072-delete-claim-hdr.sf

&$env:QUIZ r072a 36
&$env:QUIZ r072b 36
&$env:QUIZ r072c

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

&$env:QUIZ r072d

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

&$env:QUIZ r072e

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_36
Remove-Item r072?.txt
#lp r072_36

Copy-Item u072-retain-claim-hdr-37.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-37.sf u072-delete-claim-hdr.sf

&$env:QUIZ r072a 37
&$env:QUIZ r072b 37
&$env:QUIZ r072c

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

&$env:QUIZ r072d

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

&$env:QUIZ r072e

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_37
Remove-Item r072?.txt
#lp r072_37

Copy-Item u072-retain-claim-hdr-41.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-41.sf u072-delete-claim-hdr.sf

&$env:QUIZ r072a 41
&$env:QUIZ r072b 41
&$env:QUIZ r072c

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

&$env:QUIZ r072d

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

&$env:QUIZ r072e

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_41
Remove-Item r072?.txt
#lp r072_41

Copy-Item u072-retain-claim-hdr-42.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-42.sf u072-delete-claim-hdr.sf

&$env:QUIZ r072a 42
&$env:QUIZ r072b 42
&$env:QUIZ r072c

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

&$env:QUIZ r072d

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

&$env:QUIZ r072e

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_42
Remove-Item r072?.txt
#lp r072_42

Copy-Item u072-retain-claim-hdr-43.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-43.sf u072-delete-claim-hdr.sf

&$env:QUIZ r072a 43
&$env:QUIZ r072b 43
&$env:QUIZ r072c

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

&$env:QUIZ r072d

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

&$env:QUIZ r072e

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_43
Remove-Item r072?.txt
#lp r072_43

Copy-Item u072-retain-claim-hdr-44.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-44.sf u072-delete-claim-hdr.sf

&$env:QUIZ r072a 44
&$env:QUIZ r072b 44
&$env:QUIZ r072c

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

&$env:QUIZ r072d

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

&$env:QUIZ r072e

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_44
Remove-Item r072?.txt
#lp r072_44

Copy-Item u072-retain-claim-hdr-45.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-45.sf u072-delete-claim-hdr.sf

&$env:QUIZ r072a 45
&$env:QUIZ r072b 45
&$env:QUIZ r072c

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

&$env:QUIZ r072d

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

&$env:QUIZ r072e

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_45
Remove-Item r072?.txt
#lp r072_45

Copy-Item u072-retain-claim-hdr-46.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-46.sf u072-delete-claim-hdr.sf

&$env:QUIZ r072a 46
&$env:QUIZ r072b 46
&$env:QUIZ r072c

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

&$env:QUIZ r072d

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

&$env:QUIZ r072e

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_46
Remove-Item r072?.txt
#lp r072_46

Copy-Item u072-retain-claim-hdr-61.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-61.sf u072-delete-claim-hdr.sf

&$env:QUIZ r072a 61
&$env:QUIZ r072b 61
&$env:QUIZ r072c

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

&$env:QUIZ r072d

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

&$env:QUIZ r072e

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_61
Remove-Item r072?.txt
#lp r072_61

Copy-Item u072-retain-claim-hdr-62.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-62.sf u072-delete-claim-hdr.sf

&$env:QUIZ r072a 62
&$env:QUIZ r072b 62
&$env:QUIZ r072c

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

&$env:QUIZ r072d

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

&$env:QUIZ r072e

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_62
Remove-Item r072?.txt
#lp r072_62

Copy-Item u072-retain-claim-hdr-63.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-63.sf u072-delete-claim-hdr.sf

&$env:QUIZ r072a 63
&$env:QUIZ r072b 63
&$env:QUIZ r072c

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

&$env:QUIZ r072d

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

&$env:QUIZ r072e

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_63
Remove-Item r072?.txt
#lp r072_63

Copy-Item u072-retain-claim-hdr-64.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-64.sf u072-delete-claim-hdr.sf

&$env:QUIZ r072a 64
&$env:QUIZ r072b 64
&$env:QUIZ r072c

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

&$env:QUIZ r072d

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

&$env:QUIZ r072e

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_64
Remove-Item r072?.txt
#lp r072_64

Copy-Item u072-retain-claim-hdr-65.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-65.sf u072-delete-claim-hdr.sf

&$env:QUIZ r072a 65
&$env:QUIZ r072b 65
&$env:QUIZ r072c

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

&$env:QUIZ r072d

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

&$env:QUIZ r072e

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_65
Remove-Item r072?.txt
#lp r072_65

Copy-Item u072-retain-claim-hdr-66.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-66.sf u072-delete-claim-hdr.sf

&$env:QUIZ r072a 66
&$env:QUIZ r072b 66
&$env:QUIZ r072c

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

&$env:QUIZ r072d

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

&$env:QUIZ r072e

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_66
Remove-Item r072?.txt
#lp r072_66

Copy-Item u072-retain-claim-hdr-71.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-71.sf u072-delete-claim-hdr.sf

&$env:QUIZ r072a 71
&$env:QUIZ r072b 71
&$env:QUIZ r072c

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

&$env:QUIZ r072d

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

&$env:QUIZ r072e

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_71
Remove-Item r072?.txt
#lp r072_71

Copy-Item u072-retain-claim-hdr-72.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-72.sf u072-delete-claim-hdr.sf


&$env:QUIZ r072a 72
&$env:QUIZ r072b 72
&$env:QUIZ r072c

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

&$env:QUIZ r072d

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

&$env:QUIZ r072e

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_72
Remove-Item r072?.txt
#lp r072_72

Copy-Item u072-retain-claim-hdr-73.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-73.sf u072-delete-claim-hdr.sf


&$env:QUIZ r072a 73
&$env:QUIZ r072b 73
&$env:QUIZ r072c

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

&$env:QUIZ r072d

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

&$env:QUIZ r072e

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_73
Remove-Item r072?.txt
#lp r072_73

Copy-Item u072-retain-claim-hdr-74.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-74.sf u072-delete-claim-hdr.sf


&$env:QUIZ r072a 74
&$env:QUIZ r072b 74
&$env:QUIZ r072c

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

&$env:QUIZ r072d

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

&$env:QUIZ r072e

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_74
Remove-Item r072?.txt
#lp r072_74

Copy-Item u072-retain-claim-hdr-75.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-75.sf u072-delete-claim-hdr.sf


&$env:QUIZ r072a 75
&$env:QUIZ r072b 75
&$env:QUIZ r072c

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

&$env:QUIZ r072d

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

&$env:QUIZ r072e

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_75
Remove-Item r072?.txt
#lp r072_75

Copy-Item u072-retain-claim-hdr-78.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-78.sf u072-delete-claim-hdr.sf

&$env:QUIZ r072a 78
&$env:QUIZ r072b 78
&$env:QUIZ r072c

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

&$env:QUIZ r072d

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

&$env:QUIZ r072e

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_78
Remove-Item r072?.txt
#lp r072_78

Copy-Item u072-retain-claim-hdr-79.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-79.sf u072-delete-claim-hdr.sf

&$env:QUIZ r072a 79
&$env:QUIZ r072b 79
&$env:QUIZ r072c

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

&$env:QUIZ r072d

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

&$env:QUIZ r072e

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_79
Remove-Item r072?.txt
#lp r072_79

Copy-Item u072-retain-claim-hdr-80.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-80.sf u072-delete-claim-hdr.sf

&$env:QUIZ r072a 80
&$env:QUIZ r072b 80
&$env:QUIZ r072c

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

&$env:QUIZ r072d

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

&$env:QUIZ r072e

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_80
Remove-Item r072?.txt
#lp r072_80

Copy-Item u072-retain-claim-hdr-82.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-82.sf u072-delete-claim-hdr.sf

&$env:QUIZ r072a 82
&$env:QUIZ r072b 82
&$env:QUIZ r072c

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

&$env:QUIZ r072d

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

&$env:QUIZ r072e

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_82
Remove-Item r072?.txt
#lp r072_82

Copy-Item u072-retain-claim-hdr-84.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-84.sf u072-delete-claim-hdr.sf

&$env:QUIZ r072a 84
&$env:QUIZ r072b 84
&$env:QUIZ r072c

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

&$env:QUIZ r072d

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

&$env:QUIZ r072e

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_84
Remove-Item r072?.txt
#lp r072_84

Copy-Item u072-retain-claim-hdr-86.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-86.sf u072-delete-claim-hdr.sf

&$env:QUIZ r072a 86
&$env:QUIZ r072b 86
&$env:QUIZ r072c

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

&$env:QUIZ r072d

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

&$env:QUIZ r072e

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_86
Remove-Item r072?.txt
#lp r072_86

Copy-Item u072-retain-claim-hdr-87.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-87.sf u072-delete-claim-hdr.sf

&$env:QUIZ r072a 87
&$env:QUIZ r072b 87
&$env:QUIZ r072c

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

&$env:QUIZ r072d

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

&$env:QUIZ r072e

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_87
Remove-Item r072?.txt
#lp r072_87

Copy-Item u072-retain-claim-hdr-88.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-88.sf u072-delete-claim-hdr.sf

&$env:QUIZ r072a 88
&$env:QUIZ r072b 88
&$env:QUIZ r072c

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

&$env:QUIZ r072d

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

&$env:QUIZ r072e

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_88
Remove-Item r072?.txt
#lp r072_88

Copy-Item u072-retain-claim-hdr-89.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-89.sf u072-delete-claim-hdr.sf

&$env:QUIZ r072a 89
&$env:QUIZ r072b 89
&$env:QUIZ r072c

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

&$env:QUIZ r072d

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

&$env:QUIZ r072e

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_89
Remove-Item r072?.txt
#lp r072_89

Copy-Item u072-retain-claim-hdr-91.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-91.sf u072-delete-claim-hdr.sf

&$env:QUIZ r072a 91
&$env:QUIZ r072b 91
&$env:QUIZ r072c

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

&$env:QUIZ r072d

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

&$env:QUIZ r072e

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_91
Remove-Item r072?.txt
#lp r072_91

Copy-Item u072-retain-claim-hdr-92.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-92.sf u072-delete-claim-hdr.sf


&$env:QUIZ r072a 92
&$env:QUIZ r072b 92
&$env:QUIZ r072c

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

&$env:QUIZ r072d

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

&$env:QUIZ r072e

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_92
Remove-Item r072?.txt
#lp r072_92

Copy-Item u072-retain-claim-hdr-93.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-93.sf u072-delete-claim-hdr.sf

&$env:QUIZ r072a 93
&$env:QUIZ r072b 93
&$env:QUIZ r072c

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

&$env:QUIZ r072d

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

&$env:QUIZ r072e

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_93
Remove-Item r072?.txt
#lp r072_93

Copy-Item u072-retain-claim-hdr-94.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-94.sf u072-delete-claim-hdr.sf

&$env:QUIZ r072a 94
&$env:QUIZ r072b 94
&$env:QUIZ r072c

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

&$env:QUIZ r072d

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

&$env:QUIZ r072e

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_94
Remove-Item r072?.txt
#lp r072_94

Copy-Item u072-retain-claim-hdr-95.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-95.sf u072-delete-claim-hdr.sf

&$env:QUIZ r072a 95
&$env:QUIZ r072b 95
&$env:QUIZ r072c

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

&$env:QUIZ r072d

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

&$env:QUIZ r072e

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_95
Remove-Item r072?.txt
#lp r072_95

Copy-Item u072-retain-claim-hdr-96.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-96.sf u072-delete-claim-hdr.sf

&$env:QUIZ r072a 96
&$env:QUIZ r072b 96
&$env:QUIZ r072c

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

&$env:QUIZ r072d

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

&$env:QUIZ r072e

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_96
Remove-Item r072?.txt
#lp r072_96

Copy-Item u072-retain-claim-hdr-98.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-98.sf u072-delete-claim-hdr.sf

&$env:QUIZ r072a 98
&$env:QUIZ r072b 98
&$env:QUIZ r072c

#Core - Added to rename report according to quiz file
Get-Content r072c.txt > r072a.txt

&$env:QUIZ r072d

#Core - Added to rename report according to quiz file
Get-Content r072d.txt > r072b.txt

&$env:QUIZ r072e

#Core - Added to rename report according to quiz file
Get-Content r072e.txt > r072c.txt

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_98
Remove-Item r072?.txt
#lp r072_98

echo "Ending R072 Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

#----------------
