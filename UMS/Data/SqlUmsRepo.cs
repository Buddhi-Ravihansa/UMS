using System;
using System.Collections.Generic;
using System.Linq;
using UMS.Contexts;
using UMS.Models;


namespace UMS.Data

{
    public class SqlUmsRepo : IUmsRepo
    {
        private readonly UmsContext _context;

        public SqlUmsRepo(UmsContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetUsers(int faculty)
        {
            if (faculty <= 0)
            {
                return null;
            }

            var facultyId = _context.Faculties.FirstOrDefault(f => f.Id == faculty)?.Id;

            if (facultyId == null)
            {
                return null;
            }
            var departmentIds = _context.Departments
                 .Where(d => d.FacultyId == faculty)
                 .Select(d => d.Id)
                 .ToList();

            return _context.Users
                    .Where(u => departmentIds.Contains(u.DepartmentId))
                    .ToList();


        }

        public IEnumerable<User> GetUsers(int faculty, int department)
        {
            if (faculty <= 0)
            {
                return null;
            }

            var facultyId = _context.Faculties.FirstOrDefault(f => f.Id == faculty)?.Id;

            if (department <= 0 || facultyId == null)
            {
                return null;
            }

            var departmentIds = _context.Departments
                .Where(d => d.FacultyId == facultyId && d.Id == department)
                .Select(d => d.Id)
                .ToList();

            return _context.Users
                    .Where(u => departmentIds.Contains(u.DepartmentId))
                    .ToList();

        }

        public IEnumerable<User> GetUsers(int faculty, int department, int role)
        {
            if (faculty <= 0)
            {
                return null;
            }

            var facultyId = _context.Faculties.FirstOrDefault(f => f.Id == faculty)?.Id;

            if (department <= 0 || facultyId == null)
            {
                return null;
            }

            var departmentIds = _context.Departments
                .Where(d => d.FacultyId == facultyId && d.Id == department)
                .Select(d => d.Id)
                .ToList();

            return _context.Users
                    .Where(u => departmentIds.Contains(u.DepartmentId) && u.RoleId == role)
                    .ToList();

        }

        public IEnumerable<User> GetUsers(int faculty, string text)
        {
            if (faculty <= 0)
            {
                return null;
            }

            var facultyId = _context.Faculties.FirstOrDefault(f => f.Id == faculty)?.Id;

            if (facultyId == null)
            {
                return null;
            }
            var departmentIds = _context.Departments
                 .Where(d => d.FacultyId == facultyId)
                 .Select(d => d.Id)
                 .ToList();

            if (!string.IsNullOrWhiteSpace(text))
            {
                return _context.Users
                    .Where(u => departmentIds.Contains(u.DepartmentId) && u.Name.Trim() == text.Trim())
                    .ToList();
            }
            return _context.Users
                    .Where(u => departmentIds.Contains(u.DepartmentId))
                    .ToList();
        }

        public IEnumerable<User> GetUsers(int faculty, int department, string text)
        {
            if (faculty <= 0)
            {
                return null;
            }

            var facultyId = _context.Faculties.FirstOrDefault(f => f.Id == faculty)?.Id;

            if (facultyId == null)
            {
                return null;
            }
            var departmentIds = _context.Departments
                 .Where(d => d.FacultyId == facultyId && d.Id == department)
                 .Select(d => d.Id)
                 .ToList();

            if (!string.IsNullOrWhiteSpace(text))
            {
                return _context.Users
                    .Where(u => departmentIds.Contains(u.DepartmentId) && u.Name.Trim() == text.Trim())
                    .ToList();
            }
            return _context.Users
                    .Where(u => departmentIds.Contains(u.DepartmentId))
                    .ToList();


        }

        public IEnumerable<User> GetUsers(int faculty, int department, int role, string text)
        {
            if (faculty <= 0)
            {
                return null;
            }

            var facultyId = _context.Faculties.FirstOrDefault(f => f.Id == faculty)?.Id;

            if (department <= 0 || facultyId == null)
            {
                return null;
            }

            var departmentIds = _context.Departments
                .Where(d => d.FacultyId == facultyId && d.Id == department)
                .Select(d => d.Id)
                .ToList();

            if (!string.IsNullOrWhiteSpace(text))
            {
                return _context.Users
                   .Where(u => departmentIds.Contains(u.DepartmentId) && u.RoleId == role && u.Name.Trim() == text.Trim())
                   .ToList();
            }
            return _context.Users
                    .Where(u => departmentIds.Contains(u.DepartmentId))
                    .ToList();

        }


    }
}