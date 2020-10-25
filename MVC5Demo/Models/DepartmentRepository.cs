using System;
using System.Linq;
using System.Collections.Generic;

namespace MVC5Demo.Models
{
	public  class DepartmentRepository : EFRepository<Department>, IDepartmentRepository
	{

	}

	public  interface IDepartmentRepository : IRepository<Department>
	{

	}
}