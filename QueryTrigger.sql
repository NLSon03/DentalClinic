-- Tạo trigger update số lượng tool sau khi thêm, xóa hoặc sửa
create trigger updateSoLuongTool
on DentalToolTransactionsDetails
for INSERT, UPDATE, DELETE
AS
BEGIN
	declare @type bit;
	declare @transactionid int;
	declare @soluong int;
	declare @toolid int;
	declare @soluongbefore int;
	if exists(SELECT * from inserted) and exists (SELECT * from deleted)
	begin
		select @toolid = i.ToolID, @transactionid = i.TransactionID, @soluong = i.Quantity from inserted i
		select @type = transactiontype from DentalToolTransactions where @transactionid = transactionid
		select @soluongbefore = deleted.Quantity from deleted
		if (@type = 0)
			update DentalTools 
			set Quantity = Quantity + @soluong - @soluongbefore
			where ToolID = @toolid
		else
		begin
			declare @t int;
			select @t = Quantity from DentalTools
			if (@soluongbefore + @t < @soluong)
			begin
				update DentalToolTransactionsDetails
				set Quantity = @soluongbefore + @t
				where @toolid = ToolID
				update DentalTools
				set Quantity = 0
				where @toolid = ToolID
			end
			else
				update DentalTools 
				set Quantity = Quantity - @soluong + @soluongbefore
				where ToolID = @toolid
		end
	end
	if exists (Select * from inserted) and not exists(Select * from deleted)
	begin
		select @transactionid = inserted.transactionid, @soluong = inserted.Quantity, @toolid = inserted.toolid from inserted
		select @type = transactiontype from DentalToolTransactions where @transactionid = transactionid
		if (@type = 0)
			update DentalTools
			set Quantity = Quantity + @soluong
			where ToolID = @toolid
		else
		begin
			select @soluongbefore = Quantity from DentalTools
			if (@soluongbefore < @soluong)
			begin
				update DentalToolTransactionsDetails
				set Quantity = @soluongbefore
				where ToolID = @toolid
				set @soluong = @soluongbefore
			end
			update DentalTools
			set Quantity = Quantity - @soluong
			where ToolID = @toolid 
		end
	end
	if exists (Select * from deleted) and not exists (select * from inserted)
	begin
		select @transactionid = deleted.transactionid, @soluong = deleted.Quantity, @toolid = deleted.toolid from deleted
		select @type = transactiontype from DentalToolTransactions where @transactionid = transactionid
		if (@type = 0)
			update DentalTools
			set Quantity = Quantity - @soluong
			where ToolID = @toolid
		else
			update DentalTools
			set Quantity = Quantity + @soluong
			where ToolID = @toolid
	end
end


--Tạo trigger update Tổng thành tiền hóa đơn nhập xuất sau khi thêm, xóa, sửa
create trigger updateTienNhapXuat
on DentalToolTransactionsDetails
for INSERT, UPDATE, DELETE
AS
BEGIN
	declare @transactionid int;
	if (exists(SELECT * from inserted) and exists (SELECT * from deleted)) or (exists (Select * from inserted) and not exists(Select * from deleted))
	begin
		select @transactionid = inserted.TransactionID from inserted
		update DentalToolTransactions set TotalAmount = (select sum(TotalAmount) from DentalToolTransactionsDetails where @transactionid = TransactionID)
		where @transactionid = TransactionID
	end
	if exists (Select * from deleted) and not exists (select * from inserted)
	begin
		select @transactionid = deleted.TransactionID from deleted
		update DentalToolTransactions set TotalAmount = (select sum(TotalAmount) from DentalToolTransactionsDetails where @transactionid = TransactionID)
		where @transactionid = TransactionID
	end
end

--Tạo trigger update tổng tiền hóa đơn
create trigger updateTienHD
on InvoiceDetails
for INSERT, UPDATE, DELETE
as
begin
	declare @mahd int;
	if (exists(SELECT * from inserted) and exists (SELECT * from deleted)) or (exists (Select * from inserted) and not exists(Select * from deleted))
	begin
		select @mahd = inserted.InvoiceID from inserted
		update Invoice set TotalPayment = (select sum(TotalAmount) from InvoiceDetails where @mahd = InvoiceID)
		where @mahd = InvoiceID
	end
	if exists (Select * from deleted) and not exists (select * from inserted)
	begin
		select @mahd = deleted.InvoiceID from deleted
		update Invoice set TotalPayment = (select sum(TotalAmount) from InvoiceDetails where @mahd = InvoiceID)
		where @mahd = InvoiceID
	end
