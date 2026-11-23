-- Fictional demonstration clients for LoanManagementDB.
-- These are test records only, not real people or verified national ID numbers.
USE LoanManagementDB;

INSERT IGNORE INTO Clients
    (FullName, IdentificationNumber, PhoneNumber, Address, RegistrationDate)
VALUES
    ('Niyonzima Jean Claude ', '1199080000000001', '+250788123401', 'Kimironko, Gasabo, Kigali', '2026-01-10'),
    ('Uwase Alice ', '1199050000000002', '+250788123402', 'Kicukiro, Kigali', '2026-01-12'),
    ('Habimana Eric ', '1199020000000003', '+250788123403', 'Remera, Gasabo, Kigali', '2026-01-15'),
    ('Mukamana Diane ', '1199070000000004', '+250788123404', 'Nyamirambo, Nyarugenge, Kigali', '2026-01-18'),
    ('Nkurunziza Patrick ', '1199010000000005', '+250788123405', 'Musanze, Northern Province', '2026-01-20'),
    ('Uwamahoro Grace ', '1199060000000006', '+250788123406', 'Huye, Southern Province', '2026-01-22'),
    ('Tuyisenge Emmanuel ', '1199030000000007', '+250788123407', 'Rubavu, Western Province', '2026-01-25'),
    (' Ingabire Claudine', '1199040000000008', '+250788123408', 'Rwamagana, Eastern Province', '2026-01-28'),
    ('Bizimana Samuel ', '1199090000000009', '+250788123409', 'Nyagatare, Eastern Province', '2026-02-02'),
    (' Mukeshimana Beatha', '1199050000000010', '+250788123410', 'Muhanga, Southern Province', '2026-02-05');

-- Confirm the inserted demonstration records.
SELECT ClientID, FullName, IdentificationNumber, PhoneNumber, Address, RegistrationDate
FROM Clients
WHERE IdentificationNumber BETWEEN '1199000000000000' AND '1199999999999999'
ORDER BY ClientID;
