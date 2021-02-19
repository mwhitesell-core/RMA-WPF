using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class TMP_DOCTOR_ALPHA : BaseTable
    {
        #region Retrieve

        public ObservableCollection<TMP_DOCTOR_ALPHA> Collection( Guid? rowid,
															decimal? doc_ohip_nbrmin,
															decimal? doc_ohip_nbrmax,
															string doc_nbr,
															string tmp_alpha_field_1,
															string tmp_alpha_field_2,
															decimal? tmp_counter_1min,
															decimal? tmp_counter_1max,
															decimal? tmp_counter_2min,
															decimal? tmp_counter_2max,
															decimal? tmp_counter_3min,
															decimal? tmp_counter_3max,
															decimal? tmp_counter_4min,
															decimal? tmp_counter_4max,
															decimal? tmp_counter_5min,
															decimal? tmp_counter_5max,
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
					new SqlParameter("minDOC_OHIP_NBR",doc_ohip_nbrmin),
					new SqlParameter("maxDOC_OHIP_NBR",doc_ohip_nbrmax),
					new SqlParameter("DOC_NBR",doc_nbr),
					new SqlParameter("TMP_ALPHA_FIELD_1",tmp_alpha_field_1),
					new SqlParameter("TMP_ALPHA_FIELD_2",tmp_alpha_field_2),
					new SqlParameter("minTMP_COUNTER_1",tmp_counter_1min),
					new SqlParameter("maxTMP_COUNTER_1",tmp_counter_1max),
					new SqlParameter("minTMP_COUNTER_2",tmp_counter_2min),
					new SqlParameter("maxTMP_COUNTER_2",tmp_counter_2max),
					new SqlParameter("minTMP_COUNTER_3",tmp_counter_3min),
					new SqlParameter("maxTMP_COUNTER_3",tmp_counter_3max),
					new SqlParameter("minTMP_COUNTER_4",tmp_counter_4min),
					new SqlParameter("maxTMP_COUNTER_4",tmp_counter_4max),
					new SqlParameter("minTMP_COUNTER_5",tmp_counter_5min),
					new SqlParameter("maxTMP_COUNTER_5",tmp_counter_5max),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_TMP_DOCTOR_ALPHA_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<TMP_DOCTOR_ALPHA>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_TMP_DOCTOR_ALPHA_Search]", parameters);
            var collection = new ObservableCollection<TMP_DOCTOR_ALPHA>();

            while (Reader.Read())
            {
                collection.Add(new TMP_DOCTOR_ALPHA
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOC_OHIP_NBR = ConvertDEC(Reader["DOC_OHIP_NBR"]),
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					TMP_ALPHA_FIELD_1 = Reader["TMP_ALPHA_FIELD_1"].ToString(),
					TMP_ALPHA_FIELD_2 = Reader["TMP_ALPHA_FIELD_2"].ToString(),
					TMP_COUNTER_1 = ConvertDEC(Reader["TMP_COUNTER_1"]),
					TMP_COUNTER_2 = ConvertDEC(Reader["TMP_COUNTER_2"]),
					TMP_COUNTER_3 = ConvertDEC(Reader["TMP_COUNTER_3"]),
					TMP_COUNTER_4 = ConvertDEC(Reader["TMP_COUNTER_4"]),
					TMP_COUNTER_5 = ConvertDEC(Reader["TMP_COUNTER_5"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDoc_ohip_nbr = ConvertDEC(Reader["DOC_OHIP_NBR"]),
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalTmp_alpha_field_1 = Reader["TMP_ALPHA_FIELD_1"].ToString(),
					_originalTmp_alpha_field_2 = Reader["TMP_ALPHA_FIELD_2"].ToString(),
					_originalTmp_counter_1 = ConvertDEC(Reader["TMP_COUNTER_1"]),
					_originalTmp_counter_2 = ConvertDEC(Reader["TMP_COUNTER_2"]),
					_originalTmp_counter_3 = ConvertDEC(Reader["TMP_COUNTER_3"]),
					_originalTmp_counter_4 = ConvertDEC(Reader["TMP_COUNTER_4"]),
					_originalTmp_counter_5 = ConvertDEC(Reader["TMP_COUNTER_5"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public TMP_DOCTOR_ALPHA Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<TMP_DOCTOR_ALPHA> Collection(ObservableCollection<TMP_DOCTOR_ALPHA>
                                                               tmpDoctorAlpha = null)
        {
            if (IsSameSearch() && tmpDoctorAlpha != null)
            {
                return tmpDoctorAlpha;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<TMP_DOCTOR_ALPHA>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("DOC_OHIP_NBR",WhereDoc_ohip_nbr),
					new SqlParameter("DOC_NBR",WhereDoc_nbr),
					new SqlParameter("TMP_ALPHA_FIELD_1",WhereTmp_alpha_field_1),
					new SqlParameter("TMP_ALPHA_FIELD_2",WhereTmp_alpha_field_2),
					new SqlParameter("TMP_COUNTER_1",WhereTmp_counter_1),
					new SqlParameter("TMP_COUNTER_2",WhereTmp_counter_2),
					new SqlParameter("TMP_COUNTER_3",WhereTmp_counter_3),
					new SqlParameter("TMP_COUNTER_4",WhereTmp_counter_4),
					new SqlParameter("TMP_COUNTER_5",WhereTmp_counter_5),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_TMP_DOCTOR_ALPHA_Match]", parameters);
            var collection = new ObservableCollection<TMP_DOCTOR_ALPHA>();

            while (Reader.Read())
            {
                collection.Add(new TMP_DOCTOR_ALPHA
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOC_OHIP_NBR = ConvertDEC(Reader["DOC_OHIP_NBR"]),
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					TMP_ALPHA_FIELD_1 = Reader["TMP_ALPHA_FIELD_1"].ToString(),
					TMP_ALPHA_FIELD_2 = Reader["TMP_ALPHA_FIELD_2"].ToString(),
					TMP_COUNTER_1 = ConvertDEC(Reader["TMP_COUNTER_1"]),
					TMP_COUNTER_2 = ConvertDEC(Reader["TMP_COUNTER_2"]),
					TMP_COUNTER_3 = ConvertDEC(Reader["TMP_COUNTER_3"]),
					TMP_COUNTER_4 = ConvertDEC(Reader["TMP_COUNTER_4"]),
					TMP_COUNTER_5 = ConvertDEC(Reader["TMP_COUNTER_5"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereDoc_ohip_nbr = WhereDoc_ohip_nbr,
					_whereDoc_nbr = WhereDoc_nbr,
					_whereTmp_alpha_field_1 = WhereTmp_alpha_field_1,
					_whereTmp_alpha_field_2 = WhereTmp_alpha_field_2,
					_whereTmp_counter_1 = WhereTmp_counter_1,
					_whereTmp_counter_2 = WhereTmp_counter_2,
					_whereTmp_counter_3 = WhereTmp_counter_3,
					_whereTmp_counter_4 = WhereTmp_counter_4,
					_whereTmp_counter_5 = WhereTmp_counter_5,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDoc_ohip_nbr = ConvertDEC(Reader["DOC_OHIP_NBR"]),
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalTmp_alpha_field_1 = Reader["TMP_ALPHA_FIELD_1"].ToString(),
					_originalTmp_alpha_field_2 = Reader["TMP_ALPHA_FIELD_2"].ToString(),
					_originalTmp_counter_1 = ConvertDEC(Reader["TMP_COUNTER_1"]),
					_originalTmp_counter_2 = ConvertDEC(Reader["TMP_COUNTER_2"]),
					_originalTmp_counter_3 = ConvertDEC(Reader["TMP_COUNTER_3"]),
					_originalTmp_counter_4 = ConvertDEC(Reader["TMP_COUNTER_4"]),
					_originalTmp_counter_5 = ConvertDEC(Reader["TMP_COUNTER_5"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereDoc_ohip_nbr = WhereDoc_ohip_nbr;
					_whereDoc_nbr = WhereDoc_nbr;
					_whereTmp_alpha_field_1 = WhereTmp_alpha_field_1;
					_whereTmp_alpha_field_2 = WhereTmp_alpha_field_2;
					_whereTmp_counter_1 = WhereTmp_counter_1;
					_whereTmp_counter_2 = WhereTmp_counter_2;
					_whereTmp_counter_3 = WhereTmp_counter_3;
					_whereTmp_counter_4 = WhereTmp_counter_4;
					_whereTmp_counter_5 = WhereTmp_counter_5;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereDoc_ohip_nbr == null 
				&& WhereDoc_nbr == null 
				&& WhereTmp_alpha_field_1 == null 
				&& WhereTmp_alpha_field_2 == null 
				&& WhereTmp_counter_1 == null 
				&& WhereTmp_counter_2 == null 
				&& WhereTmp_counter_3 == null 
				&& WhereTmp_counter_4 == null 
				&& WhereTmp_counter_5 == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereDoc_ohip_nbr ==  _whereDoc_ohip_nbr
				&& WhereDoc_nbr ==  _whereDoc_nbr
				&& WhereTmp_alpha_field_1 ==  _whereTmp_alpha_field_1
				&& WhereTmp_alpha_field_2 ==  _whereTmp_alpha_field_2
				&& WhereTmp_counter_1 ==  _whereTmp_counter_1
				&& WhereTmp_counter_2 ==  _whereTmp_counter_2
				&& WhereTmp_counter_3 ==  _whereTmp_counter_3
				&& WhereTmp_counter_4 ==  _whereTmp_counter_4
				&& WhereTmp_counter_5 ==  _whereTmp_counter_5
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereDoc_ohip_nbr = null; 
			WhereDoc_nbr = null; 
			WhereTmp_alpha_field_1 = null; 
			WhereTmp_alpha_field_2 = null; 
			WhereTmp_counter_1 = null; 
			WhereTmp_counter_2 = null; 
			WhereTmp_counter_3 = null; 
			WhereTmp_counter_4 = null; 
			WhereTmp_counter_5 = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private decimal? _DOC_OHIP_NBR;
		private string _DOC_NBR;
		private string _TMP_ALPHA_FIELD_1;
		private string _TMP_ALPHA_FIELD_2;
		private decimal? _TMP_COUNTER_1;
		private decimal? _TMP_COUNTER_2;
		private decimal? _TMP_COUNTER_3;
		private decimal? _TMP_COUNTER_4;
		private decimal? _TMP_COUNTER_5;
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
		public decimal? DOC_OHIP_NBR
		{
			get { return _DOC_OHIP_NBR; }
			set
			{
				if (_DOC_OHIP_NBR != value)
				{
					_DOC_OHIP_NBR = value;
					ChangeState();
				}
			}
		}
		public string DOC_NBR
		{
			get { return _DOC_NBR; }
			set
			{
				if (_DOC_NBR != value)
				{
					_DOC_NBR = value;
					ChangeState();
				}
			}
		}
		public string TMP_ALPHA_FIELD_1
		{
			get { return _TMP_ALPHA_FIELD_1; }
			set
			{
				if (_TMP_ALPHA_FIELD_1 != value)
				{
					_TMP_ALPHA_FIELD_1 = value;
					ChangeState();
				}
			}
		}
		public string TMP_ALPHA_FIELD_2
		{
			get { return _TMP_ALPHA_FIELD_2; }
			set
			{
				if (_TMP_ALPHA_FIELD_2 != value)
				{
					_TMP_ALPHA_FIELD_2 = value;
					ChangeState();
				}
			}
		}
		public decimal? TMP_COUNTER_1
		{
			get { return _TMP_COUNTER_1; }
			set
			{
				if (_TMP_COUNTER_1 != value)
				{
					_TMP_COUNTER_1 = value;
					ChangeState();
				}
			}
		}
		public decimal? TMP_COUNTER_2
		{
			get { return _TMP_COUNTER_2; }
			set
			{
				if (_TMP_COUNTER_2 != value)
				{
					_TMP_COUNTER_2 = value;
					ChangeState();
				}
			}
		}
		public decimal? TMP_COUNTER_3
		{
			get { return _TMP_COUNTER_3; }
			set
			{
				if (_TMP_COUNTER_3 != value)
				{
					_TMP_COUNTER_3 = value;
					ChangeState();
				}
			}
		}
		public decimal? TMP_COUNTER_4
		{
			get { return _TMP_COUNTER_4; }
			set
			{
				if (_TMP_COUNTER_4 != value)
				{
					_TMP_COUNTER_4 = value;
					ChangeState();
				}
			}
		}
		public decimal? TMP_COUNTER_5
		{
			get { return _TMP_COUNTER_5; }
			set
			{
				if (_TMP_COUNTER_5 != value)
				{
					_TMP_COUNTER_5 = value;
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
		public decimal? WhereDoc_ohip_nbr { get; set; }
		private decimal? _whereDoc_ohip_nbr;
		public string WhereDoc_nbr { get; set; }
		private string _whereDoc_nbr;
		public string WhereTmp_alpha_field_1 { get; set; }
		private string _whereTmp_alpha_field_1;
		public string WhereTmp_alpha_field_2 { get; set; }
		private string _whereTmp_alpha_field_2;
		public decimal? WhereTmp_counter_1 { get; set; }
		private decimal? _whereTmp_counter_1;
		public decimal? WhereTmp_counter_2 { get; set; }
		private decimal? _whereTmp_counter_2;
		public decimal? WhereTmp_counter_3 { get; set; }
		private decimal? _whereTmp_counter_3;
		public decimal? WhereTmp_counter_4 { get; set; }
		private decimal? _whereTmp_counter_4;
		public decimal? WhereTmp_counter_5 { get; set; }
		private decimal? _whereTmp_counter_5;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private decimal? _originalDoc_ohip_nbr;
		private string _originalDoc_nbr;
		private string _originalTmp_alpha_field_1;
		private string _originalTmp_alpha_field_2;
		private decimal? _originalTmp_counter_1;
		private decimal? _originalTmp_counter_2;
		private decimal? _originalTmp_counter_3;
		private decimal? _originalTmp_counter_4;
		private decimal? _originalTmp_counter_5;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			DOC_OHIP_NBR = _originalDoc_ohip_nbr;
			DOC_NBR = _originalDoc_nbr;
			TMP_ALPHA_FIELD_1 = _originalTmp_alpha_field_1;
			TMP_ALPHA_FIELD_2 = _originalTmp_alpha_field_2;
			TMP_COUNTER_1 = _originalTmp_counter_1;
			TMP_COUNTER_2 = _originalTmp_counter_2;
			TMP_COUNTER_3 = _originalTmp_counter_3;
			TMP_COUNTER_4 = _originalTmp_counter_4;
			TMP_COUNTER_5 = _originalTmp_counter_5;
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
					new SqlParameter("DOC_OHIP_NBR",DOC_OHIP_NBR),
					new SqlParameter("DOC_NBR",DOC_NBR),
					new SqlParameter("TMP_ALPHA_FIELD_1",TMP_ALPHA_FIELD_1)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_TMP_DOCTOR_ALPHA_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_TMP_DOCTOR_ALPHA_Purge]");
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
						new SqlParameter("DOC_OHIP_NBR", SqlNull(DOC_OHIP_NBR)),
						new SqlParameter("DOC_NBR", SqlNull(DOC_NBR)),
						new SqlParameter("TMP_ALPHA_FIELD_1", SqlNull(TMP_ALPHA_FIELD_1)),
						new SqlParameter("TMP_ALPHA_FIELD_2", SqlNull(TMP_ALPHA_FIELD_2)),
						new SqlParameter("TMP_COUNTER_1", SqlNull(TMP_COUNTER_1)),
						new SqlParameter("TMP_COUNTER_2", SqlNull(TMP_COUNTER_2)),
						new SqlParameter("TMP_COUNTER_3", SqlNull(TMP_COUNTER_3)),
						new SqlParameter("TMP_COUNTER_4", SqlNull(TMP_COUNTER_4)),
						new SqlParameter("TMP_COUNTER_5", SqlNull(TMP_COUNTER_5)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_TMP_DOCTOR_ALPHA_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOC_OHIP_NBR = ConvertDEC(Reader["DOC_OHIP_NBR"]);
						DOC_NBR = Reader["DOC_NBR"].ToString();
						TMP_ALPHA_FIELD_1 = Reader["TMP_ALPHA_FIELD_1"].ToString();
						TMP_ALPHA_FIELD_2 = Reader["TMP_ALPHA_FIELD_2"].ToString();
						TMP_COUNTER_1 = ConvertDEC(Reader["TMP_COUNTER_1"]);
						TMP_COUNTER_2 = ConvertDEC(Reader["TMP_COUNTER_2"]);
						TMP_COUNTER_3 = ConvertDEC(Reader["TMP_COUNTER_3"]);
						TMP_COUNTER_4 = ConvertDEC(Reader["TMP_COUNTER_4"]);
						TMP_COUNTER_5 = ConvertDEC(Reader["TMP_COUNTER_5"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDoc_ohip_nbr = ConvertDEC(Reader["DOC_OHIP_NBR"]);
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalTmp_alpha_field_1 = Reader["TMP_ALPHA_FIELD_1"].ToString();
						_originalTmp_alpha_field_2 = Reader["TMP_ALPHA_FIELD_2"].ToString();
						_originalTmp_counter_1 = ConvertDEC(Reader["TMP_COUNTER_1"]);
						_originalTmp_counter_2 = ConvertDEC(Reader["TMP_COUNTER_2"]);
						_originalTmp_counter_3 = ConvertDEC(Reader["TMP_COUNTER_3"]);
						_originalTmp_counter_4 = ConvertDEC(Reader["TMP_COUNTER_4"]);
						_originalTmp_counter_5 = ConvertDEC(Reader["TMP_COUNTER_5"]);
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("DOC_OHIP_NBR", SqlNull(DOC_OHIP_NBR)),
						new SqlParameter("DOC_NBR", SqlNull(DOC_NBR)),
						new SqlParameter("TMP_ALPHA_FIELD_1", SqlNull(TMP_ALPHA_FIELD_1)),
						new SqlParameter("TMP_ALPHA_FIELD_2", SqlNull(TMP_ALPHA_FIELD_2)),
						new SqlParameter("TMP_COUNTER_1", SqlNull(TMP_COUNTER_1)),
						new SqlParameter("TMP_COUNTER_2", SqlNull(TMP_COUNTER_2)),
						new SqlParameter("TMP_COUNTER_3", SqlNull(TMP_COUNTER_3)),
						new SqlParameter("TMP_COUNTER_4", SqlNull(TMP_COUNTER_4)),
						new SqlParameter("TMP_COUNTER_5", SqlNull(TMP_COUNTER_5)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_TMP_DOCTOR_ALPHA_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOC_OHIP_NBR = ConvertDEC(Reader["DOC_OHIP_NBR"]);
						DOC_NBR = Reader["DOC_NBR"].ToString();
						TMP_ALPHA_FIELD_1 = Reader["TMP_ALPHA_FIELD_1"].ToString();
						TMP_ALPHA_FIELD_2 = Reader["TMP_ALPHA_FIELD_2"].ToString();
						TMP_COUNTER_1 = ConvertDEC(Reader["TMP_COUNTER_1"]);
						TMP_COUNTER_2 = ConvertDEC(Reader["TMP_COUNTER_2"]);
						TMP_COUNTER_3 = ConvertDEC(Reader["TMP_COUNTER_3"]);
						TMP_COUNTER_4 = ConvertDEC(Reader["TMP_COUNTER_4"]);
						TMP_COUNTER_5 = ConvertDEC(Reader["TMP_COUNTER_5"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDoc_ohip_nbr = ConvertDEC(Reader["DOC_OHIP_NBR"]);
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalTmp_alpha_field_1 = Reader["TMP_ALPHA_FIELD_1"].ToString();
						_originalTmp_alpha_field_2 = Reader["TMP_ALPHA_FIELD_2"].ToString();
						_originalTmp_counter_1 = ConvertDEC(Reader["TMP_COUNTER_1"]);
						_originalTmp_counter_2 = ConvertDEC(Reader["TMP_COUNTER_2"]);
						_originalTmp_counter_3 = ConvertDEC(Reader["TMP_COUNTER_3"]);
						_originalTmp_counter_4 = ConvertDEC(Reader["TMP_COUNTER_4"]);
						_originalTmp_counter_5 = ConvertDEC(Reader["TMP_COUNTER_5"]);
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