INSERT INTO address VALUES
	(1, "Sweden", "Malmö", "Stortorget 29", "21134"), # cinema
	(2, "Sweden", "Malmö", "Sveagatan 24", "21439"), # emp1
	(3, "Sweden", "Malmö", "Jägersrovägen 90", "21237"), # emp2
	(4, "Sweden", "Malmö", "Södra Förstadsgatan 41", "21143"), # emp3
	(5, "Sweden", "Malmö", "Ystadvägen 34", "21445"), # emp 4
	(6, "Sweden", "Malmö", "Malmöhusvägen 7", "21118"), #emp 5
	(7, "Sweden", "Malmö", "Malmöhusvägen 7", "21118"),
	(8, "Sweden", "Malmö", "Malmöhusvägen 7", "21118"),
	(9, "Sweden", "Stockholm", "Tjustgatan 9", "11827"),
	(10, "Denmark", "Kopenhagen", "Vesterbrogade 8", "1620"),
    (11, "Denmark", "Kopenhagen", "Tietgensgade 65", "1704");

	INSERT INTO cinema VALUES
    (1, "Spegeln", 1); 
    

	INSERT INTO person VALUES 
    (1, "Erik", "Andersson", "1988-10-14", 2, "erikandersson@gmail.com", "0701234958"),
    (2, "Jessica", "Axelsson", "1993-01-2", 3, "jessicablack@yahoo.com", "0703948382"),
    (3, "Henrik", "Person", "1983-06-29", 4, "kickass@hotmal.com", "0702954834"),
    (4, "Paul", "Oscarsson", "1989-03-23", 5, "paulpaulpul@boxmail.com", "0704930823"),
    (5, "Emma", "Svensson", "1999-03-03", 2, "emma_123_44@gmail.com", "0703456785"),
    (6, "Maja", "Jacksson", "1987-12-13", 6, "majapiraja@gmail.com", "0703458723"),
    (7, "William", "Cartman", "2005-02-13", 7, "kenny420@gmail.com", "0706002929"),
    (8, "Anna", "Griffin", "1943-09-19", 8, "will.gottli@yahoo.com", "0706917632"),
    (9, "Patricia", "Barkman", "1958-09-18", 9, "jettie1976@yahoo.com", "0703949696"),
    (10, "Jonathan", "Orvarsson", "1995-11-11", 10, "jonte_007@gmail.com", "0705959393");
    
    

    INSERT INTO movie VALUES
    (1, "No time to die", "Action", "02:45:00", 7.6),
    (2, "Free Guy", "Comedy", "01:54:00", 7.3),
    (3, "Godzilla vs. Kong", "Action", "01:54:00", 6.4),
    (4, "The Conjuring: The Devil Made Me Do It", "Horror", "01:52:00", 6.3),
    (5, "The Sucide Squad", "Action", "02:12:00", 7.3),
    (6, "A Quiet Place: Part II", "Horror", "01:37:00", 7.3),
    (7, "Black Widow", "Action", "02:13:00", 6.8),
    (8, "Candyman", "Horror", "01:31:00", 6.0),
    (9, "Escape Room 2: No Way Out", "Action", "01:28:00", 5.8);
    

	INSERT INTO saloon VALUES
    (1, 1, 45),
    (2, 1, 35),
    (3, 1, 65);
    

    INSERT INTO scheduled_movie VALUES
    (1, 1, 1, "2021-10-11 16:35:00"),
    (2, 2, 2, "2021-10-10 18:20:00"),
    (3, 2, 3, "2021-10-10 21:30:00"),
    (4, 1, 4, "2021-10-12 18:35:00"),
    (5, 2, 5, "2021-10-12 21:20:00"),
    (6, 3, 6, "2021-10-13 23:30:00"),
    (7, 1, 7, "2021-10-14 16:05:00"),
    (8, 2, 8, "2021-10-14 23:30:00"),
    (9, 3, 9, "2021-10-15 18:45:00");
    
    INSERT INTO ticket VALUES
    (1, 1, 14.99, 22, 3),
    (2, 2, 10.50, 12, 1),
    (3, 3, 12.99, 2, 5),
    (4, 4, 12.00, 13, 6),
    (5, 5, 15.99, 16, 4),
    (6, 6, 14.00, 6, 3),
    (7, 7, 8.99, 8, 6),
    (8, 8, 11.99, 11, 7),
    (9, 9, 14.50, 19, 1);
    
    describe employee;
    INSERT INTO employee VALUES
    (1, 1, null),
    (2, 2, 1),
    (3, 3, 2),
    (4, 4, 2),
    (5, 5, 2);
    
    INSERT INTO job VALUES
    (1, "Cashier", 3000),
    (2, "Ticket Master", 3000),
    (3, "Cleaner", 2500),
    (4, "Assistant to the Regional Manager", 3500),
    (5, "Regional Manager", 4500);
    
    INSERT INTO shift VALUES
    (1, 5, "15:00", "18:00"),
    (2, 4, "15:00", "00:00"),
    (3, 3, "06:30", "09:30"),
    (5, 3, "16:30", "18:30"),
    (4, 1, "16:30", "23:00"),
    (3, 2, "16:45", "22:30");
    
    INSERT INTO customer VALUES
    (1, 6, 4),
    (2, 7, 4),
    (3, 8, 1),
    (4, 9, 3),
    (5, 10, 7);
