create database WebBanHang_FoodHub
go
use WebBanHang_FoodHub

create table UserAccount(
	UserId int primary key not null identity(1,1),
	UserName nvarchar(50) not null,
	FullName nvarchar(100) not null,
	Password nvarchar(50) not null,
	UrlAvatar nvarchar(300),
	Address nvarchar(200),
	PhoneNumber nvarchar(12),
	Email nvarchar(100),
	DateOfBirth datetime,
	IsAdmin int
)

insert into UserAccount(FullName, UserName, Password, PhoneNumber, Email, Address, DateOfBirth, IsAdmin) 
values(N'Hồ Văn Nam', 'honam', '123456', '098313333', 'hovanname@gmail.com', N'Nghệ An', '03/02/1999', 0)
insert into UserAccount(FullName, UserName, Password, PhoneNumber, Email, Address, DateOfBirth, IsAdmin) 
values(N'Hồ Thị Khách Ly', 'khanhly', '123456', '09831333', 'lyaanname@gmail.com', N'Hà Nội', '03/02/1999', 0)
insert into UserAccount(FullName, UserName, Password, PhoneNumber, Email, Address, DateOfBirth, IsAdmin) 
values(N'Trần Văn Khoa', 'khoatran', '123456', '09754444', 'aa@gmail.com', N'Nghệ An', '03/02/1999', 1)
insert into UserAccount(FullName, UserName, Password, PhoneNumber, Email, Address, DateOfBirth, IsAdmin) 
values(N'Lê Khắc Khỏe', 'khôe', '123456', '09811233', 'h1ame@gmail.com', N'Thanh Hóa', '03/02/1999', 1)

create table Category(
	CategoryId int primary key not null identity(1,1),
	CategoryName nvarchar(50) not null,
	Origin nvarchar(100),
	Active int not null, --- 0: đang bán, 1: ngừng bán
	Manufacturer nvarchar(100)
)

insert into Category(CategoryName, Origin, Active, Manufacturer) values(N'Rau, củ', 'Miền Bắc', 1, null)
insert into Category(CategoryName, Origin, Active, Manufacturer) values(N'Trái cây', 'Miền Bắc', 1, null)
insert into Category(CategoryName, Origin, Active, Manufacturer) values(N'Hải sản', 'Quỳnh Lưu', 1, null)
insert into Category(CategoryName, Origin, Active, Manufacturer) values(N'Combo tiện lợi', 'Miền Bắc', 1, null)
insert into Category(CategoryName, Origin, Active, Manufacturer) values(N'Món ăn', 'Miền Bắc', 1, null)
insert into Category(CategoryName, Origin, Active, Manufacturer) values(N'Gia vị', 'Hà Nội', 1, 'ajinomoto')


create table Product(
	ProductId int primary key not null identity(1,1),
	ProductName nvarchar(100) not null,
	ProductCode nvarchar(50) not null,
	Price float not null,
	UrlPicture nvarchar(300) not null,
	Quantity int not null,
	Unit nvarchar(20),
	Description ntext,
	Infor ntext,
	CategoryId int,
		Constraint FK_CategoryId foreign key (CategoryId) references Category(CategoryId)
)


insert into Product(ProductCode, ProductName, Price, UrlPicture, Quantity, Description, CategoryId)
values('SP001', N'Dưa hấu', 30000, 'duahau.jpg', 100, N'Dưa hấu sạch, trọng lượng 5kg/1 quả', 2)
insert into Product(ProductCode, ProductName, Price, UrlPicture, Quantity, Description, CategoryId, Unit)
values('SP002', N'Hàu sống', 40000, 'hau.jpg', 100, N'Hàu sống tự nhiên, tươi sống', 3, 'con')
insert into Product(ProductCode, ProductName, Price, UrlPicture, Quantity, Description, CategoryId, Unit)
values('SP003', N'Sườn xào chua ngọt', 60000, 'suonxaochuangot.jpg', 100, N'Nguyên liệu để làm sườn non(Cho 4 người ăn)', 5, N'đĩa')
insert into Product(ProductCode, ProductName, Price, UrlPicture, Quantity, Description, CategoryId, Unit)
values('SP004', N'Bánh đa cua', 30000, 'banhdacua.jpg', 100, N'Bánh đa cua đóng gói', 5, N'Cái')
insert into Product(ProductCode, ProductName, Price, UrlPicture, Quantity, Description, CategoryId, Unit)
values('SP005', N'Cá kho tiêu', 20000, 'cakhotieu.jpg', 100, N'Cá kho', 5, N'Nồi')
insert into Product(ProductCode, ProductName, Price, UrlPicture, Quantity, Description, CategoryId, Unit)
values('SP006', N'Chuối', 30000, 'chieutieu.jpg', 100, N'Chuối nải chín từ 10-15 quả', 2, N'Nải')
insert into Product(ProductCode, ProductName, Price, UrlPicture, Quantity, Description, CategoryId, Unit)
values('SP007', N'Nước nắm', 30000, 'nuocmamcacom.jpg', 100, N'Nước mắm Nam Ngư', 6, 'Chai')
insert into Product(ProductCode, ProductName, Price, UrlPicture, Quantity, Description, CategoryId, Unit)
values('SP008', N'Rượu mơ', 30000, 'ruoumo.jpg', 100, N'Rượu mơ đóng chai', 6, 'Chai')
insert into Product(ProductCode, ProductName, Price, UrlPicture, Quantity, Description, CategoryId, Unit)
values('SP009', N'Tương ớt', 30000, 'tuongot.jpg', 100, N'Tương ớt cay', 6, 'Chai')
insert into Product(ProductCode, ProductName, Price, UrlPicture, Quantity, Description, CategoryId, Unit)
values('SP010', N'Tôm hùm', 700000, 'tomhum.jpg', 100, N'Tôm hùm tươi sống', 3, 'Kg')
insert into Product(ProductCode, ProductName, Price, UrlPicture, Quantity, Description, CategoryId, Unit)
values('SP011', N'Cà rốt', 30000, 'carot.jpg', 100, N'Cà rốt', 1, 'Kg')

