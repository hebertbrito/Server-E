﻿using Data.UseCases.UserPlan;
using Domain.Models.UserPlan.Request;
using Domain.Models.UserPlan.Response;
using Infra.Database.SQLServer.Plan;
using Infra.Database.SQLServer.UserPlan;
using Infra.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Produces("application/json")]
    [Route("api/plan/relationship")]
    public class UserPlansRelationShipController : Controller
    {
        [Route("create")]
        [HttpPost]

        public async Task<ActionResult<List<UserPlanModelResponse>>> GetListUserPlan([FromBody] UserPlanModel userPlanModel)
        {
            DatabaseHelperClass databaseHelperClass = new DatabaseHelperClass("YOUR_CONNECTIONSTRING");
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Model is Invalid");
                }

                GetListUserPlanRepository getListUserPlanRepository = new GetListUserPlanRepository(databaseHelperClass);
                DbGetListUserPlan dbGetListUserPlan = new DbGetListUserPlan(getListUserPlanRepository);
                var response = await dbGetListUserPlan.GetUSerPlanList(userPlanModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                databaseHelperClass.connection.Close();
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
