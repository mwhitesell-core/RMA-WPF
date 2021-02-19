
 CREATE OR REPLACE FORCE VIEW CORE.IMPORT_SCHEMA AS
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