using System;
using System.Collections.Generic;
using System.Linq;

namespace Module5HW1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var start = new Startup();
            await start.Run();
        }
    }
}