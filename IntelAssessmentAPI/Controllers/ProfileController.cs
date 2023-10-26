using IntelAssessmentAPI.Data;
using IntelAssessmentAPI.Models.Profile;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntelAssessmentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json", new string[] { "text/plain", "text/json" })]
    public class ProfileController : Controller
    {
        private readonly AboutAPIDbContext dbContext;

        public ProfileController(AboutAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<Profile>> GetProfiles()

        {
            return Ok(await dbContext.Profile.ToListAsync());
        }

        [HttpGet]
        [Route("specify")]
        public async Task<ActionResult<Profile>> GetProfile(Guid idProfile)
        {
            var profile = await dbContext.Profile.FindAsync(idProfile);
            if (profile == null)
            {
                return NotFound();
            }

            return Ok(profile);
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<Profile>> AddProfile(AddProfileRequest addProfileRequest)
        {
            var userExist = await dbContext.Profile.FirstOrDefaultAsync(x => x.Email == addProfileRequest.Email);
            if (userExist != null)
            {
                return Conflict("Email already in use!");
            }

            var newProfile = new Profile()
            {
                Id = Guid.NewGuid(),
                FullName = addProfileRequest.FullName,
                NickName = addProfileRequest.NickName,
                Email = addProfileRequest.Email,
                ProfilePhoto = addProfileRequest.ProfilePhoto,
                CreatedAt = DateTime.UtcNow,
            };

            await dbContext.Profile.AddAsync(newProfile);
            await dbContext.SaveChangesAsync();
            return Ok("Profile added.");
        }

        [HttpPut]
        [Route("update/{idProfile:guid}")]
        public async Task<ActionResult<Profile>> UpdateProfile([FromRoute] Guid idProfile, UpdateProfileRequest updateProfileRequest)
        {
            var profile = await dbContext.Profile.FindAsync(idProfile);
            if (profile == null)
            {
                return NotFound();
            }

            if (updateProfileRequest.Email != null && updateProfileRequest.Email != profile.Email)
            {
                var userExist = await dbContext.Profile.FirstOrDefaultAsync(x => x.Email == updateProfileRequest.Email);
                if (userExist != null)
                {
                    return Conflict("Email already in use!");
                }
                profile.Email = updateProfileRequest.Email;
            }

            if (updateProfileRequest.FullName != null)
            {
                profile.FullName = updateProfileRequest.FullName;
            }

            if (updateProfileRequest.NickName != null)
            {
                profile.NickName = updateProfileRequest.NickName;
            }

            if (updateProfileRequest.ProfilePhoto != null)
            {
                profile.ProfilePhoto = updateProfileRequest.ProfilePhoto;
            }

            await dbContext.SaveChangesAsync();
            return Ok("Profile updated.");
        }

        [HttpDelete]
        [Route("delete/{idProfile:guid}")]
        public async Task<ActionResult<Profile>> DeleteProfile([FromRoute] Guid idProfile)
        {
            var profile = await dbContext.Profile
                .Include(p => p.Detail)
                .Include(p => p.JobHistory)
                .Include(p => p.Education)
                .Include(p => p.Biography)
                .Include(p => p.SocMed)
                .Include(p => p.Image)
                .FirstOrDefaultAsync(p => p.Id == idProfile);
            if (profile == null)
            {
                return NotFound();
            }
            dbContext.Profile.Remove(profile);
            await dbContext.SaveChangesAsync();
            return Ok("Profile deleted.");
        }
    }
}
