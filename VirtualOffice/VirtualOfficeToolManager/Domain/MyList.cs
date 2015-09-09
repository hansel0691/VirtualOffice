using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualOfficeToolManager.Domain
{
    public class MyList<T>: IEnumerable<T>
    {
        private readonly List<T> _list;

        public MyList()
        {
            _list= new List<T>();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
