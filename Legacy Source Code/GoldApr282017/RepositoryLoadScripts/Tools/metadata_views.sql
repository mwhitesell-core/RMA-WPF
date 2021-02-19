Spool E:\core\Install_logs\Metadata_Views;
/*
*/

/*
	PROCEDURE: Update_DBRelation_Elements

	The following procedure is used to update DBRelation_Element with the proper
	occurrence for Item_Occurs based on the parent's Item_Occurs value.
*/
CREATE OR REPLACE PROCEDURE Update_DBRelation_Elements AS

v_Database_Id           DBStructure_View.Database_Id%TYPE;
v_Relation_Id           DBStructure_View.Relation_Id%TYPE;
v_Element_Id            DBStructure_View.Element_Id%TYPE;
v_Element_Occurs        DBStructure_View.Element_Occurs%TYPE;
v_Count					Integer Default 0;

-- The SELECT statement below uses DBStructure_View.  Since it's not compiled yet,
-- we need to use the same code as the view (with the exception of using DBRelation_Element
-- instead of DBRelation_Element_View as it has not yet been compiled).
-- If DBStructure_View is changed, the appropriate changes may be required here.
CURSOR C_DBStructure Is
 SELECT Database_Id, Relation_Id, Structure_Id, Element_Occurs
 FROM   (SELECT  a.Database_Id,
        a.Relation_Id,
        a.Element_Id,
		a.structure_id,
        b.Item_occurs Element_Occurs
  FROM  DBStructure      a,
        DBRelation_Element        b,
        DBRelation_Element        c
 WHERE  a.Database_Id = b.Database_Id
   AND  a.Relation_Id = b.Relation_Id
   AND  a.Element_Id  = b.element_Id
   AND  a.Database_id = c.Database_id
   AND  a.Relation_Id = c.Relation_Id
   AND  a.Structure_Id  = c.element_Id
   AND  c.Item_Occurs = 0)
 WHERE  Element_Occurs > 0
 ORDER BY Database_Id, Relation_Id, Structure_Id;

BEGIN

LOOP
	BEGIN
		-- Get the parent elements that occur and update the children.
		OPEN C_DBStructure;
		LOOP
		    FETCH C_DBStructure INTO v_Database_Id, v_Relation_Id, v_Element_Id, v_Element_Occurs;

		    EXIT WHEN C_DBStructure%NOTFOUND;

			DBMS_OUTPUT.Put_Line(v_Database_Id || ' ' || v_Relation_Id || ' ' || v_Element_Id || ' ' || v_Element_Occurs);
		    UPDATE DBRelation_Element
			SET   Item_Occurs = v_Element_Occurs
		        WHERE Database_Id = v_Database_Id
    	   		AND   Relation_Id = v_Relation_Id
	    	    AND   Element_Id  = v_Element_Id;
		END LOOP;
		CLOSE C_DBStructure;
	
		-- Check if we need to re-run for children that are also parents.
		 SELECT Count(*) INTO v_Count
		 FROM   (SELECT  a.Database_Id,
    		    a.Relation_Id,
        		a.Element_Id,
				a.structure_id,
		        b.Item_occurs Element_Occurs
		  FROM  DBStructure      a,
		        DBRelation_Element        b,
		        DBRelation_Element        c
		 WHERE  a.Database_Id = b.Database_Id
		   AND  a.Relation_Id = b.Relation_Id
		   AND  a.Element_Id  = b.element_Id
		   AND  a.Database_id = c.Database_id
		   AND  a.Relation_Id = c.Relation_Id
		   AND  a.Structure_Id  = c.element_Id
		   AND  c.Item_Occurs = 0)
		 WHERE  Element_Occurs > 0;
	 
	 	IF (v_Count = 0)
		 THEN
		 	EXIT;
		 END IF;
	 END; 
	 
END LOOP;

END Update_DBRelation_Elements;
/
exec Update_DBRelation_Elements;
/*
	END PROCEDURE: Update_DBRelation_Elements
*/

Prompt CREATE VIEW DBRELATION_ELEMENT_VIEW_BASE
CREATE OR REPLACE VIEW DBRELATION_ELEMENT_VIEW_BASE ( SOURCE_MODULE_ID,
DATABASE_ID, RELATION_ID, ELEMENT_ID, SEQUENCE_NUMBER,
METHOD_ID, OBJECT_ID, ITEM_OCCURS, PARENT_FLAG, Signed_Flag,
ITEM_REDEFINES_ELEMENT_ID, ALIASED_ELEMENT_ID, DATABASE_NAME, ALTERNATE_DATABASE_NAME,
RELATION_NAME, ALTERNATE_RELATION_NAME, RELATION_TYPE_CODE, ORGANIZATION_TYPE_CODE, Create_Flag,
ELEMENT_NAME, ALTERNATE_ELEMENT_NAME, ELEMENT_SIZE, ELEMENT_TYPE_CODE,
ITEM_DATATYPE_CODE, ITEM_SIZE, DECIMAL_POSITION, PICTURE, ENGLISH_LABEL, DATE_FORMAT_CODE,
SEPARATOR, TRAILING_SIGN, LEADING_SIGN, Aliased_Element_Name,Aliased_Alt_Element_Name, DOMAIN_ID, OUTPUT_SCALE, DOMAIN_LABEL_VALUE, 
DOMAIN_NAME, Alternate_Domain_Name, Domain_Picture_Value, Domain_type_code, TEMPLATE_NAME ) 
AS SELECT  
		a.Source_Module_Id,
        a.Database_Id,
        a.Relation_Id,
        a.Element_Id,
        A.Sequence_number,
        a.Method_id,
        a.Object_id,
        Decode(a.Item_Occurs, 0, Decode(d.Occurs, 0, Decode(e.Occurs, 0, f.Occurs, e.Occurs), d.Occurs), a.Item_Occurs) Item_Occurs,
        a.Parent_Flag,
        a.signed_flag,
        a.Item_Redefines_Element_Id,
        a.Aliased_Element_Id,
        b.Database_Name,
        b.Alternate_Database_Name,
        c.Relation_name,
        c.Alternate_Relation_name,
        c.Relation_Type_code,
        c.Organization_Type_Code,
        c.Create_flag,
        d.Element_Name,
        d.Alternate_Element_Name,
		--For MENTEC Project needs lines without decode to dbelement because of NonRelational database
        --Decode(a.Item_Size, 0,Decode(e.item_size, 0 , Decode(e.Domain_Size, 0,Decode(f.item_size, 0 ,f.Template_Size,f.item_size),e.Domain_Size),e.item_size), a.item_Size) Element_Size,
        --Decode(a.Datatype_Code, ' ', Decode(e.ITEM_DATATYPE_CODE,' ', Decode(e.Domain_TYPE_CODE, ' ',Decode(f.ITEM_DATATYPE_CODE, ' ' ,f.Template_TYPE_CODE,f.ITEM_DATATYPE_CODE),e.Domain_TYPE_CODE),e.ITEM_DATATYPE_CODE), a.Datatype_Code) Element_Type_Code,
        --Decode(a.Item_Size, 0,Decode(d.Item_Size, 0,Decode(d.Element_Size, 0, Decode(e.item_size, 0 , Decode(e.Domain_Size, 0,Decode(f.item_size, 0 ,f.Template_Size,f.item_size),e.Domain_Size),e.item_size), d.Element_Size),d.item_size), a.item_Size) Element_Size,
		Decode(d.Element_Size, 0, Decode(e.Domain_Size, 0, DECODE(f.Template_Size, Null, 0, f.Template_Size), Null, 0, e.Domain_Size), d.Element_Size) Element_Size,
	Decode(d.Element_Type_code, ' ', Decode(e.Domain_type_code, ' ', DECODE(f.Template_type_code, Null, ' ', f.Template_type_code), Null, '', e.Domain_type_code), d.Element_type_code) Element_type_code,
	-- Rolf 08/07/2007 Decode(f.Template_Type_Code, '', Decode(f.Template_Type_Code, ' ', Decode(e.Domain_Type_Code, '', Decode(e.Domain_Type_Code, ' ',Decode(d.ELEMENT_TYPE_CODE, ' ', a.DATATYPE_CODE, d.ELEMENT_TYPE_CODE), e.Domain_Type_Code), f.template_type_code), e.Domain_Type_Code), f.Template_Type_Code) Element_Type_Code,
        Decode(a.Datatype_Code, ' ',Decode(e.ITEM_DATATYPE_CODE, ' ', f.item_datatype_CODE, e.ITEM_DATATYPE_CODE), a.Datatype_Code) ITEM_DATATYPE_CODE,
        Decode(a.Item_Size,0 ,Decode(e.item_size,0, f.item_size, e.item_size), a.item_Size) Item_Size,
        Decode(d.Decimal_Position, 0, Decode(e.Decimal_Position, 0, f.Decimal_Position, e.Decimal_Position), d.Decimal_Position) Decimal_Position,
        Decode(d.Picture, ' ', Decode(e.Picture, ' ', f.Picture, e.Picture), d.Picture) Picture,
        Decode(d.English_label, ' ', Decode(e.English_label, ' ', f.English_label, e.English_label), d.English_label) English_label,
        Decode(d.Date_Format_Code, ' ', Decode(e.Date_Format_Code, ' ', f.Date_Format_Code, e.Date_Format_Code), d.Date_Format_Code) Date_Format_Code,
        Decode(d.Separator, ' ', Decode(e.Separator, ' ', f.Separator, e.Separator), d.Separator) Separator,
        d.Trailing_sign,
        d.Leading_Sign,
        g.Element_Name Aliased_Element_Name,
        g.Alternate_Element_Name Aliased_Alt_Element_Name,
		--GW2002: Added
        e.Domain_Id,
 		e.Output_Scale,
        core_label(d.english_label, e.english_label, f.english_label, d.element_name) Domain_Label_Value,
		e.Domain_Name,
		e.Alternate_Domain_Name,
   		e.Picture       Domain_Picture_Value,
		e.Domain_type_code,
 		f.template_name
  FROM  DBRelation_Element      a,
        DBDatabase              b,
        DBRelation              c,
        DBElement               d,
        DBDomain                e,
        DBTemplate              f,
        DBElement               g
 WHERE  a.database_id            = b.Database_id and
        a.relation_id          = c.Relation_id and
        a.Element_Id         = d.Element_Id and
        d.domain_id          = e.domain_id(+) and
        e.template_id         = f.template_id(+) and
        a.Aliased_element_id  = g.Element_Id(+)
