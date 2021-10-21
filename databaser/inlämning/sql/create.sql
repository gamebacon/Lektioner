DROP DATABASE IF EXISTS cinema;
CREATE DATABASE IF NOT EXISTS cinema;
USE cinema;

CREATE TABLE address (
	id INT PRIMARY KEY NOT NULL,
    country VARCHAR(255) NOT NULL,
    city VARCHAR(255) NOT NULL,
    street VARCHAR(255) NOT NULL,
    zip VARCHAR(10) NOT NULL
);
CREATE TABLE person (
	id INT PRIMARY KEY NOT NULL,
    firstname VARCHAR(255),
    lastname VARCHAR(255),
    birth_date DATE,
	address_id INT,
    email VARCHAR(255),
    phone_number VARCHAR(10),
    FOREIGN KEY(address_id) REFERENCES address(id)
);
CREATE TABLE employee (
	id INT PRIMARY KEY NOT NULL,
    person_id INT NOT NULL,
    manager INT REFERENCES id,
    FOREIGN KEY(person_id) REFERENCES person(id)
);
CREATE TABLE job (
	id INT PRIMARY KEY NOT NULL,
	title VARCHAR(255),
    salary FLOAT
);
CREATE TABLE shift (
	employee_id INT NOT NULL,
    job_id INT NOT NULL,
    shift_begin TIME,
    shift_end TIME,
    FOREIGN KEY(employee_id) REFERENCES employee(id),
    FOREIGN KEY(job_id) REFERENCES job(id),
    PRIMARY KEY(employee_id, job_id)
);
CREATE TABLE cinema (
	id INT NOT NULL PRIMARY KEY,
    name VARCHAR(255),
    address_id INT NOT NULL,
    FOREIGN KEY(address_id) REFERENCES address(id)
);
CREATE TABLE saloon (
	id INT NOT NULL PRIMARY KEY,
    cinema_id INT NOT NULL,
    max_capacity INT,
    FOREIGN KEY(cinema_id) REFERENCES cinema(id)
);
CREATE TABLE movie (
	id INT NOT NULL PRIMARY KEY,
	title VARCHAR(255), 
	genre VARCHAR(45),
	length TIME,
    rating DECIMAL(2,1)
);
CREATE TABLE scheduled_movie (
	id INT NOT NULL PRIMARY KEY,
    saloon_id INT NOT NULL,
    movie_id INT NOT NULL,
    showtime DATETIME NOT NULL,
    FOREIGN KEY(saloon_id) REFERENCES saloon(id),
    FOREIGN KEY(movie_id) REFERENCES movie(id)
);
CREATE TABLE ticket (
	id INT PRIMARY KEY NOT NULL,
    scheduled_movie_id INT NOT NULL,
    price FLOAT,
    seat INT,
    _row INT
);
CREATE TABLE customer (
	id INT NOT NULL PRIMARY KEY,
    person_id INT NOT NULL,
    ticket_id INT,
    FOREIGN KEY(person_id) REFERENCES person(id),
    FOREIGN KEY(ticket_id) REFERENCES ticket(id)
);




