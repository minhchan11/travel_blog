CREATE DATABASE Travel
GO
USE Travel
GO
CREATE TABLE locations
(
  id int NOT NULL IDENTITY(1, 1),
  name nvarchar(255) NOT NULL
)
go

ALTER TABLE locations ADD CONSTRAINT pk_locations
  PRIMARY KEY (id)
go

CREATE TABLE people
(
  id int NOT NULL IDENTITY(1, 1),
  name nchar(255) NOT NULL,
  thingId int NOT NULL
)
go

ALTER TABLE people ADD CONSTRAINT pk_people
  PRIMARY KEY (id)
go

CREATE TABLE things
(
  id int NOT NULL IDENTITY(1, 1),
  description nchar(255) NOT NULL,
  locationId int NOT NULL
)
go

ALTER TABLE things ADD CONSTRAINT pk_things
  PRIMARY KEY (id)
go

ALTER TABLE people ADD CONSTRAINT fk_people_things
  FOREIGN KEY (thingId) REFERENCES things (id)
go

ALTER TABLE things ADD CONSTRAINT fk_things_locations
  FOREIGN KEY (locationId) REFERENCES locations (id)
go
