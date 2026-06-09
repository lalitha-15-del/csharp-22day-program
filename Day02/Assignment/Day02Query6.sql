CREATE VIEW vw_Clinical
AS
SELECT 
    p.PatientId,
    p.FullName,
    d.Description,
    e.EncounterType
FROM Patient p
JOIN Encounter e ON p.PatientId = e.PatientId
JOIN Diagnosis d ON e.EncounterId = d.EncounterId;
