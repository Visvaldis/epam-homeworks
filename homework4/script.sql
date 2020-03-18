-- Запрос 1
SELECT p.Name as Position, Count(epp.position_id) as People_Count
From Positions p Left Join EmployeeProjectPosition epp
On p.id = epp.position_id
Group by p.Name;

-- Запрос 2
SELECT p.Name as Position
From Positions p Left Join EmployeeProjectPosition epp
On p.id = epp.position_id
Group by p.Name
Having Count(epp.position_id) = 0;

-- Запрос 3
SELECT p.Name, pos.Name, Count(epp.position_id)
From Projects p Left Join EmployeeProjectPosition epp
On p.id = epp.project_id
	Join Positions pos on epp.position_id = pos.id
Group by p.Name, pos.Name
Order by p.Name, pos.Name;

-- Запрос 4
Select Projects.Name, 
(CAST(Count(t.Name) AS float) 
   / CAST(Count(Distinct epp.employee_id) AS float))
		 as AVG_Tasks
From Tasks t RIGHT Join EmployeeProjectPosition epp
ON t.EPP_id = epp.id , Projects
WHere Projects.id = epp.project_id

Group by Projects.Name
Order by Projects.Name;

-- Запрос 5
SELECT p.Name, 
CASE
 WHEN GETDATE() < p.EndDate
 Then  DATEDIFF(month, p.CreationDate, GETDATE())
 ELSE DATEDIFF(month,  p.CreationDate, p.EndDate)
END  as Project_Life_in_Month
From Projects p
Where  p.CreationDate < GETDATE();

-- Запрос 6
select LastName, FirstName, kount from Employees, (
SELECT employee_id, COUNT(t.id) AS kount
  FROM EmployeeProjectPosition epp 
  JOIN Tasks AS t ON t.EPP_id = epp.id
      Join Status_Task_Info sti
		on t.Status_Info_id = sti.id 
	Where sti.Status_id <>  4
GROUP BY employee_id
      having COUNT(t.id) = (SELECT MIN(myCount)  
	   	FROM (
               SELECT employee_id, COUNT(t.id) AS myCount
                 FROM EmployeeProjectPosition epp
                 JOIN Tasks t ON t.EPP_id = epp.id
                 Join Status_Task_Info sti
						on t.Status_Info_id = sti.id 
						Where sti.Status_id <>  4
             GROUP BY employee_id
				 ) as tt )
) AS tm
where id = employee_id ;
-- Запрос 7 	
select LastName, FirstName, kount from Employees, (
SELECT employee_id, COUNT(t.id) AS kount
  FROM EmployeeProjectPosition epp 
  JOIN Tasks AS t ON t.EPP_id = epp.id
      Join Status_Task_Info sti
						on t.Status_Info_id = sti.id 
						Where sti.Status_id <>  4
GROUP BY employee_id
      having COUNT(t.id) = (SELECT MAX(myCount)  
	   	FROM (
               SELECT employee_id, COUNT(t.id) AS myCount
                 FROM EmployeeProjectPosition epp
                 JOIN Tasks t ON t.EPP_id = epp.id
                 Join Status_Task_Info sti
						on t.Status_Info_id = sti.id 
						Where sti.Status_id <>  4
						and t.DeadlineDate < GETDATE()
             GROUP BY employee_id
				 ) as tt )
) AS tm
where id = employee_id ;

-- Запрос 8
Select t.Name, t.DeadlineDate, s."Status"
From Tasks t Join Status_Task_Info sti
on t.Status_Info_id = sti.id 
Join "Status" s On sti.Status_id = s.id
Where s.id <>  4;

Update Tasks
Set Tasks.DeadlineDate = DATEADD(day, 5, Tasks.DeadlineDate)
from Tasks, Status_Task_Info 
Where  Status_Task_Info.Status_id <>  4
 and Tasks.Status_Info_id = Status_Task_Info.id;

