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
