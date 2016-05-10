using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Persistencia
{
    public class Contato
    {
        private string arquivo = "c:\\temp\\agenda.xml";

        public void Insert(Modelo.Contato c)
        {
            List<Modelo.Contato> agenda = AbrirArquivo();
            agenda.Add(c);
            SalvarArquivo(agenda);
        }

        public List<Modelo.Contato> Select()
        {
            return AbrirArquivo();
        }
        private List<Modelo.Contato> AbrirArquivo()
        {
            List<Modelo.Contato> result = null;
            {
                try
                {
                    using (StreamReader sr = new StreamReader(arquivo))
                    {
                        XmlSerializer xml = new XmlSerializer(typeof(List<Modelo.Contato>));
                        result = (List<Modelo.Contato>)xml.Deserialize(sr);
                    }
                }
                catch
                {
                    result = new List<Modelo.Contato>();
                }
            }          
            return result;
        }
        private void SalvarArquivo(List<Modelo.Contato> agenda)
        {
            using (StreamWriter sw = new StreamWriter(arquivo))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Modelo.Contato>));
                xml.Serialize(sw, agenda);
            }          
        }
    }
}
