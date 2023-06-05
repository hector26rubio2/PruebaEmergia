using Microsoft.EntityFrameworkCore;
using PruebaEmergia.Infrastructure.Data;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    public class FacturaRepository  : IFacturaRepository
    {
        private readonly emergiaContext _context;

        public FacturaRepository (emergiaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Factura>> GetFacturas()
        {
            var facturas = await _context.Factura.ToListAsync();
            return facturas; 
        }

        public async Task<Factura> GetFactura(int id)
        {
            var factura =await _context.Factura.FirstOrDefaultAsync(x => x.IdFactura == id);
            return factura;
        }

        public async Task InsertFactura(Factura factura)
        {
            _context.Factura.Add(factura);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateFactura(Factura factura)
        {
            var currentFactura =await GetFactura(factura.IdFactura);
            currentFactura.Fecha = factura.Fecha;
            currentFactura.NumCliente = factura.NumCliente;
            currentFactura.NumVendedor = factura.NumVendedor;
            int rows = await _context.SaveChangesAsync();

            return rows>0;
        }

        public async Task<bool> DeleteFactura(int id)
        {
            var currentFactura = await GetFactura(id);
            _context.Factura.Remove(currentFactura);
            int rows = await _context.SaveChangesAsync();

            return rows > 0;
        }
    }
}
