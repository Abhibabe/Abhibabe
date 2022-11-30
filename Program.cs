using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace File_IO_Demo
{
    public partial class Form1 : Form
    {
        FileStream fs;
        BinaryWriter bw;
        BinaryReader br;
        StreamWriter sw;
        StreamReader sr;

        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                fs = new FileStream(@"E:\Wipro\emp.dat", FileMode.Open, FileAccess.Read);
                br = new BinaryReader(fs);
                txtEmpId.Text = br.ReadInt32().ToString();
                txtEmpName.Text = br.ReadString();
                txtSalary.Text = br.ReadDouble().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                br.Close();
                fs.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                fs = new FileStream(@"E:\Wipro\emp.dat", FileMode.Create, FileAccess.Write);
                bw = new BinaryWriter(fs);
                bw.Write(Convert.ToInt32(txtEmpId.Text));
                bw.Write(txtEmpName.Text);
                bw.Write(Convert.ToDouble(txtSalary.Text));
                MessageBox.Show("Data added to file");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                bw.Close();
                fs.Close();
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnCreateFolder_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"E:\Wipro";
                if (Directory.Exists(path))
                {
                    MessageBox.Show("Folder exists");
                }
                else
                {
                    Directory.CreateDirectory(path);
                    MessageBox.Show("Folder created");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void BtnCreateFile_Click_1(object sender, EventArgs e)
        {
            try
            {
                string path = @"E:\Wipro\sample.txt";
                if (File.Exists(path))
                {
                    MessageBox.Show("File exits");
                }
                else
                {
                    File.Create(path);
                    MessageBox.Show("File created");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnStreamWrite_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"E:\Wipro\testfile.txt", FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(richTextBox1.Text);
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sw.Close();
                fs.Close();
            }
        }

        private void btnStramRead_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"E:\Wipro\testfile.txt", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                richTextBox1.Text = sr.ReadToEnd();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sr.Close();
                fs.Close();
            }

        }
    }
}