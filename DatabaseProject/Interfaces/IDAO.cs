using DatabaseProject.Interfaces;

namespace DatabaseProject
{
    /// <summary>
    /// Represents a generic interface for Data Access Objects (DAOs) providing basic CRUD operations.
    /// </summary>
    /// <typeparam name="T">The type of object that the DAO operates on, must implement the IBaseClass interface.</typeparam>
    public interface IDAO<T> where T : IBaseClass
    {
        /// <summary>
        /// Retrieves all instances of the specified type from the data store.
        /// </summary>
        /// <returns>An IEnumerable of the specified type containing all instances from the data store.</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Adds a new element of the specified type to the data store.
        /// </summary>
        /// <param name="element">The element to be added to the data store.</param>
        void Add(T element);

        /// <summary>
        /// Deletes an element from the data store based on its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the element to be deleted.</param>
        void Delete(int id);

        /// <summary>
        /// Updates an existing element in the data store.
        /// </summary>
        /// <param name="element">The element with updated data to be persisted in the data store.</param>
        void Update(T element);

        /// <summary>
        /// Deletes all elements of the specified type from the data store.
        /// </summary>
        void DeleteAll();
    }
}