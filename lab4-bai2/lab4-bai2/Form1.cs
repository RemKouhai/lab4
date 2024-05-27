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

namespace lab4_bai2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            richTextBox1.ReadOnly = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {

            string url = textBox1.Text;
            string postData = textBox2.Text;

            byte[] postDataBytes = Encoding.UTF8.GetBytes(postData);
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = postDataBytes.Length;

                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(postDataBytes, 0, postDataBytes.Length);
                }

                HttpWebResponse response;
                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                }
                catch (WebException ex)
                {
                   response = (HttpWebResponse)ex.Response;
                }


                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(responseStream))
                    {
                        string responseText = reader.ReadToEnd();
                        richTextBox1.Text = responseText;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại URL", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
