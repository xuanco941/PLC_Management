CREATE DATABASE PLC_MANAGEMENT
GO
USE PLC_MANAGEMENT
GO

CREATE TABLE Employee (
Employee_ID INT IDENTITY(1,1) PRIMARY KEY,
Employee_FullName NVARCHAR(100),
Employee_Username VARCHAR(100) UNIQUE NOT NULL,
Employee_Password VARCHAR(100) default 'plcmanagement',
Employee_IsAdmin BIT default 0
)
GO

CREATE TABLE Activity(
Activity_ID INT IDENTITY(1,1) PRIMARY KEY,
Activity_Name NVARCHAR(2000),
Activity_Time DATETIME DEFAULT GETDATE()
--Employee_ID INT,
--FOREIGN KEY (Employee_ID) REFERENCES Employee(Employee_ID)
)
GO

CREATE TABLE Parameter(
Parameter_ID VARCHAR(25) PRIMARY KEY,
Parameter_Name NVARCHAR(300) NOT NULL,
Parameter_ValueRange NVARCHAR(300),
Parameter_Unit NVARCHAR(30)
)
GO

--CREATE TABLE Cabinet(
	
--)
GO
CREATE TABLE Flow(
Flow_ID INT IDENTITY(1,1) PRIMARY KEY,
Flow_Name nvarchar(200),
Flow_Value REAL ,
Flow_Unit nvarchar(20)
)

GO

CREATE TABLE Result(
Result_ID INT IDENTITY(1,1) PRIMARY KEY,
Result_Parameter_Name NVARCHAR(300),
Result_Parameter_ID VARCHAR(25),
Result_Parameter_Unit NVARCHAR(30),
Result_Value REAL ,
Result_Status BIT DEFAULT 1,
Result_DateTime DATETIME DEFAULT GETDATE()
--FOREIGN KEY (Result_Parameter_ID) REFERENCES Parameter(Parameter_ID)
)
GO

/* Procedure */
--Tìm kiếm nhân viên theo tên tài khoản
CREATE PROC FindEmployeeByUsername @Username varchar(100)
as begin 
Select * From Employee Where Employee.Employee_Username = @Username;
end
GO

--Tìm kiếm nhân viên theo MaNV
CREATE PROC FindEmployeeByID @ID int
as begin 
Select * From Employee Where Employee.Employee_ID = @ID;
end
GO

--Tìm kiếm nhân viên với họ tên bất kỳ
CREATE PROC FindEmployeeByFullName @FullName nvarchar(100)
as begin 
Select * From Employee Where Employee.Employee_FullName like '%'+@FullName+'%';
end
GO

-- Thêm nhân viên
CREATE PROC AddEmployee @FullName nvarchar(100), @Username VARCHAR(100) , @Password VARCHAR(100) , @IsAdmin Bit
as begin
Insert into Employee values (@FullName,@Username,@Password,@IsAdmin);
end
GO

--Cap nhat thong tin nhan vien
CREATE PROC UpdateEmployee @ID int, @FullName nvarchar(100), @Username VARCHAR(100) , @Password VARCHAR(100) , @IsAdmin Bit
as begin
Update Employee SET Employee_FullName = @FullName, Employee_Username = @Username, Employee_Password = @Password, Employee_IsAdmin = @IsAdmin
where Employee_ID = @ID
end
GO


--Xóa tài khoản nhân viên theo MaNV
CREATE PROC DeleteEmployee @ID int
as begin
Delete FROM Employee WHERE Employee.Employee_ID = @ID;
end
GO


exec AddEmployee 'Do Van Xuan', 'xuan', '123', 1
GO
Insert into Parameter values ('pH','pH','6/9',''),('Temp','Temp','<40','&#176;C'),('TSS','TSS','<50','mg/L'),('COD','COD','<75','mg/L');
GO
Insert into Flow values('Luu luong vao',9.9,'m3/h'),('Tong luu luong vao',20,'m3'),('Luu luong ra',5.5,'m3/h'),('Luu luong ra',17,'m3')
GO
Insert into Activity(Activity_Name) values('ngat ket noi plc');
GO
INSERT INTO Result(Result_Parameter_ID,Result_Parameter_Name,Result_Parameter_Unit,Result_Value) values('pH','pH','6/9',7.8)


select * from Employee
select * from Parameter
select * from Flow
select * from Activity
select * from Result

--SELECT * FROM Activity
--WHERE Activity_Time >= '1970' AND Activity_Time <= '2022'