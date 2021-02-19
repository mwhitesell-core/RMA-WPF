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
