using KormosalaWebApi.Application.Repositories.JobRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Commands.JobCommands.CreateJob
{
    public class CreateJobCommandHandler : IRequestHandler<CreateJobCommandRequest, CreateJobCommandResponse>
    {
        private readonly IJobRepository _repository;

        public CreateJobCommandHandler(IJobRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateJobCommandResponse> Handle(CreateJobCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.AddAsync(new Domain.Entities.Job
                {
                    Description = request.Description,
                    Experince = request.Experince,
                    JobType = request.JobType,
                    Name = request.Name,
                    Salary = request.Salary,
                    CategoryId = request.CategoryId,
                    CompanyId = request.CompanyId
                });

                await _repository.SaveAsync();

                return new CreateJobCommandResponse
                {
                    Success = true,
                    Message = "Job Create Successfully"
                };
            }
            catch (Exception ex)
            {
                return new CreateJobCommandResponse
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }
    }
}
