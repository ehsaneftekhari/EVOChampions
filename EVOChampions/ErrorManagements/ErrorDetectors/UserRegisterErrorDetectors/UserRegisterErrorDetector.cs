using EVOChampions.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVOChampions.ErrorManagements.ErrorDetectors.UserRegisterErrorDetectors
{
    public abstract class UserRegisterErrorDetector : ErrorDetector
    {
        protected UserRegisterErrorDetector(RegisterManager registerManager) : base(registerManager)
        {
        }

        public bool Detect(User newUser)
        {
            if (newUser == null)
            {
                throw new ArgumentNullException(nameof(newUser));
            }

            return DoDetection(newUser);
        }

        protected abstract bool DoDetection(User newUser);
    }
}
