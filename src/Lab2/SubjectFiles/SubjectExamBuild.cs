using Itmo.ObjectOrientedProgramming.Lab2.MaterialsFiles;

namespace Itmo.ObjectOrientedProgramming.Lab2.SubjectFiles;

public class SubjectExamBuild : ISubjectBuilder
{
    private static Dictionary<int, string> LabWorks { get; set; } = [];

    private static Dictionary<int, string> LectureMaterials { get; set; } = [];

    private readonly Subject? newSubject;

    public SubjectExamBuild()
    {
        newSubject = new Subject(LabWorks, LectureMaterials);
    }

    public SubjectExamBuild SubjectNameBuild(string name)
    {
        newSubject?.SetName(name);
        return this;
    }

    public SubjectExamBuild ExamPointsBuild(int ePoints)
    {
        newSubject?.SetExamPoints(ePoints);
        return this;
    }

    public void PassPointsBuild(int pPoints)
    {
        newSubject?.SetPassPoints(pPoints);
    }

    public SubjectExamBuild AuthorBuild(int author)
    {
        newSubject?.SetIdAuthor(author);
        return this;
    }

    public void LabWorksBuild(int labId, RepositoryLaboratory labRepository)
    {
        LabWorks.Add(labId, labRepository.LabWorksGet(labId));
    }

    public void LectureMaterialsBuild(int lecId, RepositoryLectures lecRepository)
    {
        LectureMaterials.Add(lecId, lecRepository.LectureMaterialsGet(lecId));
    }

    public Subject? Build()
    {
        if (newSubject?.GetExamPoints() != null)
        {
            return newSubject;
        }

        return null;
    }
}