insert into Product(ProductCode, ProductName, Price, UrlPicture, Quantity, Description, CategoryId)
values('SP012', N'Dưa hấu', 30000, 'duahau.jpg', 100, N'Dưa hấu sạch, trọng lượng 5kg/1 quả', 2)
insert into Product(ProductCode, ProductName, Price, UrlPicture, Quantity, Description, CategoryId, Unit)
values('SP013', N'Hàu sống', 40000, 'hau.jpg', 100, N'Hàu sống tự nhiên, tươi sống', 3, 'con')
insert into Product(ProductCode, ProductName, Price, UrlPicture, Quantity, Description, CategoryId, Unit)
values('SP022', N'Sườn xào chua ngọt', 60000, 'suonxaochuangot.jpg', 100, N'Nguyên liệu để làm sườn non(Cho 4 người ăn)', 5, N'đĩa')
insert into Product(ProductCode, ProductName, Price, UrlPicture, Quantity, Description, CategoryId, Unit)
values('SP014', N'Bánh đa cua', 30000, 'banhdacua.jpg', 100, N'Bánh đa cua đóng gói', 5, N'Cái')
insert into Product(ProductCode, ProductName, Price, UrlPicture, Quantity, Description, CategoryId, Unit)
values('SP015', N'Cá kho tiêu', 20000, 'cakhotieu.jpg', 100, N'Cá kho', 5, N'Nồi')
insert into Product(ProductCode, ProductName, Price, UrlPicture, Quantity, Description, CategoryId, Unit)
values('SP016', N'Chuối', 30000, 'chieutieu.jpg', 100, N'Chuối nải chín từ 10-15 quả', 2, N'Nải')
insert into Product(ProductCode, ProductName, Price, UrlPicture, Quantity, Description, CategoryId, Unit)
values('SP017', N'Nước nắm', 30000, 'nuocmamcacom.jpg', 100, N'Nước mắm Nam Ngư', 6, 'Chai')
insert into Product(ProductCode, ProductName, Price, UrlPicture, Quantity, Description, CategoryId, Unit)
values('SP018', N'Rượu mơ', 30000, 'ruoumo.jpg', 100, N'Rượu mơ đóng chai', 6, 'Chai')
insert into Product(ProductCode, ProductName, Price, UrlPicture, Quantity, Description, CategoryId, Unit)
values('SP019', N'Tương ớt', 30000, 'tuongot.jpg', 100, N'Tương ớt cay', 6, 'Chai')
insert into Product(ProductCode, ProductName, Price, UrlPicture, Quantity, Description, CategoryId, Unit)
values('SP020', N'Tôm hùm', 700000, 'tomhum.jpg', 100, N'Tôm hùm tươi sống', 3, 'Kg')
insert into Product(ProductCode, ProductName, Price, UrlPicture, Quantity, Description, CategoryId, Unit)
values('SP021', N'Cà rốt', 30000, 'carot.jpg', 100, N'Cà rốt', 1, 'Kg')


