--ogettazione e realizzazione:


/*Il centro fitness "Energia Pura" sta cercando di sviluppare un sistema per migliorare e digitalizzare la gestione delle sue attività quotidiane. 
Il sistema dovrebbe coprire vari aspetti, tra cui la gestione dei membri, la programmazione delle classi, la gestione degli istruttori e delle attrezzature, e il monitoraggio dei progressi dei membri.
Ogni membro del centro fitness è registrato nel sistema con un ID unico, nome, cognome, data di nascita, sesso, indirizzo email, numero di telefono, e la data di inizio dell'abbonamento.

I membri possono scegliere tra diversi tipi di abbonamenti (ad esempio, mensile, trimestrale, annuale) che differiscono per durata e prezzo.


Le classi di fitness, come yoga, pilates, spinning e sollevamento pesi, sono un elemento chiave dell'offerta del centro.
Ogni classe è caratterizzata da un ID unico, nome, descrizione, orario, giorno della settimana e numero massimo di partecipanti.

Inoltre, ogni classe è associata a uno specifico istruttore.
Gli istruttori sono impiegati dal centro fitness e sono registrati nel sistema con dettagli quali ID, nome, cognome, specializzazione, e orari di lavoro. 

Ogni istruttore può condurre diverse classi, ma una classe può essere condotta da un solo istruttore per volta.


Il sistema deve anche gestire le prenotazioni delle classi effettuate dai membri. Una prenotazione collega un membro a una specifica classe e ne registra la data e l'ora. Il sistema dovrebbe consentire ai membri di prenotare le classi online e cancellare le prenotazioni se necessario.
Inoltre, il centro fitness dispone di diverse attrezzature, come tapis roulant, biciclette da spinning e pesi liberi. 

Ogni attrezzatura è catalogata nel sistema con un ID univoco, una descrizione, una data di acquisto e uno stato (ad esempio, disponibile, in manutenzione, fuori servizio).



Si richiede di progettare uno schema ER per questo sistema e la relativa traduzione in SQL.
Alla fine della traduzione in SQL inserisci dei dati di esempio ed effettua:

1.	Query base: Recupera tutti i membri registrati nel sistema.

2.	Recupera il nome e il cognome di tutti i membri che hanno un abbonamento mensile.

3.	Recupera l'elenco delle classi di yoga offerte dal centro fitness.

4.	Recupera il nome e cognome degli istruttori che insegnano Pilates.

5.	Recupera i dettagli delle classi programmate per il lunedì.

6.	Recupera l'elenco dei membri che hanno prenotato una classe di spinning.

7.	Recupera tutte le attrezzature che sono attualmente fuori servizio.

8.	Conta il numero di partecipanti per ciascuna classe programmata per il mercoledì.

9.	Recupera l'elenco degli istruttori disponibili per tenere una lezione il sabato.

10.	Recupera tutti i membri che hanno un abbonamento attivo dal 2023.

*/



CREATE TABLE Membro(
 membroID  INT PRIMARY KEY IDENTITY (1,1),
 nome VARCHAR(250) NOT NULL,
 cognome VARCHAR(250)NOT NULL,
 data_nas DATE NOT NULL,
 sesso VARCHAR(250) NOT NULL,
 email VARCHAR(250) NOT NULL,
 telefono INT NOT NULL
);

CREATE TABLE Istruttore(
 istruttoreID  INT PRIMARY KEY IDENTITY (1,1),
 nome VARCHAR(250) NOT NULL,
 cognome VARCHAR(250)NOT NULL,
 specializzazione VARCHAR(250) NOT NULL CHECK (specializzazione IN ('yoga', 'pilates', 'spinning','pesi')),
 orario TIME NOT NULL,
 disponibilita VARCHAR(250)
);



CREATE TABLE Classe(
 classeID  INT PRIMARY KEY IDENTITY (1,1),
 tipo VARCHAR(250)NOT NULL CHECK (tipo IN ('yoga', 'pilates', 'spinning','pesi')),
 giorno VARCHAR(250)NOT NULL,
 orario TIME NOT NULL,
 partecipanti INT NOT NULL CHECK (partecipanti <= 20),
 istruttoreRIF INT NOT NULL,
 prenotazioneRIF INT NOT NULL,
 FOREIGN KEY (istruttoreRIF) REFERENCES Istruttore(istruttoreID) ON DELETE CASCADE,
);





