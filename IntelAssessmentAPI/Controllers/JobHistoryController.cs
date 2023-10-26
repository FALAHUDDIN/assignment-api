using IntelAssessmentAPI.Data;
using IntelAssessmentAPI.Models.JobHistory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntelAssessmentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json", new string[] { "text/plain", "text/json" })]
    public class JobHistoryController : Controller
    {
        private readonly AboutAPIDbContext dbContext;

        public JobHistoryController(AboutAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<JobHistory>> GetJobHistories()
        {
            return Ok(await dbContext.JobHistory.ToListAsync());
        }

        [HttpGet]
        [Route("specify")]
        public async Task<ActionResult<JobHistory>> GetJobHistory(Guid idProfile, Guid idJobHistory)
        {
            if (idJobHistory != Guid.Empty)
            {
                var jobHistory = await dbContext.JobHistory.FindAsync(idJobHistory);
                if (jobHistory == null)
                {
                    return NotFound();
                }
                return Ok(jobHistory);
            }
            else
            {
                var jobHistory = await dbContext.JobHistory.Where(b => b.IdProfile == idProfile).ToListAsync();
                if (jobHistory == null)
                {
                    return NotFound();
                }
                return Ok(jobHistory);
            }
        }

        [HttpPost]
        [Route("add/{idProfile:guid}")]
        public async Task<ActionResult<JobHistory>> AddJobHistory([FromRoute] Guid idProfile, AddJobHistoryRequest addJobHistoryRequest)
        {
            var profile = await dbContext.Profile.Include(p => p.JobHistory).FirstOrDefaultAsync(p => p.Id == idProfile);
            if (profile == null)
            {
                return NotFound();
            }

            var newJobHistory = new JobHistory()
            {
                Id = Guid.NewGuid(),
                IdProfile = idProfile,
                CompanyName = addJobHistoryRequest.CompanyName,
                Position = addJobHistoryRequest.Position,
                Department = addJobHistoryRequest.Department,
                JobDescription = addJobHistoryRequest.JobDescription,
                StartDate = addJobHistoryRequest.StartDate,
                EndDate = addJobHistoryRequest.EndDate,
            };

            await dbContext.JobHistory.AddAsync(newJobHistory);
            await dbContext.SaveChangesAsync();
            return Ok("Job history added.");
        }

        [HttpPut]
        [Route("update/{idJobHistory:guid}")]
        public async Task<ActionResult<JobHistory>> UpdateJobHistory([FromRoute] Guid idJobHistory, UpdateJobHistoryRequest updateJobHistoryRequest)
        {
            var jobHistory = await dbContext.JobHistory.FindAsync(idJobHistory);
            if (jobHistory == null)
            {
                return NotFound();
            }

            if (updateJobHistoryRequest.CompanyName != null)
            {
                jobHistory.CompanyName = updateJobHistoryRequest.CompanyName;
            }

            if (updateJobHistoryRequest.Position != null)
            {
                jobHistory.Position = updateJobHistoryRequest.Position;
            }

            if (updateJobHistoryRequest.Department != null)
            {
                jobHistory.Department = updateJobHistoryRequest.Department;
            }

            if (updateJobHistoryRequest.JobDescription != null)
            {
                jobHistory.JobDescription = updateJobHistoryRequest.JobDescription;
            }

            if (updateJobHistoryRequest.StartDate != null)
            {
                jobHistory.StartDate = updateJobHistoryRequest.StartDate;
            }

            if (updateJobHistoryRequest.EndDate != null)
            {
                jobHistory.EndDate = updateJobHistoryRequest.EndDate;
            }

            await dbContext.SaveChangesAsync();
            return Ok("Job history updated.");
        }

        [HttpDelete]
        [Route("delete/{idJobHistory:guid}")]
        public async Task<ActionResult<JobHistory>> DeleteJobHistory([FromRoute] Guid idJobHistory)
        {
            var jobHistory = await dbContext.JobHistory.FindAsync(idJobHistory);
            if (jobHistory == null)
            {
                return NotFound();
            }
            dbContext.JobHistory.Remove(jobHistory);
            await dbContext.SaveChangesAsync();
            return Ok("Job history deleted.");
        }
    }
}
