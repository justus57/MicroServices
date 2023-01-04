using System;
using System.Threading;
using System.Threading.Tasks;
using Banking.DotNetConf.Core.Interfaces;
using Banking.DotNetConf.Core.ProjectAggregate;
using Banking.DotNetConf.Core.ProjectAggregate.Events;
using Banking.DotNetConf.Core.ProjectAggregate.Handlers;
using Moq;
using Xunit;

namespace Banking.DotNetConf.UnitTests.Core.Handlers;

public class ItemCompletedEmailNotificationHandlerHandle
{
    private ItemCompletedEmailNotificationHandler _handler;
    private Mock<IEmailSender> _emailSenderMock;

    public ItemCompletedEmailNotificationHandlerHandle()
    {
        _emailSenderMock = new Mock<IEmailSender>();
        _handler = new ItemCompletedEmailNotificationHandler(_emailSenderMock.Object);
    }

    [Fact]
    public async Task ThrowsExceptionGivenNullEventArgument()
    {
        Exception ex = await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(null, CancellationToken.None));
    }

    [Fact]
    public async Task SendsEmailGivenEventInstance()
    {
        await _handler.Handle(new ToDoItemCompletedEvent(new ToDoItem()), CancellationToken.None);

        _emailSenderMock.Verify(sender => sender.SendEmailAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
    }
}
