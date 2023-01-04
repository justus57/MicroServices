using Ardalis.Specification;
using Banking.DotNetConf.Core.ProjectAggregate;

namespace Banking.DotNetConf.Core.ProjectAggregate.Specifications;

public class ProjectByIdWithItemsSpec : Specification<Project>, ISingleResultSpecification
{
    public ProjectByIdWithItemsSpec(int projectId)
    {
        Query
            .Where(project => project.Id == projectId)
            .Include(project => project.Items);
    }
}
