--1
select c.customerId, c.LastName, c.FirstName, b.ModelType, p.ColorList, b.OrderDate, b.SaleState
from customer c
inner join bicycle b on c.customerid = b.customerid
inner join city on c.cityid = city.cityid
inner join Paint p on p.PaintID = b.PaintID
	where city.State like 'CA' and b.PaintID = '14' 
	and b.modeltype like 'Mountain%' 
	and b.orderdate >= '01-sep-03' and b.OrderDate <= '30-sep-03'

--2
select b.EmployeeID, c.LastName, b.SaleState, b.ModelType, b.StoreID, b.OrderDate
from bicycle b
inner join customer c on b.CustomerID = c.CustomerID
where ModelType like 'Race' 
	  and SaleState like 'WI' 
	  and (StoreID = 1 or StoreID = 2) 
	  and year(ShipDate) = 2001

--3
select distinct c.ComponentID, m.ManufacturerID, c.ProductNumber
from Component c 
inner join Manufacturer m on c.ManufacturerID = m.ManufacturerID
inner join BikeParts bp on c.ComponentID = bp.ComponentID
inner join Bicycle b on bp.SerialNumber = b.SerialNumber
where c.Category = 'Rear derailleur'
      and b.ModelType = 'Road'
	  and year(b.OrderDate) = '2002'
	  and b.SaleState = 'FL'

--4
select c.CustomerID, c.LastName, c.FirstName, b.ModelType, b.SaleState, b.FrameSize 
from Customer c 
	 inner join Bicycle b on c.CustomerID = b.CustomerID
	 inner join ModelType mt on b.ModelType = mt.ModelType
where mt.Description = 'Full suspension mountain bike'
	  and b.SaleState = 'GA'
	  and year(b.orderdate) = '2004'
	  and b.FrameSize = (select max(FrameSize) 
					     from customer c
						 inner join Bicycle b on c.CustomerID = b.CustomerID
						 inner join ModelType mt on b.ModelType = mt.ModelType
					     where mt.Description = 'Full suspension mountain bike'
						 and year(b.orderdate) = '2004'
						 and b.SaleState = 'GA')

--5
select  top 1 m.ManufacturerID, m.ManufacturerName
from Manufacturer m 
	 inner join Component c on m.ManufacturerID = c.ManufacturerID
	 inner join PurchaseItem pi on c.ComponentID = pi.ComponentID
	 inner join PurchaseOrder po on pi.PurchaseID = po.PurchaseID
 
	  where Discount in (select max(Discount)
						 from PurchaseOrder
						 where year(OrderDate) = 2003) 

--6
select c.Category, m.ManufacturerName, c.ProductNumber, c.Road, c.Category, c.ListPrice,  c.QuantityOnHand
from Component c
     inner join Manufacturer m on c.ManufacturerID = m.ManufacturerID
where ListPrice = (select max(ListPrice)
				   from Component
				   where QuantityOnHand > 200)

--7
select c.ComponentID, m.ManufacturerName, c.ProductNumber, c.Category, c.Year, c.EstimatedCost AS [VALUE]
from component c
     inner join Manufacturer m on c.ManufacturerID = m.ManufacturerID
where c.ListPrice = (select max(ListPrice)
					 from Component)

--8
select bp.EmployeeID, e.LastName, bp.DateInstalled, count(bp.ComponentID) AS [count of components]
from BikeParts bp
	 inner join Employee e on bp.EmployeeID = e.EmployeeID
where bp.DateInstalled is not null
group by bp.DateInstalled, bp.EmployeeID, e.LastName
having count(bp.ComponentID) = (select top 1 count(bp.ComponentID) AS [count of components]
								from BikeParts bp
									 inner join Employee e on bp.EmployeeID = e.EmployeeID
								where bp.DateInstalled is not null
								group by bp.DateInstalled, bp.EmployeeID, e.LastName
								order by count(bp.ComponentID) DESC)

--9
select top 1 LetterStyleID, count(SerialNumber) as [CountOfSerialNumber]
from bicycle
where ModelType = 'Race' and year(orderdate) = 2003
group by LetterStyleID, year(orderdate), ModelType
order by CountofSerialNumber DESC

--10
select ct.CustomerID, c.LastName, c.FirstName, count(b.SerialNumber) AS [Number of bikes], sum(ct.Amount) AS [Amount spent]
from CustomerTransaction ct
     inner join Customer c on ct.CustomerID = c.CustomerID
	 inner join Bicycle b on  c.CustomerID = b.CustomerID
where ct.Description like '%single/final%'
	  and ct.TransactionDate like '%2002%'
