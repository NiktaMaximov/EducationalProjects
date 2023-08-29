using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams.LazyExample
{
    public static class LazyExample
    {
        // Пример без отложенной инициализации
        //static LazyExample()
        //{
        //    CacheData = GetData();
        //}

        // Использование Lazy в конструкторе
        static LazyExample()
        {
            Lazy<Data> data = new Lazy<Data>();
            var dta = data.Value;
        }

        public static Data CacheData { get; set; }

        public static Data GetData()
        {
            return new Data();
        }
    }

    public class Data
    {
    }
}
