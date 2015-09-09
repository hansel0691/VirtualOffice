using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using AutoMapper;
using VirtualOfficeToolManager.Data;

namespace VirtualOfficeToolManager.Helpers
{
    static public class ConverterHelper
    {
        static ConverterHelper()
        {
            InitMaps();
        }


        private static void InitMaps()
        {

            #region Filters 

            //Mapper.CreateMap<UserFilter, Domain.UserFilter>();
            //Mapper.CreateMap<Domain.UserFilter, Data.UserFilter>().
            //ForMember(p => p.TimeSpan, t => t.ResolveUsing(a=> DateTime.Now));

            Mapper.CreateMap<Data.PredefinedFilter, Domain.PredefinedFilter>();
            Mapper.CreateMap<Domain.PredefinedFilter, PredefinedFilter>().
            ForMember(p => p.TimeSpan, t => t.ResolveUsing(a => DateTime.Now)).
            ForMember(p => p.RowVersion, t => t.ResolveUsing(a => GetVersionRow()));

            #endregion

            #region Report
            Mapper.CreateMap<Data.Report, Domain.Report>();
            Mapper.CreateMap<Domain.Report, Data.Report>()
            .ForMember(rep=> rep.DefaultOutput,a=> a.ResolveUsing(b=> string.Empty))
            .ForMember(rep => rep.RowVersion, a => a.ResolveUsing(b => new byte[1]));
            #endregion
        }
         
        public static K MapTo<T, K>(this T aModelSource)
        {
            var modelResult = Mapper.Map<T, K>(aModelSource);

            return modelResult;
        }

        public static byte[] GetVersionRow()
        {
            return BitConverter.GetBytes(DateTime.Now.Ticks);
        }

        public static bool IsNull<T>(this T item)
        {
            return item == null;
        }


        
    }
}
