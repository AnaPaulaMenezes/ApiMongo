using System;
using MongoDB.Bson;
using MongoDB.Driver.GeoJsonObjectModel;

namespace ApiMongo.Data.Collections
{
    public class Infectado
    {
        public Infectado(DateTime dataNascimento, string sexo, double latitude, double longitude, Nullable<ObjectId> id)
        {

            this._id = (id is null) ? new ObjectId() : (ObjectId)id;
            this.DataNascimento = dataNascimento;
            this.Sexo = sexo;
            this.Localizacao = new GeoJson2DGeographicCoordinates(longitude, latitude);
            this.Curado = false;
        }
        public ObjectId _id { get; private set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public GeoJson2DGeographicCoordinates Localizacao { get; set; }
        public bool Curado { get; set; }



    }
}