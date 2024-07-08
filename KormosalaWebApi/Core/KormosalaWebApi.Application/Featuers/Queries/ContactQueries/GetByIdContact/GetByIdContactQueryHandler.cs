using KormosalaWebApi.Application.Repositories.ContactRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Queries.ContactQueries.GetByIdContact
{
    public class GetByIdContactQueryHandler : IRequestHandler<GetByIdContactQueryRequest, GetByIdContactQueryResponse>
    {
        private readonly IContactRepository _repository;

        public GetByIdContactQueryHandler(IContactRepository repository  )
        {
            _repository = repository;
        }

        public async Task<GetByIdContactQueryResponse> Handle(GetByIdContactQueryRequest request, CancellationToken cancellationToken)
        {
            var contact = await _repository.GetByIdAsync(request.Id);

            if (contact is null)
            {
                return new GetByIdContactQueryResponse
                {
                    Success = false,
                    Message = "Contact not found"
                };
            }

            try
            {
                return new GetByIdContactQueryResponse
                {
                    Id = contact.Id,
                    Email = contact.Email,
                    FullName = contact.FullName,
                    UserMessage = contact.UserMessage,

                    Success = true,
                    Message = "Successfully"
                };
            }
            catch (Exception ex)
            {
                return new GetByIdContactQueryResponse
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
