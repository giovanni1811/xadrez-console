using System;

namespace xadrez
{
    class XadrezException : Exception
    {
        public XadrezException(string msg) : base(msg) { 
        }
    }
}
