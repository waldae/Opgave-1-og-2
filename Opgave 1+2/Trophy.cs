using System;
using System.ComponentModel.DataAnnotations;

//Opgave 1 Class Library og Unit test
//Lav et projekt af typen “Class Library”.

//Lav en klasse Trophy med properties (bemærk de forskellige constraints):

//Id, et tal
//Competition, tekst-streng, min 3 tegn langt, må ikke være null
//Year, tal, 1970 <= year  <= 2024
//samt en ToString() metode

//Der skal være validerings-metoder til de relevante properties.
//Valideringsmetoderne skal kaste passende exceptions

//Tilføj en unit test til dit projekt.

//Din unit test skal have et godt “Code Coverage”

public class Trophy
{
    public int Id { get; set; }
    public string? Competition { get; set; }
    public int Year { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}, Competition: {Competition}, Year: {Year}";
    }

    public void ValidateCompetition()
    {
        if (Competition == null)
        {
            throw new ArgumentNullException("Competition cannot be null");
        }
        if (Competition.Length < 3)
        {
            throw new ArgumentException("Competition must be at least 3 characters long");
        }
    }
    
    public void ValidateYear()
    {
        if (Year < 1970 || Year > 2024)
        {
            throw new ArgumentOutOfRangeException("Year must be between 1970 and 2024");
        }
    }

}

