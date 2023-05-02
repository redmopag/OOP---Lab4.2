using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
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

        // Функция, обрабатывающая обновление модели
        private void getUpdateaFromModel(object sender, EventArgs e)
        {
            // set textBox
            textBoxA.Text = model.getA().ToString();
            textBoxB.Text = model.getB().ToString();
            textBoxC.Text = model.getC().ToString();

            // set numericUpDown
            numericUpDownA.Value = model.getA();
            numericUpDownB.Value = model.getB();
            numericUpDownC.Value = model.getC();

            // set trackBar
            trackBarA.Value = model.getA();
            trackBarB.Value = model.getB();
            trackBarC.Value = model.getC();
        }

        // Получение данных целочисленного типа из NumericUpDown
        private int getValueFromNumeric(object sender)
        {
            return (Decimal.ToInt32((sender as NumericUpDown).Value));
        }
        //
        // NumericUpDown
        //
        private void numericUpDownA_ValueChanged(object sender, EventArgs e)
        {
            model.setA(getValueFromNumeric(sender));
        }

        private void numericUpDownB_ValueChanged(object sender, EventArgs e)
        {
            model.setB(getValueFromNumeric(sender));
        }

        private void numericUpDownC_ValueChanged(object sender, EventArgs e)
        {
            model.setC(getValueFromNumeric(sender));
        }

        // Получнеие данных целочисленного типа из trackBar
        private int getValueFromTrackBar(object sender)
        {
            return (Decimal.ToInt32((sender as TrackBar).Value));
        }
        //
        // trackBar
        //
        private void trackBarA_Scroll(object sender, EventArgs e)
        {
            model.setA(getValueFromTrackBar(sender));
        }
        private void trackBarB_Scroll(object sender, EventArgs e)
        {
            model.setB(getValueFromTrackBar(sender));
        }
        private void trackBarC_Scroll(object sender, EventArgs e)
        {
            model.setC(getValueFromTrackBar(sender));
        }
        //
        // textbox
        //
        private int getValueFromTextBox(object sender)
        {
            return (Int32.Parse((sender as TextBox).Text));
        }
        private void textBoxA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                model.setA(getValueFromTextBox(sender));
        }

        private void textBoxB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                model.setB(getValueFromTextBox(sender));
        }

        private void textBoxC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                model.setC(getValueFromTextBox(sender));
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Записываем содержимое в созданные в settings переменные
            Properties.Settings.Default.a = model.getA();
            Properties.Settings.Default.b = model.getB();
            Properties.Settings.Default.c = model.getC();

            // Сохраняем значения
            Properties.Settings.Default.Save();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            // Получаем переменные из settings и зыписываем их в модель
            model.setA(Properties.Settings.Default.a);
            model.setC(Properties.Settings.Default.c);
            model.setB(Properties.Settings.Default.b);
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
            if (newA > c) c = newA;

            a = newA;
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
            if (newC < a) a = newC;

            c = newC;
            observer.Invoke(this, null);
        }

        public int getA() { return this.a; }
        public int getB() { return this.b; }
        public int getC() { return this.c; }
    }
}
