Q S H O W   (7.33.E)
Copyright 1996 COGNOS INCORPORATED

> show rec f020-doctor-extra
######            Regional Medical Associates - Hamilton          Page    1
                         R E C O R D   R E P O R T
         For DICTIONARY:  /alpha/rmabill/rmabill101c/obj/dict.pdc
    Record:             F020-DOCTOR-EXTRA
    of File:            F020-DOCTOR-EXTRA
    Organization:       INDEXED
    Type:               CISAM
    Open:               $pb_data/f020_doctor_extra
    Record Size:        331 Bytes

-- Record Contents --
    Item                                 Type            Size  Occ  Offset
    DOC-NBR                              CHARACTER          3            0
    DOC-YRLY-REQUIRE-REVENUE             ZONED NUMERIC      9            3
    DOC-YRLY-TARGET-REVENUE              ZONED NUMERIC      9           12
    DOC-CEIREQ                           ZONED NUMERIC      9           21
    DOC-YTDREQ                           ZONED NUMERIC      9           30
    DOC-CEITAR                           ZONED NUMERIC      9           39
    DOC-YTDTAR                           ZONED NUMERIC      9           48
    CEIREQ-PRT-FORMAT                    CHARACTER         13           57
    YTDREQ-PRT-FORMAT                    CHARACTER         13           70
    CEITAR-PRT-FORMAT                    CHARACTER         13           83
    YTDTAR-PRT-FORMAT                    CHARACTER         13           96
######            Regional Medical Associates - Hamilton          Page    2
                         R E C O R D   R E P O R T
         For DICTIONARY:  /alpha/rmabill/rmabill101c/obj/dict.pdc
    Item                                 Type            Size  Occ  Offset
    BILLING-VIA-PAPER-FLAG               CHARACTER          1          109
    BILLING-VIA-DISKETTE-FLAG            CHARACTER          1          110
    BILLING-VIA-WEB-TEST-FLAG            CHARACTER          1          111
    BILLING-VIA-WEB-LIVE-FLAG            CHARACTER          1          112
    BILLING-VIA-RMA-DATA-ENTRY           CHARACTER          1          113
    DATE-START-RMA-DATA-ENTRY            ZONED UNSIGNED     8          114
    DATE-START-DISKETTE                  ZONED UNSIGNED     8          122
    DATE-START-PAPER                     ZONED UNSIGNED     8          130
    DATE-START-WEB-LIVE                  ZONED UNSIGNED     8          138
    DATE-START-WEB-TEST                  ZONED UNSIGNED     8          146
    LEAVE-DESCRIPTION                    CHARACTER         30          154
    LEAVE-DATE-START                     ZONED UNSIGNED     8          184
    LEAVE-DATE-END                       ZONED UNSIGNED     8          192
    WEB-USER-REVENUE-ONLY-FLAG           CHARACTER          1          200
    MANAGER-FLAG                         CHARACTER          1          201
    CHAIR-FLAG                           CHARACTER          1          202
    ABE-USER-FLAG                        CHARACTER          1          203
    CPSO-NBR                             CHARACTER          6          204
    CMPA-NBR                             CHARACTER          9          210
######            Regional Medical Associates - Hamilton          Page    3
                         R E C O R D   R E P O R T
         For DICTIONARY:  /alpha/rmabill/rmabill101c/obj/dict.pdc
    Item                                 Type            Size  Occ  Offset
    OMA-NBR                              CHARACTER         10          219
    CFPC-NBR                             CHARACTER          7          229
    RCPSC-NBR                            CHARACTER          7          236
    DOC-MED-PROF-CORP                    CHARACTER          1          243
    MCMASTER-EMPLOYEE-ID                 ZONED UNSIGNED     7          244
    DOC-SPEC-CD-EFF-DATE                 ZONED UNSIGNED     8          251
    DOC-SPEC-CD-2-EFF-DATE               ZONED UNSIGNED     8          259
    DOC-SPEC-CD-3-EFF-DATE               ZONED UNSIGNED     8          267
    DOC-CLINIC-NBR-STATUS                CHARACTER          1          275
    DOC-CLINIC-NBR-2-STATUS              CHARACTER          1          276
    DOC-CLINIC-NBR-3-STATUS              CHARACTER          1          277
    DOC-CLINIC-NBR-4-STATUS              CHARACTER          1          278
    DOC-CLINIC-NBR-5-STATUS              CHARACTER          1          279
    DOC-CLINIC-NBR-6-STATUS              CHARACTER          1          280
    FACTOR-GST-INCOME-REG                ZONED UNSIGNED     5          281
    FACTOR-GST-INCOME-MISC               ZONED UNSIGNED     5          286
    YELLOW-PAGES-FLAG                    CHARACTER          1          291
    REPLACED-BY-DOC-NBR                  CHARACTER          3          292
    PRIOR-DOC-NBR                        CHARACTER          3          295
