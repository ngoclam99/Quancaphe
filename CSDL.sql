SELECT * FROM Account
SELECT * FROM BoPhan
SELECT * FROM ChiTietDoUong
SELECT * FROM ChiTietGiaoHang
SELECT * FROM ChiTietHoaDon
SELECT * FROM ChiTietNhapKho
SELECT * FROM ChiTietPhaChe
SELECT * FROM DoUong
SELECT * FROM LoaiDoUong
SELECT * FROM HoaDon
SELECT * FROM NguyenLieu
SELECT * FROM NhapKho
SELECT * FROM NhanVien

ALTER PROC check_dangnhap
@tendn nvarchar(100),
@matkhau nvarchar(255)
as
begin
	Select Account.*, NhanVien.TenNhanVien from Account
	inner join NhanVien on NhanVien.IDNhanVien = Account.IDNhanVien
	where Account.Tendangnhap = @tendn and Account.MatKhau = @matkhau
end

CREATE PROC update_matkhau_moi
@username nvarchar(50),
@pass nvarchar(255)
as
begin
	UPDATE Account set MatKhau = @pass where Tendangnhap = @username 
end