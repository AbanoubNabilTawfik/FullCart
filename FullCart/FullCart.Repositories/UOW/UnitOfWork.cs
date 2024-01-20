using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace FullCart.Repositories.UOW
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : DbContext
    {
        private readonly T _dbContext;
        public UnitOfWork(T dbContext)
        {
            _dbContext = dbContext;
        }

        public int Save()
        {
            var res = _dbContext.SaveChanges();
            DetachAllEntities();
            return res;
        }

        private void DetachAllEntities()
        {
            EntityEntry[] entityEntries = _dbContext.ChangeTracker.Entries().ToArray();
            foreach (EntityEntry entityEntry in entityEntries)
                entityEntry.State = EntityState.Detached;
        }

        public async Task<int> SaveAsync()
        {
            var res = await _dbContext.SaveChangesAsync();
            DetachAllEntities();
            return res;
        }

        public IDbContextTransaction CurrentTransaction { get; private set; } = null!;

        public IsolationLevel CurrentTransactionIsolationLevel => CurrentTransaction != null ? CurrentTransaction.GetDbTransaction().IsolationLevel : IsolationLevel.Unspecified;

        public IDbContextTransaction BeginTrainsaction(IsolationLevel IsolationLevel = IsolationLevel.Unspecified)
        {
            if (IsolationLevel == IsolationLevel.Unspecified)
                CurrentTransaction = _dbContext.Database.BeginTransaction();
            else
                CurrentTransaction = _dbContext.Database.BeginTransaction(IsolationLevel);
            return CurrentTransaction;
        }
        public IExecutionStrategy CreateExecutionStrategy()
        {
            return _dbContext.Database.CreateExecutionStrategy();
        }
    }
    class UnitOfWork
    {
    }
}
