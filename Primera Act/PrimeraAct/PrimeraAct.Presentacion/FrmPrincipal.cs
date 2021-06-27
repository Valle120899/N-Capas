using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PrimeraAct.Negocio;

namespace PrimeraAct.Presentacion
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        //Se manda a llamar a la función Listar para mostrar desde un inicio los datos insertados en la BD
        private void Listar()
        {
            try
            {
                DgvListado.DataSource = NPersona.Listar();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //Se ocupa para limpiar los labels, el contenido de cada uno, evitando inyección de código
        private void Limpiar()
        {
            txbName.Clear();
            txbApellido.Clear();
            txbTelefono.Clear();
            txbAge.Clear();
            BtnInsert.Visible = true;
        }

        //Este método mantiene activo la query de Listar desde que se abre la ventana
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            this.Listar();
            
        }

        private void MensajeError(String Mensaje)
        {
            MessageBox.Show(Mensaje, " Error", MessageBoxButtons.OK);
        }

        private void MensajeOK(String Mensaje)
        {
            MessageBox.Show(Mensaje, " Tarea 1", MessageBoxButtons.OK);
        }

        private void txbName_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";

                //Se verifica que todos los textbox estén llenos, caso contrario hay error.
                if(txbName.Text==string.Empty || txbApellido.Text == String.Empty || txbAge.Text == string.Empty || txbTelefono.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar algunos datos.");

                }
                //Con este condicional, se verifica que el número de teléfono al menos cumpla con que su lóngitud sea de 8
                else if(txbTelefono.Text.Length != 8)
                {
                    this.MensajeError("Ingrese el celular correctamente.");

                }
                else
                {
                    //En la BD existen 5 roles, por lo tanto, al no estar especificado en la tarea, 
                    //Se selecciona un número random cada que se inserta un nuevo usuario
                    Random Generator = new Random();
                    int rol = Generator.Next(1, 5);

                    Rpta = NPersona.Insertar(txbName.Text.Trim(), txbApellido.Text.Trim(), Convert.ToInt32(txbAge.Text), txbTelefono.Text, rol);

                    if (Rpta.Equals("Ok"))
                    {
                        this.MensajeOK("Se insertó de forma correcta el registro");
                        this.Limpiar();
                        this.Listar();
                        this.Refresh();
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void DgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
