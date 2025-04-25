using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Entidades;

namespace Domain.Interfaces.InterfaceServicos
{
    public interface IDespesaServico
    {
        Task AdicionarDespesa(Despesa despesa);

        Task AtualizarDespesa(Despesa despesa);
    }
}
