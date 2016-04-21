using IdentityCompletoNHibernate.Models;
using Microsoft.AspNet.Identity;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityCompletoNHibernate.App_Start.Identity
{
    public class RoleStore<TRole> : IQueryableRoleStore<TRole>, IRoleStore<TRole>, IDisposable where TRole : IdentityRole
    {
        private bool _disposed;

        /// <summary>
        /// If true then disposing this object will also dispose (close) the session. False means that external code is responsible for disposing the session.
        /// </summary>
        public bool ShouldDisposeSession { get; set; }

        public ISession Context { get; private set; }

        public RoleStore(ISession context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            ShouldDisposeSession = true;
            Context = context;
        }

        public virtual Task<TRole> FindByIdAsync(string roleId)
        {
            ThrowIfDisposed();
            return Task.FromResult(Context.Get<TRole>(roleId));
        }

        public virtual Task<TRole> FindByNameAsync(string roleName)
        {
            ThrowIfDisposed();
            return Task.FromResult(Queryable.FirstOrDefault(Queryable.Where(Context.Query<TRole>(), (u => u.Name.ToUpper() == roleName.ToUpper()))));
        }

        public virtual Task CreateAsync(TRole role)
        {
            ThrowIfDisposed();
            if (role == null)
                throw new ArgumentNullException("role");
            Context.Save(role);
            Context.Flush();
            return Task.FromResult(0);
        }

        public virtual Task DeleteAsync(TRole role)
        {
            ThrowIfDisposed();
            if (role == null)
            {
                throw new ArgumentNullException("role");
            }
            Context.Delete(role);
            Context.Flush();
            return Task.FromResult(0);
        }

        public virtual Task UpdateAsync(TRole role)
        {
            ThrowIfDisposed();
            if (role == null)
                throw new ArgumentNullException("role");
            Context.Update(role);
            Context.Flush();
            return Task.FromResult(0);
        }

        private void ThrowIfDisposed()
        {
            if (_disposed)
                throw new ObjectDisposedException(GetType().Name);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !_disposed && ShouldDisposeSession)
                Context.Dispose();
            _disposed = true;
            Context = null;
        }

        public IQueryable<TRole> Roles
        {
            get
            {
                ThrowIfDisposed();
                return Context.Query<TRole>();
            }
        }
    }
}