group by Ct.CustomerID, c.LastName, c.FirstName
having sum(ct.Amount) = (select top 1 sum(ct.Amount)
						 from CustomerTransaction ct
						 inner join Customer c on ct.CustomerID = c.CustomerID
						 inner join Bicycle b on  c.CustomerID = b.CustomerID
						 where ct.Description like '%single/final%'
						    and ct.TransactionDate like '%2002%'
						 group by c.CustomerID, c.LastName, c.FirstName
						 order by sum(ct.Amount))

--11
select year(OrderDate) as [SaleYear], count(serialnumber) AS [CountOfSerialNumber]
from Bicycle
where ModelType Like 'mountain%'
group by year(OrderDate)
having year(OrderDate) between 2000 AND 2004
order by year(OrderDate)DESC

--12
select c.ComponentID, m.ManufacturerName, c.ProductNumber, c.Category, sum(pit.pricepaid) as [value]
from Component c inner join PurchaseItem pit on c.ComponentID =pit.ComponentID
	 inner join PurchaseOrder po on pit.PurchaseID = po.PurchaseID
     inner join Manufacturer m on po.ManufacturerID = m.ManufacturerID
where year(po.OrderDate) = 2003
group by c.ComponentID, m.ManufacturerName, year(po.OrderDate), c.ProductNumber, c.Category
having sum(pit.pricepaid) = (select top 1 sum(pit.pricepaid)
							 from Component c
								  inner join PurchaseItem pit on c.ComponentID =pit.ComponentID
								  inner join PurchaseOrder po on pit.PurchaseID = po.PurchaseID
								  inner join Manufacturer m on po.ManufacturerID = m.ManufacturerID
							 where year(po.OrderDate) = 2003
							 group by c.ComponentID, m.ManufacturerName, year(po.OrderDate), c.ProductNumber, c.Category
							 order by sum(pit.pricepaid) desc)

--13
select e.employeeID, e.LastName, count(b.SerialNumber) as [Number Painted]
from Employee e 
	 inner join Bicycle b on e.EmployeeID = b.EmployeeID
	 inner join paint p on b.PaintID = p.PaintID
where p.ColorList= 'red' 
      and b.ModelType LIKE '%Race%' and month(b.OrderDate)= 05 and year(b.orderdate)= 2003
group by e.EmployeeID, e.lastname
having  count(b.SerialNumber) = (select top 1 count(b.SerialNumber) as [Number Painted]
							from Employee e 
								 inner join Bicycle b on e.EmployeeID = b.EmployeeID
								 inner join paint p on b.PaintID = p.PaintID
							where p.ColorList= 'red' 
								  and b.ModelType LIKE '%Race%' and month(b.OrderDate)= 05 and year(b.orderdate)= 2003
							group by e.EmployeeID, e.lastname
							order by count(b.SerialNumber) desc)

--14
select b.StoreID
from RetailStore r inner join city c on r.CityID = c.CityID
	 inner join Bicycle b on r.StoreID = b.StoreID
where c.state = 'CA' 
      and year(b.OrderDate) = 2003
group by b.StoreID, c.state
having sum(b.SalePrice) =(select top 1 sum(b.SalePrice)
						  from RetailStore r inner join city c on r.CityID = c.CityID
							   inner join Bicycle b on r.StoreID = b.StoreID
						  where c.state = 'CA' 
							   and year(b.OrderDate) = 2003
						  group by r.StoreID, c.state
						  order by sum(b.SalePrice) desc)

--15
select sum(c.weight) AS [TotalWeight]
from Component c 
	 inner join BikeParts bp on c.ComponentID = bp.ComponentID
where bp.SerialNumber = 11356

--16
select g.groupname, sum(c.listprice) AS [SumOfListPrice]
from Groupo g
     inner join GroupComponents gc on g.ComponentGroupID = gc.GroupID
	 inner join Component c on gc.ComponentID = c.ComponentID
where g.GroupName = 'Campy Record 2002'
group by g.GroupName

--17
select tm.Material, Count(btu.SerialNumber) AS [CountOfSerialNumber]
from TubeMaterial tm 
     inner join BicycleTubeUsage btu on tm.TubeID = btu.TubeID
	 inner join Bicycle b on btu.SerialNumber = b.SerialNumber
	 inner join BikeTubes bt on b.SerialNumber = bt.SerialNumber
where year(b.StartDate) = '2003' 
	  and b.ModelType = 'race' 
	  and tm.Material like '%carbon%' or tm.Material like '%titanium%'
	  and bt.TubeName = 'down'
group by tm.Material, bt.TubeName, b.ModelType, year(b.startdate)
having count(b.SerialNumber) = (select top 1 Count(btu.SerialNumber) AS [CountOfSerialNumber]
								from TubeMaterial tm 
									 inner join BicycleTubeUsage btu on tm.TubeID = btu.TubeID
									 inner join Bicycle b on btu.SerialNumber = b.SerialNumber
									 inner join BikeTubes bt on b.SerialNumber = bt.SerialNumber
								where year(b.StartDate) = '2003' 
									 and b.ModelType = 'race' 
									 and tm.Material like '%carbon%' or tm.Material like '%titanium%'
									 and bt.TubeName = 'down'
								group by tm.Material, bt.TubeName, b.ModelType, year(b.startdate)
								order by count(b.serialnumber) desc)

