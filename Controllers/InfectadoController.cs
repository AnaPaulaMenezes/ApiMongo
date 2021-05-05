using ApiMongo.Data.Collections;
using ApiMongo.Models;
using MongoDB.Bson;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;


namespace ApiMongo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfectadoController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Infectado> _infectadosCollection;

        public InfectadoController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _infectadosCollection = _mongoDB.DB.GetCollection<Infectado>(typeof(Infectado).Name.ToLower());
        }


        /// <summary>
        ///  Adicionar um infectado
        /// </summary>
        /// <param name="InfectadoDto"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SalvarInfectado([FromBody] InfectadoDto dto)
        {
            var infectado = new Infectado(dto.DataNascimento, dto.Sexo, dto.Latitude, dto.Longitude, null);

            _infectadosCollection.InsertOne(infectado);

            return StatusCode(201, "Infectado adicionado com sucesso");
        }

        /// <summary>
        ///  Listar infectados
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ObterInfectados()
        {

            var infectados = _infectadosCollection.Find(Builders<Infectado>.Filter.Empty).ToList();

            return Ok(infectados);
        }

        /// <summary>
        ///  Atualizar infectado
        /// </summary>
        /// <param name="string"></param>
        /// <param name="InfectadoDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult AtualizarInfectado(string id, [FromBody] InfectadoDto dto)
        {
            var id_Infectado = new ObjectId(id);
            var infectado = new Infectado(dto.DataNascimento, dto.Sexo, dto.Latitude, dto.Longitude, id_Infectado);
            var filtro = Builders<Infectado>.Filter.Where(_ => _._id == id_Infectado);

            _infectadosCollection.ReplaceOne(filtro, infectado);

            return Ok("Atualizado com sucesso");
        }

        /// <summary>
        ///  Deletar infectado
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult AtualizarInfectado(string id)
        {
            var id_Infectado = new ObjectId(id);
            var filtro = Builders<Infectado>.Filter.Where(_ => _._id == id_Infectado);

            _infectadosCollection.DeleteOne(filtro);

            return Ok("Deletado com sucesso");
        }

        /// <summary>
        ///  Marcar infectado como curado
        /// </summary>
        /// <param name="string"></param>
        /// <param name="bool"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public ActionResult MarcarCurado(string id, [FromQuery] bool curado)
        {
            var id_Infectado = new ObjectId(id);
            var filtro = Builders<Infectado>.Filter.Where(_ => _._id == id_Infectado);
            var update = Builders<Infectado>.Update.Set("curado", curado);

            _infectadosCollection.UpdateOne(filtro, update);

            return Ok("Atualizado com sucesso");
        }

    }
}