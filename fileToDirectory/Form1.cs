using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fileToDirecory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "請選擇資料夾";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = dialog.SelectedPath;

             
                textBox1.Text = filepath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "請選擇資料夾";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = dialog.SelectedPath;


                textBox2.Text = filepath;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string filePath = textBox1.Text;
            string distPath = textBox2.Text;
            if (!Directory.Exists(filePath)|| !Directory.Exists(filePath))
            {
                MessageBox.Show("請填入來源與目標資料夾", "",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            string[] fileEntries = Directory.GetFiles(filePath);
            string[] subdirectoryEntries = Directory.GetDirectories(distPath);

            foreach (string file in fileEntries)
            {
                string fileName = Path.GetFileName(file).Split('.')[0];
                string distFile = distPath + "\\" + fileName + "\\" + Path.GetFileName(file);
                if (subdirectoryEntries.Contains(distPath+"\\"+fileName))
                {
                    File.Copy(file, distFile, true);
                }
                else
                {
                    Directory.CreateDirectory(distPath + "\\" + fileName);
                    File.Copy(file, distFile, true);
                }
            }
        }
    }
}
