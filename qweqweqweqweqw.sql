create database [Zooo];
go

use [Zooo];
go

create table [Position] (
	[Id] int identity primary key,
	[Value] nvarchar (25) not null,
	[IsDeleted] bit default 0 not null,
);
go

delete from Position where Id = 1

select * from Position

create table [UserData] (
	[Id]			int identity primary key,
	[PositionId]	int foreign key references [Position] ([Id]),
	[Name]			nvarchar (50) not null, 
	[MiddleName]	nvarchar (50) not null, 
	[LastName]		nvarchar (50) not null, 
	[Login]			nvarchar (50) not null, 
	[Password]		nvarchar (50) not null, 
	[IsDeleted]		bit default 0 not null,

);
go

create table [Aviary] (
	[Id] int identity primary key,
	[Width] float not null,
	[Height] float not null,
	[IsDeleted] bit default 0 not null,
);
go

create table [AnimalData] (
	[Id] int identity primary key,
	[Name] nvarchar (50) not null,
	[IsDeleted] bit default 0 not null,
	[Description] ntext,
);
go

create table [Feed] (
	[Id] int identity primary key,
	[Name] nvarchar (50) not null,
	[Description] ntext,
	[IsDeleted] bit default 0 not null,
);
go

create table [WorkShiftSchedule] (
	[Id] int identity primary key,
	[WorkDay] date not null,
	[Description] ntext,
	[IsDeleted] bit default 0 not null,
);
go

create table [SalaryCoeffiecient] (
	[Id]			int identity primary key,
	[MinSalaryValue] money not null,
	[Coeff]			decimal not null,
	[IsDeleted] bit default 0 not null,
);
go


create table [SalarOfEmployee] (
	[WorkShiftScheduleId] int foreign key references [WorkShiftSchedule]([Id]),
	[UserDataId] int foreign key references [UserData]([Id]),
	[SalaryCoeffiecientId] int foreign key references [SalaryCoeffiecient]([Id]),
	[IsDeleted] bit default 0 not null,
	primary key ([WorkShiftScheduleId], [UserDataId], [SalaryCoeffiecientId]),
);
go


create table [StoredOfFeed] (
	[Id] int identity primary key,
	[FeedId] int foreign key references [Feed]([Id]),
	[Count] int check ([Count] >= 0) not null,
	[Description] ntext,
	[IsDeleted] bit default 0 not null,

);
go

create table [FeedOfAnimal] (
	[AnimalId] int foreign key references [AnimalData]([Id]),
	[FeedId] int foreign key references [Feed]([Id]),
	[IsDeleted] bit default 0 not null,
	primary key ([AnimalId], [FeedId]),

);
go

create table [AnimalsInAvairy] (
	[AnimalId] int foreign key references [AnimalData]([Id]),
	[AvairyId] int foreign key references [Aviary]([Id]),
	[IsDeleted] bit default 0 not null,
	primary key ([AnimalId], [AvairyId])
);
go

create table [ResponsibleForAnimals] (
	[AnimalId] int foreign key references [AnimalData]([Id]),
	[ResponsibleId] int foreign key references [UserData]([Id]),
	[IsDeleted] bit default 0 not null,
	primary key ([AnimalId], [ResponsibleId])
);
go


--- triggers

create trigger [OnPositionDelete] 
	on Position instead of delete as
	update Position set IsDeleted = 1 where Id = (select Id from deleted); 
	go


-- procedures

create proc [DeleteFromPositionTable]
	@Id int, @a int
	as
begin
	update Position set IsDeleted = 0 where Id = @Id; 
end
go


create proc [AddNewUser]
	@name nvarchar (50),
	@middlename nvarchar (50),
	@lastname nvarchar (50),
	@login nvarchar (50),
	@passwd nvarchar (50),
	@position nvarchar (25)
	as
begin
	declare @idOfPosition int = (select Id from Position where [Value] = @position)
	insert into 
	UserData([Name], [MiddleName], [LastName], [Login], [Password], [PositionId])
	values (@name, @middlename, @lastname, @login, @passwd, @idOfPosition)
end
go
-- functions 
use [Zooo];
go

create function [dbo].[FindUserId] (@login nvarchar (50), @passwd nvarchar (50))
returns int
with execute as caller
as
begin
	declare @idOfUser int =
	(select [Id] from UserData where [Login] = @login and [Password] = @passwd)
	return (@idOfUser)
end
go
 select [dbo].[FindUserId] ('xiwaz','NTGFk6TS')

--- views

create view [UsersWithPosition] 
	as 
	select distinct ud.[Name], 
	       ud.[MiddleName]	as [Middle name], 
		   ud.[LastName]	as [Last name],
		   p.[Value]		as [Position]
 	from [UserData] as ud 
	join Position as p on ud.PositionId = p.Id;
go
