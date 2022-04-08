create database Organizer;

use Organizer;

create table Korisnik(
	id int identity(1, 1) primary key,
	username varchar(32) not null unique
);

insert into Korisnik(username) values ('dragomir');

create table Projekat(
	id int identity(1, 1) primary key,
	naziv varchar(32) not null,
	opis varchar(512),
	pocetak datetime not null,
	kraj datetime,
	ocekivaniKraj datetime
);

insert into Projekat(naziv, opis, pocetak) values ('organizer', 'Aplikacija koja prati razvitak razlicitih projekata', '2022-04-08');

create table Clanstvo (
	id int identity(1, 1) primary key,
	projekat int not null,
	korisnik int not null,
	ovlascenja int not null check (ovlascenja >= 0 and ovlascenja < 3) -- Ovlascenje 2 je vlasnik, 1 je bitan ucesnik, a 0 je obican smrtnik.
	foreign key (projekat) references Projekat(id),
	foreign key (korisnik) references Korisnik(id),
);

insert into Clanstvo(projekat, korisnik, ovlascenja) values (1, 1, 2);

go

create function ValidateLogin (@username varchar(32))
returns int as
begin
declare @cnt int;

set @cnt = (select COUNT(*) from Korisnik where username = @username);

return abs(@cnt - 1);

end;

go

create proc Register
@username varchar(32) as
begin try
	insert into Korisnik(username) values (@username);
	return 0;
end try
begin catch
	return 1;
end catch;