using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.IO;
using System.Net;
using Assert = NUnit.Framework.Assert;

namespace InforUnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            NUnit.Framework.Assert.Pass();
        }

        [TestMethod]
        public void VlaidateStatusCode200()
        {
            string Url = @"https://ct.pinterest.com/user/?event=search&ed=%7B%22np%22%3A%22gtm%22%7D&tid=2612859132799&cb=1664577078288";

            var request = WebRequest.Create(Url);
            request.Method = "GET";

            var webResponse = request.GetResponse();

            Assert.That(webResponse, Is.Not.Null.And.EqualTo("200")); 
           
        }

        [TestMethod]
        public void VlaidateParameterValue()
        {
            string Url = @"https://ct.pinterest.com/user/?event=search&ed=%7B%22np%22%3A%22gtm%22%7D&tid=2612859132799&cb=1664577078288";

            var request = WebRequest.Create(Url);
            request.Method = "GET";

            var webResponse = request.GetResponse();

            Assert.That("isUtilizingAdvertiser1pEnabled", Is.Not.Null.And.EqualTo(false));

        }

        [TestMethod]
        public void VlaidateStatusCode500()
        {
            string Url = @"https://www.google.com/recaptcha/api2/webworker.js?hl=en&v=ovmhLiigaw4D9ujHYlHcKKhP";

            var request = WebRequest.Create(Url);
            request.Method = "POST";

            WebResponse webResponse = null;
            try
            {
                webResponse = request.GetResponse();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Assert.That(webResponse, Is.Not.Null.And.EqualTo("500"));

        }

    }
}