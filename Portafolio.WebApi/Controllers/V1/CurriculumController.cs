using Microsoft.AspNetCore.Mvc;
using Portafolio.Application.Services;

namespace Portafolio.WebApi.Controllers.V1
{
    /// <summary>
    /// Controlador que expone la información del currículum de un perfil.
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CurriculumController : ControllerBase
    {
        private readonly ICurriculumService _curriculumService;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="CurriculumController"/>.
        /// </summary>
        /// <param name="curriculumService">Servicio encargado de obtener el currículum.</param>
        public CurriculumController(ICurriculumService curriculumService)
        {
            _curriculumService = curriculumService;
        }

        /// <summary>
        /// Obtiene la información completa del currículum asociado al perfil especificado.
        /// </summary>
        /// <param name="id">Identificador único del perfil.</param>
        /// <returns>
        /// Retorna el currículum completo del perfil, incluyendo información personal,
        /// experiencia, educación, habilidades, idiomas y demás secciones asociadas.
        /// </returns>
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
