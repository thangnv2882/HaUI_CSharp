use DemoBai11
go

DROP TABLE LoaiSanPham
DROP TABLE SanPham


create table LoaiSanPham 
(
	maloai nvarchar(20) primary key not null,
	tenloai nvarchar(30),
)
create table SanPham
(
	masp nvarchar(20) primary key not null,
	tensp nvarchar(30),
	soluong int,
	dongia float,
	maloai nvarchar(20) not null,
	constraint fk_lsp foreign key(maloai) 
	references LoaiSanPham(maloai)
)