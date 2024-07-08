using KormosalaWebApi.Application.Repositories.JobRepository;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Commands.JobCommands.UpdateJob
{
    public class UpdateJobCommandHandler : IRequestHandler<UpdateJobCommandRequest, UpdateJobCommandResponse>
    {
        private readonly IJobRepository _repository;

        public UpdateJobCommandHandler(IJobRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateJobCommandResponse> Handle(UpdateJobCommandRequest request, CancellationToken cancellationToken)
        {
            var job = await _repository.GetByIdAsync(request.Id);
            if (job is null)
            {
                return new UpdateJobCommandResponse
                {
                    Success = false,
                    Message = "Job Not Found"
                };
            }

            try
            {
                job.Description = request.Description;
                job.Experince = request.Experince;
                job.Name = request.Name;
                job.Salary = request.Salary;
                job.CategoryId = request.CategoryId;
                job.CompanyId = request.CompanyId;
                job.JobType = request.JobType;

                _repository.Update(job);
                await _repository.SaveAsync();

                return new UpdateJobCommandResponse { Success = true,  Message = "Job Update Successfully" };
            }
            catch (Exception ex)
            {
                return new UpdateJobCommandResponse
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
