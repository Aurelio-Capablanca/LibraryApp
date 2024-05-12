using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AppBibilioteca.Ayudante
{
    internal class Validador
    {

        private string mensaje;        
        private Regex patron;

        public string Mensaje{
            get { return mensaje; }
        }        

        private bool ValidadorGeneral(Regex patron, String valor, int maximo, bool esnulo)
        {
            if (!valor.Length.Equals(0))
            {
                bool coincide = patron.IsMatch(valor);
                if (valor.Length <= maximo)
                {
                    mensaje = coincide ? "Valido" : "El texto no coincide";
                    return coincide;
                }
                else
                {
                    mensaje = "La longitud del texto no esta permitida";
                    return false;
                }
            }
            else
            {
                mensaje = esnulo ? "El valor es nulo" : "El valor no puede ser nulo";
                return esnulo;
            }            
        }

        public bool ValidarAlfabeticos(String valor, int maximo, bool esnulo) {
            patron = new Regex(@"^[a-zA-ZÀ-ÖØ-öø-ÿ]+( [a-zA-ZÀ-ÖØ-öø-ÿ]+)*$");
            return ValidadorGeneral(patron,valor,maximo,esnulo);
        }

        public bool ValidarAlfanumericos(String valor, int maximo, bool esnulo)
        {
            patron = new Regex(@"^(?:[\p{L}\p{N}]+[\p{P}\p{M}]*\s*)+$");
            return ValidadorGeneral(patron, valor, maximo, esnulo);
        }

        public bool ValidarAlfanumericosConCaracteres(String valor, int maximo, bool esnulo)
        {
            patron = new Regex(@"^[A-Za-z0-9 !@#$%^&()_+\-=,.;:'""/?`~|[\]{}]+$");
            return ValidadorGeneral(patron, valor, maximo, esnulo);
        }

        public bool ValidarCorreos(String valor, int maximo, bool esnulo)
        {
            patron = new Regex(@"^[-a-z0-9~!$%^&*_=+}{'?]+(\.[-a-z0-9~!$%^&*_=+}{'?]+)*@([a-z0-9_][-a-z0-9_]*(\.[-a-z0-9_]+)*\.(aero|arpa|biz|com|coop|edu|gov|info|int|mil|museum|name|net|org|pro|travel|mobi|[a-z][a-z])|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(:[0-9]{1,5})?$");
            return ValidadorGeneral(patron, valor, maximo, esnulo);
        }


        public static int ValidarEnteros(string valor)
        {
            int num = -1;
            try
            {
                num = Int32.Parse(valor);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Error, dato no válido", "Error" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return num;
        }

    }
}
