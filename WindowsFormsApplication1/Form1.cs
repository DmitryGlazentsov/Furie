using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myClass my_class = new myClass();
           /* for (int i = 0; i < my_class.Nn; i++)
                my_class.InnerArray[i] = 5 * Math.Sin(2 * Math.PI * i / 100) * Math.Cos(2 * Math.PI * i / my_class.Nn); // задаем форму сигнала
            */
           
            double[] InnerArray__A = new double[20];
            double[] InnerArray__T = new double[20];

            InnerArray__A[0] = 10;
            InnerArray__A[1] = 15;
            InnerArray__A[2] = 8;
            InnerArray__A[3] = 13;
            InnerArray__A[4] = 6;
            InnerArray__A[5] = 3;
            InnerArray__A[6] = 1;
            InnerArray__A[7] = 1;
            InnerArray__A[8] = 1;
            InnerArray__A[9] = 1;
            InnerArray__A[10] = 1;
            InnerArray__A[11] = 1;
            InnerArray__A[12] = 1;
            InnerArray__A[13] = 1;
            InnerArray__A[14] = 1;
            InnerArray__A[15] = 1;
            InnerArray__A[16] = 1;
            InnerArray__A[17] = 1;
            InnerArray__A[18] = 1;
            InnerArray__A[19] = 1;
            

            InnerArray__T[0] = 0;
            InnerArray__T[1] = 1;
            InnerArray__T[2] = 2;
            InnerArray__T[3] = 3;
            InnerArray__T[4] = 4;
            InnerArray__T[5] = 5;
            InnerArray__T[6] = 6;
            InnerArray__T[7] = 7;
            InnerArray__T[8] = 8;
            InnerArray__T[9] = 9;
            InnerArray__T[10] = 10;
            InnerArray__T[11] = 11;
            InnerArray__T[12] = 12;
            InnerArray__T[13] = 13;
            InnerArray__T[14] = 14;
            InnerArray__T[15] = 15;
            InnerArray__T[16] = 16;
            InnerArray__T[17] = 17;
            InnerArray__T[18] = 18;
            InnerArray__T[19] = 19;
           
       



            my_class.DPF(InnerArray__A,InnerArray__T);

            PD obratochka = new PD();
            List<double> obr = new List<double>();
            obr = obratochka.FromFourier(my_class.output,20);


            for (int i = 0; i < my_class.Nn; i++)
            {
                listBox1.Items.Add(my_class.Furie[i].Amplitude);
                listBox2.Items.Add(my_class.Furie[i].Faza);
                listBox3.Items.Add(my_class.Furie[i].Freq);
                listBox4.Items.Add(my_class.Furie[i].Re);
                listBox5.Items.Add(my_class.Furie[i].Im);
                listBox8.Items.Add(obr[i]);
            }

            for(int i = 0; i < InnerArray__A.Length;i++)
            {
                listBox6.Items.Add(InnerArray__A[i]);
            }

            for (int i = 0; i < InnerArray__T.Length; i++)
            {
                listBox7.Items.Add(InnerArray__T[i]);
            }
            

                
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string resStr = string.Empty;
            resStr += " Re " + Environment.NewLine;
            foreach (object o in listBox4.Items)
            {
                resStr += o.ToString() + Environment.NewLine;
            }

            resStr += " Im " + Environment.NewLine;

            foreach (object o in listBox5.Items)
            {
                resStr += o.ToString() + Environment.NewLine;
            }

            resStr += " Amplitude " + Environment.NewLine;
            foreach (object o in listBox1.Items)
            {
                resStr += o.ToString() + Environment.NewLine;
            }
            resStr += " FAZA " + Environment.NewLine;
            foreach (object o in listBox2.Items)
            {
                resStr += o.ToString() + Environment.NewLine;
            }
            resStr += " Frequency " + Environment.NewLine;
            foreach (object o in listBox3.Items)
            {
                resStr += o.ToString() + Environment.NewLine;
            }
            resStr += " OBRATKA " + Environment.NewLine;
            foreach (object o in listBox8.Items)
            {
                resStr += o.ToString() + Environment.NewLine;
            }

            
           
            Clipboard.SetDataObject(resStr);
        }

       /* private void button1_Click(object sender, EventArgs e)
        {
            listBox6.Items.Clear();
            listBox7.Items.Clear();

            string text = textBox1.Text;
            string temp = string.Empty;
            int count= 0;
            label10.Text = textBox1.Text.Length.ToString();
            //textBox1.Text
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                if (text[i] == ' ')
                {
                    for (int k = count; k < i; k++ )
                    {
                        temp += text[k];
                        listBox6.Items.Add(temp);
                        temp = string.Empty;
                    }
                    count += 1;
                }
            }
        }*/

 

      

       

       

      
    }
}
