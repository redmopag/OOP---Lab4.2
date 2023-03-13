using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void numericUpDownA_ValueChanged(object sender, EventArgs e)
        {

        }
    }
    public class Model
    {
        private int a = 0, b = 0, c = 0;
        public System.EventHandler observer;
        
        public void setA(int a)
        {
            if (a < 0 || a > 100)
            {
                this.a = this.b = this.c = (a > 100) ? 100 : 0;
            }
            else if (a > this.b)
            {
                if (a > this.c)
                    this.a = this.b = this.c = a;
                else
                    this.a = this.b = a;
            }
            else
                this.a = a;
        }
        public void setB(int b)
        {
            if (b >= 0 && b <= 100 && b >= a && b <= c)
            {
                this.b = b;
            }
        }
        public void setC(int c)
        {
            if (c < 0 || c > 100)
                this.c = this.b = this.a = (c > 100) ? 100 : 0;
            else if (c < this.b)
            {
                if (c < this.a)
                    this.c = this.b = this.a = c;
                else
                    this.c = this.b = c;
            }
            else
                this.c = c;
        }

        public int getA() { return this.a; }
        public int getB() { return this.b; }
        public int getC() { return this.c; }
    }
}
