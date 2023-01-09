using EVOChampions.Manager.AccountManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EVOChampions.Error
{
    internal class MessageGenerator
    {
        public string GetArgumentNullMessage(string argumentName, string nameof)
        {
            return string.Format("Argument '{0}' ({0}) can not bee null", argumentName, nameof);
        }

        public string IndexOutOfRange(string argumentName, string nameof)
        {
            return string.Format("Argument '{0}' ({0}) is out of range", argumentName, nameof);
        }
    }
}
