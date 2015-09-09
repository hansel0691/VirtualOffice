using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VirtualOffice.Data.Helpers
{
    public class Helper
    {
        public static byte[] GetVersionRow()
        {
            return BitConverter.GetBytes(DateTime.Now.Ticks);
        }

        public static string GetJsonDefaultOutPutConfig(string reportOutPut)
        {
            var columnsConfig = reportOutPut.Split(',').Select((a, i) => new 
            {
                Name = a,
                Width = 120,
                Index = i,
                Level = 0
            });

            var columnsConfigSerialized = JsonConvert.SerializeObject(columnsConfig);

            return columnsConfigSerialized;
        }
    }
}
