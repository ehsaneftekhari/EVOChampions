using EVOChampions.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVOChampions.Errors
{
    internal sealed class NationalIdFormatError : Error
    {
        public NationalIdFormatError(RegisterManager registerManager) : base(registerManager)
        {
        }

        public override int ErrorCode => throw new NotImplementedException();

        public override string ErrorMessage => throw new NotImplementedException();

        protected override bool Detect(out int ErrorCode, out string ErrorMessage, User newUser)
        {
            foreach (User user in registerManager.Users)
            {
                if (user == null) 
                {
                    SetMessageAndCode(out ErrorCode, out ErrorMessage);
                    return false;
                }
                    

                if (user.NationalId == newUser.NationalId)
                {

                }
                    return true;
            }
            return false;
        }
    }
}
