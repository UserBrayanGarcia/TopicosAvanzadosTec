using System;
using System.Drawing;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace TAPU2_Ejemplo1
{
    public partial class Form1 : Form
    {
        Button button = new Button();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCrearControl_Click(object sender, EventArgs e)
        {
            //Crear controles, en tiempo de ejecucion
            //Instanciar una clase de tipo Button           

            button.Name = "btn1";
            button.Text = "Soy nuevo";
            button.Top = (this.Height / 2) - 25;
            button.Left = (this.Width / 2) - 45;
            button.Height = 50;
            button.Width = 90;
            button.FlatStyle = FlatStyle.Flat;
            //Este control hay que ponerlo en el Form1
            this.Controls.Add(button);
            //Asociar el button a un evento
            button.Click += new EventHandler(btn1_Click);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Controls.Remove(button);
        }

        private void btn1_Click(object sender, EventArgs e) {
            this.BackColor = Color.Aqua;
            MessageBox.Show("Evento creado en tiempo de ejecución");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblCantidad.Text = tbCantidad.Value.ToString();
        }

        private void tbCantidad_Scroll(object sender, EventArgs e)
        {
            lblCantidad.Text = tbCantidad.Value.ToString();
        }

        private void btnCrearCajas_Click(object sender, EventArgs e)
        {
            //crear las cajas          
            //byte cantidadDeCajas1 = (byte)tbCantidad.Value;
            //byte numeroPequeño = 255;
            //int numeroGrande = numeroPequeño ; //conv implicita                                               
            byte cantidadDeCajas = Convert.ToByte(tbCantidad.Value);

            //crear las cajas
            for (int i = 1; i <= cantidadDeCajas; i++)
            {
                //Crear cajas de texto
                TextBox txtControl = new TextBox();
                txtControl.Name = "txt"+ i.ToString();
                txtControl.Tag = i;
                txtControl.Size = new Size(60, 15);
                txtControl.Location = new Point(ClientSize.Width / 2, 25 * (i + 1));
                txtControl.Text = txtControl.Name;
                this.Controls.Add(txtControl);

                //asociarlo a un evento
                txtControl.Enter += new EventHandler(txtClick);                

                //  DateTimePicker calendario = new DateTimePicker();
                //  calendario.Name = "calendar";
                //  calendario.Tag = i;
                //  calendario.Size = new Size(20, 25);
                //  calendario.Location = new Point(ClientSize.Width -100, 25 * (i + 1));
                ////  calendario.Text = calendario.Name;
                //  this.Controls.Add(calendario);
            }
        }

        //metodo para usar las cajas
        public void txtClick(object sender, EventArgs e) {
            string speech = string.Format("El nombrre del Control es:" + ((TextBox)sender).Name.ToString());
            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            // speechSynthesizer.GetInstalledVoices();
            MessageBox.Show(speechSynthesizer.Voice.Name);
            while (true)
            {
                speechSynthesizer.Speak(speech);
            }
         //   MessageBox.Show("Control:" + ((TextBox)sender).Name.ToString());
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            Bitmap screen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            using (Graphics g = Graphics.FromImage(screen))
            {
                g.CopyFromScreen(0, 0, 0, 0, screen.Size);
            }
            pictureBox1.Image = screen;
        }
    }
}
