using IntelAssessmentAPI.Data;
using IntelAssessmentAPI.Models.Image;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntelAssessmentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json", new string[] { "text/plain", "text/json" })]
    public class ImageController : Controller
    {
        private readonly AboutAPIDbContext dbContext;
        public ImageController(AboutAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<Image>> GetImages()
        {
            return Ok(await dbContext.Image.ToListAsync());
        }

        [HttpGet]
        [Route("specify")]
        public async Task<ActionResult<Image>> GetImage(Guid idProfile, Guid idImage)
        {
            if (idImage != Guid.Empty)
            {
                var image = await dbContext.Image.FindAsync(idImage);
                if (image == null)
                {
                    return NotFound();
                }
                return Ok(image);
            }
            else
            {
                var image = await dbContext.Image.Where(b => b.IdProfile == idProfile).ToListAsync();
                if (image == null)
                {
                    return NotFound();
                }
                return Ok(image);
            }
        }

        [HttpPost]
        [Route("add/{idProfile:guid}")]
        public async Task<ActionResult<Image>> AddImage([FromRoute] Guid idProfile, AddImageRequest addImageRequest)
        {
            var profile = await dbContext.Profile.Include(p => p.Image).FirstOrDefaultAsync(p => p.Id == idProfile);
            if (profile == null)
            {
                return NotFound();
            }

            var newImage = new Image()
            {
                Id = Guid.NewGuid(),
                IdProfile = idProfile,
                ImagePath = addImageRequest.ImagePath,
                Description = addImageRequest.Description,
            };

            await dbContext.Image.AddAsync(newImage);
            await dbContext.SaveChangesAsync();
            return Ok("Image added.");
        }

        [HttpPut]
        [Route("update/{idImage:guid}")]
        public async Task<ActionResult<Image>> UpdateImage([FromRoute] Guid idImage, UpdateImageRequest updateImageRequest )
        {
            var image = await dbContext.Image.FindAsync(idImage);
            if (image == null)
            {
                return NotFound();
            }

            if (updateImageRequest.ImagePath != null)
            {
                image.ImagePath = updateImageRequest.ImagePath;
            }

            if (updateImageRequest.Description != null)
            {
                image.Description = updateImageRequest.Description;
            }

            await dbContext.SaveChangesAsync();
            return Ok("Image updated.");
        }

        [HttpDelete]
        [Route("delete/{idImage:guid}")]
        public async Task<ActionResult<Image>> DeleteImage([FromRoute] Guid idImage)
        {
            var image = await dbContext.Image.FindAsync(idImage);
            if (image == null)
            {
                return NotFound();
            }
            dbContext.Image.Remove(image);
            await dbContext.SaveChangesAsync();
            return Ok("Image deleted.");
        }
    }
}
