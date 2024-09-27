CREATE TABLE Utente(
	utenteID INT PRIMARY KEY IDENTITY(1,1),
	codice VARCHAR(250) DEFAULT NEWID(), 
	nome VARCHAR(250) NOT NULL,
	cognome VARCHAR (250) NOT NULL,
	email VARCHAR(250) NOT NULL,
);

CREATE TABLE Libro(
	libroID INT PRIMARY KEY IDENTITY(1,1),
	codice VARCHAR(250) DEFAULT NEWID(), 
	titolo VARCHAR(250) NOT NULL,
	anno_pub DATE NOT NULL,
	disponibilita BIT DEFAULT 1
);

CREATE TABLE Prestito(
	prestitoID INT PRIMARY KEY IDENTITY(1,1),
	codice VARCHAR(250) DEFAULT NEWID(), 
	data_start DATE NOT NULL,
	data_return DATE NOT NULL,
	utenteRIF INT NOT NULL,
	libroRIF INT NOT NULL,
	FOREIGN KEY (utenteRIF) REFERENCES Utente(utenteID) ON DELETE CASCADE,
	FOREIGN KEY (libroRIF) REFERENCES Libro(libroID) ON DELETE CASCADE,
	UNIQUE (utenteRIF,libroRIF)
);

INSERT INTO Utente (nome, cognome, email)
VALUES 
('Mario', 'Rossi', 'mario.rossi@example.com'),
('Luigi', 'Bianchi', 'luigi.bianchi@example.com'),
('Giovanni', 'Verdi', 'giovanni.verdi@example.com'),
('Francesco', 'Neri', 'francesco.neri@example.com'),
('Andrea', 'Gialli', 'andrea.gialli@example.com'),
('Marco', 'Blu', 'marco.blu@example.com'),
('Paolo', 'Rossa', 'paolo.rossa@example.com'),
('Simone', 'Viola', 'simone.viola@example.com'),
('Lorenzo', 'Arancio', 'lorenzo.arancio@example.com'),
('Davide', 'Giallo', 'davide.giallo@example.com');


INSERT INTO Libro (titolo, anno_pub, disponibilita)
VALUES 
('Il Signore degli Anelli', '1954-07-29', 1),
('Il Nome della Rosa', '1980-03-04', 1),
('Il Codice da Vinci', '2003-03-18', 1),
('La Divina Commedia', '1320-01-01', 1),
('I Promessi Sposi', '1840-06-01', 1),
('Il Conte di Montecristo', '1844-08-01', 1),
('Orgoglio e Pregiudizio', '1813-01-28', 1),
('La Bella e la Bestia', '1740-01-01', 1),
('Il Gatto con gli Stivali', '1697-01-01', 1),
('Cenerentola', '1697-01-01', 1);


INSERT INTO Prestito (data_start, data_return, utenteRIF, libroRIF)
VALUES 
('2022-01-01', '2022-01-31', 1, 1),
('2022-02-01', '2022-02-28', 2, 2),
('2022-03-01', '2022-03-31', 3, 3),
('2022-04-01', '2022-04-30', 4, 4),
('2022-05-01', '2022-05-31', 5, 5),
('2022-06-01', '2022-06-30', 6, 6),
('2022-07-01', '2022-07-31', 7, 7),
('2022-08-01', '2022-08-31', 8, 8),
('2022-09-01', '2022-09-30', 9, 9),
('2022-10-01', '2022-10-31', 10, 10);

