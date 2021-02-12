using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Masny.DataTransfer.ClientService.Helpers
{
    public static class ServerConvertor
    {
        public static int ConvertPort(this string port, Ports ports)
        {
            return port switch
            {
                "EU" => ports.EU,
                "US" => ports.US,
                "BY" => ports.BY,
                _ => default,
            };
        }
    }
}
