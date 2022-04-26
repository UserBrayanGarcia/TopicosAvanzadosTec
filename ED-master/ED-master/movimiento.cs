using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ED_Ejemplo3
{
    public partial class movimiento : Form
    {
        //Variable global
        private int x, y, limite;
        public movimiento()
        {
            InitializeComponent();
            this.BackColor = Color.White;
            timer1.Enabled = true;
            limite = this.Width;

        }
        int contador;
        private void timer1_Tick(object sender, EventArgs e)
        {
            contador++;
            label1.Text = contador.ToString();
            //Mover el gif
            corredor1.Left = x += 10;
            if (x>=limite)
            {
                timer1.Stop();
            }
           
        }

        private void movimiento_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                label2.Text = i.ToString();
                System.Threading.Thread.Sleep(3);
            }
        }
    }
}
