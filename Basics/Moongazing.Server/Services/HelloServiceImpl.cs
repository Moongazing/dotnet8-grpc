using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HelloService;

namespace Moongazing.Server.Services;

public class HelloServiceImpl:HelloServiceBase
{

    public override Task<HelloResponse> Welcome(HelloRequest request, ServerCallContext context)
    {
        var message = $" Hello {request.FirstName} {request.LastName}";
        return Task.FromResult(new HelloResponse()
        {
            Message = message
        });
    }
}
