using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace MVC.Controllers
{
    public class XMLController : Controller
    {
        public ActionResult Index()
        {
            WebRequest request = WebRequest.Create(
              "http://localhost:50413/api/test/GetPersonXML");

            request.Credentials = CredentialCache.DefaultCredentials;

            WebResponse response = request.GetResponse();

            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            Stream dataStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(dataStream);

            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            Person deserialized = (Person)serializer.Deserialize(reader);

            return View();
        }

        [XmlRoot(ElementName = "Adress")]
        public class Adress
        {
            [XmlElement(ElementName = "City", Namespace = "http://schemas.datacontract.org/2004/07/WebAPI.Controllers")]
            public string City { get; set; }
            [XmlElement(ElementName = "FullAdress", Namespace = "http://schemas.datacontract.org/2004/07/WebAPI.Controllers")]
            public string FullAdress { get; set; }
        }

        [XmlRoot(ElementName = "PhoneNumbers", Namespace = "http://schemas.datacontract.org/2004/07/WebAPI.Controllers")]
        public class PhoneNumbers
        {
            [XmlElement(ElementName = "string", Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
            public List<string> String { get; set; }
            [XmlAttribute(AttributeName = "d2p1", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string D2p1 { get; set; }
        }

        [XmlRoot(ElementName = "Person", Namespace = "http://schemas.datacontract.org/2004/07/WebAPI.Controllers")]
        public class Person
        {
            [XmlElement(ElementName = "Adress", Namespace = "http://schemas.datacontract.org/2004/07/WebAPI.Controllers")]
            public Adress Adress { get; set; }
            [XmlElement(ElementName = "FirstName", Namespace = "http://schemas.datacontract.org/2004/07/WebAPI.Controllers")]
            public string FirstName { get; set; }
            [XmlElement(ElementName = "LastName", Namespace = "http://schemas.datacontract.org/2004/07/WebAPI.Controllers")]
            public string LastName { get; set; }
            [XmlElement(ElementName = "PhoneNumbers", Namespace = "http://schemas.datacontract.org/2004/07/WebAPI.Controllers")]
            public PhoneNumbers PhoneNumbers { get; set; }
            [XmlAttribute(AttributeName = "i", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string I { get; set; }
            [XmlAttribute(AttributeName = "xmlns")]
            public string Xmlns { get; set; }
        }
    }
}