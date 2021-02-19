#  91/12/12 M. CHAN     - ADD R030I1 AND R030I2 PASSES
#  93/11/02 YASEMIN       - TAKE OUT R030E3 PASSE
#  94/02/02 M. CHAN      - ADD R030J
#  05/12/06 M. CHAN	 - Yas/Lori requested not to print detail in ru030c.txt
#  16/12/14 MC1		 - Yas/Lori requested not to run r030i1/2 for ru030f.txt
#  18/01/17 Core     - replaces r030.qzu

$rcmd = $env:QUIZ + "r030d1"
invoke-expression $rcmd

$rcmd = $env:QUIZ + "r030d2"
invoke-expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r030d1.txt > ru030a.txt
Get-Content r030d2.txt >> ru030a.txt

$rcmd = $env:QUIZ + "r030e1"
invoke-expression $rcmd

$rcmd = $env:QUIZ + "r030e2"
invoke-expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r030e1.txt > ru030b.txt
Get-Content r030e2.txt >> ru030b.txt

$rcmd = $env:QUIZ + "r030f1_summary"
invoke-expression $rcmd

$rcmd = $env:QUIZ + "r030f2"
invoke-expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r030f1_summary.txt > ru030c.txt
Get-Content r030f2.txt >> ru030c.txt

$rcmd = $env:QUIZ + "r030h"
invoke-expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r030h.txt > ru030d.txt

$rcmd = $env:QUIZ + "r030j"
invoke-expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r030j.txt > ru030e.txt

