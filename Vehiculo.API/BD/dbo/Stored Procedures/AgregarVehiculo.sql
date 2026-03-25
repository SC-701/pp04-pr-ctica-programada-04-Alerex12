-- =============================================
-- Author:		ALEJANDRO MUÑOZ VINDAS
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE AgregarVehiculo

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
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
		
		BEGIN TRANSACTION
		INSERT INTO [dbo].[Vehiculo]
           ([Id]
           ,[IdModelo]
           ,[Placa]
           ,[Color]
           ,[Anio]
           ,[Precio]
           ,[CorreoPropietarios]
           ,[TelefonoPropietario])
     VALUES
           (@Id 
			,@IdModelo 
			,@Placa 
			,@Color 
			,@Anio 
			,@Precio 
			,@CorreoPropietarios 
			,@TelefonoPropietario )

	SELECT @Id 
	COMMIT TRANSACTION
END