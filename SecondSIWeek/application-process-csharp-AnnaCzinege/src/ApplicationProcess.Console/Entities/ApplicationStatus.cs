namespace Codecool.ApplicationProcess.Entities
{
    /// <summary>
    /// Possible application statuses.
    /// </summary>
    public enum ApplicationStatus
    {
        /// <summary>
        /// When the applicant starts the process.
        /// </summary>
        Applied,

        /// <summary>
        /// In some reason the process is terminated.
        /// </summary>
        Cancelled,

        /// <summary>
        /// When the applicant accepted as a new student.
        /// </summary>
        Approved,

        /// <summary>
        /// When the applicant failed during the application process.
        /// </summary>
        Rejected,
    }
}