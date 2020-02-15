using System.Collections.Generic;
using System.Linq;

namespace CleanControllers.Web.Models.Business
{
    public class Person
    {
        // this constructor is obsolete; the Person class needs only properties with private setters
        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public string FirstName { get; }

        public string LastName { get; }

        public int Age { get; }

        public static readonly string ERROR_FIRST_NAME_LENGTH = "person.firstname.length";
        public static readonly string ERROR_LAST_NAME_LENGTH = "person.lastname.length";
        public static readonly string ERROR_AGE_INVALID = "person.age.invalid";
        public static readonly string ERROR_CONSENT_REQUIRED = "person.consent.required";

        public class Builder
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public string[] Consent { get; set; }

            public bool ShouldCauseServerError => SimulateServerError != null && SimulateServerError.Contains("yes");
            public string[] SimulateServerError { get; set; }

            public BuildResult<Person> Build()
            {
                var errorCodes = new List<string>();

                if (string.IsNullOrEmpty(FirstName))
                    errorCodes.Add(ERROR_FIRST_NAME_LENGTH);
                
                if(string.IsNullOrEmpty(LastName))
                    errorCodes.Add(ERROR_LAST_NAME_LENGTH);

                if(Age < 18)
                    errorCodes.Add(ERROR_AGE_INVALID);

                if(Consent == null || Consent.Contains("yes") == false)
                    errorCodes.Add(ERROR_CONSENT_REQUIRED);

                // kinda dumb
                var person = errorCodes.Any() ? null : new Person(FirstName, LastName, Age);

                return new BuildResult<Person>(errorCodes.ToArray(), person);
            }
        }
    }
}