ORDER BY
 		a.database_id, a.relation_id, a.sequence_number;

--------- DBRelation_Element_View -------------------
-- 
-- Changed name of DBRelation_Element_View to DBRelation_Element_View_Base
-- in order to avoid changing all the views, and applications by creating 
-- synonyms using the DBRelation_Element_View name which will point 
-- to the DBRelation_Element_Summary table.
--
-----------------------------------------------------
Prompt Creating Table DBRelation_Element_Summary

Drop Table DBRelation_Element_Summary;

Create Table DBRelation_Element_Summary
       PCTFREE 5
       PCTUSED 90
       TABLESPACE CORE_REPOSITORY
       STORAGE (
              INITIAL 12928 K
              NEXT 1408 K
              MINEXTENTS 1
              MAXEXTENTS Unlimited
       )
       NOLOGGING
 As
Select * from DBRelation_Element_View_Base;

-- Define indices for the newly created table

CREATE UNIQUE INDEX XPKDBRelation_Element_Summary ON DBRelation_Element_Summary
(
       Source_Module_Id                 ASC,
       Database_ID                      ASC,
       Relation_ID          			ASC,
       Element_ID                      	ASC
)
       PCTFREE 5
       TABLESPACE CORE_REPOSITORY
       STORAGE (
              INITIAL 1330 K
              NEXT 1330 K
              MINEXTENTS 1
              MAXEXTENTS Unlimited
       )
       NOLOGGING
;

CREATE UNIQUE INDEX XAK2DBRelation_Element_Summary ON DBRelation_Element_Summary
(
       Database_ID                      ASC,
       Relation_ID          			ASC,
       Element_ID                      	ASC
)
       PCTFREE 5
       TABLESPACE CORE_REPOSITORY
       STORAGE (
              INITIAL 1330 K
              NEXT 1330 K
              MINEXTENTS 1
              MAXEXTENTS Unlimited
       )
       NOLOGGING
;

DECLARE
  V_COUNT NUMBER(38);
BEGIN
  SELECT COUNT(*) INTO V_COUNT FROM ALL_SYNONYMS WHERE OWNER = 'PUBLIC' AND SYNONYM_NAME = 'DBRELATION_ELEMENT_VIEW';
  IF V_COUNT <> 0
  THEN
      EXECUTE IMMEDIATE 'DROP PUBLIC SYNONYM DBRELATION_ELEMENT_VIEW';
  END IF;
END;
/
CREATE PUBLIC SYNONYM DBRELATION_ELEMENT_VIEW FOR DBRELATION_ELEMENT_SUMMARY;
-- END OF DBRELATION_ELEMENT_SUMMARY

Prompt CREATE VIEW DBElement_Relation_View
CREATE OR REPLACE VIEW DBElement_Relation_View
AS
SELECT  a.Database_Id,
        a.Source_Module_Id,
        a.Element_Id,
        a.Relation_Id,
        a.Object_id,
        a.Method_id,
        b.Relation_Name,
        b.Alternate_Relation_Name
  FROM  DBRelation_Element      a,
        DBRelation              b
 WHERE  a.Database_Id = b.Database_Id
   AND  a.Relation_Id = b.Relation_Id;

Prompt CREATE VIEW DBIndex_Element_View
CREATE OR REPLACE VIEW DBIndex_Element_View
AS
SELECT  b.Database_Id,
        b.Source_Module_Id,
        b.Relation_Id,
        b.Index_Id,
        b.object_id,
        b.method_id,
        b.Sequence_number,
        b.Item_datatype_code,
        b.Sort_Type_Code,
        b.sort_flag,
        a.Element_Id,
        a.Element_Name,
        a.Alternate_Element_Name
  FROM  DBElement               a,
        DBIndex_Segment         b
 WHERE  a.database_id   = b.database_id and
        a.Element_Id    = b.Element_Id;

Prompt CREATE VIEW DBIndex_Table_View
CREATE OR REPLACE VIEW DBIndex_Table_View
AS
SELECT  a.Source_Module_Id,
        a.Database_Id,
        a.Relation_Id,
        a.Index_id,
        a.Object_id,
        a.Method_id,
        a.Alternate_Flag,
        a.Sort_Type_Code,
        a.Null_Value_Flag,
        a.Null_Value,
        a.Unique_Flag,
        a.Active_Flag,
        a.Ordered_Flag,
        a.Index_Name,
        a.Alternate_Index_Name,
        b.Database_Name,
        b.Alternate_Database_Name,
        c.Relation_name,
        c.Alternate_Relation_name
  FROM  DBIndex_Table           a,
        DBDatabase              b,
        DBRelation              c
 WHERE  a.database_id = b.Database_id  and
        a.database_id = c.database_id  and
        a.relation_id = c.Relation_id;


--
-- NOTE:
-- 	Object_Id from DBRelation
-- 	Method_Id from DBRelation
--
Prompt CREATE VIEW DBRelation_View
CREATE OR REPLACE VIEW DBRelation_View
AS
SELECT  a.Database_Id,
        a.Source_Module_Id,
        a.Element_Id,
        a.Relation_Id,
        b.Object_id,
        b.Method_id,
        b.Relation_Name,
        b.Alternate_Relation_Name,
        c.Database_Name,
        c.Alternate_Database_Name
  FROM  DBRelation_Element      a,
        DBRelation              b,
        DBDatabase              c
 WHERE  a.Database_Id = b.Database_Id
   AND  a.Relation_Id = b.Relation_Id
   AND  a.Database_id = c.Database_id;


Prompt CREATE VIEW DBCore_Xref_View
CREATE OR REPLACE VIEW DBCore_Xref_View AS
SELECT
	b.Reference_Group,
	b.Reference_Code,
	b.Target_Reference_Group,
	b.Target_Reference_Code,
        a.Full_English_Desc Source_Value,
        c.Full_English_Desc Target_Value,
        DECODE(a.Full_English_desc, ' ', a.Full_English_Desc, c.Full_English_desc) Return_value
FROM 	DBCore_Table      A,
	DBCore_XRef_Table B,
	DBCore_Table      C
WHERE 	A.Reference_Group         = B.Reference_Group(+) AND
	A.Reference_Code          = B.Reference_Code(+) AND
	B.Target_Reference_Group  = c.Reference_Group(+) AND
	B.Target_Reference_Code   = C.Reference_Code(+);

PROMPT DBSet_Option_View
CREATE OR REPLACE VIEW DBSet_Option_View AS
SELECT
	a.Set_Id,
	a.Set_Name,
	a.Set_Type_Code,
	a.Set_Option_Code,
	a.Stack_Id,
	b.Full_English_Desc Set_Type_Desc,
	b.Full_English_Desc Set_Option_Desc
  FROM
	DBSet_Option a,
	DBCore_Table b,
	DBCore_Table c
 WHERE
	a.Set_Type_Code = b.Reference_Code AND
	b.Reference_Group = '0069' AND
	a.Set_Option_Code = b.Reference_Code AND
	b.Reference_Group = '0070';

PROMPT DBTemplate_View
CREATE OR REPLACE VIEW DBTemplate_View AS
SELECT
	a.Dictionary_Id,
	a.Template_Id,
	a.Template_Name,
	a.Alternate_Template_Name,
	a.Template_Size,
	a.Template_Type_Code,
	a.English_Description,
	a.French_Description,
	b.Full_English_Desc
  FROM
	DBTemplate a,
	DBCore_Table b
 WHERE
	a.Template_Type_Code = b.Reference_Code AND
	b.Reference_Group = '0004';

PROMPT CREATE VIEW DBRelation_Fld_Procedure_View
CREATE OR REPLACE VIEW DBRelation_Fld_Procedure_View AS
SELECT
	a.Project_Id,
	a.Module_Id,
	a.Originating_Module_Id,
	a.Procedure_Id,
        a.RPRelation_ID,
        b.Database_ID,
	b.Relation_Id,
        b.Alias_Name,
        c.Relation_Name Base_Relation_Name,
	c.Source_Module_Id,
	DECODE (c.Alternate_Relation_Name, ' ', c.Relation_Name, c.Alternate_Relation_Name) Relation_Name,
	a.Element_Id,
	DECODE(d.Alternate_Element_Name, ' ', d.Element_Name, d.Alternate_Element_Name) Element_Name,
        d.element_name Base_Element_Name,
	d.Object_Id,
	d.Method_Id
 FROM
	RPProcedure a,
        RPRelation  b,
	DBRelation  c,
	DBElement   d
