/*

using static System.Formats.Asn1.AsnWriter;

[AllureTms("265196")]
[Test(Description = "GET cases - permissions")]
public void GetCasesWithDifferentPermissionsTest()
{
    Given("Создаем пользователя_1");
    var user1 = new UserHelper(Scope.AdminConfiguration).CreateAdminUser();

    And("Создаем пользователя_2");
    var user2 = new UserHelper(Scope.AdminConfiguration).CreateAdminUser();

    And("Создаем пользователя_3");
    var user3 = new UserHelper(Scope.AdminConfiguration).CreateAdminUser();

    And($"Авторизуемся через API пользователем_1 {user1.Email}");
    var conf1 = new Login().LoginConfiguration(Scope.SiteUri.ToString(), user1.Email,
        user1.Password);

    And($"Создаем дело пользователем_1 {user1.Email}");
    var caseName1 = Guid.NewGuid().ToString();
    new CaseHelper(conf1).CreateCase(caseName1, Scope.DefaultCaseType);

    And($"Авторизуемся через API пользователем_2 {user2.Email}");
    var conf2 = new Login().LoginConfiguration(Scope.SiteUri.ToString(), user2.Email,
        user2.Password);

    And($"Создаем дело пользователем_2 {user2.Email}");
    var caseName2 = Guid.NewGuid().ToString();
    new CaseHelper(conf2).CreateCase(caseName2, Scope.DefaultCaseType);

    And($"Создаем еще дело пользователем_2 {user2.Email}");
    var caseName3 = Guid.NewGuid().ToString();
    new CaseHelper(conf2).CreateCase(caseName3, Scope.DefaultCaseType);

    And($"Шарим дело {caseName3} пользователю_1 {user1.Email}");
    new SharingHelper(conf2).ShareCase(caseName3, user1.ToString(), AccessLevelEnum.View);

    And($"Авторизуемся через API пользователем_3 {user3.Email}");
    var conf3 = new Login().LoginConfiguration(Scope.SiteUri.ToString(), user3.Email,
        user3.Password);

    And($"Создаем дело пользователем_3 {user3.Email}");
    var caseName4 = Guid.NewGuid().ToString();
    var caseId = new CaseHelper(conf3).CreateCase(caseName4, Scope.DefaultCaseType);

    And($"Создаем группу с пользователем {user1}");
    var groupName = Guid.NewGuid().ToString();
    new UserGroupsHelper(Scope.AdminConfiguration).CreateUserGroup(new UserGroup
    {
        Name = groupName,
        Users = new List<CaseProUser> { user1 },
        CasesAccess = new Access
        {
            Authors = new List<string> { user3.ToString() },
            AccessLevel = AccessLevelEnum.Edit
        }
    });

    And("Ждем пока дело_4 расшарится на пользователя");
    ApiWaitHelper.WaitUntilAutoSharingFolderAndProjectAndCases(conf1, caseName: caseName4);

    And($"Авторизуемся пользователем {user1.Email} через публичное API на инстансе {Scope.SiteUri}");
    var publicConf = new LoginForPublicApi()
        .LoginConfiguration(Scope.SiteUri.ToString(), user1.Email, user1.Password);

    When("Получаем список дел");
    var currentDate = DateTimeProvider.UtcNow;
    var casesList = new PublicCaseHelper(publicConf).GetCases();

    Then("Проверяем сортировку дел");
    var cases = new List<string> { caseName1, caseName3, caseName4 };
    cases.Sort();
    casesList.Items.Select(x => x.Name).ShouldBe(cases);

    And($"Проверяем информацию о деле {caseName4}");
    var caseInfo = casesList.Items.Find(x => x.Name == caseName4);
    caseInfo.ShouldSatisfyAllConditions(
        () => caseInfo.Assignee.Name.ShouldBe($"{user3.FirstName} {user3.LastName}"),
        () => caseInfo.CaseType.Name.ShouldBe(Scope.DefaultCaseType),
        () => caseInfo.CreationDate.Value.ShouldBeInRange(currentDate.AddMinutes(-1),
            currentDate.AddMinutes(1)),
        () => caseInfo.Folder.ShouldBeNull(),
        () => caseInfo.Id.ShouldBe(caseId),
        () => caseInfo.IsArchive.Value.ShouldBeFalse(),
        () => caseInfo.Project.ShouldBeNull()
    );
}



public CaseMapPublicApiPaginationPageCaseMapPublicApiCasesCase GetCases(string caseTypeId = null,
string folderId = null,
string projectId = null,
string assigneeId = null, bool? isArchive = null, DateTime? minDate = null, DateTime? maxDate = null, DateTime? minChangeDate = null,
DateTime? maxChangeDate = null, string objectClassId = null,
int page = 1, int pageSize = 100500)
{
    return new ObjectsApi(Configuration).GetObjects(
    caseTypeId,
    folderId,
    projectId,
    assigneeId,
    isArchive,
    minDate,
    maxDate,
    minChangeDate,
    maxChangeDate,
    objectClassId,
    page: page,
    pageSize: pageSize);
}

*/