using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F095_TEXT_LINES : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F095_TEXT_LINES> Collection( Guid? rowid,
															string record_id,
															string udt_key,
															decimal? seq_nbrmin,
															decimal? seq_nbrmax,
															string text,
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
					new SqlParameter("RECORD_ID",record_id),
					new SqlParameter("UDT_KEY",udt_key),
					new SqlParameter("minSEQ_NBR",seq_nbrmin),
					new SqlParameter("maxSEQ_NBR",seq_nbrmax),
					new SqlParameter("TEXT",text),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F095_TEXT_LINES_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F095_TEXT_LINES>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F095_TEXT_LINES_Search]", parameters);
            var collection = new ObservableCollection<F095_TEXT_LINES>();

            while (Reader.Read())
            {
                collection.Add(new F095_TEXT_LINES
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					RECORD_ID = Reader["RECORD_ID"].ToString(),
					UDT_KEY = Reader["UDT_KEY"].ToString(),
					SEQ_NBR = ConvertDEC(Reader["SEQ_NBR"]),
					TEXT = Reader["TEXT"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalRecord_id = Reader["RECORD_ID"].ToString(),
					_originalUdt_key = Reader["UDT_KEY"].ToString(),
					_originalSeq_nbr = ConvertDEC(Reader["SEQ_NBR"]),
					_originalText = Reader["TEXT"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F095_TEXT_LINES Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F095_TEXT_LINES> Collection(ObservableCollection<F095_TEXT_LINES>
                                                               f095TextLines = null)
        {
            if (IsSameSearch() && f095TextLines != null)
            {
                return f095TextLines;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F095_TEXT_LINES>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("RECORD_ID",WhereRecord_id),
					new SqlParameter("UDT_KEY",WhereUdt_key),
					new SqlParameter("SEQ_NBR",WhereSeq_nbr),
					new SqlParameter("TEXT",WhereText),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F095_TEXT_LINES_Match]", parameters);
            var collection = new ObservableCollection<F095_TEXT_LINES>();

            while (Reader.Read())
            {
                collection.Add(new F095_TEXT_LINES
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					RECORD_ID = Reader["RECORD_ID"].ToString(),
					UDT_KEY = Reader["UDT_KEY"].ToString(),
					SEQ_NBR = ConvertDEC(Reader["SEQ_NBR"]),
					TEXT = Reader["TEXT"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereRecord_id = WhereRecord_id,
					_whereUdt_key = WhereUdt_key,
					_whereSeq_nbr = WhereSeq_nbr,
					_whereText = WhereText,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalRecord_id = Reader["RECORD_ID"].ToString(),
					_originalUdt_key = Reader["UDT_KEY"].ToString(),
					_originalSeq_nbr = ConvertDEC(Reader["SEQ_NBR"]),
					_originalText = Reader["TEXT"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereRecord_id = WhereRecord_id;
					_whereUdt_key = WhereUdt_key;
					_whereSeq_nbr = WhereSeq_nbr;
					_whereText = WhereText;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereRecord_id == null 
				&& WhereUdt_key == null 
				&& WhereSeq_nbr == null 
				&& WhereText == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereRecord_id ==  _whereRecord_id
				&& WhereUdt_key ==  _whereUdt_key
				&& WhereSeq_nbr ==  _whereSeq_nbr
				&& WhereText ==  _whereText
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereRecord_id = null; 
			WhereUdt_key = null; 
			WhereSeq_nbr = null; 
			WhereText = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _RECORD_ID;
		private string _UDT_KEY;
		private decimal? _SEQ_NBR;
		private string _TEXT;
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
		public string RECORD_ID
		{
			get { return _RECORD_ID; }
			set
			{
				if (_RECORD_ID != value)
				{
					_RECORD_ID = value;
					ChangeState();
				}
			}
		}
		public string UDT_KEY
		{
			get { return _UDT_KEY; }
			set
			{
				if (_UDT_KEY != value)
				{
					_UDT_KEY = value;
					ChangeState();
				}
			}
		}
		public decimal? SEQ_NBR
		{
			get { return _SEQ_NBR; }
			set
			{
				if (_SEQ_NBR != value)
				{
					_SEQ_NBR = value;
					ChangeState();
				}
			}
		}
		public string TEXT
		{
			get { return _TEXT; }
			set
			{
				if (_TEXT != value)
				{
					_TEXT = value;
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
		public string WhereRecord_id { get; set; }
		private string _whereRecord_id;
		public string WhereUdt_key { get; set; }
		private string _whereUdt_key;
		public decimal? WhereSeq_nbr { get; set; }
		private decimal? _whereSeq_nbr;
		public string WhereText { get; set; }
		private string _whereText;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalRecord_id;
		private string _originalUdt_key;
		private decimal? _originalSeq_nbr;
		private string _originalText;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			RECORD_ID = _originalRecord_id;
			UDT_KEY = _originalUdt_key;
			SEQ_NBR = _originalSeq_nbr;
			TEXT = _originalText;
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
					new SqlParameter("RECORD_ID",RECORD_ID),
					new SqlParameter("UDT_KEY",UDT_KEY),
					new SqlParameter("SEQ_NBR",SEQ_NBR)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F095_TEXT_LINES_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F095_TEXT_LINES_Purge]");
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
						new SqlParameter("RECORD_ID", SqlNull(RECORD_ID)),
						new SqlParameter("UDT_KEY", SqlNull(UDT_KEY)),
						new SqlParameter("SEQ_NBR", SqlNull(SEQ_NBR)),
						new SqlParameter("TEXT", SqlNull(TEXT)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F095_TEXT_LINES_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						RECORD_ID = Reader["RECORD_ID"].ToString();
						UDT_KEY = Reader["UDT_KEY"].ToString();
						SEQ_NBR = ConvertDEC(Reader["SEQ_NBR"]);
						TEXT = Reader["TEXT"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalRecord_id = Reader["RECORD_ID"].ToString();
						_originalUdt_key = Reader["UDT_KEY"].ToString();
						_originalSeq_nbr = ConvertDEC(Reader["SEQ_NBR"]);
						_originalText = Reader["TEXT"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("RECORD_ID", SqlNull(RECORD_ID)),
						new SqlParameter("UDT_KEY", SqlNull(UDT_KEY)),
						new SqlParameter("SEQ_NBR", SqlNull(SEQ_NBR)),
						new SqlParameter("TEXT", SqlNull(TEXT)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F095_TEXT_LINES_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						RECORD_ID = Reader["RECORD_ID"].ToString();
						UDT_KEY = Reader["UDT_KEY"].ToString();
						SEQ_NBR = ConvertDEC(Reader["SEQ_NBR"]);
						TEXT = Reader["TEXT"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalRecord_id = Reader["RECORD_ID"].ToString();
						_originalUdt_key = Reader["UDT_KEY"].ToString();
						_originalSeq_nbr = ConvertDEC(Reader["SEQ_NBR"]);
						_originalText = Reader["TEXT"].ToString();
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