WHERE
        a.RPRelation_Id <> 0
  And   a.Element_Id    <> 0
  And	a.RPRelation_ID = b.RPRelation_ID
  And   b.Database_ID   = C.Database_ID
  And	b.Relation_Id   = c.Relation_Id
  And   b.Database_ID   = d.Database_ID
  And   a.Element_id    = d.Element_ID;

PROMPT DBDictionary_Database_View
CREATE OR REPLACE VIEW DBDictionary_Database_View AS
SELECT
	a.Dictionary_Id,
	d.Dictionary_Name,
	b.Database_Id,
	b.Database_Name,
	b.Alternate_Database_Name,
	b.Database_Type_Code,
	c.Full_English_Desc,
	b.Logical_Name,
	b.English_Description,
	b.French_Description,
	b.Server_Name,
	b.Owner
  FROM
	DBDictionary_Database a,
	DBDatabase b,
	DBCore_Table c,
	DBDictionary d
 WHERE
	a.Database_Id = b.Database_Id AND
	a.dictionary_Id = d.dictionary_Id AND
	b.Database_Type_Code(+) = c.Reference_Code AND
	c.Reference_Group = '0003';

PROMPT DBDictionary_DB_Role_View
CREATE OR REPLACE VIEW DBDictionary_DB_Role_View AS
SELECT
	a.Dictionary_Id,
	d.Dictionary_Name,
	b.Database_Id,
	b.Database_Name,
	b.Alternate_Database_Name,
	b.Database_Type_Code,
	c.Full_English_Desc Database_Type,
	e.role_id,
	e.role_Name,
	b.Owner
  FROM
	DBDictionary_Database a,
	DBDatabase b,
	DBCore_Table c,
	DBDictionary d,
	DBDatabase_Role e
 WHERE
	a.Database_Id = b.Database_Id AND
	a.dictionary_Id = d.dictionary_Id AND
	a.Database_Id = e.Database_Id AND
	b.Database_Type_Code(+) = c.Reference_Code AND
	c.Reference_Group = '0003';


Prompt CREATE VIEW DBSet_Option_View
CREATE OR REPLACE VIEW DBSet_Option_View AS
SELECT
	a.Dictionary_Id,
	a.Set_Id,
	a.Set_Name,
	a.Set_Type_Code,
	b.Full_English_Desc Set_Type_Desc,
	a.Set_Option_Code,
	c.Full_English_Desc Set_Option_Desc,
	a.Stack_Id,
	a.Set_Option_Flag
  FROM
	DBSet_Option a,
	DBCore_Table b,
	DBCore_Table c
 WHERE
	a.Set_Type_Code = b.Reference_Code AND
	b.Reference_Group = '0069' AND
	a.Set_Option_Code = c.Reference_Code AND
	c.Reference_Group = '0070';

PROMPT DBDomain_View
CREATE OR REPLACE VIEW DBDomain_View AS
SELECT
	a.Dictionary_Id,
	a.Domain_Id,
	a.Domain_Name,
	a.Alternate_Domain_Name,
	a.Domain_Size,
	a.Domain_Type_Code,
	a.English_Description,
	a.French_Description,
	b.Full_English_Desc
  FROM
	DBDomain a,
	DBCore_Table b
 WHERE
	a.Domain_Type_Code = b.Reference_Code AND
	b.Reference_Group = '0004';

PROMPT DBElement_View
CREATE OR REPLACE VIEW DBElement_View AS
SELECT
	a.Database_Id,
	a.Element_Id,
	a.Object_Id,
	a.Method_Id,
	a.Element_Name,
	a.Alternate_Element_Name,
	a.Dictionary_Id,
	a.Domain_Id,
	a.English_Description,
	a.French_Description,
	a.Element_Size,
	a.Element_Type_Code,
	a.BWZ_FLAG,
	a.DECIMAL_POSITION ,
	a.ENGLISH_HEADING,
	a.FILL,
        a.TRAILING_SIGN ,
	a.SIGNIFICANCE,
	a.FLOAT_VALUE,
	a.DATE_FORMAT_CODE,
	a.INITIAL_VALUE,
	a.INPUT_SCALE ,
	a.ITEM_DATATYPE_CODE,
	a.ITEM_SIZE,
	a.LEADING_SIGN ,
	a.OCCURS,
	a.OUTPUT_SCALE,
	a.PATTERN_VALUE,
	a.PICTURE,
	a.SHIFTINPUT_CODE,
	a.SEPARATOR,
	a.DATA_VALUES,
	b.Full_English_Desc
  FROM
	DBElement a,
	DBCore_Table b
 WHERE
	a.Element_Type_Code = b.Reference_Code AND
	b.Reference_Group = '0004';


PROMPT DBRelation_Decode_View
CREATE OR REPLACE VIEW DBRelation_Decode_View AS
SELECT
	a.Database_Id,
	a.Relation_Id,
	a.Source_Module_Id,
	a.Object_Id,
	a.Method_Id,
	a.Relation_Name,
	a.Alternate_Relation_Name,
	a.English_Description,
	a.French_Description,
	a.Relation_Type_Code,
	a.Organization_Type_Code,
	c.Database_Name,
	c.Alternate_Database_Name,
	b.Full_English_Desc
  FROM
	DBRelation a,
	DBCore_Table b,
        DBDatabase   c
 WHERE
	a.database_id        = c.database_id    AND
	a.Relation_Type_Code = b.Reference_Code AND
	b.Reference_Group = '0065';

PROMPT DBIndex_Table_Base_View
CREATE OR REPLACE VIEW DBIndex_Table_Base_View AS
SELECT
	Database_Id,
	Relation_Id,
	Source_Module_Id,
	Index_Id,
	Object_Id,
	Method_Id,
	Index_Name,
	Alternate_Index_Name,
	DECODE(Sort_Type_Code, ' ', '0003', Sort_Type_Code) Sort_Type_Code,
	DECODE(Unique_Flag, ' ', '0002', Unique_Flag) Unique_Flag,
	DECODE(Alternate_Flag, ' ' , '0002', Alternate_Flag) Alternate_Flag
  FROM
	DBIndex_Table;

PROMPT DBIndex_Table_Decode_View
CREATE OR REPLACE VIEW DBIndex_Table_Decode_View AS
SELECT
	a.Database_Id,
	a.Relation_Id,
	a.Source_Module_Id,
	a.Index_Id,
	a.Object_Id,
	a.Method_Id,
	a.Index_Name,
	a.Alternate_Index_Name,
	a.Sort_Type_Code,
	b.Full_English_Desc Sort_Type_Desc,
	a.Unique_Flag,
	c.Full_English_Desc Unique_Flag_Desc,
	a.Alternate_Flag,
	d.Full_English_Desc Alternate_Flag_Desc
  FROM
	DBIndex_Table_Base_View a,
	DBCore_Table b,
	DBCore_Table c,
	DBCore_Table d
 WHERE
	a.Sort_Type_Code = b.Reference_Code AND
	b.Reference_Group = '0022' AND
	a.Unique_Flag = c.Reference_Code AND
	c.Reference_Group = '0008' AND
	a.Alternate_Flag = d.Reference_Code AND
	d.Reference_Group = '0008';

PROMPT DBElement_Permission_View
CREATE OR REPLACE VIEW DBElement_Permission_View AS
SELECT
	a.Database_Id,
	a.Relation_Id,
	a.Source_Module_Id,
	a.Element_Id,
	a.Permission_Id,
	a.Object_Id,
	a.Method_Id,
	a.Role_Id,
	b.Role_Name,
	a.Permission_Type_Code,
	c.Full_English_Desc Permission_Type_Desc
  FROM
	DBElement_Permission a,
	DBDatabase_Role b,
	DBCore_Table c
 WHERE
	a.Database_Id = b.Database_Id AND
	a.Role_Id = b.Role_Id AND
	a.Permission_Type_Code = c.Reference_Code AND
	c.Reference_Group = '0015';

PROMPT DBRelation_Element_Decode_View
CREATE OR REPLACE VIEW DBRelation_Element_Decode_View AS
SELECT
	a.Database_Id,
	a.Relation_Id,
	a.Source_Module_Id,
	a.Object_Id,
	a.Method_Id,
	a.Element_Id,
	c.Element_Name,
	c.English_Description,
	c.French_Description,
	a.Item_Size,
	a.Datatype_Code,
	d.Full_English_Desc DataType_Desc,
	b.Relation_Name,
	e.Role_Name,
	e.Permission_Type_Desc
  FROM
	DBRelation_Element a,
	DBRelation b,
	DBElement c,
	DBCore_Table d,
	DBElement_Permission_View e
 WHERE
	a.Database_Id = b.Database_Id AND
	a.Relation_Id = b.Relation_Id AND
	a.Database_Id = c.Database_Id AND
	a.Element_Id = c.Element_Id AND
	a.Datatype_Code = d.Reference_Code(+) AND
	d.Reference_Group(+) = '0004' AND
	a.Database_Id = e.Database_Id(+) AND
	a.Relation_Id = e.Relation_Id(+) AND
	a.Source_Module_Id = e.Source_Module_Id(+) AND
	a.Element_Id = e.Element_Id(+);

