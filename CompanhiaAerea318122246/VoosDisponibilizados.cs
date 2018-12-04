using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanhiaAerea.Listas;

namespace CompanhiaAerea318122246
{
    public class VoosDisponibilizados
    {
        public void VoosExistentes()
        {
            List<Voo> ViagensDisponiveis = new List<Voo>()
            {
                new Voo {NumeroVoo = 1, Horario = new DateTime(2019, 1, 1, 13, 00, 00), Destino = "BH/Rio"},
                new Voo {NumeroVoo = 2, Horario = new DateTime(2019, 1, 1, 13, 30, 00), Destino = "BH/SP" },
                new Voo {NumeroVoo = 2, Horario = new DateTime(2019, 1, 1, 14, 00, 00), Destino = "BH/Recife"}
            };
        }
    }
}
