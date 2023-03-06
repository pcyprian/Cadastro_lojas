using Microsoft.AspNetCore.Mvc;
using cadastro_lojas_fullstack.Domain;
using cadastro_lojas_fullstack.Models;
using FluentValidation;

namespace cadastro_lojas_fullstack.Controllers
{
    public class MedidaController : ControllerBase
    {
        private readonly MedidaServices medidaServices;
        private readonly IValidator<Medida> _validator;

        public MedidaController(IValidator<Medida> validator)
        {
            medidaServices = new MedidaServices();
            _validator = validator;
        }

        [HttpGet("Medida/GetAll")]
        public IEnumerable<Medida> GetAll()
        {
            var medidaDomain = new MedidaServices();
            return medidaDomain.GetAllMedida();
        }

     /*   [HttpGet("Medida/Id-projeto/{Id}")]
        public ActionResult GetIdMedida(Guid id)
        {
           var medidaDomain = new MedidaServices();
           var medida = medidaDomain.GetIdMedidaByIdProjeto(id);

            if (medida == null)
            {
                return NotFound($"Medida não encontrado com o Id ={id} informado");
            }
            return Ok(medida);
        }*/

        [HttpGet("Medida/Id-medida/{id}")]
        public ActionResult GetId(Guid id)
        {
            var medidaDomain = new MedidaServices();
            var medida = medidaDomain.GetMedidaId(id);

            if (medida == null)
            {
                return NotFound($"Medida não encontrado com o Id ={id} informado");
            }

            return Ok(medida);
        }


        [HttpPost("Medida/Create")]
        public ActionResult CreateMedida([FromBody] Medida medida)
        {
            var validacao = _validator.Validate(medida);
            if (!validacao.IsValid)
            {
                return BadRequest(validacao.ToDictionary());
            }
            var medidaServices = new MedidaServices();
            bool resposta = medidaServices.InsertMedida(medida);
            if (!resposta)
            {
                return BadRequest("Medidas não criadas");
            }
            return Created("Medidas criadas.", medida);
        }

        [HttpPut("Medida/Update/{id}")]
        public ActionResult UpdateMedida([FromBody] Medida medida, Guid id)
        {
            var validacao = _validator.Validate(medida);
            if (!validacao.IsValid)
            {
                return BadRequest(validacao.ToDictionary());
            }
            var medidaServices = new MedidaServices();
            medidaServices.UpdateMedida(medida, id);
            return Ok(medida);
        }

        [HttpDelete("Medidas/Delete/{id}")]
        public ActionResult DeleteMedida(Guid id)
        {
            var medidaServices = new MedidaServices();
            medidaServices.DeleteMedida(id);
            return Ok("Removido com sucesso");

        }

    }


}

