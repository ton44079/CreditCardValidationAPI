CREATE PROCEDURE [dbo].[SP_CREDIT_CARD_VALIDATION]
	@cardNumber bigint
	--@expiryDate date
AS
	DECLARE @Exist int ,@Result nvarchar(20),@CardType nvarchar(10), @ExpiryMonth int, @ExpiryYear int, @FirstDigit nvarchar(1)
	DECLARE @TxtValid nvarchar(20),@TxtInvalid nvarchar(20),@TxtDontExsit nvarchar(20)
	DECLARE @Visa nvarchar(10),@Master nvarchar(10),@Amex nvarchar(10),@JCB nvarchar(10),@Unknown nvarchar(10)

	SET @Exist =0;
	-- Result Text
	SET @TxtValid ='Valid';
	SET @TxtInvalid ='Invalid';
	SET @TxtDontExsit ='Does not exist';
	-- Card Type
	SET @Visa ='Visa';
	SET @Master ='Master';
	SET @Amex ='Amex';
	SET @JCB ='JCB';
	SET @Unknown ='Unknown';

	SELECT @Exist = COUNT(Id) FROM CREDIT_CARDS WHERE CARD_NUMBER = @cardNumber

	IF @Exist > 0 -- if has data in database

		SELECT
		    (CASE  FIRST_DIGIT
				   WHEN  4  THEN @Visa   
				   WHEN  5  THEN @Master  
				   WHEN  3  THEN	
								CASE COUNT_NUMBER -- Check Lenght of Card Number
								 WHEN  15  THEN @Amex   
								 WHEN  16  THEN @JCB   
							  	 ELSE @Unknown
								END
				   ELSE @Unknown
			END) AS CardType,
			 (CASE  FIRST_DIGIT
				   WHEN  4  THEN CASE
									WHEN (EX_YEAR % 4 = 0 AND EX_YEAR % 100 <> 0) OR EX_YEAR % 400 = 0 THEN  @TxtValid
								    ELSE @TxtInvalid
								 END
				   WHEN  5  THEN CASE  
									WHEN dbo.[IS_PRIME](EX_YEAR) = 1 THEN  @TxtValid
								    ELSE @TxtInvalid
								 END
				   WHEN  3  THEN	-- Case Vasa / JCB
								CASE COUNT_NUMBER -- Check Lenght of Card Number
								 WHEN  15  THEN @TxtInvalid   -- Refer 11. The rest is "Invalid" Card.
								 WHEN  16  THEN @TxtValid   
							  	 ELSE @TxtInvalid
								END
				   ELSE @TxtInvalid
			END) AS Result
			FROM 
			(select CONVERT(nvarchar(20),CARD_NUMBER) as STR_CARD_NUMBER,
			        SUBSTRING(CONVERT(nvarchar(20),CARD_NUMBER), 1, 1) as FIRST_DIGIT,
					YEAR(EXPIRY_DATE) as EX_YEAR,
					LEN(CONVERT(nvarchar(20),CARD_NUMBER)) as COUNT_NUMBER
			 FROM CREDIT_CARDS
		     WHERE CARD_NUMBER = @cardNumber) as CREDIT_ITEM
   	ELSE  -- if doesn't have data in database
	BEGIN
		SET @Result = @TxtDontExsit;
		SELECT @Result as Result, @CardType as CardType
	END
RETURN 0
