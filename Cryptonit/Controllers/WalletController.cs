using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cryptonit.Controllers
{
    public class WalletController : Controller
    {
        // GET: Wallet
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddNewAddress()
        {
            return View();
        }
        public ActionResult MyAddresses()
        {
            return View();
        }

        public ActionResult Send()
        {
            return View();
        }
    }
}