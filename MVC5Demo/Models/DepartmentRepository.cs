using System;
using System.Linq;
using System.Collections.Generic;

namespace MVC5Demo.Models
{
    public class DepartmentRepository : EFRepository<Department>, IDepartmentRepository
    {
        public override IQueryable<Department> All()
        {
            return base.All().Where(p => p.IsDeleted == false);
        }

        public Department Get單一筆部門資料(int id)
        {
            return this.All().FirstOrDefault(p => p.DepartmentID == id);
        }

        public override void Delete(Department entity)
        {
            this.UnitOfWork.Context.Configuration.ValidateOnSaveEnabled = false;

            entity.IsDeleted = true;
        }
    }

    public  interface IDepartmentRepository : IRepository<Department>
	{
        IQueryable<Department> All();
        void Delete(Department entity);
        Department Get單一筆部門資料(int id);
    }
}