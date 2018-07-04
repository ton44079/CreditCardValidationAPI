using CreditCardValidationAPI.Services.Interfaces;
using CreditCardValidationAPI.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CreaditCardValidationAPI.Controllers
{
    public class ValidationCreditCardController : ApiController
    {
        private readonly ICreditCardService _creditCardService;
        public ValidationCreditCardController(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        //// GET: api/ValidationCreditCard
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/ValidationCreditCard/5
        public ValidateResultModel Get(string id)
        {
            return _creditCardService.Validatie(id);
        }

        //// POST: api/ValidationCreditCard
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/ValidationCreditCard/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/ValidationCreditCard/5
        //public void Delete(int id)
        //{
        //}
    }
}
