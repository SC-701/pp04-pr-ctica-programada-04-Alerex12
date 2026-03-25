-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE EditarVehiculo

	@Id AS uniqueidentifier
,@IdModelo AS uniqueidentifier
,@Placa AS varchar(max)
,@Color AS varchar(max)
,@Anio AS int
,@Precio AS decimal(18,0)
,@CorreoPropietarios AS varchar(max)
,@TelefonoPropietario AS varchar(max)
AS
BEGIN
	SET NOCOUNT ON

	BEGIN TRANSACTION
		UPDATE [dbo].[Vehiculo]
	   SET [IdModelo] = @IdModelo
		  ,[Placa] = @Placa
		  ,[Color] = @Color
		  ,[Anio] = @Anio
		  ,[Precio] = @Precio
		  ,[CorreoPropietarios] = @CorreoPropietarios
		  ,[TelefonoPropietario] = @TelefonoPropietario
	 WHERE Id = @Id
	 Select @Id

	COMMIT TRANSACTION
END