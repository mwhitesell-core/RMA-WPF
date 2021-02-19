select distinct project_id, Module_id, '-- ', Module_type_code, module_source, Module_name from ERROR_LOG;

-- Modules To Drop from the repository that failed in the load 
select 'exec dl_Rperase_project_module(', rpmodule.Project_id, ', ', Module_id, '); -- ', Project_name, '-- ', Module_name 
from rpmodule, rpproject
where rpmodule.project_id = rpproject.project_id 
and module_source in (select distinct module_source from error_log)
order by rpmodule.project_id, module_id;

-- Modules To reload grouped by Type
select distinct Project_name, module_type_code, module_source 
from error_log
Order by Project_name, Module_type_code, Module_source;


 
-- Called modules across projects
select b.project_name, 
       a.Module_name, 
       a.Called_module_name, 
      (select project_name 
          from rpproject 
              where project_id in 
                (select project_id from rpmodule where module_name = a.called_module_name and project_id <> a.project_id
                and module_id in (select distinct module_id from rpprocedure))) FoundIn
from rpcalled_module_view a, rpproject b
where a.project_id = b.project_id 
and a.called_module_type_code = '0004' and
a.called_module_id not in (select distinct module_id from rpprocedure);

select * from rpmodule_view;


select distinct module_name from error_log where module_type_code = '0004';

select * from rpmodule where module_type_code = '0004'
and module_id not in (select distinct module_id from rpprocedure);

select * from rpcode_walkthrough_new where project_id = 141 and Module_id = 21794;

select * from rpmodule where module_name in 
(select a.Module_name from rpcalled_module_view a
where a.called_module_type_code = '0004' and
a.called_module_id not in (select distinct module_id from rpprocedure));



