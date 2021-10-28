use inlock_games_tarde;
go

insert into Tipo(titulo)
values ('Administrador'), ('Cliente');
go

insert into Usuario (idTipo, email, senha)
values (1, 'admin@admin.com', 'admin'), (2,'cliente@cliente.com','cliente');
go

insert into Estudio (nomeEstudio)
values ('Blizzard'),('Rockstar Studio'), ('Square Enix');
go

insert into Jogo (idEstudio 