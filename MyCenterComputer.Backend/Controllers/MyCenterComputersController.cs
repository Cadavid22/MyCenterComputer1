using CenterComputer.Backend.Data;
using Microsoft.AspNetCore.Mvc;
using MyCenterComputer.shared.Entities;
using Microsoft.AspNetCore.Http;

namespace MyCenterComputer.Backend.Controllers
{
    public class MyCenterComputersController : Controller
    {
        [Route("api/[controller]")]
        [ApiController]
        public class MyCenterComputerController : ControllerBase
        {
            private readonly DataContext _context;

            public MyCenterComputerController(DataContext context)
            {
                _context = context;
            }

            [HttpGet]
            public IActionResult Get()
            {
                return Ok(_context.MyCenterComputers.ToList());
            }

            [HttpGet("{id:int}")]
            public IActionResult Get(int id)
            {
                var computer = _context.MyCenterComputers.FirstOrDefault(x => x.Id == id);
                if (computer == null)
                {
                    return NotFound();
                }
                return Ok(computer);
            }


            [HttpPost]
            public IActionResult Post(Controllers.MyCenterComputersController computer)
            {
                _context.Add(computer);
                _context.SaveChanges();
                return Ok(computer);
            }



            [HttpPut]
            public IActionResult Put(Controllers.MyCenterComputersController computer)
            {
                var Mycomputer = _context.MyCenterComputers.FirstOrDefault(x => x.Id == computer.Id);
                if (computer == null)
                {
                    return NotFound();
                }
                computer.Type = Mycomputer.Type;
                computer.Brand = Mycomputer.Brand;
                computer.Name = Mycomputer.Name;
                computer.LastName = Mycomputer.LastName;
                computer.Phone = Mycomputer.Phone;
                computer.Email = Mycomputer.Email;
                computer.Diagnosis = Mycomputer.Diagnosis;
                computer.Coments = Mycomputer.Coments;
                computer.Status = Mycomputer.Status;
                computer.Value = Mycomputer.Value;
                computer.DateStarted = Mycomputer.DateStarted;
                computer.DateFinished = Mycomputer.DateFinished;

                _context.Update(computer);
                _context.SaveChanges();
                return Ok(computer);
            }

            [HttpDelete("{id:int}")]
            public IActionResult Delete(int Id)
            {
                var Mycomputer = _context.MyCenterComputers.FirstOrDefault(x => x.Id == Id);
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
