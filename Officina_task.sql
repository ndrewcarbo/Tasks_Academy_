CREATE TABLE Cliente (
	clienteID INT PRIMARY KEY IDENTITY(1,1),
	codice CHAR(36) NOT NULL DEFAULT NEWID() UNIQUE,
	nome VARCHAR(250) NOT NULL,
	cognome VARCHAR(250) NOT NULL,
	email VARCHAR(250),
	indirizzo VARCHAR(250),
	telefono VARCHAR(250)
);

CREATE TABLE Intervento (
	interventoID INT PRIMARY KEY IDENTITY(1,1),
	codice CHAR(36) NOT NULL DEFAULT NEWID() UNIQUE,
	targa VARCHAR(50) NOT NULL,
	modello VARCHAR(50) NOT NULL,
	marca VARCHAR(50) NOT NULL,
	anno INT,
	prezzo DECIMAL(10,2) CHECK (prezzo >= 0),
	stato VARCHAR(50) CHECK (stato IN ('in corso','completato','da fare')),
	data_start DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
	clienteRIF INT NOT NULL,
	FOREIGN KEY (clienteRIF) REFERENCES Cliente(clienteID) ON DELETE CASCADE
);

-- Inserimento di 10 clienti
INSERT INTO Cliente (nome, cognome, email, indirizzo, telefono)
VALUES 
('Mario', 'Rossi', 'mario.rossi@example.com', 'Via Roma 1, Milano', '3291234567'),
('Luigi', 'Bianchi', 'luigi.bianchi@example.com', 'Corso Italia 22, Roma', '3487654321'),
('Anna', 'Verdi', 'anna.verdi@example.com', 'Via Torino 5, Torino', '3209876543'),
('Giulia', 'Ferrari', 'giulia.ferrari@example.com', 'Viale Marconi 7, Napoli', '3339876543'),
('Marco', 'Esposito', 'marco.esposito@example.com', 'Via Dante 3, Palermo', '3311239876'),
('Paolo', 'Neri', 'paolo.neri@example.com', 'Via Garibaldi 10, Firenze', '3409876543'),
('Francesca', 'Ricci', 'francesca.ricci@example.com', 'Piazza San Marco 2, Venezia', '3501234567'),
('Luca', 'Galli', 'luca.galli@example.com', 'Via Manzoni 8, Bologna', '3709876543'),
('Sara', 'Costa', 'sara.costa@example.com', 'Via Verdi 12, Genova', '3498765432'),
('Elena', 'Colombo', 'elena.colombo@example.com', 'Via Milano 15, Bari', '3512345678');


-- Inserimento di 10 interventi
INSERT INTO Intervento (targa, modello, marca, anno, prezzo, stato, clienteRIF)
VALUES 
('AB123CD', 'Panda', 'Fiat', 2015, 350.00, 'in corso', 1),
('EF456GH', 'Golf', 'Volkswagen', 2018, 450.00, 'completato', 2),
('IJ789KL', 'Clio', 'Renault', 2019, 500.00, 'da fare', 3),
('MN012OP', 'Model 3', 'Tesla', 2021, 1000.00, 'in corso', 4),
('QR345ST', 'Civic', 'Honda', 2017, 400.00, 'completato', 5),
('UV678WX', 'Astra', 'Opel', 2016, 350.00, 'da fare', 6),
('YZ901AB', '500X', 'Fiat', 2019, 550.00, 'in corso', 7),
('CD234EF', 'A3', 'Audi', 2018, 600.00, 'completato', 8),
('GH567IJ', 'Corsa', 'Opel', 2020, 450.00, 'da fare', 9),
('KL890MN', 'Yaris', 'Toyota', 2022, 800.00, 'in corso', 10);


SELECT * FROM Cliente
	JOIN Intervento ON Cliente.clienteID = Intervento.clienteRIF;
