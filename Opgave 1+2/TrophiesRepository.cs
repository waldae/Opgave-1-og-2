using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Fortsæt i projektet fra forrige opgave.

//Lav en klasse TrophiesRepository.

//Klassen skal indeholde en liste af Trophy objekter. Indsæt mindst 5 objekter i listen.

//Klassen skal have flg metoder:

//Get()
//Returnerer en kopi af listen af alle Trophy objekter: Brug en copy constructor.
//Get() skal give mulighed for at filtrere på Year.
//Get() skal give mulighed for at sortere på Competition eller Year .
//GetById(int id)
//Returnerer Trophy objektet med det angivne id - eller null.
//Add(Trophy  trophy)
//Tilføj id til trophy objektet. Tilføjer trophy til listen. Returnerer Trophy objektet
//Remove(int id)
//Sletter Trophy objektet med det angivne id. Returnerer Trophy objektet - eller null.
//Update(int id, Trophy values)
//Trophy objektet med det angivne id opdateres med values.
//Returnerer det opdaterede Trophy objekt - eller null.

//Din repository-klasse skal unit testes: Du kan nøjes med at teste tre metoder.

//Din testede metoder skal have et godt “Code Coverage”


//Besvarelsen på opgave 1 + 2 skal lægges i et GitHub repository.


public class TrophiesRepository
{
    private List<Trophy> trophies;

    public TrophiesRepository()
    {
        trophies = new List<Trophy>();
        // Insert at least 5 Trophy objects into the list
        trophies.Add(new Trophy());
        trophies.Add(new Trophy());
        trophies.Add(new Trophy());
        trophies.Add(new Trophy());
        trophies.Add(new Trophy());
    }

    public List<Trophy> Get()
    {
        return new List<Trophy>(trophies);
    }

    public List<Trophy> Get(int year)
    {
        return new List<Trophy>(trophies.Where(t => t.Year == year));
    }

    public List<Trophy> Get(string sortBy)
    {
        if (sortBy == "Competition")
        {
            return new List<Trophy>(trophies.OrderBy(t => t.Competition));
        }
        else if (sortBy == "Year")
        {
            return new List<Trophy>(trophies.OrderBy(t => t.Year));
        }
        else
        {
            return new List<Trophy>(trophies);
        }
    }

    public Trophy GetById(int id)
    {
        return trophies.FirstOrDefault(t => t.Id == id);
    }

    public Trophy AddTrophy(Trophy trophy)
    {
        trophy.Id = trophies
            .Select(t => t.Id)
            .DefaultIfEmpty()
            .Max() + 1;
        trophies.Add(trophy);
        return trophy;
    }

    public Trophy Remove(int id)
    {
        Trophy trophy = GetById(id);
        if (trophy != null)
        {
            trophies.Remove(trophy);
        }
        return trophy;
    }

    public Trophy Update(int id, Trophy values)
    {
        Trophy trophy = GetById(id);
        if (trophy != null)
        {
            trophy.Competition = values.Competition;
            trophy.Year = values.Year;
        }
        return trophy;
    }
}

