using System;
using MediatR;

namespace azuretest_2.App.AccApplayer.Usecases.UserUsecases.GetId
{
    public class GetIdRequest : IRequest<GetIdResponse>
    {
        public int Id { get; set; }
    }
}