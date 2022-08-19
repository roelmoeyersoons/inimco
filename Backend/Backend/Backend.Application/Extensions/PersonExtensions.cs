using Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Extensions
{
    public static class PersonExtensions
    {
        public static string ReverseName(this Person person)
        {
            if (person is null)
                return string.Empty;

            var sb = new StringBuilder();
            sb.Append(person.LastName);
            if (string.IsNullOrWhiteSpace(person.LastName))
                sb.Append(' ');

            sb.Append(person.FirstName);

            return sb.ToString();
        }

        private static char[] _consonants = { 'a', 'e', 'i', 'o', 'u' };

        public static int CountConsonants(this Person person)
        {
            if (person is null)
                return 0;

            var acc = 0;
            foreach(var character in Enumerable.Concat(person.FirstName, person.LastName))
            {
                if(_consonants.Contains(character))
                    acc++;
            }
            return acc;
        }
    }
}
