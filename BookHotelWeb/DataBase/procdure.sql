CREATE PROCEDURE GetCities
AS
BEGIN
  SELECT *
  FROM City
END
GO


CREATE PROCEDURE GetHotels
AS
BEGIN
  SELECT *
  FROM Hotel
END
GO

CREATE PROCEDURE GetRooms
AS
BEGIN
  SELECT *
  FROM Room
END
GO

CREATE PROCEDURE GetAccounts
AS
BEGIN
  SELECT *
  FROM Account
END
GO

CREATE PROCEDURE GetBookingDetails
AS
BEGIN
  SELECT *
  FROM BookingDetail
END
GO

--GetRooms


CREATE PROCEDURE Proc_GetRoomAmount
AS
BEGIN
select count(IdRoom) from Room group by Room.IdHotel
END
GO
--Proc_GetRoomAmount

CREATE PROCEDURE Proc_GetDistance
AS
BEGIN
	select Distance from Hotel
END
GO
--Proc_GetDistance
 GO
CREATE PROCEDURE Proc_GetHotelCheapPrice
AS
BEGIN
	select * from Hotel,Room where Room.IdHotel = Hotel.IdHotel and Price <= 1200000 
END
GO
Proc_GetHotelCheapPrice



CREATE PROCEDURE Proc_GetIdHotelByIdRoom
@idRoom int
as
BEGIN
	select IdHotel from Room where IdRoom = @idRoom
END
GO


CREATE PROCEDURE Proc_GetHotelById
@idHotel int
as
BEGIN
	select * from Hotel where IdHotel = @idHotel
END
GO

CREATE PROCEDURE Proc_GetPricesHotel
@idHotel int
as
BEGIN
	select Price from Room where IdHotel = @idHotel
END
GO

Create Proc checktime1
@ngayvao datetime,
@ngayra datetime,
@idroom int
as
begin
	if EXISTS( select * from BookingDetail where ListIdRoomSelected = @idroom)
			if EXISTS( select * from BookingDetail where @ngayvao BETWEEN RoomReserveTime AND PaymentTime or  @ngayra BETWEEN RoomReserveTime  AND PaymentTime)
				SELECT 1;
			ELSE
				SELECT 0;
	ELSE
		SELECT 0;
		
end
go
