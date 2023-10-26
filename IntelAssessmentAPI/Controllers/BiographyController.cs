using IntelAssessmentAPI.Data;
using IntelAssessmentAPI.Models.Biography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntelAssessmentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json", new string[] { "text/plain", "text/json" })]
    public class BiographyController : Controller
    {
        private readonly AboutAPIDbContext dbContext;
        public BiographyController(AboutAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<Biography>> GetBiographies()
        {
            return Ok(await dbContext.Biography.ToListAsync());
        }

        [HttpGet]
        [Route("specify")]
        public async Task<ActionResult<Biography>> GetBiography(Guid idProfile, Guid idBiography)
        {
            if (idBiography != Guid.Empty)
            {
                var biography = await dbContext.Biography.FindAsync(idBiography);
                if (biography == null)
                {
                    return NotFound();
                }
                return Ok(biography);
            }
            else
            {
                var biography = await dbContext.Biography.Where(b => b.IdProfile == idProfile).ToListAsync();
                if (biography == null)
                {
                    return NotFound();
                }
                return Ok(biography);
            }
        }


        [HttpPost]
        [Route("add/{idProfile:guid}")]
        public async Task<ActionResult<Biography>> AddBiography([FromRoute] Guid idProfile,  AddBiographyRequest addBiographyRequest)
        {
            var profile = await dbContext.Profile.Include(p => p.Biography).FirstOrDefaultAsync(p => p.Id == idProfile);
            if (profile == null)
            {
                return NotFound();
            }

            var newBiography = new Biography()
            {
                Id = Guid.NewGuid(),
                IdProfile = idProfile,
                Summary1 = addBiographyRequest.Summary1,
                Summary2 = addBiographyRequest.Summary2,
                Summary3 = addBiographyRequest.Summary3,
            };

            await dbContext.Biography.AddAsync(newBiography);
            await dbContext.SaveChangesAsync();
            return Ok("Biography added.");
        }

        [HttpPut]
        [Route("update/{idBiography:guid}")]
        public async Task<ActionResult<Biography>> UpdateBiography([FromRoute] Guid idBiography, UpdateBiographyRequest updateBiographyRequest )
        {
            var biography = await dbContext.Biography.FindAsync(idBiography);
            if (biography == null)
            {
                return NotFound();
            }

            if (updateBiographyRequest.Summary1 != null)
            {
                biography.Summary1 = updateBiographyRequest.Summary1;
            }

            if (updateBiographyRequest.Summary2 != null)
            {
                biography.Summary2 = updateBiographyRequest.Summary2;
            }

            if (updateBiographyRequest.Summary3 != null)
            {
                biography.Summary3 = updateBiographyRequest.Summary3;
            }

            await dbContext.SaveChangesAsync();
            return Ok("Biography updated.");
        }

        [HttpDelete]
        [Route("delete/{idBiography:guid}")]
        public async Task<ActionResult<Biography>> DeleteBiography([FromRoute] Guid idBiography)
        {
            var biography = await dbContext.Biography.FindAsync(idBiography);
            if (biography == null)
            {
                return NotFound();
            }
            dbContext.Biography.Remove(biography);
            await dbContext.SaveChangesAsync();
            return Ok("Biography deleted.");
        }
    }
}
