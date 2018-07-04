CREATE FUNCTION [dbo].[IS_PRIME]
(
	@number int
)
RETURNS bit
AS
BEGIN
	DECLARE @prime_or_notPrime INT
    DECLARE @counter INT
    DECLARE @retVal VARCHAR(10)
    SET @retVal = 0

    SET @prime_or_notPrime = 1
    SET @counter = 2

    WHILE (@counter <= @number/2 )
    BEGIN

        IF (( @number % @counter) = 0 )
        BEGIN
            set @prime_or_notPrime = 0
            BREAK
        END

        IF (@prime_or_notPrime = 1 )
        BEGIN
            SET @retVal = 1
        END

        SET @counter = @counter + 1
    END
    return @retVal
END
