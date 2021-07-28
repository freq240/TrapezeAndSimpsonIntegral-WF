using System;
using System.Windows.Forms;

namespace TrapezeAndSimpsonIntegral
{
    public partial class MainForm : Form
    {

        Integral obj = new Integral();
        public MainForm()
        {
            InitializeComponent();
           
        }


        private void ShowGraph(double a, double b, double h)
        {
            for (double x = a; x <= b; x += h)
            {
                this.Graph.Series[0].BorderWidth = 8;
                this.Graph.Series[1].BorderWidth = 8;
                this.Graph.Series[2].BorderWidth = 8;
                this.Graph.Series[0].Points.AddXY(x, (Math.Pow(x,2) - 2*x + 1));
                this.Graph.Series[1].Points.AddXY(x, (-Math.Pow(x, 2) + 2));
                this.Graph.Series[2].Points.AddXY(x, 1);
            }
        }

        private void ReadFileButton_Click(object sender, EventArgs e)
        {
            textBox3.Text = Convert.ToString(obj.GetDot1());
            textBox4.Text = Convert.ToString(obj.GetDot2());
            textBox5.Text = Convert.ToString(obj.GetDot3());
            textBox6.Text = Convert.ToString(obj.GetEps());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(obj.SimpsonMethod());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = Convert.ToString(obj.TrapezeMethod());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowGraph(1, 2, 0.01);
        }

    }
}