PROMPT DBIndex_Segment_View
CREATE OR REPLACE VIEW DBIndex_Segment_View AS
SELECT
	a.Database_Id,
	a.Relation_Id,
	b.Relation_Name,
	b.Alternate_Relation_Name,
	a.Source_Module_Id,
	a.Index_Id,
	c.Index_Name,
        c.ALTERNATE_INDEX_NAME,
        c.ALTERNATE_FLAG      ,
        c.UNIQUE_FLAG         ,
        c.ACTIVE_FLAG         ,
        c.ORDERED_FLAG,
        a.Element_Id,
	d.Element_Name,
	d.Alternate_Element_Name,
	a.Object_Id,
	a.Method_Id,
	a.Sequence_Number,
	a.Item_Datatype_Code,
	e.Full_English_Desc Item_Datatype_Desc,
	a.Item_Datatype_Size,
	a.Sort_Type_Code,
	f.Full_English_Desc Sort_Type_Desc,
	a.Sort_Flag
  FROM
	DBIndex_Segment a,
	DBRelation b,
	DBIndex_Table c,
	DBElement d,
	DBCore_Table e,
	DBCore_Table f
 WHERE
	a.Database_Id = b.Database_Id AND
	a.Relation_Id = b.Relation_Id AND
	a.Database_Id = c.Database_Id AND
	a.Index_Id = c.Index_Id AND
	a.Database_Id = d.Database_Id AND
	a.Element_Id = d.Element_Id AND
	a.Item_Datatype_Code = e.Reference_Code(+) AND
	e.Reference_Group(+) = '0004' AND
	a.Sort_Type_Code = f.Reference_Code(+) AND
	f.Reference_Group(+) = '0022';

PROMPT DBSequence_View
CREATE OR REPLACE VIEW DBSequence_View AS
SELECT
	a.Database_Id,
	a.Sequence_Id,
	a.Object_Id,
	a.Method_Id,
	a.Sequence_Name,
	a.Alternate_Sequence_Name,
	a.Start_Value,
	a.Increment_Value,
	a.Max_Value,
	a.Minimum_Value,
	a.Cycle_Flag,
	b.Full_English_Desc Cycle_Flag_Desc
  FROM
	DBSequence a,
	DBCore_Table b
 WHERE
	a.Cycle_Flag = b.Reference_Code AND
	b.Reference_Group = '0008';

PROMPT DBRelation_Permission_View
CREATE OR REPLACE VIEW DBRelation_Permission_View AS
SELECT
	a.Database_Id,
	a.Relation_Id,
	d.Relation_Name,
	a.Source_Module_Id,
	a.Permission_Id,
	a.Object_Id,
	a.Method_Id,
	a.Role_Id,
	b.Role_Name,
	a.Permission_Type_Code,
	c.Full_English_Desc Permission_Type_Desc
  FROM
	DBRelation_Permission a,
	DBDatabase_Role b,
	DBCore_Table c,
	DBRelation d
 WHERE
	a.Database_Id = b.Database_Id(+) AND
	a.Role_Id = b.Role_Id(+) AND
	a.Permission_Type_Code = c.Reference_Code AND
	c.Reference_Group = '0015' AND
	a.Database_Id = d.Database_Id AND
	a.Relation_Id = d.Relation_Id;

PROMPT DBUser_Role_View
CREATE OR REPLACE VIEW DBUser_Role_View AS
SELECT
	a.Database_Id,
	a.Role_Id,
	b.Role_Name,
	a.User_Id,
	c.User_Name,
	a.Object_Id,
	a.Method_Id,
	a.Active_Flag
  FROM
	DBUser_Role a,
	DBDatabase_Role b,
	DBUser_Table c
 WHERE
	a.Database_Id = b.Database_Id AND
	a.Role_Id = b.Role_Id AND
	a.Database_Id = c.Database_Id AND
	a.User_Id = c.User_Id;

PROMPT DBDatabase_View
CREATE OR REPLACE VIEW DBDatabase_View AS
SELECT
	a.Database_Id,
	a.Database_Name,
	a.Alternate_Database_Name,
	a.Database_Type_Code,
	b.Full_English_Desc,
	a.Logical_Name,
	a.English_Description,
	a.French_Description,
	a.Server_Name,
	a.Owner
  FROM
	DBDatabase a,
	DBCore_Table b
 WHERE
	a.Database_Type_Code = b.Reference_Code(+) AND
	b.Reference_Group(+) = '0003';


