01  FILE-STATUS.
                 02  STAT1 PIC X.
                 02  STAT2 PIC X.
           01  BINARY-STATUS REDEFINES FILE-STATUS PIC 9(4) COMP.
           01  DISPLAY-STATUS.
                 02  STAT1-DISPLAY  PIC X.
                 02  FILLER         PIC X(3).
                 02  STAT2-DISPLAY  PIC 9(4).     
  DECLARATIVES.
           FILE-ERR SECTION.
                USE AFTER STANDARD ERROR PROCEDURE ON FILENAME.
           FILE-ERROR.
                MOVE STAT1 TO STAT1-DISPLAY.
                IF STAT1 NOT = 9
                      MOVE STAT2 TO STAT2-DISPLAY
                                  GO TO END-STAT.
          * 9 means it is a RTS error - look in RTS err msg manual
                      IF STAT1 = 9
                              MOVE LOW-VALUES TO STAT1.
                      MOVE BINARY-STATUS TO STAT2-DISPLAY.
                GO TO END-STAT.
           END-STAT.
                   DISPLAY "File status is ", DISPLAY-STATUS.
                   STOP RUN.
           END DECLARATIVES.               

    copy "y2k_default_sysdate_century.rtn".
