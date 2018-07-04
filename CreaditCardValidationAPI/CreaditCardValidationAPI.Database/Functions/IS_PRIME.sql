CREATE FUNCTION [dbo].[IS_PRIME]
(
      @NumberToTest int
)
RETURNS bit
AS
BEGIN
      -- Declare the return variable here
      DECLARE @IsPrime bit,
                  @Divider int

      -- To speed things up, we will only attempt dividing by odd numbers

      -- We first take care of all evens, except 2
      IF (@NumberToTest % 2 = 0 AND @NumberToTest > 2)
            SET @IsPrime = 0
      ELSE
            SET @IsPrime = 1 -- By default, declare the number a prime

      --We then use a loop to attempt to disprove the number is a prime

      SET @Divider = 3 -- Start with the first odd superior to 1

      -- We loop up through the odds until the square root of the number to test
      -- or until we disprove the number is a prime
      WHILE (@Divider <= floor(sqrt(@NumberToTest))) AND (@IsPrime = 1)
      BEGIN

            -- Simply use a modulo
            IF @NumberToTest % @Divider = 0
                  SET @IsPrime = 0
            -- We only consider odds, therefore the step is 2
            SET @Divider = @Divider + 2
      END  

      -- Return the result of the function
      RETURN @IsPrime

END