Prompt Create VIEW FEDictionary_View
CREATE OR REPLACE VIEW fedictionary_view
 AS
 SELECT
    b.Dictionary_Id,
    c.database_id,
    d.database_name,
    C.ELEMENT_ID             ,
    C.ELEMENT_NAME           ,
    C.ALTERNATE_ELEMENT_NAME ,
    C.DOMAIN_ID              ,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.BWZ_Flag, ' ', Decode(b.BWZ_Flag, ' ', DECODE(a.BWZ_FLag, NULL, ' ', a.BWZ_Flag), b.BWZ_Flag), c.BWZ_Flag), Decode(c.BWZ_Flag, ' ', Decode(e.BWZ_Flag, ' ', DECODE(f.BWZ_FLag, NULL, ' ', f.BWZ_Flag), e.BWZ_Flag), c.BWZ_Flag)) BWZ_Flag,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.Decimal_Position, 0, Decode(b.Decimal_Position, 0, DECODE(a.Decimal_Position, NULL, 0, a.Decimal_Position), b.Decimal_Position), c.Decimal_Position),Decode(c.Decimal_Position, 0, Decode(e.Decimal_Position, 0, DECODE(f.Decimal_Position, NULL, 0, f.Decimal_Position), e.Decimal_Position), c.Decimal_Position)) Decimal_Position,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.Element_Size, 0, Decode(b.Domain_Size, 0, DECODE(a.Template_Size, Null, 0, a.Template_Size), b.Domain_Size), c.Element_Size),Decode(c.Element_Size, 0, Decode(e.Domain_Size, 0, DECODE(f.Template_Size, Null, 0, f.Template_Size), e.Domain_Size), c.Element_Size)) Element_Size,
    Decode(c.Element_Name, b.Domain_Name, Decode(b.Domain_Type_Code, ' ', Decode(a.Template_Type_Code, ' ', DECODE(c.Element_Type_Code, Null, ' ', c.Element_Type_Code), a.Template_Type_Code), b.Domain_Type_Code), Decode(e.Domain_Type_Code, ' ', Decode(f.Template_Type_Code, ' ', DECODE(c.Element_Type_Code, Null, ' ', c.Element_Type_Code), f.Template_Type_Code), e.Domain_Type_Code))  Element_Type_Code,   --The logical datatype!!!!!
    Decode(c.Element_Name, b.Domain_Name, Decode(c.ENGLISH_Heading, ' ', Decode(b.ENGLISH_Heading, ' ', DECODE(a.English_Heading, Null, ' ', a.English_Heading), b.english_Heading), c.english_Heading), Decode(c.ENGLISH_Heading, ' ', Decode(e.ENGLISH_Heading, ' ', DECODE(f.English_Heading, Null, ' ', f.English_Heading), e.english_Heading), c.english_Heading)) english_Heading,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.French_Heading, ' ', Decode(b.French_Heading, ' ', DECODE(a.French_Heading, Null, ' ', a.French_Heading), b.French_Heading), c.French_Heading),Decode(c.French_Heading, ' ', Decode(e.French_Heading, ' ', DECODE(f.French_Heading, Null, ' ', f.French_Heading), e.French_Heading), c.French_Heading)) French_Heading,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.Fill, ' ', Decode(b.Fill, ' ', DECODE(a.Fill, Null, ' ', a.Fill), b.Fill), c.Fill),Decode(c.Fill, ' ', Decode(e.Fill, ' ', DECODE(f.Fill, Null, ' ', f.Fill), e.Fill), c.Fill)) Fill,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.Float_Value, ' ', Decode(b.Float_Value, ' ', DECODE(a.Float_Value, Null, ' ', a.Float_Value), b.Float_Value), c.Float_Value),Decode(c.Float_Value, ' ', Decode(e.Float_Value, ' ', DECODE(f.Float_Value, Null, ' ', f.Float_Value), e.Float_Value), c.Float_Value)) Float_Value,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.Date_Format_Code, ' ', Decode(b.Date_Format_Code, ' ', DECODE(a.Date_Format_Code, Null, ' ', a.Date_Format_Code), b.Date_Format_Code), c.Date_Format_Code),Decode(c.Date_Format_Code, ' ', Decode(e.Date_Format_Code, ' ', DECODE(f.Date_Format_Code, Null, ' ', f.Date_Format_Code), e.Date_Format_Code), c.Date_Format_Code)) Date_Format_Code,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.ENGLISH_Label, ' ', Decode(b.ENGLISH_Label, ' ', DECODE(a.English_Label, Null, ' ', a.English_Label), b.english_Label), c.english_Label),Decode(c.ENGLISH_Label, ' ', Decode(e.ENGLISH_Label, ' ', DECODE(f.English_Label, Null, ' ', f.English_Label), e.english_Label), c.english_Label)) english_Label,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.French_Label, ' ', Decode(b.French_Label, ' ', DECODE(a.French_Label, Null, ' ', a.French_Label), b.French_Label), c.French_Label),Decode(c.French_Label, ' ', Decode(e.French_Label, ' ', DECODE(f.French_Label, Null, ' ', f.French_Label), e.French_Label), c.French_Label)) French_Label,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.ENGLISH_Help, ' ', Decode(b.ENGLISH_Help, ' ', DECODE(a.English_Help, Null, ' ', a.English_Help), b.english_Help), c.english_Help),Decode(c.ENGLISH_Help, ' ', Decode(e.ENGLISH_Help, ' ', DECODE(f.English_Help, Null, ' ', f.English_Help), e.english_Help), c.english_Help)) english_Help,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.French_Help, ' ', Decode(b.French_Help, ' ', DECODE(a.French_Help, Null, ' ', a.French_Help), b.French_Help), c.French_Help),Decode(c.French_Help, ' ', Decode(e.French_Help, ' ', DECODE(f.French_Help, Null, ' ', f.French_Help), e.French_Help), c.French_Help)) French_Help,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.Initial_Value, ' ', Decode(b.Initial_Value, ' ', DECODE(a.Initial_Value, Null, ' ', a.Initial_Value), b.Initial_Value), c.Initial_Value),Decode(c.Initial_Value, ' ', Decode(e.Initial_Value, ' ', DECODE(f.Initial_Value, Null, ' ', f.Initial_Value), e.Initial_Value), c.Initial_Value)) Initial_Value,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.Input_Scale, 0, Decode(b.Input_Scale, 0, DECODE(a.Input_Scale, NULL, 0, a.Input_Scale), b.Input_Scale), c.Input_Scale),Decode(c.Input_Scale, 0, Decode(e.Input_Scale, 0, DECODE(f.Input_Scale, NULL, 0, f.Input_Scale), e.Input_Scale), c.Input_Scale)) Input_Scale,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.Item_Datatype_Code, ' ', Decode(b.Item_Datatype_Code, ' ', DECODE(a.Item_Datatype_Code, Null, ' ', a.Item_Datatype_Code), b.Item_Datatype_Code), c.Item_Datatype_Code),Decode(c.Item_Datatype_Code, ' ', Decode(e.Item_Datatype_Code, ' ', DECODE(f.Item_Datatype_Code, Null, ' ', f.Item_Datatype_Code), e.Item_Datatype_Code), c.Item_Datatype_Code)) Item_Datatype_Code,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.Item_Size, 0, Decode(b.Item_Size, 0, DECODE(a.Item_Size, NULL, 0, a.Item_Size), b.Item_Size), c.Item_Size),Decode(c.Item_Size, 0, Decode(e.Item_Size, 0, DECODE(f.Item_Size, NULL, 0, f.Item_Size), e.Item_Size), c.Item_Size)) Item_Size,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.Leading_Sign, ' ', Decode(b.Leading_Sign, ' ', DECODE(a.Leading_Sign, NULL, ' ', a.Leading_Sign), b.Leading_Sign), c.Leading_Sign),Decode(c.Leading_Sign, ' ', Decode(e.Leading_Sign, ' ', DECODE(f.Leading_Sign, NULL, ' ', f.Leading_Sign), e.Leading_Sign), c.Leading_Sign)) Leading_Sign,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.Output_Scale, 0, Decode(b.Output_Scale, 0, DECODE(a.Output_Scale, NULL, 0, a.Output_Scale), b.Output_Scale), c.Output_Scale),Decode(c.Output_Scale, 0, Decode(e.Output_Scale, 0, DECODE(f.Output_Scale, NULL, 0, f.Output_Scale), e.Output_Scale), c.Output_Scale)) Output_Scale,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.Pattern_Value, ' ', Decode(b.Pattern_Value, ' ', DECODE(a.Pattern_Value, Null, ' ', a.Pattern_Value), b.Pattern_Value), c.Pattern_Value),Decode(c.Pattern_Value, ' ', Decode(e.Pattern_Value, ' ', DECODE(f.Pattern_Value, Null, ' ', f.Pattern_Value), e.Pattern_Value), c.Pattern_Value)) Pattern_Value,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.Picture, ' ', Decode(b.Picture, ' ', DECODE(a.Picture, NULL, ' ', a.Picture), b.Picture), c.Picture),Decode(c.Picture, ' ', Decode(e.Picture, ' ', DECODE(f.Picture, NULL, ' ', f.Picture), e.Picture), c.Picture)) Picture,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.ShiftInput_Code, ' ', Decode(b.ShiftInput_Code, ' ', DECODE(a.ShiftInput_Code, Null, ' ', a.ShiftInput_Code), b.ShiftInput_Code), c.ShiftInput_Code),Decode(c.ShiftInput_Code, ' ', Decode(e.ShiftInput_Code, ' ', DECODE(f.ShiftInput_Code, Null, ' ', f.ShiftInput_Code), e.ShiftInput_Code), c.ShiftInput_Code)) ShiftInput_Code,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.Separator, ' ', Decode(b.Separator, ' ', DECODE(a.Separator, Null, ' ', a.Separator), b.Separator), c.Separator),Decode(c.Separator, ' ', Decode(e.Separator, ' ', DECODE(f.Separator, Null, ' ', f.Separator), e.Separator), c.Separator)) Separator,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.Significance, 0, Decode(b.Significance, 0, DECODE(a.Significance, NULL, 0, a.Significance), b.Significance), c.Significance),Decode(c.Significance, 0, Decode(e.Significance, 0, DECODE(f.Significance, NULL, 0, f.Significance), e.Significance), c.Significance)) Significance,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.Trailing_Sign, ' ', Decode(b.Trailing_Sign, ' ', DECODE(a.Trailing_Sign, Null, ' ', a.Trailing_Sign), b.Trailing_Sign), c.Trailing_Sign),Decode(c.Trailing_Sign, ' ', Decode(e.Trailing_Sign, ' ', DECODE(f.Trailing_Sign, Null, ' ', f.Trailing_Sign), e.Trailing_Sign), c.Trailing_Sign)) Trailing_Sign,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.ENGLISH_description, ' ', Decode(b.ENGLISH_description, ' ', DECODE(a.English_description, Null, ' ', a.English_Description), b.english_description), c.english_description),Decode(c.ENGLISH_description, ' ', Decode(e.ENGLISH_description, ' ', DECODE(f.English_description, Null, ' ', f.English_Description), e.english_description), c.english_description)) english_description,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.French_description, ' ', Decode(b.French_description, ' ', DECODE(a.French_description, Null, ' ', a.French_Description), b.French_description), c.French_description),Decode(c.French_description, ' ', Decode(e.French_description, ' ', DECODE(f.French_description, Null, ' ', f.French_Description), e.French_description), c.French_description)) French_description,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.Data_Values, ' ', Decode(b.Data_Values, ' ', DECODE(a.Data_Values, Null, ' ', a.Data_Values), b.Data_Values), c.Data_Values),Decode(c.Data_Values, ' ', Decode(e.Data_Values, ' ', DECODE(f.Data_Values, Null, ' ', f.Data_Values), e.Data_Values), c.Data_Values)) Values_List,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.Signed_Flag, ' ', Decode(b.Signed_Flag, ' ', DECODE(a.Signed_Flag, Null, ' ', a.Signed_Flag), b.Signed_Flag), c.Signed_Flag),Decode(c.Signed_Flag, ' ', Decode(e.Signed_Flag, ' ', DECODE(f.Signed_Flag, Null, ' ', f.Signed_Flag), e.Signed_Flag), c.Signed_Flag)) Signed_Flag,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.Occurs, 0, Decode(b.Occurs, 0, DECODE(a.Occurs, Null, 0, a.Occurs), b.Occurs), c.Occurs),Decode(c.Occurs, 0, Decode(e.Occurs, 0, DECODE(f.Occurs, Null, 0, f.Occurs), e.Occurs), c.Occurs)) Occurs
 FROM
      DBElement        c,
      DBDomain         b,
      DBTemplate       a,
      DBDatabase       d,
      DBDomain         e,
      DBTemplate       f
WHERE
      c.Database_id   = d.Database_id and
      (UPPER(d.Database_Name) <> 'TEMPORARY DATA' or UPPER(d.Database_Name) NOT like '%TEMPORARYDATA') and
      c.Element_Name     = b.Domain_Name(+)            and
      B.template_id      = a.template_id(+)            and
      c.Domain_Id     = e.Domain_Id(+)            and
      e.template_id      = f.template_id(+)  /*and
     c.rowid =
          (SELECT max(rowid)
             FROM DBElement e
            WHERE e.Element_Name = c.Element_Name)  ' Changed by Chris due to missing dictioanry elements*/
/




PROMPT DBElement_DropDown_View
create or replace view DBElement_DropDown_View as
    select
   	c.Element_id,
    c.Element_Name,
	c.Alternate_Element_Name,
	Decode(g.Value_From, ' ', Decode(f.Value_From, ' ',' ', NULL,' ', f.Value_From), NULL, Decode(f.Value_From, ' ',' ', f.Value_From),  g.Value_From ) Value_From    ,
	Decode(g.Value_From_Caption, ' ', Decode(f.Value_From_Caption, ' ', ' ', NULL, ' ', f.Value_From_Caption), NULL, Decode(f.Value_From_Caption, ' ', ' ', NULL, ' ', f.Value_From_Caption), g.Value_From_Caption) Value_From_Caption    ,
	Decode(g.Value_To, ' ', Decode(f.Value_To, ' ',' ', NULL,' ', f.Value_To), NULL, Decode(f.Value_To, ' ',' ', f.Value_To),  g.Value_To ) Value_To    ,
	Decode(g.Value_To_Caption, ' ', Decode(f.Value_To_Caption, ' ', ' ', NULL, ' ', f.Value_To_Caption), NULL, Decode(f.Value_To_Caption, ' ', ' ', NULL, ' ', f.Value_To_Caption), g.Value_To_Caption) Value_To_Caption
