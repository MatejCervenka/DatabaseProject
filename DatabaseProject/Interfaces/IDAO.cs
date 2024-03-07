namespace DatabaseProject;

public interface IDAO<T> where T : IBaseClass
{
    T? GetById(int id);
    IEnumerable<T> GetAll();
    void Insert(T element);
    void Delete(T element);
    
    void Update(T element);
    
    void DeleteAll();
}