CREATE TABLE Abbonamento(
 abbID  INT PRIMARY KEY IDENTITY (1,1),
 tipo VARCHAR(250) NOT NULL CHECK (tipo IN ('mensile', 'trimestrale', 'annuale')),
 data_start DATE NOT NULL,
 data_end DATE NOT NULL,
 costo DECIMAL(5,2) NOT NULL,
 membroRIF INT NOT NULL,
 FOREIGN KEY (membroRIF) REFERENCES Membro(membroID) ON DELETE CASCADE
);



CREATE TABLE Attrezzature(
	attrezzatureID INT PRIMARY KEY IDENTITY (1,1),
	nome VARCHAR(250) NOT NULL,
	descrizione TEXT NOT NULL,
	data_acquisto DATE NOT NULL,
	stato VARCHAR(250) NOT NULL
);



CREATE TABLE Prenotazione (
	prenotazioneID INT PRIMARY KEY IDENTITY (1,1),
	data_pren DATE NOT NULL,
	annullata DATE DEFAULT NULL,
	classeRIF INT NOT NULL,
	membroRIF INT NOT NULL,
	FOREIGN KEY (classeRIF) REFERENCES Classe(classeID) ON DELETE CASCADE,
	FOREIGN KEY (membroRIF) REFERENCES Membro(membroID) ON DELETE CASCADE
);

--INSERIMENTO MEMBRI 
INSERT INTO Membro (nome, cognome, data_nas, sesso, email, telefono) 
VALUES 
('Giulia', 'Bianchi', '1990-09-23', 'Femmina', 'giulia.bianchi@example.com', 234567901),
('Giulia', 'Bianchi', '1990-09-23', 'Femmina', 'giulia.bianchi@example.com', 234567901),
('Luca', 'Verdi', '1978-12-05', 'Maschio', 'luca.verdi@example.com', 345678902),
('Anna', 'Neri', '1995-03-12', 'Femmina', 'anna.neri@example.com', 456890123),
('Paolo', 'Gialli', '1982-07-19', 'Maschio', 'paolo.gialli@example.com', 567890134),
('Sara', 'Rosa', '1993-11-30', 'Femmina', 'sara.rosa@example.com', 678901345),
('Giulia', 'Bianchi', '1990-09-23', 'Femmina', 'giulia.bianchi@example.com', 234567901),
('Luca', 'Verdi', '1978-12-05', 'Maschio', 'luca.verdi@example.com', 345678012),
('Anna', 'Neri', '1995-03-12', 'Femmina', 'anna.neri@example.com', 456789123),
('Paolo', 'Gialli', '1982-07-19', 'Maschio', 'paolo.gialli@example.com', 567890234),
('Sara', 'Rosa', '1993-11-30', 'Femmina', 'sara.rosa@example.com', 678012345),
('Marco', 'Blu', '1988-04-22', 'Maschio', 'marco.blu@example.com', 789023456), 
('Elena', 'Viola', '1991-08-15', 'Femmina', 'elena.viola@example.com', 890134567),
('Giorgio', 'Marrone', '1980-02-10', 'Maschio', 'giorgio.marrone@example.com', 901234678),
('Francesca', 'Azzurri', '1987-05-25', 'Femmina', 'francesca.azzurri@example.com', 123457891),
('Davide', 'Neri', '1992-12-12', 'Maschio', 'davide.neri@example.com', 234567902),
('Chiara', 'Verdi', '1989-03-18', 'Femmina', 'chiara.verdi@example.com', 345678013),
('Alessandro', 'Rossi', '1984-07-07', 'Maschio', 'alessandro.rossi@example.com', 456890124),
('Martina', 'Bianchi', '1996-01-29', 'Femmina', 'martina.bianchi@example.com', 567890125),
('Federico', 'Gialli', '1983-10-10', 'Maschio', 'federico.gialli@example.com', 678901346),
('Valentina', 'Rosa', '1994-06-06', 'Femmina', 'valentina.rosa@example.com', 789013457),
('Simone', 'Blu', '1986-09-09', 'Maschio', 'simone.blu@example.com', 890134568),
('Laura', 'Viola', '1997-02-14', 'Femmina', 'laura.viola@example.com', 901234679),
('Matteo', 'Marrone', '1981-11-11', 'Maschio', 'matteo.marrone@example.com', 123567892),
('Silvia', 'Azzurri', '1998-04-04', 'Femmina', 'silvia.azzurri@example.com', 345678903);


SELECT * FROM Membro;
-- inserisco istruttori

