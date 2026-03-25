-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE ObtenerVehiculo

	@Id uniqueIdentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   SELECT        Vehiculo.Id, Vehiculo.IdModelo, Vehiculo.Placa, Vehiculo.Color, Vehiculo.Anio, Vehiculo.Precio, Vehiculo.CorreoPropietarios, Vehiculo.TelefonoPropietario, Modelos.Nombre AS Modelo, Marcas.Nombre AS Marca
FROM            Marcas INNER JOIN
                         Modelos ON Marcas.id = Modelos.IdMarca INNER JOIN
                         Vehiculo ON Modelos.Id = Vehiculo.IdModelo
WHERE        (Vehiculo.Id = @Id)
END