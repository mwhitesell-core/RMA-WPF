using System;
using System.Text;
using System.Windows;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.ExceptionManagement;
using Core.Windows.UI.Core.Windows;
using Core.Windows.UI.Core.Windows.UI;
using System.Data.SqlClient;

namespace rma.Views
{
    /// <summary>
    /// Interaction logic for TestTemplate.xaml
    /// </summary>
    partial class TestTemplate : BasePage
    {
        
        private CoreInteger W_EP_NBR_FROM;
        private CoreCharacter W_EP_NBR_TO;
        private CoreInteger temp;

        public TestTemplate()
        {
            base.LoadBase();
            InitializeComponent();
            Loaded += Page_Load;
            this.Initialized += TestTemplate_Initialized;            

            this.FormName = "TestTemplate";

            //# Set the ACTIVITIES for the screen.
            this.ChangeActivity = true;
            this.FindActivity = true;
            this.DeleteActivity = false;
            this.EntryActivity = true;
            this.UseAcceptProcessing = true;
            this.HasPathRequestFields = true;
        }

        protected override bool Initialize()
        {
           /* try
             {
                 string temp = "1";
                 Accept(ref fldW_EP_NBR_FROM);

                 if (W_EP_NBR_FROM.Value == 12)
                 {
                     Accept(ref fldW_EP_NBR_TO);
                 }

                 return true;
             }
             catch (CustomApplicationException ex)
             {
                 throw ex;
             }
             catch (Exception ex)
             {
                 ExceptionManager.Publish(ex);
                 throw ex;
             }    */
            return true; 
        }


        protected override bool Entry() //MainLine()
        {
            try
            {
                temp.Value += 1;
                Accept(ref fldW_EP_NBR_FROM);
               

                if (W_EP_NBR_FROM.Value == 12)
                {
                    Accept(ref fldW_EP_NBR_TO);
                }
                //Display (ref temp);           
                return true;
            }
            catch (CustomApplicationException ex)
            {
                 throw ex;
                //string error = ex.Message;
                //return true;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            
            }
            
        }

        private void TestTemplate_Initialized(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            string temp = "";
        }

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            SetVariables();
            base.Page_Load();
           // MainLine();
        }

        protected override void SetVariables()
        {
            //fleF020_DOCTOR_EXTRA = new SqlFileObject(this, FileTypes.Secondary, 0, "INDEXED", "F020_DOCTOR_EXTRA", "", false, false, false, 0, "m_trnTRANS_UPDATE");

            W_EP_NBR_FROM = new CoreInteger("W_EP_NBR_FROM", 4, this);
            W_EP_NBR_TO = new CoreCharacter("W_EP_NBR_TO", 20, this,"HelloWorld");
            temp = new CoreInteger("TEMP", 4, this);
        }

        public override void BindFields()
        {
            try
            {
                fldW_EP_NBR_FROM.Bind(W_EP_NBR_FROM);
                fldW_EP_NBR_TO.Bind(W_EP_NBR_TO);
                fldTEMP.Bind(temp);

            }
            catch (CustomApplicationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }
        }

        /*protected override bool Entry()
        {

            try
            {
                string temp = "1";
                Accept(ref fldW_EP_NBR_FROM);

                if (W_EP_NBR_FROM.Value == 12)
                {
                    Accept(ref fldW_EP_NBR_TO);
                }

                return true;
            }
            catch (CustomApplicationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            } 
            return true;
        } */


       
    }
}
