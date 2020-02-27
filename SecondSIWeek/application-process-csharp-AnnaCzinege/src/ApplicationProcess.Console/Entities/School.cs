using System.IO;
using System.Xml.Serialization;

namespace Codecool.ApplicationProcess.Entities
{
    /// <summary>
    /// Codecool location.
    /// </summary>
    public class School
    {
        private static int _idCounter = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="School"/> class.
        /// It is necessary because of serialization.
        /// </summary>
        public School()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="School"/> class.
        /// </summary>
        /// <param name="name">Name of the new <see cref="School"/> instance.</param>
        /// <param name="city">City where the <see cref="School"/> is located.</param>
        /// <param name="country">Country where the <see cref="School"/> is located.</param>
        public School(string name, City city, string country)
        {
            Name = name;
            City = city;
            Country = country;
            Id = _idCounter++;
        }

        /// <summary>
        /// Gets or sets the unique identifier of a <see cref="School"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets thr name of the <see cref="School"/>.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the city where the <see cref="School"/> is located.
        /// </summary>
        public City City { get; set; }

        /// <summary>
        /// Gets or sets the country of the <see cref="School"/>.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the main contact <see cref="Mentor"/> of the location.
        /// </summary>
        public Mentor ContactPerson { get; set; }

        /// <summary>
        /// Serialize the object to XML file with "_school" prefix and the <see cref="School"/>'s name.
        /// </summary>
        public void Serialize()
        {
            var serializer = new XmlSerializer(typeof(School));
            using var streamWriter = new StreamWriter($"school_{Name}.xml");
            serializer.Serialize(streamWriter, this);
        }
    }
}
