
CREATE PROCEDURE sp_HighRiskPatients
AS
BEGIN
    SELECT 
        PatientId,
        COUNT(DISTINCT EncounterId) AS Visits
    FROM Encounter
    GROUP BY PatientId
    HAVING COUNT(*) >= 3;
END;