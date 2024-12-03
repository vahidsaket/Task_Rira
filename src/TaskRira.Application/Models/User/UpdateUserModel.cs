namespace TaskRira.Application.Models.User
{
    public class UpdateUserModel
    {
        public int UserId { get; set; }
        /// 
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string Family { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string NationalCode { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string BirthDate { get; set; }
    }

    public class UserUpdateResponseModel : BaseResponseModel
    {

    }
}
