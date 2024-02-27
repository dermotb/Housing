using Housing.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Housing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        static List<Property> houses = new List<Property>()
        {
            new Property(){ID=0, Address="12 The Crescent", FullyDelegated=true, BedroomCount=4, ClientEmail="jim@jimsbiz.ie", LeaseExpiry=new DateTime(2024, 6, 30)},
            new Property(){ID=1, Address="The Towers", FullyDelegated=true, BedroomCount=5, ClientEmail="mick@micksbiz.ie", LeaseExpiry=new DateTime(2024, 3, 17)},
            new Property(){ID=2, Address="15b Crolly St", FullyDelegated=false, BedroomCount=2, ClientEmail="sheila@sheilaprop.ie", LeaseExpiry=new DateTime(2026, 9, 1)},
            new Property(){ID=3, Address="122 Happy Road", FullyDelegated=true, BedroomCount=3, ClientEmail="mary@realtyinc.ie", LeaseExpiry=new DateTime(2025, 1, 30)}
        };

        // GET: api/<HouseController>
        [HttpGet]
        public IEnumerable<Property> Get()
        {
            return houses;
        }

        // GET api/<HouseController>/5
        [HttpGet("{id}")]
        public Property Get(int id)
        {
            Property found = houses.FirstOrDefault(p => p.ID == id);
            return found;
        }

        [HttpGet]
        [Route("AllEmails")]
        public IEnumerable<string> GetAllEmails()
        {
            return houses.Select(p=>p.ClientEmail).ToList();
        }

        // POST api/<HouseController>
        [HttpPost]
        public void Post([FromBody] Property value)
        {
            if (ModelState.IsValid) 
            {
                Property found = houses.FirstOrDefault(p=>p.ID==value.ID);
                if (found==null)
                {
                    houses.Add(value);
                }
            }
        }

        // PUT api/<HouseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Property value)
        {
            if (ModelState.IsValid)
            {
                Property found = houses.FirstOrDefault(p => p.ID == value.ID);
                if (found != null)
                {
                    found.BedroomCount = value.BedroomCount;
                }
            }
        }

    }
}
