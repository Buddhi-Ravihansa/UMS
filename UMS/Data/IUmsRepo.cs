using System.Collections.Generic;
using UMS.Models;

namespace UMS.Data
{
    public interface IUmsRepo
    {
        IEnumerable<User> GetUsers(int faculty);
        IEnumerable<User> GetUsers(int faculty, int department);
        IEnumerable<User> GetUsers(int faculty, int department, int role);
        IEnumerable<User> GetUsers(int faculty, string text);
        IEnumerable<User> GetUsers(int faculty, int department, string text);
        IEnumerable<User> GetUsers(int faculty, int department, int role, string text);

    }
}