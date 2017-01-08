namespace FSharpLibrary

module MyMathLib =
    type TestUser (name : string, age : int) =
       do printfn "%s created" name
       member this.GetFullData = printfn "%s %i" name age

    let PrintUser (x:TestUser) = x.GetFullData
    let PrintUsers (x:seq<TestUser>) = Seq.iter PrintUser x
        
    let square x = x * x
    let sumOfSquares n = 
       [1.0 .. n] |> List.map square |> List.sum
 