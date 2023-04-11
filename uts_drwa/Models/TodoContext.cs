using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Models;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
    {
    }

    public DbSet<Guru> TodoItems { get; set; } = null!;

    public DbSet<TodoApi.Models.Mapel> Mapel { get; set; } = default!;

    public DbSet<TodoApi.Models.JadwalGuru> JadwalGuru { get; set; } = default!;
}