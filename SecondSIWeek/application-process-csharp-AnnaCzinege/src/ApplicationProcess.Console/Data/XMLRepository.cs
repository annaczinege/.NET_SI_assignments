using System;
using System.Collections.Generic;
using System.IO;
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
            var applicationDates = _doc.Descendants("Applications").Descendants("Application");
            int applicationAfter = 0;
            foreach (var application in applicationDates)
            {
                StringReader reader = new StringReader(application.ToString());
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Application));
                Application appl = (Application)xmlSerializer.Deserialize(reader);

                if (appl.ApplicationDate > date)
                {
                    applicationAfter += 1;
                }
            }

            return applicationAfter;
        }

        /// <inheritdoc/>
        public IEnumerable<Mentor> GetAllMentorFrom(City city)
        {
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
            var mentors = _doc.Descendants("Applications").Descendants("Application").Descendants("Mentor");
            var applicants = _doc.Descendants("Applications").Descendants("Application").Descendants("Applicant");

            var mentorList = new List<Mentor>();
            var applicantList = new List<Applicant>();
            var applicantList2 = new List<Applicant>();

            foreach (var mentor in mentors)
            {
                Mentor ment = new Mentor();
                StringReader reader = new StringReader(mentor.ToString());
                XmlSerializer serializer = new XmlSerializer(typeof(Mentor));
                ment = (Mentor)serializer.Deserialize(reader);
                mentorList.Add(ment);
            }

            foreach (var applicant in applicants)
            {
                Applicant appl = new Applicant();
                StringReader reader = new StringReader(applicant.ToString());
                XmlSerializer serializer = new XmlSerializer(typeof(Applicant));
                appl = (Applicant)serializer.Deserialize(reader);
                applicantList.Add(appl);
            }

            for (int i = 0; i < mentorList.Count; i++)
            {
                if (mentorList[i].FirstName.Equals(contactMentorName)
                    || mentorList[i].LastName.Equals(contactMentorName)
                    || mentorList[i].LastName.Equals(contactMentorName)
                    || mentorList[i].Nickname.Equals(contactMentorName))
                {
                    applicantList2.Add(applicantList[i]);
                }
            }

            return applicantList2;
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetAppliedStudentEmailList()
        {
            var applicants = _doc.Descendants("Applications").Descendants("Application")
                .Descendants("Applicant").Descendants("Email");
            var emails = new List<string>();
            foreach (var applicant in applicants)
            {
                emails.Add(applicant.Value);
            }

            return emails;
        }
    }
}
