using TaskRira.Application.Models.User;

namespace TaskRira.Application.Services
{
    public interface IUserService
    {
        Task<List<SelectUserModel>> GetAllAsync();

        Task<UserUpdateResponseModel> UpdateAsync(UpdateUserModel updateUserModel);

        Task<UserCreateResponseModel> CreateAsync(CreateUserModel createUserModel);

        Task<SelectUserModel> GetByIdAsync(int id);
        Task<SelectUserModel> DeleteAsync(int id);
    }
}
