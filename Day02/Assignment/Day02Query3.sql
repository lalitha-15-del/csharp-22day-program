
CREATE PROCEDURE sp_RevenueLeakageReport
AS
BEGIN
    SELECT 
        Status,
        COUNT(*) AS TotalClaims,
        SUM(BilledAmount) AS TotalBilledAmount,
        SUM(ISNULL(ReimbursedAmt, 0)) AS TotalReimbursedAmount,
        SUM(BilledAmount - ISNULL(ReimbursedAmt, 0)) AS OutstandingAmount,
        RANK() OVER (
            ORDER BY SUM(BilledAmount - ISNULL(ReimbursedAmt, 0)) DESC
        ) AS LossRank
    FROM Claim
    GROUP BY Status;
END;
