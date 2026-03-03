using Itmo.ObjectOrientedProgramming.Lab3.DisplayDriverFiles;
using Itmo.ObjectOrientedProgramming.Lab3.DisplayFiles;
using Itmo.ObjectOrientedProgramming.Lab3.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.MessageFiles;
using Itmo.ObjectOrientedProgramming.Lab3.MessengerFiles;
using Itmo.ObjectOrientedProgramming.Lab3.RecipientFiles;
using Itmo.ObjectOrientedProgramming.Lab3.SignificanceFiles;
using Itmo.ObjectOrientedProgramming.Lab3.TopicFiles;
using Itmo.ObjectOrientedProgramming.Lab3.UserFiles;
using Moq;
using Xunit;

namespace Lab3.Tests;

public class TestsLab3
{
    [Fact]
    public void Test_Message_Status_Unread_To_Read()
    {
        var user = new User(1, "TestUser");
        var message = new Message(1, "Test Title", "Test Body");
        user.ReceiveMessage(message);
        bool result = user.MarkMessageStatus(message.GetId());
        Assert.True(result);
        Assert.True(user.GetMessagesStatus()[message.GetId()]);
    }

    [Fact]
    public void Test_Message_Status_Already_Read()
    {
        var user = new User(1, "TestUser");
        var message = new Message(1, "Test Title", "Test Body");
        user.ReceiveMessage(message);
        user.MarkMessageStatus(message.GetId());
        bool result = user.MarkMessageStatus(message.GetId());
        Assert.False(result);
    }

    [Fact]
    public void Test_ReceiveMessage_High_Significance()
    {
        var mockRecipient = new Mock<IRecipient>();
        var significanceFilter = new SignificanceFilter(mockRecipient.Object, SignificanceLevel.Medium);
        var highSignificanceMessage = new Message(1, "High Significance", "High Body");
        highSignificanceMessage.SetLevel(SignificanceLevel.High);
        significanceFilter.ReceiveMessage(highSignificanceMessage);
        mockRecipient.Verify(r => r.ReceiveMessage(highSignificanceMessage), Times.Once);
    }

    [Fact]
    public void Test_Message_Logging()
        {
            var mockLogger = new Mock<ILogger>();
            var mockRecipient = new Mock<IRecipient>();
            var recipientLogging = new RecipientLogging(mockRecipient.Object, mockLogger.Object);
            var message = new Message(1, "Test Title", "Test Body");
            recipientLogging.ReceiveMessage(message);
            mockLogger.Verify(l => l.LogMessage(message), Times.Once);
            mockRecipient.Verify(r => r.ReceiveMessage(message), Times.Once);
        }

    [Fact]
    public void Test_Message_Sending_To_Messenger()
    {
        var mockMessenger = new Mock<IRecipientMessenger>();
        var recipientMessenger = new RecipientMessenger(mockMessenger.Object);
        var message = new Message(1, "Test Title", "Test Body");
        recipientMessenger.ReceiveMessage(message);
        mockMessenger.Verify(m => m.WriteMessage(It.IsAny<string>()), Times.Once);
    }

    [Fact]
    public void Test_Message_Sending_To_Group_With_Filter()
    {
        var mockRecipient1 = new Mock<IRecipient>();
        var mockRecipient2 = new Mock<IRecipient>();
        var recipientGroup = new RecipientGroup();
        recipientGroup.AddRecipient(new SignificanceFilter(mockRecipient1.Object, SignificanceLevel.Medium));
        recipientGroup.AddRecipient(mockRecipient2.Object);
        var highSignificanceMessage = new Message(1, "High Significance", "High Body");
        highSignificanceMessage.SetLevel(SignificanceLevel.High);
        var lowSignificanceMessage = new Message(2, "Low Significance", "Low Body");
        lowSignificanceMessage.SetLevel(SignificanceLevel.Low);
        recipientGroup.ReceiveMessage(highSignificanceMessage);
        recipientGroup.ReceiveMessage(lowSignificanceMessage);
        mockRecipient1.Verify(r => r.ReceiveMessage(It.Is<IMessage>(m => m.GetLevel() == SignificanceLevel.High)), Times.Once);
        mockRecipient1.Verify(r => r.ReceiveMessage(It.Is<IMessage>(m => m.GetLevel() == SignificanceLevel.Low)), Times.Never);
        mockRecipient2.Verify(r => r.ReceiveMessage(It.Is<IMessage>(m => m.GetLevel() == SignificanceLevel.High)), Times.Once);
        mockRecipient2.Verify(r => r.ReceiveMessage(It.Is<IMessage>(m => m.GetLevel() == SignificanceLevel.Low)), Times.Once);
    }

