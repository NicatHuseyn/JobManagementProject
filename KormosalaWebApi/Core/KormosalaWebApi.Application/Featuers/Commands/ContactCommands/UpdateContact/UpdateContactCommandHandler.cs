using KormosalaWebApi.Application.Repositories.ContactRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Commands.ContactCommands.UpdateContact
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommandRequest, UpdateContactCommandResponse>
    {
        private readonly IContactRepository _repository;

        public UpdateContactCommandHandler(IContactRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateContactCommandResponse> Handle(UpdateContactCommandRequest request, CancellationToken cancellationToken)
        {
            var contact = await _repository.GetByIdAsync(request.Id);
            if (contact is null)
            {
                return new UpdateContactCommandResponse
                {
                    Success = false,
                    Message = "Contact Not Found"
                };
            }

            try
            {
                contact.UserMessage = request.UserMessage;
                contact.FullName = request.FullName;
                contact.Email = request.Email;

                _repository.Update(contact);
                await _repository.SaveAsync();

                return new UpdateContactCommandResponse { Success = true, Message = "Contact Update Successfully" };
            }
            catch (Exception ex)
            {
                return new UpdateContactCommandResponse
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
