USE [CCG4];



SET IDENTITY_INSERT Clients ON;

INSERT INTO Clients ( ClientID, FirstName, LastName, HomeState )
VALUES ( 1, 'LeBron', 'James', 'MO' );

SET IDENTITY_INSERT Clients OFF;

INSERT INTO Accounts ( ClientID, AccountID, Balance )
VALUES ( 1, 211111110, 0.00 );

SET IDENTITY_INSERT Transactions ON;

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 1, 211111110, '2019-05-02', 'Starbucks', 2.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 2, 211111110, '2019-05-04', 'Payroll', 800.00, 'CR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 3, 211111110, '2019-05-07', 'Chipotle', 8.00, 'DR', 'MO', 0 );


INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 4, 211111110, '2019-05-09', 'ATM', 10.00, 'DR', 'MO', 0 );


INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 5, 211111110, '2019-05-10', 'Hoolihans', 32.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 6, 211111110, '2019-05-10', 'KCPL', 100.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 7, 211111110, '2019-05-10', 'Google Fiber', 190.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 8, 211111110, '2019-05-15', 'Netflix', 9.99, 'DR', 'CA', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 9, 211111110, '2019-05-15', 'Rent', 350.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 10, 211111110, '2019-05-19', 'Starbucks', 2.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 11, 211111110, '2019-05-19', 'Payroll', 750.00, 'CR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 12, 211111110, '2019-05-19', 'Commerce Bank Credit Card Payment', 620.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 13, 211111110, '2019-05-19', 'McFaddens', 150.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 14, 211111110, '2019-05-22', 'Price Chopper', 100.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 15, 211111110, '2019-05-23', 'Check from friend', 50.00, 'CR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 16, 211111110, '2019-06-02', 'Payroll', 800.00, 'CR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 17, 211111110, '2019-06-02', 'HyVee', 9.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 18, 211111110, '2019-06-06', 'McFaddens', 14.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 19, 211111110, '2019-06-13', 'Target', 32.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 20, 211111110, '2019-06-13', 'KCPL', 100.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 21, 211111110, '2019-06-19', 'Payroll', 750.00, 'CR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 22, 211111110, '2019-06-19', 'Google Fiber', 190.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 23, 211111110, '2019-06-19', 'Netflix', 9.99, 'DR', 'CA', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 24, 211111110, '2019-06-22', 'Neos', 6.50, 'DR',  'KS', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 25, 211111110, '2019-06-22', 'Commerce Bank Credit Card Payment', 230.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 26, 211111110, '2019-06-22', 'Best Buy', 100.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 27, 211111110, '2019-06-22', 'Pottery Barn', 300.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 28, 211111110, '2019-06-26', 'The Loft', 23.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 29, 211111110, '2019-06-26', 'Dave and Busters', 45.00, 'DR', 'KS', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 30, 211111110, '2019-06-26', 'Bowling', 35.00, 'DR', 'KS', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 31, 211111110, '2019-06-30', 'Payroll', 800.00, 'CR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 32, 211111110, '2019-07-01', 'McFaddens', 210.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 33, 211111110, '2019-07-01', 'Taco Bell', 18.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 34, 211111110, '2019-07-01', 'QuikTrip', 45.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 35, 211111110, '2019-07-02', 'KCPL', 130.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 36, 211111110, '2019-07-02', 'Google Fiber', 185.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 37, 211111110, '2019-07-04', 'Netflix', 7.99, 'DR', 'CA', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 38, 211111110, '2019-07-04', 'Price Chopper', 56.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 39, 211111110, '2019-07-06', 'Price Chopper', 43.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 40, 211111110, '2019-07-07', 'Target', 98.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 41, 211111110, '2019-07-09', 'Jose Peppers', 13.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 42, 211111110, '2019-07-10', 'Starbucks', 9.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 43, 211111110, '2019-07-12', 'Rent', 350.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 44, 211111110, '2019-07-12', 'Redbox', 3.50, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 45, 211111110, '2019-07-12', 'Bank of America Credit Card Payment', 301.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 46, 211111110, '2019-07-13', 'Payroll', 730.00, 'CR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 47, 211111110, '2019-07-14', 'Target', 232.68, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 48, 211111110, '2019-07-14', 'Best Buy', 18.50, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 49, 211111110, '2019-07-16', 'Nationwide', 120.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 50, 211111110, '2019-07-19', 'KC Police - Speeding Ticket', 50.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 51, 211111110, '2019-07-19', 'Uber', 50.00, 'DR', 'CA', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 52, 211111110, '2019-07-19', 'Mannys', 9.20, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 53, 211111110, '2019-07-19', 'Toys R Us', 24.75, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 54, 211111110, '2019-07-19', 'Scooters', 3.50, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 55, 211111110, '2019-07-20', 'QuikTrip', 36.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 56, 211111110, '2019-07-20', 'Price Chopper', 32.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 57, 211111110, '2019-07-21', 'Home Depot', 48.12, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 58, 211111110, '2019-07-22', 'Burger King', 4.20, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 59, 211111110, '2019-07-22', 'Jiffy Lube', 45.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 60, 211111110, '2019-07-22', 'Doctor Visit', 25.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 61, 211111110, '2019-07-23', 'CVS', 36.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 62, 211111110, '2019-07-23', 'Price Chopper', 29.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 63, 211111110, '2019-07-23', 'Transfer to Savings', 200.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 64, 211111110, '2019-07-23', 'Christmas check from Grandma', 150.00, 'CR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 65, 211111110, '2019-07-23', 'Student Loans', 250.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 66, 211111110, '2019-07-23', 'Ford Service', 75.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 67, 211111110, '2019-07-27', 'Hallmark', 36.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 68, 211111110, '2019-07-27', 'CVS', 22.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 69, 211111110, '2019-07-27', 'Payroll', 810.00, 'CR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 70, 211111110, '2019-07-30', 'Pottery Barn', 180.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 71, 211111110, '2019-07-30', 'Cheesecake Factory', 46.00, 'DR', 'MO', 0 );

INSERT INTO Transactions ( TransactionID, AccountID, Date, TransactionDetails, TransactionAmount, TransactionType, State, Dispute )
VALUES ( 72, 211111110, '2019-07-30', 'Starbucks', 8.00, 'DR', 'MO', 0 );

SET IDENTITY_INSERT Transactions OFF;