######            Regional Medical Associates - Hamilton          Page    4
                         R E C O R D   R E P O R T
         For DICTIONARY:  /alpha/rmabill/rmabill101c/obj/dict.pdc
    Item                                 Type            Size  Occ  Offset
    COP-NBR                              CHARACTER          8          298
    DOC-FLAG-PRIMARY                     CHARACTER          1          306
    HAS-VALID-CURRENT-PAYROLL-RECORD     CHARACTER          1          307
    PAY-THIS-DOCTOR-OHIP-PREMIUM         CHARACTER          1          308
    DOC-FISCAL-YR-START-MONTH            ZONED UNSIGNED     2          309
    FILLER                               CHARACTER         20          311

-- Index Contents --

 ** DOC-NBR is a 3 byte   UNIQUE PRIMARY  index **


    Segment                              Type            Size  Ord  Offset
    DOC-NBR                              CHARACTER          3    A       0






> show rec f028-contacts-info-mstr
######            Regional Medical Associates - Hamilton          Page    1
                         R E C O R D   R E P O R T
         For DICTIONARY:  /alpha/rmabill/rmabill101c/obj/dict.pdc
    Record:             F028-CONTACTS-INFO-MSTR
    of File:            F028-CONTACTS-INFO-MSTR
    Organization:       INDEXED
    Type:               CISAM
    Open:               $pb_data/f028_contacts_info_mstr
    Record Size:        198 Bytes

-- Record Contents --
    Item                                 Type            Size  Occ  Offset
    FILLER                               CHARACTER          1            0
    DOC-NBR                              CHARACTER          3            1
    CONTACTS-TYPE                        CHARACTER          1            4
    CONTACTS-LOCATION                    CHARACTER          1            5
    CONTACTS-ADDR-1                      CHARACTER         30            6
    CONTACTS-ADDR-2                      CHARACTER         30           36
    CONTACTS-ADDR-3                      CHARACTER         30           66
    POSTAL-CODE                          CHARACTER          6           96
    CONTACTS-EMAIL-ADDR                  CHARACTER         50          102
    CONTACTS-PHONE-NBR                   ZONED UNSIGNED    10          152
    CONTACTS-PHONE-EXT                   ZONED UNSIGNED     5          162
######            Regional Medical Associates - Hamilton          Page    2
                         R E C O R D   R E P O R T
         For DICTIONARY:  /alpha/rmabill/rmabill101c/obj/dict.pdc
    Item                                 Type            Size  Occ  Offset
    CONTACTS-PAGER-NBR                   ZONED UNSIGNED    10          167
    CONTACTS-CELL-NBR                    ZONED UNSIGNED    10          177
    CONTACTS-FAX-NBR                     ZONED UNSIGNED    10          187
    NEWSLETTER-FLAG                      CHARACTER          1          197

-- Index Contents --

 ** CONTACTS-INFO-KEY is a 6 byte   UNIQUE PRIMARY  index **


    Segment                              Type            Size  Ord  Offset
    FILLER                               CHARACTER          1    A       0
    DOC-NBR                              CHARACTER          3    A       1
    CONTACTS-TYPE                        CHARACTER          1    A       4
    CONTACTS-LOCATION                    CHARACTER          1    A       5





> exit
