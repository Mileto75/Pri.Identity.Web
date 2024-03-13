﻿using Pri.CleanArchitecture.Music.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.CleanArchitecture.Music.Core.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetAll();
        Task<bool> AddAsync(T toAdd);
        Task<bool> DeleteAsync(T toDelete);
        Task<bool> UpdateAsync(T toUpdate);
        Task<bool> CheckIfExistsAsync(int id);
    }
}
