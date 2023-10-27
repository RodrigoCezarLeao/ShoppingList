namespace API.Models {
    public class Product {
        public int Id {get; set;}
        public required string Name {get; set;}
        public required string UnitOfMeasured { get; set; }

        public override string ToString(){
            return $"({this.Id}) {this.Name} - {this.UnitOfMeasured}";
        }
    }
}