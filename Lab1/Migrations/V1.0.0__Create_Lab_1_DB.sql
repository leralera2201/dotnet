create table station
(
    id int auto_increment
        primary key,
    name varchar(50) not null
);

create table users
(
    id int auto_increment
        primary key,
    first_name varchar(50) not null,
    last_name varchar(50) not null,
    email varchar(50) not null,
    password varchar(50) not null
);

create definer = admin@`%` procedure DeleteFromTableById(IN table_name varchar(50), IN id int)
BEGIN
	SET @Expression = CONCAT('DELETE FROM ', table_name, ' WHERE id=', id, ';');
PREPARE myquery FROM @Expression;
EXECUTE myquery;
END;

create definer = admin@`%` procedure GetAllRecordsFromTable(IN table_name varchar(50))
BEGIN
	SET @Expression = CONCAT('SELECT * FROM ', table_name, ';');
PREPARE myquery FROM @Expression;
EXECUTE myquery;
END;

create definer = admin@`%` procedure GetRecordFromTableById(IN table_name varchar(50), IN id int)
BEGIN
	SET @Expression = CONCAT('SELECT * FROM ', table_name, ' WHERE id=', id, ';');
PREPARE myquery FROM @Expression;
EXECUTE myquery;
END;

create definer = admin@`%` procedure InsertEntityIntoTable(IN table_name varchar(50), IN colums varchar(500), IN properties varchar(500))
BEGIN
	SET @Expression = CONCAT('INSERT INTO ', table_name, '(', colums , ') VALUES (', properties, ')', ';');
PREPARE myquery FROM @Expression;
EXECUTE myquery;
END;

create definer = admin@`%` procedure UpdateEntityInsideTable(IN table_name varchar(50), IN id int, IN fields varchar(1000))
BEGIN
	SET @Expression = CONCAT('UPDATE ', table_name, ' SET ', fields , ' WHERE id=', id,  ';');
PREPARE myquery FROM @Expression;
EXECUTE myquery;
END;

