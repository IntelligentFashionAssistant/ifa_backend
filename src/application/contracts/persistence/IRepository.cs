using System.Collections.Generic;

namespace application.persistence
{
    /// <summary>
    /// interface <c>IRepository</c>  generic interface to be used as base Repository 
    /// the interface defines the basics CRUD operations
    /// </summary>
    /// <typeparam name="TEntity">the Type of the Entity</typeparam>
    /// <typeparam name="TEntityId">Type of the Entity Id</typeparam>
    public interface IRepository<TEntity, TEntityId>
    {
        /// <summary>
        /// method <c>GetById</c> retrieve entity with given id 
        /// </summary>
        /// <param name="id">
        /// the id of the entity
        /// </param>
        /// <returns>
        ///  Entity
        /// </returns>
        TEntity GetById(TEntityId id);
        
        /// <summary>
        /// method <c>GetAll</c> retrieves all entities 
        /// </summary>
        /// <returns>
        /// return ICollection of the entities
        /// </returns>
        ICollection<TEntity> GetAll();
        
        /// <summary>
        /// method <c>Create</c> create new Entity 
        /// </summary>
        /// <param name="obj"> the entity to be created</param>
        /// <returns> the created entity</returns>
        TEntity Create(TEntity obj);
        
        /// <summary>
        /// method <c>Update</c> update an existing entity
        /// </summary>
        /// <param name="obj"> the modified entity </param>
        /// <returns> the new modified entity</returns>
        TEntity Update(TEntity obj);
        
        /// <summary>
        /// method <c>Delete</c> delete an existing entity with given id
        /// </summary>
        /// <param name="id"> the entity id that must be deleted</param>
        void DeleteById(TEntityId id);
        
    }
}