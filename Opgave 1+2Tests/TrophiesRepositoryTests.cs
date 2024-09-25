[TestClass()]
public class TrophiesRepositoryTests
{

    [TestMethod()]
    public void GetTestFilterByYear()
    {
        // Arrange
        var repository = new TrophiesRepository();
        var expectedYear = 2020;
        repository.AddTrophy(new Trophy { Competition = "Competition1", Year = expectedYear });
        repository.AddTrophy(new Trophy { Competition = "Competition2", Year = 2021 });

        // Act
        var result = repository.Get(expectedYear);

        // Assert
        Assert.AreEqual(1, result.Count);
        Assert.IsTrue(result.All(t => t.Year == expectedYear));

    }

    [TestMethod()]
    public void RemoveTest()
    {
        // Arrange
        Trophy trophy = new Trophy
        {
            Id = 1,
            Competition = "OL Mesterskab",
            Year = 2001
        };

        TrophiesRepository trophyRepository = new TrophiesRepository();
        trophyRepository.AddTrophy(trophy);

        // Act
        var result = trophyRepository.Remove(trophy.Id);

        // Assert
        Assert.IsNotNull(result); // Check if the result is not null
        Assert.AreEqual(trophy.Id, result.Id); // Check if the correct teacher is returned
        Assert.IsFalse(trophyRepository.Get().Any(t => t.Id == trophy.Id)); // Check if the teacher is actually removed
    }

    [TestMethod()]
    public void UpdateTest()
    {
        // Arrange
        var repository = new TrophiesRepository();
        var originalTrophy = new Trophy { Competition = "Original Competition", Year = 2020 };
        repository.AddTrophy(originalTrophy);
        var updatedValues = new Trophy { Competition = "Updated Competition", Year = 2021 };

        // Act
        var updatedTrophy = repository.Update(originalTrophy.Id, updatedValues);

        // Assert
        Assert.IsNotNull(updatedTrophy);
        Assert.AreEqual(updatedValues.Competition, updatedTrophy.Competition);
        Assert.AreEqual(updatedValues.Year, updatedTrophy.Year);
    }
}

