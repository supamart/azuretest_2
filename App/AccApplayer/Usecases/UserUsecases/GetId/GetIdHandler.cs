using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace azuretest_2.App.AccApplayer.Usecases.UserUsecases.GetId
{
    public class  GetIdHandler:IRequestHandler<GetIdRequest, GetIdResponse>
    {
        public async Task<GetIdResponse> Handle(GetIdRequest request, CancellationToken cancellationToken)
        {
            var user = new GetIdResponse
            {
                Id = request.Id,
                Name = "john"
            };

            return user;
        }

    }

}