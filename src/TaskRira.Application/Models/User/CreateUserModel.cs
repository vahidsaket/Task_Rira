﻿using ProtoBuf;

namespace TaskRira.Application.Models.User
{

    [ProtoContract]
    public class CreateUserModel
    {
        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(1)]
        public string Name { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(2)]
        public string Family { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(3)]
        public string NationalCode { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(4)]
        public string BirthDate { get; set; }
    }

    public class UserCreateResponseModel : BaseResponseModel { }
}
