using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F030_LOCATIONS_MSTR : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F030_LOCATIONS_MSTR> Collection( Guid? rowid,
															string loc_nbr,
															decimal? loc_clinic_nbrmin,
															decimal? loc_clinic_nbrmax,
															decimal? loc_hospital_nbrmin,
															decimal? loc_hospital_nbrmax,
															string loc_hospital_code,
															string loc_card_colour,
															string loc_name,
															decimal? loc_ministry_loc_codemin,
															decimal? loc_ministry_loc_codemax,
															string loc_payroll_flag,
															string loc_active_for_entry,
															string loc_service_location_indicator,
															string loc_filler_1,
															int? checksum_valuemin,
															int? checksum_valuemax,
                                                            string sortcolumn,
                                                            string sortdirection,
                                                            bool replaceSearch,
                                                            int skip)
        {
            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",rowid),
					new SqlParameter("LOC_NBR",loc_nbr),
					new SqlParameter("minLOC_CLINIC_NBR",loc_clinic_nbrmin),
					new SqlParameter("maxLOC_CLINIC_NBR",loc_clinic_nbrmax),
					new SqlParameter("minLOC_HOSPITAL_NBR",loc_hospital_nbrmin),
					new SqlParameter("maxLOC_HOSPITAL_NBR",loc_hospital_nbrmax),
					new SqlParameter("LOC_HOSPITAL_CODE",loc_hospital_code),
					new SqlParameter("LOC_CARD_COLOUR",loc_card_colour),
					new SqlParameter("LOC_NAME",loc_name),
					new SqlParameter("minLOC_MINISTRY_LOC_CODE",loc_ministry_loc_codemin),
					new SqlParameter("maxLOC_MINISTRY_LOC_CODE",loc_ministry_loc_codemax),
					new SqlParameter("LOC_PAYROLL_FLAG",loc_payroll_flag),
					new SqlParameter("LOC_ACTIVE_FOR_ENTRY",loc_active_for_entry),
					new SqlParameter("LOC_SERVICE_LOCATION_INDICATOR",loc_service_location_indicator),
					new SqlParameter("LOC_FILLER_1",loc_filler_1),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F030_LOCATIONS_MSTR_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F030_LOCATIONS_MSTR>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F030_LOCATIONS_MSTR_Search]", parameters);
            var collection = new ObservableCollection<F030_LOCATIONS_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F030_LOCATIONS_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					LOC_NBR = Reader["LOC_NBR"].ToString(),
					LOC_CLINIC_NBR = ConvertDEC(Reader["LOC_CLINIC_NBR"]),
					LOC_HOSPITAL_NBR = ConvertDEC(Reader["LOC_HOSPITAL_NBR"]),
					LOC_HOSPITAL_CODE = Reader["LOC_HOSPITAL_CODE"].ToString(),
					LOC_CARD_COLOUR = Reader["LOC_CARD_COLOUR"].ToString(),
					LOC_NAME = Reader["LOC_NAME"].ToString(),
					LOC_MINISTRY_LOC_CODE = ConvertDEC(Reader["LOC_MINISTRY_LOC_CODE"]),
					LOC_PAYROLL_FLAG = Reader["LOC_PAYROLL_FLAG"].ToString(),
					LOC_ACTIVE_FOR_ENTRY = Reader["LOC_ACTIVE_FOR_ENTRY"].ToString(),
					LOC_SERVICE_LOCATION_INDICATOR = Reader["LOC_SERVICE_LOCATION_INDICATOR"].ToString(),
					LOC_FILLER_1 = Reader["LOC_FILLER_1"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalLoc_nbr = Reader["LOC_NBR"].ToString(),
					_originalLoc_clinic_nbr = ConvertDEC(Reader["LOC_CLINIC_NBR"]),
					_originalLoc_hospital_nbr = ConvertDEC(Reader["LOC_HOSPITAL_NBR"]),
					_originalLoc_hospital_code = Reader["LOC_HOSPITAL_CODE"].ToString(),
					_originalLoc_card_colour = Reader["LOC_CARD_COLOUR"].ToString(),
					_originalLoc_name = Reader["LOC_NAME"].ToString(),
					_originalLoc_ministry_loc_code = ConvertDEC(Reader["LOC_MINISTRY_LOC_CODE"]),
					_originalLoc_payroll_flag = Reader["LOC_PAYROLL_FLAG"].ToString(),
					_originalLoc_active_for_entry = Reader["LOC_ACTIVE_FOR_ENTRY"].ToString(),
					_originalLoc_service_location_indicator = Reader["LOC_SERVICE_LOCATION_INDICATOR"].ToString(),
					_originalLoc_filler_1 = Reader["LOC_FILLER_1"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F030_LOCATIONS_MSTR Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F030_LOCATIONS_MSTR> Collection(ObservableCollection<F030_LOCATIONS_MSTR>
                                                               f030LocationsMstr = null)
        {
            if (IsSameSearch() && f030LocationsMstr != null)
            {
                return f030LocationsMstr;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F030_LOCATIONS_MSTR>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("LOC_NBR",WhereLoc_nbr),
					new SqlParameter("LOC_CLINIC_NBR",WhereLoc_clinic_nbr),
					new SqlParameter("LOC_HOSPITAL_NBR",WhereLoc_hospital_nbr),
					new SqlParameter("LOC_HOSPITAL_CODE",WhereLoc_hospital_code),
					new SqlParameter("LOC_CARD_COLOUR",WhereLoc_card_colour),
					new SqlParameter("LOC_NAME",WhereLoc_name),
					new SqlParameter("LOC_MINISTRY_LOC_CODE",WhereLoc_ministry_loc_code),
					new SqlParameter("LOC_PAYROLL_FLAG",WhereLoc_payroll_flag),
					new SqlParameter("LOC_ACTIVE_FOR_ENTRY",WhereLoc_active_for_entry),
					new SqlParameter("LOC_SERVICE_LOCATION_INDICATOR",WhereLoc_service_location_indicator),
					new SqlParameter("LOC_FILLER_1",WhereLoc_filler_1),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F030_LOCATIONS_MSTR_Match]", parameters);
            var collection = new ObservableCollection<F030_LOCATIONS_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F030_LOCATIONS_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					LOC_NBR = Reader["LOC_NBR"].ToString(),
					LOC_CLINIC_NBR = ConvertDEC(Reader["LOC_CLINIC_NBR"]),
					LOC_HOSPITAL_NBR = ConvertDEC(Reader["LOC_HOSPITAL_NBR"]),
					LOC_HOSPITAL_CODE = Reader["LOC_HOSPITAL_CODE"].ToString(),
					LOC_CARD_COLOUR = Reader["LOC_CARD_COLOUR"].ToString(),
					LOC_NAME = Reader["LOC_NAME"].ToString(),
					LOC_MINISTRY_LOC_CODE = ConvertDEC(Reader["LOC_MINISTRY_LOC_CODE"]),
					LOC_PAYROLL_FLAG = Reader["LOC_PAYROLL_FLAG"].ToString(),
					LOC_ACTIVE_FOR_ENTRY = Reader["LOC_ACTIVE_FOR_ENTRY"].ToString(),
					LOC_SERVICE_LOCATION_INDICATOR = Reader["LOC_SERVICE_LOCATION_INDICATOR"].ToString(),
					LOC_FILLER_1 = Reader["LOC_FILLER_1"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereLoc_nbr = WhereLoc_nbr,
					_whereLoc_clinic_nbr = WhereLoc_clinic_nbr,
					_whereLoc_hospital_nbr = WhereLoc_hospital_nbr,
					_whereLoc_hospital_code = WhereLoc_hospital_code,
					_whereLoc_card_colour = WhereLoc_card_colour,
					_whereLoc_name = WhereLoc_name,
					_whereLoc_ministry_loc_code = WhereLoc_ministry_loc_code,
					_whereLoc_payroll_flag = WhereLoc_payroll_flag,
					_whereLoc_active_for_entry = WhereLoc_active_for_entry,
					_whereLoc_service_location_indicator = WhereLoc_service_location_indicator,
					_whereLoc_filler_1 = WhereLoc_filler_1,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalLoc_nbr = Reader["LOC_NBR"].ToString(),
					_originalLoc_clinic_nbr = ConvertDEC(Reader["LOC_CLINIC_NBR"]),
					_originalLoc_hospital_nbr = ConvertDEC(Reader["LOC_HOSPITAL_NBR"]),
					_originalLoc_hospital_code = Reader["LOC_HOSPITAL_CODE"].ToString(),
					_originalLoc_card_colour = Reader["LOC_CARD_COLOUR"].ToString(),
					_originalLoc_name = Reader["LOC_NAME"].ToString(),
					_originalLoc_ministry_loc_code = ConvertDEC(Reader["LOC_MINISTRY_LOC_CODE"]),
					_originalLoc_payroll_flag = Reader["LOC_PAYROLL_FLAG"].ToString(),
					_originalLoc_active_for_entry = Reader["LOC_ACTIVE_FOR_ENTRY"].ToString(),
					_originalLoc_service_location_indicator = Reader["LOC_SERVICE_LOCATION_INDICATOR"].ToString(),
					_originalLoc_filler_1 = Reader["LOC_FILLER_1"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereLoc_nbr = WhereLoc_nbr;
					_whereLoc_clinic_nbr = WhereLoc_clinic_nbr;
					_whereLoc_hospital_nbr = WhereLoc_hospital_nbr;
					_whereLoc_hospital_code = WhereLoc_hospital_code;
					_whereLoc_card_colour = WhereLoc_card_colour;
					_whereLoc_name = WhereLoc_name;
					_whereLoc_ministry_loc_code = WhereLoc_ministry_loc_code;
					_whereLoc_payroll_flag = WhereLoc_payroll_flag;
					_whereLoc_active_for_entry = WhereLoc_active_for_entry;
					_whereLoc_service_location_indicator = WhereLoc_service_location_indicator;
					_whereLoc_filler_1 = WhereLoc_filler_1;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereLoc_nbr == null 
				&& WhereLoc_clinic_nbr == null 
				&& WhereLoc_hospital_nbr == null 
				&& WhereLoc_hospital_code == null 
				&& WhereLoc_card_colour == null 
				&& WhereLoc_name == null 
				&& WhereLoc_ministry_loc_code == null 
				&& WhereLoc_payroll_flag == null 
				&& WhereLoc_active_for_entry == null 
				&& WhereLoc_service_location_indicator == null 
				&& WhereLoc_filler_1 == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereLoc_nbr ==  _whereLoc_nbr
				&& WhereLoc_clinic_nbr ==  _whereLoc_clinic_nbr
				&& WhereLoc_hospital_nbr ==  _whereLoc_hospital_nbr
				&& WhereLoc_hospital_code ==  _whereLoc_hospital_code
				&& WhereLoc_card_colour ==  _whereLoc_card_colour
				&& WhereLoc_name ==  _whereLoc_name
				&& WhereLoc_ministry_loc_code ==  _whereLoc_ministry_loc_code
				&& WhereLoc_payroll_flag ==  _whereLoc_payroll_flag
				&& WhereLoc_active_for_entry ==  _whereLoc_active_for_entry
				&& WhereLoc_service_location_indicator ==  _whereLoc_service_location_indicator
				&& WhereLoc_filler_1 ==  _whereLoc_filler_1
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereLoc_nbr = null; 
			WhereLoc_clinic_nbr = null; 
			WhereLoc_hospital_nbr = null; 
			WhereLoc_hospital_code = null; 
			WhereLoc_card_colour = null; 
			WhereLoc_name = null; 
			WhereLoc_ministry_loc_code = null; 
			WhereLoc_payroll_flag = null; 
			WhereLoc_active_for_entry = null; 
			WhereLoc_service_location_indicator = null; 
			WhereLoc_filler_1 = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _LOC_NBR;
		private decimal? _LOC_CLINIC_NBR;
		private decimal? _LOC_HOSPITAL_NBR;
		private string _LOC_HOSPITAL_CODE;
		private string _LOC_CARD_COLOUR;
		private string _LOC_NAME;
		private decimal? _LOC_MINISTRY_LOC_CODE;
		private string _LOC_PAYROLL_FLAG;
		private string _LOC_ACTIVE_FOR_ENTRY;
		private string _LOC_SERVICE_LOCATION_INDICATOR;
		private string _LOC_FILLER_1;
		private int? _CHECKSUM_VALUE;

		public Guid ROWID
		{
			get { return _ROWID; }
			set
			{
				if (_ROWID != value)
				{
					_ROWID = value;
					ChangeState();
				}
			}
		}
		public string LOC_NBR
		{
			get { return _LOC_NBR; }
			set
			{
				if (_LOC_NBR != value)
				{
					_LOC_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? LOC_CLINIC_NBR
		{
			get { return _LOC_CLINIC_NBR; }
			set
			{
				if (_LOC_CLINIC_NBR != value)
				{
					_LOC_CLINIC_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? LOC_HOSPITAL_NBR
		{
			get { return _LOC_HOSPITAL_NBR; }
			set
			{
				if (_LOC_HOSPITAL_NBR != value)
				{
					_LOC_HOSPITAL_NBR = value;
					ChangeState();
				}
			}
		}
		public string LOC_HOSPITAL_CODE
		{
			get { return _LOC_HOSPITAL_CODE; }
			set
			{
				if (_LOC_HOSPITAL_CODE != value)
				{
					_LOC_HOSPITAL_CODE = value;
					ChangeState();
				}
			}
		}
		public string LOC_CARD_COLOUR
		{
			get { return _LOC_CARD_COLOUR; }
			set
			{
				if (_LOC_CARD_COLOUR != value)
				{
					_LOC_CARD_COLOUR = value;
					ChangeState();
				}
			}
		}
		public string LOC_NAME
		{
			get { return _LOC_NAME; }
			set
			{
				if (_LOC_NAME != value)
				{
					_LOC_NAME = value;
					ChangeState();
				}
			}
		}
		public decimal? LOC_MINISTRY_LOC_CODE
		{
			get { return _LOC_MINISTRY_LOC_CODE; }
			set
			{
				if (_LOC_MINISTRY_LOC_CODE != value)
				{
					_LOC_MINISTRY_LOC_CODE = value;
					ChangeState();
				}
			}
		}
		public string LOC_PAYROLL_FLAG
		{
			get { return _LOC_PAYROLL_FLAG; }
			set
			{
				if (_LOC_PAYROLL_FLAG != value)
				{
					_LOC_PAYROLL_FLAG = value;
					ChangeState();
				}
			}
		}
		public string LOC_ACTIVE_FOR_ENTRY
		{
			get { return _LOC_ACTIVE_FOR_ENTRY; }
			set
			{
				if (_LOC_ACTIVE_FOR_ENTRY != value)
				{
					_LOC_ACTIVE_FOR_ENTRY = value;
					ChangeState();
				}
			}
		}
		public string LOC_SERVICE_LOCATION_INDICATOR
		{
			get { return _LOC_SERVICE_LOCATION_INDICATOR; }
			set
			{
				if (_LOC_SERVICE_LOCATION_INDICATOR != value)
				{
					_LOC_SERVICE_LOCATION_INDICATOR = value;
					ChangeState();
				}
			}
		}
		public string LOC_FILLER_1
		{
			get { return _LOC_FILLER_1; }
			set
			{
				if (_LOC_FILLER_1 != value)
				{
					_LOC_FILLER_1 = value;
					ChangeState();
				}
			}
		}
		public int? CHECKSUM_VALUE
		{
			get { return _CHECKSUM_VALUE; }
			set
			{
				if (_CHECKSUM_VALUE != value)
				{
					_CHECKSUM_VALUE = value;
					ChangeState();
				}
			}
		}


        #endregion

        #region Where

		public Guid? WhereRowid { get; set; }
		private Guid? _whereRowid;
		public string WhereLoc_nbr { get; set; }
		private string _whereLoc_nbr;
		public decimal? WhereLoc_clinic_nbr { get; set; }
		private decimal? _whereLoc_clinic_nbr;
		public decimal? WhereLoc_hospital_nbr { get; set; }
		private decimal? _whereLoc_hospital_nbr;
		public string WhereLoc_hospital_code { get; set; }
		private string _whereLoc_hospital_code;
		public string WhereLoc_card_colour { get; set; }
		private string _whereLoc_card_colour;
		public string WhereLoc_name { get; set; }
		private string _whereLoc_name;
		public decimal? WhereLoc_ministry_loc_code { get; set; }
		private decimal? _whereLoc_ministry_loc_code;
		public string WhereLoc_payroll_flag { get; set; }
		private string _whereLoc_payroll_flag;
		public string WhereLoc_active_for_entry { get; set; }
		private string _whereLoc_active_for_entry;
		public string WhereLoc_service_location_indicator { get; set; }
		private string _whereLoc_service_location_indicator;
		public string WhereLoc_filler_1 { get; set; }
		private string _whereLoc_filler_1;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalLoc_nbr;
		private decimal? _originalLoc_clinic_nbr;
		private decimal? _originalLoc_hospital_nbr;
		private string _originalLoc_hospital_code;
		private string _originalLoc_card_colour;
		private string _originalLoc_name;
		private decimal? _originalLoc_ministry_loc_code;
		private string _originalLoc_payroll_flag;
		private string _originalLoc_active_for_entry;
		private string _originalLoc_service_location_indicator;
		private string _originalLoc_filler_1;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			LOC_NBR = _originalLoc_nbr;
			LOC_CLINIC_NBR = _originalLoc_clinic_nbr;
			LOC_HOSPITAL_NBR = _originalLoc_hospital_nbr;
			LOC_HOSPITAL_CODE = _originalLoc_hospital_code;
			LOC_CARD_COLOUR = _originalLoc_card_colour;
			LOC_NAME = _originalLoc_name;
			LOC_MINISTRY_LOC_CODE = _originalLoc_ministry_loc_code;
			LOC_PAYROLL_FLAG = _originalLoc_payroll_flag;
			LOC_ACTIVE_FOR_ENTRY = _originalLoc_active_for_entry;
			LOC_SERVICE_LOCATION_INDICATOR = _originalLoc_service_location_indicator;
			LOC_FILLER_1 = _originalLoc_filler_1;
			CHECKSUM_VALUE = _originalChecksum_value;

            RecordState = State.UnChanged;

            return true;
        }


        public bool Delete()
        {
			int RowsAffected = 0;
			var parameters = new SqlParameter[]
				{
					new SqlParameter("RowCheckSum",RowCheckSum),
					new SqlParameter("ROWID",ROWID),
					new SqlParameter("LOC_NBR",LOC_NBR)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F030_LOCATIONS_MSTR_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F030_LOCATIONS_MSTR_Purge]");
		    CloseConnection();
		    return true;
		}


        #endregion

        #region Submit

        public void Submit()
        {
            int RowsAffected = 0;
            SqlParameter[] parameters; 
            switch (RecordState)
            {
                case State.Adding:
                case State.Added:
					parameters = new SqlParameter[]
					{
						new SqlParameter("LOC_NBR", SqlNull(LOC_NBR)),
						new SqlParameter("LOC_CLINIC_NBR", SqlNull(LOC_CLINIC_NBR)),
						new SqlParameter("LOC_HOSPITAL_NBR", SqlNull(LOC_HOSPITAL_NBR)),
						new SqlParameter("LOC_HOSPITAL_CODE", SqlNull(LOC_HOSPITAL_CODE)),
						new SqlParameter("LOC_CARD_COLOUR", SqlNull(LOC_CARD_COLOUR)),
						new SqlParameter("LOC_NAME", SqlNull(LOC_NAME)),
						new SqlParameter("LOC_MINISTRY_LOC_CODE", SqlNull(LOC_MINISTRY_LOC_CODE)),
						new SqlParameter("LOC_PAYROLL_FLAG", SqlNull(LOC_PAYROLL_FLAG)),
						new SqlParameter("LOC_ACTIVE_FOR_ENTRY", SqlNull(LOC_ACTIVE_FOR_ENTRY)),
						new SqlParameter("LOC_SERVICE_LOCATION_INDICATOR", SqlNull(LOC_SERVICE_LOCATION_INDICATOR)),
						new SqlParameter("LOC_FILLER_1", SqlNull(LOC_FILLER_1)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F030_LOCATIONS_MSTR_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						LOC_NBR = Reader["LOC_NBR"].ToString();
						LOC_CLINIC_NBR = ConvertDEC(Reader["LOC_CLINIC_NBR"]);
						LOC_HOSPITAL_NBR = ConvertDEC(Reader["LOC_HOSPITAL_NBR"]);
						LOC_HOSPITAL_CODE = Reader["LOC_HOSPITAL_CODE"].ToString();
						LOC_CARD_COLOUR = Reader["LOC_CARD_COLOUR"].ToString();
						LOC_NAME = Reader["LOC_NAME"].ToString();
						LOC_MINISTRY_LOC_CODE = ConvertDEC(Reader["LOC_MINISTRY_LOC_CODE"]);
						LOC_PAYROLL_FLAG = Reader["LOC_PAYROLL_FLAG"].ToString();
						LOC_ACTIVE_FOR_ENTRY = Reader["LOC_ACTIVE_FOR_ENTRY"].ToString();
						LOC_SERVICE_LOCATION_INDICATOR = Reader["LOC_SERVICE_LOCATION_INDICATOR"].ToString();
						LOC_FILLER_1 = Reader["LOC_FILLER_1"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalLoc_nbr = Reader["LOC_NBR"].ToString();
						_originalLoc_clinic_nbr = ConvertDEC(Reader["LOC_CLINIC_NBR"]);
						_originalLoc_hospital_nbr = ConvertDEC(Reader["LOC_HOSPITAL_NBR"]);
						_originalLoc_hospital_code = Reader["LOC_HOSPITAL_CODE"].ToString();
						_originalLoc_card_colour = Reader["LOC_CARD_COLOUR"].ToString();
						_originalLoc_name = Reader["LOC_NAME"].ToString();
						_originalLoc_ministry_loc_code = ConvertDEC(Reader["LOC_MINISTRY_LOC_CODE"]);
						_originalLoc_payroll_flag = Reader["LOC_PAYROLL_FLAG"].ToString();
						_originalLoc_active_for_entry = Reader["LOC_ACTIVE_FOR_ENTRY"].ToString();
						_originalLoc_service_location_indicator = Reader["LOC_SERVICE_LOCATION_INDICATOR"].ToString();
						_originalLoc_filler_1 = Reader["LOC_FILLER_1"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("LOC_NBR", SqlNull(LOC_NBR)),
						new SqlParameter("LOC_CLINIC_NBR", SqlNull(LOC_CLINIC_NBR)),
						new SqlParameter("LOC_HOSPITAL_NBR", SqlNull(LOC_HOSPITAL_NBR)),
						new SqlParameter("LOC_HOSPITAL_CODE", SqlNull(LOC_HOSPITAL_CODE)),
						new SqlParameter("LOC_CARD_COLOUR", SqlNull(LOC_CARD_COLOUR)),
						new SqlParameter("LOC_NAME", SqlNull(LOC_NAME)),
						new SqlParameter("LOC_MINISTRY_LOC_CODE", SqlNull(LOC_MINISTRY_LOC_CODE)),
						new SqlParameter("LOC_PAYROLL_FLAG", SqlNull(LOC_PAYROLL_FLAG)),
						new SqlParameter("LOC_ACTIVE_FOR_ENTRY", SqlNull(LOC_ACTIVE_FOR_ENTRY)),
						new SqlParameter("LOC_SERVICE_LOCATION_INDICATOR", SqlNull(LOC_SERVICE_LOCATION_INDICATOR)),
						new SqlParameter("LOC_FILLER_1", SqlNull(LOC_FILLER_1)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F030_LOCATIONS_MSTR_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						LOC_NBR = Reader["LOC_NBR"].ToString();
						LOC_CLINIC_NBR = ConvertDEC(Reader["LOC_CLINIC_NBR"]);
						LOC_HOSPITAL_NBR = ConvertDEC(Reader["LOC_HOSPITAL_NBR"]);
						LOC_HOSPITAL_CODE = Reader["LOC_HOSPITAL_CODE"].ToString();
						LOC_CARD_COLOUR = Reader["LOC_CARD_COLOUR"].ToString();
						LOC_NAME = Reader["LOC_NAME"].ToString();
						LOC_MINISTRY_LOC_CODE = ConvertDEC(Reader["LOC_MINISTRY_LOC_CODE"]);
						LOC_PAYROLL_FLAG = Reader["LOC_PAYROLL_FLAG"].ToString();
						LOC_ACTIVE_FOR_ENTRY = Reader["LOC_ACTIVE_FOR_ENTRY"].ToString();
						LOC_SERVICE_LOCATION_INDICATOR = Reader["LOC_SERVICE_LOCATION_INDICATOR"].ToString();
						LOC_FILLER_1 = Reader["LOC_FILLER_1"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalLoc_nbr = Reader["LOC_NBR"].ToString();
						_originalLoc_clinic_nbr = ConvertDEC(Reader["LOC_CLINIC_NBR"]);
						_originalLoc_hospital_nbr = ConvertDEC(Reader["LOC_HOSPITAL_NBR"]);
						_originalLoc_hospital_code = Reader["LOC_HOSPITAL_CODE"].ToString();
						_originalLoc_card_colour = Reader["LOC_CARD_COLOUR"].ToString();
						_originalLoc_name = Reader["LOC_NAME"].ToString();
						_originalLoc_ministry_loc_code = ConvertDEC(Reader["LOC_MINISTRY_LOC_CODE"]);
						_originalLoc_payroll_flag = Reader["LOC_PAYROLL_FLAG"].ToString();
						_originalLoc_active_for_entry = Reader["LOC_ACTIVE_FOR_ENTRY"].ToString();
						_originalLoc_service_location_indicator = Reader["LOC_SERVICE_LOCATION_INDICATOR"].ToString();
						_originalLoc_filler_1 = Reader["LOC_FILLER_1"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                   
                    break;
            }
	    CloseConnection();
	     
            RecordState = State.UnChanged;
        }

        #endregion

      
    }
}