From
    DBELement           C,
	DBElement_Dropdown	D,
    DBDOMAIN            E,
    DBTemplate_Dropdown F,
    DBDomain_Dropdown   G
Where
	c.Element_id		= d.Element_ID(+) And
    c.Domain_Id         = e.Domain_Id(+)  And
    e.Template_Id       = f.Template_Id(+) And
    e.Domain_Id         = g.Domain_Id(+);


Prompt CREATE VIEW DBDAT_View
CREATE OR REPLACE VIEW DBDAT_View
AS
SELECT  ROWNUM Record_Number,
	'COLUMN' TYPE,
	a.Database_Name,
        a.Relation_name,
        b.Full_English_Desc Table_Type,
        '0' Y,
        '0' Z,
        a.Element_Name,
	TO_NUMBER(a.Element_type_code) Element_Type_Code,
	a.Element_Size,
	Core_field_size(a.database_id, a.relation_id, a.element_id) Display_Size,
        Length(core_Remove_token(a.domain_label_value,'"')) Label_Size,
	a.Domain_Label_value Label_Value,
        core_picture_value(a.Picture, a.Element_type_code, a.Element_size) Picture_Value,
	'0' A,
	'0' B,
	'0' C,
	'0' D,
	'0' E,
	'0' F,
	'0' G
FROM
	DBRelation_Element_VIEW a,
	DBCORE_TABLE            b
WHERE
	a.Organization_Type_Code = b.Reference_Code(+) AND
	b.Reference_Group(+) = '0065';


Prompt CREATE VIEW DBDAO_VIEW
CREATE OR REPLACE VIEW DBDAO_View
AS
SELECT  a.Database_Id,
        a.Relation_Id,
        a.Element_Id,
        A.Sequence_number,
        a.Method_id,
        a.Object_id,
        Decode(a.Item_Occurs, 0, Decode(d.Occurs, 0, Decode(e.Occurs, 0, f.Occurs, e.Occurs), d.Occurs), a.Item_Occurs) Item_Occurs,
        a.Parent_Flag,
        a.Item_Redefines_Element_Id,
        a.Aliased_Element_Id,
        b.Database_Name,
        b.Alternate_Database_Name,
        c.Relation_name,
        c.Alternate_Relation_name,
        c.Relation_Type_code,
        c.Organization_Type_Code,
        d.Element_Name,
        d.Alternate_Element_Name,
        -- Logical Type and Size
        Decode(d.Element_Size, 0, Decode(e.Domain_Size, 0, DECODE(f.Template_Size, Null, 0, f.Template_Size), e.Domain_Size), d.Element_Size) Element_Size,
        Decode(e.Domain_Type_Code, ' ', Decode(f.Template_Type_Code, ' ', DECODE(d.Element_Type_Code, Null, ' ', d.Element_Type_Code), f.Template_Type_Code), e.Domain_Type_Code) Element_Type_Code,   --The logical datatype!!!!!
        -- Physical type and size
        Decode(a.Datatype_Code, ' ',Decode(e.ITEM_DATATYPE_CODE, ' ', f.item_datatype_CODE, e.ITEM_DATATYPE_CODE), a.Datatype_Code) ITEM_DATATYPE_CODE,
        Decode(a.Item_Size,0 ,Decode(e.item_size,0, f.item_size, e.item_size), a.item_Size) Item_Size,
        Decode(d.Decimal_Position, 0, Decode(e.Decimal_Position, 0, f.Decimal_Position, e.Decimal_Position), d.Decimal_Position) Decimal_Position,
        Decode(d.Picture, ' ', Decode(e.Picture, ' ', f.Picture, e.Picture), d.Picture) Picture,
        Decode(d.English_label, ' ', Decode(e.English_label, ' ', f.English_label, e.English_label), d.English_label) English_label,
        Decode(d.Date_Format_Code, ' ', Decode(e.Date_Format_Code, ' ', f.Date_Format_Code, e.Date_Format_Code), d.Date_Format_Code) Date_Format_Code,
        Decode(d.Separator, ' ', Decode(e.Separator, ' ', f.Separator, e.Separator), d.Separator) Separator,
        d.Trailing_sign,
        d.Leading_Sign,
        e.Domain_Id,
 		e.Output_Scale,
        e.english_label Domain_Label_Value,
 		e.Picture       Domain_Picture_Value,
 		f.template_name
  FROM  DBRelation_Element      a,
        DBDatabase              b,
        DBRelation              c,
        DBElement               d,
        DBDomain                e,
        DBTemplate              f
 WHERE  a.database_id            = b.Database_id and
        a.relation_id          = c.Relation_id and
        a.Element_Id         = d.Element_Id and
        d.domain_id          = e.domain_id(+) and
        e.template_id         = f.template_id(+)
ORDER BY
 		a.database_id, a.relation_id, a.sequence_number;


PROMPT DBDictionaryDomain_View
CREATE OR REPLACE VIEW DBDictionaryDomain_View AS
SELECT
  	d.dictionary_Name            ,
  	a.domain_name                ,
  	a.alternate_domain_name                ,
  	a.english_description        ,
  	a.french_description         ,
  	a.bwz_flag                   ,
  	a.decimal_position           ,
  	a.domain_size                ,
  	a.domain_type_code           ,
	substr(b.Return_Value,1,30)  domain_type,
  	a.french_heading             ,
  	a.english_heading            ,
  	a.fill                       ,
  	a.float_value                ,
  	a.date_format_code           ,
  	a.english_label              ,
  	a.english_help               ,
  	a.french_help                ,
  	a.french_label               ,
  	a.initial_value              ,
  	a.input_scale                ,
  	a.item_datatype_code         ,
	substr(c.Return_value,1,30)  Item_Datatype,
  	a.item_size                  ,
  	a.leading_sign               ,
  	a.occurs                     ,
  	a.output_scale               ,
  	a.pattern_value              ,
  	a.picture                    ,
  	a.shiftinput_code            ,
  	a.separator                  ,
  	a.significance               ,
  	a.trailing_sign	
  FROM
	DBdomain a,
	DBCore_xref_View b,
	DBCore_xref_view c,
	DBDictionary d
 WHERE
	a.Dictionary_id      = d.dictionary_id     AND
	a.domain_Type_Code   = b.Reference_Code    AND
	b.Reference_Group    = '0004'              AND
        b.Target_reference_group = '0080'          AND
	a.Item_Datatype_Code = c.Reference_Code    AND
	c.Reference_Group    = '0004'              AND
        c.Target_reference_group = '0080';

-- **** NOTE: If changing this view, update the procedure at the top
--            of this script with the necessary changes.
Prompt CREATE VIEW DBStructure_View
CREATE OR REPLACE VIEW DBStructure_View
AS
SELECT  a.Database_Id,
        a.Relation_Id,
        a.Element_Id,
		a.structure_id,
		a.Sequence_Number,
        a.Source_Module_Id,
        b.Object_id,
        b.Method_id,
        b.Element_Name,
        b.Alternate_Element_Name,
        b.Item_occurs Element_Occurs,
        c.Alternate_Element_Name Alternate_Structure_name,
        c.Element_Name Structure_name,
        c.Item_occurs Structure_Occurs
  FROM  DBStructure      a,
        DBRelation_Element_View        b,
        DBRelation_Element_View        c
 WHERE  a.Database_Id = b.Database_Id
   AND  a.Relation_Id = b.Relation_Id
   AND  a.Element_Id  = b.element_Id
   AND  a.Database_id = c.Database_id
   AND  a.Relation_Id = c.Relation_Id
   AND  a.Structure_Id  = c.element_Id;

PROMPT DBUSER_DEFINED_TYPES
CREATE OR REPLACE VIEW DBUSER_DEFINED_TYPES AS
SELECT  A.DATABASE_ID,
        A.RELATION_ID,
        A.ELEMENT_ID,
        Decode(a.Item_Occurs, 0, Decode(d.Occurs, 0, Decode(e.Occurs, 0, f.Occurs, e.Occurs), d.Occurs), a.Item_Occurs) Item_Occurs,
        a.Parent_Flag,
        a.Item_Redefines_Element_Id,
        a.Aliased_Element_Id,
        b.Database_Name,
        b.Alternate_Database_Name,
        c.Relation_name,
        c.Alternate_Relation_name,
        c.Relation_Type_code,
        c.Organization_Type_Code,
        d.Element_Name,
        d.Alternate_Element_Name,
		Decode(d.Element_Size, 0, Decode(e.Domain_Size, 0, DECODE(f.Template_Size, Null, 0, f.Template_Size), Null, 0, e.Domain_Size), d.Element_Size) Element_Size,
        Decode(a.Datatype_Code, ' ',Decode(d.ITEM_DATATYPE_CODE, ' ',Decode(d.ELEMENT_TYPE_CODE, ' ', Decode(e.ITEM_DATATYPE_CODE, ' ' , Decode(e.Domain_TYPE_CODE, ' ',Decode(f.ITEM_DATATYPE_CODE, ' ' ,f.Template_TYPE_CODE,f.ITEM_DATATYPE_CODE),e.Domain_TYPE_CODE),e.ITEM_DATATYPE_CODE), d.ELEMENT_TYPE_CODE),d.ITEM_DATATYPE_CODE), a.Datatype_Code) Element_Type_Code,
        Decode(a.Datatype_Code, ' ',Decode(e.ITEM_DATATYPE_CODE, ' ', f.item_datatype_CODE, e.ITEM_DATATYPE_CODE), a.Datatype_Code) ITEM_DATATYPE_CODE,
        Decode(a.Item_Size,0 ,Decode(e.item_size,0, f.item_size, e.item_size), a.item_Size) Item_Size,
        Decode(e.item_size,0, f.item_size, e.item_size) Physical_Size,
        Decode(e.Decimal_Position,0, f.Decimal_Position, e.Decimal_Position) Decimal_Position,
    	e.Domain_Name,
		e.Alternate_Domain_Name
 FROM  DBRelation_Element      a,
        DBDatabase              b,
        DBRelation              c,
        DBElement               d,
        DBDomain                e,
        DBTemplate              f
 WHERE  a.database_id            = b.Database_id and
        a.relation_id          = c.Relation_id and
        a.Element_Id         = d.Element_Id and
        d.domain_id          = e.domain_id(+) and
        e.template_id         = f.template_id(+) 
