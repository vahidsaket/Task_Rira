using AutoMapper;
using Grpc.Core;
using TaskRira.Application.Models.User;
using TaskRira.Application.Services;

namespace Grpc.Server.Services
{
    public class UserCallService : UserGrpcService.UserGrpcServiceBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserCallService(IUserService userService,
            IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async override Task<Users> GetAllUser(Empty request, ServerCallContext context)
        {
            List<SelectUserModel> useData = await _userService.GetAllAsync();

            Users users = new Users();

            foreach (SelectUserModel item in useData)
            {
                users.Items.Add(_mapper.Map<UserDetails>(item));
            }

            return users;
        }

        public async override Task<UpdateUserResponseModel> UserUpdate(UpdateUserDetailRequest request, ServerCallContext context)
        {
            UpdateUserModel updateUserModel = new UpdateUserModel
            {
                BirthDate = request.User.BirthDate,
                Family = request.User.Family,
                Name = request.User.Name,
                NationalCode = request.User.NationalCode,
                UserId = request.User.UserId,
            };

            UserUpdateResponseModel resultUpdate = await _userService.UpdateAsync(updateUserModel);

            UpdateUserResponseModel model = new UpdateUserResponseModel
            {
                Id = resultUpdate.Id,
            };
            return model;
        }

        public async override Task<CreateUserResponseModel> UserCreate(CreateUserDetailRequest request, ServerCallContext context)
        {
            CreateUserModel createUserModel = _mapper.Map<CreateUserModel>(request);

            UserCreateResponseModel resultCreate = await _userService.CreateAsync(createUserModel);

            CreateUserResponseModel model = new CreateUserResponseModel
            {
                Id = resultCreate.Id,
            };
            return model;
        }

        public async override Task<UserDetails> UserGetById(UserGetByIdRequestModel request, ServerCallContext context)
        {
            SelectUserModel selectUserModel = await _userService.GetByIdAsync(request.Id);

            return _mapper.Map<UserDetails>(selectUserModel);
        }

        public async override Task<UserDetails> UserDelete(UserDeleteRequestModel request, ServerCallContext context)
        {
            SelectUserModel selectUserModel = await _userService.DeleteAsync(request.Id);

            return _mapper.Map<UserDetails>(selectUserModel);
        }
    }
}
