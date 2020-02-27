using System;
using System.IO;
using System.Xml.Serialization;

namespace Codecool.ApplicationProcess.Entities
{
    /// <summary>
    /// A person who applies to Codecool.
    /// </summary>
    public class Applicant : Person
    {
        private static int _idCounter = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="Applicant"/> class.
        /// It is necessary because of serialization.
        /// </summary>
        public Applicant()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Applicant"/> class.
        /// </summary>
        /// <param name="firstName">Firstname of applicant.</param>
        /// <param name="lastName">Last name of applicant.</param>
        public Applicant(string firstName, string lastName)
            : base(firstName, lastName)
        {
            Id = _idCounter++;
            ApplicationCode = FirstName[0] + LastName[0] + Id;
        }

        /// <summary>
        /// Gets or sets the application code which is generated from the FirstName, LastName and Id.
        /// </summary>
        public int ApplicationCode { get; set; }

        /// <summary>
        /// Gets or sets the current status of the application.
        /// </summary>
        public ApplicationStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the StartDate of the applicant as a Codecooler.
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Serialize the object to XML file with the "applicant" prefix and the <see cref="Applicant"/>'s Firstname and Lastname.
        /// </summary>
        public void Serialize()
        {
            var serializer = new XmlSerializer(typeof(Applicant));
            using var streamWriter = new StreamWriter($"applicant_{FirstName}_{LastName}.xml");
            serializer.Serialize(streamWriter, this);
        }

        /// <summary>
        /// String representation of an applicant.
        /// </summary>
        /// <returns>Applicant's base data as a string.</returns>
        public override string ToString()
        {
            return $"[Applicant - {ApplicationCode}]" + base.ToString();
        }
    }
}
