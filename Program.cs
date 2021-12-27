var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var NomyApes= new List<NomyApe>();
var index = 1;
var  NomyApe= new NomyApe("Nicolas","Ochoa");

NomyApe.id=index;
NomyApes.Add(NomyApe);


//GETALL
app.MapGet("/api/NomyApes",() => NomyApes);

//GET
app.MapGet("/api/NomyApes/{id}",(int id) =>{
    var NomyApe= NomyApes.FirstOrDefault(x => x.id == id );
    return NomyApe;
});

//CREATE
app.MapPost("/api/NomyApes",(NomyApe nomyapeinput) =>
{

    var exist = NomyApes.FirstOrDefault(x => (x.Name.ToLower() == nomyapeinput.Name.ToLower()) && (x.Surname.ToLower() == nomyapeinput.Surname.ToLower()));
    
    if (exist != null){

        return false;
    }

    nomyapeinput.id = index++;
    NomyApes.Add(nomyapeinput);
    return true;
});


//EDIT
app.MapPut("/api/NomyApes",(NomyApe nomyapeinput) =>
{

    var exist = NomyApes.FirstOrDefault(x => x.id == nomyapeinput.id);
    if (exist == null){

        return false;
    }
    NomyApes.Remove(NomyApe);
    NomyApes.Add(nomyapeinput);

    return true;
});

//DELETE
app.MapDelete("/api/NomyApes/{id}",(int id) =>
{

    var exist = NomyApes.FirstOrDefault(x => x.id == id);
    if (exist == null){

        return false;
    }

    NomyApes.Remove(NomyApe);

    return true;
});


app.Run();
