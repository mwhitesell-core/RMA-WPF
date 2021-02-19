
using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;
using rma.Cobol.Reports;


public class R153A : BaseClassControl
{

    private R153a m_R153a;

    public R153A(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public R153A(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
    }

    public R153a GetR120(int Level)
    {
        if (m_R153a == null)
        {
            m_R153a = new R153a("R153a", Level);
        }
        else
        {
            //m_R123b.ResetValues();
        }
        return m_R153a;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.


    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

    public override bool RunQTP()
    {

        try
        {
            R153a r153a = null;
            r153a = new R153a(Name, Level);            

            r153a.MainLine(wsSundry: Prompt(1).ToString(),
                        wsVersionNbr: Convert.ToInt32(Prompt(2)),
                        wsTapeYr: Convert.ToInt32(Prompt(3)),
                        wsTapeDay: Convert.ToInt32(Prompt(4)),
                        wsFundYr: Convert.ToInt32(Prompt(5)),
                        wsFundDay: Convert.ToInt32(Prompt(6)),
                        dateCheckOption: Prompt(7).ToString(),
                        yearEndOption: Prompt(8).ToString(),
                        yearEndLabel: Prompt(9).ToString(),
                        selClinic: Prompt(10).ToString(),
                        wsChqYr: Convert.ToInt32(Prompt(11)),
                        wsChqMth: Convert.ToInt32(Prompt(12)),
                        wsChqDay: Convert.ToInt32(Prompt(13)),
                        selOK: Prompt(14).ToString());

            r153a = null;
            return true;
        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);
            return false;
        }
        catch (Exception ex)
        {
            WriteError(ex);
            return false;

        }

    }







    #endregion

    #endregion

}



