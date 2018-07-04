using CreditCardValidationAPI.Domain.Context;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreaditCardValidationAPI.Tests.SP_UnitTest
{
    [TestClass]
    public class ValiationUnitTest
    {
        private readonly CreditDBEntities _dbContext;

        public ValiationUnitTest()
        {
            _dbContext = new CreditDBEntities();
        }

        [TestMethod]
        public void ValidVisa()
        {
            var result = _dbContext.SP_CREDIT_CARD_VALIDATION(4123345678910234).FirstOrDefault();

            Assert.AreEqual("Valid", result.Result);
            Assert.AreEqual("Visa", result.CardType);
        }

        [TestMethod]
        public void ValidMasterCard()
        {
            var result = _dbContext.SP_CREDIT_CARD_VALIDATION(5123345678910234).FirstOrDefault();

            Assert.AreEqual("Valid", result.Result);
            Assert.AreEqual("Master", result.CardType);
        }

        /// <summary>
        /// 3. Amex is a card number start with 3
        /// 6. Only Amex card number is 15
        /// 11. The rest case is "Invalid" card;
        /// Then I alway set "Invaliad" for Amex;
        /// </summary>
        [TestMethod]
        public void AmedCoditionFromAssignmentNotClear()
        {
            var result = _dbContext.SP_CREDIT_CARD_VALIDATION(312334567891023).FirstOrDefault();

            Assert.AreEqual("Invalid", result.Result);
            Assert.AreEqual("Amex", result.CardType);
        }

        /// <summary>
        /// 3. JCB is a card number start with 3
        /// 9. JCB card number is 16
        /// 11. All JCB is Valid;
        /// Then I alway set "Valiad" for JCB;
        /// </summary>
        [TestMethod]
        public void ValidJCB()
        {
            var result = _dbContext.SP_CREDIT_CARD_VALIDATION(3123345678910234).FirstOrDefault();

            Assert.AreEqual("Valid", result.Result);
            Assert.AreEqual("JCB", result.CardType);
        }

        [TestMethod]
        public void InvalidVisa()
        {
            var result = _dbContext.SP_CREDIT_CARD_VALIDATION(4199999999999999).FirstOrDefault();

            Assert.AreEqual("Invalid", result.Result);
            Assert.AreEqual("Visa", result.CardType);
        }

        [TestMethod]
        public void InvalidMasterCard()
        {
            var result = _dbContext.SP_CREDIT_CARD_VALIDATION(5199999999999999).FirstOrDefault();

            Assert.AreEqual("Invalid", result.Result);
            Assert.AreEqual("Master", result.CardType);
        }

        [TestMethod]
        public void UnknowCase()
        {
            var result = _dbContext.SP_CREDIT_CARD_VALIDATION(9999999999999999).FirstOrDefault();

            Assert.AreEqual("Invalid", result.Result);
            Assert.AreEqual("Unknown", result.CardType);
        }

        [TestMethod]
        public void DoesNotExist()
        {
            var result = _dbContext.SP_CREDIT_CARD_VALIDATION(51999999988888).FirstOrDefault();

            Assert.AreEqual("Does not exist", result.Result);
            Assert.AreEqual(null, result.CardType);
        }
    }
}