ORDER BY
 		a.database_id, a.relation_id, a.sequence_number;
PROMPT DBDictionary_view
CREATE OR REPLACE VIEW DBDictionary_view (
   dictionary_id,
   database_id,
   database_name,
   element_id,
   element_name,
   alternate_element_name,
   domain_id,
   bwz_flag,
   decimal_position,
   element_size,
   element_type_code,
   english_heading,
   french_heading,
   fill,
   float_value,
   date_format_code,
   english_label,
   french_label,
   english_help,
   french_help,
   initial_value,
   input_scale,
   item_datatype_code,
   item_size,
   leading_sign,
   output_scale,
   pattern_value,
   picture,
   shiftinput_code,
   separator,
   significance,
   trailing_sign,
   english_description,
   french_description,
   values_list,
   signed_flag,
   occurs )
AS
SELECT
    b.Dictionary_Id,
    c.database_id,
    d.database_name,
    C.ELEMENT_ID             ,
    C.ELEMENT_NAME           ,
    C.ALTERNATE_ELEMENT_NAME ,
    C.DOMAIN_ID              ,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.BWZ_Flag, ' ', Decode(b.BWZ_Flag, ' ', DECODE(a.BWZ_FLag, NULL, ' ', a.BWZ_Flag), b.BWZ_Flag), c.BWZ_Flag), Decode(c.BWZ_Flag, ' ', Decode(e.BWZ_Flag, ' ', DECODE(f.BWZ_FLag, NULL, ' ', f.BWZ_Flag), e.BWZ_Flag), c.BWZ_Flag)) BWZ_Flag,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.Decimal_Position, 0, Decode(b.Decimal_Position, 0, DECODE(a.Decimal_Position, NULL, 0, a.Decimal_Position), b.Decimal_Position), c.Decimal_Position),Decode(c.Decimal_Position, 0, Decode(e.Decimal_Position, 0, DECODE(f.Decimal_Position, NULL, 0, f.Decimal_Position), e.Decimal_Position), c.Decimal_Position)) Decimal_Position,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.Element_Size, 0, Decode(b.Domain_Size, 0, DECODE(a.Template_Size, Null, 0, a.Template_Size), b.Domain_Size), c.Element_Size),Decode(c.Element_Size, 0, Decode(e.Domain_Size, 0, DECODE(f.Template_Size, Null, 0, f.Template_Size), e.Domain_Size), c.Element_Size)) Element_Size,
    Decode(c.Element_Name, b.Domain_Name, Decode(b.Domain_Type_Code, ' ', Decode(a.Template_Type_Code, ' ', DECODE(c.Element_Type_Code, Null, ' ', c.Element_Type_Code), a.Template_Type_Code), b.Domain_Type_Code), Decode(e.Domain_Type_Code, ' ', Decode(f.Template_Type_Code, ' ', DECODE(c.Element_Type_Code, Null, ' ', c.Element_Type_Code), f.Template_Type_Code), e.Domain_Type_Code))  Element_Type_Code,   --The logical datatype!!!!!
    Decode(c.Element_Name, b.Domain_Name, Decode(c.ENGLISH_Heading, ' ', Decode(b.ENGLISH_Heading, ' ', DECODE(a.English_Heading, Null, ' ', a.English_Heading), b.english_Heading), c.english_Heading), Decode(c.ENGLISH_Heading, ' ', Decode(e.ENGLISH_Heading, ' ', DECODE(f.English_Heading, Null, ' ', f.English_Heading), e.english_Heading), c.english_Heading)) english_Heading,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.French_Heading, ' ', Decode(b.French_Heading, ' ', DECODE(a.French_Heading, Null, ' ', a.French_Heading), b.French_Heading), c.French_Heading),Decode(c.French_Heading, ' ', Decode(e.French_Heading, ' ', DECODE(f.French_Heading, Null, ' ', f.French_Heading), e.French_Heading), c.French_Heading)) French_Heading,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.Fill, ' ', Decode(b.Fill, ' ', DECODE(a.Fill, Null, ' ', a.Fill), b.Fill), c.Fill),Decode(c.Fill, ' ', Decode(e.Fill, ' ', DECODE(f.Fill, Null, ' ', f.Fill), e.Fill), c.Fill)) Fill,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.Float_Value, ' ', Decode(b.Float_Value, ' ', DECODE(a.Float_Value, Null, ' ', a.Float_Value), b.Float_Value), c.Float_Value),Decode(c.Float_Value, ' ', Decode(e.Float_Value, ' ', DECODE(f.Float_Value, Null, ' ', f.Float_Value), e.Float_Value), c.Float_Value)) Float_Value,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.Date_Format_Code, ' ', Decode(b.Date_Format_Code, ' ', DECODE(a.Date_Format_Code, Null, ' ', a.Date_Format_Code), b.Date_Format_Code), c.Date_Format_Code),Decode(c.Date_Format_Code, ' ', Decode(e.Date_Format_Code, ' ', DECODE(f.Date_Format_Code, Null, ' ', f.Date_Format_Code), e.Date_Format_Code), c.Date_Format_Code)) Date_Format_Code,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.ENGLISH_Label, ' ', Decode(b.ENGLISH_Label, ' ', DECODE(a.English_Label, Null, ' ', a.English_Label), b.english_Label), c.english_Label),Decode(c.ENGLISH_Label, ' ', Decode(e.ENGLISH_Label, ' ', DECODE(f.English_Label, Null, ' ', f.English_Label), e.english_Label), c.english_Label)) english_Label,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.French_Label, ' ', Decode(b.French_Label, ' ', DECODE(a.French_Label, Null, ' ', a.French_Label), b.French_Label), c.French_Label),Decode(c.French_Label, ' ', Decode(e.French_Label, ' ', DECODE(f.French_Label, Null, ' ', f.French_Label), e.French_Label), c.French_Label)) French_Label,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.ENGLISH_Help, ' ', Decode(b.ENGLISH_Help, ' ', DECODE(a.English_Help, Null, ' ', a.English_Help), b.english_Help), c.english_Help),Decode(c.ENGLISH_Help, ' ', Decode(e.ENGLISH_Help, ' ', DECODE(f.English_Help, Null, ' ', f.English_Help), e.english_Help), c.english_Help)) english_Help,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.French_Help, ' ', Decode(b.French_Help, ' ', DECODE(a.French_Help, Null, ' ', a.French_Help), b.French_Help), c.French_Help),Decode(c.French_Help, ' ', Decode(e.French_Help, ' ', DECODE(f.French_Help, Null, ' ', f.French_Help), e.French_Help), c.French_Help)) French_Help,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.Initial_Value, ' ', Decode(b.Initial_Value, ' ', DECODE(a.Initial_Value, Null, ' ', a.Initial_Value), b.Initial_Value), c.Initial_Value),Decode(c.Initial_Value, ' ', Decode(e.Initial_Value, ' ', DECODE(f.Initial_Value, Null, ' ', f.Initial_Value), e.Initial_Value), c.Initial_Value)) Initial_Value,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.Input_Scale, 0, Decode(b.Input_Scale, 0, DECODE(a.Input_Scale, NULL, 0, a.Input_Scale), b.Input_Scale), c.Input_Scale),Decode(c.Input_Scale, 0, Decode(e.Input_Scale, 0, DECODE(f.Input_Scale, NULL, 0, f.Input_Scale), e.Input_Scale), c.Input_Scale)) Input_Scale,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.Item_Datatype_Code, ' ', Decode(b.Item_Datatype_Code, ' ', DECODE(a.Item_Datatype_Code, Null, ' ', a.Item_Datatype_Code), b.Item_Datatype_Code), c.Item_Datatype_Code),Decode(c.Item_Datatype_Code, ' ', Decode(e.Item_Datatype_Code, ' ', DECODE(f.Item_Datatype_Code, Null, ' ', f.Item_Datatype_Code), e.Item_Datatype_Code), c.Item_Datatype_Code)) Item_Datatype_Code,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.Item_Size, 0, Decode(b.Item_Size, 0, DECODE(a.Item_Size, NULL, 0, a.Item_Size), b.Item_Size), c.Item_Size),Decode(c.Item_Size, 0, Decode(e.Item_Size, 0, DECODE(f.Item_Size, NULL, 0, f.Item_Size), e.Item_Size), c.Item_Size)) Item_Size,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.Leading_Sign, ' ', Decode(b.Leading_Sign, ' ', DECODE(a.Leading_Sign, NULL, ' ', a.Leading_Sign), b.Leading_Sign), c.Leading_Sign),Decode(c.Leading_Sign, ' ', Decode(e.Leading_Sign, ' ', DECODE(f.Leading_Sign, NULL, ' ', f.Leading_Sign), e.Leading_Sign), c.Leading_Sign)) Leading_Sign,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.Output_Scale, 0, Decode(b.Output_Scale, 0, DECODE(a.Output_Scale, NULL, 0, a.Output_Scale), b.Output_Scale), c.Output_Scale),Decode(c.Output_Scale, 0, Decode(e.Output_Scale, 0, DECODE(f.Output_Scale, NULL, 0, f.Output_Scale), e.Output_Scale), c.Output_Scale)) Output_Scale,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.Pattern_Value, ' ', Decode(b.Pattern_Value, ' ', DECODE(a.Pattern_Value, Null, ' ', a.Pattern_Value), b.Pattern_Value), c.Pattern_Value),Decode(c.Pattern_Value, ' ', Decode(e.Pattern_Value, ' ', DECODE(f.Pattern_Value, Null, ' ', f.Pattern_Value), e.Pattern_Value), c.Pattern_Value)) Pattern_Value,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.Picture, ' ', Decode(b.Picture, ' ', DECODE(a.Picture, NULL, ' ', a.Picture), b.Picture), c.Picture),Decode(c.Picture, ' ', Decode(e.Picture, ' ', DECODE(f.Picture, NULL, ' ', f.Picture), e.Picture), c.Picture)) Picture,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.ShiftInput_Code, ' ', Decode(b.ShiftInput_Code, ' ', DECODE(a.ShiftInput_Code, Null, ' ', a.ShiftInput_Code), b.ShiftInput_Code), c.ShiftInput_Code),Decode(c.ShiftInput_Code, ' ', Decode(e.ShiftInput_Code, ' ', DECODE(f.ShiftInput_Code, Null, ' ', f.ShiftInput_Code), e.ShiftInput_Code), c.ShiftInput_Code)) ShiftInput_Code,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.Separator, ' ', Decode(b.Separator, ' ', DECODE(a.Separator, Null, ' ', a.Separator), b.Separator), c.Separator),Decode(c.Separator, ' ', Decode(e.Separator, ' ', DECODE(f.Separator, Null, ' ', f.Separator), e.Separator), c.Separator)) Separator,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.Significance, 0, Decode(b.Significance, 0, DECODE(a.Significance, NULL, 0, a.Significance), b.Significance), c.Significance),Decode(c.Significance, 0, Decode(e.Significance, 0, DECODE(f.Significance, NULL, 0, f.Significance), e.Significance), c.Significance)) Significance,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.Trailing_Sign, ' ', Decode(b.Trailing_Sign, ' ', DECODE(a.Trailing_Sign, Null, ' ', a.Trailing_Sign), b.Trailing_Sign), c.Trailing_Sign),Decode(c.Trailing_Sign, ' ', Decode(e.Trailing_Sign, ' ', DECODE(f.Trailing_Sign, Null, ' ', f.Trailing_Sign), e.Trailing_Sign), c.Trailing_Sign)) Trailing_Sign,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.ENGLISH_description, ' ', Decode(b.ENGLISH_description, ' ', DECODE(a.English_description, Null, ' ', a.English_Description), b.english_description), c.english_description),Decode(c.ENGLISH_description, ' ', Decode(e.ENGLISH_description, ' ', DECODE(f.English_description, Null, ' ', f.English_Description), e.english_description), c.english_description)) english_description,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.French_description, ' ', Decode(b.French_description, ' ', DECODE(a.French_description, Null, ' ', a.French_Description), b.French_description), c.French_description),Decode(c.French_description, ' ', Decode(e.French_description, ' ', DECODE(f.French_description, Null, ' ', f.French_Description), e.French_description), c.French_description)) French_description,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.Data_Values, ' ', Decode(b.Data_Values, ' ', DECODE(a.Data_Values, Null, ' ', a.Data_Values), b.Data_Values), c.Data_Values),Decode(c.Data_Values, ' ', Decode(e.Data_Values, ' ', DECODE(f.Data_Values, Null, ' ', f.Data_Values), e.Data_Values), c.Data_Values)) Values_List,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.Signed_Flag, ' ', Decode(b.Signed_Flag, ' ', DECODE(a.Signed_Flag, Null, ' ', a.Signed_Flag), b.Signed_Flag), c.Signed_Flag),Decode(c.Signed_Flag, ' ', Decode(e.Signed_Flag, ' ', DECODE(f.Signed_Flag, Null, ' ', f.Signed_Flag), e.Signed_Flag), c.Signed_Flag)) Signed_Flag,
    Decode(c.Element_Name, b.Domain_Name, Decode(c.Occurs, 0, Decode(b.Occurs, 0, DECODE(a.Occurs, Null, 0, a.Occurs), b.Occurs), c.Occurs),Decode(c.Occurs, 0, Decode(e.Occurs, 0, DECODE(f.Occurs, Null, 0, f.Occurs), e.Occurs), c.Occurs)) Occurs
 FROM
      DBElement        c,
      DBDomain         b,
      DBTemplate       a,
      DBDatabase       d,
      DBDomain         e,
      DBTemplate       f
