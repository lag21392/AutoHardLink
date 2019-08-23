using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;



namespace AutoHardLink
{
    


    public partial class Form1 : Form
    {




        public static bool esArchivo { get; set; } = true;
        public static string pathCarpetaDeLinks { get; set; } = "";
        public Form1()
        {

            MessageBox.Show("AutoLink:\n\nCrea copia de carpeta o archivo a un destino, borra el de el origen y lo sustituye por un link (hardlink en caso de carpetas y softlink en archivos), para que se mantenga como si estubieara en el origen.\nEs idea para liberar espacio de aplicaciones en unidades que no se pueden instalar en otra unidad normalmente.\n\n Creado por: \n\t\t  Lucas Agustin Gonzalez \n\t\t  lag21392@gmail.com");

            InitializeComponent();

            

            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo d in allDrives)
            {

                comboBox1.Items.Add(d.Name.Substring(0,1));
            }


        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e) 
        {
            const string comilla = "\"";
            using (Process myProcess = new Process())
                
            {

                
                
                string log = "\\hardlinkCopy.log ";
                string path = Directory.GetCurrentDirectory();
                
               // MessageBox.Show(pathMasComando);
                //string origen = "c:\\aaaa";
                string origen = textBox1.Text;
                if (origen != "" & comboBox1.Text != "") {

                    string comando = "";
                    string destino = "";
                    string destinoSinArch = "";

                    if (checkBox1.CheckState == CheckState.Checked) {
                        pathCarpetaDeLinks = "DataLinks_By_AutoLink\\";
                        
                    }
                    else
                    {
                        pathCarpetaDeLinks = "";
                    }

                    if (esArchivo == true)
                    {

                        
                        comando = "\\hardlinkCopyFile.bat ";
                        destino = comboBox1.Text + ":\\"+ pathCarpetaDeLinks + origen.Substring(3);
                        destinoSinArch = comboBox1.Text + ":\\" + pathCarpetaDeLinks + origen.Substring(3, origen.LastIndexOf("\\")-2);
                        MessageBox.Show(destinoSinArch + "     " + destino);
                        myProcess.StartInfo.Arguments = comilla + origen + comilla + " " + comilla + destino + comilla+ " " + comilla + destinoSinArch + comilla + ">> " + path + log;
                    }
                    else
                    {
                        comando = "\\hardlinkCopyFolder.bat ";
                        destino = comboBox1.Text + ":\\" + pathCarpetaDeLinks + origen.Substring(3);
                        MessageBox.Show(destinoSinArch + "     " + destino);
                        myProcess.StartInfo.Arguments = comilla + origen + comilla + " " + comilla + destino + comilla + ">> " + path + log;
                    }

                    

                    myProcess.StartInfo.UseShellExecute = true;


                    myProcess.StartInfo.FileName = path + comando;
                    
 
                    myProcess.StartInfo.CreateNoWindow = false;
                   
                    myProcess.Start();


                    textBox2.Text="EnProceso " + path + comando + comilla + origen + comilla + " " + comilla + destino + comilla;
                    myProcess.WaitForExit();
                    try
                    {//Pass the filepath and filename to the StreamWriter ConstructorStreamWriter 
                        
                        string text = System.IO.File.ReadAllText(path + log);
                        richTextBox1.Text = text;
                        textBox2.Text = "Finalizado Log: " + path + log;

                    }
                    catch
                    {
                        MessageBox.Show("No puedo leer log");
                    }
                    textBox2.Text = "Finalizado Log: " + path + log;
                }
                else
                {
                    MessageBox.Show("Escribir Origen y disco de Destino correcto ");
                }
                
                
                


            }
           

        }




        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void FolderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void Button2_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog browserdialog = new FolderBrowserDialog();
            if (browserdialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = browserdialog.SelectedPath;
                esArchivo = false;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog browserdialog = new OpenFileDialog();
            if (browserdialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = browserdialog.FileName;
                esArchivo = true;
            }
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            string log = "\\hardlinkCopy.log ";
            string path = Directory.GetCurrentDirectory();
            try
            {//Pass the filepath and filename to the StreamWriter ConstructorStreamWriter 
                string text = System.IO.File.ReadAllText(path + log);
                richTextBox1.Text = text;
               

            }
            catch
            {
                MessageBox.Show("No puedo leer log");
            }
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            string log = "\\hardlinkCopy.log ";
            string path = Directory.GetCurrentDirectory();

            if (File.Exists(path + log))
            {

                File.Delete(path + log);
            }

            // Create the file.
            using (FileStream fs = File.Create(path + log))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes("");

                fs.Write(info, 0, info.Length);
            }
            button4.PerformClick();

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
