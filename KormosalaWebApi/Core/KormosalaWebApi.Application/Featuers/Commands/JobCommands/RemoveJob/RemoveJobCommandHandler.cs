using KormosalaWebApi.Application.Repositories.JobRepository;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Commands.JobCommands.RemoveJob
{
    public class RemoveJobCommandHandler : IRequestHandler<RemoveJobCommandRequest, RemoveJobCommandResponse>
    {
        private readonly IJobRepository _repository;

        public RemoveJobCommandHandler(IJobRepository repository)
        {
            _repository = repository;
        }

        public async Task<RemoveJobCommandResponse> Handle(RemoveJobCommandRequest request, CancellationToken cancellationToken)
        {
            var job = await _repository.GetByIdAsync(request.Id);

            if (job is null)
            {
                return new RemoveJobCommandResponse
                {
                    Success = false,
                    Message = "Job Not Found"
                };
            }

            try
            {
                _repository.Remove(job);
                 await _repository.SaveAsync();

                return new RemoveJobCommandResponse
                {
                    Success = true,
                    Message = "Job Deleted Successfully"
                };
            }
            catch (Exception ex)
            {
                return new RemoveJobCommandResponse
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
