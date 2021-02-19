program-id.
account.

data division.
working-storage section.
78 account-name-len	value 80.
01 account-name	pic x(account-name-len).
01 total	pic 9(9) value zero.
01 result	pic $$$,$$$,$$9.

linkage section.
01 strlen		pic x(4) comp-5.
01 newname		pic x(80).
01 next-item		pic x(4) comp-5.

procedure division.
display spaces upon crt.
exit program.


entry "validate" using strlen newname.
if strlen > account-name-len
display "account name exceeds ", account-name-len,
"characters."
move 1 to return-code
else
move newname(1:strlen) to account-name.
exit program.

entry "tally" using next-item.
	    add next-item to total
		on size error
		    display "numeric overflow"
		    move 2 to return-code.
	    exit program.

entry "showaccount".
	    display spaces upon crt.
	    display account-name.
	    move total to result.
	    display result.
	    exit program.
