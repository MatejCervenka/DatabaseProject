namespace DatabaseProject.Interfaces
{
    /// <summary>
    /// Represents the base interface for classes that have an integer identifier (Id).
    /// </summary>
    public interface IBaseClass
    {
        /// <summary>
        /// Gets or sets the unique identifier of the class.
        /// </summary>
        int Id { get; set; }
    }
}