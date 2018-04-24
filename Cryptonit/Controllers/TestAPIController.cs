using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BlockCypher;
using BlockCypher.Objects;

namespace Cryptonit.Controllers
{
    public class TestAPIController : Controller
    {
        Blockcypher blockcypher = new Blockcypher("bd7d185d02654037a6620f5fa579a180");

        // GET: TestAPI
        public Task<AddressBalance> Index()
        {
            return blockcypher.GetBalanceForAddress("1MSH1S19YGjcF8hM2j6cTxyLehjryGaMkq");
        }
            //var request = blockcypher.GetBalanceForAddress("1MSH1S19YGjcF8hM2j6cTxyLehjryGaMkq").Result;

            //Satoshi c = request.Balance;

            //return c;

        
    }
}