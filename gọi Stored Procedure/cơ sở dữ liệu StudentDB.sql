-- tạo cơ sở dữ liệu
CREATE DATABASE StudentDB;
GO


-- sử dụng cơ sở dữ liệu
USE StudentDB;
GO


-- tạo bảng
CREATE TABLE Student(
 [Id] [int] IDENTITY(100,1) PRIMARY KEY,
 [Name] [varchar](100) NULL,
 [Email] [varchar](50) NULL,
 [Mobile] [varchar](50) NULL
);
GO


-- thêm dữ liệu vào bảng
INSERT INTO Student VALUES ('Anurag','Anurag@dotnettutorial.net','1234567890');
INSERT INTO Student VALUES ('Priyanka','Priyanka@dotnettutorial.net','2233445566');
INSERT INTO Student VALUES ('Preety','Preety@dotnettutorial.net','6655443322');
INSERT INTO Student VALUES ('Sambit','Sambit@dotnettutorial.net','9876543210');


-- tạo stored procedure
CREATE PROCEDURE spGetStudents
AS
BEGIN
     SELECT Id, Name, Email, Mobile
     FROM Student
END