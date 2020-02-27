using System.IO;
using System.Xml.Serialization;

namespace Codecool.ApplicationProcess.Entities
{
    /// <summary>
    /// A mentor is a person in Codecool who is responsible for managing and supporting applied students.
    /// </summary>
    public class Mentor : Person
    {
        private static int _idCounter = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="Mentor"/> class.
        /// It is necessary because of serialization.
        /// </summary>
        public Mentor()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Mentor"/> class.
        /// </summary>
        /// <param name="firstName">Firstname of a mentor.</param>
        /// <param name="lastName">Lastname of a mentor.</param>
        public Mentor(string firstName, string lastName)
            : base(firstName, lastName)
        {
            Id = _idCounter++;
        }

        /// <summary>
        /// Gets or sets the nickname of the mentor.
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// Gets or sets the location of the mentor.
        /// </summary>
        public City City { get; set; }

        /// <summary>
        /// Gets or sets the favourite programing language of a mentor.
        /// </summary>
        public string ProgrammingLanguage { get; set; }

        /// <summary>
        /// Serialize the object to XML file with the "mentor" prefix and the <see cref="Mentor"/>'s Nickname.
        /// </summary>
        public void Serialize()
        {
            var serializer = new XmlSerializer(typeof(Mentor));
            using var streamWriter = new StreamWriter($"mentor_{Nickname}.xml");
            serializer.Serialize(streamWriter, this);
        }

        /// <summary>
        /// String representation of a <see cref="Mentor"/>.
        /// </summary>
        /// <returns>Mentor's base data as a string.</returns>
        /// <example>Example: [Mentor - Atesz] [1] My name is: Attila Molnár.</example>
        public override string ToString()
        {
            var nickName = Nickname ?? FirstName;
            return $"[Mentor - {nickName}]" + base.ToString();
        }
    }
}
