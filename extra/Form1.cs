using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;


namespace extra
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }
        conexion con = new conexion();
        
        
        private void Form1_Load(object sender, EventArgs e)
        {
            con.conectar();
            MostrarDatos();
            btnAlta.Enabled = false;
        }
        public void MostrarDatos()
        {
            con.consulta("select * from datos", "datos");
            dgvDatos.DataSource = con.ds.Tables["datos"];
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {


            string colsu = "Select count (Codigo) from datos where Codigo = ( '" + txtcodigo.Text + "')";
            string agregar = "insert into datos values(" + txtcodigo.Text + ",'" + txtdescri.Text + "'," + txtnum.Text + ",'" + comboBox1.Text  + "')";


            if (string.IsNullOrWhiteSpace(txtcodigo.Text))
            {
                MessageBox.Show("falta el codigo");
                txtdescri.Clear();
                txtnum.Clear();
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                if (con.existeID(colsu))
                {
                    MessageBox.Show("ya existe ese ID");
                    return;
                }
                else
                {
                    if (con.insertar(agregar))
                    {
                        MessageBox.Show("Datos agragados");
                        MostrarDatos();
                        txtcodigo.Clear();
                        txtdescri.Clear();
                        txtnum.Clear();
                        comboBox1.SelectedIndex = 0;

                    }


                    else
                    {
                        MessageBox.Show("ERROR no se agrego");
                    }
                }
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            if(con.baja("datos ", " Codigo = " + txtcodigo.Text))
            {
                MessageBox.Show("Baja exitosa");
                MostrarDatos();
                txtcodigo.Clear();
                txtdescri.Clear();
                txtnum.Clear();
                comboBox1.SelectedIndex = 0;

            }
            else
            {
                MessageBox.Show("ERROR");
            }
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dtv = dgvDatos.Rows[e.RowIndex];
            txtcodigo.Text = dtv.Cells[0].Value.ToString();
            txtdescri.Text = dtv.Cells[1].Value.ToString();
            txtnum.Text = dtv.Cells[2].Value.ToString();
            comboBox1.Text = dtv.Cells[3].Value.ToString();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string modifacacion = "Descripcion='" + txtdescri.Text + "', Numero_Provedor= " + txtnum.Text + ", Activo = '" + comboBox1.Text + "'";
            if (con.modificar("datos ", modifacacion, " Codigo = " + txtcodigo.Text))
            {
                MessageBox.Show("Datos modificados ");
                MostrarDatos();
                txtcodigo.Clear();
                txtdescri.Clear();
                txtnum.Clear();
                comboBox1.SelectedIndex = 0;

            }
            else
            {
                MessageBox.Show("EL ID YA EXISTE POR LO CUAL NO SE PUEDE MODIFICAR");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtcodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.solonum(e);
        }

        private void txtactivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.sololetra(e);
        }

        private void txtnum_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.solonum(e);
        }
        private void valiVacio()
        {
            var vr = !string.IsNullOrEmpty(txtcodigo.Text) &&
                !string.IsNullOrEmpty(txtdescri.Text) &&
                !string.IsNullOrEmpty(txtnum.Text) &&
                !string.IsNullOrEmpty(comboBox1.SelectedIndex.ToString());
            
           
                btnAlta.Enabled = vr;
           
           
            
                
               
                
            
        }

        private void txtcodigo_TextChanged(object sender, EventArgs e)
        {
            valiVacio();
        }

        private void txtdescri_TextChanged(object sender, EventArgs e)
        {
            valiVacio();
        }

        private void txtnum_TextChanged(object sender, EventArgs e)
        {
            valiVacio();
        }

        private void txtactivo_TextChanged(object sender, EventArgs e)
        {
            valiVacio();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtcodigo.Clear();
            txtdescri.Clear();
            txtnum.Clear();
            comboBox1.SelectedIndex = 0;
        }

        private void txtcodigo_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void txtcodigo_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
