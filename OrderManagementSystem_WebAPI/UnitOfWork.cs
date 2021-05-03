using OrderManagementSystem_WebAPI.Models;
using OrderManagementSystem_WebAPI.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace OrderManagementSystem_WebAPI
{
    public class UnitOfWork : IDisposable
    {
        private readonly DataContext _context = new DataContext();
        private bool _disposed = false;
        private GenericRepository<Customer> _customerRepository;
        private GenericRepository<Product> _productRepository;
        private GenericRepository<Order> _orderRepository;

        public GenericRepository<Customer> CustomerRepository => _customerRepository ?? (_customerRepository = new GenericRepository<Customer>(_context));
        public GenericRepository<Product> ProductRepository => _productRepository ?? (_productRepository = new GenericRepository<Product>(_context));
        public GenericRepository<Order> OrderRepository => _orderRepository ?? (_orderRepository = new GenericRepository<Order>(_context));

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