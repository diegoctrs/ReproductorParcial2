using ReproductorParcial2.clases.listaCircularEjemplo;
using ReproductorParcial2.clases.listaDoble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReproductorParcial2
{
    public partial class Form1 : Form
    {
        private NodoListaC reg;

        ListaCircular primero = new ListaCircular();
        ClsListaDoble LDoble = new ClsListaDoble();
        //Lista addlist = new Lista();
        OpenFileDialog addpath = new OpenFileDialog();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (lstCanciones.SelectedIndex > 0)
            {
                lstCanciones.SelectedIndex -= 1;
            }
            else
            {
                volver();
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (lstCanciones.SelectedIndex < lstCanciones.Items.Count - 1)
            {
                lstCanciones.SelectedIndex += 1;
            }
            else
            {
                reiniciar();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                addpath.Multiselect = true;
                addpath.Filter = "Archivos audios (*.mp3),(*.mp4),(*.wav),(*.png)|";

                if (addpath.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    for (int i = 0; i < addpath.SafeFileNames.Length; i++)
                    {
                        LDoble.insertarCabezaArreglado(addpath.FileNames[i]); // inserta las canciones con lista doble
                        primero.insertarArreglado(addpath.FileNames[i]);
                        lstCanciones.Items.Add(addpath.SafeFileNames[i]);                  
                    }
                    axWindowsMediaPlayer1.URL = addpath.FileNames[0];
                    lstCanciones.SelectedIndex = 0;
                    int pause;
                    pause = 0;
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string eliminar = addpath.FileName;
            int indice = lstCanciones.SelectedIndex; // se toma la posicion

            if(lstCanciones.SelectedIndex != 1)
            {
                LDoble.eliminar(eliminar);
                lstCanciones.Items.RemoveAt(indice); // para eliminar la cancion en esa posicion
                axWindowsMediaPlayer1.Ctlcontrols.stop();
            }         
        }

        private void lstCanciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCanciones.SelectedIndex != -1)
            {
                axWindowsMediaPlayer1.URL = addpath.FileNames[lstCanciones.SelectedIndex];
                int indice = lstCanciones.SelectedIndex;
                reg = new NodoListaC(addpath.FileNames[indice]);
            }
        }

        private void btnCiclo_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRan_Click(object sender, EventArgs e)
        {
            Random aleatorio = new Random();
            int r = aleatorio.Next(lstCanciones.Items.Count - 1);
            axWindowsMediaPlayer1.URL = addpath.FileNames[r];
            lstCanciones.SelectedIndex = r;
        }

        public void reiniciar()
        {
            if (reg != null)
            {
                reg = primero.lc.enlace; 
                while (reg == primero.lc.enlace)
                {
                    if (lstCanciones.SelectedIndex < lstCanciones.Items.Count - 1)
                    {
                        lstCanciones.SelectedIndex += 1;
                        reg = reg.enlace;
                    }
                    else
                    {
                        axWindowsMediaPlayer1.URL = addpath.FileNames[0];
                        lstCanciones.SelectedIndex = 0;
                        reg = reg.enlace;
                    }
                    reg = reg.enlace;
                }
            }
            else
            {
                MessageBox.Show("\t Lista Circular vacía.");
            }
        }

        public void volver()
        {
            if (reg != null)
            {
                reg = primero.lc.enlace;
                while (reg == primero.lc.enlace)
                {
                    if (lstCanciones.SelectedIndex > 0)
                    {
                        lstCanciones.SelectedIndex -= 1;
                        reg = reg.enlace;
                    }
                    else
                    {
                        axWindowsMediaPlayer1.URL = addpath.FileNames[0];
                        lstCanciones.SelectedIndex = 4;
                        reg = reg.enlace;
                    }
                    reg = reg.enlace;
                }
            }
            else
            {
                MessageBox.Show("\t Lista Circular vacía.");
            }
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                trackBar1.Maximum = (int)axWindowsMediaPlayer1.Ctlcontrols.currentItem.duration;
                trackBar1.Value = (int)axWindowsMediaPlayer1.Ctlcontrols.currentPosition;

                if (trackBar1.Value == trackBar1.Maximum)
                {
                    reiniciar();
                }
            }
            try
            {
                trackBar1.Value = (int)axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
                label1.Text = axWindowsMediaPlayer1.Ctlcontrols.currentPositionString;
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            trackBar1.Maximum = (int)axWindowsMediaPlayer1.currentMedia.duration;

            if (trackBar1.Value == (int)axWindowsMediaPlayer1.Ctlcontrols.currentPosition)
            {
                //
            }
            else
            {
                axWindowsMediaPlayer1.Ctlcontrols.currentPosition = trackBar1.Value;
            }
        }

        public void ActualizarDatosTrack()
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                trackBar1.Maximum = (int)axWindowsMediaPlayer1.Ctlcontrols.currentItem.duration;
                timer1.Start();
            }
            else if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                timer1.Stop();
            }
            else if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                timer1.Stop();
            }
        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            ActualizarDatosTrack();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
