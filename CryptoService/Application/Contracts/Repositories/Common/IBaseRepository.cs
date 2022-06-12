using System.Linq.Expressions;

namespace Application.Contracts.Repositories.Common;

public interface IBaseRepository<T> where T : class
{
    /// <summary>
    /// Gets object of type T by specified value from parameters
    /// </summary>
    /// <example>x => x.Email == email</example>
    /// <param name="criteria">Lambda expression</param>
    /// <returns>Object matching given criteria</returns>
    Task<T> GetAsync(Expression<Func<T, bool>> criteria);
    
    /// <summary>
    /// Gets all objects of type T
    /// </summary>
    /// <returns>A list of T Objects</returns>
    Task<List<T>> GetAllAsync();
    
    /// <summary>
    /// Gets all objects of type T matching specified criteria
    /// </summary>
    /// <returns>A list of T Objects</returns>
    Task<List<T>> GetAllAsyncWithCriteria(Expression<Func<T, bool>> criteria);

    /// <summary>
    /// Checks by Id if object does exist
    /// </summary>
    /// <param name="criteria">Lambda function with check condition</param>
    /// <returns>True if exists</returns>
    Task<bool> CheckIfExistsAsync(Expression<Func<T, bool>> criteria);
    
    /// <summary>
    /// Creates object of type T
    /// </summary>
    /// <param name="entity">Object to be created</param>
    /// <returns>Created object</returns>
    Task<T> AddAsync(T entity);
        
    /// <summary>
    /// Updates existing object with values from T entity
    /// </summary>
    /// <param name="entity">Object with new values to updatePut existing one</param>
    void Update(T entity);
        
    /// <summary>
    /// Removes object of type T
    /// </summary>
    /// <param name="entity">Object to be removed</param>
    void Delete(T entity);
}