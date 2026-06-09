CREATE VIEW vw_Billing
AS
SELECT 
    c.ClaimId,
    c.Status,
    c.BilledAmount,
    c.ReimbursedAmt,
    (c.BilledAmount - ISNULL(c.ReimbursedAmt, 0)) AS OutstandingAmount
FROM Claim c;