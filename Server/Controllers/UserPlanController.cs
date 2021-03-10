using Data.UseCases.Plan;
using Domain.Models.Plan.Request;
using Infra.Database.SQLServer.Plan;
using Infra.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Produces("application/json")]
    [Route("api/plan/")]
    public class UserPlanController : Controller
    {
        [Route("create")]
        [HttpPost]
        public async Task<ActionResult> CreatePlan([FromBody] PlanModel planModel)
        {
            DatabaseHelperClass databaseHelperClass = new DatabaseHelperClass("YOUR_CONNECTIONSTRING");
            try
            {
                if(!ModelState.IsValid)
                {
                    throw new Exception("Model is Invalid");
                }

                CreatePlanUserRepository createPlanUserRepository = new CreatePlanUserRepository(databaseHelperClass);
                DbCreatePlanUser dbCreatePlanUser = new DbCreatePlanUser(createPlanUserRepository);
                await dbCreatePlanUser.CreatePlanUser(planModel);
                return Ok();
            }
            catch (Exception ex)
            {
                databaseHelperClass.connection.Close();
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