end

--Tạo trigger update thành tiền đơn thuốc
create trigger updateTienThuoc
on PrescriptionDetails
for INSERT, UPDATE, DELETE
as
begin
	declare @madonthuoc int;
	if (exists(SELECT * from inserted) and exists (SELECT * from deleted)) or (exists (Select * from inserted) and not exists(Select * from deleted))
	begin
		select @madonthuoc = inserted.PrescriptionID from inserted
		update Prescription set TotalAmount = (select sum(TotalAmount) from PrescriptionDetails where @madonthuoc = PrescriptionID)
		where @madonthuoc = PrescriptionID
	end
	if exists (Select * from deleted) and not exists (select * from inserted)
	begin
		select @madonthuoc = deleted.PrescriptionID from deleted
		update Prescription set TotalAmount = (select sum(TotalAmount) from PrescriptionDetails where @madonthuoc = PrescriptionID)
		where @madonthuoc = PrescriptionID
	end
end
select * from WarrantyInformation

create trigger addWarranty
on SubClinicalInformation
for INSERT, UPDATE
as
begin
	declare @mawar int;
	select @mawar = inserted.WarrantyID from inserted
	if not exists (select * from WarrantyInformation where @mawar = WarrantyID)
		insert into WarrantyInformation values (@mawar,null)
end

create trigger deleteTheoBN
on PatientInformation
for delete
as
begin
	declare @mabn int;
	select @mabn = deleted.PatientID from deleted
	delete from SubClinicalInformation where PatientID = @mabn
	delete from ClinicalInformation where PatientID = @mabn
end

create trigger deleteTheoPhieuKhamBenh
on ClinicalInformation
for delete
as
begin
	declare @mapkb int;
	select @mapkb = deleted.ClinicalInfoID from deleted
	delete from Prescription where ClinicalInfoID = @mapkb
	delete from Invoice where ClinicalInfoID = @mapkb
	delete from ClinicalInformationDetails where ClinicalInfoID = @mapkb
end

create trigger deletetheoHoadon
on Invoice
for delete
as
begin
	declare @mahd int;
	select @mahd = deleted.InvoiceID from deleted
	delete from InvoiceDetails where InvoiceID = @mahd
end

create trigger deletetheoCTKhamBenh
on ClinicalInformationDetails
for delete
as
begin
	declare @idctkb int;
	select @idctkb = deleted.ID from deleted
	delete from InvoiceDetails where ClinicalInfoDetailsID = @idctkb
end

create trigger deletetheoDonthuoc
on Prescription
for delete
as
begin
	declare @madonthuoc int;
	select @madonthuoc = deleted.PrescriptionID from deleted
	delete from PrescriptionDetails where PrescriptionID = @madonthuoc
end

create trigger deletetheoThuoc
on Medicine
for delete
as
begin
	declare @mathuoc int;
	select @mathuoc = deleted.MedicineID from deleted
	delete from PrescriptionDetails where MedicineID = @mathuoc
end

create trigger deletetheoDV
on Diagnosis_Treatment
for delete
as
begin
	declare @madv int
	select @madv = deleted.Diagnosis_Treatment_ID from deleted
	delete from ClinicalInformationDetails where @madv = Diagnosis_Treatment_ID
end

create trigger deletetheoDungcuNhakhoa
on DentalTools
for delete
as
begin
	declare @madungcu int
	select @madungcu = deleted.ToolID from deleted
	delete from DentalToolTransactionsDetails where @madungcu = ToolID
end

create trigger deletetheoHoaDonNhapXuat
on DentalToolTransactions
for delete
as
begin
	declare @manhapxuat int
	select @manhapxuat = deleted.TransactionID from deleted
	delete from DentalToolTransactionsDetails where @manhapxuat = TransactionID
end

--Trigger update Tien trong CTHD
create trigger updateTienCTHD
on InvoiceDetails
for Insert, UPDATE
as
begin
	declare @macthd int
	select @macthd = inserted.ClinicalInfoDetailsID from inserted
	update InvoiceDetails
	set TotalAmount = (select sum(TotalAmount) from ClinicalInformationDetails where @macthd = ID)
end