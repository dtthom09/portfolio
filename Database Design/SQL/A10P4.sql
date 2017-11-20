--part4
--List the names of pilots who have flown the most miles
select ED.EMP_LNAME, ED.EMP_FNAME, ED.EMP_CODE, SUM(F.CHAR_DISTANCE) AS[DistanceFlown]
from EmployeeDim ED 
	 inner join Fact F on ED.EMP_CODE = F.EMP_CODE
group by ED.EMP_LNAME, ED.EMP_FNAME, ED.EMP_CODE
Having SUM(F.CHAR_DISTANCE) =( select top 1 SUM(char_Distance) 
							   from Fact 
							   group by EMP_CODE 
							   order by SUM(char_Distance) desc )

--List the revenue by model and month in ascending order.
select F.Revenue, AD.MOD_NAME, Month(TD.CHAR_DATE) AS [month]
from Fact F 
	 inner join AIRPLANEDIM AD on F.AC_CODE = AD.AC_CODE
	 inner join TimeDim TD on F.Time_ID = TD.Time_ID
order by F.Revenue
