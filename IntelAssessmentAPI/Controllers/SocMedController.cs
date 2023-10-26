using IntelAssessmentAPI.Data;
using IntelAssessmentAPI.Models.SocMed;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntelAssessmentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json", new string[] { "text/plain", "text/json" })]
    public class SocMedController : Controller
    {
        private readonly AboutAPIDbContext dbContext;
        public SocMedController(AboutAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<SocMed>> GetSocMeds()
        {
            return Ok(await dbContext.SocMed.ToListAsync());
        }

        [HttpGet]
        [Route("specify")]
        public async Task<ActionResult<SocMed>> GetSocMed(Guid idProfile, Guid idSocMed)
        {
            if (idSocMed != Guid.Empty)
            {
                var socMed = await dbContext.SocMed.FindAsync(idSocMed);
                if (socMed == null)
                {
                    return NotFound();
                }
                return Ok(socMed);
            }
            else
            {
                var socMed = await dbContext.SocMed.Where(b => b.IdProfile == idProfile).ToListAsync();
                if (socMed == null)
                {
                    return NotFound();
                }
                return Ok(socMed);
            }
        }

        [HttpPost]
        [Route("add/{idProfile:guid}")]
        public async Task<ActionResult<SocMed>> AddSocMed([FromRoute] Guid idProfile, AddSocMedRequest addSocMedRequest )
        {
            var profile = await dbContext.Profile.Include(p => p.SocMed).FirstOrDefaultAsync(p => p.Id == idProfile);
            if (profile == null)
            {
                return NotFound();
            }

            var newSocMed = new SocMed()
            {
                Id = Guid.NewGuid(),
                IdProfile = idProfile,
                NameOfMedia = addSocMedRequest.NameOfMedia,
                UserName = addSocMedRequest.UserName,
            };

            await dbContext.SocMed.AddAsync(newSocMed);
            await dbContext.SaveChangesAsync();
            return Ok("Social media added.");
        }

        [HttpPut]
        [Route("update/{idSocMed:guid}")]
        public async Task<ActionResult<SocMed>> UpdateSocMed([FromRoute] Guid idSocMed, UpdateSocMedRequest updateSocMedRequest)
        {
            var socMed = await dbContext.SocMed.FindAsync(idSocMed);
            if (socMed == null)
            {
                return NotFound();
            }

            if (updateSocMedRequest.NameOfMedia != null)
            {
                socMed.NameOfMedia = updateSocMedRequest.NameOfMedia;
            }

            if (updateSocMedRequest.UserName != null)
            {
                socMed.UserName = updateSocMedRequest.UserName;
            }

            await dbContext.SaveChangesAsync();
            return Ok("Social media updated.");
        }

        [HttpDelete]
        [Route("delete/{idSocMed:guid}")]
        public async Task<ActionResult<SocMed>> DeleteSocMed([FromRoute] Guid idSocMed)
        {
            var socMed = await dbContext.SocMed.FindAsync(idSocMed);
            if (socMed == null)
            {
                return NotFound();
            }
            dbContext.SocMed.Remove(socMed);
            await dbContext.SaveChangesAsync();
            return Ok("Social media deleted.");
        }
    }
}
