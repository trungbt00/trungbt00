CREATE TABLE NhanVien (
    Id VARCHAR(10) PRIMARY KEY,
    MaNV VARCHAR(20) UNIQUE,
    TenNV NVARCHAR(100),
    NgaySinh DATE,
    DiaChi NVARCHAR(255),
    CapBac VARCHAR(50)
);

CREATE PROCEDURE InsertNhanVien
	@Id VARCHAR(10),
    @MaNV VARCHAR(20),
    @TenNV NVARCHAR(100),
    @NgaySinh DATE,
    @DiaChi NVARCHAR(255),
    @CapBac VARCHAR(50)
AS
BEGIN
    INSERT INTO NhanVien (Id, MaNV, TenNV, NgaySinh, DiaChi, CapBac)
    VALUES (@Id, @MaNV, @TenNV, @NgaySinh, @DiaChi, @CapBac);
END;

EXEC InsertNHANVIEN 'SS1','001','Z','08-08-1985','HaNoi','Nhanvien';

CREATE PROCEDURE UpdateNhanVien
    @Id VARCHAR(10),
    @MaNV VARCHAR(20),
    @TenNV NVARCHAR(100),
    @NgaySinh DATE,
    @DiaChi NVARCHAR(255),
    @CapBac VARCHAR(50)
AS
BEGIN
    UPDATE NhanVien
    SET MaNV = @MaNV,
        TenNV = @TenNV,
        NgaySinh = @NgaySinh,
        DiaChi = @DiaChi,
        CapBac = @CapBac
    WHERE Id = @Id;
END;

EXEC UpdateNhanVien SS3,'005','D','1995-05-15','HCM','Quanly';

CREATE PROCEDURE DeleteNhanVien
    @Id VARCHAR(10)
AS
BEGIN
    DELETE FROM NhanVien
    WHERE Id = @Id;
END;

EXEC DeleteNhanVien SS1