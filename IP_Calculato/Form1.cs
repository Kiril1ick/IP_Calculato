using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IP_Calculato
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            string FirstByte="", SecondByte=null, ThirdByte="", FouthByte="";
            int ByteOne=0, ByteTwo=0, ByteThree=0, ByteFouth=0;
            int Hosts;
            int a=0,shag=0;
            int Masc = Convert.ToInt32(textBox2.Text);
            string txt1= textBox1.Text;
            for (int i = 0; i < txt1.Length; i++)
            {
                if (txt1[i] == '.')
                {
                    a++;
                }
                if (a == 0 && txt1[i] != '.')
                {
                    FirstByte += txt1[i];
                }
                if (a == 1 && txt1[i]!='.')
                {
                    SecondByte += txt1[i];
                }
                if (a == 2 && txt1[i] != '.')
                {
                    ThirdByte += txt1[i];
                }
                if (a == 3 && txt1[i] != '.')
                {
                    FouthByte += txt1[i];
                }
            }

            label1.Text = "IP =" + textBox1.Text;

            Hosts = (int)Math.Pow(2, 32 - Masc);
            label2.Text = "Hosts ="+ (Hosts-2);

            for (int i=0;i<(32-Masc)%8;i++)
            {
                shag += (int)Math.Pow(2, i);
            }

            if (Masc>=0 && Masc<=8)
            {
                ByteOne = int.Parse(FirstByte) - shag;
                if (ByteOne % (shag+1) != 0)
                {
                    while (ByteOne % (shag+1) != 0)
                    {
                        ByteOne++;
                    }
                }
                label3.Text = "Network =" + ByteOne + "." + 0 + "." + 0 + "." + 0;
            }
            if (Masc >8 && Masc <= 16)
            {
                ByteTwo = int.Parse(SecondByte) - shag;
                if (ByteTwo % (shag + 1) != 0)
                {
                    while (ByteTwo % (shag + 1) != 0)
                    {
                        ByteTwo++;
                    }
                }
                label3.Text = "Network =" + FirstByte + "." + ByteTwo + "." + 0 + "." + 0;
            }
            if (Masc > 16 && Masc <= 24)
            {
                ByteThree = int.Parse(ThirdByte) - shag;
                if (ByteThree % (shag + 1) != 0)
                {
                    while (ByteThree % (shag + 1) != 0)
                    {
                        ByteThree++;
                    }
                }
                label3.Text = "Network =" + FirstByte + "." + SecondByte + "." + ByteThree + "." + 0;
            }
            if (Masc > 24 && Masc <= 32)
            {
                ByteFouth = int.Parse(FouthByte) - shag;
                if (ByteFouth % (shag + 1) != 0)
                {
                    while (ByteFouth % (shag + 1) != 0)
                    {
                        ByteFouth++;
                    }
                }
                label3.Text ="Network ="+ FirstByte + "." + SecondByte + "." + ThirdByte + "." + ByteFouth;
            }


            if (Masc >= 0 && Masc <= 8)
            {
                ByteOne +=shag;
                label4.Text ="Brodecast ="+ ByteOne + "." + 255 + "." + 255 + "." + 255;
            }
            if (Masc > 8 && Masc <= 16)
            {
                ByteTwo +=shag;
                label4.Text = "Brodecast =" + FirstByte + "." + ByteTwo + "." + 255 + "." + 255;
            }
            if (Masc > 16 && Masc <= 24)
            {
                ByteThree +=shag;
                label4.Text = "Brodecast =" + FirstByte + "." + SecondByte + "." + ByteThree + "." + 255;
            }
            if (Masc > 24 && Masc <= 32)
            {
                ByteFouth +=shag;
                label4.Text = "Brodecast =" + FirstByte + "." + SecondByte + "." + ThirdByte + "." + ByteFouth;
            }
        }
    }
}
