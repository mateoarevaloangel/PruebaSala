CREATE TABLE Sala
   (
      ID int IDENTITY(1,1) PRIMARY KEY,
      Nombre varchar(255),
      Descripcion varchar(255),
	  Capacidad int
   )
   CREATE TABLE Reservacion
   (
      ID int IDENTITY(1,1) PRIMARY KEY,
      Nombre varchar(255),
      Fecha Date,
	  SalaID int FOREIGN KEY REFERENCES Sala(ID)
   )
alter PROCEDURE SelectAllReservas
AS
BEGIN;
SELECT Reservacion.ID, Reservacion.Nombre, Reservacion.Fecha,Sala.Nombre as NombreSala
FROM Reservacion
INNER JOIN Sala ON Reservacion.SalaID = Sala.ID;
END;
CREATE PROCEDURE SelectAllSalas
AS
BEGIN;
SELECT * FROM Sala
END;
CREATE PROCEDURE AddSala @Nombre nvarchar(30), @Descripcion nvarchar(30),@Capacidad int
AS
BEGIN;
INSERT INTO Sala (Nombre, Descripcion, Capacidad) VALUES (@Nombre, @Descripcion,@Capacidad);
END;
ALTER PROCEDURE AddReserva @Nombre nvarchar(30), @Fecha date,@SalaID int
AS
BEGIN;
INSERT INTO Reservacion (Nombre, Fecha, SalaID) VALUES (@Nombre, @Fecha,@SalaID)
END;
CREATE PROCEDURE DisponibilidadReserva @Nombre nvarchar(30), @Fecha date 
AS
BEGIN;
SELECT s.*
       from Sala s
       WHERE s.ID NOT IN (SELECT SalaID
                                    FROM Reservacion
                                    WHERE Fecha = @Fecha 
                                          )
END;
