using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Management_System.Data;
using Task_Management_System.Models;

namespace Task_Management_System.Controllers
{
    [ApiController]
    [Route("api/proPlans")]
    [Produces("application/json")]
    public class ProPlansController
    {
        private readonly IRepository<ProPlan> proPlansRepository;

        public ProPlansController(IRepository<ProPlan> repository)
        {
            proPlansRepository = repository;
        }


    }
}
