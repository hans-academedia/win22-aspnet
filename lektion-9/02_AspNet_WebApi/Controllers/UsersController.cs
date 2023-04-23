using _02_AspNet_WebApi.Helpers.Services;
using _02_AspNet_WebApi.Models.Dtos;
using _02_AspNet_WebApi.Models.Entities;
using _02_AspNet_WebApi.Models.Schemas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _02_AspNet_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _userService.GetAllAsync());
        }


        [HttpGet("User")]
        public async Task<IActionResult> GetUser([FromQuery] string? id, [FromQuery] string? email)
        {
            User user = null!;

            if (!string.IsNullOrEmpty(id))
                user = await _userService.GetAsync(x => x.Id == id);

            else if (!string.IsNullOrEmpty(email))
                user = await _userService.GetAsync(x => x.Email == email);

            if (user != null)
                return Ok(user);

            return NotFound();
        }




        [HttpPost]
        public async Task<IActionResult> CreateUser(UserRegisterSchema userRegisterSchema)
        {
            if (ModelState.IsValid)
            {
                if (await _userService.UserExistsAsync(x => x.Email == userRegisterSchema.Email))
                    return Conflict("User with the same email address already exists");

                if (await _userService.RegisterAsync(userRegisterSchema)) 
                {
                    var user = await _userService.GetAsync(x => x.Email == userRegisterSchema.Email);
                    return Created($"https://domain.com/api/users/{user.Id}", user);
                }
                    

                ModelState.AddModelError("", "Something went wrong. Please contact support.");
            }

            return BadRequest(userRegisterSchema);
        }




    }
}



/*
    body        innbär att i skickar data genom body request oftast i form av json.
    query       innebär att vi skickar med en parameter uppe i urlen:
                https://domain.com/api/products/ASA-500
                https://domain.com/api/products?articleNumber=ASA-500

                  CRUD       HTTP METHOD    ANVÄNDS NÄR                                             SKICKAR DATA VIA...
    ------------------------------------------------------------------------------------------------------------------
    [HttpPost]    CREATE     POST           vi ska skicka känslig information                       body
    [HttpGet]     READ       GET            vi vill hämta information eller skicka till sökmotor    query
    [HttpPut]     UPDATE     PUT            vi ska ersätta ett objekt                               query & body
    [HttpPatch]   UPDATE     PATCH          vi ska uppdatera ett fält i ett objekt (ovanlig)        query & body
    [HttpDelete]  DELETE     DELETE         vi vill ta bort ett objekt                              query eller body



    STATUS CODES
    ------------------------------------------------------------------------------------------------------------------
    SUCCESS *
->  200         OK                              Allt har gått som det skulle här har du information
    201         CREATED                         Skapanded av ett objekt har lyckats här är information
    204         NO CONTENT                      allt har gått bra, du får ingen inforamtion tillbaka

    REDIRECT       
    301         MOVED PERMANENTLY               sidan har flyttats permanent -> BYTE AV DOMÄMNAMN
    302         MOVED TEMPORARILY               sidan har flyttats temporärt -> BYTE PGA UPPDATERING AV SERVRAR
    303         REDIRECT                        vanlig redirect

    CLIENT ERROR *
->  400         BAD REQUEST                     DU KAN ANGIVIT FELAKTIG INFORMATION 
->  401         UNAUTHORIZED                    DU HAR INTE LOGGAT IN, ELLER INTE LOGGAD IN MED RÄTT UPPGIFTER
->  403         FORBIDDEN                       DU ÄR INLOGGAD MEN SAKNAR RÄTT BEHÖRIGHET FÖR ATT KOMMA ÅT SIDAN
->  404         NOT FOUND                       SAKEN DU SÖKER KAN INTE HITTAS (404-PAGE NOT FOUND)
    405         METHOD NOT ALLOWED              DU FÖRSÖKER ANVÄNDA EN HTTP METHOD SOM INTE TILLÅTS (POST,GET,PUT,PATCH,DELETE)
    409         CONFLICT                        DET FINNS REDAN ETT OBJEKT MED SAMMA INFORMATION

    SERVER ERROR *
->  500         INTERNAL SERVER ERROR           ALLMÄNT FEL PÅ SERVERN SÅSOM INGEN CONNECTIONSTRING ETC.
    501         NOT IMPLEMENTED                 DET FINNS INGEN FUNKTION SOM SVARAR PÅ DIN FÖRFRÅGAN
    502         BAD GATEWAY                     BRANDVÄGGEN/GATEWAY/SWITCHEN ÄR INTE TILLGÄNGLIG UTAN LIGGER NERE
->  503         SERVICE UNAVAILABLE             SYSTEMET UPDATERAS/SERVERN STARTAR OM

*/