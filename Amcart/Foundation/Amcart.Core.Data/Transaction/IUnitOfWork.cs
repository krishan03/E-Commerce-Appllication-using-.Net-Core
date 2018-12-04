using Amcart.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Amcart.Core.Data.Transaction
{
    public interface IUnitOfWork : IDisposable
    {
        int Save();

        OperationResult Commit();

        void Rollback();

        Task<int> SaveAsyc();
    }
}
