use master
go
create database dbQLSV_DaiHoc
on primary(
	name='pri_dbQLSV_DaiHoc',
	filename='D:\KhaiThacDuLieu\PhanMemChonChuyenNganh\DataSet\pri_dbQLSV_DaiHoc.mdf',
	size=10MB,
	maxsize=20MB,
	filegrowth=10%
)
log on(
	name='log_dbQLSV_DaiHoc',
	filename='D:\KhaiThacDuLieu\PhanMemChonChuyenNganh\DataSet\log_dbQLSV_DaiHoc.ldf',
	size=7MB,
	maxsize=14MB,
	filegrowth=5%
)
go
use dbQLSV_DaiHoc
go
create table sinhVien(
	MSSV char(10),
	HoTen nvarchar(50),
	DiemHe4 float,
	XepLoai nvarchar(20),
	primary key(MSSV)
)
go
create table MonHoc(
	maMH char(10),
	tenMH nvarchar(100),
	soTC int,
	maChuyenNganh char(10)
	primary key(maMH)
)
go
create table chuyenNganh(
	maChuyenNganh char(10),
	tenChuyenNganh nvarchar(100)
	primary key(maChuyenNganh)
)
go 
create table ketQuaThi(
	MSSV char(10),
	MaMH char(10),
	DiemHe10 float,
	DiemChu char(2),
	XepLoai nvarchar(20),
	primary key(MSSV,MaMH)
)
go
--Tạo khóa ngoại
alter table monHoc
add constraint fk_MH_CN foreign key(maChuyenNganh) references ChuyenNganh(maChuyenNganh)
go
alter table ketQuaThi
add constraint fk_KQ_SV foreign key(MSSV) references SinhVien(MSSV)
go
alter table ketQuaThi
add constraint fk_KQ_MH foreign key(maMH) references monHoc(maMH)
go
--Nhập liệu
--Bảng chuyên ngành 
insert into ChuyenNganh(maChuyenNganh,tenChuyenNganh) values
	('CNPM',N'Công nghệ phần mềm'),
	('HTTT',N'Hệ thống thông tin'),
	('MMT',N'Mạng máy tính'),
	('KTDL',N'Khai thác dữ liệu')
go
--Bảng môn học
insert into MonHoc(maMH,tenMH,soTC,maChuyenNganh) values
	('003472',N'LT Nhập môn lập trình',3,'CNPM'),
	('003473',N'TH Nhập môn lập trình',2,'CNPM'),
	('002910',N'LT Lập trình hướng đối tượng',3,'CNPM'),
	('005281',N'TH Lập tình hướng đối tượng',1,'CNPM'),
	('002290',N'Kiến trúc máy tính',2,'MMT'),
	('006199',N'Toán Rời Rạc',3,'KTDL'),
	('000420',N'LT Cấu trúc Dữ Liệu và Giải Thuật',3,'CNPM'),
	('004794',N'TH Cấu trúc dữ liệu và giải thuật',2,'CNPM'),
	('000605',N'LT Cơ Sở Sữ Liệu',3,'HTTT'),
	('007642',N'TH Cơ sở Dữ liệu',1,'HTTT'),
	('001742',N'Hệ Diều Hành',3,'MMT'),
	('001755',N'Hệ Quản trị csdl',3,'HTTT'),
	('003158',N'Mạng Máy Tính',3,'MMT'),
	('005322',N'TH Mạng Máy Tính',1,'MMT'),
	('006237',N'Trí Tuệ Nhân Tạo',3,'KTDL'),
	('000002',N'Công nghệ Java',3,'CNPM')
go
--Bảng sinh viên 
insert into sinhVien(MSSV,HoTen,DiemHe4)
select MSSV,HoTen,DiemHe4 from dbo.xlsx
--Bảng điểm 

/*insert into ketQuaThi(MSSV,MaMH,DiemHe10)
select MSSV,Mamh,CongNgheJava from xlsx,MonHoc
where mamh='000002'*/

select count(*) from ketquaThi