using IntelAssessmentAPI.Data;
using IntelAssessmentAPI.Models.Detail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntelAssessmentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json", new string[] { "text/plain", "text/json" })]
    public class DetailController : Controller
    {
        private readonly AboutAPIDbContext dbContext;

        public DetailController(AboutAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<Detail>> GetDetails()
        {
            return Ok(await dbContext.Detail.ToListAsync());
        }

        [HttpGet]
        [Route("specify")]
        public async Task<ActionResult<Detail>> GetDetail(Guid idProfile, Guid idDetail)
        {
            if (idDetail != Guid.Empty)
            {
                var detail = await dbContext.Detail.FindAsync(idDetail);
                if (detail == null)
                {
                    return NotFound();
                }
                return Ok(detail);
            }
            else
            {
                var detail = await dbContext.Detail.Where(b => b.IdProfile == idProfile).ToListAsync();
                if (detail == null)
                {
                    return NotFound();
                }
                return Ok(detail);
            }
        }

        [HttpPost]
        [Route("add/{idProfile:guid}")]
        public async Task<ActionResult<Detail>> AddDetail([FromRoute] Guid idProfile, AddDetailRequest addDetailRequest)
        {
            var profile = await dbContext.Profile.Include(p => p.Detail).FirstOrDefaultAsync(p => p.Id == idProfile);
            if (profile == null)
            {
                return NotFound();
            }

            if (profile.Detail != null)
            {
                return Conflict("Detail already exists for this Profile!");
            }

            var newDetail = new Detail()
            {
                Id = Guid.NewGuid(),
                IdProfile = idProfile,
                FirstName = addDetailRequest.FirstName,
                LastName = addDetailRequest.LastName,
                Gender = addDetailRequest.Gender,
                DateBirth = addDetailRequest.DateBirth,
                PassportNo = addDetailRequest.PassportNo,
                Address = addDetailRequest.Address,
                PhoneNo = addDetailRequest.PhoneNo,
                Hobby = addDetailRequest.Hobby,
                Skill = addDetailRequest.Skill,
                Pet = addDetailRequest.Pet,
                FreeTimeActivity = addDetailRequest.FreeTimeActivity,
                Interest = addDetailRequest.Interest,
                FavouriteFood = addDetailRequest.FavouriteFood,
                Weight = addDetailRequest.Weight,
                Height = addDetailRequest.Height,
            };

            await dbContext.Detail.AddAsync(newDetail);
            await dbContext.SaveChangesAsync();
            return Ok("Detail added.");
        }

        [HttpPut]
        [Route("update/{idDetail:guid}")]
        public async Task<ActionResult<Detail>> UpdateDetail([FromRoute] Guid idDetail, UpdateDetailRequest updateDetailRequest)
        {
            var detail = await dbContext.Detail.FindAsync(idDetail);
            if (detail == null)
            {
                return NotFound();
            }

            if (updateDetailRequest.FirstName != null)
            {
                detail.FirstName = updateDetailRequest.FirstName;
            }

            if (updateDetailRequest.LastName != null)
            {
                detail.LastName = updateDetailRequest.LastName;
            }

            if (updateDetailRequest.Gender != null)
            {
                detail.Gender = updateDetailRequest.Gender;
            }

            if (updateDetailRequest.DateBirth != null)
            {
                detail.DateBirth = updateDetailRequest.DateBirth;
            }

            if (updateDetailRequest.PassportNo != null)
            {
                detail.PassportNo = updateDetailRequest.PassportNo;
            }

            if (updateDetailRequest.Address != null)
            {
                detail.Address = updateDetailRequest.Address;
            }

            if (updateDetailRequest.PhoneNo != null)
            {
                detail.PhoneNo = updateDetailRequest.PhoneNo;
            }

            if (updateDetailRequest.Hobby != null)
            {
                detail.Hobby = updateDetailRequest.Hobby;
            }

            if (updateDetailRequest.Skill != null)
            {
                detail.Skill = updateDetailRequest.Skill;
            }

            if (updateDetailRequest.Pet != null)
            {
                detail.Pet = updateDetailRequest.Pet;
            }

            if (updateDetailRequest.FreeTimeActivity != null)
            {
                detail.FreeTimeActivity = updateDetailRequest.FreeTimeActivity;
            }

            if (updateDetailRequest.Interest != null)
            {
                detail.Interest = updateDetailRequest.Interest;
            }

            if (updateDetailRequest.FavouriteFood != null)
            {
                detail.FavouriteFood = updateDetailRequest.FavouriteFood;
            }

            if (updateDetailRequest.Weight != null)
            {
                detail.Weight = updateDetailRequest.Weight;
            }

            if (updateDetailRequest.Height != null)
            {
                detail.Height = updateDetailRequest.Height;
            }

            await dbContext.SaveChangesAsync();
            return Ok("Detail updated.");
        }

        [HttpDelete]
        [Route("delete/{idDetail:guid}")]
        public async Task<ActionResult<Detail>> DeleteDetail([FromRoute] Guid idDetail)
        {
            var detail = await dbContext.Detail.FindAsync(idDetail);
            if (detail == null)
            {
                return NotFound();
            }
            dbContext.Detail.Remove(detail);
            await dbContext.SaveChangesAsync();
            return Ok("Detail deleted.");
        }
    }
}
