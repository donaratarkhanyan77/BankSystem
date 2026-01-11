using Bank.Domain.Interface.IRepositories;
using Bank.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Bank.Infrastructure.Interfaces;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly BankDbContext _context;
    protected readonly DbSet<T> _db;

    public BaseRepository(BankDbContext context)
    {
        _context = context;
        _db = context.Set<T>();
    }

    public async Task<T> GetByIdAsync(int id) => await _db.FindAsync(id);
    public async Task<List<T>> GetAllAsync() => await _db.ToListAsync();
    public async Task AddAsync(T entity)
    {
        await _db.AddAsync(entity);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAsync(T entity)
    {
        _db.Update(entity);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(T entity)
    {
        _db.Remove(entity);
        await _context.SaveChangesAsync();
    }
 
}
