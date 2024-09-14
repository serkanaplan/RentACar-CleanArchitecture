using NArchitecture.Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Entities;

public class Car : Entity<Guid>
{
    public Guid ModelId { get; set; } //model nesnesinin içerisinde zaten brandId olduğu için onu buraya eklemedik
    public int Kilometer { get; set; }
    public short ModelYear { get; set; }
    public string Plate { get; set; }
    public short MinFindexScore { get; set; }
    public CarState CarState { get; set; }
    public virtual Model? Model { get; set; }

    public Car() { }
    // this parametresiz yapıcınında çalışmasını sağlar. yabi aşağıdaki yapıcı çağırılırsa otomatik olarak yukarıdaki yapıcı da çalışacaktır 
    public Car(Guid id, Guid modelId, CarState carState, int kilometer, short modelYear, string plate, short minFindexScore) : this()
    {
        Id = id;
        ModelId = modelId;
        CarState = carState;
        Kilometer = kilometer;
        ModelYear = modelYear;
        Plate = plate;
        MinFindexScore = minFindexScore;
    }
}
