using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using Codecool.ApplicationProcess.Entities;

namespace Codecool.ApplicationProcess.Data
{
    /// <summary>
    /// Application process xml repository.
    /// </summary>
    public class XMLRepository : IApplicationRepository
    {
        private static XDocument _doc;

        /// <summary>
        /// Initializes a new instance of the <see cref="XMLRepository"/> class.
        /// </summary>
        public XMLRepository()
        {
            _doc = XDocument.Load("Resources/Backup.xml");
        }

        /// <inheritdoc/>
        public int AmountOfApplicationAfter(DateTime date)
        {
            return _doc.Descendants("Applications").Descendants("Application")
                .Count(application => (DateTime)application.Element("ApplicationDate") > date);
        }

        /// <inheritdoc/>
        public IEnumerable<Mentor> GetAllMentorFrom(City city)
        {
            // serialization
            var mentors = _doc.Descendants("Mentors").Descendants("Mentor");
            var mentorsFromCity = new HashSet<Mentor>();
            foreach (var mentor in mentors)
            {
                Mentor ment = new Mentor();
                StringReader reader = new StringReader(mentor.ToString());
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Mentor));
                ment = (Mentor)xmlSerializer.Deserialize(reader);

                if (ment.City == city)
                {
                    mentorsFromCity.Add(ment);
                }
            }

            return mentorsFromCity;
        }

        /// <inheritdoc/>
        public IEnumerable<Mentor> GetAllMentorWhomFavoriteLanguage(string language)
        {
            // serialization
            var mentors = _doc.Descendants("Mentors").Descendants("Mentor");
            var mentorsOfLanguage = new List<Mentor>();
            foreach (var mentor in mentors)
            {
                Mentor mentor1 = new Mentor();
                StringReader reader = new StringReader(mentor.ToString());
                XmlSerializer serializer = new XmlSerializer(typeof(Mentor));
                mentor1 = (Mentor)serializer.Deserialize(reader);

                if (mentor1.ProgrammingLanguage.Equals(language))
                {
                    mentorsOfLanguage.Add(mentor1);
                }
            }

            return mentorsOfLanguage;
        }

        /// <inheritdoc/>
        public IEnumerable<Applicant> GetApplicantsOf(string contactMentorName)
        {
            return _doc.Descendants("Applications").Descendants("Application")
                .Where(application => contactMentorName.Equals(application.Element("Mentor").Element("Nickname").Value))
                .Select(application => CreateNewApplicant(application.Element("Applicant")));
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetAppliedStudentEmailList()
        {
            return _doc.Descendants("Applicants").Descendants("Applicant")
                .Where(applicant => applicant.Element("Status").Value == "Applied")
                .Select(applicant => applicant.Element("Email").Value).ToList();
        }

        private Applicant CreateNewApplicant(XElement element)
        {
            return new Applicant()
            {
                Id = (int)element.Element("Id"),
                FirstName = (string)element.Element("FirstName"),
                LastName = (string)element.Element("LastName"),
                PhoneNumber = (string)element.Element("PhoneNumber"),
                Email = (string)element.Element("Email"),
                ApplicationCode = (int)element.Element("ApplicationCode"),
                Status = (ApplicationStatus)Enum.Parse(typeof(ApplicationStatus), element.Element("Status").Value),
                StartDate = element.Element("StartDate").IsEmpty ? default : (DateTime)element.Element("StartDate"),
            };
        }
    }
}
