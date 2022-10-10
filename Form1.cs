using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string Url = @"https://ct.pinterest.com/user/?event=search&ed=%7B%22np%22%3A%22gtm%22%7D&tid=2612859132799&cb=1664577078288";
            
            var request = WebRequest.Create(Url);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();

            var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();

            Console.WriteLine(data);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            long unixTimeNow = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            Console.WriteLine(unixTimeNow);
    
            long unixTimeTpomorrow = unixTimeNow + 86400;

            string Url = string.Format(@"https://ct.pinterest.com/user/?event=search&ed=%7B%22np%22%3A%22gtm%22%7D&tid={0}&cb={1}", unixTimeNow, unixTimeTpomorrow);
            //string Url = @"https://www.google.com/recaptcha/api2/webworker.js?hl=en&v=ovmhLiigaw4D9ujHYlHcKKhP/put";
            var request = WebRequest.Create(Url);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();

            var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();

            Console.WriteLine(data);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Url = @"https://www.google.com/recaptcha/api2/webworker.js?hl=en&v=ovmhLiigaw4D9ujHYlHcKKhP";

            var request = WebRequest.Create(Url);
            request.Method = "POST";
            WebResponse webResponse = null;
            try
            {
                webResponse = request.GetResponse();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return;
            }
            var webStream = webResponse.GetResponseStream();

            var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();

            Console.WriteLine(data);
        }







    }
}
