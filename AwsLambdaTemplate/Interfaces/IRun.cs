using System.Threading.Tasks;
using Amazon.Lambda.Core;

namespace $safeprojectname$.Interfaces
{
    public interface IRun
    {
        Task<string> Run(string input, ILambdaContext context);
    }
}