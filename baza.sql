create table vrstaPica (
	vrstaPicaID int primary key identity(1,1) not null,
	ime nvarchar(30) not null,
)

insert into vrstaPica (ime) values ('Pivo')
insert into vrstaPica (ime) values ('Viski')
insert into vrstaPica (ime) values ('Vodka')
insert into vrstaPica (ime) values ('Tekila')
insert into vrstaPica (ime) values ('Sok')
insert into vrstaPica (ime) values ('Gazirani sok')
insert into vrstaPica (ime) values ('Voda')
insert into vrstaPica (ime) values ('Rakija')

create table diskont (
	diskontID int primary key identity(1,1) not null,
	ime nvarchar(50) not null,
	mesto nvarchar(50) not null,
)

create table pice (
	piceID int primary key not null identity(1,1),
	ime nvarchar(30) not null,
	imeVrste nvarchar(50) not null,
)
