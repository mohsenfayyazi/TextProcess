using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace TextProcess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public bool TextFileProcess(string FileName)
        {
            try {
                string FileExt = System.IO.Path.GetExtension(FileName);

                //Check the TYPE of file
                if (string.Compare(FileExt.ToUpper(), ".TXT") != 0) {
                    MessageBox.Show("Please select the Text file", "error upload", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                //Check the SIZE of file
                long length = new System.IO.FileInfo(FileName).Length;
                if (length < 10)
                {
                    MessageBox.Show("Your file is empty", "error upload", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }


                List<string> FileLines = File.ReadAllLines(FileName).ToList();

                foreach (string line in FileLines)
                {
                    //Get the ISBN from the line
                    string resultString = Regex.Match(line, @"\d+").Value;
                    if (!string.IsNullOrEmpty(resultString))
                    {
                        Regex re = new Regex(@"\d+");
                        Match NumberMatchCase = re.Match(line);
                        //Get the ISBN from the line
                        string ISBN = Regex.Split(line, @"\D+")[1];


                        if (!string.IsNullOrEmpty(ISBN))
                        {
                            string Name = line.Substring(0, NumberMatchCase.Index).Trim();
                            string Author = line.Substring(NumberMatchCase.Index + ISBN.Length).Trim();

                            //Add data to listview row
                            ListViewItem lvi = new ListViewItem(Name);
                            lvi.SubItems.Add(ISBN);
                            lvi.SubItems.Add(Author);
                            listView1.Items.Add(lvi);



                        }
                    }





                }
                return true;
            }catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString(), "error upload", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
             openFileDialog1.ShowDialog();
             string FileName = openFileDialog1.FileName;

            //Call the Method to Process the Text File
             TextFileProcess(FileName);
            
                
        }

       
    }
}
