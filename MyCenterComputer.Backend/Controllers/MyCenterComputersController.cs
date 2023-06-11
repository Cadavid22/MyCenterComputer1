using CenterComputer.Backend.Data;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Http;

namespace CenterComputer.Backend.Controllers
{
    public class MyCenterComputerController : Controller
    {
        [Route("api/[controller]")]
        [ApiController]
        public class MyCenterComputersController : ControllerBase
        {
            private readonly DataContext _context;

            public MyCenterComputersController(DataContext context)
            {
                _context = context;
            }

            [HttpGet]
            public IActionResult Get()
            {
                return Ok(_context.CenterComputers.ToList());
            }

            [HttpGet("{id:int}")]
            public IActionResult Get(int id)
            {
                var computer = _context.CenterComputers.FirstOrDefault(x => x.Id == id);
                if (computer == null)
                {
                    return NotFound();
                }
                return Ok(computer);
            }


            [HttpPost]
            public IActionResult Post(Controllers.MyCenterComputerController computer)
            {
                _context.Add(computer);
                _context.SaveChanges();
                return Ok(computer);
            }



            [HttpPut]
            public IActionResult Put(Controllers.MyCenterComputerController computer)
            {
                var Mycomputer = _context.CenterComputers.FirstOrDefault(x => x.Id== computer.Id);
                if (computer == null)
                {
                    return NotFound();
                }
                Mycomputer.Type = Mycomputer.Type;
                Mycomputer.Brand = Mycomputer.Brand;
                Mycomputer.Name = Mycomputer.Name;
                Mycomputer.LastName = Mycomputer.LastName;
                Mycomputer.Phone = Mycomputer.Phone;
                Mycomputer.Email = Mycomputer.Email;
                Mycomputer.Diagnosis = Mycomputer.Diagnosis;
                Mycomputer.Coments = Mycomputer.Coments;
                Mycomputer.Status = Mycomputer.Status;
                Mycomputer.Value = Mycomputer.Value;
                Mycomputer.DateStarted = Mycomputer.DateStarted;
                Mycomputer.DateFinished = Mycomputer.DateFinished;

                _context.Update(computer);
                _context.SaveChanges();
                return Ok(computer);
            }

            [HttpDelete("{id:int}")]
            public IActionResult Delete(int Id)
            {
                var Mycomputer = _context.CenterComputers.FirstOrDefault(x => x.Id == Id);
                if (Mycomputer == null)
                {
                    return NotFound();
                }
                _context.Remove(Mycomputer);
                _context.SaveChanges();
                return NoContent();
            }
        }
    }

   
}
