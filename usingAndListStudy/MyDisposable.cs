using System;

namespace usingAndListStudy
{
    public sealed class MyDisposable : IDisposable
    {
        readonly string _name;

        public MyDisposable(string name)
        {
            _name = name;

            if (name.Length == 0)
                throw new Exception("EMPTY NAME!");
        }

        public void Dispose()
        {
            Console.WriteLine($"Dispose() called. this is [{this}]");
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