    [Fact]
    public void Test_ReceiveMessage_CallsShowMessage()
    {
        var mockDisplay = new Mock<IDisplay>();
        var recipientDisplay = new RecipientDisplay(mockDisplay.Object);
        var message = new Mock<IMessage>();
        recipientDisplay.ReceiveMessage(message.Object);
        mockDisplay.Verify(d => d.ShowMessage(message.Object, ConsoleColor.White), Times.Once);
    }

    [Fact]
    public void Test_WriteText_WritesToFile()
    {
        string tempFilePath = Path.GetTempFileName();
        var fileDisplayDriver = new FileDisplayDriver(tempFilePath);
        string text = "Test Message";
        fileDisplayDriver.WriteText(text);
        string fileContent = File.ReadAllText(tempFilePath);
        Assert.Contains(text, fileContent, StringComparison.Ordinal);
    }

    [Fact]
    public void Test_ClearDisplay_ClearsFile()
    {
        string tempFilePath = Path.GetTempFileName();
        var fileDisplayDriver = new FileDisplayDriver(tempFilePath);
        string text = "Test Message";
        fileDisplayDriver.WriteText(text);
        fileDisplayDriver.ClearDisplay();
        string fileContent = File.ReadAllText(tempFilePath);
        Assert.Empty(fileContent);
    }

    [Fact]
    public void Test_GetName_ReturnsCorrectName()
    {
        Topic topic = Topic.Instance;
        string name = "Test Topic";
        topic.SetName(name);
        Assert.Equal(name, topic.GetName());
    }

    [Fact]
    public void Test_SendMessage_SendsMessageToAllRecipients()
    {
        Topic topic = Topic.Instance;
        var mockRecipient1 = new Mock<IRecipient>();
        var mockRecipient2 = new Mock<IRecipient>();
        topic.AddRecipient(mockRecipient1.Object);
        topic.AddRecipient(mockRecipient2.Object);
        var message = new Mock<IMessage>();
        topic.SendMessage(message.Object);
        mockRecipient1.Verify(r => r.ReceiveMessage(message.Object), Times.Once);
        mockRecipient2.Verify(r => r.ReceiveMessage(message.Object), Times.Once);
    }

    [Fact]
    public void Test_SendMessage_DoesNotSendMessageToRemovedRecipient()
    {
        Topic topic = Topic.Instance;
        var mockRecipient1 = new Mock<IRecipient>();
        var mockRecipient2 = new Mock<IRecipient>();
        topic.AddRecipient(mockRecipient1.Object);
        topic.AddRecipient(mockRecipient2.Object);
        topic.RemoveRecipient(mockRecipient2.Object);
        var message = new Mock<IMessage>();
        topic.SendMessage(message.Object);
        mockRecipient1.Verify(r => r.ReceiveMessage(message.Object), Times.Once);
        mockRecipient2.Verify(r => r.ReceiveMessage(message.Object), Times.Never);
    }

    [Fact]
    public void Test_AddRecipient_AddsRecipientToList()
    {
        Topic topic = Topic.Instance;
        var mockRecipient = new Mock<IRecipient>();
        topic.AddRecipient(mockRecipient.Object);
        var message = new Mock<IMessage>();
        topic.SendMessage(message.Object);
        mockRecipient.Verify(r => r.ReceiveMessage(message.Object), Times.Once);
    }

    [Fact]
    public void Test_RemoveRecipient_RemovesRecipientFromList()
    {
        Topic topic = Topic.Instance;
        var mockRecipient = new Mock<IRecipient>();
        topic.AddRecipient(mockRecipient.Object);
        topic.RemoveRecipient(mockRecipient.Object);
        var message = new Mock<IMessage>();
        topic.SendMessage(message.Object);
        mockRecipient.Verify(r => r.ReceiveMessage(message.Object), Times.Never);
    }

    [Fact]
    public void Test_ReceiveMessage_CallsUserReceiveMessage()
    {
        var mockUser = new Mock<IRecipientUser>();
        var recipientUser = new RecipientUser(mockUser.Object);
        var message = new Mock<IMessage>();
        recipientUser.ReceiveMessage(message.Object);
        mockUser.Verify(u => u.ReceiveMessage(message.Object), Times.Once);
    }

    [Fact]
    public void Test_MarkMessageStatus_CallsUserMarkMessageStatus()
    {
        var mockUser = new Mock<IRecipientUser>();
        var recipientUser = new RecipientUser(mockUser.Object);
        int messageId = 1;
        recipientUser.MarkMessageStatus(messageId);
        mockUser.Verify(u => u.MarkMessageStatus(messageId), Times.Once);
    }
}