using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Loging;

public class LogDetailWithException:LogDetail
{
    public string ExceptionMessage { get; set; }
    public LogDetailWithException()
    {
        ExceptionMessage = string.Empty;
    }

    public LogDetailWithException(string fullName, string metodName, string user, List<LogParameter> parameters, string exceptionMessage):base(fullName, metodName, user, parameters)
    {
        ExceptionMessage = exceptionMessage;
    }
}
