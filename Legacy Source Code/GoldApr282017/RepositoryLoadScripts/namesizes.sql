ALTER TABLE 
   DBDatabase 
MODIFY 
   ( 
   Database_Name varchar2(50),
   Alternate_Database_Name varchar2(50)
   )
;

ALTER TABLE 
   DBRelation
MODIFY 
   ( 
   Relation_Name varchar2(50),
   Alternate_Relation_Name varchar2(50)
   )
;

ALTER TABLE 
   DBElement
MODIFY 
   ( 
   Element_Name varchar2(50),
   Alternate_Element_Name varchar2(50)
   )
;