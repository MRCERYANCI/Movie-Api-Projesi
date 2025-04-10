using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesingPattern.Commands.TagCommands
{
    public class RemoveTagCommand : IRequest
    {
        public int id { get; set; }
        public RemoveTagCommand(int id)
        {
            this.id = id;
        }
    }
}
