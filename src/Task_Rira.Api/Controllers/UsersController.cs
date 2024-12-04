using Grpc.Net.Client;
using Grpc.Server;
using Microsoft.AspNetCore.Mvc;
using Task_Rira.Api.Models;

namespace Task_Rira.Controllers
{
    public class UsersController : ApiController
    {
        private readonly GrpcChannel _channel;
        private readonly IConfiguration _configuration;
        private readonly UserGrpcService.UserGrpcServiceClient _client;

        public UsersController(
            IConfiguration configuration)
        {
            _configuration = configuration;
            _channel = GrpcChannel.ForAddress(_configuration.GetValue<string>("GrpcSettings:UserServiceUrl"));
            _client = new UserGrpcService.UserGrpcServiceClient(_channel);
        }

        [HttpGet(nameof(GetAllUserAsync))]
        public async Task<IActionResult> GetAllUserAsync()
        {
            try
            {
                Empty empty = new Empty();
                Users response = await _client.GetAllUserAsync(empty);
                return Ok(ApiResult<Users>.Success(response));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(nameof(CreateUserAsync))]
        public async Task<IActionResult> CreateUserAsync(CreateUserDetailRequest request)
        {
            try
            {
                CreateUserResponseModel response = await _client.UserCreateAsync(request);
                return Ok(ApiResult<CreateUserResponseModel>.Success(response));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut(nameof(UpdateUserAsync))]
        public async Task<IActionResult> UpdateUserAsync(UpdateUserDetailRequest request)
        {
            try
            {
                UpdateUserResponseModel response = await _client.UserUpdateAsync(request);
                return Ok(ApiResult<UpdateUserResponseModel>.Success(response));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost(nameof(GetByIdAsync))]
        public async Task<IActionResult> GetByIdAsync(UserGetByIdRequestModel request)
        {
            try
            {
                if (request == null || request.Id <= 0)
                    return NotFound();

                UserDetails response = await _client.UserGetByIdAsync(request);
                return Ok(ApiResult<UserDetails>.Success(response));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete(nameof(DeleteUserAsync))]
        public async Task<IActionResult> DeleteUserAsync(UserDeleteRequestModel request)
        {
            try
            {
                UserDetails response = await _client.UserDeleteAsync(request);
                return Ok(ApiResult<UserDetails>.Success(response));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
