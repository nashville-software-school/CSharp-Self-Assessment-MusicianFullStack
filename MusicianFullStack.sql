USE [master]

IF db_id('MusicianFullStack') IS NULl
BEGIN
    CREATE DATABASE [MusicianFullStack]
END;
GO

USE [MusicianFullStack]
GO


DROP TABLE IF EXISTS MusicianInstrument;
DROP TABLE IF EXISTS Instrument;
DROP TABLE IF EXISTS Difficulty;
DROP TABLE IF EXISTS Musician;


CREATE TABLE Musician
(
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
    Name NVARCHAR(55) NOT NULL
);

CREATE TABLE Difficulty
(
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
    Label NVARCHAR(25) NOT NULL
);

CREATE TABLE Instrument
(
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
    Name NVARCHAR(255) NOT NULL,
    DifficultyId INTEGER NOT NULL,

    CONSTRAINT FK_Instrument_Difficulty FOREIGN KEY(DifficultyId) REFERENCES Difficulty(Id)
);

CREATE TABLE MusicianInstrument
(
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
    MusicianId INTEGER NOT NULL,
    InstrumentId INTEGER NOT NULL,

    CONSTRAINT FK_MusicianInstrument_Musician FOREIGN KEY(MusicianId) REFERENCES Musician(Id),
    CONSTRAINT FK_MusicianInstrument_Instrument FOREIGN KEY(InstrumentId) REFERENCES Instrument(Id)
);


INSERT INTO Musician ( Name ) VALUES ( 'Sun Ra' )
INSERT INTO Musician ( Name ) VALUES ( 'Weird Guy Down the Street' )
INSERT INTO Musician ( Name ) VALUES ( 'Julie' )

INSERT INTO Difficulty ( Label ) VALUES ( 'Easy' )
INSERT INTO Difficulty ( Label ) VALUES ( 'Hard' )

INSERT INTO Instrument ( Name, DifficultyId ) VALUES ( 'Recorder', 1 )
INSERT INTO Instrument ( Name, DifficultyId ) VALUES ( 'Triangle', 1 )
INSERT INTO Instrument ( Name, DifficultyId ) VALUES ( 'Trumpet', 2 )
INSERT INTO Instrument ( Name, DifficultyId ) VALUES ( 'Upright Bass', 2 )
INSERT INTO Instrument ( Name, DifficultyId ) VALUES ( 'Fiddle', 2 )

INSERT INTO MusicianInstrument (MusicianId, InstrumentId ) VALUES ( 1, 3 )
INSERT INTO MusicianInstrument (MusicianId, InstrumentId ) VALUES ( 2, 2 )
INSERT INTO MusicianInstrument (MusicianId, InstrumentId ) VALUES ( 3, 2 )
INSERT INTO MusicianInstrument (MusicianId, InstrumentId ) VALUES ( 3, 4 )