WHERE
      c.Database_id   = d.Database_id and
--      UPPER(d.Database_Name) NOT IN ('TEMPORARY DATA') and
      c.Element_Name     = b.Domain_Name(+)            and
      B.template_id      = a.template_id(+)            and
      c.Domain_Id     = e.Domain_Id(+)            and
      e.template_id      = f.template_id(+);

Prompt CREATE VIEW DBStructure_Detail_View
CREATE OR REPLACE VIEW DBStructure_Detail_View
AS
SELECT 
	b.database_name,
	b.relation_name,
        b.Element_Name,
        b.Alternate_Element_Name,
    	d.Full_English_Desc Element_Type,
        b.Item_size Parent_size,
        c.Alternate_Element_Name Alternate_Structure_name,
        c.Element_Name Structure_name,
        c.item_datatype_code,
	d.Full_English_Desc Structure_Type,
        c.element_size,
        c.item_size
  FROM  DBStructure      a,
        DBRelation_Element_View        b,
        DBRelation_Element_View        c,
       	DBCore_Table d,
       	DBCore_Table e   	    
 WHERE  a.Database_Id = b.Database_Id
   AND  a.Relation_Id = b.Relation_Id
   AND  a.Element_Id  = b.element_Id
   AND  a.Database_id = c.Database_id
   AND  a.Relation_Id = c.Relation_Id
   AND  a.Structure_Id  = c.element_Id
   AND  b.item_datatype_code = d.Reference_Code(+) 
   AND	d.Reference_Group(+) = '0004'
   AND  c.item_datatype_code = e.Reference_Code(+) 
   AND	e.Reference_Group(+) = '0004'
Order by a.database_id,a.relation_id, a.element_id, a.sequence_number;

Prompt CREATE VIEW IMPORT_SCHEMA
CREATE OR REPLACE VIEW IMPORT_SCHEMA AS
SELECT 
 	b.physical_name,
         a.Alternate_Database_Name Schema_Name,
         a.Alternate_Relation_name Relation_name,
         a.Alternate_Element_name Element_name,
         f.Full_English_Desc Element_type,
         decode(Decode(c.Signed_Flag, ' ', Decode(d.Signed_Flag, ' ', e.Signed_Flag, d.Signed_Flag), c.Signed_Flag),'0001', 'True', '0002', 'False', ' ') Signed_Flag,
         a.Item_Size,
         decode(a.Decimal_Position,'',' ', a.decimal_position) Decimal_position,
         decode(a.Picture,'', ' ', a.Picture) Picture,
         decode(a.Date_Format_Code, ' ', Decode(Full_English_Desc, 'Date', 'YYYYMMDD', ' '), ' ')DateFormat,
         nvl(decode(c.Input_Scale, 0, Decode(d.Input_Scale, 0, e.Input_Scale, d.Input_Scale), c.Input_Scale), 0) Input_Scale,
         nvl(decode(c.Output_Scale, 0, Decode(d.Output_Scale, 0, e.Output_Scale, d.Output_Scale), c.Output_Scale), 0) Output_Scale,
         decode(a.Item_Occurs,'', ' ', a.Item_Occurs) Item_occurs,
 	decode(a.Parent_Flag,'0001', 'True', ' ') Parent_flag,
         decode(g.Alternate_Element_name, '', ' ',g.Alternate_Element_name) REDEFINED_ELEMENT,
  	(select sum(Item_size) from Dbrelation_element_summary where relation_id = a.relation_id group by relation_id) Record_length
 FROM    DBRelation_Element_Summary      a,
         DBRelation                      b,
         DBElement               	c,
 	DBDomain                	d,
 	DBTemplate              	e,
         DBCore_Table                    f,
         DBElement                       g
 WHERE  a.database_id          = b.Database_id and
        a.relation_id          = b.Relation_id and
         a.Element_Id          = c.Element_Id and
         c.domain_id           = d.domain_id(+) and
         d.template_id         = e.template_id(+) and
        a.Element_Type_Code    = f.Reference_Code AND
        f.Reference_Group      = '0004'           and
        a.ITEM_REDEFINES_ELEMENT_ID  = g.Element_Id(+)  
 ORDER BY
	a.database_id, a.relation_id, a.sequence_number;

SPOOL OFF;

--EXIT;







