create database Organizer;

use Organizer;

create table Korisnik(
	id int identity(1, 1) primary key,
	username varchar(32) not null
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