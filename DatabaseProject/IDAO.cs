namespace DatabaseProject;

public interface IDAO<T> where T : IBaseClass
{
    T? GetByID(int id);
    IEnumerable<T> GetAll();
    void Save(T element);
    void Delete(T element);
}