create database lektion8;
use lektion8;


create table students
(
	id int primary key auto_increment,
    first_name varchar(255),
    last_name varchar(255),
    age int,
    birth_date date
);


DELIMITER $$

CREATE PROCEDURE add_student (
    firstname varchar(255),
    lastname varchar(255),
    age int,
    birthdate date
)

begin 
	insert into students (first_name, last_name, age, birth_date) values
    (firstname, lastname, age, birthdate);
end$$

delimiter ;


select * from students;

call add_student("William", "With", 22, "1998-10-16");
call add_student("Niklas", "Carlsson", 29, "1992-01-10");


select * from students where first_name regexp "n"; # take student with name starts with n


select avg(age) from students;



select 


