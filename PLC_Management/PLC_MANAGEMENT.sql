﻿CREATE DATABASE PLC_MANAGEMENT
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
)
GO

CREATE TABLE Parameter(
Parameter_ID VARCHAR(25) PRIMARY KEY,
Parameter_Name NVARCHAR(300) NOT NULL,
Parameter_ValueRange NVARCHAR(300),
Parameter_Unit NVARCHAR(30)
)
GO

CREATE TABLE Result(
Result_ID INT IDENTITY(1,1) PRIMARY KEY,
Result_Parameter_Name NVARCHAR(300),
Result_Parameter_ID VARCHAR(25),
Result_Parameter_Unit NVARCHAR(30),
Result_Value FLOAT ,
Result_Status BIT DEFAULT 1,
Result_DateTime DATETIME DEFAULT GETDATE()
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

--Tim kiem Activity theo khoang ngay
CREATE PROC FindActivityDayToDay @Time1 DateTime , @Time2 DateTime
as begin
SELECT * FROM Activity WHERE 
Activity_Time BETWEEN
@Time1 AND
 @Time2 order by Activity.Activity_ID DESC
end
GO

--Tim kiem Result theo khoang ngay
CREATE PROC FindResultDayToDay @Time1 DateTime , @Time2 DateTime
as begin
SELECT * FROM Result WHERE 
Result_DateTime BETWEEN
@Time1 AND
 @Time2 order by Result.Result_ID DESC
end
GO
CREATE PROC FindResultDayToDayByParameter @Time1 DateTime , @Time2 DateTime,@pH varchar(25), @Temp varchar(25), @TSS varchar(25),@COD varchar(25), @NH4 varchar(25)
as begin
SELECT * FROM Result WHERE( 
Result_DateTime BETWEEN
@Time1 AND
 @Time2) and (Result_Parameter_ID = @pH OR Result_Parameter_ID = @Temp OR Result_Parameter_ID = @TSS OR Result_Parameter_ID = @COD OR Result_Parameter_ID = @NH4) order by Result.Result_ID DESC
end
GO
--count by day
CREATE PROC CountResultDayToDay @Time1 DateTime , @Time2 DateTime
as begin
SELECT count(*) FROM Result WHERE 
Result_DateTime BETWEEN
@Time1 AND
 @Time2
end
GO

CREATE PROC CountActivityDayToDay @Time1 DateTime , @Time2 DateTime
as begin
SELECT count(*) FROM Activity WHERE 
Activity_Time BETWEEN
@Time1 AND
 @Time2
end
GO

--Dem result theo ngay, theo parameter
CREATE PROC CountResultByParameterAndDay @Time1 DateTime, @Time2 DateTime, @pH varchar(25),@Temp varchar(25),@TSS varchar(25),@COD varchar(25), @NH4 varchar(25)
as begin
select count(*) from Result where (Result.Result_Parameter_ID = @pH OR Result.Result_Parameter_ID = @Temp OR Result.Result_Parameter_ID = @TSS or Result.Result_Parameter_ID = @COD OR Result.Result_Parameter_ID = @NH4) and (Result.Result_DateTime between @Time1 and @Time2) 
end
GO
-- Them result
CREATE PROC AddResult @Result_Parameter_Name nvarchar(300),@Result_Parameter_ID varchar(25),@Result_Parameter_Unit nvarchar(30),@Result_Value FLOAT
as begin
INSERT INTO Result(Result_Parameter_Name,Result_Parameter_ID,Result_Parameter_Unit,Result_Value) values(@Result_Parameter_Name,@Result_Parameter_ID,@Result_Parameter_Unit,@Result_Value)
end
GO

--phan trang 
create proc paginationActivity (@startfrom int ,@endto int) as
SELECT * FROM ( 
  SELECT *, ROW_NUMBER() OVER (ORDER BY Activity_ID desc) as row FROM Activity 
 ) a WHERE a.row > @startfrom and a.row <= @endto
 GO

 create proc paginationResult (@startfrom int ,@endto int) as
SELECT * FROM ( 
  SELECT *, ROW_NUMBER() OVER (ORDER BY Result_ID desc) as row FROM Result 
 ) a WHERE a.row > @startfrom and a.row <= @endto
 GO

-- phan trang theo ngay
 create proc paginationActivityByDay (@startfrom int ,@endto int, @Time1 Datetime , @Time2 Datetime) as begin
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY Activity_ID desc) as row FROM Activity WHERE 
Activity_Time BETWEEN
@Time1 AND
 @Time2 ) as a WHERE a.row > @startfrom and a.row <= @endto
 end
 GO

  create proc paginationResultByDay (@startfrom int ,@endto int, @Time1 Datetime , @Time2 Datetime) as
SELECT * FROM ( 
  SELECT *, ROW_NUMBER() OVER (ORDER BY Result_ID desc) as row FROM Result WHERE 
Result_DateTime BETWEEN
@Time1 AND
 @Time2
 ) as a WHERE a.row > @startfrom and a.row <= @endto 
 GO

 --pagination paraID and day
   create proc paginationResultByDayAndParameter (@startfrom int ,@endto int, @Time1 Datetime , @Time2 Datetime,@pH varchar(25),@Temp varchar(25), @TSS varchar(25), @COD varchar(25),@NH4 varchar(25) ) as begin 
  select * from (SELECT *, ROW_NUMBER() OVER (ORDER BY Result_ID desc) as row FROM Result WHERE 
(Result_DateTime BETWEEN
@Time1 AND
 @Time2) AND (Result_Parameter_ID = @pH OR Result_Parameter_ID = @Temp OR Result_Parameter_ID = @TSS OR Result_Parameter_ID = @COD OR Result.Result_Parameter_ID = @NH4)) as a WHERE a.row > @startfrom and a.row <= @endto  
 end
 GO


 -- delete result by ID
 CREATE proc DeleteResultByIDAndParameter (@startID int, @endID int, @pH varchar(25),@Temp varchar(25), @TSS varchar(25), @COD varchar(25),@NH4 varchar(25))
 as begin
 Delete From Result Where (Result.Result_ID >= @startID and Result.Result_ID <= @endID) and (Result_Parameter_ID = @pH OR Result_Parameter_ID = @Temp OR Result_Parameter_ID = @TSS OR Result_Parameter_ID = @COD OR Result_Parameter_ID = @NH4) 
 end
 GO

exec AddEmployee N'Đỗ Văn Xuân', 'admin', '123', 1
GO
Insert into Parameter values ('pH','pH','5/9',''),('Temp','Temp','40',N'độ C'),('TSS','TSS','100','mg/L'),('COD','COD','150','mg/L'),('NH4','NH4','','');
GO
