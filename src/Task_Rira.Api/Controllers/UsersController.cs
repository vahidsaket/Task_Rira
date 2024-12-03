using Grpc.Net.Client;
using Grpc.Server;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<Users> GetAllUserAsync()
        {
            try
            {
                Empty empty = new Empty();
                Users response = await _client.GetAllUserAsync(empty);
                return response;
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        [HttpPost(nameof(CreateUserAsync))]
        public async Task<CreateUserResponseModel> CreateUserAsync(CreateUserDetailRequest request)
        {
            try
            {
                CreateUserResponseModel response = await _client.UserCreateAsync(request);
                return response;
            }
            catch (Exception ex)
            {
            }
            return null;
        }


        [HttpPut(nameof(UpdateUserAsync))]
        public async Task<UpdateUserResponseModel> UpdateUserAsync(UpdateUserDetailRequest request)
        {
            try
            {
                UpdateUserResponseModel response = await _client.UserUpdateAsync(request);
                return response;
            }
            catch (Exception ex)
            {
            }
            return null;
        }


        [HttpGet(nameof(GetByIdAsync))]
        public async Task<UserDetails> GetByIdAsync(UserGetByIdRequestModel request)
        {
            try
            {
                UserDetails response = await _client.UserGetByIdAsync(request);
                return response;
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        [HttpDelete(nameof(DeleteUserAsync))]
        public async Task<UserDetails> DeleteUserAsync(UserDeleteRequestModel request)
        {
            try
            {
                UserDetails response = await _client.UserDeleteAsync(request);
                return response;
            }
            catch (Exception ex)
            {
            }
            return null;
        }
    }
}
