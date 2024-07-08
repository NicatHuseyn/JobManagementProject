using KormosalaWebApi.Application.Repositories.ContactRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Commands.ContactCommands.CreateContact
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommandRequest, CreateContactCommandResponse>
    {
        private readonly IContactRepository _repository;

        public CreateContactCommandHandler(IContactRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateContactCommandResponse> Handle(CreateContactCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.AddAsync(new Domain.Entities.Contact
                {
                    Email  = request.Email,
                    FullName = request.FullName,
                    UserMessage = request.UserMessage,
                });

                await _repository.SaveAsync();

                return new CreateContactCommandResponse
                {
                    Success = true,
                    Message = "Contact Create Successfully"
                };
            }
            catch (Exception ex)
            {
                return new CreateContactCommandResponse
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
