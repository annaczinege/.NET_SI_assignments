using System;
using System.Collections.Generic;
using Codecool.ApplicationProcess.Entities;

namespace Codecool.ApplicationProcess.Data
{
    /// <summary>
    /// Interface for application process repository.
    /// </summary>
    public interface IApplicationRepository
    {
        /// <summary>
        /// Gets all stored <see cref="Mentor"/>.
        /// </summary>
        /// <param name="city">The location we are interested in.</param>
        /// <returns>All stored mentors as an <see cref="IEnumerable{Mentor}"/> collection.</returns>
        IEnumerable<Mentor> GetAllMentorFrom(City city);

        /// <summary>
        /// Gets all mentors whom favourite language is equal to the given language.
        /// </summary>
        /// <param name="language">Programming language.</param>
        /// <returns><see cref="IEnumerable{Mentor}"/> collection of mentors.</returns>
        IEnumerable<Mentor> GetAllMentorWhomFavoriteLanguage(string language);

        /// <summary>
        /// Gets all <see cref="Applicant"/> who applied and her contact mentor is equal to the given one.
        /// If the given <paramref name="contactMentorName"/> is less then 3 character then it throws <see cref="ArgumentException"/>.
        /// </summary>
        /// <param name="contactMentorName">The name of the <see cref="Mentor"/> who is the contact person.</param>
        /// <returns><see cref="IEnumerable{Applicant}"/> collection of applicants.</returns>
        IEnumerable<Applicant> GetApplicantsOf(string contactMentorName);

        /// <summary>
        /// Calculate how many applications were registered after <paramref name="date"/>.
        /// </summary>
        /// <param name="date">The date we would like to get applications after.</param>
        /// <returns>Total number of applications.</returns>
        int AmountOfApplicationAfter(DateTime date);

        /// <summary>
        /// Gets all email address of <see cref="Applicant"/>'s whom <see cref="ApplicationStatus"/> is <see cref="ApplicationStatus.Applied"/>.
        /// </summary>
        /// <returns><see cref="IEnumerable{String}"/> collection of email addresses.</returns>
        IEnumerable<string> GetAppliedStudentEmailList();
    }
}