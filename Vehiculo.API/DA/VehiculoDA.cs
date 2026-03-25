using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class VehiculoDA : IVehiculoDA
    {

        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        #region Constructor

        public VehiculoDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }
        #endregion


        #region Operaciones
        public async Task<Guid> Agregar(VehiculoRequest vehiculo)
        {
            string query = @"AgregarVehiculo";
            var resultQuery = await
                                _sqlConnection.ExecuteScalarAsync<Guid>(query, new {
                                    Id = Guid.NewGuid(),
                                    IdModelo = vehiculo.IdModelo,
                                    Placa = vehiculo.Placa,
                                    Color = vehiculo.Color,
                                    Anio = vehiculo.Anio,
                                    Precio = vehiculo.Precio,
                                    CorreoPropietarios = vehiculo.CorreoPropietarios,
                                    TelefonoPropietario = vehiculo.TelefonoPropietario
                                }); //ExecuteScalarAsync INDICAMOS QUE ESPERAMOS UN VALOR DE RETORNO DEL QUERY

            return resultQuery;
        }

        public async Task<Guid> Editar(Guid Id, VehiculoRequest vehiculo)
        {
            await verificarVehiculoExiste(Id);
            string query = @"EditarVehiculo";

            var resultQuery = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
                                {
                                    Id = Id,
                                    IdModelo = vehiculo.IdModelo,
                                    Placa = vehiculo.Placa,
                                    Color = vehiculo.Color,
                                    Anio = vehiculo.Anio,
                                    Precio = vehiculo.Precio,
                                    CorreoPropietarios = vehiculo.CorreoPropietarios,
                                    TelefonoPropietario = vehiculo.TelefonoPropietario
                                }); //ExecuteScalarAsync INDICAMOS QUE ESPERAMOS UN VALOR DE RETORNO DEL QUERY

            return resultQuery;

        }


        public async Task<Guid> Eliminar(Guid Id)
        {
            await verificarVehiculoExiste(Id);

            string query = @"EliminarVehiculo";
            var resultQuery = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new{ Id = Id });

            return resultQuery;
        }

        public async Task<IEnumerable<VehiculoResponse>> Obtener()
        {
            string query = @"ObtenerVehiculos";
            var resultQuery = await  _sqlConnection.QueryAsync<VehiculoResponse>(query);
            return resultQuery;
        }

        public async Task<VehiculoDetalle> Obtener(Guid Id)
        {
            string query = @"ObtenerVehiculo";
            var resultQuery = await _sqlConnection.QueryAsync<VehiculoDetalle>(query, new { Id });
            return resultQuery.FirstOrDefault();

        }
        #endregion

        private async Task verificarVehiculoExiste(Guid Id)
        {
            VehiculoResponse? resultadoConsultaVehiculo = await Obtener(Id);
            if (resultadoConsultaVehiculo == null)
                throw new Exception("No se encontro el vehiculo");

        }
    }
}
