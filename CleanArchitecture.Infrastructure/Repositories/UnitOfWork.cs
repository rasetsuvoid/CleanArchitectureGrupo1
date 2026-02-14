using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CleanArchitecture.Infrastructure.Data.ApplicationDbContext _context;

        public IGenericRepository<Almacen> Almacenes { get; }
        public IGenericRepository<Categoria> Categorias { get; }
        public IGenericRepository<Existencia> Existencias { get; }
        public IGenericRepository<MovimientoInventario> Movimientos { get; }
        public IGenericRepository<Producto> Productos { get; }
        public IGenericRepository<Proveedor> Proveedores { get; }
        public IGenericRepository<UnidadMedida> Unidades { get; }

        public UnitOfWork(CleanArchitecture.Infrastructure.Data.ApplicationDbContext context)
        {
            _context = context;
            Almacenes = new GenericRepository<Almacen>(context);
            Categorias = new GenericRepository<Categoria>(context);
            Existencias = new GenericRepository<Existencia>(context);
            Movimientos = new GenericRepository<MovimientoInventario>(context);
            Productos = new GenericRepository<Producto>(context);
            Proveedores = new GenericRepository<Proveedor>(context);
            Unidades = new GenericRepository<UnidadMedida>(context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}