using FacilitaCondo.Shared.Exceptions;
using System.Text.RegularExpressions;

namespace FacilitaCondo.Shared.Validations
{
    public class EmailAssertionConcern
    {
        public static void AssertEmailFormat(string email, string message)
        {
            if (string.IsNullOrEmpty(email))
                throw new DomainException(message);

            if (!Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
                throw new DomainException(message);
        }
    }
}
