> 
> build $pb_obj/del_doctor
0 ERRORS  0 WARNINGS.
The file /alpha/rmabill/rmabill101c/obj/del_doctor.qtc already exists. Ok to delete?y
> 
> 
> go

Executing request DELETE_DOCTOR ...

Enter doctor nbr: 00E
Enter doctor nbr: 00E
Enter doctor nbr: 

Enter Doctor Termination Date cutoff : (yyyymmdd) 20130308
-------------------------------------------------------------------------------
The permanent subfile will be overwritten.
   File:  delf020_doc
-------------------------------------------------------------------------------
Data access error.                                                         [2] 
   File:  F020-DOCTOR-MSTR
     Linkitem:  DOC-NBR                          00E
     Linkitem:  DOC-OHIP-NBR                      26458
     Linkitem:  DOC-NAME-SOUNDEX                 R525

Action Taken: Report and Continue.
-------------------------------------------------------------------------------
Record not found (ISAM 111)
   File:  F020-DOCTOR-MSTR
     Linkitem:  DOC-NBR                          00E
     Linkitem:  DOC-OHIP-NBR                      26458
     Linkitem:  DOC-NAME-SOUNDEX                 R525
-------------------------------------------------------------------------------

Records read:
  F020-DOCTOR-MSTR                         2

Transactions processed:                    2

Records processed:                     Added    Updated  Unchanged    Deleted
  F020-DOCTOR-MSTR                         0          0          0          1
  SAVEF020                                 2          0          0          0
  DELF020_DOC                              2          0          0          0


Executing request DELETE_DOCTOR_EXTRA ...
-------------------------------------------------------------------------------
Data access error.                                                         [2] 
   File:  F020-DOCTOR-EXTRA
     Linkitem:  DOC-NBR                          00E

Action Taken: Report and Continue.
-------------------------------------------------------------------------------
Record not found (ISAM 111)
   File:  F020-DOCTOR-EXTRA
     Linkitem:  DOC-NBR                          00E
-------------------------------------------------------------------------------

Records read:
  DELF020_DOC                              2
  F020-DOCTOR-EXTRA                        1

Transactions processed:                    2

Records processed:                     Added    Updated  Unchanged    Deleted
  F020-DOCTOR-EXTRA                        0          0          0          1
  SAVEF020EXTRA                            2          0          0          0


Executing request DELETE_F027 ...
-------------------------------------------------------------------------------
Data access error.                                                         [4] 
   File:  F027-CONTACTS-MSTR
     Linkitem:  FILLER
     Linkitem:  DOC-NBR                          00E
     Linkitem:  CONTACTS-TYPE                    D

Action Taken: Report and Continue.
-------------------------------------------------------------------------------
Record not found (ISAM 111)
   File:  F027-CONTACTS-MSTR
     Linkitem:  FILLER
     Linkitem:  DOC-NBR                          00E
     Linkitem:  CONTACTS-TYPE                    D
-------------------------------------------------------------------------------
Data access error.                                                         [5] 
   File:  F027-CONTACTS-MSTR
     Linkitem:  FILLER
     Linkitem:  DOC-NBR                          00E
     Linkitem:  CONTACTS-TYPE                    O

Action Taken: Report and Continue.
-------------------------------------------------------------------------------
Record not found (ISAM 111)
   File:  F027-CONTACTS-MSTR
     Linkitem:  FILLER
     Linkitem:  DOC-NBR                          00E
     Linkitem:  CONTACTS-TYPE                    O
-------------------------------------------------------------------------------
Data access error.                                                         [6] 
   File:  F027-CONTACTS-MSTR
     Linkitem:  FILLER
     Linkitem:  DOC-NBR                          00E
     Linkitem:  CONTACTS-TYPE                    S

Action Taken: Report and Continue.
-------------------------------------------------------------------------------
Record not found (ISAM 111)
   File:  F027-CONTACTS-MSTR
     Linkitem:  FILLER
     Linkitem:  DOC-NBR                          00E
     Linkitem:  CONTACTS-TYPE                    S
-------------------------------------------------------------------------------

Records read:
  DELF020_DOC                              2
  F027-CONTACTS-MSTR                       6

Transactions processed:                    6

Records processed:                     Added    Updated  Unchanged    Deleted
  F027-CONTACTS-MSTR                       0          0          0          3
  SAVEF027                                 6          0          0          0