INSERT INTO Istruttore (nome, cognome, specializzazione, orario,disponibilita) 
VALUES 
('Luca', 'Verdi', 'yoga', '09:00:00','no'),
('Anna', 'Neri', 'pilates', '10:30:00','no'),
('Marco', 'Blu', 'spinning', '11:00:00','sabato'),
('Sara', 'Rosa', 'pesi', '14:00:00','no'),
('Elena', 'Viola', 'yoga', '16:00:00','sabato'),
('Giorgio', 'Marrone', 'pilates', '08:00:00','no'),
('Francesca', 'Azzurri', 'spinning', '12:00:00','sabato'),
('Davide', 'Neri', 'pesi', '15:00:00','no'),
('Chiara', 'Verdi', 'yoga', '17:00:00','no'),
('Mario', 'Rossi', 'pilates', '18:00:00','sabato');

SELECT * FROM Istruttore;


--inserisco attrezzi


INSERT INTO Attrezzature (nome, descrizione, data_acquisto, stato) 
VALUES 
('Tapis Roulant', 'Tapis roulant professionale', '2023-01-15', 'Ottimo'),
('Cyclette', 'Cyclette da palestra', '2022-05-20', 'Buono'), 
('Manubri', 'Set di manubri regolabili', '2021-11-10', 'Ottimo'),
('Panca Piana', 'Panca piana per sollevamento pesi', '2020-06-25', 'Buono'),
('Ellittica', 'Macchina ellittica professionale', '2023-03-05', 'Ottimo'),
('Vogatore', 'Vogatore per allenamento cardio', '2021-09-15', 'Buono'),
('Stepper', 'Stepper per esercizi aerobici', '2022-12-01', 'Ottimo'),
('Pesi', 'Set di pesi variabili', '2023-05-10', 'Buono'),
('Panca', 'Panca in pelle professionale', '2003-01-15', 'fuori sevizio');

SELECT * FROM Classe;

--INSERISCO CLASSE

INSERT INTO Classe (tipo, giorno, orario, partecipanti, istruttoreRIF, prenotazioneRIF) 
VALUES 
('yoga', 'Lunedì', '09:00:00', 15, 1, 1),
('pilates', 'Martedì', '10:30:00', 10, 2, 2),
('spinning', 'Mercoledì', '11:00:00', 20, 3, 3), 
('pesi', 'Giovedì', '14:00:00', 12, 4, 4),
('yoga', 'Venerdì', '16:00:00', 18, 5, 5),
('pilates', 'Sabato', '08:00:00', 8, 6, 6),
('spinning', 'Domenica', '10:00:00', 14, 7, 7),
('pesi', 'Lunedì', '18:00:00', 16, 8, 8)
--INSERT INTO Classe (tipo, giorno, orario, partecipanti, istruttoreRIF, prenotazioneRIF) VALUES ('yoga', 'Mercoledì', '09:00:00', 10, 1, 1);

INSERT INTO Classe (tipo, giorno, orario, partecipanti, istruttoreRIF, prenotazioneRIF) VALUES ('pesi', 'Giovedì', '13:00:00', 10, 7, 5);
--INSERISCO PRENOTAZIONE

INSERT INTO Prenotazione (data_pren, classeRIF, membroRIF) 
VALUES 
('2024-09-20', 1, 1),
('2024-09-21', 2, 2),
('2024-09-22', 3, 3),
('2024-09-23', 4, 4), 
('2024-09-24', 5, 5),
('2024-09-25', 1, 6),
('2024-09-26', 2, 7),
('2024-09-27', 3, 8),
('2024-09-28', 4, 9),
('2024-09-29', 5, 10),
('2024-09-20', 1, 11),
('2024-09-21', 2, 12), 
('2024-09-22', 3, 13),
('2024-09-23', 4, 14), 
('2024-09-24', 5, 15),
('2024-09-25', 1, 16),
('2024-09-26', 2, 17),
('2024-09-27', 3, 18),
('2024-09-28', 4, 19),
('2024-09-27', 3, 20);

--ANNULLATA
INSERT INTO Prenotazione (data_pren, classeRIF, membroRIF,annullata) VALUES ('2024-09-09',3,10,'2024-09-09');
-- inserisco ABBOMEMNTI 

