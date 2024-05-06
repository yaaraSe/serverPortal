using Microsoft.AspNetCore.Mvc;
using Repository;

namespace serverPortal.Controllers
{
    public class GenericController : ControllerBase
    {
        public readonly MongoRepository repository;


        public GenericController(MongoRepository mongoRepository)
        {
            repository = mongoRepository;
        }



    }
}
