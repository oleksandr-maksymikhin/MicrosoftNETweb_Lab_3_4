use MovieTicketLab;


select * from Movies;
select * from Tickets;

insert into Movies (Title, Director, Genre, Poster, [Date]) values ('Avatar', 'James Cameron', 'Fantasy', NULL, '2023-03-03');
insert into Movies (Title, Director, Genre, Poster, [Date]) values ('Interstellar', 'Christopher Nolan', 'Fantasy', NULL, '2023-01-01');
insert into Movies (Title, Director, Genre, Poster, [Date]) values ('Matrix', 'Wachowskis', 'Action', NULL, '2023-02-28');
insert into Movies (Title, Director, Genre, Poster, [Date]) values ('Terminator', 'James Cameron', 'Action', NULL, '2023-01-05');
insert into Movies (Title, Director, Genre, Poster, [Date]) values ('Troy', 'Wolfgang Petersen', 'Mystery', NULL, '2023-02-10');
insert into Movies (Title, Director, Genre, Poster, [Date]) values ('Gladiator', 'Ridley Scott', 'History', NULL, '2023-03-03');
insert into Movies (Title, Director, Genre, Poster, [Date]) values ('Titanic', 'James Cameron', 'Mystery', NULL, '2023-01-05');
insert into Movies (Title, Director, Genre, Poster, [Date]) values ('Pirates of the Caribbean', 'Gore Verbinski', 'Commedy', NULL, '2023-02-28');
insert into Movies (Title, Director, Genre, Poster, [Date]) values ('Star Wars', 'George Lucas', 'Fantasy', NULL, '2023-03-03');
insert into Movies (Title, Director, Genre, Poster, [Date]) values ('Forrest Gamp', 'Robert Zemeckis', 'Commedy', NULL, '2023-01-01');


delete from Tickets
where id > 200;

insert into Tickets (Price, [Status], [Row], Seat, MovieId) values (600, 'open', 1, 1, 101);
insert into Tickets (Price, [Status], [Row], Seat, MovieId) values (600, 'open', 1, 2, 101);
insert into Tickets (Price, [Status], [Row], Seat, MovieId) values (600, 'open', 1, 3, 101);
insert into Tickets (Price, [Status], [Row], Seat, MovieId) values (600, 'open', 1, 4, 101);
insert into Tickets (Price, [Status], [Row], Seat, MovieId) values (600, 'open', 1, 5, 101);
insert into Tickets (Price, [Status], [Row], Seat, MovieId) values (600, 'open', 2, 1, 101);
insert into Tickets (Price, [Status], [Row], Seat, MovieId) values (600, 'open', 2, 2, 101);
insert into Tickets (Price, [Status], [Row], Seat, MovieId) values (600, 'open', 2, 3, 101);
insert into Tickets (Price, [Status], [Row], Seat, MovieId) values (600, 'open', 2, 4, 101);
insert into Tickets (Price, [Status], [Row], Seat, MovieId) values (600, 'open', 2, 5, 101);

update Tickets set [Status] = 'open' where [Row] = 1 and Seat = 1;
update Tickets set [Status] = 'sold' where [Row] = 1 and Seat = 2;
update Tickets set [Status] = 'booked' where [Row] = 1 and Seat = 3;

TRUNCATE TABLE Tickets;
DROP TABLE Tickets;

ALTER TABLE Tickets
ADD SalePrice decimal(18, 2);