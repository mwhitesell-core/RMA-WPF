using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F060_CHEQUE_REG_MSTR : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F060_CHEQUE_REG_MSTR> Collection( Guid? rowid,
															decimal? chq_reg_clinic_nbr_1_2min,
															decimal? chq_reg_clinic_nbr_1_2max,
															decimal? chq_reg_deptmin,
															decimal? chq_reg_deptmax,
															string chq_reg_doc_nbr,
															double? chq_reg_perc_bill1min,
															double? chq_reg_perc_bill1max,
															double? chq_reg_perc_bill2min,
															double? chq_reg_perc_bill2max,
															double? chq_reg_perc_bill3min,
															double? chq_reg_perc_bill3max,
															double? chq_reg_perc_bill4min,
															double? chq_reg_perc_bill4max,
															double? chq_reg_perc_bill5min,
															double? chq_reg_perc_bill5max,
															double? chq_reg_perc_bill6min,
															double? chq_reg_perc_bill6max,
															double? chq_reg_perc_bill7min,
															double? chq_reg_perc_bill7max,
															double? chq_reg_perc_bill8min,
															double? chq_reg_perc_bill8max,
															double? chq_reg_perc_bill9min,
															double? chq_reg_perc_bill9max,
															double? chq_reg_perc_bill10min,
															double? chq_reg_perc_bill10max,
															double? chq_reg_perc_bill11min,
															double? chq_reg_perc_bill11max,
															double? chq_reg_perc_bill12min,
															double? chq_reg_perc_bill12max,
															double? chq_reg_perc_bill13min,
															double? chq_reg_perc_bill13max,
															double? chq_reg_perc_bill14min,
															double? chq_reg_perc_bill14max,
															double? chq_reg_perc_bill15min,
															double? chq_reg_perc_bill15max,
															double? chq_reg_perc_bill16min,
															double? chq_reg_perc_bill16max,
															double? chq_reg_perc_bill17min,
															double? chq_reg_perc_bill17max,
															double? chq_reg_perc_bill18min,
															double? chq_reg_perc_bill18max,
															double? chq_reg_perc_misc1min,
															double? chq_reg_perc_misc1max,
															double? chq_reg_perc_misc2min,
															double? chq_reg_perc_misc2max,
															double? chq_reg_perc_misc3min,
															double? chq_reg_perc_misc3max,
															double? chq_reg_perc_misc4min,
															double? chq_reg_perc_misc4max,
															double? chq_reg_perc_misc5min,
															double? chq_reg_perc_misc5max,
															double? chq_reg_perc_misc6min,
															double? chq_reg_perc_misc6max,
															double? chq_reg_perc_misc7min,
															double? chq_reg_perc_misc7max,
															double? chq_reg_perc_misc8min,
															double? chq_reg_perc_misc8max,
															double? chq_reg_perc_misc9min,
															double? chq_reg_perc_misc9max,
															double? chq_reg_perc_misc10min,
															double? chq_reg_perc_misc10max,
															double? chq_reg_perc_misc11min,
															double? chq_reg_perc_misc11max,
															double? chq_reg_perc_misc12min,
															double? chq_reg_perc_misc12max,
															double? chq_reg_perc_misc13min,
															double? chq_reg_perc_misc13max,
															double? chq_reg_perc_misc14min,
															double? chq_reg_perc_misc14max,
															double? chq_reg_perc_misc15min,
															double? chq_reg_perc_misc15max,
															double? chq_reg_perc_misc16min,
															double? chq_reg_perc_misc16max,
															double? chq_reg_perc_misc17min,
															double? chq_reg_perc_misc17max,
															double? chq_reg_perc_misc18min,
															double? chq_reg_perc_misc18max,
															string chq_reg_pay_code1,
															string chq_reg_pay_code2,
															string chq_reg_pay_code3,
															string chq_reg_pay_code4,
															string chq_reg_pay_code5,
															string chq_reg_pay_code6,
															string chq_reg_pay_code7,
															string chq_reg_pay_code8,
															string chq_reg_pay_code9,
															string chq_reg_pay_code10,
															string chq_reg_pay_code11,
															string chq_reg_pay_code12,
															string chq_reg_pay_code13,
															string chq_reg_pay_code14,
															string chq_reg_pay_code15,
															string chq_reg_pay_code16,
															string chq_reg_pay_code17,
															string chq_reg_pay_code18,
															double? chq_reg_perc_tax1min,
															double? chq_reg_perc_tax1max,
															double? chq_reg_perc_tax2min,
															double? chq_reg_perc_tax2max,
															double? chq_reg_perc_tax3min,
															double? chq_reg_perc_tax3max,
															double? chq_reg_perc_tax4min,
															double? chq_reg_perc_tax4max,
															double? chq_reg_perc_tax5min,
															double? chq_reg_perc_tax5max,
															double? chq_reg_perc_tax6min,
															double? chq_reg_perc_tax6max,
															double? chq_reg_perc_tax7min,
															double? chq_reg_perc_tax7max,
															double? chq_reg_perc_tax8min,
															double? chq_reg_perc_tax8max,
															double? chq_reg_perc_tax9min,
															double? chq_reg_perc_tax9max,
															double? chq_reg_perc_tax10min,
															double? chq_reg_perc_tax10max,
															double? chq_reg_perc_tax11min,
															double? chq_reg_perc_tax11max,
															double? chq_reg_perc_tax12min,
															double? chq_reg_perc_tax12max,
															double? chq_reg_perc_tax13min,
															double? chq_reg_perc_tax13max,
															double? chq_reg_perc_tax14min,
															double? chq_reg_perc_tax14max,
															double? chq_reg_perc_tax15min,
															double? chq_reg_perc_tax15max,
															double? chq_reg_perc_tax16min,
															double? chq_reg_perc_tax16max,
															double? chq_reg_perc_tax17min,
															double? chq_reg_perc_tax17max,
															double? chq_reg_perc_tax18min,
															double? chq_reg_perc_tax18max,
															double? chq_reg_mth_bill_amt1min,
															double? chq_reg_mth_bill_amt1max,
															double? chq_reg_mth_bill_amt2min,
															double? chq_reg_mth_bill_amt2max,
															double? chq_reg_mth_bill_amt3min,
															double? chq_reg_mth_bill_amt3max,
															double? chq_reg_mth_bill_amt4min,
															double? chq_reg_mth_bill_amt4max,
															double? chq_reg_mth_bill_amt5min,
															double? chq_reg_mth_bill_amt5max,
															double? chq_reg_mth_bill_amt6min,
															double? chq_reg_mth_bill_amt6max,
															double? chq_reg_mth_bill_amt7min,
															double? chq_reg_mth_bill_amt7max,
															double? chq_reg_mth_bill_amt8min,
															double? chq_reg_mth_bill_amt8max,
															double? chq_reg_mth_bill_amt9min,
															double? chq_reg_mth_bill_amt9max,
															double? chq_reg_mth_bill_amt10min,
															double? chq_reg_mth_bill_amt10max,
															double? chq_reg_mth_bill_amt11min,
															double? chq_reg_mth_bill_amt11max,
															double? chq_reg_mth_bill_amt12min,
															double? chq_reg_mth_bill_amt12max,
															double? chq_reg_mth_bill_amt13min,
															double? chq_reg_mth_bill_amt13max,
															double? chq_reg_mth_bill_amt14min,
															double? chq_reg_mth_bill_amt14max,
															double? chq_reg_mth_bill_amt15min,
															double? chq_reg_mth_bill_amt15max,
															double? chq_reg_mth_bill_amt16min,
															double? chq_reg_mth_bill_amt16max,
															double? chq_reg_mth_bill_amt17min,
															double? chq_reg_mth_bill_amt17max,
															double? chq_reg_mth_bill_amt18min,
															double? chq_reg_mth_bill_amt18max,
															double? chq_reg_mth_misc_amt_11min,
															double? chq_reg_mth_misc_amt_11max,
															double? chq_reg_mth_misc_amt_12min,
															double? chq_reg_mth_misc_amt_12max,
															double? chq_reg_mth_misc_amt_13min,
															double? chq_reg_mth_misc_amt_13max,
															double? chq_reg_mth_misc_amt_14min,
															double? chq_reg_mth_misc_amt_14max,
															double? chq_reg_mth_misc_amt_15min,
															double? chq_reg_mth_misc_amt_15max,
															double? chq_reg_mth_misc_amt_16min,
															double? chq_reg_mth_misc_amt_16max,
															double? chq_reg_mth_misc_amt_17min,
															double? chq_reg_mth_misc_amt_17max,
															double? chq_reg_mth_misc_amt_18min,
															double? chq_reg_mth_misc_amt_18max,
															double? chq_reg_mth_misc_amt_19min,
															double? chq_reg_mth_misc_amt_19max,
															double? chq_reg_mth_misc_amt_110min,
															double? chq_reg_mth_misc_amt_110max,
															double? chq_reg_mth_misc_amt_111min,
															double? chq_reg_mth_misc_amt_111max,
															double? chq_reg_mth_misc_amt_112min,
															double? chq_reg_mth_misc_amt_112max,
															double? chq_reg_mth_misc_amt_113min,
															double? chq_reg_mth_misc_amt_113max,
															double? chq_reg_mth_misc_amt_114min,
															double? chq_reg_mth_misc_amt_114max,
															double? chq_reg_mth_misc_amt_115min,
															double? chq_reg_mth_misc_amt_115max,
															double? chq_reg_mth_misc_amt_116min,
															double? chq_reg_mth_misc_amt_116max,
															double? chq_reg_mth_misc_amt_117min,
															double? chq_reg_mth_misc_amt_117max,
															double? chq_reg_mth_misc_amt_118min,
															double? chq_reg_mth_misc_amt_118max,
															double? chq_reg_mth_misc_amt_21min,
															double? chq_reg_mth_misc_amt_21max,
															double? chq_reg_mth_misc_amt_22min,
															double? chq_reg_mth_misc_amt_22max,
															double? chq_reg_mth_misc_amt_23min,
															double? chq_reg_mth_misc_amt_23max,
															double? chq_reg_mth_misc_amt_24min,
															double? chq_reg_mth_misc_amt_24max,
															double? chq_reg_mth_misc_amt_25min,
															double? chq_reg_mth_misc_amt_25max,
															double? chq_reg_mth_misc_amt_26min,
															double? chq_reg_mth_misc_amt_26max,
															double? chq_reg_mth_misc_amt_27min,
															double? chq_reg_mth_misc_amt_27max,
															double? chq_reg_mth_misc_amt_28min,
															double? chq_reg_mth_misc_amt_28max,
															double? chq_reg_mth_misc_amt_29min,
															double? chq_reg_mth_misc_amt_29max,
															double? chq_reg_mth_misc_amt_210min,
															double? chq_reg_mth_misc_amt_210max,
															double? chq_reg_mth_misc_amt_211min,
															double? chq_reg_mth_misc_amt_211max,
															double? chq_reg_mth_misc_amt_212min,
															double? chq_reg_mth_misc_amt_212max,
															double? chq_reg_mth_misc_amt_213min,
															double? chq_reg_mth_misc_amt_213max,
															double? chq_reg_mth_misc_amt_214min,
															double? chq_reg_mth_misc_amt_214max,
															double? chq_reg_mth_misc_amt_215min,
															double? chq_reg_mth_misc_amt_215max,
															double? chq_reg_mth_misc_amt_216min,
															double? chq_reg_mth_misc_amt_216max,
															double? chq_reg_mth_misc_amt_217min,
															double? chq_reg_mth_misc_amt_217max,
															double? chq_reg_mth_misc_amt_218min,
															double? chq_reg_mth_misc_amt_218max,
															double? chq_reg_mth_misc_amt_31min,
															double? chq_reg_mth_misc_amt_31max,
															double? chq_reg_mth_misc_amt_32min,
															double? chq_reg_mth_misc_amt_32max,
															double? chq_reg_mth_misc_amt_33min,
															double? chq_reg_mth_misc_amt_33max,
															double? chq_reg_mth_misc_amt_34min,
															double? chq_reg_mth_misc_amt_34max,
															double? chq_reg_mth_misc_amt_35min,
															double? chq_reg_mth_misc_amt_35max,
															double? chq_reg_mth_misc_amt_36min,
															double? chq_reg_mth_misc_amt_36max,
															double? chq_reg_mth_misc_amt_37min,
															double? chq_reg_mth_misc_amt_37max,
															double? chq_reg_mth_misc_amt_38min,
															double? chq_reg_mth_misc_amt_38max,
															double? chq_reg_mth_misc_amt_39min,
															double? chq_reg_mth_misc_amt_39max,
															double? chq_reg_mth_misc_amt_310min,
															double? chq_reg_mth_misc_amt_310max,
															double? chq_reg_mth_misc_amt_311min,
															double? chq_reg_mth_misc_amt_311max,
															double? chq_reg_mth_misc_amt_312min,
															double? chq_reg_mth_misc_amt_312max,
															double? chq_reg_mth_misc_amt_313min,
															double? chq_reg_mth_misc_amt_313max,
															double? chq_reg_mth_misc_amt_314min,
															double? chq_reg_mth_misc_amt_314max,
															double? chq_reg_mth_misc_amt_315min,
															double? chq_reg_mth_misc_amt_315max,
															double? chq_reg_mth_misc_amt_316min,
															double? chq_reg_mth_misc_amt_316max,
															double? chq_reg_mth_misc_amt_317min,
															double? chq_reg_mth_misc_amt_317max,
															double? chq_reg_mth_misc_amt_318min,
															double? chq_reg_mth_misc_amt_318max,
															double? chq_reg_mth_misc_amt_41min,
															double? chq_reg_mth_misc_amt_41max,
															double? chq_reg_mth_misc_amt_42min,
															double? chq_reg_mth_misc_amt_42max,
															double? chq_reg_mth_misc_amt_43min,
															double? chq_reg_mth_misc_amt_43max,
															double? chq_reg_mth_misc_amt_44min,
															double? chq_reg_mth_misc_amt_44max,
															double? chq_reg_mth_misc_amt_45min,
															double? chq_reg_mth_misc_amt_45max,
															double? chq_reg_mth_misc_amt_46min,
															double? chq_reg_mth_misc_amt_46max,
															double? chq_reg_mth_misc_amt_47min,
															double? chq_reg_mth_misc_amt_47max,
															double? chq_reg_mth_misc_amt_48min,
															double? chq_reg_mth_misc_amt_48max,
															double? chq_reg_mth_misc_amt_49min,
															double? chq_reg_mth_misc_amt_49max,
															double? chq_reg_mth_misc_amt_410min,
															double? chq_reg_mth_misc_amt_410max,
															double? chq_reg_mth_misc_amt_411min,
															double? chq_reg_mth_misc_amt_411max,
															double? chq_reg_mth_misc_amt_412min,
															double? chq_reg_mth_misc_amt_412max,
															double? chq_reg_mth_misc_amt_413min,
															double? chq_reg_mth_misc_amt_413max,
															double? chq_reg_mth_misc_amt_414min,
															double? chq_reg_mth_misc_amt_414max,
															double? chq_reg_mth_misc_amt_415min,
															double? chq_reg_mth_misc_amt_415max,
															double? chq_reg_mth_misc_amt_416min,
															double? chq_reg_mth_misc_amt_416max,
															double? chq_reg_mth_misc_amt_417min,
															double? chq_reg_mth_misc_amt_417max,
															double? chq_reg_mth_misc_amt_418min,
															double? chq_reg_mth_misc_amt_418max,
															double? chq_reg_mth_misc_amt_51min,
															double? chq_reg_mth_misc_amt_51max,
															double? chq_reg_mth_misc_amt_52min,
															double? chq_reg_mth_misc_amt_52max,
															double? chq_reg_mth_misc_amt_53min,
															double? chq_reg_mth_misc_amt_53max,
															double? chq_reg_mth_misc_amt_54min,
															double? chq_reg_mth_misc_amt_54max,
															double? chq_reg_mth_misc_amt_55min,
															double? chq_reg_mth_misc_amt_55max,
															double? chq_reg_mth_misc_amt_56min,
															double? chq_reg_mth_misc_amt_56max,
															double? chq_reg_mth_misc_amt_57min,
															double? chq_reg_mth_misc_amt_57max,
															double? chq_reg_mth_misc_amt_58min,
															double? chq_reg_mth_misc_amt_58max,
															double? chq_reg_mth_misc_amt_59min,
															double? chq_reg_mth_misc_amt_59max,
															double? chq_reg_mth_misc_amt_510min,
															double? chq_reg_mth_misc_amt_510max,
															double? chq_reg_mth_misc_amt_511min,
															double? chq_reg_mth_misc_amt_511max,
															double? chq_reg_mth_misc_amt_512min,
															double? chq_reg_mth_misc_amt_512max,
															double? chq_reg_mth_misc_amt_513min,
															double? chq_reg_mth_misc_amt_513max,
															double? chq_reg_mth_misc_amt_514min,
															double? chq_reg_mth_misc_amt_514max,
															double? chq_reg_mth_misc_amt_515min,
															double? chq_reg_mth_misc_amt_515max,
															double? chq_reg_mth_misc_amt_516min,
															double? chq_reg_mth_misc_amt_516max,
															double? chq_reg_mth_misc_amt_517min,
															double? chq_reg_mth_misc_amt_517max,
															double? chq_reg_mth_misc_amt_518min,
															double? chq_reg_mth_misc_amt_518max,
															double? chq_reg_mth_misc_amt_61min,
															double? chq_reg_mth_misc_amt_61max,
															double? chq_reg_mth_misc_amt_62min,
															double? chq_reg_mth_misc_amt_62max,
															double? chq_reg_mth_misc_amt_63min,
															double? chq_reg_mth_misc_amt_63max,
															double? chq_reg_mth_misc_amt_64min,
															double? chq_reg_mth_misc_amt_64max,
															double? chq_reg_mth_misc_amt_65min,
															double? chq_reg_mth_misc_amt_65max,
															double? chq_reg_mth_misc_amt_66min,
															double? chq_reg_mth_misc_amt_66max,
															double? chq_reg_mth_misc_amt_67min,
															double? chq_reg_mth_misc_amt_67max,
															double? chq_reg_mth_misc_amt_68min,
															double? chq_reg_mth_misc_amt_68max,
															double? chq_reg_mth_misc_amt_69min,
															double? chq_reg_mth_misc_amt_69max,
															double? chq_reg_mth_misc_amt_610min,
															double? chq_reg_mth_misc_amt_610max,
															double? chq_reg_mth_misc_amt_611min,
															double? chq_reg_mth_misc_amt_611max,
															double? chq_reg_mth_misc_amt_612min,
															double? chq_reg_mth_misc_amt_612max,
															double? chq_reg_mth_misc_amt_613min,
															double? chq_reg_mth_misc_amt_613max,
															double? chq_reg_mth_misc_amt_614min,
															double? chq_reg_mth_misc_amt_614max,
															double? chq_reg_mth_misc_amt_615min,
															double? chq_reg_mth_misc_amt_615max,
															double? chq_reg_mth_misc_amt_616min,
															double? chq_reg_mth_misc_amt_616max,
															double? chq_reg_mth_misc_amt_617min,
															double? chq_reg_mth_misc_amt_617max,
															double? chq_reg_mth_misc_amt_618min,
															double? chq_reg_mth_misc_amt_618max,
															double? chq_reg_mth_misc_amt_71min,
															double? chq_reg_mth_misc_amt_71max,
															double? chq_reg_mth_misc_amt_72min,
															double? chq_reg_mth_misc_amt_72max,
															double? chq_reg_mth_misc_amt_73min,
															double? chq_reg_mth_misc_amt_73max,
															double? chq_reg_mth_misc_amt_74min,
															double? chq_reg_mth_misc_amt_74max,
															double? chq_reg_mth_misc_amt_75min,
															double? chq_reg_mth_misc_amt_75max,
															double? chq_reg_mth_misc_amt_76min,
															double? chq_reg_mth_misc_amt_76max,
															double? chq_reg_mth_misc_amt_77min,
															double? chq_reg_mth_misc_amt_77max,
															double? chq_reg_mth_misc_amt_78min,
															double? chq_reg_mth_misc_amt_78max,
															double? chq_reg_mth_misc_amt_79min,
															double? chq_reg_mth_misc_amt_79max,
															double? chq_reg_mth_misc_amt_710min,
															double? chq_reg_mth_misc_amt_710max,
															double? chq_reg_mth_misc_amt_711min,
															double? chq_reg_mth_misc_amt_711max,
															double? chq_reg_mth_misc_amt_712min,
															double? chq_reg_mth_misc_amt_712max,
															double? chq_reg_mth_misc_amt_713min,
															double? chq_reg_mth_misc_amt_713max,
															double? chq_reg_mth_misc_amt_714min,
															double? chq_reg_mth_misc_amt_714max,
															double? chq_reg_mth_misc_amt_715min,
															double? chq_reg_mth_misc_amt_715max,
															double? chq_reg_mth_misc_amt_716min,
															double? chq_reg_mth_misc_amt_716max,
															double? chq_reg_mth_misc_amt_717min,
															double? chq_reg_mth_misc_amt_717max,
															double? chq_reg_mth_misc_amt_718min,
															double? chq_reg_mth_misc_amt_718max,
															double? chq_reg_mth_misc_amt_81min,
															double? chq_reg_mth_misc_amt_81max,
															double? chq_reg_mth_misc_amt_82min,
															double? chq_reg_mth_misc_amt_82max,
															double? chq_reg_mth_misc_amt_83min,
															double? chq_reg_mth_misc_amt_83max,
															double? chq_reg_mth_misc_amt_84min,
															double? chq_reg_mth_misc_amt_84max,
															double? chq_reg_mth_misc_amt_85min,
															double? chq_reg_mth_misc_amt_85max,
															double? chq_reg_mth_misc_amt_86min,
															double? chq_reg_mth_misc_amt_86max,
															double? chq_reg_mth_misc_amt_87min,
															double? chq_reg_mth_misc_amt_87max,
															double? chq_reg_mth_misc_amt_88min,
															double? chq_reg_mth_misc_amt_88max,
															double? chq_reg_mth_misc_amt_89min,
															double? chq_reg_mth_misc_amt_89max,
															double? chq_reg_mth_misc_amt_810min,
															double? chq_reg_mth_misc_amt_810max,
															double? chq_reg_mth_misc_amt_811min,
															double? chq_reg_mth_misc_amt_811max,
															double? chq_reg_mth_misc_amt_812min,
															double? chq_reg_mth_misc_amt_812max,
															double? chq_reg_mth_misc_amt_813min,
															double? chq_reg_mth_misc_amt_813max,
															double? chq_reg_mth_misc_amt_814min,
															double? chq_reg_mth_misc_amt_814max,
															double? chq_reg_mth_misc_amt_815min,
															double? chq_reg_mth_misc_amt_815max,
															double? chq_reg_mth_misc_amt_816min,
															double? chq_reg_mth_misc_amt_816max,
															double? chq_reg_mth_misc_amt_817min,
															double? chq_reg_mth_misc_amt_817max,
															double? chq_reg_mth_misc_amt_818min,
															double? chq_reg_mth_misc_amt_818max,
															double? chq_reg_mth_misc_amt_91min,
															double? chq_reg_mth_misc_amt_91max,
															double? chq_reg_mth_misc_amt_92min,
															double? chq_reg_mth_misc_amt_92max,
															double? chq_reg_mth_misc_amt_93min,
															double? chq_reg_mth_misc_amt_93max,
															double? chq_reg_mth_misc_amt_94min,
															double? chq_reg_mth_misc_amt_94max,
															double? chq_reg_mth_misc_amt_95min,
															double? chq_reg_mth_misc_amt_95max,
															double? chq_reg_mth_misc_amt_96min,
															double? chq_reg_mth_misc_amt_96max,
															double? chq_reg_mth_misc_amt_97min,
															double? chq_reg_mth_misc_amt_97max,
															double? chq_reg_mth_misc_amt_98min,
															double? chq_reg_mth_misc_amt_98max,
															double? chq_reg_mth_misc_amt_99min,
															double? chq_reg_mth_misc_amt_99max,
															double? chq_reg_mth_misc_amt_910min,
															double? chq_reg_mth_misc_amt_910max,
															double? chq_reg_mth_misc_amt_911min,
															double? chq_reg_mth_misc_amt_911max,
															double? chq_reg_mth_misc_amt_912min,
															double? chq_reg_mth_misc_amt_912max,
															double? chq_reg_mth_misc_amt_913min,
															double? chq_reg_mth_misc_amt_913max,
															double? chq_reg_mth_misc_amt_914min,
															double? chq_reg_mth_misc_amt_914max,
															double? chq_reg_mth_misc_amt_915min,
															double? chq_reg_mth_misc_amt_915max,
															double? chq_reg_mth_misc_amt_916min,
															double? chq_reg_mth_misc_amt_916max,
															double? chq_reg_mth_misc_amt_917min,
															double? chq_reg_mth_misc_amt_917max,
															double? chq_reg_mth_misc_amt_918min,
															double? chq_reg_mth_misc_amt_918max,
															double? chq_reg_mth_misc_amt_101min,
															double? chq_reg_mth_misc_amt_101max,
															double? chq_reg_mth_misc_amt_102min,
															double? chq_reg_mth_misc_amt_102max,
															double? chq_reg_mth_misc_amt_103min,
															double? chq_reg_mth_misc_amt_103max,
															double? chq_reg_mth_misc_amt_104min,
															double? chq_reg_mth_misc_amt_104max,
															double? chq_reg_mth_misc_amt_105min,
															double? chq_reg_mth_misc_amt_105max,
															double? chq_reg_mth_misc_amt_106min,
															double? chq_reg_mth_misc_amt_106max,
															double? chq_reg_mth_misc_amt_107min,
															double? chq_reg_mth_misc_amt_107max,
															double? chq_reg_mth_misc_amt_108min,
															double? chq_reg_mth_misc_amt_108max,
															double? chq_reg_mth_misc_amt_109min,
															double? chq_reg_mth_misc_amt_109max,
															double? chq_reg_mth_misc_amt_1010min,
															double? chq_reg_mth_misc_amt_1010max,
															double? chq_reg_mth_misc_amt_1011min,
															double? chq_reg_mth_misc_amt_1011max,
															double? chq_reg_mth_misc_amt_1012min,
															double? chq_reg_mth_misc_amt_1012max,
															double? chq_reg_mth_misc_amt_1013min,
															double? chq_reg_mth_misc_amt_1013max,
															double? chq_reg_mth_misc_amt_1014min,
															double? chq_reg_mth_misc_amt_1014max,
															double? chq_reg_mth_misc_amt_1015min,
															double? chq_reg_mth_misc_amt_1015max,
															double? chq_reg_mth_misc_amt_1016min,
															double? chq_reg_mth_misc_amt_1016max,
															double? chq_reg_mth_misc_amt_1017min,
															double? chq_reg_mth_misc_amt_1017max,
															double? chq_reg_mth_misc_amt_1018min,
															double? chq_reg_mth_misc_amt_1018max,
															double? chq_reg_mth_exp_amt1min,
															double? chq_reg_mth_exp_amt1max,
															double? chq_reg_mth_exp_amt2min,
															double? chq_reg_mth_exp_amt2max,
															double? chq_reg_mth_exp_amt3min,
															double? chq_reg_mth_exp_amt3max,
															double? chq_reg_mth_exp_amt4min,
															double? chq_reg_mth_exp_amt4max,
															double? chq_reg_mth_exp_amt5min,
															double? chq_reg_mth_exp_amt5max,
															double? chq_reg_mth_exp_amt6min,
															double? chq_reg_mth_exp_amt6max,
															double? chq_reg_mth_exp_amt7min,
															double? chq_reg_mth_exp_amt7max,
															double? chq_reg_mth_exp_amt8min,
															double? chq_reg_mth_exp_amt8max,
															double? chq_reg_mth_exp_amt9min,
															double? chq_reg_mth_exp_amt9max,
															double? chq_reg_mth_exp_amt10min,
															double? chq_reg_mth_exp_amt10max,
															double? chq_reg_mth_exp_amt11min,
															double? chq_reg_mth_exp_amt11max,
															double? chq_reg_mth_exp_amt12min,
															double? chq_reg_mth_exp_amt12max,
															double? chq_reg_mth_exp_amt13min,
															double? chq_reg_mth_exp_amt13max,
															double? chq_reg_mth_exp_amt14min,
															double? chq_reg_mth_exp_amt14max,
															double? chq_reg_mth_exp_amt15min,
															double? chq_reg_mth_exp_amt15max,
															double? chq_reg_mth_exp_amt16min,
															double? chq_reg_mth_exp_amt16max,
															double? chq_reg_mth_exp_amt17min,
															double? chq_reg_mth_exp_amt17max,
															double? chq_reg_mth_exp_amt18min,
															double? chq_reg_mth_exp_amt18max,
															double? chq_reg_comp_ann_exp_this_pay1min,
															double? chq_reg_comp_ann_exp_this_pay1max,
															double? chq_reg_comp_ann_exp_this_pay2min,
															double? chq_reg_comp_ann_exp_this_pay2max,
															double? chq_reg_comp_ann_exp_this_pay3min,
															double? chq_reg_comp_ann_exp_this_pay3max,
															double? chq_reg_comp_ann_exp_this_pay4min,
															double? chq_reg_comp_ann_exp_this_pay4max,
															double? chq_reg_comp_ann_exp_this_pay5min,
															double? chq_reg_comp_ann_exp_this_pay5max,
															double? chq_reg_comp_ann_exp_this_pay6min,
															double? chq_reg_comp_ann_exp_this_pay6max,
															double? chq_reg_comp_ann_exp_this_pay7min,
															double? chq_reg_comp_ann_exp_this_pay7max,
															double? chq_reg_comp_ann_exp_this_pay8min,
															double? chq_reg_comp_ann_exp_this_pay8max,
															double? chq_reg_comp_ann_exp_this_pay9min,
															double? chq_reg_comp_ann_exp_this_pay9max,
															double? chq_reg_comp_ann_exp_this_pay10min,
															double? chq_reg_comp_ann_exp_this_pay10max,
															double? chq_reg_comp_ann_exp_this_pay11min,
															double? chq_reg_comp_ann_exp_this_pay11max,
															double? chq_reg_comp_ann_exp_this_pay12min,
															double? chq_reg_comp_ann_exp_this_pay12max,
															double? chq_reg_comp_ann_exp_this_pay13min,
															double? chq_reg_comp_ann_exp_this_pay13max,
															double? chq_reg_comp_ann_exp_this_pay14min,
															double? chq_reg_comp_ann_exp_this_pay14max,
															double? chq_reg_comp_ann_exp_this_pay15min,
															double? chq_reg_comp_ann_exp_this_pay15max,
															double? chq_reg_comp_ann_exp_this_pay16min,
															double? chq_reg_comp_ann_exp_this_pay16max,
															double? chq_reg_comp_ann_exp_this_pay17min,
															double? chq_reg_comp_ann_exp_this_pay17max,
															double? chq_reg_comp_ann_exp_this_pay18min,
															double? chq_reg_comp_ann_exp_this_pay18max,
															double? chq_reg_mth_ceil_amt1min,
															double? chq_reg_mth_ceil_amt1max,
															double? chq_reg_mth_ceil_amt2min,
															double? chq_reg_mth_ceil_amt2max,
															double? chq_reg_mth_ceil_amt3min,
															double? chq_reg_mth_ceil_amt3max,
															double? chq_reg_mth_ceil_amt4min,
															double? chq_reg_mth_ceil_amt4max,
															double? chq_reg_mth_ceil_amt5min,
															double? chq_reg_mth_ceil_amt5max,
															double? chq_reg_mth_ceil_amt6min,
															double? chq_reg_mth_ceil_amt6max,
															double? chq_reg_mth_ceil_amt7min,
															double? chq_reg_mth_ceil_amt7max,
															double? chq_reg_mth_ceil_amt8min,
															double? chq_reg_mth_ceil_amt8max,
															double? chq_reg_mth_ceil_amt9min,
															double? chq_reg_mth_ceil_amt9max,
															double? chq_reg_mth_ceil_amt10min,
															double? chq_reg_mth_ceil_amt10max,
															double? chq_reg_mth_ceil_amt11min,
															double? chq_reg_mth_ceil_amt11max,
															double? chq_reg_mth_ceil_amt12min,
															double? chq_reg_mth_ceil_amt12max,
															double? chq_reg_mth_ceil_amt13min,
															double? chq_reg_mth_ceil_amt13max,
															double? chq_reg_mth_ceil_amt14min,
															double? chq_reg_mth_ceil_amt14max,
															double? chq_reg_mth_ceil_amt15min,
															double? chq_reg_mth_ceil_amt15max,
															double? chq_reg_mth_ceil_amt16min,
															double? chq_reg_mth_ceil_amt16max,
															double? chq_reg_mth_ceil_amt17min,
															double? chq_reg_mth_ceil_amt17max,
															double? chq_reg_mth_ceil_amt18min,
															double? chq_reg_mth_ceil_amt18max,
															double? chq_reg_comp_ann_ceil_this_pay1min,
															double? chq_reg_comp_ann_ceil_this_pay1max,
															double? chq_reg_comp_ann_ceil_this_pay2min,
															double? chq_reg_comp_ann_ceil_this_pay2max,
															double? chq_reg_comp_ann_ceil_this_pay3min,
															double? chq_reg_comp_ann_ceil_this_pay3max,
															double? chq_reg_comp_ann_ceil_this_pay4min,
															double? chq_reg_comp_ann_ceil_this_pay4max,
															double? chq_reg_comp_ann_ceil_this_pay5min,
															double? chq_reg_comp_ann_ceil_this_pay5max,
															double? chq_reg_comp_ann_ceil_this_pay6min,
															double? chq_reg_comp_ann_ceil_this_pay6max,
															double? chq_reg_comp_ann_ceil_this_pay7min,
															double? chq_reg_comp_ann_ceil_this_pay7max,
															double? chq_reg_comp_ann_ceil_this_pay8min,
															double? chq_reg_comp_ann_ceil_this_pay8max,
															double? chq_reg_comp_ann_ceil_this_pay9min,
															double? chq_reg_comp_ann_ceil_this_pay9max,
															double? chq_reg_comp_ann_ceil_this_pay10min,
															double? chq_reg_comp_ann_ceil_this_pay10max,
															double? chq_reg_comp_ann_ceil_this_pay11min,
															double? chq_reg_comp_ann_ceil_this_pay11max,
															double? chq_reg_comp_ann_ceil_this_pay12min,
															double? chq_reg_comp_ann_ceil_this_pay12max,
															double? chq_reg_comp_ann_ceil_this_pay13min,
															double? chq_reg_comp_ann_ceil_this_pay13max,
															double? chq_reg_comp_ann_ceil_this_pay14min,
															double? chq_reg_comp_ann_ceil_this_pay14max,
															double? chq_reg_comp_ann_ceil_this_pay15min,
															double? chq_reg_comp_ann_ceil_this_pay15max,
															double? chq_reg_comp_ann_ceil_this_pay16min,
															double? chq_reg_comp_ann_ceil_this_pay16max,
															double? chq_reg_comp_ann_ceil_this_pay17min,
															double? chq_reg_comp_ann_ceil_this_pay17max,
															double? chq_reg_comp_ann_ceil_this_pay18min,
															double? chq_reg_comp_ann_ceil_this_pay18max,
															double? chq_reg_earnings_this_mth1min,
															double? chq_reg_earnings_this_mth1max,
															double? chq_reg_earnings_this_mth2min,
															double? chq_reg_earnings_this_mth2max,
															double? chq_reg_earnings_this_mth3min,
															double? chq_reg_earnings_this_mth3max,
															double? chq_reg_earnings_this_mth4min,
															double? chq_reg_earnings_this_mth4max,
															double? chq_reg_earnings_this_mth5min,
															double? chq_reg_earnings_this_mth5max,
															double? chq_reg_earnings_this_mth6min,
															double? chq_reg_earnings_this_mth6max,
															double? chq_reg_earnings_this_mth7min,
															double? chq_reg_earnings_this_mth7max,
															double? chq_reg_earnings_this_mth8min,
															double? chq_reg_earnings_this_mth8max,
															double? chq_reg_earnings_this_mth9min,
															double? chq_reg_earnings_this_mth9max,
															double? chq_reg_earnings_this_mth10min,
															double? chq_reg_earnings_this_mth10max,
															double? chq_reg_earnings_this_mth11min,
															double? chq_reg_earnings_this_mth11max,
															double? chq_reg_earnings_this_mth12min,
															double? chq_reg_earnings_this_mth12max,
															double? chq_reg_earnings_this_mth13min,
															double? chq_reg_earnings_this_mth13max,
															double? chq_reg_earnings_this_mth14min,
															double? chq_reg_earnings_this_mth14max,
															double? chq_reg_earnings_this_mth15min,
															double? chq_reg_earnings_this_mth15max,
															double? chq_reg_earnings_this_mth16min,
															double? chq_reg_earnings_this_mth16max,
															double? chq_reg_earnings_this_mth17min,
															double? chq_reg_earnings_this_mth17max,
															double? chq_reg_earnings_this_mth18min,
															double? chq_reg_earnings_this_mth18max,
															double? chq_reg_regular_pay_this_mth1min,
															double? chq_reg_regular_pay_this_mth1max,
															double? chq_reg_regular_pay_this_mth2min,
															double? chq_reg_regular_pay_this_mth2max,
															double? chq_reg_regular_pay_this_mth3min,
															double? chq_reg_regular_pay_this_mth3max,
															double? chq_reg_regular_pay_this_mth4min,
															double? chq_reg_regular_pay_this_mth4max,
															double? chq_reg_regular_pay_this_mth5min,
															double? chq_reg_regular_pay_this_mth5max,
															double? chq_reg_regular_pay_this_mth6min,
															double? chq_reg_regular_pay_this_mth6max,
															double? chq_reg_regular_pay_this_mth7min,
															double? chq_reg_regular_pay_this_mth7max,
															double? chq_reg_regular_pay_this_mth8min,
															double? chq_reg_regular_pay_this_mth8max,
															double? chq_reg_regular_pay_this_mth9min,
															double? chq_reg_regular_pay_this_mth9max,
															double? chq_reg_regular_pay_this_mth10min,
															double? chq_reg_regular_pay_this_mth10max,
															double? chq_reg_regular_pay_this_mth11min,
															double? chq_reg_regular_pay_this_mth11max,
															double? chq_reg_regular_pay_this_mth12min,
															double? chq_reg_regular_pay_this_mth12max,
															double? chq_reg_regular_pay_this_mth13min,
															double? chq_reg_regular_pay_this_mth13max,
															double? chq_reg_regular_pay_this_mth14min,
															double? chq_reg_regular_pay_this_mth14max,
															double? chq_reg_regular_pay_this_mth15min,
															double? chq_reg_regular_pay_this_mth15max,
															double? chq_reg_regular_pay_this_mth16min,
															double? chq_reg_regular_pay_this_mth16max,
															double? chq_reg_regular_pay_this_mth17min,
															double? chq_reg_regular_pay_this_mth17max,
															double? chq_reg_regular_pay_this_mth18min,
															double? chq_reg_regular_pay_this_mth18max,
															double? chq_reg_regular_tax_this_mth1min,
															double? chq_reg_regular_tax_this_mth1max,
															double? chq_reg_regular_tax_this_mth2min,
															double? chq_reg_regular_tax_this_mth2max,
															double? chq_reg_regular_tax_this_mth3min,
															double? chq_reg_regular_tax_this_mth3max,
															double? chq_reg_regular_tax_this_mth4min,
															double? chq_reg_regular_tax_this_mth4max,
															double? chq_reg_regular_tax_this_mth5min,
															double? chq_reg_regular_tax_this_mth5max,
															double? chq_reg_regular_tax_this_mth6min,
															double? chq_reg_regular_tax_this_mth6max,
															double? chq_reg_regular_tax_this_mth7min,
															double? chq_reg_regular_tax_this_mth7max,
															double? chq_reg_regular_tax_this_mth8min,
															double? chq_reg_regular_tax_this_mth8max,
															double? chq_reg_regular_tax_this_mth9min,
															double? chq_reg_regular_tax_this_mth9max,
															double? chq_reg_regular_tax_this_mth10min,
															double? chq_reg_regular_tax_this_mth10max,
															double? chq_reg_regular_tax_this_mth11min,
															double? chq_reg_regular_tax_this_mth11max,
															double? chq_reg_regular_tax_this_mth12min,
															double? chq_reg_regular_tax_this_mth12max,
															double? chq_reg_regular_tax_this_mth13min,
															double? chq_reg_regular_tax_this_mth13max,
															double? chq_reg_regular_tax_this_mth14min,
															double? chq_reg_regular_tax_this_mth14max,
															double? chq_reg_regular_tax_this_mth15min,
															double? chq_reg_regular_tax_this_mth15max,
															double? chq_reg_regular_tax_this_mth16min,
															double? chq_reg_regular_tax_this_mth16max,
															double? chq_reg_regular_tax_this_mth17min,
															double? chq_reg_regular_tax_this_mth17max,
															double? chq_reg_regular_tax_this_mth18min,
															double? chq_reg_regular_tax_this_mth18max,
															double? chq_reg_man_pay_this_mth1min,
															double? chq_reg_man_pay_this_mth1max,
															double? chq_reg_man_pay_this_mth2min,
															double? chq_reg_man_pay_this_mth2max,
															double? chq_reg_man_pay_this_mth3min,
															double? chq_reg_man_pay_this_mth3max,
															double? chq_reg_man_pay_this_mth4min,
															double? chq_reg_man_pay_this_mth4max,
															double? chq_reg_man_pay_this_mth5min,
															double? chq_reg_man_pay_this_mth5max,
															double? chq_reg_man_pay_this_mth6min,
															double? chq_reg_man_pay_this_mth6max,
															double? chq_reg_man_pay_this_mth7min,
															double? chq_reg_man_pay_this_mth7max,
															double? chq_reg_man_pay_this_mth8min,
															double? chq_reg_man_pay_this_mth8max,
															double? chq_reg_man_pay_this_mth9min,
															double? chq_reg_man_pay_this_mth9max,
															double? chq_reg_man_pay_this_mth10min,
															double? chq_reg_man_pay_this_mth10max,
															double? chq_reg_man_pay_this_mth11min,
															double? chq_reg_man_pay_this_mth11max,
															double? chq_reg_man_pay_this_mth12min,
															double? chq_reg_man_pay_this_mth12max,
															double? chq_reg_man_pay_this_mth13min,
															double? chq_reg_man_pay_this_mth13max,
															double? chq_reg_man_pay_this_mth14min,
															double? chq_reg_man_pay_this_mth14max,
															double? chq_reg_man_pay_this_mth15min,
															double? chq_reg_man_pay_this_mth15max,
															double? chq_reg_man_pay_this_mth16min,
															double? chq_reg_man_pay_this_mth16max,
															double? chq_reg_man_pay_this_mth17min,
															double? chq_reg_man_pay_this_mth17max,
															double? chq_reg_man_pay_this_mth18min,
															double? chq_reg_man_pay_this_mth18max,
															double? chq_reg_man_tax_this_mth1min,
															double? chq_reg_man_tax_this_mth1max,
															double? chq_reg_man_tax_this_mth2min,
															double? chq_reg_man_tax_this_mth2max,
															double? chq_reg_man_tax_this_mth3min,
															double? chq_reg_man_tax_this_mth3max,
															double? chq_reg_man_tax_this_mth4min,
															double? chq_reg_man_tax_this_mth4max,
															double? chq_reg_man_tax_this_mth5min,
															double? chq_reg_man_tax_this_mth5max,
															double? chq_reg_man_tax_this_mth6min,
															double? chq_reg_man_tax_this_mth6max,
															double? chq_reg_man_tax_this_mth7min,
															double? chq_reg_man_tax_this_mth7max,
															double? chq_reg_man_tax_this_mth8min,
															double? chq_reg_man_tax_this_mth8max,
															double? chq_reg_man_tax_this_mth9min,
															double? chq_reg_man_tax_this_mth9max,
															double? chq_reg_man_tax_this_mth10min,
															double? chq_reg_man_tax_this_mth10max,
															double? chq_reg_man_tax_this_mth11min,
															double? chq_reg_man_tax_this_mth11max,
															double? chq_reg_man_tax_this_mth12min,
															double? chq_reg_man_tax_this_mth12max,
															double? chq_reg_man_tax_this_mth13min,
															double? chq_reg_man_tax_this_mth13max,
															double? chq_reg_man_tax_this_mth14min,
															double? chq_reg_man_tax_this_mth14max,
															double? chq_reg_man_tax_this_mth15min,
															double? chq_reg_man_tax_this_mth15max,
															double? chq_reg_man_tax_this_mth16min,
															double? chq_reg_man_tax_this_mth16max,
															double? chq_reg_man_tax_this_mth17min,
															double? chq_reg_man_tax_this_mth17max,
															double? chq_reg_man_tax_this_mth18min,
															double? chq_reg_man_tax_this_mth18max,
															decimal? chq_reg_pay_date1min,
															decimal? chq_reg_pay_date1max,
															decimal? chq_reg_pay_date2min,
															decimal? chq_reg_pay_date2max,
															decimal? chq_reg_pay_date3min,
															decimal? chq_reg_pay_date3max,
															decimal? chq_reg_pay_date4min,
															decimal? chq_reg_pay_date4max,
															decimal? chq_reg_pay_date5min,
															decimal? chq_reg_pay_date5max,
															decimal? chq_reg_pay_date6min,
															decimal? chq_reg_pay_date6max,
															decimal? chq_reg_pay_date7min,
															decimal? chq_reg_pay_date7max,
															decimal? chq_reg_pay_date8min,
															decimal? chq_reg_pay_date8max,
															decimal? chq_reg_pay_date9min,
															decimal? chq_reg_pay_date9max,
															decimal? chq_reg_pay_date10min,
															decimal? chq_reg_pay_date10max,
															decimal? chq_reg_pay_date11min,
															decimal? chq_reg_pay_date11max,
															decimal? chq_reg_pay_date12min,
															decimal? chq_reg_pay_date12max,
															decimal? chq_reg_pay_date13min,
															decimal? chq_reg_pay_date13max,
															decimal? chq_reg_pay_date14min,
															decimal? chq_reg_pay_date14max,
															decimal? chq_reg_pay_date15min,
															decimal? chq_reg_pay_date15max,
															decimal? chq_reg_pay_date16min,
															decimal? chq_reg_pay_date16max,
															decimal? chq_reg_pay_date17min,
															decimal? chq_reg_pay_date17max,
															decimal? chq_reg_pay_date18min,
															decimal? chq_reg_pay_date18max,
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
					new SqlParameter("minCHQ_REG_CLINIC_NBR_1_2",chq_reg_clinic_nbr_1_2min),
					new SqlParameter("maxCHQ_REG_CLINIC_NBR_1_2",chq_reg_clinic_nbr_1_2max),
					new SqlParameter("minCHQ_REG_DEPT",chq_reg_deptmin),
					new SqlParameter("maxCHQ_REG_DEPT",chq_reg_deptmax),
					new SqlParameter("CHQ_REG_DOC_NBR",chq_reg_doc_nbr),
					new SqlParameter("minCHQ_REG_PERC_BILL1",chq_reg_perc_bill1min),
					new SqlParameter("maxCHQ_REG_PERC_BILL1",chq_reg_perc_bill1max),
					new SqlParameter("minCHQ_REG_PERC_BILL2",chq_reg_perc_bill2min),
					new SqlParameter("maxCHQ_REG_PERC_BILL2",chq_reg_perc_bill2max),
					new SqlParameter("minCHQ_REG_PERC_BILL3",chq_reg_perc_bill3min),
					new SqlParameter("maxCHQ_REG_PERC_BILL3",chq_reg_perc_bill3max),
					new SqlParameter("minCHQ_REG_PERC_BILL4",chq_reg_perc_bill4min),
					new SqlParameter("maxCHQ_REG_PERC_BILL4",chq_reg_perc_bill4max),
					new SqlParameter("minCHQ_REG_PERC_BILL5",chq_reg_perc_bill5min),
					new SqlParameter("maxCHQ_REG_PERC_BILL5",chq_reg_perc_bill5max),
					new SqlParameter("minCHQ_REG_PERC_BILL6",chq_reg_perc_bill6min),
					new SqlParameter("maxCHQ_REG_PERC_BILL6",chq_reg_perc_bill6max),
					new SqlParameter("minCHQ_REG_PERC_BILL7",chq_reg_perc_bill7min),
					new SqlParameter("maxCHQ_REG_PERC_BILL7",chq_reg_perc_bill7max),
					new SqlParameter("minCHQ_REG_PERC_BILL8",chq_reg_perc_bill8min),
					new SqlParameter("maxCHQ_REG_PERC_BILL8",chq_reg_perc_bill8max),
					new SqlParameter("minCHQ_REG_PERC_BILL9",chq_reg_perc_bill9min),
					new SqlParameter("maxCHQ_REG_PERC_BILL9",chq_reg_perc_bill9max),
					new SqlParameter("minCHQ_REG_PERC_BILL10",chq_reg_perc_bill10min),
					new SqlParameter("maxCHQ_REG_PERC_BILL10",chq_reg_perc_bill10max),
					new SqlParameter("minCHQ_REG_PERC_BILL11",chq_reg_perc_bill11min),
					new SqlParameter("maxCHQ_REG_PERC_BILL11",chq_reg_perc_bill11max),
					new SqlParameter("minCHQ_REG_PERC_BILL12",chq_reg_perc_bill12min),
					new SqlParameter("maxCHQ_REG_PERC_BILL12",chq_reg_perc_bill12max),
					new SqlParameter("minCHQ_REG_PERC_BILL13",chq_reg_perc_bill13min),
					new SqlParameter("maxCHQ_REG_PERC_BILL13",chq_reg_perc_bill13max),
					new SqlParameter("minCHQ_REG_PERC_BILL14",chq_reg_perc_bill14min),
					new SqlParameter("maxCHQ_REG_PERC_BILL14",chq_reg_perc_bill14max),
					new SqlParameter("minCHQ_REG_PERC_BILL15",chq_reg_perc_bill15min),
					new SqlParameter("maxCHQ_REG_PERC_BILL15",chq_reg_perc_bill15max),
					new SqlParameter("minCHQ_REG_PERC_BILL16",chq_reg_perc_bill16min),
					new SqlParameter("maxCHQ_REG_PERC_BILL16",chq_reg_perc_bill16max),
					new SqlParameter("minCHQ_REG_PERC_BILL17",chq_reg_perc_bill17min),
					new SqlParameter("maxCHQ_REG_PERC_BILL17",chq_reg_perc_bill17max),
					new SqlParameter("minCHQ_REG_PERC_BILL18",chq_reg_perc_bill18min),
					new SqlParameter("maxCHQ_REG_PERC_BILL18",chq_reg_perc_bill18max),
					new SqlParameter("minCHQ_REG_PERC_MISC1",chq_reg_perc_misc1min),
					new SqlParameter("maxCHQ_REG_PERC_MISC1",chq_reg_perc_misc1max),
					new SqlParameter("minCHQ_REG_PERC_MISC2",chq_reg_perc_misc2min),
					new SqlParameter("maxCHQ_REG_PERC_MISC2",chq_reg_perc_misc2max),
					new SqlParameter("minCHQ_REG_PERC_MISC3",chq_reg_perc_misc3min),
					new SqlParameter("maxCHQ_REG_PERC_MISC3",chq_reg_perc_misc3max),
					new SqlParameter("minCHQ_REG_PERC_MISC4",chq_reg_perc_misc4min),
					new SqlParameter("maxCHQ_REG_PERC_MISC4",chq_reg_perc_misc4max),
					new SqlParameter("minCHQ_REG_PERC_MISC5",chq_reg_perc_misc5min),
					new SqlParameter("maxCHQ_REG_PERC_MISC5",chq_reg_perc_misc5max),
					new SqlParameter("minCHQ_REG_PERC_MISC6",chq_reg_perc_misc6min),
					new SqlParameter("maxCHQ_REG_PERC_MISC6",chq_reg_perc_misc6max),
					new SqlParameter("minCHQ_REG_PERC_MISC7",chq_reg_perc_misc7min),
					new SqlParameter("maxCHQ_REG_PERC_MISC7",chq_reg_perc_misc7max),
					new SqlParameter("minCHQ_REG_PERC_MISC8",chq_reg_perc_misc8min),
					new SqlParameter("maxCHQ_REG_PERC_MISC8",chq_reg_perc_misc8max),
					new SqlParameter("minCHQ_REG_PERC_MISC9",chq_reg_perc_misc9min),
					new SqlParameter("maxCHQ_REG_PERC_MISC9",chq_reg_perc_misc9max),
					new SqlParameter("minCHQ_REG_PERC_MISC10",chq_reg_perc_misc10min),
					new SqlParameter("maxCHQ_REG_PERC_MISC10",chq_reg_perc_misc10max),
					new SqlParameter("minCHQ_REG_PERC_MISC11",chq_reg_perc_misc11min),
					new SqlParameter("maxCHQ_REG_PERC_MISC11",chq_reg_perc_misc11max),
					new SqlParameter("minCHQ_REG_PERC_MISC12",chq_reg_perc_misc12min),
					new SqlParameter("maxCHQ_REG_PERC_MISC12",chq_reg_perc_misc12max),
					new SqlParameter("minCHQ_REG_PERC_MISC13",chq_reg_perc_misc13min),
					new SqlParameter("maxCHQ_REG_PERC_MISC13",chq_reg_perc_misc13max),
					new SqlParameter("minCHQ_REG_PERC_MISC14",chq_reg_perc_misc14min),
					new SqlParameter("maxCHQ_REG_PERC_MISC14",chq_reg_perc_misc14max),
					new SqlParameter("minCHQ_REG_PERC_MISC15",chq_reg_perc_misc15min),
					new SqlParameter("maxCHQ_REG_PERC_MISC15",chq_reg_perc_misc15max),
					new SqlParameter("minCHQ_REG_PERC_MISC16",chq_reg_perc_misc16min),
					new SqlParameter("maxCHQ_REG_PERC_MISC16",chq_reg_perc_misc16max),
					new SqlParameter("minCHQ_REG_PERC_MISC17",chq_reg_perc_misc17min),
					new SqlParameter("maxCHQ_REG_PERC_MISC17",chq_reg_perc_misc17max),
					new SqlParameter("minCHQ_REG_PERC_MISC18",chq_reg_perc_misc18min),
					new SqlParameter("maxCHQ_REG_PERC_MISC18",chq_reg_perc_misc18max),
					new SqlParameter("CHQ_REG_PAY_CODE1",chq_reg_pay_code1),
					new SqlParameter("CHQ_REG_PAY_CODE2",chq_reg_pay_code2),
					new SqlParameter("CHQ_REG_PAY_CODE3",chq_reg_pay_code3),
					new SqlParameter("CHQ_REG_PAY_CODE4",chq_reg_pay_code4),
					new SqlParameter("CHQ_REG_PAY_CODE5",chq_reg_pay_code5),
					new SqlParameter("CHQ_REG_PAY_CODE6",chq_reg_pay_code6),
					new SqlParameter("CHQ_REG_PAY_CODE7",chq_reg_pay_code7),
					new SqlParameter("CHQ_REG_PAY_CODE8",chq_reg_pay_code8),
					new SqlParameter("CHQ_REG_PAY_CODE9",chq_reg_pay_code9),
					new SqlParameter("CHQ_REG_PAY_CODE10",chq_reg_pay_code10),
					new SqlParameter("CHQ_REG_PAY_CODE11",chq_reg_pay_code11),
					new SqlParameter("CHQ_REG_PAY_CODE12",chq_reg_pay_code12),
					new SqlParameter("CHQ_REG_PAY_CODE13",chq_reg_pay_code13),
					new SqlParameter("CHQ_REG_PAY_CODE14",chq_reg_pay_code14),
					new SqlParameter("CHQ_REG_PAY_CODE15",chq_reg_pay_code15),
					new SqlParameter("CHQ_REG_PAY_CODE16",chq_reg_pay_code16),
					new SqlParameter("CHQ_REG_PAY_CODE17",chq_reg_pay_code17),
					new SqlParameter("CHQ_REG_PAY_CODE18",chq_reg_pay_code18),
					new SqlParameter("minCHQ_REG_PERC_TAX1",chq_reg_perc_tax1min),
					new SqlParameter("maxCHQ_REG_PERC_TAX1",chq_reg_perc_tax1max),
					new SqlParameter("minCHQ_REG_PERC_TAX2",chq_reg_perc_tax2min),
					new SqlParameter("maxCHQ_REG_PERC_TAX2",chq_reg_perc_tax2max),
					new SqlParameter("minCHQ_REG_PERC_TAX3",chq_reg_perc_tax3min),
					new SqlParameter("maxCHQ_REG_PERC_TAX3",chq_reg_perc_tax3max),
					new SqlParameter("minCHQ_REG_PERC_TAX4",chq_reg_perc_tax4min),
					new SqlParameter("maxCHQ_REG_PERC_TAX4",chq_reg_perc_tax4max),
					new SqlParameter("minCHQ_REG_PERC_TAX5",chq_reg_perc_tax5min),
					new SqlParameter("maxCHQ_REG_PERC_TAX5",chq_reg_perc_tax5max),
					new SqlParameter("minCHQ_REG_PERC_TAX6",chq_reg_perc_tax6min),
					new SqlParameter("maxCHQ_REG_PERC_TAX6",chq_reg_perc_tax6max),
					new SqlParameter("minCHQ_REG_PERC_TAX7",chq_reg_perc_tax7min),
					new SqlParameter("maxCHQ_REG_PERC_TAX7",chq_reg_perc_tax7max),
					new SqlParameter("minCHQ_REG_PERC_TAX8",chq_reg_perc_tax8min),
					new SqlParameter("maxCHQ_REG_PERC_TAX8",chq_reg_perc_tax8max),
					new SqlParameter("minCHQ_REG_PERC_TAX9",chq_reg_perc_tax9min),
					new SqlParameter("maxCHQ_REG_PERC_TAX9",chq_reg_perc_tax9max),
					new SqlParameter("minCHQ_REG_PERC_TAX10",chq_reg_perc_tax10min),
					new SqlParameter("maxCHQ_REG_PERC_TAX10",chq_reg_perc_tax10max),
					new SqlParameter("minCHQ_REG_PERC_TAX11",chq_reg_perc_tax11min),
					new SqlParameter("maxCHQ_REG_PERC_TAX11",chq_reg_perc_tax11max),
					new SqlParameter("minCHQ_REG_PERC_TAX12",chq_reg_perc_tax12min),
					new SqlParameter("maxCHQ_REG_PERC_TAX12",chq_reg_perc_tax12max),
					new SqlParameter("minCHQ_REG_PERC_TAX13",chq_reg_perc_tax13min),
					new SqlParameter("maxCHQ_REG_PERC_TAX13",chq_reg_perc_tax13max),
					new SqlParameter("minCHQ_REG_PERC_TAX14",chq_reg_perc_tax14min),
					new SqlParameter("maxCHQ_REG_PERC_TAX14",chq_reg_perc_tax14max),
					new SqlParameter("minCHQ_REG_PERC_TAX15",chq_reg_perc_tax15min),
					new SqlParameter("maxCHQ_REG_PERC_TAX15",chq_reg_perc_tax15max),
					new SqlParameter("minCHQ_REG_PERC_TAX16",chq_reg_perc_tax16min),
					new SqlParameter("maxCHQ_REG_PERC_TAX16",chq_reg_perc_tax16max),
					new SqlParameter("minCHQ_REG_PERC_TAX17",chq_reg_perc_tax17min),
					new SqlParameter("maxCHQ_REG_PERC_TAX17",chq_reg_perc_tax17max),
					new SqlParameter("minCHQ_REG_PERC_TAX18",chq_reg_perc_tax18min),
					new SqlParameter("maxCHQ_REG_PERC_TAX18",chq_reg_perc_tax18max),
					new SqlParameter("minCHQ_REG_MTH_BILL_AMT1",chq_reg_mth_bill_amt1min),
					new SqlParameter("maxCHQ_REG_MTH_BILL_AMT1",chq_reg_mth_bill_amt1max),
					new SqlParameter("minCHQ_REG_MTH_BILL_AMT2",chq_reg_mth_bill_amt2min),
					new SqlParameter("maxCHQ_REG_MTH_BILL_AMT2",chq_reg_mth_bill_amt2max),
					new SqlParameter("minCHQ_REG_MTH_BILL_AMT3",chq_reg_mth_bill_amt3min),
					new SqlParameter("maxCHQ_REG_MTH_BILL_AMT3",chq_reg_mth_bill_amt3max),
					new SqlParameter("minCHQ_REG_MTH_BILL_AMT4",chq_reg_mth_bill_amt4min),
					new SqlParameter("maxCHQ_REG_MTH_BILL_AMT4",chq_reg_mth_bill_amt4max),
					new SqlParameter("minCHQ_REG_MTH_BILL_AMT5",chq_reg_mth_bill_amt5min),
					new SqlParameter("maxCHQ_REG_MTH_BILL_AMT5",chq_reg_mth_bill_amt5max),
					new SqlParameter("minCHQ_REG_MTH_BILL_AMT6",chq_reg_mth_bill_amt6min),
					new SqlParameter("maxCHQ_REG_MTH_BILL_AMT6",chq_reg_mth_bill_amt6max),
					new SqlParameter("minCHQ_REG_MTH_BILL_AMT7",chq_reg_mth_bill_amt7min),
					new SqlParameter("maxCHQ_REG_MTH_BILL_AMT7",chq_reg_mth_bill_amt7max),
					new SqlParameter("minCHQ_REG_MTH_BILL_AMT8",chq_reg_mth_bill_amt8min),
					new SqlParameter("maxCHQ_REG_MTH_BILL_AMT8",chq_reg_mth_bill_amt8max),
					new SqlParameter("minCHQ_REG_MTH_BILL_AMT9",chq_reg_mth_bill_amt9min),
					new SqlParameter("maxCHQ_REG_MTH_BILL_AMT9",chq_reg_mth_bill_amt9max),
					new SqlParameter("minCHQ_REG_MTH_BILL_AMT10",chq_reg_mth_bill_amt10min),
					new SqlParameter("maxCHQ_REG_MTH_BILL_AMT10",chq_reg_mth_bill_amt10max),
					new SqlParameter("minCHQ_REG_MTH_BILL_AMT11",chq_reg_mth_bill_amt11min),
					new SqlParameter("maxCHQ_REG_MTH_BILL_AMT11",chq_reg_mth_bill_amt11max),
					new SqlParameter("minCHQ_REG_MTH_BILL_AMT12",chq_reg_mth_bill_amt12min),
					new SqlParameter("maxCHQ_REG_MTH_BILL_AMT12",chq_reg_mth_bill_amt12max),
					new SqlParameter("minCHQ_REG_MTH_BILL_AMT13",chq_reg_mth_bill_amt13min),
					new SqlParameter("maxCHQ_REG_MTH_BILL_AMT13",chq_reg_mth_bill_amt13max),
					new SqlParameter("minCHQ_REG_MTH_BILL_AMT14",chq_reg_mth_bill_amt14min),
					new SqlParameter("maxCHQ_REG_MTH_BILL_AMT14",chq_reg_mth_bill_amt14max),
					new SqlParameter("minCHQ_REG_MTH_BILL_AMT15",chq_reg_mth_bill_amt15min),
					new SqlParameter("maxCHQ_REG_MTH_BILL_AMT15",chq_reg_mth_bill_amt15max),
					new SqlParameter("minCHQ_REG_MTH_BILL_AMT16",chq_reg_mth_bill_amt16min),
					new SqlParameter("maxCHQ_REG_MTH_BILL_AMT16",chq_reg_mth_bill_amt16max),
					new SqlParameter("minCHQ_REG_MTH_BILL_AMT17",chq_reg_mth_bill_amt17min),
					new SqlParameter("maxCHQ_REG_MTH_BILL_AMT17",chq_reg_mth_bill_amt17max),
					new SqlParameter("minCHQ_REG_MTH_BILL_AMT18",chq_reg_mth_bill_amt18min),
					new SqlParameter("maxCHQ_REG_MTH_BILL_AMT18",chq_reg_mth_bill_amt18max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_11",chq_reg_mth_misc_amt_11min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_11",chq_reg_mth_misc_amt_11max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_12",chq_reg_mth_misc_amt_12min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_12",chq_reg_mth_misc_amt_12max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_13",chq_reg_mth_misc_amt_13min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_13",chq_reg_mth_misc_amt_13max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_14",chq_reg_mth_misc_amt_14min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_14",chq_reg_mth_misc_amt_14max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_15",chq_reg_mth_misc_amt_15min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_15",chq_reg_mth_misc_amt_15max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_16",chq_reg_mth_misc_amt_16min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_16",chq_reg_mth_misc_amt_16max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_17",chq_reg_mth_misc_amt_17min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_17",chq_reg_mth_misc_amt_17max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_18",chq_reg_mth_misc_amt_18min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_18",chq_reg_mth_misc_amt_18max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_19",chq_reg_mth_misc_amt_19min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_19",chq_reg_mth_misc_amt_19max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_110",chq_reg_mth_misc_amt_110min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_110",chq_reg_mth_misc_amt_110max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_111",chq_reg_mth_misc_amt_111min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_111",chq_reg_mth_misc_amt_111max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_112",chq_reg_mth_misc_amt_112min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_112",chq_reg_mth_misc_amt_112max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_113",chq_reg_mth_misc_amt_113min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_113",chq_reg_mth_misc_amt_113max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_114",chq_reg_mth_misc_amt_114min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_114",chq_reg_mth_misc_amt_114max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_115",chq_reg_mth_misc_amt_115min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_115",chq_reg_mth_misc_amt_115max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_116",chq_reg_mth_misc_amt_116min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_116",chq_reg_mth_misc_amt_116max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_117",chq_reg_mth_misc_amt_117min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_117",chq_reg_mth_misc_amt_117max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_118",chq_reg_mth_misc_amt_118min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_118",chq_reg_mth_misc_amt_118max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_21",chq_reg_mth_misc_amt_21min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_21",chq_reg_mth_misc_amt_21max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_22",chq_reg_mth_misc_amt_22min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_22",chq_reg_mth_misc_amt_22max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_23",chq_reg_mth_misc_amt_23min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_23",chq_reg_mth_misc_amt_23max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_24",chq_reg_mth_misc_amt_24min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_24",chq_reg_mth_misc_amt_24max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_25",chq_reg_mth_misc_amt_25min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_25",chq_reg_mth_misc_amt_25max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_26",chq_reg_mth_misc_amt_26min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_26",chq_reg_mth_misc_amt_26max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_27",chq_reg_mth_misc_amt_27min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_27",chq_reg_mth_misc_amt_27max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_28",chq_reg_mth_misc_amt_28min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_28",chq_reg_mth_misc_amt_28max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_29",chq_reg_mth_misc_amt_29min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_29",chq_reg_mth_misc_amt_29max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_210",chq_reg_mth_misc_amt_210min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_210",chq_reg_mth_misc_amt_210max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_211",chq_reg_mth_misc_amt_211min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_211",chq_reg_mth_misc_amt_211max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_212",chq_reg_mth_misc_amt_212min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_212",chq_reg_mth_misc_amt_212max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_213",chq_reg_mth_misc_amt_213min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_213",chq_reg_mth_misc_amt_213max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_214",chq_reg_mth_misc_amt_214min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_214",chq_reg_mth_misc_amt_214max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_215",chq_reg_mth_misc_amt_215min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_215",chq_reg_mth_misc_amt_215max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_216",chq_reg_mth_misc_amt_216min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_216",chq_reg_mth_misc_amt_216max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_217",chq_reg_mth_misc_amt_217min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_217",chq_reg_mth_misc_amt_217max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_218",chq_reg_mth_misc_amt_218min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_218",chq_reg_mth_misc_amt_218max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_31",chq_reg_mth_misc_amt_31min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_31",chq_reg_mth_misc_amt_31max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_32",chq_reg_mth_misc_amt_32min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_32",chq_reg_mth_misc_amt_32max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_33",chq_reg_mth_misc_amt_33min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_33",chq_reg_mth_misc_amt_33max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_34",chq_reg_mth_misc_amt_34min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_34",chq_reg_mth_misc_amt_34max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_35",chq_reg_mth_misc_amt_35min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_35",chq_reg_mth_misc_amt_35max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_36",chq_reg_mth_misc_amt_36min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_36",chq_reg_mth_misc_amt_36max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_37",chq_reg_mth_misc_amt_37min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_37",chq_reg_mth_misc_amt_37max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_38",chq_reg_mth_misc_amt_38min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_38",chq_reg_mth_misc_amt_38max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_39",chq_reg_mth_misc_amt_39min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_39",chq_reg_mth_misc_amt_39max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_310",chq_reg_mth_misc_amt_310min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_310",chq_reg_mth_misc_amt_310max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_311",chq_reg_mth_misc_amt_311min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_311",chq_reg_mth_misc_amt_311max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_312",chq_reg_mth_misc_amt_312min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_312",chq_reg_mth_misc_amt_312max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_313",chq_reg_mth_misc_amt_313min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_313",chq_reg_mth_misc_amt_313max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_314",chq_reg_mth_misc_amt_314min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_314",chq_reg_mth_misc_amt_314max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_315",chq_reg_mth_misc_amt_315min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_315",chq_reg_mth_misc_amt_315max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_316",chq_reg_mth_misc_amt_316min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_316",chq_reg_mth_misc_amt_316max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_317",chq_reg_mth_misc_amt_317min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_317",chq_reg_mth_misc_amt_317max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_318",chq_reg_mth_misc_amt_318min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_318",chq_reg_mth_misc_amt_318max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_41",chq_reg_mth_misc_amt_41min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_41",chq_reg_mth_misc_amt_41max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_42",chq_reg_mth_misc_amt_42min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_42",chq_reg_mth_misc_amt_42max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_43",chq_reg_mth_misc_amt_43min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_43",chq_reg_mth_misc_amt_43max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_44",chq_reg_mth_misc_amt_44min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_44",chq_reg_mth_misc_amt_44max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_45",chq_reg_mth_misc_amt_45min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_45",chq_reg_mth_misc_amt_45max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_46",chq_reg_mth_misc_amt_46min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_46",chq_reg_mth_misc_amt_46max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_47",chq_reg_mth_misc_amt_47min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_47",chq_reg_mth_misc_amt_47max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_48",chq_reg_mth_misc_amt_48min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_48",chq_reg_mth_misc_amt_48max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_49",chq_reg_mth_misc_amt_49min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_49",chq_reg_mth_misc_amt_49max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_410",chq_reg_mth_misc_amt_410min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_410",chq_reg_mth_misc_amt_410max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_411",chq_reg_mth_misc_amt_411min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_411",chq_reg_mth_misc_amt_411max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_412",chq_reg_mth_misc_amt_412min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_412",chq_reg_mth_misc_amt_412max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_413",chq_reg_mth_misc_amt_413min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_413",chq_reg_mth_misc_amt_413max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_414",chq_reg_mth_misc_amt_414min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_414",chq_reg_mth_misc_amt_414max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_415",chq_reg_mth_misc_amt_415min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_415",chq_reg_mth_misc_amt_415max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_416",chq_reg_mth_misc_amt_416min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_416",chq_reg_mth_misc_amt_416max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_417",chq_reg_mth_misc_amt_417min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_417",chq_reg_mth_misc_amt_417max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_418",chq_reg_mth_misc_amt_418min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_418",chq_reg_mth_misc_amt_418max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_51",chq_reg_mth_misc_amt_51min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_51",chq_reg_mth_misc_amt_51max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_52",chq_reg_mth_misc_amt_52min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_52",chq_reg_mth_misc_amt_52max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_53",chq_reg_mth_misc_amt_53min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_53",chq_reg_mth_misc_amt_53max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_54",chq_reg_mth_misc_amt_54min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_54",chq_reg_mth_misc_amt_54max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_55",chq_reg_mth_misc_amt_55min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_55",chq_reg_mth_misc_amt_55max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_56",chq_reg_mth_misc_amt_56min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_56",chq_reg_mth_misc_amt_56max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_57",chq_reg_mth_misc_amt_57min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_57",chq_reg_mth_misc_amt_57max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_58",chq_reg_mth_misc_amt_58min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_58",chq_reg_mth_misc_amt_58max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_59",chq_reg_mth_misc_amt_59min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_59",chq_reg_mth_misc_amt_59max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_510",chq_reg_mth_misc_amt_510min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_510",chq_reg_mth_misc_amt_510max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_511",chq_reg_mth_misc_amt_511min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_511",chq_reg_mth_misc_amt_511max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_512",chq_reg_mth_misc_amt_512min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_512",chq_reg_mth_misc_amt_512max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_513",chq_reg_mth_misc_amt_513min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_513",chq_reg_mth_misc_amt_513max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_514",chq_reg_mth_misc_amt_514min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_514",chq_reg_mth_misc_amt_514max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_515",chq_reg_mth_misc_amt_515min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_515",chq_reg_mth_misc_amt_515max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_516",chq_reg_mth_misc_amt_516min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_516",chq_reg_mth_misc_amt_516max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_517",chq_reg_mth_misc_amt_517min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_517",chq_reg_mth_misc_amt_517max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_518",chq_reg_mth_misc_amt_518min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_518",chq_reg_mth_misc_amt_518max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_61",chq_reg_mth_misc_amt_61min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_61",chq_reg_mth_misc_amt_61max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_62",chq_reg_mth_misc_amt_62min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_62",chq_reg_mth_misc_amt_62max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_63",chq_reg_mth_misc_amt_63min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_63",chq_reg_mth_misc_amt_63max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_64",chq_reg_mth_misc_amt_64min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_64",chq_reg_mth_misc_amt_64max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_65",chq_reg_mth_misc_amt_65min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_65",chq_reg_mth_misc_amt_65max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_66",chq_reg_mth_misc_amt_66min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_66",chq_reg_mth_misc_amt_66max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_67",chq_reg_mth_misc_amt_67min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_67",chq_reg_mth_misc_amt_67max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_68",chq_reg_mth_misc_amt_68min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_68",chq_reg_mth_misc_amt_68max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_69",chq_reg_mth_misc_amt_69min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_69",chq_reg_mth_misc_amt_69max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_610",chq_reg_mth_misc_amt_610min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_610",chq_reg_mth_misc_amt_610max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_611",chq_reg_mth_misc_amt_611min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_611",chq_reg_mth_misc_amt_611max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_612",chq_reg_mth_misc_amt_612min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_612",chq_reg_mth_misc_amt_612max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_613",chq_reg_mth_misc_amt_613min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_613",chq_reg_mth_misc_amt_613max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_614",chq_reg_mth_misc_amt_614min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_614",chq_reg_mth_misc_amt_614max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_615",chq_reg_mth_misc_amt_615min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_615",chq_reg_mth_misc_amt_615max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_616",chq_reg_mth_misc_amt_616min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_616",chq_reg_mth_misc_amt_616max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_617",chq_reg_mth_misc_amt_617min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_617",chq_reg_mth_misc_amt_617max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_618",chq_reg_mth_misc_amt_618min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_618",chq_reg_mth_misc_amt_618max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_71",chq_reg_mth_misc_amt_71min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_71",chq_reg_mth_misc_amt_71max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_72",chq_reg_mth_misc_amt_72min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_72",chq_reg_mth_misc_amt_72max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_73",chq_reg_mth_misc_amt_73min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_73",chq_reg_mth_misc_amt_73max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_74",chq_reg_mth_misc_amt_74min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_74",chq_reg_mth_misc_amt_74max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_75",chq_reg_mth_misc_amt_75min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_75",chq_reg_mth_misc_amt_75max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_76",chq_reg_mth_misc_amt_76min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_76",chq_reg_mth_misc_amt_76max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_77",chq_reg_mth_misc_amt_77min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_77",chq_reg_mth_misc_amt_77max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_78",chq_reg_mth_misc_amt_78min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_78",chq_reg_mth_misc_amt_78max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_79",chq_reg_mth_misc_amt_79min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_79",chq_reg_mth_misc_amt_79max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_710",chq_reg_mth_misc_amt_710min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_710",chq_reg_mth_misc_amt_710max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_711",chq_reg_mth_misc_amt_711min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_711",chq_reg_mth_misc_amt_711max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_712",chq_reg_mth_misc_amt_712min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_712",chq_reg_mth_misc_amt_712max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_713",chq_reg_mth_misc_amt_713min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_713",chq_reg_mth_misc_amt_713max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_714",chq_reg_mth_misc_amt_714min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_714",chq_reg_mth_misc_amt_714max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_715",chq_reg_mth_misc_amt_715min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_715",chq_reg_mth_misc_amt_715max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_716",chq_reg_mth_misc_amt_716min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_716",chq_reg_mth_misc_amt_716max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_717",chq_reg_mth_misc_amt_717min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_717",chq_reg_mth_misc_amt_717max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_718",chq_reg_mth_misc_amt_718min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_718",chq_reg_mth_misc_amt_718max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_81",chq_reg_mth_misc_amt_81min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_81",chq_reg_mth_misc_amt_81max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_82",chq_reg_mth_misc_amt_82min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_82",chq_reg_mth_misc_amt_82max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_83",chq_reg_mth_misc_amt_83min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_83",chq_reg_mth_misc_amt_83max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_84",chq_reg_mth_misc_amt_84min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_84",chq_reg_mth_misc_amt_84max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_85",chq_reg_mth_misc_amt_85min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_85",chq_reg_mth_misc_amt_85max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_86",chq_reg_mth_misc_amt_86min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_86",chq_reg_mth_misc_amt_86max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_87",chq_reg_mth_misc_amt_87min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_87",chq_reg_mth_misc_amt_87max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_88",chq_reg_mth_misc_amt_88min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_88",chq_reg_mth_misc_amt_88max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_89",chq_reg_mth_misc_amt_89min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_89",chq_reg_mth_misc_amt_89max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_810",chq_reg_mth_misc_amt_810min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_810",chq_reg_mth_misc_amt_810max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_811",chq_reg_mth_misc_amt_811min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_811",chq_reg_mth_misc_amt_811max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_812",chq_reg_mth_misc_amt_812min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_812",chq_reg_mth_misc_amt_812max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_813",chq_reg_mth_misc_amt_813min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_813",chq_reg_mth_misc_amt_813max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_814",chq_reg_mth_misc_amt_814min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_814",chq_reg_mth_misc_amt_814max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_815",chq_reg_mth_misc_amt_815min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_815",chq_reg_mth_misc_amt_815max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_816",chq_reg_mth_misc_amt_816min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_816",chq_reg_mth_misc_amt_816max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_817",chq_reg_mth_misc_amt_817min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_817",chq_reg_mth_misc_amt_817max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_818",chq_reg_mth_misc_amt_818min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_818",chq_reg_mth_misc_amt_818max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_91",chq_reg_mth_misc_amt_91min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_91",chq_reg_mth_misc_amt_91max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_92",chq_reg_mth_misc_amt_92min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_92",chq_reg_mth_misc_amt_92max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_93",chq_reg_mth_misc_amt_93min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_93",chq_reg_mth_misc_amt_93max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_94",chq_reg_mth_misc_amt_94min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_94",chq_reg_mth_misc_amt_94max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_95",chq_reg_mth_misc_amt_95min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_95",chq_reg_mth_misc_amt_95max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_96",chq_reg_mth_misc_amt_96min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_96",chq_reg_mth_misc_amt_96max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_97",chq_reg_mth_misc_amt_97min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_97",chq_reg_mth_misc_amt_97max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_98",chq_reg_mth_misc_amt_98min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_98",chq_reg_mth_misc_amt_98max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_99",chq_reg_mth_misc_amt_99min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_99",chq_reg_mth_misc_amt_99max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_910",chq_reg_mth_misc_amt_910min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_910",chq_reg_mth_misc_amt_910max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_911",chq_reg_mth_misc_amt_911min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_911",chq_reg_mth_misc_amt_911max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_912",chq_reg_mth_misc_amt_912min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_912",chq_reg_mth_misc_amt_912max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_913",chq_reg_mth_misc_amt_913min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_913",chq_reg_mth_misc_amt_913max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_914",chq_reg_mth_misc_amt_914min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_914",chq_reg_mth_misc_amt_914max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_915",chq_reg_mth_misc_amt_915min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_915",chq_reg_mth_misc_amt_915max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_916",chq_reg_mth_misc_amt_916min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_916",chq_reg_mth_misc_amt_916max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_917",chq_reg_mth_misc_amt_917min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_917",chq_reg_mth_misc_amt_917max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_918",chq_reg_mth_misc_amt_918min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_918",chq_reg_mth_misc_amt_918max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_101",chq_reg_mth_misc_amt_101min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_101",chq_reg_mth_misc_amt_101max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_102",chq_reg_mth_misc_amt_102min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_102",chq_reg_mth_misc_amt_102max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_103",chq_reg_mth_misc_amt_103min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_103",chq_reg_mth_misc_amt_103max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_104",chq_reg_mth_misc_amt_104min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_104",chq_reg_mth_misc_amt_104max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_105",chq_reg_mth_misc_amt_105min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_105",chq_reg_mth_misc_amt_105max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_106",chq_reg_mth_misc_amt_106min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_106",chq_reg_mth_misc_amt_106max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_107",chq_reg_mth_misc_amt_107min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_107",chq_reg_mth_misc_amt_107max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_108",chq_reg_mth_misc_amt_108min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_108",chq_reg_mth_misc_amt_108max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_109",chq_reg_mth_misc_amt_109min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_109",chq_reg_mth_misc_amt_109max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_1010",chq_reg_mth_misc_amt_1010min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_1010",chq_reg_mth_misc_amt_1010max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_1011",chq_reg_mth_misc_amt_1011min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_1011",chq_reg_mth_misc_amt_1011max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_1012",chq_reg_mth_misc_amt_1012min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_1012",chq_reg_mth_misc_amt_1012max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_1013",chq_reg_mth_misc_amt_1013min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_1013",chq_reg_mth_misc_amt_1013max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_1014",chq_reg_mth_misc_amt_1014min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_1014",chq_reg_mth_misc_amt_1014max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_1015",chq_reg_mth_misc_amt_1015min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_1015",chq_reg_mth_misc_amt_1015max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_1016",chq_reg_mth_misc_amt_1016min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_1016",chq_reg_mth_misc_amt_1016max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_1017",chq_reg_mth_misc_amt_1017min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_1017",chq_reg_mth_misc_amt_1017max),
					new SqlParameter("minCHQ_REG_MTH_MISC_AMT_1018",chq_reg_mth_misc_amt_1018min),
					new SqlParameter("maxCHQ_REG_MTH_MISC_AMT_1018",chq_reg_mth_misc_amt_1018max),
					new SqlParameter("minCHQ_REG_MTH_EXP_AMT1",chq_reg_mth_exp_amt1min),
					new SqlParameter("maxCHQ_REG_MTH_EXP_AMT1",chq_reg_mth_exp_amt1max),
					new SqlParameter("minCHQ_REG_MTH_EXP_AMT2",chq_reg_mth_exp_amt2min),
					new SqlParameter("maxCHQ_REG_MTH_EXP_AMT2",chq_reg_mth_exp_amt2max),
					new SqlParameter("minCHQ_REG_MTH_EXP_AMT3",chq_reg_mth_exp_amt3min),
					new SqlParameter("maxCHQ_REG_MTH_EXP_AMT3",chq_reg_mth_exp_amt3max),
					new SqlParameter("minCHQ_REG_MTH_EXP_AMT4",chq_reg_mth_exp_amt4min),
					new SqlParameter("maxCHQ_REG_MTH_EXP_AMT4",chq_reg_mth_exp_amt4max),
					new SqlParameter("minCHQ_REG_MTH_EXP_AMT5",chq_reg_mth_exp_amt5min),
					new SqlParameter("maxCHQ_REG_MTH_EXP_AMT5",chq_reg_mth_exp_amt5max),
					new SqlParameter("minCHQ_REG_MTH_EXP_AMT6",chq_reg_mth_exp_amt6min),
					new SqlParameter("maxCHQ_REG_MTH_EXP_AMT6",chq_reg_mth_exp_amt6max),
					new SqlParameter("minCHQ_REG_MTH_EXP_AMT7",chq_reg_mth_exp_amt7min),
					new SqlParameter("maxCHQ_REG_MTH_EXP_AMT7",chq_reg_mth_exp_amt7max),
					new SqlParameter("minCHQ_REG_MTH_EXP_AMT8",chq_reg_mth_exp_amt8min),
					new SqlParameter("maxCHQ_REG_MTH_EXP_AMT8",chq_reg_mth_exp_amt8max),
					new SqlParameter("minCHQ_REG_MTH_EXP_AMT9",chq_reg_mth_exp_amt9min),
					new SqlParameter("maxCHQ_REG_MTH_EXP_AMT9",chq_reg_mth_exp_amt9max),
					new SqlParameter("minCHQ_REG_MTH_EXP_AMT10",chq_reg_mth_exp_amt10min),
					new SqlParameter("maxCHQ_REG_MTH_EXP_AMT10",chq_reg_mth_exp_amt10max),
					new SqlParameter("minCHQ_REG_MTH_EXP_AMT11",chq_reg_mth_exp_amt11min),
					new SqlParameter("maxCHQ_REG_MTH_EXP_AMT11",chq_reg_mth_exp_amt11max),
					new SqlParameter("minCHQ_REG_MTH_EXP_AMT12",chq_reg_mth_exp_amt12min),
					new SqlParameter("maxCHQ_REG_MTH_EXP_AMT12",chq_reg_mth_exp_amt12max),
					new SqlParameter("minCHQ_REG_MTH_EXP_AMT13",chq_reg_mth_exp_amt13min),
					new SqlParameter("maxCHQ_REG_MTH_EXP_AMT13",chq_reg_mth_exp_amt13max),
					new SqlParameter("minCHQ_REG_MTH_EXP_AMT14",chq_reg_mth_exp_amt14min),
					new SqlParameter("maxCHQ_REG_MTH_EXP_AMT14",chq_reg_mth_exp_amt14max),
					new SqlParameter("minCHQ_REG_MTH_EXP_AMT15",chq_reg_mth_exp_amt15min),
					new SqlParameter("maxCHQ_REG_MTH_EXP_AMT15",chq_reg_mth_exp_amt15max),
					new SqlParameter("minCHQ_REG_MTH_EXP_AMT16",chq_reg_mth_exp_amt16min),
					new SqlParameter("maxCHQ_REG_MTH_EXP_AMT16",chq_reg_mth_exp_amt16max),
					new SqlParameter("minCHQ_REG_MTH_EXP_AMT17",chq_reg_mth_exp_amt17min),
					new SqlParameter("maxCHQ_REG_MTH_EXP_AMT17",chq_reg_mth_exp_amt17max),
					new SqlParameter("minCHQ_REG_MTH_EXP_AMT18",chq_reg_mth_exp_amt18min),
					new SqlParameter("maxCHQ_REG_MTH_EXP_AMT18",chq_reg_mth_exp_amt18max),
					new SqlParameter("minCHQ_REG_COMP_ANN_EXP_THIS_PAY1",chq_reg_comp_ann_exp_this_pay1min),
					new SqlParameter("maxCHQ_REG_COMP_ANN_EXP_THIS_PAY1",chq_reg_comp_ann_exp_this_pay1max),
					new SqlParameter("minCHQ_REG_COMP_ANN_EXP_THIS_PAY2",chq_reg_comp_ann_exp_this_pay2min),
					new SqlParameter("maxCHQ_REG_COMP_ANN_EXP_THIS_PAY2",chq_reg_comp_ann_exp_this_pay2max),
					new SqlParameter("minCHQ_REG_COMP_ANN_EXP_THIS_PAY3",chq_reg_comp_ann_exp_this_pay3min),
					new SqlParameter("maxCHQ_REG_COMP_ANN_EXP_THIS_PAY3",chq_reg_comp_ann_exp_this_pay3max),
					new SqlParameter("minCHQ_REG_COMP_ANN_EXP_THIS_PAY4",chq_reg_comp_ann_exp_this_pay4min),
					new SqlParameter("maxCHQ_REG_COMP_ANN_EXP_THIS_PAY4",chq_reg_comp_ann_exp_this_pay4max),
					new SqlParameter("minCHQ_REG_COMP_ANN_EXP_THIS_PAY5",chq_reg_comp_ann_exp_this_pay5min),
					new SqlParameter("maxCHQ_REG_COMP_ANN_EXP_THIS_PAY5",chq_reg_comp_ann_exp_this_pay5max),
					new SqlParameter("minCHQ_REG_COMP_ANN_EXP_THIS_PAY6",chq_reg_comp_ann_exp_this_pay6min),
					new SqlParameter("maxCHQ_REG_COMP_ANN_EXP_THIS_PAY6",chq_reg_comp_ann_exp_this_pay6max),
					new SqlParameter("minCHQ_REG_COMP_ANN_EXP_THIS_PAY7",chq_reg_comp_ann_exp_this_pay7min),
					new SqlParameter("maxCHQ_REG_COMP_ANN_EXP_THIS_PAY7",chq_reg_comp_ann_exp_this_pay7max),
					new SqlParameter("minCHQ_REG_COMP_ANN_EXP_THIS_PAY8",chq_reg_comp_ann_exp_this_pay8min),
					new SqlParameter("maxCHQ_REG_COMP_ANN_EXP_THIS_PAY8",chq_reg_comp_ann_exp_this_pay8max),
					new SqlParameter("minCHQ_REG_COMP_ANN_EXP_THIS_PAY9",chq_reg_comp_ann_exp_this_pay9min),
					new SqlParameter("maxCHQ_REG_COMP_ANN_EXP_THIS_PAY9",chq_reg_comp_ann_exp_this_pay9max),
					new SqlParameter("minCHQ_REG_COMP_ANN_EXP_THIS_PAY10",chq_reg_comp_ann_exp_this_pay10min),
					new SqlParameter("maxCHQ_REG_COMP_ANN_EXP_THIS_PAY10",chq_reg_comp_ann_exp_this_pay10max),
					new SqlParameter("minCHQ_REG_COMP_ANN_EXP_THIS_PAY11",chq_reg_comp_ann_exp_this_pay11min),
					new SqlParameter("maxCHQ_REG_COMP_ANN_EXP_THIS_PAY11",chq_reg_comp_ann_exp_this_pay11max),
					new SqlParameter("minCHQ_REG_COMP_ANN_EXP_THIS_PAY12",chq_reg_comp_ann_exp_this_pay12min),
					new SqlParameter("maxCHQ_REG_COMP_ANN_EXP_THIS_PAY12",chq_reg_comp_ann_exp_this_pay12max),
					new SqlParameter("minCHQ_REG_COMP_ANN_EXP_THIS_PAY13",chq_reg_comp_ann_exp_this_pay13min),
					new SqlParameter("maxCHQ_REG_COMP_ANN_EXP_THIS_PAY13",chq_reg_comp_ann_exp_this_pay13max),
					new SqlParameter("minCHQ_REG_COMP_ANN_EXP_THIS_PAY14",chq_reg_comp_ann_exp_this_pay14min),
					new SqlParameter("maxCHQ_REG_COMP_ANN_EXP_THIS_PAY14",chq_reg_comp_ann_exp_this_pay14max),
					new SqlParameter("minCHQ_REG_COMP_ANN_EXP_THIS_PAY15",chq_reg_comp_ann_exp_this_pay15min),
					new SqlParameter("maxCHQ_REG_COMP_ANN_EXP_THIS_PAY15",chq_reg_comp_ann_exp_this_pay15max),
					new SqlParameter("minCHQ_REG_COMP_ANN_EXP_THIS_PAY16",chq_reg_comp_ann_exp_this_pay16min),
					new SqlParameter("maxCHQ_REG_COMP_ANN_EXP_THIS_PAY16",chq_reg_comp_ann_exp_this_pay16max),
					new SqlParameter("minCHQ_REG_COMP_ANN_EXP_THIS_PAY17",chq_reg_comp_ann_exp_this_pay17min),
					new SqlParameter("maxCHQ_REG_COMP_ANN_EXP_THIS_PAY17",chq_reg_comp_ann_exp_this_pay17max),
					new SqlParameter("minCHQ_REG_COMP_ANN_EXP_THIS_PAY18",chq_reg_comp_ann_exp_this_pay18min),
					new SqlParameter("maxCHQ_REG_COMP_ANN_EXP_THIS_PAY18",chq_reg_comp_ann_exp_this_pay18max),
					new SqlParameter("minCHQ_REG_MTH_CEIL_AMT1",chq_reg_mth_ceil_amt1min),
					new SqlParameter("maxCHQ_REG_MTH_CEIL_AMT1",chq_reg_mth_ceil_amt1max),
					new SqlParameter("minCHQ_REG_MTH_CEIL_AMT2",chq_reg_mth_ceil_amt2min),
					new SqlParameter("maxCHQ_REG_MTH_CEIL_AMT2",chq_reg_mth_ceil_amt2max),
					new SqlParameter("minCHQ_REG_MTH_CEIL_AMT3",chq_reg_mth_ceil_amt3min),
					new SqlParameter("maxCHQ_REG_MTH_CEIL_AMT3",chq_reg_mth_ceil_amt3max),
					new SqlParameter("minCHQ_REG_MTH_CEIL_AMT4",chq_reg_mth_ceil_amt4min),
					new SqlParameter("maxCHQ_REG_MTH_CEIL_AMT4",chq_reg_mth_ceil_amt4max),
					new SqlParameter("minCHQ_REG_MTH_CEIL_AMT5",chq_reg_mth_ceil_amt5min),
					new SqlParameter("maxCHQ_REG_MTH_CEIL_AMT5",chq_reg_mth_ceil_amt5max),
					new SqlParameter("minCHQ_REG_MTH_CEIL_AMT6",chq_reg_mth_ceil_amt6min),
					new SqlParameter("maxCHQ_REG_MTH_CEIL_AMT6",chq_reg_mth_ceil_amt6max),
					new SqlParameter("minCHQ_REG_MTH_CEIL_AMT7",chq_reg_mth_ceil_amt7min),
					new SqlParameter("maxCHQ_REG_MTH_CEIL_AMT7",chq_reg_mth_ceil_amt7max),
					new SqlParameter("minCHQ_REG_MTH_CEIL_AMT8",chq_reg_mth_ceil_amt8min),
					new SqlParameter("maxCHQ_REG_MTH_CEIL_AMT8",chq_reg_mth_ceil_amt8max),
					new SqlParameter("minCHQ_REG_MTH_CEIL_AMT9",chq_reg_mth_ceil_amt9min),
					new SqlParameter("maxCHQ_REG_MTH_CEIL_AMT9",chq_reg_mth_ceil_amt9max),
					new SqlParameter("minCHQ_REG_MTH_CEIL_AMT10",chq_reg_mth_ceil_amt10min),
					new SqlParameter("maxCHQ_REG_MTH_CEIL_AMT10",chq_reg_mth_ceil_amt10max),
					new SqlParameter("minCHQ_REG_MTH_CEIL_AMT11",chq_reg_mth_ceil_amt11min),
					new SqlParameter("maxCHQ_REG_MTH_CEIL_AMT11",chq_reg_mth_ceil_amt11max),
					new SqlParameter("minCHQ_REG_MTH_CEIL_AMT12",chq_reg_mth_ceil_amt12min),
					new SqlParameter("maxCHQ_REG_MTH_CEIL_AMT12",chq_reg_mth_ceil_amt12max),
					new SqlParameter("minCHQ_REG_MTH_CEIL_AMT13",chq_reg_mth_ceil_amt13min),
					new SqlParameter("maxCHQ_REG_MTH_CEIL_AMT13",chq_reg_mth_ceil_amt13max),
					new SqlParameter("minCHQ_REG_MTH_CEIL_AMT14",chq_reg_mth_ceil_amt14min),
					new SqlParameter("maxCHQ_REG_MTH_CEIL_AMT14",chq_reg_mth_ceil_amt14max),
					new SqlParameter("minCHQ_REG_MTH_CEIL_AMT15",chq_reg_mth_ceil_amt15min),
					new SqlParameter("maxCHQ_REG_MTH_CEIL_AMT15",chq_reg_mth_ceil_amt15max),
					new SqlParameter("minCHQ_REG_MTH_CEIL_AMT16",chq_reg_mth_ceil_amt16min),
					new SqlParameter("maxCHQ_REG_MTH_CEIL_AMT16",chq_reg_mth_ceil_amt16max),
					new SqlParameter("minCHQ_REG_MTH_CEIL_AMT17",chq_reg_mth_ceil_amt17min),
					new SqlParameter("maxCHQ_REG_MTH_CEIL_AMT17",chq_reg_mth_ceil_amt17max),
					new SqlParameter("minCHQ_REG_MTH_CEIL_AMT18",chq_reg_mth_ceil_amt18min),
					new SqlParameter("maxCHQ_REG_MTH_CEIL_AMT18",chq_reg_mth_ceil_amt18max),
					new SqlParameter("minCHQ_REG_COMP_ANN_CEIL_THIS_PAY1",chq_reg_comp_ann_ceil_this_pay1min),
					new SqlParameter("maxCHQ_REG_COMP_ANN_CEIL_THIS_PAY1",chq_reg_comp_ann_ceil_this_pay1max),
					new SqlParameter("minCHQ_REG_COMP_ANN_CEIL_THIS_PAY2",chq_reg_comp_ann_ceil_this_pay2min),
					new SqlParameter("maxCHQ_REG_COMP_ANN_CEIL_THIS_PAY2",chq_reg_comp_ann_ceil_this_pay2max),
					new SqlParameter("minCHQ_REG_COMP_ANN_CEIL_THIS_PAY3",chq_reg_comp_ann_ceil_this_pay3min),
					new SqlParameter("maxCHQ_REG_COMP_ANN_CEIL_THIS_PAY3",chq_reg_comp_ann_ceil_this_pay3max),
					new SqlParameter("minCHQ_REG_COMP_ANN_CEIL_THIS_PAY4",chq_reg_comp_ann_ceil_this_pay4min),
					new SqlParameter("maxCHQ_REG_COMP_ANN_CEIL_THIS_PAY4",chq_reg_comp_ann_ceil_this_pay4max),
					new SqlParameter("minCHQ_REG_COMP_ANN_CEIL_THIS_PAY5",chq_reg_comp_ann_ceil_this_pay5min),
					new SqlParameter("maxCHQ_REG_COMP_ANN_CEIL_THIS_PAY5",chq_reg_comp_ann_ceil_this_pay5max),
					new SqlParameter("minCHQ_REG_COMP_ANN_CEIL_THIS_PAY6",chq_reg_comp_ann_ceil_this_pay6min),
					new SqlParameter("maxCHQ_REG_COMP_ANN_CEIL_THIS_PAY6",chq_reg_comp_ann_ceil_this_pay6max),
					new SqlParameter("minCHQ_REG_COMP_ANN_CEIL_THIS_PAY7",chq_reg_comp_ann_ceil_this_pay7min),
					new SqlParameter("maxCHQ_REG_COMP_ANN_CEIL_THIS_PAY7",chq_reg_comp_ann_ceil_this_pay7max),
					new SqlParameter("minCHQ_REG_COMP_ANN_CEIL_THIS_PAY8",chq_reg_comp_ann_ceil_this_pay8min),
					new SqlParameter("maxCHQ_REG_COMP_ANN_CEIL_THIS_PAY8",chq_reg_comp_ann_ceil_this_pay8max),
					new SqlParameter("minCHQ_REG_COMP_ANN_CEIL_THIS_PAY9",chq_reg_comp_ann_ceil_this_pay9min),
					new SqlParameter("maxCHQ_REG_COMP_ANN_CEIL_THIS_PAY9",chq_reg_comp_ann_ceil_this_pay9max),
					new SqlParameter("minCHQ_REG_COMP_ANN_CEIL_THIS_PAY10",chq_reg_comp_ann_ceil_this_pay10min),
					new SqlParameter("maxCHQ_REG_COMP_ANN_CEIL_THIS_PAY10",chq_reg_comp_ann_ceil_this_pay10max),
					new SqlParameter("minCHQ_REG_COMP_ANN_CEIL_THIS_PAY11",chq_reg_comp_ann_ceil_this_pay11min),
					new SqlParameter("maxCHQ_REG_COMP_ANN_CEIL_THIS_PAY11",chq_reg_comp_ann_ceil_this_pay11max),
					new SqlParameter("minCHQ_REG_COMP_ANN_CEIL_THIS_PAY12",chq_reg_comp_ann_ceil_this_pay12min),
					new SqlParameter("maxCHQ_REG_COMP_ANN_CEIL_THIS_PAY12",chq_reg_comp_ann_ceil_this_pay12max),
					new SqlParameter("minCHQ_REG_COMP_ANN_CEIL_THIS_PAY13",chq_reg_comp_ann_ceil_this_pay13min),
					new SqlParameter("maxCHQ_REG_COMP_ANN_CEIL_THIS_PAY13",chq_reg_comp_ann_ceil_this_pay13max),
					new SqlParameter("minCHQ_REG_COMP_ANN_CEIL_THIS_PAY14",chq_reg_comp_ann_ceil_this_pay14min),
					new SqlParameter("maxCHQ_REG_COMP_ANN_CEIL_THIS_PAY14",chq_reg_comp_ann_ceil_this_pay14max),
					new SqlParameter("minCHQ_REG_COMP_ANN_CEIL_THIS_PAY15",chq_reg_comp_ann_ceil_this_pay15min),
					new SqlParameter("maxCHQ_REG_COMP_ANN_CEIL_THIS_PAY15",chq_reg_comp_ann_ceil_this_pay15max),
					new SqlParameter("minCHQ_REG_COMP_ANN_CEIL_THIS_PAY16",chq_reg_comp_ann_ceil_this_pay16min),
					new SqlParameter("maxCHQ_REG_COMP_ANN_CEIL_THIS_PAY16",chq_reg_comp_ann_ceil_this_pay16max),
					new SqlParameter("minCHQ_REG_COMP_ANN_CEIL_THIS_PAY17",chq_reg_comp_ann_ceil_this_pay17min),
					new SqlParameter("maxCHQ_REG_COMP_ANN_CEIL_THIS_PAY17",chq_reg_comp_ann_ceil_this_pay17max),
					new SqlParameter("minCHQ_REG_COMP_ANN_CEIL_THIS_PAY18",chq_reg_comp_ann_ceil_this_pay18min),
					new SqlParameter("maxCHQ_REG_COMP_ANN_CEIL_THIS_PAY18",chq_reg_comp_ann_ceil_this_pay18max),
					new SqlParameter("minCHQ_REG_EARNINGS_THIS_MTH1",chq_reg_earnings_this_mth1min),
					new SqlParameter("maxCHQ_REG_EARNINGS_THIS_MTH1",chq_reg_earnings_this_mth1max),
					new SqlParameter("minCHQ_REG_EARNINGS_THIS_MTH2",chq_reg_earnings_this_mth2min),
					new SqlParameter("maxCHQ_REG_EARNINGS_THIS_MTH2",chq_reg_earnings_this_mth2max),
					new SqlParameter("minCHQ_REG_EARNINGS_THIS_MTH3",chq_reg_earnings_this_mth3min),
					new SqlParameter("maxCHQ_REG_EARNINGS_THIS_MTH3",chq_reg_earnings_this_mth3max),
					new SqlParameter("minCHQ_REG_EARNINGS_THIS_MTH4",chq_reg_earnings_this_mth4min),
					new SqlParameter("maxCHQ_REG_EARNINGS_THIS_MTH4",chq_reg_earnings_this_mth4max),
					new SqlParameter("minCHQ_REG_EARNINGS_THIS_MTH5",chq_reg_earnings_this_mth5min),
					new SqlParameter("maxCHQ_REG_EARNINGS_THIS_MTH5",chq_reg_earnings_this_mth5max),
					new SqlParameter("minCHQ_REG_EARNINGS_THIS_MTH6",chq_reg_earnings_this_mth6min),
					new SqlParameter("maxCHQ_REG_EARNINGS_THIS_MTH6",chq_reg_earnings_this_mth6max),
					new SqlParameter("minCHQ_REG_EARNINGS_THIS_MTH7",chq_reg_earnings_this_mth7min),
					new SqlParameter("maxCHQ_REG_EARNINGS_THIS_MTH7",chq_reg_earnings_this_mth7max),
					new SqlParameter("minCHQ_REG_EARNINGS_THIS_MTH8",chq_reg_earnings_this_mth8min),
					new SqlParameter("maxCHQ_REG_EARNINGS_THIS_MTH8",chq_reg_earnings_this_mth8max),
					new SqlParameter("minCHQ_REG_EARNINGS_THIS_MTH9",chq_reg_earnings_this_mth9min),
					new SqlParameter("maxCHQ_REG_EARNINGS_THIS_MTH9",chq_reg_earnings_this_mth9max),
					new SqlParameter("minCHQ_REG_EARNINGS_THIS_MTH10",chq_reg_earnings_this_mth10min),
					new SqlParameter("maxCHQ_REG_EARNINGS_THIS_MTH10",chq_reg_earnings_this_mth10max),
					new SqlParameter("minCHQ_REG_EARNINGS_THIS_MTH11",chq_reg_earnings_this_mth11min),
					new SqlParameter("maxCHQ_REG_EARNINGS_THIS_MTH11",chq_reg_earnings_this_mth11max),
					new SqlParameter("minCHQ_REG_EARNINGS_THIS_MTH12",chq_reg_earnings_this_mth12min),
					new SqlParameter("maxCHQ_REG_EARNINGS_THIS_MTH12",chq_reg_earnings_this_mth12max),
					new SqlParameter("minCHQ_REG_EARNINGS_THIS_MTH13",chq_reg_earnings_this_mth13min),
					new SqlParameter("maxCHQ_REG_EARNINGS_THIS_MTH13",chq_reg_earnings_this_mth13max),
					new SqlParameter("minCHQ_REG_EARNINGS_THIS_MTH14",chq_reg_earnings_this_mth14min),
					new SqlParameter("maxCHQ_REG_EARNINGS_THIS_MTH14",chq_reg_earnings_this_mth14max),
					new SqlParameter("minCHQ_REG_EARNINGS_THIS_MTH15",chq_reg_earnings_this_mth15min),
					new SqlParameter("maxCHQ_REG_EARNINGS_THIS_MTH15",chq_reg_earnings_this_mth15max),
					new SqlParameter("minCHQ_REG_EARNINGS_THIS_MTH16",chq_reg_earnings_this_mth16min),
					new SqlParameter("maxCHQ_REG_EARNINGS_THIS_MTH16",chq_reg_earnings_this_mth16max),
					new SqlParameter("minCHQ_REG_EARNINGS_THIS_MTH17",chq_reg_earnings_this_mth17min),
					new SqlParameter("maxCHQ_REG_EARNINGS_THIS_MTH17",chq_reg_earnings_this_mth17max),
					new SqlParameter("minCHQ_REG_EARNINGS_THIS_MTH18",chq_reg_earnings_this_mth18min),
					new SqlParameter("maxCHQ_REG_EARNINGS_THIS_MTH18",chq_reg_earnings_this_mth18max),
					new SqlParameter("minCHQ_REG_REGULAR_PAY_THIS_MTH1",chq_reg_regular_pay_this_mth1min),
					new SqlParameter("maxCHQ_REG_REGULAR_PAY_THIS_MTH1",chq_reg_regular_pay_this_mth1max),
					new SqlParameter("minCHQ_REG_REGULAR_PAY_THIS_MTH2",chq_reg_regular_pay_this_mth2min),
					new SqlParameter("maxCHQ_REG_REGULAR_PAY_THIS_MTH2",chq_reg_regular_pay_this_mth2max),
					new SqlParameter("minCHQ_REG_REGULAR_PAY_THIS_MTH3",chq_reg_regular_pay_this_mth3min),
					new SqlParameter("maxCHQ_REG_REGULAR_PAY_THIS_MTH3",chq_reg_regular_pay_this_mth3max),
					new SqlParameter("minCHQ_REG_REGULAR_PAY_THIS_MTH4",chq_reg_regular_pay_this_mth4min),
					new SqlParameter("maxCHQ_REG_REGULAR_PAY_THIS_MTH4",chq_reg_regular_pay_this_mth4max),
					new SqlParameter("minCHQ_REG_REGULAR_PAY_THIS_MTH5",chq_reg_regular_pay_this_mth5min),
					new SqlParameter("maxCHQ_REG_REGULAR_PAY_THIS_MTH5",chq_reg_regular_pay_this_mth5max),
					new SqlParameter("minCHQ_REG_REGULAR_PAY_THIS_MTH6",chq_reg_regular_pay_this_mth6min),
					new SqlParameter("maxCHQ_REG_REGULAR_PAY_THIS_MTH6",chq_reg_regular_pay_this_mth6max),
					new SqlParameter("minCHQ_REG_REGULAR_PAY_THIS_MTH7",chq_reg_regular_pay_this_mth7min),
					new SqlParameter("maxCHQ_REG_REGULAR_PAY_THIS_MTH7",chq_reg_regular_pay_this_mth7max),
					new SqlParameter("minCHQ_REG_REGULAR_PAY_THIS_MTH8",chq_reg_regular_pay_this_mth8min),
					new SqlParameter("maxCHQ_REG_REGULAR_PAY_THIS_MTH8",chq_reg_regular_pay_this_mth8max),
					new SqlParameter("minCHQ_REG_REGULAR_PAY_THIS_MTH9",chq_reg_regular_pay_this_mth9min),
					new SqlParameter("maxCHQ_REG_REGULAR_PAY_THIS_MTH9",chq_reg_regular_pay_this_mth9max),
					new SqlParameter("minCHQ_REG_REGULAR_PAY_THIS_MTH10",chq_reg_regular_pay_this_mth10min),
					new SqlParameter("maxCHQ_REG_REGULAR_PAY_THIS_MTH10",chq_reg_regular_pay_this_mth10max),
					new SqlParameter("minCHQ_REG_REGULAR_PAY_THIS_MTH11",chq_reg_regular_pay_this_mth11min),
					new SqlParameter("maxCHQ_REG_REGULAR_PAY_THIS_MTH11",chq_reg_regular_pay_this_mth11max),
					new SqlParameter("minCHQ_REG_REGULAR_PAY_THIS_MTH12",chq_reg_regular_pay_this_mth12min),
					new SqlParameter("maxCHQ_REG_REGULAR_PAY_THIS_MTH12",chq_reg_regular_pay_this_mth12max),
					new SqlParameter("minCHQ_REG_REGULAR_PAY_THIS_MTH13",chq_reg_regular_pay_this_mth13min),
					new SqlParameter("maxCHQ_REG_REGULAR_PAY_THIS_MTH13",chq_reg_regular_pay_this_mth13max),
					new SqlParameter("minCHQ_REG_REGULAR_PAY_THIS_MTH14",chq_reg_regular_pay_this_mth14min),
					new SqlParameter("maxCHQ_REG_REGULAR_PAY_THIS_MTH14",chq_reg_regular_pay_this_mth14max),
					new SqlParameter("minCHQ_REG_REGULAR_PAY_THIS_MTH15",chq_reg_regular_pay_this_mth15min),
					new SqlParameter("maxCHQ_REG_REGULAR_PAY_THIS_MTH15",chq_reg_regular_pay_this_mth15max),
					new SqlParameter("minCHQ_REG_REGULAR_PAY_THIS_MTH16",chq_reg_regular_pay_this_mth16min),
					new SqlParameter("maxCHQ_REG_REGULAR_PAY_THIS_MTH16",chq_reg_regular_pay_this_mth16max),
					new SqlParameter("minCHQ_REG_REGULAR_PAY_THIS_MTH17",chq_reg_regular_pay_this_mth17min),
					new SqlParameter("maxCHQ_REG_REGULAR_PAY_THIS_MTH17",chq_reg_regular_pay_this_mth17max),
					new SqlParameter("minCHQ_REG_REGULAR_PAY_THIS_MTH18",chq_reg_regular_pay_this_mth18min),
					new SqlParameter("maxCHQ_REG_REGULAR_PAY_THIS_MTH18",chq_reg_regular_pay_this_mth18max),
					new SqlParameter("minCHQ_REG_REGULAR_TAX_THIS_MTH1",chq_reg_regular_tax_this_mth1min),
					new SqlParameter("maxCHQ_REG_REGULAR_TAX_THIS_MTH1",chq_reg_regular_tax_this_mth1max),
					new SqlParameter("minCHQ_REG_REGULAR_TAX_THIS_MTH2",chq_reg_regular_tax_this_mth2min),
					new SqlParameter("maxCHQ_REG_REGULAR_TAX_THIS_MTH2",chq_reg_regular_tax_this_mth2max),
					new SqlParameter("minCHQ_REG_REGULAR_TAX_THIS_MTH3",chq_reg_regular_tax_this_mth3min),
					new SqlParameter("maxCHQ_REG_REGULAR_TAX_THIS_MTH3",chq_reg_regular_tax_this_mth3max),
					new SqlParameter("minCHQ_REG_REGULAR_TAX_THIS_MTH4",chq_reg_regular_tax_this_mth4min),
					new SqlParameter("maxCHQ_REG_REGULAR_TAX_THIS_MTH4",chq_reg_regular_tax_this_mth4max),
					new SqlParameter("minCHQ_REG_REGULAR_TAX_THIS_MTH5",chq_reg_regular_tax_this_mth5min),
					new SqlParameter("maxCHQ_REG_REGULAR_TAX_THIS_MTH5",chq_reg_regular_tax_this_mth5max),
					new SqlParameter("minCHQ_REG_REGULAR_TAX_THIS_MTH6",chq_reg_regular_tax_this_mth6min),
					new SqlParameter("maxCHQ_REG_REGULAR_TAX_THIS_MTH6",chq_reg_regular_tax_this_mth6max),
					new SqlParameter("minCHQ_REG_REGULAR_TAX_THIS_MTH7",chq_reg_regular_tax_this_mth7min),
					new SqlParameter("maxCHQ_REG_REGULAR_TAX_THIS_MTH7",chq_reg_regular_tax_this_mth7max),
					new SqlParameter("minCHQ_REG_REGULAR_TAX_THIS_MTH8",chq_reg_regular_tax_this_mth8min),
					new SqlParameter("maxCHQ_REG_REGULAR_TAX_THIS_MTH8",chq_reg_regular_tax_this_mth8max),
					new SqlParameter("minCHQ_REG_REGULAR_TAX_THIS_MTH9",chq_reg_regular_tax_this_mth9min),
					new SqlParameter("maxCHQ_REG_REGULAR_TAX_THIS_MTH9",chq_reg_regular_tax_this_mth9max),
					new SqlParameter("minCHQ_REG_REGULAR_TAX_THIS_MTH10",chq_reg_regular_tax_this_mth10min),
					new SqlParameter("maxCHQ_REG_REGULAR_TAX_THIS_MTH10",chq_reg_regular_tax_this_mth10max),
					new SqlParameter("minCHQ_REG_REGULAR_TAX_THIS_MTH11",chq_reg_regular_tax_this_mth11min),
					new SqlParameter("maxCHQ_REG_REGULAR_TAX_THIS_MTH11",chq_reg_regular_tax_this_mth11max),
					new SqlParameter("minCHQ_REG_REGULAR_TAX_THIS_MTH12",chq_reg_regular_tax_this_mth12min),
					new SqlParameter("maxCHQ_REG_REGULAR_TAX_THIS_MTH12",chq_reg_regular_tax_this_mth12max),
					new SqlParameter("minCHQ_REG_REGULAR_TAX_THIS_MTH13",chq_reg_regular_tax_this_mth13min),
					new SqlParameter("maxCHQ_REG_REGULAR_TAX_THIS_MTH13",chq_reg_regular_tax_this_mth13max),
					new SqlParameter("minCHQ_REG_REGULAR_TAX_THIS_MTH14",chq_reg_regular_tax_this_mth14min),
					new SqlParameter("maxCHQ_REG_REGULAR_TAX_THIS_MTH14",chq_reg_regular_tax_this_mth14max),
					new SqlParameter("minCHQ_REG_REGULAR_TAX_THIS_MTH15",chq_reg_regular_tax_this_mth15min),
					new SqlParameter("maxCHQ_REG_REGULAR_TAX_THIS_MTH15",chq_reg_regular_tax_this_mth15max),
					new SqlParameter("minCHQ_REG_REGULAR_TAX_THIS_MTH16",chq_reg_regular_tax_this_mth16min),
					new SqlParameter("maxCHQ_REG_REGULAR_TAX_THIS_MTH16",chq_reg_regular_tax_this_mth16max),
					new SqlParameter("minCHQ_REG_REGULAR_TAX_THIS_MTH17",chq_reg_regular_tax_this_mth17min),
					new SqlParameter("maxCHQ_REG_REGULAR_TAX_THIS_MTH17",chq_reg_regular_tax_this_mth17max),
					new SqlParameter("minCHQ_REG_REGULAR_TAX_THIS_MTH18",chq_reg_regular_tax_this_mth18min),
					new SqlParameter("maxCHQ_REG_REGULAR_TAX_THIS_MTH18",chq_reg_regular_tax_this_mth18max),
					new SqlParameter("minCHQ_REG_MAN_PAY_THIS_MTH1",chq_reg_man_pay_this_mth1min),
					new SqlParameter("maxCHQ_REG_MAN_PAY_THIS_MTH1",chq_reg_man_pay_this_mth1max),
					new SqlParameter("minCHQ_REG_MAN_PAY_THIS_MTH2",chq_reg_man_pay_this_mth2min),
					new SqlParameter("maxCHQ_REG_MAN_PAY_THIS_MTH2",chq_reg_man_pay_this_mth2max),
					new SqlParameter("minCHQ_REG_MAN_PAY_THIS_MTH3",chq_reg_man_pay_this_mth3min),
					new SqlParameter("maxCHQ_REG_MAN_PAY_THIS_MTH3",chq_reg_man_pay_this_mth3max),
					new SqlParameter("minCHQ_REG_MAN_PAY_THIS_MTH4",chq_reg_man_pay_this_mth4min),
					new SqlParameter("maxCHQ_REG_MAN_PAY_THIS_MTH4",chq_reg_man_pay_this_mth4max),
					new SqlParameter("minCHQ_REG_MAN_PAY_THIS_MTH5",chq_reg_man_pay_this_mth5min),
					new SqlParameter("maxCHQ_REG_MAN_PAY_THIS_MTH5",chq_reg_man_pay_this_mth5max),
					new SqlParameter("minCHQ_REG_MAN_PAY_THIS_MTH6",chq_reg_man_pay_this_mth6min),
					new SqlParameter("maxCHQ_REG_MAN_PAY_THIS_MTH6",chq_reg_man_pay_this_mth6max),
					new SqlParameter("minCHQ_REG_MAN_PAY_THIS_MTH7",chq_reg_man_pay_this_mth7min),
					new SqlParameter("maxCHQ_REG_MAN_PAY_THIS_MTH7",chq_reg_man_pay_this_mth7max),
					new SqlParameter("minCHQ_REG_MAN_PAY_THIS_MTH8",chq_reg_man_pay_this_mth8min),
					new SqlParameter("maxCHQ_REG_MAN_PAY_THIS_MTH8",chq_reg_man_pay_this_mth8max),
					new SqlParameter("minCHQ_REG_MAN_PAY_THIS_MTH9",chq_reg_man_pay_this_mth9min),
					new SqlParameter("maxCHQ_REG_MAN_PAY_THIS_MTH9",chq_reg_man_pay_this_mth9max),
					new SqlParameter("minCHQ_REG_MAN_PAY_THIS_MTH10",chq_reg_man_pay_this_mth10min),
					new SqlParameter("maxCHQ_REG_MAN_PAY_THIS_MTH10",chq_reg_man_pay_this_mth10max),
					new SqlParameter("minCHQ_REG_MAN_PAY_THIS_MTH11",chq_reg_man_pay_this_mth11min),
					new SqlParameter("maxCHQ_REG_MAN_PAY_THIS_MTH11",chq_reg_man_pay_this_mth11max),
					new SqlParameter("minCHQ_REG_MAN_PAY_THIS_MTH12",chq_reg_man_pay_this_mth12min),
					new SqlParameter("maxCHQ_REG_MAN_PAY_THIS_MTH12",chq_reg_man_pay_this_mth12max),
					new SqlParameter("minCHQ_REG_MAN_PAY_THIS_MTH13",chq_reg_man_pay_this_mth13min),
					new SqlParameter("maxCHQ_REG_MAN_PAY_THIS_MTH13",chq_reg_man_pay_this_mth13max),
					new SqlParameter("minCHQ_REG_MAN_PAY_THIS_MTH14",chq_reg_man_pay_this_mth14min),
					new SqlParameter("maxCHQ_REG_MAN_PAY_THIS_MTH14",chq_reg_man_pay_this_mth14max),
					new SqlParameter("minCHQ_REG_MAN_PAY_THIS_MTH15",chq_reg_man_pay_this_mth15min),
					new SqlParameter("maxCHQ_REG_MAN_PAY_THIS_MTH15",chq_reg_man_pay_this_mth15max),
					new SqlParameter("minCHQ_REG_MAN_PAY_THIS_MTH16",chq_reg_man_pay_this_mth16min),
					new SqlParameter("maxCHQ_REG_MAN_PAY_THIS_MTH16",chq_reg_man_pay_this_mth16max),
					new SqlParameter("minCHQ_REG_MAN_PAY_THIS_MTH17",chq_reg_man_pay_this_mth17min),
					new SqlParameter("maxCHQ_REG_MAN_PAY_THIS_MTH17",chq_reg_man_pay_this_mth17max),
					new SqlParameter("minCHQ_REG_MAN_PAY_THIS_MTH18",chq_reg_man_pay_this_mth18min),
					new SqlParameter("maxCHQ_REG_MAN_PAY_THIS_MTH18",chq_reg_man_pay_this_mth18max),
					new SqlParameter("minCHQ_REG_MAN_TAX_THIS_MTH1",chq_reg_man_tax_this_mth1min),
					new SqlParameter("maxCHQ_REG_MAN_TAX_THIS_MTH1",chq_reg_man_tax_this_mth1max),
					new SqlParameter("minCHQ_REG_MAN_TAX_THIS_MTH2",chq_reg_man_tax_this_mth2min),
					new SqlParameter("maxCHQ_REG_MAN_TAX_THIS_MTH2",chq_reg_man_tax_this_mth2max),
					new SqlParameter("minCHQ_REG_MAN_TAX_THIS_MTH3",chq_reg_man_tax_this_mth3min),
					new SqlParameter("maxCHQ_REG_MAN_TAX_THIS_MTH3",chq_reg_man_tax_this_mth3max),
					new SqlParameter("minCHQ_REG_MAN_TAX_THIS_MTH4",chq_reg_man_tax_this_mth4min),
					new SqlParameter("maxCHQ_REG_MAN_TAX_THIS_MTH4",chq_reg_man_tax_this_mth4max),
					new SqlParameter("minCHQ_REG_MAN_TAX_THIS_MTH5",chq_reg_man_tax_this_mth5min),
					new SqlParameter("maxCHQ_REG_MAN_TAX_THIS_MTH5",chq_reg_man_tax_this_mth5max),
					new SqlParameter("minCHQ_REG_MAN_TAX_THIS_MTH6",chq_reg_man_tax_this_mth6min),
					new SqlParameter("maxCHQ_REG_MAN_TAX_THIS_MTH6",chq_reg_man_tax_this_mth6max),
					new SqlParameter("minCHQ_REG_MAN_TAX_THIS_MTH7",chq_reg_man_tax_this_mth7min),
					new SqlParameter("maxCHQ_REG_MAN_TAX_THIS_MTH7",chq_reg_man_tax_this_mth7max),
					new SqlParameter("minCHQ_REG_MAN_TAX_THIS_MTH8",chq_reg_man_tax_this_mth8min),
					new SqlParameter("maxCHQ_REG_MAN_TAX_THIS_MTH8",chq_reg_man_tax_this_mth8max),
					new SqlParameter("minCHQ_REG_MAN_TAX_THIS_MTH9",chq_reg_man_tax_this_mth9min),
					new SqlParameter("maxCHQ_REG_MAN_TAX_THIS_MTH9",chq_reg_man_tax_this_mth9max),
					new SqlParameter("minCHQ_REG_MAN_TAX_THIS_MTH10",chq_reg_man_tax_this_mth10min),
					new SqlParameter("maxCHQ_REG_MAN_TAX_THIS_MTH10",chq_reg_man_tax_this_mth10max),
					new SqlParameter("minCHQ_REG_MAN_TAX_THIS_MTH11",chq_reg_man_tax_this_mth11min),
					new SqlParameter("maxCHQ_REG_MAN_TAX_THIS_MTH11",chq_reg_man_tax_this_mth11max),
					new SqlParameter("minCHQ_REG_MAN_TAX_THIS_MTH12",chq_reg_man_tax_this_mth12min),
					new SqlParameter("maxCHQ_REG_MAN_TAX_THIS_MTH12",chq_reg_man_tax_this_mth12max),
					new SqlParameter("minCHQ_REG_MAN_TAX_THIS_MTH13",chq_reg_man_tax_this_mth13min),
					new SqlParameter("maxCHQ_REG_MAN_TAX_THIS_MTH13",chq_reg_man_tax_this_mth13max),
					new SqlParameter("minCHQ_REG_MAN_TAX_THIS_MTH14",chq_reg_man_tax_this_mth14min),
					new SqlParameter("maxCHQ_REG_MAN_TAX_THIS_MTH14",chq_reg_man_tax_this_mth14max),
					new SqlParameter("minCHQ_REG_MAN_TAX_THIS_MTH15",chq_reg_man_tax_this_mth15min),
					new SqlParameter("maxCHQ_REG_MAN_TAX_THIS_MTH15",chq_reg_man_tax_this_mth15max),
					new SqlParameter("minCHQ_REG_MAN_TAX_THIS_MTH16",chq_reg_man_tax_this_mth16min),
					new SqlParameter("maxCHQ_REG_MAN_TAX_THIS_MTH16",chq_reg_man_tax_this_mth16max),
					new SqlParameter("minCHQ_REG_MAN_TAX_THIS_MTH17",chq_reg_man_tax_this_mth17min),
					new SqlParameter("maxCHQ_REG_MAN_TAX_THIS_MTH17",chq_reg_man_tax_this_mth17max),
					new SqlParameter("minCHQ_REG_MAN_TAX_THIS_MTH18",chq_reg_man_tax_this_mth18min),
					new SqlParameter("maxCHQ_REG_MAN_TAX_THIS_MTH18",chq_reg_man_tax_this_mth18max),
					new SqlParameter("minCHQ_REG_PAY_DATE1",chq_reg_pay_date1min),
					new SqlParameter("maxCHQ_REG_PAY_DATE1",chq_reg_pay_date1max),
					new SqlParameter("minCHQ_REG_PAY_DATE2",chq_reg_pay_date2min),
					new SqlParameter("maxCHQ_REG_PAY_DATE2",chq_reg_pay_date2max),
					new SqlParameter("minCHQ_REG_PAY_DATE3",chq_reg_pay_date3min),
					new SqlParameter("maxCHQ_REG_PAY_DATE3",chq_reg_pay_date3max),
					new SqlParameter("minCHQ_REG_PAY_DATE4",chq_reg_pay_date4min),
					new SqlParameter("maxCHQ_REG_PAY_DATE4",chq_reg_pay_date4max),
					new SqlParameter("minCHQ_REG_PAY_DATE5",chq_reg_pay_date5min),
					new SqlParameter("maxCHQ_REG_PAY_DATE5",chq_reg_pay_date5max),
					new SqlParameter("minCHQ_REG_PAY_DATE6",chq_reg_pay_date6min),
					new SqlParameter("maxCHQ_REG_PAY_DATE6",chq_reg_pay_date6max),
					new SqlParameter("minCHQ_REG_PAY_DATE7",chq_reg_pay_date7min),
					new SqlParameter("maxCHQ_REG_PAY_DATE7",chq_reg_pay_date7max),
					new SqlParameter("minCHQ_REG_PAY_DATE8",chq_reg_pay_date8min),
					new SqlParameter("maxCHQ_REG_PAY_DATE8",chq_reg_pay_date8max),
					new SqlParameter("minCHQ_REG_PAY_DATE9",chq_reg_pay_date9min),
					new SqlParameter("maxCHQ_REG_PAY_DATE9",chq_reg_pay_date9max),
					new SqlParameter("minCHQ_REG_PAY_DATE10",chq_reg_pay_date10min),
					new SqlParameter("maxCHQ_REG_PAY_DATE10",chq_reg_pay_date10max),
					new SqlParameter("minCHQ_REG_PAY_DATE11",chq_reg_pay_date11min),
					new SqlParameter("maxCHQ_REG_PAY_DATE11",chq_reg_pay_date11max),
					new SqlParameter("minCHQ_REG_PAY_DATE12",chq_reg_pay_date12min),
					new SqlParameter("maxCHQ_REG_PAY_DATE12",chq_reg_pay_date12max),
					new SqlParameter("minCHQ_REG_PAY_DATE13",chq_reg_pay_date13min),
					new SqlParameter("maxCHQ_REG_PAY_DATE13",chq_reg_pay_date13max),
					new SqlParameter("minCHQ_REG_PAY_DATE14",chq_reg_pay_date14min),
					new SqlParameter("maxCHQ_REG_PAY_DATE14",chq_reg_pay_date14max),
					new SqlParameter("minCHQ_REG_PAY_DATE15",chq_reg_pay_date15min),
					new SqlParameter("maxCHQ_REG_PAY_DATE15",chq_reg_pay_date15max),
					new SqlParameter("minCHQ_REG_PAY_DATE16",chq_reg_pay_date16min),
					new SqlParameter("maxCHQ_REG_PAY_DATE16",chq_reg_pay_date16max),
					new SqlParameter("minCHQ_REG_PAY_DATE17",chq_reg_pay_date17min),
					new SqlParameter("maxCHQ_REG_PAY_DATE17",chq_reg_pay_date17max),
					new SqlParameter("minCHQ_REG_PAY_DATE18",chq_reg_pay_date18min),
					new SqlParameter("maxCHQ_REG_PAY_DATE18",chq_reg_pay_date18max),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F060_CHEQUE_REG_MSTR_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F060_CHEQUE_REG_MSTR>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F060_CHEQUE_REG_MSTR_Search]", parameters);
            var collection = new ObservableCollection<F060_CHEQUE_REG_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F060_CHEQUE_REG_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CHQ_REG_CLINIC_NBR_1_2 = ConvertDEC(Reader["CHQ_REG_CLINIC_NBR_1_2"]),
					CHQ_REG_DEPT = ConvertDEC(Reader["CHQ_REG_DEPT"]),
					CHQ_REG_DOC_NBR = Reader["CHQ_REG_DOC_NBR"].ToString(),
					CHQ_REG_PERC_BILL1 = ConvertDEC(Reader["CHQ_REG_PERC_BILL1"]),
					CHQ_REG_PERC_BILL2 = ConvertDEC(Reader["CHQ_REG_PERC_BILL2"]),
					CHQ_REG_PERC_BILL3 = ConvertDEC(Reader["CHQ_REG_PERC_BILL3"]),
					CHQ_REG_PERC_BILL4 = ConvertDEC(Reader["CHQ_REG_PERC_BILL4"]),
					CHQ_REG_PERC_BILL5 = ConvertDEC(Reader["CHQ_REG_PERC_BILL5"]),
					CHQ_REG_PERC_BILL6 = ConvertDEC(Reader["CHQ_REG_PERC_BILL6"]),
					CHQ_REG_PERC_BILL7 = ConvertDEC(Reader["CHQ_REG_PERC_BILL7"]),
					CHQ_REG_PERC_BILL8 = ConvertDEC(Reader["CHQ_REG_PERC_BILL8"]),
					CHQ_REG_PERC_BILL9 = ConvertDEC(Reader["CHQ_REG_PERC_BILL9"]),
					CHQ_REG_PERC_BILL10 = ConvertDEC(Reader["CHQ_REG_PERC_BILL10"]),
					CHQ_REG_PERC_BILL11 = ConvertDEC(Reader["CHQ_REG_PERC_BILL11"]),
					CHQ_REG_PERC_BILL12 = ConvertDEC(Reader["CHQ_REG_PERC_BILL12"]),
					CHQ_REG_PERC_BILL13 = ConvertDEC(Reader["CHQ_REG_PERC_BILL13"]),
					CHQ_REG_PERC_BILL14 = ConvertDEC(Reader["CHQ_REG_PERC_BILL14"]),
					CHQ_REG_PERC_BILL15 = ConvertDEC(Reader["CHQ_REG_PERC_BILL15"]),
					CHQ_REG_PERC_BILL16 = ConvertDEC(Reader["CHQ_REG_PERC_BILL16"]),
					CHQ_REG_PERC_BILL17 = ConvertDEC(Reader["CHQ_REG_PERC_BILL17"]),
					CHQ_REG_PERC_BILL18 = ConvertDEC(Reader["CHQ_REG_PERC_BILL18"]),
					CHQ_REG_PERC_MISC1 = ConvertDEC(Reader["CHQ_REG_PERC_MISC1"]),
					CHQ_REG_PERC_MISC2 = ConvertDEC(Reader["CHQ_REG_PERC_MISC2"]),
					CHQ_REG_PERC_MISC3 = ConvertDEC(Reader["CHQ_REG_PERC_MISC3"]),
					CHQ_REG_PERC_MISC4 = ConvertDEC(Reader["CHQ_REG_PERC_MISC4"]),
					CHQ_REG_PERC_MISC5 = ConvertDEC(Reader["CHQ_REG_PERC_MISC5"]),
					CHQ_REG_PERC_MISC6 = ConvertDEC(Reader["CHQ_REG_PERC_MISC6"]),
					CHQ_REG_PERC_MISC7 = ConvertDEC(Reader["CHQ_REG_PERC_MISC7"]),
					CHQ_REG_PERC_MISC8 = ConvertDEC(Reader["CHQ_REG_PERC_MISC8"]),
					CHQ_REG_PERC_MISC9 = ConvertDEC(Reader["CHQ_REG_PERC_MISC9"]),
					CHQ_REG_PERC_MISC10 = ConvertDEC(Reader["CHQ_REG_PERC_MISC10"]),
					CHQ_REG_PERC_MISC11 = ConvertDEC(Reader["CHQ_REG_PERC_MISC11"]),
					CHQ_REG_PERC_MISC12 = ConvertDEC(Reader["CHQ_REG_PERC_MISC12"]),
					CHQ_REG_PERC_MISC13 = ConvertDEC(Reader["CHQ_REG_PERC_MISC13"]),
					CHQ_REG_PERC_MISC14 = ConvertDEC(Reader["CHQ_REG_PERC_MISC14"]),
					CHQ_REG_PERC_MISC15 = ConvertDEC(Reader["CHQ_REG_PERC_MISC15"]),
					CHQ_REG_PERC_MISC16 = ConvertDEC(Reader["CHQ_REG_PERC_MISC16"]),
					CHQ_REG_PERC_MISC17 = ConvertDEC(Reader["CHQ_REG_PERC_MISC17"]),
					CHQ_REG_PERC_MISC18 = ConvertDEC(Reader["CHQ_REG_PERC_MISC18"]),
					CHQ_REG_PAY_CODE1 = Reader["CHQ_REG_PAY_CODE1"].ToString(),
					CHQ_REG_PAY_CODE2 = Reader["CHQ_REG_PAY_CODE2"].ToString(),
					CHQ_REG_PAY_CODE3 = Reader["CHQ_REG_PAY_CODE3"].ToString(),
					CHQ_REG_PAY_CODE4 = Reader["CHQ_REG_PAY_CODE4"].ToString(),
					CHQ_REG_PAY_CODE5 = Reader["CHQ_REG_PAY_CODE5"].ToString(),
					CHQ_REG_PAY_CODE6 = Reader["CHQ_REG_PAY_CODE6"].ToString(),
					CHQ_REG_PAY_CODE7 = Reader["CHQ_REG_PAY_CODE7"].ToString(),
					CHQ_REG_PAY_CODE8 = Reader["CHQ_REG_PAY_CODE8"].ToString(),
					CHQ_REG_PAY_CODE9 = Reader["CHQ_REG_PAY_CODE9"].ToString(),
					CHQ_REG_PAY_CODE10 = Reader["CHQ_REG_PAY_CODE10"].ToString(),
					CHQ_REG_PAY_CODE11 = Reader["CHQ_REG_PAY_CODE11"].ToString(),
					CHQ_REG_PAY_CODE12 = Reader["CHQ_REG_PAY_CODE12"].ToString(),
					CHQ_REG_PAY_CODE13 = Reader["CHQ_REG_PAY_CODE13"].ToString(),
					CHQ_REG_PAY_CODE14 = Reader["CHQ_REG_PAY_CODE14"].ToString(),
					CHQ_REG_PAY_CODE15 = Reader["CHQ_REG_PAY_CODE15"].ToString(),
					CHQ_REG_PAY_CODE16 = Reader["CHQ_REG_PAY_CODE16"].ToString(),
					CHQ_REG_PAY_CODE17 = Reader["CHQ_REG_PAY_CODE17"].ToString(),
					CHQ_REG_PAY_CODE18 = Reader["CHQ_REG_PAY_CODE18"].ToString(),
					CHQ_REG_PERC_TAX1 = ConvertDEC(Reader["CHQ_REG_PERC_TAX1"]),
					CHQ_REG_PERC_TAX2 = ConvertDEC(Reader["CHQ_REG_PERC_TAX2"]),
					CHQ_REG_PERC_TAX3 = ConvertDEC(Reader["CHQ_REG_PERC_TAX3"]),
					CHQ_REG_PERC_TAX4 = ConvertDEC(Reader["CHQ_REG_PERC_TAX4"]),
					CHQ_REG_PERC_TAX5 = ConvertDEC(Reader["CHQ_REG_PERC_TAX5"]),
					CHQ_REG_PERC_TAX6 = ConvertDEC(Reader["CHQ_REG_PERC_TAX6"]),
					CHQ_REG_PERC_TAX7 = ConvertDEC(Reader["CHQ_REG_PERC_TAX7"]),
					CHQ_REG_PERC_TAX8 = ConvertDEC(Reader["CHQ_REG_PERC_TAX8"]),
					CHQ_REG_PERC_TAX9 = ConvertDEC(Reader["CHQ_REG_PERC_TAX9"]),
					CHQ_REG_PERC_TAX10 = ConvertDEC(Reader["CHQ_REG_PERC_TAX10"]),
					CHQ_REG_PERC_TAX11 = ConvertDEC(Reader["CHQ_REG_PERC_TAX11"]),
					CHQ_REG_PERC_TAX12 = ConvertDEC(Reader["CHQ_REG_PERC_TAX12"]),
					CHQ_REG_PERC_TAX13 = ConvertDEC(Reader["CHQ_REG_PERC_TAX13"]),
					CHQ_REG_PERC_TAX14 = ConvertDEC(Reader["CHQ_REG_PERC_TAX14"]),
					CHQ_REG_PERC_TAX15 = ConvertDEC(Reader["CHQ_REG_PERC_TAX15"]),
					CHQ_REG_PERC_TAX16 = ConvertDEC(Reader["CHQ_REG_PERC_TAX16"]),
					CHQ_REG_PERC_TAX17 = ConvertDEC(Reader["CHQ_REG_PERC_TAX17"]),
					CHQ_REG_PERC_TAX18 = ConvertDEC(Reader["CHQ_REG_PERC_TAX18"]),
					CHQ_REG_MTH_BILL_AMT1 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT1"]),
					CHQ_REG_MTH_BILL_AMT2 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT2"]),
					CHQ_REG_MTH_BILL_AMT3 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT3"]),
					CHQ_REG_MTH_BILL_AMT4 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT4"]),
					CHQ_REG_MTH_BILL_AMT5 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT5"]),
					CHQ_REG_MTH_BILL_AMT6 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT6"]),
					CHQ_REG_MTH_BILL_AMT7 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT7"]),
					CHQ_REG_MTH_BILL_AMT8 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT8"]),
					CHQ_REG_MTH_BILL_AMT9 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT9"]),
					CHQ_REG_MTH_BILL_AMT10 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT10"]),
					CHQ_REG_MTH_BILL_AMT11 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT11"]),
					CHQ_REG_MTH_BILL_AMT12 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT12"]),
					CHQ_REG_MTH_BILL_AMT13 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT13"]),
					CHQ_REG_MTH_BILL_AMT14 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT14"]),
					CHQ_REG_MTH_BILL_AMT15 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT15"]),
					CHQ_REG_MTH_BILL_AMT16 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT16"]),
					CHQ_REG_MTH_BILL_AMT17 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT17"]),
					CHQ_REG_MTH_BILL_AMT18 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT18"]),
					CHQ_REG_MTH_MISC_AMT_11 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_11"]),
					CHQ_REG_MTH_MISC_AMT_12 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_12"]),
					CHQ_REG_MTH_MISC_AMT_13 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_13"]),
					CHQ_REG_MTH_MISC_AMT_14 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_14"]),
					CHQ_REG_MTH_MISC_AMT_15 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_15"]),
					CHQ_REG_MTH_MISC_AMT_16 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_16"]),
					CHQ_REG_MTH_MISC_AMT_17 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_17"]),
					CHQ_REG_MTH_MISC_AMT_18 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_18"]),
					CHQ_REG_MTH_MISC_AMT_19 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_19"]),
					CHQ_REG_MTH_MISC_AMT_110 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_110"]),
					CHQ_REG_MTH_MISC_AMT_111 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_111"]),
					CHQ_REG_MTH_MISC_AMT_112 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_112"]),
					CHQ_REG_MTH_MISC_AMT_113 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_113"]),
					CHQ_REG_MTH_MISC_AMT_114 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_114"]),
					CHQ_REG_MTH_MISC_AMT_115 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_115"]),
					CHQ_REG_MTH_MISC_AMT_116 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_116"]),
					CHQ_REG_MTH_MISC_AMT_117 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_117"]),
					CHQ_REG_MTH_MISC_AMT_118 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_118"]),
					CHQ_REG_MTH_MISC_AMT_21 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_21"]),
					CHQ_REG_MTH_MISC_AMT_22 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_22"]),
					CHQ_REG_MTH_MISC_AMT_23 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_23"]),
					CHQ_REG_MTH_MISC_AMT_24 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_24"]),
					CHQ_REG_MTH_MISC_AMT_25 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_25"]),
					CHQ_REG_MTH_MISC_AMT_26 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_26"]),
					CHQ_REG_MTH_MISC_AMT_27 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_27"]),
					CHQ_REG_MTH_MISC_AMT_28 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_28"]),
					CHQ_REG_MTH_MISC_AMT_29 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_29"]),
					CHQ_REG_MTH_MISC_AMT_210 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_210"]),
					CHQ_REG_MTH_MISC_AMT_211 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_211"]),
					CHQ_REG_MTH_MISC_AMT_212 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_212"]),
					CHQ_REG_MTH_MISC_AMT_213 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_213"]),
					CHQ_REG_MTH_MISC_AMT_214 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_214"]),
					CHQ_REG_MTH_MISC_AMT_215 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_215"]),
					CHQ_REG_MTH_MISC_AMT_216 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_216"]),
					CHQ_REG_MTH_MISC_AMT_217 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_217"]),
					CHQ_REG_MTH_MISC_AMT_218 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_218"]),
					CHQ_REG_MTH_MISC_AMT_31 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_31"]),
					CHQ_REG_MTH_MISC_AMT_32 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_32"]),
					CHQ_REG_MTH_MISC_AMT_33 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_33"]),
					CHQ_REG_MTH_MISC_AMT_34 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_34"]),
					CHQ_REG_MTH_MISC_AMT_35 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_35"]),
					CHQ_REG_MTH_MISC_AMT_36 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_36"]),
					CHQ_REG_MTH_MISC_AMT_37 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_37"]),
					CHQ_REG_MTH_MISC_AMT_38 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_38"]),
					CHQ_REG_MTH_MISC_AMT_39 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_39"]),
					CHQ_REG_MTH_MISC_AMT_310 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_310"]),
					CHQ_REG_MTH_MISC_AMT_311 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_311"]),
					CHQ_REG_MTH_MISC_AMT_312 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_312"]),
					CHQ_REG_MTH_MISC_AMT_313 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_313"]),
					CHQ_REG_MTH_MISC_AMT_314 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_314"]),
					CHQ_REG_MTH_MISC_AMT_315 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_315"]),
					CHQ_REG_MTH_MISC_AMT_316 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_316"]),
					CHQ_REG_MTH_MISC_AMT_317 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_317"]),
					CHQ_REG_MTH_MISC_AMT_318 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_318"]),
					CHQ_REG_MTH_MISC_AMT_41 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_41"]),
					CHQ_REG_MTH_MISC_AMT_42 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_42"]),
					CHQ_REG_MTH_MISC_AMT_43 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_43"]),
					CHQ_REG_MTH_MISC_AMT_44 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_44"]),
					CHQ_REG_MTH_MISC_AMT_45 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_45"]),
					CHQ_REG_MTH_MISC_AMT_46 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_46"]),
					CHQ_REG_MTH_MISC_AMT_47 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_47"]),
					CHQ_REG_MTH_MISC_AMT_48 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_48"]),
					CHQ_REG_MTH_MISC_AMT_49 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_49"]),
					CHQ_REG_MTH_MISC_AMT_410 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_410"]),
					CHQ_REG_MTH_MISC_AMT_411 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_411"]),
					CHQ_REG_MTH_MISC_AMT_412 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_412"]),
					CHQ_REG_MTH_MISC_AMT_413 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_413"]),
					CHQ_REG_MTH_MISC_AMT_414 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_414"]),
					CHQ_REG_MTH_MISC_AMT_415 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_415"]),
					CHQ_REG_MTH_MISC_AMT_416 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_416"]),
					CHQ_REG_MTH_MISC_AMT_417 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_417"]),
					CHQ_REG_MTH_MISC_AMT_418 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_418"]),
					CHQ_REG_MTH_MISC_AMT_51 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_51"]),
					CHQ_REG_MTH_MISC_AMT_52 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_52"]),
					CHQ_REG_MTH_MISC_AMT_53 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_53"]),
					CHQ_REG_MTH_MISC_AMT_54 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_54"]),
					CHQ_REG_MTH_MISC_AMT_55 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_55"]),
					CHQ_REG_MTH_MISC_AMT_56 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_56"]),
					CHQ_REG_MTH_MISC_AMT_57 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_57"]),
					CHQ_REG_MTH_MISC_AMT_58 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_58"]),
					CHQ_REG_MTH_MISC_AMT_59 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_59"]),
					CHQ_REG_MTH_MISC_AMT_510 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_510"]),
					CHQ_REG_MTH_MISC_AMT_511 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_511"]),
					CHQ_REG_MTH_MISC_AMT_512 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_512"]),
					CHQ_REG_MTH_MISC_AMT_513 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_513"]),
					CHQ_REG_MTH_MISC_AMT_514 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_514"]),
					CHQ_REG_MTH_MISC_AMT_515 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_515"]),
					CHQ_REG_MTH_MISC_AMT_516 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_516"]),
					CHQ_REG_MTH_MISC_AMT_517 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_517"]),
					CHQ_REG_MTH_MISC_AMT_518 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_518"]),
					CHQ_REG_MTH_MISC_AMT_61 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_61"]),
					CHQ_REG_MTH_MISC_AMT_62 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_62"]),
					CHQ_REG_MTH_MISC_AMT_63 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_63"]),
					CHQ_REG_MTH_MISC_AMT_64 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_64"]),
					CHQ_REG_MTH_MISC_AMT_65 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_65"]),
					CHQ_REG_MTH_MISC_AMT_66 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_66"]),
					CHQ_REG_MTH_MISC_AMT_67 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_67"]),
					CHQ_REG_MTH_MISC_AMT_68 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_68"]),
					CHQ_REG_MTH_MISC_AMT_69 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_69"]),
					CHQ_REG_MTH_MISC_AMT_610 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_610"]),
					CHQ_REG_MTH_MISC_AMT_611 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_611"]),
					CHQ_REG_MTH_MISC_AMT_612 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_612"]),
					CHQ_REG_MTH_MISC_AMT_613 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_613"]),
					CHQ_REG_MTH_MISC_AMT_614 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_614"]),
					CHQ_REG_MTH_MISC_AMT_615 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_615"]),
					CHQ_REG_MTH_MISC_AMT_616 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_616"]),
					CHQ_REG_MTH_MISC_AMT_617 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_617"]),
					CHQ_REG_MTH_MISC_AMT_618 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_618"]),
					CHQ_REG_MTH_MISC_AMT_71 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_71"]),
					CHQ_REG_MTH_MISC_AMT_72 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_72"]),
					CHQ_REG_MTH_MISC_AMT_73 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_73"]),
					CHQ_REG_MTH_MISC_AMT_74 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_74"]),
					CHQ_REG_MTH_MISC_AMT_75 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_75"]),
					CHQ_REG_MTH_MISC_AMT_76 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_76"]),
					CHQ_REG_MTH_MISC_AMT_77 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_77"]),
					CHQ_REG_MTH_MISC_AMT_78 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_78"]),
					CHQ_REG_MTH_MISC_AMT_79 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_79"]),
					CHQ_REG_MTH_MISC_AMT_710 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_710"]),
					CHQ_REG_MTH_MISC_AMT_711 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_711"]),
					CHQ_REG_MTH_MISC_AMT_712 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_712"]),
					CHQ_REG_MTH_MISC_AMT_713 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_713"]),
					CHQ_REG_MTH_MISC_AMT_714 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_714"]),
					CHQ_REG_MTH_MISC_AMT_715 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_715"]),
					CHQ_REG_MTH_MISC_AMT_716 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_716"]),
					CHQ_REG_MTH_MISC_AMT_717 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_717"]),
					CHQ_REG_MTH_MISC_AMT_718 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_718"]),
					CHQ_REG_MTH_MISC_AMT_81 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_81"]),
					CHQ_REG_MTH_MISC_AMT_82 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_82"]),
					CHQ_REG_MTH_MISC_AMT_83 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_83"]),
					CHQ_REG_MTH_MISC_AMT_84 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_84"]),
					CHQ_REG_MTH_MISC_AMT_85 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_85"]),
					CHQ_REG_MTH_MISC_AMT_86 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_86"]),
					CHQ_REG_MTH_MISC_AMT_87 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_87"]),
					CHQ_REG_MTH_MISC_AMT_88 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_88"]),
					CHQ_REG_MTH_MISC_AMT_89 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_89"]),
					CHQ_REG_MTH_MISC_AMT_810 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_810"]),
					CHQ_REG_MTH_MISC_AMT_811 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_811"]),
					CHQ_REG_MTH_MISC_AMT_812 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_812"]),
					CHQ_REG_MTH_MISC_AMT_813 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_813"]),
					CHQ_REG_MTH_MISC_AMT_814 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_814"]),
					CHQ_REG_MTH_MISC_AMT_815 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_815"]),
					CHQ_REG_MTH_MISC_AMT_816 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_816"]),
					CHQ_REG_MTH_MISC_AMT_817 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_817"]),
					CHQ_REG_MTH_MISC_AMT_818 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_818"]),
					CHQ_REG_MTH_MISC_AMT_91 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_91"]),
					CHQ_REG_MTH_MISC_AMT_92 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_92"]),
					CHQ_REG_MTH_MISC_AMT_93 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_93"]),
					CHQ_REG_MTH_MISC_AMT_94 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_94"]),
					CHQ_REG_MTH_MISC_AMT_95 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_95"]),
					CHQ_REG_MTH_MISC_AMT_96 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_96"]),
					CHQ_REG_MTH_MISC_AMT_97 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_97"]),
					CHQ_REG_MTH_MISC_AMT_98 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_98"]),
					CHQ_REG_MTH_MISC_AMT_99 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_99"]),
					CHQ_REG_MTH_MISC_AMT_910 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_910"]),
					CHQ_REG_MTH_MISC_AMT_911 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_911"]),
					CHQ_REG_MTH_MISC_AMT_912 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_912"]),
					CHQ_REG_MTH_MISC_AMT_913 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_913"]),
					CHQ_REG_MTH_MISC_AMT_914 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_914"]),
					CHQ_REG_MTH_MISC_AMT_915 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_915"]),
					CHQ_REG_MTH_MISC_AMT_916 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_916"]),
					CHQ_REG_MTH_MISC_AMT_917 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_917"]),
					CHQ_REG_MTH_MISC_AMT_918 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_918"]),
					CHQ_REG_MTH_MISC_AMT_101 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_101"]),
					CHQ_REG_MTH_MISC_AMT_102 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_102"]),
					CHQ_REG_MTH_MISC_AMT_103 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_103"]),
					CHQ_REG_MTH_MISC_AMT_104 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_104"]),
					CHQ_REG_MTH_MISC_AMT_105 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_105"]),
					CHQ_REG_MTH_MISC_AMT_106 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_106"]),
					CHQ_REG_MTH_MISC_AMT_107 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_107"]),
					CHQ_REG_MTH_MISC_AMT_108 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_108"]),
					CHQ_REG_MTH_MISC_AMT_109 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_109"]),
					CHQ_REG_MTH_MISC_AMT_1010 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1010"]),
					CHQ_REG_MTH_MISC_AMT_1011 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1011"]),
					CHQ_REG_MTH_MISC_AMT_1012 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1012"]),
					CHQ_REG_MTH_MISC_AMT_1013 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1013"]),
					CHQ_REG_MTH_MISC_AMT_1014 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1014"]),
					CHQ_REG_MTH_MISC_AMT_1015 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1015"]),
					CHQ_REG_MTH_MISC_AMT_1016 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1016"]),
					CHQ_REG_MTH_MISC_AMT_1017 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1017"]),
					CHQ_REG_MTH_MISC_AMT_1018 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1018"]),
					CHQ_REG_MTH_EXP_AMT1 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT1"]),
					CHQ_REG_MTH_EXP_AMT2 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT2"]),
					CHQ_REG_MTH_EXP_AMT3 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT3"]),
					CHQ_REG_MTH_EXP_AMT4 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT4"]),
					CHQ_REG_MTH_EXP_AMT5 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT5"]),
					CHQ_REG_MTH_EXP_AMT6 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT6"]),
					CHQ_REG_MTH_EXP_AMT7 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT7"]),
					CHQ_REG_MTH_EXP_AMT8 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT8"]),
					CHQ_REG_MTH_EXP_AMT9 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT9"]),
					CHQ_REG_MTH_EXP_AMT10 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT10"]),
					CHQ_REG_MTH_EXP_AMT11 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT11"]),
					CHQ_REG_MTH_EXP_AMT12 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT12"]),
					CHQ_REG_MTH_EXP_AMT13 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT13"]),
					CHQ_REG_MTH_EXP_AMT14 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT14"]),
					CHQ_REG_MTH_EXP_AMT15 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT15"]),
					CHQ_REG_MTH_EXP_AMT16 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT16"]),
					CHQ_REG_MTH_EXP_AMT17 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT17"]),
					CHQ_REG_MTH_EXP_AMT18 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT18"]),
					CHQ_REG_COMP_ANN_EXP_THIS_PAY1 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY1"]),
					CHQ_REG_COMP_ANN_EXP_THIS_PAY2 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY2"]),
					CHQ_REG_COMP_ANN_EXP_THIS_PAY3 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY3"]),
					CHQ_REG_COMP_ANN_EXP_THIS_PAY4 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY4"]),
					CHQ_REG_COMP_ANN_EXP_THIS_PAY5 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY5"]),
					CHQ_REG_COMP_ANN_EXP_THIS_PAY6 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY6"]),
					CHQ_REG_COMP_ANN_EXP_THIS_PAY7 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY7"]),
					CHQ_REG_COMP_ANN_EXP_THIS_PAY8 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY8"]),
					CHQ_REG_COMP_ANN_EXP_THIS_PAY9 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY9"]),
					CHQ_REG_COMP_ANN_EXP_THIS_PAY10 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY10"]),
					CHQ_REG_COMP_ANN_EXP_THIS_PAY11 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY11"]),
					CHQ_REG_COMP_ANN_EXP_THIS_PAY12 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY12"]),
					CHQ_REG_COMP_ANN_EXP_THIS_PAY13 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY13"]),
					CHQ_REG_COMP_ANN_EXP_THIS_PAY14 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY14"]),
					CHQ_REG_COMP_ANN_EXP_THIS_PAY15 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY15"]),
					CHQ_REG_COMP_ANN_EXP_THIS_PAY16 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY16"]),
					CHQ_REG_COMP_ANN_EXP_THIS_PAY17 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY17"]),
					CHQ_REG_COMP_ANN_EXP_THIS_PAY18 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY18"]),
					CHQ_REG_MTH_CEIL_AMT1 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT1"]),
					CHQ_REG_MTH_CEIL_AMT2 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT2"]),
					CHQ_REG_MTH_CEIL_AMT3 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT3"]),
					CHQ_REG_MTH_CEIL_AMT4 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT4"]),
					CHQ_REG_MTH_CEIL_AMT5 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT5"]),
					CHQ_REG_MTH_CEIL_AMT6 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT6"]),
					CHQ_REG_MTH_CEIL_AMT7 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT7"]),
					CHQ_REG_MTH_CEIL_AMT8 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT8"]),
					CHQ_REG_MTH_CEIL_AMT9 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT9"]),
					CHQ_REG_MTH_CEIL_AMT10 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT10"]),
					CHQ_REG_MTH_CEIL_AMT11 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT11"]),
					CHQ_REG_MTH_CEIL_AMT12 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT12"]),
					CHQ_REG_MTH_CEIL_AMT13 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT13"]),
					CHQ_REG_MTH_CEIL_AMT14 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT14"]),
					CHQ_REG_MTH_CEIL_AMT15 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT15"]),
					CHQ_REG_MTH_CEIL_AMT16 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT16"]),
					CHQ_REG_MTH_CEIL_AMT17 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT17"]),
					CHQ_REG_MTH_CEIL_AMT18 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT18"]),
					CHQ_REG_COMP_ANN_CEIL_THIS_PAY1 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY1"]),
					CHQ_REG_COMP_ANN_CEIL_THIS_PAY2 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY2"]),
					CHQ_REG_COMP_ANN_CEIL_THIS_PAY3 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY3"]),
					CHQ_REG_COMP_ANN_CEIL_THIS_PAY4 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY4"]),
					CHQ_REG_COMP_ANN_CEIL_THIS_PAY5 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY5"]),
					CHQ_REG_COMP_ANN_CEIL_THIS_PAY6 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY6"]),
					CHQ_REG_COMP_ANN_CEIL_THIS_PAY7 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY7"]),
					CHQ_REG_COMP_ANN_CEIL_THIS_PAY8 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY8"]),
					CHQ_REG_COMP_ANN_CEIL_THIS_PAY9 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY9"]),
					CHQ_REG_COMP_ANN_CEIL_THIS_PAY10 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY10"]),
					CHQ_REG_COMP_ANN_CEIL_THIS_PAY11 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY11"]),
					CHQ_REG_COMP_ANN_CEIL_THIS_PAY12 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY12"]),
					CHQ_REG_COMP_ANN_CEIL_THIS_PAY13 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY13"]),
					CHQ_REG_COMP_ANN_CEIL_THIS_PAY14 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY14"]),
					CHQ_REG_COMP_ANN_CEIL_THIS_PAY15 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY15"]),
					CHQ_REG_COMP_ANN_CEIL_THIS_PAY16 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY16"]),
					CHQ_REG_COMP_ANN_CEIL_THIS_PAY17 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY17"]),
					CHQ_REG_COMP_ANN_CEIL_THIS_PAY18 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY18"]),
					CHQ_REG_EARNINGS_THIS_MTH1 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH1"]),
					CHQ_REG_EARNINGS_THIS_MTH2 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH2"]),
					CHQ_REG_EARNINGS_THIS_MTH3 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH3"]),
					CHQ_REG_EARNINGS_THIS_MTH4 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH4"]),
					CHQ_REG_EARNINGS_THIS_MTH5 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH5"]),
					CHQ_REG_EARNINGS_THIS_MTH6 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH6"]),
					CHQ_REG_EARNINGS_THIS_MTH7 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH7"]),
					CHQ_REG_EARNINGS_THIS_MTH8 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH8"]),
					CHQ_REG_EARNINGS_THIS_MTH9 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH9"]),
					CHQ_REG_EARNINGS_THIS_MTH10 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH10"]),
					CHQ_REG_EARNINGS_THIS_MTH11 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH11"]),
					CHQ_REG_EARNINGS_THIS_MTH12 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH12"]),
					CHQ_REG_EARNINGS_THIS_MTH13 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH13"]),
					CHQ_REG_EARNINGS_THIS_MTH14 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH14"]),
					CHQ_REG_EARNINGS_THIS_MTH15 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH15"]),
					CHQ_REG_EARNINGS_THIS_MTH16 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH16"]),
					CHQ_REG_EARNINGS_THIS_MTH17 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH17"]),
					CHQ_REG_EARNINGS_THIS_MTH18 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH18"]),
					CHQ_REG_REGULAR_PAY_THIS_MTH1 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH1"]),
					CHQ_REG_REGULAR_PAY_THIS_MTH2 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH2"]),
					CHQ_REG_REGULAR_PAY_THIS_MTH3 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH3"]),
					CHQ_REG_REGULAR_PAY_THIS_MTH4 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH4"]),
					CHQ_REG_REGULAR_PAY_THIS_MTH5 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH5"]),
					CHQ_REG_REGULAR_PAY_THIS_MTH6 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH6"]),
					CHQ_REG_REGULAR_PAY_THIS_MTH7 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH7"]),
					CHQ_REG_REGULAR_PAY_THIS_MTH8 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH8"]),
					CHQ_REG_REGULAR_PAY_THIS_MTH9 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH9"]),
					CHQ_REG_REGULAR_PAY_THIS_MTH10 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH10"]),
					CHQ_REG_REGULAR_PAY_THIS_MTH11 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH11"]),
					CHQ_REG_REGULAR_PAY_THIS_MTH12 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH12"]),
					CHQ_REG_REGULAR_PAY_THIS_MTH13 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH13"]),
					CHQ_REG_REGULAR_PAY_THIS_MTH14 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH14"]),
					CHQ_REG_REGULAR_PAY_THIS_MTH15 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH15"]),
					CHQ_REG_REGULAR_PAY_THIS_MTH16 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH16"]),
					CHQ_REG_REGULAR_PAY_THIS_MTH17 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH17"]),
					CHQ_REG_REGULAR_PAY_THIS_MTH18 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH18"]),
					CHQ_REG_REGULAR_TAX_THIS_MTH1 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH1"]),
					CHQ_REG_REGULAR_TAX_THIS_MTH2 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH2"]),
					CHQ_REG_REGULAR_TAX_THIS_MTH3 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH3"]),
					CHQ_REG_REGULAR_TAX_THIS_MTH4 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH4"]),
					CHQ_REG_REGULAR_TAX_THIS_MTH5 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH5"]),
					CHQ_REG_REGULAR_TAX_THIS_MTH6 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH6"]),
					CHQ_REG_REGULAR_TAX_THIS_MTH7 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH7"]),
					CHQ_REG_REGULAR_TAX_THIS_MTH8 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH8"]),
					CHQ_REG_REGULAR_TAX_THIS_MTH9 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH9"]),
					CHQ_REG_REGULAR_TAX_THIS_MTH10 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH10"]),
					CHQ_REG_REGULAR_TAX_THIS_MTH11 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH11"]),
					CHQ_REG_REGULAR_TAX_THIS_MTH12 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH12"]),
					CHQ_REG_REGULAR_TAX_THIS_MTH13 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH13"]),
					CHQ_REG_REGULAR_TAX_THIS_MTH14 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH14"]),
					CHQ_REG_REGULAR_TAX_THIS_MTH15 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH15"]),
					CHQ_REG_REGULAR_TAX_THIS_MTH16 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH16"]),
					CHQ_REG_REGULAR_TAX_THIS_MTH17 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH17"]),
					CHQ_REG_REGULAR_TAX_THIS_MTH18 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH18"]),
					CHQ_REG_MAN_PAY_THIS_MTH1 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH1"]),
					CHQ_REG_MAN_PAY_THIS_MTH2 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH2"]),
					CHQ_REG_MAN_PAY_THIS_MTH3 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH3"]),
					CHQ_REG_MAN_PAY_THIS_MTH4 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH4"]),
					CHQ_REG_MAN_PAY_THIS_MTH5 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH5"]),
					CHQ_REG_MAN_PAY_THIS_MTH6 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH6"]),
					CHQ_REG_MAN_PAY_THIS_MTH7 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH7"]),
					CHQ_REG_MAN_PAY_THIS_MTH8 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH8"]),
					CHQ_REG_MAN_PAY_THIS_MTH9 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH9"]),
					CHQ_REG_MAN_PAY_THIS_MTH10 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH10"]),
					CHQ_REG_MAN_PAY_THIS_MTH11 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH11"]),
					CHQ_REG_MAN_PAY_THIS_MTH12 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH12"]),
					CHQ_REG_MAN_PAY_THIS_MTH13 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH13"]),
					CHQ_REG_MAN_PAY_THIS_MTH14 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH14"]),
					CHQ_REG_MAN_PAY_THIS_MTH15 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH15"]),
					CHQ_REG_MAN_PAY_THIS_MTH16 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH16"]),
					CHQ_REG_MAN_PAY_THIS_MTH17 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH17"]),
					CHQ_REG_MAN_PAY_THIS_MTH18 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH18"]),
					CHQ_REG_MAN_TAX_THIS_MTH1 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH1"]),
					CHQ_REG_MAN_TAX_THIS_MTH2 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH2"]),
					CHQ_REG_MAN_TAX_THIS_MTH3 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH3"]),
					CHQ_REG_MAN_TAX_THIS_MTH4 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH4"]),
					CHQ_REG_MAN_TAX_THIS_MTH5 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH5"]),
					CHQ_REG_MAN_TAX_THIS_MTH6 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH6"]),
					CHQ_REG_MAN_TAX_THIS_MTH7 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH7"]),
					CHQ_REG_MAN_TAX_THIS_MTH8 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH8"]),
					CHQ_REG_MAN_TAX_THIS_MTH9 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH9"]),
					CHQ_REG_MAN_TAX_THIS_MTH10 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH10"]),
					CHQ_REG_MAN_TAX_THIS_MTH11 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH11"]),
					CHQ_REG_MAN_TAX_THIS_MTH12 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH12"]),
					CHQ_REG_MAN_TAX_THIS_MTH13 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH13"]),
					CHQ_REG_MAN_TAX_THIS_MTH14 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH14"]),
					CHQ_REG_MAN_TAX_THIS_MTH15 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH15"]),
					CHQ_REG_MAN_TAX_THIS_MTH16 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH16"]),
					CHQ_REG_MAN_TAX_THIS_MTH17 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH17"]),
					CHQ_REG_MAN_TAX_THIS_MTH18 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH18"]),
					CHQ_REG_PAY_DATE1 = ConvertDEC(Reader["CHQ_REG_PAY_DATE1"]),
					CHQ_REG_PAY_DATE2 = ConvertDEC(Reader["CHQ_REG_PAY_DATE2"]),
					CHQ_REG_PAY_DATE3 = ConvertDEC(Reader["CHQ_REG_PAY_DATE3"]),
					CHQ_REG_PAY_DATE4 = ConvertDEC(Reader["CHQ_REG_PAY_DATE4"]),
					CHQ_REG_PAY_DATE5 = ConvertDEC(Reader["CHQ_REG_PAY_DATE5"]),
					CHQ_REG_PAY_DATE6 = ConvertDEC(Reader["CHQ_REG_PAY_DATE6"]),
					CHQ_REG_PAY_DATE7 = ConvertDEC(Reader["CHQ_REG_PAY_DATE7"]),
					CHQ_REG_PAY_DATE8 = ConvertDEC(Reader["CHQ_REG_PAY_DATE8"]),
					CHQ_REG_PAY_DATE9 = ConvertDEC(Reader["CHQ_REG_PAY_DATE9"]),
					CHQ_REG_PAY_DATE10 = ConvertDEC(Reader["CHQ_REG_PAY_DATE10"]),
					CHQ_REG_PAY_DATE11 = ConvertDEC(Reader["CHQ_REG_PAY_DATE11"]),
					CHQ_REG_PAY_DATE12 = ConvertDEC(Reader["CHQ_REG_PAY_DATE12"]),
					CHQ_REG_PAY_DATE13 = ConvertDEC(Reader["CHQ_REG_PAY_DATE13"]),
					CHQ_REG_PAY_DATE14 = ConvertDEC(Reader["CHQ_REG_PAY_DATE14"]),
					CHQ_REG_PAY_DATE15 = ConvertDEC(Reader["CHQ_REG_PAY_DATE15"]),
					CHQ_REG_PAY_DATE16 = ConvertDEC(Reader["CHQ_REG_PAY_DATE16"]),
					CHQ_REG_PAY_DATE17 = ConvertDEC(Reader["CHQ_REG_PAY_DATE17"]),
					CHQ_REG_PAY_DATE18 = ConvertDEC(Reader["CHQ_REG_PAY_DATE18"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalChq_reg_clinic_nbr_1_2 = ConvertDEC(Reader["CHQ_REG_CLINIC_NBR_1_2"]),
					_originalChq_reg_dept = ConvertDEC(Reader["CHQ_REG_DEPT"]),
					_originalChq_reg_doc_nbr = Reader["CHQ_REG_DOC_NBR"].ToString(),
					_originalChq_reg_perc_bill1 = ConvertDEC(Reader["CHQ_REG_PERC_BILL1"]),
					_originalChq_reg_perc_bill2 = ConvertDEC(Reader["CHQ_REG_PERC_BILL2"]),
					_originalChq_reg_perc_bill3 = ConvertDEC(Reader["CHQ_REG_PERC_BILL3"]),
					_originalChq_reg_perc_bill4 = ConvertDEC(Reader["CHQ_REG_PERC_BILL4"]),
					_originalChq_reg_perc_bill5 = ConvertDEC(Reader["CHQ_REG_PERC_BILL5"]),
					_originalChq_reg_perc_bill6 = ConvertDEC(Reader["CHQ_REG_PERC_BILL6"]),
					_originalChq_reg_perc_bill7 = ConvertDEC(Reader["CHQ_REG_PERC_BILL7"]),
					_originalChq_reg_perc_bill8 = ConvertDEC(Reader["CHQ_REG_PERC_BILL8"]),
					_originalChq_reg_perc_bill9 = ConvertDEC(Reader["CHQ_REG_PERC_BILL9"]),
					_originalChq_reg_perc_bill10 = ConvertDEC(Reader["CHQ_REG_PERC_BILL10"]),
					_originalChq_reg_perc_bill11 = ConvertDEC(Reader["CHQ_REG_PERC_BILL11"]),
					_originalChq_reg_perc_bill12 = ConvertDEC(Reader["CHQ_REG_PERC_BILL12"]),
					_originalChq_reg_perc_bill13 = ConvertDEC(Reader["CHQ_REG_PERC_BILL13"]),
					_originalChq_reg_perc_bill14 = ConvertDEC(Reader["CHQ_REG_PERC_BILL14"]),
					_originalChq_reg_perc_bill15 = ConvertDEC(Reader["CHQ_REG_PERC_BILL15"]),
					_originalChq_reg_perc_bill16 = ConvertDEC(Reader["CHQ_REG_PERC_BILL16"]),
					_originalChq_reg_perc_bill17 = ConvertDEC(Reader["CHQ_REG_PERC_BILL17"]),
					_originalChq_reg_perc_bill18 = ConvertDEC(Reader["CHQ_REG_PERC_BILL18"]),
					_originalChq_reg_perc_misc1 = ConvertDEC(Reader["CHQ_REG_PERC_MISC1"]),
					_originalChq_reg_perc_misc2 = ConvertDEC(Reader["CHQ_REG_PERC_MISC2"]),
					_originalChq_reg_perc_misc3 = ConvertDEC(Reader["CHQ_REG_PERC_MISC3"]),
					_originalChq_reg_perc_misc4 = ConvertDEC(Reader["CHQ_REG_PERC_MISC4"]),
					_originalChq_reg_perc_misc5 = ConvertDEC(Reader["CHQ_REG_PERC_MISC5"]),
					_originalChq_reg_perc_misc6 = ConvertDEC(Reader["CHQ_REG_PERC_MISC6"]),
					_originalChq_reg_perc_misc7 = ConvertDEC(Reader["CHQ_REG_PERC_MISC7"]),
					_originalChq_reg_perc_misc8 = ConvertDEC(Reader["CHQ_REG_PERC_MISC8"]),
					_originalChq_reg_perc_misc9 = ConvertDEC(Reader["CHQ_REG_PERC_MISC9"]),
					_originalChq_reg_perc_misc10 = ConvertDEC(Reader["CHQ_REG_PERC_MISC10"]),
					_originalChq_reg_perc_misc11 = ConvertDEC(Reader["CHQ_REG_PERC_MISC11"]),
					_originalChq_reg_perc_misc12 = ConvertDEC(Reader["CHQ_REG_PERC_MISC12"]),
					_originalChq_reg_perc_misc13 = ConvertDEC(Reader["CHQ_REG_PERC_MISC13"]),
					_originalChq_reg_perc_misc14 = ConvertDEC(Reader["CHQ_REG_PERC_MISC14"]),
					_originalChq_reg_perc_misc15 = ConvertDEC(Reader["CHQ_REG_PERC_MISC15"]),
					_originalChq_reg_perc_misc16 = ConvertDEC(Reader["CHQ_REG_PERC_MISC16"]),
					_originalChq_reg_perc_misc17 = ConvertDEC(Reader["CHQ_REG_PERC_MISC17"]),
					_originalChq_reg_perc_misc18 = ConvertDEC(Reader["CHQ_REG_PERC_MISC18"]),
					_originalChq_reg_pay_code1 = Reader["CHQ_REG_PAY_CODE1"].ToString(),
					_originalChq_reg_pay_code2 = Reader["CHQ_REG_PAY_CODE2"].ToString(),
					_originalChq_reg_pay_code3 = Reader["CHQ_REG_PAY_CODE3"].ToString(),
					_originalChq_reg_pay_code4 = Reader["CHQ_REG_PAY_CODE4"].ToString(),
					_originalChq_reg_pay_code5 = Reader["CHQ_REG_PAY_CODE5"].ToString(),
					_originalChq_reg_pay_code6 = Reader["CHQ_REG_PAY_CODE6"].ToString(),
					_originalChq_reg_pay_code7 = Reader["CHQ_REG_PAY_CODE7"].ToString(),
					_originalChq_reg_pay_code8 = Reader["CHQ_REG_PAY_CODE8"].ToString(),
					_originalChq_reg_pay_code9 = Reader["CHQ_REG_PAY_CODE9"].ToString(),
					_originalChq_reg_pay_code10 = Reader["CHQ_REG_PAY_CODE10"].ToString(),
					_originalChq_reg_pay_code11 = Reader["CHQ_REG_PAY_CODE11"].ToString(),
					_originalChq_reg_pay_code12 = Reader["CHQ_REG_PAY_CODE12"].ToString(),
					_originalChq_reg_pay_code13 = Reader["CHQ_REG_PAY_CODE13"].ToString(),
					_originalChq_reg_pay_code14 = Reader["CHQ_REG_PAY_CODE14"].ToString(),
					_originalChq_reg_pay_code15 = Reader["CHQ_REG_PAY_CODE15"].ToString(),
					_originalChq_reg_pay_code16 = Reader["CHQ_REG_PAY_CODE16"].ToString(),
					_originalChq_reg_pay_code17 = Reader["CHQ_REG_PAY_CODE17"].ToString(),
					_originalChq_reg_pay_code18 = Reader["CHQ_REG_PAY_CODE18"].ToString(),
					_originalChq_reg_perc_tax1 = ConvertDEC(Reader["CHQ_REG_PERC_TAX1"]),
					_originalChq_reg_perc_tax2 = ConvertDEC(Reader["CHQ_REG_PERC_TAX2"]),
					_originalChq_reg_perc_tax3 = ConvertDEC(Reader["CHQ_REG_PERC_TAX3"]),
					_originalChq_reg_perc_tax4 = ConvertDEC(Reader["CHQ_REG_PERC_TAX4"]),
					_originalChq_reg_perc_tax5 = ConvertDEC(Reader["CHQ_REG_PERC_TAX5"]),
					_originalChq_reg_perc_tax6 = ConvertDEC(Reader["CHQ_REG_PERC_TAX6"]),
					_originalChq_reg_perc_tax7 = ConvertDEC(Reader["CHQ_REG_PERC_TAX7"]),
					_originalChq_reg_perc_tax8 = ConvertDEC(Reader["CHQ_REG_PERC_TAX8"]),
					_originalChq_reg_perc_tax9 = ConvertDEC(Reader["CHQ_REG_PERC_TAX9"]),
					_originalChq_reg_perc_tax10 = ConvertDEC(Reader["CHQ_REG_PERC_TAX10"]),
					_originalChq_reg_perc_tax11 = ConvertDEC(Reader["CHQ_REG_PERC_TAX11"]),
					_originalChq_reg_perc_tax12 = ConvertDEC(Reader["CHQ_REG_PERC_TAX12"]),
					_originalChq_reg_perc_tax13 = ConvertDEC(Reader["CHQ_REG_PERC_TAX13"]),
					_originalChq_reg_perc_tax14 = ConvertDEC(Reader["CHQ_REG_PERC_TAX14"]),
					_originalChq_reg_perc_tax15 = ConvertDEC(Reader["CHQ_REG_PERC_TAX15"]),
					_originalChq_reg_perc_tax16 = ConvertDEC(Reader["CHQ_REG_PERC_TAX16"]),
					_originalChq_reg_perc_tax17 = ConvertDEC(Reader["CHQ_REG_PERC_TAX17"]),
					_originalChq_reg_perc_tax18 = ConvertDEC(Reader["CHQ_REG_PERC_TAX18"]),
					_originalChq_reg_mth_bill_amt1 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT1"]),
					_originalChq_reg_mth_bill_amt2 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT2"]),
					_originalChq_reg_mth_bill_amt3 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT3"]),
					_originalChq_reg_mth_bill_amt4 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT4"]),
					_originalChq_reg_mth_bill_amt5 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT5"]),
					_originalChq_reg_mth_bill_amt6 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT6"]),
					_originalChq_reg_mth_bill_amt7 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT7"]),
					_originalChq_reg_mth_bill_amt8 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT8"]),
					_originalChq_reg_mth_bill_amt9 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT9"]),
					_originalChq_reg_mth_bill_amt10 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT10"]),
					_originalChq_reg_mth_bill_amt11 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT11"]),
					_originalChq_reg_mth_bill_amt12 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT12"]),
					_originalChq_reg_mth_bill_amt13 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT13"]),
					_originalChq_reg_mth_bill_amt14 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT14"]),
					_originalChq_reg_mth_bill_amt15 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT15"]),
					_originalChq_reg_mth_bill_amt16 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT16"]),
					_originalChq_reg_mth_bill_amt17 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT17"]),
					_originalChq_reg_mth_bill_amt18 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT18"]),
					_originalChq_reg_mth_misc_amt_11 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_11"]),
					_originalChq_reg_mth_misc_amt_12 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_12"]),
					_originalChq_reg_mth_misc_amt_13 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_13"]),
					_originalChq_reg_mth_misc_amt_14 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_14"]),
					_originalChq_reg_mth_misc_amt_15 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_15"]),
					_originalChq_reg_mth_misc_amt_16 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_16"]),
					_originalChq_reg_mth_misc_amt_17 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_17"]),
					_originalChq_reg_mth_misc_amt_18 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_18"]),
					_originalChq_reg_mth_misc_amt_19 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_19"]),
					_originalChq_reg_mth_misc_amt_110 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_110"]),
					_originalChq_reg_mth_misc_amt_111 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_111"]),
					_originalChq_reg_mth_misc_amt_112 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_112"]),
					_originalChq_reg_mth_misc_amt_113 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_113"]),
					_originalChq_reg_mth_misc_amt_114 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_114"]),
					_originalChq_reg_mth_misc_amt_115 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_115"]),
					_originalChq_reg_mth_misc_amt_116 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_116"]),
					_originalChq_reg_mth_misc_amt_117 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_117"]),
					_originalChq_reg_mth_misc_amt_118 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_118"]),
					_originalChq_reg_mth_misc_amt_21 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_21"]),
					_originalChq_reg_mth_misc_amt_22 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_22"]),
					_originalChq_reg_mth_misc_amt_23 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_23"]),
					_originalChq_reg_mth_misc_amt_24 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_24"]),
					_originalChq_reg_mth_misc_amt_25 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_25"]),
					_originalChq_reg_mth_misc_amt_26 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_26"]),
					_originalChq_reg_mth_misc_amt_27 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_27"]),
					_originalChq_reg_mth_misc_amt_28 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_28"]),
					_originalChq_reg_mth_misc_amt_29 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_29"]),
					_originalChq_reg_mth_misc_amt_210 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_210"]),
					_originalChq_reg_mth_misc_amt_211 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_211"]),
					_originalChq_reg_mth_misc_amt_212 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_212"]),
					_originalChq_reg_mth_misc_amt_213 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_213"]),
					_originalChq_reg_mth_misc_amt_214 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_214"]),
					_originalChq_reg_mth_misc_amt_215 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_215"]),
					_originalChq_reg_mth_misc_amt_216 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_216"]),
					_originalChq_reg_mth_misc_amt_217 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_217"]),
					_originalChq_reg_mth_misc_amt_218 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_218"]),
					_originalChq_reg_mth_misc_amt_31 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_31"]),
					_originalChq_reg_mth_misc_amt_32 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_32"]),
					_originalChq_reg_mth_misc_amt_33 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_33"]),
					_originalChq_reg_mth_misc_amt_34 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_34"]),
					_originalChq_reg_mth_misc_amt_35 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_35"]),
					_originalChq_reg_mth_misc_amt_36 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_36"]),
					_originalChq_reg_mth_misc_amt_37 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_37"]),
					_originalChq_reg_mth_misc_amt_38 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_38"]),
					_originalChq_reg_mth_misc_amt_39 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_39"]),
					_originalChq_reg_mth_misc_amt_310 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_310"]),
					_originalChq_reg_mth_misc_amt_311 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_311"]),
					_originalChq_reg_mth_misc_amt_312 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_312"]),
					_originalChq_reg_mth_misc_amt_313 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_313"]),
					_originalChq_reg_mth_misc_amt_314 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_314"]),
					_originalChq_reg_mth_misc_amt_315 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_315"]),
					_originalChq_reg_mth_misc_amt_316 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_316"]),
					_originalChq_reg_mth_misc_amt_317 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_317"]),
					_originalChq_reg_mth_misc_amt_318 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_318"]),
					_originalChq_reg_mth_misc_amt_41 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_41"]),
					_originalChq_reg_mth_misc_amt_42 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_42"]),
					_originalChq_reg_mth_misc_amt_43 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_43"]),
					_originalChq_reg_mth_misc_amt_44 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_44"]),
					_originalChq_reg_mth_misc_amt_45 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_45"]),
					_originalChq_reg_mth_misc_amt_46 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_46"]),
					_originalChq_reg_mth_misc_amt_47 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_47"]),
					_originalChq_reg_mth_misc_amt_48 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_48"]),
					_originalChq_reg_mth_misc_amt_49 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_49"]),
					_originalChq_reg_mth_misc_amt_410 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_410"]),
					_originalChq_reg_mth_misc_amt_411 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_411"]),
					_originalChq_reg_mth_misc_amt_412 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_412"]),
					_originalChq_reg_mth_misc_amt_413 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_413"]),
					_originalChq_reg_mth_misc_amt_414 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_414"]),
					_originalChq_reg_mth_misc_amt_415 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_415"]),
					_originalChq_reg_mth_misc_amt_416 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_416"]),
					_originalChq_reg_mth_misc_amt_417 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_417"]),
					_originalChq_reg_mth_misc_amt_418 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_418"]),
					_originalChq_reg_mth_misc_amt_51 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_51"]),
					_originalChq_reg_mth_misc_amt_52 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_52"]),
					_originalChq_reg_mth_misc_amt_53 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_53"]),
					_originalChq_reg_mth_misc_amt_54 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_54"]),
					_originalChq_reg_mth_misc_amt_55 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_55"]),
					_originalChq_reg_mth_misc_amt_56 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_56"]),
					_originalChq_reg_mth_misc_amt_57 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_57"]),
					_originalChq_reg_mth_misc_amt_58 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_58"]),
					_originalChq_reg_mth_misc_amt_59 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_59"]),
					_originalChq_reg_mth_misc_amt_510 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_510"]),
					_originalChq_reg_mth_misc_amt_511 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_511"]),
					_originalChq_reg_mth_misc_amt_512 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_512"]),
					_originalChq_reg_mth_misc_amt_513 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_513"]),
					_originalChq_reg_mth_misc_amt_514 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_514"]),
					_originalChq_reg_mth_misc_amt_515 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_515"]),
					_originalChq_reg_mth_misc_amt_516 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_516"]),
					_originalChq_reg_mth_misc_amt_517 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_517"]),
					_originalChq_reg_mth_misc_amt_518 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_518"]),
					_originalChq_reg_mth_misc_amt_61 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_61"]),
					_originalChq_reg_mth_misc_amt_62 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_62"]),
					_originalChq_reg_mth_misc_amt_63 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_63"]),
					_originalChq_reg_mth_misc_amt_64 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_64"]),
					_originalChq_reg_mth_misc_amt_65 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_65"]),
					_originalChq_reg_mth_misc_amt_66 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_66"]),
					_originalChq_reg_mth_misc_amt_67 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_67"]),
					_originalChq_reg_mth_misc_amt_68 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_68"]),
					_originalChq_reg_mth_misc_amt_69 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_69"]),
					_originalChq_reg_mth_misc_amt_610 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_610"]),
					_originalChq_reg_mth_misc_amt_611 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_611"]),
					_originalChq_reg_mth_misc_amt_612 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_612"]),
					_originalChq_reg_mth_misc_amt_613 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_613"]),
					_originalChq_reg_mth_misc_amt_614 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_614"]),
					_originalChq_reg_mth_misc_amt_615 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_615"]),
					_originalChq_reg_mth_misc_amt_616 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_616"]),
					_originalChq_reg_mth_misc_amt_617 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_617"]),
					_originalChq_reg_mth_misc_amt_618 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_618"]),
					_originalChq_reg_mth_misc_amt_71 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_71"]),
					_originalChq_reg_mth_misc_amt_72 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_72"]),
					_originalChq_reg_mth_misc_amt_73 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_73"]),
					_originalChq_reg_mth_misc_amt_74 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_74"]),
					_originalChq_reg_mth_misc_amt_75 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_75"]),
					_originalChq_reg_mth_misc_amt_76 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_76"]),
					_originalChq_reg_mth_misc_amt_77 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_77"]),
					_originalChq_reg_mth_misc_amt_78 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_78"]),
					_originalChq_reg_mth_misc_amt_79 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_79"]),
					_originalChq_reg_mth_misc_amt_710 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_710"]),
					_originalChq_reg_mth_misc_amt_711 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_711"]),
					_originalChq_reg_mth_misc_amt_712 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_712"]),
					_originalChq_reg_mth_misc_amt_713 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_713"]),
					_originalChq_reg_mth_misc_amt_714 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_714"]),
					_originalChq_reg_mth_misc_amt_715 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_715"]),
					_originalChq_reg_mth_misc_amt_716 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_716"]),
					_originalChq_reg_mth_misc_amt_717 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_717"]),
					_originalChq_reg_mth_misc_amt_718 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_718"]),
					_originalChq_reg_mth_misc_amt_81 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_81"]),
					_originalChq_reg_mth_misc_amt_82 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_82"]),
					_originalChq_reg_mth_misc_amt_83 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_83"]),
					_originalChq_reg_mth_misc_amt_84 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_84"]),
					_originalChq_reg_mth_misc_amt_85 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_85"]),
					_originalChq_reg_mth_misc_amt_86 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_86"]),
					_originalChq_reg_mth_misc_amt_87 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_87"]),
					_originalChq_reg_mth_misc_amt_88 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_88"]),
					_originalChq_reg_mth_misc_amt_89 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_89"]),
					_originalChq_reg_mth_misc_amt_810 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_810"]),
					_originalChq_reg_mth_misc_amt_811 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_811"]),
					_originalChq_reg_mth_misc_amt_812 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_812"]),
					_originalChq_reg_mth_misc_amt_813 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_813"]),
					_originalChq_reg_mth_misc_amt_814 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_814"]),
					_originalChq_reg_mth_misc_amt_815 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_815"]),
					_originalChq_reg_mth_misc_amt_816 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_816"]),
					_originalChq_reg_mth_misc_amt_817 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_817"]),
					_originalChq_reg_mth_misc_amt_818 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_818"]),
					_originalChq_reg_mth_misc_amt_91 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_91"]),
					_originalChq_reg_mth_misc_amt_92 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_92"]),
					_originalChq_reg_mth_misc_amt_93 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_93"]),
					_originalChq_reg_mth_misc_amt_94 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_94"]),
					_originalChq_reg_mth_misc_amt_95 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_95"]),
					_originalChq_reg_mth_misc_amt_96 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_96"]),
					_originalChq_reg_mth_misc_amt_97 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_97"]),
					_originalChq_reg_mth_misc_amt_98 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_98"]),
					_originalChq_reg_mth_misc_amt_99 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_99"]),
					_originalChq_reg_mth_misc_amt_910 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_910"]),
					_originalChq_reg_mth_misc_amt_911 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_911"]),
					_originalChq_reg_mth_misc_amt_912 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_912"]),
					_originalChq_reg_mth_misc_amt_913 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_913"]),
					_originalChq_reg_mth_misc_amt_914 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_914"]),
					_originalChq_reg_mth_misc_amt_915 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_915"]),
					_originalChq_reg_mth_misc_amt_916 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_916"]),
					_originalChq_reg_mth_misc_amt_917 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_917"]),
					_originalChq_reg_mth_misc_amt_918 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_918"]),
					_originalChq_reg_mth_misc_amt_101 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_101"]),
					_originalChq_reg_mth_misc_amt_102 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_102"]),
					_originalChq_reg_mth_misc_amt_103 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_103"]),
					_originalChq_reg_mth_misc_amt_104 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_104"]),
					_originalChq_reg_mth_misc_amt_105 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_105"]),
					_originalChq_reg_mth_misc_amt_106 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_106"]),
					_originalChq_reg_mth_misc_amt_107 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_107"]),
					_originalChq_reg_mth_misc_amt_108 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_108"]),
					_originalChq_reg_mth_misc_amt_109 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_109"]),
					_originalChq_reg_mth_misc_amt_1010 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1010"]),
					_originalChq_reg_mth_misc_amt_1011 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1011"]),
					_originalChq_reg_mth_misc_amt_1012 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1012"]),
					_originalChq_reg_mth_misc_amt_1013 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1013"]),
					_originalChq_reg_mth_misc_amt_1014 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1014"]),
					_originalChq_reg_mth_misc_amt_1015 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1015"]),
					_originalChq_reg_mth_misc_amt_1016 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1016"]),
					_originalChq_reg_mth_misc_amt_1017 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1017"]),
					_originalChq_reg_mth_misc_amt_1018 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1018"]),
					_originalChq_reg_mth_exp_amt1 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT1"]),
					_originalChq_reg_mth_exp_amt2 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT2"]),
					_originalChq_reg_mth_exp_amt3 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT3"]),
					_originalChq_reg_mth_exp_amt4 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT4"]),
					_originalChq_reg_mth_exp_amt5 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT5"]),
					_originalChq_reg_mth_exp_amt6 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT6"]),
					_originalChq_reg_mth_exp_amt7 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT7"]),
					_originalChq_reg_mth_exp_amt8 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT8"]),
					_originalChq_reg_mth_exp_amt9 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT9"]),
					_originalChq_reg_mth_exp_amt10 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT10"]),
					_originalChq_reg_mth_exp_amt11 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT11"]),
					_originalChq_reg_mth_exp_amt12 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT12"]),
					_originalChq_reg_mth_exp_amt13 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT13"]),
					_originalChq_reg_mth_exp_amt14 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT14"]),
					_originalChq_reg_mth_exp_amt15 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT15"]),
					_originalChq_reg_mth_exp_amt16 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT16"]),
					_originalChq_reg_mth_exp_amt17 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT17"]),
					_originalChq_reg_mth_exp_amt18 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT18"]),
					_originalChq_reg_comp_ann_exp_this_pay1 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY1"]),
					_originalChq_reg_comp_ann_exp_this_pay2 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY2"]),
					_originalChq_reg_comp_ann_exp_this_pay3 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY3"]),
					_originalChq_reg_comp_ann_exp_this_pay4 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY4"]),
					_originalChq_reg_comp_ann_exp_this_pay5 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY5"]),
					_originalChq_reg_comp_ann_exp_this_pay6 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY6"]),
					_originalChq_reg_comp_ann_exp_this_pay7 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY7"]),
					_originalChq_reg_comp_ann_exp_this_pay8 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY8"]),
					_originalChq_reg_comp_ann_exp_this_pay9 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY9"]),
					_originalChq_reg_comp_ann_exp_this_pay10 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY10"]),
					_originalChq_reg_comp_ann_exp_this_pay11 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY11"]),
					_originalChq_reg_comp_ann_exp_this_pay12 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY12"]),
					_originalChq_reg_comp_ann_exp_this_pay13 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY13"]),
					_originalChq_reg_comp_ann_exp_this_pay14 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY14"]),
					_originalChq_reg_comp_ann_exp_this_pay15 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY15"]),
					_originalChq_reg_comp_ann_exp_this_pay16 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY16"]),
					_originalChq_reg_comp_ann_exp_this_pay17 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY17"]),
					_originalChq_reg_comp_ann_exp_this_pay18 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY18"]),
					_originalChq_reg_mth_ceil_amt1 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT1"]),
					_originalChq_reg_mth_ceil_amt2 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT2"]),
					_originalChq_reg_mth_ceil_amt3 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT3"]),
					_originalChq_reg_mth_ceil_amt4 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT4"]),
					_originalChq_reg_mth_ceil_amt5 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT5"]),
					_originalChq_reg_mth_ceil_amt6 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT6"]),
					_originalChq_reg_mth_ceil_amt7 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT7"]),
					_originalChq_reg_mth_ceil_amt8 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT8"]),
					_originalChq_reg_mth_ceil_amt9 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT9"]),
					_originalChq_reg_mth_ceil_amt10 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT10"]),
					_originalChq_reg_mth_ceil_amt11 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT11"]),
					_originalChq_reg_mth_ceil_amt12 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT12"]),
					_originalChq_reg_mth_ceil_amt13 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT13"]),
					_originalChq_reg_mth_ceil_amt14 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT14"]),
					_originalChq_reg_mth_ceil_amt15 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT15"]),
					_originalChq_reg_mth_ceil_amt16 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT16"]),
					_originalChq_reg_mth_ceil_amt17 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT17"]),
					_originalChq_reg_mth_ceil_amt18 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT18"]),
					_originalChq_reg_comp_ann_ceil_this_pay1 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY1"]),
					_originalChq_reg_comp_ann_ceil_this_pay2 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY2"]),
					_originalChq_reg_comp_ann_ceil_this_pay3 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY3"]),
					_originalChq_reg_comp_ann_ceil_this_pay4 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY4"]),
					_originalChq_reg_comp_ann_ceil_this_pay5 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY5"]),
					_originalChq_reg_comp_ann_ceil_this_pay6 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY6"]),
					_originalChq_reg_comp_ann_ceil_this_pay7 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY7"]),
					_originalChq_reg_comp_ann_ceil_this_pay8 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY8"]),
					_originalChq_reg_comp_ann_ceil_this_pay9 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY9"]),
					_originalChq_reg_comp_ann_ceil_this_pay10 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY10"]),
					_originalChq_reg_comp_ann_ceil_this_pay11 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY11"]),
					_originalChq_reg_comp_ann_ceil_this_pay12 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY12"]),
					_originalChq_reg_comp_ann_ceil_this_pay13 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY13"]),
					_originalChq_reg_comp_ann_ceil_this_pay14 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY14"]),
					_originalChq_reg_comp_ann_ceil_this_pay15 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY15"]),
					_originalChq_reg_comp_ann_ceil_this_pay16 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY16"]),
					_originalChq_reg_comp_ann_ceil_this_pay17 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY17"]),
					_originalChq_reg_comp_ann_ceil_this_pay18 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY18"]),
					_originalChq_reg_earnings_this_mth1 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH1"]),
					_originalChq_reg_earnings_this_mth2 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH2"]),
					_originalChq_reg_earnings_this_mth3 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH3"]),
					_originalChq_reg_earnings_this_mth4 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH4"]),
					_originalChq_reg_earnings_this_mth5 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH5"]),
					_originalChq_reg_earnings_this_mth6 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH6"]),
					_originalChq_reg_earnings_this_mth7 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH7"]),
					_originalChq_reg_earnings_this_mth8 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH8"]),
					_originalChq_reg_earnings_this_mth9 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH9"]),
					_originalChq_reg_earnings_this_mth10 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH10"]),
					_originalChq_reg_earnings_this_mth11 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH11"]),
					_originalChq_reg_earnings_this_mth12 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH12"]),
					_originalChq_reg_earnings_this_mth13 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH13"]),
					_originalChq_reg_earnings_this_mth14 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH14"]),
					_originalChq_reg_earnings_this_mth15 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH15"]),
					_originalChq_reg_earnings_this_mth16 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH16"]),
					_originalChq_reg_earnings_this_mth17 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH17"]),
					_originalChq_reg_earnings_this_mth18 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH18"]),
					_originalChq_reg_regular_pay_this_mth1 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH1"]),
					_originalChq_reg_regular_pay_this_mth2 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH2"]),
					_originalChq_reg_regular_pay_this_mth3 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH3"]),
					_originalChq_reg_regular_pay_this_mth4 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH4"]),
					_originalChq_reg_regular_pay_this_mth5 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH5"]),
					_originalChq_reg_regular_pay_this_mth6 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH6"]),
					_originalChq_reg_regular_pay_this_mth7 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH7"]),
					_originalChq_reg_regular_pay_this_mth8 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH8"]),
					_originalChq_reg_regular_pay_this_mth9 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH9"]),
					_originalChq_reg_regular_pay_this_mth10 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH10"]),
					_originalChq_reg_regular_pay_this_mth11 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH11"]),
					_originalChq_reg_regular_pay_this_mth12 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH12"]),
					_originalChq_reg_regular_pay_this_mth13 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH13"]),
					_originalChq_reg_regular_pay_this_mth14 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH14"]),
					_originalChq_reg_regular_pay_this_mth15 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH15"]),
					_originalChq_reg_regular_pay_this_mth16 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH16"]),
					_originalChq_reg_regular_pay_this_mth17 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH17"]),
					_originalChq_reg_regular_pay_this_mth18 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH18"]),
					_originalChq_reg_regular_tax_this_mth1 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH1"]),
					_originalChq_reg_regular_tax_this_mth2 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH2"]),
					_originalChq_reg_regular_tax_this_mth3 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH3"]),
					_originalChq_reg_regular_tax_this_mth4 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH4"]),
					_originalChq_reg_regular_tax_this_mth5 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH5"]),
					_originalChq_reg_regular_tax_this_mth6 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH6"]),
					_originalChq_reg_regular_tax_this_mth7 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH7"]),
					_originalChq_reg_regular_tax_this_mth8 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH8"]),
					_originalChq_reg_regular_tax_this_mth9 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH9"]),
					_originalChq_reg_regular_tax_this_mth10 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH10"]),
					_originalChq_reg_regular_tax_this_mth11 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH11"]),
					_originalChq_reg_regular_tax_this_mth12 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH12"]),
					_originalChq_reg_regular_tax_this_mth13 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH13"]),
					_originalChq_reg_regular_tax_this_mth14 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH14"]),
					_originalChq_reg_regular_tax_this_mth15 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH15"]),
					_originalChq_reg_regular_tax_this_mth16 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH16"]),
					_originalChq_reg_regular_tax_this_mth17 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH17"]),
					_originalChq_reg_regular_tax_this_mth18 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH18"]),
					_originalChq_reg_man_pay_this_mth1 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH1"]),
					_originalChq_reg_man_pay_this_mth2 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH2"]),
					_originalChq_reg_man_pay_this_mth3 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH3"]),
					_originalChq_reg_man_pay_this_mth4 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH4"]),
					_originalChq_reg_man_pay_this_mth5 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH5"]),
					_originalChq_reg_man_pay_this_mth6 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH6"]),
					_originalChq_reg_man_pay_this_mth7 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH7"]),
					_originalChq_reg_man_pay_this_mth8 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH8"]),
					_originalChq_reg_man_pay_this_mth9 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH9"]),
					_originalChq_reg_man_pay_this_mth10 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH10"]),
					_originalChq_reg_man_pay_this_mth11 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH11"]),
					_originalChq_reg_man_pay_this_mth12 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH12"]),
					_originalChq_reg_man_pay_this_mth13 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH13"]),
					_originalChq_reg_man_pay_this_mth14 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH14"]),
					_originalChq_reg_man_pay_this_mth15 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH15"]),
					_originalChq_reg_man_pay_this_mth16 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH16"]),
					_originalChq_reg_man_pay_this_mth17 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH17"]),
					_originalChq_reg_man_pay_this_mth18 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH18"]),
					_originalChq_reg_man_tax_this_mth1 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH1"]),
					_originalChq_reg_man_tax_this_mth2 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH2"]),
					_originalChq_reg_man_tax_this_mth3 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH3"]),
					_originalChq_reg_man_tax_this_mth4 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH4"]),
					_originalChq_reg_man_tax_this_mth5 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH5"]),
					_originalChq_reg_man_tax_this_mth6 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH6"]),
					_originalChq_reg_man_tax_this_mth7 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH7"]),
					_originalChq_reg_man_tax_this_mth8 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH8"]),
					_originalChq_reg_man_tax_this_mth9 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH9"]),
					_originalChq_reg_man_tax_this_mth10 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH10"]),
					_originalChq_reg_man_tax_this_mth11 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH11"]),
					_originalChq_reg_man_tax_this_mth12 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH12"]),
					_originalChq_reg_man_tax_this_mth13 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH13"]),
					_originalChq_reg_man_tax_this_mth14 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH14"]),
					_originalChq_reg_man_tax_this_mth15 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH15"]),
					_originalChq_reg_man_tax_this_mth16 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH16"]),
					_originalChq_reg_man_tax_this_mth17 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH17"]),
					_originalChq_reg_man_tax_this_mth18 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH18"]),
					_originalChq_reg_pay_date1 = ConvertDEC(Reader["CHQ_REG_PAY_DATE1"]),
					_originalChq_reg_pay_date2 = ConvertDEC(Reader["CHQ_REG_PAY_DATE2"]),
					_originalChq_reg_pay_date3 = ConvertDEC(Reader["CHQ_REG_PAY_DATE3"]),
					_originalChq_reg_pay_date4 = ConvertDEC(Reader["CHQ_REG_PAY_DATE4"]),
					_originalChq_reg_pay_date5 = ConvertDEC(Reader["CHQ_REG_PAY_DATE5"]),
					_originalChq_reg_pay_date6 = ConvertDEC(Reader["CHQ_REG_PAY_DATE6"]),
					_originalChq_reg_pay_date7 = ConvertDEC(Reader["CHQ_REG_PAY_DATE7"]),
					_originalChq_reg_pay_date8 = ConvertDEC(Reader["CHQ_REG_PAY_DATE8"]),
					_originalChq_reg_pay_date9 = ConvertDEC(Reader["CHQ_REG_PAY_DATE9"]),
					_originalChq_reg_pay_date10 = ConvertDEC(Reader["CHQ_REG_PAY_DATE10"]),
					_originalChq_reg_pay_date11 = ConvertDEC(Reader["CHQ_REG_PAY_DATE11"]),
					_originalChq_reg_pay_date12 = ConvertDEC(Reader["CHQ_REG_PAY_DATE12"]),
					_originalChq_reg_pay_date13 = ConvertDEC(Reader["CHQ_REG_PAY_DATE13"]),
					_originalChq_reg_pay_date14 = ConvertDEC(Reader["CHQ_REG_PAY_DATE14"]),
					_originalChq_reg_pay_date15 = ConvertDEC(Reader["CHQ_REG_PAY_DATE15"]),
					_originalChq_reg_pay_date16 = ConvertDEC(Reader["CHQ_REG_PAY_DATE16"]),
					_originalChq_reg_pay_date17 = ConvertDEC(Reader["CHQ_REG_PAY_DATE17"]),
					_originalChq_reg_pay_date18 = ConvertDEC(Reader["CHQ_REG_PAY_DATE18"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F060_CHEQUE_REG_MSTR Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F060_CHEQUE_REG_MSTR> Collection(ObservableCollection<F060_CHEQUE_REG_MSTR>
                                                               f060ChequeRegMstr = null)
        {
            if (IsSameSearch() && f060ChequeRegMstr != null)
            {
                return f060ChequeRegMstr;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F060_CHEQUE_REG_MSTR>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("CHQ_REG_CLINIC_NBR_1_2",WhereChq_reg_clinic_nbr_1_2),
					new SqlParameter("CHQ_REG_DEPT",WhereChq_reg_dept),
					new SqlParameter("CHQ_REG_DOC_NBR",WhereChq_reg_doc_nbr),
					new SqlParameter("CHQ_REG_PERC_BILL1",WhereChq_reg_perc_bill1),
					new SqlParameter("CHQ_REG_PERC_BILL2",WhereChq_reg_perc_bill2),
					new SqlParameter("CHQ_REG_PERC_BILL3",WhereChq_reg_perc_bill3),
					new SqlParameter("CHQ_REG_PERC_BILL4",WhereChq_reg_perc_bill4),
					new SqlParameter("CHQ_REG_PERC_BILL5",WhereChq_reg_perc_bill5),
					new SqlParameter("CHQ_REG_PERC_BILL6",WhereChq_reg_perc_bill6),
					new SqlParameter("CHQ_REG_PERC_BILL7",WhereChq_reg_perc_bill7),
					new SqlParameter("CHQ_REG_PERC_BILL8",WhereChq_reg_perc_bill8),
					new SqlParameter("CHQ_REG_PERC_BILL9",WhereChq_reg_perc_bill9),
					new SqlParameter("CHQ_REG_PERC_BILL10",WhereChq_reg_perc_bill10),
					new SqlParameter("CHQ_REG_PERC_BILL11",WhereChq_reg_perc_bill11),
					new SqlParameter("CHQ_REG_PERC_BILL12",WhereChq_reg_perc_bill12),
					new SqlParameter("CHQ_REG_PERC_BILL13",WhereChq_reg_perc_bill13),
					new SqlParameter("CHQ_REG_PERC_BILL14",WhereChq_reg_perc_bill14),
					new SqlParameter("CHQ_REG_PERC_BILL15",WhereChq_reg_perc_bill15),
					new SqlParameter("CHQ_REG_PERC_BILL16",WhereChq_reg_perc_bill16),
					new SqlParameter("CHQ_REG_PERC_BILL17",WhereChq_reg_perc_bill17),
					new SqlParameter("CHQ_REG_PERC_BILL18",WhereChq_reg_perc_bill18),
					new SqlParameter("CHQ_REG_PERC_MISC1",WhereChq_reg_perc_misc1),
					new SqlParameter("CHQ_REG_PERC_MISC2",WhereChq_reg_perc_misc2),
					new SqlParameter("CHQ_REG_PERC_MISC3",WhereChq_reg_perc_misc3),
					new SqlParameter("CHQ_REG_PERC_MISC4",WhereChq_reg_perc_misc4),
					new SqlParameter("CHQ_REG_PERC_MISC5",WhereChq_reg_perc_misc5),
					new SqlParameter("CHQ_REG_PERC_MISC6",WhereChq_reg_perc_misc6),
					new SqlParameter("CHQ_REG_PERC_MISC7",WhereChq_reg_perc_misc7),
					new SqlParameter("CHQ_REG_PERC_MISC8",WhereChq_reg_perc_misc8),
					new SqlParameter("CHQ_REG_PERC_MISC9",WhereChq_reg_perc_misc9),
					new SqlParameter("CHQ_REG_PERC_MISC10",WhereChq_reg_perc_misc10),
					new SqlParameter("CHQ_REG_PERC_MISC11",WhereChq_reg_perc_misc11),
					new SqlParameter("CHQ_REG_PERC_MISC12",WhereChq_reg_perc_misc12),
					new SqlParameter("CHQ_REG_PERC_MISC13",WhereChq_reg_perc_misc13),
					new SqlParameter("CHQ_REG_PERC_MISC14",WhereChq_reg_perc_misc14),
					new SqlParameter("CHQ_REG_PERC_MISC15",WhereChq_reg_perc_misc15),
					new SqlParameter("CHQ_REG_PERC_MISC16",WhereChq_reg_perc_misc16),
					new SqlParameter("CHQ_REG_PERC_MISC17",WhereChq_reg_perc_misc17),
					new SqlParameter("CHQ_REG_PERC_MISC18",WhereChq_reg_perc_misc18),
					new SqlParameter("CHQ_REG_PAY_CODE1",WhereChq_reg_pay_code1),
					new SqlParameter("CHQ_REG_PAY_CODE2",WhereChq_reg_pay_code2),
					new SqlParameter("CHQ_REG_PAY_CODE3",WhereChq_reg_pay_code3),
					new SqlParameter("CHQ_REG_PAY_CODE4",WhereChq_reg_pay_code4),
					new SqlParameter("CHQ_REG_PAY_CODE5",WhereChq_reg_pay_code5),
					new SqlParameter("CHQ_REG_PAY_CODE6",WhereChq_reg_pay_code6),
					new SqlParameter("CHQ_REG_PAY_CODE7",WhereChq_reg_pay_code7),
					new SqlParameter("CHQ_REG_PAY_CODE8",WhereChq_reg_pay_code8),
					new SqlParameter("CHQ_REG_PAY_CODE9",WhereChq_reg_pay_code9),
					new SqlParameter("CHQ_REG_PAY_CODE10",WhereChq_reg_pay_code10),
					new SqlParameter("CHQ_REG_PAY_CODE11",WhereChq_reg_pay_code11),
					new SqlParameter("CHQ_REG_PAY_CODE12",WhereChq_reg_pay_code12),
					new SqlParameter("CHQ_REG_PAY_CODE13",WhereChq_reg_pay_code13),
					new SqlParameter("CHQ_REG_PAY_CODE14",WhereChq_reg_pay_code14),
					new SqlParameter("CHQ_REG_PAY_CODE15",WhereChq_reg_pay_code15),
					new SqlParameter("CHQ_REG_PAY_CODE16",WhereChq_reg_pay_code16),
					new SqlParameter("CHQ_REG_PAY_CODE17",WhereChq_reg_pay_code17),
					new SqlParameter("CHQ_REG_PAY_CODE18",WhereChq_reg_pay_code18),
					new SqlParameter("CHQ_REG_PERC_TAX1",WhereChq_reg_perc_tax1),
					new SqlParameter("CHQ_REG_PERC_TAX2",WhereChq_reg_perc_tax2),
					new SqlParameter("CHQ_REG_PERC_TAX3",WhereChq_reg_perc_tax3),
					new SqlParameter("CHQ_REG_PERC_TAX4",WhereChq_reg_perc_tax4),
					new SqlParameter("CHQ_REG_PERC_TAX5",WhereChq_reg_perc_tax5),
					new SqlParameter("CHQ_REG_PERC_TAX6",WhereChq_reg_perc_tax6),
					new SqlParameter("CHQ_REG_PERC_TAX7",WhereChq_reg_perc_tax7),
					new SqlParameter("CHQ_REG_PERC_TAX8",WhereChq_reg_perc_tax8),
					new SqlParameter("CHQ_REG_PERC_TAX9",WhereChq_reg_perc_tax9),
					new SqlParameter("CHQ_REG_PERC_TAX10",WhereChq_reg_perc_tax10),
					new SqlParameter("CHQ_REG_PERC_TAX11",WhereChq_reg_perc_tax11),
					new SqlParameter("CHQ_REG_PERC_TAX12",WhereChq_reg_perc_tax12),
					new SqlParameter("CHQ_REG_PERC_TAX13",WhereChq_reg_perc_tax13),
					new SqlParameter("CHQ_REG_PERC_TAX14",WhereChq_reg_perc_tax14),
					new SqlParameter("CHQ_REG_PERC_TAX15",WhereChq_reg_perc_tax15),
					new SqlParameter("CHQ_REG_PERC_TAX16",WhereChq_reg_perc_tax16),
					new SqlParameter("CHQ_REG_PERC_TAX17",WhereChq_reg_perc_tax17),
					new SqlParameter("CHQ_REG_PERC_TAX18",WhereChq_reg_perc_tax18),
					new SqlParameter("CHQ_REG_MTH_BILL_AMT1",WhereChq_reg_mth_bill_amt1),
					new SqlParameter("CHQ_REG_MTH_BILL_AMT2",WhereChq_reg_mth_bill_amt2),
					new SqlParameter("CHQ_REG_MTH_BILL_AMT3",WhereChq_reg_mth_bill_amt3),
					new SqlParameter("CHQ_REG_MTH_BILL_AMT4",WhereChq_reg_mth_bill_amt4),
					new SqlParameter("CHQ_REG_MTH_BILL_AMT5",WhereChq_reg_mth_bill_amt5),
					new SqlParameter("CHQ_REG_MTH_BILL_AMT6",WhereChq_reg_mth_bill_amt6),
					new SqlParameter("CHQ_REG_MTH_BILL_AMT7",WhereChq_reg_mth_bill_amt7),
					new SqlParameter("CHQ_REG_MTH_BILL_AMT8",WhereChq_reg_mth_bill_amt8),
					new SqlParameter("CHQ_REG_MTH_BILL_AMT9",WhereChq_reg_mth_bill_amt9),
					new SqlParameter("CHQ_REG_MTH_BILL_AMT10",WhereChq_reg_mth_bill_amt10),
					new SqlParameter("CHQ_REG_MTH_BILL_AMT11",WhereChq_reg_mth_bill_amt11),
					new SqlParameter("CHQ_REG_MTH_BILL_AMT12",WhereChq_reg_mth_bill_amt12),
					new SqlParameter("CHQ_REG_MTH_BILL_AMT13",WhereChq_reg_mth_bill_amt13),
					new SqlParameter("CHQ_REG_MTH_BILL_AMT14",WhereChq_reg_mth_bill_amt14),
					new SqlParameter("CHQ_REG_MTH_BILL_AMT15",WhereChq_reg_mth_bill_amt15),
					new SqlParameter("CHQ_REG_MTH_BILL_AMT16",WhereChq_reg_mth_bill_amt16),
					new SqlParameter("CHQ_REG_MTH_BILL_AMT17",WhereChq_reg_mth_bill_amt17),
					new SqlParameter("CHQ_REG_MTH_BILL_AMT18",WhereChq_reg_mth_bill_amt18),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_11",WhereChq_reg_mth_misc_amt_11),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_12",WhereChq_reg_mth_misc_amt_12),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_13",WhereChq_reg_mth_misc_amt_13),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_14",WhereChq_reg_mth_misc_amt_14),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_15",WhereChq_reg_mth_misc_amt_15),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_16",WhereChq_reg_mth_misc_amt_16),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_17",WhereChq_reg_mth_misc_amt_17),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_18",WhereChq_reg_mth_misc_amt_18),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_19",WhereChq_reg_mth_misc_amt_19),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_110",WhereChq_reg_mth_misc_amt_110),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_111",WhereChq_reg_mth_misc_amt_111),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_112",WhereChq_reg_mth_misc_amt_112),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_113",WhereChq_reg_mth_misc_amt_113),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_114",WhereChq_reg_mth_misc_amt_114),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_115",WhereChq_reg_mth_misc_amt_115),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_116",WhereChq_reg_mth_misc_amt_116),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_117",WhereChq_reg_mth_misc_amt_117),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_118",WhereChq_reg_mth_misc_amt_118),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_21",WhereChq_reg_mth_misc_amt_21),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_22",WhereChq_reg_mth_misc_amt_22),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_23",WhereChq_reg_mth_misc_amt_23),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_24",WhereChq_reg_mth_misc_amt_24),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_25",WhereChq_reg_mth_misc_amt_25),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_26",WhereChq_reg_mth_misc_amt_26),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_27",WhereChq_reg_mth_misc_amt_27),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_28",WhereChq_reg_mth_misc_amt_28),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_29",WhereChq_reg_mth_misc_amt_29),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_210",WhereChq_reg_mth_misc_amt_210),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_211",WhereChq_reg_mth_misc_amt_211),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_212",WhereChq_reg_mth_misc_amt_212),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_213",WhereChq_reg_mth_misc_amt_213),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_214",WhereChq_reg_mth_misc_amt_214),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_215",WhereChq_reg_mth_misc_amt_215),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_216",WhereChq_reg_mth_misc_amt_216),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_217",WhereChq_reg_mth_misc_amt_217),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_218",WhereChq_reg_mth_misc_amt_218),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_31",WhereChq_reg_mth_misc_amt_31),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_32",WhereChq_reg_mth_misc_amt_32),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_33",WhereChq_reg_mth_misc_amt_33),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_34",WhereChq_reg_mth_misc_amt_34),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_35",WhereChq_reg_mth_misc_amt_35),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_36",WhereChq_reg_mth_misc_amt_36),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_37",WhereChq_reg_mth_misc_amt_37),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_38",WhereChq_reg_mth_misc_amt_38),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_39",WhereChq_reg_mth_misc_amt_39),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_310",WhereChq_reg_mth_misc_amt_310),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_311",WhereChq_reg_mth_misc_amt_311),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_312",WhereChq_reg_mth_misc_amt_312),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_313",WhereChq_reg_mth_misc_amt_313),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_314",WhereChq_reg_mth_misc_amt_314),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_315",WhereChq_reg_mth_misc_amt_315),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_316",WhereChq_reg_mth_misc_amt_316),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_317",WhereChq_reg_mth_misc_amt_317),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_318",WhereChq_reg_mth_misc_amt_318),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_41",WhereChq_reg_mth_misc_amt_41),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_42",WhereChq_reg_mth_misc_amt_42),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_43",WhereChq_reg_mth_misc_amt_43),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_44",WhereChq_reg_mth_misc_amt_44),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_45",WhereChq_reg_mth_misc_amt_45),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_46",WhereChq_reg_mth_misc_amt_46),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_47",WhereChq_reg_mth_misc_amt_47),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_48",WhereChq_reg_mth_misc_amt_48),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_49",WhereChq_reg_mth_misc_amt_49),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_410",WhereChq_reg_mth_misc_amt_410),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_411",WhereChq_reg_mth_misc_amt_411),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_412",WhereChq_reg_mth_misc_amt_412),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_413",WhereChq_reg_mth_misc_amt_413),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_414",WhereChq_reg_mth_misc_amt_414),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_415",WhereChq_reg_mth_misc_amt_415),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_416",WhereChq_reg_mth_misc_amt_416),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_417",WhereChq_reg_mth_misc_amt_417),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_418",WhereChq_reg_mth_misc_amt_418),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_51",WhereChq_reg_mth_misc_amt_51),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_52",WhereChq_reg_mth_misc_amt_52),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_53",WhereChq_reg_mth_misc_amt_53),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_54",WhereChq_reg_mth_misc_amt_54),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_55",WhereChq_reg_mth_misc_amt_55),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_56",WhereChq_reg_mth_misc_amt_56),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_57",WhereChq_reg_mth_misc_amt_57),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_58",WhereChq_reg_mth_misc_amt_58),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_59",WhereChq_reg_mth_misc_amt_59),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_510",WhereChq_reg_mth_misc_amt_510),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_511",WhereChq_reg_mth_misc_amt_511),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_512",WhereChq_reg_mth_misc_amt_512),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_513",WhereChq_reg_mth_misc_amt_513),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_514",WhereChq_reg_mth_misc_amt_514),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_515",WhereChq_reg_mth_misc_amt_515),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_516",WhereChq_reg_mth_misc_amt_516),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_517",WhereChq_reg_mth_misc_amt_517),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_518",WhereChq_reg_mth_misc_amt_518),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_61",WhereChq_reg_mth_misc_amt_61),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_62",WhereChq_reg_mth_misc_amt_62),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_63",WhereChq_reg_mth_misc_amt_63),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_64",WhereChq_reg_mth_misc_amt_64),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_65",WhereChq_reg_mth_misc_amt_65),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_66",WhereChq_reg_mth_misc_amt_66),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_67",WhereChq_reg_mth_misc_amt_67),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_68",WhereChq_reg_mth_misc_amt_68),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_69",WhereChq_reg_mth_misc_amt_69),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_610",WhereChq_reg_mth_misc_amt_610),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_611",WhereChq_reg_mth_misc_amt_611),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_612",WhereChq_reg_mth_misc_amt_612),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_613",WhereChq_reg_mth_misc_amt_613),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_614",WhereChq_reg_mth_misc_amt_614),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_615",WhereChq_reg_mth_misc_amt_615),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_616",WhereChq_reg_mth_misc_amt_616),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_617",WhereChq_reg_mth_misc_amt_617),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_618",WhereChq_reg_mth_misc_amt_618),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_71",WhereChq_reg_mth_misc_amt_71),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_72",WhereChq_reg_mth_misc_amt_72),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_73",WhereChq_reg_mth_misc_amt_73),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_74",WhereChq_reg_mth_misc_amt_74),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_75",WhereChq_reg_mth_misc_amt_75),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_76",WhereChq_reg_mth_misc_amt_76),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_77",WhereChq_reg_mth_misc_amt_77),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_78",WhereChq_reg_mth_misc_amt_78),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_79",WhereChq_reg_mth_misc_amt_79),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_710",WhereChq_reg_mth_misc_amt_710),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_711",WhereChq_reg_mth_misc_amt_711),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_712",WhereChq_reg_mth_misc_amt_712),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_713",WhereChq_reg_mth_misc_amt_713),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_714",WhereChq_reg_mth_misc_amt_714),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_715",WhereChq_reg_mth_misc_amt_715),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_716",WhereChq_reg_mth_misc_amt_716),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_717",WhereChq_reg_mth_misc_amt_717),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_718",WhereChq_reg_mth_misc_amt_718),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_81",WhereChq_reg_mth_misc_amt_81),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_82",WhereChq_reg_mth_misc_amt_82),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_83",WhereChq_reg_mth_misc_amt_83),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_84",WhereChq_reg_mth_misc_amt_84),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_85",WhereChq_reg_mth_misc_amt_85),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_86",WhereChq_reg_mth_misc_amt_86),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_87",WhereChq_reg_mth_misc_amt_87),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_88",WhereChq_reg_mth_misc_amt_88),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_89",WhereChq_reg_mth_misc_amt_89),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_810",WhereChq_reg_mth_misc_amt_810),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_811",WhereChq_reg_mth_misc_amt_811),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_812",WhereChq_reg_mth_misc_amt_812),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_813",WhereChq_reg_mth_misc_amt_813),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_814",WhereChq_reg_mth_misc_amt_814),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_815",WhereChq_reg_mth_misc_amt_815),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_816",WhereChq_reg_mth_misc_amt_816),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_817",WhereChq_reg_mth_misc_amt_817),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_818",WhereChq_reg_mth_misc_amt_818),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_91",WhereChq_reg_mth_misc_amt_91),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_92",WhereChq_reg_mth_misc_amt_92),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_93",WhereChq_reg_mth_misc_amt_93),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_94",WhereChq_reg_mth_misc_amt_94),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_95",WhereChq_reg_mth_misc_amt_95),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_96",WhereChq_reg_mth_misc_amt_96),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_97",WhereChq_reg_mth_misc_amt_97),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_98",WhereChq_reg_mth_misc_amt_98),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_99",WhereChq_reg_mth_misc_amt_99),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_910",WhereChq_reg_mth_misc_amt_910),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_911",WhereChq_reg_mth_misc_amt_911),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_912",WhereChq_reg_mth_misc_amt_912),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_913",WhereChq_reg_mth_misc_amt_913),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_914",WhereChq_reg_mth_misc_amt_914),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_915",WhereChq_reg_mth_misc_amt_915),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_916",WhereChq_reg_mth_misc_amt_916),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_917",WhereChq_reg_mth_misc_amt_917),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_918",WhereChq_reg_mth_misc_amt_918),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_101",WhereChq_reg_mth_misc_amt_101),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_102",WhereChq_reg_mth_misc_amt_102),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_103",WhereChq_reg_mth_misc_amt_103),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_104",WhereChq_reg_mth_misc_amt_104),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_105",WhereChq_reg_mth_misc_amt_105),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_106",WhereChq_reg_mth_misc_amt_106),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_107",WhereChq_reg_mth_misc_amt_107),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_108",WhereChq_reg_mth_misc_amt_108),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_109",WhereChq_reg_mth_misc_amt_109),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_1010",WhereChq_reg_mth_misc_amt_1010),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_1011",WhereChq_reg_mth_misc_amt_1011),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_1012",WhereChq_reg_mth_misc_amt_1012),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_1013",WhereChq_reg_mth_misc_amt_1013),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_1014",WhereChq_reg_mth_misc_amt_1014),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_1015",WhereChq_reg_mth_misc_amt_1015),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_1016",WhereChq_reg_mth_misc_amt_1016),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_1017",WhereChq_reg_mth_misc_amt_1017),
					new SqlParameter("CHQ_REG_MTH_MISC_AMT_1018",WhereChq_reg_mth_misc_amt_1018),
					new SqlParameter("CHQ_REG_MTH_EXP_AMT1",WhereChq_reg_mth_exp_amt1),
					new SqlParameter("CHQ_REG_MTH_EXP_AMT2",WhereChq_reg_mth_exp_amt2),
					new SqlParameter("CHQ_REG_MTH_EXP_AMT3",WhereChq_reg_mth_exp_amt3),
					new SqlParameter("CHQ_REG_MTH_EXP_AMT4",WhereChq_reg_mth_exp_amt4),
					new SqlParameter("CHQ_REG_MTH_EXP_AMT5",WhereChq_reg_mth_exp_amt5),
					new SqlParameter("CHQ_REG_MTH_EXP_AMT6",WhereChq_reg_mth_exp_amt6),
					new SqlParameter("CHQ_REG_MTH_EXP_AMT7",WhereChq_reg_mth_exp_amt7),
					new SqlParameter("CHQ_REG_MTH_EXP_AMT8",WhereChq_reg_mth_exp_amt8),
					new SqlParameter("CHQ_REG_MTH_EXP_AMT9",WhereChq_reg_mth_exp_amt9),
					new SqlParameter("CHQ_REG_MTH_EXP_AMT10",WhereChq_reg_mth_exp_amt10),
					new SqlParameter("CHQ_REG_MTH_EXP_AMT11",WhereChq_reg_mth_exp_amt11),
					new SqlParameter("CHQ_REG_MTH_EXP_AMT12",WhereChq_reg_mth_exp_amt12),
					new SqlParameter("CHQ_REG_MTH_EXP_AMT13",WhereChq_reg_mth_exp_amt13),
					new SqlParameter("CHQ_REG_MTH_EXP_AMT14",WhereChq_reg_mth_exp_amt14),
					new SqlParameter("CHQ_REG_MTH_EXP_AMT15",WhereChq_reg_mth_exp_amt15),
					new SqlParameter("CHQ_REG_MTH_EXP_AMT16",WhereChq_reg_mth_exp_amt16),
					new SqlParameter("CHQ_REG_MTH_EXP_AMT17",WhereChq_reg_mth_exp_amt17),
					new SqlParameter("CHQ_REG_MTH_EXP_AMT18",WhereChq_reg_mth_exp_amt18),
					new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY1",WhereChq_reg_comp_ann_exp_this_pay1),
					new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY2",WhereChq_reg_comp_ann_exp_this_pay2),
					new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY3",WhereChq_reg_comp_ann_exp_this_pay3),
					new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY4",WhereChq_reg_comp_ann_exp_this_pay4),
					new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY5",WhereChq_reg_comp_ann_exp_this_pay5),
					new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY6",WhereChq_reg_comp_ann_exp_this_pay6),
					new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY7",WhereChq_reg_comp_ann_exp_this_pay7),
					new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY8",WhereChq_reg_comp_ann_exp_this_pay8),
					new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY9",WhereChq_reg_comp_ann_exp_this_pay9),
					new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY10",WhereChq_reg_comp_ann_exp_this_pay10),
					new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY11",WhereChq_reg_comp_ann_exp_this_pay11),
					new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY12",WhereChq_reg_comp_ann_exp_this_pay12),
					new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY13",WhereChq_reg_comp_ann_exp_this_pay13),
					new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY14",WhereChq_reg_comp_ann_exp_this_pay14),
					new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY15",WhereChq_reg_comp_ann_exp_this_pay15),
					new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY16",WhereChq_reg_comp_ann_exp_this_pay16),
					new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY17",WhereChq_reg_comp_ann_exp_this_pay17),
					new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY18",WhereChq_reg_comp_ann_exp_this_pay18),
					new SqlParameter("CHQ_REG_MTH_CEIL_AMT1",WhereChq_reg_mth_ceil_amt1),
					new SqlParameter("CHQ_REG_MTH_CEIL_AMT2",WhereChq_reg_mth_ceil_amt2),
					new SqlParameter("CHQ_REG_MTH_CEIL_AMT3",WhereChq_reg_mth_ceil_amt3),
					new SqlParameter("CHQ_REG_MTH_CEIL_AMT4",WhereChq_reg_mth_ceil_amt4),
					new SqlParameter("CHQ_REG_MTH_CEIL_AMT5",WhereChq_reg_mth_ceil_amt5),
					new SqlParameter("CHQ_REG_MTH_CEIL_AMT6",WhereChq_reg_mth_ceil_amt6),
					new SqlParameter("CHQ_REG_MTH_CEIL_AMT7",WhereChq_reg_mth_ceil_amt7),
					new SqlParameter("CHQ_REG_MTH_CEIL_AMT8",WhereChq_reg_mth_ceil_amt8),
					new SqlParameter("CHQ_REG_MTH_CEIL_AMT9",WhereChq_reg_mth_ceil_amt9),
					new SqlParameter("CHQ_REG_MTH_CEIL_AMT10",WhereChq_reg_mth_ceil_amt10),
					new SqlParameter("CHQ_REG_MTH_CEIL_AMT11",WhereChq_reg_mth_ceil_amt11),
					new SqlParameter("CHQ_REG_MTH_CEIL_AMT12",WhereChq_reg_mth_ceil_amt12),
					new SqlParameter("CHQ_REG_MTH_CEIL_AMT13",WhereChq_reg_mth_ceil_amt13),
					new SqlParameter("CHQ_REG_MTH_CEIL_AMT14",WhereChq_reg_mth_ceil_amt14),
					new SqlParameter("CHQ_REG_MTH_CEIL_AMT15",WhereChq_reg_mth_ceil_amt15),
					new SqlParameter("CHQ_REG_MTH_CEIL_AMT16",WhereChq_reg_mth_ceil_amt16),
					new SqlParameter("CHQ_REG_MTH_CEIL_AMT17",WhereChq_reg_mth_ceil_amt17),
					new SqlParameter("CHQ_REG_MTH_CEIL_AMT18",WhereChq_reg_mth_ceil_amt18),
					new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY1",WhereChq_reg_comp_ann_ceil_this_pay1),
					new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY2",WhereChq_reg_comp_ann_ceil_this_pay2),
					new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY3",WhereChq_reg_comp_ann_ceil_this_pay3),
					new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY4",WhereChq_reg_comp_ann_ceil_this_pay4),
					new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY5",WhereChq_reg_comp_ann_ceil_this_pay5),
					new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY6",WhereChq_reg_comp_ann_ceil_this_pay6),
					new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY7",WhereChq_reg_comp_ann_ceil_this_pay7),
					new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY8",WhereChq_reg_comp_ann_ceil_this_pay8),
					new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY9",WhereChq_reg_comp_ann_ceil_this_pay9),
					new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY10",WhereChq_reg_comp_ann_ceil_this_pay10),
					new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY11",WhereChq_reg_comp_ann_ceil_this_pay11),
					new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY12",WhereChq_reg_comp_ann_ceil_this_pay12),
					new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY13",WhereChq_reg_comp_ann_ceil_this_pay13),
					new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY14",WhereChq_reg_comp_ann_ceil_this_pay14),
					new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY15",WhereChq_reg_comp_ann_ceil_this_pay15),
					new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY16",WhereChq_reg_comp_ann_ceil_this_pay16),
					new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY17",WhereChq_reg_comp_ann_ceil_this_pay17),
					new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY18",WhereChq_reg_comp_ann_ceil_this_pay18),
					new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH1",WhereChq_reg_earnings_this_mth1),
					new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH2",WhereChq_reg_earnings_this_mth2),
					new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH3",WhereChq_reg_earnings_this_mth3),
					new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH4",WhereChq_reg_earnings_this_mth4),
					new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH5",WhereChq_reg_earnings_this_mth5),
					new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH6",WhereChq_reg_earnings_this_mth6),
					new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH7",WhereChq_reg_earnings_this_mth7),
					new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH8",WhereChq_reg_earnings_this_mth8),
					new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH9",WhereChq_reg_earnings_this_mth9),
					new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH10",WhereChq_reg_earnings_this_mth10),
					new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH11",WhereChq_reg_earnings_this_mth11),
					new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH12",WhereChq_reg_earnings_this_mth12),
					new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH13",WhereChq_reg_earnings_this_mth13),
					new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH14",WhereChq_reg_earnings_this_mth14),
					new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH15",WhereChq_reg_earnings_this_mth15),
					new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH16",WhereChq_reg_earnings_this_mth16),
					new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH17",WhereChq_reg_earnings_this_mth17),
					new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH18",WhereChq_reg_earnings_this_mth18),
					new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH1",WhereChq_reg_regular_pay_this_mth1),
					new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH2",WhereChq_reg_regular_pay_this_mth2),
					new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH3",WhereChq_reg_regular_pay_this_mth3),
					new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH4",WhereChq_reg_regular_pay_this_mth4),
					new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH5",WhereChq_reg_regular_pay_this_mth5),
					new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH6",WhereChq_reg_regular_pay_this_mth6),
					new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH7",WhereChq_reg_regular_pay_this_mth7),
					new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH8",WhereChq_reg_regular_pay_this_mth8),
					new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH9",WhereChq_reg_regular_pay_this_mth9),
					new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH10",WhereChq_reg_regular_pay_this_mth10),
					new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH11",WhereChq_reg_regular_pay_this_mth11),
					new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH12",WhereChq_reg_regular_pay_this_mth12),
					new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH13",WhereChq_reg_regular_pay_this_mth13),
					new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH14",WhereChq_reg_regular_pay_this_mth14),
					new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH15",WhereChq_reg_regular_pay_this_mth15),
					new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH16",WhereChq_reg_regular_pay_this_mth16),
					new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH17",WhereChq_reg_regular_pay_this_mth17),
					new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH18",WhereChq_reg_regular_pay_this_mth18),
					new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH1",WhereChq_reg_regular_tax_this_mth1),
					new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH2",WhereChq_reg_regular_tax_this_mth2),
					new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH3",WhereChq_reg_regular_tax_this_mth3),
					new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH4",WhereChq_reg_regular_tax_this_mth4),
					new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH5",WhereChq_reg_regular_tax_this_mth5),
					new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH6",WhereChq_reg_regular_tax_this_mth6),
					new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH7",WhereChq_reg_regular_tax_this_mth7),
					new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH8",WhereChq_reg_regular_tax_this_mth8),
					new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH9",WhereChq_reg_regular_tax_this_mth9),
					new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH10",WhereChq_reg_regular_tax_this_mth10),
					new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH11",WhereChq_reg_regular_tax_this_mth11),
					new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH12",WhereChq_reg_regular_tax_this_mth12),
					new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH13",WhereChq_reg_regular_tax_this_mth13),
					new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH14",WhereChq_reg_regular_tax_this_mth14),
					new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH15",WhereChq_reg_regular_tax_this_mth15),
					new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH16",WhereChq_reg_regular_tax_this_mth16),
					new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH17",WhereChq_reg_regular_tax_this_mth17),
					new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH18",WhereChq_reg_regular_tax_this_mth18),
					new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH1",WhereChq_reg_man_pay_this_mth1),
					new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH2",WhereChq_reg_man_pay_this_mth2),
					new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH3",WhereChq_reg_man_pay_this_mth3),
					new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH4",WhereChq_reg_man_pay_this_mth4),
					new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH5",WhereChq_reg_man_pay_this_mth5),
					new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH6",WhereChq_reg_man_pay_this_mth6),
					new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH7",WhereChq_reg_man_pay_this_mth7),
					new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH8",WhereChq_reg_man_pay_this_mth8),
					new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH9",WhereChq_reg_man_pay_this_mth9),
					new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH10",WhereChq_reg_man_pay_this_mth10),
					new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH11",WhereChq_reg_man_pay_this_mth11),
					new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH12",WhereChq_reg_man_pay_this_mth12),
					new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH13",WhereChq_reg_man_pay_this_mth13),
					new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH14",WhereChq_reg_man_pay_this_mth14),
					new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH15",WhereChq_reg_man_pay_this_mth15),
					new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH16",WhereChq_reg_man_pay_this_mth16),
					new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH17",WhereChq_reg_man_pay_this_mth17),
					new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH18",WhereChq_reg_man_pay_this_mth18),
					new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH1",WhereChq_reg_man_tax_this_mth1),
					new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH2",WhereChq_reg_man_tax_this_mth2),
					new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH3",WhereChq_reg_man_tax_this_mth3),
					new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH4",WhereChq_reg_man_tax_this_mth4),
					new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH5",WhereChq_reg_man_tax_this_mth5),
					new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH6",WhereChq_reg_man_tax_this_mth6),
					new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH7",WhereChq_reg_man_tax_this_mth7),
					new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH8",WhereChq_reg_man_tax_this_mth8),
					new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH9",WhereChq_reg_man_tax_this_mth9),
					new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH10",WhereChq_reg_man_tax_this_mth10),
					new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH11",WhereChq_reg_man_tax_this_mth11),
					new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH12",WhereChq_reg_man_tax_this_mth12),
					new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH13",WhereChq_reg_man_tax_this_mth13),
					new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH14",WhereChq_reg_man_tax_this_mth14),
					new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH15",WhereChq_reg_man_tax_this_mth15),
					new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH16",WhereChq_reg_man_tax_this_mth16),
					new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH17",WhereChq_reg_man_tax_this_mth17),
					new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH18",WhereChq_reg_man_tax_this_mth18),
					new SqlParameter("CHQ_REG_PAY_DATE1",WhereChq_reg_pay_date1),
					new SqlParameter("CHQ_REG_PAY_DATE2",WhereChq_reg_pay_date2),
					new SqlParameter("CHQ_REG_PAY_DATE3",WhereChq_reg_pay_date3),
					new SqlParameter("CHQ_REG_PAY_DATE4",WhereChq_reg_pay_date4),
					new SqlParameter("CHQ_REG_PAY_DATE5",WhereChq_reg_pay_date5),
					new SqlParameter("CHQ_REG_PAY_DATE6",WhereChq_reg_pay_date6),
					new SqlParameter("CHQ_REG_PAY_DATE7",WhereChq_reg_pay_date7),
					new SqlParameter("CHQ_REG_PAY_DATE8",WhereChq_reg_pay_date8),
					new SqlParameter("CHQ_REG_PAY_DATE9",WhereChq_reg_pay_date9),
					new SqlParameter("CHQ_REG_PAY_DATE10",WhereChq_reg_pay_date10),
					new SqlParameter("CHQ_REG_PAY_DATE11",WhereChq_reg_pay_date11),
					new SqlParameter("CHQ_REG_PAY_DATE12",WhereChq_reg_pay_date12),
					new SqlParameter("CHQ_REG_PAY_DATE13",WhereChq_reg_pay_date13),
					new SqlParameter("CHQ_REG_PAY_DATE14",WhereChq_reg_pay_date14),
					new SqlParameter("CHQ_REG_PAY_DATE15",WhereChq_reg_pay_date15),
					new SqlParameter("CHQ_REG_PAY_DATE16",WhereChq_reg_pay_date16),
					new SqlParameter("CHQ_REG_PAY_DATE17",WhereChq_reg_pay_date17),
					new SqlParameter("CHQ_REG_PAY_DATE18",WhereChq_reg_pay_date18),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F060_CHEQUE_REG_MSTR_Match]", parameters);
            var collection = new ObservableCollection<F060_CHEQUE_REG_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F060_CHEQUE_REG_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CHQ_REG_CLINIC_NBR_1_2 = ConvertDEC(Reader["CHQ_REG_CLINIC_NBR_1_2"]),
					CHQ_REG_DEPT = ConvertDEC(Reader["CHQ_REG_DEPT"]),
					CHQ_REG_DOC_NBR = Reader["CHQ_REG_DOC_NBR"].ToString(),
					CHQ_REG_PERC_BILL1 = ConvertDEC(Reader["CHQ_REG_PERC_BILL1"]),
					CHQ_REG_PERC_BILL2 = ConvertDEC(Reader["CHQ_REG_PERC_BILL2"]),
					CHQ_REG_PERC_BILL3 = ConvertDEC(Reader["CHQ_REG_PERC_BILL3"]),
					CHQ_REG_PERC_BILL4 = ConvertDEC(Reader["CHQ_REG_PERC_BILL4"]),
					CHQ_REG_PERC_BILL5 = ConvertDEC(Reader["CHQ_REG_PERC_BILL5"]),
					CHQ_REG_PERC_BILL6 = ConvertDEC(Reader["CHQ_REG_PERC_BILL6"]),
					CHQ_REG_PERC_BILL7 = ConvertDEC(Reader["CHQ_REG_PERC_BILL7"]),
					CHQ_REG_PERC_BILL8 = ConvertDEC(Reader["CHQ_REG_PERC_BILL8"]),
					CHQ_REG_PERC_BILL9 = ConvertDEC(Reader["CHQ_REG_PERC_BILL9"]),
					CHQ_REG_PERC_BILL10 = ConvertDEC(Reader["CHQ_REG_PERC_BILL10"]),
					CHQ_REG_PERC_BILL11 = ConvertDEC(Reader["CHQ_REG_PERC_BILL11"]),
					CHQ_REG_PERC_BILL12 = ConvertDEC(Reader["CHQ_REG_PERC_BILL12"]),
					CHQ_REG_PERC_BILL13 = ConvertDEC(Reader["CHQ_REG_PERC_BILL13"]),
					CHQ_REG_PERC_BILL14 = ConvertDEC(Reader["CHQ_REG_PERC_BILL14"]),
					CHQ_REG_PERC_BILL15 = ConvertDEC(Reader["CHQ_REG_PERC_BILL15"]),
					CHQ_REG_PERC_BILL16 = ConvertDEC(Reader["CHQ_REG_PERC_BILL16"]),
					CHQ_REG_PERC_BILL17 = ConvertDEC(Reader["CHQ_REG_PERC_BILL17"]),
					CHQ_REG_PERC_BILL18 = ConvertDEC(Reader["CHQ_REG_PERC_BILL18"]),
					CHQ_REG_PERC_MISC1 = ConvertDEC(Reader["CHQ_REG_PERC_MISC1"]),
					CHQ_REG_PERC_MISC2 = ConvertDEC(Reader["CHQ_REG_PERC_MISC2"]),
					CHQ_REG_PERC_MISC3 = ConvertDEC(Reader["CHQ_REG_PERC_MISC3"]),
					CHQ_REG_PERC_MISC4 = ConvertDEC(Reader["CHQ_REG_PERC_MISC4"]),
					CHQ_REG_PERC_MISC5 = ConvertDEC(Reader["CHQ_REG_PERC_MISC5"]),
					CHQ_REG_PERC_MISC6 = ConvertDEC(Reader["CHQ_REG_PERC_MISC6"]),
					CHQ_REG_PERC_MISC7 = ConvertDEC(Reader["CHQ_REG_PERC_MISC7"]),
					CHQ_REG_PERC_MISC8 = ConvertDEC(Reader["CHQ_REG_PERC_MISC8"]),
					CHQ_REG_PERC_MISC9 = ConvertDEC(Reader["CHQ_REG_PERC_MISC9"]),
					CHQ_REG_PERC_MISC10 = ConvertDEC(Reader["CHQ_REG_PERC_MISC10"]),
					CHQ_REG_PERC_MISC11 = ConvertDEC(Reader["CHQ_REG_PERC_MISC11"]),
					CHQ_REG_PERC_MISC12 = ConvertDEC(Reader["CHQ_REG_PERC_MISC12"]),
					CHQ_REG_PERC_MISC13 = ConvertDEC(Reader["CHQ_REG_PERC_MISC13"]),
					CHQ_REG_PERC_MISC14 = ConvertDEC(Reader["CHQ_REG_PERC_MISC14"]),
					CHQ_REG_PERC_MISC15 = ConvertDEC(Reader["CHQ_REG_PERC_MISC15"]),
					CHQ_REG_PERC_MISC16 = ConvertDEC(Reader["CHQ_REG_PERC_MISC16"]),
					CHQ_REG_PERC_MISC17 = ConvertDEC(Reader["CHQ_REG_PERC_MISC17"]),
					CHQ_REG_PERC_MISC18 = ConvertDEC(Reader["CHQ_REG_PERC_MISC18"]),
					CHQ_REG_PAY_CODE1 = Reader["CHQ_REG_PAY_CODE1"].ToString(),
					CHQ_REG_PAY_CODE2 = Reader["CHQ_REG_PAY_CODE2"].ToString(),
					CHQ_REG_PAY_CODE3 = Reader["CHQ_REG_PAY_CODE3"].ToString(),
					CHQ_REG_PAY_CODE4 = Reader["CHQ_REG_PAY_CODE4"].ToString(),
					CHQ_REG_PAY_CODE5 = Reader["CHQ_REG_PAY_CODE5"].ToString(),
					CHQ_REG_PAY_CODE6 = Reader["CHQ_REG_PAY_CODE6"].ToString(),
					CHQ_REG_PAY_CODE7 = Reader["CHQ_REG_PAY_CODE7"].ToString(),
					CHQ_REG_PAY_CODE8 = Reader["CHQ_REG_PAY_CODE8"].ToString(),
					CHQ_REG_PAY_CODE9 = Reader["CHQ_REG_PAY_CODE9"].ToString(),
					CHQ_REG_PAY_CODE10 = Reader["CHQ_REG_PAY_CODE10"].ToString(),
					CHQ_REG_PAY_CODE11 = Reader["CHQ_REG_PAY_CODE11"].ToString(),
					CHQ_REG_PAY_CODE12 = Reader["CHQ_REG_PAY_CODE12"].ToString(),
					CHQ_REG_PAY_CODE13 = Reader["CHQ_REG_PAY_CODE13"].ToString(),
					CHQ_REG_PAY_CODE14 = Reader["CHQ_REG_PAY_CODE14"].ToString(),
					CHQ_REG_PAY_CODE15 = Reader["CHQ_REG_PAY_CODE15"].ToString(),
					CHQ_REG_PAY_CODE16 = Reader["CHQ_REG_PAY_CODE16"].ToString(),
					CHQ_REG_PAY_CODE17 = Reader["CHQ_REG_PAY_CODE17"].ToString(),
					CHQ_REG_PAY_CODE18 = Reader["CHQ_REG_PAY_CODE18"].ToString(),
					CHQ_REG_PERC_TAX1 = ConvertDEC(Reader["CHQ_REG_PERC_TAX1"]),
					CHQ_REG_PERC_TAX2 = ConvertDEC(Reader["CHQ_REG_PERC_TAX2"]),
					CHQ_REG_PERC_TAX3 = ConvertDEC(Reader["CHQ_REG_PERC_TAX3"]),
					CHQ_REG_PERC_TAX4 = ConvertDEC(Reader["CHQ_REG_PERC_TAX4"]),
					CHQ_REG_PERC_TAX5 = ConvertDEC(Reader["CHQ_REG_PERC_TAX5"]),
					CHQ_REG_PERC_TAX6 = ConvertDEC(Reader["CHQ_REG_PERC_TAX6"]),
					CHQ_REG_PERC_TAX7 = ConvertDEC(Reader["CHQ_REG_PERC_TAX7"]),
					CHQ_REG_PERC_TAX8 = ConvertDEC(Reader["CHQ_REG_PERC_TAX8"]),
					CHQ_REG_PERC_TAX9 = ConvertDEC(Reader["CHQ_REG_PERC_TAX9"]),
					CHQ_REG_PERC_TAX10 = ConvertDEC(Reader["CHQ_REG_PERC_TAX10"]),
					CHQ_REG_PERC_TAX11 = ConvertDEC(Reader["CHQ_REG_PERC_TAX11"]),
					CHQ_REG_PERC_TAX12 = ConvertDEC(Reader["CHQ_REG_PERC_TAX12"]),
					CHQ_REG_PERC_TAX13 = ConvertDEC(Reader["CHQ_REG_PERC_TAX13"]),
					CHQ_REG_PERC_TAX14 = ConvertDEC(Reader["CHQ_REG_PERC_TAX14"]),
					CHQ_REG_PERC_TAX15 = ConvertDEC(Reader["CHQ_REG_PERC_TAX15"]),
					CHQ_REG_PERC_TAX16 = ConvertDEC(Reader["CHQ_REG_PERC_TAX16"]),
					CHQ_REG_PERC_TAX17 = ConvertDEC(Reader["CHQ_REG_PERC_TAX17"]),
					CHQ_REG_PERC_TAX18 = ConvertDEC(Reader["CHQ_REG_PERC_TAX18"]),
					CHQ_REG_MTH_BILL_AMT1 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT1"]),
					CHQ_REG_MTH_BILL_AMT2 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT2"]),
					CHQ_REG_MTH_BILL_AMT3 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT3"]),
					CHQ_REG_MTH_BILL_AMT4 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT4"]),
					CHQ_REG_MTH_BILL_AMT5 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT5"]),
					CHQ_REG_MTH_BILL_AMT6 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT6"]),
					CHQ_REG_MTH_BILL_AMT7 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT7"]),
					CHQ_REG_MTH_BILL_AMT8 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT8"]),
					CHQ_REG_MTH_BILL_AMT9 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT9"]),
					CHQ_REG_MTH_BILL_AMT10 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT10"]),
					CHQ_REG_MTH_BILL_AMT11 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT11"]),
					CHQ_REG_MTH_BILL_AMT12 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT12"]),
					CHQ_REG_MTH_BILL_AMT13 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT13"]),
					CHQ_REG_MTH_BILL_AMT14 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT14"]),
					CHQ_REG_MTH_BILL_AMT15 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT15"]),
					CHQ_REG_MTH_BILL_AMT16 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT16"]),
					CHQ_REG_MTH_BILL_AMT17 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT17"]),
					CHQ_REG_MTH_BILL_AMT18 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT18"]),
					CHQ_REG_MTH_MISC_AMT_11 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_11"]),
					CHQ_REG_MTH_MISC_AMT_12 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_12"]),
					CHQ_REG_MTH_MISC_AMT_13 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_13"]),
					CHQ_REG_MTH_MISC_AMT_14 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_14"]),
					CHQ_REG_MTH_MISC_AMT_15 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_15"]),
					CHQ_REG_MTH_MISC_AMT_16 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_16"]),
					CHQ_REG_MTH_MISC_AMT_17 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_17"]),
					CHQ_REG_MTH_MISC_AMT_18 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_18"]),
					CHQ_REG_MTH_MISC_AMT_19 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_19"]),
					CHQ_REG_MTH_MISC_AMT_110 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_110"]),
					CHQ_REG_MTH_MISC_AMT_111 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_111"]),
					CHQ_REG_MTH_MISC_AMT_112 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_112"]),
					CHQ_REG_MTH_MISC_AMT_113 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_113"]),
					CHQ_REG_MTH_MISC_AMT_114 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_114"]),
					CHQ_REG_MTH_MISC_AMT_115 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_115"]),
					CHQ_REG_MTH_MISC_AMT_116 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_116"]),
					CHQ_REG_MTH_MISC_AMT_117 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_117"]),
					CHQ_REG_MTH_MISC_AMT_118 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_118"]),
					CHQ_REG_MTH_MISC_AMT_21 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_21"]),
					CHQ_REG_MTH_MISC_AMT_22 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_22"]),
					CHQ_REG_MTH_MISC_AMT_23 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_23"]),
					CHQ_REG_MTH_MISC_AMT_24 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_24"]),
					CHQ_REG_MTH_MISC_AMT_25 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_25"]),
					CHQ_REG_MTH_MISC_AMT_26 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_26"]),
					CHQ_REG_MTH_MISC_AMT_27 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_27"]),
					CHQ_REG_MTH_MISC_AMT_28 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_28"]),
					CHQ_REG_MTH_MISC_AMT_29 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_29"]),
					CHQ_REG_MTH_MISC_AMT_210 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_210"]),
					CHQ_REG_MTH_MISC_AMT_211 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_211"]),
					CHQ_REG_MTH_MISC_AMT_212 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_212"]),
					CHQ_REG_MTH_MISC_AMT_213 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_213"]),
					CHQ_REG_MTH_MISC_AMT_214 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_214"]),
					CHQ_REG_MTH_MISC_AMT_215 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_215"]),
					CHQ_REG_MTH_MISC_AMT_216 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_216"]),
					CHQ_REG_MTH_MISC_AMT_217 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_217"]),
					CHQ_REG_MTH_MISC_AMT_218 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_218"]),
					CHQ_REG_MTH_MISC_AMT_31 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_31"]),
					CHQ_REG_MTH_MISC_AMT_32 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_32"]),
					CHQ_REG_MTH_MISC_AMT_33 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_33"]),
					CHQ_REG_MTH_MISC_AMT_34 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_34"]),
					CHQ_REG_MTH_MISC_AMT_35 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_35"]),
					CHQ_REG_MTH_MISC_AMT_36 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_36"]),
					CHQ_REG_MTH_MISC_AMT_37 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_37"]),
					CHQ_REG_MTH_MISC_AMT_38 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_38"]),
					CHQ_REG_MTH_MISC_AMT_39 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_39"]),
					CHQ_REG_MTH_MISC_AMT_310 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_310"]),
					CHQ_REG_MTH_MISC_AMT_311 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_311"]),
					CHQ_REG_MTH_MISC_AMT_312 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_312"]),
					CHQ_REG_MTH_MISC_AMT_313 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_313"]),
					CHQ_REG_MTH_MISC_AMT_314 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_314"]),
					CHQ_REG_MTH_MISC_AMT_315 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_315"]),
					CHQ_REG_MTH_MISC_AMT_316 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_316"]),
					CHQ_REG_MTH_MISC_AMT_317 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_317"]),
					CHQ_REG_MTH_MISC_AMT_318 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_318"]),
					CHQ_REG_MTH_MISC_AMT_41 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_41"]),
					CHQ_REG_MTH_MISC_AMT_42 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_42"]),
					CHQ_REG_MTH_MISC_AMT_43 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_43"]),
					CHQ_REG_MTH_MISC_AMT_44 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_44"]),
					CHQ_REG_MTH_MISC_AMT_45 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_45"]),
					CHQ_REG_MTH_MISC_AMT_46 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_46"]),
					CHQ_REG_MTH_MISC_AMT_47 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_47"]),
					CHQ_REG_MTH_MISC_AMT_48 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_48"]),
					CHQ_REG_MTH_MISC_AMT_49 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_49"]),
					CHQ_REG_MTH_MISC_AMT_410 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_410"]),
					CHQ_REG_MTH_MISC_AMT_411 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_411"]),
					CHQ_REG_MTH_MISC_AMT_412 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_412"]),
					CHQ_REG_MTH_MISC_AMT_413 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_413"]),
					CHQ_REG_MTH_MISC_AMT_414 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_414"]),
					CHQ_REG_MTH_MISC_AMT_415 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_415"]),
					CHQ_REG_MTH_MISC_AMT_416 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_416"]),
					CHQ_REG_MTH_MISC_AMT_417 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_417"]),
					CHQ_REG_MTH_MISC_AMT_418 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_418"]),
					CHQ_REG_MTH_MISC_AMT_51 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_51"]),
					CHQ_REG_MTH_MISC_AMT_52 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_52"]),
					CHQ_REG_MTH_MISC_AMT_53 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_53"]),
					CHQ_REG_MTH_MISC_AMT_54 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_54"]),
					CHQ_REG_MTH_MISC_AMT_55 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_55"]),
					CHQ_REG_MTH_MISC_AMT_56 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_56"]),
					CHQ_REG_MTH_MISC_AMT_57 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_57"]),
					CHQ_REG_MTH_MISC_AMT_58 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_58"]),
					CHQ_REG_MTH_MISC_AMT_59 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_59"]),
					CHQ_REG_MTH_MISC_AMT_510 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_510"]),
					CHQ_REG_MTH_MISC_AMT_511 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_511"]),
					CHQ_REG_MTH_MISC_AMT_512 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_512"]),
					CHQ_REG_MTH_MISC_AMT_513 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_513"]),
					CHQ_REG_MTH_MISC_AMT_514 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_514"]),
					CHQ_REG_MTH_MISC_AMT_515 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_515"]),
					CHQ_REG_MTH_MISC_AMT_516 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_516"]),
					CHQ_REG_MTH_MISC_AMT_517 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_517"]),
					CHQ_REG_MTH_MISC_AMT_518 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_518"]),
					CHQ_REG_MTH_MISC_AMT_61 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_61"]),
					CHQ_REG_MTH_MISC_AMT_62 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_62"]),
					CHQ_REG_MTH_MISC_AMT_63 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_63"]),
					CHQ_REG_MTH_MISC_AMT_64 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_64"]),
					CHQ_REG_MTH_MISC_AMT_65 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_65"]),
					CHQ_REG_MTH_MISC_AMT_66 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_66"]),
					CHQ_REG_MTH_MISC_AMT_67 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_67"]),
					CHQ_REG_MTH_MISC_AMT_68 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_68"]),
					CHQ_REG_MTH_MISC_AMT_69 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_69"]),
					CHQ_REG_MTH_MISC_AMT_610 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_610"]),
					CHQ_REG_MTH_MISC_AMT_611 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_611"]),
					CHQ_REG_MTH_MISC_AMT_612 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_612"]),
					CHQ_REG_MTH_MISC_AMT_613 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_613"]),
					CHQ_REG_MTH_MISC_AMT_614 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_614"]),
					CHQ_REG_MTH_MISC_AMT_615 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_615"]),
					CHQ_REG_MTH_MISC_AMT_616 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_616"]),
					CHQ_REG_MTH_MISC_AMT_617 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_617"]),
					CHQ_REG_MTH_MISC_AMT_618 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_618"]),
					CHQ_REG_MTH_MISC_AMT_71 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_71"]),
					CHQ_REG_MTH_MISC_AMT_72 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_72"]),
					CHQ_REG_MTH_MISC_AMT_73 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_73"]),
					CHQ_REG_MTH_MISC_AMT_74 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_74"]),
					CHQ_REG_MTH_MISC_AMT_75 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_75"]),
					CHQ_REG_MTH_MISC_AMT_76 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_76"]),
					CHQ_REG_MTH_MISC_AMT_77 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_77"]),
					CHQ_REG_MTH_MISC_AMT_78 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_78"]),
					CHQ_REG_MTH_MISC_AMT_79 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_79"]),
					CHQ_REG_MTH_MISC_AMT_710 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_710"]),
					CHQ_REG_MTH_MISC_AMT_711 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_711"]),
					CHQ_REG_MTH_MISC_AMT_712 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_712"]),
					CHQ_REG_MTH_MISC_AMT_713 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_713"]),
					CHQ_REG_MTH_MISC_AMT_714 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_714"]),
					CHQ_REG_MTH_MISC_AMT_715 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_715"]),
					CHQ_REG_MTH_MISC_AMT_716 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_716"]),
					CHQ_REG_MTH_MISC_AMT_717 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_717"]),
					CHQ_REG_MTH_MISC_AMT_718 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_718"]),
					CHQ_REG_MTH_MISC_AMT_81 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_81"]),
					CHQ_REG_MTH_MISC_AMT_82 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_82"]),
					CHQ_REG_MTH_MISC_AMT_83 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_83"]),
					CHQ_REG_MTH_MISC_AMT_84 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_84"]),
					CHQ_REG_MTH_MISC_AMT_85 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_85"]),
					CHQ_REG_MTH_MISC_AMT_86 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_86"]),
					CHQ_REG_MTH_MISC_AMT_87 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_87"]),
					CHQ_REG_MTH_MISC_AMT_88 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_88"]),
					CHQ_REG_MTH_MISC_AMT_89 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_89"]),
					CHQ_REG_MTH_MISC_AMT_810 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_810"]),
					CHQ_REG_MTH_MISC_AMT_811 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_811"]),
					CHQ_REG_MTH_MISC_AMT_812 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_812"]),
					CHQ_REG_MTH_MISC_AMT_813 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_813"]),
					CHQ_REG_MTH_MISC_AMT_814 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_814"]),
					CHQ_REG_MTH_MISC_AMT_815 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_815"]),
					CHQ_REG_MTH_MISC_AMT_816 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_816"]),
					CHQ_REG_MTH_MISC_AMT_817 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_817"]),
					CHQ_REG_MTH_MISC_AMT_818 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_818"]),
					CHQ_REG_MTH_MISC_AMT_91 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_91"]),
					CHQ_REG_MTH_MISC_AMT_92 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_92"]),
					CHQ_REG_MTH_MISC_AMT_93 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_93"]),
					CHQ_REG_MTH_MISC_AMT_94 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_94"]),
					CHQ_REG_MTH_MISC_AMT_95 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_95"]),
					CHQ_REG_MTH_MISC_AMT_96 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_96"]),
					CHQ_REG_MTH_MISC_AMT_97 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_97"]),
					CHQ_REG_MTH_MISC_AMT_98 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_98"]),
					CHQ_REG_MTH_MISC_AMT_99 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_99"]),
					CHQ_REG_MTH_MISC_AMT_910 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_910"]),
					CHQ_REG_MTH_MISC_AMT_911 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_911"]),
					CHQ_REG_MTH_MISC_AMT_912 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_912"]),
					CHQ_REG_MTH_MISC_AMT_913 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_913"]),
					CHQ_REG_MTH_MISC_AMT_914 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_914"]),
					CHQ_REG_MTH_MISC_AMT_915 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_915"]),
					CHQ_REG_MTH_MISC_AMT_916 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_916"]),
					CHQ_REG_MTH_MISC_AMT_917 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_917"]),
					CHQ_REG_MTH_MISC_AMT_918 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_918"]),
					CHQ_REG_MTH_MISC_AMT_101 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_101"]),
					CHQ_REG_MTH_MISC_AMT_102 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_102"]),
					CHQ_REG_MTH_MISC_AMT_103 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_103"]),
					CHQ_REG_MTH_MISC_AMT_104 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_104"]),
					CHQ_REG_MTH_MISC_AMT_105 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_105"]),
					CHQ_REG_MTH_MISC_AMT_106 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_106"]),
					CHQ_REG_MTH_MISC_AMT_107 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_107"]),
					CHQ_REG_MTH_MISC_AMT_108 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_108"]),
					CHQ_REG_MTH_MISC_AMT_109 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_109"]),
					CHQ_REG_MTH_MISC_AMT_1010 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1010"]),
					CHQ_REG_MTH_MISC_AMT_1011 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1011"]),
					CHQ_REG_MTH_MISC_AMT_1012 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1012"]),
					CHQ_REG_MTH_MISC_AMT_1013 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1013"]),
					CHQ_REG_MTH_MISC_AMT_1014 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1014"]),
					CHQ_REG_MTH_MISC_AMT_1015 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1015"]),
					CHQ_REG_MTH_MISC_AMT_1016 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1016"]),
					CHQ_REG_MTH_MISC_AMT_1017 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1017"]),
					CHQ_REG_MTH_MISC_AMT_1018 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1018"]),
					CHQ_REG_MTH_EXP_AMT1 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT1"]),
					CHQ_REG_MTH_EXP_AMT2 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT2"]),
					CHQ_REG_MTH_EXP_AMT3 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT3"]),
					CHQ_REG_MTH_EXP_AMT4 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT4"]),
					CHQ_REG_MTH_EXP_AMT5 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT5"]),
					CHQ_REG_MTH_EXP_AMT6 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT6"]),
					CHQ_REG_MTH_EXP_AMT7 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT7"]),
					CHQ_REG_MTH_EXP_AMT8 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT8"]),
					CHQ_REG_MTH_EXP_AMT9 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT9"]),
					CHQ_REG_MTH_EXP_AMT10 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT10"]),
					CHQ_REG_MTH_EXP_AMT11 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT11"]),
					CHQ_REG_MTH_EXP_AMT12 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT12"]),
					CHQ_REG_MTH_EXP_AMT13 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT13"]),
					CHQ_REG_MTH_EXP_AMT14 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT14"]),
					CHQ_REG_MTH_EXP_AMT15 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT15"]),
					CHQ_REG_MTH_EXP_AMT16 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT16"]),
					CHQ_REG_MTH_EXP_AMT17 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT17"]),
					CHQ_REG_MTH_EXP_AMT18 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT18"]),
					CHQ_REG_COMP_ANN_EXP_THIS_PAY1 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY1"]),
					CHQ_REG_COMP_ANN_EXP_THIS_PAY2 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY2"]),
					CHQ_REG_COMP_ANN_EXP_THIS_PAY3 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY3"]),
					CHQ_REG_COMP_ANN_EXP_THIS_PAY4 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY4"]),
					CHQ_REG_COMP_ANN_EXP_THIS_PAY5 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY5"]),
					CHQ_REG_COMP_ANN_EXP_THIS_PAY6 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY6"]),
					CHQ_REG_COMP_ANN_EXP_THIS_PAY7 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY7"]),
					CHQ_REG_COMP_ANN_EXP_THIS_PAY8 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY8"]),
					CHQ_REG_COMP_ANN_EXP_THIS_PAY9 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY9"]),
					CHQ_REG_COMP_ANN_EXP_THIS_PAY10 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY10"]),
					CHQ_REG_COMP_ANN_EXP_THIS_PAY11 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY11"]),
					CHQ_REG_COMP_ANN_EXP_THIS_PAY12 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY12"]),
					CHQ_REG_COMP_ANN_EXP_THIS_PAY13 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY13"]),
					CHQ_REG_COMP_ANN_EXP_THIS_PAY14 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY14"]),
					CHQ_REG_COMP_ANN_EXP_THIS_PAY15 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY15"]),
					CHQ_REG_COMP_ANN_EXP_THIS_PAY16 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY16"]),
					CHQ_REG_COMP_ANN_EXP_THIS_PAY17 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY17"]),
					CHQ_REG_COMP_ANN_EXP_THIS_PAY18 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY18"]),
					CHQ_REG_MTH_CEIL_AMT1 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT1"]),
					CHQ_REG_MTH_CEIL_AMT2 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT2"]),
					CHQ_REG_MTH_CEIL_AMT3 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT3"]),
					CHQ_REG_MTH_CEIL_AMT4 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT4"]),
					CHQ_REG_MTH_CEIL_AMT5 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT5"]),
					CHQ_REG_MTH_CEIL_AMT6 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT6"]),
					CHQ_REG_MTH_CEIL_AMT7 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT7"]),
					CHQ_REG_MTH_CEIL_AMT8 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT8"]),
					CHQ_REG_MTH_CEIL_AMT9 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT9"]),
					CHQ_REG_MTH_CEIL_AMT10 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT10"]),
					CHQ_REG_MTH_CEIL_AMT11 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT11"]),
					CHQ_REG_MTH_CEIL_AMT12 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT12"]),
					CHQ_REG_MTH_CEIL_AMT13 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT13"]),
					CHQ_REG_MTH_CEIL_AMT14 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT14"]),
					CHQ_REG_MTH_CEIL_AMT15 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT15"]),
					CHQ_REG_MTH_CEIL_AMT16 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT16"]),
					CHQ_REG_MTH_CEIL_AMT17 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT17"]),
					CHQ_REG_MTH_CEIL_AMT18 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT18"]),
					CHQ_REG_COMP_ANN_CEIL_THIS_PAY1 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY1"]),
					CHQ_REG_COMP_ANN_CEIL_THIS_PAY2 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY2"]),
					CHQ_REG_COMP_ANN_CEIL_THIS_PAY3 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY3"]),
					CHQ_REG_COMP_ANN_CEIL_THIS_PAY4 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY4"]),
					CHQ_REG_COMP_ANN_CEIL_THIS_PAY5 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY5"]),
					CHQ_REG_COMP_ANN_CEIL_THIS_PAY6 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY6"]),
					CHQ_REG_COMP_ANN_CEIL_THIS_PAY7 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY7"]),
					CHQ_REG_COMP_ANN_CEIL_THIS_PAY8 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY8"]),
					CHQ_REG_COMP_ANN_CEIL_THIS_PAY9 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY9"]),
					CHQ_REG_COMP_ANN_CEIL_THIS_PAY10 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY10"]),
					CHQ_REG_COMP_ANN_CEIL_THIS_PAY11 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY11"]),
					CHQ_REG_COMP_ANN_CEIL_THIS_PAY12 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY12"]),
					CHQ_REG_COMP_ANN_CEIL_THIS_PAY13 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY13"]),
					CHQ_REG_COMP_ANN_CEIL_THIS_PAY14 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY14"]),
					CHQ_REG_COMP_ANN_CEIL_THIS_PAY15 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY15"]),
					CHQ_REG_COMP_ANN_CEIL_THIS_PAY16 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY16"]),
					CHQ_REG_COMP_ANN_CEIL_THIS_PAY17 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY17"]),
					CHQ_REG_COMP_ANN_CEIL_THIS_PAY18 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY18"]),
					CHQ_REG_EARNINGS_THIS_MTH1 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH1"]),
					CHQ_REG_EARNINGS_THIS_MTH2 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH2"]),
					CHQ_REG_EARNINGS_THIS_MTH3 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH3"]),
					CHQ_REG_EARNINGS_THIS_MTH4 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH4"]),
					CHQ_REG_EARNINGS_THIS_MTH5 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH5"]),
					CHQ_REG_EARNINGS_THIS_MTH6 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH6"]),
					CHQ_REG_EARNINGS_THIS_MTH7 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH7"]),
					CHQ_REG_EARNINGS_THIS_MTH8 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH8"]),
					CHQ_REG_EARNINGS_THIS_MTH9 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH9"]),
					CHQ_REG_EARNINGS_THIS_MTH10 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH10"]),
					CHQ_REG_EARNINGS_THIS_MTH11 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH11"]),
					CHQ_REG_EARNINGS_THIS_MTH12 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH12"]),
					CHQ_REG_EARNINGS_THIS_MTH13 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH13"]),
					CHQ_REG_EARNINGS_THIS_MTH14 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH14"]),
					CHQ_REG_EARNINGS_THIS_MTH15 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH15"]),
					CHQ_REG_EARNINGS_THIS_MTH16 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH16"]),
					CHQ_REG_EARNINGS_THIS_MTH17 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH17"]),
					CHQ_REG_EARNINGS_THIS_MTH18 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH18"]),
					CHQ_REG_REGULAR_PAY_THIS_MTH1 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH1"]),
					CHQ_REG_REGULAR_PAY_THIS_MTH2 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH2"]),
					CHQ_REG_REGULAR_PAY_THIS_MTH3 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH3"]),
					CHQ_REG_REGULAR_PAY_THIS_MTH4 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH4"]),
					CHQ_REG_REGULAR_PAY_THIS_MTH5 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH5"]),
					CHQ_REG_REGULAR_PAY_THIS_MTH6 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH6"]),
					CHQ_REG_REGULAR_PAY_THIS_MTH7 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH7"]),
					CHQ_REG_REGULAR_PAY_THIS_MTH8 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH8"]),
					CHQ_REG_REGULAR_PAY_THIS_MTH9 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH9"]),
					CHQ_REG_REGULAR_PAY_THIS_MTH10 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH10"]),
					CHQ_REG_REGULAR_PAY_THIS_MTH11 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH11"]),
					CHQ_REG_REGULAR_PAY_THIS_MTH12 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH12"]),
					CHQ_REG_REGULAR_PAY_THIS_MTH13 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH13"]),
					CHQ_REG_REGULAR_PAY_THIS_MTH14 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH14"]),
					CHQ_REG_REGULAR_PAY_THIS_MTH15 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH15"]),
					CHQ_REG_REGULAR_PAY_THIS_MTH16 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH16"]),
					CHQ_REG_REGULAR_PAY_THIS_MTH17 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH17"]),
					CHQ_REG_REGULAR_PAY_THIS_MTH18 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH18"]),
					CHQ_REG_REGULAR_TAX_THIS_MTH1 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH1"]),
					CHQ_REG_REGULAR_TAX_THIS_MTH2 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH2"]),
					CHQ_REG_REGULAR_TAX_THIS_MTH3 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH3"]),
					CHQ_REG_REGULAR_TAX_THIS_MTH4 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH4"]),
					CHQ_REG_REGULAR_TAX_THIS_MTH5 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH5"]),
					CHQ_REG_REGULAR_TAX_THIS_MTH6 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH6"]),
					CHQ_REG_REGULAR_TAX_THIS_MTH7 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH7"]),
					CHQ_REG_REGULAR_TAX_THIS_MTH8 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH8"]),
					CHQ_REG_REGULAR_TAX_THIS_MTH9 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH9"]),
					CHQ_REG_REGULAR_TAX_THIS_MTH10 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH10"]),
					CHQ_REG_REGULAR_TAX_THIS_MTH11 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH11"]),
					CHQ_REG_REGULAR_TAX_THIS_MTH12 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH12"]),
					CHQ_REG_REGULAR_TAX_THIS_MTH13 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH13"]),
					CHQ_REG_REGULAR_TAX_THIS_MTH14 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH14"]),
					CHQ_REG_REGULAR_TAX_THIS_MTH15 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH15"]),
					CHQ_REG_REGULAR_TAX_THIS_MTH16 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH16"]),
					CHQ_REG_REGULAR_TAX_THIS_MTH17 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH17"]),
					CHQ_REG_REGULAR_TAX_THIS_MTH18 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH18"]),
					CHQ_REG_MAN_PAY_THIS_MTH1 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH1"]),
					CHQ_REG_MAN_PAY_THIS_MTH2 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH2"]),
					CHQ_REG_MAN_PAY_THIS_MTH3 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH3"]),
					CHQ_REG_MAN_PAY_THIS_MTH4 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH4"]),
					CHQ_REG_MAN_PAY_THIS_MTH5 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH5"]),
					CHQ_REG_MAN_PAY_THIS_MTH6 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH6"]),
					CHQ_REG_MAN_PAY_THIS_MTH7 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH7"]),
					CHQ_REG_MAN_PAY_THIS_MTH8 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH8"]),
					CHQ_REG_MAN_PAY_THIS_MTH9 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH9"]),
					CHQ_REG_MAN_PAY_THIS_MTH10 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH10"]),
					CHQ_REG_MAN_PAY_THIS_MTH11 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH11"]),
					CHQ_REG_MAN_PAY_THIS_MTH12 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH12"]),
					CHQ_REG_MAN_PAY_THIS_MTH13 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH13"]),
					CHQ_REG_MAN_PAY_THIS_MTH14 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH14"]),
					CHQ_REG_MAN_PAY_THIS_MTH15 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH15"]),
					CHQ_REG_MAN_PAY_THIS_MTH16 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH16"]),
					CHQ_REG_MAN_PAY_THIS_MTH17 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH17"]),
					CHQ_REG_MAN_PAY_THIS_MTH18 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH18"]),
					CHQ_REG_MAN_TAX_THIS_MTH1 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH1"]),
					CHQ_REG_MAN_TAX_THIS_MTH2 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH2"]),
					CHQ_REG_MAN_TAX_THIS_MTH3 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH3"]),
					CHQ_REG_MAN_TAX_THIS_MTH4 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH4"]),
					CHQ_REG_MAN_TAX_THIS_MTH5 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH5"]),
					CHQ_REG_MAN_TAX_THIS_MTH6 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH6"]),
					CHQ_REG_MAN_TAX_THIS_MTH7 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH7"]),
					CHQ_REG_MAN_TAX_THIS_MTH8 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH8"]),
					CHQ_REG_MAN_TAX_THIS_MTH9 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH9"]),
					CHQ_REG_MAN_TAX_THIS_MTH10 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH10"]),
					CHQ_REG_MAN_TAX_THIS_MTH11 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH11"]),
					CHQ_REG_MAN_TAX_THIS_MTH12 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH12"]),
					CHQ_REG_MAN_TAX_THIS_MTH13 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH13"]),
					CHQ_REG_MAN_TAX_THIS_MTH14 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH14"]),
					CHQ_REG_MAN_TAX_THIS_MTH15 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH15"]),
					CHQ_REG_MAN_TAX_THIS_MTH16 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH16"]),
					CHQ_REG_MAN_TAX_THIS_MTH17 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH17"]),
					CHQ_REG_MAN_TAX_THIS_MTH18 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH18"]),
					CHQ_REG_PAY_DATE1 = ConvertDEC(Reader["CHQ_REG_PAY_DATE1"]),
					CHQ_REG_PAY_DATE2 = ConvertDEC(Reader["CHQ_REG_PAY_DATE2"]),
					CHQ_REG_PAY_DATE3 = ConvertDEC(Reader["CHQ_REG_PAY_DATE3"]),
					CHQ_REG_PAY_DATE4 = ConvertDEC(Reader["CHQ_REG_PAY_DATE4"]),
					CHQ_REG_PAY_DATE5 = ConvertDEC(Reader["CHQ_REG_PAY_DATE5"]),
					CHQ_REG_PAY_DATE6 = ConvertDEC(Reader["CHQ_REG_PAY_DATE6"]),
					CHQ_REG_PAY_DATE7 = ConvertDEC(Reader["CHQ_REG_PAY_DATE7"]),
					CHQ_REG_PAY_DATE8 = ConvertDEC(Reader["CHQ_REG_PAY_DATE8"]),
					CHQ_REG_PAY_DATE9 = ConvertDEC(Reader["CHQ_REG_PAY_DATE9"]),
					CHQ_REG_PAY_DATE10 = ConvertDEC(Reader["CHQ_REG_PAY_DATE10"]),
					CHQ_REG_PAY_DATE11 = ConvertDEC(Reader["CHQ_REG_PAY_DATE11"]),
					CHQ_REG_PAY_DATE12 = ConvertDEC(Reader["CHQ_REG_PAY_DATE12"]),
					CHQ_REG_PAY_DATE13 = ConvertDEC(Reader["CHQ_REG_PAY_DATE13"]),
					CHQ_REG_PAY_DATE14 = ConvertDEC(Reader["CHQ_REG_PAY_DATE14"]),
					CHQ_REG_PAY_DATE15 = ConvertDEC(Reader["CHQ_REG_PAY_DATE15"]),
					CHQ_REG_PAY_DATE16 = ConvertDEC(Reader["CHQ_REG_PAY_DATE16"]),
					CHQ_REG_PAY_DATE17 = ConvertDEC(Reader["CHQ_REG_PAY_DATE17"]),
					CHQ_REG_PAY_DATE18 = ConvertDEC(Reader["CHQ_REG_PAY_DATE18"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereChq_reg_clinic_nbr_1_2 = WhereChq_reg_clinic_nbr_1_2,
					_whereChq_reg_dept = WhereChq_reg_dept,
					_whereChq_reg_doc_nbr = WhereChq_reg_doc_nbr,
					_whereChq_reg_perc_bill1 = WhereChq_reg_perc_bill1,
					_whereChq_reg_perc_bill2 = WhereChq_reg_perc_bill2,
					_whereChq_reg_perc_bill3 = WhereChq_reg_perc_bill3,
					_whereChq_reg_perc_bill4 = WhereChq_reg_perc_bill4,
					_whereChq_reg_perc_bill5 = WhereChq_reg_perc_bill5,
					_whereChq_reg_perc_bill6 = WhereChq_reg_perc_bill6,
					_whereChq_reg_perc_bill7 = WhereChq_reg_perc_bill7,
					_whereChq_reg_perc_bill8 = WhereChq_reg_perc_bill8,
					_whereChq_reg_perc_bill9 = WhereChq_reg_perc_bill9,
					_whereChq_reg_perc_bill10 = WhereChq_reg_perc_bill10,
					_whereChq_reg_perc_bill11 = WhereChq_reg_perc_bill11,
					_whereChq_reg_perc_bill12 = WhereChq_reg_perc_bill12,
					_whereChq_reg_perc_bill13 = WhereChq_reg_perc_bill13,
					_whereChq_reg_perc_bill14 = WhereChq_reg_perc_bill14,
					_whereChq_reg_perc_bill15 = WhereChq_reg_perc_bill15,
					_whereChq_reg_perc_bill16 = WhereChq_reg_perc_bill16,
					_whereChq_reg_perc_bill17 = WhereChq_reg_perc_bill17,
					_whereChq_reg_perc_bill18 = WhereChq_reg_perc_bill18,
					_whereChq_reg_perc_misc1 = WhereChq_reg_perc_misc1,
					_whereChq_reg_perc_misc2 = WhereChq_reg_perc_misc2,
					_whereChq_reg_perc_misc3 = WhereChq_reg_perc_misc3,
					_whereChq_reg_perc_misc4 = WhereChq_reg_perc_misc4,
					_whereChq_reg_perc_misc5 = WhereChq_reg_perc_misc5,
					_whereChq_reg_perc_misc6 = WhereChq_reg_perc_misc6,
					_whereChq_reg_perc_misc7 = WhereChq_reg_perc_misc7,
					_whereChq_reg_perc_misc8 = WhereChq_reg_perc_misc8,
					_whereChq_reg_perc_misc9 = WhereChq_reg_perc_misc9,
					_whereChq_reg_perc_misc10 = WhereChq_reg_perc_misc10,
					_whereChq_reg_perc_misc11 = WhereChq_reg_perc_misc11,
					_whereChq_reg_perc_misc12 = WhereChq_reg_perc_misc12,
					_whereChq_reg_perc_misc13 = WhereChq_reg_perc_misc13,
					_whereChq_reg_perc_misc14 = WhereChq_reg_perc_misc14,
					_whereChq_reg_perc_misc15 = WhereChq_reg_perc_misc15,
					_whereChq_reg_perc_misc16 = WhereChq_reg_perc_misc16,
					_whereChq_reg_perc_misc17 = WhereChq_reg_perc_misc17,
					_whereChq_reg_perc_misc18 = WhereChq_reg_perc_misc18,
					_whereChq_reg_pay_code1 = WhereChq_reg_pay_code1,
					_whereChq_reg_pay_code2 = WhereChq_reg_pay_code2,
					_whereChq_reg_pay_code3 = WhereChq_reg_pay_code3,
					_whereChq_reg_pay_code4 = WhereChq_reg_pay_code4,
					_whereChq_reg_pay_code5 = WhereChq_reg_pay_code5,
					_whereChq_reg_pay_code6 = WhereChq_reg_pay_code6,
					_whereChq_reg_pay_code7 = WhereChq_reg_pay_code7,
					_whereChq_reg_pay_code8 = WhereChq_reg_pay_code8,
					_whereChq_reg_pay_code9 = WhereChq_reg_pay_code9,
					_whereChq_reg_pay_code10 = WhereChq_reg_pay_code10,
					_whereChq_reg_pay_code11 = WhereChq_reg_pay_code11,
					_whereChq_reg_pay_code12 = WhereChq_reg_pay_code12,
					_whereChq_reg_pay_code13 = WhereChq_reg_pay_code13,
					_whereChq_reg_pay_code14 = WhereChq_reg_pay_code14,
					_whereChq_reg_pay_code15 = WhereChq_reg_pay_code15,
					_whereChq_reg_pay_code16 = WhereChq_reg_pay_code16,
					_whereChq_reg_pay_code17 = WhereChq_reg_pay_code17,
					_whereChq_reg_pay_code18 = WhereChq_reg_pay_code18,
					_whereChq_reg_perc_tax1 = WhereChq_reg_perc_tax1,
					_whereChq_reg_perc_tax2 = WhereChq_reg_perc_tax2,
					_whereChq_reg_perc_tax3 = WhereChq_reg_perc_tax3,
					_whereChq_reg_perc_tax4 = WhereChq_reg_perc_tax4,
					_whereChq_reg_perc_tax5 = WhereChq_reg_perc_tax5,
					_whereChq_reg_perc_tax6 = WhereChq_reg_perc_tax6,
					_whereChq_reg_perc_tax7 = WhereChq_reg_perc_tax7,
					_whereChq_reg_perc_tax8 = WhereChq_reg_perc_tax8,
					_whereChq_reg_perc_tax9 = WhereChq_reg_perc_tax9,
					_whereChq_reg_perc_tax10 = WhereChq_reg_perc_tax10,
					_whereChq_reg_perc_tax11 = WhereChq_reg_perc_tax11,
					_whereChq_reg_perc_tax12 = WhereChq_reg_perc_tax12,
					_whereChq_reg_perc_tax13 = WhereChq_reg_perc_tax13,
					_whereChq_reg_perc_tax14 = WhereChq_reg_perc_tax14,
					_whereChq_reg_perc_tax15 = WhereChq_reg_perc_tax15,
					_whereChq_reg_perc_tax16 = WhereChq_reg_perc_tax16,
					_whereChq_reg_perc_tax17 = WhereChq_reg_perc_tax17,
					_whereChq_reg_perc_tax18 = WhereChq_reg_perc_tax18,
					_whereChq_reg_mth_bill_amt1 = WhereChq_reg_mth_bill_amt1,
					_whereChq_reg_mth_bill_amt2 = WhereChq_reg_mth_bill_amt2,
					_whereChq_reg_mth_bill_amt3 = WhereChq_reg_mth_bill_amt3,
					_whereChq_reg_mth_bill_amt4 = WhereChq_reg_mth_bill_amt4,
					_whereChq_reg_mth_bill_amt5 = WhereChq_reg_mth_bill_amt5,
					_whereChq_reg_mth_bill_amt6 = WhereChq_reg_mth_bill_amt6,
					_whereChq_reg_mth_bill_amt7 = WhereChq_reg_mth_bill_amt7,
					_whereChq_reg_mth_bill_amt8 = WhereChq_reg_mth_bill_amt8,
					_whereChq_reg_mth_bill_amt9 = WhereChq_reg_mth_bill_amt9,
					_whereChq_reg_mth_bill_amt10 = WhereChq_reg_mth_bill_amt10,
					_whereChq_reg_mth_bill_amt11 = WhereChq_reg_mth_bill_amt11,
					_whereChq_reg_mth_bill_amt12 = WhereChq_reg_mth_bill_amt12,
					_whereChq_reg_mth_bill_amt13 = WhereChq_reg_mth_bill_amt13,
					_whereChq_reg_mth_bill_amt14 = WhereChq_reg_mth_bill_amt14,
					_whereChq_reg_mth_bill_amt15 = WhereChq_reg_mth_bill_amt15,
					_whereChq_reg_mth_bill_amt16 = WhereChq_reg_mth_bill_amt16,
					_whereChq_reg_mth_bill_amt17 = WhereChq_reg_mth_bill_amt17,
					_whereChq_reg_mth_bill_amt18 = WhereChq_reg_mth_bill_amt18,
					_whereChq_reg_mth_misc_amt_11 = WhereChq_reg_mth_misc_amt_11,
					_whereChq_reg_mth_misc_amt_12 = WhereChq_reg_mth_misc_amt_12,
					_whereChq_reg_mth_misc_amt_13 = WhereChq_reg_mth_misc_amt_13,
					_whereChq_reg_mth_misc_amt_14 = WhereChq_reg_mth_misc_amt_14,
					_whereChq_reg_mth_misc_amt_15 = WhereChq_reg_mth_misc_amt_15,
					_whereChq_reg_mth_misc_amt_16 = WhereChq_reg_mth_misc_amt_16,
					_whereChq_reg_mth_misc_amt_17 = WhereChq_reg_mth_misc_amt_17,
					_whereChq_reg_mth_misc_amt_18 = WhereChq_reg_mth_misc_amt_18,
					_whereChq_reg_mth_misc_amt_19 = WhereChq_reg_mth_misc_amt_19,
					_whereChq_reg_mth_misc_amt_110 = WhereChq_reg_mth_misc_amt_110,
					_whereChq_reg_mth_misc_amt_111 = WhereChq_reg_mth_misc_amt_111,
					_whereChq_reg_mth_misc_amt_112 = WhereChq_reg_mth_misc_amt_112,
					_whereChq_reg_mth_misc_amt_113 = WhereChq_reg_mth_misc_amt_113,
					_whereChq_reg_mth_misc_amt_114 = WhereChq_reg_mth_misc_amt_114,
					_whereChq_reg_mth_misc_amt_115 = WhereChq_reg_mth_misc_amt_115,
					_whereChq_reg_mth_misc_amt_116 = WhereChq_reg_mth_misc_amt_116,
					_whereChq_reg_mth_misc_amt_117 = WhereChq_reg_mth_misc_amt_117,
					_whereChq_reg_mth_misc_amt_118 = WhereChq_reg_mth_misc_amt_118,
					_whereChq_reg_mth_misc_amt_21 = WhereChq_reg_mth_misc_amt_21,
					_whereChq_reg_mth_misc_amt_22 = WhereChq_reg_mth_misc_amt_22,
					_whereChq_reg_mth_misc_amt_23 = WhereChq_reg_mth_misc_amt_23,
					_whereChq_reg_mth_misc_amt_24 = WhereChq_reg_mth_misc_amt_24,
					_whereChq_reg_mth_misc_amt_25 = WhereChq_reg_mth_misc_amt_25,
					_whereChq_reg_mth_misc_amt_26 = WhereChq_reg_mth_misc_amt_26,
					_whereChq_reg_mth_misc_amt_27 = WhereChq_reg_mth_misc_amt_27,
					_whereChq_reg_mth_misc_amt_28 = WhereChq_reg_mth_misc_amt_28,
					_whereChq_reg_mth_misc_amt_29 = WhereChq_reg_mth_misc_amt_29,
					_whereChq_reg_mth_misc_amt_210 = WhereChq_reg_mth_misc_amt_210,
					_whereChq_reg_mth_misc_amt_211 = WhereChq_reg_mth_misc_amt_211,
					_whereChq_reg_mth_misc_amt_212 = WhereChq_reg_mth_misc_amt_212,
					_whereChq_reg_mth_misc_amt_213 = WhereChq_reg_mth_misc_amt_213,
					_whereChq_reg_mth_misc_amt_214 = WhereChq_reg_mth_misc_amt_214,
					_whereChq_reg_mth_misc_amt_215 = WhereChq_reg_mth_misc_amt_215,
					_whereChq_reg_mth_misc_amt_216 = WhereChq_reg_mth_misc_amt_216,
					_whereChq_reg_mth_misc_amt_217 = WhereChq_reg_mth_misc_amt_217,
					_whereChq_reg_mth_misc_amt_218 = WhereChq_reg_mth_misc_amt_218,
					_whereChq_reg_mth_misc_amt_31 = WhereChq_reg_mth_misc_amt_31,
					_whereChq_reg_mth_misc_amt_32 = WhereChq_reg_mth_misc_amt_32,
					_whereChq_reg_mth_misc_amt_33 = WhereChq_reg_mth_misc_amt_33,
					_whereChq_reg_mth_misc_amt_34 = WhereChq_reg_mth_misc_amt_34,
					_whereChq_reg_mth_misc_amt_35 = WhereChq_reg_mth_misc_amt_35,
					_whereChq_reg_mth_misc_amt_36 = WhereChq_reg_mth_misc_amt_36,
					_whereChq_reg_mth_misc_amt_37 = WhereChq_reg_mth_misc_amt_37,
					_whereChq_reg_mth_misc_amt_38 = WhereChq_reg_mth_misc_amt_38,
					_whereChq_reg_mth_misc_amt_39 = WhereChq_reg_mth_misc_amt_39,
					_whereChq_reg_mth_misc_amt_310 = WhereChq_reg_mth_misc_amt_310,
					_whereChq_reg_mth_misc_amt_311 = WhereChq_reg_mth_misc_amt_311,
					_whereChq_reg_mth_misc_amt_312 = WhereChq_reg_mth_misc_amt_312,
					_whereChq_reg_mth_misc_amt_313 = WhereChq_reg_mth_misc_amt_313,
					_whereChq_reg_mth_misc_amt_314 = WhereChq_reg_mth_misc_amt_314,
					_whereChq_reg_mth_misc_amt_315 = WhereChq_reg_mth_misc_amt_315,
					_whereChq_reg_mth_misc_amt_316 = WhereChq_reg_mth_misc_amt_316,
					_whereChq_reg_mth_misc_amt_317 = WhereChq_reg_mth_misc_amt_317,
					_whereChq_reg_mth_misc_amt_318 = WhereChq_reg_mth_misc_amt_318,
					_whereChq_reg_mth_misc_amt_41 = WhereChq_reg_mth_misc_amt_41,
					_whereChq_reg_mth_misc_amt_42 = WhereChq_reg_mth_misc_amt_42,
					_whereChq_reg_mth_misc_amt_43 = WhereChq_reg_mth_misc_amt_43,
					_whereChq_reg_mth_misc_amt_44 = WhereChq_reg_mth_misc_amt_44,
					_whereChq_reg_mth_misc_amt_45 = WhereChq_reg_mth_misc_amt_45,
					_whereChq_reg_mth_misc_amt_46 = WhereChq_reg_mth_misc_amt_46,
					_whereChq_reg_mth_misc_amt_47 = WhereChq_reg_mth_misc_amt_47,
					_whereChq_reg_mth_misc_amt_48 = WhereChq_reg_mth_misc_amt_48,
					_whereChq_reg_mth_misc_amt_49 = WhereChq_reg_mth_misc_amt_49,
					_whereChq_reg_mth_misc_amt_410 = WhereChq_reg_mth_misc_amt_410,
					_whereChq_reg_mth_misc_amt_411 = WhereChq_reg_mth_misc_amt_411,
					_whereChq_reg_mth_misc_amt_412 = WhereChq_reg_mth_misc_amt_412,
					_whereChq_reg_mth_misc_amt_413 = WhereChq_reg_mth_misc_amt_413,
					_whereChq_reg_mth_misc_amt_414 = WhereChq_reg_mth_misc_amt_414,
					_whereChq_reg_mth_misc_amt_415 = WhereChq_reg_mth_misc_amt_415,
					_whereChq_reg_mth_misc_amt_416 = WhereChq_reg_mth_misc_amt_416,
					_whereChq_reg_mth_misc_amt_417 = WhereChq_reg_mth_misc_amt_417,
					_whereChq_reg_mth_misc_amt_418 = WhereChq_reg_mth_misc_amt_418,
					_whereChq_reg_mth_misc_amt_51 = WhereChq_reg_mth_misc_amt_51,
					_whereChq_reg_mth_misc_amt_52 = WhereChq_reg_mth_misc_amt_52,
					_whereChq_reg_mth_misc_amt_53 = WhereChq_reg_mth_misc_amt_53,
					_whereChq_reg_mth_misc_amt_54 = WhereChq_reg_mth_misc_amt_54,
					_whereChq_reg_mth_misc_amt_55 = WhereChq_reg_mth_misc_amt_55,
					_whereChq_reg_mth_misc_amt_56 = WhereChq_reg_mth_misc_amt_56,
					_whereChq_reg_mth_misc_amt_57 = WhereChq_reg_mth_misc_amt_57,
					_whereChq_reg_mth_misc_amt_58 = WhereChq_reg_mth_misc_amt_58,
					_whereChq_reg_mth_misc_amt_59 = WhereChq_reg_mth_misc_amt_59,
					_whereChq_reg_mth_misc_amt_510 = WhereChq_reg_mth_misc_amt_510,
					_whereChq_reg_mth_misc_amt_511 = WhereChq_reg_mth_misc_amt_511,
					_whereChq_reg_mth_misc_amt_512 = WhereChq_reg_mth_misc_amt_512,
					_whereChq_reg_mth_misc_amt_513 = WhereChq_reg_mth_misc_amt_513,
					_whereChq_reg_mth_misc_amt_514 = WhereChq_reg_mth_misc_amt_514,
					_whereChq_reg_mth_misc_amt_515 = WhereChq_reg_mth_misc_amt_515,
					_whereChq_reg_mth_misc_amt_516 = WhereChq_reg_mth_misc_amt_516,
					_whereChq_reg_mth_misc_amt_517 = WhereChq_reg_mth_misc_amt_517,
					_whereChq_reg_mth_misc_amt_518 = WhereChq_reg_mth_misc_amt_518,
					_whereChq_reg_mth_misc_amt_61 = WhereChq_reg_mth_misc_amt_61,
					_whereChq_reg_mth_misc_amt_62 = WhereChq_reg_mth_misc_amt_62,
					_whereChq_reg_mth_misc_amt_63 = WhereChq_reg_mth_misc_amt_63,
					_whereChq_reg_mth_misc_amt_64 = WhereChq_reg_mth_misc_amt_64,
					_whereChq_reg_mth_misc_amt_65 = WhereChq_reg_mth_misc_amt_65,
					_whereChq_reg_mth_misc_amt_66 = WhereChq_reg_mth_misc_amt_66,
					_whereChq_reg_mth_misc_amt_67 = WhereChq_reg_mth_misc_amt_67,
					_whereChq_reg_mth_misc_amt_68 = WhereChq_reg_mth_misc_amt_68,
					_whereChq_reg_mth_misc_amt_69 = WhereChq_reg_mth_misc_amt_69,
					_whereChq_reg_mth_misc_amt_610 = WhereChq_reg_mth_misc_amt_610,
					_whereChq_reg_mth_misc_amt_611 = WhereChq_reg_mth_misc_amt_611,
					_whereChq_reg_mth_misc_amt_612 = WhereChq_reg_mth_misc_amt_612,
					_whereChq_reg_mth_misc_amt_613 = WhereChq_reg_mth_misc_amt_613,
					_whereChq_reg_mth_misc_amt_614 = WhereChq_reg_mth_misc_amt_614,
					_whereChq_reg_mth_misc_amt_615 = WhereChq_reg_mth_misc_amt_615,
					_whereChq_reg_mth_misc_amt_616 = WhereChq_reg_mth_misc_amt_616,
					_whereChq_reg_mth_misc_amt_617 = WhereChq_reg_mth_misc_amt_617,
					_whereChq_reg_mth_misc_amt_618 = WhereChq_reg_mth_misc_amt_618,
					_whereChq_reg_mth_misc_amt_71 = WhereChq_reg_mth_misc_amt_71,
					_whereChq_reg_mth_misc_amt_72 = WhereChq_reg_mth_misc_amt_72,
					_whereChq_reg_mth_misc_amt_73 = WhereChq_reg_mth_misc_amt_73,
					_whereChq_reg_mth_misc_amt_74 = WhereChq_reg_mth_misc_amt_74,
					_whereChq_reg_mth_misc_amt_75 = WhereChq_reg_mth_misc_amt_75,
					_whereChq_reg_mth_misc_amt_76 = WhereChq_reg_mth_misc_amt_76,
					_whereChq_reg_mth_misc_amt_77 = WhereChq_reg_mth_misc_amt_77,
					_whereChq_reg_mth_misc_amt_78 = WhereChq_reg_mth_misc_amt_78,
					_whereChq_reg_mth_misc_amt_79 = WhereChq_reg_mth_misc_amt_79,
					_whereChq_reg_mth_misc_amt_710 = WhereChq_reg_mth_misc_amt_710,
					_whereChq_reg_mth_misc_amt_711 = WhereChq_reg_mth_misc_amt_711,
					_whereChq_reg_mth_misc_amt_712 = WhereChq_reg_mth_misc_amt_712,
					_whereChq_reg_mth_misc_amt_713 = WhereChq_reg_mth_misc_amt_713,
					_whereChq_reg_mth_misc_amt_714 = WhereChq_reg_mth_misc_amt_714,
					_whereChq_reg_mth_misc_amt_715 = WhereChq_reg_mth_misc_amt_715,
					_whereChq_reg_mth_misc_amt_716 = WhereChq_reg_mth_misc_amt_716,
					_whereChq_reg_mth_misc_amt_717 = WhereChq_reg_mth_misc_amt_717,
					_whereChq_reg_mth_misc_amt_718 = WhereChq_reg_mth_misc_amt_718,
					_whereChq_reg_mth_misc_amt_81 = WhereChq_reg_mth_misc_amt_81,
					_whereChq_reg_mth_misc_amt_82 = WhereChq_reg_mth_misc_amt_82,
					_whereChq_reg_mth_misc_amt_83 = WhereChq_reg_mth_misc_amt_83,
					_whereChq_reg_mth_misc_amt_84 = WhereChq_reg_mth_misc_amt_84,
					_whereChq_reg_mth_misc_amt_85 = WhereChq_reg_mth_misc_amt_85,
					_whereChq_reg_mth_misc_amt_86 = WhereChq_reg_mth_misc_amt_86,
					_whereChq_reg_mth_misc_amt_87 = WhereChq_reg_mth_misc_amt_87,
					_whereChq_reg_mth_misc_amt_88 = WhereChq_reg_mth_misc_amt_88,
					_whereChq_reg_mth_misc_amt_89 = WhereChq_reg_mth_misc_amt_89,
					_whereChq_reg_mth_misc_amt_810 = WhereChq_reg_mth_misc_amt_810,
					_whereChq_reg_mth_misc_amt_811 = WhereChq_reg_mth_misc_amt_811,
					_whereChq_reg_mth_misc_amt_812 = WhereChq_reg_mth_misc_amt_812,
					_whereChq_reg_mth_misc_amt_813 = WhereChq_reg_mth_misc_amt_813,
					_whereChq_reg_mth_misc_amt_814 = WhereChq_reg_mth_misc_amt_814,
					_whereChq_reg_mth_misc_amt_815 = WhereChq_reg_mth_misc_amt_815,
					_whereChq_reg_mth_misc_amt_816 = WhereChq_reg_mth_misc_amt_816,
					_whereChq_reg_mth_misc_amt_817 = WhereChq_reg_mth_misc_amt_817,
					_whereChq_reg_mth_misc_amt_818 = WhereChq_reg_mth_misc_amt_818,
					_whereChq_reg_mth_misc_amt_91 = WhereChq_reg_mth_misc_amt_91,
					_whereChq_reg_mth_misc_amt_92 = WhereChq_reg_mth_misc_amt_92,
					_whereChq_reg_mth_misc_amt_93 = WhereChq_reg_mth_misc_amt_93,
					_whereChq_reg_mth_misc_amt_94 = WhereChq_reg_mth_misc_amt_94,
					_whereChq_reg_mth_misc_amt_95 = WhereChq_reg_mth_misc_amt_95,
					_whereChq_reg_mth_misc_amt_96 = WhereChq_reg_mth_misc_amt_96,
					_whereChq_reg_mth_misc_amt_97 = WhereChq_reg_mth_misc_amt_97,
					_whereChq_reg_mth_misc_amt_98 = WhereChq_reg_mth_misc_amt_98,
					_whereChq_reg_mth_misc_amt_99 = WhereChq_reg_mth_misc_amt_99,
					_whereChq_reg_mth_misc_amt_910 = WhereChq_reg_mth_misc_amt_910,
					_whereChq_reg_mth_misc_amt_911 = WhereChq_reg_mth_misc_amt_911,
					_whereChq_reg_mth_misc_amt_912 = WhereChq_reg_mth_misc_amt_912,
					_whereChq_reg_mth_misc_amt_913 = WhereChq_reg_mth_misc_amt_913,
					_whereChq_reg_mth_misc_amt_914 = WhereChq_reg_mth_misc_amt_914,
					_whereChq_reg_mth_misc_amt_915 = WhereChq_reg_mth_misc_amt_915,
					_whereChq_reg_mth_misc_amt_916 = WhereChq_reg_mth_misc_amt_916,
					_whereChq_reg_mth_misc_amt_917 = WhereChq_reg_mth_misc_amt_917,
					_whereChq_reg_mth_misc_amt_918 = WhereChq_reg_mth_misc_amt_918,
					_whereChq_reg_mth_misc_amt_101 = WhereChq_reg_mth_misc_amt_101,
					_whereChq_reg_mth_misc_amt_102 = WhereChq_reg_mth_misc_amt_102,
					_whereChq_reg_mth_misc_amt_103 = WhereChq_reg_mth_misc_amt_103,
					_whereChq_reg_mth_misc_amt_104 = WhereChq_reg_mth_misc_amt_104,
					_whereChq_reg_mth_misc_amt_105 = WhereChq_reg_mth_misc_amt_105,
					_whereChq_reg_mth_misc_amt_106 = WhereChq_reg_mth_misc_amt_106,
					_whereChq_reg_mth_misc_amt_107 = WhereChq_reg_mth_misc_amt_107,
					_whereChq_reg_mth_misc_amt_108 = WhereChq_reg_mth_misc_amt_108,
					_whereChq_reg_mth_misc_amt_109 = WhereChq_reg_mth_misc_amt_109,
					_whereChq_reg_mth_misc_amt_1010 = WhereChq_reg_mth_misc_amt_1010,
					_whereChq_reg_mth_misc_amt_1011 = WhereChq_reg_mth_misc_amt_1011,
					_whereChq_reg_mth_misc_amt_1012 = WhereChq_reg_mth_misc_amt_1012,
					_whereChq_reg_mth_misc_amt_1013 = WhereChq_reg_mth_misc_amt_1013,
					_whereChq_reg_mth_misc_amt_1014 = WhereChq_reg_mth_misc_amt_1014,
					_whereChq_reg_mth_misc_amt_1015 = WhereChq_reg_mth_misc_amt_1015,
					_whereChq_reg_mth_misc_amt_1016 = WhereChq_reg_mth_misc_amt_1016,
					_whereChq_reg_mth_misc_amt_1017 = WhereChq_reg_mth_misc_amt_1017,
					_whereChq_reg_mth_misc_amt_1018 = WhereChq_reg_mth_misc_amt_1018,
					_whereChq_reg_mth_exp_amt1 = WhereChq_reg_mth_exp_amt1,
					_whereChq_reg_mth_exp_amt2 = WhereChq_reg_mth_exp_amt2,
					_whereChq_reg_mth_exp_amt3 = WhereChq_reg_mth_exp_amt3,
					_whereChq_reg_mth_exp_amt4 = WhereChq_reg_mth_exp_amt4,
					_whereChq_reg_mth_exp_amt5 = WhereChq_reg_mth_exp_amt5,
					_whereChq_reg_mth_exp_amt6 = WhereChq_reg_mth_exp_amt6,
					_whereChq_reg_mth_exp_amt7 = WhereChq_reg_mth_exp_amt7,
					_whereChq_reg_mth_exp_amt8 = WhereChq_reg_mth_exp_amt8,
					_whereChq_reg_mth_exp_amt9 = WhereChq_reg_mth_exp_amt9,
					_whereChq_reg_mth_exp_amt10 = WhereChq_reg_mth_exp_amt10,
					_whereChq_reg_mth_exp_amt11 = WhereChq_reg_mth_exp_amt11,
					_whereChq_reg_mth_exp_amt12 = WhereChq_reg_mth_exp_amt12,
					_whereChq_reg_mth_exp_amt13 = WhereChq_reg_mth_exp_amt13,
					_whereChq_reg_mth_exp_amt14 = WhereChq_reg_mth_exp_amt14,
					_whereChq_reg_mth_exp_amt15 = WhereChq_reg_mth_exp_amt15,
					_whereChq_reg_mth_exp_amt16 = WhereChq_reg_mth_exp_amt16,
					_whereChq_reg_mth_exp_amt17 = WhereChq_reg_mth_exp_amt17,
					_whereChq_reg_mth_exp_amt18 = WhereChq_reg_mth_exp_amt18,
					_whereChq_reg_comp_ann_exp_this_pay1 = WhereChq_reg_comp_ann_exp_this_pay1,
					_whereChq_reg_comp_ann_exp_this_pay2 = WhereChq_reg_comp_ann_exp_this_pay2,
					_whereChq_reg_comp_ann_exp_this_pay3 = WhereChq_reg_comp_ann_exp_this_pay3,
					_whereChq_reg_comp_ann_exp_this_pay4 = WhereChq_reg_comp_ann_exp_this_pay4,
					_whereChq_reg_comp_ann_exp_this_pay5 = WhereChq_reg_comp_ann_exp_this_pay5,
					_whereChq_reg_comp_ann_exp_this_pay6 = WhereChq_reg_comp_ann_exp_this_pay6,
					_whereChq_reg_comp_ann_exp_this_pay7 = WhereChq_reg_comp_ann_exp_this_pay7,
					_whereChq_reg_comp_ann_exp_this_pay8 = WhereChq_reg_comp_ann_exp_this_pay8,
					_whereChq_reg_comp_ann_exp_this_pay9 = WhereChq_reg_comp_ann_exp_this_pay9,
					_whereChq_reg_comp_ann_exp_this_pay10 = WhereChq_reg_comp_ann_exp_this_pay10,
					_whereChq_reg_comp_ann_exp_this_pay11 = WhereChq_reg_comp_ann_exp_this_pay11,
					_whereChq_reg_comp_ann_exp_this_pay12 = WhereChq_reg_comp_ann_exp_this_pay12,
					_whereChq_reg_comp_ann_exp_this_pay13 = WhereChq_reg_comp_ann_exp_this_pay13,
					_whereChq_reg_comp_ann_exp_this_pay14 = WhereChq_reg_comp_ann_exp_this_pay14,
					_whereChq_reg_comp_ann_exp_this_pay15 = WhereChq_reg_comp_ann_exp_this_pay15,
					_whereChq_reg_comp_ann_exp_this_pay16 = WhereChq_reg_comp_ann_exp_this_pay16,
					_whereChq_reg_comp_ann_exp_this_pay17 = WhereChq_reg_comp_ann_exp_this_pay17,
					_whereChq_reg_comp_ann_exp_this_pay18 = WhereChq_reg_comp_ann_exp_this_pay18,
					_whereChq_reg_mth_ceil_amt1 = WhereChq_reg_mth_ceil_amt1,
					_whereChq_reg_mth_ceil_amt2 = WhereChq_reg_mth_ceil_amt2,
					_whereChq_reg_mth_ceil_amt3 = WhereChq_reg_mth_ceil_amt3,
					_whereChq_reg_mth_ceil_amt4 = WhereChq_reg_mth_ceil_amt4,
					_whereChq_reg_mth_ceil_amt5 = WhereChq_reg_mth_ceil_amt5,
					_whereChq_reg_mth_ceil_amt6 = WhereChq_reg_mth_ceil_amt6,
					_whereChq_reg_mth_ceil_amt7 = WhereChq_reg_mth_ceil_amt7,
					_whereChq_reg_mth_ceil_amt8 = WhereChq_reg_mth_ceil_amt8,
					_whereChq_reg_mth_ceil_amt9 = WhereChq_reg_mth_ceil_amt9,
					_whereChq_reg_mth_ceil_amt10 = WhereChq_reg_mth_ceil_amt10,
					_whereChq_reg_mth_ceil_amt11 = WhereChq_reg_mth_ceil_amt11,
					_whereChq_reg_mth_ceil_amt12 = WhereChq_reg_mth_ceil_amt12,
					_whereChq_reg_mth_ceil_amt13 = WhereChq_reg_mth_ceil_amt13,
					_whereChq_reg_mth_ceil_amt14 = WhereChq_reg_mth_ceil_amt14,
					_whereChq_reg_mth_ceil_amt15 = WhereChq_reg_mth_ceil_amt15,
					_whereChq_reg_mth_ceil_amt16 = WhereChq_reg_mth_ceil_amt16,
					_whereChq_reg_mth_ceil_amt17 = WhereChq_reg_mth_ceil_amt17,
					_whereChq_reg_mth_ceil_amt18 = WhereChq_reg_mth_ceil_amt18,
					_whereChq_reg_comp_ann_ceil_this_pay1 = WhereChq_reg_comp_ann_ceil_this_pay1,
					_whereChq_reg_comp_ann_ceil_this_pay2 = WhereChq_reg_comp_ann_ceil_this_pay2,
					_whereChq_reg_comp_ann_ceil_this_pay3 = WhereChq_reg_comp_ann_ceil_this_pay3,
					_whereChq_reg_comp_ann_ceil_this_pay4 = WhereChq_reg_comp_ann_ceil_this_pay4,
					_whereChq_reg_comp_ann_ceil_this_pay5 = WhereChq_reg_comp_ann_ceil_this_pay5,
					_whereChq_reg_comp_ann_ceil_this_pay6 = WhereChq_reg_comp_ann_ceil_this_pay6,
					_whereChq_reg_comp_ann_ceil_this_pay7 = WhereChq_reg_comp_ann_ceil_this_pay7,
					_whereChq_reg_comp_ann_ceil_this_pay8 = WhereChq_reg_comp_ann_ceil_this_pay8,
					_whereChq_reg_comp_ann_ceil_this_pay9 = WhereChq_reg_comp_ann_ceil_this_pay9,
					_whereChq_reg_comp_ann_ceil_this_pay10 = WhereChq_reg_comp_ann_ceil_this_pay10,
					_whereChq_reg_comp_ann_ceil_this_pay11 = WhereChq_reg_comp_ann_ceil_this_pay11,
					_whereChq_reg_comp_ann_ceil_this_pay12 = WhereChq_reg_comp_ann_ceil_this_pay12,
					_whereChq_reg_comp_ann_ceil_this_pay13 = WhereChq_reg_comp_ann_ceil_this_pay13,
					_whereChq_reg_comp_ann_ceil_this_pay14 = WhereChq_reg_comp_ann_ceil_this_pay14,
					_whereChq_reg_comp_ann_ceil_this_pay15 = WhereChq_reg_comp_ann_ceil_this_pay15,
					_whereChq_reg_comp_ann_ceil_this_pay16 = WhereChq_reg_comp_ann_ceil_this_pay16,
					_whereChq_reg_comp_ann_ceil_this_pay17 = WhereChq_reg_comp_ann_ceil_this_pay17,
					_whereChq_reg_comp_ann_ceil_this_pay18 = WhereChq_reg_comp_ann_ceil_this_pay18,
					_whereChq_reg_earnings_this_mth1 = WhereChq_reg_earnings_this_mth1,
					_whereChq_reg_earnings_this_mth2 = WhereChq_reg_earnings_this_mth2,
					_whereChq_reg_earnings_this_mth3 = WhereChq_reg_earnings_this_mth3,
					_whereChq_reg_earnings_this_mth4 = WhereChq_reg_earnings_this_mth4,
					_whereChq_reg_earnings_this_mth5 = WhereChq_reg_earnings_this_mth5,
					_whereChq_reg_earnings_this_mth6 = WhereChq_reg_earnings_this_mth6,
					_whereChq_reg_earnings_this_mth7 = WhereChq_reg_earnings_this_mth7,
					_whereChq_reg_earnings_this_mth8 = WhereChq_reg_earnings_this_mth8,
					_whereChq_reg_earnings_this_mth9 = WhereChq_reg_earnings_this_mth9,
					_whereChq_reg_earnings_this_mth10 = WhereChq_reg_earnings_this_mth10,
					_whereChq_reg_earnings_this_mth11 = WhereChq_reg_earnings_this_mth11,
					_whereChq_reg_earnings_this_mth12 = WhereChq_reg_earnings_this_mth12,
					_whereChq_reg_earnings_this_mth13 = WhereChq_reg_earnings_this_mth13,
					_whereChq_reg_earnings_this_mth14 = WhereChq_reg_earnings_this_mth14,
					_whereChq_reg_earnings_this_mth15 = WhereChq_reg_earnings_this_mth15,
					_whereChq_reg_earnings_this_mth16 = WhereChq_reg_earnings_this_mth16,
					_whereChq_reg_earnings_this_mth17 = WhereChq_reg_earnings_this_mth17,
					_whereChq_reg_earnings_this_mth18 = WhereChq_reg_earnings_this_mth18,
					_whereChq_reg_regular_pay_this_mth1 = WhereChq_reg_regular_pay_this_mth1,
					_whereChq_reg_regular_pay_this_mth2 = WhereChq_reg_regular_pay_this_mth2,
					_whereChq_reg_regular_pay_this_mth3 = WhereChq_reg_regular_pay_this_mth3,
					_whereChq_reg_regular_pay_this_mth4 = WhereChq_reg_regular_pay_this_mth4,
					_whereChq_reg_regular_pay_this_mth5 = WhereChq_reg_regular_pay_this_mth5,
					_whereChq_reg_regular_pay_this_mth6 = WhereChq_reg_regular_pay_this_mth6,
					_whereChq_reg_regular_pay_this_mth7 = WhereChq_reg_regular_pay_this_mth7,
					_whereChq_reg_regular_pay_this_mth8 = WhereChq_reg_regular_pay_this_mth8,
					_whereChq_reg_regular_pay_this_mth9 = WhereChq_reg_regular_pay_this_mth9,
					_whereChq_reg_regular_pay_this_mth10 = WhereChq_reg_regular_pay_this_mth10,
					_whereChq_reg_regular_pay_this_mth11 = WhereChq_reg_regular_pay_this_mth11,
					_whereChq_reg_regular_pay_this_mth12 = WhereChq_reg_regular_pay_this_mth12,
					_whereChq_reg_regular_pay_this_mth13 = WhereChq_reg_regular_pay_this_mth13,
					_whereChq_reg_regular_pay_this_mth14 = WhereChq_reg_regular_pay_this_mth14,
					_whereChq_reg_regular_pay_this_mth15 = WhereChq_reg_regular_pay_this_mth15,
					_whereChq_reg_regular_pay_this_mth16 = WhereChq_reg_regular_pay_this_mth16,
					_whereChq_reg_regular_pay_this_mth17 = WhereChq_reg_regular_pay_this_mth17,
					_whereChq_reg_regular_pay_this_mth18 = WhereChq_reg_regular_pay_this_mth18,
					_whereChq_reg_regular_tax_this_mth1 = WhereChq_reg_regular_tax_this_mth1,
					_whereChq_reg_regular_tax_this_mth2 = WhereChq_reg_regular_tax_this_mth2,
					_whereChq_reg_regular_tax_this_mth3 = WhereChq_reg_regular_tax_this_mth3,
					_whereChq_reg_regular_tax_this_mth4 = WhereChq_reg_regular_tax_this_mth4,
					_whereChq_reg_regular_tax_this_mth5 = WhereChq_reg_regular_tax_this_mth5,
					_whereChq_reg_regular_tax_this_mth6 = WhereChq_reg_regular_tax_this_mth6,
					_whereChq_reg_regular_tax_this_mth7 = WhereChq_reg_regular_tax_this_mth7,
					_whereChq_reg_regular_tax_this_mth8 = WhereChq_reg_regular_tax_this_mth8,
					_whereChq_reg_regular_tax_this_mth9 = WhereChq_reg_regular_tax_this_mth9,
					_whereChq_reg_regular_tax_this_mth10 = WhereChq_reg_regular_tax_this_mth10,
					_whereChq_reg_regular_tax_this_mth11 = WhereChq_reg_regular_tax_this_mth11,
					_whereChq_reg_regular_tax_this_mth12 = WhereChq_reg_regular_tax_this_mth12,
					_whereChq_reg_regular_tax_this_mth13 = WhereChq_reg_regular_tax_this_mth13,
					_whereChq_reg_regular_tax_this_mth14 = WhereChq_reg_regular_tax_this_mth14,
					_whereChq_reg_regular_tax_this_mth15 = WhereChq_reg_regular_tax_this_mth15,
					_whereChq_reg_regular_tax_this_mth16 = WhereChq_reg_regular_tax_this_mth16,
					_whereChq_reg_regular_tax_this_mth17 = WhereChq_reg_regular_tax_this_mth17,
					_whereChq_reg_regular_tax_this_mth18 = WhereChq_reg_regular_tax_this_mth18,
					_whereChq_reg_man_pay_this_mth1 = WhereChq_reg_man_pay_this_mth1,
					_whereChq_reg_man_pay_this_mth2 = WhereChq_reg_man_pay_this_mth2,
					_whereChq_reg_man_pay_this_mth3 = WhereChq_reg_man_pay_this_mth3,
					_whereChq_reg_man_pay_this_mth4 = WhereChq_reg_man_pay_this_mth4,
					_whereChq_reg_man_pay_this_mth5 = WhereChq_reg_man_pay_this_mth5,
					_whereChq_reg_man_pay_this_mth6 = WhereChq_reg_man_pay_this_mth6,
					_whereChq_reg_man_pay_this_mth7 = WhereChq_reg_man_pay_this_mth7,
					_whereChq_reg_man_pay_this_mth8 = WhereChq_reg_man_pay_this_mth8,
					_whereChq_reg_man_pay_this_mth9 = WhereChq_reg_man_pay_this_mth9,
					_whereChq_reg_man_pay_this_mth10 = WhereChq_reg_man_pay_this_mth10,
					_whereChq_reg_man_pay_this_mth11 = WhereChq_reg_man_pay_this_mth11,
					_whereChq_reg_man_pay_this_mth12 = WhereChq_reg_man_pay_this_mth12,
					_whereChq_reg_man_pay_this_mth13 = WhereChq_reg_man_pay_this_mth13,
					_whereChq_reg_man_pay_this_mth14 = WhereChq_reg_man_pay_this_mth14,
					_whereChq_reg_man_pay_this_mth15 = WhereChq_reg_man_pay_this_mth15,
					_whereChq_reg_man_pay_this_mth16 = WhereChq_reg_man_pay_this_mth16,
					_whereChq_reg_man_pay_this_mth17 = WhereChq_reg_man_pay_this_mth17,
					_whereChq_reg_man_pay_this_mth18 = WhereChq_reg_man_pay_this_mth18,
					_whereChq_reg_man_tax_this_mth1 = WhereChq_reg_man_tax_this_mth1,
					_whereChq_reg_man_tax_this_mth2 = WhereChq_reg_man_tax_this_mth2,
					_whereChq_reg_man_tax_this_mth3 = WhereChq_reg_man_tax_this_mth3,
					_whereChq_reg_man_tax_this_mth4 = WhereChq_reg_man_tax_this_mth4,
					_whereChq_reg_man_tax_this_mth5 = WhereChq_reg_man_tax_this_mth5,
					_whereChq_reg_man_tax_this_mth6 = WhereChq_reg_man_tax_this_mth6,
					_whereChq_reg_man_tax_this_mth7 = WhereChq_reg_man_tax_this_mth7,
					_whereChq_reg_man_tax_this_mth8 = WhereChq_reg_man_tax_this_mth8,
					_whereChq_reg_man_tax_this_mth9 = WhereChq_reg_man_tax_this_mth9,
					_whereChq_reg_man_tax_this_mth10 = WhereChq_reg_man_tax_this_mth10,
					_whereChq_reg_man_tax_this_mth11 = WhereChq_reg_man_tax_this_mth11,
					_whereChq_reg_man_tax_this_mth12 = WhereChq_reg_man_tax_this_mth12,
					_whereChq_reg_man_tax_this_mth13 = WhereChq_reg_man_tax_this_mth13,
					_whereChq_reg_man_tax_this_mth14 = WhereChq_reg_man_tax_this_mth14,
					_whereChq_reg_man_tax_this_mth15 = WhereChq_reg_man_tax_this_mth15,
					_whereChq_reg_man_tax_this_mth16 = WhereChq_reg_man_tax_this_mth16,
					_whereChq_reg_man_tax_this_mth17 = WhereChq_reg_man_tax_this_mth17,
					_whereChq_reg_man_tax_this_mth18 = WhereChq_reg_man_tax_this_mth18,
					_whereChq_reg_pay_date1 = WhereChq_reg_pay_date1,
					_whereChq_reg_pay_date2 = WhereChq_reg_pay_date2,
					_whereChq_reg_pay_date3 = WhereChq_reg_pay_date3,
					_whereChq_reg_pay_date4 = WhereChq_reg_pay_date4,
					_whereChq_reg_pay_date5 = WhereChq_reg_pay_date5,
					_whereChq_reg_pay_date6 = WhereChq_reg_pay_date6,
					_whereChq_reg_pay_date7 = WhereChq_reg_pay_date7,
					_whereChq_reg_pay_date8 = WhereChq_reg_pay_date8,
					_whereChq_reg_pay_date9 = WhereChq_reg_pay_date9,
					_whereChq_reg_pay_date10 = WhereChq_reg_pay_date10,
					_whereChq_reg_pay_date11 = WhereChq_reg_pay_date11,
					_whereChq_reg_pay_date12 = WhereChq_reg_pay_date12,
					_whereChq_reg_pay_date13 = WhereChq_reg_pay_date13,
					_whereChq_reg_pay_date14 = WhereChq_reg_pay_date14,
					_whereChq_reg_pay_date15 = WhereChq_reg_pay_date15,
					_whereChq_reg_pay_date16 = WhereChq_reg_pay_date16,
					_whereChq_reg_pay_date17 = WhereChq_reg_pay_date17,
					_whereChq_reg_pay_date18 = WhereChq_reg_pay_date18,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalChq_reg_clinic_nbr_1_2 = ConvertDEC(Reader["CHQ_REG_CLINIC_NBR_1_2"]),
					_originalChq_reg_dept = ConvertDEC(Reader["CHQ_REG_DEPT"]),
					_originalChq_reg_doc_nbr = Reader["CHQ_REG_DOC_NBR"].ToString(),
					_originalChq_reg_perc_bill1 = ConvertDEC(Reader["CHQ_REG_PERC_BILL1"]),
					_originalChq_reg_perc_bill2 = ConvertDEC(Reader["CHQ_REG_PERC_BILL2"]),
					_originalChq_reg_perc_bill3 = ConvertDEC(Reader["CHQ_REG_PERC_BILL3"]),
					_originalChq_reg_perc_bill4 = ConvertDEC(Reader["CHQ_REG_PERC_BILL4"]),
					_originalChq_reg_perc_bill5 = ConvertDEC(Reader["CHQ_REG_PERC_BILL5"]),
					_originalChq_reg_perc_bill6 = ConvertDEC(Reader["CHQ_REG_PERC_BILL6"]),
					_originalChq_reg_perc_bill7 = ConvertDEC(Reader["CHQ_REG_PERC_BILL7"]),
					_originalChq_reg_perc_bill8 = ConvertDEC(Reader["CHQ_REG_PERC_BILL8"]),
					_originalChq_reg_perc_bill9 = ConvertDEC(Reader["CHQ_REG_PERC_BILL9"]),
					_originalChq_reg_perc_bill10 = ConvertDEC(Reader["CHQ_REG_PERC_BILL10"]),
					_originalChq_reg_perc_bill11 = ConvertDEC(Reader["CHQ_REG_PERC_BILL11"]),
					_originalChq_reg_perc_bill12 = ConvertDEC(Reader["CHQ_REG_PERC_BILL12"]),
					_originalChq_reg_perc_bill13 = ConvertDEC(Reader["CHQ_REG_PERC_BILL13"]),
					_originalChq_reg_perc_bill14 = ConvertDEC(Reader["CHQ_REG_PERC_BILL14"]),
					_originalChq_reg_perc_bill15 = ConvertDEC(Reader["CHQ_REG_PERC_BILL15"]),
					_originalChq_reg_perc_bill16 = ConvertDEC(Reader["CHQ_REG_PERC_BILL16"]),
					_originalChq_reg_perc_bill17 = ConvertDEC(Reader["CHQ_REG_PERC_BILL17"]),
					_originalChq_reg_perc_bill18 = ConvertDEC(Reader["CHQ_REG_PERC_BILL18"]),
					_originalChq_reg_perc_misc1 = ConvertDEC(Reader["CHQ_REG_PERC_MISC1"]),
					_originalChq_reg_perc_misc2 = ConvertDEC(Reader["CHQ_REG_PERC_MISC2"]),
					_originalChq_reg_perc_misc3 = ConvertDEC(Reader["CHQ_REG_PERC_MISC3"]),
					_originalChq_reg_perc_misc4 = ConvertDEC(Reader["CHQ_REG_PERC_MISC4"]),
					_originalChq_reg_perc_misc5 = ConvertDEC(Reader["CHQ_REG_PERC_MISC5"]),
					_originalChq_reg_perc_misc6 = ConvertDEC(Reader["CHQ_REG_PERC_MISC6"]),
					_originalChq_reg_perc_misc7 = ConvertDEC(Reader["CHQ_REG_PERC_MISC7"]),
					_originalChq_reg_perc_misc8 = ConvertDEC(Reader["CHQ_REG_PERC_MISC8"]),
					_originalChq_reg_perc_misc9 = ConvertDEC(Reader["CHQ_REG_PERC_MISC9"]),
					_originalChq_reg_perc_misc10 = ConvertDEC(Reader["CHQ_REG_PERC_MISC10"]),
					_originalChq_reg_perc_misc11 = ConvertDEC(Reader["CHQ_REG_PERC_MISC11"]),
					_originalChq_reg_perc_misc12 = ConvertDEC(Reader["CHQ_REG_PERC_MISC12"]),
					_originalChq_reg_perc_misc13 = ConvertDEC(Reader["CHQ_REG_PERC_MISC13"]),
					_originalChq_reg_perc_misc14 = ConvertDEC(Reader["CHQ_REG_PERC_MISC14"]),
					_originalChq_reg_perc_misc15 = ConvertDEC(Reader["CHQ_REG_PERC_MISC15"]),
					_originalChq_reg_perc_misc16 = ConvertDEC(Reader["CHQ_REG_PERC_MISC16"]),
					_originalChq_reg_perc_misc17 = ConvertDEC(Reader["CHQ_REG_PERC_MISC17"]),
					_originalChq_reg_perc_misc18 = ConvertDEC(Reader["CHQ_REG_PERC_MISC18"]),
					_originalChq_reg_pay_code1 = Reader["CHQ_REG_PAY_CODE1"].ToString(),
					_originalChq_reg_pay_code2 = Reader["CHQ_REG_PAY_CODE2"].ToString(),
					_originalChq_reg_pay_code3 = Reader["CHQ_REG_PAY_CODE3"].ToString(),
					_originalChq_reg_pay_code4 = Reader["CHQ_REG_PAY_CODE4"].ToString(),
					_originalChq_reg_pay_code5 = Reader["CHQ_REG_PAY_CODE5"].ToString(),
					_originalChq_reg_pay_code6 = Reader["CHQ_REG_PAY_CODE6"].ToString(),
					_originalChq_reg_pay_code7 = Reader["CHQ_REG_PAY_CODE7"].ToString(),
					_originalChq_reg_pay_code8 = Reader["CHQ_REG_PAY_CODE8"].ToString(),
					_originalChq_reg_pay_code9 = Reader["CHQ_REG_PAY_CODE9"].ToString(),
					_originalChq_reg_pay_code10 = Reader["CHQ_REG_PAY_CODE10"].ToString(),
					_originalChq_reg_pay_code11 = Reader["CHQ_REG_PAY_CODE11"].ToString(),
					_originalChq_reg_pay_code12 = Reader["CHQ_REG_PAY_CODE12"].ToString(),
					_originalChq_reg_pay_code13 = Reader["CHQ_REG_PAY_CODE13"].ToString(),
					_originalChq_reg_pay_code14 = Reader["CHQ_REG_PAY_CODE14"].ToString(),
					_originalChq_reg_pay_code15 = Reader["CHQ_REG_PAY_CODE15"].ToString(),
					_originalChq_reg_pay_code16 = Reader["CHQ_REG_PAY_CODE16"].ToString(),
					_originalChq_reg_pay_code17 = Reader["CHQ_REG_PAY_CODE17"].ToString(),
					_originalChq_reg_pay_code18 = Reader["CHQ_REG_PAY_CODE18"].ToString(),
					_originalChq_reg_perc_tax1 = ConvertDEC(Reader["CHQ_REG_PERC_TAX1"]),
					_originalChq_reg_perc_tax2 = ConvertDEC(Reader["CHQ_REG_PERC_TAX2"]),
					_originalChq_reg_perc_tax3 = ConvertDEC(Reader["CHQ_REG_PERC_TAX3"]),
					_originalChq_reg_perc_tax4 = ConvertDEC(Reader["CHQ_REG_PERC_TAX4"]),
					_originalChq_reg_perc_tax5 = ConvertDEC(Reader["CHQ_REG_PERC_TAX5"]),
					_originalChq_reg_perc_tax6 = ConvertDEC(Reader["CHQ_REG_PERC_TAX6"]),
					_originalChq_reg_perc_tax7 = ConvertDEC(Reader["CHQ_REG_PERC_TAX7"]),
					_originalChq_reg_perc_tax8 = ConvertDEC(Reader["CHQ_REG_PERC_TAX8"]),
					_originalChq_reg_perc_tax9 = ConvertDEC(Reader["CHQ_REG_PERC_TAX9"]),
					_originalChq_reg_perc_tax10 = ConvertDEC(Reader["CHQ_REG_PERC_TAX10"]),
					_originalChq_reg_perc_tax11 = ConvertDEC(Reader["CHQ_REG_PERC_TAX11"]),
					_originalChq_reg_perc_tax12 = ConvertDEC(Reader["CHQ_REG_PERC_TAX12"]),
					_originalChq_reg_perc_tax13 = ConvertDEC(Reader["CHQ_REG_PERC_TAX13"]),
					_originalChq_reg_perc_tax14 = ConvertDEC(Reader["CHQ_REG_PERC_TAX14"]),
					_originalChq_reg_perc_tax15 = ConvertDEC(Reader["CHQ_REG_PERC_TAX15"]),
					_originalChq_reg_perc_tax16 = ConvertDEC(Reader["CHQ_REG_PERC_TAX16"]),
					_originalChq_reg_perc_tax17 = ConvertDEC(Reader["CHQ_REG_PERC_TAX17"]),
					_originalChq_reg_perc_tax18 = ConvertDEC(Reader["CHQ_REG_PERC_TAX18"]),
					_originalChq_reg_mth_bill_amt1 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT1"]),
					_originalChq_reg_mth_bill_amt2 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT2"]),
					_originalChq_reg_mth_bill_amt3 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT3"]),
					_originalChq_reg_mth_bill_amt4 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT4"]),
					_originalChq_reg_mth_bill_amt5 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT5"]),
					_originalChq_reg_mth_bill_amt6 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT6"]),
					_originalChq_reg_mth_bill_amt7 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT7"]),
					_originalChq_reg_mth_bill_amt8 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT8"]),
					_originalChq_reg_mth_bill_amt9 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT9"]),
					_originalChq_reg_mth_bill_amt10 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT10"]),
					_originalChq_reg_mth_bill_amt11 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT11"]),
					_originalChq_reg_mth_bill_amt12 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT12"]),
					_originalChq_reg_mth_bill_amt13 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT13"]),
					_originalChq_reg_mth_bill_amt14 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT14"]),
					_originalChq_reg_mth_bill_amt15 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT15"]),
					_originalChq_reg_mth_bill_amt16 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT16"]),
					_originalChq_reg_mth_bill_amt17 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT17"]),
					_originalChq_reg_mth_bill_amt18 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT18"]),
					_originalChq_reg_mth_misc_amt_11 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_11"]),
					_originalChq_reg_mth_misc_amt_12 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_12"]),
					_originalChq_reg_mth_misc_amt_13 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_13"]),
					_originalChq_reg_mth_misc_amt_14 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_14"]),
					_originalChq_reg_mth_misc_amt_15 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_15"]),
					_originalChq_reg_mth_misc_amt_16 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_16"]),
					_originalChq_reg_mth_misc_amt_17 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_17"]),
					_originalChq_reg_mth_misc_amt_18 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_18"]),
					_originalChq_reg_mth_misc_amt_19 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_19"]),
					_originalChq_reg_mth_misc_amt_110 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_110"]),
					_originalChq_reg_mth_misc_amt_111 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_111"]),
					_originalChq_reg_mth_misc_amt_112 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_112"]),
					_originalChq_reg_mth_misc_amt_113 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_113"]),
					_originalChq_reg_mth_misc_amt_114 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_114"]),
					_originalChq_reg_mth_misc_amt_115 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_115"]),
					_originalChq_reg_mth_misc_amt_116 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_116"]),
					_originalChq_reg_mth_misc_amt_117 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_117"]),
					_originalChq_reg_mth_misc_amt_118 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_118"]),
					_originalChq_reg_mth_misc_amt_21 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_21"]),
					_originalChq_reg_mth_misc_amt_22 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_22"]),
					_originalChq_reg_mth_misc_amt_23 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_23"]),
					_originalChq_reg_mth_misc_amt_24 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_24"]),
					_originalChq_reg_mth_misc_amt_25 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_25"]),
					_originalChq_reg_mth_misc_amt_26 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_26"]),
					_originalChq_reg_mth_misc_amt_27 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_27"]),
					_originalChq_reg_mth_misc_amt_28 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_28"]),
					_originalChq_reg_mth_misc_amt_29 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_29"]),
					_originalChq_reg_mth_misc_amt_210 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_210"]),
					_originalChq_reg_mth_misc_amt_211 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_211"]),
					_originalChq_reg_mth_misc_amt_212 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_212"]),
					_originalChq_reg_mth_misc_amt_213 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_213"]),
					_originalChq_reg_mth_misc_amt_214 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_214"]),
					_originalChq_reg_mth_misc_amt_215 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_215"]),
					_originalChq_reg_mth_misc_amt_216 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_216"]),
					_originalChq_reg_mth_misc_amt_217 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_217"]),
					_originalChq_reg_mth_misc_amt_218 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_218"]),
					_originalChq_reg_mth_misc_amt_31 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_31"]),
					_originalChq_reg_mth_misc_amt_32 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_32"]),
					_originalChq_reg_mth_misc_amt_33 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_33"]),
					_originalChq_reg_mth_misc_amt_34 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_34"]),
					_originalChq_reg_mth_misc_amt_35 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_35"]),
					_originalChq_reg_mth_misc_amt_36 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_36"]),
					_originalChq_reg_mth_misc_amt_37 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_37"]),
					_originalChq_reg_mth_misc_amt_38 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_38"]),
					_originalChq_reg_mth_misc_amt_39 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_39"]),
					_originalChq_reg_mth_misc_amt_310 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_310"]),
					_originalChq_reg_mth_misc_amt_311 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_311"]),
					_originalChq_reg_mth_misc_amt_312 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_312"]),
					_originalChq_reg_mth_misc_amt_313 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_313"]),
					_originalChq_reg_mth_misc_amt_314 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_314"]),
					_originalChq_reg_mth_misc_amt_315 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_315"]),
					_originalChq_reg_mth_misc_amt_316 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_316"]),
					_originalChq_reg_mth_misc_amt_317 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_317"]),
					_originalChq_reg_mth_misc_amt_318 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_318"]),
					_originalChq_reg_mth_misc_amt_41 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_41"]),
					_originalChq_reg_mth_misc_amt_42 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_42"]),
					_originalChq_reg_mth_misc_amt_43 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_43"]),
					_originalChq_reg_mth_misc_amt_44 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_44"]),
					_originalChq_reg_mth_misc_amt_45 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_45"]),
					_originalChq_reg_mth_misc_amt_46 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_46"]),
					_originalChq_reg_mth_misc_amt_47 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_47"]),
					_originalChq_reg_mth_misc_amt_48 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_48"]),
					_originalChq_reg_mth_misc_amt_49 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_49"]),
					_originalChq_reg_mth_misc_amt_410 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_410"]),
					_originalChq_reg_mth_misc_amt_411 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_411"]),
					_originalChq_reg_mth_misc_amt_412 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_412"]),
					_originalChq_reg_mth_misc_amt_413 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_413"]),
					_originalChq_reg_mth_misc_amt_414 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_414"]),
					_originalChq_reg_mth_misc_amt_415 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_415"]),
					_originalChq_reg_mth_misc_amt_416 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_416"]),
					_originalChq_reg_mth_misc_amt_417 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_417"]),
					_originalChq_reg_mth_misc_amt_418 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_418"]),
					_originalChq_reg_mth_misc_amt_51 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_51"]),
					_originalChq_reg_mth_misc_amt_52 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_52"]),
					_originalChq_reg_mth_misc_amt_53 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_53"]),
					_originalChq_reg_mth_misc_amt_54 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_54"]),
					_originalChq_reg_mth_misc_amt_55 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_55"]),
					_originalChq_reg_mth_misc_amt_56 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_56"]),
					_originalChq_reg_mth_misc_amt_57 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_57"]),
					_originalChq_reg_mth_misc_amt_58 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_58"]),
					_originalChq_reg_mth_misc_amt_59 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_59"]),
					_originalChq_reg_mth_misc_amt_510 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_510"]),
					_originalChq_reg_mth_misc_amt_511 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_511"]),
					_originalChq_reg_mth_misc_amt_512 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_512"]),
					_originalChq_reg_mth_misc_amt_513 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_513"]),
					_originalChq_reg_mth_misc_amt_514 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_514"]),
					_originalChq_reg_mth_misc_amt_515 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_515"]),
					_originalChq_reg_mth_misc_amt_516 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_516"]),
					_originalChq_reg_mth_misc_amt_517 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_517"]),
					_originalChq_reg_mth_misc_amt_518 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_518"]),
					_originalChq_reg_mth_misc_amt_61 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_61"]),
					_originalChq_reg_mth_misc_amt_62 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_62"]),
					_originalChq_reg_mth_misc_amt_63 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_63"]),
					_originalChq_reg_mth_misc_amt_64 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_64"]),
					_originalChq_reg_mth_misc_amt_65 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_65"]),
					_originalChq_reg_mth_misc_amt_66 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_66"]),
					_originalChq_reg_mth_misc_amt_67 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_67"]),
					_originalChq_reg_mth_misc_amt_68 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_68"]),
					_originalChq_reg_mth_misc_amt_69 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_69"]),
					_originalChq_reg_mth_misc_amt_610 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_610"]),
					_originalChq_reg_mth_misc_amt_611 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_611"]),
					_originalChq_reg_mth_misc_amt_612 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_612"]),
					_originalChq_reg_mth_misc_amt_613 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_613"]),
					_originalChq_reg_mth_misc_amt_614 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_614"]),
					_originalChq_reg_mth_misc_amt_615 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_615"]),
					_originalChq_reg_mth_misc_amt_616 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_616"]),
					_originalChq_reg_mth_misc_amt_617 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_617"]),
					_originalChq_reg_mth_misc_amt_618 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_618"]),
					_originalChq_reg_mth_misc_amt_71 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_71"]),
					_originalChq_reg_mth_misc_amt_72 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_72"]),
					_originalChq_reg_mth_misc_amt_73 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_73"]),
					_originalChq_reg_mth_misc_amt_74 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_74"]),
					_originalChq_reg_mth_misc_amt_75 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_75"]),
					_originalChq_reg_mth_misc_amt_76 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_76"]),
					_originalChq_reg_mth_misc_amt_77 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_77"]),
					_originalChq_reg_mth_misc_amt_78 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_78"]),
					_originalChq_reg_mth_misc_amt_79 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_79"]),
					_originalChq_reg_mth_misc_amt_710 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_710"]),
					_originalChq_reg_mth_misc_amt_711 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_711"]),
					_originalChq_reg_mth_misc_amt_712 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_712"]),
					_originalChq_reg_mth_misc_amt_713 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_713"]),
					_originalChq_reg_mth_misc_amt_714 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_714"]),
					_originalChq_reg_mth_misc_amt_715 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_715"]),
					_originalChq_reg_mth_misc_amt_716 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_716"]),
					_originalChq_reg_mth_misc_amt_717 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_717"]),
					_originalChq_reg_mth_misc_amt_718 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_718"]),
					_originalChq_reg_mth_misc_amt_81 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_81"]),
					_originalChq_reg_mth_misc_amt_82 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_82"]),
					_originalChq_reg_mth_misc_amt_83 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_83"]),
					_originalChq_reg_mth_misc_amt_84 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_84"]),
					_originalChq_reg_mth_misc_amt_85 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_85"]),
					_originalChq_reg_mth_misc_amt_86 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_86"]),
					_originalChq_reg_mth_misc_amt_87 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_87"]),
					_originalChq_reg_mth_misc_amt_88 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_88"]),
					_originalChq_reg_mth_misc_amt_89 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_89"]),
					_originalChq_reg_mth_misc_amt_810 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_810"]),
					_originalChq_reg_mth_misc_amt_811 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_811"]),
					_originalChq_reg_mth_misc_amt_812 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_812"]),
					_originalChq_reg_mth_misc_amt_813 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_813"]),
					_originalChq_reg_mth_misc_amt_814 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_814"]),
					_originalChq_reg_mth_misc_amt_815 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_815"]),
					_originalChq_reg_mth_misc_amt_816 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_816"]),
					_originalChq_reg_mth_misc_amt_817 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_817"]),
					_originalChq_reg_mth_misc_amt_818 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_818"]),
					_originalChq_reg_mth_misc_amt_91 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_91"]),
					_originalChq_reg_mth_misc_amt_92 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_92"]),
					_originalChq_reg_mth_misc_amt_93 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_93"]),
					_originalChq_reg_mth_misc_amt_94 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_94"]),
					_originalChq_reg_mth_misc_amt_95 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_95"]),
					_originalChq_reg_mth_misc_amt_96 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_96"]),
					_originalChq_reg_mth_misc_amt_97 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_97"]),
					_originalChq_reg_mth_misc_amt_98 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_98"]),
					_originalChq_reg_mth_misc_amt_99 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_99"]),
					_originalChq_reg_mth_misc_amt_910 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_910"]),
					_originalChq_reg_mth_misc_amt_911 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_911"]),
					_originalChq_reg_mth_misc_amt_912 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_912"]),
					_originalChq_reg_mth_misc_amt_913 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_913"]),
					_originalChq_reg_mth_misc_amt_914 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_914"]),
					_originalChq_reg_mth_misc_amt_915 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_915"]),
					_originalChq_reg_mth_misc_amt_916 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_916"]),
					_originalChq_reg_mth_misc_amt_917 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_917"]),
					_originalChq_reg_mth_misc_amt_918 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_918"]),
					_originalChq_reg_mth_misc_amt_101 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_101"]),
					_originalChq_reg_mth_misc_amt_102 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_102"]),
					_originalChq_reg_mth_misc_amt_103 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_103"]),
					_originalChq_reg_mth_misc_amt_104 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_104"]),
					_originalChq_reg_mth_misc_amt_105 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_105"]),
					_originalChq_reg_mth_misc_amt_106 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_106"]),
					_originalChq_reg_mth_misc_amt_107 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_107"]),
					_originalChq_reg_mth_misc_amt_108 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_108"]),
					_originalChq_reg_mth_misc_amt_109 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_109"]),
					_originalChq_reg_mth_misc_amt_1010 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1010"]),
					_originalChq_reg_mth_misc_amt_1011 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1011"]),
					_originalChq_reg_mth_misc_amt_1012 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1012"]),
					_originalChq_reg_mth_misc_amt_1013 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1013"]),
					_originalChq_reg_mth_misc_amt_1014 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1014"]),
					_originalChq_reg_mth_misc_amt_1015 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1015"]),
					_originalChq_reg_mth_misc_amt_1016 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1016"]),
					_originalChq_reg_mth_misc_amt_1017 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1017"]),
					_originalChq_reg_mth_misc_amt_1018 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1018"]),
					_originalChq_reg_mth_exp_amt1 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT1"]),
					_originalChq_reg_mth_exp_amt2 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT2"]),
					_originalChq_reg_mth_exp_amt3 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT3"]),
					_originalChq_reg_mth_exp_amt4 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT4"]),
					_originalChq_reg_mth_exp_amt5 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT5"]),
					_originalChq_reg_mth_exp_amt6 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT6"]),
					_originalChq_reg_mth_exp_amt7 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT7"]),
					_originalChq_reg_mth_exp_amt8 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT8"]),
					_originalChq_reg_mth_exp_amt9 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT9"]),
					_originalChq_reg_mth_exp_amt10 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT10"]),
					_originalChq_reg_mth_exp_amt11 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT11"]),
					_originalChq_reg_mth_exp_amt12 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT12"]),
					_originalChq_reg_mth_exp_amt13 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT13"]),
					_originalChq_reg_mth_exp_amt14 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT14"]),
					_originalChq_reg_mth_exp_amt15 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT15"]),
					_originalChq_reg_mth_exp_amt16 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT16"]),
					_originalChq_reg_mth_exp_amt17 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT17"]),
					_originalChq_reg_mth_exp_amt18 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT18"]),
					_originalChq_reg_comp_ann_exp_this_pay1 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY1"]),
					_originalChq_reg_comp_ann_exp_this_pay2 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY2"]),
					_originalChq_reg_comp_ann_exp_this_pay3 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY3"]),
					_originalChq_reg_comp_ann_exp_this_pay4 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY4"]),
					_originalChq_reg_comp_ann_exp_this_pay5 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY5"]),
					_originalChq_reg_comp_ann_exp_this_pay6 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY6"]),
					_originalChq_reg_comp_ann_exp_this_pay7 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY7"]),
					_originalChq_reg_comp_ann_exp_this_pay8 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY8"]),
					_originalChq_reg_comp_ann_exp_this_pay9 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY9"]),
					_originalChq_reg_comp_ann_exp_this_pay10 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY10"]),
					_originalChq_reg_comp_ann_exp_this_pay11 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY11"]),
					_originalChq_reg_comp_ann_exp_this_pay12 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY12"]),
					_originalChq_reg_comp_ann_exp_this_pay13 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY13"]),
					_originalChq_reg_comp_ann_exp_this_pay14 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY14"]),
					_originalChq_reg_comp_ann_exp_this_pay15 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY15"]),
					_originalChq_reg_comp_ann_exp_this_pay16 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY16"]),
					_originalChq_reg_comp_ann_exp_this_pay17 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY17"]),
					_originalChq_reg_comp_ann_exp_this_pay18 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY18"]),
					_originalChq_reg_mth_ceil_amt1 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT1"]),
					_originalChq_reg_mth_ceil_amt2 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT2"]),
					_originalChq_reg_mth_ceil_amt3 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT3"]),
					_originalChq_reg_mth_ceil_amt4 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT4"]),
					_originalChq_reg_mth_ceil_amt5 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT5"]),
					_originalChq_reg_mth_ceil_amt6 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT6"]),
					_originalChq_reg_mth_ceil_amt7 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT7"]),
					_originalChq_reg_mth_ceil_amt8 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT8"]),
					_originalChq_reg_mth_ceil_amt9 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT9"]),
					_originalChq_reg_mth_ceil_amt10 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT10"]),
					_originalChq_reg_mth_ceil_amt11 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT11"]),
					_originalChq_reg_mth_ceil_amt12 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT12"]),
					_originalChq_reg_mth_ceil_amt13 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT13"]),
					_originalChq_reg_mth_ceil_amt14 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT14"]),
					_originalChq_reg_mth_ceil_amt15 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT15"]),
					_originalChq_reg_mth_ceil_amt16 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT16"]),
					_originalChq_reg_mth_ceil_amt17 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT17"]),
					_originalChq_reg_mth_ceil_amt18 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT18"]),
					_originalChq_reg_comp_ann_ceil_this_pay1 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY1"]),
					_originalChq_reg_comp_ann_ceil_this_pay2 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY2"]),
					_originalChq_reg_comp_ann_ceil_this_pay3 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY3"]),
					_originalChq_reg_comp_ann_ceil_this_pay4 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY4"]),
					_originalChq_reg_comp_ann_ceil_this_pay5 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY5"]),
					_originalChq_reg_comp_ann_ceil_this_pay6 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY6"]),
					_originalChq_reg_comp_ann_ceil_this_pay7 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY7"]),
					_originalChq_reg_comp_ann_ceil_this_pay8 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY8"]),
					_originalChq_reg_comp_ann_ceil_this_pay9 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY9"]),
					_originalChq_reg_comp_ann_ceil_this_pay10 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY10"]),
					_originalChq_reg_comp_ann_ceil_this_pay11 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY11"]),
					_originalChq_reg_comp_ann_ceil_this_pay12 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY12"]),
					_originalChq_reg_comp_ann_ceil_this_pay13 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY13"]),
					_originalChq_reg_comp_ann_ceil_this_pay14 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY14"]),
					_originalChq_reg_comp_ann_ceil_this_pay15 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY15"]),
					_originalChq_reg_comp_ann_ceil_this_pay16 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY16"]),
					_originalChq_reg_comp_ann_ceil_this_pay17 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY17"]),
					_originalChq_reg_comp_ann_ceil_this_pay18 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY18"]),
					_originalChq_reg_earnings_this_mth1 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH1"]),
					_originalChq_reg_earnings_this_mth2 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH2"]),
					_originalChq_reg_earnings_this_mth3 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH3"]),
					_originalChq_reg_earnings_this_mth4 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH4"]),
					_originalChq_reg_earnings_this_mth5 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH5"]),
					_originalChq_reg_earnings_this_mth6 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH6"]),
					_originalChq_reg_earnings_this_mth7 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH7"]),
					_originalChq_reg_earnings_this_mth8 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH8"]),
					_originalChq_reg_earnings_this_mth9 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH9"]),
					_originalChq_reg_earnings_this_mth10 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH10"]),
					_originalChq_reg_earnings_this_mth11 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH11"]),
					_originalChq_reg_earnings_this_mth12 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH12"]),
					_originalChq_reg_earnings_this_mth13 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH13"]),
					_originalChq_reg_earnings_this_mth14 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH14"]),
					_originalChq_reg_earnings_this_mth15 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH15"]),
					_originalChq_reg_earnings_this_mth16 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH16"]),
					_originalChq_reg_earnings_this_mth17 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH17"]),
					_originalChq_reg_earnings_this_mth18 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH18"]),
					_originalChq_reg_regular_pay_this_mth1 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH1"]),
					_originalChq_reg_regular_pay_this_mth2 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH2"]),
					_originalChq_reg_regular_pay_this_mth3 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH3"]),
					_originalChq_reg_regular_pay_this_mth4 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH4"]),
					_originalChq_reg_regular_pay_this_mth5 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH5"]),
					_originalChq_reg_regular_pay_this_mth6 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH6"]),
					_originalChq_reg_regular_pay_this_mth7 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH7"]),
					_originalChq_reg_regular_pay_this_mth8 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH8"]),
					_originalChq_reg_regular_pay_this_mth9 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH9"]),
					_originalChq_reg_regular_pay_this_mth10 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH10"]),
					_originalChq_reg_regular_pay_this_mth11 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH11"]),
					_originalChq_reg_regular_pay_this_mth12 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH12"]),
					_originalChq_reg_regular_pay_this_mth13 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH13"]),
					_originalChq_reg_regular_pay_this_mth14 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH14"]),
					_originalChq_reg_regular_pay_this_mth15 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH15"]),
					_originalChq_reg_regular_pay_this_mth16 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH16"]),
					_originalChq_reg_regular_pay_this_mth17 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH17"]),
					_originalChq_reg_regular_pay_this_mth18 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH18"]),
					_originalChq_reg_regular_tax_this_mth1 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH1"]),
					_originalChq_reg_regular_tax_this_mth2 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH2"]),
					_originalChq_reg_regular_tax_this_mth3 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH3"]),
					_originalChq_reg_regular_tax_this_mth4 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH4"]),
					_originalChq_reg_regular_tax_this_mth5 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH5"]),
					_originalChq_reg_regular_tax_this_mth6 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH6"]),
					_originalChq_reg_regular_tax_this_mth7 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH7"]),
					_originalChq_reg_regular_tax_this_mth8 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH8"]),
					_originalChq_reg_regular_tax_this_mth9 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH9"]),
					_originalChq_reg_regular_tax_this_mth10 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH10"]),
					_originalChq_reg_regular_tax_this_mth11 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH11"]),
					_originalChq_reg_regular_tax_this_mth12 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH12"]),
					_originalChq_reg_regular_tax_this_mth13 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH13"]),
					_originalChq_reg_regular_tax_this_mth14 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH14"]),
					_originalChq_reg_regular_tax_this_mth15 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH15"]),
					_originalChq_reg_regular_tax_this_mth16 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH16"]),
					_originalChq_reg_regular_tax_this_mth17 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH17"]),
					_originalChq_reg_regular_tax_this_mth18 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH18"]),
					_originalChq_reg_man_pay_this_mth1 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH1"]),
					_originalChq_reg_man_pay_this_mth2 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH2"]),
					_originalChq_reg_man_pay_this_mth3 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH3"]),
					_originalChq_reg_man_pay_this_mth4 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH4"]),
					_originalChq_reg_man_pay_this_mth5 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH5"]),
					_originalChq_reg_man_pay_this_mth6 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH6"]),
					_originalChq_reg_man_pay_this_mth7 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH7"]),
					_originalChq_reg_man_pay_this_mth8 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH8"]),
					_originalChq_reg_man_pay_this_mth9 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH9"]),
					_originalChq_reg_man_pay_this_mth10 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH10"]),
					_originalChq_reg_man_pay_this_mth11 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH11"]),
					_originalChq_reg_man_pay_this_mth12 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH12"]),
					_originalChq_reg_man_pay_this_mth13 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH13"]),
					_originalChq_reg_man_pay_this_mth14 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH14"]),
					_originalChq_reg_man_pay_this_mth15 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH15"]),
					_originalChq_reg_man_pay_this_mth16 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH16"]),
					_originalChq_reg_man_pay_this_mth17 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH17"]),
					_originalChq_reg_man_pay_this_mth18 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH18"]),
					_originalChq_reg_man_tax_this_mth1 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH1"]),
					_originalChq_reg_man_tax_this_mth2 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH2"]),
					_originalChq_reg_man_tax_this_mth3 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH3"]),
					_originalChq_reg_man_tax_this_mth4 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH4"]),
					_originalChq_reg_man_tax_this_mth5 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH5"]),
					_originalChq_reg_man_tax_this_mth6 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH6"]),
					_originalChq_reg_man_tax_this_mth7 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH7"]),
					_originalChq_reg_man_tax_this_mth8 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH8"]),
					_originalChq_reg_man_tax_this_mth9 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH9"]),
					_originalChq_reg_man_tax_this_mth10 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH10"]),
					_originalChq_reg_man_tax_this_mth11 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH11"]),
					_originalChq_reg_man_tax_this_mth12 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH12"]),
					_originalChq_reg_man_tax_this_mth13 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH13"]),
					_originalChq_reg_man_tax_this_mth14 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH14"]),
					_originalChq_reg_man_tax_this_mth15 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH15"]),
					_originalChq_reg_man_tax_this_mth16 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH16"]),
					_originalChq_reg_man_tax_this_mth17 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH17"]),
					_originalChq_reg_man_tax_this_mth18 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH18"]),
					_originalChq_reg_pay_date1 = ConvertDEC(Reader["CHQ_REG_PAY_DATE1"]),
					_originalChq_reg_pay_date2 = ConvertDEC(Reader["CHQ_REG_PAY_DATE2"]),
					_originalChq_reg_pay_date3 = ConvertDEC(Reader["CHQ_REG_PAY_DATE3"]),
					_originalChq_reg_pay_date4 = ConvertDEC(Reader["CHQ_REG_PAY_DATE4"]),
					_originalChq_reg_pay_date5 = ConvertDEC(Reader["CHQ_REG_PAY_DATE5"]),
					_originalChq_reg_pay_date6 = ConvertDEC(Reader["CHQ_REG_PAY_DATE6"]),
					_originalChq_reg_pay_date7 = ConvertDEC(Reader["CHQ_REG_PAY_DATE7"]),
					_originalChq_reg_pay_date8 = ConvertDEC(Reader["CHQ_REG_PAY_DATE8"]),
					_originalChq_reg_pay_date9 = ConvertDEC(Reader["CHQ_REG_PAY_DATE9"]),
					_originalChq_reg_pay_date10 = ConvertDEC(Reader["CHQ_REG_PAY_DATE10"]),
					_originalChq_reg_pay_date11 = ConvertDEC(Reader["CHQ_REG_PAY_DATE11"]),
					_originalChq_reg_pay_date12 = ConvertDEC(Reader["CHQ_REG_PAY_DATE12"]),
					_originalChq_reg_pay_date13 = ConvertDEC(Reader["CHQ_REG_PAY_DATE13"]),
					_originalChq_reg_pay_date14 = ConvertDEC(Reader["CHQ_REG_PAY_DATE14"]),
					_originalChq_reg_pay_date15 = ConvertDEC(Reader["CHQ_REG_PAY_DATE15"]),
					_originalChq_reg_pay_date16 = ConvertDEC(Reader["CHQ_REG_PAY_DATE16"]),
					_originalChq_reg_pay_date17 = ConvertDEC(Reader["CHQ_REG_PAY_DATE17"]),
					_originalChq_reg_pay_date18 = ConvertDEC(Reader["CHQ_REG_PAY_DATE18"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereChq_reg_clinic_nbr_1_2 = WhereChq_reg_clinic_nbr_1_2;
					_whereChq_reg_dept = WhereChq_reg_dept;
					_whereChq_reg_doc_nbr = WhereChq_reg_doc_nbr;
					_whereChq_reg_perc_bill1 = WhereChq_reg_perc_bill1;
					_whereChq_reg_perc_bill2 = WhereChq_reg_perc_bill2;
					_whereChq_reg_perc_bill3 = WhereChq_reg_perc_bill3;
					_whereChq_reg_perc_bill4 = WhereChq_reg_perc_bill4;
					_whereChq_reg_perc_bill5 = WhereChq_reg_perc_bill5;
					_whereChq_reg_perc_bill6 = WhereChq_reg_perc_bill6;
					_whereChq_reg_perc_bill7 = WhereChq_reg_perc_bill7;
					_whereChq_reg_perc_bill8 = WhereChq_reg_perc_bill8;
					_whereChq_reg_perc_bill9 = WhereChq_reg_perc_bill9;
					_whereChq_reg_perc_bill10 = WhereChq_reg_perc_bill10;
					_whereChq_reg_perc_bill11 = WhereChq_reg_perc_bill11;
					_whereChq_reg_perc_bill12 = WhereChq_reg_perc_bill12;
					_whereChq_reg_perc_bill13 = WhereChq_reg_perc_bill13;
					_whereChq_reg_perc_bill14 = WhereChq_reg_perc_bill14;
					_whereChq_reg_perc_bill15 = WhereChq_reg_perc_bill15;
					_whereChq_reg_perc_bill16 = WhereChq_reg_perc_bill16;
					_whereChq_reg_perc_bill17 = WhereChq_reg_perc_bill17;
					_whereChq_reg_perc_bill18 = WhereChq_reg_perc_bill18;
					_whereChq_reg_perc_misc1 = WhereChq_reg_perc_misc1;
					_whereChq_reg_perc_misc2 = WhereChq_reg_perc_misc2;
					_whereChq_reg_perc_misc3 = WhereChq_reg_perc_misc3;
					_whereChq_reg_perc_misc4 = WhereChq_reg_perc_misc4;
					_whereChq_reg_perc_misc5 = WhereChq_reg_perc_misc5;
					_whereChq_reg_perc_misc6 = WhereChq_reg_perc_misc6;
					_whereChq_reg_perc_misc7 = WhereChq_reg_perc_misc7;
					_whereChq_reg_perc_misc8 = WhereChq_reg_perc_misc8;
					_whereChq_reg_perc_misc9 = WhereChq_reg_perc_misc9;
					_whereChq_reg_perc_misc10 = WhereChq_reg_perc_misc10;
					_whereChq_reg_perc_misc11 = WhereChq_reg_perc_misc11;
					_whereChq_reg_perc_misc12 = WhereChq_reg_perc_misc12;
					_whereChq_reg_perc_misc13 = WhereChq_reg_perc_misc13;
					_whereChq_reg_perc_misc14 = WhereChq_reg_perc_misc14;
					_whereChq_reg_perc_misc15 = WhereChq_reg_perc_misc15;
					_whereChq_reg_perc_misc16 = WhereChq_reg_perc_misc16;
					_whereChq_reg_perc_misc17 = WhereChq_reg_perc_misc17;
					_whereChq_reg_perc_misc18 = WhereChq_reg_perc_misc18;
					_whereChq_reg_pay_code1 = WhereChq_reg_pay_code1;
					_whereChq_reg_pay_code2 = WhereChq_reg_pay_code2;
					_whereChq_reg_pay_code3 = WhereChq_reg_pay_code3;
					_whereChq_reg_pay_code4 = WhereChq_reg_pay_code4;
					_whereChq_reg_pay_code5 = WhereChq_reg_pay_code5;
					_whereChq_reg_pay_code6 = WhereChq_reg_pay_code6;
					_whereChq_reg_pay_code7 = WhereChq_reg_pay_code7;
					_whereChq_reg_pay_code8 = WhereChq_reg_pay_code8;
					_whereChq_reg_pay_code9 = WhereChq_reg_pay_code9;
					_whereChq_reg_pay_code10 = WhereChq_reg_pay_code10;
					_whereChq_reg_pay_code11 = WhereChq_reg_pay_code11;
					_whereChq_reg_pay_code12 = WhereChq_reg_pay_code12;
					_whereChq_reg_pay_code13 = WhereChq_reg_pay_code13;
					_whereChq_reg_pay_code14 = WhereChq_reg_pay_code14;
					_whereChq_reg_pay_code15 = WhereChq_reg_pay_code15;
					_whereChq_reg_pay_code16 = WhereChq_reg_pay_code16;
					_whereChq_reg_pay_code17 = WhereChq_reg_pay_code17;
					_whereChq_reg_pay_code18 = WhereChq_reg_pay_code18;
					_whereChq_reg_perc_tax1 = WhereChq_reg_perc_tax1;
					_whereChq_reg_perc_tax2 = WhereChq_reg_perc_tax2;
					_whereChq_reg_perc_tax3 = WhereChq_reg_perc_tax3;
					_whereChq_reg_perc_tax4 = WhereChq_reg_perc_tax4;
					_whereChq_reg_perc_tax5 = WhereChq_reg_perc_tax5;
					_whereChq_reg_perc_tax6 = WhereChq_reg_perc_tax6;
					_whereChq_reg_perc_tax7 = WhereChq_reg_perc_tax7;
					_whereChq_reg_perc_tax8 = WhereChq_reg_perc_tax8;
					_whereChq_reg_perc_tax9 = WhereChq_reg_perc_tax9;
					_whereChq_reg_perc_tax10 = WhereChq_reg_perc_tax10;
					_whereChq_reg_perc_tax11 = WhereChq_reg_perc_tax11;
					_whereChq_reg_perc_tax12 = WhereChq_reg_perc_tax12;
					_whereChq_reg_perc_tax13 = WhereChq_reg_perc_tax13;
					_whereChq_reg_perc_tax14 = WhereChq_reg_perc_tax14;
					_whereChq_reg_perc_tax15 = WhereChq_reg_perc_tax15;
					_whereChq_reg_perc_tax16 = WhereChq_reg_perc_tax16;
					_whereChq_reg_perc_tax17 = WhereChq_reg_perc_tax17;
					_whereChq_reg_perc_tax18 = WhereChq_reg_perc_tax18;
					_whereChq_reg_mth_bill_amt1 = WhereChq_reg_mth_bill_amt1;
					_whereChq_reg_mth_bill_amt2 = WhereChq_reg_mth_bill_amt2;
					_whereChq_reg_mth_bill_amt3 = WhereChq_reg_mth_bill_amt3;
					_whereChq_reg_mth_bill_amt4 = WhereChq_reg_mth_bill_amt4;
					_whereChq_reg_mth_bill_amt5 = WhereChq_reg_mth_bill_amt5;
					_whereChq_reg_mth_bill_amt6 = WhereChq_reg_mth_bill_amt6;
					_whereChq_reg_mth_bill_amt7 = WhereChq_reg_mth_bill_amt7;
					_whereChq_reg_mth_bill_amt8 = WhereChq_reg_mth_bill_amt8;
					_whereChq_reg_mth_bill_amt9 = WhereChq_reg_mth_bill_amt9;
					_whereChq_reg_mth_bill_amt10 = WhereChq_reg_mth_bill_amt10;
					_whereChq_reg_mth_bill_amt11 = WhereChq_reg_mth_bill_amt11;
					_whereChq_reg_mth_bill_amt12 = WhereChq_reg_mth_bill_amt12;
					_whereChq_reg_mth_bill_amt13 = WhereChq_reg_mth_bill_amt13;
					_whereChq_reg_mth_bill_amt14 = WhereChq_reg_mth_bill_amt14;
					_whereChq_reg_mth_bill_amt15 = WhereChq_reg_mth_bill_amt15;
					_whereChq_reg_mth_bill_amt16 = WhereChq_reg_mth_bill_amt16;
					_whereChq_reg_mth_bill_amt17 = WhereChq_reg_mth_bill_amt17;
					_whereChq_reg_mth_bill_amt18 = WhereChq_reg_mth_bill_amt18;
					_whereChq_reg_mth_misc_amt_11 = WhereChq_reg_mth_misc_amt_11;
					_whereChq_reg_mth_misc_amt_12 = WhereChq_reg_mth_misc_amt_12;
					_whereChq_reg_mth_misc_amt_13 = WhereChq_reg_mth_misc_amt_13;
					_whereChq_reg_mth_misc_amt_14 = WhereChq_reg_mth_misc_amt_14;
					_whereChq_reg_mth_misc_amt_15 = WhereChq_reg_mth_misc_amt_15;
					_whereChq_reg_mth_misc_amt_16 = WhereChq_reg_mth_misc_amt_16;
					_whereChq_reg_mth_misc_amt_17 = WhereChq_reg_mth_misc_amt_17;
					_whereChq_reg_mth_misc_amt_18 = WhereChq_reg_mth_misc_amt_18;
					_whereChq_reg_mth_misc_amt_19 = WhereChq_reg_mth_misc_amt_19;
					_whereChq_reg_mth_misc_amt_110 = WhereChq_reg_mth_misc_amt_110;
					_whereChq_reg_mth_misc_amt_111 = WhereChq_reg_mth_misc_amt_111;
					_whereChq_reg_mth_misc_amt_112 = WhereChq_reg_mth_misc_amt_112;
					_whereChq_reg_mth_misc_amt_113 = WhereChq_reg_mth_misc_amt_113;
					_whereChq_reg_mth_misc_amt_114 = WhereChq_reg_mth_misc_amt_114;
					_whereChq_reg_mth_misc_amt_115 = WhereChq_reg_mth_misc_amt_115;
					_whereChq_reg_mth_misc_amt_116 = WhereChq_reg_mth_misc_amt_116;
					_whereChq_reg_mth_misc_amt_117 = WhereChq_reg_mth_misc_amt_117;
					_whereChq_reg_mth_misc_amt_118 = WhereChq_reg_mth_misc_amt_118;
					_whereChq_reg_mth_misc_amt_21 = WhereChq_reg_mth_misc_amt_21;
					_whereChq_reg_mth_misc_amt_22 = WhereChq_reg_mth_misc_amt_22;
					_whereChq_reg_mth_misc_amt_23 = WhereChq_reg_mth_misc_amt_23;
					_whereChq_reg_mth_misc_amt_24 = WhereChq_reg_mth_misc_amt_24;
					_whereChq_reg_mth_misc_amt_25 = WhereChq_reg_mth_misc_amt_25;
					_whereChq_reg_mth_misc_amt_26 = WhereChq_reg_mth_misc_amt_26;
					_whereChq_reg_mth_misc_amt_27 = WhereChq_reg_mth_misc_amt_27;
					_whereChq_reg_mth_misc_amt_28 = WhereChq_reg_mth_misc_amt_28;
					_whereChq_reg_mth_misc_amt_29 = WhereChq_reg_mth_misc_amt_29;
					_whereChq_reg_mth_misc_amt_210 = WhereChq_reg_mth_misc_amt_210;
					_whereChq_reg_mth_misc_amt_211 = WhereChq_reg_mth_misc_amt_211;
					_whereChq_reg_mth_misc_amt_212 = WhereChq_reg_mth_misc_amt_212;
					_whereChq_reg_mth_misc_amt_213 = WhereChq_reg_mth_misc_amt_213;
					_whereChq_reg_mth_misc_amt_214 = WhereChq_reg_mth_misc_amt_214;
					_whereChq_reg_mth_misc_amt_215 = WhereChq_reg_mth_misc_amt_215;
					_whereChq_reg_mth_misc_amt_216 = WhereChq_reg_mth_misc_amt_216;
					_whereChq_reg_mth_misc_amt_217 = WhereChq_reg_mth_misc_amt_217;
					_whereChq_reg_mth_misc_amt_218 = WhereChq_reg_mth_misc_amt_218;
					_whereChq_reg_mth_misc_amt_31 = WhereChq_reg_mth_misc_amt_31;
					_whereChq_reg_mth_misc_amt_32 = WhereChq_reg_mth_misc_amt_32;
					_whereChq_reg_mth_misc_amt_33 = WhereChq_reg_mth_misc_amt_33;
					_whereChq_reg_mth_misc_amt_34 = WhereChq_reg_mth_misc_amt_34;
					_whereChq_reg_mth_misc_amt_35 = WhereChq_reg_mth_misc_amt_35;
					_whereChq_reg_mth_misc_amt_36 = WhereChq_reg_mth_misc_amt_36;
					_whereChq_reg_mth_misc_amt_37 = WhereChq_reg_mth_misc_amt_37;
					_whereChq_reg_mth_misc_amt_38 = WhereChq_reg_mth_misc_amt_38;
					_whereChq_reg_mth_misc_amt_39 = WhereChq_reg_mth_misc_amt_39;
					_whereChq_reg_mth_misc_amt_310 = WhereChq_reg_mth_misc_amt_310;
					_whereChq_reg_mth_misc_amt_311 = WhereChq_reg_mth_misc_amt_311;
					_whereChq_reg_mth_misc_amt_312 = WhereChq_reg_mth_misc_amt_312;
					_whereChq_reg_mth_misc_amt_313 = WhereChq_reg_mth_misc_amt_313;
					_whereChq_reg_mth_misc_amt_314 = WhereChq_reg_mth_misc_amt_314;
					_whereChq_reg_mth_misc_amt_315 = WhereChq_reg_mth_misc_amt_315;
					_whereChq_reg_mth_misc_amt_316 = WhereChq_reg_mth_misc_amt_316;
					_whereChq_reg_mth_misc_amt_317 = WhereChq_reg_mth_misc_amt_317;
					_whereChq_reg_mth_misc_amt_318 = WhereChq_reg_mth_misc_amt_318;
					_whereChq_reg_mth_misc_amt_41 = WhereChq_reg_mth_misc_amt_41;
					_whereChq_reg_mth_misc_amt_42 = WhereChq_reg_mth_misc_amt_42;
					_whereChq_reg_mth_misc_amt_43 = WhereChq_reg_mth_misc_amt_43;
					_whereChq_reg_mth_misc_amt_44 = WhereChq_reg_mth_misc_amt_44;
					_whereChq_reg_mth_misc_amt_45 = WhereChq_reg_mth_misc_amt_45;
					_whereChq_reg_mth_misc_amt_46 = WhereChq_reg_mth_misc_amt_46;
					_whereChq_reg_mth_misc_amt_47 = WhereChq_reg_mth_misc_amt_47;
					_whereChq_reg_mth_misc_amt_48 = WhereChq_reg_mth_misc_amt_48;
					_whereChq_reg_mth_misc_amt_49 = WhereChq_reg_mth_misc_amt_49;
					_whereChq_reg_mth_misc_amt_410 = WhereChq_reg_mth_misc_amt_410;
					_whereChq_reg_mth_misc_amt_411 = WhereChq_reg_mth_misc_amt_411;
					_whereChq_reg_mth_misc_amt_412 = WhereChq_reg_mth_misc_amt_412;
					_whereChq_reg_mth_misc_amt_413 = WhereChq_reg_mth_misc_amt_413;
					_whereChq_reg_mth_misc_amt_414 = WhereChq_reg_mth_misc_amt_414;
					_whereChq_reg_mth_misc_amt_415 = WhereChq_reg_mth_misc_amt_415;
					_whereChq_reg_mth_misc_amt_416 = WhereChq_reg_mth_misc_amt_416;
					_whereChq_reg_mth_misc_amt_417 = WhereChq_reg_mth_misc_amt_417;
					_whereChq_reg_mth_misc_amt_418 = WhereChq_reg_mth_misc_amt_418;
					_whereChq_reg_mth_misc_amt_51 = WhereChq_reg_mth_misc_amt_51;
					_whereChq_reg_mth_misc_amt_52 = WhereChq_reg_mth_misc_amt_52;
					_whereChq_reg_mth_misc_amt_53 = WhereChq_reg_mth_misc_amt_53;
					_whereChq_reg_mth_misc_amt_54 = WhereChq_reg_mth_misc_amt_54;
					_whereChq_reg_mth_misc_amt_55 = WhereChq_reg_mth_misc_amt_55;
					_whereChq_reg_mth_misc_amt_56 = WhereChq_reg_mth_misc_amt_56;
					_whereChq_reg_mth_misc_amt_57 = WhereChq_reg_mth_misc_amt_57;
					_whereChq_reg_mth_misc_amt_58 = WhereChq_reg_mth_misc_amt_58;
					_whereChq_reg_mth_misc_amt_59 = WhereChq_reg_mth_misc_amt_59;
					_whereChq_reg_mth_misc_amt_510 = WhereChq_reg_mth_misc_amt_510;
					_whereChq_reg_mth_misc_amt_511 = WhereChq_reg_mth_misc_amt_511;
					_whereChq_reg_mth_misc_amt_512 = WhereChq_reg_mth_misc_amt_512;
					_whereChq_reg_mth_misc_amt_513 = WhereChq_reg_mth_misc_amt_513;
					_whereChq_reg_mth_misc_amt_514 = WhereChq_reg_mth_misc_amt_514;
					_whereChq_reg_mth_misc_amt_515 = WhereChq_reg_mth_misc_amt_515;
					_whereChq_reg_mth_misc_amt_516 = WhereChq_reg_mth_misc_amt_516;
					_whereChq_reg_mth_misc_amt_517 = WhereChq_reg_mth_misc_amt_517;
					_whereChq_reg_mth_misc_amt_518 = WhereChq_reg_mth_misc_amt_518;
					_whereChq_reg_mth_misc_amt_61 = WhereChq_reg_mth_misc_amt_61;
					_whereChq_reg_mth_misc_amt_62 = WhereChq_reg_mth_misc_amt_62;
					_whereChq_reg_mth_misc_amt_63 = WhereChq_reg_mth_misc_amt_63;
					_whereChq_reg_mth_misc_amt_64 = WhereChq_reg_mth_misc_amt_64;
					_whereChq_reg_mth_misc_amt_65 = WhereChq_reg_mth_misc_amt_65;
					_whereChq_reg_mth_misc_amt_66 = WhereChq_reg_mth_misc_amt_66;
					_whereChq_reg_mth_misc_amt_67 = WhereChq_reg_mth_misc_amt_67;
					_whereChq_reg_mth_misc_amt_68 = WhereChq_reg_mth_misc_amt_68;
					_whereChq_reg_mth_misc_amt_69 = WhereChq_reg_mth_misc_amt_69;
					_whereChq_reg_mth_misc_amt_610 = WhereChq_reg_mth_misc_amt_610;
					_whereChq_reg_mth_misc_amt_611 = WhereChq_reg_mth_misc_amt_611;
					_whereChq_reg_mth_misc_amt_612 = WhereChq_reg_mth_misc_amt_612;
					_whereChq_reg_mth_misc_amt_613 = WhereChq_reg_mth_misc_amt_613;
					_whereChq_reg_mth_misc_amt_614 = WhereChq_reg_mth_misc_amt_614;
					_whereChq_reg_mth_misc_amt_615 = WhereChq_reg_mth_misc_amt_615;
					_whereChq_reg_mth_misc_amt_616 = WhereChq_reg_mth_misc_amt_616;
					_whereChq_reg_mth_misc_amt_617 = WhereChq_reg_mth_misc_amt_617;
					_whereChq_reg_mth_misc_amt_618 = WhereChq_reg_mth_misc_amt_618;
					_whereChq_reg_mth_misc_amt_71 = WhereChq_reg_mth_misc_amt_71;
					_whereChq_reg_mth_misc_amt_72 = WhereChq_reg_mth_misc_amt_72;
					_whereChq_reg_mth_misc_amt_73 = WhereChq_reg_mth_misc_amt_73;
					_whereChq_reg_mth_misc_amt_74 = WhereChq_reg_mth_misc_amt_74;
					_whereChq_reg_mth_misc_amt_75 = WhereChq_reg_mth_misc_amt_75;
					_whereChq_reg_mth_misc_amt_76 = WhereChq_reg_mth_misc_amt_76;
					_whereChq_reg_mth_misc_amt_77 = WhereChq_reg_mth_misc_amt_77;
					_whereChq_reg_mth_misc_amt_78 = WhereChq_reg_mth_misc_amt_78;
					_whereChq_reg_mth_misc_amt_79 = WhereChq_reg_mth_misc_amt_79;
					_whereChq_reg_mth_misc_amt_710 = WhereChq_reg_mth_misc_amt_710;
					_whereChq_reg_mth_misc_amt_711 = WhereChq_reg_mth_misc_amt_711;
					_whereChq_reg_mth_misc_amt_712 = WhereChq_reg_mth_misc_amt_712;
					_whereChq_reg_mth_misc_amt_713 = WhereChq_reg_mth_misc_amt_713;
					_whereChq_reg_mth_misc_amt_714 = WhereChq_reg_mth_misc_amt_714;
					_whereChq_reg_mth_misc_amt_715 = WhereChq_reg_mth_misc_amt_715;
					_whereChq_reg_mth_misc_amt_716 = WhereChq_reg_mth_misc_amt_716;
					_whereChq_reg_mth_misc_amt_717 = WhereChq_reg_mth_misc_amt_717;
					_whereChq_reg_mth_misc_amt_718 = WhereChq_reg_mth_misc_amt_718;
					_whereChq_reg_mth_misc_amt_81 = WhereChq_reg_mth_misc_amt_81;
					_whereChq_reg_mth_misc_amt_82 = WhereChq_reg_mth_misc_amt_82;
					_whereChq_reg_mth_misc_amt_83 = WhereChq_reg_mth_misc_amt_83;
					_whereChq_reg_mth_misc_amt_84 = WhereChq_reg_mth_misc_amt_84;
					_whereChq_reg_mth_misc_amt_85 = WhereChq_reg_mth_misc_amt_85;
					_whereChq_reg_mth_misc_amt_86 = WhereChq_reg_mth_misc_amt_86;
					_whereChq_reg_mth_misc_amt_87 = WhereChq_reg_mth_misc_amt_87;
					_whereChq_reg_mth_misc_amt_88 = WhereChq_reg_mth_misc_amt_88;
					_whereChq_reg_mth_misc_amt_89 = WhereChq_reg_mth_misc_amt_89;
					_whereChq_reg_mth_misc_amt_810 = WhereChq_reg_mth_misc_amt_810;
					_whereChq_reg_mth_misc_amt_811 = WhereChq_reg_mth_misc_amt_811;
					_whereChq_reg_mth_misc_amt_812 = WhereChq_reg_mth_misc_amt_812;
					_whereChq_reg_mth_misc_amt_813 = WhereChq_reg_mth_misc_amt_813;
					_whereChq_reg_mth_misc_amt_814 = WhereChq_reg_mth_misc_amt_814;
					_whereChq_reg_mth_misc_amt_815 = WhereChq_reg_mth_misc_amt_815;
					_whereChq_reg_mth_misc_amt_816 = WhereChq_reg_mth_misc_amt_816;
					_whereChq_reg_mth_misc_amt_817 = WhereChq_reg_mth_misc_amt_817;
					_whereChq_reg_mth_misc_amt_818 = WhereChq_reg_mth_misc_amt_818;
					_whereChq_reg_mth_misc_amt_91 = WhereChq_reg_mth_misc_amt_91;
					_whereChq_reg_mth_misc_amt_92 = WhereChq_reg_mth_misc_amt_92;
					_whereChq_reg_mth_misc_amt_93 = WhereChq_reg_mth_misc_amt_93;
					_whereChq_reg_mth_misc_amt_94 = WhereChq_reg_mth_misc_amt_94;
					_whereChq_reg_mth_misc_amt_95 = WhereChq_reg_mth_misc_amt_95;
					_whereChq_reg_mth_misc_amt_96 = WhereChq_reg_mth_misc_amt_96;
					_whereChq_reg_mth_misc_amt_97 = WhereChq_reg_mth_misc_amt_97;
					_whereChq_reg_mth_misc_amt_98 = WhereChq_reg_mth_misc_amt_98;
					_whereChq_reg_mth_misc_amt_99 = WhereChq_reg_mth_misc_amt_99;
					_whereChq_reg_mth_misc_amt_910 = WhereChq_reg_mth_misc_amt_910;
					_whereChq_reg_mth_misc_amt_911 = WhereChq_reg_mth_misc_amt_911;
					_whereChq_reg_mth_misc_amt_912 = WhereChq_reg_mth_misc_amt_912;
					_whereChq_reg_mth_misc_amt_913 = WhereChq_reg_mth_misc_amt_913;
					_whereChq_reg_mth_misc_amt_914 = WhereChq_reg_mth_misc_amt_914;
					_whereChq_reg_mth_misc_amt_915 = WhereChq_reg_mth_misc_amt_915;
					_whereChq_reg_mth_misc_amt_916 = WhereChq_reg_mth_misc_amt_916;
					_whereChq_reg_mth_misc_amt_917 = WhereChq_reg_mth_misc_amt_917;
					_whereChq_reg_mth_misc_amt_918 = WhereChq_reg_mth_misc_amt_918;
					_whereChq_reg_mth_misc_amt_101 = WhereChq_reg_mth_misc_amt_101;
					_whereChq_reg_mth_misc_amt_102 = WhereChq_reg_mth_misc_amt_102;
					_whereChq_reg_mth_misc_amt_103 = WhereChq_reg_mth_misc_amt_103;
					_whereChq_reg_mth_misc_amt_104 = WhereChq_reg_mth_misc_amt_104;
					_whereChq_reg_mth_misc_amt_105 = WhereChq_reg_mth_misc_amt_105;
					_whereChq_reg_mth_misc_amt_106 = WhereChq_reg_mth_misc_amt_106;
					_whereChq_reg_mth_misc_amt_107 = WhereChq_reg_mth_misc_amt_107;
					_whereChq_reg_mth_misc_amt_108 = WhereChq_reg_mth_misc_amt_108;
					_whereChq_reg_mth_misc_amt_109 = WhereChq_reg_mth_misc_amt_109;
					_whereChq_reg_mth_misc_amt_1010 = WhereChq_reg_mth_misc_amt_1010;
					_whereChq_reg_mth_misc_amt_1011 = WhereChq_reg_mth_misc_amt_1011;
					_whereChq_reg_mth_misc_amt_1012 = WhereChq_reg_mth_misc_amt_1012;
					_whereChq_reg_mth_misc_amt_1013 = WhereChq_reg_mth_misc_amt_1013;
					_whereChq_reg_mth_misc_amt_1014 = WhereChq_reg_mth_misc_amt_1014;
					_whereChq_reg_mth_misc_amt_1015 = WhereChq_reg_mth_misc_amt_1015;
					_whereChq_reg_mth_misc_amt_1016 = WhereChq_reg_mth_misc_amt_1016;
					_whereChq_reg_mth_misc_amt_1017 = WhereChq_reg_mth_misc_amt_1017;
					_whereChq_reg_mth_misc_amt_1018 = WhereChq_reg_mth_misc_amt_1018;
					_whereChq_reg_mth_exp_amt1 = WhereChq_reg_mth_exp_amt1;
					_whereChq_reg_mth_exp_amt2 = WhereChq_reg_mth_exp_amt2;
					_whereChq_reg_mth_exp_amt3 = WhereChq_reg_mth_exp_amt3;
					_whereChq_reg_mth_exp_amt4 = WhereChq_reg_mth_exp_amt4;
					_whereChq_reg_mth_exp_amt5 = WhereChq_reg_mth_exp_amt5;
					_whereChq_reg_mth_exp_amt6 = WhereChq_reg_mth_exp_amt6;
					_whereChq_reg_mth_exp_amt7 = WhereChq_reg_mth_exp_amt7;
					_whereChq_reg_mth_exp_amt8 = WhereChq_reg_mth_exp_amt8;
					_whereChq_reg_mth_exp_amt9 = WhereChq_reg_mth_exp_amt9;
					_whereChq_reg_mth_exp_amt10 = WhereChq_reg_mth_exp_amt10;
					_whereChq_reg_mth_exp_amt11 = WhereChq_reg_mth_exp_amt11;
					_whereChq_reg_mth_exp_amt12 = WhereChq_reg_mth_exp_amt12;
					_whereChq_reg_mth_exp_amt13 = WhereChq_reg_mth_exp_amt13;
					_whereChq_reg_mth_exp_amt14 = WhereChq_reg_mth_exp_amt14;
					_whereChq_reg_mth_exp_amt15 = WhereChq_reg_mth_exp_amt15;
					_whereChq_reg_mth_exp_amt16 = WhereChq_reg_mth_exp_amt16;
					_whereChq_reg_mth_exp_amt17 = WhereChq_reg_mth_exp_amt17;
					_whereChq_reg_mth_exp_amt18 = WhereChq_reg_mth_exp_amt18;
					_whereChq_reg_comp_ann_exp_this_pay1 = WhereChq_reg_comp_ann_exp_this_pay1;
					_whereChq_reg_comp_ann_exp_this_pay2 = WhereChq_reg_comp_ann_exp_this_pay2;
					_whereChq_reg_comp_ann_exp_this_pay3 = WhereChq_reg_comp_ann_exp_this_pay3;
					_whereChq_reg_comp_ann_exp_this_pay4 = WhereChq_reg_comp_ann_exp_this_pay4;
					_whereChq_reg_comp_ann_exp_this_pay5 = WhereChq_reg_comp_ann_exp_this_pay5;
					_whereChq_reg_comp_ann_exp_this_pay6 = WhereChq_reg_comp_ann_exp_this_pay6;
					_whereChq_reg_comp_ann_exp_this_pay7 = WhereChq_reg_comp_ann_exp_this_pay7;
					_whereChq_reg_comp_ann_exp_this_pay8 = WhereChq_reg_comp_ann_exp_this_pay8;
					_whereChq_reg_comp_ann_exp_this_pay9 = WhereChq_reg_comp_ann_exp_this_pay9;
					_whereChq_reg_comp_ann_exp_this_pay10 = WhereChq_reg_comp_ann_exp_this_pay10;
					_whereChq_reg_comp_ann_exp_this_pay11 = WhereChq_reg_comp_ann_exp_this_pay11;
					_whereChq_reg_comp_ann_exp_this_pay12 = WhereChq_reg_comp_ann_exp_this_pay12;
					_whereChq_reg_comp_ann_exp_this_pay13 = WhereChq_reg_comp_ann_exp_this_pay13;
					_whereChq_reg_comp_ann_exp_this_pay14 = WhereChq_reg_comp_ann_exp_this_pay14;
					_whereChq_reg_comp_ann_exp_this_pay15 = WhereChq_reg_comp_ann_exp_this_pay15;
					_whereChq_reg_comp_ann_exp_this_pay16 = WhereChq_reg_comp_ann_exp_this_pay16;
					_whereChq_reg_comp_ann_exp_this_pay17 = WhereChq_reg_comp_ann_exp_this_pay17;
					_whereChq_reg_comp_ann_exp_this_pay18 = WhereChq_reg_comp_ann_exp_this_pay18;
					_whereChq_reg_mth_ceil_amt1 = WhereChq_reg_mth_ceil_amt1;
					_whereChq_reg_mth_ceil_amt2 = WhereChq_reg_mth_ceil_amt2;
					_whereChq_reg_mth_ceil_amt3 = WhereChq_reg_mth_ceil_amt3;
					_whereChq_reg_mth_ceil_amt4 = WhereChq_reg_mth_ceil_amt4;
					_whereChq_reg_mth_ceil_amt5 = WhereChq_reg_mth_ceil_amt5;
					_whereChq_reg_mth_ceil_amt6 = WhereChq_reg_mth_ceil_amt6;
					_whereChq_reg_mth_ceil_amt7 = WhereChq_reg_mth_ceil_amt7;
					_whereChq_reg_mth_ceil_amt8 = WhereChq_reg_mth_ceil_amt8;
					_whereChq_reg_mth_ceil_amt9 = WhereChq_reg_mth_ceil_amt9;
					_whereChq_reg_mth_ceil_amt10 = WhereChq_reg_mth_ceil_amt10;
					_whereChq_reg_mth_ceil_amt11 = WhereChq_reg_mth_ceil_amt11;
					_whereChq_reg_mth_ceil_amt12 = WhereChq_reg_mth_ceil_amt12;
					_whereChq_reg_mth_ceil_amt13 = WhereChq_reg_mth_ceil_amt13;
					_whereChq_reg_mth_ceil_amt14 = WhereChq_reg_mth_ceil_amt14;
					_whereChq_reg_mth_ceil_amt15 = WhereChq_reg_mth_ceil_amt15;
					_whereChq_reg_mth_ceil_amt16 = WhereChq_reg_mth_ceil_amt16;
					_whereChq_reg_mth_ceil_amt17 = WhereChq_reg_mth_ceil_amt17;
					_whereChq_reg_mth_ceil_amt18 = WhereChq_reg_mth_ceil_amt18;
					_whereChq_reg_comp_ann_ceil_this_pay1 = WhereChq_reg_comp_ann_ceil_this_pay1;
					_whereChq_reg_comp_ann_ceil_this_pay2 = WhereChq_reg_comp_ann_ceil_this_pay2;
					_whereChq_reg_comp_ann_ceil_this_pay3 = WhereChq_reg_comp_ann_ceil_this_pay3;
					_whereChq_reg_comp_ann_ceil_this_pay4 = WhereChq_reg_comp_ann_ceil_this_pay4;
					_whereChq_reg_comp_ann_ceil_this_pay5 = WhereChq_reg_comp_ann_ceil_this_pay5;
					_whereChq_reg_comp_ann_ceil_this_pay6 = WhereChq_reg_comp_ann_ceil_this_pay6;
					_whereChq_reg_comp_ann_ceil_this_pay7 = WhereChq_reg_comp_ann_ceil_this_pay7;
					_whereChq_reg_comp_ann_ceil_this_pay8 = WhereChq_reg_comp_ann_ceil_this_pay8;
					_whereChq_reg_comp_ann_ceil_this_pay9 = WhereChq_reg_comp_ann_ceil_this_pay9;
					_whereChq_reg_comp_ann_ceil_this_pay10 = WhereChq_reg_comp_ann_ceil_this_pay10;
					_whereChq_reg_comp_ann_ceil_this_pay11 = WhereChq_reg_comp_ann_ceil_this_pay11;
					_whereChq_reg_comp_ann_ceil_this_pay12 = WhereChq_reg_comp_ann_ceil_this_pay12;
					_whereChq_reg_comp_ann_ceil_this_pay13 = WhereChq_reg_comp_ann_ceil_this_pay13;
					_whereChq_reg_comp_ann_ceil_this_pay14 = WhereChq_reg_comp_ann_ceil_this_pay14;
					_whereChq_reg_comp_ann_ceil_this_pay15 = WhereChq_reg_comp_ann_ceil_this_pay15;
					_whereChq_reg_comp_ann_ceil_this_pay16 = WhereChq_reg_comp_ann_ceil_this_pay16;
					_whereChq_reg_comp_ann_ceil_this_pay17 = WhereChq_reg_comp_ann_ceil_this_pay17;
					_whereChq_reg_comp_ann_ceil_this_pay18 = WhereChq_reg_comp_ann_ceil_this_pay18;
					_whereChq_reg_earnings_this_mth1 = WhereChq_reg_earnings_this_mth1;
					_whereChq_reg_earnings_this_mth2 = WhereChq_reg_earnings_this_mth2;
					_whereChq_reg_earnings_this_mth3 = WhereChq_reg_earnings_this_mth3;
					_whereChq_reg_earnings_this_mth4 = WhereChq_reg_earnings_this_mth4;
					_whereChq_reg_earnings_this_mth5 = WhereChq_reg_earnings_this_mth5;
					_whereChq_reg_earnings_this_mth6 = WhereChq_reg_earnings_this_mth6;
					_whereChq_reg_earnings_this_mth7 = WhereChq_reg_earnings_this_mth7;
					_whereChq_reg_earnings_this_mth8 = WhereChq_reg_earnings_this_mth8;
					_whereChq_reg_earnings_this_mth9 = WhereChq_reg_earnings_this_mth9;
					_whereChq_reg_earnings_this_mth10 = WhereChq_reg_earnings_this_mth10;
					_whereChq_reg_earnings_this_mth11 = WhereChq_reg_earnings_this_mth11;
					_whereChq_reg_earnings_this_mth12 = WhereChq_reg_earnings_this_mth12;
					_whereChq_reg_earnings_this_mth13 = WhereChq_reg_earnings_this_mth13;
					_whereChq_reg_earnings_this_mth14 = WhereChq_reg_earnings_this_mth14;
					_whereChq_reg_earnings_this_mth15 = WhereChq_reg_earnings_this_mth15;
					_whereChq_reg_earnings_this_mth16 = WhereChq_reg_earnings_this_mth16;
					_whereChq_reg_earnings_this_mth17 = WhereChq_reg_earnings_this_mth17;
					_whereChq_reg_earnings_this_mth18 = WhereChq_reg_earnings_this_mth18;
					_whereChq_reg_regular_pay_this_mth1 = WhereChq_reg_regular_pay_this_mth1;
					_whereChq_reg_regular_pay_this_mth2 = WhereChq_reg_regular_pay_this_mth2;
					_whereChq_reg_regular_pay_this_mth3 = WhereChq_reg_regular_pay_this_mth3;
					_whereChq_reg_regular_pay_this_mth4 = WhereChq_reg_regular_pay_this_mth4;
					_whereChq_reg_regular_pay_this_mth5 = WhereChq_reg_regular_pay_this_mth5;
					_whereChq_reg_regular_pay_this_mth6 = WhereChq_reg_regular_pay_this_mth6;
					_whereChq_reg_regular_pay_this_mth7 = WhereChq_reg_regular_pay_this_mth7;
					_whereChq_reg_regular_pay_this_mth8 = WhereChq_reg_regular_pay_this_mth8;
					_whereChq_reg_regular_pay_this_mth9 = WhereChq_reg_regular_pay_this_mth9;
					_whereChq_reg_regular_pay_this_mth10 = WhereChq_reg_regular_pay_this_mth10;
					_whereChq_reg_regular_pay_this_mth11 = WhereChq_reg_regular_pay_this_mth11;
					_whereChq_reg_regular_pay_this_mth12 = WhereChq_reg_regular_pay_this_mth12;
					_whereChq_reg_regular_pay_this_mth13 = WhereChq_reg_regular_pay_this_mth13;
					_whereChq_reg_regular_pay_this_mth14 = WhereChq_reg_regular_pay_this_mth14;
					_whereChq_reg_regular_pay_this_mth15 = WhereChq_reg_regular_pay_this_mth15;
					_whereChq_reg_regular_pay_this_mth16 = WhereChq_reg_regular_pay_this_mth16;
					_whereChq_reg_regular_pay_this_mth17 = WhereChq_reg_regular_pay_this_mth17;
					_whereChq_reg_regular_pay_this_mth18 = WhereChq_reg_regular_pay_this_mth18;
					_whereChq_reg_regular_tax_this_mth1 = WhereChq_reg_regular_tax_this_mth1;
					_whereChq_reg_regular_tax_this_mth2 = WhereChq_reg_regular_tax_this_mth2;
					_whereChq_reg_regular_tax_this_mth3 = WhereChq_reg_regular_tax_this_mth3;
					_whereChq_reg_regular_tax_this_mth4 = WhereChq_reg_regular_tax_this_mth4;
					_whereChq_reg_regular_tax_this_mth5 = WhereChq_reg_regular_tax_this_mth5;
					_whereChq_reg_regular_tax_this_mth6 = WhereChq_reg_regular_tax_this_mth6;
					_whereChq_reg_regular_tax_this_mth7 = WhereChq_reg_regular_tax_this_mth7;
					_whereChq_reg_regular_tax_this_mth8 = WhereChq_reg_regular_tax_this_mth8;
					_whereChq_reg_regular_tax_this_mth9 = WhereChq_reg_regular_tax_this_mth9;
					_whereChq_reg_regular_tax_this_mth10 = WhereChq_reg_regular_tax_this_mth10;
					_whereChq_reg_regular_tax_this_mth11 = WhereChq_reg_regular_tax_this_mth11;
					_whereChq_reg_regular_tax_this_mth12 = WhereChq_reg_regular_tax_this_mth12;
					_whereChq_reg_regular_tax_this_mth13 = WhereChq_reg_regular_tax_this_mth13;
					_whereChq_reg_regular_tax_this_mth14 = WhereChq_reg_regular_tax_this_mth14;
					_whereChq_reg_regular_tax_this_mth15 = WhereChq_reg_regular_tax_this_mth15;
					_whereChq_reg_regular_tax_this_mth16 = WhereChq_reg_regular_tax_this_mth16;
					_whereChq_reg_regular_tax_this_mth17 = WhereChq_reg_regular_tax_this_mth17;
					_whereChq_reg_regular_tax_this_mth18 = WhereChq_reg_regular_tax_this_mth18;
					_whereChq_reg_man_pay_this_mth1 = WhereChq_reg_man_pay_this_mth1;
					_whereChq_reg_man_pay_this_mth2 = WhereChq_reg_man_pay_this_mth2;
					_whereChq_reg_man_pay_this_mth3 = WhereChq_reg_man_pay_this_mth3;
					_whereChq_reg_man_pay_this_mth4 = WhereChq_reg_man_pay_this_mth4;
					_whereChq_reg_man_pay_this_mth5 = WhereChq_reg_man_pay_this_mth5;
					_whereChq_reg_man_pay_this_mth6 = WhereChq_reg_man_pay_this_mth6;
					_whereChq_reg_man_pay_this_mth7 = WhereChq_reg_man_pay_this_mth7;
					_whereChq_reg_man_pay_this_mth8 = WhereChq_reg_man_pay_this_mth8;
					_whereChq_reg_man_pay_this_mth9 = WhereChq_reg_man_pay_this_mth9;
					_whereChq_reg_man_pay_this_mth10 = WhereChq_reg_man_pay_this_mth10;
					_whereChq_reg_man_pay_this_mth11 = WhereChq_reg_man_pay_this_mth11;
					_whereChq_reg_man_pay_this_mth12 = WhereChq_reg_man_pay_this_mth12;
					_whereChq_reg_man_pay_this_mth13 = WhereChq_reg_man_pay_this_mth13;
					_whereChq_reg_man_pay_this_mth14 = WhereChq_reg_man_pay_this_mth14;
					_whereChq_reg_man_pay_this_mth15 = WhereChq_reg_man_pay_this_mth15;
					_whereChq_reg_man_pay_this_mth16 = WhereChq_reg_man_pay_this_mth16;
					_whereChq_reg_man_pay_this_mth17 = WhereChq_reg_man_pay_this_mth17;
					_whereChq_reg_man_pay_this_mth18 = WhereChq_reg_man_pay_this_mth18;
					_whereChq_reg_man_tax_this_mth1 = WhereChq_reg_man_tax_this_mth1;
					_whereChq_reg_man_tax_this_mth2 = WhereChq_reg_man_tax_this_mth2;
					_whereChq_reg_man_tax_this_mth3 = WhereChq_reg_man_tax_this_mth3;
					_whereChq_reg_man_tax_this_mth4 = WhereChq_reg_man_tax_this_mth4;
					_whereChq_reg_man_tax_this_mth5 = WhereChq_reg_man_tax_this_mth5;
					_whereChq_reg_man_tax_this_mth6 = WhereChq_reg_man_tax_this_mth6;
					_whereChq_reg_man_tax_this_mth7 = WhereChq_reg_man_tax_this_mth7;
					_whereChq_reg_man_tax_this_mth8 = WhereChq_reg_man_tax_this_mth8;
					_whereChq_reg_man_tax_this_mth9 = WhereChq_reg_man_tax_this_mth9;
					_whereChq_reg_man_tax_this_mth10 = WhereChq_reg_man_tax_this_mth10;
					_whereChq_reg_man_tax_this_mth11 = WhereChq_reg_man_tax_this_mth11;
					_whereChq_reg_man_tax_this_mth12 = WhereChq_reg_man_tax_this_mth12;
					_whereChq_reg_man_tax_this_mth13 = WhereChq_reg_man_tax_this_mth13;
					_whereChq_reg_man_tax_this_mth14 = WhereChq_reg_man_tax_this_mth14;
					_whereChq_reg_man_tax_this_mth15 = WhereChq_reg_man_tax_this_mth15;
					_whereChq_reg_man_tax_this_mth16 = WhereChq_reg_man_tax_this_mth16;
					_whereChq_reg_man_tax_this_mth17 = WhereChq_reg_man_tax_this_mth17;
					_whereChq_reg_man_tax_this_mth18 = WhereChq_reg_man_tax_this_mth18;
					_whereChq_reg_pay_date1 = WhereChq_reg_pay_date1;
					_whereChq_reg_pay_date2 = WhereChq_reg_pay_date2;
					_whereChq_reg_pay_date3 = WhereChq_reg_pay_date3;
					_whereChq_reg_pay_date4 = WhereChq_reg_pay_date4;
					_whereChq_reg_pay_date5 = WhereChq_reg_pay_date5;
					_whereChq_reg_pay_date6 = WhereChq_reg_pay_date6;
					_whereChq_reg_pay_date7 = WhereChq_reg_pay_date7;
					_whereChq_reg_pay_date8 = WhereChq_reg_pay_date8;
					_whereChq_reg_pay_date9 = WhereChq_reg_pay_date9;
					_whereChq_reg_pay_date10 = WhereChq_reg_pay_date10;
					_whereChq_reg_pay_date11 = WhereChq_reg_pay_date11;
					_whereChq_reg_pay_date12 = WhereChq_reg_pay_date12;
					_whereChq_reg_pay_date13 = WhereChq_reg_pay_date13;
					_whereChq_reg_pay_date14 = WhereChq_reg_pay_date14;
					_whereChq_reg_pay_date15 = WhereChq_reg_pay_date15;
					_whereChq_reg_pay_date16 = WhereChq_reg_pay_date16;
					_whereChq_reg_pay_date17 = WhereChq_reg_pay_date17;
					_whereChq_reg_pay_date18 = WhereChq_reg_pay_date18;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereChq_reg_clinic_nbr_1_2 == null 
				&& WhereChq_reg_dept == null 
				&& WhereChq_reg_doc_nbr == null 
				&& WhereChq_reg_perc_bill1 == null 
				&& WhereChq_reg_perc_bill2 == null 
				&& WhereChq_reg_perc_bill3 == null 
				&& WhereChq_reg_perc_bill4 == null 
				&& WhereChq_reg_perc_bill5 == null 
				&& WhereChq_reg_perc_bill6 == null 
				&& WhereChq_reg_perc_bill7 == null 
				&& WhereChq_reg_perc_bill8 == null 
				&& WhereChq_reg_perc_bill9 == null 
				&& WhereChq_reg_perc_bill10 == null 
				&& WhereChq_reg_perc_bill11 == null 
				&& WhereChq_reg_perc_bill12 == null 
				&& WhereChq_reg_perc_bill13 == null 
				&& WhereChq_reg_perc_bill14 == null 
				&& WhereChq_reg_perc_bill15 == null 
				&& WhereChq_reg_perc_bill16 == null 
				&& WhereChq_reg_perc_bill17 == null 
				&& WhereChq_reg_perc_bill18 == null 
				&& WhereChq_reg_perc_misc1 == null 
				&& WhereChq_reg_perc_misc2 == null 
				&& WhereChq_reg_perc_misc3 == null 
				&& WhereChq_reg_perc_misc4 == null 
				&& WhereChq_reg_perc_misc5 == null 
				&& WhereChq_reg_perc_misc6 == null 
				&& WhereChq_reg_perc_misc7 == null 
				&& WhereChq_reg_perc_misc8 == null 
				&& WhereChq_reg_perc_misc9 == null 
				&& WhereChq_reg_perc_misc10 == null 
				&& WhereChq_reg_perc_misc11 == null 
				&& WhereChq_reg_perc_misc12 == null 
				&& WhereChq_reg_perc_misc13 == null 
				&& WhereChq_reg_perc_misc14 == null 
				&& WhereChq_reg_perc_misc15 == null 
				&& WhereChq_reg_perc_misc16 == null 
				&& WhereChq_reg_perc_misc17 == null 
				&& WhereChq_reg_perc_misc18 == null 
				&& WhereChq_reg_pay_code1 == null 
				&& WhereChq_reg_pay_code2 == null 
				&& WhereChq_reg_pay_code3 == null 
				&& WhereChq_reg_pay_code4 == null 
				&& WhereChq_reg_pay_code5 == null 
				&& WhereChq_reg_pay_code6 == null 
				&& WhereChq_reg_pay_code7 == null 
				&& WhereChq_reg_pay_code8 == null 
				&& WhereChq_reg_pay_code9 == null 
				&& WhereChq_reg_pay_code10 == null 
				&& WhereChq_reg_pay_code11 == null 
				&& WhereChq_reg_pay_code12 == null 
				&& WhereChq_reg_pay_code13 == null 
				&& WhereChq_reg_pay_code14 == null 
				&& WhereChq_reg_pay_code15 == null 
				&& WhereChq_reg_pay_code16 == null 
				&& WhereChq_reg_pay_code17 == null 
				&& WhereChq_reg_pay_code18 == null 
				&& WhereChq_reg_perc_tax1 == null 
				&& WhereChq_reg_perc_tax2 == null 
				&& WhereChq_reg_perc_tax3 == null 
				&& WhereChq_reg_perc_tax4 == null 
				&& WhereChq_reg_perc_tax5 == null 
				&& WhereChq_reg_perc_tax6 == null 
				&& WhereChq_reg_perc_tax7 == null 
				&& WhereChq_reg_perc_tax8 == null 
				&& WhereChq_reg_perc_tax9 == null 
				&& WhereChq_reg_perc_tax10 == null 
				&& WhereChq_reg_perc_tax11 == null 
				&& WhereChq_reg_perc_tax12 == null 
				&& WhereChq_reg_perc_tax13 == null 
				&& WhereChq_reg_perc_tax14 == null 
				&& WhereChq_reg_perc_tax15 == null 
				&& WhereChq_reg_perc_tax16 == null 
				&& WhereChq_reg_perc_tax17 == null 
				&& WhereChq_reg_perc_tax18 == null 
				&& WhereChq_reg_mth_bill_amt1 == null 
				&& WhereChq_reg_mth_bill_amt2 == null 
				&& WhereChq_reg_mth_bill_amt3 == null 
				&& WhereChq_reg_mth_bill_amt4 == null 
				&& WhereChq_reg_mth_bill_amt5 == null 
				&& WhereChq_reg_mth_bill_amt6 == null 
				&& WhereChq_reg_mth_bill_amt7 == null 
				&& WhereChq_reg_mth_bill_amt8 == null 
				&& WhereChq_reg_mth_bill_amt9 == null 
				&& WhereChq_reg_mth_bill_amt10 == null 
				&& WhereChq_reg_mth_bill_amt11 == null 
				&& WhereChq_reg_mth_bill_amt12 == null 
				&& WhereChq_reg_mth_bill_amt13 == null 
				&& WhereChq_reg_mth_bill_amt14 == null 
				&& WhereChq_reg_mth_bill_amt15 == null 
				&& WhereChq_reg_mth_bill_amt16 == null 
				&& WhereChq_reg_mth_bill_amt17 == null 
				&& WhereChq_reg_mth_bill_amt18 == null 
				&& WhereChq_reg_mth_misc_amt_11 == null 
				&& WhereChq_reg_mth_misc_amt_12 == null 
				&& WhereChq_reg_mth_misc_amt_13 == null 
				&& WhereChq_reg_mth_misc_amt_14 == null 
				&& WhereChq_reg_mth_misc_amt_15 == null 
				&& WhereChq_reg_mth_misc_amt_16 == null 
				&& WhereChq_reg_mth_misc_amt_17 == null 
				&& WhereChq_reg_mth_misc_amt_18 == null 
				&& WhereChq_reg_mth_misc_amt_19 == null 
				&& WhereChq_reg_mth_misc_amt_110 == null 
				&& WhereChq_reg_mth_misc_amt_111 == null 
				&& WhereChq_reg_mth_misc_amt_112 == null 
				&& WhereChq_reg_mth_misc_amt_113 == null 
				&& WhereChq_reg_mth_misc_amt_114 == null 
				&& WhereChq_reg_mth_misc_amt_115 == null 
				&& WhereChq_reg_mth_misc_amt_116 == null 
				&& WhereChq_reg_mth_misc_amt_117 == null 
				&& WhereChq_reg_mth_misc_amt_118 == null 
				&& WhereChq_reg_mth_misc_amt_21 == null 
				&& WhereChq_reg_mth_misc_amt_22 == null 
				&& WhereChq_reg_mth_misc_amt_23 == null 
				&& WhereChq_reg_mth_misc_amt_24 == null 
				&& WhereChq_reg_mth_misc_amt_25 == null 
				&& WhereChq_reg_mth_misc_amt_26 == null 
				&& WhereChq_reg_mth_misc_amt_27 == null 
				&& WhereChq_reg_mth_misc_amt_28 == null 
				&& WhereChq_reg_mth_misc_amt_29 == null 
				&& WhereChq_reg_mth_misc_amt_210 == null 
				&& WhereChq_reg_mth_misc_amt_211 == null 
				&& WhereChq_reg_mth_misc_amt_212 == null 
				&& WhereChq_reg_mth_misc_amt_213 == null 
				&& WhereChq_reg_mth_misc_amt_214 == null 
				&& WhereChq_reg_mth_misc_amt_215 == null 
				&& WhereChq_reg_mth_misc_amt_216 == null 
				&& WhereChq_reg_mth_misc_amt_217 == null 
				&& WhereChq_reg_mth_misc_amt_218 == null 
				&& WhereChq_reg_mth_misc_amt_31 == null 
				&& WhereChq_reg_mth_misc_amt_32 == null 
				&& WhereChq_reg_mth_misc_amt_33 == null 
				&& WhereChq_reg_mth_misc_amt_34 == null 
				&& WhereChq_reg_mth_misc_amt_35 == null 
				&& WhereChq_reg_mth_misc_amt_36 == null 
				&& WhereChq_reg_mth_misc_amt_37 == null 
				&& WhereChq_reg_mth_misc_amt_38 == null 
				&& WhereChq_reg_mth_misc_amt_39 == null 
				&& WhereChq_reg_mth_misc_amt_310 == null 
				&& WhereChq_reg_mth_misc_amt_311 == null 
				&& WhereChq_reg_mth_misc_amt_312 == null 
				&& WhereChq_reg_mth_misc_amt_313 == null 
				&& WhereChq_reg_mth_misc_amt_314 == null 
				&& WhereChq_reg_mth_misc_amt_315 == null 
				&& WhereChq_reg_mth_misc_amt_316 == null 
				&& WhereChq_reg_mth_misc_amt_317 == null 
				&& WhereChq_reg_mth_misc_amt_318 == null 
				&& WhereChq_reg_mth_misc_amt_41 == null 
				&& WhereChq_reg_mth_misc_amt_42 == null 
				&& WhereChq_reg_mth_misc_amt_43 == null 
				&& WhereChq_reg_mth_misc_amt_44 == null 
				&& WhereChq_reg_mth_misc_amt_45 == null 
				&& WhereChq_reg_mth_misc_amt_46 == null 
				&& WhereChq_reg_mth_misc_amt_47 == null 
				&& WhereChq_reg_mth_misc_amt_48 == null 
				&& WhereChq_reg_mth_misc_amt_49 == null 
				&& WhereChq_reg_mth_misc_amt_410 == null 
				&& WhereChq_reg_mth_misc_amt_411 == null 
				&& WhereChq_reg_mth_misc_amt_412 == null 
				&& WhereChq_reg_mth_misc_amt_413 == null 
				&& WhereChq_reg_mth_misc_amt_414 == null 
				&& WhereChq_reg_mth_misc_amt_415 == null 
				&& WhereChq_reg_mth_misc_amt_416 == null 
				&& WhereChq_reg_mth_misc_amt_417 == null 
				&& WhereChq_reg_mth_misc_amt_418 == null 
				&& WhereChq_reg_mth_misc_amt_51 == null 
				&& WhereChq_reg_mth_misc_amt_52 == null 
				&& WhereChq_reg_mth_misc_amt_53 == null 
				&& WhereChq_reg_mth_misc_amt_54 == null 
				&& WhereChq_reg_mth_misc_amt_55 == null 
				&& WhereChq_reg_mth_misc_amt_56 == null 
				&& WhereChq_reg_mth_misc_amt_57 == null 
				&& WhereChq_reg_mth_misc_amt_58 == null 
				&& WhereChq_reg_mth_misc_amt_59 == null 
				&& WhereChq_reg_mth_misc_amt_510 == null 
				&& WhereChq_reg_mth_misc_amt_511 == null 
				&& WhereChq_reg_mth_misc_amt_512 == null 
				&& WhereChq_reg_mth_misc_amt_513 == null 
				&& WhereChq_reg_mth_misc_amt_514 == null 
				&& WhereChq_reg_mth_misc_amt_515 == null 
				&& WhereChq_reg_mth_misc_amt_516 == null 
				&& WhereChq_reg_mth_misc_amt_517 == null 
				&& WhereChq_reg_mth_misc_amt_518 == null 
				&& WhereChq_reg_mth_misc_amt_61 == null 
				&& WhereChq_reg_mth_misc_amt_62 == null 
				&& WhereChq_reg_mth_misc_amt_63 == null 
				&& WhereChq_reg_mth_misc_amt_64 == null 
				&& WhereChq_reg_mth_misc_amt_65 == null 
				&& WhereChq_reg_mth_misc_amt_66 == null 
				&& WhereChq_reg_mth_misc_amt_67 == null 
				&& WhereChq_reg_mth_misc_amt_68 == null 
				&& WhereChq_reg_mth_misc_amt_69 == null 
				&& WhereChq_reg_mth_misc_amt_610 == null 
				&& WhereChq_reg_mth_misc_amt_611 == null 
				&& WhereChq_reg_mth_misc_amt_612 == null 
				&& WhereChq_reg_mth_misc_amt_613 == null 
				&& WhereChq_reg_mth_misc_amt_614 == null 
				&& WhereChq_reg_mth_misc_amt_615 == null 
				&& WhereChq_reg_mth_misc_amt_616 == null 
				&& WhereChq_reg_mth_misc_amt_617 == null 
				&& WhereChq_reg_mth_misc_amt_618 == null 
				&& WhereChq_reg_mth_misc_amt_71 == null 
				&& WhereChq_reg_mth_misc_amt_72 == null 
				&& WhereChq_reg_mth_misc_amt_73 == null 
				&& WhereChq_reg_mth_misc_amt_74 == null 
				&& WhereChq_reg_mth_misc_amt_75 == null 
				&& WhereChq_reg_mth_misc_amt_76 == null 
				&& WhereChq_reg_mth_misc_amt_77 == null 
				&& WhereChq_reg_mth_misc_amt_78 == null 
				&& WhereChq_reg_mth_misc_amt_79 == null 
				&& WhereChq_reg_mth_misc_amt_710 == null 
				&& WhereChq_reg_mth_misc_amt_711 == null 
				&& WhereChq_reg_mth_misc_amt_712 == null 
				&& WhereChq_reg_mth_misc_amt_713 == null 
				&& WhereChq_reg_mth_misc_amt_714 == null 
				&& WhereChq_reg_mth_misc_amt_715 == null 
				&& WhereChq_reg_mth_misc_amt_716 == null 
				&& WhereChq_reg_mth_misc_amt_717 == null 
				&& WhereChq_reg_mth_misc_amt_718 == null 
				&& WhereChq_reg_mth_misc_amt_81 == null 
				&& WhereChq_reg_mth_misc_amt_82 == null 
				&& WhereChq_reg_mth_misc_amt_83 == null 
				&& WhereChq_reg_mth_misc_amt_84 == null 
				&& WhereChq_reg_mth_misc_amt_85 == null 
				&& WhereChq_reg_mth_misc_amt_86 == null 
				&& WhereChq_reg_mth_misc_amt_87 == null 
				&& WhereChq_reg_mth_misc_amt_88 == null 
				&& WhereChq_reg_mth_misc_amt_89 == null 
				&& WhereChq_reg_mth_misc_amt_810 == null 
				&& WhereChq_reg_mth_misc_amt_811 == null 
				&& WhereChq_reg_mth_misc_amt_812 == null 
				&& WhereChq_reg_mth_misc_amt_813 == null 
				&& WhereChq_reg_mth_misc_amt_814 == null 
				&& WhereChq_reg_mth_misc_amt_815 == null 
				&& WhereChq_reg_mth_misc_amt_816 == null 
				&& WhereChq_reg_mth_misc_amt_817 == null 
				&& WhereChq_reg_mth_misc_amt_818 == null 
				&& WhereChq_reg_mth_misc_amt_91 == null 
				&& WhereChq_reg_mth_misc_amt_92 == null 
				&& WhereChq_reg_mth_misc_amt_93 == null 
				&& WhereChq_reg_mth_misc_amt_94 == null 
				&& WhereChq_reg_mth_misc_amt_95 == null 
				&& WhereChq_reg_mth_misc_amt_96 == null 
				&& WhereChq_reg_mth_misc_amt_97 == null 
				&& WhereChq_reg_mth_misc_amt_98 == null 
				&& WhereChq_reg_mth_misc_amt_99 == null 
				&& WhereChq_reg_mth_misc_amt_910 == null 
				&& WhereChq_reg_mth_misc_amt_911 == null 
				&& WhereChq_reg_mth_misc_amt_912 == null 
				&& WhereChq_reg_mth_misc_amt_913 == null 
				&& WhereChq_reg_mth_misc_amt_914 == null 
				&& WhereChq_reg_mth_misc_amt_915 == null 
				&& WhereChq_reg_mth_misc_amt_916 == null 
				&& WhereChq_reg_mth_misc_amt_917 == null 
				&& WhereChq_reg_mth_misc_amt_918 == null 
				&& WhereChq_reg_mth_misc_amt_101 == null 
				&& WhereChq_reg_mth_misc_amt_102 == null 
				&& WhereChq_reg_mth_misc_amt_103 == null 
				&& WhereChq_reg_mth_misc_amt_104 == null 
				&& WhereChq_reg_mth_misc_amt_105 == null 
				&& WhereChq_reg_mth_misc_amt_106 == null 
				&& WhereChq_reg_mth_misc_amt_107 == null 
				&& WhereChq_reg_mth_misc_amt_108 == null 
				&& WhereChq_reg_mth_misc_amt_109 == null 
				&& WhereChq_reg_mth_misc_amt_1010 == null 
				&& WhereChq_reg_mth_misc_amt_1011 == null 
				&& WhereChq_reg_mth_misc_amt_1012 == null 
				&& WhereChq_reg_mth_misc_amt_1013 == null 
				&& WhereChq_reg_mth_misc_amt_1014 == null 
				&& WhereChq_reg_mth_misc_amt_1015 == null 
				&& WhereChq_reg_mth_misc_amt_1016 == null 
				&& WhereChq_reg_mth_misc_amt_1017 == null 
				&& WhereChq_reg_mth_misc_amt_1018 == null 
				&& WhereChq_reg_mth_exp_amt1 == null 
				&& WhereChq_reg_mth_exp_amt2 == null 
				&& WhereChq_reg_mth_exp_amt3 == null 
				&& WhereChq_reg_mth_exp_amt4 == null 
				&& WhereChq_reg_mth_exp_amt5 == null 
				&& WhereChq_reg_mth_exp_amt6 == null 
				&& WhereChq_reg_mth_exp_amt7 == null 
				&& WhereChq_reg_mth_exp_amt8 == null 
				&& WhereChq_reg_mth_exp_amt9 == null 
				&& WhereChq_reg_mth_exp_amt10 == null 
				&& WhereChq_reg_mth_exp_amt11 == null 
				&& WhereChq_reg_mth_exp_amt12 == null 
				&& WhereChq_reg_mth_exp_amt13 == null 
				&& WhereChq_reg_mth_exp_amt14 == null 
				&& WhereChq_reg_mth_exp_amt15 == null 
				&& WhereChq_reg_mth_exp_amt16 == null 
				&& WhereChq_reg_mth_exp_amt17 == null 
				&& WhereChq_reg_mth_exp_amt18 == null 
				&& WhereChq_reg_comp_ann_exp_this_pay1 == null 
				&& WhereChq_reg_comp_ann_exp_this_pay2 == null 
				&& WhereChq_reg_comp_ann_exp_this_pay3 == null 
				&& WhereChq_reg_comp_ann_exp_this_pay4 == null 
				&& WhereChq_reg_comp_ann_exp_this_pay5 == null 
				&& WhereChq_reg_comp_ann_exp_this_pay6 == null 
				&& WhereChq_reg_comp_ann_exp_this_pay7 == null 
				&& WhereChq_reg_comp_ann_exp_this_pay8 == null 
				&& WhereChq_reg_comp_ann_exp_this_pay9 == null 
				&& WhereChq_reg_comp_ann_exp_this_pay10 == null 
				&& WhereChq_reg_comp_ann_exp_this_pay11 == null 
				&& WhereChq_reg_comp_ann_exp_this_pay12 == null 
				&& WhereChq_reg_comp_ann_exp_this_pay13 == null 
				&& WhereChq_reg_comp_ann_exp_this_pay14 == null 
				&& WhereChq_reg_comp_ann_exp_this_pay15 == null 
				&& WhereChq_reg_comp_ann_exp_this_pay16 == null 
				&& WhereChq_reg_comp_ann_exp_this_pay17 == null 
				&& WhereChq_reg_comp_ann_exp_this_pay18 == null 
				&& WhereChq_reg_mth_ceil_amt1 == null 
				&& WhereChq_reg_mth_ceil_amt2 == null 
				&& WhereChq_reg_mth_ceil_amt3 == null 
				&& WhereChq_reg_mth_ceil_amt4 == null 
				&& WhereChq_reg_mth_ceil_amt5 == null 
				&& WhereChq_reg_mth_ceil_amt6 == null 
				&& WhereChq_reg_mth_ceil_amt7 == null 
				&& WhereChq_reg_mth_ceil_amt8 == null 
				&& WhereChq_reg_mth_ceil_amt9 == null 
				&& WhereChq_reg_mth_ceil_amt10 == null 
				&& WhereChq_reg_mth_ceil_amt11 == null 
				&& WhereChq_reg_mth_ceil_amt12 == null 
				&& WhereChq_reg_mth_ceil_amt13 == null 
				&& WhereChq_reg_mth_ceil_amt14 == null 
				&& WhereChq_reg_mth_ceil_amt15 == null 
				&& WhereChq_reg_mth_ceil_amt16 == null 
				&& WhereChq_reg_mth_ceil_amt17 == null 
				&& WhereChq_reg_mth_ceil_amt18 == null 
				&& WhereChq_reg_comp_ann_ceil_this_pay1 == null 
				&& WhereChq_reg_comp_ann_ceil_this_pay2 == null 
				&& WhereChq_reg_comp_ann_ceil_this_pay3 == null 
				&& WhereChq_reg_comp_ann_ceil_this_pay4 == null 
				&& WhereChq_reg_comp_ann_ceil_this_pay5 == null 
				&& WhereChq_reg_comp_ann_ceil_this_pay6 == null 
				&& WhereChq_reg_comp_ann_ceil_this_pay7 == null 
				&& WhereChq_reg_comp_ann_ceil_this_pay8 == null 
				&& WhereChq_reg_comp_ann_ceil_this_pay9 == null 
				&& WhereChq_reg_comp_ann_ceil_this_pay10 == null 
				&& WhereChq_reg_comp_ann_ceil_this_pay11 == null 
				&& WhereChq_reg_comp_ann_ceil_this_pay12 == null 
				&& WhereChq_reg_comp_ann_ceil_this_pay13 == null 
				&& WhereChq_reg_comp_ann_ceil_this_pay14 == null 
				&& WhereChq_reg_comp_ann_ceil_this_pay15 == null 
				&& WhereChq_reg_comp_ann_ceil_this_pay16 == null 
				&& WhereChq_reg_comp_ann_ceil_this_pay17 == null 
				&& WhereChq_reg_comp_ann_ceil_this_pay18 == null 
				&& WhereChq_reg_earnings_this_mth1 == null 
				&& WhereChq_reg_earnings_this_mth2 == null 
				&& WhereChq_reg_earnings_this_mth3 == null 
				&& WhereChq_reg_earnings_this_mth4 == null 
				&& WhereChq_reg_earnings_this_mth5 == null 
				&& WhereChq_reg_earnings_this_mth6 == null 
				&& WhereChq_reg_earnings_this_mth7 == null 
				&& WhereChq_reg_earnings_this_mth8 == null 
				&& WhereChq_reg_earnings_this_mth9 == null 
				&& WhereChq_reg_earnings_this_mth10 == null 
				&& WhereChq_reg_earnings_this_mth11 == null 
				&& WhereChq_reg_earnings_this_mth12 == null 
				&& WhereChq_reg_earnings_this_mth13 == null 
				&& WhereChq_reg_earnings_this_mth14 == null 
				&& WhereChq_reg_earnings_this_mth15 == null 
				&& WhereChq_reg_earnings_this_mth16 == null 
				&& WhereChq_reg_earnings_this_mth17 == null 
				&& WhereChq_reg_earnings_this_mth18 == null 
				&& WhereChq_reg_regular_pay_this_mth1 == null 
				&& WhereChq_reg_regular_pay_this_mth2 == null 
				&& WhereChq_reg_regular_pay_this_mth3 == null 
				&& WhereChq_reg_regular_pay_this_mth4 == null 
				&& WhereChq_reg_regular_pay_this_mth5 == null 
				&& WhereChq_reg_regular_pay_this_mth6 == null 
				&& WhereChq_reg_regular_pay_this_mth7 == null 
				&& WhereChq_reg_regular_pay_this_mth8 == null 
				&& WhereChq_reg_regular_pay_this_mth9 == null 
				&& WhereChq_reg_regular_pay_this_mth10 == null 
				&& WhereChq_reg_regular_pay_this_mth11 == null 
				&& WhereChq_reg_regular_pay_this_mth12 == null 
				&& WhereChq_reg_regular_pay_this_mth13 == null 
				&& WhereChq_reg_regular_pay_this_mth14 == null 
				&& WhereChq_reg_regular_pay_this_mth15 == null 
				&& WhereChq_reg_regular_pay_this_mth16 == null 
				&& WhereChq_reg_regular_pay_this_mth17 == null 
				&& WhereChq_reg_regular_pay_this_mth18 == null 
				&& WhereChq_reg_regular_tax_this_mth1 == null 
				&& WhereChq_reg_regular_tax_this_mth2 == null 
				&& WhereChq_reg_regular_tax_this_mth3 == null 
				&& WhereChq_reg_regular_tax_this_mth4 == null 
				&& WhereChq_reg_regular_tax_this_mth5 == null 
				&& WhereChq_reg_regular_tax_this_mth6 == null 
				&& WhereChq_reg_regular_tax_this_mth7 == null 
				&& WhereChq_reg_regular_tax_this_mth8 == null 
				&& WhereChq_reg_regular_tax_this_mth9 == null 
				&& WhereChq_reg_regular_tax_this_mth10 == null 
				&& WhereChq_reg_regular_tax_this_mth11 == null 
				&& WhereChq_reg_regular_tax_this_mth12 == null 
				&& WhereChq_reg_regular_tax_this_mth13 == null 
				&& WhereChq_reg_regular_tax_this_mth14 == null 
				&& WhereChq_reg_regular_tax_this_mth15 == null 
				&& WhereChq_reg_regular_tax_this_mth16 == null 
				&& WhereChq_reg_regular_tax_this_mth17 == null 
				&& WhereChq_reg_regular_tax_this_mth18 == null 
				&& WhereChq_reg_man_pay_this_mth1 == null 
				&& WhereChq_reg_man_pay_this_mth2 == null 
				&& WhereChq_reg_man_pay_this_mth3 == null 
				&& WhereChq_reg_man_pay_this_mth4 == null 
				&& WhereChq_reg_man_pay_this_mth5 == null 
				&& WhereChq_reg_man_pay_this_mth6 == null 
				&& WhereChq_reg_man_pay_this_mth7 == null 
				&& WhereChq_reg_man_pay_this_mth8 == null 
				&& WhereChq_reg_man_pay_this_mth9 == null 
				&& WhereChq_reg_man_pay_this_mth10 == null 
				&& WhereChq_reg_man_pay_this_mth11 == null 
				&& WhereChq_reg_man_pay_this_mth12 == null 
				&& WhereChq_reg_man_pay_this_mth13 == null 
				&& WhereChq_reg_man_pay_this_mth14 == null 
				&& WhereChq_reg_man_pay_this_mth15 == null 
				&& WhereChq_reg_man_pay_this_mth16 == null 
				&& WhereChq_reg_man_pay_this_mth17 == null 
				&& WhereChq_reg_man_pay_this_mth18 == null 
				&& WhereChq_reg_man_tax_this_mth1 == null 
				&& WhereChq_reg_man_tax_this_mth2 == null 
				&& WhereChq_reg_man_tax_this_mth3 == null 
				&& WhereChq_reg_man_tax_this_mth4 == null 
				&& WhereChq_reg_man_tax_this_mth5 == null 
				&& WhereChq_reg_man_tax_this_mth6 == null 
				&& WhereChq_reg_man_tax_this_mth7 == null 
				&& WhereChq_reg_man_tax_this_mth8 == null 
				&& WhereChq_reg_man_tax_this_mth9 == null 
				&& WhereChq_reg_man_tax_this_mth10 == null 
				&& WhereChq_reg_man_tax_this_mth11 == null 
				&& WhereChq_reg_man_tax_this_mth12 == null 
				&& WhereChq_reg_man_tax_this_mth13 == null 
				&& WhereChq_reg_man_tax_this_mth14 == null 
				&& WhereChq_reg_man_tax_this_mth15 == null 
				&& WhereChq_reg_man_tax_this_mth16 == null 
				&& WhereChq_reg_man_tax_this_mth17 == null 
				&& WhereChq_reg_man_tax_this_mth18 == null 
				&& WhereChq_reg_pay_date1 == null 
				&& WhereChq_reg_pay_date2 == null 
				&& WhereChq_reg_pay_date3 == null 
				&& WhereChq_reg_pay_date4 == null 
				&& WhereChq_reg_pay_date5 == null 
				&& WhereChq_reg_pay_date6 == null 
				&& WhereChq_reg_pay_date7 == null 
				&& WhereChq_reg_pay_date8 == null 
				&& WhereChq_reg_pay_date9 == null 
				&& WhereChq_reg_pay_date10 == null 
				&& WhereChq_reg_pay_date11 == null 
				&& WhereChq_reg_pay_date12 == null 
				&& WhereChq_reg_pay_date13 == null 
				&& WhereChq_reg_pay_date14 == null 
				&& WhereChq_reg_pay_date15 == null 
				&& WhereChq_reg_pay_date16 == null 
				&& WhereChq_reg_pay_date17 == null 
				&& WhereChq_reg_pay_date18 == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereChq_reg_clinic_nbr_1_2 ==  _whereChq_reg_clinic_nbr_1_2
				&& WhereChq_reg_dept ==  _whereChq_reg_dept
				&& WhereChq_reg_doc_nbr ==  _whereChq_reg_doc_nbr
				&& WhereChq_reg_perc_bill1 ==  _whereChq_reg_perc_bill1
				&& WhereChq_reg_perc_bill2 ==  _whereChq_reg_perc_bill2
				&& WhereChq_reg_perc_bill3 ==  _whereChq_reg_perc_bill3
				&& WhereChq_reg_perc_bill4 ==  _whereChq_reg_perc_bill4
				&& WhereChq_reg_perc_bill5 ==  _whereChq_reg_perc_bill5
				&& WhereChq_reg_perc_bill6 ==  _whereChq_reg_perc_bill6
				&& WhereChq_reg_perc_bill7 ==  _whereChq_reg_perc_bill7
				&& WhereChq_reg_perc_bill8 ==  _whereChq_reg_perc_bill8
				&& WhereChq_reg_perc_bill9 ==  _whereChq_reg_perc_bill9
				&& WhereChq_reg_perc_bill10 ==  _whereChq_reg_perc_bill10
				&& WhereChq_reg_perc_bill11 ==  _whereChq_reg_perc_bill11
				&& WhereChq_reg_perc_bill12 ==  _whereChq_reg_perc_bill12
				&& WhereChq_reg_perc_bill13 ==  _whereChq_reg_perc_bill13
				&& WhereChq_reg_perc_bill14 ==  _whereChq_reg_perc_bill14
				&& WhereChq_reg_perc_bill15 ==  _whereChq_reg_perc_bill15
				&& WhereChq_reg_perc_bill16 ==  _whereChq_reg_perc_bill16
				&& WhereChq_reg_perc_bill17 ==  _whereChq_reg_perc_bill17
				&& WhereChq_reg_perc_bill18 ==  _whereChq_reg_perc_bill18
				&& WhereChq_reg_perc_misc1 ==  _whereChq_reg_perc_misc1
				&& WhereChq_reg_perc_misc2 ==  _whereChq_reg_perc_misc2
				&& WhereChq_reg_perc_misc3 ==  _whereChq_reg_perc_misc3
				&& WhereChq_reg_perc_misc4 ==  _whereChq_reg_perc_misc4
				&& WhereChq_reg_perc_misc5 ==  _whereChq_reg_perc_misc5
				&& WhereChq_reg_perc_misc6 ==  _whereChq_reg_perc_misc6
				&& WhereChq_reg_perc_misc7 ==  _whereChq_reg_perc_misc7
				&& WhereChq_reg_perc_misc8 ==  _whereChq_reg_perc_misc8
				&& WhereChq_reg_perc_misc9 ==  _whereChq_reg_perc_misc9
				&& WhereChq_reg_perc_misc10 ==  _whereChq_reg_perc_misc10
				&& WhereChq_reg_perc_misc11 ==  _whereChq_reg_perc_misc11
				&& WhereChq_reg_perc_misc12 ==  _whereChq_reg_perc_misc12
				&& WhereChq_reg_perc_misc13 ==  _whereChq_reg_perc_misc13
				&& WhereChq_reg_perc_misc14 ==  _whereChq_reg_perc_misc14
				&& WhereChq_reg_perc_misc15 ==  _whereChq_reg_perc_misc15
				&& WhereChq_reg_perc_misc16 ==  _whereChq_reg_perc_misc16
				&& WhereChq_reg_perc_misc17 ==  _whereChq_reg_perc_misc17
				&& WhereChq_reg_perc_misc18 ==  _whereChq_reg_perc_misc18
				&& WhereChq_reg_pay_code1 ==  _whereChq_reg_pay_code1
				&& WhereChq_reg_pay_code2 ==  _whereChq_reg_pay_code2
				&& WhereChq_reg_pay_code3 ==  _whereChq_reg_pay_code3
				&& WhereChq_reg_pay_code4 ==  _whereChq_reg_pay_code4
				&& WhereChq_reg_pay_code5 ==  _whereChq_reg_pay_code5
				&& WhereChq_reg_pay_code6 ==  _whereChq_reg_pay_code6
				&& WhereChq_reg_pay_code7 ==  _whereChq_reg_pay_code7
				&& WhereChq_reg_pay_code8 ==  _whereChq_reg_pay_code8
				&& WhereChq_reg_pay_code9 ==  _whereChq_reg_pay_code9
				&& WhereChq_reg_pay_code10 ==  _whereChq_reg_pay_code10
				&& WhereChq_reg_pay_code11 ==  _whereChq_reg_pay_code11
				&& WhereChq_reg_pay_code12 ==  _whereChq_reg_pay_code12
				&& WhereChq_reg_pay_code13 ==  _whereChq_reg_pay_code13
				&& WhereChq_reg_pay_code14 ==  _whereChq_reg_pay_code14
				&& WhereChq_reg_pay_code15 ==  _whereChq_reg_pay_code15
				&& WhereChq_reg_pay_code16 ==  _whereChq_reg_pay_code16
				&& WhereChq_reg_pay_code17 ==  _whereChq_reg_pay_code17
				&& WhereChq_reg_pay_code18 ==  _whereChq_reg_pay_code18
				&& WhereChq_reg_perc_tax1 ==  _whereChq_reg_perc_tax1
				&& WhereChq_reg_perc_tax2 ==  _whereChq_reg_perc_tax2
				&& WhereChq_reg_perc_tax3 ==  _whereChq_reg_perc_tax3
				&& WhereChq_reg_perc_tax4 ==  _whereChq_reg_perc_tax4
				&& WhereChq_reg_perc_tax5 ==  _whereChq_reg_perc_tax5
				&& WhereChq_reg_perc_tax6 ==  _whereChq_reg_perc_tax6
				&& WhereChq_reg_perc_tax7 ==  _whereChq_reg_perc_tax7
				&& WhereChq_reg_perc_tax8 ==  _whereChq_reg_perc_tax8
				&& WhereChq_reg_perc_tax9 ==  _whereChq_reg_perc_tax9
				&& WhereChq_reg_perc_tax10 ==  _whereChq_reg_perc_tax10
				&& WhereChq_reg_perc_tax11 ==  _whereChq_reg_perc_tax11
				&& WhereChq_reg_perc_tax12 ==  _whereChq_reg_perc_tax12
				&& WhereChq_reg_perc_tax13 ==  _whereChq_reg_perc_tax13
				&& WhereChq_reg_perc_tax14 ==  _whereChq_reg_perc_tax14
				&& WhereChq_reg_perc_tax15 ==  _whereChq_reg_perc_tax15
				&& WhereChq_reg_perc_tax16 ==  _whereChq_reg_perc_tax16
				&& WhereChq_reg_perc_tax17 ==  _whereChq_reg_perc_tax17
				&& WhereChq_reg_perc_tax18 ==  _whereChq_reg_perc_tax18
				&& WhereChq_reg_mth_bill_amt1 ==  _whereChq_reg_mth_bill_amt1
				&& WhereChq_reg_mth_bill_amt2 ==  _whereChq_reg_mth_bill_amt2
				&& WhereChq_reg_mth_bill_amt3 ==  _whereChq_reg_mth_bill_amt3
				&& WhereChq_reg_mth_bill_amt4 ==  _whereChq_reg_mth_bill_amt4
				&& WhereChq_reg_mth_bill_amt5 ==  _whereChq_reg_mth_bill_amt5
				&& WhereChq_reg_mth_bill_amt6 ==  _whereChq_reg_mth_bill_amt6
				&& WhereChq_reg_mth_bill_amt7 ==  _whereChq_reg_mth_bill_amt7
				&& WhereChq_reg_mth_bill_amt8 ==  _whereChq_reg_mth_bill_amt8
				&& WhereChq_reg_mth_bill_amt9 ==  _whereChq_reg_mth_bill_amt9
				&& WhereChq_reg_mth_bill_amt10 ==  _whereChq_reg_mth_bill_amt10
				&& WhereChq_reg_mth_bill_amt11 ==  _whereChq_reg_mth_bill_amt11
				&& WhereChq_reg_mth_bill_amt12 ==  _whereChq_reg_mth_bill_amt12
				&& WhereChq_reg_mth_bill_amt13 ==  _whereChq_reg_mth_bill_amt13
				&& WhereChq_reg_mth_bill_amt14 ==  _whereChq_reg_mth_bill_amt14
				&& WhereChq_reg_mth_bill_amt15 ==  _whereChq_reg_mth_bill_amt15
				&& WhereChq_reg_mth_bill_amt16 ==  _whereChq_reg_mth_bill_amt16
				&& WhereChq_reg_mth_bill_amt17 ==  _whereChq_reg_mth_bill_amt17
				&& WhereChq_reg_mth_bill_amt18 ==  _whereChq_reg_mth_bill_amt18
				&& WhereChq_reg_mth_misc_amt_11 ==  _whereChq_reg_mth_misc_amt_11
				&& WhereChq_reg_mth_misc_amt_12 ==  _whereChq_reg_mth_misc_amt_12
				&& WhereChq_reg_mth_misc_amt_13 ==  _whereChq_reg_mth_misc_amt_13
				&& WhereChq_reg_mth_misc_amt_14 ==  _whereChq_reg_mth_misc_amt_14
				&& WhereChq_reg_mth_misc_amt_15 ==  _whereChq_reg_mth_misc_amt_15
				&& WhereChq_reg_mth_misc_amt_16 ==  _whereChq_reg_mth_misc_amt_16
				&& WhereChq_reg_mth_misc_amt_17 ==  _whereChq_reg_mth_misc_amt_17
				&& WhereChq_reg_mth_misc_amt_18 ==  _whereChq_reg_mth_misc_amt_18
				&& WhereChq_reg_mth_misc_amt_19 ==  _whereChq_reg_mth_misc_amt_19
				&& WhereChq_reg_mth_misc_amt_110 ==  _whereChq_reg_mth_misc_amt_110
				&& WhereChq_reg_mth_misc_amt_111 ==  _whereChq_reg_mth_misc_amt_111
				&& WhereChq_reg_mth_misc_amt_112 ==  _whereChq_reg_mth_misc_amt_112
				&& WhereChq_reg_mth_misc_amt_113 ==  _whereChq_reg_mth_misc_amt_113
				&& WhereChq_reg_mth_misc_amt_114 ==  _whereChq_reg_mth_misc_amt_114
				&& WhereChq_reg_mth_misc_amt_115 ==  _whereChq_reg_mth_misc_amt_115
				&& WhereChq_reg_mth_misc_amt_116 ==  _whereChq_reg_mth_misc_amt_116
				&& WhereChq_reg_mth_misc_amt_117 ==  _whereChq_reg_mth_misc_amt_117
				&& WhereChq_reg_mth_misc_amt_118 ==  _whereChq_reg_mth_misc_amt_118
				&& WhereChq_reg_mth_misc_amt_21 ==  _whereChq_reg_mth_misc_amt_21
				&& WhereChq_reg_mth_misc_amt_22 ==  _whereChq_reg_mth_misc_amt_22
				&& WhereChq_reg_mth_misc_amt_23 ==  _whereChq_reg_mth_misc_amt_23
				&& WhereChq_reg_mth_misc_amt_24 ==  _whereChq_reg_mth_misc_amt_24
				&& WhereChq_reg_mth_misc_amt_25 ==  _whereChq_reg_mth_misc_amt_25
				&& WhereChq_reg_mth_misc_amt_26 ==  _whereChq_reg_mth_misc_amt_26
				&& WhereChq_reg_mth_misc_amt_27 ==  _whereChq_reg_mth_misc_amt_27
				&& WhereChq_reg_mth_misc_amt_28 ==  _whereChq_reg_mth_misc_amt_28
				&& WhereChq_reg_mth_misc_amt_29 ==  _whereChq_reg_mth_misc_amt_29
				&& WhereChq_reg_mth_misc_amt_210 ==  _whereChq_reg_mth_misc_amt_210
				&& WhereChq_reg_mth_misc_amt_211 ==  _whereChq_reg_mth_misc_amt_211
				&& WhereChq_reg_mth_misc_amt_212 ==  _whereChq_reg_mth_misc_amt_212
				&& WhereChq_reg_mth_misc_amt_213 ==  _whereChq_reg_mth_misc_amt_213
				&& WhereChq_reg_mth_misc_amt_214 ==  _whereChq_reg_mth_misc_amt_214
				&& WhereChq_reg_mth_misc_amt_215 ==  _whereChq_reg_mth_misc_amt_215
				&& WhereChq_reg_mth_misc_amt_216 ==  _whereChq_reg_mth_misc_amt_216
				&& WhereChq_reg_mth_misc_amt_217 ==  _whereChq_reg_mth_misc_amt_217
				&& WhereChq_reg_mth_misc_amt_218 ==  _whereChq_reg_mth_misc_amt_218
				&& WhereChq_reg_mth_misc_amt_31 ==  _whereChq_reg_mth_misc_amt_31
				&& WhereChq_reg_mth_misc_amt_32 ==  _whereChq_reg_mth_misc_amt_32
				&& WhereChq_reg_mth_misc_amt_33 ==  _whereChq_reg_mth_misc_amt_33
				&& WhereChq_reg_mth_misc_amt_34 ==  _whereChq_reg_mth_misc_amt_34
				&& WhereChq_reg_mth_misc_amt_35 ==  _whereChq_reg_mth_misc_amt_35
				&& WhereChq_reg_mth_misc_amt_36 ==  _whereChq_reg_mth_misc_amt_36
				&& WhereChq_reg_mth_misc_amt_37 ==  _whereChq_reg_mth_misc_amt_37
				&& WhereChq_reg_mth_misc_amt_38 ==  _whereChq_reg_mth_misc_amt_38
				&& WhereChq_reg_mth_misc_amt_39 ==  _whereChq_reg_mth_misc_amt_39
				&& WhereChq_reg_mth_misc_amt_310 ==  _whereChq_reg_mth_misc_amt_310
				&& WhereChq_reg_mth_misc_amt_311 ==  _whereChq_reg_mth_misc_amt_311
				&& WhereChq_reg_mth_misc_amt_312 ==  _whereChq_reg_mth_misc_amt_312
				&& WhereChq_reg_mth_misc_amt_313 ==  _whereChq_reg_mth_misc_amt_313
				&& WhereChq_reg_mth_misc_amt_314 ==  _whereChq_reg_mth_misc_amt_314
				&& WhereChq_reg_mth_misc_amt_315 ==  _whereChq_reg_mth_misc_amt_315
				&& WhereChq_reg_mth_misc_amt_316 ==  _whereChq_reg_mth_misc_amt_316
				&& WhereChq_reg_mth_misc_amt_317 ==  _whereChq_reg_mth_misc_amt_317
				&& WhereChq_reg_mth_misc_amt_318 ==  _whereChq_reg_mth_misc_amt_318
				&& WhereChq_reg_mth_misc_amt_41 ==  _whereChq_reg_mth_misc_amt_41
				&& WhereChq_reg_mth_misc_amt_42 ==  _whereChq_reg_mth_misc_amt_42
				&& WhereChq_reg_mth_misc_amt_43 ==  _whereChq_reg_mth_misc_amt_43
				&& WhereChq_reg_mth_misc_amt_44 ==  _whereChq_reg_mth_misc_amt_44
				&& WhereChq_reg_mth_misc_amt_45 ==  _whereChq_reg_mth_misc_amt_45
				&& WhereChq_reg_mth_misc_amt_46 ==  _whereChq_reg_mth_misc_amt_46
				&& WhereChq_reg_mth_misc_amt_47 ==  _whereChq_reg_mth_misc_amt_47
				&& WhereChq_reg_mth_misc_amt_48 ==  _whereChq_reg_mth_misc_amt_48
				&& WhereChq_reg_mth_misc_amt_49 ==  _whereChq_reg_mth_misc_amt_49
				&& WhereChq_reg_mth_misc_amt_410 ==  _whereChq_reg_mth_misc_amt_410
				&& WhereChq_reg_mth_misc_amt_411 ==  _whereChq_reg_mth_misc_amt_411
				&& WhereChq_reg_mth_misc_amt_412 ==  _whereChq_reg_mth_misc_amt_412
				&& WhereChq_reg_mth_misc_amt_413 ==  _whereChq_reg_mth_misc_amt_413
				&& WhereChq_reg_mth_misc_amt_414 ==  _whereChq_reg_mth_misc_amt_414
				&& WhereChq_reg_mth_misc_amt_415 ==  _whereChq_reg_mth_misc_amt_415
				&& WhereChq_reg_mth_misc_amt_416 ==  _whereChq_reg_mth_misc_amt_416
				&& WhereChq_reg_mth_misc_amt_417 ==  _whereChq_reg_mth_misc_amt_417
				&& WhereChq_reg_mth_misc_amt_418 ==  _whereChq_reg_mth_misc_amt_418
				&& WhereChq_reg_mth_misc_amt_51 ==  _whereChq_reg_mth_misc_amt_51
				&& WhereChq_reg_mth_misc_amt_52 ==  _whereChq_reg_mth_misc_amt_52
				&& WhereChq_reg_mth_misc_amt_53 ==  _whereChq_reg_mth_misc_amt_53
				&& WhereChq_reg_mth_misc_amt_54 ==  _whereChq_reg_mth_misc_amt_54
				&& WhereChq_reg_mth_misc_amt_55 ==  _whereChq_reg_mth_misc_amt_55
				&& WhereChq_reg_mth_misc_amt_56 ==  _whereChq_reg_mth_misc_amt_56
				&& WhereChq_reg_mth_misc_amt_57 ==  _whereChq_reg_mth_misc_amt_57
				&& WhereChq_reg_mth_misc_amt_58 ==  _whereChq_reg_mth_misc_amt_58
				&& WhereChq_reg_mth_misc_amt_59 ==  _whereChq_reg_mth_misc_amt_59
				&& WhereChq_reg_mth_misc_amt_510 ==  _whereChq_reg_mth_misc_amt_510
				&& WhereChq_reg_mth_misc_amt_511 ==  _whereChq_reg_mth_misc_amt_511
				&& WhereChq_reg_mth_misc_amt_512 ==  _whereChq_reg_mth_misc_amt_512
				&& WhereChq_reg_mth_misc_amt_513 ==  _whereChq_reg_mth_misc_amt_513
				&& WhereChq_reg_mth_misc_amt_514 ==  _whereChq_reg_mth_misc_amt_514
				&& WhereChq_reg_mth_misc_amt_515 ==  _whereChq_reg_mth_misc_amt_515
				&& WhereChq_reg_mth_misc_amt_516 ==  _whereChq_reg_mth_misc_amt_516
				&& WhereChq_reg_mth_misc_amt_517 ==  _whereChq_reg_mth_misc_amt_517
				&& WhereChq_reg_mth_misc_amt_518 ==  _whereChq_reg_mth_misc_amt_518
				&& WhereChq_reg_mth_misc_amt_61 ==  _whereChq_reg_mth_misc_amt_61
				&& WhereChq_reg_mth_misc_amt_62 ==  _whereChq_reg_mth_misc_amt_62
				&& WhereChq_reg_mth_misc_amt_63 ==  _whereChq_reg_mth_misc_amt_63
				&& WhereChq_reg_mth_misc_amt_64 ==  _whereChq_reg_mth_misc_amt_64
				&& WhereChq_reg_mth_misc_amt_65 ==  _whereChq_reg_mth_misc_amt_65
				&& WhereChq_reg_mth_misc_amt_66 ==  _whereChq_reg_mth_misc_amt_66
				&& WhereChq_reg_mth_misc_amt_67 ==  _whereChq_reg_mth_misc_amt_67
				&& WhereChq_reg_mth_misc_amt_68 ==  _whereChq_reg_mth_misc_amt_68
				&& WhereChq_reg_mth_misc_amt_69 ==  _whereChq_reg_mth_misc_amt_69
				&& WhereChq_reg_mth_misc_amt_610 ==  _whereChq_reg_mth_misc_amt_610
				&& WhereChq_reg_mth_misc_amt_611 ==  _whereChq_reg_mth_misc_amt_611
				&& WhereChq_reg_mth_misc_amt_612 ==  _whereChq_reg_mth_misc_amt_612
				&& WhereChq_reg_mth_misc_amt_613 ==  _whereChq_reg_mth_misc_amt_613
				&& WhereChq_reg_mth_misc_amt_614 ==  _whereChq_reg_mth_misc_amt_614
				&& WhereChq_reg_mth_misc_amt_615 ==  _whereChq_reg_mth_misc_amt_615
				&& WhereChq_reg_mth_misc_amt_616 ==  _whereChq_reg_mth_misc_amt_616
				&& WhereChq_reg_mth_misc_amt_617 ==  _whereChq_reg_mth_misc_amt_617
				&& WhereChq_reg_mth_misc_amt_618 ==  _whereChq_reg_mth_misc_amt_618
				&& WhereChq_reg_mth_misc_amt_71 ==  _whereChq_reg_mth_misc_amt_71
				&& WhereChq_reg_mth_misc_amt_72 ==  _whereChq_reg_mth_misc_amt_72
				&& WhereChq_reg_mth_misc_amt_73 ==  _whereChq_reg_mth_misc_amt_73
				&& WhereChq_reg_mth_misc_amt_74 ==  _whereChq_reg_mth_misc_amt_74
				&& WhereChq_reg_mth_misc_amt_75 ==  _whereChq_reg_mth_misc_amt_75
				&& WhereChq_reg_mth_misc_amt_76 ==  _whereChq_reg_mth_misc_amt_76
				&& WhereChq_reg_mth_misc_amt_77 ==  _whereChq_reg_mth_misc_amt_77
				&& WhereChq_reg_mth_misc_amt_78 ==  _whereChq_reg_mth_misc_amt_78
				&& WhereChq_reg_mth_misc_amt_79 ==  _whereChq_reg_mth_misc_amt_79
				&& WhereChq_reg_mth_misc_amt_710 ==  _whereChq_reg_mth_misc_amt_710
				&& WhereChq_reg_mth_misc_amt_711 ==  _whereChq_reg_mth_misc_amt_711
				&& WhereChq_reg_mth_misc_amt_712 ==  _whereChq_reg_mth_misc_amt_712
				&& WhereChq_reg_mth_misc_amt_713 ==  _whereChq_reg_mth_misc_amt_713
				&& WhereChq_reg_mth_misc_amt_714 ==  _whereChq_reg_mth_misc_amt_714
				&& WhereChq_reg_mth_misc_amt_715 ==  _whereChq_reg_mth_misc_amt_715
				&& WhereChq_reg_mth_misc_amt_716 ==  _whereChq_reg_mth_misc_amt_716
				&& WhereChq_reg_mth_misc_amt_717 ==  _whereChq_reg_mth_misc_amt_717
				&& WhereChq_reg_mth_misc_amt_718 ==  _whereChq_reg_mth_misc_amt_718
				&& WhereChq_reg_mth_misc_amt_81 ==  _whereChq_reg_mth_misc_amt_81
				&& WhereChq_reg_mth_misc_amt_82 ==  _whereChq_reg_mth_misc_amt_82
				&& WhereChq_reg_mth_misc_amt_83 ==  _whereChq_reg_mth_misc_amt_83
				&& WhereChq_reg_mth_misc_amt_84 ==  _whereChq_reg_mth_misc_amt_84
				&& WhereChq_reg_mth_misc_amt_85 ==  _whereChq_reg_mth_misc_amt_85
				&& WhereChq_reg_mth_misc_amt_86 ==  _whereChq_reg_mth_misc_amt_86
				&& WhereChq_reg_mth_misc_amt_87 ==  _whereChq_reg_mth_misc_amt_87
				&& WhereChq_reg_mth_misc_amt_88 ==  _whereChq_reg_mth_misc_amt_88
				&& WhereChq_reg_mth_misc_amt_89 ==  _whereChq_reg_mth_misc_amt_89
				&& WhereChq_reg_mth_misc_amt_810 ==  _whereChq_reg_mth_misc_amt_810
				&& WhereChq_reg_mth_misc_amt_811 ==  _whereChq_reg_mth_misc_amt_811
				&& WhereChq_reg_mth_misc_amt_812 ==  _whereChq_reg_mth_misc_amt_812
				&& WhereChq_reg_mth_misc_amt_813 ==  _whereChq_reg_mth_misc_amt_813
				&& WhereChq_reg_mth_misc_amt_814 ==  _whereChq_reg_mth_misc_amt_814
				&& WhereChq_reg_mth_misc_amt_815 ==  _whereChq_reg_mth_misc_amt_815
				&& WhereChq_reg_mth_misc_amt_816 ==  _whereChq_reg_mth_misc_amt_816
				&& WhereChq_reg_mth_misc_amt_817 ==  _whereChq_reg_mth_misc_amt_817
				&& WhereChq_reg_mth_misc_amt_818 ==  _whereChq_reg_mth_misc_amt_818
				&& WhereChq_reg_mth_misc_amt_91 ==  _whereChq_reg_mth_misc_amt_91
				&& WhereChq_reg_mth_misc_amt_92 ==  _whereChq_reg_mth_misc_amt_92
				&& WhereChq_reg_mth_misc_amt_93 ==  _whereChq_reg_mth_misc_amt_93
				&& WhereChq_reg_mth_misc_amt_94 ==  _whereChq_reg_mth_misc_amt_94
				&& WhereChq_reg_mth_misc_amt_95 ==  _whereChq_reg_mth_misc_amt_95
				&& WhereChq_reg_mth_misc_amt_96 ==  _whereChq_reg_mth_misc_amt_96
				&& WhereChq_reg_mth_misc_amt_97 ==  _whereChq_reg_mth_misc_amt_97
				&& WhereChq_reg_mth_misc_amt_98 ==  _whereChq_reg_mth_misc_amt_98
				&& WhereChq_reg_mth_misc_amt_99 ==  _whereChq_reg_mth_misc_amt_99
				&& WhereChq_reg_mth_misc_amt_910 ==  _whereChq_reg_mth_misc_amt_910
				&& WhereChq_reg_mth_misc_amt_911 ==  _whereChq_reg_mth_misc_amt_911
				&& WhereChq_reg_mth_misc_amt_912 ==  _whereChq_reg_mth_misc_amt_912
				&& WhereChq_reg_mth_misc_amt_913 ==  _whereChq_reg_mth_misc_amt_913
				&& WhereChq_reg_mth_misc_amt_914 ==  _whereChq_reg_mth_misc_amt_914
				&& WhereChq_reg_mth_misc_amt_915 ==  _whereChq_reg_mth_misc_amt_915
				&& WhereChq_reg_mth_misc_amt_916 ==  _whereChq_reg_mth_misc_amt_916
				&& WhereChq_reg_mth_misc_amt_917 ==  _whereChq_reg_mth_misc_amt_917
				&& WhereChq_reg_mth_misc_amt_918 ==  _whereChq_reg_mth_misc_amt_918
				&& WhereChq_reg_mth_misc_amt_101 ==  _whereChq_reg_mth_misc_amt_101
				&& WhereChq_reg_mth_misc_amt_102 ==  _whereChq_reg_mth_misc_amt_102
				&& WhereChq_reg_mth_misc_amt_103 ==  _whereChq_reg_mth_misc_amt_103
				&& WhereChq_reg_mth_misc_amt_104 ==  _whereChq_reg_mth_misc_amt_104
				&& WhereChq_reg_mth_misc_amt_105 ==  _whereChq_reg_mth_misc_amt_105
				&& WhereChq_reg_mth_misc_amt_106 ==  _whereChq_reg_mth_misc_amt_106
				&& WhereChq_reg_mth_misc_amt_107 ==  _whereChq_reg_mth_misc_amt_107
				&& WhereChq_reg_mth_misc_amt_108 ==  _whereChq_reg_mth_misc_amt_108
				&& WhereChq_reg_mth_misc_amt_109 ==  _whereChq_reg_mth_misc_amt_109
				&& WhereChq_reg_mth_misc_amt_1010 ==  _whereChq_reg_mth_misc_amt_1010
				&& WhereChq_reg_mth_misc_amt_1011 ==  _whereChq_reg_mth_misc_amt_1011
				&& WhereChq_reg_mth_misc_amt_1012 ==  _whereChq_reg_mth_misc_amt_1012
				&& WhereChq_reg_mth_misc_amt_1013 ==  _whereChq_reg_mth_misc_amt_1013
				&& WhereChq_reg_mth_misc_amt_1014 ==  _whereChq_reg_mth_misc_amt_1014
				&& WhereChq_reg_mth_misc_amt_1015 ==  _whereChq_reg_mth_misc_amt_1015
				&& WhereChq_reg_mth_misc_amt_1016 ==  _whereChq_reg_mth_misc_amt_1016
				&& WhereChq_reg_mth_misc_amt_1017 ==  _whereChq_reg_mth_misc_amt_1017
				&& WhereChq_reg_mth_misc_amt_1018 ==  _whereChq_reg_mth_misc_amt_1018
				&& WhereChq_reg_mth_exp_amt1 ==  _whereChq_reg_mth_exp_amt1
				&& WhereChq_reg_mth_exp_amt2 ==  _whereChq_reg_mth_exp_amt2
				&& WhereChq_reg_mth_exp_amt3 ==  _whereChq_reg_mth_exp_amt3
				&& WhereChq_reg_mth_exp_amt4 ==  _whereChq_reg_mth_exp_amt4
				&& WhereChq_reg_mth_exp_amt5 ==  _whereChq_reg_mth_exp_amt5
				&& WhereChq_reg_mth_exp_amt6 ==  _whereChq_reg_mth_exp_amt6
				&& WhereChq_reg_mth_exp_amt7 ==  _whereChq_reg_mth_exp_amt7
				&& WhereChq_reg_mth_exp_amt8 ==  _whereChq_reg_mth_exp_amt8
				&& WhereChq_reg_mth_exp_amt9 ==  _whereChq_reg_mth_exp_amt9
				&& WhereChq_reg_mth_exp_amt10 ==  _whereChq_reg_mth_exp_amt10
				&& WhereChq_reg_mth_exp_amt11 ==  _whereChq_reg_mth_exp_amt11
				&& WhereChq_reg_mth_exp_amt12 ==  _whereChq_reg_mth_exp_amt12
				&& WhereChq_reg_mth_exp_amt13 ==  _whereChq_reg_mth_exp_amt13
				&& WhereChq_reg_mth_exp_amt14 ==  _whereChq_reg_mth_exp_amt14
				&& WhereChq_reg_mth_exp_amt15 ==  _whereChq_reg_mth_exp_amt15
				&& WhereChq_reg_mth_exp_amt16 ==  _whereChq_reg_mth_exp_amt16
				&& WhereChq_reg_mth_exp_amt17 ==  _whereChq_reg_mth_exp_amt17
				&& WhereChq_reg_mth_exp_amt18 ==  _whereChq_reg_mth_exp_amt18
				&& WhereChq_reg_comp_ann_exp_this_pay1 ==  _whereChq_reg_comp_ann_exp_this_pay1
				&& WhereChq_reg_comp_ann_exp_this_pay2 ==  _whereChq_reg_comp_ann_exp_this_pay2
				&& WhereChq_reg_comp_ann_exp_this_pay3 ==  _whereChq_reg_comp_ann_exp_this_pay3
				&& WhereChq_reg_comp_ann_exp_this_pay4 ==  _whereChq_reg_comp_ann_exp_this_pay4
				&& WhereChq_reg_comp_ann_exp_this_pay5 ==  _whereChq_reg_comp_ann_exp_this_pay5
				&& WhereChq_reg_comp_ann_exp_this_pay6 ==  _whereChq_reg_comp_ann_exp_this_pay6
				&& WhereChq_reg_comp_ann_exp_this_pay7 ==  _whereChq_reg_comp_ann_exp_this_pay7
				&& WhereChq_reg_comp_ann_exp_this_pay8 ==  _whereChq_reg_comp_ann_exp_this_pay8
				&& WhereChq_reg_comp_ann_exp_this_pay9 ==  _whereChq_reg_comp_ann_exp_this_pay9
				&& WhereChq_reg_comp_ann_exp_this_pay10 ==  _whereChq_reg_comp_ann_exp_this_pay10
				&& WhereChq_reg_comp_ann_exp_this_pay11 ==  _whereChq_reg_comp_ann_exp_this_pay11
				&& WhereChq_reg_comp_ann_exp_this_pay12 ==  _whereChq_reg_comp_ann_exp_this_pay12
				&& WhereChq_reg_comp_ann_exp_this_pay13 ==  _whereChq_reg_comp_ann_exp_this_pay13
				&& WhereChq_reg_comp_ann_exp_this_pay14 ==  _whereChq_reg_comp_ann_exp_this_pay14
				&& WhereChq_reg_comp_ann_exp_this_pay15 ==  _whereChq_reg_comp_ann_exp_this_pay15
				&& WhereChq_reg_comp_ann_exp_this_pay16 ==  _whereChq_reg_comp_ann_exp_this_pay16
				&& WhereChq_reg_comp_ann_exp_this_pay17 ==  _whereChq_reg_comp_ann_exp_this_pay17
				&& WhereChq_reg_comp_ann_exp_this_pay18 ==  _whereChq_reg_comp_ann_exp_this_pay18
				&& WhereChq_reg_mth_ceil_amt1 ==  _whereChq_reg_mth_ceil_amt1
				&& WhereChq_reg_mth_ceil_amt2 ==  _whereChq_reg_mth_ceil_amt2
				&& WhereChq_reg_mth_ceil_amt3 ==  _whereChq_reg_mth_ceil_amt3
				&& WhereChq_reg_mth_ceil_amt4 ==  _whereChq_reg_mth_ceil_amt4
				&& WhereChq_reg_mth_ceil_amt5 ==  _whereChq_reg_mth_ceil_amt5
				&& WhereChq_reg_mth_ceil_amt6 ==  _whereChq_reg_mth_ceil_amt6
				&& WhereChq_reg_mth_ceil_amt7 ==  _whereChq_reg_mth_ceil_amt7
				&& WhereChq_reg_mth_ceil_amt8 ==  _whereChq_reg_mth_ceil_amt8
				&& WhereChq_reg_mth_ceil_amt9 ==  _whereChq_reg_mth_ceil_amt9
				&& WhereChq_reg_mth_ceil_amt10 ==  _whereChq_reg_mth_ceil_amt10
				&& WhereChq_reg_mth_ceil_amt11 ==  _whereChq_reg_mth_ceil_amt11
				&& WhereChq_reg_mth_ceil_amt12 ==  _whereChq_reg_mth_ceil_amt12
				&& WhereChq_reg_mth_ceil_amt13 ==  _whereChq_reg_mth_ceil_amt13
				&& WhereChq_reg_mth_ceil_amt14 ==  _whereChq_reg_mth_ceil_amt14
				&& WhereChq_reg_mth_ceil_amt15 ==  _whereChq_reg_mth_ceil_amt15
				&& WhereChq_reg_mth_ceil_amt16 ==  _whereChq_reg_mth_ceil_amt16
				&& WhereChq_reg_mth_ceil_amt17 ==  _whereChq_reg_mth_ceil_amt17
				&& WhereChq_reg_mth_ceil_amt18 ==  _whereChq_reg_mth_ceil_amt18
				&& WhereChq_reg_comp_ann_ceil_this_pay1 ==  _whereChq_reg_comp_ann_ceil_this_pay1
				&& WhereChq_reg_comp_ann_ceil_this_pay2 ==  _whereChq_reg_comp_ann_ceil_this_pay2
				&& WhereChq_reg_comp_ann_ceil_this_pay3 ==  _whereChq_reg_comp_ann_ceil_this_pay3
				&& WhereChq_reg_comp_ann_ceil_this_pay4 ==  _whereChq_reg_comp_ann_ceil_this_pay4
				&& WhereChq_reg_comp_ann_ceil_this_pay5 ==  _whereChq_reg_comp_ann_ceil_this_pay5
				&& WhereChq_reg_comp_ann_ceil_this_pay6 ==  _whereChq_reg_comp_ann_ceil_this_pay6
				&& WhereChq_reg_comp_ann_ceil_this_pay7 ==  _whereChq_reg_comp_ann_ceil_this_pay7
				&& WhereChq_reg_comp_ann_ceil_this_pay8 ==  _whereChq_reg_comp_ann_ceil_this_pay8
				&& WhereChq_reg_comp_ann_ceil_this_pay9 ==  _whereChq_reg_comp_ann_ceil_this_pay9
				&& WhereChq_reg_comp_ann_ceil_this_pay10 ==  _whereChq_reg_comp_ann_ceil_this_pay10
				&& WhereChq_reg_comp_ann_ceil_this_pay11 ==  _whereChq_reg_comp_ann_ceil_this_pay11
				&& WhereChq_reg_comp_ann_ceil_this_pay12 ==  _whereChq_reg_comp_ann_ceil_this_pay12
				&& WhereChq_reg_comp_ann_ceil_this_pay13 ==  _whereChq_reg_comp_ann_ceil_this_pay13
				&& WhereChq_reg_comp_ann_ceil_this_pay14 ==  _whereChq_reg_comp_ann_ceil_this_pay14
				&& WhereChq_reg_comp_ann_ceil_this_pay15 ==  _whereChq_reg_comp_ann_ceil_this_pay15
				&& WhereChq_reg_comp_ann_ceil_this_pay16 ==  _whereChq_reg_comp_ann_ceil_this_pay16
				&& WhereChq_reg_comp_ann_ceil_this_pay17 ==  _whereChq_reg_comp_ann_ceil_this_pay17
				&& WhereChq_reg_comp_ann_ceil_this_pay18 ==  _whereChq_reg_comp_ann_ceil_this_pay18
				&& WhereChq_reg_earnings_this_mth1 ==  _whereChq_reg_earnings_this_mth1
				&& WhereChq_reg_earnings_this_mth2 ==  _whereChq_reg_earnings_this_mth2
				&& WhereChq_reg_earnings_this_mth3 ==  _whereChq_reg_earnings_this_mth3
				&& WhereChq_reg_earnings_this_mth4 ==  _whereChq_reg_earnings_this_mth4
				&& WhereChq_reg_earnings_this_mth5 ==  _whereChq_reg_earnings_this_mth5
				&& WhereChq_reg_earnings_this_mth6 ==  _whereChq_reg_earnings_this_mth6
				&& WhereChq_reg_earnings_this_mth7 ==  _whereChq_reg_earnings_this_mth7
				&& WhereChq_reg_earnings_this_mth8 ==  _whereChq_reg_earnings_this_mth8
				&& WhereChq_reg_earnings_this_mth9 ==  _whereChq_reg_earnings_this_mth9
				&& WhereChq_reg_earnings_this_mth10 ==  _whereChq_reg_earnings_this_mth10
				&& WhereChq_reg_earnings_this_mth11 ==  _whereChq_reg_earnings_this_mth11
				&& WhereChq_reg_earnings_this_mth12 ==  _whereChq_reg_earnings_this_mth12
				&& WhereChq_reg_earnings_this_mth13 ==  _whereChq_reg_earnings_this_mth13
				&& WhereChq_reg_earnings_this_mth14 ==  _whereChq_reg_earnings_this_mth14
				&& WhereChq_reg_earnings_this_mth15 ==  _whereChq_reg_earnings_this_mth15
				&& WhereChq_reg_earnings_this_mth16 ==  _whereChq_reg_earnings_this_mth16
				&& WhereChq_reg_earnings_this_mth17 ==  _whereChq_reg_earnings_this_mth17
				&& WhereChq_reg_earnings_this_mth18 ==  _whereChq_reg_earnings_this_mth18
				&& WhereChq_reg_regular_pay_this_mth1 ==  _whereChq_reg_regular_pay_this_mth1
				&& WhereChq_reg_regular_pay_this_mth2 ==  _whereChq_reg_regular_pay_this_mth2
				&& WhereChq_reg_regular_pay_this_mth3 ==  _whereChq_reg_regular_pay_this_mth3
				&& WhereChq_reg_regular_pay_this_mth4 ==  _whereChq_reg_regular_pay_this_mth4
				&& WhereChq_reg_regular_pay_this_mth5 ==  _whereChq_reg_regular_pay_this_mth5
				&& WhereChq_reg_regular_pay_this_mth6 ==  _whereChq_reg_regular_pay_this_mth6
				&& WhereChq_reg_regular_pay_this_mth7 ==  _whereChq_reg_regular_pay_this_mth7
				&& WhereChq_reg_regular_pay_this_mth8 ==  _whereChq_reg_regular_pay_this_mth8
				&& WhereChq_reg_regular_pay_this_mth9 ==  _whereChq_reg_regular_pay_this_mth9
				&& WhereChq_reg_regular_pay_this_mth10 ==  _whereChq_reg_regular_pay_this_mth10
				&& WhereChq_reg_regular_pay_this_mth11 ==  _whereChq_reg_regular_pay_this_mth11
				&& WhereChq_reg_regular_pay_this_mth12 ==  _whereChq_reg_regular_pay_this_mth12
				&& WhereChq_reg_regular_pay_this_mth13 ==  _whereChq_reg_regular_pay_this_mth13
				&& WhereChq_reg_regular_pay_this_mth14 ==  _whereChq_reg_regular_pay_this_mth14
				&& WhereChq_reg_regular_pay_this_mth15 ==  _whereChq_reg_regular_pay_this_mth15
				&& WhereChq_reg_regular_pay_this_mth16 ==  _whereChq_reg_regular_pay_this_mth16
				&& WhereChq_reg_regular_pay_this_mth17 ==  _whereChq_reg_regular_pay_this_mth17
				&& WhereChq_reg_regular_pay_this_mth18 ==  _whereChq_reg_regular_pay_this_mth18
				&& WhereChq_reg_regular_tax_this_mth1 ==  _whereChq_reg_regular_tax_this_mth1
				&& WhereChq_reg_regular_tax_this_mth2 ==  _whereChq_reg_regular_tax_this_mth2
				&& WhereChq_reg_regular_tax_this_mth3 ==  _whereChq_reg_regular_tax_this_mth3
				&& WhereChq_reg_regular_tax_this_mth4 ==  _whereChq_reg_regular_tax_this_mth4
				&& WhereChq_reg_regular_tax_this_mth5 ==  _whereChq_reg_regular_tax_this_mth5
				&& WhereChq_reg_regular_tax_this_mth6 ==  _whereChq_reg_regular_tax_this_mth6
				&& WhereChq_reg_regular_tax_this_mth7 ==  _whereChq_reg_regular_tax_this_mth7
				&& WhereChq_reg_regular_tax_this_mth8 ==  _whereChq_reg_regular_tax_this_mth8
				&& WhereChq_reg_regular_tax_this_mth9 ==  _whereChq_reg_regular_tax_this_mth9
				&& WhereChq_reg_regular_tax_this_mth10 ==  _whereChq_reg_regular_tax_this_mth10
				&& WhereChq_reg_regular_tax_this_mth11 ==  _whereChq_reg_regular_tax_this_mth11
				&& WhereChq_reg_regular_tax_this_mth12 ==  _whereChq_reg_regular_tax_this_mth12
				&& WhereChq_reg_regular_tax_this_mth13 ==  _whereChq_reg_regular_tax_this_mth13
				&& WhereChq_reg_regular_tax_this_mth14 ==  _whereChq_reg_regular_tax_this_mth14
				&& WhereChq_reg_regular_tax_this_mth15 ==  _whereChq_reg_regular_tax_this_mth15
				&& WhereChq_reg_regular_tax_this_mth16 ==  _whereChq_reg_regular_tax_this_mth16
				&& WhereChq_reg_regular_tax_this_mth17 ==  _whereChq_reg_regular_tax_this_mth17
				&& WhereChq_reg_regular_tax_this_mth18 ==  _whereChq_reg_regular_tax_this_mth18
				&& WhereChq_reg_man_pay_this_mth1 ==  _whereChq_reg_man_pay_this_mth1
				&& WhereChq_reg_man_pay_this_mth2 ==  _whereChq_reg_man_pay_this_mth2
				&& WhereChq_reg_man_pay_this_mth3 ==  _whereChq_reg_man_pay_this_mth3
				&& WhereChq_reg_man_pay_this_mth4 ==  _whereChq_reg_man_pay_this_mth4
				&& WhereChq_reg_man_pay_this_mth5 ==  _whereChq_reg_man_pay_this_mth5
				&& WhereChq_reg_man_pay_this_mth6 ==  _whereChq_reg_man_pay_this_mth6
				&& WhereChq_reg_man_pay_this_mth7 ==  _whereChq_reg_man_pay_this_mth7
				&& WhereChq_reg_man_pay_this_mth8 ==  _whereChq_reg_man_pay_this_mth8
				&& WhereChq_reg_man_pay_this_mth9 ==  _whereChq_reg_man_pay_this_mth9
				&& WhereChq_reg_man_pay_this_mth10 ==  _whereChq_reg_man_pay_this_mth10
				&& WhereChq_reg_man_pay_this_mth11 ==  _whereChq_reg_man_pay_this_mth11
				&& WhereChq_reg_man_pay_this_mth12 ==  _whereChq_reg_man_pay_this_mth12
				&& WhereChq_reg_man_pay_this_mth13 ==  _whereChq_reg_man_pay_this_mth13
				&& WhereChq_reg_man_pay_this_mth14 ==  _whereChq_reg_man_pay_this_mth14
				&& WhereChq_reg_man_pay_this_mth15 ==  _whereChq_reg_man_pay_this_mth15
				&& WhereChq_reg_man_pay_this_mth16 ==  _whereChq_reg_man_pay_this_mth16
				&& WhereChq_reg_man_pay_this_mth17 ==  _whereChq_reg_man_pay_this_mth17
				&& WhereChq_reg_man_pay_this_mth18 ==  _whereChq_reg_man_pay_this_mth18
				&& WhereChq_reg_man_tax_this_mth1 ==  _whereChq_reg_man_tax_this_mth1
				&& WhereChq_reg_man_tax_this_mth2 ==  _whereChq_reg_man_tax_this_mth2
				&& WhereChq_reg_man_tax_this_mth3 ==  _whereChq_reg_man_tax_this_mth3
				&& WhereChq_reg_man_tax_this_mth4 ==  _whereChq_reg_man_tax_this_mth4
				&& WhereChq_reg_man_tax_this_mth5 ==  _whereChq_reg_man_tax_this_mth5
				&& WhereChq_reg_man_tax_this_mth6 ==  _whereChq_reg_man_tax_this_mth6
				&& WhereChq_reg_man_tax_this_mth7 ==  _whereChq_reg_man_tax_this_mth7
				&& WhereChq_reg_man_tax_this_mth8 ==  _whereChq_reg_man_tax_this_mth8
				&& WhereChq_reg_man_tax_this_mth9 ==  _whereChq_reg_man_tax_this_mth9
				&& WhereChq_reg_man_tax_this_mth10 ==  _whereChq_reg_man_tax_this_mth10
				&& WhereChq_reg_man_tax_this_mth11 ==  _whereChq_reg_man_tax_this_mth11
				&& WhereChq_reg_man_tax_this_mth12 ==  _whereChq_reg_man_tax_this_mth12
				&& WhereChq_reg_man_tax_this_mth13 ==  _whereChq_reg_man_tax_this_mth13
				&& WhereChq_reg_man_tax_this_mth14 ==  _whereChq_reg_man_tax_this_mth14
				&& WhereChq_reg_man_tax_this_mth15 ==  _whereChq_reg_man_tax_this_mth15
				&& WhereChq_reg_man_tax_this_mth16 ==  _whereChq_reg_man_tax_this_mth16
				&& WhereChq_reg_man_tax_this_mth17 ==  _whereChq_reg_man_tax_this_mth17
				&& WhereChq_reg_man_tax_this_mth18 ==  _whereChq_reg_man_tax_this_mth18
				&& WhereChq_reg_pay_date1 ==  _whereChq_reg_pay_date1
				&& WhereChq_reg_pay_date2 ==  _whereChq_reg_pay_date2
				&& WhereChq_reg_pay_date3 ==  _whereChq_reg_pay_date3
				&& WhereChq_reg_pay_date4 ==  _whereChq_reg_pay_date4
				&& WhereChq_reg_pay_date5 ==  _whereChq_reg_pay_date5
				&& WhereChq_reg_pay_date6 ==  _whereChq_reg_pay_date6
				&& WhereChq_reg_pay_date7 ==  _whereChq_reg_pay_date7
				&& WhereChq_reg_pay_date8 ==  _whereChq_reg_pay_date8
				&& WhereChq_reg_pay_date9 ==  _whereChq_reg_pay_date9
				&& WhereChq_reg_pay_date10 ==  _whereChq_reg_pay_date10
				&& WhereChq_reg_pay_date11 ==  _whereChq_reg_pay_date11
				&& WhereChq_reg_pay_date12 ==  _whereChq_reg_pay_date12
				&& WhereChq_reg_pay_date13 ==  _whereChq_reg_pay_date13
				&& WhereChq_reg_pay_date14 ==  _whereChq_reg_pay_date14
				&& WhereChq_reg_pay_date15 ==  _whereChq_reg_pay_date15
				&& WhereChq_reg_pay_date16 ==  _whereChq_reg_pay_date16
				&& WhereChq_reg_pay_date17 ==  _whereChq_reg_pay_date17
				&& WhereChq_reg_pay_date18 ==  _whereChq_reg_pay_date18
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereChq_reg_clinic_nbr_1_2 = null; 
			WhereChq_reg_dept = null; 
			WhereChq_reg_doc_nbr = null; 
			WhereChq_reg_perc_bill1 = null; 
			WhereChq_reg_perc_bill2 = null; 
			WhereChq_reg_perc_bill3 = null; 
			WhereChq_reg_perc_bill4 = null; 
			WhereChq_reg_perc_bill5 = null; 
			WhereChq_reg_perc_bill6 = null; 
			WhereChq_reg_perc_bill7 = null; 
			WhereChq_reg_perc_bill8 = null; 
			WhereChq_reg_perc_bill9 = null; 
			WhereChq_reg_perc_bill10 = null; 
			WhereChq_reg_perc_bill11 = null; 
			WhereChq_reg_perc_bill12 = null; 
			WhereChq_reg_perc_bill13 = null; 
			WhereChq_reg_perc_bill14 = null; 
			WhereChq_reg_perc_bill15 = null; 
			WhereChq_reg_perc_bill16 = null; 
			WhereChq_reg_perc_bill17 = null; 
			WhereChq_reg_perc_bill18 = null; 
			WhereChq_reg_perc_misc1 = null; 
			WhereChq_reg_perc_misc2 = null; 
			WhereChq_reg_perc_misc3 = null; 
			WhereChq_reg_perc_misc4 = null; 
			WhereChq_reg_perc_misc5 = null; 
			WhereChq_reg_perc_misc6 = null; 
			WhereChq_reg_perc_misc7 = null; 
			WhereChq_reg_perc_misc8 = null; 
			WhereChq_reg_perc_misc9 = null; 
			WhereChq_reg_perc_misc10 = null; 
			WhereChq_reg_perc_misc11 = null; 
			WhereChq_reg_perc_misc12 = null; 
			WhereChq_reg_perc_misc13 = null; 
			WhereChq_reg_perc_misc14 = null; 
			WhereChq_reg_perc_misc15 = null; 
			WhereChq_reg_perc_misc16 = null; 
			WhereChq_reg_perc_misc17 = null; 
			WhereChq_reg_perc_misc18 = null; 
			WhereChq_reg_pay_code1 = null; 
			WhereChq_reg_pay_code2 = null; 
			WhereChq_reg_pay_code3 = null; 
			WhereChq_reg_pay_code4 = null; 
			WhereChq_reg_pay_code5 = null; 
			WhereChq_reg_pay_code6 = null; 
			WhereChq_reg_pay_code7 = null; 
			WhereChq_reg_pay_code8 = null; 
			WhereChq_reg_pay_code9 = null; 
			WhereChq_reg_pay_code10 = null; 
			WhereChq_reg_pay_code11 = null; 
			WhereChq_reg_pay_code12 = null; 
			WhereChq_reg_pay_code13 = null; 
			WhereChq_reg_pay_code14 = null; 
			WhereChq_reg_pay_code15 = null; 
			WhereChq_reg_pay_code16 = null; 
			WhereChq_reg_pay_code17 = null; 
			WhereChq_reg_pay_code18 = null; 
			WhereChq_reg_perc_tax1 = null; 
			WhereChq_reg_perc_tax2 = null; 
			WhereChq_reg_perc_tax3 = null; 
			WhereChq_reg_perc_tax4 = null; 
			WhereChq_reg_perc_tax5 = null; 
			WhereChq_reg_perc_tax6 = null; 
			WhereChq_reg_perc_tax7 = null; 
			WhereChq_reg_perc_tax8 = null; 
			WhereChq_reg_perc_tax9 = null; 
			WhereChq_reg_perc_tax10 = null; 
			WhereChq_reg_perc_tax11 = null; 
			WhereChq_reg_perc_tax12 = null; 
			WhereChq_reg_perc_tax13 = null; 
			WhereChq_reg_perc_tax14 = null; 
			WhereChq_reg_perc_tax15 = null; 
			WhereChq_reg_perc_tax16 = null; 
			WhereChq_reg_perc_tax17 = null; 
			WhereChq_reg_perc_tax18 = null; 
			WhereChq_reg_mth_bill_amt1 = null; 
			WhereChq_reg_mth_bill_amt2 = null; 
			WhereChq_reg_mth_bill_amt3 = null; 
			WhereChq_reg_mth_bill_amt4 = null; 
			WhereChq_reg_mth_bill_amt5 = null; 
			WhereChq_reg_mth_bill_amt6 = null; 
			WhereChq_reg_mth_bill_amt7 = null; 
			WhereChq_reg_mth_bill_amt8 = null; 
			WhereChq_reg_mth_bill_amt9 = null; 
			WhereChq_reg_mth_bill_amt10 = null; 
			WhereChq_reg_mth_bill_amt11 = null; 
			WhereChq_reg_mth_bill_amt12 = null; 
			WhereChq_reg_mth_bill_amt13 = null; 
			WhereChq_reg_mth_bill_amt14 = null; 
			WhereChq_reg_mth_bill_amt15 = null; 
			WhereChq_reg_mth_bill_amt16 = null; 
			WhereChq_reg_mth_bill_amt17 = null; 
			WhereChq_reg_mth_bill_amt18 = null; 
			WhereChq_reg_mth_misc_amt_11 = null; 
			WhereChq_reg_mth_misc_amt_12 = null; 
			WhereChq_reg_mth_misc_amt_13 = null; 
			WhereChq_reg_mth_misc_amt_14 = null; 
			WhereChq_reg_mth_misc_amt_15 = null; 
			WhereChq_reg_mth_misc_amt_16 = null; 
			WhereChq_reg_mth_misc_amt_17 = null; 
			WhereChq_reg_mth_misc_amt_18 = null; 
			WhereChq_reg_mth_misc_amt_19 = null; 
			WhereChq_reg_mth_misc_amt_110 = null; 
			WhereChq_reg_mth_misc_amt_111 = null; 
			WhereChq_reg_mth_misc_amt_112 = null; 
			WhereChq_reg_mth_misc_amt_113 = null; 
			WhereChq_reg_mth_misc_amt_114 = null; 
			WhereChq_reg_mth_misc_amt_115 = null; 
			WhereChq_reg_mth_misc_amt_116 = null; 
			WhereChq_reg_mth_misc_amt_117 = null; 
			WhereChq_reg_mth_misc_amt_118 = null; 
			WhereChq_reg_mth_misc_amt_21 = null; 
			WhereChq_reg_mth_misc_amt_22 = null; 
			WhereChq_reg_mth_misc_amt_23 = null; 
			WhereChq_reg_mth_misc_amt_24 = null; 
			WhereChq_reg_mth_misc_amt_25 = null; 
			WhereChq_reg_mth_misc_amt_26 = null; 
			WhereChq_reg_mth_misc_amt_27 = null; 
			WhereChq_reg_mth_misc_amt_28 = null; 
			WhereChq_reg_mth_misc_amt_29 = null; 
			WhereChq_reg_mth_misc_amt_210 = null; 
			WhereChq_reg_mth_misc_amt_211 = null; 
			WhereChq_reg_mth_misc_amt_212 = null; 
			WhereChq_reg_mth_misc_amt_213 = null; 
			WhereChq_reg_mth_misc_amt_214 = null; 
			WhereChq_reg_mth_misc_amt_215 = null; 
			WhereChq_reg_mth_misc_amt_216 = null; 
			WhereChq_reg_mth_misc_amt_217 = null; 
			WhereChq_reg_mth_misc_amt_218 = null; 
			WhereChq_reg_mth_misc_amt_31 = null; 
			WhereChq_reg_mth_misc_amt_32 = null; 
			WhereChq_reg_mth_misc_amt_33 = null; 
			WhereChq_reg_mth_misc_amt_34 = null; 
			WhereChq_reg_mth_misc_amt_35 = null; 
			WhereChq_reg_mth_misc_amt_36 = null; 
			WhereChq_reg_mth_misc_amt_37 = null; 
			WhereChq_reg_mth_misc_amt_38 = null; 
			WhereChq_reg_mth_misc_amt_39 = null; 
			WhereChq_reg_mth_misc_amt_310 = null; 
			WhereChq_reg_mth_misc_amt_311 = null; 
			WhereChq_reg_mth_misc_amt_312 = null; 
			WhereChq_reg_mth_misc_amt_313 = null; 
			WhereChq_reg_mth_misc_amt_314 = null; 
			WhereChq_reg_mth_misc_amt_315 = null; 
			WhereChq_reg_mth_misc_amt_316 = null; 
			WhereChq_reg_mth_misc_amt_317 = null; 
			WhereChq_reg_mth_misc_amt_318 = null; 
			WhereChq_reg_mth_misc_amt_41 = null; 
			WhereChq_reg_mth_misc_amt_42 = null; 
			WhereChq_reg_mth_misc_amt_43 = null; 
			WhereChq_reg_mth_misc_amt_44 = null; 
			WhereChq_reg_mth_misc_amt_45 = null; 
			WhereChq_reg_mth_misc_amt_46 = null; 
			WhereChq_reg_mth_misc_amt_47 = null; 
			WhereChq_reg_mth_misc_amt_48 = null; 
			WhereChq_reg_mth_misc_amt_49 = null; 
			WhereChq_reg_mth_misc_amt_410 = null; 
			WhereChq_reg_mth_misc_amt_411 = null; 
			WhereChq_reg_mth_misc_amt_412 = null; 
			WhereChq_reg_mth_misc_amt_413 = null; 
			WhereChq_reg_mth_misc_amt_414 = null; 
			WhereChq_reg_mth_misc_amt_415 = null; 
			WhereChq_reg_mth_misc_amt_416 = null; 
			WhereChq_reg_mth_misc_amt_417 = null; 
			WhereChq_reg_mth_misc_amt_418 = null; 
			WhereChq_reg_mth_misc_amt_51 = null; 
			WhereChq_reg_mth_misc_amt_52 = null; 
			WhereChq_reg_mth_misc_amt_53 = null; 
			WhereChq_reg_mth_misc_amt_54 = null; 
			WhereChq_reg_mth_misc_amt_55 = null; 
			WhereChq_reg_mth_misc_amt_56 = null; 
			WhereChq_reg_mth_misc_amt_57 = null; 
			WhereChq_reg_mth_misc_amt_58 = null; 
			WhereChq_reg_mth_misc_amt_59 = null; 
			WhereChq_reg_mth_misc_amt_510 = null; 
			WhereChq_reg_mth_misc_amt_511 = null; 
			WhereChq_reg_mth_misc_amt_512 = null; 
			WhereChq_reg_mth_misc_amt_513 = null; 
			WhereChq_reg_mth_misc_amt_514 = null; 
			WhereChq_reg_mth_misc_amt_515 = null; 
			WhereChq_reg_mth_misc_amt_516 = null; 
			WhereChq_reg_mth_misc_amt_517 = null; 
			WhereChq_reg_mth_misc_amt_518 = null; 
			WhereChq_reg_mth_misc_amt_61 = null; 
			WhereChq_reg_mth_misc_amt_62 = null; 
			WhereChq_reg_mth_misc_amt_63 = null; 
			WhereChq_reg_mth_misc_amt_64 = null; 
			WhereChq_reg_mth_misc_amt_65 = null; 
			WhereChq_reg_mth_misc_amt_66 = null; 
			WhereChq_reg_mth_misc_amt_67 = null; 
			WhereChq_reg_mth_misc_amt_68 = null; 
			WhereChq_reg_mth_misc_amt_69 = null; 
			WhereChq_reg_mth_misc_amt_610 = null; 
			WhereChq_reg_mth_misc_amt_611 = null; 
			WhereChq_reg_mth_misc_amt_612 = null; 
			WhereChq_reg_mth_misc_amt_613 = null; 
			WhereChq_reg_mth_misc_amt_614 = null; 
			WhereChq_reg_mth_misc_amt_615 = null; 
			WhereChq_reg_mth_misc_amt_616 = null; 
			WhereChq_reg_mth_misc_amt_617 = null; 
			WhereChq_reg_mth_misc_amt_618 = null; 
			WhereChq_reg_mth_misc_amt_71 = null; 
			WhereChq_reg_mth_misc_amt_72 = null; 
			WhereChq_reg_mth_misc_amt_73 = null; 
			WhereChq_reg_mth_misc_amt_74 = null; 
			WhereChq_reg_mth_misc_amt_75 = null; 
			WhereChq_reg_mth_misc_amt_76 = null; 
			WhereChq_reg_mth_misc_amt_77 = null; 
			WhereChq_reg_mth_misc_amt_78 = null; 
			WhereChq_reg_mth_misc_amt_79 = null; 
			WhereChq_reg_mth_misc_amt_710 = null; 
			WhereChq_reg_mth_misc_amt_711 = null; 
			WhereChq_reg_mth_misc_amt_712 = null; 
			WhereChq_reg_mth_misc_amt_713 = null; 
			WhereChq_reg_mth_misc_amt_714 = null; 
			WhereChq_reg_mth_misc_amt_715 = null; 
			WhereChq_reg_mth_misc_amt_716 = null; 
			WhereChq_reg_mth_misc_amt_717 = null; 
			WhereChq_reg_mth_misc_amt_718 = null; 
			WhereChq_reg_mth_misc_amt_81 = null; 
			WhereChq_reg_mth_misc_amt_82 = null; 
			WhereChq_reg_mth_misc_amt_83 = null; 
			WhereChq_reg_mth_misc_amt_84 = null; 
			WhereChq_reg_mth_misc_amt_85 = null; 
			WhereChq_reg_mth_misc_amt_86 = null; 
			WhereChq_reg_mth_misc_amt_87 = null; 
			WhereChq_reg_mth_misc_amt_88 = null; 
			WhereChq_reg_mth_misc_amt_89 = null; 
			WhereChq_reg_mth_misc_amt_810 = null; 
			WhereChq_reg_mth_misc_amt_811 = null; 
			WhereChq_reg_mth_misc_amt_812 = null; 
			WhereChq_reg_mth_misc_amt_813 = null; 
			WhereChq_reg_mth_misc_amt_814 = null; 
			WhereChq_reg_mth_misc_amt_815 = null; 
			WhereChq_reg_mth_misc_amt_816 = null; 
			WhereChq_reg_mth_misc_amt_817 = null; 
			WhereChq_reg_mth_misc_amt_818 = null; 
			WhereChq_reg_mth_misc_amt_91 = null; 
			WhereChq_reg_mth_misc_amt_92 = null; 
			WhereChq_reg_mth_misc_amt_93 = null; 
			WhereChq_reg_mth_misc_amt_94 = null; 
			WhereChq_reg_mth_misc_amt_95 = null; 
			WhereChq_reg_mth_misc_amt_96 = null; 
			WhereChq_reg_mth_misc_amt_97 = null; 
			WhereChq_reg_mth_misc_amt_98 = null; 
			WhereChq_reg_mth_misc_amt_99 = null; 
			WhereChq_reg_mth_misc_amt_910 = null; 
			WhereChq_reg_mth_misc_amt_911 = null; 
			WhereChq_reg_mth_misc_amt_912 = null; 
			WhereChq_reg_mth_misc_amt_913 = null; 
			WhereChq_reg_mth_misc_amt_914 = null; 
			WhereChq_reg_mth_misc_amt_915 = null; 
			WhereChq_reg_mth_misc_amt_916 = null; 
			WhereChq_reg_mth_misc_amt_917 = null; 
			WhereChq_reg_mth_misc_amt_918 = null; 
			WhereChq_reg_mth_misc_amt_101 = null; 
			WhereChq_reg_mth_misc_amt_102 = null; 
			WhereChq_reg_mth_misc_amt_103 = null; 
			WhereChq_reg_mth_misc_amt_104 = null; 
			WhereChq_reg_mth_misc_amt_105 = null; 
			WhereChq_reg_mth_misc_amt_106 = null; 
			WhereChq_reg_mth_misc_amt_107 = null; 
			WhereChq_reg_mth_misc_amt_108 = null; 
			WhereChq_reg_mth_misc_amt_109 = null; 
			WhereChq_reg_mth_misc_amt_1010 = null; 
			WhereChq_reg_mth_misc_amt_1011 = null; 
			WhereChq_reg_mth_misc_amt_1012 = null; 
			WhereChq_reg_mth_misc_amt_1013 = null; 
			WhereChq_reg_mth_misc_amt_1014 = null; 
			WhereChq_reg_mth_misc_amt_1015 = null; 
			WhereChq_reg_mth_misc_amt_1016 = null; 
			WhereChq_reg_mth_misc_amt_1017 = null; 
			WhereChq_reg_mth_misc_amt_1018 = null; 
			WhereChq_reg_mth_exp_amt1 = null; 
			WhereChq_reg_mth_exp_amt2 = null; 
			WhereChq_reg_mth_exp_amt3 = null; 
			WhereChq_reg_mth_exp_amt4 = null; 
			WhereChq_reg_mth_exp_amt5 = null; 
			WhereChq_reg_mth_exp_amt6 = null; 
			WhereChq_reg_mth_exp_amt7 = null; 
			WhereChq_reg_mth_exp_amt8 = null; 
			WhereChq_reg_mth_exp_amt9 = null; 
			WhereChq_reg_mth_exp_amt10 = null; 
			WhereChq_reg_mth_exp_amt11 = null; 
			WhereChq_reg_mth_exp_amt12 = null; 
			WhereChq_reg_mth_exp_amt13 = null; 
			WhereChq_reg_mth_exp_amt14 = null; 
			WhereChq_reg_mth_exp_amt15 = null; 
			WhereChq_reg_mth_exp_amt16 = null; 
			WhereChq_reg_mth_exp_amt17 = null; 
			WhereChq_reg_mth_exp_amt18 = null; 
			WhereChq_reg_comp_ann_exp_this_pay1 = null; 
			WhereChq_reg_comp_ann_exp_this_pay2 = null; 
			WhereChq_reg_comp_ann_exp_this_pay3 = null; 
			WhereChq_reg_comp_ann_exp_this_pay4 = null; 
			WhereChq_reg_comp_ann_exp_this_pay5 = null; 
			WhereChq_reg_comp_ann_exp_this_pay6 = null; 
			WhereChq_reg_comp_ann_exp_this_pay7 = null; 
			WhereChq_reg_comp_ann_exp_this_pay8 = null; 
			WhereChq_reg_comp_ann_exp_this_pay9 = null; 
			WhereChq_reg_comp_ann_exp_this_pay10 = null; 
			WhereChq_reg_comp_ann_exp_this_pay11 = null; 
			WhereChq_reg_comp_ann_exp_this_pay12 = null; 
			WhereChq_reg_comp_ann_exp_this_pay13 = null; 
			WhereChq_reg_comp_ann_exp_this_pay14 = null; 
			WhereChq_reg_comp_ann_exp_this_pay15 = null; 
			WhereChq_reg_comp_ann_exp_this_pay16 = null; 
			WhereChq_reg_comp_ann_exp_this_pay17 = null; 
			WhereChq_reg_comp_ann_exp_this_pay18 = null; 
			WhereChq_reg_mth_ceil_amt1 = null; 
			WhereChq_reg_mth_ceil_amt2 = null; 
			WhereChq_reg_mth_ceil_amt3 = null; 
			WhereChq_reg_mth_ceil_amt4 = null; 
			WhereChq_reg_mth_ceil_amt5 = null; 
			WhereChq_reg_mth_ceil_amt6 = null; 
			WhereChq_reg_mth_ceil_amt7 = null; 
			WhereChq_reg_mth_ceil_amt8 = null; 
			WhereChq_reg_mth_ceil_amt9 = null; 
			WhereChq_reg_mth_ceil_amt10 = null; 
			WhereChq_reg_mth_ceil_amt11 = null; 
			WhereChq_reg_mth_ceil_amt12 = null; 
			WhereChq_reg_mth_ceil_amt13 = null; 
			WhereChq_reg_mth_ceil_amt14 = null; 
			WhereChq_reg_mth_ceil_amt15 = null; 
			WhereChq_reg_mth_ceil_amt16 = null; 
			WhereChq_reg_mth_ceil_amt17 = null; 
			WhereChq_reg_mth_ceil_amt18 = null; 
			WhereChq_reg_comp_ann_ceil_this_pay1 = null; 
			WhereChq_reg_comp_ann_ceil_this_pay2 = null; 
			WhereChq_reg_comp_ann_ceil_this_pay3 = null; 
			WhereChq_reg_comp_ann_ceil_this_pay4 = null; 
			WhereChq_reg_comp_ann_ceil_this_pay5 = null; 
			WhereChq_reg_comp_ann_ceil_this_pay6 = null; 
			WhereChq_reg_comp_ann_ceil_this_pay7 = null; 
			WhereChq_reg_comp_ann_ceil_this_pay8 = null; 
			WhereChq_reg_comp_ann_ceil_this_pay9 = null; 
			WhereChq_reg_comp_ann_ceil_this_pay10 = null; 
			WhereChq_reg_comp_ann_ceil_this_pay11 = null; 
			WhereChq_reg_comp_ann_ceil_this_pay12 = null; 
			WhereChq_reg_comp_ann_ceil_this_pay13 = null; 
			WhereChq_reg_comp_ann_ceil_this_pay14 = null; 
			WhereChq_reg_comp_ann_ceil_this_pay15 = null; 
			WhereChq_reg_comp_ann_ceil_this_pay16 = null; 
			WhereChq_reg_comp_ann_ceil_this_pay17 = null; 
			WhereChq_reg_comp_ann_ceil_this_pay18 = null; 
			WhereChq_reg_earnings_this_mth1 = null; 
			WhereChq_reg_earnings_this_mth2 = null; 
			WhereChq_reg_earnings_this_mth3 = null; 
			WhereChq_reg_earnings_this_mth4 = null; 
			WhereChq_reg_earnings_this_mth5 = null; 
			WhereChq_reg_earnings_this_mth6 = null; 
			WhereChq_reg_earnings_this_mth7 = null; 
			WhereChq_reg_earnings_this_mth8 = null; 
			WhereChq_reg_earnings_this_mth9 = null; 
			WhereChq_reg_earnings_this_mth10 = null; 
			WhereChq_reg_earnings_this_mth11 = null; 
			WhereChq_reg_earnings_this_mth12 = null; 
			WhereChq_reg_earnings_this_mth13 = null; 
			WhereChq_reg_earnings_this_mth14 = null; 
			WhereChq_reg_earnings_this_mth15 = null; 
			WhereChq_reg_earnings_this_mth16 = null; 
			WhereChq_reg_earnings_this_mth17 = null; 
			WhereChq_reg_earnings_this_mth18 = null; 
			WhereChq_reg_regular_pay_this_mth1 = null; 
			WhereChq_reg_regular_pay_this_mth2 = null; 
			WhereChq_reg_regular_pay_this_mth3 = null; 
			WhereChq_reg_regular_pay_this_mth4 = null; 
			WhereChq_reg_regular_pay_this_mth5 = null; 
			WhereChq_reg_regular_pay_this_mth6 = null; 
			WhereChq_reg_regular_pay_this_mth7 = null; 
			WhereChq_reg_regular_pay_this_mth8 = null; 
			WhereChq_reg_regular_pay_this_mth9 = null; 
			WhereChq_reg_regular_pay_this_mth10 = null; 
			WhereChq_reg_regular_pay_this_mth11 = null; 
			WhereChq_reg_regular_pay_this_mth12 = null; 
			WhereChq_reg_regular_pay_this_mth13 = null; 
			WhereChq_reg_regular_pay_this_mth14 = null; 
			WhereChq_reg_regular_pay_this_mth15 = null; 
			WhereChq_reg_regular_pay_this_mth16 = null; 
			WhereChq_reg_regular_pay_this_mth17 = null; 
			WhereChq_reg_regular_pay_this_mth18 = null; 
			WhereChq_reg_regular_tax_this_mth1 = null; 
			WhereChq_reg_regular_tax_this_mth2 = null; 
			WhereChq_reg_regular_tax_this_mth3 = null; 
			WhereChq_reg_regular_tax_this_mth4 = null; 
			WhereChq_reg_regular_tax_this_mth5 = null; 
			WhereChq_reg_regular_tax_this_mth6 = null; 
			WhereChq_reg_regular_tax_this_mth7 = null; 
			WhereChq_reg_regular_tax_this_mth8 = null; 
			WhereChq_reg_regular_tax_this_mth9 = null; 
			WhereChq_reg_regular_tax_this_mth10 = null; 
			WhereChq_reg_regular_tax_this_mth11 = null; 
			WhereChq_reg_regular_tax_this_mth12 = null; 
			WhereChq_reg_regular_tax_this_mth13 = null; 
			WhereChq_reg_regular_tax_this_mth14 = null; 
			WhereChq_reg_regular_tax_this_mth15 = null; 
			WhereChq_reg_regular_tax_this_mth16 = null; 
			WhereChq_reg_regular_tax_this_mth17 = null; 
			WhereChq_reg_regular_tax_this_mth18 = null; 
			WhereChq_reg_man_pay_this_mth1 = null; 
			WhereChq_reg_man_pay_this_mth2 = null; 
			WhereChq_reg_man_pay_this_mth3 = null; 
			WhereChq_reg_man_pay_this_mth4 = null; 
			WhereChq_reg_man_pay_this_mth5 = null; 
			WhereChq_reg_man_pay_this_mth6 = null; 
			WhereChq_reg_man_pay_this_mth7 = null; 
			WhereChq_reg_man_pay_this_mth8 = null; 
			WhereChq_reg_man_pay_this_mth9 = null; 
			WhereChq_reg_man_pay_this_mth10 = null; 
			WhereChq_reg_man_pay_this_mth11 = null; 
			WhereChq_reg_man_pay_this_mth12 = null; 
			WhereChq_reg_man_pay_this_mth13 = null; 
			WhereChq_reg_man_pay_this_mth14 = null; 
			WhereChq_reg_man_pay_this_mth15 = null; 
			WhereChq_reg_man_pay_this_mth16 = null; 
			WhereChq_reg_man_pay_this_mth17 = null; 
			WhereChq_reg_man_pay_this_mth18 = null; 
			WhereChq_reg_man_tax_this_mth1 = null; 
			WhereChq_reg_man_tax_this_mth2 = null; 
			WhereChq_reg_man_tax_this_mth3 = null; 
			WhereChq_reg_man_tax_this_mth4 = null; 
			WhereChq_reg_man_tax_this_mth5 = null; 
			WhereChq_reg_man_tax_this_mth6 = null; 
			WhereChq_reg_man_tax_this_mth7 = null; 
			WhereChq_reg_man_tax_this_mth8 = null; 
			WhereChq_reg_man_tax_this_mth9 = null; 
			WhereChq_reg_man_tax_this_mth10 = null; 
			WhereChq_reg_man_tax_this_mth11 = null; 
			WhereChq_reg_man_tax_this_mth12 = null; 
			WhereChq_reg_man_tax_this_mth13 = null; 
			WhereChq_reg_man_tax_this_mth14 = null; 
			WhereChq_reg_man_tax_this_mth15 = null; 
			WhereChq_reg_man_tax_this_mth16 = null; 
			WhereChq_reg_man_tax_this_mth17 = null; 
			WhereChq_reg_man_tax_this_mth18 = null; 
			WhereChq_reg_pay_date1 = null; 
			WhereChq_reg_pay_date2 = null; 
			WhereChq_reg_pay_date3 = null; 
			WhereChq_reg_pay_date4 = null; 
			WhereChq_reg_pay_date5 = null; 
			WhereChq_reg_pay_date6 = null; 
			WhereChq_reg_pay_date7 = null; 
			WhereChq_reg_pay_date8 = null; 
			WhereChq_reg_pay_date9 = null; 
			WhereChq_reg_pay_date10 = null; 
			WhereChq_reg_pay_date11 = null; 
			WhereChq_reg_pay_date12 = null; 
			WhereChq_reg_pay_date13 = null; 
			WhereChq_reg_pay_date14 = null; 
			WhereChq_reg_pay_date15 = null; 
			WhereChq_reg_pay_date16 = null; 
			WhereChq_reg_pay_date17 = null; 
			WhereChq_reg_pay_date18 = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private decimal? _CHQ_REG_CLINIC_NBR_1_2;
		private decimal? _CHQ_REG_DEPT;
		private string _CHQ_REG_DOC_NBR;
		private decimal? _CHQ_REG_PERC_BILL1;
		private decimal? _CHQ_REG_PERC_BILL2;
		private decimal? _CHQ_REG_PERC_BILL3;
		private decimal? _CHQ_REG_PERC_BILL4;
		private decimal? _CHQ_REG_PERC_BILL5;
		private decimal? _CHQ_REG_PERC_BILL6;
		private decimal? _CHQ_REG_PERC_BILL7;
		private decimal? _CHQ_REG_PERC_BILL8;
		private decimal? _CHQ_REG_PERC_BILL9;
		private decimal? _CHQ_REG_PERC_BILL10;
		private decimal? _CHQ_REG_PERC_BILL11;
		private decimal? _CHQ_REG_PERC_BILL12;
		private decimal? _CHQ_REG_PERC_BILL13;
		private decimal? _CHQ_REG_PERC_BILL14;
		private decimal? _CHQ_REG_PERC_BILL15;
		private decimal? _CHQ_REG_PERC_BILL16;
		private decimal? _CHQ_REG_PERC_BILL17;
		private decimal? _CHQ_REG_PERC_BILL18;
		private decimal? _CHQ_REG_PERC_MISC1;
		private decimal? _CHQ_REG_PERC_MISC2;
		private decimal? _CHQ_REG_PERC_MISC3;
		private decimal? _CHQ_REG_PERC_MISC4;
		private decimal? _CHQ_REG_PERC_MISC5;
		private decimal? _CHQ_REG_PERC_MISC6;
		private decimal? _CHQ_REG_PERC_MISC7;
		private decimal? _CHQ_REG_PERC_MISC8;
		private decimal? _CHQ_REG_PERC_MISC9;
		private decimal? _CHQ_REG_PERC_MISC10;
		private decimal? _CHQ_REG_PERC_MISC11;
		private decimal? _CHQ_REG_PERC_MISC12;
		private decimal? _CHQ_REG_PERC_MISC13;
		private decimal? _CHQ_REG_PERC_MISC14;
		private decimal? _CHQ_REG_PERC_MISC15;
		private decimal? _CHQ_REG_PERC_MISC16;
		private decimal? _CHQ_REG_PERC_MISC17;
		private decimal? _CHQ_REG_PERC_MISC18;
		private string _CHQ_REG_PAY_CODE1;
		private string _CHQ_REG_PAY_CODE2;
		private string _CHQ_REG_PAY_CODE3;
		private string _CHQ_REG_PAY_CODE4;
		private string _CHQ_REG_PAY_CODE5;
		private string _CHQ_REG_PAY_CODE6;
		private string _CHQ_REG_PAY_CODE7;
		private string _CHQ_REG_PAY_CODE8;
		private string _CHQ_REG_PAY_CODE9;
		private string _CHQ_REG_PAY_CODE10;
		private string _CHQ_REG_PAY_CODE11;
		private string _CHQ_REG_PAY_CODE12;
		private string _CHQ_REG_PAY_CODE13;
		private string _CHQ_REG_PAY_CODE14;
		private string _CHQ_REG_PAY_CODE15;
		private string _CHQ_REG_PAY_CODE16;
		private string _CHQ_REG_PAY_CODE17;
		private string _CHQ_REG_PAY_CODE18;
		private decimal? _CHQ_REG_PERC_TAX1;
		private decimal? _CHQ_REG_PERC_TAX2;
		private decimal? _CHQ_REG_PERC_TAX3;
		private decimal? _CHQ_REG_PERC_TAX4;
		private decimal? _CHQ_REG_PERC_TAX5;
		private decimal? _CHQ_REG_PERC_TAX6;
		private decimal? _CHQ_REG_PERC_TAX7;
		private decimal? _CHQ_REG_PERC_TAX8;
		private decimal? _CHQ_REG_PERC_TAX9;
		private decimal? _CHQ_REG_PERC_TAX10;
		private decimal? _CHQ_REG_PERC_TAX11;
		private decimal? _CHQ_REG_PERC_TAX12;
		private decimal? _CHQ_REG_PERC_TAX13;
		private decimal? _CHQ_REG_PERC_TAX14;
		private decimal? _CHQ_REG_PERC_TAX15;
		private decimal? _CHQ_REG_PERC_TAX16;
		private decimal? _CHQ_REG_PERC_TAX17;
		private decimal? _CHQ_REG_PERC_TAX18;
		private decimal? _CHQ_REG_MTH_BILL_AMT1;
		private decimal? _CHQ_REG_MTH_BILL_AMT2;
		private decimal? _CHQ_REG_MTH_BILL_AMT3;
		private decimal? _CHQ_REG_MTH_BILL_AMT4;
		private decimal? _CHQ_REG_MTH_BILL_AMT5;
		private decimal? _CHQ_REG_MTH_BILL_AMT6;
		private decimal? _CHQ_REG_MTH_BILL_AMT7;
		private decimal? _CHQ_REG_MTH_BILL_AMT8;
		private decimal? _CHQ_REG_MTH_BILL_AMT9;
		private decimal? _CHQ_REG_MTH_BILL_AMT10;
		private decimal? _CHQ_REG_MTH_BILL_AMT11;
		private decimal? _CHQ_REG_MTH_BILL_AMT12;
		private decimal? _CHQ_REG_MTH_BILL_AMT13;
		private decimal? _CHQ_REG_MTH_BILL_AMT14;
		private decimal? _CHQ_REG_MTH_BILL_AMT15;
		private decimal? _CHQ_REG_MTH_BILL_AMT16;
		private decimal? _CHQ_REG_MTH_BILL_AMT17;
		private decimal? _CHQ_REG_MTH_BILL_AMT18;
		private decimal? _CHQ_REG_MTH_MISC_AMT_11;
		private decimal? _CHQ_REG_MTH_MISC_AMT_12;
		private decimal? _CHQ_REG_MTH_MISC_AMT_13;
		private decimal? _CHQ_REG_MTH_MISC_AMT_14;
		private decimal? _CHQ_REG_MTH_MISC_AMT_15;
		private decimal? _CHQ_REG_MTH_MISC_AMT_16;
		private decimal? _CHQ_REG_MTH_MISC_AMT_17;
		private decimal? _CHQ_REG_MTH_MISC_AMT_18;
		private decimal? _CHQ_REG_MTH_MISC_AMT_19;
		private decimal? _CHQ_REG_MTH_MISC_AMT_110;
		private decimal? _CHQ_REG_MTH_MISC_AMT_111;
		private decimal? _CHQ_REG_MTH_MISC_AMT_112;
		private decimal? _CHQ_REG_MTH_MISC_AMT_113;
		private decimal? _CHQ_REG_MTH_MISC_AMT_114;
		private decimal? _CHQ_REG_MTH_MISC_AMT_115;
		private decimal? _CHQ_REG_MTH_MISC_AMT_116;
		private decimal? _CHQ_REG_MTH_MISC_AMT_117;
		private decimal? _CHQ_REG_MTH_MISC_AMT_118;
		private decimal? _CHQ_REG_MTH_MISC_AMT_21;
		private decimal? _CHQ_REG_MTH_MISC_AMT_22;
		private decimal? _CHQ_REG_MTH_MISC_AMT_23;
		private decimal? _CHQ_REG_MTH_MISC_AMT_24;
		private decimal? _CHQ_REG_MTH_MISC_AMT_25;
		private decimal? _CHQ_REG_MTH_MISC_AMT_26;
		private decimal? _CHQ_REG_MTH_MISC_AMT_27;
		private decimal? _CHQ_REG_MTH_MISC_AMT_28;
		private decimal? _CHQ_REG_MTH_MISC_AMT_29;
		private decimal? _CHQ_REG_MTH_MISC_AMT_210;
		private decimal? _CHQ_REG_MTH_MISC_AMT_211;
		private decimal? _CHQ_REG_MTH_MISC_AMT_212;
		private decimal? _CHQ_REG_MTH_MISC_AMT_213;
		private decimal? _CHQ_REG_MTH_MISC_AMT_214;
		private decimal? _CHQ_REG_MTH_MISC_AMT_215;
		private decimal? _CHQ_REG_MTH_MISC_AMT_216;
		private decimal? _CHQ_REG_MTH_MISC_AMT_217;
		private decimal? _CHQ_REG_MTH_MISC_AMT_218;
		private decimal? _CHQ_REG_MTH_MISC_AMT_31;
		private decimal? _CHQ_REG_MTH_MISC_AMT_32;
		private decimal? _CHQ_REG_MTH_MISC_AMT_33;
		private decimal? _CHQ_REG_MTH_MISC_AMT_34;
		private decimal? _CHQ_REG_MTH_MISC_AMT_35;
		private decimal? _CHQ_REG_MTH_MISC_AMT_36;
		private decimal? _CHQ_REG_MTH_MISC_AMT_37;
		private decimal? _CHQ_REG_MTH_MISC_AMT_38;
		private decimal? _CHQ_REG_MTH_MISC_AMT_39;
		private decimal? _CHQ_REG_MTH_MISC_AMT_310;
		private decimal? _CHQ_REG_MTH_MISC_AMT_311;
		private decimal? _CHQ_REG_MTH_MISC_AMT_312;
		private decimal? _CHQ_REG_MTH_MISC_AMT_313;
		private decimal? _CHQ_REG_MTH_MISC_AMT_314;
		private decimal? _CHQ_REG_MTH_MISC_AMT_315;
		private decimal? _CHQ_REG_MTH_MISC_AMT_316;
		private decimal? _CHQ_REG_MTH_MISC_AMT_317;
		private decimal? _CHQ_REG_MTH_MISC_AMT_318;
		private decimal? _CHQ_REG_MTH_MISC_AMT_41;
		private decimal? _CHQ_REG_MTH_MISC_AMT_42;
		private decimal? _CHQ_REG_MTH_MISC_AMT_43;
		private decimal? _CHQ_REG_MTH_MISC_AMT_44;
		private decimal? _CHQ_REG_MTH_MISC_AMT_45;
		private decimal? _CHQ_REG_MTH_MISC_AMT_46;
		private decimal? _CHQ_REG_MTH_MISC_AMT_47;
		private decimal? _CHQ_REG_MTH_MISC_AMT_48;
		private decimal? _CHQ_REG_MTH_MISC_AMT_49;
		private decimal? _CHQ_REG_MTH_MISC_AMT_410;
		private decimal? _CHQ_REG_MTH_MISC_AMT_411;
		private decimal? _CHQ_REG_MTH_MISC_AMT_412;
		private decimal? _CHQ_REG_MTH_MISC_AMT_413;
		private decimal? _CHQ_REG_MTH_MISC_AMT_414;
		private decimal? _CHQ_REG_MTH_MISC_AMT_415;
		private decimal? _CHQ_REG_MTH_MISC_AMT_416;
		private decimal? _CHQ_REG_MTH_MISC_AMT_417;
		private decimal? _CHQ_REG_MTH_MISC_AMT_418;
		private decimal? _CHQ_REG_MTH_MISC_AMT_51;
		private decimal? _CHQ_REG_MTH_MISC_AMT_52;
		private decimal? _CHQ_REG_MTH_MISC_AMT_53;
		private decimal? _CHQ_REG_MTH_MISC_AMT_54;
		private decimal? _CHQ_REG_MTH_MISC_AMT_55;
		private decimal? _CHQ_REG_MTH_MISC_AMT_56;
		private decimal? _CHQ_REG_MTH_MISC_AMT_57;
		private decimal? _CHQ_REG_MTH_MISC_AMT_58;
		private decimal? _CHQ_REG_MTH_MISC_AMT_59;
		private decimal? _CHQ_REG_MTH_MISC_AMT_510;
		private decimal? _CHQ_REG_MTH_MISC_AMT_511;
		private decimal? _CHQ_REG_MTH_MISC_AMT_512;
		private decimal? _CHQ_REG_MTH_MISC_AMT_513;
		private decimal? _CHQ_REG_MTH_MISC_AMT_514;
		private decimal? _CHQ_REG_MTH_MISC_AMT_515;
		private decimal? _CHQ_REG_MTH_MISC_AMT_516;
		private decimal? _CHQ_REG_MTH_MISC_AMT_517;
		private decimal? _CHQ_REG_MTH_MISC_AMT_518;
		private decimal? _CHQ_REG_MTH_MISC_AMT_61;
		private decimal? _CHQ_REG_MTH_MISC_AMT_62;
		private decimal? _CHQ_REG_MTH_MISC_AMT_63;
		private decimal? _CHQ_REG_MTH_MISC_AMT_64;
		private decimal? _CHQ_REG_MTH_MISC_AMT_65;
		private decimal? _CHQ_REG_MTH_MISC_AMT_66;
		private decimal? _CHQ_REG_MTH_MISC_AMT_67;
		private decimal? _CHQ_REG_MTH_MISC_AMT_68;
		private decimal? _CHQ_REG_MTH_MISC_AMT_69;
		private decimal? _CHQ_REG_MTH_MISC_AMT_610;
		private decimal? _CHQ_REG_MTH_MISC_AMT_611;
		private decimal? _CHQ_REG_MTH_MISC_AMT_612;
		private decimal? _CHQ_REG_MTH_MISC_AMT_613;
		private decimal? _CHQ_REG_MTH_MISC_AMT_614;
		private decimal? _CHQ_REG_MTH_MISC_AMT_615;
		private decimal? _CHQ_REG_MTH_MISC_AMT_616;
		private decimal? _CHQ_REG_MTH_MISC_AMT_617;
		private decimal? _CHQ_REG_MTH_MISC_AMT_618;
		private decimal? _CHQ_REG_MTH_MISC_AMT_71;
		private decimal? _CHQ_REG_MTH_MISC_AMT_72;
		private decimal? _CHQ_REG_MTH_MISC_AMT_73;
		private decimal? _CHQ_REG_MTH_MISC_AMT_74;
		private decimal? _CHQ_REG_MTH_MISC_AMT_75;
		private decimal? _CHQ_REG_MTH_MISC_AMT_76;
		private decimal? _CHQ_REG_MTH_MISC_AMT_77;
		private decimal? _CHQ_REG_MTH_MISC_AMT_78;
		private decimal? _CHQ_REG_MTH_MISC_AMT_79;
		private decimal? _CHQ_REG_MTH_MISC_AMT_710;
		private decimal? _CHQ_REG_MTH_MISC_AMT_711;
		private decimal? _CHQ_REG_MTH_MISC_AMT_712;
		private decimal? _CHQ_REG_MTH_MISC_AMT_713;
		private decimal? _CHQ_REG_MTH_MISC_AMT_714;
		private decimal? _CHQ_REG_MTH_MISC_AMT_715;
		private decimal? _CHQ_REG_MTH_MISC_AMT_716;
		private decimal? _CHQ_REG_MTH_MISC_AMT_717;
		private decimal? _CHQ_REG_MTH_MISC_AMT_718;
		private decimal? _CHQ_REG_MTH_MISC_AMT_81;
		private decimal? _CHQ_REG_MTH_MISC_AMT_82;
		private decimal? _CHQ_REG_MTH_MISC_AMT_83;
		private decimal? _CHQ_REG_MTH_MISC_AMT_84;
		private decimal? _CHQ_REG_MTH_MISC_AMT_85;
		private decimal? _CHQ_REG_MTH_MISC_AMT_86;
		private decimal? _CHQ_REG_MTH_MISC_AMT_87;
		private decimal? _CHQ_REG_MTH_MISC_AMT_88;
		private decimal? _CHQ_REG_MTH_MISC_AMT_89;
		private decimal? _CHQ_REG_MTH_MISC_AMT_810;
		private decimal? _CHQ_REG_MTH_MISC_AMT_811;
		private decimal? _CHQ_REG_MTH_MISC_AMT_812;
		private decimal? _CHQ_REG_MTH_MISC_AMT_813;
		private decimal? _CHQ_REG_MTH_MISC_AMT_814;
		private decimal? _CHQ_REG_MTH_MISC_AMT_815;
		private decimal? _CHQ_REG_MTH_MISC_AMT_816;
		private decimal? _CHQ_REG_MTH_MISC_AMT_817;
		private decimal? _CHQ_REG_MTH_MISC_AMT_818;
		private decimal? _CHQ_REG_MTH_MISC_AMT_91;
		private decimal? _CHQ_REG_MTH_MISC_AMT_92;
		private decimal? _CHQ_REG_MTH_MISC_AMT_93;
		private decimal? _CHQ_REG_MTH_MISC_AMT_94;
		private decimal? _CHQ_REG_MTH_MISC_AMT_95;
		private decimal? _CHQ_REG_MTH_MISC_AMT_96;
		private decimal? _CHQ_REG_MTH_MISC_AMT_97;
		private decimal? _CHQ_REG_MTH_MISC_AMT_98;
		private decimal? _CHQ_REG_MTH_MISC_AMT_99;
		private decimal? _CHQ_REG_MTH_MISC_AMT_910;
		private decimal? _CHQ_REG_MTH_MISC_AMT_911;
		private decimal? _CHQ_REG_MTH_MISC_AMT_912;
		private decimal? _CHQ_REG_MTH_MISC_AMT_913;
		private decimal? _CHQ_REG_MTH_MISC_AMT_914;
		private decimal? _CHQ_REG_MTH_MISC_AMT_915;
		private decimal? _CHQ_REG_MTH_MISC_AMT_916;
		private decimal? _CHQ_REG_MTH_MISC_AMT_917;
		private decimal? _CHQ_REG_MTH_MISC_AMT_918;
		private decimal? _CHQ_REG_MTH_MISC_AMT_101;
		private decimal? _CHQ_REG_MTH_MISC_AMT_102;
		private decimal? _CHQ_REG_MTH_MISC_AMT_103;
		private decimal? _CHQ_REG_MTH_MISC_AMT_104;
		private decimal? _CHQ_REG_MTH_MISC_AMT_105;
		private decimal? _CHQ_REG_MTH_MISC_AMT_106;
		private decimal? _CHQ_REG_MTH_MISC_AMT_107;
		private decimal? _CHQ_REG_MTH_MISC_AMT_108;
		private decimal? _CHQ_REG_MTH_MISC_AMT_109;
		private decimal? _CHQ_REG_MTH_MISC_AMT_1010;
		private decimal? _CHQ_REG_MTH_MISC_AMT_1011;
		private decimal? _CHQ_REG_MTH_MISC_AMT_1012;
		private decimal? _CHQ_REG_MTH_MISC_AMT_1013;
		private decimal? _CHQ_REG_MTH_MISC_AMT_1014;
		private decimal? _CHQ_REG_MTH_MISC_AMT_1015;
		private decimal? _CHQ_REG_MTH_MISC_AMT_1016;
		private decimal? _CHQ_REG_MTH_MISC_AMT_1017;
		private decimal? _CHQ_REG_MTH_MISC_AMT_1018;
		private decimal? _CHQ_REG_MTH_EXP_AMT1;
		private decimal? _CHQ_REG_MTH_EXP_AMT2;
		private decimal? _CHQ_REG_MTH_EXP_AMT3;
		private decimal? _CHQ_REG_MTH_EXP_AMT4;
		private decimal? _CHQ_REG_MTH_EXP_AMT5;
		private decimal? _CHQ_REG_MTH_EXP_AMT6;
		private decimal? _CHQ_REG_MTH_EXP_AMT7;
		private decimal? _CHQ_REG_MTH_EXP_AMT8;
		private decimal? _CHQ_REG_MTH_EXP_AMT9;
		private decimal? _CHQ_REG_MTH_EXP_AMT10;
		private decimal? _CHQ_REG_MTH_EXP_AMT11;
		private decimal? _CHQ_REG_MTH_EXP_AMT12;
		private decimal? _CHQ_REG_MTH_EXP_AMT13;
		private decimal? _CHQ_REG_MTH_EXP_AMT14;
		private decimal? _CHQ_REG_MTH_EXP_AMT15;
		private decimal? _CHQ_REG_MTH_EXP_AMT16;
		private decimal? _CHQ_REG_MTH_EXP_AMT17;
		private decimal? _CHQ_REG_MTH_EXP_AMT18;
		private decimal? _CHQ_REG_COMP_ANN_EXP_THIS_PAY1;
		private decimal? _CHQ_REG_COMP_ANN_EXP_THIS_PAY2;
		private decimal? _CHQ_REG_COMP_ANN_EXP_THIS_PAY3;
		private decimal? _CHQ_REG_COMP_ANN_EXP_THIS_PAY4;
		private decimal? _CHQ_REG_COMP_ANN_EXP_THIS_PAY5;
		private decimal? _CHQ_REG_COMP_ANN_EXP_THIS_PAY6;
		private decimal? _CHQ_REG_COMP_ANN_EXP_THIS_PAY7;
		private decimal? _CHQ_REG_COMP_ANN_EXP_THIS_PAY8;
		private decimal? _CHQ_REG_COMP_ANN_EXP_THIS_PAY9;
		private decimal? _CHQ_REG_COMP_ANN_EXP_THIS_PAY10;
		private decimal? _CHQ_REG_COMP_ANN_EXP_THIS_PAY11;
		private decimal? _CHQ_REG_COMP_ANN_EXP_THIS_PAY12;
		private decimal? _CHQ_REG_COMP_ANN_EXP_THIS_PAY13;
		private decimal? _CHQ_REG_COMP_ANN_EXP_THIS_PAY14;
		private decimal? _CHQ_REG_COMP_ANN_EXP_THIS_PAY15;
		private decimal? _CHQ_REG_COMP_ANN_EXP_THIS_PAY16;
		private decimal? _CHQ_REG_COMP_ANN_EXP_THIS_PAY17;
		private decimal? _CHQ_REG_COMP_ANN_EXP_THIS_PAY18;
		private decimal? _CHQ_REG_MTH_CEIL_AMT1;
		private decimal? _CHQ_REG_MTH_CEIL_AMT2;
		private decimal? _CHQ_REG_MTH_CEIL_AMT3;
		private decimal? _CHQ_REG_MTH_CEIL_AMT4;
		private decimal? _CHQ_REG_MTH_CEIL_AMT5;
		private decimal? _CHQ_REG_MTH_CEIL_AMT6;
		private decimal? _CHQ_REG_MTH_CEIL_AMT7;
		private decimal? _CHQ_REG_MTH_CEIL_AMT8;
		private decimal? _CHQ_REG_MTH_CEIL_AMT9;
		private decimal? _CHQ_REG_MTH_CEIL_AMT10;
		private decimal? _CHQ_REG_MTH_CEIL_AMT11;
		private decimal? _CHQ_REG_MTH_CEIL_AMT12;
		private decimal? _CHQ_REG_MTH_CEIL_AMT13;
		private decimal? _CHQ_REG_MTH_CEIL_AMT14;
		private decimal? _CHQ_REG_MTH_CEIL_AMT15;
		private decimal? _CHQ_REG_MTH_CEIL_AMT16;
		private decimal? _CHQ_REG_MTH_CEIL_AMT17;
		private decimal? _CHQ_REG_MTH_CEIL_AMT18;
		private decimal? _CHQ_REG_COMP_ANN_CEIL_THIS_PAY1;
		private decimal? _CHQ_REG_COMP_ANN_CEIL_THIS_PAY2;
		private decimal? _CHQ_REG_COMP_ANN_CEIL_THIS_PAY3;
		private decimal? _CHQ_REG_COMP_ANN_CEIL_THIS_PAY4;
		private decimal? _CHQ_REG_COMP_ANN_CEIL_THIS_PAY5;
		private decimal? _CHQ_REG_COMP_ANN_CEIL_THIS_PAY6;
		private decimal? _CHQ_REG_COMP_ANN_CEIL_THIS_PAY7;
		private decimal? _CHQ_REG_COMP_ANN_CEIL_THIS_PAY8;
		private decimal? _CHQ_REG_COMP_ANN_CEIL_THIS_PAY9;
		private decimal? _CHQ_REG_COMP_ANN_CEIL_THIS_PAY10;
		private decimal? _CHQ_REG_COMP_ANN_CEIL_THIS_PAY11;
		private decimal? _CHQ_REG_COMP_ANN_CEIL_THIS_PAY12;
		private decimal? _CHQ_REG_COMP_ANN_CEIL_THIS_PAY13;
		private decimal? _CHQ_REG_COMP_ANN_CEIL_THIS_PAY14;
		private decimal? _CHQ_REG_COMP_ANN_CEIL_THIS_PAY15;
		private decimal? _CHQ_REG_COMP_ANN_CEIL_THIS_PAY16;
		private decimal? _CHQ_REG_COMP_ANN_CEIL_THIS_PAY17;
		private decimal? _CHQ_REG_COMP_ANN_CEIL_THIS_PAY18;
		private decimal? _CHQ_REG_EARNINGS_THIS_MTH1;
		private decimal? _CHQ_REG_EARNINGS_THIS_MTH2;
		private decimal? _CHQ_REG_EARNINGS_THIS_MTH3;
		private decimal? _CHQ_REG_EARNINGS_THIS_MTH4;
		private decimal? _CHQ_REG_EARNINGS_THIS_MTH5;
		private decimal? _CHQ_REG_EARNINGS_THIS_MTH6;
		private decimal? _CHQ_REG_EARNINGS_THIS_MTH7;
		private decimal? _CHQ_REG_EARNINGS_THIS_MTH8;
		private decimal? _CHQ_REG_EARNINGS_THIS_MTH9;
		private decimal? _CHQ_REG_EARNINGS_THIS_MTH10;
		private decimal? _CHQ_REG_EARNINGS_THIS_MTH11;
		private decimal? _CHQ_REG_EARNINGS_THIS_MTH12;
		private decimal? _CHQ_REG_EARNINGS_THIS_MTH13;
		private decimal? _CHQ_REG_EARNINGS_THIS_MTH14;
		private decimal? _CHQ_REG_EARNINGS_THIS_MTH15;
		private decimal? _CHQ_REG_EARNINGS_THIS_MTH16;
		private decimal? _CHQ_REG_EARNINGS_THIS_MTH17;
		private decimal? _CHQ_REG_EARNINGS_THIS_MTH18;
		private decimal? _CHQ_REG_REGULAR_PAY_THIS_MTH1;
		private decimal? _CHQ_REG_REGULAR_PAY_THIS_MTH2;
		private decimal? _CHQ_REG_REGULAR_PAY_THIS_MTH3;
		private decimal? _CHQ_REG_REGULAR_PAY_THIS_MTH4;
		private decimal? _CHQ_REG_REGULAR_PAY_THIS_MTH5;
		private decimal? _CHQ_REG_REGULAR_PAY_THIS_MTH6;
		private decimal? _CHQ_REG_REGULAR_PAY_THIS_MTH7;
		private decimal? _CHQ_REG_REGULAR_PAY_THIS_MTH8;
		private decimal? _CHQ_REG_REGULAR_PAY_THIS_MTH9;
		private decimal? _CHQ_REG_REGULAR_PAY_THIS_MTH10;
		private decimal? _CHQ_REG_REGULAR_PAY_THIS_MTH11;
		private decimal? _CHQ_REG_REGULAR_PAY_THIS_MTH12;
		private decimal? _CHQ_REG_REGULAR_PAY_THIS_MTH13;
		private decimal? _CHQ_REG_REGULAR_PAY_THIS_MTH14;
		private decimal? _CHQ_REG_REGULAR_PAY_THIS_MTH15;
		private decimal? _CHQ_REG_REGULAR_PAY_THIS_MTH16;
		private decimal? _CHQ_REG_REGULAR_PAY_THIS_MTH17;
		private decimal? _CHQ_REG_REGULAR_PAY_THIS_MTH18;
		private decimal? _CHQ_REG_REGULAR_TAX_THIS_MTH1;
		private decimal? _CHQ_REG_REGULAR_TAX_THIS_MTH2;
		private decimal? _CHQ_REG_REGULAR_TAX_THIS_MTH3;
		private decimal? _CHQ_REG_REGULAR_TAX_THIS_MTH4;
		private decimal? _CHQ_REG_REGULAR_TAX_THIS_MTH5;
		private decimal? _CHQ_REG_REGULAR_TAX_THIS_MTH6;
		private decimal? _CHQ_REG_REGULAR_TAX_THIS_MTH7;
		private decimal? _CHQ_REG_REGULAR_TAX_THIS_MTH8;
		private decimal? _CHQ_REG_REGULAR_TAX_THIS_MTH9;
		private decimal? _CHQ_REG_REGULAR_TAX_THIS_MTH10;
		private decimal? _CHQ_REG_REGULAR_TAX_THIS_MTH11;
		private decimal? _CHQ_REG_REGULAR_TAX_THIS_MTH12;
		private decimal? _CHQ_REG_REGULAR_TAX_THIS_MTH13;
		private decimal? _CHQ_REG_REGULAR_TAX_THIS_MTH14;
		private decimal? _CHQ_REG_REGULAR_TAX_THIS_MTH15;
		private decimal? _CHQ_REG_REGULAR_TAX_THIS_MTH16;
		private decimal? _CHQ_REG_REGULAR_TAX_THIS_MTH17;
		private decimal? _CHQ_REG_REGULAR_TAX_THIS_MTH18;
		private decimal? _CHQ_REG_MAN_PAY_THIS_MTH1;
		private decimal? _CHQ_REG_MAN_PAY_THIS_MTH2;
		private decimal? _CHQ_REG_MAN_PAY_THIS_MTH3;
		private decimal? _CHQ_REG_MAN_PAY_THIS_MTH4;
		private decimal? _CHQ_REG_MAN_PAY_THIS_MTH5;
		private decimal? _CHQ_REG_MAN_PAY_THIS_MTH6;
		private decimal? _CHQ_REG_MAN_PAY_THIS_MTH7;
		private decimal? _CHQ_REG_MAN_PAY_THIS_MTH8;
		private decimal? _CHQ_REG_MAN_PAY_THIS_MTH9;
		private decimal? _CHQ_REG_MAN_PAY_THIS_MTH10;
		private decimal? _CHQ_REG_MAN_PAY_THIS_MTH11;
		private decimal? _CHQ_REG_MAN_PAY_THIS_MTH12;
		private decimal? _CHQ_REG_MAN_PAY_THIS_MTH13;
		private decimal? _CHQ_REG_MAN_PAY_THIS_MTH14;
		private decimal? _CHQ_REG_MAN_PAY_THIS_MTH15;
		private decimal? _CHQ_REG_MAN_PAY_THIS_MTH16;
		private decimal? _CHQ_REG_MAN_PAY_THIS_MTH17;
		private decimal? _CHQ_REG_MAN_PAY_THIS_MTH18;
		private decimal? _CHQ_REG_MAN_TAX_THIS_MTH1;
		private decimal? _CHQ_REG_MAN_TAX_THIS_MTH2;
		private decimal? _CHQ_REG_MAN_TAX_THIS_MTH3;
		private decimal? _CHQ_REG_MAN_TAX_THIS_MTH4;
		private decimal? _CHQ_REG_MAN_TAX_THIS_MTH5;
		private decimal? _CHQ_REG_MAN_TAX_THIS_MTH6;
		private decimal? _CHQ_REG_MAN_TAX_THIS_MTH7;
		private decimal? _CHQ_REG_MAN_TAX_THIS_MTH8;
		private decimal? _CHQ_REG_MAN_TAX_THIS_MTH9;
		private decimal? _CHQ_REG_MAN_TAX_THIS_MTH10;
		private decimal? _CHQ_REG_MAN_TAX_THIS_MTH11;
		private decimal? _CHQ_REG_MAN_TAX_THIS_MTH12;
		private decimal? _CHQ_REG_MAN_TAX_THIS_MTH13;
		private decimal? _CHQ_REG_MAN_TAX_THIS_MTH14;
		private decimal? _CHQ_REG_MAN_TAX_THIS_MTH15;
		private decimal? _CHQ_REG_MAN_TAX_THIS_MTH16;
		private decimal? _CHQ_REG_MAN_TAX_THIS_MTH17;
		private decimal? _CHQ_REG_MAN_TAX_THIS_MTH18;
		private decimal? _CHQ_REG_PAY_DATE1;
		private decimal? _CHQ_REG_PAY_DATE2;
		private decimal? _CHQ_REG_PAY_DATE3;
		private decimal? _CHQ_REG_PAY_DATE4;
		private decimal? _CHQ_REG_PAY_DATE5;
		private decimal? _CHQ_REG_PAY_DATE6;
		private decimal? _CHQ_REG_PAY_DATE7;
		private decimal? _CHQ_REG_PAY_DATE8;
		private decimal? _CHQ_REG_PAY_DATE9;
		private decimal? _CHQ_REG_PAY_DATE10;
		private decimal? _CHQ_REG_PAY_DATE11;
		private decimal? _CHQ_REG_PAY_DATE12;
		private decimal? _CHQ_REG_PAY_DATE13;
		private decimal? _CHQ_REG_PAY_DATE14;
		private decimal? _CHQ_REG_PAY_DATE15;
		private decimal? _CHQ_REG_PAY_DATE16;
		private decimal? _CHQ_REG_PAY_DATE17;
		private decimal? _CHQ_REG_PAY_DATE18;
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
		public decimal? CHQ_REG_CLINIC_NBR_1_2
		{
			get { return _CHQ_REG_CLINIC_NBR_1_2; }
			set
			{
				if (_CHQ_REG_CLINIC_NBR_1_2 != value)
				{
					_CHQ_REG_CLINIC_NBR_1_2 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_DEPT
		{
			get { return _CHQ_REG_DEPT; }
			set
			{
				if (_CHQ_REG_DEPT != value)
				{
					_CHQ_REG_DEPT = value;
					ChangeState();
				}
			}
		}
		public string CHQ_REG_DOC_NBR
		{
			get { return _CHQ_REG_DOC_NBR; }
			set
			{
				if (_CHQ_REG_DOC_NBR != value)
				{
					_CHQ_REG_DOC_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_BILL1
		{
			get { return _CHQ_REG_PERC_BILL1; }
			set
			{
				if (_CHQ_REG_PERC_BILL1 != value)
				{
					_CHQ_REG_PERC_BILL1 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_BILL2
		{
			get { return _CHQ_REG_PERC_BILL2; }
			set
			{
				if (_CHQ_REG_PERC_BILL2 != value)
				{
					_CHQ_REG_PERC_BILL2 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_BILL3
		{
			get { return _CHQ_REG_PERC_BILL3; }
			set
			{
				if (_CHQ_REG_PERC_BILL3 != value)
				{
					_CHQ_REG_PERC_BILL3 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_BILL4
		{
			get { return _CHQ_REG_PERC_BILL4; }
			set
			{
				if (_CHQ_REG_PERC_BILL4 != value)
				{
					_CHQ_REG_PERC_BILL4 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_BILL5
		{
			get { return _CHQ_REG_PERC_BILL5; }
			set
			{
				if (_CHQ_REG_PERC_BILL5 != value)
				{
					_CHQ_REG_PERC_BILL5 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_BILL6
		{
			get { return _CHQ_REG_PERC_BILL6; }
			set
			{
				if (_CHQ_REG_PERC_BILL6 != value)
				{
					_CHQ_REG_PERC_BILL6 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_BILL7
		{
			get { return _CHQ_REG_PERC_BILL7; }
			set
			{
				if (_CHQ_REG_PERC_BILL7 != value)
				{
					_CHQ_REG_PERC_BILL7 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_BILL8
		{
			get { return _CHQ_REG_PERC_BILL8; }
			set
			{
				if (_CHQ_REG_PERC_BILL8 != value)
				{
					_CHQ_REG_PERC_BILL8 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_BILL9
		{
			get { return _CHQ_REG_PERC_BILL9; }
			set
			{
				if (_CHQ_REG_PERC_BILL9 != value)
				{
					_CHQ_REG_PERC_BILL9 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_BILL10
		{
			get { return _CHQ_REG_PERC_BILL10; }
			set
			{
				if (_CHQ_REG_PERC_BILL10 != value)
				{
					_CHQ_REG_PERC_BILL10 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_BILL11
		{
			get { return _CHQ_REG_PERC_BILL11; }
			set
			{
				if (_CHQ_REG_PERC_BILL11 != value)
				{
					_CHQ_REG_PERC_BILL11 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_BILL12
		{
			get { return _CHQ_REG_PERC_BILL12; }
			set
			{
				if (_CHQ_REG_PERC_BILL12 != value)
				{
					_CHQ_REG_PERC_BILL12 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_BILL13
		{
			get { return _CHQ_REG_PERC_BILL13; }
			set
			{
				if (_CHQ_REG_PERC_BILL13 != value)
				{
					_CHQ_REG_PERC_BILL13 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_BILL14
		{
			get { return _CHQ_REG_PERC_BILL14; }
			set
			{
				if (_CHQ_REG_PERC_BILL14 != value)
				{
					_CHQ_REG_PERC_BILL14 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_BILL15
		{
			get { return _CHQ_REG_PERC_BILL15; }
			set
			{
				if (_CHQ_REG_PERC_BILL15 != value)
				{
					_CHQ_REG_PERC_BILL15 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_BILL16
		{
			get { return _CHQ_REG_PERC_BILL16; }
			set
			{
				if (_CHQ_REG_PERC_BILL16 != value)
				{
					_CHQ_REG_PERC_BILL16 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_BILL17
		{
			get { return _CHQ_REG_PERC_BILL17; }
			set
			{
				if (_CHQ_REG_PERC_BILL17 != value)
				{
					_CHQ_REG_PERC_BILL17 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_BILL18
		{
			get { return _CHQ_REG_PERC_BILL18; }
			set
			{
				if (_CHQ_REG_PERC_BILL18 != value)
				{
					_CHQ_REG_PERC_BILL18 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_MISC1
		{
			get { return _CHQ_REG_PERC_MISC1; }
			set
			{
				if (_CHQ_REG_PERC_MISC1 != value)
				{
					_CHQ_REG_PERC_MISC1 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_MISC2
		{
			get { return _CHQ_REG_PERC_MISC2; }
			set
			{
				if (_CHQ_REG_PERC_MISC2 != value)
				{
					_CHQ_REG_PERC_MISC2 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_MISC3
		{
			get { return _CHQ_REG_PERC_MISC3; }
			set
			{
				if (_CHQ_REG_PERC_MISC3 != value)
				{
					_CHQ_REG_PERC_MISC3 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_MISC4
		{
			get { return _CHQ_REG_PERC_MISC4; }
			set
			{
				if (_CHQ_REG_PERC_MISC4 != value)
				{
					_CHQ_REG_PERC_MISC4 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_MISC5
		{
			get { return _CHQ_REG_PERC_MISC5; }
			set
			{
				if (_CHQ_REG_PERC_MISC5 != value)
				{
					_CHQ_REG_PERC_MISC5 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_MISC6
		{
			get { return _CHQ_REG_PERC_MISC6; }
			set
			{
				if (_CHQ_REG_PERC_MISC6 != value)
				{
					_CHQ_REG_PERC_MISC6 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_MISC7
		{
			get { return _CHQ_REG_PERC_MISC7; }
			set
			{
				if (_CHQ_REG_PERC_MISC7 != value)
				{
					_CHQ_REG_PERC_MISC7 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_MISC8
		{
			get { return _CHQ_REG_PERC_MISC8; }
			set
			{
				if (_CHQ_REG_PERC_MISC8 != value)
				{
					_CHQ_REG_PERC_MISC8 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_MISC9
		{
			get { return _CHQ_REG_PERC_MISC9; }
			set
			{
				if (_CHQ_REG_PERC_MISC9 != value)
				{
					_CHQ_REG_PERC_MISC9 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_MISC10
		{
			get { return _CHQ_REG_PERC_MISC10; }
			set
			{
				if (_CHQ_REG_PERC_MISC10 != value)
				{
					_CHQ_REG_PERC_MISC10 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_MISC11
		{
			get { return _CHQ_REG_PERC_MISC11; }
			set
			{
				if (_CHQ_REG_PERC_MISC11 != value)
				{
					_CHQ_REG_PERC_MISC11 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_MISC12
		{
			get { return _CHQ_REG_PERC_MISC12; }
			set
			{
				if (_CHQ_REG_PERC_MISC12 != value)
				{
					_CHQ_REG_PERC_MISC12 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_MISC13
		{
			get { return _CHQ_REG_PERC_MISC13; }
			set
			{
				if (_CHQ_REG_PERC_MISC13 != value)
				{
					_CHQ_REG_PERC_MISC13 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_MISC14
		{
			get { return _CHQ_REG_PERC_MISC14; }
			set
			{
				if (_CHQ_REG_PERC_MISC14 != value)
				{
					_CHQ_REG_PERC_MISC14 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_MISC15
		{
			get { return _CHQ_REG_PERC_MISC15; }
			set
			{
				if (_CHQ_REG_PERC_MISC15 != value)
				{
					_CHQ_REG_PERC_MISC15 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_MISC16
		{
			get { return _CHQ_REG_PERC_MISC16; }
			set
			{
				if (_CHQ_REG_PERC_MISC16 != value)
				{
					_CHQ_REG_PERC_MISC16 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_MISC17
		{
			get { return _CHQ_REG_PERC_MISC17; }
			set
			{
				if (_CHQ_REG_PERC_MISC17 != value)
				{
					_CHQ_REG_PERC_MISC17 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_MISC18
		{
			get { return _CHQ_REG_PERC_MISC18; }
			set
			{
				if (_CHQ_REG_PERC_MISC18 != value)
				{
					_CHQ_REG_PERC_MISC18 = value;
					ChangeState();
				}
			}
		}
		public string CHQ_REG_PAY_CODE1
		{
			get { return _CHQ_REG_PAY_CODE1; }
			set
			{
				if (_CHQ_REG_PAY_CODE1 != value)
				{
					_CHQ_REG_PAY_CODE1 = value;
					ChangeState();
				}
			}
		}
		public string CHQ_REG_PAY_CODE2
		{
			get { return _CHQ_REG_PAY_CODE2; }
			set
			{
				if (_CHQ_REG_PAY_CODE2 != value)
				{
					_CHQ_REG_PAY_CODE2 = value;
					ChangeState();
				}
			}
		}
		public string CHQ_REG_PAY_CODE3
		{
			get { return _CHQ_REG_PAY_CODE3; }
			set
			{
				if (_CHQ_REG_PAY_CODE3 != value)
				{
					_CHQ_REG_PAY_CODE3 = value;
					ChangeState();
				}
			}
		}
		public string CHQ_REG_PAY_CODE4
		{
			get { return _CHQ_REG_PAY_CODE4; }
			set
			{
				if (_CHQ_REG_PAY_CODE4 != value)
				{
					_CHQ_REG_PAY_CODE4 = value;
					ChangeState();
				}
			}
		}
		public string CHQ_REG_PAY_CODE5
		{
			get { return _CHQ_REG_PAY_CODE5; }
			set
			{
				if (_CHQ_REG_PAY_CODE5 != value)
				{
					_CHQ_REG_PAY_CODE5 = value;
					ChangeState();
				}
			}
		}
		public string CHQ_REG_PAY_CODE6
		{
			get { return _CHQ_REG_PAY_CODE6; }
			set
			{
				if (_CHQ_REG_PAY_CODE6 != value)
				{
					_CHQ_REG_PAY_CODE6 = value;
					ChangeState();
				}
			}
		}
		public string CHQ_REG_PAY_CODE7
		{
			get { return _CHQ_REG_PAY_CODE7; }
			set
			{
				if (_CHQ_REG_PAY_CODE7 != value)
				{
					_CHQ_REG_PAY_CODE7 = value;
					ChangeState();
				}
			}
		}
		public string CHQ_REG_PAY_CODE8
		{
			get { return _CHQ_REG_PAY_CODE8; }
			set
			{
				if (_CHQ_REG_PAY_CODE8 != value)
				{
					_CHQ_REG_PAY_CODE8 = value;
					ChangeState();
				}
			}
		}
		public string CHQ_REG_PAY_CODE9
		{
			get { return _CHQ_REG_PAY_CODE9; }
			set
			{
				if (_CHQ_REG_PAY_CODE9 != value)
				{
					_CHQ_REG_PAY_CODE9 = value;
					ChangeState();
				}
			}
		}
		public string CHQ_REG_PAY_CODE10
		{
			get { return _CHQ_REG_PAY_CODE10; }
			set
			{
				if (_CHQ_REG_PAY_CODE10 != value)
				{
					_CHQ_REG_PAY_CODE10 = value;
					ChangeState();
				}
			}
		}
		public string CHQ_REG_PAY_CODE11
		{
			get { return _CHQ_REG_PAY_CODE11; }
			set
			{
				if (_CHQ_REG_PAY_CODE11 != value)
				{
					_CHQ_REG_PAY_CODE11 = value;
					ChangeState();
				}
			}
		}
		public string CHQ_REG_PAY_CODE12
		{
			get { return _CHQ_REG_PAY_CODE12; }
			set
			{
				if (_CHQ_REG_PAY_CODE12 != value)
				{
					_CHQ_REG_PAY_CODE12 = value;
					ChangeState();
				}
			}
		}
		public string CHQ_REG_PAY_CODE13
		{
			get { return _CHQ_REG_PAY_CODE13; }
			set
			{
				if (_CHQ_REG_PAY_CODE13 != value)
				{
					_CHQ_REG_PAY_CODE13 = value;
					ChangeState();
				}
			}
		}
		public string CHQ_REG_PAY_CODE14
		{
			get { return _CHQ_REG_PAY_CODE14; }
			set
			{
				if (_CHQ_REG_PAY_CODE14 != value)
				{
					_CHQ_REG_PAY_CODE14 = value;
					ChangeState();
				}
			}
		}
		public string CHQ_REG_PAY_CODE15
		{
			get { return _CHQ_REG_PAY_CODE15; }
			set
			{
				if (_CHQ_REG_PAY_CODE15 != value)
				{
					_CHQ_REG_PAY_CODE15 = value;
					ChangeState();
				}
			}
		}
		public string CHQ_REG_PAY_CODE16
		{
			get { return _CHQ_REG_PAY_CODE16; }
			set
			{
				if (_CHQ_REG_PAY_CODE16 != value)
				{
					_CHQ_REG_PAY_CODE16 = value;
					ChangeState();
				}
			}
		}
		public string CHQ_REG_PAY_CODE17
		{
			get { return _CHQ_REG_PAY_CODE17; }
			set
			{
				if (_CHQ_REG_PAY_CODE17 != value)
				{
					_CHQ_REG_PAY_CODE17 = value;
					ChangeState();
				}
			}
		}
		public string CHQ_REG_PAY_CODE18
		{
			get { return _CHQ_REG_PAY_CODE18; }
			set
			{
				if (_CHQ_REG_PAY_CODE18 != value)
				{
					_CHQ_REG_PAY_CODE18 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_TAX1
		{
			get { return _CHQ_REG_PERC_TAX1; }
			set
			{
				if (_CHQ_REG_PERC_TAX1 != value)
				{
					_CHQ_REG_PERC_TAX1 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_TAX2
		{
			get { return _CHQ_REG_PERC_TAX2; }
			set
			{
				if (_CHQ_REG_PERC_TAX2 != value)
				{
					_CHQ_REG_PERC_TAX2 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_TAX3
		{
			get { return _CHQ_REG_PERC_TAX3; }
			set
			{
				if (_CHQ_REG_PERC_TAX3 != value)
				{
					_CHQ_REG_PERC_TAX3 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_TAX4
		{
			get { return _CHQ_REG_PERC_TAX4; }
			set
			{
				if (_CHQ_REG_PERC_TAX4 != value)
				{
					_CHQ_REG_PERC_TAX4 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_TAX5
		{
			get { return _CHQ_REG_PERC_TAX5; }
			set
			{
				if (_CHQ_REG_PERC_TAX5 != value)
				{
					_CHQ_REG_PERC_TAX5 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_TAX6
		{
			get { return _CHQ_REG_PERC_TAX6; }
			set
			{
				if (_CHQ_REG_PERC_TAX6 != value)
				{
					_CHQ_REG_PERC_TAX6 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_TAX7
		{
			get { return _CHQ_REG_PERC_TAX7; }
			set
			{
				if (_CHQ_REG_PERC_TAX7 != value)
				{
					_CHQ_REG_PERC_TAX7 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_TAX8
		{
			get { return _CHQ_REG_PERC_TAX8; }
			set
			{
				if (_CHQ_REG_PERC_TAX8 != value)
				{
					_CHQ_REG_PERC_TAX8 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_TAX9
		{
			get { return _CHQ_REG_PERC_TAX9; }
			set
			{
				if (_CHQ_REG_PERC_TAX9 != value)
				{
					_CHQ_REG_PERC_TAX9 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_TAX10
		{
			get { return _CHQ_REG_PERC_TAX10; }
			set
			{
				if (_CHQ_REG_PERC_TAX10 != value)
				{
					_CHQ_REG_PERC_TAX10 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_TAX11
		{
			get { return _CHQ_REG_PERC_TAX11; }
			set
			{
				if (_CHQ_REG_PERC_TAX11 != value)
				{
					_CHQ_REG_PERC_TAX11 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_TAX12
		{
			get { return _CHQ_REG_PERC_TAX12; }
			set
			{
				if (_CHQ_REG_PERC_TAX12 != value)
				{
					_CHQ_REG_PERC_TAX12 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_TAX13
		{
			get { return _CHQ_REG_PERC_TAX13; }
			set
			{
				if (_CHQ_REG_PERC_TAX13 != value)
				{
					_CHQ_REG_PERC_TAX13 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_TAX14
		{
			get { return _CHQ_REG_PERC_TAX14; }
			set
			{
				if (_CHQ_REG_PERC_TAX14 != value)
				{
					_CHQ_REG_PERC_TAX14 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_TAX15
		{
			get { return _CHQ_REG_PERC_TAX15; }
			set
			{
				if (_CHQ_REG_PERC_TAX15 != value)
				{
					_CHQ_REG_PERC_TAX15 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_TAX16
		{
			get { return _CHQ_REG_PERC_TAX16; }
			set
			{
				if (_CHQ_REG_PERC_TAX16 != value)
				{
					_CHQ_REG_PERC_TAX16 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_TAX17
		{
			get { return _CHQ_REG_PERC_TAX17; }
			set
			{
				if (_CHQ_REG_PERC_TAX17 != value)
				{
					_CHQ_REG_PERC_TAX17 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PERC_TAX18
		{
			get { return _CHQ_REG_PERC_TAX18; }
			set
			{
				if (_CHQ_REG_PERC_TAX18 != value)
				{
					_CHQ_REG_PERC_TAX18 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_BILL_AMT1
		{
			get { return _CHQ_REG_MTH_BILL_AMT1; }
			set
			{
				if (_CHQ_REG_MTH_BILL_AMT1 != value)
				{
					_CHQ_REG_MTH_BILL_AMT1 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_BILL_AMT2
		{
			get { return _CHQ_REG_MTH_BILL_AMT2; }
			set
			{
				if (_CHQ_REG_MTH_BILL_AMT2 != value)
				{
					_CHQ_REG_MTH_BILL_AMT2 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_BILL_AMT3
		{
			get { return _CHQ_REG_MTH_BILL_AMT3; }
			set
			{
				if (_CHQ_REG_MTH_BILL_AMT3 != value)
				{
					_CHQ_REG_MTH_BILL_AMT3 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_BILL_AMT4
		{
			get { return _CHQ_REG_MTH_BILL_AMT4; }
			set
			{
				if (_CHQ_REG_MTH_BILL_AMT4 != value)
				{
					_CHQ_REG_MTH_BILL_AMT4 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_BILL_AMT5
		{
			get { return _CHQ_REG_MTH_BILL_AMT5; }
			set
			{
				if (_CHQ_REG_MTH_BILL_AMT5 != value)
				{
					_CHQ_REG_MTH_BILL_AMT5 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_BILL_AMT6
		{
			get { return _CHQ_REG_MTH_BILL_AMT6; }
			set
			{
				if (_CHQ_REG_MTH_BILL_AMT6 != value)
				{
					_CHQ_REG_MTH_BILL_AMT6 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_BILL_AMT7
		{
			get { return _CHQ_REG_MTH_BILL_AMT7; }
			set
			{
				if (_CHQ_REG_MTH_BILL_AMT7 != value)
				{
					_CHQ_REG_MTH_BILL_AMT7 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_BILL_AMT8
		{
			get { return _CHQ_REG_MTH_BILL_AMT8; }
			set
			{
				if (_CHQ_REG_MTH_BILL_AMT8 != value)
				{
					_CHQ_REG_MTH_BILL_AMT8 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_BILL_AMT9
		{
			get { return _CHQ_REG_MTH_BILL_AMT9; }
			set
			{
				if (_CHQ_REG_MTH_BILL_AMT9 != value)
				{
					_CHQ_REG_MTH_BILL_AMT9 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_BILL_AMT10
		{
			get { return _CHQ_REG_MTH_BILL_AMT10; }
			set
			{
				if (_CHQ_REG_MTH_BILL_AMT10 != value)
				{
					_CHQ_REG_MTH_BILL_AMT10 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_BILL_AMT11
		{
			get { return _CHQ_REG_MTH_BILL_AMT11; }
			set
			{
				if (_CHQ_REG_MTH_BILL_AMT11 != value)
				{
					_CHQ_REG_MTH_BILL_AMT11 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_BILL_AMT12
		{
			get { return _CHQ_REG_MTH_BILL_AMT12; }
			set
			{
				if (_CHQ_REG_MTH_BILL_AMT12 != value)
				{
					_CHQ_REG_MTH_BILL_AMT12 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_BILL_AMT13
		{
			get { return _CHQ_REG_MTH_BILL_AMT13; }
			set
			{
				if (_CHQ_REG_MTH_BILL_AMT13 != value)
				{
					_CHQ_REG_MTH_BILL_AMT13 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_BILL_AMT14
		{
			get { return _CHQ_REG_MTH_BILL_AMT14; }
			set
			{
				if (_CHQ_REG_MTH_BILL_AMT14 != value)
				{
					_CHQ_REG_MTH_BILL_AMT14 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_BILL_AMT15
		{
			get { return _CHQ_REG_MTH_BILL_AMT15; }
			set
			{
				if (_CHQ_REG_MTH_BILL_AMT15 != value)
				{
					_CHQ_REG_MTH_BILL_AMT15 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_BILL_AMT16
		{
			get { return _CHQ_REG_MTH_BILL_AMT16; }
			set
			{
				if (_CHQ_REG_MTH_BILL_AMT16 != value)
				{
					_CHQ_REG_MTH_BILL_AMT16 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_BILL_AMT17
		{
			get { return _CHQ_REG_MTH_BILL_AMT17; }
			set
			{
				if (_CHQ_REG_MTH_BILL_AMT17 != value)
				{
					_CHQ_REG_MTH_BILL_AMT17 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_BILL_AMT18
		{
			get { return _CHQ_REG_MTH_BILL_AMT18; }
			set
			{
				if (_CHQ_REG_MTH_BILL_AMT18 != value)
				{
					_CHQ_REG_MTH_BILL_AMT18 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_11
		{
			get { return _CHQ_REG_MTH_MISC_AMT_11; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_11 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_11 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_12
		{
			get { return _CHQ_REG_MTH_MISC_AMT_12; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_12 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_12 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_13
		{
			get { return _CHQ_REG_MTH_MISC_AMT_13; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_13 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_13 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_14
		{
			get { return _CHQ_REG_MTH_MISC_AMT_14; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_14 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_14 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_15
		{
			get { return _CHQ_REG_MTH_MISC_AMT_15; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_15 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_15 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_16
		{
			get { return _CHQ_REG_MTH_MISC_AMT_16; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_16 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_16 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_17
		{
			get { return _CHQ_REG_MTH_MISC_AMT_17; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_17 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_17 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_18
		{
			get { return _CHQ_REG_MTH_MISC_AMT_18; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_18 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_18 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_19
		{
			get { return _CHQ_REG_MTH_MISC_AMT_19; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_19 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_19 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_110
		{
			get { return _CHQ_REG_MTH_MISC_AMT_110; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_110 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_110 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_111
		{
			get { return _CHQ_REG_MTH_MISC_AMT_111; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_111 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_111 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_112
		{
			get { return _CHQ_REG_MTH_MISC_AMT_112; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_112 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_112 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_113
		{
			get { return _CHQ_REG_MTH_MISC_AMT_113; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_113 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_113 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_114
		{
			get { return _CHQ_REG_MTH_MISC_AMT_114; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_114 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_114 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_115
		{
			get { return _CHQ_REG_MTH_MISC_AMT_115; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_115 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_115 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_116
		{
			get { return _CHQ_REG_MTH_MISC_AMT_116; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_116 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_116 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_117
		{
			get { return _CHQ_REG_MTH_MISC_AMT_117; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_117 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_117 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_118
		{
			get { return _CHQ_REG_MTH_MISC_AMT_118; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_118 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_118 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_21
		{
			get { return _CHQ_REG_MTH_MISC_AMT_21; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_21 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_21 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_22
		{
			get { return _CHQ_REG_MTH_MISC_AMT_22; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_22 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_22 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_23
		{
			get { return _CHQ_REG_MTH_MISC_AMT_23; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_23 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_23 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_24
		{
			get { return _CHQ_REG_MTH_MISC_AMT_24; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_24 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_24 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_25
		{
			get { return _CHQ_REG_MTH_MISC_AMT_25; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_25 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_25 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_26
		{
			get { return _CHQ_REG_MTH_MISC_AMT_26; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_26 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_26 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_27
		{
			get { return _CHQ_REG_MTH_MISC_AMT_27; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_27 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_27 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_28
		{
			get { return _CHQ_REG_MTH_MISC_AMT_28; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_28 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_28 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_29
		{
			get { return _CHQ_REG_MTH_MISC_AMT_29; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_29 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_29 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_210
		{
			get { return _CHQ_REG_MTH_MISC_AMT_210; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_210 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_210 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_211
		{
			get { return _CHQ_REG_MTH_MISC_AMT_211; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_211 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_211 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_212
		{
			get { return _CHQ_REG_MTH_MISC_AMT_212; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_212 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_212 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_213
		{
			get { return _CHQ_REG_MTH_MISC_AMT_213; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_213 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_213 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_214
		{
			get { return _CHQ_REG_MTH_MISC_AMT_214; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_214 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_214 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_215
		{
			get { return _CHQ_REG_MTH_MISC_AMT_215; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_215 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_215 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_216
		{
			get { return _CHQ_REG_MTH_MISC_AMT_216; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_216 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_216 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_217
		{
			get { return _CHQ_REG_MTH_MISC_AMT_217; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_217 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_217 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_218
		{
			get { return _CHQ_REG_MTH_MISC_AMT_218; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_218 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_218 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_31
		{
			get { return _CHQ_REG_MTH_MISC_AMT_31; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_31 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_31 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_32
		{
			get { return _CHQ_REG_MTH_MISC_AMT_32; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_32 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_32 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_33
		{
			get { return _CHQ_REG_MTH_MISC_AMT_33; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_33 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_33 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_34
		{
			get { return _CHQ_REG_MTH_MISC_AMT_34; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_34 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_34 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_35
		{
			get { return _CHQ_REG_MTH_MISC_AMT_35; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_35 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_35 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_36
		{
			get { return _CHQ_REG_MTH_MISC_AMT_36; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_36 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_36 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_37
		{
			get { return _CHQ_REG_MTH_MISC_AMT_37; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_37 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_37 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_38
		{
			get { return _CHQ_REG_MTH_MISC_AMT_38; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_38 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_38 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_39
		{
			get { return _CHQ_REG_MTH_MISC_AMT_39; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_39 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_39 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_310
		{
			get { return _CHQ_REG_MTH_MISC_AMT_310; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_310 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_310 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_311
		{
			get { return _CHQ_REG_MTH_MISC_AMT_311; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_311 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_311 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_312
		{
			get { return _CHQ_REG_MTH_MISC_AMT_312; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_312 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_312 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_313
		{
			get { return _CHQ_REG_MTH_MISC_AMT_313; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_313 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_313 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_314
		{
			get { return _CHQ_REG_MTH_MISC_AMT_314; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_314 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_314 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_315
		{
			get { return _CHQ_REG_MTH_MISC_AMT_315; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_315 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_315 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_316
		{
			get { return _CHQ_REG_MTH_MISC_AMT_316; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_316 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_316 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_317
		{
			get { return _CHQ_REG_MTH_MISC_AMT_317; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_317 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_317 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_318
		{
			get { return _CHQ_REG_MTH_MISC_AMT_318; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_318 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_318 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_41
		{
			get { return _CHQ_REG_MTH_MISC_AMT_41; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_41 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_41 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_42
		{
			get { return _CHQ_REG_MTH_MISC_AMT_42; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_42 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_42 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_43
		{
			get { return _CHQ_REG_MTH_MISC_AMT_43; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_43 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_43 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_44
		{
			get { return _CHQ_REG_MTH_MISC_AMT_44; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_44 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_44 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_45
		{
			get { return _CHQ_REG_MTH_MISC_AMT_45; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_45 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_45 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_46
		{
			get { return _CHQ_REG_MTH_MISC_AMT_46; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_46 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_46 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_47
		{
			get { return _CHQ_REG_MTH_MISC_AMT_47; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_47 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_47 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_48
		{
			get { return _CHQ_REG_MTH_MISC_AMT_48; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_48 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_48 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_49
		{
			get { return _CHQ_REG_MTH_MISC_AMT_49; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_49 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_49 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_410
		{
			get { return _CHQ_REG_MTH_MISC_AMT_410; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_410 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_410 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_411
		{
			get { return _CHQ_REG_MTH_MISC_AMT_411; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_411 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_411 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_412
		{
			get { return _CHQ_REG_MTH_MISC_AMT_412; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_412 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_412 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_413
		{
			get { return _CHQ_REG_MTH_MISC_AMT_413; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_413 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_413 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_414
		{
			get { return _CHQ_REG_MTH_MISC_AMT_414; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_414 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_414 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_415
		{
			get { return _CHQ_REG_MTH_MISC_AMT_415; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_415 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_415 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_416
		{
			get { return _CHQ_REG_MTH_MISC_AMT_416; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_416 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_416 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_417
		{
			get { return _CHQ_REG_MTH_MISC_AMT_417; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_417 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_417 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_418
		{
			get { return _CHQ_REG_MTH_MISC_AMT_418; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_418 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_418 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_51
		{
			get { return _CHQ_REG_MTH_MISC_AMT_51; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_51 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_51 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_52
		{
			get { return _CHQ_REG_MTH_MISC_AMT_52; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_52 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_52 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_53
		{
			get { return _CHQ_REG_MTH_MISC_AMT_53; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_53 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_53 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_54
		{
			get { return _CHQ_REG_MTH_MISC_AMT_54; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_54 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_54 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_55
		{
			get { return _CHQ_REG_MTH_MISC_AMT_55; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_55 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_55 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_56
		{
			get { return _CHQ_REG_MTH_MISC_AMT_56; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_56 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_56 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_57
		{
			get { return _CHQ_REG_MTH_MISC_AMT_57; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_57 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_57 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_58
		{
			get { return _CHQ_REG_MTH_MISC_AMT_58; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_58 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_58 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_59
		{
			get { return _CHQ_REG_MTH_MISC_AMT_59; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_59 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_59 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_510
		{
			get { return _CHQ_REG_MTH_MISC_AMT_510; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_510 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_510 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_511
		{
			get { return _CHQ_REG_MTH_MISC_AMT_511; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_511 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_511 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_512
		{
			get { return _CHQ_REG_MTH_MISC_AMT_512; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_512 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_512 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_513
		{
			get { return _CHQ_REG_MTH_MISC_AMT_513; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_513 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_513 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_514
		{
			get { return _CHQ_REG_MTH_MISC_AMT_514; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_514 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_514 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_515
		{
			get { return _CHQ_REG_MTH_MISC_AMT_515; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_515 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_515 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_516
		{
			get { return _CHQ_REG_MTH_MISC_AMT_516; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_516 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_516 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_517
		{
			get { return _CHQ_REG_MTH_MISC_AMT_517; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_517 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_517 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_518
		{
			get { return _CHQ_REG_MTH_MISC_AMT_518; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_518 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_518 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_61
		{
			get { return _CHQ_REG_MTH_MISC_AMT_61; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_61 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_61 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_62
		{
			get { return _CHQ_REG_MTH_MISC_AMT_62; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_62 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_62 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_63
		{
			get { return _CHQ_REG_MTH_MISC_AMT_63; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_63 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_63 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_64
		{
			get { return _CHQ_REG_MTH_MISC_AMT_64; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_64 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_64 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_65
		{
			get { return _CHQ_REG_MTH_MISC_AMT_65; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_65 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_65 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_66
		{
			get { return _CHQ_REG_MTH_MISC_AMT_66; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_66 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_66 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_67
		{
			get { return _CHQ_REG_MTH_MISC_AMT_67; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_67 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_67 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_68
		{
			get { return _CHQ_REG_MTH_MISC_AMT_68; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_68 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_68 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_69
		{
			get { return _CHQ_REG_MTH_MISC_AMT_69; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_69 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_69 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_610
		{
			get { return _CHQ_REG_MTH_MISC_AMT_610; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_610 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_610 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_611
		{
			get { return _CHQ_REG_MTH_MISC_AMT_611; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_611 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_611 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_612
		{
			get { return _CHQ_REG_MTH_MISC_AMT_612; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_612 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_612 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_613
		{
			get { return _CHQ_REG_MTH_MISC_AMT_613; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_613 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_613 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_614
		{
			get { return _CHQ_REG_MTH_MISC_AMT_614; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_614 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_614 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_615
		{
			get { return _CHQ_REG_MTH_MISC_AMT_615; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_615 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_615 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_616
		{
			get { return _CHQ_REG_MTH_MISC_AMT_616; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_616 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_616 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_617
		{
			get { return _CHQ_REG_MTH_MISC_AMT_617; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_617 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_617 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_618
		{
			get { return _CHQ_REG_MTH_MISC_AMT_618; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_618 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_618 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_71
		{
			get { return _CHQ_REG_MTH_MISC_AMT_71; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_71 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_71 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_72
		{
			get { return _CHQ_REG_MTH_MISC_AMT_72; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_72 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_72 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_73
		{
			get { return _CHQ_REG_MTH_MISC_AMT_73; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_73 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_73 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_74
		{
			get { return _CHQ_REG_MTH_MISC_AMT_74; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_74 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_74 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_75
		{
			get { return _CHQ_REG_MTH_MISC_AMT_75; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_75 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_75 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_76
		{
			get { return _CHQ_REG_MTH_MISC_AMT_76; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_76 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_76 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_77
		{
			get { return _CHQ_REG_MTH_MISC_AMT_77; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_77 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_77 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_78
		{
			get { return _CHQ_REG_MTH_MISC_AMT_78; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_78 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_78 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_79
		{
			get { return _CHQ_REG_MTH_MISC_AMT_79; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_79 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_79 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_710
		{
			get { return _CHQ_REG_MTH_MISC_AMT_710; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_710 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_710 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_711
		{
			get { return _CHQ_REG_MTH_MISC_AMT_711; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_711 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_711 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_712
		{
			get { return _CHQ_REG_MTH_MISC_AMT_712; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_712 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_712 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_713
		{
			get { return _CHQ_REG_MTH_MISC_AMT_713; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_713 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_713 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_714
		{
			get { return _CHQ_REG_MTH_MISC_AMT_714; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_714 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_714 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_715
		{
			get { return _CHQ_REG_MTH_MISC_AMT_715; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_715 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_715 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_716
		{
			get { return _CHQ_REG_MTH_MISC_AMT_716; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_716 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_716 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_717
		{
			get { return _CHQ_REG_MTH_MISC_AMT_717; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_717 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_717 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_718
		{
			get { return _CHQ_REG_MTH_MISC_AMT_718; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_718 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_718 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_81
		{
			get { return _CHQ_REG_MTH_MISC_AMT_81; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_81 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_81 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_82
		{
			get { return _CHQ_REG_MTH_MISC_AMT_82; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_82 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_82 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_83
		{
			get { return _CHQ_REG_MTH_MISC_AMT_83; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_83 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_83 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_84
		{
			get { return _CHQ_REG_MTH_MISC_AMT_84; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_84 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_84 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_85
		{
			get { return _CHQ_REG_MTH_MISC_AMT_85; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_85 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_85 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_86
		{
			get { return _CHQ_REG_MTH_MISC_AMT_86; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_86 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_86 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_87
		{
			get { return _CHQ_REG_MTH_MISC_AMT_87; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_87 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_87 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_88
		{
			get { return _CHQ_REG_MTH_MISC_AMT_88; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_88 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_88 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_89
		{
			get { return _CHQ_REG_MTH_MISC_AMT_89; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_89 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_89 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_810
		{
			get { return _CHQ_REG_MTH_MISC_AMT_810; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_810 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_810 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_811
		{
			get { return _CHQ_REG_MTH_MISC_AMT_811; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_811 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_811 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_812
		{
			get { return _CHQ_REG_MTH_MISC_AMT_812; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_812 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_812 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_813
		{
			get { return _CHQ_REG_MTH_MISC_AMT_813; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_813 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_813 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_814
		{
			get { return _CHQ_REG_MTH_MISC_AMT_814; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_814 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_814 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_815
		{
			get { return _CHQ_REG_MTH_MISC_AMT_815; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_815 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_815 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_816
		{
			get { return _CHQ_REG_MTH_MISC_AMT_816; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_816 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_816 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_817
		{
			get { return _CHQ_REG_MTH_MISC_AMT_817; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_817 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_817 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_818
		{
			get { return _CHQ_REG_MTH_MISC_AMT_818; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_818 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_818 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_91
		{
			get { return _CHQ_REG_MTH_MISC_AMT_91; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_91 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_91 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_92
		{
			get { return _CHQ_REG_MTH_MISC_AMT_92; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_92 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_92 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_93
		{
			get { return _CHQ_REG_MTH_MISC_AMT_93; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_93 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_93 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_94
		{
			get { return _CHQ_REG_MTH_MISC_AMT_94; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_94 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_94 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_95
		{
			get { return _CHQ_REG_MTH_MISC_AMT_95; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_95 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_95 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_96
		{
			get { return _CHQ_REG_MTH_MISC_AMT_96; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_96 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_96 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_97
		{
			get { return _CHQ_REG_MTH_MISC_AMT_97; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_97 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_97 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_98
		{
			get { return _CHQ_REG_MTH_MISC_AMT_98; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_98 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_98 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_99
		{
			get { return _CHQ_REG_MTH_MISC_AMT_99; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_99 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_99 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_910
		{
			get { return _CHQ_REG_MTH_MISC_AMT_910; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_910 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_910 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_911
		{
			get { return _CHQ_REG_MTH_MISC_AMT_911; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_911 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_911 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_912
		{
			get { return _CHQ_REG_MTH_MISC_AMT_912; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_912 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_912 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_913
		{
			get { return _CHQ_REG_MTH_MISC_AMT_913; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_913 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_913 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_914
		{
			get { return _CHQ_REG_MTH_MISC_AMT_914; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_914 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_914 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_915
		{
			get { return _CHQ_REG_MTH_MISC_AMT_915; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_915 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_915 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_916
		{
			get { return _CHQ_REG_MTH_MISC_AMT_916; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_916 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_916 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_917
		{
			get { return _CHQ_REG_MTH_MISC_AMT_917; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_917 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_917 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_918
		{
			get { return _CHQ_REG_MTH_MISC_AMT_918; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_918 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_918 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_101
		{
			get { return _CHQ_REG_MTH_MISC_AMT_101; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_101 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_101 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_102
		{
			get { return _CHQ_REG_MTH_MISC_AMT_102; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_102 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_102 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_103
		{
			get { return _CHQ_REG_MTH_MISC_AMT_103; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_103 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_103 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_104
		{
			get { return _CHQ_REG_MTH_MISC_AMT_104; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_104 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_104 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_105
		{
			get { return _CHQ_REG_MTH_MISC_AMT_105; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_105 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_105 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_106
		{
			get { return _CHQ_REG_MTH_MISC_AMT_106; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_106 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_106 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_107
		{
			get { return _CHQ_REG_MTH_MISC_AMT_107; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_107 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_107 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_108
		{
			get { return _CHQ_REG_MTH_MISC_AMT_108; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_108 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_108 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_109
		{
			get { return _CHQ_REG_MTH_MISC_AMT_109; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_109 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_109 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_1010
		{
			get { return _CHQ_REG_MTH_MISC_AMT_1010; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_1010 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_1010 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_1011
		{
			get { return _CHQ_REG_MTH_MISC_AMT_1011; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_1011 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_1011 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_1012
		{
			get { return _CHQ_REG_MTH_MISC_AMT_1012; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_1012 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_1012 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_1013
		{
			get { return _CHQ_REG_MTH_MISC_AMT_1013; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_1013 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_1013 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_1014
		{
			get { return _CHQ_REG_MTH_MISC_AMT_1014; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_1014 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_1014 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_1015
		{
			get { return _CHQ_REG_MTH_MISC_AMT_1015; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_1015 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_1015 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_1016
		{
			get { return _CHQ_REG_MTH_MISC_AMT_1016; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_1016 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_1016 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_1017
		{
			get { return _CHQ_REG_MTH_MISC_AMT_1017; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_1017 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_1017 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_MISC_AMT_1018
		{
			get { return _CHQ_REG_MTH_MISC_AMT_1018; }
			set
			{
				if (_CHQ_REG_MTH_MISC_AMT_1018 != value)
				{
					_CHQ_REG_MTH_MISC_AMT_1018 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_EXP_AMT1
		{
			get { return _CHQ_REG_MTH_EXP_AMT1; }
			set
			{
				if (_CHQ_REG_MTH_EXP_AMT1 != value)
				{
					_CHQ_REG_MTH_EXP_AMT1 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_EXP_AMT2
		{
			get { return _CHQ_REG_MTH_EXP_AMT2; }
			set
			{
				if (_CHQ_REG_MTH_EXP_AMT2 != value)
				{
					_CHQ_REG_MTH_EXP_AMT2 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_EXP_AMT3
		{
			get { return _CHQ_REG_MTH_EXP_AMT3; }
			set
			{
				if (_CHQ_REG_MTH_EXP_AMT3 != value)
				{
					_CHQ_REG_MTH_EXP_AMT3 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_EXP_AMT4
		{
			get { return _CHQ_REG_MTH_EXP_AMT4; }
			set
			{
				if (_CHQ_REG_MTH_EXP_AMT4 != value)
				{
					_CHQ_REG_MTH_EXP_AMT4 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_EXP_AMT5
		{
			get { return _CHQ_REG_MTH_EXP_AMT5; }
			set
			{
				if (_CHQ_REG_MTH_EXP_AMT5 != value)
				{
					_CHQ_REG_MTH_EXP_AMT5 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_EXP_AMT6
		{
			get { return _CHQ_REG_MTH_EXP_AMT6; }
			set
			{
				if (_CHQ_REG_MTH_EXP_AMT6 != value)
				{
					_CHQ_REG_MTH_EXP_AMT6 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_EXP_AMT7
		{
			get { return _CHQ_REG_MTH_EXP_AMT7; }
			set
			{
				if (_CHQ_REG_MTH_EXP_AMT7 != value)
				{
					_CHQ_REG_MTH_EXP_AMT7 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_EXP_AMT8
		{
			get { return _CHQ_REG_MTH_EXP_AMT8; }
			set
			{
				if (_CHQ_REG_MTH_EXP_AMT8 != value)
				{
					_CHQ_REG_MTH_EXP_AMT8 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_EXP_AMT9
		{
			get { return _CHQ_REG_MTH_EXP_AMT9; }
			set
			{
				if (_CHQ_REG_MTH_EXP_AMT9 != value)
				{
					_CHQ_REG_MTH_EXP_AMT9 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_EXP_AMT10
		{
			get { return _CHQ_REG_MTH_EXP_AMT10; }
			set
			{
				if (_CHQ_REG_MTH_EXP_AMT10 != value)
				{
					_CHQ_REG_MTH_EXP_AMT10 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_EXP_AMT11
		{
			get { return _CHQ_REG_MTH_EXP_AMT11; }
			set
			{
				if (_CHQ_REG_MTH_EXP_AMT11 != value)
				{
					_CHQ_REG_MTH_EXP_AMT11 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_EXP_AMT12
		{
			get { return _CHQ_REG_MTH_EXP_AMT12; }
			set
			{
				if (_CHQ_REG_MTH_EXP_AMT12 != value)
				{
					_CHQ_REG_MTH_EXP_AMT12 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_EXP_AMT13
		{
			get { return _CHQ_REG_MTH_EXP_AMT13; }
			set
			{
				if (_CHQ_REG_MTH_EXP_AMT13 != value)
				{
					_CHQ_REG_MTH_EXP_AMT13 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_EXP_AMT14
		{
			get { return _CHQ_REG_MTH_EXP_AMT14; }
			set
			{
				if (_CHQ_REG_MTH_EXP_AMT14 != value)
				{
					_CHQ_REG_MTH_EXP_AMT14 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_EXP_AMT15
		{
			get { return _CHQ_REG_MTH_EXP_AMT15; }
			set
			{
				if (_CHQ_REG_MTH_EXP_AMT15 != value)
				{
					_CHQ_REG_MTH_EXP_AMT15 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_EXP_AMT16
		{
			get { return _CHQ_REG_MTH_EXP_AMT16; }
			set
			{
				if (_CHQ_REG_MTH_EXP_AMT16 != value)
				{
					_CHQ_REG_MTH_EXP_AMT16 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_EXP_AMT17
		{
			get { return _CHQ_REG_MTH_EXP_AMT17; }
			set
			{
				if (_CHQ_REG_MTH_EXP_AMT17 != value)
				{
					_CHQ_REG_MTH_EXP_AMT17 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_EXP_AMT18
		{
			get { return _CHQ_REG_MTH_EXP_AMT18; }
			set
			{
				if (_CHQ_REG_MTH_EXP_AMT18 != value)
				{
					_CHQ_REG_MTH_EXP_AMT18 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_COMP_ANN_EXP_THIS_PAY1
		{
			get { return _CHQ_REG_COMP_ANN_EXP_THIS_PAY1; }
			set
			{
				if (_CHQ_REG_COMP_ANN_EXP_THIS_PAY1 != value)
				{
					_CHQ_REG_COMP_ANN_EXP_THIS_PAY1 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_COMP_ANN_EXP_THIS_PAY2
		{
			get { return _CHQ_REG_COMP_ANN_EXP_THIS_PAY2; }
			set
			{
				if (_CHQ_REG_COMP_ANN_EXP_THIS_PAY2 != value)
				{
					_CHQ_REG_COMP_ANN_EXP_THIS_PAY2 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_COMP_ANN_EXP_THIS_PAY3
		{
			get { return _CHQ_REG_COMP_ANN_EXP_THIS_PAY3; }
			set
			{
				if (_CHQ_REG_COMP_ANN_EXP_THIS_PAY3 != value)
				{
					_CHQ_REG_COMP_ANN_EXP_THIS_PAY3 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_COMP_ANN_EXP_THIS_PAY4
		{
			get { return _CHQ_REG_COMP_ANN_EXP_THIS_PAY4; }
			set
			{
				if (_CHQ_REG_COMP_ANN_EXP_THIS_PAY4 != value)
				{
					_CHQ_REG_COMP_ANN_EXP_THIS_PAY4 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_COMP_ANN_EXP_THIS_PAY5
		{
			get { return _CHQ_REG_COMP_ANN_EXP_THIS_PAY5; }
			set
			{
				if (_CHQ_REG_COMP_ANN_EXP_THIS_PAY5 != value)
				{
					_CHQ_REG_COMP_ANN_EXP_THIS_PAY5 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_COMP_ANN_EXP_THIS_PAY6
		{
			get { return _CHQ_REG_COMP_ANN_EXP_THIS_PAY6; }
			set
			{
				if (_CHQ_REG_COMP_ANN_EXP_THIS_PAY6 != value)
				{
					_CHQ_REG_COMP_ANN_EXP_THIS_PAY6 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_COMP_ANN_EXP_THIS_PAY7
		{
			get { return _CHQ_REG_COMP_ANN_EXP_THIS_PAY7; }
			set
			{
				if (_CHQ_REG_COMP_ANN_EXP_THIS_PAY7 != value)
				{
					_CHQ_REG_COMP_ANN_EXP_THIS_PAY7 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_COMP_ANN_EXP_THIS_PAY8
		{
			get { return _CHQ_REG_COMP_ANN_EXP_THIS_PAY8; }
			set
			{
				if (_CHQ_REG_COMP_ANN_EXP_THIS_PAY8 != value)
				{
					_CHQ_REG_COMP_ANN_EXP_THIS_PAY8 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_COMP_ANN_EXP_THIS_PAY9
		{
			get { return _CHQ_REG_COMP_ANN_EXP_THIS_PAY9; }
			set
			{
				if (_CHQ_REG_COMP_ANN_EXP_THIS_PAY9 != value)
				{
					_CHQ_REG_COMP_ANN_EXP_THIS_PAY9 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_COMP_ANN_EXP_THIS_PAY10
		{
			get { return _CHQ_REG_COMP_ANN_EXP_THIS_PAY10; }
			set
			{
				if (_CHQ_REG_COMP_ANN_EXP_THIS_PAY10 != value)
				{
					_CHQ_REG_COMP_ANN_EXP_THIS_PAY10 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_COMP_ANN_EXP_THIS_PAY11
		{
			get { return _CHQ_REG_COMP_ANN_EXP_THIS_PAY11; }
			set
			{
				if (_CHQ_REG_COMP_ANN_EXP_THIS_PAY11 != value)
				{
					_CHQ_REG_COMP_ANN_EXP_THIS_PAY11 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_COMP_ANN_EXP_THIS_PAY12
		{
			get { return _CHQ_REG_COMP_ANN_EXP_THIS_PAY12; }
			set
			{
				if (_CHQ_REG_COMP_ANN_EXP_THIS_PAY12 != value)
				{
					_CHQ_REG_COMP_ANN_EXP_THIS_PAY12 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_COMP_ANN_EXP_THIS_PAY13
		{
			get { return _CHQ_REG_COMP_ANN_EXP_THIS_PAY13; }
			set
			{
				if (_CHQ_REG_COMP_ANN_EXP_THIS_PAY13 != value)
				{
					_CHQ_REG_COMP_ANN_EXP_THIS_PAY13 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_COMP_ANN_EXP_THIS_PAY14
		{
			get { return _CHQ_REG_COMP_ANN_EXP_THIS_PAY14; }
			set
			{
				if (_CHQ_REG_COMP_ANN_EXP_THIS_PAY14 != value)
				{
					_CHQ_REG_COMP_ANN_EXP_THIS_PAY14 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_COMP_ANN_EXP_THIS_PAY15
		{
			get { return _CHQ_REG_COMP_ANN_EXP_THIS_PAY15; }
			set
			{
				if (_CHQ_REG_COMP_ANN_EXP_THIS_PAY15 != value)
				{
					_CHQ_REG_COMP_ANN_EXP_THIS_PAY15 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_COMP_ANN_EXP_THIS_PAY16
		{
			get { return _CHQ_REG_COMP_ANN_EXP_THIS_PAY16; }
			set
			{
				if (_CHQ_REG_COMP_ANN_EXP_THIS_PAY16 != value)
				{
					_CHQ_REG_COMP_ANN_EXP_THIS_PAY16 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_COMP_ANN_EXP_THIS_PAY17
		{
			get { return _CHQ_REG_COMP_ANN_EXP_THIS_PAY17; }
			set
			{
				if (_CHQ_REG_COMP_ANN_EXP_THIS_PAY17 != value)
				{
					_CHQ_REG_COMP_ANN_EXP_THIS_PAY17 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_COMP_ANN_EXP_THIS_PAY18
		{
			get { return _CHQ_REG_COMP_ANN_EXP_THIS_PAY18; }
			set
			{
				if (_CHQ_REG_COMP_ANN_EXP_THIS_PAY18 != value)
				{
					_CHQ_REG_COMP_ANN_EXP_THIS_PAY18 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_CEIL_AMT1
		{
			get { return _CHQ_REG_MTH_CEIL_AMT1; }
			set
			{
				if (_CHQ_REG_MTH_CEIL_AMT1 != value)
				{
					_CHQ_REG_MTH_CEIL_AMT1 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_CEIL_AMT2
		{
			get { return _CHQ_REG_MTH_CEIL_AMT2; }
			set
			{
				if (_CHQ_REG_MTH_CEIL_AMT2 != value)
				{
					_CHQ_REG_MTH_CEIL_AMT2 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_CEIL_AMT3
		{
			get { return _CHQ_REG_MTH_CEIL_AMT3; }
			set
			{
				if (_CHQ_REG_MTH_CEIL_AMT3 != value)
				{
					_CHQ_REG_MTH_CEIL_AMT3 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_CEIL_AMT4
		{
			get { return _CHQ_REG_MTH_CEIL_AMT4; }
			set
			{
				if (_CHQ_REG_MTH_CEIL_AMT4 != value)
				{
					_CHQ_REG_MTH_CEIL_AMT4 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_CEIL_AMT5
		{
			get { return _CHQ_REG_MTH_CEIL_AMT5; }
			set
			{
				if (_CHQ_REG_MTH_CEIL_AMT5 != value)
				{
					_CHQ_REG_MTH_CEIL_AMT5 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_CEIL_AMT6
		{
			get { return _CHQ_REG_MTH_CEIL_AMT6; }
			set
			{
				if (_CHQ_REG_MTH_CEIL_AMT6 != value)
				{
					_CHQ_REG_MTH_CEIL_AMT6 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_CEIL_AMT7
		{
			get { return _CHQ_REG_MTH_CEIL_AMT7; }
			set
			{
				if (_CHQ_REG_MTH_CEIL_AMT7 != value)
				{
					_CHQ_REG_MTH_CEIL_AMT7 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_CEIL_AMT8
		{
			get { return _CHQ_REG_MTH_CEIL_AMT8; }
			set
			{
				if (_CHQ_REG_MTH_CEIL_AMT8 != value)
				{
					_CHQ_REG_MTH_CEIL_AMT8 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_CEIL_AMT9
		{
			get { return _CHQ_REG_MTH_CEIL_AMT9; }
			set
			{
				if (_CHQ_REG_MTH_CEIL_AMT9 != value)
				{
					_CHQ_REG_MTH_CEIL_AMT9 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_CEIL_AMT10
		{
			get { return _CHQ_REG_MTH_CEIL_AMT10; }
			set
			{
				if (_CHQ_REG_MTH_CEIL_AMT10 != value)
				{
					_CHQ_REG_MTH_CEIL_AMT10 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_CEIL_AMT11
		{
			get { return _CHQ_REG_MTH_CEIL_AMT11; }
			set
			{
				if (_CHQ_REG_MTH_CEIL_AMT11 != value)
				{
					_CHQ_REG_MTH_CEIL_AMT11 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_CEIL_AMT12
		{
			get { return _CHQ_REG_MTH_CEIL_AMT12; }
			set
			{
				if (_CHQ_REG_MTH_CEIL_AMT12 != value)
				{
					_CHQ_REG_MTH_CEIL_AMT12 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_CEIL_AMT13
		{
			get { return _CHQ_REG_MTH_CEIL_AMT13; }
			set
			{
				if (_CHQ_REG_MTH_CEIL_AMT13 != value)
				{
					_CHQ_REG_MTH_CEIL_AMT13 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_CEIL_AMT14
		{
			get { return _CHQ_REG_MTH_CEIL_AMT14; }
			set
			{
				if (_CHQ_REG_MTH_CEIL_AMT14 != value)
				{
					_CHQ_REG_MTH_CEIL_AMT14 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_CEIL_AMT15
		{
			get { return _CHQ_REG_MTH_CEIL_AMT15; }
			set
			{
				if (_CHQ_REG_MTH_CEIL_AMT15 != value)
				{
					_CHQ_REG_MTH_CEIL_AMT15 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_CEIL_AMT16
		{
			get { return _CHQ_REG_MTH_CEIL_AMT16; }
			set
			{
				if (_CHQ_REG_MTH_CEIL_AMT16 != value)
				{
					_CHQ_REG_MTH_CEIL_AMT16 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_CEIL_AMT17
		{
			get { return _CHQ_REG_MTH_CEIL_AMT17; }
			set
			{
				if (_CHQ_REG_MTH_CEIL_AMT17 != value)
				{
					_CHQ_REG_MTH_CEIL_AMT17 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MTH_CEIL_AMT18
		{
			get { return _CHQ_REG_MTH_CEIL_AMT18; }
			set
			{
				if (_CHQ_REG_MTH_CEIL_AMT18 != value)
				{
					_CHQ_REG_MTH_CEIL_AMT18 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_COMP_ANN_CEIL_THIS_PAY1
		{
			get { return _CHQ_REG_COMP_ANN_CEIL_THIS_PAY1; }
			set
			{
				if (_CHQ_REG_COMP_ANN_CEIL_THIS_PAY1 != value)
				{
					_CHQ_REG_COMP_ANN_CEIL_THIS_PAY1 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_COMP_ANN_CEIL_THIS_PAY2
		{
			get { return _CHQ_REG_COMP_ANN_CEIL_THIS_PAY2; }
			set
			{
				if (_CHQ_REG_COMP_ANN_CEIL_THIS_PAY2 != value)
				{
					_CHQ_REG_COMP_ANN_CEIL_THIS_PAY2 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_COMP_ANN_CEIL_THIS_PAY3
		{
			get { return _CHQ_REG_COMP_ANN_CEIL_THIS_PAY3; }
			set
			{
				if (_CHQ_REG_COMP_ANN_CEIL_THIS_PAY3 != value)
				{
					_CHQ_REG_COMP_ANN_CEIL_THIS_PAY3 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_COMP_ANN_CEIL_THIS_PAY4
		{
			get { return _CHQ_REG_COMP_ANN_CEIL_THIS_PAY4; }
			set
			{
				if (_CHQ_REG_COMP_ANN_CEIL_THIS_PAY4 != value)
				{
					_CHQ_REG_COMP_ANN_CEIL_THIS_PAY4 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_COMP_ANN_CEIL_THIS_PAY5
		{
			get { return _CHQ_REG_COMP_ANN_CEIL_THIS_PAY5; }
			set
			{
				if (_CHQ_REG_COMP_ANN_CEIL_THIS_PAY5 != value)
				{
					_CHQ_REG_COMP_ANN_CEIL_THIS_PAY5 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_COMP_ANN_CEIL_THIS_PAY6
		{
			get { return _CHQ_REG_COMP_ANN_CEIL_THIS_PAY6; }
			set
			{
				if (_CHQ_REG_COMP_ANN_CEIL_THIS_PAY6 != value)
				{
					_CHQ_REG_COMP_ANN_CEIL_THIS_PAY6 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_COMP_ANN_CEIL_THIS_PAY7
		{
			get { return _CHQ_REG_COMP_ANN_CEIL_THIS_PAY7; }
			set
			{
				if (_CHQ_REG_COMP_ANN_CEIL_THIS_PAY7 != value)
				{
					_CHQ_REG_COMP_ANN_CEIL_THIS_PAY7 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_COMP_ANN_CEIL_THIS_PAY8
		{
			get { return _CHQ_REG_COMP_ANN_CEIL_THIS_PAY8; }
			set
			{
				if (_CHQ_REG_COMP_ANN_CEIL_THIS_PAY8 != value)
				{
					_CHQ_REG_COMP_ANN_CEIL_THIS_PAY8 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_COMP_ANN_CEIL_THIS_PAY9
		{
			get { return _CHQ_REG_COMP_ANN_CEIL_THIS_PAY9; }
			set
			{
				if (_CHQ_REG_COMP_ANN_CEIL_THIS_PAY9 != value)
				{
					_CHQ_REG_COMP_ANN_CEIL_THIS_PAY9 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_COMP_ANN_CEIL_THIS_PAY10
		{
			get { return _CHQ_REG_COMP_ANN_CEIL_THIS_PAY10; }
			set
			{
				if (_CHQ_REG_COMP_ANN_CEIL_THIS_PAY10 != value)
				{
					_CHQ_REG_COMP_ANN_CEIL_THIS_PAY10 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_COMP_ANN_CEIL_THIS_PAY11
		{
			get { return _CHQ_REG_COMP_ANN_CEIL_THIS_PAY11; }
			set
			{
				if (_CHQ_REG_COMP_ANN_CEIL_THIS_PAY11 != value)
				{
					_CHQ_REG_COMP_ANN_CEIL_THIS_PAY11 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_COMP_ANN_CEIL_THIS_PAY12
		{
			get { return _CHQ_REG_COMP_ANN_CEIL_THIS_PAY12; }
			set
			{
				if (_CHQ_REG_COMP_ANN_CEIL_THIS_PAY12 != value)
				{
					_CHQ_REG_COMP_ANN_CEIL_THIS_PAY12 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_COMP_ANN_CEIL_THIS_PAY13
		{
			get { return _CHQ_REG_COMP_ANN_CEIL_THIS_PAY13; }
			set
			{
				if (_CHQ_REG_COMP_ANN_CEIL_THIS_PAY13 != value)
				{
					_CHQ_REG_COMP_ANN_CEIL_THIS_PAY13 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_COMP_ANN_CEIL_THIS_PAY14
		{
			get { return _CHQ_REG_COMP_ANN_CEIL_THIS_PAY14; }
			set
			{
				if (_CHQ_REG_COMP_ANN_CEIL_THIS_PAY14 != value)
				{
					_CHQ_REG_COMP_ANN_CEIL_THIS_PAY14 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_COMP_ANN_CEIL_THIS_PAY15
		{
			get { return _CHQ_REG_COMP_ANN_CEIL_THIS_PAY15; }
			set
			{
				if (_CHQ_REG_COMP_ANN_CEIL_THIS_PAY15 != value)
				{
					_CHQ_REG_COMP_ANN_CEIL_THIS_PAY15 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_COMP_ANN_CEIL_THIS_PAY16
		{
			get { return _CHQ_REG_COMP_ANN_CEIL_THIS_PAY16; }
			set
			{
				if (_CHQ_REG_COMP_ANN_CEIL_THIS_PAY16 != value)
				{
					_CHQ_REG_COMP_ANN_CEIL_THIS_PAY16 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_COMP_ANN_CEIL_THIS_PAY17
		{
			get { return _CHQ_REG_COMP_ANN_CEIL_THIS_PAY17; }
			set
			{
				if (_CHQ_REG_COMP_ANN_CEIL_THIS_PAY17 != value)
				{
					_CHQ_REG_COMP_ANN_CEIL_THIS_PAY17 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_COMP_ANN_CEIL_THIS_PAY18
		{
			get { return _CHQ_REG_COMP_ANN_CEIL_THIS_PAY18; }
			set
			{
				if (_CHQ_REG_COMP_ANN_CEIL_THIS_PAY18 != value)
				{
					_CHQ_REG_COMP_ANN_CEIL_THIS_PAY18 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_EARNINGS_THIS_MTH1
		{
			get { return _CHQ_REG_EARNINGS_THIS_MTH1; }
			set
			{
				if (_CHQ_REG_EARNINGS_THIS_MTH1 != value)
				{
					_CHQ_REG_EARNINGS_THIS_MTH1 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_EARNINGS_THIS_MTH2
		{
			get { return _CHQ_REG_EARNINGS_THIS_MTH2; }
			set
			{
				if (_CHQ_REG_EARNINGS_THIS_MTH2 != value)
				{
					_CHQ_REG_EARNINGS_THIS_MTH2 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_EARNINGS_THIS_MTH3
		{
			get { return _CHQ_REG_EARNINGS_THIS_MTH3; }
			set
			{
				if (_CHQ_REG_EARNINGS_THIS_MTH3 != value)
				{
					_CHQ_REG_EARNINGS_THIS_MTH3 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_EARNINGS_THIS_MTH4
		{
			get { return _CHQ_REG_EARNINGS_THIS_MTH4; }
			set
			{
				if (_CHQ_REG_EARNINGS_THIS_MTH4 != value)
				{
					_CHQ_REG_EARNINGS_THIS_MTH4 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_EARNINGS_THIS_MTH5
		{
			get { return _CHQ_REG_EARNINGS_THIS_MTH5; }
			set
			{
				if (_CHQ_REG_EARNINGS_THIS_MTH5 != value)
				{
					_CHQ_REG_EARNINGS_THIS_MTH5 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_EARNINGS_THIS_MTH6
		{
			get { return _CHQ_REG_EARNINGS_THIS_MTH6; }
			set
			{
				if (_CHQ_REG_EARNINGS_THIS_MTH6 != value)
				{
					_CHQ_REG_EARNINGS_THIS_MTH6 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_EARNINGS_THIS_MTH7
		{
			get { return _CHQ_REG_EARNINGS_THIS_MTH7; }
			set
			{
				if (_CHQ_REG_EARNINGS_THIS_MTH7 != value)
				{
					_CHQ_REG_EARNINGS_THIS_MTH7 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_EARNINGS_THIS_MTH8
		{
			get { return _CHQ_REG_EARNINGS_THIS_MTH8; }
			set
			{
				if (_CHQ_REG_EARNINGS_THIS_MTH8 != value)
				{
					_CHQ_REG_EARNINGS_THIS_MTH8 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_EARNINGS_THIS_MTH9
		{
			get { return _CHQ_REG_EARNINGS_THIS_MTH9; }
			set
			{
				if (_CHQ_REG_EARNINGS_THIS_MTH9 != value)
				{
					_CHQ_REG_EARNINGS_THIS_MTH9 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_EARNINGS_THIS_MTH10
		{
			get { return _CHQ_REG_EARNINGS_THIS_MTH10; }
			set
			{
				if (_CHQ_REG_EARNINGS_THIS_MTH10 != value)
				{
					_CHQ_REG_EARNINGS_THIS_MTH10 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_EARNINGS_THIS_MTH11
		{
			get { return _CHQ_REG_EARNINGS_THIS_MTH11; }
			set
			{
				if (_CHQ_REG_EARNINGS_THIS_MTH11 != value)
				{
					_CHQ_REG_EARNINGS_THIS_MTH11 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_EARNINGS_THIS_MTH12
		{
			get { return _CHQ_REG_EARNINGS_THIS_MTH12; }
			set
			{
				if (_CHQ_REG_EARNINGS_THIS_MTH12 != value)
				{
					_CHQ_REG_EARNINGS_THIS_MTH12 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_EARNINGS_THIS_MTH13
		{
			get { return _CHQ_REG_EARNINGS_THIS_MTH13; }
			set
			{
				if (_CHQ_REG_EARNINGS_THIS_MTH13 != value)
				{
					_CHQ_REG_EARNINGS_THIS_MTH13 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_EARNINGS_THIS_MTH14
		{
			get { return _CHQ_REG_EARNINGS_THIS_MTH14; }
			set
			{
				if (_CHQ_REG_EARNINGS_THIS_MTH14 != value)
				{
					_CHQ_REG_EARNINGS_THIS_MTH14 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_EARNINGS_THIS_MTH15
		{
			get { return _CHQ_REG_EARNINGS_THIS_MTH15; }
			set
			{
				if (_CHQ_REG_EARNINGS_THIS_MTH15 != value)
				{
					_CHQ_REG_EARNINGS_THIS_MTH15 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_EARNINGS_THIS_MTH16
		{
			get { return _CHQ_REG_EARNINGS_THIS_MTH16; }
			set
			{
				if (_CHQ_REG_EARNINGS_THIS_MTH16 != value)
				{
					_CHQ_REG_EARNINGS_THIS_MTH16 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_EARNINGS_THIS_MTH17
		{
			get { return _CHQ_REG_EARNINGS_THIS_MTH17; }
			set
			{
				if (_CHQ_REG_EARNINGS_THIS_MTH17 != value)
				{
					_CHQ_REG_EARNINGS_THIS_MTH17 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_EARNINGS_THIS_MTH18
		{
			get { return _CHQ_REG_EARNINGS_THIS_MTH18; }
			set
			{
				if (_CHQ_REG_EARNINGS_THIS_MTH18 != value)
				{
					_CHQ_REG_EARNINGS_THIS_MTH18 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_REGULAR_PAY_THIS_MTH1
		{
			get { return _CHQ_REG_REGULAR_PAY_THIS_MTH1; }
			set
			{
				if (_CHQ_REG_REGULAR_PAY_THIS_MTH1 != value)
				{
					_CHQ_REG_REGULAR_PAY_THIS_MTH1 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_REGULAR_PAY_THIS_MTH2
		{
			get { return _CHQ_REG_REGULAR_PAY_THIS_MTH2; }
			set
			{
				if (_CHQ_REG_REGULAR_PAY_THIS_MTH2 != value)
				{
					_CHQ_REG_REGULAR_PAY_THIS_MTH2 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_REGULAR_PAY_THIS_MTH3
		{
			get { return _CHQ_REG_REGULAR_PAY_THIS_MTH3; }
			set
			{
				if (_CHQ_REG_REGULAR_PAY_THIS_MTH3 != value)
				{
					_CHQ_REG_REGULAR_PAY_THIS_MTH3 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_REGULAR_PAY_THIS_MTH4
		{
			get { return _CHQ_REG_REGULAR_PAY_THIS_MTH4; }
			set
			{
				if (_CHQ_REG_REGULAR_PAY_THIS_MTH4 != value)
				{
					_CHQ_REG_REGULAR_PAY_THIS_MTH4 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_REGULAR_PAY_THIS_MTH5
		{
			get { return _CHQ_REG_REGULAR_PAY_THIS_MTH5; }
			set
			{
				if (_CHQ_REG_REGULAR_PAY_THIS_MTH5 != value)
				{
					_CHQ_REG_REGULAR_PAY_THIS_MTH5 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_REGULAR_PAY_THIS_MTH6
		{
			get { return _CHQ_REG_REGULAR_PAY_THIS_MTH6; }
			set
			{
				if (_CHQ_REG_REGULAR_PAY_THIS_MTH6 != value)
				{
					_CHQ_REG_REGULAR_PAY_THIS_MTH6 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_REGULAR_PAY_THIS_MTH7
		{
			get { return _CHQ_REG_REGULAR_PAY_THIS_MTH7; }
			set
			{
				if (_CHQ_REG_REGULAR_PAY_THIS_MTH7 != value)
				{
					_CHQ_REG_REGULAR_PAY_THIS_MTH7 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_REGULAR_PAY_THIS_MTH8
		{
			get { return _CHQ_REG_REGULAR_PAY_THIS_MTH8; }
			set
			{
				if (_CHQ_REG_REGULAR_PAY_THIS_MTH8 != value)
				{
					_CHQ_REG_REGULAR_PAY_THIS_MTH8 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_REGULAR_PAY_THIS_MTH9
		{
			get { return _CHQ_REG_REGULAR_PAY_THIS_MTH9; }
			set
			{
				if (_CHQ_REG_REGULAR_PAY_THIS_MTH9 != value)
				{
					_CHQ_REG_REGULAR_PAY_THIS_MTH9 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_REGULAR_PAY_THIS_MTH10
		{
			get { return _CHQ_REG_REGULAR_PAY_THIS_MTH10; }
			set
			{
				if (_CHQ_REG_REGULAR_PAY_THIS_MTH10 != value)
				{
					_CHQ_REG_REGULAR_PAY_THIS_MTH10 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_REGULAR_PAY_THIS_MTH11
		{
			get { return _CHQ_REG_REGULAR_PAY_THIS_MTH11; }
			set
			{
				if (_CHQ_REG_REGULAR_PAY_THIS_MTH11 != value)
				{
					_CHQ_REG_REGULAR_PAY_THIS_MTH11 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_REGULAR_PAY_THIS_MTH12
		{
			get { return _CHQ_REG_REGULAR_PAY_THIS_MTH12; }
			set
			{
				if (_CHQ_REG_REGULAR_PAY_THIS_MTH12 != value)
				{
					_CHQ_REG_REGULAR_PAY_THIS_MTH12 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_REGULAR_PAY_THIS_MTH13
		{
			get { return _CHQ_REG_REGULAR_PAY_THIS_MTH13; }
			set
			{
				if (_CHQ_REG_REGULAR_PAY_THIS_MTH13 != value)
				{
					_CHQ_REG_REGULAR_PAY_THIS_MTH13 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_REGULAR_PAY_THIS_MTH14
		{
			get { return _CHQ_REG_REGULAR_PAY_THIS_MTH14; }
			set
			{
				if (_CHQ_REG_REGULAR_PAY_THIS_MTH14 != value)
				{
					_CHQ_REG_REGULAR_PAY_THIS_MTH14 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_REGULAR_PAY_THIS_MTH15
		{
			get { return _CHQ_REG_REGULAR_PAY_THIS_MTH15; }
			set
			{
				if (_CHQ_REG_REGULAR_PAY_THIS_MTH15 != value)
				{
					_CHQ_REG_REGULAR_PAY_THIS_MTH15 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_REGULAR_PAY_THIS_MTH16
		{
			get { return _CHQ_REG_REGULAR_PAY_THIS_MTH16; }
			set
			{
				if (_CHQ_REG_REGULAR_PAY_THIS_MTH16 != value)
				{
					_CHQ_REG_REGULAR_PAY_THIS_MTH16 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_REGULAR_PAY_THIS_MTH17
		{
			get { return _CHQ_REG_REGULAR_PAY_THIS_MTH17; }
			set
			{
				if (_CHQ_REG_REGULAR_PAY_THIS_MTH17 != value)
				{
					_CHQ_REG_REGULAR_PAY_THIS_MTH17 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_REGULAR_PAY_THIS_MTH18
		{
			get { return _CHQ_REG_REGULAR_PAY_THIS_MTH18; }
			set
			{
				if (_CHQ_REG_REGULAR_PAY_THIS_MTH18 != value)
				{
					_CHQ_REG_REGULAR_PAY_THIS_MTH18 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_REGULAR_TAX_THIS_MTH1
		{
			get { return _CHQ_REG_REGULAR_TAX_THIS_MTH1; }
			set
			{
				if (_CHQ_REG_REGULAR_TAX_THIS_MTH1 != value)
				{
					_CHQ_REG_REGULAR_TAX_THIS_MTH1 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_REGULAR_TAX_THIS_MTH2
		{
			get { return _CHQ_REG_REGULAR_TAX_THIS_MTH2; }
			set
			{
				if (_CHQ_REG_REGULAR_TAX_THIS_MTH2 != value)
				{
					_CHQ_REG_REGULAR_TAX_THIS_MTH2 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_REGULAR_TAX_THIS_MTH3
		{
			get { return _CHQ_REG_REGULAR_TAX_THIS_MTH3; }
			set
			{
				if (_CHQ_REG_REGULAR_TAX_THIS_MTH3 != value)
				{
					_CHQ_REG_REGULAR_TAX_THIS_MTH3 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_REGULAR_TAX_THIS_MTH4
		{
			get { return _CHQ_REG_REGULAR_TAX_THIS_MTH4; }
			set
			{
				if (_CHQ_REG_REGULAR_TAX_THIS_MTH4 != value)
				{
					_CHQ_REG_REGULAR_TAX_THIS_MTH4 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_REGULAR_TAX_THIS_MTH5
		{
			get { return _CHQ_REG_REGULAR_TAX_THIS_MTH5; }
			set
			{
				if (_CHQ_REG_REGULAR_TAX_THIS_MTH5 != value)
				{
					_CHQ_REG_REGULAR_TAX_THIS_MTH5 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_REGULAR_TAX_THIS_MTH6
		{
			get { return _CHQ_REG_REGULAR_TAX_THIS_MTH6; }
			set
			{
				if (_CHQ_REG_REGULAR_TAX_THIS_MTH6 != value)
				{
					_CHQ_REG_REGULAR_TAX_THIS_MTH6 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_REGULAR_TAX_THIS_MTH7
		{
			get { return _CHQ_REG_REGULAR_TAX_THIS_MTH7; }
			set
			{
				if (_CHQ_REG_REGULAR_TAX_THIS_MTH7 != value)
				{
					_CHQ_REG_REGULAR_TAX_THIS_MTH7 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_REGULAR_TAX_THIS_MTH8
		{
			get { return _CHQ_REG_REGULAR_TAX_THIS_MTH8; }
			set
			{
				if (_CHQ_REG_REGULAR_TAX_THIS_MTH8 != value)
				{
					_CHQ_REG_REGULAR_TAX_THIS_MTH8 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_REGULAR_TAX_THIS_MTH9
		{
			get { return _CHQ_REG_REGULAR_TAX_THIS_MTH9; }
			set
			{
				if (_CHQ_REG_REGULAR_TAX_THIS_MTH9 != value)
				{
					_CHQ_REG_REGULAR_TAX_THIS_MTH9 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_REGULAR_TAX_THIS_MTH10
		{
			get { return _CHQ_REG_REGULAR_TAX_THIS_MTH10; }
			set
			{
				if (_CHQ_REG_REGULAR_TAX_THIS_MTH10 != value)
				{
					_CHQ_REG_REGULAR_TAX_THIS_MTH10 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_REGULAR_TAX_THIS_MTH11
		{
			get { return _CHQ_REG_REGULAR_TAX_THIS_MTH11; }
			set
			{
				if (_CHQ_REG_REGULAR_TAX_THIS_MTH11 != value)
				{
					_CHQ_REG_REGULAR_TAX_THIS_MTH11 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_REGULAR_TAX_THIS_MTH12
		{
			get { return _CHQ_REG_REGULAR_TAX_THIS_MTH12; }
			set
			{
				if (_CHQ_REG_REGULAR_TAX_THIS_MTH12 != value)
				{
					_CHQ_REG_REGULAR_TAX_THIS_MTH12 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_REGULAR_TAX_THIS_MTH13
		{
			get { return _CHQ_REG_REGULAR_TAX_THIS_MTH13; }
			set
			{
				if (_CHQ_REG_REGULAR_TAX_THIS_MTH13 != value)
				{
					_CHQ_REG_REGULAR_TAX_THIS_MTH13 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_REGULAR_TAX_THIS_MTH14
		{
			get { return _CHQ_REG_REGULAR_TAX_THIS_MTH14; }
			set
			{
				if (_CHQ_REG_REGULAR_TAX_THIS_MTH14 != value)
				{
					_CHQ_REG_REGULAR_TAX_THIS_MTH14 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_REGULAR_TAX_THIS_MTH15
		{
			get { return _CHQ_REG_REGULAR_TAX_THIS_MTH15; }
			set
			{
				if (_CHQ_REG_REGULAR_TAX_THIS_MTH15 != value)
				{
					_CHQ_REG_REGULAR_TAX_THIS_MTH15 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_REGULAR_TAX_THIS_MTH16
		{
			get { return _CHQ_REG_REGULAR_TAX_THIS_MTH16; }
			set
			{
				if (_CHQ_REG_REGULAR_TAX_THIS_MTH16 != value)
				{
					_CHQ_REG_REGULAR_TAX_THIS_MTH16 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_REGULAR_TAX_THIS_MTH17
		{
			get { return _CHQ_REG_REGULAR_TAX_THIS_MTH17; }
			set
			{
				if (_CHQ_REG_REGULAR_TAX_THIS_MTH17 != value)
				{
					_CHQ_REG_REGULAR_TAX_THIS_MTH17 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_REGULAR_TAX_THIS_MTH18
		{
			get { return _CHQ_REG_REGULAR_TAX_THIS_MTH18; }
			set
			{
				if (_CHQ_REG_REGULAR_TAX_THIS_MTH18 != value)
				{
					_CHQ_REG_REGULAR_TAX_THIS_MTH18 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MAN_PAY_THIS_MTH1
		{
			get { return _CHQ_REG_MAN_PAY_THIS_MTH1; }
			set
			{
				if (_CHQ_REG_MAN_PAY_THIS_MTH1 != value)
				{
					_CHQ_REG_MAN_PAY_THIS_MTH1 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MAN_PAY_THIS_MTH2
		{
			get { return _CHQ_REG_MAN_PAY_THIS_MTH2; }
			set
			{
				if (_CHQ_REG_MAN_PAY_THIS_MTH2 != value)
				{
					_CHQ_REG_MAN_PAY_THIS_MTH2 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MAN_PAY_THIS_MTH3
		{
			get { return _CHQ_REG_MAN_PAY_THIS_MTH3; }
			set
			{
				if (_CHQ_REG_MAN_PAY_THIS_MTH3 != value)
				{
					_CHQ_REG_MAN_PAY_THIS_MTH3 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MAN_PAY_THIS_MTH4
		{
			get { return _CHQ_REG_MAN_PAY_THIS_MTH4; }
			set
			{
				if (_CHQ_REG_MAN_PAY_THIS_MTH4 != value)
				{
					_CHQ_REG_MAN_PAY_THIS_MTH4 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MAN_PAY_THIS_MTH5
		{
			get { return _CHQ_REG_MAN_PAY_THIS_MTH5; }
			set
			{
				if (_CHQ_REG_MAN_PAY_THIS_MTH5 != value)
				{
					_CHQ_REG_MAN_PAY_THIS_MTH5 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MAN_PAY_THIS_MTH6
		{
			get { return _CHQ_REG_MAN_PAY_THIS_MTH6; }
			set
			{
				if (_CHQ_REG_MAN_PAY_THIS_MTH6 != value)
				{
					_CHQ_REG_MAN_PAY_THIS_MTH6 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MAN_PAY_THIS_MTH7
		{
			get { return _CHQ_REG_MAN_PAY_THIS_MTH7; }
			set
			{
				if (_CHQ_REG_MAN_PAY_THIS_MTH7 != value)
				{
					_CHQ_REG_MAN_PAY_THIS_MTH7 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MAN_PAY_THIS_MTH8
		{
			get { return _CHQ_REG_MAN_PAY_THIS_MTH8; }
			set
			{
				if (_CHQ_REG_MAN_PAY_THIS_MTH8 != value)
				{
					_CHQ_REG_MAN_PAY_THIS_MTH8 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MAN_PAY_THIS_MTH9
		{
			get { return _CHQ_REG_MAN_PAY_THIS_MTH9; }
			set
			{
				if (_CHQ_REG_MAN_PAY_THIS_MTH9 != value)
				{
					_CHQ_REG_MAN_PAY_THIS_MTH9 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MAN_PAY_THIS_MTH10
		{
			get { return _CHQ_REG_MAN_PAY_THIS_MTH10; }
			set
			{
				if (_CHQ_REG_MAN_PAY_THIS_MTH10 != value)
				{
					_CHQ_REG_MAN_PAY_THIS_MTH10 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MAN_PAY_THIS_MTH11
		{
			get { return _CHQ_REG_MAN_PAY_THIS_MTH11; }
			set
			{
				if (_CHQ_REG_MAN_PAY_THIS_MTH11 != value)
				{
					_CHQ_REG_MAN_PAY_THIS_MTH11 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MAN_PAY_THIS_MTH12
		{
			get { return _CHQ_REG_MAN_PAY_THIS_MTH12; }
			set
			{
				if (_CHQ_REG_MAN_PAY_THIS_MTH12 != value)
				{
					_CHQ_REG_MAN_PAY_THIS_MTH12 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MAN_PAY_THIS_MTH13
		{
			get { return _CHQ_REG_MAN_PAY_THIS_MTH13; }
			set
			{
				if (_CHQ_REG_MAN_PAY_THIS_MTH13 != value)
				{
					_CHQ_REG_MAN_PAY_THIS_MTH13 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MAN_PAY_THIS_MTH14
		{
			get { return _CHQ_REG_MAN_PAY_THIS_MTH14; }
			set
			{
				if (_CHQ_REG_MAN_PAY_THIS_MTH14 != value)
				{
					_CHQ_REG_MAN_PAY_THIS_MTH14 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MAN_PAY_THIS_MTH15
		{
			get { return _CHQ_REG_MAN_PAY_THIS_MTH15; }
			set
			{
				if (_CHQ_REG_MAN_PAY_THIS_MTH15 != value)
				{
					_CHQ_REG_MAN_PAY_THIS_MTH15 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MAN_PAY_THIS_MTH16
		{
			get { return _CHQ_REG_MAN_PAY_THIS_MTH16; }
			set
			{
				if (_CHQ_REG_MAN_PAY_THIS_MTH16 != value)
				{
					_CHQ_REG_MAN_PAY_THIS_MTH16 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MAN_PAY_THIS_MTH17
		{
			get { return _CHQ_REG_MAN_PAY_THIS_MTH17; }
			set
			{
				if (_CHQ_REG_MAN_PAY_THIS_MTH17 != value)
				{
					_CHQ_REG_MAN_PAY_THIS_MTH17 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MAN_PAY_THIS_MTH18
		{
			get { return _CHQ_REG_MAN_PAY_THIS_MTH18; }
			set
			{
				if (_CHQ_REG_MAN_PAY_THIS_MTH18 != value)
				{
					_CHQ_REG_MAN_PAY_THIS_MTH18 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MAN_TAX_THIS_MTH1
		{
			get { return _CHQ_REG_MAN_TAX_THIS_MTH1; }
			set
			{
				if (_CHQ_REG_MAN_TAX_THIS_MTH1 != value)
				{
					_CHQ_REG_MAN_TAX_THIS_MTH1 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MAN_TAX_THIS_MTH2
		{
			get { return _CHQ_REG_MAN_TAX_THIS_MTH2; }
			set
			{
				if (_CHQ_REG_MAN_TAX_THIS_MTH2 != value)
				{
					_CHQ_REG_MAN_TAX_THIS_MTH2 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MAN_TAX_THIS_MTH3
		{
			get { return _CHQ_REG_MAN_TAX_THIS_MTH3; }
			set
			{
				if (_CHQ_REG_MAN_TAX_THIS_MTH3 != value)
				{
					_CHQ_REG_MAN_TAX_THIS_MTH3 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MAN_TAX_THIS_MTH4
		{
			get { return _CHQ_REG_MAN_TAX_THIS_MTH4; }
			set
			{
				if (_CHQ_REG_MAN_TAX_THIS_MTH4 != value)
				{
					_CHQ_REG_MAN_TAX_THIS_MTH4 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MAN_TAX_THIS_MTH5
		{
			get { return _CHQ_REG_MAN_TAX_THIS_MTH5; }
			set
			{
				if (_CHQ_REG_MAN_TAX_THIS_MTH5 != value)
				{
					_CHQ_REG_MAN_TAX_THIS_MTH5 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MAN_TAX_THIS_MTH6
		{
			get { return _CHQ_REG_MAN_TAX_THIS_MTH6; }
			set
			{
				if (_CHQ_REG_MAN_TAX_THIS_MTH6 != value)
				{
					_CHQ_REG_MAN_TAX_THIS_MTH6 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MAN_TAX_THIS_MTH7
		{
			get { return _CHQ_REG_MAN_TAX_THIS_MTH7; }
			set
			{
				if (_CHQ_REG_MAN_TAX_THIS_MTH7 != value)
				{
					_CHQ_REG_MAN_TAX_THIS_MTH7 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MAN_TAX_THIS_MTH8
		{
			get { return _CHQ_REG_MAN_TAX_THIS_MTH8; }
			set
			{
				if (_CHQ_REG_MAN_TAX_THIS_MTH8 != value)
				{
					_CHQ_REG_MAN_TAX_THIS_MTH8 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MAN_TAX_THIS_MTH9
		{
			get { return _CHQ_REG_MAN_TAX_THIS_MTH9; }
			set
			{
				if (_CHQ_REG_MAN_TAX_THIS_MTH9 != value)
				{
					_CHQ_REG_MAN_TAX_THIS_MTH9 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MAN_TAX_THIS_MTH10
		{
			get { return _CHQ_REG_MAN_TAX_THIS_MTH10; }
			set
			{
				if (_CHQ_REG_MAN_TAX_THIS_MTH10 != value)
				{
					_CHQ_REG_MAN_TAX_THIS_MTH10 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MAN_TAX_THIS_MTH11
		{
			get { return _CHQ_REG_MAN_TAX_THIS_MTH11; }
			set
			{
				if (_CHQ_REG_MAN_TAX_THIS_MTH11 != value)
				{
					_CHQ_REG_MAN_TAX_THIS_MTH11 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MAN_TAX_THIS_MTH12
		{
			get { return _CHQ_REG_MAN_TAX_THIS_MTH12; }
			set
			{
				if (_CHQ_REG_MAN_TAX_THIS_MTH12 != value)
				{
					_CHQ_REG_MAN_TAX_THIS_MTH12 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MAN_TAX_THIS_MTH13
		{
			get { return _CHQ_REG_MAN_TAX_THIS_MTH13; }
			set
			{
				if (_CHQ_REG_MAN_TAX_THIS_MTH13 != value)
				{
					_CHQ_REG_MAN_TAX_THIS_MTH13 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MAN_TAX_THIS_MTH14
		{
			get { return _CHQ_REG_MAN_TAX_THIS_MTH14; }
			set
			{
				if (_CHQ_REG_MAN_TAX_THIS_MTH14 != value)
				{
					_CHQ_REG_MAN_TAX_THIS_MTH14 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MAN_TAX_THIS_MTH15
		{
			get { return _CHQ_REG_MAN_TAX_THIS_MTH15; }
			set
			{
				if (_CHQ_REG_MAN_TAX_THIS_MTH15 != value)
				{
					_CHQ_REG_MAN_TAX_THIS_MTH15 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MAN_TAX_THIS_MTH16
		{
			get { return _CHQ_REG_MAN_TAX_THIS_MTH16; }
			set
			{
				if (_CHQ_REG_MAN_TAX_THIS_MTH16 != value)
				{
					_CHQ_REG_MAN_TAX_THIS_MTH16 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MAN_TAX_THIS_MTH17
		{
			get { return _CHQ_REG_MAN_TAX_THIS_MTH17; }
			set
			{
				if (_CHQ_REG_MAN_TAX_THIS_MTH17 != value)
				{
					_CHQ_REG_MAN_TAX_THIS_MTH17 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_MAN_TAX_THIS_MTH18
		{
			get { return _CHQ_REG_MAN_TAX_THIS_MTH18; }
			set
			{
				if (_CHQ_REG_MAN_TAX_THIS_MTH18 != value)
				{
					_CHQ_REG_MAN_TAX_THIS_MTH18 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PAY_DATE1
		{
			get { return _CHQ_REG_PAY_DATE1; }
			set
			{
				if (_CHQ_REG_PAY_DATE1 != value)
				{
					_CHQ_REG_PAY_DATE1 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PAY_DATE2
		{
			get { return _CHQ_REG_PAY_DATE2; }
			set
			{
				if (_CHQ_REG_PAY_DATE2 != value)
				{
					_CHQ_REG_PAY_DATE2 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PAY_DATE3
		{
			get { return _CHQ_REG_PAY_DATE3; }
			set
			{
				if (_CHQ_REG_PAY_DATE3 != value)
				{
					_CHQ_REG_PAY_DATE3 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PAY_DATE4
		{
			get { return _CHQ_REG_PAY_DATE4; }
			set
			{
				if (_CHQ_REG_PAY_DATE4 != value)
				{
					_CHQ_REG_PAY_DATE4 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PAY_DATE5
		{
			get { return _CHQ_REG_PAY_DATE5; }
			set
			{
				if (_CHQ_REG_PAY_DATE5 != value)
				{
					_CHQ_REG_PAY_DATE5 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PAY_DATE6
		{
			get { return _CHQ_REG_PAY_DATE6; }
			set
			{
				if (_CHQ_REG_PAY_DATE6 != value)
				{
					_CHQ_REG_PAY_DATE6 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PAY_DATE7
		{
			get { return _CHQ_REG_PAY_DATE7; }
			set
			{
				if (_CHQ_REG_PAY_DATE7 != value)
				{
					_CHQ_REG_PAY_DATE7 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PAY_DATE8
		{
			get { return _CHQ_REG_PAY_DATE8; }
			set
			{
				if (_CHQ_REG_PAY_DATE8 != value)
				{
					_CHQ_REG_PAY_DATE8 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PAY_DATE9
		{
			get { return _CHQ_REG_PAY_DATE9; }
			set
			{
				if (_CHQ_REG_PAY_DATE9 != value)
				{
					_CHQ_REG_PAY_DATE9 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PAY_DATE10
		{
			get { return _CHQ_REG_PAY_DATE10; }
			set
			{
				if (_CHQ_REG_PAY_DATE10 != value)
				{
					_CHQ_REG_PAY_DATE10 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PAY_DATE11
		{
			get { return _CHQ_REG_PAY_DATE11; }
			set
			{
				if (_CHQ_REG_PAY_DATE11 != value)
				{
					_CHQ_REG_PAY_DATE11 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PAY_DATE12
		{
			get { return _CHQ_REG_PAY_DATE12; }
			set
			{
				if (_CHQ_REG_PAY_DATE12 != value)
				{
					_CHQ_REG_PAY_DATE12 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PAY_DATE13
		{
			get { return _CHQ_REG_PAY_DATE13; }
			set
			{
				if (_CHQ_REG_PAY_DATE13 != value)
				{
					_CHQ_REG_PAY_DATE13 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PAY_DATE14
		{
			get { return _CHQ_REG_PAY_DATE14; }
			set
			{
				if (_CHQ_REG_PAY_DATE14 != value)
				{
					_CHQ_REG_PAY_DATE14 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PAY_DATE15
		{
			get { return _CHQ_REG_PAY_DATE15; }
			set
			{
				if (_CHQ_REG_PAY_DATE15 != value)
				{
					_CHQ_REG_PAY_DATE15 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PAY_DATE16
		{
			get { return _CHQ_REG_PAY_DATE16; }
			set
			{
				if (_CHQ_REG_PAY_DATE16 != value)
				{
					_CHQ_REG_PAY_DATE16 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PAY_DATE17
		{
			get { return _CHQ_REG_PAY_DATE17; }
			set
			{
				if (_CHQ_REG_PAY_DATE17 != value)
				{
					_CHQ_REG_PAY_DATE17 = value;
					ChangeState();
				}
			}
		}
		public decimal? CHQ_REG_PAY_DATE18
		{
			get { return _CHQ_REG_PAY_DATE18; }
			set
			{
				if (_CHQ_REG_PAY_DATE18 != value)
				{
					_CHQ_REG_PAY_DATE18 = value;
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
		public decimal? WhereChq_reg_clinic_nbr_1_2 { get; set; }
		private decimal? _whereChq_reg_clinic_nbr_1_2;
		public decimal? WhereChq_reg_dept { get; set; }
		private decimal? _whereChq_reg_dept;
		public string WhereChq_reg_doc_nbr { get; set; }
		private string _whereChq_reg_doc_nbr;
		public double? WhereChq_reg_perc_bill1 { get; set; }
		private double? _whereChq_reg_perc_bill1;
		public double? WhereChq_reg_perc_bill2 { get; set; }
		private double? _whereChq_reg_perc_bill2;
		public double? WhereChq_reg_perc_bill3 { get; set; }
		private double? _whereChq_reg_perc_bill3;
		public double? WhereChq_reg_perc_bill4 { get; set; }
		private double? _whereChq_reg_perc_bill4;
		public double? WhereChq_reg_perc_bill5 { get; set; }
		private double? _whereChq_reg_perc_bill5;
		public double? WhereChq_reg_perc_bill6 { get; set; }
		private double? _whereChq_reg_perc_bill6;
		public double? WhereChq_reg_perc_bill7 { get; set; }
		private double? _whereChq_reg_perc_bill7;
		public double? WhereChq_reg_perc_bill8 { get; set; }
		private double? _whereChq_reg_perc_bill8;
		public double? WhereChq_reg_perc_bill9 { get; set; }
		private double? _whereChq_reg_perc_bill9;
		public double? WhereChq_reg_perc_bill10 { get; set; }
		private double? _whereChq_reg_perc_bill10;
		public double? WhereChq_reg_perc_bill11 { get; set; }
		private double? _whereChq_reg_perc_bill11;
		public double? WhereChq_reg_perc_bill12 { get; set; }
		private double? _whereChq_reg_perc_bill12;
		public double? WhereChq_reg_perc_bill13 { get; set; }
		private double? _whereChq_reg_perc_bill13;
		public double? WhereChq_reg_perc_bill14 { get; set; }
		private double? _whereChq_reg_perc_bill14;
		public double? WhereChq_reg_perc_bill15 { get; set; }
		private double? _whereChq_reg_perc_bill15;
		public double? WhereChq_reg_perc_bill16 { get; set; }
		private double? _whereChq_reg_perc_bill16;
		public double? WhereChq_reg_perc_bill17 { get; set; }
		private double? _whereChq_reg_perc_bill17;
		public double? WhereChq_reg_perc_bill18 { get; set; }
		private double? _whereChq_reg_perc_bill18;
		public double? WhereChq_reg_perc_misc1 { get; set; }
		private double? _whereChq_reg_perc_misc1;
		public double? WhereChq_reg_perc_misc2 { get; set; }
		private double? _whereChq_reg_perc_misc2;
		public double? WhereChq_reg_perc_misc3 { get; set; }
		private double? _whereChq_reg_perc_misc3;
		public double? WhereChq_reg_perc_misc4 { get; set; }
		private double? _whereChq_reg_perc_misc4;
		public double? WhereChq_reg_perc_misc5 { get; set; }
		private double? _whereChq_reg_perc_misc5;
		public double? WhereChq_reg_perc_misc6 { get; set; }
		private double? _whereChq_reg_perc_misc6;
		public double? WhereChq_reg_perc_misc7 { get; set; }
		private double? _whereChq_reg_perc_misc7;
		public double? WhereChq_reg_perc_misc8 { get; set; }
		private double? _whereChq_reg_perc_misc8;
		public double? WhereChq_reg_perc_misc9 { get; set; }
		private double? _whereChq_reg_perc_misc9;
		public double? WhereChq_reg_perc_misc10 { get; set; }
		private double? _whereChq_reg_perc_misc10;
		public double? WhereChq_reg_perc_misc11 { get; set; }
		private double? _whereChq_reg_perc_misc11;
		public double? WhereChq_reg_perc_misc12 { get; set; }
		private double? _whereChq_reg_perc_misc12;
		public double? WhereChq_reg_perc_misc13 { get; set; }
		private double? _whereChq_reg_perc_misc13;
		public double? WhereChq_reg_perc_misc14 { get; set; }
		private double? _whereChq_reg_perc_misc14;
		public double? WhereChq_reg_perc_misc15 { get; set; }
		private double? _whereChq_reg_perc_misc15;
		public double? WhereChq_reg_perc_misc16 { get; set; }
		private double? _whereChq_reg_perc_misc16;
		public double? WhereChq_reg_perc_misc17 { get; set; }
		private double? _whereChq_reg_perc_misc17;
		public double? WhereChq_reg_perc_misc18 { get; set; }
		private double? _whereChq_reg_perc_misc18;
		public string WhereChq_reg_pay_code1 { get; set; }
		private string _whereChq_reg_pay_code1;
		public string WhereChq_reg_pay_code2 { get; set; }
		private string _whereChq_reg_pay_code2;
		public string WhereChq_reg_pay_code3 { get; set; }
		private string _whereChq_reg_pay_code3;
		public string WhereChq_reg_pay_code4 { get; set; }
		private string _whereChq_reg_pay_code4;
		public string WhereChq_reg_pay_code5 { get; set; }
		private string _whereChq_reg_pay_code5;
		public string WhereChq_reg_pay_code6 { get; set; }
		private string _whereChq_reg_pay_code6;
		public string WhereChq_reg_pay_code7 { get; set; }
		private string _whereChq_reg_pay_code7;
		public string WhereChq_reg_pay_code8 { get; set; }
		private string _whereChq_reg_pay_code8;
		public string WhereChq_reg_pay_code9 { get; set; }
		private string _whereChq_reg_pay_code9;
		public string WhereChq_reg_pay_code10 { get; set; }
		private string _whereChq_reg_pay_code10;
		public string WhereChq_reg_pay_code11 { get; set; }
		private string _whereChq_reg_pay_code11;
		public string WhereChq_reg_pay_code12 { get; set; }
		private string _whereChq_reg_pay_code12;
		public string WhereChq_reg_pay_code13 { get; set; }
		private string _whereChq_reg_pay_code13;
		public string WhereChq_reg_pay_code14 { get; set; }
		private string _whereChq_reg_pay_code14;
		public string WhereChq_reg_pay_code15 { get; set; }
		private string _whereChq_reg_pay_code15;
		public string WhereChq_reg_pay_code16 { get; set; }
		private string _whereChq_reg_pay_code16;
		public string WhereChq_reg_pay_code17 { get; set; }
		private string _whereChq_reg_pay_code17;
		public string WhereChq_reg_pay_code18 { get; set; }
		private string _whereChq_reg_pay_code18;
		public double? WhereChq_reg_perc_tax1 { get; set; }
		private double? _whereChq_reg_perc_tax1;
		public double? WhereChq_reg_perc_tax2 { get; set; }
		private double? _whereChq_reg_perc_tax2;
		public double? WhereChq_reg_perc_tax3 { get; set; }
		private double? _whereChq_reg_perc_tax3;
		public double? WhereChq_reg_perc_tax4 { get; set; }
		private double? _whereChq_reg_perc_tax4;
		public double? WhereChq_reg_perc_tax5 { get; set; }
		private double? _whereChq_reg_perc_tax5;
		public double? WhereChq_reg_perc_tax6 { get; set; }
		private double? _whereChq_reg_perc_tax6;
		public double? WhereChq_reg_perc_tax7 { get; set; }
		private double? _whereChq_reg_perc_tax7;
		public double? WhereChq_reg_perc_tax8 { get; set; }
		private double? _whereChq_reg_perc_tax8;
		public double? WhereChq_reg_perc_tax9 { get; set; }
		private double? _whereChq_reg_perc_tax9;
		public double? WhereChq_reg_perc_tax10 { get; set; }
		private double? _whereChq_reg_perc_tax10;
		public double? WhereChq_reg_perc_tax11 { get; set; }
		private double? _whereChq_reg_perc_tax11;
		public double? WhereChq_reg_perc_tax12 { get; set; }
		private double? _whereChq_reg_perc_tax12;
		public double? WhereChq_reg_perc_tax13 { get; set; }
		private double? _whereChq_reg_perc_tax13;
		public double? WhereChq_reg_perc_tax14 { get; set; }
		private double? _whereChq_reg_perc_tax14;
		public double? WhereChq_reg_perc_tax15 { get; set; }
		private double? _whereChq_reg_perc_tax15;
		public double? WhereChq_reg_perc_tax16 { get; set; }
		private double? _whereChq_reg_perc_tax16;
		public double? WhereChq_reg_perc_tax17 { get; set; }
		private double? _whereChq_reg_perc_tax17;
		public double? WhereChq_reg_perc_tax18 { get; set; }
		private double? _whereChq_reg_perc_tax18;
		public double? WhereChq_reg_mth_bill_amt1 { get; set; }
		private double? _whereChq_reg_mth_bill_amt1;
		public double? WhereChq_reg_mth_bill_amt2 { get; set; }
		private double? _whereChq_reg_mth_bill_amt2;
		public double? WhereChq_reg_mth_bill_amt3 { get; set; }
		private double? _whereChq_reg_mth_bill_amt3;
		public double? WhereChq_reg_mth_bill_amt4 { get; set; }
		private double? _whereChq_reg_mth_bill_amt4;
		public double? WhereChq_reg_mth_bill_amt5 { get; set; }
		private double? _whereChq_reg_mth_bill_amt5;
		public double? WhereChq_reg_mth_bill_amt6 { get; set; }
		private double? _whereChq_reg_mth_bill_amt6;
		public double? WhereChq_reg_mth_bill_amt7 { get; set; }
		private double? _whereChq_reg_mth_bill_amt7;
		public double? WhereChq_reg_mth_bill_amt8 { get; set; }
		private double? _whereChq_reg_mth_bill_amt8;
		public double? WhereChq_reg_mth_bill_amt9 { get; set; }
		private double? _whereChq_reg_mth_bill_amt9;
		public double? WhereChq_reg_mth_bill_amt10 { get; set; }
		private double? _whereChq_reg_mth_bill_amt10;
		public double? WhereChq_reg_mth_bill_amt11 { get; set; }
		private double? _whereChq_reg_mth_bill_amt11;
		public double? WhereChq_reg_mth_bill_amt12 { get; set; }
		private double? _whereChq_reg_mth_bill_amt12;
		public double? WhereChq_reg_mth_bill_amt13 { get; set; }
		private double? _whereChq_reg_mth_bill_amt13;
		public double? WhereChq_reg_mth_bill_amt14 { get; set; }
		private double? _whereChq_reg_mth_bill_amt14;
		public double? WhereChq_reg_mth_bill_amt15 { get; set; }
		private double? _whereChq_reg_mth_bill_amt15;
		public double? WhereChq_reg_mth_bill_amt16 { get; set; }
		private double? _whereChq_reg_mth_bill_amt16;
		public double? WhereChq_reg_mth_bill_amt17 { get; set; }
		private double? _whereChq_reg_mth_bill_amt17;
		public double? WhereChq_reg_mth_bill_amt18 { get; set; }
		private double? _whereChq_reg_mth_bill_amt18;
		public double? WhereChq_reg_mth_misc_amt_11 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_11;
		public double? WhereChq_reg_mth_misc_amt_12 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_12;
		public double? WhereChq_reg_mth_misc_amt_13 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_13;
		public double? WhereChq_reg_mth_misc_amt_14 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_14;
		public double? WhereChq_reg_mth_misc_amt_15 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_15;
		public double? WhereChq_reg_mth_misc_amt_16 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_16;
		public double? WhereChq_reg_mth_misc_amt_17 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_17;
		public double? WhereChq_reg_mth_misc_amt_18 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_18;
		public double? WhereChq_reg_mth_misc_amt_19 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_19;
		public double? WhereChq_reg_mth_misc_amt_110 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_110;
		public double? WhereChq_reg_mth_misc_amt_111 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_111;
		public double? WhereChq_reg_mth_misc_amt_112 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_112;
		public double? WhereChq_reg_mth_misc_amt_113 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_113;
		public double? WhereChq_reg_mth_misc_amt_114 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_114;
		public double? WhereChq_reg_mth_misc_amt_115 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_115;
		public double? WhereChq_reg_mth_misc_amt_116 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_116;
		public double? WhereChq_reg_mth_misc_amt_117 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_117;
		public double? WhereChq_reg_mth_misc_amt_118 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_118;
		public double? WhereChq_reg_mth_misc_amt_21 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_21;
		public double? WhereChq_reg_mth_misc_amt_22 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_22;
		public double? WhereChq_reg_mth_misc_amt_23 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_23;
		public double? WhereChq_reg_mth_misc_amt_24 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_24;
		public double? WhereChq_reg_mth_misc_amt_25 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_25;
		public double? WhereChq_reg_mth_misc_amt_26 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_26;
		public double? WhereChq_reg_mth_misc_amt_27 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_27;
		public double? WhereChq_reg_mth_misc_amt_28 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_28;
		public double? WhereChq_reg_mth_misc_amt_29 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_29;
		public double? WhereChq_reg_mth_misc_amt_210 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_210;
		public double? WhereChq_reg_mth_misc_amt_211 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_211;
		public double? WhereChq_reg_mth_misc_amt_212 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_212;
		public double? WhereChq_reg_mth_misc_amt_213 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_213;
		public double? WhereChq_reg_mth_misc_amt_214 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_214;
		public double? WhereChq_reg_mth_misc_amt_215 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_215;
		public double? WhereChq_reg_mth_misc_amt_216 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_216;
		public double? WhereChq_reg_mth_misc_amt_217 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_217;
		public double? WhereChq_reg_mth_misc_amt_218 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_218;
		public double? WhereChq_reg_mth_misc_amt_31 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_31;
		public double? WhereChq_reg_mth_misc_amt_32 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_32;
		public double? WhereChq_reg_mth_misc_amt_33 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_33;
		public double? WhereChq_reg_mth_misc_amt_34 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_34;
		public double? WhereChq_reg_mth_misc_amt_35 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_35;
		public double? WhereChq_reg_mth_misc_amt_36 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_36;
		public double? WhereChq_reg_mth_misc_amt_37 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_37;
		public double? WhereChq_reg_mth_misc_amt_38 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_38;
		public double? WhereChq_reg_mth_misc_amt_39 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_39;
		public double? WhereChq_reg_mth_misc_amt_310 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_310;
		public double? WhereChq_reg_mth_misc_amt_311 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_311;
		public double? WhereChq_reg_mth_misc_amt_312 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_312;
		public double? WhereChq_reg_mth_misc_amt_313 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_313;
		public double? WhereChq_reg_mth_misc_amt_314 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_314;
		public double? WhereChq_reg_mth_misc_amt_315 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_315;
		public double? WhereChq_reg_mth_misc_amt_316 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_316;
		public double? WhereChq_reg_mth_misc_amt_317 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_317;
		public double? WhereChq_reg_mth_misc_amt_318 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_318;
		public double? WhereChq_reg_mth_misc_amt_41 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_41;
		public double? WhereChq_reg_mth_misc_amt_42 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_42;
		public double? WhereChq_reg_mth_misc_amt_43 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_43;
		public double? WhereChq_reg_mth_misc_amt_44 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_44;
		public double? WhereChq_reg_mth_misc_amt_45 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_45;
		public double? WhereChq_reg_mth_misc_amt_46 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_46;
		public double? WhereChq_reg_mth_misc_amt_47 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_47;
		public double? WhereChq_reg_mth_misc_amt_48 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_48;
		public double? WhereChq_reg_mth_misc_amt_49 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_49;
		public double? WhereChq_reg_mth_misc_amt_410 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_410;
		public double? WhereChq_reg_mth_misc_amt_411 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_411;
		public double? WhereChq_reg_mth_misc_amt_412 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_412;
		public double? WhereChq_reg_mth_misc_amt_413 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_413;
		public double? WhereChq_reg_mth_misc_amt_414 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_414;
		public double? WhereChq_reg_mth_misc_amt_415 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_415;
		public double? WhereChq_reg_mth_misc_amt_416 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_416;
		public double? WhereChq_reg_mth_misc_amt_417 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_417;
		public double? WhereChq_reg_mth_misc_amt_418 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_418;
		public double? WhereChq_reg_mth_misc_amt_51 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_51;
		public double? WhereChq_reg_mth_misc_amt_52 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_52;
		public double? WhereChq_reg_mth_misc_amt_53 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_53;
		public double? WhereChq_reg_mth_misc_amt_54 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_54;
		public double? WhereChq_reg_mth_misc_amt_55 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_55;
		public double? WhereChq_reg_mth_misc_amt_56 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_56;
		public double? WhereChq_reg_mth_misc_amt_57 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_57;
		public double? WhereChq_reg_mth_misc_amt_58 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_58;
		public double? WhereChq_reg_mth_misc_amt_59 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_59;
		public double? WhereChq_reg_mth_misc_amt_510 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_510;
		public double? WhereChq_reg_mth_misc_amt_511 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_511;
		public double? WhereChq_reg_mth_misc_amt_512 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_512;
		public double? WhereChq_reg_mth_misc_amt_513 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_513;
		public double? WhereChq_reg_mth_misc_amt_514 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_514;
		public double? WhereChq_reg_mth_misc_amt_515 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_515;
		public double? WhereChq_reg_mth_misc_amt_516 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_516;
		public double? WhereChq_reg_mth_misc_amt_517 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_517;
		public double? WhereChq_reg_mth_misc_amt_518 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_518;
		public double? WhereChq_reg_mth_misc_amt_61 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_61;
		public double? WhereChq_reg_mth_misc_amt_62 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_62;
		public double? WhereChq_reg_mth_misc_amt_63 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_63;
		public double? WhereChq_reg_mth_misc_amt_64 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_64;
		public double? WhereChq_reg_mth_misc_amt_65 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_65;
		public double? WhereChq_reg_mth_misc_amt_66 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_66;
		public double? WhereChq_reg_mth_misc_amt_67 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_67;
		public double? WhereChq_reg_mth_misc_amt_68 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_68;
		public double? WhereChq_reg_mth_misc_amt_69 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_69;
		public double? WhereChq_reg_mth_misc_amt_610 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_610;
		public double? WhereChq_reg_mth_misc_amt_611 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_611;
		public double? WhereChq_reg_mth_misc_amt_612 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_612;
		public double? WhereChq_reg_mth_misc_amt_613 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_613;
		public double? WhereChq_reg_mth_misc_amt_614 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_614;
		public double? WhereChq_reg_mth_misc_amt_615 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_615;
		public double? WhereChq_reg_mth_misc_amt_616 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_616;
		public double? WhereChq_reg_mth_misc_amt_617 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_617;
		public double? WhereChq_reg_mth_misc_amt_618 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_618;
		public double? WhereChq_reg_mth_misc_amt_71 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_71;
		public double? WhereChq_reg_mth_misc_amt_72 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_72;
		public double? WhereChq_reg_mth_misc_amt_73 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_73;
		public double? WhereChq_reg_mth_misc_amt_74 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_74;
		public double? WhereChq_reg_mth_misc_amt_75 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_75;
		public double? WhereChq_reg_mth_misc_amt_76 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_76;
		public double? WhereChq_reg_mth_misc_amt_77 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_77;
		public double? WhereChq_reg_mth_misc_amt_78 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_78;
		public double? WhereChq_reg_mth_misc_amt_79 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_79;
		public double? WhereChq_reg_mth_misc_amt_710 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_710;
		public double? WhereChq_reg_mth_misc_amt_711 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_711;
		public double? WhereChq_reg_mth_misc_amt_712 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_712;
		public double? WhereChq_reg_mth_misc_amt_713 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_713;
		public double? WhereChq_reg_mth_misc_amt_714 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_714;
		public double? WhereChq_reg_mth_misc_amt_715 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_715;
		public double? WhereChq_reg_mth_misc_amt_716 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_716;
		public double? WhereChq_reg_mth_misc_amt_717 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_717;
		public double? WhereChq_reg_mth_misc_amt_718 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_718;
		public double? WhereChq_reg_mth_misc_amt_81 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_81;
		public double? WhereChq_reg_mth_misc_amt_82 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_82;
		public double? WhereChq_reg_mth_misc_amt_83 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_83;
		public double? WhereChq_reg_mth_misc_amt_84 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_84;
		public double? WhereChq_reg_mth_misc_amt_85 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_85;
		public double? WhereChq_reg_mth_misc_amt_86 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_86;
		public double? WhereChq_reg_mth_misc_amt_87 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_87;
		public double? WhereChq_reg_mth_misc_amt_88 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_88;
		public double? WhereChq_reg_mth_misc_amt_89 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_89;
		public double? WhereChq_reg_mth_misc_amt_810 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_810;
		public double? WhereChq_reg_mth_misc_amt_811 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_811;
		public double? WhereChq_reg_mth_misc_amt_812 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_812;
		public double? WhereChq_reg_mth_misc_amt_813 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_813;
		public double? WhereChq_reg_mth_misc_amt_814 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_814;
		public double? WhereChq_reg_mth_misc_amt_815 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_815;
		public double? WhereChq_reg_mth_misc_amt_816 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_816;
		public double? WhereChq_reg_mth_misc_amt_817 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_817;
		public double? WhereChq_reg_mth_misc_amt_818 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_818;
		public double? WhereChq_reg_mth_misc_amt_91 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_91;
		public double? WhereChq_reg_mth_misc_amt_92 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_92;
		public double? WhereChq_reg_mth_misc_amt_93 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_93;
		public double? WhereChq_reg_mth_misc_amt_94 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_94;
		public double? WhereChq_reg_mth_misc_amt_95 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_95;
		public double? WhereChq_reg_mth_misc_amt_96 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_96;
		public double? WhereChq_reg_mth_misc_amt_97 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_97;
		public double? WhereChq_reg_mth_misc_amt_98 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_98;
		public double? WhereChq_reg_mth_misc_amt_99 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_99;
		public double? WhereChq_reg_mth_misc_amt_910 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_910;
		public double? WhereChq_reg_mth_misc_amt_911 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_911;
		public double? WhereChq_reg_mth_misc_amt_912 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_912;
		public double? WhereChq_reg_mth_misc_amt_913 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_913;
		public double? WhereChq_reg_mth_misc_amt_914 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_914;
		public double? WhereChq_reg_mth_misc_amt_915 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_915;
		public double? WhereChq_reg_mth_misc_amt_916 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_916;
		public double? WhereChq_reg_mth_misc_amt_917 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_917;
		public double? WhereChq_reg_mth_misc_amt_918 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_918;
		public double? WhereChq_reg_mth_misc_amt_101 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_101;
		public double? WhereChq_reg_mth_misc_amt_102 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_102;
		public double? WhereChq_reg_mth_misc_amt_103 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_103;
		public double? WhereChq_reg_mth_misc_amt_104 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_104;
		public double? WhereChq_reg_mth_misc_amt_105 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_105;
		public double? WhereChq_reg_mth_misc_amt_106 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_106;
		public double? WhereChq_reg_mth_misc_amt_107 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_107;
		public double? WhereChq_reg_mth_misc_amt_108 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_108;
		public double? WhereChq_reg_mth_misc_amt_109 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_109;
		public double? WhereChq_reg_mth_misc_amt_1010 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_1010;
		public double? WhereChq_reg_mth_misc_amt_1011 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_1011;
		public double? WhereChq_reg_mth_misc_amt_1012 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_1012;
		public double? WhereChq_reg_mth_misc_amt_1013 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_1013;
		public double? WhereChq_reg_mth_misc_amt_1014 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_1014;
		public double? WhereChq_reg_mth_misc_amt_1015 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_1015;
		public double? WhereChq_reg_mth_misc_amt_1016 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_1016;
		public double? WhereChq_reg_mth_misc_amt_1017 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_1017;
		public double? WhereChq_reg_mth_misc_amt_1018 { get; set; }
		private double? _whereChq_reg_mth_misc_amt_1018;
		public double? WhereChq_reg_mth_exp_amt1 { get; set; }
		private double? _whereChq_reg_mth_exp_amt1;
		public double? WhereChq_reg_mth_exp_amt2 { get; set; }
		private double? _whereChq_reg_mth_exp_amt2;
		public double? WhereChq_reg_mth_exp_amt3 { get; set; }
		private double? _whereChq_reg_mth_exp_amt3;
		public double? WhereChq_reg_mth_exp_amt4 { get; set; }
		private double? _whereChq_reg_mth_exp_amt4;
		public double? WhereChq_reg_mth_exp_amt5 { get; set; }
		private double? _whereChq_reg_mth_exp_amt5;
		public double? WhereChq_reg_mth_exp_amt6 { get; set; }
		private double? _whereChq_reg_mth_exp_amt6;
		public double? WhereChq_reg_mth_exp_amt7 { get; set; }
		private double? _whereChq_reg_mth_exp_amt7;
		public double? WhereChq_reg_mth_exp_amt8 { get; set; }
		private double? _whereChq_reg_mth_exp_amt8;
		public double? WhereChq_reg_mth_exp_amt9 { get; set; }
		private double? _whereChq_reg_mth_exp_amt9;
		public double? WhereChq_reg_mth_exp_amt10 { get; set; }
		private double? _whereChq_reg_mth_exp_amt10;
		public double? WhereChq_reg_mth_exp_amt11 { get; set; }
		private double? _whereChq_reg_mth_exp_amt11;
		public double? WhereChq_reg_mth_exp_amt12 { get; set; }
		private double? _whereChq_reg_mth_exp_amt12;
		public double? WhereChq_reg_mth_exp_amt13 { get; set; }
		private double? _whereChq_reg_mth_exp_amt13;
		public double? WhereChq_reg_mth_exp_amt14 { get; set; }
		private double? _whereChq_reg_mth_exp_amt14;
		public double? WhereChq_reg_mth_exp_amt15 { get; set; }
		private double? _whereChq_reg_mth_exp_amt15;
		public double? WhereChq_reg_mth_exp_amt16 { get; set; }
		private double? _whereChq_reg_mth_exp_amt16;
		public double? WhereChq_reg_mth_exp_amt17 { get; set; }
		private double? _whereChq_reg_mth_exp_amt17;
		public double? WhereChq_reg_mth_exp_amt18 { get; set; }
		private double? _whereChq_reg_mth_exp_amt18;
		public double? WhereChq_reg_comp_ann_exp_this_pay1 { get; set; }
		private double? _whereChq_reg_comp_ann_exp_this_pay1;
		public double? WhereChq_reg_comp_ann_exp_this_pay2 { get; set; }
		private double? _whereChq_reg_comp_ann_exp_this_pay2;
		public double? WhereChq_reg_comp_ann_exp_this_pay3 { get; set; }
		private double? _whereChq_reg_comp_ann_exp_this_pay3;
		public double? WhereChq_reg_comp_ann_exp_this_pay4 { get; set; }
		private double? _whereChq_reg_comp_ann_exp_this_pay4;
		public double? WhereChq_reg_comp_ann_exp_this_pay5 { get; set; }
		private double? _whereChq_reg_comp_ann_exp_this_pay5;
		public double? WhereChq_reg_comp_ann_exp_this_pay6 { get; set; }
		private double? _whereChq_reg_comp_ann_exp_this_pay6;
		public double? WhereChq_reg_comp_ann_exp_this_pay7 { get; set; }
		private double? _whereChq_reg_comp_ann_exp_this_pay7;
		public double? WhereChq_reg_comp_ann_exp_this_pay8 { get; set; }
		private double? _whereChq_reg_comp_ann_exp_this_pay8;
		public double? WhereChq_reg_comp_ann_exp_this_pay9 { get; set; }
		private double? _whereChq_reg_comp_ann_exp_this_pay9;
		public double? WhereChq_reg_comp_ann_exp_this_pay10 { get; set; }
		private double? _whereChq_reg_comp_ann_exp_this_pay10;
		public double? WhereChq_reg_comp_ann_exp_this_pay11 { get; set; }
		private double? _whereChq_reg_comp_ann_exp_this_pay11;
		public double? WhereChq_reg_comp_ann_exp_this_pay12 { get; set; }
		private double? _whereChq_reg_comp_ann_exp_this_pay12;
		public double? WhereChq_reg_comp_ann_exp_this_pay13 { get; set; }
		private double? _whereChq_reg_comp_ann_exp_this_pay13;
		public double? WhereChq_reg_comp_ann_exp_this_pay14 { get; set; }
		private double? _whereChq_reg_comp_ann_exp_this_pay14;
		public double? WhereChq_reg_comp_ann_exp_this_pay15 { get; set; }
		private double? _whereChq_reg_comp_ann_exp_this_pay15;
		public double? WhereChq_reg_comp_ann_exp_this_pay16 { get; set; }
		private double? _whereChq_reg_comp_ann_exp_this_pay16;
		public double? WhereChq_reg_comp_ann_exp_this_pay17 { get; set; }
		private double? _whereChq_reg_comp_ann_exp_this_pay17;
		public double? WhereChq_reg_comp_ann_exp_this_pay18 { get; set; }
		private double? _whereChq_reg_comp_ann_exp_this_pay18;
		public double? WhereChq_reg_mth_ceil_amt1 { get; set; }
		private double? _whereChq_reg_mth_ceil_amt1;
		public double? WhereChq_reg_mth_ceil_amt2 { get; set; }
		private double? _whereChq_reg_mth_ceil_amt2;
		public double? WhereChq_reg_mth_ceil_amt3 { get; set; }
		private double? _whereChq_reg_mth_ceil_amt3;
		public double? WhereChq_reg_mth_ceil_amt4 { get; set; }
		private double? _whereChq_reg_mth_ceil_amt4;
		public double? WhereChq_reg_mth_ceil_amt5 { get; set; }
		private double? _whereChq_reg_mth_ceil_amt5;
		public double? WhereChq_reg_mth_ceil_amt6 { get; set; }
		private double? _whereChq_reg_mth_ceil_amt6;
		public double? WhereChq_reg_mth_ceil_amt7 { get; set; }
		private double? _whereChq_reg_mth_ceil_amt7;
		public double? WhereChq_reg_mth_ceil_amt8 { get; set; }
		private double? _whereChq_reg_mth_ceil_amt8;
		public double? WhereChq_reg_mth_ceil_amt9 { get; set; }
		private double? _whereChq_reg_mth_ceil_amt9;
		public double? WhereChq_reg_mth_ceil_amt10 { get; set; }
		private double? _whereChq_reg_mth_ceil_amt10;
		public double? WhereChq_reg_mth_ceil_amt11 { get; set; }
		private double? _whereChq_reg_mth_ceil_amt11;
		public double? WhereChq_reg_mth_ceil_amt12 { get; set; }
		private double? _whereChq_reg_mth_ceil_amt12;
		public double? WhereChq_reg_mth_ceil_amt13 { get; set; }
		private double? _whereChq_reg_mth_ceil_amt13;
		public double? WhereChq_reg_mth_ceil_amt14 { get; set; }
		private double? _whereChq_reg_mth_ceil_amt14;
		public double? WhereChq_reg_mth_ceil_amt15 { get; set; }
		private double? _whereChq_reg_mth_ceil_amt15;
		public double? WhereChq_reg_mth_ceil_amt16 { get; set; }
		private double? _whereChq_reg_mth_ceil_amt16;
		public double? WhereChq_reg_mth_ceil_amt17 { get; set; }
		private double? _whereChq_reg_mth_ceil_amt17;
		public double? WhereChq_reg_mth_ceil_amt18 { get; set; }
		private double? _whereChq_reg_mth_ceil_amt18;
		public double? WhereChq_reg_comp_ann_ceil_this_pay1 { get; set; }
		private double? _whereChq_reg_comp_ann_ceil_this_pay1;
		public double? WhereChq_reg_comp_ann_ceil_this_pay2 { get; set; }
		private double? _whereChq_reg_comp_ann_ceil_this_pay2;
		public double? WhereChq_reg_comp_ann_ceil_this_pay3 { get; set; }
		private double? _whereChq_reg_comp_ann_ceil_this_pay3;
		public double? WhereChq_reg_comp_ann_ceil_this_pay4 { get; set; }
		private double? _whereChq_reg_comp_ann_ceil_this_pay4;
		public double? WhereChq_reg_comp_ann_ceil_this_pay5 { get; set; }
		private double? _whereChq_reg_comp_ann_ceil_this_pay5;
		public double? WhereChq_reg_comp_ann_ceil_this_pay6 { get; set; }
		private double? _whereChq_reg_comp_ann_ceil_this_pay6;
		public double? WhereChq_reg_comp_ann_ceil_this_pay7 { get; set; }
		private double? _whereChq_reg_comp_ann_ceil_this_pay7;
		public double? WhereChq_reg_comp_ann_ceil_this_pay8 { get; set; }
		private double? _whereChq_reg_comp_ann_ceil_this_pay8;
		public double? WhereChq_reg_comp_ann_ceil_this_pay9 { get; set; }
		private double? _whereChq_reg_comp_ann_ceil_this_pay9;
		public double? WhereChq_reg_comp_ann_ceil_this_pay10 { get; set; }
		private double? _whereChq_reg_comp_ann_ceil_this_pay10;
		public double? WhereChq_reg_comp_ann_ceil_this_pay11 { get; set; }
		private double? _whereChq_reg_comp_ann_ceil_this_pay11;
		public double? WhereChq_reg_comp_ann_ceil_this_pay12 { get; set; }
		private double? _whereChq_reg_comp_ann_ceil_this_pay12;
		public double? WhereChq_reg_comp_ann_ceil_this_pay13 { get; set; }
		private double? _whereChq_reg_comp_ann_ceil_this_pay13;
		public double? WhereChq_reg_comp_ann_ceil_this_pay14 { get; set; }
		private double? _whereChq_reg_comp_ann_ceil_this_pay14;
		public double? WhereChq_reg_comp_ann_ceil_this_pay15 { get; set; }
		private double? _whereChq_reg_comp_ann_ceil_this_pay15;
		public double? WhereChq_reg_comp_ann_ceil_this_pay16 { get; set; }
		private double? _whereChq_reg_comp_ann_ceil_this_pay16;
		public double? WhereChq_reg_comp_ann_ceil_this_pay17 { get; set; }
		private double? _whereChq_reg_comp_ann_ceil_this_pay17;
		public double? WhereChq_reg_comp_ann_ceil_this_pay18 { get; set; }
		private double? _whereChq_reg_comp_ann_ceil_this_pay18;
		public double? WhereChq_reg_earnings_this_mth1 { get; set; }
		private double? _whereChq_reg_earnings_this_mth1;
		public double? WhereChq_reg_earnings_this_mth2 { get; set; }
		private double? _whereChq_reg_earnings_this_mth2;
		public double? WhereChq_reg_earnings_this_mth3 { get; set; }
		private double? _whereChq_reg_earnings_this_mth3;
		public double? WhereChq_reg_earnings_this_mth4 { get; set; }
		private double? _whereChq_reg_earnings_this_mth4;
		public double? WhereChq_reg_earnings_this_mth5 { get; set; }
		private double? _whereChq_reg_earnings_this_mth5;
		public double? WhereChq_reg_earnings_this_mth6 { get; set; }
		private double? _whereChq_reg_earnings_this_mth6;
		public double? WhereChq_reg_earnings_this_mth7 { get; set; }
		private double? _whereChq_reg_earnings_this_mth7;
		public double? WhereChq_reg_earnings_this_mth8 { get; set; }
		private double? _whereChq_reg_earnings_this_mth8;
		public double? WhereChq_reg_earnings_this_mth9 { get; set; }
		private double? _whereChq_reg_earnings_this_mth9;
		public double? WhereChq_reg_earnings_this_mth10 { get; set; }
		private double? _whereChq_reg_earnings_this_mth10;
		public double? WhereChq_reg_earnings_this_mth11 { get; set; }
		private double? _whereChq_reg_earnings_this_mth11;
		public double? WhereChq_reg_earnings_this_mth12 { get; set; }
		private double? _whereChq_reg_earnings_this_mth12;
		public double? WhereChq_reg_earnings_this_mth13 { get; set; }
		private double? _whereChq_reg_earnings_this_mth13;
		public double? WhereChq_reg_earnings_this_mth14 { get; set; }
		private double? _whereChq_reg_earnings_this_mth14;
		public double? WhereChq_reg_earnings_this_mth15 { get; set; }
		private double? _whereChq_reg_earnings_this_mth15;
		public double? WhereChq_reg_earnings_this_mth16 { get; set; }
		private double? _whereChq_reg_earnings_this_mth16;
		public double? WhereChq_reg_earnings_this_mth17 { get; set; }
		private double? _whereChq_reg_earnings_this_mth17;
		public double? WhereChq_reg_earnings_this_mth18 { get; set; }
		private double? _whereChq_reg_earnings_this_mth18;
		public double? WhereChq_reg_regular_pay_this_mth1 { get; set; }
		private double? _whereChq_reg_regular_pay_this_mth1;
		public double? WhereChq_reg_regular_pay_this_mth2 { get; set; }
		private double? _whereChq_reg_regular_pay_this_mth2;
		public double? WhereChq_reg_regular_pay_this_mth3 { get; set; }
		private double? _whereChq_reg_regular_pay_this_mth3;
		public double? WhereChq_reg_regular_pay_this_mth4 { get; set; }
		private double? _whereChq_reg_regular_pay_this_mth4;
		public double? WhereChq_reg_regular_pay_this_mth5 { get; set; }
		private double? _whereChq_reg_regular_pay_this_mth5;
		public double? WhereChq_reg_regular_pay_this_mth6 { get; set; }
		private double? _whereChq_reg_regular_pay_this_mth6;
		public double? WhereChq_reg_regular_pay_this_mth7 { get; set; }
		private double? _whereChq_reg_regular_pay_this_mth7;
		public double? WhereChq_reg_regular_pay_this_mth8 { get; set; }
		private double? _whereChq_reg_regular_pay_this_mth8;
		public double? WhereChq_reg_regular_pay_this_mth9 { get; set; }
		private double? _whereChq_reg_regular_pay_this_mth9;
		public double? WhereChq_reg_regular_pay_this_mth10 { get; set; }
		private double? _whereChq_reg_regular_pay_this_mth10;
		public double? WhereChq_reg_regular_pay_this_mth11 { get; set; }
		private double? _whereChq_reg_regular_pay_this_mth11;
		public double? WhereChq_reg_regular_pay_this_mth12 { get; set; }
		private double? _whereChq_reg_regular_pay_this_mth12;
		public double? WhereChq_reg_regular_pay_this_mth13 { get; set; }
		private double? _whereChq_reg_regular_pay_this_mth13;
		public double? WhereChq_reg_regular_pay_this_mth14 { get; set; }
		private double? _whereChq_reg_regular_pay_this_mth14;
		public double? WhereChq_reg_regular_pay_this_mth15 { get; set; }
		private double? _whereChq_reg_regular_pay_this_mth15;
		public double? WhereChq_reg_regular_pay_this_mth16 { get; set; }
		private double? _whereChq_reg_regular_pay_this_mth16;
		public double? WhereChq_reg_regular_pay_this_mth17 { get; set; }
		private double? _whereChq_reg_regular_pay_this_mth17;
		public double? WhereChq_reg_regular_pay_this_mth18 { get; set; }
		private double? _whereChq_reg_regular_pay_this_mth18;
		public double? WhereChq_reg_regular_tax_this_mth1 { get; set; }
		private double? _whereChq_reg_regular_tax_this_mth1;
		public double? WhereChq_reg_regular_tax_this_mth2 { get; set; }
		private double? _whereChq_reg_regular_tax_this_mth2;
		public double? WhereChq_reg_regular_tax_this_mth3 { get; set; }
		private double? _whereChq_reg_regular_tax_this_mth3;
		public double? WhereChq_reg_regular_tax_this_mth4 { get; set; }
		private double? _whereChq_reg_regular_tax_this_mth4;
		public double? WhereChq_reg_regular_tax_this_mth5 { get; set; }
		private double? _whereChq_reg_regular_tax_this_mth5;
		public double? WhereChq_reg_regular_tax_this_mth6 { get; set; }
		private double? _whereChq_reg_regular_tax_this_mth6;
		public double? WhereChq_reg_regular_tax_this_mth7 { get; set; }
		private double? _whereChq_reg_regular_tax_this_mth7;
		public double? WhereChq_reg_regular_tax_this_mth8 { get; set; }
		private double? _whereChq_reg_regular_tax_this_mth8;
		public double? WhereChq_reg_regular_tax_this_mth9 { get; set; }
		private double? _whereChq_reg_regular_tax_this_mth9;
		public double? WhereChq_reg_regular_tax_this_mth10 { get; set; }
		private double? _whereChq_reg_regular_tax_this_mth10;
		public double? WhereChq_reg_regular_tax_this_mth11 { get; set; }
		private double? _whereChq_reg_regular_tax_this_mth11;
		public double? WhereChq_reg_regular_tax_this_mth12 { get; set; }
		private double? _whereChq_reg_regular_tax_this_mth12;
		public double? WhereChq_reg_regular_tax_this_mth13 { get; set; }
		private double? _whereChq_reg_regular_tax_this_mth13;
		public double? WhereChq_reg_regular_tax_this_mth14 { get; set; }
		private double? _whereChq_reg_regular_tax_this_mth14;
		public double? WhereChq_reg_regular_tax_this_mth15 { get; set; }
		private double? _whereChq_reg_regular_tax_this_mth15;
		public double? WhereChq_reg_regular_tax_this_mth16 { get; set; }
		private double? _whereChq_reg_regular_tax_this_mth16;
		public double? WhereChq_reg_regular_tax_this_mth17 { get; set; }
		private double? _whereChq_reg_regular_tax_this_mth17;
		public double? WhereChq_reg_regular_tax_this_mth18 { get; set; }
		private double? _whereChq_reg_regular_tax_this_mth18;
		public double? WhereChq_reg_man_pay_this_mth1 { get; set; }
		private double? _whereChq_reg_man_pay_this_mth1;
		public double? WhereChq_reg_man_pay_this_mth2 { get; set; }
		private double? _whereChq_reg_man_pay_this_mth2;
		public double? WhereChq_reg_man_pay_this_mth3 { get; set; }
		private double? _whereChq_reg_man_pay_this_mth3;
		public double? WhereChq_reg_man_pay_this_mth4 { get; set; }
		private double? _whereChq_reg_man_pay_this_mth4;
		public double? WhereChq_reg_man_pay_this_mth5 { get; set; }
		private double? _whereChq_reg_man_pay_this_mth5;
		public double? WhereChq_reg_man_pay_this_mth6 { get; set; }
		private double? _whereChq_reg_man_pay_this_mth6;
		public double? WhereChq_reg_man_pay_this_mth7 { get; set; }
		private double? _whereChq_reg_man_pay_this_mth7;
		public double? WhereChq_reg_man_pay_this_mth8 { get; set; }
		private double? _whereChq_reg_man_pay_this_mth8;
		public double? WhereChq_reg_man_pay_this_mth9 { get; set; }
		private double? _whereChq_reg_man_pay_this_mth9;
		public double? WhereChq_reg_man_pay_this_mth10 { get; set; }
		private double? _whereChq_reg_man_pay_this_mth10;
		public double? WhereChq_reg_man_pay_this_mth11 { get; set; }
		private double? _whereChq_reg_man_pay_this_mth11;
		public double? WhereChq_reg_man_pay_this_mth12 { get; set; }
		private double? _whereChq_reg_man_pay_this_mth12;
		public double? WhereChq_reg_man_pay_this_mth13 { get; set; }
		private double? _whereChq_reg_man_pay_this_mth13;
		public double? WhereChq_reg_man_pay_this_mth14 { get; set; }
		private double? _whereChq_reg_man_pay_this_mth14;
		public double? WhereChq_reg_man_pay_this_mth15 { get; set; }
		private double? _whereChq_reg_man_pay_this_mth15;
		public double? WhereChq_reg_man_pay_this_mth16 { get; set; }
		private double? _whereChq_reg_man_pay_this_mth16;
		public double? WhereChq_reg_man_pay_this_mth17 { get; set; }
		private double? _whereChq_reg_man_pay_this_mth17;
		public double? WhereChq_reg_man_pay_this_mth18 { get; set; }
		private double? _whereChq_reg_man_pay_this_mth18;
		public double? WhereChq_reg_man_tax_this_mth1 { get; set; }
		private double? _whereChq_reg_man_tax_this_mth1;
		public double? WhereChq_reg_man_tax_this_mth2 { get; set; }
		private double? _whereChq_reg_man_tax_this_mth2;
		public double? WhereChq_reg_man_tax_this_mth3 { get; set; }
		private double? _whereChq_reg_man_tax_this_mth3;
		public double? WhereChq_reg_man_tax_this_mth4 { get; set; }
		private double? _whereChq_reg_man_tax_this_mth4;
		public double? WhereChq_reg_man_tax_this_mth5 { get; set; }
		private double? _whereChq_reg_man_tax_this_mth5;
		public double? WhereChq_reg_man_tax_this_mth6 { get; set; }
		private double? _whereChq_reg_man_tax_this_mth6;
		public double? WhereChq_reg_man_tax_this_mth7 { get; set; }
		private double? _whereChq_reg_man_tax_this_mth7;
		public double? WhereChq_reg_man_tax_this_mth8 { get; set; }
		private double? _whereChq_reg_man_tax_this_mth8;
		public double? WhereChq_reg_man_tax_this_mth9 { get; set; }
		private double? _whereChq_reg_man_tax_this_mth9;
		public double? WhereChq_reg_man_tax_this_mth10 { get; set; }
		private double? _whereChq_reg_man_tax_this_mth10;
		public double? WhereChq_reg_man_tax_this_mth11 { get; set; }
		private double? _whereChq_reg_man_tax_this_mth11;
		public double? WhereChq_reg_man_tax_this_mth12 { get; set; }
		private double? _whereChq_reg_man_tax_this_mth12;
		public double? WhereChq_reg_man_tax_this_mth13 { get; set; }
		private double? _whereChq_reg_man_tax_this_mth13;
		public double? WhereChq_reg_man_tax_this_mth14 { get; set; }
		private double? _whereChq_reg_man_tax_this_mth14;
		public double? WhereChq_reg_man_tax_this_mth15 { get; set; }
		private double? _whereChq_reg_man_tax_this_mth15;
		public double? WhereChq_reg_man_tax_this_mth16 { get; set; }
		private double? _whereChq_reg_man_tax_this_mth16;
		public double? WhereChq_reg_man_tax_this_mth17 { get; set; }
		private double? _whereChq_reg_man_tax_this_mth17;
		public double? WhereChq_reg_man_tax_this_mth18 { get; set; }
		private double? _whereChq_reg_man_tax_this_mth18;
		public decimal? WhereChq_reg_pay_date1 { get; set; }
		private decimal? _whereChq_reg_pay_date1;
		public decimal? WhereChq_reg_pay_date2 { get; set; }
		private decimal? _whereChq_reg_pay_date2;
		public decimal? WhereChq_reg_pay_date3 { get; set; }
		private decimal? _whereChq_reg_pay_date3;
		public decimal? WhereChq_reg_pay_date4 { get; set; }
		private decimal? _whereChq_reg_pay_date4;
		public decimal? WhereChq_reg_pay_date5 { get; set; }
		private decimal? _whereChq_reg_pay_date5;
		public decimal? WhereChq_reg_pay_date6 { get; set; }
		private decimal? _whereChq_reg_pay_date6;
		public decimal? WhereChq_reg_pay_date7 { get; set; }
		private decimal? _whereChq_reg_pay_date7;
		public decimal? WhereChq_reg_pay_date8 { get; set; }
		private decimal? _whereChq_reg_pay_date8;
		public decimal? WhereChq_reg_pay_date9 { get; set; }
		private decimal? _whereChq_reg_pay_date9;
		public decimal? WhereChq_reg_pay_date10 { get; set; }
		private decimal? _whereChq_reg_pay_date10;
		public decimal? WhereChq_reg_pay_date11 { get; set; }
		private decimal? _whereChq_reg_pay_date11;
		public decimal? WhereChq_reg_pay_date12 { get; set; }
		private decimal? _whereChq_reg_pay_date12;
		public decimal? WhereChq_reg_pay_date13 { get; set; }
		private decimal? _whereChq_reg_pay_date13;
		public decimal? WhereChq_reg_pay_date14 { get; set; }
		private decimal? _whereChq_reg_pay_date14;
		public decimal? WhereChq_reg_pay_date15 { get; set; }
		private decimal? _whereChq_reg_pay_date15;
		public decimal? WhereChq_reg_pay_date16 { get; set; }
		private decimal? _whereChq_reg_pay_date16;
		public decimal? WhereChq_reg_pay_date17 { get; set; }
		private decimal? _whereChq_reg_pay_date17;
		public decimal? WhereChq_reg_pay_date18 { get; set; }
		private decimal? _whereChq_reg_pay_date18;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private decimal? _originalChq_reg_clinic_nbr_1_2;
		private decimal? _originalChq_reg_dept;
		private string _originalChq_reg_doc_nbr;
		private decimal? _originalChq_reg_perc_bill1;
		private decimal? _originalChq_reg_perc_bill2;
		private decimal? _originalChq_reg_perc_bill3;
		private decimal? _originalChq_reg_perc_bill4;
		private decimal? _originalChq_reg_perc_bill5;
		private decimal? _originalChq_reg_perc_bill6;
		private decimal? _originalChq_reg_perc_bill7;
		private decimal? _originalChq_reg_perc_bill8;
		private decimal? _originalChq_reg_perc_bill9;
		private decimal? _originalChq_reg_perc_bill10;
		private decimal? _originalChq_reg_perc_bill11;
		private decimal? _originalChq_reg_perc_bill12;
		private decimal? _originalChq_reg_perc_bill13;
		private decimal? _originalChq_reg_perc_bill14;
		private decimal? _originalChq_reg_perc_bill15;
		private decimal? _originalChq_reg_perc_bill16;
		private decimal? _originalChq_reg_perc_bill17;
		private decimal? _originalChq_reg_perc_bill18;
		private decimal? _originalChq_reg_perc_misc1;
		private decimal? _originalChq_reg_perc_misc2;
		private decimal? _originalChq_reg_perc_misc3;
		private decimal? _originalChq_reg_perc_misc4;
		private decimal? _originalChq_reg_perc_misc5;
		private decimal? _originalChq_reg_perc_misc6;
		private decimal? _originalChq_reg_perc_misc7;
		private decimal? _originalChq_reg_perc_misc8;
		private decimal? _originalChq_reg_perc_misc9;
		private decimal? _originalChq_reg_perc_misc10;
		private decimal? _originalChq_reg_perc_misc11;
		private decimal? _originalChq_reg_perc_misc12;
		private decimal? _originalChq_reg_perc_misc13;
		private decimal? _originalChq_reg_perc_misc14;
		private decimal? _originalChq_reg_perc_misc15;
		private decimal? _originalChq_reg_perc_misc16;
		private decimal? _originalChq_reg_perc_misc17;
		private decimal? _originalChq_reg_perc_misc18;
		private string _originalChq_reg_pay_code1;
		private string _originalChq_reg_pay_code2;
		private string _originalChq_reg_pay_code3;
		private string _originalChq_reg_pay_code4;
		private string _originalChq_reg_pay_code5;
		private string _originalChq_reg_pay_code6;
		private string _originalChq_reg_pay_code7;
		private string _originalChq_reg_pay_code8;
		private string _originalChq_reg_pay_code9;
		private string _originalChq_reg_pay_code10;
		private string _originalChq_reg_pay_code11;
		private string _originalChq_reg_pay_code12;
		private string _originalChq_reg_pay_code13;
		private string _originalChq_reg_pay_code14;
		private string _originalChq_reg_pay_code15;
		private string _originalChq_reg_pay_code16;
		private string _originalChq_reg_pay_code17;
		private string _originalChq_reg_pay_code18;
		private decimal? _originalChq_reg_perc_tax1;
		private decimal? _originalChq_reg_perc_tax2;
		private decimal? _originalChq_reg_perc_tax3;
		private decimal? _originalChq_reg_perc_tax4;
		private decimal? _originalChq_reg_perc_tax5;
		private decimal? _originalChq_reg_perc_tax6;
		private decimal? _originalChq_reg_perc_tax7;
		private decimal? _originalChq_reg_perc_tax8;
		private decimal? _originalChq_reg_perc_tax9;
		private decimal? _originalChq_reg_perc_tax10;
		private decimal? _originalChq_reg_perc_tax11;
		private decimal? _originalChq_reg_perc_tax12;
		private decimal? _originalChq_reg_perc_tax13;
		private decimal? _originalChq_reg_perc_tax14;
		private decimal? _originalChq_reg_perc_tax15;
		private decimal? _originalChq_reg_perc_tax16;
		private decimal? _originalChq_reg_perc_tax17;
		private decimal? _originalChq_reg_perc_tax18;
		private decimal? _originalChq_reg_mth_bill_amt1;
		private decimal? _originalChq_reg_mth_bill_amt2;
		private decimal? _originalChq_reg_mth_bill_amt3;
		private decimal? _originalChq_reg_mth_bill_amt4;
		private decimal? _originalChq_reg_mth_bill_amt5;
		private decimal? _originalChq_reg_mth_bill_amt6;
		private decimal? _originalChq_reg_mth_bill_amt7;
		private decimal? _originalChq_reg_mth_bill_amt8;
		private decimal? _originalChq_reg_mth_bill_amt9;
		private decimal? _originalChq_reg_mth_bill_amt10;
		private decimal? _originalChq_reg_mth_bill_amt11;
		private decimal? _originalChq_reg_mth_bill_amt12;
		private decimal? _originalChq_reg_mth_bill_amt13;
		private decimal? _originalChq_reg_mth_bill_amt14;
		private decimal? _originalChq_reg_mth_bill_amt15;
		private decimal? _originalChq_reg_mth_bill_amt16;
		private decimal? _originalChq_reg_mth_bill_amt17;
		private decimal? _originalChq_reg_mth_bill_amt18;
		private decimal? _originalChq_reg_mth_misc_amt_11;
		private decimal? _originalChq_reg_mth_misc_amt_12;
		private decimal? _originalChq_reg_mth_misc_amt_13;
		private decimal? _originalChq_reg_mth_misc_amt_14;
		private decimal? _originalChq_reg_mth_misc_amt_15;
		private decimal? _originalChq_reg_mth_misc_amt_16;
		private decimal? _originalChq_reg_mth_misc_amt_17;
		private decimal? _originalChq_reg_mth_misc_amt_18;
		private decimal? _originalChq_reg_mth_misc_amt_19;
		private decimal? _originalChq_reg_mth_misc_amt_110;
		private decimal? _originalChq_reg_mth_misc_amt_111;
		private decimal? _originalChq_reg_mth_misc_amt_112;
		private decimal? _originalChq_reg_mth_misc_amt_113;
		private decimal? _originalChq_reg_mth_misc_amt_114;
		private decimal? _originalChq_reg_mth_misc_amt_115;
		private decimal? _originalChq_reg_mth_misc_amt_116;
		private decimal? _originalChq_reg_mth_misc_amt_117;
		private decimal? _originalChq_reg_mth_misc_amt_118;
		private decimal? _originalChq_reg_mth_misc_amt_21;
		private decimal? _originalChq_reg_mth_misc_amt_22;
		private decimal? _originalChq_reg_mth_misc_amt_23;
		private decimal? _originalChq_reg_mth_misc_amt_24;
		private decimal? _originalChq_reg_mth_misc_amt_25;
		private decimal? _originalChq_reg_mth_misc_amt_26;
		private decimal? _originalChq_reg_mth_misc_amt_27;
		private decimal? _originalChq_reg_mth_misc_amt_28;
		private decimal? _originalChq_reg_mth_misc_amt_29;
		private decimal? _originalChq_reg_mth_misc_amt_210;
		private decimal? _originalChq_reg_mth_misc_amt_211;
		private decimal? _originalChq_reg_mth_misc_amt_212;
		private decimal? _originalChq_reg_mth_misc_amt_213;
		private decimal? _originalChq_reg_mth_misc_amt_214;
		private decimal? _originalChq_reg_mth_misc_amt_215;
		private decimal? _originalChq_reg_mth_misc_amt_216;
		private decimal? _originalChq_reg_mth_misc_amt_217;
		private decimal? _originalChq_reg_mth_misc_amt_218;
		private decimal? _originalChq_reg_mth_misc_amt_31;
		private decimal? _originalChq_reg_mth_misc_amt_32;
		private decimal? _originalChq_reg_mth_misc_amt_33;
		private decimal? _originalChq_reg_mth_misc_amt_34;
		private decimal? _originalChq_reg_mth_misc_amt_35;
		private decimal? _originalChq_reg_mth_misc_amt_36;
		private decimal? _originalChq_reg_mth_misc_amt_37;
		private decimal? _originalChq_reg_mth_misc_amt_38;
		private decimal? _originalChq_reg_mth_misc_amt_39;
		private decimal? _originalChq_reg_mth_misc_amt_310;
		private decimal? _originalChq_reg_mth_misc_amt_311;
		private decimal? _originalChq_reg_mth_misc_amt_312;
		private decimal? _originalChq_reg_mth_misc_amt_313;
		private decimal? _originalChq_reg_mth_misc_amt_314;
		private decimal? _originalChq_reg_mth_misc_amt_315;
		private decimal? _originalChq_reg_mth_misc_amt_316;
		private decimal? _originalChq_reg_mth_misc_amt_317;
		private decimal? _originalChq_reg_mth_misc_amt_318;
		private decimal? _originalChq_reg_mth_misc_amt_41;
		private decimal? _originalChq_reg_mth_misc_amt_42;
		private decimal? _originalChq_reg_mth_misc_amt_43;
		private decimal? _originalChq_reg_mth_misc_amt_44;
		private decimal? _originalChq_reg_mth_misc_amt_45;
		private decimal? _originalChq_reg_mth_misc_amt_46;
		private decimal? _originalChq_reg_mth_misc_amt_47;
		private decimal? _originalChq_reg_mth_misc_amt_48;
		private decimal? _originalChq_reg_mth_misc_amt_49;
		private decimal? _originalChq_reg_mth_misc_amt_410;
		private decimal? _originalChq_reg_mth_misc_amt_411;
		private decimal? _originalChq_reg_mth_misc_amt_412;
		private decimal? _originalChq_reg_mth_misc_amt_413;
		private decimal? _originalChq_reg_mth_misc_amt_414;
		private decimal? _originalChq_reg_mth_misc_amt_415;
		private decimal? _originalChq_reg_mth_misc_amt_416;
		private decimal? _originalChq_reg_mth_misc_amt_417;
		private decimal? _originalChq_reg_mth_misc_amt_418;
		private decimal? _originalChq_reg_mth_misc_amt_51;
		private decimal? _originalChq_reg_mth_misc_amt_52;
		private decimal? _originalChq_reg_mth_misc_amt_53;
		private decimal? _originalChq_reg_mth_misc_amt_54;
		private decimal? _originalChq_reg_mth_misc_amt_55;
		private decimal? _originalChq_reg_mth_misc_amt_56;
		private decimal? _originalChq_reg_mth_misc_amt_57;
		private decimal? _originalChq_reg_mth_misc_amt_58;
		private decimal? _originalChq_reg_mth_misc_amt_59;
		private decimal? _originalChq_reg_mth_misc_amt_510;
		private decimal? _originalChq_reg_mth_misc_amt_511;
		private decimal? _originalChq_reg_mth_misc_amt_512;
		private decimal? _originalChq_reg_mth_misc_amt_513;
		private decimal? _originalChq_reg_mth_misc_amt_514;
		private decimal? _originalChq_reg_mth_misc_amt_515;
		private decimal? _originalChq_reg_mth_misc_amt_516;
		private decimal? _originalChq_reg_mth_misc_amt_517;
		private decimal? _originalChq_reg_mth_misc_amt_518;
		private decimal? _originalChq_reg_mth_misc_amt_61;
		private decimal? _originalChq_reg_mth_misc_amt_62;
		private decimal? _originalChq_reg_mth_misc_amt_63;
		private decimal? _originalChq_reg_mth_misc_amt_64;
		private decimal? _originalChq_reg_mth_misc_amt_65;
		private decimal? _originalChq_reg_mth_misc_amt_66;
		private decimal? _originalChq_reg_mth_misc_amt_67;
		private decimal? _originalChq_reg_mth_misc_amt_68;
		private decimal? _originalChq_reg_mth_misc_amt_69;
		private decimal? _originalChq_reg_mth_misc_amt_610;
		private decimal? _originalChq_reg_mth_misc_amt_611;
		private decimal? _originalChq_reg_mth_misc_amt_612;
		private decimal? _originalChq_reg_mth_misc_amt_613;
		private decimal? _originalChq_reg_mth_misc_amt_614;
		private decimal? _originalChq_reg_mth_misc_amt_615;
		private decimal? _originalChq_reg_mth_misc_amt_616;
		private decimal? _originalChq_reg_mth_misc_amt_617;
		private decimal? _originalChq_reg_mth_misc_amt_618;
		private decimal? _originalChq_reg_mth_misc_amt_71;
		private decimal? _originalChq_reg_mth_misc_amt_72;
		private decimal? _originalChq_reg_mth_misc_amt_73;
		private decimal? _originalChq_reg_mth_misc_amt_74;
		private decimal? _originalChq_reg_mth_misc_amt_75;
		private decimal? _originalChq_reg_mth_misc_amt_76;
		private decimal? _originalChq_reg_mth_misc_amt_77;
		private decimal? _originalChq_reg_mth_misc_amt_78;
		private decimal? _originalChq_reg_mth_misc_amt_79;
		private decimal? _originalChq_reg_mth_misc_amt_710;
		private decimal? _originalChq_reg_mth_misc_amt_711;
		private decimal? _originalChq_reg_mth_misc_amt_712;
		private decimal? _originalChq_reg_mth_misc_amt_713;
		private decimal? _originalChq_reg_mth_misc_amt_714;
		private decimal? _originalChq_reg_mth_misc_amt_715;
		private decimal? _originalChq_reg_mth_misc_amt_716;
		private decimal? _originalChq_reg_mth_misc_amt_717;
		private decimal? _originalChq_reg_mth_misc_amt_718;
		private decimal? _originalChq_reg_mth_misc_amt_81;
		private decimal? _originalChq_reg_mth_misc_amt_82;
		private decimal? _originalChq_reg_mth_misc_amt_83;
		private decimal? _originalChq_reg_mth_misc_amt_84;
		private decimal? _originalChq_reg_mth_misc_amt_85;
		private decimal? _originalChq_reg_mth_misc_amt_86;
		private decimal? _originalChq_reg_mth_misc_amt_87;
		private decimal? _originalChq_reg_mth_misc_amt_88;
		private decimal? _originalChq_reg_mth_misc_amt_89;
		private decimal? _originalChq_reg_mth_misc_amt_810;
		private decimal? _originalChq_reg_mth_misc_amt_811;
		private decimal? _originalChq_reg_mth_misc_amt_812;
		private decimal? _originalChq_reg_mth_misc_amt_813;
		private decimal? _originalChq_reg_mth_misc_amt_814;
		private decimal? _originalChq_reg_mth_misc_amt_815;
		private decimal? _originalChq_reg_mth_misc_amt_816;
		private decimal? _originalChq_reg_mth_misc_amt_817;
		private decimal? _originalChq_reg_mth_misc_amt_818;
		private decimal? _originalChq_reg_mth_misc_amt_91;
		private decimal? _originalChq_reg_mth_misc_amt_92;
		private decimal? _originalChq_reg_mth_misc_amt_93;
		private decimal? _originalChq_reg_mth_misc_amt_94;
		private decimal? _originalChq_reg_mth_misc_amt_95;
		private decimal? _originalChq_reg_mth_misc_amt_96;
		private decimal? _originalChq_reg_mth_misc_amt_97;
		private decimal? _originalChq_reg_mth_misc_amt_98;
		private decimal? _originalChq_reg_mth_misc_amt_99;
		private decimal? _originalChq_reg_mth_misc_amt_910;
		private decimal? _originalChq_reg_mth_misc_amt_911;
		private decimal? _originalChq_reg_mth_misc_amt_912;
		private decimal? _originalChq_reg_mth_misc_amt_913;
		private decimal? _originalChq_reg_mth_misc_amt_914;
		private decimal? _originalChq_reg_mth_misc_amt_915;
		private decimal? _originalChq_reg_mth_misc_amt_916;
		private decimal? _originalChq_reg_mth_misc_amt_917;
		private decimal? _originalChq_reg_mth_misc_amt_918;
		private decimal? _originalChq_reg_mth_misc_amt_101;
		private decimal? _originalChq_reg_mth_misc_amt_102;
		private decimal? _originalChq_reg_mth_misc_amt_103;
		private decimal? _originalChq_reg_mth_misc_amt_104;
		private decimal? _originalChq_reg_mth_misc_amt_105;
		private decimal? _originalChq_reg_mth_misc_amt_106;
		private decimal? _originalChq_reg_mth_misc_amt_107;
		private decimal? _originalChq_reg_mth_misc_amt_108;
		private decimal? _originalChq_reg_mth_misc_amt_109;
		private decimal? _originalChq_reg_mth_misc_amt_1010;
		private decimal? _originalChq_reg_mth_misc_amt_1011;
		private decimal? _originalChq_reg_mth_misc_amt_1012;
		private decimal? _originalChq_reg_mth_misc_amt_1013;
		private decimal? _originalChq_reg_mth_misc_amt_1014;
		private decimal? _originalChq_reg_mth_misc_amt_1015;
		private decimal? _originalChq_reg_mth_misc_amt_1016;
		private decimal? _originalChq_reg_mth_misc_amt_1017;
		private decimal? _originalChq_reg_mth_misc_amt_1018;
		private decimal? _originalChq_reg_mth_exp_amt1;
		private decimal? _originalChq_reg_mth_exp_amt2;
		private decimal? _originalChq_reg_mth_exp_amt3;
		private decimal? _originalChq_reg_mth_exp_amt4;
		private decimal? _originalChq_reg_mth_exp_amt5;
		private decimal? _originalChq_reg_mth_exp_amt6;
		private decimal? _originalChq_reg_mth_exp_amt7;
		private decimal? _originalChq_reg_mth_exp_amt8;
		private decimal? _originalChq_reg_mth_exp_amt9;
		private decimal? _originalChq_reg_mth_exp_amt10;
		private decimal? _originalChq_reg_mth_exp_amt11;
		private decimal? _originalChq_reg_mth_exp_amt12;
		private decimal? _originalChq_reg_mth_exp_amt13;
		private decimal? _originalChq_reg_mth_exp_amt14;
		private decimal? _originalChq_reg_mth_exp_amt15;
		private decimal? _originalChq_reg_mth_exp_amt16;
		private decimal? _originalChq_reg_mth_exp_amt17;
		private decimal? _originalChq_reg_mth_exp_amt18;
		private decimal? _originalChq_reg_comp_ann_exp_this_pay1;
		private decimal? _originalChq_reg_comp_ann_exp_this_pay2;
		private decimal? _originalChq_reg_comp_ann_exp_this_pay3;
		private decimal? _originalChq_reg_comp_ann_exp_this_pay4;
		private decimal? _originalChq_reg_comp_ann_exp_this_pay5;
		private decimal? _originalChq_reg_comp_ann_exp_this_pay6;
		private decimal? _originalChq_reg_comp_ann_exp_this_pay7;
		private decimal? _originalChq_reg_comp_ann_exp_this_pay8;
		private decimal? _originalChq_reg_comp_ann_exp_this_pay9;
		private decimal? _originalChq_reg_comp_ann_exp_this_pay10;
		private decimal? _originalChq_reg_comp_ann_exp_this_pay11;
		private decimal? _originalChq_reg_comp_ann_exp_this_pay12;
		private decimal? _originalChq_reg_comp_ann_exp_this_pay13;
		private decimal? _originalChq_reg_comp_ann_exp_this_pay14;
		private decimal? _originalChq_reg_comp_ann_exp_this_pay15;
		private decimal? _originalChq_reg_comp_ann_exp_this_pay16;
		private decimal? _originalChq_reg_comp_ann_exp_this_pay17;
		private decimal? _originalChq_reg_comp_ann_exp_this_pay18;
		private decimal? _originalChq_reg_mth_ceil_amt1;
		private decimal? _originalChq_reg_mth_ceil_amt2;
		private decimal? _originalChq_reg_mth_ceil_amt3;
		private decimal? _originalChq_reg_mth_ceil_amt4;
		private decimal? _originalChq_reg_mth_ceil_amt5;
		private decimal? _originalChq_reg_mth_ceil_amt6;
		private decimal? _originalChq_reg_mth_ceil_amt7;
		private decimal? _originalChq_reg_mth_ceil_amt8;
		private decimal? _originalChq_reg_mth_ceil_amt9;
		private decimal? _originalChq_reg_mth_ceil_amt10;
		private decimal? _originalChq_reg_mth_ceil_amt11;
		private decimal? _originalChq_reg_mth_ceil_amt12;
		private decimal? _originalChq_reg_mth_ceil_amt13;
		private decimal? _originalChq_reg_mth_ceil_amt14;
		private decimal? _originalChq_reg_mth_ceil_amt15;
		private decimal? _originalChq_reg_mth_ceil_amt16;
		private decimal? _originalChq_reg_mth_ceil_amt17;
		private decimal? _originalChq_reg_mth_ceil_amt18;
		private decimal? _originalChq_reg_comp_ann_ceil_this_pay1;
		private decimal? _originalChq_reg_comp_ann_ceil_this_pay2;
		private decimal? _originalChq_reg_comp_ann_ceil_this_pay3;
		private decimal? _originalChq_reg_comp_ann_ceil_this_pay4;
		private decimal? _originalChq_reg_comp_ann_ceil_this_pay5;
		private decimal? _originalChq_reg_comp_ann_ceil_this_pay6;
		private decimal? _originalChq_reg_comp_ann_ceil_this_pay7;
		private decimal? _originalChq_reg_comp_ann_ceil_this_pay8;
		private decimal? _originalChq_reg_comp_ann_ceil_this_pay9;
		private decimal? _originalChq_reg_comp_ann_ceil_this_pay10;
		private decimal? _originalChq_reg_comp_ann_ceil_this_pay11;
		private decimal? _originalChq_reg_comp_ann_ceil_this_pay12;
		private decimal? _originalChq_reg_comp_ann_ceil_this_pay13;
		private decimal? _originalChq_reg_comp_ann_ceil_this_pay14;
		private decimal? _originalChq_reg_comp_ann_ceil_this_pay15;
		private decimal? _originalChq_reg_comp_ann_ceil_this_pay16;
		private decimal? _originalChq_reg_comp_ann_ceil_this_pay17;
		private decimal? _originalChq_reg_comp_ann_ceil_this_pay18;
		private decimal? _originalChq_reg_earnings_this_mth1;
		private decimal? _originalChq_reg_earnings_this_mth2;
		private decimal? _originalChq_reg_earnings_this_mth3;
		private decimal? _originalChq_reg_earnings_this_mth4;
		private decimal? _originalChq_reg_earnings_this_mth5;
		private decimal? _originalChq_reg_earnings_this_mth6;
		private decimal? _originalChq_reg_earnings_this_mth7;
		private decimal? _originalChq_reg_earnings_this_mth8;
		private decimal? _originalChq_reg_earnings_this_mth9;
		private decimal? _originalChq_reg_earnings_this_mth10;
		private decimal? _originalChq_reg_earnings_this_mth11;
		private decimal? _originalChq_reg_earnings_this_mth12;
		private decimal? _originalChq_reg_earnings_this_mth13;
		private decimal? _originalChq_reg_earnings_this_mth14;
		private decimal? _originalChq_reg_earnings_this_mth15;
		private decimal? _originalChq_reg_earnings_this_mth16;
		private decimal? _originalChq_reg_earnings_this_mth17;
		private decimal? _originalChq_reg_earnings_this_mth18;
		private decimal? _originalChq_reg_regular_pay_this_mth1;
		private decimal? _originalChq_reg_regular_pay_this_mth2;
		private decimal? _originalChq_reg_regular_pay_this_mth3;
		private decimal? _originalChq_reg_regular_pay_this_mth4;
		private decimal? _originalChq_reg_regular_pay_this_mth5;
		private decimal? _originalChq_reg_regular_pay_this_mth6;
		private decimal? _originalChq_reg_regular_pay_this_mth7;
		private decimal? _originalChq_reg_regular_pay_this_mth8;
		private decimal? _originalChq_reg_regular_pay_this_mth9;
		private decimal? _originalChq_reg_regular_pay_this_mth10;
		private decimal? _originalChq_reg_regular_pay_this_mth11;
		private decimal? _originalChq_reg_regular_pay_this_mth12;
		private decimal? _originalChq_reg_regular_pay_this_mth13;
		private decimal? _originalChq_reg_regular_pay_this_mth14;
		private decimal? _originalChq_reg_regular_pay_this_mth15;
		private decimal? _originalChq_reg_regular_pay_this_mth16;
		private decimal? _originalChq_reg_regular_pay_this_mth17;
		private decimal? _originalChq_reg_regular_pay_this_mth18;
		private decimal? _originalChq_reg_regular_tax_this_mth1;
		private decimal? _originalChq_reg_regular_tax_this_mth2;
		private decimal? _originalChq_reg_regular_tax_this_mth3;
		private decimal? _originalChq_reg_regular_tax_this_mth4;
		private decimal? _originalChq_reg_regular_tax_this_mth5;
		private decimal? _originalChq_reg_regular_tax_this_mth6;
		private decimal? _originalChq_reg_regular_tax_this_mth7;
		private decimal? _originalChq_reg_regular_tax_this_mth8;
		private decimal? _originalChq_reg_regular_tax_this_mth9;
		private decimal? _originalChq_reg_regular_tax_this_mth10;
		private decimal? _originalChq_reg_regular_tax_this_mth11;
		private decimal? _originalChq_reg_regular_tax_this_mth12;
		private decimal? _originalChq_reg_regular_tax_this_mth13;
		private decimal? _originalChq_reg_regular_tax_this_mth14;
		private decimal? _originalChq_reg_regular_tax_this_mth15;
		private decimal? _originalChq_reg_regular_tax_this_mth16;
		private decimal? _originalChq_reg_regular_tax_this_mth17;
		private decimal? _originalChq_reg_regular_tax_this_mth18;
		private decimal? _originalChq_reg_man_pay_this_mth1;
		private decimal? _originalChq_reg_man_pay_this_mth2;
		private decimal? _originalChq_reg_man_pay_this_mth3;
		private decimal? _originalChq_reg_man_pay_this_mth4;
		private decimal? _originalChq_reg_man_pay_this_mth5;
		private decimal? _originalChq_reg_man_pay_this_mth6;
		private decimal? _originalChq_reg_man_pay_this_mth7;
		private decimal? _originalChq_reg_man_pay_this_mth8;
		private decimal? _originalChq_reg_man_pay_this_mth9;
		private decimal? _originalChq_reg_man_pay_this_mth10;
		private decimal? _originalChq_reg_man_pay_this_mth11;
		private decimal? _originalChq_reg_man_pay_this_mth12;
		private decimal? _originalChq_reg_man_pay_this_mth13;
		private decimal? _originalChq_reg_man_pay_this_mth14;
		private decimal? _originalChq_reg_man_pay_this_mth15;
		private decimal? _originalChq_reg_man_pay_this_mth16;
		private decimal? _originalChq_reg_man_pay_this_mth17;
		private decimal? _originalChq_reg_man_pay_this_mth18;
		private decimal? _originalChq_reg_man_tax_this_mth1;
		private decimal? _originalChq_reg_man_tax_this_mth2;
		private decimal? _originalChq_reg_man_tax_this_mth3;
		private decimal? _originalChq_reg_man_tax_this_mth4;
		private decimal? _originalChq_reg_man_tax_this_mth5;
		private decimal? _originalChq_reg_man_tax_this_mth6;
		private decimal? _originalChq_reg_man_tax_this_mth7;
		private decimal? _originalChq_reg_man_tax_this_mth8;
		private decimal? _originalChq_reg_man_tax_this_mth9;
		private decimal? _originalChq_reg_man_tax_this_mth10;
		private decimal? _originalChq_reg_man_tax_this_mth11;
		private decimal? _originalChq_reg_man_tax_this_mth12;
		private decimal? _originalChq_reg_man_tax_this_mth13;
		private decimal? _originalChq_reg_man_tax_this_mth14;
		private decimal? _originalChq_reg_man_tax_this_mth15;
		private decimal? _originalChq_reg_man_tax_this_mth16;
		private decimal? _originalChq_reg_man_tax_this_mth17;
		private decimal? _originalChq_reg_man_tax_this_mth18;
		private decimal? _originalChq_reg_pay_date1;
		private decimal? _originalChq_reg_pay_date2;
		private decimal? _originalChq_reg_pay_date3;
		private decimal? _originalChq_reg_pay_date4;
		private decimal? _originalChq_reg_pay_date5;
		private decimal? _originalChq_reg_pay_date6;
		private decimal? _originalChq_reg_pay_date7;
		private decimal? _originalChq_reg_pay_date8;
		private decimal? _originalChq_reg_pay_date9;
		private decimal? _originalChq_reg_pay_date10;
		private decimal? _originalChq_reg_pay_date11;
		private decimal? _originalChq_reg_pay_date12;
		private decimal? _originalChq_reg_pay_date13;
		private decimal? _originalChq_reg_pay_date14;
		private decimal? _originalChq_reg_pay_date15;
		private decimal? _originalChq_reg_pay_date16;
		private decimal? _originalChq_reg_pay_date17;
		private decimal? _originalChq_reg_pay_date18;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			CHQ_REG_CLINIC_NBR_1_2 = _originalChq_reg_clinic_nbr_1_2;
			CHQ_REG_DEPT = _originalChq_reg_dept;
			CHQ_REG_DOC_NBR = _originalChq_reg_doc_nbr;
			CHQ_REG_PERC_BILL1 = _originalChq_reg_perc_bill1;
			CHQ_REG_PERC_BILL2 = _originalChq_reg_perc_bill2;
			CHQ_REG_PERC_BILL3 = _originalChq_reg_perc_bill3;
			CHQ_REG_PERC_BILL4 = _originalChq_reg_perc_bill4;
			CHQ_REG_PERC_BILL5 = _originalChq_reg_perc_bill5;
			CHQ_REG_PERC_BILL6 = _originalChq_reg_perc_bill6;
			CHQ_REG_PERC_BILL7 = _originalChq_reg_perc_bill7;
			CHQ_REG_PERC_BILL8 = _originalChq_reg_perc_bill8;
			CHQ_REG_PERC_BILL9 = _originalChq_reg_perc_bill9;
			CHQ_REG_PERC_BILL10 = _originalChq_reg_perc_bill10;
			CHQ_REG_PERC_BILL11 = _originalChq_reg_perc_bill11;
			CHQ_REG_PERC_BILL12 = _originalChq_reg_perc_bill12;
			CHQ_REG_PERC_BILL13 = _originalChq_reg_perc_bill13;
			CHQ_REG_PERC_BILL14 = _originalChq_reg_perc_bill14;
			CHQ_REG_PERC_BILL15 = _originalChq_reg_perc_bill15;
			CHQ_REG_PERC_BILL16 = _originalChq_reg_perc_bill16;
			CHQ_REG_PERC_BILL17 = _originalChq_reg_perc_bill17;
			CHQ_REG_PERC_BILL18 = _originalChq_reg_perc_bill18;
			CHQ_REG_PERC_MISC1 = _originalChq_reg_perc_misc1;
			CHQ_REG_PERC_MISC2 = _originalChq_reg_perc_misc2;
			CHQ_REG_PERC_MISC3 = _originalChq_reg_perc_misc3;
			CHQ_REG_PERC_MISC4 = _originalChq_reg_perc_misc4;
			CHQ_REG_PERC_MISC5 = _originalChq_reg_perc_misc5;
			CHQ_REG_PERC_MISC6 = _originalChq_reg_perc_misc6;
			CHQ_REG_PERC_MISC7 = _originalChq_reg_perc_misc7;
			CHQ_REG_PERC_MISC8 = _originalChq_reg_perc_misc8;
			CHQ_REG_PERC_MISC9 = _originalChq_reg_perc_misc9;
			CHQ_REG_PERC_MISC10 = _originalChq_reg_perc_misc10;
			CHQ_REG_PERC_MISC11 = _originalChq_reg_perc_misc11;
			CHQ_REG_PERC_MISC12 = _originalChq_reg_perc_misc12;
			CHQ_REG_PERC_MISC13 = _originalChq_reg_perc_misc13;
			CHQ_REG_PERC_MISC14 = _originalChq_reg_perc_misc14;
			CHQ_REG_PERC_MISC15 = _originalChq_reg_perc_misc15;
			CHQ_REG_PERC_MISC16 = _originalChq_reg_perc_misc16;
			CHQ_REG_PERC_MISC17 = _originalChq_reg_perc_misc17;
			CHQ_REG_PERC_MISC18 = _originalChq_reg_perc_misc18;
			CHQ_REG_PAY_CODE1 = _originalChq_reg_pay_code1;
			CHQ_REG_PAY_CODE2 = _originalChq_reg_pay_code2;
			CHQ_REG_PAY_CODE3 = _originalChq_reg_pay_code3;
			CHQ_REG_PAY_CODE4 = _originalChq_reg_pay_code4;
			CHQ_REG_PAY_CODE5 = _originalChq_reg_pay_code5;
			CHQ_REG_PAY_CODE6 = _originalChq_reg_pay_code6;
			CHQ_REG_PAY_CODE7 = _originalChq_reg_pay_code7;
			CHQ_REG_PAY_CODE8 = _originalChq_reg_pay_code8;
			CHQ_REG_PAY_CODE9 = _originalChq_reg_pay_code9;
			CHQ_REG_PAY_CODE10 = _originalChq_reg_pay_code10;
			CHQ_REG_PAY_CODE11 = _originalChq_reg_pay_code11;
			CHQ_REG_PAY_CODE12 = _originalChq_reg_pay_code12;
			CHQ_REG_PAY_CODE13 = _originalChq_reg_pay_code13;
			CHQ_REG_PAY_CODE14 = _originalChq_reg_pay_code14;
			CHQ_REG_PAY_CODE15 = _originalChq_reg_pay_code15;
			CHQ_REG_PAY_CODE16 = _originalChq_reg_pay_code16;
			CHQ_REG_PAY_CODE17 = _originalChq_reg_pay_code17;
			CHQ_REG_PAY_CODE18 = _originalChq_reg_pay_code18;
			CHQ_REG_PERC_TAX1 = _originalChq_reg_perc_tax1;
			CHQ_REG_PERC_TAX2 = _originalChq_reg_perc_tax2;
			CHQ_REG_PERC_TAX3 = _originalChq_reg_perc_tax3;
			CHQ_REG_PERC_TAX4 = _originalChq_reg_perc_tax4;
			CHQ_REG_PERC_TAX5 = _originalChq_reg_perc_tax5;
			CHQ_REG_PERC_TAX6 = _originalChq_reg_perc_tax6;
			CHQ_REG_PERC_TAX7 = _originalChq_reg_perc_tax7;
			CHQ_REG_PERC_TAX8 = _originalChq_reg_perc_tax8;
			CHQ_REG_PERC_TAX9 = _originalChq_reg_perc_tax9;
			CHQ_REG_PERC_TAX10 = _originalChq_reg_perc_tax10;
			CHQ_REG_PERC_TAX11 = _originalChq_reg_perc_tax11;
			CHQ_REG_PERC_TAX12 = _originalChq_reg_perc_tax12;
			CHQ_REG_PERC_TAX13 = _originalChq_reg_perc_tax13;
			CHQ_REG_PERC_TAX14 = _originalChq_reg_perc_tax14;
			CHQ_REG_PERC_TAX15 = _originalChq_reg_perc_tax15;
			CHQ_REG_PERC_TAX16 = _originalChq_reg_perc_tax16;
			CHQ_REG_PERC_TAX17 = _originalChq_reg_perc_tax17;
			CHQ_REG_PERC_TAX18 = _originalChq_reg_perc_tax18;
			CHQ_REG_MTH_BILL_AMT1 = _originalChq_reg_mth_bill_amt1;
			CHQ_REG_MTH_BILL_AMT2 = _originalChq_reg_mth_bill_amt2;
			CHQ_REG_MTH_BILL_AMT3 = _originalChq_reg_mth_bill_amt3;
			CHQ_REG_MTH_BILL_AMT4 = _originalChq_reg_mth_bill_amt4;
			CHQ_REG_MTH_BILL_AMT5 = _originalChq_reg_mth_bill_amt5;
			CHQ_REG_MTH_BILL_AMT6 = _originalChq_reg_mth_bill_amt6;
			CHQ_REG_MTH_BILL_AMT7 = _originalChq_reg_mth_bill_amt7;
			CHQ_REG_MTH_BILL_AMT8 = _originalChq_reg_mth_bill_amt8;
			CHQ_REG_MTH_BILL_AMT9 = _originalChq_reg_mth_bill_amt9;
			CHQ_REG_MTH_BILL_AMT10 = _originalChq_reg_mth_bill_amt10;
			CHQ_REG_MTH_BILL_AMT11 = _originalChq_reg_mth_bill_amt11;
			CHQ_REG_MTH_BILL_AMT12 = _originalChq_reg_mth_bill_amt12;
			CHQ_REG_MTH_BILL_AMT13 = _originalChq_reg_mth_bill_amt13;
			CHQ_REG_MTH_BILL_AMT14 = _originalChq_reg_mth_bill_amt14;
			CHQ_REG_MTH_BILL_AMT15 = _originalChq_reg_mth_bill_amt15;
			CHQ_REG_MTH_BILL_AMT16 = _originalChq_reg_mth_bill_amt16;
			CHQ_REG_MTH_BILL_AMT17 = _originalChq_reg_mth_bill_amt17;
			CHQ_REG_MTH_BILL_AMT18 = _originalChq_reg_mth_bill_amt18;
			CHQ_REG_MTH_MISC_AMT_11 = _originalChq_reg_mth_misc_amt_11;
			CHQ_REG_MTH_MISC_AMT_12 = _originalChq_reg_mth_misc_amt_12;
			CHQ_REG_MTH_MISC_AMT_13 = _originalChq_reg_mth_misc_amt_13;
			CHQ_REG_MTH_MISC_AMT_14 = _originalChq_reg_mth_misc_amt_14;
			CHQ_REG_MTH_MISC_AMT_15 = _originalChq_reg_mth_misc_amt_15;
			CHQ_REG_MTH_MISC_AMT_16 = _originalChq_reg_mth_misc_amt_16;
			CHQ_REG_MTH_MISC_AMT_17 = _originalChq_reg_mth_misc_amt_17;
			CHQ_REG_MTH_MISC_AMT_18 = _originalChq_reg_mth_misc_amt_18;
			CHQ_REG_MTH_MISC_AMT_19 = _originalChq_reg_mth_misc_amt_19;
			CHQ_REG_MTH_MISC_AMT_110 = _originalChq_reg_mth_misc_amt_110;
			CHQ_REG_MTH_MISC_AMT_111 = _originalChq_reg_mth_misc_amt_111;
			CHQ_REG_MTH_MISC_AMT_112 = _originalChq_reg_mth_misc_amt_112;
			CHQ_REG_MTH_MISC_AMT_113 = _originalChq_reg_mth_misc_amt_113;
			CHQ_REG_MTH_MISC_AMT_114 = _originalChq_reg_mth_misc_amt_114;
			CHQ_REG_MTH_MISC_AMT_115 = _originalChq_reg_mth_misc_amt_115;
			CHQ_REG_MTH_MISC_AMT_116 = _originalChq_reg_mth_misc_amt_116;
			CHQ_REG_MTH_MISC_AMT_117 = _originalChq_reg_mth_misc_amt_117;
			CHQ_REG_MTH_MISC_AMT_118 = _originalChq_reg_mth_misc_amt_118;
			CHQ_REG_MTH_MISC_AMT_21 = _originalChq_reg_mth_misc_amt_21;
			CHQ_REG_MTH_MISC_AMT_22 = _originalChq_reg_mth_misc_amt_22;
			CHQ_REG_MTH_MISC_AMT_23 = _originalChq_reg_mth_misc_amt_23;
			CHQ_REG_MTH_MISC_AMT_24 = _originalChq_reg_mth_misc_amt_24;
			CHQ_REG_MTH_MISC_AMT_25 = _originalChq_reg_mth_misc_amt_25;
			CHQ_REG_MTH_MISC_AMT_26 = _originalChq_reg_mth_misc_amt_26;
			CHQ_REG_MTH_MISC_AMT_27 = _originalChq_reg_mth_misc_amt_27;
			CHQ_REG_MTH_MISC_AMT_28 = _originalChq_reg_mth_misc_amt_28;
			CHQ_REG_MTH_MISC_AMT_29 = _originalChq_reg_mth_misc_amt_29;
			CHQ_REG_MTH_MISC_AMT_210 = _originalChq_reg_mth_misc_amt_210;
			CHQ_REG_MTH_MISC_AMT_211 = _originalChq_reg_mth_misc_amt_211;
			CHQ_REG_MTH_MISC_AMT_212 = _originalChq_reg_mth_misc_amt_212;
			CHQ_REG_MTH_MISC_AMT_213 = _originalChq_reg_mth_misc_amt_213;
			CHQ_REG_MTH_MISC_AMT_214 = _originalChq_reg_mth_misc_amt_214;
			CHQ_REG_MTH_MISC_AMT_215 = _originalChq_reg_mth_misc_amt_215;
			CHQ_REG_MTH_MISC_AMT_216 = _originalChq_reg_mth_misc_amt_216;
			CHQ_REG_MTH_MISC_AMT_217 = _originalChq_reg_mth_misc_amt_217;
			CHQ_REG_MTH_MISC_AMT_218 = _originalChq_reg_mth_misc_amt_218;
			CHQ_REG_MTH_MISC_AMT_31 = _originalChq_reg_mth_misc_amt_31;
			CHQ_REG_MTH_MISC_AMT_32 = _originalChq_reg_mth_misc_amt_32;
			CHQ_REG_MTH_MISC_AMT_33 = _originalChq_reg_mth_misc_amt_33;
			CHQ_REG_MTH_MISC_AMT_34 = _originalChq_reg_mth_misc_amt_34;
			CHQ_REG_MTH_MISC_AMT_35 = _originalChq_reg_mth_misc_amt_35;
			CHQ_REG_MTH_MISC_AMT_36 = _originalChq_reg_mth_misc_amt_36;
			CHQ_REG_MTH_MISC_AMT_37 = _originalChq_reg_mth_misc_amt_37;
			CHQ_REG_MTH_MISC_AMT_38 = _originalChq_reg_mth_misc_amt_38;
			CHQ_REG_MTH_MISC_AMT_39 = _originalChq_reg_mth_misc_amt_39;
			CHQ_REG_MTH_MISC_AMT_310 = _originalChq_reg_mth_misc_amt_310;
			CHQ_REG_MTH_MISC_AMT_311 = _originalChq_reg_mth_misc_amt_311;
			CHQ_REG_MTH_MISC_AMT_312 = _originalChq_reg_mth_misc_amt_312;
			CHQ_REG_MTH_MISC_AMT_313 = _originalChq_reg_mth_misc_amt_313;
			CHQ_REG_MTH_MISC_AMT_314 = _originalChq_reg_mth_misc_amt_314;
			CHQ_REG_MTH_MISC_AMT_315 = _originalChq_reg_mth_misc_amt_315;
			CHQ_REG_MTH_MISC_AMT_316 = _originalChq_reg_mth_misc_amt_316;
			CHQ_REG_MTH_MISC_AMT_317 = _originalChq_reg_mth_misc_amt_317;
			CHQ_REG_MTH_MISC_AMT_318 = _originalChq_reg_mth_misc_amt_318;
			CHQ_REG_MTH_MISC_AMT_41 = _originalChq_reg_mth_misc_amt_41;
			CHQ_REG_MTH_MISC_AMT_42 = _originalChq_reg_mth_misc_amt_42;
			CHQ_REG_MTH_MISC_AMT_43 = _originalChq_reg_mth_misc_amt_43;
			CHQ_REG_MTH_MISC_AMT_44 = _originalChq_reg_mth_misc_amt_44;
			CHQ_REG_MTH_MISC_AMT_45 = _originalChq_reg_mth_misc_amt_45;
			CHQ_REG_MTH_MISC_AMT_46 = _originalChq_reg_mth_misc_amt_46;
			CHQ_REG_MTH_MISC_AMT_47 = _originalChq_reg_mth_misc_amt_47;
			CHQ_REG_MTH_MISC_AMT_48 = _originalChq_reg_mth_misc_amt_48;
			CHQ_REG_MTH_MISC_AMT_49 = _originalChq_reg_mth_misc_amt_49;
			CHQ_REG_MTH_MISC_AMT_410 = _originalChq_reg_mth_misc_amt_410;
			CHQ_REG_MTH_MISC_AMT_411 = _originalChq_reg_mth_misc_amt_411;
			CHQ_REG_MTH_MISC_AMT_412 = _originalChq_reg_mth_misc_amt_412;
			CHQ_REG_MTH_MISC_AMT_413 = _originalChq_reg_mth_misc_amt_413;
			CHQ_REG_MTH_MISC_AMT_414 = _originalChq_reg_mth_misc_amt_414;
			CHQ_REG_MTH_MISC_AMT_415 = _originalChq_reg_mth_misc_amt_415;
			CHQ_REG_MTH_MISC_AMT_416 = _originalChq_reg_mth_misc_amt_416;
			CHQ_REG_MTH_MISC_AMT_417 = _originalChq_reg_mth_misc_amt_417;
			CHQ_REG_MTH_MISC_AMT_418 = _originalChq_reg_mth_misc_amt_418;
			CHQ_REG_MTH_MISC_AMT_51 = _originalChq_reg_mth_misc_amt_51;
			CHQ_REG_MTH_MISC_AMT_52 = _originalChq_reg_mth_misc_amt_52;
			CHQ_REG_MTH_MISC_AMT_53 = _originalChq_reg_mth_misc_amt_53;
			CHQ_REG_MTH_MISC_AMT_54 = _originalChq_reg_mth_misc_amt_54;
			CHQ_REG_MTH_MISC_AMT_55 = _originalChq_reg_mth_misc_amt_55;
			CHQ_REG_MTH_MISC_AMT_56 = _originalChq_reg_mth_misc_amt_56;
			CHQ_REG_MTH_MISC_AMT_57 = _originalChq_reg_mth_misc_amt_57;
			CHQ_REG_MTH_MISC_AMT_58 = _originalChq_reg_mth_misc_amt_58;
			CHQ_REG_MTH_MISC_AMT_59 = _originalChq_reg_mth_misc_amt_59;
			CHQ_REG_MTH_MISC_AMT_510 = _originalChq_reg_mth_misc_amt_510;
			CHQ_REG_MTH_MISC_AMT_511 = _originalChq_reg_mth_misc_amt_511;
			CHQ_REG_MTH_MISC_AMT_512 = _originalChq_reg_mth_misc_amt_512;
			CHQ_REG_MTH_MISC_AMT_513 = _originalChq_reg_mth_misc_amt_513;
			CHQ_REG_MTH_MISC_AMT_514 = _originalChq_reg_mth_misc_amt_514;
			CHQ_REG_MTH_MISC_AMT_515 = _originalChq_reg_mth_misc_amt_515;
			CHQ_REG_MTH_MISC_AMT_516 = _originalChq_reg_mth_misc_amt_516;
			CHQ_REG_MTH_MISC_AMT_517 = _originalChq_reg_mth_misc_amt_517;
			CHQ_REG_MTH_MISC_AMT_518 = _originalChq_reg_mth_misc_amt_518;
			CHQ_REG_MTH_MISC_AMT_61 = _originalChq_reg_mth_misc_amt_61;
			CHQ_REG_MTH_MISC_AMT_62 = _originalChq_reg_mth_misc_amt_62;
			CHQ_REG_MTH_MISC_AMT_63 = _originalChq_reg_mth_misc_amt_63;
			CHQ_REG_MTH_MISC_AMT_64 = _originalChq_reg_mth_misc_amt_64;
			CHQ_REG_MTH_MISC_AMT_65 = _originalChq_reg_mth_misc_amt_65;
			CHQ_REG_MTH_MISC_AMT_66 = _originalChq_reg_mth_misc_amt_66;
			CHQ_REG_MTH_MISC_AMT_67 = _originalChq_reg_mth_misc_amt_67;
			CHQ_REG_MTH_MISC_AMT_68 = _originalChq_reg_mth_misc_amt_68;
			CHQ_REG_MTH_MISC_AMT_69 = _originalChq_reg_mth_misc_amt_69;
			CHQ_REG_MTH_MISC_AMT_610 = _originalChq_reg_mth_misc_amt_610;
			CHQ_REG_MTH_MISC_AMT_611 = _originalChq_reg_mth_misc_amt_611;
			CHQ_REG_MTH_MISC_AMT_612 = _originalChq_reg_mth_misc_amt_612;
			CHQ_REG_MTH_MISC_AMT_613 = _originalChq_reg_mth_misc_amt_613;
			CHQ_REG_MTH_MISC_AMT_614 = _originalChq_reg_mth_misc_amt_614;
			CHQ_REG_MTH_MISC_AMT_615 = _originalChq_reg_mth_misc_amt_615;
			CHQ_REG_MTH_MISC_AMT_616 = _originalChq_reg_mth_misc_amt_616;
			CHQ_REG_MTH_MISC_AMT_617 = _originalChq_reg_mth_misc_amt_617;
			CHQ_REG_MTH_MISC_AMT_618 = _originalChq_reg_mth_misc_amt_618;
			CHQ_REG_MTH_MISC_AMT_71 = _originalChq_reg_mth_misc_amt_71;
			CHQ_REG_MTH_MISC_AMT_72 = _originalChq_reg_mth_misc_amt_72;
			CHQ_REG_MTH_MISC_AMT_73 = _originalChq_reg_mth_misc_amt_73;
			CHQ_REG_MTH_MISC_AMT_74 = _originalChq_reg_mth_misc_amt_74;
			CHQ_REG_MTH_MISC_AMT_75 = _originalChq_reg_mth_misc_amt_75;
			CHQ_REG_MTH_MISC_AMT_76 = _originalChq_reg_mth_misc_amt_76;
			CHQ_REG_MTH_MISC_AMT_77 = _originalChq_reg_mth_misc_amt_77;
			CHQ_REG_MTH_MISC_AMT_78 = _originalChq_reg_mth_misc_amt_78;
			CHQ_REG_MTH_MISC_AMT_79 = _originalChq_reg_mth_misc_amt_79;
			CHQ_REG_MTH_MISC_AMT_710 = _originalChq_reg_mth_misc_amt_710;
			CHQ_REG_MTH_MISC_AMT_711 = _originalChq_reg_mth_misc_amt_711;
			CHQ_REG_MTH_MISC_AMT_712 = _originalChq_reg_mth_misc_amt_712;
			CHQ_REG_MTH_MISC_AMT_713 = _originalChq_reg_mth_misc_amt_713;
			CHQ_REG_MTH_MISC_AMT_714 = _originalChq_reg_mth_misc_amt_714;
			CHQ_REG_MTH_MISC_AMT_715 = _originalChq_reg_mth_misc_amt_715;
			CHQ_REG_MTH_MISC_AMT_716 = _originalChq_reg_mth_misc_amt_716;
			CHQ_REG_MTH_MISC_AMT_717 = _originalChq_reg_mth_misc_amt_717;
			CHQ_REG_MTH_MISC_AMT_718 = _originalChq_reg_mth_misc_amt_718;
			CHQ_REG_MTH_MISC_AMT_81 = _originalChq_reg_mth_misc_amt_81;
			CHQ_REG_MTH_MISC_AMT_82 = _originalChq_reg_mth_misc_amt_82;
			CHQ_REG_MTH_MISC_AMT_83 = _originalChq_reg_mth_misc_amt_83;
			CHQ_REG_MTH_MISC_AMT_84 = _originalChq_reg_mth_misc_amt_84;
			CHQ_REG_MTH_MISC_AMT_85 = _originalChq_reg_mth_misc_amt_85;
			CHQ_REG_MTH_MISC_AMT_86 = _originalChq_reg_mth_misc_amt_86;
			CHQ_REG_MTH_MISC_AMT_87 = _originalChq_reg_mth_misc_amt_87;
			CHQ_REG_MTH_MISC_AMT_88 = _originalChq_reg_mth_misc_amt_88;
			CHQ_REG_MTH_MISC_AMT_89 = _originalChq_reg_mth_misc_amt_89;
			CHQ_REG_MTH_MISC_AMT_810 = _originalChq_reg_mth_misc_amt_810;
			CHQ_REG_MTH_MISC_AMT_811 = _originalChq_reg_mth_misc_amt_811;
			CHQ_REG_MTH_MISC_AMT_812 = _originalChq_reg_mth_misc_amt_812;
			CHQ_REG_MTH_MISC_AMT_813 = _originalChq_reg_mth_misc_amt_813;
			CHQ_REG_MTH_MISC_AMT_814 = _originalChq_reg_mth_misc_amt_814;
			CHQ_REG_MTH_MISC_AMT_815 = _originalChq_reg_mth_misc_amt_815;
			CHQ_REG_MTH_MISC_AMT_816 = _originalChq_reg_mth_misc_amt_816;
			CHQ_REG_MTH_MISC_AMT_817 = _originalChq_reg_mth_misc_amt_817;
			CHQ_REG_MTH_MISC_AMT_818 = _originalChq_reg_mth_misc_amt_818;
			CHQ_REG_MTH_MISC_AMT_91 = _originalChq_reg_mth_misc_amt_91;
			CHQ_REG_MTH_MISC_AMT_92 = _originalChq_reg_mth_misc_amt_92;
			CHQ_REG_MTH_MISC_AMT_93 = _originalChq_reg_mth_misc_amt_93;
			CHQ_REG_MTH_MISC_AMT_94 = _originalChq_reg_mth_misc_amt_94;
			CHQ_REG_MTH_MISC_AMT_95 = _originalChq_reg_mth_misc_amt_95;
			CHQ_REG_MTH_MISC_AMT_96 = _originalChq_reg_mth_misc_amt_96;
			CHQ_REG_MTH_MISC_AMT_97 = _originalChq_reg_mth_misc_amt_97;
			CHQ_REG_MTH_MISC_AMT_98 = _originalChq_reg_mth_misc_amt_98;
			CHQ_REG_MTH_MISC_AMT_99 = _originalChq_reg_mth_misc_amt_99;
			CHQ_REG_MTH_MISC_AMT_910 = _originalChq_reg_mth_misc_amt_910;
			CHQ_REG_MTH_MISC_AMT_911 = _originalChq_reg_mth_misc_amt_911;
			CHQ_REG_MTH_MISC_AMT_912 = _originalChq_reg_mth_misc_amt_912;
			CHQ_REG_MTH_MISC_AMT_913 = _originalChq_reg_mth_misc_amt_913;
			CHQ_REG_MTH_MISC_AMT_914 = _originalChq_reg_mth_misc_amt_914;
			CHQ_REG_MTH_MISC_AMT_915 = _originalChq_reg_mth_misc_amt_915;
			CHQ_REG_MTH_MISC_AMT_916 = _originalChq_reg_mth_misc_amt_916;
			CHQ_REG_MTH_MISC_AMT_917 = _originalChq_reg_mth_misc_amt_917;
			CHQ_REG_MTH_MISC_AMT_918 = _originalChq_reg_mth_misc_amt_918;
			CHQ_REG_MTH_MISC_AMT_101 = _originalChq_reg_mth_misc_amt_101;
			CHQ_REG_MTH_MISC_AMT_102 = _originalChq_reg_mth_misc_amt_102;
			CHQ_REG_MTH_MISC_AMT_103 = _originalChq_reg_mth_misc_amt_103;
			CHQ_REG_MTH_MISC_AMT_104 = _originalChq_reg_mth_misc_amt_104;
			CHQ_REG_MTH_MISC_AMT_105 = _originalChq_reg_mth_misc_amt_105;
			CHQ_REG_MTH_MISC_AMT_106 = _originalChq_reg_mth_misc_amt_106;
			CHQ_REG_MTH_MISC_AMT_107 = _originalChq_reg_mth_misc_amt_107;
			CHQ_REG_MTH_MISC_AMT_108 = _originalChq_reg_mth_misc_amt_108;
			CHQ_REG_MTH_MISC_AMT_109 = _originalChq_reg_mth_misc_amt_109;
			CHQ_REG_MTH_MISC_AMT_1010 = _originalChq_reg_mth_misc_amt_1010;
			CHQ_REG_MTH_MISC_AMT_1011 = _originalChq_reg_mth_misc_amt_1011;
			CHQ_REG_MTH_MISC_AMT_1012 = _originalChq_reg_mth_misc_amt_1012;
			CHQ_REG_MTH_MISC_AMT_1013 = _originalChq_reg_mth_misc_amt_1013;
			CHQ_REG_MTH_MISC_AMT_1014 = _originalChq_reg_mth_misc_amt_1014;
			CHQ_REG_MTH_MISC_AMT_1015 = _originalChq_reg_mth_misc_amt_1015;
			CHQ_REG_MTH_MISC_AMT_1016 = _originalChq_reg_mth_misc_amt_1016;
			CHQ_REG_MTH_MISC_AMT_1017 = _originalChq_reg_mth_misc_amt_1017;
			CHQ_REG_MTH_MISC_AMT_1018 = _originalChq_reg_mth_misc_amt_1018;
			CHQ_REG_MTH_EXP_AMT1 = _originalChq_reg_mth_exp_amt1;
			CHQ_REG_MTH_EXP_AMT2 = _originalChq_reg_mth_exp_amt2;
			CHQ_REG_MTH_EXP_AMT3 = _originalChq_reg_mth_exp_amt3;
			CHQ_REG_MTH_EXP_AMT4 = _originalChq_reg_mth_exp_amt4;
			CHQ_REG_MTH_EXP_AMT5 = _originalChq_reg_mth_exp_amt5;
			CHQ_REG_MTH_EXP_AMT6 = _originalChq_reg_mth_exp_amt6;
			CHQ_REG_MTH_EXP_AMT7 = _originalChq_reg_mth_exp_amt7;
			CHQ_REG_MTH_EXP_AMT8 = _originalChq_reg_mth_exp_amt8;
			CHQ_REG_MTH_EXP_AMT9 = _originalChq_reg_mth_exp_amt9;
			CHQ_REG_MTH_EXP_AMT10 = _originalChq_reg_mth_exp_amt10;
			CHQ_REG_MTH_EXP_AMT11 = _originalChq_reg_mth_exp_amt11;
			CHQ_REG_MTH_EXP_AMT12 = _originalChq_reg_mth_exp_amt12;
			CHQ_REG_MTH_EXP_AMT13 = _originalChq_reg_mth_exp_amt13;
			CHQ_REG_MTH_EXP_AMT14 = _originalChq_reg_mth_exp_amt14;
			CHQ_REG_MTH_EXP_AMT15 = _originalChq_reg_mth_exp_amt15;
			CHQ_REG_MTH_EXP_AMT16 = _originalChq_reg_mth_exp_amt16;
			CHQ_REG_MTH_EXP_AMT17 = _originalChq_reg_mth_exp_amt17;
			CHQ_REG_MTH_EXP_AMT18 = _originalChq_reg_mth_exp_amt18;
			CHQ_REG_COMP_ANN_EXP_THIS_PAY1 = _originalChq_reg_comp_ann_exp_this_pay1;
			CHQ_REG_COMP_ANN_EXP_THIS_PAY2 = _originalChq_reg_comp_ann_exp_this_pay2;
			CHQ_REG_COMP_ANN_EXP_THIS_PAY3 = _originalChq_reg_comp_ann_exp_this_pay3;
			CHQ_REG_COMP_ANN_EXP_THIS_PAY4 = _originalChq_reg_comp_ann_exp_this_pay4;
			CHQ_REG_COMP_ANN_EXP_THIS_PAY5 = _originalChq_reg_comp_ann_exp_this_pay5;
			CHQ_REG_COMP_ANN_EXP_THIS_PAY6 = _originalChq_reg_comp_ann_exp_this_pay6;
			CHQ_REG_COMP_ANN_EXP_THIS_PAY7 = _originalChq_reg_comp_ann_exp_this_pay7;
			CHQ_REG_COMP_ANN_EXP_THIS_PAY8 = _originalChq_reg_comp_ann_exp_this_pay8;
			CHQ_REG_COMP_ANN_EXP_THIS_PAY9 = _originalChq_reg_comp_ann_exp_this_pay9;
			CHQ_REG_COMP_ANN_EXP_THIS_PAY10 = _originalChq_reg_comp_ann_exp_this_pay10;
			CHQ_REG_COMP_ANN_EXP_THIS_PAY11 = _originalChq_reg_comp_ann_exp_this_pay11;
			CHQ_REG_COMP_ANN_EXP_THIS_PAY12 = _originalChq_reg_comp_ann_exp_this_pay12;
			CHQ_REG_COMP_ANN_EXP_THIS_PAY13 = _originalChq_reg_comp_ann_exp_this_pay13;
			CHQ_REG_COMP_ANN_EXP_THIS_PAY14 = _originalChq_reg_comp_ann_exp_this_pay14;
			CHQ_REG_COMP_ANN_EXP_THIS_PAY15 = _originalChq_reg_comp_ann_exp_this_pay15;
			CHQ_REG_COMP_ANN_EXP_THIS_PAY16 = _originalChq_reg_comp_ann_exp_this_pay16;
			CHQ_REG_COMP_ANN_EXP_THIS_PAY17 = _originalChq_reg_comp_ann_exp_this_pay17;
			CHQ_REG_COMP_ANN_EXP_THIS_PAY18 = _originalChq_reg_comp_ann_exp_this_pay18;
			CHQ_REG_MTH_CEIL_AMT1 = _originalChq_reg_mth_ceil_amt1;
			CHQ_REG_MTH_CEIL_AMT2 = _originalChq_reg_mth_ceil_amt2;
			CHQ_REG_MTH_CEIL_AMT3 = _originalChq_reg_mth_ceil_amt3;
			CHQ_REG_MTH_CEIL_AMT4 = _originalChq_reg_mth_ceil_amt4;
			CHQ_REG_MTH_CEIL_AMT5 = _originalChq_reg_mth_ceil_amt5;
			CHQ_REG_MTH_CEIL_AMT6 = _originalChq_reg_mth_ceil_amt6;
			CHQ_REG_MTH_CEIL_AMT7 = _originalChq_reg_mth_ceil_amt7;
			CHQ_REG_MTH_CEIL_AMT8 = _originalChq_reg_mth_ceil_amt8;
			CHQ_REG_MTH_CEIL_AMT9 = _originalChq_reg_mth_ceil_amt9;
			CHQ_REG_MTH_CEIL_AMT10 = _originalChq_reg_mth_ceil_amt10;
			CHQ_REG_MTH_CEIL_AMT11 = _originalChq_reg_mth_ceil_amt11;
			CHQ_REG_MTH_CEIL_AMT12 = _originalChq_reg_mth_ceil_amt12;
			CHQ_REG_MTH_CEIL_AMT13 = _originalChq_reg_mth_ceil_amt13;
			CHQ_REG_MTH_CEIL_AMT14 = _originalChq_reg_mth_ceil_amt14;
			CHQ_REG_MTH_CEIL_AMT15 = _originalChq_reg_mth_ceil_amt15;
			CHQ_REG_MTH_CEIL_AMT16 = _originalChq_reg_mth_ceil_amt16;
			CHQ_REG_MTH_CEIL_AMT17 = _originalChq_reg_mth_ceil_amt17;
			CHQ_REG_MTH_CEIL_AMT18 = _originalChq_reg_mth_ceil_amt18;
			CHQ_REG_COMP_ANN_CEIL_THIS_PAY1 = _originalChq_reg_comp_ann_ceil_this_pay1;
			CHQ_REG_COMP_ANN_CEIL_THIS_PAY2 = _originalChq_reg_comp_ann_ceil_this_pay2;
			CHQ_REG_COMP_ANN_CEIL_THIS_PAY3 = _originalChq_reg_comp_ann_ceil_this_pay3;
			CHQ_REG_COMP_ANN_CEIL_THIS_PAY4 = _originalChq_reg_comp_ann_ceil_this_pay4;
			CHQ_REG_COMP_ANN_CEIL_THIS_PAY5 = _originalChq_reg_comp_ann_ceil_this_pay5;
			CHQ_REG_COMP_ANN_CEIL_THIS_PAY6 = _originalChq_reg_comp_ann_ceil_this_pay6;
			CHQ_REG_COMP_ANN_CEIL_THIS_PAY7 = _originalChq_reg_comp_ann_ceil_this_pay7;
			CHQ_REG_COMP_ANN_CEIL_THIS_PAY8 = _originalChq_reg_comp_ann_ceil_this_pay8;
			CHQ_REG_COMP_ANN_CEIL_THIS_PAY9 = _originalChq_reg_comp_ann_ceil_this_pay9;
			CHQ_REG_COMP_ANN_CEIL_THIS_PAY10 = _originalChq_reg_comp_ann_ceil_this_pay10;
			CHQ_REG_COMP_ANN_CEIL_THIS_PAY11 = _originalChq_reg_comp_ann_ceil_this_pay11;
			CHQ_REG_COMP_ANN_CEIL_THIS_PAY12 = _originalChq_reg_comp_ann_ceil_this_pay12;
			CHQ_REG_COMP_ANN_CEIL_THIS_PAY13 = _originalChq_reg_comp_ann_ceil_this_pay13;
			CHQ_REG_COMP_ANN_CEIL_THIS_PAY14 = _originalChq_reg_comp_ann_ceil_this_pay14;
			CHQ_REG_COMP_ANN_CEIL_THIS_PAY15 = _originalChq_reg_comp_ann_ceil_this_pay15;
			CHQ_REG_COMP_ANN_CEIL_THIS_PAY16 = _originalChq_reg_comp_ann_ceil_this_pay16;
			CHQ_REG_COMP_ANN_CEIL_THIS_PAY17 = _originalChq_reg_comp_ann_ceil_this_pay17;
			CHQ_REG_COMP_ANN_CEIL_THIS_PAY18 = _originalChq_reg_comp_ann_ceil_this_pay18;
			CHQ_REG_EARNINGS_THIS_MTH1 = _originalChq_reg_earnings_this_mth1;
			CHQ_REG_EARNINGS_THIS_MTH2 = _originalChq_reg_earnings_this_mth2;
			CHQ_REG_EARNINGS_THIS_MTH3 = _originalChq_reg_earnings_this_mth3;
			CHQ_REG_EARNINGS_THIS_MTH4 = _originalChq_reg_earnings_this_mth4;
			CHQ_REG_EARNINGS_THIS_MTH5 = _originalChq_reg_earnings_this_mth5;
			CHQ_REG_EARNINGS_THIS_MTH6 = _originalChq_reg_earnings_this_mth6;
			CHQ_REG_EARNINGS_THIS_MTH7 = _originalChq_reg_earnings_this_mth7;
			CHQ_REG_EARNINGS_THIS_MTH8 = _originalChq_reg_earnings_this_mth8;
			CHQ_REG_EARNINGS_THIS_MTH9 = _originalChq_reg_earnings_this_mth9;
			CHQ_REG_EARNINGS_THIS_MTH10 = _originalChq_reg_earnings_this_mth10;
			CHQ_REG_EARNINGS_THIS_MTH11 = _originalChq_reg_earnings_this_mth11;
			CHQ_REG_EARNINGS_THIS_MTH12 = _originalChq_reg_earnings_this_mth12;
			CHQ_REG_EARNINGS_THIS_MTH13 = _originalChq_reg_earnings_this_mth13;
			CHQ_REG_EARNINGS_THIS_MTH14 = _originalChq_reg_earnings_this_mth14;
			CHQ_REG_EARNINGS_THIS_MTH15 = _originalChq_reg_earnings_this_mth15;
			CHQ_REG_EARNINGS_THIS_MTH16 = _originalChq_reg_earnings_this_mth16;
			CHQ_REG_EARNINGS_THIS_MTH17 = _originalChq_reg_earnings_this_mth17;
			CHQ_REG_EARNINGS_THIS_MTH18 = _originalChq_reg_earnings_this_mth18;
			CHQ_REG_REGULAR_PAY_THIS_MTH1 = _originalChq_reg_regular_pay_this_mth1;
			CHQ_REG_REGULAR_PAY_THIS_MTH2 = _originalChq_reg_regular_pay_this_mth2;
			CHQ_REG_REGULAR_PAY_THIS_MTH3 = _originalChq_reg_regular_pay_this_mth3;
			CHQ_REG_REGULAR_PAY_THIS_MTH4 = _originalChq_reg_regular_pay_this_mth4;
			CHQ_REG_REGULAR_PAY_THIS_MTH5 = _originalChq_reg_regular_pay_this_mth5;
			CHQ_REG_REGULAR_PAY_THIS_MTH6 = _originalChq_reg_regular_pay_this_mth6;
			CHQ_REG_REGULAR_PAY_THIS_MTH7 = _originalChq_reg_regular_pay_this_mth7;
			CHQ_REG_REGULAR_PAY_THIS_MTH8 = _originalChq_reg_regular_pay_this_mth8;
			CHQ_REG_REGULAR_PAY_THIS_MTH9 = _originalChq_reg_regular_pay_this_mth9;
			CHQ_REG_REGULAR_PAY_THIS_MTH10 = _originalChq_reg_regular_pay_this_mth10;
			CHQ_REG_REGULAR_PAY_THIS_MTH11 = _originalChq_reg_regular_pay_this_mth11;
			CHQ_REG_REGULAR_PAY_THIS_MTH12 = _originalChq_reg_regular_pay_this_mth12;
			CHQ_REG_REGULAR_PAY_THIS_MTH13 = _originalChq_reg_regular_pay_this_mth13;
			CHQ_REG_REGULAR_PAY_THIS_MTH14 = _originalChq_reg_regular_pay_this_mth14;
			CHQ_REG_REGULAR_PAY_THIS_MTH15 = _originalChq_reg_regular_pay_this_mth15;
			CHQ_REG_REGULAR_PAY_THIS_MTH16 = _originalChq_reg_regular_pay_this_mth16;
			CHQ_REG_REGULAR_PAY_THIS_MTH17 = _originalChq_reg_regular_pay_this_mth17;
			CHQ_REG_REGULAR_PAY_THIS_MTH18 = _originalChq_reg_regular_pay_this_mth18;
			CHQ_REG_REGULAR_TAX_THIS_MTH1 = _originalChq_reg_regular_tax_this_mth1;
			CHQ_REG_REGULAR_TAX_THIS_MTH2 = _originalChq_reg_regular_tax_this_mth2;
			CHQ_REG_REGULAR_TAX_THIS_MTH3 = _originalChq_reg_regular_tax_this_mth3;
			CHQ_REG_REGULAR_TAX_THIS_MTH4 = _originalChq_reg_regular_tax_this_mth4;
			CHQ_REG_REGULAR_TAX_THIS_MTH5 = _originalChq_reg_regular_tax_this_mth5;
			CHQ_REG_REGULAR_TAX_THIS_MTH6 = _originalChq_reg_regular_tax_this_mth6;
			CHQ_REG_REGULAR_TAX_THIS_MTH7 = _originalChq_reg_regular_tax_this_mth7;
			CHQ_REG_REGULAR_TAX_THIS_MTH8 = _originalChq_reg_regular_tax_this_mth8;
			CHQ_REG_REGULAR_TAX_THIS_MTH9 = _originalChq_reg_regular_tax_this_mth9;
			CHQ_REG_REGULAR_TAX_THIS_MTH10 = _originalChq_reg_regular_tax_this_mth10;
			CHQ_REG_REGULAR_TAX_THIS_MTH11 = _originalChq_reg_regular_tax_this_mth11;
			CHQ_REG_REGULAR_TAX_THIS_MTH12 = _originalChq_reg_regular_tax_this_mth12;
			CHQ_REG_REGULAR_TAX_THIS_MTH13 = _originalChq_reg_regular_tax_this_mth13;
			CHQ_REG_REGULAR_TAX_THIS_MTH14 = _originalChq_reg_regular_tax_this_mth14;
			CHQ_REG_REGULAR_TAX_THIS_MTH15 = _originalChq_reg_regular_tax_this_mth15;
			CHQ_REG_REGULAR_TAX_THIS_MTH16 = _originalChq_reg_regular_tax_this_mth16;
			CHQ_REG_REGULAR_TAX_THIS_MTH17 = _originalChq_reg_regular_tax_this_mth17;
			CHQ_REG_REGULAR_TAX_THIS_MTH18 = _originalChq_reg_regular_tax_this_mth18;
			CHQ_REG_MAN_PAY_THIS_MTH1 = _originalChq_reg_man_pay_this_mth1;
			CHQ_REG_MAN_PAY_THIS_MTH2 = _originalChq_reg_man_pay_this_mth2;
			CHQ_REG_MAN_PAY_THIS_MTH3 = _originalChq_reg_man_pay_this_mth3;
			CHQ_REG_MAN_PAY_THIS_MTH4 = _originalChq_reg_man_pay_this_mth4;
			CHQ_REG_MAN_PAY_THIS_MTH5 = _originalChq_reg_man_pay_this_mth5;
			CHQ_REG_MAN_PAY_THIS_MTH6 = _originalChq_reg_man_pay_this_mth6;
			CHQ_REG_MAN_PAY_THIS_MTH7 = _originalChq_reg_man_pay_this_mth7;
			CHQ_REG_MAN_PAY_THIS_MTH8 = _originalChq_reg_man_pay_this_mth8;
			CHQ_REG_MAN_PAY_THIS_MTH9 = _originalChq_reg_man_pay_this_mth9;
			CHQ_REG_MAN_PAY_THIS_MTH10 = _originalChq_reg_man_pay_this_mth10;
			CHQ_REG_MAN_PAY_THIS_MTH11 = _originalChq_reg_man_pay_this_mth11;
			CHQ_REG_MAN_PAY_THIS_MTH12 = _originalChq_reg_man_pay_this_mth12;
			CHQ_REG_MAN_PAY_THIS_MTH13 = _originalChq_reg_man_pay_this_mth13;
			CHQ_REG_MAN_PAY_THIS_MTH14 = _originalChq_reg_man_pay_this_mth14;
			CHQ_REG_MAN_PAY_THIS_MTH15 = _originalChq_reg_man_pay_this_mth15;
			CHQ_REG_MAN_PAY_THIS_MTH16 = _originalChq_reg_man_pay_this_mth16;
			CHQ_REG_MAN_PAY_THIS_MTH17 = _originalChq_reg_man_pay_this_mth17;
			CHQ_REG_MAN_PAY_THIS_MTH18 = _originalChq_reg_man_pay_this_mth18;
			CHQ_REG_MAN_TAX_THIS_MTH1 = _originalChq_reg_man_tax_this_mth1;
			CHQ_REG_MAN_TAX_THIS_MTH2 = _originalChq_reg_man_tax_this_mth2;
			CHQ_REG_MAN_TAX_THIS_MTH3 = _originalChq_reg_man_tax_this_mth3;
			CHQ_REG_MAN_TAX_THIS_MTH4 = _originalChq_reg_man_tax_this_mth4;
			CHQ_REG_MAN_TAX_THIS_MTH5 = _originalChq_reg_man_tax_this_mth5;
			CHQ_REG_MAN_TAX_THIS_MTH6 = _originalChq_reg_man_tax_this_mth6;
			CHQ_REG_MAN_TAX_THIS_MTH7 = _originalChq_reg_man_tax_this_mth7;
			CHQ_REG_MAN_TAX_THIS_MTH8 = _originalChq_reg_man_tax_this_mth8;
			CHQ_REG_MAN_TAX_THIS_MTH9 = _originalChq_reg_man_tax_this_mth9;
			CHQ_REG_MAN_TAX_THIS_MTH10 = _originalChq_reg_man_tax_this_mth10;
			CHQ_REG_MAN_TAX_THIS_MTH11 = _originalChq_reg_man_tax_this_mth11;
			CHQ_REG_MAN_TAX_THIS_MTH12 = _originalChq_reg_man_tax_this_mth12;
			CHQ_REG_MAN_TAX_THIS_MTH13 = _originalChq_reg_man_tax_this_mth13;
			CHQ_REG_MAN_TAX_THIS_MTH14 = _originalChq_reg_man_tax_this_mth14;
			CHQ_REG_MAN_TAX_THIS_MTH15 = _originalChq_reg_man_tax_this_mth15;
			CHQ_REG_MAN_TAX_THIS_MTH16 = _originalChq_reg_man_tax_this_mth16;
			CHQ_REG_MAN_TAX_THIS_MTH17 = _originalChq_reg_man_tax_this_mth17;
			CHQ_REG_MAN_TAX_THIS_MTH18 = _originalChq_reg_man_tax_this_mth18;
			CHQ_REG_PAY_DATE1 = _originalChq_reg_pay_date1;
			CHQ_REG_PAY_DATE2 = _originalChq_reg_pay_date2;
			CHQ_REG_PAY_DATE3 = _originalChq_reg_pay_date3;
			CHQ_REG_PAY_DATE4 = _originalChq_reg_pay_date4;
			CHQ_REG_PAY_DATE5 = _originalChq_reg_pay_date5;
			CHQ_REG_PAY_DATE6 = _originalChq_reg_pay_date6;
			CHQ_REG_PAY_DATE7 = _originalChq_reg_pay_date7;
			CHQ_REG_PAY_DATE8 = _originalChq_reg_pay_date8;
			CHQ_REG_PAY_DATE9 = _originalChq_reg_pay_date9;
			CHQ_REG_PAY_DATE10 = _originalChq_reg_pay_date10;
			CHQ_REG_PAY_DATE11 = _originalChq_reg_pay_date11;
			CHQ_REG_PAY_DATE12 = _originalChq_reg_pay_date12;
			CHQ_REG_PAY_DATE13 = _originalChq_reg_pay_date13;
			CHQ_REG_PAY_DATE14 = _originalChq_reg_pay_date14;
			CHQ_REG_PAY_DATE15 = _originalChq_reg_pay_date15;
			CHQ_REG_PAY_DATE16 = _originalChq_reg_pay_date16;
			CHQ_REG_PAY_DATE17 = _originalChq_reg_pay_date17;
			CHQ_REG_PAY_DATE18 = _originalChq_reg_pay_date18;
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
					new SqlParameter("CHQ_REG_CLINIC_NBR_1_2",CHQ_REG_CLINIC_NBR_1_2),
					new SqlParameter("CHQ_REG_DEPT",CHQ_REG_DEPT),
					new SqlParameter("CHQ_REG_DOC_NBR",CHQ_REG_DOC_NBR)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F060_CHEQUE_REG_MSTR_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F060_CHEQUE_REG_MSTR_Purge]");
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
						new SqlParameter("CHQ_REG_CLINIC_NBR_1_2", SqlNull(CHQ_REG_CLINIC_NBR_1_2)),
						new SqlParameter("CHQ_REG_DEPT", SqlNull(CHQ_REG_DEPT)),
						new SqlParameter("CHQ_REG_DOC_NBR", SqlNull(CHQ_REG_DOC_NBR)),
						new SqlParameter("CHQ_REG_PERC_BILL1", SqlNull(CHQ_REG_PERC_BILL1)),
						new SqlParameter("CHQ_REG_PERC_BILL2", SqlNull(CHQ_REG_PERC_BILL2)),
						new SqlParameter("CHQ_REG_PERC_BILL3", SqlNull(CHQ_REG_PERC_BILL3)),
						new SqlParameter("CHQ_REG_PERC_BILL4", SqlNull(CHQ_REG_PERC_BILL4)),
						new SqlParameter("CHQ_REG_PERC_BILL5", SqlNull(CHQ_REG_PERC_BILL5)),
						new SqlParameter("CHQ_REG_PERC_BILL6", SqlNull(CHQ_REG_PERC_BILL6)),
						new SqlParameter("CHQ_REG_PERC_BILL7", SqlNull(CHQ_REG_PERC_BILL7)),
						new SqlParameter("CHQ_REG_PERC_BILL8", SqlNull(CHQ_REG_PERC_BILL8)),
						new SqlParameter("CHQ_REG_PERC_BILL9", SqlNull(CHQ_REG_PERC_BILL9)),
						new SqlParameter("CHQ_REG_PERC_BILL10", SqlNull(CHQ_REG_PERC_BILL10)),
						new SqlParameter("CHQ_REG_PERC_BILL11", SqlNull(CHQ_REG_PERC_BILL11)),
						new SqlParameter("CHQ_REG_PERC_BILL12", SqlNull(CHQ_REG_PERC_BILL12)),
						new SqlParameter("CHQ_REG_PERC_BILL13", SqlNull(CHQ_REG_PERC_BILL13)),
						new SqlParameter("CHQ_REG_PERC_BILL14", SqlNull(CHQ_REG_PERC_BILL14)),
						new SqlParameter("CHQ_REG_PERC_BILL15", SqlNull(CHQ_REG_PERC_BILL15)),
						new SqlParameter("CHQ_REG_PERC_BILL16", SqlNull(CHQ_REG_PERC_BILL16)),
						new SqlParameter("CHQ_REG_PERC_BILL17", SqlNull(CHQ_REG_PERC_BILL17)),
						new SqlParameter("CHQ_REG_PERC_BILL18", SqlNull(CHQ_REG_PERC_BILL18)),
						new SqlParameter("CHQ_REG_PERC_MISC1", SqlNull(CHQ_REG_PERC_MISC1)),
						new SqlParameter("CHQ_REG_PERC_MISC2", SqlNull(CHQ_REG_PERC_MISC2)),
						new SqlParameter("CHQ_REG_PERC_MISC3", SqlNull(CHQ_REG_PERC_MISC3)),
						new SqlParameter("CHQ_REG_PERC_MISC4", SqlNull(CHQ_REG_PERC_MISC4)),
						new SqlParameter("CHQ_REG_PERC_MISC5", SqlNull(CHQ_REG_PERC_MISC5)),
						new SqlParameter("CHQ_REG_PERC_MISC6", SqlNull(CHQ_REG_PERC_MISC6)),
						new SqlParameter("CHQ_REG_PERC_MISC7", SqlNull(CHQ_REG_PERC_MISC7)),
						new SqlParameter("CHQ_REG_PERC_MISC8", SqlNull(CHQ_REG_PERC_MISC8)),
						new SqlParameter("CHQ_REG_PERC_MISC9", SqlNull(CHQ_REG_PERC_MISC9)),
						new SqlParameter("CHQ_REG_PERC_MISC10", SqlNull(CHQ_REG_PERC_MISC10)),
						new SqlParameter("CHQ_REG_PERC_MISC11", SqlNull(CHQ_REG_PERC_MISC11)),
						new SqlParameter("CHQ_REG_PERC_MISC12", SqlNull(CHQ_REG_PERC_MISC12)),
						new SqlParameter("CHQ_REG_PERC_MISC13", SqlNull(CHQ_REG_PERC_MISC13)),
						new SqlParameter("CHQ_REG_PERC_MISC14", SqlNull(CHQ_REG_PERC_MISC14)),
						new SqlParameter("CHQ_REG_PERC_MISC15", SqlNull(CHQ_REG_PERC_MISC15)),
						new SqlParameter("CHQ_REG_PERC_MISC16", SqlNull(CHQ_REG_PERC_MISC16)),
						new SqlParameter("CHQ_REG_PERC_MISC17", SqlNull(CHQ_REG_PERC_MISC17)),
						new SqlParameter("CHQ_REG_PERC_MISC18", SqlNull(CHQ_REG_PERC_MISC18)),
						new SqlParameter("CHQ_REG_PAY_CODE1", SqlNull(CHQ_REG_PAY_CODE1)),
						new SqlParameter("CHQ_REG_PAY_CODE2", SqlNull(CHQ_REG_PAY_CODE2)),
						new SqlParameter("CHQ_REG_PAY_CODE3", SqlNull(CHQ_REG_PAY_CODE3)),
						new SqlParameter("CHQ_REG_PAY_CODE4", SqlNull(CHQ_REG_PAY_CODE4)),
						new SqlParameter("CHQ_REG_PAY_CODE5", SqlNull(CHQ_REG_PAY_CODE5)),
						new SqlParameter("CHQ_REG_PAY_CODE6", SqlNull(CHQ_REG_PAY_CODE6)),
						new SqlParameter("CHQ_REG_PAY_CODE7", SqlNull(CHQ_REG_PAY_CODE7)),
						new SqlParameter("CHQ_REG_PAY_CODE8", SqlNull(CHQ_REG_PAY_CODE8)),
						new SqlParameter("CHQ_REG_PAY_CODE9", SqlNull(CHQ_REG_PAY_CODE9)),
						new SqlParameter("CHQ_REG_PAY_CODE10", SqlNull(CHQ_REG_PAY_CODE10)),
						new SqlParameter("CHQ_REG_PAY_CODE11", SqlNull(CHQ_REG_PAY_CODE11)),
						new SqlParameter("CHQ_REG_PAY_CODE12", SqlNull(CHQ_REG_PAY_CODE12)),
						new SqlParameter("CHQ_REG_PAY_CODE13", SqlNull(CHQ_REG_PAY_CODE13)),
						new SqlParameter("CHQ_REG_PAY_CODE14", SqlNull(CHQ_REG_PAY_CODE14)),
						new SqlParameter("CHQ_REG_PAY_CODE15", SqlNull(CHQ_REG_PAY_CODE15)),
						new SqlParameter("CHQ_REG_PAY_CODE16", SqlNull(CHQ_REG_PAY_CODE16)),
						new SqlParameter("CHQ_REG_PAY_CODE17", SqlNull(CHQ_REG_PAY_CODE17)),
						new SqlParameter("CHQ_REG_PAY_CODE18", SqlNull(CHQ_REG_PAY_CODE18)),
						new SqlParameter("CHQ_REG_PERC_TAX1", SqlNull(CHQ_REG_PERC_TAX1)),
						new SqlParameter("CHQ_REG_PERC_TAX2", SqlNull(CHQ_REG_PERC_TAX2)),
						new SqlParameter("CHQ_REG_PERC_TAX3", SqlNull(CHQ_REG_PERC_TAX3)),
						new SqlParameter("CHQ_REG_PERC_TAX4", SqlNull(CHQ_REG_PERC_TAX4)),
						new SqlParameter("CHQ_REG_PERC_TAX5", SqlNull(CHQ_REG_PERC_TAX5)),
						new SqlParameter("CHQ_REG_PERC_TAX6", SqlNull(CHQ_REG_PERC_TAX6)),
						new SqlParameter("CHQ_REG_PERC_TAX7", SqlNull(CHQ_REG_PERC_TAX7)),
						new SqlParameter("CHQ_REG_PERC_TAX8", SqlNull(CHQ_REG_PERC_TAX8)),
						new SqlParameter("CHQ_REG_PERC_TAX9", SqlNull(CHQ_REG_PERC_TAX9)),
						new SqlParameter("CHQ_REG_PERC_TAX10", SqlNull(CHQ_REG_PERC_TAX10)),
						new SqlParameter("CHQ_REG_PERC_TAX11", SqlNull(CHQ_REG_PERC_TAX11)),
						new SqlParameter("CHQ_REG_PERC_TAX12", SqlNull(CHQ_REG_PERC_TAX12)),
						new SqlParameter("CHQ_REG_PERC_TAX13", SqlNull(CHQ_REG_PERC_TAX13)),
						new SqlParameter("CHQ_REG_PERC_TAX14", SqlNull(CHQ_REG_PERC_TAX14)),
						new SqlParameter("CHQ_REG_PERC_TAX15", SqlNull(CHQ_REG_PERC_TAX15)),
						new SqlParameter("CHQ_REG_PERC_TAX16", SqlNull(CHQ_REG_PERC_TAX16)),
						new SqlParameter("CHQ_REG_PERC_TAX17", SqlNull(CHQ_REG_PERC_TAX17)),
						new SqlParameter("CHQ_REG_PERC_TAX18", SqlNull(CHQ_REG_PERC_TAX18)),
						new SqlParameter("CHQ_REG_MTH_BILL_AMT1", SqlNull(CHQ_REG_MTH_BILL_AMT1)),
						new SqlParameter("CHQ_REG_MTH_BILL_AMT2", SqlNull(CHQ_REG_MTH_BILL_AMT2)),
						new SqlParameter("CHQ_REG_MTH_BILL_AMT3", SqlNull(CHQ_REG_MTH_BILL_AMT3)),
						new SqlParameter("CHQ_REG_MTH_BILL_AMT4", SqlNull(CHQ_REG_MTH_BILL_AMT4)),
						new SqlParameter("CHQ_REG_MTH_BILL_AMT5", SqlNull(CHQ_REG_MTH_BILL_AMT5)),
						new SqlParameter("CHQ_REG_MTH_BILL_AMT6", SqlNull(CHQ_REG_MTH_BILL_AMT6)),
						new SqlParameter("CHQ_REG_MTH_BILL_AMT7", SqlNull(CHQ_REG_MTH_BILL_AMT7)),
						new SqlParameter("CHQ_REG_MTH_BILL_AMT8", SqlNull(CHQ_REG_MTH_BILL_AMT8)),
						new SqlParameter("CHQ_REG_MTH_BILL_AMT9", SqlNull(CHQ_REG_MTH_BILL_AMT9)),
						new SqlParameter("CHQ_REG_MTH_BILL_AMT10", SqlNull(CHQ_REG_MTH_BILL_AMT10)),
						new SqlParameter("CHQ_REG_MTH_BILL_AMT11", SqlNull(CHQ_REG_MTH_BILL_AMT11)),
						new SqlParameter("CHQ_REG_MTH_BILL_AMT12", SqlNull(CHQ_REG_MTH_BILL_AMT12)),
						new SqlParameter("CHQ_REG_MTH_BILL_AMT13", SqlNull(CHQ_REG_MTH_BILL_AMT13)),
						new SqlParameter("CHQ_REG_MTH_BILL_AMT14", SqlNull(CHQ_REG_MTH_BILL_AMT14)),
						new SqlParameter("CHQ_REG_MTH_BILL_AMT15", SqlNull(CHQ_REG_MTH_BILL_AMT15)),
						new SqlParameter("CHQ_REG_MTH_BILL_AMT16", SqlNull(CHQ_REG_MTH_BILL_AMT16)),
						new SqlParameter("CHQ_REG_MTH_BILL_AMT17", SqlNull(CHQ_REG_MTH_BILL_AMT17)),
						new SqlParameter("CHQ_REG_MTH_BILL_AMT18", SqlNull(CHQ_REG_MTH_BILL_AMT18)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_11", SqlNull(CHQ_REG_MTH_MISC_AMT_11)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_12", SqlNull(CHQ_REG_MTH_MISC_AMT_12)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_13", SqlNull(CHQ_REG_MTH_MISC_AMT_13)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_14", SqlNull(CHQ_REG_MTH_MISC_AMT_14)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_15", SqlNull(CHQ_REG_MTH_MISC_AMT_15)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_16", SqlNull(CHQ_REG_MTH_MISC_AMT_16)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_17", SqlNull(CHQ_REG_MTH_MISC_AMT_17)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_18", SqlNull(CHQ_REG_MTH_MISC_AMT_18)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_19", SqlNull(CHQ_REG_MTH_MISC_AMT_19)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_110", SqlNull(CHQ_REG_MTH_MISC_AMT_110)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_111", SqlNull(CHQ_REG_MTH_MISC_AMT_111)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_112", SqlNull(CHQ_REG_MTH_MISC_AMT_112)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_113", SqlNull(CHQ_REG_MTH_MISC_AMT_113)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_114", SqlNull(CHQ_REG_MTH_MISC_AMT_114)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_115", SqlNull(CHQ_REG_MTH_MISC_AMT_115)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_116", SqlNull(CHQ_REG_MTH_MISC_AMT_116)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_117", SqlNull(CHQ_REG_MTH_MISC_AMT_117)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_118", SqlNull(CHQ_REG_MTH_MISC_AMT_118)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_21", SqlNull(CHQ_REG_MTH_MISC_AMT_21)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_22", SqlNull(CHQ_REG_MTH_MISC_AMT_22)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_23", SqlNull(CHQ_REG_MTH_MISC_AMT_23)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_24", SqlNull(CHQ_REG_MTH_MISC_AMT_24)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_25", SqlNull(CHQ_REG_MTH_MISC_AMT_25)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_26", SqlNull(CHQ_REG_MTH_MISC_AMT_26)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_27", SqlNull(CHQ_REG_MTH_MISC_AMT_27)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_28", SqlNull(CHQ_REG_MTH_MISC_AMT_28)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_29", SqlNull(CHQ_REG_MTH_MISC_AMT_29)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_210", SqlNull(CHQ_REG_MTH_MISC_AMT_210)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_211", SqlNull(CHQ_REG_MTH_MISC_AMT_211)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_212", SqlNull(CHQ_REG_MTH_MISC_AMT_212)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_213", SqlNull(CHQ_REG_MTH_MISC_AMT_213)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_214", SqlNull(CHQ_REG_MTH_MISC_AMT_214)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_215", SqlNull(CHQ_REG_MTH_MISC_AMT_215)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_216", SqlNull(CHQ_REG_MTH_MISC_AMT_216)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_217", SqlNull(CHQ_REG_MTH_MISC_AMT_217)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_218", SqlNull(CHQ_REG_MTH_MISC_AMT_218)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_31", SqlNull(CHQ_REG_MTH_MISC_AMT_31)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_32", SqlNull(CHQ_REG_MTH_MISC_AMT_32)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_33", SqlNull(CHQ_REG_MTH_MISC_AMT_33)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_34", SqlNull(CHQ_REG_MTH_MISC_AMT_34)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_35", SqlNull(CHQ_REG_MTH_MISC_AMT_35)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_36", SqlNull(CHQ_REG_MTH_MISC_AMT_36)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_37", SqlNull(CHQ_REG_MTH_MISC_AMT_37)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_38", SqlNull(CHQ_REG_MTH_MISC_AMT_38)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_39", SqlNull(CHQ_REG_MTH_MISC_AMT_39)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_310", SqlNull(CHQ_REG_MTH_MISC_AMT_310)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_311", SqlNull(CHQ_REG_MTH_MISC_AMT_311)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_312", SqlNull(CHQ_REG_MTH_MISC_AMT_312)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_313", SqlNull(CHQ_REG_MTH_MISC_AMT_313)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_314", SqlNull(CHQ_REG_MTH_MISC_AMT_314)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_315", SqlNull(CHQ_REG_MTH_MISC_AMT_315)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_316", SqlNull(CHQ_REG_MTH_MISC_AMT_316)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_317", SqlNull(CHQ_REG_MTH_MISC_AMT_317)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_318", SqlNull(CHQ_REG_MTH_MISC_AMT_318)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_41", SqlNull(CHQ_REG_MTH_MISC_AMT_41)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_42", SqlNull(CHQ_REG_MTH_MISC_AMT_42)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_43", SqlNull(CHQ_REG_MTH_MISC_AMT_43)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_44", SqlNull(CHQ_REG_MTH_MISC_AMT_44)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_45", SqlNull(CHQ_REG_MTH_MISC_AMT_45)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_46", SqlNull(CHQ_REG_MTH_MISC_AMT_46)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_47", SqlNull(CHQ_REG_MTH_MISC_AMT_47)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_48", SqlNull(CHQ_REG_MTH_MISC_AMT_48)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_49", SqlNull(CHQ_REG_MTH_MISC_AMT_49)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_410", SqlNull(CHQ_REG_MTH_MISC_AMT_410)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_411", SqlNull(CHQ_REG_MTH_MISC_AMT_411)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_412", SqlNull(CHQ_REG_MTH_MISC_AMT_412)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_413", SqlNull(CHQ_REG_MTH_MISC_AMT_413)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_414", SqlNull(CHQ_REG_MTH_MISC_AMT_414)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_415", SqlNull(CHQ_REG_MTH_MISC_AMT_415)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_416", SqlNull(CHQ_REG_MTH_MISC_AMT_416)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_417", SqlNull(CHQ_REG_MTH_MISC_AMT_417)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_418", SqlNull(CHQ_REG_MTH_MISC_AMT_418)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_51", SqlNull(CHQ_REG_MTH_MISC_AMT_51)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_52", SqlNull(CHQ_REG_MTH_MISC_AMT_52)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_53", SqlNull(CHQ_REG_MTH_MISC_AMT_53)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_54", SqlNull(CHQ_REG_MTH_MISC_AMT_54)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_55", SqlNull(CHQ_REG_MTH_MISC_AMT_55)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_56", SqlNull(CHQ_REG_MTH_MISC_AMT_56)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_57", SqlNull(CHQ_REG_MTH_MISC_AMT_57)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_58", SqlNull(CHQ_REG_MTH_MISC_AMT_58)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_59", SqlNull(CHQ_REG_MTH_MISC_AMT_59)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_510", SqlNull(CHQ_REG_MTH_MISC_AMT_510)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_511", SqlNull(CHQ_REG_MTH_MISC_AMT_511)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_512", SqlNull(CHQ_REG_MTH_MISC_AMT_512)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_513", SqlNull(CHQ_REG_MTH_MISC_AMT_513)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_514", SqlNull(CHQ_REG_MTH_MISC_AMT_514)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_515", SqlNull(CHQ_REG_MTH_MISC_AMT_515)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_516", SqlNull(CHQ_REG_MTH_MISC_AMT_516)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_517", SqlNull(CHQ_REG_MTH_MISC_AMT_517)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_518", SqlNull(CHQ_REG_MTH_MISC_AMT_518)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_61", SqlNull(CHQ_REG_MTH_MISC_AMT_61)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_62", SqlNull(CHQ_REG_MTH_MISC_AMT_62)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_63", SqlNull(CHQ_REG_MTH_MISC_AMT_63)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_64", SqlNull(CHQ_REG_MTH_MISC_AMT_64)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_65", SqlNull(CHQ_REG_MTH_MISC_AMT_65)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_66", SqlNull(CHQ_REG_MTH_MISC_AMT_66)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_67", SqlNull(CHQ_REG_MTH_MISC_AMT_67)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_68", SqlNull(CHQ_REG_MTH_MISC_AMT_68)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_69", SqlNull(CHQ_REG_MTH_MISC_AMT_69)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_610", SqlNull(CHQ_REG_MTH_MISC_AMT_610)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_611", SqlNull(CHQ_REG_MTH_MISC_AMT_611)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_612", SqlNull(CHQ_REG_MTH_MISC_AMT_612)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_613", SqlNull(CHQ_REG_MTH_MISC_AMT_613)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_614", SqlNull(CHQ_REG_MTH_MISC_AMT_614)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_615", SqlNull(CHQ_REG_MTH_MISC_AMT_615)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_616", SqlNull(CHQ_REG_MTH_MISC_AMT_616)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_617", SqlNull(CHQ_REG_MTH_MISC_AMT_617)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_618", SqlNull(CHQ_REG_MTH_MISC_AMT_618)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_71", SqlNull(CHQ_REG_MTH_MISC_AMT_71)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_72", SqlNull(CHQ_REG_MTH_MISC_AMT_72)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_73", SqlNull(CHQ_REG_MTH_MISC_AMT_73)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_74", SqlNull(CHQ_REG_MTH_MISC_AMT_74)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_75", SqlNull(CHQ_REG_MTH_MISC_AMT_75)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_76", SqlNull(CHQ_REG_MTH_MISC_AMT_76)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_77", SqlNull(CHQ_REG_MTH_MISC_AMT_77)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_78", SqlNull(CHQ_REG_MTH_MISC_AMT_78)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_79", SqlNull(CHQ_REG_MTH_MISC_AMT_79)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_710", SqlNull(CHQ_REG_MTH_MISC_AMT_710)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_711", SqlNull(CHQ_REG_MTH_MISC_AMT_711)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_712", SqlNull(CHQ_REG_MTH_MISC_AMT_712)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_713", SqlNull(CHQ_REG_MTH_MISC_AMT_713)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_714", SqlNull(CHQ_REG_MTH_MISC_AMT_714)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_715", SqlNull(CHQ_REG_MTH_MISC_AMT_715)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_716", SqlNull(CHQ_REG_MTH_MISC_AMT_716)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_717", SqlNull(CHQ_REG_MTH_MISC_AMT_717)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_718", SqlNull(CHQ_REG_MTH_MISC_AMT_718)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_81", SqlNull(CHQ_REG_MTH_MISC_AMT_81)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_82", SqlNull(CHQ_REG_MTH_MISC_AMT_82)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_83", SqlNull(CHQ_REG_MTH_MISC_AMT_83)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_84", SqlNull(CHQ_REG_MTH_MISC_AMT_84)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_85", SqlNull(CHQ_REG_MTH_MISC_AMT_85)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_86", SqlNull(CHQ_REG_MTH_MISC_AMT_86)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_87", SqlNull(CHQ_REG_MTH_MISC_AMT_87)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_88", SqlNull(CHQ_REG_MTH_MISC_AMT_88)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_89", SqlNull(CHQ_REG_MTH_MISC_AMT_89)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_810", SqlNull(CHQ_REG_MTH_MISC_AMT_810)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_811", SqlNull(CHQ_REG_MTH_MISC_AMT_811)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_812", SqlNull(CHQ_REG_MTH_MISC_AMT_812)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_813", SqlNull(CHQ_REG_MTH_MISC_AMT_813)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_814", SqlNull(CHQ_REG_MTH_MISC_AMT_814)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_815", SqlNull(CHQ_REG_MTH_MISC_AMT_815)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_816", SqlNull(CHQ_REG_MTH_MISC_AMT_816)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_817", SqlNull(CHQ_REG_MTH_MISC_AMT_817)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_818", SqlNull(CHQ_REG_MTH_MISC_AMT_818)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_91", SqlNull(CHQ_REG_MTH_MISC_AMT_91)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_92", SqlNull(CHQ_REG_MTH_MISC_AMT_92)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_93", SqlNull(CHQ_REG_MTH_MISC_AMT_93)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_94", SqlNull(CHQ_REG_MTH_MISC_AMT_94)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_95", SqlNull(CHQ_REG_MTH_MISC_AMT_95)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_96", SqlNull(CHQ_REG_MTH_MISC_AMT_96)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_97", SqlNull(CHQ_REG_MTH_MISC_AMT_97)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_98", SqlNull(CHQ_REG_MTH_MISC_AMT_98)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_99", SqlNull(CHQ_REG_MTH_MISC_AMT_99)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_910", SqlNull(CHQ_REG_MTH_MISC_AMT_910)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_911", SqlNull(CHQ_REG_MTH_MISC_AMT_911)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_912", SqlNull(CHQ_REG_MTH_MISC_AMT_912)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_913", SqlNull(CHQ_REG_MTH_MISC_AMT_913)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_914", SqlNull(CHQ_REG_MTH_MISC_AMT_914)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_915", SqlNull(CHQ_REG_MTH_MISC_AMT_915)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_916", SqlNull(CHQ_REG_MTH_MISC_AMT_916)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_917", SqlNull(CHQ_REG_MTH_MISC_AMT_917)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_918", SqlNull(CHQ_REG_MTH_MISC_AMT_918)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_101", SqlNull(CHQ_REG_MTH_MISC_AMT_101)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_102", SqlNull(CHQ_REG_MTH_MISC_AMT_102)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_103", SqlNull(CHQ_REG_MTH_MISC_AMT_103)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_104", SqlNull(CHQ_REG_MTH_MISC_AMT_104)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_105", SqlNull(CHQ_REG_MTH_MISC_AMT_105)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_106", SqlNull(CHQ_REG_MTH_MISC_AMT_106)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_107", SqlNull(CHQ_REG_MTH_MISC_AMT_107)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_108", SqlNull(CHQ_REG_MTH_MISC_AMT_108)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_109", SqlNull(CHQ_REG_MTH_MISC_AMT_109)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_1010", SqlNull(CHQ_REG_MTH_MISC_AMT_1010)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_1011", SqlNull(CHQ_REG_MTH_MISC_AMT_1011)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_1012", SqlNull(CHQ_REG_MTH_MISC_AMT_1012)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_1013", SqlNull(CHQ_REG_MTH_MISC_AMT_1013)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_1014", SqlNull(CHQ_REG_MTH_MISC_AMT_1014)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_1015", SqlNull(CHQ_REG_MTH_MISC_AMT_1015)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_1016", SqlNull(CHQ_REG_MTH_MISC_AMT_1016)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_1017", SqlNull(CHQ_REG_MTH_MISC_AMT_1017)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_1018", SqlNull(CHQ_REG_MTH_MISC_AMT_1018)),
						new SqlParameter("CHQ_REG_MTH_EXP_AMT1", SqlNull(CHQ_REG_MTH_EXP_AMT1)),
						new SqlParameter("CHQ_REG_MTH_EXP_AMT2", SqlNull(CHQ_REG_MTH_EXP_AMT2)),
						new SqlParameter("CHQ_REG_MTH_EXP_AMT3", SqlNull(CHQ_REG_MTH_EXP_AMT3)),
						new SqlParameter("CHQ_REG_MTH_EXP_AMT4", SqlNull(CHQ_REG_MTH_EXP_AMT4)),
						new SqlParameter("CHQ_REG_MTH_EXP_AMT5", SqlNull(CHQ_REG_MTH_EXP_AMT5)),
						new SqlParameter("CHQ_REG_MTH_EXP_AMT6", SqlNull(CHQ_REG_MTH_EXP_AMT6)),
						new SqlParameter("CHQ_REG_MTH_EXP_AMT7", SqlNull(CHQ_REG_MTH_EXP_AMT7)),
						new SqlParameter("CHQ_REG_MTH_EXP_AMT8", SqlNull(CHQ_REG_MTH_EXP_AMT8)),
						new SqlParameter("CHQ_REG_MTH_EXP_AMT9", SqlNull(CHQ_REG_MTH_EXP_AMT9)),
						new SqlParameter("CHQ_REG_MTH_EXP_AMT10", SqlNull(CHQ_REG_MTH_EXP_AMT10)),
						new SqlParameter("CHQ_REG_MTH_EXP_AMT11", SqlNull(CHQ_REG_MTH_EXP_AMT11)),
						new SqlParameter("CHQ_REG_MTH_EXP_AMT12", SqlNull(CHQ_REG_MTH_EXP_AMT12)),
						new SqlParameter("CHQ_REG_MTH_EXP_AMT13", SqlNull(CHQ_REG_MTH_EXP_AMT13)),
						new SqlParameter("CHQ_REG_MTH_EXP_AMT14", SqlNull(CHQ_REG_MTH_EXP_AMT14)),
						new SqlParameter("CHQ_REG_MTH_EXP_AMT15", SqlNull(CHQ_REG_MTH_EXP_AMT15)),
						new SqlParameter("CHQ_REG_MTH_EXP_AMT16", SqlNull(CHQ_REG_MTH_EXP_AMT16)),
						new SqlParameter("CHQ_REG_MTH_EXP_AMT17", SqlNull(CHQ_REG_MTH_EXP_AMT17)),
						new SqlParameter("CHQ_REG_MTH_EXP_AMT18", SqlNull(CHQ_REG_MTH_EXP_AMT18)),
						new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY1", SqlNull(CHQ_REG_COMP_ANN_EXP_THIS_PAY1)),
						new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY2", SqlNull(CHQ_REG_COMP_ANN_EXP_THIS_PAY2)),
						new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY3", SqlNull(CHQ_REG_COMP_ANN_EXP_THIS_PAY3)),
						new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY4", SqlNull(CHQ_REG_COMP_ANN_EXP_THIS_PAY4)),
						new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY5", SqlNull(CHQ_REG_COMP_ANN_EXP_THIS_PAY5)),
						new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY6", SqlNull(CHQ_REG_COMP_ANN_EXP_THIS_PAY6)),
						new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY7", SqlNull(CHQ_REG_COMP_ANN_EXP_THIS_PAY7)),
						new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY8", SqlNull(CHQ_REG_COMP_ANN_EXP_THIS_PAY8)),
						new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY9", SqlNull(CHQ_REG_COMP_ANN_EXP_THIS_PAY9)),
						new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY10", SqlNull(CHQ_REG_COMP_ANN_EXP_THIS_PAY10)),
						new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY11", SqlNull(CHQ_REG_COMP_ANN_EXP_THIS_PAY11)),
						new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY12", SqlNull(CHQ_REG_COMP_ANN_EXP_THIS_PAY12)),
						new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY13", SqlNull(CHQ_REG_COMP_ANN_EXP_THIS_PAY13)),
						new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY14", SqlNull(CHQ_REG_COMP_ANN_EXP_THIS_PAY14)),
						new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY15", SqlNull(CHQ_REG_COMP_ANN_EXP_THIS_PAY15)),
						new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY16", SqlNull(CHQ_REG_COMP_ANN_EXP_THIS_PAY16)),
						new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY17", SqlNull(CHQ_REG_COMP_ANN_EXP_THIS_PAY17)),
						new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY18", SqlNull(CHQ_REG_COMP_ANN_EXP_THIS_PAY18)),
						new SqlParameter("CHQ_REG_MTH_CEIL_AMT1", SqlNull(CHQ_REG_MTH_CEIL_AMT1)),
						new SqlParameter("CHQ_REG_MTH_CEIL_AMT2", SqlNull(CHQ_REG_MTH_CEIL_AMT2)),
						new SqlParameter("CHQ_REG_MTH_CEIL_AMT3", SqlNull(CHQ_REG_MTH_CEIL_AMT3)),
						new SqlParameter("CHQ_REG_MTH_CEIL_AMT4", SqlNull(CHQ_REG_MTH_CEIL_AMT4)),
						new SqlParameter("CHQ_REG_MTH_CEIL_AMT5", SqlNull(CHQ_REG_MTH_CEIL_AMT5)),
						new SqlParameter("CHQ_REG_MTH_CEIL_AMT6", SqlNull(CHQ_REG_MTH_CEIL_AMT6)),
						new SqlParameter("CHQ_REG_MTH_CEIL_AMT7", SqlNull(CHQ_REG_MTH_CEIL_AMT7)),
						new SqlParameter("CHQ_REG_MTH_CEIL_AMT8", SqlNull(CHQ_REG_MTH_CEIL_AMT8)),
						new SqlParameter("CHQ_REG_MTH_CEIL_AMT9", SqlNull(CHQ_REG_MTH_CEIL_AMT9)),
						new SqlParameter("CHQ_REG_MTH_CEIL_AMT10", SqlNull(CHQ_REG_MTH_CEIL_AMT10)),
						new SqlParameter("CHQ_REG_MTH_CEIL_AMT11", SqlNull(CHQ_REG_MTH_CEIL_AMT11)),
						new SqlParameter("CHQ_REG_MTH_CEIL_AMT12", SqlNull(CHQ_REG_MTH_CEIL_AMT12)),
						new SqlParameter("CHQ_REG_MTH_CEIL_AMT13", SqlNull(CHQ_REG_MTH_CEIL_AMT13)),
						new SqlParameter("CHQ_REG_MTH_CEIL_AMT14", SqlNull(CHQ_REG_MTH_CEIL_AMT14)),
						new SqlParameter("CHQ_REG_MTH_CEIL_AMT15", SqlNull(CHQ_REG_MTH_CEIL_AMT15)),
						new SqlParameter("CHQ_REG_MTH_CEIL_AMT16", SqlNull(CHQ_REG_MTH_CEIL_AMT16)),
						new SqlParameter("CHQ_REG_MTH_CEIL_AMT17", SqlNull(CHQ_REG_MTH_CEIL_AMT17)),
						new SqlParameter("CHQ_REG_MTH_CEIL_AMT18", SqlNull(CHQ_REG_MTH_CEIL_AMT18)),
						new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY1", SqlNull(CHQ_REG_COMP_ANN_CEIL_THIS_PAY1)),
						new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY2", SqlNull(CHQ_REG_COMP_ANN_CEIL_THIS_PAY2)),
						new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY3", SqlNull(CHQ_REG_COMP_ANN_CEIL_THIS_PAY3)),
						new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY4", SqlNull(CHQ_REG_COMP_ANN_CEIL_THIS_PAY4)),
						new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY5", SqlNull(CHQ_REG_COMP_ANN_CEIL_THIS_PAY5)),
						new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY6", SqlNull(CHQ_REG_COMP_ANN_CEIL_THIS_PAY6)),
						new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY7", SqlNull(CHQ_REG_COMP_ANN_CEIL_THIS_PAY7)),
						new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY8", SqlNull(CHQ_REG_COMP_ANN_CEIL_THIS_PAY8)),
						new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY9", SqlNull(CHQ_REG_COMP_ANN_CEIL_THIS_PAY9)),
						new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY10", SqlNull(CHQ_REG_COMP_ANN_CEIL_THIS_PAY10)),
						new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY11", SqlNull(CHQ_REG_COMP_ANN_CEIL_THIS_PAY11)),
						new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY12", SqlNull(CHQ_REG_COMP_ANN_CEIL_THIS_PAY12)),
						new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY13", SqlNull(CHQ_REG_COMP_ANN_CEIL_THIS_PAY13)),
						new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY14", SqlNull(CHQ_REG_COMP_ANN_CEIL_THIS_PAY14)),
						new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY15", SqlNull(CHQ_REG_COMP_ANN_CEIL_THIS_PAY15)),
						new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY16", SqlNull(CHQ_REG_COMP_ANN_CEIL_THIS_PAY16)),
						new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY17", SqlNull(CHQ_REG_COMP_ANN_CEIL_THIS_PAY17)),
						new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY18", SqlNull(CHQ_REG_COMP_ANN_CEIL_THIS_PAY18)),
						new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH1", SqlNull(CHQ_REG_EARNINGS_THIS_MTH1)),
						new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH2", SqlNull(CHQ_REG_EARNINGS_THIS_MTH2)),
						new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH3", SqlNull(CHQ_REG_EARNINGS_THIS_MTH3)),
						new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH4", SqlNull(CHQ_REG_EARNINGS_THIS_MTH4)),
						new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH5", SqlNull(CHQ_REG_EARNINGS_THIS_MTH5)),
						new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH6", SqlNull(CHQ_REG_EARNINGS_THIS_MTH6)),
						new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH7", SqlNull(CHQ_REG_EARNINGS_THIS_MTH7)),
						new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH8", SqlNull(CHQ_REG_EARNINGS_THIS_MTH8)),
						new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH9", SqlNull(CHQ_REG_EARNINGS_THIS_MTH9)),
						new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH10", SqlNull(CHQ_REG_EARNINGS_THIS_MTH10)),
						new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH11", SqlNull(CHQ_REG_EARNINGS_THIS_MTH11)),
						new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH12", SqlNull(CHQ_REG_EARNINGS_THIS_MTH12)),
						new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH13", SqlNull(CHQ_REG_EARNINGS_THIS_MTH13)),
						new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH14", SqlNull(CHQ_REG_EARNINGS_THIS_MTH14)),
						new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH15", SqlNull(CHQ_REG_EARNINGS_THIS_MTH15)),
						new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH16", SqlNull(CHQ_REG_EARNINGS_THIS_MTH16)),
						new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH17", SqlNull(CHQ_REG_EARNINGS_THIS_MTH17)),
						new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH18", SqlNull(CHQ_REG_EARNINGS_THIS_MTH18)),
						new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH1", SqlNull(CHQ_REG_REGULAR_PAY_THIS_MTH1)),
						new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH2", SqlNull(CHQ_REG_REGULAR_PAY_THIS_MTH2)),
						new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH3", SqlNull(CHQ_REG_REGULAR_PAY_THIS_MTH3)),
						new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH4", SqlNull(CHQ_REG_REGULAR_PAY_THIS_MTH4)),
						new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH5", SqlNull(CHQ_REG_REGULAR_PAY_THIS_MTH5)),
						new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH6", SqlNull(CHQ_REG_REGULAR_PAY_THIS_MTH6)),
						new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH7", SqlNull(CHQ_REG_REGULAR_PAY_THIS_MTH7)),
						new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH8", SqlNull(CHQ_REG_REGULAR_PAY_THIS_MTH8)),
						new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH9", SqlNull(CHQ_REG_REGULAR_PAY_THIS_MTH9)),
						new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH10", SqlNull(CHQ_REG_REGULAR_PAY_THIS_MTH10)),
						new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH11", SqlNull(CHQ_REG_REGULAR_PAY_THIS_MTH11)),
						new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH12", SqlNull(CHQ_REG_REGULAR_PAY_THIS_MTH12)),
						new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH13", SqlNull(CHQ_REG_REGULAR_PAY_THIS_MTH13)),
						new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH14", SqlNull(CHQ_REG_REGULAR_PAY_THIS_MTH14)),
						new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH15", SqlNull(CHQ_REG_REGULAR_PAY_THIS_MTH15)),
						new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH16", SqlNull(CHQ_REG_REGULAR_PAY_THIS_MTH16)),
						new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH17", SqlNull(CHQ_REG_REGULAR_PAY_THIS_MTH17)),
						new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH18", SqlNull(CHQ_REG_REGULAR_PAY_THIS_MTH18)),
						new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH1", SqlNull(CHQ_REG_REGULAR_TAX_THIS_MTH1)),
						new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH2", SqlNull(CHQ_REG_REGULAR_TAX_THIS_MTH2)),
						new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH3", SqlNull(CHQ_REG_REGULAR_TAX_THIS_MTH3)),
						new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH4", SqlNull(CHQ_REG_REGULAR_TAX_THIS_MTH4)),
						new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH5", SqlNull(CHQ_REG_REGULAR_TAX_THIS_MTH5)),
						new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH6", SqlNull(CHQ_REG_REGULAR_TAX_THIS_MTH6)),
						new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH7", SqlNull(CHQ_REG_REGULAR_TAX_THIS_MTH7)),
						new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH8", SqlNull(CHQ_REG_REGULAR_TAX_THIS_MTH8)),
						new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH9", SqlNull(CHQ_REG_REGULAR_TAX_THIS_MTH9)),
						new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH10", SqlNull(CHQ_REG_REGULAR_TAX_THIS_MTH10)),
						new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH11", SqlNull(CHQ_REG_REGULAR_TAX_THIS_MTH11)),
						new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH12", SqlNull(CHQ_REG_REGULAR_TAX_THIS_MTH12)),
						new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH13", SqlNull(CHQ_REG_REGULAR_TAX_THIS_MTH13)),
						new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH14", SqlNull(CHQ_REG_REGULAR_TAX_THIS_MTH14)),
						new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH15", SqlNull(CHQ_REG_REGULAR_TAX_THIS_MTH15)),
						new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH16", SqlNull(CHQ_REG_REGULAR_TAX_THIS_MTH16)),
						new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH17", SqlNull(CHQ_REG_REGULAR_TAX_THIS_MTH17)),
						new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH18", SqlNull(CHQ_REG_REGULAR_TAX_THIS_MTH18)),
						new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH1", SqlNull(CHQ_REG_MAN_PAY_THIS_MTH1)),
						new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH2", SqlNull(CHQ_REG_MAN_PAY_THIS_MTH2)),
						new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH3", SqlNull(CHQ_REG_MAN_PAY_THIS_MTH3)),
						new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH4", SqlNull(CHQ_REG_MAN_PAY_THIS_MTH4)),
						new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH5", SqlNull(CHQ_REG_MAN_PAY_THIS_MTH5)),
						new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH6", SqlNull(CHQ_REG_MAN_PAY_THIS_MTH6)),
						new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH7", SqlNull(CHQ_REG_MAN_PAY_THIS_MTH7)),
						new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH8", SqlNull(CHQ_REG_MAN_PAY_THIS_MTH8)),
						new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH9", SqlNull(CHQ_REG_MAN_PAY_THIS_MTH9)),
						new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH10", SqlNull(CHQ_REG_MAN_PAY_THIS_MTH10)),
						new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH11", SqlNull(CHQ_REG_MAN_PAY_THIS_MTH11)),
						new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH12", SqlNull(CHQ_REG_MAN_PAY_THIS_MTH12)),
						new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH13", SqlNull(CHQ_REG_MAN_PAY_THIS_MTH13)),
						new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH14", SqlNull(CHQ_REG_MAN_PAY_THIS_MTH14)),
						new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH15", SqlNull(CHQ_REG_MAN_PAY_THIS_MTH15)),
						new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH16", SqlNull(CHQ_REG_MAN_PAY_THIS_MTH16)),
						new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH17", SqlNull(CHQ_REG_MAN_PAY_THIS_MTH17)),
						new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH18", SqlNull(CHQ_REG_MAN_PAY_THIS_MTH18)),
						new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH1", SqlNull(CHQ_REG_MAN_TAX_THIS_MTH1)),
						new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH2", SqlNull(CHQ_REG_MAN_TAX_THIS_MTH2)),
						new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH3", SqlNull(CHQ_REG_MAN_TAX_THIS_MTH3)),
						new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH4", SqlNull(CHQ_REG_MAN_TAX_THIS_MTH4)),
						new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH5", SqlNull(CHQ_REG_MAN_TAX_THIS_MTH5)),
						new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH6", SqlNull(CHQ_REG_MAN_TAX_THIS_MTH6)),
						new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH7", SqlNull(CHQ_REG_MAN_TAX_THIS_MTH7)),
						new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH8", SqlNull(CHQ_REG_MAN_TAX_THIS_MTH8)),
						new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH9", SqlNull(CHQ_REG_MAN_TAX_THIS_MTH9)),
						new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH10", SqlNull(CHQ_REG_MAN_TAX_THIS_MTH10)),
						new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH11", SqlNull(CHQ_REG_MAN_TAX_THIS_MTH11)),
						new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH12", SqlNull(CHQ_REG_MAN_TAX_THIS_MTH12)),
						new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH13", SqlNull(CHQ_REG_MAN_TAX_THIS_MTH13)),
						new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH14", SqlNull(CHQ_REG_MAN_TAX_THIS_MTH14)),
						new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH15", SqlNull(CHQ_REG_MAN_TAX_THIS_MTH15)),
						new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH16", SqlNull(CHQ_REG_MAN_TAX_THIS_MTH16)),
						new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH17", SqlNull(CHQ_REG_MAN_TAX_THIS_MTH17)),
						new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH18", SqlNull(CHQ_REG_MAN_TAX_THIS_MTH18)),
						new SqlParameter("CHQ_REG_PAY_DATE1", SqlNull(CHQ_REG_PAY_DATE1)),
						new SqlParameter("CHQ_REG_PAY_DATE2", SqlNull(CHQ_REG_PAY_DATE2)),
						new SqlParameter("CHQ_REG_PAY_DATE3", SqlNull(CHQ_REG_PAY_DATE3)),
						new SqlParameter("CHQ_REG_PAY_DATE4", SqlNull(CHQ_REG_PAY_DATE4)),
						new SqlParameter("CHQ_REG_PAY_DATE5", SqlNull(CHQ_REG_PAY_DATE5)),
						new SqlParameter("CHQ_REG_PAY_DATE6", SqlNull(CHQ_REG_PAY_DATE6)),
						new SqlParameter("CHQ_REG_PAY_DATE7", SqlNull(CHQ_REG_PAY_DATE7)),
						new SqlParameter("CHQ_REG_PAY_DATE8", SqlNull(CHQ_REG_PAY_DATE8)),
						new SqlParameter("CHQ_REG_PAY_DATE9", SqlNull(CHQ_REG_PAY_DATE9)),
						new SqlParameter("CHQ_REG_PAY_DATE10", SqlNull(CHQ_REG_PAY_DATE10)),
						new SqlParameter("CHQ_REG_PAY_DATE11", SqlNull(CHQ_REG_PAY_DATE11)),
						new SqlParameter("CHQ_REG_PAY_DATE12", SqlNull(CHQ_REG_PAY_DATE12)),
						new SqlParameter("CHQ_REG_PAY_DATE13", SqlNull(CHQ_REG_PAY_DATE13)),
						new SqlParameter("CHQ_REG_PAY_DATE14", SqlNull(CHQ_REG_PAY_DATE14)),
						new SqlParameter("CHQ_REG_PAY_DATE15", SqlNull(CHQ_REG_PAY_DATE15)),
						new SqlParameter("CHQ_REG_PAY_DATE16", SqlNull(CHQ_REG_PAY_DATE16)),
						new SqlParameter("CHQ_REG_PAY_DATE17", SqlNull(CHQ_REG_PAY_DATE17)),
						new SqlParameter("CHQ_REG_PAY_DATE18", SqlNull(CHQ_REG_PAY_DATE18)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F060_CHEQUE_REG_MSTR_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CHQ_REG_CLINIC_NBR_1_2 = ConvertDEC(Reader["CHQ_REG_CLINIC_NBR_1_2"]);
						CHQ_REG_DEPT = ConvertDEC(Reader["CHQ_REG_DEPT"]);
						CHQ_REG_DOC_NBR = Reader["CHQ_REG_DOC_NBR"].ToString();
						CHQ_REG_PERC_BILL1 = ConvertDEC(Reader["CHQ_REG_PERC_BILL1"]);
						CHQ_REG_PERC_BILL2 = ConvertDEC(Reader["CHQ_REG_PERC_BILL2"]);
						CHQ_REG_PERC_BILL3 = ConvertDEC(Reader["CHQ_REG_PERC_BILL3"]);
						CHQ_REG_PERC_BILL4 = ConvertDEC(Reader["CHQ_REG_PERC_BILL4"]);
						CHQ_REG_PERC_BILL5 = ConvertDEC(Reader["CHQ_REG_PERC_BILL5"]);
						CHQ_REG_PERC_BILL6 = ConvertDEC(Reader["CHQ_REG_PERC_BILL6"]);
						CHQ_REG_PERC_BILL7 = ConvertDEC(Reader["CHQ_REG_PERC_BILL7"]);
						CHQ_REG_PERC_BILL8 = ConvertDEC(Reader["CHQ_REG_PERC_BILL8"]);
						CHQ_REG_PERC_BILL9 = ConvertDEC(Reader["CHQ_REG_PERC_BILL9"]);
						CHQ_REG_PERC_BILL10 = ConvertDEC(Reader["CHQ_REG_PERC_BILL10"]);
						CHQ_REG_PERC_BILL11 = ConvertDEC(Reader["CHQ_REG_PERC_BILL11"]);
						CHQ_REG_PERC_BILL12 = ConvertDEC(Reader["CHQ_REG_PERC_BILL12"]);
						CHQ_REG_PERC_BILL13 = ConvertDEC(Reader["CHQ_REG_PERC_BILL13"]);
						CHQ_REG_PERC_BILL14 = ConvertDEC(Reader["CHQ_REG_PERC_BILL14"]);
						CHQ_REG_PERC_BILL15 = ConvertDEC(Reader["CHQ_REG_PERC_BILL15"]);
						CHQ_REG_PERC_BILL16 = ConvertDEC(Reader["CHQ_REG_PERC_BILL16"]);
						CHQ_REG_PERC_BILL17 = ConvertDEC(Reader["CHQ_REG_PERC_BILL17"]);
						CHQ_REG_PERC_BILL18 = ConvertDEC(Reader["CHQ_REG_PERC_BILL18"]);
						CHQ_REG_PERC_MISC1 = ConvertDEC(Reader["CHQ_REG_PERC_MISC1"]);
						CHQ_REG_PERC_MISC2 = ConvertDEC(Reader["CHQ_REG_PERC_MISC2"]);
						CHQ_REG_PERC_MISC3 = ConvertDEC(Reader["CHQ_REG_PERC_MISC3"]);
						CHQ_REG_PERC_MISC4 = ConvertDEC(Reader["CHQ_REG_PERC_MISC4"]);
						CHQ_REG_PERC_MISC5 = ConvertDEC(Reader["CHQ_REG_PERC_MISC5"]);
						CHQ_REG_PERC_MISC6 = ConvertDEC(Reader["CHQ_REG_PERC_MISC6"]);
						CHQ_REG_PERC_MISC7 = ConvertDEC(Reader["CHQ_REG_PERC_MISC7"]);
						CHQ_REG_PERC_MISC8 = ConvertDEC(Reader["CHQ_REG_PERC_MISC8"]);
						CHQ_REG_PERC_MISC9 = ConvertDEC(Reader["CHQ_REG_PERC_MISC9"]);
						CHQ_REG_PERC_MISC10 = ConvertDEC(Reader["CHQ_REG_PERC_MISC10"]);
						CHQ_REG_PERC_MISC11 = ConvertDEC(Reader["CHQ_REG_PERC_MISC11"]);
						CHQ_REG_PERC_MISC12 = ConvertDEC(Reader["CHQ_REG_PERC_MISC12"]);
						CHQ_REG_PERC_MISC13 = ConvertDEC(Reader["CHQ_REG_PERC_MISC13"]);
						CHQ_REG_PERC_MISC14 = ConvertDEC(Reader["CHQ_REG_PERC_MISC14"]);
						CHQ_REG_PERC_MISC15 = ConvertDEC(Reader["CHQ_REG_PERC_MISC15"]);
						CHQ_REG_PERC_MISC16 = ConvertDEC(Reader["CHQ_REG_PERC_MISC16"]);
						CHQ_REG_PERC_MISC17 = ConvertDEC(Reader["CHQ_REG_PERC_MISC17"]);
						CHQ_REG_PERC_MISC18 = ConvertDEC(Reader["CHQ_REG_PERC_MISC18"]);
						CHQ_REG_PAY_CODE1 = Reader["CHQ_REG_PAY_CODE1"].ToString();
						CHQ_REG_PAY_CODE2 = Reader["CHQ_REG_PAY_CODE2"].ToString();
						CHQ_REG_PAY_CODE3 = Reader["CHQ_REG_PAY_CODE3"].ToString();
						CHQ_REG_PAY_CODE4 = Reader["CHQ_REG_PAY_CODE4"].ToString();
						CHQ_REG_PAY_CODE5 = Reader["CHQ_REG_PAY_CODE5"].ToString();
						CHQ_REG_PAY_CODE6 = Reader["CHQ_REG_PAY_CODE6"].ToString();
						CHQ_REG_PAY_CODE7 = Reader["CHQ_REG_PAY_CODE7"].ToString();
						CHQ_REG_PAY_CODE8 = Reader["CHQ_REG_PAY_CODE8"].ToString();
						CHQ_REG_PAY_CODE9 = Reader["CHQ_REG_PAY_CODE9"].ToString();
						CHQ_REG_PAY_CODE10 = Reader["CHQ_REG_PAY_CODE10"].ToString();
						CHQ_REG_PAY_CODE11 = Reader["CHQ_REG_PAY_CODE11"].ToString();
						CHQ_REG_PAY_CODE12 = Reader["CHQ_REG_PAY_CODE12"].ToString();
						CHQ_REG_PAY_CODE13 = Reader["CHQ_REG_PAY_CODE13"].ToString();
						CHQ_REG_PAY_CODE14 = Reader["CHQ_REG_PAY_CODE14"].ToString();
						CHQ_REG_PAY_CODE15 = Reader["CHQ_REG_PAY_CODE15"].ToString();
						CHQ_REG_PAY_CODE16 = Reader["CHQ_REG_PAY_CODE16"].ToString();
						CHQ_REG_PAY_CODE17 = Reader["CHQ_REG_PAY_CODE17"].ToString();
						CHQ_REG_PAY_CODE18 = Reader["CHQ_REG_PAY_CODE18"].ToString();
						CHQ_REG_PERC_TAX1 = ConvertDEC(Reader["CHQ_REG_PERC_TAX1"]);
						CHQ_REG_PERC_TAX2 = ConvertDEC(Reader["CHQ_REG_PERC_TAX2"]);
						CHQ_REG_PERC_TAX3 = ConvertDEC(Reader["CHQ_REG_PERC_TAX3"]);
						CHQ_REG_PERC_TAX4 = ConvertDEC(Reader["CHQ_REG_PERC_TAX4"]);
						CHQ_REG_PERC_TAX5 = ConvertDEC(Reader["CHQ_REG_PERC_TAX5"]);
						CHQ_REG_PERC_TAX6 = ConvertDEC(Reader["CHQ_REG_PERC_TAX6"]);
						CHQ_REG_PERC_TAX7 = ConvertDEC(Reader["CHQ_REG_PERC_TAX7"]);
						CHQ_REG_PERC_TAX8 = ConvertDEC(Reader["CHQ_REG_PERC_TAX8"]);
						CHQ_REG_PERC_TAX9 = ConvertDEC(Reader["CHQ_REG_PERC_TAX9"]);
						CHQ_REG_PERC_TAX10 = ConvertDEC(Reader["CHQ_REG_PERC_TAX10"]);
						CHQ_REG_PERC_TAX11 = ConvertDEC(Reader["CHQ_REG_PERC_TAX11"]);
						CHQ_REG_PERC_TAX12 = ConvertDEC(Reader["CHQ_REG_PERC_TAX12"]);
						CHQ_REG_PERC_TAX13 = ConvertDEC(Reader["CHQ_REG_PERC_TAX13"]);
						CHQ_REG_PERC_TAX14 = ConvertDEC(Reader["CHQ_REG_PERC_TAX14"]);
						CHQ_REG_PERC_TAX15 = ConvertDEC(Reader["CHQ_REG_PERC_TAX15"]);
						CHQ_REG_PERC_TAX16 = ConvertDEC(Reader["CHQ_REG_PERC_TAX16"]);
						CHQ_REG_PERC_TAX17 = ConvertDEC(Reader["CHQ_REG_PERC_TAX17"]);
						CHQ_REG_PERC_TAX18 = ConvertDEC(Reader["CHQ_REG_PERC_TAX18"]);
						CHQ_REG_MTH_BILL_AMT1 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT1"]);
						CHQ_REG_MTH_BILL_AMT2 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT2"]);
						CHQ_REG_MTH_BILL_AMT3 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT3"]);
						CHQ_REG_MTH_BILL_AMT4 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT4"]);
						CHQ_REG_MTH_BILL_AMT5 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT5"]);
						CHQ_REG_MTH_BILL_AMT6 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT6"]);
						CHQ_REG_MTH_BILL_AMT7 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT7"]);
						CHQ_REG_MTH_BILL_AMT8 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT8"]);
						CHQ_REG_MTH_BILL_AMT9 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT9"]);
						CHQ_REG_MTH_BILL_AMT10 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT10"]);
						CHQ_REG_MTH_BILL_AMT11 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT11"]);
						CHQ_REG_MTH_BILL_AMT12 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT12"]);
						CHQ_REG_MTH_BILL_AMT13 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT13"]);
						CHQ_REG_MTH_BILL_AMT14 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT14"]);
						CHQ_REG_MTH_BILL_AMT15 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT15"]);
						CHQ_REG_MTH_BILL_AMT16 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT16"]);
						CHQ_REG_MTH_BILL_AMT17 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT17"]);
						CHQ_REG_MTH_BILL_AMT18 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT18"]);
						CHQ_REG_MTH_MISC_AMT_11 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_11"]);
						CHQ_REG_MTH_MISC_AMT_12 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_12"]);
						CHQ_REG_MTH_MISC_AMT_13 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_13"]);
						CHQ_REG_MTH_MISC_AMT_14 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_14"]);
						CHQ_REG_MTH_MISC_AMT_15 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_15"]);
						CHQ_REG_MTH_MISC_AMT_16 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_16"]);
						CHQ_REG_MTH_MISC_AMT_17 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_17"]);
						CHQ_REG_MTH_MISC_AMT_18 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_18"]);
						CHQ_REG_MTH_MISC_AMT_19 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_19"]);
						CHQ_REG_MTH_MISC_AMT_110 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_110"]);
						CHQ_REG_MTH_MISC_AMT_111 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_111"]);
						CHQ_REG_MTH_MISC_AMT_112 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_112"]);
						CHQ_REG_MTH_MISC_AMT_113 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_113"]);
						CHQ_REG_MTH_MISC_AMT_114 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_114"]);
						CHQ_REG_MTH_MISC_AMT_115 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_115"]);
						CHQ_REG_MTH_MISC_AMT_116 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_116"]);
						CHQ_REG_MTH_MISC_AMT_117 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_117"]);
						CHQ_REG_MTH_MISC_AMT_118 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_118"]);
						CHQ_REG_MTH_MISC_AMT_21 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_21"]);
						CHQ_REG_MTH_MISC_AMT_22 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_22"]);
						CHQ_REG_MTH_MISC_AMT_23 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_23"]);
						CHQ_REG_MTH_MISC_AMT_24 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_24"]);
						CHQ_REG_MTH_MISC_AMT_25 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_25"]);
						CHQ_REG_MTH_MISC_AMT_26 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_26"]);
						CHQ_REG_MTH_MISC_AMT_27 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_27"]);
						CHQ_REG_MTH_MISC_AMT_28 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_28"]);
						CHQ_REG_MTH_MISC_AMT_29 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_29"]);
						CHQ_REG_MTH_MISC_AMT_210 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_210"]);
						CHQ_REG_MTH_MISC_AMT_211 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_211"]);
						CHQ_REG_MTH_MISC_AMT_212 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_212"]);
						CHQ_REG_MTH_MISC_AMT_213 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_213"]);
						CHQ_REG_MTH_MISC_AMT_214 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_214"]);
						CHQ_REG_MTH_MISC_AMT_215 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_215"]);
						CHQ_REG_MTH_MISC_AMT_216 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_216"]);
						CHQ_REG_MTH_MISC_AMT_217 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_217"]);
						CHQ_REG_MTH_MISC_AMT_218 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_218"]);
						CHQ_REG_MTH_MISC_AMT_31 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_31"]);
						CHQ_REG_MTH_MISC_AMT_32 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_32"]);
						CHQ_REG_MTH_MISC_AMT_33 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_33"]);
						CHQ_REG_MTH_MISC_AMT_34 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_34"]);
						CHQ_REG_MTH_MISC_AMT_35 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_35"]);
						CHQ_REG_MTH_MISC_AMT_36 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_36"]);
						CHQ_REG_MTH_MISC_AMT_37 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_37"]);
						CHQ_REG_MTH_MISC_AMT_38 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_38"]);
						CHQ_REG_MTH_MISC_AMT_39 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_39"]);
						CHQ_REG_MTH_MISC_AMT_310 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_310"]);
						CHQ_REG_MTH_MISC_AMT_311 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_311"]);
						CHQ_REG_MTH_MISC_AMT_312 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_312"]);
						CHQ_REG_MTH_MISC_AMT_313 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_313"]);
						CHQ_REG_MTH_MISC_AMT_314 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_314"]);
						CHQ_REG_MTH_MISC_AMT_315 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_315"]);
						CHQ_REG_MTH_MISC_AMT_316 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_316"]);
						CHQ_REG_MTH_MISC_AMT_317 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_317"]);
						CHQ_REG_MTH_MISC_AMT_318 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_318"]);
						CHQ_REG_MTH_MISC_AMT_41 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_41"]);
						CHQ_REG_MTH_MISC_AMT_42 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_42"]);
						CHQ_REG_MTH_MISC_AMT_43 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_43"]);
						CHQ_REG_MTH_MISC_AMT_44 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_44"]);
						CHQ_REG_MTH_MISC_AMT_45 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_45"]);
						CHQ_REG_MTH_MISC_AMT_46 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_46"]);
						CHQ_REG_MTH_MISC_AMT_47 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_47"]);
						CHQ_REG_MTH_MISC_AMT_48 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_48"]);
						CHQ_REG_MTH_MISC_AMT_49 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_49"]);
						CHQ_REG_MTH_MISC_AMT_410 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_410"]);
						CHQ_REG_MTH_MISC_AMT_411 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_411"]);
						CHQ_REG_MTH_MISC_AMT_412 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_412"]);
						CHQ_REG_MTH_MISC_AMT_413 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_413"]);
						CHQ_REG_MTH_MISC_AMT_414 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_414"]);
						CHQ_REG_MTH_MISC_AMT_415 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_415"]);
						CHQ_REG_MTH_MISC_AMT_416 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_416"]);
						CHQ_REG_MTH_MISC_AMT_417 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_417"]);
						CHQ_REG_MTH_MISC_AMT_418 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_418"]);
						CHQ_REG_MTH_MISC_AMT_51 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_51"]);
						CHQ_REG_MTH_MISC_AMT_52 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_52"]);
						CHQ_REG_MTH_MISC_AMT_53 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_53"]);
						CHQ_REG_MTH_MISC_AMT_54 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_54"]);
						CHQ_REG_MTH_MISC_AMT_55 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_55"]);
						CHQ_REG_MTH_MISC_AMT_56 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_56"]);
						CHQ_REG_MTH_MISC_AMT_57 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_57"]);
						CHQ_REG_MTH_MISC_AMT_58 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_58"]);
						CHQ_REG_MTH_MISC_AMT_59 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_59"]);
						CHQ_REG_MTH_MISC_AMT_510 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_510"]);
						CHQ_REG_MTH_MISC_AMT_511 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_511"]);
						CHQ_REG_MTH_MISC_AMT_512 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_512"]);
						CHQ_REG_MTH_MISC_AMT_513 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_513"]);
						CHQ_REG_MTH_MISC_AMT_514 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_514"]);
						CHQ_REG_MTH_MISC_AMT_515 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_515"]);
						CHQ_REG_MTH_MISC_AMT_516 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_516"]);
						CHQ_REG_MTH_MISC_AMT_517 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_517"]);
						CHQ_REG_MTH_MISC_AMT_518 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_518"]);
						CHQ_REG_MTH_MISC_AMT_61 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_61"]);
						CHQ_REG_MTH_MISC_AMT_62 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_62"]);
						CHQ_REG_MTH_MISC_AMT_63 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_63"]);
						CHQ_REG_MTH_MISC_AMT_64 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_64"]);
						CHQ_REG_MTH_MISC_AMT_65 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_65"]);
						CHQ_REG_MTH_MISC_AMT_66 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_66"]);
						CHQ_REG_MTH_MISC_AMT_67 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_67"]);
						CHQ_REG_MTH_MISC_AMT_68 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_68"]);
						CHQ_REG_MTH_MISC_AMT_69 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_69"]);
						CHQ_REG_MTH_MISC_AMT_610 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_610"]);
						CHQ_REG_MTH_MISC_AMT_611 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_611"]);
						CHQ_REG_MTH_MISC_AMT_612 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_612"]);
						CHQ_REG_MTH_MISC_AMT_613 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_613"]);
						CHQ_REG_MTH_MISC_AMT_614 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_614"]);
						CHQ_REG_MTH_MISC_AMT_615 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_615"]);
						CHQ_REG_MTH_MISC_AMT_616 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_616"]);
						CHQ_REG_MTH_MISC_AMT_617 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_617"]);
						CHQ_REG_MTH_MISC_AMT_618 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_618"]);
						CHQ_REG_MTH_MISC_AMT_71 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_71"]);
						CHQ_REG_MTH_MISC_AMT_72 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_72"]);
						CHQ_REG_MTH_MISC_AMT_73 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_73"]);
						CHQ_REG_MTH_MISC_AMT_74 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_74"]);
						CHQ_REG_MTH_MISC_AMT_75 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_75"]);
						CHQ_REG_MTH_MISC_AMT_76 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_76"]);
						CHQ_REG_MTH_MISC_AMT_77 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_77"]);
						CHQ_REG_MTH_MISC_AMT_78 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_78"]);
						CHQ_REG_MTH_MISC_AMT_79 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_79"]);
						CHQ_REG_MTH_MISC_AMT_710 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_710"]);
						CHQ_REG_MTH_MISC_AMT_711 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_711"]);
						CHQ_REG_MTH_MISC_AMT_712 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_712"]);
						CHQ_REG_MTH_MISC_AMT_713 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_713"]);
						CHQ_REG_MTH_MISC_AMT_714 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_714"]);
						CHQ_REG_MTH_MISC_AMT_715 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_715"]);
						CHQ_REG_MTH_MISC_AMT_716 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_716"]);
						CHQ_REG_MTH_MISC_AMT_717 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_717"]);
						CHQ_REG_MTH_MISC_AMT_718 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_718"]);
						CHQ_REG_MTH_MISC_AMT_81 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_81"]);
						CHQ_REG_MTH_MISC_AMT_82 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_82"]);
						CHQ_REG_MTH_MISC_AMT_83 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_83"]);
						CHQ_REG_MTH_MISC_AMT_84 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_84"]);
						CHQ_REG_MTH_MISC_AMT_85 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_85"]);
						CHQ_REG_MTH_MISC_AMT_86 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_86"]);
						CHQ_REG_MTH_MISC_AMT_87 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_87"]);
						CHQ_REG_MTH_MISC_AMT_88 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_88"]);
						CHQ_REG_MTH_MISC_AMT_89 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_89"]);
						CHQ_REG_MTH_MISC_AMT_810 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_810"]);
						CHQ_REG_MTH_MISC_AMT_811 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_811"]);
						CHQ_REG_MTH_MISC_AMT_812 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_812"]);
						CHQ_REG_MTH_MISC_AMT_813 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_813"]);
						CHQ_REG_MTH_MISC_AMT_814 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_814"]);
						CHQ_REG_MTH_MISC_AMT_815 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_815"]);
						CHQ_REG_MTH_MISC_AMT_816 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_816"]);
						CHQ_REG_MTH_MISC_AMT_817 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_817"]);
						CHQ_REG_MTH_MISC_AMT_818 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_818"]);
						CHQ_REG_MTH_MISC_AMT_91 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_91"]);
						CHQ_REG_MTH_MISC_AMT_92 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_92"]);
						CHQ_REG_MTH_MISC_AMT_93 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_93"]);
						CHQ_REG_MTH_MISC_AMT_94 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_94"]);
						CHQ_REG_MTH_MISC_AMT_95 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_95"]);
						CHQ_REG_MTH_MISC_AMT_96 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_96"]);
						CHQ_REG_MTH_MISC_AMT_97 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_97"]);
						CHQ_REG_MTH_MISC_AMT_98 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_98"]);
						CHQ_REG_MTH_MISC_AMT_99 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_99"]);
						CHQ_REG_MTH_MISC_AMT_910 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_910"]);
						CHQ_REG_MTH_MISC_AMT_911 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_911"]);
						CHQ_REG_MTH_MISC_AMT_912 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_912"]);
						CHQ_REG_MTH_MISC_AMT_913 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_913"]);
						CHQ_REG_MTH_MISC_AMT_914 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_914"]);
						CHQ_REG_MTH_MISC_AMT_915 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_915"]);
						CHQ_REG_MTH_MISC_AMT_916 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_916"]);
						CHQ_REG_MTH_MISC_AMT_917 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_917"]);
						CHQ_REG_MTH_MISC_AMT_918 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_918"]);
						CHQ_REG_MTH_MISC_AMT_101 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_101"]);
						CHQ_REG_MTH_MISC_AMT_102 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_102"]);
						CHQ_REG_MTH_MISC_AMT_103 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_103"]);
						CHQ_REG_MTH_MISC_AMT_104 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_104"]);
						CHQ_REG_MTH_MISC_AMT_105 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_105"]);
						CHQ_REG_MTH_MISC_AMT_106 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_106"]);
						CHQ_REG_MTH_MISC_AMT_107 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_107"]);
						CHQ_REG_MTH_MISC_AMT_108 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_108"]);
						CHQ_REG_MTH_MISC_AMT_109 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_109"]);
						CHQ_REG_MTH_MISC_AMT_1010 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1010"]);
						CHQ_REG_MTH_MISC_AMT_1011 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1011"]);
						CHQ_REG_MTH_MISC_AMT_1012 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1012"]);
						CHQ_REG_MTH_MISC_AMT_1013 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1013"]);
						CHQ_REG_MTH_MISC_AMT_1014 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1014"]);
						CHQ_REG_MTH_MISC_AMT_1015 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1015"]);
						CHQ_REG_MTH_MISC_AMT_1016 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1016"]);
						CHQ_REG_MTH_MISC_AMT_1017 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1017"]);
						CHQ_REG_MTH_MISC_AMT_1018 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1018"]);
						CHQ_REG_MTH_EXP_AMT1 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT1"]);
						CHQ_REG_MTH_EXP_AMT2 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT2"]);
						CHQ_REG_MTH_EXP_AMT3 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT3"]);
						CHQ_REG_MTH_EXP_AMT4 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT4"]);
						CHQ_REG_MTH_EXP_AMT5 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT5"]);
						CHQ_REG_MTH_EXP_AMT6 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT6"]);
						CHQ_REG_MTH_EXP_AMT7 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT7"]);
						CHQ_REG_MTH_EXP_AMT8 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT8"]);
						CHQ_REG_MTH_EXP_AMT9 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT9"]);
						CHQ_REG_MTH_EXP_AMT10 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT10"]);
						CHQ_REG_MTH_EXP_AMT11 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT11"]);
						CHQ_REG_MTH_EXP_AMT12 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT12"]);
						CHQ_REG_MTH_EXP_AMT13 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT13"]);
						CHQ_REG_MTH_EXP_AMT14 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT14"]);
						CHQ_REG_MTH_EXP_AMT15 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT15"]);
						CHQ_REG_MTH_EXP_AMT16 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT16"]);
						CHQ_REG_MTH_EXP_AMT17 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT17"]);
						CHQ_REG_MTH_EXP_AMT18 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT18"]);
						CHQ_REG_COMP_ANN_EXP_THIS_PAY1 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY1"]);
						CHQ_REG_COMP_ANN_EXP_THIS_PAY2 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY2"]);
						CHQ_REG_COMP_ANN_EXP_THIS_PAY3 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY3"]);
						CHQ_REG_COMP_ANN_EXP_THIS_PAY4 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY4"]);
						CHQ_REG_COMP_ANN_EXP_THIS_PAY5 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY5"]);
						CHQ_REG_COMP_ANN_EXP_THIS_PAY6 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY6"]);
						CHQ_REG_COMP_ANN_EXP_THIS_PAY7 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY7"]);
						CHQ_REG_COMP_ANN_EXP_THIS_PAY8 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY8"]);
						CHQ_REG_COMP_ANN_EXP_THIS_PAY9 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY9"]);
						CHQ_REG_COMP_ANN_EXP_THIS_PAY10 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY10"]);
						CHQ_REG_COMP_ANN_EXP_THIS_PAY11 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY11"]);
						CHQ_REG_COMP_ANN_EXP_THIS_PAY12 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY12"]);
						CHQ_REG_COMP_ANN_EXP_THIS_PAY13 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY13"]);
						CHQ_REG_COMP_ANN_EXP_THIS_PAY14 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY14"]);
						CHQ_REG_COMP_ANN_EXP_THIS_PAY15 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY15"]);
						CHQ_REG_COMP_ANN_EXP_THIS_PAY16 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY16"]);
						CHQ_REG_COMP_ANN_EXP_THIS_PAY17 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY17"]);
						CHQ_REG_COMP_ANN_EXP_THIS_PAY18 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY18"]);
						CHQ_REG_MTH_CEIL_AMT1 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT1"]);
						CHQ_REG_MTH_CEIL_AMT2 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT2"]);
						CHQ_REG_MTH_CEIL_AMT3 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT3"]);
						CHQ_REG_MTH_CEIL_AMT4 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT4"]);
						CHQ_REG_MTH_CEIL_AMT5 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT5"]);
						CHQ_REG_MTH_CEIL_AMT6 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT6"]);
						CHQ_REG_MTH_CEIL_AMT7 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT7"]);
						CHQ_REG_MTH_CEIL_AMT8 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT8"]);
						CHQ_REG_MTH_CEIL_AMT9 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT9"]);
						CHQ_REG_MTH_CEIL_AMT10 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT10"]);
						CHQ_REG_MTH_CEIL_AMT11 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT11"]);
						CHQ_REG_MTH_CEIL_AMT12 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT12"]);
						CHQ_REG_MTH_CEIL_AMT13 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT13"]);
						CHQ_REG_MTH_CEIL_AMT14 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT14"]);
						CHQ_REG_MTH_CEIL_AMT15 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT15"]);
						CHQ_REG_MTH_CEIL_AMT16 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT16"]);
						CHQ_REG_MTH_CEIL_AMT17 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT17"]);
						CHQ_REG_MTH_CEIL_AMT18 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT18"]);
						CHQ_REG_COMP_ANN_CEIL_THIS_PAY1 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY1"]);
						CHQ_REG_COMP_ANN_CEIL_THIS_PAY2 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY2"]);
						CHQ_REG_COMP_ANN_CEIL_THIS_PAY3 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY3"]);
						CHQ_REG_COMP_ANN_CEIL_THIS_PAY4 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY4"]);
						CHQ_REG_COMP_ANN_CEIL_THIS_PAY5 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY5"]);
						CHQ_REG_COMP_ANN_CEIL_THIS_PAY6 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY6"]);
						CHQ_REG_COMP_ANN_CEIL_THIS_PAY7 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY7"]);
						CHQ_REG_COMP_ANN_CEIL_THIS_PAY8 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY8"]);
						CHQ_REG_COMP_ANN_CEIL_THIS_PAY9 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY9"]);
						CHQ_REG_COMP_ANN_CEIL_THIS_PAY10 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY10"]);
						CHQ_REG_COMP_ANN_CEIL_THIS_PAY11 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY11"]);
						CHQ_REG_COMP_ANN_CEIL_THIS_PAY12 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY12"]);
						CHQ_REG_COMP_ANN_CEIL_THIS_PAY13 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY13"]);
						CHQ_REG_COMP_ANN_CEIL_THIS_PAY14 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY14"]);
						CHQ_REG_COMP_ANN_CEIL_THIS_PAY15 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY15"]);
						CHQ_REG_COMP_ANN_CEIL_THIS_PAY16 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY16"]);
						CHQ_REG_COMP_ANN_CEIL_THIS_PAY17 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY17"]);
						CHQ_REG_COMP_ANN_CEIL_THIS_PAY18 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY18"]);
						CHQ_REG_EARNINGS_THIS_MTH1 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH1"]);
						CHQ_REG_EARNINGS_THIS_MTH2 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH2"]);
						CHQ_REG_EARNINGS_THIS_MTH3 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH3"]);
						CHQ_REG_EARNINGS_THIS_MTH4 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH4"]);
						CHQ_REG_EARNINGS_THIS_MTH5 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH5"]);
						CHQ_REG_EARNINGS_THIS_MTH6 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH6"]);
						CHQ_REG_EARNINGS_THIS_MTH7 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH7"]);
						CHQ_REG_EARNINGS_THIS_MTH8 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH8"]);
						CHQ_REG_EARNINGS_THIS_MTH9 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH9"]);
						CHQ_REG_EARNINGS_THIS_MTH10 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH10"]);
						CHQ_REG_EARNINGS_THIS_MTH11 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH11"]);
						CHQ_REG_EARNINGS_THIS_MTH12 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH12"]);
						CHQ_REG_EARNINGS_THIS_MTH13 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH13"]);
						CHQ_REG_EARNINGS_THIS_MTH14 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH14"]);
						CHQ_REG_EARNINGS_THIS_MTH15 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH15"]);
						CHQ_REG_EARNINGS_THIS_MTH16 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH16"]);
						CHQ_REG_EARNINGS_THIS_MTH17 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH17"]);
						CHQ_REG_EARNINGS_THIS_MTH18 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH18"]);
						CHQ_REG_REGULAR_PAY_THIS_MTH1 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH1"]);
						CHQ_REG_REGULAR_PAY_THIS_MTH2 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH2"]);
						CHQ_REG_REGULAR_PAY_THIS_MTH3 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH3"]);
						CHQ_REG_REGULAR_PAY_THIS_MTH4 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH4"]);
						CHQ_REG_REGULAR_PAY_THIS_MTH5 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH5"]);
						CHQ_REG_REGULAR_PAY_THIS_MTH6 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH6"]);
						CHQ_REG_REGULAR_PAY_THIS_MTH7 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH7"]);
						CHQ_REG_REGULAR_PAY_THIS_MTH8 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH8"]);
						CHQ_REG_REGULAR_PAY_THIS_MTH9 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH9"]);
						CHQ_REG_REGULAR_PAY_THIS_MTH10 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH10"]);
						CHQ_REG_REGULAR_PAY_THIS_MTH11 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH11"]);
						CHQ_REG_REGULAR_PAY_THIS_MTH12 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH12"]);
						CHQ_REG_REGULAR_PAY_THIS_MTH13 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH13"]);
						CHQ_REG_REGULAR_PAY_THIS_MTH14 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH14"]);
						CHQ_REG_REGULAR_PAY_THIS_MTH15 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH15"]);
						CHQ_REG_REGULAR_PAY_THIS_MTH16 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH16"]);
						CHQ_REG_REGULAR_PAY_THIS_MTH17 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH17"]);
						CHQ_REG_REGULAR_PAY_THIS_MTH18 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH18"]);
						CHQ_REG_REGULAR_TAX_THIS_MTH1 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH1"]);
						CHQ_REG_REGULAR_TAX_THIS_MTH2 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH2"]);
						CHQ_REG_REGULAR_TAX_THIS_MTH3 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH3"]);
						CHQ_REG_REGULAR_TAX_THIS_MTH4 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH4"]);
						CHQ_REG_REGULAR_TAX_THIS_MTH5 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH5"]);
						CHQ_REG_REGULAR_TAX_THIS_MTH6 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH6"]);
						CHQ_REG_REGULAR_TAX_THIS_MTH7 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH7"]);
						CHQ_REG_REGULAR_TAX_THIS_MTH8 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH8"]);
						CHQ_REG_REGULAR_TAX_THIS_MTH9 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH9"]);
						CHQ_REG_REGULAR_TAX_THIS_MTH10 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH10"]);
						CHQ_REG_REGULAR_TAX_THIS_MTH11 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH11"]);
						CHQ_REG_REGULAR_TAX_THIS_MTH12 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH12"]);
						CHQ_REG_REGULAR_TAX_THIS_MTH13 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH13"]);
						CHQ_REG_REGULAR_TAX_THIS_MTH14 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH14"]);
						CHQ_REG_REGULAR_TAX_THIS_MTH15 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH15"]);
						CHQ_REG_REGULAR_TAX_THIS_MTH16 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH16"]);
						CHQ_REG_REGULAR_TAX_THIS_MTH17 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH17"]);
						CHQ_REG_REGULAR_TAX_THIS_MTH18 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH18"]);
						CHQ_REG_MAN_PAY_THIS_MTH1 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH1"]);
						CHQ_REG_MAN_PAY_THIS_MTH2 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH2"]);
						CHQ_REG_MAN_PAY_THIS_MTH3 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH3"]);
						CHQ_REG_MAN_PAY_THIS_MTH4 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH4"]);
						CHQ_REG_MAN_PAY_THIS_MTH5 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH5"]);
						CHQ_REG_MAN_PAY_THIS_MTH6 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH6"]);
						CHQ_REG_MAN_PAY_THIS_MTH7 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH7"]);
						CHQ_REG_MAN_PAY_THIS_MTH8 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH8"]);
						CHQ_REG_MAN_PAY_THIS_MTH9 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH9"]);
						CHQ_REG_MAN_PAY_THIS_MTH10 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH10"]);
						CHQ_REG_MAN_PAY_THIS_MTH11 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH11"]);
						CHQ_REG_MAN_PAY_THIS_MTH12 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH12"]);
						CHQ_REG_MAN_PAY_THIS_MTH13 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH13"]);
						CHQ_REG_MAN_PAY_THIS_MTH14 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH14"]);
						CHQ_REG_MAN_PAY_THIS_MTH15 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH15"]);
						CHQ_REG_MAN_PAY_THIS_MTH16 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH16"]);
						CHQ_REG_MAN_PAY_THIS_MTH17 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH17"]);
						CHQ_REG_MAN_PAY_THIS_MTH18 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH18"]);
						CHQ_REG_MAN_TAX_THIS_MTH1 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH1"]);
						CHQ_REG_MAN_TAX_THIS_MTH2 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH2"]);
						CHQ_REG_MAN_TAX_THIS_MTH3 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH3"]);
						CHQ_REG_MAN_TAX_THIS_MTH4 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH4"]);
						CHQ_REG_MAN_TAX_THIS_MTH5 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH5"]);
						CHQ_REG_MAN_TAX_THIS_MTH6 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH6"]);
						CHQ_REG_MAN_TAX_THIS_MTH7 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH7"]);
						CHQ_REG_MAN_TAX_THIS_MTH8 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH8"]);
						CHQ_REG_MAN_TAX_THIS_MTH9 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH9"]);
						CHQ_REG_MAN_TAX_THIS_MTH10 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH10"]);
						CHQ_REG_MAN_TAX_THIS_MTH11 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH11"]);
						CHQ_REG_MAN_TAX_THIS_MTH12 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH12"]);
						CHQ_REG_MAN_TAX_THIS_MTH13 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH13"]);
						CHQ_REG_MAN_TAX_THIS_MTH14 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH14"]);
						CHQ_REG_MAN_TAX_THIS_MTH15 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH15"]);
						CHQ_REG_MAN_TAX_THIS_MTH16 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH16"]);
						CHQ_REG_MAN_TAX_THIS_MTH17 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH17"]);
						CHQ_REG_MAN_TAX_THIS_MTH18 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH18"]);
						CHQ_REG_PAY_DATE1 = ConvertDEC(Reader["CHQ_REG_PAY_DATE1"]);
						CHQ_REG_PAY_DATE2 = ConvertDEC(Reader["CHQ_REG_PAY_DATE2"]);
						CHQ_REG_PAY_DATE3 = ConvertDEC(Reader["CHQ_REG_PAY_DATE3"]);
						CHQ_REG_PAY_DATE4 = ConvertDEC(Reader["CHQ_REG_PAY_DATE4"]);
						CHQ_REG_PAY_DATE5 = ConvertDEC(Reader["CHQ_REG_PAY_DATE5"]);
						CHQ_REG_PAY_DATE6 = ConvertDEC(Reader["CHQ_REG_PAY_DATE6"]);
						CHQ_REG_PAY_DATE7 = ConvertDEC(Reader["CHQ_REG_PAY_DATE7"]);
						CHQ_REG_PAY_DATE8 = ConvertDEC(Reader["CHQ_REG_PAY_DATE8"]);
						CHQ_REG_PAY_DATE9 = ConvertDEC(Reader["CHQ_REG_PAY_DATE9"]);
						CHQ_REG_PAY_DATE10 = ConvertDEC(Reader["CHQ_REG_PAY_DATE10"]);
						CHQ_REG_PAY_DATE11 = ConvertDEC(Reader["CHQ_REG_PAY_DATE11"]);
						CHQ_REG_PAY_DATE12 = ConvertDEC(Reader["CHQ_REG_PAY_DATE12"]);
						CHQ_REG_PAY_DATE13 = ConvertDEC(Reader["CHQ_REG_PAY_DATE13"]);
						CHQ_REG_PAY_DATE14 = ConvertDEC(Reader["CHQ_REG_PAY_DATE14"]);
						CHQ_REG_PAY_DATE15 = ConvertDEC(Reader["CHQ_REG_PAY_DATE15"]);
						CHQ_REG_PAY_DATE16 = ConvertDEC(Reader["CHQ_REG_PAY_DATE16"]);
						CHQ_REG_PAY_DATE17 = ConvertDEC(Reader["CHQ_REG_PAY_DATE17"]);
						CHQ_REG_PAY_DATE18 = ConvertDEC(Reader["CHQ_REG_PAY_DATE18"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalChq_reg_clinic_nbr_1_2 = ConvertDEC(Reader["CHQ_REG_CLINIC_NBR_1_2"]);
						_originalChq_reg_dept = ConvertDEC(Reader["CHQ_REG_DEPT"]);
						_originalChq_reg_doc_nbr = Reader["CHQ_REG_DOC_NBR"].ToString();
						_originalChq_reg_perc_bill1 = ConvertDEC(Reader["CHQ_REG_PERC_BILL1"]);
						_originalChq_reg_perc_bill2 = ConvertDEC(Reader["CHQ_REG_PERC_BILL2"]);
						_originalChq_reg_perc_bill3 = ConvertDEC(Reader["CHQ_REG_PERC_BILL3"]);
						_originalChq_reg_perc_bill4 = ConvertDEC(Reader["CHQ_REG_PERC_BILL4"]);
						_originalChq_reg_perc_bill5 = ConvertDEC(Reader["CHQ_REG_PERC_BILL5"]);
						_originalChq_reg_perc_bill6 = ConvertDEC(Reader["CHQ_REG_PERC_BILL6"]);
						_originalChq_reg_perc_bill7 = ConvertDEC(Reader["CHQ_REG_PERC_BILL7"]);
						_originalChq_reg_perc_bill8 = ConvertDEC(Reader["CHQ_REG_PERC_BILL8"]);
						_originalChq_reg_perc_bill9 = ConvertDEC(Reader["CHQ_REG_PERC_BILL9"]);
						_originalChq_reg_perc_bill10 = ConvertDEC(Reader["CHQ_REG_PERC_BILL10"]);
						_originalChq_reg_perc_bill11 = ConvertDEC(Reader["CHQ_REG_PERC_BILL11"]);
						_originalChq_reg_perc_bill12 = ConvertDEC(Reader["CHQ_REG_PERC_BILL12"]);
						_originalChq_reg_perc_bill13 = ConvertDEC(Reader["CHQ_REG_PERC_BILL13"]);
						_originalChq_reg_perc_bill14 = ConvertDEC(Reader["CHQ_REG_PERC_BILL14"]);
						_originalChq_reg_perc_bill15 = ConvertDEC(Reader["CHQ_REG_PERC_BILL15"]);
						_originalChq_reg_perc_bill16 = ConvertDEC(Reader["CHQ_REG_PERC_BILL16"]);
						_originalChq_reg_perc_bill17 = ConvertDEC(Reader["CHQ_REG_PERC_BILL17"]);
						_originalChq_reg_perc_bill18 = ConvertDEC(Reader["CHQ_REG_PERC_BILL18"]);
						_originalChq_reg_perc_misc1 = ConvertDEC(Reader["CHQ_REG_PERC_MISC1"]);
						_originalChq_reg_perc_misc2 = ConvertDEC(Reader["CHQ_REG_PERC_MISC2"]);
						_originalChq_reg_perc_misc3 = ConvertDEC(Reader["CHQ_REG_PERC_MISC3"]);
						_originalChq_reg_perc_misc4 = ConvertDEC(Reader["CHQ_REG_PERC_MISC4"]);
						_originalChq_reg_perc_misc5 = ConvertDEC(Reader["CHQ_REG_PERC_MISC5"]);
						_originalChq_reg_perc_misc6 = ConvertDEC(Reader["CHQ_REG_PERC_MISC6"]);
						_originalChq_reg_perc_misc7 = ConvertDEC(Reader["CHQ_REG_PERC_MISC7"]);
						_originalChq_reg_perc_misc8 = ConvertDEC(Reader["CHQ_REG_PERC_MISC8"]);
						_originalChq_reg_perc_misc9 = ConvertDEC(Reader["CHQ_REG_PERC_MISC9"]);
						_originalChq_reg_perc_misc10 = ConvertDEC(Reader["CHQ_REG_PERC_MISC10"]);
						_originalChq_reg_perc_misc11 = ConvertDEC(Reader["CHQ_REG_PERC_MISC11"]);
						_originalChq_reg_perc_misc12 = ConvertDEC(Reader["CHQ_REG_PERC_MISC12"]);
						_originalChq_reg_perc_misc13 = ConvertDEC(Reader["CHQ_REG_PERC_MISC13"]);
						_originalChq_reg_perc_misc14 = ConvertDEC(Reader["CHQ_REG_PERC_MISC14"]);
						_originalChq_reg_perc_misc15 = ConvertDEC(Reader["CHQ_REG_PERC_MISC15"]);
						_originalChq_reg_perc_misc16 = ConvertDEC(Reader["CHQ_REG_PERC_MISC16"]);
						_originalChq_reg_perc_misc17 = ConvertDEC(Reader["CHQ_REG_PERC_MISC17"]);
						_originalChq_reg_perc_misc18 = ConvertDEC(Reader["CHQ_REG_PERC_MISC18"]);
						_originalChq_reg_pay_code1 = Reader["CHQ_REG_PAY_CODE1"].ToString();
						_originalChq_reg_pay_code2 = Reader["CHQ_REG_PAY_CODE2"].ToString();
						_originalChq_reg_pay_code3 = Reader["CHQ_REG_PAY_CODE3"].ToString();
						_originalChq_reg_pay_code4 = Reader["CHQ_REG_PAY_CODE4"].ToString();
						_originalChq_reg_pay_code5 = Reader["CHQ_REG_PAY_CODE5"].ToString();
						_originalChq_reg_pay_code6 = Reader["CHQ_REG_PAY_CODE6"].ToString();
						_originalChq_reg_pay_code7 = Reader["CHQ_REG_PAY_CODE7"].ToString();
						_originalChq_reg_pay_code8 = Reader["CHQ_REG_PAY_CODE8"].ToString();
						_originalChq_reg_pay_code9 = Reader["CHQ_REG_PAY_CODE9"].ToString();
						_originalChq_reg_pay_code10 = Reader["CHQ_REG_PAY_CODE10"].ToString();
						_originalChq_reg_pay_code11 = Reader["CHQ_REG_PAY_CODE11"].ToString();
						_originalChq_reg_pay_code12 = Reader["CHQ_REG_PAY_CODE12"].ToString();
						_originalChq_reg_pay_code13 = Reader["CHQ_REG_PAY_CODE13"].ToString();
						_originalChq_reg_pay_code14 = Reader["CHQ_REG_PAY_CODE14"].ToString();
						_originalChq_reg_pay_code15 = Reader["CHQ_REG_PAY_CODE15"].ToString();
						_originalChq_reg_pay_code16 = Reader["CHQ_REG_PAY_CODE16"].ToString();
						_originalChq_reg_pay_code17 = Reader["CHQ_REG_PAY_CODE17"].ToString();
						_originalChq_reg_pay_code18 = Reader["CHQ_REG_PAY_CODE18"].ToString();
						_originalChq_reg_perc_tax1 = ConvertDEC(Reader["CHQ_REG_PERC_TAX1"]);
						_originalChq_reg_perc_tax2 = ConvertDEC(Reader["CHQ_REG_PERC_TAX2"]);
						_originalChq_reg_perc_tax3 = ConvertDEC(Reader["CHQ_REG_PERC_TAX3"]);
						_originalChq_reg_perc_tax4 = ConvertDEC(Reader["CHQ_REG_PERC_TAX4"]);
						_originalChq_reg_perc_tax5 = ConvertDEC(Reader["CHQ_REG_PERC_TAX5"]);
						_originalChq_reg_perc_tax6 = ConvertDEC(Reader["CHQ_REG_PERC_TAX6"]);
						_originalChq_reg_perc_tax7 = ConvertDEC(Reader["CHQ_REG_PERC_TAX7"]);
						_originalChq_reg_perc_tax8 = ConvertDEC(Reader["CHQ_REG_PERC_TAX8"]);
						_originalChq_reg_perc_tax9 = ConvertDEC(Reader["CHQ_REG_PERC_TAX9"]);
						_originalChq_reg_perc_tax10 = ConvertDEC(Reader["CHQ_REG_PERC_TAX10"]);
						_originalChq_reg_perc_tax11 = ConvertDEC(Reader["CHQ_REG_PERC_TAX11"]);
						_originalChq_reg_perc_tax12 = ConvertDEC(Reader["CHQ_REG_PERC_TAX12"]);
						_originalChq_reg_perc_tax13 = ConvertDEC(Reader["CHQ_REG_PERC_TAX13"]);
						_originalChq_reg_perc_tax14 = ConvertDEC(Reader["CHQ_REG_PERC_TAX14"]);
						_originalChq_reg_perc_tax15 = ConvertDEC(Reader["CHQ_REG_PERC_TAX15"]);
						_originalChq_reg_perc_tax16 = ConvertDEC(Reader["CHQ_REG_PERC_TAX16"]);
						_originalChq_reg_perc_tax17 = ConvertDEC(Reader["CHQ_REG_PERC_TAX17"]);
						_originalChq_reg_perc_tax18 = ConvertDEC(Reader["CHQ_REG_PERC_TAX18"]);
						_originalChq_reg_mth_bill_amt1 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT1"]);
						_originalChq_reg_mth_bill_amt2 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT2"]);
						_originalChq_reg_mth_bill_amt3 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT3"]);
						_originalChq_reg_mth_bill_amt4 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT4"]);
						_originalChq_reg_mth_bill_amt5 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT5"]);
						_originalChq_reg_mth_bill_amt6 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT6"]);
						_originalChq_reg_mth_bill_amt7 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT7"]);
						_originalChq_reg_mth_bill_amt8 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT8"]);
						_originalChq_reg_mth_bill_amt9 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT9"]);
						_originalChq_reg_mth_bill_amt10 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT10"]);
						_originalChq_reg_mth_bill_amt11 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT11"]);
						_originalChq_reg_mth_bill_amt12 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT12"]);
						_originalChq_reg_mth_bill_amt13 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT13"]);
						_originalChq_reg_mth_bill_amt14 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT14"]);
						_originalChq_reg_mth_bill_amt15 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT15"]);
						_originalChq_reg_mth_bill_amt16 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT16"]);
						_originalChq_reg_mth_bill_amt17 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT17"]);
						_originalChq_reg_mth_bill_amt18 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT18"]);
						_originalChq_reg_mth_misc_amt_11 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_11"]);
						_originalChq_reg_mth_misc_amt_12 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_12"]);
						_originalChq_reg_mth_misc_amt_13 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_13"]);
						_originalChq_reg_mth_misc_amt_14 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_14"]);
						_originalChq_reg_mth_misc_amt_15 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_15"]);
						_originalChq_reg_mth_misc_amt_16 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_16"]);
						_originalChq_reg_mth_misc_amt_17 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_17"]);
						_originalChq_reg_mth_misc_amt_18 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_18"]);
						_originalChq_reg_mth_misc_amt_19 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_19"]);
						_originalChq_reg_mth_misc_amt_110 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_110"]);
						_originalChq_reg_mth_misc_amt_111 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_111"]);
						_originalChq_reg_mth_misc_amt_112 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_112"]);
						_originalChq_reg_mth_misc_amt_113 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_113"]);
						_originalChq_reg_mth_misc_amt_114 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_114"]);
						_originalChq_reg_mth_misc_amt_115 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_115"]);
						_originalChq_reg_mth_misc_amt_116 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_116"]);
						_originalChq_reg_mth_misc_amt_117 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_117"]);
						_originalChq_reg_mth_misc_amt_118 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_118"]);
						_originalChq_reg_mth_misc_amt_21 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_21"]);
						_originalChq_reg_mth_misc_amt_22 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_22"]);
						_originalChq_reg_mth_misc_amt_23 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_23"]);
						_originalChq_reg_mth_misc_amt_24 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_24"]);
						_originalChq_reg_mth_misc_amt_25 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_25"]);
						_originalChq_reg_mth_misc_amt_26 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_26"]);
						_originalChq_reg_mth_misc_amt_27 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_27"]);
						_originalChq_reg_mth_misc_amt_28 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_28"]);
						_originalChq_reg_mth_misc_amt_29 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_29"]);
						_originalChq_reg_mth_misc_amt_210 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_210"]);
						_originalChq_reg_mth_misc_amt_211 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_211"]);
						_originalChq_reg_mth_misc_amt_212 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_212"]);
						_originalChq_reg_mth_misc_amt_213 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_213"]);
						_originalChq_reg_mth_misc_amt_214 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_214"]);
						_originalChq_reg_mth_misc_amt_215 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_215"]);
						_originalChq_reg_mth_misc_amt_216 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_216"]);
						_originalChq_reg_mth_misc_amt_217 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_217"]);
						_originalChq_reg_mth_misc_amt_218 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_218"]);
						_originalChq_reg_mth_misc_amt_31 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_31"]);
						_originalChq_reg_mth_misc_amt_32 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_32"]);
						_originalChq_reg_mth_misc_amt_33 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_33"]);
						_originalChq_reg_mth_misc_amt_34 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_34"]);
						_originalChq_reg_mth_misc_amt_35 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_35"]);
						_originalChq_reg_mth_misc_amt_36 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_36"]);
						_originalChq_reg_mth_misc_amt_37 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_37"]);
						_originalChq_reg_mth_misc_amt_38 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_38"]);
						_originalChq_reg_mth_misc_amt_39 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_39"]);
						_originalChq_reg_mth_misc_amt_310 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_310"]);
						_originalChq_reg_mth_misc_amt_311 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_311"]);
						_originalChq_reg_mth_misc_amt_312 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_312"]);
						_originalChq_reg_mth_misc_amt_313 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_313"]);
						_originalChq_reg_mth_misc_amt_314 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_314"]);
						_originalChq_reg_mth_misc_amt_315 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_315"]);
						_originalChq_reg_mth_misc_amt_316 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_316"]);
						_originalChq_reg_mth_misc_amt_317 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_317"]);
						_originalChq_reg_mth_misc_amt_318 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_318"]);
						_originalChq_reg_mth_misc_amt_41 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_41"]);
						_originalChq_reg_mth_misc_amt_42 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_42"]);
						_originalChq_reg_mth_misc_amt_43 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_43"]);
						_originalChq_reg_mth_misc_amt_44 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_44"]);
						_originalChq_reg_mth_misc_amt_45 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_45"]);
						_originalChq_reg_mth_misc_amt_46 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_46"]);
						_originalChq_reg_mth_misc_amt_47 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_47"]);
						_originalChq_reg_mth_misc_amt_48 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_48"]);
						_originalChq_reg_mth_misc_amt_49 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_49"]);
						_originalChq_reg_mth_misc_amt_410 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_410"]);
						_originalChq_reg_mth_misc_amt_411 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_411"]);
						_originalChq_reg_mth_misc_amt_412 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_412"]);
						_originalChq_reg_mth_misc_amt_413 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_413"]);
						_originalChq_reg_mth_misc_amt_414 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_414"]);
						_originalChq_reg_mth_misc_amt_415 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_415"]);
						_originalChq_reg_mth_misc_amt_416 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_416"]);
						_originalChq_reg_mth_misc_amt_417 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_417"]);
						_originalChq_reg_mth_misc_amt_418 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_418"]);
						_originalChq_reg_mth_misc_amt_51 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_51"]);
						_originalChq_reg_mth_misc_amt_52 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_52"]);
						_originalChq_reg_mth_misc_amt_53 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_53"]);
						_originalChq_reg_mth_misc_amt_54 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_54"]);
						_originalChq_reg_mth_misc_amt_55 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_55"]);
						_originalChq_reg_mth_misc_amt_56 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_56"]);
						_originalChq_reg_mth_misc_amt_57 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_57"]);
						_originalChq_reg_mth_misc_amt_58 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_58"]);
						_originalChq_reg_mth_misc_amt_59 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_59"]);
						_originalChq_reg_mth_misc_amt_510 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_510"]);
						_originalChq_reg_mth_misc_amt_511 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_511"]);
						_originalChq_reg_mth_misc_amt_512 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_512"]);
						_originalChq_reg_mth_misc_amt_513 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_513"]);
						_originalChq_reg_mth_misc_amt_514 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_514"]);
						_originalChq_reg_mth_misc_amt_515 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_515"]);
						_originalChq_reg_mth_misc_amt_516 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_516"]);
						_originalChq_reg_mth_misc_amt_517 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_517"]);
						_originalChq_reg_mth_misc_amt_518 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_518"]);
						_originalChq_reg_mth_misc_amt_61 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_61"]);
						_originalChq_reg_mth_misc_amt_62 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_62"]);
						_originalChq_reg_mth_misc_amt_63 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_63"]);
						_originalChq_reg_mth_misc_amt_64 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_64"]);
						_originalChq_reg_mth_misc_amt_65 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_65"]);
						_originalChq_reg_mth_misc_amt_66 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_66"]);
						_originalChq_reg_mth_misc_amt_67 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_67"]);
						_originalChq_reg_mth_misc_amt_68 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_68"]);
						_originalChq_reg_mth_misc_amt_69 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_69"]);
						_originalChq_reg_mth_misc_amt_610 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_610"]);
						_originalChq_reg_mth_misc_amt_611 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_611"]);
						_originalChq_reg_mth_misc_amt_612 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_612"]);
						_originalChq_reg_mth_misc_amt_613 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_613"]);
						_originalChq_reg_mth_misc_amt_614 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_614"]);
						_originalChq_reg_mth_misc_amt_615 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_615"]);
						_originalChq_reg_mth_misc_amt_616 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_616"]);
						_originalChq_reg_mth_misc_amt_617 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_617"]);
						_originalChq_reg_mth_misc_amt_618 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_618"]);
						_originalChq_reg_mth_misc_amt_71 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_71"]);
						_originalChq_reg_mth_misc_amt_72 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_72"]);
						_originalChq_reg_mth_misc_amt_73 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_73"]);
						_originalChq_reg_mth_misc_amt_74 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_74"]);
						_originalChq_reg_mth_misc_amt_75 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_75"]);
						_originalChq_reg_mth_misc_amt_76 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_76"]);
						_originalChq_reg_mth_misc_amt_77 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_77"]);
						_originalChq_reg_mth_misc_amt_78 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_78"]);
						_originalChq_reg_mth_misc_amt_79 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_79"]);
						_originalChq_reg_mth_misc_amt_710 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_710"]);
						_originalChq_reg_mth_misc_amt_711 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_711"]);
						_originalChq_reg_mth_misc_amt_712 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_712"]);
						_originalChq_reg_mth_misc_amt_713 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_713"]);
						_originalChq_reg_mth_misc_amt_714 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_714"]);
						_originalChq_reg_mth_misc_amt_715 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_715"]);
						_originalChq_reg_mth_misc_amt_716 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_716"]);
						_originalChq_reg_mth_misc_amt_717 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_717"]);
						_originalChq_reg_mth_misc_amt_718 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_718"]);
						_originalChq_reg_mth_misc_amt_81 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_81"]);
						_originalChq_reg_mth_misc_amt_82 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_82"]);
						_originalChq_reg_mth_misc_amt_83 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_83"]);
						_originalChq_reg_mth_misc_amt_84 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_84"]);
						_originalChq_reg_mth_misc_amt_85 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_85"]);
						_originalChq_reg_mth_misc_amt_86 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_86"]);
						_originalChq_reg_mth_misc_amt_87 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_87"]);
						_originalChq_reg_mth_misc_amt_88 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_88"]);
						_originalChq_reg_mth_misc_amt_89 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_89"]);
						_originalChq_reg_mth_misc_amt_810 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_810"]);
						_originalChq_reg_mth_misc_amt_811 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_811"]);
						_originalChq_reg_mth_misc_amt_812 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_812"]);
						_originalChq_reg_mth_misc_amt_813 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_813"]);
						_originalChq_reg_mth_misc_amt_814 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_814"]);
						_originalChq_reg_mth_misc_amt_815 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_815"]);
						_originalChq_reg_mth_misc_amt_816 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_816"]);
						_originalChq_reg_mth_misc_amt_817 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_817"]);
						_originalChq_reg_mth_misc_amt_818 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_818"]);
						_originalChq_reg_mth_misc_amt_91 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_91"]);
						_originalChq_reg_mth_misc_amt_92 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_92"]);
						_originalChq_reg_mth_misc_amt_93 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_93"]);
						_originalChq_reg_mth_misc_amt_94 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_94"]);
						_originalChq_reg_mth_misc_amt_95 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_95"]);
						_originalChq_reg_mth_misc_amt_96 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_96"]);
						_originalChq_reg_mth_misc_amt_97 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_97"]);
						_originalChq_reg_mth_misc_amt_98 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_98"]);
						_originalChq_reg_mth_misc_amt_99 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_99"]);
						_originalChq_reg_mth_misc_amt_910 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_910"]);
						_originalChq_reg_mth_misc_amt_911 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_911"]);
						_originalChq_reg_mth_misc_amt_912 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_912"]);
						_originalChq_reg_mth_misc_amt_913 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_913"]);
						_originalChq_reg_mth_misc_amt_914 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_914"]);
						_originalChq_reg_mth_misc_amt_915 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_915"]);
						_originalChq_reg_mth_misc_amt_916 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_916"]);
						_originalChq_reg_mth_misc_amt_917 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_917"]);
						_originalChq_reg_mth_misc_amt_918 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_918"]);
						_originalChq_reg_mth_misc_amt_101 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_101"]);
						_originalChq_reg_mth_misc_amt_102 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_102"]);
						_originalChq_reg_mth_misc_amt_103 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_103"]);
						_originalChq_reg_mth_misc_amt_104 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_104"]);
						_originalChq_reg_mth_misc_amt_105 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_105"]);
						_originalChq_reg_mth_misc_amt_106 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_106"]);
						_originalChq_reg_mth_misc_amt_107 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_107"]);
						_originalChq_reg_mth_misc_amt_108 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_108"]);
						_originalChq_reg_mth_misc_amt_109 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_109"]);
						_originalChq_reg_mth_misc_amt_1010 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1010"]);
						_originalChq_reg_mth_misc_amt_1011 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1011"]);
						_originalChq_reg_mth_misc_amt_1012 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1012"]);
						_originalChq_reg_mth_misc_amt_1013 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1013"]);
						_originalChq_reg_mth_misc_amt_1014 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1014"]);
						_originalChq_reg_mth_misc_amt_1015 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1015"]);
						_originalChq_reg_mth_misc_amt_1016 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1016"]);
						_originalChq_reg_mth_misc_amt_1017 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1017"]);
						_originalChq_reg_mth_misc_amt_1018 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1018"]);
						_originalChq_reg_mth_exp_amt1 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT1"]);
						_originalChq_reg_mth_exp_amt2 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT2"]);
						_originalChq_reg_mth_exp_amt3 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT3"]);
						_originalChq_reg_mth_exp_amt4 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT4"]);
						_originalChq_reg_mth_exp_amt5 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT5"]);
						_originalChq_reg_mth_exp_amt6 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT6"]);
						_originalChq_reg_mth_exp_amt7 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT7"]);
						_originalChq_reg_mth_exp_amt8 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT8"]);
						_originalChq_reg_mth_exp_amt9 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT9"]);
						_originalChq_reg_mth_exp_amt10 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT10"]);
						_originalChq_reg_mth_exp_amt11 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT11"]);
						_originalChq_reg_mth_exp_amt12 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT12"]);
						_originalChq_reg_mth_exp_amt13 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT13"]);
						_originalChq_reg_mth_exp_amt14 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT14"]);
						_originalChq_reg_mth_exp_amt15 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT15"]);
						_originalChq_reg_mth_exp_amt16 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT16"]);
						_originalChq_reg_mth_exp_amt17 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT17"]);
						_originalChq_reg_mth_exp_amt18 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT18"]);
						_originalChq_reg_comp_ann_exp_this_pay1 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY1"]);
						_originalChq_reg_comp_ann_exp_this_pay2 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY2"]);
						_originalChq_reg_comp_ann_exp_this_pay3 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY3"]);
						_originalChq_reg_comp_ann_exp_this_pay4 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY4"]);
						_originalChq_reg_comp_ann_exp_this_pay5 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY5"]);
						_originalChq_reg_comp_ann_exp_this_pay6 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY6"]);
						_originalChq_reg_comp_ann_exp_this_pay7 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY7"]);
						_originalChq_reg_comp_ann_exp_this_pay8 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY8"]);
						_originalChq_reg_comp_ann_exp_this_pay9 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY9"]);
						_originalChq_reg_comp_ann_exp_this_pay10 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY10"]);
						_originalChq_reg_comp_ann_exp_this_pay11 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY11"]);
						_originalChq_reg_comp_ann_exp_this_pay12 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY12"]);
						_originalChq_reg_comp_ann_exp_this_pay13 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY13"]);
						_originalChq_reg_comp_ann_exp_this_pay14 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY14"]);
						_originalChq_reg_comp_ann_exp_this_pay15 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY15"]);
						_originalChq_reg_comp_ann_exp_this_pay16 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY16"]);
						_originalChq_reg_comp_ann_exp_this_pay17 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY17"]);
						_originalChq_reg_comp_ann_exp_this_pay18 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY18"]);
						_originalChq_reg_mth_ceil_amt1 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT1"]);
						_originalChq_reg_mth_ceil_amt2 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT2"]);
						_originalChq_reg_mth_ceil_amt3 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT3"]);
						_originalChq_reg_mth_ceil_amt4 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT4"]);
						_originalChq_reg_mth_ceil_amt5 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT5"]);
						_originalChq_reg_mth_ceil_amt6 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT6"]);
						_originalChq_reg_mth_ceil_amt7 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT7"]);
						_originalChq_reg_mth_ceil_amt8 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT8"]);
						_originalChq_reg_mth_ceil_amt9 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT9"]);
						_originalChq_reg_mth_ceil_amt10 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT10"]);
						_originalChq_reg_mth_ceil_amt11 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT11"]);
						_originalChq_reg_mth_ceil_amt12 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT12"]);
						_originalChq_reg_mth_ceil_amt13 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT13"]);
						_originalChq_reg_mth_ceil_amt14 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT14"]);
						_originalChq_reg_mth_ceil_amt15 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT15"]);
						_originalChq_reg_mth_ceil_amt16 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT16"]);
						_originalChq_reg_mth_ceil_amt17 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT17"]);
						_originalChq_reg_mth_ceil_amt18 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT18"]);
						_originalChq_reg_comp_ann_ceil_this_pay1 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY1"]);
						_originalChq_reg_comp_ann_ceil_this_pay2 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY2"]);
						_originalChq_reg_comp_ann_ceil_this_pay3 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY3"]);
						_originalChq_reg_comp_ann_ceil_this_pay4 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY4"]);
						_originalChq_reg_comp_ann_ceil_this_pay5 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY5"]);
						_originalChq_reg_comp_ann_ceil_this_pay6 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY6"]);
						_originalChq_reg_comp_ann_ceil_this_pay7 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY7"]);
						_originalChq_reg_comp_ann_ceil_this_pay8 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY8"]);
						_originalChq_reg_comp_ann_ceil_this_pay9 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY9"]);
						_originalChq_reg_comp_ann_ceil_this_pay10 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY10"]);
						_originalChq_reg_comp_ann_ceil_this_pay11 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY11"]);
						_originalChq_reg_comp_ann_ceil_this_pay12 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY12"]);
						_originalChq_reg_comp_ann_ceil_this_pay13 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY13"]);
						_originalChq_reg_comp_ann_ceil_this_pay14 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY14"]);
						_originalChq_reg_comp_ann_ceil_this_pay15 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY15"]);
						_originalChq_reg_comp_ann_ceil_this_pay16 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY16"]);
						_originalChq_reg_comp_ann_ceil_this_pay17 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY17"]);
						_originalChq_reg_comp_ann_ceil_this_pay18 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY18"]);
						_originalChq_reg_earnings_this_mth1 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH1"]);
						_originalChq_reg_earnings_this_mth2 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH2"]);
						_originalChq_reg_earnings_this_mth3 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH3"]);
						_originalChq_reg_earnings_this_mth4 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH4"]);
						_originalChq_reg_earnings_this_mth5 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH5"]);
						_originalChq_reg_earnings_this_mth6 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH6"]);
						_originalChq_reg_earnings_this_mth7 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH7"]);
						_originalChq_reg_earnings_this_mth8 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH8"]);
						_originalChq_reg_earnings_this_mth9 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH9"]);
						_originalChq_reg_earnings_this_mth10 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH10"]);
						_originalChq_reg_earnings_this_mth11 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH11"]);
						_originalChq_reg_earnings_this_mth12 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH12"]);
						_originalChq_reg_earnings_this_mth13 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH13"]);
						_originalChq_reg_earnings_this_mth14 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH14"]);
						_originalChq_reg_earnings_this_mth15 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH15"]);
						_originalChq_reg_earnings_this_mth16 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH16"]);
						_originalChq_reg_earnings_this_mth17 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH17"]);
						_originalChq_reg_earnings_this_mth18 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH18"]);
						_originalChq_reg_regular_pay_this_mth1 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH1"]);
						_originalChq_reg_regular_pay_this_mth2 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH2"]);
						_originalChq_reg_regular_pay_this_mth3 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH3"]);
						_originalChq_reg_regular_pay_this_mth4 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH4"]);
						_originalChq_reg_regular_pay_this_mth5 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH5"]);
						_originalChq_reg_regular_pay_this_mth6 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH6"]);
						_originalChq_reg_regular_pay_this_mth7 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH7"]);
						_originalChq_reg_regular_pay_this_mth8 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH8"]);
						_originalChq_reg_regular_pay_this_mth9 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH9"]);
						_originalChq_reg_regular_pay_this_mth10 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH10"]);
						_originalChq_reg_regular_pay_this_mth11 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH11"]);
						_originalChq_reg_regular_pay_this_mth12 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH12"]);
						_originalChq_reg_regular_pay_this_mth13 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH13"]);
						_originalChq_reg_regular_pay_this_mth14 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH14"]);
						_originalChq_reg_regular_pay_this_mth15 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH15"]);
						_originalChq_reg_regular_pay_this_mth16 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH16"]);
						_originalChq_reg_regular_pay_this_mth17 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH17"]);
						_originalChq_reg_regular_pay_this_mth18 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH18"]);
						_originalChq_reg_regular_tax_this_mth1 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH1"]);
						_originalChq_reg_regular_tax_this_mth2 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH2"]);
						_originalChq_reg_regular_tax_this_mth3 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH3"]);
						_originalChq_reg_regular_tax_this_mth4 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH4"]);
						_originalChq_reg_regular_tax_this_mth5 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH5"]);
						_originalChq_reg_regular_tax_this_mth6 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH6"]);
						_originalChq_reg_regular_tax_this_mth7 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH7"]);
						_originalChq_reg_regular_tax_this_mth8 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH8"]);
						_originalChq_reg_regular_tax_this_mth9 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH9"]);
						_originalChq_reg_regular_tax_this_mth10 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH10"]);
						_originalChq_reg_regular_tax_this_mth11 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH11"]);
						_originalChq_reg_regular_tax_this_mth12 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH12"]);
						_originalChq_reg_regular_tax_this_mth13 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH13"]);
						_originalChq_reg_regular_tax_this_mth14 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH14"]);
						_originalChq_reg_regular_tax_this_mth15 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH15"]);
						_originalChq_reg_regular_tax_this_mth16 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH16"]);
						_originalChq_reg_regular_tax_this_mth17 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH17"]);
						_originalChq_reg_regular_tax_this_mth18 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH18"]);
						_originalChq_reg_man_pay_this_mth1 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH1"]);
						_originalChq_reg_man_pay_this_mth2 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH2"]);
						_originalChq_reg_man_pay_this_mth3 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH3"]);
						_originalChq_reg_man_pay_this_mth4 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH4"]);
						_originalChq_reg_man_pay_this_mth5 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH5"]);
						_originalChq_reg_man_pay_this_mth6 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH6"]);
						_originalChq_reg_man_pay_this_mth7 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH7"]);
						_originalChq_reg_man_pay_this_mth8 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH8"]);
						_originalChq_reg_man_pay_this_mth9 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH9"]);
						_originalChq_reg_man_pay_this_mth10 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH10"]);
						_originalChq_reg_man_pay_this_mth11 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH11"]);
						_originalChq_reg_man_pay_this_mth12 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH12"]);
						_originalChq_reg_man_pay_this_mth13 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH13"]);
						_originalChq_reg_man_pay_this_mth14 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH14"]);
						_originalChq_reg_man_pay_this_mth15 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH15"]);
						_originalChq_reg_man_pay_this_mth16 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH16"]);
						_originalChq_reg_man_pay_this_mth17 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH17"]);
						_originalChq_reg_man_pay_this_mth18 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH18"]);
						_originalChq_reg_man_tax_this_mth1 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH1"]);
						_originalChq_reg_man_tax_this_mth2 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH2"]);
						_originalChq_reg_man_tax_this_mth3 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH3"]);
						_originalChq_reg_man_tax_this_mth4 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH4"]);
						_originalChq_reg_man_tax_this_mth5 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH5"]);
						_originalChq_reg_man_tax_this_mth6 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH6"]);
						_originalChq_reg_man_tax_this_mth7 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH7"]);
						_originalChq_reg_man_tax_this_mth8 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH8"]);
						_originalChq_reg_man_tax_this_mth9 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH9"]);
						_originalChq_reg_man_tax_this_mth10 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH10"]);
						_originalChq_reg_man_tax_this_mth11 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH11"]);
						_originalChq_reg_man_tax_this_mth12 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH12"]);
						_originalChq_reg_man_tax_this_mth13 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH13"]);
						_originalChq_reg_man_tax_this_mth14 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH14"]);
						_originalChq_reg_man_tax_this_mth15 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH15"]);
						_originalChq_reg_man_tax_this_mth16 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH16"]);
						_originalChq_reg_man_tax_this_mth17 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH17"]);
						_originalChq_reg_man_tax_this_mth18 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH18"]);
						_originalChq_reg_pay_date1 = ConvertDEC(Reader["CHQ_REG_PAY_DATE1"]);
						_originalChq_reg_pay_date2 = ConvertDEC(Reader["CHQ_REG_PAY_DATE2"]);
						_originalChq_reg_pay_date3 = ConvertDEC(Reader["CHQ_REG_PAY_DATE3"]);
						_originalChq_reg_pay_date4 = ConvertDEC(Reader["CHQ_REG_PAY_DATE4"]);
						_originalChq_reg_pay_date5 = ConvertDEC(Reader["CHQ_REG_PAY_DATE5"]);
						_originalChq_reg_pay_date6 = ConvertDEC(Reader["CHQ_REG_PAY_DATE6"]);
						_originalChq_reg_pay_date7 = ConvertDEC(Reader["CHQ_REG_PAY_DATE7"]);
						_originalChq_reg_pay_date8 = ConvertDEC(Reader["CHQ_REG_PAY_DATE8"]);
						_originalChq_reg_pay_date9 = ConvertDEC(Reader["CHQ_REG_PAY_DATE9"]);
						_originalChq_reg_pay_date10 = ConvertDEC(Reader["CHQ_REG_PAY_DATE10"]);
						_originalChq_reg_pay_date11 = ConvertDEC(Reader["CHQ_REG_PAY_DATE11"]);
						_originalChq_reg_pay_date12 = ConvertDEC(Reader["CHQ_REG_PAY_DATE12"]);
						_originalChq_reg_pay_date13 = ConvertDEC(Reader["CHQ_REG_PAY_DATE13"]);
						_originalChq_reg_pay_date14 = ConvertDEC(Reader["CHQ_REG_PAY_DATE14"]);
						_originalChq_reg_pay_date15 = ConvertDEC(Reader["CHQ_REG_PAY_DATE15"]);
						_originalChq_reg_pay_date16 = ConvertDEC(Reader["CHQ_REG_PAY_DATE16"]);
						_originalChq_reg_pay_date17 = ConvertDEC(Reader["CHQ_REG_PAY_DATE17"]);
						_originalChq_reg_pay_date18 = ConvertDEC(Reader["CHQ_REG_PAY_DATE18"]);
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("CHQ_REG_CLINIC_NBR_1_2", SqlNull(CHQ_REG_CLINIC_NBR_1_2)),
						new SqlParameter("CHQ_REG_DEPT", SqlNull(CHQ_REG_DEPT)),
						new SqlParameter("CHQ_REG_DOC_NBR", SqlNull(CHQ_REG_DOC_NBR)),
						new SqlParameter("CHQ_REG_PERC_BILL1", SqlNull(CHQ_REG_PERC_BILL1)),
						new SqlParameter("CHQ_REG_PERC_BILL2", SqlNull(CHQ_REG_PERC_BILL2)),
						new SqlParameter("CHQ_REG_PERC_BILL3", SqlNull(CHQ_REG_PERC_BILL3)),
						new SqlParameter("CHQ_REG_PERC_BILL4", SqlNull(CHQ_REG_PERC_BILL4)),
						new SqlParameter("CHQ_REG_PERC_BILL5", SqlNull(CHQ_REG_PERC_BILL5)),
						new SqlParameter("CHQ_REG_PERC_BILL6", SqlNull(CHQ_REG_PERC_BILL6)),
						new SqlParameter("CHQ_REG_PERC_BILL7", SqlNull(CHQ_REG_PERC_BILL7)),
						new SqlParameter("CHQ_REG_PERC_BILL8", SqlNull(CHQ_REG_PERC_BILL8)),
						new SqlParameter("CHQ_REG_PERC_BILL9", SqlNull(CHQ_REG_PERC_BILL9)),
						new SqlParameter("CHQ_REG_PERC_BILL10", SqlNull(CHQ_REG_PERC_BILL10)),
						new SqlParameter("CHQ_REG_PERC_BILL11", SqlNull(CHQ_REG_PERC_BILL11)),
						new SqlParameter("CHQ_REG_PERC_BILL12", SqlNull(CHQ_REG_PERC_BILL12)),
						new SqlParameter("CHQ_REG_PERC_BILL13", SqlNull(CHQ_REG_PERC_BILL13)),
						new SqlParameter("CHQ_REG_PERC_BILL14", SqlNull(CHQ_REG_PERC_BILL14)),
						new SqlParameter("CHQ_REG_PERC_BILL15", SqlNull(CHQ_REG_PERC_BILL15)),
						new SqlParameter("CHQ_REG_PERC_BILL16", SqlNull(CHQ_REG_PERC_BILL16)),
						new SqlParameter("CHQ_REG_PERC_BILL17", SqlNull(CHQ_REG_PERC_BILL17)),
						new SqlParameter("CHQ_REG_PERC_BILL18", SqlNull(CHQ_REG_PERC_BILL18)),
						new SqlParameter("CHQ_REG_PERC_MISC1", SqlNull(CHQ_REG_PERC_MISC1)),
						new SqlParameter("CHQ_REG_PERC_MISC2", SqlNull(CHQ_REG_PERC_MISC2)),
						new SqlParameter("CHQ_REG_PERC_MISC3", SqlNull(CHQ_REG_PERC_MISC3)),
						new SqlParameter("CHQ_REG_PERC_MISC4", SqlNull(CHQ_REG_PERC_MISC4)),
						new SqlParameter("CHQ_REG_PERC_MISC5", SqlNull(CHQ_REG_PERC_MISC5)),
						new SqlParameter("CHQ_REG_PERC_MISC6", SqlNull(CHQ_REG_PERC_MISC6)),
						new SqlParameter("CHQ_REG_PERC_MISC7", SqlNull(CHQ_REG_PERC_MISC7)),
						new SqlParameter("CHQ_REG_PERC_MISC8", SqlNull(CHQ_REG_PERC_MISC8)),
						new SqlParameter("CHQ_REG_PERC_MISC9", SqlNull(CHQ_REG_PERC_MISC9)),
						new SqlParameter("CHQ_REG_PERC_MISC10", SqlNull(CHQ_REG_PERC_MISC10)),
						new SqlParameter("CHQ_REG_PERC_MISC11", SqlNull(CHQ_REG_PERC_MISC11)),
						new SqlParameter("CHQ_REG_PERC_MISC12", SqlNull(CHQ_REG_PERC_MISC12)),
						new SqlParameter("CHQ_REG_PERC_MISC13", SqlNull(CHQ_REG_PERC_MISC13)),
						new SqlParameter("CHQ_REG_PERC_MISC14", SqlNull(CHQ_REG_PERC_MISC14)),
						new SqlParameter("CHQ_REG_PERC_MISC15", SqlNull(CHQ_REG_PERC_MISC15)),
						new SqlParameter("CHQ_REG_PERC_MISC16", SqlNull(CHQ_REG_PERC_MISC16)),
						new SqlParameter("CHQ_REG_PERC_MISC17", SqlNull(CHQ_REG_PERC_MISC17)),
						new SqlParameter("CHQ_REG_PERC_MISC18", SqlNull(CHQ_REG_PERC_MISC18)),
						new SqlParameter("CHQ_REG_PAY_CODE1", SqlNull(CHQ_REG_PAY_CODE1)),
						new SqlParameter("CHQ_REG_PAY_CODE2", SqlNull(CHQ_REG_PAY_CODE2)),
						new SqlParameter("CHQ_REG_PAY_CODE3", SqlNull(CHQ_REG_PAY_CODE3)),
						new SqlParameter("CHQ_REG_PAY_CODE4", SqlNull(CHQ_REG_PAY_CODE4)),
						new SqlParameter("CHQ_REG_PAY_CODE5", SqlNull(CHQ_REG_PAY_CODE5)),
						new SqlParameter("CHQ_REG_PAY_CODE6", SqlNull(CHQ_REG_PAY_CODE6)),
						new SqlParameter("CHQ_REG_PAY_CODE7", SqlNull(CHQ_REG_PAY_CODE7)),
						new SqlParameter("CHQ_REG_PAY_CODE8", SqlNull(CHQ_REG_PAY_CODE8)),
						new SqlParameter("CHQ_REG_PAY_CODE9", SqlNull(CHQ_REG_PAY_CODE9)),
						new SqlParameter("CHQ_REG_PAY_CODE10", SqlNull(CHQ_REG_PAY_CODE10)),
						new SqlParameter("CHQ_REG_PAY_CODE11", SqlNull(CHQ_REG_PAY_CODE11)),
						new SqlParameter("CHQ_REG_PAY_CODE12", SqlNull(CHQ_REG_PAY_CODE12)),
						new SqlParameter("CHQ_REG_PAY_CODE13", SqlNull(CHQ_REG_PAY_CODE13)),
						new SqlParameter("CHQ_REG_PAY_CODE14", SqlNull(CHQ_REG_PAY_CODE14)),
						new SqlParameter("CHQ_REG_PAY_CODE15", SqlNull(CHQ_REG_PAY_CODE15)),
						new SqlParameter("CHQ_REG_PAY_CODE16", SqlNull(CHQ_REG_PAY_CODE16)),
						new SqlParameter("CHQ_REG_PAY_CODE17", SqlNull(CHQ_REG_PAY_CODE17)),
						new SqlParameter("CHQ_REG_PAY_CODE18", SqlNull(CHQ_REG_PAY_CODE18)),
						new SqlParameter("CHQ_REG_PERC_TAX1", SqlNull(CHQ_REG_PERC_TAX1)),
						new SqlParameter("CHQ_REG_PERC_TAX2", SqlNull(CHQ_REG_PERC_TAX2)),
						new SqlParameter("CHQ_REG_PERC_TAX3", SqlNull(CHQ_REG_PERC_TAX3)),
						new SqlParameter("CHQ_REG_PERC_TAX4", SqlNull(CHQ_REG_PERC_TAX4)),
						new SqlParameter("CHQ_REG_PERC_TAX5", SqlNull(CHQ_REG_PERC_TAX5)),
						new SqlParameter("CHQ_REG_PERC_TAX6", SqlNull(CHQ_REG_PERC_TAX6)),
						new SqlParameter("CHQ_REG_PERC_TAX7", SqlNull(CHQ_REG_PERC_TAX7)),
						new SqlParameter("CHQ_REG_PERC_TAX8", SqlNull(CHQ_REG_PERC_TAX8)),
						new SqlParameter("CHQ_REG_PERC_TAX9", SqlNull(CHQ_REG_PERC_TAX9)),
						new SqlParameter("CHQ_REG_PERC_TAX10", SqlNull(CHQ_REG_PERC_TAX10)),
						new SqlParameter("CHQ_REG_PERC_TAX11", SqlNull(CHQ_REG_PERC_TAX11)),
						new SqlParameter("CHQ_REG_PERC_TAX12", SqlNull(CHQ_REG_PERC_TAX12)),
						new SqlParameter("CHQ_REG_PERC_TAX13", SqlNull(CHQ_REG_PERC_TAX13)),
						new SqlParameter("CHQ_REG_PERC_TAX14", SqlNull(CHQ_REG_PERC_TAX14)),
						new SqlParameter("CHQ_REG_PERC_TAX15", SqlNull(CHQ_REG_PERC_TAX15)),
						new SqlParameter("CHQ_REG_PERC_TAX16", SqlNull(CHQ_REG_PERC_TAX16)),
						new SqlParameter("CHQ_REG_PERC_TAX17", SqlNull(CHQ_REG_PERC_TAX17)),
						new SqlParameter("CHQ_REG_PERC_TAX18", SqlNull(CHQ_REG_PERC_TAX18)),
						new SqlParameter("CHQ_REG_MTH_BILL_AMT1", SqlNull(CHQ_REG_MTH_BILL_AMT1)),
						new SqlParameter("CHQ_REG_MTH_BILL_AMT2", SqlNull(CHQ_REG_MTH_BILL_AMT2)),
						new SqlParameter("CHQ_REG_MTH_BILL_AMT3", SqlNull(CHQ_REG_MTH_BILL_AMT3)),
						new SqlParameter("CHQ_REG_MTH_BILL_AMT4", SqlNull(CHQ_REG_MTH_BILL_AMT4)),
						new SqlParameter("CHQ_REG_MTH_BILL_AMT5", SqlNull(CHQ_REG_MTH_BILL_AMT5)),
						new SqlParameter("CHQ_REG_MTH_BILL_AMT6", SqlNull(CHQ_REG_MTH_BILL_AMT6)),
						new SqlParameter("CHQ_REG_MTH_BILL_AMT7", SqlNull(CHQ_REG_MTH_BILL_AMT7)),
						new SqlParameter("CHQ_REG_MTH_BILL_AMT8", SqlNull(CHQ_REG_MTH_BILL_AMT8)),
						new SqlParameter("CHQ_REG_MTH_BILL_AMT9", SqlNull(CHQ_REG_MTH_BILL_AMT9)),
						new SqlParameter("CHQ_REG_MTH_BILL_AMT10", SqlNull(CHQ_REG_MTH_BILL_AMT10)),
						new SqlParameter("CHQ_REG_MTH_BILL_AMT11", SqlNull(CHQ_REG_MTH_BILL_AMT11)),
						new SqlParameter("CHQ_REG_MTH_BILL_AMT12", SqlNull(CHQ_REG_MTH_BILL_AMT12)),
						new SqlParameter("CHQ_REG_MTH_BILL_AMT13", SqlNull(CHQ_REG_MTH_BILL_AMT13)),
						new SqlParameter("CHQ_REG_MTH_BILL_AMT14", SqlNull(CHQ_REG_MTH_BILL_AMT14)),
						new SqlParameter("CHQ_REG_MTH_BILL_AMT15", SqlNull(CHQ_REG_MTH_BILL_AMT15)),
						new SqlParameter("CHQ_REG_MTH_BILL_AMT16", SqlNull(CHQ_REG_MTH_BILL_AMT16)),
						new SqlParameter("CHQ_REG_MTH_BILL_AMT17", SqlNull(CHQ_REG_MTH_BILL_AMT17)),
						new SqlParameter("CHQ_REG_MTH_BILL_AMT18", SqlNull(CHQ_REG_MTH_BILL_AMT18)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_11", SqlNull(CHQ_REG_MTH_MISC_AMT_11)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_12", SqlNull(CHQ_REG_MTH_MISC_AMT_12)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_13", SqlNull(CHQ_REG_MTH_MISC_AMT_13)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_14", SqlNull(CHQ_REG_MTH_MISC_AMT_14)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_15", SqlNull(CHQ_REG_MTH_MISC_AMT_15)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_16", SqlNull(CHQ_REG_MTH_MISC_AMT_16)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_17", SqlNull(CHQ_REG_MTH_MISC_AMT_17)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_18", SqlNull(CHQ_REG_MTH_MISC_AMT_18)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_19", SqlNull(CHQ_REG_MTH_MISC_AMT_19)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_110", SqlNull(CHQ_REG_MTH_MISC_AMT_110)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_111", SqlNull(CHQ_REG_MTH_MISC_AMT_111)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_112", SqlNull(CHQ_REG_MTH_MISC_AMT_112)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_113", SqlNull(CHQ_REG_MTH_MISC_AMT_113)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_114", SqlNull(CHQ_REG_MTH_MISC_AMT_114)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_115", SqlNull(CHQ_REG_MTH_MISC_AMT_115)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_116", SqlNull(CHQ_REG_MTH_MISC_AMT_116)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_117", SqlNull(CHQ_REG_MTH_MISC_AMT_117)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_118", SqlNull(CHQ_REG_MTH_MISC_AMT_118)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_21", SqlNull(CHQ_REG_MTH_MISC_AMT_21)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_22", SqlNull(CHQ_REG_MTH_MISC_AMT_22)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_23", SqlNull(CHQ_REG_MTH_MISC_AMT_23)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_24", SqlNull(CHQ_REG_MTH_MISC_AMT_24)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_25", SqlNull(CHQ_REG_MTH_MISC_AMT_25)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_26", SqlNull(CHQ_REG_MTH_MISC_AMT_26)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_27", SqlNull(CHQ_REG_MTH_MISC_AMT_27)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_28", SqlNull(CHQ_REG_MTH_MISC_AMT_28)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_29", SqlNull(CHQ_REG_MTH_MISC_AMT_29)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_210", SqlNull(CHQ_REG_MTH_MISC_AMT_210)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_211", SqlNull(CHQ_REG_MTH_MISC_AMT_211)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_212", SqlNull(CHQ_REG_MTH_MISC_AMT_212)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_213", SqlNull(CHQ_REG_MTH_MISC_AMT_213)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_214", SqlNull(CHQ_REG_MTH_MISC_AMT_214)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_215", SqlNull(CHQ_REG_MTH_MISC_AMT_215)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_216", SqlNull(CHQ_REG_MTH_MISC_AMT_216)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_217", SqlNull(CHQ_REG_MTH_MISC_AMT_217)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_218", SqlNull(CHQ_REG_MTH_MISC_AMT_218)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_31", SqlNull(CHQ_REG_MTH_MISC_AMT_31)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_32", SqlNull(CHQ_REG_MTH_MISC_AMT_32)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_33", SqlNull(CHQ_REG_MTH_MISC_AMT_33)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_34", SqlNull(CHQ_REG_MTH_MISC_AMT_34)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_35", SqlNull(CHQ_REG_MTH_MISC_AMT_35)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_36", SqlNull(CHQ_REG_MTH_MISC_AMT_36)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_37", SqlNull(CHQ_REG_MTH_MISC_AMT_37)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_38", SqlNull(CHQ_REG_MTH_MISC_AMT_38)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_39", SqlNull(CHQ_REG_MTH_MISC_AMT_39)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_310", SqlNull(CHQ_REG_MTH_MISC_AMT_310)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_311", SqlNull(CHQ_REG_MTH_MISC_AMT_311)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_312", SqlNull(CHQ_REG_MTH_MISC_AMT_312)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_313", SqlNull(CHQ_REG_MTH_MISC_AMT_313)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_314", SqlNull(CHQ_REG_MTH_MISC_AMT_314)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_315", SqlNull(CHQ_REG_MTH_MISC_AMT_315)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_316", SqlNull(CHQ_REG_MTH_MISC_AMT_316)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_317", SqlNull(CHQ_REG_MTH_MISC_AMT_317)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_318", SqlNull(CHQ_REG_MTH_MISC_AMT_318)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_41", SqlNull(CHQ_REG_MTH_MISC_AMT_41)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_42", SqlNull(CHQ_REG_MTH_MISC_AMT_42)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_43", SqlNull(CHQ_REG_MTH_MISC_AMT_43)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_44", SqlNull(CHQ_REG_MTH_MISC_AMT_44)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_45", SqlNull(CHQ_REG_MTH_MISC_AMT_45)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_46", SqlNull(CHQ_REG_MTH_MISC_AMT_46)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_47", SqlNull(CHQ_REG_MTH_MISC_AMT_47)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_48", SqlNull(CHQ_REG_MTH_MISC_AMT_48)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_49", SqlNull(CHQ_REG_MTH_MISC_AMT_49)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_410", SqlNull(CHQ_REG_MTH_MISC_AMT_410)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_411", SqlNull(CHQ_REG_MTH_MISC_AMT_411)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_412", SqlNull(CHQ_REG_MTH_MISC_AMT_412)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_413", SqlNull(CHQ_REG_MTH_MISC_AMT_413)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_414", SqlNull(CHQ_REG_MTH_MISC_AMT_414)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_415", SqlNull(CHQ_REG_MTH_MISC_AMT_415)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_416", SqlNull(CHQ_REG_MTH_MISC_AMT_416)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_417", SqlNull(CHQ_REG_MTH_MISC_AMT_417)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_418", SqlNull(CHQ_REG_MTH_MISC_AMT_418)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_51", SqlNull(CHQ_REG_MTH_MISC_AMT_51)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_52", SqlNull(CHQ_REG_MTH_MISC_AMT_52)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_53", SqlNull(CHQ_REG_MTH_MISC_AMT_53)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_54", SqlNull(CHQ_REG_MTH_MISC_AMT_54)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_55", SqlNull(CHQ_REG_MTH_MISC_AMT_55)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_56", SqlNull(CHQ_REG_MTH_MISC_AMT_56)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_57", SqlNull(CHQ_REG_MTH_MISC_AMT_57)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_58", SqlNull(CHQ_REG_MTH_MISC_AMT_58)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_59", SqlNull(CHQ_REG_MTH_MISC_AMT_59)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_510", SqlNull(CHQ_REG_MTH_MISC_AMT_510)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_511", SqlNull(CHQ_REG_MTH_MISC_AMT_511)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_512", SqlNull(CHQ_REG_MTH_MISC_AMT_512)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_513", SqlNull(CHQ_REG_MTH_MISC_AMT_513)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_514", SqlNull(CHQ_REG_MTH_MISC_AMT_514)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_515", SqlNull(CHQ_REG_MTH_MISC_AMT_515)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_516", SqlNull(CHQ_REG_MTH_MISC_AMT_516)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_517", SqlNull(CHQ_REG_MTH_MISC_AMT_517)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_518", SqlNull(CHQ_REG_MTH_MISC_AMT_518)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_61", SqlNull(CHQ_REG_MTH_MISC_AMT_61)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_62", SqlNull(CHQ_REG_MTH_MISC_AMT_62)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_63", SqlNull(CHQ_REG_MTH_MISC_AMT_63)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_64", SqlNull(CHQ_REG_MTH_MISC_AMT_64)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_65", SqlNull(CHQ_REG_MTH_MISC_AMT_65)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_66", SqlNull(CHQ_REG_MTH_MISC_AMT_66)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_67", SqlNull(CHQ_REG_MTH_MISC_AMT_67)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_68", SqlNull(CHQ_REG_MTH_MISC_AMT_68)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_69", SqlNull(CHQ_REG_MTH_MISC_AMT_69)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_610", SqlNull(CHQ_REG_MTH_MISC_AMT_610)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_611", SqlNull(CHQ_REG_MTH_MISC_AMT_611)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_612", SqlNull(CHQ_REG_MTH_MISC_AMT_612)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_613", SqlNull(CHQ_REG_MTH_MISC_AMT_613)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_614", SqlNull(CHQ_REG_MTH_MISC_AMT_614)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_615", SqlNull(CHQ_REG_MTH_MISC_AMT_615)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_616", SqlNull(CHQ_REG_MTH_MISC_AMT_616)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_617", SqlNull(CHQ_REG_MTH_MISC_AMT_617)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_618", SqlNull(CHQ_REG_MTH_MISC_AMT_618)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_71", SqlNull(CHQ_REG_MTH_MISC_AMT_71)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_72", SqlNull(CHQ_REG_MTH_MISC_AMT_72)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_73", SqlNull(CHQ_REG_MTH_MISC_AMT_73)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_74", SqlNull(CHQ_REG_MTH_MISC_AMT_74)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_75", SqlNull(CHQ_REG_MTH_MISC_AMT_75)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_76", SqlNull(CHQ_REG_MTH_MISC_AMT_76)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_77", SqlNull(CHQ_REG_MTH_MISC_AMT_77)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_78", SqlNull(CHQ_REG_MTH_MISC_AMT_78)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_79", SqlNull(CHQ_REG_MTH_MISC_AMT_79)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_710", SqlNull(CHQ_REG_MTH_MISC_AMT_710)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_711", SqlNull(CHQ_REG_MTH_MISC_AMT_711)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_712", SqlNull(CHQ_REG_MTH_MISC_AMT_712)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_713", SqlNull(CHQ_REG_MTH_MISC_AMT_713)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_714", SqlNull(CHQ_REG_MTH_MISC_AMT_714)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_715", SqlNull(CHQ_REG_MTH_MISC_AMT_715)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_716", SqlNull(CHQ_REG_MTH_MISC_AMT_716)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_717", SqlNull(CHQ_REG_MTH_MISC_AMT_717)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_718", SqlNull(CHQ_REG_MTH_MISC_AMT_718)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_81", SqlNull(CHQ_REG_MTH_MISC_AMT_81)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_82", SqlNull(CHQ_REG_MTH_MISC_AMT_82)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_83", SqlNull(CHQ_REG_MTH_MISC_AMT_83)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_84", SqlNull(CHQ_REG_MTH_MISC_AMT_84)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_85", SqlNull(CHQ_REG_MTH_MISC_AMT_85)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_86", SqlNull(CHQ_REG_MTH_MISC_AMT_86)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_87", SqlNull(CHQ_REG_MTH_MISC_AMT_87)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_88", SqlNull(CHQ_REG_MTH_MISC_AMT_88)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_89", SqlNull(CHQ_REG_MTH_MISC_AMT_89)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_810", SqlNull(CHQ_REG_MTH_MISC_AMT_810)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_811", SqlNull(CHQ_REG_MTH_MISC_AMT_811)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_812", SqlNull(CHQ_REG_MTH_MISC_AMT_812)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_813", SqlNull(CHQ_REG_MTH_MISC_AMT_813)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_814", SqlNull(CHQ_REG_MTH_MISC_AMT_814)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_815", SqlNull(CHQ_REG_MTH_MISC_AMT_815)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_816", SqlNull(CHQ_REG_MTH_MISC_AMT_816)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_817", SqlNull(CHQ_REG_MTH_MISC_AMT_817)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_818", SqlNull(CHQ_REG_MTH_MISC_AMT_818)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_91", SqlNull(CHQ_REG_MTH_MISC_AMT_91)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_92", SqlNull(CHQ_REG_MTH_MISC_AMT_92)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_93", SqlNull(CHQ_REG_MTH_MISC_AMT_93)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_94", SqlNull(CHQ_REG_MTH_MISC_AMT_94)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_95", SqlNull(CHQ_REG_MTH_MISC_AMT_95)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_96", SqlNull(CHQ_REG_MTH_MISC_AMT_96)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_97", SqlNull(CHQ_REG_MTH_MISC_AMT_97)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_98", SqlNull(CHQ_REG_MTH_MISC_AMT_98)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_99", SqlNull(CHQ_REG_MTH_MISC_AMT_99)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_910", SqlNull(CHQ_REG_MTH_MISC_AMT_910)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_911", SqlNull(CHQ_REG_MTH_MISC_AMT_911)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_912", SqlNull(CHQ_REG_MTH_MISC_AMT_912)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_913", SqlNull(CHQ_REG_MTH_MISC_AMT_913)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_914", SqlNull(CHQ_REG_MTH_MISC_AMT_914)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_915", SqlNull(CHQ_REG_MTH_MISC_AMT_915)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_916", SqlNull(CHQ_REG_MTH_MISC_AMT_916)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_917", SqlNull(CHQ_REG_MTH_MISC_AMT_917)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_918", SqlNull(CHQ_REG_MTH_MISC_AMT_918)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_101", SqlNull(CHQ_REG_MTH_MISC_AMT_101)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_102", SqlNull(CHQ_REG_MTH_MISC_AMT_102)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_103", SqlNull(CHQ_REG_MTH_MISC_AMT_103)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_104", SqlNull(CHQ_REG_MTH_MISC_AMT_104)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_105", SqlNull(CHQ_REG_MTH_MISC_AMT_105)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_106", SqlNull(CHQ_REG_MTH_MISC_AMT_106)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_107", SqlNull(CHQ_REG_MTH_MISC_AMT_107)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_108", SqlNull(CHQ_REG_MTH_MISC_AMT_108)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_109", SqlNull(CHQ_REG_MTH_MISC_AMT_109)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_1010", SqlNull(CHQ_REG_MTH_MISC_AMT_1010)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_1011", SqlNull(CHQ_REG_MTH_MISC_AMT_1011)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_1012", SqlNull(CHQ_REG_MTH_MISC_AMT_1012)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_1013", SqlNull(CHQ_REG_MTH_MISC_AMT_1013)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_1014", SqlNull(CHQ_REG_MTH_MISC_AMT_1014)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_1015", SqlNull(CHQ_REG_MTH_MISC_AMT_1015)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_1016", SqlNull(CHQ_REG_MTH_MISC_AMT_1016)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_1017", SqlNull(CHQ_REG_MTH_MISC_AMT_1017)),
						new SqlParameter("CHQ_REG_MTH_MISC_AMT_1018", SqlNull(CHQ_REG_MTH_MISC_AMT_1018)),
						new SqlParameter("CHQ_REG_MTH_EXP_AMT1", SqlNull(CHQ_REG_MTH_EXP_AMT1)),
						new SqlParameter("CHQ_REG_MTH_EXP_AMT2", SqlNull(CHQ_REG_MTH_EXP_AMT2)),
						new SqlParameter("CHQ_REG_MTH_EXP_AMT3", SqlNull(CHQ_REG_MTH_EXP_AMT3)),
						new SqlParameter("CHQ_REG_MTH_EXP_AMT4", SqlNull(CHQ_REG_MTH_EXP_AMT4)),
						new SqlParameter("CHQ_REG_MTH_EXP_AMT5", SqlNull(CHQ_REG_MTH_EXP_AMT5)),
						new SqlParameter("CHQ_REG_MTH_EXP_AMT6", SqlNull(CHQ_REG_MTH_EXP_AMT6)),
						new SqlParameter("CHQ_REG_MTH_EXP_AMT7", SqlNull(CHQ_REG_MTH_EXP_AMT7)),
						new SqlParameter("CHQ_REG_MTH_EXP_AMT8", SqlNull(CHQ_REG_MTH_EXP_AMT8)),
						new SqlParameter("CHQ_REG_MTH_EXP_AMT9", SqlNull(CHQ_REG_MTH_EXP_AMT9)),
						new SqlParameter("CHQ_REG_MTH_EXP_AMT10", SqlNull(CHQ_REG_MTH_EXP_AMT10)),
						new SqlParameter("CHQ_REG_MTH_EXP_AMT11", SqlNull(CHQ_REG_MTH_EXP_AMT11)),
						new SqlParameter("CHQ_REG_MTH_EXP_AMT12", SqlNull(CHQ_REG_MTH_EXP_AMT12)),
						new SqlParameter("CHQ_REG_MTH_EXP_AMT13", SqlNull(CHQ_REG_MTH_EXP_AMT13)),
						new SqlParameter("CHQ_REG_MTH_EXP_AMT14", SqlNull(CHQ_REG_MTH_EXP_AMT14)),
						new SqlParameter("CHQ_REG_MTH_EXP_AMT15", SqlNull(CHQ_REG_MTH_EXP_AMT15)),
						new SqlParameter("CHQ_REG_MTH_EXP_AMT16", SqlNull(CHQ_REG_MTH_EXP_AMT16)),
						new SqlParameter("CHQ_REG_MTH_EXP_AMT17", SqlNull(CHQ_REG_MTH_EXP_AMT17)),
						new SqlParameter("CHQ_REG_MTH_EXP_AMT18", SqlNull(CHQ_REG_MTH_EXP_AMT18)),
						new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY1", SqlNull(CHQ_REG_COMP_ANN_EXP_THIS_PAY1)),
						new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY2", SqlNull(CHQ_REG_COMP_ANN_EXP_THIS_PAY2)),
						new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY3", SqlNull(CHQ_REG_COMP_ANN_EXP_THIS_PAY3)),
						new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY4", SqlNull(CHQ_REG_COMP_ANN_EXP_THIS_PAY4)),
						new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY5", SqlNull(CHQ_REG_COMP_ANN_EXP_THIS_PAY5)),
						new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY6", SqlNull(CHQ_REG_COMP_ANN_EXP_THIS_PAY6)),
						new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY7", SqlNull(CHQ_REG_COMP_ANN_EXP_THIS_PAY7)),
						new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY8", SqlNull(CHQ_REG_COMP_ANN_EXP_THIS_PAY8)),
						new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY9", SqlNull(CHQ_REG_COMP_ANN_EXP_THIS_PAY9)),
						new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY10", SqlNull(CHQ_REG_COMP_ANN_EXP_THIS_PAY10)),
						new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY11", SqlNull(CHQ_REG_COMP_ANN_EXP_THIS_PAY11)),
						new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY12", SqlNull(CHQ_REG_COMP_ANN_EXP_THIS_PAY12)),
						new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY13", SqlNull(CHQ_REG_COMP_ANN_EXP_THIS_PAY13)),
						new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY14", SqlNull(CHQ_REG_COMP_ANN_EXP_THIS_PAY14)),
						new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY15", SqlNull(CHQ_REG_COMP_ANN_EXP_THIS_PAY15)),
						new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY16", SqlNull(CHQ_REG_COMP_ANN_EXP_THIS_PAY16)),
						new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY17", SqlNull(CHQ_REG_COMP_ANN_EXP_THIS_PAY17)),
						new SqlParameter("CHQ_REG_COMP_ANN_EXP_THIS_PAY18", SqlNull(CHQ_REG_COMP_ANN_EXP_THIS_PAY18)),
						new SqlParameter("CHQ_REG_MTH_CEIL_AMT1", SqlNull(CHQ_REG_MTH_CEIL_AMT1)),
						new SqlParameter("CHQ_REG_MTH_CEIL_AMT2", SqlNull(CHQ_REG_MTH_CEIL_AMT2)),
						new SqlParameter("CHQ_REG_MTH_CEIL_AMT3", SqlNull(CHQ_REG_MTH_CEIL_AMT3)),
						new SqlParameter("CHQ_REG_MTH_CEIL_AMT4", SqlNull(CHQ_REG_MTH_CEIL_AMT4)),
						new SqlParameter("CHQ_REG_MTH_CEIL_AMT5", SqlNull(CHQ_REG_MTH_CEIL_AMT5)),
						new SqlParameter("CHQ_REG_MTH_CEIL_AMT6", SqlNull(CHQ_REG_MTH_CEIL_AMT6)),
						new SqlParameter("CHQ_REG_MTH_CEIL_AMT7", SqlNull(CHQ_REG_MTH_CEIL_AMT7)),
						new SqlParameter("CHQ_REG_MTH_CEIL_AMT8", SqlNull(CHQ_REG_MTH_CEIL_AMT8)),
						new SqlParameter("CHQ_REG_MTH_CEIL_AMT9", SqlNull(CHQ_REG_MTH_CEIL_AMT9)),
						new SqlParameter("CHQ_REG_MTH_CEIL_AMT10", SqlNull(CHQ_REG_MTH_CEIL_AMT10)),
						new SqlParameter("CHQ_REG_MTH_CEIL_AMT11", SqlNull(CHQ_REG_MTH_CEIL_AMT11)),
						new SqlParameter("CHQ_REG_MTH_CEIL_AMT12", SqlNull(CHQ_REG_MTH_CEIL_AMT12)),
						new SqlParameter("CHQ_REG_MTH_CEIL_AMT13", SqlNull(CHQ_REG_MTH_CEIL_AMT13)),
						new SqlParameter("CHQ_REG_MTH_CEIL_AMT14", SqlNull(CHQ_REG_MTH_CEIL_AMT14)),
						new SqlParameter("CHQ_REG_MTH_CEIL_AMT15", SqlNull(CHQ_REG_MTH_CEIL_AMT15)),
						new SqlParameter("CHQ_REG_MTH_CEIL_AMT16", SqlNull(CHQ_REG_MTH_CEIL_AMT16)),
						new SqlParameter("CHQ_REG_MTH_CEIL_AMT17", SqlNull(CHQ_REG_MTH_CEIL_AMT17)),
						new SqlParameter("CHQ_REG_MTH_CEIL_AMT18", SqlNull(CHQ_REG_MTH_CEIL_AMT18)),
						new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY1", SqlNull(CHQ_REG_COMP_ANN_CEIL_THIS_PAY1)),
						new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY2", SqlNull(CHQ_REG_COMP_ANN_CEIL_THIS_PAY2)),
						new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY3", SqlNull(CHQ_REG_COMP_ANN_CEIL_THIS_PAY3)),
						new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY4", SqlNull(CHQ_REG_COMP_ANN_CEIL_THIS_PAY4)),
						new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY5", SqlNull(CHQ_REG_COMP_ANN_CEIL_THIS_PAY5)),
						new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY6", SqlNull(CHQ_REG_COMP_ANN_CEIL_THIS_PAY6)),
						new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY7", SqlNull(CHQ_REG_COMP_ANN_CEIL_THIS_PAY7)),
						new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY8", SqlNull(CHQ_REG_COMP_ANN_CEIL_THIS_PAY8)),
						new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY9", SqlNull(CHQ_REG_COMP_ANN_CEIL_THIS_PAY9)),
						new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY10", SqlNull(CHQ_REG_COMP_ANN_CEIL_THIS_PAY10)),
						new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY11", SqlNull(CHQ_REG_COMP_ANN_CEIL_THIS_PAY11)),
						new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY12", SqlNull(CHQ_REG_COMP_ANN_CEIL_THIS_PAY12)),
						new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY13", SqlNull(CHQ_REG_COMP_ANN_CEIL_THIS_PAY13)),
						new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY14", SqlNull(CHQ_REG_COMP_ANN_CEIL_THIS_PAY14)),
						new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY15", SqlNull(CHQ_REG_COMP_ANN_CEIL_THIS_PAY15)),
						new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY16", SqlNull(CHQ_REG_COMP_ANN_CEIL_THIS_PAY16)),
						new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY17", SqlNull(CHQ_REG_COMP_ANN_CEIL_THIS_PAY17)),
						new SqlParameter("CHQ_REG_COMP_ANN_CEIL_THIS_PAY18", SqlNull(CHQ_REG_COMP_ANN_CEIL_THIS_PAY18)),
						new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH1", SqlNull(CHQ_REG_EARNINGS_THIS_MTH1)),
						new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH2", SqlNull(CHQ_REG_EARNINGS_THIS_MTH2)),
						new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH3", SqlNull(CHQ_REG_EARNINGS_THIS_MTH3)),
						new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH4", SqlNull(CHQ_REG_EARNINGS_THIS_MTH4)),
						new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH5", SqlNull(CHQ_REG_EARNINGS_THIS_MTH5)),
						new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH6", SqlNull(CHQ_REG_EARNINGS_THIS_MTH6)),
						new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH7", SqlNull(CHQ_REG_EARNINGS_THIS_MTH7)),
						new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH8", SqlNull(CHQ_REG_EARNINGS_THIS_MTH8)),
						new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH9", SqlNull(CHQ_REG_EARNINGS_THIS_MTH9)),
						new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH10", SqlNull(CHQ_REG_EARNINGS_THIS_MTH10)),
						new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH11", SqlNull(CHQ_REG_EARNINGS_THIS_MTH11)),
						new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH12", SqlNull(CHQ_REG_EARNINGS_THIS_MTH12)),
						new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH13", SqlNull(CHQ_REG_EARNINGS_THIS_MTH13)),
						new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH14", SqlNull(CHQ_REG_EARNINGS_THIS_MTH14)),
						new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH15", SqlNull(CHQ_REG_EARNINGS_THIS_MTH15)),
						new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH16", SqlNull(CHQ_REG_EARNINGS_THIS_MTH16)),
						new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH17", SqlNull(CHQ_REG_EARNINGS_THIS_MTH17)),
						new SqlParameter("CHQ_REG_EARNINGS_THIS_MTH18", SqlNull(CHQ_REG_EARNINGS_THIS_MTH18)),
						new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH1", SqlNull(CHQ_REG_REGULAR_PAY_THIS_MTH1)),
						new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH2", SqlNull(CHQ_REG_REGULAR_PAY_THIS_MTH2)),
						new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH3", SqlNull(CHQ_REG_REGULAR_PAY_THIS_MTH3)),
						new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH4", SqlNull(CHQ_REG_REGULAR_PAY_THIS_MTH4)),
						new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH5", SqlNull(CHQ_REG_REGULAR_PAY_THIS_MTH5)),
						new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH6", SqlNull(CHQ_REG_REGULAR_PAY_THIS_MTH6)),
						new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH7", SqlNull(CHQ_REG_REGULAR_PAY_THIS_MTH7)),
						new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH8", SqlNull(CHQ_REG_REGULAR_PAY_THIS_MTH8)),
						new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH9", SqlNull(CHQ_REG_REGULAR_PAY_THIS_MTH9)),
						new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH10", SqlNull(CHQ_REG_REGULAR_PAY_THIS_MTH10)),
						new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH11", SqlNull(CHQ_REG_REGULAR_PAY_THIS_MTH11)),
						new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH12", SqlNull(CHQ_REG_REGULAR_PAY_THIS_MTH12)),
						new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH13", SqlNull(CHQ_REG_REGULAR_PAY_THIS_MTH13)),
						new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH14", SqlNull(CHQ_REG_REGULAR_PAY_THIS_MTH14)),
						new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH15", SqlNull(CHQ_REG_REGULAR_PAY_THIS_MTH15)),
						new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH16", SqlNull(CHQ_REG_REGULAR_PAY_THIS_MTH16)),
						new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH17", SqlNull(CHQ_REG_REGULAR_PAY_THIS_MTH17)),
						new SqlParameter("CHQ_REG_REGULAR_PAY_THIS_MTH18", SqlNull(CHQ_REG_REGULAR_PAY_THIS_MTH18)),
						new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH1", SqlNull(CHQ_REG_REGULAR_TAX_THIS_MTH1)),
						new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH2", SqlNull(CHQ_REG_REGULAR_TAX_THIS_MTH2)),
						new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH3", SqlNull(CHQ_REG_REGULAR_TAX_THIS_MTH3)),
						new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH4", SqlNull(CHQ_REG_REGULAR_TAX_THIS_MTH4)),
						new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH5", SqlNull(CHQ_REG_REGULAR_TAX_THIS_MTH5)),
						new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH6", SqlNull(CHQ_REG_REGULAR_TAX_THIS_MTH6)),
						new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH7", SqlNull(CHQ_REG_REGULAR_TAX_THIS_MTH7)),
						new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH8", SqlNull(CHQ_REG_REGULAR_TAX_THIS_MTH8)),
						new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH9", SqlNull(CHQ_REG_REGULAR_TAX_THIS_MTH9)),
						new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH10", SqlNull(CHQ_REG_REGULAR_TAX_THIS_MTH10)),
						new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH11", SqlNull(CHQ_REG_REGULAR_TAX_THIS_MTH11)),
						new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH12", SqlNull(CHQ_REG_REGULAR_TAX_THIS_MTH12)),
						new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH13", SqlNull(CHQ_REG_REGULAR_TAX_THIS_MTH13)),
						new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH14", SqlNull(CHQ_REG_REGULAR_TAX_THIS_MTH14)),
						new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH15", SqlNull(CHQ_REG_REGULAR_TAX_THIS_MTH15)),
						new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH16", SqlNull(CHQ_REG_REGULAR_TAX_THIS_MTH16)),
						new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH17", SqlNull(CHQ_REG_REGULAR_TAX_THIS_MTH17)),
						new SqlParameter("CHQ_REG_REGULAR_TAX_THIS_MTH18", SqlNull(CHQ_REG_REGULAR_TAX_THIS_MTH18)),
						new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH1", SqlNull(CHQ_REG_MAN_PAY_THIS_MTH1)),
						new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH2", SqlNull(CHQ_REG_MAN_PAY_THIS_MTH2)),
						new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH3", SqlNull(CHQ_REG_MAN_PAY_THIS_MTH3)),
						new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH4", SqlNull(CHQ_REG_MAN_PAY_THIS_MTH4)),
						new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH5", SqlNull(CHQ_REG_MAN_PAY_THIS_MTH5)),
						new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH6", SqlNull(CHQ_REG_MAN_PAY_THIS_MTH6)),
						new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH7", SqlNull(CHQ_REG_MAN_PAY_THIS_MTH7)),
						new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH8", SqlNull(CHQ_REG_MAN_PAY_THIS_MTH8)),
						new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH9", SqlNull(CHQ_REG_MAN_PAY_THIS_MTH9)),
						new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH10", SqlNull(CHQ_REG_MAN_PAY_THIS_MTH10)),
						new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH11", SqlNull(CHQ_REG_MAN_PAY_THIS_MTH11)),
						new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH12", SqlNull(CHQ_REG_MAN_PAY_THIS_MTH12)),
						new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH13", SqlNull(CHQ_REG_MAN_PAY_THIS_MTH13)),
						new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH14", SqlNull(CHQ_REG_MAN_PAY_THIS_MTH14)),
						new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH15", SqlNull(CHQ_REG_MAN_PAY_THIS_MTH15)),
						new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH16", SqlNull(CHQ_REG_MAN_PAY_THIS_MTH16)),
						new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH17", SqlNull(CHQ_REG_MAN_PAY_THIS_MTH17)),
						new SqlParameter("CHQ_REG_MAN_PAY_THIS_MTH18", SqlNull(CHQ_REG_MAN_PAY_THIS_MTH18)),
						new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH1", SqlNull(CHQ_REG_MAN_TAX_THIS_MTH1)),
						new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH2", SqlNull(CHQ_REG_MAN_TAX_THIS_MTH2)),
						new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH3", SqlNull(CHQ_REG_MAN_TAX_THIS_MTH3)),
						new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH4", SqlNull(CHQ_REG_MAN_TAX_THIS_MTH4)),
						new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH5", SqlNull(CHQ_REG_MAN_TAX_THIS_MTH5)),
						new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH6", SqlNull(CHQ_REG_MAN_TAX_THIS_MTH6)),
						new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH7", SqlNull(CHQ_REG_MAN_TAX_THIS_MTH7)),
						new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH8", SqlNull(CHQ_REG_MAN_TAX_THIS_MTH8)),
						new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH9", SqlNull(CHQ_REG_MAN_TAX_THIS_MTH9)),
						new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH10", SqlNull(CHQ_REG_MAN_TAX_THIS_MTH10)),
						new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH11", SqlNull(CHQ_REG_MAN_TAX_THIS_MTH11)),
						new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH12", SqlNull(CHQ_REG_MAN_TAX_THIS_MTH12)),
						new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH13", SqlNull(CHQ_REG_MAN_TAX_THIS_MTH13)),
						new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH14", SqlNull(CHQ_REG_MAN_TAX_THIS_MTH14)),
						new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH15", SqlNull(CHQ_REG_MAN_TAX_THIS_MTH15)),
						new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH16", SqlNull(CHQ_REG_MAN_TAX_THIS_MTH16)),
						new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH17", SqlNull(CHQ_REG_MAN_TAX_THIS_MTH17)),
						new SqlParameter("CHQ_REG_MAN_TAX_THIS_MTH18", SqlNull(CHQ_REG_MAN_TAX_THIS_MTH18)),
						new SqlParameter("CHQ_REG_PAY_DATE1", SqlNull(CHQ_REG_PAY_DATE1)),
						new SqlParameter("CHQ_REG_PAY_DATE2", SqlNull(CHQ_REG_PAY_DATE2)),
						new SqlParameter("CHQ_REG_PAY_DATE3", SqlNull(CHQ_REG_PAY_DATE3)),
						new SqlParameter("CHQ_REG_PAY_DATE4", SqlNull(CHQ_REG_PAY_DATE4)),
						new SqlParameter("CHQ_REG_PAY_DATE5", SqlNull(CHQ_REG_PAY_DATE5)),
						new SqlParameter("CHQ_REG_PAY_DATE6", SqlNull(CHQ_REG_PAY_DATE6)),
						new SqlParameter("CHQ_REG_PAY_DATE7", SqlNull(CHQ_REG_PAY_DATE7)),
						new SqlParameter("CHQ_REG_PAY_DATE8", SqlNull(CHQ_REG_PAY_DATE8)),
						new SqlParameter("CHQ_REG_PAY_DATE9", SqlNull(CHQ_REG_PAY_DATE9)),
						new SqlParameter("CHQ_REG_PAY_DATE10", SqlNull(CHQ_REG_PAY_DATE10)),
						new SqlParameter("CHQ_REG_PAY_DATE11", SqlNull(CHQ_REG_PAY_DATE11)),
						new SqlParameter("CHQ_REG_PAY_DATE12", SqlNull(CHQ_REG_PAY_DATE12)),
						new SqlParameter("CHQ_REG_PAY_DATE13", SqlNull(CHQ_REG_PAY_DATE13)),
						new SqlParameter("CHQ_REG_PAY_DATE14", SqlNull(CHQ_REG_PAY_DATE14)),
						new SqlParameter("CHQ_REG_PAY_DATE15", SqlNull(CHQ_REG_PAY_DATE15)),
						new SqlParameter("CHQ_REG_PAY_DATE16", SqlNull(CHQ_REG_PAY_DATE16)),
						new SqlParameter("CHQ_REG_PAY_DATE17", SqlNull(CHQ_REG_PAY_DATE17)),
						new SqlParameter("CHQ_REG_PAY_DATE18", SqlNull(CHQ_REG_PAY_DATE18)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F060_CHEQUE_REG_MSTR_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CHQ_REG_CLINIC_NBR_1_2 = ConvertDEC(Reader["CHQ_REG_CLINIC_NBR_1_2"]);
						CHQ_REG_DEPT = ConvertDEC(Reader["CHQ_REG_DEPT"]);
						CHQ_REG_DOC_NBR = Reader["CHQ_REG_DOC_NBR"].ToString();
						CHQ_REG_PERC_BILL1 = ConvertDEC(Reader["CHQ_REG_PERC_BILL1"]);
						CHQ_REG_PERC_BILL2 = ConvertDEC(Reader["CHQ_REG_PERC_BILL2"]);
						CHQ_REG_PERC_BILL3 = ConvertDEC(Reader["CHQ_REG_PERC_BILL3"]);
						CHQ_REG_PERC_BILL4 = ConvertDEC(Reader["CHQ_REG_PERC_BILL4"]);
						CHQ_REG_PERC_BILL5 = ConvertDEC(Reader["CHQ_REG_PERC_BILL5"]);
						CHQ_REG_PERC_BILL6 = ConvertDEC(Reader["CHQ_REG_PERC_BILL6"]);
						CHQ_REG_PERC_BILL7 = ConvertDEC(Reader["CHQ_REG_PERC_BILL7"]);
						CHQ_REG_PERC_BILL8 = ConvertDEC(Reader["CHQ_REG_PERC_BILL8"]);
						CHQ_REG_PERC_BILL9 = ConvertDEC(Reader["CHQ_REG_PERC_BILL9"]);
						CHQ_REG_PERC_BILL10 = ConvertDEC(Reader["CHQ_REG_PERC_BILL10"]);
						CHQ_REG_PERC_BILL11 = ConvertDEC(Reader["CHQ_REG_PERC_BILL11"]);
						CHQ_REG_PERC_BILL12 = ConvertDEC(Reader["CHQ_REG_PERC_BILL12"]);
						CHQ_REG_PERC_BILL13 = ConvertDEC(Reader["CHQ_REG_PERC_BILL13"]);
						CHQ_REG_PERC_BILL14 = ConvertDEC(Reader["CHQ_REG_PERC_BILL14"]);
						CHQ_REG_PERC_BILL15 = ConvertDEC(Reader["CHQ_REG_PERC_BILL15"]);
						CHQ_REG_PERC_BILL16 = ConvertDEC(Reader["CHQ_REG_PERC_BILL16"]);
						CHQ_REG_PERC_BILL17 = ConvertDEC(Reader["CHQ_REG_PERC_BILL17"]);
						CHQ_REG_PERC_BILL18 = ConvertDEC(Reader["CHQ_REG_PERC_BILL18"]);
						CHQ_REG_PERC_MISC1 = ConvertDEC(Reader["CHQ_REG_PERC_MISC1"]);
						CHQ_REG_PERC_MISC2 = ConvertDEC(Reader["CHQ_REG_PERC_MISC2"]);
						CHQ_REG_PERC_MISC3 = ConvertDEC(Reader["CHQ_REG_PERC_MISC3"]);
						CHQ_REG_PERC_MISC4 = ConvertDEC(Reader["CHQ_REG_PERC_MISC4"]);
						CHQ_REG_PERC_MISC5 = ConvertDEC(Reader["CHQ_REG_PERC_MISC5"]);
						CHQ_REG_PERC_MISC6 = ConvertDEC(Reader["CHQ_REG_PERC_MISC6"]);
						CHQ_REG_PERC_MISC7 = ConvertDEC(Reader["CHQ_REG_PERC_MISC7"]);
						CHQ_REG_PERC_MISC8 = ConvertDEC(Reader["CHQ_REG_PERC_MISC8"]);
						CHQ_REG_PERC_MISC9 = ConvertDEC(Reader["CHQ_REG_PERC_MISC9"]);
						CHQ_REG_PERC_MISC10 = ConvertDEC(Reader["CHQ_REG_PERC_MISC10"]);
						CHQ_REG_PERC_MISC11 = ConvertDEC(Reader["CHQ_REG_PERC_MISC11"]);
						CHQ_REG_PERC_MISC12 = ConvertDEC(Reader["CHQ_REG_PERC_MISC12"]);
						CHQ_REG_PERC_MISC13 = ConvertDEC(Reader["CHQ_REG_PERC_MISC13"]);
						CHQ_REG_PERC_MISC14 = ConvertDEC(Reader["CHQ_REG_PERC_MISC14"]);
						CHQ_REG_PERC_MISC15 = ConvertDEC(Reader["CHQ_REG_PERC_MISC15"]);
						CHQ_REG_PERC_MISC16 = ConvertDEC(Reader["CHQ_REG_PERC_MISC16"]);
						CHQ_REG_PERC_MISC17 = ConvertDEC(Reader["CHQ_REG_PERC_MISC17"]);
						CHQ_REG_PERC_MISC18 = ConvertDEC(Reader["CHQ_REG_PERC_MISC18"]);
						CHQ_REG_PAY_CODE1 = Reader["CHQ_REG_PAY_CODE1"].ToString();
						CHQ_REG_PAY_CODE2 = Reader["CHQ_REG_PAY_CODE2"].ToString();
						CHQ_REG_PAY_CODE3 = Reader["CHQ_REG_PAY_CODE3"].ToString();
						CHQ_REG_PAY_CODE4 = Reader["CHQ_REG_PAY_CODE4"].ToString();
						CHQ_REG_PAY_CODE5 = Reader["CHQ_REG_PAY_CODE5"].ToString();
						CHQ_REG_PAY_CODE6 = Reader["CHQ_REG_PAY_CODE6"].ToString();
						CHQ_REG_PAY_CODE7 = Reader["CHQ_REG_PAY_CODE7"].ToString();
						CHQ_REG_PAY_CODE8 = Reader["CHQ_REG_PAY_CODE8"].ToString();
						CHQ_REG_PAY_CODE9 = Reader["CHQ_REG_PAY_CODE9"].ToString();
						CHQ_REG_PAY_CODE10 = Reader["CHQ_REG_PAY_CODE10"].ToString();
						CHQ_REG_PAY_CODE11 = Reader["CHQ_REG_PAY_CODE11"].ToString();
						CHQ_REG_PAY_CODE12 = Reader["CHQ_REG_PAY_CODE12"].ToString();
						CHQ_REG_PAY_CODE13 = Reader["CHQ_REG_PAY_CODE13"].ToString();
						CHQ_REG_PAY_CODE14 = Reader["CHQ_REG_PAY_CODE14"].ToString();
						CHQ_REG_PAY_CODE15 = Reader["CHQ_REG_PAY_CODE15"].ToString();
						CHQ_REG_PAY_CODE16 = Reader["CHQ_REG_PAY_CODE16"].ToString();
						CHQ_REG_PAY_CODE17 = Reader["CHQ_REG_PAY_CODE17"].ToString();
						CHQ_REG_PAY_CODE18 = Reader["CHQ_REG_PAY_CODE18"].ToString();
						CHQ_REG_PERC_TAX1 = ConvertDEC(Reader["CHQ_REG_PERC_TAX1"]);
						CHQ_REG_PERC_TAX2 = ConvertDEC(Reader["CHQ_REG_PERC_TAX2"]);
						CHQ_REG_PERC_TAX3 = ConvertDEC(Reader["CHQ_REG_PERC_TAX3"]);
						CHQ_REG_PERC_TAX4 = ConvertDEC(Reader["CHQ_REG_PERC_TAX4"]);
						CHQ_REG_PERC_TAX5 = ConvertDEC(Reader["CHQ_REG_PERC_TAX5"]);
						CHQ_REG_PERC_TAX6 = ConvertDEC(Reader["CHQ_REG_PERC_TAX6"]);
						CHQ_REG_PERC_TAX7 = ConvertDEC(Reader["CHQ_REG_PERC_TAX7"]);
						CHQ_REG_PERC_TAX8 = ConvertDEC(Reader["CHQ_REG_PERC_TAX8"]);
						CHQ_REG_PERC_TAX9 = ConvertDEC(Reader["CHQ_REG_PERC_TAX9"]);
						CHQ_REG_PERC_TAX10 = ConvertDEC(Reader["CHQ_REG_PERC_TAX10"]);
						CHQ_REG_PERC_TAX11 = ConvertDEC(Reader["CHQ_REG_PERC_TAX11"]);
						CHQ_REG_PERC_TAX12 = ConvertDEC(Reader["CHQ_REG_PERC_TAX12"]);
						CHQ_REG_PERC_TAX13 = ConvertDEC(Reader["CHQ_REG_PERC_TAX13"]);
						CHQ_REG_PERC_TAX14 = ConvertDEC(Reader["CHQ_REG_PERC_TAX14"]);
						CHQ_REG_PERC_TAX15 = ConvertDEC(Reader["CHQ_REG_PERC_TAX15"]);
						CHQ_REG_PERC_TAX16 = ConvertDEC(Reader["CHQ_REG_PERC_TAX16"]);
						CHQ_REG_PERC_TAX17 = ConvertDEC(Reader["CHQ_REG_PERC_TAX17"]);
						CHQ_REG_PERC_TAX18 = ConvertDEC(Reader["CHQ_REG_PERC_TAX18"]);
						CHQ_REG_MTH_BILL_AMT1 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT1"]);
						CHQ_REG_MTH_BILL_AMT2 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT2"]);
						CHQ_REG_MTH_BILL_AMT3 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT3"]);
						CHQ_REG_MTH_BILL_AMT4 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT4"]);
						CHQ_REG_MTH_BILL_AMT5 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT5"]);
						CHQ_REG_MTH_BILL_AMT6 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT6"]);
						CHQ_REG_MTH_BILL_AMT7 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT7"]);
						CHQ_REG_MTH_BILL_AMT8 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT8"]);
						CHQ_REG_MTH_BILL_AMT9 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT9"]);
						CHQ_REG_MTH_BILL_AMT10 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT10"]);
						CHQ_REG_MTH_BILL_AMT11 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT11"]);
						CHQ_REG_MTH_BILL_AMT12 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT12"]);
						CHQ_REG_MTH_BILL_AMT13 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT13"]);
						CHQ_REG_MTH_BILL_AMT14 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT14"]);
						CHQ_REG_MTH_BILL_AMT15 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT15"]);
						CHQ_REG_MTH_BILL_AMT16 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT16"]);
						CHQ_REG_MTH_BILL_AMT17 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT17"]);
						CHQ_REG_MTH_BILL_AMT18 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT18"]);
						CHQ_REG_MTH_MISC_AMT_11 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_11"]);
						CHQ_REG_MTH_MISC_AMT_12 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_12"]);
						CHQ_REG_MTH_MISC_AMT_13 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_13"]);
						CHQ_REG_MTH_MISC_AMT_14 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_14"]);
						CHQ_REG_MTH_MISC_AMT_15 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_15"]);
						CHQ_REG_MTH_MISC_AMT_16 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_16"]);
						CHQ_REG_MTH_MISC_AMT_17 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_17"]);
						CHQ_REG_MTH_MISC_AMT_18 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_18"]);
						CHQ_REG_MTH_MISC_AMT_19 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_19"]);
						CHQ_REG_MTH_MISC_AMT_110 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_110"]);
						CHQ_REG_MTH_MISC_AMT_111 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_111"]);
						CHQ_REG_MTH_MISC_AMT_112 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_112"]);
						CHQ_REG_MTH_MISC_AMT_113 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_113"]);
						CHQ_REG_MTH_MISC_AMT_114 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_114"]);
						CHQ_REG_MTH_MISC_AMT_115 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_115"]);
						CHQ_REG_MTH_MISC_AMT_116 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_116"]);
						CHQ_REG_MTH_MISC_AMT_117 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_117"]);
						CHQ_REG_MTH_MISC_AMT_118 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_118"]);
						CHQ_REG_MTH_MISC_AMT_21 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_21"]);
						CHQ_REG_MTH_MISC_AMT_22 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_22"]);
						CHQ_REG_MTH_MISC_AMT_23 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_23"]);
						CHQ_REG_MTH_MISC_AMT_24 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_24"]);
						CHQ_REG_MTH_MISC_AMT_25 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_25"]);
						CHQ_REG_MTH_MISC_AMT_26 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_26"]);
						CHQ_REG_MTH_MISC_AMT_27 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_27"]);
						CHQ_REG_MTH_MISC_AMT_28 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_28"]);
						CHQ_REG_MTH_MISC_AMT_29 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_29"]);
						CHQ_REG_MTH_MISC_AMT_210 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_210"]);
						CHQ_REG_MTH_MISC_AMT_211 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_211"]);
						CHQ_REG_MTH_MISC_AMT_212 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_212"]);
						CHQ_REG_MTH_MISC_AMT_213 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_213"]);
						CHQ_REG_MTH_MISC_AMT_214 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_214"]);
						CHQ_REG_MTH_MISC_AMT_215 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_215"]);
						CHQ_REG_MTH_MISC_AMT_216 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_216"]);
						CHQ_REG_MTH_MISC_AMT_217 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_217"]);
						CHQ_REG_MTH_MISC_AMT_218 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_218"]);
						CHQ_REG_MTH_MISC_AMT_31 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_31"]);
						CHQ_REG_MTH_MISC_AMT_32 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_32"]);
						CHQ_REG_MTH_MISC_AMT_33 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_33"]);
						CHQ_REG_MTH_MISC_AMT_34 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_34"]);
						CHQ_REG_MTH_MISC_AMT_35 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_35"]);
						CHQ_REG_MTH_MISC_AMT_36 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_36"]);
						CHQ_REG_MTH_MISC_AMT_37 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_37"]);
						CHQ_REG_MTH_MISC_AMT_38 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_38"]);
						CHQ_REG_MTH_MISC_AMT_39 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_39"]);
						CHQ_REG_MTH_MISC_AMT_310 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_310"]);
						CHQ_REG_MTH_MISC_AMT_311 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_311"]);
						CHQ_REG_MTH_MISC_AMT_312 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_312"]);
						CHQ_REG_MTH_MISC_AMT_313 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_313"]);
						CHQ_REG_MTH_MISC_AMT_314 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_314"]);
						CHQ_REG_MTH_MISC_AMT_315 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_315"]);
						CHQ_REG_MTH_MISC_AMT_316 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_316"]);
						CHQ_REG_MTH_MISC_AMT_317 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_317"]);
						CHQ_REG_MTH_MISC_AMT_318 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_318"]);
						CHQ_REG_MTH_MISC_AMT_41 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_41"]);
						CHQ_REG_MTH_MISC_AMT_42 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_42"]);
						CHQ_REG_MTH_MISC_AMT_43 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_43"]);
						CHQ_REG_MTH_MISC_AMT_44 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_44"]);
						CHQ_REG_MTH_MISC_AMT_45 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_45"]);
						CHQ_REG_MTH_MISC_AMT_46 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_46"]);
						CHQ_REG_MTH_MISC_AMT_47 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_47"]);
						CHQ_REG_MTH_MISC_AMT_48 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_48"]);
						CHQ_REG_MTH_MISC_AMT_49 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_49"]);
						CHQ_REG_MTH_MISC_AMT_410 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_410"]);
						CHQ_REG_MTH_MISC_AMT_411 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_411"]);
						CHQ_REG_MTH_MISC_AMT_412 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_412"]);
						CHQ_REG_MTH_MISC_AMT_413 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_413"]);
						CHQ_REG_MTH_MISC_AMT_414 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_414"]);
						CHQ_REG_MTH_MISC_AMT_415 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_415"]);
						CHQ_REG_MTH_MISC_AMT_416 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_416"]);
						CHQ_REG_MTH_MISC_AMT_417 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_417"]);
						CHQ_REG_MTH_MISC_AMT_418 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_418"]);
						CHQ_REG_MTH_MISC_AMT_51 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_51"]);
						CHQ_REG_MTH_MISC_AMT_52 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_52"]);
						CHQ_REG_MTH_MISC_AMT_53 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_53"]);
						CHQ_REG_MTH_MISC_AMT_54 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_54"]);
						CHQ_REG_MTH_MISC_AMT_55 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_55"]);
						CHQ_REG_MTH_MISC_AMT_56 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_56"]);
						CHQ_REG_MTH_MISC_AMT_57 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_57"]);
						CHQ_REG_MTH_MISC_AMT_58 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_58"]);
						CHQ_REG_MTH_MISC_AMT_59 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_59"]);
						CHQ_REG_MTH_MISC_AMT_510 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_510"]);
						CHQ_REG_MTH_MISC_AMT_511 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_511"]);
						CHQ_REG_MTH_MISC_AMT_512 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_512"]);
						CHQ_REG_MTH_MISC_AMT_513 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_513"]);
						CHQ_REG_MTH_MISC_AMT_514 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_514"]);
						CHQ_REG_MTH_MISC_AMT_515 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_515"]);
						CHQ_REG_MTH_MISC_AMT_516 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_516"]);
						CHQ_REG_MTH_MISC_AMT_517 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_517"]);
						CHQ_REG_MTH_MISC_AMT_518 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_518"]);
						CHQ_REG_MTH_MISC_AMT_61 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_61"]);
						CHQ_REG_MTH_MISC_AMT_62 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_62"]);
						CHQ_REG_MTH_MISC_AMT_63 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_63"]);
						CHQ_REG_MTH_MISC_AMT_64 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_64"]);
						CHQ_REG_MTH_MISC_AMT_65 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_65"]);
						CHQ_REG_MTH_MISC_AMT_66 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_66"]);
						CHQ_REG_MTH_MISC_AMT_67 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_67"]);
						CHQ_REG_MTH_MISC_AMT_68 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_68"]);
						CHQ_REG_MTH_MISC_AMT_69 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_69"]);
						CHQ_REG_MTH_MISC_AMT_610 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_610"]);
						CHQ_REG_MTH_MISC_AMT_611 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_611"]);
						CHQ_REG_MTH_MISC_AMT_612 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_612"]);
						CHQ_REG_MTH_MISC_AMT_613 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_613"]);
						CHQ_REG_MTH_MISC_AMT_614 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_614"]);
						CHQ_REG_MTH_MISC_AMT_615 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_615"]);
						CHQ_REG_MTH_MISC_AMT_616 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_616"]);
						CHQ_REG_MTH_MISC_AMT_617 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_617"]);
						CHQ_REG_MTH_MISC_AMT_618 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_618"]);
						CHQ_REG_MTH_MISC_AMT_71 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_71"]);
						CHQ_REG_MTH_MISC_AMT_72 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_72"]);
						CHQ_REG_MTH_MISC_AMT_73 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_73"]);
						CHQ_REG_MTH_MISC_AMT_74 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_74"]);
						CHQ_REG_MTH_MISC_AMT_75 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_75"]);
						CHQ_REG_MTH_MISC_AMT_76 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_76"]);
						CHQ_REG_MTH_MISC_AMT_77 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_77"]);
						CHQ_REG_MTH_MISC_AMT_78 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_78"]);
						CHQ_REG_MTH_MISC_AMT_79 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_79"]);
						CHQ_REG_MTH_MISC_AMT_710 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_710"]);
						CHQ_REG_MTH_MISC_AMT_711 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_711"]);
						CHQ_REG_MTH_MISC_AMT_712 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_712"]);
						CHQ_REG_MTH_MISC_AMT_713 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_713"]);
						CHQ_REG_MTH_MISC_AMT_714 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_714"]);
						CHQ_REG_MTH_MISC_AMT_715 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_715"]);
						CHQ_REG_MTH_MISC_AMT_716 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_716"]);
						CHQ_REG_MTH_MISC_AMT_717 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_717"]);
						CHQ_REG_MTH_MISC_AMT_718 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_718"]);
						CHQ_REG_MTH_MISC_AMT_81 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_81"]);
						CHQ_REG_MTH_MISC_AMT_82 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_82"]);
						CHQ_REG_MTH_MISC_AMT_83 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_83"]);
						CHQ_REG_MTH_MISC_AMT_84 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_84"]);
						CHQ_REG_MTH_MISC_AMT_85 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_85"]);
						CHQ_REG_MTH_MISC_AMT_86 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_86"]);
						CHQ_REG_MTH_MISC_AMT_87 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_87"]);
						CHQ_REG_MTH_MISC_AMT_88 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_88"]);
						CHQ_REG_MTH_MISC_AMT_89 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_89"]);
						CHQ_REG_MTH_MISC_AMT_810 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_810"]);
						CHQ_REG_MTH_MISC_AMT_811 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_811"]);
						CHQ_REG_MTH_MISC_AMT_812 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_812"]);
						CHQ_REG_MTH_MISC_AMT_813 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_813"]);
						CHQ_REG_MTH_MISC_AMT_814 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_814"]);
						CHQ_REG_MTH_MISC_AMT_815 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_815"]);
						CHQ_REG_MTH_MISC_AMT_816 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_816"]);
						CHQ_REG_MTH_MISC_AMT_817 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_817"]);
						CHQ_REG_MTH_MISC_AMT_818 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_818"]);
						CHQ_REG_MTH_MISC_AMT_91 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_91"]);
						CHQ_REG_MTH_MISC_AMT_92 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_92"]);
						CHQ_REG_MTH_MISC_AMT_93 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_93"]);
						CHQ_REG_MTH_MISC_AMT_94 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_94"]);
						CHQ_REG_MTH_MISC_AMT_95 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_95"]);
						CHQ_REG_MTH_MISC_AMT_96 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_96"]);
						CHQ_REG_MTH_MISC_AMT_97 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_97"]);
						CHQ_REG_MTH_MISC_AMT_98 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_98"]);
						CHQ_REG_MTH_MISC_AMT_99 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_99"]);
						CHQ_REG_MTH_MISC_AMT_910 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_910"]);
						CHQ_REG_MTH_MISC_AMT_911 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_911"]);
						CHQ_REG_MTH_MISC_AMT_912 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_912"]);
						CHQ_REG_MTH_MISC_AMT_913 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_913"]);
						CHQ_REG_MTH_MISC_AMT_914 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_914"]);
						CHQ_REG_MTH_MISC_AMT_915 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_915"]);
						CHQ_REG_MTH_MISC_AMT_916 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_916"]);
						CHQ_REG_MTH_MISC_AMT_917 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_917"]);
						CHQ_REG_MTH_MISC_AMT_918 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_918"]);
						CHQ_REG_MTH_MISC_AMT_101 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_101"]);
						CHQ_REG_MTH_MISC_AMT_102 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_102"]);
						CHQ_REG_MTH_MISC_AMT_103 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_103"]);
						CHQ_REG_MTH_MISC_AMT_104 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_104"]);
						CHQ_REG_MTH_MISC_AMT_105 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_105"]);
						CHQ_REG_MTH_MISC_AMT_106 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_106"]);
						CHQ_REG_MTH_MISC_AMT_107 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_107"]);
						CHQ_REG_MTH_MISC_AMT_108 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_108"]);
						CHQ_REG_MTH_MISC_AMT_109 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_109"]);
						CHQ_REG_MTH_MISC_AMT_1010 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1010"]);
						CHQ_REG_MTH_MISC_AMT_1011 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1011"]);
						CHQ_REG_MTH_MISC_AMT_1012 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1012"]);
						CHQ_REG_MTH_MISC_AMT_1013 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1013"]);
						CHQ_REG_MTH_MISC_AMT_1014 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1014"]);
						CHQ_REG_MTH_MISC_AMT_1015 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1015"]);
						CHQ_REG_MTH_MISC_AMT_1016 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1016"]);
						CHQ_REG_MTH_MISC_AMT_1017 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1017"]);
						CHQ_REG_MTH_MISC_AMT_1018 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1018"]);
						CHQ_REG_MTH_EXP_AMT1 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT1"]);
						CHQ_REG_MTH_EXP_AMT2 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT2"]);
						CHQ_REG_MTH_EXP_AMT3 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT3"]);
						CHQ_REG_MTH_EXP_AMT4 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT4"]);
						CHQ_REG_MTH_EXP_AMT5 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT5"]);
						CHQ_REG_MTH_EXP_AMT6 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT6"]);
						CHQ_REG_MTH_EXP_AMT7 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT7"]);
						CHQ_REG_MTH_EXP_AMT8 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT8"]);
						CHQ_REG_MTH_EXP_AMT9 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT9"]);
						CHQ_REG_MTH_EXP_AMT10 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT10"]);
						CHQ_REG_MTH_EXP_AMT11 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT11"]);
						CHQ_REG_MTH_EXP_AMT12 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT12"]);
						CHQ_REG_MTH_EXP_AMT13 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT13"]);
						CHQ_REG_MTH_EXP_AMT14 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT14"]);
						CHQ_REG_MTH_EXP_AMT15 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT15"]);
						CHQ_REG_MTH_EXP_AMT16 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT16"]);
						CHQ_REG_MTH_EXP_AMT17 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT17"]);
						CHQ_REG_MTH_EXP_AMT18 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT18"]);
						CHQ_REG_COMP_ANN_EXP_THIS_PAY1 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY1"]);
						CHQ_REG_COMP_ANN_EXP_THIS_PAY2 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY2"]);
						CHQ_REG_COMP_ANN_EXP_THIS_PAY3 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY3"]);
						CHQ_REG_COMP_ANN_EXP_THIS_PAY4 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY4"]);
						CHQ_REG_COMP_ANN_EXP_THIS_PAY5 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY5"]);
						CHQ_REG_COMP_ANN_EXP_THIS_PAY6 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY6"]);
						CHQ_REG_COMP_ANN_EXP_THIS_PAY7 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY7"]);
						CHQ_REG_COMP_ANN_EXP_THIS_PAY8 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY8"]);
						CHQ_REG_COMP_ANN_EXP_THIS_PAY9 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY9"]);
						CHQ_REG_COMP_ANN_EXP_THIS_PAY10 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY10"]);
						CHQ_REG_COMP_ANN_EXP_THIS_PAY11 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY11"]);
						CHQ_REG_COMP_ANN_EXP_THIS_PAY12 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY12"]);
						CHQ_REG_COMP_ANN_EXP_THIS_PAY13 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY13"]);
						CHQ_REG_COMP_ANN_EXP_THIS_PAY14 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY14"]);
						CHQ_REG_COMP_ANN_EXP_THIS_PAY15 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY15"]);
						CHQ_REG_COMP_ANN_EXP_THIS_PAY16 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY16"]);
						CHQ_REG_COMP_ANN_EXP_THIS_PAY17 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY17"]);
						CHQ_REG_COMP_ANN_EXP_THIS_PAY18 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY18"]);
						CHQ_REG_MTH_CEIL_AMT1 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT1"]);
						CHQ_REG_MTH_CEIL_AMT2 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT2"]);
						CHQ_REG_MTH_CEIL_AMT3 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT3"]);
						CHQ_REG_MTH_CEIL_AMT4 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT4"]);
						CHQ_REG_MTH_CEIL_AMT5 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT5"]);
						CHQ_REG_MTH_CEIL_AMT6 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT6"]);
						CHQ_REG_MTH_CEIL_AMT7 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT7"]);
						CHQ_REG_MTH_CEIL_AMT8 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT8"]);
						CHQ_REG_MTH_CEIL_AMT9 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT9"]);
						CHQ_REG_MTH_CEIL_AMT10 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT10"]);
						CHQ_REG_MTH_CEIL_AMT11 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT11"]);
						CHQ_REG_MTH_CEIL_AMT12 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT12"]);
						CHQ_REG_MTH_CEIL_AMT13 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT13"]);
						CHQ_REG_MTH_CEIL_AMT14 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT14"]);
						CHQ_REG_MTH_CEIL_AMT15 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT15"]);
						CHQ_REG_MTH_CEIL_AMT16 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT16"]);
						CHQ_REG_MTH_CEIL_AMT17 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT17"]);
						CHQ_REG_MTH_CEIL_AMT18 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT18"]);
						CHQ_REG_COMP_ANN_CEIL_THIS_PAY1 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY1"]);
						CHQ_REG_COMP_ANN_CEIL_THIS_PAY2 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY2"]);
						CHQ_REG_COMP_ANN_CEIL_THIS_PAY3 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY3"]);
						CHQ_REG_COMP_ANN_CEIL_THIS_PAY4 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY4"]);
						CHQ_REG_COMP_ANN_CEIL_THIS_PAY5 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY5"]);
						CHQ_REG_COMP_ANN_CEIL_THIS_PAY6 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY6"]);
						CHQ_REG_COMP_ANN_CEIL_THIS_PAY7 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY7"]);
						CHQ_REG_COMP_ANN_CEIL_THIS_PAY8 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY8"]);
						CHQ_REG_COMP_ANN_CEIL_THIS_PAY9 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY9"]);
						CHQ_REG_COMP_ANN_CEIL_THIS_PAY10 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY10"]);
						CHQ_REG_COMP_ANN_CEIL_THIS_PAY11 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY11"]);
						CHQ_REG_COMP_ANN_CEIL_THIS_PAY12 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY12"]);
						CHQ_REG_COMP_ANN_CEIL_THIS_PAY13 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY13"]);
						CHQ_REG_COMP_ANN_CEIL_THIS_PAY14 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY14"]);
						CHQ_REG_COMP_ANN_CEIL_THIS_PAY15 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY15"]);
						CHQ_REG_COMP_ANN_CEIL_THIS_PAY16 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY16"]);
						CHQ_REG_COMP_ANN_CEIL_THIS_PAY17 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY17"]);
						CHQ_REG_COMP_ANN_CEIL_THIS_PAY18 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY18"]);
						CHQ_REG_EARNINGS_THIS_MTH1 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH1"]);
						CHQ_REG_EARNINGS_THIS_MTH2 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH2"]);
						CHQ_REG_EARNINGS_THIS_MTH3 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH3"]);
						CHQ_REG_EARNINGS_THIS_MTH4 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH4"]);
						CHQ_REG_EARNINGS_THIS_MTH5 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH5"]);
						CHQ_REG_EARNINGS_THIS_MTH6 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH6"]);
						CHQ_REG_EARNINGS_THIS_MTH7 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH7"]);
						CHQ_REG_EARNINGS_THIS_MTH8 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH8"]);
						CHQ_REG_EARNINGS_THIS_MTH9 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH9"]);
						CHQ_REG_EARNINGS_THIS_MTH10 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH10"]);
						CHQ_REG_EARNINGS_THIS_MTH11 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH11"]);
						CHQ_REG_EARNINGS_THIS_MTH12 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH12"]);
						CHQ_REG_EARNINGS_THIS_MTH13 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH13"]);
						CHQ_REG_EARNINGS_THIS_MTH14 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH14"]);
						CHQ_REG_EARNINGS_THIS_MTH15 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH15"]);
						CHQ_REG_EARNINGS_THIS_MTH16 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH16"]);
						CHQ_REG_EARNINGS_THIS_MTH17 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH17"]);
						CHQ_REG_EARNINGS_THIS_MTH18 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH18"]);
						CHQ_REG_REGULAR_PAY_THIS_MTH1 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH1"]);
						CHQ_REG_REGULAR_PAY_THIS_MTH2 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH2"]);
						CHQ_REG_REGULAR_PAY_THIS_MTH3 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH3"]);
						CHQ_REG_REGULAR_PAY_THIS_MTH4 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH4"]);
						CHQ_REG_REGULAR_PAY_THIS_MTH5 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH5"]);
						CHQ_REG_REGULAR_PAY_THIS_MTH6 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH6"]);
						CHQ_REG_REGULAR_PAY_THIS_MTH7 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH7"]);
						CHQ_REG_REGULAR_PAY_THIS_MTH8 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH8"]);
						CHQ_REG_REGULAR_PAY_THIS_MTH9 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH9"]);
						CHQ_REG_REGULAR_PAY_THIS_MTH10 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH10"]);
						CHQ_REG_REGULAR_PAY_THIS_MTH11 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH11"]);
						CHQ_REG_REGULAR_PAY_THIS_MTH12 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH12"]);
						CHQ_REG_REGULAR_PAY_THIS_MTH13 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH13"]);
						CHQ_REG_REGULAR_PAY_THIS_MTH14 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH14"]);
						CHQ_REG_REGULAR_PAY_THIS_MTH15 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH15"]);
						CHQ_REG_REGULAR_PAY_THIS_MTH16 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH16"]);
						CHQ_REG_REGULAR_PAY_THIS_MTH17 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH17"]);
						CHQ_REG_REGULAR_PAY_THIS_MTH18 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH18"]);
						CHQ_REG_REGULAR_TAX_THIS_MTH1 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH1"]);
						CHQ_REG_REGULAR_TAX_THIS_MTH2 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH2"]);
						CHQ_REG_REGULAR_TAX_THIS_MTH3 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH3"]);
						CHQ_REG_REGULAR_TAX_THIS_MTH4 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH4"]);
						CHQ_REG_REGULAR_TAX_THIS_MTH5 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH5"]);
						CHQ_REG_REGULAR_TAX_THIS_MTH6 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH6"]);
						CHQ_REG_REGULAR_TAX_THIS_MTH7 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH7"]);
						CHQ_REG_REGULAR_TAX_THIS_MTH8 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH8"]);
						CHQ_REG_REGULAR_TAX_THIS_MTH9 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH9"]);
						CHQ_REG_REGULAR_TAX_THIS_MTH10 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH10"]);
						CHQ_REG_REGULAR_TAX_THIS_MTH11 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH11"]);
						CHQ_REG_REGULAR_TAX_THIS_MTH12 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH12"]);
						CHQ_REG_REGULAR_TAX_THIS_MTH13 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH13"]);
						CHQ_REG_REGULAR_TAX_THIS_MTH14 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH14"]);
						CHQ_REG_REGULAR_TAX_THIS_MTH15 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH15"]);
						CHQ_REG_REGULAR_TAX_THIS_MTH16 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH16"]);
						CHQ_REG_REGULAR_TAX_THIS_MTH17 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH17"]);
						CHQ_REG_REGULAR_TAX_THIS_MTH18 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH18"]);
						CHQ_REG_MAN_PAY_THIS_MTH1 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH1"]);
						CHQ_REG_MAN_PAY_THIS_MTH2 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH2"]);
						CHQ_REG_MAN_PAY_THIS_MTH3 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH3"]);
						CHQ_REG_MAN_PAY_THIS_MTH4 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH4"]);
						CHQ_REG_MAN_PAY_THIS_MTH5 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH5"]);
						CHQ_REG_MAN_PAY_THIS_MTH6 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH6"]);
						CHQ_REG_MAN_PAY_THIS_MTH7 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH7"]);
						CHQ_REG_MAN_PAY_THIS_MTH8 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH8"]);
						CHQ_REG_MAN_PAY_THIS_MTH9 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH9"]);
						CHQ_REG_MAN_PAY_THIS_MTH10 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH10"]);
						CHQ_REG_MAN_PAY_THIS_MTH11 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH11"]);
						CHQ_REG_MAN_PAY_THIS_MTH12 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH12"]);
						CHQ_REG_MAN_PAY_THIS_MTH13 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH13"]);
						CHQ_REG_MAN_PAY_THIS_MTH14 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH14"]);
						CHQ_REG_MAN_PAY_THIS_MTH15 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH15"]);
						CHQ_REG_MAN_PAY_THIS_MTH16 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH16"]);
						CHQ_REG_MAN_PAY_THIS_MTH17 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH17"]);
						CHQ_REG_MAN_PAY_THIS_MTH18 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH18"]);
						CHQ_REG_MAN_TAX_THIS_MTH1 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH1"]);
						CHQ_REG_MAN_TAX_THIS_MTH2 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH2"]);
						CHQ_REG_MAN_TAX_THIS_MTH3 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH3"]);
						CHQ_REG_MAN_TAX_THIS_MTH4 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH4"]);
						CHQ_REG_MAN_TAX_THIS_MTH5 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH5"]);
						CHQ_REG_MAN_TAX_THIS_MTH6 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH6"]);
						CHQ_REG_MAN_TAX_THIS_MTH7 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH7"]);
						CHQ_REG_MAN_TAX_THIS_MTH8 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH8"]);
						CHQ_REG_MAN_TAX_THIS_MTH9 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH9"]);
						CHQ_REG_MAN_TAX_THIS_MTH10 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH10"]);
						CHQ_REG_MAN_TAX_THIS_MTH11 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH11"]);
						CHQ_REG_MAN_TAX_THIS_MTH12 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH12"]);
						CHQ_REG_MAN_TAX_THIS_MTH13 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH13"]);
						CHQ_REG_MAN_TAX_THIS_MTH14 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH14"]);
						CHQ_REG_MAN_TAX_THIS_MTH15 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH15"]);
						CHQ_REG_MAN_TAX_THIS_MTH16 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH16"]);
						CHQ_REG_MAN_TAX_THIS_MTH17 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH17"]);
						CHQ_REG_MAN_TAX_THIS_MTH18 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH18"]);
						CHQ_REG_PAY_DATE1 = ConvertDEC(Reader["CHQ_REG_PAY_DATE1"]);
						CHQ_REG_PAY_DATE2 = ConvertDEC(Reader["CHQ_REG_PAY_DATE2"]);
						CHQ_REG_PAY_DATE3 = ConvertDEC(Reader["CHQ_REG_PAY_DATE3"]);
						CHQ_REG_PAY_DATE4 = ConvertDEC(Reader["CHQ_REG_PAY_DATE4"]);
						CHQ_REG_PAY_DATE5 = ConvertDEC(Reader["CHQ_REG_PAY_DATE5"]);
						CHQ_REG_PAY_DATE6 = ConvertDEC(Reader["CHQ_REG_PAY_DATE6"]);
						CHQ_REG_PAY_DATE7 = ConvertDEC(Reader["CHQ_REG_PAY_DATE7"]);
						CHQ_REG_PAY_DATE8 = ConvertDEC(Reader["CHQ_REG_PAY_DATE8"]);
						CHQ_REG_PAY_DATE9 = ConvertDEC(Reader["CHQ_REG_PAY_DATE9"]);
						CHQ_REG_PAY_DATE10 = ConvertDEC(Reader["CHQ_REG_PAY_DATE10"]);
						CHQ_REG_PAY_DATE11 = ConvertDEC(Reader["CHQ_REG_PAY_DATE11"]);
						CHQ_REG_PAY_DATE12 = ConvertDEC(Reader["CHQ_REG_PAY_DATE12"]);
						CHQ_REG_PAY_DATE13 = ConvertDEC(Reader["CHQ_REG_PAY_DATE13"]);
						CHQ_REG_PAY_DATE14 = ConvertDEC(Reader["CHQ_REG_PAY_DATE14"]);
						CHQ_REG_PAY_DATE15 = ConvertDEC(Reader["CHQ_REG_PAY_DATE15"]);
						CHQ_REG_PAY_DATE16 = ConvertDEC(Reader["CHQ_REG_PAY_DATE16"]);
						CHQ_REG_PAY_DATE17 = ConvertDEC(Reader["CHQ_REG_PAY_DATE17"]);
						CHQ_REG_PAY_DATE18 = ConvertDEC(Reader["CHQ_REG_PAY_DATE18"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalChq_reg_clinic_nbr_1_2 = ConvertDEC(Reader["CHQ_REG_CLINIC_NBR_1_2"]);
						_originalChq_reg_dept = ConvertDEC(Reader["CHQ_REG_DEPT"]);
						_originalChq_reg_doc_nbr = Reader["CHQ_REG_DOC_NBR"].ToString();
						_originalChq_reg_perc_bill1 = ConvertDEC(Reader["CHQ_REG_PERC_BILL1"]);
						_originalChq_reg_perc_bill2 = ConvertDEC(Reader["CHQ_REG_PERC_BILL2"]);
						_originalChq_reg_perc_bill3 = ConvertDEC(Reader["CHQ_REG_PERC_BILL3"]);
						_originalChq_reg_perc_bill4 = ConvertDEC(Reader["CHQ_REG_PERC_BILL4"]);
						_originalChq_reg_perc_bill5 = ConvertDEC(Reader["CHQ_REG_PERC_BILL5"]);
						_originalChq_reg_perc_bill6 = ConvertDEC(Reader["CHQ_REG_PERC_BILL6"]);
						_originalChq_reg_perc_bill7 = ConvertDEC(Reader["CHQ_REG_PERC_BILL7"]);
						_originalChq_reg_perc_bill8 = ConvertDEC(Reader["CHQ_REG_PERC_BILL8"]);
						_originalChq_reg_perc_bill9 = ConvertDEC(Reader["CHQ_REG_PERC_BILL9"]);
						_originalChq_reg_perc_bill10 = ConvertDEC(Reader["CHQ_REG_PERC_BILL10"]);
						_originalChq_reg_perc_bill11 = ConvertDEC(Reader["CHQ_REG_PERC_BILL11"]);
						_originalChq_reg_perc_bill12 = ConvertDEC(Reader["CHQ_REG_PERC_BILL12"]);
						_originalChq_reg_perc_bill13 = ConvertDEC(Reader["CHQ_REG_PERC_BILL13"]);
						_originalChq_reg_perc_bill14 = ConvertDEC(Reader["CHQ_REG_PERC_BILL14"]);
						_originalChq_reg_perc_bill15 = ConvertDEC(Reader["CHQ_REG_PERC_BILL15"]);
						_originalChq_reg_perc_bill16 = ConvertDEC(Reader["CHQ_REG_PERC_BILL16"]);
						_originalChq_reg_perc_bill17 = ConvertDEC(Reader["CHQ_REG_PERC_BILL17"]);
						_originalChq_reg_perc_bill18 = ConvertDEC(Reader["CHQ_REG_PERC_BILL18"]);
						_originalChq_reg_perc_misc1 = ConvertDEC(Reader["CHQ_REG_PERC_MISC1"]);
						_originalChq_reg_perc_misc2 = ConvertDEC(Reader["CHQ_REG_PERC_MISC2"]);
						_originalChq_reg_perc_misc3 = ConvertDEC(Reader["CHQ_REG_PERC_MISC3"]);
						_originalChq_reg_perc_misc4 = ConvertDEC(Reader["CHQ_REG_PERC_MISC4"]);
						_originalChq_reg_perc_misc5 = ConvertDEC(Reader["CHQ_REG_PERC_MISC5"]);
						_originalChq_reg_perc_misc6 = ConvertDEC(Reader["CHQ_REG_PERC_MISC6"]);
						_originalChq_reg_perc_misc7 = ConvertDEC(Reader["CHQ_REG_PERC_MISC7"]);
						_originalChq_reg_perc_misc8 = ConvertDEC(Reader["CHQ_REG_PERC_MISC8"]);
						_originalChq_reg_perc_misc9 = ConvertDEC(Reader["CHQ_REG_PERC_MISC9"]);
						_originalChq_reg_perc_misc10 = ConvertDEC(Reader["CHQ_REG_PERC_MISC10"]);
						_originalChq_reg_perc_misc11 = ConvertDEC(Reader["CHQ_REG_PERC_MISC11"]);
						_originalChq_reg_perc_misc12 = ConvertDEC(Reader["CHQ_REG_PERC_MISC12"]);
						_originalChq_reg_perc_misc13 = ConvertDEC(Reader["CHQ_REG_PERC_MISC13"]);
						_originalChq_reg_perc_misc14 = ConvertDEC(Reader["CHQ_REG_PERC_MISC14"]);
						_originalChq_reg_perc_misc15 = ConvertDEC(Reader["CHQ_REG_PERC_MISC15"]);
						_originalChq_reg_perc_misc16 = ConvertDEC(Reader["CHQ_REG_PERC_MISC16"]);
						_originalChq_reg_perc_misc17 = ConvertDEC(Reader["CHQ_REG_PERC_MISC17"]);
						_originalChq_reg_perc_misc18 = ConvertDEC(Reader["CHQ_REG_PERC_MISC18"]);
						_originalChq_reg_pay_code1 = Reader["CHQ_REG_PAY_CODE1"].ToString();
						_originalChq_reg_pay_code2 = Reader["CHQ_REG_PAY_CODE2"].ToString();
						_originalChq_reg_pay_code3 = Reader["CHQ_REG_PAY_CODE3"].ToString();
						_originalChq_reg_pay_code4 = Reader["CHQ_REG_PAY_CODE4"].ToString();
						_originalChq_reg_pay_code5 = Reader["CHQ_REG_PAY_CODE5"].ToString();
						_originalChq_reg_pay_code6 = Reader["CHQ_REG_PAY_CODE6"].ToString();
						_originalChq_reg_pay_code7 = Reader["CHQ_REG_PAY_CODE7"].ToString();
						_originalChq_reg_pay_code8 = Reader["CHQ_REG_PAY_CODE8"].ToString();
						_originalChq_reg_pay_code9 = Reader["CHQ_REG_PAY_CODE9"].ToString();
						_originalChq_reg_pay_code10 = Reader["CHQ_REG_PAY_CODE10"].ToString();
						_originalChq_reg_pay_code11 = Reader["CHQ_REG_PAY_CODE11"].ToString();
						_originalChq_reg_pay_code12 = Reader["CHQ_REG_PAY_CODE12"].ToString();
						_originalChq_reg_pay_code13 = Reader["CHQ_REG_PAY_CODE13"].ToString();
						_originalChq_reg_pay_code14 = Reader["CHQ_REG_PAY_CODE14"].ToString();
						_originalChq_reg_pay_code15 = Reader["CHQ_REG_PAY_CODE15"].ToString();
						_originalChq_reg_pay_code16 = Reader["CHQ_REG_PAY_CODE16"].ToString();
						_originalChq_reg_pay_code17 = Reader["CHQ_REG_PAY_CODE17"].ToString();
						_originalChq_reg_pay_code18 = Reader["CHQ_REG_PAY_CODE18"].ToString();
						_originalChq_reg_perc_tax1 = ConvertDEC(Reader["CHQ_REG_PERC_TAX1"]);
						_originalChq_reg_perc_tax2 = ConvertDEC(Reader["CHQ_REG_PERC_TAX2"]);
						_originalChq_reg_perc_tax3 = ConvertDEC(Reader["CHQ_REG_PERC_TAX3"]);
						_originalChq_reg_perc_tax4 = ConvertDEC(Reader["CHQ_REG_PERC_TAX4"]);
						_originalChq_reg_perc_tax5 = ConvertDEC(Reader["CHQ_REG_PERC_TAX5"]);
						_originalChq_reg_perc_tax6 = ConvertDEC(Reader["CHQ_REG_PERC_TAX6"]);
						_originalChq_reg_perc_tax7 = ConvertDEC(Reader["CHQ_REG_PERC_TAX7"]);
						_originalChq_reg_perc_tax8 = ConvertDEC(Reader["CHQ_REG_PERC_TAX8"]);
						_originalChq_reg_perc_tax9 = ConvertDEC(Reader["CHQ_REG_PERC_TAX9"]);
						_originalChq_reg_perc_tax10 = ConvertDEC(Reader["CHQ_REG_PERC_TAX10"]);
						_originalChq_reg_perc_tax11 = ConvertDEC(Reader["CHQ_REG_PERC_TAX11"]);
						_originalChq_reg_perc_tax12 = ConvertDEC(Reader["CHQ_REG_PERC_TAX12"]);
						_originalChq_reg_perc_tax13 = ConvertDEC(Reader["CHQ_REG_PERC_TAX13"]);
						_originalChq_reg_perc_tax14 = ConvertDEC(Reader["CHQ_REG_PERC_TAX14"]);
						_originalChq_reg_perc_tax15 = ConvertDEC(Reader["CHQ_REG_PERC_TAX15"]);
						_originalChq_reg_perc_tax16 = ConvertDEC(Reader["CHQ_REG_PERC_TAX16"]);
						_originalChq_reg_perc_tax17 = ConvertDEC(Reader["CHQ_REG_PERC_TAX17"]);
						_originalChq_reg_perc_tax18 = ConvertDEC(Reader["CHQ_REG_PERC_TAX18"]);
						_originalChq_reg_mth_bill_amt1 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT1"]);
						_originalChq_reg_mth_bill_amt2 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT2"]);
						_originalChq_reg_mth_bill_amt3 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT3"]);
						_originalChq_reg_mth_bill_amt4 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT4"]);
						_originalChq_reg_mth_bill_amt5 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT5"]);
						_originalChq_reg_mth_bill_amt6 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT6"]);
						_originalChq_reg_mth_bill_amt7 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT7"]);
						_originalChq_reg_mth_bill_amt8 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT8"]);
						_originalChq_reg_mth_bill_amt9 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT9"]);
						_originalChq_reg_mth_bill_amt10 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT10"]);
						_originalChq_reg_mth_bill_amt11 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT11"]);
						_originalChq_reg_mth_bill_amt12 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT12"]);
						_originalChq_reg_mth_bill_amt13 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT13"]);
						_originalChq_reg_mth_bill_amt14 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT14"]);
						_originalChq_reg_mth_bill_amt15 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT15"]);
						_originalChq_reg_mth_bill_amt16 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT16"]);
						_originalChq_reg_mth_bill_amt17 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT17"]);
						_originalChq_reg_mth_bill_amt18 = ConvertDEC(Reader["CHQ_REG_MTH_BILL_AMT18"]);
						_originalChq_reg_mth_misc_amt_11 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_11"]);
						_originalChq_reg_mth_misc_amt_12 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_12"]);
						_originalChq_reg_mth_misc_amt_13 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_13"]);
						_originalChq_reg_mth_misc_amt_14 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_14"]);
						_originalChq_reg_mth_misc_amt_15 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_15"]);
						_originalChq_reg_mth_misc_amt_16 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_16"]);
						_originalChq_reg_mth_misc_amt_17 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_17"]);
						_originalChq_reg_mth_misc_amt_18 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_18"]);
						_originalChq_reg_mth_misc_amt_19 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_19"]);
						_originalChq_reg_mth_misc_amt_110 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_110"]);
						_originalChq_reg_mth_misc_amt_111 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_111"]);
						_originalChq_reg_mth_misc_amt_112 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_112"]);
						_originalChq_reg_mth_misc_amt_113 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_113"]);
						_originalChq_reg_mth_misc_amt_114 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_114"]);
						_originalChq_reg_mth_misc_amt_115 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_115"]);
						_originalChq_reg_mth_misc_amt_116 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_116"]);
						_originalChq_reg_mth_misc_amt_117 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_117"]);
						_originalChq_reg_mth_misc_amt_118 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_118"]);
						_originalChq_reg_mth_misc_amt_21 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_21"]);
						_originalChq_reg_mth_misc_amt_22 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_22"]);
						_originalChq_reg_mth_misc_amt_23 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_23"]);
						_originalChq_reg_mth_misc_amt_24 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_24"]);
						_originalChq_reg_mth_misc_amt_25 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_25"]);
						_originalChq_reg_mth_misc_amt_26 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_26"]);
						_originalChq_reg_mth_misc_amt_27 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_27"]);
						_originalChq_reg_mth_misc_amt_28 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_28"]);
						_originalChq_reg_mth_misc_amt_29 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_29"]);
						_originalChq_reg_mth_misc_amt_210 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_210"]);
						_originalChq_reg_mth_misc_amt_211 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_211"]);
						_originalChq_reg_mth_misc_amt_212 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_212"]);
						_originalChq_reg_mth_misc_amt_213 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_213"]);
						_originalChq_reg_mth_misc_amt_214 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_214"]);
						_originalChq_reg_mth_misc_amt_215 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_215"]);
						_originalChq_reg_mth_misc_amt_216 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_216"]);
						_originalChq_reg_mth_misc_amt_217 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_217"]);
						_originalChq_reg_mth_misc_amt_218 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_218"]);
						_originalChq_reg_mth_misc_amt_31 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_31"]);
						_originalChq_reg_mth_misc_amt_32 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_32"]);
						_originalChq_reg_mth_misc_amt_33 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_33"]);
						_originalChq_reg_mth_misc_amt_34 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_34"]);
						_originalChq_reg_mth_misc_amt_35 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_35"]);
						_originalChq_reg_mth_misc_amt_36 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_36"]);
						_originalChq_reg_mth_misc_amt_37 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_37"]);
						_originalChq_reg_mth_misc_amt_38 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_38"]);
						_originalChq_reg_mth_misc_amt_39 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_39"]);
						_originalChq_reg_mth_misc_amt_310 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_310"]);
						_originalChq_reg_mth_misc_amt_311 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_311"]);
						_originalChq_reg_mth_misc_amt_312 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_312"]);
						_originalChq_reg_mth_misc_amt_313 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_313"]);
						_originalChq_reg_mth_misc_amt_314 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_314"]);
						_originalChq_reg_mth_misc_amt_315 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_315"]);
						_originalChq_reg_mth_misc_amt_316 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_316"]);
						_originalChq_reg_mth_misc_amt_317 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_317"]);
						_originalChq_reg_mth_misc_amt_318 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_318"]);
						_originalChq_reg_mth_misc_amt_41 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_41"]);
						_originalChq_reg_mth_misc_amt_42 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_42"]);
						_originalChq_reg_mth_misc_amt_43 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_43"]);
						_originalChq_reg_mth_misc_amt_44 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_44"]);
						_originalChq_reg_mth_misc_amt_45 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_45"]);
						_originalChq_reg_mth_misc_amt_46 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_46"]);
						_originalChq_reg_mth_misc_amt_47 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_47"]);
						_originalChq_reg_mth_misc_amt_48 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_48"]);
						_originalChq_reg_mth_misc_amt_49 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_49"]);
						_originalChq_reg_mth_misc_amt_410 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_410"]);
						_originalChq_reg_mth_misc_amt_411 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_411"]);
						_originalChq_reg_mth_misc_amt_412 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_412"]);
						_originalChq_reg_mth_misc_amt_413 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_413"]);
						_originalChq_reg_mth_misc_amt_414 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_414"]);
						_originalChq_reg_mth_misc_amt_415 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_415"]);
						_originalChq_reg_mth_misc_amt_416 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_416"]);
						_originalChq_reg_mth_misc_amt_417 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_417"]);
						_originalChq_reg_mth_misc_amt_418 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_418"]);
						_originalChq_reg_mth_misc_amt_51 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_51"]);
						_originalChq_reg_mth_misc_amt_52 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_52"]);
						_originalChq_reg_mth_misc_amt_53 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_53"]);
						_originalChq_reg_mth_misc_amt_54 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_54"]);
						_originalChq_reg_mth_misc_amt_55 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_55"]);
						_originalChq_reg_mth_misc_amt_56 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_56"]);
						_originalChq_reg_mth_misc_amt_57 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_57"]);
						_originalChq_reg_mth_misc_amt_58 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_58"]);
						_originalChq_reg_mth_misc_amt_59 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_59"]);
						_originalChq_reg_mth_misc_amt_510 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_510"]);
						_originalChq_reg_mth_misc_amt_511 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_511"]);
						_originalChq_reg_mth_misc_amt_512 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_512"]);
						_originalChq_reg_mth_misc_amt_513 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_513"]);
						_originalChq_reg_mth_misc_amt_514 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_514"]);
						_originalChq_reg_mth_misc_amt_515 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_515"]);
						_originalChq_reg_mth_misc_amt_516 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_516"]);
						_originalChq_reg_mth_misc_amt_517 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_517"]);
						_originalChq_reg_mth_misc_amt_518 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_518"]);
						_originalChq_reg_mth_misc_amt_61 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_61"]);
						_originalChq_reg_mth_misc_amt_62 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_62"]);
						_originalChq_reg_mth_misc_amt_63 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_63"]);
						_originalChq_reg_mth_misc_amt_64 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_64"]);
						_originalChq_reg_mth_misc_amt_65 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_65"]);
						_originalChq_reg_mth_misc_amt_66 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_66"]);
						_originalChq_reg_mth_misc_amt_67 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_67"]);
						_originalChq_reg_mth_misc_amt_68 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_68"]);
						_originalChq_reg_mth_misc_amt_69 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_69"]);
						_originalChq_reg_mth_misc_amt_610 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_610"]);
						_originalChq_reg_mth_misc_amt_611 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_611"]);
						_originalChq_reg_mth_misc_amt_612 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_612"]);
						_originalChq_reg_mth_misc_amt_613 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_613"]);
						_originalChq_reg_mth_misc_amt_614 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_614"]);
						_originalChq_reg_mth_misc_amt_615 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_615"]);
						_originalChq_reg_mth_misc_amt_616 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_616"]);
						_originalChq_reg_mth_misc_amt_617 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_617"]);
						_originalChq_reg_mth_misc_amt_618 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_618"]);
						_originalChq_reg_mth_misc_amt_71 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_71"]);
						_originalChq_reg_mth_misc_amt_72 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_72"]);
						_originalChq_reg_mth_misc_amt_73 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_73"]);
						_originalChq_reg_mth_misc_amt_74 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_74"]);
						_originalChq_reg_mth_misc_amt_75 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_75"]);
						_originalChq_reg_mth_misc_amt_76 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_76"]);
						_originalChq_reg_mth_misc_amt_77 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_77"]);
						_originalChq_reg_mth_misc_amt_78 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_78"]);
						_originalChq_reg_mth_misc_amt_79 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_79"]);
						_originalChq_reg_mth_misc_amt_710 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_710"]);
						_originalChq_reg_mth_misc_amt_711 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_711"]);
						_originalChq_reg_mth_misc_amt_712 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_712"]);
						_originalChq_reg_mth_misc_amt_713 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_713"]);
						_originalChq_reg_mth_misc_amt_714 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_714"]);
						_originalChq_reg_mth_misc_amt_715 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_715"]);
						_originalChq_reg_mth_misc_amt_716 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_716"]);
						_originalChq_reg_mth_misc_amt_717 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_717"]);
						_originalChq_reg_mth_misc_amt_718 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_718"]);
						_originalChq_reg_mth_misc_amt_81 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_81"]);
						_originalChq_reg_mth_misc_amt_82 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_82"]);
						_originalChq_reg_mth_misc_amt_83 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_83"]);
						_originalChq_reg_mth_misc_amt_84 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_84"]);
						_originalChq_reg_mth_misc_amt_85 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_85"]);
						_originalChq_reg_mth_misc_amt_86 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_86"]);
						_originalChq_reg_mth_misc_amt_87 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_87"]);
						_originalChq_reg_mth_misc_amt_88 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_88"]);
						_originalChq_reg_mth_misc_amt_89 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_89"]);
						_originalChq_reg_mth_misc_amt_810 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_810"]);
						_originalChq_reg_mth_misc_amt_811 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_811"]);
						_originalChq_reg_mth_misc_amt_812 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_812"]);
						_originalChq_reg_mth_misc_amt_813 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_813"]);
						_originalChq_reg_mth_misc_amt_814 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_814"]);
						_originalChq_reg_mth_misc_amt_815 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_815"]);
						_originalChq_reg_mth_misc_amt_816 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_816"]);
						_originalChq_reg_mth_misc_amt_817 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_817"]);
						_originalChq_reg_mth_misc_amt_818 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_818"]);
						_originalChq_reg_mth_misc_amt_91 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_91"]);
						_originalChq_reg_mth_misc_amt_92 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_92"]);
						_originalChq_reg_mth_misc_amt_93 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_93"]);
						_originalChq_reg_mth_misc_amt_94 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_94"]);
						_originalChq_reg_mth_misc_amt_95 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_95"]);
						_originalChq_reg_mth_misc_amt_96 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_96"]);
						_originalChq_reg_mth_misc_amt_97 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_97"]);
						_originalChq_reg_mth_misc_amt_98 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_98"]);
						_originalChq_reg_mth_misc_amt_99 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_99"]);
						_originalChq_reg_mth_misc_amt_910 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_910"]);
						_originalChq_reg_mth_misc_amt_911 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_911"]);
						_originalChq_reg_mth_misc_amt_912 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_912"]);
						_originalChq_reg_mth_misc_amt_913 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_913"]);
						_originalChq_reg_mth_misc_amt_914 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_914"]);
						_originalChq_reg_mth_misc_amt_915 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_915"]);
						_originalChq_reg_mth_misc_amt_916 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_916"]);
						_originalChq_reg_mth_misc_amt_917 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_917"]);
						_originalChq_reg_mth_misc_amt_918 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_918"]);
						_originalChq_reg_mth_misc_amt_101 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_101"]);
						_originalChq_reg_mth_misc_amt_102 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_102"]);
						_originalChq_reg_mth_misc_amt_103 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_103"]);
						_originalChq_reg_mth_misc_amt_104 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_104"]);
						_originalChq_reg_mth_misc_amt_105 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_105"]);
						_originalChq_reg_mth_misc_amt_106 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_106"]);
						_originalChq_reg_mth_misc_amt_107 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_107"]);
						_originalChq_reg_mth_misc_amt_108 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_108"]);
						_originalChq_reg_mth_misc_amt_109 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_109"]);
						_originalChq_reg_mth_misc_amt_1010 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1010"]);
						_originalChq_reg_mth_misc_amt_1011 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1011"]);
						_originalChq_reg_mth_misc_amt_1012 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1012"]);
						_originalChq_reg_mth_misc_amt_1013 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1013"]);
						_originalChq_reg_mth_misc_amt_1014 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1014"]);
						_originalChq_reg_mth_misc_amt_1015 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1015"]);
						_originalChq_reg_mth_misc_amt_1016 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1016"]);
						_originalChq_reg_mth_misc_amt_1017 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1017"]);
						_originalChq_reg_mth_misc_amt_1018 = ConvertDEC(Reader["CHQ_REG_MTH_MISC_AMT_1018"]);
						_originalChq_reg_mth_exp_amt1 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT1"]);
						_originalChq_reg_mth_exp_amt2 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT2"]);
						_originalChq_reg_mth_exp_amt3 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT3"]);
						_originalChq_reg_mth_exp_amt4 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT4"]);
						_originalChq_reg_mth_exp_amt5 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT5"]);
						_originalChq_reg_mth_exp_amt6 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT6"]);
						_originalChq_reg_mth_exp_amt7 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT7"]);
						_originalChq_reg_mth_exp_amt8 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT8"]);
						_originalChq_reg_mth_exp_amt9 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT9"]);
						_originalChq_reg_mth_exp_amt10 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT10"]);
						_originalChq_reg_mth_exp_amt11 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT11"]);
						_originalChq_reg_mth_exp_amt12 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT12"]);
						_originalChq_reg_mth_exp_amt13 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT13"]);
						_originalChq_reg_mth_exp_amt14 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT14"]);
						_originalChq_reg_mth_exp_amt15 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT15"]);
						_originalChq_reg_mth_exp_amt16 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT16"]);
						_originalChq_reg_mth_exp_amt17 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT17"]);
						_originalChq_reg_mth_exp_amt18 = ConvertDEC(Reader["CHQ_REG_MTH_EXP_AMT18"]);
						_originalChq_reg_comp_ann_exp_this_pay1 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY1"]);
						_originalChq_reg_comp_ann_exp_this_pay2 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY2"]);
						_originalChq_reg_comp_ann_exp_this_pay3 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY3"]);
						_originalChq_reg_comp_ann_exp_this_pay4 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY4"]);
						_originalChq_reg_comp_ann_exp_this_pay5 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY5"]);
						_originalChq_reg_comp_ann_exp_this_pay6 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY6"]);
						_originalChq_reg_comp_ann_exp_this_pay7 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY7"]);
						_originalChq_reg_comp_ann_exp_this_pay8 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY8"]);
						_originalChq_reg_comp_ann_exp_this_pay9 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY9"]);
						_originalChq_reg_comp_ann_exp_this_pay10 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY10"]);
						_originalChq_reg_comp_ann_exp_this_pay11 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY11"]);
						_originalChq_reg_comp_ann_exp_this_pay12 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY12"]);
						_originalChq_reg_comp_ann_exp_this_pay13 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY13"]);
						_originalChq_reg_comp_ann_exp_this_pay14 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY14"]);
						_originalChq_reg_comp_ann_exp_this_pay15 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY15"]);
						_originalChq_reg_comp_ann_exp_this_pay16 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY16"]);
						_originalChq_reg_comp_ann_exp_this_pay17 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY17"]);
						_originalChq_reg_comp_ann_exp_this_pay18 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_EXP_THIS_PAY18"]);
						_originalChq_reg_mth_ceil_amt1 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT1"]);
						_originalChq_reg_mth_ceil_amt2 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT2"]);
						_originalChq_reg_mth_ceil_amt3 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT3"]);
						_originalChq_reg_mth_ceil_amt4 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT4"]);
						_originalChq_reg_mth_ceil_amt5 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT5"]);
						_originalChq_reg_mth_ceil_amt6 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT6"]);
						_originalChq_reg_mth_ceil_amt7 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT7"]);
						_originalChq_reg_mth_ceil_amt8 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT8"]);
						_originalChq_reg_mth_ceil_amt9 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT9"]);
						_originalChq_reg_mth_ceil_amt10 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT10"]);
						_originalChq_reg_mth_ceil_amt11 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT11"]);
						_originalChq_reg_mth_ceil_amt12 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT12"]);
						_originalChq_reg_mth_ceil_amt13 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT13"]);
						_originalChq_reg_mth_ceil_amt14 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT14"]);
						_originalChq_reg_mth_ceil_amt15 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT15"]);
						_originalChq_reg_mth_ceil_amt16 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT16"]);
						_originalChq_reg_mth_ceil_amt17 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT17"]);
						_originalChq_reg_mth_ceil_amt18 = ConvertDEC(Reader["CHQ_REG_MTH_CEIL_AMT18"]);
						_originalChq_reg_comp_ann_ceil_this_pay1 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY1"]);
						_originalChq_reg_comp_ann_ceil_this_pay2 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY2"]);
						_originalChq_reg_comp_ann_ceil_this_pay3 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY3"]);
						_originalChq_reg_comp_ann_ceil_this_pay4 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY4"]);
						_originalChq_reg_comp_ann_ceil_this_pay5 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY5"]);
						_originalChq_reg_comp_ann_ceil_this_pay6 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY6"]);
						_originalChq_reg_comp_ann_ceil_this_pay7 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY7"]);
						_originalChq_reg_comp_ann_ceil_this_pay8 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY8"]);
						_originalChq_reg_comp_ann_ceil_this_pay9 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY9"]);
						_originalChq_reg_comp_ann_ceil_this_pay10 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY10"]);
						_originalChq_reg_comp_ann_ceil_this_pay11 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY11"]);
						_originalChq_reg_comp_ann_ceil_this_pay12 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY12"]);
						_originalChq_reg_comp_ann_ceil_this_pay13 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY13"]);
						_originalChq_reg_comp_ann_ceil_this_pay14 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY14"]);
						_originalChq_reg_comp_ann_ceil_this_pay15 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY15"]);
						_originalChq_reg_comp_ann_ceil_this_pay16 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY16"]);
						_originalChq_reg_comp_ann_ceil_this_pay17 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY17"]);
						_originalChq_reg_comp_ann_ceil_this_pay18 = ConvertDEC(Reader["CHQ_REG_COMP_ANN_CEIL_THIS_PAY18"]);
						_originalChq_reg_earnings_this_mth1 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH1"]);
						_originalChq_reg_earnings_this_mth2 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH2"]);
						_originalChq_reg_earnings_this_mth3 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH3"]);
						_originalChq_reg_earnings_this_mth4 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH4"]);
						_originalChq_reg_earnings_this_mth5 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH5"]);
						_originalChq_reg_earnings_this_mth6 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH6"]);
						_originalChq_reg_earnings_this_mth7 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH7"]);
						_originalChq_reg_earnings_this_mth8 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH8"]);
						_originalChq_reg_earnings_this_mth9 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH9"]);
						_originalChq_reg_earnings_this_mth10 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH10"]);
						_originalChq_reg_earnings_this_mth11 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH11"]);
						_originalChq_reg_earnings_this_mth12 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH12"]);
						_originalChq_reg_earnings_this_mth13 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH13"]);
						_originalChq_reg_earnings_this_mth14 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH14"]);
						_originalChq_reg_earnings_this_mth15 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH15"]);
						_originalChq_reg_earnings_this_mth16 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH16"]);
						_originalChq_reg_earnings_this_mth17 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH17"]);
						_originalChq_reg_earnings_this_mth18 = ConvertDEC(Reader["CHQ_REG_EARNINGS_THIS_MTH18"]);
						_originalChq_reg_regular_pay_this_mth1 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH1"]);
						_originalChq_reg_regular_pay_this_mth2 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH2"]);
						_originalChq_reg_regular_pay_this_mth3 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH3"]);
						_originalChq_reg_regular_pay_this_mth4 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH4"]);
						_originalChq_reg_regular_pay_this_mth5 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH5"]);
						_originalChq_reg_regular_pay_this_mth6 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH6"]);
						_originalChq_reg_regular_pay_this_mth7 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH7"]);
						_originalChq_reg_regular_pay_this_mth8 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH8"]);
						_originalChq_reg_regular_pay_this_mth9 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH9"]);
						_originalChq_reg_regular_pay_this_mth10 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH10"]);
						_originalChq_reg_regular_pay_this_mth11 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH11"]);
						_originalChq_reg_regular_pay_this_mth12 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH12"]);
						_originalChq_reg_regular_pay_this_mth13 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH13"]);
						_originalChq_reg_regular_pay_this_mth14 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH14"]);
						_originalChq_reg_regular_pay_this_mth15 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH15"]);
						_originalChq_reg_regular_pay_this_mth16 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH16"]);
						_originalChq_reg_regular_pay_this_mth17 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH17"]);
						_originalChq_reg_regular_pay_this_mth18 = ConvertDEC(Reader["CHQ_REG_REGULAR_PAY_THIS_MTH18"]);
						_originalChq_reg_regular_tax_this_mth1 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH1"]);
						_originalChq_reg_regular_tax_this_mth2 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH2"]);
						_originalChq_reg_regular_tax_this_mth3 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH3"]);
						_originalChq_reg_regular_tax_this_mth4 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH4"]);
						_originalChq_reg_regular_tax_this_mth5 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH5"]);
						_originalChq_reg_regular_tax_this_mth6 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH6"]);
						_originalChq_reg_regular_tax_this_mth7 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH7"]);
						_originalChq_reg_regular_tax_this_mth8 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH8"]);
						_originalChq_reg_regular_tax_this_mth9 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH9"]);
						_originalChq_reg_regular_tax_this_mth10 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH10"]);
						_originalChq_reg_regular_tax_this_mth11 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH11"]);
						_originalChq_reg_regular_tax_this_mth12 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH12"]);
						_originalChq_reg_regular_tax_this_mth13 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH13"]);
						_originalChq_reg_regular_tax_this_mth14 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH14"]);
						_originalChq_reg_regular_tax_this_mth15 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH15"]);
						_originalChq_reg_regular_tax_this_mth16 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH16"]);
						_originalChq_reg_regular_tax_this_mth17 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH17"]);
						_originalChq_reg_regular_tax_this_mth18 = ConvertDEC(Reader["CHQ_REG_REGULAR_TAX_THIS_MTH18"]);
						_originalChq_reg_man_pay_this_mth1 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH1"]);
						_originalChq_reg_man_pay_this_mth2 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH2"]);
						_originalChq_reg_man_pay_this_mth3 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH3"]);
						_originalChq_reg_man_pay_this_mth4 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH4"]);
						_originalChq_reg_man_pay_this_mth5 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH5"]);
						_originalChq_reg_man_pay_this_mth6 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH6"]);
						_originalChq_reg_man_pay_this_mth7 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH7"]);
						_originalChq_reg_man_pay_this_mth8 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH8"]);
						_originalChq_reg_man_pay_this_mth9 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH9"]);
						_originalChq_reg_man_pay_this_mth10 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH10"]);
						_originalChq_reg_man_pay_this_mth11 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH11"]);
						_originalChq_reg_man_pay_this_mth12 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH12"]);
						_originalChq_reg_man_pay_this_mth13 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH13"]);
						_originalChq_reg_man_pay_this_mth14 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH14"]);
						_originalChq_reg_man_pay_this_mth15 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH15"]);
						_originalChq_reg_man_pay_this_mth16 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH16"]);
						_originalChq_reg_man_pay_this_mth17 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH17"]);
						_originalChq_reg_man_pay_this_mth18 = ConvertDEC(Reader["CHQ_REG_MAN_PAY_THIS_MTH18"]);
						_originalChq_reg_man_tax_this_mth1 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH1"]);
						_originalChq_reg_man_tax_this_mth2 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH2"]);
						_originalChq_reg_man_tax_this_mth3 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH3"]);
						_originalChq_reg_man_tax_this_mth4 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH4"]);
						_originalChq_reg_man_tax_this_mth5 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH5"]);
						_originalChq_reg_man_tax_this_mth6 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH6"]);
						_originalChq_reg_man_tax_this_mth7 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH7"]);
						_originalChq_reg_man_tax_this_mth8 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH8"]);
						_originalChq_reg_man_tax_this_mth9 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH9"]);
						_originalChq_reg_man_tax_this_mth10 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH10"]);
						_originalChq_reg_man_tax_this_mth11 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH11"]);
						_originalChq_reg_man_tax_this_mth12 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH12"]);
						_originalChq_reg_man_tax_this_mth13 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH13"]);
						_originalChq_reg_man_tax_this_mth14 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH14"]);
						_originalChq_reg_man_tax_this_mth15 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH15"]);
						_originalChq_reg_man_tax_this_mth16 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH16"]);
						_originalChq_reg_man_tax_this_mth17 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH17"]);
						_originalChq_reg_man_tax_this_mth18 = ConvertDEC(Reader["CHQ_REG_MAN_TAX_THIS_MTH18"]);
						_originalChq_reg_pay_date1 = ConvertDEC(Reader["CHQ_REG_PAY_DATE1"]);
						_originalChq_reg_pay_date2 = ConvertDEC(Reader["CHQ_REG_PAY_DATE2"]);
						_originalChq_reg_pay_date3 = ConvertDEC(Reader["CHQ_REG_PAY_DATE3"]);
						_originalChq_reg_pay_date4 = ConvertDEC(Reader["CHQ_REG_PAY_DATE4"]);
						_originalChq_reg_pay_date5 = ConvertDEC(Reader["CHQ_REG_PAY_DATE5"]);
						_originalChq_reg_pay_date6 = ConvertDEC(Reader["CHQ_REG_PAY_DATE6"]);
						_originalChq_reg_pay_date7 = ConvertDEC(Reader["CHQ_REG_PAY_DATE7"]);
						_originalChq_reg_pay_date8 = ConvertDEC(Reader["CHQ_REG_PAY_DATE8"]);
						_originalChq_reg_pay_date9 = ConvertDEC(Reader["CHQ_REG_PAY_DATE9"]);
						_originalChq_reg_pay_date10 = ConvertDEC(Reader["CHQ_REG_PAY_DATE10"]);
						_originalChq_reg_pay_date11 = ConvertDEC(Reader["CHQ_REG_PAY_DATE11"]);
						_originalChq_reg_pay_date12 = ConvertDEC(Reader["CHQ_REG_PAY_DATE12"]);
						_originalChq_reg_pay_date13 = ConvertDEC(Reader["CHQ_REG_PAY_DATE13"]);
						_originalChq_reg_pay_date14 = ConvertDEC(Reader["CHQ_REG_PAY_DATE14"]);
						_originalChq_reg_pay_date15 = ConvertDEC(Reader["CHQ_REG_PAY_DATE15"]);
						_originalChq_reg_pay_date16 = ConvertDEC(Reader["CHQ_REG_PAY_DATE16"]);
						_originalChq_reg_pay_date17 = ConvertDEC(Reader["CHQ_REG_PAY_DATE17"]);
						_originalChq_reg_pay_date18 = ConvertDEC(Reader["CHQ_REG_PAY_DATE18"]);
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