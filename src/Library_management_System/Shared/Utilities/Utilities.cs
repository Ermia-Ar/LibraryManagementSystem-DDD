using System.Text.RegularExpressions;

namespace Shared.Utilities
{
    public static class Utilities
    {
        public static bool IsEmail(this string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

		public static bool IsPhoneNumber(this string phoneNumber)
		{
			if (string.IsNullOrWhiteSpace(phoneNumber))
				return false;

			string pattern = @"^\+?[1-9]\d{6,14}$";
			return Regex.IsMatch(phoneNumber, pattern);
		}
	}
}