using System.Collections.Generic;
using Banking.DotNetConf.Core.ProjectAggregate;

namespace Banking.DotNetConf.Web.Endpoints.ProjectEndpoints;

public class ProjectListResponse
{
    public List<ProjectRecord> Projects { get; set; } = new();
}
