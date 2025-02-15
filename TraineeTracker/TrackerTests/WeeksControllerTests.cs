﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraineeTrackerApp.Models;
using Moq;
using TraineeTrackerApp.Services;
using TraineeTrackerApp.Controllers;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore;

namespace TrackerTests;

internal class WeeksControllerTests
{
    // Note add tests to check logged in user privileges

    #region Index()

    [Test]
    public async Task Index_ReturnsTypeOfListWeeks()
    {
        // Arrange
        var serviceMock = new Mock<IWeekService>();
        serviceMock.Setup(mock => mock.GetWeeksAsync()).ReturnsAsync(new List<Week>());

        var store = new Mock<IUserStore<Spartan>>();
        var userMgrMock = new Mock<UserManager<Spartan>>(store.Object, null, null, null, null, null, null, null, null);
        userMgrMock.Setup(mock => mock.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(It.IsAny<Spartan>());

        var sut = new WeeksController(serviceMock.Object, userMgrMock.Object);
        sut.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };

        // Act
        var result = sut.Index().Result;
        var viewResult = (ViewResult)result;
        var viewDataList = (List<Week>)viewResult.ViewData.Model;

        // Assert
        Assert.That(viewDataList, Is.TypeOf<List<Week>>());
    }

    [Test]
    public void Index_GivenUserHasWeeks_ReturnsListOfUsersWeeks()
    {
        // Arrange
        Spartan user = new Spartan
        {
            Id = Guid.NewGuid().ToString(),
        };

        List<Week> weeks = new List<Week>();
        weeks.Add(new Week { SpartanId = user.Id });
        weeks.Add(new Week { SpartanId = user.Id });
        weeks.Add(new Week { SpartanId = user.Id });
        weeks.Add(new Week { SpartanId = Guid.NewGuid().ToString() });
        weeks.Add(new Week { SpartanId = Guid.NewGuid().ToString() });

        var serviceMock = new Mock<IWeekService>();
        serviceMock.Setup(mock => mock.GetWeeksAsync()).ReturnsAsync(weeks);

        var store = new Mock<IUserStore<Spartan>>();
        var userMgrMock = new Mock<UserManager<Spartan>>(store.Object, null, null, null, null, null, null, null, null);
        userMgrMock.Setup(mock => mock.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(user);

        var sut = new WeeksController(serviceMock.Object, userMgrMock.Object);
        sut.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };

        // Act
        var result = sut.Index().Result;
        var viewResult = (ViewResult)result;
        var viewDataList = (List<Week>)viewResult.ViewData.Model;

        // Assert
        Assert.That(viewDataList.Count(), Is.EqualTo(3));
        Assert.That(viewDataList[0], Is.EqualTo(weeks[0]));
        Assert.That(viewDataList[1], Is.EqualTo(weeks[1]));
        Assert.That(viewDataList[2], Is.EqualTo(weeks[2]));
    }

    [Test]
    public void Index_GivenUserHasNoWeeks_ReturnsEmptyListOfWeeks()
    {
        // Arrange
        Spartan user = new Spartan
        {
            Id = Guid.NewGuid().ToString(),
        };

        List<Week> weeks = new List<Week>();
        weeks.Add(new Week { SpartanId = Guid.NewGuid().ToString() });
        weeks.Add(new Week { SpartanId = Guid.NewGuid().ToString() });

        var serviceMock = new Mock<IWeekService>();
        serviceMock.Setup(mock => mock.GetWeeksAsync()).ReturnsAsync(weeks);

        var store = new Mock<IUserStore<Spartan>>();
        var userMgrMock = new Mock<UserManager<Spartan>>(store.Object, null, null, null, null, null, null, null, null);
        userMgrMock.Setup(mock => mock.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(user);

        var sut = new WeeksController(serviceMock.Object, userMgrMock.Object);
        sut.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };

        // Act
        var result = sut.Index().Result;
        var viewResult = (ViewResult)result;
        var viewDataList = (List<Week>)viewResult.ViewData.Model;

        // Assert
        Assert.That(viewDataList.Count(), Is.EqualTo(0));
    }
    #endregion

    #region Details(int)