Executing request DELETE_F028 ...
-------------------------------------------------------------------------------
Data access error.                                                         [7] 
   File:  F028-CONTACTS-INFO-MSTR
     Linkitem:  FILLER
     Linkitem:  DOC-NBR                          00E
     Linkitem:  CONTACTS-TYPE                    D
     Linkitem:  CONTACTS-LOCATION                H

Action Taken: Report and Continue.
-------------------------------------------------------------------------------
Record not found (ISAM 111)
   File:  F028-CONTACTS-INFO-MSTR
     Linkitem:  FILLER
     Linkitem:  DOC-NBR                          00E
     Linkitem:  CONTACTS-TYPE                    D
     Linkitem:  CONTACTS-LOCATION                H
-------------------------------------------------------------------------------
Data access error.                                                         [8] 
   File:  F028-CONTACTS-INFO-MSTR
     Linkitem:  FILLER
     Linkitem:  DOC-NBR                          00E
     Linkitem:  CONTACTS-TYPE                    D
     Linkitem:  CONTACTS-LOCATION                O

Action Taken: Report and Continue.
-------------------------------------------------------------------------------
Record not found (ISAM 111)
   File:  F028-CONTACTS-INFO-MSTR
     Linkitem:  FILLER
     Linkitem:  DOC-NBR                          00E
     Linkitem:  CONTACTS-TYPE                    D
     Linkitem:  CONTACTS-LOCATION                O
-------------------------------------------------------------------------------
Data access error.                                                         [9] 
   File:  F028-CONTACTS-INFO-MSTR
     Linkitem:  FILLER
     Linkitem:  DOC-NBR                          00E
     Linkitem:  CONTACTS-TYPE                    O
     Linkitem:  CONTACTS-LOCATION                H

Action Taken: Report and Continue.
-------------------------------------------------------------------------------
Record not found (ISAM 111)
   File:  F028-CONTACTS-INFO-MSTR
     Linkitem:  FILLER
     Linkitem:  DOC-NBR                          00E
     Linkitem:  CONTACTS-TYPE                    O
     Linkitem:  CONTACTS-LOCATION                H
-------------------------------------------------------------------------------
Data access error.                                                        [10] 
   File:  F028-CONTACTS-INFO-MSTR
     Linkitem:  FILLER
     Linkitem:  DOC-NBR                          00E
     Linkitem:  CONTACTS-TYPE                    O
     Linkitem:  CONTACTS-LOCATION                O

Action Taken: Report and Continue.
-------------------------------------------------------------------------------
Record not found (ISAM 111)
   File:  F028-CONTACTS-INFO-MSTR
     Linkitem:  FILLER
     Linkitem:  DOC-NBR                          00E
     Linkitem:  CONTACTS-TYPE                    O
     Linkitem:  CONTACTS-LOCATION                O
-------------------------------------------------------------------------------
Data access error.                                                        [11] 
   File:  F028-CONTACTS-INFO-MSTR
     Linkitem:  FILLER
     Linkitem:  DOC-NBR                          00E
     Linkitem:  CONTACTS-TYPE                    S
     Linkitem:  CONTACTS-LOCATION                H

Action Taken: Report and Continue.
-------------------------------------------------------------------------------
Record not found (ISAM 111)
   File:  F028-CONTACTS-INFO-MSTR
     Linkitem:  FILLER
     Linkitem:  DOC-NBR                          00E
     Linkitem:  CONTACTS-TYPE                    S
     Linkitem:  CONTACTS-LOCATION                H
-------------------------------------------------------------------------------
Data access error.                                                        [12] 
   File:  F028-CONTACTS-INFO-MSTR
     Linkitem:  FILLER
     Linkitem:  DOC-NBR                          00E
     Linkitem:  CONTACTS-TYPE                    S
     Linkitem:  CONTACTS-LOCATION                O

Action Taken: Report and Continue.
-------------------------------------------------------------------------------
Record not found (ISAM 111)
   File:  F028-CONTACTS-INFO-MSTR
     Linkitem:  FILLER
     Linkitem:  DOC-NBR                          00E
     Linkitem:  CONTACTS-TYPE                    S
     Linkitem:  CONTACTS-LOCATION                O
-------------------------------------------------------------------------------

Records read:
  DELF020_DOC                              2
  F028-CONTACTS-INFO-MSTR                 12

Transactions processed:                   12

Records processed:                     Added    Updated  Unchanged    Deleted
  F028-CONTACTS-INFO-MSTR                  0          0          0          6
  SAVEF028                                12          0          0          0

Finished.
