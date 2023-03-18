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
        private Model model;
        public Form1()
        {
            InitializeComponent();
            model = new Model();
            model.observer += new System.EventHandler(this.getUpdateaFromModel);
        }

        private void numericUpDownA_ValueChanged(object sender, EventArgs e)
        {
            model.setA(Decimal.ToInt32(numericUpDownA.Value));
        }

        private void getUpdateaFromModel(object sender, EventArgs e)
        {

        }

        private void textBoxA_TextChanged(object sender, EventArgs e)
        {

        }
    }
    public class Model
    {
        private int a = 0, b = 0, c = 0;
        private const int min = 0, max = 100;
        public System.EventHandler observer;
        
        private int getChekedInterval(int newNum)
        {
            return ((newNum > 100) ? 100 : ((newNum < 0) ? 0 : newNum));
        }
        public void setA(int newA)
        {
            newA = getChekedInterval(newA);
            if (newA > b) b = newA;
            else if (newA > c) c = newA;
            else a = newA;

            observer.Invoke(this, null);
        }
        public void setB(int newB)
        {
            newB = getChekedInterval(newB);
            if (newB < a) b = a;
            else if (newB > c) b = c;
            else b = newB;

            observer.Invoke(this, null);
        }
        public void setC(int newC)
        {
            newC = getChekedInterval(newC);
            if (newC < b) b = newC;
            else if (newC < a) a = newC;
            else c = newC;

            observer.Invoke(this, null);
        }

        public int getA() { return this.a; }
        public int getB() { return this.b; }
        public int getC() { return this.c; }
    }
}
