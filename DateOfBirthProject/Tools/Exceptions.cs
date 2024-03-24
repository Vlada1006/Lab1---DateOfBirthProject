using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateOfBirthProject.Tools.Exceptions
{
    class DateInFutureException : Exception
    {
        public DateInFutureException(string message) : base(message) { }
    }

    class DateInLatePastException : Exception
    {
        public DateInLatePastException(string message) : base(message) { }
    }

    class InvalidEmailAddressException : Exception
    {
        public InvalidEmailAddressException(string message) : base(message) { }
    }

    class NotFoundCapitalLetterInBeginningException : Exception
    {
        public NotFoundCapitalLetterInBeginningException(string message) : base(message) { }
    }

    class AmountOfLettersException : Exception
    {
        public AmountOfLettersException(string message) : base(message) { }
    }

    class UnnecessaryExtraCharactersException : Exception
    {
        public UnnecessaryExtraCharactersException(string message) : base(message) { }
    }
}

    

