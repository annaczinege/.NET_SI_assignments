using System;
using System.Xml.Serialization;

namespace Codecool.ApplicationProcess.Entities
{
    /// <summary>
    /// Possible application statuses.
    /// </summary>
    [Serializable]
    [XmlRoot("Status")]
    public enum ApplicationStatus
    {
        /// <summary>
        /// When the applicant starts the process.
        /// </summary>
        [XmlEnum("Status")]
        Applied,

        /// <summary>
        /// In some reason the process is terminated.
        /// </summary>
        [XmlEnum("Status")]
        Cancelled,

        /// <summary>
        /// When the applicant accepted as a new student.
        /// </summary>
        [XmlEnum("Status")]
        Approved,

        /// <summary>
        /// When the applicant failed during the application process.
        /// </summary>
        [XmlEnum("Status")]
        Rejected,
    }
}