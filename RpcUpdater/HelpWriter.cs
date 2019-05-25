using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RpcUpdater
{
    public class HelpWriter : TextWriter
    {
        private readonly List<string> list = new List<string>();

        public override Encoding Encoding { get; } = Encoding.ASCII;

        public override void Write(string value)
        {
            if (value != null)
            {
                list.Add(value);
            }
        }

        public void WriteToConsole()
        {
            foreach (string str in list)
            {
                Console.Error.Write(str);
            }
        }
    }
}
