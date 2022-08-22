CREATE VIEW PassportView AS
SELECT Passports.firstName, 
       Passports.lastName, 
	   Passports.passportSeria, 
	   Passports.passpotNumber, 
       PassportList.allPassports  
FROM Passports 
	 INNER JOIN 
	(SELECT firstName, 
		    lastName,
			STRING_AGG(CONCAT(passportSeria, passpotNumber), ', ') AS allPassports
	 FROM Passports
	 GROUP BY firstName, lastName) AS PassportList
	 ON Passports.firstName = PassportList.firstName AND Passports.lastName = PassportList.lastName

SELECT *
FROM PassportView
WHERE passportSeria = 'AA' AND  passpotNumber='12345678'
