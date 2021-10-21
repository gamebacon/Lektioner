USE cinema;

ALTER TABLE job ADD COLUMN max_salary FLOAT DEFAULT 5000;
UPDATE job SET max_salary = 7500 WHERE job.title = "Regional manager";
DELETE FROM shift WHERE employee_id = 1;
INSERT INTO shift VALUES (1, 5, "15:00", "00:00");

SELECT * FROM job WHERE job.salary > 3000.00;
SELECT title AS "Scary movies", rating as "Rating"
 from movie WHERE genre = "Horror" ORDER BY rating DESC;
SELECT firstname AS "Name", birth_date AS "Birth" FROM person ORDER BY birth_date ASC;
SELECT round(AVG(salary), 2) AS "Average employee salary" from job;

SELECT p.firstname AS "Name",
 j.title AS "Role",
 s.shift_begin AS "Starts",
 s.shift_end AS "Finishes"
FROM shift s
inner join employee emp ON s.employee_id = emp.id
inner join job j ON j.id = s.job_id
inner join person p ON emp.person_id = p.id
ORDER BY s.shift_begin ASC;

SELECT CONCAT(emp_person.firstname, " ", emp_person.lastname) AS "Employee",
 CONCAT(mgr_person.firstname, " ", mgr_person.lastname) AS "Manager"
 from employee emp
INNER JOIN person emp_person ON emp.person_id = emp_person.id
LEFT JOIN employee mgr ON emp.manager = mgr.id
LEFT JOIN person mgr_person ON mgr.person_id = mgr_person.id;


SELECT 
person.firstname AS "Firstname",
person.lastname AS "Lastname",
person.birth_date AS "Birth date",
address.city AS "City", 
address.street AS "Street", 
address.zip AS "Zipcode"
from person
 inner join address on person.address_id = address.id;
 
 
SELECT * FROM movie WHERE rating > (SELECT AVG(rating) FROM movie);

SELECT * FROM movie WHERE id = (floor(1 + RAND() * 9));

SELECT title AS "Movie", 
	IF(rating > 7.0, "Good", "meh") AS "Review"
FROM movie;

CREATE VIEW person_info AS 
	SELECT CONCAT(p.firstname, " ", p.lastname) AS "Name",
	CONCAT(a.street, ", ", a.city, ", ", a.country) AS "Address"
	FROM person p
    INNER JOIN address a 
    ON p.address_id = a.id;

DELIMITER $$
CREATE PROCEDURE GetMoviesFromGenre(wantedGenre VARCHAR(255))
BEGIN
	SELECT title AS "Title", length AS "Length", rating AS "Rating"
    FROM movie WHERE genre = wantedGenre ORDER BY rating DESC;
END $$
DELIMITER $$



