using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Contato
    {
        public void Insert(Modelo.Contato c)
        {
            //Validar Contato - ID e nome vazio
            List<Modelo.Contato> agenda = Select();

            if (!(agenda.Exists(a => a.Id == c.Id)) && c.nome != "" && c.fone != "")
            {
                (new Persistencia.Contato()).Insert(c);
            }
        }

        public List<Modelo.Contato> Select()
        {
            return (new Persistencia.Contato()).Select();
        }
    }
}
