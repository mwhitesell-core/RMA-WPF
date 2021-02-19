Q S H O W   (7.33.E)
Copyright 1996 COGNOS INCORPORATED

> show rec f020-doctor-extra
######            Regional Medical Associates - Hamilton          Page    1
                         R E C O R D   R E P O R T
          For DICTIONARY:  /alpha/rmabill/rmabillmp/obj/dict.pdc
    Record:             F020-DOCTOR-EXTRA
    of File:            F020-DOCTOR-EXTRA
    Organization:       INDEXED
    Type:               CISAM
    Open:               $pb_data/f020_doctor_extra
    Record Size:        261 Bytes

-- Record Contents --
    Item                                 Type            Size  Occ  Offset
    DOC-NBR                              CHARACTER          3            0
    DOC-YRLY-REQUIRE-REVENUE             INTEGER SIGNED     4            3
    DOC-YRLY-TARGET-REVENUE              INTEGER SIGNED     4            7
    DOC-CEIREQ                           INTEGER SIGNED     4           11
    DOC-YTDREQ                           INTEGER SIGNED     4           15
    DOC-CEITAR                           INTEGER SIGNED     4           19
    DOC-YTDTAR                           INTEGER SIGNED     4           23
    CEIREQ-PRT-FORMAT                    CHARACTER         13           27
    YTDREQ-PRT-FORMAT                    CHARACTER         13           40
    CEITAR-PRT-FORMAT                    CHARACTER         13           53
    YTDTAR-PRT-FORMAT                    CHARACTER         13           66
######            Regional Medical Associates - Hamilton          Page    2
                         R E C O R D   R E P O R T
          For DICTIONARY:  /alpha/rmabill/rmabillmp/obj/dict.pdc
    Item                                 Type            Size  Occ  Offset
    BILLING-VIA-PAPER-FLAG               CHARACTER          1           79
    BILLING-VIA-DISKETTE-FLAG            CHARACTER          1           80
    BILLING-VIA-WEB-TEST-FLAG            CHARACTER          1           81
    BILLING-VIA-WEB-LIVE-FLAG            CHARACTER          1           82
    BILLING-VIA-RMA-DATA-ENTRY           CHARACTER          1           83
    DATE-START-RMA-DATA-ENTRY            ZONED UNSIGNED     8           84
    DATE-START-DISKETTE                  ZONED UNSIGNED     8           92
    DATE-START-PAPER                     ZONED UNSIGNED     8          100
    DATE-START-WEB-LIVE                  ZONED UNSIGNED     8          108
    DATE-START-WEB-TEST                  ZONED UNSIGNED     8          116
    LEAVE-DESCRIPTION                    CHARACTER         30          124
    LEAVE-DATE-START                     ZONED UNSIGNED     8          154
    LEAVE-DATE-END                       ZONED UNSIGNED     8          162
    WEB-USER-REVENUE-ONLY-FLAG           CHARACTER          1          170
    MANAGER-FLAG                         CHARACTER          1          171
    CHAIR-FLAG                           CHARACTER          1          172
    ABE-USER-FLAG                        CHARACTER          1          173
    CPSO-NBR                             CHARACTER          5          174
    CMPA-NBR                             CHARACTER          8          179
######            Regional Medical Associates - Hamilton          Page    3
                         R E C O R D   R E P O R T
          For DICTIONARY:  /alpha/rmabill/rmabillmp/obj/dict.pdc
    Item                                 Type            Size  Occ  Offset
    OMA-NBR                              CHARACTER          9          187
    CFPC-NBR                             CHARACTER          6          196
    RCPSC-NBR                            CHARACTER          6          202
    DOC-MED-PROF-CORP                    CHARACTER          1          208
    MCMASTER-EMPLOYEE-ID                 ZONED UNSIGNED     7          209
    DOC-SPEC-CD-EFF-DATE                 ZONED UNSIGNED     8          216
    DOC-SPEC-CD-2-EFF-DATE               ZONED UNSIGNED     8          224
    DOC-SPEC-CD-3-EFF-DATE               ZONED UNSIGNED     8          232
    DOC-CLINIC-NBR-STATUS                CHARACTER          1          240
    DOC-CLINIC-NBR-2-STATUS              CHARACTER          1          241
    DOC-CLINIC-NBR-3-STATUS              CHARACTER          1          242
    DOC-CLINIC-NBR-4-STATUS              CHARACTER          1          243
    DOC-CLINIC-NBR-5-STATUS              CHARACTER          1          244
    DOC-CLINIC-NBR-6-STATUS              CHARACTER          1          245
    FILLER-BRAD1                         CHARACTER         15          246




######            Regional Medical Associates - Hamilton          Page    4
                         R E C O R D   R E P O R T
          For DICTIONARY:  /alpha/rmabill/rmabillmp/obj/dict.pdc

-- Index Contents --

 ** DOC-NBR is a 3 byte   UNIQUE PRIMARY  index **


    Segment                              Type            Size  Ord  Offset
    DOC-NBR                              CHARACTER          3    A       0













> show rec f028-contacts-info-mstr
######            Regional Medical Associates - Hamilton          Page    1
                         R E C O R D   R E P O R T
          For DICTIONARY:  /alpha/rmabill/rmabillmp/obj/dict.pdc
    Record:             F028-CONTACTS-INFO-MSTR
    of File:            F028-CONTACTS-INFO-MSTR
    Organization:       INDEXED
    Type:               CISAM
    Open:               $pb_data/f028_contacts_info_mstr
    Record Size:        178 Bytes

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
    CONTACTS-EMAIL-ADDR                  CHARACTER         30          102
    CONTACTS-PHONE-NBR                   ZONED UNSIGNED    10          132
    CONTACTS-PHONE-EXT                   ZONED UNSIGNED     5          142
######            Regional Medical Associates - Hamilton          Page    2
                         R E C O R D   R E P O R T
          For DICTIONARY:  /alpha/rmabill/rmabillmp/obj/dict.pdc
    Item                                 Type            Size  Occ  Offset
    CONTACTS-PAGER-NBR                   ZONED UNSIGNED    10          147
    CONTACTS-CELL-NBR                    ZONED UNSIGNED    10          157
    CONTACTS-FAX-NBR                     ZONED UNSIGNED    10          167
    NEWSLETTER-FLAG                      CHARACTER          1          177

-- Index Contents --

 ** CONTACTS-INFO-KEY is a 6 byte   UNIQUE PRIMARY  index **


    Segment                              Type            Size  Ord  Offset
    FILLER                               CHARACTER          1    A       0
    DOC-NBR                              CHARACTER          3    A       1
    CONTACTS-TYPE                        CHARACTER          1    A       4
    CONTACTS-LOCATION                    CHARACTER          1    A       5





> exit
