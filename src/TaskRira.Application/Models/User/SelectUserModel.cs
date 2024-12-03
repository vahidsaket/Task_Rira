using ProtoBuf;

namespace TaskRira.Application.Models.User
{
    //[ProtoContract]
    public class SelectUserModel
    {
        //[ProtoMember(1)]
        public string UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        //[ProtoMember(2)]
        public string Name { get; set; }


        /// <summary>
        /// 
        /// </summary>
        //[ProtoMember(3)]
        public string Family { get; set; }

        /// <summary>
        /// 
        /// </summary>
        //[ProtoMember(4)]
        public string NationalCode { get; set; }


        /// <summary>
        /// 
        /// </summary>
        //[ProtoMember(5)]
        public string BirthDate { get; set; }
    }
}
