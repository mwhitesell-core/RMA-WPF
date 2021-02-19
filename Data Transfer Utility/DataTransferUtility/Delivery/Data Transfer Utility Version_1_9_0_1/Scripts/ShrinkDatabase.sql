use master
go
alter database [%DatabaseName%] set recovery simple with no_wait
go
use [%DatabaseName%]
go
dbcc shrinkfile('%DatabaseName%_log', 1)
go
use master
go
alter database [%DatabaseName%] set recovery full with no_wait
go
