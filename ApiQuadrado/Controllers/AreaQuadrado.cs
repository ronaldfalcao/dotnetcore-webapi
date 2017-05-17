using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quadrado;

namespace ApiQuadrado.Controllers
{
    [Route("api/[controller]")]
    public class AreaQuadradoExemplo : Controller
    {
        [HttpGet("Lado/{lado}")]
        public object Get(double lado)
        {
            return new
                   {
                       Lado = lado,
                       //Não sei porque precisou de mais um Quadrado :-(
                       area = Quadrado.Quadrado.Area(lado)
                   };
        }
    }
}