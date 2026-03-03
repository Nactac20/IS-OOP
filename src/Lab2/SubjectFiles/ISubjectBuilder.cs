using Itmo.ObjectOrientedProgramming.Lab2.MaterialsFiles;

namespace Itmo.ObjectOrientedProgramming.Lab2.SubjectFiles;

public interface ISubjectBuilder
{
    public SubjectExamBuild SubjectNameBuild(string name);

    public SubjectExamBuild ExamPointsBuild(int ePoints);

    public void PassPointsBuild(int pPoints);

    public SubjectExamBuild AuthorBuild(int author);

    public void LabWorksBuild(int labId, RepositoryLaboratory labRepository);

    public void LectureMaterialsBuild(int lecId, RepositoryLectures lecRepository);
}