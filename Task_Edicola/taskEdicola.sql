 /*

 * Creare un sistema di gestione edicola.

 * In un'edicola sono presenti riviste e giocattoli.

 * Entrambi sono caratterizzati da un codice univoco (assegnato automaticamente all'inserimento nel DB) ed il prezzo.

 * 

 * Un gicattolo è caratterizzato almeno da:

 * - materiale

 * - età minima

 * 

 * La rivista è caratterizzata

 * - titolo

 * - casa editrice

 * 

 * Creare un sistema che si occupi di:

 * 1. Inserire riviste o giocattoli

 * 2. Stampare tutti i prodotti

 * 3. Stampare solo le riviste (con LINQ)

 * 4. Stampare solo i giocattoli (con LINQ)

 * 5. Conta tutti gli elementi (con LINQ)

 * 5. Cercare un elemento e stamparne i dettagli tramite il codice univoco.

 */


 CREATE TABLE Giocattolo(
	giocattoloID INT PRIMARY KEY IDENTITY(1,1),
	codiceAbarre CHAR(10) NOT NULL UNIQUE,
	nome VARCHAR(250) NOT NULL,
	materiale VARCHAR(250) NOT NULL,
	prezzo DECIMAL(5,2) NOT NULL,
	eta_min INT NOT NULL
 );

 CREATE TABLE Rivista(
	rivistaID INT PRIMARY KEY IDENTITY(1,1),
	codiceAbarre CHAR(10) NOT NULL UNIQUE,
	titolo VARCHAR(250) NOT NULL,
	prezzo DECIMAL(5,2) NOT NULL,
	casaEditrice VARCHAR(250) NOT NULL
 );

 INSERT INTO Giocattolo (codiceAbarre, nome, materiale, prezzo, eta_min) VALUES
('1234567890', 'Macchinina', 'Plastica', 9.99, 3),
('0987654321', 'Bambola', 'Tessuto', 14.99, 4),
('1122334455', 'Puzzle', 'Legno', 7.50, 5),
('2233445566', 'Pallone', 'Gomma', 12.00, 6),
('3344556677', 'Treno', 'Metallo', 19.99, 3),
('4455667788', 'Orsetto', 'Peluche', 8.99, 2),
('5566778899', 'Gioco da tavolo', 'Cartone', 24.99, 8),
('6677889900', 'Costruzioni', 'Plastica', 29.99, 5),
('7788990011', 'Bicicletta', 'Metallo', 49.99, 7),
('8899001122', 'Gioco educativo', 'Legno', 15.99, 4);

INSERT INTO Rivista (codiceAbarre, titolo, prezzo, casaEditrice) VALUES
('1111111111', 'Scienza e Natura', 5.99, 'Editore A'),
('2222222222', 'Moda e Stile', 7.50, 'Editore B'),
('3333333333', 'Tecnologia Oggi', 6.99, 'Editore C'),
('4444444444', 'Viaggi e Avventure', 8.99, 'Editore D'),
('5555555555', 'Cucina Gourmet', 4.99, 'Editore E'),
('6666666666', 'Fitness e Salute', 5.50, 'Editore F'),
('7777777777', 'Arte e Cultura', 9.99, 'Editore G'),
('8888888888', 'Fotografia', 6.50, 'Editore H'),
('9999999999', 'Giardinaggio', 7.99, 'Editore I'),
('0000000000', 'Storia e Misteri', 8.50, 'Editore J');


SELECT * FROM Giocattolo;

SELECT * FROM Rivista;