insert into Product(ProductCode, ProductName, Price, UrlPicture, Quantity, Description, CategoryId)
values('SP012', N'Dưa hấu', 30000, 'duahau.jpg', 100, N'Dưa hấu sạch, trọng lượng 5kg/1 quả', 2)
insert into Product(ProductCode, ProductName, Price, UrlPicture, Quantity, Description, CategoryId, Unit)
values('SP013', N'Hàu sống', 40000, 'hau.jpg', 100, N'Hàu sống tự nhiên, tươi sống', 3, 'con')
insert into Product(ProductCode, ProductName, Price, UrlPicture, Quantity, Description, CategoryId, Unit)
values('SP022', N'Sườn xào chua ngọt', 60000, 'suonxaochuangot.jpg', 100, N'Nguyên liệu để làm sườn non(Cho 4 người ăn)', 5, N'đĩa')
insert into Product(ProductCode, ProductName, Price, UrlPicture, Quantity, Description, CategoryId, Unit)
values('SP014', N'Bánh đa cua', 30000, 'banhdacua.jpg', 100, N'Bánh đa cua đóng gói', 5, N'Cái')
insert into Product(ProductCode, ProductName, Price, UrlPicture, Quantity, Description, CategoryId, Unit)
values('SP015', N'Cá kho tiêu', 20000, 'cakhotieu.jpg', 100, N'Cá kho', 5, N'Nồi')
insert into Product(ProductCode, ProductName, Price, UrlPicture, Quantity, Description, CategoryId, Unit)
values('SP016', N'Chuối', 30000, 'chieutieu.jpg', 100, N'Chuối nải chín từ 10-15 quả', 2, N'Nải')
insert into Product(ProductCode, ProductName, Price, UrlPicture, Quantity, Description, CategoryId, Unit)
values('SP017', N'Nước nắm', 30000, 'nuocmamcacom.jpg', 100, N'Nước mắm Nam Ngư', 6, 'Chai')
insert into Product(ProductCode, ProductName, Price, UrlPicture, Quantity, Description, CategoryId, Unit)
values('SP018', N'Rượu mơ', 30000, 'ruoumo.jpg', 100, N'Rượu mơ đóng chai', 6, 'Chai')
insert into Product(ProductCode, ProductName, Price, UrlPicture, Quantity, Description, CategoryId, Unit)
values('SP019', N'Tương ớt', 30000, 'tuongot.jpg', 100, N'Tương ớt cay', 6, 'Chai')
insert into Product(ProductCode, ProductName, Price, UrlPicture, Quantity, Description, CategoryId, Unit)
values('SP020', N'Tôm hùm', 700000, 'tomhum.jpg', 100, N'Tôm hùm tươi sống', 3, 'Kg')
insert into Product(ProductCode, ProductName, Price, UrlPicture, Quantity, Description, CategoryId, Unit)
values('SP021', N'Cà rốt', 30000, 'carot.jpg', 100, N'Cà rốt', 1, 'Kg')

SELECT  *
FROM Product
ORDER BY ProductId 
OFFSET 32 ROWS 
FETCH NEXT 16 ROWS ONLY 

create table OrderProduct(
	OrderId int primary key not null identity(1,1),
	OrderedDate datetime,
	Active int, -- 0: chưa thanh toán, 1: đã thanh toán
	FullName nvarchar(100),
	PhoneNumber nvarchar(12),
	Email nvarchar(100),
	Address nvarchar(200),
	Quantity int,
	Total float,
	Description ntext
)

create table OrderDetail(
	Quantity int,
	ProductId int,
	OrderId int,
		Constraint FK_ProductId foreign key (ProductId) references Product(ProductId),
		Constraint FK_OrderId foreign key (OrderId) references OrderProduct(OrderId)
)

-------Store Produces--------
create proc Proc_InsertOrderProduct(@FullName nvarchar(100), @Active int, @PhoneNumber nvarchar(12),
@Email nvarchar(100), @Address nvarchar(200), @Quantity int, @Total float, @Description ntext)
as
begin
	insert into OrderProduct values(GETDATE(), @Active, @FullName, @PhoneNumber, @Email, @Address, @Quantity, @Total, @Description)
end

create proc Proc_InsertOrderDetail(@ProductId int, @Quantity int)
as
begin
	declare @OrderId int
	select @OrderId = Max(OrderProduct.OrderId) from OrderProduct
	insert into OrderDetail values(@Quantity, @ProductId, @OrderId)
end

create proc Proc_InsertAccount(@UserName nvarchar(50), @FullName nvarchar(100), @Password nvarchar(50), @Address nvarchar(200), @PhoneNumber nvarchar(12), @Email nvarchar(100), @IsAdmin int)
as
begin
	if not exists (select * from UserAccount where UserName = @UserName)
	begin
		insert into UserAccount(UserName, FullName, Password, Address, PhoneNumber, Email, IsAdmin) 
		values(@UserName, @FullName, @Password, @Address, @PhoneNumber, @Email, @IsAdmin)
	end
end
