using System.Collections.Generic;

namespace application.services
{
    /// <summary>
    /// interface <c>IService</c>  generic interface to be used as base service
    /// the interface defines the basics CRUD operations
    /// </summary>
    /// <typeparam name="TE">the Type of the Entity</typeparam>
    /// <typeparam name="TK">Type of the Entity Id</typeparam>
    public interface IService<TE, TK>
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
        TE GetById(TK id);
        
        /// <summary>
        /// method <c>GetAll</c> retrieves all entities 
        /// </summary>
        /// <returns>
        /// return ICollection of the entities
        /// </returns>
        ICollection<TE> GetAll();
        
        /// <summary>
        /// method <c>Create</c> create new Entity 
        /// </summary>
        /// <param name="obj"> the entity to be created</param>
        /// <returns> the created entity</returns>
        TE Create(TE obj);
        
        /// <summary>
        /// method <c>Update</c> update an existing entity
        /// </summary>
        /// <param name="obj"> the modified entity </param>
        /// <returns> the new modified entity</returns>
        TE Edit(TE obj);
        
        /// <summary>
        /// method <c>Delete</c> delete an existing entity with given id
        /// </summary>
        /// <param name="id"> the entity id that must be deleted</param>
        void DeleteById(TK id);
    }
    
}