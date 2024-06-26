﻿using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB4_BAI3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            richTextBox1.ReadOnly = true;
            button1.Visible = false;
            
        }

       


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

      

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            string url = textBox1.Text;
            string filePath = textBox2.Text;



            LoadTextFromFile(filePath, url);

            richTextBox1.Text = File.ReadAllText(filePath);

        }

        private string DownloadString(string url)
        {
            try
            {
                WebClient client = new WebClient();
                return client.DownloadString(url);
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Kiểm tra lại URL", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
            
        }
        private void LoadTextFromFile(string filePath,string url)
        {
            try
            {
                File.WriteAllText(filePath, DownloadString(url));

            }
            catch (IOException ex)
            {
                
                MessageBox.Show($"Lỗi đọc file: {ex.Message}");
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "/";
                openFileDialog.Filter = "Text Files (*.txt)|*.txt";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.CheckFileExists = false;
                openFileDialog.CheckPathExists = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    textBox2.Text = selectedFilePath;
                }
            }
            if (textBox2.Text != "") { button1.Visible = true; }
        }
    }
}
