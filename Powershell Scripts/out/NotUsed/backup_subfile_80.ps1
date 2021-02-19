#-------------------------------------------------------------------------------
# File 'backup_subfile_80.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_subfile_80'
#-------------------------------------------------------------------------------

clear
echo "BACKUP OF MONTHLY CLAIM SUBFILE - PLACE APPROPRIATE TAPE ONLINE"
echo ""
Set-Location $application_upl

if (Test-Path claims_subfile_80_apr.sf)
{
        if (Test-Path claims_subfile_80_may.sf)
        {
                                &$env:cmd\call_error_duplicate_files apr may
        } else {
        if (Test-Path claims_subfile_80_jun.sf)
        {
                                &$env:cmd\call_error_duplicate_files apr jun
        } else {
           if (Test-Path claims_subfile_80_yr.sf)
           {
                            &$env:cmd\call_error_duplicate_files apr yr
            } else {
           if (Test-Path claims_subfile_80_jul.sf)
           {
                                &$env:cmd\call_error_duplicate_files apr jul
              } else {
              if (Test-Path claims_subfile_80_aug.sf)
              {
                                    &$env:cmd\call_error_duplicate_files apr aug
                } else {
                if (Test-Path claims_subfile_80_sep.sf)
                {
                                        &$env:cmd\call_error_duplicate_files apr sep
                  } else {
                  if (Test-Path claims_subfile_80_oct.sf)
                  {
                                            &$env:cmd\call_error_duplicate_files apr oct
                    } else {
                    if (Test-Path claims_subfile_80_nov.sf)
                    {
                                                &$env:cmd\call_error_duplicate_files apr nov
                      } else {
                      if (Test-Path claims_subfile_80_dec.sf)
                      {
                                                    &$env:cmd\call_error_duplicate_files apr dec
                        } else {
                                              &$env:cmd\call_backup_mthly_sub80 apr 0
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
 if (Test-Path claims_subfile_80_may.sf)
 {
# CONVERSION ERROR (unexpected, #57): Unknown command.
#           if [ claims_subfile_80_jun.sf ]
          {
                        &$env:cmd\call_error_duplicate_files may jun
          } else {
            if (Test-Path claims_subfile_80_yr.sf)
            {
                            &$env:cmd\call_error_duplicate_files may yr
            } else {
              if (Test-Path claims_subfile_80_jul.sf)
              {
                                &$env:cmd\call_error_duplicate_files may jul
              } else {
                if (Test-Path claims_subfile_80_aug.sf)
                {
                                    &$env:cmd\call_error_duplicate_files may aug
                } else {
                  if (Test-Path claims_subfile_80_sep.sf)
                  {
                                        &$env:cmd\call_error_duplicate_files may sep
                  } else {
                    if (Test-Path claims_subfile_80_oct.sf)
                    {
                                            &$env:cmd\call_error_duplicate_files may oct
                    } else {
                      if (Test-Path claims_subfile_80_nov.sf)
                      {
                                                &$env:cmd\call_error_duplicate_files may nov
                      } else {
                        if (Test-Path claims_subfile_80_dec.sf)
                        {
                                                    &$env:cmd\call_error_duplicate_files may dec
                        } else {
                                                  &$env:cmd\call_backup_mthly_sub80 may 1
                        }
                }
                }
                }
                }
        }
        }
        }
} else {
if (Test-Path claims_subfile_80_jun.sf)
{
            if (Test-Path claims_subfile_80_yr.sf)
            {
                            &$env:cmd\call_error_duplicate_files jun yr
            } else {
              if (Test-Path claims_subfile_80_jul.sf)
              {
                                &$env:cmd\call_error_duplicate_files jun jul
              } else {
                if (Test-Path claims_subfile_80_aug.sf)
                {
                                    &$env:cmd\call_error_duplicate_files jun aug
                } else {
                  if (Test-Path claims_subfile_80_sep.sf)
                  {
                                        &$env:cmd\call_error_duplicate_files jun sep
                  } else {
                    if (Test-Path claims_subfile_80_oct.sf)
                    {
                                            &$env:cmd\call_error_duplicate_files jun oct
                    } else {
                      if (Test-Path claims_subfile_80_nov.sf)
                      {
                                                &$env:cmd\call_error_duplicate_files jun nov
                      } else {
                        if (Test-Path claims_subfile_80_dec.sf)
                        {
                                                    &$env:cmd\call_error_duplicate_files jun dec
                        } else {
                                              &$env:cmd\call_backup_mthly_sub80 jun 2
                        }
                }
                }
                }
                }
        }
        }
#  else
#  [!ne [!path claims_subfile_80_yr.sf],]
#        [!ne [!path claims_subfile_80_jul.sf],]
#          $cmd/call_error_duplicate_files yr jul
#        else
#          [!ne [!path claims_subfile_80_aug.sf],]
#            $cmd/call_error_duplicate_files yr aug
#          else
#            [!ne [!path claims_subfile_80_sep.sf],]
#              $cmd/call_error_duplicate_files yr sep
#            else
#              [!ne [!path claims_subfile_80_oct.sf],]
#                $cmd/call_error_duplicate_files yr oct
#              else
#                [!ne [!path claims_subfile_80_nov.sf],]
#                  $cmd/call_error_duplicate_files yr nov
#                else
#                  [!ne [!path claims_subfile_80_dec.sf],]
#                    $cmd/call_error_duplicate_files yr dec
#                  else
#                          call_backup_mthly_sub80 yr 0
#                   fi
#                  fi
#                  fi
#            fi
#          fi
#        fi
} else {
if (Test-Path claims_subfile_80_jul.sf)
{
                if (Test-Path claims_subfile_80_aug.sf)
                {
                                    &$env:cmd\call_error_duplicate_files jul aug
                } else {
                  if (Test-Path claims_subfile_80_sep.sf)
                  {
                                        &$env:cmd\call_error_duplicate_files jul sep
                  } else {
                    if (Test-Path claims_subfile_80_oct.sf)
                    {
                                            &$env:cmd\call_error_duplicate_files jul oct
                    } else {
                      if (Test-Path claims_subfile_80_nov.sf)
                      {
                                                &$env:cmd\call_error_duplicate_files jul nov
                      } else {
                        if (Test-Path claims_subfile_80_dec.sf)
                        {
                                                    &$env:cmd\call_error_duplicate_files jul dec
                        } else {
                                                      &$env:cmd\call_backup_mthly_sub80 jul 3
                        }
                }
                }
                }
                }
} else {
if (Test-Path claims_subfile_80_aug.sf)
{
                  if (Test-Path claims_subfile_80_sep.sf)
                  {
                                        &$env:cmd\call_error_duplicate_files aug sep
                  } else {
                    if (Test-Path claims_subfile_80_oct.sf)
                    {
                                            &$env:cmd\call_error_duplicate_files aug oct
                    } else {
                      if (Test-Path claims_subfile_80_nov.sf)
                      {
                                                &$env:cmd\call_error_duplicate_files aug nov
                      } else {
                        if (Test-Path claims_subfile_80_dec.sf)
                        {
                                                    &$env:cmd\call_error_duplicate_files aug dec
                        } else {
                                                      &$env:cmd\call_backup_mthly_sub80 aug 4
                        }
                }
                }
                }
} else {
if (Test-Path claims_subfile_80_sep.sf)
{
                    if (Test-Path claims_subfile_80_oct.sf)
                    {
                                            &$env:cmd\call_error_duplicate_files sep oct
                    } else {
                      if (Test-Path claims_subfile_80_nov.sf)
                      {
                                                &$env:cmd\call_error_duplicate_files sep nov
                      } else {
                        if (Test-Path claims_subfile_80_dec.sf)
                        {
                                                    &$env:cmd\call_error_duplicate_files sep dec
                        } else {
                                                  &$env:cmd\call_backup_mthly_sub80 sep 5
                        }
                }
                }
} else {
if (Test-Path claims_subfile_80_oct.sf)
{
                      if (Test-Path claims_subfile_80_nov.sf)
                      {
                                                &$env:cmd\call_error_duplicate_files oct nov
                      } else {
                        if (Test-Path claims_subfile_80_dec.sf)
                        {
                                                    &$env:cmd\call_error_duplicate_files oct dec
                        } else {
                                          &$env:cmd\call_backup_mthly_sub80 oct 0
                        }
                }
} else {
if (Test-Path claims_subfile_80_nov.sf)
{
                        if (Test-Path claims_subfile_80_dec.sf)
                        {
                                                    &$env:cmd\call_error_duplicate_files nov dec
                        } else {
                                              &$env:cmd\call_backup_mthly_sub80 nov 1
                        }
} else {
if (Test-Path claims_subfile_80_dec.sf)
{
                                              &$env:cmd\call_backup_mthly_sub80 dec 2
} else {
if (Test-Path claims_subfile_80_jan.sf)
{
  if (Test-Path claims_subfile_80_feb.sf)
  {
        &$env:cmd\call_error_duplicate_files jan feb
  } else {
    if (Test-Path claims_subfile_80_mar.sf)
    {
            &$env:cmd\call_error_duplicate_files jan mar
    } else {
      if (Test-Path claims_subfile_80_apr.sf)
      {
                &$env:cmd\call_error_duplicate_files jan apr
      } else {
        if (Test-Path claims_subfile_80_may.sf)
        {
                    &$env:cmd\call_error_duplicate_files jan may
        } else {
          if (Test-Path claims_subfile_80_jun.sf)
          {
                        &$env:cmd\call_error_duplicate_files jan jun
          } else {
            if (Test-Path claims_subfile_80_yr.sf)
            {
                            &$env:cmd\call_error_duplicate_files jan yr
            } else {
              if (Test-Path claims_subfile_80_jul.sf)
              {
                                &$env:cmd\call_error_duplicate_files jan jul
              } else {
                if (Test-Path claims_subfile_80_aug.sf)
                {
                                    &$env:cmd\call_error_duplicate_files jan aug
                } else {
                  if (Test-Path claims_subfile_80_sep.sf)
                  {
                                        &$env:cmd\call_error_duplicate_files jan sep
                  } else {
                    if (Test-Path claims_subfile_80_oct.sf)
                    {
                                            &$env:cmd\call_error_duplicate_files jan oct
                    } else {
                      if (Test-Path claims_subfile_80_nov.sf)
                      {
                                                &$env:cmd\call_error_duplicate_files jan nov
                      } else {
                        if (Test-Path claims_subfile_80_dec.sf)
                        {
                                                    &$env:cmd\call_error_duplicate_files jan dec
                        } else {
                                                      &$env:cmd\call_backup_mthly_sub80 jan 3
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
if (Test-Path claims_subfile_80_feb.sf)
{
    if (Test-Path claims_subfile_80_mar.sf)
    {
            &$env:cmd\call_error_duplicate_files feb mar
    } else {
      if (Test-Path claims_subfile_80_apr.sf)
      {
                &$env:cmd\call_error_duplicate_files feb apr
      } else {
        if (Test-Path claims_subfile_80_may.sf)
        {
                    &$env:cmd\call_error_duplicate_files feb may
        } else {
          if (Test-Path claims_subfile_80_jun.sf)
          {
                        &$env:cmd\call_error_duplicate_files feb jun
          } else {
            if (Test-Path claims_subfile_80_yr.sf)
            {
                            &$env:cmd\call_error_duplicate_files feb yr
            } else {
              if (Test-Path claims_subfile_80_jul.sf)
              {
                                &$env:cmd\call_error_duplicate_files feb jul
              } else {
                if (Test-Path claims_subfile_80_aug.sf)
                {
                                    &$env:cmd\call_error_duplicate_files feb aug
                } else {
                  if (Test-Path claims_subfile_80_sep.sf)
                  {
                                        &$env:cmd\call_error_duplicate_files feb sep
                  } else {
                    if (Test-Path claims_subfile_80_oct.sf)
                    {
                                            &$env:cmd\call_error_duplicate_files feb oct
                    } else {
                      if (Test-Path claims_subfile_80_nov.sf)
                      {
                                                &$env:cmd\call_error_duplicate_files feb nov
                      } else {
                        if (Test-Path claims_subfile_80_dec.sf)
                        {
                                                    &$env:cmd\call_error_duplicate_files feb dec
                        } else {
                                              &$env:cmd\call_backup_mthly_sub80 feb 4
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
if (Test-Path claims_subfile_80_mar.sf)
{
      if (Test-Path claims_subfile_80_apr.sf)
      {
                &$env:cmd\call_error_duplicate_files mar apr
      } else {
        if (Test-Path claims_subfile_80_may.sf)
        {
                    &$env:cmd\call_error_duplicate_files mar may
        } else {
          if (Test-Path claims_subfile_80_jun.sf)
          {
                        &$env:cmd\call_error_duplicate_files mar jun
          } else {
            if (Test-Path claims_subfile_80_yr.sf)
            {
                            &$env:cmd\call_error_duplicate_files mar yr
            } else {
              if (Test-Path claims_subfile_80_jul.sf)
              {
                                &$env:cmd\call_error_duplicate_files mar jul
              } else {
                if (Test-Path claims_subfile_80_aug.sf)
                {
                                    &$env:cmd\call_error_duplicate_files mar aug
                } else {
                  if (Test-Path claims_subfile_80_sep.sf)
                  {
                                        &$env:cmd\call_error_duplicate_files mar sep
                  } else {
                    if (Test-Path claims_subfile_80_oct.sf)
                    {
                                            &$env:cmd\call_error_duplicate_files mar oct
                    } else {
                      if (Test-Path claims_subfile_80_nov.sf)
                      {
                                                &$env:cmd\call_error_duplicate_files mar nov
                      } else {
                        if (Test-Path claims_subfile_80_dec.sf)
                        {
                                                    &$env:cmd\call_error_duplicate_files mar dec
                        } else {
                                          &$env:cmd\call_backup_mthly_sub80 mar 5
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