    [Test]
    public void Details_ReturnsTypeOfWeek()
    {
        // Arrange
        Spartan spartan = new Spartan() { Id = Guid.NewGuid().ToString() };
        
        List<Week> weeks = new List<Week>();
        weeks.Add(new Week { SpartanId = spartan.Id });

        var serviceMock = new Mock<IWeekService>();
        serviceMock.Setup(mock => mock.GetWeeksAsync()).ReturnsAsync(weeks);
        serviceMock.Setup(mock => mock.GetWeekByIdAsync(It.IsAny<int>())).ReturnsAsync(weeks[0]);


        var store = new Mock<IUserStore<Spartan>>();
        var userMgrMock = new Mock<UserManager<Spartan>>(store.Object, null, null, null, null, null, null, null, null);
        userMgrMock.Setup(mock => mock.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(spartan);

        var sut = new WeeksController(serviceMock.Object, userMgrMock.Object);
        sut.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };

        // Act
        var result = sut.Details(It.IsAny<int>()).Result;
        var viewResult = (ViewResult)result;
        var viewData = (Week)viewResult.ViewData.Model;

        // Assert
        Assert.That(viewData, Is.TypeOf<Week>());
    }

    [Test]
    public void Details_GivenValidWeekId_ReturnsWeek()
    {
        // Arrange
        Spartan spartan = new Spartan() { Id = Guid.NewGuid().ToString() };

        List<Week> weeks = new List<Week>();
        weeks.Add(new Week { SpartanId = spartan.Id });
        weeks.Add(new Week { SpartanId = spartan.Id });
        weeks.Add(new Week
        {
            SpartanId = spartan.Id,
            Start = "Listening Babytron",
            Stop = "Unit testing"
        });
        weeks.Add(new Week { SpartanId = Guid.NewGuid().ToString() });
        weeks.Add(new Week { SpartanId = Guid.NewGuid().ToString() });

        var serviceMock = new Mock<IWeekService>();
        serviceMock.Setup(mock => mock.GetWeeksAsync()).ReturnsAsync(weeks);
        serviceMock.Setup(mock => mock.GetWeekByIdAsync(2)).ReturnsAsync(weeks[2]);


        var store = new Mock<IUserStore<Spartan>>();
        var userMgrMock = new Mock<UserManager<Spartan>>(store.Object, null, null, null, null, null, null, null, null);
        userMgrMock.Setup(mock => mock.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(spartan);

        var sut = new WeeksController(serviceMock.Object, userMgrMock.Object);
        sut.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };

        // Act
        var result = sut.Details(2).Result;
        var viewResult = (ViewResult)result;
        var viewData = (Week)viewResult.ViewData.Model;

        // Assert
        Assert.That(viewData.SpartanId, Is.EqualTo(spartan.Id));
        Assert.That(viewData.Start, Is.EqualTo(weeks[2].Start));
        Assert.That(viewData.Stop, Is.EqualTo(weeks[2].Stop));

    }

    [Test]
    public void Details_GivenWeeksUnpopulated_Returns404NotFound()
    {
        // Arrange
        var serviceMock = new Mock<IWeekService>();
        serviceMock.Setup(mock => mock.GetWeeksAsync()).ReturnsAsync(It.IsAny<List<Week>>());

        var store = new Mock<IUserStore<Spartan>>();
        var userMgrMock = new Mock<UserManager<Spartan>>(store.Object, null, null, null, null, null, null, null, null);

        var sut = new WeeksController(serviceMock.Object, userMgrMock.Object);
        sut.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };

        // Act
        var result = sut.Details(It.IsAny<int>()).Result;
        var viewResult = (NotFoundResult)result;

