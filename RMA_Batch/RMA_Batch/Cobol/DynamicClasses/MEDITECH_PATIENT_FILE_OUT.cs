using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class MEDITECH_PATIENT_FILE_OUT : BaseTable
    {
        #region Retrieve

        public ObservableCollection<MEDITECH_PATIENT_FILE_OUT> Collection( Guid? rowid,
															string rec_seq_nbr,
															string rec_line,
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
					new SqlParameter("REC_SEQ_NBR",rec_seq_nbr),
					new SqlParameter("REC_LINE",rec_line),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[SEQUENTIAL].[sp_MEDITECH_PATIENT_FILE_OUT_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<MEDITECH_PATIENT_FILE_OUT>();
				}

            }

            Reader = CoreReader("[SEQUENTIAL].[sp_MEDITECH_PATIENT_FILE_OUT_Search]", parameters);
            var collection = new ObservableCollection<MEDITECH_PATIENT_FILE_OUT>();

            while (Reader.Read())
            {
                collection.Add(new MEDITECH_PATIENT_FILE_OUT
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					REC_SEQ_NBR = Reader["REC_SEQ_NBR"].ToString(),
					REC_LINE = Reader["REC_LINE"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalRec_seq_nbr = Reader["REC_SEQ_NBR"].ToString(),
					_originalRec_line = Reader["REC_LINE"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public MEDITECH_PATIENT_FILE_OUT Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<MEDITECH_PATIENT_FILE_OUT> Collection(ObservableCollection<MEDITECH_PATIENT_FILE_OUT>
                                                               meditechPatientFileOut = null)
        {
            if (IsSameSearch() && meditechPatientFileOut != null)
            {
                return meditechPatientFileOut;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<MEDITECH_PATIENT_FILE_OUT>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("REC_SEQ_NBR",WhereRec_seq_nbr),
					new SqlParameter("REC_LINE",WhereRec_line),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[SEQUENTIAL].[sp_MEDITECH_PATIENT_FILE_OUT_Match]", parameters);
            var collection = new ObservableCollection<MEDITECH_PATIENT_FILE_OUT>();

            while (Reader.Read())
            {
                collection.Add(new MEDITECH_PATIENT_FILE_OUT
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					REC_SEQ_NBR = Reader["REC_SEQ_NBR"].ToString(),
					REC_LINE = Reader["REC_LINE"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereRec_seq_nbr = WhereRec_seq_nbr,
					_whereRec_line = WhereRec_line,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalRec_seq_nbr = Reader["REC_SEQ_NBR"].ToString(),
					_originalRec_line = Reader["REC_LINE"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereRec_seq_nbr = WhereRec_seq_nbr;
					_whereRec_line = WhereRec_line;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereRec_seq_nbr == null 
				&& WhereRec_line == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereRec_seq_nbr ==  _whereRec_seq_nbr
				&& WhereRec_line ==  _whereRec_line
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereRec_seq_nbr = null; 
			WhereRec_line = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _REC_SEQ_NBR;
		private string _REC_LINE;
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
		public string REC_SEQ_NBR
		{
			get { return _REC_SEQ_NBR; }
			set
			{
				if (_REC_SEQ_NBR != value)
				{
					_REC_SEQ_NBR = value;
					ChangeState();
				}
			}
		}
		public string REC_LINE
		{
			get { return _REC_LINE; }
			set
			{
				if (_REC_LINE != value)
				{
					_REC_LINE = value;
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
		public string WhereRec_seq_nbr { get; set; }
		private string _whereRec_seq_nbr;
		public string WhereRec_line { get; set; }
		private string _whereRec_line;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalRec_seq_nbr;
		private string _originalRec_line;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			REC_SEQ_NBR = _originalRec_seq_nbr;
			REC_LINE = _originalRec_line;
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
					new SqlParameter("ROWID",ROWID)
				};
			RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_MEDITECH_PATIENT_FILE_OUT_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_MEDITECH_PATIENT_FILE_OUT_Purge]");
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
						new SqlParameter("REC_SEQ_NBR", SqlNull(REC_SEQ_NBR)),
						new SqlParameter("REC_LINE", SqlNull(REC_LINE)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_MEDITECH_PATIENT_FILE_OUT_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						REC_SEQ_NBR = Reader["REC_SEQ_NBR"].ToString();
						REC_LINE = Reader["REC_LINE"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalRec_seq_nbr = Reader["REC_SEQ_NBR"].ToString();
						_originalRec_line = Reader["REC_LINE"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("REC_SEQ_NBR", SqlNull(REC_SEQ_NBR)),
						new SqlParameter("REC_LINE", SqlNull(REC_LINE)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_MEDITECH_PATIENT_FILE_OUT_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						REC_SEQ_NBR = Reader["REC_SEQ_NBR"].ToString();
						REC_LINE = Reader["REC_LINE"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalRec_seq_nbr = Reader["REC_SEQ_NBR"].ToString();
						_originalRec_line = Reader["REC_LINE"].ToString();
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