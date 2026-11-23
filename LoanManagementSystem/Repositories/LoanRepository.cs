using System;
using System.Data;
using MySqlConnector;
using LoanManagementSystem.Database;
using LoanManagementSystem.Models;

namespace LoanManagementSystem.Repositories
{
    public class LoanRepository
    {
        private DataTable ReadTable(string sql, Action<MySqlCommand>? addParameters = null)
        {
            using (MySqlConnection con = DatabaseConnection.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(sql, con))
            {
                addParameters?.Invoke(cmd);
                con.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    DataTable table = new DataTable();
                    table.Load(reader);
                    return table;
                }
            }
        }

        public DataTable GetClients(string search = "")
        {
            return ReadTable(@"SELECT ClientID,FullName,IdentificationNumber,PhoneNumber,Address,RegistrationDate
                FROM Clients WHERE FullName LIKE @s OR IdentificationNumber LIKE @s OR PhoneNumber LIKE @s
                ORDER BY ClientID DESC", c => c.Parameters.AddWithValue("@s", "%" + search + "%"));
        }

        public void SaveClient(Client client)
        {
            string sql = client.ClientID == 0
                ? @"INSERT INTO Clients(FullName,IdentificationNumber,PhoneNumber,Address,RegistrationDate)
                    VALUES(@name,@nid,@phone,@address,@date)"
                : @"UPDATE Clients SET FullName=@name,IdentificationNumber=@nid,PhoneNumber=@phone,
                    Address=@address WHERE ClientID=@id";
            using (MySqlConnection con = DatabaseConnection.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@name", client.FullName);
                cmd.Parameters.AddWithValue("@nid", client.IdentificationNumber);
                cmd.Parameters.AddWithValue("@phone", client.PhoneNumber);
                cmd.Parameters.AddWithValue("@address", client.Address);
                cmd.Parameters.AddWithValue("@date", client.RegistrationDate);
                if (client.ClientID != 0) cmd.Parameters.AddWithValue("@id", client.ClientID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetApplications(string search = "", string status = "")
        {
            return ReadTable(@"SELECT a.ApplicationID,a.ReferenceNumber,a.ClientID,c.FullName AS Client,
                a.AmountRequested,a.Purpose,a.RepaymentPeriod,a.ApplicationDate,a.Status,
                d.DecisionStatus,d.DecisionNote,d.DecisionDate,d.ApproverID
                FROM LoanApplications a
                INNER JOIN Clients c ON a.ClientID=c.ClientID
                LEFT JOIN Decisions d ON d.ApplicationID=a.ApplicationID
                WHERE (a.ReferenceNumber LIKE @search
                    OR c.FullName LIKE @search
                    OR a.Status LIKE @search
                    OR CAST(a.ApplicationDate AS CHAR) LIKE @search)
                  AND (@status = '' OR a.Status = @status)
                ORDER BY a.ApplicationID DESC",
                c =>
                {
                    c.Parameters.AddWithValue("@search", "%" + search + "%");
                    c.Parameters.AddWithValue("@status", status);
                });
        }

        public DataTable GetClientChoices()
        {
            return ReadTable("SELECT ClientID,FullName FROM Clients ORDER BY FullName");
        }

        public void AddApplication(LoanApplication a)
        {
            string sql = @"INSERT INTO LoanApplications
                (ReferenceNumber,ClientID,AmountRequested,Purpose,RepaymentPeriod,ApplicationDate,Status,SupportingNotes)
                VALUES(@ref,@client,@amount,@purpose,@period,@date,'Pending Review',@notes)";
            using (MySqlConnection con = DatabaseConnection.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@ref", a.ReferenceNumber);
                cmd.Parameters.AddWithValue("@client", a.ClientID);
                cmd.Parameters.AddWithValue("@amount", a.AmountRequested);
                cmd.Parameters.AddWithValue("@purpose", a.Purpose);
                cmd.Parameters.AddWithValue("@period", a.RepaymentPeriod);
                cmd.Parameters.AddWithValue("@date", a.ApplicationDate);
                cmd.Parameters.AddWithValue("@notes", a.SupportingNotes);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public void UpdateApplication(LoanApplication a)
        {
            string sql = @"UPDATE LoanApplications
                SET ClientID=@client,AmountRequested=@amount,Purpose=@purpose,
                    RepaymentPeriod=@period,SupportingNotes=@notes
                WHERE ApplicationID=@id AND Status='Pending Review'";
            using (MySqlConnection con = DatabaseConnection.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@client", a.ClientID);
                cmd.Parameters.AddWithValue("@amount", a.AmountRequested);
                cmd.Parameters.AddWithValue("@purpose", a.Purpose);
                cmd.Parameters.AddWithValue("@period", a.RepaymentPeriod);
                cmd.Parameters.AddWithValue("@notes", a.SupportingNotes);
                cmd.Parameters.AddWithValue("@id", a.ApplicationID);
                con.Open();
                if (cmd.ExecuteNonQuery() == 0)
                    throw new Exception("Only pending applications can be updated.");
            }
        }

        public void Decide(int applicationID, string decision, string note, int approverID)
        {
            using (MySqlConnection con = DatabaseConnection.GetConnection())
            {
                con.Open();
                using (var tx = con.BeginTransaction())
                {
                    using (MySqlCommand update = new MySqlCommand(
                        "UPDATE LoanApplications SET Status=@status WHERE ApplicationID=@id AND Status='Pending Review'", con, tx))
                    {
                        update.Parameters.AddWithValue("@status", decision);
                        update.Parameters.AddWithValue("@id", applicationID);
                        if (update.ExecuteNonQuery() == 0) throw new Exception("Only pending applications can receive a decision.");
                    }
                    using (MySqlCommand insert = new MySqlCommand(
                        @"INSERT INTO Decisions(ApplicationID,DecisionStatus,DecisionNote,DecisionDate,ApproverID)
                          VALUES(@id,@status,@note,NOW(),@approver)", con, tx))
                    {
                        insert.Parameters.AddWithValue("@id", applicationID);
                        insert.Parameters.AddWithValue("@status", decision);
                        insert.Parameters.AddWithValue("@note", note);
                        insert.Parameters.AddWithValue("@approver", approverID);
                        insert.ExecuteNonQuery();
                    }
                    tx.Commit();
                }
            }
        }

        public DataTable GetApprovedApplications(string search = "")
        {
            return ReadTable(@"SELECT a.ApplicationID,a.ReferenceNumber,c.FullName AS Client,a.AmountRequested
                FROM LoanApplications a
                JOIN Clients c ON c.ClientID=a.ClientID
                WHERE a.Status='Approved'
                  AND (a.ReferenceNumber LIKE @search OR c.FullName LIKE @search
                       OR CAST(a.ApplicationID AS CHAR) LIKE @search)
                  AND NOT EXISTS
                    (SELECT 1 FROM Loans l WHERE l.ApplicationID=a.ApplicationID)
                ORDER BY a.ApplicationID DESC",
                c => c.Parameters.AddWithValue("@search", "%" + search + "%"));
        }

        public void AddPayout(int applicationID, decimal amount, DateTime date, string method, string reference, int period)
        {
            using (MySqlConnection con = DatabaseConnection.GetConnection())
            {
                con.Open();
                using (var tx = con.BeginTransaction())
                {
                    decimal approved;
                    using (MySqlCommand check = new MySqlCommand(
                        "SELECT AmountRequested FROM LoanApplications WHERE ApplicationID=@id AND Status='Approved'", con, tx))
                    {
                        check.Parameters.AddWithValue("@id", applicationID);
                        object? result = check.ExecuteScalar();
                        if (result == null) throw new Exception("Only approved applications can be paid out.");
                        approved = Convert.ToDecimal(result);
                    }
                    if (amount <= 0 || amount > approved) throw new Exception("Payout must be above zero and cannot exceed the approved amount.");
                    int loanID;
                    using (MySqlCommand insert = new MySqlCommand(
                        @"INSERT INTO Loans(ApplicationID,ApprovedAmount,AmountPaidOut,PayoutDate,PaymentMethod,PaymentReference,LoanStatus)
                          VALUES(@app,@approved,@amount,@date,@method,@ref,'Active')", con, tx))
                    {
                        insert.Parameters.AddWithValue("@app", applicationID);
                        insert.Parameters.AddWithValue("@approved", approved);
                        insert.Parameters.AddWithValue("@amount", amount);
                        insert.Parameters.AddWithValue("@date", date);
                        insert.Parameters.AddWithValue("@method", method);
                        insert.Parameters.AddWithValue("@ref", reference);
                        insert.ExecuteNonQuery();
                        loanID = (int)insert.LastInsertedId;
                    }
                    // Equal instalments are used as a simple initial schedule; the SRS says calculation policy is to be supplied later.
                    decimal instalment = decimal.Round(amount / period, 2);
                    for (int i = 1; i <= period; i++)
                    {
                        decimal dueAmount = i == period ? amount - instalment * (period - 1) : instalment;
                        using (MySqlCommand schedule = new MySqlCommand(
                            @"INSERT INTO RepaymentSchedules(LoanID,DueDate,ExpectedAmount,InstalmentStatus)
                              VALUES(@loan,DATE_ADD(@start,INTERVAL @months MONTH),@expected,'Pending')", con, tx))
                        {
                            schedule.Parameters.AddWithValue("@loan", loanID);
                            schedule.Parameters.AddWithValue("@start", date);
                            schedule.Parameters.AddWithValue("@months", i);
                            schedule.Parameters.AddWithValue("@expected", dueAmount);
                            schedule.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                }
            }
        }

        public DataTable GetActiveLoans(string search = "")
        {
            return ReadTable(@"SELECT l.LoanID,c.FullName AS Client,l.ApprovedAmount,l.AmountPaidOut,
                (l.AmountPaidOut-IFNULL((SELECT SUM(r.AmountPaid) FROM Repayments r WHERE r.LoanID=l.LoanID),0)) AS Balance,
                l.PayoutDate,l.LoanStatus
                FROM Loans l
                JOIN LoanApplications a ON a.ApplicationID=l.ApplicationID
                JOIN Clients c ON c.ClientID=a.ClientID
                WHERE l.LoanStatus='Active'
                  AND (c.FullName LIKE @search OR CAST(l.LoanID AS CHAR) LIKE @search)
                ORDER BY l.LoanID DESC",
                c => c.Parameters.AddWithValue("@search", "%" + search + "%"));
        }

        public DataTable GetLoanChoices()
        {
            return ReadTable(@"SELECT l.LoanID,CONCAT('LN-',l.LoanID,' - ',c.FullName) AS LoanName,
                (l.AmountPaidOut-IFNULL((SELECT SUM(r.AmountPaid) FROM Repayments r WHERE r.LoanID=l.LoanID),0)) AS Balance
                FROM Loans l JOIN LoanApplications a ON a.ApplicationID=l.ApplicationID
                JOIN Clients c ON c.ClientID=a.ClientID WHERE l.LoanStatus='Active'");
        }

        public void AddRepayment(int loanID, decimal amount, DateTime date, string method, string reference)
        {
            using (MySqlConnection con = DatabaseConnection.GetConnection())
            {
                con.Open();
                using (var tx = con.BeginTransaction())
                {
                    decimal balance;
                    using (MySqlCommand check = new MySqlCommand(
                        @"SELECT l.AmountPaidOut-IFNULL((SELECT SUM(r.AmountPaid) FROM Repayments r WHERE r.LoanID=l.LoanID),0)
                          FROM Loans l WHERE l.LoanID=@id AND l.LoanStatus='Active' FOR UPDATE", con, tx))
                    {
                        check.Parameters.AddWithValue("@id", loanID);
                        object? result = check.ExecuteScalar();
                        if (result == null) throw new Exception("Select an active loan.");
                        balance = Convert.ToDecimal(result);
                    }
                    if (amount <= 0 || amount > balance) throw new Exception("Repayment must be above zero and cannot exceed the outstanding balance.");
                    using (MySqlCommand insert = new MySqlCommand(
                        @"INSERT INTO Repayments(LoanID,AmountPaid,PaymentDate,PaymentMethod,ReceiptReference)
                          VALUES(@loan,@amount,@date,@method,@ref)", con, tx))
                    {
                        insert.Parameters.AddWithValue("@loan", loanID);
                        insert.Parameters.AddWithValue("@amount", amount);
                        insert.Parameters.AddWithValue("@date", date);
                        insert.Parameters.AddWithValue("@method", method);
                        insert.Parameters.AddWithValue("@ref", reference);
                        insert.ExecuteNonQuery();
                    }
                    // Mark instalments as paid when recorded repayments cover them in due-date order.
                    decimal totalPaid;
                    using (MySqlCommand total = new MySqlCommand(
                        "SELECT IFNULL(SUM(AmountPaid),0) FROM Repayments WHERE LoanID=@id", con, tx))
                    {
                        total.Parameters.AddWithValue("@id", loanID);
                        totalPaid = Convert.ToDecimal(total.ExecuteScalar());
                    }

                    decimal runningExpected = 0;
                    using (MySqlCommand scheduleRead = new MySqlCommand(
                        "SELECT ScheduleID,ExpectedAmount FROM RepaymentSchedules WHERE LoanID=@id ORDER BY DueDate,ScheduleID", con, tx))
                    {
                        scheduleRead.Parameters.AddWithValue("@id", loanID);
                        using (MySqlDataReader reader = scheduleRead.ExecuteReader())
                        {
                            var paidScheduleIDs = new System.Collections.Generic.List<int>();
                            while (reader.Read())
                            {
                                runningExpected += Convert.ToDecimal(reader["ExpectedAmount"]);
                                if (totalPaid >= runningExpected)
                                    paidScheduleIDs.Add(Convert.ToInt32(reader["ScheduleID"]));
                            }
                            reader.Close();
                            foreach (int scheduleID in paidScheduleIDs)
                            {
                                using (MySqlCommand mark = new MySqlCommand(
                                    "UPDATE RepaymentSchedules SET InstalmentStatus='Paid' WHERE ScheduleID=@id", con, tx))
                                {
                                    mark.Parameters.AddWithValue("@id", scheduleID);
                                    mark.ExecuteNonQuery();
                                }
                            }
                        }
                    }

                    decimal newBalance = balance - amount;
                    if (newBalance == 0)
                    {
                        using (MySqlCommand close = new MySqlCommand(
                            "UPDATE Loans SET LoanStatus='Closed' WHERE LoanID=@id", con, tx))
                        {
                            close.Parameters.AddWithValue("@id", loanID);
                            close.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                }
            }
        }

        public DataTable GetRepayments(string search = "")
        {
            return ReadTable(@"SELECT r.RepaymentID,r.LoanID,c.FullName AS Client,r.AmountPaid,r.PaymentDate,
                r.PaymentMethod,r.ReceiptReference
                FROM Repayments r
                JOIN Loans l ON l.LoanID=r.LoanID
                JOIN LoanApplications a ON a.ApplicationID=l.ApplicationID
                JOIN Clients c ON c.ClientID=a.ClientID
                WHERE c.FullName LIKE @search OR CAST(r.LoanID AS CHAR) LIKE @search
                ORDER BY r.RepaymentID DESC",
                c => c.Parameters.AddWithValue("@search", "%" + search + "%"));
        }

        public DataTable GetSchedule(string search = "")
        {
            return ReadTable(@"SELECT s.ScheduleID,s.LoanID,c.FullName AS Client,s.DueDate,s.ExpectedAmount,
                CASE WHEN s.InstalmentStatus='Paid' THEN 'Paid'
                     WHEN s.DueDate<CURDATE() THEN 'Overdue' ELSE 'Pending' END AS Status
                FROM RepaymentSchedules s
                JOIN Loans l ON l.LoanID=s.LoanID
                JOIN LoanApplications a ON a.ApplicationID=l.ApplicationID
                JOIN Clients c ON c.ClientID=a.ClientID
                WHERE c.FullName LIKE @search OR CAST(s.LoanID AS CHAR) LIKE @search
                ORDER BY s.DueDate,s.ScheduleID",
                c => c.Parameters.AddWithValue("@search", "%" + search + "%"));
        }

        public DataTable GetReports(DateTime fromDate, DateTime toDate)
        {
            return ReadTable(@"SELECT 'Applications by status' AS Report,Status AS Category,COUNT(*) AS Total
                FROM LoanApplications WHERE ApplicationDate BETWEEN @from AND @to GROUP BY Status
                UNION ALL
                SELECT 'Loans by status',
                    CASE
                        WHEN l.LoanStatus='Closed' THEN 'Closed'
                        WHEN EXISTS (
                            SELECT 1
                            FROM RepaymentSchedules s
                            WHERE s.LoanID=l.LoanID
                              AND s.DueDate<CURDATE()
                              AND s.InstalmentStatus<>'Paid'
                        ) THEN 'Overdue'
                        ELSE l.LoanStatus
                    END AS Category,
                    COUNT(*) AS Total
                FROM Loans l
                WHERE l.PayoutDate BETWEEN @from AND @to
                GROUP BY Category
                UNION ALL
                SELECT 'Overdue instalments','Overdue',COUNT(*) FROM RepaymentSchedules
                WHERE DueDate<CURDATE() AND DueDate BETWEEN @from AND @to
                  AND InstalmentStatus<>'Paid'
                UNION ALL
                SELECT 'Money paid out','Total',IFNULL(SUM(AmountPaidOut),0) FROM Loans WHERE PayoutDate BETWEEN @from AND @to
                UNION ALL
                SELECT 'Repayments received','Total',IFNULL(SUM(AmountPaid),0) FROM Repayments WHERE PaymentDate BETWEEN @from AND @to",
                c => { c.Parameters.AddWithValue("@from", fromDate.Date); c.Parameters.AddWithValue("@to", toDate.Date); });
        }

        public DataTable GetLoanStatement(int clientID)
        {
            return ReadTable(@"SELECT 'Payout' AS EntryType,
                    l.PayoutDate AS EntryDate,
                    l.AmountPaidOut AS Amount,
                    l.PaymentMethod AS Method,
                    l.PaymentReference AS Reference,
                    l.AmountPaidOut AS Balance,
                    l.LoanID
                FROM Loans l
                JOIN LoanApplications a ON a.ApplicationID=l.ApplicationID
                WHERE a.ClientID=@client

                UNION ALL

                SELECT 'Repayment' AS EntryType,
                    r.PaymentDate AS EntryDate,
                    -r.AmountPaid AS Amount,
                    r.PaymentMethod AS Method,
                    r.ReceiptReference AS Reference,
                    l.AmountPaidOut - IFNULL((
                        SELECT SUM(r2.AmountPaid)
                        FROM Repayments r2
                        WHERE r2.LoanID=r.LoanID
                          AND (r2.PaymentDate<r.PaymentDate
                               OR (r2.PaymentDate=r.PaymentDate AND r2.RepaymentID<=r.RepaymentID))
                    ),0) AS Balance,
                    l.LoanID
                FROM Repayments r
                JOIN Loans l ON l.LoanID=r.LoanID
                JOIN LoanApplications a ON a.ApplicationID=l.ApplicationID
                WHERE a.ClientID=@client
                ORDER BY EntryDate,LoanID",
                c => c.Parameters.AddWithValue("@client", clientID));
        }

        public DataTable GetDashboardCounts()
        {
            return ReadTable(@"SELECT
                (SELECT COUNT(*) FROM Clients) AS Clients,
                (SELECT COUNT(*) FROM LoanApplications) AS Applications,
                (SELECT COUNT(*) FROM Loans WHERE LoanStatus='Active') AS ActiveLoans,
                (SELECT COUNT(*) FROM RepaymentSchedules WHERE DueDate<CURDATE() AND InstalmentStatus<>'Paid') AS Overdue");
        }
    }
}
