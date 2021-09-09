

CREATE TABLE dbo.Account (
  Username varchar(50) NOT NULL,
  Password varchar(50) NULL,
  PhoneNumber varchar(30) NULL,
  FullName nvarchar(50) NULL,
  Email varchar(50) NULL,
  IsAdmin bit not null
  CONSTRAINT PK_User_EMAIL PRIMARY KEY CLUSTERED (Username)
)
ON [PRIMARY]
GO

CREATE TABLE dbo.BookingDetail (
  Username varchar(50) NOT NULL,
  IdHotel int NOT NULL,
  RoomReserveTime date NOT NULL,
  PaymentTime date NOT NULL,
  PeopleAmount int NULL,
  RoomAmount int NULL,
  PhoneNumber varchar(30) NULL,
  ListIdRoomSelected varchar(50) NOT NULL
)
ON [PRIMARY]
GO


CREATE TABLE dbo.City (
  IdCity int IDENTITY,
  CityName nvarchar(50) NULL,
  CityImage varchar(50) NULL,
  CONSTRAINT PK_City PRIMARY KEY CLUSTERED (IdCity)
)
ON [PRIMARY]
GO

CREATE TABLE dbo.Comment(
  IdComment	int IDENTITY,
  Username varchar(50) NULL,
  Comment nvarchar(4000) NULL,
  CommentDate date NULL,
  IdHotel int NULL
  CONSTRAINT PK_Comment PRIMARY KEY CLUSTERED (IdComment)
)
ON [PRIMARY]
GO

CREATE TABLE dbo.Room (
  IdRoom int IDENTITY,
  RoomName nvarchar(50) NULL,
  Price int NULL,
  RoomService nvarchar(4000) NULL,
  IsCheck bit NULL,
  RoomInformation nvarchar(4000) NULL,
  RoomIntroduce nvarchar(4000) NULL,
  IdHotel int NULL,
  MaxPerson int NULL,
  CONSTRAINT PK_Room PRIMARY KEY CLUSTERED (IdRoom)
)
ON [PRIMARY]
GO


CREATE TABLE dbo.Hotel (
  IdHotel int IDENTITY,
  IdCity int NOT NULL,
  HotelName nvarchar(50) NULL,
  Evaluate varchar(50) NULL,
  Distance varchar(50) NULL,
  HotelAddress nvarchar(500) NULL,
  HotelIntroduce nvarchar(4000) NULL,
  CoverImage varchar(50) NULL,
  Image1 varchar(50) NULL,
  Image2 varchar(50) NULL,
  Image3 varchar(50) NULL,
  Image4 varchar(50) NULL,
  Image5 varchar(50) NULL,
  Image6 varchar(50) NULL,
  Image7 varchar(50) NULL,
  Image8 varchar(50) NULL,
  CONSTRAINT PK_Hotel PRIMARY KEY CLUSTERED (IdHotel)
)
ON [PRIMARY]
GO

ALTER TABLE dbo.BookingDetail
  ADD CONSTRAINT FK_BookingDetail_Account FOREIGN KEY (Username) REFERENCES dbo.Account (Username)
GO

ALTER TABLE dbo.BookingDetail
  ADD CONSTRAINT FK_BookingDetail_Hotel FOREIGN KEY (IdHotel) REFERENCES dbo.Hotel (IdHotel)
GO


ALTER TABLE dbo.Comment
  ADD CONSTRAINT FK_Comment_Account FOREIGN KEY (Username) REFERENCES dbo.Account (Username)
GO

ALTER TABLE dbo.Comment
  ADD CONSTRAINT FK_Comment_Hotel FOREIGN KEY (IdHotel) REFERENCES dbo.Hotel (IdHotel)
GO

ALTER TABLE dbo.Hotel
  ADD CONSTRAINT FK_Hotel_City FOREIGN KEY (IdCity) REFERENCES dbo.City (IdCity)
GO


ALTER TABLE dbo.Room
  ADD CONSTRAINT FK_Room_Hotel FOREIGN KEY (IdHotel) REFERENCES dbo.Hotel (IdHotel)
GO

