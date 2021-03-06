﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualOffice.Data.External
{
    public static class ExtentionMethods
    {
        public static IEnumerable<T> Select<T>(this IDataReader reader,
                                       Func<IDataReader, T> projection)
        {
            while (reader.Read())
            {
                var a = projection(reader);
                yield return a;
            }
        }

    }
}
