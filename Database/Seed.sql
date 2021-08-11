BEGIN TRY

	BEGIN TRANSACTION Seed_Database
		
		USE [FIBA]

		DELETE FROM Seasons
		GO
		DBCC CHECKIDENT (Seasons, RESEED, 0)
		GO

		DELETE FROM Genders
		GO
		DBCC CHECKIDENT (Genders, RESEED, 0)
		GO

		DELETE FROM Player
		DBCC CHECKIDENT (Player, RESEED, 0)
		
		DELETE FROM Team
		DBCC CHECKIDENT (Team, RESEED, 0)



		-- Gender
		INSERT INTO Genders (GenderId, Name) VALUES ('eddf827d-8795-4054-93b9-19276dd4af26', 'Female')
		GO
		INSERT INTO Genders (GenderId, Name) VALUES ('7a8e0b6f-3e77-4c55-9227-d47325088b25','Male')
		GO

		-- Season
		INSERT INTO Seasons (Year, NbTeams, GenderId, LastModification) VALUES (2020, 8, 1, SYSDATETIMEOFFSET())
		GO
		INSERT INTO Seasons (Year, NbTeams, GenderId, LastModification) VALUES (2020, 8, 2, SYSDATETIMEOFFSET())
		GO

		-- Team
		INSERT INTO Teams(Tea_Name, Tea_Gen_Id) VALUES ('TeamF01', 1)
		INSERT INTO Teams(Tea_Name, Tea_Gen_Id) VALUES ('TeamF02', 1)
		INSERT INTO Teams(Tea_Name, Tea_Gen_Id) VALUES ('TeamF03', 1)
		INSERT INTO Teams(Tea_Name, Tea_Gen_Id) VALUES ('TeamF04', 1)
		INSERT INTO Teams(Tea_Name, Tea_Gen_Id) VALUES ('TeamF05', 1)
						
		INSERT INTO Teams(Tea_Name, Tea_Gen_Id) VALUES ('TeamM01', 2)
		INSERT INTO Teams(Tea_Name, Tea_Gen_Id) VALUES ('TeamM02', 2)
		INSERT INTO Teams(Tea_Name, Tea_Gen_Id) VALUES ('TeamM03', 2)
		INSERT INTO Teams(Tea_Name, Tea_Gen_Id) VALUES ('TeamM04', 2)
		INSERT INTO Teams(Tea_Name, Tea_Gen_Id) VALUES ('TeamM05', 2)

		-- Player
		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 01', 'TeamF01', 1, 1)
		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 02', 'TeamF01', 1, 1)
		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 03', 'TeamF01', 1, 1)
		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 04', 'TeamF01', 1, 1)
		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 05', 'TeamF01', 1, 1)

		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 01', 'TeamF02', 2, 1)
		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 02', 'TeamF02', 2, 1)
		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 03', 'TeamF02', 2, 1)
		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 04', 'TeamF02', 2, 1)
		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 05', 'TeamF02', 2, 1)

		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 01', 'TeamF03', 3, 1)
		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 02', 'TeamF03', 3, 1)
		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 03', 'TeamF03', 3, 1)
		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 04', 'TeamF03', 3, 1)
		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 05', 'TeamF03', 3, 1)

		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 01', 'TeamF04', 4, 1)
		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 02', 'TeamF04', 4, 1)
		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 03', 'TeamF04', 4, 1)
		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 04', 'TeamF04', 4, 1)
		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 05', 'TeamF04', 4, 1)

		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 01', 'TeamF05', 5, 1)
		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 02', 'TeamF05', 5, 1)
		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 03', 'TeamF05', 5, 1)
		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 04', 'TeamF05', 5, 1)
		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 05', 'TeamF05', 5, 1)

		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 01', 'TeamM01', 6, 2)
		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 02', 'TeamM01', 6, 2)
		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 03', 'TeamM01', 6, 2)
		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 04', 'TeamM01', 6, 2)
		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 05', 'TeamM01', 6, 2)

		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 01', 'TeamM02', 7, 2)
		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 02', 'TeamM02', 7, 2)
		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 03', 'TeamM02', 7, 2)
		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 04', 'TeamM02', 7, 2)
		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 05', 'TeamM02', 7, 2)

		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 01', 'TeamM03', 8, 2)
		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 02', 'TeamM03', 8, 2)
		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 03', 'TeamM03', 8, 2)
		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 04', 'TeamM03', 8, 2)
		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 05', 'TeamM03', 8, 2)

		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 01', 'TeamM04', 9, 2)
		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 02', 'TeamM04', 9, 2)
		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 03', 'TeamM04', 9, 2)
		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 04', 'TeamM04', 9, 2)
		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 05', 'TeamM04', 9, 2)

		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 01', 'TeamM05', 10, 2)
		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 02', 'TeamM05', 10, 2)
		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 03', 'TeamM05', 10, 2)
		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 04', 'TeamM05', 10, 2)
		INSERT INTO Player (Pla_FirstName, Pla_LastName, Pla_Tea_Id, Pla_Gen_Id) VALUES ('Player 05', 'TeamM05', 10, 2)

		-- Season
		EXEC Fiba_Administrator.sp_addSeason 2020, 6, 1
		EXEC Fiba_Administrator.sp_addSeason 2020, 6, 2

	COMMIT TRANSACTION Seed_Database

END TRY

BEGIN CATCH

	ROLLBACK TRANSACTION Seed_Database

END CATCH