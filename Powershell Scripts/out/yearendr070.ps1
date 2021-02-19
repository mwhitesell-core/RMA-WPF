#-------------------------------------------------------------------------------
# File 'yearendr070.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'yearendr070'
#-------------------------------------------------------------------------------

&$env:COBOL r070a 22 Y Y

&$env:COBOL r070b

&$env:COBOL r070c N

#lp r070_22

&$env:COBOL r070a 23 Y Y

&$env:COBOL r070b

&$env:COBOL r070c N

#lp r070_23

&$env:COBOL r070a 24 Y Y

&$env:COBOL r070b

&$env:COBOL r070c N

#lp r070_24

&$env:COBOL r070a 25 Y Y

&$env:COBOL r070b

&$env:COBOL r070c N

#lp r070_25

&$env:COBOL r070a 26 Y Y

&$env:COBOL r070b

&$env:COBOL r070c N

#lp r070_26

&$env:COBOL r070a 30 Y Y

&$env:COBOL r070b

&$env:COBOL r070c N

#lp r070_30

&$env:COBOL r070a 31 Y Y

&$env:COBOL r070b

&$env:COBOL r070c N

#lp r070_31

&$env:COBOL r070a 32 Y Y

&$env:COBOL r070b

&$env:COBOL r070c N

#lp r070_32

&$env:COBOL r070a 33 Y Y

&$env:COBOL r070b

&$env:COBOL r070c N

#lp r070_33

&$env:COBOL r070a 34 Y Y

&$env:COBOL r070b

&$env:COBOL r070c N

#lp r070_34

&$env:COBOL r070a 35 Y Y

&$env:COBOL r070b

&$env:COBOL r070c N

#lp r070_35

&$env:COBOL r070a 36 Y Y

&$env:COBOL r070b

&$env:COBOL r070c N

#lp r070_36

&$env:COBOL r070a 37 Y Y

&$env:COBOL r070b

&$env:COBOL r070c N

#lp r070_37

&$env:COBOL r070a 41 Y Y

&$env:COBOL r070b

&$env:COBOL r070c N

#lp r070_41

&$env:COBOL r070a 42 Y Y

&$env:COBOL r070b

&$env:COBOL r070c N

#lp r070_42

&$env:COBOL r070a 43 Y Y

&$env:COBOL r070b

&$env:COBOL r070c N

#lp r070_43

&$env:COBOL r070a 44 Y Y

&$env:COBOL r070b

&$env:COBOL r070c N

#lp r070_44

&$env:COBOL r070a 45 Y Y

&$env:COBOL r070b

&$env:COBOL r070c N

#lp r070_45

&$env:COBOL r070a 46 Y Y

&$env:COBOL r070b

&$env:COBOL r070c N

#lp r070_46

&$env:COBOL r070a 68 Y Y

&$env:COBOL r070b

&$env:COBOL r070c N

#lp r070_68

&$env:COBOL r070a 69 Y Y

&$env:COBOL r070b

&$env:COBOL r070c N

#lp r070_69

&$env:COBOL r070a 78 Y Y

&$env:COBOL r070b

&$env:COBOL r070c N

#lp r070_78

&$env:COBOL r070a 79 Y Y

&$env:COBOL r070b

&$env:COBOL r070c N

#lp r070_79

&$env:COBOL r070a 80 Y Y

&$env:COBOL r070b

&$env:COBOL r070c N

#lp r070_80


&$env:COBOL r070a 82 Y Y

&$env:COBOL r070b

&$env:COBOL r070c N

#lp r070_82

&$env:COBOL r070a 83 Y Y

&$env:COBOL r070b

&$env:COBOL r070c N

#lp r070_83

&$env:COBOL r070a 84 Y Y

&$env:COBOL r070b

&$env:COBOL r070c N

#lp r070_84

&$env:COBOL r070a 86 Y Y

&$env:COBOL r070b

&$env:COBOL r070c N

#lp r070_86

&$env:COBOL r070a 87 Y Y

&$env:COBOL r070b

&$env:COBOL r070c N

#lp r070_87

&$env:COBOL r070a 88 Y Y

&$env:COBOL r070b

&$env:COBOL r070c N

#lp r070_88

&$env:COBOL r070a 89 Y Y

&$env:COBOL r070b

&$env:COBOL r070c N

#lp r070_89

&$env:COBOL r070a 91 Y Y

&$env:COBOL r070b

&$env:COBOL r070c N

#lp r070_91


&$env:COBOL r070a 92 Y Y

&$env:COBOL r070b

&$env:COBOL r070c N

#lp r070_92


&$env:COBOL r070a 93 Y Y

&$env:COBOL r070b

&$env:COBOL r070c N

#lp r070_93


&$env:COBOL r070a 94 Y Y

&$env:COBOL r070b

&$env:COBOL r070c N

#lp r070_94


&$env:COBOL r070a 95 Y Y

&$env:COBOL r070b

&$env:COBOL r070c N

#lp r070_95


&$env:COBOL r070a 96 Y Y

&$env:COBOL r070b

&$env:COBOL r070c N

#lp r070_96

&$env:COBOL r070a 98 Y Y

&$env:COBOL r070b

&$env:COBOL r070c N

#lp r070_98

&$env:QUIZ r070atp
&$env:QUIZ r070btp
&$env:QUIZ r070ctp
&$env:QUIZ r070dtp

Get-Content r070dtp.txt | Add-Content r070ctp.txt
Move-Item -Force r070ctp.txt r070tp_60
#lp r070tp_60

&$env:QUIZ r070atp_70
&$env:QUIZ r070btp_70
&$env:QUIZ r070ctp_70
&$env:QUIZ r070dtp_70

Get-Content r070dtp_70.txt | Add-Content r070ctp_70.txt
Move-Item -Force r070ctp_70.txt r070tp_70
#lp r070tp_70
