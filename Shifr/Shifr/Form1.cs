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
namespace Shifr
{
    public partial class Form1 : Form
    {

            static public string text;
            static char[] Z = new char[12];
            static char[] a = new char[12];
            static char[] SCH = new char[12];
            static char[] I = new char[12];
            static char[] T = new char[12];
            static char[] A = new char[12];
            static public string Encrypt()
            {
                if (text.Length < 72)
                {
                MessageBox.Show("Текст содержит меньше 72 символов. Недостающие символы будут автоматически забиты рандомом ( ͡° ͜ʖ ͡°)");
                Random random = new Random();
                text += " ";
                while (text.Length < 72)
                {
                    text += (char)random.Next(0,127);
                }
                }
                else if (text.Length > 72)
                {
                MessageBox.Show("Текст содержит больше 72 символов. Лишние будут обрезаны ( ͡° ͜ʖ ͡°)");
                text = text.Substring(0, 72);
                }
                for (int i = 0; i < 12; i++)
                {
                    Z[i] = text[i];
                }
                for (int i = 12; i < 24; i++)
                {
                    a[i - 12] = text[i];
                }
                for (int i = 24; i < 36; i++)
                {
                    SCH[i - 24] = text[i];
                }
                for (int i = 36; i < 48; i++)
                {
                    I[i - 36] = text[i];
                }
                for (int i = 48; i < 60; i++)
                {
                    T[i - 48] = text[i];
                }
                for (int i = 60; i < 72; i++)
                {
                    A[i - 60] = text[i];
                }
                char[] finalchar = new char[72];
                for (int i = 0; i < 12; i++)
                {
                    finalchar[i * 6] = a[i];
                    finalchar[i * 6 + 1] = A[i];
                    finalchar[i * 6 + 2] = Z[i];
                    finalchar[i * 6 + 3] = I[i];
                    finalchar[i * 6 + 4] = T[i];
                    finalchar[i * 6 + 5] = SCH[i];
                }

                string output = new string(finalchar);
            return output;
            }
        static public string Decrypt()
        {
            for (int i = 0; i < 12; i++)
            {
                a[i] = text[i*6];
                A[i] = text[i*6+1];
                Z[i] = text[i*6+2];
                I[i] = text[i*6+3];
                T[i] = text[i*6+4];
                SCH[i] = text[i*6+5];
            }
            string output1 = new string(Z);
            string output2 = new string(a);
            string output3 = new string(SCH);
            string output4 = new string(I);
            string output5 = new string(T);
            string output6 = new string(A);
            return output1 + output2 + output3 + output4 + output5 + output6;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    text = File.ReadAllText(openFileDialog1.FileName);
                    richTextBox1.Text = Decrypt();
                    MessageBox.Show("Текст расшифрован успешно");
                }

            }
            else if (radioButton2.Checked)
            {
                text = richTextBox1.Text;
                File.WriteAllText("Зашифрованный текст.txt",Encrypt());
                MessageBox.Show("Текст зашифрован\nИщите его в дебаге");
            }
            
        }
    }
}
