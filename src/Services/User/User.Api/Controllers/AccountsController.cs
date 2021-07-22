using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using User.Api.DTO;
using User.Api.JwtFeatures;
using User.Api.Models;

namespace CompanyEmployees.Controllers
{
    [Route("api/accounts")]
	[ApiController]
	public class AccountsController : ControllerBase
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IMapper _mapper;
		private readonly JwtHandler _jwtHandler;
		//private readonly IEmailSender _emailSender;

		public AccountsController(UserManager<ApplicationUser> userManager, IMapper mapper, JwtHandler jwtHandler)
		{
			_userManager = userManager;
			_mapper = mapper;
			_jwtHandler = jwtHandler;
		}

		[HttpPost("Registration")]
		public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
		{
			if (userForRegistration == null || !ModelState.IsValid)
				return BadRequest();

			var user = _mapper.Map<ApplicationUser>(userForRegistration);
			user.UserRole = "User";
			var result = await _userManager.CreateAsync(user, userForRegistration.Password);
			if (!result.Succeeded)
			{
				var errors = result.Errors.Select(e => e.Description);

				return BadRequest(new RegistrationResponseDto { Errors = errors });
			}

			//var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
			//var param = new Dictionary<string, string>
			//{
			//	{"token", token },
			//	{"email", user.Email }
			//};

			//var callback = QueryHelpers.AddQueryString(userForRegistration.ClientURI, param);

			//var message = new Message(new string[] { "codemazetest@gmail.com" }, "Email Confirmation token", callback, null);
			//await _emailSender.SendEmailAsync(message);

			await _userManager.AddToRoleAsync(user, "User");

			return StatusCode(201);
		}

		[HttpPost("Login")]
		public async Task<IActionResult> Login([FromBody] UserForAuthenticationDto userForAuthentication)
		{
			var user = await _userManager.FindByNameAsync(userForAuthentication.Email);
			if (user == null)
				return BadRequest("Invalid Request");

			//if (!await _userManager.IsEmailConfirmedAsync(user))
			//	return Unauthorized(new AuthResponseDto { ErrorMessage = "Email is not confirmed" });

			//you can check here if the account is locked out in case the user enters valid credentials after locking the account.

			//if (!await _userManager.CheckPasswordAsync(user, userForAuthentication.Password))
			//{
			//	await _userManager.AccessFailedAsync(user);

			//	if (await _userManager.IsLockedOutAsync(user))
			//	{
			//		var content = $"Your account is locked out. To reset the password click this link: {userForAuthentication.clientURI}";
			//		var message = new Message(new string[] { userForAuthentication.Email }, "Locked out account information", content, null);
			//		await _emailSender.SendEmailAsync(message);

			//		return Unauthorized(new AuthResponseDto { ErrorMessage = "The account is locked out" });
			//	}

			//	return Unauthorized(new AuthResponseDto { ErrorMessage = "Invalid Authentication" });
			//}

			//if (await _userManager.GetTwoFactorEnabledAsync(user))
			//	return await GenerateOTPFor2StepVerification(user);

			var token = await _jwtHandler.GenerateToken(user);

			await _userManager.ResetAccessFailedCountAsync(user);

			return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = token });
		}

		[HttpPost("ExternalLogin")]
		public async Task<IActionResult> ExternalLogin([FromBody] ExternalAuthDto externalAuth)
		{
			var payload =  await _jwtHandler.VerifyGoogleToken(externalAuth);
			if(payload == null)
				return BadRequest("Invalid External Authentication.");

			var info = new UserLoginInfo(externalAuth.Provider, payload.Subject, externalAuth.Provider);

			var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
			if (user == null)
			{
				user = await _userManager.FindByEmailAsync(payload.Email);

				if (user == null)
				{
					user = new ApplicationUser { Email = payload.Email, UserName = payload.Email };
					user.UserRole = "User";
					await _userManager.CreateAsync(user);

					//prepare and send an email for the email confirmation

					await _userManager.AddToRoleAsync(user, "User");
					await _userManager.AddLoginAsync(user, info);
				}
				else
				{
					await _userManager.AddLoginAsync(user, info);
				}
			}

			if (user == null)
				return BadRequest("Invalid External Authentication.");

			//check for the Locked out account

			var token = await _jwtHandler.GenerateToken(user);
			return Ok(new AuthResponseDto { Token = token, IsAuthSuccessful = true });
		}
	}
}
