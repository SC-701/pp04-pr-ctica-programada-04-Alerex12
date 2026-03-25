using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flujo
{
    public class ModeloFlujo : IModeloFlujo
    {
        private IModeloDA _modeloDA;

        public ModeloFlujo(IModeloDA modeloDA)
        {
            _modeloDA = modeloDA;
        }

        public async Task<IEnumerable<Modelo>> Obtener(Guid IdMarca)
        {
            return await _modeloDA.Obtener(IdMarca);
        }
    }
}
