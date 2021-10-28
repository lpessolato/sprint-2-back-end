Create database inlock_games_tarde;
go

use inlock_games_tarde;
go

Create table Estudio(
idEstudio tinyint primary key identity (1,1),
nomeEstudio varchar (50) not null,
);
go

Create table Jogo(
idJogo tinyint primary key identity(1,1),
idEstudio tinyint foreign key references Estudio(idEstudio),
nomeJogo varchar (100) not null,
descricao varchar (100) not null,
dataLancamento datetime not null default getdate(),
valor varchar (10) not null,
);
go

Create table Tipo(
idTipo tinyint primary key identity (1,1),
titulo varchar (30) not null,
);
go

Create table Usuario(
idUsuario tinyint primary key identity (1,1),
idTipo tinyint foreign key references Tipo(idTipo),
email varchar (100) not null,
senha varchar (30) not null,
);
go


