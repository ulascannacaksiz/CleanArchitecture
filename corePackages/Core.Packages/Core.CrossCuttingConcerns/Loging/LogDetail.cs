using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Loging;

public class LogDetail
{
    public string FullName { get; set; }
    public string MetodName { get; set; }
    public string User { get; set; }
    public List<LogParameter> Parameters { get; set; }
    public LogDetail()
    {
        FullName = string.Empty;
        MetodName = string.Empty;
        User = string.Empty;
        Parameters = new List<LogParameter>();
    }

    public LogDetail(string fullName, string metodName, string user, List<LogParameter> parameters)
    {
        FullName = fullName;
        MetodName = metodName;
        User = user;
        Parameters = parameters;
    }
}
