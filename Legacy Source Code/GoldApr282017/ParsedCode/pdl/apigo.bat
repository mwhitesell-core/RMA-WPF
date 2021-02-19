del apigo.log
del *.api
del metric.dat
del metric.det
del auxiliary.txt
del ..\db.dat

path=C:\CoreProjects\parser\bin;%path%

pdl rmaMp rmabill.pre rmabill.api /cc=RMA >> apigo.log
