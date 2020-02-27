namespace Codecool.ApplicationProcess.Entities
{
    /// <summary>
    /// Person class.
    /// </summary>
    public abstract class Person
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// It is necessary because of serialization.
        /// </summary>
        protected Person()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        /// <param name="firstName">Firstname of person.</param>
        /// <param name="lastName">Secondname of person.</param>
        protected Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        /// <summary>
        /// Gets or sets the unique identifier of the person.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the firstname of the person.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the lastname of the person.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the person.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the email of the person.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// String representation of a <see cref="Person"/>.
        /// </summary>
        /// <returns>Person's base data as a string.</returns>
        public override string ToString()
        {
            return $"[{Id}] My name is: {FirstName} {LastName}";
        }
    }
}