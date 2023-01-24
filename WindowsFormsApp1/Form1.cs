using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionBancariaAppNS
{
    public partial class GestionBancariaApp : Form
    {
        private double saldo;
            
        public const string ERR_CANTIDAD_NO_VALIDA = "Cantidad no válida";
        public const string ERR_SALDO_INSUFICIENTE = "Saldo insuficiente";


        public GestionBancariaApp(double saldo = 0)
        {
            InitializeComponent();
            if (saldo > 0)
                this.saldo = saldo;
            else
                this.saldo = 0;
            txtSaldo.Text = obtenerSaldo().ToString();
            txtCantidad.Text = "0";
        }

        public double obtenerSaldo() { return saldo; }

        public int realizarReintegro(double cantidad)
        {
            if (cantidad <= 0)
            {
                throw new ArgumentOutOfRangeException(ERR_CANTIDAD_NO_VALIDA);

            }
            if (saldo < cantidad)
            {
                throw new ArgumentOutOfRangeException(ERR_SALDO_INSUFICIENTE);
            }
            else
            {
                saldo -= cantidad;
            }
            return 0;
        }

        public int realizarIngreso(double cantidad)
        {
            if (cantidad > 0)
            {
                saldo += cantidad;
            }
            else
            {
                throw new ArgumentOutOfRangeException(ERR_CANTIDAD_NO_VALIDA);
            }


            return 0;
        }

        private void btOperar_Click(object sender, EventArgs e)
        {

            if (rbReintegro.Checked)
            {
                double cantidad = Convert.ToDouble(txtCantidad.Text);// Cogemos la cantidad del TextBox y la pasamos a número
                if (rbReintegro.Checked)
                {
                    try
                    {
                        realizarReintegro(cantidad);
                        MessageBox.Show("Transacción realizada.");
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Equals(ERR_SALDO_INSUFICIENTE))
                            MessageBox.Show("No se ha podido realizar la operación (¿Saldo insuficiente ?)");
                        else
                        if (ex.Message.Equals(ERR_CANTIDAD_NO_VALIDA))
                            MessageBox.Show("Cantidad no válida, sólo se admiten cantidades positivas.");
                    }
                }
                else
                {
                    try
                    {
                        realizarIngreso(cantidad);
                        MessageBox.Show("Transacción realizada.");
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Equals(ERR_CANTIDAD_NO_VALIDA))
                            MessageBox.Show("Cantidad no válida, sólo se admiten cantidades positivas.");
                    }
                    txtSaldo.Text = obtenerSaldo().ToString();

                }
            }
        }
    }
}
