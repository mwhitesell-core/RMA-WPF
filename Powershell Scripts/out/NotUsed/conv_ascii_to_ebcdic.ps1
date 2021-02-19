#-------------------------------------------------------------------------------
# File 'conv_ascii_to_ebcdic.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'conv_ascii_to_ebcdic'
#-------------------------------------------------------------------------------

# Copied from the man(ual) page on dd:
#
#       The ASCII/EBCDIC conversion tables are taken from the 256-character
#       standard in the CACM Nov, 1968.  These do not always correspond to
#       certain IBM  print train conventions.  There is no universal
#       solution.
#
#       New-lines are inserted only on conversion to ASCII; padding is done
#       only on conversion to EBCDIC.  These should be separate options.

# dd if=eft_tape of=eft_tape.ascii conv=ebcdic ibs=1464 
# CONVERSION ERROR (expected, #12): EBCDIC.
# dd if=eft_tape of=eft_tape.ascii conv=ebcdic
