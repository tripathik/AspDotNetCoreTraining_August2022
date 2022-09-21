﻿using EmployeeDataCore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataCore.Abctractions
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetEmployee();
    }
}
