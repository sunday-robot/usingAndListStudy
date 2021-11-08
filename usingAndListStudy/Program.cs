using System;
using System.Collections.Generic;

namespace usingAndListStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestConvertAll();
            TestTraditionalWay();
        }

        static void TestConvertAll()
        {
            var names = new List<string>() { "abc", "def", "", "ghi" };
            try
            {
                // ↓"using var mds..."と記述したいが、ListはIDisposableではないので、usingは使えない。
                // ConvertAll()の途中で例外が投げられると、それ以前に生成されたMyDisposableのインスタンスはDispose()が呼ばれないままGC対象となる。
                // FileStream等の場合は、おそらくGCでインスタンスが破棄されるまでオープンしたままとなってしまう。
                var mds = names.ConvertAll(name => new MyDisposable(name));
                Console.WriteLine(mds);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static void TestTraditionalWay()
        {
            var names = new List<string>() { "abc", "def", "", "ghi" };
            var mds = new List<MyDisposable>();
            try
            {
                foreach (var name in names)
                {
                    mds.Add(new MyDisposable(name));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                foreach (var md in mds)
                {
                    md.Dispose();
                }
            }
        }
    }
}
