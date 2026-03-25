-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE EliminarVehiculo

	@Id uniqueIdentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	BEGIN TRANSACTION

	DELETE 
	FROM            
							 Vehiculo
	WHERE        (Id = @Id)

	Select @Id

	COMMIT TRANSACTION
END