        // Assert
        Assert.That(viewResult.StatusCode, Is.EqualTo(404));
    }

    [Test]
    public void Details_GivenWeekIsNotInDB_Returns404NotFound()
    {
        // Arrange
        List<Week> weeks = new List<Week>();
        weeks.Add(new Week { Id = 1 });
        weeks.Add(new Week { Id = 2 });
        weeks.Add(new Week { Id = 3 });

        var serviceMock = new Mock<IWeekService>();
        serviceMock.Setup(mock => mock.GetWeeksAsync()).ReturnsAsync(weeks);
        serviceMock.Setup(mock => mock.GetWeekByIdAsync(It.IsAny<int>())).ReturnsAsync(value: null);


        var store = new Mock<IUserStore<Spartan>>();
        var userMgrMock = new Mock<UserManager<Spartan>>(store.Object, null, null, null, null, null, null, null, null);

        var sut = new WeeksController(serviceMock.Object, userMgrMock.Object);
        sut.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };

        // Act
        var result = sut.Details(It.IsAny<int>()).Result;
        var viewResult = (NotFoundResult)result;

        // Assert
        Assert.That(viewResult.StatusCode, Is.EqualTo(404));
    }

    [Test]
    public void Details_GivenWeekCreatedByOtherTrainee_ReturnsUnauthorized()
    {
        // Arrange
        Spartan spartan = new Spartan() { Id = Guid.NewGuid().ToString() };

        List<Week> weeks = new List<Week>();
        weeks.Add(new Week { SpartanId = spartan.Id });
        weeks.Add(new Week { SpartanId = spartan.Id });
        weeks.Add(new Week { SpartanId = spartan.Id });
        weeks.Add(new Week { SpartanId = Guid.NewGuid().ToString() });
        weeks.Add(new Week { SpartanId = Guid.NewGuid().ToString() });

        var serviceMock = new Mock<IWeekService>();
        serviceMock.Setup(mock => mock.GetWeeksAsync()).ReturnsAsync(weeks);
        serviceMock.Setup(mock => mock.GetWeekByIdAsync(It.IsAny<int>())).ReturnsAsync(weeks[3]);


        var store = new Mock<IUserStore<Spartan>>();
        var userMgrMock = new Mock<UserManager<Spartan>>(store.Object, null, null, null, null, null, null, null, null);
        userMgrMock.Setup(mock => mock.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(spartan);

        var sut = new WeeksController(serviceMock.Object, userMgrMock.Object);
        sut.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };

        // Act
        var result = sut.Details(It.IsAny<int>()).Result;
        var viewResult = (UnauthorizedResult)result;

        // Assert
        Assert.That(viewResult.StatusCode, Is.EqualTo(401));
    }

    #endregion

    #region Create()
    [Test]
    public void Create_ReturnsTypeOfView()
    {
        // Arrange
        var serviceMock = new Mock<IWeekService>();
        serviceMock.Setup(mock => mock.GetWeeksAsync()).ReturnsAsync(new List<Week>());

        var store = new Mock<IUserStore<Spartan>>();
        var userMgrMock = new Mock<UserManager<Spartan>>(store.Object, null, null, null, null, null, null, null, null);
        userMgrMock.Setup(mock => mock.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(It.IsAny<Spartan>());

        var sut = new WeeksController(serviceMock.Object, userMgrMock.Object);

        // Act
        var result = sut.Create();

        // Assert
        Assert.That(result, Is.TypeOf(typeof(ViewResult)));
    }
    #endregion

    #region Create(Week)
    [Test]
    public void Create_ReturnsRedirect()
    {
        // Arrange
        Spartan spartan = new Spartan() { Id = Guid.NewGuid().ToString() };

        Week week = new Week { 
            SpartanId = spartan.Id,
            Spartan = spartan
        };

        var serviceMock = new Mock<IWeekService>();

        var store = new Mock<IUserStore<Spartan>>();
        var userMgrMock = new Mock<UserManager<Spartan>>(store.Object, null, null, null, null, null, null, null, null);
        userMgrMock.Setup(mock => mock.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(spartan);

        var sut = new WeeksController(serviceMock.Object, userMgrMock.Object);
        sut.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };

        // Act
        var result = sut.Create(week).Result;
        var resultType = (RedirectToActionResult)result;

        // Assert
        Assert.That(resultType.ActionName, Is.EqualTo("Index"));
    }
    #endregion

    #region Edit(int)
    [Test]
    public void Edit_ReturnsTypeOfWeek()
    {
        // Arrange
        Spartan spartan = new Spartan() { Id = Guid.NewGuid().ToString() };

        List<Week> weeks = new List<Week>();
        weeks.Add(new Week { SpartanId = spartan.Id });

        var serviceMock = new Mock<IWeekService>();
        serviceMock.Setup(mock => mock.GetWeeksAsync()).ReturnsAsync(weeks);
        serviceMock.Setup(mock => mock.GetWeekByIdAsync(It.IsAny<int>())).ReturnsAsync(weeks[0]);


        var store = new Mock<IUserStore<Spartan>>();
        var userMgrMock = new Mock<UserManager<Spartan>>(store.Object, null, null, null, null, null, null, null, null);
        userMgrMock.Setup(mock => mock.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(spartan);

        var sut = new WeeksController(serviceMock.Object, userMgrMock.Object);
        sut.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };

        // Act
        var result = sut.Edit(It.IsAny<int>()).Result;
        var viewResult = (ViewResult)result;
        var viewData = (Week)viewResult.ViewData.Model;

        // Assert
        Assert.That(viewData, Is.TypeOf<Week>());
    }

    [Test]
    public void Edit_GivenValidId_ReturnsWeek()
    {
        // Arrange
        Spartan spartan = new Spartan() { Id = Guid.NewGuid().ToString() };

        List<Week> weeks = new List<Week>();
        weeks.Add(new Week { SpartanId = spartan.Id });
        weeks.Add(new Week { SpartanId = spartan.Id });
        weeks.Add(new Week
        {
            SpartanId = spartan.Id,
            Start = "Listening Babytron",
            Stop = "Unit testing"
        });
        weeks.Add(new Week { SpartanId = Guid.NewGuid().ToString() });
        weeks.Add(new Week { SpartanId = Guid.NewGuid().ToString() });

        var serviceMock = new Mock<IWeekService>();
        serviceMock.Setup(mock => mock.GetWeeksAsync()).ReturnsAsync(weeks);
        serviceMock.Setup(mock => mock.GetWeekByIdAsync(2)).ReturnsAsync(weeks[2]);


        var store = new Mock<IUserStore<Spartan>>();
        var userMgrMock = new Mock<UserManager<Spartan>>(store.Object, null, null, null, null, null, null, null, null);
        userMgrMock.Setup(mock => mock.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(spartan);

        var sut = new WeeksController(serviceMock.Object, userMgrMock.Object);
        sut.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };

        // Act
        var result = sut.Edit(2).Result;
        var viewResult = (ViewResult)result;
        var viewData = (Week)viewResult.ViewData.Model;

        // Assert
        Assert.That(viewData.SpartanId, Is.EqualTo(spartan.Id));
        Assert.That(viewData.Start, Is.EqualTo(weeks[2].Start));
        Assert.That(viewData.Stop, Is.EqualTo(weeks[2].Stop));
    }

    [Test]
    public void Edit_GivenWeeksUnpopulated_Returns404NotFound()
    {
        // Arrange
        var serviceMock = new Mock<IWeekService>();
        serviceMock.Setup(mock => mock.GetWeeksAsync()).ReturnsAsync(It.IsAny<List<Week>>());

        var store = new Mock<IUserStore<Spartan>>();
        var userMgrMock = new Mock<UserManager<Spartan>>(store.Object, null, null, null, null, null, null, null, null);

        var sut = new WeeksController(serviceMock.Object, userMgrMock.Object);
        sut.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };

        // Act
        var result = sut.Edit(It.IsAny<int>()).Result;
        var viewResult = (NotFoundResult)result;

        // Assert
        Assert.That(viewResult.StatusCode, Is.EqualTo(404));
    }

    [Test]
    public void Edit_GivenWeekIsNotInDB_Returns404NotFound()
    {
        // Arrange
        List<Week> weeks = new List<Week>();
        weeks.Add(new Week { Id = 1 });
        weeks.Add(new Week { Id = 2 });
        weeks.Add(new Week { Id = 3 });

        var serviceMock = new Mock<IWeekService>();
        serviceMock.Setup(mock => mock.GetWeeksAsync()).ReturnsAsync(weeks);
        serviceMock.Setup(mock => mock.GetWeekByIdAsync(It.IsAny<int>())).ReturnsAsync(value: null);


        var store = new Mock<IUserStore<Spartan>>();
        var userMgrMock = new Mock<UserManager<Spartan>>(store.Object, null, null, null, null, null, null, null, null);

        var sut = new WeeksController(serviceMock.Object, userMgrMock.Object);
        sut.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };

        // Act
        var result = sut.Edit(It.IsAny<int>()).Result;
        var viewResult = (NotFoundResult)result;

        // Assert
        Assert.That(viewResult.StatusCode, Is.EqualTo(404));
    }

    [Test]
    public void Edit_GivenWeekCreatedByOtherTrainee_ReturnsUnauthorized()
    {
        // Arrange
        Spartan spartan = new Spartan() { Id = Guid.NewGuid().ToString() };

        List<Week> weeks = new List<Week>();
        weeks.Add(new Week { SpartanId = spartan.Id });
        weeks.Add(new Week { SpartanId = spartan.Id });
        weeks.Add(new Week { SpartanId = spartan.Id });
        weeks.Add(new Week { SpartanId = Guid.NewGuid().ToString() });
        weeks.Add(new Week { SpartanId = Guid.NewGuid().ToString() });

        var serviceMock = new Mock<IWeekService>();
        serviceMock.Setup(mock => mock.GetWeeksAsync()).ReturnsAsync(weeks);
        serviceMock.Setup(mock => mock.GetWeekByIdAsync(It.IsAny<int>())).ReturnsAsync(weeks[3]);


        var store = new Mock<IUserStore<Spartan>>();
        var userMgrMock = new Mock<UserManager<Spartan>>(store.Object, null, null, null, null, null, null, null, null);
        userMgrMock.Setup(mock => mock.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(spartan);

        var sut = new WeeksController(serviceMock.Object, userMgrMock.Object);
        sut.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };

        // Act
        var result = sut.Edit(It.IsAny<int>()).Result;
        var viewResult = (UnauthorizedResult)result;

        // Assert
        Assert.That(viewResult.StatusCode, Is.EqualTo(401));
    }
    #endregion

    #region Edit(int, Week)

    [Test]
    public void Edit_GivenWeekIdDoesntMatchUrlId_ReturnsNotFound()
    {
        // Arrange
        var serviceMock = new Mock<IWeekService>();

        var store = new Mock<IUserStore<Spartan>>();
        var userMgrMock = new Mock<UserManager<Spartan>>(store.Object, null, null, null, null, null, null, null, null);

        var sut = new WeeksController(serviceMock.Object, userMgrMock.Object);
        sut.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };

        int id = 4;
        Week week = new Week
        {
            Id = 6
        };

        // Act
        var result = sut.Edit(id, week).Result;
        var viewResult = (NotFoundResult)result;

        // Assert
        Assert.That(viewResult.StatusCode, Is.EqualTo(404));
    }

    [Test]
    public void Edit_GivenWeekDoesntBelongToSpartan_ReturnsUnauthorised()
    {
        // Arrange
        Spartan spartan = new Spartan() { Id = Guid.NewGuid().ToString() };

        List<Week> weeks = new List<Week>();
        weeks.Add(new Week { SpartanId = Guid.NewGuid().ToString() });

        var serviceMock = new Mock<IWeekService>();
        serviceMock.Setup(mock => mock.GetWeekByIdAsync(It.IsAny<int>())).ReturnsAsync(weeks[0]);


        var store = new Mock<IUserStore<Spartan>>();
        var userMgrMock = new Mock<UserManager<Spartan>>(store.Object, null, null, null, null, null, null, null, null);
        userMgrMock.Setup(mock => mock.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(spartan);

        var sut = new WeeksController(serviceMock.Object, userMgrMock.Object);
        sut.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };

        // Act
        var result = sut.Edit(It.IsAny<int>(), weeks[0]).Result;
        var viewResult = (UnauthorizedResult)result;

        // Assert
        Assert.That(viewResult.StatusCode, Is.EqualTo(401));
    }

    [Ignore("Method exit never reached")]
    [Test]
    public void Edit_GivenSaveChangesFailsIfWeekDoesntExist_ReturnsNotFound()
    {
        // Arrange
        Spartan spartan = new Spartan() { Id = Guid.NewGuid().ToString() };

        List<Week> weeks = new List<Week>();
        weeks.Add(new Week { SpartanId = spartan.Id });

        var serviceMock = new Mock<IWeekService>();
        serviceMock.Setup(mock => mock.GetWeekByIdAsync(It.IsAny<int>())).ReturnsAsync(weeks[0]);
        serviceMock.Setup(mock => mock.SaveChangesAsync()).ThrowsAsync(new Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException());

        var store = new Mock<IUserStore<Spartan>>();
        var userMgrMock = new Mock<UserManager<Spartan>>(store.Object, null, null, null, null, null, null, null, null);
        userMgrMock.Setup(mock => mock.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(spartan);

        var sut = new WeeksController(serviceMock.Object, userMgrMock.Object);
        sut.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };

        // Act
        var result = sut.Edit(It.IsAny<int>(), weeks[0]).Result;
        var viewResult = (NotFoundResult)result;

        // Assert
        Assert.That(viewResult.StatusCode, Is.EqualTo(404));
    }

    [Test]
    public void Edit_GivenSaveChangesFailsIfWeekDoesExist_ThrowsException()
    {
        // Arrange
        Spartan spartan = new Spartan() { Id = Guid.NewGuid().ToString() };

        List<Week> weeks = new List<Week>();
        weeks.Add(new Week { SpartanId = spartan.Id });

        var serviceMock = new Mock<IWeekService>();
        serviceMock.Setup(mock => mock.GetWeekByIdAsync(It.IsAny<int>())).ReturnsAsync(weeks[0]);
        serviceMock.Setup(mock => mock.SaveChangesAsync()).ThrowsAsync(new Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException());

        var store = new Mock<IUserStore<Spartan>>();
        var userMgrMock = new Mock<UserManager<Spartan>>(store.Object, null, null, null, null, null, null, null, null);
        userMgrMock.Setup(mock => mock.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(spartan);

        var sut = new WeeksController(serviceMock.Object, userMgrMock.Object);
        sut.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };

        // Act

        // Assert
        Assert.That(async () => await sut.Edit(It.IsAny<int>(), weeks[0]), Throws.Exception.TypeOf<DbUpdateConcurrencyException>());
    }
    #endregion

    #region Delete(int)

    [Test]
    public void Delete_GivenWeeksTableIsEmpty_Return404()
    {
        // Arrange
        var serviceMock = new Mock<IWeekService>();
        serviceMock.Setup(mock => mock.GetWeeksAsync()).ReturnsAsync(new List<Week>());

        var store = new Mock<IUserStore<Spartan>>();
        var userMgrMock = new Mock<UserManager<Spartan>>(store.Object, null, null, null, null, null, null, null, null);

        var sut = new WeeksController(serviceMock.Object, userMgrMock.Object);
        sut.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };

        // Act
        var result = sut.Delete(It.IsAny<int>()).Result;
        var viewResult = (NotFoundResult)result;

        // Assert
        Assert.That(viewResult.StatusCode, Is.EqualTo(404));
    }

    [Test]
    public void Delete_GivenInvalidId_Return404()
    {
        // Arrange
        List<Week> weeks = new List<Week>();
        weeks.Add(new Week { Id = 1 });
        weeks.Add(new Week { Id = 2 });
        weeks.Add(new Week { Id = 3 });

        var serviceMock = new Mock<IWeekService>();
        serviceMock.Setup(mock => mock.GetWeeksAsync()).ReturnsAsync(weeks);
        serviceMock.Setup(mock => mock.GetWeekByIdAsync(It.IsAny<int>())).ReturnsAsync(value: null);


        var store = new Mock<IUserStore<Spartan>>();
        var userMgrMock = new Mock<UserManager<Spartan>>(store.Object, null, null, null, null, null, null, null, null);

        var sut = new WeeksController(serviceMock.Object, userMgrMock.Object);
        sut.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };

        // Act
        var result = sut.Delete(It.IsAny<int>()).Result;
        var viewResult = (NotFoundResult)result;

        // Assert
        Assert.That(viewResult.StatusCode, Is.EqualTo(404));
    }

    [Test]
    public void Delete_GivenValidId_ReturnsWeek()
    {
        // Arrange
        Spartan spartan = new Spartan() { Id = Guid.NewGuid().ToString() };

        List<Week> weeks = new List<Week>();
        weeks.Add(new Week { SpartanId = spartan.Id });
        weeks.Add(new Week { SpartanId = spartan.Id });
        weeks.Add(new Week
        {
            SpartanId = spartan.Id,
            Start = "Listening Babytron",
            Stop = "Unit testing"
        });
        weeks.Add(new Week { SpartanId = Guid.NewGuid().ToString() });
        weeks.Add(new Week { SpartanId = Guid.NewGuid().ToString() });

        var serviceMock = new Mock<IWeekService>();
        serviceMock.Setup(mock => mock.GetWeeksAsync()).ReturnsAsync(weeks);
        serviceMock.Setup(mock => mock.GetWeekByIdAsync(2)).ReturnsAsync(weeks[2]);


        var store = new Mock<IUserStore<Spartan>>();
        var userMgrMock = new Mock<UserManager<Spartan>>(store.Object, null, null, null, null, null, null, null, null);
        userMgrMock.Setup(mock => mock.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(spartan);

        var sut = new WeeksController(serviceMock.Object, userMgrMock.Object);
        sut.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };

        // Act
        var result = sut.Delete(2).Result;
        var viewResult = (ViewResult)result;
        var viewData = (Week)viewResult.ViewData.Model;

        // Assert
        Assert.That(viewData.SpartanId, Is.EqualTo(spartan.Id));
        Assert.That(viewData.Start, Is.EqualTo(weeks[2].Start));
        Assert.That(viewData.Stop, Is.EqualTo(weeks[2].Stop));
    }
    #endregion

    #region DeleteConfirmed(int)

    [Test]
    public void Delete_ReturnsRedirectToIndex()
    {
        // Arrange
        Spartan spartan = new Spartan() { Id = Guid.NewGuid().ToString() };

        Week week = new Week
        {
            SpartanId = spartan.Id,
            Spartan = spartan
        };

        var serviceMock = new Mock<IWeekService>();
        serviceMock.Setup(mock => mock.GetWeekByIdAsync(week.Id)).ReturnsAsync(week);

        var store = new Mock<IUserStore<Spartan>>();
        var userMgrMock = new Mock<UserManager<Spartan>>(store.Object, null, null, null, null, null, null, null, null);
        userMgrMock.Setup(mock => mock.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(spartan);

        var sut = new WeeksController(serviceMock.Object, userMgrMock.Object);
        sut.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };

        // Act
        var result = sut.DeleteConfirmed(week.Id).Result;
        var resultType = (RedirectToActionResult)result;

        // Assert
        Assert.That(resultType.ActionName, Is.EqualTo("Index"));
    }

    [Test]
    public void Delete_GivenWeekDoesNotBelongToUser_ReturnsUnauthorized()
    {
        // Arrange
        Spartan spartan = new Spartan() { Id = Guid.NewGuid().ToString() };

        List<Week> weeks = new List<Week>();
        weeks.Add(new Week { SpartanId = spartan.Id });
        weeks.Add(new Week { SpartanId = spartan.Id });
        weeks.Add(new Week { SpartanId = spartan.Id });
        weeks.Add(new Week { SpartanId = Guid.NewGuid().ToString() });
        weeks.Add(new Week { SpartanId = Guid.NewGuid().ToString() });

        var serviceMock = new Mock<IWeekService>();
        serviceMock.Setup(mock => mock.GetWeeksAsync()).ReturnsAsync(weeks);
        serviceMock.Setup(mock => mock.GetWeekByIdAsync(It.IsAny<int>())).ReturnsAsync(weeks[3]);


        var store = new Mock<IUserStore<Spartan>>();
        var userMgrMock = new Mock<UserManager<Spartan>>(store.Object, null, null, null, null, null, null, null, null);
        userMgrMock.Setup(mock => mock.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(spartan);

        var sut = new WeeksController(serviceMock.Object, userMgrMock.Object);
        sut.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };

        // Act
        var result = sut.DeleteConfirmed(It.IsAny<int>()).Result;
        var viewResult = (UnauthorizedResult)result;

        // Assert
        Assert.That(viewResult.StatusCode, Is.EqualTo(401));
    }

    [Ignore("Problem not valid to test")]
    [Test]
    public void Delete_GivenInvalidId_ReturnsProblem()
    {
        // Arrange
        var serviceMock = new Mock<IWeekService>();
        serviceMock.Setup(mock => mock.GetWeeksAsync()).ReturnsAsync(new List<Week>());

        var store = new Mock<IUserStore<Spartan>>();
        var userMgrMock = new Mock<UserManager<Spartan>>(store.Object, null, null, null, null, null, null, null, null);

        var sut = new WeeksController(serviceMock.Object, userMgrMock.Object);
        sut.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };

        // Act
        var result = sut.DeleteConfirmed(It.IsAny<int>()).Result;
        var viewResult = (ObjectResult)result;

        // Assert
        //Assert.That(viewResult., Is.EqualTo(401));
    }
    #endregion
}