// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp


[<EntryPoint>]
let main argv =
    
    Problem1.explicitRcursiveSolution
    Problem1.listSolution
    System.Console.ReadKey() |> ignore
    0 // return an integer exit code