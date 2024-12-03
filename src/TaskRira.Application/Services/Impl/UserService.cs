using AutoMapper;
using Microsoft.Extensions.Configuration;
using TaskRira.Application.Exceptions;
using TaskRira.Application.Models.User;
using TaskRira.Core.Entities;
using TaskRira.DataAccess;
using TaskRira.DataAccess.Repositories;

namespace TaskRira.Application.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<ApplicationUser> _userRepository;
        private readonly IConfiguration _config;

        public UserService(IMapper mapper,
            IBaseRepository<ApplicationUser> userRepository,
            IConfiguration config)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _config = config;
        }

        public async Task<List<SelectUserModel>> GetAllAsync()
        {
            IList<ApplicationUser> user = await _userRepository.GetAllAsNoTrackingAsync();

            List<SelectUserModel> model = _mapper.Map<List<SelectUserModel>>(user);

            return model;
        }

        public async Task<UserUpdateResponseModel> UpdateAsync(UpdateUserModel updateUserModel)
        {
            ApplicationUser user = await _userRepository.GetFirstAsync(x => x.Id == updateUserModel.UserId);

            if (user == null)
                throw new NotFoundException("User not found");

            user = _mapper.Map<UpdateUserModel, ApplicationUser>(updateUserModel, user);

            await _userRepository.UpdateAsync(user);

            return new UserUpdateResponseModel
            {
                Id = user.Id,
            };
        }

        public async Task<UserCreateResponseModel> CreateAsync(CreateUserModel createUserModel)
        {
            ApplicationUser user = _mapper.Map<ApplicationUser>(createUserModel);

            DatabaseConfiguration databaseConfig = _config.GetSection("Database").Get<DatabaseConfiguration>();
            if (databaseConfig.UseInMemoryDatabase)
            {
                Random rnd = new Random();
                user.Id = rnd.Next(1, 9999);
            }

            await _userRepository.AddAsync(user);

            return new UserCreateResponseModel
            {
                Id = user.Id,
            };
        }

        public async Task<SelectUserModel> GetByIdAsync(int id)
        {
            ApplicationUser user = await _userRepository.GetFirstAsNoTrackingAsync(x => x.Id == id);

            SelectUserModel model = _mapper.Map<SelectUserModel>(user);

            return model;
        }

        public async Task<SelectUserModel> DeleteAsync(int id)
        {
            ApplicationUser user = await _userRepository.GetFirstAsync(x => x.Id == id);

            ApplicationUser removeUser = await _userRepository.DeleteAsync(user);

            SelectUserModel model = _mapper.Map<SelectUserModel>(removeUser);

            return model;
        }
    }
}
