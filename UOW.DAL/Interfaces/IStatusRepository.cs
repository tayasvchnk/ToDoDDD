using ToDoDDD.DAL.Interfaces;
using ToDoDDD.DAL.Entities;

namespace ToDoDDD.DAL.Interfaces;

public interface IStatusRepository : IRepository<Status>, IDisposable
{

}