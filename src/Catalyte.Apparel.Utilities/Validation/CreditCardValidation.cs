﻿using Catalyte.Apparel.Data.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Catalyte.Apparel.Utilities.HttpResponseExceptions;
using System.Globalization;

namespace Catalyte.Apparel.Utilities.Validation
{
    public static class Validation
    {
        /// <summary>
        /// This function validates that credit cards are valid based on multiple criteria.
        /// if invalid, it returns a list of strings. otherwise it returns an empty list.
        /// </summary>
        public static List<string> CreditCardValidation(Purchase Purchase)
        {
            List<string> errors = new();
            //Card number validation
            try
            {
                if (Purchase.CardNumber.Trim() == "")
                    errors.Add("The card number field must not be empty or whitespace. ");

                if (Purchase.CardNumber.Trim() != "" && Purchase.CardNumber.Trim().Length < 16 || Purchase.CardNumber.Trim().Length > 19)
                    errors.Add("Card number length must be between 16 and 19 characters. ");

                if (Purchase.CardNumber.Trim() != "" && !Purchase.CardNumber.Trim().All(char.IsDigit))
                    errors.Add("Card number must be only numbers. ");

                if (Purchase.CardNumber.Trim() != "" && Purchase.CardNumber.Trim().First() != '4' && Purchase.CardNumber.Trim().First() != '5')
                    errors.Add("This credit card provider is not supported. ");
            }
            catch (Exception)
            {
                errors.Add("The card number field must not be empty or whitespace. ");
            }
            //Expiration Validation
            try
            {
                if (Purchase.Expiration.Trim() == "")
                    errors.Add("The expiration field must not be empty or whitespace. ");

                var CardYear = Purchase.Expiration.Trim().Substring(3, 2);
                var CardMonth = Purchase.Expiration.Trim().Substring(0, 2);
                if (Purchase.Expiration.Trim() != "" && DateTime.Now >= DateTime.Parse($"{CardMonth}/20{CardYear}"))
                        errors.Add("This credit card is expired. ");
            }
            catch (FormatException)
            {
                errors.Add("This date is invalid. ");
            }
            catch (Exception)
            {
                errors.Add("The expiration field must not be empty or whitespace. ");
            }

            if (Purchase.CardHolder == null || Purchase.CardHolder.Trim() == "")
                errors.Add("The card holder field must not be empty or whitespace. ");


            if (Purchase.CVV.Length == 0)
                errors.Add("The CVV field must not be empty or white space. ");

            if (Purchase.CVV.Length != 0 && Purchase.CVV.Trim().Length != 3)
                errors.Add("CVV must be 3 digits long. ");

            if (Purchase.CardNumber.Trim() != "" && !Purchase.CardNumber.Trim().All(char.IsDigit))
                errors.Add("CVV must be only numbers. ");

            if (Purchase.CVV == null && Purchase.CardNumber == null && Purchase.Expiration == null && Purchase.CardHolder == null)
                throw new BadRequestException("No credit card provided. ");

            return errors;
        }
    }
}
