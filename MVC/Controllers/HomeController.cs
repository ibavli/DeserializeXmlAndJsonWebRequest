using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            WebRequest request = WebRequest.Create(
              "http://localhost:50413/api/test/GetPersonJson");

            request.Credentials = CredentialCache.DefaultCredentials;

            WebResponse response = request.GetResponse();

            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            Stream dataStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();


            var personObject = JsonConvert.DeserializeObject<Person>(responseFromServer);
            var dynamicType = JsonConvert.DeserializeObject<dynamic>(responseFromServer);

            var firstName = dynamicType.FirstName;
            var list = dynamicType.PhoneNumbers;
            foreach (var item in list)
            {

            }
            foreach (var item in personObject.PhoneNumbers)
            {

            }
            reader.Close();
            response.Close();
            return View();
        }

        public class Person
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public Adress Adress { get; set; }

            public List<string> PhoneNumbers { get; set; }
        }

        public class Adress
        {
            public string FullAdress { get; set; }

            public string City { get; set; }

        }

    }
}