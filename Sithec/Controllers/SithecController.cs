using Microsoft.AspNetCore.Mvc;
using SithecBusiness.HumanoProcess;
using SithecBusiness.OperacionesProcess;
using SithecModels.Interface;
using SithecModels.Models;

namespace Sithec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SithecController : ControllerBase
    {
        private readonly HumanoBusiness _hb;
        private readonly OperacionesBusiness _ob;
        public SithecController(HumanoBusiness hb, OperacionesBusiness ob)
        {
            _hb = hb;
            _ob = ob;
        }
        
        [HttpGet("getHumanos")]
        public ActionResult getHumano()
        {
            return Ok(new List<IHumano>()
            {
            new Humano{Id=1, Nombre="Pablo", Edad=31, Sexo='h', Altura=1.70, Peso=85},
            new Humano{Id=2, Nombre="Pedro", Edad=23, Sexo='h', Altura=1.50, Peso=70},
            });
        }

        [HttpPost("doOperation")]
        public ActionResult doOperation(double PrimerValor, char Operador, double SegundoValor)
        {
            try
            {
                string res = _ob.realizaOperacion(PrimerValor,Operador,SegundoValor);
                return Ok(res);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("doOperationGET")]
        public ActionResult doOperationGET([FromHeader] double PrimerValor, char Operador, double SegundoValor)
        {
            try
            {
                string res = _ob.realizaOperacion(PrimerValor, Operador, SegundoValor);
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("listHumanos")]
        public ActionResult listaHumanos()
        {
            try
            {
                var lh = _hb.consultaHumanos();
                if (lh is null || lh == null) return NoContent();
                return Ok(lh);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getHumanoById/{Id}")]
        public ActionResult getHumanoById(int Id)
        {
            try
            {
                var h = _hb.buscaHumano(Id);
                if (h != null) return Ok(h);
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("addHumano")]
        public ActionResult agregarHumano([FromBody] Humano humano)
        {
            try
            {
                _hb.agregarHumano(humano);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(humano);
        }

        [HttpPut("updateHumano")]
        public ActionResult modificarHumano([FromBody] Humano humano)
        {
            try
            {
                _hb.modificarHumano(humano);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(humano);
        }
    }
}
