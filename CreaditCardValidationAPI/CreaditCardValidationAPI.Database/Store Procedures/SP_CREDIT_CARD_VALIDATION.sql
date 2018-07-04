CREATE PROCEDURE [dbo].[SP_CREDIT_CARD_VALIDATION]
	@cardNumber numeric(16,0),
	@expiryDate date
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

	SELECT @Exist = COUNT(Id) FROM CREDIT_CARDS WHERE CARD_NUMBER like @cardNumber

	IF @Exist > 0 -- if has data in database

		SELECT
			CONVERT(nvarchar(16),CARD_NUMBER) as STR_CARD_NUMBER,
		    (CASE  SUBSTRING(CONVERT(nvarchar(16),CARD_NUMBER), 1, 1)
				   WHEN  4  THEN @Visa   
				   WHEN  5  THEN @Master  
				   WHEN  3  THEN	
								CASE LEN(CONVERT(nvarchar(16),CARD_NUMBER)) -- Check Lenght of Card Number
								 WHEN  15  THEN @Visa   
								 WHEN  16  THEN @JCB   
							  	 ELSE @Unknown
								END
				   ELSE @Unknown
			END) AS CardType,
			 (CASE  SUBSTRING(CONVERT(nvarchar(16),CARD_NUMBER), 1, 1)
				   WHEN  4  THEN CASE
									When (YEAR(EXPIRY_DATE) % 4 = 0 AND YEAR(EXPIRY_DATE) % 100 <> 0) OR YEAR(EXPIRY_DATE) % 400 = 0 THEN  @TxtValid
								    ELSE @TxtInvalid
								 END
				   --WHEN  5  THEN CASE 
							--		When IS_PRIME((YEAR(EXPIRY_DATE)) = 1 THEN  @TxtValid
							--	    ELSE @TxtInvalid
							--	 END
				   WHEN  3  THEN	-- Case Vasa / JCB
								CASE LEN(CONVERT(nvarchar(16),CARD_NUMBER)) -- Check Lenght of Card Number
								 WHEN  15  THEN @TxtInvalid   -- Refer 11. The rest is "Invalid" Card.
								 WHEN  16  THEN @TxtValid   
							  	 ELSE @TxtInvalid
								END
				   ELSE @TxtInvalid
			END) AS Result
			FROM CREDIT_CARDS WHERE CARD_NUMBER like @cardNumber
   	ELSE  -- if doesn't have data in database
	BEGIN
		SET @Result = @TxtDontExsit;
		SELECT @Result as Result, @CardType as CardType
	END
RETURN 0
