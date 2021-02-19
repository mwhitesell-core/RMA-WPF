ftp -v rmaprod << E_O_F
binary
hash
cd /dyad/rmabill101c/production
cd  98
lcd 98
mget *
E_O_F
