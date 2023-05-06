using ToDoDDD.DAL.Interfaces;
using ToDoDDD.DAL.Entities;
using ToDoDDD.DAL.Datas;

namespace ToDoDDD.BLL.Repositories;

public class PriorityRepository : Repository<Priority>
{
    private readonly AppDbContext _db;
    public PriorityRepository( AppDbContext db ) : base(db)
    {
        _db = db;
    }

}