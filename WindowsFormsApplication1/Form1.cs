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
           
            double[] InnerArray__A = new double[my_class.Nn];
            double[] InnerArray__T = new double[my_class.Nn];

            InnerArray__A[0] = 1;
            InnerArray__A[1] = 1;
            InnerArray__A[2] = 1;
            InnerArray__A[3] = 1;
            InnerArray__A[4] = 1;
            InnerArray__A[5] = 1;
            InnerArray__A[6] = 1;

            InnerArray__T[0] = 0;
            InnerArray__T[1] = 1;
            InnerArray__T[2] = 2;
            InnerArray__T[3] = 3;
            InnerArray__T[4] = 4;
            InnerArray__T[5] = 5;
            InnerArray__T[6] = 6;



            my_class.DPF(InnerArray__A,InnerArray__T);

            for (int i = 0; i < my_class.Nn-1; i++)
            {
                listBox1.Items.Add( my_class.Furie[i].Amplitude);
            }


            for (int i = 0; i < my_class.Nn-1; i++)
            {
                listBox2.Items.Add(my_class.Furie[i].Faza);
            }

            for (int i = 0; i < my_class.Nn-1; i++)
            {
                listBox3.Items.Add(my_class.Furie[i].Frecuensy);
            }
            for (int i = 0; i < my_class.Nn-1; i++)
            {
                listBox4.Items.Add(my_class.Furie[i].Re);
            }
            for (int i = 0; i < my_class.Nn-1; i++)
            {
                listBox5.Items.Add(my_class.Furie[i].Im);
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
            
           
            Clipboard.SetDataObject(resStr);
        }

        private void button1_Click(object sender, EventArgs e)
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
        }

 

      

       

       

      
    }
}
