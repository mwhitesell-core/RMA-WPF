* status_cobol_pat_mstr.ws

    05  status-cobol-pat-mstr.
        10  status-cobol-pat-mstr1              pic x   value "0".
        10  status-cobol-pat-mstr2              pic x   value "0".
    05  status-cobol-pat-mstr-binary
                redefines status-cobol-pat-mstr pic 9(4) comp.
