namespace LanguageCourse.API.Validation
{
    public static class Validator
    {
        public static bool IsValidCPF(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11 || !long.TryParse(cpf, out _))
                return false;

            var digits = cpf.Select(c => int.Parse(c.ToString())).ToArray();
            var firstDigitCheck = 0;
            var seccondDigitCheck = 0;

            for (int i = 0; i < 9; i++)
            {
                firstDigitCheck += digits[i] * (10 - i);
                seccondDigitCheck += digits[i] * (11 - i);
            }

            var firstDigit = (firstDigitCheck * 10 % 11) % 10;
            seccondDigitCheck += firstDigit * 2;
            var secondDigit = (seccondDigitCheck * 10 % 11) % 10;

            return digits[9] == firstDigit && digits[10] == secondDigit;
        }
    }
}
