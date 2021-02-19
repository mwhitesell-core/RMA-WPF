using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F200C_OSCAR_PROVIDER_NEXT_BATCH_NBR : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F200C_OSCAR_PROVIDER_NEXT_BATCH_NBR> Collection( Guid? rowid,
															string oscar_provider_no,
															string doc_nbr,
															decimal? doc_clinic_nbrmin,
															decimal? doc_clinic_nbrmax,
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
					new SqlParameter("OSCAR_PROVIDER_NO",oscar_provider_no),
					new SqlParameter("DOC_NBR",doc_nbr),
					new SqlParameter("minDOC_CLINIC_NBR",doc_clinic_nbrmin),
					new SqlParameter("maxDOC_CLINIC_NBR",doc_clinic_nbrmax),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F200C_OSCAR_PROVIDER_NEXT_BATCH_NBR_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F200C_OSCAR_PROVIDER_NEXT_BATCH_NBR>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F200C_OSCAR_PROVIDER_NEXT_BATCH_NBR_Search]", parameters);
            var collection = new ObservableCollection<F200C_OSCAR_PROVIDER_NEXT_BATCH_NBR>();

            while (Reader.Read())
            {
                collection.Add(new F200C_OSCAR_PROVIDER_NEXT_BATCH_NBR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					OSCAR_PROVIDER_NO = Reader["OSCAR_PROVIDER_NO"].ToString(),
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					DOC_CLINIC_NBR = ConvertDEC(Reader["DOC_CLINIC_NBR"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalOscar_provider_no = Reader["OSCAR_PROVIDER_NO"].ToString(),
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalDoc_clinic_nbr = ConvertDEC(Reader["DOC_CLINIC_NBR"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F200C_OSCAR_PROVIDER_NEXT_BATCH_NBR Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F200C_OSCAR_PROVIDER_NEXT_BATCH_NBR> Collection(ObservableCollection<F200C_OSCAR_PROVIDER_NEXT_BATCH_NBR>
                                                               f200cOscarProviderNextBatchNbr = null)
        {
            if (IsSameSearch() && f200cOscarProviderNextBatchNbr != null)
            {
                return f200cOscarProviderNextBatchNbr;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F200C_OSCAR_PROVIDER_NEXT_BATCH_NBR>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("OSCAR_PROVIDER_NO",WhereOscar_provider_no),
					new SqlParameter("DOC_NBR",WhereDoc_nbr),
					new SqlParameter("DOC_CLINIC_NBR",WhereDoc_clinic_nbr),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F200C_OSCAR_PROVIDER_NEXT_BATCH_NBR_Match]", parameters);
            var collection = new ObservableCollection<F200C_OSCAR_PROVIDER_NEXT_BATCH_NBR>();

            while (Reader.Read())
            {
                collection.Add(new F200C_OSCAR_PROVIDER_NEXT_BATCH_NBR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					OSCAR_PROVIDER_NO = Reader["OSCAR_PROVIDER_NO"].ToString(),
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					DOC_CLINIC_NBR = ConvertDEC(Reader["DOC_CLINIC_NBR"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereOscar_provider_no = WhereOscar_provider_no,
					_whereDoc_nbr = WhereDoc_nbr,
					_whereDoc_clinic_nbr = WhereDoc_clinic_nbr,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalOscar_provider_no = Reader["OSCAR_PROVIDER_NO"].ToString(),
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalDoc_clinic_nbr = ConvertDEC(Reader["DOC_CLINIC_NBR"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereOscar_provider_no = WhereOscar_provider_no;
					_whereDoc_nbr = WhereDoc_nbr;
					_whereDoc_clinic_nbr = WhereDoc_clinic_nbr;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereOscar_provider_no == null 
				&& WhereDoc_nbr == null 
				&& WhereDoc_clinic_nbr == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereOscar_provider_no ==  _whereOscar_provider_no
				&& WhereDoc_nbr ==  _whereDoc_nbr
				&& WhereDoc_clinic_nbr ==  _whereDoc_clinic_nbr
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereOscar_provider_no = null; 
			WhereDoc_nbr = null; 
			WhereDoc_clinic_nbr = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _OSCAR_PROVIDER_NO;
		private string _DOC_NBR;
		private decimal? _DOC_CLINIC_NBR;
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
		public string OSCAR_PROVIDER_NO
		{
			get { return _OSCAR_PROVIDER_NO; }
			set
			{
				if (_OSCAR_PROVIDER_NO != value)
				{
					_OSCAR_PROVIDER_NO = value;
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
		public decimal? DOC_CLINIC_NBR
		{
			get { return _DOC_CLINIC_NBR; }
			set
			{
				if (_DOC_CLINIC_NBR != value)
				{
					_DOC_CLINIC_NBR = value;
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
		public string WhereOscar_provider_no { get; set; }
		private string _whereOscar_provider_no;
		public string WhereDoc_nbr { get; set; }
		private string _whereDoc_nbr;
		public decimal? WhereDoc_clinic_nbr { get; set; }
		private decimal? _whereDoc_clinic_nbr;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalOscar_provider_no;
		private string _originalDoc_nbr;
		private decimal? _originalDoc_clinic_nbr;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			OSCAR_PROVIDER_NO = _originalOscar_provider_no;
			DOC_NBR = _originalDoc_nbr;
			DOC_CLINIC_NBR = _originalDoc_clinic_nbr;
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
					new SqlParameter("OSCAR_PROVIDER_NO",OSCAR_PROVIDER_NO),
					new SqlParameter("DOC_NBR",DOC_NBR),
					new SqlParameter("DOC_CLINIC_NBR",DOC_CLINIC_NBR)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F200C_OSCAR_PROVIDER_NEXT_BATCH_NBR_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F200C_OSCAR_PROVIDER_NEXT_BATCH_NBR_Purge]");
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
						new SqlParameter("OSCAR_PROVIDER_NO", SqlNull(OSCAR_PROVIDER_NO)),
						new SqlParameter("DOC_NBR", SqlNull(DOC_NBR)),
						new SqlParameter("DOC_CLINIC_NBR", SqlNull(DOC_CLINIC_NBR)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F200C_OSCAR_PROVIDER_NEXT_BATCH_NBR_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						OSCAR_PROVIDER_NO = Reader["OSCAR_PROVIDER_NO"].ToString();
						DOC_NBR = Reader["DOC_NBR"].ToString();
						DOC_CLINIC_NBR = ConvertDEC(Reader["DOC_CLINIC_NBR"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalOscar_provider_no = Reader["OSCAR_PROVIDER_NO"].ToString();
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalDoc_clinic_nbr = ConvertDEC(Reader["DOC_CLINIC_NBR"]);
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("OSCAR_PROVIDER_NO", SqlNull(OSCAR_PROVIDER_NO)),
						new SqlParameter("DOC_NBR", SqlNull(DOC_NBR)),
						new SqlParameter("DOC_CLINIC_NBR", SqlNull(DOC_CLINIC_NBR)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F200C_OSCAR_PROVIDER_NEXT_BATCH_NBR_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						OSCAR_PROVIDER_NO = Reader["OSCAR_PROVIDER_NO"].ToString();
						DOC_NBR = Reader["DOC_NBR"].ToString();
						DOC_CLINIC_NBR = ConvertDEC(Reader["DOC_CLINIC_NBR"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalOscar_provider_no = Reader["OSCAR_PROVIDER_NO"].ToString();
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalDoc_clinic_nbr = ConvertDEC(Reader["DOC_CLINIC_NBR"]);
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