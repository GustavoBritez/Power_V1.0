using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Power
{
    public partial class Form1 : Form
    {
        private bool _apagadoProgramado = false;
        private Thread _hiloInactividad;
        private bool _monitoreoActivo = false;
        Gestion_Archivo GC = new Gestion_Archivo();

        public Form1()
        {
            InitializeComponent();

            CK_00Hs.CheckedChanged += CK_00Hs_CheckedChanged;
            CK_Inactividad.CheckedChanged += CK_Inactividad_CheckedChanged;
            TXT_INACTIVIDAD.KeyPress += TXT_INACTIVIDAD_KeyPress;

            DGV_Estado.Columns.Add("Apagado 00Hs", "Apagado 00Hs");
            DGV_Estado.Columns.Add("Inactividad", "Inactividad");
            DGV_Estado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGV_Estado.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DGV_Estado.AllowUserToResizeColumns = false;
            DGV_Estado.AllowUserToAddRows = false;

            Cargar_DGV();
            Levantar_Aplicacion();

            TXT_INACTIVIDAD.Enabled = CK_Inactividad.Checked;
        }

        private void TXT_INACTIVIDAD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        public void Cargar_DGV()
        {
            DGV_Estado.Rows.Clear();
            List<string> datos = GC.Levantar_Datos();
            DGV_Estado.Rows.Add(datos[0], datos[1]);
        }

        private void BTN_Actualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(TXT_INACTIVIDAD.Text, out int tiempoInactividad) || tiempoInactividad <= 0)
                {
                    MessageBox.Show("El tiempo de inactividad debe ser un número mayor que cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Actualizar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Apagado_Por_Horario()
        {
            DateTime ahora = DateTime.Now;
            DateTime Forzar_Apagado = new DateTime(ahora.Year, ahora.Month, ahora.Day, 0, 0, 0).AddDays(1);
            TimeSpan hora_apagado = Forzar_Apagado - ahora;
            int segundos = (int)hora_apagado.TotalSeconds;
            Process.Start("shutdown", $"/s /t {segundos}");
        }

        public void Apagado_Por_Inactividad(int tiempo)
        {
            if (_apagadoProgramado)
            {
                MessageBox.Show("Ya hay un apagado programado por inactividad.");
                return;
            }
            _monitoreoActivo = true;
            _hiloInactividad = new Thread(() => MonitorearInactividad(tiempo));
            _hiloInactividad.Start();
        }

        public void Levantar_Aplicacion()
        {
            List<string> datos = GC.Levantar_Datos();


            TXT_INACTIVIDAD.Text = datos[2]; 


            if (datos[0] == "Activado")
            {
                CK_00Hs.Checked = true;
                Actualizar();
            }
            else
            {
                CK_00Hs.Checked = false;
            }


            if (datos[1] == "Desactivado")
            {
                CK_Inactividad.Checked = false;
            }
            else
            {
                CK_Inactividad.Checked = true;
                Actualizar();
            }
        }


        public void Actualizar()
        {
            try
            {
                List<string> datos = GC.Levantar_Datos();
                int tiempoInactividad;


                if (string.IsNullOrEmpty(TXT_INACTIVIDAD.Text))
                {
                    TXT_INACTIVIDAD.Text = "60";
                }

                if (CK_00Hs.Checked)
                {
                    Apagado_Por_Horario();
                    GC.Modificar_Archivo("Activado", "Desactivado", TXT_INACTIVIDAD.Text);
                    Cargar_DGV();
                }
                if (CK_Inactividad.Checked)
                {

                    if (!int.TryParse(TXT_INACTIVIDAD.Text, out tiempoInactividad) || tiempoInactividad <= 0)
                    {
                        MessageBox.Show("El tiempo de inactividad debe ser un número mayor que cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    Apagado_Por_Inactividad(tiempoInactividad);
                    GC.Modificar_Archivo("Desactivado", "Activado", TXT_INACTIVIDAD.Text);
                    Cargar_DGV();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void CK_00Hs_CheckedChanged(object sender, EventArgs e)
        {
            if (CK_00Hs.Checked)
            {
                CK_Inactividad.Checked = false;
            }
        }

        private void CK_Inactividad_CheckedChanged(object sender, EventArgs e)
        {
            TXT_INACTIVIDAD.Enabled = CK_Inactividad.Checked;

            if (CK_Inactividad.Checked)
            {
                CK_00Hs.Checked = false;
            }
            else
            {
                CancelarApagado();
            }
        }

        private void MonitorearInactividad(int tiempo)
        {
            TimeSpan umbralInicio = TimeSpan.FromMinutes(1);
            TimeSpan umbralApagado = TimeSpan.FromMinutes(tiempo);

            TimeSpan tiempoInactividad;

            while (_monitoreoActivo)
            {
                tiempoInactividad = Inactividad.ObtenerTiempoInactividad();

                if (tiempoInactividad >= umbralInicio)
                {
                    if (tiempoInactividad >= umbralApagado)
                    {
                        ProgramarApagado();
                        break;
                    }
                }
                else
                {
                    _apagadoProgramado = false;
                }
                Thread.Sleep(1000);
            }
        }

        private void ProgramarApagado()
        {
            Process.Start("shutdown", "/s /f");
            _apagadoProgramado = true;
        }

        public void CancelarApagado()
        {
            Process.Start("shutdown", "/a");
            _apagadoProgramado = false;
            _monitoreoActivo = false;
            if (_hiloInactividad != null && _hiloInactividad.IsAlive)
            {
                _hiloInactividad.Join();
            }
        }

        private void BTN_Desactivar_Click(object sender, EventArgs e)
        {
            CancelarApagado();

            CK_00Hs.Checked = false;
            CK_Inactividad.Checked = false;

            GC.Modificar_Archivo("Desactivar", "Desactivar", TXT_INACTIVIDAD.Text);
            Cargar_DGV();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}