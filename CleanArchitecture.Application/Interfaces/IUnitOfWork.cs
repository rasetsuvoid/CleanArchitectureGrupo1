using System;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Almacen> Almacenes { get; }
        IGenericRepository<Categoria> Categorias { get; }
        IGenericRepository<Existencia> Existencias { get; }
        IGenericRepository<MovimientoInventario> Movimientos { get; }
        IGenericRepository<Producto> Productos { get; }
        IGenericRepository<Proveedor> Proveedores { get; }
        IGenericRepository<UnidadMedida> Unidades { get; }

        Task<int> SaveChangesAsync();
    }
}