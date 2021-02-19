#-------------------------------------------------------------------------------
# File 'backup_subfile_82.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_subfile_82'
#-------------------------------------------------------------------------------

clear
echo "BACKUP OF MONTHLY CLAIM SUBFILE - PLACE APPROPRIATE TAPE ONLINE"
echo ""
if (Test-Path claims_subfile_82_apr.sf)
{
        if (Test-Path claims_subfile_82_may.sf)
        {
                    &$env:cmd\call_error_duplicate_files apr may
        } else {
          if (Test-Path claims_subfile_82_jun.sf)
          {
                        &$env:cmd\call_error_duplicate_files apr jun
          } else {
            if (Test-Path claims_subfile_82_yr.sf)
            {
                            &$env:cmd\call_error_duplicate_files apr yr
            } else {
              if (Test-Path claims_subfile_82_jul.sf)
            {
                                &$env:cmd\call_error_duplicate_files apr jul
              } else {
                if (Test-Path claims_subfile_82_aug.sf)
                {
                                    &$env:cmd\call_error_duplicate_files apr aug
                } else {
                  if (Test-Path claims_subfile_82_sep.sf)
                  {
                                        &$env:cmd\call_error_duplicate_files apr sep
                  } else {
                    if (Test-Path claims_subfile_82_oct.sf)
                    {
                                            &$env:cmd\call_error_duplicate_files apr oct
                    } else {
                      if (Test-Path claims_subfile_82_nov.sf)
                    {
                                                &$env:cmd\call_error_duplicate_files apr nov
                      } else {
                        if (Test-Path claims_subfile_82_dec.sf)
                        {
                                                    &$env:cmd\call_error_duplicate_files apr dec
                        } else {
                                              &$env:cmd\call_backup_mthly_sub82 apr 0
                        }
                }
                }
                }
                }
        }
        }
        }
        }
} else {
if (Test-Path claims_subfile_82_may.sf)
{
          if (Test-Path claims_subfile_82_jun.sf)
          {
                        &$env:cmd\call_error_duplicate_files may jun
          } else {
            if (Test-Path claims_subfile_82_yr.sf)
            {
                            &$env:cmd\call_error_duplicate_files may yr
            } else {
              if (Test-Path claims_subfile_82_jul.sf)
              {
                                &$env:cmd\call_error_duplicate_files may jul
              } else {
                if (Test-Path claims_subfile_82_aug.sf)
                {
                                    &$env:cmd\call_error_duplicate_files may aug
                } else {
                  if (Test-Path claims_subfile_82_sep.sf)
                  {
                                        &$env:cmd\call_error_duplicate_files may sep
                  } else {
                    if (Test-Path claims_subfile_82_oct.sf)
                    {
                                            &$env:cmd\call_error_duplicate_files may oct
                    } else {
                      if (Test-Path claims_subfile_82_nov.sf)
                      {
                                                &$env:cmd\call_error_duplicate_files may nov
                      } else {
                        if (Test-Path claims_subfile_82_dec.sf)
                        {
                                                    &$env:cmd\call_error_duplicate_files may dec
                        } else {
                                                  &$env:cmd\call_backup_mthly_sub82 may 1
                        }
                }
                }
                }
                }
        }
        }
        }
} else {
if (Test-Path claims_subfile_82_jun.sf)
{
            if (Test-Path claims_subfile_82_yr.sf)
            {
                            &$env:cmd\call_error_duplicate_files jun yr
            } else {
              if (Test-Path claims_subfile_82_jul.sf)
              {
                                &$env:cmd\call_error_duplicate_files jun jul
              } else {
                if (Test-Path claims_subfile_82_aug.sf)
                {
                                    &$env:cmd\call_error_duplicate_files jun aug
                } else {
                  if (Test-Path claims_subfile_82_sep.sf)
                  {
                                        &$env:cmd\call_error_duplicate_files jun sep
                  } else {
                    if (Test-Path claims_subfile_82_oct.sf)
                    {
                                            &$env:cmd\call_error_duplicate_files jun oct
                    } else {
                      if (Test-Path claims_subfile_82_nov.sf)
                        {
                                                &$env:cmd\call_error_duplicate_files jun nov
                      } else {
                        if (Test-Path claims_subfile_82_dec.sf)
                        {
                                                    &$env:cmd\call_error_duplicate_files jun dec
                        } else {
                                              &$env:cmd\call_backup_mthly_sub82 jun 2
                        }
                }
                }
                }
                }
        }
        }
        } else {
        if (Test-Path claims_subfile_82_yr.sf)
        {
              if (Test-Path claims_subfile_82_jul.sf)
              {
                                &$env:cmd\call_error_duplicate_files yr jul
              } else {
                if (Test-Path claims_subfile_82_aug.sf)
                {
                                    &$env:cmd\call_error_duplicate_files yr aug
                } else {
                  if (Test-Path claims_subfile_82_sep.sf)
                  {
                                        &$env:cmd\call_error_duplicate_files yr sep
                  } else {
                    if (Test-Path claims_subfile_82_oct.sf)
                    {
                                            &$env:cmd\call_error_duplicate_files yr oct
                    } else {
                      if (Test-Path claims_subfile_82_nov.sf)
                      {
                                                &$env:cmd\call_error_duplicate_files yr nov
                      } else {
                        if (Test-Path claims_subfile_82_dec.sf)
                        {
                                                    &$env:cmd\call_error_duplicate_files yr dec
                        } else {
                                                                &$env:cmd\call_backup_mthly_sub82 yr 3
                         }
                        }
                        }
                  }
                }
              }
} else {
if (Test-Path claims_subfile_82_jul.sf)
{
                if (Test-Path claims_subfile_82_aug.sf)
                {
                                    &$env:cmd\call_error_duplicate_files jul aug
                } else {
                  if (Test-Path claims_subfile_82_sep.sf)
                  {
                                        &$env:cmd\call_error_duplicate_files jul sep
                  } else {
                    if (Test-Path claims_subfile_82_oct.sf)
                    {
                                            &$env:cmd\call_error_duplicate_files jul oct
                    } else {
                      if (Test-Path claims_subfile_82_nov.sf)
                      {
                                                &$env:cmd\call_error_duplicate_files jul nov
                      } else {
                        if (Test-Path claims_subfile_82_dec.sf)
                        {
                                                    &$env:cmd\call_error_duplicate_files jul dec
                        } else {
                                                      &$env:cmd\call_backup_mthly_sub82 jul 4
                        }
                }
                }
                }
                }
} else {
if (Test-Path claims_subfile_82_aug.sf)
{
                  if (Test-Path claims_subfile_82_sep.sf)
                  {
                                        &$env:cmd\call_error_duplicate_files aug sep
                  } else {
                    if (Test-Path claims_subfile_82_oct.sf)
                    {
                                            &$env:cmd\call_error_duplicate_files aug oct
                    } else {
                      if (Test-Path claims_subfile_82_nov.sf)
                      {
                                                &$env:cmd\call_error_duplicate_files aug nov
                      } else {
                        if (Test-Path claims_subfile_82_dec.sf)
                        {
                                                    &$env:cmd\call_error_duplicate_files aug dec
                        } else {
                                                      &$env:cmd\call_backup_mthly_sub82 aug 5
                        }
                }
                }
                }
} else {
if (Test-Path claims_subfile_82_sep.sf)
{
                    if (Test-Path claims_subfile_82_oct.sf)
                    {
                                            &$env:cmd\call_error_duplicate_files sep oct
                    } else {
                      if (Test-Path claims_subfile_82_nov.sf)
                      {
                                                &$env:cmd\call_error_duplicate_files sep nov
                      } else {
                        if (Test-Path claims_subfile_82_dec.sf)
                        {
                                                    &$env:cmd\call_error_duplicate_files sep dec
                        } else {
                                                  &$env:cmd\call_backup_mthly_sub82 sep 6
                        }
                }
                }
} else {
if (Test-Path claims_subfile_82_oct.sf)
{
                      if (Test-Path claims_subfile_82_nov.sf)
                      {
                                                &$env:cmd\call_error_duplicate_files oct nov
                      } else {
                        if (Test-Path claims_subfile_82_dec.sf)
                        {
                                                    &$env:cmd\call_error_duplicate_files oct dec
                        } else {
                                          &$env:cmd\call_backup_mthly_sub82 oct 0
                        }
                }
} else {
if (Test-Path claims_subfile_82_nov.sf)
{
                        if (Test-Path claims_subfile_82_dec.sf)
                        {
                                                    &$env:cmd\call_error_duplicate_files nov dec
                        } else {
                                              &$env:cmd\call_backup_mthly_sub82 nov 1
                        }
} else {
if (Test-Path claims_subfile_82_dec.sf)
{
                                              &$env:cmd\call_backup_mthly_sub82 dec 2
} else {
if (Test-Path claims_subfile_82_jan.sf)
{
  if (Test-Path claims_subfile_82_feb.sf)
  {
        &$env:cmd\call_error_duplicate_files jan feb
  } else {
    if (Test-Path claims_subfile_82_mar.sf)
    {
            &$env:cmd\call_error_duplicate_files jan mar
    } else {
      if (Test-Path claims_subfile_82_apr.sf)
      {
                &$env:cmd\call_error_duplicate_files jan apr
      } else {
        if (Test-Path claims_subfile_82_may.sf)
        {
                    &$env:cmd\call_error_duplicate_files jan may
        } else {
          if (Test-Path claims_subfile_82_jun.sf)
          {
                        &$env:cmd\call_error_duplicate_files jan jun
          } else {
            if (Test-Path claims_subfile_82_yr.sf)
            {
                            &$env:cmd\call_error_duplicate_files jan yr
            } else {
              if (Test-Path claims_subfile_82_jul.sf)
              {
                                &$env:cmd\call_error_duplicate_files jan jul
              } else {
                if (Test-Path claims_subfile_82_aug.sf)
                {
                                    &$env:cmd\call_error_duplicate_files jan aug
                } else {
                  if (Test-Path claims_subfile_82_sep.sf)
                  {
                                        &$env:cmd\call_error_duplicate_files jan sep
                  } else {
                    if (Test-Path claims_subfile_82_oct.sf)
                    {
                                            &$env:cmd\call_error_duplicate_files jan oct
                    } else {
                      if (Test-Path claims_subfile_82_nov.sf)
                      {
                                                &$env:cmd\call_error_duplicate_files jan nov
                      } else {
                        if (Test-Path claims_subfile_82_dec.sf)
                        {
                                                    &$env:cmd\call_error_duplicate_files jan dec
                        } else {
                                                      &$env:cmd\call_backup_mthly_sub82 jan 3
                        }
                }
                }
                }
                }
        }
        }
        }
        }
      }
    }
  }
} else {
if (Test-Path claims_subfile_82_feb.sf)
{
    if (Test-Path claims_subfile_82_mar.sf)
    {
            &$env:cmd\call_error_duplicate_files feb mar
    } else {
      if (Test-Path claims_subfile_82_apr.sf)
      {
                &$env:cmd\call_error_duplicate_files feb apr
      } else {
        if (Test-Path claims_subfile_82_may.sf)
        {
                    &$env:cmd\call_error_duplicate_files feb may
        } else {
          if (Test-Path claims_subfile_82_jun.sf)
          {
                        &$env:cmd\call_error_duplicate_files feb jun
          } else {
            if (Test-Path claims_subfile_82_yr.sf)
            {
                            &$env:cmd\call_error_duplicate_files feb yr
            } else {
              if (Test-Path claims_subfile_82_jul.sf)
              {
                                &$env:cmd\call_error_duplicate_files feb jul
              } else {
                if (Test-Path claims_subfile_82_aug.sf)
                {
                                  &$env:cmd\call_error_duplicate_files feb aug
                } else {
                  if (Test-Path claims_subfile_82_sep.sf)
                  {
                                        &$env:cmd\call_error_duplicate_files feb sep
                  } else {
                    if (Test-Path claims_subfile_82_oct.sf)
                    {
                                            &$env:cmd\call_error_duplicate_files feb oct
                    } else {
                      if (Test-Path claims_subfile_82_nov.sf)
                      {
                                                &$env:cmd\call_error_duplicate_files feb nov
                      } else {
                        if (Test-Path claims_subfile_82_dec.sf)
                        {
                                                    &$env:cmd\call_error_duplicate_files feb dec
                        } else {
                                              &$env:cmd\call_backup_mthly_sub82 feb 4
                        }
                }
                }
                }
                }
        }
        }
        }
        }
      }
    }
} else {
if (Test-Path claims_subfile_82_mar.sf)
{
      if (Test-Path claims_subfile_82_apr.sf)
      {
                &$env:cmd\call_error_duplicate_files mar apr
      } else {
        if (Test-Path claims_subfile_82_may.sf)
        {
                    &$env:cmd\call_error_duplicate_files mar may
        } else {
          if (Test-Path claims_subfile_82_jun.sf)
          {
                        &$env:cmd\call_error_duplicate_files mar jun
          } else {
            if (Test-Path claims_subfile_82_yr.sf)
            {
                            &$env:cmd\call_error_duplicate_files mar yr
            } else {
              if (Test-Path claims_subfile_82_jul.sf)
              {
                                &$env:cmd\call_error_duplicate_files mar jul
              } else {
                if (Test-Path claims_subfile_82_aug.sf)
                {
                                    &$env:cmd\call_error_duplicate_files mar aug
                } else {
                  if (Test-Path claims_subfile_82_sep.sf)
                  {
                                        &$env:cmd\call_error_duplicate_files mar sep
                  } else {
                    if (Test-Path claims_subfile_82_oct.sf)
                    {
                                            &$env:cmd\call_error_duplicate_files mar oct
                    } else {
                      if (Test-Path claims_subfile_82_nov.sf)
                      {
                                                &$env:cmd\call_error_duplicate_files mar nov
                      } else {
                        if (Test-Path claims_subfile_82_dec.sf)
                        {
                                                    &$env:cmd\call_error_duplicate_files mar dec
                        } else {
                                          &$env:cmd\call_backup_mthly_sub82 mar 5
                        }
                }
                }
                }
                }
        }
        }
        }
        }
      }
} else {
echo "no files"
}
}
}
}
}
}
}
}
}
}
}
}
}
