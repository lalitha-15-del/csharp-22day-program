select p.FullName as ProviderName,
d.Name as DepartmentName,
Count(e.EncounterId) as TotalEncounters,
Rank() over (Order by count(e.EncounterId) Desc) as ProviderRank
from Provider p
join Department d 
on p.DepartmentId = d.DepartmentId
JOIN Encounter e 
    ON p.ProviderId = e.ProviderId
group by p.FullName, d.Name

