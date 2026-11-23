-- Run this once in phpMyAdmin after selecting LoanManagementDB.
-- It preserves existing repayment records and standardizes the amount column name.
USE LoanManagementDB;

DROP PROCEDURE IF EXISTS UpdateRepaymentAmountColumn;

DELIMITER //
CREATE PROCEDURE UpdateRepaymentAmountColumn()
BEGIN
    DECLARE has_amount_paid INT DEFAULT 0;
    DECLARE legacy_column VARCHAR(64) DEFAULT NULL;
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET legacy_column = NULL;

    SELECT COUNT(*) INTO has_amount_paid
    FROM INFORMATION_SCHEMA.COLUMNS
    WHERE TABLE_SCHEMA = DATABASE()
      AND TABLE_NAME = 'Repayments'
      AND COLUMN_NAME = 'AmountPaid';

    IF has_amount_paid = 0 THEN
        SELECT COLUMN_NAME INTO legacy_column
        FROM INFORMATION_SCHEMA.COLUMNS
        WHERE TABLE_SCHEMA = DATABASE()
          AND TABLE_NAME = 'Repayments'
          AND COLUMN_NAME IN ('PaidAmount', 'PaymentAmount', 'RepaymentAmount', 'Amount')
        ORDER BY FIELD(COLUMN_NAME, 'PaidAmount', 'PaymentAmount', 'RepaymentAmount', 'Amount')
        LIMIT 1;

        IF legacy_column IS NOT NULL THEN
            SET @migration_sql = CONCAT(
                'ALTER TABLE Repayments CHANGE COLUMN `',
                REPLACE(legacy_column, '`', '``'),
                '` AmountPaid DECIMAL(15,2) NOT NULL'
            );
            PREPARE migration_statement FROM @migration_sql;
            EXECUTE migration_statement;
            DEALLOCATE PREPARE migration_statement;
        END IF;
    END IF;
END//
DELIMITER ;

CALL UpdateRepaymentAmountColumn();
DROP PROCEDURE UpdateRepaymentAmountColumn;

-- Verify the final column name. It should return AmountPaid.
SHOW COLUMNS FROM Repayments LIKE 'AmountPaid';
