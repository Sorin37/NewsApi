using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using NewsApi.Model;
using NewsApi.Services;

namespace NewsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnnouncementController : Controller
    {
        IAnnouncementCollectionService _announcementCollectionService;

        public AnnouncementController(IAnnouncementCollectionService announcementCollectionService)
        {
            _announcementCollectionService = announcementCollectionService;
        }

        /// <summary>
        /// Returns a list of announcements
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _announcementCollectionService.GetAll());
        }

        /// <summary>
        /// Add an announcement
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AnnouncementEntity announcementEntity)
        {
            if (String.IsNullOrWhiteSpace(announcementEntity.Title) ||
                String.IsNullOrWhiteSpace(announcementEntity.Message) ||
                String.IsNullOrWhiteSpace(announcementEntity.Author) ||
                String.IsNullOrWhiteSpace(announcementEntity.Category))
            {
                return BadRequest("Announcement's id cannot be 0");
            }
            Announcement announcement = announcementEntity.EntityToModel();

            await _announcementCollectionService.Create(announcement);

            return Ok(await _announcementCollectionService.GetAll());
        }

        /// <summary>
        /// Updates an announcement
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Announcement announcement)
        {
            if (String.IsNullOrWhiteSpace(announcement.Title) ||
                String.IsNullOrWhiteSpace(announcement.Message) ||
                String.IsNullOrWhiteSpace(announcement.Author) ||
                String.IsNullOrWhiteSpace(announcement.Category))
            {
                return BadRequest("Announcement cannot be null");
            }

            if(!await _announcementCollectionService.Update(announcement.Id, announcement))
            {
                return NotFound();
            }

            return Ok(await _announcementCollectionService.GetAll());
        }

        /// <summary>
        /// Updates the Title and the Description for an announcement
        /// </summary>
        /// <returns></returns>
        [HttpPatch]
        public IActionResult Patch([FromRoute] Guid id, string title, string description)
        {
            return Ok(title + description);
        }

        /// <summary>
        /// Deletes an announcement
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (await _announcementCollectionService.Delete(id))
            {
                return NotFound();
            }

            return Ok(await _announcementCollectionService.GetAll());
        }
    }
}
