using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoDDD.DAL.Datas;
using ToDoDDD.DAL.Entities;

namespace ToDoDDD.BLL.Repositories;

public class TaskRepository : Repository<Tasks>
{

    private readonly AppDbContext _db;
    public TaskRepository( AppDbContext db ) : base(db)
    {
        _db = db;
    }

    public void ChangeStatus( Guid id )
    {
        Guid openStatus = _db.Status.FirstOrDefault(s => s.StatusName == "Открыта")!.Id;
        Guid closeStatus = _db.Status.FirstOrDefault(s => s.StatusName == "Закрыта")!.Id;
        Guid newStatus = _db.Status.FirstOrDefault(s => s.StatusName == "Новая")!.Id;

        Tasks? myTask = GetByIdIncluded(id);

        myTask.StatusId = myTask.StatusId == newStatus ? openStatus : closeStatus;

        Update(myTask);
        Save();
    }




    public IEnumerable<Tasks> GetIncluded()
    {
        return _db.Tasks
            .Include(p => p.Status)
            .Include(p => p.Priority);
        //.ToList();
    }
    public Tasks GetByIdIncluded( Guid id )
    {
        return _db.Tasks
            .Include(p => p.Priority)
            .Include(p => p.Status)
            .FirstOrDefault(t => t.Id == id);
    }

}