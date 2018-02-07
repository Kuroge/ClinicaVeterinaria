using Model;
using Model.Repositories;
using Model.Repositories.Implementation;
using System;
using System.Linq;
using Xunit;

namespace ModelTest
{
    public class AnimalRepositoryTest
    {
        [Fact]
        public void AnimalRepository_Add_ItemOk_Success()
        {
            //Arrange(Preparaci�n)
            ClinicContext context = new ClinicContext();
            IRepository<Animal> repository = new GenericRepository<Animal>(context);
            Animal animal = new Animal() { Name = "Agumon", Id = 1 };

            //Act(Ejecuci�n)
            repository.Add(animal);

            //Assert (Comprobaci�n)
            Animal expected = context.Animals.Where(x => x.Id == 1).FirstOrDefault();
            Assert.Equal(expected, animal);
        }

        [Fact]
        public void AnimalRepository_Add_NotName_Exception()
        {
            //Arrange (Preparaci�n)
            ClinicContext context = new ClinicContext();
            IRepository<Animal> repository = new AnimalRepository(context);
            Animal animal = new Animal() { Id = 1 };

            //Act (Ejecuci�n)
            Action testCode = () => repository.Add(animal);

            //Assert (Comprobaci�n)
            Assert.Throws<ArgumentNullException>(testCode);
        }
    }
}
