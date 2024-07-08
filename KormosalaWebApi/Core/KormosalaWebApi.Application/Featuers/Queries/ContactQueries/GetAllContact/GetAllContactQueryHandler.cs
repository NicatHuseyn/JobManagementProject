using KormosalaWebApi.Application.Repositories.ContactRepository;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Queries.ContactQueries.GetAllContact
{
    public class GetAllContactQueryHandler : IRequestHandler<GetAllContactQueryRequest, List<GetAllContactQueryResponse>>
    {
        private readonly IContactRepository _repository;

        public GetAllContactQueryHandler(IContactRepository repository)
        {
            _repository = repository;
        }

        public Task<List<GetAllContactQueryResponse>> Handle(GetAllContactQueryRequest request, CancellationToken cancellationToken)
        {
            var contacts = _repository.GetAll();

            return contacts.Select(x=> new GetAllContactQueryResponse
            {
                Id = x.Id,
                Email = x.Email,
                FullName = x.FullName,
                UserMessage = x.UserMessage,

                Success = true,
                Message = "Successfully"
            }).ToListAsync();
        }
    }
}
