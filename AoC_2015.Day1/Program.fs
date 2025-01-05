module AoC_2015.Day1.Program

[<EntryPoint>]
let main args =
    async {
        use fs = new System.IO.FileStream(args[0], System.IO.FileMode.Open)
        use reader = new System.IO.StreamReader(fs)
        let floor = Floor 0L
        let! fileData = reader.ReadToEndAsync() |> Async.AwaitTask
        
        let directions = fileData.ToCharArray() |> Array.toList |> List.map (fun c -> match c with | '(' -> UpOne | ')' -> DownOne | _ -> invalidOp "Unexpected Character." |> raise)
        
        let finalFloor = Floor.fold floor directions
        
        printfn $"Final Floor: %A{finalFloor}" 
        return 0
    } |> Async.RunSynchronously