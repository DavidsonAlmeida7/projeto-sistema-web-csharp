using Microsoft.EntityFrameworkCore;
using ProjetoSistemaWeb.Data;
using ProjetoSistemaWeb.Models;

namespace ProjetoSistemaWeb.Services
{
    public class DepartmentService
    {
        private readonly ProjetoSistemaWebContext _context;

        public DepartmentService(ProjetoSistemaWebContext context)
        {
            _context = context;
        }

        /*
         * ToList é do LINQ para chamadas no banco sincronas
         * ToListAsync é do EntityFrameworkCore para pode chamadas asssincronas
         */
        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
