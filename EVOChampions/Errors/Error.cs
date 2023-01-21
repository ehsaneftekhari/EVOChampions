using EVOChampions.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVOChampions.Errors
{
    public abstract class Error
    {
        protected RegisterManager registerManager;

        protected Error(RegisterManager registerManager) 
        {
            this.registerManager = registerManager;
        }

        public abstract int ErrorCode { get; }

        public abstract string ErrorMessage { get; }

        protected abstract bool Detect(out int ErrorCode, out string ErrorMessage, User newUser);

        protected void SetMessageAndCode(out int ErrorCode, out string ErrorMessage)
        {
            ErrorCode = this.ErrorCode;
            ErrorMessage = this.ErrorMessage;
        }

        protected void ClearMessageAndCode(out int ErrorCode, out string ErrorMessage)
        {
            ErrorCode = 0;
            ErrorMessage = null;
        }
    }
}