INSERT INTO Abbonamento (tipo, data_start, data_end, costo, membroRIF) 
VALUES 
('mensile', '2024-09-01', '2024-09-30', 50.00,1),
('annuale', '2024-01-01', '2024-12-31', 500.00, 2),
('trimestrale', '2024-07-01', '2024-09-30', 120.00, 3),
('mensile', '2024-08-01', '2024-08-31', 50.00, 4),
('annuale', '2024-02-01', '2025-01-31', 500.00, 5),
('trimestrale', '2024-04-01', '2024-06-30', 120.00, 6),
('mensile', '2024-10-01', '2024-10-31', 50.00, 7),
('annuale', '2024-03-01', '2025-02-28', 500.00, 8), 
('trimestrale', '2024-05-01', '2024-07-31', 120.00, 9),
('mensile', '2024-11-01', '2024-11-30', 50.00, 10),
('mensile', '2024-09-01', '2024-09-30', 50.00, 11),
('annuale', '2024-01-01', '2024-12-31', 500.00, 12),
('trimestrale', '2024-07-01', '2024-09-30', 120.00, 13),
('mensile', '2024-08-01', '2024-08-31', 50.00, 14),
('annuale', '2024-02-01', '2025-01-31', 500.00, 15),
('trimestrale', '2024-04-01', '2024-06-30', 120.00, 16),
('mensile', '2024-10-01', '2024-10-31', 50.00, 17),
('annuale', '2024-03-01', '2025-02-28', 500.00, 18), 
('trimestrale', '2024-05-01', '2024-07-31', 120.00, 19),
('annuale', '2024-03-01', '2025-02-28', 500.00, 20);

--1.	Query base: Recupera tutti i membri registrati nel sistema.

SELECT * FROM Membro;

-- 2.	Recupera il nome e il cognome di tutti i membri che hanno un abbonamento mensile.

SELECT * FROM Membro
	JOIN Abbonamento ON Membro.membroID = Abbonamento.membroRIF
	WHERE tipo = 'mensile'


--3.	Recupera l'elenco delle classi di yoga offerte dal centro fitness.

SELECT * FROM Classe
	WHERE tipo = 'yoga'

--4.	Recupera il nome e cognome degli istruttori che insegnano Pilates.

SELECT nome,cognome FROM Istruttore
	WHERE specializzazione = 'Pilates';

--5.	Recupera i dettagli delle classi programmate per il lunedì.

SELECT * FROM Classe 
	WHERE giorno = 'Lunedì'

--6.	Recupera l'elenco dei membri che hanno prenotato una classe di spinning

SELECT * FROM Membro
	JOIN Prenotazione ON Membro.membroID = Prenotazione.membroRIF
	JOIN Classe ON Prenotazione.prenotazioneID = Classe.prenotazioneRIF
	WHERE tipo = 'spinning'

	--7.	Recupera tutte le attrezzature che sono attualmente fuori servizio.

	SELECT * FROM Attrezzature
		WHERE stato = 'fuori sevizio'

	--8.	Conta il numero di partecipanti per ciascuna classe programmata per il mercoledì.

	SELECT * FROM Membro 
		JOIN Prenotazione ON Membro.membroID = Prenotazione.membroRIF
		JOIN Classe ON Prenotazione.prenotazioneID = Classe.prenotazioneRIF
		WHERE giorno = 'Mercoledì' 
			
		--9.	Recupera l'elenco degli istruttori disponibili per tenere una lezione il sabato.  

		SELECT * FROM Membro 
			JOIN Prenotazione ON Membro.membroID = Prenotazione.membroRIF
			JOIN Classe ON Prenotazione.prenotazioneID = Classe.prenotazioneRIF
			JOIN Istruttore ON Classe.istruttoreRIF = Istruttore.istruttoreID
			WHERE Istruttore.disponibilita= 'sabato'
	--10.	Recupera tutti i membri che hanno un abbonamento attivo dal 2023.

		SELECT *  FROM Membro
			JOIN Abbonamento ON Membro.membroID = Abbonamento.membroRIF
			WHERE Abbonamento.data_start = '2023-09-01';  -- HO AVUTO MOLTI DUBBI

			--11.	Trova il numero massimo di partecipanti per tutte le classi di sollevamento pesi.

			SELECT partecipanti FROM Classe 
				WHERE tipo = 'pesi'
				

		--12.	Recupera le prenotazioni effettuate da un membro specifico.

			SELECT * FROM Prenotazione 
				JOIN Membro ON Prenotazione.membroRIF = Membro.membroID
			WHERE membroID = 1


			
-- 13.	Recupera l'elenco degli istruttori che conducono più di 5 classi alla settimana.
			


-- 14.	Recupera le classi che hanno ancora posti disponibili per nuove prenotazioni. 

		SELECT * FROM Classe
		WHERE partecipanti< 20
-- 15.	Recupera l'elenco dei membri che hanno annullato una prenotazione negli ultimi 30 giorni.
		SELECT * FROM Prenotazione 
		WHERE annullata IS NOT NULL

