using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebAPISecondLook.DTO;
using WebAPISecondLook.IdentityFolder;

namespace WebAPISecondLook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configuration;

        public AccountController(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }

        //Register 
        //DTO 

        //Login
        //check user 
        //check password 
        //create token

        //localhost:5013/api/Account/Register   

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterDTO userDTO)
        {
            //check if model state not valid 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //check if user exists before or not 

            var userExistsBefore = await userManager.FindByNameAsync(userDTO.Name);

            if (userExistsBefore is not null)
            {
                return BadRequest("user already exits ");
            }


            //create user
            ApplicationUser user = new ApplicationUser();
            user.UserName = userDTO.Name;
            user.Email = userDTO.Email;

            var registerResult = await userManager.CreateAsync(user, userDTO.Password);

            if (!registerResult.Succeeded)
            {
                return BadRequest(registerResult.Errors.FirstOrDefault().Description);
            }


            return Ok("Account Created Succeffuly");
        }



        //localhost:5013/api/Account/Login

        //check if name exists or not 
        //password correct 
        //create token 

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDTO userDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userExists = await userManager.FindByNameAsync(userDTO.Name);
            if (userExists is not null)
            {
                var validUser = await userManager.CheckPasswordAsync(userExists, userDTO.Password);


                if (validUser)
                {
                    //create Token 

                    //create list<Claims>

                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, userExists.UserName));
                    claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                    var userRoles = await userManager.GetRolesAsync(userExists);


                    SecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

                    SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    foreach (var roleItem in userRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, roleItem));
                    }


                    JwtSecurityToken token =
                        new JwtSecurityToken(issuer: configuration["JWT:ValidIssuer"],
                        audience: configuration["JWT:ValidAudience"],
                        claims: claims,
                        expires: DateTime.Now.AddHours(1),
                        signingCredentials: signingCredentials
                        );


                    return Ok(
                             new
                             {
                                 token = new JwtSecurityTokenHandler().WriteToken(token),
                                 expiration = token.ValidTo
                             });
                }

            }
            return Unauthorized();
        }


    }
}
