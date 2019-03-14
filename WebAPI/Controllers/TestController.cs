using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class TestController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetPersonJson()
        {
            Person person = new Person()
            {
                FirstName = "Ali",
                LastName = "Veli",
                Adress = new Adress
                {
                    City = "İzmir",
                    FullAdress = "Ataşehir mah."
                },
                PhoneNumbers = new List<string>
                {
                    "099999999",
                    "088888888"
                }

            };

            return Request.CreateResponse(HttpStatusCode.OK, person);
        }


        [HttpGet]
        public HttpResponseMessage GetPersonXML()
        {
            Person person = new Person()
            {
                FirstName = "Ali",
                LastName = "Veli",
                Adress = new Adress
                {
                    City = "İzmir",
                    FullAdress = "Ataşehir mah."
                },
                PhoneNumbers = new List<string>
                {
                    "099999999",
                    "088888888"
                }

            };

            GlobalConfiguration.Configuration.Formatters.Clear();
            GlobalConfiguration.Configuration.Formatters.Add(new System.Net.Http.Formatting.XmlMediaTypeFormatter());
            return Request.CreateResponse(HttpStatusCode.OK, person);

        }
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