--18
select AVG(pi.PricePaid) AS [AvgOfPricePaid]
from Component c
	 inner join PurchaseItem pi on c.ComponentID = pi.ComponentID
where c.Category = 'rear derailleur'
	  and c.Description like '%xtr%'
	  and c.year = '2001'

--19
select avg(bt.Length) AS [AvgOfPricePaid]
from BikeTubes bt
	 inner join bicycle b on bt.SerialNumber = b.SerialNumber
	 inner join BikeParts bp on b.SerialNumber = bp.SerialNumber
	 inner join Component c on bp.ComponentID = c.ComponentID
	 inner join GroupComponents gc on c.ComponentID = gc.ComponentID
	 inner join Groupo gp on gc.GroupID = gp.ComponentGroupID
where b.framesize = '54'
	  and b.ModelType = 'road'
	  and gp.Year = 1994
	  

--20
select Road, avg(listprice) AS [AverageListPrice]
from Component
where category = 'tire'
	  and (road = 'road' or road = 'mtb')
group by road, Category
having avg(listprice) = (select top 1 avg(listprice) AS [AverageListPrice]
						 from Component
						 where category = 'tire'
							   and (road = 'road' or road = 'mtb')
						 group by road, Category
						 order by avg(listprice) desc)

--21
select distinct e.employeeID, e.LastName
from Bicycle b
	 inner join Employee e on b.EmployeeID = e.EmployeeID
where month(b.OrderDate) = 05 
	  and year(b.OrderDate) = 2003
	  and b.ModelType = 'road'

--22
Select p.PaintID, p.ColorName, count(p.paintID) as [NumberOfBikesPainted]
from paint p
	 inner join Bicycle b on p.PaintID = b.PaintID
	 inner join LetterStyle ls on b.LetterStyleID = ls.LetterStyle
where year(b.OrderDate) = 2002
	  and ls.LetterStyle = 'english'
group by p.PaintID, p.ColorName
order by NumberOfBikesPainted DESC

--23
select SerialNumber, ModelType, OrderDate, SalePrice
from Bicycle
where ModelType = 'race'
	  and OrderDate like '%2003%'
	  and saleprice > (select avg(saleprice) AS [AverageSalesPrice]
				       from Bicycle
				       where ModelType = 'race'
							 and OrderDate like '%2002%')

--24
select distinct c.Description, c.ProductNumber, c.Category, (c.QuantityOnHand*c.EstimatedCost) as [ValueComponentID]
from bikeparts bp
	 inner join Component c on bp.ComponentID = c.ComponentID
where year(bp.dateinstalled) <> 2004 
	  and c.QuantityOnHand*c.EstimatedCost = (select max(c.quantityonhand*c.estimatedcost)
											  from bikeparts bp
												   inner join Component c on bp.ComponentID = c.ComponentID
											  where year(bp.dateinstalled) <> 2004)

--25
select m.ManufacturerName, m.Phone
from Manufacturer m
	 Inner Join City c On M.CityID=C.CityID
Where C.State like'CA'
Union Select M.ManufacturerName, R.Phone
	  From RetailStore R Inner Join City C On R.CityID=C.CityID
		   Inner Join Bicycle B On R.StoreID=B.StoreID
		   Inner Join Manufacturer M on M.CityID=R.CityID
	  Where Year(B.OrderDate)=2004 AND C.State like'CA'

--26
select EmployeeID, LastName, FirstName, Title
from Employee
where CurrentManager ='15293'

--27
Select c.ComponentID, m.ManufacturerName, c.ProductNumber, c.Category, tr.TotalReceived, tu.TotalUsed, tr.TotalReceived-tu.TotalUsed AS NetGain, 1-(TotalUsed/TotalReceived+0.0) AS NetPct, c.ListPrice
From TotalReceived tr 
	 Inner Join TotalUsed tu on tu.ComponentID = tr.ComponentID
	 Inner Join Bike.. Component c On C.ComponentID = TR.ComponentID
	 Inner Join Bike.. Manufacturer m on m.ManufacturerID = c.ManufacturerID
Where 1-(TotalUsed/(TotalReceived + 0.0))>.25
Order By C.ComponentID

--28
Select YEAR(OrderDate) AS [Year], AVG(DATEDIFF(DAY, OrderDate, ShipDate)) AS [BuildTime]
From Bicycle
Group by YEAR(OrderDate)
Having AVG(DATEDIFF(DAY, OrderDate, Shipdate)) > (Select AVG(DATEDIFF(DAY, OrderDate, Shipdate))
												  From Bicycle)