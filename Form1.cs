using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl.Http;
using System.Net;
using System.Collections.Specialized;
using System.IO;

namespace HttpPostTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var wb = new WebClient())
            {
                //string _auth = string.Format("{0}:{1}", "SindreMA", "########.");
                //string _enc = Convert.ToBase64String(Encoding.ASCII.GetBytes(_auth));
                //string _cred = string.Format("{0} {1}", "Basic", _enc);
                //wb.Headers.Add("Authorization", _cred);
                //var data = new NameValueCollection();
                //data["url"] = "youtube.com/watch?v=jNQXAC9IVRw";
                //data["jsonp"] = "callback";
                //var response = wb.UploadValues(@"http:\\safeshare.tv/api/generate", "GET", data);

                string link = "https://www.youtube.com/watch?v=7Ac76qgeoA0&";
                string dsds = HttpGet(@"http:\\safeshare.tv/api/generate?url=" + link);
                dsds = dsds.Replace("\"", "").Replace("\\", "").Replace("{", "").Replace(":", "").Replace("statussuccess,messageSafeview was created!,data[safeshare_id","") ;
                string[] gdf = dsds.Split(',');
                string newlink = "http://safeshare.tv/v/" + gdf[0];


            }
        }
        protected string get(string url)
        {
            try
            {
                string rt;

                WebRequest request = WebRequest.Create(url);

                WebResponse response = request.GetResponse();

                Stream dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                rt = reader.ReadToEnd();

                Console.WriteLine(rt);

                reader.Close();
                response.Close();

                return rt;
            }

            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
        public string HttpGet(string URI)
        {
            WebClient client = new WebClient();
            Stream data = client.OpenRead(URI);
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            data.Close();
            reader.Close();

            return s;
        }
    }
}
