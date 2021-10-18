using System;
using MediatR;

namespace azuretest_2.App.AccApplayer.Usecases.UserUsecases.GetId
{
    public class GetIdResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}