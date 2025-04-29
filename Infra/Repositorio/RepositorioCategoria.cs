using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.ICategoria;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RepositorioCategoria : RepositoryGenerics<Categoria>, InterfaceCategoria
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;
        
        public RepositorioCategoria()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public Task<object> AtualizarCategoria(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Categoria>> ListarCategoriaUsuarios(string emailUsuario)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return  await

                    (from s in banco.SistemaFinanceiro
                    join c in banco.Categoria on s.Id equals c.IdSistema
                    join us in banco.UsuarioSistemaFinanceiro on s.Id equals us.IdSistema
                    where us.EmailUsuario.Equals(emailUsuario) && us.SistemaAtual
                    select c).AsNoTracking().ToListAsync();
            }
        }
    }
}