--16Recupera tutte le attrezzature acquistate prima del 2022.
		SELECT * FROM Attrezzature
		WHERE GETDATE (data_acquisto < DATE)

--17Recupera l'elenco dei membri che hanno prenotato una classe in cui l'istruttore è "Mario Rossi".
		SELECT * FROM Membro
				JOIN Prenotazione ON Membro.membroID = Prenotazione.membroRIF
				JOIN Classe ON Prenotazione.classeRIF = Classe.classeID
				JOIN Istruttore ON Classe.istruttoreRIF = Istruttore.istruttoreID
			WHERE Istruttore.nome = 'Marco'

--18Calcola il numero totale di prenotazioni per ogni classe per un determinato periodo di tempo.



--19Trova tutte le classi associate a un'istruttore specifico e i membri che vi hanno partecipato.
	SELECT * FROM Membro
				JOIN Prenotazione ON Membro.membroID = Prenotazione.membroRIF
				JOIN Classe ON Prenotazione.classeRIF = Classe.classeID
				JOIN Istruttore ON Classe.istruttoreRIF = Istruttore.istruttoreID
			WHERE Istruttore.nome = 'Anna'


--20ecupera tutte le attrezzature in manutenzione e il nome degli istruttori che le utilizzano nelle loro classi.*/
		
/*
1.	Crea una view che mostra l'elenco completo dei membri con il loro nome, cognome e tipo di abbonamento.

2.	Crea una view che elenca tutte le classi disponibili con i rispettivi nomi degli istruttori.

3.	Crea una view che mostra le classi prenotate dai membri insieme al nome della classe e alla data di prenotazione.

4.	Crea una view che elenca tutte le attrezzature attualmente disponibili, con la descrizione e lo stato.

5.	Crea una view che mostra i membri che hanno prenotato una classe di spinning negli ultimi 30 giorni.

6.	Crea una view che elenca gli istruttori con il numero totale di classi che conducono.


7.	Crea una view che mostri il nome delle classi e il numero di partecipanti registrati per ciascuna classe.


8.	Crea una view che elenca i membri che hanno un abbonamento attivo insieme alla data di inizio e la data di scadenza.
9.	Crea una view che mostra l'elenco degli istruttori che conducono classi il lunedì e il venerdì.
10.	Crea una view che elenca tutte le attrezzature acquistate nel 2023 insieme al loro stato attuale.
*/

--1 

CREATE VIEW AgendaAbbonamenti AS
	SELECT Membro.nome + ' ' + Membro.cognome AS cliente, Abbonamento.tipo AS codice
		FROM Membro 
		JOIN Abbonamento ON Membro.membroID = Abbonamento.membroRIF
		
		SELECT * FROM AgendaAbbonamenti;

CREATE VIEW CorsiEistruttori AS
	SELECT Classe.tipo AS corso, Istruttore.nome + ' ' + Istruttore.cognome AS prof
		FROM Istruttore
		JOIN Classe ON Istruttore.istruttoreID = Classe.istruttoreRIF

		SELECT * FROM CorsiEistruttori

CREATE VIEW AgendaPrenotatiCorso AS 
		SELECT Membro.email mem, Prenotazione.data_pren AS pren, Classe.tipo AS serv
		FROM Membro 
		JOIN Prenotazione ON Membro.membroID = Prenotazione.membroRIF
		JOIN Classe ON Prenotazione.prenotazioneID = classeRIF

--DROP VIEW AgendaPrenotatiCorso

		SELECT * FROM AgendaPrenotatiCorso

		CREATE VIEW AttrezziDisponibili AS 
		SELECT Attrezzature.nome,Attrezzature.descrizione,Attrezzature.stato AS attr
			FROM Attrezzature

		SELECT * FROM AttrezziDisponibili


		CREATE VIEW ElencoPrenCorso AS
		SELECT Membro.nome,Membro.cognome AS iscritto 
			FROM Membro
			JOIN Prenotazione ON Membro.membroID = Prenotazione.membroRIF
			JOIN Classe ON Prenotazione.prenotazioneID = Classe.prenotazioneRIF
			WHERE tipo = 'spinning'
			--NON HO CAPITO BENE LE DATE 

			SELECT * FROM ElencoPrenCorso

			CREATE VIEW IstruttoreCorso AS
				SELECT Istruttore.nome AS nome, Classe.tipo AS corso
				FROM Istruttore 
				JOIN Classe ON Istruttore.istruttoreID = Classe.istruttoreRIF
					
				
				SELECT * FROM IstruttoreCorso


				CREATE VIEW AbboAttivi AS 