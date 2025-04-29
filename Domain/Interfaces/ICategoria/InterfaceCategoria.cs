using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.Generics;
using Entities.Entidades;

namespace Domain.Interfaces.ICategoria
{
    public interface InterfaceCategoria : InterfaceGenerica<Categoria>
    {
        Task<object> AtualizarCategoria(Categoria categoria);
        Task<IList<Categoria>> ListarCategoriaUsuarios(string emailUsuario);
    }
}
