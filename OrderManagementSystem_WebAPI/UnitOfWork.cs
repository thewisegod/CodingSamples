using OrderManagementSystem_WebAPI.Models;
using OrderManagementSystem_WebAPI.Repositories.Concrete;
using System;

namespace OrderManagementSystem_WebAPI
{
    public class UnitOfWork : IDisposable
    {   
        private bool _disposed = false;
        private readonly DataContext _context = new DataContext();
        private GenericRepository<Customer> _customerRepository;
        private GenericRepository<Product> _productRepository;
        private GenericRepository<Order> _orderRepository;
        private GenericRepository<OrderItem> _orderItemRepository;
        private GenericRepository<Supplier> _supplierRepository;

        public GenericRepository<Customer> CustomerRepository => _customerRepository ?? (_customerRepository = new GenericRepository<Customer>(_context));
        public GenericRepository<Product> ProductRepository => _productRepository ?? (_productRepository = new GenericRepository<Product>(_context));
        public GenericRepository<Order> OrderRepository => _orderRepository ?? (_orderRepository = new GenericRepository<Order>(_context));
        public GenericRepository<OrderItem> OrderItemRepository => _orderItemRepository ?? (_orderItemRepository = new GenericRepository<OrderItem>(_context));
        public GenericRepository<Supplier> SupplierRepository => _supplierRepository ?? (_supplierRepository = new GenericRepository<Supplier>(_context));

        public void Complete()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}