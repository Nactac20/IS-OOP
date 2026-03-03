using Itmo.ObjectOrientedProgramming.Lab2.MaterialsFiles;
using Itmo.ObjectOrientedProgramming.Lab2.SubjectFiles;
using Itmo.ObjectOrientedProgramming.Lab2.UserFiles;

using Xunit;

namespace Lab2.Tests;

public class Tests2
{
    [Fact]
    public void UpDateLab_NonAuthor_False()
    {
        var lab = new Laboratory("Lab1", "Description", "Criterion", 100);
        lab.SetAuthor(1);
        bool result = lab.UpDateLab(2, "NewName", "NewDescription", "NewCriterion");
        Assert.False(result);
    }

    [Fact]
    public void CloneLab_ContainsParentId()
    {
        var lab = new Laboratory("Lab1", "Description", "Criterion", 100);
        Laboratory clonedLab = lab.CloneLab();
        Assert.Equal(lab.GetId(), clonedLab.GetParent());
    }

    [Fact]
    public void UpDateLec_NonAuthor_False()
    {
        var lec = new Lectures("Lecture1", "Description", "Content");
        lec.SetAuthor(1);
        bool result = lec.UpDateLec(2, "NewName", "NewDescription", "NewContent");
        Assert.False(result);
    }

    [Fact]
    public void CloneLec_ContainsParentId()
    {
        var lec = new Lectures("Lecture1", "Description", "Content");
        Lectures clonedLec = lec.CloneLec();
        Assert.Equal(lec.GetId(), clonedLec.GetParent());
    }

    [Fact]
    public void CheckBuild_InvalidPoints_False()
    {
        Subject? subjectBuilder = new SubjectExamBuild().SubjectNameBuild("Subject1")
            .ExamPointsBuild(70)
            .AuthorBuild(1)
            .Build();

        if (subjectBuilder != null)
        {
            subjectBuilder.SetSumPoints(10);
        }

        Assert.False(subjectBuilder?.GetExamPoints() + subjectBuilder?.GetSumPoints() == 100);
    }

    [Fact]
    public void CheckBuild_ValidPoints_True()
    {
        Subject? subjectBuilder = new SubjectExamBuild().SubjectNameBuild("Subject1")
            .ExamPointsBuild(70)
            .AuthorBuild(1)
            .Build();

        if (subjectBuilder != null)
        {
            subjectBuilder.SetSumPoints(30);
        }

        Assert.True(subjectBuilder?.GetExamPoints() + subjectBuilder?.GetSumPoints() == 100);
    }

    [Fact]
    public void CreateUser_ReturnsUserWithCorrectId()
    {
        var user = new User("User1");
        int? id = user.GetId();
        Assert.NotNull(id);
    }
}