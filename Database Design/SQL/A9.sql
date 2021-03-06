USE [CIS31047]
GO
/****** Object:  Trigger [dbo].[trg_mem_balance]    Script Date: 11/21/2016 10:23:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER trigger [dbo].[trg_mem_balance]
on [dbo].[DETAILRENTAL]
after update
as
begin
	select 'content of inserted'
	select * from inserted
	select 'content of deleted'
	select * from deleted


	declare @rent_num int
	declare @priorLateFee decimal(5,2)
	declare @afterLateFee decimal(5,2)
	declare @change decimal(5,2)
	declare @mem_num char(3)

	select * from inserted
	select * from deleted
	begin
			declare Update_Cursor
			Cursor for
			select i.Rent_Num, ISNULL (DATEDIFF(DAY, d.Detail_DueDate, d.Detail_ReturnDate)* d.Detail_DailyLateFee, 0) AS [priorLateFee], 
				   ISNULL (DATEDIFF(DAY,i.Detail_DueDate, i.Detail_ReturnDate)* i.Detail_DailyLateFee, 0) AS [afterLateFee],
				   (ISNULL (DATEDIFF(DAY,i.Detail_DueDate, i.Detail_ReturnDate)* i.Detail_DailyLateFee, 0) - 
				   ISNULL (DATEDIFF(DAY, d.Detail_DueDate, d.Detail_ReturnDate)* d.Detail_DailyLateFee, 0)) as [change]
			from deleted d
				 inner join inserted i on i.Rent_Num = d.Rent_Num 
			order by afterLateFee  desc		

			Open Update_Cursor
			Fetch next from Update_Cursor
			Into @rent_num, @priorLateFee, @afterLateFee, @change
			set @mem_num = (select mem_num 
							from RENTAL 
							where Rent_Num = @rent_num)

			if @change > 0
			while(@@FETCH_STATUS=0)
			begin
				update MEMBERSHIP
				set Mem_Balance = Mem_Balance- @change
				where mem_num = @mem_num
				fetch next from update_cursor
				into @rent_num, @priorLateFee, @afterLateFee, @change

			end
			close update_cursor
			deallocate update_cursor
	end
end

