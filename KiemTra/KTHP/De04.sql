CREATE DATABASE QLBanHang
GO
USE QLBanHang
GO
-- bảng Danh mục hàng
CREATE TABLE DanhMucHang(
MaDM char(4) PRIMARY KEY,
TenDM nvarchar(50) )
GO
INSERT INTO DanhMucHang VALUES('DM01',N'Sữa và sản phẩm từ sữa')
INSERT INTO DanhMucHang VALUES('DM02',N'Thủy hải sản')
INSERT INTO DanhMucHang VALUES('DM03',N'Rau củ quả')
GO
--bảng Hàng
CREATE TABLE Hang(
MaHang char(3) PRIMARY KEY,
TenHang nvarchar(30),
DonGiaBan int,
SoLuongCon int,
MaDM char(4) FOREIGN KEY REFERENCES DanhMucHang(MaDM))
GO
INSERT INTO Hang VALUES('H01',N'Sữa tươi không đường',10000,100,'DM01')
INSERT INTO Hang VALUES('H02',N'Phi lê cá basa',20000,200,'DM02')
INSERT INTO Hang VALUES('H03',N'Pho mát sợi',30000,300,'DM01')
GO
