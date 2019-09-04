using BaltimoreAdoptALot.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaltimoreAdoptALot
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                testLotLookup();
            }
            else
                LookupLot(args[0]);

        }

        private static void LookupLot(string lotNumber)
        {
            var result = AddressLookup.LookupAddressByLot(lotNumber);
            Console.WriteLine(result.address.Match_addr);
        }

        private static void testLotLookup()
        {
            var lotNumber = "3357 008";

            var result = AddressLookup.LookupAddressByLot(lotNumber);

            lotNumber = "3357I004";
            result = AddressLookup.LookupAddressByLot(lotNumber);

            var sb = new StringBuilder();

        }
    }
}
