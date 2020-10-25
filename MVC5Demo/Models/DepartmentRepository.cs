using System;
using System.Linq;
using System.Collections.Generic;

namespace MVC5Demo.Models
{
	public  class DepartmentRepository : EFRepository<Department>, IDepartmentRepository
	{
		public Department Get單一筆部門資料(int id)
        {
			return this.All().FirstOrDefault(p => p.DepartmentID == id);
        }
	}

	public  interface IDepartmentRepository : IRepository<Department>
	{

	}
}