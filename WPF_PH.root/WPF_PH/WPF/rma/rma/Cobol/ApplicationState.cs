
using System.Configuration;
using System.IO;
using System.Windows;

namespace rma.Cobol
{
    public sealed class ApplicationState
    {
        #region Singleton Behavior

        private static ApplicationState _current;

        public static ApplicationState Current
        {
            get { return _current ?? (_current = new ApplicationState()); }
            internal set { _current = value; }
        }

        #endregion
        
        private string _dateFormat = ConfigurationManager.AppSettings["DateFormat"];
        private int _lastAddedConstituent = -1;

        /// <summary>
        /// Used the define the mode that the screen is in
        /// </summary>      

        private string _tempDir;

        private string _userName = string.Empty;

        public string DateFormat
        {
            get { return _dateFormat; }
            set
            {
                lock (_dateFormat)
                {
                    _dateFormat = value;
                }
            }
        }

        public string TempDir
        {
            get
            {
                if (_tempDir == null)
                {
                    _tempDir = Path.GetTempPath() + "Rmaapp\\";
                    if (!Directory.Exists(_tempDir))
                        Directory.CreateDirectory(_tempDir);
                }
                return _tempDir;
            }
        }
       
        public string UserName
        {
            get { return _userName; }
            set
            {
                lock (_userName)
                {
                    _userName = value;
                }
            }
        }
       
        public string UserNameWithoutDomain
        {
            get { return _userName.Substring(_userName.LastIndexOf("\\") + 1); }
        }

        public double MainX { get; set; }
        public double MainY { get; set; }

        public double MainHeight { get; set; }
        public double MainWidth { get; set; }

        public string Keys { get; set; }
        

        public int LastAddedConstituent
        {
            get { return _lastAddedConstituent; }
            set { _lastAddedConstituent = value; }
        }

        public string Filter { get; set; }
        public bool HasError { get; set; }
        public string FieldNameError { get; set; }
        public bool UndoHasFocus { get; set; }

        public object CurrentViewmodel { get; set; }

        public Window CurrentScreen { get; set; }
        public Window PreviousCurrentScreen { get; set; }
        public bool IsProcessing { get; set; }

        //Global Variables
       

       

        public string RctOut { get; set; }
        public string LdaBille { get; set; }
        public string TextFile { get; set; }
        public string Xmlfile { get; set; }
        public string PoolNum { get; set; }

        public string ADDEND { get; set; }
        public string ADDINSURED { get; set; }
        public string INSTALLMENT { get; set; }
        public string DATETIMESTAMP { get; set; }


        public string CUST_NAME { get; set; }
        public string PCODE { get; set; }
        public string PREVEX1 { get; set; }
        public string PREVEX2 { get; set; }
        public string PREVEX3 { get; set; }
        public string ACCOUNT { get; set; }

        #region Shared Variables between computes

        /// <summary>
        /// these variables are shared between 2 classes(COMPUTES) RATECOV1 and RATECOV2
        /// </summary>
        public decimal COUNT_COV { get; set; }

        public string[] COV_ARRAY { get; set; }
        public string CURR_COV { get; set; }
        public decimal CURR_QT_ID { get; set; }
        public string CURR_QT_ID_COV { get; set; }
        public string NEW_QT_ID_COV { get; set; }
        public string[] PARA_SELECT { get; set; }
        public string[] PARA_TYPE { get; set; }
        public string[] PARA_DESC { get; set; }
        public string[] TYPE_ARRAY { get; set; }
        public string POLKEY { get; set; }

        public string RECVALUE { get; set; }
        public string RECTYPE { get; set; }

        public int LAYER_NO { get; set; }

        /// <summary>
        /// these variable are shared between reports
        /// </summary>
        public string PARA_TYPE2 { get; set; }

        public int PARA_KEY { get; set; }
        public string NAME { get; set; }
        public string NAME1 { get; set; }
        public string NAME2 { get; set; }
        public string SEQUENCENUM { get; set; }
        public string SYNC_BYTE { get; set; }

        #endregion

        #region HPVariables

        private string _NLUSERLANG;
        public string UWDEPT { get; set; }
        public string ONLYONECOV { get; set; }
        public string GENPATH { get; set; }
        public string GLRATEXS { get; set; }
        public string PHANTOM { get; set; }
        public string GLRATEFLOW { get; set; }

        public string STOPREJECT { get; set; }
        public string PROCEED { get; set; }
        public string COVPL { get; set; }
        public string COVGL { get; set; }
        public string COVBR { get; set; }
        public string COVWU { get; set; }
        public string COVCG { get; set; }
        public string COVEO { get; set; }
        public string COVED { get; set; }
        public string COVPO { get; set; }
        public string COVFB { get; set; }
        public string COVDO { get; set; }
        public string COVFD { get; set; }
        public string COVXS { get; set; }
        public string COVXD { get; set; }
        public string COVXE { get; set; }
        public string COVXF { get; set; }
        public string COVEP { get; set; }
        public string COVPP { get; set; }
        public string COVAP { get; set; }
        public string DEPTAE { get; set; }
        public string DEPTSRD { get; set; }
        public string DEPTCOIN { get; set; }
        public string DEPTDO { get; set; }

        public string NLUSERLANG
        {
            get { return _NLUSERLANG; }
            set
            {
                _NLUSERLANG = value;
                if (value == "1")
                    USERLANG = "1";
            }
        }

        public string USERLANG { get; set; }
        public string COMPONENT { get; set; }
        public string COMPONENT1 { get; set; }
        public string COMPONENT2 { get; set; }
        public string OROPTION { get; set; }
        public string EDITFILEOPTION { get; set; }
        public string NOQTEND { get; set; }
        public string FMCART { get; set; }
        public string EMAIL { get; set; }
        public string SPECIMEN { get; set; }
        public string HPENV { get; set; }
        public string SELECTALL { get; set; }
        public string UNSELECTALL { get; set; }
        public string WHICHCOV { get; set; }
        public string LASTCOV { get; set; }
        public string REPRINT { get; set; }
        public string ENDLOOP { get; set; }
        public string BARCODE { get; set; }
        public bool DecBodyForceSave { get; set; }

        public bool FirstKeyWordHit { get; set; }

       

      

        #endregion
       
       
    }
}
