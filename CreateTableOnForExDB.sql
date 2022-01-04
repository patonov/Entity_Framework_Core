USE ForExDB

CREATE TABLE EurUsd(Id INT PRIMARY KEY IDENTITY, OpenPrice DECIMAL, HighestPrice DECIMAL, LowestPrice DECIMAL, ClosingPrice DECIMAL)

INSERT INTO EurUsd (OpenPrice, HighestPrice, LowestPrice, ClosingPrice) VALUES (0.0000, 0.0000, 0.0000, 0.0000)