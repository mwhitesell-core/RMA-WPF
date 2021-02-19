-- Brad's List
update [INDEXED].[F020_DOCTOR_EXTRA] 
set DOC_flag_Primary   = ''
where doc_nbr in ('K01', '36H', 'N93', '22A', '12A', '296', '284')

-- Moira's List
update [INDEXED].[F020_DOCTOR_EXTRA] 
set DOC_flag_Primary   = ''
where doc_nbr in ('558','55E','75H','88N','26N','497','65R','66R','67R','03T','04T','B68','214','41N','67F','N22','25M','E74','W60','63F','38P','J08','22K','P63','V54','15T','46J','89E','05M','W16','50P','24J','25J','96K','45J','90J','43E','32F','33F','34F','48E','78N','64H','96F','018','41V','64V','B47','C22','J50','387','50K','K10','M76','25P','532','K15','N66','R37')

-- Cores list
update [INDEXED].[F020_DOCTOR_EXTRA] 
set DOC_flag_Primary   = ''
where doc_nbr in ('52K')
