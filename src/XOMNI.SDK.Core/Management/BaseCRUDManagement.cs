﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;

namespace XOMNI.SDK.Core.Management
{
    public abstract class BaseCRUDManagement<T> : ManagementBase
    {
        protected abstract CRUDApiAccessBase<T> ApiAccess { get; }

        /// <summary>
        /// Adds a new entity
        /// </summary>
        /// <param name="entity">Entity to be added</param>
        /// <returns>Added entity</returns>
        public virtual Task<T> AddAsync(T entity)
        {
            return ApiAccess.PostAsync(entity, base.ApiCredential);
        }

        /// <summary>
        /// Delete entity by its id
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns></returns>
        public virtual Task DeleteAsync(int id)
        {
            return ApiAccess.DeleteAsync(id, base.ApiCredential);
        }

        /// <summary>
        /// Updates an entity
        /// </summary>
        /// <param name="entity">Entity to be updated</param>
        /// <returns>Updated entity</returns>
        public virtual Task<T> UpdateAsync(T entity)
        {
            return ApiAccess.PutAsync(entity, base.ApiCredential);
        }

        /// <summary>
        /// Fetchs an entity by its id
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns>Fetched entity</returns>
        public virtual Task<T> GetByIdAsync(int id)
        {
            return ApiAccess.GetByIdAsync(id, base.ApiCredential);
        }
    }
}