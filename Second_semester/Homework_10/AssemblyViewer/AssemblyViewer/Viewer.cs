using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssemblyViewer
{
    public partial class Viewer : Form
    {
        public Viewer()
        {
            InitializeComponent();
            openFileDialog = new OpenFileDialog();
            tip.Text = "Выберите тип файлов, чтобы установить фильтр";
            buttonOK.Enabled = false;
        }

        private void OnButtonOKClick(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = "c:\\University\\Second_Semestr\\";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    nameBox.Text = "";
                    viewerBox.Text = "";
                    nameBox.Text = openFileDialog.FileName;
                    var assembly = System.Reflection.Assembly.LoadFile(openFileDialog.FileName);
                    foreach (var type in assembly.GetTypes())
                    {
                        viewerBox.Text += "class " + type.Name + "\r\n";
                        foreach (var method in type.GetMethods())
                        {
                            viewerBox.Text += "             " + method.Name + "(";
                            var parameters = method.GetParameters();
                            for (int i = 0; i < parameters.Length; ++i)
                            {
                                viewerBox.Text += parameters[i];
                            }

                            viewerBox.Text += ")\r\n";
                        }

                        viewerBox.Text += "\r\n";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void OnButton_exeClick(object sender, EventArgs e)
        {
            openFileDialog.Filter = "exe files|*.exe";
            tip.Text = "Значение фильтра .exe Нажмите OK, чтобы продолжить";
            buttonOK.Enabled = true;
            button_exe.Enabled = false;
            button_dll.Enabled = true;
        }

        private void OnButton_dllClick(object sender, EventArgs e)
        {
            openFileDialog.Filter = "dll files|*.dll";
            tip.Text = "Значение фильтра .dll Нажмите OK, чтобы продолжить";
            buttonOK.Enabled = true;
            button_dll.Enabled = false;
            button_exe.Enabled = true;
        }

        private OpenFileDialog openFileDialog;
    }
}
