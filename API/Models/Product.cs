namespace API.Models {
    public class Product {
        public int Id {get; set;}
        public required string Name {get; set;}
        public required string UnitOfMeasure { get; set; }

        public override string ToString(){
            return $"({this.Id}) {this.Name} - {this.UnitOfMeasure}";
        }
    }
}