using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using J_LearingSystem.Models;

namespace J_LearningSystem.Data
{
     public class UnitOfWork : IDisposable
    {
        private SystemContext _db;

        private List<object> _list;

        public UnitOfWork()
        {
            _list = new List<object>();
            _db = new SystemContext();
        }

        public BaseRepository<T> GetRepository<T>() where T : BaseEntity {
            var repo =  _list.OfType<BaseRepository<T>>().FirstOrDefault();
            if (repo == null) {
                repo = new BaseRepository<T>(_db);
                _list.Add(repo);
            }
            return repo;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {
                    _list.Clear();
                    _list = null;
                    _db.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UnitOfWork() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose() {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion


    }
}
