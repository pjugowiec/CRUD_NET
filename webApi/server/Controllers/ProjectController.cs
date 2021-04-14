using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using webApi.Domain.Entities;
using webApi.Repositories;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController
    {
        private readonly IRepository<ProjectEntity> _projectRepo;

        public ProjectController(IRepository<ProjectEntity> projectRepo)
        {
            _projectRepo = projectRepo;
        }

        [HttpGet(Name = "GetProjects")]
        public IEnumerable<ProjectEntity> GetAll()
        {
            return _projectRepo.GetAll();
        }

        [HttpGet("{id}", Name = "FindProjectById")]
        public void GetById([FromQuery] long id)
        {
            _projectRepo.GetById(id);
        }

        [HttpPost(Name = "CreateProject")]
        public void Create([FromBody] ProjectEntity project)
        {
            _projectRepo.Insert(project);
        }

        [HttpPut("{id}", Name = "UpdateProject")]
        public void Update([FromQuery] long id, [FromBody] ProjectEntity project)
        {
            _projectRepo.Update(project);
        }

        [HttpDelete("{id}", Name = "DeleteProjectById")]
        public void DeleteById([FromQuery] long id)
        {
            _projectRepo.DeleteById(id);
        }
    }
}
