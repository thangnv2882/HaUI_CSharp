use DemoBai11
go

create table LoaiSanPham 
(
	maloai int primary key not null,
	tenloai nvarchar(30),
)
create table SanPham
(
	masp int primary key not null,
	tensp nvarchar(30),
	soluong int,
	dongia float,
	maloai int not null,
	constraint fk_lsp foreign key(maloai) 
	references LoaiSanPham(maloai)
)