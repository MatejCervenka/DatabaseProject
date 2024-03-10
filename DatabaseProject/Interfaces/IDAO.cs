namespace DatabaseProject;

public interface IDAO<T> where T : IBaseClass
{
    IEnumerable<T> GetAll();
    void Add(T element);
    void Delete(int id);
    
    void Update(T element);
    
    void DeleteAll();
}