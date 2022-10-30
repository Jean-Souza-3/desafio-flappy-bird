using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace FLAPPY_BIRD
{
    class Registro
    {
        public static void Gravar(
            string caminho, string parametro,
            string valor)
        {
            RegistryKey Key = Registry.CurrentUser.CreateSubKey(caminho);
            Key.SetValue(parametro, valor);
        }

        public static string Ler(
            string caminho, string parametro)
        {
            RegistryKey Key = Registry.CurrentUser.OpenSubKey(caminho);
            try
            {
                if (Key != null)
                {
                    return Key.GetValue(parametro).ToString();
                }
                else return "0";
            }
            catch (Exception)
            {

                return "0";
            }
        }
    }
}