Select t.Name, t.DeadlineDate, s."Status"
From Tasks t Join Status_Task_Info sti
on t.Status_Info_id = sti.id 
Join "Status" s On sti.Status_id = s.id
Where s.id <>  4;


-- Запрос 9
Select p.Name, Count(t.Name) as Open_tasks
From Projects p Join EmployeeProjectPosition epp
On p.id = epp.project_id
	Join Tasks t On t.EPP_id = epp.id	
	Join Status_Task_Info sti On sti.id = t.Status_Info_id
	Where sti.Status_id =  1
Group by p.Name

-- Запрос 10
 
 SELECT p.Name, p.isOpen, t.Name, s."Status"
FROM Projects p 
	JOIN EmployeeProjectPosition epp ON p.id = epp.project_id
	JOIN Tasks t ON t.EPP_id = epp.id
	JOIN Status_Task_Info sti ON t.Status_Info_id = sti.id
	JOIN "Status" s ON sti.Status_id = s.id;
	
	
UPDATE Projects
Set Projects.isOpen = 0, 
Projects.EndDate =tt.max_date 

from Projects, (Select pr.id as proj_id, max(sti1.StatusDate) as max_date
    from Projects pr
      Join EmployeeProjectPosition epp1 on pr.id = epp1.project_id
      JOIN Tasks t1 ON t1.EPP_id = epp1.id
      JOIN Status_Task_Info sti1 ON t1.Status_Info_id = sti1.id 
    Where not exists (
      select 1
      from EmployeeProjectPosition epp
        JOIN Tasks t ON t.EPP_id = epp.id
        JOIN Status_Task_Info sti ON t.Status_Info_id = sti.id 
      where  sti.Status_id != 4
        and pr.id = epp.project_id) 
    group by pr.id
    having Count (t1.id) <> 0) as tt

  where Projects.id = tt.proj_id


	
	 SELECT p.Name, p.isOpen, t.Name, s."Status", p.EndDate
FROM Projects p 
	JOIN EmployeeProjectPosition epp ON p.id = epp.project_id
	JOIN Tasks t ON t.EPP_id = epp.id
	JOIN Status_Task_Info sti ON t.Status_Info_id = sti.id
	JOIN "Status" s ON sti.Status_id = s.id
	

-- Запрос 11
Select em.FirstName, em.LastName
from Employees em
	Join EmployeeProjectPosition epp1 on em.id = epp1.employee_id
	JOIN Tasks t1 ON t1.EPP_id = epp1.id
	JOIN Status_Task_Info sti1 ON t1.Status_Info_id = sti1.id 
Where not exists (
	select 1
	from EmployeeProjectPosition epp
		JOIN Tasks t ON t.EPP_id = epp.id
		JOIN Status_Task_Info sti ON t.Status_Info_id = sti.id 
	where	sti.Status_id != 4
		and em.id = epp.employee_id)
group by em.FirstName, em.LastName
having Count (t1.id) <> 0


-- Запрос 12
Select e.FirstName, e.LastName, t.Name
From Employees e
	Join EmployeeProjectPosition epp On e.id = epp.employee_id
	Join Tasks t On epp.id = t.EPP_id;

Update Tasks
Set Tasks.EPP_id = (Select top 1 epp.id
From Employees e
	Join EmployeeProjectPosition epp On e.id = epp.employee_id
	join Tasks t ON epp.id = t.EPP_id
Where epp.project_id  = 
		(Select epp.project_id
		From EmployeeProjectPosition epp 
			join Tasks t ON epp.id = t.EPP_id
		Where t.Name =  'DAL Creation')
Group by epp.id
Order by Count(t.id))
Where Tasks.Name =  'DAL Creation'

Select e.FirstName, e.LastName, t.Name
From Employees e
	Join EmployeeProjectPosition epp On e.id = epp.employee_id
	Join Tasks t On epp.id = t.EPP_id;