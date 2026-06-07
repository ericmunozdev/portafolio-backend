using Microsoft.AspNetCore.Mvc;
using Portafolio.Application.Services;

namespace Portafolio.WebApi.Controllers.V1
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/v1/[controller]")]
    public class CurriculumController : ControllerBase
    {
        private readonly ICurriculumService _curriculumService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="curriculumService"></param>
        public CurriculumController(ICurriculumService curriculumService)
        {
            _curriculumService = curriculumService;
        }

        /// <summary>
        /// Obtiene curriculum vitae mediante el identificador
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var curriculum = await _curriculumService.GetByIdAsync(id);

            if (curriculum is null)
                return NotFound();

            return Ok(curriculum);
        }
    }
}
