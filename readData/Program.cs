using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Oracle;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
using OracleInternal.SqlAndPlsqlParser;

namespace readData
{
    internal class Program
    {
        public static void Main(string[] args)
        {
                process pr = new process();
                pr.equalJson();
        }
    }
}
