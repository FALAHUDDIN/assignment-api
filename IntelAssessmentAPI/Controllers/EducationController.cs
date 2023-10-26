using IntelAssessmentAPI.Data;
using IntelAssessmentAPI.Models.Education;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntelAssessmentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json", new string[] { "text/plain", "text/json" })]
    public class EducationController : Controller
    {
        private readonly AboutAPIDbContext dbContext;

        public EducationController(AboutAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<Education>> GetEducations()
        {
            return Ok(await dbContext.Education.ToListAsync());
        }

        [HttpGet]
        [Route("specify")]
        public async Task<ActionResult<Education>> GetEducation(Guid idProfile, Guid idEducation)
        {
            if (idEducation != Guid.Empty)
            {
                var education = await dbContext.Education.FindAsync(idEducation);
                if (education == null)
                {
                    return NotFound();
                }
                return Ok(education);
            }
            else
            {
                var education = await dbContext.Education.Where(b => b.IdProfile == idProfile).ToListAsync();
                if (education == null)
                {
                    return NotFound();
                }
                return Ok(education);
            }
        }

        [HttpPost]
        [Route("add/{idProfile:guid}")]
        public async Task<ActionResult<Education>> AddEducation([FromRoute] Guid idProfile, AddEducationRequest addEducationRequest)
        {
            var profile = await dbContext.Profile.Include(p => p.Education).FirstOrDefaultAsync(p => p.Id == idProfile);
            if (profile == null)
            {
                return NotFound();
            }

            var newEducation = new Education()
            {
                Id = Guid.NewGuid(),
                IdProfile = idProfile,
                InstitutionName = addEducationRequest.InstitutionName,
                EducationLevel = addEducationRequest.EducationLevel,
                StudyField = addEducationRequest.StudyField,
                StartDate = addEducationRequest.StartDate,
                EndDate = addEducationRequest.EndDate,
            };

            await dbContext.Education.AddAsync(newEducation);
            await dbContext.SaveChangesAsync();
            return Ok("Education added.");
        }

        [HttpPut]
        [Route("update/{idEducation:guid}")]
        public async Task<ActionResult<Education>> UpdateEducation([FromRoute] Guid idEducation, UpdateEducationRequest updateEducationRequest)
        {
            var education = await dbContext.Education.FindAsync(idEducation);
            if (education == null)
            {
                return NotFound();
            }

            if (updateEducationRequest.InstitutionName != null)
            {
                education.InstitutionName = updateEducationRequest.InstitutionName;
            }

            if (updateEducationRequest.EducationLevel != null)
            {
                education.EducationLevel = updateEducationRequest.EducationLevel;
            }

            if (updateEducationRequest.StudyField != null)
            {
                education.StudyField = updateEducationRequest.StudyField;
            }

            if (updateEducationRequest.StartDate != null)
            {
                education.StartDate = updateEducationRequest.StartDate;
            }

            if (updateEducationRequest.EndDate != null)
            {
                education.EndDate = updateEducationRequest.EndDate;
            }

            await dbContext.SaveChangesAsync();
            return Ok("Education updated.");
        }

        [HttpDelete]
        [Route("delete/{idEducation:guid}")]
        public async Task<ActionResult<Education>> DeleteEducation([FromRoute] Guid idEducation)
        {
            var education = await dbContext.Education.FindAsync(idEducation);
            if (education == null)
            {
                return NotFound();
            }
            dbContext.Education.Remove(education);
            await dbContext.SaveChangesAsync();
            return Ok("Education deleted.");
        }
    }
}
