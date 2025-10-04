using AvukatProLib.GlobalResource;
using Microsoft.Win32;
using System.Reflection;

namespace AvukatProLib.Util
{
    public class Metot
    {
        public void AcilisKontrolu(bool evetMi, string programIsmi)
        {
            if (evetMi == true)
            {
                Registry.SetValue(Stringler.LocalAdres, programIsmi, string.Empty);
                Assembly assembley = Assembly.GetExecutingAssembly();
                Registry.SetValue(Stringler.LocalAdres, programIsmi, assembley.Location);
            }
            else
            {
                Registry.LocalMachine.DeleteValue(programIsmi);
            }
        }
    }
}