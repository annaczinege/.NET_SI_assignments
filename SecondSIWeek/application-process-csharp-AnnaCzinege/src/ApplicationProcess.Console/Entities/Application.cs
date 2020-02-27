using System;
using System.IO;
using System.Xml.Serialization;

namespace Codecool.ApplicationProcess.Entities
{
    /// <summary>
    /// Application of applicants.
    /// </summary>
    public class Application
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Application"/> class.
        /// It is necessary because of serialization.
        /// </summary>
        public Application()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Application"/> class.
        /// </summary>
        /// <param name="mentor"><see cref="Mentor"/> who is the contact person.</param>
        /// <param name="applicant"><see cref="Applicant"/> who applies to Codecool.</param>
        /// <param name="applicationDate">Date of the application process started.</param>
        public Application(Mentor mentor, Applicant applicant, DateTime applicationDate)
        {
            Mentor = mentor;
            Applicant = applicant;
            ApplicationDate = applicationDate;
        }

        /// <summary>
        /// Gets or sets contact <see cref="Mentor"/> of the application.
        /// </summary>
        public Mentor Mentor { get; set; }

        /// <summary>
        /// Gets or sets <see cref="Applicant"/> who applied.
        /// </summary>
        public Applicant Applicant { get; set; }

        /// <summary>
        /// Gets or sets the date of the <see cref="Application"/>.
        /// </summary>
        public DateTime ApplicationDate { get; set; }

        /// <summary>
        /// Serialize the object to XML file with the "app" prefix and the <see cref="Application"/>'s Date.
        /// </summary>
        public void Serialize()
        {
            var serializer = new XmlSerializer(typeof(Application));
            using var streamWriter = new StreamWriter($"app_{ApplicationDate.ToShortDateString()}.xml");
            serializer.Serialize(streamWriter, this);
        }
    }
}
