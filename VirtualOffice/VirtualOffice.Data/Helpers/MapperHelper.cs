using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using VirtualOffice.Data.EFModels;


namespace VirtualOffice.Data.Helpers
{
    public static class MapperHelper
    {
        static MapperHelper()
        {
            InitializeMaps();
        }

        private static void InitializeMaps()
        {
            Mapper.CreateMap<IDataReader, sp_get_transactions_Result>()
               .ForMember(p => p.merchant_pk, k => k.MapFrom(r => r["merchant_pk"] is DBNull ? 0 : r["merchant_pk"] as int?))
               .ForMember(p => p.mer_name, k => k.MapFrom(m => m["mer_name"] is DBNull ? null : m["mer_name"].ToString()))
               .ForMember(p => p.datestamp, k => k.MapFrom(m => m["amex_amount"] is DBNull ? null : m["datestamp"] as string))
               .ForMember(p => p.vmc_amount, k => k.MapFrom(m => m["vmc_amount"] is DBNull ? null : m["vmc_amount"].ToString()))
               .ForMember(p => p.amex_amount, k => k.MapFrom(m => m["amex_amount"] is DBNull ? null : m["amex_amount"].ToString()))
               .ForMember(p => p.dscv_amount, k => k.MapFrom(m => m["dscv_amount"] is DBNull ? null : m["dscv_amount"].ToString()))
               .ForMember(p => p.ebt_amount, k => k.MapFrom(m => m["ebt_amount"] is DBNull ? null : m["ebt_amount"].ToString()))
               .ForMember(p => p.oth_amount, k => k.MapFrom(m => m["oth_amount"] is DBNull ? null : m["oth_amount"].ToString()))
               .ForMember(p => p.tran_amt, k => k.MapFrom(m => m["tran_amt"] is DBNull ? null : m["tran_amt"].ToString()));
        }

        public static K MapTo<T, K>(this T aModelSource)
        {
            var modelResult = Mapper.Map<T, K>(aModelSource);

            return modelResult;
        }
    }
}
