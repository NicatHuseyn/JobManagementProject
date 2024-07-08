using KormosalaWebApi.Application.Repositories.ContactRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Commands.ContactCommands.RemoveContact
{
    public class RemoveContactCommandHandler : IRequestHandler<RemoveContactCommandRequest, RemoveContactCommandResponse>
    {
        private readonly IContactRepository _repository;

        public RemoveContactCommandHandler(IContactRepository repository)
        {
            _repository = repository;
        }

        public async Task<RemoveContactCommandResponse> Handle(RemoveContactCommandRequest request, CancellationToken cancellationToken)
        {
            var contact = await _repository.GetByIdAsync(request.Id);

            if (contact is null)
            {
                return new RemoveContactCommandResponse
                {
                    Success = false,
                    Message = "Contact Not Found"
                };
            }

            try
            {
                _repository.Remove(contact);
                await _repository.SaveAsync();

                return new RemoveContactCommandResponse
                {
                    Success = true,
                    Message = "Contact Deleted Successfully"
                };
            }
            catch (Exception ex)
            {
                return new RemoveContactCommandResponse
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }
    }
}
