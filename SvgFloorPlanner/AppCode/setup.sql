/* Sample database setup script. Use isql.exe from Firebird           */
/* Server for Windows installation or some Firebird admin tool      */
/* to create the database.       */

SET SQL DIALECT 3;

SET NAMES NONE;

/* Change the path if necessary */
CREATE DATABASE 'LOCALHOST:C:\MYDB.FDB'
USER 'SYSDBA' PASSWORD 'masterkey'
PAGE_SIZE 1024
DEFAULT CHARACTER SET NONE;


CREATE TABLE TABLE1 (
    ID         INTEGER,
    FIRSTNAME  VARCHAR(50),
    LASTNAME   VARCHAR(50)
);

INSERT INTO TABLE1 (ID, FIRSTNAME, LASTNAME) VALUES (1, 'John', 'Doe');
INSERT INTO TABLE1 (ID, FIRSTNAME, LASTNAME) VALUES (2, 'Jane', 'Doe');

COMMIT WORK;